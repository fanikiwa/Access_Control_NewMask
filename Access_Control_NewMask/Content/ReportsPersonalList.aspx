<%@ Page Title="<%$ Resources:localizedText, personallists %>" Language="C#" MasterPageFile="~/MasterPages/Reports.Master" ClientIDMode="Static" AutoEventWireup="true" CodeBehind="ReportsPersonalList.aspx.cs" Inherits="Access_Control_NewMask.Content.ReportPersonalList" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.2.Web, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/ReportsPersonalList.css" rel="stylesheet" />
    <script src="Scripts/ReportsPersonalList.js"></script>
    <script type="text/javascript">
        function doTime() {

            //$( "#lblTime" ).text( moment().format( "HH" ) + ":" + moment().format( "mm" ) );
            //  $("#lblDate").text(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
        }

        $(function () {
            setInterval(doTime, 1);

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div id="importantDialog" class="dialogBox"></div>
    <asp:HiddenField ID="HiddenField1BackValue" runat="server" />
    <asp:HiddenField ID="hiddenFieldSaveChanges" runat="server" />

    <div class="ContentAreaDiv">
        <div class="TopContentAreaDiv">
            <%-- <asp:CheckBox ID="chkPotriat" runat="server" Style="display: none" />
            <asp:CheckBox ID="chkLandScape" runat="server" Style="display: none" />--%>
            <section class="sectop">
                <section class="upperpart">
                    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, personalListsNo %>" CssClass="lblpersonlist"></asp:Label>
                    <dx:ASPxComboBox ID="cboPersonalListNr" runat="server" ValueField="ID" TextField="ListNr" ClientInstanceName="cboPersonalListNr" OnCallback="cboPersonalListNr_Callback"
                        TextFormatString="{0}" CallbackPageSize="100000" Theme="Office2003Blue" CssClass="combopersonno" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
cboPersonalListNrSelectedIndexChanged(s.GetValue());	
}"
                            DropDown="function(s, e) {
	dplClicked(s, e);
}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn Caption="Nr:" Name="ListNr" FieldName="ListNr" Width="15%" />
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, description_newP %>" Name="ListDescription" FieldName="ListDescription" Width="85%" />
                        </Columns>
                    </dx:ASPxComboBox>

                    <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, description_newP %>" CssClass="lblalleabswe"></asp:Label>
                    <dx:ASPxComboBox ID="cboPersonalListDescription" runat="server" ValueField="ID" TextField="ListDescription" ClientInstanceName="cboPersonalListDescription" OnCallback="cboPersonalListDescription_Callback"
                        TextFormatString="{1}" CallbackPageSize="100000" Theme="Office2003Blue" CssClass="combopersondes" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
