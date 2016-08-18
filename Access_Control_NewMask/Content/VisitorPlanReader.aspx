<%@ Page Title="Besucherpläne - Leser" Language="C#" MasterPageFile="~/MasterPages/Accessplan.Master" AutoEventWireup="true" CodeBehind="VisitorPlanReader.aspx.cs" Inherits="Access_Control_NewMask.Content.VisitorPlanReader" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/VisitorPlanReader2.css" rel="stylesheet" />
    <link href="Styles/VisitorPlanReader.css" rel="stylesheet" />
    <script src="Scripts/go.js" type="text/javascript"></script>
     <script src="Scripts/VisitorPlanReaderDiagram.js"></script>
    <script src="Scripts/VisitorPlanReader.js?v=<%= Access_Control_NewMask.Controllers.Version.JSVersion %>"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="ContentAreaDiv">
        <div class="topMostSection">
            <div id="ControlSecarea" class="ControlSecarea1reader">
                <div class="ControlSecarea2" style="display: none;">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, accessPlanGroupNo %>" CssClass="planGruppen1"></asp:Label>
                    <asp:DropDownList ID="ddlVisitorGroupNumber" ClientIDMode="Static" DataValueField="Id" DataTextField="AccessGroupNumber" runat="server" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="planGruppen2"></asp:DropDownList>
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, groupName %>" CssClass="planGruppen3"></asp:Label>
                    <asp:DropDownList ID="ddlVisitorGroupName" ClientIDMode="Static" runat="server" DataValueField="Id" DataTextField="AccessGroupName" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="planGruppen4"></asp:DropDownList>
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, accessPlanNo %>" CssClass="planGruppen5"></asp:Label>
                    <asp:DropDownList ID="ddlVisitorProfileNumber" ClientIDMode="Static" runat="server" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                        CssClass="planGruppen6" DataValueField="ID" DataTextField="AccessPlanNr">
                    </asp:DropDownList>
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="planGruppen7"></asp:Label>
                    <asp:DropDownList ID="ddlVisitorProfileName" ClientIDMode="Static" runat="server" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                        CssClass="planGruppen8" DataValueField="ID" DataTextField="AccessPlanDescription">
                    </asp:DropDownList>

                    <asp:Button ID="Search" runat="server" Text="" CssClass="searchzutarea" />

                </div>
                <div class="ControlSecarea3r">
                    <section class="leftDvnsnewab">
                        <asp:Label runat="server" Text="<%$ Resources:localizedText, accessPlanGroupNo %>" CssClass="Gruppen1newab" Style="padding-left: 12px; display: none;"></asp:Label>
                        <asp:TextBox ID="txtVisitorGroupNumber" ClientIDMode="Static" runat="server" CssClass="Gruppen2newab" Style="display: none"></asp:TextBox>
                        <asp:Label runat="server" Text="<%$ Resources:localizedText, groupName %>" CssClass="Gruppen3newab" Style="display: none"></asp:Label>
                        <asp:TextBox ID="txtVisitorGroupName" ClientIDMode="Static" runat="server" CssClass="Gruppen4newab" Style="display: none"></asp:TextBox>
                        <asp:Label runat="server" Text="<%$ Resources:localizedText, visitorPlannumber %>" CssClass="planGruppenfr"></asp:Label>
                        <asp:TextBox ID="txtVisitorProfileNumber" Enabled="false" ClientIDMode="Static" runat="server" CssClass="Gruppenfr" Style="width: 5.8%"></asp:TextBox>
                        <asp:TextBox ID="txtProfileId" Style="display:none" runat="server"></asp:TextBox>
                        <asp:Label runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="planGruppeng" Style="text-align: left; min-width: 133px; margin-left: 10px; margin-top: 10px; width: 6%"></asp:Label>
                        <asp:TextBox ID="txtVisitorProfileName" Enabled="false" ClientIDMode="Static" runat="server" CssClass="Gruppengnewab" Style="width: 19%; margin-left: 19px"></asp:TextBox>
                        <asp:Label runat="server" Text="<%$ Resources:localizedText, settings %>" CssClass="settings2new015" Style="display: none;"></asp:Label>
                    </section>
                    <section class="rightDvnsnewab" style="margin-top: 12px;">
                        <asp:Button ID="btnPersonnel" runat="server" Text="<%$ Resources:localizedText, visitorTitle %>" CssClass="newstandardbutton" Style="display: none;" OnClick="btnPersonnel_Click"></asp:Button>
                        <img src="../Images/FormImages/arrowpoint.png" class="arrowpoint" style="display: none;" />
                        <asp:Button ID="btnReader" runat="server" Text="<%$ Resources:localizedText, reader %>" CssClass=" newstandardbutton" Enabled="false" Style="width: 18%;" OnClick="btnReader_Click" ></asp:Button>
                        <img src="../Images/FormImages/arrowpoint.png" class="arrowpoint" />
                        <asp:Button ID="btnAccessProfile" runat="server" Text="<%$ Resources:localizedText, accessCalendar%>" CssClass="newstandardbutton" OnClick="btnAccessProfile_Click"></asp:Button >
                        <img src="../Images/FormImages/arrowpoint.png" class="arrowpoint" style="display: none;" />
                        <asp:Button ID="btnHoliday" runat="server" Text="<%$ Resources:localizedText, holidaySchedule%>" CssClass="newstandardbutton" Style="display: none;" OnClick="btnHoliday_Click"></asp:Button>
                    </section>
                </div>
            </div>
            
        </div>
        <div class="MidContentAreaDiv">
            <div id="ControlSection1" class="ControlSection" style="min-height: 62px;">

                <div class="top" style="width: 100%; height: 50%; float: left;">

                    <section class="lefttop" style="width: 67%; height: 100%; float: left;">
                        <asp:Label ID="lblPlanNr" runat="server" Text="<%$ Resources:localizedText, buildingPlanNr %>" CssClass="L1HeaderT1drplables"></asp:Label>
                        <dx:ASPxComboBox ID="dpllPlanNr" ClientInstanceName="dpllPlanNr" ValueField="ID" TextField="PlanNr" TextFormatString="{0}" DropDownWidth="300px" DropDownRows="20" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	planSelectedChanged(s,e);
}"
                        ></ClientSideEvents>
                            <Columns>
                        <dx:ListBoxColumn Caption="Nr:" Name="PlanNr" FieldName="PlanNr" Width="10%" />
                         <dx:ListBoxColumn Caption="<%$ Resources:localizedText,  buildingPlanName2 %>" Name="PlanName" FieldName="PlanName" Width="90%" />
                    </Columns>
                        </dx:ASPxComboBox>

                        <asp:Label ID="lblPlanName" runat="server" Text="<%$ Resources:localizedText, buildingPlanName %>" CssClass="L1HeaderT1drplablessd"></asp:Label>
                        <dx:ASPxComboBox ID="dplPlanName" ClientInstanceName="dplPlanName" ValueField="ID" TextField="PlanName" TextFormatString="{1}" DropDownWidth="300px" DropDownRows="20" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="L1HeaderT1drplistsfj" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                             <ClientSideEvents SelectedIndexChanged="function(s, e) {
	planSelectedChanged(s,e);
}"
                        ></ClientSideEvents>
                            <Columns>
                        <dx:ListBoxColumn Caption="Nr:" Name="PlanNr" FieldName="PlanNr" Width="10%" />
                         <dx:ListBoxColumn Caption="<%$ Resources:localizedText,  buildingPlanName2 %>" Name="PlanName" FieldName="PlanName" Width="90%" />
                    </Columns>
                        </dx:ASPxComboBox>
                    </section>
                    <section class="righttop" style="text-align: right; height: 100%; float: right; display: none;">
                        <asp:Button ID="btnFullScreenMode" runat="server" Text="<%$ Resources:LocalizedText, fullScreen %>" CssClass="midlevelrightsection"></asp:Button>
                    </section>

                </div>
                <div class="bottom" style="width: 100%; height: 49%; background: #E5E5E5; background: rgba(229, 229, 229, 1); float: left;">

                    <section class="leftbottom" style="width: 50%; height: 100%; float: left;">

                        <asp:Label ID="lblPlanNr2" runat="server" Text="<%$ Resources:localizedText, buildingPlanNr %>" CssClass="L1HeaderT1drplablesd"></asp:Label>
                        <asp:TextBox ID="txtPlanNr" Enabled="false" runat="server" ReadOnly="true" CssClass="L1HeaderT1txboxd" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                        </asp:TextBox>
                        <asp:Label ID="lblPlanName2" runat="server" Text="<%$ Resources:localizedText, buildingPlanName %>" CssClass="L1HeaderT1drplablesxnewab"></asp:Label>
                        <asp:TextBox ID="txtPlanName" Enabled="false" runat="server" CssClass="L1HeaderT1txboxv" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                        </asp:TextBox>

                    </section>
                    <section class="rightbottom" style="height: 75%; margin-top: 5px; float: left;">
                        <asp:ImageButton ID="btnZoomOut" ImageUrl="~/Images/FormImages/zoom20-02.png" runat="server" />
                        <asp:ImageButton ID="btnZoomIn" ImageUrl="~/Images/FormImages/zoom10-01.png" runat="server" />
                    </section>
                    <section class="standontarea">
                        <section class="arealeft">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, hidefrom %>" class="lbllocation" Style="margin-right: 2%;"></asp:Label><asp:Label runat="server" Text="<%$ Resources:localizedText, hidefromlocation %>" class="lbllocation" Style="font-weight: bold;"></asp:Label><asp:CheckBox runat="server" ID="chkHideLocation" ClientIDMode="Static" class="chklocation"></asp:CheckBox>
                        </section>
                        <section class="arearight">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, Buildingloc %>" class="lbllocation2"></asp:Label>
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, Buildinglocationhide %>" class="lbllocation2" Style="font-weight: bold;"></asp:Label><asp:CheckBox runat="server" ID="chkHideLocBuilding" ClientIDMode="Static" class="chklocation2"></asp:CheckBox>
                        </section>
                    </section>
                </div>
            </div>
            <div id="BuildingAreaDivNav" class="secBuildingplanNav">
                <div id="BuildingAreaNav" class="BuildingAreaNav"></div>
            </div>
            <div id="BuildingAreaDiv" class="secBuildingplan"></div>
            <div id="contextMenu">
                <ul>
                    <li id="entriesMenu" class="contextListTitle">
                        <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText, entries %>"></asp:Label></li>
                    <li id="entriesLine">
                        <hr />
                    </li>
                    <li id="readerMenu">
                        <asp:CheckBox ID="chkTerminal" CssClass="contextList" TextAlign="Left" Text="<%$ Resources:localizedText, readerActive %>" runat="server" ClientIDMode="Static" /></li>
                    <li id="readerLine">
                        <hr />
                    </li>
                    <li id="passBackMenu"><a href="#" id="PassBack" class="contextList" onclick="PassBackMenu()"></a></li>
                    <li id="passBackLineMenu">
                        <hr />
                    </li>
                    <li id="closeMenu"><a href="#" id="conclude" class="contextList" onclick="CloseMenu()"></a></li>
                    <li id="closeLine">
                        <hr />
                    </li>
                    <li id="lblInfo" class="contextListTitle">
                        <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText, information %>"></asp:Label></li>
                    <li id="infoLine">
                        <hr />
                    </li>
                    <li id="terminalMenu"><a href="#" id="terminalInfo" class="contextList" onclick="cxcommandTerminalInfo()"></a></li>
                    <li id="lblpassBack" class="contextListTitle">
                        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, antiPassBackFunction %>"></asp:Label></li>
                    <li id="passBackLine">
                        <hr />
                    </li>
                    <li id="readerOne">
                        <asp:Label ID="Label4" runat="server" CssClass="contextList" Text="<%$ Resources:localizedText, firstReader %>"></asp:Label>
                        <asp:CheckBox ID="chkFirstReader" TextAlign="Left" runat="server" ClientIDMode="Static" /></li>
                    <li id="readerOneLine">
                        <hr />
                    </li>
                    <li id="readerTwo">
                        <asp:Label ID="Label3" runat="server" CssClass="contextList" Text="<%$ Resources:localizedText, secondReader %>"></asp:Label>
                        <asp:CheckBox ID="chkSecondReader" TextAlign="Left" runat="server" ClientIDMode="Static" /></li>
                    <li id="readerTwoLine">
                        <hr />
                    </li>
                    <li id="nothing">
                        <asp:Label ID="Label2" runat="server" CssClass="contextList" Text="<%$ Resources:localizedText, nothing %>"></asp:Label>
                        <asp:CheckBox ID="chkNothing" CssClass="contextChkList3" TextAlign="Left" runat="server" ClientIDMode="Static" /></li>
                    <li id="nothingLine">
                        <hr />
                    </li>
                    <li id="closeMenuTwo"><a href="#" id="close" class="contextList2" onclick="CloseMenuTwo()"></a></li>
                </ul>
            </div>
            <div id="txtEdit" style="visibility: hidden">
                <asp:TextBox ID="txtEditor" ClientIDMode="Static" Font-Size="12px" Width="100px" MaxLength="15" runat="server"></asp:TextBox>
            </div>
        </div>
        <div id="importantDialog" class="dialogBox">
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterLeft" runat="server">
    <%--     <asp:Button ID="btnEdit" CssClass="BottomFooterBtnsLeft btnEdit" runat="server" Text="<%$ Resources:localizedText, editing %>" />--%>
    <asp:Button ID="btnSave" CssClass="savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, savereaders %>" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
