using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using RestaurantManagementSystem.DataAccess;

namespace RestaurantManagementSystem.Views
{
    public partial class LoginForm : Form
    {
        private readonly DbConnection _db = new DbConnection();

        public LoginForm()
        {
            InitializeComponent();
            cmbRole.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (string.IsNullOrWhiteSpace(txtUserId.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "Please fill in all fields.";
                return;
            }

            if (!int.TryParse(txtUserId.Text.Trim(), out int userId))
            {
                lblError.Text = "User ID must be numeric.";
                return;
            }

            string role = cmbRole.SelectedItem.ToString();
            string pwd = txtPassword.Text.Trim();
            string table = role == "Owner" ? "[Owner]" : (role == "Employee" ? "[Employee]" : "[Customer]");
            string idCol = role == "Owner" ? "owner_id" : (role == "Employee" ? "employee_id" : "customer_id");

            string query = $"SELECT * FROM {table} WHERE {idCol} = @id AND password = @pwd";
            SqlParameter[] parameters = {
                new SqlParameter("@id", userId),
                new SqlParameter("@pwd", pwd)
            };

            DataTable dt = _db.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                string name = dt.Rows[0]["name"].ToString();
                MainShellForm shell = new MainShellForm(role, userId, name);
                shell.Show();
                this.Hide();
            }
            else
            {
                lblError.Text = "Invalid ID or Password!";
            }
        }

        private void btnGoRegister_Click(object sender, EventArgs e)
        {
            RegisterForm reg = new RegisterForm();
            reg.Show();
            this.Hide();
        }
    }
}