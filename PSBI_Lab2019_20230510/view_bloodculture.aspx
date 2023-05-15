<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_bloodculture.aspx.cs" Inherits="view_bloodculture" EnableEventValidation="false" %>

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
                    <li class="nav-item"><a href="sample_results.aspx"><span class="menu-title" data-i18n=""><span style="font-family: Verdana">Lab Results</span></span></a></li>                    
                    <li class="nav-item"><a href="#"><span class="menu-title" data-i18n=""><span style="font-family: Verdana">Searching</span></span></a>
                        <ul>
                            <li class="nav-item">
                                <a href="search_sample.aspx"><span class="menu-title" data-i18n=""><span style="font-family: Verdana">Search Record</span></span></a>
                            </li>
                            <li class="active"><a href="view_bloodculture.aspx"><span class="menu-title" data-i18n=""><span style="font-family: Verdana">View Blood Culture</span></span></a></li>
                        </ul>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton Style="font-family: Verdana" ID="lnk_logout" runat="server" OnClick="lnk_logout_Click">Logout</asp:LinkButton>
                    </li>
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

                                                    <div class="form-group row">
                                                        <div class="col-md-12" id="lbl_testing" runat="server">
                                                            <div id="Div19" runat="server" style="font-size: 15pt; font-weight: bold; color: #FF0000; text-align: center;">Testing Entries</div>
                                                        </div>
                                                    </div>


                                                    <h4 class="form-section"><i class="ft-clipboard"></i>View Blood Culture</h4>
                                                    <br />
                                                    <div class="form-group row">
                                                        <div class="col-md-9">
                                                            <asp:Label runat="server" Style="color: #FF0000" ID="lblerr" name="lblerr"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-md-4 label-control" for="projectinput5">Start Date</label>
                                                                <div class="col-md-6">
                                                                    <asp:TextBox runat="server" ID="txtStartDate" class="form-control" name="txtStartDate"></asp:TextBox>
                                                                    <div id="Div1" runat="server">
                                                                        <script type="text/javascript">
                                                                            $(document).ready(function () {
                                                                                $('#<%=txtStartDate.ClientID%>').datepicker({
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
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-md-4 label-control" for="projectinput5">End Date</label>
                                                                <div class="col-md-6">
                                                                    <asp:TextBox runat="server" ID="txtEndDate" class="form-control" name="txtEndDate"></asp:TextBox>
                                                                    <div id="Div2" runat="server">
                                                                        <script type="text/javascript">
                                                                            $(document).ready(function () {
                                                                                $('#<%=txtEndDate.ClientID%>').datepicker({
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
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <asp:CheckBox runat="server" ID="chkBloodCulture" name="chkBloodCulture"></asp:CheckBox>
                                                                <label class="col-md-8 label-control" for="projectinput5">Is Blood Culture Positive?</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-1">
                                                        <asp:Button runat="server" ID="cmdSearch" OnClick="cmdSearch_Click" class="btn btn-primary" Text="Search"></asp:Button>&nbsp;
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:Button runat="server" ID="cmdCancel" OnClick="cmdCancel_Click" class="btn btn-primary" Text=" Clear "></asp:Button>
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:Button runat="server" ID="cmdExportExcel" OnClick="cmdExportExcel_Click" class="btn btn-primary" Text="Export Excel"></asp:Button>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-md-9">
                                                        <asp:GridView ID="dg_BloodCulture" Name="dg_BloodCulture" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="800px" OnPageIndexChanging="dg_BloodCulture_PageIndexChanging"
                                                            BorderColor="#6967CE" BorderStyle="Solid" BorderWidth="2px" PageSize="30">
                                                            <Columns>
                                                                <asp:BoundField DataField="id" Visible="false" />
                                                                <asp:TemplateField HeaderText="ID" HeaderStyle-Height="30px" ItemStyle-Height="30px" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox76" runat="server" Text='<%# Bind("id1") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label76" runat="server" Text='<%# Bind("id1") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle BackColor="#6967ce" BorderColor="#6967ce" Font-Names="Verdana" Font-Size="10pt" ForeColor="White" />
                                                                    <ItemStyle Height="30px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Screening ID" HeaderStyle-Height="30px" ItemStyle-Height="30px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("AS1_screening_ID") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("AS1_screening_ID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle BackColor="#6967ce" BorderColor="#6967ce" Font-Names="Verdana" Font-Size="10pt" ForeColor="White" />
                                                                    <ItemStyle Height="30px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Randomization ID">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox5" runat="server" CssClass="txtbox" Text='<%# Bind("AS1_rand_id") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("AS1_rand_id") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle BackColor="#6967ce" BorderColor="#6967ce" Font-Names="Verdana" Font-Size="10pt" ForeColor="White" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Child Name">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox11" runat="server" CssClass="txtbox" Text='<%# Bind("AS1_name") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("AS1_name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle BackColor="#6967ce" BorderColor="#6967ce" Font-Names="Verdana" Font-Size="10pt" ForeColor="White" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Child Age">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox12" runat="server" CssClass="txtbox" Text='<%# Bind("AS1_age") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label122" runat="server" Text='<%# Bind("AS1_age") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle BackColor="#6967ce" BorderColor="#6967ce" Font-Names="Verdana" Font-Size="10pt" ForeColor="White" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="MR No">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox136" runat="server" CssClass="txtbox" Text='<%# Bind("AS1_mrno") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label291" runat="server" Text='<%# Bind("AS1_mrno") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle BackColor="#6967ce" BorderColor="#6967ce" Font-Names="Verdana" Font-Size="10pt" ForeColor="White" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="L Number">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox146" runat="server" CssClass="txtbox" Text='<%# Bind("AS1_lno") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label369" runat="server" Text='<%# Bind("AS1_lno") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle BackColor="#6967ce" BorderColor="#6967ce" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Receiving Date">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox146" runat="server" CssClass="txtbox" Text='<%# Bind("AS2_Q9") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label369" runat="server" Text='<%# Bind("AS2_Q9") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle BackColor="#6967ce" BorderColor="#6967ce" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                                <%--<asp:CommandField ShowSelectButton="True" EditText="View Data" ShowEditButton="True">
                                                                            <HeaderStyle BackColor="#6967ce" BorderColor="#6967ce" />
                                                                        </asp:CommandField>--%>
                                                            </Columns>
                                                            <PagerStyle BackColor="#6967ce" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="White" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>

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
