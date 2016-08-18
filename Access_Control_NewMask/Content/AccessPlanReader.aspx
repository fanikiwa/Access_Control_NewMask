<%@ Page Title="Zutrittsplan Leserauswahl" Language="C#" MasterPageFile="~/MasterPages/Accessplan.Master" AutoEventWireup="true" CodeBehind="AccessPlanReader.aspx.cs" Inherits="Access_Control_NewMask.Content.AccessPlanReader" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/go.js"></script>
    <script src="Scripts/DiagramFunctionsPlans.js"></script>
    <script src="Scripts/AccessPlanReader.js?v=<%= Access_Control_NewMask.Controllers.Version.JSVersion %>"></script>
    <script src="Scripts/AccessPlanReaderDiagram.js"></script>
    <link href="Styles/AccessPlanReader.css" rel="stylesheet" />
    <link href="Styles/AccessPlanReaderNew.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">
      <asp:HiddenField ID="hiddenFieldInitialPlan" runat="server" />
    <div class="ContentAreaDiv">
    <div id="ControlSection1" class="ControlSectionNew" >
        <div class="topMostSectionNew">
            <div id="ControlSecarea" class="controlSecNew">
                <div class="ControlSecarea2" style="display: none;">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, accessPlanGroupNo %>" CssClass="planGruppen1"></asp:Label>
                    <asp:DropDownList ID="ddlAccessGroupNumber" ClientIDMode="Static" DataValueField="Id" DataTextField="AccessGroupNumber" runat="server" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="planGruppen2"></asp:DropDownList>
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, groupName %>" CssClass="planGruppen3"></asp:Label>
                    <asp:DropDownList ID="ddlAccessGroupName" ClientIDMode="Static" runat="server" DataValueField="Id" DataTextField="AccessGroupName" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="planGruppen4"></asp:DropDownList>
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, accessPlanNo %>" CssClass="planGruppen5"></asp:Label>
                    <asp:DropDownList ID="ddlAccessProfileNumber" ClientIDMode="Static" runat="server" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                        CssClass="planGruppen6" DataValueField="ID" DataTextField="AccessPlanNr">
                    </asp:DropDownList>
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="planGruppen7"></asp:Label>
                    <asp:DropDownList ID="ddlAccessProfileName" ClientIDMode="Static" runat="server" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                        CssClass="planGruppen8" DataValueField="ID" DataTextField="AccessPlanDescription">
                    </asp:DropDownList>

                    <asp:Button ID="Search" runat="server" Text="" CssClass="searchzutarea" />

                </div>
                <div class="ControlSecarea3New">
                    <section class="leftDvns">
                        <asp:Label runat="server" Text="<%$ Resources:localizedText,  accessplangroupinfo %>" CssClass="Gruppen1"></asp:Label>
                        <asp:TextBox ID="txtAccessGroupNumber" ClientIDMode="Static" Enabled="false" runat="server" CssClass="Gruppen2"></asp:TextBox>
                        <asp:Label runat="server" Text="<%$ Resources:localizedText, groupName %>" CssClass="Gruppen3"></asp:Label>
                        <asp:TextBox ID="txtAccessGroupName" ClientIDMode="Static" Enabled="false" runat="server" CssClass="Gruppen4"></asp:TextBox>
                        <asp:Label runat="server" Text="<%$ Resources:localizedText,  planNo_new %>" CssClass="planGruppenf"></asp:Label>
                        <asp:TextBox ID="txtAccessProfileNumber" ClientIDMode="Static" Enabled="false" runat="server" CssClass="Gruppenf"></asp:TextBox>
                        <asp:Label runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="planGruppeng"></asp:Label>
                        <asp:TextBox ID="txtAccessProfileName" ClientIDMode="Static" Enabled="false" runat="server" CssClass="Gruppeng"></asp:TextBox>
                        <%--<asp:Label runat="server" Text="<%$ Resources:localizedText, settings %>" CssClass="settings2new015"></asp:Label>--%>
                    </section>
                    <section class="rightDvns">
                        <asp:Button ID="btnPersonnel" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, people %>" CssClass="newstandardbutton Personenbutton2" PostBackUrl="~/Content/AccessPlanPersonal.aspx"></asp:Button>
                        <img src="../Images/FormImages/arrowreader.png" Class="arrowpoint" />
                        <asp:Button ID="btnMembers" runat="server" Text="Mitglieder" cssclass="newstandardbutton memberbutton2" PostBackUrl="~/Content/AccessPlanMembers.aspx" ></asp:Button>
				        <img src="../Images/FormImages/arrowreader.png" Class="arrowpoint" /> 
                        <asp:Button ID="btnReader" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, reader %>" CssClass="newstandardbutton Leserbutton2" PostBackUrl="~/Content/AccessPlanReader.aspx"></asp:Button>
                        <img src="../Images/FormImages/arrowreader.png" Class="arrowpoint" />
                        <asp:Button ID="btnAccessProfile" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, accessCalendar%>" PostBackUrl="~/Content/AccessPlanAccessCalender.aspx" CssClass="newstandardbutton Zutrittsprofilbutton2"></asp:Button>
                        <img src="../Images/FormImages/arrowreader.png" Class="arrowpoint" />
                        <asp:Button ID="Button1" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, holidaySchedule%>" PostBackUrl="~/Content/AccessPlanHolidaySchedule.aspx" CssClass="newstandardbutton Zutrittsprofilbutton2leser"></asp:Button>
                        <asp:ImageButton ID="btnInformation" CssClass="btnInfo" runat="server"  />
                    </section>
                </div>
            </div>

        </div>
        <div class="MidContentAreaDiv"></div>
        <div class="top topControls">

            <section class="lefttop" style="width: 67%; height: 100%; float: left;">
                <asp:Label ID="lblPlanNr" runat="server" Text="<%$ Resources:localizedText, buildingPlanNr1 %>" CssClass="L1HeaderT1drplables"  Style="margin-left: 11px; min-width: 121px; width: 10.5%;"></asp:Label> 
                <dx:ASPxComboBox ID="dpllPlanNr" ClientInstanceName="dpllPlanNr" ValueField="ID" TextField="PlanNr" runat="server" TextFormatString="{0}" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" DropDownWidth="300px" DropDownRows="20" Theme="Office2003Blue">
                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	planSelectedChanged(s,e);
}"
                        Init="function(s, e) {
