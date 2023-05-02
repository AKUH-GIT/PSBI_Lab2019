using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class search_sample : System.Web.UI.Page
{
    private int m_currentPageIndex;
    private IList<Stream> m_streams;


    protected void Page_Load(object sender, EventArgs e)
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

            if (!IsPostBack)
            {
                IsTestingServer();


                if (Request.Cookies["role"].Value == "admin")
                {
                    fillDropDown_allsites();
                }
                else
                {
                    fillDropDown_sitewise();
                }


                ReportViewer1.Visible = false;
            }
        }
    }


    private void IsTestingServer()
    {
        if (Server.MachineName.ToString() != "pedres2")
        {
            //lbl_testing.InnerText = Server.MachineName;
            lbl_testing.Visible = true;
            Div1.InnerText = "Testing Entries";
            Div1.Style.Add(HtmlTextWriterStyle.Color, "#FF0000");
            Div1.Style.Add(HtmlTextWriterStyle.FontSize, "15pt");
            Div1.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
        }
        else
        {
            lbl_testing.Visible = false;
            lbl_testing.InnerText = "";
        }
    }


    private void fillDropDown_sitewise()
    {
        CConnection cn = null;

        try
        {
            cn = new CConnection();
            string qry;

            qry = "select distinct la_sno from sample_result where SUBSTRING(la_sno, 4, 1) = '" + Request.Cookies["role"].Value + "'";


            SqlDataAdapter da = new SqlDataAdapter(qry, cn.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            ddl_screeningid.DataTextField = ds.Tables[0].Columns["la_sno"].ToString();
            ddl_screeningid.DataValueField = ds.Tables[0].Columns["la_sno"].ToString();

            ddl_screeningid.DataSource = ds.Tables[0];
            ddl_screeningid.DataBind();

            ddl_screeningid.Items.Add(new ListItem("Select Screening ID", "0"));

            for (int a = 0; a <= ddl_screeningid.Items.Count - 1; a++)
            {
                if (ddl_screeningid.Items[a].Value == "0")
                {
                    ddl_screeningid.SelectedIndex = a;
                }
            }

        }

        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Exception Error", "alert('" + ex.Message.Replace("'", "") + "')", false);
        }

        finally
        {
            cn = null;
        }
    }



    private void fillDropDown_allsites()
    {
        CConnection cn = null;

        try
        {
            cn = new CConnection();
            string qry;

            qry = "select distinct la_sno from sample_result ";


            SqlDataAdapter da = new SqlDataAdapter(qry, cn.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            ddl_screeningid.DataTextField = ds.Tables[0].Columns["la_sno"].ToString();
            ddl_screeningid.DataValueField = ds.Tables[0].Columns["la_sno"].ToString();

            ddl_screeningid.DataSource = ds.Tables[0];
            ddl_screeningid.DataBind();

            ddl_screeningid.Items.Add(new ListItem("Select Screening ID", "0"));

            for (int a = 0; a <= ddl_screeningid.Items.Count - 1; a++)
            {
                if (ddl_screeningid.Items[a].Value == "0")
                {
                    ddl_screeningid.SelectedIndex = a;
                }
            }

        }

        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Exception Error", "alert('" + ex.Message.Replace("'", "") + "')", false);
        }

        finally
        {
            cn = null;
        }
    }


    protected void cmdSearch_Click(object sender, EventArgs e)
    {
        CConnection cn = null;

        dg.Visible = true;
        ReportViewer1.Visible = false;


        try
        {
            if (ddl_screeningid.Value == "0")
            {
                lblerr.Text = "Please select screening ID";
                ReportViewer1.Visible = false;
                dg.Visible = false;
            }
            else
            {
                cn = new CConnection();
                string qry;

                qry = "select b.ID, b.id id1, a.AS1_screening_ID, a.AS1_rand_id, a.AS1_name, a.AS1_age, a.AS1_mrno, a.AS1_lno from form1 a inner join sample_result b on a.AS1_screening_ID = b.la_sno and a.labid = 1 and b.labid = 1 ";
                qry = SearchingCriteria(qry);


                SqlDataAdapter da = new SqlDataAdapter(qry, cn.cn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                lblerr.Text = "";

                dg.DataSource = ds.Tables[0];
                dg.DataBind();

            }
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Exception Error", "alert('" + ex.Message.Replace("'", "") + "')", false);
        }

        finally
        {
            cn = null;
        }
    }

    private string SearchingCriteria(string qry)
    {
        string criteria = "";

        try
        {

            if (ddl_screeningid.Value != "")
            {
                if (criteria != null || criteria != "")
                {
                    qry += " and a.AS1_screening_ID = '" + ddl_screeningid.Value + "'";
                }
                else
                {
                    qry += " where a.AS1_screening_ID = '" + ddl_screeningid.Value + "'";
                }
            }


            //if (!string.IsNullOrEmpty(LA_03_a.Text))
            //{
            //    if (criteria != null || criteria != "")
            //    {
            //        qry += " and b.LA_03_a = '" + LA_03_a.Text + "'";
            //    }
            //    else
            //    {
            //        qry += " where b.LA_03_a = '" + LA_03_a.Text + "'";
            //    }
            //}


            //if (!string.IsNullOrEmpty(LA_04_a.Text))
            //{
            //    if (criteria != null || criteria != "")
            //    {
            //        qry += " and b.LA_04_a = '" + LA_04_a.Text + "'";
            //    }
            //    else
            //    {
            //        qry += " where b.LA_04_a = '" + LA_04_a.Text + "'";
            //    }
            //}



            //if (!string.IsNullOrEmpty(LA_05_a.Text))
            //{
            //    if (criteria != null || criteria != "")
            //    {
            //        qry += " and b.LA_05_a = '" + LA_05_a.Text + "'";
            //    }
            //    else
            //    {
            //        qry += " where b.LA_05_a = '" + LA_05_a.Text + "'";
            //    }
            //}



            //if (!string.IsNullOrEmpty(LA_06_a.Text))
            //{
            //    if (criteria != null || criteria != "")
            //    {
            //        qry += " and b.LA_06_a = '" + LA_06_a.Text + "'";
            //    }
            //    else
            //    {
            //        qry += " where b.LA_06_a = '" + LA_06_a.Text + "'";
            //    }
            //}



            //if (!string.IsNullOrEmpty(LA_07_a.Text))
            //{
            //    if (criteria != null || criteria != "")
            //    {
            //        qry += " and b.LA_07_a = '" + LA_07_a.Text + "'";
            //    }
            //    else
            //    {
            //        qry += " where b.LA_07_a = '" + LA_07_a.Text + "'";
            //    }
            //}



            //if (!string.IsNullOrEmpty(LA_08_a.Text))
            //{
            //    if (criteria != null || criteria != "")
            //    {
            //        qry += " and b.LA_08_a = '" + LA_08_a.Text + "'";
            //    }
            //    else
            //    {
            //        qry += " where b.LA_08_a = '" + LA_08_a.Text + "'";
            //    }
            //}



            //if (!string.IsNullOrEmpty(LA_09_a.Text))
            //{
            //    if (criteria != null || criteria != "")
            //    {
            //        qry += " and b.LA_09_a = '" + LA_09_a.Text + "'";
            //    }
            //    else
            //    {
            //        qry += " where b.LA_09_a = '" + LA_09_a.Text + "'";
            //    }
            //}



            //if (!string.IsNullOrEmpty(LA_10_a.Text))
            //{
            //    if (criteria != null || criteria != "")
            //    {
            //        qry += " and b.LA_10_a = '" + LA_10_a.Text + "'";
            //    }
            //    else
            //    {
            //        qry += " where b.LA_10_a = '" + LA_10_a.Text + "'";
            //    }
            //}



            //if (!string.IsNullOrEmpty(LA_11_a.Text))
            //{
            //    if (criteria != null || criteria != "")
            //    {
            //        qry += " and b.LA_11_a = '" + LA_11_a.Text + "'";
            //    }
            //    else
            //    {
            //        qry += " where b.LA_11_a = '" + LA_11_a.Text + "'";
            //    }
            //}



            //if (!string.IsNullOrEmpty(LA_12_a.Text))
            //{
            //    if (criteria != null || criteria != "")
            //    {
            //        qry += " and b.LA_12_a = '" + LA_12_a.Text + "'";
            //    }
            //    else
            //    {
            //        qry += " where b.LA_12_a = '" + LA_12_a.Text + "'";
            //    }
            //}




            //if (!string.IsNullOrEmpty(LA_13_a.Text))
            //{
            //    if (criteria != null || criteria != "")
            //    {
            //        qry += " and b.LA_13_a = '" + LA_13_a.Text + "'";
            //    }
            //    else
            //    {
            //        qry += " where b.LA_13_a = '" + LA_13_a.Text + "'";
            //    }
            //}



            //if (!string.IsNullOrEmpty(LA_14_a.Text))
            //{
            //    if (criteria != null || criteria != "")
            //    {
            //        qry += " and b.LA_14_a = '" + LA_14_a.Text + "'";
            //    }
            //    else
            //    {
            //        qry += " where b.LA_14_a = '" + LA_14_a.Text + "'";
            //    }
            //}



            //if (!string.IsNullOrEmpty(LA_15_a.Text))
            //{
            //    if (criteria != null || criteria != "")
            //    {
            //        qry += " and b.LA_15_a = '" + LA_15_a.Text + "'";
            //    }
            //    else
            //    {
            //        qry += " where b.LA_15_a = '" + LA_15_a.Text + "'";
            //    }
            //}



            //if (!string.IsNullOrEmpty(LA_16_a.Text))
            //{
            //    if (criteria != null || criteria != "")
            //    {
            //        qry += " and b.LA_16_a = '" + LA_16_a.Text + "'";
            //    }
            //    else
            //    {
            //        qry += " where b.LA_16_a = '" + LA_16_a.Text + "'";
            //    }
            //}



            //if (!string.IsNullOrEmpty(LA_17.Text))
            //{
            //    if (criteria != null || criteria != "")
            //    {
            //        qry += " and b.LA_17 = '" + LA_17.Text + "'";
            //    }
            //    else
            //    {
            //        qry += " where b.LA_17 = '" + LA_17.Text + "'";
            //    }
            //}




            //if (!string.IsNullOrEmpty(LA_18.Text))
            //{
            //    if (criteria != null || criteria != "")
            //    {
            //        qry += " and b.LA_18 = '" + LA_18.Text + "'";
            //    }
            //    else
            //    {
            //        qry += " where b.LA_18 = '" + LA_18.Text + "'";
            //    }
            //}



        }

        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Exception Error", "alert('" + ex.Message + "')", false);
        }

        return qry;
    }

    protected void lnk_logout_Click(object sender, EventArgs e)
    {
        Session.Remove("UserID");
        Session.Abandon();
        Response.Redirect("login.aspx");
    }

    protected void cmdClose_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("search_sample.aspx");
    }

    protected void dg_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Select")
            {
                Label lbl = (Label)dg.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].FindControl("Label76");
                string id = lbl.Text;
                Response.Redirect("sample_results.aspx?id=" + id);
            }
            else if (e.CommandName == "Edit")
            {
                Label lbl = (Label)dg.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].FindControl("Label76");
                getData(lbl.Text);
            }
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Permission Error", "alert('" + ex.Message.Replace("'", "") + "')", false);
        }

    }


    public void getData(string screeningid)
    {
        CConnection cn = null;

        try
        {
            cn = new CConnection();

            SqlDataAdapter da = new SqlDataAdapter("select " +
"b.AS1_screening_ID," +
"[AS1_rand_id]," +
"[AS1_name]," +
"case when[AS1_sex] = 1 then 'Male'" +
"when[AS1_sex] = 2 then 'Female'" +
"end[AS1_sex]," +
"[AS1_age]," +
"[AS1_barcode]," +
"case when[AS1_fsite] = 1 then 'AKU Kharadar Hospital'" +
"when[AS1_fsite] = 2 then 'Sindh Govt. Children Hospital'" +
"when[AS1_fsite] = 3 then 'Liyari General Hospital'" +
"when[AS1_fsite] = 4 then 'Indus Korangi Hospital'" +
"when[AS1_fsite] = 5 then 'NICH'" +
"when[AS1_fsite] = 6 then 'Sheikh Saeed Memorial Hospital'" +
"end[AS1_fsite]," +
"case when AS1_Q1_1 = 1 then 'RCT1'" +
"when AS1_Q1_1 = 2 then 'RCT2'" +
"end[AS1_Q1_1]," +
"a.la_sno," +
"a.LA_01," +
"a.LA_02," +
"a.LA_03_b," +
"a.LA_03_a," +
"a.LA_04_b," +
"a.LA_04_a," +
"a.LA_05_b," +
"a.LA_05_a," +
"a.LA_06_b," +
"a.LA_06_a," +
"a.LA_07_b," +
"a.LA_07_a," +
"a.LA_08_b," +
"a.LA_08_a," +
"a.LA_09_b," +
"a.LA_09_a," +
"a.LA_10_b," +
"a.LA_10_a," +
"a.LA_11_b," +
"a.LA_11_a," +
"a.LA_12_b," +
"a.LA_12_a," +
"a.LA_13_b," +
"a.LA_13_a," +
"a.LA_14_b," +
"a.LA_14_a," +
"a.LA_15_b," +
"a.LA_15_a," +
"a.LA_16_b," +
"a.LA_16_a," +
"a.LF_01," +
"a.LF_01_a," +
"a.LF_02," +
"a.LF_02_a," +
"a.LF_03," +
"a.LF_03_a," +
"a.LF_04," +
"a.LF_04_a," +
"a.LF_05," +
"a.LF_05_a," +
"a.LF_06," +
"a.LF_06_a," +
"a.LF_07," +
"a.LF_07_a," +
"a.RF_01," +
"a.RF_01_a," +
"a.RF_02," +
"a.RF_02_a," +
"a.RF_03," +
"a.RF_03_a," +
"a.RF_04," +
"a.RF_04_a," +
"a.SE_01," +
"a.SE_01_a," +
"a.SE_02," +
"a.SE_02_a," +
"a.SE_03," +
"a.SE_03_a," +
"a.SE_04," +
"a.SE_04_a," +
"a.CS_01," +
"a.CS_01_a," +
"a.CS_02," +
"a.CS_02_a," +
"a.CS_03," +
"a.CS_03_a," +
"a.CS_04," +
"a.CS_04_a," +
"a.CS_05," +
"a.CS_05_a," +
"a.CS_06," +
"a.CS_06_a," +
"a.CS_07," +
"a.CS_07_a," +
"a.CS_08," +
"a.CS_08_a," +
"a.CS_09," +
"a.CS_09_a," +
"a.CS_10," +
"a.CS_10_a," +
"a.UR_01," +
"a.UR_01_a," +
"a.UR_02," +
"a.UR_02_a," +
"a.UR_03," +
"a.UR_03_a," +
"a.UR_04," +
"a.UR_04_a," +
"a.UR_04a," +
"a.UR_04a_a," +
"a.UR_05," +
"a.UR_05_a," +
"a.UR_06," +
"a.UR_06_a," +
"a.UR_07," +
"a.UR_07_a," +
"a.UR_08," +
"a.UR_08_a," +
"a.UR_10," +
"a.UR_10_a," +
"a.UR_11," +
"a.UR_11_a," +
"a.UR_12," +
"a.UR_12_a," +
"a.UR_13," +
"a.UR_13_a," +
"a.UR_14," +
"a.UR_14_a," +
"a.UR_15," +
"a.UR_15_a," +
"a.UR_16," +
"a.UR_16_a," +
"a.UR_17," +
"a.UR_17_a," +
"a.UR_18," +
"a.UR_18_a," +
"a.UR_19," +
"a.UR_19_a," +
"a.UR_20," +
"a.UR_20_a," +
"a.UR_21," +
"a.UR_21_a," +
"a.uc_01a," +
"a.uc_01_ca," +
"a.uc_02a," +
"a.uc_02a_a," +
"a.uc_02b," +
"a.uc_03a," +
"a.uc_03a_a," +
"a.uc_03b," +
"a.uc_04a," +
"a.uc_04a_a," +
"a.uc_04b," +
"a.uc_05a," +
"a.uc_05a_a," +
"a.uc_05b," +
"a.uc_06a," +
"a.uc_06a_a," +
"a.uc_06b," +
"a.uc_07a," +
"a.uc_07a_a," +
"a.uc_07b," +
"a.uc_08a," +
"a.uc_08a_a," +
"a.uc_08b," +
"a.uc_09a," +
"a.uc_09a_a," +
"a.uc_09b," +
"a.uc_10a," +
"a.uc_10a_a," +
"a.uc_10b," +
"a.uc_11a," +
"a.uc_11a_a," +
"a.uc_11b," +
"a.uc_12a," +
"a.uc_12a_a," +
"a.uc_12b," +
"a.uc_13a," +
"a.uc_13a_a," +
"a.uc_13b," +
"a.uc_14a," +
"a.uc_14a_a," +
"a.uc_14b," +
"a.uc_15a," +
"a.uc_15a_a," +
"a.uc_15b," +
"a.uc_16a," +
"a.uc_16a_a," +
"a.uc_16b," +
"a.uc_17a," +
"a.uc_17a_a," +
"a.uc_17b," +
"a.uc_18a," +
"a.uc_18a_a," +
"a.uc_18b," +
"a.uc_19a," +
"a.uc_19a_a," +
"a.uc_19b," +
"a.uc_20a," +
"a.uc_20a_a," +
"a.uc_20b," +
"a.uc_21a," +
"a.uc_21a_a," +
"a.uc_21b," +
"a.uc_22a," +
"a.uc_22a_a," +
"a.uc_22b," +
"a.uc_23a," +
"a.uc_23a_a," +
"a.uc_23b," +
"a.uc_24a," +
"a.uc_24a_a," +
"a.uc_24b," +
"a.uc_25a," +
"a.uc_25a_a," +
"a.uc_25b," +
"a.uc_26a," +
"a.uc_26a_a," +
"a.uc_26b," +
"a.uc_27a," +
"a.uc_27a_a," +
"a.uc_27b," +
"a.uc_28a," +
"a.uc_28a_a," +
"a.uc_28b," +
"a.uc_29a," +
"a.uc_29a_a," +
"a.uc_29b," +
"a.uc_30a," +
"a.uc_30a_a," +
"a.uc_30b," +
"a.uc_31a," +
"a.uc_31a_a," +
"a.uc_31b," +
"a.uc_32a," +
"a.uc_32a_a," +
"a.uc_32b," +
"a.uc_33a," +
"a.uc_33a_a," +
"a.uc_33b," +
"a.uc_34a," +
"a.uc_34a_a," +
"a.uc_34b," +
"a.uc_35a," +
"a.uc_35a_a," +
"a.uc_35b," +
"a.uc_36a," +
"a.uc_36a_a," +
"a.uc_36b," +
"a.uc_37a," +
"a.uc_37a_a," +
"a.uc_37b," +
"a.LA_17," +
"a.LA_18," +
"a.LA_19," +
"a.LA_20a_b," +
"a.LA_20a_a," +
"a.LA_20b_a," +
"a.LA_21a_b," +
"a.LA_21a_a," +
"a.LA_21b_a," +
"a.LA_22a_b," +
"a.LA_22a_a," +
"a.LA_22b_a," +
"a.LA_23a_b," +
"a.LA_23a_a," +
"a.LA_23b_a," +
"a.LA_24a_b," +
"a.LA_24a_a," +
"a.LA_24b_a," +
"a.LA_25a_b," +
"a.LA_25a_a," +
"a.LA_25b_a," +
"a.LA_26a_b," +
"a.LA_26a_a," +
"a.LA_26b_a," +
"a.LA_27a_b," +
"a.LA_27a_a," +
"a.LA_27b_a," +
"a.LA_28a_b," +
"a.LA_28a_a," +
"a.LA_28b_a," +
"a.LA_29a_b," +
"a.LA_29a_a," +
"a.LA_29b_a," +
"a.LA_30a_b," +
"a.LA_30a_a," +
"a.LA_30b_a," +
"a.LA_31a_b," +
"a.LA_31a_a," +
"a.LA_31b_a," +
"a.LA_32a_b," +
"a.LA_32a_a," +
"a.LA_32b_a," +
"a.LA_33a_b," +
"a.LA_33a_a," +
"a.LA_33b_a," +
"a.LA_34a_b," +
"a.LA_34a_a," +
"a.LA_34b_a," +
"a.LA_35a_b," +
"a.LA_35a_a," +
"a.LA_35b_a," +
"a.LA_36a_b," +
"a.LA_36a_a," +
"a.LA_36b_a," +
"a.LA_37a_b," +
"a.LA_37a_a," +
"a.LA_37b_a," +
"a.LA_38a_b," +
"a.LA_38a_a," +
"a.LA_38b_a," +
"a.LA_39a_b," +
"a.LA_39a_a," +
"a.LA_39b_a," +
"a.LA_40a_b," +
"a.LA_40a_a," +
"a.LA_40b_a," +
"a.LA_41a_b," +
"a.LA_41a_a," +
"a.LA_41b_a," +
"a.LA_42a_b," +
"a.LA_42a_a," +
"a.LA_42b_a," +
"a.LA_43a_b," +
"a.LA_43a_a," +
"a.LA_43b_a," +
"a.LA_44a_b," +
"a.LA_44a_a," +
"a.LA_44b_a," +
"a.LA_45a_b," +
"a.LA_45a_a," +
"a.LA_45b_a," +
"a.LA_46a_b," +
"a.LA_46a_a," +
"a.LA_46b_a," +
"a.LA_47a_b," +
"a.LA_47a_a," +
"a.LA_47b_a," +
"a.LA_48a_b," +
"a.LA_48a_a," +
"a.LA_48b_a," +
"a.LA_49a_b," +
"a.LA_49a_a," +
"a.LA_49b_a," +
"a.LA_50a_b," +
"a.LA_50a_a," +
"a.LA_50b_a," +
"a.LA_51a_b," +
"a.LA_51a_a," +
"a.LA_51b_a," +
"a.LA_52a_b," +
"a.LA_52a_a," +
"a.LA_52b_a" +
            " from sample_result a inner join form1 b on a.la_sno = b.AS1_screening_ID where a.id = '" + screeningid + "'", cn.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);



            //dl_data.DataSource = ds.Tables[0];
            //dl_data.DataBind();


            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {



                        //LA_01.Text = ds.Tables[0].Rows[0]["LA_01"].ToString();

                        //LA_02.Text = ds.Tables[0].Rows[0]["LA_02"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_03_b"].ToString() == "0")
                        //{
                        //    LA_03_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_03_b"].ToString() == "999")
                        //{
                        //    LA_03_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_03_b"].ToString() == "888")
                        //{
                        //    LA_03_c.Checked = true;
                        //}


                        //LA_03_a.Text = ds.Tables[0].Rows[0]["LA_03_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_04_b"].ToString() == "0")
                        //{
                        //    LA_04_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_04_b"].ToString() == "999")
                        //{
                        //    LA_04_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_04_b"].ToString() == "888")
                        //{
                        //    LA_04_c.Checked = true;
                        //}


                        //LA_04_a.Text = ds.Tables[0].Rows[0]["LA_04_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_05_b"].ToString() == "0")
                        //{
                        //    LA_05_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_05_b"].ToString() == "999")
                        //{
                        //    LA_05_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_05_b"].ToString() == "888")
                        //{
                        //    LA_05_c.Checked = true;
                        //}


                        //LA_05_a.Text = ds.Tables[0].Rows[0]["LA_05_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_06_b"].ToString() == "0")
                        //{
                        //    LA_06_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_06_b"].ToString() == "999")
                        //{
                        //    LA_06_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_06_b"].ToString() == "888")
                        //{
                        //    LA_06_c.Checked = true;
                        //}


                        //LA_06_a.Text = ds.Tables[0].Rows[0]["LA_06_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_07_b"].ToString() == "0")
                        //{
                        //    LA_07_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_07_b"].ToString() == "999")
                        //{
                        //    LA_07_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_07_b"].ToString() == "888")
                        //{
                        //    LA_07_c.Checked = true;
                        //}


                        //LA_07_a.Text = ds.Tables[0].Rows[0]["LA_07_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_08_b"].ToString() == "0")
                        //{
                        //    LA_08_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_08_b"].ToString() == "999")
                        //{
                        //    LA_08_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_08_b"].ToString() == "888")
                        //{
                        //    LA_08_c.Checked = true;
                        //}


                        //LA_08_a.Text = ds.Tables[0].Rows[0]["LA_08_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_09_b"].ToString() == "0")
                        //{
                        //    LA_09_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_09_b"].ToString() == "999")
                        //{
                        //    LA_09_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_09_b"].ToString() == "888")
                        //{
                        //    LA_09_c.Checked = true;
                        //}


                        //LA_09_a.Text = ds.Tables[0].Rows[0]["LA_09_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_10_b"].ToString() == "0")
                        //{
                        //    LA_10_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_10_b"].ToString() == "999")
                        //{
                        //    LA_10_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_10_b"].ToString() == "888")
                        //{
                        //    LA_10_c.Checked = true;
                        //}


                        //LA_10_a.Text = ds.Tables[0].Rows[0]["LA_10_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_11_b"].ToString() == "0")
                        //{
                        //    LA_11_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_11_b"].ToString() == "999")
                        //{
                        //    LA_11_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_11_b"].ToString() == "888")
                        //{
                        //    LA_11_c.Checked = true;
                        //}


                        //LA_11_a.Text = ds.Tables[0].Rows[0]["LA_11_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_12_b"].ToString() == "0")
                        //{
                        //    LA_12_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_12_b"].ToString() == "999")
                        //{
                        //    LA_12_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_12_b"].ToString() == "888")
                        //{
                        //    LA_12_c.Checked = true;
                        //}


                        //LA_12_a.Text = ds.Tables[0].Rows[0]["LA_12_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_13_b"].ToString() == "0")
                        //{
                        //    LA_13_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_13_b"].ToString() == "999")
                        //{
                        //    LA_13_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_13_b"].ToString() == "888")
                        //{
                        //    LA_13_c.Checked = true;
                        //}


                        //LA_13_a.Text = ds.Tables[0].Rows[0]["LA_13_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_14_b"].ToString() == "0")
                        //{
                        //    LA_14_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_14_b"].ToString() == "999")
                        //{
                        //    LA_14_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_14_b"].ToString() == "888")
                        //{
                        //    LA_14_c.Checked = true;
                        //}


                        //LA_14_a.Text = ds.Tables[0].Rows[0]["LA_14_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_15_b"].ToString() == "0")
                        //{
                        //    LA_15_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_15_b"].ToString() == "999")
                        //{
                        //    LA_15_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_15_b"].ToString() == "888")
                        //{
                        //    LA_15_c.Checked = true;
                        //}


                        //LA_15_a.Text = ds.Tables[0].Rows[0]["LA_15_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_16_b"].ToString() == "0")
                        //{
                        //    LA_16_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_16_b"].ToString() == "999")
                        //{
                        //    LA_16_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_16_b"].ToString() == "888")
                        //{
                        //    LA_16_c.Checked = true;
                        //}


                        //LA_16_a.Text = ds.Tables[0].Rows[0]["LA_16_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LF_01"].ToString() == "0")
                        //{
                        //    LF_01_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LF_01"].ToString() == "999")
                        //{
                        //    LF_01_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LF_01"].ToString() == "888")
                        //{
                        //    LF_01_c.Checked = true;
                        //}


                        //LF_01_a.Text = ds.Tables[0].Rows[0]["LF_01_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LF_02"].ToString() == "0")
                        //{
                        //    LF_02_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LF_02"].ToString() == "999")
                        //{
                        //    LF_02_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LF_02"].ToString() == "888")
                        //{
                        //    LF_02_c.Checked = true;
                        //}


                        //LF_02_a.Text = ds.Tables[0].Rows[0]["LF_02_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LF_03"].ToString() == "0")
                        //{
                        //    LF_03_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LF_03"].ToString() == "999")
                        //{
                        //    LF_03_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LF_03"].ToString() == "888")
                        //{
                        //    LF_03_c.Checked = true;
                        //}


                        //LF_03_a.Text = ds.Tables[0].Rows[0]["LF_03_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LF_04"].ToString() == "0")
                        //{
                        //    LF_04_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LF_04"].ToString() == "999")
                        //{
                        //    LF_04_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LF_04"].ToString() == "888")
                        //{
                        //    LF_04_c.Checked = true;
                        //}


                        //LF_04_a.Text = ds.Tables[0].Rows[0]["LF_04_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LF_05"].ToString() == "0")
                        //{
                        //    LF_05_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LF_05"].ToString() == "999")
                        //{
                        //    LF_05_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LF_05"].ToString() == "888")
                        //{
                        //    LF_05_c.Checked = true;
                        //}


                        //LF_05_a.Text = ds.Tables[0].Rows[0]["LF_05_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LF_06"].ToString() == "0")
                        //{
                        //    LF_06_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LF_06"].ToString() == "999")
                        //{
                        //    LF_06_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LF_06"].ToString() == "888")
                        //{
                        //    LF_06_c.Checked = true;
                        //}


                        //LF_06_a.Text = ds.Tables[0].Rows[0]["LF_06_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LF_07"].ToString() == "0")
                        //{
                        //    LF_07_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LF_07"].ToString() == "999")
                        //{
                        //    LF_07_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LF_07"].ToString() == "888")
                        //{
                        //    LF_07_c.Checked = true;
                        //}


                        //LF_07_a.Text = ds.Tables[0].Rows[0]["LF_07_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["RF_01"].ToString() == "0")
                        //{
                        //    RF_01_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["RF_01"].ToString() == "999")
                        //{
                        //    RF_01_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["RF_01"].ToString() == "888")
                        //{
                        //    RF_01_c.Checked = true;
                        //}


                        //RF_01_a.Text = ds.Tables[0].Rows[0]["RF_01_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["RF_02"].ToString() == "0")
                        //{
                        //    RF_02_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["RF_02"].ToString() == "999")
                        //{
                        //    RF_02_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["RF_02"].ToString() == "888")
                        //{
                        //    RF_02_c.Checked = true;
                        //}


                        //RF_02_a.Text = ds.Tables[0].Rows[0]["RF_02_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["RF_03"].ToString() == "0")
                        //{
                        //    RF_03_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["RF_03"].ToString() == "999")
                        //{
                        //    RF_03_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["RF_03"].ToString() == "888")
                        //{
                        //    RF_03_c.Checked = true;
                        //}


                        //RF_03_a.Text = ds.Tables[0].Rows[0]["RF_03_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["RF_04"].ToString() == "0")
                        //{
                        //    RF_04_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["RF_04"].ToString() == "999")
                        //{
                        //    RF_04_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["RF_04"].ToString() == "888")
                        //{
                        //    RF_04_c.Checked = true;
                        //}


                        //RF_04_a.Text = ds.Tables[0].Rows[0]["RF_04_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["SE_01"].ToString() == "0")
                        //{
                        //    SE_01_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["SE_01"].ToString() == "999")
                        //{
                        //    SE_01_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["SE_01"].ToString() == "888")
                        //{
                        //    SE_01_c.Checked = true;
                        //}


                        //SE_01_a.Text = ds.Tables[0].Rows[0]["SE_01_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["SE_02"].ToString() == "0")
                        //{
                        //    SE_02_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["SE_02"].ToString() == "999")
                        //{
                        //    SE_02_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["SE_02"].ToString() == "888")
                        //{
                        //    SE_02_c.Checked = true;
                        //}


                        //SE_02_a.Text = ds.Tables[0].Rows[0]["SE_02_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["SE_03"].ToString() == "0")
                        //{
                        //    SE_03_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["SE_03"].ToString() == "999")
                        //{
                        //    SE_03_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["SE_03"].ToString() == "888")
                        //{
                        //    SE_03_c.Checked = true;
                        //}


                        //SE_03_a.Text = ds.Tables[0].Rows[0]["SE_03_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["SE_04"].ToString() == "0")
                        //{
                        //    SE_04_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["SE_04"].ToString() == "999")
                        //{
                        //    SE_04_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["SE_04"].ToString() == "888")
                        //{
                        //    SE_04_c.Checked = true;
                        //}


                        //SE_04_a.Text = ds.Tables[0].Rows[0]["SE_04_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["CS_01"].ToString() == "0")
                        //{
                        //    CS_01_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_01"].ToString() == "999")
                        //{
                        //    CS_01_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_01"].ToString() == "888")
                        //{
                        //    CS_01_c.Checked = true;
                        //}


                        //CS_01_a.Text = ds.Tables[0].Rows[0]["CS_01_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["CS_02"].ToString() == "0")
                        //{
                        //    CS_02_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_02"].ToString() == "999")
                        //{
                        //    CS_02_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_02"].ToString() == "888")
                        //{
                        //    CS_02_c.Checked = true;
                        //}


                        //CS_02_a.Text = ds.Tables[0].Rows[0]["CS_02_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["CS_03"].ToString() == "0")
                        //{
                        //    CS_03_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_03"].ToString() == "999")
                        //{
                        //    CS_03_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_03"].ToString() == "888")
                        //{
                        //    CS_03_c.Checked = true;
                        //}


                        //CS_03_a.Text = ds.Tables[0].Rows[0]["CS_03_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["CS_04"].ToString() == "0")
                        //{
                        //    CS_04_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_04"].ToString() == "999")
                        //{
                        //    CS_04_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_04"].ToString() == "888")
                        //{
                        //    CS_04_c.Checked = true;
                        //}


                        //CS_04_a.Text = ds.Tables[0].Rows[0]["CS_04_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["CS_05"].ToString() == "0")
                        //{
                        //    CS_05_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_05"].ToString() == "999")
                        //{
                        //    CS_05_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_05"].ToString() == "888")
                        //{
                        //    CS_05_c.Checked = true;
                        //}


                        //CS_05_a.Text = ds.Tables[0].Rows[0]["CS_05_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["CS_06"].ToString() == "0")
                        //{
                        //    CS_06_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_06"].ToString() == "999")
                        //{
                        //    CS_06_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_06"].ToString() == "888")
                        //{
                        //    CS_06_c.Checked = true;
                        //}


                        //CS_06_a.Text = ds.Tables[0].Rows[0]["CS_06_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["CS_07"].ToString() == "0")
                        //{
                        //    CS_07_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_07"].ToString() == "999")
                        //{
                        //    CS_07_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_07"].ToString() == "888")
                        //{
                        //    CS_07_c.Checked = true;
                        //}


                        //CS_07_a.Text = ds.Tables[0].Rows[0]["CS_07_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["CS_08"].ToString() == "0")
                        //{
                        //    CS_08_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_08"].ToString() == "999")
                        //{
                        //    CS_08_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_08"].ToString() == "888")
                        //{
                        //    CS_08_c.Checked = true;
                        //}


                        //CS_08_a.Text = ds.Tables[0].Rows[0]["CS_08_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["CS_09"].ToString() == "0")
                        //{
                        //    CS_09_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_09"].ToString() == "999")
                        //{
                        //    CS_09_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_09"].ToString() == "888")
                        //{
                        //    CS_09_c.Checked = true;
                        //}


                        //CS_09_a.Text = ds.Tables[0].Rows[0]["CS_09_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["CS_10"].ToString() == "0")
                        //{
                        //    CS_10_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_10"].ToString() == "999")
                        //{
                        //    CS_10_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["CS_10"].ToString() == "888")
                        //{
                        //    CS_10_c.Checked = true;
                        //}


                        //CS_10_a.Text = ds.Tables[0].Rows[0]["CS_10_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["UR_01"].ToString() == "0")
                        //{
                        //    UR_01_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_01"].ToString() == "999")
                        //{
                        //    UR_01_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_01"].ToString() == "888")
                        //{
                        //    UR_01_c.Checked = true;
                        //}


                        //UR_01_a.Text = ds.Tables[0].Rows[0]["UR_01_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["UR_02"].ToString() == "0")
                        //{
                        //    UR_02_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_02"].ToString() == "999")
                        //{
                        //    UR_02_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_02"].ToString() == "888")
                        //{
                        //    UR_02_c.Checked = true;
                        //}


                        //UR_02_a.Text = ds.Tables[0].Rows[0]["UR_02_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["UR_03"].ToString() == "0")
                        //{
                        //    UR_03_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_03"].ToString() == "999")
                        //{
                        //    UR_03_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_03"].ToString() == "888")
                        //{
                        //    UR_03_c.Checked = true;
                        //}


                        //UR_03_a.Text = ds.Tables[0].Rows[0]["UR_03_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["UR_04"].ToString() == "0")
                        //{
                        //    UR_04_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_04"].ToString() == "999")
                        //{
                        //    UR_04_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_04"].ToString() == "888")
                        //{
                        //    UR_04_c.Checked = true;
                        //}


                        //UR_04_a.Text = ds.Tables[0].Rows[0]["UR_04_a"].ToString();




                        //if (ds.Tables[0].Rows[0]["UR_04a"].ToString() == "0")
                        //{
                        //    UR_04a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_04a"].ToString() == "999")
                        //{
                        //    UR_04a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_04a"].ToString() == "888")
                        //{
                        //    UR_04a_c.Checked = true;
                        //}


                        //UR_04a_a.Text = ds.Tables[0].Rows[0]["UR_04a_a"].ToString();





                        //if (ds.Tables[0].Rows[0]["UR_05"].ToString() == "0")
                        //{
                        //    UR_05_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_05"].ToString() == "999")
                        //{
                        //    UR_05_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_05"].ToString() == "888")
                        //{
                        //    UR_05_c.Checked = true;
                        //}


                        //UR_05_a.Text = ds.Tables[0].Rows[0]["UR_05_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["UR_06"].ToString() == "0")
                        //{
                        //    UR_06_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_06"].ToString() == "999")
                        //{
                        //    UR_06_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_06"].ToString() == "888")
                        //{
                        //    UR_06_c.Checked = true;
                        //}


                        //UR_06_a.Text = ds.Tables[0].Rows[0]["UR_06_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["UR_07"].ToString() == "0")
                        //{
                        //    UR_07_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_07"].ToString() == "999")
                        //{
                        //    UR_07_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_07"].ToString() == "888")
                        //{
                        //    UR_07_c.Checked = true;
                        //}


                        //UR_07_a.Text = ds.Tables[0].Rows[0]["UR_07_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["UR_08"].ToString() == "0")
                        //{
                        //    UR_08_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_08"].ToString() == "999")
                        //{
                        //    UR_08_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_08"].ToString() == "888")
                        //{
                        //    UR_08_c.Checked = true;
                        //}


                        //UR_08_a.Text = ds.Tables[0].Rows[0]["UR_08_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["UR_10"].ToString() == "0")
                        //{
                        //    UR_10_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_10"].ToString() == "999")
                        //{
                        //    UR_10_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_10"].ToString() == "888")
                        //{
                        //    UR_10_c.Checked = true;
                        //}


                        //UR_10_a.Text = ds.Tables[0].Rows[0]["UR_10_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["UR_11"].ToString() == "0")
                        //{
                        //    UR_11_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_11"].ToString() == "999")
                        //{
                        //    UR_11_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_11"].ToString() == "888")
                        //{
                        //    UR_11_c.Checked = true;
                        //}


                        //UR_11_a.Text = ds.Tables[0].Rows[0]["UR_11_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["UR_12"].ToString() == "0")
                        //{
                        //    UR_12_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_12"].ToString() == "999")
                        //{
                        //    UR_12_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_12"].ToString() == "888")
                        //{
                        //    UR_12_c.Checked = true;
                        //}


                        //UR_12_a.Text = ds.Tables[0].Rows[0]["UR_12_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["UR_13"].ToString() == "0")
                        //{
                        //    UR_13_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_13"].ToString() == "999")
                        //{
                        //    UR_13_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_13"].ToString() == "888")
                        //{
                        //    UR_13_c.Checked = true;
                        //}


                        //UR_13_a.Text = ds.Tables[0].Rows[0]["UR_13_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["UR_14"].ToString() == "0")
                        //{
                        //    UR_14_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_14"].ToString() == "999")
                        //{
                        //    UR_14_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_14"].ToString() == "888")
                        //{
                        //    UR_14_c.Checked = true;
                        //}


                        //UR_14_a.Text = ds.Tables[0].Rows[0]["UR_14_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["UR_15"].ToString() == "0")
                        //{
                        //    UR_15_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_15"].ToString() == "999")
                        //{
                        //    UR_15_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_15"].ToString() == "888")
                        //{
                        //    UR_15_c.Checked = true;
                        //}


                        //UR_15_a.Text = ds.Tables[0].Rows[0]["UR_15_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["UR_16"].ToString() == "0")
                        //{
                        //    UR_16_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_16"].ToString() == "999")
                        //{
                        //    UR_16_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_16"].ToString() == "888")
                        //{
                        //    UR_16_c.Checked = true;
                        //}


                        //UR_16_a.Text = ds.Tables[0].Rows[0]["UR_16_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["UR_17"].ToString() == "0")
                        //{
                        //    UR_17_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_17"].ToString() == "999")
                        //{
                        //    UR_17_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_17"].ToString() == "888")
                        //{
                        //    UR_17_c.Checked = true;
                        //}


                        //UR_17_a.Text = ds.Tables[0].Rows[0]["UR_17_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["UR_18"].ToString() == "0")
                        //{
                        //    UR_18_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_18"].ToString() == "999")
                        //{
                        //    UR_18_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_18"].ToString() == "888")
                        //{
                        //    UR_18_c.Checked = true;
                        //}


                        //UR_18_a.Text = ds.Tables[0].Rows[0]["UR_18_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["UR_19"].ToString() == "0")
                        //{
                        //    UR_19_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_19"].ToString() == "999")
                        //{
                        //    UR_19_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_19"].ToString() == "888")
                        //{
                        //    UR_19_c.Checked = true;
                        //}


                        //UR_19_a.Text = ds.Tables[0].Rows[0]["UR_19_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["UR_20"].ToString() == "0")
                        //{
                        //    UR_20_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_20"].ToString() == "999")
                        //{
                        //    UR_20_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_20"].ToString() == "888")
                        //{
                        //    UR_20_c.Checked = true;
                        //}


                        //UR_20_a.Text = ds.Tables[0].Rows[0]["UR_20_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["UR_21"].ToString() == "0")
                        //{
                        //    UR_21_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_21"].ToString() == "999")
                        //{
                        //    UR_21_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["UR_21"].ToString() == "888")
                        //{
                        //    UR_21_c.Checked = true;
                        //}


                        //UR_21_a.Text = ds.Tables[0].Rows[0]["UR_21_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_01a"].ToString() == "1")
                        //{
                        //    uc_01_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_01a"].ToString() == "2")
                        //{
                        //    uc_01_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_01a"].ToString() == "999")
                        //{
                        //    uc_01_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_02a"].ToString() == "0")
                        //{
                        //    uc_02a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_02a"].ToString() == "999")
                        //{
                        //    uc_02a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_02a"].ToString() == "888")
                        //{
                        //    uc_02a_c.Checked = true;
                        //}


                        //uc_02a_a.Text = ds.Tables[0].Rows[0]["uc_02a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_02b"].ToString() == "1")
                        //{
                        //    uc_02b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_02b"].ToString() == "2")
                        //{
                        //    uc_02b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_02b"].ToString() == "3")
                        //{
                        //    uc_02b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_03a"].ToString() == "0")
                        //{
                        //    uc_03a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_03a"].ToString() == "999")
                        //{
                        //    uc_03a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_03a"].ToString() == "888")
                        //{
                        //    uc_03a_c.Checked = true;
                        //}


                        //uc_03a_a.Text = ds.Tables[0].Rows[0]["uc_03a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_03b"].ToString() == "1")
                        //{
                        //    uc_03b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_03b"].ToString() == "2")
                        //{
                        //    uc_03b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_03b"].ToString() == "3")
                        //{
                        //    uc_03b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_04a"].ToString() == "0")
                        //{
                        //    uc_04a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_04a"].ToString() == "999")
                        //{
                        //    uc_04a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_04a"].ToString() == "888")
                        //{
                        //    uc_04a_c.Checked = true;
                        //}


                        //uc_04a_a.Text = ds.Tables[0].Rows[0]["uc_04a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_04b"].ToString() == "1")
                        //{
                        //    uc_04b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_04b"].ToString() == "2")
                        //{
                        //    uc_04b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_04b"].ToString() == "3")
                        //{
                        //    uc_04b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_05a"].ToString() == "0")
                        //{
                        //    uc_05a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_05a"].ToString() == "999")
                        //{
                        //    uc_05a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_05a"].ToString() == "888")
                        //{
                        //    uc_05a_c.Checked = true;
                        //}


                        //uc_05a_a.Text = ds.Tables[0].Rows[0]["uc_05a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_05b"].ToString() == "1")
                        //{
                        //    uc_05b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_05b"].ToString() == "2")
                        //{
                        //    uc_05b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_05b"].ToString() == "3")
                        //{
                        //    uc_05b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_06a"].ToString() == "0")
                        //{
                        //    uc_06a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_06a"].ToString() == "999")
                        //{
                        //    uc_06a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_06a"].ToString() == "888")
                        //{
                        //    uc_06a_c.Checked = true;
                        //}


                        //uc_06a_a.Text = ds.Tables[0].Rows[0]["uc_06a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_06b"].ToString() == "1")
                        //{
                        //    uc_06b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_06b"].ToString() == "2")
                        //{
                        //    uc_06b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_06b"].ToString() == "3")
                        //{
                        //    uc_06b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_07a"].ToString() == "0")
                        //{
                        //    uc_07a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_07a"].ToString() == "999")
                        //{
                        //    uc_07a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_07a"].ToString() == "888")
                        //{
                        //    uc_07a_c.Checked = true;
                        //}


                        //uc_07a_a.Text = ds.Tables[0].Rows[0]["uc_07a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_07b"].ToString() == "1")
                        //{
                        //    uc_07b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_07b"].ToString() == "2")
                        //{
                        //    uc_07b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_07b"].ToString() == "3")
                        //{
                        //    uc_07b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_08a"].ToString() == "0")
                        //{
                        //    uc_08a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_08a"].ToString() == "999")
                        //{
                        //    uc_08a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_08a"].ToString() == "888")
                        //{
                        //    uc_08a_c.Checked = true;
                        //}


                        //uc_08a_a.Text = ds.Tables[0].Rows[0]["uc_08a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_08b"].ToString() == "1")
                        //{
                        //    uc_08b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_08b"].ToString() == "2")
                        //{
                        //    uc_08b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_08b"].ToString() == "3")
                        //{
                        //    uc_08b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_09a"].ToString() == "0")
                        //{
                        //    uc_09a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_09a"].ToString() == "999")
                        //{
                        //    uc_09a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_09a"].ToString() == "888")
                        //{
                        //    uc_09a_c.Checked = true;
                        //}


                        //uc_09a_a.Text = ds.Tables[0].Rows[0]["uc_09a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_09b"].ToString() == "1")
                        //{
                        //    uc_09b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_09b"].ToString() == "2")
                        //{
                        //    uc_09b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_09b"].ToString() == "3")
                        //{
                        //    uc_09b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_10a"].ToString() == "0")
                        //{
                        //    uc_10a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_10a"].ToString() == "999")
                        //{
                        //    uc_10a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_10a"].ToString() == "888")
                        //{
                        //    uc_10a_c.Checked = true;
                        //}


                        //uc_10a_a.Text = ds.Tables[0].Rows[0]["uc_10a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_10b"].ToString() == "1")
                        //{
                        //    uc_10b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_10b"].ToString() == "2")
                        //{
                        //    uc_10b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_10b"].ToString() == "3")
                        //{
                        //    uc_10b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_11a"].ToString() == "0")
                        //{
                        //    uc_11a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_11a"].ToString() == "999")
                        //{
                        //    uc_11a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_11a"].ToString() == "888")
                        //{
                        //    uc_11a_c.Checked = true;
                        //}


                        //uc_11a_a.Text = ds.Tables[0].Rows[0]["uc_11a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_11b"].ToString() == "1")
                        //{
                        //    uc_11b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_11b"].ToString() == "2")
                        //{
                        //    uc_11b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_11b"].ToString() == "3")
                        //{
                        //    uc_11b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_12a"].ToString() == "0")
                        //{
                        //    uc_12a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_12a"].ToString() == "999")
                        //{
                        //    uc_12a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_12a"].ToString() == "888")
                        //{
                        //    uc_12a_c.Checked = true;
                        //}


                        //uc_12a_a.Text = ds.Tables[0].Rows[0]["uc_12a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_12b"].ToString() == "1")
                        //{
                        //    uc_12b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_12b"].ToString() == "2")
                        //{
                        //    uc_12b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_12b"].ToString() == "3")
                        //{
                        //    uc_12b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_13a"].ToString() == "0")
                        //{
                        //    uc_13a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_13a"].ToString() == "999")
                        //{
                        //    uc_13a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_13a"].ToString() == "888")
                        //{
                        //    uc_13a_c.Checked = true;
                        //}


                        //uc_13a_a.Text = ds.Tables[0].Rows[0]["uc_13a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_13b"].ToString() == "1")
                        //{
                        //    uc_13b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_13b"].ToString() == "2")
                        //{
                        //    uc_13b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_13b"].ToString() == "3")
                        //{
                        //    uc_13b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_14a"].ToString() == "0")
                        //{
                        //    uc_14a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_14a"].ToString() == "999")
                        //{
                        //    uc_14a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_14a"].ToString() == "888")
                        //{
                        //    uc_14a_c.Checked = true;
                        //}


                        //uc_14a_a.Text = ds.Tables[0].Rows[0]["uc_14a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_14b"].ToString() == "1")
                        //{
                        //    uc_14b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_14b"].ToString() == "2")
                        //{
                        //    uc_14b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_14b"].ToString() == "3")
                        //{
                        //    uc_14b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_15a"].ToString() == "0")
                        //{
                        //    uc_15a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_15a"].ToString() == "999")
                        //{
                        //    uc_15a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_15a"].ToString() == "888")
                        //{
                        //    uc_15a_c.Checked = true;
                        //}


                        //uc_15a_a.Text = ds.Tables[0].Rows[0]["uc_15a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_15b"].ToString() == "1")
                        //{
                        //    uc_15b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_15b"].ToString() == "2")
                        //{
                        //    uc_15b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_15b"].ToString() == "3")
                        //{
                        //    uc_15b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_16a"].ToString() == "0")
                        //{
                        //    uc_16a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_16a"].ToString() == "999")
                        //{
                        //    uc_16a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_16a"].ToString() == "888")
                        //{
                        //    uc_16a_c.Checked = true;
                        //}


                        //uc_16a_a.Text = ds.Tables[0].Rows[0]["uc_16a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_16b"].ToString() == "1")
                        //{
                        //    uc_16b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_16b"].ToString() == "2")
                        //{
                        //    uc_16b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_16b"].ToString() == "3")
                        //{
                        //    uc_16b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_17a"].ToString() == "0")
                        //{
                        //    uc_17a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_17a"].ToString() == "999")
                        //{
                        //    uc_17a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_17a"].ToString() == "888")
                        //{
                        //    uc_17a_c.Checked = true;
                        //}


                        //uc_17a_a.Text = ds.Tables[0].Rows[0]["uc_17a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_17b"].ToString() == "1")
                        //{
                        //    uc_17b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_17b"].ToString() == "2")
                        //{
                        //    uc_17b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_17b"].ToString() == "3")
                        //{
                        //    uc_17b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_18a"].ToString() == "0")
                        //{
                        //    uc_18a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_18a"].ToString() == "999")
                        //{
                        //    uc_18a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_18a"].ToString() == "888")
                        //{
                        //    uc_18a_c.Checked = true;
                        //}


                        //uc_18a_a.Text = ds.Tables[0].Rows[0]["uc_18a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_18b"].ToString() == "1")
                        //{
                        //    uc_18b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_18b"].ToString() == "2")
                        //{
                        //    uc_18b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_18b"].ToString() == "3")
                        //{
                        //    uc_18b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_19a"].ToString() == "0")
                        //{
                        //    uc_19a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_19a"].ToString() == "999")
                        //{
                        //    uc_19a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_19a"].ToString() == "888")
                        //{
                        //    uc_19a_c.Checked = true;
                        //}


                        //uc_19a_a.Text = ds.Tables[0].Rows[0]["uc_19a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_19b"].ToString() == "1")
                        //{
                        //    uc_19b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_19b"].ToString() == "2")
                        //{
                        //    uc_19b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_19b"].ToString() == "3")
                        //{
                        //    uc_19b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_20a"].ToString() == "0")
                        //{
                        //    uc_20a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_20a"].ToString() == "999")
                        //{
                        //    uc_20a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_20a"].ToString() == "888")
                        //{
                        //    uc_20a_c.Checked = true;
                        //}


                        //uc_20a_a.Text = ds.Tables[0].Rows[0]["uc_20a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_20b"].ToString() == "1")
                        //{
                        //    uc_20b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_20b"].ToString() == "2")
                        //{
                        //    uc_20b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_20b"].ToString() == "3")
                        //{
                        //    uc_20b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_21a"].ToString() == "0")
                        //{
                        //    uc_21a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_21a"].ToString() == "999")
                        //{
                        //    uc_21a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_21a"].ToString() == "888")
                        //{
                        //    uc_21a_c.Checked = true;
                        //}


                        //uc_21a_a.Text = ds.Tables[0].Rows[0]["uc_21a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_21b"].ToString() == "1")
                        //{
                        //    uc_21b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_21b"].ToString() == "2")
                        //{
                        //    uc_21b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_21b"].ToString() == "3")
                        //{
                        //    uc_21b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_22a"].ToString() == "0")
                        //{
                        //    uc_22a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_22a"].ToString() == "999")
                        //{
                        //    uc_22a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_22a"].ToString() == "888")
                        //{
                        //    uc_22a_c.Checked = true;
                        //}


                        //uc_22a_a.Text = ds.Tables[0].Rows[0]["uc_22a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_22b"].ToString() == "1")
                        //{
                        //    uc_22b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_22b"].ToString() == "2")
                        //{
                        //    uc_22b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_22b"].ToString() == "3")
                        //{
                        //    uc_22b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_23a"].ToString() == "0")
                        //{
                        //    uc_23a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_23a"].ToString() == "999")
                        //{
                        //    uc_23a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_23a"].ToString() == "888")
                        //{
                        //    uc_23a_c.Checked = true;
                        //}


                        //uc_23a_a.Text = ds.Tables[0].Rows[0]["uc_23a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_23b"].ToString() == "1")
                        //{
                        //    uc_23b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_23b"].ToString() == "2")
                        //{
                        //    uc_23b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_23b"].ToString() == "3")
                        //{
                        //    uc_23b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_24a"].ToString() == "0")
                        //{
                        //    uc_24a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_24a"].ToString() == "999")
                        //{
                        //    uc_24a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_24a"].ToString() == "888")
                        //{
                        //    uc_24a_c.Checked = true;
                        //}


                        //uc_24a_a.Text = ds.Tables[0].Rows[0]["uc_24a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_24b"].ToString() == "1")
                        //{
                        //    uc_24b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_24b"].ToString() == "2")
                        //{
                        //    uc_24b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_24b"].ToString() == "3")
                        //{
                        //    uc_24b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_25a"].ToString() == "0")
                        //{
                        //    uc_25a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_25a"].ToString() == "999")
                        //{
                        //    uc_25a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_25a"].ToString() == "888")
                        //{
                        //    uc_25a_c.Checked = true;
                        //}


                        //uc_25a_a.Text = ds.Tables[0].Rows[0]["uc_25a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_25b"].ToString() == "1")
                        //{
                        //    uc_25b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_25b"].ToString() == "2")
                        //{
                        //    uc_25b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_25b"].ToString() == "3")
                        //{
                        //    uc_25b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_26a"].ToString() == "0")
                        //{
                        //    uc_26a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_26a"].ToString() == "999")
                        //{
                        //    uc_26a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_26a"].ToString() == "888")
                        //{
                        //    uc_26a_c.Checked = true;
                        //}


                        //uc_26a_a.Text = ds.Tables[0].Rows[0]["uc_26a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_26b"].ToString() == "1")
                        //{
                        //    uc_26b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_26b"].ToString() == "2")
                        //{
                        //    uc_26b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_26b"].ToString() == "3")
                        //{
                        //    uc_26b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_27a"].ToString() == "0")
                        //{
                        //    uc_27a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_27a"].ToString() == "999")
                        //{
                        //    uc_27a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_27a"].ToString() == "888")
                        //{
                        //    uc_27a_c.Checked = true;
                        //}


                        //uc_27a_a.Text = ds.Tables[0].Rows[0]["uc_27a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_27b"].ToString() == "1")
                        //{
                        //    uc_27b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_27b"].ToString() == "2")
                        //{
                        //    uc_27b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_27b"].ToString() == "3")
                        //{
                        //    uc_27b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_28a"].ToString() == "0")
                        //{
                        //    uc_28a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_28a"].ToString() == "999")
                        //{
                        //    uc_28a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_28a"].ToString() == "888")
                        //{
                        //    uc_28a_c.Checked = true;
                        //}


                        //uc_28a_a.Text = ds.Tables[0].Rows[0]["uc_28a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_28b"].ToString() == "1")
                        //{
                        //    uc_28b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_28b"].ToString() == "2")
                        //{
                        //    uc_28b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_28b"].ToString() == "3")
                        //{
                        //    uc_28b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_29a"].ToString() == "0")
                        //{
                        //    uc_29a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_29a"].ToString() == "999")
                        //{
                        //    uc_29a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_29a"].ToString() == "888")
                        //{
                        //    uc_29a_c.Checked = true;
                        //}


                        //uc_29a_a.Text = ds.Tables[0].Rows[0]["uc_29a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_29b"].ToString() == "1")
                        //{
                        //    uc_29b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_29b"].ToString() == "2")
                        //{
                        //    uc_29b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_29b"].ToString() == "3")
                        //{
                        //    uc_29b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_30a"].ToString() == "0")
                        //{
                        //    uc_30a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_30a"].ToString() == "999")
                        //{
                        //    uc_30a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_30a"].ToString() == "888")
                        //{
                        //    uc_30a_c.Checked = true;
                        //}


                        //uc_30a_a.Text = ds.Tables[0].Rows[0]["uc_30a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_30b"].ToString() == "1")
                        //{
                        //    uc_30b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_30b"].ToString() == "2")
                        //{
                        //    uc_30b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_30b"].ToString() == "3")
                        //{
                        //    uc_30b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_31a"].ToString() == "0")
                        //{
                        //    uc_31a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_31a"].ToString() == "999")
                        //{
                        //    uc_31a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_31a"].ToString() == "888")
                        //{
                        //    uc_31a_c.Checked = true;
                        //}


                        //uc_31a_a.Text = ds.Tables[0].Rows[0]["uc_31a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_31b"].ToString() == "1")
                        //{
                        //    uc_31b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_31b"].ToString() == "2")
                        //{
                        //    uc_31b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_31b"].ToString() == "3")
                        //{
                        //    uc_31b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_32a"].ToString() == "0")
                        //{
                        //    uc_32a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_32a"].ToString() == "999")
                        //{
                        //    uc_32a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_32a"].ToString() == "888")
                        //{
                        //    uc_32a_c.Checked = true;
                        //}


                        //uc_32a_a.Text = ds.Tables[0].Rows[0]["uc_32a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_32b"].ToString() == "1")
                        //{
                        //    uc_32b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_32b"].ToString() == "2")
                        //{
                        //    uc_32b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_32b"].ToString() == "3")
                        //{
                        //    uc_32b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_33a"].ToString() == "0")
                        //{
                        //    uc_33a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_33a"].ToString() == "999")
                        //{
                        //    uc_33a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_33a"].ToString() == "888")
                        //{
                        //    uc_33a_c.Checked = true;
                        //}


                        //uc_33a_a.Text = ds.Tables[0].Rows[0]["uc_33a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_33b"].ToString() == "1")
                        //{
                        //    uc_33b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_33b"].ToString() == "2")
                        //{
                        //    uc_33b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_33b"].ToString() == "3")
                        //{
                        //    uc_33b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_34a"].ToString() == "0")
                        //{
                        //    uc_34a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_34a"].ToString() == "999")
                        //{
                        //    uc_34a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_34a"].ToString() == "888")
                        //{
                        //    uc_34a_c.Checked = true;
                        //}


                        //uc_34a_a.Text = ds.Tables[0].Rows[0]["uc_34a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_34b"].ToString() == "0")
                        //{
                        //    uc_34b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_34b"].ToString() == "999")
                        //{
                        //    uc_34b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_34b"].ToString() == "888")
                        //{
                        //    uc_34b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_35a"].ToString() == "0")
                        //{
                        //    uc_35a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_35a"].ToString() == "999")
                        //{
                        //    uc_35a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_35a"].ToString() == "888")
                        //{
                        //    uc_35a_c.Checked = true;
                        //}


                        //uc_35a_a.Text = ds.Tables[0].Rows[0]["uc_35a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_35b"].ToString() == "1")
                        //{
                        //    uc_35b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_35b"].ToString() == "2")
                        //{
                        //    uc_35b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_35b"].ToString() == "3")
                        //{
                        //    uc_35b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_36a"].ToString() == "0")
                        //{
                        //    uc_36a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_36a"].ToString() == "999")
                        //{
                        //    uc_36a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_36a"].ToString() == "888")
                        //{
                        //    uc_36a_c.Checked = true;
                        //}


                        //uc_36a_a.Text = ds.Tables[0].Rows[0]["uc_36a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_36b"].ToString() == "1")
                        //{
                        //    uc_36b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_36b"].ToString() == "2")
                        //{
                        //    uc_36b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_36b"].ToString() == "3")
                        //{
                        //    uc_36b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["uc_37a"].ToString() == "0")
                        //{
                        //    uc_37a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_37a"].ToString() == "999")
                        //{
                        //    uc_37a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_37a"].ToString() == "888")
                        //{
                        //    uc_37a_c.Checked = true;
                        //}


                        //uc_37a_a.Text = ds.Tables[0].Rows[0]["uc_37a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["uc_37b"].ToString() == "1")
                        //{
                        //    uc_37b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_37b"].ToString() == "2")
                        //{
                        //    uc_37b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["uc_37b"].ToString() == "3")
                        //{
                        //    uc_37b_c.Checked = true;
                        //}


                        //LA_17.Text = ds.Tables[0].Rows[0]["LA_17"].ToString();


                        //LA_18.Text = ds.Tables[0].Rows[0]["LA_18"].ToString();


                        //LA_19.Text = ds.Tables[0].Rows[0]["LA_19"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_20a_b"].ToString() == "0")
                        //{
                        //    LA_20a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_20a_b"].ToString() == "999")
                        //{
                        //    LA_20a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_20a_b"].ToString() == "888")
                        //{
                        //    LA_20a_c.Checked = true;
                        //}


                        //LA_20a_a.Text = ds.Tables[0].Rows[0]["LA_20a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_20b_a"].ToString() == "1")
                        //{
                        //    LA_20b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_20b_a"].ToString() == "2")
                        //{
                        //    LA_20b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_20b_a"].ToString() == "3")
                        //{
                        //    LA_20b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_21a_b"].ToString() == "0")
                        //{
                        //    LA_21a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_21a_b"].ToString() == "999")
                        //{
                        //    LA_21a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_21a_b"].ToString() == "888")
                        //{
                        //    LA_21a_c.Checked = true;
                        //}


                        //LA_21a_a.Text = ds.Tables[0].Rows[0]["LA_21a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_21b_a"].ToString() == "1")
                        //{
                        //    LA_21b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_21b_a"].ToString() == "2")
                        //{
                        //    LA_21b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_21b_a"].ToString() == "3")
                        //{
                        //    LA_21b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_22a_b"].ToString() == "0")
                        //{
                        //    LA_22a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_22a_b"].ToString() == "999")
                        //{
                        //    LA_22a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_22a_b"].ToString() == "888")
                        //{
                        //    LA_22a_c.Checked = true;
                        //}


                        //LA_22a_a.Text = ds.Tables[0].Rows[0]["LA_22a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_22b_a"].ToString() == "1")
                        //{
                        //    LA_22b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_22b_a"].ToString() == "2")
                        //{
                        //    LA_22b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_22b_a"].ToString() == "3")
                        //{
                        //    LA_22b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_23a_b"].ToString() == "0")
                        //{
                        //    LA_23a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_23a_b"].ToString() == "999")
                        //{
                        //    LA_23a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_23a_b"].ToString() == "888")
                        //{
                        //    LA_23a_c.Checked = true;
                        //}


                        //LA_23a_a.Text = ds.Tables[0].Rows[0]["LA_23a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_23b_a"].ToString() == "1")
                        //{
                        //    LA_23b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_23b_a"].ToString() == "2")
                        //{
                        //    LA_23b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_23b_a"].ToString() == "3")
                        //{
                        //    LA_23b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_24a_b"].ToString() == "0")
                        //{
                        //    LA_24a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_24a_b"].ToString() == "999")
                        //{
                        //    LA_24a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_24a_b"].ToString() == "888")
                        //{
                        //    LA_24a_c.Checked = true;
                        //}


                        //LA_24a_a.Text = ds.Tables[0].Rows[0]["LA_24a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_24b_a"].ToString() == "1")
                        //{
                        //    LA_24b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_24b_a"].ToString() == "2")
                        //{
                        //    LA_24b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_24b_a"].ToString() == "3")
                        //{
                        //    LA_24b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_25a_b"].ToString() == "0")
                        //{
                        //    LA_25a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_25a_b"].ToString() == "999")
                        //{
                        //    LA_25a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_25a_b"].ToString() == "888")
                        //{
                        //    LA_25a_c.Checked = true;
                        //}


                        //LA_25a_a.Text = ds.Tables[0].Rows[0]["LA_25a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_25b_a"].ToString() == "1")
                        //{
                        //    LA_25b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_25b_a"].ToString() == "2")
                        //{
                        //    LA_25b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_25b_a"].ToString() == "3")
                        //{
                        //    LA_25b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_26a_b"].ToString() == "0")
                        //{
                        //    LA_26a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_26a_b"].ToString() == "999")
                        //{
                        //    LA_26a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_26a_b"].ToString() == "888")
                        //{
                        //    LA_26a_c.Checked = true;
                        //}


                        //LA_26a_a.Text = ds.Tables[0].Rows[0]["LA_26a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_26b_a"].ToString() == "1")
                        //{
                        //    LA_26b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_26b_a"].ToString() == "2")
                        //{
                        //    LA_26b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_26b_a"].ToString() == "3")
                        //{
                        //    LA_26b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_27a_b"].ToString() == "0")
                        //{
                        //    LA_27a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_27a_b"].ToString() == "999")
                        //{
                        //    LA_27a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_27a_b"].ToString() == "888")
                        //{
                        //    LA_27a_c.Checked = true;
                        //}


                        //LA_27a_a.Text = ds.Tables[0].Rows[0]["LA_27a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_27b_a"].ToString() == "1")
                        //{
                        //    LA_27b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_27b_a"].ToString() == "2")
                        //{
                        //    LA_27b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_27b_a"].ToString() == "3")
                        //{
                        //    LA_27b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_28a_b"].ToString() == "0")
                        //{
                        //    LA_28a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_28a_b"].ToString() == "999")
                        //{
                        //    LA_28a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_28a_b"].ToString() == "888")
                        //{
                        //    LA_28a_c.Checked = true;
                        //}


                        //LA_28a_a.Text = ds.Tables[0].Rows[0]["LA_28a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_28b_a"].ToString() == "1")
                        //{
                        //    LA_28b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_28b_a"].ToString() == "2")
                        //{
                        //    LA_28b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_28b_a"].ToString() == "3")
                        //{
                        //    LA_28b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_29a_b"].ToString() == "0")
                        //{
                        //    LA_29a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_29a_b"].ToString() == "999")
                        //{
                        //    LA_29a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_29a_b"].ToString() == "888")
                        //{
                        //    LA_29a_c.Checked = true;
                        //}


                        //LA_29a_a.Text = ds.Tables[0].Rows[0]["LA_29a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_29b_a"].ToString() == "1")
                        //{
                        //    LA_29b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_29b_a"].ToString() == "2")
                        //{
                        //    LA_29b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_29b_a"].ToString() == "3")
                        //{
                        //    LA_29b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_30a_b"].ToString() == "0")
                        //{
                        //    LA_30a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_30a_b"].ToString() == "999")
                        //{
                        //    LA_30a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_30a_b"].ToString() == "888")
                        //{
                        //    LA_30a_c.Checked = true;
                        //}


                        //LA_30a_a.Text = ds.Tables[0].Rows[0]["LA_30a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_30b_a"].ToString() == "1")
                        //{
                        //    LA_30b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_30b_a"].ToString() == "2")
                        //{
                        //    LA_30b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_30b_a"].ToString() == "3")
                        //{
                        //    LA_30b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_31a_b"].ToString() == "0")
                        //{
                        //    LA_31a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_31a_b"].ToString() == "999")
                        //{
                        //    LA_31a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_31a_b"].ToString() == "888")
                        //{
                        //    LA_31a_c.Checked = true;
                        //}


                        //LA_31a_a.Text = ds.Tables[0].Rows[0]["LA_31a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_31b_a"].ToString() == "1")
                        //{
                        //    LA_31b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_31b_a"].ToString() == "2")
                        //{
                        //    LA_31b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_31b_a"].ToString() == "3")
                        //{
                        //    LA_31b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_32a_b"].ToString() == "0")
                        //{
                        //    LA_32a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_32a_b"].ToString() == "999")
                        //{
                        //    LA_32a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_32a_b"].ToString() == "888")
                        //{
                        //    LA_32a_c.Checked = true;
                        //}


                        //LA_32a_a.Text = ds.Tables[0].Rows[0]["LA_32a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_32b_a"].ToString() == "1")
                        //{
                        //    LA_32b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_32b_a"].ToString() == "2")
                        //{
                        //    LA_32b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_32b_a"].ToString() == "3")
                        //{
                        //    LA_32b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_33a_b"].ToString() == "0")
                        //{
                        //    LA_33a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_33a_b"].ToString() == "999")
                        //{
                        //    LA_33a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_33a_b"].ToString() == "888")
                        //{
                        //    LA_33a_c.Checked = true;
                        //}


                        //LA_33a_a.Text = ds.Tables[0].Rows[0]["LA_33a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_33b_a"].ToString() == "1")
                        //{
                        //    LA_33b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_33b_a"].ToString() == "2")
                        //{
                        //    LA_33b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_33b_a"].ToString() == "3")
                        //{
                        //    LA_33b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_34a_b"].ToString() == "0")
                        //{
                        //    LA_34a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_34a_b"].ToString() == "999")
                        //{
                        //    LA_34a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_34a_b"].ToString() == "888")
                        //{
                        //    LA_34a_c.Checked = true;
                        //}


                        //LA_34a_a.Text = ds.Tables[0].Rows[0]["LA_34a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_34b_a"].ToString() == "1")
                        //{
                        //    LA_34b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_34b_a"].ToString() == "2")
                        //{
                        //    LA_34b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_34b_a"].ToString() == "3")
                        //{
                        //    LA_34b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_35a_b"].ToString() == "0")
                        //{
                        //    LA_35a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_35a_b"].ToString() == "999")
                        //{
                        //    LA_35a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_35a_b"].ToString() == "888")
                        //{
                        //    LA_35a_c.Checked = true;
                        //}


                        //LA_35a_a.Text = ds.Tables[0].Rows[0]["LA_35a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_35b_a"].ToString() == "1")
                        //{
                        //    LA_35b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_35b_a"].ToString() == "2")
                        //{
                        //    LA_35b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_35b_a"].ToString() == "3")
                        //{
                        //    LA_35b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_36a_b"].ToString() == "0")
                        //{
                        //    LA_36a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_36a_b"].ToString() == "999")
                        //{
                        //    LA_36a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_36a_b"].ToString() == "888")
                        //{
                        //    LA_36a_c.Checked = true;
                        //}


                        //LA_36a_a.Text = ds.Tables[0].Rows[0]["LA_36a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_36b_a"].ToString() == "1")
                        //{
                        //    LA_36b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_36b_a"].ToString() == "2")
                        //{
                        //    LA_36b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_36b_a"].ToString() == "3")
                        //{
                        //    LA_36b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_37a_b"].ToString() == "0")
                        //{
                        //    LA_37a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_37a_b"].ToString() == "999")
                        //{
                        //    LA_37a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_37a_b"].ToString() == "888")
                        //{
                        //    LA_37a_c.Checked = true;
                        //}


                        //LA_37a_a.Text = ds.Tables[0].Rows[0]["LA_37a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_37b_a"].ToString() == "1")
                        //{
                        //    LA_37b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_37b_a"].ToString() == "2")
                        //{
                        //    LA_37b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_37b_a"].ToString() == "3")
                        //{
                        //    LA_37b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_38a_b"].ToString() == "0")
                        //{
                        //    LA_38a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_38a_b"].ToString() == "999")
                        //{
                        //    LA_38a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_38a_b"].ToString() == "888")
                        //{
                        //    LA_38a_c.Checked = true;
                        //}


                        //LA_38a_a.Text = ds.Tables[0].Rows[0]["LA_38a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_38b_a"].ToString() == "1")
                        //{
                        //    LA_38b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_38b_a"].ToString() == "2")
                        //{
                        //    LA_38b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_38b_a"].ToString() == "3")
                        //{
                        //    LA_38b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_39a_b"].ToString() == "0")
                        //{
                        //    LA_39a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_39a_b"].ToString() == "999")
                        //{
                        //    LA_39a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_39a_b"].ToString() == "888")
                        //{
                        //    LA_39a_c.Checked = true;
                        //}


                        //LA_39a_a.Text = ds.Tables[0].Rows[0]["LA_39a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_39b_a"].ToString() == "1")
                        //{
                        //    LA_39b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_39b_a"].ToString() == "2")
                        //{
                        //    LA_39b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_39b_a"].ToString() == "3")
                        //{
                        //    LA_39b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_40a_b"].ToString() == "0")
                        //{
                        //    LA_40a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_40a_b"].ToString() == "999")
                        //{
                        //    LA_40a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_40a_b"].ToString() == "888")
                        //{
                        //    LA_40a_c.Checked = true;
                        //}


                        //LA_40a_a.Text = ds.Tables[0].Rows[0]["LA_40a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_40b_a"].ToString() == "1")
                        //{
                        //    LA_40b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_40b_a"].ToString() == "2")
                        //{
                        //    LA_40b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_40b_a"].ToString() == "3")
                        //{
                        //    LA_40b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_41a_b"].ToString() == "0")
                        //{
                        //    LA_41a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_41a_b"].ToString() == "999")
                        //{
                        //    LA_41a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_41a_b"].ToString() == "888")
                        //{
                        //    LA_41a_c.Checked = true;
                        //}


                        //LA_41a_a.Text = ds.Tables[0].Rows[0]["LA_41a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_41b_a"].ToString() == "1")
                        //{
                        //    LA_41b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_41b_a"].ToString() == "2")
                        //{
                        //    LA_41b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_41b_a"].ToString() == "3")
                        //{
                        //    LA_41b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_42a_b"].ToString() == "0")
                        //{
                        //    LA_42a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_42a_b"].ToString() == "999")
                        //{
                        //    LA_42a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_42a_b"].ToString() == "888")
                        //{
                        //    LA_42a_c.Checked = true;
                        //}


                        //LA_42a_a.Text = ds.Tables[0].Rows[0]["LA_42a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_42b_a"].ToString() == "1")
                        //{
                        //    LA_42b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_42b_a"].ToString() == "2")
                        //{
                        //    LA_42b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_42b_a"].ToString() == "3")
                        //{
                        //    LA_42b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_43a_b"].ToString() == "0")
                        //{
                        //    LA_43a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_43a_b"].ToString() == "999")
                        //{
                        //    LA_43a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_43a_b"].ToString() == "888")
                        //{
                        //    LA_43a_c.Checked = true;
                        //}


                        //LA_43a_a.Text = ds.Tables[0].Rows[0]["LA_43a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_43b_a"].ToString() == "1")
                        //{
                        //    LA_43b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_43b_a"].ToString() == "2")
                        //{
                        //    LA_43b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_43b_a"].ToString() == "3")
                        //{
                        //    LA_43b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_44a_b"].ToString() == "0")
                        //{
                        //    LA_44a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_44a_b"].ToString() == "999")
                        //{
                        //    LA_44a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_44a_b"].ToString() == "888")
                        //{
                        //    LA_44a_c.Checked = true;
                        //}


                        //LA_44a_a.Text = ds.Tables[0].Rows[0]["LA_44a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_44b_a"].ToString() == "1")
                        //{
                        //    LA_44b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_44b_a"].ToString() == "2")
                        //{
                        //    LA_44b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_44b_a"].ToString() == "3")
                        //{
                        //    LA_44b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_45a_b"].ToString() == "0")
                        //{
                        //    LA_45a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_45a_b"].ToString() == "999")
                        //{
                        //    LA_45a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_45a_b"].ToString() == "888")
                        //{
                        //    LA_45a_c.Checked = true;
                        //}


                        //LA_45a_a.Text = ds.Tables[0].Rows[0]["LA_45a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_45b_a"].ToString() == "1")
                        //{
                        //    LA_45b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_45b_a"].ToString() == "2")
                        //{
                        //    LA_45b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_45b_a"].ToString() == "3")
                        //{
                        //    LA_45b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_46a_b"].ToString() == "0")
                        //{
                        //    LA_46a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_46a_b"].ToString() == "999")
                        //{
                        //    LA_46a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_46a_b"].ToString() == "888")
                        //{
                        //    LA_46a_c.Checked = true;
                        //}


                        //LA_46a_a.Text = ds.Tables[0].Rows[0]["LA_46a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_46b_a"].ToString() == "1")
                        //{
                        //    LA_46b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_46b_a"].ToString() == "2")
                        //{
                        //    LA_46b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_46b_a"].ToString() == "3")
                        //{
                        //    LA_46b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_47a_b"].ToString() == "0")
                        //{
                        //    LA_47a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_47a_b"].ToString() == "999")
                        //{
                        //    LA_47a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_47a_b"].ToString() == "888")
                        //{
                        //    LA_47a_c.Checked = true;
                        //}


                        //LA_47a_a.Text = ds.Tables[0].Rows[0]["LA_47a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_47b_a"].ToString() == "1")
                        //{
                        //    LA_47b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_47b_a"].ToString() == "2")
                        //{
                        //    LA_47b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_47b_a"].ToString() == "3")
                        //{
                        //    LA_47b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_48a_b"].ToString() == "0")
                        //{
                        //    LA_48a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_48a_b"].ToString() == "999")
                        //{
                        //    LA_48a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_48a_b"].ToString() == "888")
                        //{
                        //    LA_48a_c.Checked = true;
                        //}


                        //LA_48a_a.Text = ds.Tables[0].Rows[0]["LA_48a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_48b_a"].ToString() == "1")
                        //{
                        //    LA_48b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_48b_a"].ToString() == "2")
                        //{
                        //    LA_48b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_48b_a"].ToString() == "3")
                        //{
                        //    LA_48b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_49a_b"].ToString() == "0")
                        //{
                        //    LA_49a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_49a_b"].ToString() == "999")
                        //{
                        //    LA_49a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_49a_b"].ToString() == "888")
                        //{
                        //    LA_49a_c.Checked = true;
                        //}


                        //LA_49a_a.Text = ds.Tables[0].Rows[0]["LA_49a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_49b_a"].ToString() == "1")
                        //{
                        //    LA_49b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_49b_a"].ToString() == "2")
                        //{
                        //    LA_49b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_49b_a"].ToString() == "3")
                        //{
                        //    LA_49b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_50a_b"].ToString() == "0")
                        //{
                        //    LA_50a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_50a_b"].ToString() == "999")
                        //{
                        //    LA_50a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_50a_b"].ToString() == "888")
                        //{
                        //    LA_50a_c.Checked = true;
                        //}


                        //LA_50a_a.Text = ds.Tables[0].Rows[0]["LA_50a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_50b_a"].ToString() == "1")
                        //{
                        //    LA_50b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_50b_a"].ToString() == "2")
                        //{
                        //    LA_50b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_50b_a"].ToString() == "3")
                        //{
                        //    LA_50b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_51a_b"].ToString() == "0")
                        //{
                        //    LA_51a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_51a_b"].ToString() == "999")
                        //{
                        //    LA_51a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_51a_b"].ToString() == "888")
                        //{
                        //    LA_51a_c.Checked = true;
                        //}


                        //LA_51a_a.Text = ds.Tables[0].Rows[0]["LA_51a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_51b_a"].ToString() == "1")
                        //{
                        //    LA_51b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_51b_a"].ToString() == "2")
                        //{
                        //    LA_51b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_51b_a"].ToString() == "3")
                        //{
                        //    LA_51b_c.Checked = true;
                        //}


                        //if (ds.Tables[0].Rows[0]["LA_52a_b"].ToString() == "0")
                        //{
                        //    LA_52a_v.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_52a_b"].ToString() == "999")
                        //{
                        //    LA_52a_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_52a_b"].ToString() == "888")
                        //{
                        //    LA_52a_c.Checked = true;
                        //}


                        //LA_52a_a.Text = ds.Tables[0].Rows[0]["LA_52a_a"].ToString();


                        //if (ds.Tables[0].Rows[0]["LA_52b_a"].ToString() == "1")
                        //{
                        //    LA_52b_a.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_52b_a"].ToString() == "2")
                        //{
                        //    LA_52b_b.Checked = true;
                        //}
                        //else if (ds.Tables[0].Rows[0]["LA_52b_a"].ToString() == "3")
                        //{
                        //    LA_52b_c.Checked = true;
                        //}


                    }
                }
            }
        }

        catch (Exception ex)
        {
            string message = "alert('Exception occur');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
        }

        finally
        {
            cn = null;
        }
    }


    private void BindGrid()
    {
        CConnection cn = null;

        try
        {
            cn = new CConnection();

            string qry;

            qry = "select b.id, b.id id1, a.AS1_screening_ID, a.AS1_rand_id, a.AS1_name, a.AS1_age, a.AS1_mrno, a.AS1_lno from form1 a inner join sample_result b on a.AS1_screening_ID = b.la_sno ";
            qry = SearchingCriteria(qry);


            SqlDataAdapter da = new SqlDataAdapter(qry, cn.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dg.Columns[0].Visible = true;
            dg.DataSource = ds.Tables[0];
            dg.DataBind();
            dg.Columns[0].Visible = false;
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Exception Error", "alert('" + ex.Message.Replace("'", "") + "')", false);
        }

        finally
        {
            cn = null;
        }
    }


    protected void dg_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dg.PageIndex = e.NewPageIndex;
        dg.DataBind();
    }


    protected void cmdSearchAll_Click(object sender, EventArgs e)
    {
        CConnection cn = null;

        try
        {
            dg.Visible = true;
            lblerr.Text = "";
            ReportViewer1.Visible = false;
            ddl_screeningid.Items.Clear();


            if (Request.Cookies["role"].Value == "admin")
            {
                fillDropDown_allsites();
            }
            else
            {
                fillDropDown_sitewise();
            }


            cn = new CConnection();

            string qry;

            qry = "select b.ID, b.id id1, a.AS1_screening_ID, a.AS1_rand_id, a.AS1_name, a.AS1_age, a.AS1_mrno, a.AS1_lno from form1 a inner join sample_result b on a.AS1_screening_ID = b.la_sno and a.labid = 1 and (b.history is null) or (b.history = '') ";


            SqlDataAdapter da = new SqlDataAdapter(qry, cn.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dg.DataSource = ds.Tables[0];
            dg.DataBind();
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Exception Error", "alert('" + ex.Message.Replace("'", "") + "')", false);
        }

        finally
        {
            cn = null;
        }
    }


    private DataSet GetData()
    {
        DataSet ds = null;

        try
        {
            CConnection cn = new CConnection();
            SqlDataAdapter da = new SqlDataAdapter("select " +
"b.AS1_screening_ID," +
"b.AS1_rand_id," +
"b.AS1_name," +
"b.AS1_sex," +
"b.AS1_age," +
"b.AS1_barcode," +
"b.AS1_mrno," +
"b.AS1_lno," +
"b.AS1_barcode1," +
"b.AS1_fsite," +
"b.AS1_Samp_1," +
"b.AS1_Samp_2," +
"b.AS1_Samp_3," +
"b.AS1_Samp_4," +
"b.AS1_Q1_1," +
"b.AS1_Q1_2," +
"b.AS1_Q2_1," +
"b.AS1_Q2_2," +
"b.AS1_Q3," +
"b.AS1_Q3a_1," +
"b.AS1_Q3a_2," +
"b.AS1_Q4," +
"b.AS1_Q5," +
"b.AS1_Q6," +
"b.AS1_Q6a," +
"b.AS1_Q6b," +
"b.AS1_Q6c," +
"b.AS2_Q7_1," +
"b.AS2_Q7_2," +
"b.AS2_Q7_CBC_CODE," +
"b.AS2_Q8," +
"b.AS2_Q8_BacT," +
"b.AS2_Q8_3," +
"b.AS2_Q8a," +
"b.AS2_Q9," +
"b.AS2_Q10," +
"b.AS2_Q11," +
"b.AS2_Q12_1," +
"b.AS2_Q12_2," +
"b.AS2_Q12_3," +
"b.AS2_Q12_4," +
"b.AS2_Q13," +
"b.AS2_Q13a," +
"b.AS3_Q14," +
"b.AS3_Q14a," +
"b.AS3_Q15," +
"b.AS3_Q16," +
"b.AS3_Q17," +
"b.AS3_Q18," +
"b.AS3_Q19," +
"b.AS3_Q20," +
"b.AS4_Q21a," +
"b.AS4_Q22a," +
"b.AS4_Q22b," +
"b.AS4_Q23," +
"b.AS4_Q24," +
"b.AS5_Q25a," +
"b.AS5_Q25b," +
"b.AS5_Q26," +
"b.AS5_Q27," +
"b.AS5_Q28," +
"b.AS5_Q29," +
"b.AS5_Q30," +
"b.AS5_Q31," +
"b.AS5_Q32," +
"b.AS5_Q33a," +
"b.AS5_Q33b," +
"b.AS3_Remarks," +
"b.AS6_Q34," +
"b.AS6_Q35," +
"b.AS6_Q36," +
"b.AS6_Q37," +
"b.AS6_Q38," +
"b.AS6_Q39," +
"b.AS6_Q40," +
"b.AS6_Q41," +
"b.AS6_Q42," +
"b.AS6_Q43," +
"b.AS6_Q44," +
"b.AS6_Q45," +
"b.AS6_Q46," +
"b.AS6_Q47," +
"b.AS5_R1," +
"b.AS3_A1," +
"b.AS3_A2," +
"b.AS3_B1," +
"b.AS3_B2," +
"a.la_sno," +
"a.LA_01," +
"a.LA_02," +
"a.LA_03_b," +
"a.LA_03_a," +
"a.LA_04_b," +
"a.LA_04_a," +
"a.LA_05_b," +
"a.LA_05_a," +
"a.LA_06_b," +
"a.LA_06_a," +
"a.LA_07_b," +
"a.LA_07_a," +
"a.LA_08_b," +
"a.LA_08_a," +
"a.LA_09_b," +
"a.LA_09_a," +
"a.LA_10_b," +
"a.LA_10_a," +
"a.LA_11_b," +
"a.LA_11_a," +
"a.LA_12_b," +
"a.LA_12_a," +
"a.LA_13_b," +
"a.LA_13_a," +
"a.LA_14_b," +
"a.LA_14_a," +
"a.LA_15_b," +
"a.LA_15_a," +
"a.LA_16_b," +
"a.LA_16_a," +
"a.LF_01," +
"a.LF_01_a," +
"a.LF_02," +
"a.LF_02_a," +
"a.LF_03," +
"a.LF_03_a," +
"a.LF_04," +
"a.LF_04_a," +
"a.LF_05," +
"a.LF_05_a," +
"a.LF_06," +
"a.LF_06_a," +
"a.LF_07," +
"a.LF_07_a," +
"a.RF_01," +
"a.RF_01_a," +
"a.RF_02," +
"a.RF_02_a," +
"a.RF_03," +
"a.RF_03_a," +
"a.RF_04," +
"a.RF_04_a," +
"a.SE_01," +
"a.SE_01_a," +
"a.SE_02," +
"a.SE_02_a," +
"a.SE_03," +
"a.SE_03_a," +
"a.SE_04," +
"a.SE_04_a," +
"a.CS_01," +
"a.CS_01_a," +
"a.CS_02," +
"a.CS_02_a," +
"a.CS_03," +
"a.CS_03_a," +
"a.CS_04," +
"a.CS_04_a," +
"a.CS_05," +
"a.CS_05_a," +
"a.CS_06," +
"a.CS_06_a," +
"a.CS_07," +
"a.CS_07_a," +
"a.CS_08," +
"a.CS_08_a," +
"a.CS_09," +
"a.CS_09_a," +
"a.CS_10," +
"a.CS_10_a," +
"a.UR_01," +
"a.UR_01_a," +
"a.UR_02," +
"a.UR_02_a," +
"a.UR_03," +
"a.UR_03_a," +
"a.UR_04," +
"a.UR_04_a," +
"a.UR_04a," +
"a.UR_04a_a," +
"a.UR_05," +
"a.UR_05_a," +
"a.UR_06," +
"a.UR_06_a," +
"a.UR_07," +
"a.UR_07_a," +
"a.UR_08," +
"a.UR_08_a," +
"a.UR_10," +
"a.UR_10_a," +
"a.UR_11," +
"a.UR_11_a," +
"a.UR_12," +
"a.UR_12_a," +
"a.UR_13," +
"a.UR_13_a," +
"a.UR_14," +
"a.UR_14_a," +
"a.UR_15," +
"a.UR_15_a," +
"a.UR_16," +
"a.UR_16_a," +
"a.UR_17," +
"a.UR_17_a," +
"a.UR_18," +
"a.UR_18_a," +
"a.UR_19," +
"a.UR_19_a," +
"a.UR_20," +
"a.UR_20_a," +
"a.UR_21," +
"a.UR_21_a," +
"a.uc_01_ca," +
"case when a.uc_01a = 1 then 'Uropathogen Isolated' when a.uc_01a = 2 then 'No Uropathogen Isolated' when a.uc_01a = 999 then 'NA' end uc_01a," +
"a.uc_02a," +
"a.uc_02a_a," +
"a.uc_02b," +
"a.uc_03a," +
"a.uc_03a_a," +
"a.uc_03b," +
"a.uc_04a," +
"a.uc_04a_a," +
"a.uc_04b," +
"a.uc_05a," +
"a.uc_05a_a," +
"a.uc_05b," +
"a.uc_06a," +
"a.uc_06a_a," +
"a.uc_06b," +
"a.uc_07a," +
"a.uc_07a_a," +
"a.uc_07b," +
"a.uc_08a," +
"a.uc_08a_a," +
"a.uc_08b," +
"a.uc_09a," +
"a.uc_09a_a," +
"a.uc_09b," +
"a.uc_10a," +
"a.uc_10a_a," +
"a.uc_10b," +
"a.uc_11a," +
"a.uc_11a_a," +
"a.uc_11b," +
"a.uc_12a," +
"a.uc_12a_a," +
"a.uc_12b," +
"a.uc_13a," +
"a.uc_13a_a," +
"a.uc_13b," +
"a.uc_14a," +
"a.uc_14a_a," +
"a.uc_14b," +
"a.uc_15a," +
"a.uc_15a_a," +
"a.uc_15b," +
"a.uc_16a," +
"a.uc_16a_a," +
"a.uc_16b," +
"a.uc_17a," +
"a.uc_17a_a," +
"a.uc_17b," +
"a.uc_18a," +
"a.uc_18a_a," +
"a.uc_18b," +
"a.uc_19a," +
"a.uc_19a_a," +
"a.uc_19b," +
"a.uc_20a," +
"a.uc_20a_a," +
"a.uc_20b," +
"a.uc_21a," +
"a.uc_21a_a," +
"a.uc_21b," +
"a.uc_22a," +
"a.uc_22a_a," +
"a.uc_22b," +
"a.uc_23a," +
"a.uc_23a_a," +
"a.uc_23b," +
"a.uc_24a," +
"a.uc_24a_a," +
"a.uc_24b," +
"a.uc_25a," +
"a.uc_25a_a," +
"a.uc_25b," +
"a.uc_26a," +
"a.uc_26a_a," +
"a.uc_26b," +
"a.uc_27a," +
"a.uc_27a_a," +
"a.uc_27b," +
"a.uc_28a," +
"a.uc_28a_a," +
"a.uc_28b," +
"a.uc_29a," +
"a.uc_29a_a," +
"a.uc_29b," +
"a.uc_30a," +
"a.uc_30a_a," +
"a.uc_30b," +
"a.uc_31a," +
"a.uc_31a_a," +
"a.uc_31b," +
"a.uc_32a," +
"a.uc_32a_a," +
"a.uc_32b," +
"a.uc_33a," +
"a.uc_33a_a," +
"a.uc_33b," +
"a.uc_34a," +
"a.uc_34a_a," +
"a.uc_34b," +
"a.uc_35a," +
"a.uc_35a_a," +
"a.uc_35b," +
"a.uc_36a," +
"a.uc_36a_a," +
"a.uc_36b," +
"a.uc_37a," +
"a.uc_37a_a," +
"a.uc_37b," +
"a.LA_17," +
"a.LA_18," +
"a.LA_19," +
"a.LA_20a_b," +
"a.LA_20a_a," +
"a.LA_20b_a," +
"a.LA_21a_b," +
"a.LA_21a_a," +
"a.LA_21b_a," +
"a.LA_22a_b," +
"a.LA_22a_a," +
"a.LA_22b_a," +
"a.LA_23a_b," +
"a.LA_23a_a," +
"a.LA_23b_a," +
"a.LA_24a_b," +
"a.LA_24a_a," +
"a.LA_24b_a," +
"a.LA_25a_b," +
"a.LA_25a_a," +
"a.LA_25b_a," +
"a.LA_26a_b," +
"a.LA_26a_a," +
"a.LA_26b_a," +
"a.LA_27a_b," +
"a.LA_27a_a," +
"a.LA_27b_a," +
"a.LA_28a_b," +
"a.LA_28a_a," +
"a.LA_28b_a," +
"a.LA_29a_b," +
"a.LA_29a_a," +
"a.LA_29b_a," +
"a.LA_30a_b," +
"a.LA_30a_a," +
"a.LA_30b_a," +
"a.LA_31a_b," +
"a.LA_31a_a," +
"a.LA_31b_a," +
"a.LA_32a_b," +
"a.LA_32a_a," +
"a.LA_32b_a," +
"a.LA_33a_b," +
"a.LA_33a_a," +
"a.LA_33b_a," +
"a.LA_34a_b," +
"a.LA_34a_a," +
"a.LA_34b_a," +
"a.LA_35a_b," +
"a.LA_35a_a," +
"a.LA_35b_a," +
"a.LA_36a_b," +
"a.LA_36a_a," +
"a.LA_36b_a," +
"a.LA_37a_b," +
"a.LA_37a_a," +
"a.LA_37b_a," +
"a.LA_38a_b," +
"a.LA_38a_a," +
"a.LA_38b_a," +
"a.LA_39a_b," +
"a.LA_39a_a," +
"a.LA_39b_a," +
"a.LA_40a_b," +
"a.LA_40a_a," +
"a.LA_40b_a," +
"a.LA_41a_b," +
"a.LA_41a_a," +
"a.LA_41b_a," +
"a.LA_42a_b," +
"a.LA_42a_a," +
"a.LA_42b_a," +
"a.LA_43a_b," +
"a.LA_43a_a," +
"a.LA_43b_a," +
"a.LA_44a_b," +
"a.LA_44a_a," +
"a.LA_44b_a," +
"a.LA_45a_b," +
"a.LA_45a_a," +
"a.LA_45b_a," +
"a.LA_46a_b," +
"a.LA_46a_a," +
"a.LA_46b_a," +
"a.LA_47a_b," +
"a.LA_47a_a," +
"a.LA_47b_a," +
"a.LA_48a_b," +
"a.LA_48a_a," +
"a.LA_48b_a," +
"a.LA_49a_b," +
"a.LA_49a_a," +
"a.LA_49b_a," +
"a.LA_50a_b," +
"a.LA_50a_a," +
"a.LA_50b_a," +
"a.LA_51a_b," +
"a.LA_51a_a," +
"a.LA_51b_a," +
"a.LA_52a_b," +
"a.LA_52a_a," +
"a.LA_52b_a" +
            " from sample_result a inner join form1 b on a.la_sno = b.AS1_screening_ID where a.la_sno = '" + ddl_screeningid.Value + "' and b.userid='usernrl'", cn.cn);
            ds = new DataSet();
            da.Fill(ds);
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Exception Error", "alert('" + ex.Message.Replace("'", "") + "')", false);
        }

        finally
        {

        }

        return ds;
    }


    protected void cmdPrintPreview_Click(object sender, EventArgs e)
    {
        dg.Visible = false;
        ReportViewer1.Visible = true;

        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("rpt_Sample.rdlc");
        DataSet ds = GetData();

        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ReportDataSource datasource = new ReportDataSource("ds", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                    ReportViewer1.Visible = true;

                    lblerr.Text = "";
                }
                else
                {
                    lblerr.Text = "No record found to preview";
                    ReportViewer1.Visible = false;
                }
            }
            else
            {
                lblerr.Text = "No record found to preview";
                ReportViewer1.Visible = false;
            }
        }
        else
        {
            lblerr.Text = "No record found to preview";
            ReportViewer1.Visible = false;
        }

    }

    protected void cmdPrint_Click(object sender, EventArgs e)
    {
        Run();
    }


    private Stream CreateStream(string name,
          string fileNameExtension, Encoding encoding,
          string mimeType, bool willSeek)
    {
        Stream stream = new MemoryStream();
        m_streams.Add(stream);
        return stream;
    }
    // Export the given report as an EMF (Enhanced Metafile) file.
    private void Export(LocalReport report)
    {
        string deviceInfo =
          @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.5in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0.25in</MarginTop>
                <MarginLeft>0.25in</MarginLeft>
                <MarginRight>0.25in</MarginRight>
                <MarginBottom>0.25in</MarginBottom>
            </DeviceInfo>";
        Warning[] warnings;
        m_streams = new List<Stream>();
        report.Render("Image", deviceInfo, CreateStream,
           out warnings);
        foreach (Stream stream in m_streams)
            stream.Position = 0;
    }
    // Handler for PrintPageEvents
    private void PrintPage(object sender, PrintPageEventArgs ev)
    {
        Metafile pageImage = new
           Metafile(m_streams[m_currentPageIndex]);

        // Adjust rectangular area with printer margins.
        Rectangle adjustedRect = new Rectangle(
            ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
            ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
            ev.PageBounds.Width,
            ev.PageBounds.Height);

        // Draw a white background for the report
        ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

        // Draw the report content
        ev.Graphics.DrawImage(pageImage, adjustedRect);

        // Prepare for the next page. Make sure we haven't hit the end.
        m_currentPageIndex++;
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
    }

    private void Print()
    {
        if (m_streams == null || m_streams.Count == 0)
            throw new Exception("Error: no stream to print.");
        PrintDocument printDoc = new PrintDocument();
        if (!printDoc.PrinterSettings.IsValid)
        {
            throw new Exception("Error: cannot find the default printer.");
        }
        else
        {
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            m_currentPageIndex = 0;
            printDoc.Print();
        }
    }
    // Create a local report for Report.rdlc, load the data,
    //    export the report to an .emf file, and print it.
    private void Run()
    {
        //LocalReport report = new LocalReport();
        //report.ReportPath = @"..\..\Report.rdlc";
        //report.DataSources.Add(
        //   new ReportDataSource("Sales", LoadSalesData()));

        Export(ReportViewer1.LocalReport);
        Print();
    }

    public void Dispose()
    {
        if (m_streams != null)
        {
            foreach (Stream stream in m_streams)
                stream.Close();
            m_streams = null;
        }
    }


    public class Demo : IDisposable
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        private DataTable LoadSalesData()
        {
            // Create a new DataSet and read sales data file 
            //    data.xml into the first DataTable.
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(@"..\..\data.xml");
            return dataSet.Tables[0];
        }
        // Routine to provide to the report renderer, in order to
        //    save an image for each page of the report.
        private Stream CreateStream(string name,
          string fileNameExtension, Encoding encoding,
          string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.5in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0.25in</MarginTop>
                <MarginLeft>0.25in</MarginLeft>
                <MarginRight>0.25in</MarginRight>
                <MarginBottom>0.25in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }
        // Create a local report for Report.rdlc, load the data,
        //    export the report to an .emf file, and print it.
        public void Run(LocalReport report)
        {
            //LocalReport report = new LocalReport();
            //report.ReportPath = @"..\..\Report.rdlc";
            //report.DataSources.Add(
            //   new ReportDataSource("Sales", LoadSalesData()));

            Export(report);
            Print();
        }

        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }

    }

    protected void dg_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))

        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
        {
            //LinkButton Btn1 = e.Row.FindControl("Label1") as LinkButton;
            //ScriptManager.GetCurrent(this.Parent.Page).RegisterAsyncPostBackControl(Btn1);
        }

        //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Edit)
        //{
        //    LinkButton Btn2 = e.Row.FindControl("Btn2 ") as LinkButton;
        //    ScriptManager.GetCurrent(this.Parent.Page).RegisterAsyncPostBackControl(Btn2);
        //}
    }
}