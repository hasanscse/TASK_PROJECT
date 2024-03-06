using IA.ConnectionProvider;
using SET_TEST;
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
    public partial class AddMultipleEmployee : System.Web.UI.Page
    {
        //List<EMPLOYEE_TABLE> objListEMPLOYEE_TABLE = new List<EMPLOYEE_TABLE>();
        List<EMPLOYEE_TABLE> OldobjListEMPLOYEE_TABLE = new List<EMPLOYEE_TABLE>();
        string GENDER = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CreateList();
                binddopDepartment();
                txtDateOfBirth.Text = DateTime.Now.ToShortDateString();
                btnAdd.Visible = true;
                btnUpdate.Visible = false;
            }
        }
        private void CreateList()
        {
            List<EMPLOYEE_TABLE> objListEMPLOYEE_TABLE = new List<EMPLOYEE_TABLE>();
            Session["objListEMPLOYEE_TABLE"] = objListEMPLOYEE_TABLE;
        }
        private void Createtable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("FIRST_NAME", typeof(string));
            dt.Columns.Add("LAST_NAME", typeof(string));
            dt.Columns.Add("EMAIL", typeof(string));
            dt.Columns.Add("DEPARTMENT_ID", typeof(int));
            dt.Columns.Add("DATE_OF_BIRTH", typeof(DateTime));
            dt.Columns.Add("PHONE", typeof(string));
            dt.Columns.Add("GENDER", typeof(string));

            Session["tbltemp"] = dt;


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
        protected void txtDateOfBirth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime SelectedDate = Convert.ToDateTime(txtDateOfBirth.Text);
                int age = DateTime.Now.Year - SelectedDate.Year;
                txtAge.Text = age.ToString();
            }
            catch { }

        }      
        public void btnAdd_Click(object sender, EventArgs e)
        {           
            try
            {             

                if (txtFirstName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('First Name Can not Be null!')", true);
                    return;
                }
                if (txtLastName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Last Name Can not Be null!')", true);
                    return;
                }
                if (txtEmail.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Email Can not Be null!')", true);
                    return;
                }
                if (txtPhone.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Email Can not Be null!')", true);
                    return;
                }
                if (txtDateOfBirth.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('DateOfBirth Can not Be null!')", true);
                    return;
                }
                if (rdMale.Checked == true)
                {
                    GENDER = "Male";

                }
                else if (rdFemale.Checked == true)
                {
                    GENDER = "Female";
                }

                EMPLOYEE_TABLE objEMPLOYEE_TABLE = new EMPLOYEE_TABLE();
                objEMPLOYEE_TABLE = FetchItem.EmployeeID();

                var objListEMPLOYEE_TABLE = (List<EMPLOYEE_TABLE>)Session["objListEMPLOYEE_TABLE"];
                int id = 0;
                if (objListEMPLOYEE_TABLE.Count() > 0)
                {
                    id = objListEMPLOYEE_TABLE.Max(x => Convert.ToInt32(x.ID)) + 1;
                }
                else
                {
                    if (String.IsNullOrEmpty(objEMPLOYEE_TABLE.ID))
                    {
                        id = 10001;

                    }
                    else
                    {

                        int last_id = Convert.ToInt32(objEMPLOYEE_TABLE.ID);

                        id = Convert.ToInt32(last_id + 1);

                        // id = 10001;//From Database 
                    }
                }
                if (objListEMPLOYEE_TABLE.Where(x => x.ID == Convert.ToString(id)).Count() > 0)
                {
                    //Some Message.. Already Added

                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Id Already Exist!')", true);
                    return;
                }
                objEMPLOYEE_TABLE.ID = id.ToString();
                objEMPLOYEE_TABLE.FIRST_NAME = txtFirstName.Text;
                objEMPLOYEE_TABLE.LAST_NAME = txtLastName.Text;
                objEMPLOYEE_TABLE.EMAIL = txtEmail.Text;
                objEMPLOYEE_TABLE.PHONE = txtPhone.Text;
                objEMPLOYEE_TABLE.DEPARTMENT_ID = Convert.ToInt32(cmbDepartment.SelectedValue);
                objEMPLOYEE_TABLE.DATE_OF_BIRTH = Convert.ToDateTime(txtDateOfBirth.Text);
                objEMPLOYEE_TABLE.GENDER = GENDER;

                objListEMPLOYEE_TABLE.Add(objEMPLOYEE_TABLE);


                //DataTable dt = (DataTable)Session["tbltemp"];
                //DataRow dr1 = dt.NewRow();
                //dr1["ID"] = "123";
                //dr1["FIRST_NAME"] = txtFirstName.Text;
                //dr1["LAST_NAME"] = txtLastName.Text;
                //dr1["EMAIL"] = txtEmail.Text;
                //dr1["DEPARTMENT_ID"] =20;
                //dr1["DATE_OF_BIRTH"] = "01-jan-2024";
                //dr1["PHONE"] = txtPhone.Text;
                //dr1["GENDER"] = GENDER;
                //dt.Rows.Add(dr1);


                Session["objListEMPLOYEE_TABLE"] = objListEMPLOYEE_TABLE;
                DATA_BIND();
                clearfield();

            }
            catch { }
        }
        private void DATA_BIND()
        {
            var objListEMPLOYEE_TABLE = (List<EMPLOYEE_TABLE>)Session["objListEMPLOYEE_TABLE"];
            dgdepartment.DataSource = objListEMPLOYEE_TABLE;
            dgdepartment.DataBind();
        }
        private void clearfield()
        {
            txtID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtAge.Text = "";
            txtPhone.Text = "";
            txtDateOfBirth.Text = DateTime.Now.ToShortDateString();

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                int i = 0;
                var objlist = (List<EMPLOYEE_TABLE>)Session["objListEMPLOYEE_TABLE"];
                foreach (var obj in objlist)
                {

                    SqlConnection conn = ConnectionClass.GetConnection();
                    SqlCommand objSqlCommand = new SqlCommand();
                    objSqlCommand.CommandText = "FSP_EMPLOYEE_DATA_I";
                    objSqlCommand.CommandType = CommandType.StoredProcedure;
                    objSqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar, 100));
                    objSqlCommand.Parameters["@ID"].Value = obj.ID;
                    objSqlCommand.Parameters.Add(new SqlParameter("@FIRST_NAME", SqlDbType.VarChar, 100));
                    objSqlCommand.Parameters["@FIRST_NAME"].Value = obj.FIRST_NAME;
                    objSqlCommand.Parameters.Add(new SqlParameter("@LAST_NAME", SqlDbType.VarChar, 100));
                    objSqlCommand.Parameters["@LAST_NAME"].Value = obj.LAST_NAME;
                    objSqlCommand.Parameters.Add(new SqlParameter("@EMAIL", SqlDbType.VarChar, 50));
                    objSqlCommand.Parameters["@EMAIL"].Value = obj.EMAIL;
                    objSqlCommand.Parameters.Add(new SqlParameter("@PHONE", SqlDbType.VarChar, 100));
                    objSqlCommand.Parameters["@PHONE"].Value = obj.PHONE;
                    objSqlCommand.Parameters.Add(new SqlParameter("@DEPARTMENT_ID", SqlDbType.Int));
                    objSqlCommand.Parameters["@DEPARTMENT_ID"].Value = obj.DEPARTMENT_ID;
                    objSqlCommand.Parameters.Add(new SqlParameter("@GENDER", SqlDbType.VarChar, 100));
                    objSqlCommand.Parameters["@GENDER"].Value = obj.GENDER;
                    objSqlCommand.Parameters.Add(new SqlParameter("@DATE_OF_BIRTH", SqlDbType.DateTime));
                    objSqlCommand.Parameters["@DATE_OF_BIRTH"].Value = obj.DATE_OF_BIRTH;
                    objSqlCommand.Connection = conn;
                    conn.Open();
                    i = objSqlCommand.ExecuteNonQuery();
                    conn.Close();

                }

                if (i > 0)
                {
                    clearfield();
                    Session["objListEMPLOYEE_TABLE"] = null;
                    CreateList();
                    DATA_BIND();
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Save Successfully!')", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Save Not Successfully!')", true);

                }


            }
            catch (Exception ex) { }
        }
        public static List<EMPLOYEE_TABLE> getData()
        {

            List<EMPLOYEE_TABLE> objListEMPLOYEE_TABLE = new List<EMPLOYEE_TABLE>();
            SqlConnection conn = ConnectionClass.GetConnection();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "FSP_EMPLOYEE_TABLE_GA";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Connection = conn;
            conn.Open();

            SqlDataReader dr = objSqlCommand.ExecuteReader();
            while (dr.Read())
            {
                EMPLOYEE_TABLE objEMPLOYEE_TABLE = new EMPLOYEE_TABLE();
                objEMPLOYEE_TABLE.ID = dr["ID"].ToString();
                objEMPLOYEE_TABLE.FIRST_NAME = dr["FIRST_NAME"].ToString();
                objEMPLOYEE_TABLE.LAST_NAME = dr["LAST_NAME"].ToString();
                objEMPLOYEE_TABLE.PHONE = dr["PHONE"].ToString();
                objEMPLOYEE_TABLE.EMAIL = dr["EMAIL"].ToString();
                objEMPLOYEE_TABLE.DATE_OF_BIRTH = Convert.ToDateTime(dr["DATE_OF_BIRTH"]);
                objEMPLOYEE_TABLE.GENDER = dr["GENDER"].ToString();
                objListEMPLOYEE_TABLE.Add(objEMPLOYEE_TABLE);

            }


            return objListEMPLOYEE_TABLE;



        }
        protected void btndelete_Click(object sender, EventArgs e)
        {

            try
            {
                var objlist = (List<EMPLOYEE_TABLE>)Session["objListEMPLOYEE_TABLE"];
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int i = Convert.ToInt32(row.RowIndex);
                string id = (dgdepartment.Rows[i].FindControl("lblID") as Label).Text;

                EMPLOYEE_TABLE objEMPLOYEE_TABLE = objlist.Where(x => x.ID == id).FirstOrDefault();
                objlist.Remove(objEMPLOYEE_TABLE);
                Session["objListEMPLOYEE_TABLE"] = objlist;
                DATA_BIND();
            }
            catch { }



        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                var objlist = (List<EMPLOYEE_TABLE>)Session["objListEMPLOYEE_TABLE"];
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int i = Convert.ToInt32(row.RowIndex);
                string id = (dgdepartment.Rows[i].FindControl("lblID") as Label).Text;

                foreach (var obj in objlist)
                {
                    if (obj.ID == id)
                    {
                        txtID.Text = obj.ID;
                        txtFirstName.Text = obj.FIRST_NAME;
                        txtLastName.Text = obj.LAST_NAME;
                        txtPhone.Text = obj.PHONE;
                        txtEmail.Text = obj.EMAIL;
                        if (obj.GENDER == "Male")
                        {
                            rdFemale.Checked = false;
                            rdMale.Checked = true;

                        }
                        else
                        {

                            rdFemale.Checked = true;
                            rdMale.Checked = false;

                        }



                    }
                }
            }
            catch { }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                btnAdd.Visible = true;
                btnUpdate.Visible = false;
                var objlist = (List<EMPLOYEE_TABLE>)Session["objListEMPLOYEE_TABLE"];
                string id = txtID.Text;
                foreach (var obj in objlist)
                {
                    if (obj.ID == id)
                    {
                        obj.FIRST_NAME = txtFirstName.Text;
                        obj.LAST_NAME = txtLastName.Text;
                        obj.PHONE = txtPhone.Text;
                        obj.EMAIL = txtEmail.Text;
                        if (rdMale.Checked == true)
                        {
                            obj.GENDER = "Male";
                        }
                        else
                        {
                            obj.GENDER = "Female";
                        }
                    }
                }
                Session["objListEMPLOYEE_TABLE"] = objlist;
                DATA_BIND();
                clearfield();


            }
            catch { }



        }
    }
}