<%@ Page Title="<%$ Resources:localizedText, cardInfoPersonal %>" Language="C#" MasterPageFile="~/MasterPages/Reports.Master" AutoEventWireup="true" CodeBehind="ReportPersonalCardInfo.aspx.cs" Inherits="Access_Control_NewMask.Content.ReportPersonalCardInfo" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.2.Web, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/ReportPersonalCardInfo.js"></script>
    <link href="Styles/ReportPersonalCardInfo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="ContentAreaDiv">
        <asp:HiddenField ID="HiddenField1BackValue" runat="server" />
        <div class="TopContentAreaDiv">
            <section class="sectop">

                <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, activeCards %>" CssClass="lblalleanswe"></asp:Label>
                <asp:CheckBox ID="chkActiveCards" runat="server" CssClass="chkanwse" />
                <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, extendedCards %>" CssClass="lblalleabswe"></asp:Label>
                <asp:CheckBox ID="chkExtendedCards" runat="server" CssClass="chkabwse" />
                <asp:Label ID="Label5" runat="server" Text="<%$ Resources:localizedText, inactiveCards %>" CssClass="lblalleget"></asp:Label>
                <asp:CheckBox ID="chkInactiveCards" runat="server" CssClass="chkallget" />
                <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText, allCards %>" CssClass="lbldatum"></asp:Label>
                <asp:CheckBox ID="chkAllCards" runat="server" CssClass="chkallget" />
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
                            <dx:ASPxDateEdit ID="datePickerFrom" ClientInstanceName="datePickerFrom" runat="server" HorizontalAlign="Center" Theme="Office2003Blue" CssClass="datedis">

                                <ClientSideEvents DateChanged="function(s, e) {
dateFromChanged(s,e);
}"></ClientSideEvents>
                            </dx:ASPxDateEdit>
                            <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                            <dx:ASPxDateEdit ID="datePickerTo" ClientInstanceName="datePickerTo" runat="server" HorizontalAlign="Center" Theme="Office2003Blue" CssClass="datedis">
                                <ClientSideEvents DateChanged="function(s, e) {
