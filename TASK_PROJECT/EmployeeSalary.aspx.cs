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
        private void Createtable1()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EMPLOYEE_SALARY_ID", typeof(string));
            dt.Columns.Add("NAME", typeof(string));
            dt.Columns.Add("MONTH", typeof(string));
            dt.Columns.Add("YEAR", typeof(string));
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("BASIC_SALARY", typeof(decimal));
            dt.Columns.Add("HOME_RENT", typeof(decimal));
            dt.Columns.Add("OTHER_RENT", typeof(decimal));
            Session["tbltemp"] = dt;
        }

        private void Createtable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EMPLOYEE_SALARY_ID", typeof(string));
            dt.Columns.Add("NAME", typeof(string));
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
                decimal salary = Convert.ToDecimal(txtSalary.Text);
                decimal homeRent = Convert.ToDecimal(txtOtherRent.Text);
                decimal other = Convert.ToDecimal(txtOtherRent.Text);
                if (homeRent + other > salary)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Sum of Home Rent and Other Rent Can not be Greater-than Basic Salary!!')", true);
                    return;

                }

                DataTable dt = (DataTable)Session["tbltemp"];


                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["NAME"].ToString() == txtName.Text && dr["MONTH"].ToString() == cmbMonth.Text && dr["YEAR"].ToString() == cmbYear.Text)
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('you can not add same type of Row! this row already exist!!')", true);
                        return;

                    }

                }

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
                dr1["NAME"] = txtName.Text;
                dr1["MONTH"] = cmbMonth.Text;
                dr1["YEAR"] = cmbYear.Text;
                dr1["ID"] = cmbEmployee.SelectedValue;
                dr1["BASIC_SALARY"] = txtSalary.Text;
                dr1["HOME_RENT"] = txtHomeRent.Text;
                dr1["OTHER_RENT"] = txtOtherRent.Text;
                dt.Rows.Add(dr1);

                Session["tbltemp"] = dt;
                Session["tbltemp2"] = dt;

                dgSalary.DataSource = dt;
                dgSalary.DataBind();
                clearfield();

            }
            catch (Exception ex) { }
        }
        public void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {



                EMPLOYEE_SALARY objEMPLOYEE_SALARY = new EMPLOYEE_SALARY();

                var objListEMPLOYEE_TABLE = (List<EMPLOYEE_SALARY>)Session["tbltemp"];
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
        public void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = ConnectionClass.GetConnection();
                SqlCommand objSqlCommand = new SqlCommand();
                objSqlCommand.CommandText = "SELECT NAME, SALARY FROM EMPLOYEE Where EMPLOYEE_ID='" + cmbEmployee.SelectedValue + "'";
                objSqlCommand.Connection = conn;
                conn.Open();

                SqlDataReader dr = objSqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    txtSalary.Text = dr["SALARY"].ToString();
                    txtName.Text = dr["NAME"].ToString();
                }

                conn.Close();

            }
            catch (Exception ex) { }

        }
        public void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)Session["tbltemp"];
                DataView view = dt.DefaultView;
                view.Sort = "EMPLOYEE_SALARY_ID ASC";
                DataTable sortedDate = view.ToTable();

                foreach (DataRow row in dt.Rows)
                {

                    SqlConnection conn = ConnectionClass.GetConnection();
                    SqlCommand objSqlCommand = new SqlCommand();
                    objSqlCommand.CommandText = "FSP_EMPLOYEE_SALARY_I";
                    objSqlCommand.CommandType = CommandType.StoredProcedure;
                    objSqlCommand.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.VarChar, 100));
                    objSqlCommand.Parameters["@MONTH"].Value = row["MONTH"].ToString();
                    objSqlCommand.Parameters.Add(new SqlParameter("@YEAR", SqlDbType.VarChar, 100));
                    objSqlCommand.Parameters["@YEAR"].Value = row["YEAR"].ToString();
                    objSqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                    objSqlCommand.Parameters["@ID"].Value = row["ID"].ToString();
                    objSqlCommand.Parameters.Add(new SqlParameter("@BASIC_SALARY", SqlDbType.Decimal));
                    objSqlCommand.Parameters["@BASIC_SALARY"].Value = Convert.ToDecimal(row["BASIC_SALARY"]);
                    objSqlCommand.Parameters.Add(new SqlParameter("@HOME_RENT", SqlDbType.Decimal));
                    objSqlCommand.Parameters["@HOME_RENT"].Value = row["HOME_RENT"].ToString();
                    objSqlCommand.Parameters.Add(new SqlParameter("@OTHER_RENT", SqlDbType.Decimal));
                    objSqlCommand.Parameters["@OTHER_RENT"].Value = row["HOME_RENT"].ToString();
                    objSqlCommand.Connection = conn;
                    conn.Open();
                    objSqlCommand.ExecuteNonQuery();
                    conn.Close();
                }


                Session["tbltemp"] = null;
                dt = null;
                this.Createtable();
                dgSalary.DataSource = dt;
                dgSalary.DataBind();
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Save Successfully!')", true);
                clearfield();


            }
            catch { }


        }
        public void clearfield()
        {
            txtHomeRent.Text = "";
            txtOtherRent.Text = "";
           // txtSalary.Text = "";
            txtEMPLOYEEID.Text = "";

        }
        public void btndelete_Click(object sender, EventArgs e)
        {
            try
            {


                DataTable dt = (DataTable)Session["tbltemp"];

                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int i = Convert.ToInt32(row.RowIndex);
                string EMPLOYEE_SALARY_ID = (dgSalary.Rows[i].FindControl("lblEMPLOYEE_SALARY_ID") as Label).Text;

                for (int j = dt.Rows.Count - 1; j >= 0; j--)
                {
                    DataRow dr = dt.Rows[j];
                    string k = dr["EMPLOYEE_SALARY_ID"].ToString();

                    if (k == EMPLOYEE_SALARY_ID)
                        dr.Delete();
                }
                dt.AcceptChanges();



                Session["tbltemp"] = dt;
                dgSalary.DataSource = Session["tbltemp"];
                dgSalary.DataBind();



            }
            catch { }




        }

        public void btnSalarydesc_Click(object sender, EventArgs e)
        {
            try
            {


                DataTable dt = (DataTable)Session["tbltemp"];
                DataView view = dt.DefaultView;
                view.Sort = "BASIC_SALARY DESC";
                DataTable sorteddt = view.ToTable();


                dgSalary.DataSource = null;
                dgSalary.DataSource = dt;
                dgSalary.DataBind();


            }
            catch (Exception ex) { }



        }

        public void btnHomeRentdesc_Click(object sender, EventArgs e)
        {
            try
            {


                DataTable dt = (DataTable)Session["tbltemp"];
                DataView view = dt.DefaultView;
                view.Sort = "HOME_RENT DESC";
                DataTable sorteddt = view.ToTable();


                dgSalary.DataSource = null;
                dgSalary.DataSource = dt;
                dgSalary.DataBind();


            }
            catch (Exception ex) { }



        }
        public void btnOther_Click(object sender, EventArgs e)
        {
            try
            {


                DataTable dt = (DataTable)Session["tbltemp"];
                DataView view = dt.DefaultView;
                view.Sort = "OTHER_RENT DESC";
                DataTable sorteddt = view.ToTable();


                dgSalary.DataSource = null;
                dgSalary.DataSource = dt;
                dgSalary.DataBind();


            }
            catch (Exception ex) { }



        }


        protected void btnReverse_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = (DataTable)Session["tbltemp"];
                DataView view = dt.DefaultView;
                view.Sort = "EMPLOYEE_SALARY_ID ASC";
                DataTable sorteddt = view.ToTable();            
              
                dgSalary.DataSource = null;
                dgSalary.DataSource = dt;
                dgSalary.DataBind();


            }
            catch { }



        }

    }
}