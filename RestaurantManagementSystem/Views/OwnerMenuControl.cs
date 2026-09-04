using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using RestaurantManagementSystem.DataAccess;

namespace RestaurantManagementSystem.Views
{
    public partial class OwnerMenuControl : UserControl
    {
        private readonly DbConnection _db = new DbConnection();
        private readonly int _ownerId;
        private int _selectedFoodId = -1;

        public OwnerMenuControl(int ownerId)
        {
            InitializeComponent();
            _ownerId = ownerId;
            cmbCategory.SelectedIndex = 0;
            LoadFoodGrid();
        }

        private void LoadFoodGrid()
        {
            string qry = "SELECT food_id, food_name, category, price, stock_quantity FROM [Food]";
            dgvMenu.DataSource = _db.ExecuteQuery(qry);

            foreach (DataGridViewRow row in dgvMenu.Rows)
            {
                if (row.Cells["stock_quantity"].Value != null && Convert.ToInt32(row.Cells["stock_quantity"].Value) <= 5)
                {
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
                }
            }
        }

        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvMenu.Rows[e.RowIndex];
                _selectedFoodId = Convert.ToInt32(r.Cells["food_id"].Value);
                txtFoodName.Text = r.Cells["food_name"].Value.ToString();
                cmbCategory.SelectedItem = r.Cells["category"].Value.ToString();
                nudPrice.Value = Convert.ToDecimal(r.Cells["price"].Value);
                nudStock.Value = Convert.ToInt32(r.Cells["stock_quantity"].Value);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFoodName.Text)) return;
            string qry = "INSERT INTO [Food] (owner_id, food_name, category, price, stock_quantity) VALUES (@oId, @name, @cat, @price, @stock)";
            SqlParameter[] p = {
                new SqlParameter("@oId", _ownerId),
                new SqlParameter("@name", txtFoodName.Text.Trim()),
                new SqlParameter("@cat", cmbCategory.SelectedItem.ToString()),
                new SqlParameter("@price", nudPrice.Value),
                new SqlParameter("@stock", (int)nudStock.Value)
            };
            _db.ExecuteNonQuery(qry, p);
            LoadFoodGrid();
            ClearInputs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedFoodId == -1) return;
            string qry = "UPDATE [Food] SET food_name = @name, category = @cat, price = @price, stock_quantity = @stock WHERE food_id = @id";
            SqlParameter[] p = {
                new SqlParameter("@id", _selectedFoodId),
                new SqlParameter("@name", txtFoodName.Text.Trim()),
                new SqlParameter("@cat", cmbCategory.SelectedItem.ToString()),
                new SqlParameter("@price", nudPrice.Value),
                new SqlParameter("@stock", (int)nudStock.Value)
            };
            _db.ExecuteNonQuery(qry, p);
            LoadFoodGrid();
            ClearInputs();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedFoodId == -1) return;
            string qry = "DELETE FROM [Food] WHERE food_id = @id";
            _db.ExecuteNonQuery(qry, new SqlParameter[] { new SqlParameter("@id", _selectedFoodId) });
            LoadFoodGrid();
            ClearInputs();
        }

        private void ClearInputs()
        {
            _selectedFoodId = -1;
            txtFoodName.Clear();
            nudPrice.Value = 50;
            nudStock.Value = 10;
        }
    }
}