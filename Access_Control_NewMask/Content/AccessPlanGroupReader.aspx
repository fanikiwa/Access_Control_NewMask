<%@ Page Title="<%$ Resources:localizedText, accessgroupgraphics %>" Language="C#" MasterPageFile="~/MasterPages/AccessPlanGroup.Master" AutoEventWireup="true" CodeBehind="AccessPlanGroupReader.aspx.cs" Inherits="Access_Control_NewMask.Content.AccessPlanGroupReader" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/go.js" type="text/javascript"></script>
    <script src="Scripts/AccessPlanGroupReaderDiagram.js"></script>
    <script src="Scripts/DiagramsCustomFunctions.js" type="text/javascript"></script>
    <script src="Scripts/AccessPlanGroupReader.js?v=<%= Access_Control_NewMask.Controllers.Version.JSVersion %>"></script>
    <link href="Styles/AccessPlanGroupReader.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">
    <div id="ControlSection1" class="ControlSection" style="min-height: 74px; height: 8%; background-color: #E5E5E5;">

        <div class="secsidenav">
            <asp:Label ID="Label8" runat="server" Text="<%$ Resources:localizedText, siteselection %>" CssClass="Lblarealocation"></asp:Label>
            <dx:ASPxComboBox ID="cobBuildingPlanLocation" ClientInstanceName="cobBuildingPlanLocation" DropDownWidth="400px" DropDownRows="20" ValueField="ID" TextField="LocationName" TextFormatString="{1}" runat="server" CssClass="L1Headerlocation" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" Theme="Office2003Blue">
                <ClientSideEvents SelectedIndexChanged="function(s, e) {
