using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNET_DatabaseProgramming
{
    public partial class _Default : Page
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        SqlDataAdapter AdEmp;
        DataSet Ds;
        private object lblerr;

        protected void Page_Load(object sender, EventArgs e)
        {
            Conn = new SqlConnection("Data Source =.; Initial Catalog = Employee; Integrated Security = True"); AdEmp = new SqlDataAdapter("Select * from tbl_employee", Conn);

            Ds = new DataSet();

            if (this.IsPostBack == false)
            {
                Ds = GetDs();
                //BindGrid(Ds);
            }
        }

        private DataSet GetDs()
        {
            AdEmp.Fill(Ds, "Employee");
            return Ds;
        }
        //private void BindGrid(DataSet Ds)

        //{
        //    gdvEmp.DataSource = Ds.Tables["Employee"];
        //   // gdvEmp.DataBind();
        //}
        protected void gdvEmp_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gdvEmp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvEmp.PageIndex = e.NewPageIndex;
            Ds = GetDs();
            //BindGrid(Ds);
        }

        protected void gdvEmp_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gdvEmp.EditIndex = -1;
            Ds = GetDs();
        }

        protected void gdvEmp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int Eno = 0;
                Eno = Convert.ToInt32(gdvEmp.Rows[e.RowIndex].Cells[0].Text);
                Conn.Open(); Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "Delete tbl_employee where EmpNo=@EmpNo";
                Cmd.Parameters.AddWithValue("@EmpNo", Eno);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //lblerr.Text = ex.Message;
            }
            finally
            {
                Conn.Close();
            }
            gdvEmp.EditIndex = -1;
            Ds = GetDs();
        }

        protected void gdvEmp_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gdvEmp.EditIndex = e.NewEditIndex;
            Ds = GetDs();
        }

        protected void gdvEmp_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int Eno, Dno = 0, Sal = 0;
            try
            {
                #region Logic For Reading Selected Row 
                Eno = Convert.ToInt32(gdvEmp.Rows[e.RowIndex].Cells[0].Text);
                Sal = Convert.ToInt32(((TextBox) gdvEmp.Rows[e.RowIndex].Cells[2].Controls[0]).Text );
                Dno = Convert.ToInt32(((TextBox)gdvEmp.Rows[e.RowIndex].Cells[3].Controls[0] ).Text);
                #endregion 


                Conn.Open(); Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "Update tbl_employee Set Salary=@Salary,DeptNo=@DeptNo where EmpNo=@EmpNo";
                Cmd.Parameters.AddWithValue("@EmpNo", Eno);
                Cmd.Parameters.AddWithValue("@DeptNo", Dno);
                Cmd.Parameters.AddWithValue("@Salary", Sal);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //lblerr.Text = ex.Message;
            }
            finally { Conn.Close(); }
            gdvEmp.EditIndex = -1; Ds = GetDs();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployee.aspx");
           //hellow
        }
    }
}