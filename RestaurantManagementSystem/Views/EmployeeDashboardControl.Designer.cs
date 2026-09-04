using System.Drawing;
using System.Windows.Forms;

namespace RestaurantManagementSystem.Views
{
    partial class EmployeeDashboardControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblHeader, lblDetails;
        private Panel pnlCard;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlCard = new Panel();
            this.lblHeader = new Label();
            this.lblDetails = new Label();

            this.Size = new Size(960, 660);

            this.pnlCard.Location = new Point(40, 40);
            this.pnlCard.Size = new Size(600, 420);
            this.pnlCard.BackColor = Color.White;
            this.pnlCard.BorderStyle = BorderStyle.FixedSingle;

            this.lblHeader.Text = "Employee Salary & Bonus Slip";
            this.lblHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblHeader.Location = new Point(30, 20);
            this.lblHeader.Size = new Size(540, 35);

            this.lblDetails.Font = new Font("Segoe UI", 11F);
            this.lblDetails.Location = new Point(30, 70);
            this.lblDetails.Size = new Size(540, 320);

            this.pnlCard.Controls.Add(this.lblHeader);
            this.pnlCard.Controls.Add(this.lblDetails);
            this.Controls.Add(this.pnlCard);
        }
    }
}