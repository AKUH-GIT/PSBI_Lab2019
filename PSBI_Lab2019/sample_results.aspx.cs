using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Microsoft.Reporting.WebForms;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing;
using System.Text;
using System.IO;
using System.ServiceModel.Configuration;
using System.Diagnostics;
using System.Collections;
using System.Xml.Linq;


public partial class sample_results : System.Web.UI.Page
{
    private int m_currentPageIndex;
    private IList<Stream> m_streams;

    static DataTable dt_bloodculture = new DataTable();
    DataRow dr_bloodculture = null;
    static private int organism_sno;


    public List<CountryInfo> CountryInformation { get; set; }
    public List<SampleResults> SampleResultList { get; set; }


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





    public class SampleResults
    {
        public string la_sno { get; set; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["labid"] != null)
        {
            if (Request.Cookies["labid"].Value != "3")
            {
                cmdSave.OnClientClick = "return ValidateForm();";
            }
        }


        cmdSaveDraft.OnClientClick = "return ValidateForm1();";



        if (!IsPostBack)
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


                IsTestingServer();


                if (Request.QueryString["id"] != null && Request.Cookies["labid"].Value == "3")
                {
                    ViewState["id"] = Request.QueryString["id"].ToString();


                    getData1(ViewState["id"].ToString());
                    cmdSave.Visible = false;
                    cmdSaveDraft.Visible = true;
                    cmdCancel.Visible = true;
                    //txthistory.ReadOnly = true;

                    if (ViewState["organism_sno"] == "0")
                    {
                        CreateColsBloodCultureGrid();
                    }
                    else
                    {
                        fillGrid_BloodCulture();
                    }


                    Disable_IDRL_Section();

                    ViewState["isupdate"] = "1";

                    pnl_LA_01.Visible = false;
                    pnl_LA_02.Visible = false;
                    pnl_idrl.Visible = true;

                    previewReport();

                }
                else
                {

                    if (Request.QueryString["id"] != null && Request.Cookies["labid"].Value == "1")
                    {
                        ViewState["id"] = Request.QueryString["id"].ToString();


                        getData1(ViewState["id"].ToString());
                        ViewState["isupdate"] = "1";
                        cmdSave.Visible = true;
                        cmdSaveDraft.Visible = true;
                        cmdCancel.Visible = true;
                        txthistory.ReadOnly = false;

                        pnl_LA_01.Visible = false;
                        pnl_LA_02.Visible = false;
                        pnl_idrl.Visible = true;


                        if (ViewState["organism_sno"] == "0")
                        {
                            CreateColsBloodCultureGrid();
                        }
                        else
                        {
                            fillGrid_BloodCulture();
                        }


                        Enable_IDRL_Section();

                        previewReport();

                    }
                    else if (Request.QueryString["id"] != null && Request.Cookies["labid"].Value == "4")
                    {
                        ViewState["id"] = Request.QueryString["id"].ToString();


                        getData1(ViewState["id"].ToString());
                        cmdSave.Visible = false;
                        cmdSaveDraft.Visible = false;
                        cmdCancel.Visible = true;
                        //txthistory.ReadOnly = true;

                        if (ViewState["organism_sno"] == "0")
                        {
                            CreateColsBloodCultureGrid();
                        }
                        else
                        {
                            fillGrid_BloodCulture();
                        }



                        Disable_IDRL_Section();

                        ViewState["isupdate"] = "1";

                        pnl_LA_01.Visible = false;
                        pnl_LA_02.Visible = false;
                        pnl_idrl.Visible = true;

                        previewReport();

                    }
                    else
                    {

                        if (Request.QueryString["id"] == null && Request.Cookies["labid"].Value == "2")
                        {
                            Disable_IDRL_Section();
                        }
                        else
                        {
                            Enable_IDRL_Section();
                        }

                    }

                }

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



    private void Disable_IDRL_Section()
    {

        EnableControls(LA_01);
        EnableControls(LA_02);
        EnableControls(LA_02a);

        Disable_RadioButton(LA_03_v);
        Disable_RadioButton(LA_03_b);
        Disable_RadioButton(LA_03_c);
        DisableControls1(LA_03_a);


        Disable_RadioButton(LA_04_v);
        Disable_RadioButton(LA_04_b);
        Disable_RadioButton(LA_04_c);
        DisableControls1(LA_04_a);


        Disable_RadioButton(LA_05_v);
        Disable_RadioButton(LA_05_b);
        Disable_RadioButton(LA_05_c);
        DisableControls1(LA_05_a);


        Disable_RadioButton(LA_06_v);
        Disable_RadioButton(LA_06_b);
        Disable_RadioButton(LA_06_c);
        DisableControls1(LA_06_a);


        Disable_RadioButton(LA_07_v);
        Disable_RadioButton(LA_07_b);
        Disable_RadioButton(LA_07_c);
        DisableControls1(LA_07_a);


        Disable_RadioButton(LA_08_v);
        Disable_RadioButton(LA_08_b);
        Disable_RadioButton(LA_08_c);
        DisableControls1(LA_08_a);


        Disable_RadioButton(LA_09_v);
        Disable_RadioButton(LA_09_b);
        Disable_RadioButton(LA_09_c);
        DisableControls1(LA_09_a);


        Disable_RadioButton(LA_10_v);
        Disable_RadioButton(LA_10_b);
        Disable_RadioButton(LA_10_c);
        DisableControls1(LA_10_a);


        Disable_RadioButton(LA_11_v);
        Disable_RadioButton(LA_11_b);
        Disable_RadioButton(LA_11_c);
        DisableControls1(LA_11_a);


        Disable_RadioButton(LA_12_v);
        Disable_RadioButton(LA_12_b);
        Disable_RadioButton(LA_12_c);
        DisableControls1(LA_12_a);


        Disable_RadioButton(LA_13_v);
        Disable_RadioButton(LA_13_b);
        Disable_RadioButton(LA_13_c);
        DisableControls1(LA_13_a);


        Disable_RadioButton(LA_14_v);
        Disable_RadioButton(LA_14_b);
        Disable_RadioButton(LA_14_c);
        DisableControls1(LA_14_a);


        Disable_RadioButton(LA_15_v);
        Disable_RadioButton(LA_15_b);
        Disable_RadioButton(LA_15_c);
        DisableControls1(LA_15_a);


        Disable_RadioButton(LA_16_v);
        Disable_RadioButton(LA_16_b);
        Disable_RadioButton(LA_16_c);
        DisableControls1(LA_16_a);



        Disable_RadioButton(LF_01_v);
        Disable_RadioButton(LF_01_b);
        Disable_RadioButton(LF_01_c);
        DisableControls1(LF_01_a);



        Disable_RadioButton(LF_02_v);
        Disable_RadioButton(LF_02_b);
        Disable_RadioButton(LF_02_c);
        DisableControls1(LF_02_a);


        Disable_RadioButton(LF_03_v);
        Disable_RadioButton(LF_03_b);
        Disable_RadioButton(LF_03_c);
        DisableControls1(LF_03_a);


        Disable_RadioButton(LF_04_v);
        Disable_RadioButton(LF_04_b);
        Disable_RadioButton(LF_04_c);
        DisableControls1(LF_04_a);


        Disable_RadioButton(LF_05_v);
        Disable_RadioButton(LF_05_b);
        Disable_RadioButton(LF_05_c);
        DisableControls1(LF_05_a);


        Disable_RadioButton(LF_06_v);
        Disable_RadioButton(LF_06_b);
        Disable_RadioButton(LF_06_c);
        DisableControls1(LF_06_a);


        Disable_RadioButton(LF_07_v);
        Disable_RadioButton(LF_07_b);
        Disable_RadioButton(LF_07_c);
        DisableControls1(LF_07_a);



        Disable_RadioButton(RF_01_v);
        Disable_RadioButton(RF_01_b);
        Disable_RadioButton(RF_01_c);
        DisableControls1(RF_01_a);



        Disable_RadioButton(RF_03_v);
        Disable_RadioButton(RF_03_b);
        Disable_RadioButton(RF_03_c);
        DisableControls1(RF_03_a);


        Disable_RadioButton(RF_04_v);
        Disable_RadioButton(RF_04_b);
        Disable_RadioButton(RF_04_c);
        DisableControls1(RF_04_a);


        Disable_RadioButton(SE_01_v);
        Disable_RadioButton(SE_01_b);
        Disable_RadioButton(SE_01_c);
        DisableControls1(SE_01_a);


        Disable_RadioButton(SE_02_v);
        Disable_RadioButton(SE_02_b);
        Disable_RadioButton(SE_02_c);
        DisableControls1(SE_02_a);


        Disable_RadioButton(SE_03_v);
        Disable_RadioButton(SE_03_b);
        Disable_RadioButton(SE_03_c);
        DisableControls1(SE_03_a);


        Disable_RadioButton(SE_04_v);
        Disable_RadioButton(SE_04_b);
        Disable_RadioButton(SE_04_c);
        DisableControls1(SE_04_a);


        Disable_RadioButton(CS_01_v);
        Disable_RadioButton(CS_01_b);
        Disable_RadioButton(CS_01_c);
        DisableControls1(CS_01_a);



        Disable_RadioButton(CS_02_v);
        Disable_RadioButton(CS_02_b);
        Disable_RadioButton(CS_02_c);
        DisableControls1(CS_02_a);



        Disable_RadioButton(CS_03_v);
        Disable_RadioButton(CS_03_b);
        Disable_RadioButton(CS_03_c);
        DisableControls1(CS_03_a);


        Disable_RadioButton(CS_04_v);
        Disable_RadioButton(CS_04_b);
        Disable_RadioButton(CS_04_c);
        DisableControls1(CS_04_a);



        Disable_RadioButton(CS_05_v);
        Disable_RadioButton(CS_05_b);
        Disable_RadioButton(CS_05_c);
        DisableControls1(CS_05_a);


        Disable_RadioButton(CS_06_v);
        Disable_RadioButton(CS_06_b);
        Disable_RadioButton(CS_06_c);
        DisableControls1(CS_06_a);


        Disable_RadioButton(CS_07_v);
        Disable_RadioButton(CS_07_b);
        Disable_RadioButton(CS_07_c);
        DisableControls1(CS_07_a);


        Disable_RadioButton(CS_08_v);
        Disable_RadioButton(CS_08_b);
        Disable_RadioButton(CS_08_c);
        DisableControls1(CS_08_a);



        Disable_RadioButton(CS_09_v);
        Disable_RadioButton(CS_09_b);
        Disable_RadioButton(CS_09_c);
        DisableControls1(CS_09_a);


        Disable_RadioButton(CS_10_v);
        Disable_RadioButton(CS_10_b);
        Disable_RadioButton(CS_10_c);
        DisableControls1(CS_10_a);



        Disable_RadioButton(UR_01_v);
        Disable_RadioButton(UR_01_b);
        Disable_RadioButton(UR_01_c);
        DisableControls1(UR_01_a);


        Disable_RadioButton(UR_02_v);
        Disable_RadioButton(UR_02_b);
        Disable_RadioButton(UR_02_c);
        DisableControls1(UR_02_a);


        Disable_RadioButton(UR_03_v);
        Disable_RadioButton(UR_03_b);
        Disable_RadioButton(UR_03_c);
        DisableControls1(UR_03_a);


        Disable_RadioButton(UR_04_v);
        Disable_RadioButton(UR_04_b);
        Disable_RadioButton(UR_04_c);
        DisableControls1(UR_04_a);


        Disable_RadioButton(UR_04a_v);
        Disable_RadioButton(UR_04a_b);
        Disable_RadioButton(UR_04a_c);
        DisableControls1(UR_04a_a);


        Disable_RadioButton(UR_05_v);
        Disable_RadioButton(UR_05_b);
        Disable_RadioButton(UR_05_c);
        DisableControls1(UR_05_a);


        Disable_RadioButton(UR_06_v);
        Disable_RadioButton(UR_06_b);
        Disable_RadioButton(UR_06_c);
        DisableControls1(UR_06_a);


        Disable_RadioButton(UR_07_v);
        Disable_RadioButton(UR_07_b);
        Disable_RadioButton(UR_07_c);
        DisableControls1(UR_07_a);


        Disable_RadioButton(UR_08_v);
        Disable_RadioButton(UR_08_b);
        Disable_RadioButton(UR_08_c);
        DisableControls1(UR_08_a);



        Disable_RadioButton(UR_10_v);
        Disable_RadioButton(UR_10_b);
        Disable_RadioButton(UR_10_c);
        DisableControls1(UR_10_a);


        Disable_RadioButton(UR_11_v);
        Disable_RadioButton(UR_11_b);
        Disable_RadioButton(UR_11_c);
        DisableControls1(UR_11_a);


        Disable_RadioButton(UR_12_v);
        Disable_RadioButton(UR_12_b);
        Disable_RadioButton(UR_12_c);
        DisableControls1(UR_12_a);


        Disable_RadioButton(UR_13_v);
        Disable_RadioButton(UR_13_b);
        Disable_RadioButton(UR_13_c);
        DisableControls1(UR_13_a);


        Disable_RadioButton(UR_14_v);
        Disable_RadioButton(UR_14_b);
        Disable_RadioButton(UR_14_c);
        DisableControls1(UR_14_a);


        Disable_RadioButton(UR_15_v);
        Disable_RadioButton(UR_15_b);
        Disable_RadioButton(UR_15_c);
        DisableControls1(UR_15_a);


        Disable_RadioButton(UR_16_v);
        Disable_RadioButton(UR_16_b);
        Disable_RadioButton(UR_16_c);
        DisableControls1(UR_16_a);


        Disable_RadioButton(UR_17_v);
        Disable_RadioButton(UR_17_b);
        Disable_RadioButton(UR_17_c);
        DisableControls1(UR_17_a);



        Disable_RadioButton(UR_18_v);
        Disable_RadioButton(UR_18_b);
        Disable_RadioButton(UR_18_c);
        DisableControls1(UR_18_a);



        Disable_RadioButton(UR_19_v);
        Disable_RadioButton(UR_19_b);
        Disable_RadioButton(UR_19_c);
        DisableControls1(UR_19_a);


        Disable_RadioButton(UR_20_v);
        Disable_RadioButton(UR_20_b);
        Disable_RadioButton(UR_20_c);
        DisableControls1(UR_20_a);



        Disable_RadioButton(UR_21_v);
        Disable_RadioButton(UR_21_b);
        Disable_RadioButton(UR_21_c);
        DisableControls1(UR_21_a);


        Disable_RadioButton(uc_01_a);
        Disable_RadioButton(uc_01_b);
        Disable_RadioButton(uc_01_c);
        DisableControls1(uc_01_ca);


        Disable_RadioButton(uc_02a_v);
        Disable_RadioButton(uc_02a_b);
        Disable_RadioButton(uc_02a_c);
        DisableControls1(uc_02a_a);
        Disable_RadioButton(uc_02b_a);
        Disable_RadioButton(uc_02b_b);
        Disable_RadioButton(uc_02b_c);


        Disable_RadioButton(uc_03a_v);
        Disable_RadioButton(uc_03a_b);
        Disable_RadioButton(uc_03a_c);
        DisableControls1(uc_03a_a);
        Disable_RadioButton(uc_03b_a);
        Disable_RadioButton(uc_03b_b);
        Disable_RadioButton(uc_03b_c);


        Disable_RadioButton(uc_04a_v);
        Disable_RadioButton(uc_04a_b);
        Disable_RadioButton(uc_04a_c);
        DisableControls1(uc_04a_a);
        Disable_RadioButton(uc_04b_a);
        Disable_RadioButton(uc_04b_b);
        Disable_RadioButton(uc_04b_c);


        Disable_RadioButton(uc_05a_v);
        Disable_RadioButton(uc_05a_b);
        Disable_RadioButton(uc_05a_c);
        DisableControls1(uc_05a_a);
        Disable_RadioButton(uc_05b_a);
        Disable_RadioButton(uc_05b_b);
        Disable_RadioButton(uc_05b_c);


        Disable_RadioButton(uc_06a_v);
        Disable_RadioButton(uc_06a_b);
        Disable_RadioButton(uc_06a_c);
        DisableControls1(uc_06a_a);
        Disable_RadioButton(uc_06b_a);
        Disable_RadioButton(uc_06b_b);
        Disable_RadioButton(uc_06b_c);


        Disable_RadioButton(uc_07a_v);
        Disable_RadioButton(uc_07a_b);
        Disable_RadioButton(uc_07a_c);
        DisableControls1(uc_07a_a);
        Disable_RadioButton(uc_07b_a);
        Disable_RadioButton(uc_07b_b);
        Disable_RadioButton(uc_07b_c);


        Disable_RadioButton(uc_08a_v);
        Disable_RadioButton(uc_08a_b);
        Disable_RadioButton(uc_08a_c);
        DisableControls1(uc_08a_a);
        Disable_RadioButton(uc_08b_a);
        Disable_RadioButton(uc_08b_b);
        Disable_RadioButton(uc_08b_c);



        Disable_RadioButton(uc_09a_v);
        Disable_RadioButton(uc_09a_b);
        Disable_RadioButton(uc_09a_c);
        DisableControls1(uc_09a_a);
        Disable_RadioButton(uc_09b_a);
        Disable_RadioButton(uc_09b_b);
        Disable_RadioButton(uc_09b_c);



        Disable_RadioButton(uc_10a_v);
        Disable_RadioButton(uc_10a_b);
        Disable_RadioButton(uc_10a_c);
        DisableControls1(uc_10a_a);
        Disable_RadioButton(uc_10b_a);
        Disable_RadioButton(uc_10b_b);
        Disable_RadioButton(uc_10b_c);



        Disable_RadioButton(uc_11a_v);
        Disable_RadioButton(uc_11a_b);
        Disable_RadioButton(uc_11a_c);
        DisableControls1(uc_11a_a);
        Disable_RadioButton(uc_11b_a);
        Disable_RadioButton(uc_11b_b);
        Disable_RadioButton(uc_11b_c);



        Disable_RadioButton(uc_12a_v);
        Disable_RadioButton(uc_12a_b);
        Disable_RadioButton(uc_12a_c);
        DisableControls1(uc_12a_a);
        Disable_RadioButton(uc_12b_a);
        Disable_RadioButton(uc_12b_b);
        Disable_RadioButton(uc_12b_c);



        Disable_RadioButton(uc_13a_v);
        Disable_RadioButton(uc_13a_b);
        Disable_RadioButton(uc_13a_c);
        DisableControls1(uc_13a_a);
        Disable_RadioButton(uc_13b_a);
        Disable_RadioButton(uc_13b_b);
        Disable_RadioButton(uc_13b_c);



        Disable_RadioButton(uc_14a_v);
        Disable_RadioButton(uc_14a_b);
        Disable_RadioButton(uc_14a_c);
        DisableControls1(uc_14a_a);
        Disable_RadioButton(uc_14b_a);
        Disable_RadioButton(uc_14b_b);
        Disable_RadioButton(uc_14b_c);



        Disable_RadioButton(uc_15a_v);
        Disable_RadioButton(uc_15a_b);
        Disable_RadioButton(uc_15a_c);
        DisableControls1(uc_15a_a);
        Disable_RadioButton(uc_15b_a);
        Disable_RadioButton(uc_15b_b);
        Disable_RadioButton(uc_15b_c);



        Disable_RadioButton(uc_16a_v);
        Disable_RadioButton(uc_16a_b);
        Disable_RadioButton(uc_16a_c);
        DisableControls1(uc_16a_a);
        Disable_RadioButton(uc_16b_a);
        Disable_RadioButton(uc_16b_b);
        Disable_RadioButton(uc_16b_c);



        Disable_RadioButton(uc_17a_v);
        Disable_RadioButton(uc_17a_b);
        Disable_RadioButton(uc_17a_c);
        DisableControls1(uc_17a_a);
        Disable_RadioButton(uc_17b_a);
        Disable_RadioButton(uc_17b_b);
        Disable_RadioButton(uc_17b_c);



        Disable_RadioButton(uc_18a_v);
        Disable_RadioButton(uc_18a_b);
        Disable_RadioButton(uc_18a_c);
        DisableControls1(uc_18a_a);
        Disable_RadioButton(uc_18b_a);
        Disable_RadioButton(uc_18b_b);
        Disable_RadioButton(uc_18b_c);



        Disable_RadioButton(uc_19a_v);
        Disable_RadioButton(uc_19a_b);
        Disable_RadioButton(uc_19a_c);
        DisableControls1(uc_19a_a);
        Disable_RadioButton(uc_19b_a);
        Disable_RadioButton(uc_19b_b);
        Disable_RadioButton(uc_19b_c);



        Disable_RadioButton(uc_20a_v);
        Disable_RadioButton(uc_20a_b);
        Disable_RadioButton(uc_20a_c);
        DisableControls1(uc_20a_a);
        Disable_RadioButton(uc_20b_a);
        Disable_RadioButton(uc_20b_b);
        Disable_RadioButton(uc_20b_c);



        Disable_RadioButton(uc_21a_v);
        Disable_RadioButton(uc_21a_b);
        Disable_RadioButton(uc_21a_c);
        DisableControls1(uc_21a_a);
        Disable_RadioButton(uc_21b_a);
        Disable_RadioButton(uc_21b_b);
        Disable_RadioButton(uc_21b_c);


        Disable_RadioButton(uc_22a_v);
        Disable_RadioButton(uc_22a_b);
        Disable_RadioButton(uc_22a_c);
        DisableControls1(uc_22a_a);
        Disable_RadioButton(uc_22b_a);
        Disable_RadioButton(uc_22b_b);
        Disable_RadioButton(uc_22b_c);



        Disable_RadioButton(uc_23a_v);
        Disable_RadioButton(uc_23a_b);
        Disable_RadioButton(uc_23a_c);
        DisableControls1(uc_23a_a);
        Disable_RadioButton(uc_23b_a);
        Disable_RadioButton(uc_23b_b);
        Disable_RadioButton(uc_23b_c);



        Disable_RadioButton(uc_24a_v);
        Disable_RadioButton(uc_24a_b);
        Disable_RadioButton(uc_24a_c);
        DisableControls1(uc_24a_a);
        Disable_RadioButton(uc_24b_a);
        Disable_RadioButton(uc_24b_b);
        Disable_RadioButton(uc_24b_c);



        Disable_RadioButton(uc_25a_v);
        Disable_RadioButton(uc_25a_b);
        Disable_RadioButton(uc_25a_c);
        DisableControls1(uc_25a_a);
        Disable_RadioButton(uc_25b_a);
        Disable_RadioButton(uc_25b_b);
        Disable_RadioButton(uc_25b_c);



        Disable_RadioButton(uc_26a_v);
        Disable_RadioButton(uc_26a_b);
        Disable_RadioButton(uc_26a_c);
        DisableControls1(uc_26a_a);
        Disable_RadioButton(uc_26b_a);
        Disable_RadioButton(uc_26b_b);
        Disable_RadioButton(uc_26b_c);



        Disable_RadioButton(uc_27a_v);
        Disable_RadioButton(uc_27a_b);
        Disable_RadioButton(uc_27a_c);
        DisableControls1(uc_27a_a);
        Disable_RadioButton(uc_27b_a);
        Disable_RadioButton(uc_27b_b);
        Disable_RadioButton(uc_27b_c);




        Disable_RadioButton(uc_28a_v);
        Disable_RadioButton(uc_28a_b);
        Disable_RadioButton(uc_28a_c);
        DisableControls1(uc_28a_a);
        Disable_RadioButton(uc_28b_a);
        Disable_RadioButton(uc_28b_b);
        Disable_RadioButton(uc_28b_c);



        Disable_RadioButton(uc_29a_v);
        Disable_RadioButton(uc_29a_b);
        Disable_RadioButton(uc_29a_c);
        DisableControls1(uc_29a_a);
        Disable_RadioButton(uc_29b_a);
        Disable_RadioButton(uc_29b_b);
        Disable_RadioButton(uc_29b_c);



        Disable_RadioButton(uc_30a_v);
        Disable_RadioButton(uc_30a_b);
        Disable_RadioButton(uc_30a_c);
        DisableControls1(uc_30a_a);
        Disable_RadioButton(uc_30b_a);
        Disable_RadioButton(uc_30b_b);
        Disable_RadioButton(uc_30b_c);



        Disable_RadioButton(uc_31a_v);
        Disable_RadioButton(uc_31a_b);
        Disable_RadioButton(uc_31a_c);
        DisableControls1(uc_31a_a);
        Disable_RadioButton(uc_31b_a);
        Disable_RadioButton(uc_31b_b);
        Disable_RadioButton(uc_31b_c);



        Disable_RadioButton(uc_32a_v);
        Disable_RadioButton(uc_32a_b);
        Disable_RadioButton(uc_32a_c);
        DisableControls1(uc_32a_a);
        Disable_RadioButton(uc_32b_a);
        Disable_RadioButton(uc_32b_b);
        Disable_RadioButton(uc_32b_c);



        Disable_RadioButton(uc_33a_v);
        Disable_RadioButton(uc_33a_b);
        Disable_RadioButton(uc_33a_c);
        DisableControls1(uc_33a_a);
        Disable_RadioButton(uc_33b_a);
        Disable_RadioButton(uc_33b_b);
        Disable_RadioButton(uc_33b_c);



        Disable_RadioButton(uc_34a_v);
        Disable_RadioButton(uc_34a_b);
        Disable_RadioButton(uc_34a_c);
        DisableControls1(uc_34a_a);
        Disable_RadioButton(uc_34b_a);
        Disable_RadioButton(uc_34b_b);
        Disable_RadioButton(uc_34b_c);



        Disable_RadioButton(uc_35a_v);
        Disable_RadioButton(uc_35a_b);
        Disable_RadioButton(uc_35a_c);
        DisableControls1(uc_35a_a);
        Disable_RadioButton(uc_35b_a);
        Disable_RadioButton(uc_35b_b);
        Disable_RadioButton(uc_35b_c);



        Disable_RadioButton(uc_36a_v);
        Disable_RadioButton(uc_36a_b);
        Disable_RadioButton(uc_36a_c);
        DisableControls1(uc_36a_a);
        Disable_RadioButton(uc_36b_a);
        Disable_RadioButton(uc_36b_b);
        Disable_RadioButton(uc_36b_c);



        Disable_RadioButton(uc_37a_v);
        Disable_RadioButton(uc_37a_b);
        Disable_RadioButton(uc_37a_c);
        DisableControls1(uc_37a_a);
        Disable_RadioButton(uc_37b_a);
        Disable_RadioButton(uc_37b_b);
        Disable_RadioButton(uc_37b_c);



        if (Request.Cookies["labid"].Value == "3" ||
            Request.Cookies["labid"].Value == "4")
        {

            DisableControls1(ProvisionalResult);
            Disable_RadioButton(rd_BloodCulture_Pos);
            Disable_RadioButton(rd_BloodCulture_Neg);


            ddl_BloodCulture.Attributes.Add("disabled", "disabled");
            DisableControls1(txtOtherOrganism);

            Disable_RadioButton(BloodCulture_Multiple_Yes);
            Disable_RadioButton(BloodCulture_Multiple_No);


            if (Request.Cookies["labid"].Value == "2")
            {
                dg_BloodCulture.FooterRow.Visible = false;
            }


            dg_BloodCulture.Columns[4].Visible = false;
            dg_BloodCulture.Columns[5].Visible = false;
            dg_BloodCulture.Columns[6].Visible = false;

        }


        DisableControls1(LA_17);
        DisableControls1(LA_18);
        //DisableControls1(LA_19);


        Disable_RadioButton(LA_20a_v);
        Disable_RadioButton(LA_20a_b);
        Disable_RadioButton(LA_20a_c);
        DisableControls1(LA_20a_a);
        Disable_RadioButton(LA_20b_a);
        Disable_RadioButton(LA_20b_b);
        Disable_RadioButton(LA_20b_c);


        Disable_RadioButton(LA_21a_v);
        Disable_RadioButton(LA_21a_b);
        Disable_RadioButton(LA_21a_c);
        DisableControls1(LA_21a_a);
        Disable_RadioButton(LA_21b_a);
        Disable_RadioButton(LA_21b_b);
        Disable_RadioButton(LA_21b_c);


        Disable_RadioButton(LA_22a_v);
        Disable_RadioButton(LA_22a_b);
        Disable_RadioButton(LA_22a_c);
        DisableControls1(LA_22a_a);
        Disable_RadioButton(LA_22b_a);
        Disable_RadioButton(LA_22b_b);
        Disable_RadioButton(LA_22b_c);


        Disable_RadioButton(LA_23a_v);
        Disable_RadioButton(LA_23a_b);
        Disable_RadioButton(LA_23a_c);
        DisableControls1(LA_23a_a);
        Disable_RadioButton(LA_23b_a);
        Disable_RadioButton(LA_23b_b);
        Disable_RadioButton(LA_23b_c);


        Disable_RadioButton(LA_24a_v);
        Disable_RadioButton(LA_24a_b);
        Disable_RadioButton(LA_24a_c);
        DisableControls1(LA_24a_a);
        Disable_RadioButton(LA_24b_a);
        Disable_RadioButton(LA_24b_b);
        Disable_RadioButton(LA_24b_c);


        Disable_RadioButton(LA_25a_v);
        Disable_RadioButton(LA_25a_b);
        Disable_RadioButton(LA_25a_c);
        DisableControls1(LA_25a_a);
        Disable_RadioButton(LA_25b_a);
        Disable_RadioButton(LA_25b_b);
        Disable_RadioButton(LA_25b_c);


        Disable_RadioButton(LA_26a_v);
        Disable_RadioButton(LA_26a_b);
        Disable_RadioButton(LA_26a_c);
        DisableControls1(LA_26a_a);
        Disable_RadioButton(LA_26b_a);
        Disable_RadioButton(LA_26b_b);
        Disable_RadioButton(LA_26b_c);


        Disable_RadioButton(LA_27a_v);
        Disable_RadioButton(LA_27a_b);
        Disable_RadioButton(LA_27a_c);
        DisableControls1(LA_27a_a);
        Disable_RadioButton(LA_27b_a);
        Disable_RadioButton(LA_27b_b);
        Disable_RadioButton(LA_27b_c);


        Disable_RadioButton(LA_28a_v);
        Disable_RadioButton(LA_28a_b);
        Disable_RadioButton(LA_28a_c);
        DisableControls1(LA_28a_a);
        Disable_RadioButton(LA_28b_a);
        Disable_RadioButton(LA_28b_b);
        Disable_RadioButton(LA_28b_c);



        Disable_RadioButton(LA_29a_v);
        Disable_RadioButton(LA_29a_b);
        Disable_RadioButton(LA_29a_c);
        DisableControls1(LA_29a_a);
        Disable_RadioButton(LA_29b_a);
        Disable_RadioButton(LA_29b_b);
        Disable_RadioButton(LA_29b_c);



        Disable_RadioButton(LA_30a_v);
        Disable_RadioButton(LA_30a_b);
        Disable_RadioButton(LA_30a_c);
        DisableControls1(LA_30a_a);
        Disable_RadioButton(LA_30b_a);
        Disable_RadioButton(LA_30b_b);
        Disable_RadioButton(LA_30b_c);


        Disable_RadioButton(LA_31a_v);
        Disable_RadioButton(LA_31a_b);
        Disable_RadioButton(LA_31a_c);
        DisableControls1(LA_31a_a);
        Disable_RadioButton(LA_31b_a);
        Disable_RadioButton(LA_31b_b);
        Disable_RadioButton(LA_31b_c);


        Disable_RadioButton(LA_32a_v);
        Disable_RadioButton(LA_32a_b);
        Disable_RadioButton(LA_32a_c);
        DisableControls1(LA_32a_a);
        Disable_RadioButton(LA_32b_a);
        Disable_RadioButton(LA_32b_b);
        Disable_RadioButton(LA_32b_c);


        Disable_RadioButton(LA_33a_v);
        Disable_RadioButton(LA_33a_b);
        Disable_RadioButton(LA_33a_c);
        DisableControls1(LA_33a_a);
        Disable_RadioButton(LA_33b_a);
        Disable_RadioButton(LA_33b_b);
        Disable_RadioButton(LA_33b_c);


        Disable_RadioButton(LA_34a_v);
        Disable_RadioButton(LA_34a_b);
        Disable_RadioButton(LA_34a_c);
        DisableControls1(LA_34a_a);
        Disable_RadioButton(LA_34b_a);
        Disable_RadioButton(LA_34b_b);
        Disable_RadioButton(LA_34b_c);


        Disable_RadioButton(LA_35a_v);
        Disable_RadioButton(LA_35a_b);
        Disable_RadioButton(LA_35a_c);
        DisableControls1(LA_35a_a);
        Disable_RadioButton(LA_35b_a);
        Disable_RadioButton(LA_35b_b);
        Disable_RadioButton(LA_35b_c);


        Disable_RadioButton(LA_36a_v);
        Disable_RadioButton(LA_36a_b);
        Disable_RadioButton(LA_36a_c);
        DisableControls1(LA_36a_a);
        Disable_RadioButton(LA_36b_a);
        Disable_RadioButton(LA_36b_b);
        Disable_RadioButton(LA_36b_c);


        Disable_RadioButton(LA_37a_v);
        Disable_RadioButton(LA_37a_b);
        Disable_RadioButton(LA_37a_c);
        DisableControls1(LA_37a_a);
        Disable_RadioButton(LA_37b_a);
        Disable_RadioButton(LA_37b_b);
        Disable_RadioButton(LA_37b_c);


        Disable_RadioButton(LA_38a_v);
        Disable_RadioButton(LA_38a_b);
        Disable_RadioButton(LA_38a_c);
        DisableControls1(LA_38a_a);
        Disable_RadioButton(LA_38b_a);
        Disable_RadioButton(LA_38b_b);
        Disable_RadioButton(LA_38b_c);


        Disable_RadioButton(LA_39a_v);
        Disable_RadioButton(LA_39a_b);
        Disable_RadioButton(LA_39a_c);
        DisableControls1(LA_39a_a);
        Disable_RadioButton(LA_39b_a);
        Disable_RadioButton(LA_39b_b);
        Disable_RadioButton(LA_39b_c);



        Disable_RadioButton(LA_40a_v);
        Disable_RadioButton(LA_40a_b);
        Disable_RadioButton(LA_40a_c);
        DisableControls1(LA_40a_a);
        Disable_RadioButton(LA_40b_a);
        Disable_RadioButton(LA_40b_b);
        Disable_RadioButton(LA_40b_c);


        Disable_RadioButton(LA_41a_v);
        Disable_RadioButton(LA_41a_b);
        Disable_RadioButton(LA_41a_c);
        DisableControls1(LA_41a_a);
        Disable_RadioButton(LA_41b_a);
        Disable_RadioButton(LA_41b_b);
        Disable_RadioButton(LA_41b_c);


        Disable_RadioButton(LA_42a_v);
        Disable_RadioButton(LA_42a_b);
        Disable_RadioButton(LA_42a_c);
        DisableControls1(LA_42a_a);
        Disable_RadioButton(LA_42b_a);
        Disable_RadioButton(LA_42b_b);
        Disable_RadioButton(LA_42b_c);


        Disable_RadioButton(LA_43a_v);
        Disable_RadioButton(LA_43a_b);
        Disable_RadioButton(LA_43a_c);
        DisableControls1(LA_43a_a);
        Disable_RadioButton(LA_43b_a);
        Disable_RadioButton(LA_43b_b);
        Disable_RadioButton(LA_43b_c);


        Disable_RadioButton(LA_44a_v);
        Disable_RadioButton(LA_44a_b);
        Disable_RadioButton(LA_44a_c);
        DisableControls1(LA_44a_a);
        Disable_RadioButton(LA_44b_a);
        Disable_RadioButton(LA_44b_b);
        Disable_RadioButton(LA_44b_c);


        Disable_RadioButton(LA_45a_v);
        Disable_RadioButton(LA_45a_b);
        Disable_RadioButton(LA_45a_c);
        DisableControls1(LA_45a_a);
        Disable_RadioButton(LA_45b_a);
        Disable_RadioButton(LA_45b_b);
        Disable_RadioButton(LA_45b_c);


        Disable_RadioButton(LA_46a_v);
        Disable_RadioButton(LA_46a_b);
        Disable_RadioButton(LA_46a_c);
        DisableControls1(LA_46a_a);
        Disable_RadioButton(LA_46b_a);
        Disable_RadioButton(LA_46b_b);
        Disable_RadioButton(LA_46b_c);


        Disable_RadioButton(LA_47a_v);
        Disable_RadioButton(LA_47a_b);
        Disable_RadioButton(LA_47a_c);
        DisableControls1(LA_47a_a);
        Disable_RadioButton(LA_47b_a);
        Disable_RadioButton(LA_47b_b);
        Disable_RadioButton(LA_47b_c);


        Disable_RadioButton(LA_48a_v);
        Disable_RadioButton(LA_48a_b);
        Disable_RadioButton(LA_48a_c);
        DisableControls1(LA_48a_a);
        Disable_RadioButton(LA_48b_a);
        Disable_RadioButton(LA_48b_b);
        Disable_RadioButton(LA_48b_c);


        Disable_RadioButton(LA_49a_v);
        Disable_RadioButton(LA_49a_b);
        Disable_RadioButton(LA_49a_c);
        DisableControls1(LA_49a_a);
        Disable_RadioButton(LA_49b_a);
        Disable_RadioButton(LA_49b_b);
        Disable_RadioButton(LA_49b_c);


        Disable_RadioButton(LA_50a_v);
        Disable_RadioButton(LA_50a_b);
        Disable_RadioButton(LA_50a_c);
        DisableControls1(LA_50a_a);
        Disable_RadioButton(LA_50b_a);
        Disable_RadioButton(LA_50b_b);
        Disable_RadioButton(LA_50b_c);


        Disable_RadioButton(LA_51a_v);
        Disable_RadioButton(LA_51a_b);
        Disable_RadioButton(LA_51a_c);
        DisableControls1(LA_51a_a);
        Disable_RadioButton(LA_51b_a);
        Disable_RadioButton(LA_51b_b);
        Disable_RadioButton(LA_51b_c);


        Disable_RadioButton(LA_52a_v);
        Disable_RadioButton(LA_52a_b);
        Disable_RadioButton(LA_52a_c);
        DisableControls1(LA_52a_a);
        Disable_RadioButton(LA_52b_a);
        Disable_RadioButton(LA_52b_b);
        Disable_RadioButton(LA_52b_c);


        pnl_LA_01.Visible = true;
        pnl_LA_02.Visible = true;
        pnl_idrl.Visible = false;

    }


    private void Enable_IDRL_Section()
    {
        DisableControls(LA_01);
        DisableControls(LA_02);
        DisableControls(LA_02a);


        Enable_RadioButton(LA_03_v);
        Enable_RadioButton(LA_03_b);
        Enable_RadioButton(LA_03_c);
        EnableControls(LA_03_a);


        Enable_RadioButton(LA_04_v);
        Enable_RadioButton(LA_04_b);
        Enable_RadioButton(LA_04_c);
        EnableControls(LA_04_a);


        Enable_RadioButton(LA_05_v);
        Enable_RadioButton(LA_05_b);
        Enable_RadioButton(LA_05_c);
        EnableControls(LA_05_a);


        Enable_RadioButton(LA_06_v);
        Enable_RadioButton(LA_06_b);
        Enable_RadioButton(LA_06_c);
        EnableControls(LA_06_a);


        Enable_RadioButton(LA_07_v);
        Enable_RadioButton(LA_07_b);
        Enable_RadioButton(LA_07_c);
        EnableControls(LA_07_a);


        Enable_RadioButton(LA_08_v);
        Enable_RadioButton(LA_08_b);
        Enable_RadioButton(LA_08_c);
        EnableControls(LA_08_a);


        Enable_RadioButton(LA_09_v);
        Enable_RadioButton(LA_09_b);
        Enable_RadioButton(LA_09_c);
        EnableControls(LA_09_a);


        Enable_RadioButton(LA_10_v);
        Enable_RadioButton(LA_10_b);
        Enable_RadioButton(LA_10_c);
        EnableControls(LA_10_a);


        Enable_RadioButton(LA_11_v);
        Enable_RadioButton(LA_11_b);
        Enable_RadioButton(LA_11_c);
        EnableControls(LA_11_a);


        Enable_RadioButton(LA_12_v);
        Enable_RadioButton(LA_12_b);
        Enable_RadioButton(LA_12_c);
        EnableControls(LA_12_a);


        Enable_RadioButton(LA_13_v);
        Enable_RadioButton(LA_13_b);
        Enable_RadioButton(LA_13_c);
        EnableControls(LA_13_a);


        Enable_RadioButton(LA_14_v);
        Enable_RadioButton(LA_14_b);
        Enable_RadioButton(LA_14_c);
        EnableControls(LA_14_a);


        Enable_RadioButton(LA_15_v);
        Enable_RadioButton(LA_15_b);
        Enable_RadioButton(LA_15_c);
        EnableControls(LA_15_a);


        Enable_RadioButton(LA_16_v);
        Enable_RadioButton(LA_16_b);
        Enable_RadioButton(LA_16_c);
        EnableControls(LA_16_a);



        Enable_RadioButton(LF_01_v);
        Enable_RadioButton(LF_01_b);
        Enable_RadioButton(LF_01_c);
        EnableControls(LF_01_a);



        Enable_RadioButton(LF_02_v);
        Enable_RadioButton(LF_02_b);
        Enable_RadioButton(LF_02_c);
        EnableControls(LF_02_a);


        Enable_RadioButton(LF_03_v);
        Enable_RadioButton(LF_03_b);
        Enable_RadioButton(LF_03_c);
        EnableControls(LF_03_a);



        Enable_RadioButton(LF_04_v);
        Enable_RadioButton(LF_04_b);
        Enable_RadioButton(LF_04_c);
        EnableControls(LF_04_a);



        Enable_RadioButton(LF_05_v);
        Enable_RadioButton(LF_05_b);
        Enable_RadioButton(LF_05_c);
        EnableControls(LF_05_a);



        Enable_RadioButton(LF_06_v);
        Enable_RadioButton(LF_06_b);
        Enable_RadioButton(LF_06_c);
        EnableControls(LF_06_a);



        Enable_RadioButton(LF_07_v);
        Enable_RadioButton(LF_07_b);
        Enable_RadioButton(LF_07_c);
        EnableControls(LF_07_a);



        Enable_RadioButton(RF_01_v);
        Enable_RadioButton(RF_01_b);
        Enable_RadioButton(RF_01_c);
        EnableControls(RF_01_a);


        Enable_RadioButton(RF_03_v);
        Enable_RadioButton(RF_03_b);
        Enable_RadioButton(RF_03_c);
        EnableControls(RF_03_a);


        Enable_RadioButton(RF_04_v);
        Enable_RadioButton(RF_04_b);
        Enable_RadioButton(RF_04_c);
        EnableControls(RF_04_a);


        Enable_RadioButton(SE_01_v);
        Enable_RadioButton(SE_01_b);
        Enable_RadioButton(SE_01_c);
        EnableControls(SE_01_a);


        Enable_RadioButton(SE_02_v);
        Enable_RadioButton(SE_02_b);
        Enable_RadioButton(SE_02_c);
        EnableControls(SE_02_a);


        Enable_RadioButton(SE_03_v);
        Enable_RadioButton(SE_03_b);
        Enable_RadioButton(SE_03_c);
        EnableControls(SE_03_a);


        Enable_RadioButton(SE_04_v);
        Enable_RadioButton(SE_04_b);
        Enable_RadioButton(SE_04_c);
        EnableControls(SE_04_a);



        Enable_RadioButton(CS_01_v);
        Enable_RadioButton(CS_01_b);
        Enable_RadioButton(CS_01_c);
        EnableControls(CS_01_a);


        Enable_RadioButton(CS_02_v);
        Enable_RadioButton(CS_02_b);
        Enable_RadioButton(CS_02_c);
        EnableControls(CS_02_a);




        Enable_RadioButton(CS_03_v);
        Enable_RadioButton(CS_03_b);
        Enable_RadioButton(CS_03_c);
        EnableControls(CS_03_a);



        Enable_RadioButton(CS_04_v);
        Enable_RadioButton(CS_04_b);
        Enable_RadioButton(CS_04_c);
        EnableControls(CS_04_a);



        Enable_RadioButton(CS_05_v);
        Enable_RadioButton(CS_05_b);
        Enable_RadioButton(CS_05_c);
        EnableControls(CS_05_a);



        Enable_RadioButton(CS_06_v);
        Enable_RadioButton(CS_06_b);
        Enable_RadioButton(CS_06_c);
        EnableControls(CS_06_a);



        Enable_RadioButton(CS_07_v);
        Enable_RadioButton(CS_07_b);
        Enable_RadioButton(CS_07_c);
        EnableControls(CS_07_a);



        Enable_RadioButton(CS_08_v);
        Enable_RadioButton(CS_08_b);
        Enable_RadioButton(CS_08_c);
        EnableControls(CS_08_a);



        Enable_RadioButton(CS_09_v);
        Enable_RadioButton(CS_09_b);
        Enable_RadioButton(CS_09_c);
        EnableControls(CS_09_a);



        Enable_RadioButton(CS_10_v);
        Enable_RadioButton(CS_10_b);
        Enable_RadioButton(CS_10_c);
        EnableControls(CS_10_a);



        Enable_RadioButton(UR_01_v);
        Enable_RadioButton(UR_01_b);
        Enable_RadioButton(UR_01_c);
        EnableControls(UR_01_a);


        Enable_RadioButton(UR_02_v);
        Enable_RadioButton(UR_02_b);
        Enable_RadioButton(UR_02_c);
        EnableControls(UR_02_a);


        Enable_RadioButton(UR_03_v);
        Enable_RadioButton(UR_03_b);
        Enable_RadioButton(UR_03_c);
        EnableControls(UR_03_a);


        Enable_RadioButton(UR_04_v);
        Enable_RadioButton(UR_04_b);
        Enable_RadioButton(UR_04_c);
        EnableControls(UR_04_a);


        Enable_RadioButton(UR_05_v);
        Enable_RadioButton(UR_05_b);
        Enable_RadioButton(UR_05_c);
        EnableControls(UR_05_a);


        Enable_RadioButton(UR_06_v);
        Enable_RadioButton(UR_06_b);
        Enable_RadioButton(UR_06_c);
        EnableControls(UR_06_a);


        Enable_RadioButton(UR_07_v);
        Enable_RadioButton(UR_07_b);
        Enable_RadioButton(UR_07_c);
        EnableControls(UR_07_a);


        Enable_RadioButton(UR_08_v);
        Enable_RadioButton(UR_08_b);
        Enable_RadioButton(UR_08_c);
        EnableControls(UR_08_a);


        Enable_RadioButton(UR_10_v);
        Enable_RadioButton(UR_10_b);
        Enable_RadioButton(UR_10_c);
        EnableControls(UR_10_a);


        Enable_RadioButton(UR_11_v);
        Enable_RadioButton(UR_11_b);
        Enable_RadioButton(UR_11_c);
        EnableControls(UR_11_a);



        Enable_RadioButton(UR_12_v);
        Enable_RadioButton(UR_12_b);
        Enable_RadioButton(UR_12_c);
        EnableControls(UR_12_a);



        Enable_RadioButton(UR_13_v);
        Enable_RadioButton(UR_13_b);
        Enable_RadioButton(UR_13_c);
        EnableControls(UR_13_a);



        Enable_RadioButton(UR_14_v);
        Enable_RadioButton(UR_14_b);
        Enable_RadioButton(UR_14_c);
        EnableControls(UR_14_a);



        Enable_RadioButton(UR_15_v);
        Enable_RadioButton(UR_15_b);
        Enable_RadioButton(UR_15_c);
        EnableControls(UR_15_a);



        Enable_RadioButton(UR_16_v);
        Enable_RadioButton(UR_16_b);
        Enable_RadioButton(UR_16_c);
        EnableControls(UR_16_a);



        Enable_RadioButton(UR_17_v);
        Enable_RadioButton(UR_17_b);
        Enable_RadioButton(UR_17_c);
        EnableControls(UR_17_a);



        Enable_RadioButton(UR_18_v);
        Enable_RadioButton(UR_18_b);
        Enable_RadioButton(UR_18_c);
        EnableControls(UR_18_a);


        Enable_RadioButton(UR_19_v);
        Enable_RadioButton(UR_19_b);
        Enable_RadioButton(UR_19_c);
        EnableControls(UR_19_a);



        Enable_RadioButton(UR_20_v);
        Enable_RadioButton(UR_20_b);
        Enable_RadioButton(UR_20_c);
        EnableControls(UR_20_a);


        Enable_RadioButton(UR_21_v);
        Enable_RadioButton(UR_21_b);
        Enable_RadioButton(UR_21_c);
        EnableControls(UR_21_a);



        Enable_RadioButton(uc_01_a);
        Enable_RadioButton(uc_01_b);
        Enable_RadioButton(uc_01_c);
        EnableControls(uc_01_ca);


        Enable_RadioButton(uc_02a_v);
        Enable_RadioButton(uc_02a_b);
        Enable_RadioButton(uc_02a_c);
        EnableControls(uc_02a_a);
        Enable_RadioButton(uc_02b_a);
        Enable_RadioButton(uc_02b_b);
        Enable_RadioButton(uc_02b_c);



        Enable_RadioButton(uc_03a_v);
        Enable_RadioButton(uc_03a_b);
        Enable_RadioButton(uc_03a_c);
        EnableControls(uc_03a_a);
        Enable_RadioButton(uc_03b_a);
        Enable_RadioButton(uc_03b_b);
        Enable_RadioButton(uc_03b_c);



        Enable_RadioButton(uc_04a_v);
        Enable_RadioButton(uc_04a_b);
        Enable_RadioButton(uc_04a_c);
        EnableControls(uc_04a_a);
        Enable_RadioButton(uc_04b_a);
        Enable_RadioButton(uc_04b_b);
        Enable_RadioButton(uc_04b_c);



        Enable_RadioButton(uc_05a_v);
        Enable_RadioButton(uc_05a_b);
        Enable_RadioButton(uc_05a_c);
        EnableControls(uc_05a_a);
        Enable_RadioButton(uc_05b_a);
        Enable_RadioButton(uc_05b_b);
        Enable_RadioButton(uc_05b_c);



        Enable_RadioButton(uc_06a_v);
        Enable_RadioButton(uc_06a_b);
        Enable_RadioButton(uc_06a_c);
        EnableControls(uc_06a_a);
        Enable_RadioButton(uc_06b_a);
        Enable_RadioButton(uc_06b_b);
        Enable_RadioButton(uc_06b_c);



        Enable_RadioButton(uc_07a_v);
        Enable_RadioButton(uc_07a_b);
        Enable_RadioButton(uc_07a_c);
        EnableControls(uc_07a_a);
        Enable_RadioButton(uc_07b_a);
        Enable_RadioButton(uc_07b_b);
        Enable_RadioButton(uc_07b_c);



        Enable_RadioButton(uc_08a_v);
        Enable_RadioButton(uc_08a_b);
        Enable_RadioButton(uc_08a_c);
        EnableControls(uc_08a_a);
        Enable_RadioButton(uc_08b_a);
        Enable_RadioButton(uc_08b_b);
        Enable_RadioButton(uc_08b_c);



        Enable_RadioButton(uc_09a_v);
        Enable_RadioButton(uc_09a_b);
        Enable_RadioButton(uc_09a_c);
        EnableControls(uc_09a_a);
        Enable_RadioButton(uc_09b_a);
        Enable_RadioButton(uc_09b_b);
        Enable_RadioButton(uc_09b_c);



        Enable_RadioButton(uc_10a_v);
        Enable_RadioButton(uc_10a_b);
        Enable_RadioButton(uc_10a_c);
        EnableControls(uc_10a_a);
        Enable_RadioButton(uc_10b_a);
        Enable_RadioButton(uc_10b_b);
        Enable_RadioButton(uc_10b_c);



        Enable_RadioButton(uc_11a_v);
        Enable_RadioButton(uc_11a_b);
        Enable_RadioButton(uc_11a_c);
        EnableControls(uc_11a_a);
        Enable_RadioButton(uc_11b_a);
        Enable_RadioButton(uc_11b_b);
        Enable_RadioButton(uc_11b_c);



        Enable_RadioButton(uc_12a_v);
        Enable_RadioButton(uc_12a_b);
        Enable_RadioButton(uc_12a_c);
        EnableControls(uc_12a_a);
        Enable_RadioButton(uc_12b_a);
        Enable_RadioButton(uc_12b_b);
        Enable_RadioButton(uc_12b_c);



        Enable_RadioButton(uc_13a_v);
        Enable_RadioButton(uc_13a_b);
        Enable_RadioButton(uc_13a_c);
        EnableControls(uc_13a_a);
        Enable_RadioButton(uc_13b_a);
        Enable_RadioButton(uc_13b_b);
        Enable_RadioButton(uc_13b_c);



        Enable_RadioButton(uc_14a_v);
        Enable_RadioButton(uc_14a_b);
        Enable_RadioButton(uc_14a_c);
        EnableControls(uc_14a_a);
        Enable_RadioButton(uc_14b_a);
        Enable_RadioButton(uc_14b_b);
        Enable_RadioButton(uc_14b_c);



        Enable_RadioButton(uc_15a_v);
        Enable_RadioButton(uc_15a_b);
        Enable_RadioButton(uc_15a_c);
        EnableControls(uc_15a_a);
        Enable_RadioButton(uc_15b_a);
        Enable_RadioButton(uc_15b_b);
        Enable_RadioButton(uc_15b_c);



        Enable_RadioButton(uc_16a_v);
        Enable_RadioButton(uc_16a_b);
        Enable_RadioButton(uc_16a_c);
        EnableControls(uc_16a_a);
        Enable_RadioButton(uc_16b_a);
        Enable_RadioButton(uc_16b_b);
        Enable_RadioButton(uc_16b_c);


        Enable_RadioButton(uc_17a_v);
        Enable_RadioButton(uc_17a_b);
        Enable_RadioButton(uc_17a_c);
        EnableControls(uc_17a_a);
        Enable_RadioButton(uc_17b_a);
        Enable_RadioButton(uc_17b_b);
        Enable_RadioButton(uc_17b_c);



        Enable_RadioButton(uc_18a_v);
        Enable_RadioButton(uc_18a_b);
        Enable_RadioButton(uc_18a_c);
        EnableControls(uc_18a_a);
        Enable_RadioButton(uc_18b_a);
        Enable_RadioButton(uc_18b_b);
        Enable_RadioButton(uc_18b_c);



        Enable_RadioButton(uc_19a_v);
        Enable_RadioButton(uc_19a_b);
        Enable_RadioButton(uc_19a_c);
        EnableControls(uc_19a_a);
        Enable_RadioButton(uc_19b_a);
        Enable_RadioButton(uc_19b_b);
        Enable_RadioButton(uc_19b_c);



        Enable_RadioButton(uc_20a_v);
        Enable_RadioButton(uc_20a_b);
        Enable_RadioButton(uc_20a_c);
        EnableControls(uc_20a_a);
        Enable_RadioButton(uc_20b_a);
        Enable_RadioButton(uc_20b_b);
        Enable_RadioButton(uc_20b_c);



        Enable_RadioButton(uc_21a_v);
        Enable_RadioButton(uc_21a_b);
        Enable_RadioButton(uc_21a_c);
        EnableControls(uc_21a_a);
        Enable_RadioButton(uc_21b_a);
        Enable_RadioButton(uc_21b_b);
        Enable_RadioButton(uc_21b_c);



        Enable_RadioButton(uc_22a_v);
        Enable_RadioButton(uc_22a_b);
        Enable_RadioButton(uc_22a_c);
        EnableControls(uc_22a_a);
        Enable_RadioButton(uc_22b_a);
        Enable_RadioButton(uc_22b_b);
        Enable_RadioButton(uc_22b_c);



        Enable_RadioButton(uc_23a_v);
        Enable_RadioButton(uc_23a_b);
        Enable_RadioButton(uc_23a_c);
        EnableControls(uc_23a_a);
        Enable_RadioButton(uc_23b_a);
        Enable_RadioButton(uc_23b_b);
        Enable_RadioButton(uc_23b_c);



        Enable_RadioButton(uc_24a_v);
        Enable_RadioButton(uc_24a_b);
        Enable_RadioButton(uc_24a_c);
        EnableControls(uc_24a_a);
        Enable_RadioButton(uc_24b_a);
        Enable_RadioButton(uc_24b_b);
        Enable_RadioButton(uc_24b_c);



        Enable_RadioButton(uc_25a_v);
        Enable_RadioButton(uc_25a_b);
        Enable_RadioButton(uc_25a_c);
        EnableControls(uc_25a_a);
        Enable_RadioButton(uc_25b_a);
        Enable_RadioButton(uc_25b_b);
        Enable_RadioButton(uc_25b_c);



        Enable_RadioButton(uc_26a_v);
        Enable_RadioButton(uc_26a_b);
        Enable_RadioButton(uc_26a_c);
        EnableControls(uc_26a_a);
        Enable_RadioButton(uc_26b_a);
        Enable_RadioButton(uc_26b_b);
        Enable_RadioButton(uc_26b_c);



        Enable_RadioButton(uc_27a_v);
        Enable_RadioButton(uc_27a_b);
        Enable_RadioButton(uc_27a_c);
        EnableControls(uc_27a_a);
        Enable_RadioButton(uc_27b_a);
        Enable_RadioButton(uc_27b_b);
        Enable_RadioButton(uc_27b_c);


        Enable_RadioButton(uc_28a_v);
        Enable_RadioButton(uc_28a_b);
        Enable_RadioButton(uc_28a_c);
        EnableControls(uc_28a_a);
        Enable_RadioButton(uc_28b_a);
        Enable_RadioButton(uc_28b_b);
        Enable_RadioButton(uc_28b_c);



        Enable_RadioButton(uc_29a_v);
        Enable_RadioButton(uc_29a_b);
        Enable_RadioButton(uc_29a_c);
        EnableControls(uc_29a_a);
        Enable_RadioButton(uc_29b_a);
        Enable_RadioButton(uc_29b_b);
        Enable_RadioButton(uc_29b_c);



        Enable_RadioButton(uc_30a_v);
        Enable_RadioButton(uc_30a_b);
        Enable_RadioButton(uc_30a_c);
        EnableControls(uc_30a_a);
        Enable_RadioButton(uc_30b_a);
        Enable_RadioButton(uc_30b_b);
        Enable_RadioButton(uc_30b_c);



        Enable_RadioButton(uc_31a_v);
        Enable_RadioButton(uc_31a_b);
        Enable_RadioButton(uc_31a_c);
        EnableControls(uc_31a_a);
        Enable_RadioButton(uc_31b_a);
        Enable_RadioButton(uc_31b_b);
        Enable_RadioButton(uc_31b_c);



        Enable_RadioButton(uc_32a_v);
        Enable_RadioButton(uc_32a_b);
        Enable_RadioButton(uc_32a_c);
        EnableControls(uc_32a_a);
        Enable_RadioButton(uc_32b_a);
        Enable_RadioButton(uc_32b_b);
        Enable_RadioButton(uc_32b_c);



        Enable_RadioButton(uc_33a_v);
        Enable_RadioButton(uc_33a_b);
        Enable_RadioButton(uc_33a_c);
        EnableControls(uc_33a_a);
        Enable_RadioButton(uc_33b_a);
        Enable_RadioButton(uc_33b_b);
        Enable_RadioButton(uc_33b_c);



        Enable_RadioButton(uc_34a_v);
        Enable_RadioButton(uc_34a_b);
        Enable_RadioButton(uc_34a_c);
        EnableControls(uc_34a_a);
        Enable_RadioButton(uc_34b_a);
        Enable_RadioButton(uc_34b_b);
        Enable_RadioButton(uc_34b_c);



        Enable_RadioButton(uc_35a_v);
        Enable_RadioButton(uc_35a_b);
        Enable_RadioButton(uc_35a_c);
        EnableControls(uc_35a_a);
        Enable_RadioButton(uc_35b_a);
        Enable_RadioButton(uc_35b_b);
        Enable_RadioButton(uc_35b_c);



        Enable_RadioButton(uc_36a_v);
        Enable_RadioButton(uc_36a_b);
        Enable_RadioButton(uc_36a_c);
        EnableControls(uc_36a_a);
        Enable_RadioButton(uc_36b_a);
        Enable_RadioButton(uc_36b_b);
        Enable_RadioButton(uc_36b_c);



        Enable_RadioButton(uc_37a_v);
        Enable_RadioButton(uc_37a_b);
        Enable_RadioButton(uc_37a_c);
        EnableControls(uc_37a_a);
        Enable_RadioButton(uc_37b_a);
        Enable_RadioButton(uc_37b_b);
        Enable_RadioButton(uc_37b_c);


        EnableControls(LA_17);
        EnableControls(LA_18);
        //EnableControls(LA_19);


        Enable_RadioButton(LA_20a_v);
        Enable_RadioButton(LA_20a_b);
        Enable_RadioButton(LA_20a_c);
        EnableControls(LA_20a_a);
        Enable_RadioButton(LA_20b_a);
        Enable_RadioButton(LA_20b_b);
        Enable_RadioButton(LA_20b_c);


        Enable_RadioButton(LA_21a_v);
        Enable_RadioButton(LA_21a_b);
        Enable_RadioButton(LA_21a_c);
        EnableControls(LA_21a_a);
        Enable_RadioButton(LA_21b_a);
        Enable_RadioButton(LA_21b_b);
        Enable_RadioButton(LA_21b_c);


        Enable_RadioButton(LA_22a_v);
        Enable_RadioButton(LA_22a_b);
        Enable_RadioButton(LA_22a_c);
        EnableControls(LA_22a_a);
        Enable_RadioButton(LA_22b_a);
        Enable_RadioButton(LA_22b_b);
        Enable_RadioButton(LA_22b_c);


        Enable_RadioButton(LA_23a_v);
        Enable_RadioButton(LA_23a_b);
        Enable_RadioButton(LA_23a_c);
        EnableControls(LA_23a_a);
        Enable_RadioButton(LA_23b_a);
        Enable_RadioButton(LA_23b_b);
        Enable_RadioButton(LA_23b_c);


        Enable_RadioButton(LA_24a_v);
        Enable_RadioButton(LA_24a_b);
        Enable_RadioButton(LA_24a_c);
        EnableControls(LA_24a_a);
        Enable_RadioButton(LA_24b_a);
        Enable_RadioButton(LA_24b_b);
        Enable_RadioButton(LA_24b_c);


        Enable_RadioButton(LA_25a_v);
        Enable_RadioButton(LA_25a_b);
        Enable_RadioButton(LA_25a_c);
        EnableControls(LA_25a_a);
        Enable_RadioButton(LA_25b_a);
        Enable_RadioButton(LA_25b_b);
        Enable_RadioButton(LA_25b_c);


        Enable_RadioButton(LA_26a_v);
        Enable_RadioButton(LA_26a_b);
        Enable_RadioButton(LA_26a_c);
        EnableControls(LA_26a_a);
        Enable_RadioButton(LA_26b_a);
        Enable_RadioButton(LA_26b_b);
        Enable_RadioButton(LA_26b_c);


        Enable_RadioButton(LA_27a_v);
        Enable_RadioButton(LA_27a_b);
        Enable_RadioButton(LA_27a_c);
        EnableControls(LA_27a_a);
        Enable_RadioButton(LA_27b_a);
        Enable_RadioButton(LA_27b_b);
        Enable_RadioButton(LA_27b_c);


        Enable_RadioButton(LA_28a_v);
        Enable_RadioButton(LA_28a_b);
        Enable_RadioButton(LA_28a_c);
        EnableControls(LA_28a_a);
        Enable_RadioButton(LA_28b_a);
        Enable_RadioButton(LA_28b_b);
        Enable_RadioButton(LA_28b_c);



        Enable_RadioButton(LA_29a_v);
        Enable_RadioButton(LA_29a_b);
        Enable_RadioButton(LA_29a_c);
        EnableControls(LA_29a_a);
        Enable_RadioButton(LA_29b_a);
        Enable_RadioButton(LA_29b_b);
        Enable_RadioButton(LA_29b_c);



        Enable_RadioButton(LA_30a_v);
        Enable_RadioButton(LA_30a_b);
        Enable_RadioButton(LA_30a_c);
        EnableControls(LA_30a_a);
        Enable_RadioButton(LA_30b_a);
        Enable_RadioButton(LA_30b_b);
        Enable_RadioButton(LA_30b_c);


        Enable_RadioButton(LA_31a_v);
        Enable_RadioButton(LA_31a_b);
        Enable_RadioButton(LA_31a_c);
        EnableControls(LA_31a_a);
        Enable_RadioButton(LA_31b_a);
        Enable_RadioButton(LA_31b_b);
        Enable_RadioButton(LA_31b_c);


        Enable_RadioButton(LA_32a_v);
        Enable_RadioButton(LA_32a_b);
        Enable_RadioButton(LA_32a_c);
        EnableControls(LA_32a_a);
        Enable_RadioButton(LA_32b_a);
        Enable_RadioButton(LA_32b_b);
        Enable_RadioButton(LA_32b_c);


        Enable_RadioButton(LA_33a_v);
        Enable_RadioButton(LA_33a_b);
        Enable_RadioButton(LA_33a_c);
        EnableControls(LA_33a_a);
        Enable_RadioButton(LA_33b_a);
        Enable_RadioButton(LA_33b_b);
        Enable_RadioButton(LA_33b_c);


        Enable_RadioButton(LA_34a_v);
        Enable_RadioButton(LA_34a_b);
        Enable_RadioButton(LA_34a_c);
        EnableControls(LA_34a_a);
        Enable_RadioButton(LA_34b_a);
        Enable_RadioButton(LA_34b_b);
        Enable_RadioButton(LA_34b_c);


        Enable_RadioButton(LA_35a_v);
        Enable_RadioButton(LA_35a_b);
        Enable_RadioButton(LA_35a_c);
        EnableControls(LA_35a_a);
        Enable_RadioButton(LA_35b_a);
        Enable_RadioButton(LA_35b_b);
        Enable_RadioButton(LA_35b_c);


        Enable_RadioButton(LA_36a_v);
        Enable_RadioButton(LA_36a_b);
        Enable_RadioButton(LA_36a_c);
        EnableControls(LA_36a_a);
        Enable_RadioButton(LA_36b_a);
        Enable_RadioButton(LA_36b_b);
        Enable_RadioButton(LA_36b_c);


        Enable_RadioButton(LA_37a_v);
        Enable_RadioButton(LA_37a_b);
        Enable_RadioButton(LA_37a_c);
        EnableControls(LA_37a_a);
        Enable_RadioButton(LA_37b_a);
        Enable_RadioButton(LA_37b_b);
        Enable_RadioButton(LA_37b_c);


        Enable_RadioButton(LA_38a_v);
        Enable_RadioButton(LA_38a_b);
        Enable_RadioButton(LA_38a_c);
        EnableControls(LA_38a_a);
        Enable_RadioButton(LA_38b_a);
        Enable_RadioButton(LA_38b_b);
        Enable_RadioButton(LA_38b_c);


        Enable_RadioButton(LA_39a_v);
        Enable_RadioButton(LA_39a_b);
        Enable_RadioButton(LA_39a_c);
        EnableControls(LA_39a_a);
        Enable_RadioButton(LA_39b_a);
        Enable_RadioButton(LA_39b_b);
        Enable_RadioButton(LA_39b_c);



        Enable_RadioButton(LA_40a_v);
        Enable_RadioButton(LA_40a_b);
        Enable_RadioButton(LA_40a_c);
        EnableControls(LA_40a_a);
        Enable_RadioButton(LA_40b_a);
        Enable_RadioButton(LA_40b_b);
        Enable_RadioButton(LA_40b_c);


        Enable_RadioButton(LA_41a_v);
        Enable_RadioButton(LA_41a_b);
        Enable_RadioButton(LA_41a_c);
        EnableControls(LA_41a_a);
        Enable_RadioButton(LA_41b_a);
        Enable_RadioButton(LA_41b_b);
        Enable_RadioButton(LA_41b_c);


        Enable_RadioButton(LA_42a_v);
        Enable_RadioButton(LA_42a_b);
        Enable_RadioButton(LA_42a_c);
        EnableControls(LA_42a_a);
        Enable_RadioButton(LA_42b_a);
        Enable_RadioButton(LA_42b_b);
        Enable_RadioButton(LA_42b_c);


        Enable_RadioButton(LA_43a_v);
        Enable_RadioButton(LA_43a_b);
        Enable_RadioButton(LA_43a_c);
        EnableControls(LA_43a_a);
        Enable_RadioButton(LA_43b_a);
        Enable_RadioButton(LA_43b_b);
        Enable_RadioButton(LA_43b_c);


        Enable_RadioButton(LA_44a_v);
        Enable_RadioButton(LA_44a_b);
        Enable_RadioButton(LA_44a_c);
        EnableControls(LA_44a_a);
        Enable_RadioButton(LA_44b_a);
        Enable_RadioButton(LA_44b_b);
        Enable_RadioButton(LA_44b_c);


        Enable_RadioButton(LA_45a_v);
        Enable_RadioButton(LA_45a_b);
        Enable_RadioButton(LA_45a_c);
        EnableControls(LA_45a_a);
        Enable_RadioButton(LA_45b_a);
        Enable_RadioButton(LA_45b_b);
        Enable_RadioButton(LA_45b_c);


        Enable_RadioButton(LA_46a_v);
        Enable_RadioButton(LA_46a_b);
        Enable_RadioButton(LA_46a_c);
        EnableControls(LA_46a_a);
        Enable_RadioButton(LA_46b_a);
        Enable_RadioButton(LA_46b_b);
        Enable_RadioButton(LA_46b_c);


        Enable_RadioButton(LA_47a_v);
        Enable_RadioButton(LA_47a_b);
        Enable_RadioButton(LA_47a_c);
        EnableControls(LA_47a_a);
        Enable_RadioButton(LA_47b_a);
        Enable_RadioButton(LA_47b_b);
        Enable_RadioButton(LA_47b_c);


        Enable_RadioButton(LA_48a_v);
        Enable_RadioButton(LA_48a_b);
        Enable_RadioButton(LA_48a_c);
        EnableControls(LA_48a_a);
        Enable_RadioButton(LA_48b_a);
        Enable_RadioButton(LA_48b_b);
        Enable_RadioButton(LA_48b_c);


        Enable_RadioButton(LA_49a_v);
        Enable_RadioButton(LA_49a_b);
        Enable_RadioButton(LA_49a_c);
        EnableControls(LA_49a_a);
        Enable_RadioButton(LA_49b_a);
        Enable_RadioButton(LA_49b_b);
        Enable_RadioButton(LA_49b_c);


        Enable_RadioButton(LA_50a_v);
        Enable_RadioButton(LA_50a_b);
        Enable_RadioButton(LA_50a_c);
        EnableControls(LA_50a_a);
        Enable_RadioButton(LA_50b_a);
        Enable_RadioButton(LA_50b_b);
        Enable_RadioButton(LA_50b_c);


        Enable_RadioButton(LA_51a_v);
        Enable_RadioButton(LA_51a_b);
        Enable_RadioButton(LA_51a_c);
        EnableControls(LA_51a_a);
        Enable_RadioButton(LA_51b_a);
        Enable_RadioButton(LA_51b_b);
        Enable_RadioButton(LA_51b_c);


        Enable_RadioButton(LA_52a_v);
        Enable_RadioButton(LA_52a_b);
        Enable_RadioButton(LA_52a_c);
        EnableControls(LA_52a_a);
        Enable_RadioButton(LA_52b_a);
        Enable_RadioButton(LA_52b_b);
        Enable_RadioButton(LA_52b_c);

        pnl_LA_01.Visible = false;
        pnl_LA_02.Visible = false;
        pnl_idrl.Visible = true;
    }



    private void Disable_RadioButton_ViewOnly(RadioButton rdo)
    {
        rdo.Enabled = false;
    }


    private void DisableControls_ViewOnly(TextBox rdo)
    {
        rdo.Enabled = false;
    }



    private void Enable_RadioButton(RadioButton rdo)
    {
        //rdo.Visible = true;
        rdo.Enabled = true;
    }


    private void Disable_RadioButton(RadioButton rdo)
    {
        //rdo.Checked = false;
        //rdo.Visible = false;
        rdo.Enabled = false;
    }


    private void Disable_RadioButton_Sensitivity(RadioButton rdo)
    {
        rdo.Checked = false;
        //rdo.Visible = false;
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



    private void DisableControls1(TextBox rdo)
    {
        rdo.Enabled = false;
        rdo.CssClass = "form-control";
    }



    protected void Unnamed_Click(object sender, EventArgs e)
    {
        Session.Remove("UserID");
        Session.Abandon();
        Response.Redirect("login.aspx");
    }

    protected void cmdSave_Click(object sender, EventArgs e)
    {

        //if (IsValid(sender, e) == false)
        //{
        //    return;
        //}


        if (ViewState["isupdate"] == null)
        {
            SaveData("Done");
        }
        else
        {
            if (Request.Cookies["labid"].Value == "3")
            {
                UpdateData_historyonly("history");
            }
            else
            {
                UpdateData("Done");
            }

        }

    }


    private void UpdateData_historyonly(string formstatus)
    {
        CDBOperations obj_op = new CDBOperations();


        try
        {

            CConnection cn = new CConnection();


            string qry1 = "select * from sample_result where id='" + ViewState["id"] + "'";


            string msg1 = obj_op.ExecuteNonQuery_Message_Qry(qry1);

            if (string.IsNullOrEmpty(msg1))
            {

                qry1 = "UPDATE sample_result set history = '" + txthistory.Text + "' where id='" + ViewState["id"] + "'";
                msg1 = obj_op.ExecuteNonQuery_Message_Qry(qry1);


                if (string.IsNullOrEmpty(msg1))
                {
                    UpdateFormStatus(formstatus);

                    string message = "alert('Record saved successfully');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
                }
                else
                {
                    string message = "alert('" + msg1.Replace("'", "") + "');";
                    message = "alert('" + msg1.Replace("\"", "") + "');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
                }


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



    private void UpdateData(string formstatus)
    {
        CDBOperations obj_op = new CDBOperations();

        string var_LF_01 = "-1";
        string var_LF_02 = "-1";
        string var_LF_03 = "-1";
        string var_LF_04 = "-1";
        string var_LF_05 = "-1";
        string var_LF_06 = "-1";
        string var_LF_07 = "-1";


        string var_RF_01 = "-1";
        string var_RF_02 = "-1";
        string var_RF_03 = "-1";
        string var_RF_04 = "-1";


        string var_SE_01 = "-1";
        string var_SE_02 = "-1";
        string var_SE_03 = "-1";
        string var_SE_04 = "-1";


        string var_CS_01 = "-1";
        string var_CS_02 = "-1";
        string var_CS_03 = "-1";
        string var_CS_04 = "-1";
        string var_CS_05 = "-1";
        string var_CS_06 = "-1";
        string var_CS_07 = "-1";
        string var_CS_08 = "-1";
        string var_CS_09 = "-1";
        string var_CS_10 = "-1";


        string var_UR_01 = "-1";
        string var_UR_02 = "-1";
        string var_UR_03 = "-1";
        string var_UR_04 = "-1";
        string var_UR_04a = "-1";
        string var_UR_05 = "-1";
        string var_UR_06 = "-1";
        string var_UR_07 = "-1";
        string var_UR_08 = "-1";
        string var_UR_10 = "-1";
        string var_UR_11 = "-1";
        string var_UR_12 = "-1";
        string var_UR_13 = "-1";
        string var_UR_14 = "-1";
        string var_UR_15 = "-1";
        string var_UR_16 = "-1";
        string var_UR_17 = "-1";
        string var_UR_18 = "-1";
        string var_UR_19 = "-1";
        string var_UR_20 = "-1";
        string var_UR_21 = "-1";

        string var_uc_01a = "-1";


        string var_uc_02a = "-1";
        string var_uc_03a = "-1";
        string var_uc_04a = "-1";
        string var_uc_05a = "-1";
        string var_uc_06a = "-1";
        string var_uc_07a = "-1";
        string var_uc_08a = "-1";
        string var_uc_09a = "-1";
        string var_uc_10a = "-1";
        string var_uc_11a = "-1";
        string var_uc_12a = "-1";
        string var_uc_13a = "-1";
        string var_uc_14a = "-1";
        string var_uc_15a = "-1";
        string var_uc_16a = "-1";
        string var_uc_17a = "-1";
        string var_uc_18a = "-1";
        string var_uc_19a = "-1";
        string var_uc_20a = "-1";
        string var_uc_21a = "-1";
        string var_uc_22a = "-1";
        string var_uc_23a = "-1";
        string var_uc_24a = "-1";
        string var_uc_25a = "-1";
        string var_uc_26a = "-1";
        string var_uc_27a = "-1";
        string var_uc_28a = "-1";
        string var_uc_29a = "-1";
        string var_uc_30a = "-1";
        string var_uc_31a = "-1";
        string var_uc_32a = "-1";
        string var_uc_33a = "-1";
        string var_uc_34a = "-1";
        string var_uc_35a = "-1";
        string var_uc_36a = "-1";
        string var_uc_37a = "-1";



        string var_uc_02b = "-1";
        string var_uc_03b = "-1";
        string var_uc_04b = "-1";
        string var_uc_05b = "-1";
        string var_uc_06b = "-1";
        string var_uc_07b = "-1";
        string var_uc_08b = "-1";
        string var_uc_09b = "-1";
        string var_uc_10b = "-1";
        string var_uc_11b = "-1";
        string var_uc_12b = "-1";
        string var_uc_13b = "-1";
        string var_uc_14b = "-1";
        string var_uc_15b = "-1";
        string var_uc_16b = "-1";
        string var_uc_17b = "-1";
        string var_uc_18b = "-1";
        string var_uc_19b = "-1";
        string var_uc_20b = "-1";
        string var_uc_21b = "-1";
        string var_uc_22b = "-1";
        string var_uc_23b = "-1";
        string var_uc_24b = "-1";
        string var_uc_25b = "-1";
        string var_uc_26b = "-1";
        string var_uc_27b = "-1";
        string var_uc_28b = "-1";
        string var_uc_29b = "-1";
        string var_uc_30b = "-1";
        string var_uc_31b = "-1";
        string var_uc_32b = "-1";
        string var_uc_33b = "-1";
        string var_uc_34b = "-1";
        string var_uc_35b = "-1";
        string var_uc_36b = "-1";
        string var_uc_37b = "-1";



        string var_LA_03_b = "-1";
        string var_LA_04_b = "-1";
        string var_LA_05_b = "-1";
        string var_LA_06_b = "-1";
        string var_LA_07_b = "-1";
        string var_LA_08_b = "-1";
        string var_LA_09_b = "-1";
        string var_LA_10_b = "-1";
        string var_LA_11_b = "-1";
        string var_LA_12_b = "-1";
        string var_LA_13_b = "-1";
        string var_LA_14_b = "-1";
        string var_LA_15_b = "-1";
        string var_LA_16_b = "-1";


        string var_LA_20a_b = "-1";
        string var_LA_21a_b = "-1";
        string var_LA_22a_b = "-1";
        string var_LA_23a_b = "-1";
        string var_LA_24a_b = "-1";
        string var_LA_25a_b = "-1";
        string var_LA_26a_b = "-1";
        string var_LA_27a_b = "-1";
        string var_LA_28a_b = "-1";
        string var_LA_29a_b = "-1";
        string var_LA_30a_b = "-1";
        string var_LA_31a_b = "-1";
        string var_LA_32a_b = "-1";
        string var_LA_33a_b = "-1";
        string var_LA_34a_b = "-1";
        string var_LA_35a_b = "-1";
        string var_LA_36a_b = "-1";
        string var_LA_37a_b = "-1";
        string var_LA_38a_b = "-1";
        string var_LA_39a_b = "-1";
        string var_LA_40a_b = "-1";
        string var_LA_41a_b = "-1";
        string var_LA_42a_b = "-1";
        string var_LA_43a_b = "-1";
        string var_LA_44a_b = "-1";
        string var_LA_45a_b = "-1";
        string var_LA_46a_b = "-1";
        string var_LA_47a_b = "-1";
        string var_LA_48a_b = "-1";
        string var_LA_49a_b = "-1";
        string var_LA_50a_b = "-1";
        string var_LA_51a_b = "-1";
        string var_LA_52a_b = "-1";


        var var_LA_20b_a = "-1";
        var var_LA_21b_a = "-1";
        var var_LA_22b_a = "-1";
        var var_LA_23b_a = "-1";
        var var_LA_24b_a = "-1";
        var var_LA_25b_a = "-1";
        var var_LA_26b_a = "-1";
        var var_LA_27b_a = "-1";
        var var_LA_28b_a = "-1";
        var var_LA_29b_a = "-1";
        var var_LA_30b_a = "-1";
        var var_LA_31b_a = "-1";
        var var_LA_32b_a = "-1";
        var var_LA_33b_a = "-1";
        var var_LA_34b_a = "-1";
        var var_LA_35b_a = "-1";
        var var_LA_36b_a = "-1";
        var var_LA_37b_a = "-1";
        var var_LA_38b_a = "-1";
        var var_LA_39b_a = "-1";
        var var_LA_40b_a = "-1";
        var var_LA_41b_a = "-1";
        var var_LA_42b_a = "-1";
        var var_LA_43b_a = "-1";
        var var_LA_44b_a = "-1";
        var var_LA_45b_a = "-1";
        var var_LA_46b_a = "-1";
        var var_LA_47b_a = "-1";
        var var_LA_48b_a = "-1";
        var var_LA_49b_a = "-1";
        var var_LA_50b_a = "-1";
        var var_LA_51b_a = "-1";
        var var_LA_52b_a = "-1";

        var var_BloodCulture = "";
        var var_BloodCulture_Multiple = "";




        try
        {

            if (LA_03_v.Checked == true)
            {
                var_LA_03_b = "";
            }
            else if (LA_03_b.Checked == true)
            {
                var_LA_03_b = "999";
            }
            else if (LA_03_c.Checked == true)
            {
                var_LA_03_b = "888";
            }


            if (LA_04_v.Checked == true)
            {
                var_LA_04_b = "";
            }
            else if (LA_04_b.Checked == true)
            {
                var_LA_04_b = "999";
            }
            else if (LA_04_c.Checked == true)
            {
                var_LA_04_b = "888";
            }


            if (LA_05_v.Checked == true)
            {
                var_LA_05_b = "";
            }
            else if (LA_05_b.Checked == true)
            {
                var_LA_05_b = "999";
            }
            else if (LA_05_c.Checked == true)
            {
                var_LA_05_b = "888";
            }



            if (LA_06_v.Checked == true)
            {
                var_LA_06_b = "";
            }
            else if (LA_06_b.Checked == true)
            {
                var_LA_06_b = "999";
            }
            else if (LA_06_c.Checked == true)
            {
                var_LA_06_b = "888";
            }



            if (LA_07_v.Checked == true)
            {
                var_LA_07_b = "";
            }
            else if (LA_07_b.Checked == true)
            {
                var_LA_07_b = "999";
            }
            else if (LA_07_c.Checked == true)
            {
                var_LA_07_b = "888";
            }



            if (LA_08_v.Checked == true)
            {
                var_LA_08_b = "";
            }
            else if (LA_08_b.Checked == true)
            {
                var_LA_08_b = "999";
            }
            else if (LA_08_c.Checked == true)
            {
                var_LA_08_b = "888";
            }



            if (LA_09_v.Checked == true)
            {
                var_LA_09_b = "";
            }
            else if (LA_09_b.Checked == true)
            {
                var_LA_09_b = "999";
            }
            else if (LA_09_c.Checked == true)
            {
                var_LA_09_b = "999";
            }



            if (LA_10_v.Checked == true)
            {
                var_LA_10_b = "";
            }
            else if (LA_10_b.Checked == true)
            {
                var_LA_10_b = "999";
            }
            else if (LA_10_c.Checked == true)
            {
                var_LA_10_b = "888";
            }



            if (LA_11_v.Checked == true)
            {
                var_LA_11_b = "";
            }
            else if (LA_11_b.Checked == true)
            {
                var_LA_11_b = "999";
            }
            else if (LA_11_c.Checked == true)
            {
                var_LA_11_b = "888";
            }



            if (LA_12_v.Checked == true)
            {
                var_LA_12_b = "";
            }
            else if (LA_12_b.Checked == true)
            {
                var_LA_12_b = "999";
            }
            else if (LA_12_c.Checked == true)
            {
                var_LA_12_b = "888";
            }




            if (LA_13_v.Checked == true)
            {
                var_LA_13_b = "";
            }
            else if (LA_13_b.Checked == true)
            {
                var_LA_13_b = "999";
            }
            else if (LA_13_c.Checked == true)
            {
                var_LA_13_b = "888";
            }



            if (LA_14_v.Checked == true)
            {
                var_LA_14_b = "";
            }
            else if (LA_14_b.Checked == true)
            {
                var_LA_14_b = "999";
            }
            else if (LA_14_c.Checked == true)
            {
                var_LA_14_b = "888";
            }



            if (LA_15_v.Checked == true)
            {
                var_LA_15_b = "";
            }
            else if (LA_15_b.Checked == true)
            {
                var_LA_15_b = "999";
            }
            else if (LA_15_c.Checked == true)
            {
                var_LA_15_b = "888";
            }



            if (LA_16_v.Checked == true)
            {
                var_LA_16_b = "";
            }
            else if (LA_16_b.Checked == true)
            {
                var_LA_16_b = "999";
            }
            else if (LA_16_c.Checked == true)
            {
                var_LA_16_b = "888";
            }




            if (LF_01_v.Checked == true)
            {
                var_LF_01 = "";
            }
            else if (LF_01_b.Checked == true)
            {
                var_LF_01 = "999";
            }
            else if (LF_01_c.Checked == true)
            {
                var_LF_01 = "888";
            }



            if (LF_02_v.Checked == true)
            {
                var_LF_02 = "";
            }
            else if (LF_02_b.Checked == true)
            {
                var_LF_02 = "999";
            }
            else if (LF_02_c.Checked == true)
            {
                var_LF_02 = "888";
            }



            if (LF_03_v.Checked == true)
            {
                var_LF_03 = "";
            }
            else if (LF_03_b.Checked == true)
            {
                var_LF_03 = "999";
            }
            else if (LF_03_c.Checked == true)
            {
                var_LF_03 = "888";
            }



            if (LF_04_v.Checked == true)
            {
                var_LF_04 = "";
            }
            else if (LF_04_b.Checked == true)
            {
                var_LF_04 = "999";
            }
            else if (LF_04_c.Checked == true)
            {
                var_LF_04 = "888";
            }



            if (LF_05_v.Checked == true)
            {
                var_LF_05 = "";
            }
            else if (LF_05_b.Checked == true)
            {
                var_LF_05 = "999";
            }
            else if (LF_05_c.Checked == true)
            {
                var_LF_05 = "888";
            }




            if (LF_06_v.Checked == true)
            {
                var_LF_06 = "";
            }
            else if (LF_06_b.Checked == true)
            {
                var_LF_06 = "999";
            }
            else if (LF_06_c.Checked == true)
            {
                var_LF_06 = "888";
            }



            if (LF_07_v.Checked == true)
            {
                var_LF_07 = "";
            }
            else if (LF_07_b.Checked == true)
            {
                var_LF_07 = "999";
            }
            else if (LF_07_c.Checked == true)
            {
                var_LF_07 = "888";
            }



            if (RF_01_v.Checked == true)
            {
                var_RF_01 = "";
            }
            else if (RF_01_b.Checked == true)
            {
                var_RF_01 = "999";
            }
            else if (RF_01_c.Checked == true)
            {
                var_RF_01 = "888";
            }



            if (RF_02_v.Checked == true)
            {
                var_RF_02 = "";
            }
            else if (RF_02_b.Checked == true)
            {
                var_RF_02 = "999";
            }
            else if (RF_02_c.Checked == true)
            {
                var_RF_02 = "888";
            }



            if (RF_03_v.Checked == true)
            {
                var_RF_03 = "";
            }
            else if (RF_03_b.Checked == true)
            {
                var_RF_03 = "999";
            }
            else if (RF_03_c.Checked == true)
            {
                var_RF_03 = "888";
            }



            if (RF_04_v.Checked == true)
            {
                var_RF_04 = "";
            }
            else if (RF_04_b.Checked == true)
            {
                var_RF_04 = "999";
            }
            else if (RF_04_c.Checked == true)
            {
                var_RF_04 = "888";
            }



            if (SE_01_v.Checked == true)
            {
                var_SE_01 = "";
            }
            else if (SE_01_b.Checked == true)
            {
                var_SE_01 = "999";
            }
            else if (SE_01_c.Checked == true)
            {
                var_SE_01 = "888";
            }



            if (SE_02_v.Checked == true)
            {
                var_SE_02 = "";
            }
            else if (SE_02_b.Checked == true)
            {
                var_SE_02 = "999";
            }
            else if (SE_02_c.Checked == true)
            {
                var_SE_02 = "888";
            }




            if (SE_03_v.Checked == true)
            {
                var_SE_03 = "";
            }
            else if (SE_03_b.Checked == true)
            {
                var_SE_03 = "999";
            }
            else if (SE_03_c.Checked == true)
            {
                var_SE_03 = "888";
            }



            if (SE_04_v.Checked == true)
            {
                var_SE_04 = "";
            }
            else if (SE_04_b.Checked == true)
            {
                var_SE_04 = "999";
            }
            else if (SE_04_c.Checked == true)
            {
                var_SE_04 = "888";
            }



            if (CS_01_v.Checked == true)
            {
                var_CS_01 = "";
            }
            else if (CS_01_b.Checked == true)
            {
                var_CS_01 = "999";
            }
            else if (CS_01_c.Checked == true)
            {
                var_CS_01 = "888";
            }



            if (CS_02_v.Checked == true)
            {
                var_CS_02 = "";
            }
            else if (CS_02_b.Checked == true)
            {
                var_CS_02 = "999";
            }
            else if (CS_02_c.Checked == true)
            {
                var_CS_02 = "888";
            }




            if (CS_03_v.Checked == true)
            {
                var_CS_03 = "";
            }
            else if (CS_03_b.Checked == true)
            {
                var_CS_03 = "999";
            }
            else if (CS_03_c.Checked == true)
            {
                var_CS_03 = "888";
            }



            if (CS_04_v.Checked == true)
            {
                var_CS_04 = "";
            }
            else if (CS_04_b.Checked == true)
            {
                var_CS_04 = "999";
            }
            else if (CS_04_c.Checked == true)
            {
                var_CS_04 = "888";
            }



            if (CS_05_v.Checked == true)
            {
                var_CS_05 = "";
            }
            else if (CS_05_b.Checked == true)
            {
                var_CS_05 = "999";
            }
            else if (CS_05_c.Checked == true)
            {
                var_CS_05 = "888";
            }



            if (CS_06_v.Checked == true)
            {
                var_CS_06 = "";
            }
            else if (CS_06_b.Checked == true)
            {
                var_CS_06 = "999";
            }
            else if (CS_06_c.Checked == true)
            {
                var_CS_06 = "888";
            }



            if (CS_07_v.Checked == true)
            {
                var_CS_07 = "";
            }
            else if (CS_07_b.Checked == true)
            {
                var_CS_07 = "999";
            }
            else if (CS_07_c.Checked == true)
            {
                var_CS_07 = "888";
            }



            if (CS_08_v.Checked == true)
            {
                var_CS_08 = "";
            }
            else if (CS_08_b.Checked == true)
            {
                var_CS_08 = "999";
            }
            else if (CS_08_c.Checked == true)
            {
                var_CS_08 = "888";
            }



            if (CS_09_v.Checked == true)
            {
                var_CS_09 = "";
            }
            else if (CS_09_b.Checked == true)
            {
                var_CS_09 = "999";
            }
            else if (CS_09_c.Checked == true)
            {
                var_CS_09 = "888";
            }



            if (CS_10_v.Checked == true)
            {
                var_CS_10 = "";
            }
            else if (CS_10_b.Checked == true)
            {
                var_CS_10 = "999";
            }
            else if (CS_10_c.Checked == true)
            {
                var_CS_10 = "888";
            }



            if (UR_01_v.Checked == true)
            {
                var_UR_01 = "";
            }
            else if (UR_01_b.Checked == true)
            {
                var_UR_01 = "999";
            }
            else if (UR_01_c.Checked == true)
            {
                var_UR_01 = "888";
            }



            if (UR_02_v.Checked == true)
            {
                var_UR_02 = "";
            }
            else if (UR_02_b.Checked == true)
            {
                var_UR_02 = "999";
            }
            else if (UR_02_c.Checked == true)
            {
                var_UR_02 = "888";
            }



            if (UR_03_v.Checked == true)
            {
                var_UR_03 = "";
            }
            else if (UR_03_b.Checked == true)
            {
                var_UR_03 = "999";
            }
            else if (UR_03_c.Checked == true)
            {
                var_UR_03 = "888";
            }



            if (UR_04_v.Checked == true)
            {
                var_UR_04 = "";
            }
            else if (UR_04_b.Checked == true)
            {
                var_UR_04 = "999";
            }
            else if (UR_04_c.Checked == true)
            {
                var_UR_04 = "888";
            }



            if (UR_04a_v.Checked == true)
            {
                var_UR_04a = "";
            }
            else if (UR_04a_b.Checked == true)
            {
                var_UR_04a = "999";
            }
            else if (UR_04a_c.Checked == true)
            {
                var_UR_04a = "888";
            }




            if (UR_05_v.Checked == true)
            {
                var_UR_05 = "";
            }
            else if (UR_05_b.Checked == true)
            {
                var_UR_05 = "999";
            }
            else if (UR_05_c.Checked == true)
            {
                var_UR_05 = "888";
            }




            if (UR_06_v.Checked == true)
            {
                var_UR_06 = "";
            }
            else if (UR_06_b.Checked == true)
            {
                var_UR_06 = "999";
            }
            else if (UR_06_c.Checked == true)
            {
                var_UR_06 = "888";
            }



            if (UR_07_v.Checked == true)
            {
                var_UR_07 = "";
            }
            else if (UR_07_b.Checked == true)
            {
                var_UR_07 = "999";
            }
            else if (UR_07_c.Checked == true)
            {
                var_UR_07 = "888";
            }



            if (UR_08_v.Checked == true)
            {
                var_UR_08 = "";
            }
            else if (UR_08_b.Checked == true)
            {
                var_UR_08 = "999";
            }
            else if (UR_08_c.Checked == true)
            {
                var_UR_08 = "888";
            }



            if (UR_10_v.Checked == true)
            {
                var_UR_10 = "";
            }
            else if (UR_10_b.Checked == true)
            {
                var_UR_10 = "999";
            }
            else if (UR_10_c.Checked == true)
            {
                var_UR_10 = "888";
            }



            if (UR_11_v.Checked == true)
            {
                var_UR_11 = "";
            }
            else if (UR_11_b.Checked == true)
            {
                var_UR_11 = "999";
            }
            else if (UR_11_c.Checked == true)
            {
                var_UR_11 = "888";
            }



            if (UR_12_v.Checked == true)
            {
                var_UR_12 = "";
            }
            else if (UR_12_b.Checked == true)
            {
                var_UR_12 = "999";
            }
            else if (UR_12_c.Checked == true)
            {
                var_UR_12 = "888";
            }




            if (UR_13_v.Checked == true)
            {
                var_UR_13 = "";
            }
            else if (UR_13_b.Checked == true)
            {
                var_UR_13 = "999";
            }
            else if (UR_13_c.Checked == true)
            {
                var_UR_13 = "888";
            }




            if (UR_14_v.Checked == true)
            {
                var_UR_14 = "";
            }
            else if (UR_14_b.Checked == true)
            {
                var_UR_14 = "999";
            }
            else if (UR_14_c.Checked == true)
            {
                var_UR_14 = "888";
            }




            if (UR_15_v.Checked == true)
            {
                var_UR_15 = "";
            }
            else if (UR_15_b.Checked == true)
            {
                var_UR_15 = "999";
            }
            else if (UR_15_c.Checked == true)
            {
                var_UR_15 = "888";
            }



            if (UR_16_v.Checked == true)
            {
                var_UR_16 = "";
            }
            else if (UR_16_b.Checked == true)
            {
                var_UR_16 = "999";
            }
            else if (UR_16_c.Checked == true)
            {
                var_UR_16 = "888";
            }



            if (UR_17_v.Checked == true)
            {
                var_UR_17 = "";
            }
            else if (UR_17_b.Checked == true)
            {
                var_UR_17 = "999";
            }
            else if (UR_17_c.Checked == true)
            {
                var_UR_17 = "888";
            }



            if (UR_18_v.Checked == true)
            {
                var_UR_18 = "";
            }
            else if (UR_18_b.Checked == true)
            {
                var_UR_18 = "999";
            }
            else if (UR_18_c.Checked == true)
            {
                var_UR_18 = "888";
            }



            if (UR_19_v.Checked == true)
            {
                var_UR_19 = "";
            }
            else if (UR_19_b.Checked == true)
            {
                var_UR_19 = "999";
            }
            else if (UR_19_c.Checked == true)
            {
                var_UR_19 = "888";
            }




            if (UR_20_v.Checked == true)
            {
                var_UR_20 = "";
            }
            else if (UR_20_b.Checked == true)
            {
                var_UR_20 = "999";
            }
            else if (UR_20_c.Checked == true)
            {
                var_UR_20 = "888";
            }



            if (UR_21_v.Checked == true)
            {
                var_UR_21 = "";
            }
            else if (UR_21_b.Checked == true)
            {
                var_UR_21 = "999";
            }
            else if (UR_21_c.Checked == true)
            {
                var_UR_21 = "888";
            }



            if (uc_01_a.Checked == true)
            {
                var_uc_01a = "1";
            }
            else if (uc_01_b.Checked == true)
            {
                var_uc_01a = "2";
            }
            else if (uc_01_c.Checked == true)
            {
                var_uc_01a = "999";
            }



            if (uc_02a_v.Checked == true)
            {
                var_uc_02a = "";
            }
            else if (uc_02a_b.Checked == true)
            {
                var_uc_02a = "999";
            }
            else if (uc_02a_c.Checked == true)
            {
                var_uc_02a = "888";
            }



            if (uc_02b_a.Checked == true)
            {
                var_uc_02b = "1";
            }
            else if (uc_02b_b.Checked == true)
            {
                var_uc_02b = "2";
            }
            else if (uc_02b_c.Checked == true)
            {
                var_uc_02b = "3";
            }



            if (uc_03a_v.Checked == true)
            {
                var_uc_03a = "";
            }
            else if (uc_03a_b.Checked == true)
            {
                var_uc_03a = "999";
            }
            else if (uc_03a_c.Checked == true)
            {
                var_uc_03a = "888";
            }



            if (uc_03b_a.Checked == true)
            {
                var_uc_03b = "1";
            }
            else if (uc_03b_b.Checked == true)
            {
                var_uc_03b = "2";
            }
            else if (uc_03b_c.Checked == true)
            {
                var_uc_03b = "3";
            }




            if (uc_04a_v.Checked == true)
            {
                var_uc_04a = "";
            }
            else if (uc_04a_b.Checked == true)
            {
                var_uc_04a = "999";
            }
            else if (uc_04a_c.Checked == true)
            {
                var_uc_04a = "888";
            }



            if (uc_04b_a.Checked == true)
            {
                var_uc_04b = "1";
            }
            else if (uc_04b_b.Checked == true)
            {
                var_uc_04b = "2";
            }
            else if (uc_04b_c.Checked == true)
            {
                var_uc_04b = "3";
            }



            if (uc_05a_v.Checked == true)
            {
                var_uc_05a = "";
            }
            else if (uc_05a_b.Checked == true)
            {
                var_uc_05a = "999";
            }
            else if (uc_05a_c.Checked == true)
            {
                var_uc_05a = "888";
            }



            if (uc_05b_a.Checked == true)
            {
                var_uc_05b = "1";
            }
            else if (uc_05b_b.Checked == true)
            {
                var_uc_05b = "2";
            }
            else if (uc_05b_c.Checked == true)
            {
                var_uc_05b = "3";
            }




            if (uc_06a_v.Checked == true)
            {
                var_uc_06a = "";
            }
            else if (uc_06a_b.Checked == true)
            {
                var_uc_06a = "999";
            }
            else if (uc_06a_c.Checked == true)
            {
                var_uc_06a = "888";
            }



            if (uc_06b_a.Checked == true)
            {
                var_uc_06b = "1";
            }
            else if (uc_06b_b.Checked == true)
            {
                var_uc_06b = "2";
            }
            else if (uc_06b_c.Checked == true)
            {
                var_uc_06b = "3";
            }



            if (uc_07a_v.Checked == true)
            {
                var_uc_07a = "";
            }
            else if (uc_07a_b.Checked == true)
            {
                var_uc_07a = "999";
            }
            else if (uc_07a_c.Checked == true)
            {
                var_uc_07a = "888";
            }



            if (uc_07b_a.Checked == true)
            {
                var_uc_07b = "1";
            }
            else if (uc_07b_b.Checked == true)
            {
                var_uc_07b = "2";
            }
            else if (uc_07b_c.Checked == true)
            {
                var_uc_07b = "3";
            }



            if (uc_08a_v.Checked == true)
            {
                var_uc_08a = "";
            }
            else if (uc_08a_b.Checked == true)
            {
                var_uc_08a = "999";
            }
            else if (uc_08a_c.Checked == true)
            {
                var_uc_08a = "888";
            }



            if (uc_08b_a.Checked == true)
            {
                var_uc_08b = "1";
            }
            else if (uc_08b_b.Checked == true)
            {
                var_uc_08b = "2";
            }
            else if (uc_08b_c.Checked == true)
            {
                var_uc_08b = "3";
            }




            if (uc_09a_v.Checked == true)
            {
                var_uc_09a = "";
            }
            else if (uc_09a_b.Checked == true)
            {
                var_uc_09a = "999";
            }
            else if (uc_09a_c.Checked == true)
            {
                var_uc_09a = "888";
            }



            if (uc_09b_a.Checked == true)
            {
                var_uc_09b = "1";
            }
            else if (uc_09b_b.Checked == true)
            {
                var_uc_09b = "2";
            }
            else if (uc_09b_c.Checked == true)
            {
                var_uc_09b = "3";
            }




            if (uc_10a_v.Checked == true)
            {
                var_uc_10a = "";
            }
            else if (uc_10a_b.Checked == true)
            {
                var_uc_10a = "999";
            }
            else if (uc_10a_c.Checked == true)
            {
                var_uc_10a = "888";
            }



            if (uc_10b_a.Checked == true)
            {
                var_uc_10b = "1";
            }
            else if (uc_10b_b.Checked == true)
            {
                var_uc_10b = "2";
            }
            else if (uc_10b_c.Checked == true)
            {
                var_uc_10b = "3";
            }



            if (uc_11a_v.Checked == true)
            {
                var_uc_11a = "";
            }
            else if (uc_11a_b.Checked == true)
            {
                var_uc_11a = "999";
            }
            else if (uc_11a_c.Checked == true)
            {
                var_uc_11a = "888";
            }



            if (uc_11b_a.Checked == true)
            {
                var_uc_11b = "1";
            }
            else if (uc_11b_b.Checked == true)
            {
                var_uc_11b = "2";
            }
            else if (uc_11b_c.Checked == true)
            {
                var_uc_11b = "3";
            }




            if (uc_12a_v.Checked == true)
            {
                var_uc_12a = "";
            }
            else if (uc_12a_b.Checked == true)
            {
                var_uc_12a = "999";
            }
            else if (uc_12a_c.Checked == true)
            {
                var_uc_12a = "888";
            }



            if (uc_12b_a.Checked == true)
            {
                var_uc_12b = "1";
            }
            else if (uc_12b_b.Checked == true)
            {
                var_uc_12b = "2";
            }
            else if (uc_12b_c.Checked == true)
            {
                var_uc_12b = "3";
            }



            if (uc_13a_v.Checked == true)
            {
                var_uc_13a = "";
            }
            else if (uc_13a_b.Checked == true)
            {
                var_uc_13a = "999";
            }
            else if (uc_13a_c.Checked == true)
            {
                var_uc_13a = "888";
            }



            if (uc_13b_a.Checked == true)
            {
                var_uc_13b = "1";
            }
            else if (uc_13b_b.Checked == true)
            {
                var_uc_13b = "2";
            }
            else if (uc_13b_c.Checked == true)
            {
                var_uc_13b = "3";
            }




            if (uc_14a_v.Checked == true)
            {
                var_uc_14a = "";
            }
            else if (uc_14a_b.Checked == true)
            {
                var_uc_14a = "999";
            }
            else if (uc_14a_c.Checked == true)
            {
                var_uc_14a = "888";
            }



            if (uc_14b_a.Checked == true)
            {
                var_uc_14b = "1";
            }
            else if (uc_14b_b.Checked == true)
            {
                var_uc_14b = "2";
            }
            else if (uc_14b_c.Checked == true)
            {
                var_uc_14b = "3";
            }




            if (uc_15a_v.Checked == true)
            {
                var_uc_15a = "";
            }
            else if (uc_15a_b.Checked == true)
            {
                var_uc_15a = "999";
            }
            else if (uc_15a_c.Checked == true)
            {
                var_uc_15a = "888";
            }



            if (uc_15b_a.Checked == true)
            {
                var_uc_15b = "1";
            }
            else if (uc_15b_b.Checked == true)
            {
                var_uc_15b = "2";
            }
            else if (uc_15b_c.Checked == true)
            {
                var_uc_15b = "3";
            }




            if (uc_16a_v.Checked == true)
            {
                var_uc_16a = "";
            }
            else if (uc_16a_b.Checked == true)
            {
                var_uc_16a = "999";
            }
            else if (uc_16a_c.Checked == true)
            {
                var_uc_16a = "888";
            }



            if (uc_16b_a.Checked == true)
            {
                var_uc_16b = "1";
            }
            else if (uc_16b_b.Checked == true)
            {
                var_uc_16b = "2";
            }
            else if (uc_16b_c.Checked == true)
            {
                var_uc_16b = "3";
            }





            if (uc_17a_v.Checked == true)
            {
                var_uc_17a = "";
            }
            else if (uc_17a_b.Checked == true)
            {
                var_uc_17a = "999";
            }
            else if (uc_17a_c.Checked == true)
            {
                var_uc_17a = "888";
            }



            if (uc_17b_a.Checked == true)
            {
                var_uc_17b = "1";
            }
            else if (uc_17b_b.Checked == true)
            {
                var_uc_17b = "2";
            }
            else if (uc_17b_c.Checked == true)
            {
                var_uc_17b = "3";
            }




            if (uc_18a_v.Checked == true)
            {
                var_uc_18a = "";
            }
            else if (uc_18a_b.Checked == true)
            {
                var_uc_18a = "999";
            }
            else if (uc_18a_c.Checked == true)
            {
                var_uc_18a = "888";
            }



            if (uc_18b_a.Checked == true)
            {
                var_uc_18b = "1";
            }
            else if (uc_18b_b.Checked == true)
            {
                var_uc_18b = "2";
            }
            else if (uc_18b_c.Checked == true)
            {
                var_uc_18b = "3";
            }




            if (uc_19a_v.Checked == true)
            {
                var_uc_19a = "";
            }
            else if (uc_19a_b.Checked == true)
            {
                var_uc_19a = "999";
            }
            else if (uc_19a_c.Checked == true)
            {
                var_uc_19a = "888";
            }



            if (uc_19b_a.Checked == true)
            {
                var_uc_19b = "1";
            }
            else if (uc_19b_b.Checked == true)
            {
                var_uc_19b = "2";
            }
            else if (uc_19b_c.Checked == true)
            {
                var_uc_19b = "3";
            }




            if (uc_20a_v.Checked == true)
            {
                var_uc_20a = "";
            }
            else if (uc_20a_b.Checked == true)
            {
                var_uc_20a = "999";
            }
            else if (uc_20a_c.Checked == true)
            {
                var_uc_20a = "888";
            }



            if (uc_20b_a.Checked == true)
            {
                var_uc_20b = "1";
            }
            else if (uc_20b_b.Checked == true)
            {
                var_uc_20b = "2";
            }
            else if (uc_20b_c.Checked == true)
            {
                var_uc_20b = "3";
            }




            if (uc_21a_v.Checked == true)
            {
                var_uc_21a = "";
            }
            else if (uc_21a_b.Checked == true)
            {
                var_uc_21a = "999";
            }
            else if (uc_21a_c.Checked == true)
            {
                var_uc_21a = "888";
            }



            if (uc_21b_a.Checked == true)
            {
                var_uc_21b = "1";
            }
            else if (uc_21b_b.Checked == true)
            {
                var_uc_21b = "2";
            }
            else if (uc_21b_c.Checked == true)
            {
                var_uc_21b = "3";
            }




            if (uc_22a_v.Checked == true)
            {
                var_uc_22a = "";
            }
            else if (uc_22a_b.Checked == true)
            {
                var_uc_22a = "999";
            }
            else if (uc_22a_c.Checked == true)
            {
                var_uc_22a = "888";
            }



            if (uc_22b_a.Checked == true)
            {
                var_uc_22b = "1";
            }
            else if (uc_22b_b.Checked == true)
            {
                var_uc_22b = "2";
            }
            else if (uc_22b_c.Checked == true)
            {
                var_uc_22b = "3";
            }




            if (uc_23a_v.Checked == true)
            {
                var_uc_23a = "";
            }
            else if (uc_23a_b.Checked == true)
            {
                var_uc_23a = "999";
            }
            else if (uc_23a_c.Checked == true)
            {
                var_uc_23a = "888";
            }



            if (uc_23b_a.Checked == true)
            {
                var_uc_23b = "1";
            }
            else if (uc_23b_b.Checked == true)
            {
                var_uc_23b = "2";
            }
            else if (uc_23b_c.Checked == true)
            {
                var_uc_23b = "3";
            }




            if (uc_24a_v.Checked == true)
            {
                var_uc_24a = "";
            }
            else if (uc_24a_b.Checked == true)
            {
                var_uc_24a = "999";
            }
            else if (uc_24a_c.Checked == true)
            {
                var_uc_24a = "888";
            }



            if (uc_24b_a.Checked == true)
            {
                var_uc_24b = "1";
            }
            else if (uc_24b_b.Checked == true)
            {
                var_uc_24b = "2";
            }
            else if (uc_24b_c.Checked == true)
            {
                var_uc_24b = "3";
            }




            if (uc_25a_v.Checked == true)
            {
                var_uc_25a = "";
            }
            else if (uc_25a_b.Checked == true)
            {
                var_uc_25a = "999";
            }
            else if (uc_25a_c.Checked == true)
            {
                var_uc_25a = "888";
            }



            if (uc_25b_a.Checked == true)
            {
                var_uc_25b = "1";
            }
            else if (uc_25b_b.Checked == true)
            {
                var_uc_25b = "2";
            }
            else if (uc_25b_c.Checked == true)
            {
                var_uc_25b = "3";
            }




            if (uc_26a_v.Checked == true)
            {
                var_uc_26a = "";
            }
            else if (uc_26a_b.Checked == true)
            {
                var_uc_26a = "999";
            }
            else if (uc_26a_c.Checked == true)
            {
                var_uc_26a = "888";
            }



            if (uc_26b_a.Checked == true)
            {
                var_uc_26b = "1";
            }
            else if (uc_26b_b.Checked == true)
            {
                var_uc_26b = "2";
            }
            else if (uc_26b_c.Checked == true)
            {
                var_uc_26b = "3";
            }




            if (uc_27a_v.Checked == true)
            {
                var_uc_27a = "";
            }
            else if (uc_27a_b.Checked == true)
            {
                var_uc_27a = "999";
            }
            else if (uc_27a_c.Checked == true)
            {
                var_uc_27a = "888";
            }



            if (uc_27b_a.Checked == true)
            {
                var_uc_27b = "1";
            }
            else if (uc_27b_b.Checked == true)
            {
                var_uc_27b = "2";
            }
            else if (uc_27b_c.Checked == true)
            {
                var_uc_27b = "3";
            }




            if (uc_28a_v.Checked == true)
            {
                var_uc_28a = "";
            }
            else if (uc_28a_b.Checked == true)
            {
                var_uc_28a = "999";
            }
            else if (uc_28a_c.Checked == true)
            {
                var_uc_28a = "888";
            }



            if (uc_28b_a.Checked == true)
            {
                var_uc_28b = "1";
            }
            else if (uc_28b_b.Checked == true)
            {
                var_uc_28b = "2";
            }
            else if (uc_28b_c.Checked == true)
            {
                var_uc_28b = "3";
            }




            if (uc_29a_v.Checked == true)
            {
                var_uc_29a = "";
            }
            else if (uc_29a_b.Checked == true)
            {
                var_uc_29a = "999";
            }
            else if (uc_29a_c.Checked == true)
            {
                var_uc_29a = "888";
            }



            if (uc_29b_a.Checked == true)
            {
                var_uc_29b = "1";
            }
            else if (uc_29b_b.Checked == true)
            {
                var_uc_29b = "2";
            }
            else if (uc_29b_c.Checked == true)
            {
                var_uc_29b = "3";
            }




            if (uc_30a_v.Checked == true)
            {
                var_uc_30a = "";
            }
            else if (uc_30a_b.Checked == true)
            {
                var_uc_30a = "999";
            }
            else if (uc_30a_c.Checked == true)
            {
                var_uc_30a = "888";
            }



            if (uc_30b_a.Checked == true)
            {
                var_uc_30b = "1";
            }
            else if (uc_30b_b.Checked == true)
            {
                var_uc_30b = "2";
            }
            else if (uc_30b_c.Checked == true)
            {
                var_uc_30b = "3";
            }



            if (uc_31a_v.Checked == true)
            {
                var_uc_31a = "";
            }
            else if (uc_31a_b.Checked == true)
            {
                var_uc_31a = "999";
            }
            else if (uc_31a_c.Checked == true)
            {
                var_uc_31a = "888";
            }



            if (uc_31b_a.Checked == true)
            {
                var_uc_31b = "1";
            }
            else if (uc_31b_b.Checked == true)
            {
                var_uc_31b = "2";
            }
            else if (uc_31b_c.Checked == true)
            {
                var_uc_31b = "3";
            }



            if (uc_32a_v.Checked == true)
            {
                var_uc_32a = "";
            }
            else if (uc_32a_b.Checked == true)
            {
                var_uc_32a = "999";
            }
            else if (uc_32a_c.Checked == true)
            {
                var_uc_32a = "888";
            }



            if (uc_32b_a.Checked == true)
            {
                var_uc_32b = "1";
            }
            else if (uc_32b_b.Checked == true)
            {
                var_uc_32b = "2";
            }
            else if (uc_32b_c.Checked == true)
            {
                var_uc_32b = "3";
            }




            if (uc_33a_v.Checked == true)
            {
                var_uc_33a = "";
            }
            else if (uc_33a_b.Checked == true)
            {
                var_uc_33a = "999";
            }
            else if (uc_33a_c.Checked == true)
            {
                var_uc_33a = "888";
            }



            if (uc_33b_a.Checked == true)
            {
                var_uc_33b = "1";
            }
            else if (uc_33b_b.Checked == true)
            {
                var_uc_33b = "2";
            }
            else if (uc_33b_c.Checked == true)
            {
                var_uc_33b = "3";
            }



            if (uc_34a_v.Checked == true)
            {
                var_uc_34a = "";
            }
            else if (uc_34a_b.Checked == true)
            {
                var_uc_34a = "999";
            }
            else if (uc_34a_c.Checked == true)
            {
                var_uc_34a = "888";
            }



            if (uc_34b_a.Checked == true)
            {
                var_uc_34b = "1";
            }
            else if (uc_34b_b.Checked == true)
            {
                var_uc_34b = "2";
            }
            else if (uc_34b_c.Checked == true)
            {
                var_uc_34b = "3";
            }




            if (uc_35a_v.Checked == true)
            {
                var_uc_35a = "";
            }
            else if (uc_35a_b.Checked == true)
            {
                var_uc_35a = "999";
            }
            else if (uc_35a_c.Checked == true)
            {
                var_uc_35a = "888";
            }



            if (uc_35b_a.Checked == true)
            {
                var_uc_35b = "1";
            }
            else if (uc_35b_b.Checked == true)
            {
                var_uc_35b = "2";
            }
            else if (uc_35b_c.Checked == true)
            {
                var_uc_35b = "3";
            }





            if (uc_36a_v.Checked == true)
            {
                var_uc_36a = "";
            }
            else if (uc_36a_b.Checked == true)
            {
                var_uc_36a = "999";
            }
            else if (uc_36a_c.Checked == true)
            {
                var_uc_36a = "888";
            }



            if (uc_36b_a.Checked == true)
            {
                var_uc_36b = "1";
            }
            else if (uc_36b_b.Checked == true)
            {
                var_uc_36b = "2";
            }
            else if (uc_36b_c.Checked == true)
            {
                var_uc_36b = "3";
            }





            if (uc_37a_v.Checked == true)
            {
                var_uc_37a = "";
            }
            else if (uc_37a_b.Checked == true)
            {
                var_uc_37a = "999";
            }
            else if (uc_37a_c.Checked == true)
            {
                var_uc_37a = "888";
            }



            if (uc_37b_a.Checked == true)
            {
                var_uc_37b = "1";
            }
            else if (uc_37b_b.Checked == true)
            {
                var_uc_37b = "2";
            }
            else if (uc_37b_c.Checked == true)
            {
                var_uc_37b = "3";
            }






            if (LA_20a_v.Checked == true)
            {
                var_LA_20a_b = "";
            }
            else if (LA_20a_b.Checked == true)
            {
                var_LA_20a_b = "999";
            }
            else if (LA_20a_c.Checked == true)
            {
                var_LA_20a_b = "888";
            }



            if (LA_20b_a.Checked == true)
            {
                var_LA_20b_a = "1";
            }
            else if (LA_20b_b.Checked == true)
            {
                var_LA_20b_a = "2";
            }
            else if (LA_20b_c.Checked == true)
            {
                var_LA_20b_a = "3";
            }




            if (LA_21a_v.Checked == true)
            {
                var_LA_21a_b = "";
            }
            else if (LA_21a_b.Checked == true)
            {
                var_LA_21a_b = "999";
            }
            else if (LA_21a_c.Checked == true)
            {
                var_LA_21a_b = "888";
            }



            if (LA_21b_a.Checked == true)
            {
                var_LA_21b_a = "1";
            }
            else if (LA_21b_b.Checked == true)
            {
                var_LA_21b_a = "2";
            }
            else if (LA_21b_c.Checked == true)
            {
                var_LA_21b_a = "3";
            }



            if (LA_22a_v.Checked == true)
            {
                var_LA_22a_b = "";
            }
            else if (LA_22a_b.Checked == true)
            {
                var_LA_22a_b = "999";
            }
            else if (LA_22a_c.Checked == true)
            {
                var_LA_22a_b = "888";
            }



            if (LA_22b_a.Checked == true)
            {
                var_LA_22b_a = "1";
            }
            else if (LA_22b_b.Checked == true)
            {
                var_LA_22b_a = "2";
            }
            else if (LA_22b_c.Checked == true)
            {
                var_LA_22b_a = "3";
            }



            if (LA_23a_v.Checked == true)
            {
                var_LA_23a_b = "";
            }
            else if (LA_23a_b.Checked == true)
            {
                var_LA_23a_b = "999";
            }
            else if (LA_23a_c.Checked == true)
            {
                var_LA_23a_b = "888";
            }



            if (LA_23b_a.Checked == true)
            {
                var_LA_23b_a = "1";
            }
            else if (LA_23b_b.Checked == true)
            {
                var_LA_23b_a = "2";
            }
            else if (LA_23b_c.Checked == true)
            {
                var_LA_23b_a = "3";
            }



            if (LA_24a_v.Checked == true)
            {
                var_LA_24a_b = "";
            }
            else if (LA_24a_b.Checked == true)
            {
                var_LA_24a_b = "999";
            }
            else if (LA_24a_c.Checked == true)
            {
                var_LA_24a_b = "888";
            }



            if (LA_24b_a.Checked == true)
            {
                var_LA_24b_a = "1";
            }
            else if (LA_24b_b.Checked == true)
            {
                var_LA_24b_a = "2";
            }
            else if (LA_24b_c.Checked == true)
            {
                var_LA_24b_a = "3";
            }



            if (LA_25a_v.Checked == true)
            {
                var_LA_25a_b = "";
            }
            else if (LA_25a_b.Checked == true)
            {
                var_LA_25a_b = "999";
            }
            else if (LA_25a_c.Checked == true)
            {
                var_LA_25a_b = "888";
            }



            if (LA_25b_a.Checked == true)
            {
                var_LA_25b_a = "1";
            }
            else if (LA_25b_b.Checked == true)
            {
                var_LA_25b_a = "2";
            }
            else if (LA_25b_c.Checked == true)
            {
                var_LA_25b_a = "3";
            }



            if (LA_26a_v.Checked == true)
            {
                var_LA_26a_b = "";
            }
            else if (LA_26a_b.Checked == true)
            {
                var_LA_26a_b = "999";
            }
            else if (LA_26a_c.Checked == true)
            {
                var_LA_26a_b = "888";
            }



            if (LA_26b_a.Checked == true)
            {
                var_LA_26b_a = "1";
            }
            else if (LA_26b_b.Checked == true)
            {
                var_LA_26b_a = "2";
            }
            else if (LA_26b_c.Checked == true)
            {
                var_LA_26b_a = "3";
            }




            if (LA_27a_v.Checked == true)
            {
                var_LA_27a_b = "";
            }
            else if (LA_27a_b.Checked == true)
            {
                var_LA_27a_b = "999";
            }
            else if (LA_27a_c.Checked == true)
            {
                var_LA_27a_b = "888";
            }



            if (LA_27b_a.Checked == true)
            {
                var_LA_27b_a = "1";
            }
            else if (LA_27b_b.Checked == true)
            {
                var_LA_27b_a = "2";
            }
            else if (LA_27b_c.Checked == true)
            {
                var_LA_27b_a = "3";
            }




            if (LA_28a_v.Checked == true)
            {
                var_LA_28a_b = "";
            }
            else if (LA_28a_b.Checked == true)
            {
                var_LA_28a_b = "999";
            }
            else if (LA_28a_c.Checked == true)
            {
                var_LA_28a_b = "888";
            }



            if (LA_28b_a.Checked == true)
            {
                var_LA_28b_a = "1";
            }
            else if (LA_28b_b.Checked == true)
            {
                var_LA_28b_a = "2";
            }
            else if (LA_28b_c.Checked == true)
            {
                var_LA_28b_a = "3";
            }



            if (LA_29a_v.Checked == true)
            {
                var_LA_29a_b = "";
            }
            else if (LA_29a_b.Checked == true)
            {
                var_LA_29a_b = "999";
            }
            else if (LA_29a_c.Checked == true)
            {
                var_LA_29a_b = "888";
            }



            if (LA_29b_a.Checked == true)
            {
                var_LA_29b_a = "1";
            }
            else if (LA_29b_b.Checked == true)
            {
                var_LA_29b_a = "2";
            }
            else if (LA_29b_c.Checked == true)
            {
                var_LA_29b_a = "3";
            }



            if (LA_30a_v.Checked == true)
            {
                var_LA_30a_b = "";
            }
            else if (LA_30a_b.Checked == true)
            {
                var_LA_30a_b = "999";
            }
            else if (LA_30a_c.Checked == true)
            {
                var_LA_30a_b = "888";
            }



            if (LA_30b_a.Checked == true)
            {
                var_LA_30b_a = "1";
            }
            else if (LA_30b_b.Checked == true)
            {
                var_LA_30b_a = "2";
            }
            else if (LA_30b_c.Checked == true)
            {
                var_LA_30b_a = "3";
            }



            if (LA_31a_v.Checked == true)
            {
                var_LA_31a_b = "";
            }
            else if (LA_31a_b.Checked == true)
            {
                var_LA_31a_b = "999";
            }
            else if (LA_31a_c.Checked == true)
            {
                var_LA_31a_b = "888";
            }



            if (LA_31b_a.Checked == true)
            {
                var_LA_31b_a = "1";
            }
            else if (LA_31b_b.Checked == true)
            {
                var_LA_31b_a = "2";
            }
            else if (LA_31b_c.Checked == true)
            {
                var_LA_31b_a = "3";
            }



            if (LA_32a_v.Checked == true)
            {
                var_LA_32a_b = "";
            }
            else if (LA_32a_b.Checked == true)
            {
                var_LA_32a_b = "999";
            }
            else if (LA_32a_c.Checked == true)
            {
                var_LA_32a_b = "888";
            }



            if (LA_32b_a.Checked == true)
            {
                var_LA_32b_a = "1";
            }
            else if (LA_32b_b.Checked == true)
            {
                var_LA_32b_a = "2";
            }
            else if (LA_32b_c.Checked == true)
            {
                var_LA_32b_a = "3";
            }




            if (LA_33a_v.Checked == true)
            {
                var_LA_33a_b = "";
            }
            else if (LA_33a_b.Checked == true)
            {
                var_LA_33a_b = "999";
            }
            else if (LA_33a_c.Checked == true)
            {
                var_LA_33a_b = "888";
            }



            if (LA_33b_a.Checked == true)
            {
                var_LA_33b_a = "1";
            }
            else if (LA_33b_b.Checked == true)
            {
                var_LA_33b_a = "2";
            }
            else if (LA_33b_c.Checked == true)
            {
                var_LA_33b_a = "3";
            }




            if (LA_34a_v.Checked == true)
            {
                var_LA_34a_b = "";
            }
            else if (LA_34a_b.Checked == true)
            {
                var_LA_34a_b = "999";
            }
            else if (LA_34a_c.Checked == true)
            {
                var_LA_34a_b = "888";
            }



            if (LA_34b_a.Checked == true)
            {
                var_LA_34b_a = "1";
            }
            else if (LA_34b_b.Checked == true)
            {
                var_LA_34b_a = "2";
            }
            else if (LA_34b_c.Checked == true)
            {
                var_LA_34b_a = "3";
            }




            if (LA_35a_v.Checked == true)
            {
                var_LA_35a_b = "";
            }
            else if (LA_35a_b.Checked == true)
            {
                var_LA_35a_b = "999";
            }
            else if (LA_35a_c.Checked == true)
            {
                var_LA_35a_b = "888";
            }




            if (LA_35b_a.Checked == true)
            {
                var_LA_35b_a = "1";
            }
            else if (LA_35b_b.Checked == true)
            {
                var_LA_35b_a = "2";
            }
            else if (LA_35b_c.Checked == true)
            {
                var_LA_35b_a = "3";
            }




            if (LA_36a_v.Checked == true)
            {
                var_LA_36a_b = "";
            }
            else if (LA_36a_b.Checked == true)
            {
                var_LA_36a_b = "999";
            }
            else if (LA_36a_c.Checked == true)
            {
                var_LA_36a_b = "888";
            }



            if (LA_36b_a.Checked == true)
            {
                var_LA_36b_a = "1";
            }
            else if (LA_36b_b.Checked == true)
            {
                var_LA_36b_a = "2";
            }
            else if (LA_36b_c.Checked == true)
            {
                var_LA_36b_a = "3";
            }




            if (LA_37a_v.Checked == true)
            {
                var_LA_37a_b = "";
            }
            else if (LA_37a_b.Checked == true)
            {
                var_LA_37a_b = "999";
            }
            else if (LA_37a_c.Checked == true)
            {
                var_LA_37a_b = "888";
            }



            if (LA_37b_a.Checked == true)
            {
                var_LA_37b_a = "1";
            }
            else if (LA_37b_b.Checked == true)
            {
                var_LA_37b_a = "2";
            }
            else if (LA_37b_c.Checked == true)
            {
                var_LA_37b_a = "3";
            }




            if (LA_38a_v.Checked == true)
            {
                var_LA_38a_b = "";
            }
            else if (LA_38a_b.Checked == true)
            {
                var_LA_38a_b = "999";
            }
            else if (LA_38a_c.Checked == true)
            {
                var_LA_38a_b = "888";
            }



            if (LA_38b_a.Checked == true)
            {
                var_LA_38b_a = "1";
            }
            else if (LA_38b_b.Checked == true)
            {
                var_LA_38b_a = "2";
            }
            else if (LA_38b_c.Checked == true)
            {
                var_LA_38b_a = "3";
            }




            if (LA_39a_v.Checked == true)
            {
                var_LA_39a_b = "";
            }
            else if (LA_39a_b.Checked == true)
            {
                var_LA_39a_b = "999";
            }
            else if (LA_39a_c.Checked == true)
            {
                var_LA_39a_b = "888";
            }



            if (LA_39b_a.Checked == true)
            {
                var_LA_39b_a = "1";
            }
            else if (LA_39b_b.Checked == true)
            {
                var_LA_39b_a = "2";
            }
            else if (LA_39b_c.Checked == true)
            {
                var_LA_39b_a = "3";
            }



            if (LA_40a_v.Checked == true)
            {
                var_LA_40a_b = "";
            }
            else if (LA_40a_b.Checked == true)
            {
                var_LA_40a_b = "999";
            }
            else if (LA_40a_c.Checked == true)
            {
                var_LA_40a_b = "888";
            }



            if (LA_40b_a.Checked == true)
            {
                var_LA_40b_a = "1";
            }
            else if (LA_40b_b.Checked == true)
            {
                var_LA_40b_a = "2";
            }
            else if (LA_40b_c.Checked == true)
            {
                var_LA_40b_a = "3";
            }



            if (LA_41a_v.Checked == true)
            {
                var_LA_41a_b = "";
            }
            else if (LA_41a_b.Checked == true)
            {
                var_LA_41a_b = "999";
            }
            else if (LA_41a_c.Checked == true)
            {
                var_LA_41a_b = "888";
            }



            if (LA_41b_a.Checked == true)
            {
                var_LA_41b_a = "1";
            }
            else if (LA_41b_b.Checked == true)
            {
                var_LA_41b_a = "2";
            }
            else if (LA_41b_c.Checked == true)
            {
                var_LA_41b_a = "3";
            }



            if (LA_42a_v.Checked == true)
            {
                var_LA_42a_b = "";
            }
            else if (LA_42a_b.Checked == true)
            {
                var_LA_42a_b = "999";
            }
            else if (LA_42a_c.Checked == true)
            {
                var_LA_42a_b = "888";
            }



            if (LA_42b_a.Checked == true)
            {
                var_LA_42b_a = "1";
            }
            else if (LA_42b_b.Checked == true)
            {
                var_LA_42b_a = "2";
            }
            else if (LA_42b_c.Checked == true)
            {
                var_LA_42b_a = "3";
            }



            if (LA_43a_v.Checked == true)
            {
                var_LA_43a_b = "";
            }
            else if (LA_43a_b.Checked == true)
            {
                var_LA_43a_b = "999";
            }
            else if (LA_43a_c.Checked == true)
            {
                var_LA_43a_b = "888";
            }



            if (LA_43b_a.Checked == true)
            {
                var_LA_43b_a = "1";
            }
            else if (LA_43b_b.Checked == true)
            {
                var_LA_43b_a = "2";
            }
            else if (LA_43b_c.Checked == true)
            {
                var_LA_43b_a = "3";
            }



            if (LA_44a_v.Checked == true)
            {
                var_LA_44a_b = "";
            }
            else if (LA_44a_b.Checked == true)
            {
                var_LA_44a_b = "999";
            }
            else if (LA_44a_c.Checked == true)
            {
                var_LA_44a_b = "888";
            }



            if (LA_44b_a.Checked == true)
            {
                var_LA_44b_a = "1";
            }
            else if (LA_44b_b.Checked == true)
            {
                var_LA_44b_a = "2";
            }
            else if (LA_44b_c.Checked == true)
            {
                var_LA_44b_a = "3";
            }



            if (LA_45a_v.Checked == true)
            {
                var_LA_45a_b = "";
            }
            else if (LA_45a_b.Checked == true)
            {
                var_LA_45a_b = "999";
            }
            else if (LA_45a_c.Checked == true)
            {
                var_LA_45a_b = "888";
            }



            if (LA_45b_a.Checked == true)
            {
                var_LA_45b_a = "1";
            }
            else if (LA_45b_b.Checked == true)
            {
                var_LA_45b_a = "2";
            }
            else if (LA_45b_c.Checked == true)
            {
                var_LA_45b_a = "3";
            }



            if (LA_46a_v.Checked == true)
            {
                var_LA_46a_b = "";
            }
            else if (LA_46a_b.Checked == true)
            {
                var_LA_46a_b = "999";
            }
            else if (LA_46a_c.Checked == true)
            {
                var_LA_46a_b = "888";
            }



            if (LA_46b_a.Checked == true)
            {
                var_LA_46b_a = "1";
            }
            else if (LA_46b_b.Checked == true)
            {
                var_LA_46b_a = "2";
            }
            else if (LA_46b_c.Checked == true)
            {
                var_LA_46b_a = "3";
            }



            if (LA_47a_v.Checked == true)
            {
                var_LA_47a_b = "";
            }
            else if (LA_47a_b.Checked == true)
            {
                var_LA_47a_b = "999";
            }
            else if (LA_47a_c.Checked == true)
            {
                var_LA_47a_b = "888";
            }



            if (LA_47b_a.Checked == true)
            {
                var_LA_47b_a = "1";
            }
            else if (LA_47b_b.Checked == true)
            {
                var_LA_47b_a = "2";
            }
            else if (LA_47b_c.Checked == true)
            {
                var_LA_47b_a = "3";
            }




            if (LA_48a_v.Checked == true)
            {
                var_LA_48a_b = "";
            }
            else if (LA_48a_b.Checked == true)
            {
                var_LA_48a_b = "999";
            }
            else if (LA_48a_c.Checked == true)
            {
                var_LA_48a_b = "888";
            }



            if (LA_48b_a.Checked == true)
            {
                var_LA_48b_a = "1";
            }
            else if (LA_48b_b.Checked == true)
            {
                var_LA_48b_a = "2";
            }
            else if (LA_48b_c.Checked == true)
            {
                var_LA_48b_a = "3";
            }



            if (LA_49a_v.Checked == true)
            {
                var_LA_49a_b = "";
            }
            else if (LA_49a_b.Checked == true)
            {
                var_LA_49a_b = "999";
            }
            else if (LA_49a_c.Checked == true)
            {
                var_LA_49a_b = "888";
            }



            if (LA_49b_a.Checked == true)
            {
                var_LA_49b_a = "1";
            }
            else if (LA_49b_b.Checked == true)
            {
                var_LA_49b_a = "2";
            }
            else if (LA_49b_c.Checked == true)
            {
                var_LA_49b_a = "3";
            }



            if (LA_50a_v.Checked == true)
            {
                var_LA_50a_b = "";
            }
            else if (LA_50a_b.Checked == true)
            {
                var_LA_50a_b = "999";
            }
            else if (LA_50a_c.Checked == true)
            {
                var_LA_50a_b = "888";
            }



            if (LA_50b_a.Checked == true)
            {
                var_LA_50b_a = "1";
            }
            else if (LA_50b_b.Checked == true)
            {
                var_LA_50b_a = "2";
            }
            else if (LA_50b_c.Checked == true)
            {
                var_LA_50b_a = "3";
            }




            if (LA_51a_v.Checked == true)
            {
                var_LA_51a_b = "";
            }
            else if (LA_51a_b.Checked == true)
            {
                var_LA_51a_b = "999";
            }
            else if (LA_51a_c.Checked == true)
            {
                var_LA_51a_b = "888";
            }



            if (LA_51b_a.Checked == true)
            {
                var_LA_51b_a = "1";
            }
            else if (LA_51b_b.Checked == true)
            {
                var_LA_51b_a = "2";
            }
            else if (LA_51b_c.Checked == true)
            {
                var_LA_51b_a = "3";
            }




            if (LA_52a_v.Checked == true)
            {
                var_LA_52a_b = "";
            }
            else if (LA_52a_b.Checked == true)
            {
                var_LA_52a_b = "999";
            }
            else if (LA_52a_c.Checked == true)
            {
                var_LA_52a_b = "888";
            }



            if (LA_52b_a.Checked == true)
            {
                var_LA_52b_a = "1";
            }
            else if (LA_52b_b.Checked == true)
            {
                var_LA_52b_a = "2";
            }
            else if (LA_52b_c.Checked == true)
            {
                var_LA_52b_a = "3";
            }


            if (rd_BloodCulture_Pos.Checked == true)
            {
                var_BloodCulture = "1";
            }
            else if (rd_BloodCulture_Neg.Checked == true)
            {
                var_BloodCulture = "2";
            }


            if (BloodCulture_Multiple_Yes.Checked)
            {
                var_BloodCulture_Multiple = "1";
            }
            else if (BloodCulture_Multiple_No.Checked)
            {
                var_BloodCulture_Multiple = "2";
            }


            DateTime dt_entry = new DateTime();

            string[] arr_entry = null;
            string val_entry = null;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            dt_entry = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            arr_entry = dt_entry.ToShortDateString().Split('/');
            val_entry = arr_entry[2] + "/" + arr_entry[1] + "/" + arr_entry[0];


            CConnection cn = new CConnection();


            string qry1 = "select * from sample_result where id='" + ViewState["id"] + "'";


            string msg1 = obj_op.ExecuteNonQuery_Message_Qry(qry1);

            if (string.IsNullOrEmpty(msg1))
            {

                if (ddl_BloodCulture.Items[ddl_BloodCulture.SelectedIndex].Text == "Others")
                {

                    qry1 = "UPDATE sample_result set " +
        "LA_01 = '" + LA_01.Text + "', " +
        "LA_02 = '" + LA_02.Text + "', " +
        "LA_02a = '" + LA_02a.Text + "', " +
        "LA_03_b = '" + var_LA_03_b + "', " +
        "LA_03_a = '" + LA_03_a.Text + "', " +
        "LA_04_b = '" + var_LA_04_b + "', " +
        "LA_04_a = '" + LA_04_a.Text + "', " +
        "LA_05_b = '" + var_LA_05_b + "', " +
        "LA_05_a = '" + LA_05_a.Text + "', " +
        "LA_06_b = '" + var_LA_06_b + "', " +
        "LA_06_a = '" + LA_06_a.Text + "', " +
        "LA_07_b = '" + var_LA_07_b + "', " +
        "LA_07_a = '" + LA_07_a.Text + "', " +
        "LA_08_b = '" + var_LA_08_b + "', " +
        "LA_08_a = '" + LA_08_a.Text + "', " +
        "LA_09_b = '" + var_LA_09_b + "', " +
        "LA_09_a = '" + LA_09_a.Text + "', " +
        "LA_10_b = '" + var_LA_10_b + "', " +
        "LA_10_a = '" + LA_10_a.Text + "', " +
        "LA_11_b = '" + var_LA_11_b + "', " +
        "LA_11_a = '" + LA_11_a.Text + "', " +
        "LA_12_b = '" + var_LA_12_b + "', " +
        "LA_12_a = '" + LA_12_a.Text + "', " +
        "LA_13_b = '" + var_LA_13_b + "', " +
        "LA_13_a = '" + LA_13_a.Text + "', " +
        "LA_14_b = '" + var_LA_14_b + "', " +
        "LA_14_a = '" + LA_14_a.Text + "', " +
        "LA_15_b = '" + var_LA_15_b + "', " +
        "LA_15_a = '" + LA_15_a.Text + "', " +
        "LA_16_b = '" + var_LA_16_b + "', " +
        "LA_16_a = '" + LA_16_a.Text + "', " +
        "LF_01 = '" + var_LF_01 + "', " +
        "LF_01_a = '" + LF_01_a.Text + "', " +
        "LF_02 = '" + var_LF_02 + "', " +
        "LF_02_a = '" + LF_02_a.Text + "', " +
        "LF_03 = '" + var_LF_03 + "', " +
        "LF_03_a = '" + LF_03_a.Text + "', " +
        "LF_04 = '" + var_LF_04 + "', " +
        "LF_04_a = '" + LF_04_a.Text + "', " +
        "LF_05 = '" + var_LF_05 + "', " +
        "LF_05_a = '" + LF_05_a.Text + "', " +
        "LF_06 = '" + var_LF_06 + "', " +
        "LF_06_a = '" + LF_06_a.Text + "', " +
        "LF_07 = '" + var_LF_07 + "', " +
        "LF_07_a = '" + LF_07_a.Text + "', " +
        "RF_01 = '" + var_RF_01 + "', " +
        "RF_01_a = '" + RF_01_a.Text + "', " +
        "RF_02 = '" + var_RF_02 + "', " +
        "RF_02_a = '" + RF_02_a.Text + "', " +
        "RF_03 = '" + var_RF_03 + "', " +
        "RF_03_a = '" + RF_03_a.Text + "', " +
        "RF_04 = '" + var_RF_04 + "', " +
        "RF_04_a = '" + RF_04_a.Text + "', " +
        "SE_01 = '" + var_SE_01 + "', " +
        "SE_01_a = '" + SE_01_a.Text + "', " +
        "SE_02 = '" + var_SE_02 + "', " +
        "SE_02_a = '" + SE_02_a.Text + "', " +
        "SE_03 = '" + var_SE_03 + "', " +
        "SE_03_a = '" + SE_03_a.Text + "', " +
        "SE_04 = '" + var_SE_04 + "', " +
        "SE_04_a = '" + SE_04_a.Text + "', " +
        "CS_01 = '" + var_CS_01 + "', " +
        "CS_01_a = '" + CS_01_a.Text + "', " +
        "CS_02 = '" + var_CS_02 + "', " +
        "CS_02_a = '" + CS_02_a.Text + "', " +
        "CS_03 = '" + var_CS_03 + "', " +
        "CS_03_a = '" + CS_03_a.Text + "', " +
        "CS_04 = '" + var_CS_04 + "', " +
        "CS_04_a = '" + CS_04_a.Text + "', " +
        "CS_05 = '" + var_CS_05 + "', " +
        "CS_05_a = '" + CS_05_a.Text + "', " +
        "CS_06 = '" + var_CS_06 + "', " +
        "CS_06_a = '" + CS_06_a.Text + "', " +
        "CS_07 = '" + var_CS_07 + "', " +
        "CS_07_a = '" + CS_07_a.Text + "', " +
        "CS_08 = '" + var_CS_08 + "', " +
        "CS_08_a = '" + CS_08_a.Text + "', " +
        "CS_09 = '" + var_CS_09 + "', " +
        "CS_09_a = '" + CS_09_a.Text + "', " +
        "CS_10 = '" + var_CS_10 + "', " +
        "CS_10_a = '" + CS_10_a.Text + "', " +
        "UR_01 = '" + var_UR_01 + "', " +
        "UR_01_a = '" + UR_01_a.Text + "', " +
        "UR_02 = '" + var_UR_02 + "', " +
        "UR_02_a = '" + UR_02_a.Text + "', " +
        "UR_03 = '" + var_UR_03 + "', " +
        "UR_03_a = '" + UR_03_a.Text + "', " +
        "UR_04 = '" + var_UR_04 + "', " +
        "UR_04_a = '" + UR_04_a.Text + "', " +
        "UR_05 = '" + var_UR_05 + "', " +
        "UR_05_a = '" + UR_05_a.Text + "', " +
        "UR_06 = '" + var_UR_06 + "', " +
        "UR_06_a = '" + UR_06_a.Text + "', " +
        "UR_07 = '" + var_UR_07 + "', " +
        "UR_07_a = '" + UR_07_a.Text + "', " +
        "UR_08 = '" + var_UR_08 + "', " +
        "UR_08_a = '" + UR_08_a.Text + "', " +
        "UR_10 = '" + var_UR_10 + "', " +
        "UR_10_a = '" + UR_10_a.Text + "', " +
        "UR_11 = '" + var_UR_11 + "', " +
        "UR_11_a = '" + UR_11_a.Text + "', " +
        "UR_12 = '" + var_UR_12 + "', " +
        "UR_12_a = '" + UR_12_a.Text + "', " +
        "UR_13 = '" + var_UR_13 + "', " +
        "UR_13_a = '" + UR_13_a.Text + "', " +
        "UR_14 = '" + var_UR_14 + "', " +
        "UR_14_a = '" + UR_14_a.Text + "', " +
        "UR_15 = '" + var_UR_15 + "', " +
        "UR_15_a = '" + UR_15_a.Text + "', " +
        "UR_16 = '" + var_UR_16 + "', " +
        "UR_16_a = '" + UR_16_a.Text + "', " +
        "UR_17 = '" + var_UR_17 + "', " +
        "UR_17_a = '" + UR_17_a.Text + "', " +
        "UR_18 = '" + var_UR_18 + "', " +
        "UR_18_a = '" + UR_18_a.Text + "', " +
        "UR_19 = '" + var_UR_19 + "', " +
        "UR_19_a = '" + UR_19_a.Text + "', " +
        "UR_20 = '" + var_UR_20 + "', " +
        "UR_20_a = '" + UR_20_a.Text + "', " +
        "UR_21 = '" + var_UR_21 + "', " +
        "UR_21_a = '" + UR_21_a.Text + "', " +
        "uc_01a = '" + var_uc_01a + "', " +
        "uc_02a = '" + var_uc_02a + "', " +
        "uc_02a_a = '" + uc_02a_a.Text + "', " +
        "uc_02b = '" + var_uc_02b + "', " +
        "uc_03a = '" + var_uc_03a + "', " +
        "uc_03a_a = '" + uc_03a_a.Text + "', " +
        "uc_03b = '" + var_uc_03b + "', " +
        "uc_04a = '" + var_uc_04a + "', " +
        "uc_04a_a = '" + uc_04a_a.Text + "', " +
        "uc_04b = '" + var_uc_04b + "', " +
        "uc_05a = '" + var_uc_05a + "', " +
        "uc_05a_a = '" + uc_05a_a.Text + "', " +
        "uc_05b = '" + var_uc_05b + "', " +
        "uc_06a = '" + var_uc_06a + "', " +
        "uc_06a_a = '" + uc_06a_a.Text + "', " +
        "uc_06b = '" + var_uc_06b + "', " +
        "uc_07a = '" + var_uc_07a + "', " +
        "uc_07a_a = '" + uc_07a_a.Text + "', " +
        "uc_07b = '" + var_uc_07b + "', " +
        "uc_08a = '" + var_uc_08a + "', " +
        "uc_08a_a = '" + uc_08a_a.Text + "', " +
        "uc_08b = '" + var_uc_08b + "', " +
        "uc_09a = '" + var_uc_09a + "', " +
        "uc_09a_a = '" + uc_09a_a.Text + "', " +
        "uc_09b = '" + var_uc_09b + "', " +
        "uc_10a = '" + var_uc_10a + "', " +
        "uc_10a_a = '" + uc_10a_a.Text + "', " +
        "uc_10b = '" + var_uc_10b + "', " +
        "uc_11a = '" + var_uc_11a + "', " +
        "uc_11a_a = '" + uc_11a_a.Text + "', " +
        "uc_11b = '" + var_uc_11b + "', " +
        "uc_12a = '" + var_uc_12a + "', " +
        "uc_12a_a = '" + uc_12a_a.Text + "', " +
        "uc_12b = '" + var_uc_12b + "', " +
        "uc_13a = '" + var_uc_13a + "', " +
        "uc_13a_a = '" + uc_13a_a.Text + "', " +
        "uc_13b = '" + var_uc_13b + "', " +
        "uc_14a = '" + var_uc_14a + "', " +
        "uc_14a_a = '" + uc_14a_a.Text + "', " +
        "uc_14b = '" + var_uc_14b + "', " +
        "uc_15a = '" + var_uc_15a + "', " +
        "uc_15a_a = '" + uc_15a_a.Text + "', " +
        "uc_15b = '" + var_uc_15b + "', " +
        "uc_16a = '" + var_uc_16a + "', " +
        "uc_16a_a = '" + uc_16a_a.Text + "', " +
        "uc_16b = '" + var_uc_16b + "', " +
        "uc_17a = '" + var_uc_17a + "', " +
        "uc_17a_a = '" + uc_17a_a.Text + "', " +
        "uc_17b = '" + var_uc_17b + "', " +
        "uc_18a = '" + var_uc_18a + "', " +
        "uc_18a_a = '" + uc_18a_a.Text + "', " +
        "uc_18b = '" + var_uc_18b + "', " +
        "uc_19a = '" + var_uc_19a + "', " +
        "uc_19a_a = '" + uc_19a_a.Text + "', " +
        "uc_19b = '" + var_uc_19b + "', " +
        "uc_20a = '" + var_uc_20a + "', " +
        "uc_20a_a = '" + uc_20a_a.Text + "', " +
        "uc_20b = '" + var_uc_20b + "', " +
        "uc_21a = '" + var_uc_21a + "', " +
        "uc_21a_a = '" + uc_21a_a.Text + "', " +
        "uc_21b = '" + var_uc_21b + "', " +
        "uc_22a = '" + var_uc_22a + "', " +
        "uc_22a_a = '" + uc_22a_a.Text + "', " +
        "uc_22b = '" + var_uc_22b + "', " +
        "uc_23a = '" + var_uc_23a + "', " +
        "uc_23a_a = '" + uc_23a_a.Text + "', " +
        "uc_23b = '" + var_uc_23b + "', " +
        "uc_24a = '" + var_uc_24a + "', " +
        "uc_24a_a = '" + uc_24a_a.Text + "', " +
        "uc_24b = '" + var_uc_24b + "', " +
        "uc_25a = '" + var_uc_25a + "', " +
        "uc_25a_a = '" + uc_25a_a.Text + "', " +
        "uc_25b = '" + var_uc_25b + "', " +
        "uc_26a = '" + var_uc_26a + "', " +
        "uc_26a_a = '" + uc_26a_a.Text + "', " +
        "uc_26b = '" + var_uc_26b + "', " +
        "uc_27a = '" + var_uc_27a + "', " +
        "uc_27a_a = '" + uc_27a_a.Text + "', " +
        "uc_27b = '" + var_uc_27b + "', " +
        "uc_28a = '" + var_uc_28a + "', " +
        "uc_28a_a = '" + uc_28a_a.Text + "', " +
        "uc_28b = '" + var_uc_28b + "', " +
        "uc_29a = '" + var_uc_29a + "', " +
        "uc_29a_a = '" + uc_29a_a.Text + "', " +
        "uc_29b = '" + var_uc_29b + "', " +
        "uc_30a = '" + var_uc_30a + "', " +
        "uc_30a_a = '" + uc_30a_a.Text + "', " +
        "uc_30b = '" + var_uc_30b + "', " +
        "uc_31a = '" + var_uc_31a + "', " +
        "uc_31a_a = '" + uc_31a_a.Text + "', " +
        "uc_31b = '" + var_uc_31b + "', " +
        "uc_32a = '" + var_uc_32a + "', " +
        "uc_32a_a = '" + uc_32a_a.Text + "', " +
        "uc_32b = '" + var_uc_32b + "', " +
        "uc_33a = '" + var_uc_33a + "', " +
        "uc_33a_a = '" + uc_33a_a.Text + "', " +
        "uc_33b = '" + var_uc_33b + "', " +
        "uc_34a = '" + var_uc_34a + "', " +
        "uc_34a_a = '" + uc_34a_a.Text + "', " +
        "uc_34b = '" + var_uc_34b + "', " +
        "uc_35a = '" + var_uc_35a + "', " +
        "uc_35a_a = '" + uc_35a_a.Text + "', " +
        "uc_35b = '" + var_uc_35b + "', " +
        "uc_36a = '" + var_uc_36a + "', " +
        "uc_36a_a = '" + uc_36a_a.Text + "', " +
        "uc_36b = '" + var_uc_36b + "', " +
        "uc_37a = '" + var_uc_37a + "', " +
        "uc_37a_a = '" + uc_37a_a.Text + "', " +
        "uc_37b = '" + var_uc_37b + "', " +
        "LA_17 = '" + LA_17.Text + "', " +
        "LA_18 = '" + LA_18.Text + "', " +
        "LA_19 = '" + txtOtherOrganism.Text + "', " +
        "LA_20a_b = '" + var_LA_20a_b + "', " +
        "LA_20a_a = '" + LA_20a_a.Text + "', " +
        "LA_20b_a = '" + var_LA_20b_a + "', " +
        "LA_21a_b = '" + var_LA_21a_b + "', " +
        "LA_21a_a = '" + LA_21a_a.Text + "', " +
        "LA_21b_a = '" + var_LA_21b_a + "', " +
        "LA_22a_b = '" + var_LA_22a_b + "', " +
        "LA_22a_a = '" + LA_22a_a.Text + "', " +
        "LA_22b_a = '" + var_LA_22b_a + "', " +
        "LA_23a_b = '" + var_LA_23a_b + "', " +
        "LA_23a_a = '" + LA_23a_a.Text + "', " +
        "LA_23b_a = '" + var_LA_23b_a + "', " +
        "LA_24a_b = '" + var_LA_24a_b + "', " +
        "LA_24a_a = '" + LA_24a_a.Text + "', " +
        "LA_24b_a = '" + var_LA_24b_a + "', " +
        "LA_25a_b = '" + var_LA_25a_b + "', " +
        "LA_25a_a = '" + LA_25a_a.Text + "', " +
        "LA_25b_a = '" + var_LA_25b_a + "', " +
        "LA_26a_b = '" + var_LA_26a_b + "', " +
        "LA_26a_a = '" + LA_26a_a.Text + "', " +
        "LA_26b_a = '" + var_LA_26b_a + "', " +
        "LA_27a_b = '" + var_LA_27a_b + "', " +
        "LA_27a_a = '" + LA_27a_a.Text + "', " +
        "LA_27b_a = '" + var_LA_27b_a + "', " +
        "LA_28a_b = '" + var_LA_28a_b + "', " +
        "LA_28a_a = '" + LA_28a_a.Text + "', " +
        "LA_28b_a = '" + var_LA_28b_a + "', " +
        "LA_29a_b = '" + var_LA_29a_b + "', " +
        "LA_29a_a = '" + LA_29a_a.Text + "', " +
        "LA_29b_a = '" + var_LA_29b_a + "', " +
        "LA_30a_b = '" + var_LA_30a_b + "', " +
        "LA_30a_a = '" + LA_30a_a.Text + "', " +
        "LA_30b_a = '" + var_LA_30b_a + "', " +
        "LA_31a_b = '" + var_LA_31a_b + "', " +
        "LA_31a_a = '" + LA_31a_a.Text + "', " +
        "LA_31b_a = '" + var_LA_31b_a + "', " +
        "LA_32a_b = '" + var_LA_32a_b + "', " +
        "LA_32a_a = '" + LA_32a_a.Text + "', " +
        "LA_32b_a = '" + var_LA_32b_a + "', " +
        "LA_33a_b = '" + var_LA_33a_b + "', " +
        "LA_33a_a = '" + LA_33a_a.Text + "', " +
        "LA_33b_a = '" + var_LA_33b_a + "', " +
        "LA_34a_b = '" + var_LA_34a_b + "', " +
        "LA_34a_a = '" + LA_34a_a.Text + "', " +
        "LA_34b_a = '" + var_LA_34b_a + "', " +
        "LA_35a_b = '" + var_LA_35a_b + "', " +
        "LA_35a_a = '" + LA_35a_a.Text + "', " +
        "LA_35b_a = '" + var_LA_35b_a + "', " +
        "LA_36a_b = '" + var_LA_36a_b + "', " +
        "LA_36a_a = '" + LA_36a_a.Text + "', " +
        "LA_36b_a = '" + var_LA_36b_a + "', " +
        "LA_37a_b = '" + var_LA_37a_b + "', " +
        "LA_37a_a = '" + LA_37a_a.Text + "', " +
        "LA_37b_a = '" + var_LA_37b_a + "', " +
        "LA_38a_b = '" + var_LA_38a_b + "', " +
        "LA_38a_a = '" + LA_38a_a.Text + "', " +
        "LA_38b_a = '" + var_LA_38b_a + "', " +
        "LA_39a_b = '" + var_LA_39a_b + "', " +
        "LA_39a_a = '" + LA_39a_a.Text + "', " +
        "LA_39b_a = '" + var_LA_39b_a + "', " +
        "LA_40a_b = '" + var_LA_40a_b + "', " +
        "LA_40a_a = '" + LA_40a_a.Text + "', " +
        "LA_40b_a = '" + var_LA_40b_a + "', " +
        "LA_41a_b = '" + var_LA_41a_b + "', " +
        "LA_41a_a = '" + LA_41a_a.Text + "', " +
        "LA_41b_a = '" + var_LA_41b_a + "', " +
        "LA_42a_b = '" + var_LA_42a_b + "', " +
        "LA_42a_a = '" + LA_42a_a.Text + "', " +
        "LA_42b_a = '" + var_LA_42b_a + "', " +
        "LA_43a_b = '" + var_LA_43a_b + "', " +
        "LA_43a_a = '" + LA_43a_a.Text + "', " +
        "LA_43b_a = '" + var_LA_43b_a + "', " +
        "LA_44a_b = '" + var_LA_44a_b + "', " +
        "LA_44a_a = '" + LA_44a_a.Text + "', " +
        "LA_44b_a = '" + var_LA_44b_a + "', " +
        "LA_45a_b = '" + var_LA_45a_b + "', " +
        "LA_45a_a = '" + LA_45a_a.Text + "', " +
        "LA_45b_a = '" + var_LA_45b_a + "', " +
        "LA_46a_b = '" + var_LA_46a_b + "', " +
        "LA_46a_a = '" + LA_46a_a.Text + "', " +
        "LA_46b_a = '" + var_LA_46b_a + "', " +
        "LA_47a_b = '" + var_LA_47a_b + "', " +
        "LA_47a_a = '" + LA_47a_a.Text + "', " +
        "LA_47b_a = '" + var_LA_47b_a + "', " +
        "LA_48a_b = '" + var_LA_48a_b + "', " +
        "LA_48a_a = '" + LA_48a_a.Text + "', " +
        "LA_48b_a = '" + var_LA_48b_a + "', " +
        "LA_49a_b = '" + var_LA_49a_b + "', " +
        "LA_49a_a = '" + LA_49a_a.Text + "', " +
        "LA_49b_a = '" + var_LA_49b_a + "', " +
        "LA_50a_b = '" + var_LA_50a_b + "', " +
        "LA_50a_a = '" + LA_50a_a.Text + "', " +
        "LA_50b_a = '" + var_LA_50b_a + "', " +
        "LA_51a_b = '" + var_LA_51a_b + "', " +
        "LA_51a_a = '" + LA_51a_a.Text + "', " +
        "LA_51b_a = '" + var_LA_51b_a + "', " +
        "LA_52a_b = '" + var_LA_52a_b + "', " +
        "LA_52a_a = '" + LA_52a_a.Text + "', " +
        "LA_52b_a = '" + var_LA_52b_a + "', " +
        "uc_01_ca = '" + uc_01_ca.Text + "', " +
        "UR_04a_a = '" + UR_04a_a.Text + "', " +
        "UR_04a = '" + var_UR_04a + "', " +
        "ProvisionalResult = '" + ProvisionalResult.Text + "', " +
        "rdo_BloodCulture = '" + var_BloodCulture + "', " +
        "rdo_BloodCulture_Multiple = '" + var_BloodCulture_Multiple + "', " +
        "ddl_BloodCulture = '" + ddl_BloodCulture.SelectedIndex + "' where id='" + ViewState["id"] + "'";

                }
                else
                {

                    qry1 = "UPDATE sample_result set " +
    "LA_01 = '" + LA_01.Text + "', " +
    "LA_02 = '" + LA_02.Text + "', " +
    "LA_02a = '" + LA_02a.Text + "', " +
    "LA_03_b = '" + var_LA_03_b + "', " +
    "LA_03_a = '" + LA_03_a.Text + "', " +
    "LA_04_b = '" + var_LA_04_b + "', " +
    "LA_04_a = '" + LA_04_a.Text + "', " +
    "LA_05_b = '" + var_LA_05_b + "', " +
    "LA_05_a = '" + LA_05_a.Text + "', " +
    "LA_06_b = '" + var_LA_06_b + "', " +
    "LA_06_a = '" + LA_06_a.Text + "', " +
    "LA_07_b = '" + var_LA_07_b + "', " +
    "LA_07_a = '" + LA_07_a.Text + "', " +
    "LA_08_b = '" + var_LA_08_b + "', " +
    "LA_08_a = '" + LA_08_a.Text + "', " +
    "LA_09_b = '" + var_LA_09_b + "', " +
    "LA_09_a = '" + LA_09_a.Text + "', " +
    "LA_10_b = '" + var_LA_10_b + "', " +
    "LA_10_a = '" + LA_10_a.Text + "', " +
    "LA_11_b = '" + var_LA_11_b + "', " +
    "LA_11_a = '" + LA_11_a.Text + "', " +
    "LA_12_b = '" + var_LA_12_b + "', " +
    "LA_12_a = '" + LA_12_a.Text + "', " +
    "LA_13_b = '" + var_LA_13_b + "', " +
    "LA_13_a = '" + LA_13_a.Text + "', " +
    "LA_14_b = '" + var_LA_14_b + "', " +
    "LA_14_a = '" + LA_14_a.Text + "', " +
    "LA_15_b = '" + var_LA_15_b + "', " +
    "LA_15_a = '" + LA_15_a.Text + "', " +
    "LA_16_b = '" + var_LA_16_b + "', " +
    "LA_16_a = '" + LA_16_a.Text + "', " +
    "LF_01 = '" + var_LF_01 + "', " +
    "LF_01_a = '" + LF_01_a.Text + "', " +
    "LF_02 = '" + var_LF_02 + "', " +
    "LF_02_a = '" + LF_02_a.Text + "', " +
    "LF_03 = '" + var_LF_03 + "', " +
    "LF_03_a = '" + LF_03_a.Text + "', " +
    "LF_04 = '" + var_LF_04 + "', " +
    "LF_04_a = '" + LF_04_a.Text + "', " +
    "LF_05 = '" + var_LF_05 + "', " +
    "LF_05_a = '" + LF_05_a.Text + "', " +
    "LF_06 = '" + var_LF_06 + "', " +
    "LF_06_a = '" + LF_06_a.Text + "', " +
    "LF_07 = '" + var_LF_07 + "', " +
    "LF_07_a = '" + LF_07_a.Text + "', " +
    "RF_01 = '" + var_RF_01 + "', " +
    "RF_01_a = '" + RF_01_a.Text + "', " +
    "RF_02 = '" + var_RF_02 + "', " +
    "RF_02_a = '" + RF_02_a.Text + "', " +
    "RF_03 = '" + var_RF_03 + "', " +
    "RF_03_a = '" + RF_03_a.Text + "', " +
    "RF_04 = '" + var_RF_04 + "', " +
    "RF_04_a = '" + RF_04_a.Text + "', " +
    "SE_01 = '" + var_SE_01 + "', " +
    "SE_01_a = '" + SE_01_a.Text + "', " +
    "SE_02 = '" + var_SE_02 + "', " +
    "SE_02_a = '" + SE_02_a.Text + "', " +
    "SE_03 = '" + var_SE_03 + "', " +
    "SE_03_a = '" + SE_03_a.Text + "', " +
    "SE_04 = '" + var_SE_04 + "', " +
    "SE_04_a = '" + SE_04_a.Text + "', " +
    "CS_01 = '" + var_CS_01 + "', " +
    "CS_01_a = '" + CS_01_a.Text + "', " +
    "CS_02 = '" + var_CS_02 + "', " +
    "CS_02_a = '" + CS_02_a.Text + "', " +
    "CS_03 = '" + var_CS_03 + "', " +
    "CS_03_a = '" + CS_03_a.Text + "', " +
    "CS_04 = '" + var_CS_04 + "', " +
    "CS_04_a = '" + CS_04_a.Text + "', " +
    "CS_05 = '" + var_CS_05 + "', " +
    "CS_05_a = '" + CS_05_a.Text + "', " +
    "CS_06 = '" + var_CS_06 + "', " +
    "CS_06_a = '" + CS_06_a.Text + "', " +
    "CS_07 = '" + var_CS_07 + "', " +
    "CS_07_a = '" + CS_07_a.Text + "', " +
    "CS_08 = '" + var_CS_08 + "', " +
    "CS_08_a = '" + CS_08_a.Text + "', " +
    "CS_09 = '" + var_CS_09 + "', " +
    "CS_09_a = '" + CS_09_a.Text + "', " +
    "CS_10 = '" + var_CS_10 + "', " +
    "CS_10_a = '" + CS_10_a.Text + "', " +
    "UR_01 = '" + var_UR_01 + "', " +
    "UR_01_a = '" + UR_01_a.Text + "', " +
    "UR_02 = '" + var_UR_02 + "', " +
    "UR_02_a = '" + UR_02_a.Text + "', " +
    "UR_03 = '" + var_UR_03 + "', " +
    "UR_03_a = '" + UR_03_a.Text + "', " +
    "UR_04 = '" + var_UR_04 + "', " +
    "UR_04_a = '" + UR_04_a.Text + "', " +
    "UR_05 = '" + var_UR_05 + "', " +
    "UR_05_a = '" + UR_05_a.Text + "', " +
    "UR_06 = '" + var_UR_06 + "', " +
    "UR_06_a = '" + UR_06_a.Text + "', " +
    "UR_07 = '" + var_UR_07 + "', " +
    "UR_07_a = '" + UR_07_a.Text + "', " +
    "UR_08 = '" + var_UR_08 + "', " +
    "UR_08_a = '" + UR_08_a.Text + "', " +
    "UR_10 = '" + var_UR_10 + "', " +
    "UR_10_a = '" + UR_10_a.Text + "', " +
    "UR_11 = '" + var_UR_11 + "', " +
    "UR_11_a = '" + UR_11_a.Text + "', " +
    "UR_12 = '" + var_UR_12 + "', " +
    "UR_12_a = '" + UR_12_a.Text + "', " +
    "UR_13 = '" + var_UR_13 + "', " +
    "UR_13_a = '" + UR_13_a.Text + "', " +
    "UR_14 = '" + var_UR_14 + "', " +
    "UR_14_a = '" + UR_14_a.Text + "', " +
    "UR_15 = '" + var_UR_15 + "', " +
    "UR_15_a = '" + UR_15_a.Text + "', " +
    "UR_16 = '" + var_UR_16 + "', " +
    "UR_16_a = '" + UR_16_a.Text + "', " +
    "UR_17 = '" + var_UR_17 + "', " +
    "UR_17_a = '" + UR_17_a.Text + "', " +
    "UR_18 = '" + var_UR_18 + "', " +
    "UR_18_a = '" + UR_18_a.Text + "', " +
    "UR_19 = '" + var_UR_19 + "', " +
    "UR_19_a = '" + UR_19_a.Text + "', " +
    "UR_20 = '" + var_UR_20 + "', " +
    "UR_20_a = '" + UR_20_a.Text + "', " +
    "UR_21 = '" + var_UR_21 + "', " +
    "UR_21_a = '" + UR_21_a.Text + "', " +
    "uc_01a = '" + var_uc_01a + "', " +
    "uc_02a = '" + var_uc_02a + "', " +
    "uc_02a_a = '" + uc_02a_a.Text + "', " +
    "uc_02b = '" + var_uc_02b + "', " +
    "uc_03a = '" + var_uc_03a + "', " +
    "uc_03a_a = '" + uc_03a_a.Text + "', " +
    "uc_03b = '" + var_uc_03b + "', " +
    "uc_04a = '" + var_uc_04a + "', " +
    "uc_04a_a = '" + uc_04a_a.Text + "', " +
    "uc_04b = '" + var_uc_04b + "', " +
    "uc_05a = '" + var_uc_05a + "', " +
    "uc_05a_a = '" + uc_05a_a.Text + "', " +
    "uc_05b = '" + var_uc_05b + "', " +
    "uc_06a = '" + var_uc_06a + "', " +
    "uc_06a_a = '" + uc_06a_a.Text + "', " +
    "uc_06b = '" + var_uc_06b + "', " +
    "uc_07a = '" + var_uc_07a + "', " +
    "uc_07a_a = '" + uc_07a_a.Text + "', " +
    "uc_07b = '" + var_uc_07b + "', " +
    "uc_08a = '" + var_uc_08a + "', " +
    "uc_08a_a = '" + uc_08a_a.Text + "', " +
    "uc_08b = '" + var_uc_08b + "', " +
    "uc_09a = '" + var_uc_09a + "', " +
    "uc_09a_a = '" + uc_09a_a.Text + "', " +
    "uc_09b = '" + var_uc_09b + "', " +
    "uc_10a = '" + var_uc_10a + "', " +
    "uc_10a_a = '" + uc_10a_a.Text + "', " +
    "uc_10b = '" + var_uc_10b + "', " +
    "uc_11a = '" + var_uc_11a + "', " +
    "uc_11a_a = '" + uc_11a_a.Text + "', " +
    "uc_11b = '" + var_uc_11b + "', " +
    "uc_12a = '" + var_uc_12a + "', " +
    "uc_12a_a = '" + uc_12a_a.Text + "', " +
    "uc_12b = '" + var_uc_12b + "', " +
    "uc_13a = '" + var_uc_13a + "', " +
    "uc_13a_a = '" + uc_13a_a.Text + "', " +
    "uc_13b = '" + var_uc_13b + "', " +
    "uc_14a = '" + var_uc_14a + "', " +
    "uc_14a_a = '" + uc_14a_a.Text + "', " +
    "uc_14b = '" + var_uc_14b + "', " +
    "uc_15a = '" + var_uc_15a + "', " +
    "uc_15a_a = '" + uc_15a_a.Text + "', " +
    "uc_15b = '" + var_uc_15b + "', " +
    "uc_16a = '" + var_uc_16a + "', " +
    "uc_16a_a = '" + uc_16a_a.Text + "', " +
    "uc_16b = '" + var_uc_16b + "', " +
    "uc_17a = '" + var_uc_17a + "', " +
    "uc_17a_a = '" + uc_17a_a.Text + "', " +
    "uc_17b = '" + var_uc_17b + "', " +
    "uc_18a = '" + var_uc_18a + "', " +
    "uc_18a_a = '" + uc_18a_a.Text + "', " +
    "uc_18b = '" + var_uc_18b + "', " +
    "uc_19a = '" + var_uc_19a + "', " +
    "uc_19a_a = '" + uc_19a_a.Text + "', " +
    "uc_19b = '" + var_uc_19b + "', " +
    "uc_20a = '" + var_uc_20a + "', " +
    "uc_20a_a = '" + uc_20a_a.Text + "', " +
    "uc_20b = '" + var_uc_20b + "', " +
    "uc_21a = '" + var_uc_21a + "', " +
    "uc_21a_a = '" + uc_21a_a.Text + "', " +
    "uc_21b = '" + var_uc_21b + "', " +
    "uc_22a = '" + var_uc_22a + "', " +
    "uc_22a_a = '" + uc_22a_a.Text + "', " +
    "uc_22b = '" + var_uc_22b + "', " +
    "uc_23a = '" + var_uc_23a + "', " +
    "uc_23a_a = '" + uc_23a_a.Text + "', " +
    "uc_23b = '" + var_uc_23b + "', " +
    "uc_24a = '" + var_uc_24a + "', " +
    "uc_24a_a = '" + uc_24a_a.Text + "', " +
    "uc_24b = '" + var_uc_24b + "', " +
    "uc_25a = '" + var_uc_25a + "', " +
    "uc_25a_a = '" + uc_25a_a.Text + "', " +
    "uc_25b = '" + var_uc_25b + "', " +
    "uc_26a = '" + var_uc_26a + "', " +
    "uc_26a_a = '" + uc_26a_a.Text + "', " +
    "uc_26b = '" + var_uc_26b + "', " +
    "uc_27a = '" + var_uc_27a + "', " +
    "uc_27a_a = '" + uc_27a_a.Text + "', " +
    "uc_27b = '" + var_uc_27b + "', " +
    "uc_28a = '" + var_uc_28a + "', " +
    "uc_28a_a = '" + uc_28a_a.Text + "', " +
    "uc_28b = '" + var_uc_28b + "', " +
    "uc_29a = '" + var_uc_29a + "', " +
    "uc_29a_a = '" + uc_29a_a.Text + "', " +
    "uc_29b = '" + var_uc_29b + "', " +
    "uc_30a = '" + var_uc_30a + "', " +
    "uc_30a_a = '" + uc_30a_a.Text + "', " +
    "uc_30b = '" + var_uc_30b + "', " +
    "uc_31a = '" + var_uc_31a + "', " +
    "uc_31a_a = '" + uc_31a_a.Text + "', " +
    "uc_31b = '" + var_uc_31b + "', " +
    "uc_32a = '" + var_uc_32a + "', " +
    "uc_32a_a = '" + uc_32a_a.Text + "', " +
    "uc_32b = '" + var_uc_32b + "', " +
    "uc_33a = '" + var_uc_33a + "', " +
    "uc_33a_a = '" + uc_33a_a.Text + "', " +
    "uc_33b = '" + var_uc_33b + "', " +
    "uc_34a = '" + var_uc_34a + "', " +
    "uc_34a_a = '" + uc_34a_a.Text + "', " +
    "uc_34b = '" + var_uc_34b + "', " +
    "uc_35a = '" + var_uc_35a + "', " +
    "uc_35a_a = '" + uc_35a_a.Text + "', " +
    "uc_35b = '" + var_uc_35b + "', " +
    "uc_36a = '" + var_uc_36a + "', " +
    "uc_36a_a = '" + uc_36a_a.Text + "', " +
    "uc_36b = '" + var_uc_36b + "', " +
    "uc_37a = '" + var_uc_37a + "', " +
    "uc_37a_a = '" + uc_37a_a.Text + "', " +
    "uc_37b = '" + var_uc_37b + "', " +
    "LA_17 = '" + LA_17.Text + "', " +
    "LA_18 = '" + LA_18.Text + "', " +
    "LA_19 = '" + ddl_BloodCulture.Items[ddl_BloodCulture.SelectedIndex].Text + "', " +
    "LA_20a_b = '" + var_LA_20a_b + "', " +
    "LA_20a_a = '" + LA_20a_a.Text + "', " +
    "LA_20b_a = '" + var_LA_20b_a + "', " +
    "LA_21a_b = '" + var_LA_21a_b + "', " +
    "LA_21a_a = '" + LA_21a_a.Text + "', " +
    "LA_21b_a = '" + var_LA_21b_a + "', " +
    "LA_22a_b = '" + var_LA_22a_b + "', " +
    "LA_22a_a = '" + LA_22a_a.Text + "', " +
    "LA_22b_a = '" + var_LA_22b_a + "', " +
    "LA_23a_b = '" + var_LA_23a_b + "', " +
    "LA_23a_a = '" + LA_23a_a.Text + "', " +
    "LA_23b_a = '" + var_LA_23b_a + "', " +
    "LA_24a_b = '" + var_LA_24a_b + "', " +
    "LA_24a_a = '" + LA_24a_a.Text + "', " +
    "LA_24b_a = '" + var_LA_24b_a + "', " +
    "LA_25a_b = '" + var_LA_25a_b + "', " +
    "LA_25a_a = '" + LA_25a_a.Text + "', " +
    "LA_25b_a = '" + var_LA_25b_a + "', " +
    "LA_26a_b = '" + var_LA_26a_b + "', " +
    "LA_26a_a = '" + LA_26a_a.Text + "', " +
    "LA_26b_a = '" + var_LA_26b_a + "', " +
    "LA_27a_b = '" + var_LA_27a_b + "', " +
    "LA_27a_a = '" + LA_27a_a.Text + "', " +
    "LA_27b_a = '" + var_LA_27b_a + "', " +
    "LA_28a_b = '" + var_LA_28a_b + "', " +
    "LA_28a_a = '" + LA_28a_a.Text + "', " +
    "LA_28b_a = '" + var_LA_28b_a + "', " +
    "LA_29a_b = '" + var_LA_29a_b + "', " +
    "LA_29a_a = '" + LA_29a_a.Text + "', " +
    "LA_29b_a = '" + var_LA_29b_a + "', " +
    "LA_30a_b = '" + var_LA_30a_b + "', " +
    "LA_30a_a = '" + LA_30a_a.Text + "', " +
    "LA_30b_a = '" + var_LA_30b_a + "', " +
    "LA_31a_b = '" + var_LA_31a_b + "', " +
    "LA_31a_a = '" + LA_31a_a.Text + "', " +
    "LA_31b_a = '" + var_LA_31b_a + "', " +
    "LA_32a_b = '" + var_LA_32a_b + "', " +
    "LA_32a_a = '" + LA_32a_a.Text + "', " +
    "LA_32b_a = '" + var_LA_32b_a + "', " +
    "LA_33a_b = '" + var_LA_33a_b + "', " +
    "LA_33a_a = '" + LA_33a_a.Text + "', " +
    "LA_33b_a = '" + var_LA_33b_a + "', " +
    "LA_34a_b = '" + var_LA_34a_b + "', " +
    "LA_34a_a = '" + LA_34a_a.Text + "', " +
    "LA_34b_a = '" + var_LA_34b_a + "', " +
    "LA_35a_b = '" + var_LA_35a_b + "', " +
    "LA_35a_a = '" + LA_35a_a.Text + "', " +
    "LA_35b_a = '" + var_LA_35b_a + "', " +
    "LA_36a_b = '" + var_LA_36a_b + "', " +
    "LA_36a_a = '" + LA_36a_a.Text + "', " +
    "LA_36b_a = '" + var_LA_36b_a + "', " +
    "LA_37a_b = '" + var_LA_37a_b + "', " +
    "LA_37a_a = '" + LA_37a_a.Text + "', " +
    "LA_37b_a = '" + var_LA_37b_a + "', " +
    "LA_38a_b = '" + var_LA_38a_b + "', " +
    "LA_38a_a = '" + LA_38a_a.Text + "', " +
    "LA_38b_a = '" + var_LA_38b_a + "', " +
    "LA_39a_b = '" + var_LA_39a_b + "', " +
    "LA_39a_a = '" + LA_39a_a.Text + "', " +
    "LA_39b_a = '" + var_LA_39b_a + "', " +
    "LA_40a_b = '" + var_LA_40a_b + "', " +
    "LA_40a_a = '" + LA_40a_a.Text + "', " +
    "LA_40b_a = '" + var_LA_40b_a + "', " +
    "LA_41a_b = '" + var_LA_41a_b + "', " +
    "LA_41a_a = '" + LA_41a_a.Text + "', " +
    "LA_41b_a = '" + var_LA_41b_a + "', " +
    "LA_42a_b = '" + var_LA_42a_b + "', " +
    "LA_42a_a = '" + LA_42a_a.Text + "', " +
    "LA_42b_a = '" + var_LA_42b_a + "', " +
    "LA_43a_b = '" + var_LA_43a_b + "', " +
    "LA_43a_a = '" + LA_43a_a.Text + "', " +
    "LA_43b_a = '" + var_LA_43b_a + "', " +
    "LA_44a_b = '" + var_LA_44a_b + "', " +
    "LA_44a_a = '" + LA_44a_a.Text + "', " +
    "LA_44b_a = '" + var_LA_44b_a + "', " +
    "LA_45a_b = '" + var_LA_45a_b + "', " +
    "LA_45a_a = '" + LA_45a_a.Text + "', " +
    "LA_45b_a = '" + var_LA_45b_a + "', " +
    "LA_46a_b = '" + var_LA_46a_b + "', " +
    "LA_46a_a = '" + LA_46a_a.Text + "', " +
    "LA_46b_a = '" + var_LA_46b_a + "', " +
    "LA_47a_b = '" + var_LA_47a_b + "', " +
    "LA_47a_a = '" + LA_47a_a.Text + "', " +
    "LA_47b_a = '" + var_LA_47b_a + "', " +
    "LA_48a_b = '" + var_LA_48a_b + "', " +
    "LA_48a_a = '" + LA_48a_a.Text + "', " +
    "LA_48b_a = '" + var_LA_48b_a + "', " +
    "LA_49a_b = '" + var_LA_49a_b + "', " +
    "LA_49a_a = '" + LA_49a_a.Text + "', " +
    "LA_49b_a = '" + var_LA_49b_a + "', " +
    "LA_50a_b = '" + var_LA_50a_b + "', " +
    "LA_50a_a = '" + LA_50a_a.Text + "', " +
    "LA_50b_a = '" + var_LA_50b_a + "', " +
    "LA_51a_b = '" + var_LA_51a_b + "', " +
    "LA_51a_a = '" + LA_51a_a.Text + "', " +
    "LA_51b_a = '" + var_LA_51b_a + "', " +
    "LA_52a_b = '" + var_LA_52a_b + "', " +
    "LA_52a_a = '" + LA_52a_a.Text + "', " +
    "LA_52b_a = '" + var_LA_52b_a + "', " +
    "uc_01_ca = '" + uc_01_ca.Text + "', " +
    "UR_04a_a = '" + UR_04a_a.Text + "', " +
    "UR_04a = '" + var_UR_04a + "', " +
    "ProvisionalResult = '" + ProvisionalResult.Text + "', " +
    "rdo_BloodCulture = '" + var_BloodCulture + "', " +
    "rdo_BloodCulture_Multiple = '" + var_BloodCulture_Multiple + "', " +
    "ddl_BloodCulture = '" + ddl_BloodCulture.SelectedIndex + "' where id='" + ViewState["id"] + "'";

                }



                msg1 = obj_op.ExecuteNonQuery_Message_Qry(qry1);


                if (string.IsNullOrEmpty(msg1))
                {
                    UpdateFormStatus(formstatus);

                    string message = "alert('Record saved successfully');window.location.href='sample_recv.aspx'";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);


                    string qry = "";

                    SqlCommand cmd = null;
                    SqlDataAdapter da = null;
                    DataTable dt = null;

                    SqlCommand cmd_select = null;
                    SqlDataAdapter da_select = null;
                    DataTable dt_select = null;

                    int sno = 0;

                    qry = "delete from tblorganism where screeningID = '" + la_sno.Text + "'";
                    cmd_select = new SqlCommand(qry, cn.cn);
                    da_select = new SqlDataAdapter(cmd_select);
                    dt_select = new DataTable();
                    da_select.Fill(dt_select);


                    for (int a = 0; a <= dg_BloodCulture.Rows.Count - 1; a++)
                    {
                        sno += 1;

                        qry = "insert into tblorganism(sno, screeningID, organismName, comment) values('" + sno + "', '" + la_sno.Text + "', '" + dt_bloodculture.Rows[a].ItemArray[1] + "', '" + dt_bloodculture.Rows[a].ItemArray[2] + "')";

                        cmd = new SqlCommand(qry, cn.cn);
                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                    }

                    dt_bloodculture = null;

                }
                else
                {
                    string message = "alert('" + msg1.Replace("'", "") + "');";
                    message = "alert('" + msg1.Replace("\"", "") + "');";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
                }


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


    private void SaveData(string formstatus)
    {
        CDBOperations obj_op = new CDBOperations();

        string var_LF_01 = "-1";
        string var_LF_02 = "-1";
        string var_LF_03 = "-1";
        string var_LF_04 = "-1";
        string var_LF_05 = "-1";
        string var_LF_06 = "-1";
        string var_LF_07 = "-1";


        string var_RF_01 = "-1";
        string var_RF_02 = "-1";
        string var_RF_03 = "-1";
        string var_RF_04 = "-1";


        string var_SE_01 = "-1";
        string var_SE_02 = "-1";
        string var_SE_03 = "-1";
        string var_SE_04 = "-1";


        string var_CS_01 = "-1";
        string var_CS_02 = "-1";
        string var_CS_03 = "-1";
        string var_CS_04 = "-1";
        string var_CS_05 = "-1";
        string var_CS_06 = "-1";
        string var_CS_07 = "-1";
        string var_CS_08 = "-1";
        string var_CS_09 = "-1";
        string var_CS_10 = "-1";


        string var_UR_01 = "-1";
        string var_UR_02 = "-1";
        string var_UR_03 = "-1";
        string var_UR_04 = "-1";
        string var_UR_04a = "-1";
        string var_UR_05 = "-1";
        string var_UR_06 = "-1";
        string var_UR_07 = "-1";
        string var_UR_08 = "-1";
        string var_UR_10 = "-1";
        string var_UR_11 = "-1";
        string var_UR_12 = "-1";
        string var_UR_13 = "-1";
        string var_UR_14 = "-1";
        string var_UR_15 = "-1";
        string var_UR_16 = "-1";
        string var_UR_17 = "-1";
        string var_UR_18 = "-1";
        string var_UR_19 = "-1";
        string var_UR_20 = "-1";
        string var_UR_21 = "-1";

        string var_uc_01a = "-1";


        string var_uc_02a = "-1";
        string var_uc_03a = "-1";
        string var_uc_04a = "-1";
        string var_uc_05a = "-1";
        string var_uc_06a = "-1";
        string var_uc_07a = "-1";
        string var_uc_08a = "-1";
        string var_uc_09a = "-1";
        string var_uc_10a = "-1";
        string var_uc_11a = "-1";
        string var_uc_12a = "-1";
        string var_uc_13a = "-1";
        string var_uc_14a = "-1";
        string var_uc_15a = "-1";
        string var_uc_16a = "-1";
        string var_uc_17a = "-1";
        string var_uc_18a = "-1";
        string var_uc_19a = "-1";
        string var_uc_20a = "-1";
        string var_uc_21a = "-1";
        string var_uc_22a = "-1";
        string var_uc_23a = "-1";
        string var_uc_24a = "-1";
        string var_uc_25a = "-1";
        string var_uc_26a = "-1";
        string var_uc_27a = "-1";
        string var_uc_28a = "-1";
        string var_uc_29a = "-1";
        string var_uc_30a = "-1";
        string var_uc_31a = "-1";
        string var_uc_32a = "-1";
        string var_uc_33a = "-1";
        string var_uc_34a = "-1";
        string var_uc_35a = "-1";
        string var_uc_36a = "-1";
        string var_uc_37a = "-1";



        string var_uc_02b = "-1";
        string var_uc_03b = "-1";
        string var_uc_04b = "-1";
        string var_uc_05b = "-1";
        string var_uc_06b = "-1";
        string var_uc_07b = "-1";
        string var_uc_08b = "-1";
        string var_uc_09b = "-1";
        string var_uc_10b = "-1";
        string var_uc_11b = "-1";
        string var_uc_12b = "-1";
        string var_uc_13b = "-1";
        string var_uc_14b = "-1";
        string var_uc_15b = "-1";
        string var_uc_16b = "-1";
        string var_uc_17b = "-1";
        string var_uc_18b = "-1";
        string var_uc_19b = "-1";
        string var_uc_20b = "-1";
        string var_uc_21b = "-1";
        string var_uc_22b = "-1";
        string var_uc_23b = "-1";
        string var_uc_24b = "-1";
        string var_uc_25b = "-1";
        string var_uc_26b = "-1";
        string var_uc_27b = "-1";
        string var_uc_28b = "-1";
        string var_uc_29b = "-1";
        string var_uc_30b = "-1";
        string var_uc_31b = "-1";
        string var_uc_32b = "-1";
        string var_uc_33b = "-1";
        string var_uc_34b = "-1";
        string var_uc_35b = "-1";
        string var_uc_36b = "-1";
        string var_uc_37b = "-1";



        string var_LA_03_b = "-1";
        string var_LA_04_b = "-1";
        string var_LA_05_b = "-1";
        string var_LA_06_b = "-1";
        string var_LA_07_b = "-1";
        string var_LA_08_b = "-1";
        string var_LA_09_b = "-1";
        string var_LA_10_b = "-1";
        string var_LA_11_b = "-1";
        string var_LA_12_b = "-1";
        string var_LA_13_b = "-1";
        string var_LA_14_b = "-1";
        string var_LA_15_b = "-1";
        string var_LA_16_b = "-1";


        string var_LA_20a_b = "-1";
        string var_LA_21a_b = "-1";
        string var_LA_22a_b = "-1";
        string var_LA_23a_b = "-1";
        string var_LA_24a_b = "-1";
        string var_LA_25a_b = "-1";
        string var_LA_26a_b = "-1";
        string var_LA_27a_b = "-1";
        string var_LA_28a_b = "-1";
        string var_LA_29a_b = "-1";
        string var_LA_30a_b = "-1";
        string var_LA_31a_b = "-1";
        string var_LA_32a_b = "-1";
        string var_LA_33a_b = "-1";
        string var_LA_34a_b = "-1";
        string var_LA_35a_b = "-1";
        string var_LA_36a_b = "-1";
        string var_LA_37a_b = "-1";
        string var_LA_38a_b = "-1";
        string var_LA_39a_b = "-1";
        string var_LA_40a_b = "-1";
        string var_LA_41a_b = "-1";
        string var_LA_42a_b = "-1";
        string var_LA_43a_b = "-1";
        string var_LA_44a_b = "-1";
        string var_LA_45a_b = "-1";
        string var_LA_46a_b = "-1";
        string var_LA_47a_b = "-1";
        string var_LA_48a_b = "-1";
        string var_LA_49a_b = "-1";
        string var_LA_50a_b = "-1";
        string var_LA_51a_b = "-1";
        string var_LA_52a_b = "-1";


        var var_LA_20b_a = "-1";
        var var_LA_21b_a = "-1";
        var var_LA_22b_a = "-1";
        var var_LA_23b_a = "-1";
        var var_LA_24b_a = "-1";
        var var_LA_25b_a = "-1";
        var var_LA_26b_a = "-1";
        var var_LA_27b_a = "-1";
        var var_LA_28b_a = "-1";
        var var_LA_29b_a = "-1";
        var var_LA_30b_a = "-1";
        var var_LA_31b_a = "-1";
        var var_LA_32b_a = "-1";
        var var_LA_33b_a = "-1";
        var var_LA_34b_a = "-1";
        var var_LA_35b_a = "-1";
        var var_LA_36b_a = "-1";
        var var_LA_37b_a = "-1";
        var var_LA_38b_a = "-1";
        var var_LA_39b_a = "-1";
        var var_LA_40b_a = "-1";
        var var_LA_41b_a = "-1";
        var var_LA_42b_a = "-1";
        var var_LA_43b_a = "-1";
        var var_LA_44b_a = "-1";
        var var_LA_45b_a = "-1";
        var var_LA_46b_a = "-1";
        var var_LA_47b_a = "-1";
        var var_LA_48b_a = "-1";
        var var_LA_49b_a = "-1";
        var var_LA_50b_a = "-1";
        var var_LA_51b_a = "-1";
        var var_LA_52b_a = "-1";

        var var_BloodCulture = "";


        try
        {


            if (LA_03_v.Checked == true)
            {
                var_LA_03_b = "";
            }
            else if (LA_03_b.Checked == true)
            {
                var_LA_03_b = "999";
            }
            else if (LA_03_c.Checked == true)
            {
                var_LA_03_b = "888";
            }


            if (LA_04_v.Checked == true)
            {
                var_LA_04_b = "";
            }
            else if (LA_04_b.Checked == true)
            {
                var_LA_04_b = "999";
            }
            else if (LA_04_c.Checked == true)
            {
                var_LA_04_b = "888";
            }


            if (LA_05_v.Checked == true)
            {
                var_LA_05_b = "";
            }
            else if (LA_05_b.Checked == true)
            {
                var_LA_05_b = "999";
            }
            else if (LA_05_c.Checked == true)
            {
                var_LA_05_b = "888";
            }



            if (LA_06_v.Checked == true)
            {
                var_LA_06_b = "";
            }
            else if (LA_06_b.Checked == true)
            {
                var_LA_06_b = "999";
            }
            else if (LA_06_c.Checked == true)
            {
                var_LA_06_b = "888";
            }



            if (LA_07_v.Checked == true)
            {
                var_LA_07_b = "";
            }
            else if (LA_07_b.Checked == true)
            {
                var_LA_07_b = "999";
            }
            else if (LA_07_c.Checked == true)
            {
                var_LA_07_b = "888";
            }



            if (LA_08_v.Checked == true)
            {
                var_LA_08_b = "";
            }
            else if (LA_08_b.Checked == true)
            {
                var_LA_08_b = "999";
            }
            else if (LA_08_c.Checked == true)
            {
                var_LA_08_b = "888";
            }



            if (LA_09_v.Checked == true)
            {
                var_LA_09_b = "";
            }
            else if (LA_09_b.Checked == true)
            {
                var_LA_09_b = "999";
            }
            else if (LA_09_c.Checked == true)
            {
                var_LA_09_b = "999";
            }



            if (LA_10_v.Checked == true)
            {
                var_LA_10_b = "";
            }
            else if (LA_10_b.Checked == true)
            {
                var_LA_10_b = "999";
            }
            else if (LA_10_c.Checked == true)
            {
                var_LA_10_b = "888";
            }



            if (LA_11_b.Checked == true)
            {
                var_LA_11_b = "";
            }
            else if (LA_11_b.Checked == true)
            {
                var_LA_11_b = "999";
            }
            else if (LA_11_c.Checked == true)
            {
                var_LA_11_b = "888";
            }



            if (LA_12_v.Checked == true)
            {
                var_LA_12_b = "";
            }
            else if (LA_12_b.Checked == true)
            {
                var_LA_12_b = "999";
            }
            else if (LA_12_c.Checked == true)
            {
                var_LA_12_b = "888";
            }




            if (LA_13_v.Checked == true)
            {
                var_LA_13_b = "";
            }
            else if (LA_13_b.Checked == true)
            {
                var_LA_13_b = "999";
            }
            else if (LA_13_c.Checked == true)
            {
                var_LA_13_b = "888";
            }



            if (LA_14_v.Checked == true)
            {
                var_LA_14_b = "";
            }
            else if (LA_14_b.Checked == true)
            {
                var_LA_14_b = "999";
            }
            else if (LA_14_c.Checked == true)
            {
                var_LA_14_b = "888";
            }



            if (LA_15_v.Checked == true)
            {
                var_LA_15_b = "";
            }
            else if (LA_15_b.Checked == true)
            {
                var_LA_15_b = "999";
            }
            else if (LA_15_c.Checked == true)
            {
                var_LA_15_b = "888";
            }



            if (LA_16_v.Checked == true)
            {
                var_LA_16_b = "";
            }
            else if (LA_16_b.Checked == true)
            {
                var_LA_16_b = "999";
            }
            else if (LA_16_c.Checked == true)
            {
                var_LA_16_b = "888";
            }




            if (LF_01_v.Checked == true)
            {
                var_LF_01 = "";
            }
            else if (LF_01_b.Checked == true)
            {
                var_LF_01 = "999";
            }
            else if (LF_01_c.Checked == true)
            {
                var_LF_01 = "888";
            }



            if (LF_02_v.Checked == true)
            {
                var_LF_02 = "";
            }
            else if (LF_02_b.Checked == true)
            {
                var_LF_02 = "999";
            }
            else if (LF_02_c.Checked == true)
            {
                var_LF_02 = "888";
            }



            if (LF_03_v.Checked == true)
            {
                var_LF_03 = "";
            }
            else if (LF_03_b.Checked == true)
            {
                var_LF_03 = "999";
            }
            else if (LF_03_c.Checked == true)
            {
                var_LF_03 = "888";
            }



            if (LF_04_v.Checked == true)
            {
                var_LF_04 = "";
            }
            else if (LF_04_b.Checked == true)
            {
                var_LF_04 = "999";
            }
            else if (LF_04_c.Checked == true)
            {
                var_LF_04 = "888";
            }



            if (LF_05_v.Checked == true)
            {
                var_LF_05 = "";
            }
            else if (LF_05_b.Checked == true)
            {
                var_LF_05 = "999";
            }
            else if (LF_05_c.Checked == true)
            {
                var_LF_05 = "888";
            }




            if (LF_06_v.Checked == true)
            {
                var_LF_06 = "";
            }
            else if (LF_06_b.Checked == true)
            {
                var_LF_06 = "999";
            }
            else if (LF_06_c.Checked == true)
            {
                var_LF_06 = "888";
            }



            if (LF_07_v.Checked == true)
            {
                var_LF_07 = "";
            }
            else if (LF_07_b.Checked == true)
            {
                var_LF_07 = "999";
            }
            else if (LF_07_c.Checked == true)
            {
                var_LF_07 = "888";
            }



            if (RF_01_v.Checked == true)
            {
                var_RF_01 = "";
            }
            else if (RF_01_b.Checked == true)
            {
                var_RF_01 = "999";
            }
            else if (RF_01_c.Checked == true)
            {
                var_RF_01 = "888";
            }



            if (RF_02_v.Checked == true)
            {
                var_RF_02 = "";
            }
            else if (RF_02_b.Checked == true)
            {
                var_RF_02 = "999";
            }
            else if (RF_02_c.Checked == true)
            {
                var_RF_02 = "888";
            }



            if (RF_03_v.Checked == true)
            {
                var_RF_03 = "";
            }
            else if (RF_03_b.Checked == true)
            {
                var_RF_03 = "999";
            }
            else if (RF_03_c.Checked == true)
            {
                var_RF_03 = "888";
            }



            if (RF_04_v.Checked == true)
            {
                var_RF_04 = "";
            }
            else if (RF_04_b.Checked == true)
            {
                var_RF_04 = "999";
            }
            else if (RF_04_c.Checked == true)
            {
                var_RF_04 = "888";
            }



            if (SE_01_v.Checked == true)
            {
                var_SE_01 = "";
            }
            else if (SE_01_b.Checked == true)
            {
                var_SE_01 = "999";
            }
            else if (SE_01_c.Checked == true)
            {
                var_SE_01 = "888";
            }



            if (SE_02_v.Checked == true)
            {
                var_SE_02 = "";
            }
            else if (SE_02_b.Checked == true)
            {
                var_SE_02 = "999";
            }
            else if (SE_02_c.Checked == true)
            {
                var_SE_02 = "888";
            }




            if (SE_03_v.Checked == true)
            {
                var_SE_03 = "";
            }
            else if (SE_03_b.Checked == true)
            {
                var_SE_03 = "999";
            }
            else if (SE_03_c.Checked == true)
            {
                var_SE_03 = "888";
            }



            if (SE_04_v.Checked == true)
            {
                var_SE_04 = "";
            }
            else if (SE_04_b.Checked == true)
            {
                var_SE_04 = "999";
            }
            else if (SE_04_c.Checked == true)
            {
                var_SE_04 = "888";
            }



            if (CS_01_v.Checked == true)
            {
                var_CS_01 = "";
            }
            else if (CS_01_b.Checked == true)
            {
                var_CS_01 = "999";
            }
            else if (CS_01_c.Checked == true)
            {
                var_CS_01 = "888";
            }



            if (CS_02_v.Checked == true)
            {
                var_CS_02 = "";
            }
            else if (CS_02_b.Checked == true)
            {
                var_CS_02 = "999";
            }
            else if (CS_02_c.Checked == true)
            {
                var_CS_02 = "888";
            }




            if (CS_03_v.Checked == true)
            {
                var_CS_03 = "";
            }
            else if (CS_03_b.Checked == true)
            {
                var_CS_03 = "999";
            }
            else if (CS_03_c.Checked == true)
            {
                var_CS_03 = "888";
            }



            if (CS_04_v.Checked == true)
            {
                var_CS_04 = "";
            }
            else if (CS_04_b.Checked == true)
            {
                var_CS_04 = "999";
            }
            else if (CS_04_c.Checked == true)
            {
                var_CS_04 = "888";
            }



            if (CS_05_v.Checked == true)
            {
                var_CS_05 = "";
            }
            else if (CS_05_b.Checked == true)
            {
                var_CS_05 = "999";
            }
            else if (CS_05_c.Checked == true)
            {
                var_CS_05 = "888";
            }



            if (CS_06_v.Checked == true)
            {
                var_CS_06 = "";
            }
            else if (CS_06_b.Checked == true)
            {
                var_CS_06 = "999";
            }
            else if (CS_06_c.Checked == true)
            {
                var_CS_06 = "888";
            }



            if (CS_07_v.Checked == true)
            {
                var_CS_07 = "";
            }
            else if (CS_07_b.Checked == true)
            {
                var_CS_07 = "999";
            }
            else if (CS_07_c.Checked == true)
            {
                var_CS_07 = "888";
            }



            if (CS_08_v.Checked == true)
            {
                var_CS_08 = "";
            }
            else if (CS_08_b.Checked == true)
            {
                var_CS_08 = "999";
            }
            else if (CS_08_c.Checked == true)
            {
                var_CS_08 = "888";
            }



            if (CS_09_v.Checked == true)
            {
                var_CS_09 = "";
            }
            else if (CS_09_b.Checked == true)
            {
                var_CS_09 = "999";
            }
            else if (CS_09_c.Checked == true)
            {
                var_CS_09 = "888";
            }



            if (CS_10_v.Checked == true)
            {
                var_CS_10 = "";
            }
            else if (CS_10_b.Checked == true)
            {
                var_CS_10 = "999";
            }
            else if (CS_10_c.Checked == true)
            {
                var_CS_10 = "888";
            }



            if (UR_01_v.Checked == true)
            {
                var_UR_01 = "";
            }
            else if (UR_01_b.Checked == true)
            {
                var_UR_01 = "999";
            }
            else if (UR_01_c.Checked == true)
            {
                var_UR_01 = "888";
            }



            if (UR_02_v.Checked == true)
            {
                var_UR_02 = "";
            }
            else if (UR_02_b.Checked == true)
            {
                var_UR_02 = "999";
            }
            else if (UR_02_c.Checked == true)
            {
                var_UR_02 = "888";
            }



            if (UR_03_v.Checked == true)
            {
                var_UR_03 = "";
            }
            else if (UR_03_b.Checked == true)
            {
                var_UR_03 = "999";
            }
            else if (UR_03_c.Checked == true)
            {
                var_UR_03 = "888";
            }



            if (UR_04_v.Checked == true)
            {
                var_UR_04 = "";
            }
            else if (UR_04_b.Checked == true)
            {
                var_UR_04 = "999";
            }
            else if (UR_04_c.Checked == true)
            {
                var_UR_04 = "888";
            }



            if (UR_04a_v.Checked == true)
            {
                var_UR_04a = "";
            }
            else if (UR_04a_b.Checked == true)
            {
                var_UR_04a = "999";
            }
            else if (UR_04a_c.Checked == true)
            {
                var_UR_04a = "888";
            }




            if (UR_05_v.Checked == true)
            {
                var_UR_05 = "";
            }
            else if (UR_05_b.Checked == true)
            {
                var_UR_05 = "999";
            }
            else if (UR_05_c.Checked == true)
            {
                var_UR_05 = "888";
            }




            if (UR_06_v.Checked == true)
            {
                var_UR_06 = "";
            }
            else if (UR_06_b.Checked == true)
            {
                var_UR_06 = "999";
            }
            else if (UR_06_c.Checked == true)
            {
                var_UR_06 = "888";
            }



            if (UR_07_v.Checked == true)
            {
                var_UR_07 = "";
            }
            else if (UR_07_b.Checked == true)
            {
                var_UR_07 = "999";
            }
            else if (UR_07_c.Checked == true)
            {
                var_UR_07 = "888";
            }



            if (UR_08_v.Checked == true)
            {
                var_UR_08 = "";
            }
            else if (UR_08_b.Checked == true)
            {
                var_UR_08 = "999";
            }
            else if (UR_08_c.Checked == true)
            {
                var_UR_08 = "888";
            }



            if (UR_10_v.Checked == true)
            {
                var_UR_10 = "";
            }
            else if (UR_10_b.Checked == true)
            {
                var_UR_10 = "999";
            }
            else if (UR_10_c.Checked == true)
            {
                var_UR_10 = "888";
            }



            if (UR_11_v.Checked == true)
            {
                var_UR_11 = "";
            }
            else if (UR_11_b.Checked == true)
            {
                var_UR_11 = "999";
            }
            else if (UR_11_c.Checked == true)
            {
                var_UR_11 = "888";
            }



            if (UR_12_v.Checked == true)
            {
                var_UR_12 = "";
            }
            else if (UR_12_b.Checked == true)
            {
                var_UR_12 = "999";
            }
            else if (UR_12_c.Checked == true)
            {
                var_UR_12 = "888";
            }




            if (UR_13_v.Checked == true)
            {
                var_UR_13 = "";
            }
            else if (UR_13_b.Checked == true)
            {
                var_UR_13 = "999";
            }
            else if (UR_13_c.Checked == true)
            {
                var_UR_13 = "888";
            }




            if (UR_14_v.Checked == true)
            {
                var_UR_14 = "";
            }
            else if (UR_14_b.Checked == true)
            {
                var_UR_14 = "999";
            }
            else if (UR_14_c.Checked == true)
            {
                var_UR_14 = "888";
            }




            if (UR_15_v.Checked == true)
            {
                var_UR_15 = "";
            }
            else if (UR_15_b.Checked == true)
            {
                var_UR_15 = "999";
            }
            else if (UR_15_c.Checked == true)
            {
                var_UR_15 = "888";
            }



            if (UR_16_v.Checked == true)
            {
                var_UR_16 = "";
            }
            else if (UR_16_b.Checked == true)
            {
                var_UR_16 = "999";
            }
            else if (UR_16_c.Checked == true)
            {
                var_UR_16 = "888";
            }



            if (UR_17_v.Checked == true)
            {
                var_UR_17 = "";
            }
            else if (UR_17_b.Checked == true)
            {
                var_UR_17 = "999";
            }
            else if (UR_17_c.Checked == true)
            {
                var_UR_17 = "888";
            }



            if (UR_18_v.Checked == true)
            {
                var_UR_18 = "";
            }
            else if (UR_18_b.Checked == true)
            {
                var_UR_18 = "999";
            }
            else if (UR_18_c.Checked == true)
            {
                var_UR_18 = "888";
            }



            if (UR_19_v.Checked == true)
            {
                var_UR_19 = "";
            }
            else if (UR_19_b.Checked == true)
            {
                var_UR_19 = "999";
            }
            else if (UR_19_c.Checked == true)
            {
                var_UR_19 = "888";
            }




            if (UR_20_v.Checked == true)
            {
                var_UR_20 = "";
            }
            else if (UR_20_b.Checked == true)
            {
                var_UR_20 = "999";
            }
            else if (UR_20_c.Checked == true)
            {
                var_UR_20 = "888";
            }



            if (UR_21_v.Checked == true)
            {
                var_UR_21 = "";
            }
            else if (UR_21_b.Checked == true)
            {
                var_UR_21 = "999";
            }
            else if (UR_21_c.Checked == true)
            {
                var_UR_21 = "888";
            }



            if (uc_01_a.Checked == true)
            {
                var_uc_01a = "1";
            }
            else if (uc_01_b.Checked == true)
            {
                var_uc_01a = "2";
            }
            else if (uc_01_c.Checked == true)
            {
                var_uc_01a = "999";
            }



            if (uc_02a_v.Checked == true)
            {
                var_uc_02a = "";
            }
            else if (uc_02a_b.Checked == true)
            {
                var_uc_02a = "999";
            }
            else if (uc_02a_c.Checked == true)
            {
                var_uc_02a = "888";
            }



            if (uc_02b_a.Checked == true)
            {
                var_uc_02b = "1";
            }
            else if (uc_02b_b.Checked == true)
            {
                var_uc_02b = "2";
            }
            else if (uc_02b_c.Checked == true)
            {
                var_uc_02b = "3";
            }



            if (uc_03a_v.Checked == true)
            {
                var_uc_03a = "";
            }
            else if (uc_03a_b.Checked == true)
            {
                var_uc_03a = "999";
            }
            else if (uc_03a_c.Checked == true)
            {
                var_uc_03a = "888";
            }



            if (uc_03b_a.Checked == true)
            {
                var_uc_03b = "1";
            }
            else if (uc_03b_b.Checked == true)
            {
                var_uc_03b = "2";
            }
            else if (uc_03b_c.Checked == true)
            {
                var_uc_03b = "3";
            }




            if (uc_04a_v.Checked == true)
            {
                var_uc_04a = "";
            }
            else if (uc_04a_b.Checked == true)
            {
                var_uc_04a = "999";
            }
            else if (uc_04a_c.Checked == true)
            {
                var_uc_04a = "888";
            }



            if (uc_04b_a.Checked == true)
            {
                var_uc_04b = "1";
            }
            else if (uc_04b_b.Checked == true)
            {
                var_uc_04b = "2";
            }
            else if (uc_04b_c.Checked == true)
            {
                var_uc_04b = "3";
            }



            if (uc_05a_v.Checked == true)
            {
                var_uc_05a = "";
            }
            else if (uc_05a_b.Checked == true)
            {
                var_uc_05a = "999";
            }
            else if (uc_05a_c.Checked == true)
            {
                var_uc_05a = "888";
            }



            if (uc_05b_a.Checked == true)
            {
                var_uc_05b = "1";
            }
            else if (uc_05b_b.Checked == true)
            {
                var_uc_05b = "2";
            }
            else if (uc_05b_c.Checked == true)
            {
                var_uc_05b = "3";
            }




            if (uc_06a_v.Checked == true)
            {
                var_uc_06a = "";
            }
            else if (uc_06a_b.Checked == true)
            {
                var_uc_06a = "999";
            }
            else if (uc_06a_c.Checked == true)
            {
                var_uc_06a = "888";
            }



            if (uc_06b_a.Checked == true)
            {
                var_uc_06b = "1";
            }
            else if (uc_06b_b.Checked == true)
            {
                var_uc_06b = "2";
            }
            else if (uc_06b_c.Checked == true)
            {
                var_uc_06b = "3";
            }



            if (uc_07a_v.Checked == true)
            {
                var_uc_07a = "";
            }
            else if (uc_07a_b.Checked == true)
            {
                var_uc_07a = "999";
            }
            else if (uc_07a_c.Checked == true)
            {
                var_uc_07a = "888";
            }



            if (uc_07b_a.Checked == true)
            {
                var_uc_07b = "1";
            }
            else if (uc_07b_b.Checked == true)
            {
                var_uc_07b = "2";
            }
            else if (uc_07b_c.Checked == true)
            {
                var_uc_07b = "3";
            }



            if (uc_08a_v.Checked == true)
            {
                var_uc_08a = "";
            }
            else if (uc_08a_b.Checked == true)
            {
                var_uc_08a = "999";
            }
            else if (uc_08a_c.Checked == true)
            {
                var_uc_08a = "888";
            }



            if (uc_08b_a.Checked == true)
            {
                var_uc_08b = "1";
            }
            else if (uc_08b_b.Checked == true)
            {
                var_uc_08b = "2";
            }
            else if (uc_08b_c.Checked == true)
            {
                var_uc_08b = "3";
            }




            if (uc_09a_v.Checked == true)
            {
                var_uc_09a = "";
            }
            else if (uc_09a_b.Checked == true)
            {
                var_uc_09a = "999";
            }
            else if (uc_09a_c.Checked == true)
            {
                var_uc_09a = "888";
            }



            if (uc_09b_a.Checked == true)
            {
                var_uc_09b = "1";
            }
            else if (uc_09b_b.Checked == true)
            {
                var_uc_09b = "2";
            }
            else if (uc_09b_c.Checked == true)
            {
                var_uc_09b = "3";
            }




            if (uc_10a_v.Checked == true)
            {
                var_uc_10a = "";
            }
            else if (uc_10a_b.Checked == true)
            {
                var_uc_10a = "999";
            }
            else if (uc_10a_c.Checked == true)
            {
                var_uc_10a = "888";
            }



            if (uc_10b_a.Checked == true)
            {
                var_uc_10b = "1";
            }
            else if (uc_10b_b.Checked == true)
            {
                var_uc_10b = "2";
            }
            else if (uc_10b_c.Checked == true)
            {
                var_uc_10b = "3";
            }



            if (uc_11a_v.Checked == true)
            {
                var_uc_11a = "";
            }
            else if (uc_11a_b.Checked == true)
            {
                var_uc_11a = "999";
            }
            else if (uc_11a_c.Checked == true)
            {
                var_uc_11a = "888";
            }



            if (uc_11b_a.Checked == true)
            {
                var_uc_11b = "1";
            }
            else if (uc_11b_b.Checked == true)
            {
                var_uc_11b = "2";
            }
            else if (uc_11b_c.Checked == true)
            {
                var_uc_11b = "3";
            }




            if (uc_12a_v.Checked == true)
            {
                var_uc_12a = "";
            }
            else if (uc_12a_b.Checked == true)
            {
                var_uc_12a = "999";
            }
            else if (uc_12a_c.Checked == true)
            {
                var_uc_12a = "888";
            }



            if (uc_12b_a.Checked == true)
            {
                var_uc_12b = "1";
            }
            else if (uc_12b_b.Checked == true)
            {
                var_uc_12b = "2";
            }
            else if (uc_12b_c.Checked == true)
            {
                var_uc_12b = "3";
            }



            if (uc_13a_v.Checked == true)
            {
                var_uc_13a = "";
            }
            else if (uc_13a_b.Checked == true)
            {
                var_uc_13a = "999";
            }
            else if (uc_13a_c.Checked == true)
            {
                var_uc_13a = "888";
            }



            if (uc_13b_a.Checked == true)
            {
                var_uc_13b = "1";
            }
            else if (uc_13b_b.Checked == true)
            {
                var_uc_13b = "2";
            }
            else if (uc_13b_c.Checked == true)
            {
                var_uc_13b = "3";
            }




            if (uc_14a_v.Checked == true)
            {
                var_uc_14a = "";
            }
            else if (uc_14a_b.Checked == true)
            {
                var_uc_14a = "999";
            }
            else if (uc_14a_c.Checked == true)
            {
                var_uc_14a = "888";
            }



            if (uc_14b_a.Checked == true)
            {
                var_uc_14b = "1";
            }
            else if (uc_14b_b.Checked == true)
            {
                var_uc_14b = "2";
            }
            else if (uc_14b_c.Checked == true)
            {
                var_uc_14b = "3";
            }




            if (uc_15a_v.Checked == true)
            {
                var_uc_15a = "";
            }
            else if (uc_15a_b.Checked == true)
            {
                var_uc_15a = "999";
            }
            else if (uc_15a_c.Checked == true)
            {
                var_uc_15a = "888";
            }



            if (uc_15b_a.Checked == true)
            {
                var_uc_15b = "1";
            }
            else if (uc_15b_b.Checked == true)
            {
                var_uc_15b = "2";
            }
            else if (uc_15b_c.Checked == true)
            {
                var_uc_15b = "3";
            }




            if (uc_16a_v.Checked == true)
            {
                var_uc_16a = "";
            }
            else if (uc_16a_b.Checked == true)
            {
                var_uc_16a = "999";
            }
            else if (uc_16a_c.Checked == true)
            {
                var_uc_16a = "888";
            }



            if (uc_16b_a.Checked == true)
            {
                var_uc_16b = "1";
            }
            else if (uc_16b_b.Checked == true)
            {
                var_uc_16b = "2";
            }
            else if (uc_16b_c.Checked == true)
            {
                var_uc_16b = "3";
            }





            if (uc_17a_v.Checked == true)
            {
                var_uc_17a = "";
            }
            else if (uc_17a_b.Checked == true)
            {
                var_uc_17a = "999";
            }
            else if (uc_17a_c.Checked == true)
            {
                var_uc_17a = "888";
            }



            if (uc_17b_a.Checked == true)
            {
                var_uc_17b = "1";
            }
            else if (uc_17b_b.Checked == true)
            {
                var_uc_17b = "2";
            }
            else if (uc_17b_c.Checked == true)
            {
                var_uc_17b = "3";
            }




            if (uc_18a_v.Checked == true)
            {
                var_uc_18a = "";
            }
            else if (uc_18a_b.Checked == true)
            {
                var_uc_18a = "999";
            }
            else if (uc_18a_c.Checked == true)
            {
                var_uc_18a = "888";
            }



            if (uc_18b_a.Checked == true)
            {
                var_uc_18b = "1";
            }
            else if (uc_18b_b.Checked == true)
            {
                var_uc_18b = "2";
            }
            else if (uc_18b_c.Checked == true)
            {
                var_uc_18b = "3";
            }




            if (uc_19a_v.Checked == true)
            {
                var_uc_19a = "";
            }
            else if (uc_19a_b.Checked == true)
            {
                var_uc_19a = "999";
            }
            else if (uc_19a_c.Checked == true)
            {
                var_uc_19a = "888";
            }



            if (uc_19b_a.Checked == true)
            {
                var_uc_19b = "1";
            }
            else if (uc_19b_b.Checked == true)
            {
                var_uc_19b = "2";
            }
            else if (uc_19b_c.Checked == true)
            {
                var_uc_19b = "3";
            }




            if (uc_20a_v.Checked == true)
            {
                var_uc_20a = "";
            }
            else if (uc_20a_b.Checked == true)
            {
                var_uc_20a = "999";
            }
            else if (uc_20a_c.Checked == true)
            {
                var_uc_20a = "888";
            }



            if (uc_20b_a.Checked == true)
            {
                var_uc_20b = "1";
            }
            else if (uc_20b_b.Checked == true)
            {
                var_uc_20b = "2";
            }
            else if (uc_20b_c.Checked == true)
            {
                var_uc_20b = "3";
            }




            if (uc_21a_v.Checked == true)
            {
                var_uc_21a = "";
            }
            else if (uc_21a_b.Checked == true)
            {
                var_uc_21a = "999";
            }
            else if (uc_21a_c.Checked == true)
            {
                var_uc_21a = "888";
            }



            if (uc_21b_a.Checked == true)
            {
                var_uc_21b = "1";
            }
            else if (uc_21b_b.Checked == true)
            {
                var_uc_21b = "2";
            }
            else if (uc_21b_c.Checked == true)
            {
                var_uc_21b = "3";
            }




            if (uc_22a_v.Checked == true)
            {
                var_uc_22a = "";
            }
            else if (uc_22a_b.Checked == true)
            {
                var_uc_22a = "999";
            }
            else if (uc_22a_c.Checked == true)
            {
                var_uc_22a = "888";
            }



            if (uc_22b_a.Checked == true)
            {
                var_uc_22b = "1";
            }
            else if (uc_22b_b.Checked == true)
            {
                var_uc_22b = "2";
            }
            else if (uc_22b_c.Checked == true)
            {
                var_uc_22b = "3";
            }




            if (uc_23a_v.Checked == true)
            {
                var_uc_23a = "";
            }
            else if (uc_23a_b.Checked == true)
            {
                var_uc_23a = "999";
            }
            else if (uc_23a_c.Checked == true)
            {
                var_uc_23a = "888";
            }



            if (uc_23b_a.Checked == true)
            {
                var_uc_23b = "1";
            }
            else if (uc_23b_b.Checked == true)
            {
                var_uc_23b = "2";
            }
            else if (uc_23b_c.Checked == true)
            {
                var_uc_23b = "3";
            }




            if (uc_24a_v.Checked == true)
            {
                var_uc_24a = "";
            }
            else if (uc_24a_b.Checked == true)
            {
                var_uc_24a = "999";
            }
            else if (uc_24a_c.Checked == true)
            {
                var_uc_24a = "888";
            }



            if (uc_24b_a.Checked == true)
            {
                var_uc_24b = "1";
            }
            else if (uc_24b_b.Checked == true)
            {
                var_uc_24b = "2";
            }
            else if (uc_24b_c.Checked == true)
            {
                var_uc_24b = "3";
            }




            if (uc_25a_v.Checked == true)
            {
                var_uc_25a = "";
            }
            else if (uc_25a_b.Checked == true)
            {
                var_uc_25a = "999";
            }
            else if (uc_25a_c.Checked == true)
            {
                var_uc_25a = "888";
            }



            if (uc_25b_a.Checked == true)
            {
                var_uc_25b = "1";
            }
            else if (uc_25b_b.Checked == true)
            {
                var_uc_25b = "2";
            }
            else if (uc_25b_c.Checked == true)
            {
                var_uc_25b = "3";
            }




            if (uc_26a_v.Checked == true)
            {
                var_uc_26a = "";
            }
            else if (uc_26a_b.Checked == true)
            {
                var_uc_26a = "999";
            }
            else if (uc_26a_c.Checked == true)
            {
                var_uc_26a = "888";
            }



            if (uc_26b_a.Checked == true)
            {
                var_uc_26b = "1";
            }
            else if (uc_26b_b.Checked == true)
            {
                var_uc_26b = "2";
            }
            else if (uc_26b_c.Checked == true)
            {
                var_uc_26b = "3";
            }




            if (uc_27a_v.Checked == true)
            {
                var_uc_27a = "";
            }
            else if (uc_27a_b.Checked == true)
            {
                var_uc_27a = "999";
            }
            else if (uc_27a_c.Checked == true)
            {
                var_uc_27a = "888";
            }



            if (uc_27b_a.Checked == true)
            {
                var_uc_27b = "1";
            }
            else if (uc_27b_b.Checked == true)
            {
                var_uc_27b = "2";
            }
            else if (uc_27b_c.Checked == true)
            {
                var_uc_27b = "3";
            }




            if (uc_28a_v.Checked == true)
            {
                var_uc_28a = "";
            }
            else if (uc_28a_b.Checked == true)
            {
                var_uc_28a = "999";
            }
            else if (uc_28a_c.Checked == true)
            {
                var_uc_28a = "888";
            }



            if (uc_28b_a.Checked == true)
            {
                var_uc_28b = "1";
            }
            else if (uc_28b_b.Checked == true)
            {
                var_uc_28b = "2";
            }
            else if (uc_28b_c.Checked == true)
            {
                var_uc_28b = "3";
            }




            if (uc_29a_v.Checked == true)
            {
                var_uc_29a = "";
            }
            else if (uc_29a_b.Checked == true)
            {
                var_uc_29a = "999";
            }
            else if (uc_29a_c.Checked == true)
            {
                var_uc_29a = "888";
            }



            if (uc_29b_a.Checked == true)
            {
                var_uc_29b = "1";
            }
            else if (uc_29b_b.Checked == true)
            {
                var_uc_29b = "2";
            }
            else if (uc_29b_c.Checked == true)
            {
                var_uc_29b = "3";
            }




            if (uc_30a_v.Checked == true)
            {
                var_uc_30a = "";
            }
            else if (uc_30a_b.Checked == true)
            {
                var_uc_30a = "999";
            }
            else if (uc_30a_c.Checked == true)
            {
                var_uc_30a = "888";
            }



            if (uc_30b_a.Checked == true)
            {
                var_uc_30b = "1";
            }
            else if (uc_30b_b.Checked == true)
            {
                var_uc_30b = "2";
            }
            else if (uc_30b_c.Checked == true)
            {
                var_uc_30b = "3";
            }



            if (uc_31a_v.Checked == true)
            {
                var_uc_31a = "";
            }
            else if (uc_31a_b.Checked == true)
            {
                var_uc_31a = "999";
            }
            else if (uc_31a_c.Checked == true)
            {
                var_uc_31a = "888";
            }



            if (uc_31b_a.Checked == true)
            {
                var_uc_31b = "1";
            }
            else if (uc_31b_b.Checked == true)
            {
                var_uc_31b = "2";
            }
            else if (uc_31b_c.Checked == true)
            {
                var_uc_31b = "3";
            }



            if (uc_32a_v.Checked == true)
            {
                var_uc_32a = "";
            }
            else if (uc_32a_b.Checked == true)
            {
                var_uc_32a = "999";
            }
            else if (uc_32a_c.Checked == true)
            {
                var_uc_32a = "888";
            }



            if (uc_32b_a.Checked == true)
            {
                var_uc_32b = "1";
            }
            else if (uc_32b_b.Checked == true)
            {
                var_uc_32b = "2";
            }
            else if (uc_32b_c.Checked == true)
            {
                var_uc_32b = "3";
            }




            if (uc_33a_v.Checked == true)
            {
                var_uc_33a = "";
            }
            else if (uc_33a_b.Checked == true)
            {
                var_uc_33a = "999";
            }
            else if (uc_33a_c.Checked == true)
            {
                var_uc_33a = "888";
            }



            if (uc_33b_a.Checked == true)
            {
                var_uc_33b = "1";
            }
            else if (uc_33b_b.Checked == true)
            {
                var_uc_33b = "2";
            }
            else if (uc_33b_c.Checked == true)
            {
                var_uc_33b = "3";
            }



            if (uc_34a_v.Checked == true)
            {
                var_uc_34a = "";
            }
            else if (uc_34a_b.Checked == true)
            {
                var_uc_34a = "999";
            }
            else if (uc_34a_c.Checked == true)
            {
                var_uc_34a = "888";
            }



            if (uc_34b_a.Checked == true)
            {
                var_uc_34b = "1";
            }
            else if (uc_34b_b.Checked == true)
            {
                var_uc_34b = "2";
            }
            else if (uc_34b_c.Checked == true)
            {
                var_uc_34b = "3";
            }




            if (uc_35a_v.Checked == true)
            {
                var_uc_35a = "";
            }
            else if (uc_35a_b.Checked == true)
            {
                var_uc_35a = "999";
            }
            else if (uc_35a_c.Checked == true)
            {
                var_uc_35a = "888";
            }



            if (uc_35b_a.Checked == true)
            {
                var_uc_35b = "1";
            }
            else if (uc_35b_b.Checked == true)
            {
                var_uc_35b = "2";
            }
            else if (uc_35b_c.Checked == true)
            {
                var_uc_35b = "3";
            }





            if (uc_36a_v.Checked == true)
            {
                var_uc_36a = "";
            }
            else if (uc_36a_b.Checked == true)
            {
                var_uc_36a = "999";
            }
            else if (uc_36a_c.Checked == true)
            {
                var_uc_36a = "888";
            }



            if (uc_36b_a.Checked == true)
            {
                var_uc_36b = "1";
            }
            else if (uc_36b_b.Checked == true)
            {
                var_uc_36b = "2";
            }
            else if (uc_36b_c.Checked == true)
            {
                var_uc_36b = "3";
            }





            if (uc_37a_v.Checked == true)
            {
                var_uc_37a = "";
            }
            else if (uc_37a_b.Checked == true)
            {
                var_uc_37a = "999";
            }
            else if (uc_37a_c.Checked == true)
            {
                var_uc_37a = "888";
            }



            if (uc_37b_a.Checked == true)
            {
                var_uc_37b = "1";
            }
            else if (uc_37b_b.Checked == true)
            {
                var_uc_37b = "2";
            }
            else if (uc_37b_c.Checked == true)
            {
                var_uc_37b = "3";
            }






            if (LA_20a_v.Checked == true)
            {
                var_LA_20a_b = "";
            }
            else if (LA_20a_b.Checked == true)
            {
                var_LA_20a_b = "999";
            }
            else if (LA_20a_c.Checked == true)
            {
                var_LA_20a_b = "888";
            }



            if (LA_20b_a.Checked == true)
            {
                var_LA_20b_a = "1";
            }
            else if (LA_20b_b.Checked == true)
            {
                var_LA_20b_a = "2";
            }
            else if (LA_20b_c.Checked == true)
            {
                var_LA_20b_a = "3";
            }




            if (LA_21a_v.Checked == true)
            {
                var_LA_21a_b = "";
            }
            else if (LA_21a_b.Checked == true)
            {
                var_LA_21a_b = "999";
            }
            else if (LA_21a_c.Checked == true)
            {
                var_LA_21a_b = "888";
            }



            if (LA_21b_a.Checked == true)
            {
                var_LA_21b_a = "1";
            }
            else if (LA_21b_b.Checked == true)
            {
                var_LA_21b_a = "2";
            }
            else if (LA_21b_c.Checked == true)
            {
                var_LA_21b_a = "3";
            }



            if (LA_22a_v.Checked == true)
            {
                var_LA_22a_b = "";
            }
            else if (LA_22a_b.Checked == true)
            {
                var_LA_22a_b = "999";
            }
            else if (LA_22a_c.Checked == true)
            {
                var_LA_22a_b = "888";
            }



            if (LA_22b_a.Checked == true)
            {
                var_LA_22b_a = "1";
            }
            else if (LA_22b_b.Checked == true)
            {
                var_LA_22b_a = "2";
            }
            else if (LA_22b_c.Checked == true)
            {
                var_LA_22b_a = "3";
            }



            if (LA_23a_v.Checked == true)
            {
                var_LA_23a_b = "";
            }
            else if (LA_23a_b.Checked == true)
            {
                var_LA_23a_b = "999";
            }
            else if (LA_23a_c.Checked == true)
            {
                var_LA_23a_b = "888";
            }



            if (LA_23b_a.Checked == true)
            {
                var_LA_23b_a = "1";
            }
            else if (LA_23b_b.Checked == true)
            {
                var_LA_23b_a = "2";
            }
            else if (LA_23b_c.Checked == true)
            {
                var_LA_23b_a = "3";
            }



            if (LA_24a_v.Checked == true)
            {
                var_LA_24a_b = "";
            }
            else if (LA_24a_b.Checked == true)
            {
                var_LA_24a_b = "999";
            }
            else if (LA_24a_c.Checked == true)
            {
                var_LA_24a_b = "888";
            }



            if (LA_24b_a.Checked == true)
            {
                var_LA_24b_a = "1";
            }
            else if (LA_24b_b.Checked == true)
            {
                var_LA_24b_a = "2";
            }
            else if (LA_24b_c.Checked == true)
            {
                var_LA_24b_a = "3";
            }



            if (LA_25a_v.Checked == true)
            {
                var_LA_25a_b = "";
            }
            else if (LA_25a_b.Checked == true)
            {
                var_LA_25a_b = "999";
            }
            else if (LA_25a_c.Checked == true)
            {
                var_LA_25a_b = "888";
            }



            if (LA_25b_a.Checked == true)
            {
                var_LA_25b_a = "1";
            }
            else if (LA_25b_b.Checked == true)
            {
                var_LA_25b_a = "2";
            }
            else if (LA_25b_c.Checked == true)
            {
                var_LA_25b_a = "3";
            }



            if (LA_26a_v.Checked == true)
            {
                var_LA_26a_b = "";
            }
            else if (LA_26a_b.Checked == true)
            {
                var_LA_26a_b = "999";
            }
            else if (LA_26a_c.Checked == true)
            {
                var_LA_26a_b = "888";
            }



            if (LA_26b_a.Checked == true)
            {
                var_LA_26b_a = "1";
            }
            else if (LA_26b_b.Checked == true)
            {
                var_LA_26b_a = "2";
            }
            else if (LA_26b_c.Checked == true)
            {
                var_LA_26b_a = "3";
            }




            if (LA_27a_v.Checked == true)
            {
                var_LA_27a_b = "";
            }
            else if (LA_27a_b.Checked == true)
            {
                var_LA_27a_b = "999";
            }
            else if (LA_27a_c.Checked == true)
            {
                var_LA_27a_b = "888";
            }



            if (LA_27b_a.Checked == true)
            {
                var_LA_27b_a = "1";
            }
            else if (LA_27b_b.Checked == true)
            {
                var_LA_27b_a = "2";
            }
            else if (LA_27b_c.Checked == true)
            {
                var_LA_27b_a = "3";
            }




            if (LA_28a_v.Checked == true)
            {
                var_LA_28a_b = "";
            }
            else if (LA_28a_b.Checked == true)
            {
                var_LA_28a_b = "999";
            }
            else if (LA_28a_c.Checked == true)
            {
                var_LA_28a_b = "888";
            }



            if (LA_28b_a.Checked == true)
            {
                var_LA_28b_a = "1";
            }
            else if (LA_28b_b.Checked == true)
            {
                var_LA_28b_a = "2";
            }
            else if (LA_28b_c.Checked == true)
            {
                var_LA_28b_a = "3";
            }



            if (LA_29a_v.Checked == true)
            {
                var_LA_29a_b = "";
            }
            else if (LA_29a_b.Checked == true)
            {
                var_LA_29a_b = "999";
            }
            else if (LA_29a_c.Checked == true)
            {
                var_LA_29a_b = "888";
            }



            if (LA_29b_a.Checked == true)
            {
                var_LA_29b_a = "1";
            }
            else if (LA_29b_b.Checked == true)
            {
                var_LA_29b_a = "2";
            }
            else if (LA_29b_c.Checked == true)
            {
                var_LA_29b_a = "3";
            }



            if (LA_30a_v.Checked == true)
            {
                var_LA_30a_b = "";
            }
            else if (LA_30a_b.Checked == true)
            {
                var_LA_30a_b = "999";
            }
            else if (LA_30a_c.Checked == true)
            {
                var_LA_30a_b = "888";
            }



            if (LA_30b_a.Checked == true)
            {
                var_LA_30b_a = "1";
            }
            else if (LA_30b_b.Checked == true)
            {
                var_LA_30b_a = "2";
            }
            else if (LA_30b_c.Checked == true)
            {
                var_LA_30b_a = "3";
            }



            if (LA_31a_v.Checked == true)
            {
                var_LA_31a_b = "";
            }
            else if (LA_31a_b.Checked == true)
            {
                var_LA_31a_b = "999";
            }
            else if (LA_31a_c.Checked == true)
            {
                var_LA_31a_b = "888";
            }



            if (LA_31b_a.Checked == true)
            {
                var_LA_31b_a = "1";
            }
            else if (LA_31b_b.Checked == true)
            {
                var_LA_31b_a = "2";
            }
            else if (LA_31b_c.Checked == true)
            {
                var_LA_31b_a = "3";
            }



            if (LA_32a_v.Checked == true)
            {
                var_LA_32a_b = "";
            }
            else if (LA_32a_b.Checked == true)
            {
                var_LA_32a_b = "999";
            }
            else if (LA_32a_c.Checked == true)
            {
                var_LA_32a_b = "888";
            }



            if (LA_32b_a.Checked == true)
            {
                var_LA_32b_a = "1";
            }
            else if (LA_32b_b.Checked == true)
            {
                var_LA_32b_a = "2";
            }
            else if (LA_32b_c.Checked == true)
            {
                var_LA_32b_a = "3";
            }




            if (LA_33a_v.Checked == true)
            {
                var_LA_33a_b = "";
            }
            else if (LA_33a_b.Checked == true)
            {
                var_LA_33a_b = "999";
            }
            else if (LA_33a_c.Checked == true)
            {
                var_LA_33a_b = "888";
            }



            if (LA_33b_a.Checked == true)
            {
                var_LA_33b_a = "1";
            }
            else if (LA_33b_b.Checked == true)
            {
                var_LA_33b_a = "2";
            }
            else if (LA_33b_c.Checked == true)
            {
                var_LA_33b_a = "3";
            }




            if (LA_34a_v.Checked == true)
            {
                var_LA_34a_b = "";
            }
            else if (LA_34a_b.Checked == true)
            {
                var_LA_34a_b = "999";
            }
            else if (LA_34a_c.Checked == true)
            {
                var_LA_34a_b = "888";
            }



            if (LA_34b_a.Checked == true)
            {
                var_LA_34b_a = "1";
            }
            else if (LA_34b_b.Checked == true)
            {
                var_LA_34b_a = "2";
            }
            else if (LA_34b_c.Checked == true)
            {
                var_LA_34b_a = "3";
            }




            if (LA_35a_v.Checked == true)
            {
                var_LA_35a_b = "";
            }
            else if (LA_35a_b.Checked == true)
            {
                var_LA_35a_b = "999";
            }
            else if (LA_35a_c.Checked == true)
            {
                var_LA_35a_b = "888";
            }




            if (LA_35b_a.Checked == true)
            {
                var_LA_35b_a = "1";
            }
            else if (LA_35b_b.Checked == true)
            {
                var_LA_35b_a = "2";
            }
            else if (LA_35b_c.Checked == true)
            {
                var_LA_35b_a = "3";
            }




            if (LA_36a_v.Checked == true)
            {
                var_LA_36a_b = "";
            }
            else if (LA_36a_b.Checked == true)
            {
                var_LA_36a_b = "999";
            }
            else if (LA_36a_c.Checked == true)
            {
                var_LA_36a_b = "888";
            }



            if (LA_36b_a.Checked == true)
            {
                var_LA_36b_a = "1";
            }
            else if (LA_36b_b.Checked == true)
            {
                var_LA_36b_a = "2";
            }
            else if (LA_36b_c.Checked == true)
            {
                var_LA_36b_a = "3";
            }




            if (LA_37a_v.Checked == true)
            {
                var_LA_37a_b = "";
            }
            else if (LA_37a_b.Checked == true)
            {
                var_LA_37a_b = "999";
            }
            else if (LA_37a_c.Checked == true)
            {
                var_LA_37a_b = "888";
            }



            if (LA_37b_a.Checked == true)
            {
                var_LA_37b_a = "1";
            }
            else if (LA_37b_b.Checked == true)
            {
                var_LA_37b_a = "2";
            }
            else if (LA_37b_c.Checked == true)
            {
                var_LA_37b_a = "3";
            }




            if (LA_38a_v.Checked == true)
            {
                var_LA_38a_b = "";
            }
            else if (LA_38a_b.Checked == true)
            {
                var_LA_38a_b = "999";
            }
            else if (LA_38a_c.Checked == true)
            {
                var_LA_38a_b = "888";
            }



            if (LA_38b_a.Checked == true)
            {
                var_LA_38b_a = "1";
            }
            else if (LA_38b_b.Checked == true)
            {
                var_LA_38b_a = "2";
            }
            else if (LA_38b_c.Checked == true)
            {
                var_LA_38b_a = "3";
            }




            if (LA_39a_v.Checked == true)
            {
                var_LA_39a_b = "";
            }
            else if (LA_39a_b.Checked == true)
            {
                var_LA_39a_b = "999";
            }
            else if (LA_39a_c.Checked == true)
            {
                var_LA_39a_b = "888";
            }



            if (LA_39b_a.Checked == true)
            {
                var_LA_39b_a = "1";
            }
            else if (LA_39b_b.Checked == true)
            {
                var_LA_39b_a = "2";
            }
            else if (LA_39b_c.Checked == true)
            {
                var_LA_39b_a = "3";
            }



            if (LA_40a_v.Checked == true)
            {
                var_LA_40a_b = "";
            }
            else if (LA_40a_b.Checked == true)
            {
                var_LA_40a_b = "999";
            }
            else if (LA_40a_c.Checked == true)
            {
                var_LA_40a_b = "888";
            }



            if (LA_40b_a.Checked == true)
            {
                var_LA_40b_a = "1";
            }
            else if (LA_40b_b.Checked == true)
            {
                var_LA_40b_a = "2";
            }
            else if (LA_40b_c.Checked == true)
            {
                var_LA_40b_a = "3";
            }



            if (LA_41a_v.Checked == true)
            {
                var_LA_41a_b = "";
            }
            else if (LA_41a_b.Checked == true)
            {
                var_LA_41a_b = "999";
            }
            else if (LA_41a_c.Checked == true)
            {
                var_LA_41a_b = "888";
            }



            if (LA_41b_a.Checked == true)
            {
                var_LA_41b_a = "1";
            }
            else if (LA_41b_b.Checked == true)
            {
                var_LA_41b_a = "2";
            }
            else if (LA_41b_c.Checked == true)
            {
                var_LA_41b_a = "3";
            }



            if (LA_42a_v.Checked == true)
            {
                var_LA_42a_b = "";
            }
            else if (LA_42a_b.Checked == true)
            {
                var_LA_42a_b = "999";
            }
            else if (LA_42a_c.Checked == true)
            {
                var_LA_42a_b = "888";
            }



            if (LA_42b_a.Checked == true)
            {
                var_LA_42b_a = "1";
            }
            else if (LA_42b_b.Checked == true)
            {
                var_LA_42b_a = "2";
            }
            else if (LA_42b_c.Checked == true)
            {
                var_LA_42b_a = "3";
            }



            if (LA_43a_v.Checked == true)
            {
                var_LA_43a_b = "";
            }
            else if (LA_43a_b.Checked == true)
            {
                var_LA_43a_b = "999";
            }
            else if (LA_43a_c.Checked == true)
            {
                var_LA_43a_b = "888";
            }



            if (LA_43b_a.Checked == true)
            {
                var_LA_43b_a = "1";
            }
            else if (LA_43b_b.Checked == true)
            {
                var_LA_43b_a = "2";
            }
            else if (LA_43b_c.Checked == true)
            {
                var_LA_43b_a = "3";
            }



            if (LA_44a_v.Checked == true)
            {
                var_LA_44a_b = "";
            }
            else if (LA_44a_b.Checked == true)
            {
                var_LA_44a_b = "999";
            }
            else if (LA_44a_c.Checked == true)
            {
                var_LA_44a_b = "888";
            }



            if (LA_44b_a.Checked == true)
            {
                var_LA_44b_a = "1";
            }
            else if (LA_44b_b.Checked == true)
            {
                var_LA_44b_a = "2";
            }
            else if (LA_44b_c.Checked == true)
            {
                var_LA_44b_a = "3";
            }



            if (LA_45a_v.Checked == true)
            {
                var_LA_45a_b = "";
            }
            else if (LA_45a_b.Checked == true)
            {
                var_LA_45a_b = "999";
            }
            else if (LA_45a_c.Checked == true)
            {
                var_LA_45a_b = "888";
            }



            if (LA_45b_a.Checked == true)
            {
                var_LA_45b_a = "1";
            }
            else if (LA_45b_b.Checked == true)
            {
                var_LA_45b_a = "2";
            }
            else if (LA_45b_c.Checked == true)
            {
                var_LA_45b_a = "3";
            }



            if (LA_46a_v.Checked == true)
            {
                var_LA_46a_b = "";
            }
            else if (LA_46a_b.Checked == true)
            {
                var_LA_46a_b = "999";
            }
            else if (LA_46a_c.Checked == true)
            {
                var_LA_46a_b = "888";
            }



            if (LA_46b_a.Checked == true)
            {
                var_LA_46b_a = "1";
            }
            else if (LA_46b_b.Checked == true)
            {
                var_LA_46b_a = "2";
            }
            else if (LA_46b_c.Checked == true)
            {
                var_LA_46b_a = "3";
            }



            if (LA_47a_v.Checked == true)
            {
                var_LA_47a_b = "";
            }
            else if (LA_47a_b.Checked == true)
            {
                var_LA_47a_b = "999";
            }
            else if (LA_47a_c.Checked == true)
            {
                var_LA_47a_b = "888";
            }



            if (LA_47b_a.Checked == true)
            {
                var_LA_47b_a = "1";
            }
            else if (LA_47b_b.Checked == true)
            {
                var_LA_47b_a = "2";
            }
            else if (LA_47b_c.Checked == true)
            {
                var_LA_47b_a = "3";
            }




            if (LA_48a_v.Checked == true)
            {
                var_LA_48a_b = "";
            }
            else if (LA_48a_b.Checked == true)
            {
                var_LA_48a_b = "999";
            }
            else if (LA_48a_c.Checked == true)
            {
                var_LA_48a_b = "888";
            }



            if (LA_48b_a.Checked == true)
            {
                var_LA_48b_a = "1";
            }
            else if (LA_48b_b.Checked == true)
            {
                var_LA_48b_a = "2";
            }
            else if (LA_48b_c.Checked == true)
            {
                var_LA_48b_a = "3";
            }



            if (LA_49a_v.Checked == true)
            {
                var_LA_49a_b = "";
            }
            else if (LA_49a_b.Checked == true)
            {
                var_LA_49a_b = "999";
            }
            else if (LA_49a_c.Checked == true)
            {
                var_LA_49a_b = "888";
            }



            if (LA_49b_a.Checked == true)
            {
                var_LA_49b_a = "1";
            }
            else if (LA_49b_b.Checked == true)
            {
                var_LA_49b_a = "2";
            }
            else if (LA_49b_c.Checked == true)
            {
                var_LA_49b_a = "3";
            }



            if (LA_50a_v.Checked == true)
            {
                var_LA_50a_b = "";
            }
            else if (LA_50a_b.Checked == true)
            {
                var_LA_50a_b = "999";
            }
            else if (LA_50a_c.Checked == true)
            {
                var_LA_50a_b = "888";
            }



            if (LA_50b_a.Checked == true)
            {
                var_LA_50b_a = "1";
            }
            else if (LA_50b_b.Checked == true)
            {
                var_LA_50b_a = "2";
            }
            else if (LA_50b_c.Checked == true)
            {
                var_LA_50b_a = "3";
            }




            if (LA_51a_v.Checked == true)
            {
                var_LA_51a_b = "";
            }
            else if (LA_51a_b.Checked == true)
            {
                var_LA_51a_b = "999";
            }
            else if (LA_51a_c.Checked == true)
            {
                var_LA_51a_b = "888";
            }



            if (LA_51b_a.Checked == true)
            {
                var_LA_51b_a = "1";
            }
            else if (LA_51b_b.Checked == true)
            {
                var_LA_51b_a = "2";
            }
            else if (LA_51b_c.Checked == true)
            {
                var_LA_51b_a = "3";
            }




            if (LA_52a_v.Checked == true)
            {
                var_LA_52a_b = "";
            }
            else if (LA_52a_b.Checked == true)
            {
                var_LA_52a_b = "999";
            }
            else if (LA_52a_c.Checked == true)
            {
                var_LA_52a_b = "888";
            }



            if (LA_52b_a.Checked == true)
            {
                var_LA_52b_a = "1";
            }
            else if (LA_52b_b.Checked == true)
            {
                var_LA_52b_a = "2";
            }
            else if (LA_52b_c.Checked == true)
            {
                var_LA_52b_a = "3";
            }


            if (rd_BloodCulture_Pos.Checked == true)
            {
                var_BloodCulture = "1";
            }
            else if (rd_BloodCulture_Neg.Checked == true)
            {
                var_BloodCulture = "2";
            }



            DateTime dt_entry = new DateTime();

            string[] arr_entry = null;
            string val_entry = null;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            dt_entry = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            arr_entry = dt_entry.ToShortDateString().Split('/');
            val_entry = arr_entry[2] + "/" + arr_entry[1] + "/" + arr_entry[0];

            string qry = "";


            if (Request.Cookies["labid"].Value == "2")
            {

                qry = "insert into sample_result(" +
        "la_sno," +
        "LA_01," +
        "LA_02," +
        "LA_02a," +
        "LA_03_b," +
        "LA_03_a," +
        "LA_04_b," +
        "LA_04_a," +
        "LA_05_b," +
        "LA_05_a," +
        "LA_06_b," +
        "LA_06_a," +
        "LA_07_b," +
        "LA_07_a," +
        "LA_08_b," +
        "LA_08_a," +
        "LA_09_b," +
        "LA_09_a," +
        "LA_10_b," +
        "LA_10_a," +
        "LA_11_b," +
        "LA_11_a," +
        "LA_12_b," +
        "LA_12_a," +
        "LA_13_b," +
        "LA_13_a," +
        "LA_14_b," +
        "LA_14_a," +
        "LA_15_b," +
        "LA_15_a," +
        "LA_16_b," +
        "LA_16_a," +
        "LF_01," +
        "LF_01_a," +
        "LF_02," +
        "LF_02_a," +
        "LF_03," +
        "LF_03_a," +
        "LF_04," +
        "LF_04_a," +
        "LF_05," +
        "LF_05_a," +
        "LF_06," +
        "LF_06_a," +
        "LF_07," +
        "LF_07_a," +
        "RF_01," +
        "RF_01_a," +
        "RF_02," +
        "RF_02_a," +
        "RF_03," +
        "RF_03_a," +
        "RF_04," +
        "RF_04_a," +
        "SE_01," +
        "SE_01_a," +
        "SE_02," +
        "SE_02_a," +
        "SE_03," +
        "SE_03_a," +
        "SE_04," +
        "SE_04_a," +
        "CS_01," +
        "CS_01_a," +
        "CS_02," +
        "CS_02_a," +
        "CS_03," +
        "CS_03_a," +
        "CS_04," +
        "CS_04_a," +
        "CS_05," +
        "CS_05_a," +
        "CS_06," +
        "CS_06_a," +
        "CS_07," +
        "CS_07_a," +
        "CS_08," +
        "CS_08_a," +
        "CS_09," +
        "CS_09_a," +
        "CS_10," +
        "CS_10_a," +
        "UR_01," +
        "UR_01_a," +
        "UR_02," +
        "UR_02_a," +
        "UR_03," +
        "UR_03_a," +
        "UR_04," +
        "UR_04_a," +
        "UR_04a," +
        "UR_04a_a," +
        "UR_05," +
        "UR_05_a," +
        "UR_06," +
        "UR_06_a," +
        "UR_07," +
        "UR_07_a," +
        "UR_08," +
        "UR_08_a," +
        "UR_10," +
        "UR_10_a," +
        "UR_11," +
        "UR_11_a," +
        "UR_12," +
        "UR_12_a," +
        "UR_13," +
        "UR_13_a," +
        "UR_14," +
        "UR_14_a," +
        "UR_15," +
        "UR_15_a," +
        "UR_16," +
        "UR_16_a," +
        "UR_17," +
        "UR_17_a," +
        "UR_18," +
        "UR_18_a," +
        "UR_19," +
        "UR_19_a," +
        "UR_20," +
        "UR_20_a," +
        "UR_21," +
        "UR_21_a," +
        "uc_01a," +
        "uc_01_ca," +
        "uc_02a," +
        "uc_02a_a," +
        "uc_02b," +
        "uc_03a," +
        "uc_03a_a," +
        "uc_03b," +
        "uc_04a," +
        "uc_04a_a," +
        "uc_04b," +
        "uc_05a," +
        "uc_05a_a," +
        "uc_05b," +
        "uc_06a," +
        "uc_06a_a," +
        "uc_06b," +
        "uc_07a," +
        "uc_07a_a," +
        "uc_07b," +
        "uc_08a," +
        "uc_08a_a," +
        "uc_08b," +
        "uc_09a," +
        "uc_09a_a," +
        "uc_09b," +
        "uc_10a," +
        "uc_10a_a," +
        "uc_10b," +
        "uc_11a," +
        "uc_11a_a," +
        "uc_11b," +
        "uc_12a," +
        "uc_12a_a," +
        "uc_12b," +
        "uc_13a," +
        "uc_13a_a," +
        "uc_13b," +
        "uc_14a," +
        "uc_14a_a," +
        "uc_14b," +
        "uc_15a," +
        "uc_15a_a," +
        "uc_15b," +
        "uc_16a," +
        "uc_16a_a," +
        "uc_16b," +
        "uc_17a," +
        "uc_17a_a," +
        "uc_17b," +
        "uc_18a," +
        "uc_18a_a," +
        "uc_18b," +
        "uc_19a," +
        "uc_19a_a," +
        "uc_19b," +
        "uc_20a," +
        "uc_20a_a," +
        "uc_20b," +
        "uc_21a," +
        "uc_21a_a," +
        "uc_21b," +
        "uc_22a," +
        "uc_22a_a," +
        "uc_22b," +
        "uc_23a," +
        "uc_23a_a," +
        "uc_23b," +
        "uc_24a," +
        "uc_24a_a," +
        "uc_24b," +
        "uc_25a," +
        "uc_25a_a," +
        "uc_25b," +
        "uc_26a," +
        "uc_26a_a," +
        "uc_26b," +
        "uc_27a," +
        "uc_27a_a," +
        "uc_27b," +
        "uc_28a," +
        "uc_28a_a," +
        "uc_28b," +
        "uc_29a," +
        "uc_29a_a," +
        "uc_29b," +
        "uc_30a," +
        "uc_30a_a," +
        "uc_30b," +
        "uc_31a," +
        "uc_31a_a," +
        "uc_31b," +
        "uc_32a," +
        "uc_32a_a," +
        "uc_32b," +
        "uc_33a," +
        "uc_33a_a," +
        "uc_33b," +
        "uc_34a," +
        "uc_34a_a," +
        "uc_34b," +
        "uc_35a," +
        "uc_35a_a," +
        "uc_35b," +
        "uc_36a," +
        "uc_36a_a," +
        "uc_36b," +
        "uc_37a," +
        "uc_37a_a," +
        "uc_37b," +
        "LA_17," +
        "LA_18," +
        "LA_19," +
        "LA_20a_b," +
        "LA_20a_a," +
        "LA_20b_a," +
        "LA_21a_b," +
        "LA_21a_a," +
        "LA_21b_a," +
        "LA_22a_b," +
        "LA_22a_a," +
        "LA_22b_a," +
        "LA_23a_b," +
        "LA_23a_a," +
        "LA_23b_a," +
        "LA_24a_b," +
        "LA_24a_a," +
        "LA_24b_a," +
        "LA_25a_b," +
        "LA_25a_a," +
        "LA_25b_a," +
        "LA_26a_b," +
        "LA_26a_a," +
        "LA_26b_a," +
        "LA_27a_b," +
        "LA_27a_a," +
        "LA_27b_a," +
        "LA_28a_b," +
        "LA_28a_a," +
        "LA_28b_a," +
        "LA_29a_b," +
        "LA_29a_a," +
        "LA_29b_a," +
        "LA_30a_b," +
        "LA_30a_a," +
        "LA_30b_a," +
        "LA_31a_b," +
        "LA_31a_a," +
        "LA_31b_a," +
        "LA_32a_b," +
        "LA_32a_a," +
        "LA_32b_a," +
        "LA_33a_b," +
        "LA_33a_a," +
        "LA_33b_a," +
        "LA_34a_b," +
        "LA_34a_a," +
        "LA_34b_a," +
        "LA_35a_b," +
        "LA_35a_a," +
        "LA_35b_a," +
        "LA_36a_b," +
        "LA_36a_a," +
        "LA_36b_a," +
        "LA_37a_b," +
        "LA_37a_a," +
        "LA_37b_a," +
        "LA_38a_b," +
        "LA_38a_a," +
        "LA_38b_a," +
        "LA_39a_b," +
        "LA_39a_a," +
        "LA_39b_a," +
        "LA_40a_b," +
        "LA_40a_a," +
        "LA_40b_a," +
        "LA_41a_b," +
        "LA_41a_a," +
        "LA_41b_a," +
        "LA_42a_b," +
        "LA_42a_a," +
        "LA_42b_a," +
        "LA_43a_b," +
        "LA_43a_a," +
        "LA_43b_a," +
        "LA_44a_b," +
        "LA_44a_a," +
        "LA_44b_a," +
        "LA_45a_b," +
        "LA_45a_a," +
        "LA_45b_a," +
        "LA_46a_b," +
        "LA_46a_a," +
        "LA_46b_a," +
        "LA_47a_b," +
        "LA_47a_a," +
        "LA_47b_a," +
        "LA_48a_b," +
        "LA_48a_a," +
        "LA_48b_a," +
        "LA_49a_b," +
        "LA_49a_a," +
        "LA_49b_a," +
        "LA_50a_b," +
        "LA_50a_a," +
        "LA_50b_a," +
        "LA_51a_b," +
        "LA_51a_a," +
        "LA_51b_a," +
        "LA_52a_b," +
        "LA_52a_a," +
        "LA_52b_a," +
        "UserID," +
        "EntryDate," +
        "labid," +
        "ProvisionalResult," +
        "rdo_BloodCulture," +
        "ddl_BloodCulture) values('" +
        la_sno.Text + "', '" +
        LA_01.Text + "', '" +
        LA_02.Text + "', '" +
        LA_02a.Text + "', '" +
        var_LA_03_b + "', '" +
        LA_03_a.Text + "', '" +
        var_LA_04_b + "', '" +
        LA_04_a.Text + "', '" +
        var_LA_05_b + "', '" +
        LA_05_a.Text + "', '" +
        var_LA_06_b + "', '" +
        LA_06_a.Text + "', '" +
        var_LA_07_b + "', '" +
        LA_07_a.Text + "', '" +
        var_LA_08_b + "', '" +
        LA_08_a.Text + "', '" +
        var_LA_09_b + "', '" +
        LA_09_a.Text + "', '" +
        var_LA_10_b + "', '" +
        LA_10_a.Text + "', '" +
        var_LA_11_b + "', '" +
        LA_11_a.Text + "', '" +
        var_LA_12_b + "', '" +
        LA_12_a.Text + "', '" +
        var_LA_13_b + "', '" +
        LA_13_a.Text + "', '" +
        var_LA_14_b + "', '" +
        LA_14_a.Text + "', '" +
        var_LA_15_b + "', '" +
        LA_15_a.Text + "', '" +
        var_LA_16_b + "', '" +
        LA_16_a.Text + "', '" +
        var_LF_01 + "', '" +
        LF_01_a.Text + "', '" +
        var_LF_02 + "', '" +
        LF_02_a.Text + "', '" +
        var_LF_03 + "', '" +
        LF_03_a.Text + "', '" +
        var_LF_04 + "', '" +
        LF_04_a.Text + "', '" +
        var_LF_05 + "', '" +
        LF_05_a.Text + "', '" +
        var_LF_06 + "', '" +
        LF_06_a.Text + "', '" +
        var_LF_07 + "', '" +
        LF_07_a.Text + "', '" +
        var_RF_01 + "', '" +
        RF_01_a.Text + "', '" +
        var_RF_02 + "', '" +
        RF_02_a.Text + "', '" +
        var_RF_03 + "', '" +
        RF_03_a.Text + "', '" +
        var_RF_04 + "', '" +
        RF_04_a.Text + "', '" +
        var_SE_01 + "', '" +
        SE_01_a.Text + "', '" +
        var_SE_02 + "', '" +
        SE_02_a.Text + "', '" +
        var_SE_03 + "', '" +
        SE_03_a.Text + "', '" +
        var_SE_04 + "', '" +
        SE_04_a.Text + "', '" +
        var_CS_01 + "', '" +
        CS_01_a.Text + "', '" +
        var_CS_02 + "', '" +
        CS_02_a.Text + "', '" +
        var_CS_03 + "', '" +
        CS_03_a.Text + "', '" +
        var_CS_04 + "', '" +
        CS_04_a.Text + "', '" +
        var_CS_05 + "', '" +
        CS_05_a.Text + "', '" +
        var_CS_06 + "', '" +
        CS_06_a.Text + "', '" +
        var_CS_07 + "', '" +
        CS_07_a.Text + "', '" +
        var_CS_08 + "', '" +
        CS_08_a.Text + "', '" +
        var_CS_09 + "', '" +
        CS_09_a.Text + "', '" +
        var_CS_10 + "', '" +
        CS_10_a.Text + "', '" +
        var_UR_01 + "', '" +
        UR_01_a.Text + "', '" +
        var_UR_02 + "', '" +
        UR_02_a.Text + "', '" +
        var_UR_03 + "', '" +
        UR_03_a.Text + "', '" +
        var_UR_04 + "', '" +
        UR_04_a.Text + "', '" +
        var_UR_04a + "', '" +
        UR_04a_a.Text + "', '" +
        var_UR_05 + "', '" +
        UR_05_a.Text + "', '" +
        var_UR_06 + "', '" +
        UR_06_a.Text + "', '" +
        var_UR_07 + "', '" +
        UR_07_a.Text + "', '" +
        var_UR_08 + "', '" +
        UR_08_a.Text + "', '" +
        var_UR_10 + "', '" +
        UR_10_a.Text + "', '" +
        var_UR_11 + "', '" +
        UR_11_a.Text + "', '" +
        var_UR_12 + "', '" +
        UR_12_a.Text + "', '" +
        var_UR_13 + "', '" +
        UR_13_a.Text + "', '" +
        var_UR_14 + "', '" +
        UR_14_a.Text + "', '" +
        var_UR_15 + "', '" +
        UR_15_a.Text + "', '" +
        var_UR_16 + "', '" +
        UR_16_a.Text + "', '" +
        var_UR_17 + "', '" +
        UR_17_a.Text + "', '" +
        var_UR_18 + "', '" +
        UR_18_a.Text + "', '" +
        var_UR_19 + "', '" +
        UR_19_a.Text + "', '" +
        var_UR_20 + "', '" +
        UR_20_a.Text + "', '" +
        var_UR_21 + "', '" +
        UR_21_a.Text + "', '" +
        var_uc_01a + "', '" +
        uc_01_ca.Text + "', '" +
        var_uc_02a + "', '" +
        uc_02a_a.Text + "', '" +
        var_uc_02b + "', '" +
        var_uc_03a + "', '" +
        uc_03a_a.Text + "', '" +
        var_uc_03b + "', '" +
        var_uc_04a + "', '" +
        uc_04a_a.Text + "', '" +
        var_uc_04b + "', '" +
        var_uc_05a + "', '" +
        uc_05a_a.Text + "', '" +
        var_uc_05b + "', '" +
        var_uc_06a + "', '" +
        uc_06a_a.Text + "', '" +
        var_uc_06b + "', '" +
        var_uc_07a + "', '" +
        uc_07a_a.Text + "', '" +
        var_uc_07b + "', '" +
        var_uc_08a + "', '" +
        uc_08a_a.Text + "', '" +
        var_uc_08b + "', '" +
        var_uc_09a + "', '" +
        uc_09a_a.Text + "', '" +
        var_uc_09b + "', '" +
        var_uc_10a + "', '" +
        uc_10a_a.Text + "', '" +
        var_uc_10b + "', '" +
        var_uc_11a + "', '" +
        uc_11a_a.Text + "', '" +
        var_uc_11b + "', '" +
        var_uc_12a + "', '" +
        uc_12a_a.Text + "', '" +
        var_uc_12b + "', '" +
        var_uc_13a + "', '" +
        uc_13a_a.Text + "', '" +
        var_uc_13b + "', '" +
        var_uc_14a + "', '" +
        uc_14a_a.Text + "', '" +
        var_uc_14b + "', '" +
        var_uc_15a + "', '" +
        uc_15a_a.Text + "', '" +
        var_uc_15b + "', '" +
        var_uc_16a + "', '" +
        uc_16a_a.Text + "', '" +
        var_uc_16b + "', '" +
        var_uc_17a + "', '" +
        uc_17a_a.Text + "', '" +
        var_uc_17b + "', '" +
        var_uc_18a + "', '" +
        uc_18a_a.Text + "', '" +
        var_uc_18b + "', '" +
        var_uc_19a + "', '" +
        uc_19a_a.Text + "', '" +
        var_uc_19b + "', '" +
        var_uc_20a + "', '" +
        uc_20a_a.Text + "', '" +
        var_uc_20b + "', '" +
        var_uc_21a + "', '" +
        uc_21a_a.Text + "', '" +
        var_uc_21b + "', '" +
        var_uc_22a + "', '" +
        uc_22a_a.Text + "', '" +
        var_uc_22b + "', '" +
        var_uc_23a + "', '" +
        uc_23a_a.Text + "', '" +
        var_uc_23b + "', '" +
        var_uc_24a + "', '" +
        uc_24a_a.Text + "', '" +
        var_uc_24b + "', '" +
        var_uc_25a + "', '" +
        uc_25a_a.Text + "', '" +
        var_uc_25b + "', '" +
        var_uc_26a + "', '" +
        uc_26a_a.Text + "', '" +
        var_uc_26b + "', '" +
        var_uc_27a + "', '" +
        uc_27a_a.Text + "', '" +
        var_uc_27b + "', '" +
        var_uc_28a + "', '" +
        uc_28a_a.Text + "', '" +
        var_uc_28b + "', '" +
        var_uc_29a + "', '" +
        uc_29a_a.Text + "', '" +
        var_uc_29b + "', '" +
        var_uc_30a + "', '" +
        uc_30a_a.Text + "', '" +
        var_uc_30b + "', '" +
        var_uc_31a + "', '" +
        uc_31a_a.Text + "', '" +
        var_uc_31b + "', '" +
        var_uc_32a + "', '" +
        uc_32a_a.Text + "', '" +
        var_uc_32b + "', '" +
        var_uc_33a + "', '" +
        uc_33a_a.Text + "', '" +
        var_uc_33b + "', '" +
        var_uc_34a + "', '" +
        uc_34a_a.Text + "', '" +
        var_uc_34b + "', '" +
        var_uc_35a + "', '" +
        uc_35a_a.Text + "', '" +
        var_uc_35b + "', '" +
        var_uc_36a + "', '" +
        uc_36a_a.Text + "', '" +
        var_uc_36b + "', '" +
        var_uc_37a + "', '" +
        uc_37a_a.Text + "', '" +
        var_uc_37b + "', '" +
        LA_17.Text + "', '" +
        LA_18.Text + "', '" +
        txtOtherOrganism.Text + "', '" +
        var_LA_20a_b + "', '" +
        LA_20a_a.Text + "', '" +
        var_LA_20b_a + "', '" +
        var_LA_21a_b + "', '" +
        LA_21a_a.Text + "', '" +
        var_LA_21b_a + "', '" +
        var_LA_22a_b + "', '" +
        LA_22a_a.Text + "', '" +
        var_LA_22b_a + "', '" +
        var_LA_23a_b + "', '" +
        LA_23a_a.Text + "', '" +
        var_LA_23b_a + "', '" +
        var_LA_24a_b + "', '" +
        LA_24a_a.Text + "', '" +
        var_LA_24b_a + "', '" +
        var_LA_25a_b + "', '" +
        LA_25a_a.Text + "', '" +
        var_LA_25b_a + "', '" +
        var_LA_26a_b + "', '" +
        LA_26a_a.Text + "', '" +
        var_LA_26b_a + "', '" +
        var_LA_27a_b + "', '" +
        LA_27a_a.Text + "', '" +
        var_LA_27b_a + "', '" +
        var_LA_28a_b + "', '" +
        LA_28a_a.Text + "', '" +
        var_LA_28b_a + "', '" +
        var_LA_29a_b + "', '" +
        LA_29a_a.Text + "', '" +
        var_LA_29b_a + "', '" +
        var_LA_30a_b + "', '" +
        LA_30a_a.Text + "', '" +
        var_LA_30b_a + "', '" +
        var_LA_31a_b + "', '" +
        LA_31a_a.Text + "', '" +
        var_LA_31b_a + "', '" +
        var_LA_32a_b + "', '" +
        LA_32a_a.Text + "', '" +
        var_LA_32b_a + "', '" +
        var_LA_33a_b + "', '" +
        LA_33a_a.Text + "', '" +
        var_LA_33b_a + "', '" +
        var_LA_34a_b + "', '" +
        LA_34a_a.Text + "', '" +
        var_LA_34b_a + "', '" +
        var_LA_35a_b + "', '" +
        LA_35a_a.Text + "', '" +
        var_LA_35b_a + "', '" +
        var_LA_36a_b + "', '" +
        LA_36a_a.Text + "', '" +
        var_LA_36b_a + "', '" +
        var_LA_37a_b + "', '" +
        LA_37a_a.Text + "', '" +
        var_LA_37b_a + "', '" +
        var_LA_38a_b + "', '" +
        LA_38a_a.Text + "', '" +
        var_LA_38b_a + "', '" +
        var_LA_39a_b + "', '" +
        LA_39a_a.Text + "', '" +
        var_LA_39b_a + "', '" +
        var_LA_40a_b + "', '" +
        LA_40a_a.Text + "', '" +
        var_LA_40b_a + "', '" +
        var_LA_41a_b + "', '" +
        LA_41a_a.Text + "', '" +
        var_LA_41b_a + "', '" +
        var_LA_42a_b + "', '" +
        LA_42a_a.Text + "', '" +
        var_LA_42b_a + "', '" +
        var_LA_43a_b + "', '" +
        LA_43a_a.Text + "', '" +
        var_LA_43b_a + "', '" +
        var_LA_44a_b + "', '" +
        LA_44a_a.Text + "', '" +
        var_LA_44b_a + "', '" +
        var_LA_45a_b + "', '" +
        LA_45a_a.Text + "', '" +
        var_LA_45b_a + "', '" +
        var_LA_46a_b + "', '" +
        LA_46a_a.Text + "', '" +
        var_LA_46b_a + "', '" +
        var_LA_47a_b + "', '" +
        LA_47a_a.Text + "', '" +
        var_LA_47b_a + "', '" +
        var_LA_48a_b + "', '" +
        LA_48a_a.Text + "', '" +
        var_LA_48b_a + "', '" +
        var_LA_49a_b + "', '" +
        LA_49a_a.Text + "', '" +
        var_LA_49b_a + "', '" +
        var_LA_50a_b + "', '" +
        LA_50a_a.Text + "', '" +
        var_LA_50b_a + "', '" +
        var_LA_51a_b + "', '" +
        LA_51a_a.Text + "', '" +
        var_LA_51b_a + "', '" +
        var_LA_52a_b + "', '" +
        LA_52a_a.Text + "', '" +
        var_LA_52b_a + "', '" +
        Session["userid"].ToString() + "', '" +
        val_entry + "', '" +
        HttpContext.Current.Request["labid"].ToString() + "', '" +
        ProvisionalResult.Text + "', '" +
        var_BloodCulture + "', '" +
        ddl_BloodCulture.SelectedIndex + "')";

            }
            else
            {

                if (ddl_BloodCulture.Items.Count == 0)
                {

                    qry = "insert into sample_result(" +
                "la_sno," +
                "LA_01," +
                "LA_02," +
                "LA_02a," +
                "LA_03_b," +
                "LA_03_a," +
                "LA_04_b," +
                "LA_04_a," +
                "LA_05_b," +
                "LA_05_a," +
                "LA_06_b," +
                "LA_06_a," +
                "LA_07_b," +
                "LA_07_a," +
                "LA_08_b," +
                "LA_08_a," +
                "LA_09_b," +
                "LA_09_a," +
                "LA_10_b," +
                "LA_10_a," +
                "LA_11_b," +
                "LA_11_a," +
                "LA_12_b," +
                "LA_12_a," +
                "LA_13_b," +
                "LA_13_a," +
                "LA_14_b," +
                "LA_14_a," +
                "LA_15_b," +
                "LA_15_a," +
                "LA_16_b," +
                "LA_16_a," +
                "LF_01," +
                "LF_01_a," +
                "LF_02," +
                "LF_02_a," +
                "LF_03," +
                "LF_03_a," +
                "LF_04," +
                "LF_04_a," +
                "LF_05," +
                "LF_05_a," +
                "LF_06," +
                "LF_06_a," +
                "LF_07," +
                "LF_07_a," +
                "RF_01," +
                "RF_01_a," +
                "RF_02," +
                "RF_02_a," +
                "RF_03," +
                "RF_03_a," +
                "RF_04," +
                "RF_04_a," +
                "SE_01," +
                "SE_01_a," +
                "SE_02," +
                "SE_02_a," +
                "SE_03," +
                "SE_03_a," +
                "SE_04," +
                "SE_04_a," +
                "CS_01," +
                "CS_01_a," +
                "CS_02," +
                "CS_02_a," +
                "CS_03," +
                "CS_03_a," +
                "CS_04," +
                "CS_04_a," +
                "CS_05," +
                "CS_05_a," +
                "CS_06," +
                "CS_06_a," +
                "CS_07," +
                "CS_07_a," +
                "CS_08," +
                "CS_08_a," +
                "CS_09," +
                "CS_09_a," +
                "CS_10," +
                "CS_10_a," +
                "UR_01," +
                "UR_01_a," +
                "UR_02," +
                "UR_02_a," +
                "UR_03," +
                "UR_03_a," +
                "UR_04," +
                "UR_04_a," +
                "UR_04a," +
                "UR_04a_a," +
                "UR_05," +
                "UR_05_a," +
                "UR_06," +
                "UR_06_a," +
                "UR_07," +
                "UR_07_a," +
                "UR_08," +
                "UR_08_a," +
                "UR_10," +
                "UR_10_a," +
                "UR_11," +
                "UR_11_a," +
                "UR_12," +
                "UR_12_a," +
                "UR_13," +
                "UR_13_a," +
                "UR_14," +
                "UR_14_a," +
                "UR_15," +
                "UR_15_a," +
                "UR_16," +
                "UR_16_a," +
                "UR_17," +
                "UR_17_a," +
                "UR_18," +
                "UR_18_a," +
                "UR_19," +
                "UR_19_a," +
                "UR_20," +
                "UR_20_a," +
                "UR_21," +
                "UR_21_a," +
                "uc_01a," +
                "uc_01_ca," +
                "uc_02a," +
                "uc_02a_a," +
                "uc_02b," +
                "uc_03a," +
                "uc_03a_a," +
                "uc_03b," +
                "uc_04a," +
                "uc_04a_a," +
                "uc_04b," +
                "uc_05a," +
                "uc_05a_a," +
                "uc_05b," +
                "uc_06a," +
                "uc_06a_a," +
                "uc_06b," +
                "uc_07a," +
                "uc_07a_a," +
                "uc_07b," +
                "uc_08a," +
                "uc_08a_a," +
                "uc_08b," +
                "uc_09a," +
                "uc_09a_a," +
                "uc_09b," +
                "uc_10a," +
                "uc_10a_a," +
                "uc_10b," +
                "uc_11a," +
                "uc_11a_a," +
                "uc_11b," +
                "uc_12a," +
                "uc_12a_a," +
                "uc_12b," +
                "uc_13a," +
                "uc_13a_a," +
                "uc_13b," +
                "uc_14a," +
                "uc_14a_a," +
                "uc_14b," +
                "uc_15a," +
                "uc_15a_a," +
                "uc_15b," +
                "uc_16a," +
                "uc_16a_a," +
                "uc_16b," +
                "uc_17a," +
                "uc_17a_a," +
                "uc_17b," +
                "uc_18a," +
                "uc_18a_a," +
                "uc_18b," +
                "uc_19a," +
                "uc_19a_a," +
                "uc_19b," +
                "uc_20a," +
                "uc_20a_a," +
                "uc_20b," +
                "uc_21a," +
                "uc_21a_a," +
                "uc_21b," +
                "uc_22a," +
                "uc_22a_a," +
                "uc_22b," +
                "uc_23a," +
                "uc_23a_a," +
                "uc_23b," +
                "uc_24a," +
                "uc_24a_a," +
                "uc_24b," +
                "uc_25a," +
                "uc_25a_a," +
                "uc_25b," +
                "uc_26a," +
                "uc_26a_a," +
                "uc_26b," +
                "uc_27a," +
                "uc_27a_a," +
                "uc_27b," +
                "uc_28a," +
                "uc_28a_a," +
                "uc_28b," +
                "uc_29a," +
                "uc_29a_a," +
                "uc_29b," +
                "uc_30a," +
                "uc_30a_a," +
                "uc_30b," +
                "uc_31a," +
                "uc_31a_a," +
                "uc_31b," +
                "uc_32a," +
                "uc_32a_a," +
                "uc_32b," +
                "uc_33a," +
                "uc_33a_a," +
                "uc_33b," +
                "uc_34a," +
                "uc_34a_a," +
                "uc_34b," +
                "uc_35a," +
                "uc_35a_a," +
                "uc_35b," +
                "uc_36a," +
                "uc_36a_a," +
                "uc_36b," +
                "uc_37a," +
                "uc_37a_a," +
                "uc_37b," +
                "LA_17," +
                "LA_18," +
                "LA_19," +
                "LA_20a_b," +
                "LA_20a_a," +
                "LA_20b_a," +
                "LA_21a_b," +
                "LA_21a_a," +
                "LA_21b_a," +
                "LA_22a_b," +
                "LA_22a_a," +
                "LA_22b_a," +
                "LA_23a_b," +
                "LA_23a_a," +
                "LA_23b_a," +
                "LA_24a_b," +
                "LA_24a_a," +
                "LA_24b_a," +
                "LA_25a_b," +
                "LA_25a_a," +
                "LA_25b_a," +
                "LA_26a_b," +
                "LA_26a_a," +
                "LA_26b_a," +
                "LA_27a_b," +
                "LA_27a_a," +
                "LA_27b_a," +
                "LA_28a_b," +
                "LA_28a_a," +
                "LA_28b_a," +
                "LA_29a_b," +
                "LA_29a_a," +
                "LA_29b_a," +
                "LA_30a_b," +
                "LA_30a_a," +
                "LA_30b_a," +
                "LA_31a_b," +
                "LA_31a_a," +
                "LA_31b_a," +
                "LA_32a_b," +
                "LA_32a_a," +
                "LA_32b_a," +
                "LA_33a_b," +
                "LA_33a_a," +
                "LA_33b_a," +
                "LA_34a_b," +
                "LA_34a_a," +
                "LA_34b_a," +
                "LA_35a_b," +
                "LA_35a_a," +
                "LA_35b_a," +
                "LA_36a_b," +
                "LA_36a_a," +
                "LA_36b_a," +
                "LA_37a_b," +
                "LA_37a_a," +
                "LA_37b_a," +
                "LA_38a_b," +
                "LA_38a_a," +
                "LA_38b_a," +
                "LA_39a_b," +
                "LA_39a_a," +
                "LA_39b_a," +
                "LA_40a_b," +
                "LA_40a_a," +
                "LA_40b_a," +
                "LA_41a_b," +
                "LA_41a_a," +
                "LA_41b_a," +
                "LA_42a_b," +
                "LA_42a_a," +
                "LA_42b_a," +
                "LA_43a_b," +
                "LA_43a_a," +
                "LA_43b_a," +
                "LA_44a_b," +
                "LA_44a_a," +
                "LA_44b_a," +
                "LA_45a_b," +
                "LA_45a_a," +
                "LA_45b_a," +
                "LA_46a_b," +
                "LA_46a_a," +
                "LA_46b_a," +
                "LA_47a_b," +
                "LA_47a_a," +
                "LA_47b_a," +
                "LA_48a_b," +
                "LA_48a_a," +
                "LA_48b_a," +
                "LA_49a_b," +
                "LA_49a_a," +
                "LA_49b_a," +
                "LA_50a_b," +
                "LA_50a_a," +
                "LA_50b_a," +
                "LA_51a_b," +
                "LA_51a_a," +
                "LA_51b_a," +
                "LA_52a_b," +
                "LA_52a_a," +
                "LA_52b_a," +
                "UserID," +
                "EntryDate," +
                "labid," +
                "ProvisionalResult," +
                "rdo_BloodCulture," +
                "ddl_BloodCulture) values('" +
                la_sno.Text + "', '" +
                LA_01.Text + "', '" +
                LA_02.Text + "', '" +
                LA_02a.Text + "', '" +
                var_LA_03_b + "', '" +
                LA_03_a.Text + "', '" +
                var_LA_04_b + "', '" +
                LA_04_a.Text + "', '" +
                var_LA_05_b + "', '" +
                LA_05_a.Text + "', '" +
                var_LA_06_b + "', '" +
                LA_06_a.Text + "', '" +
                var_LA_07_b + "', '" +
                LA_07_a.Text + "', '" +
                var_LA_08_b + "', '" +
                LA_08_a.Text + "', '" +
                var_LA_09_b + "', '" +
                LA_09_a.Text + "', '" +
                var_LA_10_b + "', '" +
                LA_10_a.Text + "', '" +
                var_LA_11_b + "', '" +
                LA_11_a.Text + "', '" +
                var_LA_12_b + "', '" +
                LA_12_a.Text + "', '" +
                var_LA_13_b + "', '" +
                LA_13_a.Text + "', '" +
                var_LA_14_b + "', '" +
                LA_14_a.Text + "', '" +
                var_LA_15_b + "', '" +
                LA_15_a.Text + "', '" +
                var_LA_16_b + "', '" +
                LA_16_a.Text + "', '" +
                var_LF_01 + "', '" +
                LF_01_a.Text + "', '" +
                var_LF_02 + "', '" +
                LF_02_a.Text + "', '" +
                var_LF_03 + "', '" +
                LF_03_a.Text + "', '" +
                var_LF_04 + "', '" +
                LF_04_a.Text + "', '" +
                var_LF_05 + "', '" +
                LF_05_a.Text + "', '" +
                var_LF_06 + "', '" +
                LF_06_a.Text + "', '" +
                var_LF_07 + "', '" +
                LF_07_a.Text + "', '" +
                var_RF_01 + "', '" +
                RF_01_a.Text + "', '" +
                var_RF_02 + "', '" +
                RF_02_a.Text + "', '" +
                var_RF_03 + "', '" +
                RF_03_a.Text + "', '" +
                var_RF_04 + "', '" +
                RF_04_a.Text + "', '" +
                var_SE_01 + "', '" +
                SE_01_a.Text + "', '" +
                var_SE_02 + "', '" +
                SE_02_a.Text + "', '" +
                var_SE_03 + "', '" +
                SE_03_a.Text + "', '" +
                var_SE_04 + "', '" +
                SE_04_a.Text + "', '" +
                var_CS_01 + "', '" +
                CS_01_a.Text + "', '" +
                var_CS_02 + "', '" +
                CS_02_a.Text + "', '" +
                var_CS_03 + "', '" +
                CS_03_a.Text + "', '" +
                var_CS_04 + "', '" +
                CS_04_a.Text + "', '" +
                var_CS_05 + "', '" +
                CS_05_a.Text + "', '" +
                var_CS_06 + "', '" +
                CS_06_a.Text + "', '" +
                var_CS_07 + "', '" +
                CS_07_a.Text + "', '" +
                var_CS_08 + "', '" +
                CS_08_a.Text + "', '" +
                var_CS_09 + "', '" +
                CS_09_a.Text + "', '" +
                var_CS_10 + "', '" +
                CS_10_a.Text + "', '" +
                var_UR_01 + "', '" +
                UR_01_a.Text + "', '" +
                var_UR_02 + "', '" +
                UR_02_a.Text + "', '" +
                var_UR_03 + "', '" +
                UR_03_a.Text + "', '" +
                var_UR_04 + "', '" +
                UR_04_a.Text + "', '" +
                var_UR_04a + "', '" +
                UR_04a_a.Text + "', '" +
                var_UR_05 + "', '" +
                UR_05_a.Text + "', '" +
                var_UR_06 + "', '" +
                UR_06_a.Text + "', '" +
                var_UR_07 + "', '" +
                UR_07_a.Text + "', '" +
                var_UR_08 + "', '" +
                UR_08_a.Text + "', '" +
                var_UR_10 + "', '" +
                UR_10_a.Text + "', '" +
                var_UR_11 + "', '" +
                UR_11_a.Text + "', '" +
                var_UR_12 + "', '" +
                UR_12_a.Text + "', '" +
                var_UR_13 + "', '" +
                UR_13_a.Text + "', '" +
                var_UR_14 + "', '" +
                UR_14_a.Text + "', '" +
                var_UR_15 + "', '" +
                UR_15_a.Text + "', '" +
                var_UR_16 + "', '" +
                UR_16_a.Text + "', '" +
                var_UR_17 + "', '" +
                UR_17_a.Text + "', '" +
                var_UR_18 + "', '" +
                UR_18_a.Text + "', '" +
                var_UR_19 + "', '" +
                UR_19_a.Text + "', '" +
                var_UR_20 + "', '" +
                UR_20_a.Text + "', '" +
                var_UR_21 + "', '" +
                UR_21_a.Text + "', '" +
                var_uc_01a + "', '" +
                uc_01_ca.Text + "', '" +
                var_uc_02a + "', '" +
                uc_02a_a.Text + "', '" +
                var_uc_02b + "', '" +
                var_uc_03a + "', '" +
                uc_03a_a.Text + "', '" +
                var_uc_03b + "', '" +
                var_uc_04a + "', '" +
                uc_04a_a.Text + "', '" +
                var_uc_04b + "', '" +
                var_uc_05a + "', '" +
                uc_05a_a.Text + "', '" +
                var_uc_05b + "', '" +
                var_uc_06a + "', '" +
                uc_06a_a.Text + "', '" +
                var_uc_06b + "', '" +
                var_uc_07a + "', '" +
                uc_07a_a.Text + "', '" +
                var_uc_07b + "', '" +
                var_uc_08a + "', '" +
                uc_08a_a.Text + "', '" +
                var_uc_08b + "', '" +
                var_uc_09a + "', '" +
                uc_09a_a.Text + "', '" +
                var_uc_09b + "', '" +
                var_uc_10a + "', '" +
                uc_10a_a.Text + "', '" +
                var_uc_10b + "', '" +
                var_uc_11a + "', '" +
                uc_11a_a.Text + "', '" +
                var_uc_11b + "', '" +
                var_uc_12a + "', '" +
                uc_12a_a.Text + "', '" +
                var_uc_12b + "', '" +
                var_uc_13a + "', '" +
                uc_13a_a.Text + "', '" +
                var_uc_13b + "', '" +
                var_uc_14a + "', '" +
                uc_14a_a.Text + "', '" +
                var_uc_14b + "', '" +
                var_uc_15a + "', '" +
                uc_15a_a.Text + "', '" +
                var_uc_15b + "', '" +
                var_uc_16a + "', '" +
                uc_16a_a.Text + "', '" +
                var_uc_16b + "', '" +
                var_uc_17a + "', '" +
                uc_17a_a.Text + "', '" +
                var_uc_17b + "', '" +
                var_uc_18a + "', '" +
                uc_18a_a.Text + "', '" +
                var_uc_18b + "', '" +
                var_uc_19a + "', '" +
                uc_19a_a.Text + "', '" +
                var_uc_19b + "', '" +
                var_uc_20a + "', '" +
                uc_20a_a.Text + "', '" +
                var_uc_20b + "', '" +
                var_uc_21a + "', '" +
                uc_21a_a.Text + "', '" +
                var_uc_21b + "', '" +
                var_uc_22a + "', '" +
                uc_22a_a.Text + "', '" +
                var_uc_22b + "', '" +
                var_uc_23a + "', '" +
                uc_23a_a.Text + "', '" +
                var_uc_23b + "', '" +
                var_uc_24a + "', '" +
                uc_24a_a.Text + "', '" +
                var_uc_24b + "', '" +
                var_uc_25a + "', '" +
                uc_25a_a.Text + "', '" +
                var_uc_25b + "', '" +
                var_uc_26a + "', '" +
                uc_26a_a.Text + "', '" +
                var_uc_26b + "', '" +
                var_uc_27a + "', '" +
                uc_27a_a.Text + "', '" +
                var_uc_27b + "', '" +
                var_uc_28a + "', '" +
                uc_28a_a.Text + "', '" +
                var_uc_28b + "', '" +
                var_uc_29a + "', '" +
                uc_29a_a.Text + "', '" +
                var_uc_29b + "', '" +
                var_uc_30a + "', '" +
                uc_30a_a.Text + "', '" +
                var_uc_30b + "', '" +
                var_uc_31a + "', '" +
                uc_31a_a.Text + "', '" +
                var_uc_31b + "', '" +
                var_uc_32a + "', '" +
                uc_32a_a.Text + "', '" +
                var_uc_32b + "', '" +
                var_uc_33a + "', '" +
                uc_33a_a.Text + "', '" +
                var_uc_33b + "', '" +
                var_uc_34a + "', '" +
                uc_34a_a.Text + "', '" +
                var_uc_34b + "', '" +
                var_uc_35a + "', '" +
                uc_35a_a.Text + "', '" +
                var_uc_35b + "', '" +
                var_uc_36a + "', '" +
                uc_36a_a.Text + "', '" +
                var_uc_36b + "', '" +
                var_uc_37a + "', '" +
                uc_37a_a.Text + "', '" +
                var_uc_37b + "', '" +
                LA_17.Text + "', '" +
                LA_18.Text + "', '" +
                txtOtherOrganism.Text + "', '" +
                var_LA_20a_b + "', '" +
                LA_20a_a.Text + "', '" +
                var_LA_20b_a + "', '" +
                var_LA_21a_b + "', '" +
                LA_21a_a.Text + "', '" +
                var_LA_21b_a + "', '" +
                var_LA_22a_b + "', '" +
                LA_22a_a.Text + "', '" +
                var_LA_22b_a + "', '" +
                var_LA_23a_b + "', '" +
                LA_23a_a.Text + "', '" +
                var_LA_23b_a + "', '" +
                var_LA_24a_b + "', '" +
                LA_24a_a.Text + "', '" +
                var_LA_24b_a + "', '" +
                var_LA_25a_b + "', '" +
                LA_25a_a.Text + "', '" +
                var_LA_25b_a + "', '" +
                var_LA_26a_b + "', '" +
                LA_26a_a.Text + "', '" +
                var_LA_26b_a + "', '" +
                var_LA_27a_b + "', '" +
                LA_27a_a.Text + "', '" +
                var_LA_27b_a + "', '" +
                var_LA_28a_b + "', '" +
                LA_28a_a.Text + "', '" +
                var_LA_28b_a + "', '" +
                var_LA_29a_b + "', '" +
                LA_29a_a.Text + "', '" +
                var_LA_29b_a + "', '" +
                var_LA_30a_b + "', '" +
                LA_30a_a.Text + "', '" +
                var_LA_30b_a + "', '" +
                var_LA_31a_b + "', '" +
                LA_31a_a.Text + "', '" +
                var_LA_31b_a + "', '" +
                var_LA_32a_b + "', '" +
                LA_32a_a.Text + "', '" +
                var_LA_32b_a + "', '" +
                var_LA_33a_b + "', '" +
                LA_33a_a.Text + "', '" +
                var_LA_33b_a + "', '" +
                var_LA_34a_b + "', '" +
                LA_34a_a.Text + "', '" +
                var_LA_34b_a + "', '" +
                var_LA_35a_b + "', '" +
                LA_35a_a.Text + "', '" +
                var_LA_35b_a + "', '" +
                var_LA_36a_b + "', '" +
                LA_36a_a.Text + "', '" +
                var_LA_36b_a + "', '" +
                var_LA_37a_b + "', '" +
                LA_37a_a.Text + "', '" +
                var_LA_37b_a + "', '" +
                var_LA_38a_b + "', '" +
                LA_38a_a.Text + "', '" +
                var_LA_38b_a + "', '" +
                var_LA_39a_b + "', '" +
                LA_39a_a.Text + "', '" +
                var_LA_39b_a + "', '" +
                var_LA_40a_b + "', '" +
                LA_40a_a.Text + "', '" +
                var_LA_40b_a + "', '" +
                var_LA_41a_b + "', '" +
                LA_41a_a.Text + "', '" +
                var_LA_41b_a + "', '" +
                var_LA_42a_b + "', '" +
                LA_42a_a.Text + "', '" +
                var_LA_42b_a + "', '" +
                var_LA_43a_b + "', '" +
                LA_43a_a.Text + "', '" +
                var_LA_43b_a + "', '" +
                var_LA_44a_b + "', '" +
                LA_44a_a.Text + "', '" +
                var_LA_44b_a + "', '" +
                var_LA_45a_b + "', '" +
                LA_45a_a.Text + "', '" +
                var_LA_45b_a + "', '" +
                var_LA_46a_b + "', '" +
                LA_46a_a.Text + "', '" +
                var_LA_46b_a + "', '" +
                var_LA_47a_b + "', '" +
                LA_47a_a.Text + "', '" +
                var_LA_47b_a + "', '" +
                var_LA_48a_b + "', '" +
                LA_48a_a.Text + "', '" +
                var_LA_48b_a + "', '" +
                var_LA_49a_b + "', '" +
                LA_49a_a.Text + "', '" +
                var_LA_49b_a + "', '" +
                var_LA_50a_b + "', '" +
                LA_50a_a.Text + "', '" +
                var_LA_50b_a + "', '" +
                var_LA_51a_b + "', '" +
                LA_51a_a.Text + "', '" +
                var_LA_51b_a + "', '" +
                var_LA_52a_b + "', '" +
                LA_52a_a.Text + "', '" +
                var_LA_52b_a + "', '" +
                Session["userid"].ToString() + "', '" +
                val_entry + "', '" +
                HttpContext.Current.Request["labid"].ToString() + "', '" +
                ProvisionalResult.Text + "', '" +
                var_BloodCulture + "', '" +
                ddl_BloodCulture.SelectedIndex + "')";

                }
                else
                {

                    if (ddl_BloodCulture.Items[ddl_BloodCulture.SelectedIndex].Text == "Others")
                    {

                        qry = "insert into sample_result(" +
                "la_sno," +
                "LA_01," +
                "LA_02," +
                "LA_02a," +
                "LA_03_b," +
                "LA_03_a," +
                "LA_04_b," +
                "LA_04_a," +
                "LA_05_b," +
                "LA_05_a," +
                "LA_06_b," +
                "LA_06_a," +
                "LA_07_b," +
                "LA_07_a," +
                "LA_08_b," +
                "LA_08_a," +
                "LA_09_b," +
                "LA_09_a," +
                "LA_10_b," +
                "LA_10_a," +
                "LA_11_b," +
                "LA_11_a," +
                "LA_12_b," +
                "LA_12_a," +
                "LA_13_b," +
                "LA_13_a," +
                "LA_14_b," +
                "LA_14_a," +
                "LA_15_b," +
                "LA_15_a," +
                "LA_16_b," +
                "LA_16_a," +
                "LF_01," +
                "LF_01_a," +
                "LF_02," +
                "LF_02_a," +
                "LF_03," +
                "LF_03_a," +
                "LF_04," +
                "LF_04_a," +
                "LF_05," +
                "LF_05_a," +
                "LF_06," +
                "LF_06_a," +
                "LF_07," +
                "LF_07_a," +
                "RF_01," +
                "RF_01_a," +
                "RF_02," +
                "RF_02_a," +
                "RF_03," +
                "RF_03_a," +
                "RF_04," +
                "RF_04_a," +
                "SE_01," +
                "SE_01_a," +
                "SE_02," +
                "SE_02_a," +
                "SE_03," +
                "SE_03_a," +
                "SE_04," +
                "SE_04_a," +
                "CS_01," +
                "CS_01_a," +
                "CS_02," +
                "CS_02_a," +
                "CS_03," +
                "CS_03_a," +
                "CS_04," +
                "CS_04_a," +
                "CS_05," +
                "CS_05_a," +
                "CS_06," +
                "CS_06_a," +
                "CS_07," +
                "CS_07_a," +
                "CS_08," +
                "CS_08_a," +
                "CS_09," +
                "CS_09_a," +
                "CS_10," +
                "CS_10_a," +
                "UR_01," +
                "UR_01_a," +
                "UR_02," +
                "UR_02_a," +
                "UR_03," +
                "UR_03_a," +
                "UR_04," +
                "UR_04_a," +
                "UR_04a," +
                "UR_04a_a," +
                "UR_05," +
                "UR_05_a," +
                "UR_06," +
                "UR_06_a," +
                "UR_07," +
                "UR_07_a," +
                "UR_08," +
                "UR_08_a," +
                "UR_10," +
                "UR_10_a," +
                "UR_11," +
                "UR_11_a," +
                "UR_12," +
                "UR_12_a," +
                "UR_13," +
                "UR_13_a," +
                "UR_14," +
                "UR_14_a," +
                "UR_15," +
                "UR_15_a," +
                "UR_16," +
                "UR_16_a," +
                "UR_17," +
                "UR_17_a," +
                "UR_18," +
                "UR_18_a," +
                "UR_19," +
                "UR_19_a," +
                "UR_20," +
                "UR_20_a," +
                "UR_21," +
                "UR_21_a," +
                "uc_01a," +
                "uc_01_ca," +
                "uc_02a," +
                "uc_02a_a," +
                "uc_02b," +
                "uc_03a," +
                "uc_03a_a," +
                "uc_03b," +
                "uc_04a," +
                "uc_04a_a," +
                "uc_04b," +
                "uc_05a," +
                "uc_05a_a," +
                "uc_05b," +
                "uc_06a," +
                "uc_06a_a," +
                "uc_06b," +
                "uc_07a," +
                "uc_07a_a," +
                "uc_07b," +
                "uc_08a," +
                "uc_08a_a," +
                "uc_08b," +
                "uc_09a," +
                "uc_09a_a," +
                "uc_09b," +
                "uc_10a," +
                "uc_10a_a," +
                "uc_10b," +
                "uc_11a," +
                "uc_11a_a," +
                "uc_11b," +
                "uc_12a," +
                "uc_12a_a," +
                "uc_12b," +
                "uc_13a," +
                "uc_13a_a," +
                "uc_13b," +
                "uc_14a," +
                "uc_14a_a," +
                "uc_14b," +
                "uc_15a," +
                "uc_15a_a," +
                "uc_15b," +
                "uc_16a," +
                "uc_16a_a," +
                "uc_16b," +
                "uc_17a," +
                "uc_17a_a," +
                "uc_17b," +
                "uc_18a," +
                "uc_18a_a," +
                "uc_18b," +
                "uc_19a," +
                "uc_19a_a," +
                "uc_19b," +
                "uc_20a," +
                "uc_20a_a," +
                "uc_20b," +
                "uc_21a," +
                "uc_21a_a," +
                "uc_21b," +
                "uc_22a," +
                "uc_22a_a," +
                "uc_22b," +
                "uc_23a," +
                "uc_23a_a," +
                "uc_23b," +
                "uc_24a," +
                "uc_24a_a," +
                "uc_24b," +
                "uc_25a," +
                "uc_25a_a," +
                "uc_25b," +
                "uc_26a," +
                "uc_26a_a," +
                "uc_26b," +
                "uc_27a," +
                "uc_27a_a," +
                "uc_27b," +
                "uc_28a," +
                "uc_28a_a," +
                "uc_28b," +
                "uc_29a," +
                "uc_29a_a," +
                "uc_29b," +
                "uc_30a," +
                "uc_30a_a," +
                "uc_30b," +
                "uc_31a," +
                "uc_31a_a," +
                "uc_31b," +
                "uc_32a," +
                "uc_32a_a," +
                "uc_32b," +
                "uc_33a," +
                "uc_33a_a," +
                "uc_33b," +
                "uc_34a," +
                "uc_34a_a," +
                "uc_34b," +
                "uc_35a," +
                "uc_35a_a," +
                "uc_35b," +
                "uc_36a," +
                "uc_36a_a," +
                "uc_36b," +
                "uc_37a," +
                "uc_37a_a," +
                "uc_37b," +
                "LA_17," +
                "LA_18," +
                "LA_19," +
                "LA_20a_b," +
                "LA_20a_a," +
                "LA_20b_a," +
                "LA_21a_b," +
                "LA_21a_a," +
                "LA_21b_a," +
                "LA_22a_b," +
                "LA_22a_a," +
                "LA_22b_a," +
                "LA_23a_b," +
                "LA_23a_a," +
                "LA_23b_a," +
                "LA_24a_b," +
                "LA_24a_a," +
                "LA_24b_a," +
                "LA_25a_b," +
                "LA_25a_a," +
                "LA_25b_a," +
                "LA_26a_b," +
                "LA_26a_a," +
                "LA_26b_a," +
                "LA_27a_b," +
                "LA_27a_a," +
                "LA_27b_a," +
                "LA_28a_b," +
                "LA_28a_a," +
                "LA_28b_a," +
                "LA_29a_b," +
                "LA_29a_a," +
                "LA_29b_a," +
                "LA_30a_b," +
                "LA_30a_a," +
                "LA_30b_a," +
                "LA_31a_b," +
                "LA_31a_a," +
                "LA_31b_a," +
                "LA_32a_b," +
                "LA_32a_a," +
                "LA_32b_a," +
                "LA_33a_b," +
                "LA_33a_a," +
                "LA_33b_a," +
                "LA_34a_b," +
                "LA_34a_a," +
                "LA_34b_a," +
                "LA_35a_b," +
                "LA_35a_a," +
                "LA_35b_a," +
                "LA_36a_b," +
                "LA_36a_a," +
                "LA_36b_a," +
                "LA_37a_b," +
                "LA_37a_a," +
                "LA_37b_a," +
                "LA_38a_b," +
                "LA_38a_a," +
                "LA_38b_a," +
                "LA_39a_b," +
                "LA_39a_a," +
                "LA_39b_a," +
                "LA_40a_b," +
                "LA_40a_a," +
                "LA_40b_a," +
                "LA_41a_b," +
                "LA_41a_a," +
                "LA_41b_a," +
                "LA_42a_b," +
                "LA_42a_a," +
                "LA_42b_a," +
                "LA_43a_b," +
                "LA_43a_a," +
                "LA_43b_a," +
                "LA_44a_b," +
                "LA_44a_a," +
                "LA_44b_a," +
                "LA_45a_b," +
                "LA_45a_a," +
                "LA_45b_a," +
                "LA_46a_b," +
                "LA_46a_a," +
                "LA_46b_a," +
                "LA_47a_b," +
                "LA_47a_a," +
                "LA_47b_a," +
                "LA_48a_b," +
                "LA_48a_a," +
                "LA_48b_a," +
                "LA_49a_b," +
                "LA_49a_a," +
                "LA_49b_a," +
                "LA_50a_b," +
                "LA_50a_a," +
                "LA_50b_a," +
                "LA_51a_b," +
                "LA_51a_a," +
                "LA_51b_a," +
                "LA_52a_b," +
                "LA_52a_a," +
                "LA_52b_a," +
                "UserID," +
                "EntryDate," +
                "labid," +
                "ProvisionalResult," +
                "rdo_BloodCulture," +
                "ddl_BloodCulture) values('" +
                la_sno.Text + "', '" +
                LA_01.Text + "', '" +
                LA_02.Text + "', '" +
                LA_02a.Text + "', '" +
                var_LA_03_b + "', '" +
                LA_03_a.Text + "', '" +
                var_LA_04_b + "', '" +
                LA_04_a.Text + "', '" +
                var_LA_05_b + "', '" +
                LA_05_a.Text + "', '" +
                var_LA_06_b + "', '" +
                LA_06_a.Text + "', '" +
                var_LA_07_b + "', '" +
                LA_07_a.Text + "', '" +
                var_LA_08_b + "', '" +
                LA_08_a.Text + "', '" +
                var_LA_09_b + "', '" +
                LA_09_a.Text + "', '" +
                var_LA_10_b + "', '" +
                LA_10_a.Text + "', '" +
                var_LA_11_b + "', '" +
                LA_11_a.Text + "', '" +
                var_LA_12_b + "', '" +
                LA_12_a.Text + "', '" +
                var_LA_13_b + "', '" +
                LA_13_a.Text + "', '" +
                var_LA_14_b + "', '" +
                LA_14_a.Text + "', '" +
                var_LA_15_b + "', '" +
                LA_15_a.Text + "', '" +
                var_LA_16_b + "', '" +
                LA_16_a.Text + "', '" +
                var_LF_01 + "', '" +
                LF_01_a.Text + "', '" +
                var_LF_02 + "', '" +
                LF_02_a.Text + "', '" +
                var_LF_03 + "', '" +
                LF_03_a.Text + "', '" +
                var_LF_04 + "', '" +
                LF_04_a.Text + "', '" +
                var_LF_05 + "', '" +
                LF_05_a.Text + "', '" +
                var_LF_06 + "', '" +
                LF_06_a.Text + "', '" +
                var_LF_07 + "', '" +
                LF_07_a.Text + "', '" +
                var_RF_01 + "', '" +
                RF_01_a.Text + "', '" +
                var_RF_02 + "', '" +
                RF_02_a.Text + "', '" +
                var_RF_03 + "', '" +
                RF_03_a.Text + "', '" +
                var_RF_04 + "', '" +
                RF_04_a.Text + "', '" +
                var_SE_01 + "', '" +
                SE_01_a.Text + "', '" +
                var_SE_02 + "', '" +
                SE_02_a.Text + "', '" +
                var_SE_03 + "', '" +
                SE_03_a.Text + "', '" +
                var_SE_04 + "', '" +
                SE_04_a.Text + "', '" +
                var_CS_01 + "', '" +
                CS_01_a.Text + "', '" +
                var_CS_02 + "', '" +
                CS_02_a.Text + "', '" +
                var_CS_03 + "', '" +
                CS_03_a.Text + "', '" +
                var_CS_04 + "', '" +
                CS_04_a.Text + "', '" +
                var_CS_05 + "', '" +
                CS_05_a.Text + "', '" +
                var_CS_06 + "', '" +
                CS_06_a.Text + "', '" +
                var_CS_07 + "', '" +
                CS_07_a.Text + "', '" +
                var_CS_08 + "', '" +
                CS_08_a.Text + "', '" +
                var_CS_09 + "', '" +
                CS_09_a.Text + "', '" +
                var_CS_10 + "', '" +
                CS_10_a.Text + "', '" +
                var_UR_01 + "', '" +
                UR_01_a.Text + "', '" +
                var_UR_02 + "', '" +
                UR_02_a.Text + "', '" +
                var_UR_03 + "', '" +
                UR_03_a.Text + "', '" +
                var_UR_04 + "', '" +
                UR_04_a.Text + "', '" +
                var_UR_04a + "', '" +
                UR_04a_a.Text + "', '" +
                var_UR_05 + "', '" +
                UR_05_a.Text + "', '" +
                var_UR_06 + "', '" +
                UR_06_a.Text + "', '" +
                var_UR_07 + "', '" +
                UR_07_a.Text + "', '" +
                var_UR_08 + "', '" +
                UR_08_a.Text + "', '" +
                var_UR_10 + "', '" +
                UR_10_a.Text + "', '" +
                var_UR_11 + "', '" +
                UR_11_a.Text + "', '" +
                var_UR_12 + "', '" +
                UR_12_a.Text + "', '" +
                var_UR_13 + "', '" +
                UR_13_a.Text + "', '" +
                var_UR_14 + "', '" +
                UR_14_a.Text + "', '" +
                var_UR_15 + "', '" +
                UR_15_a.Text + "', '" +
                var_UR_16 + "', '" +
                UR_16_a.Text + "', '" +
                var_UR_17 + "', '" +
                UR_17_a.Text + "', '" +
                var_UR_18 + "', '" +
                UR_18_a.Text + "', '" +
                var_UR_19 + "', '" +
                UR_19_a.Text + "', '" +
                var_UR_20 + "', '" +
                UR_20_a.Text + "', '" +
                var_UR_21 + "', '" +
                UR_21_a.Text + "', '" +
                var_uc_01a + "', '" +
                uc_01_ca.Text + "', '" +
                var_uc_02a + "', '" +
                uc_02a_a.Text + "', '" +
                var_uc_02b + "', '" +
                var_uc_03a + "', '" +
                uc_03a_a.Text + "', '" +
                var_uc_03b + "', '" +
                var_uc_04a + "', '" +
                uc_04a_a.Text + "', '" +
                var_uc_04b + "', '" +
                var_uc_05a + "', '" +
                uc_05a_a.Text + "', '" +
                var_uc_05b + "', '" +
                var_uc_06a + "', '" +
                uc_06a_a.Text + "', '" +
                var_uc_06b + "', '" +
                var_uc_07a + "', '" +
                uc_07a_a.Text + "', '" +
                var_uc_07b + "', '" +
                var_uc_08a + "', '" +
                uc_08a_a.Text + "', '" +
                var_uc_08b + "', '" +
                var_uc_09a + "', '" +
                uc_09a_a.Text + "', '" +
                var_uc_09b + "', '" +
                var_uc_10a + "', '" +
                uc_10a_a.Text + "', '" +
                var_uc_10b + "', '" +
                var_uc_11a + "', '" +
                uc_11a_a.Text + "', '" +
                var_uc_11b + "', '" +
                var_uc_12a + "', '" +
                uc_12a_a.Text + "', '" +
                var_uc_12b + "', '" +
                var_uc_13a + "', '" +
                uc_13a_a.Text + "', '" +
                var_uc_13b + "', '" +
                var_uc_14a + "', '" +
                uc_14a_a.Text + "', '" +
                var_uc_14b + "', '" +
                var_uc_15a + "', '" +
                uc_15a_a.Text + "', '" +
                var_uc_15b + "', '" +
                var_uc_16a + "', '" +
                uc_16a_a.Text + "', '" +
                var_uc_16b + "', '" +
                var_uc_17a + "', '" +
                uc_17a_a.Text + "', '" +
                var_uc_17b + "', '" +
                var_uc_18a + "', '" +
                uc_18a_a.Text + "', '" +
                var_uc_18b + "', '" +
                var_uc_19a + "', '" +
                uc_19a_a.Text + "', '" +
                var_uc_19b + "', '" +
                var_uc_20a + "', '" +
                uc_20a_a.Text + "', '" +
                var_uc_20b + "', '" +
                var_uc_21a + "', '" +
                uc_21a_a.Text + "', '" +
                var_uc_21b + "', '" +
                var_uc_22a + "', '" +
                uc_22a_a.Text + "', '" +
                var_uc_22b + "', '" +
                var_uc_23a + "', '" +
                uc_23a_a.Text + "', '" +
                var_uc_23b + "', '" +
                var_uc_24a + "', '" +
                uc_24a_a.Text + "', '" +
                var_uc_24b + "', '" +
                var_uc_25a + "', '" +
                uc_25a_a.Text + "', '" +
                var_uc_25b + "', '" +
                var_uc_26a + "', '" +
                uc_26a_a.Text + "', '" +
                var_uc_26b + "', '" +
                var_uc_27a + "', '" +
                uc_27a_a.Text + "', '" +
                var_uc_27b + "', '" +
                var_uc_28a + "', '" +
                uc_28a_a.Text + "', '" +
                var_uc_28b + "', '" +
                var_uc_29a + "', '" +
                uc_29a_a.Text + "', '" +
                var_uc_29b + "', '" +
                var_uc_30a + "', '" +
                uc_30a_a.Text + "', '" +
                var_uc_30b + "', '" +
                var_uc_31a + "', '" +
                uc_31a_a.Text + "', '" +
                var_uc_31b + "', '" +
                var_uc_32a + "', '" +
                uc_32a_a.Text + "', '" +
                var_uc_32b + "', '" +
                var_uc_33a + "', '" +
                uc_33a_a.Text + "', '" +
                var_uc_33b + "', '" +
                var_uc_34a + "', '" +
                uc_34a_a.Text + "', '" +
                var_uc_34b + "', '" +
                var_uc_35a + "', '" +
                uc_35a_a.Text + "', '" +
                var_uc_35b + "', '" +
                var_uc_36a + "', '" +
                uc_36a_a.Text + "', '" +
                var_uc_36b + "', '" +
                var_uc_37a + "', '" +
                uc_37a_a.Text + "', '" +
                var_uc_37b + "', '" +
                LA_17.Text + "', '" +
                LA_18.Text + "', '" +
                txtOtherOrganism.Text + "', '" +
                var_LA_20a_b + "', '" +
                LA_20a_a.Text + "', '" +
                var_LA_20b_a + "', '" +
                var_LA_21a_b + "', '" +
                LA_21a_a.Text + "', '" +
                var_LA_21b_a + "', '" +
                var_LA_22a_b + "', '" +
                LA_22a_a.Text + "', '" +
                var_LA_22b_a + "', '" +
                var_LA_23a_b + "', '" +
                LA_23a_a.Text + "', '" +
                var_LA_23b_a + "', '" +
                var_LA_24a_b + "', '" +
                LA_24a_a.Text + "', '" +
                var_LA_24b_a + "', '" +
                var_LA_25a_b + "', '" +
                LA_25a_a.Text + "', '" +
                var_LA_25b_a + "', '" +
                var_LA_26a_b + "', '" +
                LA_26a_a.Text + "', '" +
                var_LA_26b_a + "', '" +
                var_LA_27a_b + "', '" +
                LA_27a_a.Text + "', '" +
                var_LA_27b_a + "', '" +
                var_LA_28a_b + "', '" +
                LA_28a_a.Text + "', '" +
                var_LA_28b_a + "', '" +
                var_LA_29a_b + "', '" +
                LA_29a_a.Text + "', '" +
                var_LA_29b_a + "', '" +
                var_LA_30a_b + "', '" +
                LA_30a_a.Text + "', '" +
                var_LA_30b_a + "', '" +
                var_LA_31a_b + "', '" +
                LA_31a_a.Text + "', '" +
                var_LA_31b_a + "', '" +
                var_LA_32a_b + "', '" +
                LA_32a_a.Text + "', '" +
                var_LA_32b_a + "', '" +
                var_LA_33a_b + "', '" +
                LA_33a_a.Text + "', '" +
                var_LA_33b_a + "', '" +
                var_LA_34a_b + "', '" +
                LA_34a_a.Text + "', '" +
                var_LA_34b_a + "', '" +
                var_LA_35a_b + "', '" +
                LA_35a_a.Text + "', '" +
                var_LA_35b_a + "', '" +
                var_LA_36a_b + "', '" +
                LA_36a_a.Text + "', '" +
                var_LA_36b_a + "', '" +
                var_LA_37a_b + "', '" +
                LA_37a_a.Text + "', '" +
                var_LA_37b_a + "', '" +
                var_LA_38a_b + "', '" +
                LA_38a_a.Text + "', '" +
                var_LA_38b_a + "', '" +
                var_LA_39a_b + "', '" +
                LA_39a_a.Text + "', '" +
                var_LA_39b_a + "', '" +
                var_LA_40a_b + "', '" +
                LA_40a_a.Text + "', '" +
                var_LA_40b_a + "', '" +
                var_LA_41a_b + "', '" +
                LA_41a_a.Text + "', '" +
                var_LA_41b_a + "', '" +
                var_LA_42a_b + "', '" +
                LA_42a_a.Text + "', '" +
                var_LA_42b_a + "', '" +
                var_LA_43a_b + "', '" +
                LA_43a_a.Text + "', '" +
                var_LA_43b_a + "', '" +
                var_LA_44a_b + "', '" +
                LA_44a_a.Text + "', '" +
                var_LA_44b_a + "', '" +
                var_LA_45a_b + "', '" +
                LA_45a_a.Text + "', '" +
                var_LA_45b_a + "', '" +
                var_LA_46a_b + "', '" +
                LA_46a_a.Text + "', '" +
                var_LA_46b_a + "', '" +
                var_LA_47a_b + "', '" +
                LA_47a_a.Text + "', '" +
                var_LA_47b_a + "', '" +
                var_LA_48a_b + "', '" +
                LA_48a_a.Text + "', '" +
                var_LA_48b_a + "', '" +
                var_LA_49a_b + "', '" +
                LA_49a_a.Text + "', '" +
                var_LA_49b_a + "', '" +
                var_LA_50a_b + "', '" +
                LA_50a_a.Text + "', '" +
                var_LA_50b_a + "', '" +
                var_LA_51a_b + "', '" +
                LA_51a_a.Text + "', '" +
                var_LA_51b_a + "', '" +
                var_LA_52a_b + "', '" +
                LA_52a_a.Text + "', '" +
                var_LA_52b_a + "', '" +
                Session["userid"].ToString() + "', '" +
                val_entry + "', '" +
                HttpContext.Current.Request["labid"].ToString() + "', '" +
                ProvisionalResult.Text + "', '" +
                var_BloodCulture + "', '" +
                ddl_BloodCulture.SelectedIndex + "')";

                    }
                    else
                    {

                        qry = "insert into sample_result(" +
            "la_sno," +
            "LA_01," +
            "LA_02," +
            "LA_02a," +
            "LA_03_b," +
            "LA_03_a," +
            "LA_04_b," +
            "LA_04_a," +
            "LA_05_b," +
            "LA_05_a," +
            "LA_06_b," +
            "LA_06_a," +
            "LA_07_b," +
            "LA_07_a," +
            "LA_08_b," +
            "LA_08_a," +
            "LA_09_b," +
            "LA_09_a," +
            "LA_10_b," +
            "LA_10_a," +
            "LA_11_b," +
            "LA_11_a," +
            "LA_12_b," +
            "LA_12_a," +
            "LA_13_b," +
            "LA_13_a," +
            "LA_14_b," +
            "LA_14_a," +
            "LA_15_b," +
            "LA_15_a," +
            "LA_16_b," +
            "LA_16_a," +
            "LF_01," +
            "LF_01_a," +
            "LF_02," +
            "LF_02_a," +
            "LF_03," +
            "LF_03_a," +
            "LF_04," +
            "LF_04_a," +
            "LF_05," +
            "LF_05_a," +
            "LF_06," +
            "LF_06_a," +
            "LF_07," +
            "LF_07_a," +
            "RF_01," +
            "RF_01_a," +
            "RF_02," +
            "RF_02_a," +
            "RF_03," +
            "RF_03_a," +
            "RF_04," +
            "RF_04_a," +
            "SE_01," +
            "SE_01_a," +
            "SE_02," +
            "SE_02_a," +
            "SE_03," +
            "SE_03_a," +
            "SE_04," +
            "SE_04_a," +
            "CS_01," +
            "CS_01_a," +
            "CS_02," +
            "CS_02_a," +
            "CS_03," +
            "CS_03_a," +
            "CS_04," +
            "CS_04_a," +
            "CS_05," +
            "CS_05_a," +
            "CS_06," +
            "CS_06_a," +
            "CS_07," +
            "CS_07_a," +
            "CS_08," +
            "CS_08_a," +
            "CS_09," +
            "CS_09_a," +
            "CS_10," +
            "CS_10_a," +
            "UR_01," +
            "UR_01_a," +
            "UR_02," +
            "UR_02_a," +
            "UR_03," +
            "UR_03_a," +
            "UR_04," +
            "UR_04_a," +
            "UR_04a," +
            "UR_04a_a," +
            "UR_05," +
            "UR_05_a," +
            "UR_06," +
            "UR_06_a," +
            "UR_07," +
            "UR_07_a," +
            "UR_08," +
            "UR_08_a," +
            "UR_10," +
            "UR_10_a," +
            "UR_11," +
            "UR_11_a," +
            "UR_12," +
            "UR_12_a," +
            "UR_13," +
            "UR_13_a," +
            "UR_14," +
            "UR_14_a," +
            "UR_15," +
            "UR_15_a," +
            "UR_16," +
            "UR_16_a," +
            "UR_17," +
            "UR_17_a," +
            "UR_18," +
            "UR_18_a," +
            "UR_19," +
            "UR_19_a," +
            "UR_20," +
            "UR_20_a," +
            "UR_21," +
            "UR_21_a," +
            "uc_01a," +
            "uc_01_ca," +
            "uc_02a," +
            "uc_02a_a," +
            "uc_02b," +
            "uc_03a," +
            "uc_03a_a," +
            "uc_03b," +
            "uc_04a," +
            "uc_04a_a," +
            "uc_04b," +
            "uc_05a," +
            "uc_05a_a," +
            "uc_05b," +
            "uc_06a," +
            "uc_06a_a," +
            "uc_06b," +
            "uc_07a," +
            "uc_07a_a," +
            "uc_07b," +
            "uc_08a," +
            "uc_08a_a," +
            "uc_08b," +
            "uc_09a," +
            "uc_09a_a," +
            "uc_09b," +
            "uc_10a," +
            "uc_10a_a," +
            "uc_10b," +
            "uc_11a," +
            "uc_11a_a," +
            "uc_11b," +
            "uc_12a," +
            "uc_12a_a," +
            "uc_12b," +
            "uc_13a," +
            "uc_13a_a," +
            "uc_13b," +
            "uc_14a," +
            "uc_14a_a," +
            "uc_14b," +
            "uc_15a," +
            "uc_15a_a," +
            "uc_15b," +
            "uc_16a," +
            "uc_16a_a," +
            "uc_16b," +
            "uc_17a," +
            "uc_17a_a," +
            "uc_17b," +
            "uc_18a," +
            "uc_18a_a," +
            "uc_18b," +
            "uc_19a," +
            "uc_19a_a," +
            "uc_19b," +
            "uc_20a," +
            "uc_20a_a," +
            "uc_20b," +
            "uc_21a," +
            "uc_21a_a," +
            "uc_21b," +
            "uc_22a," +
            "uc_22a_a," +
            "uc_22b," +
            "uc_23a," +
            "uc_23a_a," +
            "uc_23b," +
            "uc_24a," +
            "uc_24a_a," +
            "uc_24b," +
            "uc_25a," +
            "uc_25a_a," +
            "uc_25b," +
            "uc_26a," +
            "uc_26a_a," +
            "uc_26b," +
            "uc_27a," +
            "uc_27a_a," +
            "uc_27b," +
            "uc_28a," +
            "uc_28a_a," +
            "uc_28b," +
            "uc_29a," +
            "uc_29a_a," +
            "uc_29b," +
            "uc_30a," +
            "uc_30a_a," +
            "uc_30b," +
            "uc_31a," +
            "uc_31a_a," +
            "uc_31b," +
            "uc_32a," +
            "uc_32a_a," +
            "uc_32b," +
            "uc_33a," +
            "uc_33a_a," +
            "uc_33b," +
            "uc_34a," +
            "uc_34a_a," +
            "uc_34b," +
            "uc_35a," +
            "uc_35a_a," +
            "uc_35b," +
            "uc_36a," +
            "uc_36a_a," +
            "uc_36b," +
            "uc_37a," +
            "uc_37a_a," +
            "uc_37b," +
            "LA_17," +
            "LA_18," +
            "LA_19," +
            "LA_20a_b," +
            "LA_20a_a," +
            "LA_20b_a," +
            "LA_21a_b," +
            "LA_21a_a," +
            "LA_21b_a," +
            "LA_22a_b," +
            "LA_22a_a," +
            "LA_22b_a," +
            "LA_23a_b," +
            "LA_23a_a," +
            "LA_23b_a," +
            "LA_24a_b," +
            "LA_24a_a," +
            "LA_24b_a," +
            "LA_25a_b," +
            "LA_25a_a," +
            "LA_25b_a," +
            "LA_26a_b," +
            "LA_26a_a," +
            "LA_26b_a," +
            "LA_27a_b," +
            "LA_27a_a," +
            "LA_27b_a," +
            "LA_28a_b," +
            "LA_28a_a," +
            "LA_28b_a," +
            "LA_29a_b," +
            "LA_29a_a," +
            "LA_29b_a," +
            "LA_30a_b," +
            "LA_30a_a," +
            "LA_30b_a," +
            "LA_31a_b," +
            "LA_31a_a," +
            "LA_31b_a," +
            "LA_32a_b," +
            "LA_32a_a," +
            "LA_32b_a," +
            "LA_33a_b," +
            "LA_33a_a," +
            "LA_33b_a," +
            "LA_34a_b," +
            "LA_34a_a," +
            "LA_34b_a," +
            "LA_35a_b," +
            "LA_35a_a," +
            "LA_35b_a," +
            "LA_36a_b," +
            "LA_36a_a," +
            "LA_36b_a," +
            "LA_37a_b," +
            "LA_37a_a," +
            "LA_37b_a," +
            "LA_38a_b," +
            "LA_38a_a," +
            "LA_38b_a," +
            "LA_39a_b," +
            "LA_39a_a," +
            "LA_39b_a," +
            "LA_40a_b," +
            "LA_40a_a," +
            "LA_40b_a," +
            "LA_41a_b," +
            "LA_41a_a," +
            "LA_41b_a," +
            "LA_42a_b," +
            "LA_42a_a," +
            "LA_42b_a," +
            "LA_43a_b," +
            "LA_43a_a," +
            "LA_43b_a," +
            "LA_44a_b," +
            "LA_44a_a," +
            "LA_44b_a," +
            "LA_45a_b," +
            "LA_45a_a," +
            "LA_45b_a," +
            "LA_46a_b," +
            "LA_46a_a," +
            "LA_46b_a," +
            "LA_47a_b," +
            "LA_47a_a," +
            "LA_47b_a," +
            "LA_48a_b," +
            "LA_48a_a," +
            "LA_48b_a," +
            "LA_49a_b," +
            "LA_49a_a," +
            "LA_49b_a," +
            "LA_50a_b," +
            "LA_50a_a," +
            "LA_50b_a," +
            "LA_51a_b," +
            "LA_51a_a," +
            "LA_51b_a," +
            "LA_52a_b," +
            "LA_52a_a," +
            "LA_52b_a," +
            "UserID," +
            "EntryDate," +
            "labid," +
            "ProvisionalResult," +
            "rdo_BloodCulture," +
            "ddl_BloodCulture) values('" +
            la_sno.Text + "', '" +
            LA_01.Text + "', '" +
            LA_02.Text + "', '" +
            LA_02a.Text + "', '" +
            var_LA_03_b + "', '" +
            LA_03_a.Text + "', '" +
            var_LA_04_b + "', '" +
            LA_04_a.Text + "', '" +
            var_LA_05_b + "', '" +
            LA_05_a.Text + "', '" +
            var_LA_06_b + "', '" +
            LA_06_a.Text + "', '" +
            var_LA_07_b + "', '" +
            LA_07_a.Text + "', '" +
            var_LA_08_b + "', '" +
            LA_08_a.Text + "', '" +
            var_LA_09_b + "', '" +
            LA_09_a.Text + "', '" +
            var_LA_10_b + "', '" +
            LA_10_a.Text + "', '" +
            var_LA_11_b + "', '" +
            LA_11_a.Text + "', '" +
            var_LA_12_b + "', '" +
            LA_12_a.Text + "', '" +
            var_LA_13_b + "', '" +
            LA_13_a.Text + "', '" +
            var_LA_14_b + "', '" +
            LA_14_a.Text + "', '" +
            var_LA_15_b + "', '" +
            LA_15_a.Text + "', '" +
            var_LA_16_b + "', '" +
            LA_16_a.Text + "', '" +
            var_LF_01 + "', '" +
            LF_01_a.Text + "', '" +
            var_LF_02 + "', '" +
            LF_02_a.Text + "', '" +
            var_LF_03 + "', '" +
            LF_03_a.Text + "', '" +
            var_LF_04 + "', '" +
            LF_04_a.Text + "', '" +
            var_LF_05 + "', '" +
            LF_05_a.Text + "', '" +
            var_LF_06 + "', '" +
            LF_06_a.Text + "', '" +
            var_LF_07 + "', '" +
            LF_07_a.Text + "', '" +
            var_RF_01 + "', '" +
            RF_01_a.Text + "', '" +
            var_RF_02 + "', '" +
            RF_02_a.Text + "', '" +
            var_RF_03 + "', '" +
            RF_03_a.Text + "', '" +
            var_RF_04 + "', '" +
            RF_04_a.Text + "', '" +
            var_SE_01 + "', '" +
            SE_01_a.Text + "', '" +
            var_SE_02 + "', '" +
            SE_02_a.Text + "', '" +
            var_SE_03 + "', '" +
            SE_03_a.Text + "', '" +
            var_SE_04 + "', '" +
            SE_04_a.Text + "', '" +
            var_CS_01 + "', '" +
            CS_01_a.Text + "', '" +
            var_CS_02 + "', '" +
            CS_02_a.Text + "', '" +
            var_CS_03 + "', '" +
            CS_03_a.Text + "', '" +
            var_CS_04 + "', '" +
            CS_04_a.Text + "', '" +
            var_CS_05 + "', '" +
            CS_05_a.Text + "', '" +
            var_CS_06 + "', '" +
            CS_06_a.Text + "', '" +
            var_CS_07 + "', '" +
            CS_07_a.Text + "', '" +
            var_CS_08 + "', '" +
            CS_08_a.Text + "', '" +
            var_CS_09 + "', '" +
            CS_09_a.Text + "', '" +
            var_CS_10 + "', '" +
            CS_10_a.Text + "', '" +
            var_UR_01 + "', '" +
            UR_01_a.Text + "', '" +
            var_UR_02 + "', '" +
            UR_02_a.Text + "', '" +
            var_UR_03 + "', '" +
            UR_03_a.Text + "', '" +
            var_UR_04 + "', '" +
            UR_04_a.Text + "', '" +
            var_UR_04a + "', '" +
            UR_04a_a.Text + "', '" +
            var_UR_05 + "', '" +
            UR_05_a.Text + "', '" +
            var_UR_06 + "', '" +
            UR_06_a.Text + "', '" +
            var_UR_07 + "', '" +
            UR_07_a.Text + "', '" +
            var_UR_08 + "', '" +
            UR_08_a.Text + "', '" +
            var_UR_10 + "', '" +
            UR_10_a.Text + "', '" +
            var_UR_11 + "', '" +
            UR_11_a.Text + "', '" +
            var_UR_12 + "', '" +
            UR_12_a.Text + "', '" +
            var_UR_13 + "', '" +
            UR_13_a.Text + "', '" +
            var_UR_14 + "', '" +
            UR_14_a.Text + "', '" +
            var_UR_15 + "', '" +
            UR_15_a.Text + "', '" +
            var_UR_16 + "', '" +
            UR_16_a.Text + "', '" +
            var_UR_17 + "', '" +
            UR_17_a.Text + "', '" +
            var_UR_18 + "', '" +
            UR_18_a.Text + "', '" +
            var_UR_19 + "', '" +
            UR_19_a.Text + "', '" +
            var_UR_20 + "', '" +
            UR_20_a.Text + "', '" +
            var_UR_21 + "', '" +
            UR_21_a.Text + "', '" +
            var_uc_01a + "', '" +
            uc_01_ca.Text + "', '" +
            var_uc_02a + "', '" +
            uc_02a_a.Text + "', '" +
            var_uc_02b + "', '" +
            var_uc_03a + "', '" +
            uc_03a_a.Text + "', '" +
            var_uc_03b + "', '" +
            var_uc_04a + "', '" +
            uc_04a_a.Text + "', '" +
            var_uc_04b + "', '" +
            var_uc_05a + "', '" +
            uc_05a_a.Text + "', '" +
            var_uc_05b + "', '" +
            var_uc_06a + "', '" +
            uc_06a_a.Text + "', '" +
            var_uc_06b + "', '" +
            var_uc_07a + "', '" +
            uc_07a_a.Text + "', '" +
            var_uc_07b + "', '" +
            var_uc_08a + "', '" +
            uc_08a_a.Text + "', '" +
            var_uc_08b + "', '" +
            var_uc_09a + "', '" +
            uc_09a_a.Text + "', '" +
            var_uc_09b + "', '" +
            var_uc_10a + "', '" +
            uc_10a_a.Text + "', '" +
            var_uc_10b + "', '" +
            var_uc_11a + "', '" +
            uc_11a_a.Text + "', '" +
            var_uc_11b + "', '" +
            var_uc_12a + "', '" +
            uc_12a_a.Text + "', '" +
            var_uc_12b + "', '" +
            var_uc_13a + "', '" +
            uc_13a_a.Text + "', '" +
            var_uc_13b + "', '" +
            var_uc_14a + "', '" +
            uc_14a_a.Text + "', '" +
            var_uc_14b + "', '" +
            var_uc_15a + "', '" +
            uc_15a_a.Text + "', '" +
            var_uc_15b + "', '" +
            var_uc_16a + "', '" +
            uc_16a_a.Text + "', '" +
            var_uc_16b + "', '" +
            var_uc_17a + "', '" +
            uc_17a_a.Text + "', '" +
            var_uc_17b + "', '" +
            var_uc_18a + "', '" +
            uc_18a_a.Text + "', '" +
            var_uc_18b + "', '" +
            var_uc_19a + "', '" +
            uc_19a_a.Text + "', '" +
            var_uc_19b + "', '" +
            var_uc_20a + "', '" +
            uc_20a_a.Text + "', '" +
            var_uc_20b + "', '" +
            var_uc_21a + "', '" +
            uc_21a_a.Text + "', '" +
            var_uc_21b + "', '" +
            var_uc_22a + "', '" +
            uc_22a_a.Text + "', '" +
            var_uc_22b + "', '" +
            var_uc_23a + "', '" +
            uc_23a_a.Text + "', '" +
            var_uc_23b + "', '" +
            var_uc_24a + "', '" +
            uc_24a_a.Text + "', '" +
            var_uc_24b + "', '" +
            var_uc_25a + "', '" +
            uc_25a_a.Text + "', '" +
            var_uc_25b + "', '" +
            var_uc_26a + "', '" +
            uc_26a_a.Text + "', '" +
            var_uc_26b + "', '" +
            var_uc_27a + "', '" +
            uc_27a_a.Text + "', '" +
            var_uc_27b + "', '" +
            var_uc_28a + "', '" +
            uc_28a_a.Text + "', '" +
            var_uc_28b + "', '" +
            var_uc_29a + "', '" +
            uc_29a_a.Text + "', '" +
            var_uc_29b + "', '" +
            var_uc_30a + "', '" +
            uc_30a_a.Text + "', '" +
            var_uc_30b + "', '" +
            var_uc_31a + "', '" +
            uc_31a_a.Text + "', '" +
            var_uc_31b + "', '" +
            var_uc_32a + "', '" +
            uc_32a_a.Text + "', '" +
            var_uc_32b + "', '" +
            var_uc_33a + "', '" +
            uc_33a_a.Text + "', '" +
            var_uc_33b + "', '" +
            var_uc_34a + "', '" +
            uc_34a_a.Text + "', '" +
            var_uc_34b + "', '" +
            var_uc_35a + "', '" +
            uc_35a_a.Text + "', '" +
            var_uc_35b + "', '" +
            var_uc_36a + "', '" +
            uc_36a_a.Text + "', '" +
            var_uc_36b + "', '" +
            var_uc_37a + "', '" +
            uc_37a_a.Text + "', '" +
            var_uc_37b + "', '" +
            LA_17.Text + "', '" +
            LA_18.Text + "', '" +
            ddl_BloodCulture.Items[ddl_BloodCulture.SelectedIndex].Text + "', '" +
            var_LA_20a_b + "', '" +
            LA_20a_a.Text + "', '" +
            var_LA_20b_a + "', '" +
            var_LA_21a_b + "', '" +
            LA_21a_a.Text + "', '" +
            var_LA_21b_a + "', '" +
            var_LA_22a_b + "', '" +
            LA_22a_a.Text + "', '" +
            var_LA_22b_a + "', '" +
            var_LA_23a_b + "', '" +
            LA_23a_a.Text + "', '" +
            var_LA_23b_a + "', '" +
            var_LA_24a_b + "', '" +
            LA_24a_a.Text + "', '" +
            var_LA_24b_a + "', '" +
            var_LA_25a_b + "', '" +
            LA_25a_a.Text + "', '" +
            var_LA_25b_a + "', '" +
            var_LA_26a_b + "', '" +
            LA_26a_a.Text + "', '" +
            var_LA_26b_a + "', '" +
            var_LA_27a_b + "', '" +
            LA_27a_a.Text + "', '" +
            var_LA_27b_a + "', '" +
            var_LA_28a_b + "', '" +
            LA_28a_a.Text + "', '" +
            var_LA_28b_a + "', '" +
            var_LA_29a_b + "', '" +
            LA_29a_a.Text + "', '" +
            var_LA_29b_a + "', '" +
            var_LA_30a_b + "', '" +
            LA_30a_a.Text + "', '" +
            var_LA_30b_a + "', '" +
            var_LA_31a_b + "', '" +
            LA_31a_a.Text + "', '" +
            var_LA_31b_a + "', '" +
            var_LA_32a_b + "', '" +
            LA_32a_a.Text + "', '" +
            var_LA_32b_a + "', '" +
            var_LA_33a_b + "', '" +
            LA_33a_a.Text + "', '" +
            var_LA_33b_a + "', '" +
            var_LA_34a_b + "', '" +
            LA_34a_a.Text + "', '" +
            var_LA_34b_a + "', '" +
            var_LA_35a_b + "', '" +
            LA_35a_a.Text + "', '" +
            var_LA_35b_a + "', '" +
            var_LA_36a_b + "', '" +
            LA_36a_a.Text + "', '" +
            var_LA_36b_a + "', '" +
            var_LA_37a_b + "', '" +
            LA_37a_a.Text + "', '" +
            var_LA_37b_a + "', '" +
            var_LA_38a_b + "', '" +
            LA_38a_a.Text + "', '" +
            var_LA_38b_a + "', '" +
            var_LA_39a_b + "', '" +
            LA_39a_a.Text + "', '" +
            var_LA_39b_a + "', '" +
            var_LA_40a_b + "', '" +
            LA_40a_a.Text + "', '" +
            var_LA_40b_a + "', '" +
            var_LA_41a_b + "', '" +
            LA_41a_a.Text + "', '" +
            var_LA_41b_a + "', '" +
            var_LA_42a_b + "', '" +
            LA_42a_a.Text + "', '" +
            var_LA_42b_a + "', '" +
            var_LA_43a_b + "', '" +
            LA_43a_a.Text + "', '" +
            var_LA_43b_a + "', '" +
            var_LA_44a_b + "', '" +
            LA_44a_a.Text + "', '" +
            var_LA_44b_a + "', '" +
            var_LA_45a_b + "', '" +
            LA_45a_a.Text + "', '" +
            var_LA_45b_a + "', '" +
            var_LA_46a_b + "', '" +
            LA_46a_a.Text + "', '" +
            var_LA_46b_a + "', '" +
            var_LA_47a_b + "', '" +
            LA_47a_a.Text + "', '" +
            var_LA_47b_a + "', '" +
            var_LA_48a_b + "', '" +
            LA_48a_a.Text + "', '" +
            var_LA_48b_a + "', '" +
            var_LA_49a_b + "', '" +
            LA_49a_a.Text + "', '" +
            var_LA_49b_a + "', '" +
            var_LA_50a_b + "', '" +
            LA_50a_a.Text + "', '" +
            var_LA_50b_a + "', '" +
            var_LA_51a_b + "', '" +
            LA_51a_a.Text + "', '" +
            var_LA_51b_a + "', '" +
            var_LA_52a_b + "', '" +
            LA_52a_a.Text + "', '" +
            var_LA_52b_a + "', '" +
            Session["userid"].ToString() + "', '" +
            val_entry + "', '" +
            HttpContext.Current.Request["labid"].ToString() + "', '" +
            ProvisionalResult.Text + "', '" +
            var_BloodCulture + "', '" +
            ddl_BloodCulture.SelectedIndex + "')";

                    }

                }

            }

            //string msg = obj_op.ExecuteNonQuery_Message(fldname, fldvalue, "sp_AddSampleResult");
            string msg = obj_op.ExecuteNonQuery_Message_Qry(qry);

            if (string.IsNullOrEmpty(msg))
            {

                CConnection cn = new CConnection();
                SqlDataAdapter da = new SqlDataAdapter("select * from formstatus where AS1_screening_ID = '" + la_sno.Text + "' and labid='" + Request.Cookies["labid"].Value + "'", cn.cn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            UpdateFormStatus(formstatus);
                        }
                        else
                        {
                            AddFormStatus(formstatus);
                        }
                    }
                    else
                    {
                        AddFormStatus(formstatus);
                    }
                }
                else
                {
                    AddFormStatus(formstatus);
                }


                string message = "alert('Record saved successfully');window.location.href='sample_recv.aspx'";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
            }
            else
            {
                string message = "alert('" + msg.Replace("'", "") + "');";
                message = "alert('" + msg.Replace("\"", "") + "');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
            }


            LA_01.Focus();

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



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<CountryInfo> CheckScreeningID(string screeningid, string labid)
    {
        List<CountryInfo> CountryInformation = new List<CountryInfo>();

        try
        {
            //string[] fldname = { "screeningid", "fldvalue", "visitid" };
            //string[] fldvalue = { screeningid, "0", labid };

            //DataSet ds = ExecuteNonQuery(fldname, fldvalue, "sp_GetRecords");

            CConnection cn = new CConnection();


            SqlCommand cmd = new SqlCommand("SELECT [AS1_screening_ID]" +
      ",[AS1_rand_id]" +
      ",[AS1_name]" +
      ",case when[AS1_sex] = 1 then 'Male'" +
      "when[AS1_sex] = 2 then 'Female'" +
      "end[AS1_sex]" +
      ",[AS1_age]" +
      ",[AS1_barcode]" +
      ",case when[AS1_fsite] = 1 then 'AKU Kharadar Hospital'" +
      "when[AS1_fsite] = 2 then 'Sindh Govt. Children Hospital'" +
      "when[AS1_fsite] = 3 then 'Liyari General Hospital'" +
      "when[AS1_fsite] = 4 then 'Indus Korangi Hospital'" +
      "when[AS1_fsite] = 5 then 'NICH'" +
      "when[AS1_fsite] = 6 then 'Sheikh Saeed Memorial Hospital'" +
      "end[AS1_fsite]" +
      ",case when AS1_Q1_1 = 1 then 'RCT1'" +
      "when AS1_Q1_1 = 2 then 'RCT2'" +
      "end[AS1_Q1_1]" +
        "FROM [form1] where[AS1_screening_ID] = '" + screeningid + "' and labid='" + labid + "'", cn.cn);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


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


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<SampleResults> IsScreeningIDExists(string screeningid, string labid)
    {
        List<SampleResults> CountryInformation = new List<SampleResults>();

        try
        {
            string[] fldname = { "screeningid", "fldvalue", "visitid" };
            string[] fldvalue = { screeningid, "1", labid };


            CConnection cn = new CConnection();

            SqlCommand cmd = new SqlCommand("select * from sample_result where la_sno='" + screeningid + "' and labid='" + labid + "'", cn.cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            //DataSet ds = ExecuteNonQuery(fldname, fldvalue, "sp_GetRecords");

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            CountryInformation.Add(new SampleResults()
                            {
                                la_sno = dr["la_sno"].ToString()

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
        Response.Redirect("sample_results.aspx");
    }




    private bool IsValid(object sender, EventArgs e)
    {
        CDBOperations obj_op = new CDBOperations();

        //if (Session["mycookierole"].ToString() == "mdl")
        //{
        //    return true;
        //}


        try
        {

            if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_03_a'", LA_03_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_03_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_04_a'", LA_04_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_04_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_05_a'", LA_05_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_05_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_06_a'", LA_06_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_06_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_07_a'", LA_07_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_07_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_08_a'", LA_08_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_08_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_09_a'", LA_09_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_09_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_10_a'", LA_10_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_10_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_11_a'", LA_11_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_11_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_12_a'", LA_12_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_12_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_13_a'", LA_13_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_13_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_14_a'", LA_14_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_14_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_15_a'", LA_15_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_15_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_16_a'", LA_16_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_16_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LF_01_a'", LF_01_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LF_01_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LF_02_a'", LF_02_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LF_02_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LF_03_a'", LF_03_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LF_03_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LF_04_a'", LF_04_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LF_04_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LF_05_a'", LF_05_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LF_05_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LF_06_a'", LF_06_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LF_06_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LF_07_a'", LF_07_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LF_07_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'RF_01_a'", RF_01_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                RF_01_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'RF_02_a'", RF_02_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                RF_02_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'RF_03_a'", RF_03_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                RF_03_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'RF_04_a'", RF_04_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                RF_04_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'SE_01_a'", SE_01_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                SE_01_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'SE_02_a'", SE_02_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                SE_02_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'SE_03_a'", SE_03_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                SE_03_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'SE_04_a'", SE_04_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                SE_04_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'CS_01_a'", CS_01_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                CS_01_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'CS_02_a'", CS_02_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                CS_02_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'CS_03_a'", CS_03_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                CS_03_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'CS_04_a'", CS_04_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                CS_04_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'CS_05_a'", CS_05_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                CS_05_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'CS_06_a'", CS_06_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                CS_06_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'CS_07_a'", CS_07_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                CS_07_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'CS_08_a'", CS_08_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                CS_08_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'CS_09_a'", CS_09_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                CS_09_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'CS_10_a'", CS_10_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                CS_10_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_01_a'", UR_01_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_01_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_02_a'", UR_02_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_02_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_03_a'", UR_03_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_03_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_04_a'", UR_04_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_04_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_05_a'", UR_05_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_05_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_06_a'", UR_06_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_06_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_07_a'", UR_07_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_07_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_08_a'", UR_08_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_08_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_10_a'", UR_10_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_10_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_11_a'", UR_11_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_11_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_12_a'", UR_12_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_12_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_13_a'", UR_13_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_13_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_14_a'", UR_14_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_14_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_15_a'", UR_15_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_15_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_16_a'", UR_16_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_16_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_17_a'", UR_17_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_17_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_18_a'", UR_18_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_18_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_19_a'", UR_19_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_19_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_20_a'", UR_20_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_20_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'UR_21_a'", UR_21_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                UR_21_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_02a_a'", uc_02a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_02a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_03a_a'", uc_03a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_03a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_04a_a'", uc_04a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_04a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_05a_a'", uc_05a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_05a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_06a_a'", uc_06a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_06a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_07a_a'", uc_07a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_07a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_08a_a'", uc_08a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_08a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_09a_a'", uc_09a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_09a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_10a_a'", uc_10a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_10a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_11a_a'", uc_11a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_11a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_12a_a'", uc_12a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_12a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_13a_a'", uc_13a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_13a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_14a_a'", uc_14a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_14a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_15a_a'", uc_15a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_15a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_16a_a'", uc_16a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_16a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_17a_a'", uc_17a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_17a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_18a_a'", uc_18a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_18a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_19a_a'", uc_19a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_19a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_20a_a'", uc_20a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_20a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_21a_a'", uc_21a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_21a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_22a_a'", uc_22a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_22a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_23a_a'", uc_23a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_23a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_24a_a'", uc_24a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_24a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_25a_a'", uc_25a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_25a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_26a_a'", uc_26a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_26a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_27a_a'", uc_27a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_27a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_28a_a'", uc_28a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_28a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_29a_a'", uc_29a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_29a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_30a_a'", uc_30a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_30a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_31a_a'", uc_31a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_31a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_32a_a'", uc_32a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_32a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_33a_a'", uc_33a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_33a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_34a_a'", uc_34a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_34a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_35a_a'", uc_35a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_35a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_36a_a'", uc_36a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_36a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'uc_37a_a'", uc_37a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                uc_37a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_20a_a'", LA_20a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_20a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_21a_a'", LA_21a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_21a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_22a_a'", LA_22a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_22a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_23a_a'", LA_23a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_23a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_24a_a'", LA_24a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_24a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_25a_a'", LA_25a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_25a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_26a_a'", LA_26a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_26a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_27a_a'", LA_27a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_27a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_28a_a'", LA_28a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_28a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_29a_a'", LA_29a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_29a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_30a_a'", LA_30a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_30a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_31a_a'", LA_31a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_31a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_32a_a'", LA_32a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_32a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_33a_a'", LA_33a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_33a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_34a_a'", LA_34a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_34a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_35a_a'", LA_35a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_35a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_36a_a'", LA_36a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_36a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_37a_a'", LA_37a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_37a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_38a_a'", LA_38a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_38a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_39a_a'", LA_39a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_39a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_40a_a'", LA_40a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_40a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_41a_a'", LA_41a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_41a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_42a_a'", LA_42a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_42a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_43a_a'", LA_43a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_43a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_44a_a'", LA_44a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_44a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_45a_a'", LA_45a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_45a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_46a_a'", LA_46a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_46a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_47a_a'", LA_47a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_47a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_48a_a'", LA_48a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_48a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_49a_a'", LA_49a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_49a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_50a_a'", LA_50a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_50a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_51a_a'", LA_51a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_51a_a.Focus();
                return false;
            }
            else if (obj_op.Validate_Dictionary_Qry("0", "sp_ValidateDictionary", "select * from tbldict where tabname = 'sample_resu' and var_id = 'LA_52a_a'", LA_52a_a.Text) == true)
            {
                string message = "alert('Invalid value');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                LA_52a_a.Focus();
                return false;
            }


        }
        catch (Exception ex)
        {
            string message = "alert('Exception occur');";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return false;
        }


        return true;
    }



    protected void cmdSearch_Click(object sender, EventArgs e)
    {
        getData(sender);
    }


    private void getData(object sender)
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
            " from sample_result a inner join form1 b on a.la_sno = b.AS1_screening_ID where a.la_sno = '" + la_sno.Text + "'", cn.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);


            la_fsite.Text = "";
            la_rand.Text = "";
            la_spec.Text = "";
            la_name.Text = "";
            la_gen.Text = "";
            la_age.Text = "";
            la_obj.Text = "";



            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        la_fsite.Text = ds.Tables[0].Rows[0]["AS1_fsite"].ToString();
                        la_rand.Text = ds.Tables[0].Rows[0]["AS1_rand_id"].ToString();
                        la_spec.Text = ds.Tables[0].Rows[0]["AS1_barcode"].ToString();
                        la_name.Text = ds.Tables[0].Rows[0]["AS1_name"].ToString();
                        la_gen.Text = ds.Tables[0].Rows[0]["AS1_sex"].ToString();
                        la_age.Text = ds.Tables[0].Rows[0]["AS1_age"].ToString();
                        la_obj.Text = ds.Tables[0].Rows[0]["AS1_Q1_1"].ToString();



                        LA_01.Text = ds.Tables[0].Rows[0]["LA_01"].ToString();

                        LA_02.Text = ds.Tables[0].Rows[0]["LA_02"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_03_b"].ToString() == "0")
                        {
                            LA_03_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_03_b"].ToString() == "999")
                        {
                            LA_03_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_03_b"].ToString() == "888")
                        {
                            LA_03_c.Checked = true;
                        }


                        LA_03_a.Text = ds.Tables[0].Rows[0]["LA_03_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_04_b"].ToString() == "0")
                        {
                            LA_04_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_04_b"].ToString() == "999")
                        {
                            LA_04_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_04_b"].ToString() == "888")
                        {
                            LA_04_c.Checked = true;
                        }


                        LA_04_a.Text = ds.Tables[0].Rows[0]["LA_04_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_05_b"].ToString() == "0")
                        {
                            LA_05_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_05_b"].ToString() == "999")
                        {
                            LA_05_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_05_b"].ToString() == "888")
                        {
                            LA_05_c.Checked = true;
                        }


                        LA_05_a.Text = ds.Tables[0].Rows[0]["LA_05_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_06_b"].ToString() == "0")
                        {
                            LA_06_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_06_b"].ToString() == "999")
                        {
                            LA_06_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_06_b"].ToString() == "888")
                        {
                            LA_06_c.Checked = true;
                        }


                        LA_06_a.Text = ds.Tables[0].Rows[0]["LA_06_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_07_b"].ToString() == "0")
                        {
                            LA_07_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_07_b"].ToString() == "999")
                        {
                            LA_07_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_07_b"].ToString() == "888")
                        {
                            LA_07_c.Checked = true;
                        }


                        LA_07_a.Text = ds.Tables[0].Rows[0]["LA_07_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_08_b"].ToString() == "0")
                        {
                            LA_08_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_08_b"].ToString() == "999")
                        {
                            LA_08_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_08_b"].ToString() == "888")
                        {
                            LA_08_c.Checked = true;
                        }


                        LA_08_a.Text = ds.Tables[0].Rows[0]["LA_08_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_09_b"].ToString() == "0")
                        {
                            LA_09_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_09_b"].ToString() == "999")
                        {
                            LA_09_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_09_b"].ToString() == "888")
                        {
                            LA_09_c.Checked = true;
                        }


                        LA_09_a.Text = ds.Tables[0].Rows[0]["LA_09_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_10_b"].ToString() == "0")
                        {
                            LA_10_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_10_b"].ToString() == "999")
                        {
                            LA_10_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_10_b"].ToString() == "888")
                        {
                            LA_10_c.Checked = true;
                        }


                        LA_10_a.Text = ds.Tables[0].Rows[0]["LA_10_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_11_b"].ToString() == "0")
                        {
                            LA_11_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_11_b"].ToString() == "999")
                        {
                            LA_11_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_11_b"].ToString() == "888")
                        {
                            LA_11_c.Checked = true;
                        }


                        LA_11_a.Text = ds.Tables[0].Rows[0]["LA_11_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_12_b"].ToString() == "0")
                        {
                            LA_12_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_12_b"].ToString() == "999")
                        {
                            LA_12_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_12_b"].ToString() == "888")
                        {
                            LA_12_c.Checked = true;
                        }


                        LA_12_a.Text = ds.Tables[0].Rows[0]["LA_12_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_13_b"].ToString() == "0")
                        {
                            LA_13_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_13_b"].ToString() == "999")
                        {
                            LA_13_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_13_b"].ToString() == "888")
                        {
                            LA_13_c.Checked = true;
                        }


                        LA_13_a.Text = ds.Tables[0].Rows[0]["LA_13_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_14_b"].ToString() == "0")
                        {
                            LA_14_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_14_b"].ToString() == "999")
                        {
                            LA_14_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_14_b"].ToString() == "888")
                        {
                            LA_14_c.Checked = true;
                        }


                        LA_14_a.Text = ds.Tables[0].Rows[0]["LA_14_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_15_b"].ToString() == "0")
                        {
                            LA_15_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_15_b"].ToString() == "999")
                        {
                            LA_15_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_15_b"].ToString() == "888")
                        {
                            LA_15_c.Checked = true;
                        }


                        LA_15_a.Text = ds.Tables[0].Rows[0]["LA_15_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_16_b"].ToString() == "0")
                        {
                            LA_16_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_16_b"].ToString() == "999")
                        {
                            LA_16_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_16_b"].ToString() == "888")
                        {
                            LA_16_c.Checked = true;
                        }


                        LA_16_a.Text = ds.Tables[0].Rows[0]["LA_16_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LF_01"].ToString() == "0")
                        {
                            LF_01_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LF_01"].ToString() == "999")
                        {
                            LF_01_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LF_01"].ToString() == "888")
                        {
                            LF_01_c.Checked = true;
                        }


                        LF_01_a.Text = ds.Tables[0].Rows[0]["LF_01_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LF_02"].ToString() == "0")
                        {
                            LF_02_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LF_02"].ToString() == "999")
                        {
                            LF_02_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LF_02"].ToString() == "888")
                        {
                            LF_02_c.Checked = true;
                        }


                        LF_02_a.Text = ds.Tables[0].Rows[0]["LF_02_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LF_03"].ToString() == "0")
                        {
                            LF_03_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LF_03"].ToString() == "999")
                        {
                            LF_03_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LF_03"].ToString() == "888")
                        {
                            LF_03_c.Checked = true;
                        }


                        LF_03_a.Text = ds.Tables[0].Rows[0]["LF_03_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LF_04"].ToString() == "0")
                        {
                            LF_04_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LF_04"].ToString() == "999")
                        {
                            LF_04_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LF_04"].ToString() == "888")
                        {
                            LF_04_c.Checked = true;
                        }


                        LF_04_a.Text = ds.Tables[0].Rows[0]["LF_04_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LF_05"].ToString() == "0")
                        {
                            LF_05_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LF_05"].ToString() == "999")
                        {
                            LF_05_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LF_05"].ToString() == "888")
                        {
                            LF_05_c.Checked = true;
                        }


                        LF_05_a.Text = ds.Tables[0].Rows[0]["LF_05_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LF_06"].ToString() == "0")
                        {
                            LF_06_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LF_06"].ToString() == "999")
                        {
                            LF_06_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LF_06"].ToString() == "888")
                        {
                            LF_06_c.Checked = true;
                        }


                        LF_06_a.Text = ds.Tables[0].Rows[0]["LF_06_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LF_07"].ToString() == "0")
                        {
                            LF_07_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LF_07"].ToString() == "999")
                        {
                            LF_07_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LF_07"].ToString() == "888")
                        {
                            LF_07_c.Checked = true;
                        }


                        LF_07_a.Text = ds.Tables[0].Rows[0]["LF_07_a"].ToString();


                        if (ds.Tables[0].Rows[0]["RF_01"].ToString() == "0")
                        {
                            RF_01_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["RF_01"].ToString() == "999")
                        {
                            RF_01_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["RF_01"].ToString() == "888")
                        {
                            RF_01_c.Checked = true;
                        }


                        RF_01_a.Text = ds.Tables[0].Rows[0]["RF_01_a"].ToString();


                        if (ds.Tables[0].Rows[0]["RF_02"].ToString() == "0")
                        {
                            RF_02_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["RF_02"].ToString() == "999")
                        {
                            RF_02_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["RF_02"].ToString() == "888")
                        {
                            RF_02_c.Checked = true;
                        }


                        RF_02_a.Text = ds.Tables[0].Rows[0]["RF_02_a"].ToString();


                        if (ds.Tables[0].Rows[0]["RF_03"].ToString() == "0")
                        {
                            RF_03_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["RF_03"].ToString() == "999")
                        {
                            RF_03_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["RF_03"].ToString() == "888")
                        {
                            RF_03_c.Checked = true;
                        }


                        RF_03_a.Text = ds.Tables[0].Rows[0]["RF_03_a"].ToString();


                        if (ds.Tables[0].Rows[0]["RF_04"].ToString() == "0")
                        {
                            RF_04_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["RF_04"].ToString() == "999")
                        {
                            RF_04_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["RF_04"].ToString() == "888")
                        {
                            RF_04_c.Checked = true;
                        }


                        RF_04_a.Text = ds.Tables[0].Rows[0]["RF_04_a"].ToString();


                        if (ds.Tables[0].Rows[0]["SE_01"].ToString() == "0")
                        {
                            SE_01_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["SE_01"].ToString() == "999")
                        {
                            SE_01_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["SE_01"].ToString() == "888")
                        {
                            SE_01_c.Checked = true;
                        }


                        SE_01_a.Text = ds.Tables[0].Rows[0]["SE_01_a"].ToString();


                        if (ds.Tables[0].Rows[0]["SE_02"].ToString() == "0")
                        {
                            SE_02_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["SE_02"].ToString() == "999")
                        {
                            SE_02_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["SE_02"].ToString() == "888")
                        {
                            SE_02_c.Checked = true;
                        }


                        SE_02_a.Text = ds.Tables[0].Rows[0]["SE_02_a"].ToString();


                        if (ds.Tables[0].Rows[0]["SE_03"].ToString() == "0")
                        {
                            SE_03_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["SE_03"].ToString() == "999")
                        {
                            SE_03_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["SE_03"].ToString() == "888")
                        {
                            SE_03_c.Checked = true;
                        }


                        SE_03_a.Text = ds.Tables[0].Rows[0]["SE_03_a"].ToString();


                        if (ds.Tables[0].Rows[0]["SE_04"].ToString() == "0")
                        {
                            SE_04_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["SE_04"].ToString() == "999")
                        {
                            SE_04_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["SE_04"].ToString() == "888")
                        {
                            SE_04_c.Checked = true;
                        }


                        SE_04_a.Text = ds.Tables[0].Rows[0]["SE_04_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_01"].ToString() == "0")
                        {
                            CS_01_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_01"].ToString() == "999")
                        {
                            CS_01_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_01"].ToString() == "888")
                        {
                            CS_01_c.Checked = true;
                        }


                        CS_01_a.Text = ds.Tables[0].Rows[0]["CS_01_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_02"].ToString() == "0")
                        {
                            CS_02_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_02"].ToString() == "999")
                        {
                            CS_02_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_02"].ToString() == "888")
                        {
                            CS_02_c.Checked = true;
                        }


                        CS_02_a.Text = ds.Tables[0].Rows[0]["CS_02_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_03"].ToString() == "0")
                        {
                            CS_03_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_03"].ToString() == "999")
                        {
                            CS_03_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_03"].ToString() == "888")
                        {
                            CS_03_c.Checked = true;
                        }


                        CS_03_a.Text = ds.Tables[0].Rows[0]["CS_03_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_04"].ToString() == "0")
                        {
                            CS_04_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_04"].ToString() == "999")
                        {
                            CS_04_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_04"].ToString() == "888")
                        {
                            CS_04_c.Checked = true;
                        }


                        CS_04_a.Text = ds.Tables[0].Rows[0]["CS_04_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_05"].ToString() == "0")
                        {
                            CS_05_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_05"].ToString() == "999")
                        {
                            CS_05_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_05"].ToString() == "888")
                        {
                            CS_05_c.Checked = true;
                        }


                        CS_05_a.Text = ds.Tables[0].Rows[0]["CS_05_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_06"].ToString() == "0")
                        {
                            CS_06_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_06"].ToString() == "999")
                        {
                            CS_06_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_06"].ToString() == "888")
                        {
                            CS_06_c.Checked = true;
                        }


                        CS_06_a.Text = ds.Tables[0].Rows[0]["CS_06_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_07"].ToString() == "0")
                        {
                            CS_07_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_07"].ToString() == "999")
                        {
                            CS_07_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_07"].ToString() == "888")
                        {
                            CS_07_c.Checked = true;
                        }


                        CS_07_a.Text = ds.Tables[0].Rows[0]["CS_07_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_08"].ToString() == "0")
                        {
                            CS_08_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_08"].ToString() == "999")
                        {
                            CS_08_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_08"].ToString() == "888")
                        {
                            CS_08_c.Checked = true;
                        }


                        CS_08_a.Text = ds.Tables[0].Rows[0]["CS_08_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_09"].ToString() == "0")
                        {
                            CS_09_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_09"].ToString() == "999")
                        {
                            CS_09_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_09"].ToString() == "888")
                        {
                            CS_09_c.Checked = true;
                        }


                        CS_09_a.Text = ds.Tables[0].Rows[0]["CS_09_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_10"].ToString() == "0")
                        {
                            CS_10_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_10"].ToString() == "999")
                        {
                            CS_10_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["CS_10"].ToString() == "888")
                        {
                            CS_10_c.Checked = true;
                        }


                        CS_10_a.Text = ds.Tables[0].Rows[0]["CS_10_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_01"].ToString() == "0")
                        {
                            UR_01_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_01"].ToString() == "999")
                        {
                            UR_01_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_01"].ToString() == "888")
                        {
                            UR_01_c.Checked = true;
                        }


                        UR_01_a.Text = ds.Tables[0].Rows[0]["UR_01_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_02"].ToString() == "0")
                        {
                            UR_02_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_02"].ToString() == "999")
                        {
                            UR_02_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_02"].ToString() == "888")
                        {
                            UR_02_c.Checked = true;
                        }


                        UR_02_a.Text = ds.Tables[0].Rows[0]["UR_02_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_03"].ToString() == "0")
                        {
                            UR_03_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_03"].ToString() == "999")
                        {
                            UR_03_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_03"].ToString() == "888")
                        {
                            UR_03_c.Checked = true;
                        }


                        UR_03_a.Text = ds.Tables[0].Rows[0]["UR_03_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_04"].ToString() == "0")
                        {
                            UR_04_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_04"].ToString() == "999")
                        {
                            UR_04_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_04"].ToString() == "888")
                        {
                            UR_04_c.Checked = true;
                        }


                        UR_04_a.Text = ds.Tables[0].Rows[0]["UR_04_a"].ToString();




                        if (ds.Tables[0].Rows[0]["UR_04a"].ToString() == "0")
                        {
                            UR_04a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_04a"].ToString() == "999")
                        {
                            UR_04a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_04a"].ToString() == "888")
                        {
                            UR_04a_c.Checked = true;
                        }


                        UR_04a_a.Text = ds.Tables[0].Rows[0]["UR_04a_a"].ToString();





                        if (ds.Tables[0].Rows[0]["UR_05"].ToString() == "0")
                        {
                            UR_05_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_05"].ToString() == "999")
                        {
                            UR_05_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_05"].ToString() == "888")
                        {
                            UR_05_c.Checked = true;
                        }


                        UR_05_a.Text = ds.Tables[0].Rows[0]["UR_05_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_06"].ToString() == "0")
                        {
                            UR_06_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_06"].ToString() == "999")
                        {
                            UR_06_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_06"].ToString() == "888")
                        {
                            UR_06_c.Checked = true;
                        }


                        UR_06_a.Text = ds.Tables[0].Rows[0]["UR_06_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_07"].ToString() == "0")
                        {
                            UR_07_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_07"].ToString() == "999")
                        {
                            UR_07_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_07"].ToString() == "888")
                        {
                            UR_07_c.Checked = true;
                        }


                        UR_07_a.Text = ds.Tables[0].Rows[0]["UR_07_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_08"].ToString() == "0")
                        {
                            UR_08_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_08"].ToString() == "999")
                        {
                            UR_08_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_08"].ToString() == "888")
                        {
                            UR_08_c.Checked = true;
                        }


                        UR_08_a.Text = ds.Tables[0].Rows[0]["UR_08_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_10"].ToString() == "0")
                        {
                            UR_10_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_10"].ToString() == "999")
                        {
                            UR_10_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_10"].ToString() == "888")
                        {
                            UR_10_c.Checked = true;
                        }


                        UR_10_a.Text = ds.Tables[0].Rows[0]["UR_10_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_11"].ToString() == "0")
                        {
                            UR_11_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_11"].ToString() == "999")
                        {
                            UR_11_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_11"].ToString() == "888")
                        {
                            UR_11_c.Checked = true;
                        }


                        UR_11_a.Text = ds.Tables[0].Rows[0]["UR_11_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_12"].ToString() == "0")
                        {
                            UR_12_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_12"].ToString() == "999")
                        {
                            UR_12_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_12"].ToString() == "888")
                        {
                            UR_12_c.Checked = true;
                        }


                        UR_12_a.Text = ds.Tables[0].Rows[0]["UR_12_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_13"].ToString() == "0")
                        {
                            UR_13_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_13"].ToString() == "999")
                        {
                            UR_13_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_13"].ToString() == "888")
                        {
                            UR_13_c.Checked = true;
                        }


                        UR_13_a.Text = ds.Tables[0].Rows[0]["UR_13_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_14"].ToString() == "0")
                        {
                            UR_14_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_14"].ToString() == "999")
                        {
                            UR_14_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_14"].ToString() == "888")
                        {
                            UR_14_c.Checked = true;
                        }


                        UR_14_a.Text = ds.Tables[0].Rows[0]["UR_14_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_15"].ToString() == "0")
                        {
                            UR_15_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_15"].ToString() == "999")
                        {
                            UR_15_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_15"].ToString() == "888")
                        {
                            UR_15_c.Checked = true;
                        }


                        UR_15_a.Text = ds.Tables[0].Rows[0]["UR_15_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_16"].ToString() == "0")
                        {
                            UR_16_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_16"].ToString() == "999")
                        {
                            UR_16_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_16"].ToString() == "888")
                        {
                            UR_16_c.Checked = true;
                        }


                        UR_16_a.Text = ds.Tables[0].Rows[0]["UR_16_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_17"].ToString() == "0")
                        {
                            UR_17_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_17"].ToString() == "999")
                        {
                            UR_17_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_17"].ToString() == "888")
                        {
                            UR_17_c.Checked = true;
                        }


                        UR_17_a.Text = ds.Tables[0].Rows[0]["UR_17_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_18"].ToString() == "0")
                        {
                            UR_18_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_18"].ToString() == "999")
                        {
                            UR_18_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_18"].ToString() == "888")
                        {
                            UR_18_c.Checked = true;
                        }


                        UR_18_a.Text = ds.Tables[0].Rows[0]["UR_18_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_19"].ToString() == "0")
                        {
                            UR_19_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_19"].ToString() == "999")
                        {
                            UR_19_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_19"].ToString() == "888")
                        {
                            UR_19_c.Checked = true;
                        }


                        UR_19_a.Text = ds.Tables[0].Rows[0]["UR_19_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_20"].ToString() == "0")
                        {
                            UR_20_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_20"].ToString() == "999")
                        {
                            UR_20_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_20"].ToString() == "888")
                        {
                            UR_20_c.Checked = true;
                        }


                        UR_20_a.Text = ds.Tables[0].Rows[0]["UR_20_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_21"].ToString() == "0")
                        {
                            UR_21_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_21"].ToString() == "999")
                        {
                            UR_21_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["UR_21"].ToString() == "888")
                        {
                            UR_21_c.Checked = true;
                        }


                        UR_21_a.Text = ds.Tables[0].Rows[0]["UR_21_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_01a"].ToString() == "1")
                        {
                            uc_01_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_01a"].ToString() == "2")
                        {
                            uc_01_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_01a"].ToString() == "999")
                        {
                            uc_01_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_02a"].ToString() == "0")
                        {
                            uc_02a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_02a"].ToString() == "999")
                        {
                            uc_02a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_02a"].ToString() == "888")
                        {
                            uc_02a_c.Checked = true;
                        }


                        uc_02a_a.Text = ds.Tables[0].Rows[0]["uc_02a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_02b"].ToString() == "1")
                        {
                            uc_02b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_02b"].ToString() == "2")
                        {
                            uc_02b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_02b"].ToString() == "3")
                        {
                            uc_02b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_03a"].ToString() == "0")
                        {
                            uc_03a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_03a"].ToString() == "999")
                        {
                            uc_03a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_03a"].ToString() == "888")
                        {
                            uc_03a_c.Checked = true;
                        }


                        uc_03a_a.Text = ds.Tables[0].Rows[0]["uc_03a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_03b"].ToString() == "1")
                        {
                            uc_03b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_03b"].ToString() == "2")
                        {
                            uc_03b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_03b"].ToString() == "3")
                        {
                            uc_03b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_04a"].ToString() == "0")
                        {
                            uc_04a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_04a"].ToString() == "999")
                        {
                            uc_04a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_04a"].ToString() == "888")
                        {
                            uc_04a_c.Checked = true;
                        }


                        uc_04a_a.Text = ds.Tables[0].Rows[0]["uc_04a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_04b"].ToString() == "1")
                        {
                            uc_04b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_04b"].ToString() == "2")
                        {
                            uc_04b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_04b"].ToString() == "3")
                        {
                            uc_04b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_05a"].ToString() == "0")
                        {
                            uc_05a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_05a"].ToString() == "999")
                        {
                            uc_05a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_05a"].ToString() == "888")
                        {
                            uc_05a_c.Checked = true;
                        }


                        uc_05a_a.Text = ds.Tables[0].Rows[0]["uc_05a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_05b"].ToString() == "1")
                        {
                            uc_05b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_05b"].ToString() == "2")
                        {
                            uc_05b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_05b"].ToString() == "3")
                        {
                            uc_05b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_06a"].ToString() == "0")
                        {
                            uc_06a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_06a"].ToString() == "999")
                        {
                            uc_06a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_06a"].ToString() == "888")
                        {
                            uc_06a_c.Checked = true;
                        }


                        uc_06a_a.Text = ds.Tables[0].Rows[0]["uc_06a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_06b"].ToString() == "1")
                        {
                            uc_06b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_06b"].ToString() == "2")
                        {
                            uc_06b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_06b"].ToString() == "3")
                        {
                            uc_06b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_07a"].ToString() == "0")
                        {
                            uc_07a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_07a"].ToString() == "999")
                        {
                            uc_07a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_07a"].ToString() == "888")
                        {
                            uc_07a_c.Checked = true;
                        }


                        uc_07a_a.Text = ds.Tables[0].Rows[0]["uc_07a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_07b"].ToString() == "1")
                        {
                            uc_07b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_07b"].ToString() == "2")
                        {
                            uc_07b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_07b"].ToString() == "3")
                        {
                            uc_07b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_08a"].ToString() == "0")
                        {
                            uc_08a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_08a"].ToString() == "999")
                        {
                            uc_08a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_08a"].ToString() == "888")
                        {
                            uc_08a_c.Checked = true;
                        }


                        uc_08a_a.Text = ds.Tables[0].Rows[0]["uc_08a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_08b"].ToString() == "1")
                        {
                            uc_08b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_08b"].ToString() == "2")
                        {
                            uc_08b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_08b"].ToString() == "3")
                        {
                            uc_08b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_09a"].ToString() == "0")
                        {
                            uc_09a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_09a"].ToString() == "999")
                        {
                            uc_09a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_09a"].ToString() == "888")
                        {
                            uc_09a_c.Checked = true;
                        }


                        uc_09a_a.Text = ds.Tables[0].Rows[0]["uc_09a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_09b"].ToString() == "1")
                        {
                            uc_09b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_09b"].ToString() == "2")
                        {
                            uc_09b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_09b"].ToString() == "3")
                        {
                            uc_09b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_10a"].ToString() == "0")
                        {
                            uc_10a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_10a"].ToString() == "999")
                        {
                            uc_10a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_10a"].ToString() == "888")
                        {
                            uc_10a_c.Checked = true;
                        }


                        uc_10a_a.Text = ds.Tables[0].Rows[0]["uc_10a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_10b"].ToString() == "1")
                        {
                            uc_10b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_10b"].ToString() == "2")
                        {
                            uc_10b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_10b"].ToString() == "3")
                        {
                            uc_10b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_11a"].ToString() == "0")
                        {
                            uc_11a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_11a"].ToString() == "999")
                        {
                            uc_11a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_11a"].ToString() == "888")
                        {
                            uc_11a_c.Checked = true;
                        }


                        uc_11a_a.Text = ds.Tables[0].Rows[0]["uc_11a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_11b"].ToString() == "1")
                        {
                            uc_11b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_11b"].ToString() == "2")
                        {
                            uc_11b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_11b"].ToString() == "3")
                        {
                            uc_11b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_12a"].ToString() == "0")
                        {
                            uc_12a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_12a"].ToString() == "999")
                        {
                            uc_12a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_12a"].ToString() == "888")
                        {
                            uc_12a_c.Checked = true;
                        }


                        uc_12a_a.Text = ds.Tables[0].Rows[0]["uc_12a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_12b"].ToString() == "1")
                        {
                            uc_12b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_12b"].ToString() == "2")
                        {
                            uc_12b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_12b"].ToString() == "3")
                        {
                            uc_12b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_13a"].ToString() == "0")
                        {
                            uc_13a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_13a"].ToString() == "999")
                        {
                            uc_13a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_13a"].ToString() == "888")
                        {
                            uc_13a_c.Checked = true;
                        }


                        uc_13a_a.Text = ds.Tables[0].Rows[0]["uc_13a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_13b"].ToString() == "1")
                        {
                            uc_13b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_13b"].ToString() == "2")
                        {
                            uc_13b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_13b"].ToString() == "3")
                        {
                            uc_13b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_14a"].ToString() == "0")
                        {
                            uc_14a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_14a"].ToString() == "999")
                        {
                            uc_14a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_14a"].ToString() == "888")
                        {
                            uc_14a_c.Checked = true;
                        }


                        uc_14a_a.Text = ds.Tables[0].Rows[0]["uc_14a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_14b"].ToString() == "1")
                        {
                            uc_14b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_14b"].ToString() == "2")
                        {
                            uc_14b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_14b"].ToString() == "3")
                        {
                            uc_14b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_15a"].ToString() == "0")
                        {
                            uc_15a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_15a"].ToString() == "999")
                        {
                            uc_15a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_15a"].ToString() == "888")
                        {
                            uc_15a_c.Checked = true;
                        }


                        uc_15a_a.Text = ds.Tables[0].Rows[0]["uc_15a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_15b"].ToString() == "1")
                        {
                            uc_15b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_15b"].ToString() == "2")
                        {
                            uc_15b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_15b"].ToString() == "3")
                        {
                            uc_15b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_16a"].ToString() == "0")
                        {
                            uc_16a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_16a"].ToString() == "999")
                        {
                            uc_16a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_16a"].ToString() == "888")
                        {
                            uc_16a_c.Checked = true;
                        }


                        uc_16a_a.Text = ds.Tables[0].Rows[0]["uc_16a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_16b"].ToString() == "1")
                        {
                            uc_16b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_16b"].ToString() == "2")
                        {
                            uc_16b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_16b"].ToString() == "3")
                        {
                            uc_16b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_17a"].ToString() == "0")
                        {
                            uc_17a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_17a"].ToString() == "999")
                        {
                            uc_17a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_17a"].ToString() == "888")
                        {
                            uc_17a_c.Checked = true;
                        }


                        uc_17a_a.Text = ds.Tables[0].Rows[0]["uc_17a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_17b"].ToString() == "1")
                        {
                            uc_17b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_17b"].ToString() == "2")
                        {
                            uc_17b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_17b"].ToString() == "3")
                        {
                            uc_17b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_18a"].ToString() == "0")
                        {
                            uc_18a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_18a"].ToString() == "999")
                        {
                            uc_18a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_18a"].ToString() == "888")
                        {
                            uc_18a_c.Checked = true;
                        }


                        uc_18a_a.Text = ds.Tables[0].Rows[0]["uc_18a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_18b"].ToString() == "1")
                        {
                            uc_18b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_18b"].ToString() == "2")
                        {
                            uc_18b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_18b"].ToString() == "3")
                        {
                            uc_18b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_19a"].ToString() == "0")
                        {
                            uc_19a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_19a"].ToString() == "999")
                        {
                            uc_19a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_19a"].ToString() == "888")
                        {
                            uc_19a_c.Checked = true;
                        }


                        uc_19a_a.Text = ds.Tables[0].Rows[0]["uc_19a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_19b"].ToString() == "1")
                        {
                            uc_19b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_19b"].ToString() == "2")
                        {
                            uc_19b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_19b"].ToString() == "3")
                        {
                            uc_19b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_20a"].ToString() == "0")
                        {
                            uc_20a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_20a"].ToString() == "999")
                        {
                            uc_20a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_20a"].ToString() == "888")
                        {
                            uc_20a_c.Checked = true;
                        }


                        uc_20a_a.Text = ds.Tables[0].Rows[0]["uc_20a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_20b"].ToString() == "1")
                        {
                            uc_20b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_20b"].ToString() == "2")
                        {
                            uc_20b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_20b"].ToString() == "3")
                        {
                            uc_20b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_21a"].ToString() == "0")
                        {
                            uc_21a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_21a"].ToString() == "999")
                        {
                            uc_21a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_21a"].ToString() == "888")
                        {
                            uc_21a_c.Checked = true;
                        }


                        uc_21a_a.Text = ds.Tables[0].Rows[0]["uc_21a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_21b"].ToString() == "1")
                        {
                            uc_21b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_21b"].ToString() == "2")
                        {
                            uc_21b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_21b"].ToString() == "3")
                        {
                            uc_21b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_22a"].ToString() == "0")
                        {
                            uc_22a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_22a"].ToString() == "999")
                        {
                            uc_22a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_22a"].ToString() == "888")
                        {
                            uc_22a_c.Checked = true;
                        }


                        uc_22a_a.Text = ds.Tables[0].Rows[0]["uc_22a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_22b"].ToString() == "1")
                        {
                            uc_22b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_22b"].ToString() == "2")
                        {
                            uc_22b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_22b"].ToString() == "3")
                        {
                            uc_22b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_23a"].ToString() == "0")
                        {
                            uc_23a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_23a"].ToString() == "999")
                        {
                            uc_23a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_23a"].ToString() == "888")
                        {
                            uc_23a_c.Checked = true;
                        }


                        uc_23a_a.Text = ds.Tables[0].Rows[0]["uc_23a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_23b"].ToString() == "1")
                        {
                            uc_23b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_23b"].ToString() == "2")
                        {
                            uc_23b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_23b"].ToString() == "3")
                        {
                            uc_23b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_24a"].ToString() == "0")
                        {
                            uc_24a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_24a"].ToString() == "999")
                        {
                            uc_24a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_24a"].ToString() == "888")
                        {
                            uc_24a_c.Checked = true;
                        }


                        uc_24a_a.Text = ds.Tables[0].Rows[0]["uc_24a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_24b"].ToString() == "1")
                        {
                            uc_24b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_24b"].ToString() == "2")
                        {
                            uc_24b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_24b"].ToString() == "3")
                        {
                            uc_24b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_25a"].ToString() == "0")
                        {
                            uc_25a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_25a"].ToString() == "999")
                        {
                            uc_25a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_25a"].ToString() == "888")
                        {
                            uc_25a_c.Checked = true;
                        }


                        uc_25a_a.Text = ds.Tables[0].Rows[0]["uc_25a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_25b"].ToString() == "1")
                        {
                            uc_25b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_25b"].ToString() == "2")
                        {
                            uc_25b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_25b"].ToString() == "3")
                        {
                            uc_25b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_26a"].ToString() == "0")
                        {
                            uc_26a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_26a"].ToString() == "999")
                        {
                            uc_26a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_26a"].ToString() == "888")
                        {
                            uc_26a_c.Checked = true;
                        }


                        uc_26a_a.Text = ds.Tables[0].Rows[0]["uc_26a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_26b"].ToString() == "1")
                        {
                            uc_26b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_26b"].ToString() == "2")
                        {
                            uc_26b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_26b"].ToString() == "3")
                        {
                            uc_26b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_27a"].ToString() == "0")
                        {
                            uc_27a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_27a"].ToString() == "999")
                        {
                            uc_27a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_27a"].ToString() == "888")
                        {
                            uc_27a_c.Checked = true;
                        }


                        uc_27a_a.Text = ds.Tables[0].Rows[0]["uc_27a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_27b"].ToString() == "1")
                        {
                            uc_27b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_27b"].ToString() == "2")
                        {
                            uc_27b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_27b"].ToString() == "3")
                        {
                            uc_27b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_28a"].ToString() == "0")
                        {
                            uc_28a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_28a"].ToString() == "999")
                        {
                            uc_28a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_28a"].ToString() == "888")
                        {
                            uc_28a_c.Checked = true;
                        }


                        uc_28a_a.Text = ds.Tables[0].Rows[0]["uc_28a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_28b"].ToString() == "1")
                        {
                            uc_28b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_28b"].ToString() == "2")
                        {
                            uc_28b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_28b"].ToString() == "3")
                        {
                            uc_28b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_29a"].ToString() == "0")
                        {
                            uc_29a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_29a"].ToString() == "999")
                        {
                            uc_29a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_29a"].ToString() == "888")
                        {
                            uc_29a_c.Checked = true;
                        }


                        uc_29a_a.Text = ds.Tables[0].Rows[0]["uc_29a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_29b"].ToString() == "1")
                        {
                            uc_29b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_29b"].ToString() == "2")
                        {
                            uc_29b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_29b"].ToString() == "3")
                        {
                            uc_29b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_30a"].ToString() == "0")
                        {
                            uc_30a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_30a"].ToString() == "999")
                        {
                            uc_30a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_30a"].ToString() == "888")
                        {
                            uc_30a_c.Checked = true;
                        }


                        uc_30a_a.Text = ds.Tables[0].Rows[0]["uc_30a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_30b"].ToString() == "1")
                        {
                            uc_30b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_30b"].ToString() == "2")
                        {
                            uc_30b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_30b"].ToString() == "3")
                        {
                            uc_30b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_31a"].ToString() == "0")
                        {
                            uc_31a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_31a"].ToString() == "999")
                        {
                            uc_31a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_31a"].ToString() == "888")
                        {
                            uc_31a_c.Checked = true;
                        }


                        uc_31a_a.Text = ds.Tables[0].Rows[0]["uc_31a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_31b"].ToString() == "1")
                        {
                            uc_31b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_31b"].ToString() == "2")
                        {
                            uc_31b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_31b"].ToString() == "3")
                        {
                            uc_31b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_32a"].ToString() == "0")
                        {
                            uc_32a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_32a"].ToString() == "999")
                        {
                            uc_32a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_32a"].ToString() == "888")
                        {
                            uc_32a_c.Checked = true;
                        }


                        uc_32a_a.Text = ds.Tables[0].Rows[0]["uc_32a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_32b"].ToString() == "1")
                        {
                            uc_32b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_32b"].ToString() == "2")
                        {
                            uc_32b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_32b"].ToString() == "3")
                        {
                            uc_32b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_33a"].ToString() == "0")
                        {
                            uc_33a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_33a"].ToString() == "999")
                        {
                            uc_33a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_33a"].ToString() == "888")
                        {
                            uc_33a_c.Checked = true;
                        }


                        uc_33a_a.Text = ds.Tables[0].Rows[0]["uc_33a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_33b"].ToString() == "1")
                        {
                            uc_33b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_33b"].ToString() == "2")
                        {
                            uc_33b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_33b"].ToString() == "3")
                        {
                            uc_33b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_34a"].ToString() == "0")
                        {
                            uc_34a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_34a"].ToString() == "999")
                        {
                            uc_34a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_34a"].ToString() == "888")
                        {
                            uc_34a_c.Checked = true;
                        }


                        uc_34a_a.Text = ds.Tables[0].Rows[0]["uc_34a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_34b"].ToString() == "0")
                        {
                            uc_34b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_34b"].ToString() == "999")
                        {
                            uc_34b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_34b"].ToString() == "888")
                        {
                            uc_34b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_35a"].ToString() == "0")
                        {
                            uc_35a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_35a"].ToString() == "999")
                        {
                            uc_35a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_35a"].ToString() == "888")
                        {
                            uc_35a_c.Checked = true;
                        }


                        uc_35a_a.Text = ds.Tables[0].Rows[0]["uc_35a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_35b"].ToString() == "1")
                        {
                            uc_35b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_35b"].ToString() == "2")
                        {
                            uc_35b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_35b"].ToString() == "3")
                        {
                            uc_35b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_36a"].ToString() == "0")
                        {
                            uc_36a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_36a"].ToString() == "999")
                        {
                            uc_36a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_36a"].ToString() == "888")
                        {
                            uc_36a_c.Checked = true;
                        }


                        uc_36a_a.Text = ds.Tables[0].Rows[0]["uc_36a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_36b"].ToString() == "1")
                        {
                            uc_36b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_36b"].ToString() == "2")
                        {
                            uc_36b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_36b"].ToString() == "3")
                        {
                            uc_36b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_37a"].ToString() == "0")
                        {
                            uc_37a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_37a"].ToString() == "999")
                        {
                            uc_37a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_37a"].ToString() == "888")
                        {
                            uc_37a_c.Checked = true;
                        }


                        uc_37a_a.Text = ds.Tables[0].Rows[0]["uc_37a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_37b"].ToString() == "1")
                        {
                            uc_37b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_37b"].ToString() == "2")
                        {
                            uc_37b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_37b"].ToString() == "3")
                        {
                            uc_37b_c.Checked = true;
                        }


                        LA_17.Text = ds.Tables[0].Rows[0]["LA_17"].ToString();


                        LA_18.Text = ds.Tables[0].Rows[0]["LA_18"].ToString();


                        //LA_19.Text = ds.Tables[0].Rows[0]["LA_19"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_20a_b"].ToString() == "0")
                        {
                            LA_20a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_20a_b"].ToString() == "999")
                        {
                            LA_20a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_20a_b"].ToString() == "888")
                        {
                            LA_20a_c.Checked = true;
                        }


                        LA_20a_a.Text = ds.Tables[0].Rows[0]["LA_20a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_20b_a"].ToString() == "1")
                        {
                            LA_20b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_20b_a"].ToString() == "2")
                        {
                            LA_20b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_20b_a"].ToString() == "3")
                        {
                            LA_20b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_21a_b"].ToString() == "0")
                        {
                            LA_21a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_21a_b"].ToString() == "999")
                        {
                            LA_21a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_21a_b"].ToString() == "888")
                        {
                            LA_21a_c.Checked = true;
                        }


                        LA_21a_a.Text = ds.Tables[0].Rows[0]["LA_21a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_21b_a"].ToString() == "1")
                        {
                            LA_21b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_21b_a"].ToString() == "2")
                        {
                            LA_21b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_21b_a"].ToString() == "3")
                        {
                            LA_21b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_22a_b"].ToString() == "0")
                        {
                            LA_22a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_22a_b"].ToString() == "999")
                        {
                            LA_22a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_22a_b"].ToString() == "888")
                        {
                            LA_22a_c.Checked = true;
                        }


                        LA_22a_a.Text = ds.Tables[0].Rows[0]["LA_22a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_22b_a"].ToString() == "1")
                        {
                            LA_22b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_22b_a"].ToString() == "2")
                        {
                            LA_22b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_22b_a"].ToString() == "3")
                        {
                            LA_22b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_23a_b"].ToString() == "0")
                        {
                            LA_23a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_23a_b"].ToString() == "999")
                        {
                            LA_23a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_23a_b"].ToString() == "888")
                        {
                            LA_23a_c.Checked = true;
                        }


                        LA_23a_a.Text = ds.Tables[0].Rows[0]["LA_23a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_23b_a"].ToString() == "1")
                        {
                            LA_23b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_23b_a"].ToString() == "2")
                        {
                            LA_23b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_23b_a"].ToString() == "3")
                        {
                            LA_23b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_24a_b"].ToString() == "0")
                        {
                            LA_24a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_24a_b"].ToString() == "999")
                        {
                            LA_24a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_24a_b"].ToString() == "888")
                        {
                            LA_24a_c.Checked = true;
                        }


                        LA_24a_a.Text = ds.Tables[0].Rows[0]["LA_24a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_24b_a"].ToString() == "1")
                        {
                            LA_24b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_24b_a"].ToString() == "2")
                        {
                            LA_24b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_24b_a"].ToString() == "3")
                        {
                            LA_24b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_25a_b"].ToString() == "0")
                        {
                            LA_25a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_25a_b"].ToString() == "999")
                        {
                            LA_25a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_25a_b"].ToString() == "888")
                        {
                            LA_25a_c.Checked = true;
                        }


                        LA_25a_a.Text = ds.Tables[0].Rows[0]["LA_25a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_25b_a"].ToString() == "1")
                        {
                            LA_25b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_25b_a"].ToString() == "2")
                        {
                            LA_25b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_25b_a"].ToString() == "3")
                        {
                            LA_25b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_26a_b"].ToString() == "0")
                        {
                            LA_26a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_26a_b"].ToString() == "999")
                        {
                            LA_26a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_26a_b"].ToString() == "888")
                        {
                            LA_26a_c.Checked = true;
                        }


                        LA_26a_a.Text = ds.Tables[0].Rows[0]["LA_26a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_26b_a"].ToString() == "1")
                        {
                            LA_26b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_26b_a"].ToString() == "2")
                        {
                            LA_26b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_26b_a"].ToString() == "3")
                        {
                            LA_26b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_27a_b"].ToString() == "0")
                        {
                            LA_27a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_27a_b"].ToString() == "999")
                        {
                            LA_27a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_27a_b"].ToString() == "888")
                        {
                            LA_27a_c.Checked = true;
                        }


                        LA_27a_a.Text = ds.Tables[0].Rows[0]["LA_27a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_27b_a"].ToString() == "1")
                        {
                            LA_27b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_27b_a"].ToString() == "2")
                        {
                            LA_27b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_27b_a"].ToString() == "3")
                        {
                            LA_27b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_28a_b"].ToString() == "0")
                        {
                            LA_28a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_28a_b"].ToString() == "999")
                        {
                            LA_28a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_28a_b"].ToString() == "888")
                        {
                            LA_28a_c.Checked = true;
                        }


                        LA_28a_a.Text = ds.Tables[0].Rows[0]["LA_28a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_28b_a"].ToString() == "1")
                        {
                            LA_28b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_28b_a"].ToString() == "2")
                        {
                            LA_28b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_28b_a"].ToString() == "3")
                        {
                            LA_28b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_29a_b"].ToString() == "0")
                        {
                            LA_29a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_29a_b"].ToString() == "999")
                        {
                            LA_29a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_29a_b"].ToString() == "888")
                        {
                            LA_29a_c.Checked = true;
                        }


                        LA_29a_a.Text = ds.Tables[0].Rows[0]["LA_29a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_29b_a"].ToString() == "1")
                        {
                            LA_29b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_29b_a"].ToString() == "2")
                        {
                            LA_29b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_29b_a"].ToString() == "3")
                        {
                            LA_29b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_30a_b"].ToString() == "0")
                        {
                            LA_30a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_30a_b"].ToString() == "999")
                        {
                            LA_30a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_30a_b"].ToString() == "888")
                        {
                            LA_30a_c.Checked = true;
                        }


                        LA_30a_a.Text = ds.Tables[0].Rows[0]["LA_30a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_30b_a"].ToString() == "1")
                        {
                            LA_30b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_30b_a"].ToString() == "2")
                        {
                            LA_30b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_30b_a"].ToString() == "3")
                        {
                            LA_30b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_31a_b"].ToString() == "0")
                        {
                            LA_31a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_31a_b"].ToString() == "999")
                        {
                            LA_31a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_31a_b"].ToString() == "888")
                        {
                            LA_31a_c.Checked = true;
                        }


                        LA_31a_a.Text = ds.Tables[0].Rows[0]["LA_31a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_31b_a"].ToString() == "1")
                        {
                            LA_31b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_31b_a"].ToString() == "2")
                        {
                            LA_31b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_31b_a"].ToString() == "3")
                        {
                            LA_31b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_32a_b"].ToString() == "0")
                        {
                            LA_32a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_32a_b"].ToString() == "999")
                        {
                            LA_32a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_32a_b"].ToString() == "888")
                        {
                            LA_32a_c.Checked = true;
                        }


                        LA_32a_a.Text = ds.Tables[0].Rows[0]["LA_32a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_32b_a"].ToString() == "1")
                        {
                            LA_32b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_32b_a"].ToString() == "2")
                        {
                            LA_32b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_32b_a"].ToString() == "3")
                        {
                            LA_32b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_33a_b"].ToString() == "0")
                        {
                            LA_33a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_33a_b"].ToString() == "999")
                        {
                            LA_33a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_33a_b"].ToString() == "888")
                        {
                            LA_33a_c.Checked = true;
                        }


                        LA_33a_a.Text = ds.Tables[0].Rows[0]["LA_33a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_33b_a"].ToString() == "1")
                        {
                            LA_33b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_33b_a"].ToString() == "2")
                        {
                            LA_33b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_33b_a"].ToString() == "3")
                        {
                            LA_33b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_34a_b"].ToString() == "0")
                        {
                            LA_34a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_34a_b"].ToString() == "999")
                        {
                            LA_34a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_34a_b"].ToString() == "888")
                        {
                            LA_34a_c.Checked = true;
                        }


                        LA_34a_a.Text = ds.Tables[0].Rows[0]["LA_34a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_34b_a"].ToString() == "1")
                        {
                            LA_34b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_34b_a"].ToString() == "2")
                        {
                            LA_34b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_34b_a"].ToString() == "3")
                        {
                            LA_34b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_35a_b"].ToString() == "0")
                        {
                            LA_35a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_35a_b"].ToString() == "999")
                        {
                            LA_35a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_35a_b"].ToString() == "888")
                        {
                            LA_35a_c.Checked = true;
                        }


                        LA_35a_a.Text = ds.Tables[0].Rows[0]["LA_35a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_35b_a"].ToString() == "1")
                        {
                            LA_35b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_35b_a"].ToString() == "2")
                        {
                            LA_35b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_35b_a"].ToString() == "3")
                        {
                            LA_35b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_36a_b"].ToString() == "0")
                        {
                            LA_36a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_36a_b"].ToString() == "999")
                        {
                            LA_36a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_36a_b"].ToString() == "888")
                        {
                            LA_36a_c.Checked = true;
                        }


                        LA_36a_a.Text = ds.Tables[0].Rows[0]["LA_36a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_36b_a"].ToString() == "1")
                        {
                            LA_36b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_36b_a"].ToString() == "2")
                        {
                            LA_36b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_36b_a"].ToString() == "3")
                        {
                            LA_36b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_37a_b"].ToString() == "0")
                        {
                            LA_37a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_37a_b"].ToString() == "999")
                        {
                            LA_37a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_37a_b"].ToString() == "888")
                        {
                            LA_37a_c.Checked = true;
                        }


                        LA_37a_a.Text = ds.Tables[0].Rows[0]["LA_37a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_37b_a"].ToString() == "1")
                        {
                            LA_37b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_37b_a"].ToString() == "2")
                        {
                            LA_37b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_37b_a"].ToString() == "3")
                        {
                            LA_37b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_38a_b"].ToString() == "0")
                        {
                            LA_38a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_38a_b"].ToString() == "999")
                        {
                            LA_38a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_38a_b"].ToString() == "888")
                        {
                            LA_38a_c.Checked = true;
                        }


                        LA_38a_a.Text = ds.Tables[0].Rows[0]["LA_38a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_38b_a"].ToString() == "1")
                        {
                            LA_38b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_38b_a"].ToString() == "2")
                        {
                            LA_38b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_38b_a"].ToString() == "3")
                        {
                            LA_38b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_39a_b"].ToString() == "0")
                        {
                            LA_39a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_39a_b"].ToString() == "999")
                        {
                            LA_39a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_39a_b"].ToString() == "888")
                        {
                            LA_39a_c.Checked = true;
                        }


                        LA_39a_a.Text = ds.Tables[0].Rows[0]["LA_39a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_39b_a"].ToString() == "1")
                        {
                            LA_39b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_39b_a"].ToString() == "2")
                        {
                            LA_39b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_39b_a"].ToString() == "3")
                        {
                            LA_39b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_40a_b"].ToString() == "0")
                        {
                            LA_40a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_40a_b"].ToString() == "999")
                        {
                            LA_40a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_40a_b"].ToString() == "888")
                        {
                            LA_40a_c.Checked = true;
                        }


                        LA_40a_a.Text = ds.Tables[0].Rows[0]["LA_40a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_40b_a"].ToString() == "1")
                        {
                            LA_40b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_40b_a"].ToString() == "2")
                        {
                            LA_40b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_40b_a"].ToString() == "3")
                        {
                            LA_40b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_41a_b"].ToString() == "0")
                        {
                            LA_41a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_41a_b"].ToString() == "999")
                        {
                            LA_41a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_41a_b"].ToString() == "888")
                        {
                            LA_41a_c.Checked = true;
                        }


                        LA_41a_a.Text = ds.Tables[0].Rows[0]["LA_41a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_41b_a"].ToString() == "1")
                        {
                            LA_41b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_41b_a"].ToString() == "2")
                        {
                            LA_41b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_41b_a"].ToString() == "3")
                        {
                            LA_41b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_42a_b"].ToString() == "0")
                        {
                            LA_42a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_42a_b"].ToString() == "999")
                        {
                            LA_42a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_42a_b"].ToString() == "888")
                        {
                            LA_42a_c.Checked = true;
                        }


                        LA_42a_a.Text = ds.Tables[0].Rows[0]["LA_42a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_42b_a"].ToString() == "1")
                        {
                            LA_42b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_42b_a"].ToString() == "2")
                        {
                            LA_42b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_42b_a"].ToString() == "3")
                        {
                            LA_42b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_43a_b"].ToString() == "0")
                        {
                            LA_43a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_43a_b"].ToString() == "999")
                        {
                            LA_43a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_43a_b"].ToString() == "888")
                        {
                            LA_43a_c.Checked = true;
                        }


                        LA_43a_a.Text = ds.Tables[0].Rows[0]["LA_43a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_43b_a"].ToString() == "1")
                        {
                            LA_43b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_43b_a"].ToString() == "2")
                        {
                            LA_43b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_43b_a"].ToString() == "3")
                        {
                            LA_43b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_44a_b"].ToString() == "0")
                        {
                            LA_44a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_44a_b"].ToString() == "999")
                        {
                            LA_44a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_44a_b"].ToString() == "888")
                        {
                            LA_44a_c.Checked = true;
                        }


                        LA_44a_a.Text = ds.Tables[0].Rows[0]["LA_44a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_44b_a"].ToString() == "1")
                        {
                            LA_44b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_44b_a"].ToString() == "2")
                        {
                            LA_44b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_44b_a"].ToString() == "3")
                        {
                            LA_44b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_45a_b"].ToString() == "0")
                        {
                            LA_45a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_45a_b"].ToString() == "999")
                        {
                            LA_45a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_45a_b"].ToString() == "888")
                        {
                            LA_45a_c.Checked = true;
                        }


                        LA_45a_a.Text = ds.Tables[0].Rows[0]["LA_45a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_45b_a"].ToString() == "1")
                        {
                            LA_45b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_45b_a"].ToString() == "2")
                        {
                            LA_45b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_45b_a"].ToString() == "3")
                        {
                            LA_45b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_46a_b"].ToString() == "0")
                        {
                            LA_46a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_46a_b"].ToString() == "999")
                        {
                            LA_46a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_46a_b"].ToString() == "888")
                        {
                            LA_46a_c.Checked = true;
                        }


                        LA_46a_a.Text = ds.Tables[0].Rows[0]["LA_46a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_46b_a"].ToString() == "1")
                        {
                            LA_46b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_46b_a"].ToString() == "2")
                        {
                            LA_46b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_46b_a"].ToString() == "3")
                        {
                            LA_46b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_47a_b"].ToString() == "0")
                        {
                            LA_47a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_47a_b"].ToString() == "999")
                        {
                            LA_47a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_47a_b"].ToString() == "888")
                        {
                            LA_47a_c.Checked = true;
                        }


                        LA_47a_a.Text = ds.Tables[0].Rows[0]["LA_47a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_47b_a"].ToString() == "1")
                        {
                            LA_47b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_47b_a"].ToString() == "2")
                        {
                            LA_47b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_47b_a"].ToString() == "3")
                        {
                            LA_47b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_48a_b"].ToString() == "0")
                        {
                            LA_48a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_48a_b"].ToString() == "999")
                        {
                            LA_48a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_48a_b"].ToString() == "888")
                        {
                            LA_48a_c.Checked = true;
                        }


                        LA_48a_a.Text = ds.Tables[0].Rows[0]["LA_48a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_48b_a"].ToString() == "1")
                        {
                            LA_48b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_48b_a"].ToString() == "2")
                        {
                            LA_48b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_48b_a"].ToString() == "3")
                        {
                            LA_48b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_49a_b"].ToString() == "0")
                        {
                            LA_49a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_49a_b"].ToString() == "999")
                        {
                            LA_49a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_49a_b"].ToString() == "888")
                        {
                            LA_49a_c.Checked = true;
                        }


                        LA_49a_a.Text = ds.Tables[0].Rows[0]["LA_49a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_49b_a"].ToString() == "1")
                        {
                            LA_49b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_49b_a"].ToString() == "2")
                        {
                            LA_49b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_49b_a"].ToString() == "3")
                        {
                            LA_49b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_50a_b"].ToString() == "0")
                        {
                            LA_50a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_50a_b"].ToString() == "999")
                        {
                            LA_50a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_50a_b"].ToString() == "888")
                        {
                            LA_50a_c.Checked = true;
                        }


                        LA_50a_a.Text = ds.Tables[0].Rows[0]["LA_50a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_50b_a"].ToString() == "1")
                        {
                            LA_50b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_50b_a"].ToString() == "2")
                        {
                            LA_50b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_50b_a"].ToString() == "3")
                        {
                            LA_50b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_51a_b"].ToString() == "0")
                        {
                            LA_51a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_51a_b"].ToString() == "999")
                        {
                            LA_51a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_51a_b"].ToString() == "888")
                        {
                            LA_51a_c.Checked = true;
                        }


                        LA_51a_a.Text = ds.Tables[0].Rows[0]["LA_51a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_51b_a"].ToString() == "1")
                        {
                            LA_51b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_51b_a"].ToString() == "2")
                        {
                            LA_51b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_51b_a"].ToString() == "3")
                        {
                            LA_51b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_52a_b"].ToString() == "0")
                        {
                            LA_52a_v.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_52a_b"].ToString() == "999")
                        {
                            LA_52a_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_52a_b"].ToString() == "888")
                        {
                            LA_52a_c.Checked = true;
                        }


                        LA_52a_a.Text = ds.Tables[0].Rows[0]["LA_52a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_52b_a"].ToString() == "1")
                        {
                            LA_52b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_52b_a"].ToString() == "2")
                        {
                            LA_52b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_52b_a"].ToString() == "3")
                        {
                            LA_52b_c.Checked = true;
                        }


                    }
                }
            }
        }

        catch (Exception ex)
        {
            string message = "alert('Exception occur');";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        }

        finally
        {
            cn = null;
        }
    }


    private void CreateColsBloodCultureGrid()
    {
        try
        {

            DataColumn col1 = new DataColumn();
            col1.ColumnName = "id";
            col1.DataType = typeof(Int32);
            col1.Caption = "id";
            dt_bloodculture.Columns.Add(col1);


            DataColumn col2 = new DataColumn();
            col2.ColumnName = "organismName";
            col2.DataType = typeof(String);
            col2.Caption = "Organism Name";
            dt_bloodculture.Columns.Add(col2);


            DataColumn col3 = new DataColumn();
            col3.ColumnName = "comment";
            col3.DataType = typeof(String);
            col3.Caption = "Comments";
            dt_bloodculture.Columns.Add(col3);


            if (ViewState["organism_sno"] == "0")
            {
                organism_sno = 0;
            }


            dg_BloodCulture.DataSource = dt_bloodculture;
            dg_BloodCulture.DataBind();

            cntl_Blood_Organism.Visible = false;
        }

        catch (Exception ex)
        {

        }

        finally
        {

        }
    }



    public void fillGrid_BloodCulture_array(string organismName, string comments)
    {
        try
        {

            //DataTable dt = new DataTable();            

            //DataRow dr = dt.NewRow();

            organism_sno += 1;

            dr_bloodculture = dt_bloodculture.NewRow();

            dr_bloodculture["id"] = organism_sno;
            dr_bloodculture["organismName"] = organismName;
            dr_bloodculture["comment"] = comments;

            dt_bloodculture.Rows.Add(dr_bloodculture);


            dg_BloodCulture.DataSource = dt_bloodculture;
            dg_BloodCulture.DataBind();
        }

        catch (Exception ex)
        {
            string message = "alert('Exception Occured');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
        }

        finally
        {

        }
    }



    public void fillGrid_BloodCulture()
    {
        CConnection cn = null;

        try
        {
            cn = new CConnection();

            SqlDataAdapter da = new SqlDataAdapter("select id, organismName, comment from tblorganism where screeningID = '" + la_sno.Text + "'", cn.cn);
            //DataSet ds = new DataSet();
            dt_bloodculture = new DataTable();
            da.Fill(dt_bloodculture);

            dg_BloodCulture.Columns[0].Visible = true;
            dg_BloodCulture.DataSource = dt_bloodculture;

            dg_BloodCulture.DataBind();
            dg_BloodCulture.Columns[0].Visible = false;
        }

        catch (Exception ex)
        {

        }

        finally
        {

        }
    }


    public void getData1(string id)
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
    "a.history, " +
    "a.LA_01," +
    "a.LA_02," +
    "a.LA_02a," +
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
    "a.LA_52b_a," +
    "a.ProvisionalResult," +
    "a.rdo_BloodCulture," +
    "a.ddl_BloodCulture," +
    "a.txtOtherOrganism," +
    "a.rdo_BloodCulture_Multiple," +
    "(select count(*) from tblorganism c where c.screeningID = a.la_sno) count1 " +
            " from sample_result a inner join form1 b on a.la_sno = b.AS1_screening_ID where a.id = '" + id + "'", cn.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);


            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        la_sno.Text = ds.Tables[0].Rows[0]["AS1_screening_ID"].ToString();
                        la_fsite.Text = ds.Tables[0].Rows[0]["AS1_fsite"].ToString();
                        la_rand.Text = ds.Tables[0].Rows[0]["AS1_rand_id"].ToString();
                        la_spec.Text = ds.Tables[0].Rows[0]["AS1_barcode"].ToString();
                        la_name.Text = ds.Tables[0].Rows[0]["AS1_name"].ToString();
                        la_gen.Text = ds.Tables[0].Rows[0]["AS1_sex"].ToString();
                        la_age.Text = ds.Tables[0].Rows[0]["AS1_age"].ToString();
                        la_obj.Text = ds.Tables[0].Rows[0]["AS1_Q1_1"].ToString();


                        txthistory.Text = ds.Tables[0].Rows[0]["history"].ToString();


                        if (Request.Cookies["labid"].Value == "1" && Request.Cookies["labid"].Value == "4")
                        {
                            txthistory.Enabled = false;
                            txthistory.CssClass = "form-control";
                            txthistory.ReadOnly = true;
                        }
                        else
                        {
                            txthistory.Enabled = true;
                            txthistory.CssClass = "form-control";
                            txthistory.ReadOnly = false;
                        }


                        //LA_01.Text = ds.Tables[0].Rows[0]["LA_01"].ToString();
                        //LA_02.Text = ds.Tables[0].Rows[0]["LA_02"].ToString();
                        //LA_02a.Text = ds.Tables[0].Rows[0]["LA_02a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_03_b"].ToString() == "")
                        {
                            LA_03_v.Checked = true;
                            LA_03_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_03_b"].ToString() == "999")
                        {
                            LA_03_b.Checked = true;
                            LA_03_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_03_b"].ToString() == "888")
                        {
                            LA_03_c.Checked = true;
                            LA_03_c_CheckedChanged(null, null);
                        }





                        LA_03_a.Text = ds.Tables[0].Rows[0]["LA_03_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_04_b"].ToString() == "")
                        {
                            LA_04_v.Checked = true;
                            LA_04_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_04_b"].ToString() == "999")
                        {
                            LA_04_b.Checked = true;
                            LA_04_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_04_b"].ToString() == "888")
                        {
                            LA_04_c.Checked = true;
                            LA_04_c_CheckedChanged(null, null);
                        }


                        LA_04_a.Text = ds.Tables[0].Rows[0]["LA_04_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_05_b"].ToString() == "")
                        {
                            LA_05_v.Checked = true;
                            LA_05_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_05_b"].ToString() == "999")
                        {
                            LA_05_b.Checked = true;
                            LA_05_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_05_b"].ToString() == "888")
                        {
                            LA_05_c.Checked = true;
                            LA_05_c_CheckedChanged(null, null);
                        }


                        LA_05_a.Text = ds.Tables[0].Rows[0]["LA_05_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_06_b"].ToString() == "")
                        {
                            LA_06_v.Checked = true;
                            LA_06_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_06_b"].ToString() == "999")
                        {
                            LA_06_b.Checked = true;
                            LA_06_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_06_b"].ToString() == "888")
                        {
                            LA_06_c.Checked = true;
                            LA_06_c_CheckedChanged(null, null);
                        }


                        LA_06_a.Text = ds.Tables[0].Rows[0]["LA_06_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_07_b"].ToString() == "")
                        {
                            LA_07_v.Checked = true;
                            LA_07_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_07_b"].ToString() == "999")
                        {
                            LA_07_b.Checked = true;
                            LA_07_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_07_b"].ToString() == "888")
                        {
                            LA_07_c.Checked = true;
                            LA_07_c_CheckedChanged(null, null);
                        }


                        LA_07_a.Text = ds.Tables[0].Rows[0]["LA_07_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_08_b"].ToString() == "")
                        {
                            LA_08_v.Checked = true;
                            LA_08_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_08_b"].ToString() == "999")
                        {
                            LA_08_b.Checked = true;
                            LA_08_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_08_b"].ToString() == "888")
                        {
                            LA_08_c.Checked = true;
                            LA_08_c_CheckedChanged(null, null);
                        }


                        LA_08_a.Text = ds.Tables[0].Rows[0]["LA_08_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_09_b"].ToString() == "")
                        {
                            LA_09_v.Checked = true;
                            LA_09_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_09_b"].ToString() == "999")
                        {
                            LA_09_b.Checked = true;
                            LA_09_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_09_b"].ToString() == "888")
                        {
                            LA_09_c.Checked = true;
                            LA_09_c_CheckedChanged(null, null);
                        }


                        LA_09_a.Text = ds.Tables[0].Rows[0]["LA_09_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_10_b"].ToString() == "")
                        {
                            LA_10_v.Checked = true;
                            LA_10_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_10_b"].ToString() == "999")
                        {
                            LA_10_b.Checked = true;
                            LA_10_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_10_b"].ToString() == "888")
                        {
                            LA_10_c.Checked = true;
                            LA_10_c_CheckedChanged(null, null);
                        }


                        LA_10_a.Text = ds.Tables[0].Rows[0]["LA_10_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_11_b"].ToString() == "")
                        {
                            LA_11_v.Checked = true;
                            LA_11_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_11_b"].ToString() == "999")
                        {
                            LA_11_b.Checked = true;
                            LA_11_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_11_b"].ToString() == "888")
                        {
                            LA_11_c.Checked = true;
                            LA_11_c_CheckedChanged(null, null);
                        }


                        LA_11_a.Text = ds.Tables[0].Rows[0]["LA_11_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_12_b"].ToString() == "")
                        {
                            LA_12_v.Checked = true;
                            LA_12_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_12_b"].ToString() == "999")
                        {
                            LA_12_b.Checked = true;
                            LA_12_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_12_b"].ToString() == "888")
                        {
                            LA_12_c.Checked = true;
                            LA_12_c_CheckedChanged(null, null);
                        }


                        LA_12_a.Text = ds.Tables[0].Rows[0]["LA_12_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_13_b"].ToString() == "")
                        {
                            LA_13_v.Checked = true;
                            LA_13_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_13_b"].ToString() == "999")
                        {
                            LA_13_b.Checked = true;
                            LA_13_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_13_b"].ToString() == "888")
                        {
                            LA_13_c.Checked = true;
                            LA_13_c_CheckedChanged(null, null);
                        }


                        LA_13_a.Text = ds.Tables[0].Rows[0]["LA_13_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_14_b"].ToString() == "")
                        {
                            LA_14_v.Checked = true;
                            LA_14_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_14_b"].ToString() == "999")
                        {
                            LA_14_b.Checked = true;
                            LA_14_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_14_b"].ToString() == "888")
                        {
                            LA_14_c.Checked = true;
                            LA_14_c_CheckedChanged(null, null);
                        }


                        LA_14_a.Text = ds.Tables[0].Rows[0]["LA_14_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_15_b"].ToString() == "")
                        {
                            LA_15_v.Checked = true;
                            LA_15_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_15_b"].ToString() == "999")
                        {
                            LA_15_b.Checked = true;
                            LA_15_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_15_b"].ToString() == "888")
                        {
                            LA_15_c.Checked = true;
                            LA_15_c_CheckedChanged(null, null);
                        }


                        LA_15_a.Text = ds.Tables[0].Rows[0]["LA_15_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_16_b"].ToString() == "")
                        {
                            LA_16_v.Checked = true;
                            LA_16_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_16_b"].ToString() == "999")
                        {
                            LA_16_b.Checked = true;
                            LA_16_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_16_b"].ToString() == "888")
                        {
                            LA_16_c.Checked = true;
                            LA_16_c_CheckedChanged(null, null);
                        }


                        LA_16_a.Text = ds.Tables[0].Rows[0]["LA_16_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LF_01"].ToString() == "")
                        {
                            LF_01_v.Checked = true;
                            LF_01_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LF_01"].ToString() == "999")
                        {
                            LF_01_b.Checked = true;
                            LF_01_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LF_01"].ToString() == "888")
                        {
                            LF_01_c.Checked = true;
                            LF_01_c_CheckedChanged(null, null);
                        }


                        LF_01_a.Text = ds.Tables[0].Rows[0]["LF_01_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LF_02"].ToString() == "")
                        {
                            LF_02_v.Checked = true;
                            LF_02_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LF_02"].ToString() == "999")
                        {
                            LF_02_b.Checked = true;
                            LF_02_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LF_02"].ToString() == "888")
                        {
                            LF_02_c.Checked = true;
                            LF_02_c_CheckedChanged(null, null);
                        }


                        LF_02_a.Text = ds.Tables[0].Rows[0]["LF_02_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LF_03"].ToString() == "")
                        {
                            LF_03_v.Checked = true;
                            LF_03_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LF_03"].ToString() == "999")
                        {
                            LF_03_b.Checked = true;
                            LF_03_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LF_03"].ToString() == "888")
                        {
                            LF_03_c.Checked = true;
                            LF_03_c_CheckedChanged(null, null);
                        }


                        LF_03_a.Text = ds.Tables[0].Rows[0]["LF_03_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LF_04"].ToString() == "")
                        {
                            LF_04_v.Checked = true;
                            LF_04_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LF_04"].ToString() == "999")
                        {
                            LF_04_b.Checked = true;
                            LF_04_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LF_04"].ToString() == "888")
                        {
                            LF_04_c.Checked = true;
                            LF_04_c_CheckedChanged(null, null);
                        }


                        LF_04_a.Text = ds.Tables[0].Rows[0]["LF_04_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LF_05"].ToString() == "")
                        {
                            LF_05_v.Checked = true;
                            LF_05_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LF_05"].ToString() == "999")
                        {
                            LF_05_b.Checked = true;
                            LF_05_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LF_05"].ToString() == "888")
                        {
                            LF_05_c.Checked = true;
                            LF_05_c_CheckedChanged(null, null);
                        }


                        LF_05_a.Text = ds.Tables[0].Rows[0]["LF_05_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LF_06"].ToString() == "")
                        {
                            LF_06_v.Checked = true;
                            LF_06_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LF_06"].ToString() == "999")
                        {
                            LF_06_b.Checked = true;
                            LF_06_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LF_06"].ToString() == "888")
                        {
                            LF_06_c.Checked = true;
                            LF_06_c_CheckedChanged(null, null);
                        }


                        LF_06_a.Text = ds.Tables[0].Rows[0]["LF_06_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LF_07"].ToString() == "")
                        {
                            LF_07_v.Checked = true;
                            LF_07_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LF_07"].ToString() == "999")
                        {
                            LF_07_b.Checked = true;
                            LF_07_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LF_07"].ToString() == "888")
                        {
                            LF_07_c.Checked = true;
                            LF_07_c_CheckedChanged(null, null);
                        }


                        LF_07_a.Text = ds.Tables[0].Rows[0]["LF_07_a"].ToString();


                        if (ds.Tables[0].Rows[0]["RF_01"].ToString() == "")
                        {
                            RF_01_v.Checked = true;
                            RF_01_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["RF_01"].ToString() == "999")
                        {
                            RF_01_b.Checked = true;
                            RF_01_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["RF_01"].ToString() == "888")
                        {
                            RF_01_c.Checked = true;
                            RF_01_c_CheckedChanged(null, null);
                        }


                        RF_01_a.Text = ds.Tables[0].Rows[0]["RF_01_a"].ToString();


                        if (ds.Tables[0].Rows[0]["RF_02"].ToString() == "")
                        {
                            RF_02_v.Checked = true;
                            RF_02_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["RF_02"].ToString() == "999")
                        {
                            RF_02_b.Checked = true;
                            RF_02_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["RF_02"].ToString() == "888")
                        {
                            RF_02_c.Checked = true;
                            RF_02_c_CheckedChanged(null, null);
                        }


                        RF_02_a.Text = ds.Tables[0].Rows[0]["RF_02_a"].ToString();


                        if (ds.Tables[0].Rows[0]["RF_03"].ToString() == "")
                        {
                            RF_03_v.Checked = true;
                            RF_03_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["RF_03"].ToString() == "999")
                        {
                            RF_03_b.Checked = true;
                            RF_03_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["RF_03"].ToString() == "888")
                        {
                            RF_03_c.Checked = true;
                            RF_03_c_CheckedChanged(null, null);
                        }


                        RF_03_a.Text = ds.Tables[0].Rows[0]["RF_03_a"].ToString();


                        if (ds.Tables[0].Rows[0]["RF_04"].ToString() == "")
                        {
                            RF_04_v.Checked = true;
                            RF_04_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["RF_04"].ToString() == "999")
                        {
                            RF_04_b.Checked = true;
                            RF_04_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["RF_04"].ToString() == "888")
                        {
                            RF_04_c.Checked = true;
                            RF_04_c_CheckedChanged(null, null);
                        }


                        RF_04_a.Text = ds.Tables[0].Rows[0]["RF_04_a"].ToString();


                        if (ds.Tables[0].Rows[0]["SE_01"].ToString() == "")
                        {
                            SE_01_v.Checked = true;
                            SE_01_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["SE_01"].ToString() == "999")
                        {
                            SE_01_b.Checked = true;
                            SE_01_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["SE_01"].ToString() == "888")
                        {
                            SE_01_c.Checked = true;
                            SE_01_c_CheckedChanged(null, null);
                        }


                        SE_01_a.Text = ds.Tables[0].Rows[0]["SE_01_a"].ToString();


                        if (ds.Tables[0].Rows[0]["SE_02"].ToString() == "")
                        {
                            SE_02_v.Checked = true;
                            SE_02_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["SE_02"].ToString() == "999")
                        {
                            SE_02_b.Checked = true;
                            SE_02_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["SE_02"].ToString() == "888")
                        {
                            SE_02_c.Checked = true;
                            SE_02_c_CheckedChanged(null, null);
                        }


                        SE_02_a.Text = ds.Tables[0].Rows[0]["SE_02_a"].ToString();


                        if (ds.Tables[0].Rows[0]["SE_03"].ToString() == "")
                        {
                            SE_03_v.Checked = true;
                            SE_03_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["SE_03"].ToString() == "999")
                        {
                            SE_03_b.Checked = true;
                            SE_03_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["SE_03"].ToString() == "888")
                        {
                            SE_03_c.Checked = true;
                            SE_03_c_CheckedChanged(null, null);
                        }


                        SE_03_a.Text = ds.Tables[0].Rows[0]["SE_03_a"].ToString();


                        if (ds.Tables[0].Rows[0]["SE_04"].ToString() == "")
                        {
                            SE_04_v.Checked = true;
                            SE_04_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["SE_04"].ToString() == "999")
                        {
                            SE_04_b.Checked = true;
                            SE_04_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["SE_04"].ToString() == "888")
                        {
                            SE_04_c.Checked = true;
                            SE_04_c_CheckedChanged(null, null);
                        }


                        SE_04_a.Text = ds.Tables[0].Rows[0]["SE_04_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_01"].ToString() == "")
                        {
                            CS_01_v.Checked = true;
                            CS_01_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_01"].ToString() == "999")
                        {
                            CS_01_b.Checked = true;
                            CS_01_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_01"].ToString() == "888")
                        {
                            CS_01_c.Checked = true;
                            CS_01_c_CheckedChanged(null, null);
                        }


                        CS_01_a.Text = ds.Tables[0].Rows[0]["CS_01_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_02"].ToString() == "")
                        {
                            CS_02_v.Checked = true;
                            CS_02_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_02"].ToString() == "999")
                        {
                            CS_02_b.Checked = true;
                            CS_02_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_02"].ToString() == "888")
                        {
                            CS_02_c.Checked = true;
                            CS_02_c_CheckedChanged(null, null);
                        }


                        CS_02_a.Text = ds.Tables[0].Rows[0]["CS_02_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_03"].ToString() == "")
                        {
                            CS_03_v.Checked = true;
                            CS_03_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_03"].ToString() == "999")
                        {
                            CS_03_b.Checked = true;
                            CS_03_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_03"].ToString() == "888")
                        {
                            CS_03_c.Checked = true;
                            CS_03_c_CheckedChanged(null, null);
                        }


                        CS_03_a.Text = ds.Tables[0].Rows[0]["CS_03_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_04"].ToString() == "")
                        {
                            CS_04_v.Checked = true;
                            CS_04_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_04"].ToString() == "999")
                        {
                            CS_04_b.Checked = true;
                            CS_04_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_04"].ToString() == "888")
                        {
                            CS_04_c.Checked = true;
                            CS_04_c_CheckedChanged(null, null);
                        }


                        CS_04_a.Text = ds.Tables[0].Rows[0]["CS_04_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_05"].ToString() == "")
                        {
                            CS_05_v.Checked = true;
                            CS_05_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_05"].ToString() == "999")
                        {
                            CS_05_b.Checked = true;
                            CS_05_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_05"].ToString() == "888")
                        {
                            CS_05_c.Checked = true;
                            CS_05_c_CheckedChanged(null, null);
                        }


                        CS_05_a.Text = ds.Tables[0].Rows[0]["CS_05_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_06"].ToString() == "")
                        {
                            CS_06_v.Checked = true;
                            CS_06_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_06"].ToString() == "999")
                        {
                            CS_06_b.Checked = true;
                            CS_06_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_06"].ToString() == "888")
                        {
                            CS_06_c.Checked = true;
                            CS_06_c_CheckedChanged(null, null);
                        }


                        CS_06_a.Text = ds.Tables[0].Rows[0]["CS_06_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_07"].ToString() == "")
                        {
                            CS_07_v.Checked = true;
                            CS_07_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_07"].ToString() == "999")
                        {
                            CS_07_b.Checked = true;
                            CS_07_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_07"].ToString() == "888")
                        {
                            CS_07_c.Checked = true;
                            CS_07_c_CheckedChanged(null, null);
                        }


                        CS_07_a.Text = ds.Tables[0].Rows[0]["CS_07_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_08"].ToString() == "")
                        {
                            CS_08_v.Checked = true;
                            CS_08_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_08"].ToString() == "999")
                        {
                            CS_08_b.Checked = true;
                            CS_08_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_08"].ToString() == "888")
                        {
                            CS_08_c.Checked = true;
                            CS_08_c_CheckedChanged(null, null);
                        }


                        CS_08_a.Text = ds.Tables[0].Rows[0]["CS_08_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_09"].ToString() == "")
                        {
                            CS_09_v.Checked = true;
                            CS_09_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_09"].ToString() == "999")
                        {
                            CS_09_b.Checked = true;
                            CS_09_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_09"].ToString() == "888")
                        {
                            CS_09_c.Checked = true;
                            CS_09_c_CheckedChanged(null, null);
                        }


                        CS_09_a.Text = ds.Tables[0].Rows[0]["CS_09_a"].ToString();


                        if (ds.Tables[0].Rows[0]["CS_10"].ToString() == "")
                        {
                            CS_10_v.Checked = true;
                            CS_10_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_10"].ToString() == "999")
                        {
                            CS_10_b.Checked = true;
                            CS_10_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["CS_10"].ToString() == "888")
                        {
                            CS_10_c.Checked = true;
                            CS_10_c_CheckedChanged(null, null);
                        }


                        CS_10_a.Text = ds.Tables[0].Rows[0]["CS_10_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_01"].ToString() == "")
                        {
                            UR_01_v.Checked = true;
                            UR_01_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_01"].ToString() == "999")
                        {
                            UR_01_b.Checked = true;
                            UR_01_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_01"].ToString() == "888")
                        {
                            UR_01_c.Checked = true;
                            UR_01_c_CheckedChanged(null, null);
                        }


                        UR_01_a.Text = ds.Tables[0].Rows[0]["UR_01_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_02"].ToString() == "")
                        {
                            UR_02_v.Checked = true;
                            UR_02_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_02"].ToString() == "999")
                        {
                            UR_02_b.Checked = true;
                            UR_02_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_02"].ToString() == "888")
                        {
                            UR_02_c.Checked = true;
                            UR_02_c_CheckedChanged(null, null);
                        }


                        UR_02_a.Text = ds.Tables[0].Rows[0]["UR_02_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_03"].ToString() == "")
                        {
                            UR_03_v.Checked = true;
                            UR_03_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_03"].ToString() == "999")
                        {
                            UR_03_b.Checked = true;
                            UR_03_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_03"].ToString() == "888")
                        {
                            UR_03_c.Checked = true;
                            UR_03_c_CheckedChanged(null, null);
                        }


                        UR_03_a.Text = ds.Tables[0].Rows[0]["UR_03_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_04"].ToString() == "")
                        {
                            UR_04_v.Checked = true;
                            UR_04_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_04"].ToString() == "999")
                        {
                            UR_04_b.Checked = true;
                            UR_04_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_04"].ToString() == "888")
                        {
                            UR_04_c.Checked = true;
                            UR_04_c_CheckedChanged(null, null);
                        }


                        UR_04_a.Text = ds.Tables[0].Rows[0]["UR_04_a"].ToString();




                        if (ds.Tables[0].Rows[0]["UR_04a"].ToString() == "")
                        {
                            UR_04a_v.Checked = true;
                            UR_04a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_04a"].ToString() == "999")
                        {
                            UR_04a_b.Checked = true;
                            UR_04a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_04a"].ToString() == "888")
                        {
                            UR_04a_c.Checked = true;
                            UR_04a_c_CheckedChanged(null, null);
                        }


                        UR_04a_a.Text = ds.Tables[0].Rows[0]["UR_04a_a"].ToString();





                        if (ds.Tables[0].Rows[0]["UR_05"].ToString() == "")
                        {
                            UR_05_v.Checked = true;
                            UR_05_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_05"].ToString() == "999")
                        {
                            UR_05_b.Checked = true;
                            UR_05_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_05"].ToString() == "888")
                        {
                            UR_05_c.Checked = true;
                            UR_05_c_CheckedChanged(null, null);
                        }


                        UR_05_a.Text = ds.Tables[0].Rows[0]["UR_05_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_06"].ToString() == "")
                        {
                            UR_06_v.Checked = true;
                            UR_06_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_06"].ToString() == "999")
                        {
                            UR_06_b.Checked = true;
                            UR_06_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_06"].ToString() == "888")
                        {
                            UR_06_c.Checked = true;
                            UR_06_c_CheckedChanged(null, null);
                        }


                        UR_06_a.Text = ds.Tables[0].Rows[0]["UR_06_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_07"].ToString() == "")
                        {
                            UR_07_v.Checked = true;
                            UR_07_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_07"].ToString() == "999")
                        {
                            UR_07_b.Checked = true;
                            UR_07_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_07"].ToString() == "888")
                        {
                            UR_07_c.Checked = true;
                            UR_07_c_CheckedChanged(null, null);
                        }


                        UR_07_a.Text = ds.Tables[0].Rows[0]["UR_07_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_08"].ToString() == "")
                        {
                            UR_08_v.Checked = true;
                            UR_08_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_08"].ToString() == "999")
                        {
                            UR_08_b.Checked = true;
                            UR_08_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_08"].ToString() == "888")
                        {
                            UR_08_c.Checked = true;
                            UR_08_c_CheckedChanged(null, null);
                        }


                        UR_08_a.Text = ds.Tables[0].Rows[0]["UR_08_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_10"].ToString() == "")
                        {
                            UR_10_v.Checked = true;
                            UR_10_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_10"].ToString() == "999")
                        {
                            UR_10_b.Checked = true;
                            UR_10_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_10"].ToString() == "888")
                        {
                            UR_10_c.Checked = true;
                            UR_10_c_CheckedChanged(null, null);
                        }


                        UR_10_a.Text = ds.Tables[0].Rows[0]["UR_10_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_11"].ToString() == "")
                        {
                            UR_11_v.Checked = true;
                            UR_11_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_11"].ToString() == "999")
                        {
                            UR_11_b.Checked = true;
                            UR_11_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_11"].ToString() == "888")
                        {
                            UR_11_c.Checked = true;
                            UR_11_c_CheckedChanged(null, null);
                        }


                        UR_11_a.Text = ds.Tables[0].Rows[0]["UR_11_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_12"].ToString() == "")
                        {
                            UR_12_v.Checked = true;
                            UR_12_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_12"].ToString() == "999")
                        {
                            UR_12_b.Checked = true;
                            UR_12_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_12"].ToString() == "888")
                        {
                            UR_12_c.Checked = true;
                            UR_12_c_CheckedChanged(null, null);
                        }


                        UR_12_a.Text = ds.Tables[0].Rows[0]["UR_12_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_13"].ToString() == "")
                        {
                            UR_13_v.Checked = true;
                            UR_13_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_13"].ToString() == "999")
                        {
                            UR_13_b.Checked = true;
                            UR_13_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_13"].ToString() == "888")
                        {
                            UR_13_c.Checked = true;
                            UR_13_c_CheckedChanged(null, null);
                        }


                        UR_13_a.Text = ds.Tables[0].Rows[0]["UR_13_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_14"].ToString() == "")
                        {
                            UR_14_v.Checked = true;
                            UR_14_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_14"].ToString() == "999")
                        {
                            UR_14_b.Checked = true;
                            UR_14_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_14"].ToString() == "888")
                        {
                            UR_14_c.Checked = true;
                            UR_14_c_CheckedChanged(null, null);
                        }


                        UR_14_a.Text = ds.Tables[0].Rows[0]["UR_14_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_15"].ToString() == "")
                        {
                            UR_15_v.Checked = true;
                            UR_15_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_15"].ToString() == "999")
                        {
                            UR_15_b.Checked = true;
                            UR_15_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_15"].ToString() == "888")
                        {
                            UR_15_c.Checked = true;
                            UR_15_c_CheckedChanged(null, null);
                        }


                        UR_15_a.Text = ds.Tables[0].Rows[0]["UR_15_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_16"].ToString() == "")
                        {
                            UR_16_v.Checked = true;
                            UR_16_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_16"].ToString() == "999")
                        {
                            UR_16_b.Checked = true;
                            UR_16_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_16"].ToString() == "888")
                        {
                            UR_16_c.Checked = true;
                            UR_16_c_CheckedChanged(null, null);
                        }


                        UR_16_a.Text = ds.Tables[0].Rows[0]["UR_16_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_17"].ToString() == "")
                        {
                            UR_17_v.Checked = true;
                            UR_17_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_17"].ToString() == "999")
                        {
                            UR_17_b.Checked = true;
                            UR_17_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_17"].ToString() == "888")
                        {
                            UR_17_c.Checked = true;
                            UR_17_c_CheckedChanged(null, null);
                        }


                        UR_17_a.Text = ds.Tables[0].Rows[0]["UR_17_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_18"].ToString() == "")
                        {
                            UR_18_v.Checked = true;
                            UR_18_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_18"].ToString() == "999")
                        {
                            UR_18_b.Checked = true;
                            UR_18_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_18"].ToString() == "888")
                        {
                            UR_18_c.Checked = true;
                            UR_18_c_CheckedChanged(null, null);
                        }


                        UR_18_a.Text = ds.Tables[0].Rows[0]["UR_18_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_19"].ToString() == "")
                        {
                            UR_19_v.Checked = true;
                            UR_19_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_19"].ToString() == "999")
                        {
                            UR_19_b.Checked = true;
                            UR_19_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_19"].ToString() == "888")
                        {
                            UR_19_c.Checked = true;
                            UR_19_c_CheckedChanged(null, null);
                        }


                        UR_19_a.Text = ds.Tables[0].Rows[0]["UR_19_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_20"].ToString() == "")
                        {
                            UR_20_v.Checked = true;
                            UR_20_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_20"].ToString() == "999")
                        {
                            UR_20_b.Checked = true;
                            UR_20_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_20"].ToString() == "888")
                        {
                            UR_20_c.Checked = true;
                            UR_20_c_CheckedChanged(null, null);
                        }


                        UR_20_a.Text = ds.Tables[0].Rows[0]["UR_20_a"].ToString();


                        if (ds.Tables[0].Rows[0]["UR_21"].ToString() == "")
                        {
                            UR_21_v.Checked = true;
                            UR_21_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_21"].ToString() == "999")
                        {
                            UR_21_b.Checked = true;
                            UR_21_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["UR_21"].ToString() == "888")
                        {
                            UR_21_c.Checked = true;
                            UR_21_c_CheckedChanged(null, null);
                        }


                        UR_21_a.Text = ds.Tables[0].Rows[0]["UR_21_a"].ToString();


                        uc_01_ca.Text = ds.Tables[0].Rows[0]["uc_01_ca"].ToString();



                        if (ds.Tables[0].Rows[0]["uc_01a"].ToString() == "1")
                        {
                            uc_01_a.Checked = true;
                            uc_01_a_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_01a"].ToString() == "2")
                        {
                            uc_01_b.Checked = true;
                            uc_01_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_01a"].ToString() == "999")
                        {
                            uc_01_c.Checked = true;
                            uc_01_c_CheckedChanged(null, null);
                        }



                        if (ds.Tables[0].Rows[0]["uc_02a"].ToString() == "")
                        {
                            uc_02a_v.Checked = true;
                            uc_02a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_02a"].ToString() == "999")
                        {
                            uc_02a_b.Checked = true;
                            uc_02a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_02a"].ToString() == "888")
                        {
                            uc_02a_c.Checked = true;
                            uc_02a_c_CheckedChanged(null, null);
                        }


                        uc_02a_a.Text = ds.Tables[0].Rows[0]["uc_02a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_02b"].ToString() == "1")
                        {
                            uc_02b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_02b"].ToString() == "2")
                        {
                            uc_02b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_02b"].ToString() == "3")
                        {
                            uc_02b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_03a"].ToString() == "")
                        {
                            uc_03a_v.Checked = true;
                            uc_03a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_03a"].ToString() == "999")
                        {
                            uc_03a_b.Checked = true;
                            uc_03a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_03a"].ToString() == "888")
                        {
                            uc_03a_c.Checked = true;
                            uc_03a_c_CheckedChanged(null, null);
                        }


                        uc_03a_a.Text = ds.Tables[0].Rows[0]["uc_03a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_03b"].ToString() == "1")
                        {
                            uc_03b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_03b"].ToString() == "2")
                        {
                            uc_03b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_03b"].ToString() == "3")
                        {
                            uc_03b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_04a"].ToString() == "")
                        {
                            uc_04a_v.Checked = true;
                            uc_04a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_04a"].ToString() == "999")
                        {
                            uc_04a_b.Checked = true;
                            uc_04a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_04a"].ToString() == "888")
                        {
                            uc_04a_c.Checked = true;
                            uc_04a_c_CheckedChanged(null, null);
                        }


                        uc_04a_a.Text = ds.Tables[0].Rows[0]["uc_04a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_04b"].ToString() == "1")
                        {
                            uc_04b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_04b"].ToString() == "2")
                        {
                            uc_04b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_04b"].ToString() == "3")
                        {
                            uc_04b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_05a"].ToString() == "")
                        {
                            uc_05a_v.Checked = true;
                            uc_05a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_05a"].ToString() == "999")
                        {
                            uc_05a_b.Checked = true;
                            uc_05a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_05a"].ToString() == "888")
                        {
                            uc_05a_c.Checked = true;
                            uc_05a_c_CheckedChanged(null, null);
                        }


                        uc_05a_a.Text = ds.Tables[0].Rows[0]["uc_05a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_05b"].ToString() == "1")
                        {
                            uc_05b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_05b"].ToString() == "2")
                        {
                            uc_05b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_05b"].ToString() == "3")
                        {
                            uc_05b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_06a"].ToString() == "")
                        {
                            uc_06a_v.Checked = true;
                            uc_06a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_06a"].ToString() == "999")
                        {
                            uc_06a_b.Checked = true;
                            uc_06a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_06a"].ToString() == "888")
                        {
                            uc_06a_c.Checked = true;
                            uc_06a_c_CheckedChanged(null, null);
                        }


                        uc_06a_a.Text = ds.Tables[0].Rows[0]["uc_06a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_06b"].ToString() == "1")
                        {
                            uc_06b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_06b"].ToString() == "2")
                        {
                            uc_06b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_06b"].ToString() == "3")
                        {
                            uc_06b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_07a"].ToString() == "")
                        {
                            uc_07a_v.Checked = true;
                            uc_07a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_07a"].ToString() == "999")
                        {
                            uc_07a_b.Checked = true;
                            uc_07a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_07a"].ToString() == "888")
                        {
                            uc_07a_c.Checked = true;
                            uc_07a_c_CheckedChanged(null, null);
                        }


                        uc_07a_a.Text = ds.Tables[0].Rows[0]["uc_07a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_07b"].ToString() == "1")
                        {
                            uc_07b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_07b"].ToString() == "2")
                        {
                            uc_07b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_07b"].ToString() == "3")
                        {
                            uc_07b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_08a"].ToString() == "")
                        {
                            uc_08a_v.Checked = true;
                            uc_08a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_08a"].ToString() == "999")
                        {
                            uc_08a_b.Checked = true;
                            uc_08a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_08a"].ToString() == "888")
                        {
                            uc_08a_c.Checked = true;
                            uc_08a_c_CheckedChanged(null, null);
                        }


                        uc_08a_a.Text = ds.Tables[0].Rows[0]["uc_08a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_08b"].ToString() == "1")
                        {
                            uc_08b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_08b"].ToString() == "2")
                        {
                            uc_08b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_08b"].ToString() == "3")
                        {
                            uc_08b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_09a"].ToString() == "")
                        {
                            uc_09a_v.Checked = true;
                            uc_09a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_09a"].ToString() == "999")
                        {
                            uc_09a_b.Checked = true;
                            uc_09a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_09a"].ToString() == "888")
                        {
                            uc_09a_c.Checked = true;
                            uc_09a_c_CheckedChanged(null, null);
                        }


                        uc_09a_a.Text = ds.Tables[0].Rows[0]["uc_09a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_09b"].ToString() == "1")
                        {
                            uc_09b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_09b"].ToString() == "2")
                        {
                            uc_09b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_09b"].ToString() == "3")
                        {
                            uc_09b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_10a"].ToString() == "")
                        {
                            uc_10a_v.Checked = true;
                            uc_10a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_10a"].ToString() == "999")
                        {
                            uc_10a_b.Checked = true;
                            uc_10a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_10a"].ToString() == "888")
                        {
                            uc_10a_c.Checked = true;
                            uc_10a_c_CheckedChanged(null, null);
                        }


                        uc_10a_a.Text = ds.Tables[0].Rows[0]["uc_10a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_10b"].ToString() == "1")
                        {
                            uc_10b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_10b"].ToString() == "2")
                        {
                            uc_10b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_10b"].ToString() == "3")
                        {
                            uc_10b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_11a"].ToString() == "")
                        {
                            uc_11a_v.Checked = true;
                            uc_11a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_11a"].ToString() == "999")
                        {
                            uc_11a_b.Checked = true;
                            uc_11a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_11a"].ToString() == "888")
                        {
                            uc_11a_c.Checked = true;
                            uc_11a_c_CheckedChanged(null, null);
                        }


                        uc_11a_a.Text = ds.Tables[0].Rows[0]["uc_11a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_11b"].ToString() == "1")
                        {
                            uc_11b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_11b"].ToString() == "2")
                        {
                            uc_11b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_11b"].ToString() == "3")
                        {
                            uc_11b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_12a"].ToString() == "")
                        {
                            uc_12a_v.Checked = true;
                            uc_12a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_12a"].ToString() == "999")
                        {
                            uc_12a_b.Checked = true;
                            uc_12a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_12a"].ToString() == "888")
                        {
                            uc_12a_c.Checked = true;
                            uc_12a_c_CheckedChanged(null, null);
                        }


                        uc_12a_a.Text = ds.Tables[0].Rows[0]["uc_12a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_12b"].ToString() == "1")
                        {
                            uc_12b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_12b"].ToString() == "2")
                        {
                            uc_12b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_12b"].ToString() == "3")
                        {
                            uc_12b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_13a"].ToString() == "")
                        {
                            uc_13a_v.Checked = true;
                            uc_13a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_13a"].ToString() == "999")
                        {
                            uc_13a_b.Checked = true;
                            uc_13a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_13a"].ToString() == "888")
                        {
                            uc_13a_c.Checked = true;
                            uc_13a_c_CheckedChanged(null, null);
                        }


                        uc_13a_a.Text = ds.Tables[0].Rows[0]["uc_13a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_13b"].ToString() == "1")
                        {
                            uc_13b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_13b"].ToString() == "2")
                        {
                            uc_13b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_13b"].ToString() == "3")
                        {
                            uc_13b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_14a"].ToString() == "")
                        {
                            uc_14a_v.Checked = true;
                            uc_14a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_14a"].ToString() == "999")
                        {
                            uc_14a_b.Checked = true;
                            uc_14a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_14a"].ToString() == "888")
                        {
                            uc_14a_c.Checked = true;
                            uc_14a_c_CheckedChanged(null, null);
                        }


                        uc_14a_a.Text = ds.Tables[0].Rows[0]["uc_14a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_14b"].ToString() == "1")
                        {
                            uc_14b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_14b"].ToString() == "2")
                        {
                            uc_14b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_14b"].ToString() == "3")
                        {
                            uc_14b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_15a"].ToString() == "")
                        {
                            uc_15a_v.Checked = true;
                            uc_15a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_15a"].ToString() == "999")
                        {
                            uc_15a_b.Checked = true;
                            uc_15a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_15a"].ToString() == "888")
                        {
                            uc_15a_c.Checked = true;
                            uc_15a_c_CheckedChanged(null, null);
                        }


                        uc_15a_a.Text = ds.Tables[0].Rows[0]["uc_15a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_15b"].ToString() == "1")
                        {
                            uc_15b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_15b"].ToString() == "2")
                        {
                            uc_15b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_15b"].ToString() == "3")
                        {
                            uc_15b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_16a"].ToString() == "")
                        {
                            uc_16a_v.Checked = true;
                            uc_16a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_16a"].ToString() == "999")
                        {
                            uc_16a_b.Checked = true;
                            uc_16a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_16a"].ToString() == "888")
                        {
                            uc_16a_c.Checked = true;
                            uc_16a_c_CheckedChanged(null, null);
                        }


                        uc_16a_a.Text = ds.Tables[0].Rows[0]["uc_16a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_16b"].ToString() == "1")
                        {
                            uc_16b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_16b"].ToString() == "2")
                        {
                            uc_16b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_16b"].ToString() == "3")
                        {
                            uc_16b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_17a"].ToString() == "")
                        {
                            uc_17a_v.Checked = true;
                            uc_17a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_17a"].ToString() == "999")
                        {
                            uc_17a_b.Checked = true;
                            uc_17a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_17a"].ToString() == "888")
                        {
                            uc_17a_c.Checked = true;
                            uc_17a_c_CheckedChanged(null, null);
                        }


                        uc_17a_a.Text = ds.Tables[0].Rows[0]["uc_17a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_17b"].ToString() == "1")
                        {
                            uc_17b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_17b"].ToString() == "2")
                        {
                            uc_17b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_17b"].ToString() == "3")
                        {
                            uc_17b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_18a"].ToString() == "")
                        {
                            uc_18a_v.Checked = true;
                            uc_18a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_18a"].ToString() == "999")
                        {
                            uc_18a_b.Checked = true;
                            uc_18a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_18a"].ToString() == "888")
                        {
                            uc_18a_c.Checked = true;
                            uc_18a_c_CheckedChanged(null, null);
                        }


                        uc_18a_a.Text = ds.Tables[0].Rows[0]["uc_18a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_18b"].ToString() == "1")
                        {
                            uc_18b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_18b"].ToString() == "2")
                        {
                            uc_18b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_18b"].ToString() == "3")
                        {
                            uc_18b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_19a"].ToString() == "")
                        {
                            uc_19a_v.Checked = true;
                            uc_19a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_19a"].ToString() == "999")
                        {
                            uc_19a_b.Checked = true;
                            uc_19a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_19a"].ToString() == "888")
                        {
                            uc_19a_c.Checked = true;
                            uc_19a_c_CheckedChanged(null, null);
                        }


                        uc_19a_a.Text = ds.Tables[0].Rows[0]["uc_19a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_19b"].ToString() == "1")
                        {
                            uc_19b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_19b"].ToString() == "2")
                        {
                            uc_19b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_19b"].ToString() == "3")
                        {
                            uc_19b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_20a"].ToString() == "")
                        {
                            uc_20a_v.Checked = true;
                            uc_20a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_20a"].ToString() == "999")
                        {
                            uc_20a_b.Checked = true;
                            uc_20a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_20a"].ToString() == "888")
                        {
                            uc_20a_c.Checked = true;
                            uc_20a_c_CheckedChanged(null, null);
                        }


                        uc_20a_a.Text = ds.Tables[0].Rows[0]["uc_20a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_20b"].ToString() == "1")
                        {
                            uc_20b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_20b"].ToString() == "2")
                        {
                            uc_20b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_20b"].ToString() == "3")
                        {
                            uc_20b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_21a"].ToString() == "")
                        {
                            uc_21a_v.Checked = true;
                            uc_21a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_21a"].ToString() == "999")
                        {
                            uc_21a_b.Checked = true;
                            uc_21a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_21a"].ToString() == "888")
                        {
                            uc_21a_c.Checked = true;
                            uc_21a_c_CheckedChanged(null, null);
                        }


                        uc_21a_a.Text = ds.Tables[0].Rows[0]["uc_21a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_21b"].ToString() == "1")
                        {
                            uc_21b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_21b"].ToString() == "2")
                        {
                            uc_21b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_21b"].ToString() == "3")
                        {
                            uc_21b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_22a"].ToString() == "")
                        {
                            uc_22a_v.Checked = true;
                            uc_22a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_22a"].ToString() == "999")
                        {
                            uc_22a_b.Checked = true;
                            uc_22a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_22a"].ToString() == "888")
                        {
                            uc_22a_c.Checked = true;
                            uc_22a_c_CheckedChanged(null, null);
                        }


                        uc_22a_a.Text = ds.Tables[0].Rows[0]["uc_22a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_22b"].ToString() == "1")
                        {
                            uc_22b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_22b"].ToString() == "2")
                        {
                            uc_22b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_22b"].ToString() == "3")
                        {
                            uc_22b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_23a"].ToString() == "")
                        {
                            uc_23a_v.Checked = true;
                            uc_23a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_23a"].ToString() == "999")
                        {
                            uc_23a_b.Checked = true;
                            uc_23a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_23a"].ToString() == "888")
                        {
                            uc_23a_c.Checked = true;
                            uc_23a_c_CheckedChanged(null, null);
                        }


                        uc_23a_a.Text = ds.Tables[0].Rows[0]["uc_23a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_23b"].ToString() == "1")
                        {
                            uc_23b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_23b"].ToString() == "2")
                        {
                            uc_23b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_23b"].ToString() == "3")
                        {
                            uc_23b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_24a"].ToString() == "")
                        {
                            uc_24a_v.Checked = true;
                            uc_24a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_24a"].ToString() == "999")
                        {
                            uc_24a_b.Checked = true;
                            uc_24a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_24a"].ToString() == "888")
                        {
                            uc_24a_c.Checked = true;
                            uc_24a_c_CheckedChanged(null, null);
                        }


                        uc_24a_a.Text = ds.Tables[0].Rows[0]["uc_24a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_24b"].ToString() == "1")
                        {
                            uc_24b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_24b"].ToString() == "2")
                        {
                            uc_24b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_24b"].ToString() == "3")
                        {
                            uc_24b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_25a"].ToString() == "")
                        {
                            uc_25a_v.Checked = true;
                            uc_25a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_25a"].ToString() == "999")
                        {
                            uc_25a_b.Checked = true;
                            uc_25a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_25a"].ToString() == "888")
                        {
                            uc_25a_c.Checked = true;
                            uc_25a_c_CheckedChanged(null, null);
                        }


                        uc_25a_a.Text = ds.Tables[0].Rows[0]["uc_25a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_25b"].ToString() == "1")
                        {
                            uc_25b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_25b"].ToString() == "2")
                        {
                            uc_25b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_25b"].ToString() == "3")
                        {
                            uc_25b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_26a"].ToString() == "")
                        {
                            uc_26a_v.Checked = true;
                            uc_26a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_26a"].ToString() == "999")
                        {
                            uc_26a_b.Checked = true;
                            uc_26a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_26a"].ToString() == "888")
                        {
                            uc_26a_c.Checked = true;
                            uc_26a_c_CheckedChanged(null, null);
                        }


                        uc_26a_a.Text = ds.Tables[0].Rows[0]["uc_26a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_26b"].ToString() == "1")
                        {
                            uc_26b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_26b"].ToString() == "2")
                        {
                            uc_26b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_26b"].ToString() == "3")
                        {
                            uc_26b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_27a"].ToString() == "")
                        {
                            uc_27a_v.Checked = true;
                            uc_27a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_27a"].ToString() == "999")
                        {
                            uc_27a_b.Checked = true;
                            uc_27a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_27a"].ToString() == "888")
                        {
                            uc_27a_c.Checked = true;
                            uc_27a_c_CheckedChanged(null, null);
                        }


                        uc_27a_a.Text = ds.Tables[0].Rows[0]["uc_27a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_27b"].ToString() == "1")
                        {
                            uc_27b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_27b"].ToString() == "2")
                        {
                            uc_27b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_27b"].ToString() == "3")
                        {
                            uc_27b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_28a"].ToString() == "")
                        {
                            uc_28a_v.Checked = true;
                            uc_28a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_28a"].ToString() == "999")
                        {
                            uc_28a_b.Checked = true;
                            uc_28a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_28a"].ToString() == "888")
                        {
                            uc_28a_c.Checked = true;
                            uc_28a_c_CheckedChanged(null, null);
                        }


                        uc_28a_a.Text = ds.Tables[0].Rows[0]["uc_28a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_28b"].ToString() == "1")
                        {
                            uc_28b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_28b"].ToString() == "2")
                        {
                            uc_28b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_28b"].ToString() == "3")
                        {
                            uc_28b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_29a"].ToString() == "")
                        {
                            uc_29a_v.Checked = true;
                            uc_29a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_29a"].ToString() == "999")
                        {
                            uc_29a_b.Checked = true;
                            uc_29a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_29a"].ToString() == "888")
                        {
                            uc_29a_c.Checked = true;
                            uc_29a_c_CheckedChanged(null, null);
                        }


                        uc_29a_a.Text = ds.Tables[0].Rows[0]["uc_29a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_29b"].ToString() == "1")
                        {
                            uc_29b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_29b"].ToString() == "2")
                        {
                            uc_29b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_29b"].ToString() == "3")
                        {
                            uc_29b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_30a"].ToString() == "")
                        {
                            uc_30a_v.Checked = true;
                            uc_30a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_30a"].ToString() == "999")
                        {
                            uc_30a_b.Checked = true;
                            uc_30a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_30a"].ToString() == "888")
                        {
                            uc_30a_c.Checked = true;
                            uc_30a_c_CheckedChanged(null, null);
                        }


                        uc_30a_a.Text = ds.Tables[0].Rows[0]["uc_30a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_30b"].ToString() == "1")
                        {
                            uc_30b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_30b"].ToString() == "2")
                        {
                            uc_30b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_30b"].ToString() == "3")
                        {
                            uc_30b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_31a"].ToString() == "")
                        {
                            uc_31a_v.Checked = true;
                            uc_31a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_31a"].ToString() == "999")
                        {
                            uc_31a_b.Checked = true;
                            uc_31a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_31a"].ToString() == "888")
                        {
                            uc_31a_c.Checked = true;
                            uc_31a_c_CheckedChanged(null, null);
                        }


                        uc_31a_a.Text = ds.Tables[0].Rows[0]["uc_31a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_31b"].ToString() == "1")
                        {
                            uc_31b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_31b"].ToString() == "2")
                        {
                            uc_31b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_31b"].ToString() == "3")
                        {
                            uc_31b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_32a"].ToString() == "")
                        {
                            uc_32a_v.Checked = true;
                            uc_32a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_32a"].ToString() == "999")
                        {
                            uc_32a_b.Checked = true;
                            uc_32a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_32a"].ToString() == "888")
                        {
                            uc_32a_c.Checked = true;
                            uc_32a_c_CheckedChanged(null, null);
                        }


                        uc_32a_a.Text = ds.Tables[0].Rows[0]["uc_32a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_32b"].ToString() == "1")
                        {
                            uc_32b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_32b"].ToString() == "2")
                        {
                            uc_32b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_32b"].ToString() == "3")
                        {
                            uc_32b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_33a"].ToString() == "")
                        {
                            uc_33a_v.Checked = true;
                            uc_33a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_33a"].ToString() == "999")
                        {
                            uc_33a_b.Checked = true;
                            uc_33a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_33a"].ToString() == "888")
                        {
                            uc_33a_c.Checked = true;
                            uc_33a_c_CheckedChanged(null, null);
                        }


                        uc_33a_a.Text = ds.Tables[0].Rows[0]["uc_33a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_33b"].ToString() == "1")
                        {
                            uc_33b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_33b"].ToString() == "2")
                        {
                            uc_33b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_33b"].ToString() == "3")
                        {
                            uc_33b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_34a"].ToString() == "")
                        {
                            uc_34a_v.Checked = true;
                            uc_34a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_34a"].ToString() == "999")
                        {
                            uc_34a_b.Checked = true;
                            uc_34a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_34a"].ToString() == "888")
                        {
                            uc_34a_c.Checked = true;
                            uc_34a_c_CheckedChanged(null, null);
                        }


                        uc_34a_a.Text = ds.Tables[0].Rows[0]["uc_34a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_34b"].ToString() == "1")
                        {
                            uc_34b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_34b"].ToString() == "2")
                        {
                            uc_34b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_34b"].ToString() == "3")
                        {
                            uc_34b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_35a"].ToString() == "")
                        {
                            uc_35a_v.Checked = true;
                            uc_35a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_35a"].ToString() == "999")
                        {
                            uc_35a_b.Checked = true;
                            uc_35a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_35a"].ToString() == "888")
                        {
                            uc_35a_c.Checked = true;
                            uc_35a_c_CheckedChanged(null, null);
                        }


                        uc_35a_a.Text = ds.Tables[0].Rows[0]["uc_35a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_35b"].ToString() == "1")
                        {
                            uc_35b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_35b"].ToString() == "2")
                        {
                            uc_35b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_35b"].ToString() == "3")
                        {
                            uc_35b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_36a"].ToString() == "")
                        {
                            uc_36a_v.Checked = true;
                            uc_36a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_36a"].ToString() == "999")
                        {
                            uc_36a_b.Checked = true;
                            uc_36a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_36a"].ToString() == "888")
                        {
                            uc_36a_c.Checked = true;
                            uc_36a_c_CheckedChanged(null, null);
                        }


                        uc_36a_a.Text = ds.Tables[0].Rows[0]["uc_36a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_36b"].ToString() == "1")
                        {
                            uc_36b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_36b"].ToString() == "2")
                        {
                            uc_36b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_36b"].ToString() == "3")
                        {
                            uc_36b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["uc_37a"].ToString() == "")
                        {
                            uc_37a_v.Checked = true;
                            uc_37a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_37a"].ToString() == "999")
                        {
                            uc_37a_b.Checked = true;
                            uc_37a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["uc_37a"].ToString() == "888")
                        {
                            uc_37a_c.Checked = true;
                            uc_37a_c_CheckedChanged(null, null);
                        }


                        uc_37a_a.Text = ds.Tables[0].Rows[0]["uc_37a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["uc_37b"].ToString() == "1")
                        {
                            uc_37b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_37b"].ToString() == "2")
                        {
                            uc_37b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["uc_37b"].ToString() == "3")
                        {
                            uc_37b_c.Checked = true;
                        }



                        LA_17.Text = ds.Tables[0].Rows[0]["LA_17"].ToString();


                        LA_18.Text = ds.Tables[0].Rows[0]["LA_18"].ToString();


                        //LA_19.Text = ds.Tables[0].Rows[0]["LA_19"].ToString();



                        if (ds.Tables[0].Rows[0]["LA_20a_b"].ToString() == "")
                        {
                            LA_20a_v.Checked = true;
                            LA_20a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_20a_b"].ToString() == "999")
                        {
                            LA_20a_b.Checked = true;
                            LA_20a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_20a_b"].ToString() == "888")
                        {
                            LA_20a_c.Checked = true;
                            LA_20a_c_CheckedChanged(null, null);
                        }


                        //if (ds.Tables[0].Rows[0]["LA_20a_b"].ToString() == "999" || ds.Tables[0].Rows[0]["LA_20a_b"].ToString() == "888")
                        //{
                        //    pnl_LA_20a.Visible = false;

                        //    LA_20a_a.Text = "";
                        //    LA_20a_a.Visible = false;

                        //    LA_20b_a.Checked = false;
                        //    LA_20b_b.Checked = false;
                        //    LA_20b_c.Checked = false;

                        //    LA_20b_a.Visible = false;
                        //    LA_20b_b.Visible = false;
                        //    LA_20b_c.Visible = false;
                        //}
                        //else
                        //{

                        //    pnl_LA_20a.Visible = true;

                        //    LA_20a_a.Visible = true;

                        //    LA_20b_a.Visible = true;
                        //    LA_20b_b.Visible = true;
                        //    LA_20b_c.Visible = true;

                        //}


                        LA_20a_a.Text = ds.Tables[0].Rows[0]["LA_20a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_20b_a"].ToString() == "1")
                        {
                            LA_20b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_20b_a"].ToString() == "2")
                        {
                            LA_20b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_20b_a"].ToString() == "3")
                        {
                            LA_20b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_21a_b"].ToString() == "")
                        {
                            LA_21a_v.Checked = true;
                            LA_21a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_21a_b"].ToString() == "999")
                        {
                            LA_21a_b.Checked = true;
                            LA_21a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_21a_b"].ToString() == "888")
                        {
                            LA_21a_c.Checked = true;
                            LA_21a_c_CheckedChanged(null, null);
                        }


                        LA_21a_a.Text = ds.Tables[0].Rows[0]["LA_21a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_21b_a"].ToString() == "1")
                        {
                            LA_21b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_21b_a"].ToString() == "2")
                        {
                            LA_21b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_21b_a"].ToString() == "3")
                        {
                            LA_21b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_22a_b"].ToString() == "")
                        {
                            LA_22a_v.Checked = true;
                            LA_22a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_22a_b"].ToString() == "999")
                        {
                            LA_22a_b.Checked = true;
                            LA_22a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_22a_b"].ToString() == "888")
                        {
                            LA_22a_c.Checked = true;
                            LA_22a_c_CheckedChanged(null, null);
                        }


                        LA_22a_a.Text = ds.Tables[0].Rows[0]["LA_22a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_22b_a"].ToString() == "1")
                        {
                            LA_22b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_22b_a"].ToString() == "2")
                        {
                            LA_22b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_22b_a"].ToString() == "3")
                        {
                            LA_22b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_23a_b"].ToString() == "")
                        {
                            LA_23a_v.Checked = true;
                            LA_23a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_23a_b"].ToString() == "999")
                        {
                            LA_23a_b.Checked = true;
                            LA_23a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_23a_b"].ToString() == "888")
                        {
                            LA_23a_c.Checked = true;
                            LA_23a_c_CheckedChanged(null, null);
                        }


                        LA_23a_a.Text = ds.Tables[0].Rows[0]["LA_23a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_23b_a"].ToString() == "1")
                        {
                            LA_23b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_23b_a"].ToString() == "2")
                        {
                            LA_23b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_23b_a"].ToString() == "3")
                        {
                            LA_23b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_24a_b"].ToString() == "")
                        {
                            LA_24a_v.Checked = true;
                            LA_24a_v_CheckedChanged1(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_24a_b"].ToString() == "999")
                        {
                            LA_24a_b.Checked = true;
                            LA_24a_b_CheckedChanged1(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_24a_b"].ToString() == "888")
                        {
                            LA_24a_c.Checked = true;
                            LA_24a_c_CheckedChanged1(null, null);
                        }


                        LA_24a_a.Text = ds.Tables[0].Rows[0]["LA_24a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_24b_a"].ToString() == "1")
                        {
                            LA_24b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_24b_a"].ToString() == "2")
                        {
                            LA_24b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_24b_a"].ToString() == "3")
                        {
                            LA_24b_c.Checked = true;
                        }




                        if (ds.Tables[0].Rows[0]["LA_25a_b"].ToString() == "")
                        {
                            LA_25a_v.Checked = true;
                            LA_25a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_25a_b"].ToString() == "999")
                        {
                            LA_25a_b.Checked = true;
                            LA_25a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_25a_b"].ToString() == "888")
                        {
                            LA_25a_c.Checked = true;
                            LA_25a_c_CheckedChanged(null, null);
                        }


                        LA_25a_a.Text = ds.Tables[0].Rows[0]["LA_25a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_25b_a"].ToString() == "1")
                        {
                            LA_25b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_25b_a"].ToString() == "2")
                        {
                            LA_25b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_25b_a"].ToString() == "3")
                        {
                            LA_25b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_26a_b"].ToString() == "")
                        {
                            LA_26a_v.Checked = true;
                            LA_26a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_26a_b"].ToString() == "999")
                        {
                            LA_26a_b.Checked = true;
                            LA_26a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_26a_b"].ToString() == "888")
                        {
                            LA_26a_c.Checked = true;
                            LA_26a_c_CheckedChanged(null, null);
                        }


                        LA_26a_a.Text = ds.Tables[0].Rows[0]["LA_26a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_26b_a"].ToString() == "1")
                        {
                            LA_26b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_26b_a"].ToString() == "2")
                        {
                            LA_26b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_26b_a"].ToString() == "3")
                        {
                            LA_26b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_27a_b"].ToString() == "")
                        {
                            LA_27a_v.Checked = true;
                            LA_27a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_27a_b"].ToString() == "999")
                        {
                            LA_27a_b.Checked = true;
                            LA_27a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_27a_b"].ToString() == "888")
                        {
                            LA_27a_c.Checked = true;
                            LA_27a_c_CheckedChanged(null, null);
                        }


                        LA_27a_a.Text = ds.Tables[0].Rows[0]["LA_27a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_27b_a"].ToString() == "1")
                        {
                            LA_27b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_27b_a"].ToString() == "2")
                        {
                            LA_27b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_27b_a"].ToString() == "3")
                        {
                            LA_27b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_28a_b"].ToString() == "")
                        {
                            LA_28a_v.Checked = true;
                            LA_28a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_28a_b"].ToString() == "999")
                        {
                            LA_28a_b.Checked = true;
                            LA_28a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_28a_b"].ToString() == "888")
                        {
                            LA_28a_c.Checked = true;
                            LA_28a_c_CheckedChanged(null, null);
                        }


                        LA_28a_a.Text = ds.Tables[0].Rows[0]["LA_28a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_28b_a"].ToString() == "1")
                        {
                            LA_28b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_28b_a"].ToString() == "2")
                        {
                            LA_28b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_28b_a"].ToString() == "3")
                        {
                            LA_28b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_29a_b"].ToString() == "")
                        {
                            LA_29a_v.Checked = true;
                            LA_29a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_29a_b"].ToString() == "999")
                        {
                            LA_29a_b.Checked = true;
                            LA_29a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_29a_b"].ToString() == "888")
                        {
                            LA_29a_c.Checked = true;
                            LA_29a_c_CheckedChanged(null, null);
                        }


                        LA_29a_a.Text = ds.Tables[0].Rows[0]["LA_29a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_29b_a"].ToString() == "1")
                        {
                            LA_29b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_29b_a"].ToString() == "2")
                        {
                            LA_29b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_29b_a"].ToString() == "3")
                        {
                            LA_29b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_30a_b"].ToString() == "")
                        {
                            LA_30a_v.Checked = true;
                            LA_30a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_30a_b"].ToString() == "999")
                        {
                            LA_30a_b.Checked = true;
                            LA_30a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_30a_b"].ToString() == "888")
                        {
                            LA_30a_c.Checked = true;
                            LA_30a_c_CheckedChanged(null, null);
                        }


                        LA_30a_a.Text = ds.Tables[0].Rows[0]["LA_30a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_30b_a"].ToString() == "1")
                        {
                            LA_30b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_30b_a"].ToString() == "2")
                        {
                            LA_30b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_30b_a"].ToString() == "3")
                        {
                            LA_30b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_31a_b"].ToString() == "")
                        {
                            LA_31a_v.Checked = true;
                            LA_31a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_31a_b"].ToString() == "999")
                        {
                            LA_31a_b.Checked = true;
                            LA_31a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_31a_b"].ToString() == "888")
                        {
                            LA_31a_c.Checked = true;
                            LA_31a_c_CheckedChanged(null, null);
                        }


                        LA_31a_a.Text = ds.Tables[0].Rows[0]["LA_31a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_31b_a"].ToString() == "1")
                        {
                            LA_31b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_31b_a"].ToString() == "2")
                        {
                            LA_31b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_31b_a"].ToString() == "3")
                        {
                            LA_31b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_32a_b"].ToString() == "")
                        {
                            LA_32a_v.Checked = true;
                            LA_32a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_32a_b"].ToString() == "999")
                        {
                            LA_32a_b.Checked = true;
                            LA_32a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_32a_b"].ToString() == "888")
                        {
                            LA_32a_c.Checked = true;
                            LA_32a_c_CheckedChanged(null, null);
                        }


                        LA_32a_a.Text = ds.Tables[0].Rows[0]["LA_32a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_32b_a"].ToString() == "1")
                        {
                            LA_32b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_32b_a"].ToString() == "2")
                        {
                            LA_32b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_32b_a"].ToString() == "3")
                        {
                            LA_32b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_33a_b"].ToString() == "")
                        {
                            LA_33a_v.Checked = true;
                            LA_33a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_33a_b"].ToString() == "999")
                        {
                            LA_33a_b.Checked = true;
                            LA_33a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_33a_b"].ToString() == "888")
                        {
                            LA_33a_c.Checked = true;
                            LA_33a_c_CheckedChanged(null, null);
                        }


                        LA_33a_a.Text = ds.Tables[0].Rows[0]["LA_33a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_33b_a"].ToString() == "1")
                        {
                            LA_33b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_33b_a"].ToString() == "2")
                        {
                            LA_33b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_33b_a"].ToString() == "3")
                        {
                            LA_33b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_34a_b"].ToString() == "")
                        {
                            LA_34a_v.Checked = true;
                            LA_34a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_34a_b"].ToString() == "999")
                        {
                            LA_34a_b.Checked = true;
                            LA_34a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_34a_b"].ToString() == "888")
                        {
                            LA_34a_c.Checked = true;
                            LA_34a_c_CheckedChanged(null, null);
                        }


                        LA_34a_a.Text = ds.Tables[0].Rows[0]["LA_34a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_34b_a"].ToString() == "1")
                        {
                            LA_34b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_34b_a"].ToString() == "2")
                        {
                            LA_34b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_34b_a"].ToString() == "3")
                        {
                            LA_34b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_35a_b"].ToString() == "")
                        {
                            LA_35a_v.Checked = true;
                            LA_35a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_35a_b"].ToString() == "999")
                        {
                            LA_35a_b.Checked = true;
                            LA_35a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_35a_b"].ToString() == "888")
                        {
                            LA_35a_c.Checked = true;
                            LA_35a_c_CheckedChanged(null, null);
                        }


                        LA_35a_a.Text = ds.Tables[0].Rows[0]["LA_35a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_35b_a"].ToString() == "1")
                        {
                            LA_35b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_35b_a"].ToString() == "2")
                        {
                            LA_35b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_35b_a"].ToString() == "3")
                        {
                            LA_35b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_36a_b"].ToString() == "")
                        {
                            LA_36a_v.Checked = true;
                            LA_36a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_36a_b"].ToString() == "999")
                        {
                            LA_36a_b.Checked = true;
                            LA_36a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_36a_b"].ToString() == "888")
                        {
                            LA_36a_c.Checked = true;
                            LA_36a_c_CheckedChanged(null, null);
                        }


                        LA_36a_a.Text = ds.Tables[0].Rows[0]["LA_36a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_36b_a"].ToString() == "1")
                        {
                            LA_36b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_36b_a"].ToString() == "2")
                        {
                            LA_36b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_36b_a"].ToString() == "3")
                        {
                            LA_36b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_37a_b"].ToString() == "")
                        {
                            LA_37a_v.Checked = true;
                            LA_37a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_37a_b"].ToString() == "999")
                        {
                            LA_37a_b.Checked = true;
                            LA_37a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_37a_b"].ToString() == "888")
                        {
                            LA_37a_c.Checked = true;
                            LA_37a_c_CheckedChanged(null, null);
                        }


                        LA_37a_a.Text = ds.Tables[0].Rows[0]["LA_37a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_37b_a"].ToString() == "1")
                        {
                            LA_37b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_37b_a"].ToString() == "2")
                        {
                            LA_37b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_37b_a"].ToString() == "3")
                        {
                            LA_37b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_38a_b"].ToString() == "")
                        {
                            LA_38a_v.Checked = true;
                            LA_38a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_38a_b"].ToString() == "999")
                        {
                            LA_38a_b.Checked = true;
                            LA_38a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_38a_b"].ToString() == "888")
                        {
                            LA_38a_c.Checked = true;
                            LA_38a_c_CheckedChanged(null, null);
                        }


                        LA_38a_a.Text = ds.Tables[0].Rows[0]["LA_38a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_38b_a"].ToString() == "1")
                        {
                            LA_38b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_38b_a"].ToString() == "2")
                        {
                            LA_38b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_38b_a"].ToString() == "3")
                        {
                            LA_38b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_39a_b"].ToString() == "")
                        {
                            LA_39a_v.Checked = true;
                            LA_39a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_39a_b"].ToString() == "999")
                        {
                            LA_39a_b.Checked = true;
                            LA_39a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_39a_b"].ToString() == "888")
                        {
                            LA_39a_c.Checked = true;
                            LA_39a_c_CheckedChanged(null, null);
                        }


                        LA_39a_a.Text = ds.Tables[0].Rows[0]["LA_39a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_39b_a"].ToString() == "1")
                        {
                            LA_39b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_39b_a"].ToString() == "2")
                        {
                            LA_39b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_39b_a"].ToString() == "3")
                        {
                            LA_39b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_40a_b"].ToString() == "")
                        {
                            LA_40a_v.Checked = true;
                            LA_40a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_40a_b"].ToString() == "999")
                        {
                            LA_40a_b.Checked = true;
                            LA_40a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_40a_b"].ToString() == "888")
                        {
                            LA_40a_c.Checked = true;
                            LA_40a_c_CheckedChanged(null, null);
                        }


                        LA_40a_a.Text = ds.Tables[0].Rows[0]["LA_40a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_40b_a"].ToString() == "1")
                        {
                            LA_40b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_40b_a"].ToString() == "2")
                        {
                            LA_40b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_40b_a"].ToString() == "3")
                        {
                            LA_40b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_41a_b"].ToString() == "")
                        {
                            LA_41a_v.Checked = true;
                            LA_41a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_41a_b"].ToString() == "999")
                        {
                            LA_41a_b.Checked = true;
                            LA_41a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_41a_b"].ToString() == "888")
                        {
                            LA_41a_c.Checked = true;
                            LA_41a_c_CheckedChanged(null, null);
                        }


                        LA_41a_a.Text = ds.Tables[0].Rows[0]["LA_41a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_41b_a"].ToString() == "1")
                        {
                            LA_41b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_41b_a"].ToString() == "2")
                        {
                            LA_41b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_41b_a"].ToString() == "3")
                        {
                            LA_41b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_42a_b"].ToString() == "")
                        {
                            LA_42a_v.Checked = true;
                            LA_42a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_42a_b"].ToString() == "999")
                        {
                            LA_42a_b.Checked = true;
                            LA_42a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_42a_b"].ToString() == "888")
                        {
                            LA_42a_c.Checked = true;
                            LA_42a_c_CheckedChanged(null, null);
                        }


                        LA_42a_a.Text = ds.Tables[0].Rows[0]["LA_42a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_42b_a"].ToString() == "1")
                        {
                            LA_42b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_42b_a"].ToString() == "2")
                        {
                            LA_42b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_42b_a"].ToString() == "3")
                        {
                            LA_42b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_43a_b"].ToString() == "")
                        {
                            LA_43a_v.Checked = true;
                            LA_43a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_43a_b"].ToString() == "999")
                        {
                            LA_43a_b.Checked = true;
                            LA_43a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_43a_b"].ToString() == "888")
                        {
                            LA_43a_c.Checked = true;
                            LA_43a_c_CheckedChanged(null, null);
                        }


                        LA_43a_a.Text = ds.Tables[0].Rows[0]["LA_43a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_43b_a"].ToString() == "1")
                        {
                            LA_43b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_43b_a"].ToString() == "2")
                        {
                            LA_43b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_43b_a"].ToString() == "3")
                        {
                            LA_43b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_44a_b"].ToString() == "")
                        {
                            LA_44a_v.Checked = true;
                            LA_44a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_44a_b"].ToString() == "999")
                        {
                            LA_44a_b.Checked = true;
                            LA_44a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_44a_b"].ToString() == "888")
                        {
                            LA_44a_c.Checked = true;
                            LA_44a_c_CheckedChanged(null, null);
                        }


                        LA_44a_a.Text = ds.Tables[0].Rows[0]["LA_44a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_44b_a"].ToString() == "1")
                        {
                            LA_44b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_44b_a"].ToString() == "2")
                        {
                            LA_44b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_44b_a"].ToString() == "3")
                        {
                            LA_44b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_45a_b"].ToString() == "")
                        {
                            LA_45a_v.Checked = true;
                            LA_45a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_45a_b"].ToString() == "999")
                        {
                            LA_45a_b.Checked = true;
                            LA_45a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_45a_b"].ToString() == "888")
                        {
                            LA_45a_c.Checked = true;
                            LA_45a_c_CheckedChanged(null, null);
                        }


                        LA_45a_a.Text = ds.Tables[0].Rows[0]["LA_45a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_45b_a"].ToString() == "1")
                        {
                            LA_45b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_45b_a"].ToString() == "2")
                        {
                            LA_45b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_45b_a"].ToString() == "3")
                        {
                            LA_45b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_46a_b"].ToString() == "")
                        {
                            LA_46a_v.Checked = true;
                            LA_46a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_46a_b"].ToString() == "999")
                        {
                            LA_46a_b.Checked = true;
                            LA_46a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_46a_b"].ToString() == "888")
                        {
                            LA_46a_c.Checked = true;
                            LA_46a_c_CheckedChanged(null, null);
                        }


                        LA_46a_a.Text = ds.Tables[0].Rows[0]["LA_46a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_46b_a"].ToString() == "1")
                        {
                            LA_46b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_46b_a"].ToString() == "2")
                        {
                            LA_46b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_46b_a"].ToString() == "3")
                        {
                            LA_46b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_47a_b"].ToString() == "")
                        {
                            LA_47a_v.Checked = true;
                            LA_47a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_47a_b"].ToString() == "999")
                        {
                            LA_47a_b.Checked = true;
                            LA_47a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_47a_b"].ToString() == "888")
                        {
                            LA_47a_c.Checked = true;
                            LA_47a_c_CheckedChanged(null, null);
                        }


                        LA_47a_a.Text = ds.Tables[0].Rows[0]["LA_47a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_47b_a"].ToString() == "1")
                        {
                            LA_47b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_47b_a"].ToString() == "2")
                        {
                            LA_47b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_47b_a"].ToString() == "3")
                        {
                            LA_47b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_48a_b"].ToString() == "")
                        {
                            LA_48a_v.Checked = true;
                            LA_48a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_48a_b"].ToString() == "999")
                        {
                            LA_48a_b.Checked = true;
                            LA_48a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_48a_b"].ToString() == "888")
                        {
                            LA_48a_c.Checked = true;
                            LA_48a_c_CheckedChanged(null, null);
                        }


                        LA_48a_a.Text = ds.Tables[0].Rows[0]["LA_48a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_48b_a"].ToString() == "1")
                        {
                            LA_48b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_48b_a"].ToString() == "2")
                        {
                            LA_48b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_48b_a"].ToString() == "3")
                        {
                            LA_48b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_49a_b"].ToString() == "")
                        {
                            LA_49a_v.Checked = true;
                            LA_49a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_49a_b"].ToString() == "999")
                        {
                            LA_49a_b.Checked = true;
                            LA_49a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_49a_b"].ToString() == "888")
                        {
                            LA_49a_c.Checked = true;
                            LA_49a_c_CheckedChanged(null, null);
                        }


                        LA_49a_a.Text = ds.Tables[0].Rows[0]["LA_49a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_49b_a"].ToString() == "1")
                        {
                            LA_49b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_49b_a"].ToString() == "2")
                        {
                            LA_49b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_49b_a"].ToString() == "3")
                        {
                            LA_49b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_50a_b"].ToString() == "")
                        {
                            LA_50a_v.Checked = true;
                            LA_50a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_50a_b"].ToString() == "999")
                        {
                            LA_50a_b.Checked = true;
                            LA_50a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_50a_b"].ToString() == "888")
                        {
                            LA_50a_c.Checked = true;
                            LA_50a_c_CheckedChanged(null, null);
                        }


                        LA_50a_a.Text = ds.Tables[0].Rows[0]["LA_50a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_50b_a"].ToString() == "1")
                        {
                            LA_50b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_50b_a"].ToString() == "2")
                        {
                            LA_50b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_50b_a"].ToString() == "3")
                        {
                            LA_50b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_51a_b"].ToString() == "")
                        {
                            LA_51a_v.Checked = true;
                            LA_51a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_51a_b"].ToString() == "999")
                        {
                            LA_51a_b.Checked = true;
                            LA_51a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_51a_b"].ToString() == "888")
                        {
                            LA_51a_c.Checked = true;
                            LA_51a_c_CheckedChanged(null, null);
                        }


                        LA_51a_a.Text = ds.Tables[0].Rows[0]["LA_51a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_51b_a"].ToString() == "1")
                        {
                            LA_51b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_51b_a"].ToString() == "2")
                        {
                            LA_51b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_51b_a"].ToString() == "3")
                        {
                            LA_51b_c.Checked = true;
                        }


                        if (ds.Tables[0].Rows[0]["LA_52a_b"].ToString() == "")
                        {
                            LA_52a_v.Checked = true;
                            LA_52a_v_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_52a_b"].ToString() == "999")
                        {
                            LA_52a_b.Checked = true;
                            LA_52a_b_CheckedChanged(null, null);
                        }
                        else if (ds.Tables[0].Rows[0]["LA_52a_b"].ToString() == "888")
                        {
                            LA_52a_c.Checked = true;
                            LA_52a_c_CheckedChanged(null, null);
                        }


                        LA_52a_a.Text = ds.Tables[0].Rows[0]["LA_52a_a"].ToString();


                        if (ds.Tables[0].Rows[0]["LA_52b_a"].ToString() == "1")
                        {
                            LA_52b_a.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_52b_a"].ToString() == "2")
                        {
                            LA_52b_b.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["LA_52b_a"].ToString() == "3")
                        {
                            LA_52b_c.Checked = true;
                        }


                        ProvisionalResult.Text = ds.Tables[0].Rows[0]["ProvisionalResult"].ToString();


                        if (ds.Tables[0].Rows[0]["rdo_BloodCulture"].ToString() == "1")
                        {
                            rd_BloodCulture_Pos.Checked = true;
                            rd_BloodCulture_Pos_CheckedChanged(null, null);
                            ddl_BloodCulture.SelectedIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["ddl_BloodCulture"].ToString());

                        }
                        else if (ds.Tables[0].Rows[0]["rdo_BloodCulture"].ToString() == "2")
                        {
                            rd_BloodCulture_Neg.Checked = true;
                            rd_BloodCulture_Neg_CheckedChanged(null, null);
                        }



                        if (ddl_BloodCulture.SelectedIndex == 31)
                        {
                            txtOtherOrganism.ReadOnly = false;
                            txtOtherOrganism.Text = ds.Tables[0].Rows[0]["LA_19"].ToString();
                        }
                        else
                        {
                            txtOtherOrganism.ReadOnly = true;
                        }




                        if (ds.Tables[0].Rows[0]["rdo_BloodCulture_Multiple"].ToString() == "1")
                        {
                            BloodCulture_Multiple_Yes.Checked = true;
                            cntl_Blood_Organism.Visible = true;
                            dg_BloodCulture.Visible = true;
                        }
                        else
                        {
                            BloodCulture_Multiple_No.Checked = true;
                            cntl_Blood_Organism.Visible = false;
                            dg_BloodCulture.Visible = false;
                        }


                        organism_sno = Convert.ToInt32(ds.Tables[0].Rows[0]["count1"].ToString());
                        ViewState["organism_sno"] = ds.Tables[0].Rows[0]["count1"].ToString();

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



    protected void cmdSaveDraft_Click(object sender, EventArgs e)
    {
        if (ViewState["isupdate"] == null)
        {
            SaveData("Draft");
        }
        else
        {
            if (Request["labid"].ToString() == "3")
            {
                AuditTrials();
                UpdateData_historyonly("history");
            }
            else
            {
                AuditTrials();
                UpdateData("Draft");
            }

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
            " from sample_result a inner join form1 b on a.la_sno = b.AS1_screening_ID where a.la_sno = '" + la_sno.Text + "' and b.userid='usernrl'", cn.cn);
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



    private void AddFormStatus(string formstatus)
    {
        CConnection cn = null;

        try
        {
            cn = new CConnection();

            DateTime dt_entry = new DateTime();
            string[] arr_entry = null;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            dt_entry = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());

            arr_entry = dt_entry.ToString().Split(' ');


            arr_entry = arr_entry[0].ToString().Split('/');
            string mydt = arr_entry[1] + "/" + arr_entry[0] + "/" + arr_entry[2];

            arr_entry = dt_entry.ToString().Split(' ');

            arr_entry = arr_entry[1].ToString().Split(':');
            string mytm = arr_entry[0] + ":" + arr_entry[1] + ":" + arr_entry[2];


            SqlDataAdapter da = new SqlDataAdapter("insert into formstatus values('" + la_sno.Text + "', '" + formstatus + "', '" + mydt + " " + mytm + "', '" + mydt + " " + mytm + "', '" + Session["userid"].ToString() + "', '" + Request["labid"].ToString() + "', '" + Session["userid"].ToString() + "')", cn.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

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


    private void UpdateFormStatus(string formstatus)
    {
        CConnection cn = null;

        try
        {
            cn = new CConnection();


            DateTime dt_entry = new DateTime();

            string[] arr_entry = null;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            dt_entry = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());

            arr_entry = dt_entry.ToString().Split(' ');


            arr_entry = arr_entry[0].ToString().Split('/');
            string mydt = arr_entry[1] + "/" + arr_entry[0] + "/" + arr_entry[2];

            arr_entry = dt_entry.ToString().Split(' ');

            arr_entry = arr_entry[1].ToString().Split(':');
            string mytm = arr_entry[0] + ":" + arr_entry[1] + ":" + arr_entry[2];


            SqlDataAdapter da = new SqlDataAdapter("update formstatus set fstatus='" + formstatus + "', Last_Update_DTTM='" + mydt + " " + mytm + "', Last_Update_UserId='" + Session["userid"].ToString() + "' where AS1_screening_ID='" + la_sno.Text + "' and labid='1'", cn.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

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


    private DataSet GetData_report()
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
            " from sample_result a inner join form1 b on a.la_sno = b.AS1_screening_ID where a.la_sno = '" + la_sno.Text + "' and b.labid='1'", cn.cn);
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


    private void previewReport()
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("rpt_Sample.rdlc");
        DataSet ds = GetData_report();
        ReportDataSource datasource = new ReportDataSource("ds", ds.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(datasource);
        ReportViewer1.LocalReport.Refresh();

        ReportViewer1.Visible = true;
        //pnl_viewer.Visible = true;
    }


    protected void cmdPrintPreview_Click(object sender, EventArgs e)
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("rpt_Sample.rdlc");
        DataSet ds = GetData_report();
        ReportDataSource datasource = new ReportDataSource("ds", ds.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(datasource);
        ReportViewer1.LocalReport.Refresh();

        ReportViewer1.Visible = true;
        //pnl_viewer.Visible = true;
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



    private DataSet getSampleResult_ScrID()
    {
        CConnection cn = new CConnection();

        SqlDataAdapter da = new SqlDataAdapter("select " +
    "a.la_sno," +
    "a.history, " +
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
            " from sample_result a where a.la_sno = '" + la_sno.Text + "' and a.labid='1'", cn.cn);
        DataSet ds = new DataSet();
        da.Fill(ds);

        return ds;
    }


    private DataSet getDictionary_Cols(string formname)
    {
        CConnection cn = new CConnection();
        SqlDataAdapter da = new SqlDataAdapter("select * from tbldict where tabname = '" + formname + "' order by var_seq", cn.cn);
        DataSet ds = new DataSet();
        da.Fill(ds);

        return ds;
    }



    private void AuditTrials()
    {
        CDBOperations obj_op = null;
        DataSet ds = null;
        DataSet ds_dict = null;


        try
        {

            obj_op = new CDBOperations();

            //ds = obj_op.GetFormData_VisitID("sp_GetRecords", "5", la_sno.Text, "");
            ds = getSampleResult_ScrID();


            //ds_dict = obj_op.GetFormData_VisitID1("sp_GetRecords1", "0", "", "", "sample_result");
            ds_dict = getDictionary_Cols("sample_result");



            for (int a = 0; a <= ds_dict.Tables[0].Rows.Count - 1; a++)
            {

                for (int b = 0; b <= ds.Tables[0].Rows.Count - 1; b++)
                {

                    //if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "ID" && ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "FORM_ID" && ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "COMP_ID" && ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "EntryDate" && ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "UserID" && ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "IsPilotPhase" && ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "RR1_DIFF" && ds_dict.Tables[0].Rows[a]["var_id"].ToString() != "RR2_DIFF")

                    if (IsIncludedAudit("sample_result", ds_dict.Tables[0].Rows[a]["var_id"].ToString()))
                    {

                        //if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString() != tabControl1.TabPages[Convert.ToInt32(ds_dict.Tables[0].Rows[a]["TabPageNo"].ToString())].Controls[ds_dict.Tables[0].Rows[a]["var_id"].ToString()].Text)



                        if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_03_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_04_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_05_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_06_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_07_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_08_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_09_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_10_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_11_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_12_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_13_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_14_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_15_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_16_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_17" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LF_01_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LF_02_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LF_03_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LF_04_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LF_05_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LF_06_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LF_07_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "RF_01_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "RF_02_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "RF_03_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "RF_04_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "SE_01_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "SE_02_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "SE_03_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "SE_04_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_01_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_02_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_03_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_04_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_05_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_06_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_07_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_08_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_09_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_10_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_01_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_02_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_03_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_04_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_05_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_06_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_07_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_08_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_09_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_10_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_11_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_12_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_13_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_14_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_15_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_16_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_17_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_18_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_19_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_20_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_21_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_01_ca" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_02a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_03a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_04a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_05a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_06a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_07a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_08a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_09a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_10a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_11a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_12a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_13a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_14a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_15a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_16a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_17a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_18a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_19a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_20a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_21a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_22a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_23a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_24a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_25a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_26a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_27a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_28a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_29a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_30a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_31a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_32a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_33a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_34a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_35a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_36a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_37a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_18" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_19" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_20a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_21a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_22a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_23a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_24a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_25a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_26a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_27a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_28a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_29a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_30a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_31a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_32a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_33a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_34a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_35a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_36a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_37a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_38a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_39a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_40a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_41a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_42a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_43a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_44a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_45a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_46a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_47a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_48a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_49a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_50a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_51a_a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_52a_a"
                            )
                        {


                            TextBox txt = (TextBox)Page.FindControl(ds_dict.Tables[0].Rows[a]["var_id"].ToString());



                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString().Trim() != txt.Text.Trim())
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["la_sno"].ToString(), "", "", "sample_result", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), txt.Text, "", "");

                            }


                        }
                        else if (
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_03_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_04_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_05_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_06_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_07_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_08_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_09_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_10_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_11_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_12_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_13_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_14_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_15_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LA_16_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LF_01_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LF_02_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LF_03_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LF_04_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LF_05_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LF_06_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "LF_07_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "RF_01_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "RF_02_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "RF_03_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "RF_04_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "SE_01_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "SE_02_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "SE_03_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "SE_04_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_01_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_02_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_03_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_04_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_05_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_06_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_07_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_08_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_09_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "CS_10_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_01_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_02_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_03_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_04_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_05_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_06_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_07_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_08_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_09_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_10_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_11_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_12_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_13_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_14_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_15_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_16_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_17_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_18_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_19_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_20_b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "UR_21_b"
                            )
                        {

                            string[] arr = ds_dict.Tables[0].Rows[a]["var_id"].ToString().Split('_');
                            string rdo_id_v = arr[0] + "_" + arr[1] + "_v";
                            string rdo_id_b = arr[0] + "_" + arr[1] + "_b";
                            string rdo_id_c = arr[0] + "_" + arr[1] + "_c";

                            string rdo_val = "-1";

                            RadioButton rdo_v = (RadioButton)Page.FindControl(rdo_id_v);
                            RadioButton rdo_b = (RadioButton)Page.FindControl(rdo_id_b);
                            RadioButton rdo_c = (RadioButton)Page.FindControl(rdo_id_c);

                            if (rdo_v.Checked == true)
                            {
                                rdo_val = "";
                            }
                            else if (rdo_b.Checked == true)
                            {
                                rdo_val = "999";
                            }
                            else if (rdo_c.Checked == true)
                            {
                                rdo_val = "888";
                            }


                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString().Trim() != rdo_val)
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["la_sno"].ToString(), "", "", "sample_result", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), rdo_val, "", "");

                            }


                        }
                        else if (
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_01a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_02a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_03a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_04a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_05a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_06a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_07a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_08a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_09a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_10a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_11a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_12a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_13a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_14a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_15a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_16a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_17a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_18a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_19a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_20a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_21a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_22a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_23a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_24a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_25a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_26a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_27a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_28a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_29a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_30a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_31a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_32a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_33a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_34a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_35a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_36a" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_37a"
                            )
                        {


                            if (ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_01a")
                            {

                                string rdo_val = "-1";


                                RadioButton rdo_v = (RadioButton)Page.FindControl("uc_01_a");
                                RadioButton rdo_b = (RadioButton)Page.FindControl("uc_01_b");
                                RadioButton rdo_c = (RadioButton)Page.FindControl("uc_01_c");


                                if (rdo_v.Checked == true)
                                {
                                    rdo_val = "1";
                                }
                                else if (rdo_b.Checked == true)
                                {
                                    rdo_val = "2";
                                }
                                else if (rdo_c.Checked == true)
                                {
                                    rdo_val = "999";
                                }


                                if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString().Trim() != rdo_val)
                                {

                                    AddRecord("", ds.Tables[0].Rows[b]["la_sno"].ToString(), "", "", "sample_result", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), rdo_val, "", "");

                                }


                            }
                            else
                            {

                                string rdo_val = "-1";

                                int var_len = ds_dict.Tables[0].Rows[a]["var_id"].ToString().Length - 1;

                                string rdo_id = ds_dict.Tables[0].Rows[a]["var_id"].ToString().Substring(0, var_len);

                                RadioButton rdo_v = (RadioButton)Page.FindControl(rdo_id + "a_v");
                                RadioButton rdo_b = (RadioButton)Page.FindControl(rdo_id + "a_b");
                                RadioButton rdo_c = (RadioButton)Page.FindControl(rdo_id + "a_c");


                                if (rdo_v.Checked == true)
                                {
                                    rdo_val = "";
                                }
                                else if (rdo_b.Checked == true)
                                {
                                    rdo_val = "999";
                                }
                                else if (rdo_c.Checked == true)
                                {
                                    rdo_val = "888";
                                }


                                if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString().Trim() != rdo_val)
                                {

                                    AddRecord("", ds.Tables[0].Rows[b]["la_sno"].ToString(), "", "", "sample_result", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), rdo_val, "", "");

                                }

                            }


                        }
                        else if (
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_02b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_03b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_04b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_05b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_06b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_07b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_08b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_09b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_10b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_11b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_12b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_13b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_14b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_15b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_16b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_17b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_18b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_19b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_20b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_21b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_22b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_23b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_24b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_25b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_26b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_27b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_28b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_29b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_30b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_31b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_32b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_33b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_34b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_35b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_36b" ||
                            ds_dict.Tables[0].Rows[a]["var_id"].ToString() == "uc_37b"
                            )
                        {


                            string rdo_val = "-1";

                            int var_len = ds_dict.Tables[0].Rows[a]["var_id"].ToString().Length - 1;

                            string rdo_id = ds_dict.Tables[0].Rows[a]["var_id"].ToString().Substring(0, var_len);

                            RadioButton rdo_v = (RadioButton)Page.FindControl(rdo_id + "b_a");
                            RadioButton rdo_b = (RadioButton)Page.FindControl(rdo_id + "b_b");
                            RadioButton rdo_c = (RadioButton)Page.FindControl(rdo_id + "b_c");


                            if (rdo_v.Checked == true)
                            {
                                rdo_val = "";
                            }
                            else if (rdo_b.Checked == true)
                            {
                                rdo_val = "999";
                            }
                            else if (rdo_c.Checked == true)
                            {
                                rdo_val = "888";
                            }


                            if (ds.Tables[0].Rows[b][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString().Trim() != rdo_val)
                            {

                                AddRecord("", ds.Tables[0].Rows[b]["la_sno"].ToString(), "", "", "sample_result", "Update", ds_dict.Tables[0].Rows[a]["var_id"].ToString(), ds.Tables[0].Rows[0][ds_dict.Tables[0].Rows[a]["var_id"].ToString()].ToString(), rdo_val, "", "");

                            }


                        }



                    }  //   if (ds.Tables[0].Rows[0][a].ToString() == tabControl1.TabPages[b].Controls[c].Name)



                }     //   for (int b = 0; b <= tabControl1.TabPages[b].Controls.Count - 1; c++)


            }     //    for (int a = 0; a <= ds.Tables[0].Columns.Count - 1; a++)


        }


        catch (Exception ex)
        {
            string message = "alert('" + ex.Message.Replace("'", "") + "');";
            message = "alert('" + ex.Message.Replace("\"", "") + "');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
        }

        finally
        {
            obj_op = null;
            ds = null;
        }
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





    protected void LA_24a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_24a_v.Checked)
        {
            cntl_LA_24a_a.Visible = true;
            cntl_LA_24b.Visible = true;
        }
    }

    protected void LA_24a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_24a_v.Checked)
        {
            cntl_LA_24a_a.Visible = false;
            cntl_LA_24b.Visible = false;
            LA_24a_a.Text = "";
            LA_24b_a.Checked = false;
            LA_24b_b.Checked = false;
            LA_24b_c.Checked = false;
        }
    }

    protected void LA_24a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_24a_c.Checked)
        {
            cntl_LA_24a_a.Visible = false;
            cntl_LA_24b.Visible = false;
            LA_24a_a.Text = "";
            LA_24b_a.Checked = false;
            LA_24b_b.Checked = false;
            LA_24b_c.Checked = false;
        }
    }

    protected void LA_03_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_03_v.Checked == true)
        {
            cntl_LA_03_a.Visible = true;
        }
    }

    protected void LA_03_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_03_b.Checked == true)
        {
            cntl_LA_03_a.Visible = false;
            LA_03_a.Text = "";
        }
    }

    protected void LA_03_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_03_c.Checked == true)
        {
            cntl_LA_03_a.Visible = false;
            LA_03_a.Text = "";
        }
    }

    protected void LA_04_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_04_v.Checked == true)
        {
            cntl_LA_04_a.Visible = true;
        }
    }

    protected void LA_04_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_04_b.Checked == true)
        {
            cntl_LA_04_a.Visible = false;
            LA_04_a.Text = "";
        }
    }

    protected void LA_04_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_04_c.Checked == true)
        {
            cntl_LA_04_a.Visible = false;
            LA_04_a.Text = "";
        }
    }

    protected void LA_05_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_05_v.Checked == true)
        {
            cntl_LA_05_a.Visible = true;
        }
    }

    protected void LA_05_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_05_b.Checked == true)
        {
            cntl_LA_05_a.Visible = false;
            LA_05_a.Text = "";
        }
    }

    protected void LA_05_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_05_c.Checked == true)
        {
            cntl_LA_05_a.Visible = false;
            LA_05_a.Text = "";
        }
    }

    protected void LA_06_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_06_v.Checked == true)
        {
            cntl_LA_06_a.Visible = true;
        }
    }

    protected void LA_06_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_06_b.Checked == true)
        {
            cntl_LA_06_a.Visible = false;
            LA_06_a.Text = "";
        }
    }

    protected void LA_06_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_06_c.Checked == true)
        {
            cntl_LA_06_a.Visible = false;
            LA_06_a.Text = "";
        }
    }

    protected void LA_07_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_07_v.Checked == true)
        {
            cntl_LA_07_a.Visible = true;
        }
    }

    protected void LA_07_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_07_b.Checked == true)
        {
            cntl_LA_07_a.Visible = false;
            LA_07_a.Text = "";
        }
    }

    protected void LA_07_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_07_c.Checked == true)
        {
            cntl_LA_07_a.Visible = false;
            LA_07_a.Text = "";
        }
    }

    protected void LA_08_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_08_v.Checked == true)
        {
            cntl_LA_08_a.Visible = true;
        }
    }

    protected void LA_08_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_08_b.Checked == true)
        {
            cntl_LA_08_a.Visible = false;
            LA_08_a.Text = "";
        }
    }

    protected void LA_08_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_08_c.Checked == true)
        {
            cntl_LA_08_a.Visible = false;
            LA_08_a.Text = "";
        }
    }

    protected void LA_09_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_09_v.Checked == true)
        {
            cntl_LA_09_a.Visible = true;
        }
    }

    protected void LA_09_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_09_b.Checked == true)
        {
            cntl_LA_09_a.Visible = false;
            LA_09_a.Text = "";
        }
    }

    protected void LA_09_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_09_c.Checked == true)
        {
            cntl_LA_09_a.Visible = false;
            LA_09_a.Text = "";
        }
    }

    protected void LA_10_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_10_v.Checked == true)
        {
            cntl_LA_10_a.Visible = true;
        }
    }

    protected void LA_10_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_10_b.Checked == true)
        {
            cntl_LA_10_a.Visible = false;
            LA_10_a.Text = "";
        }
    }

    protected void LA_10_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_10_c.Checked == true)
        {
            cntl_LA_10_a.Visible = false;
            LA_10_a.Text = "";
        }
    }

    protected void LA_11_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_11_v.Checked == true)
        {
            cntl_LA_11_a.Visible = true;
        }
    }

    protected void LA_11_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_11_b.Checked == true)
        {
            cntl_LA_11_a.Visible = false;
            LA_11_a.Text = "";
        }
    }

    protected void LA_11_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_11_c.Checked == true)
        {
            cntl_LA_11_a.Visible = false;
            LA_11_a.Text = "";
        }
    }

    protected void LA_12_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_12_v.Checked == true)
        {
            cntl_LA_12_a.Visible = true;
        }
    }

    protected void LA_12_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_12_b.Checked == true)
        {
            cntl_LA_12_a.Visible = false;
            LA_12_a.Text = "";
        }
    }

    protected void LA_12_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_12_c.Checked == true)
        {
            cntl_LA_12_a.Visible = false;
            LA_12_a.Text = "";
        }
    }

    protected void LA_13_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_13_v.Checked == true)
        {
            cntl_LA_13_a.Visible = true;
        }
    }

    protected void LA_13_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_13_b.Checked == true)
        {
            cntl_LA_13_a.Visible = false;
            LA_13_a.Text = "";
        }
    }

    protected void LA_13_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_13_c.Checked == true)
        {
            cntl_LA_13_a.Visible = false;
            LA_13_a.Text = "";
        }
    }

    protected void LA_14_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_14_v.Checked == true)
        {
            cntl_LA_14_a.Visible = true;
        }
    }

    protected void LA_14_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_14_b.Checked == true)
        {
            cntl_LA_14_a.Visible = false;
            LA_14_a.Text = "";
        }
    }

    protected void LA_14_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_14_c.Checked == true)
        {
            cntl_LA_14_a.Visible = false;
            LA_14_a.Text = "";
        }
    }

    protected void LA_15_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_15_v.Checked == true)
        {
            cntl_LA_15_a.Visible = true;
        }
    }

    protected void LA_15_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_15_b.Checked == true)
        {
            cntl_LA_15_a.Visible = false;
            LA_15_a.Text = "";
        }
    }

    protected void LA_15_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_15_c.Checked == true)
        {
            cntl_LA_15_a.Visible = false;
            LA_15_a.Text = "";
        }
    }

    protected void LA_16_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_16_v.Checked == true)
        {
            cntl_LA_16_a.Visible = true;
        }
    }

    protected void LA_16_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_16_b.Checked == true)
        {
            cntl_LA_16_a.Visible = false;
            LA_16_a.Text = "";
        }
    }

    protected void LA_16_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_16_c.Checked == true)
        {
            cntl_LA_16_a.Visible = false;
            LA_16_a.Text = "";
        }
    }

    protected void LF_01_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_01_v.Checked == true)
        {
            cntl_LF_01_a.Visible = true;
        }
    }

    protected void LF_01_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_01_b.Checked == true)
        {
            cntl_LF_01_a.Visible = false;
            LF_01_a.Text = "";
        }
    }

    protected void LF_01_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_01_c.Checked == true)
        {
            cntl_LF_01_a.Visible = false;
            LF_01_a.Text = "";
        }
    }

    protected void LF_02_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_02_v.Checked == true)
        {
            cntl_LF_02_a.Visible = true;
        }
    }

    protected void LF_02_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_02_b.Checked == true)
        {
            cntl_LF_02_a.Visible = false;
            LF_02_a.Text = "";
        }
    }

    protected void LF_02_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_02_c.Checked == true)
        {
            cntl_LF_02_a.Visible = false;
            LF_02_a.Text = "";
        }
    }

    protected void LF_03_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_03_v.Checked == true)
        {
            cntl_LF_03_a.Visible = true;
        }
    }

    protected void LF_03_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_03_b.Checked == true)
        {
            cntl_LF_03_a.Visible = false;
            LF_03_a.Text = "";
        }
    }

    protected void LF_03_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_03_c.Checked == true)
        {
            cntl_LF_03_a.Visible = false;
            LF_03_a.Text = "";
        }
    }

    protected void LF_04_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_04_v.Checked == true)
        {
            cntl_LF_04_a.Visible = true;
        }
    }

    protected void LF_04_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_04_b.Checked == true)
        {
            cntl_LF_04_a.Visible = false;
            LF_04_a.Text = "";
        }
    }

    protected void LF_04_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_04_c.Checked == true)
        {
            cntl_LF_04_a.Visible = false;
            LF_04_a.Text = "";
        }
    }

    protected void LF_05_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_05_v.Checked == true)
        {
            cntl_LF_05_a.Visible = true;
        }
    }

    protected void LF_05_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_05_b.Checked == true)
        {
            cntl_LF_05_a.Visible = false;
            LF_05_a.Text = "";
        }
    }

    protected void LF_05_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_05_c.Checked == true)
        {
            cntl_LF_05_a.Visible = false;
            LF_05_a.Text = "";
        }
    }

    protected void LF_06_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_06_v.Checked == true)
        {
            cntl_LF_06_a.Visible = true;
        }
    }

    protected void LF_06_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_06_b.Checked == true)
        {
            cntl_LF_06_a.Visible = false;
            LF_06_a.Text = "";
        }
    }

    protected void LF_06_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_06_c.Checked == true)
        {
            cntl_LF_06_a.Visible = false;
            LF_06_a.Text = "";
        }
    }

    protected void LF_07_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_07_v.Checked == true)
        {
            cntl_LF_07_a.Visible = true;
        }
    }

    protected void LF_07_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_07_b.Checked == true)
        {
            cntl_LF_07_a.Visible = false;
            LF_07_a.Text = "";
        }
    }

    protected void LF_07_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LF_07_c.Checked == true)
        {
            cntl_LF_07_a.Visible = false;
            LF_07_a.Text = "";
        }
    }

    protected void RF_01_v_CheckedChanged(object sender, EventArgs e)
    {
        if (RF_01_v.Checked)
        {
            cntl_RF_01_a.Visible = true;
        }
    }

    protected void RF_01_b_CheckedChanged(object sender, EventArgs e)
    {
        if (RF_01_b.Checked)
        {
            cntl_RF_01_a.Visible = false;
            RF_01_a.Text = "";
        }
    }

    protected void RF_01_c_CheckedChanged(object sender, EventArgs e)
    {
        if (RF_01_c.Checked)
        {
            cntl_RF_01_a.Visible = false;
            RF_01_a.Text = "";
        }
    }

    protected void RF_02_v_CheckedChanged(object sender, EventArgs e)
    {
        if (RF_02_v.Checked)
        {
            cntl_RF_02_a.Visible = true;
        }
    }

    protected void RF_02_b_CheckedChanged(object sender, EventArgs e)
    {
        if (RF_02_b.Checked)
        {
            cntl_RF_02_a.Visible = false;
            RF_02_a.Text = "";
        }
    }

    protected void RF_02_c_CheckedChanged(object sender, EventArgs e)
    {
        if (RF_02_c.Checked)
        {
            cntl_RF_02_a.Visible = false;
            RF_02_a.Text = "";
        }
    }

    protected void RF_03_v_CheckedChanged(object sender, EventArgs e)
    {
        if (RF_03_v.Checked)
        {
            cntl_RF_03_a.Visible = true;
        }
    }

    protected void RF_03_b_CheckedChanged(object sender, EventArgs e)
    {
        if (RF_03_b.Checked)
        {
            cntl_RF_03_a.Visible = false;
            RF_03_a.Text = "";
        }
    }

    protected void RF_03_c_CheckedChanged(object sender, EventArgs e)
    {
        if (RF_03_c.Checked)
        {
            cntl_RF_03_a.Visible = false;
            RF_03_a.Text = "";
        }
    }

    protected void RF_04_v_CheckedChanged(object sender, EventArgs e)
    {
        if (RF_04_v.Checked)
        {
            cntl_RF_04_a.Visible = true;
        }
    }

    protected void RF_04_b_CheckedChanged(object sender, EventArgs e)
    {
        if (RF_04_b.Checked)
        {
            cntl_RF_04_a.Visible = false;
            RF_04_a.Text = "";
        }
    }

    protected void RF_04_c_CheckedChanged(object sender, EventArgs e)
    {
        if (RF_04_c.Checked)
        {
            cntl_RF_04_a.Visible = false;
            RF_04_a.Text = "";
        }
    }

    protected void SE_01_v_CheckedChanged(object sender, EventArgs e)
    {
        if (SE_01_v.Checked)
        {
            cntl_SE_01_a.Visible = true;
        }
    }

    protected void SE_01_b_CheckedChanged(object sender, EventArgs e)
    {
        if (SE_01_b.Checked)
        {
            cntl_SE_01_a.Visible = false;
            SE_01_a.Text = "";
        }
    }

    protected void SE_01_c_CheckedChanged(object sender, EventArgs e)
    {
        if (SE_01_c.Checked)
        {
            cntl_SE_01_a.Visible = false;
            SE_01_a.Text = "";
        }
    }

    protected void SE_02_v_CheckedChanged(object sender, EventArgs e)
    {
        if (SE_02_v.Checked)
        {
            cntl_SE_02_a.Visible = true;
        }
    }

    protected void SE_02_b_CheckedChanged(object sender, EventArgs e)
    {
        if (SE_02_b.Checked)
        {
            cntl_SE_02_a.Visible = false;
            SE_02_a.Text = "";
        }
    }

    protected void SE_02_c_CheckedChanged(object sender, EventArgs e)
    {
        if (SE_02_c.Checked)
        {
            cntl_SE_02_a.Visible = false;
            SE_02_a.Text = "";
        }
    }

    protected void SE_03_v_CheckedChanged(object sender, EventArgs e)
    {
        if (SE_03_v.Checked)
        {
            cntl_SE_03_a.Visible = true;
        }
    }

    protected void SE_03_b_CheckedChanged(object sender, EventArgs e)
    {
        if (SE_03_b.Checked)
        {
            cntl_SE_03_a.Visible = false;
            SE_03_a.Text = "";
        }
    }

    protected void SE_03_c_CheckedChanged(object sender, EventArgs e)
    {
        if (SE_03_c.Checked)
        {
            cntl_SE_03_a.Visible = false;
            SE_03_a.Text = "";
        }
    }

    protected void SE_04_v_CheckedChanged(object sender, EventArgs e)
    {
        if (SE_04_v.Checked)
        {
            cntl_SE_04_a.Visible = true;
        }
    }

    protected void SE_04_b_CheckedChanged(object sender, EventArgs e)
    {
        if (SE_04_b.Checked)
        {
            cntl_SE_04_a.Visible = false;
            SE_04_a.Text = "";
        }
    }

    protected void SE_04_c_CheckedChanged(object sender, EventArgs e)
    {
        if (SE_04_c.Checked)
        {
            cntl_SE_04_a.Visible = false;
            SE_04_a.Text = "";
        }
    }

    protected void CS_01_v_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_01_v.Checked)
        {
            cntl_CS_01_a.Visible = true;
        }
    }

    protected void CS_01_b_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_01_b.Checked)
        {
            cntl_CS_01_a.Visible = false;
            CS_01_a.Text = "";
        }
    }

    protected void CS_01_c_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_01_c.Checked)
        {
            cntl_CS_01_a.Visible = false;
            CS_01_a.Text = "";
        }
    }

    protected void CS_02_v_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_02_v.Checked)
        {
            cntl_CS_02_a.Visible = true;
        }
    }

    protected void CS_02_b_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_02_b.Checked)
        {
            cntl_CS_02_a.Visible = false;
            CS_02_a.Text = "";
        }
    }

    protected void CS_02_c_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_02_c.Checked)
        {
            cntl_CS_02_a.Visible = false;
            CS_02_a.Text = "";
        }
    }

    protected void CS_03_v_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_03_v.Checked)
        {
            cntl_CS_03_a.Visible = true;
        }
    }

    protected void CS_03_b_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_03_b.Checked)
        {
            cntl_CS_03_a.Visible = false;
            CS_03_a.Text = "";
        }
    }

    protected void CS_03_c_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_03_c.Checked)
        {
            cntl_CS_03_a.Visible = false;
            CS_03_a.Text = "";
        }
    }

    protected void CS_04_v_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_04_v.Checked)
        {
            cntl_CS_04_a.Visible = true;
        }
    }

    protected void CS_04_b_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_04_b.Checked)
        {
            cntl_CS_04_a.Visible = false;
            CS_04_a.Text = "";
        }
    }

    protected void CS_04_c_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_04_c.Checked)
        {
            cntl_CS_04_a.Visible = false;
            CS_04_a.Text = "";
        }
    }

    protected void CS_05_v_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_05_v.Checked)
        {
            cntl_CS_05_a.Visible = true;
        }
    }

    protected void CS_05_b_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_05_b.Checked)
        {
            cntl_CS_05_a.Visible = false;
            CS_05_a.Text = "";
        }
    }

    protected void CS_05_c_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_05_c.Checked)
        {
            cntl_CS_05_a.Visible = false;
            CS_05_a.Text = "";
        }
    }

    protected void CS_06_v_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_06_v.Checked)
        {
            cntl_CS_06_a.Visible = true;
        }
    }

    protected void CS_06_b_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_06_b.Checked)
        {
            cntl_CS_06_a.Visible = false;
            CS_06_a.Text = "";
        }
    }

    protected void CS_06_c_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_06_c.Checked)
        {
            cntl_CS_06_a.Visible = false;
            CS_06_a.Text = "";
        }
    }

    protected void CS_07_v_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_07_v.Checked)
        {
            cntl_CS_07_a.Visible = true;
        }
    }

    protected void CS_07_b_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_07_b.Checked)
        {
            cntl_CS_07_a.Visible = false;
            CS_07_a.Text = "";
        }
    }

    protected void CS_07_c_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_07_c.Checked)
        {
            cntl_CS_07_a.Visible = false;
            CS_07_a.Text = "";
        }
    }

    protected void CS_08_v_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_08_v.Checked)
        {
            cntl_CS_08_a.Visible = true;
        }
    }

    protected void CS_08_b_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_08_b.Checked)
        {
            cntl_CS_08_a.Visible = false;
            CS_08_a.Text = "";
        }
    }

    protected void CS_08_c_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_08_c.Checked)
        {
            cntl_CS_08_a.Visible = false;
            CS_08_a.Text = "";
        }
    }

    protected void CS_09_v_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_09_v.Checked)
        {
            cntl_CS_09_a.Visible = true;
        }
    }

    protected void CS_09_b_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_09_b.Checked)
        {
            cntl_CS_09_a.Visible = false;
            CS_09_a.Text = "";
        }
    }

    protected void CS_09_c_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_09_c.Checked)
        {
            cntl_CS_09_a.Visible = false;
            CS_09_a.Text = "";
        }
    }

    protected void CS_10_v_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_10_v.Checked)
        {
            cntl_CS_10_a.Visible = true;
        }
    }

    protected void CS_10_b_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_10_b.Checked)
        {
            cntl_CS_10_a.Visible = false;
            CS_10_a.Text = "";
        }
    }

    protected void CS_10_c_CheckedChanged(object sender, EventArgs e)
    {
        if (CS_10_c.Checked)
        {
            cntl_CS_10_a.Visible = false;
            CS_10_a.Text = "";
        }
    }

    protected void UR_01_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_01_v.Checked)
        {
            cntl_UR_01_a.Visible = true;
        }
    }

    protected void UR_01_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_01_b.Checked)
        {
            cntl_UR_01_a.Visible = false;
            UR_01_a.Text = "";
        }
    }

    protected void UR_01_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_01_c.Checked)
        {
            cntl_UR_01_a.Visible = false;
            UR_01_a.Text = "";
        }
    }

    protected void UR_02_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_02_v.Checked)
        {
            cntl_UR_02_a.Visible = true;
        }
    }

    protected void UR_02_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_02_b.Checked)
        {
            cntl_UR_02_a.Visible = false;
            UR_02_a.Text = "";
        }
    }

    protected void UR_02_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_02_c.Checked)
        {
            cntl_UR_02_a.Visible = false;
            UR_02_a.Text = "";
        }
    }

    protected void UR_03_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_03_v.Checked)
        {
            cntl_UR_03_a.Visible = true;
        }
    }

    protected void UR_03_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_03_b.Checked)
        {
            cntl_UR_03_a.Visible = false;
            UR_03_a.Text = "";
        }
    }

    protected void UR_03_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_03_c.Checked)
        {
            cntl_UR_03_a.Visible = false;
            UR_03_a.Text = "";
        }
    }

    protected void UR_04_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_04_v.Checked)
        {
            cntl_UR_04_a.Visible = true;
        }
    }

    protected void UR_04_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_04_b.Checked)
        {
            cntl_UR_04_a.Visible = false;
            UR_04_a.Text = "";
        }
    }

    protected void UR_04_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_04_c.Checked)
        {
            cntl_UR_04_a.Visible = false;
            UR_04_a.Text = "";
        }
    }

    protected void UR_04a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_04a_v.Checked)
        {
            cntl_UR_04a_a.Visible = true;
        }
    }

    protected void UR_04a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_04a_b.Checked)
        {
            cntl_UR_04a_a.Visible = false;
            UR_04a_a.Text = "";
        }
    }

    protected void UR_04a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_04a_c.Checked)
        {
            cntl_UR_04a_a.Visible = false;
            UR_04a_a.Text = "";
        }
    }

    protected void UR_05_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_05_v.Checked)
        {
            cntl_UR_05_a.Visible = true;
        }
    }

    protected void UR_05_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_05_b.Checked)
        {
            cntl_UR_05_a.Visible = false;
            UR_05_a.Text = "";
        }
    }

    protected void UR_05_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_05_c.Checked)
        {
            cntl_UR_05_a.Visible = false;
            UR_05_a.Text = "";
        }
    }

    protected void UR_06_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_06_v.Checked)
        {
            cntl_UR_06_a.Visible = true;
        }
    }

    protected void UR_06_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_06_b.Checked)
        {
            cntl_UR_06_a.Visible = false;
            UR_06_a.Text = "";
        }
    }

    protected void UR_06_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_06_c.Checked)
        {
            cntl_UR_06_a.Visible = false;
            UR_06_a.Text = "";
        }
    }

    protected void UR_07_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_07_v.Checked)
        {
            cntl_UR_07_a.Visible = true;
        }
    }

    protected void UR_07_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_07_b.Checked)
        {
            cntl_UR_07_a.Visible = false;
            UR_07_a.Text = "";
        }
    }

    protected void UR_07_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_07_c.Checked)
        {
            cntl_UR_07_a.Visible = false;
            UR_07_a.Text = "";
        }
    }

    protected void UR_08_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_08_v.Checked)
        {
            cntl_UR_08_a.Visible = true;
        }
    }

    protected void UR_08_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_08_b.Checked)
        {
            cntl_UR_08_a.Visible = false;
            UR_08_a.Text = "";
        }
    }

    protected void UR_08_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_08_c.Checked)
        {
            cntl_UR_08_a.Visible = false;
            UR_08_a.Text = "";
        }
    }

    protected void UR_10_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_10_v.Checked)
        {
            cntl_UR_10_a.Visible = true;
        }
    }

    protected void UR_10_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_10_b.Checked)
        {
            cntl_UR_10_a.Visible = false;
            UR_10_a.Text = "";
        }
    }

    protected void UR_10_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_10_c.Checked)
        {
            cntl_UR_10_a.Visible = false;
            UR_10_a.Text = "";
        }
    }

    protected void UR_11_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_11_v.Checked)
        {
            cntl_UR_11_a.Visible = true;
        }
    }

    protected void UR_11_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_11_b.Checked)
        {
            cntl_UR_11_a.Visible = false;
            UR_11_a.Text = "";
        }
    }

    protected void UR_11_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_11_c.Checked)
        {
            cntl_UR_11_a.Visible = false;
            UR_11_a.Text = "";
        }
    }

    protected void UR_12_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_12_v.Checked)
        {
            cntl_UR_12_a.Visible = true;
        }
    }

    protected void UR_12_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_12_b.Checked)
        {
            cntl_UR_12_a.Visible = false;
            UR_12_a.Text = "";
        }
    }

    protected void UR_12_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_12_c.Checked)
        {
            cntl_UR_12_a.Visible = false;
            UR_12_a.Text = "";
        }
    }

    protected void UR_13_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_13_v.Checked)
        {
            cntl_UR_13_a.Visible = true;
        }
    }

    protected void UR_13_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_13_b.Checked)
        {
            cntl_UR_13_a.Visible = false;
            UR_13_a.Text = "";
        }
    }

    protected void UR_13_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_13_c.Checked)
        {
            cntl_UR_13_a.Visible = false;
            UR_13_a.Text = "";
        }
    }

    protected void UR_14_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_14_v.Checked)
        {
            cntl_UR_14_a.Visible = true;
        }
    }

    protected void UR_14_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_14_b.Checked)
        {
            cntl_UR_14_a.Visible = false;
            UR_14_a.Text = "";
        }
    }

    protected void UR_14_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_14_c.Checked)
        {
            cntl_UR_14_a.Visible = false;
            UR_14_a.Text = "";
        }
    }

    protected void UR_15_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_15_v.Checked)
        {
            cntl_UR_15_a.Visible = true;
        }
    }

    protected void UR_15_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_15_b.Checked)
        {
            cntl_UR_15_a.Visible = false;
            UR_15_a.Text = "";
        }
    }

    protected void UR_15_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_15_c.Checked)
        {
            cntl_UR_15_a.Visible = false;
            UR_15_a.Text = "";
        }
    }

    protected void UR_16_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_16_v.Checked)
        {
            cntl_UR_16_a.Visible = true;
        }
    }

    protected void UR_16_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_16_b.Checked)
        {
            cntl_UR_16_a.Visible = false;
            UR_16_a.Text = "";
        }
    }

    protected void UR_16_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_16_c.Checked)
        {
            cntl_UR_16_a.Visible = false;
            UR_16_a.Text = "";
        }
    }

    protected void UR_17_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_17_v.Checked)
        {
            cntl_UR_17_a.Visible = true;
        }
    }

    protected void UR_17_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_17_b.Checked)
        {
            cntl_UR_17_a.Visible = false;
            UR_17_a.Text = "";
        }
    }

    protected void UR_17_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_17_c.Checked)
        {
            cntl_UR_17_a.Visible = false;
            UR_17_a.Text = "";
        }
    }

    protected void UR_18_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_18_v.Checked)
        {
            cntl_UR_18_a.Visible = true;
        }
    }

    protected void UR_18_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_18_b.Checked)
        {
            cntl_UR_18_a.Visible = false;
            UR_18_a.Text = "";
        }
    }

    protected void UR_18_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_18_c.Checked)
        {
            cntl_UR_18_a.Visible = false;
            UR_18_a.Text = "";
        }
    }

    protected void UR_19_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_19_v.Checked)
        {
            cntl_UR_19_a.Visible = true;
        }
    }

    protected void UR_19_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_19_b.Checked)
        {
            cntl_UR_19_a.Visible = false;
            UR_19_a.Text = "";
        }
    }

    protected void UR_19_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_19_c.Checked)
        {
            cntl_UR_19_a.Visible = false;
            UR_19_a.Text = "";
        }
    }

    protected void UR_20_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_20_v.Checked)
        {
            cntl_UR_20_a.Visible = true;
        }
    }

    protected void UR_20_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_20_b.Checked)
        {
            cntl_UR_20_a.Visible = false;
            UR_20_a.Text = "";
        }
    }

    protected void UR_20_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_20_c.Checked)
        {
            cntl_UR_20_a.Visible = false;
            UR_20_a.Text = "";
        }
    }

    protected void UR_21_v_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_21_v.Checked)
        {
            cntl_UR_21_a.Visible = true;
        }
    }

    protected void UR_21_b_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_21_b.Checked)
        {
            cntl_UR_21_a.Visible = false;
            UR_21_a.Text = "";
        }
    }

    protected void UR_21_c_CheckedChanged(object sender, EventArgs e)
    {
        if (UR_21_c.Checked)
        {
            cntl_UR_21_a.Visible = false;
            UR_21_a.Text = "";
        }
    }

    protected void uc_01_a_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_01_a.Checked)
        {
            cntl_uc_01_ca.Visible = true;
        }
    }

    protected void uc_01_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_01_b.Checked)
        {
            cntl_uc_01_ca.Visible = false;
            uc_01_ca.Text = "";
        }
    }

    protected void uc_01_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_01_c.Checked)
        {
            cntl_uc_01_ca.Visible = false;
            uc_01_ca.Text = "";
        }
    }

    protected void uc_02a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_02a_v.Checked)
        {
            cntl_uc_02a_a.Visible = true;
            cntl_uc_02b.Visible = true;
        }
    }

    protected void uc_02a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_02a_b.Checked)
        {
            cntl_uc_02a_a.Visible = false;
            cntl_uc_02b.Visible = false;

            uc_02a_a.Text = "";
            uc_02b_a.Checked = false;
            uc_02b_b.Checked = false;
            uc_02b_c.Checked = false;
        }
    }

    protected void uc_02a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_02a_c.Checked)
        {
            cntl_uc_02a_a.Visible = false;
            cntl_uc_02b.Visible = false;

            uc_02a_a.Text = "";
            uc_02b_a.Checked = false;
            uc_02b_b.Checked = false;
            uc_02b_c.Checked = false;
        }
    }


    protected void uc_03a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_03a_v.Checked)
        {
            cntl_uc_03a_a.Visible = true;
            cntl_uc_03b.Visible = true;
        }
    }

    protected void uc_03a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_03a_b.Checked)
        {
            cntl_uc_03a_a.Visible = false;
            cntl_uc_03b.Visible = false;

            uc_03a_a.Text = "";
            uc_03b_a.Checked = false;
            uc_03b_b.Checked = false;
            uc_03b_c.Checked = false;
        }
    }

    protected void uc_03a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_03a_c.Checked)
        {
            cntl_uc_03a_a.Visible = false;
            cntl_uc_03b.Visible = false;

            uc_03a_a.Text = "";
            uc_03b_a.Checked = false;
            uc_03b_b.Checked = false;
            uc_03b_c.Checked = false;
        }
    }



    protected void uc_04a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_04a_v.Checked)
        {
            cntl_uc_04a_a.Visible = true;
            cntl_uc_04b.Visible = true;
        }
    }

    protected void uc_04a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_04a_b.Checked)
        {
            cntl_uc_04a_a.Visible = false;
            cntl_uc_04b.Visible = false;

            uc_04a_a.Text = "";
            uc_04b_a.Checked = false;
            uc_04b_b.Checked = false;
            uc_04b_c.Checked = false;
        }
    }

    protected void uc_04a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_04a_c.Checked)
        {
            cntl_uc_04a_a.Visible = false;
            cntl_uc_04b.Visible = false;

            uc_04a_a.Text = "";
            uc_04b_a.Checked = false;
            uc_04b_b.Checked = false;
            uc_04b_c.Checked = false;
        }
    }

    protected void uc_04b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_04b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_04b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_05a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_05a_v.Checked)
        {
            cntl_uc_05a_a.Visible = true;
            cntl_uc_05b.Visible = true;
        }
    }

    protected void uc_05a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_05a_b.Checked)
        {
            cntl_uc_05a_a.Visible = false;
            cntl_uc_05b.Visible = false;

            uc_05a_a.Text = "";
            uc_05b_a.Checked = false;
            uc_05b_b.Checked = false;
            uc_05b_c.Checked = false;
        }
    }

    protected void uc_05a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_05a_c.Checked)
        {
            cntl_uc_05a_a.Visible = false;
            cntl_uc_05b.Visible = false;

            uc_05a_a.Text = "";
            uc_05b_a.Checked = false;
            uc_05b_b.Checked = false;
            uc_05b_c.Checked = false;
        }
    }

    protected void uc_05b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_05b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_05b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_06a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_06a_v.Checked)
        {
            cntl_uc_06a_a.Visible = true;
            cntl_uc_06b.Visible = true;
        }
    }

    protected void uc_06a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_06a_b.Checked)
        {
            cntl_uc_06a_a.Visible = false;
            cntl_uc_06b.Visible = false;

            uc_06a_a.Text = "";
            uc_06b_a.Checked = false;
            uc_06b_b.Checked = false;
            uc_06b_c.Checked = false;
        }
    }

    protected void uc_06a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_06a_c.Checked)
        {
            cntl_uc_06a_a.Visible = false;
            cntl_uc_06b.Visible = false;

            uc_06a_a.Text = "";
            uc_06b_a.Checked = false;
            uc_06b_b.Checked = false;
            uc_06b_c.Checked = false;
        }
    }

    protected void uc_06b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_06b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_06b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_07a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_07a_v.Checked)
        {
            cntl_uc_07a_a.Visible = true;
            cntl_uc_07b.Visible = true;
        }
    }

    protected void uc_07a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_07a_b.Checked)
        {
            cntl_uc_07a_a.Visible = false;
            cntl_uc_07b.Visible = false;

            uc_07a_a.Text = "";
            uc_07b_a.Checked = false;
            uc_07b_b.Checked = false;
            uc_07b_c.Checked = false;
        }
    }

    protected void uc_07a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_07a_c.Checked)
        {
            cntl_uc_07a_a.Visible = false;
            cntl_uc_07b.Visible = false;

            uc_07a_a.Text = "";
            uc_07b_a.Checked = false;
            uc_07b_b.Checked = false;
            uc_07b_c.Checked = false;
        }
    }

    protected void uc_07b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_07b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_07b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_08a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_08a_v.Checked)
        {
            cntl_uc_08a_a.Visible = true;
            cntl_uc_08b.Visible = true;
        }
    }

    protected void uc_08a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_08a_b.Checked)
        {
            cntl_uc_08a_a.Visible = false;
            cntl_uc_08b.Visible = false;

            uc_08a_a.Text = "";
            uc_08b_a.Checked = false;
            uc_08b_b.Checked = false;
            uc_08b_c.Checked = false;
        }
    }

    protected void uc_08a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_08a_c.Checked)
        {
            cntl_uc_08a_a.Visible = false;
            cntl_uc_08b.Visible = false;

            uc_08a_a.Text = "";
            uc_08b_a.Checked = false;
            uc_08b_b.Checked = false;
            uc_08b_c.Checked = false;
        }
    }

    protected void uc_08b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_08b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_08b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_09a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_09a_v.Checked)
        {
            cntl_uc_09a_a.Visible = true;
            cntl_uc_09b.Visible = true;
        }
    }

    protected void uc_09a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_09a_b.Checked)
        {
            cntl_uc_09a_a.Visible = false;
            cntl_uc_09b.Visible = false;

            uc_09a_a.Text = "";
            uc_09b_a.Checked = false;
            uc_09b_b.Checked = false;
            uc_09b_c.Checked = false;
        }
    }

    protected void uc_09a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_09a_c.Checked)
        {
            cntl_uc_09a_a.Visible = false;
            cntl_uc_09b.Visible = false;

            uc_09a_a.Text = "";
            uc_09b_a.Checked = false;
            uc_09b_b.Checked = false;
            uc_09b_c.Checked = false;
        }
    }

    protected void uc_09b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_09b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_09b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_10a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_10a_v.Checked)
        {
            cntl_uc_10a_a.Visible = true;
            cntl_uc_10b.Visible = true;
        }
    }

    protected void uc_10a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_10a_b.Checked)
        {
            cntl_uc_10a_a.Visible = false;
            cntl_uc_10b.Visible = false;

            uc_10a_a.Text = "";
            uc_10b_a.Checked = false;
            uc_10b_b.Checked = false;
            uc_10b_c.Checked = false;
        }
    }

    protected void uc_10a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_10a_c.Checked)
        {
            cntl_uc_10a_a.Visible = false;
            cntl_uc_10b.Visible = false;

            uc_10a_a.Text = "";
            uc_10b_a.Checked = false;
            uc_10b_b.Checked = false;
            uc_10b_c.Checked = false;
        }
    }

    protected void uc_10b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_10b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_10b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_11a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_11a_v.Checked)
        {
            cntl_uc_11a_a.Visible = true;
            cntl_uc_11b.Visible = true;
        }
    }

    protected void uc_11a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_11a_b.Checked)
        {
            cntl_uc_11a_a.Visible = false;
            cntl_uc_11b.Visible = false;

            uc_11a_a.Text = "";
            uc_11b_a.Checked = false;
            uc_11b_b.Checked = false;
            uc_11b_c.Checked = false;
        }
    }

    protected void uc_11a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_11a_c.Checked)
        {
            cntl_uc_11a_a.Visible = false;
            cntl_uc_11b.Visible = false;

            uc_11a_a.Text = "";
            uc_11b_a.Checked = false;
            uc_11b_b.Checked = false;
            uc_11b_c.Checked = false;
        }
    }

    protected void uc_11b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_11b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_11b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_12a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_12a_v.Checked)
        {
            cntl_uc_12a_a.Visible = true;
            cntl_uc_12b.Visible = true;
        }
    }

    protected void uc_12a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_12a_b.Checked)
        {
            cntl_uc_12a_a.Visible = false;
            cntl_uc_12b.Visible = false;

            uc_12a_a.Text = "";
            uc_12b_a.Checked = false;
            uc_12b_b.Checked = false;
            uc_12b_c.Checked = false;
        }
    }

    protected void uc_12a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_12a_c.Checked)
        {
            cntl_uc_12a_a.Visible = false;
            cntl_uc_12b.Visible = false;

            uc_12a_a.Text = "";
            uc_12b_a.Checked = false;
            uc_12b_b.Checked = false;
            uc_12b_c.Checked = false;
        }
    }

    protected void uc_12b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_12b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_12b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_13a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_13a_v.Checked)
        {
            cntl_uc_13a_a.Visible = true;
            cntl_uc_13b.Visible = true;
        }
    }

    protected void uc_13a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_13a_b.Checked)
        {
            cntl_uc_13a_a.Visible = false;
            cntl_uc_13b.Visible = false;

            uc_13a_a.Text = "";
            uc_13b_a.Checked = false;
            uc_13b_b.Checked = false;
            uc_13b_c.Checked = false;
        }
    }

    protected void uc_13a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_13a_c.Checked)
        {
            cntl_uc_13a_a.Visible = false;
            cntl_uc_13b.Visible = false;

            uc_13a_a.Text = "";
            uc_13b_a.Checked = false;
            uc_13b_b.Checked = false;
            uc_13b_c.Checked = false;
        }
    }

    protected void uc_13b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_13b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_13b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_14a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_14a_v.Checked)
        {
            cntl_uc_14a_a.Visible = true;
            cntl_uc_14b.Visible = true;
        }
    }

    protected void uc_14a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_14a_b.Checked)
        {
            cntl_uc_14a_a.Visible = false;
            cntl_uc_14b.Visible = false;

            uc_14a_a.Text = "";
            uc_14b_a.Checked = false;
            uc_14b_b.Checked = false;
            uc_14b_c.Checked = false;
        }
    }

    protected void uc_14a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_14a_c.Checked)
        {
            cntl_uc_14a_a.Visible = false;
            cntl_uc_14b.Visible = false;

            uc_14a_a.Text = "";
            uc_14b_a.Checked = false;
            uc_14b_b.Checked = false;
            uc_14b_c.Checked = false;
        }
    }

    protected void uc_14b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_14b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_14b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_15a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_15a_v.Checked)
        {
            cntl_uc_15a_a.Visible = true;
            cntl_uc_15b.Visible = true;
        }
    }

    protected void uc_15a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_15a_b.Checked)
        {
            cntl_uc_15a_a.Visible = false;
            cntl_uc_15b.Visible = false;

            uc_15a_a.Text = "";
            uc_15b_a.Checked = false;
            uc_15b_b.Checked = false;
            uc_15b_c.Checked = false;
        }
    }

    protected void uc_15a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_15a_c.Checked)
        {
            cntl_uc_15a_a.Visible = false;
            cntl_uc_15b.Visible = false;

            uc_15a_a.Text = "";
            uc_15b_a.Checked = false;
            uc_15b_b.Checked = false;
            uc_15b_c.Checked = false;
        }
    }

    protected void uc_15b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_15b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_15b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_16a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_16a_v.Checked)
        {
            cntl_uc_16a_a.Visible = true;
            cntl_uc_16b.Visible = true;
        }
    }

    protected void uc_16a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_16a_b.Checked)
        {
            cntl_uc_16a_a.Visible = false;
            cntl_uc_16b.Visible = false;

            uc_16a_a.Text = "";
            uc_16b_a.Checked = false;
            uc_16b_b.Checked = false;
            uc_16b_c.Checked = false;
        }
    }

    protected void uc_16a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_16a_c.Checked)
        {
            cntl_uc_16a_a.Visible = false;
            cntl_uc_16b.Visible = false;

            uc_16a_a.Text = "";
            uc_16b_a.Checked = false;
            uc_16b_b.Checked = false;
            uc_16b_c.Checked = false;
        }
    }

    protected void uc_16b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_16b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_16b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_17a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_17a_v.Checked)
        {
            cntl_uc_17a_a.Visible = true;
            cntl_uc_17b.Visible = true;
        }
    }

    protected void uc_17a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_17a_b.Checked)
        {
            cntl_uc_17a_a.Visible = false;
            cntl_uc_17b.Visible = false;

            uc_17a_a.Text = "";
            uc_17b_a.Checked = false;
            uc_17b_b.Checked = false;
            uc_17b_c.Checked = false;
        }
    }

    protected void uc_17a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_17a_c.Checked)
        {
            cntl_uc_17a_a.Visible = false;
            cntl_uc_17b.Visible = false;

            uc_17a_a.Text = "";
            uc_17b_a.Checked = false;
            uc_17b_b.Checked = false;
            uc_17b_c.Checked = false;
        }
    }

    protected void uc_17b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_17b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_17b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_18a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_18a_v.Checked)
        {
            cntl_uc_18a_a.Visible = true;
            cntl_uc_18b.Visible = true;
        }
    }

    protected void uc_18a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_18a_b.Checked)
        {
            cntl_uc_18a_a.Visible = false;
            cntl_uc_18b.Visible = false;

            uc_18a_a.Text = "";
            uc_18b_a.Checked = false;
            uc_18b_b.Checked = false;
            uc_18b_c.Checked = false;
        }
    }

    protected void uc_18a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_18a_c.Checked)
        {
            cntl_uc_18a_a.Visible = false;
            cntl_uc_18b.Visible = false;

            uc_18a_a.Text = "";
            uc_18b_a.Checked = false;
            uc_18b_b.Checked = false;
            uc_18b_c.Checked = false;
        }
    }

    protected void uc_18b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_18b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_18b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_19a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_19a_v.Checked)
        {
            cntl_uc_19a_a.Visible = true;
            cntl_uc_19b.Visible = true;
        }
    }

    protected void uc_19a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_19a_b.Checked)
        {
            cntl_uc_19a_a.Visible = false;
            cntl_uc_19b.Visible = false;

            uc_19a_a.Text = "";
            uc_19b_a.Checked = false;
            uc_19b_b.Checked = false;
            uc_19b_c.Checked = false;
        }
    }

    protected void uc_19a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_19a_c.Checked)
        {
            cntl_uc_19a_a.Visible = false;
            cntl_uc_19b.Visible = false;

            uc_19a_a.Text = "";
            uc_19b_a.Checked = false;
            uc_19b_b.Checked = false;
            uc_19b_c.Checked = false;
        }
    }

    protected void uc_19b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_19b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_19b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_20a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_20a_v.Checked)
        {
            cntl_uc_20a_a.Visible = true;
            cntl_uc_20b.Visible = true;
        }
    }

    protected void uc_20a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_20a_b.Checked)
        {
            cntl_uc_20a_a.Visible = false;
            cntl_uc_20b.Visible = false;

            uc_20a_a.Text = "";
            uc_20b_a.Checked = false;
            uc_20b_b.Checked = false;
            uc_20b_c.Checked = false;
        }
    }

    protected void uc_20a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_20a_c.Checked)
        {
            cntl_uc_20a_a.Visible = false;
            cntl_uc_20b.Visible = false;

            uc_20a_a.Text = "";
            uc_20b_a.Checked = false;
            uc_20b_b.Checked = false;
            uc_20b_c.Checked = false;
        }
    }

    protected void uc_20b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_20b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_20b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_21a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_21a_v.Checked)
        {
            cntl_uc_21a_a.Visible = true;
            cntl_uc_21b.Visible = true;
        }
    }

    protected void uc_21a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_21a_b.Checked)
        {
            cntl_uc_21a_a.Visible = false;
            cntl_uc_21b.Visible = false;

            uc_21a_a.Text = "";
            uc_21b_a.Checked = false;
            uc_21b_b.Checked = false;
            uc_21b_c.Checked = false;
        }
    }

    protected void uc_21a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_21a_c.Checked)
        {
            cntl_uc_21a_a.Visible = false;
            cntl_uc_21b.Visible = false;

            uc_21a_a.Text = "";
            uc_21b_a.Checked = false;
            uc_21b_b.Checked = false;
            uc_21b_c.Checked = false;
        }
    }

    protected void uc_21b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_21b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_21b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_22a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_22a_v.Checked)
        {
            cntl_uc_22a_a.Visible = true;
            cntl_uc_22b.Visible = true;
        }
    }

    protected void uc_22a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_22a_b.Checked)
        {
            cntl_uc_22a_a.Visible = false;
            cntl_uc_22b.Visible = false;

            uc_22a_a.Text = "";
            uc_22b_a.Checked = false;
            uc_22b_b.Checked = false;
            uc_22b_c.Checked = false;
        }
    }

    protected void uc_22a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_22a_c.Checked)
        {
            cntl_uc_22a_a.Visible = false;
            cntl_uc_22b.Visible = false;

            uc_22a_a.Text = "";
            uc_22b_a.Checked = false;
            uc_22b_b.Checked = false;
            uc_22b_c.Checked = false;
        }
    }

    protected void uc_22b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_22b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_22b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_23a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_23a_v.Checked)
        {
            cntl_uc_23a_a.Visible = true;
            cntl_uc_23b.Visible = true;
        }
    }

    protected void uc_23a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_23a_b.Checked)
        {
            cntl_uc_23a_a.Visible = false;
            cntl_uc_23b.Visible = false;

            uc_23a_a.Text = "";
            uc_23b_a.Checked = false;
            uc_23b_b.Checked = false;
            uc_23b_c.Checked = false;
        }
    }

    protected void uc_23a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_23a_c.Checked)
        {
            cntl_uc_23a_a.Visible = false;
            cntl_uc_23b.Visible = false;

            uc_23a_a.Text = "";
            uc_23b_a.Checked = false;
            uc_23b_b.Checked = false;
            uc_23b_c.Checked = false;
        }
    }

    protected void uc_23b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_23b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_23b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_24a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_24a_v.Checked)
        {
            cntl_uc_24a_a.Visible = true;
            cntl_uc_24b.Visible = true;
        }
    }

    protected void uc_24a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_24a_b.Checked)
        {
            cntl_uc_24a_a.Visible = false;
            cntl_uc_24b.Visible = false;

            uc_24a_a.Text = "";
            uc_24b_a.Checked = false;
            uc_24b_b.Checked = false;
            uc_24b_c.Checked = false;
        }
    }

    protected void uc_24a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_24a_c.Checked)
        {
            cntl_uc_24a_a.Visible = false;
            cntl_uc_24b.Visible = false;

            uc_24a_a.Text = "";
            uc_24b_a.Checked = false;
            uc_24b_b.Checked = false;
            uc_24b_c.Checked = false;
        }
    }

    protected void uc_24b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_24b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_24b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_25a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_25a_v.Checked)
        {
            cntl_uc_25a_a.Visible = true;
            cntl_uc_25b.Visible = true;
        }
    }

    protected void uc_25a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_25a_b.Checked)
        {
            cntl_uc_25a_a.Visible = false;
            cntl_uc_25b.Visible = false;

            uc_25a_a.Text = "";
            uc_25b_a.Checked = false;
            uc_25b_b.Checked = false;
            uc_25b_c.Checked = false;
        }
    }

    protected void uc_25a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_25a_c.Checked)
        {
            cntl_uc_25a_a.Visible = false;
            cntl_uc_25b.Visible = false;

            uc_25a_a.Text = "";
            uc_25b_a.Checked = false;
            uc_25b_b.Checked = false;
            uc_25b_c.Checked = false;
        }
    }

    protected void uc_25b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_25b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_25b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_26a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_26a_v.Checked)
        {
            cntl_uc_26a_a.Visible = true;
            cntl_uc_26b.Visible = true;
        }
    }

    protected void uc_26a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_26a_b.Checked)
        {
            cntl_uc_26a_a.Visible = false;
            cntl_uc_26b.Visible = false;

            uc_26a_a.Text = "";
            uc_26b_a.Checked = false;
            uc_26b_b.Checked = false;
            uc_26b_c.Checked = false;
        }
    }

    protected void uc_26a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_26a_c.Checked)
        {
            cntl_uc_26a_a.Visible = false;
            cntl_uc_26b.Visible = false;

            uc_26a_a.Text = "";
            uc_26b_a.Checked = false;
            uc_26b_b.Checked = false;
            uc_26b_c.Checked = false;
        }
    }

    protected void uc_26b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_26b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_26b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_27a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_27a_v.Checked)
        {
            cntl_uc_27a_a.Visible = true;
            cntl_uc_27b.Visible = true;
        }
    }

    protected void uc_27a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_27a_b.Checked)
        {
            cntl_uc_27a_a.Visible = false;
            cntl_uc_27b.Visible = false;

            uc_27a_a.Text = "";
            uc_27b_a.Checked = false;
            uc_27b_b.Checked = false;
            uc_27b_c.Checked = false;
        }
    }

    protected void uc_27a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_27a_c.Checked)
        {
            cntl_uc_27a_a.Visible = false;
            cntl_uc_27b.Visible = false;

            uc_27a_a.Text = "";
            uc_27b_a.Checked = false;
            uc_27b_b.Checked = false;
            uc_27b_c.Checked = false;
        }
    }

    protected void uc_27b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_27b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_27b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_28a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_28a_v.Checked)
        {
            cntl_uc_28a_a.Visible = true;
            cntl_uc_28b.Visible = true;
        }
    }

    protected void uc_28a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_28a_b.Checked)
        {
            cntl_uc_28a_a.Visible = false;
            cntl_uc_28b.Visible = false;

            uc_28a_a.Text = "";
            uc_28b_a.Checked = false;
            uc_28b_b.Checked = false;
            uc_28b_c.Checked = false;
        }
    }

    protected void uc_28a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_28a_c.Checked)
        {
            cntl_uc_28a_a.Visible = false;
            cntl_uc_28b.Visible = false;

            uc_28a_a.Text = "";
            uc_28b_a.Checked = false;
            uc_28b_b.Checked = false;
            uc_28b_c.Checked = false;
        }
    }

    protected void uc_28b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_28b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_28b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_29a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_29a_v.Checked)
        {
            cntl_uc_29a_a.Visible = true;
            cntl_uc_29b.Visible = true;
        }
    }

    protected void uc_29a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_29a_b.Checked)
        {
            cntl_uc_29a_a.Visible = false;
            cntl_uc_29b.Visible = false;

            uc_29a_a.Text = "";
            uc_29b_a.Checked = false;
            uc_29b_b.Checked = false;
            uc_29b_c.Checked = false;
        }
    }

    protected void uc_29a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_29a_c.Checked)
        {
            cntl_uc_29a_a.Visible = false;
            cntl_uc_29b.Visible = false;

            uc_29a_a.Text = "";
            uc_29b_a.Checked = false;
            uc_29b_b.Checked = false;
            uc_29b_c.Checked = false;
        }
    }

    protected void uc_29b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_29b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_29b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_30a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_30a_v.Checked)
        {
            cntl_uc_30a_a.Visible = true;
            cntl_uc_30b.Visible = true;
        }
    }

    protected void uc_30a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_30a_b.Checked)
        {
            cntl_uc_30a_a.Visible = false;
            cntl_uc_30b.Visible = false;

            uc_30a_a.Text = "";
            uc_30b_a.Checked = false;
            uc_30b_b.Checked = false;
            uc_30b_c.Checked = false;
        }
    }

    protected void uc_30a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_30a_c.Checked)
        {
            cntl_uc_30a_a.Visible = false;
            cntl_uc_30b.Visible = false;

            uc_30a_a.Text = "";
            uc_30b_a.Checked = false;
            uc_30b_b.Checked = false;
            uc_30b_c.Checked = false;
        }
    }

    protected void uc_30b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_30b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_30b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_31a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_31a_v.Checked)
        {
            cntl_uc_31a_a.Visible = true;
            cntl_uc_31b.Visible = true;
        }
    }

    protected void uc_31a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_31a_b.Checked)
        {
            cntl_uc_31a_a.Visible = false;
            cntl_uc_31b.Visible = false;

            uc_31a_a.Text = "";
            uc_31b_a.Checked = false;
            uc_31b_b.Checked = false;
            uc_31b_c.Checked = false;
        }
    }

    protected void uc_31a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_31a_c.Checked)
        {
            cntl_uc_31a_a.Visible = false;
            cntl_uc_31b.Visible = false;

            uc_31a_a.Text = "";
            uc_31b_a.Checked = false;
            uc_31b_b.Checked = false;
            uc_31b_c.Checked = false;
        }
    }

    protected void uc_31b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_31b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_31b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_32a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_32a_v.Checked)
        {
            cntl_uc_32a_a.Visible = true;
            cntl_uc_32b.Visible = true;
        }
    }

    protected void uc_32a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_32a_b.Checked)
        {
            cntl_uc_32a_a.Visible = false;
            cntl_uc_32b.Visible = false;

            uc_32a_a.Text = "";
            uc_32b_a.Checked = false;
            uc_32b_b.Checked = false;
            uc_32b_c.Checked = false;
        }
    }

    protected void uc_32a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_32a_c.Checked)
        {
            cntl_uc_32a_a.Visible = false;
            cntl_uc_32b.Visible = false;

            uc_32a_a.Text = "";
            uc_32b_a.Checked = false;
            uc_32b_b.Checked = false;
            uc_32b_c.Checked = false;
        }
    }

    protected void uc_32b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_32b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_32b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_33a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_33a_v.Checked)
        {
            cntl_uc_33a_a.Visible = true;
            cntl_uc_33b.Visible = true;
        }
    }

    protected void uc_33a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_33a_b.Checked)
        {
            cntl_uc_33a_a.Visible = false;
            cntl_uc_33b.Visible = false;

            uc_33a_a.Text = "";
            uc_33b_a.Checked = false;
            uc_33b_b.Checked = false;
            uc_33b_c.Checked = false;
        }
    }

    protected void uc_33a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_33a_c.Checked)
        {
            cntl_uc_33a_a.Visible = false;
            cntl_uc_33b.Visible = false;

            uc_33a_a.Text = "";
            uc_33b_a.Checked = false;
            uc_33b_b.Checked = false;
            uc_33b_c.Checked = false;
        }
    }

    protected void uc_33b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_33b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_33b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_34a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_34a_v.Checked)
        {
            cntl_uc_34a_a.Visible = true;
            cntl_uc_34b.Visible = true;
        }
    }

    protected void uc_34a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_34a_b.Checked)
        {
            cntl_uc_34a_a.Visible = false;
            cntl_uc_34b.Visible = false;

            uc_34a_a.Text = "";
            uc_34b_a.Checked = false;
            uc_34b_b.Checked = false;
            uc_34b_c.Checked = false;
        }
    }

    protected void uc_34a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_34a_c.Checked)
        {
            cntl_uc_34a_a.Visible = false;
            cntl_uc_34b.Visible = false;

            uc_34a_a.Text = "";
            uc_34b_a.Checked = false;
            uc_34b_b.Checked = false;
            uc_34b_c.Checked = false;
        }
    }

    protected void uc_34b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_34b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_34b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_35a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_35a_v.Checked)
        {
            cntl_uc_35a_a.Visible = true;
            cntl_uc_35b.Visible = true;
        }
    }

    protected void uc_35a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_35a_b.Checked)
        {
            cntl_uc_35a_a.Visible = false;
            cntl_uc_35b.Visible = false;

            uc_35a_a.Text = "";
            uc_35b_a.Checked = false;
            uc_35b_b.Checked = false;
            uc_35b_c.Checked = false;
        }
    }

    protected void uc_35a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_35a_c.Checked)
        {
            cntl_uc_35a_a.Visible = false;
            cntl_uc_35b.Visible = false;

            uc_35a_a.Text = "";
            uc_35b_a.Checked = false;
            uc_35b_b.Checked = false;
            uc_35b_c.Checked = false;
        }
    }

    protected void uc_35b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_35b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_35b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_36a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_36a_v.Checked)
        {
            cntl_uc_36a_a.Visible = true;
            cntl_uc_36b.Visible = true;
        }
    }

    protected void uc_36a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_36a_b.Checked)
        {
            cntl_uc_36a_a.Visible = false;
            cntl_uc_36b.Visible = false;

            uc_36a_a.Text = "";
            uc_36b_a.Checked = false;
            uc_36b_b.Checked = false;
            uc_36b_c.Checked = false;
        }
    }

    protected void uc_36a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_36a_c.Checked)
        {
            cntl_uc_36a_a.Visible = false;
            cntl_uc_36b.Visible = false;

            uc_36a_a.Text = "";
            uc_36b_a.Checked = false;
            uc_36b_b.Checked = false;
            uc_36b_c.Checked = false;
        }
    }

    protected void uc_36b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_36b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_36b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_37a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_37a_v.Checked)
        {
            cntl_uc_37a_a.Visible = true;
            cntl_uc_37b.Visible = true;
        }
    }

    protected void uc_37a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_37a_b.Checked)
        {
            cntl_uc_37a_a.Visible = false;
            cntl_uc_37b.Visible = false;

            uc_37a_a.Text = "";
            uc_37b_a.Checked = false;
            uc_37b_b.Checked = false;
            uc_37b_c.Checked = false;
        }
    }

    protected void uc_37a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (uc_37a_c.Checked)
        {
            cntl_uc_37a_a.Visible = false;
            cntl_uc_37b.Visible = false;

            uc_37a_a.Text = "";
            uc_37b_a.Checked = false;
            uc_37b_b.Checked = false;
            uc_37b_c.Checked = false;
        }
    }

    protected void uc_37b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_37b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void uc_37b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_20a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_20a_v.Checked)
        {
            cntl_LA_20a_a.Visible = true;
            cntl_LA_20b.Visible = true;
        }
    }

    protected void LA_20a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_20a_b.Checked)
        {
            cntl_LA_20a_a.Visible = false;
            cntl_LA_20b.Visible = false;
            LA_20a_a.Text = "";
            LA_20b_a.Checked = false;
            LA_20b_b.Checked = false;
            LA_20b_c.Checked = false;
        }
    }

    protected void LA_20a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_20a_c.Checked)
        {
            cntl_LA_20a_a.Visible = false;
            cntl_LA_20b.Visible = false;
            LA_20a_a.Text = "";
            LA_20b_a.Checked = false;
            LA_20b_b.Checked = false;
            LA_20b_c.Checked = false;
        }
    }

    protected void LA_20b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_20b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_20b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_21a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_21a_v.Checked)
        {
            cntl_LA_21a_a.Visible = true;
            cntl_LA_21b.Visible = true;
        }
    }

    protected void LA_21a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_21a_b.Checked)
        {
            cntl_LA_21a_a.Visible = false;
            cntl_LA_21b.Visible = false;
            LA_21a_a.Text = "";
            LA_21b_a.Checked = false;
            LA_21b_b.Checked = false;
            LA_21b_c.Checked = false;
        }
    }

    protected void LA_21a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_21a_c.Checked)
        {
            cntl_LA_21a_a.Visible = false;
            cntl_LA_21b.Visible = false;
            LA_21a_a.Text = "";
            LA_21b_a.Checked = false;
            LA_21b_b.Checked = false;
            LA_21b_c.Checked = false;
        }
    }

    protected void LA_21b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_21b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_21b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_22a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_22a_v.Checked)
        {
            cntl_LA_22a_a.Visible = true;
            cntl_LA_22b.Visible = true;
        }
    }

    protected void LA_22a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_22a_b.Checked)
        {
            cntl_LA_22a_a.Visible = false;
            cntl_LA_22b.Visible = false;
            LA_22a_a.Text = "";
            LA_22b_a.Checked = false;
            LA_22b_b.Checked = false;
            LA_22b_c.Checked = false;
        }
    }

    protected void LA_22a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_22a_c.Checked)
        {
            cntl_LA_22a_a.Visible = false;
            cntl_LA_22b.Visible = false;
            LA_22a_a.Text = "";
            LA_22b_a.Checked = false;
            LA_22b_b.Checked = false;
            LA_22b_c.Checked = false;
        }
    }

    protected void LA_22b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_22b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_22b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_23a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_23a_v.Checked)
        {
            cntl_LA_23a_a.Visible = true;
            cntl_LA_23b.Visible = true;
        }
    }

    protected void LA_23a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_23a_b.Checked)
        {
            cntl_LA_23a_a.Visible = false;
            cntl_LA_23b.Visible = false;
            LA_23a_a.Text = "";
            LA_23b_a.Checked = false;
            LA_23b_b.Checked = false;
            LA_23b_c.Checked = false;
        }
    }

    protected void LA_23a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_23a_c.Checked)
        {
            cntl_LA_23a_a.Visible = false;
            cntl_LA_23b.Visible = false;
            LA_23a_a.Text = "";
            LA_23b_a.Checked = false;
            LA_23b_b.Checked = false;
            LA_23b_c.Checked = false;
        }
    }

    protected void LA_23b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_23b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_23b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_24a_v_CheckedChanged1(object sender, EventArgs e)
    {
        if (LA_24a_v.Checked)
        {
            cntl_LA_24a_a.Visible = true;
            cntl_LA_24b.Visible = true;
        }
    }

    protected void LA_24a_b_CheckedChanged1(object sender, EventArgs e)
    {
        if (LA_24a_b.Checked)
        {
            cntl_LA_24a_a.Visible = false;
            cntl_LA_24b.Visible = false;
            LA_24a_a.Text = "";
            LA_24b_a.Checked = false;
            LA_24b_b.Checked = false;
            LA_24b_c.Checked = false;
        }
    }

    protected void LA_24a_c_CheckedChanged1(object sender, EventArgs e)
    {
        if (LA_24a_c.Checked)
        {
            cntl_LA_24a_a.Visible = false;
            cntl_LA_24b.Visible = false;
            LA_24a_a.Text = "";
            LA_24b_a.Checked = false;
            LA_24b_b.Checked = false;
            LA_24b_c.Checked = false;
        }
    }

    protected void LA_24b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_24b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_24b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_25a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_25a_v.Checked)
        {
            cntl_LA_25a_a.Visible = true;
            cntl_LA_25b.Visible = true;
        }
    }

    protected void LA_25a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_25a_b.Checked)
        {
            cntl_LA_25a_a.Visible = false;
            cntl_LA_25b.Visible = false;
            LA_25a_a.Text = "";
            LA_25b_a.Checked = false;
            LA_25b_b.Checked = false;
            LA_25b_c.Checked = false;
        }
    }

    protected void LA_25a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_25a_c.Checked)
        {
            cntl_LA_25a_a.Visible = false;
            cntl_LA_25b.Visible = false;
            LA_25a_a.Text = "";
            LA_25b_a.Checked = false;
            LA_25b_b.Checked = false;
            LA_25b_c.Checked = false;
        }
    }

    protected void LA_25b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_25b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_25b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_26a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_26a_v.Checked)
        {
            cntl_LA_26a_a.Visible = true;
            cntl_LA_26b.Visible = true;
        }
    }

    protected void LA_26a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_26a_b.Checked)
        {
            cntl_LA_26a_a.Visible = false;
            cntl_LA_26b.Visible = false;
            LA_26a_a.Text = "";
            LA_26b_a.Checked = false;
            LA_26b_b.Checked = false;
            LA_26b_c.Checked = false;
        }
    }

    protected void LA_26a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_26a_c.Checked)
        {
            cntl_LA_26a_a.Visible = false;
            cntl_LA_26b.Visible = false;
            LA_26a_a.Text = "";
            LA_26b_a.Checked = false;
            LA_26b_b.Checked = false;
            LA_26b_c.Checked = false;
        }
    }

    protected void LA_26b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_26b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_26b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_27a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_27a_v.Checked)
        {
            cntl_LA_27a_a.Visible = true;
            cntl_LA_27b.Visible = true;
        }
    }

    protected void LA_27a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_27a_b.Checked)
        {
            cntl_LA_27a_a.Visible = false;
            cntl_LA_27b.Visible = false;
            LA_27a_a.Text = "";
            LA_27b_a.Checked = false;
            LA_27b_b.Checked = false;
            LA_27b_c.Checked = false;
        }
    }

    protected void LA_27a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_27a_c.Checked)
        {
            cntl_LA_27a_a.Visible = false;
            cntl_LA_27b.Visible = false;
            LA_27a_a.Text = "";
            LA_27b_a.Checked = false;
            LA_27b_b.Checked = false;
            LA_27b_c.Checked = false;
        }
    }

    protected void LA_27b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_27b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_27b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_28a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_28a_v.Checked)
        {
            cntl_LA_28a_a.Visible = true;
            cntl_LA_28b.Visible = true;
        }
    }

    protected void LA_28a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_28a_b.Checked)
        {
            cntl_LA_28a_a.Visible = false;
            cntl_LA_28b.Visible = false;
            LA_28a_a.Text = "";
            LA_28b_a.Checked = false;
            LA_28b_b.Checked = false;
            LA_28b_c.Checked = false;
        }
    }

    protected void LA_28a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_28a_c.Checked)
        {
            cntl_LA_28a_a.Visible = false;
            cntl_LA_28b.Visible = false;
            LA_28a_a.Text = "";
            LA_28b_a.Checked = false;
            LA_28b_b.Checked = false;
            LA_28b_c.Checked = false;
        }
    }

    protected void LA_28b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_28b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_28b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_29a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_29a_v.Checked)
        {
            cntl_LA_29a_a.Visible = true;
            cntl_LA_29b.Visible = true;
        }
    }

    protected void LA_29a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_29a_b.Checked)
        {
            cntl_LA_29a_a.Visible = false;
            cntl_LA_29b.Visible = false;
            LA_29a_a.Text = "";
            LA_29b_a.Checked = false;
            LA_29b_b.Checked = false;
            LA_29b_c.Checked = false;
        }
    }

    protected void LA_29a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_29a_c.Checked)
        {
            cntl_LA_29a_a.Visible = false;
            cntl_LA_29b.Visible = false;
            LA_29a_a.Text = "";
            LA_29b_a.Checked = false;
            LA_29b_b.Checked = false;
            LA_29b_c.Checked = false;
        }
    }

    protected void LA_29b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_29b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_29b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_30a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_30a_v.Checked)
        {
            cntl_LA_30a_a.Visible = true;
            cntl_LA_30b.Visible = true;
        }
    }

    protected void LA_30a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_30a_b.Checked)
        {
            cntl_LA_30a_a.Visible = false;
            cntl_LA_30b.Visible = false;
            LA_30a_a.Text = "";
            LA_30b_a.Checked = false;
            LA_30b_b.Checked = false;
            LA_30b_c.Checked = false;
        }
    }

    protected void LA_30a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_30a_c.Checked)
        {
            cntl_LA_30a_a.Visible = false;
            cntl_LA_30b.Visible = false;
            LA_30a_a.Text = "";
            LA_30b_a.Checked = false;
            LA_30b_b.Checked = false;
            LA_30b_c.Checked = false;
        }
    }

    protected void LA_30b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_30b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_30b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_31a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_31a_v.Checked)
        {
            cntl_LA_31a_a.Visible = true;
            cntl_LA_31b.Visible = true;
        }
    }

    protected void LA_31a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_31a_b.Checked)
        {
            cntl_LA_31a_a.Visible = false;
            cntl_LA_31b.Visible = false;
            LA_31a_a.Text = "";
            LA_31b_a.Checked = false;
            LA_31b_b.Checked = false;
            LA_31b_c.Checked = false;
        }
    }

    protected void LA_31a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_31a_c.Checked)
        {
            cntl_LA_31a_a.Visible = false;
            cntl_LA_31b.Visible = false;
            LA_31a_a.Text = "";
            LA_31b_a.Checked = false;
            LA_31b_b.Checked = false;
            LA_31b_c.Checked = false;
        }
    }

    protected void LA_31b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_31b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_31b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_32a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_32a_v.Checked)
        {
            cntl_LA_32a_a.Visible = true;
            cntl_LA_32b.Visible = true;
        }
    }

    protected void LA_32a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_32a_b.Checked)
        {
            cntl_LA_32a_a.Visible = false;
            cntl_LA_32b.Visible = false;
            LA_32a_a.Text = "";
            LA_32b_a.Checked = false;
            LA_32b_b.Checked = false;
            LA_32b_c.Checked = false;
        }
    }

    protected void LA_32a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_32a_c.Checked)
        {
            cntl_LA_32a_a.Visible = false;
            cntl_LA_32b.Visible = false;
            LA_32a_a.Text = "";
            LA_32b_a.Checked = false;
            LA_32b_b.Checked = false;
            LA_32b_c.Checked = false;
        }
    }

    protected void LA_32b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_32b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_32b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_33a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_33a_v.Checked)
        {
            cntl_LA_33a_a.Visible = true;
            cntl_LA_33b.Visible = true;
        }
    }

    protected void LA_33a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_33a_b.Checked)
        {
            cntl_LA_33a_a.Visible = false;
            cntl_LA_33b.Visible = false;
            LA_33a_a.Text = "";
            LA_33b_a.Checked = false;
            LA_33b_b.Checked = false;
            LA_33b_c.Checked = false;
        }
    }

    protected void LA_33a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_33a_c.Checked)
        {
            cntl_LA_33a_a.Visible = false;
            cntl_LA_33b.Visible = false;
            LA_33a_a.Text = "";
            LA_33b_a.Checked = false;
            LA_33b_b.Checked = false;
            LA_33b_c.Checked = false;
        }
    }

    protected void LA_33b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_33b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_33b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_34a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_34a_v.Checked)
        {
            cntl_LA_34a_a.Visible = true;
            cntl_LA_34b.Visible = true;
        }
    }

    protected void LA_34a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_34a_b.Checked)
        {
            cntl_LA_34a_a.Visible = false;
            cntl_LA_34b.Visible = false;
            LA_34a_a.Text = "";
            LA_34b_a.Checked = false;
            LA_34b_b.Checked = false;
            LA_34b_c.Checked = false;
        }
    }

    protected void LA_34a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_34a_c.Checked)
        {
            cntl_LA_34a_a.Visible = false;
            cntl_LA_34b.Visible = false;
            LA_34a_a.Text = "";
            LA_34b_a.Checked = false;
            LA_34b_b.Checked = false;
            LA_34b_c.Checked = false;
        }
    }

    protected void LA_34b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_34b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_34b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_35a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_35a_v.Checked)
        {
            cntl_LA_35a_a.Visible = true;
            cntl_LA_35b.Visible = true;
        }
    }

    protected void LA_35a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_35a_b.Checked)
        {
            cntl_LA_35a_a.Visible = false;
            cntl_LA_35b.Visible = false;
            LA_35a_a.Text = "";
            LA_35b_a.Checked = false;
            LA_35b_b.Checked = false;
            LA_35b_c.Checked = false;
        }
    }

    protected void LA_35a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_35a_c.Checked)
        {
            cntl_LA_35a_a.Visible = false;
            cntl_LA_35b.Visible = false;
            LA_35a_a.Text = "";
            LA_35b_a.Checked = false;
            LA_35b_b.Checked = false;
            LA_35b_c.Checked = false;
        }
    }

    protected void LA_35b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_35b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_35b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_36a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_36a_v.Checked)
        {
            cntl_LA_36a_a.Visible = true;
            cntl_LA_36b.Visible = true;
        }
    }

    protected void LA_36a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_36a_b.Checked)
        {
            cntl_LA_36a_a.Visible = false;
            cntl_LA_36b.Visible = false;
            LA_36a_a.Text = "";
            LA_36b_a.Checked = false;
            LA_36b_b.Checked = false;
            LA_36b_c.Checked = false;
        }
    }

    protected void LA_36a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_36a_c.Checked)
        {
            cntl_LA_36a_a.Visible = false;
            cntl_LA_36b.Visible = false;
            LA_36a_a.Text = "";
            LA_36b_a.Checked = false;
            LA_36b_b.Checked = false;
            LA_36b_c.Checked = false;
        }
    }

    protected void LA_36b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_36b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_36b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_37a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_37a_v.Checked)
        {
            cntl_LA_37a_a.Visible = true;
            cntl_LA_37b.Visible = true;
        }
    }

    protected void LA_37a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_37a_b.Checked)
        {
            cntl_LA_37a_a.Visible = false;
            cntl_LA_37b.Visible = false;
            LA_37a_a.Text = "";
            LA_37b_a.Checked = false;
            LA_37b_b.Checked = false;
            LA_37b_c.Checked = false;
        }
    }

    protected void LA_37a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_37a_c.Checked)
        {
            cntl_LA_37a_a.Visible = false;
            cntl_LA_37b.Visible = false;
            LA_37a_a.Text = "";
            LA_37b_a.Checked = false;
            LA_37b_b.Checked = false;
            LA_37b_c.Checked = false;
        }
    }

    protected void LA_37b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_37b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_37b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_38a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_38a_v.Checked)
        {
            cntl_LA_38a_a.Visible = true;
            cntl_LA_38b.Visible = true;
        }
    }

    protected void LA_38a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_38a_b.Checked)
        {
            cntl_LA_38a_a.Visible = false;
            cntl_LA_38b.Visible = false;
            LA_38a_a.Text = "";
            LA_38b_a.Checked = false;
            LA_38b_b.Checked = false;
            LA_38b_c.Checked = false;
        }
    }

    protected void LA_38a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_38a_c.Checked)
        {
            cntl_LA_38a_a.Visible = false;
            cntl_LA_38b.Visible = false;
            LA_38a_a.Text = "";
            LA_38b_a.Checked = false;
            LA_38b_b.Checked = false;
            LA_38b_c.Checked = false;
        }
    }

    protected void LA_38b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_38b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_38b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_39a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_39a_v.Checked)
        {
            cntl_LA_39a_a.Visible = true;
            cntl_LA_39b.Visible = true;
        }
    }

    protected void LA_39a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_39a_b.Checked)
        {
            cntl_LA_39a_a.Visible = false;
            cntl_LA_39b.Visible = false;
            LA_39a_a.Text = "";
            LA_39b_a.Checked = false;
            LA_39b_b.Checked = false;
            LA_39b_c.Checked = false;
        }
    }

    protected void LA_39a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_39a_c.Checked)
        {
            cntl_LA_39a_a.Visible = false;
            cntl_LA_39b.Visible = false;
            LA_39a_a.Text = "";
            LA_39b_a.Checked = false;
            LA_39b_b.Checked = false;
            LA_39b_c.Checked = false;
        }
    }

    protected void LA_39b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_39b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_39b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_40a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_40a_v.Checked)
        {
            cntl_LA_40a_a.Visible = true;
            cntl_LA_40b.Visible = true;
        }
    }

    protected void LA_40a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_40a_b.Checked)
        {
            cntl_LA_40a_a.Visible = false;
            cntl_LA_40b.Visible = false;
            LA_40a_a.Text = "";
            LA_40b_a.Checked = false;
            LA_40b_b.Checked = false;
            LA_40b_c.Checked = false;
        }
    }

    protected void LA_40a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_40a_c.Checked)
        {
            cntl_LA_40a_a.Visible = false;
            cntl_LA_40b.Visible = false;
            LA_40a_a.Text = "";
            LA_40b_a.Checked = false;
            LA_40b_b.Checked = false;
            LA_40b_c.Checked = false;
        }
    }

    protected void LA_40b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_40b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_40b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_41a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_41a_v.Checked)
        {
            cntl_LA_41a_a.Visible = true;
            cntl_LA_41b.Visible = true;
        }
    }

    protected void LA_41a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_41a_b.Checked)
        {
            cntl_LA_41a_a.Visible = false;
            cntl_LA_41b.Visible = false;
            LA_41a_a.Text = "";
            LA_41b_a.Checked = false;
            LA_41b_b.Checked = false;
            LA_41b_c.Checked = false;
        }
    }

    protected void LA_41a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_41a_c.Checked)
        {
            cntl_LA_41a_a.Visible = false;
            cntl_LA_41b.Visible = false;
            LA_41a_a.Text = "";
            LA_41b_a.Checked = false;
            LA_41b_b.Checked = false;
            LA_41b_c.Checked = false;
        }
    }

    protected void LA_41b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_41b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_41b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_42a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_42a_v.Checked)
        {
            cntl_LA_42a_a.Visible = true;
            cntl_LA_42b.Visible = true;
        }
    }

    protected void LA_42a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_42a_b.Checked)
        {
            cntl_LA_42a_a.Visible = false;
            cntl_LA_42b.Visible = false;
            LA_42a_a.Text = "";
            LA_42b_a.Checked = false;
            LA_42b_b.Checked = false;
            LA_42b_c.Checked = false;
        }
    }

    protected void LA_42a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_42a_c.Checked)
        {
            cntl_LA_42a_a.Visible = false;
            cntl_LA_42b.Visible = false;
            LA_42a_a.Text = "";
            LA_42b_a.Checked = false;
            LA_42b_b.Checked = false;
            LA_42b_c.Checked = false;
        }
    }

    protected void LA_42b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_42b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_42b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_43a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_43a_v.Checked)
        {
            cntl_LA_43a_a.Visible = true;
            cntl_LA_43b.Visible = true;
        }
    }

    protected void LA_43a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_43a_b.Checked)
        {
            cntl_LA_43a_a.Visible = false;
            cntl_LA_43b.Visible = false;
            LA_43a_a.Text = "";
            LA_43b_a.Checked = false;
            LA_43b_b.Checked = false;
            LA_43b_c.Checked = false;
        }
    }

    protected void LA_43a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_43a_c.Checked)
        {
            cntl_LA_43a_a.Visible = false;
            cntl_LA_43b.Visible = false;
            LA_43a_a.Text = "";
            LA_43b_a.Checked = false;
            LA_43b_b.Checked = false;
            LA_43b_c.Checked = false;
        }
    }

    protected void LA_43b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_43b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_43b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_44a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_44a_v.Checked)
        {
            cntl_LA_44a_a.Visible = true;
            cntl_LA_44b.Visible = true;
        }
    }

    protected void LA_44a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_44a_b.Checked)
        {
            cntl_LA_44a_a.Visible = false;
            cntl_LA_44b.Visible = false;
            LA_44a_a.Text = "";
            LA_44b_a.Checked = false;
            LA_44b_b.Checked = false;
            LA_44b_c.Checked = false;
        }
    }

    protected void LA_44a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_44a_c.Checked)
        {
            cntl_LA_44a_a.Visible = false;
            cntl_LA_44b.Visible = false;
            LA_44a_a.Text = "";
            LA_44b_a.Checked = false;
            LA_44b_b.Checked = false;
            LA_44b_c.Checked = false;
        }
    }

    protected void LA_44b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_44b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_44b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_45a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_45a_v.Checked)
        {
            cntl_LA_45a_a.Visible = true;
            cntl_LA_45b.Visible = true;
        }
    }

    protected void LA_45a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_45a_b.Checked)
        {
            cntl_LA_45a_a.Visible = false;
            cntl_LA_45b.Visible = false;
            LA_45a_a.Text = "";
            LA_45b_a.Checked = false;
            LA_45b_b.Checked = false;
            LA_45b_c.Checked = false;
        }
    }

    protected void LA_45a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_45a_c.Checked)
        {
            cntl_LA_45a_a.Visible = false;
            cntl_LA_45b.Visible = false;
            LA_45a_a.Text = "";
            LA_45b_a.Checked = false;
            LA_45b_b.Checked = false;
            LA_45b_c.Checked = false;
        }
    }

    protected void LA_45b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_45b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_45b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_46a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_46a_v.Checked)
        {
            cntl_LA_46a_a.Visible = true;
            cntl_LA_46b.Visible = true;
        }
    }

    protected void LA_46a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_46a_b.Checked)
        {
            cntl_LA_46a_a.Visible = false;
            cntl_LA_46b.Visible = false;
            LA_46a_a.Text = "";
            LA_46b_a.Checked = false;
            LA_46b_b.Checked = false;
            LA_46b_c.Checked = false;
        }
    }

    protected void LA_46a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_46a_c.Checked)
        {
            cntl_LA_46a_a.Visible = false;
            cntl_LA_46b.Visible = false;
            LA_46a_a.Text = "";
            LA_46b_a.Checked = false;
            LA_46b_b.Checked = false;
            LA_46b_c.Checked = false;
        }
    }

    protected void LA_46b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_46b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_46b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_47a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_47a_v.Checked)
        {
            cntl_LA_47a_a.Visible = true;
            cntl_LA_47b.Visible = true;
        }
    }

    protected void LA_47a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_47a_b.Checked)
        {
            cntl_LA_47a_a.Visible = false;
            cntl_LA_47b.Visible = false;
            LA_47a_a.Text = "";
            LA_47b_a.Checked = false;
            LA_47b_b.Checked = false;
            LA_47b_c.Checked = false;
        }
    }

    protected void LA_47a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_47a_c.Checked)
        {
            cntl_LA_47a_a.Visible = false;
            cntl_LA_47b.Visible = false;
            LA_47a_a.Text = "";
            LA_47b_a.Checked = false;
            LA_47b_b.Checked = false;
            LA_47b_c.Checked = false;
        }
    }

    protected void LA_47b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_47b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_47b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_48a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_48a_v.Checked)
        {
            cntl_LA_48a_a.Visible = true;
            cntl_LA_48b.Visible = true;
        }
    }

    protected void LA_48a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_48a_b.Checked)
        {
            cntl_LA_48a_a.Visible = false;
            cntl_LA_48b.Visible = false;
            LA_48a_a.Text = "";
            LA_48b_a.Checked = false;
            LA_48b_b.Checked = false;
            LA_48b_c.Checked = false;
        }
    }

    protected void LA_48a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_48a_c.Checked)
        {
            cntl_LA_48a_a.Visible = false;
            cntl_LA_48b.Visible = false;
            LA_48a_a.Text = "";
            LA_48b_a.Checked = false;
            LA_48b_b.Checked = false;
            LA_48b_c.Checked = false;
        }
    }

    protected void LA_48b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_48b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_48b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_49a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_49a_v.Checked)
        {
            cntl_LA_49a_a.Visible = true;
            cntl_LA_49b.Visible = true;
        }
    }

    protected void LA_49a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_49a_b.Checked)
        {
            cntl_LA_49a_a.Visible = false;
            cntl_LA_49b.Visible = false;
            LA_49a_a.Text = "";
            LA_49b_a.Checked = false;
            LA_49b_b.Checked = false;
            LA_49b_c.Checked = false;
        }
    }

    protected void LA_49a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_49a_c.Checked)
        {
            cntl_LA_49a_a.Visible = false;
            cntl_LA_49b.Visible = false;
            LA_49a_a.Text = "";
            LA_49b_a.Checked = false;
            LA_49b_b.Checked = false;
            LA_49b_c.Checked = false;
        }
    }

    protected void LA_49b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_49b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_49b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_50a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_50a_v.Checked)
        {
            cntl_LA_50a_a.Visible = true;
            cntl_LA_50b.Visible = true;
        }
    }

    protected void LA_50a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_50a_b.Checked)
        {
            cntl_LA_50a_a.Visible = false;
            cntl_LA_50b.Visible = false;
            LA_50a_a.Text = "";
            LA_50b_a.Checked = false;
            LA_50b_b.Checked = false;
            LA_50b_c.Checked = false;
        }
    }

    protected void LA_50a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_50a_c.Checked)
        {
            cntl_LA_50a_a.Visible = false;
            cntl_LA_50b.Visible = false;
            LA_50a_a.Text = "";
            LA_50b_a.Checked = false;
            LA_50b_b.Checked = false;
            LA_50b_c.Checked = false;
        }
    }

    protected void LA_50b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_50b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_50b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_51a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_51a_v.Checked)
        {
            cntl_LA_51a_a.Visible = true;
            cntl_LA_51b.Visible = true;
        }
    }

    protected void LA_51a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_51a_b.Checked)
        {
            cntl_LA_51a_a.Visible = false;
            cntl_LA_51b.Visible = false;
            LA_51a_a.Text = "";
            LA_51b_a.Checked = false;
            LA_51b_b.Checked = false;
            LA_51b_c.Checked = false;
        }
    }

    protected void LA_51a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_51a_c.Checked)
        {
            cntl_LA_51a_a.Visible = false;
            cntl_LA_51b.Visible = false;
            LA_51a_a.Text = "";
            LA_51b_a.Checked = false;
            LA_51b_b.Checked = false;
            LA_51b_c.Checked = false;
        }
    }

    protected void LA_51b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_51b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_51b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_52a_v_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_52a_v.Checked)
        {
            cntl_LA_52a_a.Visible = true;
            cntl_LA_52b.Visible = true;
        }
    }

    protected void LA_52a_b_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_52a_b.Checked)
        {
            cntl_LA_52a_a.Visible = false;
            cntl_LA_52b.Visible = false;
            LA_52a_a.Text = "";
            LA_52b_a.Checked = false;
            LA_52b_b.Checked = false;
            LA_52b_c.Checked = false;
        }
    }

    protected void LA_52a_c_CheckedChanged(object sender, EventArgs e)
    {
        if (LA_52a_c.Checked)
        {
            cntl_LA_52a_a.Visible = false;
            cntl_LA_52b.Visible = false;
            LA_52a_a.Text = "";
            LA_52b_a.Checked = false;
            LA_52b_b.Checked = false;
            LA_52b_c.Checked = false;
        }
    }

    protected void LA_52b_a_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_52b_b_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void LA_52b_c_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void rd_BloodCulture_Pos_CheckedChanged(object sender, EventArgs e)
    {
        if (rd_BloodCulture_Pos.Checked)
        {
            cntl_rdo_Blood_Organism.Visible = true;

            ddl_BloodCulture.Items.Clear();
            FillDropDown_BloodCulture_Positive();
            pnl_BloodCulture_Sensitivity.Visible = true;
        }
    }

    protected void rd_BloodCulture_Neg_CheckedChanged(object sender, EventArgs e)
    {
        if (rd_BloodCulture_Neg.Checked)
        {
            cntl_rdo_Blood_Organism.Visible = false;
            BloodCulture_Multiple_Yes.Checked = false;
            BloodCulture_Multiple_No.Checked = false;

            cntl_Blood_Organism.Visible = false;

            ddl_BloodCulture.Items.Clear();
            FillDropDown_BloodCulture_Negative();
            txtOtherOrganism.Text = "";
            txtOtherOrganism.ReadOnly = true;
            pnl_BloodCulture_Sensitivity.Visible = false;
            DisableSensitivity_BloodCulture();
        }
    }


    private void EnableSensitivity_BloodCulture()
    {
        EnableControls(LA_18);
        //EnableControls(LA_19);


        Enable_RadioButton(LA_20a_v);
        Enable_RadioButton(LA_20a_b);
        Enable_RadioButton(LA_20a_c);
        EnableControls(LA_20a_a);
        Enable_RadioButton(LA_20b_a);
        Enable_RadioButton(LA_20b_b);
        Enable_RadioButton(LA_20b_c);


        Enable_RadioButton(LA_21a_v);
        Enable_RadioButton(LA_21a_b);
        Enable_RadioButton(LA_21a_c);
        EnableControls(LA_21a_a);
        Enable_RadioButton(LA_21b_a);
        Enable_RadioButton(LA_21b_b);
        Enable_RadioButton(LA_21b_c);


        Enable_RadioButton(LA_22a_v);
        Enable_RadioButton(LA_22a_b);
        Enable_RadioButton(LA_22a_c);
        EnableControls(LA_22a_a);
        Enable_RadioButton(LA_22b_a);
        Enable_RadioButton(LA_22b_b);
        Enable_RadioButton(LA_22b_c);


        Enable_RadioButton(LA_23a_v);
        Enable_RadioButton(LA_23a_b);
        Enable_RadioButton(LA_23a_c);
        EnableControls(LA_23a_a);
        Enable_RadioButton(LA_23b_a);
        Enable_RadioButton(LA_23b_b);
        Enable_RadioButton(LA_23b_c);


        Enable_RadioButton(LA_24a_v);
        Enable_RadioButton(LA_24a_b);
        Enable_RadioButton(LA_24a_c);
        EnableControls(LA_24a_a);
        Enable_RadioButton(LA_24b_a);
        Enable_RadioButton(LA_24b_b);
        Enable_RadioButton(LA_24b_c);


        Enable_RadioButton(LA_25a_v);
        Enable_RadioButton(LA_25a_b);
        Enable_RadioButton(LA_25a_c);
        EnableControls(LA_25a_a);
        Enable_RadioButton(LA_25b_a);
        Enable_RadioButton(LA_25b_b);
        Enable_RadioButton(LA_25b_c);


        Enable_RadioButton(LA_26a_v);
        Enable_RadioButton(LA_26a_b);
        Enable_RadioButton(LA_26a_c);
        EnableControls(LA_26a_a);
        Enable_RadioButton(LA_26b_a);
        Enable_RadioButton(LA_26b_b);
        Enable_RadioButton(LA_26b_c);


        Enable_RadioButton(LA_27a_v);
        Enable_RadioButton(LA_27a_b);
        Enable_RadioButton(LA_27a_c);
        EnableControls(LA_27a_a);
        Enable_RadioButton(LA_27b_a);
        Enable_RadioButton(LA_27b_b);
        Enable_RadioButton(LA_27b_c);


        Enable_RadioButton(LA_28a_v);
        Enable_RadioButton(LA_28a_b);
        Enable_RadioButton(LA_28a_c);
        EnableControls(LA_28a_a);
        Enable_RadioButton(LA_28b_a);
        Enable_RadioButton(LA_28b_b);
        Enable_RadioButton(LA_28b_c);



        Enable_RadioButton(LA_29a_v);
        Enable_RadioButton(LA_29a_b);
        Enable_RadioButton(LA_29a_c);
        EnableControls(LA_29a_a);
        Enable_RadioButton(LA_29b_a);
        Enable_RadioButton(LA_29b_b);
        Enable_RadioButton(LA_29b_c);



        Enable_RadioButton(LA_30a_v);
        Enable_RadioButton(LA_30a_b);
        Enable_RadioButton(LA_30a_c);
        EnableControls(LA_30a_a);
        Enable_RadioButton(LA_30b_a);
        Enable_RadioButton(LA_30b_b);
        Enable_RadioButton(LA_30b_c);


        Enable_RadioButton(LA_31a_v);
        Enable_RadioButton(LA_31a_b);
        Enable_RadioButton(LA_31a_c);
        EnableControls(LA_31a_a);
        Enable_RadioButton(LA_31b_a);
        Enable_RadioButton(LA_31b_b);
        Enable_RadioButton(LA_31b_c);


        Enable_RadioButton(LA_32a_v);
        Enable_RadioButton(LA_32a_b);
        Enable_RadioButton(LA_32a_c);
        EnableControls(LA_32a_a);
        Enable_RadioButton(LA_32b_a);
        Enable_RadioButton(LA_32b_b);
        Enable_RadioButton(LA_32b_c);


        Enable_RadioButton(LA_33a_v);
        Enable_RadioButton(LA_33a_b);
        Enable_RadioButton(LA_33a_c);
        EnableControls(LA_33a_a);
        Enable_RadioButton(LA_33b_a);
        Enable_RadioButton(LA_33b_b);
        Enable_RadioButton(LA_33b_c);


        Enable_RadioButton(LA_34a_v);
        Enable_RadioButton(LA_34a_b);
        Enable_RadioButton(LA_34a_c);
        EnableControls(LA_34a_a);
        Enable_RadioButton(LA_34b_a);
        Enable_RadioButton(LA_34b_b);
        Enable_RadioButton(LA_34b_c);


        Enable_RadioButton(LA_35a_v);
        Enable_RadioButton(LA_35a_b);
        Enable_RadioButton(LA_35a_c);
        EnableControls(LA_35a_a);
        Enable_RadioButton(LA_35b_a);
        Enable_RadioButton(LA_35b_b);
        Enable_RadioButton(LA_35b_c);


        Enable_RadioButton(LA_36a_v);
        Enable_RadioButton(LA_36a_b);
        Enable_RadioButton(LA_36a_c);
        EnableControls(LA_36a_a);
        Enable_RadioButton(LA_36b_a);
        Enable_RadioButton(LA_36b_b);
        Enable_RadioButton(LA_36b_c);


        Enable_RadioButton(LA_37a_v);
        Enable_RadioButton(LA_37a_b);
        Enable_RadioButton(LA_37a_c);
        EnableControls(LA_37a_a);
        Enable_RadioButton(LA_37b_a);
        Enable_RadioButton(LA_37b_b);
        Enable_RadioButton(LA_37b_c);


        Enable_RadioButton(LA_38a_v);
        Enable_RadioButton(LA_38a_b);
        Enable_RadioButton(LA_38a_c);
        EnableControls(LA_38a_a);
        Enable_RadioButton(LA_38b_a);
        Enable_RadioButton(LA_38b_b);
        Enable_RadioButton(LA_38b_c);


        Enable_RadioButton(LA_39a_v);
        Enable_RadioButton(LA_39a_b);
        Enable_RadioButton(LA_39a_c);
        EnableControls(LA_39a_a);
        Enable_RadioButton(LA_39b_a);
        Enable_RadioButton(LA_39b_b);
        Enable_RadioButton(LA_39b_c);



        Enable_RadioButton(LA_40a_v);
        Enable_RadioButton(LA_40a_b);
        Enable_RadioButton(LA_40a_c);
        EnableControls(LA_40a_a);
        Enable_RadioButton(LA_40b_a);
        Enable_RadioButton(LA_40b_b);
        Enable_RadioButton(LA_40b_c);


        Enable_RadioButton(LA_41a_v);
        Enable_RadioButton(LA_41a_b);
        Enable_RadioButton(LA_41a_c);
        EnableControls(LA_41a_a);
        Enable_RadioButton(LA_41b_a);
        Enable_RadioButton(LA_41b_b);
        Enable_RadioButton(LA_41b_c);


        Enable_RadioButton(LA_42a_v);
        Enable_RadioButton(LA_42a_b);
        Enable_RadioButton(LA_42a_c);
        EnableControls(LA_42a_a);
        Enable_RadioButton(LA_42b_a);
        Enable_RadioButton(LA_42b_b);
        Enable_RadioButton(LA_42b_c);


        Enable_RadioButton(LA_43a_v);
        Enable_RadioButton(LA_43a_b);
        Enable_RadioButton(LA_43a_c);
        EnableControls(LA_43a_a);
        Enable_RadioButton(LA_43b_a);
        Enable_RadioButton(LA_43b_b);
        Enable_RadioButton(LA_43b_c);


        Enable_RadioButton(LA_44a_v);
        Enable_RadioButton(LA_44a_b);
        Enable_RadioButton(LA_44a_c);
        EnableControls(LA_44a_a);
        Enable_RadioButton(LA_44b_a);
        Enable_RadioButton(LA_44b_b);
        Enable_RadioButton(LA_44b_c);


        Enable_RadioButton(LA_45a_v);
        Enable_RadioButton(LA_45a_b);
        Enable_RadioButton(LA_45a_c);
        EnableControls(LA_45a_a);
        Enable_RadioButton(LA_45b_a);
        Enable_RadioButton(LA_45b_b);
        Enable_RadioButton(LA_45b_c);


        Enable_RadioButton(LA_46a_v);
        Enable_RadioButton(LA_46a_b);
        Enable_RadioButton(LA_46a_c);
        EnableControls(LA_46a_a);
        Enable_RadioButton(LA_46b_a);
        Enable_RadioButton(LA_46b_b);
        Enable_RadioButton(LA_46b_c);


        Enable_RadioButton(LA_47a_v);
        Enable_RadioButton(LA_47a_b);
        Enable_RadioButton(LA_47a_c);
        EnableControls(LA_47a_a);
        Enable_RadioButton(LA_47b_a);
        Enable_RadioButton(LA_47b_b);
        Enable_RadioButton(LA_47b_c);


        Enable_RadioButton(LA_48a_v);
        Enable_RadioButton(LA_48a_b);
        Enable_RadioButton(LA_48a_c);
        EnableControls(LA_48a_a);
        Enable_RadioButton(LA_48b_a);
        Enable_RadioButton(LA_48b_b);
        Enable_RadioButton(LA_48b_c);


        Enable_RadioButton(LA_49a_v);
        Enable_RadioButton(LA_49a_b);
        Enable_RadioButton(LA_49a_c);
        EnableControls(LA_49a_a);
        Enable_RadioButton(LA_49b_a);
        Enable_RadioButton(LA_49b_b);
        Enable_RadioButton(LA_49b_c);


        Enable_RadioButton(LA_50a_v);
        Enable_RadioButton(LA_50a_b);
        Enable_RadioButton(LA_50a_c);
        EnableControls(LA_50a_a);
        Enable_RadioButton(LA_50b_a);
        Enable_RadioButton(LA_50b_b);
        Enable_RadioButton(LA_50b_c);


        Enable_RadioButton(LA_51a_v);
        Enable_RadioButton(LA_51a_b);
        Enable_RadioButton(LA_51a_c);
        EnableControls(LA_51a_a);
        Enable_RadioButton(LA_51b_a);
        Enable_RadioButton(LA_51b_b);
        Enable_RadioButton(LA_51b_c);


        Enable_RadioButton(LA_52a_v);
        Enable_RadioButton(LA_52a_b);
        Enable_RadioButton(LA_52a_c);
        EnableControls(LA_52a_a);
        Enable_RadioButton(LA_52b_a);
        Enable_RadioButton(LA_52b_b);
        Enable_RadioButton(LA_52b_c);
    }

    private void DisableSensitivity_BloodCulture()
    {
        DisableControls1(LA_18);


        Disable_RadioButton_Sensitivity(LA_20a_v);
        Disable_RadioButton_Sensitivity(LA_20a_b);
        Disable_RadioButton_Sensitivity(LA_20a_c);
        DisableControls1(LA_20a_a);
        Disable_RadioButton_Sensitivity(LA_20b_a);
        Disable_RadioButton_Sensitivity(LA_20b_b);
        Disable_RadioButton_Sensitivity(LA_20b_c);


        Disable_RadioButton_Sensitivity(LA_21a_v);
        Disable_RadioButton_Sensitivity(LA_21a_b);
        Disable_RadioButton_Sensitivity(LA_21a_c);
        DisableControls1(LA_21a_a);
        Disable_RadioButton_Sensitivity(LA_21b_a);
        Disable_RadioButton_Sensitivity(LA_21b_b);
        Disable_RadioButton_Sensitivity(LA_21b_c);


        Disable_RadioButton_Sensitivity(LA_22a_v);
        Disable_RadioButton_Sensitivity(LA_22a_b);
        Disable_RadioButton_Sensitivity(LA_22a_c);
        DisableControls1(LA_22a_a);
        Disable_RadioButton_Sensitivity(LA_22b_a);
        Disable_RadioButton_Sensitivity(LA_22b_b);
        Disable_RadioButton_Sensitivity(LA_22b_c);


        Disable_RadioButton_Sensitivity(LA_23a_v);
        Disable_RadioButton_Sensitivity(LA_23a_b);
        Disable_RadioButton_Sensitivity(LA_23a_c);
        DisableControls1(LA_23a_a);
        Disable_RadioButton_Sensitivity(LA_23b_a);
        Disable_RadioButton_Sensitivity(LA_23b_b);
        Disable_RadioButton_Sensitivity(LA_23b_c);


        Disable_RadioButton_Sensitivity(LA_24a_v);
        Disable_RadioButton_Sensitivity(LA_24a_b);
        Disable_RadioButton_Sensitivity(LA_24a_c);
        DisableControls1(LA_24a_a);
        Disable_RadioButton_Sensitivity(LA_24b_a);
        Disable_RadioButton_Sensitivity(LA_24b_b);
        Disable_RadioButton_Sensitivity(LA_24b_c);


        Disable_RadioButton_Sensitivity(LA_25a_v);
        Disable_RadioButton_Sensitivity(LA_25a_b);
        Disable_RadioButton_Sensitivity(LA_25a_c);
        DisableControls1(LA_25a_a);
        Disable_RadioButton_Sensitivity(LA_25b_a);
        Disable_RadioButton_Sensitivity(LA_25b_b);
        Disable_RadioButton_Sensitivity(LA_25b_c);


        Disable_RadioButton_Sensitivity(LA_26a_v);
        Disable_RadioButton_Sensitivity(LA_26a_b);
        Disable_RadioButton_Sensitivity(LA_26a_c);
        DisableControls1(LA_26a_a);
        Disable_RadioButton_Sensitivity(LA_26b_a);
        Disable_RadioButton_Sensitivity(LA_26b_b);
        Disable_RadioButton_Sensitivity(LA_26b_c);


        Disable_RadioButton_Sensitivity(LA_27a_v);
        Disable_RadioButton_Sensitivity(LA_27a_b);
        Disable_RadioButton_Sensitivity(LA_27a_c);
        DisableControls1(LA_27a_a);
        Disable_RadioButton_Sensitivity(LA_27b_a);
        Disable_RadioButton_Sensitivity(LA_27b_b);
        Disable_RadioButton_Sensitivity(LA_27b_c);


        Disable_RadioButton_Sensitivity(LA_28a_v);
        Disable_RadioButton_Sensitivity(LA_28a_b);
        Disable_RadioButton_Sensitivity(LA_28a_c);
        DisableControls1(LA_28a_a);
        Disable_RadioButton_Sensitivity(LA_28b_a);
        Disable_RadioButton_Sensitivity(LA_28b_b);
        Disable_RadioButton_Sensitivity(LA_28b_c);



        Disable_RadioButton_Sensitivity(LA_29a_v);
        Disable_RadioButton_Sensitivity(LA_29a_b);
        Disable_RadioButton_Sensitivity(LA_29a_c);
        DisableControls1(LA_29a_a);
        Disable_RadioButton_Sensitivity(LA_29b_a);
        Disable_RadioButton_Sensitivity(LA_29b_b);
        Disable_RadioButton_Sensitivity(LA_29b_c);



        Disable_RadioButton_Sensitivity(LA_30a_v);
        Disable_RadioButton_Sensitivity(LA_30a_b);
        Disable_RadioButton_Sensitivity(LA_30a_c);
        DisableControls1(LA_30a_a);
        Disable_RadioButton_Sensitivity(LA_30b_a);
        Disable_RadioButton_Sensitivity(LA_30b_b);
        Disable_RadioButton_Sensitivity(LA_30b_c);


        Disable_RadioButton_Sensitivity(LA_31a_v);
        Disable_RadioButton_Sensitivity(LA_31a_b);
        Disable_RadioButton_Sensitivity(LA_31a_c);
        DisableControls1(LA_31a_a);
        Disable_RadioButton_Sensitivity(LA_31b_a);
        Disable_RadioButton_Sensitivity(LA_31b_b);
        Disable_RadioButton_Sensitivity(LA_31b_c);


        Disable_RadioButton_Sensitivity(LA_32a_v);
        Disable_RadioButton_Sensitivity(LA_32a_b);
        Disable_RadioButton_Sensitivity(LA_32a_c);
        DisableControls1(LA_32a_a);
        Disable_RadioButton_Sensitivity(LA_32b_a);
        Disable_RadioButton_Sensitivity(LA_32b_b);
        Disable_RadioButton_Sensitivity(LA_32b_c);


        Disable_RadioButton_Sensitivity(LA_33a_v);
        Disable_RadioButton_Sensitivity(LA_33a_b);
        Disable_RadioButton_Sensitivity(LA_33a_c);
        DisableControls1(LA_33a_a);
        Disable_RadioButton_Sensitivity(LA_33b_a);
        Disable_RadioButton_Sensitivity(LA_33b_b);
        Disable_RadioButton_Sensitivity(LA_33b_c);


        Disable_RadioButton_Sensitivity(LA_34a_v);
        Disable_RadioButton_Sensitivity(LA_34a_b);
        Disable_RadioButton_Sensitivity(LA_34a_c);
        DisableControls1(LA_34a_a);
        Disable_RadioButton_Sensitivity(LA_34b_a);
        Disable_RadioButton_Sensitivity(LA_34b_b);
        Disable_RadioButton_Sensitivity(LA_34b_c);


        Disable_RadioButton_Sensitivity(LA_35a_v);
        Disable_RadioButton_Sensitivity(LA_35a_b);
        Disable_RadioButton_Sensitivity(LA_35a_c);
        DisableControls1(LA_35a_a);
        Disable_RadioButton_Sensitivity(LA_35b_a);
        Disable_RadioButton_Sensitivity(LA_35b_b);
        Disable_RadioButton_Sensitivity(LA_35b_c);


        Disable_RadioButton_Sensitivity(LA_36a_v);
        Disable_RadioButton_Sensitivity(LA_36a_b);
        Disable_RadioButton_Sensitivity(LA_36a_c);
        DisableControls1(LA_36a_a);
        Disable_RadioButton_Sensitivity(LA_36b_a);
        Disable_RadioButton_Sensitivity(LA_36b_b);
        Disable_RadioButton_Sensitivity(LA_36b_c);


        Disable_RadioButton_Sensitivity(LA_37a_v);
        Disable_RadioButton_Sensitivity(LA_37a_b);
        Disable_RadioButton_Sensitivity(LA_37a_c);
        DisableControls1(LA_37a_a);
        Disable_RadioButton_Sensitivity(LA_37b_a);
        Disable_RadioButton_Sensitivity(LA_37b_b);
        Disable_RadioButton_Sensitivity(LA_37b_c);


        Disable_RadioButton_Sensitivity(LA_38a_v);
        Disable_RadioButton_Sensitivity(LA_38a_b);
        Disable_RadioButton_Sensitivity(LA_38a_c);
        DisableControls1(LA_38a_a);
        Disable_RadioButton_Sensitivity(LA_38b_a);
        Disable_RadioButton_Sensitivity(LA_38b_b);
        Disable_RadioButton_Sensitivity(LA_38b_c);


        Disable_RadioButton_Sensitivity(LA_39a_v);
        Disable_RadioButton_Sensitivity(LA_39a_b);
        Disable_RadioButton_Sensitivity(LA_39a_c);
        DisableControls1(LA_39a_a);
        Disable_RadioButton_Sensitivity(LA_39b_a);
        Disable_RadioButton_Sensitivity(LA_39b_b);
        Disable_RadioButton_Sensitivity(LA_39b_c);



        Disable_RadioButton_Sensitivity(LA_40a_v);
        Disable_RadioButton_Sensitivity(LA_40a_b);
        Disable_RadioButton_Sensitivity(LA_40a_c);
        DisableControls1(LA_40a_a);
        Disable_RadioButton_Sensitivity(LA_40b_a);
        Disable_RadioButton_Sensitivity(LA_40b_b);
        Disable_RadioButton_Sensitivity(LA_40b_c);


        Disable_RadioButton_Sensitivity(LA_41a_v);
        Disable_RadioButton_Sensitivity(LA_41a_b);
        Disable_RadioButton_Sensitivity(LA_41a_c);
        DisableControls1(LA_41a_a);
        Disable_RadioButton_Sensitivity(LA_41b_a);
        Disable_RadioButton_Sensitivity(LA_41b_b);
        Disable_RadioButton_Sensitivity(LA_41b_c);


        Disable_RadioButton_Sensitivity(LA_42a_v);
        Disable_RadioButton_Sensitivity(LA_42a_b);
        Disable_RadioButton_Sensitivity(LA_42a_c);
        DisableControls1(LA_42a_a);
        Disable_RadioButton_Sensitivity(LA_42b_a);
        Disable_RadioButton_Sensitivity(LA_42b_b);
        Disable_RadioButton_Sensitivity(LA_42b_c);


        Disable_RadioButton_Sensitivity(LA_43a_v);
        Disable_RadioButton_Sensitivity(LA_43a_b);
        Disable_RadioButton_Sensitivity(LA_43a_c);
        DisableControls1(LA_43a_a);
        Disable_RadioButton_Sensitivity(LA_43b_a);
        Disable_RadioButton_Sensitivity(LA_43b_b);
        Disable_RadioButton_Sensitivity(LA_43b_c);


        Disable_RadioButton_Sensitivity(LA_44a_v);
        Disable_RadioButton_Sensitivity(LA_44a_b);
        Disable_RadioButton_Sensitivity(LA_44a_c);
        DisableControls1(LA_44a_a);
        Disable_RadioButton_Sensitivity(LA_44b_a);
        Disable_RadioButton_Sensitivity(LA_44b_b);
        Disable_RadioButton_Sensitivity(LA_44b_c);


        Disable_RadioButton_Sensitivity(LA_45a_v);
        Disable_RadioButton_Sensitivity(LA_45a_b);
        Disable_RadioButton_Sensitivity(LA_45a_c);
        DisableControls1(LA_45a_a);
        Disable_RadioButton_Sensitivity(LA_45b_a);
        Disable_RadioButton_Sensitivity(LA_45b_b);
        Disable_RadioButton_Sensitivity(LA_45b_c);


        Disable_RadioButton_Sensitivity(LA_46a_v);
        Disable_RadioButton_Sensitivity(LA_46a_b);
        Disable_RadioButton_Sensitivity(LA_46a_c);
        DisableControls1(LA_46a_a);
        Disable_RadioButton_Sensitivity(LA_46b_a);
        Disable_RadioButton_Sensitivity(LA_46b_b);
        Disable_RadioButton_Sensitivity(LA_46b_c);


        Disable_RadioButton_Sensitivity(LA_47a_v);
        Disable_RadioButton_Sensitivity(LA_47a_b);
        Disable_RadioButton_Sensitivity(LA_47a_c);
        DisableControls1(LA_47a_a);
        Disable_RadioButton_Sensitivity(LA_47b_a);
        Disable_RadioButton_Sensitivity(LA_47b_b);
        Disable_RadioButton_Sensitivity(LA_47b_c);


        Disable_RadioButton_Sensitivity(LA_48a_v);
        Disable_RadioButton_Sensitivity(LA_48a_b);
        Disable_RadioButton_Sensitivity(LA_48a_c);
        DisableControls1(LA_48a_a);
        Disable_RadioButton_Sensitivity(LA_48b_a);
        Disable_RadioButton_Sensitivity(LA_48b_b);
        Disable_RadioButton_Sensitivity(LA_48b_c);


        Disable_RadioButton_Sensitivity(LA_49a_v);
        Disable_RadioButton_Sensitivity(LA_49a_b);
        Disable_RadioButton_Sensitivity(LA_49a_c);
        DisableControls1(LA_49a_a);
        Disable_RadioButton_Sensitivity(LA_49b_a);
        Disable_RadioButton_Sensitivity(LA_49b_b);
        Disable_RadioButton_Sensitivity(LA_49b_c);


        Disable_RadioButton_Sensitivity(LA_50a_v);
        Disable_RadioButton_Sensitivity(LA_50a_b);
        Disable_RadioButton_Sensitivity(LA_50a_c);
        DisableControls1(LA_50a_a);
        Disable_RadioButton_Sensitivity(LA_50b_a);
        Disable_RadioButton_Sensitivity(LA_50b_b);
        Disable_RadioButton_Sensitivity(LA_50b_c);


        Disable_RadioButton_Sensitivity(LA_51a_v);
        Disable_RadioButton_Sensitivity(LA_51a_b);
        Disable_RadioButton_Sensitivity(LA_51a_c);
        DisableControls1(LA_51a_a);
        Disable_RadioButton_Sensitivity(LA_51b_a);
        Disable_RadioButton_Sensitivity(LA_51b_b);
        Disable_RadioButton_Sensitivity(LA_51b_c);


        Disable_RadioButton_Sensitivity(LA_52a_v);
        Disable_RadioButton_Sensitivity(LA_52a_b);
        Disable_RadioButton_Sensitivity(LA_52a_c);
        DisableControls1(LA_52a_a);
        Disable_RadioButton_Sensitivity(LA_52b_a);
        Disable_RadioButton_Sensitivity(LA_52b_b);
        Disable_RadioButton_Sensitivity(LA_52b_c);

    }


    protected void btnAddMore_Click(object sender, EventArgs e)
    {
        CConnection cn = null;

        try
        {
            TextBox txtOrganismName = (TextBox)dg_BloodCulture.FooterRow.FindControl("insertorganismName");
            TextBox txtcomment = (TextBox)dg_BloodCulture.FooterRow.FindControl("insertComments");


            if (string.IsNullOrEmpty(txtOrganismName.Text))
            {
                string message = "alert('Organism name required');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
                txtOrganismName.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtcomment.Text))
            {
                string message = "alert('Comments required');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
                txtcomment.Focus();
                return;
            }


            fillGrid_BloodCulture_array(txtOrganismName.Text, txtcomment.Text);


            //string sno = getSNO_Organism();

            //if (sno == "")
            //{
            //    sno = "1";
            //}
            //else
            //{
            //    sno = Convert.ToString(Convert.ToInt32(sno) + 1);
            //}


            //cn = new CConnection();
            //SqlCommand cmd = new SqlCommand("insert into tblorganism (sno, screeningID, organismName, comment) values('" + sno + "', '" + la_sno.Text + "', '" + txtOrganismName.Text + "', '" + txtcomment.Text + "')", cn.cn);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);


            //fillGrid_BloodCulture();
        }

        catch (Exception ex)
        {

        }

        finally
        {

        }
    }


    private string getSNO_Organism()
    {
        string sno = "0";

        CConnection cn = new CConnection();

        SqlDataAdapter da = new SqlDataAdapter("select max(sno) sno from tblorganism where screeningID = '" + la_sno.Text + "'", cn.cn);
        DataSet ds = new DataSet();
        da.Fill(ds);

        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    sno = ds.Tables[0].Rows[0]["sno"].ToString();
                }
            }
        }

        return sno;
    }


    protected void btnAddMore1_Click(object sender, EventArgs e)
    {
        CConnection cn = null;

        try
        {
            TextBox txtOrganismName = (TextBox)dg_BloodCulture.Controls[0].Controls[0].FindControl("addOrganism");
            TextBox txtcomment = (TextBox)dg_BloodCulture.Controls[0].Controls[0].FindControl("addComments");


            if (string.IsNullOrEmpty(txtOrganismName.Text))
            {
                string message = "alert('Organism name required');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
                txtOrganismName.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtcomment.Text))
            {
                string message = "alert('Comments required');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
                txtcomment.Focus();
                return;
            }



            fillGrid_BloodCulture_array(txtOrganismName.Text, txtcomment.Text);


            //string sno = getSNO_Organism();

            //if (sno == "")
            //    sno = "1";


            //cn = new CConnection();
            //SqlCommand cmd = new SqlCommand("insert into tblorganism (sno, screeningID, organismName, comment) values('" + sno + "', '" + la_sno.Text + "', '" + txtOrganismName.Text + "', '" + txtcomment.Text + "')", cn.cn);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);


            //fillGrid_BloodCulture();
        }

        catch (Exception ex)
        {

        }

        finally
        {

        }
    }


    private void FillDropDown_BloodCulture_Positive()
    {
        try
        {
            ddl_BloodCulture.Items.Add(new ListItem("Select Organism", "0"));
            ddl_BloodCulture.Items.Add(new ListItem("Escherichia coli", "1"));
            ddl_BloodCulture.Items.Add(new ListItem("Klebsiella pneumoniae", "2"));
            ddl_BloodCulture.Items.Add(new ListItem("Klebsiella species", "3"));
            ddl_BloodCulture.Items.Add(new ListItem("Acinetobacter baumannii", "4"));
            ddl_BloodCulture.Items.Add(new ListItem("Acinetobacter species", "5"));
            ddl_BloodCulture.Items.Add(new ListItem("Salmonella species", "6"));
            ddl_BloodCulture.Items.Add(new ListItem("Salmonella typhi", "7"));
            ddl_BloodCulture.Items.Add(new ListItem("Salmonella paratyphi A", "8"));
            ddl_BloodCulture.Items.Add(new ListItem("Salmonella paratyphi B", "9"));
            ddl_BloodCulture.Items.Add(new ListItem("Serratia species", "10"));
            ddl_BloodCulture.Items.Add(new ListItem("Serratia marcescens", "11"));
            ddl_BloodCulture.Items.Add(new ListItem("Serratia liquefaciens", "12"));
            ddl_BloodCulture.Items.Add(new ListItem("Staphylococcus epidermidis", "13"));
            ddl_BloodCulture.Items.Add(new ListItem("Staphylococcus saprophyticus", "14"));
            ddl_BloodCulture.Items.Add(new ListItem("Staphylococcus species", "15"));
            ddl_BloodCulture.Items.Add(new ListItem("Micrococcus specie", "16"));
            ddl_BloodCulture.Items.Add(new ListItem("Streptococcus species", "17"));
            ddl_BloodCulture.Items.Add(new ListItem("Streptococcus pyogenes (group A Streptococcus)", "18"));
            ddl_BloodCulture.Items.Add(new ListItem("Streptococcus pneumoniae", "19"));
            ddl_BloodCulture.Items.Add(new ListItem("Streptococcus mitis", "20"));
            ddl_BloodCulture.Items.Add(new ListItem("Campylobacter species", "21"));
            ddl_BloodCulture.Items.Add(new ListItem("Campylobacter jejuni", "22"));
            ddl_BloodCulture.Items.Add(new ListItem("Enterococcus species", "23"));
            ddl_BloodCulture.Items.Add(new ListItem("Corynebacterium species", "24"));
            ddl_BloodCulture.Items.Add(new ListItem("Burkholderia cepacia", "25"));
            ddl_BloodCulture.Items.Add(new ListItem("Neisseria gonorrhoeae", "26"));
            ddl_BloodCulture.Items.Add(new ListItem("Candida species", "27"));
            ddl_BloodCulture.Items.Add(new ListItem("Citrobacter freundii", "28"));
            ddl_BloodCulture.Items.Add(new ListItem("Citrobacter species", "29"));
            ddl_BloodCulture.Items.Add(new ListItem("Bacillus species", "30"));
            ddl_BloodCulture.Items.Add(new ListItem("Others", "32"));
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Exception Error", "alert('" + ex.Message.Replace("'", "") + "')", false);
        }

        finally
        {

        }
    }



    private void FillDropDown_BloodCulture_Negative()
    {
        try
        {
            ddl_BloodCulture.Items.Add(new ListItem("No growth after 07 days", "31"));
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Exception Error", "alert('" + ex.Message.Replace("'", "") + "')", false);
        }

        finally
        {

        }
    }



    protected void BloodCulture_Multiple_Yes_CheckedChanged(object sender, EventArgs e)
    {
        if (BloodCulture_Multiple_Yes.Checked)
        {
            DataTable dt = new DataTable();

            cntl_Blood_Organism.Visible = true;
            dg_BloodCulture.Visible = true;

            dg_BloodCulture.DataSource = dt;
            dg_BloodCulture.DataBind();
        }
    }

    protected void BloodCulture_Multiple_No_CheckedChanged(object sender, EventArgs e)
    {
        if (BloodCulture_Multiple_No.Checked)
        {
            cntl_Blood_Organism.Visible = false;
            dg_BloodCulture.Visible = false;
        }
    }

    protected void dg_BloodCulture_RowEditing(object sender, GridViewEditEventArgs e)
    {
        dg_BloodCulture.EditIndex = e.NewEditIndex;
        //fillGrid_BloodCulture();
    }

    protected void dg_BloodCulture_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        dg_BloodCulture.EditIndex = -1;
        //fillGrid_BloodCulture();
    }

    protected void dg_BloodCulture_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        CConnection cn = null;

        try
        {
            TextBox txtOrganismName = (TextBox)dg_BloodCulture.Rows[e.RowIndex].Cells[1].FindControl("editorganismName");
            TextBox txtcomment = (TextBox)dg_BloodCulture.Rows[e.RowIndex].Cells[1].FindControl("editComments");


            if (string.IsNullOrEmpty(txtOrganismName.Text))
            {
                string message = "alert('Organism name required');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
                txtOrganismName.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtcomment.Text))
            {
                string message = "alert('Comments required');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
                txtcomment.Focus();
                return;
            }

            if (ViewState["editid"] != null)
            {
                dt_bloodculture.Rows[e.RowIndex]["organismName"] = txtOrganismName.Text;
                dt_bloodculture.Rows[e.RowIndex]["comment"] = txtcomment.Text;
                dt_bloodculture.AcceptChanges();


                //cn = new CConnection();
                //SqlCommand cmd = new SqlCommand("update tblorganism set organismName = '" + txtOrganismName.Text + "', comment = '" + txtcomment.Text + "' where id = '" + ViewState["editid"] + "'", cn.cn);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
            }

            ViewState["editid"] = null;

            dg_BloodCulture.EditIndex = -1;
            dg_BloodCulture.DataSource = dt_bloodculture;
            dg_BloodCulture.DataBind();

            //fillGrid_BloodCulture();
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Exception Error", "alert('" + ex.Message.Replace("'", "") + "')", false);
        }

        finally
        {

        }
    }

    protected void dg_BloodCulture_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            dg_BloodCulture.Columns[0].Visible = true;
            ViewState["editid"] = dg_BloodCulture.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            dg_BloodCulture.Columns[0].Visible = false;
        }
    }

    protected void dg_BloodCulture_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //CConnection cn = null;

        try
        {

            dt_bloodculture.Rows[e.RowIndex].Delete();
            dt_bloodculture.AcceptChanges();


            //cn = new CConnection();
            //SqlCommand cmd = new SqlCommand("delete tblorganism where id = '" + dg_BloodCulture.Rows[e.RowIndex].Cells[0].Text + "'", cn.cn);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);


            ViewState["delid"] = null;

            dg_BloodCulture.EditIndex = -1;
            dg_BloodCulture.DataSource = dt_bloodculture;
            dg_BloodCulture.DataBind();
            //fillGrid_BloodCulture();
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Exception Error", "alert('" + ex.Message.Replace("'", "") + "')", false);
        }

        finally
        {

        }
    }

}