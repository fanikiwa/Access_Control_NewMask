<%@ Page Title="<%$ Resources:localizedText, switchProfilenew %>" Language="C#" MasterPageFile="~/MasterPages/Secondary.Master" AutoEventWireup="true" CodeBehind="Switchprofile.aspx.cs" Inherits="Access_Control_NewMask.Content.Switchprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/Switchprofile.js"></script>
    <link href="Styles/Switchprofile.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div id="Contentareaholder">
        <div class="ControlSectiontoparea">
        </div>
        <div class="ControlSection2bottom">
            <div class="Wrapperdivinfo">
                <section class="infoimgarea">
                </section>
                <section class="lblsoftware">
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, notincludedinthesolutionmustorderseparate2 %>"></asp:Label>
                </section>
                <section class="btnareabottom" style="display:none;">
                    <asp:Button ID="btnBacktop" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>"  OnClick="btnBacktop_Click"/>
                </section>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBack_Click" />
    <asp:Button ID="btnHelp" ClientIDMode="Static" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" Style="display: none;" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
