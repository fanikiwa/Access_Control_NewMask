<%@ Page Title="<%$ Resources:localizedText, rightsassign %>" Language="C#" MasterPageFile="~/MasterPages/Secondary.Master" AutoEventWireup="true" CodeBehind="RightsAssignment.aspx.cs" Inherits="Access_Control_NewMask.Content.RightsAssignment" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/RightsAssignment.css" rel="stylesheet" />
    <script src="Scripts/RightsAssignment.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="mainSection">
        <div class="secTop">
            <section class="secTopBckGreen">
                <section class="secLeft">
                    <asp:Label ID="Label14" runat="server" Text="<%$ Resources:localizedText, rightNo %>" CssClass="lblRightNr"></asp:Label>
                    <dx:ASPxComboBox ID="cmbProfileNr" runat="server" CssClass="ddlRightNr" Theme="Office2003Blue" ValueField="ID" TextField="ProfileNr" TextFormatString="{0}"
                        DropDownWidth="500px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" AutoPostBack="true"
                        OnValueChanged="cmbProfileNr_SelectedIndexChanged">
                        <Columns>
                            <dx:ListBoxColumn FieldName="ProfileNr" Name="Nr." Width="10%" Caption="Nr.:" ToolTip="Nr."></dx:ListBoxColumn>
                            <dx:ListBoxColumn FieldName="ProfileDescription" Name="Bezeichnung" Width="90%" Caption="Bezeichnung:" ToolTip="ProfileDescription"></dx:ListBoxColumn>
                        </Columns>
                    </dx:ASPxComboBox>

                    <asp:Label ID="Label17" runat="server" Text="<%$ Resources:localizedText, descriptionnew %>" CssClass="lblRightdscptn"></asp:Label>
                    <dx:ASPxComboBox ID="cmbProfileDesc" runat="server" CssClass="ddlDscptn" Theme="Office2003Blue" ValueField="ID" TextField="ProfileDescription" TextFormatString="{1}"
                        DropDownWidth="500px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" AutoPostBack="true"
                        OnValueChanged="cmbProfileDesc_SelectedIndexChanged">
                        <Columns>
                            <dx:ListBoxColumn FieldName="ProfileNr" Name="Nr." Width="10%" Caption="Nr.:" ToolTip="Nr."></dx:ListBoxColumn>
                            <dx:ListBoxColumn FieldName="ProfileDescription" Name="Bezeichnung" Width="90%" Caption="Bezeichnung:" ToolTip="Bezeichnung"></dx:ListBoxColumn>
                        </Columns>
                    </dx:ASPxComboBox>

                    <section style="float: right; margin-top: 10px; font-size: 14px; font-weight: bold;">
                        <asp:Label runat="server" Text="<%$ Resources:localizedText, readl %>" Style="clear: none;"></asp:Label>
                        <asp:Label runat="server" Text="<%$ Resources:localizedText, editb %>" Style="clear: none; margin-left: 20px;"></asp:Label>
                    </section>
                </section>
                <section class="secRight">
                    <asp:Button ID="btnSearch" ClientIDMode="Static" runat="server" Text="" CssClass="searchzutarea" />
                </section>
            </section>
            <section class="secTopBcYllw">
                <section class="secLeft">
                    <asp:Label ID="Label15" runat="server" Text="<%$ Resources:localizedText, rightNo %>" CssClass="lblRightNr"></asp:Label>
                    <asp:TextBox ID="txtProfileNr" runat="server" CssClass="txtRightNr"></asp:TextBox>

                    <asp:Label ID="Label16" runat="server" Text="<%$ Resources:localizedText, descriptionnew %>" CssClass="lblRightdscptn"></asp:Label>
                    <asp:TextBox ID="txtProfileDesc" runat="server" CssClass="txtRightDscptn"></asp:TextBox>
                </section>
                <section class="secRight"></section>
            </section>
        </div>
        <div class="secBttm">
            <section class="tableSec">
                <asp:Table CellPadding="0" CellSpacing="0" runat="server" CssClass="mainTbl">
                    <asp:TableRow CssClass="tblRwH">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:Label ID="Label1" runat="server" Text="L" CssClass="lblTblCellL"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:Label ID="Label2" runat="server" Text="B" CssClass="lblTblCellL"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:Label ID="Label3" runat="server" Text="L" CssClass="lblTblCellL"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:Label ID="Label4" runat="server" Text="B" CssClass="lblTblCellL"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:Label ID="Label13" runat="server" Text="L" CssClass="lblTblCellL"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:Label ID="Label5" runat="server" Text="B" CssClass="lblTblCellL"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:Label ID="Label10" runat="server" Text="L" CssClass="lblTblCellL"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:Label ID="Label6" runat="server" Text="B" CssClass="lblTblCellL"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3">
                            <asp:Label ID="lblTMK" runat="server" Text="Service Studio" CssClass="lblTblCellTitle"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkTMKRead" runat="server" CssClass="chkCell2 areared1" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkTMKEdit" runat="server" CssClass="chkCell2 areared1" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3">
                            <asp:Label ID="lblZUT" runat="server" Text="<%$ Resources:localizedText, access %>" CssClass="lblTblCellTitle2"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkZUTRead" runat="server" CssClass="chkCell2 areared1 areablue1" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkZUTEdit" runat="server" CssClass="chkCell2 areared1 areablue1" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblSettings" runat="server" Text="<%$ Resources:localizedText, settings %>" CssClass="lblTblCellTitle2"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkSettingsRead" runat="server" CssClass="chkCell4 zutChkRead areablue1" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkSettingsEdit" runat="server" CssClass="chkCell4 zutChkEdit areablue1" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblGateMonitor" runat="server" Text="<%$ Resources:localizedText, gateMonitor %>" CssClass="lblTblCellTitle2"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkGateMonitorRead" runat="server" CssClass="chkCell4 zutChkRead areablue1" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkGateMonitorEdit" runat="server" CssClass="chkCell4 zutChkEdit areablue1" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblGrader" runat="server" Text="<%$ Resources:localizedText, accessCorrections %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkGraderRead" runat="server" CssClass="chkCell4 zutChkRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkGraderEdit" runat="server" CssClass="chkCell4 zutChkEdit" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblPersInactive" runat="server" Text="<%$ Resources:localizedText, personelinavctive %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkPersInactiveRead" runat="server" CssClass="chkCell zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkPersInactiveEdit" runat="server" CssClass="chkCell zutChkEdit zutSettingsEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblGateMonitorPers" runat="server" Text="<%$ Resources:localizedText, personnelcheck %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkGateMonitorPersRead" runat="server" CssClass="chkCell zutChkRead gateMonitorRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkGateMonitorPersEdit" runat="server" CssClass="chkCell zutChkEdit gateMonitorEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblDisplayPanel" runat="server" Text="<%$ Resources:localizedText, displayPanel %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkDisplayPanelRead" runat="server" CssClass="chkCell zutChkRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkDisplayPanelEdit" runat="server" CssClass="chkCell zutChkEdit" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblMembersInactive" runat="server" Text="<%$ Resources:localizedText, memberinactive %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkMembersInactiveRead" runat="server" CssClass="chkCell3 zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkMembersInactiveEdit" runat="server" CssClass="chkCell3 zutChkEdit zutSettingsEdit  " />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblGateMonitorMembers" runat="server" Text="<%$ Resources:localizedText, memberscheck %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkGateMonitorMembersRead" runat="server" CssClass="chkCell3 zutChkRead gateMonitorRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkGateMonitorMembersEdit" runat="server" CssClass="chkCell3 zutChkEdit gateMonitorEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblAlarmDoorOpen" runat="server" Text="<%$ Resources:localizedText, alarmdooropen %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkAlarmDoorOpenRead" runat="server" CssClass="chkCell3 zutChkRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkAlarmDoorOpenEdit" runat="server" CssClass="chkCell3 zutChkEdit" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblClients" runat="server" Text="<%$ Resources:localizedText, client2 %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkClientsRead" runat="server" CssClass="chkCell zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkClientsEdit" runat="server" CssClass="chkCell zutChkEdit zutSettingsEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblGateMonitorVisitors" runat="server" Text="<%$ Resources:localizedText, visitor %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkGateMonitorVisitorsRead" runat="server" CssClass="chkCell3 zutChkRead gateMonitorRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkGateMonitorVisitorsEdit" runat="server" CssClass="chkCell3 zutChkEdit gateMonitorEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">

                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">

                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">

                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblLocations" runat="server" Text="<%$ Resources:localizedText, locale %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkLocationsRead" runat="server" CssClass="chkCell zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkLocationsEdit" runat="server" CssClass="chkCell zutChkEdit zutSettingsEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblGateMonitorDisplayPanel" runat="server" Text="<%$ Resources:localizedText, quickdisplaypanel %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkGateMonitorDisplayPanelRead" runat="server" CssClass="chkCell3 zutChkRead gateMonitorRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkGateMonitorDisplayPanelEdit" runat="server" CssClass="chkCell3 zutChkEdit gateMonitorEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblReports" runat="server" Text="<%$ Resources:localizedText, listandprotocol %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkReportsRead" runat="server" CssClass="chkCell3 zutChkRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkReportsEdit" runat="server" CssClass="chkCell3 zutChkEdit" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblDepartments" runat="server" Text="<%$ Resources:localizedText, departmentsControl %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkDepartmentsRead" runat="server" CssClass="chkCell zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkDepartmentsEdit" runat="server" CssClass="chkCell zutChkEdit zutSettingsEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblGateMonitorInfo" runat="server" Text="<%$ Resources:localizedText, info %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkGateMonitorInfoRead" runat="server" CssClass="chkCell zutChkRead gateMonitorRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkGateMonitorInfoEdit" runat="server" CssClass="chkCell zutChkEdit gateMonitorEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblCostCenters" runat="server" Text="<%$ Resources:localizedText, costcenters %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkCostCentersRead" runat="server" CssClass="chkCell zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkCostCentersEdit" runat="server" CssClass="chkCell zutChkEdit zutSettingsEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">

                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">

                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">

                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblCommunicationGet" runat="server" Text="<%$ Resources:localizedText, getdata %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkCommunicationGetRead" runat="server" CssClass="chkCell zutChkRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkCommunicationGetEdit" runat="server" CssClass="chkCell zutChkEdit" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblVisitorFirms" runat="server" Text="<%$ Resources:localizedText, visitCompanynew %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkVisitorFirmsRead" runat="server" CssClass="chkCell3 zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkVisitorFirmsEdit" runat="server" CssClass="chkCell3 zutChkEdit zutSettingsEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblPerActive" runat="server" Text="<%$ Resources:localizedText, personal %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkPersActiveRead" runat="server" CssClass="chkCell3 zutChkRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkPersActiveEdit" runat="server" CssClass="chkCell3 zutChkEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblCommunicationSend" runat="server" Text="<%$ Resources:localizedText, senddata %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkCommunicationSendRead" runat="server" CssClass="chkCell3 zutChkRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkCommunicationSendEdit" runat="server" CssClass="chkCell3 zutChkEdit" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblVehicles" runat="server" Text="<%$ Resources:localizedText, car %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkVehiclesRead" runat="server" CssClass="chkCell3 zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkVehiclesEdit" runat="server" CssClass="chkCell3 zutChkEdit zutSettingsEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblMembersActive" runat="server" Text="<%$ Resources:localizedText, members %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkMembersActiveRead" runat="server" CssClass="chkCell zutChkRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkMembersActiveEdit" runat="server" CssClass="chkCell zutChkEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblCommunicationManual" runat="server" Text="<%$ Resources:localizedText, SendDataManually %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkCommunicationManualRead" runat="server" CssClass="chkCell zutChkRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkCommunicationManualEdit" runat="server" CssClass="chkCell zutChkEdit" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblMembersGroups" runat="server" Text="<%$ Resources:localizedText, studioGroup %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkMembersGroupsRead" runat="server" CssClass="chkCell zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkMembersGroupsEdit" runat="server" CssClass="chkCell zutChkEdit zutSettingsEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblBuildingPlan" runat="server" Text="<%$ Resources:localizedText, buildingPlan %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkBuildingPlanRead" runat="server" CssClass="chkCell zutChkRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkBuildingPlanEdit" runat="server" CssClass="chkCell zutChkEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblMembersContracts" runat="server" Text="<%$ Resources:localizedText, contractDuration %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkMembersContractsRead" runat="server" CssClass="chkCell zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkMembersContractsEdit" runat="server" CssClass="chkCell zutChkEdit zutSettingsEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblAccessGroups" runat="server" Text="<%$ Resources:localizedText, accessgroups %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkAccessGroupsRead" runat="server" CssClass="chkCell zutChkRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkAccessGroupsEdit" runat="server" CssClass="chkCell zutChkEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblAccessProfile" runat="server" Text="<%$ Resources:localizedText, accessProfileTitle %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkAccessProfileRead" runat="server" CssClass="chkCell zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkAccessProfileEdit" runat="server" CssClass="chkCell zutChkEdit zutSettingsEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblAccessPlans" runat="server" Text="<%$ Resources:localizedText, accessPlans %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkAccessPlansRead" runat="server" CssClass="chkCell zutChkRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkAccessPlansEdit" runat="server" CssClass="chkCell zutChkEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblAccessCalender" runat="server" Text="<%$ Resources:localizedText, accessCalendar %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkAccessCalenderRead" runat="server" CssClass="chkCell zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkAccessCalenderEdit" runat="server" CssClass="chkCell zutChkEdit zutSettingsEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblSwitchPlan" runat="server" Text="<%$ Resources:localizedText, switchPlan %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkSwitchPlanRead" runat="server" CssClass="chkCell zutChkRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkSwitchPlanEdit" runat="server" CssClass="chkCell zutChkEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblSwitchProfile" runat="server" Text="<%$ Resources:localizedText, swProfile %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkSwitchProfileRead" runat="server" CssClass="chkCell zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkSwitchProfileEdit" runat="server" CssClass="chkCell zutChkEdit zutSettingsEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblHolidayCalender" runat="server" Text="<%$ Resources:localizedText, holidayCalendar2 %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkHolidayCalenderRead" runat="server" CssClass="chkCell zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkHolidayCalenderEdit" runat="server" CssClass="chkCell zutChkEdit zutSettingsEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblVisitors" runat="server" Text="<%$ Resources:localizedText, visitorsData %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkVisitorsRead" runat="server" CssClass="chkCell zutChkRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkVisitorsEdit" runat="server" CssClass="chkCell zutChkEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblHolidayPlan" runat="server" Text="<%$ Resources:localizedText, holidayPlan %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkHolidayPlanRead" runat="server" CssClass="chkCell zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkHolidayPlanEdit" runat="server" CssClass="chkCell zutChkEdit zutSettingsEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblVisitorApplications" runat="server" Text="<%$ Resources:localizedText, registration %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkVisitorApplicationsRead" runat="server" CssClass="chkCell zutChkRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkVisitorApplicationsEdit" runat="server" CssClass="chkCell zutChkEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblLanguage" runat="server" Text="<%$ Resources:localizedText, language %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkLanguageRead" runat="server" CssClass="chkCell zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkLanguageEdit" runat="server" CssClass="chkCell zutChkEdit zutSettingsEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblVisitorPlan" runat="server" Text="<%$ Resources:localizedText, visitorplan %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkVisitorPlanRead" runat="server" CssClass="chkCell zutChkRead " />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkVisitorPlanEdit" runat="server" CssClass="chkCell zutChkEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblRightsSettings" runat="server" Text="<%$ Resources:localizedText, rightsSetting %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkRightsSettingsRead" runat="server" CssClass="chkCell zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkRightsSettingsEdit" runat="server" CssClass="chkCell zutChkEdit zutSettingsEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblPasswordsAndProfiles" runat="server" Text="<%$ Resources:localizedText, rightsSettings %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkPasswordsAndProfilesRead" runat="server" CssClass="chkCell zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkPasswordsAndProfilesEdit" runat="server" CssClass="chkCell zutChkEdit zutSettingsEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblAccessProfileGroup" runat="server" Text="<%$ Resources:localizedText, accessprofilgroup %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkAccessProfileGroupRead" runat="server" CssClass="chkCell zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkAccessProfileGroupEdit" runat="server" CssClass="chkCell zutChkEdit zutSettingsEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="tblRw">
                        <asp:TableCell CssClass="tblCell3"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblAccessPlanGroup" runat="server" Text="<%$ Resources:localizedText, accessplangro %>" CssClass="lblTblCellTitle4"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkAccessPlanGroupRead" runat="server" CssClass="chkCell zutChkRead zutSettingsRead" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell2">
                            <asp:CheckBox ID="chkAccessPlanGroupEdit" runat="server" CssClass="chkCell zutChkEdit zutSettingsEdit" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                        <asp:TableCell CssClass="tblCell2"></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </section>

            <section class="grdSec" style="display: none;">
                <dx:ASPxGridView ID="grdSearchProfiles" runat="server" Width="100%" AutoGenerateColumns="False" Theme="Office2003Blue" EnableTheming="True" KeyFieldName="ID"
                    Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="12px" EnableCallBacks="False"
                    OnSelectionChanged="grdSearchProfiles_SelectionChanged">
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="4%" Caption="<%$ Resources:localizedText, rightNo %>" VisibleIndex="1" FieldName="ProfileNr">
                            <HeaderStyle HorizontalAlign="left"></HeaderStyle>

                            <CellStyle HorizontalAlign="left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="18%" Caption="<%$ Resources:localizedText, descriptionnew %>" VisibleIndex="2" FieldName="ProfileDescription">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsBehavior AllowFocusedRow="true" AllowDragDrop="False" AllowGroup="False" AllowSelectSingleRowOnly="True" AllowSort="False" ProcessSelectionChangedOnServer="True" AllowSelectByRowClick="True" />
                    <SettingsPager Visible="False" ShowEmptyDataRows="true" PageSize="24" Mode="ShowAllRecords"></SettingsPager>

                    <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                </dx:ASPxGridView>
            </section>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnNew" CssClass="BottomFooterBtnsLeft newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newrightssettings  %>" OnClick="btnNew_Click" Style="width: 170px;" />
    <asp:Button ID="btnSave" CssClass="BottomFooterBtnsLeft savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, saverightssettings  %>" OnClick="btnSave_Click" Style="width: 207px;" />
    <asp:Button ID="btnDel" CssClass="BottomFooterBtnsLeft deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deleterightssettings  %>" OnClick="btnDel_Click" Style="width: 188px;" />
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="BottomFooterBtnsRight backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton  %>" OnClick="btnBack_Click" />
    <asp:Button ID="btnActHelp" CssClass="BottomFooterBtnsRight helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" Style="width: 41px;" />
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
