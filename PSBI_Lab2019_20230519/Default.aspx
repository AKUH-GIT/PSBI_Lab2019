<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
    <link rel="stylesheet" type="text/css" href="Content/demo/chameleon-admin-template/app-assets/vendors/css/forms/selects/select2.min.css">
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

    </script>
</head>
<body class="vertical-layout vertical-menu 2-columns fixed-navbar" data-open="click" data-menu="vertical-menu" data-color="bg-blue" data-col="2-columns">
    <form id="form1" name="form1" runat="server" autocomplete="off" enctype="multipart/form-data">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="upd" runat="server">
            <ContentTemplate>
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

                            <% if (HttpContext.Current.Request.Cookies["labid"].Value == "3" || HttpContext.Current.Request.Cookies["labid"].Value == "4")
                                { %>

                            <li class="nav-item"><a href="search_sample.aspx"><span class="menu-title" data-i18n=""><span style="font-family: Verdana">Searching</span></span></a>
                                <ul>
                                    <li class="nav-item">
                                        <a href="search_sample.aspx"><span class="menu-title" data-i18n=""><span style="font-family: Verdana">Search Record</span></span></a>
                                    </li>
                                    <li class="nav-item"><a href="view_bloodculture.aspx"><span class="menu-title" data-i18n=""><span style="font-family: Verdana">View Blood Culture</span></span></a></li>
                                </ul>
                            </li>
                            <li class="nav-item">
                                <asp:LinkButton Style="font-family: Verdana" ID="LinkButton1" runat="server" OnClick="lnk_logout_Click">Logout</asp:LinkButton>
                            </li>

                            <% }
                                else if (HttpContext.Current.Request.Cookies["labid"].Value == "2")
                                { %>

                            <li class="nav-item"><a href="sample_recv.aspx"><span style="font-family: Verdana">Sample Receiving</span></a>
                            </li>
                            <li class="nav-item"><a href="sample_results.aspx"><span style="font-family: Verdana">Lab Results</span></a></li>
                            <li class="nav-item">
                                <asp:LinkButton runat="server" Style="font-family: Verdana" OnClick="lnk_logout_Click">Logout</asp:LinkButton>
                            </li>

                            <% }
                                else
                                { %>

                            <li class="nav-item"><a href="sample_recv.aspx"><span style="font-family: Verdana">Sample Receiving</span></a></li>
                            <li class="nav-item"><a href="sample_results.aspx"><span style="font-family: Verdana">Lab Results</span></a></li>
                            <li class="nav-item"><a href="search_sample.aspx"><span class="menu-title" data-i18n=""><span style="font-family: Verdana">Searching</span></span></a>
                                <ul>
                                    <li class="nav-item">
                                        <a href="search_sample.aspx"><span class="menu-title" data-i18n=""><span style="font-family: Verdana">Search Record</span></span></a>
                                    </li>
                                    <li class="nav-item"><a href="view_bloodculture.aspx"><span class="menu-title" data-i18n=""><span style="font-family: Verdana">View Blood Culture</span></span></a></li>
                                </ul>
                            </li>
                            <li class="nav-item">
                                <asp:LinkButton runat="server" Style="font-family: Verdana" OnClick="lnk_logout_Click">Logout</asp:LinkButton>
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
                            <!-- Basic form layout section start -->
                            <section id="horizontal-form-layouts">
                                <div class="row">
                                    <div class="col-xl-6 col-lg-12">
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    </div>
                                </div>
                            </section>
                            <!-- // Basic form layout section end -->
                        </div>
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

                <!-- BEGIN: Page Vendor JS-->
                <script src="Content/demo/chameleon-admin-template/app-assets/vendors/js/forms/select/select2.full.min.js" type="text/javascript"></script>
                <!-- END: Page Vendor JS-->



                <!-- END: Page Vendor JS-->
                <script src="Content/demo/chameleon-admin-template/app-assets/js/core/app-menu.min.js" type="text/javascript"></script>
                <script src="Content/demo/chameleon-admin-template/app-assets/js/core/app.min.js" type="text/javascript"></script>
                <script src="Content/demo/chameleon-admin-template/app-assets/js/scripts/customizer.min.js" type="text/javascript"></script>
                <script src="Content/demo/chameleon-admin-template/app-assets/vendors/js/jquery.sharrre.js" type="text/javascript"></script>
                <!-- END: Theme JS-->

                <!-- BEGIN: Page JS-->
                <script src="Content/demo/chameleon-admin-template/app-assets/js/scripts/forms/select/form-select2.min.js" type="text/javascript"></script>
                <!-- END: Page JS-->

                <!-- END: Body-->
                <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
                <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
                <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
