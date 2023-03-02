<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sample_recv_20230302.aspx.cs" Inherits="sample_recv_20230302" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui">
    <meta name="description" content="PSBI Lab Management System">
    <meta name="keywords" content="PSBI Lab Management System">
    <meta name="author" content="ThemeSelect">
    <meta http-equiv="Content-Security-Policy" content="upgrade-insecure-requests">
    <title>PSBI Lab Management System</title>
    <link rel="apple-touch-icon" href="favicon.ico">
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico">
    <!-- BEGIN: Theme CSS-->
    <link rel="stylesheet" type="text/css" href="Content/demo/chameleon-admin-template/app-assets/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="Content/demo/chameleon-admin-template/app-assets/css/bootstrap-extended.min.css">
    <link rel="stylesheet" type="text/css" href="Content/demo/chameleon-admin-template/app-assets/css/colors.min.css">
    <link rel="stylesheet" type="text/css" href="Content/demo/chameleon-admin-template/app-assets/css/components.min.css">
    <!-- END: Theme CSS-->
    <!-- BEGIN: Page CSS-->
    <link rel="stylesheet" type="text/css" href="Content/demo/chameleon-admin-template/app-assets/css/core/menu/menu-types/vertical-menu.min.css">
    <link rel="stylesheet" type="text/css" href="Content/demo/chameleon-admin-template/app-assets/css/core/colors/palette-gradient.min.css">
    <!-- END: Page CSS-->
    <!-- BEGIN: Custom CSS-->
    <link href="Content/demo/chameleon-admin-template/assets/css/style.css" rel="stylesheet" />
    <link href="Content/demo/chameleon-admin-template/assets/feather/style.min.css" rel="stylesheet" />
    <!-- END: Custom CSS-->
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <link href="Scripts/timepicker/css/timepicki.css" rel="stylesheet" />
    <script src="Scripts/timepicker/timepicki.js"></script>
    <script type="text/javascript">
        function lettersOnly(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
                ((evt.which) ? evt.which : 0));

            if (charCode > 31 && (charCode < 65 || charCode > 90) &&
                (charCode < 97 || charCode > 122)) {
                alert("Please enter string value ");
                return false;
            }
            return true;
        }

        function lettersOnly_WithSpace(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
                ((evt.which) ? evt.which : 0));

            if (charCode > 31 && (charCode < 65 || charCode > 90) &&
                (charCode < 97 || charCode > 122) && charCode != 32) {
                alert("Please enter string value ");
                return false;
            }
            return true;
        }

        function lettersOnly_WithSpace_Email(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
                ((evt.which) ? evt.which : 0));

            if (charCode > 31 && (charCode < 65 || charCode > 90) &&
                (charCode < 97 || charCode > 122) && charCode != 32 && charCode != 46 && charCode != 64) {
                alert("Please enter string value ");
                return false;
            }
            return true;
        }

        function numeralsOnly(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
                ((evt.which) ? evt.which : 0));

            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                alert("Please enter Numeric value ");
                return false;
            }
            return true;
        }

        function numeralsOnly1(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
                ((evt.which) ? evt.which : 0));

            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46) {
                alert("Please enter Numeric value ");
                return false;
            }
            return true;
        }

        function RestrictSpecialCharacters(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
                ((evt.which) ? evt.which : 0));
            if (charCode > 31 && (charCode < 65 || charCode > 90) &&
                (charCode < 97 || charCode > 122) && charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 32) {
                alert("Please enter string / numeric value but special characters not allowed ");
                return false;
            }
            return true;
        }

        function RestrictSpecialCharacters_New2(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
                ((evt.which) ? evt.which : 0));
            if (charCode > 31 && (charCode < 65 || charCode > 90) &&
                (charCode < 97 || charCode > 122) && charCode > 31 && (charCode < 48 || charCode > 57)) {
                alert("Please enter string / numeric value but special characters not allowed ");
                return false;
            }
            return true;
        }




        function RestrictSpecialCharacters_New(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
                ((evt.which) ? evt.which : 0));

            if (charCode > 31 && (charCode < 65 || charCode > 90) &&
                (charCode < 97 || charCode > 122) && charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 32 && charCode != 46 && charCode != 47) {
                alert("Please enter string / numeric value but special characters not allowed ");
                return false;
            }
            return true;
        }


        function RestrictSpecialCharacters_Projectcode(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
                ((evt.which) ? evt.which : 0));

            if (charCode > 31 && (charCode < 65 || charCode > 90) &&
                (charCode < 97 || charCode > 122) && charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 32 && charCode != 46 && charCode != 47) {
                alert("Please enter string / numeric value but special characters not allowed ");
                return false;
            }
            return true;
        }


        function numeralsOnly_decimal(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
                ((evt.which) ? evt.which : 0));

            if (charCode > 31 && charCode != 46 && (charCode < 48 || charCode > 57)) {
                alert("Please enter Numeric value ");
                return false;
            }
            return true;
        }


    </script>
    <script>

        $(document).on("click", "input[name='AS1_Q1_1']:checked", function () {

            var arr = $(this).val().split('_');
            var rdo_value = $("input[name='AS1_Q2_1']:checked").val();

            if (rdo_value != undefined && rdo_value != "" && rdo_value != null && rdo_value != "undefined") {

                var arr1 = $("input[name='AS1_Q2_1']:checked").val().split('_');

                if (arr[2] != arr1[2]) {
                    alert("RCT 1 must be selected for all samples ");

                    $("#AS1_Q2_11").removeAttr("checked");
                    $("#AS1_Q2_12").removeAttr("checked");

                    $("#AS1_Q3_1").removeAttr("checked");
                    $("#AS1_Q3_2").removeAttr("checked");
                }
            }


            var rdo_value1 = $("input[name='AS1_Q3']:checked").val();


            if (rdo_value1 != undefined && rdo_value1 != "" && rdo_value1 != null && rdo_value1 != "undefined") {

                var arr1 = $("input[name='AS1_Q3']:checked").val().split('_');


                if (arr[2] == 11 && arr1[2] == 2) {
                    alert("RCT 1 must be selected for all samples ");

                    $("#AS1_Q2_11").removeAttr("checked");
                    $("#AS1_Q2_12").removeAttr("checked");

                    $("#AS1_Q3_1").removeAttr("checked");
                    $("#AS1_Q3_2").removeAttr("checked");

                } else if (arr[2] == 12 && arr1[2] == 1) {
                    alert("RCT 1 must be selected for all samples ");

                    $("#AS1_Q2_11").removeAttr("checked");
                    $("#AS1_Q2_12").removeAttr("checked");

                    $("#AS1_Q3_1").removeAttr("checked");
                    $("#AS1_Q3_2").removeAttr("checked");

                }
            }


        });


        $(document).on("click", "input[name='AS1_Q2_1']:checked", function () {

            var arr = $(this).val().split('_');
            var rdo_value = $("input[name='AS1_Q1_1']:checked").val();

            if (rdo_value != undefined && rdo_value != "" && rdo_value != null && rdo_value != "undefined") {

                var arr1 = $("input[name='AS1_Q1_1']:checked").val().split('_');

                if (arr[2] != arr1[2]) {
                    alert("RCT 1 must be selected for all samples ");

                    $("#AS1_Q1_11").removeAttr("checked");
                    $("#AS1_Q1_12").removeAttr("checked");
                }
            }




            var rdo_value1 = $("input[name='AS1_Q3']:checked").val();

            if (rdo_value1 != undefined && rdo_value1 != "" && rdo_value1 != null && rdo_value1 != "undefined") {

                var arr1 = $("input[name='AS1_Q3']:checked").val().split('_');


                if (arr[2] == 11 && arr1[2] == 2) {
                    alert("RCT 1 must be selected for all samples ");

                    $("#AS1_Q1_11").removeAttr("checked");
                    $("#AS1_Q1_12").removeAttr("checked");

                    $("#AS1_Q3_1").removeAttr("checked");
                    $("#AS1_Q3_2").removeAttr("checked");

                } else if (arr[2] == 12 && arr1[2] == 1) {
                    alert("RCT 1 must be selected for all samples ");

                    $("#AS1_Q1_11").removeAttr("checked");
                    $("#AS1_Q1_12").removeAttr("checked");

                    $("#AS1_Q3_1").removeAttr("checked");
                    $("#AS1_Q3_2").removeAttr("checked");

                }
            }

        });




        $(document).on("click", "input[name='AS1_Q3']:checked", function () {

            var arr = $(this).val().split('_');
            var rdo_value = $("input[name='AS1_Q2_1']:checked").val();


            if (rdo_value != undefined && rdo_value != "" && rdo_value != null && rdo_value != "undefined") {

                var arr1 = $("input[name='AS1_Q2_1']:checked").val().split('_');

                if (arr[2] == 2 && arr1[2] == 11) {
                    alert("RCT 1 must be selected for all samples ");

                    $("#AS1_Q2_11").removeAttr("checked");
                    $("#AS1_Q2_12").removeAttr("checked");
                } else if (arr[2] == 1 && arr1[2] == 12) {
                    alert("RCT 1 must be selected for all samples ");

                    $("#AS1_Q2_11").removeAttr("checked");
                    $("#AS1_Q2_12").removeAttr("checked");
                }
            }




            var rdo_value1 = $("input[name='AS1_Q1_1']:checked").val();

            if (rdo_value1 != undefined && rdo_value1 != "" && rdo_value1 != null && rdo_value1 != "undefined") {

                var arr1 = $("input[name='AS1_Q1_1']:checked").val().split('_');


                if (arr[2] == 2 && arr1[2] == 11) {
                    alert("RCT 1 must be selected for all samples ");

                    //$("#AS1_Q2_11").removeAttr("checked");
                    //$("#AS1_Q2_12").removeAttr("checked");

                    $("#AS1_Q1_11").removeAttr("checked");
                    $("#AS1_Q1_12").removeAttr("checked");

                } else if (arr[2] == 1 && arr1[2] == 12) {
                    alert("RCT 1 must be selected for all samples ");

                    //$("#AS1_Q2_11").removeAttr("checked");
                    //$("#AS1_Q2_12").removeAttr("checked");

                    $("#AS1_Q1_11").removeAttr("checked");
                    $("#AS1_Q1_12").removeAttr("checked");
                }
            }

        });




        $(document).on("click", "input[name='AS1_Q1_1']:checked", function () {

            var arr = $(this).val().split('_');
            var rdo_value = $("input[name='AS1_Q3']:checked").val();
            var rdo_value1 = $("input[name='AS1_Q2_1']:checked").val();


            if (rdo_value != undefined && rdo_value != "" && rdo_value != null && rdo_value != "undefined" &&
                rdo_value1 != undefined && rdo_value1 != "" && rdo_value1 != null && rdo_value1 != "undefined") {

                var arr1 = $("input[name='AS1_Q3']:checked").val().split('_');
                var arr2 = $("input[name='AS1_Q2_1']:checked").val().split('_');


                if (arr[2] === "11" && arr1[2] === "1" && arr2[2] === "11") {

                    $("#pnl_AS4_Q21a").css("display", "none");

                    EnableControls1("AS3_Q16", "txt");
                    EnableControls1("AS3_Q17", "txt");
                    EnableControls1("AS3_Q18", "txt");
                    EnableControls1("AS3_Q19", "txt");
                    EnableControls1("AS3_Q20", "txt");


                    DisableControls1("AS4_Q21a", "rdo");

                    DisableControls1("AS4_Q22a", "txt");
                    DisableControls1("AS4_Q22b", "txt");
                    DisableControls1("AS4_Q23", "txt");
                    DisableControls1("AS4_Q24", "txt");
                    DisableControls1("AS5_Q25a", "txt");
                    DisableControls1("AS5_Q25b", "txt");
                    DisableControls1("AS5_Q26", "txt");

                    DisableControls1("AS5_Q27", "rdo");
                    DisableControls1("AS5_Q28", "rdo");
                    DisableControls1("AS5_Q29", "rdo");
                    DisableControls1("AS5_Q30", "rdo");
                    DisableControls1("AS5_Q31", "rdo");
                    DisableControls1("AS5_Q32", "rdo");

                    DisableControls1("AS5_Q33a", "txt");
                    DisableControls1("AS5_Q33b", "txt");
                    DisableControls1("AS3_Remarks", "txt");

                }
                else {

                    $("#pnl_AS4_Q21a").css("display", "block");

                    DisableControls1("AS3_Q16", "txt");
                    DisableControls1("AS3_Q17", "txt");
                    DisableControls1("AS3_Q18", "txt");
                    DisableControls1("AS3_Q19", "txt");
                    DisableControls1("AS3_Q20", "txt");


                    EnableControls1("AS4_Q21a", "rdo");

                    EnableControls1("AS4_Q22a", "txt");
                    EnableControls1("AS4_Q22b", "txt");
                    EnableControls1("AS4_Q23", "txt");
                    EnableControls1("AS4_Q24", "txt");
                    EnableControls1("AS5_Q25a", "txt");
                    EnableControls1("AS5_Q25b", "txt");
                    EnableControls1("AS5_Q26", "txt");

                    EnableControls1("AS5_Q27", "rdo");
                    EnableControls1("AS5_Q28", "rdo");
                    EnableControls1("AS5_Q29", "rdo");
                    EnableControls1("AS5_Q30", "rdo");
                    EnableControls1("AS5_Q31", "rdo");
                    EnableControls1("AS5_Q32", "rdo");

                    EnableControls1("AS5_Q33a", "txt");
                    EnableControls1("AS5_Q33b", "txt");
                    EnableControls1("AS3_Remarks", "txt");


                }

            }

        });





        $(document).on("click", "input[name='AS1_Q2_1']:checked", function () {

            var arr = $(this).val().split('_');
            var rdo_value = $("input[name='AS1_Q3']:checked").val();
            var rdo_value1 = $("input[name='AS1_Q1_1']:checked").val();


            if (rdo_value != undefined && rdo_value != "" && rdo_value != null && rdo_value != "undefined" &&
                rdo_value1 != undefined && rdo_value1 != "" && rdo_value1 != null && rdo_value1 != "undefined") {

                var arr1 = $("input[name='AS1_Q3']:checked").val().split('_');
                var arr2 = $("input[name='AS1_Q1_1']:checked").val().split('_');


                if (arr[2] === "11" && arr1[2] === "1" && arr2[2] === "11") {

                    $("#pnl_AS4_Q21a").css("display", "none");

                    EnableControls1("AS3_Q16", "txt");
                    EnableControls1("AS3_Q17", "txt");
                    EnableControls1("AS3_Q18", "txt");
                    EnableControls1("AS3_Q19", "txt");
                    EnableControls1("AS3_Q20", "txt");


                    DisableControls1("AS4_Q21a", "rdo");

                    DisableControls1("AS4_Q22a", "txt");
                    DisableControls1("AS4_Q22b", "txt");
                    DisableControls1("AS4_Q23", "txt");
                    DisableControls1("AS4_Q24", "txt");
                    DisableControls1("AS5_Q25a", "txt");
                    DisableControls1("AS5_Q25b", "txt");
                    DisableControls1("AS5_Q26", "txt");

                    DisableControls1("AS5_Q27", "rdo");
                    DisableControls1("AS5_Q28", "rdo");
                    DisableControls1("AS5_Q29", "rdo");
                    DisableControls1("AS5_Q30", "rdo");
                    DisableControls1("AS5_Q31", "rdo");
                    DisableControls1("AS5_Q32", "rdo");

                    DisableControls1("AS5_Q33a", "txt");
                    DisableControls1("AS5_Q33b", "txt");
                    DisableControls1("AS3_Remarks", "txt");

                }
                else {

                    $("#pnl_AS4_Q21a").css("display", "block");


                    DisableControls1("AS3_Q16", "txt");
                    DisableControls1("AS3_Q17", "txt");
                    DisableControls1("AS3_Q18", "txt");
                    DisableControls1("AS3_Q19", "txt");
                    DisableControls1("AS3_Q20", "txt");


                    EnableControls1("AS4_Q21a", "rdo");

                    EnableControls1("AS4_Q22a", "txt");
                    EnableControls1("AS4_Q22b", "txt");
                    EnableControls1("AS4_Q23", "txt");
                    EnableControls1("AS4_Q24", "txt");
                    EnableControls1("AS5_Q25a", "txt");
                    EnableControls1("AS5_Q25b", "txt");
                    EnableControls1("AS5_Q26", "txt");

                    EnableControls1("AS5_Q27", "rdo");
                    EnableControls1("AS5_Q28", "rdo");
                    EnableControls1("AS5_Q29", "rdo");
                    EnableControls1("AS5_Q30", "rdo");
                    EnableControls1("AS5_Q31", "rdo");
                    EnableControls1("AS5_Q32", "rdo");

                    EnableControls1("AS5_Q33a", "txt");
                    EnableControls1("AS5_Q33b", "txt");
                    EnableControls1("AS3_Remarks", "txt");



                }

            }

        });



        $(document).on("click", "#chkMRNo", function () {
            if ($(this).is(":checked") == true) {
                DisableControls1("AS1_mrno", "txt");
                EnableControls1("AS1_lno", "txt");
                $("#chkLNumber").removeAttr("checked");
            }
            else {
                EnableControls1("AS1_mrno", "txt");
                //DisableControls1("AS1_lno", "txt");
            }
        });



        $(document).on("click", "#chkLNumber", function () {
            if ($(this).is(":checked") == true) {
                DisableControls1("AS1_lno", "txt");
                EnableControls1("AS1_mrno", "txt");
                $("#chkMRNo").removeAttr("checked");
            }
            else {
                EnableControls1("AS1_lno", "txt");
                //DisableControls1("AS1_mrno", "txt");
            }
        });




        $(document).on("click", "#chk_AS2_Q7_2a", function () {
            if ($(this).is(":checked") == true) {
                DisableControls1("AS2_Q7_2a", "txt");
                EnableControls1("AS2_Q7_2", "txt");
                $("#chk_AS2_Q7_2").removeAttr("checked");
            }
            else {
                EnableControls1("AS2_Q7_2a", "txt");
                //DisableControls1("AS1_lno", "txt");
            }
        });



        $(document).on("click", "#chk_AS2_Q7_2", function () {
            if ($(this).is(":checked") == true) {
                DisableControls1("AS2_Q7_2", "txt");
                EnableControls1("AS2_Q7_2a", "txt");
                $("#chk_AS2_Q7_2a").removeAttr("checked");
            }
            else {
                EnableControls1("AS2_Q7_2", "txt");
                //DisableControls1("AS1_mrno", "txt");
            }
        });




        $(document).on("click", "input[name='AS1_Q3']:checked", function () {

            var arr = $(this).val().split('_');
            var rdo_value = $("input[name='AS1_Q1_1']:checked").val();
            var rdo_value1 = $("input[name='AS1_Q2_1']:checked").val();


            if (rdo_value != undefined && rdo_value != "" && rdo_value != null && rdo_value != "undefined" &&
                rdo_value1 != undefined && rdo_value1 != "" && rdo_value1 != null && rdo_value1 != "undefined") {

                var arr1 = $("input[name='AS1_Q1_1']:checked").val().split('_');
                var arr2 = $("input[name='AS1_Q2_1']:checked").val().split('_');


                if (arr[2] === "1" && arr1[2] === "11" && arr2[2] === "11") {

                    $("#pnl_AS4_Q21a").css("display", "none");

                    EnableControls1("AS3_Q16", "txt");
                    EnableControls1("AS3_Q17", "txt");
                    EnableControls1("AS3_Q18", "txt");
                    EnableControls1("AS3_Q19", "txt");
                    EnableControls1("AS3_Q20", "txt");


                    DisableControls1("AS4_Q21a", "rdo");

                    DisableControls1("AS4_Q22a", "txt");
                    DisableControls1("AS4_Q22b", "txt");
                    DisableControls1("AS4_Q23", "txt");
                    DisableControls1("AS4_Q24", "txt");
                    DisableControls1("AS5_Q25a", "txt");
                    DisableControls1("AS5_Q25b", "txt");
                    DisableControls1("AS5_Q26", "txt");

                    DisableControls1("AS5_Q27", "rdo");
                    DisableControls1("AS5_Q28", "rdo");
                    DisableControls1("AS5_Q29", "rdo");
                    DisableControls1("AS5_Q30", "rdo");
                    DisableControls1("AS5_Q31", "rdo");
                    DisableControls1("AS5_Q32", "rdo");

                    DisableControls1("AS5_Q33a", "txt");
                    DisableControls1("AS5_Q33b", "txt");
                    DisableControls1("AS3_Remarks", "txt");

                }
                else {

                    $("#pnl_AS4_Q21a").css("display", "block");


                    DisableControls1("AS3_Q16", "txt");
                    DisableControls1("AS3_Q17", "txt");
                    DisableControls1("AS3_Q18", "txt");
                    DisableControls1("AS3_Q19", "txt");
                    DisableControls1("AS3_Q20", "txt");


                    EnableControls1("AS4_Q21a", "rdo");

                    EnableControls1("AS4_Q22a", "txt");
                    EnableControls1("AS4_Q22b", "txt");
                    EnableControls1("AS4_Q23", "txt");
                    EnableControls1("AS4_Q24", "txt");
                    EnableControls1("AS5_Q25a", "txt");
                    EnableControls1("AS5_Q25b", "txt");
                    EnableControls1("AS5_Q26", "txt");

                    EnableControls1("AS5_Q27", "rdo");
                    EnableControls1("AS5_Q28", "rdo");
                    EnableControls1("AS5_Q29", "rdo");
                    EnableControls1("AS5_Q30", "rdo");
                    EnableControls1("AS5_Q31", "rdo");
                    EnableControls1("AS5_Q32", "rdo");

                    EnableControls1("AS5_Q33a", "txt");
                    EnableControls1("AS5_Q33b", "txt");
                    EnableControls1("AS3_Remarks", "txt");



                }

            }

        });





        $(document).on("change", "#AS2_Q8_2", function () {
            $("#lbl_AS2_Q8_3").hide();
            $("#AS2_Q8_3").val("");
            $("#AS2_Q8_3").hide();
        });

        $(document).on("change", "#AS2_Q8_1", function () {
            $("#lbl_AS2_Q8_3").show();
            $("#AS2_Q8_3").show();
        });



        $(document).on("change", "input[name='AS1_fsite']:checked", function () {

            //if (rdo_value === "AS1_fsite_3") {
            //    $("#pnl_lyari_sample").show();

            //    EnableControls("AS6_Q34");
            //    EnableControls("AS6_Q35");
            //    EnableControls("AS6_Q36");
            //    EnableControls("AS6_Q37");
            //    EnableControls("AS6_Q38");
            //    EnableControls("AS6_Q39");
            //    EnableControls("AS6_Q40");
            //    EnableControls("AS6_Q41");
            //    EnableControls("AS6_Q42");
            //    EnableControls("AS6_Q43");
            //    EnableControls("AS6_Q44");
            //    EnableControls("AS6_Q45");
            //    EnableControls("AS6_Q46");
            //    EnableControls("AS6_Q47");
            //    EnableControls("AS5_R1");

            //}
            //else {
            //    $("#pnl_lyari_sample").hide();

            //    DisableControls("AS6_Q34");
            //    DisableControls("AS6_Q35");
            //    DisableControls("AS6_Q36");
            //    DisableControls("AS6_Q37");
            //    DisableControls("AS6_Q38");
            //    DisableControls("AS6_Q39");
            //    DisableControls("AS6_Q40");
            //    DisableControls("AS6_Q41");
            //    DisableControls("AS6_Q42");
            //    DisableControls("AS6_Q43");
            //    DisableControls("AS6_Q44");
            //    DisableControls("AS6_Q45");
            //    DisableControls("AS6_Q46");
            //    DisableControls("AS6_Q47");
            //    DisableControls("AS5_R1");
            //}

        });



        function EnableControls(txt, controlType) {
            if (controlType == "rdo") {
                $(txt).removeAttr("disabled");
            }
            else {
                $("#" + txt).removeAttr("disabled");
            }
        }


        function DisableControls(txt, controlType) {
            if (controlType == "rdo") {
                $(txt).attr("disabled", "disabled");
            } else {
                $("#" + txt).attr("disabled", "disabled");
                $("#" + txt).val("");
            }
        }



        function EnableControls1(txt, controlType) {
            if (controlType == "rdo") {
                $("input[name=" + txt + "]").removeAttr("disabled");
            }
            else {
                $("#" + txt).removeAttr("disabled");
            }
        }


        function DisableControls1(txt, controlType) {
            if (controlType == "rdo") {
                $("input[name=" + txt + "]").removeAttr("checked");
                $("input[name=" + txt + "]").attr("disabled", "disabled");
            } else {
                $("#" + txt).attr("disabled", "disabled");
                $("#" + txt).val("");
            }
        }



        function EnableControls_Loop() {

            $('#form1 input, textarea').each(
                function (index) {
                    var input = $(this);

                    if (input.attr("id") != "AS1_screening_ID") {

                        if (input.attr('type') == "text"
                            || input.attr('type') == "number") {
                            input.removeAttr("disabled", "disabled");

                        } else if (input.attr('type') == "radio") {
                            $("input[name='" + input.attr('name') + "']").removeAttr("disabled");

                            //var radstates = {};
                            //var radioButtons = $("input[name='" + input.attr('name') + "']");

                            //$.each(radioButtons, function (index, rd) {
                            //    if (radioButtons[index].checked == false) {
                            //        radstates[index] = false;
                            //    } else {
                            //        radstates[index] = true;
                            //    }
                            //});

                        } else if (input.attr('type') == "checkbox") {

                            $("input[name='" + input.attr('name') + "']").removeAttr("disabled");

                            //var radstates = {};
                            //var radioButtons = $("input[name='" + input.attr('name') + "']");

                            //$.each(radioButtons, function (index, rd) {
                            //    if (radioButtons[index].checked == false) {
                            //        radstates[index] = false;
                            //    } else {
                            //        radstates[index] = true;
                            //    }
                            //});

                        } else if (input.is("textarea")) {
                            input.removeAttr("disabled");
                        }

                    }

                }, errorValidate);

        }

        function DisableControls_Loop() {

            $('#form1 input, textarea').each(
                function (index) {
                    var input = $(this);

                    if (input.attr("id") != "AS1_screening_ID") {

                        if (input.attr('type') == "text"
                            || input.attr('type') == "number") {

                            input.val("");
                            input.attr("disabled", "disabled");

                        } else if (input.attr('type') == "radio") {

                            $("input[name='" + input.attr('name') + "']").removeAttr("checked");
                            $("input[name='" + input.attr('name') + "']").attr("disabled", "disabled");

                            //var radstates = {};
                            //var radioButtons = $("input[name='" + input.attr('name') + "']");

                            //$.each(radioButtons, function (index, rd) {
                            //    if (radioButtons[index].checked == false) {
                            //        radstates[index] = false;
                            //    } else {
                            //        radstates[index] = true;
                            //    }
                            //});

                        } else if (input.attr('type') == "checkbox") {

                            $("input[name='" + input.attr('name') + "']").removeAttr("checked");
                            $("input[name='" + input.attr('name') + "']").attr("disabled", "disabled");

                            //var radstates = {};
                            //var radioButtons = $("input[name='" + input.attr('name') + "']");

                            //$.each(radioButtons, function (index, rd) {
                            //    if (radioButtons[index].checked == false) {
                            //        radstates[index] = false;
                            //    } else {
                            //        radstates[index] = true;
                            //    }
                            //});

                        } else if (input.is("textarea")) {
                            input.val("");
                            input.attr("disabled", "disabled");
                        }

                    }

                }, errorValidate);

        }


        function errorValidate(err) {
            alert("Error: " + err.code);
        }


    </script>

    <script>

        $(document).on("click", "#cmdCancel", function (e) {

            EnableControls_Loop();

            //$("#AS1_rand_id").removeAttr("disabled");
            //$("#AS1_name").removeAttr("disabled", "disabled");
            //$('input[name=AS1_sex]').removeAttr("disabled", "disabled");
            //$("#AS1_age").removeAttr("disabled", "disabled");
            //$("#AS1_barcode").removeAttr("disabled", "disabled");
            //$('input[name=AS1_fsite]').removeAttr("disabled", "disabled");
            //$('input[name=AS1_Samp_1]').removeAttr("disabled", "disabled");
            //$('input[name=AS1_Samp_2]').removeAttr("disabled", "disabled");
            //$('input[name=AS1_Samp_3]').removeAttr("disabled", "disabled");
            //$('input[name=AS1_Samp_4]').removeAttr("disabled", "disabled");

            //$('input[name=AS1_Q1_1]').removeAttr("disabled", "disabled");
            //$("#AS1_Q1_2").removeAttr("disabled", "disabled");
            //$('input[name=AS1_Q2_1]').removeAttr("disabled", "disabled");
            //$("#AS1_Q2_2").removeAttr("disabled", "disabled");
            //$('input[name=AS1_Q3]').removeAttr("disabled", "disabled");
            //$('input[name=AS1_Q3a_1]').removeAttr("disabled", "disabled");
            //$("#AS1_Q3a_2").removeAttr("disabled", "disabled");
            //$("#AS1_Q4").removeAttr("disabled", "disabled");
            //$("#AS1_Q5").removeAttr("disabled", "disabled");
            //$("#AS1_Q6").removeAttr("disabled", "disabled");
            //$("#AS1_Q7").removeAttr("disabled", "disabled");
            //$('input[name=AS2_Q7_11]').removeAttr("disabled", "disabled");
            //$("#AS2_Q7_2").removeAttr("disabled", "disabled");
            //$('input[name=AS2_Q8]').removeAttr("disabled", "disabled");
            //$('input[name=AS2_Q8a]').removeAttr("disabled", "disabled");
            //$("#AS2_Q8_3").removeAttr("disabled", "disabled");

            //$("#AS2_Q8a").removeAttr("disabled", "disabled");
            //$("#AS2_Q9").removeAttr("disabled", "disabled");
            //$("#AS2_Q10").removeAttr("disabled", "disabled");
            //$('input[name=AS2_Q11]').removeAttr("disabled", "disabled");

            //$("#AS2_Q12_1").removeAttr("disabled", "disabled");
            //$("#AS2_Q12_2").removeAttr("disabled", "disabled");
            //$("#AS2_Q12_3").removeAttr("disabled", "disabled");
            //$("#AS2_Q12_4").removeAttr("disabled", "disabled");

            //$("#AS2_Q13").removeAttr("disabled", "disabled");
            //$("#AS3_Q14").removeAttr("disabled", "disabled");
            //$("#AS3_Q15").removeAttr("disabled", "disabled");
            //$("#AS3_Q16").removeAttr("disabled", "disabled");
            //$("#AS3_Q17").removeAttr("disabled", "disabled");
            //$("#AS3_Q18").removeAttr("disabled", "disabled");
            //$("#AS3_Q19").removeAttr("disabled", "disabled");
            //$("#AS3_Q20").removeAttr("disabled", "disabled");
            //$("#AS3_Remarks").removeAttr("disabled", "disabled");
            //$("#AS3_A1").removeAttr("disabled", "disabled");
            //$("#AS3_A2").removeAttr("disabled", "disabled");
            //$("#AS3_B1").removeAttr("disabled", "disabled");
            //$("#AS3_B2").removeAttr("disabled", "disabled");

            $("#cmdSave").show();
            $("#AS1_screening_ID").val("");
            $("#AS1_screening_ID").focus();

        });

        function getCookie(name) {
            var nameEQ = name + "=";
            var ca = document.cookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) == ' ') c = c.substring(1, c.length);
                if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
            }
            return null;
        }


        $(document).on("blur", "#AS1_screening_ID", function (e) {


            if ($('#AS1_screening_ID').val() != "__-_-____") {

                $
                    .ajax({
                        url: "sample_results.aspx/CheckScreeningID",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: "{ screeningid: '" + $('#AS1_screening_ID').val() + "', labid: '" + getCookie("labid") + "'}",

                        success: function (data) {

                            if (data.d == "") {

                                EnableControls_Loop();

                                //$("#AS1_rand_id").removeAttr("disabled");
                                //$("#AS1_name").removeAttr("disabled", "disabled");
                                //$('input[name=AS1_sex]').removeAttr("disabled", "disabled");
                                //$("#AS1_age").removeAttr("disabled", "disabled");
                                //$("#AS1_barcode").removeAttr("disabled", "disabled");
                                //$('input[name=AS1_fsite]').removeAttr("disabled", "disabled");
                                //$('input[name=AS1_Samp_1]').removeAttr("disabled", "disabled");
                                //$('input[name=AS1_Samp_2]').removeAttr("disabled", "disabled");
                                //$('input[name=AS1_Samp_3]').removeAttr("disabled", "disabled");
                                //$('input[name=AS1_Samp_4]').removeAttr("disabled", "disabled");

                                //$('input[name=AS1_Q1_1]').removeAttr("disabled", "disabled");
                                //$("#AS1_Q1_2").removeAttr("disabled", "disabled");
                                //$('input[name=AS1_Q2_1]').removeAttr("disabled", "disabled");
                                //$("#AS1_Q2_2").removeAttr("disabled", "disabled");
                                //$('input[name=AS1_Q3]').removeAttr("disabled", "disabled");
                                //$('input[name=AS1_Q3a_1]').removeAttr("disabled", "disabled");
                                //$("#AS1_Q3a_2").removeAttr("disabled", "disabled");
                                //$("#AS1_Q4").removeAttr("disabled", "disabled");
                                //$("#AS1_Q5").removeAttr("disabled", "disabled");
                                //$("#AS1_Q6").removeAttr("disabled", "disabled");
                                //$("#AS1_Q7").removeAttr("disabled", "disabled");
                                //$('input[name=AS2_Q7_11]').removeAttr("disabled", "disabled");
                                //$("#AS2_Q7_2").removeAttr("disabled", "disabled");
                                //$('input[name=AS2_Q8]').removeAttr("disabled", "disabled");
                                //$('input[name=AS2_Q8a]').removeAttr("disabled", "disabled");
                                //$("#AS2_Q8_3").removeAttr("disabled", "disabled");

                                //$("#AS2_Q8a").removeAttr("disabled", "disabled");
                                //$("#AS2_Q9").removeAttr("disabled", "disabled");
                                //$("#AS2_Q10").removeAttr("disabled", "disabled");
                                //$('input[name=AS2_Q11]').removeAttr("disabled", "disabled");

                                //$("#AS2_Q12_1").removeAttr("disabled", "disabled");
                                //$("#AS2_Q12_2").removeAttr("disabled", "disabled");
                                //$("#AS2_Q12_3").removeAttr("disabled", "disabled");
                                //$("#AS2_Q12_4").removeAttr("disabled", "disabled");

                                //$("#AS2_Q13").removeAttr("disabled", "disabled");
                                //$("#AS3_Q14").removeAttr("disabled", "disabled");
                                //$("#AS3_Q15").removeAttr("disabled", "disabled");
                                //$("#AS3_Q16").removeAttr("disabled", "disabled");
                                //$("#AS3_Q17").removeAttr("disabled", "disabled");
                                //$("#AS3_Q18").removeAttr("disabled", "disabled");
                                //$("#AS3_Q19").removeAttr("disabled", "disabled");
                                //$("#AS3_Q20").removeAttr("disabled", "disabled");
                                //$("#AS3_Remarks").removeAttr("disabled", "disabled");
                                //$("#AS3_A1").removeAttr("disabled", "disabled");
                                //$("#AS3_A2").removeAttr("disabled", "disabled");
                                //$("#AS3_B1").removeAttr("disabled", "disabled");
                                //$("#AS3_B2").removeAttr("disabled", "disabled");

                                $("#cmdSave").show();

                                $("#AS1_rand_id").focus();

                            } else {
                                alert("Screening id already exists");

                                DisableControls_Loop();

                                //$("#AS1_rand_id").attr("disabled", "disabled");
                                //$("#AS1_name").attr("disabled", "disabled");
                                //$('input[name=AS1_sex]').attr("disabled", "disabled");
                                //$("#AS1_age").attr("disabled", "disabled");
                                //$("#AS1_barcode").attr("disabled", "disabled");
                                //$('input[name=AS1_fsite]').attr("disabled", "disabled");
                                //$('input[name=AS1_Samp_1]').attr("disabled", "disabled");
                                //$('input[name=AS1_Samp_2]').attr("disabled", "disabled");
                                //$('input[name=AS1_Samp_3]').attr("disabled", "disabled");
                                //$('input[name=AS1_Samp_4]').attr("disabled", "disabled");
                                //$('input[name=AS1_Q1_1]').attr("disabled", "disabled");
                                //$("#AS1_Q1_2").attr("disabled", "disabled");
                                //$('input[name=AS1_Q2_1]').attr("disabled", "disabled");
                                //$("#AS1_Q2_2").attr("disabled", "disabled");
                                //$('input[name=AS1_Q3]').attr("disabled", "disabled");
                                //$('input[name=AS1_Q3a_1]').attr("disabled", "disabled");
                                //$("#AS1_Q3a_2").attr("disabled", "disabled");
                                //$("#AS1_Q4").attr("disabled", "disabled");
                                //$("#AS1_Q5").attr("disabled", "disabled");
                                //$("#AS1_Q6").attr("disabled", "disabled");
                                //$("input[name=AS2_Q7_1]").attr("disabled", "disabled");
                                //$("#AS2_Q7_2").attr("disabled", "disabled");
                                //$('input[name=AS2_Q8]').attr("disabled", "disabled");
                                //$('input[name=AS2_Q8a]').attr("disabled", "disabled");
                                //$("#AS2_Q8_3").attr("disabled", "disabled");

                                //$("#input[name=AS2_Q8a]").attr("disabled", "disabled");
                                //$("#AS2_Q9").attr("disabled", "disabled");
                                //$("#AS2_Q10").attr("disabled", "disabled");
                                //$('input[name=AS2_Q11]').attr("disabled", "disabled");

                                //$("#AS2_Q12_1").attr("disabled", "disabled");
                                //$("#AS2_Q12_2").attr("disabled", "disabled");
                                //$("#AS2_Q12_3").attr("disabled", "disabled");
                                //$("#AS2_Q12_4").attr("disabled", "disabled");

                                //$("#AS2_Q13").attr("disabled", "disabled");
                                //$("#AS3_Q14").attr("disabled", "disabled");
                                //$("#AS3_Q15").attr("disabled", "disabled");
                                //$("#AS3_Q16").attr("disabled", "disabled");
                                //$("#AS3_Q17").attr("disabled", "disabled");
                                //$("#AS3_Q18").attr("disabled", "disabled");
                                //$("#AS3_Q19").attr("disabled", "disabled");
                                //$("#AS3_Q20").attr("disabled", "disabled");
                                //$("#AS3_Remarks").attr("disabled", "disabled");
                                //$("#AS3_A1").attr("disabled", "disabled");
                                //$("#AS3_A2").attr("disabled", "disabled");
                                //$("#AS3_B1").attr("disabled", "disabled");
                                //$("#AS3_B2").attr("disabled", "disabled");

                                $("#cmdSave").hide();
                            }

                        },
                        error: function (
                            xhr,
                            ajaxOptions,
                            thrownError) {

                            alert('Error: ');

                        }
                    });

            }


        });

    </script>

    <script>

        function ValidateForm() {

            if ($("#AS1_screening_ID").val() == "__-_-____") {
                alert("Please enter valid screening id");
                $("#AS1_screening_ID").focus();
                return false;
            }
            else if ($("#AS1_screening_ID").val().indexOf("_") != -1) {
                alert("Please enter full screening id");
                $("#AS1_screening_ID").focus();
                return false;
            }
            else if ($("#AS1_rand_id").val() == "_-_-_-____") {
                alert("Please enter valid randomization id");
                $("#AS1_rand_id").focus();
                return false;
            }
            else if ($("#AS1_rand_id").val().indexOf("_") != -1) {
                alert("Please enter full randomization id");
                $("#AS1_rand_id").focus();
                return false;
            }
            else if ($("#AS1_name").val() == "") {
                alert("Please enter name ");
                $("#AS1_name").focus();
                return false;
            }
            else if ($('input[name=AS1_sex]:checked').length <= 0) {
                alert("Please select gender");
                $("#AS1_sex_a").focus();
                return false;
            }
            else if ($("#AS1_age").val() == "") {
                alert("Please enter age ");
                $("#AS1_age").focus();
                return false;
            }
            else if ($("#AS1_barcode").val() == "") {
                alert("Please enter sample id ");
                $("#AS1_barcode").focus();
                return false;
            }
            else if ($("#AS1_mrno").val() == "" && $("#AS1_mrno").is(":visible") == true
                && $("#AS1_mrno").is(":disabled") == false) {
                alert("Please enter MR No. ");
                $("#AS1_mrno").focus();
                return false;
            }
            else if ($("#AS1_mrno").val() == "_-_-_-____" && $("#AS1_mrno").is(":visible") == true
                && $("#AS1_mrno").is(":disabled") == false) {
                alert("Please enter valid MR No");
                $("#AS1_mrno").focus();
                return false;
            }
            else if ($("#AS1_mrno").val().indexOf("_") != -1 && $("#AS1_mrno").is(":visible") == true
                && $("#AS1_mrno").is(":disabled") == false) {
                alert("Please enter full MR No");
                $("#AS1_mrno").focus();
                return false;
            }
            else if ($("#AS1_lno").val() == "" && $("#AS1_lno").is(":visible") == true
                && $("#AS1_lno").is(":disabled") == false) {
                alert("Please enter L Number ");
                $("#AS1_lno").focus();
                return false;
            }
            else if ($("#AS1_barcode1").val() == "") {
                alert("Please enter form Barcode ");
                $("#AS1_barcode1").focus();
                return false;
            }
            else if ($("#AS1_barcode1").val() == "__-_-_-_-____") {
                alert("Please enter valid form Barcode ");
                $("#AS1_barcode1").focus();
                return false;
            }
            else if ($("#AS1_barcode1").val().indexOf("_") != -1) {
                alert("Please enter full form Barcode ");
                $("#AS1_barcode1").focus();
                return false;
            }
            else if ($('input[name=AS1_fsite]:checked').length <= 0) {
                alert("Please select field site hospital");
                $("#AS1_fsite_1").focus();
                return false;
            }
            else if ($('input[name=AS1_Samp_1]:checked').length <= 0
                && $('input[name=AS1_Samp_2]:checked').length <= 0
                && $('input[name=AS1_Samp_3]:checked').length <= 0
                && $('input[name=AS1_Samp_4]:checked').length <= 0
                && $('input[name=AS1_Samp_5]:checked').length <= 0
                && $('input[name=AS1_Samp_6]:checked').length <= 0
            ) {
                alert("Please select sample collected ");

                if ($("#AS1_Samp_1").is(':visible') == true) {
                    $("#AS1_Samp_1").focus();
                }
                else if ($("#AS1_Samp_4").is(':visible') == true) {
                    $("#AS1_Samp_4").focus();
                }

                return false;
            }
            else if ($('input[name=AS1_Q1_1]:checked').length <= 0
                && ($("#AS1_Q1_11").is(":visible") == true || $("#AS1_Q1_12").is(":visible") == true)) {
                alert("Please select CBC Sample Collected In EDTA tube ");
                $("#AS1_Q1_11").focus();
                return false;
            }
            else if ($("#AS1_Q1_2").val() == "" && ($("#AS1_Q1_2").is(":visible") == true)) {
                alert("Please enter Volume of blood for CBC mL ");
                $("#AS1_Q1_2").focus();
                return false;
            }
            else if ($('input[name=AS1_Q2_1]:checked').length <= 0
                && ($("#AS1_Q2_11").is(":visible") == true || $("#AS1_Q2_12").is(":visible") == true)) {
                alert("Please select Blood Culture Sample collection ");
                $("#AS1_Q2_11").focus();
                return false;
            }
            else if ($("#AS1_Q2_2").val() == "" && ($("#AS1_Q2_2").is(":visible") == true)) {
                alert("Please enter Volume of blood in Paeds BacT Alert Paeds bottle ml ");
                $("#AS1_Q2_2").focus();
                return false;
            }
            else if ($('input[name=AS1_Q3]:checked').length <= 0
                && ($("#AS1_Q3_1").is(":visible") == true || $("#AS1_Q3_2").is(":visible") == true)) {
                alert("Please select Metagenomics Sample collection ");
                $("#AS1_Q3_1").focus();
                return false;
            }
            else if ($('input[name=AS1_Q3a_1]:checked').length <= 0
                && ($("#AS1_Q3a_11").is(":visible") == true || $("#AS1_Q3a_12").is(":visible") == true)) {
                alert("Please select CRP Sample Collected In Gel tube ");
                $("#AS1_Q3a_11").focus();
                return false;
            }
            else if ($("#AS1_Q3a_2").val() == "" && $("#AS1_Q3a_2").is(":visible") == true) {
                alert("Please enter Volume of blood for Metagenomics");
                $("#AS1_Q3a_2").focus();
                return false;
            }
            else if ($("#AS1_Q4").val() == "" && $("#AS1_Q4").is(":visible") == true) {
                alert("Please enter collection time ");
                $("#AS1_Q4").focus();
                return false;
            }
            else if ($("#AS1_Q5").val() == "" && $("#AS1_Q5").is(":visible") == true) {
                alert("Please enter collection date ");
                $("#AS1_Q5").focus();
                return false;
            }
            else if ($("#AS1_Q6").val() == "" && $("#AS1_Q6").is(":visible") == true) {
                alert("Please enter Time of Serum separation ");
                $("#AS1_Q6").focus();
                return false;
            }
            else if ($("#AS1_Q6a").val() == "" && $("#AS1_Q6a").is(":visible") == true) {
                alert("Please enter No. of Aliquots made ");
                $("#AS1_Q6a").focus();
                return false;
            }
            else if ($("#AS1_Q6b").val() == "" && $("#AS1_Q6b").is(":visible") == true) {
                alert("Please enter Volume in each aliquot ");
                $("#AS1_Q6b").focus();
                return false;
            }
            else if ($("#AS1_Q6c").val() == "" && $("#AS1_Q6c").is(":visible") == true) {
                alert("Please enter Time of sample handed over to NRL ");
                $("#AS1_Q6c").focus();
                return false;
            }
            else if ($('input[name=AS2_Q7_1]:checked').length <= 0
                && ($("#AS2_Q7_11").is(":visible") == true || $("#AS2_Q7_12").is(":visible") == true)) {
                alert("Please select CBC EDTA tube Received ");
                $("#AS2_Q7_11").focus();
                return false;
            }
            else if ($("#AS2_Q7_2a").val() == "___-__-__" && $("#AS2_Q7_2a").is(":visible") == true
                && $("#AS2_Q7_2a").is(":disabled") == false) {
                alert("Please enter valid CBC EDTA tube Charged at AKU clinical lab (MR Number) ");
                $("#AS2_Q7_2a").focus();
                return false;
            }
            else if ($("#AS2_Q7_2").val() == "" && $("#AS2_Q7_2").is(":visible") == true
                && $("#AS2_Q7_2").is(":disabled") == false) {
                alert("Please enter CBC EDTA tube Charged at AKU clinical lab (L Number) ");
                $("#AS2_Q7_2").focus();
                return false;
            }
            else if ($("#AS2_Q7_CBC_CODE").val() == "" && $("#AS2_Q7_CBC_CODE").is(":visible") == true) {
                alert("Please enter CBC EDTA tube barcode ");
                $("#AS2_Q7_CBC_CODE").focus();
                return false;
            }
            else if ($("#AS2_Q7_CBC_CODE").val() == "__-_-_-_-____" && $("#AS2_Q7_CBC_CODE").is(":visible") == true) {
                alert("Please enter valid sample id ");
                $("#AS2_Q7_CBC_CODE").focus();
                return false;
            }
            else if ($('input[name=AS2_Q8]:checked').length <= 0
                && ($("#AS2_Q8_1").is(":visible") == true || $("#AS2_Q8_2").is(":visible") == true)) {
                alert("Please select BacT Alert Paeds Bottle Received (Difference : Weight Before – Weight after) ");
                $("#AS2_Q8_1").focus();
                return false;
            }
            else if ($("#AS2_Q8_BacT").val() == "" && $("#AS2_Q8_BacT").is(":visible") == true) {
                alert("Please enter BacT Alert Paeds Bottle Bar Code ");
                $("#AS2_Q8_BacT").focus();
                return false;
            }
            else if ($("#AS2_Q8_3").val() == "" && $("#AS2_Q8_3").is(":visible") == true) {
                alert("Please enter Weight in gm ");
                $("#AS2_Q8_3").focus();
                return false;
            }
            else if ($('input[name=AS2_Q8a]:checked').length <= 0 && ($("#AS2_Q8a_1").is(":visible") == true ||
                $("#AS2_Q8a_2").is(":visible") == true)) {
                alert("Please select CRP Gel tube Received ");
                $("#AS2_Q8a_1").focus();
                return false;
            }
            else if ($("#AS2_Q9").val() == "" && $("#AS2_Q9").is(":visible") == true) {
                alert("Please enter date received ");
                $("#AS2_Q9").focus();
                return false;
            }
            else if ($("#AS2_Q10").val() == "" && $("#AS2_Q10").is(":visible") == true) {
                alert("Please enter time received ");
                $("#AS2_Q10").focus();
                return false;
            }
            else if ($('input[name=AS2_Q11]:checked').length <= 0 && ($('#AS2_Q11_1').is(':visible') == true ||
                $('#AS2_Q11_2').is(':visible') == true)) {
                alert("Please enter Condition of sample container received ");
                $("#AS2_Q11_1").focus();
                return false;
            }
            else if ($("#AS2_Q12_1").val() == "" && $("#AS2_Q12_1").is(":visible") == true) {
                alert("Please enter Temperature of the Coleman upon arrival at the lab (CBC tube)  ");
                $("#AS2_Q12_1").focus();
                return false;
            }
            else if ($("#AS2_Q12_2").val() == "" && $("#AS2_Q12_2").is(":visible") == true) {
                alert("Please enter Temperature of the Coleman upon arrival at the lab (BacT Alert Peads bottle)  ");
                $("#AS2_Q12_2").focus();
                return false;
            }
            else if ($("#AS2_Q12_3").val() == "" && $("#AS2_Q12_3").is(":visible") == true) {
                alert("Please enter Temperature of the Coleman upon arrival at the lab (Metagenomics)  ");
                $("#AS2_Q12_3").focus();
                return false;
            }
            else if ($("#AS2_Q12_4").val() == "" && $("#AS2_Q12_4").is(":visible") == true) {
                alert("Please enter Temperature of the Coleman upon arrival at the lab (CRP Gel tube)  ");
                $("#AS2_Q12_4").focus();
                return false;
            }
            else if ($("#AS2_Q13").val() == "" && $("#AS2_Q13").is(":visible") == true) {
                alert("Please enter Name of the laboratory person receiving the sample ");
                $("#AS2_Q13").focus();
                return false;
            }
            else if ($("#AS2_Q13a").val() == "" && $("#AS2_Q13a").is(":visible") == true) {
                alert("Please enter Time result reported (must be within 20 min - 2 hours of sample receiving) ");
                $("#AS2_Q13a").focus();
                return false;
            }
            else if ($("#AS3_Q14").val() == "" && $("#AS3_Q14").is(":visible") == true) {
                alert("Please enter Name of IDRL laboratory person receiving the sample ");
                $("#AS3_Q14").focus();
                return false;
            }
            else if ($("#AS3_Q14a").val() == "" && $("#AS3_Q14a").is(":visible") == true) {
                alert("Please enter Date received (dd/mm/yyyy) ");
                $("#AS3_Q14a").focus();
                return false;
            }
            else if ($("#AS3_Q15").val() == "" && $("#AS3_Q15").is(":visible") == true) {
                alert("Please enter Time received ");
                $("#AS3_Q15").focus();
                return false;
            }
            else if ($("#AS3_Q16").val() == "" && $("#AS3_Q16").is(":visible") == true && $("#AS3_Q16").is(":disabled") == false) {
                alert("Please enter Temperature of the Coleman upon arrival at the lab ");
                $("#AS3_Q16").focus();
                return false;
            }
            else if ($("#AS3_Q17").val() == "" && $("#AS3_Q17").is(":visible") == true && $("#AS3_Q17").is(":disabled") == false) {
                alert("Please enter Time of Serum separation ");
                $("#AS3_Q17").focus();
                return false;
            }
            else if ($("#AS3_Q18").val() == "" && $("#AS3_Q18").is(":visible") == true && $("#AS3_Q18").is(":disabled") == false) {
                alert("Please enter No. of Aliquots made ");
                $("#AS3_Q18").focus();
                return false;
            }
            else if ($("#AS3_Q19").val() == "" && $("#AS3_Q19").is(":visible") == true && $("#AS3_Q19").is(":disabled") == false) {
                alert("Please enter Volume in each aliquot ");
                $("#AS3_Q19").focus();
                return false;
            }
            else if ($("#AS3_Q20").val() == "" && $("#AS3_Q20").is(":visible") == true && $("#AS3_Q20").is(":disabled") == false) {
                alert("Please enter Time Aliquots placed in ULT Freezer ");
                $("#AS3_Q20").focus();
                return false;
            }
            else if ($('input[name=AS4_Q21a]:checked').length <= 0 && ($('#AS4_Q21a').is(':visible') == true)) {
                alert("Please select CRP Sample Collected in Capillary ");
                $("#AS4_Q21a").focus();
                return false;
            }
            else if ($("#AS4_Q22a").val() == "" && $("#AS4_Q22a").is(":visible") == true) {
                alert("Please enter Collection time (hh:mm 24 hr clock) ");
                $("#AS4_Q22a").focus();
                return false;
            }
            else if ($("#AS4_Q22b").val() == "" && $("#AS4_Q22b").is(":visible") == true) {
                alert("Please enter Collection date (dd/mm/yy) ");
                $("#AS4_Q22b").focus();
                return false;
            }
            else if ($("#AS4_Q23").val() == "" && $("#AS4_Q23").is(":visible") == true) {
                alert("Please enter Name of Phlebotomist ");
                $("#AS4_Q23").focus();
                return false;
            }
            else if ($("#AS4_Q24").val() == "" && $("#AS4_Q24").is(":visible") == true) {
                alert("Please enter Time of test performed (hh:mm 24 hr clock) ");
                $("#AS4_Q24").focus();
                return false;
            }
            else if ($("#AS5_Q25a").val() == "" && $("#AS5_Q25a").is(":visible") == true && $("#AS5_Q25a").attr("disabled") != "disabled") {
                alert("Please enter Name of staff CRP Performed ");
                $("#AS5_Q25a").focus();
                return false;
            }
            else if ($("#AS5_Q25b").val() == "" && $("#AS5_Q25b").is(":visible") == true && $("#AS5_Q25b").attr("disabled") != "disabled") {
                alert("Please enter Code of staff CRP Performed ");
                $("#AS5_Q25b").focus();
                return false;
            }
            else if ($("#AS5_Q26").val() == "" && $("#AS5_Q26").is(":visible") == true && $("#AS5_Q26").attr("disabled") != "disabled") {
                alert("Please enter Kit Lot Number ");
                $("#AS5_Q26").focus();
                return false;
            }
            else if ($('input[name=AS5_Q27]:checked').length <= 0 && ($('#AS5_Q27_1').is(':visible') == true && $('#AS5_Q27_1').attr("disabled") != "disabled" ||
                $('#AS5_Q27_2').is(':visible') == true && $('#AS5_Q27_2').attr("disabled") != "disabled")) {
                alert("Please enter Kit Quality Control ");
                $("#AS5_Q27_1").focus();
                return false;
            }
            else if ($('input[name=AS5_Q28]:checked').length <= 0 && ($('#AS5_Q28_1').is(':visible') == true && $('#AS5_Q28_1').attr("disabled") != "disabled" ||
                $('#AS5_Q28_2').is(':visible') == true && $('#AS5_Q28_2').attr("disabled") != "disabled")) {
                alert("Please enter Kit brought to Room Temperature for 30 minutes ");
                $("#AS5_Q28_1").focus();
                return false;
            }
            else if ($('input[name=AS5_Q29]:checked').length <= 0 && ($('#AS5_Q29_1').is(':visible') == true &&
                $('#AS5_Q29_1').attr("disabled") != "disabled" ||
                $('#AS5_Q29_2').is(':visible') == true && $('#AS5_Q29_2').attr("disabled" != "disabled") ||
                $('#AS5_Q29_3').is(':visible') == true && $('#AS5_Q29_3').attr("disabled" != "disabled"))) {
                alert("Please enter CRP Control line Result (test device) ");
                $("#AS5_Q29_1").focus();
                return false;
            }
            else if ($('input[name=AS5_Q30]:checked').length <= 0 && ($('#AS5_Q30_1').is(':visible') == true && $('#AS5_Q30_1').attr("disabled") != "disabled" ||
                $('#AS5_Q30_2').is(':visible') == true && $('#AS5_Q30_2').attr("disabled") != "disabled" ||
                $('#AS5_Q30_3').is(':visible') == true && $('#AS5_Q30_3').attr("disabled") != "disabled")) {
                alert("Please enter CRP Test Line ");
                $("#AS5_Q30_1").focus();
                return false;
            }
            else if ($('input[name=AS5_Q31]:checked').length <= 0 && ($('#AS5_Q31_1').is(':visible') == true && $('#AS5_Q31_1').attr("disabled") != "disabled" ||
                $('#AS5_Q31_2').is(':visible') == true && $('#AS5_Q31_2').attr("disabled") != "disabled" ||
                $('#AS5_Q31_3').is(':visible') == true && $('#AS5_Q31_3').attr("disabled") != "disabled" ||
                $('#AS5_Q31_4').is(':visible') == true && $('#AS5_Q31_4').attr("disabled") != "disabled")) {
                alert("Please enter CRP Test Level ");
                $("#AS5_Q31_1").focus();
                return false;
            }
            else if ($('input[name=AS5_Q32]:checked').length <= 0 && ($('#AS5_Q32_1').is(':visible') == true && $('#AS5_Q32_1').attr("disabled") != "disabled" ||
                $('#AS5_Q32_2').is(':visible') == true && $('#AS5_Q32_2').attr("disabled") != "disabled" ||
                $('#AS5_Q32_3').is(':visible') == true && $('#AS5_Q32_3').attr("disabled") != "disabled")) {
                alert("Please enter CRP (RDT) Result ");
                $("#AS5_Q32_1").focus();
                return false;
            }
            else if ($("#AS5_Q33a").val() == "" && $("#AS5_Q33a").is(":visible") == true && $("#AS5_Q33a").attr("disabled") != "disabled") {
                alert("Please enter Name of Staff Reading CRP (RDT) Result ");
                $("#AS5_Q33a").focus();
                return false;
            }
            else if ($("#AS5_Q33b").val() == "" && $("#AS5_Q33b").is(":visible") == true && $("#AS5_Q33b").attr("disabled") != "disabled") {
                alert("Please enter Code of Staff Reading CRP (RDT) Result ");
                $("#AS5_Q33b").focus();
                return false;
            }
            else if ($("#AS6_Q34").val() == "" && $("#AS6_Q34").is(":visible") == true) {
                alert("Please enter Urine DR ");
                $("#AS6_Q34").focus();
                return false;
            }
            else if ($("#AS6_Q35").val() == "" && $("#AS6_Q35").is(":visible") == true) {
                alert("Please enter Urine CS ");
                $("#AS6_Q35").focus();
                return false;
            }
            else if ($("#AS6_Q36").val() == "" && $("#AS6_Q36").is(":visible") == true) {
                alert("Please enter Serum Bilirubin (Adult) ");
                $("#AS6_Q36").focus();
                return false;
            }
            else if ($("#AS6_Q37").val() == "" && $("#AS6_Q37").is(":visible") == true) {
                alert("Please enter Liver function test (Serum) ");
                $("#AS6_Q37").focus();
                return false;
            }
            else if ($("#AS6_Q38").val() == "" && $("#AS6_Q38").is(":visible") == true) {
                alert("Please enter Urea ");
                $("#AS6_Q38").focus();
                return false;
            }
            else if ($("#AS6_Q39").val() == "" && $("#AS6_Q39").is(":visible") == true) {
                alert("Please enter Creatinine ");
                $("#AS6_Q39").focus();
                return false;
            }
            else if ($("#AS6_Q40").val() == "" && $("#AS6_Q40").is(":visible") == true) {
                alert("Please enter Electrolytes ");
                $("#AS6_Q40").focus();
                return false;
            }
            else if ($("#AS6_Q41").val() == "" && $("#AS6_Q41").is(":visible") == true) {
                alert("Please enter CSF DR ");
                $("#AS6_Q41").focus();
                return false;
            }
            else if ($("#AS6_Q42").val() == "" && $("#AS6_Q42").is(":visible") == true) {
                alert("Please enter CSF CS ");
                $("#AS6_Q42").focus();
                return false;
            }
            else if ($("#AS6_Q43").val() == "" && $("#AS6_Q43").is(":visible") == true) {
                alert("Please enter Chest Xray ");
                $("#AS6_Q43").focus();
                return false;
            }
            else if ($("#AS6_Q44").val() == "" && $("#AS6_Q44").is(":visible") == true) {
                alert("Please enter Ultrasound whole abdomen ");
                $("#AS6_Q44").focus();
                return false;
            }
            else if ($("#AS6_Q45").val() == "" && $("#AS6_Q45").is(":visible") == true) {
                alert("Please enter Ultrasound upper abdomen ");
                $("#AS6_Q45").focus();
                return false;
            }
            else if ($("#AS6_Q46").val() == "" && $("#AS6_Q46").is(":visible") == true) {
                alert("Please enter Ultrasound pelvis ");
                $("#AS6_Q46").focus();
                return false;
            }
            else if ($("#AS6_Q47").val() == "" && $("#AS6_Q47").is(":visible") == true) {
                alert("Please enter Ultrasound brain ");
                $("#AS6_Q47").focus();
                return false;
            }
            else if ($("#AS3_A1").val() == "" && $("#AS3_A1").is(":visible") == true) {
                alert("Please enter Form checked by PSBI Laboratory Person ");
                $("#AS3_A1").focus();
                return false;
            }
            else if ($("#AS3_A2").val() == "" && $("#AS3_A2").is(":visible") == true) {
                alert("Please enter date of Form checked by PSBI Laboratory Person ");
                $("#AS3_A2").focus();
                return false;
            }
            else if ($("#AS3_B1").val() == "" && $("#AS3_B1").is(":visible") == true) {
                alert("Please enter Form checked by PSBI Study Physician ");
                $("#AS3_B1").focus();
                return false;
            }
            else if ($("#AS3_B2").val() == "" && $("#AS3_B2").is(":visible") == true) {
                alert("Please enter date of Form checked by PSBI Study Physician ");
                $("#AS3_B2").focus();
                return false;
            }
            else if ($("#AS1_age").val() != "") {

                if (eval($("#AS1_age").val()) < 0 && eval($("#AS1_age").val()) > 59) {
                    alert("Age must be 0 - 59 days ");
                    $("#AS1_age").focus();
                    return false;
                }
                else {

                    if ($("#AS2_Q7_2a").val() != "" && $("#AS2_Q7_2a").is(":visible") == true) {

                        if ($("#AS2_Q7_2a").val().indexOf("_") != -1) {
                            alert("Please enter full (MR Number) 3 ");
                            $("#AS2_Q7_2a").focus();
                            return false;
                        }
                        else {

                            if ($("#AS2_Q7_CBC_CODE").val() != "" && $("#AS2_Q7_CBC_CODE").is(":visible") == true) {

                                if ($("#AS2_Q7_CBC_CODE").val().indexOf("_") != -1) {
                                    alert("Please enter full sample id");
                                    $("#AS2_Q7_CBC_CODE").focus();
                                    return false;
                                }
                            }

                        }
                    }

                }
            }


            return true;

        }

    </script>
