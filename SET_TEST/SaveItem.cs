using IA.ConnectionProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST_MODEL;

namespace SET_TEST
{
    public class SaveItem
    {
        public static int saveEmployee(EMPLOYEE objEMPLOYEE)
        {

            int i = 0;
            SqlConnection conn = ConnectionClass.GetConnection();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "FSP_EMPLOYEE_I";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.Add(new SqlParameter("@NAME", SqlDbType.VarChar, 100));
            objSqlCommand.Parameters["@NAME"].Value = objEMPLOYEE.NAME;
            objSqlCommand.Parameters.Add(new SqlParameter("@SALARY", SqlDbType.Decimal));
            objSqlCommand.Parameters["@SALARY"].Value = objEMPLOYEE.SALARY;
            objSqlCommand.Parameters.Add(new SqlParameter("@DEPARTMENT_ID", SqlDbType.Decimal));
            objSqlCommand.Parameters["@DEPARTMENT_ID"].Value = objEMPLOYEE.DEPARTMENT_ID;


            objSqlCommand.Connection = conn;
            conn.Open();
            try
            {

                i = objSqlCommand.ExecuteNonQuery();
            }
            catch { }

            finally {
                conn.Close();
                    }

            return i;


        }

        public static int deleteEmployee(EMPLOYEE objEMPLOYEE)
        {
            int i = 0;
            SqlConnection conn = ConnectionClass.GetConnection();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "FSP_EMPLOYEE_D";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", SqlDbType.Int));
            objSqlCommand.Parameters["@EMPLOYEE_ID"].Value = objEMPLOYEE.EMPLOYEE_ID;
            objSqlCommand.Connection = conn;
            conn.Open();

            try
            {

                i = objSqlCommand.ExecuteNonQuery();


            }

            catch { }
            finally
            {

                conn.Close();
            }
            return i;
        }


        public static int UpdateEmployee(EMPLOYEE objEMPLOYEE)
        {
            int i = 0;
            SqlConnection conn = ConnectionClass.GetConnection();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "FSP_EMPLOYEE_U";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", SqlDbType.Int));
            objSqlCommand.Parameters["@EMPLOYEE_ID"].Value = objEMPLOYEE.EMPLOYEE_ID;

            objSqlCommand.Parameters.Add(new SqlParameter("@NAME", SqlDbType.VarChar, 200));

            objSqlCommand.Parameters["@NAME"].Value = objEMPLOYEE.NAME;
            objSqlCommand.Parameters.Add(new SqlParameter("@SALARY", SqlDbType.Decimal));
            objSqlCommand.Parameters["@SALARY"].Value = objEMPLOYEE.SALARY;

            objSqlCommand.Parameters.Add(new SqlParameter("@DEPARTMENT_ID", SqlDbType.Int));
            objSqlCommand.Parameters["@DEPARTMENT_ID"].Value = objEMPLOYEE.DEPARTMENT_ID;

            objSqlCommand.Connection = conn;
            conn.Open();
            try
            {
                i = objSqlCommand.ExecuteNonQuery();
            }
            catch
            {
            }

            finally
            {
                conn.Close();

            }
            return i;

        }

    }
}
