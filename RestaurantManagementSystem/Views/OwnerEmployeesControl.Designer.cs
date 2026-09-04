using System.Drawing;
using System.Windows.Forms;

namespace RestaurantManagementSystem.Views
{
    partial class OwnerEmployeesControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private DataGridView dgvEmployees;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.dgvEmployees = new DataGridView();

            this.Size = new Size(960, 660);
            this.Font = new Font("Segoe UI", 9.5F);

            this.lblTitle.Text = "Staff Directory & Payroll Overview";
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Size = new Size(450, 35);

            this.dgvEmployees.Location = new Point(20, 70);
            this.dgvEmployees.Size = new Size(910, 540);
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvEmployees);
        }
    }
}