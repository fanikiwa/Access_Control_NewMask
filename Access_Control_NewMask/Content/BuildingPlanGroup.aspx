<%@ Page Title="Gebäudeplan-Gruppe" Language="C#" MasterPageFile="~/MasterPages/Secondary.Master" AutoEventWireup="true" CodeBehind="BuildingPlanGroup.aspx.cs" Inherits="Access_Control_NewMask.Content.BuildingPlanGroup" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/BuildingPlanGroup.js"></script>
    <link href="Styles/BuildingPlanGroup.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <asp:HiddenField ID="hiddenFieldFormMode" runat="server" />
    <asp:HiddenField ID="hiddenFieldDetectChanges" runat="server" />
    <div class="grouplanarea">
        <section class="grouplanareasec">
            <section class="grouplantop">
                <asp:Label ID="Label1" runat="server" Text="Gebäudeplan- Gruppen Nr.:" CssClass="lbltop"></asp:Label>
                <dx:ASPxComboBox ID="cboGroupNo" runat="server" ClientInstanceName="cboGroupNo" TextField="AccessGroupNumber" ValueField="Id" EnableCallbackMode="true"
                    TextFormatString="{0}" DropDownRows="20" DropDownWidth="480px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" Theme="Office2003Blue" CssClass="ddlistgrp" OnCallback="cboGroupNo_Callback">
                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
BuildingPlanGroupNumberSelectionChange(s.GetValue());	
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, groupNo4 %>" FieldName="AccessGroupNumber" Width="20%" />
                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, descriptionAccs %>" FieldName="AccessGroupName" Width="80%" />
                    </Columns>
                </dx:ASPxComboBox>
                <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="lbltopnew"></asp:Label>
                <dx:ASPxComboBox ID="cboGroupDescription" runat="server" ClientInstanceName="cboGroupDescription" TextField="AccessGroupName" ValueField="Id" EnableCallbackMode="true"
                    TextFormatString="{1}" DropDownRows="20" DropDownWidth="480px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" Theme="Office2003Blue" CssClass="ddlistgrpsecond" OnCallback="cboGroupDescription_Callback">
                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	BuildingPlanGroupDescriptionSelectionChange(s.GetValue());
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, groupNo4 %>" FieldName="AccessGroupNumber" Width="20%" />
                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, descriptionAccs %>" FieldName="AccessGroupName" Width="80%" />
                    </Columns>
                </dx:ASPxComboBox>
            </section>
            <section class="grouplanfirst">
                <asp:Label ID="Label4" runat="server" Text="Gebäudeplan- Gruppen Nr.:" CssClass="lblbottom"></asp:Label>
                <asp:TextBox ID="txtGroupNo" runat="server" CssClass="txtsecdesc numbersOnly"></asp:TextBox>
            </section>
            <section class="grouplanfirst">
                <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="lblbottom"></asp:Label>
                <asp:TextBox ID="txtGroupName" runat="server" CssClass="txtsecdesc"></asp:TextBox>
            </section>
            <section class="grouplanmemo">
                <asp:Label ID="Label5" runat="server" Text="<%$ Resources:localizedText, memo %>" CssClass="lblheader"></asp:Label>
                <asp:TextBox ID="txtMemo" ClientIDMode="Static" CssClass="txtMemo" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
            </section>
        </section>
    </div>
    <div id="importantInfoDialog" class="dialogBox">
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <section class="grpplnfooter">
        <asp:Button ID="btnNew" CssClass="newbtnfooterblue" runat="server" Text="Gebäudeplan Gruppe neu" Style="width: 164px;" OnClick="btnNew_Click" />
        <asp:Button ID="btnSave" CssClass="savebtnfootergreen" runat="server" Text="Gebäudeplan Gruppe speichern" Style="width: 203px;" OnClick="btnSave_Click" />
        <asp:Button ID="btnDelete" CssClass="deletebtnfooterred" runat="server" Text="Gebäudeplan Gruppe löschen" Style="width: 193px;" OnClick="btnDelete_Click" />
    </section>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="BottomFooterBtnsRight backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBack_Click" />
    <asp:Button ID="btnActHelp" CssClass="BottomFooterBtnsRight helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
