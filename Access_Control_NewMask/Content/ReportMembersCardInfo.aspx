<%@ Page Title="Ausweisinfo Mitglieder" Language="C#" MasterPageFile="~/MasterPages/Reports.Master" AutoEventWireup="true" CodeBehind="ReportMembersCardInfo.aspx.cs" Inherits="Access_Control_NewMask.Content.ReportMembersCardInfo" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.2.Web, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/ReportMembersCardInfo.js"></script>
    <link href="Styles/ReportMembersCardInfo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="ContentAreaDiv">
        <asp:HiddenField ID="HiddenField1BackValue" runat="server" />
        <div class="TopContentAreaDiv">
            <section class="sectop">

                <asp:Label ID="Label3" runat="server" Text="Aktive Ausweise:" CssClass="lblalleanswe"></asp:Label>
                <asp:CheckBox ID="chkActiveCards" runat="server" CssClass="chkanwse" />
                <asp:Label ID="Label4" runat="server" Text="Verlängerte Ausweise:" CssClass="lblalleabswe"></asp:Label>
                <asp:CheckBox ID="chkExtendedCards" runat="server" CssClass="chkabwse" />
                <asp:Label ID="Label5" runat="server" Text="Inaktive Ausweise:" CssClass="lblalleget"></asp:Label>
                <asp:CheckBox ID="chkInactiveCards" runat="server" CssClass="chkallget" />
                <asp:Label ID="Label6" runat="server" Text="Alle Ausweise:" CssClass="lbldatum"></asp:Label>
                <asp:CheckBox ID="chkAllCards" runat="server" CssClass="chkallget" />
            </section>

        </div>
        <div class="MidContentAreaDiv">
            <section class="toplabel">
                <asp:Label ID="Label1" runat="server" Text="Gefilterter Druck" CssClass="labeltop"></asp:Label>
            </section>
            <section class="contentarea">
                <section class="top1">
                    <section class="top1left">
                        <section class="lblleft">
                            <asp:Label ID="Label8" runat="server" Text="Druck Auswahl" CssClass="lbaus"></asp:Label>
                        </section>
                        <section class="topsec1left">
                            <asp:Label ID="Label9" runat="server" Text="Datum von:" CssClass="lbldatefrom"></asp:Label>
                            <dx:ASPxDateEdit ID="datePickerFrom" ClientInstanceName="datePickerFrom" runat="server" HorizontalAlign="Center" Theme="Office2003Blue" CssClass="datedis"></dx:ASPxDateEdit>
                            <asp:Label ID="Label10" runat="server" Text="bis:" CssClass="lbldateto"></asp:Label>
                            <dx:ASPxDateEdit ID="datePickerTo" ClientInstanceName="datePickerTo" runat="server" HorizontalAlign="Center" Theme="Office2003Blue" CssClass="datedis"></dx:ASPxDateEdit>
                        </section>
                        <section class="topsec1left2">
                            <asp:Label ID="Label40" runat="server" Text="Alle in diesem ausgewählten Datumsbereich relevanten Daten anzeigen" CssClass="lblqckdruk"></asp:Label>
                            <asp:CheckBox ID="chkShowAllData" runat="server" CssClass="chknew" />
                        </section>
                        <section class="topsec1left2new">
                            <asp:Label ID="Label12" runat="server" Text="Studio Gruppe von:" CssClass="lbldatefrom"></asp:Label>
                            <dx:ASPxComboBox ID="cobStudioGroupFrom" ClientInstanceName="cobStudioGroupFrom" ValueField="Id" TextField="GroupNr" TextFormatString="{1}" CallbackPageSize="100000" runat="server" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobStudioGroupFromIndexChanged(s,e);	
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr" Name="GroupNr" FieldName="GroupNr" Width="15%" />
                                    <dx:ListBoxColumn Caption="Studio Gruppe" Name="GroupName" FieldName="GroupName" Width="85%" />
                                </Columns>
                            </dx:ASPxComboBox>
                            <asp:Label ID="Label19" runat="server" Text="bis" CssClass="lbldateto"></asp:Label>
                            <dx:ASPxComboBox ID="cobStudioGroupTo" ClientInstanceName="cobStudioGroupTo" ValueField="Id" TextField="GroupNr" TextFormatString="{1}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobStudioGroupToIndexChanged(s,e);	
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr" Name="GroupNr" FieldName="GroupNr" Width="15%" />
                                    <dx:ListBoxColumn Caption="Studio Gruppe" Name="GroupName" FieldName="GroupName" Width="85%" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>


                        <section class="topsec1left2">
                            <asp:Label ID="Label17" runat="server" Text="Mitgliedername von:" CssClass="lbldatefrom"></asp:Label>
                            <dx:ASPxComboBox ID="cobMemberNameFrom" ClientInstanceName="cobMemberNameFrom" ValueField="ID" TextField="FullName" TextFormatString="{1}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobMemberNameFromIndexChanged(s,e);	
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr" Name="MemberNumber" FieldName="MemberNumber" Width="15%" />
                                    <dx:ListBoxColumn Caption="Mitgliedername" Name="FullName" FieldName="FullName" Width="85%" />
                                </Columns>
                            </dx:ASPxComboBox>
                            <asp:Label ID="Label18" runat="server" Text="bis:" CssClass="lbldateto"></asp:Label>
                            <dx:ASPxComboBox ID="cobMemberNameTo" ClientInstanceName="cobMemberNameTo" ValueField="ID" TextField="FullName" TextFormatString="{1}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobMemberNameToIndexChanged(s,e);	
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr" Name="MemberNumber" FieldName="MemberNumber" Width="15%" />
                                    <dx:ListBoxColumn Caption="Mitgliedername" Name="FullName" FieldName="FullName" Width="85%" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>
                        <section class="topsec1left2">
                            <asp:Label ID="Label2" runat="server" Text="ID Nr. von:" CssClass="lbldatefrom"></asp:Label>
                            <dx:ASPxComboBox ID="cobMemberNrFrom" ClientInstanceName="cobMemberNrFrom" ValueField="ID" TextField="MemberNumber" TextFormatString="{0}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobMemberNrFromIndexChanged(s,e);	
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr" Name="MemberNumber" FieldName="MemberNumber" Width="15%" />
                                    <dx:ListBoxColumn Caption="Mitgliedername" Name="FullName" FieldName="FullName" Width="85%" />
                                </Columns>
                            </dx:ASPxComboBox>
                            <asp:Label ID="Label41" runat="server" Text="bis:" CssClass="lbldateto"></asp:Label>
                            <dx:ASPxComboBox ID="cobMemberNrTo" ClientInstanceName="cobMemberNrTo" ValueField="ID" TextField="MemberNumber" TextFormatString="{0}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobMemberNrToIndexChanged(s,e);	
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr" Name="MemberNumber" FieldName="MemberNumber" Width="15%" />
                                    <dx:ListBoxColumn Caption="Mitgliedername" Name="FullName" FieldName="FullName" Width="85%" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>
                        <section class="topsec1left2">
                            <asp:Label ID="Label42" runat="server" Text="Ausweis Nr. von:" CssClass="lbldatefrom"></asp:Label>

                            <dx:ASPxComboBox ID="cobCardNrFrom" ClientInstanceName="cobCardNrFrom" ValueField="ID" TextField="TransponderNr" runat="server" ValueType="System.String" CallbackPageSize="100000" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobCardNrFromIndexChanged(s,e);	
}"></ClientSideEvents>
                            </dx:ASPxComboBox>
                            <asp:Label ID="Label43" runat="server" Text="bis:" CssClass="lbldateto"></asp:Label>
                            <dx:ASPxComboBox ID="cobCardNrTo" ClientInstanceName="cobCardNrTo" ValueField="ID" TextField="TransponderNr" runat="server" ValueType="System.String" CallbackPageSize="100000" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobCardNrToIndexChanged(s,e);	
}"></ClientSideEvents>
                            </dx:ASPxComboBox>
                        </section>

                    </section>
                    <section class="top1right">
                        <section class="lblright">
                            <asp:Label ID="Label7" runat="server" Text="Selektion der Auswertungen" CssClass="lbsel"></asp:Label>
                        </section>
                        <section class="topsec1right">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClass">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjectschks" CssClass="tblCell1">
                                        <asp:Label ID="lblObjects" runat="server" Text="1" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersonttalchecks" CssClass="tblCell2">
                                        <asp:Label ID="lblPersonal" runat="server" Text="Datum:" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkMemberDate" runat="server" /><label for='chkMemberDate'></label>

                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2"></section>
                        <section class="topsec1right2new">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjecttschks" CssClass="tblCell1">
                                        <asp:Label ID="Label20" runat="server" Text="2" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPerstonalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label21" runat="server" Text="Studio Gruppe:" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lhbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkMemberGroup" runat="server" /><label for='chkMemberGroup'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow" Style="height: 43px;">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjecltschks" CssClass="tblCell1">
                                        <asp:Label ID="Label23" runat="server" Text="3" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersionalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label24" runat="server" Text="Mitgliedername" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lbll" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkMemberName" runat="server" /><label for='chkMemberName'></label>
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
                                        <asp:Label ID="Label27" runat="server" Text="ID Nr.:" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lbdl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkMemberNr" runat="server" /><label for='chkMemberNr'></label>
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
                                        <asp:Label ID="Label30" runat="server" Text="Ausweis Nr.:" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lsdbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkCardNr" runat="server" /><label for='chkCardNr'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>



                    </section>
                </section>
                <section class="belowsec">
                    <section class="lblleftnew">
                        <asp:Label ID="Label39" runat="server" Text="Weitere Selektionen" CssClass="lbaus"></asp:Label>
                    </section>
                    <section class="belowsecholder">
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjecuttschks" CssClass="tblCell1">
                                        <asp:Label ID="Label11" runat="server" Text="6" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersjtonalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label22" runat="server" Text="Verlängerung:" CssClass="lblobjectareatitle"></asp:Label>
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
                                        <asp:Label ID="Label25" runat="server" Text="7" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersiodnalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label28" runat="server" Text="Aktionen:" CssClass="lblobjectareatitle"></asp:Label>
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
                                        <asp:Label ID="Label31" runat="server" Text="8" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPerornalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label32" runat="server" Text="Aktiv:" CssClass="lblobjectareatitle"></asp:Label>
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
                                        <asp:Label ID="Label33" runat="server" Text="9" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPrerrslchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label34" runat="server" Text="Inaktiv:" CssClass="lblobjectareatitle"></asp:Label>
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
                                        <asp:Label ID="Label35" runat="server" Text="10" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPrerdrslchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label36" runat="server" Text="Gültig bis:" CssClass="lblobjectareatitle"></asp:Label>
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
                        <asp:Label ID="Label13" runat="server" Text="Studio Gruppe von:" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label14" runat="server" Text="Mitgliedername von:" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label15" runat="server" Text="ID Nr. von:" CssClass="lblreport"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="txtGroupFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtMemberNameFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtMemberNrFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label16" runat="server" Text="bis:" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label65" runat="server" Text="bis:" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label66" runat="server" Text="bis:" CssClass="lblBis"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp4New">

                        <asp:TextBox ID="txtGroupTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtMemberNameTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtMemberNrTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left3">
                    <section class="selectionOne">
                        <section class="topRight1">
                            <asp:Label ID="Label67" runat="server" Text="Datum" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label68" runat="server" Text="von:" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="txtDateFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label69" runat="server" Text="bis:" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtDateTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight2">
                            <asp:Label ID="Label70" runat="server" Text="Selektion der Auswertungen:" CssClass="lblPrintMode"></asp:Label>
                            <asp:Label ID="lblReportType" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>
                        </section>
                        <section class="topRight3">
                            <asp:Label ID="lblCardType" runat="server" Text="" CssClass="lblPrintModeobj"></asp:Label>
                        </section>
                    </section>
                    <section class="selectionTwo">
                        <section class="topRight1">
                            <asp:Label ID="Label74" runat="server" Text="Ausweis Nr" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label76" runat="server" Text="von:" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="txtCardNrFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label77" runat="server" Text="bis:" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtCardNrTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>
                        </section>
                        <section class="topRight2">
                            <%-- <asp:Label ID="Label37" runat="server" Text="Ausgwählter Zeitbereich:" CssClass="lblPrintMode" Style="width: 56%;"></asp:Label>
                            <asp:Label ID="lblTimePrintType" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>--%>

                            <section class="loggedInUser">
                                <asp:Label ID="Label75" runat="server" Text="Erstellt von:" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblPersName" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>

                        </section>
                        <section class="topRight3">
                        </section>
                    </section>
                    <section class="selectionThree">
                        <section class="topRight1">
                            <asp:Label ID="Label72" runat="server" Text="Gedruckt am:" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtPrintDate" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label73" runat="server" Text="Uhrzeit:" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtPrintTime" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight2" style="display:none">
                            <%-- <section class="loggedInUser">
                                <asp:Label ID="Label75" runat="server" Text="Erstellt von:" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblPersName" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>--%>
                        </section>
                        <section class="topRight3perpekind">
                            <section class="secholdingarea1_new">
                                <asp:Label ID="Label99" runat="server" Text="Hoch:" CssClass="txtportrait"></asp:Label>
                                <asp:ImageButton ID="imgPotrait" runat="server" CssClass="btnorientation1" Style="cursor:default;"/>
                                <asp:CheckBox ID="chkPortrait" runat="server" CssClass="chk1controllast" />

                            </section>
                            <section class="secholdingarea1b_new">
                                <asp:Label ID="Label100" runat="server" Text="Quer:" CssClass="txtlandscape_new"></asp:Label>
                                <asp:ImageButton ID="imgLand" runat="server" CssClass="btnorientation2" Style="cursor:default;"/>
                                <asp:CheckBox ID="chkLandScape" runat="server" CssClass="chk1controllast" />

                            </section>
                        </section>

                    </section>
                </section>
            </section>
        </section>
        <section class="mainBodybtm">
            <dx:ASPxGridView ID="grdMembersCardInfo" ClientInstanceName="grdMembersCardInfo" KeyFieldName="ID" EnableCallBacks="true" OnCustomCallback="grdMembersCardInfo_CustomCallback" runat="server" AutoGenerateColumns="False" Width="100%" Theme="Office2003Blue">
                <ClientSideEvents EndCallback="function(s, e) {
	grdMembersCardInfoEndCallback(s,e);
}"></ClientSideEvents>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" FieldName="ID" Visible="false"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Studio Gruppe:" VisibleIndex="1" Name="firma" FieldName="GroupName">
                        <%--  <HeaderStyle BackColor="#ffe7a2" />--%>
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, name %>" VisibleIndex="2" Name="Nachname" FieldName="MemberName">
                        <%--    <HeaderStyle BackColor="#ffe7a2" />--%>
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="ID Nr:" VisibleIndex="3" Name="MemberNr" FieldName="MemberNumber">
                        <HeaderStyle HorizontalAlign="Left" />
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="Left">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Ausweis Nr:" VisibleIndex="4" Name="AuwesisNr" FieldName="CardNumber">
                        <HeaderStyle HorizontalAlign="Left" />
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="Left">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, idCards %>" VisibleIndex="5" Name="Ausweise" HeaderStyle-HorizontalAlign="Center" FieldName="CardsAllocated" Visible="false">
                        <HeaderStyle HorizontalAlign="Left" />
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="Left">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, extension_new %>" VisibleIndex="6" Name="Verlängerung" HeaderStyle-HorizontalAlign="Center" FieldName="TotalExtensions" Visible="false">
                        <%-- <HeaderStyle BackColor="#ffe7a2" />--%>
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="Center">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, actions %>" VisibleIndex="7" Name="Aktionen" HeaderStyle-HorizontalAlign="Center" FieldName="Action" Visible="false">
                        <%--<HeaderStyle BackColor="#ffe7a2" />--%>
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="Center">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Aktiv:" VisibleIndex="8" HeaderStyle-HorizontalAlign="Center" FieldName="ActiveCard" Visible="false">
                        <%-- <HeaderStyle BackColor="#ffe7a2" />--%>
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="Center">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Inaktiv" VisibleIndex="9" HeaderStyle-HorizontalAlign="Center" FieldName="InActiveCard" Visible="false">
                        <%--  <HeaderStyle BackColor="#ffe7a2" />--%>
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="Center">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn ShowInCustomizationForm="True" Name="bis" Caption="<%$ Resources:localizedText, expiryDate_new %>" VisibleIndex="10" Visible="false" FieldName="ActiveEndDate">
                        <PropertiesTextEdit DisplayFormatString="dd.MM.yyyy"></PropertiesTextEdit>

                        <HeaderStyle HorizontalAlign="Center" ForeColor="#128377"></HeaderStyle>
                        <%--BackColor="#FFE7A2"--%>

                        <CellStyle HorizontalAlign="Center">
                            <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn Caption="Inaktiv" VisibleIndex="11" HeaderStyle-HorizontalAlign="Center" FieldName="ID" Visible="false">
                        <%--<HeaderStyle BackColor="#ffe7a2" />--%>
                        <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="Center">
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
        <dx:ASPxCallbackPanel ID="MembersCardPanel" ClientInstanceName="MembersCardPanel" runat="server" OnCallback="MembersCardPanel_Callback">
            <PanelCollection>
                <dx:PanelContent runat="server">

                    <dx:ASPxWebDocumentViewer ID="MemberCardsDocumentViewer" Style="width: 100%; height: 1100px;" ClientIDMode="Static" ClientInstanceName="MemberCardsDocumentViewer" runat="server" Theme="Office2003Blue">
                    </dx:ASPxWebDocumentViewer>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnPrintReport" CssClass="btnPrintReport" runat="server" Text="Zutrittsprotokoll drucken" Style="display: none" />
    <asp:Button ID="btnPrintSelection" CssClass="editbtnfooterorange" runat="server" Text="Ausweisinfo drucken" Style="width: 170px;" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" ClientIDMode="Static" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
