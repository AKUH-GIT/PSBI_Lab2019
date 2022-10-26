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

public partial class sample_results : System.Web.UI.Page
{
    public List<CountryInfo> CountryInformation { get; set; }
    public List<SampleResults> SampleResultsInfo { get; set; }

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
        cmdSave.OnClientClick = "return ValidateForm();";

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
            if (Request.Cookies["labid"].Value == "2")
            {
                EnableControls(LA_01);
                EnableControls(LA_02);

                Disable_RadioButton(LA_03_v);
                Disable_RadioButton(LA_03_b);
                Disable_RadioButton(LA_03_c);
                DisableControls(LA_03_a);


                Disable_RadioButton(LA_04_v);
                Disable_RadioButton(LA_04_b);
                Disable_RadioButton(LA_04_c);
                DisableControls(LA_04_a);


                Disable_RadioButton(LA_05_v);
                Disable_RadioButton(LA_05_b);
                Disable_RadioButton(LA_05_c);
                DisableControls(LA_05_a);


                Disable_RadioButton(LA_06_v);
                Disable_RadioButton(LA_06_b);
                Disable_RadioButton(LA_06_c);
                DisableControls(LA_06_a);


                Disable_RadioButton(LA_07_v);
                Disable_RadioButton(LA_07_b);
                Disable_RadioButton(LA_07_c);
                DisableControls(LA_07_a);


                Disable_RadioButton(LA_08_v);
                Disable_RadioButton(LA_08_b);
                Disable_RadioButton(LA_08_c);
                DisableControls(LA_08_a);


                Disable_RadioButton(LA_09_v);
                Disable_RadioButton(LA_09_b);
                Disable_RadioButton(LA_09_c);
                DisableControls(LA_09_a);


                Disable_RadioButton(LA_10_v);
                Disable_RadioButton(LA_10_b);
                Disable_RadioButton(LA_10_c);
                DisableControls(LA_10_a);


                Disable_RadioButton(LA_11_v);
                Disable_RadioButton(LA_11_b);
                Disable_RadioButton(LA_11_c);
                DisableControls(LA_11_a);


                Disable_RadioButton(LA_12_v);
                Disable_RadioButton(LA_12_b);
                Disable_RadioButton(LA_12_c);
                DisableControls(LA_12_a);


                Disable_RadioButton(LA_13_v);
                Disable_RadioButton(LA_13_b);
                Disable_RadioButton(LA_13_c);
                DisableControls(LA_13_a);


                Disable_RadioButton(LA_14_v);
                Disable_RadioButton(LA_14_b);
                Disable_RadioButton(LA_14_c);
                DisableControls(LA_14_a);


                Disable_RadioButton(LA_15_v);
                Disable_RadioButton(LA_15_b);
                Disable_RadioButton(LA_15_c);
                DisableControls(LA_15_a);


                Disable_RadioButton(LA_16_v);
                Disable_RadioButton(LA_16_b);
                Disable_RadioButton(LA_16_c);
                DisableControls(LA_16_a);

                DisableControls(LA_17);
                DisableControls(LA_18);
                DisableControls(LA_19);


                Disable_RadioButton(LA_20a_v);
                Disable_RadioButton(LA_20a_b);
                Disable_RadioButton(LA_20a_c);
                DisableControls(LA_20a_a);
                Disable_RadioButton(LA_20b_a);
                Disable_RadioButton(LA_20b_b);
                Disable_RadioButton(LA_20b_c);


                Disable_RadioButton(LA_21a_v);
                Disable_RadioButton(LA_21a_b);
                Disable_RadioButton(LA_21a_c);
                DisableControls(LA_21a_a);
                Disable_RadioButton(LA_21b_a);
                Disable_RadioButton(LA_21b_b);
                Disable_RadioButton(LA_21b_c);


                Disable_RadioButton(LA_22a_v);
                Disable_RadioButton(LA_22a_b);
                Disable_RadioButton(LA_22a_c);
                DisableControls(LA_22a_a);
                Disable_RadioButton(LA_22b_a);
                Disable_RadioButton(LA_22b_b);
                Disable_RadioButton(LA_22b_c);


                Disable_RadioButton(LA_23a_v);
                Disable_RadioButton(LA_23a_b);
                Disable_RadioButton(LA_23a_c);
                DisableControls(LA_23a_a);
                Disable_RadioButton(LA_23b_a);
                Disable_RadioButton(LA_23b_b);
                Disable_RadioButton(LA_23b_c);


                Disable_RadioButton(LA_24a_v);
                Disable_RadioButton(LA_24a_b);
                Disable_RadioButton(LA_24a_c);
                DisableControls(LA_24a_a);
                Disable_RadioButton(LA_24b_a);
                Disable_RadioButton(LA_24b_b);
                Disable_RadioButton(LA_24b_c);


                Disable_RadioButton(LA_25a_v);
                Disable_RadioButton(LA_25a_b);
                Disable_RadioButton(LA_25a_c);
                DisableControls(LA_25a_a);
                Disable_RadioButton(LA_25b_a);
                Disable_RadioButton(LA_25b_b);
                Disable_RadioButton(LA_25b_c);


                Disable_RadioButton(LA_26a_v);
                Disable_RadioButton(LA_26a_b);
                Disable_RadioButton(LA_26a_c);
                DisableControls(LA_26a_a);
                Disable_RadioButton(LA_26b_a);
                Disable_RadioButton(LA_26b_b);
                Disable_RadioButton(LA_26b_c);


                Disable_RadioButton(LA_27a_v);
                Disable_RadioButton(LA_27a_b);
                Disable_RadioButton(LA_27a_c);
                DisableControls(LA_27a_a);
                Disable_RadioButton(LA_27b_a);
                Disable_RadioButton(LA_27b_b);
                Disable_RadioButton(LA_27b_c);


                Disable_RadioButton(LA_28a_v);
                Disable_RadioButton(LA_28a_b);
                Disable_RadioButton(LA_28a_c);
                DisableControls(LA_28a_a);
                Disable_RadioButton(LA_28b_a);
                Disable_RadioButton(LA_28b_b);
                Disable_RadioButton(LA_28b_c);



                Disable_RadioButton(LA_29a_v);
                Disable_RadioButton(LA_29a_b);
                Disable_RadioButton(LA_29a_c);
                DisableControls(LA_29a_a);
                Disable_RadioButton(LA_29b_a);
                Disable_RadioButton(LA_29b_b);
                Disable_RadioButton(LA_29b_c);



                Disable_RadioButton(LA_30a_v);
                Disable_RadioButton(LA_30a_b);
                Disable_RadioButton(LA_30a_c);
                DisableControls(LA_30a_a);
                Disable_RadioButton(LA_30b_a);
                Disable_RadioButton(LA_30b_b);
                Disable_RadioButton(LA_30b_c);


                Disable_RadioButton(LA_31a_v);
                Disable_RadioButton(LA_31a_b);
                Disable_RadioButton(LA_31a_c);
                DisableControls(LA_31a_a);
                Disable_RadioButton(LA_31b_a);
                Disable_RadioButton(LA_31b_b);
                Disable_RadioButton(LA_31b_c);


                Disable_RadioButton(LA_32a_v);
                Disable_RadioButton(LA_32a_b);
                Disable_RadioButton(LA_32a_c);
                DisableControls(LA_32a_a);
                Disable_RadioButton(LA_32b_a);
                Disable_RadioButton(LA_32b_b);
                Disable_RadioButton(LA_32b_c);


                Disable_RadioButton(LA_33a_v);
                Disable_RadioButton(LA_33a_b);
                Disable_RadioButton(LA_33a_c);
                DisableControls(LA_33a_a);
                Disable_RadioButton(LA_33b_a);
                Disable_RadioButton(LA_33b_b);
                Disable_RadioButton(LA_33b_c);


                Disable_RadioButton(LA_34a_v);
                Disable_RadioButton(LA_34a_b);
                Disable_RadioButton(LA_34a_c);
                DisableControls(LA_34a_a);
                Disable_RadioButton(LA_34b_a);
                Disable_RadioButton(LA_34b_b);
                Disable_RadioButton(LA_34b_c);


                Disable_RadioButton(LA_35a_v);
                Disable_RadioButton(LA_35a_b);
                Disable_RadioButton(LA_35a_c);
                DisableControls(LA_35a_a);
                Disable_RadioButton(LA_35b_a);
                Disable_RadioButton(LA_35b_b);
                Disable_RadioButton(LA_35b_c);


                Disable_RadioButton(LA_36a_v);
                Disable_RadioButton(LA_36a_b);
                Disable_RadioButton(LA_36a_c);
                DisableControls(LA_36a_a);
                Disable_RadioButton(LA_36b_a);
                Disable_RadioButton(LA_36b_b);
                Disable_RadioButton(LA_36b_c);


                Disable_RadioButton(LA_37a_v);
                Disable_RadioButton(LA_37a_b);
                Disable_RadioButton(LA_37a_c);
                DisableControls(LA_37a_a);
                Disable_RadioButton(LA_37b_a);
                Disable_RadioButton(LA_37b_b);
                Disable_RadioButton(LA_37b_c);


                Disable_RadioButton(LA_38a_v);
                Disable_RadioButton(LA_38a_b);
                Disable_RadioButton(LA_38a_c);
                DisableControls(LA_38a_a);
                Disable_RadioButton(LA_38b_a);
                Disable_RadioButton(LA_38b_b);
                Disable_RadioButton(LA_38b_c);


                Disable_RadioButton(LA_39a_v);
                Disable_RadioButton(LA_39a_b);
                Disable_RadioButton(LA_39a_c);
                DisableControls(LA_39a_a);
                Disable_RadioButton(LA_39b_a);
                Disable_RadioButton(LA_39b_b);
                Disable_RadioButton(LA_39b_c);



                Disable_RadioButton(LA_40a_v);
                Disable_RadioButton(LA_40a_b);
                Disable_RadioButton(LA_40a_c);
                DisableControls(LA_40a_a);
                Disable_RadioButton(LA_40b_a);
                Disable_RadioButton(LA_40b_b);
                Disable_RadioButton(LA_40b_c);


                Disable_RadioButton(LA_41a_v);
                Disable_RadioButton(LA_41a_b);
                Disable_RadioButton(LA_41a_c);
                DisableControls(LA_41a_a);
                Disable_RadioButton(LA_41b_a);
                Disable_RadioButton(LA_41b_b);
                Disable_RadioButton(LA_41b_c);


                Disable_RadioButton(LA_42a_v);
                Disable_RadioButton(LA_42a_b);
                Disable_RadioButton(LA_42a_c);
                DisableControls(LA_42a_a);
                Disable_RadioButton(LA_42b_a);
                Disable_RadioButton(LA_42b_b);
                Disable_RadioButton(LA_42b_c);


                Disable_RadioButton(LA_43a_v);
                Disable_RadioButton(LA_43a_b);
                Disable_RadioButton(LA_43a_c);
                DisableControls(LA_43a_a);
                Disable_RadioButton(LA_43b_a);
                Disable_RadioButton(LA_43b_b);
                Disable_RadioButton(LA_43b_c);


                Disable_RadioButton(LA_44a_v);
                Disable_RadioButton(LA_44a_b);
                Disable_RadioButton(LA_44a_c);
                DisableControls(LA_44a_a);
                Disable_RadioButton(LA_44b_a);
                Disable_RadioButton(LA_44b_b);
                Disable_RadioButton(LA_44b_c);


                Disable_RadioButton(LA_45a_v);
                Disable_RadioButton(LA_45a_b);
                Disable_RadioButton(LA_45a_c);
                DisableControls(LA_45a_a);
                Disable_RadioButton(LA_45b_a);
                Disable_RadioButton(LA_45b_b);
                Disable_RadioButton(LA_45b_c);


                Disable_RadioButton(LA_46a_v);
                Disable_RadioButton(LA_46a_b);
                Disable_RadioButton(LA_46a_c);
                DisableControls(LA_46a_a);
                Disable_RadioButton(LA_46b_a);
                Disable_RadioButton(LA_46b_b);
                Disable_RadioButton(LA_46b_c);


                Disable_RadioButton(LA_47a_v);
                Disable_RadioButton(LA_47a_b);
                Disable_RadioButton(LA_47a_c);
                DisableControls(LA_47a_a);
                Disable_RadioButton(LA_47b_a);
                Disable_RadioButton(LA_47b_b);
                Disable_RadioButton(LA_47b_c);


                Disable_RadioButton(LA_48a_v);
                Disable_RadioButton(LA_48a_b);
                Disable_RadioButton(LA_48a_c);
                DisableControls(LA_48a_a);
                Disable_RadioButton(LA_48b_a);
                Disable_RadioButton(LA_48b_b);
                Disable_RadioButton(LA_48b_c);


                Disable_RadioButton(LA_49a_v);
                Disable_RadioButton(LA_49a_b);
                Disable_RadioButton(LA_49a_c);
                DisableControls(LA_49a_a);
                Disable_RadioButton(LA_49b_a);
                Disable_RadioButton(LA_49b_b);
                Disable_RadioButton(LA_49b_c);


                Disable_RadioButton(LA_50a_v);
                Disable_RadioButton(LA_50a_b);
                Disable_RadioButton(LA_50a_c);
                DisableControls(LA_50a_a);
                Disable_RadioButton(LA_50b_a);
                Disable_RadioButton(LA_50b_b);
                Disable_RadioButton(LA_50b_c);


                Disable_RadioButton(LA_51a_v);
                Disable_RadioButton(LA_51a_b);
                Disable_RadioButton(LA_51a_c);
                DisableControls(LA_51a_a);
                Disable_RadioButton(LA_51b_a);
                Disable_RadioButton(LA_51b_b);
                Disable_RadioButton(LA_51b_c);


                Disable_RadioButton(LA_52a_v);
                Disable_RadioButton(LA_52a_b);
                Disable_RadioButton(LA_52a_c);
                DisableControls(LA_52a_a);
                Disable_RadioButton(LA_52b_a);
                Disable_RadioButton(LA_52b_b);
                Disable_RadioButton(LA_52b_c);


                pnl_LA_01.Visible = true;
                pnl_LA_02.Visible = true;
                pnl_idrl.Visible = false;

            }
            else
            {
                DisableControls(LA_01);
                DisableControls(LA_02);


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

                EnableControls(LA_17);
                EnableControls(LA_18);
                EnableControls(LA_19);


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

        }

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


