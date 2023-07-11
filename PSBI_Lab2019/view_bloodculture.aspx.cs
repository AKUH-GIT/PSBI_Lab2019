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
using System.ServiceModel.Activities;
using System.Activities.Expressions;
using System.Reflection.Emit;
using System.Reflection;

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
            //IsTestingServer();

            LinkButton lnkUser = (LinkButton)FindControl("usernme");
            lnkUser.Text = "Welcome: " + HttpContext.Current.Request["mycookie"].ToString();
            lnkUser.CssClass = "dropdown-toggle nav-link";
            lnkUser = null;
        }
    }


    private void IsTestingServer()
    {
        if (Server.MachineName.ToString() != "pedres2.aku.edu")
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
        if (Request.Cookies["labid"].Value == "3")
        {
            FillGrid_BloodCulture_Physician();
        }
        else
        {
            FillGrid_BloodCulture();
        }
    }



    private bool FillGrid_BloodCulture_Physician()
    {
        CConnection cn = null;
        lblerr.Text = "";

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
                qry = "select b.ID, b.id id1, a.AS1_screening_ID, a.AS1_rand_id, a.AS1_name, a.AS1_age, a.AS1_mrno, a.AS1_lno, convert(varchar(13), AS2_Q9, 103) AS2_Q9, case when rdo_BloodCulture = 1 then 'POS' else 'NEG' end rdo_BloodCulture, " +
                    " case when b.LA_03_a <> '' then b.LA_03_a when b.LA_03_a = '' then '888' when b.LA_03_a = '' then '999' end  LA_03_a, " +
                    " case when b.LA_04_a <> '' then b.LA_04_a when b.LA_04_a = '' then '888' when b.LA_04_a = '' then '999' end  LA_04_a, " +
                    " case when b.LA_05_a <> '' then b.LA_05_a when b.LA_05_a = '' then '888' when b.LA_05_a = '' then '999' end  LA_05_a, " +
                    " case when b.LA_06_a <> '' then b.LA_06_a when b.LA_06_a = '' then '888' when b.LA_06_a = '' then '999' end  LA_06_a, " +
                    " case when b.LA_07_a <> '' then b.LA_07_a when b.LA_07_a = '' then '888' when b.LA_07_a = '' then '999' end  LA_07_a, " +
                    " case when b.LA_08_a <> '' then b.LA_08_a when b.LA_08_a = '' then '888' when b.LA_08_a = '' then '999' end  LA_08_a, " +
                    " case when b.LA_09_a <> '' then b.LA_09_a when b.LA_09_a = '' then '888' when b.LA_09_a = '' then '999' end  LA_09_a, " +
                    " case when b.LA_10_a <> '' then b.LA_10_a when b.LA_10_a = '' then '888' when b.LA_10_a = '' then '999' end  LA_10_a, " +
                    " case when b.LA_11_a <> '' then b.LA_11_a when b.LA_11_a = '' then '888' when b.LA_11_a = '' then '999' end  LA_11_a, " +
                    " case when b.LA_12_a <> '' then b.LA_12_a when b.LA_12_a = '' then '888' when b.LA_12_a = '' then '999' end  LA_12_a, " +
                    " case when b.LA_13_a <> '' then b.LA_13_a when b.LA_13_a = '' then '888' when b.LA_13_a = '' then '999' end  LA_13_a, " +
                    " case when b.LA_14_a <> '' then b.LA_14_a when b.LA_14_a = '' then '888' when b.LA_14_a = '' then '999' end  LA_14_a, " +
                    " case when b.LA_15_a <> '' then b.LA_15_a when b.LA_15_a = '' then '888' when b.LA_15_a = '' then '999' end  LA_15_a, " +
                    " case when b.LA_16_a <> '' then b.LA_16_a when b.LA_16_a = '' then '888' when b.LA_16_a = '' then '999' end  LA_16_a, " +
                    " b.history, " +
                    " b.ProvisionalResult, " +
                    " case when b.rdo_BloodCulture = 1 then 'Yes' else 'No' end rdo_BloodCulture, " +
                    " case when b.ddl_BloodCulture = 1 then 'Escherichia coli' " +
                    " when b.ddl_BloodCulture = 2 then 'Klebsiella pneumoniae' " +
                    " when b.ddl_BloodCulture = 3 then 'Klebsiella species' " +
                    " when b.ddl_BloodCulture = 4 then 'Acinetobacter baumannii' " +
                    " when b.ddl_BloodCulture = 5 then 'Acinetobacter species' " +
                    " when b.ddl_BloodCulture = 6 then 'Salmonella species' " +
                    " when b.ddl_BloodCulture = 7 then 'Salmonella typhi' " +
                    " when b.ddl_BloodCulture = 8 then 'Salmonella paratyphi A' " +
                    " when b.ddl_BloodCulture = 9 then 'Salmonella paratyphi B'  " +
                    " when b.ddl_BloodCulture = 10 then 'Serratia species' " +
                    " when b.ddl_BloodCulture = 11 then 'Serratia marcescens' " +
                    " when b.ddl_BloodCulture = 12 then 'Serratia liquefaciens' " +
                    " when b.ddl_BloodCulture = 13 then 'Staphylococcus epidermidis' " +
                    " when b.ddl_BloodCulture = 14 then 'Staphylococcus saprophyticus' " +
                    " when b.ddl_BloodCulture = 15 then 'Staphylococcus species' " +
                    " when b.ddl_BloodCulture = 16 then 'Micrococcus specie' " +
                    " when b.ddl_BloodCulture = 17 then 'Streptococcus species' " +
                    " when b.ddl_BloodCulture = 18 then 'Streptococcus pyogenes (group A Streptococcus)' " +
                    " when b.ddl_BloodCulture = 19 then 'Streptococcus pneumoniae' " +
                    " when b.ddl_BloodCulture = 20 then 'Streptococcus mitis' " +
                    " when b.ddl_BloodCulture = 21 then 'Campylobacter species' " +
                    " when b.ddl_BloodCulture = 22 then 'Campylobacter jejuni' " +
                    " when b.ddl_BloodCulture = 23 then 'Enterococcus species' " +
                    " when b.ddl_BloodCulture = 24 then 'Corynebacterium species' " +
                    " when b.ddl_BloodCulture = 25 then 'Burkholderia cepacia' " +
                    " when b.ddl_BloodCulture = 26 then 'Neisseria gonorrhoeae' " +
                    " when b.ddl_BloodCulture = 27 then 'Candida species' " +
                    " when b.ddl_BloodCulture = 28 then 'Citrobacter freundii' " +
                    " when b.ddl_BloodCulture = 29 then 'Citrobacter species' " +
                    " when b.ddl_BloodCulture = 30 then 'Bacillus species' " +
                    " when b.ddl_BloodCulture = 32 then 'Others' " +
                    " end ddl_BloodCulture, " +
                    " case when b.rdo_BloodCulture_Multiple = 1 then 'Yes' when b.rdo_BloodCulture_Multiple = 2 then 'No' end BloodCulture_Multiple, " +
                    " b.LA_18, " +
                    " case when b.LA_20a_b = '' then b.LA_20a_b when b.LA_20a_b is null then b.LA_20a_b when b.LA_20a_b = '999' then 'NA' when b.LA_20a_b = '888' then 'NR' end LA_20a_b, " + "b.LA_20a_a, " +
                    " case when b.LA_20b_a = 1 then 'S' when b.LA_20b_a = 2 then 'R' when b.LA_20b_a = 3 then 'I' end LA_20b, " +
                    " case when b.LA_21a_b = '' then b.LA_21a_b when b.LA_21a_b is null then b.LA_21a_b when b.LA_21a_b = '999' then 'NA' when b.LA_21a_b = '888' then 'NR' end LA_21a_b, " +
                    " b.LA_21a_a, " +
                    " case when b.LA_21b_a = 1 then 'S' when b.LA_21b_a = 2 then 'R' when b.LA_21b_a = 3 then 'I' end LA_21b, " +
                    " case when b.LA_22a_b = '' then b.LA_22a_b when b.LA_22a_b is null then b.LA_22a_b when b.LA_22a_b = '999' then 'NA' when b.LA_22a_b = '888' then 'NR' end LA_22a_b, " +
                    " b.LA_22a_a, " +
                    " case when b.LA_22b_a = 1 then 'S' when b.LA_22b_a = 2 then 'R' when b.LA_22b_a = 3 then 'I' end LA_22b, " +
                    " case when b.LA_23a_b = '' then b.LA_23a_b when b.LA_23a_b is null then b.LA_23a_b when b.LA_23a_b = '999' then 'NA' when b.LA_23a_b = '888' then 'NR' end LA_23a_b, " +
                    " b.LA_23a_a, " +
                    " case when b.LA_23b_a = 1 then 'S' when b.LA_23b_a = 2 then 'R' when b.LA_23b_a = 3 then 'I' end LA_23b, " +
                    " case when b.LA_24a_b = '' then b.LA_24a_b when b.LA_24a_b is null then b.LA_24a_b when b.LA_24a_b = '999' then 'NA' when b.LA_24a_b = '888' then 'NR' end LA_24a_b, " +
                    " b.LA_24a_a, " +
                    " case when b.LA_24b_a = 1 then 'S' when b.LA_24b_a = 2 then 'R' when b.LA_24b_a = 3 then 'I' end LA_24b, " +
                    " case when b.LA_25a_b = '' then b.LA_25a_b when b.LA_25a_b is null then b.LA_25a_b when b.LA_25a_b = '999' then 'NA' when b.LA_25a_b = '888' then 'NR' end LA_25a_b, " +
                    " b.LA_25a_a, " +
                    " case when b.LA_25b_a = 1 then 'S' when b.LA_25b_a = 2 then 'R' when b.LA_25b_a = 3 then 'I' end LA_25b, " +
                    " case when b.LA_26a_b = '' then b.LA_26a_b when b.LA_26a_b is null then b.LA_26a_b when b.LA_26a_b = '999' then 'NA' when b.LA_26a_b = '888' then 'NR' end LA_26a_b, " +
                    " b.LA_26a_a, " +
                    " case when b.LA_26b_a = 1 then 'S' when b.LA_26b_a = 2 then 'R' when b.LA_26b_a = 3 then 'I' end LA_26b, " +
                    " case when b.LA_27a_b = '' then b.LA_27a_b when b.LA_27a_b is null then b.LA_27a_b when b.LA_27a_b = '999' then 'NA' when b.LA_27a_b = '888' then 'NR' end LA_27a_b, " +
                    " b.LA_27a_a, " +
                    " case when b.LA_27b_a = 1 then 'S' when b.LA_27b_a = 2 then 'R' when b.LA_27b_a = 3 then 'I' end LA_27b, " +
                    " case when b.LA_28a_b = '' then b.LA_28a_b when b.LA_28a_b is null then b.LA_28a_b when b.LA_28a_b = '999' then 'NA' when b.LA_28a_b = '888' then 'NR' end LA_28a_b, " +
                    " b.LA_28a_a, " +
                    " case when b.LA_28b_a = 1 then 'S' when b.LA_28b_a = 2 then 'R' when b.LA_28b_a = 3 then 'I' end LA_28b, " +
                    " case when b.LA_29a_b = '' then b.LA_29a_b when b.LA_29a_b is null then b.LA_29a_b when b.LA_29a_b = '999' then 'NA' when b.LA_29a_b = '888' then 'NR' end LA_29a_b, " +
                    " b.LA_29a_a, " +
                    " case when b.LA_29b_a = 1 then 'S' when b.LA_29b_a = 2 then 'R' when b.LA_29b_a = 3 then 'I' end LA_29b, " +
                    " case when b.LA_30a_b = '' then b.LA_30a_b when b.LA_30a_b is null then b.LA_30a_b when b.LA_30a_b = '999' then 'NA' when b.LA_30a_b = '888' then 'NR' end LA_30a_b, " +
                    " b.LA_30a_a, " +
                    " case when b.LA_30b_a = 1 then 'S' when b.LA_30b_a = 2 then 'R' when b.LA_30b_a = 3 then 'I' end LA_30b, " +
                    " case when b.LA_31a_b = '' then b.LA_31a_b when b.LA_31a_b is null then b.LA_31a_b when b.LA_31a_b = '999' then 'NA' when b.LA_31a_b = '888' then 'NR' end LA_31a_b, " +
                    " b.LA_31a_a, " +
                    " case when b.LA_31b_a = 1 then 'S' when b.LA_31b_a = 2 then 'R' when b.LA_31b_a = 3 then 'I' end LA_31b, " +
                    " case when b.LA_32a_b = '' then b.LA_32a_b when b.LA_32a_b is null then b.LA_32a_b when b.LA_32a_b = '999' then 'NA' when b.LA_32a_b = '888' then 'NR' end LA_32a_b, " +
                    " b.LA_32a_a, " +
                    " case when b.LA_32b_a = 1 then 'S' when b.LA_32b_a = 2 then 'R' when b.LA_32b_a = 3 then 'I' end LA_32b, " +
                    " case when b.LA_33a_b = '' then b.LA_33a_b when b.LA_33a_b is null then b.LA_33a_b when b.LA_33a_b = '999' then 'NA' when b.LA_33a_b = '888' then 'NR' end LA_33a_b, " +
                    " b.LA_33a_a, " +
                    " case when b.LA_33b_a = 1 then 'S' when b.LA_33b_a = 2 then 'R' when b.LA_33b_a = 3 then 'I' end LA_33b, " +
                    " case when b.LA_34a_b = '' then b.LA_34a_b when b.LA_34a_b is null then b.LA_34a_b when b.LA_34a_b = '999' then 'NA' when b.LA_34a_b = '888' then 'NR' end LA_34a_b, " +
                    " b.LA_34a_a, " +
                    " case when b.LA_34b_a = 1 then 'S' when b.LA_34b_a = 2 then 'R' when b.LA_34b_a = 3 then 'I' end LA_34b, " +
                    " case when b.LA_35a_b = '' then b.LA_35a_b when b.LA_35a_b is null then b.LA_35a_b when b.LA_35a_b = '999' then 'NA' when b.LA_35a_b = '888' then 'NR' end LA_35a_b, " +
                    " b.LA_35a_a, " +
                    " case when b.LA_35b_a = 1 then 'S' when b.LA_35b_a = 2 then 'R' when b.LA_35b_a = 3 then 'I' end LA_35b, " +
                    " case when b.LA_36a_b = '' then b.LA_36a_b when b.LA_36a_b is null then b.LA_36a_b when b.LA_36a_b = '999' then 'NA' when b.LA_36a_b = '888' then 'NR' end LA_36a_b, " +
                    " b.LA_36a_a, " +
                    " case when b.LA_36b_a = 1 then 'S' when b.LA_36b_a = 2 then 'R' when b.LA_36b_a = 3 then 'I' end LA_36b, " +
                    " case when b.LA_37a_b = '' then b.LA_37a_b when b.LA_37a_b is null then b.LA_37a_b when b.LA_37a_b = '999' then 'NA' when b.LA_37a_b = '888' then 'NR' end LA_37a_b, " +
                    " b.LA_37a_a, " +
                    " case when b.LA_37b_a = 1 then 'S' when b.LA_37b_a = 2 then 'R' when b.LA_37b_a = 3 then 'I' end LA_37b, " +
                    " case when b.LA_38a_b = '' then b.LA_38a_b when b.LA_38a_b is null then b.LA_38a_b when b.LA_38a_b = '999' then 'NA' when b.LA_38a_b = '888' then 'NR' end LA_38a_b, " +
                    " b.LA_38a_a, " +
                    " case when b.LA_38b_a = 1 then 'S' when b.LA_38b_a = 2 then 'R' when b.LA_38b_a = 3 then 'I' end LA_38b, " +
                    " case when b.LA_39a_b = '' then b.LA_39a_b when b.LA_39a_b is null then b.LA_39a_b when b.LA_39a_b = '999' then 'NA' when b.LA_39a_b = '888' then 'NR' end LA_39a_b, " +
                    " b.LA_39a_a, " +
                    " case when b.LA_39b_a = 1 then 'S' when b.LA_39b_a = 2 then 'R' when b.LA_39b_a = 3 then 'I' end LA_39b, " +
                    " case when b.LA_40a_b = '' then b.LA_40a_b when b.LA_40a_b is null then b.LA_40a_b when b.LA_40a_b = '999' then 'NA' when b.LA_40a_b = '888' then 'NR' end LA_40a_b, " +
                    " b.LA_40a_a, " +
                    " case when b.LA_40b_a = 1 then 'S' when b.LA_40b_a = 2 then 'R' when b.LA_40b_a = 3 then 'I' end LA_40b, " +
                    " case when b.LA_41a_b = '' then b.LA_41a_b when b.LA_41a_b is null then b.LA_41a_b when b.LA_41a_b = '999' then 'NA' when b.LA_41a_b = '888' then 'NR' end LA_41a_b, " +
                    " b.LA_41a_a, " +
                    " case when b.LA_41b_a = 1 then 'S' when b.LA_41b_a = 2 then 'R' when b.LA_41b_a = 3 then 'I' end LA_41b, " +
                    " case when b.LA_42a_b = '' then b.LA_42a_b when b.LA_42a_b is null then b.LA_42a_b when b.LA_42a_b = '999' then 'NA' when b.LA_42a_b = '888' then 'NR' end LA_42a_b, " +
                    " b.LA_42a_a, " +
                    " case when b.LA_42b_a = 1 then 'S' when b.LA_42b_a = 2 then 'R' when b.LA_42b_a = 3 then 'I' end LA_42b, " +
                    " case when b.LA_43a_b = '' then b.LA_43a_b when b.LA_43a_b is null then b.LA_43a_b when b.LA_43a_b = '999' then 'NA' when b.LA_43a_b = '888' then 'NR' end LA_43a_b, " +
                    " b.LA_43a_a, " +
                    " case when b.LA_43b_a = 1 then 'S' when b.LA_43b_a = 2 then 'R' when b.LA_43b_a = 3 then 'I' end LA_43b, " +
                    " case when b.LA_44a_b = '' then b.LA_44a_b when b.LA_44a_b is null then b.LA_44a_b when b.LA_44a_b = '999' then 'NA' when b.LA_44a_b = '888' then 'NR' end LA_44a_b, " +
                    " b.LA_44a_a, " +
                    " case when b.LA_44b_a = 1 then 'S' when b.LA_44b_a = 2 then 'R' when b.LA_44b_a = 3 then 'I' end LA_44b, " +
                    " case when b.LA_45a_b = '' then b.LA_45a_b when b.LA_45a_b is null then b.LA_45a_b when b.LA_45a_b = '999' then 'NA' when b.LA_45a_b = '888' then 'NR' end LA_45a_b, " +
                    " b.LA_45a_a, " +
                    " case when b.LA_45b_a = 1 then 'S' when b.LA_45b_a = 2 then 'R' when b.LA_45b_a = 3 then 'I' end LA_45b, " +
                    " case when b.LA_46a_b = '' then b.LA_46a_b when b.LA_46a_b is null then b.LA_46a_b when b.LA_46a_b = '999' then 'NA' when b.LA_46a_b = '888' then 'NR' end LA_46a_b, " +
                    " b.LA_46a_a, " +
                    " case when b.LA_46b_a = 1 then 'S' when b.LA_46b_a = 2 then 'R' when b.LA_46b_a = 3 then 'I' end LA_46b, " +
                    " case when b.LA_47a_b = '' then b.LA_47a_b when b.LA_47a_b is null then b.LA_47a_b when b.LA_47a_b = '999' then 'NA' when b.LA_47a_b = '888' then 'NR' end LA_47a_b, " +
                    " b.LA_47a_a, " +
                    " case when b.LA_47b_a = 1 then 'S' when b.LA_47b_a = 2 then 'R' when b.LA_47b_a = 3 then 'I' end LA_47b, " +
                    " case when b.LA_48a_b = '' then b.LA_48a_b when b.LA_48a_b is null then b.LA_48a_b when b.LA_48a_b = '999' then 'NA' when b.LA_48a_b = '888' then 'NR' end LA_48a_b, " +
                    " b.LA_48a_a, " +
                    " case when b.LA_48b_a = 1 then 'S' when b.LA_48b_a = 2 then 'R' when b.LA_48b_a = 3 then 'I' end LA_48b, " +
                    " case when b.LA_49a_b = '' then b.LA_49a_b when b.LA_49a_b is null then b.LA_49a_b when b.LA_49a_b = '999' then 'NA' when b.LA_49a_b = '888' then 'NR' end LA_49a_b, " +
                    " b.LA_49a_a, " +
                    " case when b.LA_49b_a = 1 then 'S' when b.LA_49b_a = 2 then 'R' when b.LA_49b_a = 3 then 'I' end LA_49b, " +
                    " case when b.LA_50a_b = '' then b.LA_50a_b when b.LA_50a_b is null then b.LA_50a_b when b.LA_50a_b = '999' then 'NA' when b.LA_50a_b = '888' then 'NR' end LA_50a_b, " +
                    " b.LA_50a_a, " +
                    " case when b.LA_50b_a = 1 then 'S' when b.LA_50b_a = 2 then 'R' when b.LA_50b_a = 3 then 'I' end LA_50b, " +
                    " case when b.LA_51a_b = '' then b.LA_51a_b when b.LA_51a_b is null then b.LA_51a_b when b.LA_51a_b = '999' then 'NA' when b.LA_51a_b = '888' then 'NR' end LA_51a_b, " +
                    " b.LA_51a_a, " +
                    " case when b.LA_51b_a = 1 then 'S' when b.LA_51b_a = 2 then 'R' when b.LA_51b_a = 3 then 'I' end LA_51b, " +
                    " case when b.LA_52a_b = '' then b.LA_52a_b when b.LA_52a_b is null then b.LA_52a_b when b.LA_52a_b = '999' then 'NA' when b.LA_52a_b = '888' then 'NR' end LA_52a_b, " +
                    " b.LA_52a_a, " +
                    " case when b.LA_52b_a = 1 then 'S' when b.LA_52b_a = 2 then 'R' when b.LA_52b_a = 3 then 'I' end LA_52b, " +
                    " (select c.LA_02 from sample_result c where c.la_sno = b.la_sno and c.labid = 2) LA_02, " +
                    " (select c.LA_02a from sample_result c where c.la_sno = b.la_sno and c.labid = 2) LA_02a " +
                    " from form1 a inner join sample_result b on a.AS1_screening_ID = b.la_sno " +
                    " where a.AS2_Q9 between '" + val_startdt + "' and '" + val_enddt + "' and a.labid = 1 and b.labid = 1 and b.rdo_BloodCulture = 1 ";
            }
            else if (!string.IsNullOrEmpty(txtStartDate.Text) && !string.IsNullOrEmpty(txtEndDate.Text) && chkBloodCulture.Checked == false)
            {
                qry = "select b.ID, b.id id1, a.AS1_screening_ID, a.AS1_rand_id, a.AS1_name, a.AS1_age, a.AS1_mrno, a.AS1_lno, convert(varchar(13), AS2_Q9, 103) AS2_Q9, case when rdo_BloodCulture = 1 then 'POS' else 'NEG' end rdo_BloodCulture, " +
                    " case when b.LA_03_a <> '' then b.LA_03_a when b.LA_03_a = '' then '888' when b.LA_03_a = '' then '999' end  LA_03_a, " +
                    " case when b.LA_04_a <> '' then b.LA_04_a when b.LA_04_a = '' then '888' when b.LA_04_a = '' then '999' end  LA_04_a, " +
                    " case when b.LA_05_a <> '' then b.LA_05_a when b.LA_05_a = '' then '888' when b.LA_05_a = '' then '999' end  LA_05_a, " +
                    " case when b.LA_06_a <> '' then b.LA_06_a when b.LA_06_a = '' then '888' when b.LA_06_a = '' then '999' end  LA_06_a, " +
                    " case when b.LA_07_a <> '' then b.LA_07_a when b.LA_07_a = '' then '888' when b.LA_07_a = '' then '999' end  LA_07_a, " +
                    " case when b.LA_08_a <> '' then b.LA_08_a when b.LA_08_a = '' then '888' when b.LA_08_a = '' then '999' end  LA_08_a, " +
                    " case when b.LA_09_a <> '' then b.LA_09_a when b.LA_09_a = '' then '888' when b.LA_09_a = '' then '999' end  LA_09_a, " +
                    " case when b.LA_10_a <> '' then b.LA_10_a when b.LA_10_a = '' then '888' when b.LA_10_a = '' then '999' end  LA_10_a, " +
                    " case when b.LA_11_a <> '' then b.LA_11_a when b.LA_11_a = '' then '888' when b.LA_11_a = '' then '999' end  LA_11_a, " +
                    " case when b.LA_12_a <> '' then b.LA_12_a when b.LA_12_a = '' then '888' when b.LA_12_a = '' then '999' end  LA_12_a, " +
                    " case when b.LA_13_a <> '' then b.LA_13_a when b.LA_13_a = '' then '888' when b.LA_13_a = '' then '999' end  LA_13_a, " +
                    " case when b.LA_14_a <> '' then b.LA_14_a when b.LA_14_a = '' then '888' when b.LA_14_a = '' then '999' end  LA_14_a, " +
                    " case when b.LA_15_a <> '' then b.LA_15_a when b.LA_15_a = '' then '888' when b.LA_15_a = '' then '999' end  LA_15_a, " +
                    " case when b.LA_16_a <> '' then b.LA_16_a when b.LA_16_a = '' then '888' when b.LA_16_a = '' then '999' end  LA_16_a, " +
                    " b.history, " +
                    " b.ProvisionalResult, " +
                    " case when b.rdo_BloodCulture = 1 then 'Yes' else 'No' end rdo_BloodCulture, " +
                    " case when b.ddl_BloodCulture = 1 then 'Escherichia coli' " +
                    " when b.ddl_BloodCulture = 2 then 'Klebsiella pneumoniae' " +
                    " when b.ddl_BloodCulture = 3 then 'Klebsiella species' " +
                    " when b.ddl_BloodCulture = 4 then 'Acinetobacter baumannii' " +
                    " when b.ddl_BloodCulture = 5 then 'Acinetobacter species' " +
                    " when b.ddl_BloodCulture = 6 then 'Salmonella species' " +
                    " when b.ddl_BloodCulture = 7 then 'Salmonella typhi' " +
                    " when b.ddl_BloodCulture = 8 then 'Salmonella paratyphi A' " +
                    " when b.ddl_BloodCulture = 9 then 'Salmonella paratyphi B'  " +
                    " when b.ddl_BloodCulture = 10 then 'Serratia species' " +
                    " when b.ddl_BloodCulture = 11 then 'Serratia marcescens' " +
                    " when b.ddl_BloodCulture = 12 then 'Serratia liquefaciens' " +
                    " when b.ddl_BloodCulture = 13 then 'Staphylococcus epidermidis' " +
                    " when b.ddl_BloodCulture = 14 then 'Staphylococcus saprophyticus' " +
                    " when b.ddl_BloodCulture = 15 then 'Staphylococcus species' " +
                    " when b.ddl_BloodCulture = 16 then 'Micrococcus specie' " +
                    " when b.ddl_BloodCulture = 17 then 'Streptococcus species' " +
                    " when b.ddl_BloodCulture = 18 then 'Streptococcus pyogenes (group A Streptococcus)' " +
                    " when b.ddl_BloodCulture = 19 then 'Streptococcus pneumoniae' " +
                    " when b.ddl_BloodCulture = 20 then 'Streptococcus mitis' " +
                    " when b.ddl_BloodCulture = 21 then 'Campylobacter species' " +
                    " when b.ddl_BloodCulture = 22 then 'Campylobacter jejuni' " +
                    " when b.ddl_BloodCulture = 23 then 'Enterococcus species' " +
                    " when b.ddl_BloodCulture = 24 then 'Corynebacterium species' " +
                    " when b.ddl_BloodCulture = 25 then 'Burkholderia cepacia' " +
                    " when b.ddl_BloodCulture = 26 then 'Neisseria gonorrhoeae' " +
                    " when b.ddl_BloodCulture = 27 then 'Candida species' " +
                    " when b.ddl_BloodCulture = 28 then 'Citrobacter freundii' " +
                    " when b.ddl_BloodCulture = 29 then 'Citrobacter species' " +
                    " when b.ddl_BloodCulture = 30 then 'Bacillus species' " +
                    " when b.ddl_BloodCulture = 32 then 'Others' " +
                    " end ddl_BloodCulture, " +
                    " case when b.rdo_BloodCulture_Multiple = 1 then 'Yes' when b.rdo_BloodCulture_Multiple = 2 then 'No' end BloodCulture_Multiple, " +
                    " b.LA_18, " +
                    " case when b.LA_20a_b = '' then b.LA_20a_b when b.LA_20a_b is null then b.LA_20a_b when b.LA_20a_b = '999' then 'NA' when b.LA_20a_b = '888' then 'NR' end LA_20a_b, " + "b.LA_20a_a, " +
                    " case when b.LA_20b_a = 1 then 'S' when b.LA_20b_a = 2 then 'R' when b.LA_20b_a = 3 then 'I' end LA_20b, " +
                    " case when b.LA_21a_b = '' then b.LA_21a_b when b.LA_21a_b is null then b.LA_21a_b when b.LA_21a_b = '999' then 'NA' when b.LA_21a_b = '888' then 'NR' end LA_21a_b, " +
                    " b.LA_21a_a, " +
                    " case when b.LA_21b_a = 1 then 'S' when b.LA_21b_a = 2 then 'R' when b.LA_21b_a = 3 then 'I' end LA_21b, " +
                    " case when b.LA_22a_b = '' then b.LA_22a_b when b.LA_22a_b is null then b.LA_22a_b when b.LA_22a_b = '999' then 'NA' when b.LA_22a_b = '888' then 'NR' end LA_22a_b, " +
                    " b.LA_22a_a, " +
                    " case when b.LA_22b_a = 1 then 'S' when b.LA_22b_a = 2 then 'R' when b.LA_22b_a = 3 then 'I' end LA_22b, " +
                    " case when b.LA_23a_b = '' then b.LA_23a_b when b.LA_23a_b is null then b.LA_23a_b when b.LA_23a_b = '999' then 'NA' when b.LA_23a_b = '888' then 'NR' end LA_23a_b, " +
                    " b.LA_23a_a, " +
                    " case when b.LA_23b_a = 1 then 'S' when b.LA_23b_a = 2 then 'R' when b.LA_23b_a = 3 then 'I' end LA_23b, " +
                    " case when b.LA_24a_b = '' then b.LA_24a_b when b.LA_24a_b is null then b.LA_24a_b when b.LA_24a_b = '999' then 'NA' when b.LA_24a_b = '888' then 'NR' end LA_24a_b, " +
                    " b.LA_24a_a, " +
                    " case when b.LA_24b_a = 1 then 'S' when b.LA_24b_a = 2 then 'R' when b.LA_24b_a = 3 then 'I' end LA_24b, " +
                    " case when b.LA_25a_b = '' then b.LA_25a_b when b.LA_25a_b is null then b.LA_25a_b when b.LA_25a_b = '999' then 'NA' when b.LA_25a_b = '888' then 'NR' end LA_25a_b, " +
                    " b.LA_25a_a, " +
                    " case when b.LA_25b_a = 1 then 'S' when b.LA_25b_a = 2 then 'R' when b.LA_25b_a = 3 then 'I' end LA_25b, " +
                    " case when b.LA_26a_b = '' then b.LA_26a_b when b.LA_26a_b is null then b.LA_26a_b when b.LA_26a_b = '999' then 'NA' when b.LA_26a_b = '888' then 'NR' end LA_26a_b, " +
                    " b.LA_26a_a, " +
                    " case when b.LA_26b_a = 1 then 'S' when b.LA_26b_a = 2 then 'R' when b.LA_26b_a = 3 then 'I' end LA_26b, " +
                    " case when b.LA_27a_b = '' then b.LA_27a_b when b.LA_27a_b is null then b.LA_27a_b when b.LA_27a_b = '999' then 'NA' when b.LA_27a_b = '888' then 'NR' end LA_27a_b, " +
                    " b.LA_27a_a, " +
                    " case when b.LA_27b_a = 1 then 'S' when b.LA_27b_a = 2 then 'R' when b.LA_27b_a = 3 then 'I' end LA_27b, " +
                    " case when b.LA_28a_b = '' then b.LA_28a_b when b.LA_28a_b is null then b.LA_28a_b when b.LA_28a_b = '999' then 'NA' when b.LA_28a_b = '888' then 'NR' end LA_28a_b, " +
                    " b.LA_28a_a, " +
                    " case when b.LA_28b_a = 1 then 'S' when b.LA_28b_a = 2 then 'R' when b.LA_28b_a = 3 then 'I' end LA_28b, " +
                    " case when b.LA_29a_b = '' then b.LA_29a_b when b.LA_29a_b is null then b.LA_29a_b when b.LA_29a_b = '999' then 'NA' when b.LA_29a_b = '888' then 'NR' end LA_29a_b, " +
                    " b.LA_29a_a, " +
                    " case when b.LA_29b_a = 1 then 'S' when b.LA_29b_a = 2 then 'R' when b.LA_29b_a = 3 then 'I' end LA_29b, " +
                    " case when b.LA_30a_b = '' then b.LA_30a_b when b.LA_30a_b is null then b.LA_30a_b when b.LA_30a_b = '999' then 'NA' when b.LA_30a_b = '888' then 'NR' end LA_30a_b, " +
                    " b.LA_30a_a, " +
                    " case when b.LA_30b_a = 1 then 'S' when b.LA_30b_a = 2 then 'R' when b.LA_30b_a = 3 then 'I' end LA_30b, " +
                    " case when b.LA_31a_b = '' then b.LA_31a_b when b.LA_31a_b is null then b.LA_31a_b when b.LA_31a_b = '999' then 'NA' when b.LA_31a_b = '888' then 'NR' end LA_31a_b, " +
                    " b.LA_31a_a, " +
                    " case when b.LA_31b_a = 1 then 'S' when b.LA_31b_a = 2 then 'R' when b.LA_31b_a = 3 then 'I' end LA_31b, " +
                    " case when b.LA_32a_b = '' then b.LA_32a_b when b.LA_32a_b is null then b.LA_32a_b when b.LA_32a_b = '999' then 'NA' when b.LA_32a_b = '888' then 'NR' end LA_32a_b, " +
                    " b.LA_32a_a, " +
                    " case when b.LA_32b_a = 1 then 'S' when b.LA_32b_a = 2 then 'R' when b.LA_32b_a = 3 then 'I' end LA_32b, " +
                    " case when b.LA_33a_b = '' then b.LA_33a_b when b.LA_33a_b is null then b.LA_33a_b when b.LA_33a_b = '999' then 'NA' when b.LA_33a_b = '888' then 'NR' end LA_33a_b, " +
                    " b.LA_33a_a, " +
                    " case when b.LA_33b_a = 1 then 'S' when b.LA_33b_a = 2 then 'R' when b.LA_33b_a = 3 then 'I' end LA_33b, " +
                    " case when b.LA_34a_b = '' then b.LA_34a_b when b.LA_34a_b is null then b.LA_34a_b when b.LA_34a_b = '999' then 'NA' when b.LA_34a_b = '888' then 'NR' end LA_34a_b, " +
                    " b.LA_34a_a, " +
                    " case when b.LA_34b_a = 1 then 'S' when b.LA_34b_a = 2 then 'R' when b.LA_34b_a = 3 then 'I' end LA_34b, " +
                    " case when b.LA_35a_b = '' then b.LA_35a_b when b.LA_35a_b is null then b.LA_35a_b when b.LA_35a_b = '999' then 'NA' when b.LA_35a_b = '888' then 'NR' end LA_35a_b, " +
                    " b.LA_35a_a, " +
                    " case when b.LA_35b_a = 1 then 'S' when b.LA_35b_a = 2 then 'R' when b.LA_35b_a = 3 then 'I' end LA_35b, " +
                    " case when b.LA_36a_b = '' then b.LA_36a_b when b.LA_36a_b is null then b.LA_36a_b when b.LA_36a_b = '999' then 'NA' when b.LA_36a_b = '888' then 'NR' end LA_36a_b, " +
                    " b.LA_36a_a, " +
                    " case when b.LA_36b_a = 1 then 'S' when b.LA_36b_a = 2 then 'R' when b.LA_36b_a = 3 then 'I' end LA_36b, " +
                    " case when b.LA_37a_b = '' then b.LA_37a_b when b.LA_37a_b is null then b.LA_37a_b when b.LA_37a_b = '999' then 'NA' when b.LA_37a_b = '888' then 'NR' end LA_37a_b, " +
                    " b.LA_37a_a, " +
                    " case when b.LA_37b_a = 1 then 'S' when b.LA_37b_a = 2 then 'R' when b.LA_37b_a = 3 then 'I' end LA_37b, " +
                    " case when b.LA_38a_b = '' then b.LA_38a_b when b.LA_38a_b is null then b.LA_38a_b when b.LA_38a_b = '999' then 'NA' when b.LA_38a_b = '888' then 'NR' end LA_38a_b, " +
                    " b.LA_38a_a, " +
                    " case when b.LA_38b_a = 1 then 'S' when b.LA_38b_a = 2 then 'R' when b.LA_38b_a = 3 then 'I' end LA_38b, " +
                    " case when b.LA_39a_b = '' then b.LA_39a_b when b.LA_39a_b is null then b.LA_39a_b when b.LA_39a_b = '999' then 'NA' when b.LA_39a_b = '888' then 'NR' end LA_39a_b, " +
                    " b.LA_39a_a, " +
                    " case when b.LA_39b_a = 1 then 'S' when b.LA_39b_a = 2 then 'R' when b.LA_39b_a = 3 then 'I' end LA_39b, " +
                    " case when b.LA_40a_b = '' then b.LA_40a_b when b.LA_40a_b is null then b.LA_40a_b when b.LA_40a_b = '999' then 'NA' when b.LA_40a_b = '888' then 'NR' end LA_40a_b, " +
                    " b.LA_40a_a, " +
                    " case when b.LA_40b_a = 1 then 'S' when b.LA_40b_a = 2 then 'R' when b.LA_40b_a = 3 then 'I' end LA_40b, " +
                    " case when b.LA_41a_b = '' then b.LA_41a_b when b.LA_41a_b is null then b.LA_41a_b when b.LA_41a_b = '999' then 'NA' when b.LA_41a_b = '888' then 'NR' end LA_41a_b, " +
                    " b.LA_41a_a, " +
                    " case when b.LA_41b_a = 1 then 'S' when b.LA_41b_a = 2 then 'R' when b.LA_41b_a = 3 then 'I' end LA_41b, " +
                    " case when b.LA_42a_b = '' then b.LA_42a_b when b.LA_42a_b is null then b.LA_42a_b when b.LA_42a_b = '999' then 'NA' when b.LA_42a_b = '888' then 'NR' end LA_42a_b, " +
                    " b.LA_42a_a, " +
                    " case when b.LA_42b_a = 1 then 'S' when b.LA_42b_a = 2 then 'R' when b.LA_42b_a = 3 then 'I' end LA_42b, " +
                    " case when b.LA_43a_b = '' then b.LA_43a_b when b.LA_43a_b is null then b.LA_43a_b when b.LA_43a_b = '999' then 'NA' when b.LA_43a_b = '888' then 'NR' end LA_43a_b, " +
                    " b.LA_43a_a, " +
                    " case when b.LA_43b_a = 1 then 'S' when b.LA_43b_a = 2 then 'R' when b.LA_43b_a = 3 then 'I' end LA_43b, " +
                    " case when b.LA_44a_b = '' then b.LA_44a_b when b.LA_44a_b is null then b.LA_44a_b when b.LA_44a_b = '999' then 'NA' when b.LA_44a_b = '888' then 'NR' end LA_44a_b, " +
                    " b.LA_44a_a, " +
                    " case when b.LA_44b_a = 1 then 'S' when b.LA_44b_a = 2 then 'R' when b.LA_44b_a = 3 then 'I' end LA_44b, " +
                    " case when b.LA_45a_b = '' then b.LA_45a_b when b.LA_45a_b is null then b.LA_45a_b when b.LA_45a_b = '999' then 'NA' when b.LA_45a_b = '888' then 'NR' end LA_45a_b, " +
                    " b.LA_45a_a, " +
                    " case when b.LA_45b_a = 1 then 'S' when b.LA_45b_a = 2 then 'R' when b.LA_45b_a = 3 then 'I' end LA_45b, " +
                    " case when b.LA_46a_b = '' then b.LA_46a_b when b.LA_46a_b is null then b.LA_46a_b when b.LA_46a_b = '999' then 'NA' when b.LA_46a_b = '888' then 'NR' end LA_46a_b, " +
                    " b.LA_46a_a, " +
                    " case when b.LA_46b_a = 1 then 'S' when b.LA_46b_a = 2 then 'R' when b.LA_46b_a = 3 then 'I' end LA_46b, " +
                    " case when b.LA_47a_b = '' then b.LA_47a_b when b.LA_47a_b is null then b.LA_47a_b when b.LA_47a_b = '999' then 'NA' when b.LA_47a_b = '888' then 'NR' end LA_47a_b, " +
                    " b.LA_47a_a, " +
                    " case when b.LA_47b_a = 1 then 'S' when b.LA_47b_a = 2 then 'R' when b.LA_47b_a = 3 then 'I' end LA_47b, " +
                    " case when b.LA_48a_b = '' then b.LA_48a_b when b.LA_48a_b is null then b.LA_48a_b when b.LA_48a_b = '999' then 'NA' when b.LA_48a_b = '888' then 'NR' end LA_48a_b, " +
                    " b.LA_48a_a, " +
                    " case when b.LA_48b_a = 1 then 'S' when b.LA_48b_a = 2 then 'R' when b.LA_48b_a = 3 then 'I' end LA_48b, " +
                    " case when b.LA_49a_b = '' then b.LA_49a_b when b.LA_49a_b is null then b.LA_49a_b when b.LA_49a_b = '999' then 'NA' when b.LA_49a_b = '888' then 'NR' end LA_49a_b, " +
                    " b.LA_49a_a, " +
                    " case when b.LA_49b_a = 1 then 'S' when b.LA_49b_a = 2 then 'R' when b.LA_49b_a = 3 then 'I' end LA_49b, " +
                    " case when b.LA_50a_b = '' then b.LA_50a_b when b.LA_50a_b is null then b.LA_50a_b when b.LA_50a_b = '999' then 'NA' when b.LA_50a_b = '888' then 'NR' end LA_50a_b, " +
                    " b.LA_50a_a, " +
                    " case when b.LA_50b_a = 1 then 'S' when b.LA_50b_a = 2 then 'R' when b.LA_50b_a = 3 then 'I' end LA_50b, " +
                    " case when b.LA_51a_b = '' then b.LA_51a_b when b.LA_51a_b is null then b.LA_51a_b when b.LA_51a_b = '999' then 'NA' when b.LA_51a_b = '888' then 'NR' end LA_51a_b, " +
                    " b.LA_51a_a, " +
                    " case when b.LA_51b_a = 1 then 'S' when b.LA_51b_a = 2 then 'R' when b.LA_51b_a = 3 then 'I' end LA_51b, " +
                    " case when b.LA_52a_b = '' then b.LA_52a_b when b.LA_52a_b is null then b.LA_52a_b when b.LA_52a_b = '999' then 'NA' when b.LA_52a_b = '888' then 'NR' end LA_52a_b, " +
                    " b.LA_52a_a, " +
                    " case when b.LA_52b_a = 1 then 'S' when b.LA_52b_a = 2 then 'R' when b.LA_52b_a = 3 then 'I' end LA_52b, " +
                    " (select c.LA_02 from sample_result c where c.la_sno = b.la_sno and c.labid = 2) LA_02, " +
                    " (select c.LA_02a from sample_result c where c.la_sno = b.la_sno and c.labid = 2) LA_02a " +
                    " from form1 a inner join sample_result b on a.AS1_screening_ID = b.la_sno " +
                    " where a.AS2_Q9 between '" + val_startdt + "' and '" + val_enddt + "' and a.labid = 1 and b.labid = 1 and b.rdo_BloodCulture = 2 ";
            }
            else if (string.IsNullOrEmpty(txtStartDate.Text) && string.IsNullOrEmpty(txtEndDate.Text) && chkBloodCulture.Checked == true)
            {
                qry = "select b.ID, b.id id1, a.AS1_screening_ID, a.AS1_rand_id, a.AS1_name, a.AS1_age, a.AS1_mrno, a.AS1_lno, convert(varchar(13), AS2_Q9, 103) AS2_Q9, case when rdo_BloodCulture = 1 then 'POS' else 'NEG' end rdo_BloodCulture, " +
                    " case when b.LA_03_a <> '' then b.LA_03_a when b.LA_03_a = '' then '888' when b.LA_03_a = '' then '999' end  LA_03_a, " +
                    " case when b.LA_04_a <> '' then b.LA_04_a when b.LA_04_a = '' then '888' when b.LA_04_a = '' then '999' end  LA_04_a, " +
                    " case when b.LA_05_a <> '' then b.LA_05_a when b.LA_05_a = '' then '888' when b.LA_05_a = '' then '999' end  LA_05_a, " +
                    " case when b.LA_06_a <> '' then b.LA_06_a when b.LA_06_a = '' then '888' when b.LA_06_a = '' then '999' end  LA_06_a, " +
                    " case when b.LA_07_a <> '' then b.LA_07_a when b.LA_07_a = '' then '888' when b.LA_07_a = '' then '999' end  LA_07_a, " +
                    " case when b.LA_08_a <> '' then b.LA_08_a when b.LA_08_a = '' then '888' when b.LA_08_a = '' then '999' end  LA_08_a, " +
                    " case when b.LA_09_a <> '' then b.LA_09_a when b.LA_09_a = '' then '888' when b.LA_09_a = '' then '999' end  LA_09_a, " +
                    " case when b.LA_10_a <> '' then b.LA_10_a when b.LA_10_a = '' then '888' when b.LA_10_a = '' then '999' end  LA_10_a, " +
                    " case when b.LA_11_a <> '' then b.LA_11_a when b.LA_11_a = '' then '888' when b.LA_11_a = '' then '999' end  LA_11_a, " +
                    " case when b.LA_12_a <> '' then b.LA_12_a when b.LA_12_a = '' then '888' when b.LA_12_a = '' then '999' end  LA_12_a, " +
                    " case when b.LA_13_a <> '' then b.LA_13_a when b.LA_13_a = '' then '888' when b.LA_13_a = '' then '999' end  LA_13_a, " +
                    " case when b.LA_14_a <> '' then b.LA_14_a when b.LA_14_a = '' then '888' when b.LA_14_a = '' then '999' end  LA_14_a, " +
                    " case when b.LA_15_a <> '' then b.LA_15_a when b.LA_15_a = '' then '888' when b.LA_15_a = '' then '999' end  LA_15_a, " +
                    " case when b.LA_16_a <> '' then b.LA_16_a when b.LA_16_a = '' then '888' when b.LA_16_a = '' then '999' end  LA_16_a, " +
                    " b.history, " +
                    " b.ProvisionalResult, " +
                    " case when b.rdo_BloodCulture = 1 then 'Yes' else 'No' end rdo_BloodCulture, " +
                    " case when b.ddl_BloodCulture = 1 then 'Escherichia coli' " +
                    " when b.ddl_BloodCulture = 2 then 'Klebsiella pneumoniae' " +
                    " when b.ddl_BloodCulture = 3 then 'Klebsiella species' " +
                    " when b.ddl_BloodCulture = 4 then 'Acinetobacter baumannii' " +
                    " when b.ddl_BloodCulture = 5 then 'Acinetobacter species' " +
                    " when b.ddl_BloodCulture = 6 then 'Salmonella species' " +
                    " when b.ddl_BloodCulture = 7 then 'Salmonella typhi' " +
                    " when b.ddl_BloodCulture = 8 then 'Salmonella paratyphi A' " +
                    " when b.ddl_BloodCulture = 9 then 'Salmonella paratyphi B'  " +
                    " when b.ddl_BloodCulture = 10 then 'Serratia species' " +
                    " when b.ddl_BloodCulture = 11 then 'Serratia marcescens' " +
                    " when b.ddl_BloodCulture = 12 then 'Serratia liquefaciens' " +
                    " when b.ddl_BloodCulture = 13 then 'Staphylococcus epidermidis' " +
                    " when b.ddl_BloodCulture = 14 then 'Staphylococcus saprophyticus' " +
                    " when b.ddl_BloodCulture = 15 then 'Staphylococcus species' " +
                    " when b.ddl_BloodCulture = 16 then 'Micrococcus specie' " +
                    " when b.ddl_BloodCulture = 17 then 'Streptococcus species' " +
                    " when b.ddl_BloodCulture = 18 then 'Streptococcus pyogenes (group A Streptococcus)' " +
                    " when b.ddl_BloodCulture = 19 then 'Streptococcus pneumoniae' " +
                    " when b.ddl_BloodCulture = 20 then 'Streptococcus mitis' " +
                    " when b.ddl_BloodCulture = 21 then 'Campylobacter species' " +
                    " when b.ddl_BloodCulture = 22 then 'Campylobacter jejuni' " +
                    " when b.ddl_BloodCulture = 23 then 'Enterococcus species' " +
                    " when b.ddl_BloodCulture = 24 then 'Corynebacterium species' " +
                    " when b.ddl_BloodCulture = 25 then 'Burkholderia cepacia' " +
                    " when b.ddl_BloodCulture = 26 then 'Neisseria gonorrhoeae' " +
                    " when b.ddl_BloodCulture = 27 then 'Candida species' " +
                    " when b.ddl_BloodCulture = 28 then 'Citrobacter freundii' " +
                    " when b.ddl_BloodCulture = 29 then 'Citrobacter species' " +
                    " when b.ddl_BloodCulture = 30 then 'Bacillus species' " +
                    " when b.ddl_BloodCulture = 32 then 'Others' " +
                    " end ddl_BloodCulture, " +
                    " case when b.rdo_BloodCulture_Multiple = 1 then 'Yes' when b.rdo_BloodCulture_Multiple = 2 then 'No' end BloodCulture_Multiple, " +
                    " b.LA_18, " +
                    " case when b.LA_20a_b = '' then b.LA_20a_b when b.LA_20a_b is null then b.LA_20a_b when b.LA_20a_b = '999' then 'NA' when b.LA_20a_b = '888' then 'NR' end LA_20a_b, " + "b.LA_20a_a, " +
                    " case when b.LA_20b_a = 1 then 'S' when b.LA_20b_a = 2 then 'R' when b.LA_20b_a = 3 then 'I' end LA_20b, " +
                    " case when b.LA_21a_b = '' then b.LA_21a_b when b.LA_21a_b is null then b.LA_21a_b when b.LA_21a_b = '999' then 'NA' when b.LA_21a_b = '888' then 'NR' end LA_21a_b, " +
                    " b.LA_21a_a, " +
                    " case when b.LA_21b_a = 1 then 'S' when b.LA_21b_a = 2 then 'R' when b.LA_21b_a = 3 then 'I' end LA_21b, " +
                    " case when b.LA_22a_b = '' then b.LA_22a_b when b.LA_22a_b is null then b.LA_22a_b when b.LA_22a_b = '999' then 'NA' when b.LA_22a_b = '888' then 'NR' end LA_22a_b, " +
                    " b.LA_22a_a, " +
                    " case when b.LA_22b_a = 1 then 'S' when b.LA_22b_a = 2 then 'R' when b.LA_22b_a = 3 then 'I' end LA_22b, " +
                    " case when b.LA_23a_b = '' then b.LA_23a_b when b.LA_23a_b is null then b.LA_23a_b when b.LA_23a_b = '999' then 'NA' when b.LA_23a_b = '888' then 'NR' end LA_23a_b, " +
                    " b.LA_23a_a, " +
                    " case when b.LA_23b_a = 1 then 'S' when b.LA_23b_a = 2 then 'R' when b.LA_23b_a = 3 then 'I' end LA_23b, " +
                    " case when b.LA_24a_b = '' then b.LA_24a_b when b.LA_24a_b is null then b.LA_24a_b when b.LA_24a_b = '999' then 'NA' when b.LA_24a_b = '888' then 'NR' end LA_24a_b, " +
                    " b.LA_24a_a, " +
                    " case when b.LA_24b_a = 1 then 'S' when b.LA_24b_a = 2 then 'R' when b.LA_24b_a = 3 then 'I' end LA_24b, " +
                    " case when b.LA_25a_b = '' then b.LA_25a_b when b.LA_25a_b is null then b.LA_25a_b when b.LA_25a_b = '999' then 'NA' when b.LA_25a_b = '888' then 'NR' end LA_25a_b, " +
                    " b.LA_25a_a, " +
                    " case when b.LA_25b_a = 1 then 'S' when b.LA_25b_a = 2 then 'R' when b.LA_25b_a = 3 then 'I' end LA_25b, " +
                    " case when b.LA_26a_b = '' then b.LA_26a_b when b.LA_26a_b is null then b.LA_26a_b when b.LA_26a_b = '999' then 'NA' when b.LA_26a_b = '888' then 'NR' end LA_26a_b, " +
                    " b.LA_26a_a, " +
                    " case when b.LA_26b_a = 1 then 'S' when b.LA_26b_a = 2 then 'R' when b.LA_26b_a = 3 then 'I' end LA_26b, " +
                    " case when b.LA_27a_b = '' then b.LA_27a_b when b.LA_27a_b is null then b.LA_27a_b when b.LA_27a_b = '999' then 'NA' when b.LA_27a_b = '888' then 'NR' end LA_27a_b, " +
                    " b.LA_27a_a, " +
                    " case when b.LA_27b_a = 1 then 'S' when b.LA_27b_a = 2 then 'R' when b.LA_27b_a = 3 then 'I' end LA_27b, " +
                    " case when b.LA_28a_b = '' then b.LA_28a_b when b.LA_28a_b is null then b.LA_28a_b when b.LA_28a_b = '999' then 'NA' when b.LA_28a_b = '888' then 'NR' end LA_28a_b, " +
                    " b.LA_28a_a, " +
                    " case when b.LA_28b_a = 1 then 'S' when b.LA_28b_a = 2 then 'R' when b.LA_28b_a = 3 then 'I' end LA_28b, " +
                    " case when b.LA_29a_b = '' then b.LA_29a_b when b.LA_29a_b is null then b.LA_29a_b when b.LA_29a_b = '999' then 'NA' when b.LA_29a_b = '888' then 'NR' end LA_29a_b, " +
                    " b.LA_29a_a, " +
                    " case when b.LA_29b_a = 1 then 'S' when b.LA_29b_a = 2 then 'R' when b.LA_29b_a = 3 then 'I' end LA_29b, " +
                    " case when b.LA_30a_b = '' then b.LA_30a_b when b.LA_30a_b is null then b.LA_30a_b when b.LA_30a_b = '999' then 'NA' when b.LA_30a_b = '888' then 'NR' end LA_30a_b, " +
                    " b.LA_30a_a, " +
                    " case when b.LA_30b_a = 1 then 'S' when b.LA_30b_a = 2 then 'R' when b.LA_30b_a = 3 then 'I' end LA_30b, " +
                    " case when b.LA_31a_b = '' then b.LA_31a_b when b.LA_31a_b is null then b.LA_31a_b when b.LA_31a_b = '999' then 'NA' when b.LA_31a_b = '888' then 'NR' end LA_31a_b, " +
                    " b.LA_31a_a, " +
                    " case when b.LA_31b_a = 1 then 'S' when b.LA_31b_a = 2 then 'R' when b.LA_31b_a = 3 then 'I' end LA_31b, " +
                    " case when b.LA_32a_b = '' then b.LA_32a_b when b.LA_32a_b is null then b.LA_32a_b when b.LA_32a_b = '999' then 'NA' when b.LA_32a_b = '888' then 'NR' end LA_32a_b, " +
                    " b.LA_32a_a, " +
                    " case when b.LA_32b_a = 1 then 'S' when b.LA_32b_a = 2 then 'R' when b.LA_32b_a = 3 then 'I' end LA_32b, " +
                    " case when b.LA_33a_b = '' then b.LA_33a_b when b.LA_33a_b is null then b.LA_33a_b when b.LA_33a_b = '999' then 'NA' when b.LA_33a_b = '888' then 'NR' end LA_33a_b, " +
                    " b.LA_33a_a, " +
                    " case when b.LA_33b_a = 1 then 'S' when b.LA_33b_a = 2 then 'R' when b.LA_33b_a = 3 then 'I' end LA_33b, " +
                    " case when b.LA_34a_b = '' then b.LA_34a_b when b.LA_34a_b is null then b.LA_34a_b when b.LA_34a_b = '999' then 'NA' when b.LA_34a_b = '888' then 'NR' end LA_34a_b, " +
                    " b.LA_34a_a, " +
                    " case when b.LA_34b_a = 1 then 'S' when b.LA_34b_a = 2 then 'R' when b.LA_34b_a = 3 then 'I' end LA_34b, " +
                    " case when b.LA_35a_b = '' then b.LA_35a_b when b.LA_35a_b is null then b.LA_35a_b when b.LA_35a_b = '999' then 'NA' when b.LA_35a_b = '888' then 'NR' end LA_35a_b, " +
                    " b.LA_35a_a, " +
                    " case when b.LA_35b_a = 1 then 'S' when b.LA_35b_a = 2 then 'R' when b.LA_35b_a = 3 then 'I' end LA_35b, " +
                    " case when b.LA_36a_b = '' then b.LA_36a_b when b.LA_36a_b is null then b.LA_36a_b when b.LA_36a_b = '999' then 'NA' when b.LA_36a_b = '888' then 'NR' end LA_36a_b, " +
                    " b.LA_36a_a, " +
                    " case when b.LA_36b_a = 1 then 'S' when b.LA_36b_a = 2 then 'R' when b.LA_36b_a = 3 then 'I' end LA_36b, " +
                    " case when b.LA_37a_b = '' then b.LA_37a_b when b.LA_37a_b is null then b.LA_37a_b when b.LA_37a_b = '999' then 'NA' when b.LA_37a_b = '888' then 'NR' end LA_37a_b, " +
                    " b.LA_37a_a, " +
                    " case when b.LA_37b_a = 1 then 'S' when b.LA_37b_a = 2 then 'R' when b.LA_37b_a = 3 then 'I' end LA_37b, " +
                    " case when b.LA_38a_b = '' then b.LA_38a_b when b.LA_38a_b is null then b.LA_38a_b when b.LA_38a_b = '999' then 'NA' when b.LA_38a_b = '888' then 'NR' end LA_38a_b, " +
                    " b.LA_38a_a, " +
                    " case when b.LA_38b_a = 1 then 'S' when b.LA_38b_a = 2 then 'R' when b.LA_38b_a = 3 then 'I' end LA_38b, " +
                    " case when b.LA_39a_b = '' then b.LA_39a_b when b.LA_39a_b is null then b.LA_39a_b when b.LA_39a_b = '999' then 'NA' when b.LA_39a_b = '888' then 'NR' end LA_39a_b, " +
                    " b.LA_39a_a, " +
                    " case when b.LA_39b_a = 1 then 'S' when b.LA_39b_a = 2 then 'R' when b.LA_39b_a = 3 then 'I' end LA_39b, " +
                    " case when b.LA_40a_b = '' then b.LA_40a_b when b.LA_40a_b is null then b.LA_40a_b when b.LA_40a_b = '999' then 'NA' when b.LA_40a_b = '888' then 'NR' end LA_40a_b, " +
                    " b.LA_40a_a, " +
                    " case when b.LA_40b_a = 1 then 'S' when b.LA_40b_a = 2 then 'R' when b.LA_40b_a = 3 then 'I' end LA_40b, " +
                    " case when b.LA_41a_b = '' then b.LA_41a_b when b.LA_41a_b is null then b.LA_41a_b when b.LA_41a_b = '999' then 'NA' when b.LA_41a_b = '888' then 'NR' end LA_41a_b, " +
                    " b.LA_41a_a, " +
                    " case when b.LA_41b_a = 1 then 'S' when b.LA_41b_a = 2 then 'R' when b.LA_41b_a = 3 then 'I' end LA_41b, " +
                    " case when b.LA_42a_b = '' then b.LA_42a_b when b.LA_42a_b is null then b.LA_42a_b when b.LA_42a_b = '999' then 'NA' when b.LA_42a_b = '888' then 'NR' end LA_42a_b, " +
                    " b.LA_42a_a, " +
                    " case when b.LA_42b_a = 1 then 'S' when b.LA_42b_a = 2 then 'R' when b.LA_42b_a = 3 then 'I' end LA_42b, " +
                    " case when b.LA_43a_b = '' then b.LA_43a_b when b.LA_43a_b is null then b.LA_43a_b when b.LA_43a_b = '999' then 'NA' when b.LA_43a_b = '888' then 'NR' end LA_43a_b, " +
                    " b.LA_43a_a, " +
                    " case when b.LA_43b_a = 1 then 'S' when b.LA_43b_a = 2 then 'R' when b.LA_43b_a = 3 then 'I' end LA_43b, " +
                    " case when b.LA_44a_b = '' then b.LA_44a_b when b.LA_44a_b is null then b.LA_44a_b when b.LA_44a_b = '999' then 'NA' when b.LA_44a_b = '888' then 'NR' end LA_44a_b, " +
                    " b.LA_44a_a, " +
                    " case when b.LA_44b_a = 1 then 'S' when b.LA_44b_a = 2 then 'R' when b.LA_44b_a = 3 then 'I' end LA_44b, " +
                    " case when b.LA_45a_b = '' then b.LA_45a_b when b.LA_45a_b is null then b.LA_45a_b when b.LA_45a_b = '999' then 'NA' when b.LA_45a_b = '888' then 'NR' end LA_45a_b, " +
                    " b.LA_45a_a, " +
                    " case when b.LA_45b_a = 1 then 'S' when b.LA_45b_a = 2 then 'R' when b.LA_45b_a = 3 then 'I' end LA_45b, " +
                    " case when b.LA_46a_b = '' then b.LA_46a_b when b.LA_46a_b is null then b.LA_46a_b when b.LA_46a_b = '999' then 'NA' when b.LA_46a_b = '888' then 'NR' end LA_46a_b, " +
                    " b.LA_46a_a, " +
                    " case when b.LA_46b_a = 1 then 'S' when b.LA_46b_a = 2 then 'R' when b.LA_46b_a = 3 then 'I' end LA_46b, " +
                    " case when b.LA_47a_b = '' then b.LA_47a_b when b.LA_47a_b is null then b.LA_47a_b when b.LA_47a_b = '999' then 'NA' when b.LA_47a_b = '888' then 'NR' end LA_47a_b, " +
                    " b.LA_47a_a, " +
                    " case when b.LA_47b_a = 1 then 'S' when b.LA_47b_a = 2 then 'R' when b.LA_47b_a = 3 then 'I' end LA_47b, " +
                    " case when b.LA_48a_b = '' then b.LA_48a_b when b.LA_48a_b is null then b.LA_48a_b when b.LA_48a_b = '999' then 'NA' when b.LA_48a_b = '888' then 'NR' end LA_48a_b, " +
                    " b.LA_48a_a, " +
                    " case when b.LA_48b_a = 1 then 'S' when b.LA_48b_a = 2 then 'R' when b.LA_48b_a = 3 then 'I' end LA_48b, " +
                    " case when b.LA_49a_b = '' then b.LA_49a_b when b.LA_49a_b is null then b.LA_49a_b when b.LA_49a_b = '999' then 'NA' when b.LA_49a_b = '888' then 'NR' end LA_49a_b, " +
                    " b.LA_49a_a, " +
                    " case when b.LA_49b_a = 1 then 'S' when b.LA_49b_a = 2 then 'R' when b.LA_49b_a = 3 then 'I' end LA_49b, " +
                    " case when b.LA_50a_b = '' then b.LA_50a_b when b.LA_50a_b is null then b.LA_50a_b when b.LA_50a_b = '999' then 'NA' when b.LA_50a_b = '888' then 'NR' end LA_50a_b, " +
                    " b.LA_50a_a, " +
                    " case when b.LA_50b_a = 1 then 'S' when b.LA_50b_a = 2 then 'R' when b.LA_50b_a = 3 then 'I' end LA_50b, " +
                    " case when b.LA_51a_b = '' then b.LA_51a_b when b.LA_51a_b is null then b.LA_51a_b when b.LA_51a_b = '999' then 'NA' when b.LA_51a_b = '888' then 'NR' end LA_51a_b, " +
                    " b.LA_51a_a, " +
                    " case when b.LA_51b_a = 1 then 'S' when b.LA_51b_a = 2 then 'R' when b.LA_51b_a = 3 then 'I' end LA_51b, " +
                    " case when b.LA_52a_b = '' then b.LA_52a_b when b.LA_52a_b is null then b.LA_52a_b when b.LA_52a_b = '999' then 'NA' when b.LA_52a_b = '888' then 'NR' end LA_52a_b, " +
                    " b.LA_52a_a, " +
                    " case when b.LA_52b_a = 1 then 'S' when b.LA_52b_a = 2 then 'R' when b.LA_52b_a = 3 then 'I' end LA_52b, " +
                    " (select c.LA_02 from sample_result c where c.la_sno = b.la_sno and c.labid = 2) LA_02, " +
                    " (select c.LA_02a from sample_result c where c.la_sno = b.la_sno and c.labid = 2) LA_02a " +
                    " from form1 a inner join sample_result b on a.AS1_screening_ID = b.la_sno " +
                    " where a.labid = 1 and b.labid = 1 and b.rdo_BloodCulture = 1 ";
            }
            else
            {
                qry = "select b.ID, b.id id1, a.AS1_screening_ID, a.AS1_rand_id, a.AS1_name, a.AS1_age, a.AS1_mrno, a.AS1_lno, convert(varchar(13), AS2_Q9, 103) AS2_Q9, case when rdo_BloodCulture = 1 then 'POS' else 'NEG' end rdo_BloodCulture, " +
                    " case when b.LA_03_a <> '' then b.LA_03_a when b.LA_03_a = '' then '888' when b.LA_03_a = '' then '999' end  LA_03_a, " +
                    " case when b.LA_04_a <> '' then b.LA_04_a when b.LA_04_a = '' then '888' when b.LA_04_a = '' then '999' end  LA_04_a, " +
                    " case when b.LA_05_a <> '' then b.LA_05_a when b.LA_05_a = '' then '888' when b.LA_05_a = '' then '999' end  LA_05_a, " +
                    " case when b.LA_06_a <> '' then b.LA_06_a when b.LA_06_a = '' then '888' when b.LA_06_a = '' then '999' end  LA_06_a, " +
                    " case when b.LA_07_a <> '' then b.LA_07_a when b.LA_07_a = '' then '888' when b.LA_07_a = '' then '999' end  LA_07_a, " +
                    " case when b.LA_08_a <> '' then b.LA_08_a when b.LA_08_a = '' then '888' when b.LA_08_a = '' then '999' end  LA_08_a, " +
                    " case when b.LA_09_a <> '' then b.LA_09_a when b.LA_09_a = '' then '888' when b.LA_09_a = '' then '999' end  LA_09_a, " +
                    " case when b.LA_10_a <> '' then b.LA_10_a when b.LA_10_a = '' then '888' when b.LA_10_a = '' then '999' end  LA_10_a, " +
                    " case when b.LA_11_a <> '' then b.LA_11_a when b.LA_11_a = '' then '888' when b.LA_11_a = '' then '999' end  LA_11_a, " +
                    " case when b.LA_12_a <> '' then b.LA_12_a when b.LA_12_a = '' then '888' when b.LA_12_a = '' then '999' end  LA_12_a, " +
                    " case when b.LA_13_a <> '' then b.LA_13_a when b.LA_13_a = '' then '888' when b.LA_13_a = '' then '999' end  LA_13_a, " +
                    " case when b.LA_14_a <> '' then b.LA_14_a when b.LA_14_a = '' then '888' when b.LA_14_a = '' then '999' end  LA_14_a, " +
                    " case when b.LA_15_a <> '' then b.LA_15_a when b.LA_15_a = '' then '888' when b.LA_15_a = '' then '999' end  LA_15_a, " +
                    " case when b.LA_16_a <> '' then b.LA_16_a when b.LA_16_a = '' then '888' when b.LA_16_a = '' then '999' end  LA_16_a, " +
                    " b.history, " +
                    " b.ProvisionalResult, " +
                    " case when b.rdo_BloodCulture = 1 then 'Yes' else 'No' end rdo_BloodCulture, " +
                    " case when b.ddl_BloodCulture = 1 then 'Escherichia coli' " +
                    " when b.ddl_BloodCulture = 2 then 'Klebsiella pneumoniae' " +
                    " when b.ddl_BloodCulture = 3 then 'Klebsiella species' " +
                    " when b.ddl_BloodCulture = 4 then 'Acinetobacter baumannii' " +
                    " when b.ddl_BloodCulture = 5 then 'Acinetobacter species' " +
                    " when b.ddl_BloodCulture = 6 then 'Salmonella species' " +
                    " when b.ddl_BloodCulture = 7 then 'Salmonella typhi' " +
                    " when b.ddl_BloodCulture = 8 then 'Salmonella paratyphi A' " +
                    " when b.ddl_BloodCulture = 9 then 'Salmonella paratyphi B'  " +
                    " when b.ddl_BloodCulture = 10 then 'Serratia species' " +
                    " when b.ddl_BloodCulture = 11 then 'Serratia marcescens' " +
                    " when b.ddl_BloodCulture = 12 then 'Serratia liquefaciens' " +
                    " when b.ddl_BloodCulture = 13 then 'Staphylococcus epidermidis' " +
                    " when b.ddl_BloodCulture = 14 then 'Staphylococcus saprophyticus' " +
                    " when b.ddl_BloodCulture = 15 then 'Staphylococcus species' " +
                    " when b.ddl_BloodCulture = 16 then 'Micrococcus specie' " +
                    " when b.ddl_BloodCulture = 17 then 'Streptococcus species' " +
                    " when b.ddl_BloodCulture = 18 then 'Streptococcus pyogenes (group A Streptococcus)' " +
                    " when b.ddl_BloodCulture = 19 then 'Streptococcus pneumoniae' " +
                    " when b.ddl_BloodCulture = 20 then 'Streptococcus mitis' " +
                    " when b.ddl_BloodCulture = 21 then 'Campylobacter species' " +
                    " when b.ddl_BloodCulture = 22 then 'Campylobacter jejuni' " +
                    " when b.ddl_BloodCulture = 23 then 'Enterococcus species' " +
                    " when b.ddl_BloodCulture = 24 then 'Corynebacterium species' " +
                    " when b.ddl_BloodCulture = 25 then 'Burkholderia cepacia' " +
                    " when b.ddl_BloodCulture = 26 then 'Neisseria gonorrhoeae' " +
                    " when b.ddl_BloodCulture = 27 then 'Candida species' " +
                    " when b.ddl_BloodCulture = 28 then 'Citrobacter freundii' " +
                    " when b.ddl_BloodCulture = 29 then 'Citrobacter species' " +
                    " when b.ddl_BloodCulture = 30 then 'Bacillus species' " +
                    " when b.ddl_BloodCulture = 32 then 'Others' " +
                    " end ddl_BloodCulture, " +
                    " case when b.rdo_BloodCulture_Multiple = 1 then 'Yes' when b.rdo_BloodCulture_Multiple = 2 then 'No' end BloodCulture_Multiple, " +
                    " b.LA_18, " +
                    " case when b.LA_20a_b = '' then b.LA_20a_b when b.LA_20a_b is null then b.LA_20a_b when b.LA_20a_b = '999' then 'NA' when b.LA_20a_b = '888' then 'NR' end LA_20a_b, " + "b.LA_20a_a, " +
                    " case when b.LA_20b_a = 1 then 'S' when b.LA_20b_a = 2 then 'R' when b.LA_20b_a = 3 then 'I' end LA_20b, " +
                    " case when b.LA_21a_b = '' then b.LA_21a_b when b.LA_21a_b is null then b.LA_21a_b when b.LA_21a_b = '999' then 'NA' when b.LA_21a_b = '888' then 'NR' end LA_21a_b, " +
                    " b.LA_21a_a, " +
                    " case when b.LA_21b_a = 1 then 'S' when b.LA_21b_a = 2 then 'R' when b.LA_21b_a = 3 then 'I' end LA_21b, " +
                    " case when b.LA_22a_b = '' then b.LA_22a_b when b.LA_22a_b is null then b.LA_22a_b when b.LA_22a_b = '999' then 'NA' when b.LA_22a_b = '888' then 'NR' end LA_22a_b, " +
                    " b.LA_22a_a, " +
                    " case when b.LA_22b_a = 1 then 'S' when b.LA_22b_a = 2 then 'R' when b.LA_22b_a = 3 then 'I' end LA_22b, " +
                    " case when b.LA_23a_b = '' then b.LA_23a_b when b.LA_23a_b is null then b.LA_23a_b when b.LA_23a_b = '999' then 'NA' when b.LA_23a_b = '888' then 'NR' end LA_23a_b, " +
                    " b.LA_23a_a, " +
                    " case when b.LA_23b_a = 1 then 'S' when b.LA_23b_a = 2 then 'R' when b.LA_23b_a = 3 then 'I' end LA_23b, " +
                    " case when b.LA_24a_b = '' then b.LA_24a_b when b.LA_24a_b is null then b.LA_24a_b when b.LA_24a_b = '999' then 'NA' when b.LA_24a_b = '888' then 'NR' end LA_24a_b, " +
                    " b.LA_24a_a, " +
                    " case when b.LA_24b_a = 1 then 'S' when b.LA_24b_a = 2 then 'R' when b.LA_24b_a = 3 then 'I' end LA_24b, " +
                    " case when b.LA_25a_b = '' then b.LA_25a_b when b.LA_25a_b is null then b.LA_25a_b when b.LA_25a_b = '999' then 'NA' when b.LA_25a_b = '888' then 'NR' end LA_25a_b, " +
                    " b.LA_25a_a, " +
                    " case when b.LA_25b_a = 1 then 'S' when b.LA_25b_a = 2 then 'R' when b.LA_25b_a = 3 then 'I' end LA_25b, " +
                    " case when b.LA_26a_b = '' then b.LA_26a_b when b.LA_26a_b is null then b.LA_26a_b when b.LA_26a_b = '999' then 'NA' when b.LA_26a_b = '888' then 'NR' end LA_26a_b, " +
                    " b.LA_26a_a, " +
                    " case when b.LA_26b_a = 1 then 'S' when b.LA_26b_a = 2 then 'R' when b.LA_26b_a = 3 then 'I' end LA_26b, " +
                    " case when b.LA_27a_b = '' then b.LA_27a_b when b.LA_27a_b is null then b.LA_27a_b when b.LA_27a_b = '999' then 'NA' when b.LA_27a_b = '888' then 'NR' end LA_27a_b, " +
                    " b.LA_27a_a, " +
                    " case when b.LA_27b_a = 1 then 'S' when b.LA_27b_a = 2 then 'R' when b.LA_27b_a = 3 then 'I' end LA_27b, " +
                    " case when b.LA_28a_b = '' then b.LA_28a_b when b.LA_28a_b is null then b.LA_28a_b when b.LA_28a_b = '999' then 'NA' when b.LA_28a_b = '888' then 'NR' end LA_28a_b, " +
                    " b.LA_28a_a, " +
                    " case when b.LA_28b_a = 1 then 'S' when b.LA_28b_a = 2 then 'R' when b.LA_28b_a = 3 then 'I' end LA_28b, " +
                    " case when b.LA_29a_b = '' then b.LA_29a_b when b.LA_29a_b is null then b.LA_29a_b when b.LA_29a_b = '999' then 'NA' when b.LA_29a_b = '888' then 'NR' end LA_29a_b, " +
                    " b.LA_29a_a, " +
                    " case when b.LA_29b_a = 1 then 'S' when b.LA_29b_a = 2 then 'R' when b.LA_29b_a = 3 then 'I' end LA_29b, " +
                    " case when b.LA_30a_b = '' then b.LA_30a_b when b.LA_30a_b is null then b.LA_30a_b when b.LA_30a_b = '999' then 'NA' when b.LA_30a_b = '888' then 'NR' end LA_30a_b, " +
                    " b.LA_30a_a, " +
                    " case when b.LA_30b_a = 1 then 'S' when b.LA_30b_a = 2 then 'R' when b.LA_30b_a = 3 then 'I' end LA_30b, " +
                    " case when b.LA_31a_b = '' then b.LA_31a_b when b.LA_31a_b is null then b.LA_31a_b when b.LA_31a_b = '999' then 'NA' when b.LA_31a_b = '888' then 'NR' end LA_31a_b, " +
                    " b.LA_31a_a, " +
                    " case when b.LA_31b_a = 1 then 'S' when b.LA_31b_a = 2 then 'R' when b.LA_31b_a = 3 then 'I' end LA_31b, " +
                    " case when b.LA_32a_b = '' then b.LA_32a_b when b.LA_32a_b is null then b.LA_32a_b when b.LA_32a_b = '999' then 'NA' when b.LA_32a_b = '888' then 'NR' end LA_32a_b, " +
                    " b.LA_32a_a, " +
                    " case when b.LA_32b_a = 1 then 'S' when b.LA_32b_a = 2 then 'R' when b.LA_32b_a = 3 then 'I' end LA_32b, " +
                    " case when b.LA_33a_b = '' then b.LA_33a_b when b.LA_33a_b is null then b.LA_33a_b when b.LA_33a_b = '999' then 'NA' when b.LA_33a_b = '888' then 'NR' end LA_33a_b, " +
                    " b.LA_33a_a, " +
                    " case when b.LA_33b_a = 1 then 'S' when b.LA_33b_a = 2 then 'R' when b.LA_33b_a = 3 then 'I' end LA_33b, " +
                    " case when b.LA_34a_b = '' then b.LA_34a_b when b.LA_34a_b is null then b.LA_34a_b when b.LA_34a_b = '999' then 'NA' when b.LA_34a_b = '888' then 'NR' end LA_34a_b, " +
                    " b.LA_34a_a, " +
                    " case when b.LA_34b_a = 1 then 'S' when b.LA_34b_a = 2 then 'R' when b.LA_34b_a = 3 then 'I' end LA_34b, " +
                    " case when b.LA_35a_b = '' then b.LA_35a_b when b.LA_35a_b is null then b.LA_35a_b when b.LA_35a_b = '999' then 'NA' when b.LA_35a_b = '888' then 'NR' end LA_35a_b, " +
                    " b.LA_35a_a, " +
                    " case when b.LA_35b_a = 1 then 'S' when b.LA_35b_a = 2 then 'R' when b.LA_35b_a = 3 then 'I' end LA_35b, " +
                    " case when b.LA_36a_b = '' then b.LA_36a_b when b.LA_36a_b is null then b.LA_36a_b when b.LA_36a_b = '999' then 'NA' when b.LA_36a_b = '888' then 'NR' end LA_36a_b, " +
                    " b.LA_36a_a, " +
                    " case when b.LA_36b_a = 1 then 'S' when b.LA_36b_a = 2 then 'R' when b.LA_36b_a = 3 then 'I' end LA_36b, " +
                    " case when b.LA_37a_b = '' then b.LA_37a_b when b.LA_37a_b is null then b.LA_37a_b when b.LA_37a_b = '999' then 'NA' when b.LA_37a_b = '888' then 'NR' end LA_37a_b, " +
                    " b.LA_37a_a, " +
                    " case when b.LA_37b_a = 1 then 'S' when b.LA_37b_a = 2 then 'R' when b.LA_37b_a = 3 then 'I' end LA_37b, " +
                    " case when b.LA_38a_b = '' then b.LA_38a_b when b.LA_38a_b is null then b.LA_38a_b when b.LA_38a_b = '999' then 'NA' when b.LA_38a_b = '888' then 'NR' end LA_38a_b, " +
                    " b.LA_38a_a, " +
                    " case when b.LA_38b_a = 1 then 'S' when b.LA_38b_a = 2 then 'R' when b.LA_38b_a = 3 then 'I' end LA_38b, " +
                    " case when b.LA_39a_b = '' then b.LA_39a_b when b.LA_39a_b is null then b.LA_39a_b when b.LA_39a_b = '999' then 'NA' when b.LA_39a_b = '888' then 'NR' end LA_39a_b, " +
                    " b.LA_39a_a, " +
                    " case when b.LA_39b_a = 1 then 'S' when b.LA_39b_a = 2 then 'R' when b.LA_39b_a = 3 then 'I' end LA_39b, " +
                    " case when b.LA_40a_b = '' then b.LA_40a_b when b.LA_40a_b is null then b.LA_40a_b when b.LA_40a_b = '999' then 'NA' when b.LA_40a_b = '888' then 'NR' end LA_40a_b, " +
                    " b.LA_40a_a, " +
                    " case when b.LA_40b_a = 1 then 'S' when b.LA_40b_a = 2 then 'R' when b.LA_40b_a = 3 then 'I' end LA_40b, " +
                    " case when b.LA_41a_b = '' then b.LA_41a_b when b.LA_41a_b is null then b.LA_41a_b when b.LA_41a_b = '999' then 'NA' when b.LA_41a_b = '888' then 'NR' end LA_41a_b, " +
                    " b.LA_41a_a, " +
                    " case when b.LA_41b_a = 1 then 'S' when b.LA_41b_a = 2 then 'R' when b.LA_41b_a = 3 then 'I' end LA_41b, " +
                    " case when b.LA_42a_b = '' then b.LA_42a_b when b.LA_42a_b is null then b.LA_42a_b when b.LA_42a_b = '999' then 'NA' when b.LA_42a_b = '888' then 'NR' end LA_42a_b, " +
                    " b.LA_42a_a, " +
                    " case when b.LA_42b_a = 1 then 'S' when b.LA_42b_a = 2 then 'R' when b.LA_42b_a = 3 then 'I' end LA_42b, " +
                    " case when b.LA_43a_b = '' then b.LA_43a_b when b.LA_43a_b is null then b.LA_43a_b when b.LA_43a_b = '999' then 'NA' when b.LA_43a_b = '888' then 'NR' end LA_43a_b, " +
                    " b.LA_43a_a, " +
                    " case when b.LA_43b_a = 1 then 'S' when b.LA_43b_a = 2 then 'R' when b.LA_43b_a = 3 then 'I' end LA_43b, " +
                    " case when b.LA_44a_b = '' then b.LA_44a_b when b.LA_44a_b is null then b.LA_44a_b when b.LA_44a_b = '999' then 'NA' when b.LA_44a_b = '888' then 'NR' end LA_44a_b, " +
                    " b.LA_44a_a, " +
                    " case when b.LA_44b_a = 1 then 'S' when b.LA_44b_a = 2 then 'R' when b.LA_44b_a = 3 then 'I' end LA_44b, " +
                    " case when b.LA_45a_b = '' then b.LA_45a_b when b.LA_45a_b is null then b.LA_45a_b when b.LA_45a_b = '999' then 'NA' when b.LA_45a_b = '888' then 'NR' end LA_45a_b, " +
                    " b.LA_45a_a, " +
                    " case when b.LA_45b_a = 1 then 'S' when b.LA_45b_a = 2 then 'R' when b.LA_45b_a = 3 then 'I' end LA_45b, " +
                    " case when b.LA_46a_b = '' then b.LA_46a_b when b.LA_46a_b is null then b.LA_46a_b when b.LA_46a_b = '999' then 'NA' when b.LA_46a_b = '888' then 'NR' end LA_46a_b, " +
                    " b.LA_46a_a, " +
                    " case when b.LA_46b_a = 1 then 'S' when b.LA_46b_a = 2 then 'R' when b.LA_46b_a = 3 then 'I' end LA_46b, " +
                    " case when b.LA_47a_b = '' then b.LA_47a_b when b.LA_47a_b is null then b.LA_47a_b when b.LA_47a_b = '999' then 'NA' when b.LA_47a_b = '888' then 'NR' end LA_47a_b, " +
                    " b.LA_47a_a, " +
                    " case when b.LA_47b_a = 1 then 'S' when b.LA_47b_a = 2 then 'R' when b.LA_47b_a = 3 then 'I' end LA_47b, " +
                    " case when b.LA_48a_b = '' then b.LA_48a_b when b.LA_48a_b is null then b.LA_48a_b when b.LA_48a_b = '999' then 'NA' when b.LA_48a_b = '888' then 'NR' end LA_48a_b, " +
                    " b.LA_48a_a, " +
                    " case when b.LA_48b_a = 1 then 'S' when b.LA_48b_a = 2 then 'R' when b.LA_48b_a = 3 then 'I' end LA_48b, " +
                    " case when b.LA_49a_b = '' then b.LA_49a_b when b.LA_49a_b is null then b.LA_49a_b when b.LA_49a_b = '999' then 'NA' when b.LA_49a_b = '888' then 'NR' end LA_49a_b, " +
                    " b.LA_49a_a, " +
                    " case when b.LA_49b_a = 1 then 'S' when b.LA_49b_a = 2 then 'R' when b.LA_49b_a = 3 then 'I' end LA_49b, " +
                    " case when b.LA_50a_b = '' then b.LA_50a_b when b.LA_50a_b is null then b.LA_50a_b when b.LA_50a_b = '999' then 'NA' when b.LA_50a_b = '888' then 'NR' end LA_50a_b, " +
                    " b.LA_50a_a, " +
                    " case when b.LA_50b_a = 1 then 'S' when b.LA_50b_a = 2 then 'R' when b.LA_50b_a = 3 then 'I' end LA_50b, " +
                    " case when b.LA_51a_b = '' then b.LA_51a_b when b.LA_51a_b is null then b.LA_51a_b when b.LA_51a_b = '999' then 'NA' when b.LA_51a_b = '888' then 'NR' end LA_51a_b, " +
                    " b.LA_51a_a, " +
                    " case when b.LA_51b_a = 1 then 'S' when b.LA_51b_a = 2 then 'R' when b.LA_51b_a = 3 then 'I' end LA_51b, " +
                    " case when b.LA_52a_b = '' then b.LA_52a_b when b.LA_52a_b is null then b.LA_52a_b when b.LA_52a_b = '999' then 'NA' when b.LA_52a_b = '888' then 'NR' end LA_52a_b, " +
                    " b.LA_52a_a, " +
                    " case when b.LA_52b_a = 1 then 'S' when b.LA_52b_a = 2 then 'R' when b.LA_52b_a = 3 then 'I' end LA_52b, " +
                    " (select c.LA_02 from sample_result c where c.la_sno = b.la_sno and c.labid = 2) LA_02, " +
                    " (select c.LA_02a from sample_result c where c.la_sno = b.la_sno and c.labid = 2) LA_02a " +
                    " from form1 a inner join sample_result b on a.AS1_screening_ID = b.la_sno where a.labid = 1 and b.labid = 1 ";
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



    private bool FillGrid_BloodCulture()
    {
        CConnection cn = null;
        lblerr.Text = "";

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
                qry = "select b.ID, b.id id1, a.AS1_screening_ID, a.AS1_rand_id, a.AS1_name, a.AS1_age, a.AS1_mrno, a.AS1_lno, convert(varchar(13), AS2_Q9, 103) AS2_Q9, case when rdo_BloodCulture = 1 then 'POS' else 'NEG' end rdo_BloodCulture, " +
                    " case when b.LA_03_a <> '' then b.LA_03_a when b.LA_03_a = '' then '888' when b.LA_03_a = '' then '999' end  LA_03_a, " +
                    " case when b.LA_04_a <> '' then b.LA_04_a when b.LA_04_a = '' then '888' when b.LA_04_a = '' then '999' end  LA_04_a, " +
                    " case when b.LA_05_a <> '' then b.LA_05_a when b.LA_05_a = '' then '888' when b.LA_05_a = '' then '999' end  LA_05_a, " +
                    " case when b.LA_06_a <> '' then b.LA_06_a when b.LA_06_a = '' then '888' when b.LA_06_a = '' then '999' end  LA_06_a, " +
                    " case when b.LA_07_a <> '' then b.LA_07_a when b.LA_07_a = '' then '888' when b.LA_07_a = '' then '999' end  LA_07_a, " +
                    " case when b.LA_08_a <> '' then b.LA_08_a when b.LA_08_a = '' then '888' when b.LA_08_a = '' then '999' end  LA_08_a, " +
                    " case when b.LA_09_a <> '' then b.LA_09_a when b.LA_09_a = '' then '888' when b.LA_09_a = '' then '999' end  LA_09_a, " +
                    " case when b.LA_10_a <> '' then b.LA_10_a when b.LA_10_a = '' then '888' when b.LA_10_a = '' then '999' end  LA_10_a, " +
                    " case when b.LA_11_a <> '' then b.LA_11_a when b.LA_11_a = '' then '888' when b.LA_11_a = '' then '999' end  LA_11_a, " +
                    " case when b.LA_12_a <> '' then b.LA_12_a when b.LA_12_a = '' then '888' when b.LA_12_a = '' then '999' end  LA_12_a, " +
                    " case when b.LA_13_a <> '' then b.LA_13_a when b.LA_13_a = '' then '888' when b.LA_13_a = '' then '999' end  LA_13_a, " +
                    " case when b.LA_14_a <> '' then b.LA_14_a when b.LA_14_a = '' then '888' when b.LA_14_a = '' then '999' end  LA_14_a, " +
                    " case when b.LA_15_a <> '' then b.LA_15_a when b.LA_15_a = '' then '888' when b.LA_15_a = '' then '999' end  LA_15_a, " +
                    " case when b.LA_16_a <> '' then b.LA_16_a when b.LA_16_a = '' then '888' when b.LA_16_a = '' then '999' end  LA_16_a, " +
                    " b.history, " +
                    " b.ProvisionalResult, " +
                    " case when b.rdo_BloodCulture = 1 then 'Yes' else 'No' end rdo_BloodCulture, " +
                    " case when b.ddl_BloodCulture = 1 then 'Escherichia coli' " +
                    " when b.ddl_BloodCulture = 2 then 'Klebsiella pneumoniae' " +
                    " when b.ddl_BloodCulture = 3 then 'Klebsiella species' " +
                    " when b.ddl_BloodCulture = 4 then 'Acinetobacter baumannii' " +
                    " when b.ddl_BloodCulture = 5 then 'Acinetobacter species' " +
                    " when b.ddl_BloodCulture = 6 then 'Salmonella species' " +
                    " when b.ddl_BloodCulture = 7 then 'Salmonella typhi' " +
                    " when b.ddl_BloodCulture = 8 then 'Salmonella paratyphi A' " +
                    " when b.ddl_BloodCulture = 9 then 'Salmonella paratyphi B'  " +
                    " when b.ddl_BloodCulture = 10 then 'Serratia species' " +
                    " when b.ddl_BloodCulture = 11 then 'Serratia marcescens' " +
                    " when b.ddl_BloodCulture = 12 then 'Serratia liquefaciens' " +
                    " when b.ddl_BloodCulture = 13 then 'Staphylococcus epidermidis' " +
                    " when b.ddl_BloodCulture = 14 then 'Staphylococcus saprophyticus' " +
                    " when b.ddl_BloodCulture = 15 then 'Staphylococcus species' " +
                    " when b.ddl_BloodCulture = 16 then 'Micrococcus specie' " +
                    " when b.ddl_BloodCulture = 17 then 'Streptococcus species' " +
                    " when b.ddl_BloodCulture = 18 then 'Streptococcus pyogenes (group A Streptococcus)' " +
                    " when b.ddl_BloodCulture = 19 then 'Streptococcus pneumoniae' " +
                    " when b.ddl_BloodCulture = 20 then 'Streptococcus mitis' " +
                    " when b.ddl_BloodCulture = 21 then 'Campylobacter species' " +
                    " when b.ddl_BloodCulture = 22 then 'Campylobacter jejuni' " +
                    " when b.ddl_BloodCulture = 23 then 'Enterococcus species' " +
                    " when b.ddl_BloodCulture = 24 then 'Corynebacterium species' " +
                    " when b.ddl_BloodCulture = 25 then 'Burkholderia cepacia' " +
                    " when b.ddl_BloodCulture = 26 then 'Neisseria gonorrhoeae' " +
                    " when b.ddl_BloodCulture = 27 then 'Candida species' " +
                    " when b.ddl_BloodCulture = 28 then 'Citrobacter freundii' " +
                    " when b.ddl_BloodCulture = 29 then 'Citrobacter species' " +
                    " when b.ddl_BloodCulture = 30 then 'Bacillus species' " +
                    " when b.ddl_BloodCulture = 32 then 'Others' " +
                    " end ddl_BloodCulture, " +
                    " case when b.rdo_BloodCulture_Multiple = 1 then 'Yes' when b.rdo_BloodCulture_Multiple = 2 then 'No' end BloodCulture_Multiple, " +
                    " b.LA_18, " +
                    " case when b.LA_20a_b = '' then b.LA_20a_b when b.LA_20a_b is null then b.LA_20a_b when b.LA_20a_b = '999' then 'NA' when b.LA_20a_b = '888' then 'NR' end LA_20a_b, " + "b.LA_20a_a, " +
                    " case when b.LA_20b_a = 1 then 'S' when b.LA_20b_a = 2 then 'R' when b.LA_20b_a = 3 then 'I' end LA_20b, " +
                    " case when b.LA_21a_b = '' then b.LA_21a_b when b.LA_21a_b is null then b.LA_21a_b when b.LA_21a_b = '999' then 'NA' when b.LA_21a_b = '888' then 'NR' end LA_21a_b, " +
                    " b.LA_21a_a, " +
                    " case when b.LA_21b_a = 1 then 'S' when b.LA_21b_a = 2 then 'R' when b.LA_21b_a = 3 then 'I' end LA_21b, " +
                    " case when b.LA_22a_b = '' then b.LA_22a_b when b.LA_22a_b is null then b.LA_22a_b when b.LA_22a_b = '999' then 'NA' when b.LA_22a_b = '888' then 'NR' end LA_22a_b, " +
                    " b.LA_22a_a, " +
                    " case when b.LA_22b_a = 1 then 'S' when b.LA_22b_a = 2 then 'R' when b.LA_22b_a = 3 then 'I' end LA_22b, " +
                    " case when b.LA_23a_b = '' then b.LA_23a_b when b.LA_23a_b is null then b.LA_23a_b when b.LA_23a_b = '999' then 'NA' when b.LA_23a_b = '888' then 'NR' end LA_23a_b, " +
                    " b.LA_23a_a, " +
                    " case when b.LA_23b_a = 1 then 'S' when b.LA_23b_a = 2 then 'R' when b.LA_23b_a = 3 then 'I' end LA_23b, " +
                    " case when b.LA_24a_b = '' then b.LA_24a_b when b.LA_24a_b is null then b.LA_24a_b when b.LA_24a_b = '999' then 'NA' when b.LA_24a_b = '888' then 'NR' end LA_24a_b, " +
                    " b.LA_24a_a, " +
                    " case when b.LA_24b_a = 1 then 'S' when b.LA_24b_a = 2 then 'R' when b.LA_24b_a = 3 then 'I' end LA_24b, " +
                    " case when b.LA_25a_b = '' then b.LA_25a_b when b.LA_25a_b is null then b.LA_25a_b when b.LA_25a_b = '999' then 'NA' when b.LA_25a_b = '888' then 'NR' end LA_25a_b, " +
                    " b.LA_25a_a, " +
                    " case when b.LA_25b_a = 1 then 'S' when b.LA_25b_a = 2 then 'R' when b.LA_25b_a = 3 then 'I' end LA_25b, " +
                    " case when b.LA_26a_b = '' then b.LA_26a_b when b.LA_26a_b is null then b.LA_26a_b when b.LA_26a_b = '999' then 'NA' when b.LA_26a_b = '888' then 'NR' end LA_26a_b, " +
                    " b.LA_26a_a, " +
                    " case when b.LA_26b_a = 1 then 'S' when b.LA_26b_a = 2 then 'R' when b.LA_26b_a = 3 then 'I' end LA_26b, " +
                    " case when b.LA_27a_b = '' then b.LA_27a_b when b.LA_27a_b is null then b.LA_27a_b when b.LA_27a_b = '999' then 'NA' when b.LA_27a_b = '888' then 'NR' end LA_27a_b, " +
                    " b.LA_27a_a, " +
                    " case when b.LA_27b_a = 1 then 'S' when b.LA_27b_a = 2 then 'R' when b.LA_27b_a = 3 then 'I' end LA_27b, " +
                    " case when b.LA_28a_b = '' then b.LA_28a_b when b.LA_28a_b is null then b.LA_28a_b when b.LA_28a_b = '999' then 'NA' when b.LA_28a_b = '888' then 'NR' end LA_28a_b, " +
                    " b.LA_28a_a, " +
                    " case when b.LA_28b_a = 1 then 'S' when b.LA_28b_a = 2 then 'R' when b.LA_28b_a = 3 then 'I' end LA_28b, " +
                    " case when b.LA_29a_b = '' then b.LA_29a_b when b.LA_29a_b is null then b.LA_29a_b when b.LA_29a_b = '999' then 'NA' when b.LA_29a_b = '888' then 'NR' end LA_29a_b, " +
                    " b.LA_29a_a, " +
                    " case when b.LA_29b_a = 1 then 'S' when b.LA_29b_a = 2 then 'R' when b.LA_29b_a = 3 then 'I' end LA_29b, " +
                    " case when b.LA_30a_b = '' then b.LA_30a_b when b.LA_30a_b is null then b.LA_30a_b when b.LA_30a_b = '999' then 'NA' when b.LA_30a_b = '888' then 'NR' end LA_30a_b, " +
                    " b.LA_30a_a, " +
                    " case when b.LA_30b_a = 1 then 'S' when b.LA_30b_a = 2 then 'R' when b.LA_30b_a = 3 then 'I' end LA_30b, " +
                    " case when b.LA_31a_b = '' then b.LA_31a_b when b.LA_31a_b is null then b.LA_31a_b when b.LA_31a_b = '999' then 'NA' when b.LA_31a_b = '888' then 'NR' end LA_31a_b, " +
                    " b.LA_31a_a, " +
                    " case when b.LA_31b_a = 1 then 'S' when b.LA_31b_a = 2 then 'R' when b.LA_31b_a = 3 then 'I' end LA_31b, " +
                    " case when b.LA_32a_b = '' then b.LA_32a_b when b.LA_32a_b is null then b.LA_32a_b when b.LA_32a_b = '999' then 'NA' when b.LA_32a_b = '888' then 'NR' end LA_32a_b, " +
                    " b.LA_32a_a, " +
                    " case when b.LA_32b_a = 1 then 'S' when b.LA_32b_a = 2 then 'R' when b.LA_32b_a = 3 then 'I' end LA_32b, " +
                    " case when b.LA_33a_b = '' then b.LA_33a_b when b.LA_33a_b is null then b.LA_33a_b when b.LA_33a_b = '999' then 'NA' when b.LA_33a_b = '888' then 'NR' end LA_33a_b, " +
                    " b.LA_33a_a, " +
                    " case when b.LA_33b_a = 1 then 'S' when b.LA_33b_a = 2 then 'R' when b.LA_33b_a = 3 then 'I' end LA_33b, " +
                    " case when b.LA_34a_b = '' then b.LA_34a_b when b.LA_34a_b is null then b.LA_34a_b when b.LA_34a_b = '999' then 'NA' when b.LA_34a_b = '888' then 'NR' end LA_34a_b, " +
                    " b.LA_34a_a, " +
                    " case when b.LA_34b_a = 1 then 'S' when b.LA_34b_a = 2 then 'R' when b.LA_34b_a = 3 then 'I' end LA_34b, " +
                    " case when b.LA_35a_b = '' then b.LA_35a_b when b.LA_35a_b is null then b.LA_35a_b when b.LA_35a_b = '999' then 'NA' when b.LA_35a_b = '888' then 'NR' end LA_35a_b, " +
                    " b.LA_35a_a, " +
                    " case when b.LA_35b_a = 1 then 'S' when b.LA_35b_a = 2 then 'R' when b.LA_35b_a = 3 then 'I' end LA_35b, " +
                    " case when b.LA_36a_b = '' then b.LA_36a_b when b.LA_36a_b is null then b.LA_36a_b when b.LA_36a_b = '999' then 'NA' when b.LA_36a_b = '888' then 'NR' end LA_36a_b, " +
                    " b.LA_36a_a, " +
                    " case when b.LA_36b_a = 1 then 'S' when b.LA_36b_a = 2 then 'R' when b.LA_36b_a = 3 then 'I' end LA_36b, " +
                    " case when b.LA_37a_b = '' then b.LA_37a_b when b.LA_37a_b is null then b.LA_37a_b when b.LA_37a_b = '999' then 'NA' when b.LA_37a_b = '888' then 'NR' end LA_37a_b, " +
                    " b.LA_37a_a, " +
                    " case when b.LA_37b_a = 1 then 'S' when b.LA_37b_a = 2 then 'R' when b.LA_37b_a = 3 then 'I' end LA_37b, " +
                    " case when b.LA_38a_b = '' then b.LA_38a_b when b.LA_38a_b is null then b.LA_38a_b when b.LA_38a_b = '999' then 'NA' when b.LA_38a_b = '888' then 'NR' end LA_38a_b, " +
                    " b.LA_38a_a, " +
                    " case when b.LA_38b_a = 1 then 'S' when b.LA_38b_a = 2 then 'R' when b.LA_38b_a = 3 then 'I' end LA_38b, " +
                    " case when b.LA_39a_b = '' then b.LA_39a_b when b.LA_39a_b is null then b.LA_39a_b when b.LA_39a_b = '999' then 'NA' when b.LA_39a_b = '888' then 'NR' end LA_39a_b, " +
                    " b.LA_39a_a, " +
                    " case when b.LA_39b_a = 1 then 'S' when b.LA_39b_a = 2 then 'R' when b.LA_39b_a = 3 then 'I' end LA_39b, " +
                    " case when b.LA_40a_b = '' then b.LA_40a_b when b.LA_40a_b is null then b.LA_40a_b when b.LA_40a_b = '999' then 'NA' when b.LA_40a_b = '888' then 'NR' end LA_40a_b, " +
                    " b.LA_40a_a, " +
                    " case when b.LA_40b_a = 1 then 'S' when b.LA_40b_a = 2 then 'R' when b.LA_40b_a = 3 then 'I' end LA_40b, " +
                    " case when b.LA_41a_b = '' then b.LA_41a_b when b.LA_41a_b is null then b.LA_41a_b when b.LA_41a_b = '999' then 'NA' when b.LA_41a_b = '888' then 'NR' end LA_41a_b, " +
                    " b.LA_41a_a, " +
                    " case when b.LA_41b_a = 1 then 'S' when b.LA_41b_a = 2 then 'R' when b.LA_41b_a = 3 then 'I' end LA_41b, " +
                    " case when b.LA_42a_b = '' then b.LA_42a_b when b.LA_42a_b is null then b.LA_42a_b when b.LA_42a_b = '999' then 'NA' when b.LA_42a_b = '888' then 'NR' end LA_42a_b, " +
                    " b.LA_42a_a, " +
                    " case when b.LA_42b_a = 1 then 'S' when b.LA_42b_a = 2 then 'R' when b.LA_42b_a = 3 then 'I' end LA_42b, " +
                    " case when b.LA_43a_b = '' then b.LA_43a_b when b.LA_43a_b is null then b.LA_43a_b when b.LA_43a_b = '999' then 'NA' when b.LA_43a_b = '888' then 'NR' end LA_43a_b, " +
                    " b.LA_43a_a, " +
                    " case when b.LA_43b_a = 1 then 'S' when b.LA_43b_a = 2 then 'R' when b.LA_43b_a = 3 then 'I' end LA_43b, " +
                    " case when b.LA_44a_b = '' then b.LA_44a_b when b.LA_44a_b is null then b.LA_44a_b when b.LA_44a_b = '999' then 'NA' when b.LA_44a_b = '888' then 'NR' end LA_44a_b, " +
                    " b.LA_44a_a, " +
                    " case when b.LA_44b_a = 1 then 'S' when b.LA_44b_a = 2 then 'R' when b.LA_44b_a = 3 then 'I' end LA_44b, " +
                    " case when b.LA_45a_b = '' then b.LA_45a_b when b.LA_45a_b is null then b.LA_45a_b when b.LA_45a_b = '999' then 'NA' when b.LA_45a_b = '888' then 'NR' end LA_45a_b, " +
                    " b.LA_45a_a, " +
                    " case when b.LA_45b_a = 1 then 'S' when b.LA_45b_a = 2 then 'R' when b.LA_45b_a = 3 then 'I' end LA_45b, " +
                    " case when b.LA_46a_b = '' then b.LA_46a_b when b.LA_46a_b is null then b.LA_46a_b when b.LA_46a_b = '999' then 'NA' when b.LA_46a_b = '888' then 'NR' end LA_46a_b, " +
                    " b.LA_46a_a, " +
                    " case when b.LA_46b_a = 1 then 'S' when b.LA_46b_a = 2 then 'R' when b.LA_46b_a = 3 then 'I' end LA_46b, " +
                    " case when b.LA_47a_b = '' then b.LA_47a_b when b.LA_47a_b is null then b.LA_47a_b when b.LA_47a_b = '999' then 'NA' when b.LA_47a_b = '888' then 'NR' end LA_47a_b, " +
                    " b.LA_47a_a, " +
                    " case when b.LA_47b_a = 1 then 'S' when b.LA_47b_a = 2 then 'R' when b.LA_47b_a = 3 then 'I' end LA_47b, " +
                    " case when b.LA_48a_b = '' then b.LA_48a_b when b.LA_48a_b is null then b.LA_48a_b when b.LA_48a_b = '999' then 'NA' when b.LA_48a_b = '888' then 'NR' end LA_48a_b, " +
                    " b.LA_48a_a, " +
                    " case when b.LA_48b_a = 1 then 'S' when b.LA_48b_a = 2 then 'R' when b.LA_48b_a = 3 then 'I' end LA_48b, " +
                    " case when b.LA_49a_b = '' then b.LA_49a_b when b.LA_49a_b is null then b.LA_49a_b when b.LA_49a_b = '999' then 'NA' when b.LA_49a_b = '888' then 'NR' end LA_49a_b, " +
                    " b.LA_49a_a, " +
                    " case when b.LA_49b_a = 1 then 'S' when b.LA_49b_a = 2 then 'R' when b.LA_49b_a = 3 then 'I' end LA_49b, " +
                    " case when b.LA_50a_b = '' then b.LA_50a_b when b.LA_50a_b is null then b.LA_50a_b when b.LA_50a_b = '999' then 'NA' when b.LA_50a_b = '888' then 'NR' end LA_50a_b, " +
                    " b.LA_50a_a, " +
                    " case when b.LA_50b_a = 1 then 'S' when b.LA_50b_a = 2 then 'R' when b.LA_50b_a = 3 then 'I' end LA_50b, " +
                    " case when b.LA_51a_b = '' then b.LA_51a_b when b.LA_51a_b is null then b.LA_51a_b when b.LA_51a_b = '999' then 'NA' when b.LA_51a_b = '888' then 'NR' end LA_51a_b, " +
                    " b.LA_51a_a, " +
                    " case when b.LA_51b_a = 1 then 'S' when b.LA_51b_a = 2 then 'R' when b.LA_51b_a = 3 then 'I' end LA_51b, " +
                    " case when b.LA_52a_b = '' then b.LA_52a_b when b.LA_52a_b is null then b.LA_52a_b when b.LA_52a_b = '999' then 'NA' when b.LA_52a_b = '888' then 'NR' end LA_52a_b, " +
                    " b.LA_52a_a, " +
                    " case when b.LA_52b_a = 1 then 'S' when b.LA_52b_a = 2 then 'R' when b.LA_52b_a = 3 then 'I' end LA_52b, " +
                    " (select c.LA_02 from sample_result c where c.la_sno = b.la_sno and c.labid = 2) LA_02, " +
                    " (select c.LA_02a from sample_result c where c.la_sno = b.la_sno and c.labid = 2) LA_02a " +
                    " from form1 a inner join sample_result b on a.AS1_screening_ID = b.la_sno " +
                    " where a.AS2_Q9 between '" + val_startdt + "' and '" + val_enddt + "' and a.labid = 1 and b.labid = 1 and b.rdo_BloodCulture = 1 ";
            }
            else if (!string.IsNullOrEmpty(txtStartDate.Text) && !string.IsNullOrEmpty(txtEndDate.Text) && chkBloodCulture.Checked == false)
            {
                qry = "select b.ID, b.id id1, a.AS1_screening_ID, a.AS1_rand_id, a.AS1_name, a.AS1_age, a.AS1_mrno, a.AS1_lno, convert(varchar(13), AS2_Q9, 103) AS2_Q9, case when rdo_BloodCulture = 1 then 'POS' else 'NEG' end rdo_BloodCulture, " +
                    " case when b.LA_03_a <> '' then b.LA_03_a when b.LA_03_a = '' then '888' when b.LA_03_a = '' then '999' end  LA_03_a, " +
                    " case when b.LA_04_a <> '' then b.LA_04_a when b.LA_04_a = '' then '888' when b.LA_04_a = '' then '999' end  LA_04_a, " +
                    " case when b.LA_05_a <> '' then b.LA_05_a when b.LA_05_a = '' then '888' when b.LA_05_a = '' then '999' end  LA_05_a, " +
                    " case when b.LA_06_a <> '' then b.LA_06_a when b.LA_06_a = '' then '888' when b.LA_06_a = '' then '999' end  LA_06_a, " +
                    " case when b.LA_07_a <> '' then b.LA_07_a when b.LA_07_a = '' then '888' when b.LA_07_a = '' then '999' end  LA_07_a, " +
                    " case when b.LA_08_a <> '' then b.LA_08_a when b.LA_08_a = '' then '888' when b.LA_08_a = '' then '999' end  LA_08_a, " +
                    " case when b.LA_09_a <> '' then b.LA_09_a when b.LA_09_a = '' then '888' when b.LA_09_a = '' then '999' end  LA_09_a, " +
                    " case when b.LA_10_a <> '' then b.LA_10_a when b.LA_10_a = '' then '888' when b.LA_10_a = '' then '999' end  LA_10_a, " +
                    " case when b.LA_11_a <> '' then b.LA_11_a when b.LA_11_a = '' then '888' when b.LA_11_a = '' then '999' end  LA_11_a, " +
                    " case when b.LA_12_a <> '' then b.LA_12_a when b.LA_12_a = '' then '888' when b.LA_12_a = '' then '999' end  LA_12_a, " +
                    " case when b.LA_13_a <> '' then b.LA_13_a when b.LA_13_a = '' then '888' when b.LA_13_a = '' then '999' end  LA_13_a, " +
                    " case when b.LA_14_a <> '' then b.LA_14_a when b.LA_14_a = '' then '888' when b.LA_14_a = '' then '999' end  LA_14_a, " +
                    " case when b.LA_15_a <> '' then b.LA_15_a when b.LA_15_a = '' then '888' when b.LA_15_a = '' then '999' end  LA_15_a, " +
                    " case when b.LA_16_a <> '' then b.LA_16_a when b.LA_16_a = '' then '888' when b.LA_16_a = '' then '999' end  LA_16_a, " +
                    " b.history, " +
                    " b.ProvisionalResult, " +
                    " case when b.rdo_BloodCulture = 1 then 'Yes' else 'No' end rdo_BloodCulture, " +
                    " case when b.ddl_BloodCulture = 1 then 'Escherichia coli' " +
                    " when b.ddl_BloodCulture = 2 then 'Klebsiella pneumoniae' " +
                    " when b.ddl_BloodCulture = 3 then 'Klebsiella species' " +
                    " when b.ddl_BloodCulture = 4 then 'Acinetobacter baumannii' " +
                    " when b.ddl_BloodCulture = 5 then 'Acinetobacter species' " +
                    " when b.ddl_BloodCulture = 6 then 'Salmonella species' " +
                    " when b.ddl_BloodCulture = 7 then 'Salmonella typhi' " +
                    " when b.ddl_BloodCulture = 8 then 'Salmonella paratyphi A' " +
                    " when b.ddl_BloodCulture = 9 then 'Salmonella paratyphi B'  " +
                    " when b.ddl_BloodCulture = 10 then 'Serratia species' " +
                    " when b.ddl_BloodCulture = 11 then 'Serratia marcescens' " +
                    " when b.ddl_BloodCulture = 12 then 'Serratia liquefaciens' " +
                    " when b.ddl_BloodCulture = 13 then 'Staphylococcus epidermidis' " +
                    " when b.ddl_BloodCulture = 14 then 'Staphylococcus saprophyticus' " +
                    " when b.ddl_BloodCulture = 15 then 'Staphylococcus species' " +
                    " when b.ddl_BloodCulture = 16 then 'Micrococcus specie' " +
                    " when b.ddl_BloodCulture = 17 then 'Streptococcus species' " +
                    " when b.ddl_BloodCulture = 18 then 'Streptococcus pyogenes (group A Streptococcus)' " +
                    " when b.ddl_BloodCulture = 19 then 'Streptococcus pneumoniae' " +
                    " when b.ddl_BloodCulture = 20 then 'Streptococcus mitis' " +
                    " when b.ddl_BloodCulture = 21 then 'Campylobacter species' " +
                    " when b.ddl_BloodCulture = 22 then 'Campylobacter jejuni' " +
                    " when b.ddl_BloodCulture = 23 then 'Enterococcus species' " +
                    " when b.ddl_BloodCulture = 24 then 'Corynebacterium species' " +
                    " when b.ddl_BloodCulture = 25 then 'Burkholderia cepacia' " +
                    " when b.ddl_BloodCulture = 26 then 'Neisseria gonorrhoeae' " +
                    " when b.ddl_BloodCulture = 27 then 'Candida species' " +
                    " when b.ddl_BloodCulture = 28 then 'Citrobacter freundii' " +
                    " when b.ddl_BloodCulture = 29 then 'Citrobacter species' " +
                    " when b.ddl_BloodCulture = 30 then 'Bacillus species' " +
                    " when b.ddl_BloodCulture = 32 then 'Others' " +
                    " end ddl_BloodCulture, " +
                    " case when b.rdo_BloodCulture_Multiple = 1 then 'Yes' when b.rdo_BloodCulture_Multiple = 2 then 'No' end BloodCulture_Multiple, " +
                    " b.LA_18, " +
                    " case when b.LA_20a_b = '' then b.LA_20a_b when b.LA_20a_b is null then b.LA_20a_b when b.LA_20a_b = '999' then 'NA' when b.LA_20a_b = '888' then 'NR' end LA_20a_b, " + "b.LA_20a_a, " +
                    " case when b.LA_20b_a = 1 then 'S' when b.LA_20b_a = 2 then 'R' when b.LA_20b_a = 3 then 'I' end LA_20b, " +
                    " case when b.LA_21a_b = '' then b.LA_21a_b when b.LA_21a_b is null then b.LA_21a_b when b.LA_21a_b = '999' then 'NA' when b.LA_21a_b = '888' then 'NR' end LA_21a_b, " +
                    " b.LA_21a_a, " +
                    " case when b.LA_21b_a = 1 then 'S' when b.LA_21b_a = 2 then 'R' when b.LA_21b_a = 3 then 'I' end LA_21b, " +
                    " case when b.LA_22a_b = '' then b.LA_22a_b when b.LA_22a_b is null then b.LA_22a_b when b.LA_22a_b = '999' then 'NA' when b.LA_22a_b = '888' then 'NR' end LA_22a_b, " +
                    " b.LA_22a_a, " +
                    " case when b.LA_22b_a = 1 then 'S' when b.LA_22b_a = 2 then 'R' when b.LA_22b_a = 3 then 'I' end LA_22b, " +
                    " case when b.LA_23a_b = '' then b.LA_23a_b when b.LA_23a_b is null then b.LA_23a_b when b.LA_23a_b = '999' then 'NA' when b.LA_23a_b = '888' then 'NR' end LA_23a_b, " +
                    " b.LA_23a_a, " +
                    " case when b.LA_23b_a = 1 then 'S' when b.LA_23b_a = 2 then 'R' when b.LA_23b_a = 3 then 'I' end LA_23b, " +
                    " case when b.LA_24a_b = '' then b.LA_24a_b when b.LA_24a_b is null then b.LA_24a_b when b.LA_24a_b = '999' then 'NA' when b.LA_24a_b = '888' then 'NR' end LA_24a_b, " +
                    " b.LA_24a_a, " +
                    " case when b.LA_24b_a = 1 then 'S' when b.LA_24b_a = 2 then 'R' when b.LA_24b_a = 3 then 'I' end LA_24b, " +
                    " case when b.LA_25a_b = '' then b.LA_25a_b when b.LA_25a_b is null then b.LA_25a_b when b.LA_25a_b = '999' then 'NA' when b.LA_25a_b = '888' then 'NR' end LA_25a_b, " +
                    " b.LA_25a_a, " +
                    " case when b.LA_25b_a = 1 then 'S' when b.LA_25b_a = 2 then 'R' when b.LA_25b_a = 3 then 'I' end LA_25b, " +
                    " case when b.LA_26a_b = '' then b.LA_26a_b when b.LA_26a_b is null then b.LA_26a_b when b.LA_26a_b = '999' then 'NA' when b.LA_26a_b = '888' then 'NR' end LA_26a_b, " +
                    " b.LA_26a_a, " +
                    " case when b.LA_26b_a = 1 then 'S' when b.LA_26b_a = 2 then 'R' when b.LA_26b_a = 3 then 'I' end LA_26b, " +
                    " case when b.LA_27a_b = '' then b.LA_27a_b when b.LA_27a_b is null then b.LA_27a_b when b.LA_27a_b = '999' then 'NA' when b.LA_27a_b = '888' then 'NR' end LA_27a_b, " +
                    " b.LA_27a_a, " +
                    " case when b.LA_27b_a = 1 then 'S' when b.LA_27b_a = 2 then 'R' when b.LA_27b_a = 3 then 'I' end LA_27b, " +
                    " case when b.LA_28a_b = '' then b.LA_28a_b when b.LA_28a_b is null then b.LA_28a_b when b.LA_28a_b = '999' then 'NA' when b.LA_28a_b = '888' then 'NR' end LA_28a_b, " +
                    " b.LA_28a_a, " +
                    " case when b.LA_28b_a = 1 then 'S' when b.LA_28b_a = 2 then 'R' when b.LA_28b_a = 3 then 'I' end LA_28b, " +
                    " case when b.LA_29a_b = '' then b.LA_29a_b when b.LA_29a_b is null then b.LA_29a_b when b.LA_29a_b = '999' then 'NA' when b.LA_29a_b = '888' then 'NR' end LA_29a_b, " +
                    " b.LA_29a_a, " +
                    " case when b.LA_29b_a = 1 then 'S' when b.LA_29b_a = 2 then 'R' when b.LA_29b_a = 3 then 'I' end LA_29b, " +
                    " case when b.LA_30a_b = '' then b.LA_30a_b when b.LA_30a_b is null then b.LA_30a_b when b.LA_30a_b = '999' then 'NA' when b.LA_30a_b = '888' then 'NR' end LA_30a_b, " +
                    " b.LA_30a_a, " +
                    " case when b.LA_30b_a = 1 then 'S' when b.LA_30b_a = 2 then 'R' when b.LA_30b_a = 3 then 'I' end LA_30b, " +
                    " case when b.LA_31a_b = '' then b.LA_31a_b when b.LA_31a_b is null then b.LA_31a_b when b.LA_31a_b = '999' then 'NA' when b.LA_31a_b = '888' then 'NR' end LA_31a_b, " +
                    " b.LA_31a_a, " +
                    " case when b.LA_31b_a = 1 then 'S' when b.LA_31b_a = 2 then 'R' when b.LA_31b_a = 3 then 'I' end LA_31b, " +
                    " case when b.LA_32a_b = '' then b.LA_32a_b when b.LA_32a_b is null then b.LA_32a_b when b.LA_32a_b = '999' then 'NA' when b.LA_32a_b = '888' then 'NR' end LA_32a_b, " +
                    " b.LA_32a_a, " +
                    " case when b.LA_32b_a = 1 then 'S' when b.LA_32b_a = 2 then 'R' when b.LA_32b_a = 3 then 'I' end LA_32b, " +
                    " case when b.LA_33a_b = '' then b.LA_33a_b when b.LA_33a_b is null then b.LA_33a_b when b.LA_33a_b = '999' then 'NA' when b.LA_33a_b = '888' then 'NR' end LA_33a_b, " +
                    " b.LA_33a_a, " +
                    " case when b.LA_33b_a = 1 then 'S' when b.LA_33b_a = 2 then 'R' when b.LA_33b_a = 3 then 'I' end LA_33b, " +
                    " case when b.LA_34a_b = '' then b.LA_34a_b when b.LA_34a_b is null then b.LA_34a_b when b.LA_34a_b = '999' then 'NA' when b.LA_34a_b = '888' then 'NR' end LA_34a_b, " +
                    " b.LA_34a_a, " +
                    " case when b.LA_34b_a = 1 then 'S' when b.LA_34b_a = 2 then 'R' when b.LA_34b_a = 3 then 'I' end LA_34b, " +
                    " case when b.LA_35a_b = '' then b.LA_35a_b when b.LA_35a_b is null then b.LA_35a_b when b.LA_35a_b = '999' then 'NA' when b.LA_35a_b = '888' then 'NR' end LA_35a_b, " +
                    " b.LA_35a_a, " +
                    " case when b.LA_35b_a = 1 then 'S' when b.LA_35b_a = 2 then 'R' when b.LA_35b_a = 3 then 'I' end LA_35b, " +
                    " case when b.LA_36a_b = '' then b.LA_36a_b when b.LA_36a_b is null then b.LA_36a_b when b.LA_36a_b = '999' then 'NA' when b.LA_36a_b = '888' then 'NR' end LA_36a_b, " +
                    " b.LA_36a_a, " +
                    " case when b.LA_36b_a = 1 then 'S' when b.LA_36b_a = 2 then 'R' when b.LA_36b_a = 3 then 'I' end LA_36b, " +
                    " case when b.LA_37a_b = '' then b.LA_37a_b when b.LA_37a_b is null then b.LA_37a_b when b.LA_37a_b = '999' then 'NA' when b.LA_37a_b = '888' then 'NR' end LA_37a_b, " +
                    " b.LA_37a_a, " +
                    " case when b.LA_37b_a = 1 then 'S' when b.LA_37b_a = 2 then 'R' when b.LA_37b_a = 3 then 'I' end LA_37b, " +
                    " case when b.LA_38a_b = '' then b.LA_38a_b when b.LA_38a_b is null then b.LA_38a_b when b.LA_38a_b = '999' then 'NA' when b.LA_38a_b = '888' then 'NR' end LA_38a_b, " +
                    " b.LA_38a_a, " +
                    " case when b.LA_38b_a = 1 then 'S' when b.LA_38b_a = 2 then 'R' when b.LA_38b_a = 3 then 'I' end LA_38b, " +
                    " case when b.LA_39a_b = '' then b.LA_39a_b when b.LA_39a_b is null then b.LA_39a_b when b.LA_39a_b = '999' then 'NA' when b.LA_39a_b = '888' then 'NR' end LA_39a_b, " +
                    " b.LA_39a_a, " +
                    " case when b.LA_39b_a = 1 then 'S' when b.LA_39b_a = 2 then 'R' when b.LA_39b_a = 3 then 'I' end LA_39b, " +
                    " case when b.LA_40a_b = '' then b.LA_40a_b when b.LA_40a_b is null then b.LA_40a_b when b.LA_40a_b = '999' then 'NA' when b.LA_40a_b = '888' then 'NR' end LA_40a_b, " +
                    " b.LA_40a_a, " +
                    " case when b.LA_40b_a = 1 then 'S' when b.LA_40b_a = 2 then 'R' when b.LA_40b_a = 3 then 'I' end LA_40b, " +
                    " case when b.LA_41a_b = '' then b.LA_41a_b when b.LA_41a_b is null then b.LA_41a_b when b.LA_41a_b = '999' then 'NA' when b.LA_41a_b = '888' then 'NR' end LA_41a_b, " +
                    " b.LA_41a_a, " +
                    " case when b.LA_41b_a = 1 then 'S' when b.LA_41b_a = 2 then 'R' when b.LA_41b_a = 3 then 'I' end LA_41b, " +
                    " case when b.LA_42a_b = '' then b.LA_42a_b when b.LA_42a_b is null then b.LA_42a_b when b.LA_42a_b = '999' then 'NA' when b.LA_42a_b = '888' then 'NR' end LA_42a_b, " +
                    " b.LA_42a_a, " +
                    " case when b.LA_42b_a = 1 then 'S' when b.LA_42b_a = 2 then 'R' when b.LA_42b_a = 3 then 'I' end LA_42b, " +
                    " case when b.LA_43a_b = '' then b.LA_43a_b when b.LA_43a_b is null then b.LA_43a_b when b.LA_43a_b = '999' then 'NA' when b.LA_43a_b = '888' then 'NR' end LA_43a_b, " +
                    " b.LA_43a_a, " +
                    " case when b.LA_43b_a = 1 then 'S' when b.LA_43b_a = 2 then 'R' when b.LA_43b_a = 3 then 'I' end LA_43b, " +
                    " case when b.LA_44a_b = '' then b.LA_44a_b when b.LA_44a_b is null then b.LA_44a_b when b.LA_44a_b = '999' then 'NA' when b.LA_44a_b = '888' then 'NR' end LA_44a_b, " +
                    " b.LA_44a_a, " +
                    " case when b.LA_44b_a = 1 then 'S' when b.LA_44b_a = 2 then 'R' when b.LA_44b_a = 3 then 'I' end LA_44b, " +
                    " case when b.LA_45a_b = '' then b.LA_45a_b when b.LA_45a_b is null then b.LA_45a_b when b.LA_45a_b = '999' then 'NA' when b.LA_45a_b = '888' then 'NR' end LA_45a_b, " +
                    " b.LA_45a_a, " +
                    " case when b.LA_45b_a = 1 then 'S' when b.LA_45b_a = 2 then 'R' when b.LA_45b_a = 3 then 'I' end LA_45b, " +
                    " case when b.LA_46a_b = '' then b.LA_46a_b when b.LA_46a_b is null then b.LA_46a_b when b.LA_46a_b = '999' then 'NA' when b.LA_46a_b = '888' then 'NR' end LA_46a_b, " +
                    " b.LA_46a_a, " +
                    " case when b.LA_46b_a = 1 then 'S' when b.LA_46b_a = 2 then 'R' when b.LA_46b_a = 3 then 'I' end LA_46b, " +
                    " case when b.LA_47a_b = '' then b.LA_47a_b when b.LA_47a_b is null then b.LA_47a_b when b.LA_47a_b = '999' then 'NA' when b.LA_47a_b = '888' then 'NR' end LA_47a_b, " +
                    " b.LA_47a_a, " +
                    " case when b.LA_47b_a = 1 then 'S' when b.LA_47b_a = 2 then 'R' when b.LA_47b_a = 3 then 'I' end LA_47b, " +
                    " case when b.LA_48a_b = '' then b.LA_48a_b when b.LA_48a_b is null then b.LA_48a_b when b.LA_48a_b = '999' then 'NA' when b.LA_48a_b = '888' then 'NR' end LA_48a_b, " +
                    " b.LA_48a_a, " +
                    " case when b.LA_48b_a = 1 then 'S' when b.LA_48b_a = 2 then 'R' when b.LA_48b_a = 3 then 'I' end LA_48b, " +
                    " case when b.LA_49a_b = '' then b.LA_49a_b when b.LA_49a_b is null then b.LA_49a_b when b.LA_49a_b = '999' then 'NA' when b.LA_49a_b = '888' then 'NR' end LA_49a_b, " +
                    " b.LA_49a_a, " +
                    " case when b.LA_49b_a = 1 then 'S' when b.LA_49b_a = 2 then 'R' when b.LA_49b_a = 3 then 'I' end LA_49b, " +
                    " case when b.LA_50a_b = '' then b.LA_50a_b when b.LA_50a_b is null then b.LA_50a_b when b.LA_50a_b = '999' then 'NA' when b.LA_50a_b = '888' then 'NR' end LA_50a_b, " +
                    " b.LA_50a_a, " +
                    " case when b.LA_50b_a = 1 then 'S' when b.LA_50b_a = 2 then 'R' when b.LA_50b_a = 3 then 'I' end LA_50b, " +
                    " case when b.LA_51a_b = '' then b.LA_51a_b when b.LA_51a_b is null then b.LA_51a_b when b.LA_51a_b = '999' then 'NA' when b.LA_51a_b = '888' then 'NR' end LA_51a_b, " +
                    " b.LA_51a_a, " +
                    " case when b.LA_51b_a = 1 then 'S' when b.LA_51b_a = 2 then 'R' when b.LA_51b_a = 3 then 'I' end LA_51b, " +
                    " case when b.LA_52a_b = '' then b.LA_52a_b when b.LA_52a_b is null then b.LA_52a_b when b.LA_52a_b = '999' then 'NA' when b.LA_52a_b = '888' then 'NR' end LA_52a_b, " +
                    " b.LA_52a_a, " +
                    " case when b.LA_52b_a = 1 then 'S' when b.LA_52b_a = 2 then 'R' when b.LA_52b_a = 3 then 'I' end LA_52b, " +
                    " (select c.LA_02 from sample_result c where c.la_sno = b.la_sno and c.labid = 2) LA_02, " +
                    " (select c.LA_02a from sample_result c where c.la_sno = b.la_sno and c.labid = 2) LA_02a " +
                    " from form1 a inner join sample_result b on a.AS1_screening_ID = b.la_sno " +
                    " where a.AS2_Q9 between '" + val_startdt + "' and '" + val_enddt + "' and a.labid = 1 and b.labid = 1 and b.rdo_BloodCulture = 2 ";
            }
            else if (string.IsNullOrEmpty(txtStartDate.Text) && string.IsNullOrEmpty(txtEndDate.Text) && chkBloodCulture.Checked == true)
            {
                qry = "select b.ID, b.id id1, a.AS1_screening_ID, a.AS1_rand_id, a.AS1_name, a.AS1_age, a.AS1_mrno, a.AS1_lno, convert(varchar(13), AS2_Q9, 103) AS2_Q9, case when rdo_BloodCulture = 1 then 'POS' else 'NEG' end rdo_BloodCulture, " +
                    " case when b.LA_03_a <> '' then b.LA_03_a when b.LA_03_a = '' then '888' when b.LA_03_a = '' then '999' end  LA_03_a, " +
                    " case when b.LA_04_a <> '' then b.LA_04_a when b.LA_04_a = '' then '888' when b.LA_04_a = '' then '999' end  LA_04_a, " +
                    " case when b.LA_05_a <> '' then b.LA_05_a when b.LA_05_a = '' then '888' when b.LA_05_a = '' then '999' end  LA_05_a, " +
                    " case when b.LA_06_a <> '' then b.LA_06_a when b.LA_06_a = '' then '888' when b.LA_06_a = '' then '999' end  LA_06_a, " +
                    " case when b.LA_07_a <> '' then b.LA_07_a when b.LA_07_a = '' then '888' when b.LA_07_a = '' then '999' end  LA_07_a, " +
                    " case when b.LA_08_a <> '' then b.LA_08_a when b.LA_08_a = '' then '888' when b.LA_08_a = '' then '999' end  LA_08_a, " +
                    " case when b.LA_09_a <> '' then b.LA_09_a when b.LA_09_a = '' then '888' when b.LA_09_a = '' then '999' end  LA_09_a, " +
                    " case when b.LA_10_a <> '' then b.LA_10_a when b.LA_10_a = '' then '888' when b.LA_10_a = '' then '999' end  LA_10_a, " +
                    " case when b.LA_11_a <> '' then b.LA_11_a when b.LA_11_a = '' then '888' when b.LA_11_a = '' then '999' end  LA_11_a, " +
                    " case when b.LA_12_a <> '' then b.LA_12_a when b.LA_12_a = '' then '888' when b.LA_12_a = '' then '999' end  LA_12_a, " +
                    " case when b.LA_13_a <> '' then b.LA_13_a when b.LA_13_a = '' then '888' when b.LA_13_a = '' then '999' end  LA_13_a, " +
                    " case when b.LA_14_a <> '' then b.LA_14_a when b.LA_14_a = '' then '888' when b.LA_14_a = '' then '999' end  LA_14_a, " +
                    " case when b.LA_15_a <> '' then b.LA_15_a when b.LA_15_a = '' then '888' when b.LA_15_a = '' then '999' end  LA_15_a, " +
                    " case when b.LA_16_a <> '' then b.LA_16_a when b.LA_16_a = '' then '888' when b.LA_16_a = '' then '999' end  LA_16_a, " +
                    " b.history, " +
                    " b.ProvisionalResult, " +
                    " case when b.rdo_BloodCulture = 1 then 'Yes' else 'No' end rdo_BloodCulture, " +
                    " case when b.ddl_BloodCulture = 1 then 'Escherichia coli' " +
                    " when b.ddl_BloodCulture = 2 then 'Klebsiella pneumoniae' " +
                    " when b.ddl_BloodCulture = 3 then 'Klebsiella species' " +
                    " when b.ddl_BloodCulture = 4 then 'Acinetobacter baumannii' " +
                    " when b.ddl_BloodCulture = 5 then 'Acinetobacter species' " +
                    " when b.ddl_BloodCulture = 6 then 'Salmonella species' " +
                    " when b.ddl_BloodCulture = 7 then 'Salmonella typhi' " +
                    " when b.ddl_BloodCulture = 8 then 'Salmonella paratyphi A' " +
                    " when b.ddl_BloodCulture = 9 then 'Salmonella paratyphi B'  " +
                    " when b.ddl_BloodCulture = 10 then 'Serratia species' " +
                    " when b.ddl_BloodCulture = 11 then 'Serratia marcescens' " +
                    " when b.ddl_BloodCulture = 12 then 'Serratia liquefaciens' " +
                    " when b.ddl_BloodCulture = 13 then 'Staphylococcus epidermidis' " +
                    " when b.ddl_BloodCulture = 14 then 'Staphylococcus saprophyticus' " +
                    " when b.ddl_BloodCulture = 15 then 'Staphylococcus species' " +
                    " when b.ddl_BloodCulture = 16 then 'Micrococcus specie' " +
                    " when b.ddl_BloodCulture = 17 then 'Streptococcus species' " +
                    " when b.ddl_BloodCulture = 18 then 'Streptococcus pyogenes (group A Streptococcus)' " +
                    " when b.ddl_BloodCulture = 19 then 'Streptococcus pneumoniae' " +
                    " when b.ddl_BloodCulture = 20 then 'Streptococcus mitis' " +
                    " when b.ddl_BloodCulture = 21 then 'Campylobacter species' " +
                    " when b.ddl_BloodCulture = 22 then 'Campylobacter jejuni' " +
                    " when b.ddl_BloodCulture = 23 then 'Enterococcus species' " +
                    " when b.ddl_BloodCulture = 24 then 'Corynebacterium species' " +
                    " when b.ddl_BloodCulture = 25 then 'Burkholderia cepacia' " +
                    " when b.ddl_BloodCulture = 26 then 'Neisseria gonorrhoeae' " +
                    " when b.ddl_BloodCulture = 27 then 'Candida species' " +
                    " when b.ddl_BloodCulture = 28 then 'Citrobacter freundii' " +
                    " when b.ddl_BloodCulture = 29 then 'Citrobacter species' " +
                    " when b.ddl_BloodCulture = 30 then 'Bacillus species' " +
                    " when b.ddl_BloodCulture = 32 then 'Others' " +
                    " end ddl_BloodCulture, " +
                    " case when b.rdo_BloodCulture_Multiple = 1 then 'Yes' when b.rdo_BloodCulture_Multiple = 2 then 'No' end BloodCulture_Multiple, " +
                    " b.LA_18, " +
                    " case when b.LA_20a_b = '' then b.LA_20a_b when b.LA_20a_b is null then b.LA_20a_b when b.LA_20a_b = '999' then 'NA' when b.LA_20a_b = '888' then 'NR' end LA_20a_b, " + "b.LA_20a_a, " +
                    " case when b.LA_20b_a = 1 then 'S' when b.LA_20b_a = 2 then 'R' when b.LA_20b_a = 3 then 'I' end LA_20b, " +
                    " case when b.LA_21a_b = '' then b.LA_21a_b when b.LA_21a_b is null then b.LA_21a_b when b.LA_21a_b = '999' then 'NA' when b.LA_21a_b = '888' then 'NR' end LA_21a_b, " +
                    " b.LA_21a_a, " +
                    " case when b.LA_21b_a = 1 then 'S' when b.LA_21b_a = 2 then 'R' when b.LA_21b_a = 3 then 'I' end LA_21b, " +
                    " case when b.LA_22a_b = '' then b.LA_22a_b when b.LA_22a_b is null then b.LA_22a_b when b.LA_22a_b = '999' then 'NA' when b.LA_22a_b = '888' then 'NR' end LA_22a_b, " +
                    " b.LA_22a_a, " +
                    " case when b.LA_22b_a = 1 then 'S' when b.LA_22b_a = 2 then 'R' when b.LA_22b_a = 3 then 'I' end LA_22b, " +
                    " case when b.LA_23a_b = '' then b.LA_23a_b when b.LA_23a_b is null then b.LA_23a_b when b.LA_23a_b = '999' then 'NA' when b.LA_23a_b = '888' then 'NR' end LA_23a_b, " +
                    " b.LA_23a_a, " +
                    " case when b.LA_23b_a = 1 then 'S' when b.LA_23b_a = 2 then 'R' when b.LA_23b_a = 3 then 'I' end LA_23b, " +
                    " case when b.LA_24a_b = '' then b.LA_24a_b when b.LA_24a_b is null then b.LA_24a_b when b.LA_24a_b = '999' then 'NA' when b.LA_24a_b = '888' then 'NR' end LA_24a_b, " +
                    " b.LA_24a_a, " +
                    " case when b.LA_24b_a = 1 then 'S' when b.LA_24b_a = 2 then 'R' when b.LA_24b_a = 3 then 'I' end LA_24b, " +
                    " case when b.LA_25a_b = '' then b.LA_25a_b when b.LA_25a_b is null then b.LA_25a_b when b.LA_25a_b = '999' then 'NA' when b.LA_25a_b = '888' then 'NR' end LA_25a_b, " +
                    " b.LA_25a_a, " +
                    " case when b.LA_25b_a = 1 then 'S' when b.LA_25b_a = 2 then 'R' when b.LA_25b_a = 3 then 'I' end LA_25b, " +
                    " case when b.LA_26a_b = '' then b.LA_26a_b when b.LA_26a_b is null then b.LA_26a_b when b.LA_26a_b = '999' then 'NA' when b.LA_26a_b = '888' then 'NR' end LA_26a_b, " +
                    " b.LA_26a_a, " +
                    " case when b.LA_26b_a = 1 then 'S' when b.LA_26b_a = 2 then 'R' when b.LA_26b_a = 3 then 'I' end LA_26b, " +
                    " case when b.LA_27a_b = '' then b.LA_27a_b when b.LA_27a_b is null then b.LA_27a_b when b.LA_27a_b = '999' then 'NA' when b.LA_27a_b = '888' then 'NR' end LA_27a_b, " +
                    " b.LA_27a_a, " +
                    " case when b.LA_27b_a = 1 then 'S' when b.LA_27b_a = 2 then 'R' when b.LA_27b_a = 3 then 'I' end LA_27b, " +
                    " case when b.LA_28a_b = '' then b.LA_28a_b when b.LA_28a_b is null then b.LA_28a_b when b.LA_28a_b = '999' then 'NA' when b.LA_28a_b = '888' then 'NR' end LA_28a_b, " +
                    " b.LA_28a_a, " +
                    " case when b.LA_28b_a = 1 then 'S' when b.LA_28b_a = 2 then 'R' when b.LA_28b_a = 3 then 'I' end LA_28b, " +
                    " case when b.LA_29a_b = '' then b.LA_29a_b when b.LA_29a_b is null then b.LA_29a_b when b.LA_29a_b = '999' then 'NA' when b.LA_29a_b = '888' then 'NR' end LA_29a_b, " +
                    " b.LA_29a_a, " +
                    " case when b.LA_29b_a = 1 then 'S' when b.LA_29b_a = 2 then 'R' when b.LA_29b_a = 3 then 'I' end LA_29b, " +
                    " case when b.LA_30a_b = '' then b.LA_30a_b when b.LA_30a_b is null then b.LA_30a_b when b.LA_30a_b = '999' then 'NA' when b.LA_30a_b = '888' then 'NR' end LA_30a_b, " +
                    " b.LA_30a_a, " +
                    " case when b.LA_30b_a = 1 then 'S' when b.LA_30b_a = 2 then 'R' when b.LA_30b_a = 3 then 'I' end LA_30b, " +
                    " case when b.LA_31a_b = '' then b.LA_31a_b when b.LA_31a_b is null then b.LA_31a_b when b.LA_31a_b = '999' then 'NA' when b.LA_31a_b = '888' then 'NR' end LA_31a_b, " +
                    " b.LA_31a_a, " +
                    " case when b.LA_31b_a = 1 then 'S' when b.LA_31b_a = 2 then 'R' when b.LA_31b_a = 3 then 'I' end LA_31b, " +
                    " case when b.LA_32a_b = '' then b.LA_32a_b when b.LA_32a_b is null then b.LA_32a_b when b.LA_32a_b = '999' then 'NA' when b.LA_32a_b = '888' then 'NR' end LA_32a_b, " +
                    " b.LA_32a_a, " +
                    " case when b.LA_32b_a = 1 then 'S' when b.LA_32b_a = 2 then 'R' when b.LA_32b_a = 3 then 'I' end LA_32b, " +
                    " case when b.LA_33a_b = '' then b.LA_33a_b when b.LA_33a_b is null then b.LA_33a_b when b.LA_33a_b = '999' then 'NA' when b.LA_33a_b = '888' then 'NR' end LA_33a_b, " +
                    " b.LA_33a_a, " +
                    " case when b.LA_33b_a = 1 then 'S' when b.LA_33b_a = 2 then 'R' when b.LA_33b_a = 3 then 'I' end LA_33b, " +
                    " case when b.LA_34a_b = '' then b.LA_34a_b when b.LA_34a_b is null then b.LA_34a_b when b.LA_34a_b = '999' then 'NA' when b.LA_34a_b = '888' then 'NR' end LA_34a_b, " +
                    " b.LA_34a_a, " +
                    " case when b.LA_34b_a = 1 then 'S' when b.LA_34b_a = 2 then 'R' when b.LA_34b_a = 3 then 'I' end LA_34b, " +
                    " case when b.LA_35a_b = '' then b.LA_35a_b when b.LA_35a_b is null then b.LA_35a_b when b.LA_35a_b = '999' then 'NA' when b.LA_35a_b = '888' then 'NR' end LA_35a_b, " +
                    " b.LA_35a_a, " +
                    " case when b.LA_35b_a = 1 then 'S' when b.LA_35b_a = 2 then 'R' when b.LA_35b_a = 3 then 'I' end LA_35b, " +
                    " case when b.LA_36a_b = '' then b.LA_36a_b when b.LA_36a_b is null then b.LA_36a_b when b.LA_36a_b = '999' then 'NA' when b.LA_36a_b = '888' then 'NR' end LA_36a_b, " +
                    " b.LA_36a_a, " +
                    " case when b.LA_36b_a = 1 then 'S' when b.LA_36b_a = 2 then 'R' when b.LA_36b_a = 3 then 'I' end LA_36b, " +
                    " case when b.LA_37a_b = '' then b.LA_37a_b when b.LA_37a_b is null then b.LA_37a_b when b.LA_37a_b = '999' then 'NA' when b.LA_37a_b = '888' then 'NR' end LA_37a_b, " +
                    " b.LA_37a_a, " +
                    " case when b.LA_37b_a = 1 then 'S' when b.LA_37b_a = 2 then 'R' when b.LA_37b_a = 3 then 'I' end LA_37b, " +
                    " case when b.LA_38a_b = '' then b.LA_38a_b when b.LA_38a_b is null then b.LA_38a_b when b.LA_38a_b = '999' then 'NA' when b.LA_38a_b = '888' then 'NR' end LA_38a_b, " +
                    " b.LA_38a_a, " +
                    " case when b.LA_38b_a = 1 then 'S' when b.LA_38b_a = 2 then 'R' when b.LA_38b_a = 3 then 'I' end LA_38b, " +
                    " case when b.LA_39a_b = '' then b.LA_39a_b when b.LA_39a_b is null then b.LA_39a_b when b.LA_39a_b = '999' then 'NA' when b.LA_39a_b = '888' then 'NR' end LA_39a_b, " +
                    " b.LA_39a_a, " +
                    " case when b.LA_39b_a = 1 then 'S' when b.LA_39b_a = 2 then 'R' when b.LA_39b_a = 3 then 'I' end LA_39b, " +
                    " case when b.LA_40a_b = '' then b.LA_40a_b when b.LA_40a_b is null then b.LA_40a_b when b.LA_40a_b = '999' then 'NA' when b.LA_40a_b = '888' then 'NR' end LA_40a_b, " +
                    " b.LA_40a_a, " +
                    " case when b.LA_40b_a = 1 then 'S' when b.LA_40b_a = 2 then 'R' when b.LA_40b_a = 3 then 'I' end LA_40b, " +
                    " case when b.LA_41a_b = '' then b.LA_41a_b when b.LA_41a_b is null then b.LA_41a_b when b.LA_41a_b = '999' then 'NA' when b.LA_41a_b = '888' then 'NR' end LA_41a_b, " +
                    " b.LA_41a_a, " +
                    " case when b.LA_41b_a = 1 then 'S' when b.LA_41b_a = 2 then 'R' when b.LA_41b_a = 3 then 'I' end LA_41b, " +
                    " case when b.LA_42a_b = '' then b.LA_42a_b when b.LA_42a_b is null then b.LA_42a_b when b.LA_42a_b = '999' then 'NA' when b.LA_42a_b = '888' then 'NR' end LA_42a_b, " +
                    " b.LA_42a_a, " +
                    " case when b.LA_42b_a = 1 then 'S' when b.LA_42b_a = 2 then 'R' when b.LA_42b_a = 3 then 'I' end LA_42b, " +
                    " case when b.LA_43a_b = '' then b.LA_43a_b when b.LA_43a_b is null then b.LA_43a_b when b.LA_43a_b = '999' then 'NA' when b.LA_43a_b = '888' then 'NR' end LA_43a_b, " +
                    " b.LA_43a_a, " +
                    " case when b.LA_43b_a = 1 then 'S' when b.LA_43b_a = 2 then 'R' when b.LA_43b_a = 3 then 'I' end LA_43b, " +
                    " case when b.LA_44a_b = '' then b.LA_44a_b when b.LA_44a_b is null then b.LA_44a_b when b.LA_44a_b = '999' then 'NA' when b.LA_44a_b = '888' then 'NR' end LA_44a_b, " +
                    " b.LA_44a_a, " +
                    " case when b.LA_44b_a = 1 then 'S' when b.LA_44b_a = 2 then 'R' when b.LA_44b_a = 3 then 'I' end LA_44b, " +
                    " case when b.LA_45a_b = '' then b.LA_45a_b when b.LA_45a_b is null then b.LA_45a_b when b.LA_45a_b = '999' then 'NA' when b.LA_45a_b = '888' then 'NR' end LA_45a_b, " +
                    " b.LA_45a_a, " +
                    " case when b.LA_45b_a = 1 then 'S' when b.LA_45b_a = 2 then 'R' when b.LA_45b_a = 3 then 'I' end LA_45b, " +
                    " case when b.LA_46a_b = '' then b.LA_46a_b when b.LA_46a_b is null then b.LA_46a_b when b.LA_46a_b = '999' then 'NA' when b.LA_46a_b = '888' then 'NR' end LA_46a_b, " +
                    " b.LA_46a_a, " +
                    " case when b.LA_46b_a = 1 then 'S' when b.LA_46b_a = 2 then 'R' when b.LA_46b_a = 3 then 'I' end LA_46b, " +
                    " case when b.LA_47a_b = '' then b.LA_47a_b when b.LA_47a_b is null then b.LA_47a_b when b.LA_47a_b = '999' then 'NA' when b.LA_47a_b = '888' then 'NR' end LA_47a_b, " +
                    " b.LA_47a_a, " +
                    " case when b.LA_47b_a = 1 then 'S' when b.LA_47b_a = 2 then 'R' when b.LA_47b_a = 3 then 'I' end LA_47b, " +
                    " case when b.LA_48a_b = '' then b.LA_48a_b when b.LA_48a_b is null then b.LA_48a_b when b.LA_48a_b = '999' then 'NA' when b.LA_48a_b = '888' then 'NR' end LA_48a_b, " +
                    " b.LA_48a_a, " +
                    " case when b.LA_48b_a = 1 then 'S' when b.LA_48b_a = 2 then 'R' when b.LA_48b_a = 3 then 'I' end LA_48b, " +
                    " case when b.LA_49a_b = '' then b.LA_49a_b when b.LA_49a_b is null then b.LA_49a_b when b.LA_49a_b = '999' then 'NA' when b.LA_49a_b = '888' then 'NR' end LA_49a_b, " +
                    " b.LA_49a_a, " +
                    " case when b.LA_49b_a = 1 then 'S' when b.LA_49b_a = 2 then 'R' when b.LA_49b_a = 3 then 'I' end LA_49b, " +
                    " case when b.LA_50a_b = '' then b.LA_50a_b when b.LA_50a_b is null then b.LA_50a_b when b.LA_50a_b = '999' then 'NA' when b.LA_50a_b = '888' then 'NR' end LA_50a_b, " +
                    " b.LA_50a_a, " +
                    " case when b.LA_50b_a = 1 then 'S' when b.LA_50b_a = 2 then 'R' when b.LA_50b_a = 3 then 'I' end LA_50b, " +
                    " case when b.LA_51a_b = '' then b.LA_51a_b when b.LA_51a_b is null then b.LA_51a_b when b.LA_51a_b = '999' then 'NA' when b.LA_51a_b = '888' then 'NR' end LA_51a_b, " +
                    " b.LA_51a_a, " +
                    " case when b.LA_51b_a = 1 then 'S' when b.LA_51b_a = 2 then 'R' when b.LA_51b_a = 3 then 'I' end LA_51b, " +
                    " case when b.LA_52a_b = '' then b.LA_52a_b when b.LA_52a_b is null then b.LA_52a_b when b.LA_52a_b = '999' then 'NA' when b.LA_52a_b = '888' then 'NR' end LA_52a_b, " +
                    " b.LA_52a_a, " +
                    " case when b.LA_52b_a = 1 then 'S' when b.LA_52b_a = 2 then 'R' when b.LA_52b_a = 3 then 'I' end LA_52b, " +
                    " (select c.LA_02 from sample_result c where c.la_sno = b.la_sno and c.labid = 2) LA_02, " +
                    " (select c.LA_02a from sample_result c where c.la_sno = b.la_sno and c.labid = 2) LA_02a " +
                    " from form1 a inner join sample_result b on a.AS1_screening_ID = b.la_sno " +
                    " where a.labid = 1 and b.labid = 1 and b.rdo_BloodCulture = 1 ";
            }
            else
            {
                qry = "select b.ID, b.id id1, a.AS1_screening_ID, a.AS1_rand_id, a.AS1_name, a.AS1_age, a.AS1_mrno, a.AS1_lno, convert(varchar(13), AS2_Q9, 103) AS2_Q9, case when rdo_BloodCulture = 1 then 'POS' else 'NEG' end rdo_BloodCulture, " +
                    " case when b.LA_03_a <> '' then b.LA_03_a when b.LA_03_a = '' then '888' when b.LA_03_a = '' then '999' end  LA_03_a, " +
                    " case when b.LA_04_a <> '' then b.LA_04_a when b.LA_04_a = '' then '888' when b.LA_04_a = '' then '999' end  LA_04_a, " +
                    " case when b.LA_05_a <> '' then b.LA_05_a when b.LA_05_a = '' then '888' when b.LA_05_a = '' then '999' end  LA_05_a, " +
                    " case when b.LA_06_a <> '' then b.LA_06_a when b.LA_06_a = '' then '888' when b.LA_06_a = '' then '999' end  LA_06_a, " +
                    " case when b.LA_07_a <> '' then b.LA_07_a when b.LA_07_a = '' then '888' when b.LA_07_a = '' then '999' end  LA_07_a, " +
                    " case when b.LA_08_a <> '' then b.LA_08_a when b.LA_08_a = '' then '888' when b.LA_08_a = '' then '999' end  LA_08_a, " +
                    " case when b.LA_09_a <> '' then b.LA_09_a when b.LA_09_a = '' then '888' when b.LA_09_a = '' then '999' end  LA_09_a, " +
                    " case when b.LA_10_a <> '' then b.LA_10_a when b.LA_10_a = '' then '888' when b.LA_10_a = '' then '999' end  LA_10_a, " +
                    " case when b.LA_11_a <> '' then b.LA_11_a when b.LA_11_a = '' then '888' when b.LA_11_a = '' then '999' end  LA_11_a, " +
                    " case when b.LA_12_a <> '' then b.LA_12_a when b.LA_12_a = '' then '888' when b.LA_12_a = '' then '999' end  LA_12_a, " +
                    " case when b.LA_13_a <> '' then b.LA_13_a when b.LA_13_a = '' then '888' when b.LA_13_a = '' then '999' end  LA_13_a, " +
                    " case when b.LA_14_a <> '' then b.LA_14_a when b.LA_14_a = '' then '888' when b.LA_14_a = '' then '999' end  LA_14_a, " +
                    " case when b.LA_15_a <> '' then b.LA_15_a when b.LA_15_a = '' then '888' when b.LA_15_a = '' then '999' end  LA_15_a, " +
                    " case when b.LA_16_a <> '' then b.LA_16_a when b.LA_16_a = '' then '888' when b.LA_16_a = '' then '999' end  LA_16_a, " +
                    " b.history, " +
                    " b.ProvisionalResult, " +
                    " case when b.rdo_BloodCulture = 1 then 'Yes' else 'No' end rdo_BloodCulture, " +
                    " case when b.ddl_BloodCulture = 1 then 'Escherichia coli' " +
                    " when b.ddl_BloodCulture = 2 then 'Klebsiella pneumoniae' " +
                    " when b.ddl_BloodCulture = 3 then 'Klebsiella species' " +
                    " when b.ddl_BloodCulture = 4 then 'Acinetobacter baumannii' " +
                    " when b.ddl_BloodCulture = 5 then 'Acinetobacter species' " +
                    " when b.ddl_BloodCulture = 6 then 'Salmonella species' " +
                    " when b.ddl_BloodCulture = 7 then 'Salmonella typhi' " +
                    " when b.ddl_BloodCulture = 8 then 'Salmonella paratyphi A' " +
                    " when b.ddl_BloodCulture = 9 then 'Salmonella paratyphi B'  " +
                    " when b.ddl_BloodCulture = 10 then 'Serratia species' " +
                    " when b.ddl_BloodCulture = 11 then 'Serratia marcescens' " +
                    " when b.ddl_BloodCulture = 12 then 'Serratia liquefaciens' " +
                    " when b.ddl_BloodCulture = 13 then 'Staphylococcus epidermidis' " +
                    " when b.ddl_BloodCulture = 14 then 'Staphylococcus saprophyticus' " +
                    " when b.ddl_BloodCulture = 15 then 'Staphylococcus species' " +
                    " when b.ddl_BloodCulture = 16 then 'Micrococcus specie' " +
                    " when b.ddl_BloodCulture = 17 then 'Streptococcus species' " +
                    " when b.ddl_BloodCulture = 18 then 'Streptococcus pyogenes (group A Streptococcus)' " +
                    " when b.ddl_BloodCulture = 19 then 'Streptococcus pneumoniae' " +
                    " when b.ddl_BloodCulture = 20 then 'Streptococcus mitis' " +
                    " when b.ddl_BloodCulture = 21 then 'Campylobacter species' " +
                    " when b.ddl_BloodCulture = 22 then 'Campylobacter jejuni' " +
                    " when b.ddl_BloodCulture = 23 then 'Enterococcus species' " +
                    " when b.ddl_BloodCulture = 24 then 'Corynebacterium species' " +
                    " when b.ddl_BloodCulture = 25 then 'Burkholderia cepacia' " +
                    " when b.ddl_BloodCulture = 26 then 'Neisseria gonorrhoeae' " +
                    " when b.ddl_BloodCulture = 27 then 'Candida species' " +
                    " when b.ddl_BloodCulture = 28 then 'Citrobacter freundii' " +
                    " when b.ddl_BloodCulture = 29 then 'Citrobacter species' " +
                    " when b.ddl_BloodCulture = 30 then 'Bacillus species' " +
                    " when b.ddl_BloodCulture = 32 then 'Others' " +
                    " end ddl_BloodCulture, " +
                    " case when b.rdo_BloodCulture_Multiple = 1 then 'Yes' when b.rdo_BloodCulture_Multiple = 2 then 'No' end BloodCulture_Multiple, " +
                    " b.LA_18, " +
                    " case when b.LA_20a_b = '' then b.LA_20a_b when b.LA_20a_b is null then b.LA_20a_b when b.LA_20a_b = '999' then 'NA' when b.LA_20a_b = '888' then 'NR' end LA_20a_b, " + "b.LA_20a_a, " +
                    " case when b.LA_20b_a = 1 then 'S' when b.LA_20b_a = 2 then 'R' when b.LA_20b_a = 3 then 'I' end LA_20b, " +
                    " case when b.LA_21a_b = '' then b.LA_21a_b when b.LA_21a_b is null then b.LA_21a_b when b.LA_21a_b = '999' then 'NA' when b.LA_21a_b = '888' then 'NR' end LA_21a_b, " +
                    " b.LA_21a_a, " +
                    " case when b.LA_21b_a = 1 then 'S' when b.LA_21b_a = 2 then 'R' when b.LA_21b_a = 3 then 'I' end LA_21b, " +
                    " case when b.LA_22a_b = '' then b.LA_22a_b when b.LA_22a_b is null then b.LA_22a_b when b.LA_22a_b = '999' then 'NA' when b.LA_22a_b = '888' then 'NR' end LA_22a_b, " +
                    " b.LA_22a_a, " +
                    " case when b.LA_22b_a = 1 then 'S' when b.LA_22b_a = 2 then 'R' when b.LA_22b_a = 3 then 'I' end LA_22b, " +
                    " case when b.LA_23a_b = '' then b.LA_23a_b when b.LA_23a_b is null then b.LA_23a_b when b.LA_23a_b = '999' then 'NA' when b.LA_23a_b = '888' then 'NR' end LA_23a_b, " +
                    " b.LA_23a_a, " +
                    " case when b.LA_23b_a = 1 then 'S' when b.LA_23b_a = 2 then 'R' when b.LA_23b_a = 3 then 'I' end LA_23b, " +
                    " case when b.LA_24a_b = '' then b.LA_24a_b when b.LA_24a_b is null then b.LA_24a_b when b.LA_24a_b = '999' then 'NA' when b.LA_24a_b = '888' then 'NR' end LA_24a_b, " +
                    " b.LA_24a_a, " +
                    " case when b.LA_24b_a = 1 then 'S' when b.LA_24b_a = 2 then 'R' when b.LA_24b_a = 3 then 'I' end LA_24b, " +
                    " case when b.LA_25a_b = '' then b.LA_25a_b when b.LA_25a_b is null then b.LA_25a_b when b.LA_25a_b = '999' then 'NA' when b.LA_25a_b = '888' then 'NR' end LA_25a_b, " +
                    " b.LA_25a_a, " +
                    " case when b.LA_25b_a = 1 then 'S' when b.LA_25b_a = 2 then 'R' when b.LA_25b_a = 3 then 'I' end LA_25b, " +
                    " case when b.LA_26a_b = '' then b.LA_26a_b when b.LA_26a_b is null then b.LA_26a_b when b.LA_26a_b = '999' then 'NA' when b.LA_26a_b = '888' then 'NR' end LA_26a_b, " +
                    " b.LA_26a_a, " +
                    " case when b.LA_26b_a = 1 then 'S' when b.LA_26b_a = 2 then 'R' when b.LA_26b_a = 3 then 'I' end LA_26b, " +
                    " case when b.LA_27a_b = '' then b.LA_27a_b when b.LA_27a_b is null then b.LA_27a_b when b.LA_27a_b = '999' then 'NA' when b.LA_27a_b = '888' then 'NR' end LA_27a_b, " +
                    " b.LA_27a_a, " +
                    " case when b.LA_27b_a = 1 then 'S' when b.LA_27b_a = 2 then 'R' when b.LA_27b_a = 3 then 'I' end LA_27b, " +
                    " case when b.LA_28a_b = '' then b.LA_28a_b when b.LA_28a_b is null then b.LA_28a_b when b.LA_28a_b = '999' then 'NA' when b.LA_28a_b = '888' then 'NR' end LA_28a_b, " +
                    " b.LA_28a_a, " +
                    " case when b.LA_28b_a = 1 then 'S' when b.LA_28b_a = 2 then 'R' when b.LA_28b_a = 3 then 'I' end LA_28b, " +
                    " case when b.LA_29a_b = '' then b.LA_29a_b when b.LA_29a_b is null then b.LA_29a_b when b.LA_29a_b = '999' then 'NA' when b.LA_29a_b = '888' then 'NR' end LA_29a_b, " +
                    " b.LA_29a_a, " +
                    " case when b.LA_29b_a = 1 then 'S' when b.LA_29b_a = 2 then 'R' when b.LA_29b_a = 3 then 'I' end LA_29b, " +
                    " case when b.LA_30a_b = '' then b.LA_30a_b when b.LA_30a_b is null then b.LA_30a_b when b.LA_30a_b = '999' then 'NA' when b.LA_30a_b = '888' then 'NR' end LA_30a_b, " +
                    " b.LA_30a_a, " +
                    " case when b.LA_30b_a = 1 then 'S' when b.LA_30b_a = 2 then 'R' when b.LA_30b_a = 3 then 'I' end LA_30b, " +
                    " case when b.LA_31a_b = '' then b.LA_31a_b when b.LA_31a_b is null then b.LA_31a_b when b.LA_31a_b = '999' then 'NA' when b.LA_31a_b = '888' then 'NR' end LA_31a_b, " +
                    " b.LA_31a_a, " +
                    " case when b.LA_31b_a = 1 then 'S' when b.LA_31b_a = 2 then 'R' when b.LA_31b_a = 3 then 'I' end LA_31b, " +
                    " case when b.LA_32a_b = '' then b.LA_32a_b when b.LA_32a_b is null then b.LA_32a_b when b.LA_32a_b = '999' then 'NA' when b.LA_32a_b = '888' then 'NR' end LA_32a_b, " +
                    " b.LA_32a_a, " +
                    " case when b.LA_32b_a = 1 then 'S' when b.LA_32b_a = 2 then 'R' when b.LA_32b_a = 3 then 'I' end LA_32b, " +
                    " case when b.LA_33a_b = '' then b.LA_33a_b when b.LA_33a_b is null then b.LA_33a_b when b.LA_33a_b = '999' then 'NA' when b.LA_33a_b = '888' then 'NR' end LA_33a_b, " +
                    " b.LA_33a_a, " +
                    " case when b.LA_33b_a = 1 then 'S' when b.LA_33b_a = 2 then 'R' when b.LA_33b_a = 3 then 'I' end LA_33b, " +
                    " case when b.LA_34a_b = '' then b.LA_34a_b when b.LA_34a_b is null then b.LA_34a_b when b.LA_34a_b = '999' then 'NA' when b.LA_34a_b = '888' then 'NR' end LA_34a_b, " +
                    " b.LA_34a_a, " +
                    " case when b.LA_34b_a = 1 then 'S' when b.LA_34b_a = 2 then 'R' when b.LA_34b_a = 3 then 'I' end LA_34b, " +
                    " case when b.LA_35a_b = '' then b.LA_35a_b when b.LA_35a_b is null then b.LA_35a_b when b.LA_35a_b = '999' then 'NA' when b.LA_35a_b = '888' then 'NR' end LA_35a_b, " +
                    " b.LA_35a_a, " +
                    " case when b.LA_35b_a = 1 then 'S' when b.LA_35b_a = 2 then 'R' when b.LA_35b_a = 3 then 'I' end LA_35b, " +
                    " case when b.LA_36a_b = '' then b.LA_36a_b when b.LA_36a_b is null then b.LA_36a_b when b.LA_36a_b = '999' then 'NA' when b.LA_36a_b = '888' then 'NR' end LA_36a_b, " +
                    " b.LA_36a_a, " +
                    " case when b.LA_36b_a = 1 then 'S' when b.LA_36b_a = 2 then 'R' when b.LA_36b_a = 3 then 'I' end LA_36b, " +
                    " case when b.LA_37a_b = '' then b.LA_37a_b when b.LA_37a_b is null then b.LA_37a_b when b.LA_37a_b = '999' then 'NA' when b.LA_37a_b = '888' then 'NR' end LA_37a_b, " +
                    " b.LA_37a_a, " +
                    " case when b.LA_37b_a = 1 then 'S' when b.LA_37b_a = 2 then 'R' when b.LA_37b_a = 3 then 'I' end LA_37b, " +
                    " case when b.LA_38a_b = '' then b.LA_38a_b when b.LA_38a_b is null then b.LA_38a_b when b.LA_38a_b = '999' then 'NA' when b.LA_38a_b = '888' then 'NR' end LA_38a_b, " +
                    " b.LA_38a_a, " +
                    " case when b.LA_38b_a = 1 then 'S' when b.LA_38b_a = 2 then 'R' when b.LA_38b_a = 3 then 'I' end LA_38b, " +
                    " case when b.LA_39a_b = '' then b.LA_39a_b when b.LA_39a_b is null then b.LA_39a_b when b.LA_39a_b = '999' then 'NA' when b.LA_39a_b = '888' then 'NR' end LA_39a_b, " +
                    " b.LA_39a_a, " +
                    " case when b.LA_39b_a = 1 then 'S' when b.LA_39b_a = 2 then 'R' when b.LA_39b_a = 3 then 'I' end LA_39b, " +
                    " case when b.LA_40a_b = '' then b.LA_40a_b when b.LA_40a_b is null then b.LA_40a_b when b.LA_40a_b = '999' then 'NA' when b.LA_40a_b = '888' then 'NR' end LA_40a_b, " +
                    " b.LA_40a_a, " +
                    " case when b.LA_40b_a = 1 then 'S' when b.LA_40b_a = 2 then 'R' when b.LA_40b_a = 3 then 'I' end LA_40b, " +
                    " case when b.LA_41a_b = '' then b.LA_41a_b when b.LA_41a_b is null then b.LA_41a_b when b.LA_41a_b = '999' then 'NA' when b.LA_41a_b = '888' then 'NR' end LA_41a_b, " +
                    " b.LA_41a_a, " +
                    " case when b.LA_41b_a = 1 then 'S' when b.LA_41b_a = 2 then 'R' when b.LA_41b_a = 3 then 'I' end LA_41b, " +
                    " case when b.LA_42a_b = '' then b.LA_42a_b when b.LA_42a_b is null then b.LA_42a_b when b.LA_42a_b = '999' then 'NA' when b.LA_42a_b = '888' then 'NR' end LA_42a_b, " +
                    " b.LA_42a_a, " +
                    " case when b.LA_42b_a = 1 then 'S' when b.LA_42b_a = 2 then 'R' when b.LA_42b_a = 3 then 'I' end LA_42b, " +
                    " case when b.LA_43a_b = '' then b.LA_43a_b when b.LA_43a_b is null then b.LA_43a_b when b.LA_43a_b = '999' then 'NA' when b.LA_43a_b = '888' then 'NR' end LA_43a_b, " +
                    " b.LA_43a_a, " +
                    " case when b.LA_43b_a = 1 then 'S' when b.LA_43b_a = 2 then 'R' when b.LA_43b_a = 3 then 'I' end LA_43b, " +
                    " case when b.LA_44a_b = '' then b.LA_44a_b when b.LA_44a_b is null then b.LA_44a_b when b.LA_44a_b = '999' then 'NA' when b.LA_44a_b = '888' then 'NR' end LA_44a_b, " +
                    " b.LA_44a_a, " +
                    " case when b.LA_44b_a = 1 then 'S' when b.LA_44b_a = 2 then 'R' when b.LA_44b_a = 3 then 'I' end LA_44b, " +
                    " case when b.LA_45a_b = '' then b.LA_45a_b when b.LA_45a_b is null then b.LA_45a_b when b.LA_45a_b = '999' then 'NA' when b.LA_45a_b = '888' then 'NR' end LA_45a_b, " +
                    " b.LA_45a_a, " +
                    " case when b.LA_45b_a = 1 then 'S' when b.LA_45b_a = 2 then 'R' when b.LA_45b_a = 3 then 'I' end LA_45b, " +
                    " case when b.LA_46a_b = '' then b.LA_46a_b when b.LA_46a_b is null then b.LA_46a_b when b.LA_46a_b = '999' then 'NA' when b.LA_46a_b = '888' then 'NR' end LA_46a_b, " +
                    " b.LA_46a_a, " +
                    " case when b.LA_46b_a = 1 then 'S' when b.LA_46b_a = 2 then 'R' when b.LA_46b_a = 3 then 'I' end LA_46b, " +
                    " case when b.LA_47a_b = '' then b.LA_47a_b when b.LA_47a_b is null then b.LA_47a_b when b.LA_47a_b = '999' then 'NA' when b.LA_47a_b = '888' then 'NR' end LA_47a_b, " +
                    " b.LA_47a_a, " +
                    " case when b.LA_47b_a = 1 then 'S' when b.LA_47b_a = 2 then 'R' when b.LA_47b_a = 3 then 'I' end LA_47b, " +
                    " case when b.LA_48a_b = '' then b.LA_48a_b when b.LA_48a_b is null then b.LA_48a_b when b.LA_48a_b = '999' then 'NA' when b.LA_48a_b = '888' then 'NR' end LA_48a_b, " +
                    " b.LA_48a_a, " +
                    " case when b.LA_48b_a = 1 then 'S' when b.LA_48b_a = 2 then 'R' when b.LA_48b_a = 3 then 'I' end LA_48b, " +
                    " case when b.LA_49a_b = '' then b.LA_49a_b when b.LA_49a_b is null then b.LA_49a_b when b.LA_49a_b = '999' then 'NA' when b.LA_49a_b = '888' then 'NR' end LA_49a_b, " +
                    " b.LA_49a_a, " +
                    " case when b.LA_49b_a = 1 then 'S' when b.LA_49b_a = 2 then 'R' when b.LA_49b_a = 3 then 'I' end LA_49b, " +
                    " case when b.LA_50a_b = '' then b.LA_50a_b when b.LA_50a_b is null then b.LA_50a_b when b.LA_50a_b = '999' then 'NA' when b.LA_50a_b = '888' then 'NR' end LA_50a_b, " +
                    " b.LA_50a_a, " +
                    " case when b.LA_50b_a = 1 then 'S' when b.LA_50b_a = 2 then 'R' when b.LA_50b_a = 3 then 'I' end LA_50b, " +
                    " case when b.LA_51a_b = '' then b.LA_51a_b when b.LA_51a_b is null then b.LA_51a_b when b.LA_51a_b = '999' then 'NA' when b.LA_51a_b = '888' then 'NR' end LA_51a_b, " +
                    " b.LA_51a_a, " +
                    " case when b.LA_51b_a = 1 then 'S' when b.LA_51b_a = 2 then 'R' when b.LA_51b_a = 3 then 'I' end LA_51b, " +
                    " case when b.LA_52a_b = '' then b.LA_52a_b when b.LA_52a_b is null then b.LA_52a_b when b.LA_52a_b = '999' then 'NA' when b.LA_52a_b = '888' then 'NR' end LA_52a_b, " +
                    " b.LA_52a_a, " +
                    " case when b.LA_52b_a = 1 then 'S' when b.LA_52b_a = 2 then 'R' when b.LA_52b_a = 3 then 'I' end LA_52b, " +
                    " (select c.LA_02 from sample_result c where c.la_sno = b.la_sno and c.labid = 2) LA_02, " +
                    " (select c.LA_02a from sample_result c where c.la_sno = b.la_sno and c.labid = 2) LA_02a " +
                    " from form1 a inner join sample_result b on a.AS1_screening_ID = b.la_sno where a.labid = 1 and b.labid = 1 ";
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
        if (Request.Cookies["labid"].Value == "3")
        {
            ExportData_ToExcel_Physician();
        }
        else
        {
            ExportData_ToExcel();
        }
    }


    private void ExportData_ToExcel_Physician()
    {
        if (dg_BloodCulture.Rows.Count <= 0)
        {
            lblerr.Text = "Please search records first";
        }
        else
        {
            dg_BloodCulture.Columns[23].Visible = true;
            dg_BloodCulture.Columns[24].Visible = true;


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

            dg_BloodCulture.Columns[23].Visible = false;
            dg_BloodCulture.Columns[24].Visible = false;
        }
    }


    private void ExportData_ToExcel()
    {
        if (dg_BloodCulture.Rows.Count <= 0)
        {
            lblerr.Text = "Please search records first";
        }
        else
        {
            dg_BloodCulture.Columns[9].Visible = true;
            dg_BloodCulture.Columns[10].Visible = true;
            dg_BloodCulture.Columns[11].Visible = true;
            dg_BloodCulture.Columns[12].Visible = true;
            dg_BloodCulture.Columns[13].Visible = true;
            dg_BloodCulture.Columns[14].Visible = true;
            dg_BloodCulture.Columns[15].Visible = true;
            dg_BloodCulture.Columns[16].Visible = true;
            dg_BloodCulture.Columns[17].Visible = true;
            dg_BloodCulture.Columns[18].Visible = true;
            dg_BloodCulture.Columns[19].Visible = true;
            dg_BloodCulture.Columns[20].Visible = true;
            dg_BloodCulture.Columns[21].Visible = true;
            dg_BloodCulture.Columns[22].Visible = true;


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

            dg_BloodCulture.Columns[9].Visible = false;
            dg_BloodCulture.Columns[10].Visible = false;
            dg_BloodCulture.Columns[11].Visible = false;
            dg_BloodCulture.Columns[12].Visible = false;
            dg_BloodCulture.Columns[13].Visible = false;
            dg_BloodCulture.Columns[14].Visible = false;
            dg_BloodCulture.Columns[15].Visible = false;
            dg_BloodCulture.Columns[16].Visible = false;
            dg_BloodCulture.Columns[17].Visible = false;
            dg_BloodCulture.Columns[18].Visible = false;
            dg_BloodCulture.Columns[19].Visible = false;
            dg_BloodCulture.Columns[20].Visible = false;
            dg_BloodCulture.Columns[21].Visible = false;
            dg_BloodCulture.Columns[22].Visible = false;
        }
    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

}