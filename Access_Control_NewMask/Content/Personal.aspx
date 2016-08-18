<%@ Page Title="<%$ Resources:localizedText, personal %>" Language="C#" MasterPageFile="~/MasterPages/Primary.Master" AutoEventWireup="true" CodeBehind="Personal.aspx.cs" Inherits="Access_Control_NewMask.Content.Personal" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/Personal.js?v=<%= Access_Control_NewMask.Controllers.Version.JSVersion %>"></script>
    <script src="Scripts/Webcamscripts/webcam.min.js"></script>
    <script src="Scripts/TakePhoto.js"></script>
    <link href="Styles/FormViewSearch.css" rel="stylesheet" />
    <link href="Styles/Personal.css?v=<%= Access_Control_NewMask.Controllers.Version.JSVersion %>" rel="stylesheet" />
    <%--<link href="Styles/ImportantInfoDialogPersonal.css" rel="stylesheet" />--%>
    <script type="text/javascript">
        function __promptWarning(text) {
            if (text.trim() != "") $("#__WarningPrompt > .secPromptMsg").text(text);
            $("#promptsPlaceHolder, #__WarningPrompt").show();
        }
        function __hidePromptWarning() {
            $("#promptsPlaceHolder, #__WarningPrompt").hide();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="mainPersDiv">

        <div id="ImportantDialogBox"></div>
        <asp:HiddenField ID="hiddenFieldConfirmDialog" runat="server" />
        <asp:HiddenField ID="hiddenFieldSaveChanges" runat="server" />
        <asp:HiddenField ID="hiddenFieldSavePersonal" runat="server" />
        <asp:HiddenField ID="hiddenFieldIsNewPersonal" runat="server" />
        <asp:HiddenField ID="hfdHistUpdate" runat="server" />
        <asp:HiddenField ID="hiddenFieldSearchValue" runat="server" />

        <div id="ControlSection1" class="ControlSection">

            <div id="AEHeaderLeftDiv">
                <div id="BottomHeaderLabels">
                    <asp:Label ID="Label45" runat="server" Style="display: none;" Text="Mandanten Nr.:" CssClass="L1HeaderT1drplablesmandant"></asp:Label>
                    <asp:Label ID="Label50" runat="server" Text="<%$ Resources:localizedText, clientsnew %>" CssClass="L1HeaderT1drplables2"></asp:Label>
                    <asp:Label ID="lblLocationHeader" runat="server" Text="<%$ Resources:localizedText, location1 %>" CssClass="L1HeaderT1drplables"></asp:Label>
                    <asp:Label ID="lblDepartmentHeader" runat="server" Text="<%$ Resources:localizedText, department %>" CssClass="L1HeaderT1drplables"></asp:Label>
                    <asp:Label ID="lblEmployeeName" runat="server" Text="<%$ Resources:localizedText, name %>" CssClass="L1HeaderT1drplables"></asp:Label>
                    <asp:Label ID="lblPersNo" runat="server" Text="ID Nr.:" CssClass="lblNumbersShort"></asp:Label>
                    <asp:Label ID="lblIDNr" runat="server" Text="<%$ Resources:localizedText, cardNo %>" CssClass="lblNumbersShort"></asp:Label>

                    <%-- <asp:ListItem Selected="True" Value="0">keine</asp:ListItem>--%>
                </div>

                <div id="BottomHeaderLists">

                   <%-- <asp:DropDownList ID="ddlClients" runat="server" DataValueField="ID" DataTextField="Client_Nr" CssClass="L1HeaderT1drplistsmandat" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" AutoPostBack="true" Style="display: none">
                    </asp:DropDownList>--%>
                    <dx:ASPxComboBox ID="cmbClients" runat="server" ValueField="ID" TextField="Client_Nr" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                        TextFormatString="{0}" CssClass="lblMandant ColorBlue" SelectedIndex="0" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" AutoPostBack="false">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cmbClientsSelectedIndexChanged(s.GetValue());
}" />
                        <Columns>
                            <dx:ListBoxColumn FieldName="Client_Nr" Name="ProfileDescription" ToolTip="" Width="18%" />
                            <dx:ListBoxColumn FieldName="Name" Name="" ToolTip="<%$ Resources:localizedText, descriptionAccs %>" Width="42%" Visible="false" />
                            <dx:ListBoxColumn FieldName="ID" Name="" ToolTip="<%$ Resources:localizedText, descriptionAccs %>" Width="42%" Visible="false" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <%--<asp:DropDownList ID="ddlClientsName" runat="server" DataValueField="ID" DataTextField="Name" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" AutoPostBack="true" Style="display: none">
                    </asp:DropDownList>--%>
                    <dx:ASPxComboBox ID="cmbClientsName" ClientIDMode="Static" runat="server" ValueField="ID" TextField="Client_Nr" SelectedIndex="0" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                        TextFormatString="{1}" CssClass="L1HeaderT1drplists ColorBlue" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" AutoPostBack="false">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cmbClientsNameSelectedIndexChanged(s.GetValue());
}" />
                        <Columns>
                            <dx:ListBoxColumn FieldName="Client_Nr" Caption="Nr.:" Name="Mandant Nr.:" Width="20%" />
                            <dx:ListBoxColumn FieldName="Name" Caption="<%$ Resources:localizedText ,description_new%>" Name="ID" ToolTip="Bezeichnung:" Width="80%" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <%--<asp:DropDownList ID="ddllLocation" runat="server" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" AutoPostBack="true" Style="display: none">
                    </asp:DropDownList>--%>
                    <dx:ASPxComboBox ID="cmbLocation" runat="server" ValueField="ID" TextField="Name" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                        TextFormatString="{1}" CssClass="L1HeaderT1drplists ColorBlue" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cmbLocationNameSelectedIndexChanged(s.GetValue());
}" />
                        <Columns>
                            <dx:ListBoxColumn FieldName="ID" Caption="Nr." Name="" Visible="false" />
                            <dx:ListBoxColumn FieldName="Location_Nr" Caption="Nr.:" Name="" ToolTip="<%$ Resources:localizedText, descriptionAccs %>" Width="20%" />
                            <dx:ListBoxColumn FieldName="Name" Caption="<%$ Resources:localizedText ,description_new%>" Name="ProfileDescription" ToolTip="" Width="80%" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <%--<asp:DropDownList ID="ddlDepartment" runat="server" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" AutoPostBack="true" Style="display: none">
                    </asp:DropDownList>--%>
                    <dx:ASPxComboBox ID="cmbDepartment" runat="server" ValueField="ID" TextField="Client_Nr" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                        TextFormatString="{1}" CssClass="L1HeaderT1drplists ColorBlue" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cmbDepartmentSelectedIndexChanged(s.GetValue());
}" />
                        <Columns>
                            <dx:ListBoxColumn FieldName="ID" Caption="ID." Name="ID" Visible="false" />
                            <dx:ListBoxColumn FieldName="Department_Nr" Caption="Nr.:" Name="Department_Nr" ToolTip="<%$ Resources:localizedText, descriptionAccs %>" Width="20%" />
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText ,description_new%>" FieldName="Name" Name="ProfileDescription" ToolTip="" Width="80%" />
                        </Columns>
                    </dx:ASPxComboBox>
                   <%-- <asp:DropDownList ID="dpllPersName" runat="server" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" AutoPostBack="true" DataTextField="PersNr_Fullname" DataValueField="ID" Style="display: none">
                    </asp:DropDownList>--%>
                    <dx:ASPxComboBox ID="cmbPersName" runat="server" ClientInstanceName="cmbPersName" ValueType="System.Int32" ClientIDMode="Static" ValueField="Pers_Nr" EnableCallbackMode="True" OnCallback="cmbPersName_Callback"
                        TextFormatString="{1} {2}" CssClass="L1HeaderT1drplists ColorBlue" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" CallbackPageSize="10000">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cmbPersNameSelectedIndexChanged(s.GetValue());
}"
                            EndCallback="function(s, e) {
			SetLastPersNr(s);
}"
                            Init="function(s, e) {
	CountPersonal();
}"
                            BeginCallback="function(s, e) {
	//GetLastPersNr(s);
}"
                            ButtonClick="function(s, e) {
	GetLastPersNr();
}" />
                        <Columns>
                            <dx:ListBoxColumn FieldName="Pers_Nr" Caption="Pers. Nr." Name="ProfileDescription" ToolTip="" Width="18%" />
                            <dx:ListBoxColumn FieldName="FirstName" Caption="Name:" Name="FirstName" ToolTip="<%$ Resources:localizedText, descriptionAccs %>" Width="42%" />
                            <dx:ListBoxColumn FieldName="LastName" Caption="<%$ Resources:localizedText ,firstname_new%>" Name="LastName" ToolTip="<%$ Resources:localizedText, descriptionAccs %>" Width="42%" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <%--<asp:DropDownList ID="ddlIDNr" runat="server" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Style="display: none"
                        Font-Size="14px" AutoPostBack="true" DataTextField="PersonnelNr_string" DataValueField="ID">
                    </asp:DropDownList>--%>
                    <dx:ASPxComboBox ID="cmbIDNr" HorizontalAlign="left" runat="server" ClientInstanceName="cmbIDNr" ClientIDMode="Static" ValueField="Pers_Nr" TextField="Pers_Nr" EnableCallbackMode="true" AutoPostBack="false"
                        TextFormatString="{0}" CssClass="ddlNumbers ColorBlue" DropDownRows="20" DropDownWidth="100px" Theme="Office2003Blue" CallbackPageSize="10000" OnCallback="cmbIDNr_Callback">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cmbIDNrSelectedIndexChanged(s.GetValue());
}"
                            BeginCallback="function(s, e) {
	//GetLastPersNr(s);
}"
                            EndCallback="function(s, e) {
	SetLastPersNr(s);
}" />
                        <Columns>
                            <dx:ListBoxColumn FieldName="Pers_Nr" Caption="ID Nr.:" Name="ProfileDescription" ToolTip="" Width="18%" />
                        </Columns>
                    </dx:ASPxComboBox>
                   <%-- <asp:DropDownList ID="ddlAusweisNr" runat="server" CssClass="ddlNumbers" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" Style="display: none"
                        AutoPostBack="True" DataTextField="IdentificationNr_string" DataValueField="ID">
                    </asp:DropDownList>--%>
                    <dx:ASPxComboBox ID="cmbAusweisNr" HorizontalAlign="left" runat="server" ValueField="Pers_Nr" ClientInstanceName="cmbAusweisNr" ClientIDMode="Static" TextField="Card_Nr_Str" EnableCallbackMode="true" AutoPostBack="false"
                        TextFormatString="{0}" CssClass="ddlNumbers ColorBlue" DropDownRows="20" DropDownWidth="100px" Theme="Office2003Blue" CallbackPageSize="10000" OnCallback="cmbAusweisNr_Callback">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cmbAusweisNrSelectedIndexChanged(s.GetValue());
}"
                            BeginCallback="function(s, e) {
	//GetLastPersNr(s);
}"
                            EndCallback="function(s, e) {
	SetLastPersNr(s);
	setTimeout(function(ev) {
	    InitialPageLoadPanel.Hide();
	}, 10);
}" />
                        <Columns>
                            <dx:ListBoxColumn FieldName="Pers_Nr" Name="ProfileDescription" ToolTip="" Width="20%" Visible="false" />
                            <dx:ListBoxColumn FieldName="IdentificationNr_string" Caption="<%$ Resources:localizedText ,cardNo%>" Name="AusweisN" ToolTip="<%$ Resources:localizedText, descriptionAccs %>" Width="80%" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <%-- <asp:ListItem Selected="True" Value="0">keine</asp:ListItem>--%>
                </div>

            </div>

            <div id="AEHeaderRightDiv">
                <section class="empFormViewNav">
                    <section class="fvNavSearch">
                        <asp:Label ID="lblSearchAllEmp" runat="server" Text="<%$ Resources:localizedText, search %>" Style="width: 52px" />
                        <asp:Button ID="btnSearchAllEmp" runat="server" Text="" CssClass="searchAllEmp" />
                    </section>
                    <section class="fvNavPrevious">
                        <span></span>
                        <asp:Button ID="fvNavPrev" runat="server" Text="" CssClass="btnFvNavPrev" />
                    </section>

                    <section class="fvNavCurrentEmpNum">
                        <asp:Label ID="lblFvCurrentEntry" Text="<%$ Resources:localizedText, pos %>" runat="server" />
                        <asp:TextBox ID="txtFvCurrentEntry" runat="server" Width="96%" Enabled="false" />
                    </section>

                    <section class="fvNavTotalEmpNum">
                        <asp:Label ID="lblFvTotalEntries" Text="<%$ Resources:localizedText, num %>" runat="server" />
                        <asp:TextBox ID="txtFvTotalEntries" runat="server" Width="96%" Enabled="false" />
                    </section>

                    <section class="fvNavNext">
                        <span></span>
                        <asp:Button ID="fvNavNext" runat="server" Text="" CssClass="btnFvNavNext" />
                    </section>

                </section>
            </div>

            <section class="fulltxtarealbl">
                <asp:Label ID="Label74" runat="server" Text="<%$ Resources:localizedText, fulltextsearch %>" CssClass="fulltxtareanew"></asp:Label>
            </section>

            <div class="textsearcharea">
                <asp:Label ID="Label75" runat="server" Text="Name/ID Nr." CssClass="fulltxtarea"></asp:Label>

                <asp:UpdatePanel ID="upPnl_MemberNameSearch" runat="server">
                    <ContentTemplate>
                        <dx:ASPxComboBox ID="cboPersonNameSearch" ClientInstanceName="cboPersonNameSearch" runat="server" EnableCallbackMode="True" ValueField="Pers_Nr" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif"
                            Font-Size="14px" CssClass="drpmemberstext ColorBlue" Theme="Office2003Blue"
                            OnItemsRequestedByFilterCondition="cboPersonNameSearch_OnItemsRequestedByFilterCondition" OnItemRequestedByValue="cboPersonNameSearch_OnItemRequestedByValue" TextFormatString="{0} {1}"
                            DropDownStyle="DropDown" DropDownRows="20" DropDownWidth="500px">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) { cboPersonNameSearchSelectionChanged(s,e); }"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn FieldName="Pers_Nr" Caption="ID Nr.:" Name="ID" Width="20%" />
                                <dx:ListBoxColumn FieldName="FirstName" Caption="Name" Name="FirstName" Width="40%" />
                                <dx:ListBoxColumn FieldName="LastName" Caption="Vorname" Name="SurName" Width="40%" />
                            </Columns>
                            <DropDownButton Visible="False">
                            </DropDownButton>
                            <ItemStyle Wrap="True" />
                            <ButtonStyle Border-BorderStyle="None">
                                <Border BorderStyle="None" />
                            </ButtonStyle>
                        </dx:ASPxComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div id="ControlSection2">
            <div id="rightdiv1">
                <section class="upperSectionPersonal">
                    <asp:Button ID="Button1" CssClass="newstandardbutton BottomFooterBtnsLeftdocument" Enabled="false" runat="server" Text="<%$ Resources:localizedText, personal %>" Style="padding-left: 13px !important; text-align: left !important;" />
                    <asp:Button ID="btnPersonalForm" CssClass="newstandardbutton BottomFooterBtnsLeftbogen  btnbogen" runat="server" Text="<%$ Resources:localizedText, applicationForm %>" Style="padding-left: 13px !important; text-align: left !important;" OnClick="btnPersonalForm_Click" />
                    <asp:Button ID="btnPERSDOC" CssClass=" newstandardbutton BottomFooterBtnsLeftdocument btndocument " runat="server" Text="<%$ Resources:localizedText, document %>" Style="padding-left: 0px !important; text-align: left !important;"
                        OnClick="btnPERSDOC_Click" />
                    <%-- <asp:ListItem Selected="True" Value="0">keine</asp:ListItem>--%>
                </section>
                <div id="UpperDiv">
                    <div id="leftdiv">
                        <section class="topHeaderSec">
                            <section class="headerLeftSec">
                                <asp:Label ID="Label39" runat="server" Text="<%$ Resources:localizedText, clientsnew %>" CssClass="lblpersonal2lient fontweight600"></asp:Label>
                                <%--<ClientSideEvents RowDblClick="function(s, e) {
	grdPersDataRowDblClick(s, e)
}"></ClientSideEvents>--%>
                                <dx:ASPxComboBox ID="dplCompanyName" runat="server" ValueField="ID" TextField="Client_Nr"
                                    TextFormatString="{0}-{1}" CssClass="dplpersonalsplit2 ColorBlue" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" SelectedIndex="0"
                                    OnCallback="dplCompanyName_Callback">
                                    <ClientSideEvents ValueChanged="function(s, e) {
}"
                                        SelectedIndexChanged="function(s, e) {
	dplCompanyNameSelectedIndexChanged(s,e);
}" />
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="Client_Nr" Caption="Mandaten Nr." Name="ProfileDescription" ToolTip="" Width="20%" />
                                        <dx:ListBoxColumn FieldName="Name" Caption="Mandaten" Name="ID" ToolTip="<%$ Resources:localizedText, descriptionAccs %>" Width="80%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                                <asp:Button ID="btnCompany" runat="server" Enabled="true" Text="" CssClass="btnpersonalsplit ColorRed fontweight600" ClientIDMode="Static" Style="margin-top: 1px;" />
                            </section>
                            <section class="headerRightSec">
                                <section class="secSelection">
                                    <asp:Label ID="Label26" runat="server" Text="<%$ Resources:localizedText ,locationnew%>" CssClass="lblstandort2"></asp:Label>

                                    <dx:ASPxComboBox ID="cmbLocations" runat="server" ValueField="ID" TextField="Name" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                                        TextFormatString="{1}" CssClass="txtstandort ColorBlue" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue">
                                        <Columns>
                                            <dx:ListBoxColumn FieldName="ID" Caption="Nr." Name="" Visible="false" />
                                            <dx:ListBoxColumn FieldName="Location_Nr" Caption="Nr.:" Name="" ToolTip="<%$ Resources:localizedText, descriptionAccs %>" Width="20%" />
                                            <dx:ListBoxColumn FieldName="Name" Caption="<%$ Resources:localizedText ,description_new%>" Name="ProfileDescription" ToolTip="" Width="80%" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                </section>
                                <asp:Label ID="Label38" runat="server" Text="<%$ Resources:localizedText ,personalDataFromTimeAttendance%>" CssClass="lblpersonal22neww" Style="display: none;"></asp:Label>
                                <asp:Image ID="imgimport" runat="server" CssClass="imgimp" Style="display: none;" />
                            </section>
                        </section>
                        <section class="bttmSection">
                            <section class="bttmSecLeftControls">
                                <section class="secUserInput" style="display: none;">
                                    <asp:Label ID="Label40" runat="server" Text="Mandant:" CssClass="lblpersonal2lientnew fontweight600"></asp:Label>
                                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="txtpersonalcustomer ColorBlue"></asp:TextBox>
                                </section>
                                <section class="secUserInput">
                                    <asp:Label ID="Label13" runat="server" Text="ID Nr.:" CssClass="lblpersonalsplit"></asp:Label>
                                    <asp:TextBox ID="txtPersonalNr" runat="server" Enabled="true" CssClass="txtpersonalsplit numbersOnly" Style="text-align: left !important; width: 44%;"></asp:TextBox>
                                </section>
                                <section class="secUserInput">
                                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText ,name%>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="txtpersonal ColorBlue"> </asp:TextBox>
                                </section>
                                <section class="secUserInput">
                                    <asp:Label ID="Label41" runat="server" Text="<%$ Resources:localizedText ,firstName1%>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="txtpersonal ColorBlue"></asp:TextBox>

                                </section>
                                <section class="secUserInput" style="display: none;">
                                    <asp:Label ID="Label2" runat="server" Text="<%$  Resources:localizedText ,company %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                    <asp:TextBox ID="txtCompany" runat="server" CssClass="txtpersonal ColorBlue"></asp:TextBox>
                                </section>
                                <section class="secUserInput">
                                    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText,street %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                    <asp:TextBox ID="txtStreet" runat="server" CssClass="txtpersonal ColorBlue"></asp:TextBox>
                                </section>
                                <section class="secUserInput">
                                    <asp:Label ID="Label70" runat="server" Text="Nr.:" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                    <asp:TextBox ID="txtStreetNr" runat="server" Style="text-align: left;" CssClass="txtpersonal ColorBlue"></asp:TextBox>
                                </section>
                                <section class="secUserInput">
                                    <asp:Label ID="Label69" runat="server" Text="<%$ Resources:localizedText, postcode %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                    <asp:TextBox ID="txtPostalCode" runat="server" Style="text-align: left;" CssClass="txtpersonal ColorBlue"></asp:TextBox>
                                </section>
                                <section class="secUserInput">
                                    <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, loc %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                    <asp:TextBox ID="txtPhysicalAddress" runat="server" CssClass="txtpersonal ColorBlue"></asp:TextBox>
                                </section>

                                <section class="secUserInput">
                                    <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText ,personnelType1%>" CssClass="lblpersonalsplits"></asp:Label>

                                    <dx:ASPxComboBox runat="server" ID="ddlPersType" ClientInstanceName="ddlPersType" ValueField="ID" TextField="Name" EnableCallbackMode="true" DropDownRows="6"
                                        SelectedIndex="0" DropDownWidth="240px" Font-Size="14px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif"  Theme="Office2003Blue" TextFormatString="{0}" CssClass="dplpersonalsplit" OnCallback="ddlPersType_Callback">
                                        <ClientSideEvents EndCallback="function(s, e) {
	ddlPersTypeEndCallback(s,e);
}"></ClientSideEvents>
                                        <Columns>
                                            <dx:ListBoxColumn Caption="Personentyp" FieldName="Name" Name="Name" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                    <asp:Button ID="btnPersType" runat="server" Enabled="true" Text="..." CssClass="btnpersonalsplit ColorRed fontweight600" />

                                </section>
                                <section class="secUserInput" style="display: none;">
                                    <asp:Label ID="Label30" runat="server" Text="<%$ Resources:localizedText ,vehicleType%>" CssClass="lblpersonalsplit"></asp:Label>
                                    <asp:DropDownList ID="ddlCarType" runat="server" CssClass="dplpersonalsplit" AutoPostBack="false" Enabled="true">
                                    </asp:DropDownList>
                                    <asp:Button ID="btnCarType" runat="server" Text="..." CssClass="btnpersonalsplit ColorRed fontweight600" />

                                </section>
                                <section class="secUserInput" style="display: none;">
                                    <asp:Label ID="Label31" runat="server" Text="<%$ Resources:localizedText ,indicator %>" CssClass="lblpersonalsplit"></asp:Label>
                                    <asp:TextBox ID="txtCarRegNo" runat="server" CssClass="txtpersonalsplit"></asp:TextBox>
                                </section>
                            </section>
                            <section class="bttmSecRightControls">
                                <section class="secSelectionTop">
                                    <section class="secSelection" style="display: none">
                                        <%-- <asp:Label ID="Label26" runat="server" Text="<%$ Resources:localizedText ,locationnew%>" CssClass="lblstandort2"></asp:Label>

                                    <dx:ASPxComboBox ID="cmbLocations" runat="server" ValueField="ID" TextField="Name" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                                        TextFormatString="{1}" CssClass="txtstandort ColorBlue" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue">
                                        <Columns>
                                            <dx:ListBoxColumn FieldName="ID" Caption="Nr." Name="" Visible="false" />
                                            <dx:ListBoxColumn FieldName="Location_Nr" Caption="Nr.:" Name="" ToolTip="Bezeichnung:" Width="20%" />
                                            <dx:ListBoxColumn FieldName="Name" Caption="<%$ Resources:localizedText ,description_new%>" Name="ProfileDescription" ToolTip="" Width="80%" />
                                        </Columns>
                                    </dx:ASPxComboBox>--%>
                                    </section>
                                    <section class="secSelection">
                                        <asp:Label ID="Label43" runat="server" Text="<%$ Resources:localizedText ,department%>" CssClass="lblstandort"></asp:Label>

                                        <dx:ASPxComboBox ID="cmbDepartments" runat="server" ValueField="ID" TextField="Client_Nr" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                                            TextFormatString="{1}" CssClass="txtstandort ColorBlue" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue">
                                            <Columns>
                                                <dx:ListBoxColumn FieldName="ID" Caption="ID." Name="ID" Visible="false" />
                                                <dx:ListBoxColumn FieldName="Department_Nr" Caption="Nr.:" Name="Department_Nr" ToolTip="<%$ Resources:localizedText, descriptionAccs %>" Width="20%" />
                                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText ,description_new%>" FieldName="Name" Name="ProfileDescription" ToolTip="" Width="80%" />
                                            </Columns>
                                        </dx:ASPxComboBox>
                                    </section>
                                    <section class="secSelection">
                                        <asp:Label ID="Label44" runat="server" Text="<%$ Resources:localizedText ,costCenter%>" CssClass="lblstandort"></asp:Label>

                                        <dx:ASPxComboBox ID="cmbCostCenters" runat="server" ValueField="ID" TextField="Name" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                                            TextFormatString="{1}" CssClass="txtstandort ColorBlue" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue">
                                            <Columns>
                                                <dx:ListBoxColumn FieldName="ID" Caption="ID." Name="ID" Visible="false" />
                                                <dx:ListBoxColumn FieldName="CostCenter_Nr" Caption="Nr.:" Name="CostCenter_Nr" ToolTip="Nr:" Width="20%" />
                                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText ,description_new%>" FieldName="Name" Name="CostCenterBezeichnung" ToolTip="<%$ Resources:localizedText, descriptionAccs %>" Width="80%" />
                                            </Columns>
                                        </dx:ASPxComboBox>
                                    </section>
                                </section>
                                <section class="secUserInput">
                                    <asp:Label ID="Label77" runat="server" Text="<%$ Resources:localizedText ,pesrinactive%>" CssClass="lblpersonal2area fontweight600" Style="min-width: 160px;"></asp:Label>
                                    <asp:CheckBox ID="chkActivePersonal" runat="server" CssClass="chkAccssDataarea" />
                                </section>


                                <section class="secMemo">
                                    <section class="secMemoHeader">
                                        <asp:Label ID="Label42" runat="server" Text="<%$ Resources:localizedText ,memotitle%>" CssClass="lblstandortheader" />
                                    </section>
                                    <section class="secMemoText">
                                        <asp:TextBox ID="txtMemo" runat="server" CssClass="txtpersonallarge" TextMode="MultiLine" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="14px"></asp:TextBox>
                                    </section>
                                </section>
                            </section>
                        </section>
                        <section class="personalstammudata" style="display: none">
                            <section class="personalstammudataright">
                                <asp:Label ID="lblImported" runat="server" Text="<%$ Resources:localizedText ,imported%>" CssClass="lblpersimported" Visible="false" Style="display: none"></asp:Label>
                                <asp:Label ID="Label32" runat="server" Text="Dokumente" CssClass="lblpersonal22" Style="display: none"></asp:Label>
                            </section>
                        </section>
                        <section class="tab1leftsection" style="display: none">
                            <section class="tab1leftsection1">
                                <section>
                                    <asp:Label ID="lbljh" runat="server" Text="" CssClass="lblpersonal2 fontweight600" Style="display: none"></asp:Label>
                                </section>
                            </section>

                            <section class="tab1leftsection22">
                                <section style="display: none">
                                    <asp:CheckBox ID="chkImported" runat="server" />
                                </section>
                                <asp:Label ID="lbljha" runat="server" Text="" CssClass="lblpersonal2 fontweight600" Style="display: none"></asp:Label>
                                <section class="SecPersType">
                                </section>
                            </section>
                        </section>
                    </div>

                    <div id="rightdiv">
                        <section class="sectionAccessData">
                            <section class="sec1" style="display: none">
                                <asp:Label ID="Label33" runat="server" Text="<%$ Resources:localizedText ,accessData%>" CssClass="lblpersonalRightTitle"></asp:Label>

                            </section>
                            <section class="sec1">
                                <section class="sec1Divns">
                                    <asp:Label ID="Label51" runat="server" Text="<%$ Resources:localizedText ,longTermCard%>" CssClass="lblAccsssData fontweight600"></asp:Label>
                                </section>
                                <section class="sec1Divns2">
                                    <asp:TextBox ID="txtAccsDatanew" runat="server" CssClass="txtAccsDatanew" Style="text-align: left;" Enabled="false"></asp:TextBox>
                                    <asp:ImageButton ID="imgidentity" runat="server" CssClass="btnInfo2" />
                                </section>
                                <section class="sec1Divns3">
                                    <asp:Label ID="Label52" runat="server" Text="<%$ Resources:localizedText ,active %>" CssClass="lblActive"></asp:Label>
                                    <asp:CheckBox ID="chkWeekpass" runat="server" CssClass="chkAccssData" />
                                    <asp:Button ID="btnCardReaderData" runat="server" CssClass="btncardreader" Style="display: none" />

                                </section>
                                <asp:Button ID="btnPrintLongtermpass" runat="server" CssClass="btnprintarea" />

                            </section>
                            <section class="sec1">
                                <section class="sec1Divns">
                                    <asp:Label ID="Label53" runat="server" Text="<%$ Resources:localizedText ,shortTimeCard%>" CssClass="lblAccsssData fontweight600"></asp:Label>
                                </section>
                                <section class="sec1Divns2">
                                    <asp:TextBox ID="txtAccsDatanew2" runat="server" CssClass="txtAccsDatanew" Style="text-align: left;" Enabled="false"></asp:TextBox>
                                    <asp:ImageButton ID="imgSelection" runat="server" CssClass="btnInfo2" />
                                </section>
                                <section class="sec1Divns3">
                                    <asp:Label ID="Label54" runat="server" Text="<%$ Resources:localizedText ,active %>" CssClass="lblActive"></asp:Label>
                                    <asp:CheckBox ID="chkDaypass" runat="server" CssClass="chkAccssData" />
                                    <asp:Button ID="btnCardReaderData2" runat="server" CssClass="btncardreader" Style="display: none" />
                                </section>
                                <asp:Button ID="btnPrintDailypass" runat="server" CssClass="btnprintarea" />
                            </section>
                            <section class="sec1" style="display: none;">
                                <section class="sec1Divns">
                                    <asp:Label ID="lblIdNo" runat="server" Text="<%$ Resources:localizedText ,idNo%>" CssClass="lblAccsssData fontweight600"></asp:Label>
                                </section>
                                <section class="sec1Divns2">
                                    <asp:TextBox ID="txtAusweisNr" runat="server" Style="text-align: left;" CssClass="txtAccsData"></asp:TextBox>
                                </section>
                                <section class="sec1Divns3">
                                    <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText ,active %>" CssClass="lblActive"></asp:Label>
                                    <asp:CheckBox ID="chkIdentificationActive" runat="server" CssClass="chkAccssData" />

                                </section>
                            </section>

                            <section class="sec1">
                                <section class="sec1Divns">
                                    <asp:Label ID="Label9" runat="server" Text="<%$ Resources:localizedText ,idAndPinCode%>" CssClass="lblAccsssData fontweight600"></asp:Label>
                                </section>
                                <section class="sec1Divns2">
                                    <asp:TextBox ID="txtAusweisPincode" Style="text-align: left;" runat="server" CssClass="txtAccsData numbersOnly" TextMode="Password" MaxLength="4"></asp:TextBox>
                                </section>
                                <section class="sec1Divns3">
                                    <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText ,active %>" CssClass="lblActive"></asp:Label>
                                    <asp:CheckBox ID="chkPincodeActive" runat="server" CssClass="chkAccssData" />
                                </section>
                            </section>
                            <section class="sec1">
                                <section class="sec1Divns">
                                    <asp:Label ID="Label11" runat="server" Text="<%$ Resources:localizedText ,pinCodeOnly %>" CssClass="lblAccsssData fontweight600"></asp:Label>
                                </section>
                                <section class="sec1Divns2">
                                    <asp:TextBox ID="txtNurPincode" runat="server" Style="text-align: left;" Enabled="false" CssClass="txtAccsData" TextMode="Password" MaxLength="4"></asp:TextBox>
                                </section>
                                <section class="sec1Divns3">
                                    <asp:Label ID="Label12" runat="server" Text="<%$ Resources:localizedText ,active %>" CssClass="lblActive"></asp:Label>
                                    <asp:CheckBox ID="chkNurPincodeActive" Name="chkNurPincodeActive" runat="server" CssClass="chkAccssData" />
                                </section>
                            </section>
                            <section class="sec1">
                                <section class="sec1Divns">
                                    <asp:Label ID="Label14" runat="server" Text="<%$ Resources:localizedText ,securityPinCode1 %>" CssClass="lblAccsssData fontweight600"></asp:Label>
                                </section>
                                <section class="sec1Divns2">
                                    <asp:TextBox ID="txtSicherheitsPincode" runat="server" Style="text-align: left;" CssClass="txtAccsData numbersOnly" TextMode="Password" MaxLength="4"></asp:TextBox>
                                </section>
                                <section class="sec1Divns3">
                                    <asp:Label ID="Label16" runat="server" Text="<%$ Resources:localizedText ,active %>" CssClass="lblActive"></asp:Label>
                                    <asp:CheckBox ID="chkMenaceActive" runat="server" CssClass="chkAccssData" />
                                </section>
                            </section>
                            <section class="sec1fe">
                                <asp:Label ID="Label5" runat="server" Text="<%$ Resources:localizedText ,autoDerecognition2 %>" CssClass="lblDerecog"></asp:Label>
                                <asp:TextBox ID="txtAutomaticLogout" runat="server" MaxLength="5" CssClass="txtDerecognew" Style="text-align: center !important;"></asp:TextBox>
                            </section>
                            <section class="sec1facc">
                                <asp:Label ID="Label76" runat="server" Text="<%$ Resources:localizedText ,accessviaaccessplans %>" CssClass="lblDeacc"></asp:Label>
                            </section>
                            <section class="shadowarea">

                                <section class="sec1dr">
                                    <section class="secDatePck">
                                        <asp:Label ID="Label34" runat="server" Text="<%$ Resources:localizedText ,accessAuthorizationFrom %>" CssClass="lblDate"></asp:Label>
                                    </section>
                                    <section class="secDatePck2">
                                        <dx:ASPxDateEdit ID="dpAccessPlanDateFrom" HorizontalAlign="Center" runat="server" Theme="Aqua" CssClass="dateEdit" DisplayFormatString="dd.MM.yyyy">
                                            <ClientSideEvents DateChanged="function(s, e) {
	setSaveChanges();
}" />
                                        </dx:ASPxDateEdit>
                                    </section>
                                    <section class="secDatePck3">
                                        <asp:Label ID="Label35" runat="server" Text="<%$ Resources:localizedText ,toAccss %>" CssClass="lblBis"></asp:Label>
                                        <dx:ASPxDateEdit ID="dpAccessPlanDateTo" HorizontalAlign="Center" runat="server" Theme="Aqua" CssClass="dateEditNew" DisplayFormatString="dd.MM.yyyy">
                                            <ClientSideEvents DateChanged="function(s, e) {
	setSaveChanges();
}" />
                                        </dx:ASPxDateEdit>
                                    </section>
                                </section>
                                <section class="sec1fd">
                                    <section class="secDatePck">
                                        <asp:Label ID="Label36" runat="server" Text="<%$ Resources:localizedText ,accessPlanNr %>" CssClass="lblDate2"></asp:Label>
                                    </section>
                                    <section class="secDatePck2e">
                                        <asp:TextBox ID="txtZuttritsplanNr" Enabled="false" runat="server" CssClass="dateEditew"></asp:TextBox>
                                    </section>
                                    <section class="secDatePck3e">
                                        <asp:Label ID="Label48" runat="server" Text="<%$ Resources:localizedText ,descriptionnew %>" CssClass="lblDescrp"></asp:Label>
                                        <asp:TextBox ID="txtdateEdited" Enabled="false" runat="server" CssClass="dateEdited"></asp:TextBox>

                                        <asp:Label ID="Label37" runat="server" Text="<%$ Resources:localizedText ,descriptionnew %>" CssClass="lblDescrp" Style="display: none"></asp:Label>
                                        <asp:TextBox ID="txtZuttritsBezeichnung" Enabled="false" runat="server" CssClass="dateEdited" Style="display: none"></asp:TextBox>

                                        <asp:Button ID="btnSearch" runat="server" Text="" CssClass="btnSearchorange" Enabled="true" />
                                    </section>

                                </section>
                                <section class="sec1fd">
                                    <section class="secDatePck3enew">
                                    </section>
                                </section>
                            </section>
                        </section>
                        <section class="sectionFoto">
                            <section class="fotoUpload">
                                <section class="photo">
                                    <asp:Label ID="Label49" runat="server" Text="<%$ Resources:localizedText ,passportPhoto %>" CssClass="BottomFooterBtnsLeftpassport"></asp:Label>
                                    <fieldset id="PhotoFieldset" class="fieldset">
                                        <asp:HiddenField ID="photVal" ClientIDMode="Static" runat="server" />
                                        <div id="Photoholder" class="PhotoholderCls">

                                            <img id="img" runat="server" src="" />
                                        </div>
                                    </fieldset>
                                </section>

                                <section class="PhotoBtnsHolder" style="margin-left: 28%;">
                                    <asp:Button ID="btnTriggerFileUploadorig" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, insertPicture %>" CssClass="PhotoholderButtonsCls btnewphoto" Font-Size="Small" Style="display: none" />
                                    <asp:Button ID="btnTriggerFileUpload" runat="server" Text="<%$ Resources:localizedText, addPhoto %>" Font-Size="Small" CssClass="PhotoholderButtonsClsein allhover" />
                                    <asp:Button ID="btnTakeWebcamPicture" runat="server" Text="<%$ Resources:localizedText, takePhoto_new %>" Font-Size="Small" CssClass="PhotoholderButtonsClaus allhover" />
                                    <asp:Button ID="btnRemovePhoto" runat="server" Text="<%$ Resources:localizedText, deletePhoto %>" Font-Size="Small" CssClass="PhotoholderButtonsCldelete allhover" />

                                    <asp:FileUpload ID="UploadPhoto" ClientIDMode="Static" CssClass="PhotoholderButtonsClsUpload" accept=".png,.jpg,.jpeg,.gif" runat="server" />
                                </section>
                                <section class="PhotoBtnsHolder" style="display: none;">
                                    <asp:Button ID="btnRemovePhotoorig" runat="server" Text="<%$ Resources:localizedText, removePicture %>" CssClass="PhotoholderButtonsCls btdelphoto" Font-Size="Small" Style="display: none" />
                                </section>
                            </section>
                            <section class="searchareanew">
                            </section>
                        </section>
                        <section class="webCamMode" style="display: none;">
                            <section class="cameraScreen">
                                <div id="webcam" style="width: 100%; height: 100%;"></div>
                            </section>
                            <section class="acceptButtons">
                                <asp:Button ID="btnTakePhoto" runat="server" Text="<%$ Resources:localizedText, takePhoto %>" CssClass="cameraButtonsLeft " />

                                <asp:Button ID="btnClearPhoto" runat="server" Text="<%$ Resources:localizedText, clearPhoto %>" CssClass="cameraButtonsRight " />

                            </section>
                            <asp:Button ID="btnAccept" runat="server" Text="<%$ Resources:localizedText, takeover %>" CssClass="cameraButtonsLeft " />

                            <asp:Button ID="btnCancelPhoto" runat="server" Text="<%$ Resources:localizedText, cancel_New %>" CssClass="cameraButtonsRight " />
                        </section>

                        <div class="readergrid" style="display: none;">
                            <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName=" " KeyFieldName="ID" runat="server" AutoGenerateColumns="False" Width="100%" Theme="Office2003Blue" CssClass="readerdata">


                                <Columns>
                                    <dx:GridViewDataTextColumn VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText ,no2 %>" VisibleIndex="1" Width="30%" FieldName="Card">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText ,cardNo %>" VisibleIndex="2" Width="70%" FieldName="TransponderNr">
                                        <PropertiesTextEdit>
                                        </PropertiesTextEdit>

                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="left">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <SettingsBehavior AllowDragDrop="False" AllowGroup="false" AllowSelectSingleRowOnly="true" AllowSort="False" AllowSelectByRowClick="true" />
                                <SettingsPager ShowEmptyDataRows="true" Visible="False" PageSize="10"></SettingsPager>
                                <SettingsEditing EditFormColumnCount="10" Mode="Batch" NewItemRowPosition="Bottom">
                                    <BatchEditSettings EditMode="Row" ShowConfirmOnLosingChanges="False" />
                                </SettingsEditing>
                                <Settings ShowStatusBar="Hidden" />
                            </dx:ASPxGridView>
                        </div>

                    </div>
                </div>
                <div id="middiv">
                    <div id="middivTitle">
                        <asp:Label ID="lblinfo" CssClass="quickinfo" runat="server" Text="<%$ Resources:localizedText, quickinfo %>" Style="display: none;" />
                        <asp:Label ID="Label15" CssClass="quickinfotitle" runat="server" Text="<%$ Resources:localizedText, accessviaccessgroup1 %>" />
                    </div>

                    <div id="bottomdiv">
                        <section class="bottomdiv1">
                            <asp:Label ID="Label17" runat="server" Text="<%$ Resources:localizedText, dateOfBirth %>" CssClass="lblpersonal"></asp:Label>
                            <asp:Label ID="Label18" runat="server" Text="<%$ Resources:localizedText, dateofentry %>" CssClass="lblpersonal"></asp:Label>
                            <asp:Label ID="Label19" runat="server" Text="<%$ Resources:localizedText, dateofexit %>" CssClass="lblpersonal"></asp:Label>
                            <asp:Label ID="Label20" runat="server" Text="<%$ Resources:localizedText, employedas %>" CssClass="lblpersonal"></asp:Label>
                            <asp:Label ID="Label21" runat="server" Text="<%$ Resources:localizedText, nationality %>" CssClass="lblpersonal fontweight600"></asp:Label>
                        </section>

                        <section class="bottomdiv2">
                            <dx:ASPxDateEdit ID="DoBpicker" ClientIDMode="Static" CssClass="ddlYearStyle" runat="server" Theme="Aqua" Style="min-width: 88%;" DisplayFormatString="dd.MM.yyyy" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="14px" HorizontalAlign="Center">
                                <ClientSideEvents DateChanged="function(s, e) {
	setSaveChanges();
}" />
                            </dx:ASPxDateEdit>
                            <dx:ASPxDateEdit ID="DofEntry" ClientIDMode="Static" CssClass="ddlYearStyle" runat="server" Theme="Aqua" Style="min-width: 88%;" DisplayFormatString="dd.MM.yyyy" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="14px" HorizontalAlign="Center">
                                <ClientSideEvents DateChanged="function(s, e) {
	setSaveChanges();
}" />
                            </dx:ASPxDateEdit>
                            <dx:ASPxDateEdit ID="DofExit" ClientIDMode="Static" CssClass="ddlYearStyle" runat="server" Theme="Aqua" Style="min-width: 88%;" DisplayFormatString="dd.MM.yyyy" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="14px" HorizontalAlign="Center">
                                <ClientSideEvents DateChanged="function(s, e) {
	setSaveChanges();
}" />
                            </dx:ASPxDateEdit>
                            <asp:TextBox ID="txtPosition" runat="server" CssClass="txtpersonalbottom2"></asp:TextBox>
                            <asp:TextBox ID="txtNationality" runat="server" CssClass="txtpersonalbottom2"></asp:TextBox>
                        </section>

                        <section class="bottomdiv3">
                            <asp:Label ID="Label22" runat="server" Text="<%$ Resources:localizedText, companyPhone_new %>" CssClass="lblpersonal"></asp:Label>
                            <asp:Label ID="Label23" runat="server" Text="<%$ Resources:localizedText, companyMobile_new %>" CssClass="lblpersonal"></asp:Label>
                            <asp:Label ID="Label24" runat="server" Text="<%$ Resources:localizedText, privatePhone_new %>" CssClass="lblpersonal"></asp:Label>
                            <asp:Label ID="Label25" runat="server" Text="<%$ Resources:localizedText, privateMobile_new %>" CssClass="lblpersonal"></asp:Label>



                            <asp:Label ID="Label27" runat="server" Text="<%$ Resources:localizedText, companyEmail_new %>" CssClass="lblpersonal"></asp:Label>
                            <asp:Label ID="Label28" runat="server" Text="<%$ Resources:localizedText, privateEmail_new %>" CssClass="lblpersonal"></asp:Label>
                            <asp:Label ID="Label29" runat="server" Text="<%$ Resources:localizedText, documents %>" CssClass="lblpersonalnew" Style="display: none;"></asp:Label>
                        </section>

                        <section class="bottomdiv4">
                            <asp:TextBox ID="txtCompTel" runat="server" CssClass="txtpersonalbottom"></asp:TextBox>
                            <asp:TextBox ID="txtCompMobile" runat="server" CssClass="txtpersonalbottom"></asp:TextBox>
                            <asp:TextBox ID="txtPrivTel" runat="server" CssClass="txtpersonalbottom"></asp:TextBox>
                            <asp:TextBox ID="txtPrivMobile" runat="server" CssClass="txtpersonalbottom"></asp:TextBox>


                            <asp:TextBox ID="txtCompanyEmail" runat="server" CssClass="txtpersonalbottomlarge"></asp:TextBox>
                            <asp:TextBox ID="txtPrivateEmail" runat="server" CssClass="txtpersonalbottomlarge"></asp:TextBox>
                        </section>
                        <section class="accessreadergrp">
                            <dx:ASPxGridView ID="grdAccessGroups" ClientInstanceName="grdAccessGroups" runat="server" AutoGenerateColumns="False" Width="67%"
                                Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="12px" KeyFieldName="ID" OnCustomCallback="grdAccessGroups_CustomCallback"
                                Theme="Office2003Blue">
                                <SettingsEditing Mode="Batch" NewItemRowPosition="Bottom">
                                    <BatchEditSettings ShowConfirmOnLosingChanges="False" />
                                </SettingsEditing>
                                <Settings ShowStatusBar="Hidden" />
                                <SettingsBehavior AllowDragDrop="False" AllowGroup="False" AllowSort="False" />
                                <SettingsDataSecurity AllowInsert="False" />
                                <Columns>
                                    <dx:GridViewDataTextColumn VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataComboBoxColumn Caption="Nr.:" VisibleIndex="1" FieldName="GroupID"
                                        Width="12%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000">
                                        <HeaderStyle HorizontalAlign="left" />
                                        <CellStyle CssClass="specialpad"></CellStyle>
                                        <DataItemTemplate>
                                            <dx:ASPxLabel ID="lblAccessGroupNr" runat="server"
                                                Text='<%# GetAccessPlanGroup(Convert.ToInt64(Eval("GroupID"))).AccessPlanGroupNr.ToString() %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                        <EditItemTemplate>
                                            <dx:ASPxComboBox ID="cmbPersAccessGroupNr" ClientInstanceName="cmbPersAccessGroupNr" runat="server" ValueField="ID" TextField="GroupID"
                                                EnableCallbackMode="true" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" Width="100%"
                                                TextFormatString="{0}" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" OnInit="cmbPersAccessGroup_Init">
                                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
    AccessGroupIndexChanged(s, e);
}"
                                                    GotFocus="function(s, e) {
	AccessGroupFocused(s, e);
}" />
                                                <Columns>
                                                    <dx:ListBoxColumn FieldName="AccessPlanGroupNr" Caption="Nr.:" Name="Nr.:" ToolTip="Nr." Width="16%" />
                                                    <dx:ListBoxColumn FieldName="AccessPlanGroupName" Caption="Bezeichnung:" Name="" ToolTip="Bezeichnung:" Width="84%" />
                                                </Columns>
                                            </dx:ASPxComboBox>
                                        </EditItemTemplate>
                                    </dx:GridViewDataComboBoxColumn>
                                    <dx:GridViewDataComboBoxColumn Caption="<%$ Resources:localizedText, descriptionAccs %>" VisibleIndex="2" FieldName="GroupID"
                                        Width="48%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000">
                                        <HeaderStyle HorizontalAlign="left" />
                                        <DataItemTemplate>
                                            <dx:ASPxLabel ID="lblAccessGroupName" runat="server"
                                                Text='<%# GetAccessPlanGroup(Convert.ToInt64(Eval("GroupID"))).AccessPlanGroupName %>'>
                                            </dx:ASPxLabel>
                                        </DataItemTemplate>
                                        <EditItemTemplate>
                                            <dx:ASPxComboBox ID="cmbPersAccessGroupName" ClientInstanceName="cmbPersAccessGroupName" runat="server" ValueField="ID" TextField="AccessPlanGroupName"
                                                EnableCallbackMode="true" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" Width="100%"
                                                TextFormatString="{1}" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" OnInit="cmbPersAccessGroup_Init">
                                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
    AccessGroupIndexChanged(s, e);
}"
                                                    GotFocus="function(s, e) {
	AccessGroupFocused(s, e);
}" />
                                                <Columns>
                                                    <dx:ListBoxColumn FieldName="AccessPlanGroupNr" Caption="Nr.:" Name="Nr.:" ToolTip="Nr." Width="16%" />
                                                    <dx:ListBoxColumn FieldName="AccessPlanGroupName" Caption="<%$ Resources:localizedText, descriptionAccs %>" Name="" ToolTip="<%$ Resources:localizedText, descriptionAccs %>" Width="84%" />
                                                </Columns>
                                            </dx:ASPxComboBox>
                                        </EditItemTemplate>
                                    </dx:GridViewDataComboBoxColumn>
                                    <dx:GridViewDataCheckColumn Caption="<%$ Resources:localizedText, active %>" FieldName="Active" VisibleIndex="3" Width="4%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000">
                                        <HeaderStyle HorizontalAlign="center" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataCheckColumn>
                                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, from %>" FieldName="StartDate" VisibleIndex="4" Width="16%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000">
                                        <HeaderStyle HorizontalAlign="center" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, to %>" FieldName="EndDate" VisibleIndex="5" Width="16%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000">
                                        <HeaderStyle HorizontalAlign="center" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataHyperLinkColumn Caption="<%$ Resources:localizedText, info %>" VisibleIndex="6" Width="4%" FieldName="GroupID" ReadOnly="true"
                                        HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000">
                                        <PropertiesHyperLinkEdit ImageHeight="18px" ImageUrl="~/Images/FormImages/18pxorange.png" ImageWidth="18px" Target="_top" NavigateUrlFormatString="" TextFormatString="">
                                        </PropertiesHyperLinkEdit>
                                        <EditFormSettings Visible="False" />
                                        <HeaderStyle HorizontalAlign="center" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataHyperLinkColumn>
                                </Columns>
                                <SettingsPager ShowEmptyDataRows="true" Visible="False" PageSize="8"></SettingsPager>
                            </dx:ASPxGridView>
                        </section>
                        <%--  <section class="bottomdiv5">


                        </section>

                        <section class="bottomdiv6">
                            <section class="rightfloatingwidth">

                            </section>
                            <section class="rightfloatingwidth">

                            </section>
                            <section class="rightfloatingwidth">
                            </section>
                            <section class="rightfloatingwidth">
                                <asp:Label ID="Label15" runat="server" Text="<%$ Resources:localizedText ,mapping1andmapping2%>" CssClass="lblpersonalRightCont6"></asp:Label>
                            </section>
                        </section>--%>
                    </div>
                </div>
                <section class="surchpersonalinfomation" style="display: none">
                    <dx:ASPxGridView ID="grdTransponders" ClientInstanceName="grdTransponders" KeyFieldName="ID" runat="server" OnCustomCallback="grdTransponders_CustomCallback"
                        AutoGenerateColumns="False" Width="100%" Theme="Office2003Blue" OnBatchUpdate="grdTransponders_BatchUpdate"
                        Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="12px">
                        <ClientSideEvents RowClick="function(s, e) {
	SetGrdRowNum(s, e);
}"
                            EndCallback="function(s, e) {
	GetActiveTransponderNr();
}"
                            Init="function(s, e) {
	GetActiveTransponderNr();
}"
                            FocusedRowChanged="function(s, e) {
	SetGrdRowNum(s, e);
}" />
                        <Columns>
                            <dx:GridViewDataTextColumn VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption=" " VisibleIndex="1" Width="5%" FieldName="Card">
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Left"></CellStyle>
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText ,cardNo%>" VisibleIndex="2" Width="2%" FieldName="TransponderNr">
                                <CellStyle HorizontalAlign="left"></CellStyle>
                                <PropertiesTextEdit>
                                    <ClientSideEvents TextChanged="function(s, e) {
	ausweisChanged(s, e, 1);
}"></ClientSideEvents>
                                </PropertiesTextEdit>

                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataCheckColumn Caption="<%$ Resources:localizedText ,active_new%>" VisibleIndex="3" Width="8%" FieldName="TransponderActive">
                                <PropertiesCheckEdit ClientInstanceName="chkActive">
                                    <ClientSideEvents CheckedChanged="function(s, e) {
	SetActive(s, e, true);
}" />
                                </PropertiesCheckEdit>
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataCheckColumn>
                            <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText ,activatedOn%>" VisibleIndex="4" Width="10%" FieldName="ValidFrom">
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText ,expiryDate_new%>" VisibleIndex="5" Width="10%" FieldName="ValidTo">
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataHyperLinkColumn FieldName="ExtendedTo" Width="10%" Caption="<%$ Resources:localizedText ,extended %>" VisibleIndex="6">
                                <PropertiesHyperLinkEdit TextFormatString="{0:dd.MM.yyyy}">
                                </PropertiesHyperLinkEdit>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                <DataItemTemplate>

                                    <dx:ASPxHyperLink ID="lnkExtended" runat="server" NavigateUrl="#" Text='<%# (DateTime?)Eval("[ExtendedTo]") == null?
                                        ". . ." : ((DateTime)Eval("[ExtendedTo]")).ToString("dd.MM.yyyy") %>'
                                        ForeColor="#0094FF" CssClass="lnkTransponders">
                                        <ClientSideEvents Click="function(s,e) {
                                            ShowEndingDates(s, e);
                                        }" />
                                    </dx:ASPxHyperLink>
                                </DataItemTemplate>
                                <EditItemTemplate>
                                    <dx:ASPxHyperLink ID="lnkExtended" runat="server" NavigateUrl="#" Text='<%# (DateTime?)Eval("[ExtendedTo]") == null?
                                        ". . ." : ((DateTime)Eval("[ExtendedTo]")).ToString("dd.MM.yyyy") %>'
                                        ForeColor="#0094FF" CssClass="lnkTransponders">
                                        <ClientSideEvents Click="function(s,e) {
                                            ShowEndingDates(s, e);
                                        }" />
                                    </dx:ASPxHyperLink>
                                </EditItemTemplate>
                            </dx:GridViewDataHyperLinkColumn>
                            <dx:GridViewDataCheckColumn Caption="<%$ Resources:localizedText ,inactive_new%>" VisibleIndex="7" Width="10%" FieldName="TransponderInActive">
                                <PropertiesCheckEdit ClientInstanceName="chkInactive">
                                    <ClientSideEvents CheckedChanged="function(s, e) {
	SetActive(s, e, false);
}" />
                                </PropertiesCheckEdit>
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataCheckColumn>
                            <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText ,inactiveFrom%>" VisibleIndex="8" Width="10%" FieldName="TransponderDeactivatedOn">
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                <PropertiesDateEdit ClientInstanceName="drpGrdInactiveDate">
                                </PropertiesDateEdit>
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText ,actions%>" VisibleIndex="9" Width="10%" FieldName="Action" ReadOnly="True">
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Memo:" VisibleIndex="10" Width="31%" FieldName="Memo">
                                <HeaderStyle HorizontalAlign="Left" />
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsBehavior AllowDragDrop="False" AllowGroup="false" AllowSelectSingleRowOnly="true" AllowSort="False" AllowSelectByRowClick="true" />
                        <SettingsPager ShowEmptyDataRows="true" Visible="False" PageSize="10"></SettingsPager>
                        <SettingsEditing EditFormColumnCount="10" Mode="Batch" NewItemRowPosition="Bottom">
                            <BatchEditSettings EditMode="Row" ShowConfirmOnLosingChanges="False" />
                        </SettingsEditing>
                        <Settings ShowStatusBar="Hidden" />
                    </dx:ASPxGridView>
                    <section class="surchpersonalinfomationbtm">
                        <section class="lblAuswe">
                            <asp:Label ID="Label8" runat="server" Text="" CssClass=""></asp:Label>
                        </section>
                        <section class="lblAuswe1new">
                            <asp:Label ID="Label55" runat="server" Text="<%$ Resources:localizedText ,idCards%>"></asp:Label>
                        </section>
                        <section class="lblAusweActive">
                            <asp:Label ID="Label56" runat="server" Text="" CssClass="" Style="text-align: center; display: block;"></asp:Label>
                        </section>
                        <section class="lblAuswe1">
                            <asp:Label ID="Label57" runat="server" Text="" CssClass=""></asp:Label>
                        </section>
                        <section class="lblAuswe3">
                            <asp:Label ID="Label58" runat="server" Text="" CssClass=""></asp:Label>
                        </section>
                        <section class="lblAuswe3">
                            <asp:Label ID="Label59" runat="server" Text="" CssClass=""></asp:Label>
                        </section>
                        <section class="lblAuswe3">
                            <asp:Label ID="Label60" runat="server" Text="" CssClass=""></asp:Label>
                        </section>
                        <section class="lblAuswe3">
                            <asp:Label ID="Label61" runat="server" Text="<%$ Resources:localizedText ,actions%>" CssClass=""></asp:Label>
                        </section>
                        <section class="lblAuswe3action">
                            <asp:Label ID="Label62" runat="server" Text="" CssClass=""></asp:Label>
                        </section>
                        <section class="lblAuswe4">
                            <asp:Label ID="Label63" runat="server" Text="" CssClass=""></asp:Label>
                        </section>
                    </section>
                </section>
                <section class="Dailystatement" style="display: none">
                    <dx:ASPxGridView ID="grdTranspondersShortTerm" ClientInstanceName="grdTranspondersShortTerm" KeyFieldName="ID" runat="server" AutoGenerateColumns="False"
                        Width="100%" Theme="Office2003Blue" OnCustomCallback="grdTranspondersShortTerm_CustomCallback" OnBatchUpdate="grdTranspondersShortTerm_BatchUpdate"
                        Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="12px">
                        <ClientSideEvents RowClick="function(s, e) {
	SetGrdRowNum(s, e);
}"
                            EndCallback="function(s, e) {
    if (saveTransponders) {
        saveTransponders = false;
        cmbPersName.PerformCallback(LastPersValue + ';' + '0');
        cmbIDNr.PerformCallback(LastPersValue + ';' + '0');
        cmbAusweisNr.PerformCallback(LastPersValue + ';' + '0');
    }
	GetActiveSTTransponderNr();
}"
                            Init="function(s, e) {
	GetActiveSTTransponderNr();
}"
                            FocusedRowChanged="function(s, e) {
	SetGrdRowNum(s, e);
}" />
                        <Columns>
                            <dx:GridViewDataTextColumn VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption=" " VisibleIndex="1" Width="5%" FieldName="Card">
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Left"></CellStyle>
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText ,cardNo%>" VisibleIndex="2" Width="2%" FieldName="TransponderNr">
                                <PropertiesTextEdit>
                                    <ClientSideEvents TextChanged="function(s, e) {
	ausweisChanged(s, e, 2);
}"></ClientSideEvents>
                                </PropertiesTextEdit>

                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Left">
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataCheckColumn Caption="<%$ Resources:localizedText ,active%>" VisibleIndex="3" Width="8%" FieldName="TransponderActive">
                                <PropertiesCheckEdit>
                                    <ClientSideEvents CheckedChanged="function(s, e) {
    if (s.GetChecked()) {
	    activeCheckedChanged(s, e, 2);
    }
}"></ClientSideEvents>
                                </PropertiesCheckEdit>

                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataCheckColumn>
                            <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText ,activatedOn%>" VisibleIndex="4" Width="10%" FieldName="ValidFrom">
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText ,expiryDate_new%>" VisibleIndex="5" Width="10%" FieldName="ValidTo">
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                            </dx:GridViewDataDateColumn>
                            <%--                 <dx:GridViewDataDateColumn Caption="Verlängert:" VisibleIndex="6" Width="10%" FieldName="ValidTo">
                                  <HeaderStyle HorizontalAlign="Center" />
                              </dx:GridViewDataDateColumn>
                               <dx:GridViewDataCheckColumn Caption="Inaktiv:" VisibleIndex="7" Width="10%" FieldName="TransponderInActive">
                                  <HeaderStyle HorizontalAlign="Center" />
                              </dx:GridViewDataCheckColumn>
                              <dx:GridViewDataDateColumn Caption="Inaktiv ab:" VisibleIndex="8" Width="10%" FieldName="TransponderDeactivatedOn">
                                   <HeaderStyle HorizontalAlign="Center" />
                              </dx:GridViewDataDateColumn>
                              <dx:GridViewDataTextColumn Caption="Aktionen:" VisibleIndex="9" Width="10%" FieldName="Action">
                                   <HeaderStyle HorizontalAlign="Center" />
                              </dx:GridViewDataTextColumn>
                              <dx:GridViewDataTextColumn Caption="Memo:" VisibleIndex="10" Width="31%" FieldName="Memo">
                                   <HeaderStyle HorizontalAlign="Left" />
                              </dx:GridViewDataTextColumn>--%>
                        </Columns>
                        <SettingsBehavior AllowDragDrop="False" AllowGroup="false" AllowSelectSingleRowOnly="true" AllowSort="False" AllowSelectByRowClick="true" />
                        <SettingsPager ShowEmptyDataRows="true" Visible="False" PageSize="10"></SettingsPager>
                        <SettingsEditing EditFormColumnCount="10" Mode="Batch" NewItemRowPosition="Bottom">
                            <BatchEditSettings EditMode="Row" ShowConfirmOnLosingChanges="False" />
                        </SettingsEditing>
                        <Settings ShowStatusBar="Hidden" />
                    </dx:ASPxGridView>
                    <section class="surchpersonalinfomationbtm">
                        <asp:Label ID="Label64" runat="server" Text="" CssClass="lblAusweselect"></asp:Label>
                        <asp:Label ID="Label65" runat="server" Text="<%$ Resources:localizedText,idCards %>" CssClass="lblAuswe1neworig"></asp:Label>
                        <asp:Label ID="Label66" runat="server" Text="" CssClass="lblAuswe1newselect"></asp:Label>
                        <asp:Label ID="Label67" runat="server" Text="" CssClass="lblAuswe1select"></asp:Label>
                        <asp:Label ID="Label68" runat="server" Text="" CssClass="lblAuswe3new"></asp:Label>
                        <%--<asp:Label ID="Label69" runat="server" Text="" CssClass="lblAuswe3"></asp:Label>
                           <asp:Label ID="Label70" runat="server" Text="" CssClass="lblAuswe3"></asp:Label>
                           <asp:Label ID="Label71" runat="server" Text="Aktionen:" CssClass="lblAuswe3"></asp:Label>
                           <asp:Label ID="Label72" runat="server" Text="" CssClass="lblAuswe3action"></asp:Label>
                           <asp:Label ID="Label73" runat="server" Text="" CssClass="lblAuswe4"></asp:Label>--%>
                    </section>
                </section>
            </div>
            <div id="rightdiv2">
                <div class="Wrappernew">
                    <div id="Grid" class="Grid">
                        <dx:ASPxGridView ID="grdPersType" runat="server" CellPadding="4" ForeColor="#333333" Width="100%" GridLines="Both" Theme="Office2003Blue" OnCustomCallback="grdPersType_CustomCallback"
                            AutoGenerateColumns="False" KeyFieldName="ID" ClientInstanceName="grdPersType" OnHtmlDataCellPrepared="grdPersType_HtmlDataCellPrepared" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="14px" SettingsPager-PageSize="14">
                            <ClientSideEvents RowClick="function(s, e) {
	grdPersTypeRowClick(s,e);
}"
                                RowDblClick="function(s, e) {
	grdPersTypeRowDbClick(s,e);
}"></ClientSideEvents>
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText,name2 %>" VisibleIndex="1" FieldName="Name" Width="40%">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText,memo %>" VisibleIndex="2" FieldName="Memo" Width="50%">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Color" VisibleIndex="3" Visible="false" FieldName="PersTypeColor" Width="10%">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText,color %>" Name="TypeColor" VisibleIndex="4" FieldName="" Width="10%">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="False" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="false" AllowDragDrop="false" />
                            <SettingsPager Mode="ShowAllRecords" ShowEmptyDataRows="True">
                            </SettingsPager>
                            <SettingsDataSecurity AllowDelete="False" AllowEdit="false" AllowInsert="false" />
                        </dx:ASPxGridView>
                    </div>

                    <div id="Grid2" class="Grid2">
                        <section style="display: none">
                            <%--<asp:DropDownList ID="ddlPersTypePopup" runat="server" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" AutoPostBack="true" DataSourceID="odsgrdPersonType" DataTextField="Name" DataValueField="ID">
                        </asp:DropDownList>--%>
                        </section>
                        <section id="fvSec2" style="width: 100%; height: 100%">
                            <section>
                                <asp:Label ID="Label71" runat="server" Text="<%$ Resources:localizedText, name %>" CssClass="lblptype" Style="width: 6%; margin-left: 1px;"></asp:Label>
                                <asp:TextBox ID="txtPersType" runat="server" CssClass="txtptype"></asp:TextBox>
                            </section>
                            <section>
                                <asp:Label ID="Label72" runat="server" Text="Memo:" CssClass="lblptype" Style="width: 7%;"></asp:Label>
                                <asp:TextBox ID="txtPersTypeMemo" runat="server" CssClass="txtpmemo" Style="width: 28%; float: left"></asp:TextBox>
                                <asp:Label ID="Label73" runat="server" Text="<%$ Resources:localizedText,color_new %>" CssClass="lblptype" Style="width: 5.5%;"></asp:Label>
                                <dx:ASPxColorEdit ID="dbPersTypeColor" ClientInstanceName="dbPersTypeColor" runat="server" AllowUserInput="false" Theme="Office2003Blue" CssClass="colorEditTwo" EnableCustomColors="true">
                                    <ColorIndicatorStyle CssClass="colorIndicator"></ColorIndicatorStyle>
                                    <DropDownButton Image-Url="../Images/FormImages/paint-brush.png"></DropDownButton>
                                    <%--<DropDownButton Text="..."></DropDownButton>--%>
                                </dx:ASPxColorEdit>
                                <asp:TextBox ID="txtPersTypeId" runat="server" CssClass="txtpmemo" Style="display: none" EnableCustomColors="True"></asp:TextBox>
                            </section>
                            <%--  <asp:FormView ID="fvPerstype" runat="server" CssClass="fvSection" DataSourceID="odsPersonType" DataKeyNames="ID" OnModeChanged="fvPerstype_ModeChanged">
                            <EmptyDataTemplate>
                                <section>
                                    <asp:Label ID="Label46" runat="server" Text="<%$ Resources:localizedText, name %>" CssClass="lblptype"></asp:Label>
                                    <asp:TextBox ID="txtPersName" runat="server" Enabled="false" CssClass="txtptype" Text='<%# Bind("Name") %>'></asp:TextBox>
                                </section>
                                <section>
                                    <asp:Label ID="Label47" runat="server" Text="<%$ Resources:localizedText, memo %>" CssClass="lblptype"></asp:Label>
                                    <asp:TextBox ID="txtPersMemo" runat="server" Enabled="false" CssClass="txtpmemo" Text='<%# Bind("Memo") %>'></asp:TextBox>
                                </section>
                            </EmptyDataTemplate>
                            <ItemTemplate>
                                <section>
                                    <asp:Label ID="Label46" runat="server" Text="<%$ Resources:localizedText, name %>" CssClass="lblptype"></asp:Label>
                                    <asp:TextBox ID="txtPersName" runat="server" Enabled="false" CssClass="txtptype" Text='<%# Bind("Name") %>'></asp:TextBox>
                                </section>
                                <section>
                                    <asp:Label ID="Label47" runat="server" Text="<%$ Resources:localizedText, memo %>" CssClass="lblptype"></asp:Label>
                                    <asp:TextBox ID="txtPersMemo" runat="server" Enabled="false" CssClass="txtpmemo" Text='<%# Bind("Memo") %>'></asp:TextBox>
                                </section>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <section>
                                    <asp:Label ID="Label46" runat="server" Text="<%$ Resources:localizedText, name %>" CssClass="lblptype"></asp:Label>
                                    <asp:TextBox ID="txtPersName" runat="server" Enabled="true" CssClass="txtptype" Text='<%# Bind("Name") %>'></asp:TextBox>
                                </section>
                                <section>
                                    <asp:Label ID="Label47" runat="server" Text="<%$ Resources:localizedText, memo %>" CssClass="lblptype"></asp:Label>
                                    <asp:TextBox ID="txtPersMemo" runat="server" Enabled="true" CssClass="txtpmemo" Text='<%# Bind("Memo") %>'></asp:TextBox>
                                </section>
                            </EditItemTemplate>
                        </asp:FormView>--%>
                        </section>
                    </div>

                    <section class="ActionBtnsBottom">
                        <asp:Button ID="btnNewPersType" CssClass="GridFooterBtnsLeft newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newButton %>" Style="width: 38px !important;" />
                        <asp:Button ID="btnEditPersType" CssClass="GridFooterBtnsLeft btnEdit" runat="server" Text="<%$ Resources:localizedText, editing %>" Style="display: none" />
                        <asp:Button ID="btnSavePersType" CssClass="GridFooterBtnsLeft savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, saveButton %>" />
                        <asp:Button ID="btnDeletePersType" CssClass="GridFooterBtnsLeft deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deleteButton %>" />
                        <asp:Button ID="btnapply2" CssClass="GridFooterBtnsLeft editbtnfooterorange" runat="server" Text="<%$ Resources:localizedText, takeover %>" Style="width: 86px; margin-left: 181px;" />
                        <asp:Button ID="btnPersTypeBack" CssClass="BottomFooterBtnsRight backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" Style="display: none;" />
                    </section>
                </div>
            </div>
            <div id="rightdiv3">
                <div class="Wrappernew3">
                    <div id="GridIdNr" class="gridIdNr">
                        <dx:ASPxGridView ID="grdVehicleTypes" ClientInstanceName="grdVehicleTypes" KeyFieldName="ID" EnableCallBacks="false" runat="server" CellPadding="4" ForeColor="#333333" Width="100%" GridLines="Both" Theme="Office2003Blue" AutoGenerateColumns="False" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="14px">
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, manufacturer1 %>" VisibleIndex="1" FieldName="Name">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, typevehicle1 %>" VisibleIndex="2" FieldName="Type">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="False" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsBehavior AllowFocusedRow="true" AllowDragDrop="false" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="true" ProcessSelectionChangedOnServer="True" />
                            <SettingsPager PageSize="17" ShowEmptyDataRows="True" Visible="False">
                            </SettingsPager>
                            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        </dx:ASPxGridView>
                    </div>

                    <div id="Grid3" class="Grid2">
                        <section style="display: none">
                            <asp:DropDownList ID="ddlVehicleType" runat="server" Visible="true" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" AutoPostBack="true">
                            </asp:DropDownList>
                        </section>
                        <section id="fvSec3" style="width: 100%; height: 100%">
                            <asp:FormView ID="fvCarType" runat="server" DataKeyNames="ID" CssClass="fvSection">
                                <EmptyDataTemplate>
                                    <section>
                                        <asp:Label ID="Label46" runat="server" Text="<%$ Resources:localizedText,manufacturer12 %>" CssClass="lblptype"></asp:Label>
                                        <asp:TextBox ID="txtVehicleName" runat="server" Enabled="false" CssClass="txtptype" Text='<%# Bind("Name") %>'></asp:TextBox>
                                    </section>
                                    <section>
                                        <asp:Label ID="Label47" runat="server" Text="<%$ Resources:localizedText,cartype2 %>" CssClass="lblptype"></asp:Label>
                                        <asp:TextBox ID="txtVehicleType" runat="server" Enabled="false" CssClass="txtpmemo" Text='<%# Bind("Type") %>'></asp:TextBox>
                                    </section>
                                </EmptyDataTemplate>
                                <ItemTemplate>
                                    <section>
                                        <asp:Label ID="Label46" runat="server" Text="<%$ Resources:localizedText,manufacturer12 %>" CssClass="lblptype"></asp:Label>
                                        <asp:TextBox ID="txtVehicleName" runat="server" Enabled="false" CssClass="txtptype" Text='<%# Bind("Name") %>'></asp:TextBox>
                                    </section>
                                    <section>
                                        <asp:Label ID="Label47" runat="server" Text="<%$ Resources:localizedText,cartype2 %>" CssClass="lblptype"></asp:Label>
                                        <asp:TextBox ID="txtVehicleType" runat="server" Enabled="false" CssClass="txtpmemo" Text='<%# Bind("Type") %>'></asp:TextBox>
                                    </section>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <section>
                                        <asp:Label ID="Label46" runat="server" Text="<%$ Resources:localizedText,manufacturer12 %>" CssClass="lblptype"></asp:Label>
                                        <asp:TextBox ID="txtVehicleName" runat="server" CssClass="txtptype" Text='<%# Bind("Name") %>' Enabled="true"></asp:TextBox>
                                    </section>
                                    <section>
                                        <asp:Label ID="Label47" runat="server" Text="<%$ Resources:localizedText,cartype2 %>" CssClass="lblptype"></asp:Label>
                                        <asp:TextBox ID="txtVehicleType" runat="server" CssClass="txtpmemo" Text='<%# Bind("Type") %>' Enabled="true"></asp:TextBox>
                                    </section>
                                </EditItemTemplate>
                            </asp:FormView>
                        </section>
                    </div>

                    <section class="ActionBtnsBottom">
                        <asp:Button ID="btnNewCarType" CssClass="GridFooterBtnsLeft btnNew" runat="server" Text="<%$ Resources:localizedText, newButton %>" />
                        <asp:Button ID="btnEditCarType" CssClass="GridFooterBtnsLeft btnEdit" runat="server" Text="<%$ Resources:localizedText, editing %>" />
                        <asp:Button ID="btnSaveCarType" CssClass="GridFooterBtnsLeft btnSave" runat="server" Text="<%$ Resources:localizedText, saveButton %>" />
                        <asp:Button ID="btnDeleteCarType" CssClass="GridFooterBtnsLeft btnLöschen" runat="server" Text="<%$ Resources:localizedText, deleteButton %>" />
                        <asp:Button ID="btnCarTypeBack" CssClass="BottomFooterBtnsRight btnClose" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
                    </section>
                </div>
            </div>

            <div id="rightdiv5" style="display: none;">
                <div class="Wrappernew3">
                    <div id="GridIdNr4" class="gridIdNr4">
                        <dx:ASPxGridView ID="grdClients" runat="server" CellPadding="4" ClientInstanceName="grdClients" KeyFieldName="ID" ClientIDMode="Static" ForeColor="#333333" Width="100%" GridLines="Both" Theme="Office2003Blue" AutoGenerateColumns="False"
                            font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="14px" OnCustomCallback="grdClients_CustomCallback">
                            <ClientSideEvents RowClick="function(s, e) {
	grdvwgrdClientsRowClick(s, e)
}"
                                RowDblClick="function(s, e) {
    grdClientsClientsRowDblClick(s, e)
}"
                                EndCallback="function(s, e) {
    dplCompanyName.PerformCallback();
}"></ClientSideEvents>
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, clientNr %>" VisibleIndex="1" FieldName="Client_Nr" Width="15%">
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, client_new %>" VisibleIndex="2" FieldName="Name" Width="85%">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="False" VisibleIndex="0">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsBehavior AllowFocusedRow="true" AllowDragDrop="false" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="true" ProcessSelectionChangedOnServer="True" />
                            <SettingsPager PageSize="18" ShowEmptyDataRows="True" Visible="False">
                            </SettingsPager>
                            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        </dx:ASPxGridView>
                    </div>

                    <div id="Grid4" class="Grid4">
                        <section style="display: none">
                            <asp:DropDownList ID="DropDownList2" runat="server" Visible="true" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" AutoPostBack="true">
                            </asp:DropDownList>
                        </section>
                        <section id="fvSec4" style="width: 100%; height: 100%">
                            <section>
                                <asp:Label ID="Label47" runat="server" Text="<%$ Resources:localizedText, clientNr %>" CssClass="lblptype" Style="min-width: 82px;"></asp:Label>

                                <asp:TextBox ID="txtClientNr" runat="server" CssClass="txtptype" Text='<%# Bind("Name") %>' Enabled="true" Style="width: 19%;"></asp:TextBox>
                            </section>
                            <section>
                                <asp:Label ID="Label46" runat="server" Text="<%$ Resources:localizedText, client_new %>" CssClass="lblptype" Style="margin-left: 46px;"></asp:Label>
                                <asp:TextBox ID="txtClientName" runat="server" CssClass="txtpmemo" Text='<%# Bind("Type") %>' Enabled="true"></asp:TextBox>
                            </section>


                        </section>
                    </div>

                    <section class="ActionBtnsBottom">
                        <asp:Button ID="btnNewClient" ClientIDMode="Static" CssClass="GridFooterBtnsLeft newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newButton %>" Style="width: 33px; padding: 0px;" />
                        <asp:Button ID="btnSaveClient" CssClass="GridFooterBtnsLeft savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, saveButton %>" />
                        <asp:Button ID="btnDeleteClient" CssClass="GridFooterBtnsLeft deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deleteButton %>" />
                        <asp:Button ID="btnapply" CssClass="GridFooterBtnsLeft editbtnfooterorange" runat="server" Text="<%$ Resources:localizedText, takeover %>" Style="width: 86px; margin-left: 159px;" />
                        <asp:Button ID="btnCompanyBack" CssClass="BottomFooterBtnsRight backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" Style="display: none;" />
                    </section>
                </div>
            </div>
            <div id="gridSearch" class="searchContact" style="display: none;">
                <section class="SecApplyAccesslanGrid">
                    <dx:ASPxGridView ID="grdChangePlan" runat="server" AutoGenerateColumns="False" Theme="Office2003Blue" Width="100%" ClientInstanceName="grdChangePlan" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important"
                        Font-Size="12px" KeyFieldName="ID" OnCustomCallback="grdChangePlan_CustomCallback">
                        <ClientSideEvents RowDblClick="function(s, e) {
	AddEditPersonnelToPlan(s, e);
}"
                            RowClick="function(s, e) {
	if(ASPxClientUtils.touchUI) { AddEditPersonnelToPlan(s, e); }
}" />
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, groupNo_new %>" VisibleIndex="1" FieldName="AccessGroupNumber">
                                <CellStyle HorizontalAlign="Left"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, groupDescription_new %>" VisibleIndex="2" FieldName="AccessGroupName">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, accessPlanNo_new %>" VisibleIndex="3" FieldName="AccessPlanNumber">
                                <CellStyle HorizontalAlign="Left"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, accessPlanDescription_new %>" VisibleIndex="4" FieldName="AccessPlanName">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="false" AllowDragDrop="false"></SettingsBehavior>
                        <SettingsPager PageSize="31" ShowEmptyDataRows="True" Visible="false">
                        </SettingsPager>
                    </dx:ASPxGridView>
                </section>
                <section class="SecApplyAccesslan">
                    <asp:Button ID="btnApplyAccessPlan" runat="server" Text="<%$ Resources:localizedText, takeover %>" CssClass="ubernahme" Style="margin-top: 10px !important;" />
                </section>

            </div>
            <div id="searchPersData" class="searchPersonnelData" style="display: none;">
                <div style="float: left; height: 98%; width: 100%; overflow-y: auto;">
                    <dx:ASPxGridView ID="grdPersData" SettingsBehavior-AllowSort="false" ClientInstanceName="grdPersData" runat="server" Width="100%" KeyFieldName="Pers_Nr" AutoGenerateColumns="False" Theme="Office2003Blue" EnableTheming="True">
                        <ClientSideEvents
                            RowDblClick="function(s, e) {
	BindSelectedPers(s.GetRowKey(e.visibleIndex));
}"
                            EndCallback="function(s, e) {
    setTimeout(function(ev) {
        SetValues( cmbPersName.GetValue() );
    }, 1000);
    CountPersonal();
}"></ClientSideEvents>
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="Pers_Nr" Visible="False" VisibleIndex="0" FieldName="ID">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, personnelNo2 %>" VisibleIndex="1" FieldName="Pers_Nr" Width="4%">
                                <CellStyle HorizontalAlign="Left"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, identification %>" VisibleIndex="2" FieldName="Card_Nr" Width="4%">
                                <CellStyle HorizontalAlign="Left"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, lastName %>" VisibleIndex="3" FieldName="LastName" Width="18%">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, firstName %>" VisibleIndex="4" FieldName="FirstName" Width="18%">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, location2 %>" VisibleIndex="5" FieldName="LocationName" Width="18%">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, depatmentTitle %>" VisibleIndex="6" FieldName="DepartmentName" Width="18%">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, costcenter2%>" VisibleIndex="7" FieldName="CostCenterName" Width="18%">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewCommandColumn Caption="<%$ Resources:localizedText, selection%>" Visible="false" ShowSelectCheckbox="True" ShowClearFilterButton="True" VisibleIndex="8" />

                        </Columns>

                        <SettingsPager ShowEmptyDataRows="true" Mode="ShowAllRecords" Visible="False"></SettingsPager>
                        <SettingsBehavior AllowSort="false" AllowDragDrop="false" AllowFocusedRow="true" AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" />
                        <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                    </dx:ASPxGridView>
                </div>
                <asp:Button ID="btnApplyPersonnel" runat="server" Text="<%$ Resources:localizedText, takeover %>" CssClass="ubernahme" />
            </div>
        </div>

        <div id="transponderInactiveHist" tabindex="-22"
            style="display: none; height: 160px; border: 1px solid black; width: 140px; background: #FEF2CE; outline: none; padding: 1px;">
            <dx:ASPxGridView ID="grdTransponderInactiveHist" runat="server" Width="100%" AutoGenerateColumns="False" Theme="Office2003Blue" KeyFieldName="ID"
                Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TabIndex="-23" OnCustomCallback="grdTransponderInactiveHist_CustomCallback">
                <ClientSideEvents RowClick="function(s, e) {
	CheckTransponderInactiveDate(s, e);
}"></ClientSideEvents>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" VisibleIndex="0" Visible="false"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Date" FieldName="ExtendedTo" VisibleIndex="1">
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" ClientInstanceName="drpGrdHistInactiveDate" EnableClientSideAPI="True">
                            <ClientSideEvents
                                DateChanged="function(s, e) {
	SetTransponderInactiveDate(s, e);
}" />
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                </Columns>

                <SettingsBehavior AllowDragDrop="False" AllowGroup="False" AllowSelectSingleRowOnly="True" AllowSort="False" />

                <SettingsPager Visible="False" Mode="ShowAllRecords"></SettingsPager>
                <SettingsEditing Mode="Batch">
                    <BatchEditSettings ShowConfirmOnLosingChanges="False" />
                </SettingsEditing>
                <Settings ShowStatusBar="Hidden" ShowColumnHeaders="False" />
                <SettingsText EmptyDataRow=" " />
                <SettingsDataSecurity AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
            </dx:ASPxGridView>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnNewAusweis" runat="server" Text="<%$ Resources:localizedText, newCard %>" CssClass="btnAuswesNew" Style="display: none !important;" />
    <asp:Button ID="btnSaveAusweis" runat="server" Text="<%$ Resources:localizedText, saveCard %>" CssClass="btnAuswesSave" />
    <asp:Button ID="btnDeleteAusweis" runat="server" Text="<%$ Resources:localizedText, deleteCard %>" CssClass="btnAuswesDelete" />

    <asp:Button ID="btnNew" CssClass="BottomFooterBtnsLeft newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newPersonal %>" />
    <asp:Button ID="btnSave" CssClass="BottomFooterBtnsLeft savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, savePersonal %>" />
    <asp:Button ID="btnDelete" CssClass="BottomFooterBtnsLeft deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deletePersonal %>" />
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
    <asp:Button ID="btnHelp" ClientIDMode="Static" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
