<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Access_Control_NewMask.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/Index.js"></script>
    <link href="Styles/Index.css" rel="stylesheet" />
    <script type="text/javascript">
        function setZUT_AUTH(_username, _password) {
            ASPxClientUtils.DeleteCookie("ZUT_AUTH");
            ASPxClientUtils.SetCookie('ZUT_AUTH', 'username:' + _username + '#password:' + _password, moment().add(1, 'day').toDate());
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="indexMainHolder">
        <section class="indexTopSec">
            <section class="indexTopSecLeft">
                <section class="indxOneTitle">
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, installedSoftware %>" CssClass="lblSoftwareHeader"></asp:Label>
                </section>
                <section class="indxOne">
                    <asp:Button ID="btnTermKonfig" runat="server" Text="" CssClass="btntmk btnHovers" OnClick="btnTermKonfig_Click" />
                    <asp:Button ID="btnVisitors" runat="server" Text="" CssClass="btnvis btnHovers" OnClick="btnVisitors_Click" />
                </section>
                <section class="indxOneFooter">
                    <%-- <asp:Label ID="Label2" runat="server" Text="Zutritt" CssClass="lblNameOfModule"></asp:Label>
                    <asp:Label ID="Label5" runat="server" Text="Termkonfig" CssClass="lblNameOfModule"></asp:Label>--%>
                </section>
            </section>
            <section class="indexTopSecRight">
                <asp:Button ID="btnPortal" runat="server" Text="" CssClass="btnportal btnHoverssol" />
            </section>
        </section>
        <section class="indexBttmSec">
            <section class="indexTopSecLeft resize">
                <section class="indxBttmOneTitle">
                    <asp:Label ID="Label3" runat="server" CssClass="lblTitle" Text="<%$ Resources:localizedText, accessControlCloudVersion %>"></asp:Label>
                </section>
                <section class="indxBttmOne">
                    <section class="btnModulesBlue">
                        <asp:Button ID="btnSettings" runat="server" Text="<%$ Resources:localizedText, settings %>" CssClass="settingspic btnHovers" />
                    </section>
                    <section class="btnModulesYellow">
                        <asp:Button ID="btnGateMonitor" runat="server" Text="<%$ Resources:localizedText, gateMonitor %>" CssClass="gatepic btnHovers" />
                    </section>
                    <section class="btnModulesGreen">
                        <asp:Button ID="btnPersonal" runat="server" Text="<%$ Resources:localizedText, personell %>" CssClass="personalspic btnHovers" />
                    </section>
                    <section class="btnModulesmembers3">
                        <asp:Button ID="btnMembers" runat="server" Text="<%$ Resources:localizedText, members %>" CssClass="memberspic btnHovers" />
                    </section>
                    <section class="btnModulesnewGreen">
                        <asp:Button ID="btnBuildingPlan" runat="server" Text="<%$ Resources:localizedText, buildingPlan %>" CssClass="buildingplanpic btnHovers" />
                    </section>
                    <section class="btnModulesGreen">
                        <asp:Button ID="btnAccessGroup" runat="server" Text="<%$ Resources:localizedText, accessgroups %>" CssClass="accessgroup btnHovers" />
                    </section>
                    <section class="btnModulesGreen2">
                        <asp:Button ID="btnAccessPlan" runat="server" Text="<%$ Resources:localizedText, accessPlans %>" CssClass="accessplanpic btnHovers" />
                    </section>
                    <section class="btnModulesGreen3">
                        <asp:Button ID="btnSwitchPlan" runat="server" Text="<%$ Resources:localizedText, switchPlan %>" CssClass="switchplanpic btnHovers" />
                    </section>
                </section>
                <section class="indxBttmOne">
                    <section class="btnModulesGreenblue2">
                        <asp:Button ID="btnVisitorData" runat="server" Text="<%$ Resources:localizedText, visitorsData %>" CssClass="visitordatapic btnHovers" />
                    </section>
                    <section class="btnModulesGreenblue">
                        <asp:Button ID="btnVisitApplications" runat="server" Text="<%$ Resources:localizedText, applicatns %>" CssClass="visitorapplicationpic btnHovers" />
                    </section>
                    <section class="btnModulesGreenblue2">
                        <asp:Button ID="btnVisitorPlan" runat="server" Text="<%$ Resources:localizedText, visitorplan %>" CssClass="visitorplanpic btnHovers" />
                    </section>
                </section>
                <section class="indxBttmOne">
                    <section class="btnModulesRed">
                        <asp:Button ID="btnAccessCorrections" runat="server" Text="<%$ Resources:localizedText, accessCorrections %>" CssClass="accesscorrectionpic btnHovers" />
                    </section>
                    <section class="btnModulesRed3">
                        <asp:Button ID="btnDisplayPanel" runat="server" Text="<%$ Resources:localizedText, displayPanel %>" CssClass="displaypanelpic btnHovers" />
                    </section>
                    <section class="btnModulesRed">
                        <asp:Button ID="btnAlarmFunction" runat="server" Text="<%$ Resources:localizedText, alarmdooropen %>" CssClass="alarmpic btnHovers" />
                    </section>

                </section>
                <section class="indxBttmOne">
                    <section class="btnModulesRedlast2">
                        <%--btnModulesRedlast2--%>
                        <asp:Button ID="btnProtocollist" runat="server" Text="<%$ Resources:localizedText, morenew %>" CssClass="topbuttonnew" />
                        <asp:Button ID="btnListProtocol" runat="server" Text="<%$ Resources:localizedText, otherLists %>" CssClass="otherspic btnHovers" />
                    </section>
                    <section class="btnModulesRed2" style="display:none;">
                        <asp:Button ID="btnGetBookings" runat="server" Text="<%$ Resources:localizedText, getdata %>" CssClass="receivedatapic btnHovers" />
                    </section>
                    <section class="btnModulesRed2purple" style="display:none;">
                        <asp:Button ID="btnSendData" runat="server" Text="<%$ Resources:localizedText, senddata %>" CssClass="senddatapic btnHovers" />
                    </section>
                    <section class="btnModulesRed2">
                        <asp:Button ID="btndatacommmanual" runat="server" Text="<%$ Resources:localizedText, datacommmanual %>" CssClass="datemnanualpic btnHovers" />
                    </section>







                    <section class="btnModulesRedlast" style="display: none;">
                        <asp:Button ID="Button3" runat="server" Text="<%$ Resources:localizedText, personell %>" CssClass="topbuttonnew" />
                        <asp:Button ID="btnProtocol" runat="server" Text="<%$ Resources:localizedText, protocal %>" CssClass="accessprotocalpic btnHovers" />
                    </section>
                    <section class="btnModulesRedlast2" style="display: none;">
                        <asp:Button ID="Button4" runat="server" Text="<%$ Resources:localizedText, member %>" CssClass="topbuttonnew" />
                        <asp:Button ID="btnOtherLists" runat="server" Text="<%$ Resources:localizedText, protocal %>" CssClass="morelistnewpic btnHovers" />
                    </section>
                    <section class="btnModulesRedlast" style="display: none;">
                        <asp:Button ID="Button5" runat="server" Text="<%$ Resources:localizedText, visitorTitle %>" CssClass="topbuttonnew" />
                        <asp:Button ID="btnVisitorList" runat="server" Text="<%$ Resources:localizedText, protocal %>" CssClass="visitorlistenpic btnHovers" />
                    </section>

                </section>
                <%--         <section class="indxBttmOne">
                    <asp:Button ID="Button1" runat="server" Text="" CssClass="btnModulesRedlast btnHovers" />
                    <asp:Button ID="Button2" runat="server" Text="" CssClass="btnModulesRedlast btnHovers"  />
                    <asp:Button ID="Button5" runat="server" Text="" CssClass="btnModulesRedlast btnHovers" />
                </section>--%>
            </section>
            <section class="indexTopSecRight"></section>
        </section>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
