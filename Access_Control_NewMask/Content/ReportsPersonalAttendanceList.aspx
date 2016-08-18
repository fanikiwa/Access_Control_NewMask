<%@ Page Title="<%$ Resources:localizedText, attendanceStaff %>" Language="C#" MasterPageFile="~/MasterPages/Reports.Master" AutoEventWireup="true" CodeBehind="ReportsPersonalAttendanceList.aspx.cs" Inherits="Access_Control_NewMask.Content.ReportsPersonalAttendanceList" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.2.Web, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/ReportsPersonalAttendanceList.js"></script>
    <link href="Styles/ReportsPersonalAttendanceList.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">

    <asp:HiddenField ID="HiddenField1BackValue" runat="server" />
    <div class="ContentAreaDiv">
        <div class="TopContentAreaDiv">
            <section class="sectop">
                <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, quickPrint %>" CssClass="lblqckdruk"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, allPresent %>" CssClass="lblalleanswe"></asp:Label>
                <asp:CheckBox ID="chkPresentOnly" runat="server" CssClass="chkanwse chkSwitch" />
                <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, allAbsence %>" CssClass="lblalleabswe"></asp:Label>
                <asp:CheckBox ID="chkAbsencesOnly" runat="server" CssClass="chkabwse chkSwitch" />
                <asp:Label ID="Label5" runat="server" Text="<%$ Resources:localizedText, allBookingsMade %>" CssClass="lblalleget"></asp:Label>
                <asp:CheckBox ID="chkAllBookings" runat="server" CssClass="chkallget chkSwitch" />
                <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText, dateTitle %>" CssClass="lbldatum"></asp:Label>
                <dx:ASPxDateEdit ID="dtPrintDateMain" runat="server" HorizontalAlign="Center" Theme="Office2003Blue" CssClass="datedisT"></dx:ASPxDateEdit>
                <asp:Button ID="btnQuickPrint" runat="server" Text="<%$ Resources:localizedText, quickPrint %>" CssClass="btnquickdruk" />
            </section>
        </div>
        <div class="MidContentAreaDiv">
            <section class="toplabel">
                <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, filteredPrint %>" CssClass="labeltop"></asp:Label>
            </section>
            <section class="contentarea">
                <section class="top1">
                    <section class="top1left">
                        <section class="lblleft">
                            <asp:Label ID="Label8" runat="server" Text="<%$ Resources:localizedText, printSelection_New %>" CssClass="lbaus"></asp:Label>
                        </section>
                        <section class="topsec1left">
                            <asp:Label ID="Label9" runat="server" Text="<%$ Resources:localizedText, dateFrom_newP %>" CssClass="lbldatefrom"></asp:Label>
                            <dx:ASPxDateEdit ID="dtPrintDateFrom" runat="server" HorizontalAlign="Center" Theme="Office2003Blue" CssClass="datedis"></dx:ASPxDateEdit>
                            <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                            <dx:ASPxDateEdit ID="dtPrintDateTo" runat="server" HorizontalAlign="Center" Theme="Office2003Blue" CssClass="datedis"></dx:ASPxDateEdit>
                        </section>
                        <section class="topsec1left2">
                            <asp:Label ID="Label12" runat="server" Text="<%$ Resources:localizedText, companyFrom %>" CssClass="lbldatefrom"></asp:Label>
                            <%--<dx:ASPxComboBox ID="cboClientNameFrom" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"></dx:ASPxComboBox>--%>

                            <dx:ASPxComboBox ID="cboClientNameFrom" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ClientIDMode="Static" ClientInstanceName="cboClientNameFrom" runat="server" SelectedIndex="0" ValueField="ID" TextField="Name" Theme="Office2003Blue" ValueType="System.String" CssClass="drpcombo">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {cboClientNameFromPersonal(s, e);}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" FieldName="Client_Nr" Width="20%" />
                                    <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, companynew %>" FieldName="Name" Width="80%" />
                                </Columns>
                            </dx:ASPxComboBox>

                            <asp:Label ID="Label19" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                            <%--<dx:ASPxComboBox ID="cboClientNameto" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"></dx:ASPxComboBox>--%>
                            <dx:ASPxComboBox ID="cboClientNameto" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ValueField="ID" TextField="Name" ClientIDMode="Static" ClientInstanceName="cboClientNameto" SelectedIndex="0" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="drpcombo">
                                <Columns>
                                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" FieldName="Client_Nr" Width="20%" />
                                    <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, companynew %>" FieldName="Name" Width="80%" />
                                </Columns>
                            </dx:ASPxComboBox>

                        </section>
                        <section class="topsec1left2">
                            <asp:Label ID="Label13" runat="server" Text="<%$ Resources:localizedText, locationFrom_new %>" CssClass="lbldatefrom"></asp:Label>
                            <%--<dx:ASPxComboBox ID="cbolocationPersonalFrm" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"></dx:ASPxComboBox>--%>
                            <dx:ASPxComboBox ID="cbolocationPersonalFrm" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" SelectedIndex="0" ValueField="ID" TextField="Name" ClientIDMode="Static" ClientInstanceName="cbolocationPersonalFrm" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="drpcombo">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {cbolocationPersonal(s, e);}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr.:" FieldName="Location_Nr" Width="20%" />
                                    <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, location1 %>" FieldName="Name" Width="80%" />
                                </Columns>
                            </dx:ASPxComboBox>

                            <asp:Label ID="Label14" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                            <%--<dx:ASPxComboBox ID="cbolocationPersonalTo" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"></dx:ASPxComboBox>--%>

                            <dx:ASPxComboBox ID="cbolocationPersonalTo" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ClientIDMode="Static" ClientInstanceName="cbolocationPersonalTo" ValueField="ID" TextField="Name" SelectedIndex="0" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="drpcombo">
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr.:" FieldName="Location_Nr" Width="20%" />
                                    <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, location1 %>" FieldName="Name" Width="80%" />
                                </Columns>
                            </dx:ASPxComboBox>

                        </section>
                        <section class="topsec1left2">
                            <asp:Label ID="Label15" runat="server" Text="<%$ Resources:localizedText, departmentFrom %>" CssClass="lbldatefrom"></asp:Label>
                            <%--<dx:ASPxComboBox ID="cboDeptNameFrom" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"></dx:ASPxComboBox>--%>

                            <dx:ASPxComboBox ID="cboDeptNameFrom" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ClientIDMode="Static" SelectedIndex="0" ClientInstanceName="cboDeptNameFrom" ValueField="ID" TextField="Name" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="drpcombo">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {cboDeptNamePersonal(s, e);}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr.:" FieldName="Department_Nr" Width="20%" />
                                    <dx:ListBoxColumn Caption="Name:" FieldName="Name" Width="80%" />
                                </Columns>
                            </dx:ASPxComboBox>

                            <asp:Label ID="Label16" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                            <%--<dx:ASPxComboBox ID="cboDeptNameTo" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"></dx:ASPxComboBox>--%>

                            <dx:ASPxComboBox ID="cboDeptNameTo" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ClientIDMode="Static" ClientInstanceName="cboDeptNameTo" ValueField="ID" TextField="Name" SelectedIndex="0" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="drpcombo">
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr.:" FieldName="Department_Nr" Width="20%" />
                                    <dx:ListBoxColumn Caption="Name:" FieldName="Name" Width="80%" />
                                </Columns>
                            </dx:ASPxComboBox>

                        </section>
                        <section class="topsec1left2">
                            <asp:Label ID="Label17" runat="server" Text="<%$ Resources:localizedText, costCenterFrom %>" CssClass="lbldatefrom"></asp:Label>
                            <%--<dx:ASPxComboBox ID="cboCostCenterNameFrom" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"></dx:ASPxComboBox>--%>

                            <dx:ASPxComboBox ID="cboCostCenterName" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ClientIDMode="Static" ClientInstanceName="cboCostCenterName" ValueField="ID" TextField="Name" SelectedIndex="0" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="drpcombo">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {cboCostCenterNamePersonal(s, e);}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr.:" FieldName="CostCenter_Nr" Width="20%" />
                                    <dx:ListBoxColumn Caption="Name:" FieldName="Name" Width="80%" />
                                </Columns>
                            </dx:ASPxComboBox>

                            <asp:Label ID="Label18" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                            <%--<dx:ASPxComboBox ID="cboCostCenterNameTo" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"></dx:ASPxComboBox>--%>

                            <dx:ASPxComboBox ID="cboCostCenterNameTo" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ValueField="ID" TextField="Name" SelectedIndex="0" ClientIDMode="Static" ClientInstanceName="cboCostCenterNameTo" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="drpcombo">
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr.:" FieldName="CostCenter_Nr" Width="20%" />
                                    <dx:ListBoxColumn Caption="Name:" FieldName="Name" Width="80%" />
                                </Columns>
                            </dx:ASPxComboBox>

                        </section>

                    </section>
                    <section class="top1right">
                        <section class="lblright">
                            <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText, selectionOfReports_new %>" CssClass="lbsel"></asp:Label>
                        </section>
                        <section class="topsec1right">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClass">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjectschks" CssClass="tblCell1">
                                        <asp:Label ID="lblObjects" runat="server" Text="1" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersonttalchecks" CssClass="tblCell2">
                                        <asp:Label ID="lblPersonal" runat="server" Text="<%$ Resources:localizedText, date %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkPersonalDate" runat="server" /><label for='chkPersonalDate'></label>

                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjecttschks" CssClass="tblCell1">
                                        <asp:Label ID="Label20" runat="server" Text="2" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPerstonalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label21" runat="server" Text="Mandant:" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lhbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkcompany" runat="server" /><label for='chkcompany'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjecltschks" CssClass="tblCell1">
                                        <asp:Label ID="Label23" runat="server" Text="3" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersionalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label24" runat="server" Text="Standort:" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lbll" CssClass="tblCell3">
                                        <asp:CheckBox ID="chklocation" runat="server" /><label for='chklocation'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjecschks" CssClass="tblCell1">
                                        <asp:Label ID="Label26" runat="server" Text="4" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPeronalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label27" runat="server" Text="Abteilung:" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lbdl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkdepartment" runat="server" /><label for='chkdepartment'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObctschks" CssClass="tblCell1">
                                        <asp:Label ID="Label29" runat="server" Text="5" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPerslchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label30" runat="server" Text="Kostenstelle:" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkcostcenter" runat="server" /><label for='chkcostcenter'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>

                    </section>
                </section>
                <section class="belowsec">
                    <section class="lblleft">
                        <asp:Label ID="Label39" runat="server" Text="<%$ Resources:localizedText, otherSelections %>" CssClass="lbaus"></asp:Label>
                    </section>
                    <section class="belowsecholder">
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjecuttschks" CssClass="tblCell1">
                                        <asp:Label ID="Label11" runat="server" Text="6" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersjtonalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label22" runat="server" Text="Name:" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lhjbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkname" runat="server" /><label for='chkname'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjjecltschks" CssClass="tblCell1">
                                        <asp:Label ID="Label25" runat="server" Text="7" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersiodnalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label28" runat="server" Text="ID Nr.:" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldfbll" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkid" runat="server" /><label for='chkid'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblOrrbjecschks" CssClass="tblCell1">
                                        <asp:Label ID="Label31" runat="server" Text="8" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPerornalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label32" runat="server" Text="<%$ Resources:localizedText, idNr_P %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lbdrl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkCardNr" runat="server" /><label for='chkCardNr'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblrObctschks" CssClass="tblCell1">
                                        <asp:Label ID="Label33" runat="server" Text="9" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPrerrslchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label34" runat="server" Text="<%$ Resources:localizedText, expiresDate %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldrbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkCardExpiryDate" runat="server" /><label for='chkCardExpiryDate'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblrObctsschks" CssClass="tblCell1">
                                        <asp:Label ID="Label35" runat="server" Text="10" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPrerdrslchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label36" runat="server" Text="<%$ Resources:localizedText, EntryDate %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldarbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkEntry" runat="server" /><label for='chkEntry'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblrObctscehks" CssClass="tblCell1">
                                        <asp:Label ID="Label37" runat="server" Text="11" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPrerrsflchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label38" runat="server" Text="<%$ Resources:localizedText, exitDate_P %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldrbdl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkExit" runat="server" /><label for='chkExit'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                    </section>
                </section>
            </section>
        </div>
    </div>
    <section class="showReports" style="display: none">
        <section class="mainBodyTop">
            <section class="mainBodyTop1 ">
                <section class="mainBodyTop1left">
                    <section class="mainBodyTop1leftlbl">
                        <asp:Label ID="Label40" runat="server" Text="<%$ Resources:localizedText, locationFrom_new %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label41" runat="server" Text="<%$ Resources:localizedText, departmentFrom_new %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label42" runat="server" Text="<%$ Resources:localizedText, costCenterFrom_new %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label60" runat="server" Text="<%$ Resources:localizedText, companyFrom %>" CssClass="lblreport"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="txtlocFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtDeptFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtCostCenterFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtMemberFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label43" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label44" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label45" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label61" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp4New">

                        <asp:TextBox ID="txtLocTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtDeptTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtCostCenterTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtMemberTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left3">
                    <section class="selectionOne">
                        <section class="topRight1">
                            <asp:Label ID="Label46" runat="server" Text="<%$ Resources:localizedText, date_new %>" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label47" runat="server" Text="<%$ Resources:localizedText, fromnew %>" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="txtPrintDateFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label48" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtPrintDateTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight2">
                            <%--   <asp:Label ID="Label49" runat="server" Text="Selektion der Auswertungen:" CssClass="lblPrintMode" Style="margin-left: 19%;"></asp:Label>
                            <asp:Label ID="Label50" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>--%>

                            <section class="loggedInUser2">
                                <asp:Label ID="Label58" runat="server" Text="<%$ Resources:localizedText, createdBy %>" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblLoggedInUser" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>
                        </section>
                        <section class="topRight3">
                            <asp:Label ID="printType" runat="server" Text="" CssClass="lblPrintModeobj"></asp:Label>
                        </section>
                    </section>
                    <section class="selectionTwo">
                        <section class="topRight1">
                            <asp:Label ID="Label51" runat="server" Text="<%$ Resources:localizedText, time %>" CssClass="lblDateTitle" Style="display: none"></asp:Label>
                            <asp:Label ID="Label52" runat="server" Text="<%$ Resources:localizedText, fromnew %>" CssClass="lblDtFromTitle" Style="display: none"></asp:Label>

                            <asp:TextBox ID="TextBox9" runat="server" Style="text-align: center; display: none;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label53" runat="server" Text="<%$ Resources:localizedText, to_new %>" Style="display: none" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="TextBox10" runat="server" Style="text-align: center; display: none;" CssClass="txtDispDateTo"></asp:TextBox>
                        </section>
                        <section class="topRight2">
                            <asp:Label ID="Label54" runat="server" Text="<%$ Resources:localizedText, selectedTimeRange %>" CssClass="lblPrintMode" Style="width: 56%; display: none;"></asp:Label>
                            <asp:Label ID="Label55" runat="server" Text="" CssClass="lblTimeHrsMode" Style="display: none"></asp:Label>
                        </section>
                        <section class="topRight3">
                        </section>
                    </section>
                    <section class="selectionThree">
                        <section class="topRight1">
                            <asp:Label ID="Label56" runat="server" Text="<%$ Resources:localizedText, printedOn %>" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtPrintDate" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label57" runat="server" Text="<%$ Resources:localizedText, timeTitle %>" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtPrintTime" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight2" style="display:none;">
                            <%--   <section class="loggedInUser">
                                <asp:Label ID="Label58" runat="server" Text="Erstellt von:" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblLoggedInUser" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>--%>
                        </section>
                        <section class="topRight3perpekind">
                            <section class="secholdingarea1_new">
                                <asp:Label ID="Label99" runat="server" Text="<%$ Resources:localizedText, potrait %>" CssClass="txtportrait"></asp:Label>
                                <asp:ImageButton ID="imgPotrait" runat="server" CssClass="btnorientation1" Style="cursor:default;"/>
                                <asp:CheckBox ID="chkPortrait" runat="server" CssClass="chk1controllast" />

                            </section>
                            <section class="secholdingarea1b_new">
                                <asp:Label ID="Label100" runat="server" Text="<%$ Resources:localizedText, landScape %>" CssClass="txtlandscape_new"></asp:Label>
                                <asp:ImageButton ID="imgLand" runat="server" CssClass="btnorientation2" Style="cursor:default;"/>
                                <asp:CheckBox ID="chkLandScape" runat="server" CssClass="chk1controllast" />

                            </section>
                        </section>

                    </section>
                </section>
            </section>
        </section>
        <section class="mainBodybtm">
            <dx:ASPxGridView ID="grdDisplayPersonalAttendance" runat="server" SettingsBehavior-AllowSort="true" ClientIDMode="Static" ClientInstanceName="grdDisplayPersonalAttendance" Theme="Office2003Blue" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdDisplayPersonalAttendance_CustomCallback">
                <SettingsBehavior AllowSort="true" AllowFocusedRow="True" AllowDragDrop="False" AllowGroup="False" AutoExpandAllGroups="True" />
                <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="BookingDate" Caption="<%$ Resources:localizedText, date_new %>" VisibleIndex="1">
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, company_Title %>" Visible="false" VisibleIndex="2" FieldName="PersClient"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, locationnew %>" Visible="false" VisibleIndex="3" FieldName="PersLocation"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, departmentTitle %>" Visible="false" VisibleIndex="4" FieldName="PersDepartement"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, costCenterTitle %>" Visible="false" VisibleIndex="5" FieldName="PersCostCenter"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Name" VisibleIndex="6" FieldName="Name"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="ID Nr.:" Visible="false" VisibleIndex="7" FieldName="PersonID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, cardNr %>" VisibleIndex="8" Visible="false" FieldName="CardNumber"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, expiryDate_new %>" Visible="false" VisibleIndex="9" FieldName="ExpiryDate">
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="EntryDate" Caption="<%$ Resources:localizedText, joining %>" Visible="false" VisibleIndex="10">
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="ExitDate" Caption="<%$ Resources:localizedText, withdrawal %>" Visible="false" VisibleIndex="11">
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                </Columns>
            </dx:ASPxGridView>
        </section>
    </section>
    <div class="showReportsDocViewer" style="display: none;">
        <dx:ASPxCallbackPanel ID="PersonalAttendanceCallbackPanel" runat="server" OnCallback="PersonalAttendanceCallbackPanel_Callback">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <dx:ASPxWebDocumentViewer ID="ASPxDocumentViewerPersonalAttendanceReport" Style="width: 100%; height: 1100px;" ClientIDMode="Static" ClientInstanceName="ASPxDocumentViewerPersonalAttendanceReport" runat="server" Theme="Office2003Blue">
                    </dx:ASPxWebDocumentViewer>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <%--<asp:Button ID="Button2" CssClass="editbtnfooterorange" runat="server" Text="Anwesenheitsliste drucken" Style="width:170px;" />--%>

    <asp:Button ID="btnPrintAttendance" CssClass="editbtnfooterorange" runat="server" Text="<%$ Resources:localizedText, attendanceSelection %>" Style="width: 170px;" />

    <asp:Button ID="btnPrintReport" CssClass="btnPrintReport" runat="server" Text="<%$ Resources:localizedText, printAttendance %>" Style="display: none" />

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">

    <asp:Button ID="btnBack" ClientIDMode="Static" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
