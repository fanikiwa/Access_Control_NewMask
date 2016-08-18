<%@ Page Title="<%$ Resources:localizedText, visitorsAccessProtocols %>" Language="C#" MasterPageFile="~/MasterPages/Reports.Master" ClientIDMode="Static" AutoEventWireup="true" CodeBehind="VisitorReports.aspx.cs" Inherits="Access_Control_NewMask.Content.VisitorReports" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.2.Web, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/VisitorReports.css" rel="stylesheet" />
    <script src="Scripts/VisitorReports.js"></script>
    <script type="text/javascript">
        function doTime() {

            //$( "#lblTime" ).text( moment().format( "HH" ) + ":" + moment().format( "mm" ) );
            $("#lblDate").text(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
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
    <div class="ContentAreaDiv">
        <div id="ControlSection1" class="TopContentAreaDiv">
            <asp:HiddenField ID="HiddenField1BackValue" runat="server" />
            <asp:HiddenField ID="hiddenFieldSaveChanges" runat="server" />
            <%--selection  --%>
            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, accessProtocolNo %>" CssClass="lblAccProtNr"></asp:Label>
            <%--<dx:ASPxComboBox ID="ASPxComboBox1" Theme="Office2003Blue" runat="server" ValueType="System.String" CssClass="cboAccsPrtNr"></dx:ASPxComboBox>--%>
            <dx:ASPxComboBox ID="cboAccesReportNo" CallbackPageSize="100000" ValueField="ID" ClientInstanceName="cboAccesReportNo" TextField="Nr" SelectedIndex="0" Theme="Office2003Blue" runat="server" ValueType="System.String" CssClass="cboAccsPrtNr" OnCallback="cboAccesReportNo_Callback"
                TextFormatString="{0}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                <ClientSideEvents SelectedIndexChanged="function(s, e) {cboAccesReportNoSelectionChanged(s.GetValue());}"></ClientSideEvents>
                <Columns>
                    <dx:ListBoxColumn Caption="Nr.:" FieldName="Nr" Width="20%" />
                    <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, description_newP %>" FieldName="Name" Width="80%" />
                </Columns>
            </dx:ASPxComboBox>
            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, description_newP %>" CssClass="lblAccProtDesc"></asp:Label>
            <%--<dx:ASPxComboBox ID="ASPxComboBox2" Theme="Office2003Blue" runat="server" ValueType="System.String" CssClass="cboAccProtDesc"></dx:ASPxComboBox>--%>

            <dx:ASPxComboBox ID="cboAccesReportDesc" CallbackPageSize="100000" ClientInstanceName="cboAccesReportDesc" ValueField="ID" TextField="Name" SelectedIndex="0" Theme="Office2003Blue" runat="server" ValueType="System.String" CssClass="cboAccProtDesc" OnCallback="cboAccesReportDesc_Callback"
                TextFormatString="{1}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                <Columns>
                    <dx:ListBoxColumn Caption="Nr.:" FieldName="Nr" Width="20%" />
                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, description_newP %>" FieldName="Name" Width="80%" />
                </Columns>
                <ClientSideEvents SelectedIndexChanged="function(s, e) {cboAccesReportDescSelectionChanged(s.GetValue());}"></ClientSideEvents>
            </dx:ASPxComboBox>

            <%-- date --%>
            <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, date_new %>" CssClass="lblDateTitlenew" Style="margin-top: 27px;"></asp:Label>
            <asp:Label ID="lblDate" runat="server" Text="" CssClass="lblDtDisp"></asp:Label>

            <%-- check section --%>
            <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, today %>" CssClass="lblCheckToday"></asp:Label>
            <asp:CheckBox ID="chkToday" runat="server" CssClass="chkToday chkAll" />
            <asp:Label ID="Label5" runat="server" Text="<%$ Resources:localizedText, yesterday%>" CssClass="lblPreviousDay"></asp:Label>
            <asp:CheckBox ID="chkPreviousDay" runat="server" CssClass="chkPreviousDay chkAll" />
            <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText, thisWeek%>" CssClass="lblThisWk"></asp:Label>
            <asp:CheckBox ID="chkThisWk" runat="server" CssClass="chkThisWk chkAll" />
            <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText, lastWeek%>" CssClass="lblLastWk"></asp:Label>
            <asp:CheckBox ID="chkLastWk" runat="server" CssClass="chkLastWk chkAll" />
            <asp:Label ID="Label8" runat="server" Text="<%$ Resources:localizedText, thisMonth%>" CssClass="lblThisMonth"></asp:Label>
            <asp:CheckBox ID="chkThisMonth" runat="server" CssClass="chkThisMonth chkAll" />
            <asp:Label ID="Label9" runat="server" Text="<%$ Resources:localizedText, lastMonth%>" CssClass="lblLastMonth"></asp:Label>
            <asp:CheckBox ID="chkLastmonth" runat="server" CssClass="chkLastmonth chkAll" />
        </div>
        <div id="MainContdiv">
            <div class="topSection">
                <section class="secTopLeft">
                    <asp:Label ID="Label12" runat="server" Text="<%$ Resources:localizedText, accessProtocolNo %>" CssClass="lblAccProtocolNr"></asp:Label>
                    <asp:TextBox ID="txtAccessReportNo" runat="server" CssClass="txtAccProtclNr"></asp:TextBox>
                    <asp:Label ID="Label13" runat="server" Text="<%$ Resources:localizedText, description_newP %>" CssClass="lblProtocolDesc"></asp:Label>
                    <asp:TextBox ID="txtAccessReportDesc" runat="server" CssClass="txtProtocolDesc"></asp:TextBox>
                </section>
                <section class="secTopRight"></section>
            </div>
            <div class="fluidarea">
                <section class="secTopLeft" style="width: 40%">
                    <asp:Label ID="Label58" runat="server" Text="<%$ Resources:localizedText, printSelection %>" CssClass="lblprint"></asp:Label>
                </section>
                <section class="secTopRight">
                    <asp:Label ID="Label59" runat="server" Text="<%$ Resources:localizedText, selectionOfReports %>" CssClass="lblprselect" Style="width: 49%"></asp:Label>
                    <asp:Label ID="Label60" runat="server" Text="<%$ Resources:localizedText, savedProtocols %>" CssClass="lblprselectprotocal"></asp:Label>
                </section>
            </div>
            <div class="bttmSec">

                <section class="secLeftControls">
                    <div class="fluidarea">
                        <asp:Label ID="Label61" runat="server" Text="<%$ Resources:localizedText, objectOrientedReports %>" CssClass="lblobjectarea_new"></asp:Label>
                        <asp:CheckBox ID="chkoject" runat="server" CssClass="chkobjpers chkObjects" />
                        <asp:Label ID="Label62" runat="server" Text="<%$ Resources:localizedText, personalReports %>" CssClass="lblobjectarea"></asp:Label>
                        <asp:CheckBox ID="chkPersonal" runat="server" CssClass="chkobjpers chkpersonal" />

                        <section class="secRightTablesmall">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClass">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjectschks" CssClass="tblCell">
                                        <asp:Label ID="Label63" runat="server" Text="<%$ Resources:localizedText, object_new %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersonalchecks" CssClass="tblCell">
                                        <asp:Label ID="Label64" runat="server" Text="<%$ Resources:localizedText, persons %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                    </div>
                    <section class="secControlsOne">
                        <section class="secDvnOne">
                            <section class="secHeightDvn">
                                <asp:Label ID="Label14" runat="server" Text="<%$ Resources:localizedText, dateFrom_newP %>" CssClass="lblDtPckrFrm"></asp:Label>
                                <%--  <dx:ASPxDateEdit ID="dtpFrom" Theme="Office2003Blue" CssClass="dtFrom" runat="server">
                                </dx:ASPxDateEdit>--%>

                                <dx:ASPxDateEdit ID="dtpFrom" ClientIDMode="Static" HorizontalAlign="Center" Theme="Office2003Blue" CssClass="dtFrom" runat="server">
                                    <ClientSideEvents DateChanged="function(s, e) {drpPlanDateFromChanged(s, e, dtpTo);}" CalendarCustomDisabledDate="function(s, e) {
	DatesFrom(s, e);
}"></ClientSideEvents>
                                </dx:ASPxDateEdit>
                            </section>
                            <section class="secHeightDvn">
                                <asp:Label ID="Label16" runat="server" Text="<%$ Resources:localizedText, timeFrom %>" CssClass="lblTmPckrFrm"></asp:Label>
                                <%--<dx:ASPxTimeEdit ID="ASPxTimeEdit1" SpinButtons-ShowIncrementButtons="false" Theme="Office2003Blue" CssClass="tmFrom" runat="server"></dx:ASPxTimeEdit>--%>
                                <dx:ASPxTimeEdit ID="TimeFrom" HorizontalAlign="Center" EditFormat="Time" ClientInstanceName="TimeFrom" SpinButtons-ShowIncrementButtons="false" Theme="Office2003Blue" CssClass="tmFrom" runat="server"></dx:ASPxTimeEdit>

                            </section>
                        </section>
                        <section class="secDvnTwo">
                            <section class="secHeightDvn">
                                <asp:Label ID="Label15" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblDtPckrTo"></asp:Label>
                                <%--<dx:ASPxDateEdit ID="ASPxDateEdit2" Theme="Office2003Blue" runat="server" CssClass="dtTo"></dx:ASPxDateEdit>--%>

                                <dx:ASPxDateEdit ID="dtpTo" ClientIDMode="Static" HorizontalAlign="Center" Theme="Office2003Blue" runat="server" CssClass="dtTo">
                                    <ClientSideEvents DateChanged="function(s, e) {drpPlanDateToChanged(s, e);}" CalendarCustomDisabledDate="function(s, e) {
	DatesTo(s, e);
}"></ClientSideEvents>
                                </dx:ASPxDateEdit>
                            </section>
                            <section class="secHeightDvn">
                                <asp:Label ID="Label17" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblTmPckrTo"></asp:Label>
                                <%--<dx:ASPxTimeEdit ID="ASPxTimeEdit2" SpinButtons-ShowIncrementButtons="false" Theme="Office2003Blue" CssClass="tmTo" runat="server"></dx:ASPxTimeEdit>--%>

                                <dx:ASPxTimeEdit ID="TimeTo" HorizontalAlign="Center" EditFormat="Time" ClientInstanceName="TimeTo" SpinButtons-ShowIncrementButtons="false" Theme="Office2003Blue" CssClass="tmTo" runat="server"></dx:ASPxTimeEdit>

                            </section>
                        </section>
                        <section class="secDvnThree">
                            <section class="secLeftHeaders">
                                <asp:Label ID="Label18" runat="server" Text="<%$ Resources:localizedText, date_new %>" CssClass="lblSecTwoControlssmall"></asp:Label>
                                <asp:Label ID="Label19" runat="server" Text="<%$ Resources:localizedText, time_newP %>" CssClass="lblSecTwoControlssmall"></asp:Label>
                            </section>
                            <section class="secRightTable">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClass">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkObjDate" runat="server" /><label for='chkObjDate'></label>
                                        </asp:TableCell>
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkPersonalDate" runat="server" /><label for='chkPersonalDate'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow CssClass="rowTwo">
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkObjTime" runat="server" /><label for='chkObjTime'></label>
                                        </asp:TableCell>
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkPersTime" runat="server" /><label for='chkPersTime'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                        </section>

                    </section>
                    <section class="secTitle">
                        <asp:Label ID="Label56" runat="server" Text="<%$ Resources:localizedText, readerSelection_New %>" CssClass="lblTitle"></asp:Label>
                    </section>
                    <section class="secControlsTwo">
                        <section class="secDvnOne">
                            <section class="secFivDvns">
                                <asp:Label ID="Label20" runat="server" Text="<%$ Resources:localizedText, locationFrom_new %>" CssClass="lblSecControlsTwo"></asp:Label>
                                <%--<dx:ASPxComboBox ID="ASPxComboBox3" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo"></dx:ASPxComboBox>--%>

                                <%-- <dx:ASPxComboBox ID="cbolocation" ClientIDMode="Static" SelectedIndex="0" ClientInstanceName="cbolocation" runat="server" Theme="Office2003Blue"
                                    CssClass="cboSecControlsTwo" ValueField="LocationID" TextField="LocationName"
                                    TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {LocationIndexChanged(s, e);}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="BuildingPlanName" Name="BuildingPlan" Width="50%" Caption="Gebäudeplan:" ToolTip="Gebäudeplan"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="50%" Caption="Standort:" ToolTip="Standort"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>--%>


                                <dx:ASPxComboBox ID="cbolocation" CallbackPageSize="100000" ClientIDMode="Static" ClientInstanceName="cbolocation" runat="server" Theme="Office2003Blue"
                                    CssClass="cboSecControlsTwo" ValueField="LocationID" TextField="LocationName"
                                    TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	 LocationIndexChanged(s, e);
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="BuildingPlanName" Name="BuildingPlan" Width="50%" Caption="<%$ Resources:localizedText, building_NewP %>" ToolTip="Gebäudeplan"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="50%" Caption="<%$ Resources:localizedText, location_new %>" ToolTip="Standort"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>

                            </section>
                            <section class="secFivDvns">
                                <asp:Label ID="Label21" runat="server" Text="<%$ Resources:localizedText, buildingFrom %>" CssClass="lblSecControlsTwo"></asp:Label>

                                <%--<dx:ASPxComboBox ID="ASPxComboBox4" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo"></dx:ASPxComboBox>--%>

                                <%-- <dx:ASPxComboBox ID="cboBuilding" SelectedIndex="0" ValueField="BuildingID" TextField="BuildingName" ClientIDMode="Static" ClientInstanceName="cboBuilding"
                                    runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo" DropDownWidth="480px" DropDownRows="10"
                                    TextFormatString="{1}"
                                    Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" OnCallback="cboBuilding_Callback">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {cboBuildingselct(s, e);}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="50%" Caption="Standort:" ToolTip="Standort"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="BuildingName" Name="BuildingName" Width="50%" Caption="Gebaüde:" ToolTip="Gebaüde"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>--%>

                                <dx:ASPxComboBox ID="cboBuilding" CallbackPageSize="100000" ValueField="BuildingID" TextField="BuildingName" ClientIDMode="Static" ClientInstanceName="cboBuilding"
                                    runat="server" Theme="Office2003Blue" SelectedIndex="0" ValueType="System.String" CssClass="cboSecControlsTwo" DropDownWidth="480px" DropDownRows="10"
                                    TextFormatString="{1}"
                                    Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" OnCallback="cboBuilding_Callback" EnableCallbackMode="True">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	 BuildingsIndexChanged(s, e);
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="50%" Caption="<%$ Resources:localizedText, location_new %>" ToolTip="Standort"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="BuildingName" Name="BuildingName" Width="50%" Caption="<%$ Resources:localizedText, building_NewP %>" ToolTip="Gebaüde"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>

                            </section>
                            <section class="secFivDvns">
                                <asp:Label ID="Label22" runat="server" Text="<%$ Resources:localizedText, levelFrom %>" CssClass="lblSecControlsTwo"></asp:Label>
                                <%--<dx:ASPxComboBox ID="ASPxComboBox5" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo"></dx:ASPxComboBox>--%>

                                <%--<dx:ASPxComboBox ID="cboLevels" ValueField="LevelID" SelectedIndex="0" TextField="Level" ClientIDMode="Static" ClientInstanceName="cboLevels" runat="server"
                                    Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo" DropDownWidth="480px" DropDownRows="10" TextFormatString="{2}"
                                    Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {cboLevelselct(s, e);}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="32%" Caption="Standort:" ToolTip="Standort"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="BuildingName" Name="BuildingName" Width="32%" Caption="Gebaüde:" ToolTip="Gebaüde"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Level" Name="Level" Width="36%" Caption="Ebene:" ToolTip="Ebene"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>--%>

                                <dx:ASPxComboBox ID="cboLevels" CallbackPageSize="100000" ValueField="LevelID" TextField="Level" ClientIDMode="Static" ClientInstanceName="cboLevels" runat="server"
                                    Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo" DropDownWidth="480px" DropDownRows="10" TextFormatString="{2}"
                                    Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" SelectedIndex="0" Font-Size="14px" OnCallback="cboLevels_Callback" EnableCallbackMode="True">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	 LevelsIndexChanged(s, e);
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="32%" Caption="<%$ Resources:localizedText, location_new %>" ToolTip="Standort"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="BuildingName" Name="BuildingName" Width="32%" Caption="<%$ Resources:localizedText, building_NewP %>" ToolTip="Gebaüde"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Level" Name="Level" Width="36%" Caption="<%$ Resources:localizedText, level_NewP %>" ToolTip="Ebene"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>

                            </section>
                            <section class="secFivDvns">
                                <asp:Label ID="Label23" runat="server" Text="<%$ Resources:localizedText, roomFrom %>" CssClass="lblSecControlsTwo"></asp:Label>
                                <%--<dx:ASPxComboBox ID="ASPxComboBox6" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo"></dx:ASPxComboBox>--%>

                                <%--<dx:ASPxComboBox ID="cboRooms" ValueField="RoomID" TextField="Room" SelectedIndex="0" runat="server" Theme="Office2003Blue" ValueType="System.String"
                                    CssClass="cboSecControlsTwo" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                                    TextFormatString="{3}">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {Roomsselct(s, e);}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="25%" Caption="Standort:" ToolTip="Standort"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="BuildingName" Name="BuildingName" Width="25%" Caption="Gebaüde:" ToolTip="Gebaüde"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Level" Name="Level" Width="25%" Caption="Ebene:" ToolTip="Ebene"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Room" Name="Room" Width="25%" Caption="Raum:" ToolTip="Raum"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>--%>


                                <dx:ASPxComboBox ID="cboRooms" CallbackPageSize="100000" ValueField="RoomID" TextField="Room" runat="server" Theme="Office2003Blue" ValueType="System.String"
                                    CssClass="cboSecControlsTwo" SelectedIndex="0" DropDownWidth="680px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                                    TextFormatString="{3}" OnCallback="cboRooms_Callback" EnableCallbackMode="True">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	 RoomsIndexChanged(s, e);
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="25%" Caption="<%$ Resources:localizedText, location_new %>" ToolTip="Standort"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="BuildingName" Name="BuildingName" Width="25%" Caption="<%$ Resources:localizedText, building_NewP %>" ToolTip="Gebaüde"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Level" Name="Level" Width="25%" Caption="<%$ Resources:localizedText, level_NewP %>" ToolTip="Ebene"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Room" Name="Room" Width="25%" Caption="<%$ Resources:localizedText, room_new %>" ToolTip="Raum"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>

                            </section>
                            <section class="secFivDvns">
                                <asp:Label ID="Label24" runat="server" Text="<%$ Resources:localizedText, doorReaderFrom %>" CssClass="lblSecControlsTwo"></asp:Label>
                                <%--<dx:ASPxComboBox ID="ASPxComboBox7" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo"></dx:ASPxComboBox>--%>

                                <%-- <dx:ASPxComboBox ID="cboDoors" ValueField="DoorID" TextField="Door" SelectedIndex="0" runat="server" Theme="Office2003Blue" ValueType="System.String"
                                    CssClass="cboSecControlsTwo" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                                    TextFormatString="{4}">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {cboDoorsselct(s, e);}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="20%" Caption="Standort:" ToolTip="Standort"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="BuildingName" Name="BuildingName" Width="20%" Caption="Gebaüde:" ToolTip="Gebaüde"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Level" Name="Level" Width="20%" Caption="Ebene:" ToolTip="Ebene"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Room" Name="Room" Width="20%" Caption="Raum:" ToolTip="Raum"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Door" Name="Door" Width="20%" Caption="Tür/Leser:" ToolTip="Tür/Leser"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>--%>

                                <dx:ASPxComboBox ID="cboDoors" CallbackPageSize="100000" ValueField="DoorID" TextField="Door" runat="server" Theme="Office2003Blue" ValueType="System.String"
                                    CssClass="cboSecControlsTwo" SelectedIndex="0" DropDownWidth="680px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                                    TextFormatString="{4}" OnCallback="cboDoors_Callback" EnableCallbackMode="True">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	 DoorsIndexChanged(s, e);
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="20%" Caption="<%$ Resources:localizedText, location_new %>" ToolTip="Standort"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="BuildingName" Name="BuildingName" Width="20%" Caption="<%$ Resources:localizedText, building_NewP %>" ToolTip="Gebaüde"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Level" Name="Level" Width="20%" Caption="<%$ Resources:localizedText, level_NewP %>" ToolTip="Ebene"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Room" Name="Room" Width="20%" Caption="<%$ Resources:localizedText, room_new %>" ToolTip="Raum"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Door" Name="Door" Width="20%" Caption="<%$ Resources:localizedText, doorReader_NewP %>" ToolTip="Tür/Leser"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>

                            </section>
                        </section>
                        <section class="secDvnTwo">
                            <section class="secFivDvns">
                                <asp:Label ID="Label25" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblSecControlsTwobis"></asp:Label>
                                <%--<dx:ASPxComboBox ID="ASPxComboBox8" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo_new"></dx:ASPxComboBox>--%>

                                <%--                                <dx:ASPxComboBox ID="cbolocationto" SelectedIndex="0" ClientIDMode="Static" ClientInstanceName="cbolocationto" runat="server"
                                    ValueField="LocationID" TextField="LocationName" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo_new"
                                    TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="BuildingPlanName" Name="BuildingPlan" Width="50%" Caption="Gebäudeplan:" ToolTip="Gebäudeplan"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="50%" Caption="Standort:" ToolTip="Standort"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>--%>

                                <dx:ASPxComboBox ID="cbolocationto" CallbackPageSize="100000" ClientIDMode="Static" ClientInstanceName="cbolocationto" runat="server"
                                    ValueField="LocationID" TextField="LocationName" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo_new"
                                    TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	 LocationIndexChanged(s, e);
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="BuildingPlanName" Name="BuildingPlan" Width="50%" Caption="<%$ Resources:localizedText, building_NewP %>" ToolTip="Gebäudeplan"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="50%" Caption="<%$ Resources:localizedText, location_new %>" ToolTip="Standort"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>

                            </section>
                            <section class="secFivDvns">
                                <asp:Label ID="Label26" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblSecControlsTwobis"></asp:Label>
                                <%--<dx:ASPxComboBox ID="ASPxComboBox9" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo_new"></dx:ASPxComboBox>--%>

                                <%--  <dx:ASPxComboBox ID="cboBuildingTo" SelectedIndex="0" ValueField="BuildingID" TextField="BuildingName" runat="server" Theme="Office2003Blue"
                                    ValueType="System.String" CssClass="cboSecControlsTwo_new" DropDownWidth="480px" DropDownRows="10" TextFormatString="{1}"
                                    Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="50%" Caption="Standort:" ToolTip="Standort"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="BuildingName" Name="BuildingName" Width="50%" Caption="Gebaüde:" ToolTip="Gebaüde"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>--%>
                                <dx:ASPxComboBox ID="cboBuildingTo" CallbackPageSize="100000" SelectedIndex="0" ValueField="BuildingID" TextField="BuildingName" runat="server" Theme="Office2003Blue" CssClass="cboSecControlsTwo_new" DropDownWidth="480px" DropDownRows="10" TextFormatString="{1}"
                                    Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" OnCallback="cboBuildingTo_Callback" EnableCallbackMode="True">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	 BuildingsIndexChanged(s, e);
}"
                                        EndCallback="function(s, e) {
	EndCallbackBuildings(s, e);
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="50%" Caption="<%$ Resources:localizedText, location_new %>" ToolTip="Standort"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="BuildingName" Name="BuildingName" Width="50%" Caption="<%$ Resources:localizedText, building_NewP %>" ToolTip="Gebaüde"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>
                            </section>
                            <section class="secFivDvns">
                                <asp:Label ID="Label27" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblSecControlsTwobis"></asp:Label>
                                <%--<dx:ASPxComboBox ID="ASPxComboBox10" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo_new"></dx:ASPxComboBox>--%>

                                <%-- <dx:ASPxComboBox ID="cboLevelsTo" ValueField="LevelID" SelectedIndex="0" TextField="Level" runat="server" Theme="Office2003Blue" ValueType="System.String"
                                    CssClass="cboSecControlsTwo_new" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                                    TextFormatString="{2}">
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="32%" Caption="Standort:" ToolTip="Standort"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="BuildingName" Name="BuildingName" Width="32%" Caption="Gebaüde:" ToolTip="Gebaüde"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Level" Name="Level" Width="36%" Caption="Ebene:" ToolTip="Ebene"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>--%>

                                <dx:ASPxComboBox ID="cboLevelsTo" CallbackPageSize="100000" ValueField="LevelID" ClientInstanceName="cboLevelsTo" TextField="Level" runat="server" Theme="Office2003Blue" ValueType="System.String"
                                    CssClass="cboSecControlsTwo_new" SelectedIndex="0" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                                    TextFormatString="{2}" OnCallback="cboLevelsTo_Callback" EnableCallbackMode="True">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	 LevelsIndexChanged(s, e);
}"
                                        EndCallback="function(s, e) {
	EndCallbackFloors(s, e);
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="32%" Caption="<%$ Resources:localizedText, location_new %>" ToolTip="Standort"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="BuildingName" Name="BuildingName" Width="32%" Caption="<%$ Resources:localizedText, building_NewP %>" ToolTip="Gebaüde"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Level" Name="Level" Width="36%" Caption="<%$ Resources:localizedText, level_NewP %>" ToolTip="Ebene"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>

                            </section>
                            <section class="secFivDvns">
                                <asp:Label ID="Label28" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblSecControlsTwobis"></asp:Label>
                                <%--<dx:ASPxComboBox ID="ASPxComboBox11" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo_new"></dx:ASPxComboBox>--%>

                                <%-- <dx:ASPxComboBox ID="cboRoomsTo" ValueField="RoomID" TextField="Room" SelectedIndex="0" runat="server" Theme="Office2003Blue" ValueType="System.String"
                                    CssClass="cboSecControlsTwo_new" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                                    TextFormatString="{3}">
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="25%" Caption="Standort:" ToolTip="Standort"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="BuildingName" Name="BuildingName" Width="25%" Caption="Gebaüde:" ToolTip="Gebaüde"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Level" Name="Level" Width="25%" Caption="Ebene:" ToolTip="Ebene"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Room" Name="Room" Width="25%" Caption="Raum:" ToolTip="Raum"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>--%>

                                <dx:ASPxComboBox ID="cboRoomsTo" CallbackPageSize="100000" ValueField="RoomID" TextField="Room" runat="server" Theme="Office2003Blue"
                                    CssClass="cboSecControlsTwo_new" SelectedIndex="0" DropDownWidth="680px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                                    TextFormatString="{3}" OnCallback="cboRoomsTo_Callback" EnableCallbackMode="True">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	 RoomsIndexChanged(s, e);
}"
                                        EndCallback="function(s, e) {
	EndCallbackRooms(s, e);
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="25%" Caption="<%$ Resources:localizedText, location_new %>" ToolTip="Standort"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="BuildingName" Name="BuildingName" Width="25%" Caption="<%$ Resources:localizedText, building_NewP %>" ToolTip="Gebaüde"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Level" Name="Level" Width="25%" Caption="<%$ Resources:localizedText, level_NewP %>" ToolTip="Ebene"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Room" Name="Room" Width="25%" Caption="<%$ Resources:localizedText, room_new %>" ToolTip="Raum"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>


                            </section>
                            <section class="secFivDvns">
                                <asp:Label ID="Label29" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblSecControlsTwobis"></asp:Label>
                                <%--<dx:ASPxComboBox ID="ASPxComboBox12" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo_new"></dx:ASPxComboBox>--%>

                                <%--  <dx:ASPxComboBox ID="cboDoorTo" ValueField="DoorID" TextField="Door" SelectedIndex="0" runat="server" Theme="Office2003Blue" CssClass="cboSecControlsTwo_new"
                                    DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                                    TextFormatString="{4}">
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="20%" Caption="Standort:" ToolTip="Standort"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="BuildingName" Name="BuildingName" Width="20%" Caption="Gebaüde:" ToolTip="Gebaüde"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Level" Name="Level" Width="20%" Caption="Ebene:" ToolTip="Ebene"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Room" Name="Room" Width="20%" Caption="Raum:" ToolTip="Raum"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Door" Name="Door" Width="20%" Caption="Tür/Leser:" ToolTip="Tür/Leser"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>--%>

                                <dx:ASPxComboBox ID="cboDoorTo" CallbackPageSize="100000" ClientIDMode="Static" ClientInstanceName="cboDoorTo" ValueField="DoorID" TextField="Door" runat="server" Theme="Office2003Blue" CssClass="cboSecControlsTwo_new"
                                    DropDownWidth="680px" SelectedIndex="0" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                                    TextFormatString="{4}" OnCallback="cboDoorsTo_Callback" EnableCallbackMode="True">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	 DoorsIndexChanged(s, e);
}"
                                        EndCallback="function(s, e) {
	EndCallbackDoors(s, e);
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="LocationName" Name="LocationName" Width="20%" Caption="<%$ Resources:localizedText, location_new %>" ToolTip="Standort"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="BuildingName" Name="BuildingName" Width="20%" Caption="<%$ Resources:localizedText, building_NewP %>" ToolTip="Gebaüde"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Level" Name="Level" Width="20%" Caption="<%$ Resources:localizedText, level_NewP %>" ToolTip="Ebene"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Room" Name="Room" Width="20%" Caption="<%$ Resources:localizedText, room_new %>" ToolTip="Raum"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="Door" Name="Door" Width="20%" Caption="<%$ Resources:localizedText, doorReader_NewP %>" ToolTip="Tür/Leser"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>

                            </section>
                        </section>
                        <section class="secDvnThree">
                            <section class="secLeftHeaders">
                                <asp:Label ID="Label30" runat="server" Text="<%$ Resources:localizedText, location_new %>" CssClass="lblSecTwoControlstop"></asp:Label>
                                <asp:Label ID="Label31" runat="server" Text="<%$ Resources:localizedText, building_NewP %>" CssClass="lblSecTwoControlstop"></asp:Label>
                                <asp:Label ID="Label32" runat="server" Text="<%$ Resources:localizedText, level_NewP %>" CssClass="lblSecTwoControlstop"></asp:Label>
                                <asp:Label ID="Label33" runat="server" Text="<%$ Resources:localizedText, room_new %>" CssClass="lblSecTwoControlstop"></asp:Label>
                                <asp:Label ID="Label34" runat="server" Text="<%$ Resources:localizedText, doorReader_NewP %>" CssClass="lblSecTwoControlstop"></asp:Label>
                            </section>
                            <section class="secRightTable2">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClass">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkObjLocation" runat="server" /><label for='chkObjLocation'></label>
                                        </asp:TableCell>
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkReaderPersLoc" runat="server" /><label for='chkReaderPersLoc'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow CssClass="rowTwo">
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkObjBuilding" runat="server" /><label for='chkObjBuilding'></label>
                                        </asp:TableCell>
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkPersReaderBuiding" runat="server" /><label for='chkPersReaderBuiding'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkObjLevel" runat="server" /><label for='chkObjLevel'></label>
                                        </asp:TableCell>
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkPersReaderLevel" runat="server" /><label for='chkPersReaderLevel'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow CssClass="rowTwo">
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkObjRoom" runat="server" /><label for='chkObjRoom'></label>
                                        </asp:TableCell>
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkReaderRoom" runat="server" /><label for='chkReaderRoom'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkObjDoor" runat="server" /><label for='chkObjDoor'></label>
                                        </asp:TableCell>
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkReaderDoor" runat="server" /><label for='chkReaderDoor'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                        </section>
                    </section>
                    <section class="secTitle">
                        <asp:Label ID="Label57" runat="server" Text="<%$ Resources:localizedText, visitorsSelection %>" CssClass="lblTitle"></asp:Label>
                    </section>
                    <section class="secControlsThree">
                        <section class="secDvnOne">
                            <section class="SecControlsThreeDvns">
                                <asp:Label ID="Label35" runat="server" Text="<%$ Resources:localizedText, companyFromTitle %>" CssClass="lblSecControlsTwo"></asp:Label>
                                <%--<dx:ASPxComboBox ID="ASPxComboBox13" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo"></dx:ASPxComboBox>--%>

                                <dx:ASPxComboBox ID="cboClientName" CallbackPageSize="100000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ClientIDMode="Static" ClientInstanceName="cboClientName" runat="server" SelectedIndex="0" ValueField="ID" TextField="CompanyName" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {cboClientNamePersonal(s, e);}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" FieldName="CompanyNr" Width="20%" />
                                        <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, companynew %>" FieldName="CompanyName" Width="80%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                            </section>
                            <section class="SecControlsThreeDvns">
                                <asp:Label ID="Label36" runat="server" Text="<%$ Resources:localizedText, nameFrom %>" CssClass="lblSecControlsTwo"></asp:Label>
                                <%--<dx:ASPxComboBox ID="ASPxComboBox14" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo"></dx:ASPxComboBox>--%>

                                <dx:ASPxComboBox ID="cmbPersName" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="7" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" SelectedIndex="0" ValueField="VisitorID" TextField="Name" ClientIDMode="Static" ClientInstanceName="cmbPersName" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {cmbPersNamePersonal(s, e);}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="VisitorID" Name="ID:" ToolTip="" Width="20%" />
                                        <dx:ListBoxColumn FieldName="Name" Name="Name:" ToolTip="" Width="80%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                            </section>
                            <%--     <section class="SecControlsThreeDvns">
                                <asp:Label ID="Label37" runat="server" Text="Ausweis Nr. lang von:" CssClass="lblSecControlsTwo"></asp:Label>
                                <dx:ASPxComboBox ID="ASPxComboBox15" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo"></dx:ASPxComboBox>
                            </section>--%>
                            <section class="SecControlsThreeDvns">
                                <asp:Label ID="Label38" runat="server" Text="<%$ Resources:localizedText ,ShortTermCardFrom%>" CssClass="lblSecControlsTwo"></asp:Label>
                                <%--<dx:ASPxComboBox ID="ASPxComboBox16" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo"></dx:ASPxComboBox>--%>

                                <dx:ASPxComboBox ID="cboShortTransponder" ClientInstanceName="cboShortTransponder" SelectedIndex="0" ValueField="ID" TextField="TransponderNr" ClientIDMode="Static" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo" DropDownWidth="200px" DropDownRows="6" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {cboShortTransponderPersonal(s, e);}"></ClientSideEvents>
                                </dx:ASPxComboBox>
                            </section>
                            <%--      <section class="SecControlsThreeDvns">
                                <asp:Label ID="Label39" runat="server" Text="Name von:" CssClass="lblSecControlsTwo"></asp:Label>
                                <dx:ASPxComboBox ID="ASPxComboBox17" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo"></dx:ASPxComboBox>
                            </section>--%>
                            <%--  <section class="SecControlsThreeDvns">
                                <asp:Label ID="Label40" runat="server" Text="Ausweis Nr.lang von:" CssClass="lblSecControlsTwo"></asp:Label>
                                <dx:ASPxComboBox ID="ASPxComboBox18" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo"></dx:ASPxComboBox>
                            </section>--%>
                            <%--   <section class="SecControlsThreeDvns">
                                <asp:Label ID="Label41" runat="server" Text="Ausweis Nr.kurz von:" CssClass="lblSecControlsTwo"></asp:Label>
                                <dx:ASPxComboBox ID="ASPxComboBox19" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo"></dx:ASPxComboBox>
                            </section>--%>
                        </section>
                        <section class="secDvnTwo">
                            <section class="SecControlsThreeDvns">
                                <asp:Label ID="Label42" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblSecControlsTwobis"></asp:Label>
                                <%--<dx:ASPxComboBox ID="ASPxComboBox20" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo_new"></dx:ASPxComboBox>--%>

                                <%--<dx:ASPxComboBox ID="cboShortTransponderTo" SelectedIndex="0" ValueField="ID" TextField="TransponderNr" ClientIDMode="Static" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo_new" DropDownWidth="200px" DropDownRows="6" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"></dx:ASPxComboBox>--%>
                                <dx:ASPxComboBox ID="cboClientNameto" CallbackPageSize="100000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="10" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ValueField="ID" TextField="CompanyName" ClientIDMode="Static" ClientInstanceName="cboClientNameto" SelectedIndex="0" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo_new">
                                    <Columns>
                                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" FieldName="CompanyNr" Width="20%" />
                                        <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, companynew %>" FieldName="CompanyName" Width="80%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                            </section>
                            <section class="SecControlsThreeDvns">
                                <asp:Label ID="Label43" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblSecControlsTwobis"></asp:Label>
                                <%--<dx:ASPxComboBox ID="ASPxComboBox21" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo_new"></dx:ASPxComboBox>--%>

                                <dx:ASPxComboBox ID="cmbPersNameTo" CallbackPageSize="100000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="7" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ValueField="ID" TextField="Name" SelectedIndex="0" ClientIDMode="Static" ClientInstanceName="cmbPersNameTo" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo_new">
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="VisitorID" Name="ID:" ToolTip="" Width="20%" />
                                        <dx:ListBoxColumn FieldName="Name" Name="Name:" ToolTip="" Width="80%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                            </section>
                            <section class="SecControlsThreeDvns">
                                <asp:Label ID="Label44" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblSecControlsTwobis"></asp:Label>
                                <%--<dx:ASPxComboBox ID="ASPxComboBox22" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo_new"></dx:ASPxComboBox>--%>

                                <dx:ASPxComboBox ID="cboShortTransponderTo" SelectedIndex="0" ValueField="ID" TextField="TransponderNr" ClientIDMode="Static" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo_new" DropDownWidth="200px" DropDownRows="6" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"></dx:ASPxComboBox>

                            </section>
                            <%--   <section class="SecControlsThreeDvns">
                                <asp:Label ID="Label45" runat="server" Text="bis:" CssClass="lblSecControlsTwobis"></asp:Label>
                                <dx:ASPxComboBox ID="ASPxComboBox23" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo"></dx:ASPxComboBox>
                            </section>--%>
                            <%--     <section class="SecControlsThreeDvns">
                                <asp:Label ID="Label46" runat="server" Text="bis:" CssClass="lblSecControlsTwobis"></asp:Label>
                                <dx:ASPxComboBox ID="ASPxComboBox24" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo"></dx:ASPxComboBox>
                            </section>--%>
                            <%-- <section class="SecControlsThreeDvns">
                                <asp:Label ID="Label47" runat="server" Text="bis:" CssClass="lblSecControlsTwobis"></asp:Label>
                                <dx:ASPxComboBox ID="ASPxComboBox25" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo"></dx:ASPxComboBox>
                            </section>--%>
                            <%-- <section class="SecControlsThreeDvns">
                                <asp:Label ID="Label48" runat="server" Text="bis:" CssClass="lblSecControlsTwobis"></asp:Label>
                                <dx:ASPxComboBox ID="ASPxComboBox26" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cboSecControlsTwo"></dx:ASPxComboBox>
                            </section>--%>
                        </section>
                        <section class="secDvnThree">
                            <section class="secLeftHeaders">
                                <asp:Label ID="Label49" runat="server" Text="<%$ Resources:localizedText, CompanyTitle %>" CssClass="lblSecTwoControls"></asp:Label>
                                <asp:Label ID="Label50" runat="server" Text="Name:" CssClass="lblSecTwoControls"></asp:Label>
                                <%--         <asp:Label ID="Label51" runat="server" Text="Abteilung:" CssClass="lblSecTwoControls"></asp:Label>
                                <asp:Label ID="Label52" runat="server" Text="Kostenstelle:" CssClass="lblSecTwoControls"></asp:Label>
                                <asp:Label ID="Label53" runat="server" Text="Name:" CssClass="lblSecTwoControls"></asp:Label>--%>
                                <%--     <asp:Label ID="Label54" runat="server" Text="Ausweis Nr.lang:" CssClass="lblSecTwoControls"></asp:Label>--%>
                                <asp:Label ID="Label55" runat="server" Text="<%$ Resources:localizedText ,shortTermCardNr%>" CssClass="lblSecTwoControls"></asp:Label>
                            </section>
                            <section class="secRightTable3">
                                <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClass">
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkObjStudioGroup" runat="server" /><label for='chkObjStudioGroup'></label>
                                        </asp:TableCell>
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkPersStudioGroup" runat="server" /><label for='chkPersStudioGroup'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow CssClass="rowTwo">
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkObjPersName" runat="server" /><label for='chkObjPersName'></label>
                                        </asp:TableCell>
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkPersonalPersName" runat="server" /><label for='chkPersonalPersName'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow CssClass="rowOne">
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkObjShortTermCard" runat="server" /><label for='chkObjShortTermCard'></label>
                                        </asp:TableCell>
                                        <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="chkPersShortTermCard" runat="server" /><label for='chkPersShortTermCard'></label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow CssClass="rowTwo">
                                        <%--       <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="CheckBox28" runat="server" CssClass="chkTable" />
                                        </asp:TableCell>--%>
                                        <%--   <asp:TableCell CssClass="tblCell">
                                            <asp:CheckBox ID="CheckBox29" runat="server" CssClass="chkTable" />
                                        </asp:TableCell>--%>
                                    </asp:TableRow>
                                    <asp:TableRow CssClass="rowOne">
                                        <%--       <asp:TableCell CssClass="tblCell"></asp:TableCell>
                                        <asp:TableCell CssClass="tblCell"></asp:TableCell>--%>
                                    </asp:TableRow>
                                    <asp:TableRow CssClass="rowOne">
                                        <%--   <asp:TableCell CssClass="tblCell"></asp:TableCell>
                                        <asp:TableCell CssClass="tblCell"></asp:TableCell>--%>
                                    </asp:TableRow>
                                    <asp:TableRow CssClass="rowTwo">
                                        <%--          <asp:TableCell CssClass="tblCell"></asp:TableCell>--%>
                                        <%--      <asp:TableCell CssClass="tblCell"></asp:TableCell>--%>
                                    </asp:TableRow>
                                </asp:Table>
                            </section>
                        </section>
                    </section>
                </section>
                <section class="secRightGrid">
                    <section class="secHeader" style="display: none">
                        <%--<asp:Label ID="Label10" runat="server" Text="Nr.:" CssClass="lblgrdNr"></asp:Label>
                        <asp:Label ID="Label11" runat="server" Text="Bezeichnung:" CssClass="lblgrdDesc"></asp:Label>--%>
                    </section>
                    <section class="secGrid">
                        <%--<dx:ASPxGridView ID="grdReport" runat="server" ClientInstanceName="grdReport" Styles-Header-BackColor="White" Theme="Default" AutoGenerateColumns="False" Width="100%">
                            <SettingsPager PageSize="17" ShowEmptyDataRows="true" Visible="False"></SettingsPager>
                            <SettingsBehavior AllowSort="false" />
                            <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="1" Width="12%" Caption="Nr.:"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="2" Width="88%" Caption="Bezeichnung:"></dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>--%>

                        <dx:ASPxGridView ID="grdReport" ClientIDMode="Static" ClientInstanceName="grdReport" runat="server" KeyFieldName="ID" Styles-Header-BackColor="White" Theme="Default" AutoGenerateColumns="False" Width="100%" OnCustomCallback="grdReport_CustomCallback">
                            <SettingsPager PageSize="19" ShowEmptyDataRows="true" Visible="False"></SettingsPager>
                            <SettingsBehavior AllowSort="false" AllowFocusedRow="True" />
                            <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                            <ClientSideEvents RowClick="function(s, e) {
