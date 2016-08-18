<%@ Page Title=" Mitgliederlisten" Language="C#" MasterPageFile="~/MasterPages/Reports.Master" AutoEventWireup="true" CodeBehind="ReportsMembersList.aspx.cs" Inherits="Access_Control_NewMask.Content.ReportsMembersList" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.2.Web, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/ReportsMembersList.js"></script>
    <link href="Styles/ReportsMembersList.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">

    <div id="importantDialog"></div>

    <asp:HiddenField ID="HiddenField1BackValue" runat="server" />
    <asp:HiddenField ID="hiddenFieldSaveChanges" runat="server" />

    <div class="ContentAreaDiv">
        <div class="TopContentAreaDiv">
            <section class="sectop">
                <section class="upperpart">
                    <asp:Label ID="Label3" runat="server" Text="Mitgliederlisten Nr.:" CssClass="lblpersonlist"></asp:Label>
                    <dx:ASPxComboBox ID="cobMemberNumber" ClientInstanceName="cobMemberNumber" ValueField="ID" TextField="ListNr" runat="server" OnCallback="cobMemberNumber_Callback"
                        TextFormatString="{0}" CallbackPageSize="100000" Theme="Office2003Blue" CssClass="combopersonno" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cobMemberNumberSelectedIndexChanged(s.GetValue());
}"
                            DropDown="function(s, e) {
