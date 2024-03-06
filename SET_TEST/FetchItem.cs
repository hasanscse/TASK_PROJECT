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
  public class FetchItem
    {
      
        public static EMPLOYEE EmployeeGK(EMPLOYEE objOldEMPLOYEE)
        {
            EMPLOYEE objEMPLOYEE = new EMPLOYEE();
            SqlConnection conn = ConnectionClass.GetConnection();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "FSP_EMPLOYEE_GK";
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", SqlDbType.Decimal));
            objSqlCommand.Parameters["@EMPLOYEE_ID"].Value = objOldEMPLOYEE.EMPLOYEE_ID;

            objSqlCommand.Connection = conn;
            conn.Open();
            try
            {
                SqlDataReader dr = objSqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    objEMPLOYEE.NAME = dr["NAME"].ToString();
                    objEMPLOYEE.SALARY = Convert.ToDecimal(dr["SALARY"]);
                    objEMPLOYEE.DEPARTMENT_ID = Convert.ToInt32(dr["DEPARTMENT_ID"]);
                    objEMPLOYEE.EMPLOYEE_ID = Convert.ToInt32(dr["EMPLOYEE_ID"]);
                }


            }
            catch { }



            return objEMPLOYEE;
        }



        public static EMPLOYEE_TABLE EmployeeID()
        {
            EMPLOYEE_TABLE objEMPLOYEE_TABLE = new EMPLOYEE_TABLE();
            SqlConnection conn = ConnectionClass.GetConnection();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "FSP_EMPLOYEE_ID_CHECK";
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Connection = conn;
            conn.Open();
            try
            {
                SqlDataReader dr = objSqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    objEMPLOYEE_TABLE.ID = dr["ID"].ToString();
                }


            }
            catch(Exception ex) { }



            return objEMPLOYEE_TABLE;
        }





    }
}
