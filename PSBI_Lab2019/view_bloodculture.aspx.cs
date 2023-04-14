using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_bloodculture : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cmdSearch.OnClientClick = "return ValidateForm();";

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
        }
    }

    protected void lnk_logout_Click(object sender, EventArgs e)
    {
        Session.Remove("UserID");
        Session.Abandon();
        Response.Redirect("login.aspx");
    }
}