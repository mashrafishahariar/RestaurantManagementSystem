using System.Drawing;
using System.Windows.Forms;

namespace RestaurantManagementSystem.Views
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle, lblRole, lblName, lblPhone, lblPwd, lblExtra, lblError;
        private ComboBox cmbRole;
        private TextBox txtName, txtPhone, txtPassword;
        private NumericUpDown nudExperience;
        private Button btnRegister, btnBack;
        private Panel pnlCard;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlCard = new Panel();
            this.lblTitle = new Label();
            this.lblRole = new Label();
            this.cmbRole = new ComboBox();
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.lblPwd = new Label();
            this.txtPassword = new TextBox();
            this.lblExtra = new Label();
            this.nudExperience = new NumericUpDown();
            this.lblError = new Label();
            this.btnRegister = new Button();
            this.btnBack = new Button();

            this.ClientSize = new Size(500, 580);
            this.Text = "Register Account - RMS";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(241, 245, 249);
            this.Font = new Font("Segoe UI", 9.5F);

            this.pnlCard.Size = new Size(420, 500);
            this.pnlCard.Location = new Point(40, 35);
            this.pnlCard.BackColor = Color.White;
            this.pnlCard.BorderStyle = BorderStyle.FixedSingle;

            this.lblTitle.Text = "Create New Account";
            this.lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(30, 41, 59);
            this.lblTitle.Size = new Size(380, 35);
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            this.lblRole.Text = "Register As";
            this.lblRole.Location = new Point(30, 60);
            this.lblRole.AutoSize = true;
            this.cmbRole.Location = new Point(30, 80);
            this.cmbRole.Size = new Size(360, 28);
            this.cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRole.Items.AddRange(new object[] { "Customer", "Employee" });
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.cmbRole_SelectedIndexChanged);

            this.lblName.Text = "Full Name";
            this.lblName.Location = new Point(30, 120);
            this.lblName.AutoSize = true;
            this.txtName.Location = new Point(30, 140);
            this.txtName.Size = new Size(360, 28);

            this.lblPhone.Text = "Phone Number";
            this.lblPhone.Location = new Point(30, 180);
            this.lblPhone.AutoSize = true;
            this.txtPhone.Location = new Point(30, 200);
            this.txtPhone.Size = new Size(360, 28);

            this.lblPwd.Text = "Password";
            this.lblPwd.Location = new Point(30, 240);
            this.lblPwd.AutoSize = true;
            this.txtPassword.Location = new Point(30, 260);
            this.txtPassword.Size = new Size(360, 28);
            this.txtPassword.UseSystemPasswordChar = true;

            this.lblExtra.Text = "Experience (Years) [Staff Only]";
            this.lblExtra.Location = new Point(30, 300);
            this.lblExtra.AutoSize = true;
            this.lblExtra.Visible = false;
            this.nudExperience.Location = new Point(30, 325);
            this.nudExperience.Size = new Size(360, 28);
            this.nudExperience.Maximum = 40;
            this.nudExperience.Visible = false;

            this.lblError.Location = new Point(30, 360);
            this.lblError.Size = new Size(360, 20);
            this.lblError.ForeColor = Color.Crimson;
            this.lblError.TextAlign = ContentAlignment.MiddleCenter;

            this.btnRegister.Text = "Register Account";
            this.btnRegister.Location = new Point(30, 390);
            this.btnRegister.Size = new Size(360, 40);
            this.btnRegister.BackColor = Color.FromArgb(234, 88, 12);
            this.btnRegister.ForeColor = Color.White;
            this.btnRegister.FlatStyle = FlatStyle.Flat;
            this.btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            this.btnBack.Text = "Back to Login";
            this.btnBack.Location = new Point(30, 440);
            this.btnBack.Size = new Size(360, 35);
            this.btnBack.BackColor = Color.Gainsboro;
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Controls.Add(this.lblRole);
            this.pnlCard.Controls.Add(this.cmbRole);
            this.pnlCard.Controls.Add(this.lblName);
            this.pnlCard.Controls.Add(this.txtName);
            this.pnlCard.Controls.Add(this.lblPhone);
            this.pnlCard.Controls.Add(this.txtPhone);
            this.pnlCard.Controls.Add(this.lblPwd);
            this.pnlCard.Controls.Add(this.txtPassword);
            this.pnlCard.Controls.Add(this.lblExtra);
            this.pnlCard.Controls.Add(this.nudExperience);
            this.pnlCard.Controls.Add(this.lblError);
            this.pnlCard.Controls.Add(this.btnRegister);
            this.pnlCard.Controls.Add(this.btnBack);
            this.Controls.Add(this.pnlCard);
        }
    }
}