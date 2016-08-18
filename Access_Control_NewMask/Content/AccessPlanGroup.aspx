<%@ Page Title="<%$ Resources:localizedText, accessgroups %>" Language="C#" MasterPageFile="~/MasterPages/Primary.Master" AutoEventWireup="true" CodeBehind="AccessPlanGroup.aspx.cs" Inherits="Access_Control_NewMask.Content.AccessPlanGroup" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/AccessPlanGroup.js"></script>
    <link href="Styles/AccessPlanGroup.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div id="ControlSecarea" class="ControlSecarea1new2ab">
        <div class="ControlSecarea2">
            <asp:Label runat="server" Text="<%$ Resources:localizedText, accessPlanGroupNo %>" CssClass="planGruppen1" Style="display: none"></asp:Label>
            <asp:Label runat="server" Text="<%$ Resources:localizedText, accessgroupno %>" CssClass="accessgroupnum"></asp:Label>
            <dx:ASPxComboBox ID="ddlAccessGroupNumber" ClientInstanceName="ddlAccessGroupNumber" ValueField="ID" TextField="AccessPlanGroupNr" EnableCallbackMode="true" OnCallback="ddlAccessGroupNumber_Callback" CallbackPageSize="100000" TextFormatString="{0}" DropDownRows="20" DropDownWidth="400px" runat="server" ValueType="System.String" Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="planGruppen6">
                <ClientSideEvents SelectedIndexChanged="function(s, e) {
planGroupSelectedChanged(s,e);	
}"
                    DropDown="function(s, e) {
planGroupDropDown(s,e);	
}"></ClientSideEvents>
                <Columns>
                    <dx:ListBoxColumn Caption="Nr:" Name="AccessPlanGroupNr" FieldName="AccessPlanGroupNr" Width="10%" />
                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, description1 %>" Name="AccessPlanGroupName" FieldName="AccessPlanGroupName" Width="90%" />
                </Columns>
            </dx:ASPxComboBox>
            <asp:Label runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="planGruppen7" Style="text-align: right;"></asp:Label>
            <dx:ASPxComboBox ID="ddlAccessGroupName" ClientInstanceName="ddlAccessGroupName" ValueField="ID" TextField="AccessPlanGroupName" EnableCallbackMode="true" OnCallback="ddlAccessGroupName_Callback" CallbackPageSize="100000" TextFormatString="{1}" DropDownRows="20" DropDownWidth="400px" runat="server" Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="planGruppen8">
                <ClientSideEvents SelectedIndexChanged="function(s, e) {
planGroupSelectedChanged(s,e);	
}"
                    DropDown="function(s, e) {
