using System.Drawing;
using System.Windows.Forms;

namespace RestaurantManagementSystem.Views
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblRole;
        private Label lblId;
        private Label lblPwd;
        private Label lblError;
        private ComboBox cmbRole;
        private TextBox txtUserId;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnGoRegister;
        private Panel pnlCard;

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
            this.pnlCard = new Panel();
            this.lblTitle = new Label();
            this.lblRole = new Label();
            this.cmbRole = new ComboBox();
            this.lblId = new Label();
            this.txtUserId = new TextBox();
            this.lblPwd = new Label();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.btnGoRegister = new Button();
            this.lblError = new Label();

            // Form Properties
            this.ClientSize = new Size(460, 520);
            this.Text = "Login - Restaurant Management System";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(241, 245, 249);
            this.Font = new Font("Segoe UI", 9.5F);

            // Card Panel Container
            this.pnlCard.Size = new Size(380, 440);
            this.pnlCard.Location = new Point(40, 35);
            this.pnlCard.BackColor = Color.White;
            this.pnlCard.BorderStyle = BorderStyle.FixedSingle;

            // Title
            this.lblTitle.Text = "Restaurant Portal";
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(30, 41, 59);
            this.lblTitle.Size = new Size(340, 35);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Role Dropdown
            this.lblRole.Text = "Select Role";
            this.lblRole.Location = new Point(30, 70);
            this.lblRole.AutoSize = true;
            this.cmbRole.Location = new Point(30, 92);
            this.cmbRole.Size = new Size(320, 28);
            this.cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRole.Items.AddRange(new object[] { "Owner", "Employee", "Customer" });

            // User ID Field
            this.lblId.Text = "User ID";
            this.lblId.Location = new Point(30, 130);
            this.lblId.AutoSize = true;
            this.txtUserId.Location = new Point(30, 152);
            this.txtUserId.Size = new Size(320, 28);

            // Password Field
            this.lblPwd.Text = "Password";
            this.lblPwd.Location = new Point(30, 190);
            this.lblPwd.AutoSize = true;
            this.txtPassword.Location = new Point(30, 212);
            this.txtPassword.Size = new Size(320, 28);
            this.txtPassword.UseSystemPasswordChar = true;

            // Error Label
            this.lblError.Location = new Point(30, 246);
            this.lblError.Size = new Size(320, 20);
            this.lblError.ForeColor = Color.Crimson;
            this.lblError.TextAlign = ContentAlignment.MiddleCenter;

            // Sign In Button
            this.btnLogin.Text = "Sign In";
            this.btnLogin.Location = new Point(30, 275);
            this.btnLogin.Size = new Size(320, 40);
            this.btnLogin.BackColor = Color.FromArgb(234, 88, 12);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            this.btnLogin.Cursor = Cursors.Hand;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // Create New Account Button
            this.btnGoRegister.Text = "Create New Account";
            this.btnGoRegister.Location = new Point(30, 325);
            this.btnGoRegister.Size = new Size(320, 36);
            this.btnGoRegister.BackColor = Color.FromArgb(71, 85, 105);
            this.btnGoRegister.ForeColor = Color.White;
            this.btnGoRegister.FlatStyle = FlatStyle.Flat;
            this.btnGoRegister.FlatAppearance.BorderSize = 0;
            this.btnGoRegister.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnGoRegister.Cursor = Cursors.Hand;
            this.btnGoRegister.Click += new System.EventHandler(this.btnGoRegister_Click);

            // Add Components
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Controls.Add(this.lblRole);
            this.pnlCard.Controls.Add(this.cmbRole);
            this.pnlCard.Controls.Add(this.lblId);
            this.pnlCard.Controls.Add(this.txtUserId);
            this.pnlCard.Controls.Add(this.lblPwd);
            this.pnlCard.Controls.Add(this.txtPassword);
            this.pnlCard.Controls.Add(this.lblError);
            this.pnlCard.Controls.Add(this.btnLogin);
            this.pnlCard.Controls.Add(this.btnGoRegister);

            this.Controls.Add(this.pnlCard);
        }
    }
}