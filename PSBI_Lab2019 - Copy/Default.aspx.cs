using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Microsoft.Reporting.WebForms;

//using CrystalDecisions.Shared;
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Web;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                LinkButton lnkUser = (LinkButton)FindControl("usernme");
                lnkUser.Text = "Welcome: " + HttpContext.Current.Request["mycookie"].ToString();
                lnkUser.CssClass = "dropdown-toggle nav-link";
                lnkUser = null;                
            }
        }
    }

    protected void lnk_logout_Click(object sender, EventArgs e)
    {
        Session.Remove("UserID");
        Session.Abandon();
        Response.Redirect("login.aspx");
    }
}