        CDBOperations obj_op = new CDBOperations();

        string var_LF_01 = "";
        string var_LF_02 = "";
        string var_LF_03 = "";
        string var_LF_04 = "";
        string var_LF_05 = "";
        string var_LF_06 = "";
        string var_LF_07 = "";


        string var_RF_01 = "";
        string var_RF_02 = "";
        string var_RF_03 = "";
        string var_RF_04 = "";


        string var_SE_01 = "";
        string var_SE_02 = "";
        string var_SE_03 = "";
        string var_SE_04 = "";


        string var_CS_01 = "";
        string var_CS_02 = "";
        string var_CS_03 = "";
        string var_CS_04 = "";
        string var_CS_05 = "";
        string var_CS_06 = "";
        string var_CS_07 = "";
        string var_CS_08 = "";
        string var_CS_09 = "";
        string var_CS_10 = "";


        string var_UR_01 = "";
        string var_UR_02 = "";
        string var_UR_03 = "";
        string var_UR_04 = "";
        string var_UR_05 = "";
        string var_UR_06 = "";
        string var_UR_07 = "";
        string var_UR_08 = "";
        string var_UR_10 = "";
        string var_UR_11 = "";
        string var_UR_12 = "";
        string var_UR_13 = "";
        string var_UR_14 = "";
        string var_UR_15 = "";
        string var_UR_16 = "";
        string var_UR_17 = "";
        string var_UR_18 = "";
        string var_UR_19 = "";
        string var_UR_20 = "";
        string var_UR_21 = "";

