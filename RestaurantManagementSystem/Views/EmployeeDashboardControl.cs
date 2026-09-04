using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using RestaurantManagementSystem.DataAccess;

namespace RestaurantManagementSystem.Views
{
    public partial class EmployeeDashboardControl : UserControl
    {
        private readonly DbConnection _db = new DbConnection();
        private readonly int _empId;

        public EmployeeDashboardControl(int empId)
        {
            InitializeComponent();
            _empId = empId;
            LoadInfo();
        }

        private void LoadInfo()
        {
            string qry = "SELECT * FROM [Employee] WHERE employee_id = @id";
            DataTable dt = _db.ExecuteQuery(qry, new SqlParameter[] { new SqlParameter("@id", _empId) });
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                int exp = Convert.ToInt32(r["experience"]);
                decimal sal = Convert.ToDecimal(r["salary"]);
                decimal bonus = exp > 3 ? 1000m : 0m;

                lblDetails.Text = $"Employee ID: {r["employee_id"]}\n\n" +
                                  $"Name: {r["name"]}\n\n" +
                                  $"Phone: {r["phone_number"]}\n\n" +
                                  $"Experience: {exp} Years\n\n" +
                                  $"Base Salary: {sal:F2} TK\n\n" +
                                  $"Calculated Bonus: {bonus:F2} TK {(exp > 3 ? "(Bonus Qualified > 3 Years)" : "(No Bonus)")}\n\n" +
                                  $"Total Payable: {(sal + bonus):F2} TK";
            }
        }
    }
}