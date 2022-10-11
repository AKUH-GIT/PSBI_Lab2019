using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Data.SqlClient;

public partial class rpt_sample : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                LinkButton lnkUser = (LinkButton)FindControl("usernme");
                lnkUser.Text = "Welcome: " + HttpContext.Current.Request["mycookie"].ToString();
                lnkUser.CssClass = "dropdown-toggle nav-link";
                lnkUser = null;


                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("rpt_Sample.rdlc");                
                DataSet ds = GetData();
                ReportDataSource datasource = new ReportDataSource("ds", ds.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                
            }
        }
    }


    private DataSet GetData()
    {
        DataSet ds = null;

        try
        {
            CConnection cn = new CConnection();
            SqlDataAdapter da = new SqlDataAdapter("select * from sample_result a inner join form1 b on a.la_sno = b.AS1_screening_ID where a.la_sno = '16-1-2222'", cn.cn);
            ds = new DataSet();
            da.Fill(ds);
        }

        catch (Exception ex)
        {

        }

        finally
        {

        }

        return ds;
    }


    protected void lnk_logout_Click(object sender, EventArgs e)
    {
        Session.Remove("UserID");
        Session.Abandon();
        Response.Redirect("login.aspx");
    }
}