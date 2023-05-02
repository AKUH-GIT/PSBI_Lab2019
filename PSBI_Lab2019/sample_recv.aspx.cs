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
            IsTestingServer();

            if (Request.Cookies["labid"].Value == "2")
            {
                cmdSave.OnClientClick = "return ValidateForm_NRL();";
            }
            else
            {
                cmdSave.OnClientClick = "return ValidateForm();";
            }


            if (Request.Cookies["labid"].Value == "3")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Permission Error", "alert('You are not authorize to view this web page')", false);
                Response.Redirect("login.aspx?errmsg=You are not authorize to view this web page");
                return;
            }


            if (Request.Cookies["labid"].Value == "2")
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

                ViewState["isupdate"] = "1";

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


    private void IsTestingServer()
    {
        if (Server.MachineName.ToString() != "pedres2")
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



    protected void cmdSave_Click(object sender, EventArgs e)
    {
        if (ViewState["isupdate"] == null)
        {
            SaveData();
        }
        else
        {
            UpdateData();
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
            UpdateData();
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
AS1_rand_id.Text + "', '" +
AS1_name.Text + "', '" +
var_AS1_sex + "', '" +
AS1_age.Text + "', '" +
AS1_barcode.Text + "', '" +
AS1_mrno.Text + "', '" +
AS1_lno.Text + "', '" +
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
AS2_Q7_2a.Text + "', '" +
AS2_Q7_2.Text + "', '" +
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
"AS1_mrno = '" + AS1_mrno.Text + "', " +
"AS1_lno = '" + AS1_lno.Text + "', " +
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
"AS2_Q7_2a = '" + AS2_Q7_2a.Text + "', " +
"AS2_Q7_2 = '" + AS2_Q7_2.Text + "', " +
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
"AS3_B2 = '" + val_AS3_B2 + "' WHERE AS1_screening_ID = '" + AS1_screening_ID.Text + "'";



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


}