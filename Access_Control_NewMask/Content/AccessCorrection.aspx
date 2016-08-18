<%@ Page Title="Korrekturen - Anwesenheitszeiten" Language="C#" MasterPageFile="~/MasterPages/Primary.Master" AutoEventWireup="true" CodeBehind="AccessCorrection.aspx.cs" Inherits="Access_Control_NewMask.Content.AccessCorrection" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/AccessCorrection.css" rel="stylesheet" />
    <script src="Scripts/AccessCorrection.js"></script>
    <link href="Styles/FormViewSearch.css" rel="stylesheet" />
    <style>
        #grdBookingsCorrection td {
            font-size: 14px;
        }
    </style>
    <script type="text/javascript">
        function doTime() {

            $("#lblTime").text(moment().format("HH") + ":" + moment().format("mm"));
            $("#lblDate").text(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
            $("#lblDateDisplay").text(moment().format("DD") + "." + moment().format("MM") + "." + moment().format("YYYY"));
        }

        $(function () {
            setInterval(doTime, 1);

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="contentarea">
        <section class="contentareatop" style="display: none">
            <section class="contentareatopleft">
                <section class="contentareatoplefttop">
                    <section class="contentareatoplefttop1">
                        <asp:Label ID="lblLocation" runat="server" Text="<%$ Resources:localizedText, location1 %>" CssClass="lbl1"></asp:Label>
                        <asp:Label ID="lblBuilding" runat="server" Text="<%$ Resources:localizedText, building2 %>" CssClass="lbl1"></asp:Label>
                        <asp:Label ID="lblEbene" runat="server" Text="<%$ Resources:localizedText, floor2 %>" CssClass="lbl1"></asp:Label>
                        <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, room2 %>" CssClass="lbl1"></asp:Label>
                    </section>
                    <section class="contentareatoplefttop2">
                        <asp:Label ID="Label5" runat="server" Text="Name:" CssClass="lbl2"></asp:Label>
                        <asp:Label ID="Label6" runat="server" Text="ID Nr.:" CssClass="lbl2"></asp:Label>
                        <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText, listingNo %>" CssClass="lbl2"></asp:Label>
                        <asp:Label ID="Label8" runat="server" Text="<%$ Resources:localizedText, location1 %>" CssClass="lbl2"></asp:Label>
                        <asp:Label ID="Label9" runat="server" Text="<%$ Resources:localizedText, departments %>" CssClass="lbl2"></asp:Label>
                    </section>
                </section>
                <section class="contentareatopleftbtm">
                    <section class="contentareabtmlefttop1">
                        <asp:DropDownList ID="ddlBuildingLocations" runat="server" CssClass="drp1"></asp:DropDownList>
                        <asp:DropDownList ID="ddlBuildings" runat="server" CssClass="drp1"></asp:DropDownList>
                        <asp:DropDownList ID="ddlBuildingFloors" runat="server" CssClass="drp1"></asp:DropDownList>
                        <asp:DropDownList ID="ddlBuildingRooms" runat="server" CssClass="drp1"></asp:DropDownList>
                    </section>
                    <section class="contentareabtmlefttop2">
                        <asp:DropDownList ID="ddlEmployeeName" AutoPostBack="True" runat="server" CssClass="drp2" DataMember="Name" DataTextField="Name"></asp:DropDownList>
                        <asp:DropDownList ID="ddlEmployeeNumber" AutoPostBack="True" runat="server" CssClass="drp2" DataTextField="EmployeeNumber"></asp:DropDownList>
                        <asp:DropDownList ID="ddlEmployeeCardNumber" AutoPostBack="True" runat="server" CssClass="drp2" DataTextField="CardNumber"></asp:DropDownList>
                        <asp:DropDownList ID="ddlEmployeeLocation" AutoPostBack="True" runat="server" CssClass="drp2" DataTextField="locationName"></asp:DropDownList>
                        <asp:DropDownList ID="ddlEmployeeDepartment" AutoPostBack="True" runat="server" CssClass="drp2" DataTextField="DepartmentName"></asp:DropDownList>
                    </section>
                </section>
            </section>
            <section class="contentareatopright">
                <div id="AEHeaderRightDiv">
                    <section class="empFormViewNav">
                        <section class="fvNavSearch">
                            <asp:Label ID="lblSearchAllEmp" runat="server" Text="<%$ Resources:localizedText, search %>" />
                            <asp:Button ID="btnSearchAllEmp" runat="server" Text="" CssClass="searchAllEmp" />
                        </section>
                    </section>
                </div>
            </section>
        </section>
        <section class="contentareatopnew">
            <section class="contentareatopleft">
                <section class="contentareatoplefttop">
                    <section class="contentareatoplefttop1">
                        <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText, client_new %>" CssClass="lbl1"></asp:Label>
                        <asp:Label ID="Label11" runat="server" Text="<%$ Resources:localizedText, location1 %>" CssClass="lbl1"></asp:Label>
                        <asp:Label ID="Label12" runat="server" Text="<%$ Resources:localizedText, departments %>" CssClass="lbl1"></asp:Label>
                        <asp:Label ID="Label13" runat="server" Text="<%$ Resources:localizedText, costcenter %>" CssClass="lbl1newcost"></asp:Label>
                    </section>
                    <section class="contentareatoplefttop2">
                        <asp:Label ID="Label14" runat="server" Text="Name:" CssClass="lbl2"></asp:Label>
                        <asp:Label ID="Label15" runat="server" Text="ID Nr.:" CssClass="lbl2nr"></asp:Label>
                        <asp:Label ID="Label16" runat="server" Text="<%$ Resources:localizedText, listingNo %>" CssClass="lbl2nr"></asp:Label>
                    </section>
                </section>
                <section class="contentareatopleftbtm">
                    <section class="contentareabtmlefttop1">
                        <%--<dx:ASPxComboBox ID="dplClients" ClientInstanceName="dplClients" runat="server" ValueField="ID" TextField="" ClientIDMode="Static"
                               TextFormatString="{0}" CssClass="drp1" SelectedIndex="0" DropDownRows="20" DropDownWidth="400px" DropDownHeight="19px" Theme="Office2003Blue">
                            <Columns>
                                <dx:ListBoxColumn FieldName="Client_Nr" Caption="Nr.:" Name="Mandant Nr.:" Width="20%" />
                                <dx:ListBoxColumn FieldName="Name" Caption="<%$ Resources:localizedText ,description_new%>" Name="ID" ToolTip="Bezeichnung:" Width="80%" />
                            </Columns>
             
                             </dx:ASPxComboBox>
                        <dx:ASPxComboBox ID="dplLocation" ClientInstanceName="dplLocation" runat="server" ValueField="ID" TextField="" ClientIDMode="Static"
                               TextFormatString="{0}" CssClass="drp1" SelectedIndex="0" DropDownRows="20" DropDownWidth="400px" DropDownHeight="19px" Theme="Office2003Blue">
                            <Columns>
                                <dx:ListBoxColumn FieldName="ID" Caption="Nr." Name="" Visible="false" />
                                <dx:ListBoxColumn FieldName="Location_Nr" Caption="Nr.:" Name="" ToolTip="Bezeichnung:" Width="20%" />
                                <dx:ListBoxColumn FieldName="Name" Caption="<%$ Resources:localizedText ,description_new%>" Name="ProfileDescription" ToolTip="" Width="80%" />
                            </Columns>
             
                             </dx:ASPxComboBox>
                        <dx:ASPxComboBox ID="dplDepartment" ClientInstanceName="dplDepartment" runat="server" ValueField="ID" TextField="" ClientIDMode="Static"
                               TextFormatString="{0}" CssClass="drp1" SelectedIndex="0" DropDownRows="20" DropDownWidth="400px" DropDownHeight="19px" Theme="Office2003Blue">
             
                            <Columns>
                                <dx:ListBoxColumn FieldName="ID" Caption="ID." Name="ID" Visible="false" />
                                <dx:ListBoxColumn FieldName="Department_Nr" Caption="Nr.:" Name="Department_Nr" ToolTip="Bezeichnung:" Width="20%" />
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText ,description_new%>" FieldName="Name" Name="ProfileDescription" ToolTip="" Width="80%" />
                            </Columns>

                             </dx:ASPxComboBox>
                        <dx:ASPxComboBox ID="dplCostCenter" ClientInstanceName="dplCostCenter" runat="server" ValueField="ID" TextField="" ClientIDMode="Static"
                               TextFormatString="{0}" CssClass="drp1" SelectedIndex="0" DropDownRows="20" DropDownWidth="400px" DropDownHeight="19px" Theme="Office2003Blue">
                        </dx:ASPxComboBox>--%>

                        <dx:ASPxComboBox ID="dplClients" runat="server" ValueField="ID" TextField="Client_Nr" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                            TextFormatString="{1}" CssClass="drp1" SelectedIndex="0" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" EnableCallbackMode="true" AutoPostBack="false">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cmbClientsSelectedIndexChanged(s.GetValue());
}" />
                            <Columns>
                                <dx:ListBoxColumn FieldName="Client_Nr" Name="ProfileDescription" ToolTip="" Width="20%" />
                                <dx:ListBoxColumn FieldName="Name" Name="" ToolTip="Bezeichnung:" Width="80%" Visible="true" />
                                <dx:ListBoxColumn FieldName="ID" Name="" ToolTip="Bezeichnung:" Width="42%" Visible="false" />
                            </Columns>
                        </dx:ASPxComboBox>

                        <dx:ASPxComboBox ID="dplLocation" runat="server" ValueField="ID" TextField="Name" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                            TextFormatString="{1}" CssClass="drp1" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" EnableCallbackMode="true" AutoPostBack="false">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cmbLocationNameSelectedIndexChanged(s.GetValue());
}" />
                            <Columns>
                                <dx:ListBoxColumn FieldName="ID" Caption="Nr." Name="" Visible="false" />
                                <dx:ListBoxColumn FieldName="Location_Nr" Caption="Nr.:" Name="" ToolTip="Bezeichnung:" Width="20%" />
                                <dx:ListBoxColumn FieldName="Name" Caption="<%$ Resources:localizedText ,description_new%>" Name="ProfileDescription" ToolTip="" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>

                        <dx:ASPxComboBox ID="dplDepartment" runat="server" ValueField="ID" TextField="Client_Nr" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                            TextFormatString="{1}" CssClass="drp1" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" EnableCallbackMode="true" AutoPostBack="false">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cmbDepartmentSelectedIndexChanged(s.GetValue());
}" />
                            <Columns>
                                <dx:ListBoxColumn FieldName="ID" Caption="ID." Name="ID" Visible="false" />
                                <dx:ListBoxColumn FieldName="Department_Nr" Caption="Nr.:" Name="Department_Nr" ToolTip="Bezeichnung:" Width="20%" />
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText ,description_new%>" FieldName="Name" Name="ProfileDescription" ToolTip="" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>

                        <dx:ASPxComboBox ID="dplCostCenter" runat="server" ValueField="ID" TextField="Name" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                            TextFormatString="{1}" CssClass="drp1" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" EnableCallbackMode="true" AutoPostBack="false">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cmbCostCenterSelectedIndexChanged(s.GetValue());
}" />
                            <Columns>
                                <dx:ListBoxColumn FieldName="ID" Caption="ID." Name="ID" Visible="false" />
                                <dx:ListBoxColumn FieldName="CostCenter_Nr" Caption="Nr.:" Name="CostCenter_Nr" ToolTip="Nr:" Width="20%" />
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText ,description_new%>" FieldName="Name" Name="CostCenterBezeichnung" ToolTip="Bezeichnung:" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                    </section>
                    <section class="contentareabtmlefttop2">
                        <%--<dx:ASPxComboBox ID="dplPersonalName" ClientInstanceName="dplPersonalName" runat="server" ValueField="ID" TextField="" ClientIDMode="Static"
                               TextFormatString="{0}" CssClass="drp1" SelectedIndex="0" DropDownRows="20" DropDownWidth="400px" DropDownHeight="19px" Theme="Office2003Blue">
                            <Columns>
                                <dx:ListBoxColumn FieldName="Pers_Nr" Caption="Pers. Nr." Name="ProfileDescription" ToolTip="" Width="18%" />
                                <dx:ListBoxColumn FieldName="FirstName" Caption="Name:" Name="FirstName" ToolTip="Bezeichnung:" Width="42%" />
                                <dx:ListBoxColumn FieldName="LastName" Caption="<%$ Resources:localizedText ,firstname_new%>" Name="LastName" ToolTip="Bezeichnung:" Width="42%" />
                            </Columns>
             
                             </dx:ASPxComboBox>
                        <dx:ASPxComboBox ID="dplPersonalNumber" ClientInstanceName="dplPersonalNumber" runat="server" ValueField="ID" TextField="" ClientIDMode="Static"
                               TextFormatString="{0}" CssClass="drp1nr" SelectedIndex="0" DropDownRows="20" DropDownWidth="400px" DropDownHeight="19px" Theme="Office2003Blue" HorizontalAlign="Right">
                            <Columns>
                                <dx:ListBoxColumn FieldName="Pers_Nr" Caption="Pers. Nr." Name="ProfileDescription" ToolTip="" Width="18%" />
                                <dx:ListBoxColumn FieldName="FirstName" Caption="Name:" Name="FirstName" ToolTip="Bezeichnung:" Width="42%" />
                                <dx:ListBoxColumn FieldName="LastName" Caption="<%$ Resources:localizedText ,firstname_new%>" Name="LastName" ToolTip="Bezeichnung:" Width="42%" />
                            </Columns>
                             </dx:ASPxComboBox>
                        <dx:ASPxComboBox ID="dplCardNumber" ClientInstanceName="dplCardNumber" runat="server" ValueField="ID" TextField="" ClientIDMode="Static"
                               TextFormatString="{0}" CssClass="drp1nr" SelectedIndex="0" DropDownRows="20" DropDownWidth="400px" DropDownHeight="19px" Theme="Office2003Blue" HorizontalAlign="Right">
                        </dx:ASPxComboBox>--%>
                        <dx:ASPxComboBox ID="dplPersonalName" runat="server" ClientInstanceName="dplPersonalName" ValueType="System.Int32" ClientIDMode="Static" ValueField="Pers_Nr" EnableCallbackMode="True"
                            TextFormatString="{1} {2}" CssClass="drp1" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" CallbackPageSize="10000">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cmbPersNameSelectedIndexChanged(s.GetValue());
}" />
                            <Columns>
                                <dx:ListBoxColumn FieldName="Pers_Nr" Caption="Pers. Nr." Name="ProfileDescription" ToolTip="" Width="18%" />
                                <dx:ListBoxColumn FieldName="FirstName" Caption="Name:" Name="FirstName" ToolTip="Bezeichnung:" Width="42%" />
                                <dx:ListBoxColumn FieldName="LastName" Caption="<%$ Resources:localizedText ,firstname_new%>" Name="LastName" ToolTip="Bezeichnung:" Width="42%" />
                            </Columns>
                        </dx:ASPxComboBox>

                        <dx:ASPxComboBox ID="dplPersonalNumber" HorizontalAlign="left" runat="server" ValueType="System.Int32" ClientInstanceName="dplPersonalNumber" ClientIDMode="Static" ValueField="Pers_Nr" TextField="Pers_Nr" EnableCallbackMode="true" AutoPostBack="false"
                            TextFormatString="{0}" CssClass="drp1nr" DropDownRows="20" DropDownWidth="100px" Theme="Office2003Blue" CallbackPageSize="10000">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cmbIDNrSelectedIndexChanged(s.GetValue());
                                }" />
                            <Columns>
                                <dx:ListBoxColumn FieldName="Pers_Nr" Caption="ID Nr.:" Name="ProfileDescription" ToolTip="" Width="18%" />
                            </Columns>
                        </dx:ASPxComboBox>

                        <dx:ASPxComboBox ID="dplCardNumber" HorizontalAlign="left" runat="server" ValueField="Pers_Nr" ClientInstanceName="dplCardNumber" ClientIDMode="Static" TextField="Card_Nr_Str" EnableCallbackMode="true" AutoPostBack="false"
                            TextFormatString="{0}" ValueType="System.Int32" CssClass="drp1nr" DropDownRows="20" DropDownWidth="100px" Theme="Office2003Blue" CallbackPageSize="10000">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cmbAusweisNrSelectedIndexChanged(s.GetValue());
}" />
                            <Columns>
                                <dx:ListBoxColumn FieldName="Pers_Nr" Name="ProfileDescription" ToolTip="" Width="20%" Visible="false" />
                                <dx:ListBoxColumn FieldName="IdentificationNr_string" Caption="<%$ Resources:localizedText ,cardNo%>" Name="AusweisN" ToolTip="Bezeichnung:" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>


                        <asp:Label ID="Label17" runat="server" Text="<%$ Resources:localizedText ,showallpeople%>" CssClass="lbl2newAll"></asp:Label>
                        <asp:CheckBox ID="chkShowAllPeople" ClientIDMode="Static" runat="server" CssClass="chkActivation" />
                    </section>
                </section>
            </section>
            <section class="contentareatopright">
                <asp:Button ID="btnRefresh" ClientIDMode="Static" runat="server" Text="" CssClass="refreshButton" />
            </section>
        </section>
        <section class="MidContentAreaDiv">
            <section class="contentareatopnewbtm">
                <section class="cotrollersarea1">
                    <asp:Label ID="Label22" runat="server" Text="<%$ Resources:localizedText ,visitorcontrol%>" CssClass="lblallnewlbl"></asp:Label>
                    <asp:CheckBox ID="chkVisitorLogsOnly" ClientIDMode="Static" runat="server" CssClass="chkareatop" />
                </section>
                <section class="cotrollersarea1new">
                    <asp:Label ID="Label180" runat="server" Text="<%$ Resources:localizedText ,viewallcorrections%>" CssClass="lblall"></asp:Label>
                    <asp:CheckBox ID="chkViewErrorBookingsOnly" runat="server" CssClass="chkareatopnew" />
                </section>
                <div class="intergrated3">
                    <asp:Label ID="Label250" runat="server" Text="<%$ Resources:localizedText ,daterange%>" CssClass="lblalldate"></asp:Label>
                    <section class="rightDivs2">
                        <section class="last">
                            <section class="griddatemover">
                                <section class="griddatemoverleft">
                                    <asp:Button ID="Button5" runat="server" Text="" CssClass="korbtnFvNavPrevNr" />
                                </section>
                                <section class="griddatemovercenter">
                                    <dx:ASPxDateEdit ID="dtDateFrom" Theme="Office2003Blue" HorizontalAlign="Center" runat="server" CssClass="ddlYearStyle2">
                                    </dx:ASPxDateEdit>
                                </section>
                                <section class="griddatemoverright">
                                    <asp:Button ID="Button6" runat="server" Text="" CssClass="korbtnFvNavNexNrt" />
                                </section>
                            </section>
                        </section>
                    </section>
                    <section class="rightDivs1">
                        <section class="bis">
                            <asp:Label ID="Label30" runat="server" Text="<%$ Resources:localizedText, to %>" CssClass="lblJahr"></asp:Label>
                        </section>
                        <section class="center">
                            <section class="griddatemover">
                                <section class="griddatemoverleft">
                                    <asp:Button ID="Button7" runat="server" Text="" CssClass="korbtnFvNavPrevNr" />
                                </section>
                                <section class="griddatemovercenter">
                                    <dx:ASPxDateEdit ID="dtDateTo" Theme="Office2003Blue" HorizontalAlign="Center" runat="server" CssClass="ddlYearStyle2">
                                    </dx:ASPxDateEdit>
                                </section>
                                <section class="griddatemoverright">
                                    <asp:Button ID="Button8" runat="server" Text="" CssClass="korbtnFvNavNexNrt" />
                                </section>
                            </section>
                        </section>
                    </section>
                </div>

                <asp:Label ID="Label24" runat="server" Text="<%$ Resources:localizedText, viewallpersonwithorwithourrser %>" CssClass="lblallpers"></asp:Label>
                <asp:CheckBox ID="chkIncludeAbsentPersonal" runat="server" CssClass="chkareatop" />


            </section>

            <section class="contentareatopnewbtm" style="display: none;">
                <section class="contentareatopleft">
                    <section class="contentareatopleftbtm">
                        <section class="contentareabtmlefttop2new">

                            <section class="cotrollers2">
                                <asp:Label ID="Label23" runat="server" Text="Datum:" CssClass="lblDate"></asp:Label>
                                <asp:Label ID="lblDateDisplay" ClientIDMode="Static" runat="server" Text=" " CssClass="lblDatedisplay"></asp:Label>
                            </section>
                            <asp:Label ID="Label25" runat="server" Text="Alle Buchungen:" CssClass="lbl2newbooking"></asp:Label>
                            <asp:CheckBox ID="chkViewAllBookings" ClientIDMode="Static" runat="server" CssClass="chkActivation" />
                            <asp:Label ID="Label18" runat="server" Text="Fehlerhafte Buchungen:" CssClass="lbl2new"></asp:Label>
                            <asp:CheckBox ID="chkViewErrorBookings" ClientIDMode="Static" runat="server" CssClass="chkActivation" />
                        </section>
                    </section>
                </section>
                <asp:Button ID="btnView" CssClass="BottomFooterBtnsLeftview" runat="server" Text="View" />
            </section>
            <section class="contentareabottom">
                <section class="contentareabottomgrid" style="display: none">
                    <dx:ASPxGridView ID="ASPxGridView1" SettingsBehavior-AllowSort="false" runat="server" AutoGenerateColumns="False" Width="100%" SettingsPager-ShowEmptyDataRows="True">
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="Location" Caption="<%$ Resources:localizedText, location2 %>" VisibleIndex="0" Name="Location">
                                <HeaderStyle BackColor="#ffe7a2" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Building" Caption="<%$ Resources:localizedText, building %>" VisibleIndex="1" Name="Building">
                                <HeaderStyle BackColor="#ffe7a2" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Floor" Caption="<%$ Resources:localizedText, floor %>" VisibleIndex="2" Name="Floor">
                                <HeaderStyle BackColor="#ffe7a2" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Room" Caption="<%$ Resources:localizedText, room %>" VisibleIndex="3" Name="Room">
                                <HeaderStyle BackColor="#ffe7a2" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Name" Caption="Name" VisibleIndex="4" Name="Name">
                                <HeaderStyle BackColor="#ffe7a2" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="PersonelNumber" Caption="ID Nr." VisibleIndex="5" Name="PersonelNumber">
                                <HeaderStyle BackColor="#ffe7a2" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="CardNumber" Caption="<%$ Resources:localizedText, cardnumber %>" VisibleIndex="6" Name="CardNumber">
                                <HeaderStyle BackColor="#ffe7a2" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="LatestBooking" Caption="<%$ Resources:localizedText, Latestbooking %>" VisibleIndex="7" PropertiesTextEdit-DisplayFormatString="yyyy.MM.dd HH:mm" Name="LatestBooking">
                                <PropertiesTextEdit DisplayFormatString="yyyy.MM.dd HH:mm"></PropertiesTextEdit>

                                <HeaderStyle BackColor="#ffe7a2" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Door" Caption="<%$ Resources:localizedText, doorReader %>" VisibleIndex="8" Name="Door">
                                <HeaderStyle BackColor="#ffe7a2" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Date" Caption="<%$ Resources:localizedText, date2 %>" VisibleIndex="11" PropertiesTextEdit-DisplayFormatString="yyyy.MM.dd" Name="Date">
                                <PropertiesTextEdit DisplayFormatString="yyyy.MM.dd"></PropertiesTextEdit>

                                <HeaderStyle BackColor="#ffe7a2" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>

                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Time" Caption="<%$ Resources:localizedText, time %>" VisibleIndex="12" PropertiesTextEdit-DisplayFormatString="HH:mm" Name="Time">
                                <PropertiesTextEdit DisplayFormatString="HH:mm"></PropertiesTextEdit>

                                <HeaderStyle BackColor="#ffe7a2" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>

                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataCheckColumn FieldName="WriteOff" Caption="<%$ Resources:localizedText, writeOff %>" VisibleIndex="10" Name="WriteOff">
                                <HeaderStyle BackColor="#FFE7A2" />
                                <CellStyle>
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px" />
                                </CellStyle>
                            </dx:GridViewDataCheckColumn>
                        </Columns>

                        <SettingsBehavior AllowSort="False"></SettingsBehavior>

                        <SettingsPager Mode="ShowAllRecords" PageSize="18" ShowEmptyDataRows="True" Visible="False">
                        </SettingsPager>
                    </dx:ASPxGridView>
                    <%--<asp:ObjectDataSource ID="acccessCorrectionLog" runat="server"></asp:ObjectDataSource>--%>
                </section>
                <section class="contentareabottomgrid">

                    <dx:ASPxGridView ID="grdAccessCorrection" ClientInstanceName="grdAccessCorrection" EnableCallBacks="true" ClientIDMode="Static" KeyFieldName="PersonalNumber" SettingsBehavior-AllowSort="false" runat="server" AutoGenerateColumns="False" Width="99%" SettingsPager-PageSize="23" SettingsPager-ShowEmptyDataRows="True" OnCustomCallback="grdAccessCorrection_CustomCallback" OnHtmlDataCellPrepared="grdAccessCorrection_HtmlDataCellPrepared">
                        <ClientSideEvents SelectionChanged="function(s, e) {
	grdAccessCorrectionRowChanged(s, e);
}"
                            RowDblClick="function(s, e) {
	grdAccessCorrection_RowClick(s, e);
}" />
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="Client" Caption="<%$ Resources:localizedText, company2 %>" VisibleIndex="0" Name="" Width="18%">
                                <HeaderStyle BackColor="#ffe7a2" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Location" Caption="<%$ Resources:localizedText, location1 %>" VisibleIndex="1" Name="" Width="8%">
                                <HeaderStyle BackColor="#ffe7a2" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Department" Caption="<%$ Resources:localizedText, department %>" VisibleIndex="2" Name="" Width="8%">
                                <HeaderStyle BackColor="#ffe7a2" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="CostCenter" Caption="<%$ Resources:localizedText, costcenter %>" VisibleIndex="3" Name="" Width="8%">
                                <HeaderStyle BackColor="#ffe7a2" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Name" Caption="<%$ Resources:localizedText, name %>" VisibleIndex="4" Name="" Width="10%">
                                <HeaderStyle BackColor="#ffe7a2" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="PersonalNumber" Caption="<%$ Resources:localizedText, IdNo_new %>" VisibleIndex="5" Name="" Width="5%">
                                <HeaderStyle BackColor="#ffe7a2" HorizontalAlign="left" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="Left">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="CardNumber" Caption="<%$ Resources:localizedText, cardNo %>" VisibleIndex="6" Name="" Width="5%">
                                <HeaderStyle BackColor="#ffe7a2" HorizontalAlign="left" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="Left">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Date" Caption="<%$ Resources:localizedText, dateTitle %>" VisibleIndex="7" Name=" " Width="5%">
                                <PropertiesTextEdit DisplayFormatString="dd.MM.yyyy"></PropertiesTextEdit>

                                <HeaderStyle BackColor="#ffe7a2" HorizontalAlign="Center" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Entry" Caption="<%$ Resources:localizedText, doorEntry2 %>" VisibleIndex="8" Name="" Width="5%">
                                <HeaderStyle BackColor="#ffe7a2" ForeColor="#249024" HorizontalAlign="Center" />
                                <PropertiesTextEdit DisplayFormatString="HH:mm"></PropertiesTextEdit>
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="Center">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Exit" Caption="<%$ Resources:localizedText, doorExit2 %>" VisibleIndex="9" Name="" Width="5%">
                                <PropertiesTextEdit DisplayFormatString="HH:mm"></PropertiesTextEdit>

                                <HeaderStyle BackColor="#ffe7a2" ForeColor="Red" HorizontalAlign="Center" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="Center">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Correction2" Caption="<%$ Resources:localizedText, corrections3 %>" VisibleIndex="10" Name="" Width="5%">
                                <PropertiesTextEdit DisplayFormatString="HH:mm"></PropertiesTextEdit>

                                <HeaderStyle BackColor="#ffe7a2" HorizontalAlign="Center" />
                                <CellStyle Border-BorderStyle="Solid" Border-BorderColor="#bdd5f5" Border-BorderWidth="1px" HorizontalAlign="Center">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px"></Border>
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Duration" Caption="<%$ Resources:localizedText, time_new %>" VisibleIndex="11" Name="" Width="5%">
                                <HeaderStyle BackColor="#FFE7A2" HorizontalAlign="Center" />
                                <PropertiesTextEdit DisplayFormatString="HH:mm"></PropertiesTextEdit>
                                <CellStyle HorizontalAlign="Center">
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px" />
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Memo" Caption="<%$ Resources:localizedText, memoTitle %>" VisibleIndex="12" Name="" Width="14%">
                                <HeaderStyle BackColor="#FFE7A2" HorizontalAlign="Left" />
                                <CellStyle>
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px" />
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewCommandColumn ShowSelectCheckbox="true" ShowClearFilterButton="True" VisibleIndex="13" Caption="A:" Width="4%">
                                <HeaderStyle BackColor="#FFE7A2" />
                                <CellStyle>
                                    <Border BorderColor="#BDD5F5" BorderStyle="Solid" BorderWidth="1px" />
                                </CellStyle>
                            </dx:GridViewCommandColumn>


                            <dx:GridViewDataTextColumn FieldName="PersonalNumber" Caption="<%$ Resources:localizedText, company2 %>" VisibleIndex="14" Visible="false" Name="" Width="10%">
                                <HeaderStyle BackColor="#ffe7a2" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="LogPersType" Caption="<%$ Resources:localizedText, company2 %>" VisibleIndex="15" Visible="false" Name="" Width="10%">
                                <HeaderStyle BackColor="#ffe7a2" />
                            </dx:GridViewDataTextColumn>
                        </Columns>

                        <SettingsBehavior AllowSort="False" AllowDragDrop="false"></SettingsBehavior>

                        <SettingsPager Mode="ShowAllRecords" PageSize="24" ShowEmptyDataRows="True" Visible="False"></SettingsPager>
                    </dx:ASPxGridView>
                    <%--<asp:ObjectDataSource ID="acccessCorrectionLog" runat="server"></asp:ObjectDataSource>--%>
                </section>
                <section class="contentareabottomlong" style="display: none">
                    <section class="contentareabottomlonglbl">
                        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, date2 %>" CssClass="contentareabottomlonglbl1"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, time %>" CssClass="contentareabottomlonglbl2"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text="Memo" CssClass="contentareabottomlonglbl3"></asp:Label>
                    </section>
                    <section class="contentareabottomlongtxt">
                        <asp:Label ID="lblDate" runat="server" Text="Label" CssClass="contentareabottomlongtxt1"></asp:Label>
                        <asp:Label ID="lblTime" runat="server" Text="Label" CssClass="contentareabottomlongtxt2"></asp:Label>
                        <asp:TextBox ID="txtMemo" runat="server" CssClass="contentareabottomlongtxt3" TextMode="MultiLine"></asp:TextBox>
                    </section>
                </section>
            </section>

            <section class="infoBoard" style="display: none;">
                <section class="secSprache">
                    <section class="sectable">
                        <asp:Table runat="server" GridLines="Vertical" CellSpacing="1" CellPadding="1" BorderStyle="Solid" BorderWidth="1px" BorderColor="#666666" Font-Size="Medium" ForeColor="Black" Width="100%" Height="89%" margin-top="-26%" float="left" margin-left="auto" margin-right="auto" CssClass="tableSec_new">
                            <asp:TableHeaderRow Height="20%" Width="100%" BorderStyle="Solid" BorderWidth="1px">
                                <asp:TableCell CssClass="tablecell2">
                                    <asp:Label ID="Label20" runat="server" Text=" Mandant:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="cell">
                                    <asp:CheckBox ID="chkClient" ClientIDMode="Static" runat="server" CssClass="check row1 col4" />
                                </asp:TableCell>

                            </asp:TableHeaderRow>
                            <asp:TableRow Height="20%" Width="100%">
                                <asp:TableCell CssClass="tablecell3">
                                    <asp:Label ID="Label26" runat="server" Text=" Standort:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="cell">
                                    <asp:CheckBox ID="chkLocation" ClientIDMode="Static" runat="server" CssClass="check row1 col1" />
                                </asp:TableCell>

                            </asp:TableRow>

                            <asp:TableRow Height="20%" Width="100%">
                                <asp:TableCell CssClass="tablecell4">
                                    <asp:Label ID="Label27" runat="server" Text="Abteilung:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="cell">
                                    <asp:CheckBox ID="chkDepartment" runat="server" CssClass="check row2 col1" ClientIDMode="Static" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow Height="20%" Width="100%">
                                <asp:TableCell CssClass="tablecell5">
                                    <asp:Label ID="Label28" runat="server" Text="Kostenstelle:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="cell">
                                    <asp:CheckBox ID="chkCostCenter" runat="server" CssClass="check row3 col1" ClientIDMode="Static" />
                                </asp:TableCell>

                            </asp:TableRow>
                            <asp:TableRow Height="20%" Width="100%">
                                <asp:TableCell CssClass="tablecell6">
                                    <asp:Label ID="Label29" runat="server" Text="ID Nr.:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="cell">
                                    <asp:CheckBox ID="chkPersonalID" runat="server" CssClass="check row4 col1" ClientIDMode="Static" />
                                </asp:TableCell>

                            </asp:TableRow>
                            <asp:TableRow Height="20%" Width="100%">
                                <asp:TableCell CssClass="tablecell6">
                                    <asp:Label ID="Label21" runat="server" Text="Ausweis Nr.:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="cell">
                                    <asp:CheckBox ID="chkCardNumber" runat="server" CssClass="check row4 col1" ClientIDMode="Static" />
                                </asp:TableCell>

                            </asp:TableRow>
                        </asp:Table>
                    </section>
                    <section class="secFooterSprache">
                        <asp:Button ID="btnSaveGridSettings" CssClass="BottomFooterBtnsLeft_100 btnSave" runat="server" Text="<%$ Resources:localizedText, saveButton %>" />
                        <asp:Button ID="btnCloseGridSettings" CssClass="BottomFooterBtnsLeft_100 btnClose" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
                    </section>
                </section>
            </section>

            <section class="correctbookings" style="display: none;">
                <section class="sectabledirectionnew">
                    <section style="float: left; clear: both; margin-left: 23%; width: 90%; height: 10%;">
                        <asp:Label ID="Label31" runat="server" Text="Datum" CssClass="lbldatum"></asp:Label>
                        <section class="rightDivs2new">
                            <section class="last">
                                <section class="griddatemovernew">
                                    <section class="griddatemoverleftnew">
                                        <asp:Button ID="btnPrevDayCorrections" runat="server" Text="" CssClass="korbtnFvNavPrevNr" />
                                    </section>
                                    <section class="griddatemovercenternew">
                                        <%--<dx:ASPxDateEdit ID="ASPxDateEdit1" Theme="Office2003Blue" runat="server" CssClass="ddlYearStyle2">
                                    </dx:ASPxDateEdit>--%>
                                        <asp:TextBox ID="txtDateCorrections" runat="server" Style="width: 98%; height: 19px; text-align: center;" />
                                    </section>
                                    <section class="griddatemoverrightnew">
                                        <asp:Button ID="btnNextDayCorrections" runat="server" Text="" CssClass="korbtnFvNavNexNrt" />
                                    </section>
                                </section>
                            </section>
                        </section>
                    </section>
                    <section style="float: left; clear: both; width: 100%; height: 50%; overflow-y: auto;">
                        <dx:ASPxGridView ID="grdBookingsCorrection" runat="server" Width="100%" Theme="Office2003Blue" SettingsPager-PageSize="6" KeyFieldName="ID"
                            SettingsPager-ShowEmptyDataRows="True" ClientInstanceName="grdBookingsCorrection" AutoGenerateColumns="False" OnCustomCallback="grdBookingsCorrection_CustomCallback">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ID" Caption="ID" Visible="False" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTimeEditColumn Caption="Zeit" FieldName="Booking1" VisibleIndex="1">
                                    <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                        <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                        </SpinButtons>
                                        <ClientSideEvents GotFocus="function(s, e) {
	GetFocusedCell(s, e);
}" />
                                    </PropertiesTimeEdit>
                                </dx:GridViewDataTimeEditColumn>
                                <dx:GridViewDataComboBoxColumn Caption="Status" FieldName="Status1" VisibleIndex="2" ReadOnly="True">
                                    <PropertiesComboBox DataSourceID="odsStatus" TextField="StatusAbbr" ValueField="StatusNr" DropDownWidth="140px">
                                        <Columns>
                                            <dx:ListBoxColumn Caption="Status" FieldName="Status" Name="Status" ToolTip="Status" Width="100%" />
                                        </Columns>
                                        <ClientSideEvents GotFocus="function(s, e) {
	UpdateCorrectionStatus(s, e, 1);
}" />
                                        <DropDownButton Visible="False">
                                        </DropDownButton>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTimeEditColumn FieldName="Booking2" Caption="Zeit" VisibleIndex="3">
                                    <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                        <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                        </SpinButtons>
                                        <ClientSideEvents GotFocus="function(s, e) {
	GetFocusedCell(s, e);
}" />
                                    </PropertiesTimeEdit>
                                </dx:GridViewDataTimeEditColumn>
                                <dx:GridViewDataComboBoxColumn Caption="Status" FieldName="Status2" VisibleIndex="4" ReadOnly="True">
                                    <PropertiesComboBox DataSourceID="odsStatus" TextField="StatusAbbr" ValueField="StatusNr" DropDownWidth="140px">
                                        <Columns>
                                            <dx:ListBoxColumn Caption="Status" FieldName="Status" Name="Status" ToolTip="Status" Width="100%" />
                                        </Columns>
                                        <ClientSideEvents GotFocus="function(s, e) {
	UpdateCorrectionStatus(s, e, 2);
}" />
                                        <DropDownButton Visible="False">
                                        </DropDownButton>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTimeEditColumn FieldName="Booking3" Caption="Zeit" VisibleIndex="5">
                                    <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                        <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                        </SpinButtons>
                                        <ClientSideEvents GotFocus="function(s, e) {
	GetFocusedCell(s, e);
}" />
                                    </PropertiesTimeEdit>
                                </dx:GridViewDataTimeEditColumn>
                                <dx:GridViewDataComboBoxColumn Caption="Status" FieldName="Status3" VisibleIndex="6" ReadOnly="True">
                                    <PropertiesComboBox DataSourceID="odsStatus" TextField="StatusAbbr" ValueField="StatusNr" DropDownWidth="140px">
                                        <Columns>
                                            <dx:ListBoxColumn Caption="Status" FieldName="Status" Name="Status" ToolTip="Status" Width="100%" />
                                        </Columns>
                                        <ClientSideEvents GotFocus="function(s, e) {
	UpdateCorrectionStatus(s, e, 1);
}" />
                                        <DropDownButton Visible="False">
                                        </DropDownButton>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTimeEditColumn FieldName="Booking4" Caption="Zeit" VisibleIndex="7">
                                    <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                        <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                        </SpinButtons>
                                        <ClientSideEvents GotFocus="function(s, e) {
	GetFocusedCell(s, e);
}" />
                                    </PropertiesTimeEdit>
                                </dx:GridViewDataTimeEditColumn>
                                <dx:GridViewDataComboBoxColumn Caption="Status" FieldName="Status4" VisibleIndex="8" ReadOnly="True">
                                    <PropertiesComboBox DataSourceID="odsStatus" TextField="StatusAbbr" ValueField="StatusNr" DropDownWidth="140px">
                                        <Columns>
                                            <dx:ListBoxColumn Caption="Status" FieldName="Status" Name="Status" ToolTip="Status" Width="100%" />
                                        </Columns>
                                        <ClientSideEvents GotFocus="function(s, e) {
	UpdateCorrectionStatus(s, e, 2);
}" />
                                        <DropDownButton Visible="False">
                                        </DropDownButton>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                            </Columns>
                            <SettingsBehavior AllowDragDrop="False" AllowGroup="False" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="False" />

                            <SettingsPager PageSize="4" ShowEmptyDataRows="True"></SettingsPager>
                            <SettingsEditing Mode="Batch">
                                <BatchEditSettings ShowConfirmOnLosingChanges="False" />
                            </SettingsEditing>
                            <Settings ShowStatusBar="Hidden" />
                            <SettingsDataSecurity AllowInsert="False" />
                        </dx:ASPxGridView>
                    </section>
                    <section style="float: left; clear: both; width: 100%; height: 30%;">
                        <asp:Label ID="Label32" runat="server" Text="Memo Text" CssClass="lblmemo"></asp:Label>
                        <asp:TextBox ID="txtCorrectionsMemo" Columns="20" Rows="2" CssClass="memoarea" runat="server" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>

                    </section>
                    <section style="float: right; clear: both; width: 100%; height: 10%;">

                        <asp:Button ID="btnDeleteDayCorrection" runat="server" Text="löchen Tag" CssClass="btnnewclose btnLöschen" />
                        <asp:Button ID="btnDeleteCorrection" runat="server" Text="löchen Zeit" CssClass="btnnewclose btnLöschen" />
                    </section>
                </section>
                <section class="sectabledirection" style="display: none;">
                    <%--<dx:ASPxGridView ID="grdBookingsCorrection" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" ClientInstanceName="grdBookingsCorrection" KeyFieldName="ID" runat="server" AutoGenerateColumns="False" Width="100%" Theme="Office2003Blue" CssClass="readerdata" OnCustomCallback="grdBookingsCorrection_CustomCallback" OnBatchUpdate="grdBookingsCorrection_BatchUpdate">

                    <ClientSideEvents EndCallback="function(s, e) {
                        reloadAccessLogsGrid();
                        }"></ClientSideEvents>
                    <Columns>
                        <dx:GridViewDataTimeEditColumn Caption="Eingang" VisibleIndex="1" HeaderStyle-ForeColor="Green" Width="50%" FieldName="KommtBooking">
                            <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                </SpinButtons>
                            </PropertiesTimeEdit>
                            <CellStyle Font-Size="16px" VerticalAlign="Middle" Paddings-PaddingTop="14px"></CellStyle>
                        </dx:GridViewDataTimeEditColumn>

                        <dx:GridViewDataTimeEditColumn Caption="Ausgang" VisibleIndex="1" HeaderStyle-ForeColor="red" Width="50%" FieldName="GehtBooking">
                            <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                </SpinButtons>
                            </PropertiesTimeEdit>
                            <CellStyle Font-Size="16px" VerticalAlign="Middle" Paddings-PaddingTop="14px"></CellStyle>
                        </dx:GridViewDataTimeEditColumn>
                        <dx:GridViewDataTextColumn Caption="" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="" Visible="false" FieldName="PersonalNumber"></dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsBehavior AllowDragDrop="False" AllowGroup="false" AllowSelectSingleRowOnly="true" AllowSort="False" AllowSelectByRowClick="true" />
                    <SettingsPager ShowEmptyDataRows="true" Visible="False" PageSize="6"></SettingsPager>
                    <SettingsEditing Mode="Batch">
                        <BatchEditSettings ShowConfirmOnLosingChanges="False" EditMode="Cell" />
                    </SettingsEditing>

                    <Settings ShowStatusBar="Hidden" />
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="True" AllowInsert="False" />
                </dx:ASPxGridView>--%>
                </section>
            </section>
        </section>

    </div>
    <asp:ObjectDataSource ID="odsStatus" runat="server" SelectMethod="BindStatus" TypeName="Access_Control_NewMask.Content.AccessCorrection"></asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <section class="btmleft">
        <asp:Button ID="btnEntSave" CssClass="savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, savedatanew %>" />
        <asp:Button ID="btnEntEdit" CssClass="BottomFooterBtnsLeftdaten" runat="server" Text="<%$ Resources:localizedText, calculatedata %>" Style="display: none;" />


    </section>
    <section class="btmright">
        <asp:Button ID="btnSelectAll" CssClass="BottomFooterBtnsLeft btnAll" runat="server" Text="<%$ Resources:localizedText, all %>" Style="display: none" />
        <asp:Button ID="btnUnSelectAll" CssClass="BottomFooterBtnsLeft btnPicked" runat="server" Text="<%$ Resources:localizedText, unselect %>" Style="display: none" />
        <asp:Label ID="Label19" runat="server" Text="<%$ Resources:localizedText, allselectedpeople %>" CssClass="lblsendData"></asp:Label>
        <%--        <asp:TextBox ID="TextBox1" runat="server" CssClass="contentareabottomlongtxt1"></asp:TextBox>--%>

        <dx:ASPxTimeEdit ID="teBookingTime" ClientInstanceName="teBookingTime" ClientIDMode="Static" runat="server" CssClass="contentareabottomlongtxt1" HorizontalAlign="Center" Font-Size="18px">
            <SpinButtons Enabled="false" ShowIncrementButtons="false">
            </SpinButtons>
        </dx:ASPxTimeEdit>
        <asp:Button ID="btnsave" ClientIDMode="Static" CssClass="savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, book %>" Style="width: 60px; padding-top:10px;" />

    </section>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass=" backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
    <asp:Button ID="btnActHelp" CssClass=" helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
