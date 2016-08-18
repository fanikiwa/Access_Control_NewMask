<%@ Page Title="<%$ Resources:localizedText, settings %>" Language="C#" MasterPageFile="~/MasterPages/Secondary.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="Access_Control_NewMask.Content.Settings" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/Settings.js"></script>
    <link href="Styles/Settings.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="holdermain">
        <section class="contentholder">
            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, settings %>" CssClass="toptitle"></asp:Label>
            <section class="indxBttmOne">
                   <section class="btnModulesGreen4">
                    <asp:Button ID="btnInactivePersonal" runat="server" Text="<%$ Resources:localizedText, personelinavctive %>" CssClass="personalspic btnHovers" />
                </section>
                   <section class="btnModulesGreen5">
                    <asp:Button ID="btnInactiveMember" runat="server" Text="<%$ Resources:localizedText, memberinactive %>" CssClass="memberspic btnHovers" />
                </section>
                <section class="btnModulesGreen2">
                    <asp:Button ID="btnCompany" runat="server" Text="<%$ Resources:localizedText, client %>" CssClass="clientpic btnHovers" />
                </section>
                <section class="btnModulesGreen3">
                    <asp:Button ID="btnLocation" runat="server" Text="<%$ Resources:localizedText, location2 %>" CssClass="locationpic btnHovers" />
                </section>
                <section class="btnModulesGreen2">
                    <asp:Button ID="btnDepartment" runat="server" Text="<%$ Resources:localizedText, departmentsControl %>" CssClass="depertmentpic btnHovers" />
                </section>
                <section class="btnModulesGreen">
                    <asp:Button ID="btnCostCenter" runat="server" Text="<%$ Resources:localizedText, costcenters %>" CssClass="costcenterpic btnHovers" />
                </section>
                <section class="btnModulesGreen2">
                    <asp:Button ID="btnVisitorCompany" runat="server" Text="<%$ Resources:localizedText, visitorCompany %>" CssClass="visitorcompanypic btnHovers" />
                </section>
                <section class="btnModulesGreen">
                    <asp:Button ID="btnVehicles" runat="server" Text="<%$ Resources:localizedText, vehicleTypes %>" CssClass="cartypepic btnHovers" />
                </section>
                <section class="btnModulesGreen3">
                    <asp:Button ID="btnMembersGroup" runat="server" Text="<%$ Resources:localizedText, membersGroups %>" CssClass="studiopic btnHovers" />
                </section>
                <section class="btnModulesGreen2">
                    <asp:Button ID="btnMembersContractDuration" runat="server" Text="<%$ Resources:localizedText, membersCotractDuration %>" CssClass="contractpic btnHovers" />
                </section>
            </section>
            <section class="indxBttmOne">
                <section class="btnModulesgoldarea">
                    <asp:Button ID="btnAccessProfile" runat="server" Text="<%$ Resources:localizedText, accessProfileTitle %>" CssClass="visitorlistnewpic btnHovers" />
                </section>
                <section class="btnModulesgoldarea2">
                    <asp:Button ID="btnAccessCalendar" runat="server" Text="<%$ Resources:localizedText, accessCalendar %>" CssClass="calenderpic btnHovers" />
                </section>
                <section class="btnModulesgoldarea">
                    <asp:Button ID="btnSwitchProfile" runat="server" Text="<%$ Resources:localizedText, switchingProfiles %>" CssClass="swichtprofilepic btnHovers" />
                </section>
                <section class="btnModulesgoldarea2">
                    <asp:Button ID="btnSwitchCalender" runat="server" Text="<%$ Resources:localizedText, switchingCalender %>" CssClass="calenderpic btnHovers" />
                </section>
                <section class="btnModulesgoldarea">
                    <asp:Button ID="btnHolidayCalender" runat="server" Text="<%$ Resources:localizedText, eventCalendar %>" CssClass="calenderpic btnHovers" />
                </section>
                <section class="btnModulesgoldarea2">
                    <asp:Button ID="btnHolidayplan" runat="server" Text="<%$ Resources:localizedText, holidayPlan %>" CssClass="holidayplanpic btnHovers" />
                </section>
            </section>
            <section class="indxBttmOne">
                <section class="btnModulesRed" style="display: none;">
                    <asp:Button ID="btnDashBoardSettings" runat="server" Text="<%$ Resources:localizedText, Dashboardsettings %>" CssClass="settingspic btnHovers" />
                </section>
                <section class="btnModulesRed2">
                    <asp:Button ID="btnLanguage" runat="server" Text="<%$ Resources:localizedText, language %>" CssClass="languagepic btnHovers" />
                </section>
                <section class="btnModulesRed3">
                    <asp:Button ID="btnRights" runat="server" Text="<%$ Resources:localizedText, rightsassign %>" CssClass="rightspic btnHovers" />
                </section>
                <section class="btnModulesRed">
                    <asp:Button ID="btnAssignPassword" runat="server" Text="<%$ Resources:localizedText, rightsSettings %>" CssClass="passwordpic btnHovers" />
                </section>
            </section>
            <section class="indxBttmOne">
                <section class="btnModulesbluelast">
                    <asp:Button ID="btnAccessProfileGroup" runat="server" Text="<%$ Resources:localizedText, accessProfileGrp %>" CssClass="accessprofigrouppic btnHovers" />
                </section>
                <section class="btnModulesbluelast2">
                    <asp:Button ID="btnAccessPlanGroup" runat="server" Text="<%$ Resources:localizedText, accessPlanGrp %>" CssClass="accessplangrouppic btnHovers" />
                </section>
                <section class="btnModulesbluelast" style="display:none;">
                    <asp:Button ID="btnBuildPlanGroup" runat="server" Text="<%$ Resources:localizedText, buildingplangroup %>" CssClass="buildingplangrouppic btnHovers" />
                </section>

            </section>
        </section>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
