using IA.ConnectionProvider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TEST_MODEL;

namespace TASK_PROJECT
{


    public partial class AddMultiEmployeeNew : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                binddopDepartment();
            }

        }

        public void binddopDepartment()
        {
            try
            {
                SqlConnection conn = ConnectionClass.GetConnection();
                SqlCommand objSqlCommand = new SqlCommand();
                objSqlCommand.CommandText = "SELECT DEPARTMENT_ID,DEPARTMENT_NAME FROM DEPARTMENT ";
                objSqlCommand.Connection = conn;
                conn.Open();
                cmbDepartment.DataSource = objSqlCommand.ExecuteReader();
                cmbDepartment.DataTextField = "DEPARTMENT_NAME";
                cmbDepartment.DataValueField = "DEPARTMENT_ID";
                cmbDepartment.DataBind();
                conn.Close();

            }
            catch (Exception e) { }
        }
        public void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var objListEMPLOYEE_TABLE123 = new List<EMPLOYEE_TABLE>();

                var objListEMPLOYEE_TABLE = new List<EMPLOYEE_TABLE>();
               
                var objEMPLOYEE_TABLE = new EMPLOYEE_TABLE();
                objEMPLOYEE_TABLE.ID = "123";
                objEMPLOYEE_TABLE.FIRST_NAME = txtFirstName.Text;
                objEMPLOYEE_TABLE.LAST_NAME = txtLastName.Text;
                objEMPLOYEE_TABLE.EMAIL = txtEmail.Text;
                objEMPLOYEE_TABLE.PHONE = txtPhone.Text;
                objEMPLOYEE_TABLE.DEPARTMENT_ID = Convert.ToInt32(cmbDepartment.SelectedValue);
                objEMPLOYEE_TABLE.DATE_OF_BIRTH = DateTime.Now;
                objEMPLOYEE_TABLE.GENDER = "Male";

                objListEMPLOYEE_TABLE.Add(objEMPLOYEE_TABLE);
                objListEMPLOYEE_TABLE123.Add(objEMPLOYEE_TABLE);
                dgdepartment.DataSource = null;
                dgdepartment.DataBind();
                dgdepartment.DataSource = objListEMPLOYEE_TABLE;
                dgdepartment.DataBind();
               

            }



            catch { }


        }




    }
}