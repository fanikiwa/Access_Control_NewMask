<%@ Page Title="<%$ Resources:localizedText, visitorplan %>" Language="C#" MasterPageFile="~/MasterPages/Primary.Master" AutoEventWireup="true" CodeBehind="VisitorPlan.aspx.cs" Inherits="Access_Control_NewMask.Content.VisitorPlan" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/VisitorPlan.css" rel="stylesheet" />
    <script src="Scripts/VisitorPlan.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div id="ControlSecarea" class="ControlSecarea1new2ab">
        <div class="ControlSecarea2">
            <asp:Label runat="server" Text="<%$ Resources:localizedText, accessPlanGroupNo %>" CssClass="planGruppen1" Style="display: none"></asp:Label>
            <asp:DropDownList ID="ddlVisitorGroupNumber" ClientIDMode="Static" DataValueField="Id" DataTextField="AccessGroupNumber"
                runat="server" AutoPostBack="true" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="planGruppen2" Style="display: none">
            </asp:DropDownList>
            <asp:Label runat="server" Text="<%$ Resources:localizedText, groupName %>" CssClass="planGruppen3 addedplan2" Style="display: none"></asp:Label>
            <asp:DropDownList ID="ddlVisitorGroupName" ClientIDMode="Static" DataValueField="Id" DataTextField="AccessGroupName" runat="server"
                AutoPostBack="true" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="planGruppen4" Style="display: none">
            </asp:DropDownList>
            <asp:Label runat="server" Text="<%$ Resources:localizedText, visitorPlannumber %>" CssClass="planGruppen5" Style="text-align: center; min-width: 113px;"></asp:Label>
            <dx:ASPxComboBox ID="ddlVisitorProfileNumber" ClientInstanceName="ddlVisitorProfileNumber" ValueField="ID" TextField="VisitorPlanNr" EnableCallbackMode="true" OnCallback="ddlVisitorProfileNumber_Callback" TextFormatString="{0}" DropDownRows="20" DropDownWidth="400px" runat="server" ValueType="System.String" Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="planGruppen6">
                <ClientSideEvents SelectedIndexChanged="function(s, e) {
profileSelectedChanged(s,e);	
}"
                    DropDown="function(s, e) {
profileDropDown(s,e);	
}"></ClientSideEvents>
                <Columns>
                    <dx:ListBoxColumn Caption="Nr:" Name="VisitorPlanNr" FieldName="VisitorPlanNr" Width="10%" />
                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, description1 %>" Name="VisitorPlanDescription" FieldName="VisitorPlanDescription" Width="90%" />
                </Columns>
            </dx:ASPxComboBox>
            <asp:Label runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="planGruppen7" Style="text-align: right;"></asp:Label>
            <dx:ASPxComboBox ID="ddlVisitorProfileName" ClientInstanceName="ddlVisitorProfileName" ValueField="ID" TextField="VisitorPlanDescription" EnableCallbackMode="true" OnCallback="ddlVisitorProfileName_Callback" TextFormatString="{1}" DropDownRows="20" DropDownWidth="400px" runat="server" Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="planGruppen8">
                <ClientSideEvents SelectedIndexChanged="function(s, e) {
profileSelectedChanged(s,e);	
}"
                    DropDown="function(s, e) {
