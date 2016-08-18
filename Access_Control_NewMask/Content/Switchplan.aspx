<%@ Page Title="<%$ Resources:localizedText, switchPlan %>" Language="C#" MasterPageFile="~/MasterPages/Primary.Master" AutoEventWireup="true" CodeBehind="Switchplan.aspx.cs" Inherits="Access_Control_NewMask.Content.Switchplan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/Switchplan.css" rel="stylesheet" />
    <script src="Scripts/Switchplan.js"></script>
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
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, notincludedinthesolutionmustorderseparate3 %>"></asp:Label>
                </section>
                <section class="btnareabottom" style="display:none;">
                    <asp:Button ID="btnBacktop" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>"  />
                </section>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
      <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBack_Click"  />
    <asp:Button ID="btnHelp" ClientIDMode="Static" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" Style="display: none;" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
