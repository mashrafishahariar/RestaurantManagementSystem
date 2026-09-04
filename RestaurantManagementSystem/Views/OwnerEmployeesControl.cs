using System;
using System.Data;
using System.Windows.Forms;
using RestaurantManagementSystem.DataAccess;

namespace RestaurantManagementSystem.Views
{
    public partial class OwnerEmployeesControl : UserControl
    {
        private readonly DbConnection _db = new DbConnection();

        public OwnerEmployeesControl()
        {
            InitializeComponent();
            LoadEmployeeData();
        }

        private void LoadEmployeeData()
        {
            string qry = @"SELECT 
                               employee_id AS [Staff ID], 
                               name AS [Full Name], 
                               phone_number AS [Contact], 
                               experience AS [Years of Exp], 
                               salary AS [Base Salary (TK)], 
                               bonus AS [Bonus (TK)],
                               (salary + bonus) AS [Total Payable (TK)] 
                           FROM [Employee]";

            dgvEmployees.DataSource = _db.ExecuteQuery(qry);
        }
    }
}