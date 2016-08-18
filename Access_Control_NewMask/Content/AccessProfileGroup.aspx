<%@ Page Title="<%$ Resources:localizedText, accessprofilgroup %>" Language="C#" MasterPageFile="~/MasterPages/Secondary.Master" ClientIDMode="Static" AutoEventWireup="true" CodeBehind="AccessProfileGroup.aspx.cs" Inherits="Access_Control_NewMask.Content.AccessProfileGroup" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/AccessProfileGroup.css" rel="stylesheet" />
    <script src="Scripts/AccessProfileGroup.js"></script>
    <%--<link href="Styles/ImportantInfoDialogVer2.css" rel="stylesheet" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <asp:HiddenField ID="hiddenFieldFormMode" runat="server" />
    <asp:HiddenField ID="hiddenFieldDetectChanges" runat="server" />
    <div class="Wrappernew1">
        <section class="topsec">
            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, groupNo2 %>" CssClass="planGruppen1"></asp:Label>
            <dx:ASPxComboBox ID="cboGroupNo" ClientIDMode="Static" ClientInstanceName="cboGroupNo" TextField="AccessGroupNumber" ValueField="Id" runat="server" CssClass="planGruppen2" EnableCallbackMode="true" Theme="Office2003Blue"
                TextFormatString="{0}" DropDownRows="20" DropDownWidth="480px" SelectedIndex="0" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" OnCallback="cboGroupNo_Callback">
                <ClientSideEvents SelectedIndexChanged="function(s, e) {
GroupNumberSelectionChange(s.GetValue());	
}"></ClientSideEvents>
                <Columns>
                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, groupNo4 %>" FieldName="AccessGroupNumber" Width="20%" />
                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, descriptionAccs %>" FieldName="AccessGroupName" Width="80%" />
                </Columns>
            </dx:ASPxComboBox>
            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, descriptionAccs %>" CssClass="planGruppen3"></asp:Label>
            <dx:ASPxComboBox ID="cboGroupDescription" ClientIDMode="Static" ClientInstanceName="cboGroupDescription" TextField="AccessGroupName" ValueField="Id" runat="server" CssClass="planGruppen8" EnableCallbackMode="true" Theme="Office2003Blue"
                TextFormatString="{1}" DropDownRows="20" DropDownWidth="480px" SelectedIndex="0" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" OnCallback="cboGroupDescription_Callback">
                <ClientSideEvents SelectedIndexChanged="function(s, e) {
	GroupDescriptionSelectionChange(s.GetValue());
}"></ClientSideEvents>
                <Columns>
                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, groupNo4 %>" FieldName="AccessGroupNumber" Width="20%" />
                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, descriptionAccs %>" FieldName="AccessGroupName" Width="80%" />
                </Columns>
            </dx:ASPxComboBox>
        </section>
        <section class="mainHolder">
            <section class="bottom">
                <section class="bottom2top">
                    <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, groupNo4 %>" CssClass="bottom2toplbl"></asp:Label>
                    <asp:TextBox ID="txtGroupNo" runat="server" CssClass="bottom2toptextbox numbersOnly"></asp:TextBox>
                </section>
                <section class="bottom2profil">
                    <asp:Label ID="Label5" runat="server" Text="<%$ Resources:localizedText, descriptionAccs  %>" CssClass="bottom2toplbl"></asp:Label>
                    <asp:TextBox ID="txtGroupName" runat="server" CssClass="bottom2toptextbox"></asp:TextBox>
                </section>
            </section>
            <section class="bottom3">
                <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, memo %>" CssClass="lbl"></asp:Label>
                <asp:TextBox ID="txtMemo" runat="server" CssClass="memo" TextMode="MultiLine"></asp:TextBox>
            </section>
        </section>

    </div>
    <div id="importantInfoDialog" class="dialogBox">
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <section class="secFooterSprache">
        <asp:Button ID="btnEntNew" CssClass="BottomFooterBtnsLeft newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newaccessprofilegroup %>" Style="width: 166px; margin-top: 0px;" OnClick="btnEntNew_Click" />
        <asp:Button ID="btnEntSave" CssClass="BottomFooterBtnsLeft savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, saveaccessprofilegroup %>" Style="width: 190px; margin-top: 0px;" OnClick="btnEntSave_Click" />
        <asp:Button ID="btnCancelDel" CssClass="BottomFooterBtnsLeft deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deleteaccessprofilegroup %>" Style="width: 185px; margin-top: 0px;" OnClick="btnCancelDel_Click" />
    </section>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBackFooter" CssClass="BottomFooterBtnsRight backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBackFooter_Click" />
    <asp:Button ID="btnActHelp" CssClass="BottomFooterBtnsRight helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
