using System.Drawing;
using System.Windows.Forms;

namespace RestaurantManagementSystem.Views
{
    partial class MainShellForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlSidebar;
        private Panel pnlTopBar;
        private Panel pnlMainHost;
        private Label lblLogo;
        private Label lblUserInfo;
        private Button btnMenuCrud;
        private Button btnViewStaff;
        private Button btnOrderCustomer;
        private Button btnEmployeePayroll;
        private Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSidebar = new Panel();
            this.lblLogo = new Label();
            this.btnMenuCrud = new Button();
            this.btnViewStaff = new Button();
            this.btnOrderCustomer = new Button();
            this.btnEmployeePayroll = new Button();
            this.btnLogout = new Button();
            this.pnlTopBar = new Panel();
            this.lblUserInfo = new Label();
            this.pnlMainHost = new Panel();

            // Form Basics
            this.ClientSize = new Size(1180, 720);
            this.Text = "Restaurant Marketplace Management System";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9.5F);

            // Left Navigation Sidebar
            this.pnlSidebar.Dock = DockStyle.Left;
            this.pnlSidebar.Width = 220;
            this.pnlSidebar.BackColor = Color.FromArgb(30, 41, 59);

            // App Logo / Title
            this.lblLogo.Text = "RMS Portal";
            this.lblLogo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblLogo.ForeColor = Color.White;
            this.lblLogo.Size = new Size(220, 70);
            this.lblLogo.TextAlign = ContentAlignment.MiddleCenter;

            // Nav Button: Manage Menu (Owner)
            this.btnMenuCrud.Text = "Manage Menu";
            this.btnMenuCrud.Location = new Point(0, 80);
            this.btnMenuCrud.Size = new Size(220, 45);
            this.btnMenuCrud.FlatStyle = FlatStyle.Flat;
            this.btnMenuCrud.FlatAppearance.BorderSize = 0;
            this.btnMenuCrud.ForeColor = Color.White;
            this.btnMenuCrud.Cursor = Cursors.Hand;
            this.btnMenuCrud.Click += new System.EventHandler(this.btnMenuCrud_Click);

            // Nav Button: View Staff Directory (Owner)
            this.btnViewStaff.Text = "View Staff List";
            this.btnViewStaff.Location = new Point(0, 130);
            this.btnViewStaff.Size = new Size(220, 45);
            this.btnViewStaff.FlatStyle = FlatStyle.Flat;
            this.btnViewStaff.FlatAppearance.BorderSize = 0;
            this.btnViewStaff.ForeColor = Color.White;
            this.btnViewStaff.Cursor = Cursors.Hand;
            this.btnViewStaff.Click += new System.EventHandler(this.btnViewStaff_Click);

            // Nav Button: Order Food (Customer)
            this.btnOrderCustomer.Text = "Order Food";
            this.btnOrderCustomer.Location = new Point(0, 80);
            this.btnOrderCustomer.Size = new Size(220, 45);
            this.btnOrderCustomer.FlatStyle = FlatStyle.Flat;
            this.btnOrderCustomer.FlatAppearance.BorderSize = 0;
            this.btnOrderCustomer.ForeColor = Color.White;
            this.btnOrderCustomer.Cursor = Cursors.Hand;
            this.btnOrderCustomer.Click += new System.EventHandler(this.btnOrderCustomer_Click);

            // Nav Button: Payroll Details (Employee)
            this.btnEmployeePayroll.Text = "My Payroll & Slip";
            this.btnEmployeePayroll.Location = new Point(0, 80);
            this.btnEmployeePayroll.Size = new Size(220, 45);
            this.btnEmployeePayroll.FlatStyle = FlatStyle.Flat;
            this.btnEmployeePayroll.FlatAppearance.BorderSize = 0;
            this.btnEmployeePayroll.ForeColor = Color.White;
            this.btnEmployeePayroll.Cursor = Cursors.Hand;
            this.btnEmployeePayroll.Click += new System.EventHandler(this.btnEmployeePayroll_Click);

            // Nav Button: Sign Out
            this.btnLogout.Text = "Sign Out";
            this.btnLogout.Dock = DockStyle.Bottom;
            this.btnLogout.Height = 50;
            this.btnLogout.BackColor = Color.FromArgb(185, 28, 28);
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnLogout.Cursor = Cursors.Hand;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // Assemble Sidebar
            this.pnlSidebar.Controls.Add(this.lblLogo);
            this.pnlSidebar.Controls.Add(this.btnMenuCrud);
            this.pnlSidebar.Controls.Add(this.btnViewStaff);
            this.pnlSidebar.Controls.Add(this.btnOrderCustomer);
            this.pnlSidebar.Controls.Add(this.btnEmployeePayroll);
            this.pnlSidebar.Controls.Add(this.btnLogout);

            // Top Status Bar
            this.pnlTopBar.Dock = DockStyle.Top;
            this.pnlTopBar.Height = 60;
            this.pnlTopBar.BackColor = Color.FromArgb(248, 250, 252);
            this.pnlTopBar.BorderStyle = BorderStyle.FixedSingle;

            this.lblUserInfo.Location = new Point(20, 18);
            this.lblUserInfo.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            this.lblUserInfo.ForeColor = Color.FromArgb(51, 65, 85);
            this.lblUserInfo.AutoSize = true;
            this.pnlTopBar.Controls.Add(this.lblUserInfo);

            // Central Dynamic Container
            this.pnlMainHost.Dock = DockStyle.Fill;
            this.pnlMainHost.BackColor = Color.FromArgb(241, 245, 249);

            // Add Panels to Form
            this.Controls.Add(this.pnlMainHost);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlSidebar);
        }
    }
}