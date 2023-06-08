using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.Web.Services;
using System.Runtime.InteropServices;
using System.Drawing;
using System.ServiceModel.Configuration;
using System.Globalization;

public partial class sample_recv : System.Web.UI.Page
{
    public List<CountryInfo> CountryInformation { get; set; }

    public class CountryInfo
    {
        public string AS1_screening_ID { get; set; }
        public string AS1_rand_id { get; set; }
        public string AS1_name { get; set; }
        public string AS1_sex { get; set; }
        public string AS1_age { get; set; }
        public string AS1_barcode { get; set; }
        public string AS1_fsite { get; set; }
        public string AS1_Q1_1 { get; set; }
    }

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
        }

        if (!IsPostBack)
        {
            //IsTestingServer();

            if (Request.Cookies["labid"].Value == "2")
            {
                cmdSave.OnClientClick = "return ValidateForm_NRL();";
            }
            else
            {
                cmdSave.OnClientClick = "return ValidateForm();";
            }

            cmdSaveDraft.OnClientClick = "return ValidateForm1();";


            if (Request.Cookies["labid"].Value == "3")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Permission Error", "alert('You are not authorize to view this web page')", false);
                Response.Redirect("login.aspx?errmsg=You are not authorize to view this web page");
                return;
            }


            if (Request.Cookies["labid"].Value == "1" && Request.QueryString["id"] != null)
            {
                ViewState["id"] = Request.QueryString["id"].ToString();
                ViewState["isupdate"] = "1";


                AS1_Q3a_11.Checked = false;
                AS1_Q3a_12.Checked = false;

                AS1_Q3a_11.Visible = false;
                AS1_Q3a_12.Visible = false;

                AS1_Q3a_11.Enabled = false;
                AS1_Q3a_12.Enabled = false;

                AS2_Q8a_1.Checked = false;
                AS2_Q8a_2.Checked = false;

                AS2_Q8a_1.Visible = false;
                AS2_Q8a_2.Visible = false;

                AS2_Q8a_1.Enabled = false;
                AS2_Q8a_2.Enabled = false;


                AS1_Q3a_2.Visible = true;
                AS1_Q3a_2.Enabled = true;


                pnl_AS1_Q3a_1.Visible = false;
                pnl_AS1_Q3a_2.Visible = true;
                pnl_AS2_Q8a.Visible = false;

                Enable_IDRL_Questions();

                pnl_AS1_Samp_1.Visible = true;
                pnl_AS1_Samp_4.Visible = false;


                pnl_AS2_Q12_4.Visible = false;
                AS2_Q12_4.Text = "";
                AS2_Q12_4.Visible = false;
                AS2_Q12_4.Enabled = false;


                pnl_AS1_Q6.Visible = false;


                EnableControls(AS1_Q4);
                EnableControls(AS1_Q5);
                EnableControls(AS1_Q6);
                EnableControls(AS1_Q6a);
                EnableControls(AS1_Q6b);
                EnableControls(AS1_Q6c);



                pnl_AS2_Q13a.Visible = false;
                AS2_Q13a.Text = "";
                AS2_Q13a.Enabled = false;
                AS2_Q13a.Visible = false;

                pnl_AS3_Q14.Visible = true;
                EnableControls(AS3_Q14);
                EnableControls(AS3_Q14a);
                EnableControls(AS3_Q15);
                EnableControls(AS3_Q16);
                EnableControls(AS3_Q17);
                EnableControls(AS3_Q18);
                EnableControls(AS3_Q19);
                EnableControls(AS3_Q20);


                pnl_AS4_Q21a.Visible = true;
                pnl_AS2_Q12_1.Visible = true;





                pnl_AS5_Q25a.Visible = true;

                EnableControls(AS5_Q25a);
                EnableControls(AS5_Q25b);
                EnableControls(AS5_Q26);

                Enable_RadioButton(AS5_Q27_1);
                Enable_RadioButton(AS5_Q27_2);

                Enable_RadioButton(AS5_Q28_1);
                Enable_RadioButton(AS5_Q28_2);

                Enable_RadioButton(AS5_Q29_1);
                Enable_RadioButton(AS5_Q29_2);
                Enable_RadioButton(AS5_Q29_3);

                Enable_RadioButton(AS5_Q30_1);
                Enable_RadioButton(AS5_Q30_2);
                Enable_RadioButton(AS5_Q30_3);

                Enable_RadioButton(AS5_Q31_1);
                Enable_RadioButton(AS5_Q31_2);
                Enable_RadioButton(AS5_Q31_3);
                Enable_RadioButton(AS5_Q31_4);

                Enable_RadioButton(AS5_Q32_1);
                Enable_RadioButton(AS5_Q32_2);
                Enable_RadioButton(AS5_Q32_3);

                EnableControls(AS5_Q33a);
                EnableControls(AS5_Q33b);
                EnableControls(AS3_Remarks);




                pnl_lyari_sample.Visible = true;

                EnableControls(AS6_Q34);
                EnableControls(AS6_Q35);
                EnableControls(AS6_Q36);
                EnableControls(AS6_Q37);
                EnableControls(AS6_Q38);
                EnableControls(AS6_Q39);
                EnableControls(AS6_Q40);
                EnableControls(AS6_Q41);
                EnableControls(AS6_Q42);
                EnableControls(AS6_Q43);
                EnableControls(AS6_Q44);
                EnableControls(AS6_Q45);
                EnableControls(AS6_Q46);
                EnableControls(AS6_Q47);
                EnableControls(AS5_R1);


                pnl_sign.Visible = true;

                EnableControls(AS3_A1);
                EnableControls(AS3_A2);
                EnableControls(AS3_B1);
                EnableControls(AS3_B2);


                getData();
            }
            else if (Request.Cookies["labid"].Value == "2")
            {
                AS1_Q3a_11.Visible = true;
                AS1_Q3a_11.Enabled = true;

                AS1_Q3a_12.Visible = true;
                AS1_Q3a_12.Enabled = true;


                AS1_Q3b_11.Visible = true;
                AS1_Q3b_11.Enabled = true;

                AS1_Q3b_12.Visible = true;
                AS1_Q3b_12.Enabled = true;



                AS1_Q3a_2.Text = "";
                AS1_Q3a_2.Visible = false;
                AS1_Q3a_2.Enabled = false;

                AS2_Q8a_1.Visible = true;
                AS2_Q8a_2.Visible = true;

                AS2_Q8a_1.Enabled = true;
                AS2_Q8a_2.Enabled = true;



                AS2_Q8b_1.Visible = true;
                AS2_Q8b_2.Visible = true;

                AS2_Q8b_1.Enabled = true;
                AS2_Q8b_2.Enabled = true;



                pnl_AS1_Q3a_1.Visible = true;
                pnl_AS1_Q3a_2.Visible = false;
                pnl_AS2_Q8a.Visible = true;


                Disable_IDRL_Questions();

                pnl_AS1_Samp_1.Visible = false;
                pnl_AS1_Samp_4.Visible = true;

                pnl_AS2_Q12_4.Visible = true;


                pnl_AS1_Q6.Visible = false;

                DisableControls(AS1_Q4);
                DisableControls(AS1_Q5);
                DisableControls(AS1_Q6);
                DisableControls(AS1_Q6a);
                DisableControls(AS1_Q6b);
                DisableControls(AS1_Q6c);



                pnl_AS2_Q13a.Visible = true;

                pnl_AS3_Q14.Visible = false;
                DisableControls(AS3_Q14);
                DisableControls(AS3_Q14a);
                DisableControls(AS3_Q15);
                DisableControls(AS3_Q16);
                DisableControls(AS3_Q17);
                DisableControls(AS3_Q18);
                DisableControls(AS3_Q19);
                DisableControls(AS3_Q20);

                pnl_AS4_Q21a.Visible = false;
                AS4_Q21a.Checked = false;
                AS4_Q21a.Visible = false;
                AS4_Q21a.Enabled = false;

                DisableControls(AS4_Q22a);
                DisableControls(AS4_Q22b);
                DisableControls(AS4_Q23);
                DisableControls(AS4_Q24);




                pnl_AS5_Q25a.Visible = false;

                DisableControls(AS5_Q25a);
                DisableControls(AS5_Q25b);
                DisableControls(AS5_Q26);

                Disable_RadioButton(AS5_Q27_1);
                Disable_RadioButton(AS5_Q27_2);

                Disable_RadioButton(AS5_Q28_1);
                Disable_RadioButton(AS5_Q28_2);

                Disable_RadioButton(AS5_Q29_1);
                Disable_RadioButton(AS5_Q29_2);
                Disable_RadioButton(AS5_Q29_3);

                Disable_RadioButton(AS5_Q30_1);
                Disable_RadioButton(AS5_Q30_2);
                Disable_RadioButton(AS5_Q30_3);

                Disable_RadioButton(AS5_Q31_1);
                Disable_RadioButton(AS5_Q31_2);
                Disable_RadioButton(AS5_Q31_3);
                Disable_RadioButton(AS5_Q31_4);

                Disable_RadioButton(AS5_Q32_1);
                Disable_RadioButton(AS5_Q32_2);
                Disable_RadioButton(AS5_Q32_3);

                DisableControls(AS5_Q33a);
                DisableControls(AS5_Q33b);
                DisableControls(AS3_Remarks);


                pnl_lyari_sample.Visible = false;

                DisableControls(AS6_Q34);
                DisableControls(AS6_Q35);
                DisableControls(AS6_Q36);
                DisableControls(AS6_Q37);
                DisableControls(AS6_Q38);
                DisableControls(AS6_Q39);
                DisableControls(AS6_Q40);
                DisableControls(AS6_Q41);
                DisableControls(AS6_Q42);
                DisableControls(AS6_Q43);
                DisableControls(AS6_Q44);
                DisableControls(AS6_Q45);
                DisableControls(AS6_Q46);
                DisableControls(AS6_Q47);
                DisableControls(AS5_R1);


                pnl_AS2_Q12_1.Visible = false;

                //DisableControls(AS2_Q12_1);
                DisableControls(AS2_Q12_2);
                DisableControls(AS2_Q12_3);


                pnl_sign.Visible = false;

                DisableControls(AS3_A1);
                DisableControls(AS3_A2);
                DisableControls(AS3_B1);
                DisableControls(AS3_B2);


            }
            else
            {

                AS1_Q3a_11.Checked = false;
                AS1_Q3a_12.Checked = false;

                AS1_Q3a_11.Visible = false;
                AS1_Q3a_12.Visible = false;

                AS1_Q3a_11.Enabled = false;
                AS1_Q3a_12.Enabled = false;

                AS2_Q8a_1.Checked = false;
                AS2_Q8a_2.Checked = false;

                AS2_Q8a_1.Visible = false;
                AS2_Q8a_2.Visible = false;

                AS2_Q8a_1.Enabled = false;
                AS2_Q8a_2.Enabled = false;


                AS1_Q3a_2.Visible = true;
                AS1_Q3a_2.Enabled = true;


                pnl_AS1_Q3a_1.Visible = false;
                pnl_AS1_Q3a_2.Visible = true;
                pnl_AS2_Q8a.Visible = false;

                Enable_IDRL_Questions();

                pnl_AS1_Samp_1.Visible = true;
                pnl_AS1_Samp_4.Visible = false;


                pnl_AS2_Q12_4.Visible = false;
                AS2_Q12_4.Text = "";
                AS2_Q12_4.Visible = false;
                AS2_Q12_4.Enabled = false;


                pnl_AS1_Q6.Visible = false;


                EnableControls(AS1_Q4);
                EnableControls(AS1_Q5);
                EnableControls(AS1_Q6);
                EnableControls(AS1_Q6a);
                EnableControls(AS1_Q6b);
                EnableControls(AS1_Q6c);



                pnl_AS2_Q13a.Visible = false;
                AS2_Q13a.Text = "";
                AS2_Q13a.Enabled = false;
                AS2_Q13a.Visible = false;

                pnl_AS3_Q14.Visible = true;
                EnableControls(AS3_Q14);
                EnableControls(AS3_Q14a);
                EnableControls(AS3_Q15);
                EnableControls(AS3_Q16);
                EnableControls(AS3_Q17);
                EnableControls(AS3_Q18);
                EnableControls(AS3_Q19);
                EnableControls(AS3_Q20);


                pnl_AS4_Q21a.Visible = true;
                pnl_AS2_Q12_1.Visible = true;





                pnl_AS5_Q25a.Visible = true;

                EnableControls(AS5_Q25a);
                EnableControls(AS5_Q25b);
                EnableControls(AS5_Q26);

                Enable_RadioButton(AS5_Q27_1);
                Enable_RadioButton(AS5_Q27_2);

                Enable_RadioButton(AS5_Q28_1);
                Enable_RadioButton(AS5_Q28_2);

                Enable_RadioButton(AS5_Q29_1);
                Enable_RadioButton(AS5_Q29_2);
                Enable_RadioButton(AS5_Q29_3);

                Enable_RadioButton(AS5_Q30_1);
                Enable_RadioButton(AS5_Q30_2);
                Enable_RadioButton(AS5_Q30_3);

                Enable_RadioButton(AS5_Q31_1);
                Enable_RadioButton(AS5_Q31_2);
                Enable_RadioButton(AS5_Q31_3);
                Enable_RadioButton(AS5_Q31_4);

                Enable_RadioButton(AS5_Q32_1);
                Enable_RadioButton(AS5_Q32_2);
                Enable_RadioButton(AS5_Q32_3);

                EnableControls(AS5_Q33a);
                EnableControls(AS5_Q33b);
                EnableControls(AS3_Remarks);




                pnl_lyari_sample.Visible = true;

                EnableControls(AS6_Q34);
                EnableControls(AS6_Q35);
                EnableControls(AS6_Q36);
                EnableControls(AS6_Q37);
                EnableControls(AS6_Q38);
                EnableControls(AS6_Q39);
                EnableControls(AS6_Q40);
                EnableControls(AS6_Q41);
                EnableControls(AS6_Q42);
                EnableControls(AS6_Q43);
                EnableControls(AS6_Q44);
                EnableControls(AS6_Q45);
                EnableControls(AS6_Q46);
                EnableControls(AS6_Q47);
                EnableControls(AS5_R1);


                pnl_sign.Visible = true;

                EnableControls(AS3_A1);
                EnableControls(AS3_A2);
                EnableControls(AS3_B1);
                EnableControls(AS3_B2);

            }

        }

    }



    private void getData()
    {
        CConnection cn = null;

        try
        {
            cn = new CConnection();

            SqlDataAdapter da = new SqlDataAdapter("select " +
    "b.AS1_screening_ID," +
    "b.AS1_rand_id," +
    "b.AS1_name," +
    "b.AS1_sex," +
    "b.AS1_age," +
    "b.AS1_barcode," +
    "b.AS1_mrno," +
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
    "[AS1_Q3]," +
    "[AS1_Q3a_1]," +
    "[AS1_Q3a_1a]," +
    "[AS1_Q3b_1]," +
    "[AS1_Q3a_2]," +
    "[AS1_Q4]," +
    "[AS1_Q5]," +
    "[AS1_Q6]," +
    "[AS1_Q6a]," +
    "[AS1_Q6b]," +
    "[AS1_Q6c]," +
    "[AS2_Q7_1]," +
    "[AS2_Q7_2]," +
    "[AS2_Q7_CBC_CODE]," +
    "[AS2_Q8]," +
    "[AS2_Q8_BacT]," +
    "[AS2_Q8_3]," +
    "[AS2_Q8a]," +
    "[AS2_Q8b]," +
    "convert(varchar(13), [AS2_Q9], 103) AS2_Q9," +
    "convert(varchar(5), [AS2_Q10], 114) [AS2_Q10]," +
    "[AS2_Q11]," +
    "[AS2_Q12_1]," +
    "[AS2_Q12_2]," +
    "[AS2_Q12_3]," +
    "[AS2_Q12_4]," +
    "[AS2_Q13]," +
    "[AS2_Q13a]," +
    "[AS3_Q14]," +
    "convert(varchar(13), [AS3_Q14a], 103) [AS3_Q14a]," +
    "convert(varchar(5), [AS3_Q15], 114) AS3_Q15," +
    "[AS3_Q16]," +
    "convert(varchar(5), [AS3_Q17], 114) [AS3_Q17]," +
    "[AS3_Q18]," +
    "[AS3_Q19]," +
    "convert(varchar(5), [AS3_Q20], 114) [AS3_Q20]," +
    "[AS4_Q21a]," +
    "convert(varchar(5), [AS4_Q22a], 114) [AS4_Q22a]," +
    "convert(varchar(13), [AS4_Q22b], 103) [AS4_Q22b]," +
    "[AS4_Q23]," +
    "convert(varchar(5), [AS4_Q24], 114) [AS4_Q24]," +
    "[AS5_Q25a]," +
    "[AS5_Q25b]," +
    "[AS5_Q26]," +
    "[AS5_Q27]," +
    "[AS5_Q28]," +
    "[AS5_Q29]," +
    "[AS5_Q30]," +
    "[AS5_Q31]," +
    "[AS5_Q32]," +
    "[AS5_Q33a]," +
    "[AS5_Q33b]," +
    "[AS3_Remarks]," +
    "[AS6_Q34]," +
    "[AS6_Q35]," +
    "[AS6_Q36]," +
    "[AS6_Q37]," +
    "[AS6_Q38]," +
    "[AS6_Q39]," +
    "[AS6_Q40]," +
    "[AS6_Q41]," +
    "[AS6_Q42]," +
    "[AS6_Q43]," +
    "[AS6_Q44]," +
    "[AS6_Q45]," +
    "[AS6_Q46]," +
    "[AS6_Q47]," +
    "[AS5_R1]," +
    "[AS3_A1]," +
    "convert(varchar(13), [AS3_A2], 103) [AS3_A2]," +
    "[AS3_B1]," +
    "convert(varchar(13), [AS3_B2], 103) [AS3_B2]," +
    "[AS1_lno]," +
    "[AS2_Q7_2a]," +
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
    "a.uc_01a," +
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
            " from sample_result a inner join form1 b on a.la_sno = b.AS1_screening_ID where b.id = '" + ViewState["id"].ToString() + "'", cn.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);


            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        AS1_screening_ID.Text = ds.Tables[0].Rows[0]["AS1_screening_ID"].ToString();
                        AS1_rand_id.Text = ds.Tables[0].Rows[0]["AS1_rand_id"].ToString();
                        AS1_name.Text = ds.Tables[0].Rows[0]["AS1_name"].ToString();

                        if (ds.Tables[0].Rows[0]["AS1_sex"].ToString() == "1")
                        {
                            AS1_sex_a.Checked = true;
                        }
                        else
                        {
                            AS1_sex_b.Checked = true;
                        }

                        AS1_age.Text = ds.Tables[0].Rows[0]["AS1_age"].ToString();
                        AS1_barcode.Text = ds.Tables[0].Rows[0]["AS1_barcode"].ToString();


                        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["AS1_mrno"].ToString()))
                        {
                            AS1_mrno.Text = ds.Tables[0].Rows[0]["AS1_mrno"].ToString();
                            chkMRNo.Checked = false;
                            AS1_mrno.CssClass = "form-control";
                        }
                        else
                        {
                            chkMRNo.Checked = true;
                            AS1_mrno.CssClass = "form-control";
                            AS1_mrno.Enabled = false;
                        }


                        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["AS1_lno"].ToString()))
                        {
                            AS1_lno.Text = ds.Tables[0].Rows[0]["AS1_lno"].ToString();
                            chkLNumber.Checked = false;
                            AS1_mrno.CssClass = "form-control";
                        }
                        else
                        {
                            chkLNumber.Checked = true;
                            AS1_lno.CssClass = "form-control";
                            AS1_lno.Enabled = false;
                        }


                        AS1_barcode1.Text = ds.Tables[0].Rows[0]["AS1_barcode1"].ToString();

                        if (ds.Tables[0].Rows[0]["AS1_fsite"].ToString() == "1")
                        {
                            AS1_fsite_1.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS1_fsite"].ToString() == "2")
                        {
                            AS1_fsite_2.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS1_fsite"].ToString() == "3")
                        {
                            AS1_fsite_3.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS1_fsite"].ToString() == "4")
                        {
                            AS1_fsite_4.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS1_fsite"].ToString() == "5")
                        {
                            AS1_fsite_5.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS1_fsite"].ToString() == "6")
                        {
                            AS1_fsite_6.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS1_fsite"].ToString() == "7")
                        {
                            AS1_fsite_7.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["AS1_Samp_1"].ToString() == "1")
                        {
                            AS1_Samp_1.Checked = true;
                        }

                        if (ds.Tables[0].Rows[0]["AS1_Samp_2"].ToString() == "2")
                        {
                            AS1_Samp_2.Checked = true;
                        }

                        if (ds.Tables[0].Rows[0]["AS1_Samp_3"].ToString() == "3")
                        {
                            AS1_Samp_3.Checked = true;
                        }

                        if (ds.Tables[0].Rows[0]["AS1_Samp_4"].ToString() == "4")
                        {
                            AS1_Samp_4.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["AS1_Q1_1"].ToString() == "1")
                        {
                            AS1_Q1_11.Checked = true;
                            AS1_Q1_11_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["AS1_Q1_1"].ToString() == "2")
                        {
                            AS1_Q1_12.Checked = true;
                            AS1_Q1_12_CheckedChanged(null, null);
                        }



                        AS1_Q1_2.Text = ds.Tables[0].Rows[0]["AS1_Q1_2"].ToString();
                        AS1_Q2_2.Text = ds.Tables[0].Rows[0]["AS1_Q2_2"].ToString();
                        AS1_Q3a_2.Text = ds.Tables[0].Rows[0]["AS1_Q3a_2"].ToString();


                        if (ds.Tables[0].Rows[0]["AS2_Q7_1"].ToString() == "1")
                        {
                            AS2_Q7_11.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS2_Q7_1"].ToString() == "2")
                        {
                            AS2_Q7_12.Checked = true;
                        }


                        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["AS2_Q7_2a"].ToString()))
                        {
                            AS2_Q7_2a.Text = ds.Tables[0].Rows[0]["AS2_Q7_2a"].ToString();
                            chk_AS2_Q7_2a.Checked = false;
                            AS2_Q7_2a.Enabled = true;
                        }
                        else
                        {
                            chk_AS2_Q7_2a.Checked = true;
                            AS2_Q7_2a.Enabled = false;
                            AS2_Q7_2a.CssClass = "form-control";
                        }



                        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["AS2_Q7_2"].ToString()))
                        {
                            AS2_Q7_2.Text = ds.Tables[0].Rows[0]["AS2_Q7_2"].ToString();
                            AS2_Q7_2.Enabled = true;
                            chk_AS2_Q7_2.Checked = false;
                        }
                        else
                        {
                            AS2_Q7_2.Enabled = false;
                            AS2_Q7_2.CssClass = "form-control";
                            chk_AS2_Q7_2.Checked = true;
                        }



                        AS2_Q7_CBC_CODE.Text = ds.Tables[0].Rows[0]["AS2_Q7_CBC_CODE"].ToString();


                        if (ds.Tables[0].Rows[0]["AS2_Q8"].ToString() == "1")
                        {
                            AS2_Q8_1.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS2_Q8"].ToString() == "2")
                        {
                            AS2_Q8_1.Checked = true;
                        }

                        AS2_Q8_BacT.Text = ds.Tables[0].Rows[0]["AS2_Q8_BacT"].ToString();
                        AS2_Q8_3.Text = ds.Tables[0].Rows[0]["AS2_Q8_3"].ToString();
                        AS2_Q9.Text = ds.Tables[0].Rows[0]["AS2_Q9"].ToString();
                        AS2_Q10.Text = ds.Tables[0].Rows[0]["AS2_Q10"].ToString();



                        if (ds.Tables[0].Rows[0]["AS2_Q11"].ToString() == "1")
                        {
                            AS2_Q11_1.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS2_Q11"].ToString() == "2")
                        {
                            AS2_Q11_2.Checked = true;
                        }

                        AS2_Q12_2.Text = ds.Tables[0].Rows[0]["AS2_Q12_2"].ToString();
                        AS2_Q12_3.Text = ds.Tables[0].Rows[0]["AS2_Q12_3"].ToString();
                        AS2_Q13.Text = ds.Tables[0].Rows[0]["AS2_Q13"].ToString();
                        AS3_Q14.Text = ds.Tables[0].Rows[0]["AS3_Q14"].ToString();
                        AS3_Q14a.Text = ds.Tables[0].Rows[0]["AS3_Q14a"].ToString();
                        AS3_Q15.Text = ds.Tables[0].Rows[0]["AS3_Q15"].ToString();
                        AS3_Q16.Text = ds.Tables[0].Rows[0]["AS3_Q16"].ToString();
                        AS3_Q17.Text = ds.Tables[0].Rows[0]["AS3_Q17"].ToString();
                        AS3_Q18.Text = ds.Tables[0].Rows[0]["AS3_Q18"].ToString();
                        AS3_Q19.Text = ds.Tables[0].Rows[0]["AS3_Q19"].ToString();
                        AS3_Q20.Text = ds.Tables[0].Rows[0]["AS3_Q20"].ToString();



                        if (ds.Tables[0].Rows[0]["AS4_Q21a"].ToString() == "1")
                        {
                            AS4_Q21a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS4_Q21a"].ToString() == "2")
                        {
                            AS4_Q21a.Checked = false;
                        }

                        AS4_Q22a.Text = ds.Tables[0].Rows[0]["AS4_Q22a"].ToString();
                        AS4_Q22b.Text = ds.Tables[0].Rows[0]["AS4_Q22b"].ToString();
                        AS4_Q23.Text = ds.Tables[0].Rows[0]["AS4_Q23"].ToString();
                        AS4_Q24.Text = ds.Tables[0].Rows[0]["AS4_Q24"].ToString();
                        AS5_Q25a.Text = ds.Tables[0].Rows[0]["AS5_Q25a"].ToString();
                        AS5_Q25b.Text = ds.Tables[0].Rows[0]["AS5_Q25b"].ToString();
                        AS5_Q26.Text = ds.Tables[0].Rows[0]["AS5_Q26"].ToString();



                        if (ds.Tables[0].Rows[0]["AS5_Q27"].ToString() == "1")
                        {
                            AS5_Q27_1.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS5_Q27"].ToString() == "2")
                        {
                            AS5_Q27_2.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["AS5_Q28"].ToString() == "1")
                        {
                            AS5_Q28_1.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS5_Q28"].ToString() == "2")
                        {
                            AS5_Q28_2.Checked = true;
                        }



                        if (ds.Tables[0].Rows[0]["AS5_Q29"].ToString() == "1")
                        {
                            AS5_Q29_1.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS5_Q29"].ToString() == "2")
                        {
                            AS5_Q29_2.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS5_Q29"].ToString() == "3")
                        {
                            AS5_Q29_3.Checked = true;
                        }



                        if (ds.Tables[0].Rows[0]["AS5_Q30"].ToString() == "1")
                        {
                            AS5_Q30_1.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS5_Q30"].ToString() == "2")
                        {
                            AS5_Q30_2.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS5_Q30"].ToString() == "3")
                        {
                            AS5_Q30_3.Checked = true;
                        }



                        if (ds.Tables[0].Rows[0]["AS5_Q31"].ToString() == "1")
                        {
                            AS5_Q31_1.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS5_Q31"].ToString() == "2")
                        {
                            AS5_Q31_2.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS5_Q31"].ToString() == "3")
                        {
                            AS5_Q31_3.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS5_Q31"].ToString() == "4")
                        {
                            AS5_Q31_4.Checked = true;
                        }



                        if (ds.Tables[0].Rows[0]["AS5_Q32"].ToString() == "1")
                        {
                            AS5_Q32_1.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS5_Q32"].ToString() == "2")
                        {
                            AS5_Q32_2.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AS5_Q32"].ToString() == "3")
                        {
                            AS5_Q32_3.Checked = true;
                        }



                        AS5_Q33a.Text = ds.Tables[0].Rows[0]["AS5_Q33a"].ToString();
                        AS5_Q33b.Text = ds.Tables[0].Rows[0]["AS5_Q33b"].ToString();
                        AS3_Remarks.Text = ds.Tables[0].Rows[0]["AS3_Remarks"].ToString();
                        AS6_Q34.Text = ds.Tables[0].Rows[0]["AS6_Q34"].ToString();
                        AS6_Q35.Text = ds.Tables[0].Rows[0]["AS6_Q35"].ToString();
                        AS6_Q36.Text = ds.Tables[0].Rows[0]["AS6_Q36"].ToString();
                        AS6_Q37.Text = ds.Tables[0].Rows[0]["AS6_Q37"].ToString();
                        AS6_Q38.Text = ds.Tables[0].Rows[0]["AS6_Q38"].ToString();
                        AS6_Q39.Text = ds.Tables[0].Rows[0]["AS6_Q39"].ToString();
                        AS6_Q40.Text = ds.Tables[0].Rows[0]["AS6_Q40"].ToString();
                        AS6_Q41.Text = ds.Tables[0].Rows[0]["AS6_Q41"].ToString();
                        AS6_Q42.Text = ds.Tables[0].Rows[0]["AS6_Q42"].ToString();
                        AS6_Q43.Text = ds.Tables[0].Rows[0]["AS6_Q43"].ToString();
                        AS6_Q44.Text = ds.Tables[0].Rows[0]["AS6_Q44"].ToString();
                        AS6_Q45.Text = ds.Tables[0].Rows[0]["AS6_Q45"].ToString();
                        AS6_Q46.Text = ds.Tables[0].Rows[0]["AS6_Q46"].ToString();
                        AS6_Q47.Text = ds.Tables[0].Rows[0]["AS6_Q47"].ToString();
                        AS5_R1.Text = ds.Tables[0].Rows[0]["AS5_R1"].ToString();
                        AS3_A1.Text = ds.Tables[0].Rows[0]["AS3_A1"].ToString();
                        AS3_A2.Text = ds.Tables[0].Rows[0]["AS3_A2"].ToString();
                        AS3_B1.Text = ds.Tables[0].Rows[0]["AS3_B1"].ToString();
                        AS3_B2.Text = ds.Tables[0].Rows[0]["AS3_B2"].ToString();

                    }
                }
            }
        }

        catch (Exception ex)
        {
            string message = "alert('" + ex.Message.Replace("'", "") + "');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
        }

        finally
        {
            cn = null;
        }
    }



    private void IsTestingServer()
    {
        if (Request.Url.Authority != "pedres2.aku.edu")
        {
            //lbl_testing.InnerText = Server.MachineName;
            lbl_testing.Visible = true;
            Div15.InnerText = "Testing Entries";
            Div15.Style.Add(HtmlTextWriterStyle.Color, "#FF0000");
            Div15.Style.Add(HtmlTextWriterStyle.FontSize, "15pt");
            Div15.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
        }
        else
        {
            lbl_testing.Visible = false;
            lbl_testing.InnerText = "";
        }
    }


    private void Disable_IDRL_Questions()
    {
        Disable_RadioButton(AS1_Q1_11);
        Disable_RadioButton(AS1_Q1_12);

        DisableControls(AS1_Q1_2);

        Disable_RadioButton(AS1_Q2_11);
        Disable_RadioButton(AS1_Q2_12);

        Disable_RadioButton(AS2_Q7_11);
        Disable_RadioButton(AS2_Q7_12);

        DisableControls(AS2_Q7_2);
        DisableControls(AS2_Q7_CBC_CODE);

        Disable_RadioButton(AS2_Q8_1);
        Disable_RadioButton(AS2_Q8_2);

        DisableControls(AS2_Q8_BacT);
        DisableControls(AS2_Q8_3);


        DisableControls(AS3_Q14);
        DisableControls(AS3_Q15);
        DisableControls(AS3_Q16);
        //DisableControls(AS3_Q17);
        //DisableControls(AS3_Q18);
        //DisableControls(AS3_Q19);
        DisableControls(AS3_Q20);


        pnl_AS1_Q1_11.Visible = false;
        pnl_AS2_Q7_1.Visible = false;

    }



    private void Enable_IDRL_Questions()
    {
        Enable_RadioButton(AS1_Q1_11);
        Enable_RadioButton(AS1_Q1_12);

        EnableControls(AS1_Q1_2);

        Enable_RadioButton(AS1_Q2_11);
        Enable_RadioButton(AS1_Q2_12);

        Enable_RadioButton(AS2_Q7_11);
        Enable_RadioButton(AS2_Q7_12);

        EnableControls(AS2_Q7_2);
        EnableControls(AS2_Q7_CBC_CODE);

        Enable_RadioButton(AS2_Q8_1);
        Enable_RadioButton(AS2_Q8_2);

        EnableControls(AS2_Q8_BacT);
        EnableControls(AS2_Q8_3);


        EnableControls(AS3_Q14);
        EnableControls(AS3_Q15);
        EnableControls(AS3_Q16);
        //EnableControls(AS3_Q17);
        //EnableControls(AS3_Q18);
        //EnableControls(AS3_Q19);
        EnableControls(AS3_Q20);


        pnl_AS1_Q1_11.Visible = true;
        pnl_AS2_Q7_1.Visible = true;

    }



    private void Enable_RadioButton(RadioButton rdo)
    {
        rdo.Visible = true;
        rdo.Enabled = true;
    }


    private void Disable_RadioButton(RadioButton rdo)
    {
        rdo.Checked = false;
        rdo.Visible = false;
        rdo.Enabled = false;
    }



    private void EnableControls(TextBox rdo)
    {
        rdo.Visible = true;
        rdo.Enabled = true;
    }


    private void DisableControls(TextBox rdo)
    {
        rdo.Text = "";
        rdo.Visible = false;
        rdo.Enabled = false;
    }



    private void EnableControls1(TextBox rdo)
    {
        rdo.Enabled = true;
    }


    private void DisableControls1(TextBox rdo)
    {
        rdo.Text = "";
        rdo.Enabled = false;
        rdo.CssClass = "form-control";
    }



    private void Enable_RadioButton1(RadioButton rdo)
    {
        rdo.Enabled = true;
    }


    private void Disable_RadioButton1(RadioButton rdo)
    {
        rdo.Checked = false;
        rdo.Enabled = false;
    }



    protected void cmdSave_Click(object sender, EventArgs e)
    {
        if (ViewState["isupdate"] == null)
        {
            SaveData();
        }
        else
        {
            if (AuditTrials())
            {
                UpdateData();
            }
        }
    }



    private void SaveData(object sender, EventArgs e)
    {

        CDBOperations obj_op = new CDBOperations();

        string var_AS1_screening_ID = "";
        string var_AS1_rand_id = "";
        string var_AS1_name = "";
        string var_AS1_sex = "";
        string var_AS1_age = "";
        string var_AS1_barcode = "";
        string var_AS1_fsite = "";
        string var_AS1_Samp = "";

        string var_AS1_Samp_1 = "";
        string var_AS1_Samp_2 = "";
        string var_AS1_Samp_3 = "";
        string var_AS1_Samp_4 = "";

        string var_AS1_Q1_1 = "";
        string var_AS1_Q1_2 = "";
        string var_AS1_Q2_1 = "";
        string var_AS1_Q2_2 = "";
        string var_AS1_Q3 = "";
        string var_AS1_Q3a_1 = "";
        string var_AS1_Q3a_2 = "";
        string var_AS1_Q4 = "";
        string var_AS1_Q5 = "";
        string var_AS1_Q6 = "";
        string var_AS2_Q7_1 = "";
        string var_AS2_Q7_2 = "";
        string var_AS2_Q8 = "";
        string var_AS2_Q8_3 = "";
        string var_AS2_Q8a = "";
        string var_AS2_Q9 = "";
        string var_AS2_Q10 = "";
        string var_AS2_Q11 = "";

        string var_AS5_Q27 = "";
        string var_AS5_Q28 = "";
        string var_AS5_Q29 = "";
        string var_AS5_Q30 = "";
        string var_AS5_Q31 = "";
        string var_AS5_Q32 = "";
        string var_AS5_Q33 = "";

        string var_AS2_Q12 = "";
        string var_AS2_Q13 = "";
        string var_AS3_Q14 = "";
        string var_AS3_Q15 = "";
        string var_AS3_Q16 = "";
        string var_AS3_Q17 = "";
        string var_AS3_Q18 = "";
        string var_AS3_Q19 = "";
        string var_AS3_Q20 = "";

        string var_AS4_Q21a = "";

        string var_AS3_Remarks = "";
        string var_AS3_A1 = "";
        string var_AS3_A2 = "";
        string var_AS3_B1 = "";
        string var_AS3_B2 = "";




        try
        {

            if (AS1_sex_a.Checked == true)
            {
                var_AS1_sex = "1";
            }
            else if (AS1_sex_b.Checked == true)
            {
                var_AS1_sex = "2";
            }



            if (AS1_fsite_1.Checked == true)
            {
                var_AS1_fsite = "1";
            }
            else if (AS1_fsite_2.Checked == true)
            {
                var_AS1_fsite = "2";
            }
            else if (AS1_fsite_3.Checked == true)
            {
                var_AS1_fsite = "3";
            }
            else if (AS1_fsite_4.Checked == true)
            {
                var_AS1_fsite = "4";
            }



            if (AS1_Samp_1.Checked == true)
            {
                var_AS1_Samp_1 = "1";
            }

            if (AS1_Samp_2.Checked == true)
            {
                var_AS1_Samp_2 = "2";
            }

            if (AS1_Samp_3.Checked == true)
            {
                var_AS1_Samp_3 = "3";
            }

            if (AS1_Samp_4.Checked == true)
            {
                var_AS1_Samp_4 = "4";
            }



            if (AS1_Q1_11.Checked == true)
            {
                var_AS1_Q1_1 = "1";
            }
            else if (AS1_Q1_12.Checked == true)
            {
                var_AS1_Q1_1 = "2";
            }



            if (AS1_Q2_11.Checked == true)
            {
                var_AS1_Q2_1 = "1";
            }
            else if (AS1_Q2_12.Checked == true)
            {
                var_AS1_Q2_1 = "2";
            }




            if (AS1_Q3_1.Checked == true)
            {
                var_AS1_Q3 = "1";
            }
            else if (AS1_Q3_2.Checked == true)
            {
                var_AS1_Q3 = "2";
            }





            if (AS1_Q3a_11.Checked == true)
            {
                var_AS1_Q3a_1 = "1";
            }
            else if (AS1_Q3a_12.Checked == true)
            {
                var_AS1_Q3a_1 = "2";
            }




            if (AS2_Q7_11.Checked == true)
            {
                var_AS2_Q7_1 = "1";
            }
            else if (AS2_Q7_12.Checked == true)
            {
                var_AS2_Q7_1 = "2";
            }



            if (AS2_Q8_1.Checked == true)
            {
                var_AS2_Q8 = "1";
            }
            else if (AS2_Q8_2.Checked == true)
            {
                var_AS2_Q8 = "2";
            }




            if (AS2_Q8a_1.Checked == true)
            {
                var_AS2_Q8a = "1";
            }
            else if (AS2_Q8a_2.Checked == true)
            {
                var_AS2_Q8a = "2";
            }




            if (AS2_Q11_1.Checked == true)
            {
                var_AS2_Q11 = "1";
            }
            else if (AS2_Q11_2.Checked == true)
            {
                var_AS2_Q11 = "2";
            }



            if (AS4_Q21a.Checked == true)
            {
                var_AS4_Q21a = "1";
            }




            if (AS5_Q27_1.Checked == true)
            {
                var_AS5_Q27 = "1";
            }
            else if (AS5_Q27_2.Checked == true)
            {
                var_AS5_Q27 = "2";
            }



            if (AS5_Q28_1.Checked == true)
            {
                var_AS5_Q28 = "1";
            }
            else if (AS5_Q28_2.Checked == true)
            {
                var_AS5_Q28 = "2";
            }



            if (AS5_Q29_1.Checked == true)
            {
                var_AS5_Q29 = "1";
            }
            else if (AS5_Q29_2.Checked == true)
            {
                var_AS5_Q29 = "2";
            }
            else if (AS5_Q29_3.Checked == true)
            {
                var_AS5_Q29 = "3";
            }




            if (AS5_Q30_1.Checked == true)
            {
                var_AS5_Q30 = "1";
            }
            else if (AS5_Q30_2.Checked == true)
            {
                var_AS5_Q30 = "2";
            }
            else if (AS5_Q30_3.Checked == true)
            {
                var_AS5_Q30 = "3";
            }




            if (AS5_Q31_1.Checked == true)
            {
                var_AS5_Q31 = "1";
            }
            else if (AS5_Q31_2.Checked == true)
            {
                var_AS5_Q31 = "2";
            }
            else if (AS5_Q31_3.Checked == true)
            {
                var_AS5_Q31 = "3";
            }
            else if (AS5_Q31_4.Checked == true)
            {
                var_AS5_Q31 = "4";
            }




            if (AS5_Q32_1.Checked == true)
            {
                var_AS5_Q32 = "1";
            }
            else if (AS5_Q32_2.Checked == true)
            {
                var_AS5_Q32 = "2";
            }
            else if (AS5_Q32_3.Checked == true)
            {
                var_AS5_Q32 = "3";
            }




            DateTime dt_AS1_Q4 = new DateTime();

            if (AS1_Q4.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS1_Q4 = Convert.ToDateTime(AS1_Q4.Text);
            }




            DateTime dt_AS1_Q5 = new DateTime();

            if (AS1_Q5.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS1_Q5 = Convert.ToDateTime(AS1_Q5.Text);
            }




            DateTime dt_AS1_Q6 = new DateTime();

            if (AS1_Q6.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS1_Q6 = Convert.ToDateTime(AS1_Q6.Text);
            }




            DateTime dt_AS1_Q6c = new DateTime();

            if (AS1_Q6c.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS1_Q6c = Convert.ToDateTime(AS1_Q6c.Text);
            }




            DateTime dt_AS2_Q9 = new DateTime();

            if (AS2_Q9.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS2_Q9 = Convert.ToDateTime(AS2_Q9.Text);
            }




            DateTime dt_AS2_Q10 = new DateTime();

            if (AS2_Q10.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS2_Q10 = Convert.ToDateTime(AS2_Q10.Text);
            }




            DateTime dt_AS2_Q13a = new DateTime();

            if (AS2_Q13a.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS2_Q13a = Convert.ToDateTime(AS2_Q13a.Text);
            }




            DateTime dt_AS3_Q14a = new DateTime();

            if (AS3_Q14a.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS3_Q14a = Convert.ToDateTime(AS3_Q14a.Text);
            }



            DateTime dt_AS3_Q15 = new DateTime();

            if (AS3_Q15.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS3_Q15 = Convert.ToDateTime(AS3_Q15.Text);
            }




            DateTime dt_AS3_Q17 = new DateTime();

            if (AS3_Q17.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS3_Q17 = Convert.ToDateTime(AS3_Q17.Text);
            }




            DateTime dt_AS3_Q20 = new DateTime();

            if (AS3_Q20.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS3_Q20 = Convert.ToDateTime(AS3_Q20.Text);
            }





            DateTime dt_AS4_Q22a = new DateTime();

            if (AS4_Q22a.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS4_Q22a = Convert.ToDateTime(AS4_Q22a.Text);
            }





            DateTime dt_AS4_Q22b = new DateTime();

            if (AS4_Q22b.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS4_Q22b = Convert.ToDateTime(AS4_Q22b.Text);
            }





            DateTime dt_AS4_Q24 = new DateTime();

            if (AS4_Q24.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS4_Q24 = Convert.ToDateTime(AS4_Q24.Text);
            }





            DateTime dt_AS3_A2 = new DateTime();

            if (AS3_A2.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS3_A2 = Convert.ToDateTime(AS3_A2.Text);
            }





            DateTime dt_AS3_B2 = new DateTime();

            if (AS3_B2.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS3_B2 = Convert.ToDateTime(AS3_B2.Text);
            }




            DateTime dt_entry = new DateTime();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            dt_entry = Convert.ToDateTime(DateTime.Now.ToShortDateString());



            string[] fldname = {
"AS1_screening_ID",
"AS1_rand_id",
"AS1_name",
"AS1_sex",
"AS1_age",
"AS1_barcode",
"AS1_mrno",
"AS1_barcode1",
"AS1_fsite",
"AS1_Samp_1",
"AS1_Samp_2",
"AS1_Samp_3",
"AS1_Samp_4",
"AS1_Q1_1",
"AS1_Q1_2",
"AS1_Q2_1",
"AS1_Q2_2",
"AS1_Q3",
"AS1_Q3a_1",
"AS1_Q3a_2",
"AS1_Q4",
"AS1_Q5",
"AS1_Q6",
"AS1_Q6a",
"AS1_Q6b",
"AS1_Q6c",
"AS2_Q7_1",
"AS2_Q7_2",
"AS2_Q7_CBC_CODE",
"AS2_Q8",
"AS2_Q8_BacT",
"AS2_Q8_3",
"AS2_Q8a",
"AS2_Q9",
"AS2_Q10",
"AS2_Q11",
"AS2_Q12_1",
"AS2_Q12_2",
"AS2_Q12_3",
"AS2_Q12_4",
"AS2_Q13",
"AS2_Q13a",
"AS3_Q14",
"AS3_Q14a",
"AS3_Q15",
"AS3_Q16",
"AS3_Q17",
"AS3_Q18",
"AS3_Q19",
"AS3_Q20",
"AS4_Q21a",
"AS4_Q22a",
"AS4_Q22b",
"AS4_Q23",
"AS4_Q24",
"AS5_Q25a",
"AS5_Q25b",
"AS5_Q26",
"AS5_Q27",
"AS5_Q28",
"AS5_Q29",
"AS5_Q30",
"AS5_Q31",
"AS5_Q32",
"AS5_Q33a",
"AS5_Q33b",
"AS3_Remarks",
"AS6_Q34",
"AS6_Q35",
"AS6_Q36",
"AS6_Q37",
"AS6_Q38",
"AS6_Q39",
"AS6_Q40",
"AS6_Q41",
"AS6_Q42",
"AS6_Q43",
"AS6_Q44",
"AS6_Q45",
"AS6_Q46",
"AS6_Q47",
"AS5_R1",
"AS3_A1",
"AS3_A2",
"AS3_B1",
"AS3_B2",
"UserID",
"EntryDate",
"labid"
 };


            string[] fldvalue =
            {

                 AS1_screening_ID.Text,
AS1_rand_id.Text,
AS1_name.Text,
var_AS1_sex,
AS1_age.Text,
AS1_barcode.Text,
AS1_mrno.Text,
AS1_barcode1.Text,
var_AS1_fsite,
var_AS1_Samp_1,
var_AS1_Samp_2,
var_AS1_Samp_3,
var_AS1_Samp_4,
var_AS1_Q1_1,
AS1_Q1_2.Text,
var_AS1_Q2_1,
AS1_Q2_2.Text,
var_AS1_Q3,
var_AS1_Q3a_1,
AS1_Q3a_2.Text,
dt_AS1_Q4.ToShortTimeString(),
dt_AS1_Q5.ToShortDateString(),
dt_AS1_Q6.ToShortTimeString(),
AS1_Q6a.Text,
AS1_Q6b.Text,
dt_AS1_Q6c.ToShortTimeString(),
var_AS2_Q7_1,
AS2_Q7_2.Text,
AS2_Q7_CBC_CODE.Text,
var_AS2_Q8,
AS2_Q8_BacT.Text,
AS2_Q8_3.Text,
var_AS2_Q8a,
dt_AS2_Q9.ToShortDateString(),
dt_AS2_Q10.ToShortTimeString(),
var_AS2_Q11,
AS2_Q12_1.Text,
AS2_Q12_2.Text,
AS2_Q12_3.Text,
AS2_Q12_4.Text,
AS2_Q13.Text,
dt_AS2_Q13a.ToShortTimeString(),
AS3_Q14.Text,
dt_AS3_Q14a.ToShortDateString(),
dt_AS3_Q15.ToShortTimeString(),
AS3_Q16.Text,
dt_AS3_Q17.ToShortTimeString(),
AS3_Q18.Text,
AS3_Q19.Text,
dt_AS3_Q20.ToShortTimeString(),
var_AS4_Q21a,
dt_AS4_Q22a.ToShortTimeString(),
dt_AS4_Q22b.ToShortDateString(),
AS4_Q23.Text,
dt_AS4_Q24.ToShortDateString(),
AS5_Q25a.Text,
AS5_Q25b.Text,
AS5_Q26.Text,
var_AS5_Q27,
var_AS5_Q28,
var_AS5_Q29,
var_AS5_Q30,
var_AS5_Q31,
var_AS5_Q32,
AS5_Q33a.Text,
AS5_Q33b.Text,
AS3_Remarks.Text,
AS6_Q34.Text,
AS6_Q35.Text,
AS6_Q36.Text,
AS6_Q37.Text,
AS6_Q38.Text,
AS6_Q39.Text,
AS6_Q40.Text,
AS6_Q41.Text,
AS6_Q42.Text,
AS6_Q43.Text,
AS6_Q44.Text,
AS6_Q45.Text,
AS6_Q46.Text,
AS6_Q47.Text,
AS5_R1.Text,
AS3_A1.Text,
dt_AS3_A2.ToShortDateString(),
AS3_B1.Text,
dt_AS3_B2.ToShortDateString(),
Session["userid"].ToString(),
dt_entry.ToShortDateString(),
HttpContext.Current.Request["labid"].ToString()

                };


            string msg = obj_op.ExecuteNonQuery_Message(fldname, fldvalue, "sp_AddForm1");

            if (string.IsNullOrEmpty(msg))
            {
                ClearFields();


                string message = "alert('Record saved successfully');window.location.href='sample_recv.aspx'";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
            else
            {
                string message = "alert('" + msg + "');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }


            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Record saved successfully');", true);

            //Response.Redirect("sample_recv.aspx");

            //lblerr.Text = "Record saved successfully";                                
        }

        catch (Exception ex)
        {
            string message = "alert('" + ex.Message + "');";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        }

        finally
        {
            obj_op = null;
        }

    }



    private void ClearFields()
    {
        AS1_screening_ID.Text = "";
        AS1_rand_id.Text = "";
        AS1_name.Text = "";
        AS1_sex_a.Checked = false;
        AS1_sex_b.Checked = false;

        AS1_age.Text = "";
        AS1_barcode.Text = "";
        AS1_mrno.Text = "";
        AS1_lno.Text = "";
        AS1_barcode1.Text = "";

        AS1_fsite_1.Checked = false;
        AS1_fsite_2.Checked = false;
        AS1_fsite_3.Checked = false;

        AS1_Samp_1.Checked = false;
        AS1_Samp_2.Checked = false;
        AS1_Samp_3.Checked = false;
        AS1_Samp_4.Checked = false;


        AS1_Q1_11.Checked = false;
        AS1_Q1_12.Checked = false;


        AS1_Q1_2.Text = "";


        AS1_Q2_11.Checked = false;
        AS1_Q2_12.Checked = false;


        AS1_Q2_2.Text = "";

        AS1_Q3a_11.Checked = false;
        AS1_Q3a_12.Checked = false;


        AS1_Q3a_11.Checked = false;
        AS1_Q3a_12.Checked = false;


        AS1_Q3a_2.Text = "";
        AS1_Q4.Text = "";
        AS1_Q5.Text = "";
        AS1_Q6.Text = "";


        AS2_Q7_11.Checked = false;
        AS2_Q7_12.Checked = false;


        AS2_Q7_2a.Text = "";
        AS2_Q7_2.Text = "";
        AS2_Q7_CBC_CODE.Text = "";


        AS2_Q8_1.Checked = false;
        AS2_Q8_2.Checked = false;

        AS2_Q8_BacT.Text = "";

        AS2_Q8_3.Text = "";


        AS2_Q8a_1.Checked = false;
        AS2_Q8a_2.Checked = false;


        AS2_Q9.Text = "";
        AS2_Q10.Text = "";


        AS2_Q11_1.Checked = false;
        AS2_Q11_2.Checked = false;


        AS2_Q12_1.Text = "";
        AS2_Q12_2.Text = "";
        AS2_Q12_3.Text = "";
        AS2_Q12_4.Text = "";


        AS2_Q13.Text = "";
        AS2_Q13a.Text = "";

        AS3_Q14.Text = "";
        AS3_Q14a.Text = "";


        AS3_Q15.Text = "";
        AS3_Q16.Text = "";
        AS3_Q17.Text = "";
        AS3_Q18.Text = "";
        AS3_Q19.Text = "";
        AS3_Q20.Text = "";


        AS4_Q21a.Checked = false;
        AS4_Q22a.Text = "";
        AS4_Q22b.Text = "";
        AS4_Q23.Text = "";
        AS4_Q24.Text = "";



        AS5_Q25a.Text = "";
        AS5_Q25b.Text = "";
        AS5_Q26.Text = "";

        AS5_Q27_1.Checked = false;
        AS5_Q27_2.Checked = false;


        AS5_Q28_1.Checked = false;
        AS5_Q28_2.Checked = false;


        AS5_Q29_1.Checked = false;
        AS5_Q29_2.Checked = false;
        AS5_Q29_3.Checked = false;


        AS5_Q30_1.Checked = false;
        AS5_Q30_2.Checked = false;
        AS5_Q30_3.Checked = false;



        AS5_Q31_1.Checked = false;
        AS5_Q31_2.Checked = false;
        AS5_Q31_3.Checked = false;
        AS5_Q31_4.Checked = false;


        AS5_Q32_1.Checked = false;
        AS5_Q32_2.Checked = false;
        AS5_Q32_3.Checked = false;

        AS5_Q33a.Text = "";
        AS5_Q33b.Text = "";

        AS3_Remarks.Text = "";


        AS6_Q34.Text = "";
        AS6_Q35.Text = "";
        AS6_Q36.Text = "";
        AS6_Q37.Text = "";
        AS6_Q38.Text = "";
        AS6_Q39.Text = "";
        AS6_Q40.Text = "";
        AS6_Q41.Text = "";
        AS6_Q42.Text = "";
        AS6_Q43.Text = "";
        AS6_Q44.Text = "";
        AS6_Q45.Text = "";
        AS6_Q46.Text = "";
        AS6_Q47.Text = "";


        AS3_A1.Text = "";
        AS3_A2.Text = "";
        AS3_B1.Text = "";
        AS3_B2.Text = "";
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {
        Session.Remove("UserID");
        Session.Abandon();
        Response.Redirect("login.aspx");
    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<CountryInfo> CheckScreeningID(string screeningid)
    {
        List<CountryInfo> CountryInformation = new List<CountryInfo>();

        try
        {
            string[] fldname = { "screeningid", "fldvalue", "visitid" };
            string[] fldvalue = { screeningid, "0", "0" };

            DataSet ds = ExecuteNonQuery(fldname, fldvalue, "sp_GetRecords");

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            CountryInformation.Add(new CountryInfo()
                            {
                                AS1_screening_ID = dr["AS1_screening_ID"].ToString(),
                                AS1_rand_id = dr["AS1_rand_id"].ToString(),
                                AS1_name = dr["AS1_name"].ToString(),
                                AS1_sex = dr["AS1_sex"].ToString(),
                                AS1_age = dr["AS1_age"].ToString(),
                                AS1_barcode = dr["AS1_barcode"].ToString(),
                                AS1_fsite = dr["AS1_fsite"].ToString(),
                                AS1_Q1_1 = dr["AS1_Q1_1"].ToString(),

                            });
                        }

                    }
                }
            }


        }

        catch (Exception ex)
        {

        }

        return CountryInformation;
    }



    public static DataSet ExecuteNonQuery(string[] fieldName, string[] fieldValues, string spName)
    {
        SqlCommand cmd = null;
        CConnection cn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;

        string[] dt;


        try
        {
            cn = new CConnection();

            cmd = new SqlCommand();
            cmd.Connection = cn.cn;
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;

            for (int a = 0; a <= fieldName.Length - 1; a++)
            {
                if (fieldValues[a] == "" || fieldValues[a] == " -" || fieldValues[a] == "  /  /" || fieldValues[a] == "  :" || fieldValues[a] == "" || fieldValues[a] == "  -   -  -      -  - -" || fieldValues[a] == "3-     -" || fieldValues[a] == "  ." || fieldValues[a] == "  -   -  -    -  - -")
                {
                    cmd.Parameters.AddWithValue(fieldName[a], DBNull.Value);
                }
                else
                {
                    if (fieldName[a] == "DOP" || fieldName[a] == "StartDate" || fieldName[a] == "EndDate" || fieldName[a] == "AADOP")
                    {
                        if (fieldValues[a].ToString() == "01/01/0001")
                        {
                            cmd.Parameters.AddWithValue(fieldName[a], DBNull.Value);
                        }
                        else
                        {
                            dt = fieldValues[a].Split('/');
                            cmd.Parameters.AddWithValue(fieldName[a], dt[1] + "/" + dt[0] + "/" + dt[2]);
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue(fieldName[a], fieldValues[a]);
                    }
                }
            }

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

        }

        catch (Exception ex)
        {

        }

        finally
        {
            cn.MConnClose();
            cmd = null;
            cn = null;
        }

        return ds;
    }

    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("sample_recv.aspx");
    }

    protected void AS1_Q3a_11a_CheckedChanged(object sender, EventArgs e)
    {
        if (AS1_Q3a_11a.Checked)
        {
            pnl_row_AS1_Q3b_1.Visible = true;
            pnl_row_AS2_Q8b.Visible = true;

            if (AS1_Q3a_11.Checked == true)
            {
                AS1_Q3b_11.Checked = true;
                AS1_Q3b_12.Checked = false;
                AS1_Q3b_11.Enabled = false;
                AS1_Q3b_12.Enabled = false;
            }
            else if (AS1_Q3a_12.Checked == true)
            {
                AS1_Q3b_11.Checked = false;
                AS1_Q3b_12.Checked = true;
                AS1_Q3b_11.Enabled = false;
                AS1_Q3b_12.Enabled = false;
            }
            else
            {
                AS1_Q3b_11.Enabled = false;
                AS1_Q3b_12.Enabled = false;
            }
        }
    }

    protected void AS1_Q3a_12a_CheckedChanged(object sender, EventArgs e)
    {
        if (AS1_Q3a_12a.Checked)
        {
            AS1_Q3b_11.Checked = false;
            AS1_Q3b_12.Checked = false;

            AS2_Q8b_1.Checked = false;
            AS2_Q8b_2.Checked = false;

            pnl_row_AS1_Q3b_1.Visible = false;
            pnl_row_AS2_Q8b.Visible = false;
        }
    }

    protected void AS1_Q3a_11_CheckedChanged(object sender, EventArgs e)
    {
        if (AS1_Q3a_11.Checked == true)
        {
            AS1_Q3b_11.Checked = true;
            AS1_Q3b_12.Checked = false;
            AS1_Q3b_11.Enabled = false;
            AS1_Q3b_12.Enabled = false;
        }
    }

    protected void AS1_Q3a_12_CheckedChanged(object sender, EventArgs e)
    {
        if (AS1_Q3a_12.Checked == true)
        {
            AS1_Q3b_11.Checked = false;
            AS1_Q3b_12.Checked = true;
            AS1_Q3b_11.Enabled = false;
            AS1_Q3b_12.Enabled = false;
        }
    }

    protected void cmdSaveDraft_Click(object sender, EventArgs e)
    {
        if (ViewState["isupdate"] == null)
        {
            SaveData();
        }
        else
        {
            if (AuditTrials())
            {
                UpdateData();
            }
        }
    }





    private void SaveData()
    {
        CDBOperations obj_op = new CDBOperations();

        string var_AS1_screening_ID = "";
        string var_AS1_rand_id = "";
        string var_AS1_name = "";
        string var_AS1_sex = "";
        string var_AS1_age = "";
        string var_AS1_barcode = "";
        string var_AS1_fsite = "";
        string var_AS1_Samp = "";

        string var_mrno1 = "";
        string var_lno1 = "";

        string var_mrno2 = "";
        string var_lno2 = "";


        string var_random = "";

        string var_AS1_Samp_1 = "";
        string var_AS1_Samp_2 = "";
        string var_AS1_Samp_3 = "";
        string var_AS1_Samp_4 = "";

        string var_AS1_Q1_1 = "";
        string var_AS1_Q1_2 = "";
        string var_AS1_Q2_1 = "";
        string var_AS1_Q2_2 = "";
        string var_AS1_Q3 = "";
        string var_AS1_Q3a_1 = "";
        string var_AS1_Q3a_2 = "";

        string var_AS1_Q3a_11a = "";
        string var_AS1_Q3a_12a = "";


        string var_AS1_Q3b_1 = "";
        string var_AS1_Q3b_2 = "";
        string var_AS1_Q4 = "";
        string var_AS1_Q5 = "";
        string var_AS1_Q6 = "";
        string var_AS2_Q7_1 = "";
        string var_AS2_Q7_2 = "";
        string var_AS2_Q8 = "";
        string var_AS2_Q8_3 = "";
        string var_AS2_Q8a = "";
        string var_AS2_Q8b = "";
        string var_AS2_Q9 = "";
        string var_AS2_Q10 = "";
        string var_AS2_Q11 = "";

        string var_AS5_Q27 = "";
        string var_AS5_Q28 = "";
        string var_AS5_Q29 = "";
        string var_AS5_Q30 = "";
        string var_AS5_Q31 = "";
        string var_AS5_Q32 = "";
        string var_AS5_Q33 = "";

        string var_AS2_Q12 = "";
        string var_AS2_Q13 = "";
        string var_AS3_Q14 = "";
        string var_AS3_Q15 = "";
        string var_AS3_Q16 = "";
        string var_AS3_Q17 = "";
        string var_AS3_Q18 = "";
        string var_AS3_Q19 = "";
        string var_AS3_Q20 = "";

        string var_AS4_Q21a = "";

        string var_AS3_Remarks = "";
        string var_AS3_A1 = "";
        string var_AS3_A2 = "";
        string var_AS3_B1 = "";
        string var_AS3_B2 = "";




        try
        {

            if (chkMRNo.Checked)
            {
                var_mrno1 = AS1_mrno.Text;
            }

            if (chkLNumber.Checked)
            {
                var_lno1 = AS1_lno.Text;
            }


            if (chk_AS2_Q7_2a.Checked)
            {
                var_mrno2 = AS2_Q7_2a.Text;
            }


            if (chk_AS2_Q7_2.Checked)
            {
                var_lno2 = AS2_Q7_2.Text;
            }



            if (AS1_sex_a.Checked == true)
            {
                var_AS1_sex = "1";
            }
            else if (AS1_sex_b.Checked == true)
            {
                var_AS1_sex = "2";
            }



            if (AS1_rand_id.Text != "_-_-_-____")
            {
                var_random = AS1_rand_id.Text;
            }



            if (AS1_fsite_1.Checked == true)
            {
                var_AS1_fsite = "1";
            }
            else if (AS1_fsite_2.Checked == true)
            {
                var_AS1_fsite = "2";
            }
            else if (AS1_fsite_3.Checked == true)
            {
                var_AS1_fsite = "3";
            }
            else if (AS1_fsite_4.Checked == true)
            {
                var_AS1_fsite = "4";
            }
            else if (AS1_fsite_5.Checked == true)
            {
                var_AS1_fsite = "5";
            }
            else if (AS1_fsite_6.Checked == true)
            {
                var_AS1_fsite = "6";
            }
            else if (AS1_fsite_7.Checked == true)
            {
                var_AS1_fsite = "7";
            }



            if (AS1_Samp_1.Checked == true)
            {
                var_AS1_Samp_1 = "1";
            }

            if (AS1_Samp_2.Checked == true)
            {
                var_AS1_Samp_2 = "2";
            }

            if (AS1_Samp_3.Checked == true)
            {
                var_AS1_Samp_3 = "3";
            }

            if (AS1_Samp_4.Checked == true)
            {
                var_AS1_Samp_4 = "4";
            }



            if (AS1_Q1_11.Checked == true)
            {
                var_AS1_Q1_1 = "1";
            }
            else if (AS1_Q1_12.Checked == true)
            {
                var_AS1_Q1_1 = "2";
            }



            if (AS1_Q2_11.Checked == true)
            {
                var_AS1_Q2_1 = "1";
            }
            else if (AS1_Q2_12.Checked == true)
            {
                var_AS1_Q2_1 = "2";
            }




            if (AS1_Q3_1.Checked == true)
            {
                var_AS1_Q3 = "1";
            }
            else if (AS1_Q3_2.Checked == true)
            {
                var_AS1_Q3 = "2";
            }





            if (AS1_Q3a_11.Checked == true)
            {
                var_AS1_Q3a_1 = "1";
            }
            else if (AS1_Q3a_12.Checked == true)
            {
                var_AS1_Q3a_1 = "2";
            }


            if (AS1_Q3a_11a.Checked == true)
            {
                var_AS1_Q3a_11a = "1";
            }
            else if (AS1_Q3a_12a.Checked == true)
            {
                var_AS1_Q3a_11a = "2";
            }



            if (AS1_Q3b_11.Checked == true)
            {
                var_AS1_Q3b_1 = "1";
            }
            else if (AS1_Q3b_12.Checked == true)
            {
                var_AS1_Q3b_1 = "2";
            }



            if (AS2_Q7_11.Checked == true)
            {
                var_AS2_Q7_1 = "1";
            }
            else if (AS2_Q7_12.Checked == true)
            {
                var_AS2_Q7_1 = "2";
            }



            if (AS2_Q8_1.Checked == true)
            {
                var_AS2_Q8 = "1";
            }
            else if (AS2_Q8_2.Checked == true)
            {
                var_AS2_Q8 = "2";
            }




            if (AS2_Q8a_1.Checked == true)
            {
                var_AS2_Q8a = "1";
            }
            else if (AS2_Q8a_2.Checked == true)
            {
                var_AS2_Q8a = "2";
            }




            if (AS2_Q8b_1.Checked == true)
            {
                var_AS2_Q8b = "1";
            }
            else if (AS2_Q8b_2.Checked == true)
            {
                var_AS2_Q8b = "2";
            }




            if (AS2_Q11_1.Checked == true)
            {
                var_AS2_Q11 = "1";
            }
            else if (AS2_Q11_2.Checked == true)
            {
                var_AS2_Q11 = "2";
            }



            if (AS4_Q21a.Checked == true)
            {
                var_AS4_Q21a = "1";
            }




            if (AS5_Q27_1.Checked == true)
            {
                var_AS5_Q27 = "1";
            }
            else if (AS5_Q27_2.Checked == true)
            {
                var_AS5_Q27 = "2";
            }



            if (AS5_Q28_1.Checked == true)
            {
                var_AS5_Q28 = "1";
            }
            else if (AS5_Q28_2.Checked == true)
            {
                var_AS5_Q28 = "2";
            }



            if (AS5_Q29_1.Checked == true)
            {
                var_AS5_Q29 = "1";
            }
            else if (AS5_Q29_2.Checked == true)
            {
                var_AS5_Q29 = "2";
            }
            else if (AS5_Q29_3.Checked == true)
            {
                var_AS5_Q29 = "3";
            }




            if (AS5_Q30_1.Checked == true)
            {
                var_AS5_Q30 = "1";
            }
            else if (AS5_Q30_2.Checked == true)
            {
                var_AS5_Q30 = "2";
            }
            else if (AS5_Q30_3.Checked == true)
            {
                var_AS5_Q30 = "3";
            }




            if (AS5_Q31_1.Checked == true)
            {
                var_AS5_Q31 = "1";
            }
            else if (AS5_Q31_2.Checked == true)
            {
                var_AS5_Q31 = "2";
            }
            else if (AS5_Q31_3.Checked == true)
            {
                var_AS5_Q31 = "3";
            }
            else if (AS5_Q31_4.Checked == true)
            {
                var_AS5_Q31 = "4";
            }




            if (AS5_Q32_1.Checked == true)
            {
                var_AS5_Q32 = "1";
            }
            else if (AS5_Q32_2.Checked == true)
            {
                var_AS5_Q32 = "2";
            }
            else if (AS5_Q32_3.Checked == true)
            {
                var_AS5_Q32 = "3";
            }




            DateTime dt_AS1_Q4 = new DateTime();
            string[] arr_AS1_Q4 = null;
            string val_AS1_Q4 = null;

            if (AS1_Q4.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS1_Q4 = Convert.ToDateTime(AS1_Q4.Text);

                arr_AS1_Q4 = dt_AS1_Q4.ToShortDateString().Split('/');
                val_AS1_Q4 = arr_AS1_Q4[2] + "/" + arr_AS1_Q4[1] + "/" + arr_AS1_Q4[0];
            }




            DateTime dt_AS1_Q5 = new DateTime();
            string[] arr_AS1_Q5 = null;
            string val_AS1_Q5 = null;

            if (AS1_Q5.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS1_Q5 = Convert.ToDateTime(AS1_Q5.Text);

                arr_AS1_Q5 = dt_AS1_Q5.ToShortDateString().Split('/');
                val_AS1_Q5 = arr_AS1_Q5[2] + "/" + arr_AS1_Q5[1] + "/" + arr_AS1_Q5[0];
            }




            DateTime dt_AS1_Q6 = new DateTime();
            string[] arr_AS1_Q6 = null;
            string val_AS1_Q6 = null;

            if (AS1_Q6.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS1_Q6 = Convert.ToDateTime(AS1_Q6.Text);

                arr_AS1_Q6 = dt_AS1_Q6.ToShortDateString().Split('/');
                val_AS1_Q6 = arr_AS1_Q6[2] + "/" + arr_AS1_Q6[1] + "/" + arr_AS1_Q6[0];
            }




            DateTime dt_AS1_Q6c = new DateTime();
            string[] arr_AS1_Q6c = null;
            string val_AS1_Q6c = null;

            if (AS1_Q6c.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS1_Q6c = Convert.ToDateTime(AS1_Q6c.Text);

                arr_AS1_Q6c = dt_AS1_Q6c.ToShortDateString().Split('/');
                val_AS1_Q6c = arr_AS1_Q6c[2] + "/" + arr_AS1_Q6c[1] + "/" + arr_AS1_Q6c[0];
            }




            DateTime dt_AS2_Q9 = new DateTime();
            string[] arr_AS2_Q9 = null;
            string val_AS2_Q9 = null;

            if (AS2_Q9.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS2_Q9 = Convert.ToDateTime(AS2_Q9.Text);

                arr_AS2_Q9 = dt_AS2_Q9.ToShortDateString().Split('/');
                val_AS2_Q9 = arr_AS2_Q9[2] + "/" + arr_AS2_Q9[1] + "/" + arr_AS2_Q9[0];
            }




            DateTime dt_AS2_Q10 = new DateTime();

            if (AS2_Q10.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS2_Q10 = Convert.ToDateTime(AS2_Q10.Text);
            }




            DateTime dt_AS2_Q13a = new DateTime();

            if (AS2_Q13a.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS2_Q13a = Convert.ToDateTime(AS2_Q13a.Text);
            }




            DateTime dt_AS3_Q14a = new DateTime();
            string[] arr_AS3_Q14a = null;
            string val_AS3_Q14a = null;

            if (AS3_Q14a.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS3_Q14a = Convert.ToDateTime(AS3_Q14a.Text);

                arr_AS3_Q14a = dt_AS3_Q14a.ToShortDateString().Split('/');
                val_AS3_Q14a = arr_AS3_Q14a[2] + "/" + arr_AS3_Q14a[1] + "/" + arr_AS3_Q14a[0];
            }



            DateTime dt_AS3_Q15 = new DateTime();

            if (AS3_Q15.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS3_Q15 = Convert.ToDateTime(AS3_Q15.Text);
            }




            DateTime dt_AS3_Q17 = new DateTime();

            if (AS3_Q17.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS3_Q17 = Convert.ToDateTime(AS3_Q17.Text);
            }




            DateTime dt_AS3_Q20 = new DateTime();

            if (AS3_Q20.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS3_Q20 = Convert.ToDateTime(AS3_Q20.Text);
            }





            DateTime dt_AS4_Q22a = new DateTime();

            if (AS4_Q22a.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS4_Q22a = Convert.ToDateTime(AS4_Q22a.Text);
            }





            DateTime dt_AS4_Q22b = new DateTime();
            string[] arr_AS4_Q22b = null;
            string val_AS4_Q22b = null;

            if (AS4_Q22b.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS4_Q22b = Convert.ToDateTime(AS4_Q22b.Text);

                arr_AS4_Q22b = dt_AS4_Q22b.ToShortDateString().Split('/');
                val_AS4_Q22b = arr_AS4_Q22b[2] + "/" + arr_AS4_Q22b[1] + "/" + arr_AS4_Q22b[0];
            }





            DateTime dt_AS4_Q24 = new DateTime();

            if (AS4_Q24.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS4_Q24 = Convert.ToDateTime(AS4_Q24.Text);
            }





            DateTime dt_AS3_A2 = new DateTime();
            string[] arr_AS3_A2 = null;
            string val_AS3_A2 = null;

            if (AS3_A2.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS3_A2 = Convert.ToDateTime(AS3_A2.Text);

                arr_AS3_A2 = dt_AS3_A2.ToShortDateString().Split('/');
                val_AS3_A2 = arr_AS3_A2[2] + "/" + arr_AS3_A2[1] + "/" + arr_AS3_A2[0];
            }





            DateTime dt_AS3_B2 = new DateTime();
            string[] arr_AS3_B2 = null;
            string val_AS3_B2 = null;

            if (AS3_B2.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS3_B2 = Convert.ToDateTime(AS3_B2.Text);

                arr_AS3_B2 = dt_AS3_B2.ToShortDateString().Split('/');
                val_AS3_B2 = arr_AS3_B2[2] + "/" + arr_AS3_B2[1] + "/" + arr_AS3_B2[0];
            }




            DateTime dt_entry = new DateTime();

            string[] arr_entry = null;
            string val_entry = null;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            dt_entry = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            arr_entry = dt_entry.ToShortDateString().Split('/');
            val_entry = arr_entry[2] + "/" + arr_entry[1] + "/" + arr_entry[0];


            string qry = "INSERT INTO form1 (" +
"AS1_screening_ID," +
"AS1_rand_id," +
"AS1_name," +
"AS1_sex," +
"AS1_age," +
"AS1_barcode," +
"AS1_mrno," +
"AS1_lno," +
"AS1_barcode1," +
"AS1_fsite," +
"AS1_Samp_1," +
"AS1_Samp_2," +
"AS1_Samp_3," +
"AS1_Samp_4," +
"AS1_Q1_1," +
"AS1_Q1_2," +
"AS1_Q2_1," +
"AS1_Q2_2," +
"AS1_Q3," +
"AS1_Q3a_1," +
"AS1_Q3a_1a," +
"AS1_Q3b_1," +
"AS1_Q3a_2," +
"AS1_Q4," +
"AS1_Q5," +
"AS1_Q6," +
"AS1_Q6a," +
"AS1_Q6b," +
"AS1_Q6c," +
"AS2_Q7_1," +
"AS2_Q7_2a," +
"AS2_Q7_2," +
"AS2_Q7_CBC_CODE," +
"AS2_Q8," +
"AS2_Q8_BacT," +
"AS2_Q8_3," +
"AS2_Q8a," +
"AS2_Q8b," +
"AS2_Q9," +
"AS2_Q10," +
"AS2_Q11," +
"AS2_Q12_1," +
"AS2_Q12_2," +
"AS2_Q12_3," +
"AS2_Q12_4," +
"AS2_Q13," +
"AS2_Q13a," +
"AS3_Q14," +
"AS3_Q14a," +
"AS3_Q15," +
"AS3_Q16," +
"AS3_Q17," +
"AS3_Q18," +
"AS3_Q19," +
"AS3_Q20," +
"AS4_Q21a," +
"AS4_Q22a," +
"AS4_Q22b," +
"AS4_Q23," +
"AS4_Q24," +
"AS5_Q25a," +
"AS5_Q25b," +
"AS5_Q26," +
"AS5_Q27," +
"AS5_Q28," +
"AS5_Q29," +
"AS5_Q30," +
"AS5_Q31," +
"AS5_Q32," +
"AS5_Q33a," +
"AS5_Q33b," +
"AS3_Remarks," +
"AS6_Q34," +
"AS6_Q35," +
"AS6_Q36," +
"AS6_Q37," +
"AS6_Q38," +
"AS6_Q39," +
"AS6_Q40," +
"AS6_Q41," +
"AS6_Q42," +
"AS6_Q43," +
"AS6_Q44," +
"AS6_Q45," +
"AS6_Q46," +
"AS6_Q47," +
"AS5_R1," +
"AS3_A1," +
"AS3_A2," +
"AS3_B1," +
"AS3_B2," +
"UserID," +
"EntryDate," +
"labid) VALUES('" +
AS1_screening_ID.Text + "', '" +
var_random + "', '" +
AS1_name.Text + "', '" +
var_AS1_sex + "', '" +
AS1_age.Text + "', '" +
AS1_barcode.Text + "', '" +
var_mrno1 + "', '" +
var_lno1 + "', '" +
AS1_barcode1.Text + "', '" +
var_AS1_fsite + "', '" +
var_AS1_Samp_1 + "', '" +
var_AS1_Samp_2 + "', '" +
var_AS1_Samp_3 + "', '" +
var_AS1_Samp_4 + "', '" +
var_AS1_Q1_1 + "', '" +
AS1_Q1_2.Text + "', '" +
var_AS1_Q2_1 + "', '" +
AS1_Q2_2.Text + "', '" +
var_AS1_Q3 + "', '" +
var_AS1_Q3a_1 + "', '" +
var_AS1_Q3a_11a + "', '" +
var_AS1_Q3b_1 + "', '" +
AS1_Q3a_2.Text + "', '" +
val_AS1_Q4 + "', '" +
val_AS1_Q5 + "', '" +
val_AS1_Q6 + "', '" +
AS1_Q6a.Text + "', '" +
AS1_Q6b.Text + "', '" +
val_AS1_Q6c + "', '" +
var_AS2_Q7_1 + "', '" +
var_mrno2 + "', '" +
var_lno2 + "', '" +
AS2_Q7_CBC_CODE.Text + "', '" +
var_AS2_Q8 + "', '" +
AS2_Q8_BacT.Text + "', '" +
AS2_Q8_3.Text + "', '" +
var_AS2_Q8a + "', '" +
var_AS2_Q8b + "', '" +
val_AS2_Q9 + "', '" +
dt_AS2_Q10.ToShortTimeString() + "', '" +
var_AS2_Q11 + "', '" +
AS2_Q12_1.Text + "', '" +
AS2_Q12_2.Text + "', '" +
AS2_Q12_3.Text + "', '" +
AS2_Q12_4.Text + "', '" +
AS2_Q13.Text + "', '" +
dt_AS2_Q13a.ToShortTimeString() + "', '" +
AS3_Q14.Text + "', '" +
val_AS3_Q14a + "', '" +
dt_AS3_Q15.ToShortTimeString() + "', '" +
AS3_Q16.Text + "', '" +
dt_AS3_Q17.ToShortTimeString() + "', '" +
AS3_Q18.Text + "', '" +
AS3_Q19.Text + "', '" +
dt_AS3_Q20.ToShortTimeString() + "', '" +
var_AS4_Q21a + "', '" +
dt_AS4_Q22a.ToShortTimeString() + "', '" +
val_AS4_Q22b + "', '" +
AS4_Q23.Text + "', '" +
dt_AS4_Q24.ToShortTimeString() + "', '" +
AS5_Q25a.Text + "', '" +
AS5_Q25b.Text + "', '" +
AS5_Q26.Text + "', '" +
var_AS5_Q27 + "', '" +
var_AS5_Q28 + "', '" +
var_AS5_Q29 + "', '" +
var_AS5_Q30 + "', '" +
var_AS5_Q31 + "', '" +
var_AS5_Q32 + "', '" +
AS5_Q33a.Text + "', '" +
AS5_Q33b.Text + "', '" +
AS3_Remarks.Text + "', '" +
AS6_Q34.Text + "', '" +
AS6_Q35.Text + "', '" +
AS6_Q36.Text + "', '" +
AS6_Q37.Text + "', '" +
AS6_Q38.Text + "', '" +
AS6_Q39.Text + "', '" +
AS6_Q40.Text + "', '" +
AS6_Q41.Text + "', '" +
AS6_Q42.Text + "', '" +
AS6_Q43.Text + "', '" +
AS6_Q44.Text + "', '" +
AS6_Q45.Text + "', '" +
AS6_Q46.Text + "', '" +
AS6_Q47.Text + "', '" +
AS5_R1.Text + "', '" +
AS3_A1.Text + "', '" +
val_AS3_A2 + "', '" +
AS3_B1.Text + "', '" +
val_AS3_B2 + "', '" +
Session["userid"].ToString() + "', '" +
val_entry + "', '" +
HttpContext.Current.Request["labid"].ToString() + "')";


            string msg = obj_op.ExecuteNonQuery_Message_Qry(qry);

            if (string.IsNullOrEmpty(msg))
            {
                ClearFields();

                string message = "alert('Record saved successfully');window.location.href='sample_recv.aspx'";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
            }
            else
            {
                string message = msg.Replace("'", "");
                message = msg.Replace(@"\", "");
                message = msg.Replace("/", "");

                message = "alert('" + msg + "');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
            }

        }

        catch (Exception ex)
        {
            string message = "alert('" + ex.Message + "');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
        }

        finally
        {
            obj_op = null;
        }
    }






    private void UpdateData()
    {
        CDBOperations obj_op = new CDBOperations();

        string var_AS1_screening_ID = "";
        string var_AS1_rand_id = "";
        string var_AS1_name = "";
        string var_AS1_sex = "";
        string var_AS1_age = "";
        string var_AS1_barcode = "";
        string var_AS1_fsite = "";
        string var_AS1_Samp = "";

        string var_mrno1 = "";
        string var_lno1 = "";

        string var_mrno2 = "";
        string var_lno2 = "";

        string var_AS1_Samp_1 = "";
        string var_AS1_Samp_2 = "";
        string var_AS1_Samp_3 = "";
        string var_AS1_Samp_4 = "";

        string var_AS1_Q1_1 = "";
        string var_AS1_Q1_2 = "";
        string var_AS1_Q2_1 = "";
        string var_AS1_Q2_2 = "";
        string var_AS1_Q3 = "";
        string var_AS1_Q3a_1 = "";
        string var_AS1_Q3a_2 = "";

        string var_AS1_Q3a_11a = "";
        string var_AS1_Q3a_12a = "";


        string var_AS1_Q3b_1 = "";
        string var_AS1_Q3b_2 = "";
        string var_AS1_Q4 = "";
        string var_AS1_Q5 = "";
        string var_AS1_Q6 = "";
        string var_AS2_Q7_1 = "";
        string var_AS2_Q7_2 = "";
        string var_AS2_Q8 = "";
        string var_AS2_Q8_3 = "";
        string var_AS2_Q8a = "";
        string var_AS2_Q8b = "";
        string var_AS2_Q9 = "";
        string var_AS2_Q10 = "";
        string var_AS2_Q11 = "";

        string var_AS5_Q27 = "";
        string var_AS5_Q28 = "";
        string var_AS5_Q29 = "";
        string var_AS5_Q30 = "";
        string var_AS5_Q31 = "";
        string var_AS5_Q32 = "";
        string var_AS5_Q33 = "";

        string var_AS2_Q12 = "";
        string var_AS2_Q13 = "";
        string var_AS3_Q14 = "";
        string var_AS3_Q15 = "";
        string var_AS3_Q16 = "";
        string var_AS3_Q17 = "";
        string var_AS3_Q18 = "";
        string var_AS3_Q19 = "";
        string var_AS3_Q20 = "";

        string var_AS4_Q21a = "";

        string var_AS3_Remarks = "";
        string var_AS3_A1 = "";
        string var_AS3_A2 = "";
        string var_AS3_B1 = "";
        string var_AS3_B2 = "";




        try
        {

            if (AS1_sex_a.Checked == true)
            {
                var_AS1_sex = "1";
            }
            else if (AS1_sex_b.Checked == true)
            {
                var_AS1_sex = "2";
            }



            if (AS1_fsite_1.Checked == true)
            {
                var_AS1_fsite = "1";
            }
            else if (AS1_fsite_2.Checked == true)
            {
                var_AS1_fsite = "2";
            }
            else if (AS1_fsite_3.Checked == true)
            {
                var_AS1_fsite = "3";
            }
            else if (AS1_fsite_4.Checked == true)
            {
                var_AS1_fsite = "4";
            }
            else if (AS1_fsite_5.Checked == true)
            {
                var_AS1_fsite = "5";
            }
            else if (AS1_fsite_6.Checked == true)
            {
                var_AS1_fsite = "6";
            }
            else if (AS1_fsite_7.Checked == true)
            {
                var_AS1_fsite = "7";
            }



            if (!chkMRNo.Checked)
            {
                var_mrno1 = AS1_mrno.Text;
            }


            if (!chkLNumber.Checked)
            {
                var_lno1 = AS1_lno.Text;
            }


            if (!chk_AS2_Q7_2a.Checked)
            {
                var_mrno2 = AS2_Q7_2a.Text;
            }


            if (!chk_AS2_Q7_2.Checked)
            {
                var_lno2 = AS2_Q7_2.Text;
            }



            if (AS1_Samp_1.Checked == true)
            {
                var_AS1_Samp_1 = "1";
            }

            if (AS1_Samp_2.Checked == true)
            {
                var_AS1_Samp_2 = "2";
            }

            if (AS1_Samp_3.Checked == true)
            {
                var_AS1_Samp_3 = "3";
            }

            if (AS1_Samp_4.Checked == true)
            {
                var_AS1_Samp_4 = "4";
            }



            if (AS1_Q1_11.Checked == true)
            {
                var_AS1_Q1_1 = "1";
            }
            else if (AS1_Q1_12.Checked == true)
            {
                var_AS1_Q1_1 = "2";
            }



            if (AS1_Q2_11.Checked == true)
            {
                var_AS1_Q2_1 = "1";
            }
            else if (AS1_Q2_12.Checked == true)
            {
                var_AS1_Q2_1 = "2";
            }




            if (AS1_Q3_1.Checked == true)
            {
                var_AS1_Q3 = "1";
            }
            else if (AS1_Q3_2.Checked == true)
            {
                var_AS1_Q3 = "2";
            }





            if (AS1_Q3a_11.Checked == true)
            {
                var_AS1_Q3a_1 = "1";
            }
            else if (AS1_Q3a_12.Checked == true)
            {
                var_AS1_Q3a_1 = "2";
            }


            if (AS1_Q3a_11a.Checked == true)
            {
                var_AS1_Q3a_11a = "1";
            }
            else if (AS1_Q3a_12a.Checked == true)
            {
                var_AS1_Q3a_11a = "2";
            }



            if (AS1_Q3b_11.Checked == true)
            {
                var_AS1_Q3b_1 = "1";
            }
            else if (AS1_Q3b_12.Checked == true)
            {
                var_AS1_Q3b_1 = "2";
            }



            if (AS2_Q7_11.Checked == true)
            {
                var_AS2_Q7_1 = "1";
            }
            else if (AS2_Q7_12.Checked == true)
            {
                var_AS2_Q7_1 = "2";
            }



            if (AS2_Q8_1.Checked == true)
            {
                var_AS2_Q8 = "1";
            }
            else if (AS2_Q8_2.Checked == true)
            {
                var_AS2_Q8 = "2";
            }




            if (AS2_Q8a_1.Checked == true)
            {
                var_AS2_Q8a = "1";
            }
            else if (AS2_Q8a_2.Checked == true)
            {
                var_AS2_Q8a = "2";
            }




            if (AS2_Q8b_1.Checked == true)
            {
                var_AS2_Q8b = "1";
            }
            else if (AS2_Q8b_2.Checked == true)
            {
                var_AS2_Q8b = "2";
            }




            if (AS2_Q11_1.Checked == true)
            {
                var_AS2_Q11 = "1";
            }
            else if (AS2_Q11_2.Checked == true)
            {
                var_AS2_Q11 = "2";
            }



            if (AS4_Q21a.Checked == true)
            {
                var_AS4_Q21a = "1";
            }




            if (AS5_Q27_1.Checked == true)
            {
                var_AS5_Q27 = "1";
            }
            else if (AS5_Q27_2.Checked == true)
            {
                var_AS5_Q27 = "2";
            }



            if (AS5_Q28_1.Checked == true)
            {
                var_AS5_Q28 = "1";
            }
            else if (AS5_Q28_2.Checked == true)
            {
                var_AS5_Q28 = "2";
            }



            if (AS5_Q29_1.Checked == true)
            {
                var_AS5_Q29 = "1";
            }
            else if (AS5_Q29_2.Checked == true)
            {
                var_AS5_Q29 = "2";
            }
            else if (AS5_Q29_3.Checked == true)
            {
                var_AS5_Q29 = "3";
            }




            if (AS5_Q30_1.Checked == true)
            {
                var_AS5_Q30 = "1";
            }
            else if (AS5_Q30_2.Checked == true)
            {
                var_AS5_Q30 = "2";
            }
            else if (AS5_Q30_3.Checked == true)
            {
                var_AS5_Q30 = "3";
            }




            if (AS5_Q31_1.Checked == true)
            {
                var_AS5_Q31 = "1";
            }
            else if (AS5_Q31_2.Checked == true)
            {
                var_AS5_Q31 = "2";
            }
            else if (AS5_Q31_3.Checked == true)
            {
                var_AS5_Q31 = "3";
            }
            else if (AS5_Q31_4.Checked == true)
            {
                var_AS5_Q31 = "4";
            }




            if (AS5_Q32_1.Checked == true)
            {
                var_AS5_Q32 = "1";
            }
            else if (AS5_Q32_2.Checked == true)
            {
                var_AS5_Q32 = "2";
            }
            else if (AS5_Q32_3.Checked == true)
            {
                var_AS5_Q32 = "3";
            }




            DateTime dt_AS1_Q4 = new DateTime();
            string[] arr_AS1_Q4 = null;
            string val_AS1_Q4 = null;

            if (AS1_Q4.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS1_Q4 = Convert.ToDateTime(AS1_Q4.Text);

                arr_AS1_Q4 = dt_AS1_Q4.ToShortDateString().Split('/');
                val_AS1_Q4 = arr_AS1_Q4[2] + "/" + arr_AS1_Q4[1] + "/" + arr_AS1_Q4[0];
            }




            DateTime dt_AS1_Q5 = new DateTime();
            string[] arr_AS1_Q5 = null;
            string val_AS1_Q5 = null;

            if (AS1_Q5.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS1_Q5 = Convert.ToDateTime(AS1_Q5.Text);

                arr_AS1_Q5 = dt_AS1_Q5.ToShortDateString().Split('/');
                val_AS1_Q5 = arr_AS1_Q5[2] + "/" + arr_AS1_Q5[1] + "/" + arr_AS1_Q5[0];
            }




            DateTime dt_AS1_Q6 = new DateTime();
            string[] arr_AS1_Q6 = null;
            string val_AS1_Q6 = null;

            if (AS1_Q6.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS1_Q6 = Convert.ToDateTime(AS1_Q6.Text);

                arr_AS1_Q6 = dt_AS1_Q6.ToShortDateString().Split('/');
                val_AS1_Q6 = arr_AS1_Q6[2] + "/" + arr_AS1_Q6[1] + "/" + arr_AS1_Q6[0];
            }




            DateTime dt_AS1_Q6c = new DateTime();
            string[] arr_AS1_Q6c = null;
            string val_AS1_Q6c = null;

            if (AS1_Q6c.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS1_Q6c = Convert.ToDateTime(AS1_Q6c.Text);

                arr_AS1_Q6c = dt_AS1_Q6c.ToShortDateString().Split('/');
                val_AS1_Q6c = arr_AS1_Q6c[2] + "/" + arr_AS1_Q6c[1] + "/" + arr_AS1_Q6c[0];
            }




            DateTime dt_AS2_Q9 = new DateTime();
            string[] arr_AS2_Q9 = null;
            string val_AS2_Q9 = null;

            if (AS2_Q9.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS2_Q9 = Convert.ToDateTime(AS2_Q9.Text);

                arr_AS2_Q9 = dt_AS2_Q9.ToShortDateString().Split('/');
                val_AS2_Q9 = arr_AS2_Q9[2] + "/" + arr_AS2_Q9[1] + "/" + arr_AS2_Q9[0];
            }




            DateTime dt_AS2_Q10 = new DateTime();

            if (AS2_Q10.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS2_Q10 = Convert.ToDateTime(AS2_Q10.Text);
            }




            DateTime dt_AS2_Q13a = new DateTime();

            if (AS2_Q13a.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS2_Q13a = Convert.ToDateTime(AS2_Q13a.Text);
            }




            DateTime dt_AS3_Q14a = new DateTime();
            string[] arr_AS3_Q14a = null;
            string val_AS3_Q14a = null;

            if (AS3_Q14a.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS3_Q14a = Convert.ToDateTime(AS3_Q14a.Text);

                arr_AS3_Q14a = dt_AS3_Q14a.ToShortDateString().Split('/');
                val_AS3_Q14a = arr_AS3_Q14a[2] + "/" + arr_AS3_Q14a[1] + "/" + arr_AS3_Q14a[0];
            }



            DateTime dt_AS3_Q15 = new DateTime();

            if (AS3_Q15.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS3_Q15 = Convert.ToDateTime(AS3_Q15.Text);
            }




            DateTime dt_AS3_Q17 = new DateTime();

            if (AS3_Q17.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS3_Q17 = Convert.ToDateTime(AS3_Q17.Text);
            }




            DateTime dt_AS3_Q20 = new DateTime();

            if (AS3_Q20.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS3_Q20 = Convert.ToDateTime(AS3_Q20.Text);
            }





            DateTime dt_AS4_Q22a = new DateTime();

            if (AS4_Q22a.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS4_Q22a = Convert.ToDateTime(AS4_Q22a.Text);
            }





            DateTime dt_AS4_Q22b = new DateTime();
            string[] arr_AS4_Q22b = null;
            string val_AS4_Q22b = null;

            if (AS4_Q22b.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS4_Q22b = Convert.ToDateTime(AS4_Q22b.Text);

                arr_AS4_Q22b = dt_AS4_Q22b.ToShortDateString().Split('/');
                val_AS4_Q22b = arr_AS4_Q22b[2] + "/" + arr_AS4_Q22b[1] + "/" + arr_AS4_Q22b[0];
            }





            DateTime dt_AS4_Q24 = new DateTime();

            if (AS4_Q24.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS4_Q24 = Convert.ToDateTime(AS4_Q24.Text);
            }





            DateTime dt_AS3_A2 = new DateTime();
            string[] arr_AS3_A2 = null;
            string val_AS3_A2 = null;

            if (AS3_A2.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS3_A2 = Convert.ToDateTime(AS3_A2.Text);

                arr_AS3_A2 = dt_AS3_A2.ToShortDateString().Split('/');
                val_AS3_A2 = arr_AS3_A2[2] + "/" + arr_AS3_A2[1] + "/" + arr_AS3_A2[0];
            }





            DateTime dt_AS3_B2 = new DateTime();
            string[] arr_AS3_B2 = null;
            string val_AS3_B2 = null;

            if (AS3_B2.Text != "")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                dt_AS3_B2 = Convert.ToDateTime(AS3_B2.Text);

                arr_AS3_B2 = dt_AS3_B2.ToShortDateString().Split('/');
                val_AS3_B2 = arr_AS3_B2[2] + "/" + arr_AS3_B2[1] + "/" + arr_AS3_B2[0];
            }




            DateTime dt_entry = new DateTime();

            string[] arr_entry = null;
            string val_entry = null;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            dt_entry = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            arr_entry = dt_entry.ToShortDateString().Split('/');
            val_entry = arr_entry[2] + "/" + arr_entry[1] + "/" + arr_entry[0];


            string qry = "UPDATE form1 set " +
"AS1_screening_ID = '" + AS1_screening_ID.Text + "', " +
"AS1_rand_id = '" + AS1_rand_id.Text + "', " +
"AS1_name = '" + AS1_name.Text + "', " +
"AS1_sex = '" + var_AS1_sex + "', " +
"AS1_age = '" + AS1_age.Text + "', " +
"AS1_barcode = '" + AS1_barcode.Text + "', " +
"AS1_mrno = '" + var_mrno1 + "', " +
"AS1_lno = '" + var_lno1 + "', " +
"AS1_barcode1 = '" + AS1_barcode1.Text + "', " +
"AS1_fsite = '" + var_AS1_fsite + "', " +
"AS1_Samp_1 = '" + var_AS1_Samp_1 + "', " +
"AS1_Samp_2 = '" + var_AS1_Samp_2 + "', " +
"AS1_Samp_3 = '" + var_AS1_Samp_3 + "', " +
"AS1_Samp_4 = '" + var_AS1_Samp_4 + "', " +
"AS1_Q1_1 = '" + var_AS1_Q1_1 + "', " +
"AS1_Q1_2 = '" + AS1_Q1_2.Text + "', " +
"AS1_Q2_1 = '" + var_AS1_Q2_1 + "', " +
"AS1_Q2_2 = '" + AS1_Q2_2.Text + "', " +
"AS1_Q3 = '" + var_AS1_Q3 + "', " +
"AS1_Q3a_1 = '" + var_AS1_Q3a_1 + "', " +
"AS1_Q3a_1a = '" + var_AS1_Q3a_11a + "', " +
"AS1_Q3b_1 = '" + var_AS1_Q3b_1 + "', " +
"AS1_Q3a_2 = '" + AS1_Q3a_2.Text + "', " +
"AS1_Q4 = '" + val_AS1_Q4 + "', " +
"AS1_Q5 = '" + val_AS1_Q5 + "', " +
"AS1_Q6 = '" + val_AS1_Q6 + "', " +
"AS1_Q6a = '" + AS1_Q6a.Text + "', " +
"AS1_Q6b = '" + AS1_Q6b.Text + "', " +
"AS1_Q6c = '" + val_AS1_Q6c + "', " +
"AS2_Q7_1 = '" + var_AS2_Q7_1 + "', " +
"AS2_Q7_2a = '" + var_mrno2 + "', " +
"AS2_Q7_2 = '" + var_lno2 + "', " +
"AS2_Q7_CBC_CODE = '" + AS2_Q7_CBC_CODE.Text + "', " +
"AS2_Q8 = '" + var_AS2_Q8 + "', " +
"AS2_Q8_BacT = '" + AS2_Q8_BacT.Text + "', " +
"AS2_Q8_3 = '" + AS2_Q8_3.Text + "', " +
"AS2_Q8a = '" + var_AS2_Q8a + "', " +
"AS2_Q8b = '" + var_AS2_Q8b + "', " +
"AS2_Q9 = '" + val_AS2_Q9 + "', " +
"AS2_Q10 = '" + dt_AS2_Q10.ToShortTimeString() + "', " +
"AS2_Q11 = '" + var_AS2_Q11 + "', " +
"AS2_Q12_1 = '" + AS2_Q12_1.Text + "', " +
"AS2_Q12_2 = '" + AS2_Q12_2.Text + "', " +
"AS2_Q12_3 = '" + AS2_Q12_3.Text + "', " +
"AS2_Q12_4 = '" + AS2_Q12_4.Text + "', " +
"AS2_Q13 = '" + AS2_Q13.Text + "', " +
"AS2_Q13a = '" + dt_AS2_Q13a.ToShortTimeString() + "', " +
"AS3_Q14 = '" + AS3_Q14.Text + "', " +
"AS3_Q14a = '" + val_AS3_Q14a + "', " +
"AS3_Q15 = '" + dt_AS3_Q15.ToShortTimeString() + "', " +
"AS3_Q16 = '" + AS3_Q16.Text + "', " +
"AS3_Q17 = '" + dt_AS3_Q17.ToShortTimeString() + "', " +
"AS3_Q18 = '" + AS3_Q18.Text + "', " +
"AS3_Q19 = '" + AS3_Q19.Text + "', " +
"AS3_Q20 = '" + dt_AS3_Q20.ToShortTimeString() + "', " +
"AS4_Q21a = '" + var_AS4_Q21a + "', " +
"AS4_Q22a = '" + dt_AS4_Q22a.ToShortTimeString() + "', " +
"AS4_Q22b = '" + val_AS4_Q22b + "', " +
"AS4_Q23 = '" + AS4_Q23.Text + "', " +
"AS4_Q24 = '" + dt_AS4_Q24.ToShortTimeString() + "', " +
"AS5_Q25a = '" + AS5_Q25a.Text + "', " +
"AS5_Q25b = '" + AS5_Q25b.Text + "', " +
"AS5_Q26 = '" + AS5_Q26.Text + "', " +
"AS5_Q27 = '" + var_AS5_Q27 + "', " +
"AS5_Q28 = '" + var_AS5_Q28 + "', " +
"AS5_Q29 = '" + var_AS5_Q29 + "', " +
"AS5_Q30 = '" + var_AS5_Q30 + "', " +
"AS5_Q31 = '" + var_AS5_Q31 + "', " +
"AS5_Q32 = '" + var_AS5_Q32 + "', " +
"AS5_Q33a = '" + AS5_Q33a.Text + "', " +
"AS5_Q33b = '" + AS5_Q33b.Text + "', " +
"AS3_Remarks = '" + AS3_Remarks.Text + "', " +
"AS6_Q34 = '" + AS6_Q34.Text + "', " +
"AS6_Q35 = '" + AS6_Q35.Text + "', " +
"AS6_Q36 = '" + AS6_Q36.Text + "', " +
"AS6_Q37 = '" + AS6_Q37.Text + "', " +
"AS6_Q38 = '" + AS6_Q38.Text + "', " +
"AS6_Q39 = '" + AS6_Q39.Text + "', " +
"AS6_Q40 = '" + AS6_Q40.Text + "', " +
"AS6_Q41= '" + AS6_Q41.Text + "', " +
"AS6_Q42= '" + AS6_Q42.Text + "', " +
"AS6_Q43= '" + AS6_Q43.Text + "', " +
"AS6_Q44= '" + AS6_Q44.Text + "', " +
"AS6_Q45= '" + AS6_Q45.Text + "', " +
"AS6_Q46= '" + AS6_Q46.Text + "', " +
"AS6_Q47= '" + AS6_Q47.Text + "', " +
"AS5_R1= '" + AS5_R1.Text + "', " +
"AS3_A1= '" + AS3_A1.Text + "', " +
"AS3_A2= '" + val_AS3_A2 + "', " +
"AS3_B1= '" + AS3_B1.Text + "', " +
"AS3_B2 = '" + val_AS3_B2 + "' WHERE id = '" + ViewState["id"].ToString() + "'";



            string msg = obj_op.ExecuteNonQuery_Message_Qry(qry);

            if (string.IsNullOrEmpty(msg))
            {
                ClearFields();

                string message = "alert('Record saved successfully');window.location.href='sample_recv.aspx'";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
            }
            else
            {
                string message = msg.Replace("'", "");
                message = msg.Replace(@"\", "");
                message = msg.Replace("/", "");

                message = "alert('" + msg + "');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
            }

        }

        catch (Exception ex)
        {
            string message = "alert('" + ex.Message + "');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
        }

        finally
        {
            obj_op = null;
        }
    }



    protected void chkMRNo_CheckedChanged(object sender, EventArgs e)
    {
        if (chkMRNo.Checked)
        {
            AS1_mrno.Text = "";
            AS1_mrno.Enabled = false;
            AS1_mrno.CssClass = "form-control";

            chkLNumber.Checked = false;
            AS1_lno.Enabled = true;
            AS1_lno.Focus();
        }
        else
        {
            AS1_mrno.Enabled = true;
            AS1_mrno.Focus();
        }
    }

    protected void chkLNumber_CheckedChanged(object sender, EventArgs e)
    {
        if (chkLNumber.Checked)
        {
            AS1_mrno.Enabled = true;
            AS1_mrno.Focus();


            chkMRNo.Checked = false;
            AS1_lno.Enabled = false;
            AS1_lno.Text = "";
            AS1_lno.CssClass = "form-control";
        }
        else
        {
            AS1_lno.Enabled = true;
            AS1_lno.Focus();
        }
    }

    protected void chk_AS2_Q7_2a_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_AS2_Q7_2a.Checked)
        {
            AS2_Q7_2a.CssClass = "form-control";
            AS2_Q7_2a.Text = "";
            AS2_Q7_2a.Enabled = false;

            chk_AS2_Q7_2.Checked = false;
            AS2_Q7_2.Enabled = true;
            AS2_Q7_2.Focus();
        }
        else
        {
            AS2_Q7_2a.Enabled = true;
            AS2_Q7_2a.Focus();
        }
    }

    protected void chk_AS2_Q7_2_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_AS2_Q7_2.Checked)
        {
            AS2_Q7_2.Text = "";
            AS2_Q7_2.Enabled = false;
            AS2_Q7_2.CssClass = "form-control";

            chk_AS2_Q7_2a.Checked = false;
            AS2_Q7_2a.Enabled = true;
            AS2_Q7_2a.Focus();
        }
        else
        {
            AS2_Q7_2.CssClass = "form-control";
            AS2_Q7_2.Enabled = true;
        }
    }

    protected void AS1_Q1_11_CheckedChanged(object sender, EventArgs e)
    {
        if (AS1_Q1_11.Checked)
        {
            pnl_AS4_Q21a.Visible = false;

            EnableControls1(AS3_Q16);
            EnableControls1(AS3_Q17);
            EnableControls1(AS3_Q18);
            EnableControls1(AS3_Q19);
            EnableControls1(AS3_Q20);

            AS4_Q21a.Checked = false;

            DisableControls1(AS4_Q22a);
            DisableControls1(AS4_Q22b);
            DisableControls1(AS4_Q23);
            DisableControls1(AS4_Q24);
            DisableControls1(AS5_Q25a);
            DisableControls1(AS5_Q25b);
            DisableControls1(AS5_Q26);


            Disable_RadioButton1(AS5_Q27_1);
            Disable_RadioButton1(AS5_Q27_2);
            Disable_RadioButton1(AS5_Q28_1);
            Disable_RadioButton1(AS5_Q28_2);
            Disable_RadioButton1(AS5_Q29_1);
            Disable_RadioButton1(AS5_Q29_2);
            Disable_RadioButton1(AS5_Q29_3);
            Disable_RadioButton1(AS5_Q30_1);
            Disable_RadioButton1(AS5_Q30_2);
            Disable_RadioButton1(AS5_Q30_3);
            Disable_RadioButton1(AS5_Q31_1);
            Disable_RadioButton1(AS5_Q31_2);
            Disable_RadioButton1(AS5_Q31_3);
            Disable_RadioButton1(AS5_Q31_4);
            Disable_RadioButton1(AS5_Q32_1);
            Disable_RadioButton1(AS5_Q32_2);
            Disable_RadioButton1(AS5_Q32_3);

            DisableControls1(AS5_Q33a);
            DisableControls1(AS5_Q33b);
            DisableControls1(AS3_Remarks);

        }
    }

    protected void AS1_Q1_12_CheckedChanged(object sender, EventArgs e)
    {
        if (AS1_Q1_12.Checked)
        {
            pnl_AS4_Q21a.Visible = true;

            DisableControls1(AS3_Q16);
            DisableControls1(AS3_Q17);
            DisableControls1(AS3_Q18);
            DisableControls1(AS3_Q19);
            DisableControls1(AS3_Q20);


            EnableControls1(AS4_Q22a);
            EnableControls1(AS4_Q22b);
            EnableControls1(AS4_Q23);
            EnableControls1(AS4_Q24);
            EnableControls1(AS5_Q25a);
            EnableControls1(AS5_Q25b);
            EnableControls1(AS5_Q26);


            Enable_RadioButton1(AS5_Q27_1);
            Enable_RadioButton1(AS5_Q27_2);
            Enable_RadioButton1(AS5_Q28_1);
            Enable_RadioButton1(AS5_Q28_2);
            Enable_RadioButton1(AS5_Q29_1);
            Enable_RadioButton1(AS5_Q29_2);
            Enable_RadioButton1(AS5_Q29_3);
            Enable_RadioButton1(AS5_Q30_1);
            Enable_RadioButton1(AS5_Q30_2);
            Enable_RadioButton1(AS5_Q30_3);
            Enable_RadioButton1(AS5_Q31_1);
            Enable_RadioButton1(AS5_Q31_2);
            Enable_RadioButton1(AS5_Q31_3);
            Enable_RadioButton1(AS5_Q31_4);
            Enable_RadioButton1(AS5_Q32_1);
            Enable_RadioButton1(AS5_Q32_2);
            Enable_RadioButton1(AS5_Q32_3);

            EnableControls1(AS5_Q33a);
            EnableControls1(AS5_Q33b);
            EnableControls1(AS3_Remarks);
        }
    }



    private DataSet getSampleResult_ScrID()
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
    "[AS1_Q3]," +
    "[AS1_Q3a_1]," +
    "[AS1_Q3a_1a]," +
    "[AS1_Q3b_1]," +
    "[AS1_Q3a_2]," +
    "[AS1_Q4]," +
    "[AS1_Q5]," +
    "[AS1_Q6]," +
    "[AS1_Q6a]," +
    "[AS1_Q6b]," +
    "[AS1_Q6c]," +
    "[AS2_Q7_1]," +
    "[AS2_Q7_2]," +
    "[AS2_Q7_CBC_CODE]," +
    "[AS2_Q8]," +
    "[AS2_Q8_BacT]," +
    "[AS2_Q8_3]," +
    "[AS2_Q8a]," +
    "[AS2_Q8b]," +
    "convert(varchar(13), [AS2_Q9], 103) AS2_Q9," +
    "convert(varchar(5), [AS2_Q10], 114) [AS2_Q10]," +
    "[AS2_Q11]," +
    "[AS2_Q12_1]," +
    "[AS2_Q12_2]," +
    "[AS2_Q12_3]," +
    "[AS2_Q12_4]," +
    "[AS2_Q13]," +
    "[AS2_Q13a]," +
    "[AS3_Q14]," +
    "convert(varchar(13), [AS3_Q14a], 103) [AS3_Q14a]," +
    "convert(varchar(5), [AS3_Q15], 114) AS3_Q15," +
    "[AS3_Q16]," +
    "convert(varchar(5), [AS3_Q17], 114) [AS3_Q17]," +
    "[AS3_Q18]," +
    "[AS3_Q19]," +
    "convert(varchar(5), [AS3_Q20], 114) [AS3_Q20]," +
    "[AS4_Q21a]," +
    "convert(varchar(5), [AS4_Q22a], 114) [AS4_Q22a]," +
    "convert(varchar(13), [AS4_Q22b], 103) [AS4_Q22b]," +
    "[AS4_Q23]," +
    "convert(varchar(5), [AS4_Q24], 114) [AS4_Q24]," +
    "[AS5_Q25a]," +
    "[AS5_Q25b]," +
    "[AS5_Q26]," +
    "[AS5_Q27]," +
    "[AS5_Q28]," +
    "[AS5_Q29]," +
    "[AS5_Q30]," +
    "[AS5_Q31]," +
    "[AS5_Q32]," +
    "[AS5_Q33a]," +
    "[AS5_Q33b]," +
    "[AS3_Remarks]," +
    "[AS6_Q34]," +
    "[AS6_Q35]," +
    "[AS6_Q36]," +
    "[AS6_Q37]," +
    "[AS6_Q38]," +
    "[AS6_Q39]," +
    "[AS6_Q40]," +
    "[AS6_Q41]," +
    "[AS6_Q42]," +
    "[AS6_Q43]," +
    "[AS6_Q44]," +
    "[AS6_Q45]," +
    "[AS6_Q46]," +
    "[AS6_Q47]," +
    "[AS5_R1]," +
    "[AS3_A1]," +
    "convert(varchar(13), [AS3_A2], 103) [AS3_A2]," +
    "[AS3_B1]," +
    "convert(varchar(13), [AS3_B2], 103) [AS3_B2]," +
    "[AS1_lno]," +
    "[AS2_Q7_2a]" +
    " from form1 b where b.id = '" + ViewState["id"] + "'", cn.cn);
        DataSet ds = new DataSet();
        da.Fill(ds);

        return ds;
    }


    private DataSet getDictionary_Cols(string formname)
    {
        CConnection cn = new CConnection();
        SqlDataAdapter da = new SqlDataAdapter("select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '" + formname + "' order by ordinal_position", cn.cn);
        DataSet ds = new DataSet();
        da.Fill(ds);

        return ds;
    }



    private bool AuditTrials()
    {
        bool IsSucess = false;

        CDBOperations obj_op = null;
        DataSet ds = null;
        DataSet ds_dict = null;


        try
        {

            obj_op = new CDBOperations();

            //ds = obj_op.GetFormData_VisitID("sp_GetRecords", "5", la_sno.Text, "");
            ds = getSampleResult_ScrID();


            //ds_dict = obj_op.GetFormData_VisitID1("sp_GetRecords1", "0", "", "", "sample_result");
            ds_dict = getDictionary_Cols("form1");



            for (int a = 0; a <= ds_dict.Tables[0].Rows.Count - 1; a++)
            {

                for (int b = 0; b <= ds.Tables[0].Rows.Count - 1; b++)
                {

                    //if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "ID" && ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "FORM_ID" && ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "COMP_ID" && ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "EntryDate" && ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "UserID" && ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "IsPilotPhase" && ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "RR1_DIFF" && ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "RR2_DIFF")

                    if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() != "ID"
                        && ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() != "UserID"
                        && ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() != "EntryDate"
                        && ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() != "labid"
                        && ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() != "AS1_screening_ID"
                        && ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() != "AS1_Samp_4"
                        && ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() != "AS1_Q2_1"
                        && ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() != "AS1_Q3"
                        && ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() != "AS1_Q3a_1"
                        && ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() != "AS1_Q3a_1a"
                        && ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() != "AS1_Q3b_1"
                        && ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() != "AS2_Q8a"
                        && ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() != "AS2_Q8b"
                        && ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() != "AS1_Q6a"
                        )
                    {

                        //if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString() != tabControl1.TabPages[Convert.ToInt32(ds_dict.Tables[0].Rows[a]["TabPageNo"].ToString())].Controls[ds_dict.Tables[0].Rows[a]["var_id"].ToString()].Text)


                        if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS1_sex")
                        {

                            string[] arr = ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString().Split('_');
                            string rdo_id_a = arr[0] + "_" + arr[1] + "_a";
                            string rdo_id_b = arr[0] + "_" + arr[1] + "_b";


                            RadioButton rdo_a = (RadioButton)Page.FindControl(rdo_id_a);
                            RadioButton rdo_b = (RadioButton)Page.FindControl(rdo_id_b);

                            string rdo_val = "0";

                            if (rdo_a.Checked == true)
                            {
                                rdo_val = "1";
                            }
                            else if (rdo_b.Checked == true)
                            {
                                rdo_val = "2";
                            }


                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != rdo_val)
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), rdo_val, "", "");

                            }


                        }
                        else if (
                            ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS1_Q1_1" ||
                            ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS2_Q7_1"
                            )
                        {

                            string[] arr = ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString().Split('_');
                            string rdo_id_a = arr[0] + "_" + arr[1] + "_11";
                            string rdo_id_b = arr[0] + "_" + arr[1] + "_12";


                            RadioButton rdo_a = (RadioButton)Page.FindControl(rdo_id_a);
                            RadioButton rdo_b = (RadioButton)Page.FindControl(rdo_id_b);

                            string rdo_val = "0";

                            if (rdo_a.Checked == true)
                            {
                                rdo_val = "1";
                            }
                            else if (rdo_b.Checked == true)
                            {
                                rdo_val = "2";
                            }


                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != rdo_val)
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), rdo_val, "", "");

                            }


                        }
                        else if (
                            ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS2_Q8" ||
                            ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS2_Q11" ||
                            ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS5_Q27" ||
                            ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS5_Q28"
                            )
                        {


                            string[] arr = ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString().Split('_');
                            string rdo_id_a = arr[0] + "_" + arr[1] + "_1";
                            string rdo_id_b = arr[0] + "_" + arr[1] + "_2";


                            RadioButton rdo_a = (RadioButton)Page.FindControl(rdo_id_a);
                            RadioButton rdo_b = (RadioButton)Page.FindControl(rdo_id_b);

                            string rdo_val = "0";

                            if (rdo_a.Checked == true)
                            {
                                rdo_val = "1";
                            }
                            else if (rdo_b.Checked == true)
                            {
                                rdo_val = "2";
                            }


                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != rdo_val)
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), rdo_val, "", "");

                            }


                        }
                        else if (
                            ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS5_Q29" ||
                            ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS5_Q30" ||
                            ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS5_Q32"
                            )
                        {


                            string rdo_val = "0";


                            string[] arr = ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString().Split('_');
                            string rdo_id_a = arr[0] + "_" + arr[1] + "_1";
                            string rdo_id_b = arr[0] + "_" + arr[1] + "_2";
                            string rdo_id_c = arr[0] + "_" + arr[1] + "_3";


                            RadioButton rdo_a = (RadioButton)Page.FindControl(rdo_id_a);
                            RadioButton rdo_b = (RadioButton)Page.FindControl(rdo_id_b);
                            RadioButton rdo_c = (RadioButton)Page.FindControl(rdo_id_c);


                            if (rdo_a.Checked == true)
                            {
                                rdo_val = "1";
                            }
                            else if (rdo_b.Checked == true)
                            {
                                rdo_val = "2";
                            }
                            else if (rdo_c.Checked == true)
                            {
                                rdo_val = "3";
                            }


                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != rdo_val)
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), rdo_val, "", "");

                            }


                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS1_fsite")
                        {


                            string rdo_val = "0";


                            string[] arr = ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString().Split('_');
                            string rdo_id_a = arr[0] + "_" + arr[1] + "_1";
                            string rdo_id_b = arr[0] + "_" + arr[1] + "_2";
                            string rdo_id_c = arr[0] + "_" + arr[1] + "_3";
                            string rdo_id_d = arr[0] + "_" + arr[1] + "_4";
                            string rdo_id_e = arr[0] + "_" + arr[1] + "_5";
                            string rdo_id_f = arr[0] + "_" + arr[1] + "_6";

                            RadioButton rdo_a = (RadioButton)Page.FindControl(rdo_id_a);
                            RadioButton rdo_b = (RadioButton)Page.FindControl(rdo_id_b);
                            RadioButton rdo_c = (RadioButton)Page.FindControl(rdo_id_c);
                            RadioButton rdo_d = (RadioButton)Page.FindControl(rdo_id_d);
                            RadioButton rdo_e = (RadioButton)Page.FindControl(rdo_id_e);
                            RadioButton rdo_f = (RadioButton)Page.FindControl(rdo_id_f);


                            if (rdo_a.Checked == true)
                            {
                                rdo_val = "1";
                            }
                            else if (rdo_b.Checked == true)
                            {
                                rdo_val = "2";
                            }
                            else if (rdo_c.Checked == true)
                            {
                                rdo_val = "3";
                            }
                            else if (rdo_d.Checked == true)
                            {
                                rdo_val = "4";
                            }
                            else if (rdo_e.Checked == true)
                            {
                                rdo_val = "5";
                            }
                            else if (rdo_f.Checked == true)
                            {
                                rdo_val = "6";
                            }



                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != rdo_val)
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), rdo_val, "", "");

                            }



                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS1_Samp_1")
                        {


                            string rdo_val = "0";


                            string[] arr = ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString().Split('_');
                            string rdo_id_a = arr[0] + "_" + arr[1] + "_1";


                            CheckBox rdo_a = (CheckBox)Page.FindControl(rdo_id_a);


                            if (rdo_a.Checked == true)
                            {
                                rdo_val = "1";
                            }


                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != rdo_val)
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), rdo_val, "", "");

                            }


                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS1_Samp_2")
                        {


                            string rdo_val = "0";


                            string[] arr = ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString().Split('_');
                            string rdo_id_b = arr[0] + "_" + arr[1] + "_2";

                            CheckBox rdo_b = (CheckBox)Page.FindControl(rdo_id_b);


                            if (rdo_b.Checked == true)
                            {
                                rdo_val = "2";
                            }


                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != rdo_val)
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), rdo_val, "", "");

                            }


                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS1_Samp_3")
                        {


                            string rdo_val = "0";


                            string[] arr = ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString().Split('_');
                            string rdo_id_a = arr[0] + "_" + arr[1] + "_3";


                            CheckBox rdo_a = (CheckBox)Page.FindControl(rdo_id_a);


                            if (rdo_a.Checked == true)
                            {
                                rdo_val = "3";
                            }


                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != rdo_val)
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), rdo_val, "", "");

                            }


                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS4_Q21a")
                        {


                            string rdo_val = "0";

                            CheckBox rdo_a = (CheckBox)Page.FindControl("AS4_Q21a");


                            if (rdo_a.Checked == true)
                            {
                                rdo_val = "1";
                            }


                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != rdo_val)
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), rdo_val, "", "");

                            }


                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS5_Q31")
                        {


                            string rdo_val = "0";


                            string[] arr = ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString().Split('_');
                            string rdo_id_a = arr[0] + "_" + arr[1] + "_1";
                            string rdo_id_b = arr[0] + "_" + arr[1] + "_2";
                            string rdo_id_c = arr[0] + "_" + arr[1] + "_3";
                            string rdo_id_d = arr[0] + "_" + arr[1] + "_4";

                            RadioButton rdo_a = (RadioButton)Page.FindControl(rdo_id_a);
                            RadioButton rdo_b = (RadioButton)Page.FindControl(rdo_id_b);
                            RadioButton rdo_c = (RadioButton)Page.FindControl(rdo_id_c);
                            RadioButton rdo_d = (RadioButton)Page.FindControl(rdo_id_d);


                            if (rdo_a.Checked == true)
                            {
                                rdo_val = "1";
                            }
                            else if (rdo_b.Checked == true)
                            {
                                rdo_val = "2";
                            }
                            else if (rdo_c.Checked == true)
                            {
                                rdo_val = "3";
                            }
                            else if (rdo_d.Checked == true)
                            {
                                rdo_val = "4";
                            }



                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != rdo_val)
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), rdo_val, "", "");

                            }


                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS2_Q9")
                        {


                            DateTime dt = new DateTime();
                            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                            dt = Convert.ToDateTime(AS2_Q9.Text);


                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != dt.ToShortDateString())
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), dt.ToShortDateString(), "", "");

                            }


                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS3_Q14a")
                        {


                            DateTime dt = new DateTime();
                            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                            dt = Convert.ToDateTime(AS3_Q14a.Text);


                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != dt.ToShortDateString())
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), dt.ToShortDateString(), "", "");

                            }


                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS3_A2")
                        {


                            DateTime dt = new DateTime();
                            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                            dt = Convert.ToDateTime(AS3_A2.Text);


                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != dt.ToShortDateString())
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), dt.ToShortDateString(), "", "");

                            }


                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS3_B2")
                        {


                            DateTime dt = new DateTime();
                            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                            dt = Convert.ToDateTime(AS3_B2.Text);


                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != dt.ToShortDateString())
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), dt.ToShortDateString(), "", "");

                            }


                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS2_Q10")
                        {


                            DateTime dt = new DateTime();
                            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                            dt = Convert.ToDateTime(AS2_Q10.Text);

                            string[] arr_tm = dt.ToShortTimeString().Split(':');
                            string str_tm = arr_tm[0] + ":" + arr_tm[1];


                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != str_tm)
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), dt.ToShortTimeString(), "", "");

                            }


                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS3_Q15")
                        {


                            DateTime dt = new DateTime();
                            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                            dt = Convert.ToDateTime(AS3_Q15.Text);

                            string[] arr_tm = dt.ToShortTimeString().Split(':');
                            string str_tm = arr_tm[0] + ":" + arr_tm[1];


                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != str_tm)
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), dt.ToShortTimeString(), "", "");

                            }


                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS3_Q17")
                        {


                            DateTime dt = new DateTime();
                            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                            dt = Convert.ToDateTime(AS3_Q17.Text);

                            string[] arr_tm = dt.ToShortTimeString().Split(':');
                            string str_tm = arr_tm[0] + ":" + arr_tm[1];


                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != str_tm)
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), dt.ToShortTimeString(), "", "");

                            }


                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS3_Q20")
                        {


                            DateTime dt = new DateTime();
                            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                            dt = Convert.ToDateTime(AS3_Q20.Text);

                            string[] arr_tm = dt.ToShortTimeString().Split(':');
                            string str_tm = arr_tm[0] + ":" + arr_tm[1];


                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != str_tm)
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), dt.ToShortTimeString(), "", "");

                            }


                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS1_Q4")
                        {

                            TextBox txt = (TextBox)Page.FindControl("AS1_Q4");


                            if (txt.Enabled == true && txt.Visible == true)
                            {

                                DateTime dt = new DateTime();
                                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                                dt = Convert.ToDateTime(AS1_Q4.Text);

                                string[] arr_tm = dt.ToShortTimeString().Split(':');
                                string str_tm = arr_tm[0] + ":" + arr_tm[1];


                                if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != str_tm)
                                {

                                    AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), dt.ToShortTimeString(), "", "");

                                }

                            }


                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS1_Q5")
                        {

                            TextBox txt = (TextBox)Page.FindControl("AS1_Q5");


                            if (txt.Enabled == true && txt.Visible == true)
                            {

                                DateTime dt = new DateTime();
                                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                                dt = Convert.ToDateTime(AS1_Q5.Text);


                                if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != dt.ToShortDateString())
                                {

                                    AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), dt.ToShortDateString(), "", "");

                                }

                            }


                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS1_Q6")
                        {

                            TextBox txt = (TextBox)Page.FindControl("AS1_Q6");


                            if (txt.Enabled == true && txt.Visible == true)
                            {

                                DateTime dt = new DateTime();
                                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                                dt = Convert.ToDateTime(AS1_Q6.Text);


                                string[] arr_tm = dt.ToShortTimeString().Split(':');
                                string str_tm = arr_tm[0] + ":" + arr_tm[1];



                                if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != str_tm)
                                {

                                    AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), dt.ToShortTimeString(), "", "");

                                }

                            }


                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS1_Q6c")
                        {

                            TextBox txt = (TextBox)Page.FindControl("AS1_Q6c");


                            if (txt.Enabled == true && txt.Visible == true)
                            {

                                DateTime dt = new DateTime();
                                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                                dt = Convert.ToDateTime(AS1_Q6c.Text);


                                string[] arr_tm = dt.ToShortTimeString().Split(':');
                                string str_tm = arr_tm[0] + ":" + arr_tm[1];



                                if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != str_tm)
                                {

                                    AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), dt.ToShortTimeString(), "", "");

                                }

                            }


                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS2_Q13a")
                        {

                            TextBox txt = (TextBox)Page.FindControl("AS2_Q13a");


                            if (txt.Enabled == true && txt.Visible == true)
                            {

                                DateTime dt = new DateTime();
                                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                                dt = Convert.ToDateTime(AS2_Q13a.Text);


                                string[] arr_tm = dt.ToShortTimeString().Split(':');
                                string str_tm = arr_tm[0] + ":" + arr_tm[1];



                                if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != str_tm)
                                {

                                    AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), dt.ToShortTimeString(), "", "");

                                }

                            }


                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS1_mrno")
                        {

                            TextBox txt = (TextBox)Page.FindControl(ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString());

                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != txt.Text)
                            {

                                if (txt.Text == "___-__-__" && string.IsNullOrEmpty(ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim()))
                                {

                                }
                                else
                                {
                                    AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), txt.Text, "", "");
                                }

                            }

                        }
                        else if (ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString() == "AS2_Q7_2a")
                        {

                            TextBox txt = (TextBox)Page.FindControl(ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString());

                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != txt.Text)
                            {

                                if (txt.Text == "___-__-__" && string.IsNullOrEmpty(ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim()))
                                {

                                }
                                else
                                {
                                    AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), txt.Text, "", "");
                                }

                            }

                        }
                        else
                        {

                            TextBox txt = (TextBox)Page.FindControl(ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString());


                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString().Trim() != txt.Text.Trim())
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["AS1_screening_ID"].ToString(), "", "", "form1", "Update", ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["COLUMN_NAME"].ToString()].ToString(), txt.Text, "", "");

                            }


                        }



                    }  //   if (ds.Tables[0].Rows[0][a].ToString() == tabControl1.TabPages[b].Controls[c].Name)



                }     //   for (int b = 0; b <= tabControl1.TabPages[b].Controls.Count - 1; c++)


            }     //    for (int a = 0; a <= ds.Tables[0].Columns.Count - 1; a++)

            IsSucess = true;

        }


        catch (Exception ex)
        {
            string message = "alert('" + ex.Message.Replace("'", "") + "');";
            message = "alert('" + ex.Message.Replace("\"", "") + "');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
            IsSucess = false;
        }

        finally
        {
            obj_op = null;
            ds = null;
        }

        return IsSucess;
    }



    private bool IsIncludedAudit(string tabname, string fieldname)
    {
        CDBOperations obj_op = new CDBOperations();
        CConnection cn = new CConnection();

        DataSet ds = null;

        bool IsError = false;

        try
        {
            //string[] fldname = { "tabname", "var_name", "var_id", "var_nmae", "var_seq", "field_desc", "remarks", "data_type", "field_len", "field_decimal", "MinValue", "MaxValue", "value1", "value2", "value3", "value4", "value5", "taborder", "msg", "IsOthers", "Others_Value", "No_Options", "Isblank", "fldvalue" };
            //string[] fldvalue = { tabname, "", fieldname, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "8" };

            //ds = obj_op.ExecuteNonQuery(fldname, fldvalue, "sp_CreateDictionary");

            SqlDataAdapter da = new SqlDataAdapter("select * from tbldict where tabname = '" + tabname + "' and var_id  = '" + fieldname + "' and isaudit is not null", cn.cn);
            ds = new DataSet();
            da.Fill(ds);


            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IsError = true;
                    }
                }
            }
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Exception Error", "alert('" + ex.Message.Replace("'", "") + "')", false);
        }

        finally
        {
            ds = null;
            obj_op = null;
        }

        return IsError;
    }



    private void AddRecord(string spName, string ChildID, string VisitID, string formNo, string FormName, string ActionPerformed, string FieldName, string OldValue, string NewValue, string IsUpdateNormal, string IsDualUpdate)
    {
        CConnection cn = new CConnection();
        CDBOperations obj_op = null;
        string[] st_dt;

        try
        {
            obj_op = new CDBOperations();

            st_dt = DateTime.Now.ToShortDateString().Split('/');


            DateTime start_dt = new DateTime();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            start_dt = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            DateTime start_dt1 = new DateTime();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            start_dt1 = Convert.ToDateTime(DateTime.Now.ToShortTimeString());


            //string[] fldname = { "FormID", "VisitID", "FormNo", "FormName", "ActionPerformed", "EntryDate", "EntryTime", "ComputerName", "WinUserName", "LoginUserName", "FieldName", "OldValue", "NewValue", "IsUpdateNormal", "IsDualUpdate" };
            ///string[] fldvalue = { ChildID, VisitID, formNo, FormName, ActionPerformed, start_dt.ToShortDateString(), start_dt1.ToShortTimeString(), "", Session["userid"].ToString(), Session["userid"].ToString(), FieldName, OldValue, NewValue, IsUpdateNormal, IsDualUpdate };

            //obj_op.ExecuteNonQuery(fldname, fldvalue, spName);


            string qry = "insert into tblAuditTrials (FormID, VisitID, FormNo, FormName, ActionPerformed, EntryDate, EntryTime, ComputerName, WinUserName, LoginUserName, FieldName, OldValue, NewValue, IsUpdateNormal, IsDualUpdate) values ('" +
                ChildID + "', '" + VisitID + "', '" + formNo + "', '" + FormName + "', '" + ActionPerformed + "', '" + start_dt.ToShortDateString() + "', '" + start_dt1.ToShortTimeString() + "', ''" + ", '" + Session["userid"].ToString() + "', '" + Session["userid"].ToString() + "', '" + FieldName + "', '" + OldValue + "', '" + NewValue + "', '" + IsUpdateNormal + "', '" + IsDualUpdate + "')";


            SqlDataAdapter da = new SqlDataAdapter(qry, cn.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

        }

        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Exception Error", "alert('" + ex.Message.Replace("'", "") + "')", false);
        }

        finally
        {
            obj_op = null;
        }
    }




}