profileDropDown(s,e);	
}"></ClientSideEvents>
                <Columns>
                    <dx:ListBoxColumn Caption="Nr:" Name="VisitorPlanNr" FieldName="VisitorPlanNr" Width="10%" />
                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, description1 %>" Name="VisitorPlanDescription" FieldName="VisitorPlanDescription" Width="90%" />
                </Columns>
            </dx:ASPxComboBox>
            <asp:Button ID="btnSearchPlans" runat="server" Text="" CssClass="searchzutarea" />

        </div>
        <div class="ControlSecarea3">
            <section class="leftDvns">
                <asp:Label runat="server" Text="<%$ Resources:localizedText, accessPlanGroupNo %>" CssClass="Gruppen1" Style="display: none"></asp:Label>
                <asp:TextBox ID="txtVisitorGroupNumber" ClientIDMode="Static" runat="server" CssClass="Gruppen2" Style="display: none"></asp:TextBox>
                <asp:Label runat="server" Text="<%$ Resources:localizedText, groupName %>" CssClass="Gruppen3 addedgruppen" Style="display: none"></asp:Label>
                <asp:TextBox ID="txtVisitorGroupName" ClientIDMode="Static" runat="server" CssClass="Gruppen4" Style="display: none"></asp:TextBox>
                <asp:Label runat="server" Text="<%$ Resources:localizedText, visitorPlannumber %>" CssClass="planGruppenf" Style="width: 11.8%; min-width: 116px; margin-left: 13px;"></asp:Label>
                <asp:TextBox ID="txtVisitorProfileNumber" ClientIDMode="Static" runat="server" CssClass="Gruppenf"></asp:TextBox>
                <asp:Label runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="planGruppeng"></asp:Label>
                <asp:TextBox ID="txtVisitorProfileName" ClientIDMode="Static" runat="server" CssClass="Gruppeng"></asp:TextBox>

            </section>
            <section class="rightDvns">
                <asp:Button ID="btnPersonnel" runat="server" Text="<%$ Resources:localizedText, visitorTitle %>" CssClass="Personenbutton2" Style="display: none;"></asp:Button>
                <img src="../Images/FormImages/arrowpoint.png" class="arrowpoint" style="display: none;" />
                <asp:Label runat="server" Text="<%$ Resources:localizedText, settingsaccess %>" CssClass="settings"></asp:Label>
                <asp:Button ID="btnReader" runat="server" Text="<%$ Resources:localizedText, reader %>" CssClass="newstandardbutton Leserbutton2" Style="width: 11%; min-width: 79px;" OnClick="btnReader_Click"></asp:Button>
                <img src="../Images/FormImages/arrowpoint.png" class="arrowpoint" />
                <asp:Button ID="btnAccessProfile" runat="server" Text="<%$ Resources:localizedText, accessCalendar%>" CssClass="newstandardbutton Zutrittsprofilbutton2" Style="width: 23%;" OnClick="btnAccessProfile_Click"></asp:Button>
                <img src="../Images/FormImages/arrowpoint.png" class="arrowpoint" style="display: none;" />
                <asp:Button ID="btnHoliday" runat="server" Text="<%$ Resources:localizedText, holidaySchedule%>" CssClass="newstandardbutton Zutrittsprofilbutton2holiday" Style="display: none;"></asp:Button>
            </section>
        </div>
    </div>

    <div id="importantDialog" class="dialogBox">
    </div>

    <div id="wrapperaccess1" class="wrapperaccess1newab">

        <section class="Wrapperaccessmain">
            <section class="sectop">
                <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, information %>"></asp:Label>
            </section>
            <section class="secbottom">
                <section class="personenarea" style="width: 22%;">
                    <section class="zutplanebuttonarea" style="display: none;">
                        <asp:Button runat="server" ID="btnPersonen" Text="<%$ Resources:localizedText, visitorTitle %>" CssClass="Personenbutton"></asp:Button>
                    </section>
                    <section style="display: none;">

                        <asp:ImageButton runat="server" ID="imageBtnPersonen" class="Personenbackarea"></asp:ImageButton>

                    </section>
                </section>
                <section class="leserarea" style="margin-right: 4%;">
                    <section class="zutplanebuttonarea">
                        <asp:Button runat="server" ID="btnReaderHeader" Text="<%$ Resources:localizedText, reader %>" CssClass="Leserbutton" OnClick="btnReaderHeader_Click"></asp:Button>
                    </section>
                    <section>

                        <asp:ImageButton runat="server" ID="imageBtnReader" class="Leserbackarea" OnClick="imageBtnReader_Click"></asp:ImageButton>

                    </section>
                </section>
                <section class="zutrittsprofilarea">
                    <section class="zutplanebuttonarea">
                        <asp:Button runat="server" ID="btnAccessCalederHeader" Text="<%$ Resources:localizedText, accessCalendar%>" CssClass="Zutrittsprofilbutton" OnClick="btnAccessCalederHeader_Click"></asp:Button>
                    </section>
                    <section>

                        <asp:ImageButton runat="server" ID="imageBtnAccessCalender" class="Zutrittsprofilbackarea" OnClick="imageBtnAccessCalender_Click"></asp:ImageButton>

                    </section>

                </section>
                <section class="zutrittsprofilareanew" style="display: none;">
                    <section class="zutplanebuttonarea">
                        <asp:Button runat="server" ID="btnHolidayCalenderHeader" Text="<%$ Resources:localizedText, holidaySchedule%>" CssClass="Zutrittsprofilbuttonholiday"></asp:Button>
                    </section>
                    <section style="display: none;">
                        <asp:ImageButton runat="server" ID="imageBtnHolidayCalender" class="Zutrittsprofilbackareanew"></asp:ImageButton>

                    </section>
                </section>
            </section>
        </section>

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnEntNew" CssClass="newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newvisitorplan %>" Style="width: 124px;" />
    <%-- <asp:Button ID="btnEntEdit" CssClass="BottomFooterBtnsLeft btnEdit" runat="server" Text="<%$ Resources:localizedText, editing %>"  />--%>
    <asp:Button ID="btnEntSave" ClientIDMode="Static" CssClass="savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, savevisitorplan %>" Style="width: 158px;" />
    <asp:Button ID="btnCancelDel" CssClass="deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deletevisitorplan %>" Style="width: 150px;" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" ClientIDMode="Static" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
