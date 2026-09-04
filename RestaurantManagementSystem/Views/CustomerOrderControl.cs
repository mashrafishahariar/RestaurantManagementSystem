using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using RestaurantManagementSystem.DataAccess;

namespace RestaurantManagementSystem.Views
{
    public partial class CustomerOrderControl : UserControl
    {
        private readonly DbConnection _db = new DbConnection();
        private readonly int _customerId;
        private readonly DataTable _cartTable = new DataTable();

        public CustomerOrderControl(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;

            _cartTable.Columns.Add("FoodId", typeof(int));
            _cartTable.Columns.Add("FoodName", typeof(string));
            _cartTable.Columns.Add("UnitPrice", typeof(decimal));
            _cartTable.Columns.Add("Quantity", typeof(int));
            _cartTable.Columns.Add("Subtotal", typeof(decimal));
            dgvCart.DataSource = _cartTable;

            cmbCategoryFilter.SelectedIndex = 0;
            cmbPriceFilter.SelectedIndex = 0;
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string query = "SELECT food_id, food_name, category, price, stock_quantity FROM [Food] WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                query += " AND food_name LIKE '%' + @search + '%'";

            if (cmbCategoryFilter.SelectedIndex > 0)
                query += " AND category = @cat";

            if (cmbPriceFilter.SelectedIndex == 1) query += " AND price < 200";
            else if (cmbPriceFilter.SelectedIndex == 2) query += " AND price BETWEEN 200 AND 500";
            else if (cmbPriceFilter.SelectedIndex == 3) query += " AND price > 500";

            if (chkInStock.Checked) query += " AND stock_quantity > 0";

            SqlParameter[] p = {
                new SqlParameter("@search", txtSearch.Text.Trim()),
                new SqlParameter("@cat", cmbCategoryFilter.SelectedItem?.ToString() ?? "")
            };

            DataTable dt = _db.ExecuteQuery(query, p);
            dgvFoodCatalog.DataSource = dt;
        }

        private void Filter_Changed(object sender, EventArgs e) => ApplyFilters();

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvFoodCatalog.SelectedRows.Count == 0) return;

            DataGridViewRow r = dgvFoodCatalog.SelectedRows[0];
            int fId = Convert.ToInt32(r.Cells["food_id"].Value);
            string fName = r.Cells["food_name"].Value.ToString();
            decimal price = Convert.ToDecimal(r.Cells["price"].Value);
            int stock = Convert.ToInt32(r.Cells["stock_quantity"].Value);
            int qty = (int)nudQty.Value;

            if (qty > stock)
            {
                MessageBox.Show("Selected quantity exceeds available stock!", "Low Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataRow row in _cartTable.Rows)
            {
                if ((int)row["FoodId"] == fId)
                {
                    row["Quantity"] = (int)row["Quantity"] + qty;
                    row["Subtotal"] = (int)row["Quantity"] * price;
                    UpdateBillSummary();
                    return;
                }
            }

            _cartTable.Rows.Add(fId, fName, price, qty, price * qty);
            UpdateBillSummary();
        }

        private void UpdateBillSummary()
        {
            decimal gross = 0;
            foreach (DataRow r in _cartTable.Rows) gross += Convert.ToDecimal(r["Subtotal"]);

            decimal discount = gross > 1500 ? (gross * 0.10m) : 0;
            decimal net = gross - discount;

            lblGross.Text = $"Gross: {gross:F2} TK";
            lblDiscount.Text = $"Discount: -{discount:F2} TK";
            lblNet.Text = $"Net Total: {net:F2} TK";
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (_cartTable.Rows.Count == 0) return;

            using (SqlConnection con = _db.GetConnection())
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    foreach (DataRow row in _cartTable.Rows)
                    {
                        int foodId = (int)row["FoodId"];
                        int qty = (int)row["Quantity"];
                        decimal price = (decimal)row["UnitPrice"];
                        decimal subtotal = (decimal)row["Subtotal"];

                        string ordQry = @"INSERT INTO [Order] (customer_id, food_id, quantity, unit_price, subtotal) 
                                          OUTPUT INSERTED.order_id 
                                          VALUES (@cId, @fId, @qty, @uPrice, @sub)";
                        SqlCommand cmdOrd = new SqlCommand(ordQry, con, tx);
                        cmdOrd.Parameters.AddWithValue("@cId", _customerId);
                        cmdOrd.Parameters.AddWithValue("@fId", foodId);
                        cmdOrd.Parameters.AddWithValue("@qty", qty);
                        cmdOrd.Parameters.AddWithValue("@uPrice", price);
                        cmdOrd.Parameters.AddWithValue("@sub", subtotal);
                        int orderId = (int)cmdOrd.ExecuteScalar();

                        decimal discount = subtotal > 1500 ? (subtotal * 0.10m) : 0m;
                        decimal net = subtotal - discount;

                        string billQry = @"INSERT INTO [Bill] (order_id, total_amount, discount_amount, net_amount) 
                                           VALUES (@oId, @tot, @disc, @net)";
                        SqlCommand cmdBill = new SqlCommand(billQry, con, tx);
                        cmdBill.Parameters.AddWithValue("@oId", orderId);
                        cmdBill.Parameters.AddWithValue("@tot", subtotal);
                        cmdBill.Parameters.AddWithValue("@disc", discount);
                        cmdBill.Parameters.AddWithValue("@net", net);
                        cmdBill.ExecuteNonQuery();

                        string stockQry = "UPDATE [Food] SET stock_quantity = stock_quantity - @q WHERE food_id = @fId";
                        SqlCommand cmdStock = new SqlCommand(stockQry, con, tx);
                        cmdStock.Parameters.AddWithValue("@q", qty);
                        cmdStock.Parameters.AddWithValue("@fId", foodId);
                        cmdStock.ExecuteNonQuery();
                    }

                    tx.Commit();
                    MessageBox.Show("Order Placed Successfully!", "Invoice Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _cartTable.Clear();
                    UpdateBillSummary();
                    ApplyFilters();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("Checkout Failed: " + ex.Message);
                }
            }
        }
    }
}