        string var_uc_01a = "";


        string var_uc_02a = "";
        string var_uc_03a = "";
        string var_uc_04a = "";
        string var_uc_05a = "";
        string var_uc_06a = "";
        string var_uc_07a = "";
        string var_uc_08a = "";
        string var_uc_09a = "";
        string var_uc_10a = "";
        string var_uc_11a = "";
        string var_uc_12a = "";
        string var_uc_13a = "";
        string var_uc_14a = "";
        string var_uc_15a = "";
        string var_uc_16a = "";
        string var_uc_17a = "";
        string var_uc_18a = "";
        string var_uc_19a = "";
        string var_uc_20a = "";
        string var_uc_21a = "";
        string var_uc_22a = "";
        string var_uc_23a = "";
        string var_uc_24a = "";
        string var_uc_25a = "";
        string var_uc_26a = "";
        string var_uc_27a = "";
        string var_uc_28a = "";
        string var_uc_29a = "";
        string var_uc_30a = "";
        string var_uc_31a = "";
        string var_uc_32a = "";
        string var_uc_33a = "";
        string var_uc_34a = "";
        string var_uc_35a = "";
        string var_uc_36a = "";
        string var_uc_37a = "";



        string var_uc_02b = "";
        string var_uc_03b = "";
        string var_uc_04b = "";
        string var_uc_05b = "";
        string var_uc_06b = "";
        string var_uc_07b = "";
        string var_uc_08b = "";
        string var_uc_09b = "";
        string var_uc_10b = "";
        string var_uc_11b = "";
        string var_uc_12b = "";
        string var_uc_13b = "";
        string var_uc_14b = "";
        string var_uc_15b = "";
        string var_uc_16b = "";
        string var_uc_17b = "";
        string var_uc_18b = "";
        string var_uc_19b = "";
        string var_uc_20b = "";
        string var_uc_21b = "";
        string var_uc_22b = "";
        string var_uc_23b = "";
        string var_uc_24b = "";
        string var_uc_25b = "";
        string var_uc_26b = "";
        string var_uc_27b = "";
        string var_uc_28b = "";
        string var_uc_29b = "";
        string var_uc_30b = "";
        string var_uc_31b = "";
        string var_uc_32b = "";
        string var_uc_33b = "";
        string var_uc_34b = "";
        string var_uc_35b = "";
        string var_uc_36b = "";
        string var_uc_37b = "";



        string var_LA_03_b = "";
        string var_LA_04_b = "";
        string var_LA_05_b = "";
        string var_LA_06_b = "";
        string var_LA_07_b = "";
        string var_LA_08_b = "";
        string var_LA_09_b = "";
        string var_LA_10_b = "";
        string var_LA_11_b = "";
        string var_LA_12_b = "";
        string var_LA_13_b = "";
        string var_LA_14_b = "";
        string var_LA_15_b = "";
        string var_LA_16_b = "";

        string var_LA_20a_b = "";
        string var_LA_21a_b = "";
        string var_LA_22a_b = "";
        string var_LA_23a_b = "";
        string var_LA_24a_b = "";
        string var_LA_25a_b = "";
        string var_LA_26a_b = "";
        string var_LA_27a_b = "";
        string var_LA_28a_b = "";
        string var_LA_29a_b = "";
        string var_LA_30a_b = "";
        string var_LA_31a_b = "";
        string var_LA_32a_b = "";
        string var_LA_33a_b = "";
        string var_LA_34a_b = "";
        string var_LA_35a_b = "";
        string var_LA_36a_b = "";
        string var_LA_37a_b = "";
        string var_LA_38a_b = "";
        string var_LA_39a_b = "";
        string var_LA_40a_b = "";
        string var_LA_41a_b = "";
        string var_LA_42a_b = "";
        string var_LA_43a_b = "";
        string var_LA_44a_b = "";
        string var_LA_45a_b = "";
        string var_LA_46a_b = "";
        string var_LA_47a_b = "";
        string var_LA_48a_b = "";
        string var_LA_49a_b = "";
        string var_LA_50a_b = "";
        string var_LA_51a_b = "";
        string var_LA_52a_b = "";


        var var_LA_20b_a = "";
        var var_LA_21b_a = "";
        var var_LA_22b_a = "";
        var var_LA_23b_a = "";
        var var_LA_24b_a = "";
        var var_LA_25b_a = "";
        var var_LA_26b_a = "";
        var var_LA_27b_a = "";
        var var_LA_28b_a = "";
        var var_LA_29b_a = "";
        var var_LA_30b_a = "";
        var var_LA_31b_a = "";
        var var_LA_32b_a = "";
        var var_LA_33b_a = "";
        var var_LA_34b_a = "";
        var var_LA_35b_a = "";
        var var_LA_36b_a = "";
        var var_LA_37b_a = "";
        var var_LA_38b_a = "";
        var var_LA_39b_a = "";
        var var_LA_40b_a = "";
        var var_LA_41b_a = "";
        var var_LA_42b_a = "";
        var var_LA_43b_a = "";
        var var_LA_44b_a = "";
        var var_LA_45b_a = "";
        var var_LA_46b_a = "";
        var var_LA_47b_a = "";
        var var_LA_48b_a = "";
        var var_LA_49b_a = "";
        var var_LA_50b_a = "";
        var var_LA_51b_a = "";
        var var_LA_52b_a = "";