cboPersonalListDescSelectedIndexChanged(s.GetValue());	
}"
                            DropDown="function(s, e) {
	dplClicked(s, e);
}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn Caption="Nr:" Name="ListNr" FieldName="ListNr" Width="15%" />
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, description_newP %>" Name="ListDescription" FieldName="ListDescription" Width="85%" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText, date_new %>" CssClass="lbldatum"></asp:Label>
                    <asp:Label ID="lblDate" runat="server" Text="" CssClass="lblDtDispNew"></asp:Label>
                    <asp:Label ID="Label42" runat="server" Text="<%$ Resources:localizedText, activePersons %>" CssClass="lblaktivep"></asp:Label>
                    <asp:CheckBox ID="chkActivePersonal" runat="server" CssClass="chkabwse chkPersTyp" AutoPostBack="false" />
                    <asp:Label ID="Label5" runat="server" Text="<%$ Resources:localizedText, inactivePersons %>" CssClass="lblalleget"></asp:Label>
                    <asp:CheckBox ID="chkInactivePersonal" runat="server" CssClass="chkallget chkPersTyp" AutoPostBack="false" />

                </section>
                <section class="lowerpart">
                    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, personalListsNo %>" CssClass="lblpersonlist"></asp:Label>
                    <asp:TextBox ID="txtPersonalListNr" runat="server" CssClass="txtperli"></asp:TextBox>
                    <asp:Label ID="Label40" runat="server" Text="<%$ Resources:localizedText, description_newP %>" CssClass="lblalleabswe"></asp:Label>
                    <asp:TextBox ID="txtPersonalListDescription" runat="server" CssClass="txtdes"></asp:TextBox>
                </section>
            </section>
        </div>
        <div class="MidContentAreaDiv">
            <section class="contentarea">
                <section class="leftside">
                    <section class="top1">
                        <section class="top1left">
                            <section class="lblleft">
                                <asp:Label ID="Label8" runat="server" Text="<%$ Resources:localizedText, printSelection_New %>" CssClass="lbaus"></asp:Label>
                            </section>
                            <section class="topsec1left">
                                <asp:Label ID="Label9" runat="server" Text="<%$ Resources:localizedText, companyFrom %>" CssClass="lbldatefrom"></asp:Label>

                                <dx:ASPxComboBox ID="cboCompanyFrom" ClientInstanceName="cboCompanyFrom" ValueField="ID" TextField="Name" TextFormatString="{1}" CallbackPageSize="100000" runat="server" Theme="Office2003Blue" CssClass="datedis" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobCompanyFromIndexChanged(s,e);	
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Nr.:" Name="Client_Nr" FieldName="Client_Nr" Width="15%" />
                                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, companynew %>" Name="Name" FieldName="Name" Width="85%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                                <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>

                                <dx:ASPxComboBox ID="cboCompanyTo" ClientInstanceName="cboCompanyTo" ValueField="ID" TextField="Name" TextFormatString="{1}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="datedis" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobCompanyToIndexChanged(s,e);	
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Nr.:" Name="Client_Nr" FieldName="Client_Nr" Width="15%" />
                                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, companynew %>" Name="Name" FieldName="Name" Width="85%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                            </section>
                            <section class="topsec1left2">
                                <asp:Label ID="Label13" runat="server" Text="<%$ Resources:localizedText, locationFrom_new %>" CssClass="lbldatefrom"></asp:Label>
                                <dx:ASPxComboBox ID="cboLocationFrom" ClientInstanceName="cboLocationFrom" ValueField="ID" TextField="Name" TextFormatString="{1}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobLocationFromIndexChanged(s,e);	
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Nr:" Name="Location_Nr" FieldName="Location_Nr" Width="15%" />
                                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, location1 %>" Name="Name" FieldName="Name" Width="85%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                                <asp:Label ID="Label14" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                                <dx:ASPxComboBox ID="cboLocationTo" ClientInstanceName="cboLocationTo" ValueField="ID" TextField="Name" TextFormatString="{1}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobLocationToIndexChanged(s,e);	
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Nr.:" Name="Location_Nr" FieldName="Location_Nr" Width="15%" />
                                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, location1 %>" Name="Name" FieldName="Name" Width="85%" />
                                    </Columns>
                                </dx:ASPxComboBox>

                            </section>
                            <section class="topsec1left2">
                                <asp:Label ID="Label15" runat="server" Text="<%$ Resources:localizedText, departmentFrom %>" CssClass="lbldatefrom"></asp:Label>
                                <dx:ASPxComboBox ID="cboDepartmentFrom" ClientInstanceName="cboDepartmentFrom" ValueField="ID" TextField="Name" TextFormatString="{1}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobDepartmentFromIndexChanged(s,e);	
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Nr.:" Name="Department_Nr" FieldName="Department_Nr" />
                                        <dx:ListBoxColumn Caption="Name:" Name="Name" FieldName="Name" />
                                    </Columns>
                                </dx:ASPxComboBox>
                                <asp:Label ID="Label16" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>

                                <dx:ASPxComboBox ID="cboDepartmentTo" ClientInstanceName="cboDepartmentTo" ValueField="ID" TextField="Name" TextFormatString="{1}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobDepartmentToIndexChanged(s,e);	
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Nr.:" Name="Department_Nr" FieldName="Department_Nr" />
                                        <dx:ListBoxColumn Caption="Name:" Name="Name" FieldName="Name" />
                                    </Columns>
                                </dx:ASPxComboBox>
                            </section>
                            <section class="topsec1left2">
                                <asp:Label ID="Label17" runat="server" Text="<%$ Resources:localizedText, nameFrom_P %>" CssClass="lbldatefrom"></asp:Label>
                                <dx:ASPxComboBox ID="cboPersNameFrom" ClientInstanceName="cboPersNameFrom" ValueField="ID" TextField="Name" TextFormatString="{1}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobNameFromIndexChanged(s,e);	
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Nr:" Name="Pers_Nr" FieldName="Pers_Nr" Width="15%" />
                                        <dx:ListBoxColumn Caption="Name:" Name="Name" FieldName="Name" Width="85%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                                <asp:Label ID="Label18" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                                <dx:ASPxComboBox ID="cbopersNameTo" ClientInstanceName="cbopersNameTo" ValueField="ID" TextField="Name" TextFormatString="{1}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
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
                                <asp:Label ID="Label12" runat="server" Text="<%$ Resources:localizedText, idNoFrom %>" CssClass="lbldatefrom"></asp:Label>
                                <dx:ASPxComboBox ID="cboPersIdFrom" ClientInstanceName="cboPersIdFrom" ValueField="ID" TextField="Pers_Nr" TextFormatString="{0}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobPersNrFromIndexChanged(s,e);	
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Nr:" Name="Pers_Nr" FieldName="Pers_Nr" Width="15%" />
                                        <dx:ListBoxColumn Caption="Name:" Name="Name" FieldName="Name" Width="85%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                                <asp:Label ID="Label19" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                                <dx:ASPxComboBox ID="cboPersIdTo" ClientInstanceName="cboPersIdTo" ValueField="ID" TextField="Pers_Nr" TextFormatString="{0}" CallbackPageSize="100000" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobPersNrToIndexChanged(s,e);	
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Nr:" Name="Pers_Nr" FieldName="Pers_Nr" Width="15%" />
                                        <dx:ListBoxColumn Caption="Name:" Name="Name" FieldName="Name" Width="85%" />
                                    </Columns>
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
                                        <asp:TableCell ID="lblObjectschks" CssClass="tblCell12">
                                            <asp:Label ID="lblObjects" runat="server" Text="1" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPersonttalchecks" CssClass="tblCell2">
                                            <asp:Label ID="lblPersonal" runat="server" Text="<%$ Resources:localizedText, company_Title %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lbl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkCompany" runat="server" /><label for='chkCompany'></label>

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
                                            <asp:Label ID="Label21" runat="server" Text="<%$ Resources:localizedText, locationnew %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lhbl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkLocation" runat="server" /><label for='chkLocation'></label>
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
                                            <asp:Label ID="Label24" runat="server" Text="<%$ Resources:localizedText, departmentTitle %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lbll" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkDepartment" runat="server" /><label for='chkDepartment'></label>
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
                                            <asp:Label ID="Label27" runat="server" Text="<%$ Resources:localizedText, nameFrom_P %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lbdl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkPersName" runat="server" /><label for='chkPersName'></label>
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
                                            <asp:Label ID="Label30" runat="server" Text="<%$ Resources:localizedText, idNoFrom %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldbl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkPersId" runat="server" /><label for='chkPersId'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>

                        </section>
                        <section class="top1farright">
                            <section class="lblleft">
                                <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, printStartAfter_New %>" CssClass="lbdrun"></asp:Label>
                            </section>
                            <section class="topsec1leftright">
                                <asp:CheckBox ID="chkVariableA" runat="server" CssClass="chkvar chkAllvar" />
                                <asp:Label ID="Label41" runat="server" Text="<%$ Resources:localizedText, variantA %>" CssClass="lblvariantlast"></asp:Label>
                            </section>
                            <section class="topsec1leftright">
                                <asp:CheckBox ID="chkVariableB" runat="server" CssClass="chkvar chkAllvar" />
                                <asp:Label ID="Label43" runat="server" Text="<%$ Resources:localizedText, variantB %>" CssClass="lblvariantlast"></asp:Label>
                            </section>
                            <section class="topsec1leftright">
                                <asp:CheckBox ID="chkVariableC" runat="server" CssClass="chkvar chkAllvar" />
                                <asp:Label ID="Label44" runat="server" Text="<%$ Resources:localizedText, variantC %>" CssClass="lblvariantlast"></asp:Label>
                            </section>
                            <section class="topsec1leftright">
                                <asp:CheckBox ID="chkVariableD" runat="server" CssClass="chkvar chkAllvar" />
                                <asp:Label ID="Label45" runat="server" Text="<%$ Resources:localizedText, variantD %>" CssClass="lblvariantlast"></asp:Label>
                            </section>
                        </section>
                    </section>
                    <section class="belowsec">
                        <section class="lblcenter">
                            <asp:Label ID="Label39" runat="server" Text="<%$ Resources:localizedText, otherSelections_New %>" CssClass="lbaus"></asp:Label>
                        </section>
                        <section class="belowsecholder">
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblObjecuttschks" CssClass="tblCell1">
                                            <asp:Label ID="Label11" runat="server" Text="6" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPersjtonalchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label22" runat="server" Text="<%$ Resources:localizedText, place2 %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lhjbl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkPlace" runat="server" /><label for='chkPlace'></label>
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
                                            <asp:Label ID="Label28" runat="server" Text="<%$ Resources:localizedText, postcode %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldfbll" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkPostalCode" runat="server" /><label for='chkPostalCode'></label>
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
                                            <asp:Label ID="Label32" runat="server" Text="<%$ Resources:localizedText, streetAndNumber %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lbdrl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkStreetNrAdnName" runat="server" /><label for='chkStreetNrAdnName'></label>
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
                                            <asp:Label ID="Label34" runat="server" Text="<%$ Resources:localizedText, dateOfBirth %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldrbl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkDateOfBirth" runat="server" /><label for='chkDateOfBirth'></label>
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
                                            <asp:Label ID="Label36" runat="server" Text="<%$ Resources:localizedText, dateofentry %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldarbl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkEnrtyDate" runat="server" /><label for='chkEnrtyDate'></label>
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
                                            <asp:Label ID="Label38" runat="server" Text="<%$ Resources:localizedText, dateofexit %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldrbdl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkExitDate" runat="server" /><label for='chkExitDate'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblObjqecuttschks" CssClass="tblCell1">
                                            <asp:Label ID="Label73" runat="server" Text="12" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPewrsjtonalchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label74" runat="server" Text="<%$ Resources:localizedText, employedAs_new %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lhjqbl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkEmployedAs" runat="server" /><label for='chkEmployedAs'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblObwjjecltschks" CssClass="tblCell1">
                                            <asp:Label ID="Label75" runat="server" Text="13" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPerqsiodnalchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label76" runat="server" Text="<%$ Resources:localizedText, nationality %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldfbqll" CssClass="tblCell3">
                                            <asp:CheckBox ID="chknationality" runat="server" /><label for='chknationality'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblOrrqbjecschks" CssClass="tblCell1">
                                            <asp:Label ID="Label77" runat="server" Text="14" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPerornawlchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label78" runat="server" Text="<%$ Resources:localizedText, companyPhone_new %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lbdwrl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkCompanyTelephone" runat="server" /><label for='chkCompanyTelephone'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblrOwbctschks" CssClass="tblCell1">
                                            <asp:Label ID="Label79" runat="server" Text="15" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPrerrswlchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label80" runat="server" Text="<%$ Resources:localizedText, companyMobile_new %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldrbwl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkCompanyMobile" runat="server" /><label for='chkCompanyMobile'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblrObcwtsschks" CssClass="tblCell1">
                                            <asp:Label ID="Label81" runat="server" Text="16" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPrerdwrslchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label82" runat="server" Text="<%$ Resources:localizedText, privatePhone_new %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldawrbwl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkPrivateTelephone" runat="server" /><label for='chkPrivateTelephone'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblrObcwwtscehks" CssClass="tblCell1">
                                            <asp:Label ID="Label83" runat="server" Text="17" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPrerrswwflchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label84" runat="server" Text="<%$ Resources:localizedText, privateMobile_new %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldrqabdl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkPrivateMobile" runat="server" /><label for='chkPrivateMobile'></label>
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
                                            <asp:Label ID="Label46" runat="server" Text="18" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPersjstonalchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label47" runat="server" Text="<%$ Resources:localizedText, longTermCard %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lhsjbl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkLongTermCard" runat="server" /><label for='chkLongTermCard'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblObjsjecltschks" CssClass="tblCell1">
                                            <asp:Label ID="Label48" runat="server" Text="19" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPersiodsnalchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label49" runat="server" Text="<%$ Resources:localizedText, shortTimeCard %>" CssClass="lblobjectareatitle"></asp:Label>
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
                                            <asp:Label ID="Label50" runat="server" Text="20" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblPerornalcshecks" CssClass="tblCell2">
                                            <asp:Label ID="Label51" runat="server" Text="<%$ Resources:localizedText, accessAuthorizationFromTo %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lbsdrl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkAccessAuthorization" runat="server" /><label for='chkAccessAuthorization'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                            <section class="topsec1right2b">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell ID="lblrOabctschks" CssClass="tblCell1">
                                            <asp:Label ID="Label52" runat="server" Text="21" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblParerrslchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label53" runat="server" Text="<%$ Resources:localizedText, accessPlanNr %>" CssClass="lblobjectareatitle"></asp:Label>
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
                                            <asp:Label ID="Label54" runat="server" Text="22" CssClass="lblno"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="lblsPrerdrslchecks" CssClass="tblCell2">
                                            <asp:Label ID="Label55" runat="server" Text="<%$ Resources:localizedText, accessPlanDescription_new %>" CssClass="lblobjectareatitle"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell ID="ldacrbl" CssClass="tblCell3">
                                            <asp:CheckBox ID="chkAccessPlanDescription" runat="server" /><label for='chkAccessPlanDescription'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>

                            <section class="lblcen">
                                <asp:Label ID="Label58" runat="server" Text="<%$ Resources:localizedText, accessGruppe %>" CssClass="lbcen"></asp:Label>
                            </section>
                            <section class="belowgrid">
                                <dx:ASPxGridView ID="grdAccessGroups" ClientIDMode="Static" ClientInstanceName="grdAccessGroups" runat="server" KeyFieldName="ID" Theme="Office2003Blue" AutoGenerateColumns="False" Width="100%">
                                    <SettingsPager PageSize="8" ShowEmptyDataRows="true" Visible="False"></SettingsPager>
                                    <SettingsBehavior AllowSort="false" AllowFocusedRow="True" />
                                    <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn VisibleIndex="1" Caption="" Width="14%"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Nr.:"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn VisibleIndex="3" Caption="<%$ Resources:localizedText, description_newP %>"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn VisibleIndex="4" Caption="<%$ Resources:localizedText, active_NewP %>"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn VisibleIndex="5" Caption="<%$ Resources:localizedText, fromTo %>"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn VisibleIndex="6" Caption=""></dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                            </section>
                        </section>
                    </section>
                </section>
                <section class="gridarea">
                    <section class="lblfarright">
                        <asp:Label ID="Label56" runat="server" Text="<%$ Resources:localizedText, savedPersonalLists %>" CssClass="lbdrun"></asp:Label>
                    </section>
                    <section class="grid">
                        <dx:ASPxGridView ID="grdSavedPersonalList" ClientIDMode="Static" ClientInstanceName="grdSavedPersonalList" runat="server" KeyFieldName="ID" Theme="Office2003Blue" AutoGenerateColumns="False" Width="100%" OnCustomCallback="grdSavedPersonalList_CustomCallback">

                            <ClientSideEvents RowDblClick="function(s, e) {
