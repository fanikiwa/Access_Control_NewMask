<%@ Page Title="<%$ Resources:localizedText, attendanceTimesPersonal %>" Language="C#" MasterPageFile="~/MasterPages/Reports.Master" ClientIDMode="Static" AutoEventWireup="true" CodeBehind="ReportsPersonalAttendancetimes.aspx.cs" Inherits="Access_Control_NewMask.Content.ReportsPersonalAttendancetimes" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.2.Web, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/ReportPersonalAttendanceTimes.js"></script>
    <link href="Styles/ReportsPersonalAttendancetimes.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="ContentAreaDiv">
        <div id="ControlSection1" class="TopContentAreaDiv">
            <asp:HiddenField ID="HiddenField1BackValue" runat="server" />
            <asp:HiddenField ID="hiddenFieldSaveChanges" runat="server" />
            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, attendanceTimesTheStaffArePrintedConstructionReview %>" CssClass="lbltoparea"></asp:Label>
        </div>
        <div id="MainContdiv">
            <section class="midareaholder">
                <section class="topareatitles">
                    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, printSelection_New %>" CssClass="lbltopareafirst"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, printStartAfter %>" CssClass="lbltopareafirstright"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, selectionOfReports_new %>" CssClass="lbltopareafirstrightB"></asp:Label>
                </section>
                <section class="areasixitems">
                    <asp:Label ID="Label5" runat="server" Text="<%$ Resources:localizedText, dateFrom_newP %>" CssClass="lbltopareafirstdateleft"></asp:Label>
                    <dx:ASPxDateEdit ID="dtpFrom" runat="server" HorizontalAlign="Center" Theme="Office2003Blue" CssClass="dtFrom">
                        <ClientSideEvents DateChanged="function(s, e) {drpPlanDateFromChanged(s, e, dtpTo);}"></ClientSideEvents>
                    </dx:ASPxDateEdit>
                    <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbltopareafirstto"></asp:Label>
                    <dx:ASPxDateEdit ID="dtpTo" HorizontalAlign="Center" runat="server" Theme="Office2003Blue" CssClass="dtFrom">
                        <ClientSideEvents DateChanged="function(s, e) {drpPlanDateToChanged(s, e);}"></ClientSideEvents>
                    </dx:ASPxDateEdit>
                    <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText, date_new %>" CssClass="lbltopareafirstdate"></asp:Label>
                    <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="dtFromlast">
                        <asp:TableRow CssClass="rowOne">
                            <asp:TableCell ID="lhjbl" CssClass="tblCell3">
                                <asp:CheckBox ID="chkname" runat="server" /><label for='chkname'></label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:CheckBox ID="chkVariableA" ClientIDMode="Static" runat="server" CssClass="chkAccssDataarea chkAllvar" />
                    <asp:Label ID="Label8" runat="server" Text="<%$ Resources:localizedText, variantA %>" CssClass="lblvariantlast"></asp:Label>

                </section>

                <section class="areasixitemsright">
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label13" runat="server" Text="<%$ Resources:localizedText, companyFrom %>" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboClientName" CallbackPageSize="100000" SelectedIndex="0" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ClientIDMode="Static" ClientInstanceName="cboClientName" runat="server" ValueField="ID" TextField="Name" Theme="Office2003Blue" CssClass="cmbFrombottom">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cboClientNamePersonal(s, e);}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" FieldName="Client_Nr" Width="20%" />
                                <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, companynew %>" FieldName="Name" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label14" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboClientNameto" CallbackPageSize="100000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ValueField="ID" TextField="Name" ClientIDMode="Static" ClientInstanceName="cboClientNameto" SelectedIndex="0" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFromarea2">
                            <Columns>
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" FieldName="Client_Nr" Width="20%" />
                                <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, companynew %>" FieldName="Name" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label15" runat="server" Text="<%$ Resources:localizedText, company_Title %>" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chkPersonalDate" runat="server" /><label for='chkPersonalDate'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </section>
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label16" runat="server" Text="<%$ Resources:localizedText, locationFrom_new %>" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="cbolocationPersonalFrm" CallbackPageSize="100000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" SelectedIndex="0" ValueField="ID" TextField="Name" ClientIDMode="Static" ClientInstanceName="cbolocationPersonalFrm" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFrombottom">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cbolocationPersonal(s, e);}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn Caption="Nr.:" FieldName="Location_Nr" Width="20%" />
                                <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, location1 %>" FieldName="Name" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label17" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="cbolocationPersonalTo" CallbackPageSize="100000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ClientIDMode="Static" ClientInstanceName="cbolocationPersonalTo" ValueField="ID" TextField="Name" SelectedIndex="0" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFromarea2">
                            <Columns>
                                <dx:ListBoxColumn Caption="Nr.:" FieldName="Location_Nr" Width="20%" />
                                <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, location1 %>" FieldName="Name" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label18" runat="server" Text="<%$ Resources:localizedText, locationnew %>" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chkcostcenter" runat="server" /><label for='chkcostcenter'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </section>
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label20" runat="server" Text="<%$ Resources:localizedText, departmentFrom %>" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboDeptName" CallbackPageSize="100000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ClientIDMode="Static" SelectedIndex="0" ClientInstanceName="cboDeptName" ValueField="ID" TextField="Name" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFrombottom">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cboDeptNamePersonal(s, e);}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn Caption="Nr.:" FieldName="Department_Nr" Width="20%" />
                                <dx:ListBoxColumn Caption="Name:" FieldName="Name" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label21" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboDeptNameTo" CallbackPageSize="100000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ClientIDMode="Static" ClientInstanceName="cboDeptNameTo" ValueField="ID" TextField="Name" SelectedIndex="0" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFromarea2">
                            <Columns>
                                <dx:ListBoxColumn Caption="Nr.:" FieldName="Department_Nr" Width="20%" />
                                <dx:ListBoxColumn Caption="Name:" FieldName="Name" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label22" runat="server" Text="<%$ Resources:localizedText, departmentTitle %>" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chkdepartment" runat="server" /><label for='chkdepartment'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </section>
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label23" runat="server" Text="<%$ Resources:localizedText, costCenterFrom %>" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboCostCenterName" CallbackPageSize="100000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ClientIDMode="Static" ClientInstanceName="cboCostCenterName" ValueField="ID" TextField="Name" SelectedIndex="0" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFrombottom">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cboCostCenterNamePersonal(s, e);}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn Caption="Nr.:" FieldName="CostCenter_Nr" Width="20%" />
                                <dx:ListBoxColumn Caption="Name:" FieldName="Name" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label24" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboCostCenterNameTo" CallbackPageSize="100000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ValueField="ID" TextField="Name" SelectedIndex="0" ClientIDMode="Static" ClientInstanceName="cboCostCenterNameTo" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFromarea2">
                            <Columns>
                                <dx:ListBoxColumn Caption="Nr.:" FieldName="CostCenter_Nr" Width="20%" />
                                <dx:ListBoxColumn Caption="Name:" FieldName="Name" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label25" runat="server" Text="<%$ Resources:localizedText, costCenterTitle %>" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chklocation" runat="server" /><label for='chklocation'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </section>
                </section>
                <section class="lastvariant">
                    <asp:CheckBox ID="chkVaribleB" ClientIDMode="Static" runat="server" CssClass="chkAccssDataareaB chkAllvar" />
                    <asp:Label ID="Label19" runat="server" Text="<%$ Resources:localizedText, variantB %>" CssClass="lblvariantlastarea"></asp:Label>
                </section>


                <section class="areasixitemsrightlast">
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label12" runat="server" Text="<%$ Resources:localizedText, nameFrom_P %>" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="cmbPersName" CallbackPageSize="100000" TextFormatString="{1} {2}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" SelectedIndex="0" ValueField="Pers_Nr" TextField="FullName" ClientIDMode="Static" ClientInstanceName="cmbPersName" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFrombottom">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cmbPersNamePersonal(s, e);}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn FieldName="Pers_Nr" Caption="Pers. Nr." Name="ProfileDescription" ToolTip="" Width="18%" />
                                <dx:ListBoxColumn FieldName="FirstName" Caption="Name:" Name="FirstName" ToolTip="Bezeichnung:" Width="42%" />
                                <dx:ListBoxColumn FieldName="LastName" Caption="<%$ Resources:localizedText ,firstname_new%>" Name="LastName" ToolTip="Bezeichnung:" Width="42%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label26" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="cmbPersNameTo" CallbackPageSize="100000" TextFormatString="{1} {2}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ValueField="Pers_Nr" TextField="FullName" SelectedIndex="0" ClientIDMode="Static" ClientInstanceName="cmbPersNameTo" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFromarea2">
                            <Columns>
                                <dx:ListBoxColumn FieldName="Pers_Nr" Caption="Pers. Nr." Name="ProfileDescription" ToolTip="" Width="18%" />
                                <dx:ListBoxColumn FieldName="FirstName" Caption="Name:" Name="FirstName" ToolTip="Bezeichnung:" Width="42%" />
                                <dx:ListBoxColumn FieldName="LastName" Caption="<%$ Resources:localizedText ,firstname_new%>" Name="LastName" ToolTip="Bezeichnung:" Width="42%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label27" runat="server" Text="Name:" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chkcompany" runat="server" /><label for='chkcompany'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </section>
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label28" runat="server" Text="<%$ Resources:localizedText ,personIdFrom%>" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboPersonalID" CallbackPageSize="100000" SelectedIndex="0" HorizontalAlign="left" runat="server" ClientInstanceName="cboPersonalID" ClientIDMode="Static" ValueField="Pers_Nr" TextField="Pers_Nr" EnableCallbackMode="true" AutoPostBack="false"
                            TextFormatString="{0}" CssClass="cmbFrombottom" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" DropDownWidth="400px" Theme="Office2003Blue">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cboPersonalIDSelected(s, e);}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn FieldName="Pers_Nr" Caption="ID Nr.:" Name="ProfileDescription" ToolTip="" Width="18%" />
                                <dx:ListBoxColumn FieldName="FirstName" Caption="Name:" Name="FirstName" ToolTip="Bezeichnung:" Width="42%" />
                                <dx:ListBoxColumn FieldName="LastName" Caption="<%$ Resources:localizedText ,firstname_new%>" Name="LastName" ToolTip="Bezeichnung:" Width="42%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label29" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="cmbIDNrTo" CallbackPageSize="100000" SelectedIndex="0" HorizontalAlign="left" runat="server" ClientInstanceName="cmbIDNrTo" ClientIDMode="Static" ValueField="Pers_Nr" TextField="Pers_Nr" EnableCallbackMode="true" AutoPostBack="false"
                            TextFormatString="{0}" CssClass="cmbFromarea2" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" Theme="Office2003Blue">
                            <Columns>
                                <dx:ListBoxColumn FieldName="Pers_Nr" Caption="ID Nr.:" Name="ProfileDescription" ToolTip="" Width="18%" />
                                <dx:ListBoxColumn FieldName="FirstName" Caption="Name:" Name="FirstName" ToolTip="Bezeichnung:" Width="42%" />
                                <dx:ListBoxColumn FieldName="LastName" Caption="<%$ Resources:localizedText ,firstname_new%>" Name="LastName" ToolTip="Bezeichnung:" Width="42%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label30" runat="server" Text="<%$ Resources:localizedText ,personId%>" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chkaust" runat="server" /><label for='chkaust'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </section>
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label31" runat="server" Text="<%$ Resources:localizedText ,cardNoFrom%>" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboLongTransponder" CallbackPageSize="100000" SelectedIndex="0" ValueField="ID" TextField="TransponderNr" ClientIDMode="Static" ClientInstanceName="cboLongTransponder" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFrombottom" DropDownWidth="200px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                            <Columns>
                                <dx:ListBoxColumn FieldName="TransponderNr" Caption="<%$ Resources:localizedText ,cardnumber%>" Name="ProfileDescription" ToolTip="" Width="18%" />
                                <%--  <dx:ListBoxColumn FieldName="FirstName" Caption="Name:" Name="FirstName" ToolTip="Bezeichnung:" Width="42%" />
                                <dx:ListBoxColumn FieldName="LastName" Caption="<%$ Resources:localizedText ,firstname_new%>" Name="LastName" ToolTip="Bezeichnung:" Width="42%" />--%>
                            </Columns>
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cboLongTransponderePersonal(s, e);}"></ClientSideEvents>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label32" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboLongTransponderTo" CallbackPageSize="100000" runat="server" SelectedIndex="0" ValueField="ID" TextField="TransponderNr" ClientIDMode="Static" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFromarea2" DropDownWidth="200px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                            <Columns>
                                <dx:ListBoxColumn FieldName="TransponderNr" Caption="<%$ Resources:localizedText ,cardnumber%>" Name="ProfileDescription" ToolTip="" Width="18%" />
                                <%--  <dx:ListBoxColumn FieldName="FirstName" Caption="Name:" Name="FirstName" ToolTip="Bezeichnung:" Width="42%" />
                                <dx:ListBoxColumn FieldName="LastName" Caption="<%$ Resources:localizedText ,firstname_new%>" Name="LastName" ToolTip="Bezeichnung:" Width="42%" />--%>
                            </Columns>

                        </dx:ASPxComboBox>
                        <asp:Label ID="Label33" runat="server" Text="<%$ Resources:localizedText ,cardnumber%>" CssClass="lbltopareafirstdatebottom"></asp:Label>
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
                    <asp:CheckBox ID="chkVaribleC" ClientIDMode="Static" runat="server" CssClass="chkAccssDataareaClast chkAllvar" />
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
                        <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText ,companyFrom%>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label11" runat="server" Text="<%$ Resources:localizedText, locationFrom_new %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label63" runat="server" Text="<%$ Resources:localizedText, departmentFrom_new %>" CssClass="lblreport"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="txtClientFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtLocFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtDept" runat="server" CssClass="drpreport"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label64" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label65" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label66" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp4New">

                        <asp:TextBox ID="txtClientTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtLocTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtDeptTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left3">
                    <section class="selectionOne">
                        <section class="topRight1">
                            <asp:Label ID="Label67" runat="server" Text="<%$ Resources:localizedText, costcenter2 %>" CssClass="lblDateTitle" Style="width: 16%"></asp:Label>
                            <asp:Label ID="Label68" runat="server" Text="<%$ Resources:localizedText, fromTitle %>" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="txtCostCenterFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label69" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtCostCenterTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight2">
                            <asp:Label ID="Label70" runat="server" Text="<%$ Resources:localizedText, printingStart %>" CssClass="lblPrintMode" Style="margin-left: 12%;"></asp:Label>
                            <asp:Label ID="lblReportType" runat="server" Text="<%$ Resources:localizedText, variantA %>" CssClass="lblTimeHrsMode"></asp:Label>
                        </section>
                        <section class="topRight3" style="display: none">
                            <asp:Label ID="Label71" runat="server" Text="Objekt" CssClass="lblPrintModeobj"></asp:Label>
                        </section>
                    </section>
                    <section class="selectionTwo">
                        <section class="topRight1">
                            <asp:Label ID="Label74" runat="server" Text="<%$ Resources:localizedText, date_new %>" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label76" runat="server" Text="<%$ Resources:localizedText, fromnew %>" CssClass="lblDtFromTitle" Style="width: 13%;"></asp:Label>

                            <asp:TextBox ID="txtDateFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label77" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtDateTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>
                        </section>
                        <section class="topRight2">
                            <%--  <asp:Label ID="lbl" runat="server" Text="Ausgwählter Zeitbereich:" CssClass="lblPrintMode" Style="width: 56%;"></asp:Label>
                            <asp:Label ID="lblTimePrintType" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>--%>
                            <section class="loggedInUser">
                                <asp:Label ID="Label75" runat="server" Text="<%$ Resources:localizedText, createdBy %>" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblPersName" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>
                        </section>
                        <section class="topRight3" style="display: none">
                        </section>
                    </section>
                    <section class="selectionThree">
                        <section class="topRight1" style="margin-top: 5px;">
                            <asp:Label ID="Label72" runat="server" Text="<%$ Resources:localizedText, printedOn %>" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtPrintDate" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label73" runat="server" Text="<%$ Resources:localizedText, timeTitle %>" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtPrintTime" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>

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
                        <section class="topRight3">
                        </section>

                    </section>
                </section>
            </section>
        </section>
        <section class="mainBodybtm">
            <dx:ASPxGridView ID="grdShowReport" runat="server" ClientIDMode="Static" ClientInstanceName="grdShowReport" Theme="Office2003Blue" SettingsPager-AlwaysShowPager="false" Settings-ShowFooter="false" SettingsBehavior-AllowSort="true" SettingsBehavior-AllowDragDrop="true" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdShowReport_CustomCallback" OnHtmlDataCellPrepared="grdShowReport_HtmlDataCellPrepared">

                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="BookingDate" Caption="<%$ Resources:localizedText, date_new %>" VisibleIndex="1">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, company_Title %>" VisibleIndex="2" FieldName="PersClient"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, locationnew %>" VisibleIndex="3" FieldName="PersLocation">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, departmentTitle %>" VisibleIndex="4" FieldName="PersDepartement"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, costCenterTitle %>" VisibleIndex="5" FieldName="PersCostCenter">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Name:" VisibleIndex="6" FieldName="Name"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, personId %>" VisibleIndex="7" FieldName="PersonID" CellStyle-HorizontalAlign="Left"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, idNo %>" VisibleIndex="8" FieldName="CardNumber"></dx:GridViewDataTextColumn>
                    <%--<dx:GridViewDataDateColumn FieldName="EntryDate" Caption="K-Uhrzeit" VisibleIndex="9">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="ExitDate" Caption="G-Uhrzeit" VisibleIndex="10">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="Duration" Caption="Zeit" VisibleIndex="11">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>--%>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, entryTime %>" VisibleIndex="10" Width="3%"  FieldName="EntryTimeText">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <HeaderStyle  HorizontalAlign="Center"/>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, exitTime %>" VisibleIndex="11" Width="3%" FieldName="ExitTimeText">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <HeaderStyle  HorizontalAlign="Center"/>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, totalTime %>" VisibleIndex="12" Width="3%" FieldName="DurationText">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <HeaderStyle  HorizontalAlign="Center"/>
                    </dx:GridViewDataTextColumn>

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
                        <asp:Label ID="Label9" runat="server" Text="<%$ Resources:localizedText, companyFrom %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label35" runat="server" Text="<%$ Resources:localizedText, locationFrom_new %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label36" runat="server" Text="<%$ Resources:localizedText, departmentFrom_new %>" CssClass="lblreport"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="txtClientBFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtLocationBFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtDeptBFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label37" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label38" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label39" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp4New">

                        <asp:TextBox ID="txtClientBTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtLocationBTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtDeptBTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left3">
                    <section class="selectionOne">
                        <section class="topRight1">
                            <asp:Label ID="Label40" runat="server" Text="<%$ Resources:localizedText, costcenter2 %>" CssClass="lblDateTitle" Style="width: 16%"></asp:Label>
                            <asp:Label ID="Label41" runat="server" Text="<%$ Resources:localizedText, fromnew %>" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="txtCostBFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label42" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtCostBTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight2" style="width: 32%;">
                            <asp:Label ID="Label43" runat="server" Text="<%$ Resources:localizedText, printingStart %>" CssClass="lblPrintMode" Style="margin-left: 12%;"></asp:Label>
                            <asp:Label ID="Label44" runat="server" Text="<%$ Resources:localizedText, variantB %>" CssClass="lblTimeHrsMode"></asp:Label>
                        </section>
                        <section class="topRight3" style="display: none">
                            <asp:Label ID="Label45" runat="server" Text="Objekt" CssClass="lblPrintModeobj"></asp:Label>
                        </section>
                    </section>
                    <section class="selectionTwo">
                        <section class="topRight1">
                            <asp:Label ID="Label46" runat="server" Text="<%$ Resources:localizedText, date_new %>" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label47" runat="server" Text="<%$ Resources:localizedText, fromnew %>" CssClass="lblDtFromTitle" Style="width: 13%;"></asp:Label>

                            <asp:TextBox ID="txtDateBFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label48" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtDateBTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>
                        </section>
                        <section class="topRight2">
                            <%--  <asp:Label ID="lbl" runat="server" Text="Ausgwählter Zeitbereich:" CssClass="lblPrintMode" Style="width: 56%;"></asp:Label>
                            <asp:Label ID="lblTimePrintType" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>--%>
                            <section class="loggedInUser">
                                <asp:Label ID="Label49" runat="server" Text="<%$ Resources:localizedText, createdBy %>" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblLoggedInUser" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>
                        </section>
                        <section class="topRight3" style="display: none">
                        </section>
                    </section>
                    <section class="selectionThree">
                        <section class="topRight1" style="margin-top: 5px;">
                            <asp:Label ID="Label51" runat="server" Text="<%$ Resources:localizedText, printedOn %>" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtTodayDate" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label52" runat="server" Text="<%$ Resources:localizedText, timeTitle %>" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtTodayTime" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight3perpekind">
                            <section class="secholdingarea1_new">
                                <asp:Label ID="Label87" runat="server" Text="<%$ Resources:localizedText, potrait %>" CssClass="txtportrait"></asp:Label>
                                <asp:ImageButton ID="imgPotraiB" runat="server" CssClass="btnorientation1" Style="cursor:default;"/>
                                <asp:CheckBox ID="chkVarientBPotrait" runat="server" CssClass="chk1controllast" />

                            </section>
                            <section class="secholdingarea1b_new">
                                <asp:Label ID="Label88" runat="server" Text="<%$ Resources:localizedText, landScape %>" CssClass="txtlandscape_new"></asp:Label>
                                <asp:ImageButton ID="imgLandB" runat="server" CssClass="btnorientation2" Style="cursor:default;"/>
                                <asp:CheckBox ID="chkVarientBLand" runat="server" CssClass="chk1controllast" />

                            </section>
                        </section>
                        <section class="topRight3">
                        </section>

                    </section>
                </section>
            </section>
        </section>
        <section class="mainBodybtm">
            <dx:ASPxGridView ID="grdVarialeB" runat="server" ClientIDMode="Static" ClientInstanceName="grdVarialeB" Theme="Office2003Blue" SettingsPager-AlwaysShowPager="false" Settings-ShowFooter="false" SettingsBehavior-AllowSort="true" SettingsBehavior-AllowDragDrop="false" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdVarialeB_CustomCallback" OnHtmlDataCellPrepared="grdVarialeB_HtmlDataCellPrepared">

                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, company_Title %>" VisibleIndex="1" FieldName="PersClient"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, locationnew %>" VisibleIndex="2" FieldName="PersLocation">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, departmentTitle %>" VisibleIndex="3" FieldName="PersDepartement"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, costCenterTitle %>" VisibleIndex="4" FieldName="PersCostCenter">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Name:" VisibleIndex="5" FieldName="Name"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, personId %>" VisibleIndex="6" Visible="false" FieldName="PersonID" CellStyle-HorizontalAlign="Left"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, idNo %>" VisibleIndex="7" FieldName="CardNumber"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="BookingDate" Caption="<%$ Resources:localizedText, date_new %>" VisibleIndex="8">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <%--<dx:GridViewDataDateColumn FieldName="EntryDate" Caption="K-Uhrzeit" VisibleIndex="9">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="ExitDate" Caption="G-Uhrzeit" VisibleIndex="10">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="Duration" Caption="Zeit" VisibleIndex="11">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>--%>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, entryTime %>" VisibleIndex="10" Width="3%"  FieldName="EntryTimeText">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <HeaderStyle  HorizontalAlign="Center"/>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, exitTime %>" VisibleIndex="11" Width="3%" FieldName="ExitTimeText">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <HeaderStyle  HorizontalAlign="Center"/>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, totalTime %>" VisibleIndex="12" Width="3%" FieldName="DurationText">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <HeaderStyle  HorizontalAlign="Center"/>
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
        </section>
    </section>
    <section class="showReportsVarC" style="display: none">
        <section class="mainBodyTop">
            <section class="mainBodyTop1 ">
                <section class="mainBodyTop1left">
                    <section class="mainBodyTop1leftlbl">
                        <asp:Label ID="Label53" runat="server" Text="<%$ Resources:localizedText, companyFrom %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label54" runat="server" Text="<%$ Resources:localizedText, locationFrom_new %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label55" runat="server" Text="<%$ Resources:localizedText, departmentFrom_new %>" CssClass="lblreport"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="txtClientCFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtLocationCFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtDeptCFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label56" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label57" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label58" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp4New">

                        <asp:TextBox ID="txtClientCTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtLocationCTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtDeptCTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left3">
                    <section class="selectionOne">
                        <section class="topRight1">
                            <asp:Label ID="Label59" runat="server" Text="<%$ Resources:localizedText, costcenter2 %>" CssClass="lblDateTitle" Style="width: 16%"></asp:Label>
                            <asp:Label ID="Label60" runat="server" Text="<%$ Resources:localizedText, fromnew %>" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="txtCostCFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label61" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtCoastCTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight2" style="width: 32%;">
                            <asp:Label ID="Label62" runat="server" Text="<%$ Resources:localizedText, printingStart %>" CssClass="lblPrintMode" Style="margin-left: 12%;"></asp:Label>
                            <asp:Label ID="Label78" runat="server" Text="<%$ Resources:localizedText, variantC %>" CssClass="lblTimeHrsMode"></asp:Label>
                        </section>
                        <section class="topRight3" style="display: none">
                            <asp:Label ID="Label79" runat="server" Text="Objekt" CssClass="lblPrintModeobj"></asp:Label>
                        </section>
                    </section>
                    <section class="selectionTwo">
                        <section class="topRight1">
                            <asp:Label ID="Label80" runat="server" Text="<%$ Resources:localizedText, date_new %>" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label81" runat="server" Text="<%$ Resources:localizedText, fromnew %>" CssClass="lblDtFromTitle" Style="width: 13%;"></asp:Label>

                            <asp:TextBox ID="txtDateCFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label82" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtDateCTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>
                        </section>
                        <section class="topRight2">
                            <%--  <asp:Label ID="lbl" runat="server" Text="Ausgwählter Zeitbereich:" CssClass="lblPrintMode" Style="width: 56%;"></asp:Label>
                            <asp:Label ID="lblTimePrintType" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>--%>
                            <section class="loggedInUser">
                                <asp:Label ID="Label83" runat="server" Text="<%$ Resources:localizedText, createdBy %>" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblLoggedInUserPers" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>
                        </section>
                        <section class="topRight3" style="display: none">
                        </section>
                    </section>
                    <section class="selectionThree">
                        <section class="topRight1" style="margin-top: 5px;">
                            <asp:Label ID="Label85" runat="server" Text="<%$ Resources:localizedText, printedOn %>" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtTodayDateC" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label86" runat="server" Text="<%$ Resources:localizedText, timeTitle %>" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtTodayTimeC" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight3perpekind">
                            <section class="secholdingarea1_new">
                                <asp:Label ID="Label89" runat="server" Text="<%$ Resources:localizedText, potrait %>" CssClass="txtportrait"></asp:Label>
                                <asp:ImageButton ID="imgPotraitC" runat="server" CssClass="btnorientation1" Style="cursor:default;"/>
                                <asp:CheckBox ID="chkVarCPotait" runat="server" CssClass="chk1controllast" />

                            </section>
                            <section class="secholdingarea1b_new">
                                <asp:Label ID="Label90" runat="server" Text="<%$ Resources:localizedText, landScape %>" CssClass="txtlandscape_new"></asp:Label>
                                <asp:ImageButton ID="imgLandC" runat="server" CssClass="btnorientation2" Style="cursor:default;"/>
                                <asp:CheckBox ID="chkVarCLand" runat="server" CssClass="chk1controllast" />

                            </section>
                        </section>
                        <section class="topRight3">
                        </section>

                    </section>
                </section>
            </section>
        </section>
        <section class="mainBodybtm">
            <dx:ASPxGridView ID="grdVaribleC" runat="server" ClientIDMode="Static" ClientInstanceName="grdVaribleC" Theme="Office2003Blue" SettingsPager-AlwaysShowPager="false" Settings-ShowFooter="false" SettingsBehavior-AllowSort="true" SettingsBehavior-AllowDragDrop="false" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdVaribleC_CustomCallback" OnHtmlDataCellPrepared="grdVaribleC_HtmlDataCellPrepared">

                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Name:" VisibleIndex="1" FieldName="Name"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, personId %>" VisibleIndex="2" FieldName="PersonID" CellStyle-HorizontalAlign="Left"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, idNo %>" VisibleIndex="3" FieldName="CardNumber"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, company_Title %>" VisibleIndex="4" FieldName="PersClient"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, locationnew %>" VisibleIndex="5" FieldName="PersLocation">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, departmentTitle %>" VisibleIndex="6" FieldName="PersDepartement"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, costCenterTitle %>" VisibleIndex="7" FieldName="PersCostCenter">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataDateColumn FieldName="BookingDate" Caption="<%$ Resources:localizedText, date_new %>" VisibleIndex="8">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <%--<dx:GridViewDataDateColumn FieldName="EntryDate" Caption="K-Uhrzeit" VisibleIndex="9">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="ExitDate" Caption="G-Uhrzeit" VisibleIndex="10">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="Duration" Caption="Zeit" VisibleIndex="11">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>--%>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, entryTime %>" VisibleIndex="10" Width="3%"  FieldName="EntryTimeText">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <HeaderStyle  HorizontalAlign="Center"/>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, exitTime %>" VisibleIndex="11" Width="3%" FieldName="ExitTimeText">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <HeaderStyle  HorizontalAlign="Center"/>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, totalTime %>" VisibleIndex="12" Width="3%" FieldName="DurationText">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <HeaderStyle  HorizontalAlign="Center"/>
                    </dx:GridViewDataTextColumn>
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
