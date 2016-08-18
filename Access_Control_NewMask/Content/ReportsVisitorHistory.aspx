<%@ Page Title="<%$ Resources:localizedText, visitorHistory_New %>" Language="C#" MasterPageFile="~/MasterPages/Reports.Master" AutoEventWireup="true" CodeBehind="ReportsVisitorHistory.aspx.cs" Inherits="Access_Control_NewMask.Content.ReportsVisitorHistory" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.2.Web, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/ReportsVisitorHistory.js"></script>
    <link href="Styles/ReportsVisitorHistory.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="ContentAreaDiv">
        <asp:HiddenField ID="HiddenField1BackValue" runat="server" />
        <div id="ControlSection1" class="TopContentAreaDiv">
            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, listWhichClientWasVisitedByWhatCompany %>" CssClass="lbltoparea"></asp:Label>
        </div>
        <div id="MainContdiv">
            <section class="midareaholder">
                <section class="topareatitles">
                    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, printSelection %>" CssClass="lbltopareafirst"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, printStartAfter %>" CssClass="lbltopareafirstright"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, selectionOfReports_new %>" CssClass="lbltopareafirstrightB"></asp:Label>
                </section>
                <section class="areasixitemsrighttop">
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label5" runat="server" Text="<%$ Resources:localizedText, dateFrom_newP %>" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxDateEdit ID="dtpFrom" runat="server" HorizontalAlign="Center" Theme="Office2003Blue" CssClass="cmbFrombottom">
                            <ClientSideEvents DateChanged="function(s, e) {drpPlanDateFromChanged(s, e, dtpTo);}"></ClientSideEvents>
                        </dx:ASPxDateEdit>
                        <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxDateEdit ID="dtpTo" HorizontalAlign="Center" runat="server" Theme="Office2003Blue" CssClass="cmbFromarea2">
                            <ClientSideEvents DateChanged="function(s, e) {drpPlanDateToChanged(s, e);}"></ClientSideEvents>
                        </dx:ASPxDateEdit>
                        <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText, date_new %>" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chkname" runat="server" /><label for='chkname'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </section>
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label40" runat="server" Text="<%$ Resources:localizedText, timeFrom %>" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxTimeEdit ID="TimeFrom" runat="server" HorizontalAlign="Center" Theme="Office2003Blue" CssClass="cmbFrombottom" SpinButtons-ShowIncrementButtons="false"></dx:ASPxTimeEdit>
                        <asp:Label ID="Label41" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxTimeEdit ID="TimeTo" runat="server" HorizontalAlign="Center" Theme="Office2003Blue" CssClass="cmbFromarea2" SpinButtons-ShowIncrementButtons="false"></dx:ASPxTimeEdit>
                        <asp:Label ID="Label42" runat="server" Text="<%$ Resources:localizedText, time_newP %>" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chkid" runat="server" /><label for='chkid'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </section>
                </section>
                <section class="lastvariant">
                    <asp:CheckBox ID="chkVariableA" runat="server" CssClass="chkAccssDataareaA chkAllvar" />
                    <asp:Label ID="Label43" runat="server" Text="<%$ Resources:localizedText, variantA %>" CssClass="lblvariantlastarea"></asp:Label>
                </section>

                <section class="areasixitemsnew">
                    <section class="areasixitemslastvariant" style="width: 83.2%;">
                        <asp:Label ID="Label13" runat="server" Text="<%$ Resources:localizedText, companyFromTitle %>" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboClientFrom" runat="server" CallbackPageSize="100000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFrombottom" ClientIDMode="Static" ClientInstanceName="cboClientFrom" SelectedIndex="0" ValueField="ID" TextField="Name">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cboClientFromSelectedIndex(s, e);}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" FieldName="Client_Nr" Width="20%" />
                                <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, companynew %>" FieldName="Name" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label14" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboClientTo" runat="server" ClientIDMode="Static" ClientInstanceName="cboClientTo" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFromarea2" CallbackPageSize="100000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" SelectedIndex="0" ValueField="ID" TextField="Name">
                            <Columns>
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" FieldName="Client_Nr" Width="20%" />
                                <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, companynew %>" FieldName="Name" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label15" runat="server" Text="Mandant:" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chkaus" runat="server" /><label for='chkaus'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </section>
                    <section class="areasixitemslastvariant" style="display: none;">
                        <asp:Label ID="Label16" runat="server" Text="Standort von:" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboLocatiomFrom" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFrombottom" CallbackPageSize="100000" SelectedIndex="0" ValueField="ID" TextField="Name" ClientIDMode="Static" ClientInstanceName="cboLocatiomFrom" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cbolocationPersonal(s, e);}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn Caption="Nr.:" FieldName="Location_Nr" Width="20%" />
                                <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, location1 %>" FieldName="Name" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label17" runat="server" Text="bis:" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboLocationTo" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFromarea2"
                            CallbackPageSize="100000" SelectedIndex="0" TextFormatString="{1}" ValueField="ID" TextField="Name" ClientIDMode="Static" ClientInstanceName="cboLocationTo" DropDownWidth="480px" DropDownRows="20">
                            <Columns>
                                <dx:ListBoxColumn Caption="Nr.:" FieldName="Location_Nr" Width="20%" />
                                <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, location1 %>" FieldName="Name" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label18" runat="server" Text="Standort:" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chkgul" runat="server" /><label for='chkgul'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </section>
                    <section class="areasixitemslastvariant" style="display: none">
                        <asp:Label ID="Label20" runat="server" Text="Abteilung von:" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboDeptFrom" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFrombottom"
                            CallbackPageSize="100000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ClientIDMode="Static" SelectedIndex="0" ClientInstanceName="cboDeptFrom" ValueField="ID" TextField="Name">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cboDeptNamePersonal(s, e);}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn Caption="Nr.:" FieldName="Department_Nr" Width="20%" />
                                <dx:ListBoxColumn Caption="Name:" FieldName="Name" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label21" runat="server" Text="bis:" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboDeptTo" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFromarea2"
                            CallbackPageSize="100000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ClientIDMode="Static" SelectedIndex="0" ClientInstanceName="cboDeptTo" ValueField="ID" TextField="Name">
                            <Columns>
                                <dx:ListBoxColumn Caption="Nr.:" FieldName="Department_Nr" Width="20%" />
                                <dx:ListBoxColumn Caption="Name:" FieldName="Name" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label22" runat="server" Text="Abteilung:" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chkenstri2" runat="server" /><label for='chkenstri2'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </section>
                    <section class="areasixitemslastvariant" style="display: none">
                        <asp:Label ID="Label23" runat="server" Text="Kostenstelle von:" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboCostCenterFrom" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFrombottom"
                            CallbackPageSize="100000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ClientIDMode="Static" ClientInstanceName="cboCostCenterFrom" ValueField="ID" TextField="Name" SelectedIndex="0">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cboCostCenterNamePersonal(s, e);}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn Caption="Nr.:" FieldName="CostCenter_Nr" Width="20%" />
                                <dx:ListBoxColumn Caption="Name:" FieldName="Name" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label24" runat="server" Text="bis:" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboCoastCenterTo" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFromarea2"
                            CallbackPageSize="100000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ClientIDMode="Static" ClientInstanceName="cboCoastCenterTo" ValueField="ID" TextField="Name" SelectedIndex="0">
                            <Columns>
                                <dx:ListBoxColumn Caption="Nr.:" FieldName="CostCenter_Nr" Width="20%" />
                                <dx:ListBoxColumn Caption="Name:" FieldName="Name" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label25" runat="server" Text="Kostenstelle:" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chkenstri3" runat="server" /><label for='chkenstri3'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </section>




                    <section class="lastvariant" style="width: 16%;">
                        <asp:CheckBox ID="chkVaribleB" runat="server" CssClass="chkAccssDataareaB chkAllvar" />
                        <asp:Label ID="Label19" runat="server" Text="<%$ Resources:localizedText, variantB %>" CssClass="lblvariantlastarea"></asp:Label>
                    </section>
                </section>



                <section class="topareatitlespers">
                    <asp:Label ID="Label8" runat="server" Text="<%$ Resources:localizedText, visitorsSelection_NewP %>" CssClass="lbltopareafirst"></asp:Label>
                </section>



                <section class="areasixitemsrightlastpers">
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label12" runat="server" Text="<%$ Resources:localizedText, visitorsCompanyFrom %>" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboClientName" CallbackPageSize="100000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ClientIDMode="Static" ClientInstanceName="cboClientName" runat="server" SelectedIndex="0" ValueField="ID" TextField="CompanyName" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFrombottom">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cboClientNamePersonal(s, e);}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" FieldName="CompanyNr" Width="20%" />
                                <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, companynew %>" FieldName="CompanyName" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label26" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbltopareafirsttobottom"></asp:Label>

                        <dx:ASPxComboBox ID="cboClientNameto" CallbackPageSize="100000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ClientIDMode="Static" ClientInstanceName="cboClientNameto" runat="server" SelectedIndex="0" ValueField="ID" TextField="CompanyName" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFromarea2">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cboClientNamePersonal(s, e);}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" FieldName="CompanyNr" Width="20%" />
                                <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, companynew %>" FieldName="CompanyName" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label27" runat="server" Text="<%$ Resources:localizedText, visitorsCompany %>" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chkPersonalDate" runat="server" /><label for='chkPersonalDate'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </section>
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label28" runat="server" Text="<%$ Resources:localizedText, nameFrom_P %>" CssClass="lbltopareafirstdateleftbottom"></asp:Label>

                        <dx:ASPxComboBox ID="cmbPersName" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="7" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" SelectedIndex="0" ValueField="VisitorID" TextField="Name" ClientIDMode="Static" ClientInstanceName="cmbPersName" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFrombottom">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cmbPersNamesSelectedIndex(s, e);}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn FieldName="VisitorID" Caption="<%$ Resources:localizedText, visitorsId_NewP %>" Width="20%" />
                                <dx:ListBoxColumn FieldName="Name" Name="Name" ToolTip="" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label29" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboPersNameTo" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="7" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" SelectedIndex="0" ValueField="VisitorID" TextField="Name" ClientIDMode="Static" ClientInstanceName="cboPersNameTo" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFromarea2">
                            <Columns>
                                <dx:ListBoxColumn FieldName="VisitorID" Caption="<%$ Resources:localizedText, visitorsId_NewP %>" ToolTip="" Width="20%" />
                                <dx:ListBoxColumn FieldName="Name" Name="Name" ToolTip="" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label30" runat="server" Text="<%$ Resources:localizedText, nameFrom_P %>" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chkcostcenter" runat="server" /><label for='chkcostcenter'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </section>
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label31" runat="server" Text="<%$ Resources:localizedText, visitorsId_NewP %>" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboVisitorIDFrom" TextFormatString="{0}" DropDownWidth="480px" DropDownRows="7" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" SelectedIndex="0" ValueField="VisitorID" TextField="Name" ClientIDMode="Static" ClientInstanceName="cboVisitorIDFrom" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFrombottom">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cboVisitorIDFromSelected(s, e);}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn FieldName="VisitorID" Caption="<%$ Resources:localizedText, visitorsId_NewP %>" ToolTip="" Width="20%" />
                                <dx:ListBoxColumn FieldName="Name" Name="Name:" ToolTip="" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label32" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboVisitorIDTO" TextFormatString="{0}" DropDownWidth="480px" DropDownRows="7" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" SelectedIndex="0" ValueField="VisitorID" TextField="Name" ClientIDMode="Static" ClientInstanceName="cboVisitorIDTO" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFromarea2">
                            <Columns>
                                <dx:ListBoxColumn FieldName="VisitorID" Caption="<%$ Resources:localizedText, visitorsId_NewP %>" ToolTip="" Width="20%" />
                                <dx:ListBoxColumn FieldName="Name" Name="Name:" ToolTip="" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label33" runat="server" Text="<%$ Resources:localizedText, visitorsId_NewP %>" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chkdepartment" runat="server" /><label for='chkdepartment'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </section>
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label9" runat="server" Text="<%$ Resources:localizedText ,ShortTermCardFrom%>" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboShortTransponder" ClientInstanceName="cboShortTransponder" SelectedIndex="0" ValueField="ID" TextField="TransponderNr" ClientIDMode="Static" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFrombottom" DropDownWidth="200px" DropDownRows="6" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cboShortTransponderPersonal(s, e);}"></ClientSideEvents>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboShortTransponderTo" SelectedIndex="0" ValueField="ID" TextField="TransponderNr" ClientIDMode="Static" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFromarea2" DropDownWidth="200px" DropDownRows="6" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"></dx:ASPxComboBox>
                        <asp:Label ID="Label11" runat="server" Text="<%$ Resources:localizedText ,shortTermCardNr%>" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chkenstri" runat="server" /><label for='chkenstri'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </section>
                </section>
                <section class="lastvariantC">
                    <asp:CheckBox ID="chkVaribleC" runat="server" CssClass="chkAccssDataareaClast chkAllvar" />
                    <asp:Label ID="Label34" runat="server" Text="<%$ Resources:localizedText ,variantC%>" CssClass="lblvariantlastarea"></asp:Label>
                </section>
            </section>

        </div>

    </div>
    <section class="showReports" style="display: none">
        <section class="mainBodyTop">
            <section class="mainBodyTop1 ">
                <section class="mainBodyTop1left">
                    <section class="mainBodyTop1leftlbl">
                        <asp:Label ID="Label70" runat="server" Text="<%$ Resources:localizedText, companyFromTitle %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label71" runat="server" Text="<%$ Resources:localizedText, visitorsCompanyFrom %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label72" runat="server" Text="Abteilung von:" CssClass="lblreport" Style="display: none"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="txtClientFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtLocFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtDept" runat="server" CssClass="drpreport" Style="display: none"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label73" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label74" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label75" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis" Style="display: none"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp4New">

                        <asp:TextBox ID="txtClientTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtLocTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtDeptTo" runat="server" CssClass="drpreportnew" Style="display: none"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left3">
                    <section class="selectionOne">
                        <section class="topRight1">
                            <%-- <asp:Label ID="Label76" runat="server" Text="Kostenstelle" CssClass="lblDateTitle" Style="width: 16%;display:none;"></asp:Label>
                            <asp:Label ID="Label77" runat="server" Text="von:" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="txtCostCenterFrom" runat="server" Style="text-align: center; display:none;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label78" runat="server" Text="bis:" CssClass="lblDateToTitle" Style="display:none"></asp:Label>

                            <asp:TextBox ID="txtCostCenterTo" runat="server" Style="text-align: center; display:none" CssClass="txtDispDateTo" ></asp:TextBox>--%>
                            <asp:Label ID="Label81" runat="server" Text="<%$ Resources:localizedText, date2 %>" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label82" runat="server" Text="<%$ Resources:localizedText, fromTitle %>" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="txtDateFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label83" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtDateTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight2" style="width: 30%;">
                            <asp:Label ID="Label79" runat="server" Text="<%$ Resources:localizedText, printingStart %>" CssClass="lblPrintMode"></asp:Label>
                            <asp:Label ID="lblReportType" runat="server" Text="<%$ Resources:localizedText, variantA %>" CssClass="lblTimeHrsMode"></asp:Label>
                        </section>
                        <section class="topRight3" style="display: none">
                            <asp:Label ID="Label80" runat="server" Text="Objekt" CssClass="lblPrintModeobj"></asp:Label>
                        </section>
                    </section>
                    <section class="selectionTwo">
                        <section class="topRight1" style="margin-top: 10px;">
                            <asp:Label ID="Label85" runat="server" Text="<%$ Resources:localizedText, printedOn %>" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtPrintDate" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label86" runat="server" Text="<%$ Resources:localizedText, time_newP %>" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtPrintTime" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>
                        </section>
                        <section class="topRight2">
                            <%--  <asp:Label ID="lbl" runat="server" Text="Ausgwählter Zeitbereich:" CssClass="lblPrintMode" Style="width: 56%;"></asp:Label>
                            <asp:Label ID="lblTimePrintType" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>--%>
                            <section class="loggedInUser">
                                <asp:Label ID="Label84" runat="server" Text="<%$ Resources:localizedText, createdBy %>" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblPersName" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>
                        </section>
                        <section class="topRight3perpekind">
                            <section class="secholdingarea1_new">
                                <asp:Label ID="Label35" runat="server" Text="<%$ Resources:localizedText, potrait %>" CssClass="txtportrait"></asp:Label>
                                <asp:ImageButton ID="imgPotrait" runat="server" CssClass="btnorientation1" Style="cursor: default;" />
                                <asp:CheckBox ID="chkPortrait" runat="server" CssClass="chk1controllast" />

                            </section>
                            <section class="secholdingarea1b_new">
                                <asp:Label ID="Label36" runat="server" Text="<%$ Resources:localizedText, landScape %>" CssClass="txtlandscape_new"></asp:Label>
                                <asp:ImageButton ID="imgLand" runat="server" CssClass="btnorientation2" Style="cursor: default;" />
                                <asp:CheckBox ID="chkLandScape" runat="server" CssClass="chk1controllast" />

                            </section>
                        </section>
                    </section>
                    <section class="selectionThree">
                        <section class="topRight1" style="margin-top: 5px;">
                        </section>
                        <section class="topRight2">
                        </section>
                        <section class="topRight3">
                        </section>

                    </section>
                </section>
            </section>
        </section>
        <section class="mainBodybtm">
            <dx:ASPxGridView ID="grdShowReport" runat="server" ClientIDMode="Static" ClientInstanceName="grdShowReport" Theme="Office2003Blue" SettingsPager-AlwaysShowPager="false" Settings-ShowFooter="false" SettingsBehavior-AllowSort="true" SettingsBehavior-AllowDragDrop="true" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdShowReport_CustomCallback">

                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="BookingDate" Caption="K-Datum:" VisibleIndex="1">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="EntryDate" Caption="<%$ Resources:localizedText, entryTime %>" VisibleIndex="2">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="" Caption="G-Datum" VisibleIndex="3">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="ExitDate" Caption="<%$ Resources:localizedText, exitTime %>" VisibleIndex="4">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, CompanyTitle %>" VisibleIndex="5" FieldName="PersClient"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Standort" VisibleIndex="6" Visible="false" FieldName="PersLocation">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Abteilung" VisibleIndex="7" Visible="false" FieldName="PersDepartement"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Kostenstelle" VisibleIndex="8" Visible="false" FieldName="PersCostCenter">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, visitorsCompanyTitle %>" VisibleIndex="9" FieldName="VisitorCompany"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, visitorsPerson %>" VisibleIndex="10" FieldName="Name"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, visitorsId_NewP %>" VisibleIndex="11" FieldName="PersonID" CellStyle-HorizontalAlign="Left"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, cardNr %> " VisibleIndex="12" FieldName="CardNumber"></dx:GridViewDataTextColumn>

                </Columns>
                <SettingsPager AlwaysShowPager="false"></SettingsPager>
            </dx:ASPxGridView>
        </section>
    </section>
    <div class="showReportsDocViewer" style="display: none;">
        <dx:ASPxCallbackPanel ID="OneTodayCallbackPanel" runat="server" OnCallback="OneTodayCallbackPanel_Callback">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <dx:ASPxWebDocumentViewer ID="AttendanceLocalASPxDocumentViewer" Style="width: 100%; height: 1100px;" ClientIDMode="Static" ClientInstanceName="VisitorLocalASPxDocumentViewer" runat="server" Theme="Office2003Blue">
                    </dx:ASPxWebDocumentViewer>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
    </div>
    <section class="showReportsVarB" style="display: none">
        <section class="mainBodyTop">
            <section class="mainBodyTop1 ">
                <section class="mainBodyTop1left">
                    <section class="mainBodyTop1leftlbl">
                        <asp:Label ID="Label87" runat="server" Text="<%$ Resources:localizedText, companyFromTitle %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label88" runat="server" Text="<%$ Resources:localizedText, visitorsCompanyFrom %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label89" runat="server" Text="Abteilung von:" CssClass="lblreport" Style="display: none"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="txtClientBFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtLocationBFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtDeptBFrom" runat="server" CssClass="drpreport" Style="display: none"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label90" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label91" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label92" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis" Style="display: none"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp4New">

                        <asp:TextBox ID="txtClientBTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtLocationBTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtDeptBTo" runat="server" CssClass="drpreportnew" Style="display: none"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left3">
                    <section class="selectionOne">
                        <section class="topRight1">
                            <%-- <asp:Label ID="Label93" runat="server" Text="Kostenstelle" CssClass="lblDateTitle" Style="width: 16%"></asp:Label>
                            <asp:Label ID="Label94" runat="server" Text="von:" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="txtCostBFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label95" runat="server" Text="bis:" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtCostBTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>--%>
                            <asp:Label ID="Label99" runat="server" Text="<%$ Resources:localizedText, date2 %>" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label100" runat="server" Text="<%$ Resources:localizedText, fromTitle %>" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="txtDateBFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label101" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtDateBTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight2" style="width: 32%;">
                            <asp:Label ID="Label96" runat="server" Text="Druckbeginn nach:" CssClass="lblPrintMode"></asp:Label>
                            <asp:Label ID="Label97" runat="server" Text="<%$ Resources:localizedText, variantB %>" CssClass="lblTimeHrsMode"></asp:Label>
                        </section>
                        <section class="topRight3" style="display: none">
                            <asp:Label ID="Label98" runat="server" Text="Objekt" CssClass="lblPrintModeobj"></asp:Label>
                        </section>
                    </section>
                    <section class="selectionTwo">
                        <section class="topRight1" style="margin-top: 10px;">
                            <asp:Label ID="Label104" runat="server" Text="<%$ Resources:localizedText, printedOn %>"  CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtTodayDate" runat="server"  CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label105" runat="server" Text="<%$ Resources:localizedText, time_newP %>"  CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtTodayTime" runat="server"   CssClass="txtDispDateTo"></asp:TextBox>
                        </section>
                        <section class="topRight2">
                            <%--  <asp:Label ID="lbl" runat="server" Text="Ausgwählter Zeitbereich:" CssClass="lblPrintMode" Style="width: 56%;"></asp:Label>
                            <asp:Label ID="lblTimePrintType" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>--%>
                            <section class="loggedInUser">
                                <asp:Label ID="Label102" runat="server" Text="<%$ Resources:localizedText, createdBy %>" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblLoggedInUser" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>
                        </section>
                        <section class="topRight3perpekind">
                            <section class="secholdingarea1_new">
                                <asp:Label ID="Label37" runat="server" Text="<%$ Resources:localizedText, potrait %>" CssClass="txtportrait"></asp:Label>
                                <asp:ImageButton ID="imgPotraiB" runat="server" CssClass="btnorientation1" Style="cursor: default;" />
                                <asp:CheckBox ID="chkVarientBPotrait" runat="server" CssClass="chk1controllast" />

                            </section>
                            <section class="secholdingarea1b_new">
                                <asp:Label ID="Label38" runat="server" Text="<%$ Resources:localizedText, landScape %>" CssClass="txtlandscape_new"></asp:Label>
                                <asp:ImageButton ID="imgLandB" runat="server" CssClass="btnorientation2" Style="cursor: default;" />
                                <asp:CheckBox ID="chkVarientBLand" runat="server" CssClass="chk1controllast" />

                            </section>
                        </section>
                    </section>
                    <section class="selectionThree">
                        <section class="topRight1" style="margin-top: 5px;">
                        </section>
                        <section class="topRight2">
                        </section>
                        <section class="topRight3">
                        </section>

                    </section>
                </section>
            </section>
        </section>
        <section class="mainBodybtm">
            <dx:ASPxGridView ID="grdVarialeB" runat="server" ClientIDMode="Static" ClientInstanceName="grdVarialeB" Theme="Office2003Blue" SettingsPager-AlwaysShowPager="false" Settings-ShowFooter="false" SettingsBehavior-AllowSort="true" SettingsBehavior-AllowDragDrop="false" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdVarialeB_CustomCallback">

                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, CompanyTitle %>" VisibleIndex="1" FieldName="PersClient"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Standort" VisibleIndex="2" Visible="false" FieldName="PersLocation">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Abteilung" VisibleIndex="3" Visible="false" FieldName="PersDepartement"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Kostenstelle" VisibleIndex="4" Visible="false" FieldName="PersCostCenter">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, visitorsCompanyTitle %>" VisibleIndex="5" FieldName="VisitorCompany"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, visitorsPerson %>" VisibleIndex="6" FieldName="Name"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, visitorsId_NewP %>" VisibleIndex="7" FieldName="PersonID" CellStyle-HorizontalAlign="Left"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, cardNr %> " VisibleIndex="8" FieldName="CardNumber"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="BookingDate" Caption="K-Datum:" VisibleIndex="9">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="EntryDate" Caption="<%$ Resources:localizedText, entryTime %>" VisibleIndex="10">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="" Caption="G-Datum" VisibleIndex="11">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="ExitDate" Caption="<%$ Resources:localizedText, exitTime %>" VisibleIndex="12">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                </Columns>
            </dx:ASPxGridView>
        </section>
    </section>
    <section class="showReportsVarC" style="display: none">
        <section class="mainBodyTop">
            <section class="mainBodyTop1 ">
                <section class="mainBodyTop1left">
                    <section class="mainBodyTop1leftlbl">
                        <asp:Label ID="Label106" runat="server" Text="<%$ Resources:localizedText, companyFromTitle %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label107" runat="server" Text="<%$ Resources:localizedText, visitorsCompanyFrom %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label108" runat="server" Text="Abteilung von:" CssClass="lblreport" Style="display: none"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="txtClientCFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtLocationCFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtDeptCFrom" runat="server" CssClass="drpreport" Style="display: none"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label109" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label110" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label111" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis" Style="display: none"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp4New">

                        <asp:TextBox ID="txtClientCTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtLocationCTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtDeptCTo" runat="server" CssClass="drpreportnew" Style="display: none"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left3">
                    <section class="selectionOne">
                        <section class="topRight1">
                            <%--           <asp:Label ID="Label112" runat="server" Text="Kostenstelle" CssClass="lblDateTitle" Style="width: 16%"></asp:Label>
                            <asp:Label ID="Label113" runat="server" Text="von:" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="txtCostCFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label114" runat="server" Text="bis:" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtCoastCTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>--%>
                            <asp:Label ID="Label118" runat="server" Text="<%$ Resources:localizedText, date2 %>" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label119" runat="server" Text="<%$ Resources:localizedText, fromTitle %>" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="txtDateCFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label120" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtDateCTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight2" style="width: 32%;">
                            <asp:Label ID="Label115" runat="server" Text="Druckbeginn nach:" CssClass="lblPrintMode"></asp:Label>
                            <asp:Label ID="Label116" runat="server" Text="<%$ Resources:localizedText, variantC %>" CssClass="lblTimeHrsMode"></asp:Label>
                        </section>
                        <section class="topRight3" style="display: none">
                            <asp:Label ID="Label117" runat="server" Text="Objekt" CssClass="lblPrintModeobj"></asp:Label>
                        </section>
                    </section>
                    <section class="selectionTwo">
                        <section class="topRight1" style="margin-top: 10px;">
                            <asp:Label ID="Label123" runat="server" Text="<%$ Resources:localizedText, printedOn %>"  CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtTodayDateC" runat="server"  CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label124" runat="server" Text="<%$ Resources:localizedText, time_newP %>"  CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtTodayTimeC" runat="server"  CssClass="txtDispDateTo"></asp:TextBox>
                        </section>
                        <section class="topRight2">
                            <%--  <asp:Label ID="lbl" runat="server" Text="Ausgwählter Zeitbereich:" CssClass="lblPrintMode" Style="width: 56%;"></asp:Label>
                            <asp:Label ID="lblTimePrintType" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>--%>
                            <section class="loggedInUser">
                                <asp:Label ID="Label121" runat="server" Text="<%$ Resources:localizedText, createdBy %>" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblLoggedInUserC" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>
                        </section>
                        <section class="topRight3perpekind">
                            <section class="secholdingarea1_new">
                                <asp:Label ID="Label39" runat="server" Text="<%$ Resources:localizedText, potrait %>" CssClass="txtportrait"></asp:Label>
                                <asp:ImageButton ID="imgPotraitC" runat="server" CssClass="btnorientation1" Style="cursor: default;" />
                                <asp:CheckBox ID="chkVarCPotait" runat="server" CssClass="chk1controllast" />

                            </section>
                            <section class="secholdingarea1b_new">
                                <asp:Label ID="Label44" runat="server" Text="<%$ Resources:localizedText, landScape %>" CssClass="txtlandscape_new"></asp:Label>
                                <asp:ImageButton ID="imgLandC" runat="server" CssClass="btnorientation2" Style="cursor: default;" />
                                <asp:CheckBox ID="chkVarCLand" runat="server" CssClass="chk1controllast" />

                            </section>
                        </section>
                    </section>
                    <section class="selectionThree">
                        <section class="topRight1" style="margin-top: 5px;">
                        </section>
                        <section class="topRight2">
                        </section>
                        <section class="topRight3">
                        </section>

                    </section>
                </section>
            </section>
        </section>
        <section class="mainBodybtm">
            <dx:ASPxGridView ID="grdVaribleC" runat="server" ClientIDMode="Static" ClientInstanceName="grdVaribleC" Theme="Office2003Blue" SettingsPager-AlwaysShowPager="false" Settings-ShowFooter="false" SettingsBehavior-AllowSort="true" SettingsBehavior-AllowDragDrop="false" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdVaribleC_CustomCallback">

                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, visitorsCompanyTitle %>" VisibleIndex="1" FieldName="VisitorCompany"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, visitorsPerson %>" VisibleIndex="2" FieldName="Name"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, visitorsId_NewP %>" VisibleIndex="6" FieldName="PersonID" CellStyle-HorizontalAlign="Left"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, cardNr %> " VisibleIndex="4" FieldName="CardNumber"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, CompanyTitle %>" VisibleIndex="5" FieldName="PersClient"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Standort" VisibleIndex="6" Visible="false" FieldName="PersLocation">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Abteilung" Visible="false" VisibleIndex="7" FieldName="PersDepartement"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Kostenstelle" Visible="false" VisibleIndex="8" FieldName="PersCostCenter">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="BookingDate" Caption="K-Datum:" VisibleIndex="9">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="EntryDate" Caption="<%$ Resources:localizedText, entryTime %>" VisibleIndex="10">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="" Caption="G-Datum" VisibleIndex="11">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="ExitDate" Caption="<%$ Resources:localizedText, exitTime %>" VisibleIndex="12">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                </Columns>
            </dx:ASPxGridView>
        </section>
    </section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnPrintReport" CssClass="btnPrintReport setHover" runat="server" Text="<%$ Resources:localizedText, printAccessProtocol %>" Style="display: none;" />
    <asp:Button ID="btnPrintSelection" ClientIDMode="Static" runat="server" CssClass="btnPrintReport setHover" Text="<%$ Resources:localizedText, printSelection_title %>" Style="width: 106px;" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" ClientIDMode="Static" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