SetVisibleIndex(s, e);
grdReportRowClick(s,e);
}" />
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Nr.:" Width="12%" FieldName="Nr"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="2" Caption="<%$ Resources:localizedText, description_newP %>" Width="88%" FieldName="Name"></dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                    </section>

                </section>
            </div>
        </div>
    </div>
    <section class="showReports" style="display: none">
        <section class="mainBodyTop">
            <section class="mainBodyTop1 ">
                <section class="mainBodyTop1left">
                    <section class="mainBodyTop1leftlbl">
                        <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText, locationFrom_new %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label11" runat="server" Text="<%$ Resources:localizedText, buildingFrom %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label37" runat="server" Text="<%$ Resources:localizedText, companyFromTitle %>" CssClass="lblreport"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">
                        <asp:TextBox ID="txtLocFrom" runat="server" CssClass="drpreport"></asp:TextBox>
                        <asp:TextBox ID="txtBuildingFrom" runat="server" CssClass="drpreport"></asp:TextBox>
                        <asp:TextBox ID="txtClientFrom" runat="server" CssClass="drpreport"></asp:TextBox>
                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label39" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label65" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label66" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp4New">
                        <asp:TextBox ID="txtLocTo" runat="server" CssClass="drpreportnew"></asp:TextBox>
                        <asp:TextBox ID="txtBuildingTo" runat="server" CssClass="drpreportnew"></asp:TextBox>
                        <asp:TextBox ID="txtClientTo" runat="server" CssClass="drpreportnew"></asp:TextBox>
                    </section>
                </section>
                <section class="mainBodyTop1left3">
                    <section class="selectionOne">
                        <section class="topRight1">
                            <asp:Label ID="Label67" runat="server" Text="<%$ Resources:localizedText, date2 %>" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label68" runat="server" Text="<%$ Resources:localizedText, fromTitle %>" CssClass="lblDtFromTitle"></asp:Label>
                            <asp:TextBox ID="txtDateFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>
                            <asp:Label ID="Label69" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblDateToTitle"></asp:Label>
                            <asp:TextBox ID="txtDateTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>
                        </section>
                        <section class="topRight2">
                            <asp:Label ID="Label70" runat="server" Text="<%$ Resources:localizedText, SelectionType %>" CssClass="lblPrintMode"></asp:Label>
                            <asp:Label ID="lblReportType" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>
                        </section>
                        <section class="topRight3">
                            <asp:Label ID="Label71" runat="server" Text="<%$ Resources:localizedText, object_new %>" CssClass="lblPrintModeobj"></asp:Label>
                        </section>
                    </section>
                    <section class="selectionTwo">
                        <section class="topRight1">
                            <asp:Label ID="Label74" runat="server" Text="<%$ Resources:localizedText, time %>" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label76" runat="server" Text="<%$ Resources:localizedText, fromTitle %>" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="txtTimeFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label77" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>
                        </section>
                        <section class="topRight2">
                            <asp:Label ID="lbl" runat="server" Text="<%$ Resources:localizedText, selectedTimeRange %>" CssClass="lblPrintMode"></asp:Label>
                            <asp:Label ID="lblTimePrintType" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>
                        </section>
                        <section class="topRight3">
                        </section>
                    </section>
                    <section class="selectionThree">
                        <section class="topRight1">
                            <asp:Label ID="Label72" runat="server" Text="<%$ Resources:localizedText, printedOn %>" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtPrintDate" runat="server" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label73" runat="server" Text="<%$ Resources:localizedText, time_newP %>" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtPrintTime" runat="server" CssClass="txtDispDateTo"></asp:TextBox>
                        </section>
                        <section class="topRight2">
                            <section class="loggedInUser">
                                <asp:Label ID="Label75" runat="server" Text="<%$ Resources:localizedText, createdBy %>" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblPersName" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>
                        </section>
                        <section class="topRight3perpekind">
                            <section class="secholdingarea1_new">
                                <asp:Label ID="Label99" runat="server" Text="<%$ Resources:localizedText, potrait %>" CssClass="txtportrait"></asp:Label>
                                <asp:ImageButton ID="imgPotrait" runat="server" CssClass="btnorientation1" Style="cursor: default;" />
                                <asp:CheckBox ID="chkPortrait" runat="server" CssClass="chk1controllast" />
                            </section>
                            <section class="secholdingarea1b_new">
                                <asp:Label ID="Label100" runat="server" Text="<%$ Resources:localizedText, landScape %>" CssClass="txtlandscape_new"></asp:Label>
                                <asp:ImageButton ID="imgLand" runat="server" CssClass="btnorientation2" Style="cursor: default;" />
                                <asp:CheckBox ID="chkLandScape" runat="server" CssClass="chk1controllast" />

                            </section>
                        </section>

                    </section>
                </section>
            </section>
        </section>
        <section class="mainBodybtm">
            <dx:ASPxGridView ID="grdShoewReport" runat="server" ClientIDMode="Static" ClientInstanceName="grdShoewReport" Theme="Office2003Blue" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdShoewReport_CustomCallback">

                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, location_new %>" Visible="False" VisibleIndex="1" FieldName="BPLocation"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, building_NewP %>" Visible="False" VisibleIndex="2" FieldName="BPBuilding"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, level_NewP %>" Visible="False" VisibleIndex="3" FieldName="BPLevel"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, room_new %>" Visible="False" VisibleIndex="4" FieldName="BPRoom"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, doorReader_NewP %>" VisibleIndex="5" FieldName="BPDoor"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="BookingDate" Caption="<%$ Resources:localizedText, date_new %>" VisibleIndex="6">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTimeEditColumn FieldName="BookingTime" Caption="<%$ Resources:localizedText, time_newP %>" VisibleIndex="7">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesTimeEdit DisplayFormatString="HH:mm" EditFormat="Time" EditFormatString="HH:mm" Height="25px"></PropertiesTimeEdit>
                    </dx:GridViewDataTimeEditColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, CompanyTitle %>" Visible="False" VisibleIndex="8" FieldName="PersClient"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Name:" VisibleIndex="9" Visible="false" FieldName="Name"></dx:GridViewDataTextColumn>
                    <%-- <dx:GridViewDataTextColumn Caption="Ausweis Nr.lang " Visible="true" VisibleIndex="10" FieldName="CardNumber"></dx:GridViewDataTextColumn>--%>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, shortTermCardNr %>  " VisibleIndex="10" FieldName="CardNumbershort"></dx:GridViewDataTextColumn>

                </Columns>
            </dx:ASPxGridView>
        </section>
    </section>
    <div class="showReportsDocViewer" style="display: none;">
        <dx:ASPxCallbackPanel ID="OneTodayCallbackPanel" runat="server" OnCallback="OneTodayCallbackPanel_Callback">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <dx:ASPxWebDocumentViewer ID="VisitorLocalASPxDocumentViewer" Style="width: 100%; height: 1100px;" ClientIDMode="Static" ClientInstanceName="VisitorLocalASPxDocumentViewer" runat="server" Theme="Office2003Blue">
                    </dx:ASPxWebDocumentViewer>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
    </div>
    <section class="showReportsPersonal" style="display: none">
        <section class="mainBodyTop">
            <section class="mainBodyTop1 ">
                <section class="mainBodyTop1left">
                    <section class="mainBodyTop1leftlbl">
                        <asp:Label ID="Label78" runat="server" Text="<%$ Resources:localizedText, locationFrom_new %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label79" runat="server" Text="<%$ Resources:localizedText, buildingFrom %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label80" runat="server" Text="<%$ Resources:localizedText, companyFromTitle %>" CssClass="lblreport"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="txtLocationFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtDisplayBuildingFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtDisplayClientFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label81" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label82" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label83" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp4New">

                        <asp:TextBox ID="txtLocationTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtblngTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtCliento" runat="server" CssClass="drpreportnew"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left3">
                    <section class="selectionOne">
                        <section class="topRight1">
                            <asp:Label ID="Label84" runat="server" Text="<%$ Resources:localizedText, date2 %>" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label85" runat="server" Text="<%$ Resources:localizedText, fromTitle %>" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="txtDisplayDateFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label86" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtDisplayDateTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight2">
                            <asp:Label ID="Label87" runat="server" Text="<%$ Resources:localizedText, SelectionType %>" CssClass="lblPrintMode"></asp:Label>
                            <asp:Label ID="Label88" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>
                        </section>
                        <section class="topRight3">
                            <asp:Label ID="Label89" runat="server" Text="<%$ Resources:localizedText, persons %>" CssClass="lblPrintModeobj"></asp:Label>
                        </section>
                    </section>
                    <section class="selectionTwo">
                        <section class="topRight1">
                            <asp:Label ID="Label90" runat="server" Text="<%$ Resources:localizedText, time %>" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label91" runat="server" Text="<%$ Resources:localizedText, fromTitle %>" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="TxtDisplayFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label92" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtDisplayTimeTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>
                        </section>
                        <section class="topRight2">
                            <asp:Label ID="Label93" runat="server" Text="<%$ Resources:localizedText, selectedTimeRange %>" CssClass="lblPrintMode"></asp:Label>
                            <asp:Label ID="lblDisplaySelection" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>
                        </section>
                        <section class="topRight3">
                        </section>
                    </section>
                    <section class="selectionThree">
                        <section class="topRight1">
                            <asp:Label ID="Label95" runat="server" Text="<%$ Resources:localizedText, printedOn %>"  CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtdateTime" runat="server"  CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label96" runat="server" Text="<%$ Resources:localizedText, time_newP %>"  CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtTime" runat="server"  CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight2">
                            <section class="loggedInUser">
                                <asp:Label ID="Label97" runat="server" Text="<%$ Resources:localizedText, createdBy %>" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblLoggedInUser" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>
                        </section>
                        <section class="topRight3perpekind">
                            <section class="secholdingarea1_new">
                                <asp:Label ID="Label94" runat="server" Text="<%$ Resources:localizedText, potrait %>" CssClass="txtportrait"></asp:Label>
                                <asp:ImageButton ID="imgPotraiB" runat="server" CssClass="btnorientation1" Style="cursor: default;" />
                                <asp:CheckBox ID="chKPersonalPotraint" runat="server" CssClass="chk1controllast" />

                            </section>
                            <section class="secholdingarea1b_new">
                                <asp:Label ID="Label40" runat="server" Text="<%$ Resources:localizedText, landScape %>" CssClass="txtlandscape_new"></asp:Label>
                                <asp:ImageButton ID="imgLandB" runat="server" CssClass="btnorientation2" Style="cursor: default;" />
                                <asp:CheckBox ID="chkPersonalLand" runat="server" CssClass="chk1controllast" />

                            </section>
                        </section>

                    </section>
                </section>
            </section>
        </section>
        <section class="mainBodybtm">
            <dx:ASPxGridView ID="grdPersonalAccessReport" runat="server" Theme="Office2003Blue" ClientInstanceName="grdPersonalAccessReport" AutoGenerateColumns="False" SettingsPager-PageSize="13" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdPersonalAccessReport_CustomCallback">

                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, CompanyTitle %>" VisibleIndex="1" FieldName="PersClient"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Name" VisibleIndex="2" FieldName="Name"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, shortTermCardNr %>" VisibleIndex="3" FieldName="CardNumbershort"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="BookingDate" Caption="<%$ Resources:localizedText, date_new %>" VisibleIndex="4">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTimeEditColumn FieldName="BookingTime" Caption="<%$ Resources:localizedText, time_newP %>" VisibleIndex="5">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesTimeEdit DisplayFormatString="HH:mm" EditFormat="Time" EditFormatString="HH:mm" Height="25px"></PropertiesTimeEdit>
                    </dx:GridViewDataTimeEditColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, location_new %>" VisibleIndex="6" FieldName="BPLocation"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, building_NewP %>" VisibleIndex="7" FieldName="BPBuilding"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, level_NewP %>" FieldName="BPLevel"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, room_new %>" VisibleIndex="9" FieldName="BPRoom"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, doorReader_NewP %>" VisibleIndex="10" FieldName="BPDoor"></dx:GridViewDataTextColumn>

                </Columns>
            </dx:ASPxGridView>
        </section>
    </section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnNew" CssClass="newProtocol" runat="server" Text="<%$ Resources:localizedText, newAccessProtocol %>" />
    <asp:Button ID="btnEntSave" CssClass="saveProtocol" runat="server" Text="<%$ Resources:localizedText, saveAccessProtocol %>" />
    <asp:Button ID="btnCancelDel" CssClass="deleteProtocol" runat="server" Text="<%$ Resources:localizedText, deleteAccessProtocol %>" />
    <asp:Button ID="btnPrintReport" CssClass="btnPrintReport" runat="server" Text="<%$ Resources:localizedText, printAccessProtocol %>" Style="display: none" />
    <asp:Button ID="btnPrintSelection" ClientIDMode="Static" runat="server" CssClass="btnPrintReport setHover" Text="<%$ Resources:localizedText, printSelection_title %>" Style="width: 106px;" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" ClientIDMode="Static" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
