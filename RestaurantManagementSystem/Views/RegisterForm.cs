using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using RestaurantManagementSystem.DataAccess;

namespace RestaurantManagementSystem.Views
{
    public partial class RegisterForm : Form
    {
        private readonly DbConnection _db = new DbConnection();

        public RegisterForm()
        {
            InitializeComponent();
            cmbRole.SelectedIndex = 0;
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isEmployee = cmbRole.SelectedItem.ToString() == "Employee";
            lblExtra.Visible = isEmployee;
            nudExperience.Visible = isEmployee;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "Please fill in all fields.";
                return;
            }

            string role = cmbRole.SelectedItem.ToString();
            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string pwd = txtPassword.Text.Trim();

            try
            {
                if (role == "Customer")
                {
                    string qry = @"INSERT INTO [Customer] (name, phone_number, password) 
                                   OUTPUT INSERTED.customer_id 
                                   VALUES (@name, @phone, @pwd)";
                    SqlParameter[] p = {
                        new SqlParameter("@name", name),
                        new SqlParameter("@phone", phone),
                        new SqlParameter("@pwd", pwd)
                    };

                    int newId = (int)_db.ExecuteScalar(qry, p);
                    MessageBox.Show($"Customer Account Created!\nYour Login ID is: {newId}\nPlease write down this ID to Sign In.", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Employee
                {
                    int exp = (int)nudExperience.Value;
                    decimal baseSalary = 20000.00m;
                    decimal bonus = exp > 3 ? 1000.00m : 0.00m;

                    string qry = @"INSERT INTO [Employee] (name, phone_number, experience, salary, bonus, password) 
                                   OUTPUT INSERTED.employee_id 
                                   VALUES (@name, @phone, @exp, @sal, @bonus, @pwd)";
                    SqlParameter[] p = {
                        new SqlParameter("@name", name),
                        new SqlParameter("@phone", phone),
                        new SqlParameter("@exp", exp),
                        new SqlParameter("@sal", baseSalary),
                        new SqlParameter("@bonus", bonus),
                        new SqlParameter("@pwd", pwd)
                    };

                    int newId = (int)_db.ExecuteScalar(qry, p);
                    MessageBox.Show($"Employee Account Created!\nYour Login ID is: {newId}\nPlease write down this ID to Sign In.", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoginForm login = new LoginForm();
                login.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error: " + ex.Message;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }
    }
}