using System.Drawing;
using System.Windows.Forms;

namespace RestaurantManagementSystem.Views
{
    partial class CustomerOrderControl
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtSearch;
        private ComboBox cmbCategoryFilter, cmbPriceFilter;
        private CheckBox chkInStock;
        private DataGridView dgvFoodCatalog, dgvCart;
        private NumericUpDown nudQty;
        private Button btnAddToCart, btnCheckout;
        private Label lblGross, lblDiscount, lblNet;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtSearch = new TextBox();
            this.cmbCategoryFilter = new ComboBox();
            this.cmbPriceFilter = new ComboBox();
            this.chkInStock = new CheckBox();
            this.dgvFoodCatalog = new DataGridView();
            this.nudQty = new NumericUpDown();
            this.btnAddToCart = new Button();
            this.dgvCart = new DataGridView();
            this.lblGross = new Label();
            this.lblDiscount = new Label();
            this.lblNet = new Label();
            this.btnCheckout = new Button();

            this.Size = new Size(960, 660);
            this.Font = new Font("Segoe UI", 9F);

            this.txtSearch.Location = new Point(20, 20);
            this.txtSearch.Size = new Size(180, 26);
            this.txtSearch.TextChanged += new System.EventHandler(this.Filter_Changed);

            this.cmbCategoryFilter.Location = new Point(210, 20);
            this.cmbCategoryFilter.Size = new Size(130, 26);
            this.cmbCategoryFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategoryFilter.Items.AddRange(new object[] { "All Categories", "Fast Food", "Italian", "Beverage", "Main Course" });
            this.cmbCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);

            this.cmbPriceFilter.Location = new Point(350, 20);
            this.cmbPriceFilter.Size = new Size(120, 26);
            this.cmbPriceFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPriceFilter.Items.AddRange(new object[] { "All Prices", "< 200 TK", "200-500 TK", "> 500 TK" });
            this.cmbPriceFilter.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);

            this.chkInStock.Text = "In Stock Only";
            this.chkInStock.Location = new Point(480, 22);
            this.chkInStock.AutoSize = true;
            this.chkInStock.CheckedChanged += new System.EventHandler(this.Filter_Changed);

            this.dgvFoodCatalog.Location = new Point(20, 60);
            this.dgvFoodCatalog.Size = new Size(570, 520);
            this.dgvFoodCatalog.ReadOnly = true;
            this.dgvFoodCatalog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvFoodCatalog.MultiSelect = false;
            this.dgvFoodCatalog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.nudQty.Location = new Point(20, 595);
            this.nudQty.Size = new Size(80, 26);
            this.nudQty.Minimum = 1;
            this.nudQty.Value = 1;

            this.btnAddToCart.Text = "Add To Cart";
            this.btnAddToCart.Location = new Point(110, 592);
            this.btnAddToCart.Size = new Size(140, 32);
            this.btnAddToCart.BackColor = Color.ForestGreen;
            this.btnAddToCart.ForeColor = Color.White;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);

            this.dgvCart.Location = new Point(610, 60);
            this.dgvCart.Size = new Size(330, 360);
            this.dgvCart.ReadOnly = true;
            this.dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.lblGross.Text = "Gross: 0.00 TK";
            this.lblGross.Location = new Point(610, 440);
            this.lblGross.Size = new Size(330, 25);

            this.lblDiscount.Text = "Discount: 0.00 TK";
            this.lblDiscount.Location = new Point(610, 470);
            this.lblDiscount.Size = new Size(330, 25);
            this.lblDiscount.ForeColor = Color.DarkGreen;

            this.lblNet.Text = "Net Total: 0.00 TK";
            this.lblNet.Location = new Point(610, 500);
            this.lblNet.Size = new Size(330, 30);
            this.lblNet.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            this.btnCheckout.Text = "Checkout & Place Order";
            this.btnCheckout.Location = new Point(610, 550);
            this.btnCheckout.Size = new Size(330, 45);
            this.btnCheckout.BackColor = Color.FromArgb(234, 88, 12);
            this.btnCheckout.ForeColor = Color.White;
            this.btnCheckout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);

            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbCategoryFilter);
            this.Controls.Add(this.cmbPriceFilter);
            this.Controls.Add(this.chkInStock);
            this.Controls.Add(this.dgvFoodCatalog);
            this.Controls.Add(this.nudQty);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.lblGross);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblNet);
            this.Controls.Add(this.btnCheckout);
        }
    }
}