namespace RestaurantManagementSystem.Views
{
    public partial class MainShellForm : Form
    {
        private readonly string _role;
        private readonly int _userId;
        private readonly string _userName;

        public MainShellForm(string role, int userId, string userName)
        {
            InitializeComponent();
            _role = role;
            _userId = userId;
            _userName = userName;

            lblUserInfo.Text = $"Welcome, {_userName} | Role: {_role} | User ID: {_userId}";
            SetupRoleTabs();
        }

        private void SetupRoleTabs()
        {
            // Reset all role buttons
            btnMenuCrud.Visible = false;
            btnViewStaff.Visible = false;
            btnOrderCustomer.Visible = false;
            btnEmployeePayroll.Visible = false;

            if (_role == "Owner")
            {
                btnMenuCrud.Visible = true;
                btnViewStaff.Visible = true;
                LoadControl(new OwnerMenuControl(_userId));
            }
            else if (_role == "Employee")
            {
                btnEmployeePayroll.Visible = true;
                LoadControl(new EmployeeDashboardControl(_userId));
            }
            else if (_role == "Customer")
            {
                btnOrderCustomer.Visible = true;
                LoadControl(new CustomerOrderControl(_userId));
            }
        }

        public void LoadControl(UserControl uc)
        {
            pnlMainHost.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMainHost.Controls.Add(uc);
        }

        // Owner Navigation Handlers
        private void btnMenuCrud_Click(object sender, EventArgs e) => LoadControl(new OwnerMenuControl(_userId));
        private void btnViewStaff_Click(object sender, EventArgs e) => LoadControl(new OwnerEmployeesControl());

        // Customer Navigation Handler
        private void btnOrderCustomer_Click(object sender, EventArgs e) => LoadControl(new CustomerOrderControl(_userId));

        // Employee Navigation Handler
        private void btnEmployeePayroll_Click(object sender, EventArgs e) => LoadControl(new EmployeeDashboardControl(_userId));

        // Logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }
    }
}