dateToChanged(s,e);
}"></ClientSideEvents>
                            </dx:ASPxDateEdit>
                        </section>
                        <section class="topsec1left2">
                            <asp:Label ID="Label40" runat="server" Text="<%$ Resources:localizedText, viewAllRelevantInThisSelectedDateRangeData %>" CssClass="lblqckdruk"></asp:Label>
                            <asp:CheckBox ID="CheckBox4" runat="server" CssClass="chknew" />
                        </section>
                        <section class="topsec1left2">
                            <asp:Label ID="Label12" runat="server" Text="<%$ Resources:localizedText, companyFrom %>" CssClass="lbldatefrom"></asp:Label>
                            <dx:ASPxComboBox ID="cobCompanyFrom" ClientInstanceName="cobCompanyFrom" ValueField="ID" TextField="Name" TextFormatString="{1}" CallbackPageSize="100000" runat="server" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobCompanyFromIndexChanged(s,e);	
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr:" Name="Client_Nr" FieldName="Client_Nr" Width="15%" />
                                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, companynew %>" Name="Name" FieldName="Name" Width="85%" />
                                </Columns>
                            </dx:ASPxComboBox>
                            <asp:Label ID="Label19" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                            <dx:ASPxComboBox ID="cobCompanyTo" ClientInstanceName="cobCompanyTo" ValueField="ID" TextField="Name" TextFormatString="{1}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobCompanyToIndexChanged(s,e);	
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr:" Name="Client_Nr" FieldName="Client_Nr" Width="15%" />
                                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, companynew %>" Name="Name" FieldName="Name" Width="85%" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>
                        <section class="topsec1left2">
                            <asp:Label ID="Label13" runat="server" Text="<%$ Resources:localizedText, locationFrom_new %>" CssClass="lbldatefrom"></asp:Label>
                            <dx:ASPxComboBox ID="cobLocationFrom" ClientInstanceName="cobLocationFrom" TextFormatString="{1}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobLocationFromIndexChanged(s,e);	
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr:" Name="Location_Nr" FieldName="Location_Nr" Width="15%" />
                                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, location1 %>" Name="Name" FieldName="Name" Width="85%" />
                                </Columns>
                            </dx:ASPxComboBox>
                            <asp:Label ID="Label14" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                            <dx:ASPxComboBox ID="cobLocationTo" ClientInstanceName="cobLocationTo" TextFormatString="{1}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobLocationToIndexChanged(s,e);	
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr:" Name="Location_Nr" FieldName="Location_Nr" Width="15%" />
                                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, location1 %>" Name="Name" FieldName="Name" Width="85%" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>
                        <section class="topsec1left2">
                            <asp:Label ID="Label15" runat="server" Text="<%$ Resources:localizedText, departmentFrom %>" CssClass="lbldatefrom"></asp:Label>
                            <dx:ASPxComboBox ID="cobDepartmentFrom" ClientInstanceName="cobDepartmentFrom" TextFormatString="{1}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobDepartmentFromIndexChanged(s,e);	
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr:" Name="Department_Nr" FieldName="Department_Nr" />
                                    <dx:ListBoxColumn Caption="Name:" Name="Name" FieldName="Name" />
                                </Columns>
                            </dx:ASPxComboBox>
                            <asp:Label ID="Label16" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                            <dx:ASPxComboBox ID="cobDepartmentTo" ClientInstanceName="cobDepartmentTo" TextFormatString="{1}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobDepartmentToIndexChanged(s,e);	
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr:" Name="Department_Nr" FieldName="Department_Nr" />
                                    <dx:ListBoxColumn Caption="Name:" Name="Name" FieldName="Name" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>
                        <section class="topsec1left2">
                            <asp:Label ID="Label17" runat="server" Text="<%$ Resources:localizedText, nameFrom_P %>" CssClass="lbldatefrom"></asp:Label>
                            <dx:ASPxComboBox ID="cobNameFrom" SelectedIndex="0" ClientInstanceName="cobNameFrom" ValueField="ID" TextField="Name" TextFormatString="{1}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobNameFromIndexChanged(s,e);	
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr:" Name="Pers_Nr" FieldName="Pers_Nr" Width="15%" />
                                    <dx:ListBoxColumn Caption="Name:" Name="Name" FieldName="Name" Width="85%" />
                                </Columns>
                            </dx:ASPxComboBox>
                            <asp:Label ID="Label18" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                            <dx:ASPxComboBox ID="cobNameTo" SelectedIndex="0" ClientInstanceName="cobNameTo" ValueField="ID" TextField="Name" TextFormatString="{1}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobNameToIndexChanged(s,e);	
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr:" Name="Pers_Nr" FieldName="Pers_Nr" Width="15%" />
                                    <dx:ListBoxColumn Caption="Name:" Name="Name" FieldName="Name" Width="85%" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>
                        <section class="topsec1left2">
                            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, idNoFrom %>" CssClass="lbldatefrom"></asp:Label>
                            <dx:ASPxComboBox ID="cobPersNrFrom" SelectedIndex="0" ClientInstanceName="cobPersNrFrom" ValueField="ID" TextField="Pers_Nr" TextFormatString="{0}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobPersNrFromIndexChanged(s,e);	
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr:" Name="Pers_Nr" FieldName="Pers_Nr" Width="15%" />
                                    <dx:ListBoxColumn Caption="Name:" Name="Name" FieldName="Name" Width="85%" />
                                </Columns>
                            </dx:ASPxComboBox>
                            <asp:Label ID="Label41" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                            <dx:ASPxComboBox ID="cobPersNrTo" SelectedIndex="0" ClientInstanceName="cobPersNrTo" ValueField="ID" TextField="Pers_Nr" TextFormatString="{0}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobPersNrToIndexChanged(s,e);	
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr:" Name="Pers_Nr" FieldName="Pers_Nr" Width="15%" />
                                    <dx:ListBoxColumn Caption="Name:" Name="Name" FieldName="Name" Width="85%" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>
                        <section class="topsec1left2">
                            <asp:Label ID="Label42" runat="server" Text="<%$ Resources:localizedText, cardNoFrom %>" CssClass="lbldatefrom"></asp:Label>
                            <dx:ASPxComboBox ID="cobCardNrFrom" ClientInstanceName="cobCardNrFrom" ValueField="ID" TextField="TransponderNr" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobCardNrFromIndexChanged(s,e);	
}"></ClientSideEvents>
                            </dx:ASPxComboBox>
                            <asp:Label ID="Label43" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                            <dx:ASPxComboBox ID="cobCardNrTo" ClientInstanceName="cobCardNrTo" ValueField="ID" TextField="TransponderNr" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobCardNrToIndexChanged(s,e);	
}"></ClientSideEvents>
                            </dx:ASPxComboBox>
                        </section>

                    </section>
                    <section class="top1right">
                        <section class="lblright">
                            <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText, SelectionType %>" CssClass="lbsel"></asp:Label>
                        </section>
                        <section class="topsec1right">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClass">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjectschks" CssClass="tblCell1">
                                        <asp:Label ID="lblObjects" runat="server" Text="1" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersonttalchecks" CssClass="tblCell2">
                                        <asp:Label ID="lblPersonal" runat="server" Text="<%$ Resources:localizedText, dateTitle %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkCardExpiryDate" runat="server" /><label for='chkCardExpiryDate'></label>

                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2"></section>
                        <section class="topsec1right2">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjecttschks" CssClass="tblCell1">
                                        <asp:Label ID="Label20" runat="server" Text="2" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPerstonalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label21" runat="server" Text="<%$ Resources:localizedText, company_Title %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lhbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkcompany" runat="server" /><label for='chkcompany'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" Style="height: 45.7px;" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjecltschks" CssClass="tblCell1">
                                        <asp:Label ID="Label23" runat="server" Text="3" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersionalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label24" runat="server" Text="<%$ Resources:localizedText, locationnew %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lbll" CssClass="tblCell3">
                                        <asp:CheckBox ID="chklocation" runat="server" /><label for='chklocation'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2new">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjecschks" CssClass="tblCell1">
                                        <asp:Label ID="Label26" runat="server" Text="4" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPeronalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label27" runat="server" Text="<%$ Resources:localizedText, departmentTitle %>" CssClass="lblobjectareatitle"></asp:Label>
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
                                        <asp:Label ID="Label30" runat="server" Text="Name:" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lsdbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkName" runat="server" /><label for='chkName'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObctsschks" CssClass="tblCell1">
                                        <asp:Label ID="Label44" runat="server" Text="6" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPerslcshecks" CssClass="tblCell2">
                                        <asp:Label ID="Label45" runat="server" Text="<%$ Resources:localizedText, IdNo_new %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldsbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkidnr" runat="server" /><label for='chkidnr'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObctfschks" CssClass="tblCell1">
                                        <asp:Label ID="Label46" runat="server" Text="7" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPerslffchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label47" runat="server" Text="<%$ Resources:localizedText, cardNo %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldbffl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkcard" runat="server" /><label for='chkcard'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>

                    </section>
                </section>
                <section class="belowsec">
                    <section class="lblleftnew">
                        <asp:Label ID="Label39" runat="server" Text="<%$ Resources:localizedText, otherSelections_New %>" CssClass="lbaus"></asp:Label>
                    </section>
                    <section class="belowsecholder">
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjecuttschks" CssClass="tblCell1">
                                        <asp:Label ID="Label11" runat="server" Text="8" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersjtonalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label22" runat="server" Text="<%$ Resources:localizedText, extension_new %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lhjbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkExtension" runat="server" /><label for='chkExtension'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjjecltschks" CssClass="tblCell1">
                                        <asp:Label ID="Label25" runat="server" Text="9" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersiodnalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label28" runat="server" Text="<%$ Resources:localizedText, actions %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldfbll" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkActions" runat="server" /><label for='chkActions'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblOrrbjecschks" CssClass="tblCell1">
                                        <asp:Label ID="Label31" runat="server" Text="10" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPerornalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label32" runat="server" Text="<%$ Resources:localizedText, active_new %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lbdrl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkActive" runat="server" /><label for='chkActive'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblrObctschks" CssClass="tblCell1">
                                        <asp:Label ID="Label33" runat="server" Text="11" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPrerrslchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label34" runat="server" Text="<%$ Resources:localizedText, inactive_new %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldrbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkInactive" runat="server" /><label for='chkInactive'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblrObctsschks" CssClass="tblCell1">
                                        <asp:Label ID="Label35" runat="server" Text="12" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPrerdrslchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label36" runat="server" Text="<%$ Resources:localizedText, expirydate %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldarbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkExpiryDate" runat="server" /><label for='chkExpiryDate'></label>
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
                        <asp:Label ID="Label37" runat="server" Text="<%$ Resources:localizedText ,companyFrom%>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label38" runat="server" Text="<%$ Resources:localizedText, locationFrom_new %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label48" runat="server" Text="<%$ Resources:localizedText, departmentFrom_new %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label51" runat="server" Text="<%$ Resources:localizedText, nameFrom_P %>" CssClass="lblreport"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="txtCompanyFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtLocationFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtDepartmentFrom" runat="server" CssClass="drpreport"></asp:TextBox>
                        <asp:TextBox ID="txtPersNameFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label49" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label65" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label66" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label52" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp4New">

                        <asp:TextBox ID="txtCompanyTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtLocationTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtDepartmentTo" runat="server" CssClass="drpreportnew"></asp:TextBox>
                        <asp:TextBox ID="txtPersNameTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left3">
                    <section class="selectionOne">
                        <section class="topRight1">
                            <asp:Label ID="Label67" runat="server" Text="<%$ Resources:localizedText, date2 %>" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label68" runat="server" Text="<%$ Resources:localizedText, fromnew %>" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="txtDateFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label69" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtDateTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight2" >
                            <asp:Label ID="Label70" runat="server" Text="<%$ Resources:localizedText, SelectionType %>" CssClass="lblPrintMode"></asp:Label>
                            <asp:Label ID="lblReportType" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>
                        </section>
                        <section class="topRight3">
                            <asp:Label ID="lblCardType" runat="server" Text="" CssClass="lblPrintModeobj"></asp:Label>
                        </section>
                    </section>
                    <section class="selectionTwo">
                        <section class="topRight1">
                            <asp:Label ID="Label74" runat="server" Text="<%$ Resources:localizedText, cardNr %>" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label76" runat="server" Text="<%$ Resources:localizedText, fromnew %>" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="txtCardNrFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label77" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtCardNrTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>
                        </section>
                        <section class="topRight2">
                            <%-- <asp:Label ID="Label50" runat="server" Text="Ausgwählter Zeitbereich:" CssClass="lblPrintMode" Style="width: 56%;"></asp:Label>
                             <asp:Label ID="lblTimePrintType" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>--%>
                            <section class="loggedInUser">
                                <asp:Label ID="Label75" runat="server" Text="<%$ Resources:localizedText, createdBy %>" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblPersName" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>
                        </section>
                        <section class="topRight3">
                        </section>
                    </section>
                    <section class="selectionThree">
                        <section class="topRight1">
                            <asp:Label ID="Label72" runat="server" Text="<%$ Resources:localizedText, printedOn %>" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtPrintDate" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label73" runat="server" Text="<%$ Resources:localizedText, timeTitle %>" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtPrintTime" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight2b">
                            <%--<section class="loggedInUser">
                                <asp:Label ID="Label75" runat="server" Text="Erstellt von:" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblPersName" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>--%>
                        </section>
                        <section class="topRight3perpekind">
                            <section class="secholdingarea1_new">
                                <asp:Label ID="Label99" runat="server" Text="<%$ Resources:localizedText, potrait %>" CssClass="txtportrait"></asp:Label>
                                <asp:ImageButton ID="imgPotrait" runat="server" CssClass="btnorientation1" Style="cursor:default;"/>
                                <asp:CheckBox ID="chkPortrait" runat="server" CssClass="chk1controllast" Style="cursor:default;"/>

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
            <dx:ASPxGridView ID="grdPersonnelCardInfo" ClientInstanceName="grdPersonnelCardInfo" KeyFieldName="ID" EnableCallBacks="true" OnCustomCallback="grdPersonnelCardInfo_CustomCallback" runat="server" AutoGenerateColumns="False" Width="100%" Theme="Office2003Blue">
                <ClientSideEvents EndCallback="function(s, e) {
	grdPersonnelCardInfoEndCallback(s,e);
}"></ClientSideEvents>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="false" VisibleIndex="0"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, client_new %>" VisibleIndex="1" Name="firma" FieldName="Company">
                        <%-- <HeaderStyle BackColor="#ffe7a2" />--%>
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, locationnew %>" VisibleIndex="2" Name="" FieldName="Location">
                        <%--<HeaderStyle BackColor="#ffe7a2" />--%>
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, departments %>" VisibleIndex="3" Name="" FieldName="Department">
                        <%-- <HeaderStyle BackColor="#ffe7a2" />--%>
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, costcenter %>" Visible="false" VisibleIndex="4" Name="" FieldName="CostCenter">
                        <%--<HeaderStyle BackColor="#ffe7a2" />--%>
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, name %>" VisibleIndex="5" Name="Nachname" FieldName="FullName">
                        <%-- <HeaderStyle BackColor="#ffe7a2" />--%>
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="ID Nr" VisibleIndex="6" Name="PersNr" FieldName="Pers_Nr">
                        <HeaderStyle HorizontalAlign="Left" />
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="Left">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, idCards %>" VisibleIndex="7" Name="Ausweise Nr" HeaderStyle-HorizontalAlign="left" FieldName="CardNumber">
                        <HeaderStyle HorizontalAlign="left" />
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="left">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, idCards %>" VisibleIndex="7" Visible="false" Name="Ausweise" HeaderStyle-HorizontalAlign="Center" FieldName="CardsAllocated">
                        <%-- <HeaderStyle BackColor="#ffe7a2" />--%>
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="Center">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, extension_new %>" VisibleIndex="8" Name="Verlängerung" HeaderStyle-HorizontalAlign="Center" FieldName="TotalExtensions">
                        <%-- <HeaderStyle BackColor="#ffe7a2" />--%>
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="Center">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, actions %>" VisibleIndex="9" Name="Aktionen" HeaderStyle-HorizontalAlign="Center" FieldName="Action">
                        <%--<HeaderStyle BackColor="#ffe7a2" />--%>
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="Center">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Aktiv:" VisibleIndex="10" HeaderStyle-HorizontalAlign="Center" FieldName="ActiveCard">
                        <%-- <HeaderStyle BackColor="#ffe7a2" />--%>
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="Center">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Inaktiv" VisibleIndex="11" HeaderStyle-HorizontalAlign="Center" FieldName="InActiveCard">
                        <%--<HeaderStyle BackColor="#ffe7a2" />--%>
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="Center">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn ShowInCustomizationForm="True" Name="bis" Caption="<%$ Resources:localizedText, expiryDate_new %>" VisibleIndex="12" FieldName="ActiveEndDate">
                        <PropertiesTextEdit DisplayFormatString="dd.MM.yyyy"></PropertiesTextEdit>

                        <HeaderStyle HorizontalAlign="Center" ForeColor="#128377"></HeaderStyle>
                        <%--BackColor="#FFE7A2"--%>

                        <CellStyle HorizontalAlign="Center">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>

                </Columns>
                <SettingsBehavior AllowSort="False" AllowDragDrop="false" AllowFocusedRow="true" AllowSelectByRowClick="true"></SettingsBehavior>
                <SettingsPager Mode="ShowAllRecords" ShowEmptyDataRows="True" Visible="False" PageSize="24">
                </SettingsPager>
            </dx:ASPxGridView>
        </section>
    </section>
    <div class="showReportsDocViewer" style="display: none;">
        <dx:ASPxCallbackPanel ID="PersonnelCardPanel" ClientInstanceName="PersonnelCardPanel" runat="server" OnCallback="PersonnelCardPanel_Callback">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <dx:ASPxWebDocumentViewer ID="PersonnelCardsDocumentViewer" Style="width: 100%; height: 1100px;" ClientIDMode="Static" ClientInstanceName="PersonnelCardsDocumentViewer" runat="server" Theme="Office2003Blue">
                    </dx:ASPxWebDocumentViewer>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnPrintReport" CssClass="btnPrintReport" runat="server" Text="<%$ Resources:localizedText, printCardInformation %>" Style="display: none" />
    <asp:Button ID="btnPrintSelection" CssClass="editbtnfooterorange" runat="server" Text="<%$ Resources:localizedText, printSelection_title %>" Style="width: 170px;" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" ClientIDMode="Static" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
