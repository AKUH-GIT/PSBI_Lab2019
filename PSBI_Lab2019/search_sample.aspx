<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search_sample.aspx.cs" Inherits="search_sample" %>

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
                            <li class="nav-item mr-auto"><a class="navbar-brand" href="main.aspx">
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

                            <li class="nav-item"><a href="sample_results.aspx"><span class="menu-title" data-i18n=""><span style="font-family: Verdana">Lab Results</span></span></a></li>
                            <li class="nav-item"><a href="search_sample.aspx"><span class="menu-title" data-i18n=""><span style="font-family: Verdana">Search Record</span></span></a></li>
                            <li class="nav-item">
                                <asp:LinkButton Style="font-family: Verdana" ID="LinkButton1" runat="server" OnClick="lnk_logout_Click">Logout</asp:LinkButton>
                            </li>

                            <% }
                                else
                                { %>

                            <li class="nav-item"><a href="sample_recv.aspx"><span style="font-family: Verdana">Sample Receiving</span></a></li>
                            <li class="nav-item"><a href="sample_results.aspx"><span class="menu-title" data-i18n=""><span style="font-family: Verdana">Lab Results</span></span></a></li>
                            <li class="nav-item"><a href="rpt_sample.aspx"><span class="menu-title" data-i18n=""><span style="font-family: Verdana">Report Viewer</span></span></a></li>
                            <li class="nav-item"><a href="search_sample.aspx"><span class="menu-title" data-i18n=""><span style="font-family: Verdana">Search Record</span></span></a></li>
                            <li class="nav-item">
                                <asp:LinkButton Style="font-family: Verdana" ID="lnk_logout" runat="server" OnClick="lnk_logout_Click">Logout</asp:LinkButton>
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
                                                            <h4 class="form-section"><i class="ft-clipboard"></i>Search Record</h4>
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
                                                        </div>
                                                        <div class="form-group row">
                                                            <div class="col-md-12">
                                                                <asp:Button runat="server" ID="cmdSearchAll" class="btn btn-primary btn-min-width mr-2 mb-1" Text="Search All" OnClick="cmdSearchAll_Click"></asp:Button>
                                                                <asp:Button runat="server" ID="cmdSearch" class="btn btn-primary btn-min-width mr-2 mb-1" Text=" Search " OnClick="cmdSearch_Click"></asp:Button>
                                                                <asp:Button runat="server" ID="cmdCancel" class="btn btn-primary btn-min-width mr-2 mb-1" Text=" Clear " OnClick="cmdCancel_Click"></asp:Button>
                                                                <asp:Button runat="server" ID="cmdPrintPreview" class="btn btn-primary btn-min-width mr-2 mb-1" Text=" Print Preview " OnClick="cmdPrintPreview_Click"></asp:Button>
                                                                <asp:Button runat="server" ID="cmdPrint" class="btn btn-primary btn-min-width mr-2 mb-1" Text=" Print " OnClick="cmdPrint_Click"></asp:Button>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <div class="col-md-9">
                                                                <asp:GridView ID="dg" Name="dg" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="800px"
                                                                    OnRowCommand="dg_RowCommand" OnPageIndexChanging="dg_PageIndexChanging" OnRowEditing="dg_RowEditing"
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
                                                                        <asp:CommandField ShowSelectButton="True">
                                                                            <HeaderStyle BackColor="#6967ce" BorderColor="#6967ce" />
                                                                        </asp:CommandField>
                                                                    </Columns>
                                                                    <PagerStyle BackColor="#6967ce" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="White" />
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <div class="col-md-9">
                                                                <%--<asp:DataList ID="dl_data" runat="server" Width="40%" CellPadding="0" CellSpacing="0" GridLines="Vertical">
                                                                    <ItemTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <div class="card-content collapse show">
                                                                                    <div class="card-body">
                                                                                        <ul class="list-group">
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="label2" runat="server" Text="Screening ID: "></asp:Label>
                                                                                                <asp:Label ID="label1" runat="server" Text='<%# Bind("AS1_screening_ID") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="label3" runat="server" Text="Randomization ID: "></asp:Label>
                                                                                                <asp:Label ID="label4" runat="server" Text='<%# Bind("AS1_rand_id") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="label6" runat="server" Text="Name: "></asp:Label>
                                                                                                <asp:Label ID="label8" runat="server" Text='<%# Bind("AS1_name") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="label9" runat="server" Text="Sex: "></asp:Label>
                                                                                                <asp:Label ID="label10" runat="server" Text='<%# Bind("AS1_sex") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="label12" runat="server" Text="Age (Days): "></asp:Label>
                                                                                                <asp:Label ID="label13" runat="server" Text='<%# Bind("AS1_age") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="label14" runat="server" Text="Field Site: "></asp:Label>
                                                                                                <asp:Label ID="label15" runat="server" Text='<%# Bind("AS1_fsite") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="label16" runat="server" Text="Sample ID: "></asp:Label>
                                                                                                <asp:Label ID="label17" runat="server" Text='<%# Bind("AS1_barcode") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_la_sno" runat="server" Text=""></asp:Label><asp:Label ID="val_la_sno" runat="server" Text='<%# Bind("la_sno") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_02" runat="server" Text=""></asp:Label><asp:Label ID="val_LA_02" runat="server" Text='<%# Bind("LA_02") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_03_a" runat="server" Text="Haemoglobin"></asp:Label><asp:Label ID="val_LA_03_a" runat="server" Text='<%# Bind("LA_03_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_04_a" runat="server" Text="Haematocrit"></asp:Label><asp:Label ID="val_LA_04_a" runat="server" Text='<%# Bind("LA_04_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_05_a" runat="server" Text="R.B.C"></asp:Label><asp:Label ID="val_LA_05_a" runat="server" Text='<%# Bind("LA_05_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_06_a" runat="server" Text="M.C.V"></asp:Label><asp:Label ID="val_LA_06_a" runat="server" Text='<%# Bind("LA_06_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_07_a" runat="server" Text="M.C.H"></asp:Label><asp:Label ID="val_LA_07_a" runat="server" Text='<%# Bind("LA_07_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_08_a" runat="server" Text="M.C.H.C"></asp:Label><asp:Label ID="val_LA_08_a" runat="server" Text='<%# Bind("LA_08_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_09_a" runat="server" Text="R.D.W"></asp:Label><asp:Label ID="val_LA_09_a" runat="server" Text='<%# Bind("LA_09_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_10_a" runat="server" Text="W.B.C Count"></asp:Label><asp:Label ID="val_LA_10_a" runat="server" Text='<%# Bind("LA_10_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_11_a" runat="server" Text="Neutrophils"></asp:Label><asp:Label ID="val_LA_11_a" runat="server" Text='<%# Bind("LA_11_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_12_a" runat="server" Text="Lymphocytes"></asp:Label><asp:Label ID="val_LA_12_a" runat="server" Text='<%# Bind("LA_12_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_13_a" runat="server" Text="Eosinophils"></asp:Label><asp:Label ID="val_LA_13_a" runat="server" Text='<%# Bind("LA_13_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_14_a" runat="server" Text="Monocytes"></asp:Label><asp:Label ID="val_LA_14_a" runat="server" Text='<%# Bind("LA_14_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_15_a" runat="server" Text="Basophils"></asp:Label><asp:Label ID="val_LA_15_a" runat="server" Text='<%# Bind("LA_15_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_16_a" runat="server" Text="Platelets Count"></asp:Label><asp:Label ID="val_LA_16_a" runat="server" Text='<%# Bind("LA_16_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LF_01_a" runat="server" Text="Serum Total Bilirubin"></asp:Label><asp:Label ID="val_LF_01_a" runat="server" Text='<%# Bind("LF_01_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LF_02_a" runat="server" Text="Serum Direct Bilirubin"></asp:Label><asp:Label ID="val_LF_02_a" runat="server" Text='<%# Bind("LF_02_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LF_03_a" runat="server" Text="Serum Indirect Bilirubin"></asp:Label><asp:Label ID="val_LF_03_a" runat="server" Text='<%# Bind("LF_03_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LF_04_a" runat="server" Text="Serum Gamma GT"></asp:Label><asp:Label ID="val_LF_04_a" runat="server" Text='<%# Bind("LF_04_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LF_05_a" runat="server" Text="SGPT (ALT)"></asp:Label><asp:Label ID="val_LF_05_a" runat="server" Text='<%# Bind("LF_05_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LF_06_a" runat="server" Text="Serum Alkaline Phosphatase"></asp:Label><asp:Label ID="val_LF_06_a" runat="server" Text='<%# Bind("LF_06_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LF_07_a" runat="server" Text="SGOT (AST)"></asp:Label><asp:Label ID="val_LF_07_a" runat="server" Text='<%# Bind("LF_07_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_RF_01_a" runat="server" Text="Blood Urea Nitrogen"></asp:Label><asp:Label ID="val_RF_01_a" runat="server" Text='<%# Bind("RF_01_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_RF_02_a" runat="server" Text="Serum Creatinine"></asp:Label><asp:Label ID="val_RF_02_a" runat="server" Text='<%# Bind("RF_02_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_RF_03_a" runat="server" Text="e GFR"></asp:Label><asp:Label ID="val_RF_03_a" runat="server" Text='<%# Bind("RF_03_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_RF_04_a" runat="server" Text="Serum Sodium"></asp:Label><asp:Label ID="val_RF_04_a" runat="server" Text='<%# Bind("RF_04_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_SE_01_a" runat="server" Text="Serum Potassium"></asp:Label><asp:Label ID="val_SE_01_a" runat="server" Text='<%# Bind("SE_01_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_SE_02_a" runat="server" Text="Serum Chloride"></asp:Label><asp:Label ID="val_SE_02_a" runat="server" Text='<%# Bind("SE_02_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_SE_03_a" runat="server" Text="Serum Bicarbonate"></asp:Label><asp:Label ID="val_SE_03_a" runat="server" Text='<%# Bind("SE_03_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_SE_04_a" runat="server" Text="CSF GLUCOSE"></asp:Label><asp:Label ID="val_SE_04_a" runat="server" Text='<%# Bind("SE_04_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_CS_01_a" runat="server" Text="CSF CHLORIDE"></asp:Label><asp:Label ID="val_CS_01_a" runat="server" Text='<%# Bind("CS_01_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_CS_02_a" runat="server" Text="CSF PROTEIN"></asp:Label><asp:Label ID="val_CS_02_a" runat="server" Text='<%# Bind("CS_02_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_CS_03_a" runat="server" Text="CSF RBC"></asp:Label><asp:Label ID="val_CS_03_a" runat="server" Text='<%# Bind("CS_03_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_CS_04_a" runat="server" Text="CSF WBC"></asp:Label><asp:Label ID="val_CS_04_a" runat="server" Text='<%# Bind("CS_04_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_CS_05_a" runat="server" Text="CSF NEUTROPHILS"></asp:Label><asp:Label ID="val_CS_05_a" runat="server" Text='<%# Bind("CS_05_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_CS_06_a" runat="server" Text="CSF LYMPHOCYTES"></asp:Label><asp:Label ID="val_CS_06_a" runat="server" Text='<%# Bind("CS_06_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_CS_07_a" runat="server" Text="CSF PUS CELLS"></asp:Label><asp:Label ID="val_CS_07_a" runat="server" Text='<%# Bind("CS_07_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_CS_08_a" runat="server" Text="GRAM STAIN RESULT"></asp:Label><asp:Label ID="val_CS_08_a" runat="server" Text='<%# Bind("CS_08_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_CS_09_a" runat="server" Text="WET PREPARATION FOR NAEGLERIA"></asp:Label><asp:Label ID="val_CS_09_a" runat="server" Text='<%# Bind("CS_09_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_CS_10_a" runat="server" Text="Color"></asp:Label><asp:Label ID="val_CS_10_a" runat="server" Text='<%# Bind("CS_10_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_01_a" runat="server" Text="Appearance"></asp:Label><asp:Label ID="val_UR_01_a" runat="server" Text='<%# Bind("UR_01_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_02_a" runat="server" Text="Specific Gravity"></asp:Label><asp:Label ID="val_UR_02_a" runat="server" Text='<%# Bind("UR_02_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_03_a" runat="server" Text="pH"></asp:Label><asp:Label ID="val_UR_03_a" runat="server" Text='<%# Bind("UR_03_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_04_a" runat="server" Text="Glucose"></asp:Label><asp:Label ID="val_UR_04_a" runat="server" Text='<%# Bind("UR_04_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_05_a" runat="server" Text="Protein"></asp:Label><asp:Label ID="val_UR_05_a" runat="server" Text='<%# Bind("UR_05_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_06_a" runat="server" Text="Ketone"></asp:Label><asp:Label ID="val_UR_06_a" runat="server" Text='<%# Bind("UR_06_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_07_a" runat="server" Text="Urobilinogen"></asp:Label><asp:Label ID="val_UR_07_a" runat="server" Text='<%# Bind("UR_07_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_08_a" runat="server" Text="Bilirubin"></asp:Label><asp:Label ID="val_UR_08_a" runat="server" Text='<%# Bind("UR_08_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_10_a" runat="server" Text="Hemoglobin"></asp:Label><asp:Label ID="val_UR_10_a" runat="server" Text='<%# Bind("UR_10_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_11_a" runat="server" Text="Nitrite"></asp:Label><asp:Label ID="val_UR_11_a" runat="server" Text='<%# Bind("UR_11_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_12_a" runat="server" Text="Leucocyte Esterase"></asp:Label><asp:Label ID="val_UR_12_a" runat="server" Text='<%# Bind("UR_12_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_13_a" runat="server" Text="Red Blood Cells"></asp:Label><asp:Label ID="val_UR_13_a" runat="server" Text='<%# Bind("UR_13_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_14_a" runat="server" Text="Leucocytes"></asp:Label><asp:Label ID="val_UR_14_a" runat="server" Text='<%# Bind("UR_14_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_15_a" runat="server" Text="Squamous Epith Cell"></asp:Label><asp:Label ID="val_UR_15_a" runat="server" Text='<%# Bind("UR_15_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_16_a" runat="server" Text="Non Squamous Epith Cell"></asp:Label><asp:Label ID="val_UR_16_a" runat="server" Text='<%# Bind("UR_16_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_17_a" runat="server" Text="Bacteria"></asp:Label><asp:Label ID="val_UR_17_a" runat="server" Text='<%# Bind("UR_17_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_18_a" runat="server" Text="Yeast"></asp:Label><asp:Label ID="val_UR_18_a" runat="server" Text='<%# Bind("UR_18_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_19_a" runat="server" Text="Cast"></asp:Label><asp:Label ID="val_UR_19_a" runat="server" Text='<%# Bind("UR_19_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_20_a" runat="server" Text="Crystals"></asp:Label><asp:Label ID="val_UR_20_a" runat="server" Text='<%# Bind("UR_20_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_21_a" runat="server" Text="Mucus"></asp:Label><asp:Label ID="val_UR_21_a" runat="server" Text='<%# Bind("UR_21_a") %>'></asp:Label></li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_01a" runat="server" Text="Urine C/S Result"></asp:Label>
                                                                                                <asp:Label ID="val_uc_01a" runat="server" Text='<%# Bind("uc_01a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_01_ca" runat="server" Text="Name of organism"></asp:Label>
                                                                                                <asp:Label ID="val_uc_01_ca" runat="server" Text='<%# Bind("uc_01_ca") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_02a_a" runat="server" Text="Amoxicillin/ Clavulanic Acid 2:1 (AMC) 30ug: "></asp:Label>
                                                                                                <asp:Label ID="val_uc_02a_a" runat="server" Text='<%# Bind("uc_02a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="Label18" runat="server" Text="Amoxicillin/ Clavulanic Acid 2:1 (AMC) 30ug (Interpretation): "></asp:Label>
                                                                                                <asp:Label ID="Label20" runat="server" Text='<%# Bind("uc_02b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_03a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_03a_a" runat="server" Text='<%# Bind("uc_03a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="res_uc_03b" runat="server" Text='<%# Bind("uc_03b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_04a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_04a" runat="server" Text='<%# Bind("uc_04a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_04a" runat="server" Text='<%# Bind("uc_04a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_04a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_04a_a" runat="server" Text='<%# Bind("uc_04a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_04a_a" runat="server" Text='<%# Bind("uc_04a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_04b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_04b" runat="server" Text='<%# Bind("uc_04b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_04b" runat="server" Text='<%# Bind("uc_04b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_05a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_05a" runat="server" Text='<%# Bind("uc_05a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_05a" runat="server" Text='<%# Bind("uc_05a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_05a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_05a_a" runat="server" Text='<%# Bind("uc_05a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_05a_a" runat="server" Text='<%# Bind("uc_05a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_05b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_05b" runat="server" Text='<%# Bind("uc_05b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_05b" runat="server" Text='<%# Bind("uc_05b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_06a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_06a" runat="server" Text='<%# Bind("uc_06a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_06a" runat="server" Text='<%# Bind("uc_06a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_06a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_06a_a" runat="server" Text='<%# Bind("uc_06a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_06a_a" runat="server" Text='<%# Bind("uc_06a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_06b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_06b" runat="server" Text='<%# Bind("uc_06b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_06b" runat="server" Text='<%# Bind("uc_06b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_07a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_07a" runat="server" Text='<%# Bind("uc_07a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_07a" runat="server" Text='<%# Bind("uc_07a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_07a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_07a_a" runat="server" Text='<%# Bind("uc_07a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_07a_a" runat="server" Text='<%# Bind("uc_07a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_07b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_07b" runat="server" Text='<%# Bind("uc_07b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_07b" runat="server" Text='<%# Bind("uc_07b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_08a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_08a" runat="server" Text='<%# Bind("uc_08a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_08a" runat="server" Text='<%# Bind("uc_08a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_08a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_08a_a" runat="server" Text='<%# Bind("uc_08a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_08a_a" runat="server" Text='<%# Bind("uc_08a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_08b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_08b" runat="server" Text='<%# Bind("uc_08b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_08b" runat="server" Text='<%# Bind("uc_08b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_09a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_09a" runat="server" Text='<%# Bind("uc_09a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_09a" runat="server" Text='<%# Bind("uc_09a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_09a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_09a_a" runat="server" Text='<%# Bind("uc_09a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_09a_a" runat="server" Text='<%# Bind("uc_09a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_09b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_09b" runat="server" Text='<%# Bind("uc_09b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_09b" runat="server" Text='<%# Bind("uc_09b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_10a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_10a" runat="server" Text='<%# Bind("uc_10a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_10a" runat="server" Text='<%# Bind("uc_10a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_10a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_10a_a" runat="server" Text='<%# Bind("uc_10a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_10a_a" runat="server" Text='<%# Bind("uc_10a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_10b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_10b" runat="server" Text='<%# Bind("uc_10b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_10b" runat="server" Text='<%# Bind("uc_10b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_11a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_11a" runat="server" Text='<%# Bind("uc_11a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_11a" runat="server" Text='<%# Bind("uc_11a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_11a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_11a_a" runat="server" Text='<%# Bind("uc_11a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_11a_a" runat="server" Text='<%# Bind("uc_11a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_11b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_11b" runat="server" Text='<%# Bind("uc_11b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_11b" runat="server" Text='<%# Bind("uc_11b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_12a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_12a" runat="server" Text='<%# Bind("uc_12a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_12a" runat="server" Text='<%# Bind("uc_12a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_12a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_12a_a" runat="server" Text='<%# Bind("uc_12a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_12a_a" runat="server" Text='<%# Bind("uc_12a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_12b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_12b" runat="server" Text='<%# Bind("uc_12b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_12b" runat="server" Text='<%# Bind("uc_12b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_13a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_13a" runat="server" Text='<%# Bind("uc_13a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_13a" runat="server" Text='<%# Bind("uc_13a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_13a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_13a_a" runat="server" Text='<%# Bind("uc_13a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_13a_a" runat="server" Text='<%# Bind("uc_13a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_13b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_13b" runat="server" Text='<%# Bind("uc_13b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_13b" runat="server" Text='<%# Bind("uc_13b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_14a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_14a" runat="server" Text='<%# Bind("uc_14a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_14a" runat="server" Text='<%# Bind("uc_14a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_14a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_14a_a" runat="server" Text='<%# Bind("uc_14a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_14a_a" runat="server" Text='<%# Bind("uc_14a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_14b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_14b" runat="server" Text='<%# Bind("uc_14b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_14b" runat="server" Text='<%# Bind("uc_14b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_15a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_15a" runat="server" Text='<%# Bind("uc_15a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_15a" runat="server" Text='<%# Bind("uc_15a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_15a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_15a_a" runat="server" Text='<%# Bind("uc_15a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_15a_a" runat="server" Text='<%# Bind("uc_15a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_15b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_15b" runat="server" Text='<%# Bind("uc_15b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_15b" runat="server" Text='<%# Bind("uc_15b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_16a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_16a" runat="server" Text='<%# Bind("uc_16a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_16a" runat="server" Text='<%# Bind("uc_16a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_16a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_16a_a" runat="server" Text='<%# Bind("uc_16a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_16a_a" runat="server" Text='<%# Bind("uc_16a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_16b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_16b" runat="server" Text='<%# Bind("uc_16b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_16b" runat="server" Text='<%# Bind("uc_16b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_17a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_17a" runat="server" Text='<%# Bind("uc_17a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_17a" runat="server" Text='<%# Bind("uc_17a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_17a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_17a_a" runat="server" Text='<%# Bind("uc_17a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_17a_a" runat="server" Text='<%# Bind("uc_17a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_17b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_17b" runat="server" Text='<%# Bind("uc_17b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_17b" runat="server" Text='<%# Bind("uc_17b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_18a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_18a" runat="server" Text='<%# Bind("uc_18a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_18a" runat="server" Text='<%# Bind("uc_18a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_18a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_18a_a" runat="server" Text='<%# Bind("uc_18a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_18a_a" runat="server" Text='<%# Bind("uc_18a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_18b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_18b" runat="server" Text='<%# Bind("uc_18b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_18b" runat="server" Text='<%# Bind("uc_18b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_19a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_19a" runat="server" Text='<%# Bind("uc_19a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_19a" runat="server" Text='<%# Bind("uc_19a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_19a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_19a_a" runat="server" Text='<%# Bind("uc_19a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_19a_a" runat="server" Text='<%# Bind("uc_19a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_19b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_19b" runat="server" Text='<%# Bind("uc_19b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_19b" runat="server" Text='<%# Bind("uc_19b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_20a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_20a" runat="server" Text='<%# Bind("uc_20a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_20a" runat="server" Text='<%# Bind("uc_20a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_20a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_20a_a" runat="server" Text='<%# Bind("uc_20a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_20a_a" runat="server" Text='<%# Bind("uc_20a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_20b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_20b" runat="server" Text='<%# Bind("uc_20b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_20b" runat="server" Text='<%# Bind("uc_20b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_21a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_21a" runat="server" Text='<%# Bind("uc_21a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_21a" runat="server" Text='<%# Bind("uc_21a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_21a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_21a_a" runat="server" Text='<%# Bind("uc_21a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_21a_a" runat="server" Text='<%# Bind("uc_21a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_21b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_21b" runat="server" Text='<%# Bind("uc_21b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_21b" runat="server" Text='<%# Bind("uc_21b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_22a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_22a" runat="server" Text='<%# Bind("uc_22a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_22a" runat="server" Text='<%# Bind("uc_22a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_22a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_22a_a" runat="server" Text='<%# Bind("uc_22a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_22a_a" runat="server" Text='<%# Bind("uc_22a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_22b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_22b" runat="server" Text='<%# Bind("uc_22b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_22b" runat="server" Text='<%# Bind("uc_22b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_23a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_23a" runat="server" Text='<%# Bind("uc_23a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_23a" runat="server" Text='<%# Bind("uc_23a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_23a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_23a_a" runat="server" Text='<%# Bind("uc_23a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_23a_a" runat="server" Text='<%# Bind("uc_23a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_23b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_23b" runat="server" Text='<%# Bind("uc_23b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_23b" runat="server" Text='<%# Bind("uc_23b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_24a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_24a" runat="server" Text='<%# Bind("uc_24a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_24a" runat="server" Text='<%# Bind("uc_24a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_24a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_24a_a" runat="server" Text='<%# Bind("uc_24a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_24a_a" runat="server" Text='<%# Bind("uc_24a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_24b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_24b" runat="server" Text='<%# Bind("uc_24b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_24b" runat="server" Text='<%# Bind("uc_24b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_25a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_25a" runat="server" Text='<%# Bind("uc_25a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_25a" runat="server" Text='<%# Bind("uc_25a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_25a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_25a_a" runat="server" Text='<%# Bind("uc_25a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_25a_a" runat="server" Text='<%# Bind("uc_25a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_25b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_25b" runat="server" Text='<%# Bind("uc_25b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_25b" runat="server" Text='<%# Bind("uc_25b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_26a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_26a" runat="server" Text='<%# Bind("uc_26a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_26a" runat="server" Text='<%# Bind("uc_26a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_26a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_26a_a" runat="server" Text='<%# Bind("uc_26a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_26a_a" runat="server" Text='<%# Bind("uc_26a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_26b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_26b" runat="server" Text='<%# Bind("uc_26b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_26b" runat="server" Text='<%# Bind("uc_26b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_27a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_27a" runat="server" Text='<%# Bind("uc_27a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_27a" runat="server" Text='<%# Bind("uc_27a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_27a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_27a_a" runat="server" Text='<%# Bind("uc_27a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_27a_a" runat="server" Text='<%# Bind("uc_27a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_27b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_27b" runat="server" Text='<%# Bind("uc_27b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_27b" runat="server" Text='<%# Bind("uc_27b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_28a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_28a" runat="server" Text='<%# Bind("uc_28a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_28a" runat="server" Text='<%# Bind("uc_28a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_28a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_28a_a" runat="server" Text='<%# Bind("uc_28a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_28a_a" runat="server" Text='<%# Bind("uc_28a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_28b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_28b" runat="server" Text='<%# Bind("uc_28b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_28b" runat="server" Text='<%# Bind("uc_28b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_29a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_29a" runat="server" Text='<%# Bind("uc_29a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_29a" runat="server" Text='<%# Bind("uc_29a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_29a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_29a_a" runat="server" Text='<%# Bind("uc_29a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_29a_a" runat="server" Text='<%# Bind("uc_29a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_29b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_29b" runat="server" Text='<%# Bind("uc_29b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_29b" runat="server" Text='<%# Bind("uc_29b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_30a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_30a" runat="server" Text='<%# Bind("uc_30a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_30a" runat="server" Text='<%# Bind("uc_30a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_30a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_30a_a" runat="server" Text='<%# Bind("uc_30a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_30a_a" runat="server" Text='<%# Bind("uc_30a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_30b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_30b" runat="server" Text='<%# Bind("uc_30b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_30b" runat="server" Text='<%# Bind("uc_30b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_31a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_31a" runat="server" Text='<%# Bind("uc_31a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_31a" runat="server" Text='<%# Bind("uc_31a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_31a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_31a_a" runat="server" Text='<%# Bind("uc_31a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_31a_a" runat="server" Text='<%# Bind("uc_31a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_31b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_31b" runat="server" Text='<%# Bind("uc_31b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_31b" runat="server" Text='<%# Bind("uc_31b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_32a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_32a" runat="server" Text='<%# Bind("uc_32a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_32a" runat="server" Text='<%# Bind("uc_32a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_32a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_32a_a" runat="server" Text='<%# Bind("uc_32a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_32a_a" runat="server" Text='<%# Bind("uc_32a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_32b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_32b" runat="server" Text='<%# Bind("uc_32b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_32b" runat="server" Text='<%# Bind("uc_32b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_33a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_33a" runat="server" Text='<%# Bind("uc_33a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_33a" runat="server" Text='<%# Bind("uc_33a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_33a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_33a_a" runat="server" Text='<%# Bind("uc_33a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_33a_a" runat="server" Text='<%# Bind("uc_33a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_33b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_33b" runat="server" Text='<%# Bind("uc_33b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_33b" runat="server" Text='<%# Bind("uc_33b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_34a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_34a" runat="server" Text='<%# Bind("uc_34a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_34a" runat="server" Text='<%# Bind("uc_34a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_34a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_34a_a" runat="server" Text='<%# Bind("uc_34a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_34a_a" runat="server" Text='<%# Bind("uc_34a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_34b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_34b" runat="server" Text='<%# Bind("uc_34b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_34b" runat="server" Text='<%# Bind("uc_34b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_35a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_35a" runat="server" Text='<%# Bind("uc_35a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_35a" runat="server" Text='<%# Bind("uc_35a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_35a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_35a_a" runat="server" Text='<%# Bind("uc_35a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_35a_a" runat="server" Text='<%# Bind("uc_35a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_35b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_35b" runat="server" Text='<%# Bind("uc_35b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_35b" runat="server" Text='<%# Bind("uc_35b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_36a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_36a" runat="server" Text='<%# Bind("uc_36a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_36a" runat="server" Text='<%# Bind("uc_36a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_36a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_36a_a" runat="server" Text='<%# Bind("uc_36a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_36a_a" runat="server" Text='<%# Bind("uc_36a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_36b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_36b" runat="server" Text='<%# Bind("uc_36b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_36b" runat="server" Text='<%# Bind("uc_36b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_37a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_37a" runat="server" Text='<%# Bind("uc_37a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_37a" runat="server" Text='<%# Bind("uc_37a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_37a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_37a_a" runat="server" Text='<%# Bind("uc_37a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_37a_a" runat="server" Text='<%# Bind("uc_37a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_uc_37b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_uc_37b" runat="server" Text='<%# Bind("uc_37b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_uc_37b" runat="server" Text='<%# Bind("uc_37b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_17" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_17" runat="server" Text='<%# Bind("LA_17") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_17" runat="server" Text='<%# Bind("LA_17") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_18" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_18" runat="server" Text='<%# Bind("LA_18") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_18" runat="server" Text='<%# Bind("LA_18") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_19" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_19" runat="server" Text='<%# Bind("LA_19") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_19" runat="server" Text='<%# Bind("LA_19") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_20a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_20a_b" runat="server" Text='<%# Bind("LA_20a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_20a_b" runat="server" Text='<%# Bind("LA_20a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_20a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_20a_a" runat="server" Text='<%# Bind("LA_20a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_20a_a" runat="server" Text='<%# Bind("LA_20a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_20b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_20b_a" runat="server" Text='<%# Bind("LA_20b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_20b_a" runat="server" Text='<%# Bind("LA_20b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_21a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_21a_b" runat="server" Text='<%# Bind("LA_21a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_21a_b" runat="server" Text='<%# Bind("LA_21a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_21a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_21a_a" runat="server" Text='<%# Bind("LA_21a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_21a_a" runat="server" Text='<%# Bind("LA_21a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_21b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_21b_a" runat="server" Text='<%# Bind("LA_21b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_21b_a" runat="server" Text='<%# Bind("LA_21b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_22a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_22a_b" runat="server" Text='<%# Bind("LA_22a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_22a_b" runat="server" Text='<%# Bind("LA_22a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_22a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_22a_a" runat="server" Text='<%# Bind("LA_22a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_22a_a" runat="server" Text='<%# Bind("LA_22a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_22b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_22b_a" runat="server" Text='<%# Bind("LA_22b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_22b_a" runat="server" Text='<%# Bind("LA_22b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_23a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_23a_b" runat="server" Text='<%# Bind("LA_23a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_23a_b" runat="server" Text='<%# Bind("LA_23a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_23a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_23a_a" runat="server" Text='<%# Bind("LA_23a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_23a_a" runat="server" Text='<%# Bind("LA_23a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_23b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_23b_a" runat="server" Text='<%# Bind("LA_23b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_23b_a" runat="server" Text='<%# Bind("LA_23b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_24a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_24a_b" runat="server" Text='<%# Bind("LA_24a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_24a_b" runat="server" Text='<%# Bind("LA_24a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_24a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_24a_a" runat="server" Text='<%# Bind("LA_24a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_24a_a" runat="server" Text='<%# Bind("LA_24a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_24b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_24b_a" runat="server" Text='<%# Bind("LA_24b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_24b_a" runat="server" Text='<%# Bind("LA_24b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_25a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_25a_b" runat="server" Text='<%# Bind("LA_25a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_25a_b" runat="server" Text='<%# Bind("LA_25a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_25a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_25a_a" runat="server" Text='<%# Bind("LA_25a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_25a_a" runat="server" Text='<%# Bind("LA_25a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_25b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_25b_a" runat="server" Text='<%# Bind("LA_25b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_25b_a" runat="server" Text='<%# Bind("LA_25b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_26a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_26a_b" runat="server" Text='<%# Bind("LA_26a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_26a_b" runat="server" Text='<%# Bind("LA_26a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_26a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_26a_a" runat="server" Text='<%# Bind("LA_26a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_26a_a" runat="server" Text='<%# Bind("LA_26a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_26b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_26b_a" runat="server" Text='<%# Bind("LA_26b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_26b_a" runat="server" Text='<%# Bind("LA_26b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_27a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_27a_b" runat="server" Text='<%# Bind("LA_27a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_27a_b" runat="server" Text='<%# Bind("LA_27a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_27a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_27a_a" runat="server" Text='<%# Bind("LA_27a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_27a_a" runat="server" Text='<%# Bind("LA_27a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_27b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_27b_a" runat="server" Text='<%# Bind("LA_27b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_27b_a" runat="server" Text='<%# Bind("LA_27b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_28a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_28a_b" runat="server" Text='<%# Bind("LA_28a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_28a_b" runat="server" Text='<%# Bind("LA_28a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_28a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_28a_a" runat="server" Text='<%# Bind("LA_28a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_28a_a" runat="server" Text='<%# Bind("LA_28a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_28b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_28b_a" runat="server" Text='<%# Bind("LA_28b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_28b_a" runat="server" Text='<%# Bind("LA_28b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_29a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_29a_b" runat="server" Text='<%# Bind("LA_29a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_29a_b" runat="server" Text='<%# Bind("LA_29a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_29a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_29a_a" runat="server" Text='<%# Bind("LA_29a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_29a_a" runat="server" Text='<%# Bind("LA_29a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_29b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_29b_a" runat="server" Text='<%# Bind("LA_29b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_29b_a" runat="server" Text='<%# Bind("LA_29b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_30a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_30a_b" runat="server" Text='<%# Bind("LA_30a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_30a_b" runat="server" Text='<%# Bind("LA_30a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_30a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_30a_a" runat="server" Text='<%# Bind("LA_30a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_30a_a" runat="server" Text='<%# Bind("LA_30a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_30b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_30b_a" runat="server" Text='<%# Bind("LA_30b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_30b_a" runat="server" Text='<%# Bind("LA_30b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_31a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_31a_b" runat="server" Text='<%# Bind("LA_31a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_31a_b" runat="server" Text='<%# Bind("LA_31a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_31a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_31a_a" runat="server" Text='<%# Bind("LA_31a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_31a_a" runat="server" Text='<%# Bind("LA_31a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_31b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_31b_a" runat="server" Text='<%# Bind("LA_31b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_31b_a" runat="server" Text='<%# Bind("LA_31b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_32a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_32a_b" runat="server" Text='<%# Bind("LA_32a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_32a_b" runat="server" Text='<%# Bind("LA_32a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_32a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_32a_a" runat="server" Text='<%# Bind("LA_32a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_32a_a" runat="server" Text='<%# Bind("LA_32a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_32b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_32b_a" runat="server" Text='<%# Bind("LA_32b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_32b_a" runat="server" Text='<%# Bind("LA_32b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_33a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_33a_b" runat="server" Text='<%# Bind("LA_33a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_33a_b" runat="server" Text='<%# Bind("LA_33a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_33a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_33a_a" runat="server" Text='<%# Bind("LA_33a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_33a_a" runat="server" Text='<%# Bind("LA_33a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_33b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_33b_a" runat="server" Text='<%# Bind("LA_33b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_33b_a" runat="server" Text='<%# Bind("LA_33b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_34a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_34a_b" runat="server" Text='<%# Bind("LA_34a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_34a_b" runat="server" Text='<%# Bind("LA_34a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_34a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_34a_a" runat="server" Text='<%# Bind("LA_34a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_34a_a" runat="server" Text='<%# Bind("LA_34a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_34b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_34b_a" runat="server" Text='<%# Bind("LA_34b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_34b_a" runat="server" Text='<%# Bind("LA_34b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_35a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_35a_b" runat="server" Text='<%# Bind("LA_35a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_35a_b" runat="server" Text='<%# Bind("LA_35a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_35a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_35a_a" runat="server" Text='<%# Bind("LA_35a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_35a_a" runat="server" Text='<%# Bind("LA_35a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_35b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_35b_a" runat="server" Text='<%# Bind("LA_35b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_35b_a" runat="server" Text='<%# Bind("LA_35b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_36a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_36a_b" runat="server" Text='<%# Bind("LA_36a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_36a_b" runat="server" Text='<%# Bind("LA_36a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_36a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_36a_a" runat="server" Text='<%# Bind("LA_36a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_36a_a" runat="server" Text='<%# Bind("LA_36a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_36b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_36b_a" runat="server" Text='<%# Bind("LA_36b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_36b_a" runat="server" Text='<%# Bind("LA_36b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_37a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_37a_b" runat="server" Text='<%# Bind("LA_37a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_37a_b" runat="server" Text='<%# Bind("LA_37a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_37a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_37a_a" runat="server" Text='<%# Bind("LA_37a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_37a_a" runat="server" Text='<%# Bind("LA_37a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_37b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_37b_a" runat="server" Text='<%# Bind("LA_37b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_37b_a" runat="server" Text='<%# Bind("LA_37b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_38a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_38a_b" runat="server" Text='<%# Bind("LA_38a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_38a_b" runat="server" Text='<%# Bind("LA_38a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_38a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_38a_a" runat="server" Text='<%# Bind("LA_38a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_38a_a" runat="server" Text='<%# Bind("LA_38a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_38b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_38b_a" runat="server" Text='<%# Bind("LA_38b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_38b_a" runat="server" Text='<%# Bind("LA_38b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_39a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_39a_b" runat="server" Text='<%# Bind("LA_39a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_39a_b" runat="server" Text='<%# Bind("LA_39a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_39a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_39a_a" runat="server" Text='<%# Bind("LA_39a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_39a_a" runat="server" Text='<%# Bind("LA_39a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_39b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_39b_a" runat="server" Text='<%# Bind("LA_39b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_39b_a" runat="server" Text='<%# Bind("LA_39b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_40a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_40a_b" runat="server" Text='<%# Bind("LA_40a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_40a_b" runat="server" Text='<%# Bind("LA_40a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_40a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_40a_a" runat="server" Text='<%# Bind("LA_40a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_40a_a" runat="server" Text='<%# Bind("LA_40a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_40b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_40b_a" runat="server" Text='<%# Bind("LA_40b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_40b_a" runat="server" Text='<%# Bind("LA_40b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_41a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_41a_b" runat="server" Text='<%# Bind("LA_41a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_41a_b" runat="server" Text='<%# Bind("LA_41a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_41a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_41a_a" runat="server" Text='<%# Bind("LA_41a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_41a_a" runat="server" Text='<%# Bind("LA_41a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_41b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_41b_a" runat="server" Text='<%# Bind("LA_41b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_41b_a" runat="server" Text='<%# Bind("LA_41b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_42a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_42a_b" runat="server" Text='<%# Bind("LA_42a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_42a_b" runat="server" Text='<%# Bind("LA_42a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_42a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_42a_a" runat="server" Text='<%# Bind("LA_42a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_42a_a" runat="server" Text='<%# Bind("LA_42a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_42b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_42b_a" runat="server" Text='<%# Bind("LA_42b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_42b_a" runat="server" Text='<%# Bind("LA_42b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_43a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_43a_b" runat="server" Text='<%# Bind("LA_43a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_43a_b" runat="server" Text='<%# Bind("LA_43a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_43a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_43a_a" runat="server" Text='<%# Bind("LA_43a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_43a_a" runat="server" Text='<%# Bind("LA_43a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_43b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_43b_a" runat="server" Text='<%# Bind("LA_43b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_43b_a" runat="server" Text='<%# Bind("LA_43b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_44a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_44a_b" runat="server" Text='<%# Bind("LA_44a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_44a_b" runat="server" Text='<%# Bind("LA_44a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_44a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_44a_a" runat="server" Text='<%# Bind("LA_44a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_44a_a" runat="server" Text='<%# Bind("LA_44a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_44b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_44b_a" runat="server" Text='<%# Bind("LA_44b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_44b_a" runat="server" Text='<%# Bind("LA_44b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_45a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_45a_b" runat="server" Text='<%# Bind("LA_45a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_45a_b" runat="server" Text='<%# Bind("LA_45a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_45a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_45a_a" runat="server" Text='<%# Bind("LA_45a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_45a_a" runat="server" Text='<%# Bind("LA_45a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_45b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_45b_a" runat="server" Text='<%# Bind("LA_45b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_45b_a" runat="server" Text='<%# Bind("LA_45b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_46a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_46a_b" runat="server" Text='<%# Bind("LA_46a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_46a_b" runat="server" Text='<%# Bind("LA_46a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_46a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_46a_a" runat="server" Text='<%# Bind("LA_46a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_46a_a" runat="server" Text='<%# Bind("LA_46a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_46b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_46b_a" runat="server" Text='<%# Bind("LA_46b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_46b_a" runat="server" Text='<%# Bind("LA_46b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_47a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_47a_b" runat="server" Text='<%# Bind("LA_47a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_47a_b" runat="server" Text='<%# Bind("LA_47a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_47a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_47a_a" runat="server" Text='<%# Bind("LA_47a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_47a_a" runat="server" Text='<%# Bind("LA_47a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_47b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_47b_a" runat="server" Text='<%# Bind("LA_47b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_47b_a" runat="server" Text='<%# Bind("LA_47b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_48a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_48a_b" runat="server" Text='<%# Bind("LA_48a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_48a_b" runat="server" Text='<%# Bind("LA_48a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_48a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_48a_a" runat="server" Text='<%# Bind("LA_48a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_48a_a" runat="server" Text='<%# Bind("LA_48a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_48b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_48b_a" runat="server" Text='<%# Bind("LA_48b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_48b_a" runat="server" Text='<%# Bind("LA_48b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_49a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_49a_b" runat="server" Text='<%# Bind("LA_49a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_49a_b" runat="server" Text='<%# Bind("LA_49a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_49a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_49a_a" runat="server" Text='<%# Bind("LA_49a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_49a_a" runat="server" Text='<%# Bind("LA_49a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_49b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_49b_a" runat="server" Text='<%# Bind("LA_49b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_49b_a" runat="server" Text='<%# Bind("LA_49b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_50a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_50a_b" runat="server" Text='<%# Bind("LA_50a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_50a_b" runat="server" Text='<%# Bind("LA_50a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_50a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_50a_a" runat="server" Text='<%# Bind("LA_50a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_50a_a" runat="server" Text='<%# Bind("LA_50a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_50b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_50b_a" runat="server" Text='<%# Bind("LA_50b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_50b_a" runat="server" Text='<%# Bind("LA_50b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_51a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_51a_b" runat="server" Text='<%# Bind("LA_51a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_51a_b" runat="server" Text='<%# Bind("LA_51a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_51a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_51a_a" runat="server" Text='<%# Bind("LA_51a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_51a_a" runat="server" Text='<%# Bind("LA_51a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_51b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_51b_a" runat="server" Text='<%# Bind("LA_51b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_51b_a" runat="server" Text='<%# Bind("LA_51b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_52a_b" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_52a_b" runat="server" Text='<%# Bind("LA_52a_b") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_52a_b" runat="server" Text='<%# Bind("LA_52a_b") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_52a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_52a_a" runat="server" Text='<%# Bind("LA_52a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_52a_a" runat="server" Text='<%# Bind("LA_52a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_LA_52b_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_LA_52b_a" runat="server" Text='<%# Bind("LA_52b_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_LA_52b_a" runat="server" Text='<%# Bind("LA_52b_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_04a_a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_UR_04a_a" runat="server" Text='<%# Bind("UR_04a_a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_UR_04a_a" runat="server" Text='<%# Bind("UR_04a_a") %>'></asp:Label>
                                                                                            </li>
                                                                                            <li class="list-group-item">
                                                                                                <asp:Label ID="lbl_UR_04a" runat="server" Text=""></asp:Label>
                                                                                                <asp:Label ID="val_UR_04a" runat="server" Text='<%# Bind("UR_04a") %>'></asp:Label>
                                                                                                <asp:Label ID="res_UR_04a" runat="server" Text='<%# Bind("UR_04a") %>'></asp:Label>
                                                                                            </li>


                                                                                        </ul>
                                                                                    </div>
                                                                                </div>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <AlternatingItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                                                                    <HeaderTemplate>
                                                                        <span style="font-size: 10pt; color: #278A05; font-family: Tahoma">
                                                                            <table align="center" cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <div class="card-content collapse show">
                                                                                        <div class="card-body">
                                                                                            <ul class="list-group">
                                                                                                <li class="list-group-item">Sample Details</li>
                                                                                            </ul>
                                                                                        </div>
                                                                                    </div>
                                                                                </tr>
                                                                            </table>
                                                                        </span>
                                                                    </HeaderTemplate>
                                                                    <SeparatorTemplate>
                                                                        <hr />
                                                                    </SeparatorTemplate>
                                                                </asp:DataList>--%>
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
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="cmdSearchAll" />
                <asp:PostBackTrigger ControlID="cmdSearch" />
                <asp:PostBackTrigger ControlID="dg" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
