using System.Drawing;
using System.Windows.Forms;

namespace RestaurantManagementSystem.Views
{
    partial class OwnerMenuControl
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvMenu;
        private TextBox txtFoodName;
        private ComboBox cmbCategory;
        private NumericUpDown nudPrice, nudStock;
        private Button btnAdd, btnUpdate, btnDelete;
        private Label lbl1, lbl2, lbl3, lbl4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvMenu = new DataGridView();
            this.txtFoodName = new TextBox();
            this.cmbCategory = new ComboBox();
            this.nudPrice = new NumericUpDown();
            this.nudStock = new NumericUpDown();
            this.btnAdd = new Button();
            this.btnUpdate = new Button();
            this.btnDelete = new Button();
            this.lbl1 = new Label();
            this.lbl2 = new Label();
            this.lbl3 = new Label();
            this.lbl4 = new Label();

            this.Size = new Size(960, 660);
            this.Font = new Font("Segoe UI", 9.5F);

            this.dgvMenu.Location = new Point(20, 20);
            this.dgvMenu.Size = new Size(580, 600);
            this.dgvMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMenu.MultiSelect = false;
            this.dgvMenu.ReadOnly = true;
            this.dgvMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMenu.CellClick += new DataGridViewCellEventHandler(this.dgvMenu_CellClick);

            this.lbl1.Text = "Food Item Name";
            this.lbl1.Location = new Point(630, 30);
            this.txtFoodName.Location = new Point(630, 55);
            this.txtFoodName.Size = new Size(290, 28);

            this.lbl2.Text = "Category";
            this.lbl2.Location = new Point(630, 95);
            this.cmbCategory.Location = new Point(630, 120);
            this.cmbCategory.Size = new Size(290, 28);
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategory.Items.AddRange(new object[] { "Fast Food", "Italian", "Beverage", "Main Course" });

            this.lbl3.Text = "Price (TK)";
            this.lbl3.Location = new Point(630, 160);
            this.nudPrice.Location = new Point(630, 185);
            this.nudPrice.Size = new Size(290, 28);
            this.nudPrice.Maximum = 10000;
            this.nudPrice.Value = 100;

            this.lbl4.Text = "Stock Quantity";
            this.lbl4.Location = new Point(630, 225);
            this.nudStock.Location = new Point(630, 250);
            this.nudStock.Size = new Size(290, 28);
            this.nudStock.Maximum = 500;
            this.nudStock.Value = 20;

            this.btnAdd.Text = "Add Food";
            this.btnAdd.Location = new Point(630, 310);
            this.btnAdd.Size = new Size(290, 38);
            this.btnAdd.BackColor = Color.ForestGreen;
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Text = "Update Food";
            this.btnUpdate.Location = new Point(630, 360);
            this.btnUpdate.Size = new Size(290, 38);
            this.btnUpdate.BackColor = Color.DodgerBlue;
            this.btnUpdate.ForeColor = Color.White;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Text = "Delete Food";
            this.btnDelete.Location = new Point(630, 410);
            this.btnDelete.Size = new Size(290, 38);
            this.btnDelete.BackColor = Color.Crimson;
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.Controls.Add(this.dgvMenu);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtFoodName);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.nudStock);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
        }
    }
}