using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TEST_MODEL;

namespace TASK_PROJECT
{
    public partial class RDLCViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindReport();
            }
        }
        protected void BindReport()
        {
            try
            {
                if (Session["PrintData"] != null)
                {
                    DataTable dt = (DataTable)Session["PrintData"];
                    DataTable dt1 = (DataTable)Session["PrintDepartment"];


                    EmployeeListView.LocalReport.EnableExternalImages = true;
                    EmployeeListView.LocalReport.ReportPath = Server.MapPath("~/ReportFile/employeeinfo.rdlc");
                    EmployeeListView.LocalReport.DataSources.Clear();
                    ReportDataSource source = new ReportDataSource("EmployeeDataSet1", dt);
                    ReportDataSource source2 = new ReportDataSource("DepartmetAllDataSet1", dt1);

                    EmployeeListView.LocalReport.DataSources.Add(source);
                    EmployeeListView.LocalReport.DataSources.Add(source2);
                    EmployeeListView.LocalReport.SetParameters(new ReportParameter("COMPANY_NAME", "Pinovation Tech Ltd."));
                    EmployeeListView.LocalReport.SetParameters(new ReportParameter("ADDRESS", "14/A, Tejkunipara Rd, Dhaka 1215"));
                    EmployeeListView.LocalReport.SetParameters(new ReportParameter("PHONE", "+8809611677682"));
                    EmployeeListView.DataBind();
                    EmployeeListView.LocalReport.Refresh();
                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType, encoding, extension;
                    byte[] bytes = EmployeeListView.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = mimeType;
                    Response.AddHeader("content-disposition", $"attachment; filename=RptProductList_{DateTime.Now.ToString("yyyyMMddHHmmss")}.pdf");
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
                    Session.Clear();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Notifications", "Toast('Error', '" + ex.Message + "', 'error');", true);
            }
        }


    }
}