using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNET_DatabaseProgramming
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void closeconnection()
        {
            con.Close();
        }
        public void openconnection()
        {

            con.ConnectionString = "Data Source=.; Initial Catalog = Employee; Integrated Security = True";
            con.Open();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            openconnection();
            SqlCommand cmd = new SqlCommand("insert into tbl_employee" + "(EmpNo,EmpName,EmpSalary,DeptNo) values(@EmpNo,@EmpName,@EmpSalary,@DeptNo)", con);
            cmd.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);
            cmd.Parameters.AddWithValue("@EmpName", txtEmpName.Text);
            cmd.Parameters.AddWithValue("@EmpSalary", txtEmpSalary.Text);
            cmd.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);
            cmd.ExecuteNonQuery();
            Response.Redirect("frmGridViewProgramming.aspx");
            closeconnection();
        }
    }
}