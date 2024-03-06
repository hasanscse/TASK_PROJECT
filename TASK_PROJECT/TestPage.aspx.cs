using IA.ConnectionProvider;
using Microsoft.Reporting.WebForms;
using SET_TEST;
using System;
using System.Collections;
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
    public partial class TestPage : System.Web.UI.Page
    {
        string str;
        int size = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                txtEmployeeID.Visible = false;
                btnUpdate.Visible = false;
                btnAdd.Visible = true;
                bindDepartment();
                gridload();
                binddopDepartment();
                AddEmployeeGroup.Visible = false;



            }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            
            dgdepartment.PageIndex = e.NewPageIndex;
            this.gridload();


        }


        protected void dopPaging_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dopPaging.SelectedItem.Text != "0")
                {
                    size = int.Parse(dopPaging.SelectedItem.Value.ToString());
                    dgdepartment.PageSize = size;
                    this.gridload();
                }

            }
            catch (Exception ex) { }
        }



        protected void btnAddVisible_Click(object sender ,EventArgs e)
        {
            try {

                AddEmployeeGroup.Visible = true;


            }
            catch { }
            

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            try {

                AddEmployeeGroup.Visible = false;

            }
            catch { }
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
        public void bindDepartment()
        {
            try
            {
                SqlConnection conn = ConnectionClass.GetConnection();
                SqlCommand objSqlCommand = new SqlCommand();
                objSqlCommand.CommandText = "select DEPARTMENT_ID=0, DEPARTMENT_NAME='ALL' union all SELECT DEPARTMENT_ID,DEPARTMENT_NAME FROM DEPARTMENT ";
                objSqlCommand.Connection = conn;
                conn.Open();
                dopDepartment.DataSource = objSqlCommand.ExecuteReader();
                dopDepartment.DataTextField = "DEPARTMENT_NAME";
                dopDepartment.DataValueField = "DEPARTMENT_ID";
                dopDepartment.DataBind();
                conn.Close();

            }
            catch (Exception e) { }

        }
        protected void dopDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                 dgdepartment.DataSource = null;
                    dgdepartment.DataBind();

                if (dopDepartment.SelectedValue.ToString() == "0")
                {
                    this.gridload();
                }
                else
                {
                    DataTable dtt = (DataTable)Session["Employeedt"];
                    //DataRow[] rows = dtt.Select("DEPARTMENT_ID ='" + dopDepartment.SelectedValue +"'");
                    DataView dv = dtt.DefaultView;
                    dv.RowFilter = $"DEPARTMENT_ID ={dopDepartment.SelectedValue}";
                    if (dv.Count > 0)
                    {
                        var filldt = dv.ToTable();
                        dgdepartment.DataSource = filldt;
                        dgdepartment.DataBind();
                    }
                }
                //  this.gridload();
            }
            catch (Exception ex) { }
        }

        public void gridload()
        {
            try
            {
                dgdepartment.DataSource = null;
                dgdepartment.DataBind();

                SqlConnection con = ConnectionClass.GetConnection();
                using (SqlCommand cmd = new SqlCommand("FSP_EMPLOYEE_GA"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dgdepartment.DataSource = dt;
                            dgdepartment.DataBind();

                            Session["Employeedt"] = dt;

                        }
                    }

                }

            }
            catch { }

        }
        public static List<EMPLOYEE> EmployeeList()
        {
            List<EMPLOYEE> objListEmployee = new List<EMPLOYEE>();
            SqlConnection conn = ConnectionClass.GetConnection();
            SqlCommand objSqlcommand = new SqlCommand();
            objSqlcommand.CommandText = "FSP_EMPLOYEE_GA";
            objSqlcommand.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = objSqlcommand.ExecuteReader();
            while (dr.Read())
            {
                EMPLOYEE objEMPLOYEE = new EMPLOYEE();
                objEMPLOYEE.DEPARTMENT_ID = Convert.ToInt32(dr["DEPARTMENT_ID"]);
                objEMPLOYEE.DEPARTMENT_NAME = dr["DEPARTMENT_NAME"].ToString();
                objEMPLOYEE.NAME = dr["NAME"].ToString();
                objEMPLOYEE.SALARY = Convert.ToDecimal(dr["SALARY"]);
                objListEmployee.Add(objEMPLOYEE);
            }

            return objListEmployee;
        }
        public void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                EMPLOYEE objEMPLOYEE = new EMPLOYEE();
                objEMPLOYEE.NAME = txtNAME.Text;
                objEMPLOYEE.SALARY = Convert.ToDecimal(txtSalary.Text);
                objEMPLOYEE.DEPARTMENT_ID = Convert.ToInt32(cmbDepartment.SelectedValue);
                int i = SaveItem.saveEmployee(objEMPLOYEE);


                if (i > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Inserted Successful')", true);
                }
                else
                {

                }

                clearfield();
                gridload();


            }
            catch (Exception ex)
            {

                clearfield();
                gridload();

            }


        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                AddEmployeeGroup.Visible = true;
                btnUpdate.Visible = true;
                btnAdd.Visible = false;
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int i = Convert.ToInt32(row.RowIndex);
                string EMPLOYEE_ID = (dgdepartment.Rows[i].FindControl("lblEMPLOYEE_ID") as Label).Text;
                SqlConnection conn = ConnectionClass.GetConnection();
                Label lbldeleteid = (Label)row.FindControl("EMPLOYEE_ID");


                EMPLOYEE objEMPLOYEE = new EMPLOYEE();
                objEMPLOYEE.EMPLOYEE_ID = Convert.ToInt32(EMPLOYEE_ID);

                objEMPLOYEE = FetchItem.EmployeeGK(objEMPLOYEE);

                txtEmployeeID.Text = objEMPLOYEE.EMPLOYEE_ID.ToString();
                txtNAME.Text = objEMPLOYEE.NAME;
                txtSalary.Text = objEMPLOYEE.SALARY.ToString();
                cmbDepartment.SelectedValue = objEMPLOYEE.DEPARTMENT_ID.ToString();


            }
            catch { }


        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                EMPLOYEE objEMPLOYEE = new EMPLOYEE();
                objEMPLOYEE.EMPLOYEE_ID = Convert.ToInt32(txtEmployeeID.Text);
                objEMPLOYEE.NAME = txtNAME.Text;
                objEMPLOYEE.SALARY = Convert.ToDecimal(txtSalary.Text);
                objEMPLOYEE.DEPARTMENT_ID = Convert.ToInt32(cmbDepartment.SelectedValue);

                int i = SaveItem.UpdateEmployee(objEMPLOYEE);

                if (i > 0)
                {
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                    gridload();
                    clearfield();
                }

                else
                {


                }

            }
            catch { }


        }
        protected void btndelete_Click(object sender, EventArgs e)
        {
            try
            {

                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int i = Convert.ToInt32(row.RowIndex);
                string EMPLOYEE_ID = (dgdepartment.Rows[i].FindControl("lblEMPLOYEE_ID") as Label).Text;

                Label lbldeleteid = (Label)row.FindControl("EMPLOYEE_ID");
                EMPLOYEE objEMPLOYEE = new EMPLOYEE();
                objEMPLOYEE.EMPLOYEE_ID = Convert.ToInt32(EMPLOYEE_ID);

                int j = SaveItem.deleteEmployee(objEMPLOYEE);

                if (j > 0)
                {
                    gridload();
                    clearfield();
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                }

                else
                {


                }



            }
            catch (Exception ex) { }


        }
        public void clearfield()

        {
            txtEmployeeID.Text = "";
            txtNAME.Text = "";
            txtSalary.Text = "";


        }
        public void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
              
                SqlConnection con = ConnectionClass.GetConnection();
                using (SqlCommand cmd = new SqlCommand("RSP_EMPLOYEE_INFO"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@DEPARTMENT_ID", SqlDbType.Int));
                        cmd.Parameters["@DEPARTMENT_ID"].Value = dopDepartment.SelectedValue;


                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            Session["PrintData"] = dt;
                        }

                     
                    }

                }

                SqlConnection con1 = ConnectionClass.GetConnection();
                using (SqlCommand cmd = new SqlCommand("FSP_DEPARTMENT_GA"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            Session["PrintDepartment"] = dt;
                        }

                    

                    }

                }


                Response.Redirect("RDLCViewer.aspx");

            }
            catch (Exception Ex) { }


        }
        public void btnIndividual_Click(object sender, EventArgs e)
        {
            try
            {

                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int i = Convert.ToInt32(row.RowIndex);
                string EMPLOYEE_ID = (dgdepartment.Rows[i].FindControl("lblEMPLOYEE_ID") as Label).Text;


                SqlConnection con = ConnectionClass.GetConnection();
                using (SqlCommand cmd = new SqlCommand("RSP_SINGLE_EMPLOYEE_INFO"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", SqlDbType.Int));
                        cmd.Parameters["@EMPLOYEE_ID"].Value = EMPLOYEE_ID;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            Session["PrintData"] = dt;
                        }

                        Response.Redirect("RDLCViewer.aspx");

                    }

                }
            }



            catch { }
        
        
        }









    }
}