planGroupDropDown(s,e);	
}"></ClientSideEvents>
                <Columns>
                    <dx:ListBoxColumn Caption="Nr:" Name="AccessPlanGroupNr" FieldName="AccessPlanGroupNr" Width="10%" />
                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, description1 %>" Name="AccessPlanGroupName" FieldName="AccessPlanGroupName" Width="90%" />
                </Columns>
            </dx:ASPxComboBox>
            <asp:Button ID="btnSearchPlans" runat="server" Text="" CssClass="searchzutarea" />

        </div>
        <div class="ControlSecarea3">
            <section class="leftDvns">
                <asp:Label runat="server" Text="<%$ Resources:localizedText, accessgroupno %>" CssClass="accessgroupnumbottom"></asp:Label>
                <asp:TextBox ID="txtAccessGroupNumber" ClientIDMode="Static" runat="server" CssClass="Gruppenf"></asp:TextBox>
                <asp:Label runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="planGruppeng"></asp:Label>
                <asp:TextBox ID="txtAccessGroupName" ClientIDMode="Static" runat="server" CssClass="Gruppeng"></asp:TextBox> 
            </section>
            <section class="rightDvns">
                <asp:Button ID="btnPersonnel" runat="server" Text="<%$ Resources:localizedText, visitorTitle %>" CssClass="Personenbutton2" Style="display: none;" Visible="false"></asp:Button>
                <img src="../Images/FormImages/arrowpoint.png" class="arrowpoint" style="display: none;" />
                <asp:Label runat="server" Text=" " CssClass="settings" Style="margin-left: 6%;"></asp:Label>
                <asp:Button ID="btnReader" runat="server" Text="<%$ Resources:localizedText, reader %>" CssClass="newstandardbutton Leserbutton2" Style="width: 11%; min-width: 54px;"></asp:Button>
                <img src="../Images/FormImages/arrowpoint.png" class="arrowpoint" />
                <asp:Button ID="btnAccessProfile" runat="server" Text="<%$ Resources:localizedText, accessCalendar%>" CssClass="newstandardbutton Zutrittsprofilbutton2" Style="width: 23%;"></asp:Button>
                <img src="../Images/FormImages/arrowpoint.png" class="arrowpoint" />
                <asp:Button ID="btnHoliday" runat="server" Text="<%$ Resources:localizedText, holidaySchedule%>" CssClass="newstandardbutton Zutrittsprofilbutton2holiday"></asp:Button>
            </section>
        </div>
    </div>

    <div id="importantDialog" class="dialogBox">
    </div>

    <div id="wrapperaccess1" class="wrapperaccess1newab">

        <section class="Wrapperaccessmain">
            <section class="sectop">
                <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, settings %>"></asp:Label>
            </section>
            <section class="secbottom">
                <section class="personenarea" style="width: 7%;">
                    <section class="zutplanebuttonarea" style="display: none;">
                        <asp:Button runat="server" ID="btnPersonen" Text="<%$ Resources:localizedText, visitorTitle %>" CssClass="Personenbutton"></asp:Button>
                    </section>
                    <section style="display: none;">

                        <asp:ImageButton runat="server" ID="imageBtnPersonen" class="Personenbackarea"></asp:ImageButton>

                    </section>
                </section>
                <section class="leserarea" style="margin-right: 4%;">
                    <section class="zutplanebuttonarea">
                        <asp:Button runat="server" ID="btnReaderHeader" Text="<%$ Resources:localizedText, reader %>" CssClass="Leserbutton"></asp:Button>
                    </section>
                    <section>

                        <asp:ImageButton runat="server" ID="imageBtnReader" class="Leserbackarea"></asp:ImageButton>

                    </section>
                </section>
                <section class="zutrittsprofilarea">
                    <section class="zutplanebuttonarea">
                        <asp:Button runat="server" ID="btnAccessCalederHeader" Text="<%$ Resources:localizedText, accessCalendar%>" CssClass="Zutrittsprofilbutton"></asp:Button>
                    </section>
                    <section>

                        <asp:ImageButton runat="server" ID="imageBtnAccessCalender" class="Zutrittsprofilbackarea"></asp:ImageButton>

                    </section>

                </section>
                <section class="zutrittsprofilareanew">
                    <%--style="display: none;"--%>
                    <section class="zutplanebuttonarea">
                        <asp:Button runat="server" ID="btnHolidayCalenderHeader" Text="<%$ Resources:localizedText, holidaySchedule%>" CssClass="Zutrittsprofilbuttonholiday"></asp:Button>
                    </section>
                    <section>
                        <asp:ImageButton runat="server" ID="imageBtnHolidayCalender" class="Zutrittsprofilbackareanew"></asp:ImageButton>

                    </section>
                </section>
            </section>
        </section>

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnEntNew" CssClass="newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newaccessgroup %>" Style="width: 124px;" />
    <asp:Button ID="btnEntSave" ClientIDMode="Static" CssClass="savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, saveaccessgroup %>" Style="width: 158px;" />
    <asp:Button ID="btnCancelDel" CssClass="deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deleteaccessgroup %>" Style="width: 150px;" />

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" ClientIDMode="Static" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