</head>
<body class="vertical-layout vertical-menu 2-columns fixed-navbar" data-open="click" data-menu="vertical-menu" data-color="bg-blue" data-col="2-columns">
    <form id="form1" name="form1" runat="server" autocomplete="off" enctype="multipart/form-data">
        <!-- BEGIN: Header-->
        <nav class="header-navbar navbar-expand-md navbar navbar-with-menu navbar-without-dd-arrow fixed-top navbar-semi-light">
            <div class="navbar-wrapper">
                <div class="navbar-container content">
                    <div class="collapse navbar-collapse show" id="navbar-mobile">
                        <ul class="nav navbar-nav mr-auto float-left">
                            <li class="nav-item mobile-menu d-md-none mr-auto"><a class="nav-link nav-menu-main menu-toggle hidden-xs" href="#"><i class="ft-menu font-large-1"></i></a></li>
                            <li class="nav-item d-none d-md-block"><a class="nav-link nav-menu-main menu-toggle hidden-xs" href="#"><i class="ft-menu"></i></a></li>
                            <li class="nav-item d-none d-md-block"><a class="nav-link nav-link-expand" href="#"><i class="ficon ft-maximize"></i></a></li>
                        </ul>
                        <ul class="nav navbar-nav float-right">
                            <li class="dropdown dropdown-language nav-item"><a class="dropdown-toggle nav-link" id="dropdown-flag" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <asp:LinkButton ID="usernme" name="usernme" runat="server" CssClass="dropdown-toggle nav-link"><i class="ft-power"></i>Welcome:</asp:LinkButton>
                            </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </nav>
        <!-- END: Header-->
        <!-- BEGIN: Main Menu-->
        <div class="main-menu menu-fixed menu-light menu-accordion    menu-shadow " data-scroll-to-active="true" data-img="Content/demo/chameleon-admin-template/app-assets/images/backgrounds/02.jpg">
            <div class="navbar-header">
                <ul class="nav navbar-nav flex-row">
                    <li class="nav-item mr-auto"><a class="navbar-brand" href="default.aspx">
                        <h3 class="brand-text">Sample Forms</h3>
                    </a></li>
                    <li class="nav-item d-md-none"><a class="nav-link close-navbar"><i class="ft-x"></i></a></li>
                </ul>
            </div>
            <div class="navigation-background"></div>
            <div class="main-menu-content">
                <ul class="navigation navigation-main" id="main-menu-navigation" data-menu="menu-navigation">

                    <% if (HttpContext.Current.Request.Cookies["labid"].Value == "3")
                        { %>

                    <li class="nav-item"><a href="sample_recv.aspx"><span style="font-family: Verdana">Sample Receiving</span></a>
                    </li>
                    <li class="nav-item"><a href="sample_results.aspx"><span class="menu-title" data-i18n=""><span style="font-family: Verdana">Lab Results</span></span></a></li>                    
                    <li class="nav-item"><a href="search_sample.aspx"><span class="menu-title" data-i18n=""><span style="font-family: Verdana">Search Record</span></span></a></li>
                    <li class="nav-item">
                        <asp:LinkButton Style="font-family: Verdana" runat="server" OnClick="Unnamed_Click">Logout</asp:LinkButton>
                    </li>

                    <% }
                        else if (HttpContext.Current.Request.Cookies["labid"].Value == "2")
                        { %>

                    <li class="nav-item"><a href="sample_recv.aspx"><span style="font-family: Verdana">Sample Receiving</span></a>
                    </li>
                    <li class="nav-item"><a href="sample_results.aspx"><span style="font-family: Verdana">Lab Results</span></a></li>                    
                    <li class="nav-item">
                        <asp:LinkButton runat="server" Style="font-family: Verdana" OnClick="Unnamed_Click">Logout</asp:LinkButton>
                    </li>

                    <% }
                        else
                        { %>

                    <li class="nav-item"><a href="sample_recv.aspx"><span style="font-family: Verdana">Sample Receiving</span></a></li>
                    <li class="nav-item"><a href="sample_results.aspx"><span style="font-family: Verdana">Lab Results</span></a></li>                    
                    <li class="nav-item"><a href="search_sample.aspx"><span class="menu-title" data-i18n=""><span style="font-family: Verdana">Search Record</span></span></a></li>
                    <li class="nav-item">
                        <asp:LinkButton runat="server" Style="font-family: Verdana" OnClick="Unnamed_Click">Logout</asp:LinkButton>
                    </li>

                    <% } %>
                </ul>
            </div>
        </div>
        <!-- END: Main Menu-->
        <!-- BEGIN: Content-->
        <div class="app-content content">
            <div class="content-wrapper">
                <div class="content-wrapper-before"></div>
                <div class="content-header row">
                    <div class="content-header-left col-12 mb-2">
                        <span style="font-family: Verdana; font-size: 1.6rem; color: white;">PSBI Lab Management System</span>
                    </div>
                </div>
                <div class="content-body">
                    <div class="content-body">
                        <!-- Basic form layout section start -->
                        <section id="horizontal-form-layouts">
                            <div class="row">
                                <div class="col-xl-6 col-lg-12">
                                    <div class="card">
                                        <div class="card-header">
                                            <h4 class="card-title" id="horz-layout-basic"></h4>
                                            <a class="heading-elements-toggle"><i class="la la-ellipsis-v font-medium-3"></i></a>
                                            <div class="heading-elements">
                                                <ul class="list-inline mb-0">
                                                    <%--<li><a data-action="collapse"><i class="ft-minus"></i></a></li>
                                    <li><a data-action="reload"><i class="ft-rotate-cw"></i></a></li>
                                    <li><a data-action="expand"><i class="ft-maximize"></i></a></li>
                                    <li><a data-action="close"><i class="ft-x"></i></a></li>--%>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="card-content collpase show">
                                            <div class="card-body">
                                                <div class="form-body">
                                                    <h4 class="form-section"><i class="ft-clipboard"></i>Sample Details</h4>
                                                    <br />
                                                    <div class="form-group row">
                                                        <div class="col-md-9">
                                                            <asp:Label runat="server" Style="color: #FF0000" ID="lblerr" name="lblerr"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Screening number</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox runat="server" ID="AS1_screening_ID" class="form-control" name="AS1_screening_ID" onkeypress="return numeralsOnly(event);"></asp:TextBox>
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="AS1_screening_ID" MaskType="Number" AutoComplete="false" ClearMaskOnLostFocus="false" Mask="99-9-9999" runat="server"></cc1:MaskedEditExtender>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Randomization ID</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox runat="server" ID="AS1_rand_id" MaxLength="10" class="form-control" name="AS1_rand_id" onkeypress="return numeralsOnly(event);"></asp:TextBox>
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" TargetControlID="AS1_rand_id" MaskType="Number" AutoComplete="false" ClearMaskOnLostFocus="false" Mask="9-9-9-9999" runat="server"></cc1:MaskedEditExtender>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Name</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox runat="server" ID="AS1_name" class="form-control" MaxLength="80" name="AS1_name" onkeypress="return lettersOnly_WithSpace(event);"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Gender</label>
                                                        <div class="col-md-6 col-sm-12">
                                                            <fieldset>
                                                                <asp:RadioButton runat="server" class=".radiocls1" GroupName="AS1_sex" name="input-radio-3" ID="AS1_sex_a" />
                                                                <label for="input-radio-11">Male</label>
                                                            </fieldset>
                                                            <fieldset>
                                                                <asp:RadioButton runat="server" class=".radiocls1" GroupName="AS1_sex" name="input-radio-3" ID="AS1_sex_b" />
                                                                <label for="input-radio-12">Female</label>
                                                            </fieldset>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Age (days)</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox runat="server" ID="AS1_age" MaxLength="2" class="form-control" name="AS1_age" onkeypress="return numeralsOnly(event);"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Specimen ID</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox runat="server" ID="AS1_barcode" class="form-control" MaxLength="50" name="AS1_barcode" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">MR No</label>
                                                        <div class="col-md-3">
                                                            <asp:TextBox runat="server" ID="AS1_mrno" class="form-control" MaxLength="50" name="AS1_mrno" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender3" TargetControlID="AS1_mrno" MaskType="Number" AutoComplete="false" ClearMaskOnLostFocus="false" Mask="999-99-99" runat="server"></cc1:MaskedEditExtender>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <asp:CheckBox ID="chkMRNo" name="chkMRNo" class=".radiocls3" runat="server" />
                                                            <label style="margin-top: 10px;">MR No not available</label>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">L Number</label>
                                                        <div class="col-md-3">
                                                            <asp:TextBox runat="server" ID="AS1_lno" class="form-control" MaxLength="50" name="AS1_lno" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <asp:CheckBox ID="chkLNumber" class=".radiocls3" runat="server" />
                                                            <label style="margin-top: 10px;">L Number not available</label>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Form Barcode ID</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox runat="server" ID="AS1_barcode1" class="form-control" MaxLength="50" name="AS1_barcode1" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender5" TargetControlID="AS1_barcode1" MaskType="Number" AutoComplete="false" ClearMaskOnLostFocus="false" Mask="LL-9-9-9-9999" runat="server"></cc1:MaskedEditExtender>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Field site hospital name</label>
                                                        <div class="col-md-6 col-sm-12">
                                                            <fieldset>
                                                                <asp:RadioButton runat="server" class=".radiocls2" GroupName="AS1_fsite" name="AS1_fsite_1" ID="AS1_fsite_1" />
                                                                <label for="input-radio-11">AKU Kharadar Hospital</label>
                                                            </fieldset>
                                                            <fieldset>
                                                                <asp:RadioButton runat="server" class=".radiocls2" GroupName="AS1_fsite" name="AS1_fsite_2" ID="AS1_fsite_2" />
                                                                <label for="input-radio-12">Sindh Govt. Children Hospital</label>
                                                            </fieldset>
                                                            <fieldset>
                                                                <asp:RadioButton runat="server" class=".radiocls2" GroupName="AS1_fsite" name="AS1_fsite_3" ID="AS1_fsite_3" />
                                                                <label for="input-radio-12">Liyari General Hospital</label>
                                                            </fieldset>
                                                            <fieldset>
                                                                <asp:RadioButton runat="server" class=".radiocls2" GroupName="AS1_fsite" name="AS1_fsite_4" ID="AS1_fsite_4" />
                                                                <label for="input-radio-12">Indus Korangi Hospital</label>
                                                            </fieldset>
                                                            <fieldset>
                                                                <asp:RadioButton runat="server" class=".radiocls2" GroupName="AS1_fsite" name="AS1_fsite_5" ID="AS1_fsite_5" />
                                                                <label for="input-radio-12">NICH</label>
                                                            </fieldset>
                                                            <fieldset>
                                                                <asp:RadioButton runat="server" class=".radiocls2" GroupName="AS1_fsite" name="AS1_fsite_6" ID="AS1_fsite_6" />
                                                                <label for="input-radio-12">Sheikh Saeed Memorial Hospital</label>
                                                            </fieldset>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Sample Collected</label>
                                                        <div class="col-md-6 col-sm-12">
                                                            <asp:Panel runat="server" ID="pnl_AS1_Samp_1">
                                                                <fieldset>
                                                                    <asp:CheckBox runat="server" class=".radiocls3" GroupName="AS1_Samp" name="AS1_Samp_1" ID="AS1_Samp_1" />
                                                                    <label for="input-radio-11">CBC</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:CheckBox runat="server" class=".radiocls3" GroupName="AS1_Samp" name="AS1_Samp_2" ID="AS1_Samp_2" />
                                                                    <label for="input-radio-12">Blood Culture</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:CheckBox runat="server" class=".radiocls3" GroupName="AS1_Samp" name="AS1_Samp_3" ID="AS1_Samp_3" />
                                                                    <label for="input-radio-12">Metagenomics</label>
                                                                </fieldset>
                                                            </asp:Panel>
                                                            <asp:Panel runat="server" ID="pnl_AS1_Samp_4">
                                                                <fieldset>
                                                                    <asp:CheckBox runat="server" class=".radiocls3" GroupName="AS1_Samp" name="AS1_Samp_4" ID="AS1_Samp_4" />
                                                                    <label for="input-radio-12">CRP</label>
                                                                </fieldset>
                                                            </asp:Panel>
                                                        </div>
                                                    </div>
                                                    <asp:Panel runat="server" ID="pnl_AS1_Q1_11">
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CBC Sample Collected In EDTA tube</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls4" GroupName="AS1_Q1_1" name="AS1_Q1_11" ID="AS1_Q1_11" />
                                                                    <label for="input-radio-11">RCT 1</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls4" GroupName="AS1_Q1_1" name="AS1_Q1_12" ID="AS1_Q1_12" />
                                                                    <label for="input-radio-12">RCT 2</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Volume of blood for CBC mL</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS1_Q1_2" MaxLength="6" class="form-control" name="AS1_Q1_2" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Blood Culture Sample collection</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls5" GroupName="AS1_Q2_1" name="AS1_Q2_11" ID="AS1_Q2_11" />
                                                                    <label for="input-radio-11">RCT 1</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls5" GroupName="AS1_Q2_1" name="AS1_Q2_12" ID="AS1_Q2_12" />
                                                                    <label for="input-radio-12">RCT 2</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Volume of blood in Paeds BacT Alert Paeds bottle ml</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS1_Q2_2" MaxLength="6" class="form-control" name="AS1_Q2_2" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Metagenomics Sample collection</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls6" GroupName="AS1_Q3" name="AS1_Q3_1" ID="AS1_Q3_1" />
                                                                    <label for="input-radio-11">RCT 1</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls6" GroupName="AS1_Q3" name="AS1_Q3_2" ID="AS1_Q3_2" />
                                                                    <label for="input-radio-12">RCT 2</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel runat="server" ID="pnl_AS1_Q3a_1">
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CRP Sample Collected In Gel tube</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls7" GroupName="AS1_Q3a_1" name="AS1_Q3a_11" ID="AS1_Q3a_11" />
                                                                    <label for="input-radio-11">RCT 1</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls7" GroupName="AS1_Q3a_1" name="AS1_Q3a_12" ID="AS1_Q3a_12" />
                                                                    <label for="input-radio-12">RCT 2</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel runat="server" ID="pnl_AS1_Q3a_2">
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Volume of blood for Metagenomics</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS1_Q3a_2" MaxLength="6" class="form-control" name="AS1_Q3a_2" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnl_AS1_Q6" runat="server">
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Collection time (hh:mm 24 hr clock)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS1_Q4" class="form-control" name="AS1_Q4"></asp:TextBox>
                                                                <script src="Scripts/timepicker/timepicki.js"></script>
                                                                <script>
                                                                    $('#<%=AS1_Q4.ClientID%>').timepicki();
                                                                </script>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Collection date (dd:mm:yy)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS1_Q5" class="form-control" name="AS1_Q5"></asp:TextBox>
                                                                <div id="Div1" runat="server">
                                                                    <script type="text/javascript">
                                                                        $(document).ready(function () {
                                                                            $('#<%=AS1_Q5.ClientID%>').datepicker({
                                                                                minDate: -100,
                                                                                maxDate: "+0D",
                                                                                dateFormat: 'dd/mm/yy',
                                                                                focusOn: 'button',
                                                                                onSelect: function () { },
                                                                                onClose: function () { $(this).focus(); }
                                                                            });
                                                                        });
                                                                    </script>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Time of Serum separation (hh:mm, 24 hr clock)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS1_Q6" class="form-control" name="AS1_Q6"></asp:TextBox>
                                                                <script src="Scripts/timepicker/timepicki.js"></script>
                                                                <script>
                                                                    $('#<%=AS1_Q6.ClientID%>').timepicki();
                                                                </script>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">No. of Aliquots made</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS1_Q6a" MaxLength="4" class="form-control" name="AS1_Q6a" onkeypress="return numeralsOnly(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Volume in each aliquot ul</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS1_Q6b" MaxLength="6" class="form-control" name="AS1_Q6b" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Time of sample handed over to NRL</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS1_Q6c" class="form-control" name="AS1_Q6c"></asp:TextBox>
                                                                <script src="Scripts/timepicker/timepicki.js"></script>
                                                                <script>
                                                                    $('#<%=AS1_Q6c.ClientID%>').timepicki();
                                                                </script>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel runat="server" ID="pnl_AS2_Q7_1">
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CBC EDTA tube Received</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls8" GroupName="AS2_Q7_1" name="AS2_Q7_11" ID="AS2_Q7_11" />
                                                                    <label for="input-radio-11">Yes</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls8" GroupName="AS2_Q7_1" name="AS2_Q7_12" ID="AS2_Q7_12" />
                                                                    <label for="input-radio-12">No</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CBC EDTA tube Charged at AKU clinical lab (MR Number)</label>
                                                            <div class="col-md-3">
                                                                <asp:TextBox runat="server" ID="AS2_Q7_2a" class="form-control" MaxLength="20" name="AS2_Q7_2a" onkeypress="return RestrictSpecialCharacters_New2(event);"></asp:TextBox>
                                                                <cc1:MaskedEditExtender ID="MaskedEditExtender6" TargetControlID="AS2_Q7_2a" MaskType="Number" AutoComplete="false" ClearMaskOnLostFocus="false" Mask="999-99-99" runat="server"></cc1:MaskedEditExtender>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <asp:CheckBox ID="chk_AS2_Q7_2a" name="chk_AS2_Q7_2a" class=".radiocls3" runat="server" />
                                                                <label style="margin-top: 10px;">MR No not available</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CBC EDTA tube Charged at AKU clinical lab (L Number)</label>
                                                            <div class="col-md-3">
                                                                <asp:TextBox runat="server" ID="AS2_Q7_2" class="form-control" MaxLength="20" name="AS2_Q7_2" onkeypress="return RestrictSpecialCharacters_New2(event);"></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <asp:CheckBox ID="chk_AS2_Q7_2" name="chk_AS2_Q7_2" class=".radiocls3" runat="server" />
                                                                <label style="margin-top: 10px;">L No not available</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CBC EDTA tube Bar Code</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS2_Q7_CBC_CODE" class="form-control" MaxLength="20" name="AS2_Q7_CBC_CODE" onkeypress="return RestrictSpecialCharacters_New2(event);"></asp:TextBox>
                                                                <cc1:MaskedEditExtender ID="MaskedEditExtender4" TargetControlID="AS2_Q7_CBC_CODE" MaskType="Number" AutoComplete="false" ClearMaskOnLostFocus="false" Mask="LL-9-9-9-9999" runat="server"></cc1:MaskedEditExtender>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">BacT Alert Paeds Bottle Received (Difference : Weight Before – Weight after)</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls9" GroupName="AS2_Q8" name="AS2_Q8_1" ID="AS2_Q8_1" />
                                                                    <label for="input-radio-11">Yes</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls9" GroupName="AS2_Q8" name="AS2_Q8_2" ID="AS2_Q8_2" />
                                                                    <label for="input-radio-12">No</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">BacT Alert Paeds Bottle Bar Code</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS2_Q8_BacT" class="form-control" MaxLength="20" name="AS2_Q8_BacT" onkeypress="return RestrictSpecialCharacters_New2(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label id="lbl_AS2_Q8_3" runat="server" class="col-md-3 label-control" for="projectinput5">Weight in gm</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS2_Q8_3" class="form-control" MaxLength="20" name="AS2_Q8_3" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel runat="server" ID="pnl_AS2_Q8a">
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CRP Gel tube Received</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls10" GroupName="AS2_Q8a" name="AS2_Q8a" ID="AS2_Q8a_1" />
                                                                    <label for="input-radio-11">Yes</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls10" GroupName="AS2_Q8a" name="AS2_Q8a" ID="AS2_Q8a_2" />
                                                                    <label for="input-radio-12">No</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Date received (dd/mm/yyyy)</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox runat="server" ID="AS2_Q9" class="form-control" name="AS2_Q9"></asp:TextBox>
                                                            <div id="Div4662" runat="server">
                                                                <script type="text/javascript">
                                                                    $(document).ready(function () {
                                                                        $('#<%=AS2_Q9.ClientID%>').datepicker({
                                                                            minDate: -100,
                                                                            maxDate: "+0D",
                                                                            dateFormat: 'dd/mm/yy',
                                                                            focusOn: 'button',
                                                                            onSelect: function () { },
                                                                            onClose: function () { $(this).focus(); }
                                                                        });
                                                                    });
                                                                </script>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">
                                                            Time received (hh:mm, 24 hr clock)
                                                        </label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox runat="server" ID="AS2_Q10" class="form-control" name="AS2_Q10"></asp:TextBox>
                                                            <script src="Scripts/timepicker/timepicki.js"></script>
                                                            <script>
                                                                $('#<%=AS2_Q10.ClientID%>').timepicki();
                                                            </script>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Condition of sample container received</label>
                                                        <div class="col-md-6 col-sm-12">
                                                            <fieldset>
                                                                <asp:RadioButton runat="server" class=".radiocls11" GroupName="AS2_Q11" name="AS2_Q11_1" ID="AS2_Q11_1" />
                                                                <label for="input-radio-11">Intact</label>
                                                            </fieldset>
                                                            <fieldset>
                                                                <asp:RadioButton runat="server" class=".radiocls11" GroupName="AS2_Q11" name="AS2_Q11_2" ID="AS2_Q11_2" />
                                                                <label for="input-radio-12">Physical damage</label>
                                                            </fieldset>
                                                        </div>
                                                    </div>
                                                    <asp:Panel ID="pnl_AS2_Q12_1" runat="server">
                                                        <div class="form-group row" style="display: none;">
                                                            <label class="col-md-3 label-control" for="projectinput5">Temperature of the Coleman upon arrival at the lab (CBC tube)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS2_Q12_1" class="form-control" MaxLength="6" name="AS2_Q12_1" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Temperature of the Coleman upon arrival at the lab (BacT Alert Peads bottle)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS2_Q12_2" class="form-control" MaxLength="6" name="AS2_Q12_2" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Temperature of the Coleman upon arrival at the lab (Metagenomics)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS2_Q12_3" class="form-control" MaxLength="6" name="AS2_Q12_3" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnl_AS2_Q12_4" runat="server">
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Temperature of the Coleman upon arrival at the lab (CRP Gel tube)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS2_Q12_4" class="form-control" MaxLength="6" name="AS2_Q12_4" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Name of the laboratory person receiving the sample</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox runat="server" ID="AS2_Q13" MaxLength="80" class="form-control" name="AS2_Q13" onkeypress="return lettersOnly_WithSpace(event);"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <asp:Panel runat="server" ID="pnl_AS2_Q13a">
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">
                                                                Time result reported (must be within 20 min - 2 hours of sample receiving)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS2_Q13a" class="form-control" name="AS2_Q13a"></asp:TextBox>
                                                                <script src="Scripts/timepicker/timepicki.js"></script>
                                                                <script>
                                                                    $('#<%=AS2_Q13a.ClientID%>').timepicki();
                                                                </script>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel runat="server" ID="pnl_AS3_Q14">
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Name of IDRL laboratory person receiving the sample</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS3_Q14" MaxLength="80" class="form-control" name="AS3_Q14" onkeypress="return lettersOnly_WithSpace(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Date received (dd/mm/yyyy)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS3_Q14a" class="form-control" name="AS3_Q14a"></asp:TextBox>
                                                                <div id="Div982" runat="server">
                                                                    <script type="text/javascript">
                                                                        $(document).ready(function () {
                                                                            $('#<%=AS3_Q14a.ClientID%>').datepicker({
                                                                                minDate: -100,
                                                                                maxDate: "+0D",
                                                                                dateFormat: 'dd/mm/yy',
                                                                                focusOn: 'button',
                                                                                onSelect: function () { },
                                                                                onClose: function () { $(this).focus(); }
                                                                            });
                                                                        });
                                                                    </script>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Time received (hh:mm 24 hr clock)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS3_Q15" class="form-control" name="AS3_Q15"></asp:TextBox>
                                                                <script src="Scripts/timepicker/timepicki.js"></script>
                                                                <script>
                                                                    $('#<%=AS3_Q15.ClientID%>').timepicki();
                                                                </script>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Temperature of the Coleman upon arrival at the lab</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS3_Q16" MaxLength="6" class="form-control" name="AS3_Q16" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Time of Serum separation (hh:mm 24 hr clock)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS3_Q17" class="form-control" name="AS3_Q17"></asp:TextBox>
                                                                <script src="Scripts/timepicker/timepicki.js"></script>
                                                                <script>
                                                                    $('#<%=AS3_Q17.ClientID%>').timepicki();
                                                                </script>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">No. of Aliquots made</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS3_Q18" MaxLength="4" class="form-control" name="AS3_Q18" onkeypress="return numeralsOnly(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Volume in each aliquot ul</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS3_Q19" MaxLength="6" class="form-control" name="AS3_Q19" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Time Aliquots placed in ULT Freezer</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS3_Q20" class="form-control" name="AS3_Q20"></asp:TextBox>
                                                                <script src="Scripts/timepicker/timepicki.js"></script>
                                                                <script>
                                                                    $('#<%=AS3_Q20.ClientID%>').timepicki();
                                                                </script>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnl_AS4_Q21a" runat="server">
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CRP Sample Collected in Capillary</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:CheckBox runat="server" class=".radiocls83" GroupName="AS4_Q21a" name="AS4_Q21a" ID="AS4_Q21a" />
                                                                    <label for="input-radio-11">RCT 2</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Collection time (hh:mm 24 hr clock)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS4_Q22a" class="form-control" name="AS4_Q22a"></asp:TextBox>
                                                                <script src="Scripts/timepicker/timepicki.js"></script>
                                                                <script>
                                                                    $('#<%=AS4_Q22a.ClientID%>').timepicki();
                                                                </script>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Collection date (dd/mm/yy)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS4_Q22b" class="form-control" name="AS4_Q22b"></asp:TextBox>
                                                                <div id="Div92" runat="server">
                                                                    <script type="text/javascript">
                                                                        $(document).ready(function () {
                                                                            $('#<%=AS4_Q22b.ClientID%>').datepicker({
                                                                                minDate: -100,
                                                                                maxDate: "+0D",
                                                                                dateFormat: 'dd/mm/yy',
                                                                                focusOn: 'button',
                                                                                onSelect: function () { },
                                                                                onClose: function () { $(this).focus(); }
                                                                            });
                                                                        });
                                                                    </script>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Name of Phlebotomist</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS4_Q23" MaxLength="80" class="form-control" name="AS4_Q23" onkeypress="return lettersOnly_WithSpace(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Time of test performed (hh:mm 24 hr clock)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS4_Q24" class="form-control" name="AS4_Q24"></asp:TextBox>
                                                                <script src="Scripts/timepicker/timepicki.js"></script>
                                                                <script>
                                                                    $('#<%=AS4_Q24.ClientID%>').timepicki();
                                                                </script>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnl_AS5_Q25a" runat="server">
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Name of staff CRP Performed</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS5_Q25a" MaxLength="80" class="form-control" name="AS5_Q25a" onkeypress="return lettersOnly_WithSpace(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Code of staff CRP Performed</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS5_Q25b" MaxLength="15" class="form-control" name="AS5_Q25b" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Kit Lot Number</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS5_Q26" MaxLength="20" class="form-control" name="AS5_Q26" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Kit Quality Control</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls12" GroupName="AS5_Q27" name="AS5_Q27" ID="AS5_Q27_1" />
                                                                    <label for="input-radio-11">Satisfactory</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls12" GroupName="AS5_Q27" name="AS5_Q27" ID="AS5_Q27_2" />
                                                                    <label for="input-radio-12">Unsatisfactory</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Kit brought to Room Temperature for 30 minutes</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls13" GroupName="AS5_Q28" name="AS5_Q28" ID="AS5_Q28_1" />
                                                                    <label for="input-radio-11">Yes</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls13" GroupName="AS5_Q28" name="AS5_Q28" ID="AS5_Q28_2" />
                                                                    <label for="input-radio-12">No</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CRP Control line Result (test device)</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls14" GroupName="AS5_Q29" name="AS5_Q29" ID="AS5_Q29_1" />
                                                                    <label for="input-radio-11">Clear</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls14" GroupName="AS5_Q29" name="AS5_Q29" ID="AS5_Q29_2" />
                                                                    <label for="input-radio-12">Faint</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls14" GroupName="AS5_Q29" name="AS5_Q29" ID="AS5_Q29_3" />
                                                                    <label for="input-radio-12">Invalid</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CRP Test Line</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls15" GroupName="AS5_Q30" name="AS5_Q30" ID="AS5_Q30_1" />
                                                                    <label for="input-radio-11">Clear</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls15" GroupName="AS5_Q30" name="AS5_Q30" ID="AS5_Q30_2" />
                                                                    <label for="input-radio-12">Faint</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls15" GroupName="AS5_Q30" name="AS5_Q30" ID="AS5_Q30_3" />
                                                                    <label for="input-radio-12">Invalid</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CRP Test Level</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls16" GroupName="AS5_Q31" name="AS5_Q31" ID="AS5_Q31_1" />
                                                                    <label for="input-radio-11">One blue line = CRP 10-40mg/l</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls16" GroupName="AS5_Q31" name="AS5_Q31" ID="AS5_Q31_2" />
                                                                    <label for="input-radio-12">Two blue lines = CRP 40-80mg/l</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls16" GroupName="AS5_Q31" name="AS5_Q31" ID="AS5_Q31_3" />
                                                                    <label for="input-radio-12">Three blue lines = CRP >80mg/l</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls16" GroupName="AS5_Q31" name="AS5_Q31" ID="AS5_Q31_4" />
                                                                    <label for="input-radio-12">No Blue Lines=CRP < 10mg/l</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CRP (RDT) Result</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls17" GroupName="AS5_Q32" name="AS5_Q32" ID="AS5_Q32_1" />
                                                                    <label for="input-radio-11">Positive</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls17" GroupName="AS5_Q32" name="AS5_Q32" ID="AS5_Q32_2" />
                                                                    <label for="input-radio-12">Negative</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls17" GroupName="AS5_Q32" name="AS5_Q32" ID="AS5_Q32_3" />
                                                                    <label for="input-radio-12">Invalid</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Name of Staff Reading CRP (RDT) Result</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS5_Q33a" MaxLength="80" class="form-control" name="AS5_Q33a" onkeypress="return lettersOnly_WithSpace(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Code of Staff Reading CRP (RDT) Result</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS5_Q33b" MaxLength="15" class="form-control" name="AS5_Q33b" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Remarks (if any)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS3_Remarks" MaxLength="300" class="form-control" TextMode="MultiLine" Rows="5" name="AS3_Remarks" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel runat="server" ID="pnl_lyari_sample">
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Urine DR</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS6_Q34" MaxLength="20" class="form-control" name="AS6_Q34" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Urine CS</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS6_Q35" MaxLength="20" class="form-control" name="AS6_Q35" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Serum Bilirubin (Adult)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS6_Q36" MaxLength="20" class="form-control" name="AS6_Q36" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Liver function test (Serum)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS6_Q37" MaxLength="20" class="form-control" name="AS6_Q37" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Urea</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS6_Q38" MaxLength="20" class="form-control" name="AS6_Q38" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Creatinine</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS6_Q39" MaxLength="20" class="form-control" name="AS6_Q39" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Electrolytes</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS6_Q40" MaxLength="20" class="form-control" name="AS6_Q40" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CSF DR</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS6_Q41" MaxLength="20" class="form-control" name="AS6_Q41" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CSF CS</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS6_Q42" MaxLength="20" class="form-control" name="AS6_Q42" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Chest Xray</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS6_Q43" MaxLength="20" class="form-control" name="AS6_Q43" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Ultrasound whole abdomen</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS6_Q44" MaxLength="20" class="form-control" name="AS6_Q44" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Ultrasound upper abdomen</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS6_Q45" MaxLength="20" class="form-control" name="AS6_Q45" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Ultrasound pelvis</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS6_Q46" MaxLength="20" class="form-control" name="AS6_Q46" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Ultrasound brain</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS6_Q47" MaxLength="20" class="form-control" name="AS6_Q47" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Remarks (if any)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS5_R1" MaxLength="300" class="form-control" TextMode="MultiLine" Rows="5" name="AS3_Remarks" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel runat="server" ID="pnl_sign">
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Form checked by PSBI Laboratory Person</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS3_A1" MaxLength="15" class="form-control" name="AS3_A1" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Date (dd/mm/yyyy)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS3_A2" class="form-control" name="AS3_A2"></asp:TextBox>
                                                                <div id="Div288" runat="server">
                                                                    <script type="text/javascript">
                                                                        $(document).ready(function () {
                                                                            $('#<%=AS3_A2.ClientID%>').datepicker({
                                                                                minDate: -100,
                                                                                maxDate: "+0D",
                                                                                dateFormat: 'dd/mm/yy',
                                                                                focusOn: 'button',
                                                                                onSelect: function () { },
                                                                                onClose: function () { $(this).focus(); }
                                                                            });
                                                                        });
                                                                    </script>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Form checked by PSBI Study Physician</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS3_B1" class="form-control" MaxLength="15" name="AS3_B1" onkeypress="return RestrictSpecialCharacters(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Date (dd/mm/yyyy)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" ID="AS3_B2" class="form-control" name="AS3_B2"></asp:TextBox>
                                                                <div id="Div42" runat="server">
                                                                    <script type="text/javascript">
                                                                        $(document).ready(function () {
                                                                            $('#<%=AS3_B2.ClientID%>').datepicker({
                                                                                minDate: -100,
                                                                                maxDate: "+0D",
                                                                                dateFormat: 'dd/mm/yy',
                                                                                focusOn: 'button',
                                                                                onSelect: function () { },
                                                                                onClose: function () { $(this).focus(); }
                                                                            });
                                                                        });
                                                                    </script>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                </div>
                                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>

                                                        <div class="form-actions left">
                                                            <asp:Button runat="server" ID="cmdSave" class="btn btn-danger mr-1" Text=" Save " OnClick="cmdSave_Click"></asp:Button>
                                                            <asp:Button ID="cmdCancel" runat="server" class="btn btn-primary" Text="Cancel" OnClick="cmdCancel_Click"></asp:Button>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                                <%--<div class="form-actions right">
                                    <button type="button" class="btn btn-danger mr-1">
                                        <i class="ft-x"></i>Cancel
	                           
                                    </button>
                                    <button type="submit" class="btn btn-primary">
                                        <i class="la la-check-square-o"></i>Save
	                           
                                    </button>
                                </div>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </section>
                        <!-- // Basic form layout section end -->
                    </div>
                </div>
            </div>
        </div>
        <!-- END: Content-->
        <!-- BEGIN: Footer-->
        <%--<a class="btn btn-try-builder btn-bg-gradient-x-purple-red btn-glow white" href="https://www.themeselection.com/layout-builder/horizontal" target="_blank">Try Layout Builder</a>--%>
        <footer class="footer footer-static footer-light navbar-border navbar-shadow">
            <div class="clearfix blue-grey lighten-2 text-sm-center mb-0 px-2">
                <span class="float-none d-block d-md-inline-block">Designed and developed by <a class="text-bold-800 grey darken-2" href="https://www.aku.edu/" target="_blank">Paeds Department</a> &copy; Copyright <% Response.Write(DateTime.Now.Year.ToString()); %></span>
                <%--<ul class="list-inline float-md-right d-block d-md-inline-blockd-none d-lg-block mb-0">
                    <li class="list-inline-item"><a class="my-1" href="https://themeselection.com/" target="_blank">More themes</a></li>
                    <li class="list-inline-item"><a class="my-1" href="https://themeselection.com/support" target="_blank">Support</a></li>
                </ul>--%>
            </div>
        </footer>
        <!-- END: Footer-->
        <!-- BEGIN: Vendor JS-->
        <script src="Content/demo/chameleon-admin-template/app-assets/vendors/js/vendors.min.js" type="text/javascript"></script>
        <script src="Content/demo/chameleon-admin-template/app-assets/vendors/js/forms/toggle/switchery.min.js" type="text/javascript"></script>
        <script src="Content/demo/chameleon-admin-template/app-assets/js/scripts/forms/switch.min.js" type="text/javascript"></script>
        <!-- BEGIN Vendor JS-->
        <!-- END: Page Vendor JS-->
        <script src="Content/demo/chameleon-admin-template/app-assets/js/core/app-menu.min.js" type="text/javascript"></script>
        <script src="Content/demo/chameleon-admin-template/app-assets/js/core/app.min.js" type="text/javascript"></script>
        <script src="Content/demo/chameleon-admin-template/app-assets/js/scripts/customizer.min.js" type="text/javascript"></script>
        <script src="Content/demo/chameleon-admin-template/app-assets/vendors/js/jquery.sharrre.js" type="text/javascript"></script>
        <!-- END: Theme JS-->
        <!-- END: Body-->
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
        <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
        <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    </form>
</body>
</html>