        try
        {


            if (LA_03_b.Checked == true)
            {
                var_LA_03_b = "999";
            }
            else if (LA_03_c.Checked == true)
            {
                var_LA_03_b = "888";
            }



            if (LA_04_b.Checked == true)
            {
                var_LA_04_b = "999";
            }
            else if (LA_04_c.Checked == true)
            {
                var_LA_04_b = "888";
            }


            if (LA_05_b.Checked == true)
            {
                var_LA_05_b = "999";
            }
            else if (LA_05_c.Checked == true)
            {
                var_LA_05_b = "888";
            }


            if (LA_06_b.Checked == true)
            {
                var_LA_06_b = "999";
            }
            else if (LA_06_c.Checked == true)
            {
                var_LA_06_b = "888";
            }


            if (LA_07_b.Checked == true)
            {
                var_LA_07_b = "999";
            }
            else if (LA_07_c.Checked == true)
            {
                var_LA_07_b = "888";
            }


            if (LA_08_b.Checked == true)
            {
                var_LA_08_b = "999";
            }
            else if (LA_08_c.Checked == true)
            {
                var_LA_08_b = "888";
            }



            if (LA_09_b.Checked == true)
            {
                var_LA_09_b = "999";
            }
            else if (LA_09_c.Checked == true)
            {
                var_LA_09_b = "999";
            }


            if (LA_10_b.Checked == true)
            {
                var_LA_10_b = "999";
            }
            else if (LA_10_c.Checked == true)
            {
                var_LA_10_b = "888";
            }



            if (LA_11_b.Checked == true)
            {
                var_LA_11_b = "999";
            }
            else if (LA_11_c.Checked == true)
            {
                var_LA_11_b = "888";
            }


            if (LA_12_b.Checked == true)
            {
                var_LA_12_b = "999";
            }
            else if (LA_12_c.Checked == true)
            {
                var_LA_12_b = "888";
            }


            if (LA_13_b.Checked == true)
            {
                var_LA_13_b = "999";
            }
            else if (LA_13_c.Checked == true)
            {
                var_LA_13_b = "888";
            }


            if (LA_14_b.Checked == true)
            {
                var_LA_14_b = "999";
            }
            else if (LA_14_c.Checked == true)
            {
                var_LA_14_b = "888";
            }



            if (LA_15_b.Checked == true)
            {
                var_LA_15_b = "999";
            }
            else if (LA_15_c.Checked == true)
            {
                var_LA_15_b = "888";
            }


            if (LA_16_b.Checked == true)
            {
                var_LA_16_b = "999";
            }
            else if (LA_16_c.Checked == true)
            {
                var_LA_16_b = "888";
            }





            if (LF_01_b.Checked == true)
            {
                var_LF_01 = "999";
            }
            else if (LF_01_c.Checked == true)
            {
                var_LF_01 = "888";
            }



            if (LF_02_b.Checked == true)
            {
                var_LF_02 = "999";
            }
            else if (LF_02_c.Checked == true)
            {
                var_LF_02 = "888";
            }



            if (LF_03_b.Checked == true)
            {
                var_LF_03 = "999";
            }
            else if (LF_03_c.Checked == true)
            {
                var_LF_03 = "888";
            }



            if (LF_04_b.Checked == true)
            {
                var_LF_04 = "999";
            }
            else if (LF_04_c.Checked == true)
            {
                var_LF_04 = "888";
            }



            if (LF_05_b.Checked == true)
            {
                var_LF_05 = "999";
            }
            else if (LF_05_c.Checked == true)
            {
                var_LF_05 = "888";
            }



            if (LF_06_b.Checked == true)
            {
                var_LF_06 = "999";
            }
            else if (LF_06_c.Checked == true)
            {
                var_LF_06 = "888";
            }


            if (LF_07_b.Checked == true)
            {
                var_LF_07 = "999";
            }
            else if (LF_07_c.Checked == true)
            {
                var_LF_07 = "888";
            }



            if (RF_01_b.Checked == true)
            {
                var_RF_01 = "999";
            }
            else if (RF_01_c.Checked == true)
            {
                var_RF_01 = "888";
            }



            if (RF_02_b.Checked == true)
            {
                var_RF_02 = "999";
            }
            else if (RF_02_c.Checked == true)
            {
                var_RF_02 = "888";
            }



            if (RF_03_b.Checked == true)
            {
                var_RF_03 = "999";
            }
            else if (RF_03_c.Checked == true)
            {
                var_RF_03 = "888";
            }



            if (RF_04_b.Checked == true)
            {
                var_RF_04 = "999";
            }
            else if (RF_04_c.Checked == true)
            {
                var_RF_04 = "888";
            }



            if (SE_01_b.Checked == true)
            {
                var_SE_01 = "999";
            }
            else if (SE_01_c.Checked == true)
            {
                var_SE_01 = "888";
            }



            if (SE_02_b.Checked == true)
            {
                var_SE_02 = "999";
            }
            else if (SE_02_c.Checked == true)
            {
                var_SE_02 = "888";
            }




            if (SE_03_b.Checked == true)
            {
                var_SE_03 = "999";
            }
            else if (SE_03_c.Checked == true)
            {
                var_SE_03 = "888";
            }



            if (SE_04_b.Checked == true)
            {
                var_SE_04 = "999";
            }
            else if (SE_04_c.Checked == true)
            {
                var_SE_04 = "888";
            }



            if (CS_01_b.Checked == true)
            {
                var_CS_01 = "999";
            }
            else if (CS_01_c.Checked == true)
            {
                var_CS_01 = "888";
            }



            if (CS_02_b.Checked == true)
            {
                var_CS_02 = "999";
            }
            else if (CS_02_c.Checked == true)
            {
                var_CS_02 = "888";
            }



            if (CS_03_b.Checked == true)
            {
                var_CS_03 = "999";
            }
            else if (CS_03_c.Checked == true)
            {
                var_CS_03 = "888";
            }



            if (CS_04_b.Checked == true)
            {
                var_CS_04 = "999";
            }
            else if (CS_04_c.Checked == true)
            {
                var_CS_04 = "888";
            }




            if (CS_05_b.Checked == true)
            {
                var_CS_05 = "999";
            }
            else if (CS_05_c.Checked == true)
            {
                var_CS_05 = "888";
            }



            if (CS_06_b.Checked == true)
            {
                var_CS_06 = "999";
            }
            else if (CS_06_c.Checked == true)
            {
                var_CS_06 = "888";
            }



            if (CS_07_b.Checked == true)
            {
                var_CS_07 = "999";
            }
            else if (CS_07_c.Checked == true)
            {
                var_CS_07 = "888";
            }



            if (CS_08_b.Checked == true)
            {
                var_CS_08 = "999";
            }
            else if (CS_08_c.Checked == true)
            {
                var_CS_08 = "888";
            }



            if (CS_09_b.Checked == true)
            {
                var_CS_09 = "999";
            }
            else if (CS_09_c.Checked == true)
            {
                var_CS_09 = "888";
            }



            if (CS_10_b.Checked == true)
            {
                var_CS_10 = "999";
            }
            else if (CS_10_c.Checked == true)
            {
                var_CS_10 = "888";
            }




            if (UR_01_b.Checked == true)
            {
                var_UR_01 = "999";
            }
            else if (UR_01_c.Checked == true)
            {
                var_UR_01 = "888";
            }



            if (UR_02_b.Checked == true)
            {
                var_UR_02 = "999";
            }
            else if (UR_02_c.Checked == true)
            {
                var_UR_02 = "888";
            }



            if (UR_03_b.Checked == true)
            {
                var_UR_03 = "999";
            }
            else if (UR_03_c.Checked == true)
            {
                var_UR_03 = "888";
            }



            if (UR_04_b.Checked == true)
            {
                var_UR_04 = "999";
            }
            else if (UR_04_c.Checked == true)
            {
                var_UR_04 = "888";
            }



            if (UR_05_b.Checked == true)
            {
                var_UR_05 = "999";
            }
            else if (UR_05_c.Checked == true)
            {
                var_UR_05 = "888";
            }




            if (UR_06_b.Checked == true)
            {
                var_UR_06 = "999";
            }
            else if (UR_06_c.Checked == true)
            {
                var_UR_06 = "888";
            }



            if (UR_07_b.Checked == true)
            {
                var_UR_07 = "999";
            }
            else if (UR_07_c.Checked == true)
            {
                var_UR_07 = "888";
            }



            if (UR_08_b.Checked == true)
            {
                var_UR_08 = "999";
            }
            else if (UR_08_c.Checked == true)
            {
                var_UR_08 = "888";
            }



            if (UR_10_b.Checked == true)
            {
                var_UR_10 = "999";
            }
            else if (UR_10_c.Checked == true)
            {
                var_UR_10 = "888";
            }



            if (UR_11_b.Checked == true)
            {
                var_UR_11 = "999";
            }
            else if (UR_11_c.Checked == true)
            {
                var_UR_11 = "888";
            }




            if (UR_12_b.Checked == true)
            {
                var_UR_12 = "999";
            }
            else if (UR_12_c.Checked == true)
            {
                var_UR_12 = "888";
            }




            if (UR_13_b.Checked == true)
            {
                var_UR_13 = "999";
            }
            else if (UR_13_c.Checked == true)
            {
                var_UR_13 = "888";
            }




            if (UR_14_b.Checked == true)
            {
                var_UR_14 = "999";
            }
            else if (UR_14_c.Checked == true)
            {
                var_UR_14 = "888";
            }



            if (UR_15_b.Checked == true)
            {
                var_UR_15 = "999";
            }
            else if (UR_15_c.Checked == true)
            {
                var_UR_15 = "888";
            }




            if (UR_16_b.Checked == true)
            {
                var_UR_16 = "999";
            }
            else if (UR_16_c.Checked == true)
            {
                var_UR_16 = "888";
            }



            if (UR_17_b.Checked == true)
            {
                var_UR_17 = "999";
            }
            else if (UR_17_c.Checked == true)
            {
                var_UR_17 = "888";
            }



            if (UR_18_b.Checked == true)
            {
                var_UR_18 = "999";
            }
            else if (UR_18_c.Checked == true)
            {
                var_UR_18 = "888";
            }




            if (UR_19_b.Checked == true)
            {
                var_UR_19 = "999";
            }
            else if (UR_19_c.Checked == true)
            {
                var_UR_19 = "888";
            }




            if (UR_20_b.Checked == true)
            {
                var_UR_20 = "999";
            }
            else if (UR_20_c.Checked == true)
            {
                var_UR_20 = "888";
            }



            if (UR_21_b.Checked == true)
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



            if (uc_02a_b.Checked == true)
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



            if (uc_03a_b.Checked == true)
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




            if (uc_04a_b.Checked == true)
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



            if (uc_05a_b.Checked == true)
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




            if (uc_06a_b.Checked == true)
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



            if (uc_07a_b.Checked == true)
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



            if (uc_08a_b.Checked == true)
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




            if (uc_09a_b.Checked == true)
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




            if (uc_10a_b.Checked == true)
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



            if (uc_11a_b.Checked == true)
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




            if (uc_12a_b.Checked == true)
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



            if (uc_13a_b.Checked == true)
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




            if (uc_14a_b.Checked == true)
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




            if (uc_15a_b.Checked == true)
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




            if (uc_16a_b.Checked == true)
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





            if (uc_17a_b.Checked == true)
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




            if (uc_18a_b.Checked == true)
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




            if (uc_19a_b.Checked == true)
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




            if (uc_20a_b.Checked == true)
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




            if (uc_21a_b.Checked == true)
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




            if (uc_22a_b.Checked == true)
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




            if (uc_23a_b.Checked == true)
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




            if (uc_24a_b.Checked == true)
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




            if (uc_25a_b.Checked == true)
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




            if (uc_26a_b.Checked == true)
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




            if (uc_27a_b.Checked == true)
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





            if (uc_28a_b.Checked == true)
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




            if (uc_29a_b.Checked == true)
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





            if (uc_30a_b.Checked == true)
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




            if (uc_31a_b.Checked == true)
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




            if (uc_32a_b.Checked == true)
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





            if (uc_33a_b.Checked == true)
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




            if (uc_34a_b.Checked == true)
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




            if (uc_35a_b.Checked == true)
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





            if (uc_36a_b.Checked == true)
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





            if (uc_37a_b.Checked == true)
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







            if (LA_20a_b.Checked == true)
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




            if (LA_21a_b.Checked == true)
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



            if (LA_22a_b.Checked == true)
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



            if (LA_23a_b.Checked == true)
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



            if (LA_24a_b.Checked == true)
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



            if (LA_25a_b.Checked == true)
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



            if (LA_26a_b.Checked == true)
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




            if (LA_27a_b.Checked == true)
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




            if (LA_28a_b.Checked == true)
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



            if (LA_29a_b.Checked == true)
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



            if (LA_30a_b.Checked == true)
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



            if (LA_31a_b.Checked == true)
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



            if (LA_32a_b.Checked == true)
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




            if (LA_33a_b.Checked == true)
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




            if (LA_34a_b.Checked == true)
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



            if (LA_35a_b.Checked == true)
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



            if (LA_36a_b.Checked == true)
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




            if (LA_37a_b.Checked == true)
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



            if (LA_38a_b.Checked == true)
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



            if (LA_39a_b.Checked == true)
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



            if (LA_40a_b.Checked == true)
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



            if (LA_41a_b.Checked == true)
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



            if (LA_42a_b.Checked == true)
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



            if (LA_43a_b.Checked == true)
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



            if (LA_44a_b.Checked == true)
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



            if (LA_45a_b.Checked == true)
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



            if (LA_46a_b.Checked == true)
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



            if (LA_47a_b.Checked == true)
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




            if (LA_48a_b.Checked == true)
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



            if (LA_49a_b.Checked == true)
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



            if (LA_50a_b.Checked == true)
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




            if (LA_51a_b.Checked == true)
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



            if (LA_52a_b.Checked == true)
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


            DateTime dt_entry = new DateTime();

            string[] arr_entry = null;
            string val_entry = null;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            dt_entry = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            arr_entry = dt_entry.ToShortDateString().Split('/');
            val_entry = arr_entry[2] + "/" + arr_entry[1] + "/" + arr_entry[0];


            //            string[] fldname = {
            //"la_sno",
            //"LA_01",
            //"LA_02",
            //"LA_03_b",
            //"LA_03_a",
            //"LA_04_b",
            //"LA_04_a",
            //"LA_05_b",
            //"LA_05_a",
            //"LA_06_b",
            //"LA_06_a",
            //"LA_07_b",
            //"LA_07_a",
            //"LA_08_b",
            //"LA_08_a",
            //"LA_09_b",
            //"LA_09_a",
            //"LA_10_b",
            //"LA_10_a",
            //"LA_11_b",
            //"LA_11_a",
            //"LA_12_b",
            //"LA_12_a",
            //"LA_13_b",
            //"LA_13_a",
            //"LA_14_b",
            //"LA_14_a",
            //"LA_15_b",
            //"LA_15_a",
            //"LA_16_b",
            //"LA_16_a",
            //"LF_01",
            //"LF_01_a",
            //"LF_02",
            //"LF_02_a",
            //"LF_03",
            //"LF_03_a",
            //"LF_04",
            //"LF_04_a",
            //"LF_05",
            //"LF_05_a",
            //"LF_06",
            //"LF_06_a",
            //"LF_07",
            //"LF_07_a",
            //"RF_01",
            //"RF_01_a",
            //"RF_02",
            //"RF_02_a",
            //"RF_03",
            //"RF_03_a",
            //"RF_04",
            //"RF_04_a",
            //"SE_01",
            //"SE_01_a",
            //"SE_02",
            //"SE_02_a",
            //"SE_03",
            //"SE_03_a",
            //"SE_04",
            //"SE_04_a",
            //"CS_01",
            //"CS_01_a",
            //"CS_02",
            //"CS_02_a",
            //"CS_03",
            //"CS_03_a",
            //"CS_04",
            //"CS_04_a",
            //"CS_05",
            //"CS_05_a",
            //"CS_06",
            //"CS_06_a",
            //"CS_07",
            //"CS_07_a",
            //"CS_08",
            //"CS_08_a",
            //"CS_09",
            //"CS_09_a",
            //"CS_10",
            //"CS_10_a",
            //"UR_01",
            //"UR_01_a",
            //"UR_02",
            //"UR_02_a",
            //"UR_03",
            //"UR_03_a",
            //"UR_04",
            //"UR_04_a",
            //"UR_05",
            //"UR_05_a",
            //"UR_06",
            //"UR_06_a",
            //"UR_07",
            //"UR_07_a",
            //"UR_08",
            //"UR_08_a",
            //"UR_10",
            //"UR_10_a",
            //"UR_11",
            //"UR_11_a",
            //"UR_12",
            //"UR_12_a",
            //"UR_13",
            //"UR_13_a",
            //"UR_14",
            //"UR_14_a",
            //"UR_15",
            //"UR_15_a",
            //"UR_16",
            //"UR_16_a",
            //"UR_17",
            //"UR_17_a",
            //"UR_18",
            //"UR_18_a",
            //"UR_19",
            //"UR_19_a",
            //"UR_20",
            //"UR_20_a",
            //"UR_21",
            //"UR_21_a",
            //"uc_01a",
            //"uc_02a",
            //"uc_02a_a",
            //"uc_02b",
            //"uc_03a",
            //"uc_03a_a",
            //"uc_03b",
            //"uc_04a",
            //"uc_04a_a",
            //"uc_04b",
            //"uc_05a",
            //"uc_05a_a",
            //"uc_05b",
            //"uc_06a",
            //"uc_06a_a",
            //"uc_06b",
            //"uc_07a",
            //"uc_07a_a",
            //"uc_07b",
            //"uc_08a",
            //"uc_08a_a",
            //"uc_08b",
            //"uc_09a",
            //"uc_09a_a",
            //"uc_09b",
            //"uc_10a",
            //"uc_10a_a",
            //"uc_10b",
            //"uc_11a",
            //"uc_11a_a",
            //"uc_11b",
            //"uc_12a",
            //"uc_12a_a",
            //"uc_12b",
            //"uc_13a",
            //"uc_13a_a",
            //"uc_13b",
            //"uc_14a",
            //"uc_14a_a",
            //"uc_14b",
            //"uc_15a",
            //"uc_15a_a",
            //"uc_15b",
            //"uc_16a",
            //"uc_16a_a",
            //"uc_16b",
            //"uc_17a",
            //"uc_17a_a",
            //"uc_17b",
            //"uc_18a",
            //"uc_18a_a",
            //"uc_18b",
            //"uc_19a",
            //"uc_19a_a",
            //"uc_19b",
            //"uc_20a",
            //"uc_20a_a",
            //"uc_20b",
            //"uc_21a",
            //"uc_21a_a",
            //"uc_21b",
            //"uc_22a",
            //"uc_22a_a",
            //"uc_22b",
            //"uc_23a",
            //"uc_23a_a",
            //"uc_23b",
            //"uc_24a",
            //"uc_24a_a",
            //"uc_24b",
            //"uc_25a",
            //"uc_25a_a",
            //"uc_25b",
            //"uc_26a",
            //"uc_26a_a",
            //"uc_26b",
            //"uc_27a",
            //"uc_27a_a",
            //"uc_27b",
            //"uc_28a",
            //"uc_28a_a",
            //"uc_28b",
            //"uc_29a",
            //"uc_29a_a",
            //"uc_29b",
            //"uc_30a",
            //"uc_30a_a",
            //"uc_30b",
            //"uc_31a",
            //"uc_31a_a",
            //"uc_31b",
            //"uc_32a",
            //"uc_32a_a",
            //"uc_32b",
            //"uc_33a",
            //"uc_33a_a",
            //"uc_33b",
            //"uc_34a",
            //"uc_34a_a",
            //"uc_34b",
            //"uc_35a",
            //"uc_35a_a",
            //"uc_35b",
            //"uc_36a",
            //"uc_36a_a",
            //"uc_36b",
            //"uc_37a",
            //"uc_37a_a",
            //"uc_37b",
            //"LA_17",
            //"LA_18",
            //"LA_19",
            //"LA_20a_b",
            //"LA_20a_a",
            //"LA_20b_a",
            //"LA_21a_b",
            //"LA_21a_a",
            //"LA_21b_a",
            //"LA_22a_b",
            //"LA_22a_a",
            //"LA_22b_a",
            //"LA_23a_b",
            //"LA_23a_a",
            //"LA_23b_a",
            //"LA_24a_b",
            //"LA_24a_a",
            //"LA_24b_a",
            //"LA_25a_b",
            //"LA_25a_a",
            //"LA_25b_a",
            //"LA_26a_b",
            //"LA_26a_a",
            //"LA_26b_a",
            //"LA_27a_b",
            //"LA_27a_a",
            //"LA_27b_a",
            //"LA_28a_b",
            //"LA_28a_a",
            //"LA_28b_a",
            //"LA_29a_b",
            //"LA_29a_a",
            //"LA_29b_a",
            //"LA_30a_b",
            //"LA_30a_a",
            //"LA_30b_a",
            //"LA_31a_b",
            //"LA_31a_a",
            //"LA_31b_a",
            //"LA_32a_b",
            //"LA_32a_a",
            //"LA_32b_a",
            //"LA_33a_b",
            //"LA_33a_a",
            //"LA_33b_a",
            //"LA_34a_b",
            //"LA_34a_a",
            //"LA_34b_a",
            //"LA_35a_b",
            //"LA_35a_a",
            //"LA_35b_a",
            //"LA_36a_b",
            //"LA_36a_a",
            //"LA_36b_a",
            //"LA_37a_b",
            //"LA_37a_a",
            //"LA_37b_a",
            //"LA_38a_b",
            //"LA_38a_a",
            //"LA_38b_a",
            //"LA_39a_b",
            //"LA_39a_a",
            //"LA_39b_a",
            //"LA_40a_b",
            //"LA_40a_a",
            //"LA_40b_a",
            //"LA_41a_b",
            //"LA_41a_a",
            //"LA_41b_a",
            //"LA_42a_b",
            //"LA_42a_a",
            //"LA_42b_a",
            //"LA_43a_b",
            //"LA_43a_a",
            //"LA_43b_a",
            //"LA_44a_b",
            //"LA_44a_a",
            //"LA_44b_a",
            //"LA_45a_b",
            //"LA_45a_a",
            //"LA_45b_a",
            //"LA_46a_b",
            //"LA_46a_a",
            //"LA_46b_a",
            //"LA_47a_b",
            //"LA_47a_a",
            //"LA_47b_a",
            //"LA_48a_b",
            //"LA_48a_a",
            //"LA_48b_a",
            //"LA_49a_b",
            //"LA_49a_a",
            //"LA_49b_a",
            //"LA_50a_b",
            //"LA_50a_a",
            //"LA_50b_a",
            //"LA_51a_b",
            //"LA_51a_a",
            //"LA_51b_a",
            //"LA_52a_b",
            //"LA_52a_a",
            //"LA_52b_a",
            //"UserID",
            //"EntryDate",
            //"labid"
            //};

            //            string[] fldvalue = {
            //la_sno.Text,
            //LA_01.Text,
            //LA_02.Text,
            //var_LA_03_b,
            //LA_03_a.Text,
            //var_LA_04_b,
            //LA_04_a.Text,
            //var_LA_05_b,
            //LA_05_a.Text,
            //var_LA_06_b,
            //LA_06_a.Text,
            //var_LA_07_b,
            //LA_07_a.Text,
            //var_LA_08_b,
            //LA_08_a.Text,
            //var_LA_09_b,
            //LA_09_a.Text,
            //var_LA_10_b,
            //LA_10_a.Text,
            //var_LA_11_b,
            //LA_11_a.Text,
            //var_LA_12_b,
            //LA_12_a.Text,
            //var_LA_13_b,
            //LA_13_a.Text,
            //var_LA_14_b,
            //LA_14_a.Text,
            //var_LA_15_b,
            //LA_15_a.Text,
            //var_LA_16_b,
            //LA_16_a.Text,
            //var_LF_01,
            //LF_01_a.Text,
            //var_LF_02,
            //LF_02_a.Text,
            //var_LF_03,
            //LF_03_a.Text,
            //var_LF_04,
            //LF_04_a.Text,
            //var_LF_05,
            //LF_05_a.Text,
            //var_LF_06,
            //LF_06_a.Text,
            //var_LF_07,
            //LF_07_a.Text,
            //var_RF_01,
            //RF_01_a.Text,
            //var_RF_02,
            //RF_02_a.Text,
            //var_RF_03,
            //RF_03_a.Text,
            //var_RF_04,
            //RF_04_a.Text,
            //var_SE_01,
            //SE_01_a.Text,
            //var_SE_02,
            //SE_02_a.Text,
            //var_SE_03,
            //SE_03_a.Text,
            //var_SE_04,
            //SE_04_a.Text,
            //var_CS_01,
            //CS_01_a.Text,
            //var_CS_02,
            //CS_02_a.Text,
            //var_CS_03,
            //CS_03_a.Text,
            //var_CS_04,
            //CS_04_a.Text,
            //var_CS_05,
            //CS_05_a.Text,
            //var_CS_06,
            //CS_06_a.Text,
            //var_CS_07,
            //CS_07_a.Text,
            //var_CS_08,
            //CS_08_a.Text,
            //var_CS_09,
            //CS_09_a.Text,
            //var_CS_10,
            //CS_10_a.Text,
            //var_UR_01,
            //UR_01_a.Text,
            //var_UR_02,
            //UR_02_a.Text,
            //var_UR_03,
            //UR_03_a.Text,
            //var_UR_04,
            //UR_04_a.Text,
            //var_UR_05,
            //UR_05_a.Text,
            //var_UR_06,
            //UR_06_a.Text,
            //var_UR_07,
            //UR_07_a.Text,
            //var_UR_08,
            //UR_08_a.Text,
            //var_UR_10,
            //UR_10_a.Text,
            //var_UR_11,
            //UR_11_a.Text,
            //var_UR_12,
            //UR_12_a.Text,
            //var_UR_13,
            //UR_13_a.Text,
            //var_UR_14,
            //UR_14_a.Text,
            //var_UR_15,
            //UR_15_a.Text,
            //var_UR_16,
            //UR_16_a.Text,
            //var_UR_17,
            //UR_17_a.Text,
            //var_UR_18,
            //UR_18_a.Text,
            //var_UR_19,
            //UR_19_a.Text,
            //var_UR_20,
            //UR_20_a.Text,
            //var_UR_21,
            //UR_21_a.Text,
            //var_uc_01a,
            //var_uc_02a,
            //uc_02a_a.Text,
            //var_uc_02b,
            //var_uc_03a,
            //uc_03a_a.Text,
            //var_uc_03b,
            //var_uc_04a,
            //uc_04a_a.Text,
            //var_uc_04b,
            //var_uc_05a,
            //uc_05a_a.Text,
            //var_uc_05b,
            //var_uc_06a,
            //uc_06a_a.Text,
            //var_uc_06b,
            //var_uc_07a,
            //uc_07a_a.Text,
            //var_uc_07b,
            //var_uc_08a,
            //uc_08a_a.Text,
            //var_uc_08b,
            //var_uc_09a,
            //uc_09a_a.Text,
            //var_uc_09b,
            //var_uc_10a,
            //uc_10a_a.Text,
            //var_uc_10b,
            //var_uc_11a,
            //uc_11a_a.Text,
            //var_uc_11b,
            //var_uc_12a,
            //uc_12a_a.Text,
            //var_uc_12b,
            //var_uc_13a,
            //uc_13a_a.Text,
            //var_uc_13b,
            //var_uc_14a,
            //uc_14a_a.Text,
            //var_uc_14b,
            //var_uc_15a,
            //uc_15a_a.Text,
            //var_uc_15b,
            //var_uc_16a,
            //uc_16a_a.Text,
            //var_uc_16b,
            //var_uc_17a,
            //uc_17a_a.Text,
            //var_uc_17b,
            //var_uc_18a,
            //uc_18a_a.Text,
            //var_uc_18b,
            //var_uc_19a,
            //uc_19a_a.Text,
            //var_uc_19b,
            //var_uc_20a,
            //uc_20a_a.Text,
            //var_uc_20b,
            //var_uc_21a,
            //uc_21a_a.Text,
            //var_uc_21b,
            //var_uc_22a,
            //uc_22a_a.Text,
            //var_uc_22b,
            //var_uc_23a,
            //uc_23a_a.Text,
            //var_uc_23b,
            //var_uc_24a,
            //uc_24a_a.Text,
            //var_uc_24b,
            //var_uc_25a,
            //uc_25a_a.Text,
            //var_uc_25b,
            //var_uc_26a,
            //uc_26a_a.Text,
            //var_uc_26b,
            //var_uc_27a,
            //uc_27a_a.Text,
            //var_uc_27b,
            //var_uc_28a,
            //uc_28a_a.Text,
            //var_uc_28b,
            //var_uc_29a,
            //uc_29a_a.Text,
            //var_uc_29b,
            //var_uc_30a,
            //uc_30a_a.Text,
            //var_uc_30b,
            //var_uc_31a,
            //uc_31a_a.Text,
            //var_uc_31b,
            //var_uc_32a,
            //uc_32a_a.Text,
            //var_uc_32b,
            //var_uc_33a,
            //uc_33a_a.Text,
            //var_uc_33b,
            //var_uc_34a,
            //uc_34a_a.Text,
            //var_uc_34b,
            //var_uc_35a,
            //uc_35a_a.Text,
            //var_uc_35b,
            //var_uc_36a,
            //uc_36a_a.Text,
            //var_uc_36b,
            //var_uc_37a,
            //uc_37a_a.Text,
            //var_uc_37b,
            //LA_17.Text,
            //LA_18.Text,
            //LA_19.Text,
            //var_LA_20a_b,
            //LA_20a_a.Text,
            //var_LA_20b_a,
            //var_LA_21a_b,
            //LA_21a_a.Text,
            //var_LA_21b_a,
            //var_LA_22a_b,
            //LA_22a_a.Text,
            //var_LA_22b_a,
            //var_LA_23a_b,
            //LA_23a_a.Text,
            //var_LA_23b_a,
            //var_LA_24a_b,
            //LA_24a_a.Text,
            //var_LA_24b_a,
            //var_LA_25a_b,
            //LA_25a_a.Text,
            //var_LA_25b_a,
            //var_LA_26a_b,
            //LA_26a_a.Text,
            //var_LA_26b_a,
            //var_LA_27a_b,
            //LA_27a_a.Text,
            //var_LA_27b_a,
            //var_LA_28a_b,
            //LA_28a_a.Text,
            //var_LA_28b_a,
            //var_LA_29a_b,
            //LA_29a_a.Text,
            //var_LA_29b_a,
            //var_LA_30a_b,
            //LA_30a_a.Text,
            //var_LA_30b_a,
            //var_LA_31a_b,
            //LA_31a_a.Text,
            //var_LA_31b_a,
            //var_LA_32a_b,
            //LA_32a_a.Text,
            //var_LA_32b_a,
            //var_LA_33a_b,
            //LA_33a_a.Text,
            //var_LA_33b_a,
            //var_LA_34a_b,
            //LA_34a_a.Text,
            //var_LA_34b_a,
            //var_LA_35a_b,
            //LA_35a_a.Text,
            //var_LA_35b_a,
            //var_LA_36a_b,
            //LA_36a_a.Text,
            //var_LA_36b_a,
            //var_LA_37a_b,
            //LA_37a_a.Text,
            //var_LA_37b_a,
            //var_LA_38a_b,
            //LA_38a_a.Text,
            //var_LA_38b_a,
            //var_LA_39a_b,
            //LA_39a_a.Text,
            //var_LA_39b_a,
            //var_LA_40a_b,
            //LA_40a_a.Text,
            //var_LA_40b_a,
            //var_LA_41a_b,
            //LA_41a_a.Text,
            //var_LA_41b_a,
            //var_LA_42a_b,
            //LA_42a_a.Text,
            //var_LA_42b_a,
            //var_LA_43a_b,
            //LA_43a_a.Text,
            //var_LA_43b_a,
            //var_LA_44a_b,
            //LA_44a_a.Text,
            //var_LA_44b_a,
            //var_LA_45a_b,
            //LA_45a_a.Text,
            //var_LA_45b_a,
            //var_LA_46a_b,
            //LA_46a_a.Text,
            //var_LA_46b_a,
            //var_LA_47a_b,
            //LA_47a_a.Text,
            //var_LA_47b_a,
            //var_LA_48a_b,
            //LA_48a_a.Text,
            //var_LA_48b_a,
            //var_LA_49a_b,
            //LA_49a_a.Text,
            //var_LA_49b_a,
            //var_LA_50a_b,
            //LA_50a_a.Text,
            //var_LA_50b_a,
            //var_LA_51a_b,
            //LA_51a_a.Text,
            //var_LA_51b_a,
            //var_LA_52a_b,
            //LA_52a_a.Text,
            //var_LA_52b_a,
            //Session["userid"].ToString(),
            //dt_entry.ToShortDateString(),
            //HttpContext.Current.Request["labid"].ToString()

            //};



            string qry = "insert into sample_result(" +
"la_sno," +
"LA_01," +
"LA_02," +
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
"labid) values('" +
la_sno.Text + "', '" +
LA_01.Text + "', '" +
LA_02.Text + "', '" +
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
LA_19.Text + "', '" +
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
HttpContext.Current.Request["labid"].ToString() + "')";


            //string msg = obj_op.ExecuteNonQuery_Message(fldname, fldvalue, "sp_AddSampleResult");
            string msg = obj_op.ExecuteNonQuery_Message_Qry(qry);

            if (string.IsNullOrEmpty(msg))
            {
                string message = "alert('Record saved successfully');window.location.href='sample_recv.aspx'";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
            else
            {
                string message = "alert('" + msg + "');";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }


            LA_01.Focus();

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
        "FROM [form1] where[AS1_screening_ID] = '" + screeningid + "' and labid = '" + labid + "'", cn.cn);


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

            DataSet ds = ExecuteNonQuery(fldname, fldvalue, "sp_GetRecords");

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


}