grdSavedPersonalListDblClick(s, e);	
}"></ClientSideEvents>

                            <SettingsPager PageSize="27" ShowEmptyDataRows="true" Visible="False"></SettingsPager>
                            <SettingsBehavior AllowSort="false" AllowFocusedRow="True" />
                            <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Nr.:" Width="12%" FieldName="ListNr"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="2" Caption="<%$ Resources:localizedText, description_newP %>" Width="88%" FieldName="ListDescription"></dx:GridViewDataTextColumn>
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
                        <asp:Label ID="Label57" runat="server" Text="<%$ Resources:localizedText ,companyFrom%>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label59" runat="server" Text="<%$ Resources:localizedText, locationFrom_new %>" CssClass="lblreport"></asp:Label>
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

                            <asp:Label ID="Label85" runat="server" Text="<%$ Resources:localizedText, printedOn %>" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtPrintDate" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label86" runat="server" Text="<%$ Resources:localizedText, timeTitle %>" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtPrintTime" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>


                            <%-- <asp:Label ID="Label67" runat="server" Text="Kostenstelle" CssClass="lblDateTitle" Style="width: 16%"></asp:Label>
                            <asp:Label ID="Label68" runat="server" Text="von:" CssClass="lblDtFromTitle"></asp:Label> 
                            <asp:TextBox ID="txtCostCenterFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>
                            <asp:Label ID="Label69" runat="server" Text="bis:" CssClass="lblDateToTitle"></asp:Label> 
                            <asp:TextBox ID="txtCostCenterTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>--%>
                        </section>
                        <section class="topRight2" style="width: 29%;">
                            <asp:Label ID="Label70" runat="server" Text="<%$ Resources:localizedText, printingStart %>" CssClass="lblPrintMode"></asp:Label>
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
                                <asp:Label ID="Label72" runat="server" Text="<%$ Resources:localizedText, createdBy %>" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblPersName" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>
                            <section class="topRight3perpekind">
                                <section class="secholdingarea1_new">
                                    <asp:Label ID="Label60" runat="server" Text="<%$ Resources:localizedText, potrait %>" CssClass="txtportrait"></asp:Label>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CssClass="btnorientation1" Style="cursor: default;" />
                                    <asp:CheckBox ID="chkPotraitA" runat="server" CssClass="chk1controllast" />

                                </section>
                                <section class="secholdingarea1b_new">
                                    <asp:Label ID="Label61" runat="server" Text="<%$ Resources:localizedText, landScape %>" CssClass="txtlandscape_new"></asp:Label>
                                    <asp:ImageButton ID="ImageButton2" runat="server" CssClass="btnorientation2" Style="cursor: default;" />
                                    <asp:CheckBox ID="chkLandScapeA" runat="server" CssClass="chk1controllast" />

                                </section>
                            </section>
                        </section>
                        <section class="topRight3" style="display: none">
                        </section>
                    </section>
                    <section class="selectionThree">
                        <section class="topRight1" style="margin-top: 5px;">
                            <%-- <asp:Label ID="Label85" runat="server" Text="Gedruckt am:" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtPrintDate" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label86" runat="server" Text="Uhrzeit:" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtPrintTime" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>--%>
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
            <dx:ASPxGridView ID="grdShowReport" runat="server" ClientIDMode="Static" ClientInstanceName="grdShowReport" Theme="Office2003Blue" SettingsPager-AlwaysShowPager="false" Settings-ShowFooter="false" SettingsBehavior-AllowSort="false" SettingsBehavior-AllowDragDrop="false" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdShowReport_CustomCallback">
                <SettingsPager PageSize="13" ShowEmptyDataRows="True" Visible="False"></SettingsPager>

                <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, company_Title %>" VisibleIndex="1" FieldName="ClientName" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, locationnew %>" VisibleIndex="2" FieldName="Location" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, departmentTitle %>" VisibleIndex="3" FieldName="DepartmentName" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Name:" VisibleIndex="4" FieldName="FullName" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, personId %>" VisibleIndex="5" FieldName="Pers_Nr" Visible="False" CellStyle-HorizontalAlign="Left"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, placeTitle %>" VisibleIndex="6" FieldName="Place" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, zipCode2 %>" VisibleIndex="7" FieldName="PostalCode" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, streetAndNumber %>" VisibleIndex="8" FieldName="StreetNrAndName" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, dateOfBirth %>" VisibleIndex="9" FieldName="DateOfBirth" Visible="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, dateofentry %>" VisibleIndex="10" FieldName="EntryDate" Visible="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, dateofexit %>" VisibleIndex="11" FieldName="ExitDate" Visible="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, employedAs_new %>" VisibleIndex="12" FieldName="EmploymentPosition" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, nationality %>" VisibleIndex="13" FieldName="Nationality" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, companyPhone_new %>" VisibleIndex="14" FieldName="CompanyPhone" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, companyMobile_new %>" VisibleIndex="15" FieldName="CompanyMobile" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, privatePhone_new %>" VisibleIndex="16" FieldName="PrivatePhone" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, privateMobile_new %>" VisibleIndex="17" FieldName="PrivateMobile" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, longTermCard %>" VisibleIndex="18" FieldName="AusweisNr" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, ShortTermCardTitle %>" VisibleIndex="19" FieldName="AusweisNrShortTerm" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, accessAuthorizationFromTo %>" FieldName="AuthorisedBy" Visible="False" VisibleIndex="20"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, accessPlanNr %>" VisibleIndex="21" FieldName="AccessPlanNr" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, accessPlanDescription_newP %>" VisibleIndex="22" FieldName="AccessPlanDescription" Visible="False"></dx:GridViewDataTextColumn>
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
                        <asp:Label ID="Label87" runat="server" Text="<%$ Resources:localizedText ,companyFrom%>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label88" runat="server" Text="<%$ Resources:localizedText, locationFrom_new %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label89" runat="server" Text="<%$ Resources:localizedText, departmentFrom_new %>" CssClass="lblreport"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="txtClientBFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtLocationBFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtDeptBFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label90" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label91" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label92" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
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

                            <asp:Label ID="Label104" runat="server" Text="<%$ Resources:localizedText, printedOn %>" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtTodayDate" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label105" runat="server" Text="<%$ Resources:localizedText, timeTitle %>" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtTodayTime" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>

                            <%-- <asp:Label ID="Label93" runat="server" Text="Kostenstelle" CssClass="lblDateTitle" Style="width: 16%"></asp:Label>
                            <asp:Label ID="Label94" runat="server" Text="von:" CssClass="lblDtFromTitle"></asp:Label> 
                            <asp:TextBox ID="txtCostBFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>
                                                           <asp:Label ID="Label95" runat="server" Text="bis:" CssClass="lblDateToTitle"></asp:Label> 
                            <asp:TextBox ID="txtCostBTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>--%>
                        </section>
                        <section class="topRight2" style="width: 29%;">
                            <asp:Label ID="Label96" runat="server" Text="<%$ Resources:localizedText, printingStart %>" CssClass="lblPrintMode"></asp:Label>
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
                                <asp:Label ID="Label102" runat="server" Text="<%$ Resources:localizedText, createdBy %>" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblPersNameB" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>
                            <section class="topRight3perpekind">
                                <section class="secholdingarea1_new">
                                    <asp:Label ID="Label62" runat="server" Text="<%$ Resources:localizedText, potrait %>" CssClass="txtportrait"></asp:Label>
                                    <asp:ImageButton ID="ImageButton3" runat="server" CssClass="btnorientation1" Style="cursor: default;" />
                                    <asp:CheckBox ID="chkPotraitB" runat="server" CssClass="chk1controllast" />

                                </section>
                                <section class="secholdingarea1b_new">
                                    <asp:Label ID="Label67" runat="server" Text="<%$ Resources:localizedText, landScape %>" CssClass="txtlandscape_new"></asp:Label>
                                    <asp:ImageButton ID="ImageButton4" runat="server" CssClass="btnorientation2" Style="cursor: default;" />
                                    <asp:CheckBox ID="chkLandScapeB" runat="server" CssClass="chk1controllast" />

                                </section>
                            </section>
                        </section>
                        <section class="topRight3" style="display: none">
                        </section>
                    </section>
                    <section class="selectionThree">
                        <section class="topRight1" style="margin-top: 5px;">
                            <%--  <asp:Label ID="Label104" runat="server" Text="Gedruckt am:" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtTodayDate" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label105" runat="server" Text="Uhrzeit:" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtTodayTime" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>--%>
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
            <dx:ASPxGridView ID="grdMainPersInfo" runat="server" ClientIDMode="Static" ClientInstanceName="grdMainPersInfo" Theme="Office2003Blue" SettingsPager-AlwaysShowPager="false" Settings-ShowFooter="false" SettingsBehavior-AllowSort="false" SettingsBehavior-AllowDragDrop="false" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdMainPersInfo_CustomCallback">
                <SettingsPager PageSize="13" ShowEmptyDataRows="True" Visible="False"></SettingsPager>
                <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, locationnew %>" VisibleIndex="1" FieldName="Location" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, company_Title %>" VisibleIndex="2" FieldName="ClientName" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, departmentTitle %>" VisibleIndex="3" FieldName="DepartmentName" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Name:" VisibleIndex="4" FieldName="FullName"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, personId %>" VisibleIndex="5" FieldName="Pers_Nr" Visible="False" CellStyle-HorizontalAlign="Left"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, placeTitle %>" VisibleIndex="6" FieldName="Place" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, zipCode2 %>" VisibleIndex="7" FieldName="PostalCode" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, streetAndNumber %>" VisibleIndex="8" FieldName="StreetNrAndName" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, dateOfBirth %>" VisibleIndex="9" FieldName="DateOfBirth" Visible="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, dateofentry %>" VisibleIndex="10" FieldName="EntryDate" Visible="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, dateofexit %>" VisibleIndex="11" FieldName="ExitDate" Visible="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, employedAs_new %>" VisibleIndex="12" FieldName="EmploymentPosition" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, nationality %>" VisibleIndex="13" FieldName="Nationality" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, companyPhone_new %>" VisibleIndex="14" FieldName="CompanyPhone" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, companyMobile_new %>" VisibleIndex="15" FieldName="CompanyMobile" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, privatePhone_new%>" VisibleIndex="16" FieldName="PrivatePhone" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, privateMobile_new %>" VisibleIndex="17" FieldName="PrivateMobile" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, longTermCard %>" VisibleIndex="18" FieldName="AusweisNr" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, ShortTermCardTitle %>" VisibleIndex="19" FieldName="AusweisNrShortTerm" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, accessAuthorizationFromTo %>" FieldName="AuthorisedBy" Visible="False" VisibleIndex="20"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, accessPlanNr %>" VisibleIndex="21" FieldName="AccessPlanNr" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, accessPlanDescription_newP %>" VisibleIndex="22" FieldName="AccessPlanDescription" Visible="False"></dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
        </section>
    </section>
    <section class="showReportsVarC" style="display: none">
        <section class="mainBodyTop">
            <section class="mainBodyTop1 ">
                <section class="mainBodyTop1left">
                    <section class="mainBodyTop1leftlbl">
                        <asp:Label ID="Label106" runat="server" Text="<%$ Resources:localizedText, companyFrom %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label107" runat="server" Text="<%$ Resources:localizedText, locationFrom_new %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label108" runat="server" Text="<%$ Resources:localizedText, departmentFrom_new %>" CssClass="lblreport"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="txtClientCFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtLocationCFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtDeptCFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label109" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label110" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label111" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
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

                            <asp:Label ID="Label123" runat="server" Text="<%$ Resources:localizedText, printedOn %>" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtTodayDateC" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label124" runat="server" Text="<%$ Resources:localizedText, timeTitle %>" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtTodayTimeC" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>


                            <%--  <asp:Label ID="Label112" runat="server" Text="Kostenstelle" CssClass="lblDateTitle" Style="width: 16%"></asp:Label>
                            <asp:Label ID="Label113" runat="server" Text="von:" CssClass="lblDtFromTitle"></asp:Label> 
                            <asp:TextBox ID="txtCostCFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox> 
                            <asp:Label ID="Label114" runat="server" Text="bis:" CssClass="lblDateToTitle"></asp:Label> 
                            <asp:TextBox ID="txtCoastCTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>--%>
                        </section>
                        <section class="topRight2">
                            <asp:Label ID="Label115" runat="server" Text="<%$ Resources:localizedText, printingStart %>" CssClass="lblPrintMode"></asp:Label>
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
                                <asp:Label ID="Label121" runat="server" Text="<%$ Resources:localizedText, createdBy %>" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblPersNameC" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>
                            <section class="topRight3perpekind">
                                <section class="secholdingarea1_new">
                                    <asp:Label ID="Label68" runat="server" Text="<%$ Resources:localizedText, potrait %>" CssClass="txtportrait"></asp:Label>
                                    <asp:ImageButton ID="ImageButton5" runat="server" CssClass="btnorientation1" Style="cursor: default;" />
                                    <asp:CheckBox ID="chkPotraitC" runat="server" CssClass="chk1controllast" />

                                </section>
                                <section class="secholdingarea1b_new">
                                    <asp:Label ID="Label69" runat="server" Text="<%$ Resources:localizedText, landScape %>" CssClass="txtlandscape_new"></asp:Label>
                                    <asp:ImageButton ID="ImageButton6" runat="server" CssClass="btnorientation2" Style="cursor: default;" />
                                    <asp:CheckBox ID="chkLandScapeC" runat="server" CssClass="chk1controllast" />

                                </section>
                            </section>
                        </section>
                        <section class="topRight3" style="display: none">
                        </section>
                    </section>
                    <section class="selectionThree">
                        <section class="topRight1" style="margin-top: 5px;">
                            <%-- <asp:Label ID="Label123" runat="server" Text="Gedruckt am:" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtTodayDateC" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label124" runat="server" Text="Uhrzeit:" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtTodayTimeC" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>--%>
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
            <dx:ASPxGridView ID="grdVaribleC" runat="server" ClientIDMode="Static" ClientInstanceName="grdVaribleC" Theme="Office2003Blue" SettingsPager-AlwaysShowPager="false" Settings-ShowFooter="false" SettingsBehavior-AllowSort="false" SettingsBehavior-AllowDragDrop="false" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdVaribleC_CustomCallback">

                <SettingsPager PageSize="13" ShowEmptyDataRows="True" Visible="False"></SettingsPager>

                <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, departmentTitle %>" VisibleIndex="1" FieldName="DepartmentName" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, company_Title %>" VisibleIndex="2" FieldName="ClientName" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, locationnew %>" VisibleIndex="3" FieldName="Location" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Name:" VisibleIndex="4" FieldName="FullName" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, personId %>" VisibleIndex="5" FieldName="Pers_Nr" CellStyle-HorizontalAlign="Left"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, placeTitle %>" VisibleIndex="6" FieldName="Place">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, zipCode2 %>" VisibleIndex="7" FieldName="PostalCode" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, streetAndNumber %>" VisibleIndex="8" FieldName="StreetNrAndName" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, dateOfBirth %>" VisibleIndex="9" FieldName="DateOfBirth" Visible="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, dateofentry %>" VisibleIndex="10" FieldName="EntryDate" Visible="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, dateofexit %>" VisibleIndex="11" FieldName="ExitDate" Visible="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, employedAs_new %>" VisibleIndex="12" FieldName="EmploymentPosition" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, nationality %>" VisibleIndex="13" FieldName="Nationality" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, companyPhone_new %>" VisibleIndex="14" FieldName="CompanyPhone" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, companyMobile_new %>" VisibleIndex="15" FieldName="CompanyMobile" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, privatePhone_new%>" VisibleIndex="16" FieldName="PrivatePhone" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, privateMobile_new %>" VisibleIndex="17" FieldName="PrivateMobile" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, longTermCard %>" VisibleIndex="18" FieldName="AusweisNr" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, ShortTermCardTitle %>" VisibleIndex="19" FieldName="AusweisNrShortTerm" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, accessAuthorizationFromTo %>" FieldName="AuthorisedBy" Visible="False" VisibleIndex="20"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, accessPlanNr %>" VisibleIndex="21" FieldName="AccessPlanNr"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, accessPlanDescription_newP %>" VisibleIndex="22" FieldName="AccessPlanDescription" Visible="False"></dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
        </section>
    </section>
    <section class="showReportsVarD" style="display: none">
        <section class="mainBodyTop">
            <section class="mainBodyTop1 ">
                <section class="mainBodyTop1left">
                    <section class="mainBodyTop1leftlbl">
                        <asp:Label ID="Label125" runat="server" Text="<%$ Resources:localizedText, companyFrom %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label126" runat="server" Text="<%$ Resources:localizedText, locationFrom_new %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label127" runat="server" Text="<%$ Resources:localizedText, departmentFrom_new %>" CssClass="lblreport"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="txtVarDClientFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtVarDLocationFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtVarDDepartmentFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label128" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label129" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label130" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
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

                            <asp:Label ID="Label142" runat="server" Text="<%$ Resources:localizedText, printedOn %>" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtVarDPrintDate" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label143" runat="server" Text="<%$ Resources:localizedText, timeTitle %>" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtVarDPrintTime" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>

                            <%--<asp:Label ID="Label131" runat="server" Text="Kostenstelle" CssClass="lblDateTitle" Style="width: 16%"></asp:Label>
                            <asp:Label ID="Label132" runat="server" Text="von:" CssClass="lblDtFromTitle"></asp:Label> 
                            <asp:TextBox ID="txtVarDCostCenterFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox> 
                            <asp:Label ID="Label133" runat="server" Text="bis:" CssClass="lblDateToTitle"></asp:Label> 
                            <asp:TextBox ID="txtVarDCostCenterTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>--%>
                        </section>
                        <section class="topRight2" style="width: 29%;">
                            <asp:Label ID="Label134" runat="server" Text="<%$ Resources:localizedText, printingStart %>" CssClass="lblPrintMode"></asp:Label>
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
                                <asp:Label ID="Label140" runat="server" Text="<%$ Resources:localizedText, createdBy %>" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblPersNameD" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>
                            <section class="topRight3perpekind">
                                <section class="secholdingarea1_new">
                                    <asp:Label ID="Label99" runat="server" Text="<%$ Resources:localizedText, potrait %>" CssClass="txtportrait"></asp:Label>
                                    <asp:ImageButton ID="imgPotraitPrint" runat="server" CssClass="btnorientation1" Style="cursor: default;" />
                                    <asp:CheckBox ID="chkPotraitD" runat="server" CssClass="chk1controllast" />

                                </section>
                                <section class="secholdingarea1b_new">
                                    <asp:Label ID="Label100" runat="server" Text="<%$ Resources:localizedText, landScape %>" CssClass="txtlandscape_new"></asp:Label>
                                    <asp:ImageButton ID="imgLandPrint" runat="server" CssClass="btnorientation2" Style="cursor: default;" />
                                    <asp:CheckBox ID="chkLandScapeD" runat="server" CssClass="chk1controllast" />

                                </section>
                            </section>
                        </section>
                    </section>
                </section>
            </section>
        </section>
        <section class="mainBodybtm">
            <dx:ASPxGridView ID="grdVaribleD" runat="server" ClientIDMode="Static" ClientInstanceName="grdVaribleD" Theme="Office2003Blue" SettingsPager-AlwaysShowPager="false" Settings-ShowFooter="false" SettingsBehavior-AllowSort="false" SettingsBehavior-AllowDragDrop="false" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdVaribleD_CustomCallback">

                <SettingsPager PageSize="13" ShowEmptyDataRows="True" Visible="False"></SettingsPager>

                <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Name:" VisibleIndex="1" FieldName="FullName"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, company_Title %>" VisibleIndex="2" FieldName="ClientName"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, locationnew %>" VisibleIndex="3" FieldName="Location" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, departmentTitle %>" VisibleIndex="4" FieldName="DepartmentName" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, personId %>" VisibleIndex="5" FieldName="Pers_Nr" Visible="False" CellStyle-HorizontalAlign="Left"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, placeTitle %>" VisibleIndex="6" FieldName="Place" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, zipCode2 %>" VisibleIndex="7" FieldName="PostalCode" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, streetAndNumber %>" VisibleIndex="8" FieldName="StreetNrAndName" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, dateOfBirth %>" VisibleIndex="9" FieldName="DateOfBirth" Visible="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, dateofentry %>" VisibleIndex="10" FieldName="EntryDate" Visible="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, dateofexit %>" VisibleIndex="11" FieldName="ExitDate" Visible="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, employedAs_new %>" VisibleIndex="12" FieldName="EmploymentPosition" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, nationality %>" VisibleIndex="13" FieldName="Nationality" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, companyPhone_new %>" VisibleIndex="14" FieldName="CompanyPhone" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, companyMobile_new %>" VisibleIndex="15" FieldName="CompanyMobile" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, privatePhone_new%>" VisibleIndex="16" FieldName="PrivatePhone" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, privateMobile_new %>" VisibleIndex="17" FieldName="PrivateMobile" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, longTermCard %>" VisibleIndex="18" FieldName="AusweisNr" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, ShortTermCardTitle %>" VisibleIndex="19" FieldName="AusweisNrShortTerm" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, accessAuthorizationFromTo %>" FieldName="AuthorisedBy" Visible="False" VisibleIndex="20"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, accessPlanNr %>" VisibleIndex="21" FieldName="AccessPlanNr" Visible="False"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, accessPlanDescription_newP %>" VisibleIndex="22" FieldName="AccessPlanDescription" Visible="False"></dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
        </section>
    </section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnNew" CssClass="newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, personalNew %>" Style="width: 114px;" />
    <asp:Button ID="btnEntSave" CssClass="savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, savePersonalList %>" Style="width: 153px;" />
    <asp:Button ID="btnCancelDel" CssClass="deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deletePersonalList %>" Style="width: 137px;" />
    <asp:Button ID="btnPrintSelection" CssClass="editbtnfooterorange" runat="server" Text="<%$ Resources:localizedText, printSelection_title %>" Style="width: 140px;" />
    <asp:Button ID="btnPrintReport" CssClass="editbtnfooterorange" runat="server" Text="<%$ Resources:localizedText, printPersonalList %>" Style="width: 140px; display: none;" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" ClientIDMode="Static" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
