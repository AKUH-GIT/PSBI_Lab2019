<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="registeruser.aspx.cs" Inherits="registeruser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">

        $(document).ready(function () {
            $('#MainContent_txtUserID').focus();
        });


        function ValidateForm() {

            if ($('#MainContent_txtUserID').val() == "") {
                alert("Required field");
                $('#MainContent_txtUserID').focus();
                return false;
            }
            else if ($('#MainContent_txtpasswd').val() == "") {
                alert("Required field");
                $('#MainContent_txtpasswd').focus();
                return false;
            }
            else if ($('#MainContent_txtconpasswd').val() == "") {
                alert("Required field");
                $('#MainContent_txtconpasswd').focus();
                return false;
            }
            else if ($('#MainContent_txtpasswd').val() != $('#MainContent_txtconpasswd').val()) {
                alert("Password and confirm password must be same");
                $('#MainContent_txtpasswd').focus();
                return false;
            }


            return true;
        }


        //$(document).on("click", "#cmdLogin", function (e) {


        //    $("#lblerr").html("");

        //    $
        //        .ajax({
        //            url: "login/Login",
        //            type: "POST",
        //            contentType: "application/json; charset=utf-8",
        //            dataType: "json",
        //            data: "{ userid: '" + $('#MainContent_txtUserID').val() + "', passwd: '" + $("#MainContent_txtpasswd").val() + "'}",

        //            success: function (
        //                data) {

        //                if (data.d == "") {
        //                    alert("Invalid user id or password");
        //                }
        //                else {
        //                    window.location.href = "default.aspx";
        //                }

        //            },
        //            error: function (
        //                xhr,
        //                ajaxOptions,
        //                thrownError) {

        //                alert('Error: ');

        //            }
        //        });


        //});

        $(document).on("click", "#cmdCancel", function (e) {
            $('#MainContent_txtUserID').val('');
            $('#MainContent_txtpasswd').val('');
            $('#MainContent_txtUserID').focus();
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div class="card border-grey border-lighten-3 px-1 py-1 m-0">
                <div class="card-header border-0">
                    <div class="text-center mb-1">
                        <%--<img src="../../../app-assets/images/logo/logo.png" alt="branding logo">--%>
                    </div>
                    <div class="font-large-1 text-center">
                        PSBI Lab Management System
                    </div>
                </div>
                <div class="card-content">
                    <div class="card-body">
                        <fieldset class="form-group position-relative has-icon-left">
                            <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control round" placeholder="User Name" Text=""></asp:TextBox>
                            <div class="form-control-position">
                                <i class="ft-user"></i>
                            </div>
                        </fieldset>
                        <fieldset class="form-group position-relative has-icon-left">
                            <asp:TextBox ID="txtpasswd" name="txtpasswd" runat="server" TextMode="Password" CssClass="form-control round" placeholder="Password" Text=""></asp:TextBox>
                            <div class="form-control-position">
                                <i class="ft-lock"></i>
                            </div>
                        </fieldset>
                        <fieldset class="form-group position-relative has-icon-left">
                            <asp:TextBox ID="txtconpasswd" name="txtconpasswd" runat="server" TextMode="Password" CssClass="form-control round" placeholder="Confirm Password" Text=""></asp:TextBox>
                            <div class="form-control-position">
                                <i class="ft-lock"></i>
                            </div>
                        </fieldset>
                        <fieldset class="form-group position-relative has-icon-left">
                            <asp:DropDownList ID="ddluserstatus" name="ddluserstatus" runat="server" CssClass="form-control round">
                                <asp:ListItem Text="Active" Value="true"></asp:ListItem>
                                <asp:ListItem Text="In-Active" Value="false"></asp:ListItem>
                            </asp:DropDownList>
                        </fieldset>
                        <fieldset class="form-group position-relative has-icon-left">
                            <div id="lblerr" runat="server" style="color: #FF0000"></div>
                        </fieldset>
                        <%--<div class="form-group row">
                            <div class="col-md-6 col-12 text-center text-sm-left">
                            </div>
                            <div class="col-md-6 col-12 float-sm-left text-center text-sm-right"><a href="recover-password.html" class="card-link">Forgot Password?</a></div>
                        </div>--%>
                        <div class="form-group text-center">
                            <%--<button type="submit" class="btn round btn-block btn-glow btn-bg-gradient-x-blue-green col-12 mr-1 mb-1">Login</button>--%>

                            <asp:Button ID="cmdRegister" runat="server" class="btn btn-danger mr-1" Text="Register" OnClick="cmdRegister_Click" />

                            <asp:Button ID="cmdCancel" runat="server" class="btn btn-primary" Text="Cancel" />
                            <asp:Button ID="cmdLogin" runat="server" class="btn btn-primary" Text="Login" OnClick="cmdLogin_Click" />

                            <%--<button id="cmdLogin" name="cmdLogin" class="btn mybtn">
                                <i class="ft-log-in"></i>Login
                            </button>
                            <button id="cmdCancel" name="cmdCancel" class="btn mybtn-cancel">
                                <i class="ft-x"></i>Cancel
                            </button>--%>
                        </div>

                        <fieldset class="form-group position-relative has-icon-left">
                            <asp:GridView ID="dg" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="450px">
                                <AlternatingRowStyle BackColor="#F7F7F7" />
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID" Visible="false" />
                                    <asp:BoundField DataField="UserID" HeaderText="User ID" />
                                    <asp:BoundField DataField="Password" HeaderText="Password" Visible="false" />
                                    <asp:BoundField DataField="UserStatus" HeaderText="User Status" />
                                    <asp:BoundField DataField="UserType" HeaderText="Admin/User" />
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                                <SortedDescendingHeaderStyle BackColor="#3E3277" />
                            </asp:GridView>
                        </fieldset>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