locationSelectedChanged(s,e);	
}"></ClientSideEvents>
                <Columns>
                    <dx:ListBoxColumn Caption="Nr:" Name="Nr" FieldName="Nr" Width="15%" />
                    <dx:ListBoxColumn Caption="Standort" Name="LocationName" FieldName="LocationName" Width="85%" />
                </Columns>
            </dx:ASPxComboBox>
        </div>

        <div class="areamaindrpdwn">
            <div class="top" style="width: 100%; height: 49%; background-color: #E5E5E5; float: left; clear: none;">

                <section class="lefttop" style="width: 50%; height: 100%; float: left;">
                    <asp:Label ID="lblPlanNr" runat="server" Text="<%$ Resources:localizedText, accessgroupno %>" CssClass="L1HeaderT1drplables"></asp:Label>

                    <dx:ASPxComboBox ID="cobAccessGroupNr" ClientInstanceName="cobAccessGroupNr" runat="server" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextField="AccessPlanGroupNr" ValueField="ID" TextFormatString="{0}" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue">
                        <Columns>
                            <dx:ListBoxColumn Caption="Nr:" Name="AccessPlanGroupNr" FieldName="AccessPlanGroupNr" Width="10%" />
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, description1 %>" Name="AccessPlanGroupName" FieldName="AccessPlanGroupName" Width="90%" />
                        </Columns>
                    </dx:ASPxComboBox>

                    <asp:Label ID="lblPlanName" runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="L1HeaderT1drplables"></asp:Label>

                    <dx:ASPxComboBox ID="cobAccessGroupName" ClientInstanceName="cobAccessGroupName" CssClass="L1HeaderT1drplistsSd" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextField="AccessPlanGroupName" ValueField="ID" TextFormatString="{1}" DropDownRows="20" DropDownWidth="400px" runat="server" Theme="Office2003Blue">

                        <Columns>
                            <dx:ListBoxColumn Caption="Nr:" Name="AccessPlanGroupNr" FieldName="AccessPlanGroupNr" Width="10%" />
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, description1 %>" Name="AccessPlanGroupName" FieldName="AccessPlanGroupName" Width="90%" />
                        </Columns>
                    </dx:ASPxComboBox>

                </section>
                <section class="righttop" style="text-align: right; height: 100%; float: right;">
                    <%--<asp:Button ID="btnFullScreenMode" runat="server" Text="<%$ Resources:LocalizedText, fullScreen %>" CssClass="midlevelrightsection"></asp:Button>--%>
                </section>

            </div>




            <div class="bottom" style="width: 100%; height: 49%; background: #E5E5E5; background: rgba(229, 229, 229, 1); float: left; clear: none;">

                <section class="leftbottom" style="width: 50%; height: 100%; float: left;">

                    <asp:Label ID="lblPlanNr2" runat="server" Text="<%$ Resources:localizedText, accessgroupno %>" CssClass="L1HeaderT1drplables"></asp:Label>
                    <asp:TextBox ID="txtAccessGroupNr" runat="server" CssClass="L1HeaderT1txbox" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                    </asp:TextBox>
                    <asp:Label ID="lblPlanName2" runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="L1HeaderT1drplables" Style="margin-left: 6px;"></asp:Label>
                    <asp:TextBox ID="txtAccessGroupName" runat="server" CssClass="L1HeaderT1txboxsd" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                    </asp:TextBox>

                </section>
                <section class="rightbottom" style="height: 75%; margin-top: 5px; float: left;">
                    <asp:ImageButton ID="btnZoomOut" ImageUrl="~/Images/FormImages/zoom20-02.png" runat="server" />
                    <asp:ImageButton ID="btnZoomIn" ImageUrl="~/Images/FormImages/zoom10-01.png" runat="server" />
                </section>
                <section class="standontarea">
                    <section class="arealeft">
                        <asp:Label runat="server" Text="<%$ Resources:localizedText, hidefrom %>" class="lbllocation" Style="margin-right: 2%;"></asp:Label><asp:Label runat="server" Text="<%$ Resources:localizedText, hidefromlocation2 %>" class="lbllocation" Style="font-weight: bold;"></asp:Label>
                        <asp:CheckBox runat="server" ClientIDMode="Static" ID="chkHideLocation" class="chklocation"></asp:CheckBox>
                    </section>
                    <section class="arearight">
                        <asp:Label runat="server" Text="<%$ Resources:localizedText, Buildingloc %>" class="lbllocation2"></asp:Label>
                        <asp:Label runat="server" Text="<%$ Resources:localizedText, Buildinglocationhide2 %>" class="lbllocation2" Style="font-weight: bold;"></asp:Label><asp:CheckBox runat="server" ClientIDMode="Static" ID="chkHideLocBuilding" class="chklocation2"></asp:CheckBox>
                    </section>
                </section>
            </div>


        </div>
        <%--hide this with grid table--%>

        <div class="areatbl">
            <asp:Label ID="LblTable" runat="server" Text="<%$ Resources:localizedText, table %>" CssClass="Lblareatable"></asp:Label>
            <asp:Label ID="LblGrafik" runat="server" Text="<%$ Resources:localizedText, graphic %>" CssClass="Lblareagrafik"></asp:Label>
            <asp:Button ID="btnShowGrid" runat="server" Text="" CssClass="btnShowBuildingGrid" />
            <asp:Button ID="btnShowDiagram" runat="server" Text="" CssClass="btnShowbBuildingDiagram" />
        </div>
        <%--hide this with grid table--%>

        <div style="display: none;">
            <div class="accessplantbl">
                <div class="top" style="width: 100%; height: 49%; background-color: #E5E5E5; float: left; clear: none;">

                    <section class="lefttop" style="width: 73%; height: 100%; float: left;">
                        <asp:Label ID="Label12" runat="server" Text="Leser-Gruppen Nr.:" CssClass="L1Header2"></asp:Label>
                        <dx:ASPxComboBox ID="ASPxComboBox4" ClientInstanceName="dpllPlanNr" EnableCallbackMode="true" runat="server" CssClass="L1T1drplists2" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextField="PlanNr" ValueField="ID" TextFormatString="{0}" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue">
                        </dx:ASPxComboBox>

                        <asp:Label ID="Label13" runat="server" Text="Leser-Gruppen Bezeichnung:" CssClass="L1T1drplables2"></asp:Label>

                        <dx:ASPxComboBox ID="ASPxComboBox5" ClientInstanceName="dplPlanName" EnableCallbackMode="true" CssClass="L1T1drplists2new" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextField="PlanName" ValueField="ID" TextFormatString="{1}" DropDownRows="20" DropDownWidth="400px" runat="server" Theme="Office2003Blue">
                        </dx:ASPxComboBox>
                    </section>
                </div>

                <div class="bottom" style="width: 100%; height: 49%; background: #E5E5E5; background: rgba(229, 229, 229, 1); float: left; clear: none;">

                    <section class="leftbottom" style="width: 73%; height: 100%; float: left;">

                        <asp:Label ID="Label14" runat="server" Text="Leser-Gruppen Nr.:" CssClass="L1Header2"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="txtL1T1drplists2" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                        </asp:TextBox>
                        <asp:Label ID="Label15" runat="server" Text="Leser-Gruppen Bezeichnung:" CssClass="L1T1drplables2"></asp:Label>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="L1T1drplistsSd2" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                        </asp:TextBox>
                    </section>
                </div>
            </div>


        </div>

    </div>


    <div id="buildingPLan" class="pageonly">

        <div id="BuildingAreaDivNav" class="secBuildingplanNav">
            <div id="BuildingAreaNav" class="BuildingAreaNav"></div>

        </div>

        <div id="BuildingAreaDiv" class="secBuildingplan">
        </div>
        <div id="BuildingGridArea" class="secBuildingplanGird">
            <div id="BuildingGridHolder">
                <dx:ASPxGridView ID="grdBuildingPlanGrid" ClientInstanceName="grdBuildingPlanGrid" runat="server" AutoGenerateColumns="False" EnableTheming="True" Width="100%"
                    KeyFieldName="DoorID" OnCustomCallback="grdBuildingPlanGrid_CustomCallback" OnHtmlDataCellPrepared="grdBuildingPlanGrid_HtmlDataCellPrepared">
                    <SettingsEditing Mode="Batch" NewItemRowPosition="Bottom" EditFormColumnCount="6">
                        <BatchEditSettings ShowConfirmOnLosingChanges="False" EditMode="Cell" StartEditAction="Click" />
                    </SettingsEditing>
                    <Settings ShowStatusBar="Hidden" />
                    <SettingsBehavior AllowDragDrop="False" AllowGroup="False" AllowSort="False" />
                    <SettingsDataSecurity AllowInsert="False" />
                    <ClientSideEvents EndCallback="function (s, e) {
                        colorGrid();
}" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" FieldName="RoomID" ReadOnly="true" Visible="false"
                            HeaderStyle-BackColor="#aecaf0" HeaderStyle-ForeColor="#000000">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, location1 %>" VisibleIndex="1" FieldName="LocationName" ReadOnly="true"
                            HeaderStyle-BackColor="#aecaf0" HeaderStyle-ForeColor="#000000">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, building2 %>" VisibleIndex="2" FieldName="BuildingName" ReadOnly="true"
                            HeaderStyle-BackColor="#aecaf0" HeaderStyle-ForeColor="#000000">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, floor2 %>" VisibleIndex="3" FieldName="Level" ReadOnly="true"
                            HeaderStyle-BackColor="#aecaf0" HeaderStyle-ForeColor="#000000">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, room2 %>" VisibleIndex="4" FieldName="Room" ReadOnly="true"
                            HeaderStyle-BackColor="#aecaf0" HeaderStyle-ForeColor="#000000">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, doororreader %>" VisibleIndex="5" FieldName="Door" ReadOnly="true"
                            HeaderStyle-BackColor="#aecaf0" HeaderStyle-ForeColor="#000000">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, direction %>" VisibleIndex="6" FieldName="DirectionName" ReadOnly="true"
                            HeaderStyle-BackColor="#aecaf0" HeaderStyle-ForeColor="#000000">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                            <%--<DataItemTemplate>
                                <dx:ASPxLabel ID="lblDirection" runat="server"
                                    ForeColor='<%# Convert.ToInt32(Eval("Direction")) == 0 ? 
                                        System.Drawing.Color.Green :   Convert.ToInt32(Eval("Direction")) == 1 ? System.Drawing.Color.Red : System.Drawing.Color.Black  %>'
                                    Text='<%# Convert.ToInt32(Eval("Direction")) == 0 ? "Eingang" :  Convert.ToInt32(Eval("Direction")) == 1 ? "Ausgang" : ""  %>'>
                                </dx:ASPxLabel>
                            </DataItemTemplate>
                            <EditItemTemplate>
                                <dx:ASPxLabel ID="lblDirectionE" runat="server"
                                    ForeColor='<%# Convert.ToInt32(Eval("Direction")) == 0 ? 
                                        System.Drawing.Color.Green :   Convert.ToInt32(Eval("Direction")) == 1 ? System.Drawing.Color.Red : System.Drawing.Color.Black  %>'
                                    Text='<%# Convert.ToInt32(Eval("Direction")) == 0 ? "Eingang" :  Convert.ToInt32(Eval("Direction")) == 1 ? "Ausgang" : ""  %>'>
                                </dx:ASPxLabel>
                            </EditItemTemplate>--%>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataCheckColumn Caption=" " VisibleIndex="7" FieldName="DoorSelected"
                            HeaderStyle-BackColor="#aecaf0" HeaderStyle-ForeColor="#000000" Width="2%">
                            <%--<DataItemTemplate>
                                <dx:ASPxLabel ID="lblDoorSelected" runat="server" Text=""
                                    Visible='<%# Convert.ToInt32(Eval("DoorKey")) > 0 ? false: true %>' />
                                <dx:ASPxCheckBox ID="chkDoorSelected" CssClass="chkDoorSelector" runat="server"
                                    Checked='<%# Convert.ToBoolean(Eval("DoorSelected")) %>'
                                    Visible='<%# Convert.ToInt32(Eval("DoorKey")) > 0 ? true: false %>'>
                                </dx:ASPxCheckBox>
                            </DataItemTemplate>--%>
                            <%--<EditItemTemplate>
                                <dx:ASPxLabel ID="lblDoorSelectedE" runat="server" Text=""
                                    Visible='<%# Convert.ToInt32(Eval("DoorKey")) > 0 ? false: true %>' />
                                <dx:ASPxCheckBox ID="chkDoorSelectedE" CssClass="chkDoorSelector" runat="server"
                                    Checked='<%# Convert.ToBoolean(Eval("DoorSelected")) %>'
                                    Visible='<%# Convert.ToInt32(Eval("DoorKey")) > 0 ? true: false %>'>
                                </dx:ASPxCheckBox>
                            </EditItemTemplate>--%>
                        </dx:GridViewDataCheckColumn>
                    </Columns>

                    <SettingsPager PageSize="32" ShowEmptyDataRows="True" Visible="False">
                    </SettingsPager>
                </dx:ASPxGridView>
            </div>
        </div>
        <div id="confirmDelete" class="dialogBox">
        </div>
        <div id="importantDialog" class="dialogBox">
        </div>
    </div>

    <div id="contextMenu">
        <%--  <ul>

                <li id="entriesMenu" class="contextListTitle">
                    <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText, entries %>"></asp:Label></li>
                <li id="entriesLine">
                    <hr />
                </li>
                <li id="readerMenu" class="contextList"><a href="#" id="terminalAssignment" class="contextList" onclick="cxcommandTerminalAssignment()"></a></li>
                <li id="readerLine">
                    <hr />
                </li>
                <li id="readerActiveMenu">
                    <asp:CheckBox ID="chkTerminal" CssClass="contextList" TextAlign="Left" Text="<%$ Resources:localizedText, readerActive %>" runat="server" ClientIDMode="Static" /></li>
                <li id="readerActiveLine">
                    <hr />
                </li>
                <li id="newBuilding" class="contextList"><a href="#" id="building" class="contextList" onclick="AddNewChildNode()"></a></li>
                <li id="buildingLine">
                    <hr />
                </li>
                <li id="newFloor" class="contextList"><a href="#" id="floor" class="contextList" onclick="AddNewChildNode()"></a></li>
                <li id="floorLine">
                    <hr />
                </li>
                <li id="newRoom" class="contextList"><a href="#" id="room" class="contextList" onclick="AddNewChildNode()"></a></li>
                <li id="roomLine">
                    <hr />
                </li>
                <li id="newDoor" class="contextList"><a href="#" id="door" class="contextList" onclick="AddNewChildNode()"></a></li>
                <li id="doorLine">
                    <hr />
                </li>
                <li id="closeMenu"><a href="#" id="conclude" class="contextList" onclick="CloseMenu()"></a></li>
                <li id="closeLine">
                    <hr />
                </li>
                <li id="deleteMenu"><a href="#" id="delete" class="contextListDelete" onclick=" cxcommandDelete()"></a></li>
                <li id="deleteLine">
                    <hr />
                </li>
                <li id="lblInfo" class="contextListTitle">
                    <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText, information %>"></asp:Label></li>
                <li id="infoLine">
                    <hr />
                </li>
                <li id="terminalMenu"><a href="#" id="terminalInfo" class="contextList" onclick="cxcommandTerminalInfo()"></a></li>

            </ul>--%>
    </div>

    <%--<div id="txtEdit" style="visibility:hidden" >--%>
    <div id="hiddenControls" style="visibility: hidden">
        <%--  <div id="hiddenControls">--%>


        <asp:TextBox ID="txtEditor" ClientIDMode="Static" Font-Size="12px" Width="130px" MaxLength="18" runat="server" CssClass="txtEditHidden"></asp:TextBox>
        <asp:TextBox ID="txtEditorDoor" ClientIDMode="Static" Font-Size="12px" Width="100px" MaxLength="15" runat="server" CssClass="txtEditHidden"></asp:TextBox>
        <dx:ASPxGridView ID="BuildingPlanDetais" ClientInstanceName="BuildingPlanDetais" runat="server" CssClass="divHiddenGrid">

            <Columns>
                <dx:GridViewDataTextColumn Caption="LocationID" FieldName="LocationID" VisibleIndex="0"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="BuildingID" FieldName="BuildingID" VisibleIndex="1"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="FloorID" VisibleIndex="2" FieldName="FloorID"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="RoomID" VisibleIndex="3" FieldName="RoomID"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="DoorID" VisibleIndex="4" FieldName="DoorID"></dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>


    </div>
    <%--  gridview section--%>

    <div id="terminalDIV" class="contentdiv" style="display: none">

        <div class="contentdivtop">
            <asp:Label ID="Label1" runat="server" Text="Terminal ID" CssClass="L1HeaderT1drplables2"></asp:Label>
            <dx:ASPxComboBox ID="ddlTerminalId" ValueField="TerminalID" TextField="TermID" runat="server" CssClass="L1HeaderT1drplists2" ValueType="System.String" Theme="Office2003Blue">
            </dx:ASPxComboBox>

            <asp:Label ID="Label2" runat="server" Text="Steureinheit" CssClass="L1HeaderT1drplables2new"></asp:Label>
            <dx:ASPxComboBox ID="ddlTerminalControlUnit" ValueField="TerminalID" TextField="TermType" runat="server" CssClass="L1HeaderT1drplistsnew" ValueType="System.String" Theme="Office2003Blue">
            </dx:ASPxComboBox>

            <asp:Label ID="Label4" runat="server" Text="Bezeichnung" CssClass="L1HeaderT1drplablesdescription "></asp:Label>
            <dx:ASPxComboBox ID="ddlTerminalDescription" ValueField="TerminalID" TextField="TerminalDescription" runat="server" CssClass="L1HeaderT1drplists2description" ValueType="System.String" Theme="Office2003Blue">
            </dx:ASPxComboBox>
            <asp:Label ID="Label5" runat="server" Text="Alle Terminals anzeigen" CssClass="L1HeaderT1drplablesall"></asp:Label>
            <asp:CheckBox ID="chkShowAll" runat="server" CssClass="chekcbox" />
            <section class="sec2">
                <section class="griddatemover">
                    <section class="griddatemoverleft">
                        <asp:Button ID="btnTariffYearPrevious" runat="server" Text="" CssClass="korbtnFvNavPrevNr" />
                    </section>
                    <section class="griddatemovercenter">
                        <asp:DropDownList ID="ddlTariffYear" runat="server" Theme="Aqua" ValueType="System.String" AutoPostBack="True" Style="min-width: 100%;" CssClass="ddlYearStyle"></asp:DropDownList>
                    </section>
                    <section class="griddatemoverright">
                        <asp:Button ID="btnTariffYearNext" runat="server" Text="" CssClass="korbtnFvNavNexNrt" />
                    </section>
                </section>
            </section>

        </div>
        <div class="contentdivbottom">
            <section class="contentdivbottom1">
                <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, readersAssignment %>"></asp:Label>
            </section>
            <section class="contentdivbottomgrind">
                <dx:ASPxGridView ID="grdTerminals" runat="server" AutoGenerateColumns="False" EnableTheming="True" Theme="Office2003Blue" Width="100%">
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, terminalId %>" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, controlUnit %>" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, description1 %>" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, connectionType %>" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Ip Adresse" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Ip Port" VisibleIndex="6">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Leser ID" VisibleIndex="7">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, readerType %>" VisibleIndex="8">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, description1 %>" VisibleIndex="9">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, direction %>" VisibleIndex="10">
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataCheckColumn Caption="<%$ Resources:localizedText, assigned %>" VisibleIndex="11">
                            <DataItemTemplate>
                                <dx:ASPxCheckBox ID="ASPxCheckBox1" runat="server"></dx:ASPxCheckBox>
                            </DataItemTemplate>
                        </dx:GridViewDataCheckColumn>

                    </Columns>
                    <SettingsPager PageSize="20" ShowEmptyDataRows="True" Visible="False">
                    </SettingsPager>
                </dx:ASPxGridView>


            </section>
        </div>
    </div>
    <%-- end gridview section--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnSaveSelectionDiagram" CssClass="savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, saveselection %>" Style="width: 130px !important; margin-left: 20%;" />
    <asp:Button ID="btnSelectAllDiagram" CssClass="editbtnfooterorange" runat="server" Text="<%$ Resources:localizedText, allselections %>" Style="width: 99px !important;" />
    <asp:Button ID="btnDeleteSeldctionDiagram" CssClass="deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, clearselection %>" Style="width: 126px !important;" />

    <asp:Button ID="btnSaveSelectionGrid" CssClass="savebtnfootergreen displayNone" runat="server" Text="<%$ Resources:localizedText, saveselection %>" Style="width: 130px !important; margin-left: 20%;" />
    <asp:Button ID="btnSelectAllGrid" CssClass="editbtnfooterorange displayNone" runat="server" Text="<%$ Resources:localizedText, allselections %>" Style="width: 99px !important;" />
    <asp:Button ID="btnDeleteSeldctionGrid" CssClass="deletebtnfooterred displayNone" runat="server" Text="<%$ Resources:localizedText, clearselection %>" Style="width: 126px !important;" />

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="backbtnfooterred btnClose" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue btnHelp" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
