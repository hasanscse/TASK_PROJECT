using IA.ConnectionProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TEST_MODEL;

namespace TASK_PROJECT
{

    public partial class EmployeeSalary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                binddopDepartment();
                this.Createtable();
                btnAdd.Visible = true;
                btnUpdate.Visible = false;
            }
        }


        private void Createtable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EMPLOYEE_SALARY_ID", typeof(string));
            dt.Columns.Add("MONTH", typeof(string));
            dt.Columns.Add("YEAR", typeof(string));
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("BASIC_SALARY", typeof(decimal));
            dt.Columns.Add("HOME_RENT", typeof(decimal));
            dt.Columns.Add("OTHER_RENT", typeof(decimal)); 
            Session["tbltemp"] = dt;
        }
        public void binddopDepartment()
        {
            try
            {
                SqlConnection conn = ConnectionClass.GetConnection();
                SqlCommand objSqlCommand = new SqlCommand();
                objSqlCommand.CommandText = "SELECT EMPLOYEE_ID,NAME FROM EMPLOYEE ";
                objSqlCommand.Connection = conn;
                conn.Open();

                cmbEmployee.DataSource = objSqlCommand.ExecuteReader();
                cmbEmployee.DataTextField = "NAME";
                cmbEmployee.DataValueField = "EMPLOYEE_ID";
                cmbEmployee.DataBind();

                conn.Close();

            }
            catch (Exception e) { }
        }
        public void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)Session["tbltemp"];

                int id = 0; ;
                if (dt.Rows.Count > 0)
                {
                    id = dt.Rows.Count + 1;
                }
                else
                {
                    id = 1;
                }

               
                DataRow dr1 = dt.NewRow();
                dr1["EMPLOYEE_SALARY_ID"] = id;
                dr1["MONTH"] = cmbMonth.Text;
                dr1["YEAR"] = cmbYear.Text;
                dr1["ID"] = cmbEmployee.SelectedValue;
                dr1["BASIC_SALARY"] = txtSalary.Text;
                dr1["HOME_RENT"] = txtHomeRent.Text;
                dr1["OTHER_RENT"] = txtOtherRent.Text;         
                dt.Rows.Add(dr1);

                Session["tbltemp"] = dt;
                dgSalary.DataSource = dt;
                dgSalary.DataBind();                


            }
            catch(Exception ex) { }
        }

        public void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {



                EMPLOYEE_SALARY objEMPLOYEE_SALARY = new EMPLOYEE_SALARY();

                var objListEMPLOYEE_TABLE = (List<EMPLOYEE_TABLE>)Session["tbltemp"];
                int id = 0;
                if (objListEMPLOYEE_TABLE.Count() > 0)
                {
                    id = objListEMPLOYEE_TABLE.Max(x => Convert.ToInt32(x.ID)) + 1;
                }
                else
                {
                    id = 1;
                }
          
                DataTable dt = (DataTable)Session["tbltemp"];
                DataRow dr1 = dt.NewRow();
                dr1["EMPLOYEE_SALARY_ID"] = id;
                dr1["MONTH"] = cmbMonth.Text;
                dr1["YEAR"] = cmbYear.Text;
                dr1["ID"] = cmbEmployee.SelectedValue;
                dr1["BASIC_SALARY"] = txtSalary.Text;
                dr1["HOME_RENT"] = txtHomeRent.Text;
                dr1["OTHER_RENT"] = txtOtherRent.Text;
                dt.Rows.Add(dr1);

                Session["tbltemp"] = dt;
                dgSalary.DataSource = dt;
                dgSalary.DataBind();


            }
            catch { }
        }



    }
}