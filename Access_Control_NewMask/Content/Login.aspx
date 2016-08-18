<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Access_Control_NewMask.Content.Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/Login.css" rel="stylesheet" />
    <script src="Scripts/Login.js"></script>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
    <div id="Contentbottomarea2">
        <div id="loginWrapper" style="font-weight: 600;">
            <div id="TopLevel"></div>

            <div id="MidLevel">
                <section class="TopMidLevelLayer">
                    <section class="cautionText">
                        <asp:Label ID="lblLogintext" runat="server"
                            Text="<%$ Resources:localizedText, signin%> "></asp:Label>
                    </section>
                </section>

                <section class="MidLevelLayer">
                    <asp:Label ID="LblUser" runat="server" class="labelStyleLayerOne" Text="<%$ Resources:localizedText, userName%> "></asp:Label>
                    <asp:TextBox ID="TxtUser" ClientIDMode="Static" runat="server" class="textBoxStyleOne"></asp:TextBox>
                </section>

                <section class="MidLevelLayer" style="margin-top: 5%; margin-bottom: 5%;">
                    <asp:Label ID="LblPassword" runat="server" class="labelStyleLayerTwo" Text="<%$ Resources:localizedText, password2%> "></asp:Label>
                    <asp:TextBox ID="TxtPassword" ClientIDMode="Static" runat="server" class="textBoxStyleTwo" TextMode="Password"></asp:TextBox>
                </section>

                <div id="BottomLevel">
                    <section class="emptyLayer"></section>

                    <section class="buttonLayer">
                        <section class="bgSetter">
                            <asp:Button ID="BtnLogin" Text="<%$ Resources:localizedText, login%>" CssClass="buttonStyle" runat="server" OnClientClick="if($('#TxtUser').val()==''||$('#TxtPassword').val()==''){return false;}else{return true;}" OnClick="BtnLogin_Click" />
                        </section>
                    </section>
                </div>
            </div>
        </div>

        <div id="loginCredentials" style="font-weight: 600; display: none;">
            <div id="secMidLevel">
                <section class="MidLevelLayer">
                    <asp:Label ID="lblUserNameDetailsTitle" runat="server" class="labelStyleLayerOneNew" Text="<%$ Resources:localizedText, userName%> "></asp:Label>
                    <asp:Label ID="lblUserNameDetails" runat="server" class="labelStyleLayerOneNew2" Text="9901"></asp:Label>
                </section>

                <section class="MidLevelLayer">
                    <asp:Label ID="lblUserPassTitle" runat="server" class="labelStyleLayerTwoNew" Text="<%$ Resources:localizedText, password2%> "></asp:Label>
                    <asp:Label ID="lblUserPass" runat="server" class="labelStyleLayerTwoNew2" Text="1234"></asp:Label>
                </section>
                <div id="secBottomLevel">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
