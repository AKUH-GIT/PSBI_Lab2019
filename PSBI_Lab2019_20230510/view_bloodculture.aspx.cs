using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.IO;
using Control = System.Web.UI.Control;

public partial class view_bloodculture : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            IsTestingServer();

            LinkButton lnkUser = (LinkButton)FindControl("usernme");
            lnkUser.Text = "Welcome: " + HttpContext.Current.Request["mycookie"].ToString();
            lnkUser.CssClass = "dropdown-toggle nav-link";
            lnkUser = null;
        }
    }


    private void IsTestingServer()
    {
        if (Server.MachineName.ToString() != "pedres2")
        {
            //lbl_testing.InnerText = Server.MachineName;
            lbl_testing.Visible = true;
            Div19.InnerText = "Testing Entries";
            Div19.Style.Add(HtmlTextWriterStyle.Color, "#FF0000");
            Div19.Style.Add(HtmlTextWriterStyle.FontSize, "15pt");
            Div19.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
        }
        else
        {
            lbl_testing.Visible = false;
            lbl_testing.InnerText = "";
        }
    }


    protected void lnk_logout_Click(object sender, EventArgs e)
    {
        Session.Remove("UserID");
        Session.Abandon();
        Response.Redirect("login.aspx");
    }

    protected void cmdSearch_Click(object sender, EventArgs e)
    {
        FillGrid_BloodCulture();
    }


    private bool FillGrid_BloodCulture()
    {
        CConnection cn = null;

        try
        {
            cn = new CConnection();

            string qry;
            string val_startdt = "";
            string val_enddt = "";


            if (!string.IsNullOrEmpty(txtStartDate.Text) && !string.IsNullOrEmpty(txtEndDate.Text))
            {
                DateTime dt_StartDate = new DateTime();
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_StartDate = Convert.ToDateTime(txtStartDate.Text);

                string[] arr_startdt = dt_StartDate.ToShortDateString().Split('/');
                val_startdt = arr_startdt[2] + "/" + arr_startdt[1] + "/" + arr_startdt[0];


                DateTime dt_EndDate = new DateTime();
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_EndDate = Convert.ToDateTime(txtEndDate.Text);

                string[] arr_enddt = dt_EndDate.ToShortDateString().Split('/');
                val_enddt = arr_enddt[2] + "/" + arr_enddt[1] + "/" + arr_enddt[0];


                if (Convert.ToDateTime(dt_StartDate.ToShortDateString()) > Convert.ToDateTime(dt_EndDate.ToShortDateString()))
                {
                    lblerr.Text = "Start date cannot be greater than end date";
                    return false;

                }
                else
                {
                    lblerr.Text = "";
                }

            }



            if (!string.IsNullOrEmpty(txtStartDate.Text) && !string.IsNullOrEmpty(txtEndDate.Text) && chkBloodCulture.Checked == true)
            {
                qry = "select b.ID, b.id id1, a.AS1_screening_ID, a.AS1_rand_id, a.AS1_name, a.AS1_age, a.AS1_mrno, a.AS1_lno, convert(varchar(13), AS2_Q9, 103) AS2_Q9 from form1 a inner join sample_result b on a.AS1_screening_ID = b.la_sno "
                + " where a.AS2_Q9 between '" + val_startdt + "' and '" + val_enddt + "' and a.labid = 1 and b.labid = 1 and b.rdo_BloodCulture = 1 ";
            }
            else if (!string.IsNullOrEmpty(txtStartDate.Text) && !string.IsNullOrEmpty(txtEndDate.Text) && chkBloodCulture.Checked == false)
            {
                qry = "select b.ID, b.id id1, a.AS1_screening_ID, a.AS1_rand_id, a.AS1_name, a.AS1_age, a.AS1_mrno, a.AS1_lno, convert(varchar(13), AS2_Q9, 103) AS2_Q9 from form1 a inner join sample_result b on a.AS1_screening_ID = b.la_sno "
                    + " where a.AS2_Q9 between '" + val_startdt + "' and '" + val_enddt + "' and a.labid = 1 and b.labid = 1 and b.rdo_BloodCulture = 2 ";
            }
            else if (string.IsNullOrEmpty(txtStartDate.Text) && string.IsNullOrEmpty(txtEndDate.Text) && chkBloodCulture.Checked == true)
            {
                qry = "select b.ID, b.id id1, a.AS1_screening_ID, a.AS1_rand_id, a.AS1_name, a.AS1_age, a.AS1_mrno, a.AS1_lno, convert(varchar(13), AS2_Q9, 103) AS2_Q9 from form1 a inner join sample_result b on a.AS1_screening_ID = b.la_sno "
                + " where a.labid = 1 and b.labid = 1 and b.rdo_BloodCulture = 1 ";
            }
            else
            {
                qry = "select b.ID, b.id id1, a.AS1_screening_ID, a.AS1_rand_id, a.AS1_name, a.AS1_age, a.AS1_mrno, a.AS1_lno, convert(varchar(13), AS2_Q9, 103) AS2_Q9 from form1 a inner join sample_result b on a.AS1_screening_ID = b.la_sno where a.labid = 1 and b.labid = 1 ";
            }


            SqlDataAdapter da = new SqlDataAdapter(qry, cn.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dg_BloodCulture.DataSource = ds.Tables[0];
            dg_BloodCulture.DataBind();
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Exception Error", "alert('" + ex.Message.Replace("'", "") + "')", false);
        }

        finally
        {
            cn = null;
        }

        return true;
    }

    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("view_bloodculture.aspx");
    }

    protected void dg_BloodCulture_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dg_BloodCulture.PageIndex = e.NewPageIndex;
        FillGrid_BloodCulture();
    }

    protected void cmdExportExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "BloodCulture_" + DateTime.Now.ToShortDateString() + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        dg_BloodCulture.GridLines = GridLines.Both;
        dg_BloodCulture.HeaderStyle.Font.Bold = true;
        dg_BloodCulture.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();
    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
}