dplClicked(s, e);	
}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn Caption="Nr:" Name="ListNr" FieldName="ListNr" Width="15%" />
                            <dx:ListBoxColumn Caption="Bezeichnung::" Name="ListDescription" FieldName="ListDescription" Width="85%" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <asp:Label ID="Label4" runat="server" Text="Bezeichnung:" CssClass="lblalleabswe"></asp:Label>
                    <dx:ASPxComboBox ID="cobMemberName" ValueField="ID" TextField="ListDescription" ClientInstanceName="cobMemberName" runat="server" OnCallback="cobMemberName_Callback"
                        TextFormatString="{1}" CallbackPageSize="100000" Theme="Office2003Blue" CssClass="combopersondes" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cboMemberListDescSelectedIndexChanged(s.GetValue());
}"
                            DropDown="function(s, e) {
	dplClicked(s, e);
}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn Caption="Nr:" Name="ListNr" FieldName="ListNr" Width="15%" />
                            <dx:ListBoxColumn Caption="Bezeichnung::" Name="ListDescription" FieldName="ListDescription" Width="85%" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <asp:Label ID="Label6" runat="server" Text="Datum:" CssClass="lbldatum"></asp:Label>
                    <asp:Label ID="lblDate" runat="server" Text="" CssClass="lblDtDisp"></asp:Label>
                    <asp:Label ID="Label42" runat="server" Text="Aktive Mitglieder:" CssClass="lblaktivep"></asp:Label>
                    <asp:CheckBox ID="chkActiveMember" runat="server" CssClass="chkabwse chkPersTyp" />
                    <asp:Label ID="Label5" runat="server" Text="Inaktive Mitglieder:" CssClass="lblalleget"></asp:Label>
                    <asp:CheckBox ID="chkInactiveMember" runat="server" CssClass="chkallget chkPersTyp" />
                </section>
                <section class="lowerpart">
                    <asp:Label ID="Label2" runat="server" Text="Mitgliederlisten Nr.:" CssClass="lblpersonlist"></asp:Label>
                    <asp:TextBox ID="txtMemberNumber" runat="server" CssClass="txtperli"></asp:TextBox>
                    <asp:Label ID="Label40" runat="server" Text="Bezeichnung:" CssClass="lblalleabswe"></asp:Label>
                    <asp:TextBox ID="txtMemberName" runat="server" CssClass="txtdes"></asp:TextBox>
                </section>
            </section>
        </div>
        <div class="MidContentAreaDiv">
            <section class="contentarea">
                <section class="leftside">
                    <section class="top1">
                        <section class="top1left">

                            <section class="lblleft">
                                <asp:Label ID="Label8" runat="server" Text="Druck Auswahl" CssClass="lbaus"></asp:Label>
                            </section>
                            <section class="topsec1left">
                                <asp:Label ID="Label9" runat="server" Text="Studio Gruppe von:" CssClass="lbldatefrom"></asp:Label>
                                <dx:ASPxComboBox ID="cobStudioGroupFrom" ClientInstanceName="cobStudioGroupFrom" ValueField="Id" TextField="GroupName" TextFormatString="{1}" runat="server" Theme="Office2003Blue" CssClass="datedis"
                                    DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e ){cobStudioGroupFromIndexChanged(s, e);}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Nr:" Name="GroupNr" FieldName="GroupNr" Width="15%" />
                                        <dx:ListBoxColumn Caption="Studio Gruppe:" Name="GroupName" FieldName="GroupName" Width="85%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                                <asp:Label ID="Label10" runat="server" Text="bis:" CssClass="lbldateto"></asp:Label>
                                <dx:ASPxComboBox ID="cobStudioGroupTo" ClientInstanceName="cobStudioGroupTo" ValueField="Id" TextField="GroupName" TextFormatString="{1}" runat="server" Theme="Office2003Blue" CssClass="datedis"
                                    DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Nr:" Name="GroupNr" FieldName="GroupNr" Width="15%" />
                                        <dx:ListBoxColumn Caption="Studio Gruppe:" Name="GroupName" FieldName="GroupName" Width="85%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                            </section>

                            <section class="topsec1left2">
                                <asp:Label ID="Label13" runat="server" Text="Mitgliedsname von:" CssClass="lbldatefrom"></asp:Label>
                                <dx:ASPxComboBox ID="cobMemberNameFrom" ClientInstanceName="cobMemberNameFrom" ValueField="ID" TextField="FullName" TextFormatString="{1}" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"
                                    DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e ){cobMemberNameFromIndexChanged(s, e);}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Nr:" Name="MemberNumber" FieldName="MemberNumber" Width="15%" />
                                        <dx:ListBoxColumn Caption="Mitgliedsname:" Name="FullName" FieldName="FullName" Width="85%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                                <asp:Label ID="Label14" runat="server" Text="bis:" CssClass="lbldateto"></asp:Label>
                                <dx:ASPxComboBox ID="cobMemberNameTo" ClientInstanceName="cobMemberNameTo" ValueField="ID" TextField="FullName" TextFormatString="{1}" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"
                                    DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Nr:" Name="MemberNumber" FieldName="MemberNumber" Width="15%" />
                                        <dx:ListBoxColumn Caption="Mitgliedsname:" Name="FullName" FieldName="FullName" Width="85%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                            </section>
                            <section class="topsec1left2">
                                <asp:Label ID="Label15" runat="server" Text="ID Nr. von:" CssClass="lbldatefrom"></asp:Label>
                                <dx:ASPxComboBox ID="cobMemberNumberFrom" ClientInstanceName="cobMemberNumberFrom" ValueField="ID" TextField="FullName" TextFormatString="{0}" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"
                                    DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e ){cobMemberNumberFromIndexChanged(s, e);}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Nr:" Name="MemberNumber" FieldName="MemberNumber" Width="15%" />
                                        <dx:ListBoxColumn Caption="Mitgliedsname:" Name="FullName" FieldName="FullName" Width="85%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                                <asp:Label ID="Label16" runat="server" Text="bis:" CssClass="lbldateto"></asp:Label>
                                <dx:ASPxComboBox ID="cobMemberNumberTo" ClientInstanceName="cobMemberNumberTo" ValueField="ID" TextField="FullName" TextFormatString="{0}" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"
                                    DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Nr:" Name="MemberNumber" FieldName="MemberNumber" Width="15%" />
                                        <dx:ListBoxColumn Caption="Mitgliedsname:" Name="FullName" FieldName="FullName" Width="85%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                            </section>
                            <section class="topsec1left2">
                                <asp:Label ID="Label17" runat="server" Text="Ort:" CssClass="lbldatefrom"></asp:Label>
                                <dx:ASPxComboBox ID="cobMemberPlaceFrom" EnableTheming="true" ClientInstanceName="cobMemberPlaceFrom" ValueField="ID" TextField="Place" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"
                                    DropDownRows="20" DropDownWidth="200px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e ){cobMemberPlaceFromIndexChanged(s, e);}"></ClientSideEvents>
                                </dx:ASPxComboBox>
                                <asp:Label ID="Label18" runat="server" Text="bis:" CssClass="lbldateto"></asp:Label>
                                <dx:ASPxComboBox ID="cobMemberPlaceTo" EnableTheming="true" ClientInstanceName="cobMemberPlaceTo" ValueField="ID" TextField="Place" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"
                                    DropDownRows="20" DropDownWidth="200px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                </dx:ASPxComboBox>
                            </section>
                            <section class="topsec1left2">
                                <asp:Label ID="Label12" runat="server" Text="PLZ:" CssClass="lbldatefrom"></asp:Label>
                                <dx:ASPxComboBox ID="cobMemberPostalCodeFrom" EnableTheming="true" ClientInstanceName="cobMemberPostalCodeFrom" ValueField="ID" TextField="PostalCode" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"
                                    DropDownRows="20" DropDownWidth="200px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e ){cobMemberPostalCodeFromIndexChanged(s, e);}"></ClientSideEvents>
                                </dx:ASPxComboBox>
                                <asp:Label ID="Label19" runat="server" Text="bis" CssClass="lbldateto"></asp:Label>
                                <dx:ASPxComboBox ID="cobMemberPostalCodeTo" ClientInstanceName="cobMemberPostalCodeTo" ValueField="ID" TextField="PostalCode" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"
                                    DropDownRows="20" DropDownWidth="200px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
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
                                        <asp:TableCell ID="lblObjectschks" CssClass="tblCell12">
                                            <asp:Label ID="lblObjects" runat="server" Text="1" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPersonttalchecks" CssClass="tblCell2">
                                            <asp:Label ID="lblPersonal" runat="server" Text="Studio Gruppe:" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lbl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkStudioGroup" runat="server" /><label for='chkStudioGroup'></label>

                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblObjecttschks" CssClass="tblCell12">
                                            <asp:Label ID="Label20" runat="server" Text="2" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPerstonalchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label21" runat="server" Text="Mitgliedsname:" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lhbl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkMemberName" runat="server" /><label for='chkMemberName'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblObjecltschks" CssClass="tblCell12">
                                            <asp:Label ID="Label23" runat="server" Text="3" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPersionalchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label24" runat="server" Text="ID Nr.:" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lbll" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkMemberNumber" runat="server" /><label for='chkMemberNumber'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblObjecschks" CssClass="tblCell12">
                                            <asp:Label ID="Label26" runat="server" Text="4" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPeronalchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label27" runat="server" Text="Ort:" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lbdl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkPlace" runat="server" /><label for='chkPlace'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblObctschks" CssClass="tblCell12">
                                            <asp:Label ID="Label29" runat="server" Text="5" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPerslchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label30" runat="server" Text="PLZ:" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldbl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkPostalCode" runat="server" /><label for='chkPostalCode'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>

                        </section>
                        <section class="top1farright">
                            <section class="lblleft">
                                <asp:Label ID="Label1" runat="server" Text="Druckbeginn nach" CssClass="lbdrun"></asp:Label>
                            </section>
                            <section class="topsec1leftright">
                                <asp:CheckBox ID="chkVariableA" runat="server" CssClass="chkvar chkAllvar" />
                                <asp:Label ID="Label41" runat="server" Text="Variante A" CssClass="lblvariantlast"></asp:Label>
                            </section>
                            <section class="topsec1leftright">
                                <asp:CheckBox ID="chkVariableB" runat="server" CssClass="chkvar chkAllvar" />
                                <asp:Label ID="Label43" runat="server" Text="Variante B" CssClass="lblvariantlast"></asp:Label>
                            </section>
                            <section class="topsec1leftright">
                                <asp:CheckBox ID="CheckBox5" runat="server" CssClass="chkvar" Style="display: none;" />
                                <asp:Label ID="Label44" runat="server" Text="Variante C" CssClass="lblvariantlast" Style="display: none;"></asp:Label>
                            </section>
                            <section class="topsec1leftright">
                                <asp:CheckBox ID="chkVariableC" runat="server" CssClass="chkvar chkAllvar" />
                                <asp:Label ID="Label57" runat="server" Text="Variante C" CssClass="lblvariantlast"></asp:Label>
                            </section>
                            <section class="topsec1leftright">
                                <asp:CheckBox ID="chkVariableD" runat="server" CssClass="chkvar chkAllvar" />
                                <asp:Label ID="Label45" runat="server" Text="Variante D" CssClass="lblvariantlast"></asp:Label>
                            </section>
                        </section>
                    </section>
                    <section class="belowsec">
                        <section class="lblcenter">
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
                                            <asp:Label ID="Label22" runat="server" Text="Anrede:" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lhjbl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkSalutation" runat="server" /><label for='chkSalutation'></label>
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
                                            <asp:Label ID="Label28" runat="server" Text="Straße und Nr.:" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldfbll" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkStreetNumber" runat="server" /><label for='chkStreetNumber'></label>
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
                                            <asp:Label ID="Label32" runat="server" Text="Vertrags Nr.:" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lbdrl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkContractNumber" runat="server" /><label for='chkContractNumber'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b" style="display:none;">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblrObctschks" CssClass="tblCell1">
                                            <asp:Label ID="Label33" runat="server" Text="9" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPrerrslchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label34" runat="server" Text="Vertrags Nr.:" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldrbl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkgul" runat="server" /><label for='chkgul'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblrObctsschks" CssClass="tblCell1">
                                            <asp:Label ID="Label35" runat="server" Text="9" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPrerdrslchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label36" runat="server" Text="Geburtsdatum:" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldarbl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkDateOfBirth" runat="server" /><label for='chkDateOfBirth'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblrObctscehks" CssClass="tblCell1">
                                            <asp:Label ID="Label37" runat="server" Text="10" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPrerrsflchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label38" runat="server" Text=" Nationalität: " CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldrbdl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkNationality" runat="server" /><label for='chkNationality'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblObjqecuttschks" CssClass="tblCell1">
                                            <asp:Label ID="Label73" runat="server" Text="11" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPewrsjtonalchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label74" runat="server" Text="Beruf:" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lhjqbl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkProfession" runat="server" /><label for='chkProfession'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblObwjjecltschks" CssClass="tblCell1">
                                            <asp:Label ID="Label75" runat="server" Text="12" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPerqsiodnalchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label76" runat="server" Text="Telefon" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldfbqll" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkTelephone" runat="server" /><label for='chkTelephone'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblOrrqbjecschks" CssClass="tblCell1">
                                            <asp:Label ID="Label77" runat="server" Text="13" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPerornawlchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label78" runat="server" Text="Handy" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lbdwrl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkMobile" runat="server" /><label for='chkMobile'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblrOwbctschks" CssClass="tblCell1">
                                            <asp:Label ID="Label79" runat="server" Text="14" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPrerrswlchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label80" runat="server" Text="E-mail" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldrbwl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkEmail" runat="server" /><label for='chkEmail'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblrObcwtsschks" CssClass="tblCell1">
                                            <asp:Label ID="Label81" runat="server" Text="15" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPrerdwrslchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label82" runat="server" Text="Eintrittsdatum:" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldawrbwl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkStartDate" runat="server" /><label for='chkStartDate'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblrObcwwtscehks" CssClass="tblCell1">
                                            <asp:Label ID="Label83" runat="server" Text="16" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPrerrswwflchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label84" runat="server" Text=" Austrittsdatum:" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldrqabdl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkEndDate" runat="server" /><label for='chkEndDate'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                        </section>
                        <section class="belowsecholderlast">
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblObjgecuttschks" CssClass="tblCell1">
                                            <asp:Label ID="Label46" runat="server" Text="17" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPersjstonalchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label47" runat="server" Text="Langzeit Ausweis" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lhsjbl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkLongtermCard" runat="server" /><label for='chkLongtermCard'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblObjsjecltschks" CssClass="tblCell1">
                                            <asp:Label ID="Label48" runat="server" Text="18" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPersiodsnalchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label49" runat="server" Text="Kurzzeit Ausweis" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldfbsll" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkShortTermCard" runat="server" /><label for='chkShortTermCard'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblOrrbsjecschks" CssClass="tblCell1">
                                            <asp:Label ID="Label50" runat="server" Text="19" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPerornalcshecks" CssClass="tblCell2">
                                            <asp:Label ID="Label51" runat="server" Text="Zutrittsberechtigung von-bis:" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lbsdrl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkAccessFromTo" runat="server" /><label for='chkAccessFromTo'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblrOabctschks" CssClass="tblCell1">
                                            <asp:Label ID="Label52" runat="server" Text="20" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblParerrslchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label53" runat="server" Text="Zutrittsplan Nr." CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldrabl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkAccessPlanNr" runat="server" /><label for='chkAccessPlanNr'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblrObcdtdsschks" CssClass="tblCell1">
                                            <asp:Label ID="Label54" runat="server" Text="21" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblsPrerdrslchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label55" runat="server" Text="Zutrittsplan Bezeichnung" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldacrbl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkAccessPlanName" runat="server" /><label for='chkAccessPlanName'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>

                            <section class="lblcen">
                                <asp:Label ID="Label58" runat="server" Text="Zutrittsgruppen" CssClass="lbcen"></asp:Label>
                            </section>
                            <section class="belowgrid">
                                <dx:ASPxGridView ID="grdAccessGroups" ClientIDMode="Static" ClientInstanceName="grdAccessGroups" runat="server" KeyFieldName="ID" Theme="Office2003Blue" AutoGenerateColumns="False" Width="100%">
                                    <SettingsPager PageSize="7" ShowEmptyDataRows="true" Visible="False"></SettingsPager>
                                    <SettingsBehavior AllowSort="false" AllowFocusedRow="True" />
                                    <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>


                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn VisibleIndex="1" Caption="" Width="14%"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Nr.:"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn VisibleIndex="3" Caption="Bezeichnung:"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn VisibleIndex="4" Caption="Aktiv:"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn VisibleIndex="5" Caption="Von - bis:"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn VisibleIndex="6" Caption=""></dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                            </section>
                        </section>
                    </section>
                </section>
                <section class="gridarea">
                    <section class="lblfarright">
                        <asp:Label ID="Label56" runat="server" Text="Gespeicherte Personallisten" CssClass="lbdrun"></asp:Label>
                    </section>
                    <section class="grid">

                        <dx:ASPxGridView ID="grdSavedMemberList" ClientIDMode="Static" ClientInstanceName="grdSavedMemberList" runat="server" KeyFieldName="ID" Theme="Office2003Blue" AutoGenerateColumns="False" Width="100%" OnCustomCallback="grdSavedMemberList_CustomCallback">
                            <ClientSideEvents RowDblClick="function(s, e) {
