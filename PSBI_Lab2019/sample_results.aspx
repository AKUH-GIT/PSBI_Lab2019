<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sample_results.aspx.cs" Inherits="sample_results" %>

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

        function EnableControls_Loop() {

            $('#form1 input').each(
                function (index) {
                    var input = $(this);

                    if (input.attr("id") != "la_sno") {

                        if (input.attr('type') == "text"
                            || input.attr('type') == "number") {
                            input.removeAttr("disabled", "disabled");

                        } else if (input.attr('type') == "radio") {
                            $("input[name='" + input.attr('name') + "']").removeAttr("disabled", "disabled");

                            //var radstates = {};
                            //var radioButtons = $("input[name='" + input.attr('name') + "']");

                            //$.each(radioButtons, function (index, rd) {
                            //    if (radioButtons[index].checked == false) {
                            //        radstates[index] = false;
                            //    } else {
                            //        radstates[index] = true;
                            //    }
                            //});

                        }

                    }

                }, errorValidate);
        }

        function DisableControls_Loop() {

            $('#form1 input').each(
                function (index) {
                    var input = $(this);

                    if (input.attr("id") != "la_sno") {

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

                        }

                    }

                }, errorValidate);
        }


        function errorValidate(err) {
            alert("Error: " + err.code);
        }


        $(document).on("click", "#cmdCancel", function (e) {

            EnableControls_Loop();

            //EnableControls("LA_01", "txt");
            //EnableControls("LA_02", "txt");
            //EnableControls("input[name=LA_03]", "rdo");
            //EnableControls("LA_03_a", "txt");

            //EnableControls("input[name=LA_04]", "rdo");
            //EnableControls("LA_04_a", "txt");

            //EnableControls("input[name=LA_05]", "rdo");
            //EnableControls("LA_05_a", "txt");

            //EnableControls("input[name=LA_06]", "rdo");
            //EnableControls("LA_06_a", "txt");

            //EnableControls("input[name=LA_07]", "rdo");
            //EnableControls("LA_07_a", "txt");

            //EnableControls("input[name=LA_08]", "rdo");
            //EnableControls("LA_08_a", "txt");

            //EnableControls("input[name=LA_09]", "rdo");
            //EnableControls("LA_09_a", "txt");

            //EnableControls("input[name=LA_10]", "rdo");
            //EnableControls("LA_10_a", "txt");

            //EnableControls("input[name=LA_11]", "rdo");
            //EnableControls("LA_11_a", "txt");

            //EnableControls("input[name=LA_12]", "rdo");
            //EnableControls("LA_12_a", "txt");

            //EnableControls("input[name=LA_13]", "rdo");
            //EnableControls("LA_13_a", "txt");

            //EnableControls("input[name=LA_14]", "rdo");
            //EnableControls("LA_14_a", "txt");

            //EnableControls("input[name=LA_15]", "rdo");
            //EnableControls("LA_15_a", "txt");

            //EnableControls("input[name=LA_16]", "rdo");
            //EnableControls("LA_16_a", "txt");

            //EnableControls("LA_17", "txt");
            //EnableControls("LA_18", "txt");
            //EnableControls("LA_19", "txt");

            //EnableControls("input[name=LA_20a]", "rdo");
            //EnableControls("LA_20a_a", "txt");
            //EnableControls("input[name=LA_20b]", "rdo");

            //EnableControls("input[name=LA_21a]", "rdo");
            //EnableControls("LA_21a_a", "txt");
            //EnableControls("input[name=LA_21b]", "rdo");

            //EnableControls("input[name=LA_22a]", "rdo");
            //EnableControls("LA_22a_a", "txt");
            //EnableControls("input[name=LA_22b]", "rdo");

            //EnableControls("input[name=LA_23a]", "rdo");
            //EnableControls("LA_23a_a", "txt");
            //EnableControls("input[name=LA_23b]", "rdo");

            //EnableControls("input[name=LA_24a]", "rdo");
            //EnableControls("LA_24a_a", "txt");
            //EnableControls("input[name=LA_24b]", "rdo");

            //EnableControls("input[name=LA_25a]", "rdo");
            //EnableControls("LA_25a_a", "txt");
            //EnableControls("input[name=LA_25b]", "rdo");

            //EnableControls("input[name=LA_26a]", "rdo");
            //EnableControls("LA_26a_a", "txt");
            //EnableControls("input[name=LA_26b]", "rdo");

            //EnableControls("input[name=LA_27a]", "rdo");
            //EnableControls("LA_27a_a", "txt");
            //EnableControls("input[name=LA_27b]", "rdo");

            //EnableControls("input[name=LA_28a]", "rdo");
            //EnableControls("LA_28a_a", "txt");
            //EnableControls("input[name=LA_28b]", "rdo");

            //EnableControls("input[name=LA_29a]", "rdo");
            //EnableControls("LA_29a_a", "txt");
            //EnableControls("input[name=LA_29b]", "rdo");

            //EnableControls("input[name=LA_30a]", "rdo");
            //EnableControls("LA_30a_a", "txt");
            //EnableControls("input[name=LA_30b]", "rdo");

            //EnableControls("input[name=LA_31a]", "rdo");
            //EnableControls("LA_31a_a", "txt");
            //EnableControls("input[name=LA_31b]", "rdo");

            //EnableControls("input[name=LA_32a]", "rdo");
            //EnableControls("LA_32a_a", "txt");
            //EnableControls("input[name=LA_32b]", "rdo");

            //EnableControls("input[name=LA_33a]", "rdo");
            //EnableControls("LA_33a_a", "txt");
            //EnableControls("input[name=LA_33b]", "rdo");

            //EnableControls("input[name=LA_34a]", "rdo");
            //EnableControls("LA_34a_a", "txt");
            //EnableControls("input[name=LA_34b]", "rdo");

            //EnableControls("input[name=LA_35a]", "rdo");
            //EnableControls("LA_35a_a", "txt");
            //EnableControls("input[name=LA_35b]", "rdo");

            //EnableControls("input[name=LA_36a]", "rdo");
            //EnableControls("LA_36a_a", "txt");
            //EnableControls("input[name=LA_36b]", "rdo");

            //EnableControls("input[name=LA_37a]", "rdo");
            //EnableControls("LA_37a_a", "txt");
            //EnableControls("input[name=LA_37b]", "rdo");

            //EnableControls("input[name=LA_38a]", "rdo");
            //EnableControls("LA_38a_a", "txt");
            //EnableControls("input[name=LA_38b]", "rdo");

            //EnableControls("input[name=LA_39a]", "rdo");
            //EnableControls("LA_39a_a", "txt");
            //EnableControls("input[name=LA_39b]", "rdo");

            //EnableControls("input[name=LA_40a]", "rdo");
            //EnableControls("LA_40a_a", "txt");
            //EnableControls("input[name=LA_40b]", "rdo");

            //EnableControls("input[name=LA_41a]", "rdo");
            //EnableControls("LA_41a_a", "txt");
            //EnableControls("input[name=LA_41b]", "rdo");

            //EnableControls("input[name=LA_42a]", "rdo");
            //EnableControls("LA_42a_a", "txt");
            //EnableControls("input[name=LA_42b]", "rdo");

            //EnableControls("input[name=LA_43a]", "rdo");
            //EnableControls("LA_43a_a", "txt");
            //EnableControls("input[name=LA_43b]", "rdo");

            //EnableControls("input[name=LA_44a]", "rdo");
            //EnableControls("LA_44a_a", "txt");
            //EnableControls("input[name=LA_44b]", "rdo");

            //EnableControls("input[name=LA_45a]", "rdo");
            //EnableControls("LA_45a_a", "txt");
            //EnableControls("input[name=LA_45b]", "rdo");

            //EnableControls("input[name=LA_46a]", "rdo");
            //EnableControls("LA_46a_a", "txt");
            //EnableControls("input[name=LA_46b]", "rdo");

            //EnableControls("input[name=LA_47a]", "rdo");
            //EnableControls("LA_47a_a", "txt");
            //EnableControls("input[name=LA_47b]", "rdo");

            //EnableControls("input[name=LA_48a]", "rdo");
            //EnableControls("LA_48a_a", "txt");
            //EnableControls("input[name=LA_48b]", "rdo");

            //EnableControls("input[name=LA_49a]", "rdo");
            //EnableControls("LA_49a_a", "txt");
            //EnableControls("input[name=LA_49b]", "rdo");

            //EnableControls("input[name=LA_50a]", "rdo");
            //EnableControls("LA_50a_a", "txt");
            //EnableControls("input[name=LA_50b]", "rdo");

            //EnableControls("input[name=LA_51a]", "rdo");
            //EnableControls("LA_51a_a", "txt");
            //EnableControls("input[name=LA_51b]", "rdo");

            //EnableControls("input[name=LA_52a]", "rdo");
            //EnableControls("LA_52a_a", "txt");
            //EnableControls("input[name=LA_52b]", "rdo");

            $("#cmdSave").show();
            $("#la_sno").val("");
            $("#la_sno").focus();
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
            }
        }


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


        $(document).on("blur", "#la_sno", function (e) {

            if ($("#la_sno").val() != "__-_-____") {

                var isexist = false;

                $
                    .ajax({
                        url: "sample_results.aspx/IsScreeningIDExists",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: "{ screeningid: '" + $('#la_sno').val() + "', labid: '" + getCookie("labid") + "'}",

                        success: function (
                            data) {

                            if (data.d == "") {

                                isexist = false;

                            }
                            else {

                                isexist = true;

                                alert("Results already entered against this Screening id ");


                                $("#la_fsite").val("");
                                $("#la_rand").val("");
                                $("#la_spec").val("");
                                $("#la_name").val("");
                                $("#la_gen").val("");
                                $("#la_age").val("");
                                $("#la_obj").val("");

                                DisableControls_Loop();

                                //DisableControls("LA_01", "txt");
                                //DisableControls("LA_02", "txt");
                                //DisableControls("input[name=LA_03]", "rdo");
                                //DisableControls("LA_03_a", "txt");

                                //DisableControls("input[name=LA_04]", "rdo");
                                //DisableControls("LA_04_a", "txt");

                                //DisableControls("input[name=LA_05]", "rdo");
                                //DisableControls("LA_05_a", "txt");

                                //DisableControls("input[name=LA_06]", "rdo");
                                //DisableControls("LA_06_a", "txt");

                                //DisableControls("input[name=LA_07]", "rdo");
                                //DisableControls("LA_07_a", "txt");

                                //DisableControls("input[name=LA_08]", "rdo");
                                //DisableControls("LA_08_a", "txt");

                                //DisableControls("input[name=LA_09]", "rdo");
                                //DisableControls("LA_09_a", "txt");

                                //DisableControls("input[name=LA_10]", "rdo");
                                //DisableControls("LA_10_a", "txt");

                                //DisableControls("input[name=LA_11]", "rdo");
                                //DisableControls("LA_11_a", "txt");

                                //DisableControls("input[name=LA_12]", "rdo");
                                //DisableControls("LA_12_a", "txt");

                                //DisableControls("input[name=LA_13]", "rdo");
                                //DisableControls("LA_13_a", "txt");

                                //DisableControls("input[name=LA_14]", "rdo");
                                //DisableControls("LA_14_a", "txt");

                                //DisableControls("input[name=LA_15]", "rdo");
                                //DisableControls("LA_15_a", "txt");

                                //DisableControls("input[name=LA_16]", "rdo");
                                //DisableControls("LA_16_a", "txt");

                                //DisableControls("LA_17", "txt");
                                //DisableControls("LA_18", "txt");
                                //DisableControls("LA_19", "txt");

                                //DisableControls("input[name=LA_20a]", "rdo");
                                //DisableControls("LA_20a_a", "txt");
                                //DisableControls("input[name=LA_20b]", "rdo");

                                //DisableControls("input[name=LA_21a]", "rdo");
                                //DisableControls("LA_21a_a", "txt");
                                //DisableControls("input[name=LA_21b]", "rdo");

                                //DisableControls("input[name=LA_22a]", "rdo");
                                //DisableControls("LA_22a_a", "txt");
                                //DisableControls("input[name=LA_22b]", "rdo");

                                //DisableControls("input[name=LA_23a]", "rdo");
                                //DisableControls("LA_23a_a", "txt");
                                //DisableControls("input[name=LA_23b]", "rdo");

                                //DisableControls("input[name=LA_24a]", "rdo");
                                //DisableControls("LA_24a_a", "txt");
                                //DisableControls("input[name=LA_24b]", "rdo");

                                //DisableControls("input[name=LA_25a]", "rdo");
                                //DisableControls("LA_25a_a", "txt");
                                //DisableControls("input[name=LA_25b]", "rdo");

                                //DisableControls("input[name=LA_26a]", "rdo");
                                //DisableControls("LA_26a_a", "txt");
                                //DisableControls("input[name=LA_26b]", "rdo");

                                //DisableControls("input[name=LA_27a]", "rdo");
                                //DisableControls("LA_27a_a", "txt");
                                //DisableControls("input[name=LA_27b]", "rdo");

                                //DisableControls("input[name=LA_28a]", "rdo");
                                //DisableControls("LA_28a_a", "txt");
                                //DisableControls("input[name=LA_28b]", "rdo");

                                //DisableControls("input[name=LA_29a]", "rdo");
                                //DisableControls("LA_29a_a", "txt");
                                //DisableControls("input[name=LA_29b]", "rdo");

                                //DisableControls("input[name=LA_30a]", "rdo");
                                //DisableControls("LA_30a_a", "txt");
                                //DisableControls("input[name=LA_30b]", "rdo");

                                //DisableControls("input[name=LA_31a]", "rdo");
                                //DisableControls("LA_31a_a", "txt");
                                //DisableControls("input[name=LA_31b]", "rdo");

                                //DisableControls("input[name=LA_32a]", "rdo");
                                //DisableControls("LA_32a_a", "txt");
                                //DisableControls("input[name=LA_32b]", "rdo");

                                //DisableControls("input[name=LA_33a]", "rdo");
                                //DisableControls("LA_33a_a", "txt");
                                //DisableControls("input[name=LA_33b]", "rdo");

                                //DisableControls("input[name=LA_34a]", "rdo");
                                //DisableControls("LA_34a_a", "txt");
                                //DisableControls("input[name=LA_34b]", "rdo");

                                //DisableControls("input[name=LA_35a]", "rdo");
                                //DisableControls("LA_35a_a", "txt");
                                //DisableControls("input[name=LA_35b]", "rdo");

                                //DisableControls("input[name=LA_36a]", "rdo");
                                //DisableControls("LA_36a_a", "txt");
                                //DisableControls("input[name=LA_36b]", "rdo");

                                //DisableControls("input[name=LA_37a]", "rdo");
                                //DisableControls("LA_37a_a", "txt");
                                //DisableControls("input[name=LA_37b]", "rdo");

                                //DisableControls("input[name=LA_38a]", "rdo");
                                //DisableControls("LA_38a_a", "txt");
                                //DisableControls("input[name=LA_38b]", "rdo");

                                //DisableControls("input[name=LA_39a]", "rdo");
                                //DisableControls("LA_39a_a", "txt");
                                //DisableControls("input[name=LA_39b]", "rdo");

                                //DisableControls("input[name=LA_40a]", "rdo");
                                //DisableControls("LA_40a_a", "txt");
                                //DisableControls("input[name=LA_40b]", "rdo");

                                //DisableControls("input[name=LA_41a]", "rdo");
                                //DisableControls("LA_41a_a", "txt");
                                //DisableControls("input[name=LA_41b]", "rdo");

                                //DisableControls("input[name=LA_42a]", "rdo");
                                //DisableControls("LA_42a_a", "txt");
                                //DisableControls("input[name=LA_42b]", "rdo");

                                //DisableControls("input[name=LA_43a]", "rdo");
                                //DisableControls("LA_43a_a", "txt");
                                //DisableControls("input[name=LA_43b]", "rdo");

                                //DisableControls("input[name=LA_44a]", "rdo");
                                //DisableControls("LA_44a_a", "txt");
                                //DisableControls("input[name=LA_44b]", "rdo");

                                //DisableControls("input[name=LA_45a]", "rdo");
                                //DisableControls("LA_45a_a", "txt");
                                //DisableControls("input[name=LA_45b]", "rdo");

                                //DisableControls("input[name=LA_46a]", "rdo");
                                //DisableControls("LA_46a_a", "txt");
                                //DisableControls("input[name=LA_46b]", "rdo");

                                //DisableControls("input[name=LA_47a]", "rdo");
                                //DisableControls("LA_47a_a", "txt");
                                //DisableControls("input[name=LA_47b]", "rdo");

                                //DisableControls("input[name=LA_48a]", "rdo");
                                //DisableControls("LA_48a_a", "txt");
                                //DisableControls("input[name=LA_48b]", "rdo");

                                //DisableControls("input[name=LA_49a]", "rdo");
                                //DisableControls("LA_49a_a", "txt");
                                //DisableControls("input[name=LA_49b]", "rdo");

                                //DisableControls("input[name=LA_50a]", "rdo");
                                //DisableControls("LA_50a_a", "txt");
                                //DisableControls("input[name=LA_50b]", "rdo");

                                //DisableControls("input[name=LA_51a]", "rdo");
                                //DisableControls("LA_51a_a", "txt");
                                //DisableControls("input[name=LA_51b]", "rdo");

                                //DisableControls("input[name=LA_52a]", "rdo");
                                //DisableControls("LA_52a_a", "txt");
                                //DisableControls("input[name=LA_52b]", "rdo");


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

                if (isexist == false) {

                    $
                        .ajax({
                            url: "sample_results.aspx/CheckScreeningID",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            data: "{ screeningid: '" + $('#la_sno').val() + "', labid: '" + getCookie("labid") + "'}",

                            success: function (
                                data) {

                                if (data.d == "") {
                                    alert("Screening id not found in sample receiving form");

                                    $("#la_fsite").val("");
                                    $("#la_rand").val("");
                                    $("#la_spec").val("");
                                    $("#la_name").val("");
                                    $("#la_gen").val("");
                                    $("#la_age").val("");
                                    $("#la_obj").val("");

                                    DisableControls_Loop();


                                    //DisableControls("LA_01", "txt");
                                    //DisableControls("LA_02", "txt");
                                    //DisableControls("input[name=LA_03]", "rdo");
                                    //DisableControls("LA_03_a", "txt");

                                    //DisableControls("input[name=LA_04]", "rdo");
                                    //DisableControls("LA_04_a", "txt");


                                    //DisableControls("input[name=LA_05]", "rdo");
                                    //DisableControls("LA_05_a", "txt");


                                    //DisableControls("input[name=LA_06]", "rdo");
                                    //DisableControls("LA_06_a", "txt");

                                    //DisableControls("input[name=LA_07]", "rdo");
                                    //DisableControls("LA_07_a", "txt");

                                    //DisableControls("input[name=LA_08]", "rdo");
                                    //DisableControls("LA_08_a", "txt");

                                    //DisableControls("input[name=LA_09]", "rdo");
                                    //DisableControls("LA_09_a", "txt");

                                    //DisableControls("input[name=LA_10]", "rdo");
                                    //DisableControls("LA_10_a", "txt");

                                    //DisableControls("input[name=LA_11]", "rdo");
                                    //DisableControls("LA_11_a", "txt");

                                    //DisableControls("input[name=LA_12]", "rdo");
                                    //DisableControls("LA_12_a", "txt");

                                    //DisableControls("input[name=LA_13]", "rdo");
                                    //DisableControls("LA_13_a", "txt");

                                    //DisableControls("input[name=LA_14]", "rdo");
                                    //DisableControls("LA_14_a", "txt");

                                    //DisableControls("input[name=LA_15]", "rdo");
                                    //DisableControls("LA_15_a", "txt");

                                    //DisableControls("input[name=LA_16]", "rdo");
                                    //DisableControls("LA_16_a", "txt");

                                    //DisableControls("LA_17", "txt");
                                    //DisableControls("LA_18", "txt");
                                    //DisableControls("LA_19", "txt");

                                    //DisableControls("input[name=LA_20a]", "rdo");
                                    //DisableControls("LA_20a_a", "txt");
                                    //DisableControls("input[name=LA_20b]", "rdo");


                                    //DisableControls("input[name=LA_21a]", "rdo");
                                    //DisableControls("LA_21a_a", "txt");
                                    //DisableControls("input[name=LA_21b]", "rdo");

                                    //DisableControls("input[name=LA_22a]", "rdo");
                                    //DisableControls("LA_22a_a", "txt");
                                    //DisableControls("input[name=LA_22b]", "rdo");

                                    //DisableControls("input[name=LA_23a]", "rdo");
                                    //DisableControls("LA_23a_a", "txt");
                                    //DisableControls("input[name=LA_23b]", "rdo");

                                    //DisableControls("input[name=LA_24a]", "rdo");
                                    //DisableControls("LA_24a_a", "txt");
                                    //DisableControls("input[name=LA_24b]", "rdo");

                                    //DisableControls("input[name=LA_25a]", "rdo");
                                    //DisableControls("LA_25a_a", "txt");
                                    //DisableControls("input[name=LA_25b]", "rdo");

                                    //DisableControls("input[name=LA_26a]", "rdo");
                                    //DisableControls("LA_26a_a", "txt");
                                    //DisableControls("input[name=LA_26b]", "rdo");

                                    //DisableControls("input[name=LA_27a]", "rdo");
                                    //DisableControls("LA_27a_a", "txt");
                                    //DisableControls("input[name=LA_27b]", "rdo");

                                    //DisableControls("input[name=LA_28a]", "rdo");
                                    //DisableControls("LA_28a_a", "txt");
                                    //DisableControls("input[name=LA_28b]", "rdo");

                                    //DisableControls("input[name=LA_29a]", "rdo");
                                    //DisableControls("LA_29a_a", "txt");
                                    //DisableControls("input[name=LA_29b]", "rdo");

                                    //DisableControls("input[name=LA_30a]", "rdo");
                                    //DisableControls("LA_30a_a", "txt");
                                    //DisableControls("input[name=LA_30b]", "rdo");

                                    //DisableControls("input[name=LA_31a]", "rdo");
                                    //DisableControls("LA_31a_a", "txt");
                                    //DisableControls("input[name=LA_31b]", "rdo");

                                    //DisableControls("input[name=LA_32a]", "rdo");
                                    //DisableControls("LA_32a_a", "txt");
                                    //DisableControls("input[name=LA_32b]", "rdo");

                                    //DisableControls("input[name=LA_33a]", "rdo");
                                    //DisableControls("LA_33a_a", "txt");
                                    //DisableControls("input[name=LA_33b]", "rdo");

                                    //DisableControls("input[name=LA_34a]", "rdo");
                                    //DisableControls("LA_34a_a", "txt");
                                    //DisableControls("input[name=LA_34b]", "rdo");

                                    //DisableControls("input[name=LA_35a]", "rdo");
                                    //DisableControls("LA_35a_a", "txt");
                                    //DisableControls("input[name=LA_35b]", "rdo");

                                    //DisableControls("input[name=LA_36a]", "rdo");
                                    //DisableControls("LA_36a_a", "txt");
                                    //DisableControls("input[name=LA_36b]", "rdo");

                                    //DisableControls("input[name=LA_37a]", "rdo");
                                    //DisableControls("LA_37a_a", "txt");
                                    //DisableControls("input[name=LA_37b]", "rdo");

                                    //DisableControls("input[name=LA_38a]", "rdo");
                                    //DisableControls("LA_38a_a", "txt");
                                    //DisableControls("input[name=LA_38b]", "rdo");

                                    //DisableControls("input[name=LA_39a]", "rdo");
                                    //DisableControls("LA_39a_a", "txt");
                                    //DisableControls("input[name=LA_39b]", "rdo");

                                    //DisableControls("input[name=LA_40a]", "rdo");
                                    //DisableControls("LA_40a_a", "txt");
                                    //DisableControls("input[name=LA_40b]", "rdo");

                                    //DisableControls("input[name=LA_41a]", "rdo");
                                    //DisableControls("LA_41a_a", "txt");
                                    //DisableControls("input[name=LA_41b]", "rdo");

                                    //DisableControls("input[name=LA_42a]", "rdo");
                                    //DisableControls("LA_42a_a", "txt");
                                    //DisableControls("input[name=LA_42b]", "rdo");

                                    //DisableControls("input[name=LA_43a]", "rdo");
                                    //DisableControls("LA_43a_a", "txt");
                                    //DisableControls("input[name=LA_43b]", "rdo");

                                    //DisableControls("input[name=LA_44a]", "rdo");
                                    //DisableControls("LA_44a_a", "txt");
                                    //DisableControls("input[name=LA_44b]", "rdo");

                                    //DisableControls("input[name=LA_45a]", "rdo");
                                    //DisableControls("LA_45a_a", "txt");
                                    //DisableControls("input[name=LA_45b]", "rdo");

                                    //DisableControls("input[name=LA_46a]", "rdo");
                                    //DisableControls("LA_46a_a", "txt");
                                    //DisableControls("input[name=LA_46b]", "rdo");

                                    //DisableControls("input[name=LA_47a]", "rdo");
                                    //DisableControls("LA_47a_a", "txt");
                                    //DisableControls("input[name=LA_47b]", "rdo");

                                    //DisableControls("input[name=LA_48a]", "rdo");
                                    //DisableControls("LA_48a_a", "txt");
                                    //DisableControls("input[name=LA_48b]", "rdo");

                                    //DisableControls("input[name=LA_49a]", "rdo");
                                    //DisableControls("LA_49a_a", "txt");
                                    //DisableControls("input[name=LA_49b]", "rdo");

                                    //DisableControls("input[name=LA_50a]", "rdo");
                                    //DisableControls("LA_50a_a", "txt");
                                    //DisableControls("input[name=LA_50b]", "rdo");

                                    //DisableControls("input[name=LA_51a]", "rdo");
                                    //DisableControls("LA_51a_a", "txt");
                                    //DisableControls("input[name=LA_51b]", "rdo");

                                    //DisableControls("input[name=LA_52a]", "rdo");
                                    //DisableControls("LA_52a_a", "txt");
                                    //DisableControls("input[name=LA_52b]", "rdo");


                                    $("#cmdSave").hide();
                                }
                                else {

                                    if (isexist == false) {

                                        EnableControls_Loop();

                                        //EnableControls("LA_01", "txt");
                                        //EnableControls("LA_02", "txt");
                                        //EnableControls("input[name=LA_03]", "rdo");
                                        //EnableControls("LA_03_a", "txt");

                                        //EnableControls("input[name=LA_04]", "rdo");
                                        //EnableControls("LA_04_a", "txt");

                                        //EnableControls("input[name=LA_05]", "rdo");
                                        //EnableControls("LA_05_a", "txt");

                                        //EnableControls("input[name=LA_06]", "rdo");
                                        //EnableControls("LA_06_a", "txt");

                                        //EnableControls("input[name=LA_07]", "rdo");
                                        //EnableControls("LA_07_a", "txt");

                                        //EnableControls("input[name=LA_08]", "rdo");
                                        //EnableControls("LA_08_a", "txt");

                                        //EnableControls("input[name=LA_09]", "rdo");
                                        //EnableControls("LA_09_a", "txt");

                                        //EnableControls("input[name=LA_10]", "rdo");
                                        //EnableControls("LA_10_a", "txt");

                                        //EnableControls("input[name=LA_11]", "rdo");
                                        //EnableControls("LA_11_a", "txt");

                                        //EnableControls("input[name=LA_12]", "rdo");
                                        //EnableControls("LA_12_a", "txt");

                                        //EnableControls("input[name=LA_13]", "rdo");
                                        //EnableControls("LA_13_a", "txt");

                                        //EnableControls("input[name=LA_14]", "rdo");
                                        //EnableControls("LA_14_a", "txt");

                                        //EnableControls("input[name=LA_15]", "rdo");
                                        //EnableControls("LA_15_a", "txt");

                                        //EnableControls("input[name=LA_16]", "rdo");
                                        //EnableControls("LA_16_a", "txt");

                                        //EnableControls("LA_17", "txt");
                                        //EnableControls("LA_18", "txt");
                                        //EnableControls("LA_19", "txt");

                                        //EnableControls("input[name=LA_20a]", "rdo");
                                        //EnableControls("LA_20a_a", "txt");
                                        //EnableControls("input[name=LA_20b]", "rdo");

                                        //EnableControls("input[name=LA_21a]", "rdo");
                                        //EnableControls("LA_21a_a", "txt");
                                        //EnableControls("input[name=LA_21b]", "rdo");

                                        //EnableControls("input[name=LA_22a]", "rdo");
                                        //EnableControls("LA_22a_a", "txt");
                                        //EnableControls("input[name=LA_22b]", "rdo");

                                        //EnableControls("input[name=LA_23a]", "rdo");
                                        //EnableControls("LA_23a_a", "txt");
                                        //EnableControls("input[name=LA_23b]", "rdo");

                                        //EnableControls("input[name=LA_24a]", "rdo");
                                        //EnableControls("LA_24a_a", "txt");
                                        //EnableControls("input[name=LA_24b]", "rdo");

                                        //EnableControls("input[name=LA_25a]", "rdo");
                                        //EnableControls("LA_25a_a", "txt");
                                        //EnableControls("input[name=LA_25b]", "rdo");

                                        //EnableControls("input[name=LA_26a]", "rdo");
                                        //EnableControls("LA_26a_a", "txt");
                                        //EnableControls("input[name=LA_26b]", "rdo");

                                        //EnableControls("input[name=LA_27a]", "rdo");
                                        //EnableControls("LA_27a_a", "txt");
                                        //EnableControls("input[name=LA_27b]", "rdo");

                                        //EnableControls("input[name=LA_28a]", "rdo");
                                        //EnableControls("LA_28a_a", "txt");
                                        //EnableControls("input[name=LA_28b]", "rdo");

                                        //EnableControls("input[name=LA_29a]", "rdo");
                                        //EnableControls("LA_29a_a", "txt");
                                        //EnableControls("input[name=LA_29b]", "rdo");

                                        //EnableControls("input[name=LA_30a]", "rdo");
                                        //EnableControls("LA_30a_a", "txt");
                                        //EnableControls("input[name=LA_30b]", "rdo");

                                        //EnableControls("input[name=LA_31a]", "rdo");
                                        //EnableControls("LA_31a_a", "txt");
                                        //EnableControls("input[name=LA_31b]", "rdo");

                                        //EnableControls("input[name=LA_32a]", "rdo");
                                        //EnableControls("LA_32a_a", "txt");
                                        //EnableControls("input[name=LA_32b]", "rdo");

                                        //EnableControls("input[name=LA_33a]", "rdo");
                                        //EnableControls("LA_33a_a", "txt");
                                        //EnableControls("input[name=LA_33b]", "rdo");

                                        //EnableControls("input[name=LA_34a]", "rdo");
                                        //EnableControls("LA_34a_a", "txt");
                                        //EnableControls("input[name=LA_34b]", "rdo");

                                        //EnableControls("input[name=LA_35a]", "rdo");
                                        //EnableControls("LA_35a_a", "txt");
                                        //EnableControls("input[name=LA_35b]", "rdo");

                                        //EnableControls("input[name=LA_36a]", "rdo");
                                        //EnableControls("LA_36a_a", "txt");
                                        //EnableControls("input[name=LA_36b]", "rdo");

                                        //EnableControls("input[name=LA_37a]", "rdo");
                                        //EnableControls("LA_37a_a", "txt");
                                        //EnableControls("input[name=LA_37b]", "rdo");

                                        //EnableControls("input[name=LA_38a]", "rdo");
                                        //EnableControls("LA_38a_a", "txt");
                                        //EnableControls("input[name=LA_38b]", "rdo");

                                        //EnableControls("input[name=LA_39a]", "rdo");
                                        //EnableControls("LA_39a_a", "txt");
                                        //EnableControls("input[name=LA_39b]", "rdo");

                                        //EnableControls("input[name=LA_40a]", "rdo");
                                        //EnableControls("LA_40a_a", "txt");
                                        //EnableControls("input[name=LA_40b]", "rdo");

                                        //EnableControls("input[name=LA_41a]", "rdo");
                                        //EnableControls("LA_41a_a", "txt");
                                        //EnableControls("input[name=LA_41b]", "rdo");

                                        //EnableControls("input[name=LA_42a]", "rdo");
                                        //EnableControls("LA_42a_a", "txt");
                                        //EnableControls("input[name=LA_42b]", "rdo");

                                        //EnableControls("input[name=LA_43a]", "rdo");
                                        //EnableControls("LA_43a_a", "txt");
                                        //EnableControls("input[name=LA_43b]", "rdo");

                                        //EnableControls("input[name=LA_44a]", "rdo");
                                        //EnableControls("LA_44a_a", "txt");
                                        //EnableControls("input[name=LA_44b]", "rdo");

                                        //EnableControls("input[name=LA_45a]", "rdo");
                                        //EnableControls("LA_45a_a", "txt");
                                        //EnableControls("input[name=LA_45b]", "rdo");

                                        //EnableControls("input[name=LA_46a]", "rdo");
                                        //EnableControls("LA_46a_a", "txt");
                                        //EnableControls("input[name=LA_46b]", "rdo");

                                        //EnableControls("input[name=LA_47a]", "rdo");
                                        //EnableControls("LA_47a_a", "txt");
                                        //EnableControls("input[name=LA_47b]", "rdo");

                                        //EnableControls("input[name=LA_48a]", "rdo");
                                        //EnableControls("LA_48a_a", "txt");
                                        //EnableControls("input[name=LA_48b]", "rdo");

                                        //EnableControls("input[name=LA_49a]", "rdo");
                                        //EnableControls("LA_49a_a", "txt");
                                        //EnableControls("input[name=LA_49b]", "rdo");

                                        //EnableControls("input[name=LA_50a]", "rdo");
                                        //EnableControls("LA_50a_a", "txt");
                                        //EnableControls("input[name=LA_50b]", "rdo");

                                        //EnableControls("input[name=LA_51a]", "rdo");
                                        //EnableControls("LA_51a_a", "txt");
                                        //EnableControls("input[name=LA_51b]", "rdo");

                                        //EnableControls("input[name=LA_52a]", "rdo");
                                        //EnableControls("LA_52a_a", "txt");
                                        //EnableControls("input[name=LA_52b]", "rdo");


                                        $("#la_fsite").val(data.d[0]["AS1_fsite"]);
                                        $("#la_rand").val(data.d[0]["AS1_rand_id"]);
                                        $("#la_spec").val(data.d[0]["AS1_barcode"]);
                                        $("#la_name").val(data.d[0]["AS1_name"]);
                                        $("#la_gen").val(data.d[0]["AS1_sex"]);
                                        $("#la_age").val(data.d[0]["AS1_age"]);
                                        $("#la_obj").val(data.d[0]["AS1_Q1_1"]);


                                        if ($("#LA_03_v").is(":visible") == true) {
                                            $("#LA_03_v").focus();
                                        }
                                        else {
                                            $("#LA_01").focus();
                                        }


                                        $("#cmdSave").show();
                                    }
                                }

                            },
                            error: function (
                                xhr,
                                ajaxOptions,
                                thrownError) {

                                alert('Error: ');

                            }
                        });

                    $("#cmdSave").show();

                }



            }

        });


    </script>


    <script>


        $(document).on("change", "#LF_01_v", function () {
            ShowHide_TextBox($("input[name=LF_01]:checked").val(), $("#LF_01_a"), "LF_01_v", $("#lbl_LF_01_a"));
        });


        $(document).on("change", "#LF_01_b", function () {
            ShowHide_TextBox($("input[name=LF_01]:checked").val(), $("#LF_01_a"), "LF_01_v", $("#lbl_LF_01_a"));
        });


        $(document).on("change", "#LF_01_c", function () {
            ShowHide_TextBox($("input[name=LF_01]:checked").val(), $("#LF_01_a"), "LF_01_v", $("#lbl_LF_01_a"));
        });




        $(document).on("change", "#LF_02_v", function () {
            ShowHide_TextBox($("input[name=LF_02]:checked").val(), $("#LF_02_a"), "LF_02_v", $("#lbl_LF_02_a"));
        });


        $(document).on("change", "#LF_02_b", function () {
            ShowHide_TextBox($("input[name=LF_02]:checked").val(), $("#LF_02_a"), "LF_02_v", $("#lbl_LF_02_a"));
        });


        $(document).on("change", "#LF_02_c", function () {
            ShowHide_TextBox($("input[name=LF_02]:checked").val(), $("#LF_02_a"), "LF_02_v", $("#lbl_LF_02_a"));
        });




        $(document).on("change", "#LF_03_v", function () {
            ShowHide_TextBox($("input[name=LF_03]:checked").val(), $("#LF_03_a"), "LF_03_v", $("#lbl_LF_03_a"));
        });


        $(document).on("change", "#LF_03_b", function () {
            ShowHide_TextBox($("input[name=LF_03]:checked").val(), $("#LF_03_a"), "LF_03_v", $("#lbl_LF_03_a"));
        });


        $(document).on("change", "#LF_03_c", function () {
            ShowHide_TextBox($("input[name=LF_03]:checked").val(), $("#LF_03_a"), "LF_03_v", $("#lbl_LF_03_a"));
        });



        $(document).on("change", "#LF_04_v", function () {
            ShowHide_TextBox($("input[name=LF_04]:checked").val(), $("#LF_04_a"), "LF_04_v", $("#lbl_LF_04_a"));
        });


        $(document).on("change", "#LF_04_b", function () {
            ShowHide_TextBox($("input[name=LF_04]:checked").val(), $("#LF_04_a"), "LF_04_v", $("#lbl_LF_04_a"));
        });


        $(document).on("change", "#LF_04_c", function () {
            ShowHide_TextBox($("input[name=LF_04]:checked").val(), $("#LF_04_a"), "LF_04_v", $("#lbl_LF_04_a"));
        });




        $(document).on("change", "#LF_05_v", function () {
            ShowHide_TextBox($("input[name=LF_05]:checked").val(), $("#LF_05_a"), "LF_05_v", $("#lbl_LF_05_a"));
        });


        $(document).on("change", "#LF_05_b", function () {
            ShowHide_TextBox($("input[name=LF_05]:checked").val(), $("#LF_05_a"), "LF_05_v", $("#lbl_LF_05_a"));
        });


        $(document).on("change", "#LF_05_c", function () {
            ShowHide_TextBox($("input[name=LF_05]:checked").val(), $("#LF_05_a"), "LF_05_v", $("#lbl_LF_05_a"));
        });




        $(document).on("change", "#LF_06_v", function () {
            ShowHide_TextBox($("input[name=LF_06]:checked").val(), $("#LF_06_a"), "LF_06_v", $("#lbl_LF_06_a"));
        });


        $(document).on("change", "#LF_06_b", function () {
            ShowHide_TextBox($("input[name=LF_06]:checked").val(), $("#LF_06_a"), "LF_06_v", $("#lbl_LF_06_a"));
        });


        $(document).on("change", "#LF_06_c", function () {
            ShowHide_TextBox($("input[name=LF_06]:checked").val(), $("#LF_06_a"), "LF_06_v", $("#lbl_LF_06_a"));
        });




        $(document).on("change", "#LF_07_v", function () {
            ShowHide_TextBox($("input[name=LF_07]:checked").val(), $("#LF_07_a"), "LF_07_v", $("#lbl_LF_07_a"));
        });


        $(document).on("change", "#LF_07_b", function () {
            ShowHide_TextBox($("input[name=LF_07]:checked").val(), $("#LF_07_a"), "LF_07_v", $("#lbl_LF_07_a"));
        });


        $(document).on("change", "#LF_07_c", function () {
            ShowHide_TextBox($("input[name=LF_07]:checked").val(), $("#LF_07_a"), "LF_07_v", $("#lbl_LF_07_a"));
        });




        $(document).on("change", "#RF_01_v", function () {
            ShowHide_TextBox($("input[name=RF_01]:checked").val(), $("#RF_01_a"), "RF_01_v", $("#lbl_RF_01_a"));
        });


        $(document).on("change", "#RF_01_b", function () {
            ShowHide_TextBox($("input[name=RF_01]:checked").val(), $("#RF_01_a"), "RF_01_v", $("#lbl_RF_01_a"));
        });


        $(document).on("change", "#RF_01_c", function () {
            ShowHide_TextBox($("input[name=RF_01]:checked").val(), $("#RF_01_a"), "RF_01_v", $("#lbl_RF_01_a"));
        });




        $(document).on("change", "#RF_02_v", function () {
            ShowHide_TextBox($("input[name=RF_02]:checked").val(), $("#RF_02_a"), "RF_02_v", $("#lbl_RF_02_a"));
        });


        $(document).on("change", "#RF_02_b", function () {
            ShowHide_TextBox($("input[name=RF_02]:checked").val(), $("#RF_02_a"), "RF_02_v", $("#lbl_RF_02_a"));
        });


        $(document).on("change", "#RF_02_c", function () {
            ShowHide_TextBox($("input[name=RF_02]:checked").val(), $("#RF_02_a"), "RF_02_v", $("#lbl_RF_02_a"));
        });




        $(document).on("change", "#RF_03_v", function () {
            ShowHide_TextBox($("input[name=RF_03]:checked").val(), $("#RF_03_a"), "RF_03_v", $("#lbl_RF_03_a"));
        });


        $(document).on("change", "#RF_03_b", function () {
            ShowHide_TextBox($("input[name=RF_03]:checked").val(), $("#RF_03_a"), "RF_03_v", $("#lbl_RF_03_a"));
        });


        $(document).on("change", "#RF_03_c", function () {
            ShowHide_TextBox($("input[name=RF_03]:checked").val(), $("#RF_03_a"), "RF_03_v", $("#lbl_RF_03_a"));
        });




        $(document).on("change", "#RF_04_v", function () {
            ShowHide_TextBox($("input[name=RF_04]:checked").val(), $("#RF_04_a"), "RF_04_v", $("#lbl_RF_04_a"));
        });


        $(document).on("change", "#RF_04_b", function () {
            ShowHide_TextBox($("input[name=RF_04]:checked").val(), $("#RF_04_a"), "RF_04_v", $("#lbl_RF_04_a"));
        });


        $(document).on("change", "#RF_04_c", function () {
            ShowHide_TextBox($("input[name=RF_04]:checked").val(), $("#RF_04_a"), "RF_04_v", $("#lbl_RF_04_a"));
        });






        $(document).on("change", "#SE_01_v", function () {
            ShowHide_TextBox($("input[name=SE_01]:checked").val(), $("#SE_01_a"), "SE_01_v", $("#lbl_SE_01_a"));
        });


        $(document).on("change", "#SE_01_b", function () {
            ShowHide_TextBox($("input[name=SE_01]:checked").val(), $("#SE_01_a"), "SE_01_v", $("#lbl_SE_01_a"));
        });


        $(document).on("change", "#SE_01_c", function () {
            ShowHide_TextBox($("input[name=SE_01]:checked").val(), $("#SE_01_a"), "SE_01_v", $("#lbl_SE_01_a"));
        });




        $(document).on("change", "#SE_02_v", function () {
            ShowHide_TextBox($("input[name=SE_02]:checked").val(), $("#SE_02_a"), "SE_02_v", $("#lbl_SE_02_a"));
        });


        $(document).on("change", "#SE_02_b", function () {
            ShowHide_TextBox($("input[name=SE_02]:checked").val(), $("#SE_02_a"), "SE_02_v", $("#lbl_SE_02_a"));
        });


        $(document).on("change", "#SE_02_c", function () {
            ShowHide_TextBox($("input[name=SE_02]:checked").val(), $("#SE_02_a"), "SE_02_v", $("#lbl_SE_02_a"));
        });




        $(document).on("change", "#SE_03_v", function () {
            ShowHide_TextBox($("input[name=SE_03]:checked").val(), $("#SE_03_a"), "SE_03_v", $("#lbl_SE_03_a"));
        });


        $(document).on("change", "#SE_03_b", function () {
            ShowHide_TextBox($("input[name=SE_03]:checked").val(), $("#SE_03_a"), "SE_03_v", $("#lbl_SE_03_a"));
        });


        $(document).on("change", "#SE_03_c", function () {
            ShowHide_TextBox($("input[name=SE_03]:checked").val(), $("#SE_03_a"), "SE_03_v", $("#lbl_SE_03_a"));
        });




        $(document).on("change", "#SE_04_v", function () {
            ShowHide_TextBox($("input[name=SE_04]:checked").val(), $("#SE_04_a"), "SE_04_v", $("#lbl_SE_04_a"));
        });


        $(document).on("change", "#SE_04_b", function () {
            ShowHide_TextBox($("input[name=SE_04]:checked").val(), $("#SE_04_a"), "SE_04_v", $("#lbl_SE_04_a"));
        });


        $(document).on("change", "#SE_04_c", function () {
            ShowHide_TextBox($("input[name=SE_04]:checked").val(), $("#SE_04_a"), "SE_04_v", $("#lbl_SE_04_a"));
        });




        $(document).on("change", "#CS_01_v", function () {
            ShowHide_TextBox($("input[name=CS_01]:checked").val(), $("#CS_01_a"), "CS_01_v", $("#lbl_CS_01_a"));
        });


        $(document).on("change", "#CS_01_b", function () {
            ShowHide_TextBox($("input[name=CS_01]:checked").val(), $("#CS_01_a"), "CS_01_v", $("#lbl_CS_01_a"));
        });


        $(document).on("change", "#CS_01_c", function () {
            ShowHide_TextBox($("input[name=CS_01]:checked").val(), $("#CS_01_a"), "CS_01_v", $("#lbl_CS_01_a"));
        });




        $(document).on("change", "#CS_02_v", function () {
            ShowHide_TextBox($("input[name=CS_02]:checked").val(), $("#CS_02_a"), "CS_02_v", $("#lbl_CS_02_a"));
        });


        $(document).on("change", "#CS_02_b", function () {
            ShowHide_TextBox($("input[name=CS_02]:checked").val(), $("#CS_02_a"), "CS_02_v", $("#lbl_CS_02_a"));
        });


        $(document).on("change", "#CS_02_c", function () {
            ShowHide_TextBox($("input[name=CS_02]:checked").val(), $("#CS_02_a"), "CS_02_v", $("#lbl_CS_02_a"));
        });





        $(document).on("change", "#CS_03_v", function () {
            ShowHide_TextBox($("input[name=CS_03]:checked").val(), $("#CS_03_a"), "CS_03_v", $("#lbl_CS_03_a"));
        });


        $(document).on("change", "#CS_03_b", function () {
            ShowHide_TextBox($("input[name=CS_03]:checked").val(), $("#CS_03_a"), "CS_03_v", $("#lbl_CS_03_a"));
        });


        $(document).on("change", "#CS_03_c", function () {
            ShowHide_TextBox($("input[name=CS_03]:checked").val(), $("#CS_03_a"), "CS_03_v", $("#lbl_CS_03_a"));
        });




        $(document).on("change", "#CS_04_v", function () {
            ShowHide_TextBox($("input[name=CS_04]:checked").val(), $("#CS_04_a"), "CS_04_v", $("#lbl_CS_04_a"));
        });


        $(document).on("change", "#CS_04_b", function () {
            ShowHide_TextBox($("input[name=CS_04]:checked").val(), $("#CS_04_a"), "CS_04_v", $("#lbl_CS_04_a"));
        });


        $(document).on("change", "#CS_04_c", function () {
            ShowHide_TextBox($("input[name=CS_04]:checked").val(), $("#CS_04_a"), "CS_04_v", $("#lbl_CS_04_a"));
        });




        $(document).on("change", "#CS_05_v", function () {
            ShowHide_TextBox($("input[name=CS_05]:checked").val(), $("#CS_05_a"), "CS_05_v", $("#lbl_CS_05_a"));
        });


        $(document).on("change", "#CS_05_b", function () {
            ShowHide_TextBox($("input[name=CS_05]:checked").val(), $("#CS_05_a"), "CS_05_v", $("#lbl_CS_05_a"));
        });


        $(document).on("change", "#CS_05_c", function () {
            ShowHide_TextBox($("input[name=CS_05]:checked").val(), $("#CS_05_a"), "CS_05_v", $("#lbl_CS_05_a"));
        });




        $(document).on("change", "#CS_06_v", function () {
            ShowHide_TextBox($("input[name=CS_06]:checked").val(), $("#CS_06_a"), "CS_06_v", $("#lbl_CS_06_a"));
        });


        $(document).on("change", "#CS_06_b", function () {
            ShowHide_TextBox($("input[name=CS_06]:checked").val(), $("#CS_06_a"), "CS_06_v", $("#lbl_CS_06_a"));
        });


        $(document).on("change", "#CS_06_c", function () {
            ShowHide_TextBox($("input[name=CS_06]:checked").val(), $("#CS_06_a"), "CS_06_v", $("#lbl_CS_06_a"));
        });




        $(document).on("change", "#CS_07_v", function () {
            ShowHide_TextBox($("input[name=CS_07]:checked").val(), $("#CS_07_a"), "CS_07_v", $("#lbl_CS_07_a"));
        });


        $(document).on("change", "#CS_07_b", function () {
            ShowHide_TextBox($("input[name=CS_07]:checked").val(), $("#CS_07_a"), "CS_07_v", $("#lbl_CS_07_a"));
        });


        $(document).on("change", "#CS_07_c", function () {
            ShowHide_TextBox($("input[name=CS_07]:checked").val(), $("#CS_07_a"), "CS_07_v", $("#lbl_CS_07_a"));
        });




        $(document).on("change", "#CS_08_v", function () {
            ShowHide_TextBox($("input[name=CS_08]:checked").val(), $("#CS_08_a"), "CS_08_v", $("#lbl_CS_08_a"));
        });


        $(document).on("change", "#CS_08_b", function () {
            ShowHide_TextBox($("input[name=CS_08]:checked").val(), $("#CS_08_a"), "CS_08_v", $("#lbl_CS_08_a"));
        });


        $(document).on("change", "#CS_08_c", function () {
            ShowHide_TextBox($("input[name=CS_08]:checked").val(), $("#CS_08_a"), "CS_08_v", $("#lbl_CS_08_a"));
        });




        $(document).on("change", "#CS_09_v", function () {
            ShowHide_TextBox($("input[name=CS_09]:checked").val(), $("#CS_09_a"), "CS_09_v", $("#lbl_CS_09_a"));
        });


        $(document).on("change", "#CS_09_b", function () {
            ShowHide_TextBox($("input[name=CS_09]:checked").val(), $("#CS_09_a"), "CS_09_v", $("#lbl_CS_09_a"));
        });


        $(document).on("change", "#CS_09_c", function () {
            ShowHide_TextBox($("input[name=CS_09]:checked").val(), $("#CS_09_a"), "CS_09_v", $("#lbl_CS_09_a"));
        });




        $(document).on("change", "#CS_10_v", function () {
            ShowHide_TextBox($("input[name=CS_10]:checked").val(), $("#CS_10_a"), "CS_10_v", $("#lbl_CS_10_a"));
        });


        $(document).on("change", "#CS_10_b", function () {
            ShowHide_TextBox($("input[name=CS_10]:checked").val(), $("#CS_10_a"), "CS_10_v", $("#lbl_CS_10_a"));
        });


        $(document).on("change", "#CS_10_c", function () {
            ShowHide_TextBox($("input[name=CS_10]:checked").val(), $("#CS_10_a"), "CS_10_v", $("#lbl_CS_10_a"));
        });





        $(document).on("change", "#UR_01_v", function () {
            ShowHide_TextBox($("input[name=UR_01]:checked").val(), $("#UR_01_a"), "UR_01_v", $("#lbl_UR_01_a"));
        });


        $(document).on("change", "#UR_01_b", function () {
            ShowHide_TextBox($("input[name=UR_01]:checked").val(), $("#UR_01_a"), "UR_01_v", $("#lbl_UR_01_a"));
        });


        $(document).on("change", "#UR_01_c", function () {
            ShowHide_TextBox($("input[name=UR_01]:checked").val(), $("#UR_01_a"), "UR_01_v", $("#lbl_UR_01_a"));
        });




        $(document).on("change", "#UR_02_v", function () {
            ShowHide_TextBox($("input[name=UR_02]:checked").val(), $("#UR_02_a"), "UR_02_v", $("#lbl_UR_02_a"));
        });


        $(document).on("change", "#UR_02_b", function () {
            ShowHide_TextBox($("input[name=UR_02]:checked").val(), $("#UR_02_a"), "UR_02_v", $("#lbl_UR_02_a"));
        });


        $(document).on("change", "#UR_02_c", function () {
            ShowHide_TextBox($("input[name=UR_02]:checked").val(), $("#UR_02_a"), "UR_02_v", $("#lbl_UR_02_a"));
        });




        $(document).on("change", "#UR_03_v", function () {
            ShowHide_TextBox($("input[name=UR_03]:checked").val(), $("#UR_03_a"), "UR_03_v", $("#lbl_UR_03_a"));
        });


        $(document).on("change", "#UR_03_b", function () {
            ShowHide_TextBox($("input[name=UR_03]:checked").val(), $("#UR_03_a"), "UR_03_v", $("#lbl_UR_03_a"));
        });


        $(document).on("change", "#UR_03_c", function () {
            ShowHide_TextBox($("input[name=UR_03]:checked").val(), $("#UR_03_a"), "UR_03_v", $("#lbl_UR_03_a"));
        });




        $(document).on("change", "#UR_04_v", function () {
            ShowHide_TextBox($("input[name=UR_04]:checked").val(), $("#UR_04_a"), "UR_04_v", $("#lbl_UR_04_a"));
        });


        $(document).on("change", "#UR_04_b", function () {
            ShowHide_TextBox($("input[name=UR_04]:checked").val(), $("#UR_04_a"), "UR_04_v", $("#lbl_UR_04_a"));
        });


        $(document).on("change", "#UR_04_c", function () {
            ShowHide_TextBox($("input[name=UR_04]:checked").val(), $("#UR_04_a"), "UR_04_v", $("#lbl_UR_04_a"));
        });




        $(document).on("change", "#UR_04a_v", function () {
            ShowHide_TextBox($("input[name=UR_04a]:checked").val(), $("#UR_04a_a"), "UR_04a_v", $("#lbl_UR_04a_a"));
        });


        $(document).on("change", "#UR_04a_b", function () {
            ShowHide_TextBox($("input[name=UR_04a]:checked").val(), $("#UR_04a_a"), "UR_04a_v", $("#lbl_UR_04a_a"));
        });


        $(document).on("change", "#UR_04a_c", function () {
            ShowHide_TextBox($("input[name=UR_04a]:checked").val(), $("#UR_04a_a"), "UR_04a_v", $("#lbl_UR_04a_a"));
        });





        $(document).on("change", "#UR_05_v", function () {
            ShowHide_TextBox($("input[name=UR_05]:checked").val(), $("#UR_05_a"), "UR_05_v", $("#lbl_UR_05_a"));
        });


        $(document).on("change", "#UR_05_b", function () {
            ShowHide_TextBox($("input[name=UR_05]:checked").val(), $("#UR_05_a"), "UR_05_v", $("#lbl_UR_05_a"));
        });


        $(document).on("change", "#UR_05_c", function () {
            ShowHide_TextBox($("input[name=UR_05]:checked").val(), $("#UR_05_a"), "UR_05_v", $("#lbl_UR_05_a"));
        });



        $(document).on("change", "#UR_06_v", function () {
            ShowHide_TextBox($("input[name=UR_06]:checked").val(), $("#UR_06_a"), "UR_06_v", $("#lbl_UR_06_a"));
        });


        $(document).on("change", "#UR_06_b", function () {
            ShowHide_TextBox($("input[name=UR_06]:checked").val(), $("#UR_06_a"), "UR_06_v", $("#lbl_UR_06_a"));
        });


        $(document).on("change", "#UR_06_c", function () {
            ShowHide_TextBox($("input[name=UR_06]:checked").val(), $("#UR_06_a"), "UR_06_v", $("#lbl_UR_06_a"));
        });




        $(document).on("change", "#UR_07_v", function () {
            ShowHide_TextBox($("input[name=UR_07]:checked").val(), $("#UR_07_a"), "UR_07_v", $("#lbl_UR_07_a"));
        });


        $(document).on("change", "#UR_07_b", function () {
            ShowHide_TextBox($("input[name=UR_07]:checked").val(), $("#UR_07_a"), "UR_07_v", $("#lbl_UR_07_a"));
        });


        $(document).on("change", "#UR_07_c", function () {
            ShowHide_TextBox($("input[name=UR_07]:checked").val(), $("#UR_07_a"), "UR_07_v", $("#lbl_UR_07_a"));
        });





        $(document).on("change", "#UR_08_v", function () {
            ShowHide_TextBox($("input[name=UR_08]:checked").val(), $("#UR_08_a"), "UR_08_v", $("#lbl_UR_08_a"));
        });


        $(document).on("change", "#UR_08_b", function () {
            ShowHide_TextBox($("input[name=UR_08]:checked").val(), $("#UR_08_a"), "UR_08_v", $("#lbl_UR_08_a"));
        });


        $(document).on("change", "#UR_08_c", function () {
            ShowHide_TextBox($("input[name=UR_08]:checked").val(), $("#UR_08_a"), "UR_08_v", $("#lbl_UR_08_a"));
        });




        $(document).on("change", "#UR_09_v", function () {
            ShowHide_TextBox($("input[name=UR_09]:checked").val(), $("#UR_09_a"), "UR_09_v", $("#lbl_UR_09_a"));
        });


        $(document).on("change", "#UR_09_b", function () {
            ShowHide_TextBox($("input[name=UR_09]:checked").val(), $("#UR_09_a"), "UR_09_v", $("#lbl_UR_09_a"));
        });


        $(document).on("change", "#UR_09_c", function () {
            ShowHide_TextBox($("input[name=UR_09]:checked").val(), $("#UR_09_a"), "UR_09_v", $("#lbl_UR_09_a"));
        });




        $(document).on("change", "#UR_10_v", function () {
            ShowHide_TextBox($("input[name=UR_10]:checked").val(), $("#UR_10_a"), "UR_10_v", $("#lbl_UR_10_a"));
        });


        $(document).on("change", "#UR_10_b", function () {
            ShowHide_TextBox($("input[name=UR_10]:checked").val(), $("#UR_10_a"), "UR_10_v", $("#lbl_UR_10_a"));
        });


        $(document).on("change", "#UR_10_c", function () {
            ShowHide_TextBox($("input[name=UR_10]:checked").val(), $("#UR_10_a"), "UR_10_v", $("#lbl_UR_10_a"));
        });




        $(document).on("change", "#UR_11_v", function () {
            ShowHide_TextBox($("input[name=UR_11]:checked").val(), $("#UR_11_a"), "UR_11_v", $("#lbl_UR_11_a"));
        });


        $(document).on("change", "#UR_11_b", function () {
            ShowHide_TextBox($("input[name=UR_11]:checked").val(), $("#UR_11_a"), "UR_11_v", $("#lbl_UR_11_a"));
        });


        $(document).on("change", "#UR_11_c", function () {
            ShowHide_TextBox($("input[name=UR_11]:checked").val(), $("#UR_11_a"), "UR_11_v", $("#lbl_UR_11_a"));
        });




        $(document).on("change", "#UR_12_v", function () {
            ShowHide_TextBox($("input[name=UR_12]:checked").val(), $("#UR_12_a"), "UR_12_v", $("#lbl_UR_12_a"));
        });


        $(document).on("change", "#UR_12_b", function () {
            ShowHide_TextBox($("input[name=UR_12]:checked").val(), $("#UR_12_a"), "UR_12_v", $("#lbl_UR_12_a"));
        });


        $(document).on("change", "#UR_12_c", function () {
            ShowHide_TextBox($("input[name=UR_12]:checked").val(), $("#UR_12_a"), "UR_12_v", $("#lbl_UR_12_a"));
        });



        $(document).on("change", "#UR_13_v", function () {
            ShowHide_TextBox($("input[name=UR_13]:checked").val(), $("#UR_13_a"), "UR_13_v", $("#lbl_UR_13_a"));
        });


        $(document).on("change", "#UR_13_b", function () {
            ShowHide_TextBox($("input[name=UR_13]:checked").val(), $("#UR_13_a"), "UR_13_v", $("#lbl_UR_13_a"));
        });


        $(document).on("change", "#UR_13_c", function () {
            ShowHide_TextBox($("input[name=UR_13]:checked").val(), $("#UR_13_a"), "UR_13_v", $("#lbl_UR_13_a"));
        });




        $(document).on("change", "#UR_14_v", function () {
            ShowHide_TextBox($("input[name=UR_14]:checked").val(), $("#UR_14_a"), "UR_14_v", $("#lbl_UR_14_a"));
        });


        $(document).on("change", "#UR_14_b", function () {
            ShowHide_TextBox($("input[name=UR_14]:checked").val(), $("#UR_14_a"), "UR_14_v", $("#lbl_UR_14_a"));
        });


        $(document).on("change", "#UR_14_c", function () {
            ShowHide_TextBox($("input[name=UR_14]:checked").val(), $("#UR_14_a"), "UR_14_v", $("#lbl_UR_14_a"));
        });




        $(document).on("change", "#UR_15_v", function () {
            ShowHide_TextBox($("input[name=UR_15]:checked").val(), $("#UR_15_a"), "UR_15_v", $("#lbl_UR_15_a"));
        });


        $(document).on("change", "#UR_15_b", function () {
            ShowHide_TextBox($("input[name=UR_15]:checked").val(), $("#UR_15_a"), "UR_15_v", $("#lbl_UR_15_a"));
        });


        $(document).on("change", "#UR_15_c", function () {
            ShowHide_TextBox($("input[name=UR_15]:checked").val(), $("#UR_15_a"), "UR_15_v", $("#lbl_UR_15_a"));
        });




        $(document).on("change", "#UR_16_v", function () {
            ShowHide_TextBox($("input[name=UR_16]:checked").val(), $("#UR_16_a"), "UR_16_v", $("#lbl_UR_16_a"));
        });


        $(document).on("change", "#UR_16_b", function () {
            ShowHide_TextBox($("input[name=UR_16]:checked").val(), $("#UR_16_a"), "UR_16_v", $("#lbl_UR_16_a"));
        });


        $(document).on("change", "#UR_16_c", function () {
            ShowHide_TextBox($("input[name=UR_16]:checked").val(), $("#UR_16_a"), "UR_16_v", $("#lbl_UR_16_a"));
        });




        $(document).on("change", "#UR_17_v", function () {
            ShowHide_TextBox($("input[name=UR_17]:checked").val(), $("#UR_17_a"), "UR_17_v", $("#lbl_UR_17_a"));
        });


        $(document).on("change", "#UR_17_b", function () {
            ShowHide_TextBox($("input[name=UR_17]:checked").val(), $("#UR_17_a"), "UR_17_v", $("#lbl_UR_17_a"));
        });


        $(document).on("change", "#UR_17_c", function () {
            ShowHide_TextBox($("input[name=UR_17]:checked").val(), $("#UR_17_a"), "UR_17_v", $("#lbl_UR_17_a"));
        });




        $(document).on("change", "#UR_18_v", function () {
            ShowHide_TextBox($("input[name=UR_18]:checked").val(), $("#UR_18_a"), "UR_18_v", $("#lbl_UR_18_a"));
        });


        $(document).on("change", "#UR_18_b", function () {
            ShowHide_TextBox($("input[name=UR_18]:checked").val(), $("#UR_18_a"), "UR_18_v", $("#lbl_UR_18_a"));
        });


        $(document).on("change", "#UR_18_c", function () {
            ShowHide_TextBox($("input[name=UR_18]:checked").val(), $("#UR_18_a"), "UR_18_v", $("#lbl_UR_18_a"));
        });




        $(document).on("change", "#UR_19_v", function () {
            ShowHide_TextBox($("input[name=UR_19]:checked").val(), $("#UR_19_a"), "UR_19_v", $("#lbl_UR_19_a"));
        });


        $(document).on("change", "#UR_19_b", function () {
            ShowHide_TextBox($("input[name=UR_19]:checked").val(), $("#UR_19_a"), "UR_19_v", $("#lbl_UR_19_a"));
        });


        $(document).on("change", "#UR_19_c", function () {
            ShowHide_TextBox($("input[name=UR_19]:checked").val(), $("#UR_19_a"), "UR_19_v", $("#lbl_UR_19_a"));
        });




        $(document).on("change", "#UR_20_v", function () {
            ShowHide_TextBox($("input[name=UR_20]:checked").val(), $("#UR_20_a"), "UR_20_v", $("#lbl_UR_20_a"));
        });


        $(document).on("change", "#UR_20_b", function () {
            ShowHide_TextBox($("input[name=UR_20]:checked").val(), $("#UR_20_a"), "UR_20_v", $("#lbl_UR_20_a"));
        });


        $(document).on("change", "#UR_20_c", function () {
            ShowHide_TextBox($("input[name=UR_20]:checked").val(), $("#UR_20_a"), "UR_20_v", $("#lbl_UR_20_a"));
        });




        $(document).on("change", "#UR_21_v", function () {
            ShowHide_TextBox($("input[name=UR_21]:checked").val(), $("#UR_21_a"), "UR_21_v", $("#lbl_UR_21_a"));
        });


        $(document).on("change", "#UR_21_b", function () {
            ShowHide_TextBox($("input[name=UR_21]:checked").val(), $("#UR_21_a"), "UR_21_v", $("#lbl_UR_21_a"));
        });


        $(document).on("change", "#UR_21_c", function () {
            ShowHide_TextBox($("input[name=UR_21]:checked").val(), $("#UR_21_a"), "UR_21_v", $("#lbl_UR_21_a"));
        });







        $(document).on("change", "#LA_03_v", function () {
            ShowHide_TextBox($("input[name=LA_03]:checked").val(), $("#LA_03_a"), "LA_03_v", $("#lbl_LA_03_a"));
        });


        $(document).on("change", "#LA_03_b", function () {
            ShowHide_TextBox($("input[name=LA_03]:checked").val(), $("#LA_03_a"), "LA_03_v", $("#lbl_LA_03_a"));
        });


        $(document).on("change", "#LA_03_c", function () {
            ShowHide_TextBox($("input[name=LA_03]:checked").val(), $("#LA_03_a"), "LA_03_v", $("#lbl_LA_03_a"));
        });




        $(document).on("change", "#LA_04_v", function () {
            ShowHide_TextBox($("input[name=LA_04]:checked").val(), $("#LA_04_a"), "LA_04_v", $("#lbl_LA_04_a"));
        });


        $(document).on("change", "#LA_04_b", function () {
            ShowHide_TextBox($("input[name=LA_04]:checked").val(), $("#LA_04_a"), "LA_04_v", $("#lbl_LA_04_a"));
        });


        $(document).on("change", "#LA_04_c", function () {
            ShowHide_TextBox($("input[name=LA_04]:checked").val(), $("#LA_04_a"), "LA_04_v", $("#lbl_LA_04_a"));
        });




        $(document).on("change", "#LA_05_v", function () {
            ShowHide_TextBox($("input[name=LA_05]:checked").val(), $("#LA_05_a"), "LA_05_v", $("#lbl_LA_05_a"));
        });


        $(document).on("change", "#LA_05_b", function () {
            ShowHide_TextBox($("input[name=LA_05]:checked").val(), $("#LA_05_a"), "LA_05_v", $("#lbl_LA_05_a"));
        });


        $(document).on("change", "#LA_05_c", function () {
            ShowHide_TextBox($("input[name=LA_05]:checked").val(), $("#LA_05_a"), "LA_05_v", $("#lbl_LA_05_a"));
        });





        $(document).on("change", "#LA_06_v", function () {
            ShowHide_TextBox($("input[name=LA_06]:checked").val(), $("#LA_06_a"), "LA_06_v", $("#lbl_LA_06_a"));
        });


        $(document).on("change", "#LA_06_b", function () {
            ShowHide_TextBox($("input[name=LA_06]:checked").val(), $("#LA_06_a"), "LA_06_v", $("#lbl_LA_06_a"));
        });


        $(document).on("change", "#LA_06_c", function () {
            ShowHide_TextBox($("input[name=LA_06]:checked").val(), $("#LA_06_a"), "LA_06_v", $("#lbl_LA_06_a"));
        });





        $(document).on("change", "#LA_07_v", function () {
            ShowHide_TextBox($("input[name=LA_07]:checked").val(), $("#LA_07_a"), "LA_07_v", $("#lbl_LA_07_a"));
        });


        $(document).on("change", "#LA_07_b", function () {
            ShowHide_TextBox($("input[name=LA_07]:checked").val(), $("#LA_07_a"), "LA_07_v", $("#lbl_LA_07_a"));
        });


        $(document).on("change", "#LA_07_c", function () {
            ShowHide_TextBox($("input[name=LA_07]:checked").val(), $("#LA_07_a"), "LA_07_v", $("#lbl_LA_07_a"));
        });





        $(document).on("change", "#LA_08_v", function () {
            ShowHide_TextBox($("input[name=LA_08]:checked").val(), $("#LA_08_a"), "LA_08_v", $("#lbl_LA_08_a"));
        });


        $(document).on("change", "#LA_08_b", function () {
            ShowHide_TextBox($("input[name=LA_08]:checked").val(), $("#LA_08_a"), "LA_08_v", $("#lbl_LA_08_a"));
        });


        $(document).on("change", "#LA_08_c", function () {
            ShowHide_TextBox($("input[name=LA_08]:checked").val(), $("#LA_08_a"), "LA_08_v", $("#lbl_LA_08_a"));
        });




        $(document).on("change", "#LA_09_v", function () {
            ShowHide_TextBox($("input[name=LA_09]:checked").val(), $("#LA_09_a"), "LA_09_v", $("#lbl_LA_09_a"));
        });


        $(document).on("change", "#LA_09_b", function () {
            ShowHide_TextBox($("input[name=LA_09]:checked").val(), $("#LA_09_a"), "LA_09_v", $("#lbl_LA_09_a"));
        });


        $(document).on("change", "#LA_09_c", function () {
            ShowHide_TextBox($("input[name=LA_09]:checked").val(), $("#LA_09_a"), "LA_09_v", $("#lbl_LA_09_a"));
        });





        $(document).on("change", "#LA_10_v", function () {
            ShowHide_TextBox($("input[name=LA_10]:checked").val(), $("#LA_10_a"), "LA_10_v", $("#lbl_LA_10_a"));
        });


        $(document).on("change", "#LA_10_b", function () {
            ShowHide_TextBox($("input[name=LA_10]:checked").val(), $("#LA_10_a"), "LA_10_v", $("#lbl_LA_10_a"));
        });


        $(document).on("change", "#LA_10_c", function () {
            ShowHide_TextBox($("input[name=LA_10]:checked").val(), $("#LA_10_a"), "LA_10_v", $("#lbl_LA_10_a"));
        });





        $(document).on("change", "#LA_11_v", function () {
            ShowHide_TextBox($("input[name=LA_11]:checked").val(), $("#LA_11_a"), "LA_11_v", $("#lbl_LA_11_a"));
        });


        $(document).on("change", "#LA_11_b", function () {
            ShowHide_TextBox($("input[name=LA_11]:checked").val(), $("#LA_11_a"), "LA_11_v", $("#lbl_LA_11_a"));
        });


        $(document).on("change", "#LA_11_c", function () {
            ShowHide_TextBox($("input[name=LA_11]:checked").val(), $("#LA_11_a"), "LA_11_v", $("#lbl_LA_11_a"));
        });





        $(document).on("change", "#LA_12_v", function () {
            ShowHide_TextBox($("input[name=LA_12]:checked").val(), $("#LA_12_a"), "LA_12_v", $("#lbl_LA_12_a"));
        });


        $(document).on("change", "#LA_12_b", function () {
            ShowHide_TextBox($("input[name=LA_12]:checked").val(), $("#LA_12_a"), "LA_12_v", $("#lbl_LA_12_a"));
        });


        $(document).on("change", "#LA_12_c", function () {
            ShowHide_TextBox($("input[name=LA_12]:checked").val(), $("#LA_12_a"), "LA_12_v", $("#lbl_LA_12_a"));
        });





        $(document).on("change", "#LA_13_v", function () {
            ShowHide_TextBox($("input[name=LA_13]:checked").val(), $("#LA_13_a"), "LA_13_v", $("#lbl_LA_13_a"));
        });


        $(document).on("change", "#LA_13_b", function () {
            ShowHide_TextBox($("input[name=LA_13]:checked").val(), $("#LA_13_a"), "LA_13_v", $("#lbl_LA_13_a"));
        });


        $(document).on("change", "#LA_13_c", function () {
            ShowHide_TextBox($("input[name=LA_13]:checked").val(), $("#LA_13_a"), "LA_13_v", $("#lbl_LA_13_a"));
        });





        $(document).on("change", "#LA_14_v", function () {
            ShowHide_TextBox($("input[name=LA_14]:checked").val(), $("#LA_14_a"), "LA_14_v", $("#lbl_LA_14_a"));
        });


        $(document).on("change", "#LA_14_b", function () {
            ShowHide_TextBox($("input[name=LA_14]:checked").val(), $("#LA_14_a"), "LA_14_v", $("#lbl_LA_14_a"));
        });


        $(document).on("change", "#LA_14_c", function () {
            ShowHide_TextBox($("input[name=LA_14]:checked").val(), $("#LA_14_a"), "LA_14_v", $("#lbl_LA_14_a"));
        });





        $(document).on("change", "#LA_15_v", function () {
            ShowHide_TextBox($("input[name=LA_15]:checked").val(), $("#LA_15_a"), "LA_15_v", $("#lbl_LA_15_a"));
        });


        $(document).on("change", "#LA_15_b", function () {
            ShowHide_TextBox($("input[name=LA_15]:checked").val(), $("#LA_15_a"), "LA_15_v", $("#lbl_LA_15_a"));
        });


        $(document).on("change", "#LA_15_c", function () {
            ShowHide_TextBox($("input[name=LA_15]:checked").val(), $("#LA_15_a"), "LA_15_v", $("#lbl_LA_15_a"));
        });




        $(document).on("change", "#LA_16_v", function () {
            ShowHide_TextBox($("input[name=LA_16]:checked").val(), $("#LA_16_a"), "LA_16_v", $("#lbl_LA_16_a"));
        });


        $(document).on("change", "#LA_16_b", function () {
            ShowHide_TextBox($("input[name=LA_16]:checked").val(), $("#LA_16_a"), "LA_16_v", $("#lbl_LA_16_a"));
        });


        $(document).on("change", "#LA_16_c", function () {
            ShowHide_TextBox($("input[name=LA_16]:checked").val(), $("#LA_16_a"), "LA_16_v", $("#lbl_LA_16_a"));
        });




        $(document).on("change", "#LA_20a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_20a]:checked").val(), $("#LA_20a_a"), "LA_20a_v", $("#lbl_LA_20a_a"), $("input[name=LA_20b]"), $("#lbl_LA_20b"), $("#lbl_LA_20b_s"), $("#lbl_LA_20b_r"), $("#lbl_LA_20b_i"));
        });


        $(document).on("change", "#LA_20a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_20a]:checked").val(), $("#LA_20a_a"), "LA_20a_v", $("#lbl_LA_20a_a"), $("input[name=LA_20b]"), $("#lbl_LA_20b"), $("#lbl_LA_20b_s"), $("#lbl_LA_20b_r"), $("#lbl_LA_20b_i"));
        });


        $(document).on("change", "#LA_20a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_20a]:checked").val(), $("#LA_20a_a"), "LA_20a_v", $("#lbl_LA_20a_a"), $("input[name=LA_20b]"), $("#lbl_LA_20b"), $("#lbl_LA_20b_s"), $("#lbl_LA_20b_r"), $("#lbl_LA_20b_i"));
        });





        $(document).on("change", "#LA_21a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_21a]:checked").val(), $("#LA_21a_a"), "LA_21a_v", $("#lbl_LA_21a_a"), $("input[name=LA_21b]"), $("#lbl_LA_21b"), $("#lbl_LA_21b_s"), $("#lbl_LA_21b_r"), $("#lbl_LA_21b_i"));
        });


        $(document).on("change", "#LA_21a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_21a]:checked").val(), $("#LA_21a_a"), "LA_21a_v", $("#lbl_LA_21a_a"), $("input[name=LA_21b]"), $("#lbl_LA_21b"), $("#lbl_LA_21b_s"), $("#lbl_LA_21b_r"), $("#lbl_LA_21b_i"));
        });


        $(document).on("change", "#LA_21a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_21a]:checked").val(), $("#LA_21a_a"), "LA_21a_v", $("#lbl_LA_21a_a"), $("input[name=LA_21b]"), $("#lbl_LA_21b"), $("#lbl_LA_21b_s"), $("#lbl_LA_21b_r"), $("#lbl_LA_21b_i"));
        });







        $(document).on("change", "#LA_22a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_22a]:checked").val(), $("#LA_22a_a"), "LA_22a_v", $("#lbl_LA_22a_a"), $("input[name=LA_22b]"), $("#lbl_LA_22b"), $("#lbl_LA_22b_s"), $("#lbl_LA_22b_r"), $("#lbl_LA_22b_i"));
        });


        $(document).on("change", "#LA_22a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_22a]:checked").val(), $("#LA_22a_a"), "LA_22a_v", $("#lbl_LA_22a_a"), $("input[name=LA_22b]"), $("#lbl_LA_22b"), $("#lbl_LA_22b_s"), $("#lbl_LA_22b_r"), $("#lbl_LA_22b_i"));
        });


        $(document).on("change", "#LA_22a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_22a]:checked").val(), $("#LA_22a_a"), "LA_22a_v", $("#lbl_LA_22a_a"), $("input[name=LA_22b]"), $("#lbl_LA_22b"), $("#lbl_LA_22b_s"), $("#lbl_LA_22b_r"), $("#lbl_LA_22b_i"));
        });






        $(document).on("change", "#LA_23a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_23a]:checked").val(), $("#LA_23a_a"), "LA_23a_v", $("#lbl_LA_23a_a"), $("input[name=LA_23b]"), $("#lbl_LA_23b"), $("#lbl_LA_23b_s"), $("#lbl_LA_23b_r"), $("#lbl_LA_23b_i"));
        });


        $(document).on("change", "#LA_23a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_23a]:checked").val(), $("#LA_23a_a"), "LA_23a_v", $("#lbl_LA_23a_a"), $("input[name=LA_23b]"), $("#lbl_LA_23b"), $("#lbl_LA_23b_s"), $("#lbl_LA_23b_r"), $("#lbl_LA_23b_i"));
        });


        $(document).on("change", "#LA_23a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_23a]:checked").val(), $("#LA_23a_a"), "LA_23a_v", $("#lbl_LA_23a_a"), $("input[name=LA_23b]"), $("#lbl_LA_23b"), $("#lbl_LA_23b_s"), $("#lbl_LA_23b_r"), $("#lbl_LA_23b_i"));
        });




        $(document).on("change", "#LA_24a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_24a]:checked").val(), $("#LA_24a_a"), "LA_24a_v", $("#lbl_LA_24a_a"), $("input[name=LA_24b]"), $("#lbl_LA_24b"), $("#lbl_LA_24b_s"), $("#lbl_LA_24b_r"), $("#lbl_LA_24b_i"));
        });


        $(document).on("change", "#LA_24a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_24a]:checked").val(), $("#LA_24a_a"), "LA_24a_v", $("#lbl_LA_24a_a"), $("input[name=LA_24b]"), $("#lbl_LA_24b"), $("#lbl_LA_24b_s"), $("#lbl_LA_24b_r"), $("#lbl_LA_24b_i"));
        });


        $(document).on("change", "#LA_24a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_24a]:checked").val(), $("#LA_24a_a"), "LA_24a_v", $("#lbl_LA_24a_a"), $("input[name=LA_24b]"), $("#lbl_LA_24b"), $("#lbl_LA_24b_s"), $("#lbl_LA_24b_r"), $("#lbl_LA_24b_i"));
        });



        $(document).on("change", "#LA_25a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_25a]:checked").val(), $("#LA_25a_a"), "LA_25a_v", $("#lbl_LA_25a_a"), $("input[name=LA_25b]"), $("#lbl_LA_25b"), $("#lbl_LA_25b_s"), $("#lbl_LA_25b_r"), $("#lbl_LA_25b_i"));
        });


        $(document).on("change", "#LA_25a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_25a]:checked").val(), $("#LA_25a_a"), "LA_25a_v", $("#lbl_LA_25a_a"), $("input[name=LA_25b]"), $("#lbl_LA_25b"), $("#lbl_LA_25b_s"), $("#lbl_LA_25b_r"), $("#lbl_LA_25b_i"));
        });


        $(document).on("change", "#LA_25a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_25a]:checked").val(), $("#LA_25a_a"), "LA_25a_v", $("#lbl_LA_25a_a"), $("input[name=LA_25b]"), $("#lbl_LA_25b"), $("#lbl_LA_25b_s"), $("#lbl_LA_25b_r"), $("#lbl_LA_25b_i"));
        });



        $(document).on("change", "#LA_26a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_26a]:checked").val(), $("#LA_26a_a"), "LA_26a_v", $("#lbl_LA_26a_a"), $("input[name=LA_26b]"), $("#lbl_LA_26b"), $("#lbl_LA_26b_s"), $("#lbl_LA_26b_r"), $("#lbl_LA_26b_i"));
        });


        $(document).on("change", "#LA_26a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_26a]:checked").val(), $("#LA_26a_a"), "LA_26a_v", $("#lbl_LA_26a_a"), $("input[name=LA_26b]"), $("#lbl_LA_26b"), $("#lbl_LA_26b_s"), $("#lbl_LA_26b_r"), $("#lbl_LA_26b_i"));
        });


        $(document).on("change", "#LA_26a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_26a]:checked").val(), $("#LA_26a_a"), "LA_26a_v", $("#lbl_LA_26a_a"), $("input[name=LA_26b]"), $("#lbl_LA_26b"), $("#lbl_LA_26b_s"), $("#lbl_LA_26b_r"), $("#lbl_LA_26b_i"));
        });



        $(document).on("change", "#LA_27a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_27a]:checked").val(), $("#LA_27a_a"), "LA_27a_v", $("#lbl_LA_27a_a"), $("input[name=LA_27b]"), $("#lbl_LA_27b"), $("#lbl_LA_27b_s"), $("#lbl_LA_27b_r"), $("#lbl_LA_27b_i"));
        });


        $(document).on("change", "#LA_27a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_27a]:checked").val(), $("#LA_27a_a"), "LA_27a_v", $("#lbl_LA_27a_a"), $("input[name=LA_27b]"), $("#lbl_LA_27b"), $("#lbl_LA_27b_s"), $("#lbl_LA_27b_r"), $("#lbl_LA_27b_i"));
        });


        $(document).on("change", "#LA_27a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_27a]:checked").val(), $("#LA_27a_a"), "LA_27a_v", $("#lbl_LA_27a_a"), $("input[name=LA_27b]"), $("#lbl_LA_27b"), $("#lbl_LA_27b_s"), $("#lbl_LA_27b_r"), $("#lbl_LA_27b_i"));
        });



        $(document).on("change", "#LA_28a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_28a]:checked").val(), $("#LA_28a_a"), "LA_28a_v", $("#lbl_LA_28a_a"), $("input[name=LA_28b]"), $("#lbl_LA_28b"), $("#lbl_LA_28b_s"), $("#lbl_LA_28b_r"), $("#lbl_LA_28b_i"));
        });


        $(document).on("change", "#LA_28a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_28a]:checked").val(), $("#LA_28a_a"), "LA_28a_v", $("#lbl_LA_28a_a"), $("input[name=LA_28b]"), $("#lbl_LA_28b"), $("#lbl_LA_28b_s"), $("#lbl_LA_28b_r"), $("#lbl_LA_28b_i"));
        });


        $(document).on("change", "#LA_28a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_28a]:checked").val(), $("#LA_28a_a"), "LA_28a_v", $("#lbl_LA_28a_a"), $("input[name=LA_28b]"), $("#lbl_LA_28b"), $("#lbl_LA_28b_s"), $("#lbl_LA_28b_r"), $("#lbl_LA_28b_i"));
        });



        $(document).on("change", "#LA_29a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_29a]:checked").val(), $("#LA_29a_a"), "LA_29a_v", $("#lbl_LA_29a_a"), $("input[name=LA_29b]"), $("#lbl_LA_29b"), $("#lbl_LA_29b_s"), $("#lbl_LA_29b_r"), $("#lbl_LA_29b_i"));
        });


        $(document).on("change", "#LA_29a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_29a]:checked").val(), $("#LA_29a_a"), "LA_29a_v", $("#lbl_LA_29a_a"), $("input[name=LA_29b]"), $("#lbl_LA_29b"), $("#lbl_LA_29b_s"), $("#lbl_LA_29b_r"), $("#lbl_LA_29b_i"));
        });


        $(document).on("change", "#LA_29a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_29a]:checked").val(), $("#LA_29a_a"), "LA_29a_v", $("#lbl_LA_29a_a"), $("input[name=LA_29b]"), $("#lbl_LA_29b"), $("#lbl_LA_29b_s"), $("#lbl_LA_29b_r"), $("#lbl_LA_29b_i"));
        });


        $(document).on("change", "#LA_30a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_30a]:checked").val(), $("#LA_30a_a"), "LA_30a_v", $("#lbl_LA_30a_a"), $("input[name=LA_30b]"), $("#lbl_LA_30b"), $("#lbl_LA_30b_s"), $("#lbl_LA_30b_r"), $("#lbl_LA_30b_i"));
        });


        $(document).on("change", "#LA_30a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_30a]:checked").val(), $("#LA_30a_a"), "LA_30a_v", $("#lbl_LA_30a_a"), $("input[name=LA_30b]"), $("#lbl_LA_30b"), $("#lbl_LA_30b_s"), $("#lbl_LA_30b_r"), $("#lbl_LA_30b_i"));
        });


        $(document).on("change", "#LA_30a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_30a]:checked").val(), $("#LA_30a_a"), "LA_30a_v", $("#lbl_LA_30a_a"), $("input[name=LA_30b]"), $("#lbl_LA_30b"), $("#lbl_LA_30b_s"), $("#lbl_LA_30b_r"), $("#lbl_LA_30b_i"));
        });



        $(document).on("change", "#LA_31a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_31a]:checked").val(), $("#LA_31a_a"), "LA_31a_v", $("#lbl_LA_31a_a"), $("input[name=LA_31b]"), $("#lbl_LA_31b"), $("#lbl_LA_31b_s"), $("#lbl_LA_31b_r"), $("#lbl_LA_31b_i"));
        });


        $(document).on("change", "#LA_31a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_31a]:checked").val(), $("#LA_31a_a"), "LA_31a_v", $("#lbl_LA_31a_a"), $("input[name=LA_31b]"), $("#lbl_LA_31b"), $("#lbl_LA_31b_s"), $("#lbl_LA_31b_r"), $("#lbl_LA_31b_i"));
        });


        $(document).on("change", "#LA_31a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_31a]:checked").val(), $("#LA_31a_a"), "LA_31a_v", $("#lbl_LA_31a_a"), $("input[name=LA_31b]"), $("#lbl_LA_31b"), $("#lbl_LA_31b_s"), $("#lbl_LA_31b_r"), $("#lbl_LA_31b_i"));
        });



        $(document).on("change", "#LA_32a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_32a]:checked").val(), $("#LA_32a_a"), "LA_32a_v", $("#lbl_LA_32a_a"), $("input[name=LA_32b]"), $("#lbl_LA_32b"), $("#lbl_LA_32b_s"), $("#lbl_LA_32b_r"), $("#lbl_LA_32b_i"));
        });


        $(document).on("change", "#LA_32a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_32a]:checked").val(), $("#LA_32a_a"), "LA_32a_v", $("#lbl_LA_32a_a"), $("input[name=LA_32b]"), $("#lbl_LA_32b"), $("#lbl_LA_32b_s"), $("#lbl_LA_32b_r"), $("#lbl_LA_32b_i"));
        });


        $(document).on("change", "#LA_32a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_32a]:checked").val(), $("#LA_32a_a"), "LA_32a_v", $("#lbl_LA_32a_a"), $("input[name=LA_32b]"), $("#lbl_LA_32b"), $("#lbl_LA_32b_s"), $("#lbl_LA_32b_r"), $("#lbl_LA_32b_i"));
        });



        $(document).on("change", "#LA_33a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_33a]:checked").val(), $("#LA_33a_a"), "LA_33a_v", $("#lbl_LA_33a_a"), $("input[name=LA_33b]"), $("#lbl_LA_33b"), $("#lbl_LA_33b_s"), $("#lbl_LA_33b_r"), $("#lbl_LA_33b_i"));
        });


        $(document).on("change", "#LA_33a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_33a]:checked").val(), $("#LA_33a_a"), "LA_33a_v", $("#lbl_LA_33a_a"), $("input[name=LA_33b]"), $("#lbl_LA_33b"), $("#lbl_LA_33b_s"), $("#lbl_LA_33b_r"), $("#lbl_LA_33b_i"));
        });


        $(document).on("change", "#LA_33a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_33a]:checked").val(), $("#LA_33a_a"), "LA_33a_v", $("#lbl_LA_33a_a"), $("input[name=LA_33b]"), $("#lbl_LA_33b"), $("#lbl_LA_33b_s"), $("#lbl_LA_33b_r"), $("#lbl_LA_33b_i"));
        });



        $(document).on("change", "#LA_34a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_34a]:checked").val(), $("#LA_34a_a"), "LA_34a_v", $("#lbl_LA_34a_a"), $("input[name=LA_34b]"), $("#lbl_LA_34b"), $("#lbl_LA_34b_s"), $("#lbl_LA_34b_r"), $("#lbl_LA_34b_i"));
        });


        $(document).on("change", "#LA_34a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_34a]:checked").val(), $("#LA_34a_a"), "LA_34a_v", $("#lbl_LA_34a_a"), $("input[name=LA_34b]"), $("#lbl_LA_34b"), $("#lbl_LA_34b_s"), $("#lbl_LA_34b_r"), $("#lbl_LA_34b_i"));
        });


        $(document).on("change", "#LA_34a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_34a]:checked").val(), $("#LA_34a_a"), "LA_34a_v", $("#lbl_LA_34a_a"), $("input[name=LA_34b]"), $("#lbl_LA_34b"), $("#lbl_LA_34b_s"), $("#lbl_LA_34b_r"), $("#lbl_LA_34b_i"));
        });



        $(document).on("change", "#LA_35a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_35a]:checked").val(), $("#LA_35a_a"), "LA_35a_v", $("#lbl_LA_35a_a"), $("input[name=LA_35b]"), $("#lbl_LA_35b"), $("#lbl_LA_35b_s"), $("#lbl_LA_35b_r"), $("#lbl_LA_35b_i"));
        });


        $(document).on("change", "#LA_35a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_35a]:checked").val(), $("#LA_35a_a"), "LA_35a_v", $("#lbl_LA_35a_a"), $("input[name=LA_35b]"), $("#lbl_LA_35b"), $("#lbl_LA_35b_s"), $("#lbl_LA_35b_r"), $("#lbl_LA_35b_i"));
        });


        $(document).on("change", "#LA_35a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_35a]:checked").val(), $("#LA_35a_a"), "LA_35a_v", $("#lbl_LA_35a_a"), $("input[name=LA_35b]"), $("#lbl_LA_35b"), $("#lbl_LA_35b_s"), $("#lbl_LA_35b_r"), $("#lbl_LA_35b_i"));
        });



        $(document).on("change", "#LA_36a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_36a]:checked").val(), $("#LA_36a_a"), "LA_36a_v", $("#lbl_LA_36a_a"), $("input[name=LA_36b]"), $("#lbl_LA_36b"), $("#lbl_LA_36b_s"), $("#lbl_LA_36b_r"), $("#lbl_LA_36b_i"));
        });


        $(document).on("change", "#LA_36a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_36a]:checked").val(), $("#LA_36a_a"), "LA_36a_v", $("#lbl_LA_36a_a"), $("input[name=LA_36b]"), $("#lbl_LA_36b"), $("#lbl_LA_36b_s"), $("#lbl_LA_36b_r"), $("#lbl_LA_36b_i"));
        });


        $(document).on("change", "#LA_36a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_36a]:checked").val(), $("#LA_36a_a"), "LA_36a_v", $("#lbl_LA_36a_a"), $("input[name=LA_36b]"), $("#lbl_LA_36b"), $("#lbl_LA_36b_s"), $("#lbl_LA_36b_r"), $("#lbl_LA_36b_i"));
        });



        $(document).on("change", "#LA_37a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_37a]:checked").val(), $("#LA_37a_a"), "LA_37a_v", $("#lbl_LA_37a_a"), $("input[name=LA_37b]"), $("#lbl_LA_37b"), $("#lbl_LA_37b_s"), $("#lbl_LA_37b_r"), $("#lbl_LA_37b_i"));
        });


        $(document).on("change", "#LA_37a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_37a]:checked").val(), $("#LA_37a_a"), "LA_37a_v", $("#lbl_LA_37a_a"), $("input[name=LA_37b]"), $("#lbl_LA_37b"), $("#lbl_LA_37b_s"), $("#lbl_LA_37b_r"), $("#lbl_LA_37b_i"));
        });


        $(document).on("change", "#LA_37a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_37a]:checked").val(), $("#LA_37a_a"), "LA_37a_v", $("#lbl_LA_37a_a"), $("input[name=LA_37b]"), $("#lbl_LA_37b"), $("#lbl_LA_37b_s"), $("#lbl_LA_37b_r"), $("#lbl_LA_37b_i"));
        });



        $(document).on("change", "#LA_38a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_38a]:checked").val(), $("#LA_38a_a"), "LA_38a_v", $("#lbl_LA_38a_a"), $("input[name=LA_38b]"), $("#lbl_LA_38b"), $("#lbl_LA_38b_s"), $("#lbl_LA_38b_r"), $("#lbl_LA_38b_i"));
        });


        $(document).on("change", "#LA_38a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_38a]:checked").val(), $("#LA_38a_a"), "LA_38a_v", $("#lbl_LA_38a_a"), $("input[name=LA_38b]"), $("#lbl_LA_38b"), $("#lbl_LA_38b_s"), $("#lbl_LA_38b_r"), $("#lbl_LA_38b_i"));
        });


        $(document).on("change", "#LA_38a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_38a]:checked").val(), $("#LA_38a_a"), "LA_38a_v", $("#lbl_LA_38a_a"), $("input[name=LA_38b]"), $("#lbl_LA_38b"), $("#lbl_LA_38b_s"), $("#lbl_LA_38b_r"), $("#lbl_LA_38b_i"));
        });




        $(document).on("change", "#LA_39a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_39a]:checked").val(), $("#LA_39a_a"), "LA_39a_v", $("#lbl_LA_39a_a"), $("input[name=LA_39b]"), $("#lbl_LA_39b"), $("#lbl_LA_39b_s"), $("#lbl_LA_39b_r"), $("#lbl_LA_39b_i"));
        });


        $(document).on("change", "#LA_39a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_39a]:checked").val(), $("#LA_39a_a"), "LA_39a_v", $("#lbl_LA_39a_a"), $("input[name=LA_39b]"), $("#lbl_LA_39b"), $("#lbl_LA_39b_s"), $("#lbl_LA_39b_r"), $("#lbl_LA_39b_i"));
        });


        $(document).on("change", "#LA_39a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_39a]:checked").val(), $("#LA_39a_a"), "LA_39a_v", $("#lbl_LA_39a_a"), $("input[name=LA_39b]"), $("#lbl_LA_39b"), $("#lbl_LA_39b_s"), $("#lbl_LA_39b_r"), $("#lbl_LA_39b_i"));
        });



        $(document).on("change", "#LA_40a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_40a]:checked").val(), $("#LA_40a_a"), "LA_40a_v", $("#lbl_LA_40a_a"), $("input[name=LA_40b]"), $("#lbl_LA_40b"), $("#lbl_LA_40b_s"), $("#lbl_LA_40b_r"), $("#lbl_LA_40b_i"));
        });


        $(document).on("change", "#LA_40a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_40a]:checked").val(), $("#LA_40a_a"), "LA_40a_v", $("#lbl_LA_40a_a"), $("input[name=LA_40b]"), $("#lbl_LA_40b"), $("#lbl_LA_40b_s"), $("#lbl_LA_40b_r"), $("#lbl_LA_40b_i"));
        });


        $(document).on("change", "#LA_40a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_40a]:checked").val(), $("#LA_40a_a"), "LA_40a_v", $("#lbl_LA_40a_a"), $("input[name=LA_40b]"), $("#lbl_LA_40b"), $("#lbl_LA_40b_s"), $("#lbl_LA_40b_r"), $("#lbl_LA_40b_i"));
        });




        $(document).on("change", "#LA_41a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_41a]:checked").val(), $("#LA_41a_a"), "LA_41a_v", $("#lbl_LA_41a_a"), $("input[name=LA_41b]"), $("#lbl_LA_41b"), $("#lbl_LA_41b_s"), $("#lbl_LA_41b_r"), $("#lbl_LA_41b_i"));
        });


        $(document).on("change", "#LA_41a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_41a]:checked").val(), $("#LA_41a_a"), "LA_41a_v", $("#lbl_LA_41a_a"), $("input[name=LA_41b]"), $("#lbl_LA_41b"), $("#lbl_LA_41b_s"), $("#lbl_LA_41b_r"), $("#lbl_LA_41b_i"));
        });


        $(document).on("change", "#LA_41a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_41a]:checked").val(), $("#LA_41a_a"), "LA_41a_v", $("#lbl_LA_41a_a"), $("input[name=LA_41b]"), $("#lbl_LA_41b"), $("#lbl_LA_41b_s"), $("#lbl_LA_41b_r"), $("#lbl_LA_41b_i"));
        });




        $(document).on("change", "#LA_42a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_42a]:checked").val(), $("#LA_42a_a"), "LA_42a_v", $("#lbl_LA_42a_a"), $("input[name=LA_42b]"), $("#lbl_LA_42b"), $("#lbl_LA_42b_s"), $("#lbl_LA_42b_r"), $("#lbl_LA_42b_i"));
        });


        $(document).on("change", "#LA_42a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_42a]:checked").val(), $("#LA_42a_a"), "LA_42a_v", $("#lbl_LA_42a_a"), $("input[name=LA_42b]"), $("#lbl_LA_42b"), $("#lbl_LA_42b_s"), $("#lbl_LA_42b_r"), $("#lbl_LA_42b_i"));
        });


        $(document).on("change", "#LA_42a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_42a]:checked").val(), $("#LA_42a_a"), "LA_42a_v", $("#lbl_LA_42a_a"), $("input[name=LA_42b]"), $("#lbl_LA_42b"), $("#lbl_LA_42b_s"), $("#lbl_LA_42b_r"), $("#lbl_LA_42b_i"));
        });



        $(document).on("change", "#LA_43a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_43a]:checked").val(), $("#LA_43a_a"), "LA_43a_v", $("#lbl_LA_43a_a"), $("input[name=LA_43b]"), $("#lbl_LA_43b"), $("#lbl_LA_43b_s"), $("#lbl_LA_43b_r"), $("#lbl_LA_43b_i"));
        });


        $(document).on("change", "#LA_43a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_43a]:checked").val(), $("#LA_43a_a"), "LA_43a_v", $("#lbl_LA_43a_a"), $("input[name=LA_43b]"), $("#lbl_LA_43b"), $("#lbl_LA_43b_s"), $("#lbl_LA_43b_r"), $("#lbl_LA_43b_i"));
        });


        $(document).on("change", "#LA_43a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_43a]:checked").val(), $("#LA_43a_a"), "LA_43a_v", $("#lbl_LA_43a_a"), $("input[name=LA_43b]"), $("#lbl_LA_43b"), $("#lbl_LA_43b_s"), $("#lbl_LA_43b_r"), $("#lbl_LA_43b_i"));
        });




        $(document).on("change", "#LA_44a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_44a]:checked").val(), $("#LA_44a_a"), "LA_44a_v", $("#lbl_LA_44a_a"), $("input[name=LA_44b]"), $("#lbl_LA_44b"), $("#lbl_LA_44b_s"), $("#lbl_LA_44b_r"), $("#lbl_LA_44b_i"));
        });


        $(document).on("change", "#LA_44a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_44a]:checked").val(), $("#LA_44a_a"), "LA_44a_v", $("#lbl_LA_44a_a"), $("input[name=LA_44b]"), $("#lbl_LA_44b"), $("#lbl_LA_44b_s"), $("#lbl_LA_44b_r"), $("#lbl_LA_44b_i"));
        });


        $(document).on("change", "#LA_44a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_44a]:checked").val(), $("#LA_44a_a"), "LA_44a_v", $("#lbl_LA_44a_a"), $("input[name=LA_44b]"), $("#lbl_LA_44b"), $("#lbl_LA_44b_s"), $("#lbl_LA_44b_r"), $("#lbl_LA_44b_i"));
        });



        $(document).on("change", "#LA_45a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_45a]:checked").val(), $("#LA_45a_a"), "LA_45a_v", $("#lbl_LA_45a_a"), $("input[name=LA_45b]"), $("#lbl_LA_45b"), $("#lbl_LA_45b_s"), $("#lbl_LA_45b_r"), $("#lbl_LA_45b_i"));
        });


        $(document).on("change", "#LA_45a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_45a]:checked").val(), $("#LA_45a_a"), "LA_45a_v", $("#lbl_LA_45a_a"), $("input[name=LA_45b]"), $("#lbl_LA_45b"), $("#lbl_LA_45b_s"), $("#lbl_LA_45b_r"), $("#lbl_LA_45b_i"));
        });


        $(document).on("change", "#LA_45a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_45a]:checked").val(), $("#LA_45a_a"), "LA_45a_v", $("#lbl_LA_45a_a"), $("input[name=LA_45b]"), $("#lbl_LA_45b"), $("#lbl_LA_45b_s"), $("#lbl_LA_45b_r"), $("#lbl_LA_45b_i"));
        });




        $(document).on("change", "#LA_46a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_46a]:checked").val(), $("#LA_46a_a"), "LA_46a_v", $("#lbl_LA_46a_a"), $("input[name=LA_46b]"), $("#lbl_LA_46b"), $("#lbl_LA_46b_s"), $("#lbl_LA_46b_r"), $("#lbl_LA_46b_i"));
        });


        $(document).on("change", "#LA_46a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_46a]:checked").val(), $("#LA_46a_a"), "LA_46a_v", $("#lbl_LA_46a_a"), $("input[name=LA_46b]"), $("#lbl_LA_46b"), $("#lbl_LA_46b_s"), $("#lbl_LA_46b_r"), $("#lbl_LA_46b_i"));
        });


        $(document).on("change", "#LA_46a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_46a]:checked").val(), $("#LA_46a_a"), "LA_46a_v", $("#lbl_LA_46a_a"), $("input[name=LA_46b]"), $("#lbl_LA_46b"), $("#lbl_LA_46b_s"), $("#lbl_LA_46b_r"), $("#lbl_LA_46b_i"));
        });



        $(document).on("change", "#LA_47a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_47a]:checked").val(), $("#LA_47a_a"), "LA_47a_v", $("#lbl_LA_47a_a"), $("input[name=LA_47b]"), $("#lbl_LA_47b"), $("#lbl_LA_47b_s"), $("#lbl_LA_47b_r"), $("#lbl_LA_47b_i"));
        });


        $(document).on("change", "#LA_47a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_47a]:checked").val(), $("#LA_47a_a"), "LA_47a_v", $("#lbl_LA_47a_a"), $("input[name=LA_47b]"), $("#lbl_LA_47b"), $("#lbl_LA_47b_s"), $("#lbl_LA_47b_r"), $("#lbl_LA_47b_i"));
        });


        $(document).on("change", "#LA_47a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_47a]:checked").val(), $("#LA_47a_a"), "LA_47a_v", $("#lbl_LA_47a_a"), $("input[name=LA_47b]"), $("#lbl_LA_47b"), $("#lbl_LA_47b_s"), $("#lbl_LA_47b_r"), $("#lbl_LA_47b_i"));
        });



        $(document).on("change", "#LA_48a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_48a]:checked").val(), $("#LA_48a_a"), "LA_48a_v", $("#lbl_LA_48a_a"), $("input[name=LA_48b]"), $("#lbl_LA_48b"), $("#lbl_LA_48b_s"), $("#lbl_LA_48b_r"), $("#lbl_LA_48b_i"));
        });


        $(document).on("change", "#LA_48a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_48a]:checked").val(), $("#LA_48a_a"), "LA_48a_v", $("#lbl_LA_48a_a"), $("input[name=LA_48b]"), $("#lbl_LA_48b"), $("#lbl_LA_48b_s"), $("#lbl_LA_48b_r"), $("#lbl_LA_48b_i"));
        });


        $(document).on("change", "#LA_48a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_48a]:checked").val(), $("#LA_48a_a"), "LA_48a_v", $("#lbl_LA_48a_a"), $("input[name=LA_48b]"), $("#lbl_LA_48b"), $("#lbl_LA_48b_s"), $("#lbl_LA_48b_r"), $("#lbl_LA_48b_i"));
        });




        $(document).on("change", "#LA_49a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_49a]:checked").val(), $("#LA_49a_a"), "LA_49a_v", $("#lbl_LA_49a_a"), $("input[name=LA_49b]"), $("#lbl_LA_49b"), $("#lbl_LA_49b_s"), $("#lbl_LA_49b_r"), $("#lbl_LA_49b_i"));
        });


        $(document).on("change", "#LA_49a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_49a]:checked").val(), $("#LA_49a_a"), "LA_49a_v", $("#lbl_LA_49a_a"), $("input[name=LA_49b]"), $("#lbl_LA_49b"), $("#lbl_LA_49b_s"), $("#lbl_LA_49b_r"), $("#lbl_LA_49b_i"));
        });


        $(document).on("change", "#LA_49a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_49a]:checked").val(), $("#LA_49a_a"), "LA_49a_v", $("#lbl_LA_49a_a"), $("input[name=LA_49b]"), $("#lbl_LA_49b"), $("#lbl_LA_49b_s"), $("#lbl_LA_49b_r"), $("#lbl_LA_49b_i"));
        });



        $(document).on("change", "#LA_50a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_50a]:checked").val(), $("#LA_50a_a"), "LA_50a_v", $("#lbl_LA_50a_a"), $("input[name=LA_50b]"), $("#lbl_LA_50b"), $("#lbl_LA_50b_s"), $("#lbl_LA_50b_r"), $("#lbl_LA_50b_i"));
        });


        $(document).on("change", "#LA_50a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_50a]:checked").val(), $("#LA_50a_a"), "LA_50a_v", $("#lbl_LA_50a_a"), $("input[name=LA_50b]"), $("#lbl_LA_50b"), $("#lbl_LA_50b_s"), $("#lbl_LA_50b_r"), $("#lbl_LA_50b_i"));
        });


        $(document).on("change", "#LA_50a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_50a]:checked").val(), $("#LA_50a_a"), "LA_50a_v", $("#lbl_LA_50a_a"), $("input[name=LA_50b]"), $("#lbl_LA_50b"), $("#lbl_LA_50b_s"), $("#lbl_LA_50b_r"), $("#lbl_LA_50b_i"));
        });




        $(document).on("change", "#LA_51a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_51a]:checked").val(), $("#LA_51a_a"), "LA_51a_v", $("#lbl_LA_51a_a"), $("input[name=LA_51b]"), $("#lbl_LA_51b"), $("#lbl_LA_51b_s"), $("#lbl_LA_51b_r"), $("#lbl_LA_51b_i"));
        });


        $(document).on("change", "#LA_51a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_51a]:checked").val(), $("#LA_51a_a"), "LA_51a_v", $("#lbl_LA_51a_a"), $("input[name=LA_51b]"), $("#lbl_LA_51b"), $("#lbl_LA_51b_s"), $("#lbl_LA_51b_r"), $("#lbl_LA_51b_i"));
        });


        $(document).on("change", "#LA_51a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_51a]:checked").val(), $("#LA_51a_a"), "LA_51a_v", $("#lbl_LA_51a_a"), $("input[name=LA_51b]"), $("#lbl_LA_51b"), $("#lbl_LA_51b_s"), $("#lbl_LA_51b_r"), $("#lbl_LA_51b_i"));
        });



        $(document).on("change", "#LA_52a_v", function () {
            ShowHide_TextBox_New($("input[name=LA_52a]:checked").val(), $("#LA_52a_a"), "LA_52a_v", $("#lbl_LA_52a_a"), $("input[name=LA_52b]"), $("#lbl_LA_52b"), $("#lbl_LA_52b_s"), $("#lbl_LA_52b_r"), $("#lbl_LA_52b_i"));
        });


        $(document).on("change", "#LA_52a_b", function () {
            ShowHide_TextBox_New($("input[name=LA_52a]:checked").val(), $("#LA_52a_a"), "LA_52a_v", $("#lbl_LA_52a_a"), $("input[name=LA_52b]"), $("#lbl_LA_52b"), $("#lbl_LA_52b_s"), $("#lbl_LA_52b_r"), $("#lbl_LA_52b_i"));
        });


        $(document).on("change", "#LA_52a_c", function () {
            ShowHide_TextBox_New($("input[name=LA_52a]:checked").val(), $("#LA_52a_a"), "LA_52a_v", $("#lbl_LA_52a_a"), $("input[name=LA_52b]"), $("#lbl_LA_52b"), $("#lbl_LA_52b_s"), $("#lbl_LA_52b_r"), $("#lbl_LA_52b_i"));
        });





        $(document).on("change", "#uc_02a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_02a]:checked").val(), $("#uc_02a_a"), "uc_02a_v", $("#lbl_uc_02a_a"), $("input[name=uc_02b]"), $("#lbl_uc_02b"), $("#lbl_uc_02b_s"), $("#lbl_uc_02b_r"), $("#lbl_uc_02b_i"));
        });


        $(document).on("change", "#uc_02a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_02a]:checked").val(), $("#uc_02a_a"), "uc_02a_v", $("#lbl_uc_02a_a"), $("input[name=uc_02b]"), $("#lbl_uc_02b"), $("#lbl_uc_02b_s"), $("#lbl_uc_02b_r"), $("#lbl_uc_02b_i"));
        });


        $(document).on("change", "#uc_02a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_02a]:checked").val(), $("#uc_02a_a"), "uc_02a_v", $("#lbl_uc_02a_a"), $("input[name=uc_02b]"), $("#lbl_uc_02b"), $("#lbl_uc_02b_s"), $("#lbl_uc_02b_r"), $("#lbl_uc_02b_i"));
        });




        $(document).on("change", "#uc_03a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_03a]:checked").val(), $("#uc_03a_a"), "uc_03a_v", $("#lbl_uc_03a_a"), $("input[name=uc_03b]"), $("#lbl_uc_03b"), $("#lbl_uc_03b_s"), $("#lbl_uc_03b_r"), $("#lbl_uc_03b_i"));
        });


        $(document).on("change", "#uc_03a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_03a]:checked").val(), $("#uc_03a_a"), "uc_03a_v", $("#lbl_uc_03a_a"), $("input[name=uc_03b]"), $("#lbl_uc_03b"), $("#lbl_uc_03b_s"), $("#lbl_uc_03b_r"), $("#lbl_uc_03b_i"));
        });


        $(document).on("change", "#uc_03a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_03a]:checked").val(), $("#uc_03a_a"), "uc_03a_v", $("#lbl_uc_03a_a"), $("input[name=uc_03b]"), $("#lbl_uc_03b"), $("#lbl_uc_03b_s"), $("#lbl_uc_03b_r"), $("#lbl_uc_03b_i"));
        });




        $(document).on("change", "#uc_04a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_04a]:checked").val(), $("#uc_04a_a"), "uc_04a_v", $("#lbl_uc_04a_a"), $("input[name=uc_04b]"), $("#lbl_uc_04b"), $("#lbl_uc_04b_s"), $("#lbl_uc_04b_r"), $("#lbl_uc_04b_i"));
        });


        $(document).on("change", "#uc_04a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_04a]:checked").val(), $("#uc_04a_a"), "uc_04a_v", $("#lbl_uc_04a_a"), $("input[name=uc_04b]"), $("#lbl_uc_04b"), $("#lbl_uc_04b_s"), $("#lbl_uc_04b_r"), $("#lbl_uc_04b_i"));
        });


        $(document).on("change", "#uc_04a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_04a]:checked").val(), $("#uc_04a_a"), "uc_04a_v", $("#lbl_uc_04a_a"), $("input[name=uc_04b]"), $("#lbl_uc_04b"), $("#lbl_uc_04b_s"), $("#lbl_uc_04b_r"), $("#lbl_uc_04b_i"));
        });




        $(document).on("change", "#uc_05a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_05a]:checked").val(), $("#uc_05a_a"), "uc_05a_v", $("#lbl_uc_05a_a"), $("input[name=uc_05b]"), $("#lbl_uc_05b"), $("#lbl_uc_05b_s"), $("#lbl_uc_05b_r"), $("#lbl_uc_05b_i"));
        });


        $(document).on("change", "#uc_05a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_05a]:checked").val(), $("#uc_05a_a"), "uc_05a_v", $("#lbl_uc_05a_a"), $("input[name=uc_05b]"), $("#lbl_uc_05b"), $("#lbl_uc_05b_s"), $("#lbl_uc_05b_r"), $("#lbl_uc_05b_i"));
        });


        $(document).on("change", "#uc_05a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_05a]:checked").val(), $("#uc_05a_a"), "uc_05a_v", $("#lbl_uc_05a_a"), $("input[name=uc_05b]"), $("#lbl_uc_05b"), $("#lbl_uc_05b_s"), $("#lbl_uc_05b_r"), $("#lbl_uc_05b_i"));
        });



        $(document).on("change", "#uc_06a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_06a]:checked").val(), $("#uc_06a_a"), "uc_06a_v", $("#lbl_uc_06a_a"), $("input[name=uc_06b]"), $("#lbl_uc_06b"), $("#lbl_uc_06b_s"), $("#lbl_uc_06b_r"), $("#lbl_uc_06b_i"));
        });


        $(document).on("change", "#uc_06a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_06a]:checked").val(), $("#uc_06a_a"), "uc_06a_v", $("#lbl_uc_06a_a"), $("input[name=uc_06b]"), $("#lbl_uc_06b"), $("#lbl_uc_06b_s"), $("#lbl_uc_06b_r"), $("#lbl_uc_06b_i"));
        });


        $(document).on("change", "#uc_06a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_06a]:checked").val(), $("#uc_06a_a"), "uc_06a_v", $("#lbl_uc_06a_a"), $("input[name=uc_06b]"), $("#lbl_uc_06b"), $("#lbl_uc_06b_s"), $("#lbl_uc_06b_r"), $("#lbl_uc_06b_i"));
        });




        $(document).on("change", "#uc_07a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_07a]:checked").val(), $("#uc_07a_a"), "uc_07a_v", $("#lbl_uc_07a_a"), $("input[name=uc_07b]"), $("#lbl_uc_07b"), $("#lbl_uc_07b_s"), $("#lbl_uc_07b_r"), $("#lbl_uc_07b_i"));
        });


        $(document).on("change", "#uc_07a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_07a]:checked").val(), $("#uc_07a_a"), "uc_07a_v", $("#lbl_uc_07a_a"), $("input[name=uc_07b]"), $("#lbl_uc_07b"), $("#lbl_uc_07b_s"), $("#lbl_uc_07b_r"), $("#lbl_uc_07b_i"));
        });


        $(document).on("change", "#uc_07a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_07a]:checked").val(), $("#uc_07a_a"), "uc_07a_v", $("#lbl_uc_07a_a"), $("input[name=uc_07b]"), $("#lbl_uc_07b"), $("#lbl_uc_07b_s"), $("#lbl_uc_07b_r"), $("#lbl_uc_07b_i"));
        });



        $(document).on("change", "#uc_08a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_08a]:checked").val(), $("#uc_08a_a"), "uc_08a_v", $("#lbl_uc_08a_a"), $("input[name=uc_08b]"), $("#lbl_uc_08b"), $("#lbl_uc_08b_s"), $("#lbl_uc_08b_r"), $("#lbl_uc_08b_i"));
        });


        $(document).on("change", "#uc_08a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_08a]:checked").val(), $("#uc_08a_a"), "uc_08a_v", $("#lbl_uc_08a_a"), $("input[name=uc_08b]"), $("#lbl_uc_08b"), $("#lbl_uc_08b_s"), $("#lbl_uc_08b_r"), $("#lbl_uc_08b_i"));
        });


        $(document).on("change", "#uc_08a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_08a]:checked").val(), $("#uc_08a_a"), "uc_08a_v", $("#lbl_uc_08a_a"), $("input[name=uc_08b]"), $("#lbl_uc_08b"), $("#lbl_uc_08b_s"), $("#lbl_uc_08b_r"), $("#lbl_uc_08b_i"));
        });




        $(document).on("change", "#uc_09a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_09a]:checked").val(), $("#uc_09a_a"), "uc_09a_v", $("#lbl_uc_09a_a"), $("input[name=uc_09b]"), $("#lbl_uc_09b"), $("#lbl_uc_09b_s"), $("#lbl_uc_09b_r"), $("#lbl_uc_09b_i"));
        });


        $(document).on("change", "#uc_09a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_09a]:checked").val(), $("#uc_09a_a"), "uc_09a_v", $("#lbl_uc_09a_a"), $("input[name=uc_09b]"), $("#lbl_uc_09b"), $("#lbl_uc_09b_s"), $("#lbl_uc_09b_r"), $("#lbl_uc_09b_i"));
        });


        $(document).on("change", "#uc_09a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_09a]:checked").val(), $("#uc_09a_a"), "uc_09a_v", $("#lbl_uc_09a_a"), $("input[name=uc_09b]"), $("#lbl_uc_09b"), $("#lbl_uc_09b_s"), $("#lbl_uc_09b_r"), $("#lbl_uc_09b_i"));
        });




        $(document).on("change", "#uc_10a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_10a]:checked").val(), $("#uc_10a_a"), "uc_10a_v", $("#lbl_uc_10a_a"), $("input[name=uc_10b]"), $("#lbl_uc_10b"), $("#lbl_uc_10b_s"), $("#lbl_uc_10b_r"), $("#lbl_uc_10b_i"));
        });


        $(document).on("change", "#uc_10a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_10a]:checked").val(), $("#uc_10a_a"), "uc_10a_v", $("#lbl_uc_10a_a"), $("input[name=uc_10b]"), $("#lbl_uc_10b"), $("#lbl_uc_10b_s"), $("#lbl_uc_10b_r"), $("#lbl_uc_10b_i"));
        });


        $(document).on("change", "#uc_10a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_10a]:checked").val(), $("#uc_10a_a"), "uc_10a_v", $("#lbl_uc_10a_a"), $("input[name=uc_10b]"), $("#lbl_uc_10b"), $("#lbl_uc_10b_s"), $("#lbl_uc_10b_r"), $("#lbl_uc_10b_i"));
        });




        $(document).on("change", "#uc_11a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_11a]:checked").val(), $("#uc_11a_a"), "uc_11a_v", $("#lbl_uc_11a_a"), $("input[name=uc_11b]"), $("#lbl_uc_11b"), $("#lbl_uc_11b_s"), $("#lbl_uc_11b_r"), $("#lbl_uc_11b_i"));
        });


        $(document).on("change", "#uc_11a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_11a]:checked").val(), $("#uc_11a_a"), "uc_11a_v", $("#lbl_uc_11a_a"), $("input[name=uc_11b]"), $("#lbl_uc_11b"), $("#lbl_uc_11b_s"), $("#lbl_uc_11b_r"), $("#lbl_uc_11b_i"));
        });


        $(document).on("change", "#uc_11a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_11a]:checked").val(), $("#uc_11a_a"), "uc_11a_v", $("#lbl_uc_11a_a"), $("input[name=uc_11b]"), $("#lbl_uc_11b"), $("#lbl_uc_11b_s"), $("#lbl_uc_11b_r"), $("#lbl_uc_11b_i"));
        });




        $(document).on("change", "#uc_12a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_12a]:checked").val(), $("#uc_12a_a"), "uc_12a_v", $("#lbl_uc_12a_a"), $("input[name=uc_12b]"), $("#lbl_uc_12b"), $("#lbl_uc_12b_s"), $("#lbl_uc_12b_r"), $("#lbl_uc_12b_i"));
        });


        $(document).on("change", "#uc_12a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_12a]:checked").val(), $("#uc_12a_a"), "uc_12a_v", $("#lbl_uc_12a_a"), $("input[name=uc_12b]"), $("#lbl_uc_12b"), $("#lbl_uc_12b_s"), $("#lbl_uc_12b_r"), $("#lbl_uc_12b_i"));
        });


        $(document).on("change", "#uc_12a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_12a]:checked").val(), $("#uc_12a_a"), "uc_12a_v", $("#lbl_uc_12a_a"), $("input[name=uc_12b]"), $("#lbl_uc_12b"), $("#lbl_uc_12b_s"), $("#lbl_uc_12b_r"), $("#lbl_uc_12b_i"));
        });



        $(document).on("change", "#uc_13a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_13a]:checked").val(), $("#uc_13a_a"), "uc_13a_v", $("#lbl_uc_13a_a"), $("input[name=uc_13b]"), $("#lbl_uc_13b"), $("#lbl_uc_13b_s"), $("#lbl_uc_13b_r"), $("#lbl_uc_13b_i"));
        });


        $(document).on("change", "#uc_13a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_13a]:checked").val(), $("#uc_13a_a"), "uc_13a_v", $("#lbl_uc_13a_a"), $("input[name=uc_13b]"), $("#lbl_uc_13b"), $("#lbl_uc_13b_s"), $("#lbl_uc_13b_r"), $("#lbl_uc_13b_i"));
        });


        $(document).on("change", "#uc_13a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_13a]:checked").val(), $("#uc_13a_a"), "uc_13a_v", $("#lbl_uc_13a_a"), $("input[name=uc_13b]"), $("#lbl_uc_13b"), $("#lbl_uc_13b_s"), $("#lbl_uc_13b_r"), $("#lbl_uc_13b_i"));
        });





        $(document).on("change", "#uc_14a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_14a]:checked").val(), $("#uc_14a_a"), "uc_14a_v", $("#lbl_uc_14a_a"), $("input[name=uc_14b]"), $("#lbl_uc_14b"), $("#lbl_uc_14b_s"), $("#lbl_uc_14b_r"), $("#lbl_uc_14b_i"));
        });


        $(document).on("change", "#uc_14a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_14a]:checked").val(), $("#uc_14a_a"), "uc_14a_v", $("#lbl_uc_14a_a"), $("input[name=uc_14b]"), $("#lbl_uc_14b"), $("#lbl_uc_14b_s"), $("#lbl_uc_14b_r"), $("#lbl_uc_14b_i"));
        });


        $(document).on("change", "#uc_14a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_14a]:checked").val(), $("#uc_14a_a"), "uc_14a_v", $("#lbl_uc_14a_a"), $("input[name=uc_14b]"), $("#lbl_uc_14b"), $("#lbl_uc_14b_s"), $("#lbl_uc_14b_r"), $("#lbl_uc_14b_i"));
        });



        $(document).on("change", "#uc_15a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_15a]:checked").val(), $("#uc_15a_a"), "uc_15a_v", $("#lbl_uc_15a_a"), $("input[name=uc_15b]"), $("#lbl_uc_15b"), $("#lbl_uc_15b_s"), $("#lbl_uc_15b_r"), $("#lbl_uc_15b_i"));
        });


        $(document).on("change", "#uc_15a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_15a]:checked").val(), $("#uc_15a_a"), "uc_15a_v", $("#lbl_uc_15a_a"), $("input[name=uc_15b]"), $("#lbl_uc_15b"), $("#lbl_uc_15b_s"), $("#lbl_uc_15b_r"), $("#lbl_uc_15b_i"));
        });


        $(document).on("change", "#uc_15a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_15a]:checked").val(), $("#uc_15a_a"), "uc_15a_v", $("#lbl_uc_15a_a"), $("input[name=uc_15b]"), $("#lbl_uc_15b"), $("#lbl_uc_15b_s"), $("#lbl_uc_15b_r"), $("#lbl_uc_15b_i"));
        });



        $(document).on("change", "#uc_16a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_16a]:checked").val(), $("#uc_16a_a"), "uc_16a_v", $("#lbl_uc_16a_a"), $("input[name=uc_16b]"), $("#lbl_uc_16b"), $("#lbl_uc_16b_s"), $("#lbl_uc_16b_r"), $("#lbl_uc_16b_i"));
        });


        $(document).on("change", "#uc_16a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_16a]:checked").val(), $("#uc_16a_a"), "uc_16a_v", $("#lbl_uc_16a_a"), $("input[name=uc_16b]"), $("#lbl_uc_16b"), $("#lbl_uc_16b_s"), $("#lbl_uc_16b_r"), $("#lbl_uc_16b_i"));
        });


        $(document).on("change", "#uc_16a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_16a]:checked").val(), $("#uc_16a_a"), "uc_16a_v", $("#lbl_uc_16a_a"), $("input[name=uc_16b]"), $("#lbl_uc_16b"), $("#lbl_uc_16b_s"), $("#lbl_uc_16b_r"), $("#lbl_uc_16b_i"));
        });



        $(document).on("change", "#uc_17a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_17a]:checked").val(), $("#uc_17a_a"), "uc_17a_v", $("#lbl_uc_17a_a"), $("input[name=uc_17b]"), $("#lbl_uc_17b"), $("#lbl_uc_17b_s"), $("#lbl_uc_17b_r"), $("#lbl_uc_17b_i"));
        });


        $(document).on("change", "#uc_17a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_17a]:checked").val(), $("#uc_17a_a"), "uc_17a_v", $("#lbl_uc_17a_a"), $("input[name=uc_17b]"), $("#lbl_uc_17b"), $("#lbl_uc_17b_s"), $("#lbl_uc_17b_r"), $("#lbl_uc_17b_i"));
        });


        $(document).on("change", "#uc_17a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_17a]:checked").val(), $("#uc_17a_a"), "uc_17a_v", $("#lbl_uc_17a_a"), $("input[name=uc_17b]"), $("#lbl_uc_17b"), $("#lbl_uc_17b_s"), $("#lbl_uc_17b_r"), $("#lbl_uc_17b_i"));
        });




        $(document).on("change", "#uc_18a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_18a]:checked").val(), $("#uc_18a_a"), "uc_18a_v", $("#lbl_uc_18a_a"), $("input[name=uc_18b]"), $("#lbl_uc_18b"), $("#lbl_uc_18b_s"), $("#lbl_uc_18b_r"), $("#lbl_uc_18b_i"));
        });


        $(document).on("change", "#uc_18a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_18a]:checked").val(), $("#uc_18a_a"), "uc_18a_v", $("#lbl_uc_18a_a"), $("input[name=uc_18b]"), $("#lbl_uc_18b"), $("#lbl_uc_18b_s"), $("#lbl_uc_18b_r"), $("#lbl_uc_18b_i"));
        });


        $(document).on("change", "#uc_18a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_18a]:checked").val(), $("#uc_18a_a"), "uc_18a_v", $("#lbl_uc_18a_a"), $("input[name=uc_18b]"), $("#lbl_uc_18b"), $("#lbl_uc_18b_s"), $("#lbl_uc_18b_r"), $("#lbl_uc_18b_i"));
        });



        $(document).on("change", "#uc_19a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_19a]:checked").val(), $("#uc_19a_a"), "uc_19a_v", $("#lbl_uc_19a_a"), $("input[name=uc_19b]"), $("#lbl_uc_19b"), $("#lbl_uc_19b_s"), $("#lbl_uc_19b_r"), $("#lbl_uc_19b_i"));
        });


        $(document).on("change", "#uc_19a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_19a]:checked").val(), $("#uc_19a_a"), "uc_19a_v", $("#lbl_uc_19a_a"), $("input[name=uc_19b]"), $("#lbl_uc_19b"), $("#lbl_uc_19b_s"), $("#lbl_uc_19b_r"), $("#lbl_uc_19b_i"));
        });


        $(document).on("change", "#uc_19a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_19a]:checked").val(), $("#uc_19a_a"), "uc_19a_v", $("#lbl_uc_19a_a"), $("input[name=uc_19b]"), $("#lbl_uc_19b"), $("#lbl_uc_19b_s"), $("#lbl_uc_19b_r"), $("#lbl_uc_19b_i"));
        });




        $(document).on("change", "#uc_20a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_20a]:checked").val(), $("#uc_20a_a"), "uc_20a_v", $("#lbl_uc_20a_a"), $("input[name=uc_20b]"), $("#lbl_uc_20b"), $("#lbl_uc_20b_s"), $("#lbl_uc_20b_r"), $("#lbl_uc_20b_i"));
        });


        $(document).on("change", "#uc_20a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_20a]:checked").val(), $("#uc_20a_a"), "uc_20a_v", $("#lbl_uc_20a_a"), $("input[name=uc_20b]"), $("#lbl_uc_20b"), $("#lbl_uc_20b_s"), $("#lbl_uc_20b_r"), $("#lbl_uc_20b_i"));
        });


        $(document).on("change", "#uc_20a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_20a]:checked").val(), $("#uc_20a_a"), "uc_20a_v", $("#lbl_uc_20a_a"), $("input[name=uc_20b]"), $("#lbl_uc_20b"), $("#lbl_uc_20b_s"), $("#lbl_uc_20b_r"), $("#lbl_uc_20b_i"));
        });





        $(document).on("change", "#uc_21a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_21a]:checked").val(), $("#uc_21a_a"), "uc_21a_v", $("#lbl_uc_21a_a"), $("input[name=uc_21b]"), $("#lbl_uc_21b"), $("#lbl_uc_21b_s"), $("#lbl_uc_21b_r"), $("#lbl_uc_21b_i"));
        });


        $(document).on("change", "#uc_21a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_21a]:checked").val(), $("#uc_21a_a"), "uc_21a_v", $("#lbl_uc_21a_a"), $("input[name=uc_21b]"), $("#lbl_uc_21b"), $("#lbl_uc_21b_s"), $("#lbl_uc_21b_r"), $("#lbl_uc_21b_i"));
        });


        $(document).on("change", "#uc_21a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_21a]:checked").val(), $("#uc_21a_a"), "uc_21a_v", $("#lbl_uc_21a_a"), $("input[name=uc_21b]"), $("#lbl_uc_21b"), $("#lbl_uc_21b_s"), $("#lbl_uc_21b_r"), $("#lbl_uc_21b_i"));
        });




        $(document).on("change", "#uc_22a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_22a]:checked").val(), $("#uc_22a_a"), "uc_22a_v", $("#lbl_uc_22a_a"), $("input[name=uc_22b]"), $("#lbl_uc_22b"), $("#lbl_uc_22b_s"), $("#lbl_uc_22b_r"), $("#lbl_uc_22b_i"));
        });


        $(document).on("change", "#uc_22a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_22a]:checked").val(), $("#uc_22a_a"), "uc_22a_v", $("#lbl_uc_22a_a"), $("input[name=uc_22b]"), $("#lbl_uc_22b"), $("#lbl_uc_22b_s"), $("#lbl_uc_22b_r"), $("#lbl_uc_22b_i"));
        });


        $(document).on("change", "#uc_22a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_22a]:checked").val(), $("#uc_22a_a"), "uc_22a_v", $("#lbl_uc_22a_a"), $("input[name=uc_22b]"), $("#lbl_uc_22b"), $("#lbl_uc_22b_s"), $("#lbl_uc_22b_r"), $("#lbl_uc_22b_i"));
        });



        $(document).on("change", "#uc_23a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_23a]:checked").val(), $("#uc_23a_a"), "uc_23a_v", $("#lbl_uc_23a_a"), $("input[name=uc_23b]"), $("#lbl_uc_23b"), $("#lbl_uc_23b_s"), $("#lbl_uc_23b_r"), $("#lbl_uc_23b_i"));
        });


        $(document).on("change", "#uc_23a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_23a]:checked").val(), $("#uc_23a_a"), "uc_23a_v", $("#lbl_uc_23a_a"), $("input[name=uc_23b]"), $("#lbl_uc_23b"), $("#lbl_uc_23b_s"), $("#lbl_uc_23b_r"), $("#lbl_uc_23b_i"));
        });


        $(document).on("change", "#uc_23a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_23a]:checked").val(), $("#uc_23a_a"), "uc_23a_v", $("#lbl_uc_23a_a"), $("input[name=uc_23b]"), $("#lbl_uc_23b"), $("#lbl_uc_23b_s"), $("#lbl_uc_23b_r"), $("#lbl_uc_23b_i"));
        });




        $(document).on("change", "#uc_24a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_24a]:checked").val(), $("#uc_24a_a"), "uc_24a_v", $("#lbl_uc_24a_a"), $("input[name=uc_24b]"), $("#lbl_uc_24b"), $("#lbl_uc_24b_s"), $("#lbl_uc_24b_r"), $("#lbl_uc_24b_i"));
        });


        $(document).on("change", "#uc_24a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_24a]:checked").val(), $("#uc_24a_a"), "uc_24a_v", $("#lbl_uc_24a_a"), $("input[name=uc_24b]"), $("#lbl_uc_24b"), $("#lbl_uc_24b_s"), $("#lbl_uc_24b_r"), $("#lbl_uc_24b_i"));
        });


        $(document).on("change", "#uc_24a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_24a]:checked").val(), $("#uc_24a_a"), "uc_24a_v", $("#lbl_uc_24a_a"), $("input[name=uc_24b]"), $("#lbl_uc_24b"), $("#lbl_uc_24b_s"), $("#lbl_uc_24b_r"), $("#lbl_uc_24b_i"));
        });




        $(document).on("change", "#uc_25a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_25a]:checked").val(), $("#uc_25a_a"), "uc_25a_v", $("#lbl_uc_25a_a"), $("input[name=uc_25b]"), $("#lbl_uc_25b"), $("#lbl_uc_25b_s"), $("#lbl_uc_25b_r"), $("#lbl_uc_25b_i"));
        });


        $(document).on("change", "#uc_25a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_25a]:checked").val(), $("#uc_25a_a"), "uc_25a_v", $("#lbl_uc_25a_a"), $("input[name=uc_25b]"), $("#lbl_uc_25b"), $("#lbl_uc_25b_s"), $("#lbl_uc_25b_r"), $("#lbl_uc_25b_i"));
        });


        $(document).on("change", "#uc_25a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_25a]:checked").val(), $("#uc_25a_a"), "uc_25a_v", $("#lbl_uc_25a_a"), $("input[name=uc_25b]"), $("#lbl_uc_25b"), $("#lbl_uc_25b_s"), $("#lbl_uc_25b_r"), $("#lbl_uc_25b_i"));
        });



        $(document).on("change", "#uc_26a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_26a]:checked").val(), $("#uc_26a_a"), "uc_26a_v", $("#lbl_uc_26a_a"), $("input[name=uc_26b]"), $("#lbl_uc_26b"), $("#lbl_uc_26b_s"), $("#lbl_uc_26b_r"), $("#lbl_uc_26b_i"));
        });


        $(document).on("change", "#uc_26a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_26a]:checked").val(), $("#uc_26a_a"), "uc_26a_v", $("#lbl_uc_26a_a"), $("input[name=uc_26b]"), $("#lbl_uc_26b"), $("#lbl_uc_26b_s"), $("#lbl_uc_26b_r"), $("#lbl_uc_26b_i"));
        });


        $(document).on("change", "#uc_26a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_26a]:checked").val(), $("#uc_26a_a"), "uc_26a_v", $("#lbl_uc_26a_a"), $("input[name=uc_26b]"), $("#lbl_uc_26b"), $("#lbl_uc_26b_s"), $("#lbl_uc_26b_r"), $("#lbl_uc_26b_i"));
        });




        $(document).on("change", "#uc_27a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_27a]:checked").val(), $("#uc_27a_a"), "uc_27a_v", $("#lbl_uc_27a_a"), $("input[name=uc_27b]"), $("#lbl_uc_27b"), $("#lbl_uc_27b_s"), $("#lbl_uc_27b_r"), $("#lbl_uc_27b_i"));
        });


        $(document).on("change", "#uc_27a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_27a]:checked").val(), $("#uc_27a_a"), "uc_27a_v", $("#lbl_uc_27a_a"), $("input[name=uc_27b]"), $("#lbl_uc_27b"), $("#lbl_uc_27b_s"), $("#lbl_uc_27b_r"), $("#lbl_uc_27b_i"));
        });


        $(document).on("change", "#uc_27a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_27a]:checked").val(), $("#uc_27a_a"), "uc_27a_v", $("#lbl_uc_27a_a"), $("input[name=uc_27b]"), $("#lbl_uc_27b"), $("#lbl_uc_27b_s"), $("#lbl_uc_27b_r"), $("#lbl_uc_27b_i"));
        });




        $(document).on("change", "#uc_28a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_28a]:checked").val(), $("#uc_28a_a"), "uc_28a_v", $("#lbl_uc_28a_a"), $("input[name=uc_28b]"), $("#lbl_uc_28b"), $("#lbl_uc_28b_s"), $("#lbl_uc_28b_r"), $("#lbl_uc_28b_i"));
        });


        $(document).on("change", "#uc_28a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_28a]:checked").val(), $("#uc_28a_a"), "uc_28a_v", $("#lbl_uc_28a_a"), $("input[name=uc_28b]"), $("#lbl_uc_28b"), $("#lbl_uc_28b_s"), $("#lbl_uc_28b_r"), $("#lbl_uc_28b_i"));
        });


        $(document).on("change", "#uc_28a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_28a]:checked").val(), $("#uc_28a_a"), "uc_28a_v", $("#lbl_uc_28a_a"), $("input[name=uc_28b]"), $("#lbl_uc_28b"), $("#lbl_uc_28b_s"), $("#lbl_uc_28b_r"), $("#lbl_uc_28b_i"));
        });



        $(document).on("change", "#uc_29a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_29a]:checked").val(), $("#uc_29a_a"), "uc_29a_v", $("#lbl_uc_29a_a"), $("input[name=uc_29b]"), $("#lbl_uc_29b"), $("#lbl_uc_29b_s"), $("#lbl_uc_29b_r"), $("#lbl_uc_29b_i"));
        });


        $(document).on("change", "#uc_29a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_29a]:checked").val(), $("#uc_29a_a"), "uc_29a_v", $("#lbl_uc_29a_a"), $("input[name=uc_29b]"), $("#lbl_uc_29b"), $("#lbl_uc_29b_s"), $("#lbl_uc_29b_r"), $("#lbl_uc_29b_i"));
        });


        $(document).on("change", "#uc_29a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_29a]:checked").val(), $("#uc_29a_a"), "uc_29a_v", $("#lbl_uc_29a_a"), $("input[name=uc_29b]"), $("#lbl_uc_29b"), $("#lbl_uc_29b_s"), $("#lbl_uc_29b_r"), $("#lbl_uc_29b_i"));
        });




        $(document).on("change", "#uc_30a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_30a]:checked").val(), $("#uc_30a_a"), "uc_30a_v", $("#lbl_uc_30a_a"), $("input[name=uc_30b]"), $("#lbl_uc_30b"), $("#lbl_uc_30b_s"), $("#lbl_uc_30b_r"), $("#lbl_uc_30b_i"));
        });


        $(document).on("change", "#uc_30a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_30a]:checked").val(), $("#uc_30a_a"), "uc_30a_v", $("#lbl_uc_30a_a"), $("input[name=uc_30b]"), $("#lbl_uc_30b"), $("#lbl_uc_30b_s"), $("#lbl_uc_30b_r"), $("#lbl_uc_30b_i"));
        });


        $(document).on("change", "#uc_30a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_30a]:checked").val(), $("#uc_30a_a"), "uc_30a_v", $("#lbl_uc_30a_a"), $("input[name=uc_30b]"), $("#lbl_uc_30b"), $("#lbl_uc_30b_s"), $("#lbl_uc_30b_r"), $("#lbl_uc_30b_i"));
        });




        $(document).on("change", "#uc_31a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_31a]:checked").val(), $("#uc_31a_a"), "uc_31a_v", $("#lbl_uc_31a_a"), $("input[name=uc_31b]"), $("#lbl_uc_31b"), $("#lbl_uc_31b_s"), $("#lbl_uc_31b_r"), $("#lbl_uc_31b_i"));
        });


        $(document).on("change", "#uc_31a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_31a]:checked").val(), $("#uc_31a_a"), "uc_31a_v", $("#lbl_uc_31a_a"), $("input[name=uc_31b]"), $("#lbl_uc_31b"), $("#lbl_uc_31b_s"), $("#lbl_uc_31b_r"), $("#lbl_uc_31b_i"));
        });


        $(document).on("change", "#uc_31a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_31a]:checked").val(), $("#uc_31a_a"), "uc_31a_v", $("#lbl_uc_31a_a"), $("input[name=uc_31b]"), $("#lbl_uc_31b"), $("#lbl_uc_31b_s"), $("#lbl_uc_31b_r"), $("#lbl_uc_31b_i"));
        });




        $(document).on("change", "#uc_32a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_32a]:checked").val(), $("#uc_32a_a"), "uc_32a_v", $("#lbl_uc_32a_a"), $("input[name=uc_32b]"), $("#lbl_uc_32b"), $("#lbl_uc_32b_s"), $("#lbl_uc_32b_r"), $("#lbl_uc_32b_i"));
        });


        $(document).on("change", "#uc_32a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_32a]:checked").val(), $("#uc_32a_a"), "uc_32a_v", $("#lbl_uc_32a_a"), $("input[name=uc_32b]"), $("#lbl_uc_32b"), $("#lbl_uc_32b_s"), $("#lbl_uc_32b_r"), $("#lbl_uc_32b_i"));
        });


        $(document).on("change", "#uc_32a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_32a]:checked").val(), $("#uc_32a_a"), "uc_32a_v", $("#lbl_uc_32a_a"), $("input[name=uc_32b]"), $("#lbl_uc_32b"), $("#lbl_uc_32b_s"), $("#lbl_uc_32b_r"), $("#lbl_uc_32b_i"));
        });




        $(document).on("change", "#uc_33a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_33a]:checked").val(), $("#uc_33a_a"), "uc_33a_v", $("#lbl_uc_33a_a"), $("input[name=uc_33b]"), $("#lbl_uc_33b"), $("#lbl_uc_33b_s"), $("#lbl_uc_33b_r"), $("#lbl_uc_33b_i"));
        });


        $(document).on("change", "#uc_33a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_33a]:checked").val(), $("#uc_33a_a"), "uc_33a_v", $("#lbl_uc_33a_a"), $("input[name=uc_33b]"), $("#lbl_uc_33b"), $("#lbl_uc_33b_s"), $("#lbl_uc_33b_r"), $("#lbl_uc_33b_i"));
        });


        $(document).on("change", "#uc_33a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_33a]:checked").val(), $("#uc_33a_a"), "uc_33a_v", $("#lbl_uc_33a_a"), $("input[name=uc_33b]"), $("#lbl_uc_33b"), $("#lbl_uc_33b_s"), $("#lbl_uc_33b_r"), $("#lbl_uc_33b_i"));
        });




        $(document).on("change", "#uc_34a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_34a]:checked").val(), $("#uc_34a_a"), "uc_34a_v", $("#lbl_uc_34a_a"), $("input[name=uc_34b]"), $("#lbl_uc_34b"), $("#lbl_uc_34b_s"), $("#lbl_uc_34b_r"), $("#lbl_uc_34b_i"));
        });


        $(document).on("change", "#uc_34a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_34a]:checked").val(), $("#uc_34a_a"), "uc_34a_v", $("#lbl_uc_34a_a"), $("input[name=uc_34b]"), $("#lbl_uc_34b"), $("#lbl_uc_34b_s"), $("#lbl_uc_34b_r"), $("#lbl_uc_34b_i"));
        });


        $(document).on("change", "#uc_34a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_34a]:checked").val(), $("#uc_34a_a"), "uc_34a_v", $("#lbl_uc_34a_a"), $("input[name=uc_34b]"), $("#lbl_uc_34b"), $("#lbl_uc_34b_s"), $("#lbl_uc_34b_r"), $("#lbl_uc_34b_i"));
        });




        $(document).on("change", "#uc_35a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_35a]:checked").val(), $("#uc_35a_a"), "uc_35a_v", $("#lbl_uc_35a_a"), $("input[name=uc_35b]"), $("#lbl_uc_35b"), $("#lbl_uc_35b_s"), $("#lbl_uc_35b_r"), $("#lbl_uc_35b_i"));
        });


        $(document).on("change", "#uc_35a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_35a]:checked").val(), $("#uc_35a_a"), "uc_35a_v", $("#lbl_uc_35a_a"), $("input[name=uc_35b]"), $("#lbl_uc_35b"), $("#lbl_uc_35b_s"), $("#lbl_uc_35b_r"), $("#lbl_uc_35b_i"));
        });


        $(document).on("change", "#uc_35a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_35a]:checked").val(), $("#uc_35a_a"), "uc_35a_v", $("#lbl_uc_35a_a"), $("input[name=uc_35b]"), $("#lbl_uc_35b"), $("#lbl_uc_35b_s"), $("#lbl_uc_35b_r"), $("#lbl_uc_35b_i"));
        });





        $(document).on("change", "#uc_36a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_36a]:checked").val(), $("#uc_36a_a"), "uc_36a_v", $("#lbl_uc_36a_a"), $("input[name=uc_36b]"), $("#lbl_uc_36b"), $("#lbl_uc_36b_s"), $("#lbl_uc_36b_r"), $("#lbl_uc_36b_i"));
        });


        $(document).on("change", "#uc_36a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_36a]:checked").val(), $("#uc_36a_a"), "uc_36a_v", $("#lbl_uc_36a_a"), $("input[name=uc_36b]"), $("#lbl_uc_36b"), $("#lbl_uc_36b_s"), $("#lbl_uc_36b_r"), $("#lbl_uc_36b_i"));
        });


        $(document).on("change", "#uc_36a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_36a]:checked").val(), $("#uc_36a_a"), "uc_36a_v", $("#lbl_uc_36a_a"), $("input[name=uc_36b]"), $("#lbl_uc_36b"), $("#lbl_uc_36b_s"), $("#lbl_uc_36b_r"), $("#lbl_uc_36b_i"));
        });




        $(document).on("change", "#uc_37a_v", function () {
            ShowHide_TextBox_New($("input[name=uc_37a]:checked").val(), $("#uc_37a_a"), "uc_37a_v", $("#lbl_uc_37a_a"), $("input[name=uc_37b]"), $("#lbl_uc_37b"), $("#lbl_uc_37b_s"), $("#lbl_uc_37b_r"), $("#lbl_uc_37b_i"));
        });


        $(document).on("change", "#uc_37a_b", function () {
            ShowHide_TextBox_New($("input[name=uc_37a]:checked").val(), $("#uc_37a_a"), "uc_37a_v", $("#lbl_uc_37a_a"), $("input[name=uc_37b]"), $("#lbl_uc_37b"), $("#lbl_uc_37b_s"), $("#lbl_uc_37b_r"), $("#lbl_uc_37b_i"));
        });


        $(document).on("change", "#uc_37a_c", function () {
            ShowHide_TextBox_New($("input[name=uc_37a]:checked").val(), $("#uc_37a_a"), "uc_37a_v", $("#lbl_uc_37a_a"), $("input[name=uc_37b]"), $("#lbl_uc_37b"), $("#lbl_uc_37b_s"), $("#lbl_uc_37b_r"), $("#lbl_uc_37b_i"));
        });







        function ShowHide_TextBox(rdovalue, txtbox, showval, questlabel) {
            if (rdovalue == showval) {
                txtbox.show();
                questlabel.show();
            }
            else {
                txtbox.hide();
                txtbox.val("");
                questlabel.hide();
            }

        }


        function ShowHide_TextBox_New(rdovalue, txtbox, showval, questlabel, rdointrepretation, rdolabel, rdolabels, rdolabelr, rdolabeli) {

            if (rdovalue == showval) {
                txtbox.show();
                questlabel.show();
                rdointrepretation.show();
                rdolabel.show();
                rdolabels.show();
                rdolabelr.show();
                rdolabeli.show();
            }
            else {
                txtbox.hide();
                txtbox.val("");
                questlabel.hide();
                rdointrepretation.hide();
                rdointrepretation.attr("checked", false);
                rdolabel.hide();
                rdolabels.hide();
                rdolabelr.hide();
                rdolabeli.hide();
            }

        }


    </script>

    <script>

        function ValidateForm() {

            if ($("#la_sno").val() == "__-_-____") {
                alert("Please enter screening id");
                $("#la_sno").focus();
                return false;
            }
            else if ($("#la_sno").val().indexOf("_") != -1) {
                alert("Please enter full screening id");
                $("#la_sno").focus();
                return false;
            }
            else if ($("#LA_01").val() == "") {
                alert("Please enter result reporting time NRL ");
                $("#LA_01").focus();
                return false;
            }
            else if ($("#LA_02").val() == "" && $("#LA_02").is(":visible") == true) {
                alert("Please enter CRP result (mg/dL) ");
                $("#LA_02").focus();
                return false;
            }
            else if ($('input[name=LA_03]:checked').length <= 0 && ($("#LA_03_v").is(":visible") == true
                || $("#LA_03_b").is(":visible") == true
                || $("#LA_03_c").is(":visible") == true
            )) {
                alert("Please select ");
                $("#LA_03_v").focus();
                return false;
            }
            else if ($("#LA_03_a").val() == "" && $("#LA_03_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_03_a").focus();
                return false;
            }
            else if ($('input[name=LA_04]:checked').length <= 0 && ($("#LA_04_v").is(":visible") == true
                || $("#LA_04_b").is(":visible") == true
                || $("#LA_04_c").is(":visible") == true
            )) {
                alert("Please select ");
                $("#LA_04_v").focus();
                return false;
            }
            else if ($("#LA_04_a").val() == "" && $("#LA_04_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_04_a").focus();
                return false;
            }
            else if ($('input[name=LA_05]:checked').length <= 0 && ($("#LA_05_v").is(":visible") == true
                || $("#LA_05_b").is(":visible") == true
                || $("#LA_05_c").is(":visible") == true
            )) {
                alert("Please select ");
                $("#LA_05_v").focus();
                return false;
            }
            else if ($("#LA_05_a").val() == "" && $("#LA_05_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_05_a").focus();
                return false;
            }
            else if ($('input[name=LA_06]:checked').length <= 0 && ($("#LA_06_v").is(":visible") == true
                || $("#LA_06_b").is(":visible") == true
                || $("#LA_06_c").is(":visible") == true
            )) {
                alert("Please select ");
                $("#LA_06_v").focus();
                return false;
            }
            else if ($("#LA_06_a").val() == "" && $("#LA_06_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_06_a").focus();
                return false;
            }
            else if ($('input[name=LA_07]:checked').length <= 0 && ($("#LA_07_v").is(":visible") == true
                || $("#LA_07_b").is(":visible") == true
                || $("#LA_07_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_07_v").focus();
                return false;
            }
            else if ($("#LA_07_a").val() == "" && $("#LA_07_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_07_a").focus();
                return false;
            }
            else if ($('input[name=LA_08]:checked').length <= 0 && ($("#LA_08_v").is(":visible") == true
                || $("#LA_08_b").is(":visible") == true
                || $("#LA_08_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_08_v").focus();
                return false;
            }
            else if ($("#LA_08_a").val() == "" && $("#LA_08_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_08_a").focus();
                return false;
            }
            else if ($('input[name=LA_09]:checked').length <= 0 && ($("#LA_09_v").is(":visible") == true
                || $("#LA_09_b").is(":visible") == true
                || $("#LA_09_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_09_v").focus();
                return false;
            }
            else if ($("#LA_09_a").val() == "" && $("#LA_09_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_09_a").focus();
                return false;
            }
            else if ($('input[name=LA_10]:checked').length <= 0 && ($("#LA_10_v").is(":visible") == true
                || $("#LA_10_b").is(":visible") == true
                || $("#LA_10_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_10_v").focus();
                return false;
            }
            else if ($("#LA_10_a").val() == "" && $("#LA_10_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_10_a").focus();
                return false;
            }
            else if ($('input[name=LA_11]:checked').length <= 0 && ($("#LA_11_v").is(":visible") == true
                || $("#LA_11_b").is(":visible") == true
                || $("#LA_11_c").is(":visible") == true
            )) {
                alert("Please select ");
                $("#LA_11_v").focus();
                return false;
            }
            else if ($("#LA_11_a").val() == "" && $("#LA_11_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_11_a").focus();
                return false;
            }
            else if ($('input[name=LA_12]:checked').length <= 0 && ($("#LA_12_v").is(":visible") == true
                || $("#LA_12_b").is(":visible") == true
                || $("#LA_12_c").is(":visible") == true
            )) {
                alert("Please select ");
                $("#LA_12_v").focus();
                return false;
            }
            else if ($("#LA_12_a").val() == "" && $("#LA_12_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_12_a").focus();
                return false;
            }
            else if ($('input[name=LA_13]:checked').length <= 0 && ($("#LA_13_v").is(":visible") == true
                || $("#LA_13_b").is(":visible") == true
                || $("#LA_13_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_13_v").focus();
                return false;
            }
            else if ($("#LA_13_a").val() == "" && $("#LA_13_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_13_a").focus();
                return false;
            }
            else if ($('input[name=LA_14]:checked').length <= 0 && ($("#LA_14_v").is(":visible") == true
                || $("#LA_14_b").is(":visible") == true
                || $("#LA_14_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_14_v").focus();
                return false;
            }
            else if ($("#LA_14_a").val() == "" && $("#LA_14_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_14_a").focus();
                return false;
            }
            else if ($('input[name=LA_15]:checked').length <= 0 && ($("#LA_15_v").is(":visible") == true
                || $("#LA_15_b").is(":visible") == true
                || $("#LA_15_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_15_v").focus();
                return false;
            }
            else if ($("#LA_15_a").val() == "" && $("#LA_15_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_15_a").focus();
                return false;
            }
            else if ($('input[name=LA_16]:checked').length <= 0 && ($("#LA_16_v").is(":visible") == true
                || $("#LA_16_b").is(":visible") == true
                || $("#LA_16_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_16_v").focus();
                return false;
            }
            else if ($("#LA_16_a").val() == "" && $("#LA_16_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_16_a").focus();
                return false;
            }
            else if ($("#LA_17").val() == "" && $("#LA_17").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_17").focus();
                return false;
            }
            else if ($('input[name=LF_01]:checked').length <= 0 && ($("#LF_01_v").is(":visible") == true
                || $("#LF_01_b").is(":visible") == true
                || $("#LF_01_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LF_01_v").focus();
                return false;
            }
            else if ($("#LF_01_a").val() == "" && $("#LF_01_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LF_01_a").focus();
                return false;
            }
            else if ($('input[name=LF_02]:checked').length <= 0 && ($("#LF_02_v").is(":visible") == true
                || $("#LF_02_b").is(":visible") == true
                || $("#LF_02_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LF_02_v").focus();
                return false;
            }
            else if ($("#LF_02_a").val() == "" && $("#LF_02_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LF_02_a").focus();
                return false;
            }
            else if ($('input[name=LF_03]:checked').length <= 0 && ($("#LF_03_v").is(":visible") == true
                || $("#LF_03_b").is(":visible") == true
                || $("#LF_03_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LF_03_v").focus();
                return false;
            }
            else if ($("#LF_03_a").val() == "" && $("#LF_03_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LF_03_a").focus();
                return false;
            }
            else if ($('input[name=LF_04]:checked').length <= 0 && ($("#LF_04_v").is(":visible") == true
                || $("#LF_04_b").is(":visible") == true
                || $("#LF_04_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LF_04_v").focus();
                return false;
            }
            else if ($("#LF_04_a").val() == "" && $("#LF_04_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LF_04_a").focus();
                return false;
            }
            else if ($('input[name=LF_05]:checked').length <= 0 && ($("#LF_05_v").is(":visible") == true
                || $("#LF_05_b").is(":visible") == true
                || $("#LF_05_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LF_05_v").focus();
                return false;
            }
            else if ($("#LF_05_a").val() == "" && $("#LF_05_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LF_05_a").focus();
                return false;
            }
            else if ($('input[name=LF_06]:checked').length <= 0 && ($("#LF_06_v").is(":visible") == true
                || $("#LF_06_b").is(":visible") == true
                || $("#LF_06_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LF_06_v").focus();
                return false;
            }
            else if ($("#LF_06_a").val() == "" && $("#LF_06_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LF_06_a").focus();
                return false;
            }
            else if ($('input[name=LF_07]:checked').length <= 0 && ($("#LF_07_v").is(":visible") == true
                || $("#LF_07_b").is(":visible") == true
                || $("#LF_07_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LF_07_v").focus();
                return false;
            }
            else if ($("#LF_07_a").val() == "" && $("#LF_07_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LF_07_a").focus();
                return false;
            }
            else if ($('input[name=RF_01]:checked').length <= 0 && ($("#RF_01_v").is(":visible") == true
                || $("#RF_01_b").is(":visible") == true
                || $("#RF_01_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#RF_01_v").focus();
                return false;
            }
            else if ($("#RF_01_a").val() == "" && $("#RF_01_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#RF_01_a").focus();
                return false;
            }
            else if ($('input[name=RF_02]:checked').length <= 0 && ($("#RF_02_v").is(":visible") == true
                || $("#RF_02_b").is(":visible") == true
                || $("#RF_02_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#RF_02_v").focus();
                return false;
            }
            else if ($("#RF_02_a").val() == "" && $("#RF_02_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#RF_02_a").focus();
                return false;
            }
            else if ($('input[name=RF_03]:checked').length <= 0 && ($("#RF_03_v").is(":visible") == true
                || $("#RF_03_b").is(":visible") == true
                || $("#RF_03_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#RF_03_v").focus();
                return false;
            }
            else if ($("#RF_03_a").val() == "" && $("#RF_03_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#RF_03_a").focus();
                return false;
            }
            else if ($('input[name=RF_04]:checked').length <= 0 && ($("#RF_04_v").is(":visible") == true
                || $("#RF_04_b").is(":visible") == true
                || $("#RF_04_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#RF_04_v").focus();
                return false;
            }
            else if ($("#RF_04_a").val() == "" && $("#RF_04_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#RF_04_a").focus();
                return false;
            }
            else if ($('input[name=SE_01]:checked').length <= 0 && ($("#SE_01_v").is(":visible") == true
                || $("#SE_01_b").is(":visible") == true
                || $("#SE_01_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#SE_01_v").focus();
                return false;
            }
            else if ($("#SE_01_a").val() == "" && $("#SE_01_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#SE_01_a").focus();
                return false;
            }
            else if ($('input[name=SE_02]:checked').length <= 0 && ($("#SE_02_v").is(":visible") == true
                || $("#SE_02_b").is(":visible") == true
                || $("#SE_02_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#SE_02_v").focus();
                return false;
            }
            else if ($("#SE_02_a").val() == "" && $("#SE_02_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#SE_02_a").focus();
                return false;
            }
            else if ($('input[name=SE_03]:checked').length <= 0 && ($("#SE_03_v").is(":visible") == true
                || $("#SE_03_b").is(":visible") == true
                || $("#SE_03_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#SE_03_v").focus();
                return false;
            }
            else if ($("#SE_03_a").val() == "" && $("#SE_03_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#SE_03_a").focus();
                return false;
            }
            else if ($('input[name=SE_04]:checked').length <= 0 && ($("#SE_04_v").is(":visible") == true
                || $("#SE_04_b").is(":visible") == true
                || $("#SE_04_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#SE_04_v").focus();
                return false;
            }
            else if ($("#SE_04_a").val() == "" && $("#SE_04_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#SE_04_a").focus();
                return false;
            }
            else if ($('input[name=CS_01]:checked').length <= 0 && ($("#CS_01_v").is(":visible") == true
                || $("#CS_01_b").is(":visible") == true
                || $("#CS_01_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#CS_01_v").focus();
                return false;
            }
            else if ($("#CS_01_a").val() == "" && $("#CS_01_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#CS_01_a").focus();
                return false;
            }
            else if ($('input[name=CS_02]:checked').length <= 0 && ($("#CS_02_v").is(":visible") == true
                || $("#CS_02_b").is(":visible") == true
                || $("#CS_02_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#CS_02_v").focus();
                return false;
            }
            else if ($("#CS_02_a").val() == "" && $("#CS_02_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#CS_02_a").focus();
                return false;
            }
            else if ($('input[name=CS_03]:checked').length <= 0 && ($("#CS_03_v").is(":visible") == true
                || $("#CS_03_b").is(":visible") == true
                || $("#CS_03_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#CS_03_v").focus();
                return false;
            }
            else if ($("#CS_03_a").val() == "" && $("#CS_03_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#CS_03_a").focus();
                return false;
            }
            else if ($('input[name=CS_04]:checked').length <= 0 && ($("#CS_04_v").is(":visible") == true
                || $("#CS_04_b").is(":visible") == true
                || $("#CS_04_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#CS_04_v").focus();
                return false;
            }
            else if ($("#CS_04_a").val() == "" && $("#CS_04_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#CS_04_a").focus();
                return false;
            }
            else if ($('input[name=CS_05]:checked').length <= 0 && ($("#CS_05_v").is(":visible") == true
                || $("#CS_05_b").is(":visible") == true
                || $("#CS_05_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#CS_05_v").focus();
                return false;
            }
            else if ($("#CS_05_a").val() == "" && $("#CS_05_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#CS_05_a").focus();
                return false;
            }
            else if ($('input[name=CS_06]:checked').length <= 0 && ($("#CS_06_v").is(":visible") == true
                || $("#CS_06_b").is(":visible") == true
                || $("#CS_06_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#CS_06_v").focus();
                return false;
            }
            else if ($("#CS_06_a").val() == "" && $("#CS_06_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#CS_06_a").focus();
                return false;
            }
            else if ($('input[name=CS_07]:checked').length <= 0 && ($("#CS_07_v").is(":visible") == true
                || $("#CS_07_b").is(":visible") == true
                || $("#CS_07_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#CS_07_v").focus();
                return false;
            }
            else if ($("#CS_07_a").val() == "" && $("#CS_07_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#CS_07_a").focus();
                return false;
            }
            else if ($('input[name=CS_08]:checked').length <= 0 && ($("#CS_08_v").is(":visible") == true
                || $("#CS_08_b").is(":visible") == true
                || $("#CS_08_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#CS_08_v").focus();
                return false;
            }
            else if ($("#CS_08_a").val() == "" && $("#CS_08_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#CS_08_a").focus();
                return false;
            }
            else if ($('input[name=CS_09]:checked').length <= 0 && ($("#CS_09_v").is(":visible") == true
                || $("#CS_09_b").is(":visible") == true
                || $("#CS_09_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#CS_09_v").focus();
                return false;
            }
            else if ($("#CS_09_a").val() == "" && $("#CS_09_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#CS_09_a").focus();
                return false;
            }
            else if ($('input[name=CS_10]:checked').length <= 0 && ($("#CS_10_v").is(":visible") == true
                || $("#CS_10_b").is(":visible") == true
                || $("#CS_10_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#CS_10_v").focus();
                return false;
            }
            else if ($("#CS_10_a").val() == "" && $("#CS_10_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#CS_10_a").focus();
                return false;
            }
            else if ($('input[name=UR_01]:checked').length <= 0 && ($("#UR_01_v").is(":visible") == true
                || $("#UR_01_b").is(":visible") == true
                || $("#UR_01_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_01_v").focus();
                return false;
            }
            else if ($("#UR_01_a").val() == "" && $("#UR_01_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_01_a").focus();
                return false;
            }
            else if ($('input[name=UR_02]:checked').length <= 0 && ($("#UR_02_v").is(":visible") == true
                || $("#UR_02_b").is(":visible") == true
                || $("#UR_02_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_02_v").focus();
                return false;
            }
            else if ($("#UR_02_a").val() == "" && $("#UR_02_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_02_a").focus();
                return false;
            }
            else if ($('input[name=UR_03]:checked').length <= 0 && ($("#UR_03_v").is(":visible") == true
                || $("#UR_03_b").is(":visible") == true
                || $("#UR_03_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_03_v").focus();
                return false;
            }
            else if ($("#UR_03_a").val() == "" && $("#UR_03_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_03_a").focus();
                return false;
            }
            else if ($('input[name=UR_04]:checked').length <= 0 && ($("#UR_04_v").is(":visible") == true
                || $("#UR_04_b").is(":visible") == true
                || $("#UR_04_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_04_v").focus();
                return false;
            }
            else if ($("#UR_04_a").val() == "" && $("#UR_04_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_04_a").focus();
                return false;
            }
            else if ($('input[name=UR_05]:checked').length <= 0 && ($("#UR_05_v").is(":visible") == true
                || $("#UR_05_b").is(":visible") == true
                || $("#UR_05_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_05_v").focus();
                return false;
            }
            else if ($("#UR_05_a").val() == "" && $("#UR_05_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_05_a").focus();
                return false;
            }
            else if ($('input[name=UR_06]:checked').length <= 0 && ($("#UR_06_v").is(":visible") == true
                || $("#UR_06_b").is(":visible") == true
                || $("#UR_06_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_06_v").focus();
                return false;
            }
            else if ($("#UR_06_a").val() == "" && $("#UR_06_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_06_a").focus();
                return false;
            }
            else if ($('input[name=UR_07]:checked').length <= 0 && ($("#UR_07_v").is(":visible") == true
                || $("#UR_07_b").is(":visible") == true
                || $("#UR_07_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_07_v").focus();
                return false;
            }
            else if ($("#UR_07_a").val() == "" && $("#UR_07_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_07_a").focus();
                return false;
            }
            else if ($('input[name=UR_08]:checked').length <= 0 && ($("#UR_08_v").is(":visible") == true
                || $("#UR_08_b").is(":visible") == true
                || $("#UR_08_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_08_v").focus();
                return false;
            }
            else if ($("#UR_08_a").val() == "" && $("#UR_08_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_08_a").focus();
                return false;
            }
            else if ($('input[name=UR_09]:checked').length <= 0 && ($("#UR_09_v").is(":visible") == true
                || $("#UR_09_b").is(":visible") == true
                || $("#UR_09_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_09_v").focus();
                return false;
            }
            else if ($("#UR_09_a").val() == "" && $("#UR_09_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_09_a").focus();
                return false;
            }
            else if ($('input[name=UR_10]:checked').length <= 0 && ($("#UR_10_v").is(":visible") == true
                || $("#UR_10_b").is(":visible") == true
                || $("#UR_10_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_10_v").focus();
                return false;
            }
            else if ($("#UR_10_a").val() == "" && $("#UR_10_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_10_a").focus();
                return false;
            }
            else if ($('input[name=UR_11]:checked').length <= 0 && ($("#UR_11_v").is(":visible") == true
                || $("#UR_11_b").is(":visible") == true
                || $("#UR_11_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_11_v").focus();
                return false;
            }
            else if ($("#UR_11_a").val() == "" && $("#UR_11_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_11_a").focus();
                return false;
            }
            else if ($('input[name=UR_12]:checked').length <= 0 && ($("#UR_12_v").is(":visible") == true
                || $("#UR_12_b").is(":visible") == true
                || $("#UR_12_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_12_v").focus();
                return false;
            }
            else if ($("#UR_12_a").val() == "" && $("#UR_12_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_12_a").focus();
                return false;
            }
            else if ($('input[name=UR_13]:checked').length <= 0 && ($("#UR_13_v").is(":visible") == true
                || $("#UR_13_b").is(":visible") == true
                || $("#UR_13_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_13_v").focus();
                return false;
            }
            else if ($("#UR_13_a").val() == "" && $("#UR_13_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_13_a").focus();
                return false;
            }
            else if ($('input[name=UR_14]:checked').length <= 0 && ($("#UR_14_v").is(":visible") == true
                || $("#UR_14_b").is(":visible") == true
                || $("#UR_14_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_14_v").focus();
                return false;
            }
            else if ($("#UR_14_a").val() == "" && $("#UR_14_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_14_a").focus();
                return false;
            }
            else if ($('input[name=UR_15]:checked').length <= 0 && ($("#UR_15_v").is(":visible") == true
                || $("#UR_15_b").is(":visible") == true
                || $("#UR_15_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_15_v").focus();
                return false;
            }
            else if ($("#UR_15_a").val() == "" && $("#UR_15_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_15_a").focus();
                return false;
            }
            else if ($('input[name=UR_16]:checked').length <= 0 && ($("#UR_16_v").is(":visible") == true
                || $("#UR_16_b").is(":visible") == true
                || $("#UR_16_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_16_v").focus();
                return false;
            }
            else if ($("#UR_16_a").val() == "" && $("#UR_16_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_16_a").focus();
                return false;
            }
            else if ($('input[name=UR_17]:checked').length <= 0 && ($("#UR_17_v").is(":visible") == true
                || $("#UR_17_b").is(":visible") == true
                || $("#UR_17_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_17_v").focus();
                return false;
            }
            else if ($("#UR_17_a").val() == "" && $("#UR_17_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_17_a").focus();
                return false;
            }
            else if ($('input[name=UR_18]:checked').length <= 0 && ($("#UR_18_v").is(":visible") == true
                || $("#UR_18_b").is(":visible") == true
                || $("#UR_18_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_18_v").focus();
                return false;
            }
            else if ($("#UR_18_a").val() == "" && $("#UR_18_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_18_a").focus();
                return false;
            }
            else if ($('input[name=UR_19]:checked').length <= 0 && ($("#UR_19_v").is(":visible") == true
                || $("#UR_19_b").is(":visible") == true
                || $("#UR_19_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_19_v").focus();
                return false;
            }
            else if ($("#UR_19_a").val() == "" && $("#UR_19_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_19_a").focus();
                return false;
            }
            else if ($('input[name=UR_20]:checked').length <= 0 && ($("#UR_20_v").is(":visible") == true
                || $("#UR_20_b").is(":visible") == true
                || $("#UR_20_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_20_v").focus();
                return false;
            }
            else if ($("#UR_20_a").val() == "" && $("#UR_20_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_20_a").focus();
                return false;
            }
            else if ($('input[name=UR_21]:checked').length <= 0 && ($("#UR_21_v").is(":visible") == true
                || $("#UR_21_b").is(":visible") == true
                || $("#UR_21_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#UR_21_v").focus();
                return false;
            }
            else if ($("#UR_21_a").val() == "" && $("#UR_21_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#UR_21_a").focus();
                return false;
            }
            else if ($('input[name=uc_02a]:checked').length <= 0 && ($("#uc_02a_v").is(":visible") == true
                || $("#uc_02a_b").is(":visible") == true
                || $("#uc_02a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_02a_v").focus();
                return false;
            }
            else if ($("#uc_02a_a").val() == "" && $("#uc_02a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_02a_a").focus();
                return false;
            }
            else if ($('input[name=uc_03a]:checked').length <= 0 && ($("#uc_03a_v").is(":visible") == true
                || $("#uc_03a_b").is(":visible") == true
                || $("#uc_03a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_03a_v").focus();
                return false;
            }
            else if ($("#uc_03a_a").val() == "" && $("#uc_03a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_03a_a").focus();
                return false;
            }
            else if ($('input[name=uc_04a]:checked').length <= 0 && ($("#uc_04a_v").is(":visible") == true
                || $("#uc_04a_b").is(":visible") == true
                || $("#uc_04a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_04a_v").focus();
                return false;
            }
            else if ($("#uc_04a_a").val() == "" && $("#uc_04a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_04a_a").focus();
                return false;
            }
            else if ($('input[name=uc_05a]:checked').length <= 0 && ($("#uc_05a_v").is(":visible") == true
                || $("#uc_05a_b").is(":visible") == true
                || $("#uc_05a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_05a_v").focus();
                return false;
            }
            else if ($("#uc_05a_a").val() == "" && $("#uc_05a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_05a_a").focus();
                return false;
            }
            else if ($('input[name=uc_06a]:checked').length <= 0 && ($("#uc_06a_v").is(":visible") == true
                || $("#uc_06a_b").is(":visible") == true
                || $("#uc_06a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_06a_v").focus();
                return false;
            }
            else if ($("#uc_06a_a").val() == "" && $("#uc_06a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_06a_a").focus();
                return false;
            }
            else if ($('input[name=uc_07a]:checked').length <= 0 && ($("#uc_07a_v").is(":visible") == true
                || $("#uc_07a_b").is(":visible") == true
                || $("#uc_07a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_07a_v").focus();
                return false;
            }
            else if ($("#uc_07a_a").val() == "" && $("#uc_07a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_07a_a").focus();
                return false;
            }
            else if ($('input[name=uc_08a]:checked').length <= 0 && ($("#uc_08a_v").is(":visible") == true
                || $("#uc_08a_b").is(":visible") == true
                || $("#uc_08a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_08a_v").focus();
                return false;
            }
            else if ($("#uc_08a_a").val() == "" && $("#uc_08a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_08a_a").focus();
                return false;
            }
            else if ($('input[name=uc_09a]:checked').length <= 0 && ($("#uc_09a_v").is(":visible") == true
                || $("#uc_09a_b").is(":visible") == true
                || $("#uc_09a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_09a_v").focus();
                return false;
            }
            else if ($("#uc_09a_a").val() == "" && $("#uc_09a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_09a_a").focus();
                return false;
            }
            else if ($('input[name=uc_10a]:checked').length <= 0 && ($("#uc_10a_v").is(":visible") == true
                || $("#uc_10a_b").is(":visible") == true
                || $("#uc_10a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_10a_v").focus();
                return false;
            }
            else if ($("#uc_10a_a").val() == "" && $("#uc_10a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_10a_a").focus();
                return false;
            }
            else if ($('input[name=uc_11a]:checked').length <= 0 && ($("#uc_11a_v").is(":visible") == true
                || $("#uc_11a_b").is(":visible") == true
                || $("#uc_11a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_11a_v").focus();
                return false;
            }
            else if ($("#uc_11a_a").val() == "" && $("#uc_11a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_11a_a").focus();
                return false;
            }
            else if ($('input[name=uc_12a]:checked').length <= 0 && ($("#uc_12a_v").is(":visible") == true
                || $("#uc_12a_b").is(":visible") == true
                || $("#uc_12a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_12a_v").focus();
                return false;
            }
            else if ($("#uc_12a_a").val() == "" && $("#uc_12a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_12a_a").focus();
                return false;
            }
            else if ($('input[name=uc_13a]:checked').length <= 0 && ($("#uc_13a_v").is(":visible") == true
                || $("#uc_13a_b").is(":visible") == true
                || $("#uc_13a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_13a_v").focus();
                return false;
            }
            else if ($("#uc_13a_a").val() == "" && $("#uc_13a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_13a_a").focus();
                return false;
            }
            else if ($('input[name=uc_14a]:checked').length <= 0 && ($("#uc_14a_v").is(":visible") == true
                || $("#uc_14a_b").is(":visible") == true
                || $("#uc_14a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_14a_v").focus();
                return false;
            }
            else if ($("#uc_14a_a").val() == "" && $("#uc_14a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_14a_a").focus();
                return false;
            }
            else if ($('input[name=uc_15a]:checked').length <= 0 && ($("#uc_15a_v").is(":visible") == true
                || $("#uc_15a_b").is(":visible") == true
                || $("#uc_15a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_15a_v").focus();
                return false;
            }
            else if ($("#uc_15a_a").val() == "" && $("#uc_15a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_15a_a").focus();
                return false;
            }
            else if ($('input[name=uc_16a]:checked').length <= 0 && ($("#uc_16a_v").is(":visible") == true
                || $("#uc_16a_b").is(":visible") == true
                || $("#uc_16a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_16a_v").focus();
                return false;
            }
            else if ($("#uc_16a_a").val() == "" && $("#uc_16a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_16a_a").focus();
                return false;
            }
            else if ($('input[name=uc_17a]:checked').length <= 0 && ($("#uc_17a_v").is(":visible") == true
                || $("#uc_17a_b").is(":visible") == true
                || $("#uc_17a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_17a_v").focus();
                return false;
            }
            else if ($("#uc_17a_a").val() == "" && $("#uc_17a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_17a_a").focus();
                return false;
            }
            else if ($('input[name=uc_18a]:checked').length <= 0 && ($("#uc_18a_v").is(":visible") == true
                || $("#uc_18a_b").is(":visible") == true
                || $("#uc_18a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_18a_v").focus();
                return false;
            }
            else if ($("#uc_18a_a").val() == "" && $("#uc_18a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_18a_a").focus();
                return false;
            }
            else if ($('input[name=uc_19a]:checked').length <= 0 && ($("#uc_19a_v").is(":visible") == true
                || $("#uc_19a_b").is(":visible") == true
                || $("#uc_19a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_19a_v").focus();
                return false;
            }
            else if ($("#uc_19a_a").val() == "" && $("#uc_19a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_19a_a").focus();
                return false;
            }
            else if ($('input[name=uc_20a]:checked').length <= 0 && ($("#uc_20a_v").is(":visible") == true
                || $("#uc_20a_b").is(":visible") == true
                || $("#uc_20a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_20a_v").focus();
                return false;
            }
            else if ($("#uc_20a_a").val() == "" && $("#uc_20a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_20a_a").focus();
                return false;
            }
            else if ($('input[name=uc_21a]:checked').length <= 0 && ($("#uc_21a_v").is(":visible") == true
                || $("#uc_21a_b").is(":visible") == true
                || $("#uc_21a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_21a_v").focus();
                return false;
            }
            else if ($("#uc_21a_a").val() == "" && $("#uc_21a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_21a_a").focus();
                return false;
            }
            else if ($('input[name=uc_22a]:checked').length <= 0 && ($("#uc_22a_v").is(":visible") == true
                || $("#uc_22a_b").is(":visible") == true
                || $("#uc_22a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_22a_v").focus();
                return false;
            }
            else if ($("#uc_22a_a").val() == "" && $("#uc_22a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_22a_a").focus();
                return false;
            }
            else if ($('input[name=uc_23a]:checked').length <= 0 && ($("#uc_23a_v").is(":visible") == true
                || $("#uc_23a_b").is(":visible") == true
                || $("#uc_23a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_23a_v").focus();
                return false;
            }
            else if ($("#uc_23a_a").val() == "" && $("#uc_23a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_23a_a").focus();
                return false;
            }
            else if ($('input[name=uc_24a]:checked').length <= 0 && ($("#uc_24a_v").is(":visible") == true
                || $("#uc_24a_b").is(":visible") == true
                || $("#uc_24a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_24a_v").focus();
                return false;
            }
            else if ($("#uc_24a_a").val() == "" && $("#uc_24a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_24a_a").focus();
                return false;
            }
            else if ($('input[name=uc_25a]:checked').length <= 0 && ($("#uc_25a_v").is(":visible") == true
                || $("#uc_25a_b").is(":visible") == true
                || $("#uc_25a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_25a_v").focus();
                return false;
            }
            else if ($("#uc_25a_a").val() == "" && $("#uc_25a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_25a_a").focus();
                return false;
            }
            else if ($('input[name=uc_26a]:checked').length <= 0 && ($("#uc_26a_v").is(":visible") == true
                || $("#uc_26a_b").is(":visible") == true
                || $("#uc_26a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_26a_v").focus();
                return false;
            }
            else if ($("#uc_26a_a").val() == "" && $("#uc_26a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_26a_a").focus();
                return false;
            }
            else if ($('input[name=uc_27a]:checked').length <= 0 && ($("#uc_27a_v").is(":visible") == true
                || $("#uc_27a_b").is(":visible") == true
                || $("#uc_27a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_27a_v").focus();
                return false;
            }
            else if ($("#uc_27a_a").val() == "" && $("#uc_27a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_27a_a").focus();
                return false;
            }
            else if ($('input[name=uc_28a]:checked').length <= 0 && ($("#uc_28a_v").is(":visible") == true
                || $("#uc_28a_b").is(":visible") == true
                || $("#uc_28a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_28a_v").focus();
                return false;
            }
            else if ($("#uc_28a_a").val() == "" && $("#uc_28a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_28a_a").focus();
                return false;
            }
            else if ($('input[name=uc_29a]:checked').length <= 0 && ($("#uc_29a_v").is(":visible") == true
                || $("#uc_29a_b").is(":visible") == true
                || $("#uc_29a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_29a_v").focus();
                return false;
            }
            else if ($("#uc_29a_a").val() == "" && $("#uc_29a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_29a_a").focus();
                return false;
            }
            else if ($('input[name=uc_30a]:checked').length <= 0 && ($("#uc_30a_v").is(":visible") == true
                || $("#uc_30a_b").is(":visible") == true
                || $("#uc_30a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_30a_v").focus();
                return false;
            }
            else if ($("#uc_30a_a").val() == "" && $("#uc_30a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_30a_a").focus();
                return false;
            }
            else if ($('input[name=uc_31a]:checked').length <= 0 && ($("#uc_31a_v").is(":visible") == true
                || $("#uc_31a_b").is(":visible") == true
                || $("#uc_31a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_31a_v").focus();
                return false;
            }
            else if ($("#uc_31a_a").val() == "" && $("#uc_31a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_31a_a").focus();
                return false;
            }
            else if ($('input[name=uc_32a]:checked').length <= 0 && ($("#uc_32a_v").is(":visible") == true
                || $("#uc_32a_b").is(":visible") == true
                || $("#uc_32a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_32a_v").focus();
                return false;
            }
            else if ($("#uc_32a_a").val() == "" && $("#uc_32a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_32a_a").focus();
                return false;
            }
            else if ($('input[name=uc_33a]:checked').length <= 0 && ($("#uc_33a_v").is(":visible") == true
                || $("#uc_33a_b").is(":visible") == true
                || $("#uc_33a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_33a_v").focus();
                return false;
            }
            else if ($("#uc_33a_a").val() == "" && $("#uc_33a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_33a_a").focus();
                return false;
            }
            else if ($('input[name=uc_34a]:checked').length <= 0 && ($("#uc_34a_v").is(":visible") == true
                || $("#uc_34a_b").is(":visible") == true
                || $("#uc_34a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_34a_v").focus();
                return false;
            }
            else if ($("#uc_34a_a").val() == "" && $("#uc_34a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_34a_a").focus();
                return false;
            }
            else if ($('input[name=uc_35a]:checked').length <= 0 && ($("#uc_35a_v").is(":visible") == true
                || $("#uc_35a_b").is(":visible") == true
                || $("#uc_35a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_35a_v").focus();
                return false;
            }
            else if ($("#uc_35a_a").val() == "" && $("#uc_35a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_35a_a").focus();
                return false;
            }
            else if ($('input[name=uc_36a]:checked').length <= 0 && ($("#uc_36a_v").is(":visible") == true
                || $("#uc_36a_b").is(":visible") == true
                || $("#uc_36a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_36a_v").focus();
                return false;
            }
            else if ($("#uc_36a_a").val() == "" && $("#uc_36a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_36a_a").focus();
                return false;
            }
            else if ($('input[name=uc_37a]:checked').length <= 0 && ($("#uc_37a_v").is(":visible") == true
                || $("#uc_37a_b").is(":visible") == true
                || $("#uc_37a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#uc_37a_v").focus();
                return false;
            }
            else if ($("#uc_37a_a").val() == "" && $("#uc_37a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#uc_37a_a").focus();
                return false;
            }
            else if ($("#LA_18").val() == "" && $("#LA_18").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_18").focus();
                return false;
            }
            else if ($("#LA_19").val() == "" && $("#LA_19").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_19").focus();
                return false;
            }
            else if ($('input[name=LA_20a]:checked').length <= 0 && ($("#LA_20a_v").is(":visible") == true
                || $("#LA_20a_b").is(":visible") == true
                || $("#LA_20a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_20a_v").focus();
                return false;
            }
            else if ($("#LA_20a_a").val() == "" && $("#LA_20a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_20a_a").focus();
                return false;
            }
            else if ($('input[name=LA_20b]:checked').length <= 0 && ($("#LA_20b_a").is(":visible") == true
                || $("#LA_20b_b").is(":visible") == true
                || $("#LA_20b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_20b_a").focus();
                return false;
            }
            else if ($('input[name=LA_21a]:checked').length <= 0 && ($("#LA_21a_v").is(":visible") == true
                || $("#LA_21a_b").is(":visible") == true
                || $("#LA_21a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_21a_v").focus();
                return false;
            }
            else if ($("#LA_21a_a").val() == "" && $("#LA_21a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_21a_a").focus();
                return false;
            }
            else if ($('input[name=LA_21b]:checked').length <= 0 && ($("#LA_21b_a").is(":visible") == true
                || $("#LA_21b_b").is(":visible") == true
                || $("#LA_21b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_21b_a").focus();
                return false;
            }
            else if ($('input[name=LA_22a]:checked').length <= 0 && ($("#LA_22a_v").is(":visible") == true
                || $("#LA_22a_b").is(":visible") == true
                || $("#LA_22a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_22a_v").focus();
                return false;
            }
            else if ($("#LA_22a_a").val() == "" && $("#LA_22a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_22a_a").focus();
                return false;
            }
            else if ($('input[name=LA_22b]:checked').length <= 0 && ($("#LA_22b_a").is(":visible") == true
                || $("#LA_22b_b").is(":visible") == true
                || $("#LA_22b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_22b_a").focus();
                return false;
            }
            else if ($('input[name=LA_23a]:checked').length <= 0 && ($("#LA_23a_v").is(":visible") == true
                || $("#LA_23a_b").is(":visible") == true
                || $("#LA_23a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_23a_v").focus();
                return false;
            }
            else if ($("#LA_23a_a").val() == "" && $("#LA_23a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_23a_a").focus();
                return false;
            }
            else if ($('input[name=LA_23b]:checked').length <= 0 && ($("#LA_23b_a").is(":visible") == true
                || $("#LA_23b_b").is(":visible") == true
                || $("#LA_23b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_23b_a").focus();
                return false;
            }
            else if ($('input[name=LA_24a]:checked').length <= 0 && ($("#LA_24a_v").is(":visible") == true
                || $("#LA_24a_b").is(":visible") == true
                || $("#LA_24a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_24a_v").focus();
                return false;
            }
            else if ($("#LA_24a_a").val() == "" && $("#LA_24a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_24a_a").focus();
                return false;
            }
            else if ($('input[name=LA_24b]:checked').length <= 0 && ($("#LA_24b_a").is(":visible") == true
                || $("#LA_24b_b").is(":visible") == true
                || $("#LA_24b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_24b_a").focus();
                return false;
            }
            else if ($('input[name=LA_25a]:checked').length <= 0 && ($("#LA_25a_v").is(":visible") == true
                || $("#LA_25a_b").is(":visible") == true
                || $("#LA_25a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_25a_v").focus();
                return false;
            }
            else if ($("#LA_25a_a").val() == "" && $("#LA_25a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_25a_a").focus();
                return false;
            }
            else if ($('input[name=LA_25b]:checked').length <= 0 && ($("#LA_25b_a").is(":visible") == true
                || $("#LA_25b_b").is(":visible") == true
                || $("#LA_25b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_25b_a").focus();
                return false;
            }
            else if ($('input[name=LA_26a]:checked').length <= 0 && ($("#LA_26a_v").is(":visible") == true
                || $("#LA_26a_b").is(":visible") == true
                || $("#LA_26a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_26a_v").focus();
                return false;
            }
            else if ($("#LA_26a_a").val() == "" && $("#LA_26a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_26a_a").focus();
                return false;
            }
            else if ($('input[name=LA_26b]:checked').length <= 0 && ($("#LA_26b_a").is(":visible") == true
                || $("#LA_26b_b").is(":visible") == true
                || $("#LA_26b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_26b_a").focus();
                return false;
            }
            else if ($('input[name=LA_27a]:checked').length <= 0 && ($("#LA_27a_v").is(":visible") == true
                || $("#LA_27a_b").is(":visible") == true
                || $("#LA_27a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_27a_v").focus();
                return false;
            }
            else if ($("#LA_27a_a").val() == "" && $("#LA_27a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_27a_a").focus();
                return false;
            }
            else if ($('input[name=LA_27b]:checked').length <= 0 && ($("#LA_27b_a").is(":visible") == true
                || $("#LA_27b_b").is(":visible") == true
                || $("#LA_27b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_27b_a").focus();
                return false;
            }
            else if ($('input[name=LA_28a]:checked').length <= 0 && ($("#LA_28a_v").is(":visible") == true
                || $("#LA_28a_b").is(":visible") == true
                || $("#LA_28a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_28a_v").focus();
                return false;
            }
            else if ($("#LA_28a_a").val() == "" && $("#LA_28a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_28a_a").focus();
                return false;
            }
            else if ($('input[name=LA_28b]:checked').length <= 0 && ($("#LA_28b_a").is(":visible") == true
                || $("#LA_28b_b").is(":visible") == true
                || $("#LA_28b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_28b_a").focus();
                return false;
            }
            else if ($('input[name=LA_29a]:checked').length <= 0 && ($("#LA_29a_v").is(":visible") == true
                || $("#LA_29a_b").is(":visible") == true
                || $("#LA_29a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_29a_v").focus();
                return false;
            }
            else if ($("#LA_29a_a").val() == "" && $("#LA_29a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_29a_a").focus();
                return false;
            }
            else if ($('input[name=LA_29b]:checked').length <= 0 && ($("#LA_29b_a").is(":visible") == true
                || $("#LA_29b_b").is(":visible") == true
                || $("#LA_29b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_29b_a").focus();
                return false;
            }
            else if ($('input[name=LA_30a]:checked').length <= 0 && ($("#LA_30a_v").is(":visible") == true
                || $("#LA_30a_b").is(":visible") == true
                || $("#LA_30a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_30a_v").focus();
                return false;
            }
            else if ($("#LA_30a_a").val() == "" && $("#LA_30a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_30a_a").focus();
                return false;
            }
            else if ($('input[name=LA_30b]:checked').length <= 0 && ($("#LA_30b_a").is(":visible") == true
                || $("#LA_30b_b").is(":visible") == true
                || $("#LA_30b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_30b_a").focus();
                return false;
            }
            else if ($('input[name=LA_31a]:checked').length <= 0 && ($("#LA_31a_v").is(":visible") == true
                || $("#LA_31a_b").is(":visible") == true
                || $("#LA_31a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_31a_v").focus();
                return false;
            }
            else if ($("#LA_31a_a").val() == "" && $("#LA_31a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_31a_a").focus();
                return false;
            }
            else if ($('input[name=LA_31b]:checked').length <= 0 && ($("#LA_31b_a").is(":visible") == true
                || $("#LA_31b_b").is(":visible") == true
                || $("#LA_31b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_31b_a").focus();
                return false;
            }
            else if ($('input[name=LA_32a]:checked').length <= 0 && ($("#LA_32a_v").is(":visible") == true
                || $("#LA_32a_b").is(":visible") == true
                || $("#LA_32a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_32a_v").focus();
                return false;
            }
            else if ($("#LA_32a_a").val() == "" && $("#LA_32a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_32a_a").focus();
                return false;
            }
            else if ($('input[name=LA_32b]:checked').length <= 0 && ($("#LA_32b_a").is(":visible") == true
                || $("#LA_32b_b").is(":visible") == true
                || $("#LA_32b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_32b_a").focus();
                return false;
            }
            else if ($('input[name=LA_33a]:checked').length <= 0 && ($("#LA_33a_v").is(":visible") == true
                || $("#LA_33a_b").is(":visible") == true
                || $("#LA_33a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_33a_v").focus();
                return false;
            }
            else if ($("#LA_33a_a").val() == "" && $("#LA_33a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_33a_a").focus();
                return false;
            }
            else if ($('input[name=LA_33b]:checked').length <= 0 && ($("#LA_33b_a").is(":visible") == true
                || $("#LA_33b_b").is(":visible") == true
                || $("#LA_33b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_33b_a").focus();
                return false;
            }
            else if ($('input[name=LA_34a]:checked').length <= 0 && ($("#LA_34a_v").is(":visible") == true
                || $("#LA_34a_b").is(":visible") == true
                || $("#LA_34a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_34a_v").focus();
                return false;
            }
            else if ($("#LA_34a_a").val() == "" && $("#LA_34a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_34a_a").focus();
                return false;
            }
            else if ($('input[name=LA_34b]:checked').length <= 0 && ($("#LA_34b_a").is(":visible") == true
                || $("#LA_34b_b").is(":visible") == true
                || $("#LA_34b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_34b_a").focus();
                return false;
            }
            else if ($('input[name=LA_35a]:checked').length <= 0 && ($("#LA_35a_v").is(":visible") == true
                || $("#LA_35a_b").is(":visible") == true
                || $("#LA_35a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_35a_v").focus();
                return false;
            }
            else if ($("#LA_35a_a").val() == "" && $("#LA_35a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_35a_a").focus();
                return false;
            }
            else if ($('input[name=LA_35b]:checked').length <= 0 && ($("#LA_35b_a").is(":visible") == true
                || $("#LA_35b_b").is(":visible") == true
                || $("#LA_35b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_35b_a").focus();
                return false;
            }
            else if ($('input[name=LA_36a]:checked').length <= 0 && ($("#LA_36a_v").is(":visible") == true
                || $("#LA_36a_b").is(":visible") == true
                || $("#LA_36a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_36a_v").focus();
                return false;
            }
            else if ($("#LA_36a_a").val() == "" && $("#LA_36a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_36a_a").focus();
                return false;
            }
            else if ($('input[name=LA_36b]:checked').length <= 0 && ($("#LA_36b_a").is(":visible") == true
                || $("#LA_36b_b").is(":visible") == true
                || $("#LA_36b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_36b_a").focus();
                return false;
            }
            else if ($('input[name=LA_37a]:checked').length <= 0 && ($("#LA_37a_v").is(":visible") == true
                || $("#LA_37a_b").is(":visible") == true
                || $("#LA_37a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_37a_v").focus();
                return false;
            }
            else if ($("#LA_37a_a").val() == "" && $("#LA_37a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_37a_a").focus();
                return false;
            }
            else if ($('input[name=LA_37b]:checked').length <= 0 && ($("#LA_37b_a").is(":visible") == true
                || $("#LA_37b_b").is(":visible") == true
                || $("#LA_37b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_37b_a").focus();
                return false;
            }
            else if ($('input[name=LA_38a]:checked').length <= 0 && ($("#LA_38a_v").is(":visible") == true
                || $("#LA_38a_b").is(":visible") == true
                || $("#LA_38a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_38a_v").focus();
                return false;
            }
            else if ($("#LA_38a_a").val() == "" && $("#LA_38a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_38a_a").focus();
                return false;
            }
            else if ($('input[name=LA_38b]:checked').length <= 0 && ($("#LA_38b_a").is(":visible") == true
                || $("#LA_38b_b").is(":visible") == true
                || $("#LA_38b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_38b_a").focus();
                return false;
            }
            else if ($('input[name=LA_39a]:checked').length <= 0 && ($("#LA_39a_v").is(":visible") == true
                || $("#LA_39a_b").is(":visible") == true
                || $("#LA_39a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_39a_v").focus();
                return false;
            }
            else if ($("#LA_39a_a").val() == "" && $("#LA_39a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_39a_a").focus();
                return false;
            }
            else if ($('input[name=LA_39b]:checked').length <= 0 && ($("#LA_39b_a").is(":visible") == true
                || $("#LA_39b_b").is(":visible") == true
                || $("#LA_39b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_39b_a").focus();
                return false;
            }
            else if ($('input[name=LA_40a]:checked').length <= 0 && ($("#LA_40a_v").is(":visible") == true
                || $("#LA_40a_b").is(":visible") == true
                || $("#LA_40a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_40a_v").focus();
                return false;
            }
            else if ($("#LA_40a_a").val() == "" && $("#LA_40a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_40a_a").focus();
                return false;
            }
            else if ($('input[name=LA_40b]:checked').length <= 0 && ($("#LA_40b_a").is(":visible") == true
                || $("#LA_40b_b").is(":visible") == true
                || $("#LA_40b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_40b_a").focus();
                return false;
            }
            else if ($('input[name=LA_41a]:checked').length <= 0 && ($("#LA_41a_v").is(":visible") == true
                || $("#LA_41a_b").is(":visible") == true
                || $("#LA_41a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_41a_v").focus();
                return false;
            }
            else if ($("#LA_41a_a").val() == "" && $("#LA_41a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_41a_a").focus();
                return false;
            }
            else if ($('input[name=LA_41b]:checked').length <= 0 && ($("#LA_41b_a").is(":visible") == true
                || $("#LA_41b_b").is(":visible") == true
                || $("#LA_41b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_41b_a").focus();
                return false;
            }
            else if ($('input[name=LA_42a]:checked').length <= 0 && ($("#LA_42a_v").is(":visible") == true
                || $("#LA_42a_b").is(":visible") == true
                || $("#LA_42a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_42a_v").focus();
                return false;
            }
            else if ($("#LA_42a_a").val() == "" && $("#LA_42a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_42a_a").focus();
                return false;
            }
            else if ($('input[name=LA_42b]:checked').length <= 0 && ($("#LA_42b_a").is(":visible") == true
                || $("#LA_42b_b").is(":visible") == true
                || $("#LA_42b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_42b_a").focus();
                return false;
            }
            else if ($('input[name=LA_43a]:checked').length <= 0 && ($("#LA_43a_v").is(":visible") == true
                || $("#LA_43a_b").is(":visible") == true
                || $("#LA_43a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_43a_v").focus();
                return false;
            }
            else if ($("#LA_43a_a").val() == "" && $("#LA_43a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_43a_a").focus();
                return false;
            }
            else if ($('input[name=LA_43b]:checked').length <= 0 && ($("#LA_43b_a").is(":visible") == true
                || $("#LA_43b_b").is(":visible") == true
                || $("#LA_43b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_43b_a").focus();
                return false;
            }
            else if ($('input[name=LA_44a]:checked').length <= 0 && ($("#LA_44a_v").is(":visible") == true
                || $("#LA_44a_b").is(":visible") == true
                || $("#LA_44a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_44a_v").focus();
                return false;
            }
            else if ($("#LA_44a_a").val() == "" && $("#LA_44a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_44a_a").focus();
                return false;
            }
            else if ($('input[name=LA_44b]:checked').length <= 0 && ($("#LA_44b_a").is(":visible") == true
                || $("#LA_44b_b").is(":visible") == true
                || $("#LA_44b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_44b_a").focus();
                return false;
            }
            else if ($('input[name=LA_45a]:checked').length <= 0 && ($("#LA_45a_v").is(":visible") == true
                || $("#LA_45a_b").is(":visible") == true
                || $("#LA_45a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_45a_v").focus();
                return false;
            }
            else if ($("#LA_45a_a").val() == "" && $("#LA_45a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_45a_a").focus();
                return false;
            }
            else if ($('input[name=LA_45b]:checked').length <= 0 && ($("#LA_45b_a").is(":visible") == true
                || $("#LA_45b_b").is(":visible") == true
                || $("#LA_45b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_45b_a").focus();
                return false;
            }
            else if ($('input[name=LA_46a]:checked').length <= 0 && ($("#LA_46a_v").is(":visible") == true
                || $("#LA_46a_b").is(":visible") == true
                || $("#LA_46a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_46a_v").focus();
                return false;
            }
            else if ($("#LA_46a_a").val() == "" && $("#LA_46a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_46a_a").focus();
                return false;
            }
            else if ($('input[name=LA_46b]:checked').length <= 0 && ($("#LA_46b_a").is(":visible") == true
                || $("#LA_46b_b").is(":visible") == true
                || $("#LA_46b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_46b_a").focus();
                return false;
            }
            else if ($('input[name=LA_47a]:checked').length <= 0 && ($("#LA_47a_v").is(":visible") == true
                || $("#LA_47a_b").is(":visible") == true
                || $("#LA_47a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_47a_v").focus();
                return false;
            }
            else if ($("#LA_47a_a").val() == "" && $("#LA_47a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_47a_a").focus();
                return false;
            }
            else if ($('input[name=LA_47b]:checked').length <= 0 && ($("#LA_47b_a").is(":visible") == true
                || $("#LA_47b_b").is(":visible") == true
                || $("#LA_47b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_47b_a").focus();
                return false;
            }
            else if ($('input[name=LA_48a]:checked').length <= 0 && ($("#LA_48a_v").is(":visible") == true
                || $("#LA_48a_b").is(":visible") == true
                || $("#LA_48a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_48a_v").focus();
                return false;
            }
            else if ($("#LA_48a_a").val() == "" && $("#LA_48a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_48a_a").focus();
                return false;
            }
            else if ($('input[name=LA_48b]:checked').length <= 0 && ($("#LA_48b_a").is(":visible") == true
                || $("#LA_48b_b").is(":visible") == true
                || $("#LA_48b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_48b_a").focus();
                return false;
            }
            else if ($('input[name=LA_49a]:checked').length <= 0 && ($("#LA_49a_v").is(":visible") == true
                || $("#LA_49a_b").is(":visible") == true
                || $("#LA_49a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_49a_v").focus();
                return false;
            }
            else if ($("#LA_49a_a").val() == "" && $("#LA_49a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_49a_a").focus();
                return false;
            }
            else if ($('input[name=LA_49b]:checked').length <= 0 && ($("#LA_49b_a").is(":visible") == true
                || $("#LA_49b_b").is(":visible") == true
                || $("#LA_49b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_49b_a").focus();
                return false;
            }
            else if ($('input[name=LA_50a]:checked').length <= 0 && ($("#LA_50a_v").is(":visible") == true
                || $("#LA_50a_b").is(":visible") == true
                || $("#LA_50a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_50a_v").focus();
                return false;
            }
            else if ($("#LA_50a_a").val() == "" && $("#LA_50a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_50a_a").focus();
                return false;
            }
            else if ($('input[name=LA_50b]:checked').length <= 0 && ($("#LA_50b_a").is(":visible") == true
                || $("#LA_50b_b").is(":visible") == true
                || $("#LA_50b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_50b_a").focus();
                return false;
            }
            else if ($('input[name=LA_51a]:checked').length <= 0 && ($("#LA_51a_v").is(":visible") == true
                || $("#LA_51a_b").is(":visible") == true
                || $("#LA_51a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_51a_v").focus();
                return false;
            }
            else if ($("#LA_51a_a").val() == "" && $("#LA_51a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_51a_a").focus();
                return false;
            }
            else if ($('input[name=LA_51b]:checked').length <= 0 && ($("#LA_51b_a").is(":visible") == true
                || $("#LA_51b_b").is(":visible") == true
                || $("#LA_51b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_51b_a").focus();
                return false;
            }
            else if ($('input[name=LA_52a]:checked').length <= 0 && ($("#LA_52a_v").is(":visible") == true
                || $("#LA_52a_b").is(":visible") == true
                || $("#LA_52a_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_52a_v").focus();
                return false;
            }
            else if ($("#LA_52a_a").val() == "" && $("#LA_52a_a").is(":visible") == true) {
                alert("Please enter value ");
                $("#LA_52a_a").focus();
                return false;
            }
            else if ($('input[name=LA_52b]:checked').length <= 0 && ($("#LA_52b_a").is(":visible") == true
                || $("#LA_52b_b").is(":visible") == true
                || $("#LA_52b_c").is(":visible") == true
            )) {
                alert("Please select   ");
                $("#LA_52b_a").focus();
                return false;
            }

            return true;

        }

    </script>

    <style>
        .lblerr {
            color: #FF0000;
        }
    </style>

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
                            <li class="dropdown nav-item mega-dropdown d-none d-md-block"><%--<a class="dropdown-toggle nav-link" href="#" data-toggle="dropdown">Mega</a>--%>
                                <ul class="mega-dropdown-menu dropdown-menu row">
                                    <li class="col-md-4">
                                        <h6 class="dropdown-menu-header text-uppercase mb-1"><i class="ft-thumbs-up"></i>Get in touch</h6>
                                        <div class="form-body">
                                            <div class="row">
                                                <div class="col-sm-12 mb-1">
                                                    <button class="btn btn-danger float-right" type="button"><i class="ft-arrow-right"></i>Submit</button>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </li>
                            <li class="dropdown d-none d-md-block mr-1"><%--<a class="dropdown-toggle nav-link" id="apps-navbar-links" href="#" data-toggle="dropdown">Apps</a>--%>
                                <div class="dropdown-menu">
                                    <div class="arrow_box"><a class="dropdown-item" href="email-application.html"><i class="ft-user"></i>Email</a><a class="dropdown-item" href="chat-application.html"><i class="ft-mail"></i> Chat</a><a class="dropdown-item" href="project-summary.html"><i class="ft-briefcase"></i> Project Summary            </a><a class="dropdown-item" href="full-calender.html"><i class="ft-calendar"></i>Calendar1            </a></div>
                                </div>
                            </li>
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
                    <li class="nav-item mr-auto"><a class="navbar-brand" href="main.aspx">
                        <h3 class="brand-text">Sample Forms</h3>
                    </a></li>
                    <li class="nav-item d-md-none"><a class="nav-link close-navbar"><i class="ft-x"></i></a></li>
                </ul>
            </div>
            <div class="navigation-background"></div>
            <div class="main-menu-content">
                <ul class="navigation navigation-main" id="main-menu-navigation" data-menu="menu-navigation">
                    <li class="nav-item"><a href="sample_recv.aspx"><span style="font-family: Verdana">Sample Receiving</span></a>
                        <%--<ul class="menu-content">
                            <li><a class="active" href="form.aspx">Employee Entry</a>
                            </li>
                            <li><a class="menu-item" href="emplist.aspx">Employee List</a>
                            </li>
                            <li><a class="menu-item" href="form-switch.html">Change Password</a>
                            </li>
                        </ul>--%>
                    </li>
                    <li class="nav-item"><a href="sample_results.aspx"><span style="font-family: Verdana">Lab Results</span></a>
                    <li class="nav-item">
                        <asp:LinkButton runat="server" Style="font-family: Verdana" OnClick="Unnamed_Click">Logout</asp:LinkButton>
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

                                                    <h4 class="form-section"><i class="ft-clipboard"></i>Lab Results</h4>

                                                    <br />

                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Screening Number</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox runat="server" MaxLength="15" ID="la_sno" class="form-control" name="la_sno" onkeypress="return numeralsOnly(event);"></asp:TextBox>
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="la_sno" MaskType="Number" AutoComplete="false" ClearMaskOnLostFocus="false" Mask="99-9-9999" runat="server"></cc1:MaskedEditExtender>
                                                        </div>
                                                    </div>


                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Name of field site</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox runat="server" MaxLength="15" ID="la_fsite" class="form-control" name="la_fsite" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>


                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Randomization Number</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox runat="server" MaxLength="15" ID="la_rand" class="form-control" name="la_rand" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>


                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Specimen ID</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox runat="server" MaxLength="15" ID="la_spec" class="form-control" name="la_spec" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>


                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Name Of Child</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox runat="server" MaxLength="15" ID="la_name" class="form-control" name="la_name" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Gender</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox runat="server" MaxLength="15" ID="la_gen" class="form-control" name="la_gen" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>


                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Age</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox runat="server" MaxLength="15" ID="la_age" class="form-control" name="la_age" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>


                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="projectinput5">Sample Collect for</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox runat="server" MaxLength="15" ID="la_obj" class="form-control" name="la_obj" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>


                                                    <asp:Panel runat="server" ID="pnl_LA_01">
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Result reporting time NRL</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_01" class="form-control" name="LA_01"></asp:TextBox>
                                                                <script src="Scripts/timepicker/timepicki.js"></script>
                                                                <script>
                                                                    $('#<%=LA_01.ClientID%>').timepicki();
                                                                </script>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>


                                                    <asp:Panel runat="server" ID="pnl_LA_02">
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CRP result (mg/dL)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_02" class="form-control" name="LA_02" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>


                                                    <asp:Panel runat="server" ID="pnl_idrl">
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CBC Result</label>
                                                        </div>

                                                        <div class="form-group row">
                                                            <label class="col-md-3 label_heading" for="projectinput5">Complete Blood Count (CBC)</label>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Haemoglobin</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls1" GroupName="LA_03" name="LA_03_v" ID="LA_03_v" />
                                                                    <label for="input-radio-11">Haemoglobin Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls1" GroupName="LA_03" name="LA_03_b" ID="LA_03_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls1" GroupName="LA_03" name="LA_03_c" ID="LA_03_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_03_a">Haemoglobin g/dl</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_03_a" class="form-control" name="LA_03_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Haematocrit</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_04" name="LA_04_v" ID="LA_04_v" />
                                                                    <label for="input-radio-11">Haematocrit Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_04" name="LA_04_b" ID="LA_04_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_04" name="LA_04_c" ID="LA_04_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_04_a">Haematocrit %</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_04_a" class="form-control" name="LA_04_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">R.B.C</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_05" name="LA_05_v" ID="LA_05_v" />
                                                                    <label for="input-radio-11">R.B.C Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_05" name="LA_05_b" ID="LA_05_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_05" name="LA_05_c" ID="LA_05_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_05_a">R.B.C. x10E12/L</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_05_a" class="form-control" name="LA_05_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">M.C.V</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_06" name="LA_06_v" ID="LA_06_v" />
                                                                    <label for="input-radio-11">M.C.V Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_06" name="LA_06_b" ID="LA_06_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_06" name="LA_06_b" ID="LA_06_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_06_a">M.C.V. fL</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_06_a" class="form-control" name="LA_06_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">M.C.H</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_07" name="LA_07_v" ID="LA_07_v" />
                                                                    <label for="input-radio-11">M.C.H Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_07" name="LA_07_b" ID="LA_07_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_07" name="LA_07_c" ID="LA_07_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_07_a">M.C.H. pg</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_07_a" class="form-control" name="LA_07_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">M.C.H.C</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_08" name="LA_08_v" ID="LA_08_v" />
                                                                    <label for="input-radio-11">M.C.H.C Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_08" name="LA_08_b" ID="LA_08_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_08" name="LA_08_c" ID="LA_08_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_08_a">M.C.H.C g/dL</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_08_a" class="form-control" name="LA_08_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">R.D.W</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_09" name="LA_09_v" ID="LA_09_v" />
                                                                    <label for="input-radio-11">R.D.W Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_09" name="LA_09_b" ID="LA_09_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_09" name="LA_09_c" ID="LA_09_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_09_a">R.D.W %</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_09_a" class="form-control" name="LA_09_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">W.B.C Count</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_10" name="LA_10_v" ID="LA_10_v" />
                                                                    <label for="input-radio-11">W.B.C Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_10" name="LA_10_b" ID="LA_10_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_10" name="LA_10_c" ID="LA_10_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_10_a">W.B.C x10E9/L</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_10_a" class="form-control" name="LA_10_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Neutrophils</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_11" name="LA_11_v" ID="LA_11_v" />
                                                                    <label for="input-radio-11">Neutrophils Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_11" name="LA_11_b" ID="LA_11_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_11" name="LA_11_c" ID="LA_11_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_11_a">Neutrophils %</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_11_a" class="form-control" name="LA_11_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Lymphocytes</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_12" name="LA_12_v" ID="LA_12_v" />
                                                                    <label for="input-radio-11">Lymphocytes Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_12" name="LA_12_b" ID="LA_12_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_12" name="LA_12_c" ID="LA_12_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_12_a">Lymphocytes %</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_12_a" class="form-control" name="LA_12_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Eosinophils</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_13" name="LA_13_v" ID="LA_13_v" />
                                                                    <label for="input-radio-11">Eosinophils Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_13" name="LA_13_b" ID="LA_13_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_13" name="LA_13_c" ID="LA_13_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_13_a">Eosinophils %</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_13_a" class="form-control" name="LA_13_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Monocytes</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_14" name="LA_14_v" ID="LA_14_v" />
                                                                    <label for="input-radio-11">Monocytes Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_14" name="LA_14_b" ID="LA_14_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_14" name="LA_14_c" ID="LA_14_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_14_a">Monocytes %</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_14_a" class="form-control" name="LA_14_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Basophils</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_15" name="LA_15_v" ID="LA_15_v" />
                                                                    <label for="input-radio-11">Basophils Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_15" name="LA_15_b" ID="LA_15_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_15" name="LA_15_c" ID="LA_15_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_15_a">Basophils %</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_15_a" class="form-control" name="LA_15_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Platelets Count</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_16" name="LA_16_v" ID="LA_16_v" />
                                                                    <label for="input-radio-11">Platelets Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_16" name="LA_16_b" ID="LA_16_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_16" name="LA_16_c" ID="LA_16_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_16_a">Platelets x10E9/L</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_16_a" class="form-control" name="LA_16_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Peripheral Film</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_17" class="form-control" name="LA_17" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label_heading" for="projectinput5">Liver Profile Test (LFT)</label>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Serum Total Bilirubin</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_01" name="LF_01_v" ID="LF_01_v" />
                                                                    <label for="input-radio-11">Serum Total Bilirubin Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_01" name="LF_01_b" ID="LF_01_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_01" name="LF_01_c" ID="LF_01_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LF_01_a">Serum Total Bilirubin mg/dL</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LF_01_a" class="form-control" name="LF_01_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Serum Direct Bilirubin</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_02" name="LF_02_v" ID="LF_02_v" />
                                                                    <label for="input-radio-11">Serum Direct Bilirubin Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_02" name="LF_02_b" ID="LF_02_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_02" name="LF_02_c" ID="LF_02_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LF_02_a">Serum Direct Bilirubin mg/dL</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LF_02_a" class="form-control" name="LF_02_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Serum Indirect Bilirubin</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_03" name="LF_03_v" ID="LF_03_v" />
                                                                    <label for="input-radio-11">Serum Indirect Bilirubin Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_03" name="LF_03_b" ID="LF_03_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_03" name="LF_03_c" ID="LF_03_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LF_03_a">Serum Indirect Bilirubin mg/dL</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LF_03_a" class="form-control" name="LF_03_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Serum Gamma GT</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_04" name="LF_04_v" ID="LF_04_v" />
                                                                    <label for="input-radio-11">Serum Gamma GT Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_04" name="LF_04_b" ID="LF_04_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_04" name="LF_04_c" ID="LF_04_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LF_04_a">Serum Gamma GT IU/L</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LF_04_a" class="form-control" name="LF_04_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>






                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">SGPT (ALT)</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_05" name="LF_05_v" ID="LF_05_v" />
                                                                    <label for="input-radio-11">SGPT (ALT) Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_05" name="LF_05_b" ID="LF_05_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_05" name="LF_05_c" ID="LF_05_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LF_05_a">SGPT (ALT) IU/L</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LF_05_a" class="form-control" name="LF_05_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Serum Alkaline Phosphatase</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_06" name="LF_06_v" ID="LF_06_v" />
                                                                    <label for="input-radio-11">Serum Alkaline Phosphatase Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_06" name="LF_06_b" ID="LF_06_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_06" name="LF_06_c" ID="LF_06_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LF_06_a">Serum Alkaline Phosphatase IU/L</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LF_06_a" class="form-control" name="LF_06_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">SGOT (AST)</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_07" name="LF_07_v" ID="LF_07_v" />
                                                                    <label for="input-radio-11">SGOT (AST) Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_07" name="LF_07_b" ID="LF_07_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LF_07" name="LF_07_c" ID="LF_07_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LF_07_a">SGOT (AST) IU/L</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LF_07_a" class="form-control" name="LF_07_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label_heading" for="projectinput5">Renal Function Test</label>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Blood Urea Nitrogen</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="RF_01" name="RF_01_v" ID="RF_01_v" />
                                                                    <label for="input-radio-11">Blood Urea Nitrogen Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="RF_01" name="RF_01_b" ID="RF_01_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="RF_01" name="RF_01_c" ID="RF_01_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_RF_01_a">Blood Urea Nitrogen mg/dL</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="RF_01_a" class="form-control" name="RF_01_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>






                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">UREA=BUN x 2.14</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="RF_02" name="RF_02_v" ID="RF_02_v" />
                                                                    <label for="input-radio-11">UREA=BUN x 2.14 Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="RF_02" name="RF_02_b" ID="RF_02_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="RF_02" name="RF_02_c" ID="RF_02_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_RF_02_a">UREA=BUN x 2.14 mg/dL</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="RF_02_a" class="form-control" name="RF_02_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Serum Creatinine</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="RF_03" name="RF_03_v" ID="RF_03_v" />
                                                                    <label for="input-radio-11">Serum Creatinine Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="RF_03" name="RF_03_b" ID="RF_03_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="RF_03" name="RF_03_c" ID="RF_03_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_RF_03_a">Serum Creatinine mg/dL</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="RF_03_a" class="form-control" name="RF_03_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>






                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">e GFR</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="RF_04" name="RF_04_v" ID="RF_04_v" />
                                                                    <label for="input-radio-11">e GFR Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="RF_04" name="RF_04_b" ID="RF_04_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="RF_04" name="RF_04_c" ID="RF_04_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_RF_04_a">e GFR mL/min/1.73m2</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="RF_04_a" class="form-control" name="RF_04_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label_heading" for="projectinput5">Serum Electrolytes</label>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Serum Sodium</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="SE_01" name="SE_01_v" ID="SE_01_v" />
                                                                    <label for="input-radio-11">Serum Sodium Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="SE_01" name="SE_01_b" ID="SE_01_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="SE_01" name="SE_01_c" ID="SE_01_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_SE_01_a">Serum Sodium mmol/L</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="SE_01_a" class="form-control" name="SE_01_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>






                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Serum Potassium</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="SE_02" name="SE_02_v" ID="SE_02_v" />
                                                                    <label for="input-radio-11">Serum Potassium Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="SE_02" name="SE_02_b" ID="SE_02_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="SE_02" name="SE_02_c" ID="SE_02_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_SE_02_a">Serum Potassium mmol/L</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="SE_02_a" class="form-control" name="SE_02_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Serum Chloride</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="SE_03" name="SE_03_v" ID="SE_03_v" />
                                                                    <label for="input-radio-11">Serum Chloride Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="SE_03" name="SE_03_b" ID="SE_03_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="SE_03" name="SE_03_c" ID="SE_03_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_SE_03_a">Serum Chloride mmol/L</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="SE_03_a" class="form-control" name="SE_03_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>






                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Serum Bicarbonate</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="SE_04" name="SE_04_v" ID="SE_04_v" />
                                                                    <label for="input-radio-11">Serum Bicarbonate Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="SE_04" name="SE_04_b" ID="SE_04_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="SE_04" name="SE_04_c" ID="SE_04_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_SE_04_a">Serum Bicarbonate mmol/L</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="SE_04_a" class="form-control" name="SE_04_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label_heading" for="projectinput5">CSF Detail Report</label>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CSF GLUCOSE</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_01" name="CS_01_v" ID="CS_01_v" />
                                                                    <label for="input-radio-11">CSF GLUCOSE Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_01" name="CS_01_b" ID="CS_01_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_01" name="CS_01_c" ID="CS_01_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_CS_01_a">CSF GLUCOSE mg/dL</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="CS_01_a" class="form-control" name="CS_01_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>






                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CSF CHLORIDE</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_02" name="CS_02_v" ID="CS_02_v" />
                                                                    <label for="input-radio-11">CSF CHLORIDE Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_02" name="CS_02_b" ID="CS_02_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_02" name="CS_02_c" ID="CS_02_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_CS_02_a">CSF CHLORIDE mEq/L</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="CS_02_a" class="form-control" name="CS_02_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>







                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CSF PROTEIN</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_03" name="CS_03_v" ID="CS_03_v" />
                                                                    <label for="input-radio-11">CSF PROTEIN Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_03" name="CS_03_b" ID="CS_03_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_03" name="CS_03_c" ID="CS_03_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_CS_03_a">CSF PROTEIN mg/dL</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="CS_03_a" class="form-control" name="CS_03_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CSF RBC</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_04" name="CS_04_v" ID="CS_04_v" />
                                                                    <label for="input-radio-11">CSF RBC Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_04" name="CS_04_b" ID="CS_04_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_04" name="CS_04_c" ID="CS_04_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_CS_04_a">CSF RBC x10E12/L</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="CS_04_a" class="form-control" name="CS_04_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CSF WBC</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_05" name="CS_05_v" ID="CS_05_v" />
                                                                    <label for="input-radio-11">CSF WBC Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_05" name="CS_05_b" ID="CS_05_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_05" name="CS_05_c" ID="CS_05_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_CS_05_a">CSF WBC x10E9/L</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="CS_05_a" class="form-control" name="CS_05_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CSF NEUTROPHILS</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_06" name="CS_06_v" ID="CS_06_v" />
                                                                    <label for="input-radio-11">CSF NEUTROPHILS Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_06" name="CS_06_b" ID="CS_06_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_06" name="CS_06_c" ID="CS_06_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_CS_06_a">CSF NEUTROPHILS (%)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="CS_06_a" class="form-control" name="CS_06_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CSF LYMPHOCYTES</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_07" name="CS_07_v" ID="CS_07_v" />
                                                                    <label for="input-radio-11">CSF LYMPHOCYTES Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_07" name="CS_07_b" ID="CS_07_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_07" name="CS_07_c" ID="CS_07_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_CS_07_a">CSF LYMPHOCYTES (%)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="CS_07_a" class="form-control" name="CS_07_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">CSF PUS CELLS</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_08" name="CS_08_v" ID="CS_08_v" />
                                                                    <label for="input-radio-11">CSF PUS CELLS Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_08" name="CS_08_b" ID="CS_08_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_08" name="CS_08_c" ID="CS_08_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_CS_08_a">CSF PUS CELLS mm3</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="CS_08_a" class="form-control" name="CS_08_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">GRAM STAIN RESULT</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_09" name="CS_09_v" ID="CS_09_v" />
                                                                    <label for="input-radio-11">GRAM STAIN RESULT Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_09" name="CS_09_b" ID="CS_09_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_09" name="CS_09_c" ID="CS_09_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_CS_09_a">GRAM STAIN RESULT</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="CS_09_a" class="form-control" name="CS_09_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">WET PREPARATION FOR NAEGLERIA</label>
                                                            <div class="col-md-9">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_10" name="CS_10_v" ID="CS_10_v" />
                                                                    <label for="input-radio-11">WET PREPARATION FOR NAEGLERIA Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_10" name="CS_10_b" ID="CS_10_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="CS_10" name="CS_10_c" ID="CS_10_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_CS_10_a">WET PREPARATION FOR NAEGLERIA (Seen / Not Seen)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="CS_10_a" class="form-control" name="CS_10_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label_heading" for="projectinput5">Urine Detail Report</label>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Color</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_01" name="UR_01_v" ID="UR_01_v" />
                                                                    <label for="input-radio-11">Color Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_01" name="UR_01_b" ID="UR_01_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_01" name="UR_01_c" ID="UR_01_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_01_a">Color</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="UR_01_a" class="form-control" name="UR_01_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Appearance</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_02" name="UR_02_v" ID="UR_02_v" />
                                                                    <label for="input-radio-11">Appearance Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_02" name="UR_02_b" ID="UR_02_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_02" name="UR_02_c" ID="UR_02_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_02_a">Appearance</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="UR_02_a" class="form-control" name="UR_02_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Specific Gravity</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_03" name="UR_03_v" ID="UR_03_v" />
                                                                    <label for="input-radio-11">Specific Gravity Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_03" name="UR_03_b" ID="UR_03_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_03" name="UR_03_c" ID="UR_03_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_03_a">Specific Gravity</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="UR_03_a" class="form-control" name="UR_03_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">pH</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_04" name="UR_04_v" ID="UR_04_v" />
                                                                    <label for="input-radio-11">pH Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_04" name="UR_04_b" ID="UR_04_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_04" name="UR_04_c" ID="UR_04_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_04_a">pH</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="UR_04_a" class="form-control" name="UR_04_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Glucose</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_04a" name="UR_04a_v" ID="UR_04a_v" />
                                                                    <label for="input-radio-11">Glucose Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_04a" name="UR_04a_b" ID="UR_04a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_04a" name="UR_04a_c" ID="UR_04a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_04a_a">Glucose mg/dL</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="UR_04a_a" class="form-control" name="UR_04a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Protein</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_05" name="UR_05_v" ID="UR_05_v" />
                                                                    <label for="input-radio-11">Protein Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_05" name="UR_05_b" ID="UR_05_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_05" name="UR_05_c" ID="UR_05_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_05_a">Protein g/L</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="UR_05_a" class="form-control" name="UR_05_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>







                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Ketone</label>
                                                            <div class="col-md-6 col-sm-21">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_06" name="UR_06_v" ID="UR_06_v" />
                                                                    <label for="input-radio-21">Ketone Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_06" name="UR_06_b" ID="UR_06_b" />
                                                                    <label for="input-radio-21">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_06" name="UR_06_c" ID="UR_06_c" />
                                                                    <label for="input-radio-21">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_06_a">Ketone mmol/L</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="21" ID="UR_06_a" class="form-control" name="UR_06_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Urobilinogen</label>
                                                            <div class="col-md-6 col-sm-21">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_07" name="UR_07_v" ID="UR_07_v" />
                                                                    <label for="input-radio-21">Urobilinogen Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_07" name="UR_07_b" ID="UR_07_b" />
                                                                    <label for="input-radio-21">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_07" name="UR_07_c" ID="UR_07_c" />
                                                                    <label for="input-radio-21">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_07_a">Urobilinogen µmol/L</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="21" ID="UR_07_a" class="form-control" name="UR_07_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>






                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Bilirubin</label>
                                                            <div class="col-md-6 col-sm-21">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_08" name="UR_08_v" ID="UR_08_v" />
                                                                    <label for="input-radio-21">Bilirubin Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_08" name="UR_08_b" ID="UR_08_b" />
                                                                    <label for="input-radio-21">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_08" name="UR_08_c" ID="UR_08_c" />
                                                                    <label for="input-radio-21">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_08_a">Bilirubin</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="21" ID="UR_08_a" class="form-control" name="UR_08_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>







                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Hemoglobin</label>
                                                            <div class="col-md-6 col-sm-21">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_10" name="UR_10_v" ID="UR_10_v" />
                                                                    <label for="input-radio-21">Platelets Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_10" name="UR_10_b" ID="UR_10_b" />
                                                                    <label for="input-radio-21">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_10" name="UR_10_c" ID="UR_10_c" />
                                                                    <label for="input-radio-21">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_10_a">Hemoglobin</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="21" ID="UR_10_a" class="form-control" name="UR_10_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>







                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Nitrite</label>
                                                            <div class="col-md-6 col-sm-21">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_11" name="UR_11_v" ID="UR_11_v" />
                                                                    <label for="input-radio-21">Nitrite Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_11" name="UR_11_b" ID="UR_11_b" />
                                                                    <label for="input-radio-21">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_11" name="UR_11_c" ID="UR_11_c" />
                                                                    <label for="input-radio-21">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_11_a">Nitrite x21E9/L</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="21" ID="UR_11_a" class="form-control" name="UR_11_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Leucocyte Esterase</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_12" name="UR_12_v" ID="UR_12_v" />
                                                                    <label for="input-radio-12">Leucocyte Esterase Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_12" name="UR_12_b" ID="UR_12_b" />
                                                                    <label for="input-radio-12">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_12" name="UR_12_c" ID="UR_12_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_12_a">Leucocyte Esterase uL</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="UR_12_a" class="form-control" name="UR_12_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Red Blood Cells</label>
                                                            <div class="col-md-6 col-sm-13">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_13" name="UR_13_v" ID="UR_13_v" />
                                                                    <label for="input-radio-13">Red Blood Cells Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_13" name="UR_13_b" ID="UR_13_b" />
                                                                    <label for="input-radio-13">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_13" name="UR_13_c" ID="UR_13_c" />
                                                                    <label for="input-radio-13">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_13_a">Red Blood Cells HPF</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="UR_13_a" class="form-control" name="UR_13_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Leucocytes</label>
                                                            <div class="col-md-6 col-sm-14">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_14" name="UR_14_v" ID="UR_14_v" />
                                                                    <label for="input-radio-14">Leucocytes Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_14" name="UR_14_b" ID="UR_14_b" />
                                                                    <label for="input-radio-14">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_14" name="UR_14_c" ID="UR_14_c" />
                                                                    <label for="input-radio-14">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_14_a">Leucocytes HPF</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="UR_14_a" class="form-control" name="UR_14_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Squamous Epith Cell</label>
                                                            <div class="col-md-6 col-sm-15">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_15" name="UR_15_v" ID="UR_15_v" />
                                                                    <label for="input-radio-15">Squamous Epith Cell Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_15" name="UR_15_b" ID="UR_15_b" />
                                                                    <label for="input-radio-15">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_15" name="UR_15_c" ID="UR_15_c" />
                                                                    <label for="input-radio-15">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_15_a">Squamous Epith Cell HPF</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="UR_15_a" class="form-control" name="UR_15_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Non Squamous Epith Cell</label>
                                                            <div class="col-md-6 col-sm-16">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_16" name="UR_16_v" ID="UR_16_v" />
                                                                    <label for="input-radio-16">Non Squamous Epith Cell Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_16" name="UR_16_b" ID="UR_16_b" />
                                                                    <label for="input-radio-16">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_16" name="UR_16_c" ID="UR_16_c" />
                                                                    <label for="input-radio-16">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_16_a">Non Squamous Epith Cell HPF</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="16" ID="UR_16_a" class="form-control" name="UR_16_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Bacteria</label>
                                                            <div class="col-md-6 col-sm-17">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_17" name="UR_17_v" ID="UR_17_v" />
                                                                    <label for="input-radio-17">Bacteria Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_17" name="UR_17_b" ID="UR_17_b" />
                                                                    <label for="input-radio-17">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_17" name="UR_17_c" ID="UR_17_c" />
                                                                    <label for="input-radio-17">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_17_a">Bacteria HPF</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="17" ID="UR_17_a" class="form-control" name="UR_17_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Yeast</label>
                                                            <div class="col-md-6 col-sm-18">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_18" name="UR_18_v" ID="UR_18_v" />
                                                                    <label for="input-radio-18">Yeast Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_18" name="UR_18_b" ID="UR_18_b" />
                                                                    <label for="input-radio-18">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_18" name="UR_18_c" ID="UR_18_c" />
                                                                    <label for="input-radio-18">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_18_a">Yeast HPF</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="18" ID="UR_18_a" class="form-control" name="UR_18_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Cast</label>
                                                            <div class="col-md-6 col-sm-19">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_19" name="UR_19_v" ID="UR_19_v" />
                                                                    <label for="input-radio-19">Cast Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_19" name="UR_19_b" ID="UR_19_b" />
                                                                    <label for="input-radio-19">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_19" name="UR_19_c" ID="UR_19_c" />
                                                                    <label for="input-radio-19">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_19_a">Cast HPF</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="19" ID="UR_19_a" class="form-control" name="UR_19_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Crystals</label>
                                                            <div class="col-md-6 col-sm-20">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_20" name="UR_20_v" ID="UR_20_v" />
                                                                    <label for="input-radio-20">Crystals Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_20" name="UR_20_b" ID="UR_20_b" />
                                                                    <label for="input-radio-20">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_20" name="UR_20_c" ID="UR_20_c" />
                                                                    <label for="input-radio-20">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_20_a">Crystals HPF</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="20" ID="UR_20_a" class="form-control" name="UR_20_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Mucus</label>
                                                            <div class="col-md-6 col-sm-21">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_21" name="UR_21_v" ID="UR_21_v" />
                                                                    <label for="input-radio-21">Mucus Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_21" name="UR_21_b" ID="UR_21_b" />
                                                                    <label for="input-radio-21">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="UR_21" name="UR_21_c" ID="UR_21_c" />
                                                                    <label for="input-radio-21">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_UR_21_a">Mucus</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="21" ID="UR_21_a" class="form-control" name="UR_21_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label_heading" for="projectinput5">Urine Culture and Sensitivity (Urine C/S)</label>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Urine C/S Result</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_01a" name="uc_01_a" ID="uc_01_a" />
                                                                    <label for="input-radio-11">Uropathogen Isolated</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_01a" name="uc_01_b" ID="uc_01_b" />
                                                                    <label for="input-radio-11">No Uropathogen Isolated</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Amoxicillin/ Clavulanic Acid 2:1 (AMC) 30ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_02a" name="uc_02a_v" ID="uc_02a_v" />
                                                                    <label for="input-radio-11">Amoxicillin/ Clavulanic Acid 2:1 (AMC) 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_02a" name="uc_02a_b" ID="uc_02a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_02a" name="uc_02a_c" ID="uc_02a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_02a_a">Zone Diameter (mm) Amoxicillin/ Clavulanic Acid 2:1 (AMC) 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="uc_02a_a" class="form-control" name="uc_02a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_02b">Amoxicillin/Clavulanic Acid 2:1 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_02b" name="uc_02b_a" ID="uc_02b_a" />
                                                                    <label for="input-radio-11" id="lbl_uc_02b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_02b" name="uc_02b_b" ID="uc_02b_b" />
                                                                    <label for="input-radio-11" id="lbl_uc_02b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_02b" name="uc_02b_c" ID="uc_02b_c" />
                                                                    <label for="input-radio-12" id="lbl_uc_02b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Ampicillin 10ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_03a" name="uc_03a_v" ID="uc_03a_v" />
                                                                    <label for="input-radio-11">Ampicillin 10ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_03a" name="uc_03a_b" ID="uc_03a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_03a" name="uc_03a_c" ID="uc_03a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_03a_a">Zone Diameter (mm) Ampicillin 10ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="uc_03a_a" class="form-control" name="uc_03a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_03b">Ampicillin 10ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_03b" name="uc_03b_a" ID="uc_03b_a" />
                                                                    <label for="input-radio-11" id="lbl_uc_03b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_03b" name="uc_03b_b" ID="uc_03b_b" />
                                                                    <label for="input-radio-11" id="lbl_uc_03b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_03b" name="uc_03b_c" ID="uc_03b_c" />
                                                                    <label for="input-radio-12" id="lbl_uc_03b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Amikacin 30ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_04a" name="uc_04a_v" ID="uc_04a_v" />
                                                                    <label for="input-radio-11">Amikacin 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_04a" name="uc_04a_b" ID="uc_04a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_04a" name="uc_04a_c" ID="uc_04a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_04a_a">Zone Diameter (mm) Amikacin 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="uc_04a_a" class="form-control" name="uc_04a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_04b">Amikacin 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_04b" name="uc_04b_a" ID="uc_04b_a" />
                                                                    <label for="input-radio-11" id="lbl_uc_04b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_04b" name="uc_04b_b" ID="uc_04b_b" />
                                                                    <label for="input-radio-11" id="lbl_uc_04b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_04b" name="uc_04b_c" ID="uc_04b_c" />
                                                                    <label for="input-radio-12" id="lbl_uc_04b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Aztreonam 30ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_05a" name="uc_05a_v" ID="uc_05a_v" />
                                                                    <label for="input-radio-11">Aztreonam 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_05a" name="uc_05a_b" ID="uc_05a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_05a" name="uc_05a_c" ID="uc_05a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_05a_a">Zone Diameter (mm) Aztreonam 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="uc_05a_a" class="form-control" name="uc_05a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_05b">Aztreonam 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_05b" name="uc_05b_a" ID="uc_05b_a" />
                                                                    <label for="input-radio-11" id="lbl_uc_05b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_05b" name="uc_05b_b" ID="uc_05b_b" />
                                                                    <label for="input-radio-11" id="lbl_uc_05b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_05b" name="uc_05b_c" ID="uc_05b_c" />
                                                                    <label for="input-radio-12" id="lbl_uc_05b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Azithromycin 15ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_06a" name="uc_06a_v" ID="uc_06a_v" />
                                                                    <label for="input-radio-11">Azithromycin 15ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_06a" name="uc_06a_b" ID="uc_06a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_06a" name="uc_06a_c" ID="uc_06a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_06a_a">Zone Diameter (mm) Azithromycin 15ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="uc_06a_a" class="form-control" name="uc_06a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_06b">Azithromycin 15ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_06b" name="uc_06b_a" ID="uc_06b_a" />
                                                                    <label for="input-radio-11" id="lbl_uc_06b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_06b" name="uc_06b_b" ID="uc_06b_b" />
                                                                    <label for="input-radio-11" id="lbl_uc_06b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_06b" name="uc_06b_c" ID="uc_06b_c" />
                                                                    <label for="input-radio-12" id="lbl_uc_06b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Chloramphenicol 30ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_07a" name="uc_07a_v" ID="uc_07a_v" />
                                                                    <label for="input-radio-11">Chloramphenicol 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_07a" name="uc_07a_b" ID="uc_07a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_07a" name="uc_07a_c" ID="uc_07a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_07a_a">Zone Diameter (mm) Chloramphenicol 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="uc_07a_a" class="form-control" name="uc_07a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_07b">Chloramphenicol 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_07b" name="uc_07b_a" ID="uc_07b_a" />
                                                                    <label for="input-radio-11" id="lbl_uc_07b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_07b" name="uc_07b_b" ID="uc_07b_b" />
                                                                    <label for="input-radio-11" id="lbl_uc_07b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_07b" name="uc_07b_c" ID="uc_07b_c" />
                                                                    <label for="input-radio-12" id="lbl_uc_07b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Ceftazidime 30ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_08a" name="uc_08a_v" ID="uc_08a_v" />
                                                                    <label for="input-radio-11">Ceftazidime 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_08a" name="uc_08a_b" ID="uc_08a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_08a" name="uc_08a_c" ID="uc_08a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_08a_a">Zone Diameter (mm) Ceftazidime 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="uc_08a_a" class="form-control" name="uc_08a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_08b">Ceftazidime 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_08b" name="uc_08b_a" ID="uc_08b_a" />
                                                                    <label for="input-radio-11" id="lbl_uc_08b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_08b" name="uc_08b_b" ID="uc_08b_b" />
                                                                    <label for="input-radio-11" id="lbl_uc_08b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_08b" name="uc_08b_c" ID="uc_08b_c" />
                                                                    <label for="input-radio-12" id="lbl_uc_08b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Cefixime 5ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_09a" name="uc_09a_v" ID="uc_09a_v" />
                                                                    <label for="input-radio-11">Cefixime 5ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_09a" name="uc_09a_b" ID="uc_09a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_09a" name="uc_09a_c" ID="uc_09a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_09a_a">Zone Diameter (mm) Cefixime 5ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="uc_09a_a" class="form-control" name="uc_09a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_09b">Cefixime 5ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_09b" name="uc_09b_a" ID="uc_09b_a" />
                                                                    <label for="input-radio-11" id="lbl_uc_09b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_09b" name="uc_09b_b" ID="uc_09b_b" />
                                                                    <label for="input-radio-11" id="lbl_uc_09b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_09b" name="uc_09b_c" ID="uc_09b_c" />
                                                                    <label for="input-radio-12" id="lbl_uc_09b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Ciprofloxacin 5ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_10a" name="uc_10a_v" ID="uc_10a_v" />
                                                                    <label for="input-radio-11">Ciprofloxacin 5ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_10a" name="uc_10a_b" ID="uc_10a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_10a" name="uc_10a_c" ID="uc_10a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_10a_a">Zone Diameter (mm) Ciprofloxacin 5ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="uc_10a_a" class="form-control" name="uc_10a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_10b">Ciprofloxacin 5ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_10b" name="uc_10b_a" ID="uc_10b_a" />
                                                                    <label for="input-radio-11" id="lbl_uc_10b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_10b" name="uc_10b_b" ID="uc_10b_b" />
                                                                    <label for="input-radio-11" id="lbl_uc_10b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_10b" name="uc_10b_c" ID="uc_10b_c" />
                                                                    <label for="input-radio-12" id="lbl_uc_10b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Gentamicin 10ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_11a" name="uc_11a_v" ID="uc_11a_v" />
                                                                    <label for="input-radio-11">Gentamicin 10ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_11a" name="uc_11a_b" ID="uc_11a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_11a" name="uc_11a_c" ID="uc_11a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_11a_a">Zone Diameter (mm) Gentamicin 10ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="uc_11a_a" class="form-control" name="uc_11a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_11b">Gentamicin 10ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_11b" name="uc_11b_a" ID="uc_11b_a" />
                                                                    <label for="input-radio-11" id="lbl_uc_11b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_11b" name="uc_11b_b" ID="uc_11b_b" />
                                                                    <label for="input-radio-11" id="lbl_uc_11b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_11b" name="uc_11b_c" ID="uc_11b_c" />
                                                                    <label for="input-radio-12" id="lbl_uc_11b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Gentamicin 120ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_12a" name="uc_12a_v" ID="uc_12a_v" />
                                                                    <label for="input-radio-12">Gentamicin 120ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_12a" name="uc_12a_b" ID="uc_12a_b" />
                                                                    <label for="input-radio-12">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_12a" name="uc_12a_c" ID="uc_12a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_12a_a">Zone Diameter (mm) Gentamicin 120ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="uc_12a_a" class="form-control" name="uc_12a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_12b">Gentamicin 120ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_12b" name="uc_12b_a" ID="uc_12b_a" />
                                                                    <label for="input-radio-12" id="lbl_uc_12b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_12b" name="uc_12b_b" ID="uc_12b_b" />
                                                                    <label for="input-radio-12" id="lbl_uc_12b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_12b" name="uc_12b_c" ID="uc_12b_c" />
                                                                    <label for="input-radio-12" id="lbl_uc_12b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Ceftriaxone 30ug</label>
                                                            <div class="col-md-6 col-sm-13">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_13a" name="uc_13a_v" ID="uc_13a_v" />
                                                                    <label for="input-radio-13">Ceftriaxone 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_13a" name="uc_13a_b" ID="uc_13a_b" />
                                                                    <label for="input-radio-13">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_13a" name="uc_13a_c" ID="uc_13a_c" />
                                                                    <label for="input-radio-13">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_13a_a">Zone Diameter (mm) Ceftriaxone 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="uc_13a_a" class="form-control" name="uc_13a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_13b">Ceftriaxone 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-13">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_13b" name="uc_13b_a" ID="uc_13b_a" />
                                                                    <label for="input-radio-13" id="lbl_uc_13b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_13b" name="uc_13b_b" ID="uc_13b_b" />
                                                                    <label for="input-radio-13" id="lbl_uc_13b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_13b" name="uc_13b_c" ID="uc_13b_c" />
                                                                    <label for="input-radio-13" id="lbl_uc_13b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Cefuroxime 30ug</label>
                                                            <div class="col-md-6 col-sm-14">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_14a" name="uc_14a_v" ID="uc_14a_v" />
                                                                    <label for="input-radio-14">Cefuroxime 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_14a" name="uc_14a_b" ID="uc_14a_b" />
                                                                    <label for="input-radio-14">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_14a" name="uc_14a_c" ID="uc_14a_c" />
                                                                    <label for="input-radio-14">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_14a_a">Zone Diameter (mm) Cefuroxime 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="uc_14a_a" class="form-control" name="uc_14a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_14b">Cefuroxime 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-14">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_14b" name="uc_14b_a" ID="uc_14b_a" />
                                                                    <label for="input-radio-14" id="lbl_uc_14b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_14b" name="uc_14b_b" ID="uc_14b_b" />
                                                                    <label for="input-radio-14" id="lbl_uc_14b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_14b" name="uc_14b_c" ID="uc_14b_c" />
                                                                    <label for="input-radio-14" id="lbl_uc_14b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Clindamycin 2ug</label>
                                                            <div class="col-md-6 col-sm-15">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_15a" name="uc_15a_v" ID="uc_15a_v" />
                                                                    <label for="input-radio-15">Clindamycin 2ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_15a" name="uc_15a_b" ID="uc_15a_b" />
                                                                    <label for="input-radio-15">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_15a" name="uc_15a_c" ID="uc_15a_c" />
                                                                    <label for="input-radio-15">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_15a_a">Zone Diameter (mm) Clindamycin 2ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="uc_15a_a" class="form-control" name="uc_15a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_15b">Clindamycin 2ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-15">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_15b" name="uc_15b_a" ID="uc_15b_a" />
                                                                    <label for="input-radio-15" id="lbl_uc_15b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_15b" name="uc_15b_b" ID="uc_15b_b" />
                                                                    <label for="input-radio-15" id="lbl_uc_15b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_15b" name="uc_15b_c" ID="uc_15b_c" />
                                                                    <label for="input-radio-15" id="lbl_uc_15b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Erythromycin 15ug</label>
                                                            <div class="col-md-6 col-sm-16">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_16a" name="uc_16a_v" ID="uc_16a_v" />
                                                                    <label for="input-radio-16">Erythromycin 15ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_16a" name="uc_16a_b" ID="uc_16a_b" />
                                                                    <label for="input-radio-16">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_16a" name="uc_16a_c" ID="uc_16a_c" />
                                                                    <label for="input-radio-16">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_16a_a">Zone Diameter (mm) Erythromycin 15ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="16" ID="uc_16a_a" class="form-control" name="uc_16a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_16b">Erythromycin 15ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-16">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_16b" name="uc_16b_a" ID="uc_16b_a" />
                                                                    <label for="input-radio-16" id="lbl_uc_16b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_16b" name="uc_16b_b" ID="uc_16b_b" />
                                                                    <label for="input-radio-16" id="lbl_uc_16b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_16b" name="uc_16b_c" ID="uc_16b_c" />
                                                                    <label for="input-radio-16" id="lbl_uc_16b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Cefipime 30ug</label>
                                                            <div class="col-md-6 col-sm-17">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_17a" name="uc_17a_v" ID="uc_17a_v" />
                                                                    <label for="input-radio-17">Cefipime 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_17a" name="uc_17a_b" ID="uc_17a_b" />
                                                                    <label for="input-radio-17">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_17a" name="uc_17a_c" ID="uc_17a_c" />
                                                                    <label for="input-radio-17">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_17a_a">Zone Diameter (mm) Cefipime 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="17" ID="uc_17a_a" class="form-control" name="uc_17a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_17b">Cefipime 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-17">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_17b" name="uc_17b_a" ID="uc_17b_a" />
                                                                    <label for="input-radio-17" id="lbl_uc_17b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_17b" name="uc_17b_b" ID="uc_17b_b" />
                                                                    <label for="input-radio-17" id="lbl_uc_17b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_17b" name="uc_17b_c" ID="uc_17b_c" />
                                                                    <label for="input-radio-17" id="lbl_uc_17b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Cefoxitin 30ug</label>
                                                            <div class="col-md-6 col-sm-18">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_18a" name="uc_18a_v" ID="uc_18a_v" />
                                                                    <label for="input-radio-18">Cefoxitin 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_18a" name="uc_18a_b" ID="uc_18a_b" />
                                                                    <label for="input-radio-18">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_18a" name="uc_18a_c" ID="uc_18a_c" />
                                                                    <label for="input-radio-18">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_18a_a">Zone Diameter (mm) Cefoxitin 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="18" ID="uc_18a_a" class="form-control" name="uc_18a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_18b">Cefoxitin 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-18">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_18b" name="uc_18b_a" ID="uc_18b_a" />
                                                                    <label for="input-radio-18" id="lbl_uc_18b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_18b" name="uc_18b_b" ID="uc_18b_b" />
                                                                    <label for="input-radio-18" id="lbl_uc_18b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_18b" name="uc_18b_c" ID="uc_18b_c" />
                                                                    <label for="input-radio-18" id="lbl_uc_18b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Fusidic Acid 10ug</label>
                                                            <div class="col-md-6 col-sm-19">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_19a" name="uc_19a_v" ID="uc_19a_v" />
                                                                    <label for="input-radio-19">Fusidic Acid 10ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_19a" name="uc_19a_b" ID="uc_19a_b" />
                                                                    <label for="input-radio-19">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_19a" name="uc_19a_c" ID="uc_19a_c" />
                                                                    <label for="input-radio-19">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_19a_a">Zone Diameter (mm) Fusidic Acid 10ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="19" ID="uc_19a_a" class="form-control" name="uc_19a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_19b">Fusidic Acid 10ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-19">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_19b" name="uc_19b_a" ID="uc_19b_a" />
                                                                    <label for="input-radio-19" id="lbl_uc_19b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_19b" name="uc_19b_b" ID="uc_19b_b" />
                                                                    <label for="input-radio-19" id="lbl_uc_19b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_19b" name="uc_19b_c" ID="uc_19b_c" />
                                                                    <label for="input-radio-19" id="lbl_uc_19b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Imipenem 10ug</label>
                                                            <div class="col-md-6 col-sm-20">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_20a" name="uc_20a_v" ID="uc_20a_v" />
                                                                    <label for="input-radio-20">Imipenem 10ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_20a" name="uc_20a_b" ID="uc_20a_b" />
                                                                    <label for="input-radio-20">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_20a" name="uc_20a_c" ID="uc_20a_c" />
                                                                    <label for="input-radio-20">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_20a_a">Zone Diameter (mm) Imipenem 10ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="20" ID="uc_20a_a" class="form-control" name="uc_20a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_20b">Imipenem 10ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-20">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_20b" name="uc_20b_a" ID="uc_20b_a" />
                                                                    <label for="input-radio-20" id="lbl_uc_20b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_20b" name="uc_20b_b" ID="uc_20b_b" />
                                                                    <label for="input-radio-20" id="lbl_uc_20b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_20b" name="uc_20b_c" ID="uc_20b_c" />
                                                                    <label for="input-radio-20" id="lbl_uc_20b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Levofloxacin 5ug</label>
                                                            <div class="col-md-6 col-sm-21">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_21a" name="uc_21a_v" ID="uc_21a_v" />
                                                                    <label for="input-radio-21">Levofloxacin 5ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_21a" name="uc_21a_b" ID="uc_21a_b" />
                                                                    <label for="input-radio-21">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_21a" name="uc_21a_c" ID="uc_21a_c" />
                                                                    <label for="input-radio-21">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_21a_a">Zone Diameter (mm) Levofloxacin 5ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="21" ID="uc_21a_a" class="form-control" name="uc_21a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_21b">Levofloxacin 5ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-21">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_21b" name="uc_21b_a" ID="uc_21b_a" />
                                                                    <label for="input-radio-21" id="lbl_uc_21b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_21b" name="uc_21b_b" ID="uc_21b_b" />
                                                                    <label for="input-radio-21" id="lbl_uc_21b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_21b" name="uc_21b_c" ID="uc_21b_c" />
                                                                    <label for="input-radio-21" id="lbl_uc_21b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Linezolid 30ug</label>
                                                            <div class="col-md-6 col-sm-22">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_22a" name="uc_22a_v" ID="uc_22a_v" />
                                                                    <label for="input-radio-22">Linezolid 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_22a" name="uc_22a_b" ID="uc_22a_b" />
                                                                    <label for="input-radio-22">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_22a" name="uc_22a_c" ID="uc_22a_c" />
                                                                    <label for="input-radio-22">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_22a_a">Zone Diameter (mm) Linezolid 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="22" ID="uc_22a_a" class="form-control" name="uc_22a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_22b">Linezolid 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-22">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_22b" name="uc_22b_a" ID="uc_22b_a" />
                                                                    <label for="input-radio-22" id="lbl_uc_22b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_22b" name="uc_22b_b" ID="uc_22b_b" />
                                                                    <label for="input-radio-22" id="lbl_uc_22b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_22b" name="uc_22b_c" ID="uc_22b_c" />
                                                                    <label for="input-radio-22" id="lbl_uc_22b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Meropenem 10ug</label>
                                                            <div class="col-md-6 col-sm-23">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_23a" name="uc_23a_v" ID="uc_23a_v" />
                                                                    <label for="input-radio-23">Meropenem 10ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_23a" name="uc_23a_b" ID="uc_23a_b" />
                                                                    <label for="input-radio-23">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_23a" name="uc_23a_c" ID="uc_23a_c" />
                                                                    <label for="input-radio-23">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_23a_a">Zone Diameter (mm) Meropenem 10ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="23" ID="uc_23a_a" class="form-control" name="uc_23a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_23b">Meropenem 10ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-23">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_23b" name="uc_23b_a" ID="uc_23b_a" />
                                                                    <label for="input-radio-23" id="lbl_uc_23b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_23b" name="uc_23b_b" ID="uc_23b_b" />
                                                                    <label for="input-radio-23" id="lbl_uc_23b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_23b" name="uc_23b_c" ID="uc_23b_c" />
                                                                    <label for="input-radio-23" id="lbl_uc_23b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Metronidazole 5ug</label>
                                                            <div class="col-md-6 col-sm-24">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_24a" name="uc_24a_v" ID="uc_24a_v" />
                                                                    <label for="input-radio-24">Metronidazole 5ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_24a" name="uc_24a_b" ID="uc_24a_b" />
                                                                    <label for="input-radio-24">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_24a" name="uc_24a_c" ID="uc_24a_c" />
                                                                    <label for="input-radio-24">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_24a_a">Zone Diameter (mm) Metronidazole 5ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="24" ID="uc_24a_a" class="form-control" name="uc_24a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_24b">Metronidazole 5ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-24">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_24b" name="uc_24b_a" ID="uc_24b_a" />
                                                                    <label for="input-radio-24" id="lbl_uc_24b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_24b" name="uc_24b_b" ID="uc_24b_b" />
                                                                    <label for="input-radio-24" id="lbl_uc_24b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_24b" name="uc_24b_c" ID="uc_24b_c" />
                                                                    <label for="input-radio-24" id="lbl_uc_24b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Ofloxacin 5ug</label>
                                                            <div class="col-md-6 col-sm-25">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_25a" name="uc_25a_v" ID="uc_25a_v" />
                                                                    <label for="input-radio-25">Ofloxacin 5ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_25a" name="uc_25a_b" ID="uc_25a_b" />
                                                                    <label for="input-radio-25">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_25a" name="uc_25a_c" ID="uc_25a_c" />
                                                                    <label for="input-radio-25">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_25a_a">Zone Diameter (mm) Ofloxacin 5ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="25" ID="uc_25a_a" class="form-control" name="uc_25a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_25b">Ofloxacin 5ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-25">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_25b" name="uc_25b_a" ID="uc_25b_a" />
                                                                    <label for="input-radio-25" id="lbl_uc_25b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_25b" name="uc_25b_b" ID="uc_25b_b" />
                                                                    <label for="input-radio-25" id="lbl_uc_25b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_25b" name="uc_25b_c" ID="uc_25b_c" />
                                                                    <label for="input-radio-25" id="lbl_uc_25b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Oxacillin 1ug</label>
                                                            <div class="col-md-6 col-sm-26">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_26a" name="uc_26a_v" ID="uc_26a_v" />
                                                                    <label for="input-radio-26">Oxacillin 1ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_26a" name="uc_26a_b" ID="uc_26a_b" />
                                                                    <label for="input-radio-26">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_26a" name="uc_26a_c" ID="uc_26a_c" />
                                                                    <label for="input-radio-26">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_26a_a">Zone Diameter (mm) Oxacillin 1ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="26" ID="uc_26a_a" class="form-control" name="uc_26a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_26b">Oxacillin 1ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-26">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_26b" name="uc_26b_a" ID="uc_26b_a" />
                                                                    <label for="input-radio-26" id="lbl_uc_26b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_26b" name="uc_26b_b" ID="uc_26b_b" />
                                                                    <label for="input-radio-26" id="lbl_uc_26b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_26b" name="uc_26b_c" ID="uc_26b_c" />
                                                                    <label for="input-radio-26" id="lbl_uc_26b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Penicillin G 10units</label>
                                                            <div class="col-md-6 col-sm-27">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_27a" name="uc_27a_v" ID="uc_27a_v" />
                                                                    <label for="input-radio-27">Penicillin G 10 units Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_27a" name="uc_27a_b" ID="uc_27a_b" />
                                                                    <label for="input-radio-27">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_27a" name="uc_27a_c" ID="uc_27a_c" />
                                                                    <label for="input-radio-27">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_27a_a">Zone Diameter (mm) Penicillin G 10 units</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="27" ID="uc_27a_a" class="form-control" name="uc_27a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_27b">Penicillin G 10 units Interpretation</label>
                                                            <div class="col-md-6 col-sm-27">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_27b" name="uc_27b_a" ID="uc_27b_a" />
                                                                    <label for="input-radio-27" id="lbl_uc_27b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_27b" name="uc_27b_b" ID="uc_27b_b" />
                                                                    <label for="input-radio-27" id="lbl_uc_27b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_27b" name="uc_27b_c" ID="uc_27b_c" />
                                                                    <label for="input-radio-27" id="lbl_uc_27b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Polymixin B 300units</label>
                                                            <div class="col-md-6 col-sm-28">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_28a" name="uc_28a_v" ID="uc_28a_v" />
                                                                    <label for="input-radio-28">Polymixin B 300units Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_28a" name="uc_28a_b" ID="uc_28a_b" />
                                                                    <label for="input-radio-28">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_28a" name="uc_28a_c" ID="uc_28a_c" />
                                                                    <label for="input-radio-28">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_28a_a">Zone Diameter (mm) Polymixin B 300units</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="28" ID="uc_28a_a" class="form-control" name="uc_28a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_28b">Polymixin B 300units Interpretation</label>
                                                            <div class="col-md-6 col-sm-28">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_28b" name="uc_28b_a" ID="uc_28b_a" />
                                                                    <label for="input-radio-28" id="lbl_uc_28b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_28b" name="uc_28b_b" ID="uc_28b_b" />
                                                                    <label for="input-radio-28" id="lbl_uc_28b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_28b" name="uc_28b_c" ID="uc_28b_c" />
                                                                    <label for="input-radio-28" id="lbl_uc_28b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Cotrimoxazole 25ug</label>
                                                            <div class="col-md-6 col-sm-29">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_29a" name="uc_29a_v" ID="uc_29a_v" />
                                                                    <label for="input-radio-29">Cotrimoxazole 25ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_29a" name="uc_29a_b" ID="uc_29a_b" />
                                                                    <label for="input-radio-29">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_29a" name="uc_29a_c" ID="uc_29a_c" />
                                                                    <label for="input-radio-29">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_29a_a">Zone Diameter (mm) Cotrimoxazole 25ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="29" ID="uc_29a_a" class="form-control" name="uc_29a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_29b">Cotrimoxazole 25ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-29">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_29b" name="uc_29b_a" ID="uc_29b_a" />
                                                                    <label for="input-radio-29" id="lbl_uc_29b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_29b" name="uc_29b_b" ID="uc_29b_b" />
                                                                    <label for="input-radio-29" id="lbl_uc_29b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_29b" name="uc_29b_c" ID="uc_29b_c" />
                                                                    <label for="input-radio-29" id="lbl_uc_29b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Tetracyclin 30ug</label>
                                                            <div class="col-md-6 col-sm-30">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_30a" name="uc_30a_v" ID="uc_30a_v" />
                                                                    <label for="input-radio-30">Tetracyclin 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_30a" name="uc_30a_b" ID="uc_30a_b" />
                                                                    <label for="input-radio-30">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_30a" name="uc_30a_c" ID="uc_30a_c" />
                                                                    <label for="input-radio-30">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_30a_a">Zone Diameter (mm) Tetracyclin 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="30" ID="uc_30a_a" class="form-control" name="uc_30a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_30b">Tetracyclin 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-30">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_30b" name="uc_30b_a" ID="uc_30b_a" />
                                                                    <label for="input-radio-30" id="lbl_uc_30b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_30b" name="uc_30b_b" ID="uc_30b_b" />
                                                                    <label for="input-radio-30" id="lbl_uc_30b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_30b" name="uc_30b_c" ID="uc_30b_c" />
                                                                    <label for="input-radio-30" id="lbl_uc_30b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Tobramycin 10ug</label>
                                                            <div class="col-md-6 col-sm-31">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_31a" name="uc_31a_v" ID="uc_31a_v" />
                                                                    <label for="input-radio-31">Tobramycin 10ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_31a" name="uc_31a_b" ID="uc_31a_b" />
                                                                    <label for="input-radio-31">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_31a" name="uc_31a_c" ID="uc_31a_c" />
                                                                    <label for="input-radio-31">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_31a_a">Zone Diameter (mm) Tobramycin 10ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="31" ID="uc_31a_a" class="form-control" name="uc_31a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_31b">Tobramycin 10ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-31">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_31b" name="uc_31b_a" ID="uc_31b_a" />
                                                                    <label for="input-radio-31" id="lbl_uc_31b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_31b" name="uc_31b_b" ID="uc_31b_b" />
                                                                    <label for="input-radio-31" id="lbl_uc_31b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_31b" name="uc_31b_c" ID="uc_31b_c" />
                                                                    <label for="input-radio-31" id="lbl_uc_31b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Piperacillin/Tazobactam 110ug</label>
                                                            <div class="col-md-6 col-sm-32">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_32a" name="uc_32a_v" ID="uc_32a_v" />
                                                                    <label for="input-radio-32">Piperacillin/Tazobactam 110ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_32a" name="uc_32a_b" ID="uc_32a_b" />
                                                                    <label for="input-radio-32">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_32a" name="uc_32a_c" ID="uc_32a_c" />
                                                                    <label for="input-radio-32">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_32a_a">Zone Diameter (mm) Piperacillin/Tazobactam 110ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="32" ID="uc_32a_a" class="form-control" name="uc_32a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_32b">Piperacillin/Tazobactam 110ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-32">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_32b" name="uc_32b_a" ID="uc_32b_a" />
                                                                    <label for="input-radio-32" id="lbl_uc_32b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_32b" name="uc_32b_b" ID="uc_32b_b" />
                                                                    <label for="input-radio-32" id="lbl_uc_32b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_32b" name="uc_32b_c" ID="uc_32b_c" />
                                                                    <label for="input-radio-32" id="lbl_uc_32b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Vancomycin 30ug</label>
                                                            <div class="col-md-6 col-sm-33">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_33a" name="uc_33a_v" ID="uc_33a_v" />
                                                                    <label for="input-radio-33">Vancomycin 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_33a" name="uc_33a_b" ID="uc_33a_b" />
                                                                    <label for="input-radio-33">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_33a" name="uc_33a_c" ID="uc_33a_c" />
                                                                    <label for="input-radio-33">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_33a_a">Zone Diameter (mm) Vancomycin 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="33" ID="uc_33a_a" class="form-control" name="uc_33a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_33b">Vancomycin 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-33">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_33b" name="uc_33b_a" ID="uc_33b_a" />
                                                                    <label for="input-radio-33" id="lbl_uc_33b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_33b" name="uc_33b_b" ID="uc_33b_b" />
                                                                    <label for="input-radio-33" id="lbl_uc_33b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_33b" name="uc_33b_c" ID="uc_33b_c" />
                                                                    <label for="input-radio-33" id="lbl_uc_33b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">FOSFOMYCIN/TROMETAMOL 200ug</label>
                                                            <div class="col-md-6 col-sm-34">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_34a" name="uc_34a_v" ID="uc_34a_v" />
                                                                    <label for="input-radio-34">FOSFOMYCIN/TROMETAMOL 200ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_34a" name="uc_34a_b" ID="uc_34a_b" />
                                                                    <label for="input-radio-34">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_34a" name="uc_34a_c" ID="uc_34a_c" />
                                                                    <label for="input-radio-34">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_34a_a">Zone Diameter (mm) FOSFOMYCIN/TROMETAMOL 200ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="34" ID="uc_34a_a" class="form-control" name="uc_34a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_34b">FOSFOMYCIN/TROMETAMOL 200ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-34">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_34b" name="uc_34b_a" ID="uc_34b_a" />
                                                                    <label for="input-radio-34" id="lbl_uc_34b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_34b" name="uc_34b_b" ID="uc_34b_b" />
                                                                    <label for="input-radio-34" id="lbl_uc_34b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_34b" name="uc_34b_c" ID="uc_34b_c" />
                                                                    <label for="input-radio-34" id="lbl_uc_34b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">NITROFURANTOIN 300ug</label>
                                                            <div class="col-md-6 col-sm-35">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_35a" name="uc_35a_v" ID="uc_35a_v" />
                                                                    <label for="input-radio-35">NITROFURANTOIN 300ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_35a" name="uc_35a_b" ID="uc_35a_b" />
                                                                    <label for="input-radio-35">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_35a" name="uc_35a_c" ID="uc_35a_c" />
                                                                    <label for="input-radio-35">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_35a_a">Zone Diameter (mm) NITROFURANTOIN 300ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="35" ID="uc_35a_a" class="form-control" name="uc_35a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_35b">NITROFURANTOIN 300ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-35">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_35b" name="uc_35b_a" ID="uc_35b_a" />
                                                                    <label for="input-radio-35" id="lbl_uc_35b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_35b" name="uc_35b_b" ID="uc_35b_b" />
                                                                    <label for="input-radio-35" id="lbl_uc_35b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_35b" name="uc_35b_c" ID="uc_35b_c" />
                                                                    <label for="input-radio-35" id="lbl_uc_35b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">PIPEMIDIC ACID 20ug</label>
                                                            <div class="col-md-6 col-sm-36">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_36a" name="uc_36a_v" ID="uc_36a_v" />
                                                                    <label for="input-radio-36">PIPEMIDIC ACID 20ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_36a" name="uc_36a_b" ID="uc_36a_b" />
                                                                    <label for="input-radio-36">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_36a" name="uc_36a_c" ID="uc_36a_c" />
                                                                    <label for="input-radio-36">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_36a_a">Zone Diameter (mm) PIPEMIDIC ACID 20ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="36" ID="uc_36a_a" class="form-control" name="uc_36a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_36b">PIPEMIDIC ACID 20ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-36">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_36b" name="uc_36b_a" ID="uc_36b_a" />
                                                                    <label for="input-radio-36" id="lbl_uc_36b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_36b" name="uc_36b_b" ID="uc_36b_b" />
                                                                    <label for="input-radio-36" id="lbl_uc_36b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_36b" name="uc_36b_c" ID="uc_36b_c" />
                                                                    <label for="input-radio-36" id="lbl_uc_36b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Nalidixic Acid 30ug</label>
                                                            <div class="col-md-6 col-sm-37">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_37a" name="uc_37a_v" ID="uc_37a_v" />
                                                                    <label for="input-radio-37">Nalidixic Acid 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_37a" name="uc_37a_b" ID="uc_37a_b" />
                                                                    <label for="input-radio-37">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_37a" name="uc_37a_c" ID="uc_37a_c" />
                                                                    <label for="input-radio-37">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_37a_a">Zone Diameter (mm) Nalidixic Acid 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="37" ID="uc_37a_a" class="form-control" name="uc_37a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_uc_37b">Nalidixic Acid 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-37">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_37b" name="uc_37b_a" ID="uc_37b_a" />
                                                                    <label for="input-radio-37" id="lbl_uc_37b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_37b" name="uc_37b_b" ID="uc_37b_b" />
                                                                    <label for="input-radio-37" id="lbl_uc_37b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="uc_37b" name="uc_37b_c" ID="uc_37b_c" />
                                                                    <label for="input-radio-37" id="lbl_uc_37b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label_heading" for="projectinput5">Blood Culture Result / Antibiotic Susceptibility</label>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Blood Culture Gram Stain Result</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_18" class="form-control" name="LA_18" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Blood Culture Result</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_19" class="form-control" name="LA_19" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Amoxicillin/ Clavulanic Acid 2:1 (AMC) 30ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_20a" name="LA_20a_v" ID="LA_20a_v" />
                                                                    <label for="input-radio-11">Amoxicillin/ Clavulanic Acid 2:1 (AMC) 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_20a" name="LA_20a_b" ID="LA_20a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_20a" name="LA_20a_c" ID="LA_20a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_20a_a">Zone Diameter (mm) Amoxicillin/ Clavulanic Acid 2:1 (AMC) 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_20a_a" class="form-control" name="LA_20a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_20b">Amoxicillin/Clavulanic Acid 2:1 (AMC) 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_20b" name="LA_20b_a" ID="LA_20b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_20b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_20b" name="LA_20b_b" ID="LA_20b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_20b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_20b" name="LA_20b_c" ID="LA_20b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_20b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Ampicillin (AMP) 10ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_21a" name="LA_21a_v" ID="LA_21a_v" />
                                                                    <label for="input-radio-11">Ampicillin (AMP) 10ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_21a" name="LA_21a_b" ID="LA_21a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_21a" name="LA_21a_c" ID="LA_21a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_21a_a">Zone Diameter (mm) Ampicillin (AMP) 10ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_21a_a" class="form-control" name="LA_21a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_21b">Ampicillin (AMP) 10ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_21b" name="LA_21b_a" ID="LA_21b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_21b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_21b" name="LA_21b_b" ID="LA_21b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_21b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_21b" name="LA_21b_c" ID="LA_21b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_21b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Amikacin  (AK) 30ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_22a" name="LA_22a_v" ID="LA_22a_v" />
                                                                    <label for="input-radio-11">Amikacin  (AK) 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_22a" name="LA_22a_b" ID="LA_22a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_22a" name="LA_22a_c" ID="LA_22a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_22a_a">Zone Diameter (mm) Amikacin  (AK) 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_22a_a" class="form-control" name="LA_22a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_22b">Amikacin  (AK) 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_22b" name="LA_22b_a" ID="LA_22b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_22b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_22b" name="LA_22b_b" ID="LA_22b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_22b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_22b" name="LA_22b_c" ID="LA_22b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_22b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Aztreonam (ATM) 30ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_23a" name="LA_23a_v" ID="LA_23a_v" />
                                                                    <label for="input-radio-11">Aztreonam (ATM) 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_23a" name="LA_23a_b" ID="LA_23a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_23a" name="LA_23a_c" ID="LA_23a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_23a_a">Zone Diameter (mm) Aztreonam (ATM) 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_23a_a" class="form-control" name="LA_23a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_23b">Aztreonam (ATM) 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_23b" name="LA_23b_a" ID="LA_23b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_23b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_23b" name="LA_23b_b" ID="LA_23b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_23b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_23b" name="LA_23b_c" ID="LA_23b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_23b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Azithromycin (AZM) 15ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_24a" name="LA_24a_v" ID="LA_24a_v" />
                                                                    <label for="input-radio-11">Azithromycin (AZM) 15ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_24a" name="LA_24a_b" ID="LA_24a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_24a" name="LA_24a_c" ID="LA_24a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_24a_a">Zone Diameter (mm) Azithromycin (AZM) 15ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_24a_a" class="form-control" name="LA_24a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_24b">Azithromycin (AZM) 15ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_24b" name="LA_24b_a" ID="LA_24b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_24b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_24b" name="LA_24b_b" ID="LA_24b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_24b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_24b" name="LA_24b_c" ID="LA_24b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_24b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Chloramphenicol (C)</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_25a" name="LA_25a_v" ID="LA_25a_v" />
                                                                    <label for="input-radio-11">Chloramphenicol (C) Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_25a" name="LA_25a_b" ID="LA_25a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_25a" name="LA_25a_c" ID="LA_25a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_25a_a">Zone Diameter (mm) Chloramphenicol (C)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_25a_a" class="form-control" name="LA_25a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_25b">Chloramphenicol (C) Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_25b" name="LA_25b_a" ID="LA_25b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_25b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_25b" name="LA_25b_b" ID="LA_25b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_25b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_25b" name="LA_25b_c" ID="LA_25b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_25b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Ceftazidime (CAZ) 30ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_26a" name="LA_26a_v" ID="LA_26a_v" />
                                                                    <label for="input-radio-11">Ceftazidime (CAZ) 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_26a" name="LA_26a_b" ID="LA_26a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_26a" name="LA_26a_c" ID="LA_26a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_26a_a">Zone Diameter (mm) Ceftazidime (CAZ) 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_26a_a" class="form-control" name="LA_26a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_26b">Ceftazidime (CAZ) 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_26b" name="LA_26b_a" ID="LA_26b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_26b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_26b" name="LA_26b_b" ID="LA_26b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_26b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_26b" name="LA_26b_c" ID="LA_26b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_26b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>






                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Cefixime (CFM) 5ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_27a" name="LA_27a_v" ID="LA_27a_v" />
                                                                    <label for="input-radio-11">Cefixime (CFM) 5ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_27a" name="LA_27a_b" ID="LA_27a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_27a" name="LA_27a_c" ID="LA_27a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_27a_a">Zone Diameter (mm) Cefixime (CFM) 5ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_27a_a" class="form-control" name="LA_27a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_27b">Cefixime (CFM) 5ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_27b" name="LA_27b_a" ID="LA_27b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_27b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_27b" name="LA_27b_b" ID="LA_27b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_27b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_27b" name="LA_27b_c" ID="LA_27b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_27b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>






                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Ciprofloxacin (CIP) 5ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_28a" name="LA_28a_v" ID="LA_28a_v" />
                                                                    <label for="input-radio-11">Ciprofloxacin (CIP) 5ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_28a" name="LA_28a_b" ID="LA_28a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_28a" name="LA_28a_c" ID="LA_28a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_28a_a">Zone Diameter (mm) Ciprofloxacin (CIP) 5ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_28a_a" class="form-control" name="LA_28a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_28b">Ciprofloxacin (CIP) 5ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_28b" name="LA_28b_a" ID="LA_28b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_28b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_28b" name="LA_28b_b" ID="LA_28b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_28b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_28b" name="LA_28b_c" ID="LA_28b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_28b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Gentamicin (CN) 10ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_29a" name="LA_29a_v" ID="LA_29a_v" />
                                                                    <label for="input-radio-11">Gentamicin (CN) 10ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_29a" name="LA_29a_b" ID="LA_29a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_29a" name="LA_29a_c" ID="LA_29a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_29a_a">Zone Diameter (mm) Gentamicin (CN) 10ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_29a_a" class="form-control" name="LA_29a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_29b">Gentamicin (CN) 10ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_29b" name="LA_29b_a" ID="LA_29b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_29b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_29b" name="LA_29b_b" ID="LA_29b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_29b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_29b" name="LA_29b_c" ID="LA_29b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_29b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Gentamicin (CN120) 120ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_30a" name="LA_30a_v" ID="LA_30a_v" />
                                                                    <label for="input-radio-11">Gentamicin (CN120) 120ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_30a" name="LA_30a_b" ID="LA_30a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_30a" name="LA_30a_c" ID="LA_30a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_30a_a">Zone Diameter (mm) Gentamicin (CN120) 120ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_30a_a" class="form-control" name="LA_30a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_30b">Gentamicin (CN120) 120ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_30b" name="LA_30b_a" ID="LA_30b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_30b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_30b" name="LA_30b_b" ID="LA_30b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_30b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_30b" name="LA_30b_c" ID="LA_30b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_30b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>






                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Ceftriaxone (CRO) 30ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_31a" name="LA_31a_v" ID="LA_31a_v" />
                                                                    <label for="input-radio-11">Ceftriaxone (CRO) 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_31a" name="LA_31a_b" ID="LA_31a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_31a" name="LA_31a_c" ID="LA_31a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_31a_a">Zone Diameter (mm) Ceftriaxone (CRO) 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_31a_a" class="form-control" name="LA_31a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_31b">Ceftriaxone (CRO) 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_31b" name="LA_31b_a" ID="LA_31b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_31b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_31b" name="LA_31b_b" ID="LA_31b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_31b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_31b" name="LA_31b_c" ID="LA_31b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_31b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Cefuroxime (CXM) 30ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_32a" name="LA_32a_v" ID="LA_32a_v" />
                                                                    <label for="input-radio-11">Cefuroxime (CXM) 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_32a" name="LA_32a_b" ID="LA_32a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_32a" name="LA_32a_c" ID="LA_32a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_32a_a">Zone Diameter (mm) Cefuroxime (CXM) 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_32a_a" class="form-control" name="LA_32a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_32b">Cefuroxime (CXM) 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_32b" name="LA_32b_a" ID="LA_32b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_32b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_32b" name="LA_32b_b" ID="LA_32b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_32b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_32b" name="LA_32b_c" ID="LA_32b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_32b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>






                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Clindamycin (DA) 2ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_33a" name="LA_33a_v" ID="LA_33a_v" />
                                                                    <label for="input-radio-11">Clindamycin (DA) 2ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_33a" name="LA_33a_b" ID="LA_33a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_33a" name="LA_33a_c" ID="LA_33a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_33a_a">Zone Diameter (mm) Clindamycin (DA) 2ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_33a_a" class="form-control" name="LA_33a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_33b">Clindamycin (DA) 2ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_33b" name="LA_33b_a" ID="LA_33b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_33b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_33b" name="LA_33b_b" ID="LA_33b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_33b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_33b" name="LA_33b_c" ID="LA_33b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_33b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>






                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Erythromycin (E)</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_34a" name="LA_34a_v" ID="LA_34a_v" />
                                                                    <label for="input-radio-11">Erythromycin (E) Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_34a" name="LA_34a_b" ID="LA_34a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_34a" name="LA_34a_c" ID="LA_34a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_34a_a">Zone Diameter (mm) Erythromycin (E)</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_34a_a" class="form-control" name="LA_34a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_34b">Erythromycin (E) Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_34b" name="LA_34b_a" ID="LA_34b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_34b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_34b" name="LA_34b_b" ID="LA_34b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_34b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_34b" name="LA_34b_c" ID="LA_34b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_34b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>






                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Cefipime (FEP) 30ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_35a" name="LA_35a_v" ID="LA_35a_v" />
                                                                    <label for="input-radio-11">Cefipime (FEP) 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_35a" name="LA_35a_b" ID="LA_35a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_35a" name="LA_35a_c" ID="LA_35a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_35a_a">Zone Diameter (mm) Cefipime (FEP) 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_35a_a" class="form-control" name="LA_35a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_35b">Cefipime (FEP) 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_35b" name="LA_35b_a" ID="LA_35b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_35b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_35b" name="LA_35b_b" ID="LA_35b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_35b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_35b" name="LA_35b_c" ID="LA_35b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_35b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>






                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Cefoxitin (FOX) 30ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_36a" name="LA_36a_v" ID="LA_36a_v" />
                                                                    <label for="input-radio-11">Cefoxitin (FOX) 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_36a" name="LA_36a_b" ID="LA_36a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_36a" name="LA_36a_c" ID="LA_36a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_36a_a">Zone Diameter (mm) Cefoxitin (FOX) 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_36a_a" class="form-control" name="LA_36a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_36b">Cefoxitin (FOX) 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_36b" name="LA_36b_a" ID="LA_36b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_36b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_36b" name="LA_36b_b" ID="LA_36b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_36b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_36b" name="LA_36b_c" ID="LA_36b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_36b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>






                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Fusidic Acid (FD) 10ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_37a" name="LA_37a_v" ID="LA_37a_v" />
                                                                    <label for="input-radio-11">Fusidic Acid (FD) 10ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_37a" name="LA_37a_b" ID="LA_37a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_37a" name="LA_37a_c" ID="LA_37a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_37a_a">Zone Diameter (mm) Fusidic Acid (FD) 10ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_37a_a" class="form-control" name="LA_37a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_37b">Fusidic Acid (FD) 10ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_37b" name="LA_37b_a" ID="LA_37b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_37b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_37b" name="LA_37b_b" ID="LA_37b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_37b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_37b" name="LA_37b_c" ID="LA_37b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_37b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>




                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Imipenem (IPM) 10ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_38a" name="LA_38a_v" ID="LA_38a_v" />
                                                                    <label for="input-radio-11">Imipenem (IPM) 10ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_38a" name="LA_38a_b" ID="LA_38a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_38a" name="LA_38a_c" ID="LA_38a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_38a_a">Zone Diameter (mm) Imipenem (IPM) 10ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_38a_a" class="form-control" name="LA_38a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_38b">Imipenem (IPM) 10ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_38b" name="LA_38b_a" ID="LA_38b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_38b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_38b" name="LA_38b_b" ID="LA_38b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_38b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_38b" name="LA_38b_c" ID="LA_38b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_38b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>





                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Levofloxacin (LEV) 5ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_39a" name="LA_39a_v" ID="LA_39a_v" />
                                                                    <label for="input-radio-11">Levofloxacin (LEV) 5ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_39a" name="LA_39a_b" ID="LA_39a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_39a" name="LA_39a_c" ID="LA_39a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_39a_a">Zone Diameter (mm) Levofloxacin (LEV) 5ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_39a_a" class="form-control" name="LA_39a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_39b">Levofloxacin (LEV) 5ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_39b" name="LA_39b_a" ID="LA_39b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_39b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_39b" name="LA_39b_b" ID="LA_39b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_39b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_39b" name="LA_39b_c" ID="LA_39b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_39b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>







                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Linezolid (LZD) 30ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_40a" name="LA_40a_v" ID="LA_40a_v" />
                                                                    <label for="input-radio-11">Linezolid (LZD) 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_40a" name="LA_40a_b" ID="LA_40a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_40a" name="LA_40a_c" ID="LA_40a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_40a_a">Zone Diameter (mm) Linezolid (LZD) 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_40a_a" class="form-control" name="LA_40a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_40b">Linezolid (LZD) 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_40b" name="LA_40b_a" ID="LA_40b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_40b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_40b" name="LA_40b_b" ID="LA_40b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_40b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_40b" name="LA_40b_c" ID="LA_40b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_40b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>








                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Meropenem (MEM) 10ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_41a" name="LA_41a_v" ID="LA_41a_v" />
                                                                    <label for="input-radio-11">Meropenem (MEM) 10ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_41a" name="LA_41a_b" ID="LA_41a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_41a" name="LA_41a_c" ID="LA_41a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_41a_a">Zone Diameter (mm) Meropenem (MEM) 10ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_41a_a" class="form-control" name="LA_41a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_41b">Meropenem (MEM) 10ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_41b" name="LA_41b_a" ID="LA_41b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_41b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_41b" name="LA_41b_b" ID="LA_41b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_41b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_41b" name="LA_41b_c" ID="LA_41b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_41b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>







                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Metronidazole (MTZ) 5ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_42a" name="LA_42a_v" ID="LA_42a_v" />
                                                                    <label for="input-radio-11">Metronidazole (MTZ) 5ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_42a" name="LA_42a_b" ID="LA_42a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_42a" name="LA_42a_c" ID="LA_42a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_42a_a">Zone Diameter (mm) Metronidazole (MTZ) 5ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_42a_a" class="form-control" name="LA_42a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_42b">Metronidazole (MTZ) 5ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_42b" name="LA_42b_a" ID="LA_42b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_42b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_42b" name="LA_42b_b" ID="LA_42b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_42b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_42b" name="LA_42b_c" ID="LA_42b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_42b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>








                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Nalidixic Acid (NA) 30ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_43a" name="LA_43a_v" ID="LA_43a_v" />
                                                                    <label for="input-radio-11">Nalidixic Acid (NA) 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_43a" name="LA_43a_b" ID="LA_43a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_43a" name="LA_43a_c" ID="LA_43a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_43a_a">Zone Diameter (mm) Nalidixic Acid (NA) 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_43a_a" class="form-control" name="LA_43a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_43b">Nalidixic Acid (NA) 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_43b" name="LA_43b_a" ID="LA_43b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_43b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_43b" name="LA_43b_b" ID="LA_43b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_43b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_43b" name="LA_43b_c" ID="LA_43b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_43b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>







                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Ofloxacin(OFX) 5ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_44a" name="LA_44a_v" ID="LA_44a_v" />
                                                                    <label for="input-radio-11">Ofloxacin(OFX) 5ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_44a" name="LA_44a_b" ID="LA_44a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_44a" name="LA_44a_c" ID="LA_44a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_44a_a">Zone Diameter (mm) Ofloxacin(OFX) 5ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_44a_a" class="form-control" name="LA_44a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_44b">Ofloxacin(OFX) 5ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_44b" name="LA_44b_a" ID="LA_44b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_44b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_44b" name="LA_44b_b" ID="LA_44b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_44b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_44b" name="LA_44b_c" ID="LA_44b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_44b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>






                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Oxacillin (OX) 1ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_45a" name="LA_45a_v" ID="LA_45a_v" />
                                                                    <label for="input-radio-11">Oxacillin (OX) 1ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_45a" name="LA_45a_b" ID="LA_45a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_45a" name="LA_45a_c" ID="LA_45a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_45a_a">Zone Diameter (mm) Oxacillin (OX) 1ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_45a_a" class="form-control" name="LA_45a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_45b">Oxacillin (OX) 1ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_45b" name="LA_45b_a" ID="LA_45b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_45b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_45b" name="LA_45b_b" ID="LA_45b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_45b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_45b" name="LA_45b_c" ID="LA_45b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_45b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>






                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Penicillin (P) 10units</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_46a" name="LA_46a_v" ID="LA_46a_v" />
                                                                    <label for="input-radio-11">Penicillin (P) 10units Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_46a" name="LA_46a_b" ID="LA_46a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_46a" name="LA_46a_c" ID="LA_46a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_46a_a">Zone Diameter (mm) Penicillin (P) 10units</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_46a_a" class="form-control" name="LA_46a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_46b">Penicillin (P) 10units Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_46b" name="LA_46b_a" ID="LA_46b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_46b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_46b" name="LA_46b_b" ID="LA_46b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_46b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_46b" name="LA_46b_c" ID="LA_46b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_46b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>







                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Polymixin B (PB) 300 units</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_47a" name="LA_47a_v" ID="LA_47a_v" />
                                                                    <label for="input-radio-11">Polymixin B (PB) 300 units Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_47a" name="LA_47a_b" ID="LA_47a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_47a" name="LA_47a_c" ID="LA_47a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_47a_a">Zone Diameter (mm) Polymixin B (PB) 300 units</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_47a_a" class="form-control" name="LA_47a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_47b">Polymixin B (PB) 300 units Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_47b" name="LA_47b_a" ID="LA_47b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_47b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_47b" name="LA_47b_b" ID="LA_47b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_47b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_47b" name="LA_47b_c" ID="LA_47b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_47b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>







                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Cotrimoxazole(SXT) 25ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_48a" name="LA_48a_v" ID="LA_48a_v" />
                                                                    <label for="input-radio-11">Cotrimoxazole(SXT) 25ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_48a" name="LA_48a_b" ID="LA_48a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_48a" name="LA_48a_c" ID="LA_48a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_48a_a">Zone Diameter (mm) Cotrimoxazole(SXT) 25ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_48a_a" class="form-control" name="LA_48a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_48b">Cotrimoxazole(SXT) 25ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_48b" name="LA_48b_a" ID="LA_48b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_48b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_48b" name="LA_48b_b" ID="LA_48b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_48b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_48b" name="LA_48b_c" ID="LA_48b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_48b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>







                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Tetracyclin (TE) 30ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_49a" name="LA_49a_v" ID="LA_49a_v" />
                                                                    <label for="input-radio-11">Tetracyclin (TE) 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_49a" name="LA_49a_b" ID="LA_49a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_49a" name="LA_49a_c" ID="LA_49a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_49a_a">Zone Diameter (mm) Tetracyclin (TE) 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_49a_a" class="form-control" name="LA_49a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_49b">Tetracyclin (TE) 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_49b" name="LA_49b_a" ID="LA_49b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_49b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_49b" name="LA_49b_b" ID="LA_49b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_49b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_49b" name="LA_49b_c" ID="LA_49b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_49b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>







                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Tobramycin (TOB) 10ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_50a" name="LA_50a_v" ID="LA_50a_v" />
                                                                    <label for="input-radio-11">Tobramycin (TOB) 10ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_50a" name="LA_50a_b" ID="LA_50a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_50a" name="LA_50a_c" ID="LA_50a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_50a_a">Zone Diameter (mm) Tobramycin (TOB) 10ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_50a_a" class="form-control" name="LA_50a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_50b">Tobramycin (TOB) 10ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_50b" name="LA_50b_a" ID="LA_50b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_50b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_50b" name="LA_50b_b" ID="LA_50b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_50b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_50b" name="LA_50b_c" ID="LA_50b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_50b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>






                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Piperacillin/Tazobactam (TZP) 110ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_51a" name="LA_51a_v" ID="LA_51a_v" />
                                                                    <label for="input-radio-11">Piperacillin/Tazobactam (TZP) 110ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_51a" name="LA_51a_b" ID="LA_51a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_51a" name="LA_51a_c" ID="LA_51a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>


                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_51a_a">Zone Diameter (mm) Piperacillin/Tazobactam (TZP) 110ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_51a_a" class="form-control" name="LA_51a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_51b">Piperacillin/Tazobactam (TZP) 110ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_51b" name="LA_51b_a" ID="LA_51b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_51b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_51b" name="LA_51b_b" ID="LA_51b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_51b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_51b" name="LA_51b_c" ID="LA_51b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_51b_i">I</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5">Vancomycin(VA) 30ug</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_52a" name="LA_52a_v" ID="LA_52a_v" />
                                                                    <label for="input-radio-11">Vancomycin(VA) 30ug Value</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_52a" name="LA_52a_b" ID="LA_52a_b" />
                                                                    <label for="input-radio-11">NA</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_52a" name="LA_52a_c" ID="LA_52a_c" />
                                                                    <label for="input-radio-12">NR</label>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_52a_a">Zone Diameter (mm) Vancomycin(VA) 30ug</label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox runat="server" MaxLength="15" ID="LA_52a_a" class="form-control" name="LA_52a_a" onkeypress="return numeralsOnly_decimal(event);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="col-md-3 label-control" for="projectinput5" id="lbl_LA_52b">Vancomycin(VA) 30ug Interpretation</label>
                                                            <div class="col-md-6 col-sm-12">
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_52b" name="LA_52b_a" ID="LA_52b_a" />
                                                                    <label for="input-radio-11" id="lbl_LA_52b_s">S</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_52b" name="LA_52b_b" ID="LA_52b_b" />
                                                                    <label for="input-radio-11" id="lbl_LA_52b_r">R</label>
                                                                </fieldset>
                                                                <fieldset>
                                                                    <asp:RadioButton runat="server" class=".radiocls2" GroupName="LA_52b" name="LA_52b_c" ID="LA_52b_c" />
                                                                    <label for="input-radio-12" id="lbl_LA_52b_i">I</label>
                                                                </fieldset>
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
                <span class="float-none d-block d-md-inline-block">Designed and developed by <a class="text-bold-800 grey darken-2" href="https://themeselection.com/" target="_blank">Paeds Department</a> &copy; Copyright <% Response.Write(DateTime.Now.Year.ToString()); %></span>
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