dpllPlanNrInit(s,e);	
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn Caption="Nr:" Name="PlanNr" FieldName="PlanNr" Width="10%" />
                         <dx:ListBoxColumn Caption="<%$ Resources:localizedText,  buildingPlanName2 %>" Name="PlanName" FieldName="PlanName" Width="90%" />
                    </Columns>
                </dx:ASPxComboBox>
                
                <asp:Label ID="lblPlanName" runat="server" Text="<%$ Resources:localizedText,  buildingPlanName2 %>" CssClass="L1HeaderT1drplablessd"></asp:Label>
                <dx:ASPxComboBox ID="dplPlanName" ClientInstanceName="dplPlanName" ValueField="ID" TextField="PlanName" runat="server" TextFormatString="{1}" CssClass="L1HeaderT1drplistsfj" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" DropDownWidth="300px" DropDownRows="20" Theme="Office2003Blue">
                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	planSelectedChanged(s,e);
}"
                        Init="function(s, e) {
dplPlanNameInit(s, e);	
}"></ClientSideEvents>
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
        <div class="bottom bottomControls" >

            <section class="leftbottom" style="width: 50%; height: 100%; float: left;">

                <asp:Label ID="lblPlanNr2" runat="server" Text="<%$ Resources:localizedText, buildingPlanNr1 %>" CssClass="L1HeaderT1drplablesd" Style="margin-left: 11px; min-width: 6px;" ></asp:Label>
                <asp:TextBox ID="txtPlanNr" runat="server" ReadOnly="true" CssClass="L1HeaderT1txboxd015" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                </asp:TextBox>
                <asp:Label ID="lblPlanName2" runat="server" Text="<%$ Resources:localizedText,  buildingPlanName2 %>" CssClass="L1HeaderT1drplablesx"></asp:Label>
                <asp:TextBox ID="txtPlanName" runat="server" CssClass="L1HeaderT1txboxvnew" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                </asp:TextBox>

            </section>
            <section class="rightbottom" style="height: 75%; margin-top: 5px; float: left;">
                <asp:ImageButton ID="btnZoomOut" ImageUrl="~/Images/FormImages/zoom20-02.png" runat="server" />
                <asp:ImageButton ID="btnZoomIn" ImageUrl="~/Images/FormImages/zoom10-01.png" runat="server" />
            </section>
          <section class="standontarea">
    <section class="arealeft">
     <asp:Label runat="server" Text="<%$ Resources:localizedText, hidefrom %>" class="lbllocation" ></asp:Label><asp:Label runat="server" Text="<%$ Resources:localizedText,  hidefromlocation2 %>" class="lbllocation" style="font-weight:bold;"></asp:Label><asp:CheckBox runat="server" id="chkHideLocation" ClientIDMode="Static" class="chklocation"></asp:CheckBox>
    </section>
    <section class="arearight">
 <asp:Label runat="server" Text="<%$ Resources:localizedText, Buildingloc %>" class="lbllocation2"></asp:Label> <asp:Label runat="server" Text="<%$ Resources:localizedText, Buildinglocationhide2 %>" class="lbllocation2" style="font-weight:bold;"></asp:Label><asp:CheckBox runat="server" id="chkHideLocBuilding" ClientIDMode="Static" class="chklocation2"></asp:CheckBox>
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
                <asp:Label ID="lblReaderActive" runat="server" CssClass="contextList" Text="<%$ Resources:localizedText, readerActive %>"></asp:Label>
                <asp:CheckBox ID="chkTerminal" CssClass="contextChkActive"  TextAlign="Left" runat="server" ClientIDMode="Static" /></li>
            <li id="readerLine">
                <hr />
            </li>
            <li id="comeMenu">
                <asp:Label ID="lblCome" runat="server" CssClass="contextList" Text="<%$ Resources:localizedText, taCome %>"></asp:Label>
                <asp:CheckBox ID="chkTA_Come" TextAlign="Left" runat="server" ClientIDMode="Static" /></li>
            <li id="comeMenuLine">
                <hr />
                </li>
            <li id="goMenu">
                <asp:Label ID="lblGo" runat="server" CssClass="contextList" Text="<%$ Resources:localizedText, taGo %>"></asp:Label>
                <asp:CheckBox ID="chkTA_Go" CssClass="contextChkGo" TextAlign="Left" runat="server" ClientIDMode="Static" /></li>
            <li id="goMenLine">
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
    <div id="importantDialog" class="dialogBox"></div>
        </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterLeft" runat="server">
      <%-- <asp:Button ID="btnEdit" CssClass="BottomFooterBtnsLeft btnEdit" runat="server" Text="<%$ Resources:localizedText, editing %>" />--%>
    <asp:Button ID="btnSave" CssClass="savebtnfootergreen" runat="server" Text="Leserauswahl speichern" style="width:153px;"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterRight" runat="server">
     <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>"  />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
