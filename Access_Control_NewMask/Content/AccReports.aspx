<%@ Page Title="<%$ Resources:localizedText, morelistsandlogs %>" Language="C#" MasterPageFile="~/MasterPages/Reports.Master" AutoEventWireup="true" CodeBehind="AccReports.aspx.cs" Inherits="Access_Control_NewMask.Content.AccReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/AccReports.js"></script>
    <link href="Styles/AccReports.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="holdermain">
        <section class="indexTopSec">
            <section class="indexTopSecLeft">
                <section class="indxOneTitle">
                </section>
                <section class="indxOne">
                </section>
                <section class="indxOneFooter">
                </section>
            </section>
            <section class="indexTopSecRight">
                <asp:Button ID="btnPortal" runat="server" Text="" CssClass="btnportal btnHoverssol" Style="display: none;" />
            </section>
        </section>




        <section class="contentholder">
            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, listandprotocol %>" CssClass="toptitle"></asp:Label>
            <section class="indxBttmOne">
                <section class="btnModulesGreen">
                    <asp:Button ID="btnPersonalReportsTop" runat="server" Text="<%$ Resources:localizedText, personell %>" CssClass="topbuttonnew" />

                    <asp:Button ID="btnPersonalReports" runat="server" Text="<%$ Resources:localizedText, protocalnew %>" CssClass="clientpic btnHovers" />
                </section>
                <section class="btnModulesGreen2">
                    <asp:Button ID="btnPersonalAttendanceListTop" runat="server" Text="<%$ Resources:localizedText, personell %>" CssClass="topbuttonnew" />
                    <asp:Button ID="btnPersonalAttendanceList" runat="server" Text="<%$ Resources:localizedText, attendancelistnew %>" CssClass="locationpic btnHovers" />
                </section>
                <section class="btnModulesGreen">
                    <asp:Button ID="btnReportsPersonalAttendancetimestop" runat="server" Text="<%$ Resources:localizedText, personell %>" CssClass="topbuttonnew" />
                    <asp:Button ID="btnReportsPersonalAttendancetimes" runat="server" Text="<%$ Resources:localizedText, attendanceTimes %>" CssClass="depertmentpic btnHovers" />
                </section>
                <section class="btnModulesGreen2">
                    <asp:Button ID="btnReportsPersonalListTop" runat="server" Text="<%$ Resources:localizedText, personell %>" CssClass="topbuttonnew" />
                    <asp:Button ID="btnReportsPersonalList" runat="server" Text="<%$ Resources:localizedText, lists1 %>" CssClass="costcenterpic btnHovers" />
                </section>
                <section class="btnModulesGreen">
                    <asp:Button ID="btnReportPersonalinfoCardTop" runat="server" Text="<%$ Resources:localizedText, personell %>" CssClass="topbuttonnew" />
                    <asp:Button ID="btnReportPersonalinfoCard" runat="server" Text="<%$ Resources:localizedText, idAssignmentChart %>" CssClass="visitorcompanypic btnHovers" />
                </section>

            </section>
            <section class="indxBttmOne">
                <section class="btnModulesgoldarea">
                    <asp:Button ID="btnVisitorReportsTop" runat="server" Text="<%$ Resources:localizedText, visitorTitle %>" CssClass="topbuttonnew" />
                    <asp:Button ID="btnVisitorReports" runat="server" Text="<%$ Resources:localizedText, protocalnew %>" CssClass="visitorlistnewpic btnHovers" />
                </section>
                <section class="btnModulesgoldarea2">
                    <asp:Button ID="btnReportsVisitorHistorytop" runat="server" Text="<%$ Resources:localizedText, visitorTitle %>" CssClass="topbuttonnew" />
                    <asp:Button ID="btnReportsVisitorHistory" runat="server" Text="<%$ Resources:localizedText, history %>" CssClass="calenderpic btnHovers" />
                </section>
               <%-- <section class="btnModulesgoldarea2">
                    <asp:Button ID="btnVisitorCompanyTop" runat="server" Text="<%$ Resources:localizedText, visitorTitle %>" CssClass="topbuttonnew" />
                    <asp:Button ID="btnVisitorCompany" runat="server" Text="<%$ Resources:localizedText, companychanged %>" CssClass="calenderpic btnHovers" />
                </section>--%>
                <section class="btnModulesgoldarea">
                    <asp:Button ID="btnReportsVisitorsAttendanceListtop" runat="server" Text="<%$ Resources:localizedText, visitorTitle %>" CssClass="topbuttonnew" />
                    <asp:Button ID="btnReportsVisitorsAttendanceList" runat="server" Text="<%$ Resources:localizedText, lists1 %>" CssClass="swichtprofilepic btnHovers" />
                </section>

            </section>
            <section class="indxBttmOne">
                <section class="btnModulesRed">
                    <asp:Button ID="btnMembersReportsTop" runat="server" Text="<%$ Resources:localizedText, member %>" CssClass="topbuttonnew" />
                    <asp:Button ID="btnMembersReports" runat="server" Text="<%$ Resources:localizedText, protocalnew %>" CssClass="settingspic btnHovers" />
                </section>
                <section class="btnModulesRed2">
                    <asp:Button ID="btnMembersAttendanceListsTop" runat="server" Text="<%$ Resources:localizedText, member %>" CssClass="topbuttonnew" />
                    <asp:Button ID="btnMembersAttendanceLists" runat="server" Text="<%$ Resources:localizedText, attendancelistnew %>" CssClass="languagepic btnHovers" />
                </section>
                <section class="btnModulesRed3">
                    <asp:Button ID="btnMembersAttendancetimestop" runat="server" Text="<%$ Resources:localizedText, member %>" CssClass="topbuttonnew" />
                    <asp:Button ID="btnMembersAttendancetimes" runat="server" Text="<%$ Resources:localizedText, attendanceTimes %>" CssClass="rightspic btnHovers" />
                </section>
                <section class="btnModulesRed">
                    <asp:Button ID="btnMembersListTop" runat="server" Text="<%$ Resources:localizedText, member %>" CssClass="topbuttonnew" />
                    <asp:Button ID="btnMembersList" runat="server" Text="<%$ Resources:localizedText, lists1 %>" CssClass="passwordpic btnHovers" />
                </section>
                <section class="btnModulesRed2">
                    <asp:Button ID="btnMembersCardInfoTop" runat="server" Text="<%$ Resources:localizedText, member %>" CssClass="topbuttonnew" />
                    <asp:Button ID="btnMembersCardInfo" runat="server" Text="<%$ Resources:localizedText, idAssignmentChart %>" CssClass="passwordpic btnHovers" />
                </section>
            </section>
            <section class="indxBttmOne">
          <%--      <section class="btnModulesbluelast">
                    <asp:Button ID="Button19" runat="server" Text=" " CssClass="accessprofigrouppic btnHovers" />
                </section>
                <section class="btnModulesbluelast2">
                    <asp:Button ID="Button20" runat="server" Text=" " CssClass="accessplangrouppic btnHovers" />
                </section>--%>

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