grdSavedMemberListDblClick(s, e);	
}"></ClientSideEvents>

                            <SettingsPager PageSize="27" ShowEmptyDataRows="true" Visible="False"></SettingsPager>
                            <SettingsBehavior AllowSort="false" AllowFocusedRow="True" />
                            <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Nr.:" Width="12%" FieldName="ListNr"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Bezeichnung:" Width="88%" FieldName="ListDescription"></dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
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
                        <asp:Label ID="Label59" runat="server" Text="Studio Gruppe:" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label60" runat="server" Text="Mitgliedsname:" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label63" runat="server" Text="Ort:" CssClass="lblreport"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="txtClientFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtLocFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtDept" runat="server" CssClass="drpreport"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label64" runat="server" Text="bis:" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label65" runat="server" Text="bis:" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label66" runat="server" Text="bis:" CssClass="lblBis"></asp:Label>
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

                            <asp:Label ID="Label85" runat="server" Text="Gedruckt am:" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtPrintDate" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label86" runat="server" Text="Uhrzeit:" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtPrintTime" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>


                            <%-- <asp:Label ID="Label67" runat="server" Text="Kostenstelle" CssClass="lblDateTitle" Style="width: 16%"></asp:Label>
                            <asp:Label ID="Label68" runat="server" Text="von:" CssClass="lblDtFromTitle"></asp:Label> 
                            <asp:TextBox ID="txtCostCenterFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>
                            <asp:Label ID="Label69" runat="server" Text="bis:" CssClass="lblDateToTitle"></asp:Label> 
                            <asp:TextBox ID="txtCostCenterTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>--%>
                        </section>
                        <section class="topRight2" style="width: 29%;">
                            <asp:Label ID="Label70" runat="server" Text="Druckbeginn nach:" CssClass="lblPrintMode" Style="margin-left: 12.5%;"></asp:Label>
                            <asp:Label ID="lblVariableA" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>
                        </section>
                        <section class="topRight3" style="display: none">
                            <asp:Label ID="Label71" runat="server" Text="Objekt" CssClass="lblPrintModeobj"></asp:Label>
                        </section>
                    </section>
                    <section class="selectionTwo">
                        <section class="topRight1">
                            <%-- <asp:Label ID="Label60" runat="server" Text="Datum" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label61" runat="server" Text="von:" CssClass="lblDtFromTitle" Style="width: 13%;"></asp:Label>

                            <asp:TextBox ID="txtDateFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label62" runat="server" Text="bis:" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtDateTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>--%>
                        </section>
                        <section class="topRight2">
                            <%--  <asp:Label ID="lbl" runat="server" Text="Ausgwählter Zeitbereich:" CssClass="lblPrintMode" Style="width: 56%;"></asp:Label>
                            <asp:Label ID="lblTimePrintType" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>--%>
                            <section class="loggedInUser">
                                <asp:Label ID="Label72" runat="server" Text="Erstellt von:" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblPersName" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>
                        </section>
                        <section class="topRight3" style="display: none">
                        </section>
                    </section>
                    <section class="selectionThree">
                        <section class="topRight3perpekind" style="margin-top:5px">
                            <section class="secholdingarea1_new">
                                <asp:Label ID="Label94" runat="server" Text="Hoch:" CssClass="txtportrait"></asp:Label>
                                <asp:ImageButton ID="imgPotraiB" runat="server" CssClass="btnorientation1" Style="cursor:default;"/>
                                <asp:CheckBox ID="chkVarientBPotrait" runat="server" CssClass="chk1controllast" />

                            </section>
                            <section class="secholdingarea1b_new">
                                <asp:Label ID="Label95" runat="server" Text="Quer:" CssClass="txtlandscape_new"></asp:Label>
                                <asp:ImageButton ID="imgLandB" runat="server" CssClass="btnorientation2" Style="cursor:default;"/>
                                <asp:CheckBox ID="chkVarientBLand" runat="server" CssClass="chk1controllast" />

                            </section>
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
            <dx:ASPxGridView ID="grdVariableA" runat="server" ClientIDMode="Static" ClientInstanceName="grdVariableA" Theme="Office2003Blue" SettingsPager-AlwaysShowPager="false" Settings-ShowFooter="false" SettingsBehavior-AllowSort="false" SettingsBehavior-AllowDragDrop="false" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdVariableA_CustomCallback">
                <SettingsPager PageSize="32" ShowEmptyDataRows="True" Visible="False"></SettingsPager>

                <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Studio Gruppe" VisibleIndex="1" FieldName="GroupName"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Name" VisibleIndex="2" FieldName="MemberName"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="ID Nr.:" VisibleIndex="3" FieldName="MemberNumber">
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Ort" VisibleIndex="4" FieldName="Place"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="PLZ" VisibleIndex="5" FieldName="PostalCode" CellStyle-HorizontalAlign="Left"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Anrede" VisibleIndex="6" FieldName="Salutation">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Straße und Nr." VisibleIndex="7" FieldName="StreetNumber">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Vertrags Nr" VisibleIndex="8" FieldName="ContractNumber">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Geburtsdatum" VisibleIndex="9" FieldName="DateOfBirth">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Nationalität" VisibleIndex="10" FieldName="Nationality">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Beruf" VisibleIndex="11" FieldName="Profession"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Telefon" VisibleIndex="12" FieldName="Telephone"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Handy" VisibleIndex="13" FieldName="MobileNr"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Email" VisibleIndex="14" FieldName="Email"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Eintrittsdatum" VisibleIndex="15" FieldName="StartDate">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="Austrittsdatum " VisibleIndex="16" FieldName="EndDate">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Langzeit Ausweis" VisibleIndex="17" FieldName="LongTermCardNumber"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Kurzzeit Ausweis" VisibleIndex="18" FieldName="ShortTermCardNumber"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Zutrittsberechtigung von-bis" FieldName="AccessDateFromTo" VisibleIndex="19">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Zutrittsplan Nr" VisibleIndex="20" FieldName="AccessPlanNr">
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Zutrittsplan Bezeichnung" VisibleIndex="21" FieldName="AccessPlanName"></dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
        </section>
    </section>
    <div class="showReportsDocViewer" style="display: none;">
        <dx:ASPxCallbackPanel ID="OneTodayCallbackPanel" runat="server" OnCallback="OneTodayCallbackPanel_Callback">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <dx:ASPxWebDocumentViewer ID="PersonalListLocalASPxDocumentViewer" Style="width: 100%; height: 1100px;" ClientIDMode="Static" ClientInstanceName="PersonalListLocalASPxDocumentViewer" runat="server" Theme="Office2003Blue">
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
                        <asp:Label ID="Label61" runat="server" Text="Studio Gruppe:" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label62" runat="server" Text="Mitgliedsname:" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label67" runat="server" Text="Ort:" CssClass="lblreport"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="txtClientBFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtLocationBFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtDeptBFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label90" runat="server" Text="bis:" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label91" runat="server" Text="bis:" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label92" runat="server" Text="bis:" CssClass="lblBis"></asp:Label>
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

                            <asp:Label ID="Label104" runat="server" Text="Gedruckt am:" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtTodayDate" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label105" runat="server" Text="Uhrzeit:" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtTodayTime" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>

                            <%-- <asp:Label ID="Label93" runat="server" Text="Kostenstelle" CssClass="lblDateTitle" Style="width: 16%"></asp:Label>
                            <asp:Label ID="Label94" runat="server" Text="von:" CssClass="lblDtFromTitle"></asp:Label> 
                            <asp:TextBox ID="txtCostBFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>
                                                           <asp:Label ID="Label95" runat="server" Text="bis:" CssClass="lblDateToTitle"></asp:Label> 
                            <asp:TextBox ID="txtCostBTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>--%>
                        </section>
                        <section class="topRight2" style="width: 29%;">
                            <asp:Label ID="Label96" runat="server" Text="Druckbeginn nach:" CssClass="lblPrintMode" Style="margin-left: 12.5%;"></asp:Label>
                            <asp:Label ID="lblVariableB" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>
                        </section>
                        <section class="topRight3" style="display: none">
                            <asp:Label ID="Label98" runat="server" Text="Objekt" CssClass="lblPrintModeobj"></asp:Label>
                        </section>
                    </section>
                    <section class="selectionTwo">
                        <section class="topRight1">
                            <%-- <asp:Label ID="Label99" runat="server" Text="Datum" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label100" runat="server" Text="von:" CssClass="lblDtFromTitle" Style="width: 13%;"></asp:Label>

                            <asp:TextBox ID="txtDateBFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label101" runat="server" Text="bis:" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtDateBTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>--%>
                        </section>
                        <section class="topRight2">
                            <%--  <asp:Label ID="lbl" runat="server" Text="Ausgwählter Zeitbereich:" CssClass="lblPrintMode" Style="width: 56%;"></asp:Label>
                            <asp:Label ID="lblTimePrintType" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>--%>
                            <section class="loggedInUser">
                                <asp:Label ID="Label102" runat="server" Text="Erstellt von:" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblPersNameB" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>
                        </section>
                        <section class="topRight3" style="display: none">
                        </section>
                    </section>
                    <section class="selectionThree">
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
                        <section class="topRight2">
                        </section>
                        <section class="topRight3">
                        </section>
                    </section>
                </section>
            </section>
        </section>
        <section class="mainBodybtm">
            <dx:ASPxGridView ID="grdVariableB" runat="server" ClientIDMode="Static" ClientInstanceName="grdVariableB" Theme="Office2003Blue" SettingsPager-AlwaysShowPager="false" Settings-ShowFooter="false" SettingsBehavior-AllowSort="false" SettingsBehavior-AllowDragDrop="false" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdVariableB_CustomCallback">
                <SettingsPager PageSize="32" ShowEmptyDataRows="True" Visible="False"></SettingsPager>
                <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Name" VisibleIndex="1" FieldName="MemberName"></dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn Caption="Studio Gruppe" VisibleIndex="2" FieldName="GroupName"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="ID Nr.:" VisibleIndex="3" FieldName="MemberNumber">
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Ort" VisibleIndex="4" FieldName="Place"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="PLZ" VisibleIndex="5" FieldName="PostalCode" CellStyle-HorizontalAlign="Left"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Anrede" VisibleIndex="6" FieldName="Salutation">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Straße und Nr." VisibleIndex="7" FieldName="StreetNumber">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Vertrags Nr" VisibleIndex="8" FieldName="ContractNumber">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Geburtsdatum" VisibleIndex="9" FieldName="DateOfBirth">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Nationalität" VisibleIndex="10" FieldName="Nationality">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Beruf" VisibleIndex="11" FieldName="Profession"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Telefon" VisibleIndex="12" FieldName="Telephone"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Handy" VisibleIndex="13" FieldName="MobileNr"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Email" VisibleIndex="14" FieldName="Email"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Eintrittsdatum" VisibleIndex="15" FieldName="StartDate">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="Austrittsdatum " VisibleIndex="16" FieldName="EndDate">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Langzeit Ausweis" VisibleIndex="17" FieldName="LongTermCardNumber"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Kurzzeit Ausweis" VisibleIndex="18" FieldName="ShortTermCardNumber"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Zutrittsberechtigung von-bis" FieldName="AccessDateFromTo" VisibleIndex="19">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Zutrittsplan Nr" VisibleIndex="20" FieldName="AccessPlanNr">
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Zutrittsplan Bezeichnung" VisibleIndex="21" FieldName="AccessPlanName"></dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
        </section>
    </section>
    <section class="showReportsVarC" style="display: none">
        <section class="mainBodyTop">
            <section class="mainBodyTop1 ">
                <section class="mainBodyTop1left">
                    <section class="mainBodyTop1leftlbl">
                        <asp:Label ID="Label68" runat="server" Text="Studio Gruppe:" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label69" runat="server" Text="Mitgliedsname:" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label87" runat="server" Text="Ort:" CssClass="lblreport"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="txtClientCFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtLocationCFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtDeptCFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label109" runat="server" Text="bis:" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label110" runat="server" Text="bis:" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label111" runat="server" Text="bis:" CssClass="lblBis"></asp:Label>
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

                            <asp:Label ID="Label123" runat="server" Text="Gedruckt am:" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtTodayDateC" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label124" runat="server" Text="Uhrzeit:" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtTodayTimeC" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>


                            <%--  <asp:Label ID="Label112" runat="server" Text="Kostenstelle" CssClass="lblDateTitle" Style="width: 16%"></asp:Label>
                            <asp:Label ID="Label113" runat="server" Text="von:" CssClass="lblDtFromTitle"></asp:Label> 
                            <asp:TextBox ID="txtCostCFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox> 
                            <asp:Label ID="Label114" runat="server" Text="bis:" CssClass="lblDateToTitle"></asp:Label> 
                            <asp:TextBox ID="txtCoastCTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>--%>
                        </section>
                        <section class="topRight2" style="width: 29%;">
                            <asp:Label ID="Label115" runat="server" Text="Druckbeginn nach:" CssClass="lblPrintMode" Style="margin-left: 12.5%;"></asp:Label>
                            <asp:Label ID="lblVariableC" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>
                        </section>
                        <section class="topRight3" style="display: none">
                            <asp:Label ID="Label117" runat="server" Text="Objekt" CssClass="lblPrintModeobj"></asp:Label>
                        </section>
                    </section>
                    <section class="selectionTwo">
                        <section class="topRight1">
                            <%--   <asp:Label ID="Label118" runat="server" Text="Datum" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label119" runat="server" Text="von:" CssClass="lblDtFromTitle" Style="width: 13%;"></asp:Label>

                            <asp:TextBox ID="txtDateCFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label120" runat="server" Text="bis:" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtDateCTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>--%>
                        </section>
                        <section class="topRight2">
                            <section class="loggedInUser">
                                <asp:Label ID="Label121" runat="server" Text="Erstellt von:" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblPersNameC" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>
                        </section>
                        <section class="topRight3" style="display: none">
                        </section>
                    </section>
                    <section class="selectionThree">
                          <section class="topRight3perpekind" style="margin-top:5px;">
                            <section class="secholdingarea1_new">
                                <asp:Label ID="Label97" runat="server" Text="Hoch:" CssClass="txtportrait"></asp:Label>
                                <asp:ImageButton ID="imgPotraitC" runat="server" CssClass="btnorientation1" Style="cursor:default;"/>
                                <asp:CheckBox ID="chkVarCPotait" runat="server" CssClass="chk1controllast" />

                            </section>
                            <section class="secholdingarea1b_new">
                                <asp:Label ID="Label101" runat="server" Text="Quer:" CssClass="txtlandscape_new"></asp:Label>
                                <asp:ImageButton ID="imgLandC" runat="server" CssClass="btnorientation2" Style="cursor:default;"/>
                                <asp:CheckBox ID="chkVarCLand" runat="server" CssClass="chk1controllast" />

                            </section>
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
            <dx:ASPxGridView ID="grdVariableC" runat="server" ClientIDMode="Static" ClientInstanceName="grdVariableC" Theme="Office2003Blue" SettingsPager-AlwaysShowPager="false" Settings-ShowFooter="false" SettingsBehavior-AllowSort="false" SettingsBehavior-AllowDragDrop="false" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdVariableC_CustomCallback">

                <SettingsPager PageSize="32" ShowEmptyDataRows="True" Visible="False"></SettingsPager>

                <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Ort" VisibleIndex="1" FieldName="Place"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Name" VisibleIndex="2" FieldName="MemberName"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="ID Nr.:" VisibleIndex="3" FieldName="MemberNumber">
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Studio Gruppe" VisibleIndex="4" FieldName="GroupName"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="PLZ" VisibleIndex="5" FieldName="PostalCode" CellStyle-HorizontalAlign="Left"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Anrede" VisibleIndex="6" FieldName="Salutation">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Straße und Nr." VisibleIndex="7" FieldName="StreetNumber">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Vertrags Nr" VisibleIndex="8" FieldName="ContractNumber">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Geburtsdatum" VisibleIndex="9" FieldName="DateOfBirth">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Nationalität" VisibleIndex="10" FieldName="Nationality">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Beruf" VisibleIndex="11" FieldName="Profession"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Telefon" VisibleIndex="12" FieldName="Telephone"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Handy" VisibleIndex="13" FieldName="MobileNr"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Email" VisibleIndex="14" FieldName="Email"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Eintrittsdatum" VisibleIndex="15" FieldName="StartDate">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="Austrittsdatum " VisibleIndex="16" FieldName="EndDate">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Langzeit Ausweis" VisibleIndex="17" FieldName="LongTermCardNumber"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Kurzzeit Ausweis" VisibleIndex="18" FieldName="ShortTermCardNumber"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Zutrittsberechtigung von-bis" FieldName="AccessDateFromTo" VisibleIndex="19">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Zutrittsplan Nr" VisibleIndex="20" FieldName="AccessPlanNr">
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Zutrittsplan Bezeichnung" VisibleIndex="21" FieldName="AccessPlanName"></dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
        </section>
    </section>
    <section class="showReportsVarD" style="display: none">
        <section class="mainBodyTop">
            <section class="mainBodyTop1 ">
                <section class="mainBodyTop1left">
                    <section class="mainBodyTop1leftlbl">
                        <asp:Label ID="Label88" runat="server" Text="Studio Gruppe:" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label89" runat="server" Text="Mitgliedsname:" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label93" runat="server" Text="Ort:" CssClass="lblreport"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="txtVarDClientFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtVarDLocationFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtVarDDepartmentFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label128" runat="server" Text="bis:" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label129" runat="server" Text="bis:" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label130" runat="server" Text="bis:" CssClass="lblBis"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp4New">

                        <asp:TextBox ID="txtVarDClientTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtVarDLocationTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtVarDDepartmentTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left3">
                    <section class="selectionOne">
                        <section class="topRight1">

                            <asp:Label ID="Label142" runat="server" Text="Gedruckt am:" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtVarDPrintDate" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label143" runat="server" Text="Uhrzeit:" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtVarDPrintTime" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>

                            <%--<asp:Label ID="Label131" runat="server" Text="Kostenstelle" CssClass="lblDateTitle" Style="width: 16%"></asp:Label>
                            <asp:Label ID="Label132" runat="server" Text="von:" CssClass="lblDtFromTitle"></asp:Label> 
                            <asp:TextBox ID="txtVarDCostCenterFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox> 
                            <asp:Label ID="Label133" runat="server" Text="bis:" CssClass="lblDateToTitle"></asp:Label> 
                            <asp:TextBox ID="txtVarDCostCenterTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>--%>
                        </section>
                        <section class="topRight2" style="width: 29%;">
                            <asp:Label ID="Label134" runat="server" Text="Druckbeginn nach:" CssClass="lblPrintMode" Style="margin-left: 12.5%;"></asp:Label>
                            <asp:Label ID="lblVariableD" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>
                        </section>
                        <section class="topRight3" style="display: none">
                            <asp:Label ID="Label136" runat="server" Text="Objekt" CssClass="lblPrintModeobj"></asp:Label>
                        </section>
                    </section>
                    <section class="selectionTwo">
                        <section class="topRight1">
                            <%--<asp:Label ID="Label137" runat="server" Text="Datum" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label138" runat="server" Text="von:" CssClass="lblDtFromTitle" Style="width: 13%;"></asp:Label>

                            <asp:TextBox ID="TextBox9" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label139" runat="server" Text="bis:" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="TextBox10" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>--%>
                        </section>
                        <section class="topRight2">
                            <section class="loggedInUser">
                                <asp:Label ID="Label140" runat="server" Text="Erstellt von:" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblPersNameD" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>
                        </section>
                        <section class="topRight3" style="display: none">
                        </section>
                    </section>
                    <section class="selectionThree">
                                    <section class="topRight3perpekind" style="margin-top:5px;">
                            <section class="secholdingarea1_new">
                                <asp:Label ID="Label103" runat="server" Text="Hoch:" CssClass="txtportrait"></asp:Label>
                                <asp:ImageButton ID="imgLandD" runat="server" CssClass="btnorientation1" Style="cursor:default;"/>
                                <asp:CheckBox ID="chkpotraitD" runat="server" CssClass="chk1controllast" />

                            </section>
                            <section class="secholdingarea1b_new">
                                <asp:Label ID="Label106" runat="server" Text="Quer:" CssClass="txtlandscape_new"></asp:Label>
                                <asp:ImageButton ID="imgpotraitD" runat="server" CssClass="btnorientation2" Style="cursor:default;"/>
                                <asp:CheckBox ID="chkLandD" runat="server" CssClass="chk1controllast" />

                            </section>
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
            <dx:ASPxGridView ID="grdVariableD" runat="server" ClientIDMode="Static" ClientInstanceName="grdVariableD" Theme="Office2003Blue" SettingsPager-AlwaysShowPager="false" Settings-ShowFooter="false" SettingsBehavior-AllowSort="false" SettingsBehavior-AllowDragDrop="false" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdVariableD_CustomCallback">

                <SettingsPager PageSize="32" ShowEmptyDataRows="True" Visible="False"></SettingsPager>

                <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="PLZ" VisibleIndex="1" FieldName="PostalCode" Visible="False" CellStyle-HorizontalAlign="Left"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Name" VisibleIndex="2" FieldName="MemberName"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="ID Nr.:" VisibleIndex="3" FieldName="MemberNumber" Visible="False">
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Ort" VisibleIndex="4" FieldName="Place" Visible="False"></dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn Caption="Studio Gruppe" VisibleIndex="5" FieldName="GroupName"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Anrede" VisibleIndex="6" FieldName="Salutation" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Straße und Nr." VisibleIndex="7" FieldName="StreetNumber" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Vertrags Nr" VisibleIndex="8" FieldName="ContractNumber" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Geburtsdatum" VisibleIndex="9" FieldName="DateOfBirth">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Nationalität" VisibleIndex="10" FieldName="Nationality" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Beruf" VisibleIndex="11" FieldName="Profession" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Telefon" VisibleIndex="12" FieldName="Telephone" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Handy" VisibleIndex="13" FieldName="MobileNr" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Email" VisibleIndex="14" FieldName="Email" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Eintrittsdatum" VisibleIndex="15" FieldName="StartDate" Visible="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="Austrittsdatum " VisibleIndex="16" FieldName="EndDate" Visible="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Langzeit Ausweis" VisibleIndex="17" FieldName="LongTermCardNumber" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Kurzzeit Ausweis" VisibleIndex="18" FieldName="ShortTermCardNumber" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Zutrittsberechtigung von-bis" FieldName="AccessDateFromTo" Visible="False" VisibleIndex="19">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Zutrittsplan Nr" VisibleIndex="20" FieldName="AccessPlanNr" Visible="False">
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Zutrittsplan Bezeichnung" VisibleIndex="21" FieldName="AccessPlanName" Visible="False"></dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
        </section>
    </section>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <%-- <asp:Button ID="Button2" CssClass="newbtnfooterblue" runat="server" Text="Mitgliederliste neu" Style="width: 119px;" />
    <asp:Button ID="Button1" CssClass="savebtnfootergreen" runat="server" Text="Mitgliederliste speichern" Style="width: 155px;" />
    <asp:Button ID="Button3" CssClass="deletebtnfooterred" runat="server" Text="Mitgliederliste löschen" Style="width: 146px;" />
    <asp:Button ID="Button4" CssClass="editbtnfooterorange" runat="server" Text="Mitgliederliste drucken" Style="width: 145px;" />--%>


    <asp:Button ID="btnNew" CssClass="newbtnfooterblue" runat="server" Text="Mitgliederliste neu" Style="width: 114px;" />
    <asp:Button ID="btnEntSave" CssClass="savebtnfootergreen" runat="server" Text="Mitgliederliste speichern" Style="width: 153px;" />
    <asp:Button ID="btnCancelDel" CssClass="deletebtnfooterred" runat="server" Text="Mitgliederliste löschen" Style="width: 149px;" />
    <asp:Button ID="btnPrintSelection" CssClass="editbtnfooterorange" runat="server" Text="Mitgliederliste drucken" Style="width: 140px;" />
    <asp:Button ID="btnPrintReport" CssClass="editbtnfooterorange" runat="server" Text="Mitgliederliste drucken" Style="width: 140px; display: none;" />

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" ClientIDMode="Static" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
