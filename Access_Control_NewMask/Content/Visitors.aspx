<%@ Page Title="<%$ Resources:localizedText, visitorsData %>" Language="C#" MasterPageFile="~/MasterPages/Primary.Master" AutoEventWireup="true" CodeBehind="Visitors.aspx.cs" Inherits="Access_Control_NewMask.Content.Visitors" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/Visitors.js?v=<%= Access_Control_NewMask.Controllers.Version.JSVersion %>"></script>
    <script src="Scripts/Webcamscripts/webcam.min.js"></script>
    <link href="Styles/Visitors.css?v=<%= Access_Control_NewMask.Controllers.Version.JSVersion %>" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/TakePhoto.js"></script>
    <link href="Styles/SerchClientCompany.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <asp:HiddenField ID="hiddenFieldVisitInstanceId" runat="server" />
    <asp:HiddenField ID="hiddenFieldVisitInstanceIdNr" runat="server" />
    <asp:HiddenField ID="hiddenFieldSecurityTrainerId" runat="server" />
    <asp:HiddenField ID="hiddenFieldVisitorId" runat="server" />
    <asp:HiddenField ID="hiddenFieldVisitorcompanyId" runat="server" />
    <asp:HiddenField ID="hiddenFieldSelectedVehicleType" runat="server" />
    <asp:HiddenField ID="hiddenFieldSelectedVehicleModel" runat="server" />
    <dx:ASPxLoadingPanel ID="LoadingPanel" runat="server" ClientInstanceName="LoadingPanel" Modal="True" ShowImage="true" ClientIDMode="Static" Text="Stammdaten werden gesendet...">
        <Image Url="../Images/FormImages/Loading.gif" />
    </dx:ASPxLoadingPanel>
    <asp:HiddenField ID="levelCaption" runat="server" />

    <div class="ContentAreaDiv">
        <div id="ControlSection1" class="TopContentAreaDiv">
            <div id="AEHeaderLeftDiv"> 
                <div id="BottomHeaderLabels">
                    <asp:Label ID="Label49" runat="server" Text="<%$ Resources:localizedText, companyClient %>" CssClass="L1HeaderT1drplables" Style="width: 17%;"></asp:Label>
                    <asp:Label ID="Label70" runat="server" Text="<%$ Resources:localizedText, postcode %>" CssClass="lblPlz2"></asp:Label>
                    <asp:Label ID="lblCostCenterHeader" runat="server" Text="<%$ Resources:localizedText, place2 %>" CssClass="L1HeaderT1drplablesplace" Style="width: 17%;"></asp:Label> 
                    <asp:Label ID="lblPersNo" runat="server" Text="<%$ Resources:localizedText, visitorID %>" CssClass="plzLbl" Style="width: 12%;"></asp:Label>
                    <asp:Label ID="lblEmployeeName" runat="server" Text="<%$ Resources:localizedText, name %>" CssClass="lblEmpName"></asp:Label>
                    <asp:Label ID="lblDateTo" runat="server" Text="<%$ Resources:localizedText, fulltextsearch %>" CssClass="idNlbl" Style="display: none;"></asp:Label>
                    <asp:Label ID="lblAllbooking" runat="server" Text="<%$ Resources:localizedText, allvisitors %>" CssClass="L1HeaderT1drplables" Style="display: none;"></asp:Label>
                </div>

                <div id="BottomHeaderLists"> 
                    <dx:ASPxComboBox ID="ddlTopCompanyNr" runat="server" CssClass="L1HeaderT1drplists" ValueField="ID" TextField="Nr" SelectedIndex="0" TextFormatString="{0}" EnableCallbackMode="true" OnCallback="ddlTopCompanyNr_Callback" CallbackPageSize="100000" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlTopCompanyNrSelectedChanged(s,e);
}"></ClientSideEvents>
                        <Columns> 
                            <dx:ListBoxColumn FieldName="Name" Name="Name" ToolTip="" Width="100%" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <dx:ASPxComboBox ID="ddlPostalCode" runat="server" CssClass="L1HeaderT1drplistsplz" SelectedIndex="0" ValueField="ID" TextField="PostalCode" EnableCallbackMode="true" OnCallback="ddlPostalCode_Callback" CallbackPageSize="100000" Theme="Office2003Blue" Style="margin-right: 5px;" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" HorizontalAlign="Left" DropDownRows="20">

                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlPostalCodeSelectionChaged(s,e);
}"></ClientSideEvents>
                    </dx:ASPxComboBox>
                    <dx:ASPxComboBox ID="ddlLocation" runat="server" CssClass="L1HeaderT1drplists" SelectedIndex="0" ValueField="ID" TextField="Location" EnableCallbackMode="true" OnCallback="ddlLocation_Callback" CallbackPageSize="100000" Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" HorizontalAlign="Left" DropDownRows="20">

                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlLocationSelectionChanged(s,e);
}"></ClientSideEvents>
                    </dx:ASPxComboBox>
                    <dx:ASPxComboBox ID="ddlVisitorID" runat="server" CssClass="L1HeaderT1drplistsclientNr" ValueField="ID" TextField="VisitorID" TextFormatString="{0}" EnableCallbackMode="true" OnCallback="ddlVisitorID_Callback" CallbackPageSize="100000" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px" HorizontalAlign="left" Style="float: left;">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlVisitorIDSelectionChanged(s,e);
}"
                            DropDown="function(s, e) {
	visitorDropdown(s,e);
}"
                            EndCallback="function(s, e) {
ddlVisitorIDEndCallBack(s,e);	
}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn FieldName="VisitorID" Name="VisitorID" ToolTip="" Width="20%" />
                            <dx:ListBoxColumn FieldName="Name" Name="Name" ToolTip="" Width="80%" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <dx:ASPxComboBox ID="ddlVisitorName" runat="server" CssClass="L1HeaderT1drplists" ValueField="ID" TextField="Name" TextFormatString="{1}" EnableCallbackMode="true" OnCallback="ddlVisitorName_Callback" CallbackPageSize="100000" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px" Style="margin-left: 7px;">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlVisitorNameSelectionChanged(s,e);
}"
                            DropDown="function(s, e) {
	visitorDropdown(s,e);
}"
                            EndCallback="function(s, e) {
	ddlVisitorNameEndCallback(s,e);
}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn FieldName="VisitorID" Name="VisitorID" ToolTip="" Width="20%" />
                            <dx:ListBoxColumn FieldName="Name" Name="Name" ToolTip="" Width="80%" />
                        </Columns>
                    </dx:ASPxComboBox>

                    <asp:TextBox ID="txtvoltext" runat="server" CssClass="txtfromtext" Style="display: none" ReadOnly="true"></asp:TextBox>
                    <dx:ASPxComboBox ID="ddlCompany" runat="server" CssClass="L1HeaderT1drplists" ValueField="ID" TextField="Company" EnableCallbackMode="true" OnCallback="ddlCompany_Callback" CallbackPageSize="100000" Theme="Office2003Blue" Visible="false">

                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlCompanySelectionChanged(s,e);
}"
                            DropDown="function(s, e) {
	visitorDropdown(s,e);
}"></ClientSideEvents>
                    </dx:ASPxComboBox>

                    <asp:CheckBox ID="chkAll" runat="server" CssClass="chkActivationnew" Style="display: none" ClientIDMode="Static" />
                </div>

            </div>
            <section class="fulltxtarealbl">
                <asp:Label ID="Label133" runat="server" Text="<%$ Resources:localizedText, fulltextsearch %>" CssClass="fulltxtareanew"></asp:Label>
            </section>
            <div class="textsearcharea">
                <asp:Label ID="Label134" runat="server" Text="<%$ Resources:localizedText, nameorvisitorid %>" CssClass="fulltxtarea"></asp:Label>

                <asp:UpdatePanel ID="upPnl_VisitorNameSearch" runat="server">
                    <ContentTemplate>
                        <dx:ASPxComboBox ID="cboVisitorNameSearch" ClientInstanceName="cboVisitorNameSearch" runat="server" EnableCallbackMode="True" ValueField="ID" ValueType="System.String" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="drpmemberstext ColorBlue" Theme="Office2003Blue" IncrementalFilteringMode="Contains" OnItemsRequestedByFilterCondition="cboVisitorNameSearch_OnItemsRequestedByFilterCondition" OnItemRequestedByValue="cboVisitorNameSearch_OnItemRequestedByValue" TextFormatString="{0}" DropDownStyle="DropDown" DropDownRows="20" DropDownWidth="500px" CallbackPageSize="20">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) { cboVisitorNameSearchSelectionChanged(s,e); }"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn FieldName="VisitorName" Caption="Name" Name="VisitorName" Width="70%" />
                                <dx:ListBoxColumn FieldName="VisitorID" Caption="Nr" Name="ID" Width="30%" />
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
            <section class="serchClintfilter" style="display: none">
                <div id="BottomHeaderLabelsclints">
                    <%--  <asp:Label ID="Label1072" runat="server" Text="<%$ Resources:localizedText, companyClient %>" CssClass="L1HeaderT1drplablesclint" ></asp:Label>--%>
                    <%-- <asp:Label ID="Label1082" runat="server" Text="<%$ Resources:localizedText, postcode %>" CssClass="lblPlz2new" Style="color: white"></asp:Label>
                    <asp:Label ID="Label109" runat="server" Text="<%$ Resources:localizedText, place2 %>" CssClass="L1HeaderT1drplablesplace_new" Style="color: white"></asp:Label>
                    --%>
                </div>

                <div id="BottomHeaderListsclints" style="margin-top: 21px;">

                    <asp:Label ID="Label109" runat="server" Text="<%$ Resources:localizedText, companyno %>" CssClass="lblcompnew22"></asp:Label>
                    <dx:ASPxComboBox ID="cobVisitorCompanyNr" ClientInstanceName="cobVisitorCompanyNr" runat="server" ValueField="ID" TextField="CompanyNr" EnableCallbackMode="true" OnCallback="cobVisitorCompanyNr_Callback" ValueType="System.String" TextFormatString="{0}" CssClass="ctextbx222" Theme="Office2003Blue" CallbackPageSize="100000" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cboVisitorCompanySelectedChanged(s,e);
}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn Caption="Nr:" Name="CompanyNr" FieldName="CompanyNr" Width="15%" />
                            <dx:ListBoxColumn Caption="Firmen Name:" Name="CompanyName" FieldName="CompanyName" Width="85%" />
                        </Columns>
                    </dx:ASPxComboBox>



                    <asp:Label ID="Label1072" runat="server" Text="<%$ Resources:localizedText, companyClient %>" CssClass="L1HeaderT1drplablesclintnew"></asp:Label>
                    <dx:ASPxComboBox ID="cboVisitorCompany" ClientInstanceName="cboVisitorCompany" runat="server" CssClass="L1HeaderT1drplists_clint" ValueField="ID" TextField="CompanyName" TextFormatString="{1}" EnableCallbackMode="true" OnCallback="cboVisitorCompany_Callback" CallbackPageSize="100000" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cboVisitorCompanySelectedChanged(s,e);
}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn Caption="Nr:" Name="CompanyNr" FieldName="CompanyNr" Width="15%" />
                            <dx:ListBoxColumn Caption="Firmen Name:" Name="CompanyName" FieldName="CompanyName" Width="85%" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <dx:ASPxComboBox ID="cboVisitorPostalCode" ClientInstanceName="cboVisitorPostalCode" runat="server" CssClass="L1HeaderT1drplistsplz_desc" SelectedIndex="0" DropDownWidth="100px" DropDownRows="20" ValueField="ID" TextField="ZipCode" EnableCallbackMode="true" OnCallback="cboVisitorPostalCode_Callback" CallbackPageSize="100000" Theme="Office2003Blue">

                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cboVisitorPostalCodeSelectionChaged(s,e);
}"></ClientSideEvents>

                    </dx:ASPxComboBox>
                    <dx:ASPxComboBox ID="cboVisitorLocation" ClientInstanceName="cboVisitorLocation" runat="server" CssClass="L1HeaderT1drplists_clintmew2" SelectedIndex="0" DropDownWidth="400px" DropDownRows="20" ValueField="ID" TextField="Place" EnableCallbackMode="true" OnCallback="cboVisitorLocation_Callback" CallbackPageSize="100000" Theme="Office2003Blue">

                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cboVisitorLocationSelectionChanged(s,e);
}"></ClientSideEvents>
                    </dx:ASPxComboBox>

                </div>
            </section>
            <section class="serchClintfiltermandant" style="display: none; margin-left: 28.2%;">
                <div id="BottomHeaderLabelsclintsman">
                    <%-- <asp:Label ID="Label125" runat="server" Text="<%$ Resources:localizedText, company2 %>" CssClass="L1HeaderT1drplablesclint" ></asp:Label>--%>
                    <%--     <asp:Label ID="Label126" runat="server" Text="<%$ Resources:localizedText, postcode %>" CssClass="lblPlz2new" Style="color: white"></asp:Label>
                    <asp:Label ID="Label127" runat="server" Text="<%$ Resources:localizedText, place2 %>" CssClass="L1HeaderT1drplablesplace_new" Style="color: white"></asp:Label>
                    --%>
                </div>

                <div id="BottomHeaderListsclintsman" style="margin-top: 20px;">



                    <asp:Label ID="Label137" runat="server" Text="Mandant Nr.:" CssClass="lblcompnew22"></asp:Label>
                    <dx:ASPxComboBox ID="ASPxComboBox7" runat="server" ValueType="System.String" CssClass="ctextbx222" Theme="Office2003Blue"></dx:ASPxComboBox>

                    <asp:Label ID="Label125" runat="server" Text="<%$ Resources:localizedText, company2 %>" CssClass="L1HeaderT1drplablesclintnew5"></asp:Label>
                    <dx:ASPxComboBox ID="cboClientName" ClientInstanceName="cboClientName" runat="server" CssClass="L1HeaderT1drplists_clint" ValueField="ID" TextField="Name" SelectedIndex="0" TextFormatString="{0}" EnableCallbackMode="true" OnCallback="cboClientName_Callback" CallbackPageSize="100000" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px">

                        <Columns>
                            <dx:ListBoxColumn FieldName="Name" Name="Name" ToolTip="Name" Width="100%" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <dx:ASPxComboBox ID="cboClentZipCode" ClientInstanceName="cboClentZipCode" runat="server" CssClass="L1HeaderT1drplistsplz_desc" SelectedIndex="0" TextFormatString="{0}" ValueField="ID" TextField="ZipCode" EnableCallbackMode="true" OnCallback="cboClentZipCode_Callback" CallbackPageSize="100000" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="100px">
                        <Columns>
                            <dx:ListBoxColumn FieldName="Plz" Name="Plz" ToolTip="Plz" Width="100%" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <dx:ASPxComboBox ID="cboClientPlace" ClientInstanceName="cboClientPlace" runat="server" CssClass="L1HeaderT1drplists_clintmew2" SelectedIndex="0" TextFormatString="{0}" ValueField="ID" TextField="Ort" EnableCallbackMode="true" OnCallback="cboClientPlace_Callback" CallbackPageSize="100000" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px">
                        <Columns>
                            <dx:ListBoxColumn FieldName="Ort" Name="Ort" ToolTip="Ort" Width="100%" />
                        </Columns>
                    </dx:ASPxComboBox>

                </div>
            </section>
            <div id="AEHeaderRightDiv" style="display: none;">

                <section class="empFormViewNav">
                    <section class="fvNavSearch">
                        <asp:Label ID="lblSearchAllEmp" runat="server" Text="<%$ Resources:localizedText, search %>" />
                        <asp:Button ID="btnSearchVisitors" runat="server" Text="" CssClass="searchAllEmp" />
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
                <%--     <section class="empFormViewNavrefresh" style="display: none">
                                      <asp:Button ID="btnRefresh" runat="server" Text="" CssClass="refreshButton" />

            </section>--%>
            </div>
            <div id="AEHeaderRightDivnew" style="display: none">
                <asp:Button ID="Button19" runat="server" Text="" CssClass="refreshButton" />


            </div>
            <section class="secLeftTopcartypenew" style="display: none">
                <section class="secLeftTopcartypenewleft">
                    <asp:Label ID="lbllocationno" runat="server" CssClass="lblsecT2" Text="<%$ Resources:localizedText, manufacturer %>"></asp:Label>

                    <dx:ASPxComboBox ID="cboVehicleTypes" ClientInstanceName="cboVehicleTypes" ValueField="ID" TextField="Name" runat="server" CssClass="ddlistT2" Theme="Office2003Blue" ClientIDMode="Static"
                        DropDownWidth="480px" EnableCallbackMode="true" OnCallback="cboVehicleTypes_Callback" CallbackPageSize="100000">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cboVehicleTypesSelectionChanged(s,e);
}"
                            EndCallback="function(s, e) {
cboVehicleTypesEndCallBack(s,e);	
}"></ClientSideEvents>
                    </dx:ASPxComboBox>

                </section>

            </section>
        </div>
        <div class="ControlSectionnewclient" style="display: none">
            <%--    <asp:Label ID="Label1110" runat="server" Text="<%$ Resources:localizedText, creatingvisitorcompany %>" CssClass="visitorlonig"></asp:Label>--%>
            <section class="left1">
                <asp:Label ID="Label135" runat="server" Text="<%$ Resources:localizedText, companyno %>" CssClass="lblcomp"></asp:Label>
                <dx:ASPxComboBox ID="cobCompanyNr" ClientInstanceName="cobCompanyNr" ValueField="ID" TextField="CompanyNr" runat="server" EnableCallbackMode="true" OnCallback="cobCompanyNr_Callback" CssClass="ctextbx" Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextFormatString="{0}" DropDownRows="20" DropDownWidth="400px">
                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
companySelectionChanged(s,e);	
}"
                        DropDown="function(s, e) {
cobCompanyClick(s,e);	
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn Caption="Nr:" Name="CompanyNr" FieldName="CompanyNr" Width="15%" />
                        <dx:ListBoxColumn Caption="Firmen Name:" Name="CompanyName" FieldName="CompanyName" Width="85%" />
                    </Columns>
                </dx:ASPxComboBox>

            </section>
            <section class="right1">
                <asp:Label ID="Label136" runat="server" Text="Firmen Name:" CssClass="lblcomp1"></asp:Label>
                <dx:ASPxComboBox ID="cobCompanyName" ClientInstanceName="cobCompanyName" ValueField="ID" TextField="CompanyName" runat="server" EnableCallbackMode="true" OnCallback="cobCompanyName_Callback" ValueType="System.String" CssClass="ctextbx1" Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextFormatString="{1}" DropDownRows="20" DropDownWidth="400px" Style="width: 360px;">
                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
companySelectionChanged(s,e);	
}"
                        DropDown="function(s, e) {
cobCompanyClick(s,e);	
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn Caption="Nr:" Name="CompanyNr" FieldName="CompanyNr" Width="15%" />
                        <dx:ListBoxColumn Caption="Firmen Name:" Name="CompanyName" FieldName="CompanyName" Width="85%" />
                    </Columns>
                </dx:ASPxComboBox>

            </section>
            <section class="btnright">
                <asp:ImageButton ID="btnVisitorPlanInfo" runat="server" CssClass="buttonbesnew" Style="background-size: cover; display: none;" />
            </section>
        </div>
        <div class="ControlSectionnewclientmandant" style="display: none">
            <asp:Label ID="Label110" runat="server" Text="Besuchermandant anlegen" CssClass="visitorlonig"></asp:Label>
        </div>
        <div id="ControlSection1history" class="ControlSectionhistory" style="display: none">
            <div id="AEHeaderLeftDivhistory">
                <div id="BottomHeaderLabelshistory">
                    <asp:Label ID="Label107" runat="server" Text="<%$ Resources:localizedText, companyClient %>" CssClass="L1HeaderT1drplables" Style="width: 17%;"></asp:Label>
                    <asp:Label ID="Label101" runat="server" Text="<%$ Resources:localizedText, postcode %>" CssClass="lblPlz2"></asp:Label>
                    <asp:Label ID="Label102" runat="server" Text="<%$ Resources:localizedText, place2 %>" CssClass="L1HeaderT1drplablesplace" Style="width: 17%;"></asp:Label>
                    <asp:Label ID="Label103" runat="server" Text="<%$ Resources:localizedText, visitorID %>" CssClass="plzLbl" Style="width: 12%;"></asp:Label>
                    <asp:Label ID="Label104" runat="server" Text="<%$ Resources:localizedText, name %>" CssClass="lblEmpName" Style="width: 16.5%;"></asp:Label>
                    <asp:Label ID="Label105" runat="server" Text="<%$ Resources:localizedText, fulltextsearch %>" CssClass="idNlbl"></asp:Label>
                    <asp:Label ID="Label106" runat="server" Text="<%$ Resources:localizedText, allvisitors %>" CssClass="L1HeaderT1drplables" Style="width: 8%; text-align: right;"></asp:Label>
                </div>

                <div id="BottomHeaderListshistory">
                    <dx:ASPxComboBox ID="ddlTopCompanyNrHistory" ClientInstanceName="ddlTopCompanyNrHistory" runat="server" CssClass="L1HeaderT1drplists" ValueField="ID" TextField="Nr" SelectedIndex="0" TextFormatString="{0}" EnableCallbackMode="true" OnCallback="ddlTopCompanyNrHistory_Callback" CallbackPageSize="100000" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px" Style="float: left;">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlTopCompanyNrHistorySelectedChanged(s,e);
}"></ClientSideEvents>
                        <Columns>
                            <%--<dx:ListBoxColumn FieldName="Nr" Name="Nr" ToolTip="" Width="20%" />--%>
                            <dx:ListBoxColumn FieldName="Name" Name="Name" ToolTip="" Width="100%" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <dx:ASPxComboBox ID="ddlPostalCodeHistory" ClientInstanceName="ddlPostalCodeHistory" runat="server" CssClass="L1HeaderT1drplistsplz" SelectedIndex="0" ValueField="ID" TextField="PostalCode" EnableCallbackMode="true" OnCallback="ddlPostalCodeHistory_Callback" CallbackPageSize="100000" Theme="Office2003Blue" Style="float: left;">

                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlPostalCodeHistorySelectionChaged(s,e);
}"></ClientSideEvents>
                    </dx:ASPxComboBox>
                    <dx:ASPxComboBox ID="ddlLocationHistory" ClientInstanceName="ddlLocationHistory" runat="server" CssClass="L1HeaderT1drplists" SelectedIndex="0" ValueField="ID" TextField="Location" EnableCallbackMode="true" OnCallback="ddlLocationHistory_Callback" CallbackPageSize="100000" Theme="Office2003Blue" Style="float: left;">

                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlLocationHistorySelectionChanged(s,e);
}"></ClientSideEvents>
                    </dx:ASPxComboBox>

                    <dx:ASPxComboBox ID="ddlVisitorIDHistory" ClientInstanceName="ddlVisitorIDHistory" runat="server" CssClass="L1HeaderT1drplistsclientNr" ValueField="ID" TextField="VisitorID" TextFormatString="{0}" EnableCallbackMode="true" OnCallback="ddlVisitorID_Callback" CallbackPageSize="100000" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px" HorizontalAlign="Right" Style="float: left;">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlVisitorIDHistorySelectionChanged(s,e);
}"
                            Init="function(s, e) {
	ddlVisitorIDHistoryInit(s,e);
}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn FieldName="VisitorID" Name="VisitorID" ToolTip="" Width="20%" />
                            <dx:ListBoxColumn FieldName="Name" Name="Name" ToolTip="" Width="80%" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <dx:ASPxComboBox ID="ddlVisitorNameHistory" ClientInstanceName="ddlVisitorNameHistory" runat="server" CssClass="L1HeaderT1drplists" ValueField="ID" TextField="Name" TextFormatString="{1}" EnableCallbackMode="true" OnCallback="ddlVisitorName_Callback" CallbackPageSize="100000" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px" Style="margin-left: 9px; float: left; width: 16%;">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlVisitorNameHistorySelectionChanged(s,e);
}"
                            Init="function(s, e) {
	ddlVisitorNameHistoryInit(s,e);
}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn FieldName="VisitorID" Name="VisitorID" ToolTip="" Width="20%" />
                            <dx:ListBoxColumn FieldName="Name" Name="Name" ToolTip="" Width="80%" />
                        </Columns>
                    </dx:ASPxComboBox>

                    <asp:TextBox ID="TextBox2" runat="server" CssClass="txtfromtext" ReadOnly="true" Style="float: left; width: 16%;"></asp:TextBox>
                    <dx:ASPxComboBox ID="ASPxComboBox6" runat="server" CssClass="L1HeaderT1drplists" ValueField="ID" TextField="Company" EnableCallbackMode="true" OnCallback="ddlCompany_Callback" Theme="Office2003Blue" Visible="false" Style="float: left;">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlCompanySelectionChanged(s,e);
}"
                            DropDown="function(s, e) {
	visitorDropdown(s,e);
}"></ClientSideEvents>

                    </dx:ASPxComboBox>

                    <asp:CheckBox ID="chkAllVisitors" runat="server" CssClass="chkActivationnew" ClientIDMode="Static" Style="float: left;" />
                </div>

            </div>

            <div id="AEHeaderRightDivhistory">
                <asp:Button ID="btnRefresh" ClientIDMode="Static" runat="server" Text="" CssClass="refreshButton" />


            </div>
        </div>
        <div id="tabcontroldiv" style="height: 90.7%;">
            <div id="UpperDiv" style="display: block;">
                <div id="leftdiv">
                    <section class="topbtnarea" style="display: none;">
                        <%-- <asp:Button ID="btnVisApplication" runat="server" Text="<%$ Resources:localizedText ,existingapplications%>" CssClass="btnregister" />--%>
                    </section>
                    <section class="tab1leftsection">
                        <section class="tab1leftsection1Left">
                            <asp:Button ID="btnVisApplication" runat="server" Text="<%$ Resources:localizedText ,visitorinformation%>" CssClass="newstandardbutton besucherbtn" />
                            <%--  <asp:Label ID="Label32" runat="server" Text="<%$ Resources:localizedText ,visitorinformation%>" CssClass="lblpersonal22new"></asp:Label>--%>
                            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText ,visitorID%>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                            <asp:Label ID="Label71" runat="server" Text="Firma Nr.:" CssClass="lblpersonal2 fontweight600" Style="display: none"></asp:Label>

                            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText ,firstName2%>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                            <asp:Label ID="Label73" runat="server" Text="<%$ Resources:localizedText ,surname%>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                            <asp:Label ID="Label72" runat="server" Text="<%$ Resources:localizedText ,company%>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText,company %>" CssClass="lblpersonal2 fontweight600" Style="display: none"></asp:Label>
                            <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, expectedEntry %>" CssClass="lblpersonal2 fontweight600" Style="display: none;"></asp:Label>
                            <asp:Label ID="Label5" runat="server" Text="<%$ Resources:localizedText, road2 %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                            <asp:Label ID="Label68" runat="server" Text="<%$ Resources:localizedText, no2 %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                            <asp:Label ID="Label69" runat="server" Text="<%$ Resources:localizedText, postalCode %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                            <asp:Label ID="Label17" runat="server" Text="<%$ Resources:localizedText, loc %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                            <asp:Label ID="Label22" runat="server" Text="<%$ Resources:localizedText, telephone %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                            <asp:Label ID="Label18" runat="server" Text="<%$ Resources:localizedText, mobile %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                            <asp:Label ID="Label19" runat="server" Text="<%$ Resources:localizedText, email1 %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                            <asp:Label ID="Label21" runat="server" Text="<%$ Resources:localizedText, indicator %>" CssClass="lblpersonal2 fontweight600" Style="margin-top: 4px;"></asp:Label>
                            <asp:Label ID="Label20" runat="server" Text="<%$ Resources:localizedText, vehicleType %>" CssClass="lblpersonal2 fontweight600"></asp:Label>

                            <div style="display: none;">
                                <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText ,personVisited%>" CssClass="lblpersonalNew fontweight600"></asp:Label>
                                <asp:Label ID="Label13" runat="server" Text="<%$ Resources:localizedText ,purposeOfVisit %>" CssClass="lblpersonalsplit2new fontweight600"></asp:Label>

                                <asp:Label ID="Label30" runat="server" Text="<%$ Resources:localizedText ,securityCheckBy%>" CssClass="lblpersonalsplit fontweight600" Style="line-height: 14px;"></asp:Label>
                                <asp:Label ID="Label31" runat="server" Text="<%$ Resources:localizedText ,securityTrainingBy %>" CssClass="lblpersonalsplit2 fontweight600"></asp:Label>
                            </div>
                        </section>
                    </section>
                    <section class="tab1leftsection2Left">
                        <asp:Button ID="btnRegistration" runat="server" Text="<%$ Resources:localizedText ,registration%>" CssClass="newstandardbutton besucherbtnnew" />
                        <asp:TextBox ID="txtVisitorID" runat="server" CssClass="txtpersonalnewwcost"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton2" runat="server" CssClass="buttonbes" Style="display: none;" />
                        <asp:TextBox ID="txtName" ClientIDMode="Static" runat="server" CssClass="txtpersonal"></asp:TextBox>
                        <asp:TextBox ID="txtSurName" ClientIDMode="Static" runat="server" CssClass="txtpersonal"></asp:TextBox>
                        <asp:TextBox ID="txtVisitorCompanyID" ClientIDMode="Static" runat="server" Style="display: none"></asp:TextBox>
                        <asp:TextBox ID="txtVisitorCompanyName" ClientIDMode="Static" CssClass="txtpersonal" ReadOnly="true" runat="server" Style="margin-right: 5px;"></asp:TextBox>
                        <section style="display: none">
                            <dx:ASPxComboBox ID="dplCompanyName" ClientInstanceName="dplCompanyName" runat="server" ValueField="ID" TextField="CompanyNr" OnCallback="dplCompanyName_Callback" CallbackPageSize="100000"
                                TextFormatString="{0}" CssClass="txtpersonalnrnew" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" HorizontalAlign="Left" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
	dplCompanyNameSelectedIndexChanged(s, e)
}"
                                    EndCallback="function(s, e) {
	dplCompanyNameEndCallback(s,e);
}"></ClientSideEvents>

                                <Columns>
                                    <%-- <dx:ListBoxColumn FieldName="Client_Nr" Name="ProfileDescription" ToolTip="" Width="20%" Caption="Nr" />--%>
                                    <dx:ListBoxColumn FieldName="CompanyName" Name="ID" ToolTip="Firma:" Caption="Firma" Width="80%" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>
                        <asp:Button ID="btnSearchClient" runat="server" CssClass="btnSearchPersnlnew" Text="" ClientIDMode="Static" />
                        <asp:Button ID="btnSerchClient" runat="server" CssClass="btnSearchclient" Text="" ClientIDMode="Static" Style="background-size: contain;" />

                        <asp:TextBox ID="txtCompany" ClientIDMode="Static" runat="server" CssClass="txtpersonal" Style="display: none"></asp:TextBox>
                        <div style="display: none;">
                            <dx:ASPxDateEdit ID="dtpExpectedEntry" runat="server" Theme="Office2003Blue" CssClass="dtpckr" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif"
                                EnableTheming="true" Font-Size="14px" HorizontalAlign="Center">
                            </dx:ASPxDateEdit>
                        </div>
                        <asp:TextBox ID="txtStreet" ClientIDMode="Static" runat="server" ReadOnly="true" CssClass="txtpersonal"></asp:TextBox>
                        <asp:TextBox ID="txtStreetNr" ClientIDMode="Static" runat="server" ReadOnly="true" CssClass="txtpersonalnrno"></asp:TextBox>
                        <asp:TextBox ID="txtPostalCode" ClientIDMode="Static" runat="server" ReadOnly="true" CssClass="txtpersonalnr"></asp:TextBox>
                        <asp:TextBox ID="txtLocation" ClientIDMode="Static" runat="server" ReadOnly="true" CssClass="txtpersonal"></asp:TextBox>
                        <asp:TextBox ID="txtTelephone" ClientIDMode="Static" runat="server" CssClass="txtpersonal"></asp:TextBox>
                        <asp:TextBox ID="txtMobile" ClientIDMode="Static" runat="server" CssClass="txtpersonal"></asp:TextBox>
                        <asp:TextBox ID="txtEmail" ClientIDMode="Static" runat="server" CssClass="txtpersonal"></asp:TextBox>
                        <asp:TextBox ID="txtRegNo" ClientIDMode="Static" runat="server" CssClass="txtpersonal" Style="display: none"></asp:TextBox>
                        <asp:TextBox ID="txtVehicleNo" ClientIDMode="Static" runat="server" CssClass="txtpersonal"></asp:TextBox>
                        <asp:TextBox ID="txtVehicleId" Style="display: none" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtVehicleTypes" runat="server" ReadOnly="true" CssClass="txtpersonalnew"></asp:TextBox>
                        <asp:Button ID="btnsearchvehicle" runat="server" CssClass="btnSearchPersnlnew" Text="" ClientIDMode="Static" />
                        <div style="display: none">
                            <asp:TextBox ID="txtPersVisited" ReadOnly="true" runat="server" CssClass="txtpersonal21"></asp:TextBox>
                            <asp:Button ID="btnSearchPersonal" runat="server" CssClass="btnSearchPersnl" Text="..." />
                            <asp:TextBox ID="txtPurpose" runat="server" CssClass="txtpersonal2"></asp:TextBox>
                            <asp:Button ID="Button7" runat="server" CssClass="btnsearchTimeOut" Text="..." Enabled="false" />

                            <asp:TextBox ID="txtSecurityChecked" ReadOnly="true" runat="server" CssClass="txtpersonal31"></asp:TextBox>
                            <asp:Button ID="btnSecurityCheckBy" runat="server" CssClass="btnSearchPurpose" Text="..." />
                            <asp:Label ID="Label23" runat="server" Text="am:" CssClass="lbl"></asp:Label>
                            <dx:ASPxTimeEdit ID="dtpcheckTime" runat="server" CssClass="txtpersonal32" EnableTheming="true">
                                <SpinButtons Enabled="false" ShowIncrementButtons="false"></SpinButtons>
                            </dx:ASPxTimeEdit>

                            <asp:TextBox ID="txtTrainingBy" ReadOnly="true" runat="server" CssClass="txtpersonal3"></asp:TextBox>
                            <asp:Button ID="btnSecurityTrainedBy" runat="server" CssClass="btnSearchTimein" Text="..." />
                            <asp:Label ID="Label24" runat="server" Text="am:" CssClass="lblpersonalLeftDiv2"></asp:Label>
                            <dx:ASPxTimeEdit ID="dtptrainingTime" runat="server" CssClass="txtpersonal32b" EnableTheming="true">
                                <SpinButtons Enabled="false" ShowIncrementButtons="false"></SpinButtons>
                            </dx:ASPxTimeEdit>
                        </div>
                    </section>

                    <section class="tab1leftsection2Leftpicnew">
                        <section class="photo">
                            <fieldset id="PhotoFieldset" class="fieldSet">
                                <asp:HiddenField ID="photVal" ClientIDMode="Static" runat="server" />
                                <div id="Photoholder" class="passPhoto">
                                    <img id="img" runat="server" src="" />
                                </div>
                            </fieldset>
                        </section>
                        <section class="secPersAccpt">
                            <section class="picbuttons">
                                <div style="display: none;">
                                    <asp:FileUpload ID="UploadPhoto" ClientIDMode="Static" CssClass="PhotoholderButtonsClsUpload" accept=".png,.jpg,.jpeg,.gif" runat="server" />
                                </div>
                                <asp:Button ID="btnTriggerFileUpload" runat="server" CssClass="PhotoholderClsnew hyperButtonsHover" Text="<%$ Resources:localizedText, selectingaSavedPhoto %>" Style="color: forestgreen;" />
                            </section>
                            <section class="picbuttons">
                                <asp:Button ID="btnTakeWebcamPicture" runat="server" CssClass="PhotoholderClsnew hyperButtonsHover" Text="<%$ Resources:localizedText, activateWebcam %>" Style="color: rgba(46,116,223,1.00);" />
                            </section>
                            <section class="picbuttons">
                                <%--<asp:Button ID="Button17" runat="server" CssClass="PhotoholderClsnew hyperButtonsHover" Text="Passfoto Specichern" Style="color: #2DAA9E;" />--%>
                            </section>
                            <section class="picbuttons">
                                <asp:Button ID="btnRemovePhoto" runat="server" CssClass="PhotoholderClsnew hyperButtonsHover" Text="<%$ Resources:localizedText, deletePhoto %>" Style="color: red;" />
                            </section>
                        </section>
                    </section>
                    <section class="webCamMode" style="display: none;">
                        <section class="cameraScreen">
                            <div id="webcam" style="width: 100%; height: 100%;"></div>
                        </section>
                        <section class="acceptButtons">
                            <asp:Button ID="btnTKPhoto" runat="server" Text="<%$ Resources:localizedText, takePhoto %>" CssClass="cameraButtonsLeft " />
                            <asp:Button ID="btnClearPhoto" runat="server" Text="<%$ Resources:localizedText, clearPhoto %>" CssClass="cameraButtonsRight " />
                        </section>
                        <asp:Button ID="btnAccept" runat="server" Text="<%$ Resources:localizedText, takeover %>" CssClass="cameraButtonsLeft " />
                        <asp:Button ID="btnCancelPhoto" runat="server" Text="<%$ Resources:localizedText, unselect %>" CssClass="cameraButtonsRight " />
                    </section>
                    <section class="secReasonForVisit">
                        <asp:Label ID="Label93" runat="server" Text="<%$ Resources:localizedText ,visitingclient%>" CssClass="newcompany"></asp:Label>
                    </section>
                    <section style="float: left; width: 100%; height: 5%;">
                        <asp:Label ID="Label94" runat="server" Text="<%$ Resources:localizedText ,companyclientid%>" CssClass="lblcompany" Style="display: none"></asp:Label>
                        <section style="display: none;">
                            <dx:ASPxComboBox ID="dplToCompanyNr" runat="server" ValueField="ID" TextField="Client_Nr" TextFormatString="{0}" EnableCallbackMode="true" OnCallback="dplToCompanyNr_Callback" CallbackPageSize="100000" CssClass="drpcompanyid" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
	companyToSelectedIndexChanged(s,e);
}"
                                    EndCallback="function(s, e) {
	dplToCompanyNrEndCallBack(s,e);
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn FieldName="Client_Nr" Name="ProfileDescription" ToolTip="" Width="20%" Caption=" Mandant ID" />
                                    <dx:ListBoxColumn FieldName="Name" Name="ID" ToolTip="Bezeichnung:" Width="80%" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>
                        <asp:Label ID="Label95" runat="server" Text="<%$ Resources:localizedText ,name%>" CssClass="lblcompanyname"></asp:Label>
                        <section style="display: none">
                            <dx:ASPxComboBox ID="dplToCompanyName" runat="server" ValueField="ID" TextField="Name" TextFormatString="{1}" EnableCallbackMode="true" OnCallback="dplToCompanyName_Callback" CallbackPageSize="100000" CssClass="drpcompanyname" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
	companyToSelectedIndexChanged(s,e);
}"
                                    EndCallback="function(s, e) {
	dplToCompanyNameEndCallBack(s,e);
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn FieldName="Client_Nr" Name="ProfileDescription" ToolTip="" Width="20%" Caption=" Mandant ID" />
                                    <dx:ListBoxColumn FieldName="Name" Name="ID" ToolTip="Bezeichnung:" Width="80%" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>
                        <asp:TextBox ID="txtToCompanyId" runat="server" Style="display: none"></asp:TextBox>
                        <asp:TextBox ID="txtToCompanyName" runat="server" CssClass="drpcompanyname" ReadOnly="true"></asp:TextBox>
                        <asp:ImageButton ID="btnSearchClient2" runat="server" CssClass="buttonbesnew" Style="margin-top: 2px; display: none;" ClientIDMode="Static" />
                        <asp:Button ID="btnSerchmandant" runat="server" CssClass="btnSearchclientnew" Text="" ClientIDMode="Static" />
                    </section>
                    <section class="secbuttons">
                        <section class="picbuttons">
                        </section>
                        <section class="picbuttons">
                        </section>

                        <section class="picbuttons">
                        </section>
                    </section>
                </div>

                <div id="rightdiv">
                    <section class="topbtnarea" style="display: none;">
                        <asp:Button ID="btnvishitorie" runat="server" Text="Besucher Daten" CssClass="btnregister" />
                    </section>
                    <section class="rightdivTopnew">
                        <section class="topsmall1">
                            <asp:Label ID="Label33" runat="server" Text="<%$ Resources:localizedText, registrationfrom %>" CssClass="lblpersonalRightTitle" Style="color: red;"></asp:Label>
                        </section>
                        <section class="centre1big" style="height: 85%;">
                            <section class="centre1bigtop" style="height: 44%;">

                                <section class="visit1">
                                    <section class="visit1anew">
                                        <asp:Label ID="Label52" runat="server" Text="Name:" CssClass="lblpersonalRightCont fontweight600"></asp:Label>
                                    </section>
                                    <section class="visit1bnew">
                                        <asp:TextBox ID="txtPersonalName" ClientIDMode="Static" Enabled="false" runat="server" CssClass="txtpersonalbottomsmallnew1"></asp:TextBox>
                                    </section>
                                    <%--  <section class="visit1c">
                                    <asp:Button ID="Button8" runat="server" Visible="false" CssClass="btnSearchGLBL ColorRed" Text="..." />
                                </section>--%>
                                </section>
                                <section class="visit1">
                                    <section class="visit1anew">
                                        <asp:Label ID="Label96" runat="server" Text="<%$ Resources:localizedText ,telephone%>" CssClass="lblpersonalRightCont fontweight600"></asp:Label>
                                    </section>
                                    <section class="visit1bnewPhne">
                                        <asp:TextBox ID="txtPersPhoneNr" ClientIDMode="Static" Enabled="false" runat="server" CssClass="txtTelphn"></asp:TextBox>
                                    </section>
                                    <section class="visit1anewUsr">
                                        <asp:Label ID="Label97" runat="server" Text="<%$ Resources:localizedText ,mobil%>" CssClass="lblpersonalRightCont fontweight600"></asp:Label>
                                    </section>
                                    <section class="visit1bnewtxt">
                                        <asp:TextBox ID="txtPersMobileNr" ClientIDMode="Static" Enabled="false" runat="server" CssClass="txtmbl"></asp:TextBox>
                                    </section>

                                </section>
                                <section class="visit1" style="display: none;">
                                    <section class="visit1anew">
                                        <asp:Label ID="Label53" runat="server" Text="Personal Nr.:" CssClass="lblpersonalRightCont fontweight600"></asp:Label>
                                    </section>
                                    <section class="visit1bnew">
                                        <%--style="width:62%;"--%>
                                        <asp:TextBox ID="txtPersonnelNumber" ClientIDMode="Static" Enabled="false" runat="server" CssClass="txtpersonalbottomsmall2new2"></asp:TextBox>
                                        <asp:Button ID="Button9" runat="server" Text="!" CssClass="btnExclamation fontweight600 ColorRed" Style="display: none;" />
                                    </section>
                                    <section class="visit1c" style="display: none;">
                                        <asp:Button ID="Button13" runat="server" CssClass="txtpersonalrightdiv2 ColorRed" Text="..." />
                                    </section>
                                </section>
                                <section class="visit1">
                                    <section class="visit1anew">
                                        <asp:Label ID="Label54" runat="server" Text="<%$ Resources:localizedText ,visitreason%>" CssClass="lblpersonalRightCont2 fontweight600"></asp:Label>

                                    </section>
                                    <section class="visit1bnewReason">
                                        <asp:TextBox ID="txtVisitReason" ClientIDMode="Static" runat="server" CssClass="txtReason"></asp:TextBox>
                                    </section>
                                    <section class="visit1c" style="display: none;">
                                        <asp:Button ID="Button14" runat="server" CssClass="btnSearchGLBL ColorRed" Text="..." />

                                    </section>
                                </section>

                                <section class="visit1" style="display: none;">
                                    <section class="visit1a">
                                        <asp:Label ID="Label55" runat="server" Text="<%$ Resources:localizedText ,calender%>" CssClass="lblpersonalRightCont3 fontweight600"></asp:Label>

                                    </section>
                                    <section class="visit1b">
                                        <asp:TextBox ID="TextBox4" runat="server" CssClass="txtpersonalbottomsmall"></asp:TextBox>
                                    </section>
                                    <section class="visit1c">
                                        <asp:Button ID="Button15" runat="server" CssClass="txtpersonalrightdiv2 ColorRed" Text="..." />
                                    </section>
                                </section>
                            </section>
                            <section class="centre1bigtop" style="height: 44%; display: none;">

                                <section class="visit1">
                                    <section class="visit1a">
                                        <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText ,identification3%>" CssClass="lblpersonalRightCont fontweight600"></asp:Label>
                                    </section>
                                    <section class="visit1b">
                                        <asp:TextBox ID="txtTransponderNr" runat="server" CssClass="txtpersonalbottomsmall"></asp:TextBox>
                                    </section>
                                    <section class="visit1c">
                                        <asp:Button ID="btntranData" runat="server" Visible="false" CssClass="btnSearchGLBL ColorRed" Text="..." />
                                    </section>
                                </section>

                                <section class="visit1">
                                    <section class="visit1a">
                                        <asp:Label ID="Label8" runat="server" Text="<%$ Resources:localizedText ,pinPassword2%>" CssClass="lblpersonalRightCont fontweight600"></asp:Label>
                                    </section>
                                    <section class="visit1b">
                                        <%--style="width:62%;"--%>
                                        <asp:TextBox ID="txtPinCode" runat="server" CssClass="txtpersonalbottomsmall2"></asp:TextBox>
                                        <asp:Button ID="Button10" runat="server" Text="!" CssClass="btnExclamation fontweight600 ColorRed" Style="display: none;" />
                                    </section>
                                    <section class="visit1c" style="display: none;">
                                        <asp:Button ID="Button2" runat="server" CssClass="txtpersonalrightdiv2 ColorRed" Text="..." />
                                    </section>
                                </section>
                                <section class="visit1">
                                    <section class="visit1a">
                                        <asp:Label ID="Label9" runat="server" Text="<%$ Resources:localizedText ,visitorsPlansingular%>" CssClass="lblpersonalRightCont2 fontweight600"></asp:Label>

                                    </section>
                                    <section class="visit1b">
                                        <asp:TextBox ID="txtVisitorPlan" ClientIDMode="Static" ReadOnly="true" runat="server" CssClass="txtpersonalbottomsmall"></asp:TextBox>
                                    </section>
                                    <section class="visit1c" style="display: none;">
                                        <asp:Button ID="btnvisData" runat="server" CssClass="btnSearchGLBL ColorRed" Text="..." />

                                    </section>
                                </section>

                                <section class="visit1" style="display: none;">
                                    <section class="visit1a">
                                        <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText ,calender%>" CssClass="lblpersonalRightCont3 fontweight600"></asp:Label>

                                    </section>
                                    <section class="visit1b">
                                        <asp:TextBox ID="TextBox12" runat="server" CssClass="txtpersonalbottomsmall"></asp:TextBox>
                                    </section>
                                    <section class="visit1c">
                                        <asp:Button ID="Button4" runat="server" CssClass="txtpersonalrightdiv2 ColorRed" Text="..." />
                                    </section>
                                </section>
                            </section>

                            <section class="centre1bigbottom">

                                <section <%-- class="tab1leftsection1Check"--%>>
                                    <section class="tab1leftsection1CheckRows">
                                        <asp:Label ID="Label56" runat="server" Text="<%$ Resources:localizedText, remberat %>" CssClass="lblpersonalRightCont3 fontweight600" Style="line-height: 14px; color: red;"></asp:Label>
                                        <asp:Label ID="Label57" runat="server" Text="<%$ Resources:localizedText, date %>" CssClass="lblShotrnewdate fontweight600" Style="color: red;"></asp:Label>
                                        <dx:ASPxDateEdit ID="drpRegDate" ClientInstanceName="drpRegDate" runat="server" Theme="Office2003Blue" CssClass="dtpckrnew" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" EnableTheming="true" Font-Size="14px" HorizontalAlign="Center">
                                            <ClientSideEvents DateChanged="function(s, e) {
	datePickerDateChanged(s,e);
}"></ClientSideEvents>
                                        </dx:ASPxDateEdit>
                                        <asp:Label ID="Label58" runat="server" Text="<%$ Resources:localizedText, timeOfDay %>" CssClass="lblShotr fontweight600" Style="color: red;"></asp:Label>
                                        <dx:ASPxTimeEdit ID="drpRegTime" ClientInstanceName="drpRegTime" runat="server" CssClass="txtsize1date" DisplayFormatString="HH:mm" family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" HorizontalAlign="Center">
                                            <ClientSideEvents DateChanged="function(s, e) {
	datePickerDateChanged(s,e);
}"></ClientSideEvents>
                                            <SpinButtons Enabled="false" ShowIncrementButtons="false">
                                            </SpinButtons>
                                        </dx:ASPxTimeEdit>
                                    </section>


                                    <section class="tab1leftsection1CheckRows">
                                        <asp:Label ID="Label11" runat="server" Text="<%$ Resources:localizedText, visitbegins %>" CssClass="lblpersonalRightCont3 fontweight600" Style="line-height: 14px;"></asp:Label>
                                        <asp:Label ID="Label15" runat="server" Text="<%$ Resources:localizedText, date %>" CssClass="lblShotrnewdate fontweight600"></asp:Label>
                                        <dx:ASPxDateEdit ID="dtpStartDate" ClientInstanceName="dtpStartDate" runat="server" Theme="Office2003Blue" CssClass="dtpckrnew" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" EnableTheming="true" Font-Size="14px" HorizontalAlign="Center">
                                            <ClientSideEvents DateChanged="function(s, e) {
	datePickerDateChanged(s,e);
}"></ClientSideEvents>
                                        </dx:ASPxDateEdit>
                                        <asp:Label ID="Label25" runat="server" Text="<%$ Resources:localizedText, timeOfDay %>" CssClass="lblShotr fontweight600"></asp:Label>
                                        <dx:ASPxTimeEdit ID="dtpStartDateTime" ClientInstanceName="dtpStartDateTime" runat="server" CssClass="txtsize1date" DisplayFormatString="HH:mm" family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" HorizontalAlign="Center">
                                            <ClientSideEvents DateChanged="function(s, e) {
	datePickerDateChanged(s,e);
}"></ClientSideEvents>
                                            <SpinButtons Enabled="false" ShowIncrementButtons="false">
                                            </SpinButtons>
                                        </dx:ASPxTimeEdit>
                                    </section>
                                    <section class="tab1leftsection1CheckRows">
                                        <asp:Label ID="Label12" runat="server" Text="<%$ Resources:localizedText, visitends %>" CssClass="lblpersonalRightCont3 fontweight600"></asp:Label>
                                        <asp:Label ID="Label26" runat="server" Text="<%$ Resources:localizedText, date %>" CssClass="lblShotrnewdate fontweight600"></asp:Label>
                                        <dx:ASPxDateEdit ID="dtpEndDate" runat="server" Theme="Office2003Blue" CssClass="dtpckrnew" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif"
                                            EnableTheming="true" Font-Size="14px" HorizontalAlign="Center">
                                            <ClientSideEvents DateChanged="function(s, e) {
	datePickerDateChanged(s,e);
}"></ClientSideEvents>
                                        </dx:ASPxDateEdit>
                                        <asp:Label ID="Label27" runat="server" Text="<%$ Resources:localizedText, timeOfDay %>" CssClass="lblShotr fontweight600"></asp:Label>
                                        <dx:ASPxTimeEdit ID="dtpEndDateTime" ClientInstanceName="dtpEndDateTime" runat="server" CssClass="txtsize1date" DisplayFormatString="HH:mm" family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" HorizontalAlign="Center">
                                            <ClientSideEvents DateChanged="function(s, e) {
	datePickerDateChanged(s,e);
}"></ClientSideEvents>
                                            <SpinButtons Enabled="false" ShowIncrementButtons="false">
                                            </SpinButtons>
                                        </dx:ASPxTimeEdit>
                                    </section>
                                    <section class="tab1leftsection1CheckRowstakeover">
                                        <asp:Button ID="btnApplyRegDates" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, applycredentials %>" CssClass="takeover" />
                                    </section>
                                </section>
                            </section>
                            <section style="text-align: right; width: 48%; display: none;">
                                <asp:Label ID="Label48" runat="server" Text="<%$ Resources:localizedText, memo %>" CssClass="memo"></asp:Label>
                            </section>
                        </section>

                        <section class="topsmall2right" style="height: 69%; display: none;">

                            <section class="tab1leftsection5" style="height: 97%">

                                <section class="photo" style="width: 100%; height: 70%;">
                                    <fieldset id="PhotoFieldset2" style="width: 87%; margin-left: auto; margin-right: auto; border: 1px solid black; height: 98%; padding: 0;">
                                        <legend>
                                            <asp:Label ID="Label16" runat="server" Text="<%$ Resources:localizedText, photo %>" CssClass="PhotoholderCls"></asp:Label></legend>
                                        <div id="Photoholder2" class="PhotoholderCls">
                                        </div>
                                    </fieldset>
                                </section>
                                <section class="PhotoBtnsHolder">
                                    <asp:Button ID="btnUploadPic" runat="server" Text="<%$ Resources:localizedText, insertPicture %>" CssClass="PhotoholderButtonsCls btnewphoto" Font-Size="Small" />
                                </section>
                                <section class="PhotoBtnsHolder">
                                    <asp:Button ID="btnDeletePic" runat="server" Text="<%$ Resources:localizedText, removePicture %>" CssClass="PhotoholderButtonsCls btdelphoto" Font-Size="Small" />
                                </section>
                            </section>
                        </section>

                        <section class="topsmall2" style="height: 15%; display: none;">


                            <section class="tab1leftsection3a" style="width: 21%; min-width: 145px;">
                                <asp:Label ID="Label37" runat="server" Text="<%$ Resources:localizedText, scanSignature %>" CssClass="lblpersonalRightCont3new fontweight600" Style="margin-bottom: 5%;"></asp:Label>
                                <asp:Label ID="Label35" runat="server" Text="<%$ Resources:localizedText, showSignature %>" CssClass="lblpersonalRightCont3new fontweight600"></asp:Label>
                            </section>
                            <section class="tab1leftsection3b" style="width: 9%;">
                                <asp:Button ID="btnTakePhoto" runat="server" CssClass="btnSearchGLBL2 ColorRed fontweight600" Text="..." Style="margin-bottom: 15%;" />
                                <asp:Button ID="Button11" runat="server" CssClass="btnSearchGLBL2 ColorRed fontweight600" Text="..." />
                            </section>
                            <section class="tab1leftsection3cnew" style="width: 99%;">

                                <asp:TextBox ID="txtMemo" runat="server" CssClass="tab1leftsection3cTextBox" TextMode="MultiLine" Style="width: 99%;"></asp:TextBox>
                            </section>
                        </section>

                        <section class="tab1leftsection3d" style="display: none;">
                            <asp:Label ID="Label38" runat="server" Text="<%$ Resources:localizedText, visitorsByAppointment %>" CssClass="txtpersonalrightdiv3dLabel fontweight600"></asp:Label>
                        </section>
                    </section>
                    <section class="topbtnareanew">
                        <asp:Label ID="Label51" runat="server" Text="<%$ Resources:localizedText, enablevisitor %>" CssClass="Activiation"></asp:Label>
                        <asp:CheckBox ID="chkAccessPlanActive" ClientIDMode="Static" runat="server" CssClass="chkActivation" />
                        <asp:Label ID="Label98" runat="server" Text="<%$ Resources:localizedText, from %>" CssClass="lblfromto"></asp:Label>
                        <asp:TextBox ID="txtPersActivated" runat="server" Enabled="false" CssClass="txtfrom"></asp:TextBox>
                        <asp:Label ID="Label99" runat="server" Text="<%$ Resources:localizedText, am %>" CssClass="lblfromto"></asp:Label>
                        <asp:TextBox ID="txtCardActivatedTime" runat="server" Enabled="false" CssClass="txtfromto"></asp:TextBox>



                    </section>
                    <section class="visactive">
                        <section class="areaeight" style="display: none;">
                            <asp:Label ID="Label65" CssClass="lblautomatic" runat="server" Text="Langzeitausweis:"></asp:Label>
                            <asp:TextBox ID="txtCardNumber" CssClass="txtpersonalbottomsmallnewww1" runat="server" Enabled="false"></asp:TextBox>
                            <asp:ImageButton ID="imgidentity" runat="server" CssClass="buttonbesnew" />
                            <asp:Label ID="Label76" runat="server" Text="<%$ Resources:localizedText ,active %>" CssClass="lblActive"></asp:Label>
                            <asp:CheckBox ID="CheckBox2" runat="server" CssClass="chkAccssData" />
                            <asp:ImageButton ID="ImageButton1" runat="server" CssClass="btnprintarea" />

                        </section>
                        <section class="areaeight">
                            <asp:Label ID="Label66" CssClass="lblautomatic" runat="server" Text="<%$ Resources:localizedText ,shorttermid %>"></asp:Label>
                            <asp:TextBox ID="txtCardPinCode" CssClass="txtpersonalbottomsmallnewww1" runat="server" Enabled="false"></asp:TextBox>
                            <asp:ImageButton ID="imgSelection" runat="server" CssClass="buttonbesnewCards" />
                            <asp:Label ID="Label77" runat="server" Text="<%$ Resources:localizedText ,active %>" CssClass="lblActive"></asp:Label>
                            <asp:CheckBox ID="chkCardActive" ClientIDMode="Static" runat="server" CssClass="chkAccssData" />
                            <asp:ImageButton ID="ImageButton3" runat="server" CssClass="btnprintarea" />

                        </section>
                        <section class="areaeight">
                            <asp:Label ID="Label67" CssClass="lblautomatic" runat="server" Text="<%$ Resources:localizedText ,visitorplanid %>"></asp:Label>
                            <dx:ASPxComboBox ID="cobVisitorPlanNr" runat="server" SelectedIndex="0" TextFormatString="{0}" ValueField="ID" TextField="VisitorPlanNr" CssClass="drpvisplanid" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
	visitorPlanSelectedIndexChanged(s,e);
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn FieldName="VisitorPlanNr" Name="VisitorPlanNr" ToolTip="" Width="20%" Caption="Plan Nr." />
                                    <dx:ListBoxColumn FieldName="VisitorPlanDescription" Name="VisitorPlanDescription" ToolTip="Bezeichnung:" Width="80%" Caption="Plan Bezeichnung" />
                                </Columns>
                            </dx:ASPxComboBox>
                            <asp:TextBox ID="txtVisitorPlangroup" CssClass="txtpersonalbottomsmallnewww1below" runat="server" Style="display: none;"></asp:TextBox>

                            <asp:ImageButton ID="imgserchvisitorplan" runat="server" CssClass="buttonbesnewplan" Style="background-size: contain;" />
                            <asp:ImageButton ID="btnImageVisitorPlanInfo" runat="server" CssClass="buttonbesnewplan2" Style="background-size: contain;" />
                        </section>
                        <section class="areaeight">
                            <asp:Label ID="Label100" CssClass="lblautomatic" runat="server" Text="<%$ Resources:localizedText ,descriptionnew %>"></asp:Label>
                            <dx:ASPxComboBox ID="cobVisitorPlanName" runat="server" SelectedIndex="0" TextFormatString="{1}" ValueField="ID" TextField="VisitorPlanDescription" CssClass="drpdescription" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
	visitorPlanSelectedIndexChanged(s,e);
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn FieldName="VisitorPlanNr" Name="VisitorPlanNr" ToolTip="" Width="20%" Caption="Plan Nr." />
                                    <dx:ListBoxColumn FieldName="VisitorPlanDescription" Name="VisitorPlanDescription" ToolTip="Bezeichnung:" Width="80%" Caption="Plan Bezeichnung" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>
                        <section class="areaeight">
                            <asp:Label ID="Label59" runat="server" Text="<%$ Resources:localizedText, accessfrom %>" CssClass="lblautomatic fontweight600" Style="line-height: 14px;"></asp:Label>
                            <asp:Label ID="Label60" runat="server" Text="<%$ Resources:localizedText, date %>" CssClass="datearea fontweight600"></asp:Label>
                            <dx:ASPxDateEdit ID="drpVisitStartDate" ClientInstanceName="drpVisitStartDate" runat="server" Theme="Office2003Blue" CssClass="dtpckrnew" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" HorizontalAlign="Center"
                                EnableTheming="true" Font-Size="14px">
                                <ClientSideEvents DateChanged="function(s, e) {
	datePickerDateChanged(s,e);
}"></ClientSideEvents>
                            </dx:ASPxDateEdit>
                            <asp:Label ID="Label61" runat="server" Text="<%$ Resources:localizedText, timeOfDay %>" CssClass="lblDate fontweight600"></asp:Label>
                            <dx:ASPxTimeEdit ID="drpVisitStartDateTime" ClientInstanceName="drpVisitStartDateTime" ClientIDMode="Static" runat="server" CssClass="txtsize1date" DisplayFormatString="HH:mm" family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" HorizontalAlign="Center">
                                <ClientSideEvents DateChanged="function(s, e) {
	datePickerDateChanged(s,e);
}"></ClientSideEvents>
                                <SpinButtons Enabled="false" ShowIncrementButtons="false">
                                </SpinButtons>
                            </dx:ASPxTimeEdit>
                        </section>
                        <section class="areaeight">
                            <asp:Label ID="Label62" runat="server" Text="<%$ Resources:localizedText, accessto1 %>" CssClass="lblautomatic fontweight600"></asp:Label>
                            <asp:Label ID="Label63" runat="server" Text="<%$ Resources:localizedText, date %>" CssClass="datearea fontweight600"></asp:Label>
                            <dx:ASPxDateEdit ID="drpVisitEndDate" ClientInstanceName="drpVisitEndDate" runat="server" Theme="Office2003Blue" CssClass="dtpckrnew" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" EnableTheming="true" Font-Size="14px" HorizontalAlign="Center">
                                <ClientSideEvents DateChanged="function(s, e) {
	datePickerDateChanged(s,e);
}"></ClientSideEvents>
                            </dx:ASPxDateEdit>
                            <asp:Label ID="Label64" runat="server" Text="<%$ Resources:localizedText, timeOfDay %>" CssClass="lblDate fontweight600"></asp:Label>
                            <dx:ASPxTimeEdit ID="drpVisitEndDateTime" ClientInstanceName="drpVisitEndDateTime" ClientIDMode="Static" runat="server" CssClass="txtsize1date" DisplayFormatString="HH:mm" family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" HorizontalAlign="Center">
                                <ClientSideEvents DateChanged="function(s, e) {
	datePickerDateChanged(s,e);
}"></ClientSideEvents>
                                <SpinButtons Enabled="false" ShowIncrementButtons="false">
                                </SpinButtons>
                            </dx:ASPxTimeEdit>
                        </section>
                        <section class="areaeight">
                            <asp:Label ID="Label128" runat="server" Text="<%$ Resources:localizedText, usetodaydate %>" CssClass="lblDatumVon"></asp:Label>
                            <asp:CheckBox ID="chkAutomaticLogout" ClientIDMode="Static" runat="server" CssClass="chkActivationvon" />
                            <asp:Button ID="btnSendData" runat="server" Text="<%$ Resources:localizedText, senddata2 %>" CssClass="btndatanew" />
                        </section>
                        <section class="areaeight">
                            <asp:Label ID="Label129" runat="server" Text="<%$ Resources:localizedText, automaticallycheckout %>" CssClass="lblDatumum"></asp:Label>
                            <dx:ASPxTimeEdit ID="drpAutomaticLogout" ClientIDMode="Static" runat="server" CssClass="dtpckrnewtext" DisplayFormatString="HH:mm" family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" HorizontalAlign="Center">
                                <SpinButtons Enabled="false" ShowIncrementButtons="false">
                                </SpinButtons>
                            </dx:ASPxTimeEdit>
                            <asp:Button ID="btnSendLoginData" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, sendandlogincalender %>" CssClass="btndatanewein" />
                        </section>
                        <section class="areaeight" style="height: 12%;">
                            <asp:Button ID="btnVisitorBookOut" runat="server" Text="Besucher ausbuchen" CssClass="btnVisitorBookOut" />
                        </section>

                        <section class="areaeight" style="display: none">
                            <asp:Label ID="Label14" runat="server" Text="Automatische Sperre:" CssClass="lblautomatic fontweight600" Style="line-height: 14px;"></asp:Label>
                            <asp:Label ID="Label28" runat="server" Text="<%$ Resources:localizedText, date %>" CssClass="datearea fontweight600"></asp:Label>
                            <dx:ASPxDateEdit ID="drpVisitAutoDate" ClientInstanceName="drpVisitAutoDate" runat="server" Theme="Office2003Blue" CssClass="dtpckrnew" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" EnableTheming="true" Font-Size="14px" HorizontalAlign="Center">
                                <ClientSideEvents DateChanged="function(s, e) {
	datePickerDateChanged(s,e);
}"></ClientSideEvents>
                            </dx:ASPxDateEdit>
                            <asp:Label ID="Label29" runat="server" Text="<%$ Resources:localizedText, timeOfDay %>" CssClass="lblShotr fontweight600"></asp:Label>
                            <dx:ASPxTimeEdit ID="drpVisitAutoDateTime" ClientInstanceName="drpVisitAutoDateTime" ClientIDMode="Static" runat="server" CssClass="txtsize1date" DisplayFormatString="HH:mm" family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" HorizontalAlign="Center">
                                <ClientSideEvents DateChanged="function(s, e) {
	datePickerDateChanged(s,e);
}"></ClientSideEvents>
                                <SpinButtons Enabled="false" ShowIncrementButtons="false">
                                </SpinButtons>
                            </dx:ASPxTimeEdit>
                        </section>
                        <section class="areaeight" style="display: none;">
                            <asp:Label ID="Label36" runat="server" Text="Automatische Sperre:" CssClass="lblautomatic fontweight600" Style="line-height: 14px;"></asp:Label>
                            <asp:Label ID="Label34" runat="server" Text="<%$ Resources:localizedText, afterstd %>" CssClass="datearea fontweight600"></asp:Label>
                            <asp:TextBox ID="txtSTDTime" runat="server" CssClass="txtsize1"></asp:TextBox>
                            <%-- <asp:Label ID="Label50" runat="server" Text="Aktivierung löschen " CssClass="deletetime"></asp:Label>--%>
                        </section>
                    </section>
                    <section class="rightdivBottom" style="display: none;">
                        <section class="rightdivBottomLevel">
                            <asp:Label ID="Label39" runat="server" Text="<%$ Resources:localizedText, notifyingId %>" CssClass="rightdivBottomLevelLabelsnew fontweight600 ColorRed" Style="margin-top: 5px;"></asp:Label>
                            <asp:TextBox ID="TextBox28" runat="server" CssClass="txtbottomLong fontweight600 ColorRed" Style="margin-top: 5px;"></asp:TextBox>
                            <asp:Label ID="Label42" runat="server" Text="<%$ Resources:localizedText, phone %>" CssClass="lblShotrnew1 fontweight600"></asp:Label>
                            <asp:TextBox ID="TextBox29" runat="server" CssClass="txtLonger" Style="margin-top: 5px;"></asp:TextBox>
                        </section>
                        <section class="rightdivBottomLevel">
                            <asp:Label ID="Label40" runat="server" Text="<%$ Resources:localizedText, signedIn %>" CssClass="rightdivBottomLevelLabelsnew fontweight600 ColorRed"></asp:Label>
                            <asp:TextBox ID="TextBox30" runat="server" CssClass="txtbottomLong fontweight600 ColorRed"></asp:TextBox>
                            <asp:Label ID="Label43" runat="server" Text="<%$ Resources:localizedText, cellPhone %>" CssClass="lblShotrnew1 fontweight600"></asp:Label>
                            <asp:TextBox ID="TextBox31" runat="server" CssClass="txtLonger"></asp:TextBox>
                        </section>
                        <section class="rightdivBottomLevel">
                            <asp:Label ID="Label41" runat="server" Text="<%$ Resources:localizedText, filedOn %>" CssClass="rightdivBottomLevelLabelsnew fontweight600 ColorRed"></asp:Label>
                            <asp:Label ID="Label46" runat="server" Text="<%$ Resources:localizedText, date %>" CssClass="lblShort fontweight600 ColorRed"></asp:Label>
                            <asp:TextBox ID="TextBox32" runat="server" CssClass="txtsize12"></asp:TextBox>
                            <asp:Label ID="Label47" runat="server" Text="<%$ Resources:localizedText, timeOfDay %>" CssClass="lblShotrnew1 fontweight600 ColorRed"></asp:Label>
                            <asp:TextBox ID="TextBox33" runat="server" CssClass="txtsize12"></asp:TextBox>
                        </section>
                        <section class="rightdivBottomLevel">
                            <asp:Label ID="Label44" runat="server" Text="<%$ Resources:localizedText, locations %>" CssClass="rightdivBottomLevelLabels fontweight600"></asp:Label>
                            <asp:TextBox ID="TextBox34" runat="server" CssClass="txtpersonalnew"></asp:TextBox>
                        </section>
                        <section class="rightdivBottomLevel">
                            <asp:Label ID="Label45" runat="server" Text="<%$ Resources:localizedText, departments %>" CssClass="rightdivBottomLevelLabels fontweight600"></asp:Label>
                            <asp:TextBox ID="TextBox35" runat="server" CssClass="txtpersonalnew"></asp:TextBox>
                            <asp:Button ID="Button12" runat="server" Text="<%$ Resources:localizedText, more %>" CssClass="btnMehr ColorRed" />
                        </section>
                    </section>
                </div>
                <div id="rightdivgrid" class="rightdivgrid" style="display: none;">
                    <section class="gridHolderSec">
                        <dx:ASPxGridView ID="grdVisitorDescription" ClientInstanceName="grdVisitorDescription" runat="server" AutoGenerateColumns="False" Width="100%" Theme="Office2003Blue" EnablePagingGestures="False" KeyFieldName="ID" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif"
                            Font-Size="14px" EnableCallBacks="True">
                            <ClientSideEvents RowDblClick="function(s, e) {
	 grdVisitorDataDblClick(s, e)
}"></ClientSideEvents>
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Width="20%" Caption="<%$ Resources:localizedText, visitorPlannumber %>" VisibleIndex="1" FieldName="VisitorPlanNr">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Width="68%" Caption="<%$ Resources:localizedText, visitorPlandescr %>" VisibleIndex="2" FieldName="VisitorPlanDescription"></dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsBehavior AllowFocusedRow="True" AllowSort="False" AllowDragDrop="false" />
                            <SettingsPager Visible="False" PageSize="25" ShowEmptyDataRows="True">
                            </SettingsPager>
                            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />

                        </dx:ASPxGridView>
                    </section>
                    <section class="buttonHolderSec">
                        <asp:Button ID="btnAcceptAccessPlan" runat="server" Text="<%$ Resources:localizedText, applyrecord %>" CssClass="btnAcceptPlan" />
                    </section>

                </div>
                <div id="grdclient" class="rightdivgclint" style="display: none;">
                    <%--<dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="grdVisitorDescription" runat="server" AutoGenerateColumns="False" Width="100%" Theme="Office2003Blue" EnablePagingGestures="False" KeyFieldName="ID" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif"
                    Font-Size="14px" EnableCallBacks="False">

                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="15%" Caption="Firma Mandant ID:" VisibleIndex="1" FieldName="">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="85%" Caption="Name:" VisibleIndex="2" FieldName=""></dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsBehavior AllowFocusedRow="True" AllowSort="False" AllowDragDrop="false" />
                    <SettingsPager Visible="False" PageSize="21" ShowEmptyDataRows="True">
                    </SettingsPager>
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />

                </dx:ASPxGridView>--%>
                </div>

                <div id="rightdivtransponder" class="rightdivtransponder" style="display: none;">
                    <dx:ASPxGridView ID="grdTransponder" ClientInstanceName="grdTransponder" runat="server" AutoGenerateColumns="False" Width="100%" Theme="Office2003Blue" EnablePagingGestures="False" KeyFieldName="ID" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif"
                        Font-Size="14px">
                        <ClientSideEvents RowDblClick="function(s, e) {
	 grdTransponderDblClick(s, e)
}"></ClientSideEvents>
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Width="12%" Caption="<%$ Resources:localizedText, Transponderid %>" VisibleIndex="1" FieldName="ID"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Width="12%" Caption="<%$ Resources:localizedText, Transpondernumber %>" VisibleIndex="2" FieldName="TransponderNr"></dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="False" ProcessSelectionChangedOnServer="True" AllowDragDrop="false" />
                        <SettingsPager Visible="False" PageSize="21" ShowEmptyDataRows="True">
                        </SettingsPager>
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />

                    </dx:ASPxGridView>
                </div>

            </div>
            <div class="searchVehicletype" id="vehicletype" style="display: none; height: 100%;">

                <div class="secholder">
                    <section class="left">
                        <asp:Label ID="Label32" runat="server" Text="<%$ Resources:localizedText, manufacturertable %>" CssClass="herslabel"></asp:Label>
                        <section class="allgridarea">
                            <dx:ASPxGridView ID="grdManufacturer" ClientInstanceName="grdManufacturer" EnableCallBacks="true" OnCustomCallback="grdManufacturer_CustomCallback" KeyFieldName="ID" runat="server" AutoGenerateColumns="False" Width="98%">

                                <ClientSideEvents RowClick="function(s, e) {
	grdManufacturerRowClick(s,e);
}"
                                    EndCallback="function(s, e) {
grdManufacturerEndCallBack(s,e);	
}"></ClientSideEvents>

                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" FieldName="ID" Visible="false">
                                        <HeaderStyle BackColor="#ffffff" ForeColor="Black" HorizontalAlign="Left"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Hersteller" VisibleIndex="1" FieldName="Name">
                                        <HeaderStyle BackColor="#ffffff" ForeColor="Black" HorizontalAlign="Left"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="false" />
                                <SettingsPager PageSize="24" ShowEmptyDataRows="True" Visible="False">
                                </SettingsPager>
                            </dx:ASPxGridView>

                        </section>
                    </section>
                    <section class="center">
                        <section class="slabel">
                            <asp:Label ID="lblVehicleManu" runat="server" CssClass="labelcenter" Text=""></asp:Label>
                        </section>
                        <section class="simage">
                            <asp:ImageButton ID="imgArrow" runat="server" ImageUrl="~/Images/FormImages/addtogrid.png" CssClass="arrowgrid" />
                        </section>
                    </section>
                    <section class="right">
                        <asp:Label ID="Label130" runat="server" Text="" CssClass="herslabel"></asp:Label>
                        <section class="allgridarea">
                            <dx:ASPxGridView ID="grdVehicleModel" ClientInstanceName="grdVehicleModel" OnCustomCallback="grdVehicleModel_CustomCallback" KeyFieldName="ID" runat="server" AutoGenerateColumns="False" Width="66%">
                                <ClientSideEvents RowClick="function(s, e) {
	grdVehicleModelRowClick(s,e);
}"
                                    RowDblClick="function(s, e) {
grdVehicleModelRowDbClick(s,e);	
}"></ClientSideEvents>

                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" FieldName="ID" Visible="false">
                                        <HeaderStyle BackColor="#ffffff" ForeColor="Black" HorizontalAlign="Left"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, typeOfvehicle %>" VisibleIndex="1" FieldName="Type">
                                        <HeaderStyle BackColor="#ffffff" ForeColor="Black" HorizontalAlign="Left"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="false" />
                                <SettingsPager PageSize="24" ShowEmptyDataRows="True" Visible="False">
                                </SettingsPager>
                            </dx:ASPxGridView>

                        </section>
                    </section>
                </div>
                <div class="secbelow">
                    <section class="secbelowl">
                        <asp:Label ID="Label131" runat="server" CssClass="lblhers" Text="<%$ Resources:localizedText, createmanufacturer %>"></asp:Label>
                        <asp:TextBox ID="txtManufacturerId" runat="server" Style="display: none" CssClass="txthers"></asp:TextBox>
                        <asp:TextBox ID="txtManufacturer" runat="server" CssClass="txthers"></asp:TextBox>
                    </section>
                    <section class="secbelowr">
                        <asp:Label ID="Label132" runat="server" Text="<%$ Resources:localizedText, createvehicletype %>" CssClass="lblfah"></asp:Label>
                        <asp:TextBox ID="txtVehicleModelId" Style="display: none" runat="server" CssClass="txtfah"></asp:TextBox>
                        <%--  <asp:TextBox ID="txtvehicleModel" runat="server"></asp:TextBox>--%>
                        <asp:TextBox ID="txtModelType" runat="server" CssClass="txtfah"></asp:TextBox>
                        <asp:Button ID="btnApplyVehicleType" ClientIDMode="Static" CssClass="editbtnfooterorange" runat="server" Text="<%$ Resources:localizedText, takeover %>" Style="float: right; clear: both; width: 116px; height: 15px; margin-right: -15px;" />

                    </section>
                </div>
                <div id="visitorcartype" class="Controlvisitorcartype" style="display: none;">
                    <%--OLD CAR TYPE AREA--%>
                    <section class="secSelectiontop1cartype">
                        <asp:Label ID="Label108" runat="server" Text="PKW" CssClass="lblTitlenew"></asp:Label>

                    </section>
                    <section class="secSelectiontop1cartype">
                        <section class="txtSearchVisitorareascartype" style="margin-left: 5px;">
                            <asp:Label ID="Label50" runat="server" Text="<%$ Resources:localizedText, manufacturer %>" CssClass="lblnamecar"></asp:Label>
                            <dx:ASPxComboBox ID="cboCarTypes" ClientInstanceName="cboCarTypes" ValueField="ID" EnableCallbackMode="true" TextField="Name" TextFormatString="{0}" runat="server" CssClass="drpallcar" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="300px" Font-Size="14px" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cboCarTypesSelectedIndexChanged(s,e);
}"
                                    EndCallback="function(s, e) {
	cboCarTypesEndCallBack(s,e);
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn FieldName="Name" Name="Name" ToolTip="" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>


                    </section>
                </div>
                <section class="areaonetwo" style="display: none;">
                    <%--OLD CAR TYPE AREA--%>
                    <div class="Wrappernew3">
                        <div id="GridIdNr" class="gridIdNr">
                        </div>
                        <div id="Grid3" class="Grid2">
                            <section style="display: none">
                                <asp:DropDownList ID="DropDownList3" runat="server" Visible="true" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" AutoPostBack="true" DataTextField="Name" DataValueField="ID">
                                </asp:DropDownList>
                            </section>
                            <section id="fvSec3" style="width: 99%; height: 100%">

                                <section style="width: 49%; height: 100%; float: left; border-right: 1px solid grey;">
                                    <asp:Label ID="lblmanufacture" runat="server" Text="<%$ Resources:localizedText,manufacturer12 %>" CssClass="lblptypenew2" Style="float: left; width: 98%; text-align: left;"></asp:Label>
                                    <asp:TextBox ID="txtVehicleTypeId" runat="server" CssClass="txtptype" Style="display: none;"></asp:TextBox>
                                    <asp:TextBox ID="txtvehicleType" runat="server" CssClass="txtptype" Style="float: left; width: 95%;"></asp:TextBox>
                                    <%--  <dx:ASPxComboBox ID="cboVehicle_Type" runat="server" ValueType="System.String" CssClass="txtpmemonew" Theme="Office2003Blue" style="float:left; width: 98%; display:none; "></dx:ASPxComboBox>--%>
                                </section>
                                <section style="float: left; width: 50%; height: 100%">
                                    <asp:Label ID="lblCartype" runat="server" Text="<%$ Resources:localizedText,typevehicle1 %>" CssClass="lblptypenew2" Style="float: left; width: 98%; text-align: left;"></asp:Label>
                                    <%-- <asp:TextBox ID="txtvehicleModel1" runat="server" CssClass="txtpmemonew" Style="margin-top: 4px; float: left; width: 98%;"></asp:TextBox>--%>
                                </section>
                            </section>
                        </div>


                    </div>
                    <section class="ActionBtnsBottom2" style="width: 100% !important; float: left !important; display: none;">
                    </section>
                    <section class="buttonHolderSecnew">
                        <asp:Button ID="btnTakeOver" ClientIDMode="Static" CssClass="BottomFooterBtnsRight btnAcceptCompany" runat="server" Text="<%$ Resources:localizedText, applyrecord %>" />
                    </section>
                </section>
            </div>
            <div class="searchclint" id="client" style="display: none;">
                <div class="Wrappernew3">
                    <div id="GrdIdNr" class="gridIdNr">
                        <%--          <dx:ASPxGridView ID="grdClientsnew"  runat="server" KeyFieldName="ID" ClientIDMode="Static" CellPadding="4" ForeColor="#333333" Width="100%" GridLines="Both" Theme="Office2003Blue"" AutoGenerateColumns="False" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="14px">
                        <ClientSideEvents RowClick="function(s, e) {
	grdvwgrdClientsRowClick(s, e)
}"
                            RowDblClick="function(s, e) {
 grdClientsRowDBClick(s,e);
}"></ClientSideEvents>
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, companyclientid %>" VisibleIndex="1" FieldName="Client_Nr" Visible="False" Width="15%">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, clientsnew %>" VisibleIndex="2" FieldName="Name" Width="85%">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="False" VisibleIndex="0">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsBehavior AllowFocusedRow="true" AllowDragDrop="false" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="true" />
                        <SettingsPager PageSize="11" ShowEmptyDataRows="True" Visible="False">
                        </SettingsPager>
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                    </dx:ASPxGridView>--%>
                    </div>

                    <div id="Grid4" class="Grid2">
                        <section style="display: none">
                            <asp:DropDownList ID="DropDownList5" runat="server" Visible="true" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" AutoPostBack="true" DataTextField="Name" DataValueField="ID">
                            </asp:DropDownList>
                        </section>
                        <section id="fvSec3" style="width: 100%; height: 100%">

                            <section>
                                <asp:Label ID="Label74" runat="server" Text="<%$ Resources:localizedText, companyclientid %>" CssClass="lblclient" Style="width: 20%;"></asp:Label>
                                <asp:TextBox ID="txtClientNr" runat="server" Enabled="true" CssClass="txtpclientdesc" Text='<%# Bind("Name") %>'></asp:TextBox>
                            </section>
                            <section>
                                <asp:Label ID="Label75" runat="server" Text="<%$ Resources:localizedText, clientsnew %>" CssClass="lblptypenew"></asp:Label>
                                <asp:TextBox ID="txtClientName" runat="server" Enabled="true" CssClass="txtpmemonew" Text='<%# Bind("Type") %>'></asp:TextBox>
                            </section>
                        </section>
                    </div>

                    <section class="ActionBtnsBottom">
                        <%-- <asp:Button ID="btnNew" CssClass="GridFooterBtnsLeft btnNew" runat="server" Text="<%$ Resources:localizedText, newButton %>" />
                    <asp:Button ID="btnSave" CssClass="GridFooterBtnsLeft btnSave" runat="server" Text="<%$ Resources:localizedText, saveButton %>" />
                    <asp:Button ID="btnDelete" CssClass="GridFooterBtnsLeft btnLöschen" runat="server" Text="<%$ Resources:localizedText, deleteButton %>" />
                    <asp:Button ID="btnCompanyBack" CssClass="BottomFooterBtnsRight btnClose" runat="server" Text="<%$ Resources:localizedText, backButton %>" />--%>
                    </section>
                </div>

            </div>
            <div class="searchclintnewclint" style="display: none;"> 
                <section class="btmsecLeftMid" style="width: 100%;">
                    <section class="innersec" style="width: 945px;">
                        <section class="upperbtmsecLeftMid">
                            <section class="secdiv">
                                <section style="display: none;">
                                    <dx:ASPxComboBox ID="cboCompanyNr" ClientInstanceName="cboCompanyNr" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                                </section>
                                <section style="display: none;">
                                    <asp:TextBox ID="txtCompanyId" runat="server" CssClass="txtsec2"></asp:TextBox>
                                </section>
                                <section class="secdivleft">
                                    <asp:Label ID="lblloc" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, companyno %>"></asp:Label>
                                    <asp:TextBox ID="txtCompanyNr" runat="server" CssClass="txtsec2"></asp:TextBox>
                                </section>
                                <section class="secdivright">
                                    <asp:Label ID="lblCustomerData" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, company %>"></asp:Label>
                                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="txtsec" Style="width: 360px;"></asp:TextBox>
                                </section>
                            </section>
                            <section class="secdiv">
                                <section class="secdivleft">
                                    <asp:Label ID="lblPlz" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, postcode %>"></asp:Label>
                                    <asp:TextBox ID="txtCompanyZipCode" runat="server" CssClass="txtsec2"></asp:TextBox>
                                </section>
                                <section class="secdivright">
                                    <asp:Label ID="lblOrt" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, placeTitle %>"></asp:Label>
                                    <asp:TextBox ID="txtCompanyPlace" runat="server" CssClass="txtsec" Style="width: 360px;"></asp:TextBox>
                                </section>
                            </section>
                            <section>
                            </section>
                            <section class="secdiv">
                                <section class="secdivleft">
                                    <asp:Label ID="Label1101" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, street2 %>"></asp:Label>
                                    <asp:TextBox ID="txtCompanyStreet" runat="server" CssClass="txtsec"></asp:TextBox>
                                </section>
                                <section class="secdivright">
                                    <asp:Label ID="lblStreet" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, no2 %>"></asp:Label>
                                    <asp:TextBox ID="txtCompanyHouseNr" runat="server" CssClass="txtsec2"></asp:TextBox>
                                </section>
                            </section>
                            <section class="secdiv">
                                <section class="secdivleft">
                                    <asp:Label ID="lblState" runat="server" CssClass="lblsecnew" Text="<%$ Resources:localizedText, state2 %>"></asp:Label>
                                    <dx:ASPxComboBox ID="cboCompanyState" CssClass="bunddlist" ClientIDMode="Static" ClientInstanceName="cboCompanyState" Theme="Aqua" runat="server" ValueField="ID" TextField="StateName"
                                        SelectedIndex="0" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" DropDownWidth="300px" ValueType="System.String" Style="width: 238px;">
                                    </dx:ASPxComboBox>
                                </section>
                            </section>
                        </section>
                        <section class="lowerbtmsecLeftMid">
                            <section class="lowerbtmsecLeftMidL">
                                <section class="topsec">
                                    <asp:Label ID="lblRespPerson" runat="server" CssClass="lblheader" Text="<%$ Resources:localizedText, responsiblePerson %>"></asp:Label>
                                </section>
                                <section class="btmsec">
                                    <section class="secdiv2">
                                        <asp:Label ID="lblName" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, name %>"></asp:Label>
                                        <asp:TextBox ID="txtCompanyPersName" ClientIDMode="Static" runat="server" CssClass="txtsec3"></asp:TextBox>
                                    </section>
                                    <section class="secdiv2">
                                        <asp:Label ID="lblFunct" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, function2 %>"></asp:Label>
                                        <asp:TextBox ID="txtCompanyFunct" runat="server" CssClass="txtsec3"></asp:TextBox>
                                    </section>
                                    <section class="secdiv2">
                                        <asp:Label ID="lblTel" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, telephone %>"></asp:Label>
                                        <asp:TextBox ID="txtCompanyTel" runat="server" CssClass="txtPhone"></asp:TextBox>
                                    </section>
                                    <section class="secdiv2">
                                        <asp:Label ID="lblMob" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, mobile2 %>"></asp:Label>
                                        <asp:TextBox ID="txtCompanyMob" ClientIDMode="Static" runat="server" CssClass="txtPhone"></asp:TextBox>
                                    </section>
                                    <section class="secdiv2">
                                        <asp:Label ID="lblEmail" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, email2 %>"></asp:Label>
                                        <asp:TextBox ID="txtCompanyEmail" runat="server" CssClass="txtsec3"></asp:TextBox>
                                    </section>
                                </section>
                            </section>
                            <section class="lowerbtmsecLeftMidR">
                                <section class="topsec">
                                    <asp:Label ID="lblMemo" runat="server" CssClass="lblheader" Text="<%$ Resources:localizedText, memo %>"></asp:Label>
                                </section>
                                <section class="btmsec">
                                    <asp:TextBox ID="txtCompanyMemo" CssClass="txtMemo" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
                                </section>
                            </section>
                        </section>
                    </section>
                    <%--<section class="btmsecLeftMidcreatenew">
                        <asp:Button ID="btnNewCompany" CssClass="BottomFooterBtnsLeftnew_vis " runat="server" Text="<%$ Resources:localizedText, newCompany %>" />
                        <asp:Button ID="btnSaveCompany" ClientIDMode="Static" CssClass="BottomFooterBtnsLeftsave " runat="server" Text="<%$ Resources:localizedText, saveVisitorCompany %>" />
                        <asp:Button ID="btnDeleteCompany" ClientIDMode="Static" Style="display: none;" CssClass="BottomFooterBtnsLeftdelete " runat="server" Text="<%$ Resources:localizedText, deleteButton %>" />

                        <asp:Button ID="btnBackCompany" ClientIDMode="Static" CssClass="BottomFooterBtnBack " runat="server" Text="<%$ Resources:localizedText, backButton %>" style="display:none;"/>

                    </section>--%>
                    <asp:Button ID="btnApplyCompany" runat="server" Text="<%$ Resources:localizedText, accept %>" CssClass="btnApplyCompany" Style="float: left;" />
                </section>








            </div>
            <div class="searchclintnewclintmanant" style="display: none;">

                <section class="btmsecLeftMid">
                    <section class="innersec">
                        <section class="upperbtmsecLeftMid">
                            <section class="secdiv">
                                <section style="display: none;">
                                    <dx:ASPxComboBox ID="ASPxComboBox1" ClientInstanceName="cboCompanyNr" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                                </section>
                                <section class="secdivleft">
                                    <asp:Label ID="Label111" runat="server" CssClass="lblsec2" Text="Mandanten Nr.:"></asp:Label>
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="txtsec2"></asp:TextBox>
                                </section>
                                <section class="secdivright">
                                    <asp:Label ID="Label112" runat="server" CssClass="lblsec" Text="Mandanten:"></asp:Label>
                                    <asp:TextBox ID="TextBox5" runat="server" CssClass="txtsec"></asp:TextBox>
                                </section>
                            </section>
                            <section class="secdiv">
                                <section class="secdivleft">
                                    <asp:Label ID="Label113" runat="server" CssClass="lblsec2" Text="PLZ:"></asp:Label>
                                    <asp:TextBox ID="TextBox6" runat="server" CssClass="txtsec2"></asp:TextBox>
                                </section>
                                <section class="secdivright">
                                    <asp:Label ID="Label114" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, placeTitle %>"></asp:Label>
                                    <asp:TextBox ID="TextBox7" runat="server" CssClass="txtsec"></asp:TextBox>
                                </section>
                            </section>
                            <section>
                            </section>
                            <section class="secdiv">
                                <section class="secdivleft">
                                    <asp:Label ID="Label115" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, street2 %>"></asp:Label>
                                    <asp:TextBox ID="TextBox8" runat="server" CssClass="txtsec"></asp:TextBox>
                                </section>
                                <section class="secdivright">
                                    <asp:Label ID="Label116" runat="server" CssClass="lblsec" Text="Nr.:"></asp:Label>
                                    <asp:TextBox ID="TextBox9" runat="server" CssClass="txtsec2"></asp:TextBox>
                                </section>
                            </section>
                            <section class="secdiv">
                                <section class="secdivleft">
                                    <asp:Label ID="Label117" runat="server" CssClass="lblsecnew" Text="<%$ Resources:localizedText, state2 %>"></asp:Label>
                                    <dx:ASPxComboBox ID="ASPxComboBox2" CssClass="bunddlist" Theme="Aqua" runat="server" ValueField="ID" TextField="StateName"
                                        SelectedIndex="0" ValueType="System.String">
                                    </dx:ASPxComboBox>
                                </section>
                            </section>
                        </section>
                        <section class="lowerbtmsecLeftMid">
                            <section class="lowerbtmsecLeftMidL">
                                <section class="topsec">
                                    <asp:Label ID="Label118" runat="server" CssClass="lblheader" Text="<%$ Resources:localizedText, responsiblePerson %>"></asp:Label>
                                </section>
                                <section class="btmsec">
                                    <section class="secdiv2">
                                        <asp:Label ID="Label119" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, name %>"></asp:Label>
                                        <asp:TextBox ID="TextBox10" ClientIDMode="Static" runat="server" CssClass="txtsec3"></asp:TextBox>
                                    </section>
                                    <section class="secdiv2">
                                        <asp:Label ID="Label120" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, function2 %>"></asp:Label>
                                        <asp:TextBox ID="TextBox11" runat="server" CssClass="txtsec3"></asp:TextBox>
                                    </section>
                                    <section class="secdiv2">
                                        <asp:Label ID="Label121" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, telephone %>"></asp:Label>
                                        <asp:TextBox ID="TextBox13" runat="server" CssClass="txtPhone"></asp:TextBox>
                                    </section>
                                    <section class="secdiv2">
                                        <asp:Label ID="Label122" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, mobile2 %>"></asp:Label>
                                        <asp:TextBox ID="TextBox14" ClientIDMode="Static" runat="server" CssClass="txtPhone"></asp:TextBox>
                                    </section>
                                    <section class="secdiv2">
                                        <asp:Label ID="Label123" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, email2 %>"></asp:Label>
                                        <asp:TextBox ID="TextBox15" runat="server" CssClass="txtsec3"></asp:TextBox>
                                    </section>
                                </section>
                            </section>
                            <section class="lowerbtmsecLeftMidR">
                                <section class="topsec">
                                    <asp:Label ID="Label124" runat="server" CssClass="lblheader" Text="<%$ Resources:localizedText, memo %>"></asp:Label>
                                </section>
                                <section class="btmsec">
                                    <asp:TextBox ID="TextBox16" CssClass="txtMemo" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
                                </section>
                            </section>
                        </section>
                    </section>
                    <section class="btmsecLeftMidcreatenew">
                        <asp:Button ID="Button1" CssClass="BottomFooterBtnsLeftnew_vis " runat="server" Text="<%$ Resources:localizedText, newButton %>" />
                        <asp:Button ID="Button3" ClientIDMode="Static" CssClass="BottomFooterBtnsLeftsave " runat="server" Text="<%$ Resources:localizedText, saveButton %>" />
                        <asp:Button ID="Button5" ClientIDMode="Static" CssClass="BottomFooterBtnsLeftdelete " runat="server" Text="<%$ Resources:localizedText, deleteButton %>" />
                        <asp:Button ID="Button6" ClientIDMode="Static" CssClass="BottomFooterBtnBack " runat="server" Text="<%$ Resources:localizedText, backButton %>" />
                    </section>
                </section>

            </div>
            <div class="searchVisitors" style="display: none;">
                <dx:ASPxGridView ID="grdSearchVisitors" SettingsBehavior-AllowSort="false" ClientInstanceName="grdSearchVisitors" OnCustomCallback="grdSearchVisitors_CustomCallback" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="false" KeyFieldName="ID">
                    <ClientSideEvents RowDblClick="function(s, e) {
	grdSearchVisitorsDblClick(s, e)
}"
                        EndCallback="function(s, e) {
	grdSearchVisitorEndCallBack(s,e);
}"></ClientSideEvents>
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="false" VisibleIndex="0"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="8%" Caption="<%$ Resources:localizedText, applications2 %>" VisibleIndex="1" FieldName="VisitorID">
                            <CellStyle BackColor="#ADDCCB" Border-BorderColor="Gray" ForeColor="Black" HorizontalAlign="Left"></CellStyle>
                            <HeaderStyle BackColor="#ADDCCB" />

                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="7%" Caption="<%$ Resources:localizedText, telephone %>" VisibleIndex="2" FieldName="Telephone">
                            <CellStyle BackColor="#ADDCCB" Border-BorderColor="Gray" ForeColor="Black" HorizontalAlign="Left"></CellStyle>
                            <HeaderStyle BackColor="#ADDCCB" />

                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="3%" Caption="<%$ Resources:localizedText, no2 %>" VisibleIndex="3" Visible="false" FieldName="">


                            <HeaderStyle BackColor="#f69679" ForeColor="Black" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="13%" Caption="<%$ Resources:localizedText, companyClient %>" VisibleIndex="4" FieldName="Company">


                            <HeaderStyle BackColor="#f69679" ForeColor="Black" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="5%" Caption="<%$ Resources:localizedText, postcode %>" VisibleIndex="5" FieldName="CompanyPostalCode">


                            <HeaderStyle BackColor="#f69679" ForeColor="Black" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black" HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="8%" Caption="<%$ Resources:localizedText, place2 %>" VisibleIndex="6" FieldName="CompanyLocation">


                            <HeaderStyle BackColor="#f69679" ForeColor="Black" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="7%" Caption="<%$ Resources:localizedText, street %>" VisibleIndex="7" FieldName="CompanyStreet">


                            <HeaderStyle BackColor="#f69679" ForeColor="Black" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="3%" Caption="<%$ Resources:localizedText, no2 %>" VisibleIndex="8" FieldName="CompanyStreetNr">


                            <HeaderStyle BackColor="#f69679" ForeColor="Black" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black" HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="5%" Caption="<%$ Resources:localizedText, visitorID %>" VisibleIndex="9" FieldName="VisitorID">


                            <HeaderStyle BackColor="#f69679" ForeColor="Black" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black" HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="15%" Caption="Name:" VisibleIndex="10" FieldName="SurName">
                            <HeaderStyle BackColor="#f69679" ForeColor="Black" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="7%" Caption="<%$ Resources:localizedText, telephone %>" VisibleIndex="11" FieldName="Telephone">
                            <HeaderStyle BackColor="#f69679" ForeColor="Black" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black" HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="7%" Caption="<%$ Resources:localizedText, mobile2 %>" VisibleIndex="12" FieldName="Mobile">
                            <HeaderStyle BackColor="#f69679" ForeColor="Black" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black" HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Width="5%" Caption="<%$ Resources:localizedText, visitorsSince_new %>" VisibleIndex="13" FieldName="vStartDate">
                            <HeaderStyle BackColor="#FFF1C6" HorizontalAlign="Center" />
                            <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTimeEditColumn Width="5%" Caption="<%$ Resources:localizedText, time_new %>" VisibleIndex="14" FieldName="vStartDate">
                            <HeaderStyle BackColor="#FFF1C6" HorizontalAlign="Center" />
                            <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTimeEditColumn>
                        <dx:GridViewDataDateColumn Width="5%" Caption="<%$ Resources:localizedText, to %>" VisibleIndex="15" FieldName="vEndDate">
                            <HeaderStyle BackColor="#FFF1C6" HorizontalAlign="Center" />
                            <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTimeEditColumn Width="6%" Caption="<%$ Resources:localizedText, time_new %>" VisibleIndex="16" FieldName="vEndDate">
                            <HeaderStyle BackColor="#FFF1C6" HorizontalAlign="Center" />
                            <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTimeEditColumn>
                    </Columns>

                    <SettingsPager Visible="False" ShowEmptyDataRows="true" PageSize="26"></SettingsPager>
                    <SettingsBehavior AllowFocusedRow="true" AllowDragDrop="false" AllowSort="false" />
                    <SettingsDataSecurity AllowDelete="False" AllowInsert="False" AllowEdit="False"></SettingsDataSecurity>
                </dx:ASPxGridView>
            </div>
            <div class="searchPersonToVisit" style="display: none">
                <dx:ASPxGridView ID="grdSearchPersonToVisit" ClientInstanceName="grdSearchPersonToVisit" SettingsBehavior-AllowSort="false" runat="server" AutoGenerateColumns="False" Theme="Office2003Blue" EnableTheming="True" Width="100%" KeyFieldName="ID">
                    <ClientSideEvents RowDblClick="function(s, e) {
	searchPersonToVisitDblClick(s, e)
}"></ClientSideEvents>
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID" Visible="false" VisibleIndex="0" FieldName="ID">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, personnelNo2 %>" VisibleIndex="1" FieldName="Pers_Nr">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, identification %>" VisibleIndex="2" FieldName="Card_Nr">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, lastName %>" VisibleIndex="3" FieldName="LastName">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, firstName %>" VisibleIndex="4" FieldName="FirstName">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, location2 %>" VisibleIndex="5" FieldName="LocationName">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, depatmentTitle %>" VisibleIndex="6" FieldName="DepartmentName">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, costcenter2%>" VisibleIndex="7" FieldName="CostCenterName">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewCommandColumn Caption="E-mail" Visible="false" ShowClearFilterButton="True" VisibleIndex="8" ShowSelectCheckbox="True" />

                    </Columns>

                    <SettingsPager Visible="False" ShowEmptyDataRows="true" Mode="ShowAllRecords"></SettingsPager>
                    <SettingsBehavior AllowFocusedRow="true" AllowSort="false" AllowDragDrop="false" />
                    <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                </dx:ASPxGridView>
            </div>
        </div>

        <div class="Visitorsapplication" style="display: none;">
            <dx:ASPxGridView ID="grdFilteredVisitors" ClientInstanceName="grdFilteredVisitors" KeyFieldName="ID" OnCustomCallback="grdFilteredVisitors_CustomCallback" SettingsBehavior-AllowSort="false" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="false">

                <ClientSideEvents RowDblClick="function(s, e) {
	grdFilteredVisitorsRowDbClick(s,e);
}"></ClientSideEvents>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="false" VisibleIndex="0"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="8%" Caption="<%$ Resources:localizedText, applications2 %>" VisibleIndex="1" FieldName="PersName">
                        <CellStyle BackColor="#E4F2EC" Border-BorderColor="Gray" ForeColor="Black"></CellStyle>
                        <HeaderStyle BackColor="#E4F2EC" Font-Bold="true" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="7%" Caption="<%$ Resources:localizedText, telephone %>" VisibleIndex="2" FieldName="PersPhoneNr">
                        <HeaderStyle BackColor="#E4F2EC" HorizontalAlign="Center" ForeColor="Black" Font-Bold="true" />
                        <CellStyle BackColor="#E4F2EC" Border-BorderColor="Gray" HorizontalAlign="Left" ForeColor="Black"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="3%" Caption="<%$ Resources:localizedText, no2 %>" VisibleIndex="3" FieldName="CompanyNr" Visible="false">
                        <HeaderStyle BackColor="#FCD3CF" HorizontalAlign="Center" ForeColor="Black" Font-Bold="true" />
                        <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" HorizontalAlign="Left" ForeColor="Black"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="13%" Caption="<%$ Resources:localizedText, companyClient %>" VisibleIndex="4" FieldName="Company">
                        <HeaderStyle BackColor="#FCD3CF" ForeColor="Black" Font-Bold="true" HorizontalAlign="Left" />
                        <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" ForeColor="Black"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="5%" Caption="<%$ Resources:localizedText, postcode %>" VisibleIndex="5" FieldName="CompanyPostalCode">
                        <HeaderStyle BackColor="#FCD3CF" HorizontalAlign="Center" Font-Bold="true" />
                        <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" HorizontalAlign="Left" ForeColor="Black"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="8%" Caption="<%$ Resources:localizedText, place2 %>" VisibleIndex="6" FieldName="CompanyLocation">
                        <HeaderStyle BackColor="#FCD3CF" Font-Bold="true" />
                        <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" ForeColor="Black"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="10%" Caption="<%$ Resources:localizedText, street %>" VisibleIndex="7" FieldName="CompanyStreet">
                        <HeaderStyle BackColor="#FCD3CF" Font-Bold="true" />
                        <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" ForeColor="Black"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="3%" Caption="<%$ Resources:localizedText, no2 %>" VisibleIndex="8" Visible="false" FieldName="CompanyStreetNr">
                        <HeaderStyle BackColor="#FCD3CF" HorizontalAlign="Center" Font-Bold="true" />
                        <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" ForeColor="Black" HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="5%" Caption="<%$ Resources:localizedText, visitorID %>" VisibleIndex="9" FieldName="VisitorID">
                        <HeaderStyle BackColor="#FCD3CF" HorizontalAlign="Center" Font-Bold="true" />
                        <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" HorizontalAlign="Left" ForeColor="Black"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="12%" Caption="Name:" VisibleIndex="10" FieldName="VisitorName">
                        <HeaderStyle BackColor="#FCD3CF" Font-Bold="true" />
                        <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" ForeColor="Black"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="7%" Caption="<%$ Resources:localizedText, telephone %>" VisibleIndex="11" FieldName="Telephone">
                        <HeaderStyle BackColor="#FCD3CF" HorizontalAlign="Center" Font-Bold="true" />
                        <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" HorizontalAlign="Left" ForeColor="Black"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="7%" Caption="<%$ Resources:localizedText, mobile2 %>" VisibleIndex="12" FieldName="Mobile">
                        <HeaderStyle BackColor="#FCD3CF" HorizontalAlign="Center" Font-Bold="true" />
                        <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" HorizontalAlign="Left" ForeColor="Black"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Width="5%" Caption="<%$ Resources:localizedText, visitorsSince_new %>" VisibleIndex="13" FieldName="vStartDate">
                        <HeaderStyle BackColor="#FFF6DC" HorizontalAlign="Center" Font-Bold="true" />
                        <CellStyle BackColor="#FFF6DC" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black"></CellStyle>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTimeEditColumn Width="4%" Caption="<%$ Resources:localizedText, time_new %>" VisibleIndex="14" FieldName="vStartDate">
                        <HeaderStyle BackColor="#FFF6DC" HorizontalAlign="Center" Font-Bold="true" />
                        <CellStyle BackColor="#FFF6DC" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black"></CellStyle>
                    </dx:GridViewDataTimeEditColumn>
                    <dx:GridViewDataDateColumn Width="5%" Caption="<%$ Resources:localizedText, to %>" VisibleIndex="15" FieldName="vEndDate">
                        <HeaderStyle BackColor="#FFF6DC" HorizontalAlign="Center" Font-Bold="true" />
                        <CellStyle BackColor="#FFF6DC" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black"></CellStyle>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTimeEditColumn Width="4%" Caption="<%$ Resources:localizedText, time_new %>" VisibleIndex="16" FieldName="vEndDate">
                        <HeaderStyle BackColor="#FFF6DC" HorizontalAlign="Center" Font-Bold="true" />
                        <CellStyle BackColor="#FFF6DC" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black"></CellStyle>
                    </dx:GridViewDataTimeEditColumn>
                </Columns>

                <SettingsPager Visible="False" ShowEmptyDataRows="true" PageSize="34"></SettingsPager>
                <SettingsBehavior AllowFocusedRow="true" AllowDragDrop="false" AllowSort="false" />
                <SettingsDataSecurity AllowDelete="False" AllowInsert="False" AllowEdit="False"></SettingsDataSecurity>
            </dx:ASPxGridView>

        </div>
      
        <div class="Visitorsapplicationnewvishis" style="display: none;">
            <dx:ASPxGridView ID="grdVisitorsHistory" ClientInstanceName="grdVisitorsHistory" OnCustomCallback="grdVisitorsHistory_CustomCallback" KeyFieldName="ID" EnableCallBacks="true" SettingsBehavior-AllowSort="false" runat="server" Width="100%" AutoGenerateColumns="False" Theme="Office2003Blue" EnableTheming="True">
                <ClientSideEvents RowDblClick="function(s, e) {
	grdVisitorsHistoryDblClick(s, e)
}"
                    EndCallback="function(s, e) {
	grdVisitorsHistoryEndCallBack(s,e);
}"></ClientSideEvents>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="false" VisibleIndex="0"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="3%" HeaderStyle-HorizontalAlign="Center" Caption="<%$ Resources:localizedText, no2 %>" VisibleIndex="1" FieldName="CompanyNr">
                        <CellStyle HorizontalAlign="Right"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="11%" Caption="<%$ Resources:localizedText, companyClient %>" VisibleIndex="2"  FieldName="Company"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="4%" Caption="PLZ:" VisibleIndex="3" HeaderStyle-HorizontalAlign="Center"  FieldName="CompanyPostalCode">
                        <CellStyle HorizontalAlign="Right"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="11%" Caption="<%$ Resources:localizedText, place2 %>" VisibleIndex="4"  FieldName="CompanyLocation"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="11%" Caption="<%$ Resources:localizedText, street %>" VisibleIndex="5"  FieldName="CompanyStreet"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="3%" Caption="<%$ Resources:localizedText, no2 %>" VisibleIndex="6" HeaderStyle-HorizontalAlign="Center" Visible="false" FieldName="CompanyStreet">
                        <CellStyle HorizontalAlign="Right"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="4%" Caption="<%$ Resources:localizedText, visitorID %>" VisibleIndex="7" HeaderStyle-HorizontalAlign="Center"  FieldName="VisitorID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="11%" Caption="Name:" VisibleIndex="8" FieldName="VisitorName"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="8%" Caption="<%$ Resources:localizedText, telephone %>" VisibleIndex="9" HeaderStyle-HorizontalAlign="Center"  FieldName="Telephone">
                        <CellStyle HorizontalAlign="Right"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="8%" Caption="<%$ Resources:localizedText, mobile2 %>" VisibleIndex="10" HeaderStyle-HorizontalAlign="Center"  FieldName="Mobile">
                        <CellStyle HorizontalAlign="Right"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="11%" Caption="E-mail:" VisibleIndex="11" FieldName="Email" HeaderStyle-HorizontalAlign="Center" ></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="5%" Caption="<%$ Resources:localizedText, accessfrom %>" VisibleIndex="12" FieldName="" HeaderStyle-HorizontalAlign="Center"  Visible="false">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="5%" Caption="<%$ Resources:localizedText, to %>" VisibleIndex="13" HeaderStyle-HorizontalAlign="Center"  Visible="false">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="5%" Caption="<%$ Resources:localizedText, timeTitle %>" VisibleIndex="14" HeaderStyle-HorizontalAlign="Center"  Visible="false">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsPager Visible="False" ShowEmptyDataRows="true" PageSize="32"></SettingsPager>
                <SettingsBehavior AllowFocusedRow="true" AllowDragDrop="false" AllowSort="false" />
                <SettingsDataSecurity AllowDelete="False" AllowInsert="False" AllowEdit="False"></SettingsDataSecurity>
            </dx:ASPxGridView>
        </div>
        

        <div class="Visitorclient" style="display: none;">
            <section class="SecSearcVisitorCompanyGrid">
                <dx:ASPxGridView ID="grdVisitorCompany" ClientInstanceName="grdVisitorCompany" KeyFieldName="ID" OnCustomCallback="grdVisitorCompany_CustomCallback" SettingsBehavior-AllowSort="false" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True">
                    <ClientSideEvents RowDblClick="function(s, e) {
	grdVisitorCompanyDblClick(s, e)
}"
                        RowClick="function(s, e) {
grdVisitorCompanyRowClick(s,e);	
}" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="false" VisibleIndex="0"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="3%" HeaderStyle-HorizontalAlign="Center" Caption="<%$ Resources:localizedText, no2 %>" VisibleIndex="1" HeaderStyle-BackColor="#fff2c8" FieldName="CompanyNr">
                            <CellStyle HorizontalAlign="left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="17%" Caption="<%$ Resources:localizedText, companyClient %>" VisibleIndex="2" HeaderStyle-BackColor="#fff2c8" FieldName="CompanyName"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="4%" Caption="PLZ:" VisibleIndex="3" HeaderStyle-HorizontalAlign="left" HeaderStyle-BackColor="#fff2c8" FieldName="ZipCode">
                            <CellStyle HorizontalAlign="left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="8%" Caption="<%$ Resources:localizedText, place2 %>" VisibleIndex="4" HeaderStyle-BackColor="#fff2c8" FieldName="Place"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="8%" Caption="<%$ Resources:localizedText, street %>" VisibleIndex="5" HeaderStyle-BackColor="#fff2c8" FieldName="Street"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="3%" Caption="<%$ Resources:localizedText, no2 %>" VisibleIndex="6" HeaderStyle-HorizontalAlign="left" HeaderStyle-BackColor="#fff2c8" FieldName="HouseNr">
                            <CellStyle HorizontalAlign="left"></CellStyle>
                        </dx:GridViewDataTextColumn>

                    </Columns>
                    <SettingsPager Visible="False" ShowEmptyDataRows="true" PageSize="32"></SettingsPager>
                    <SettingsBehavior AllowFocusedRow="true" AllowDragDrop="false" AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" AllowSort="false" />
                    <SettingsDataSecurity AllowDelete="False" AllowInsert="False" AllowEdit="False"></SettingsDataSecurity>
                </dx:ASPxGridView>
            </section>
            <section class="SecSearcVisitorCompanyApplyBtn">
            </section>
        </div>
        <div class="Visitormandant" style="display: none;">
            <section class="Visitormandantgrid">
                <dx:ASPxGridView ID="grdClients" ClientInstanceName="grdClients" KeyFieldName="ID" ClientIDMode="Static" EnableCallBacks="true" SettingsBehavior-AllowSort="false" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" OnCustomCallback="grdClients_CustomCallback">
                    <ClientSideEvents RowClick="function(s, e) {
	grdClientsRowClick(s, e)
}"
                        RowDblClick="function(s, e) {
 grdClientsRowDBClick(s,e);
}"></ClientSideEvents>
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="false" VisibleIndex="0"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="3%" HeaderStyle-HorizontalAlign="left" Caption="<%$ Resources:localizedText, no2 %>" VisibleIndex="1" HeaderStyle-BackColor="#fff2c8" FieldName="Client_Nr">
                            <CellStyle HorizontalAlign="left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="17%" Caption="<%$ Resources:localizedText, company2 %>" VisibleIndex="2" HeaderStyle-BackColor="#fff2c8" FieldName="Name"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="4%" Caption="PLZ:" VisibleIndex="3" HeaderStyle-HorizontalAlign="left" HeaderStyle-BackColor="#fff2c8" FieldName="Plz">
                            <CellStyle HorizontalAlign="left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="8%" Caption="<%$ Resources:localizedText, place2 %>" VisibleIndex="4" HeaderStyle-BackColor="#fff2c8" FieldName="Ort"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="8%" Caption="<%$ Resources:localizedText, street %>" VisibleIndex="5" HeaderStyle-BackColor="#fff2c8" FieldName="Street"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="3%" Caption="<%$ Resources:localizedText, no2 %>" VisibleIndex="6" HeaderStyle-HorizontalAlign="left" HeaderStyle-BackColor="#fff2c8" FieldName="HouseNr">
                            <CellStyle HorizontalAlign="left"></CellStyle>
                        </dx:GridViewDataTextColumn>

                    </Columns>
                    <SettingsPager Visible="False" ShowEmptyDataRows="true" PageSize="31"></SettingsPager>
                    <SettingsBehavior AllowFocusedRow="true" AllowDragDrop="false" AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" AllowSort="false" />
                    <SettingsDataSecurity AllowDelete="False" AllowInsert="False" AllowEdit="False"></SettingsDataSecurity>
                </dx:ASPxGridView>
            </section>

        </div>
        <section class="surchpersonalinfomation" style="display: none">
            <dx:ASPxGridView ID="grdTransponders" ClientInstanceName="grdTransponders" KeyFieldName="ID" runat="server" AutoGenerateColumns="False" Width="100%"
                Theme="Office2003Blue" OnBatchUpdate="grdTransponders_BatchUpdate" OnCustomCallback="grdTransponders_CustomCallback" EnableCallBacks="true">
                <%--<ClientSideEvents RowClick="function(s, e) {
	SetGrdRowNum(s, e);
}"
                    EndCallback="function(s, e) {
	GetActiveTransponderNr();
}"
                    Init="function(s, e) {
	//GetActiveTransponderNr();
}" />--%>
                <Columns>
                    <dx:GridViewDataTextColumn VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption=" " VisibleIndex="1" Width="5%" FieldName="Card">
                        <HeaderStyle HorizontalAlign="Center" />
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, cardNo %>" VisibleIndex="2" Width="2%" FieldName="TransponderNr">
                        <PropertiesTextEdit>
                            <ClientSideEvents TextChanged="function(s, e) {
	ausweisChanged(s, e, 1);
}"></ClientSideEvents>
                        </PropertiesTextEdit>
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataCheckColumn Caption="<%$ Resources:localizedText, active_new %>" VisibleIndex="3" Width="8%" FieldName="TransponderActive">
                        <PropertiesCheckEdit ClientInstanceName="chkActive">
                            <ClientSideEvents CheckedChanged="function(s, e) {
	SetActive(s, e, true);
}" />
                        </PropertiesCheckEdit>
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, activatedOn %>" VisibleIndex="4" Width="10%" FieldName="ExtendedTo">
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, expiryDate_new %>" VisibleIndex="5" Width="10%" FieldName="ValidFrom">
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="Verlängert:" VisibleIndex="6" Width="10%" FieldName="ValidTo">
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataCheckColumn Caption="Inaktiv:" VisibleIndex="7" Width="10%" FieldName="TransponderInActive">
                        <PropertiesCheckEdit ClientInstanceName="chkInactive">
                            <ClientSideEvents CheckedChanged="function(s, e) {
	SetActive(s, e, false);
}" />
                        </PropertiesCheckEdit>
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
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsBehavior AllowDragDrop="False" AllowGroup="false" AllowSelectSingleRowOnly="true" AllowSort="False" AllowSelectByRowClick="true" />
                <SettingsPager ShowEmptyDataRows="true" Visible="False" PageSize="10"></SettingsPager>
                <SettingsEditing EditFormColumnCount="10" Mode="Batch" NewItemRowPosition="Bottom">
                    <BatchEditSettings EditMode="Row" StartEditAction="DblClick" ShowConfirmOnLosingChanges="False" />
                </SettingsEditing>
                <Settings ShowStatusBar="Hidden" />
            </dx:ASPxGridView>
            <section class="surchpersonalinfomationbtm">
                <asp:Label ID="Label78" runat="server" Text="" CssClass="lblAuswe"></asp:Label>
                <asp:Label ID="Label79" runat="server" Text="Ausweise:" CssClass="lblAuswe1new"></asp:Label>
                <asp:Label ID="Label80" runat="server" Text="" CssClass="lblAusweActive"></asp:Label>
                <asp:Label ID="Label81" runat="server" Text="" CssClass="lblAuswe1"></asp:Label>
                <asp:Label ID="Label82" runat="server" Text="" CssClass="lblAuswe3"></asp:Label>
                <asp:Label ID="Label83" runat="server" Text="" CssClass="lblAuswe3"></asp:Label>
                <asp:Label ID="Label84" runat="server" Text="" CssClass="lblAuswe3"></asp:Label>
                <asp:Label ID="Label85" runat="server" Text="Aktionen:" CssClass="lblAuswe3"></asp:Label>
                <asp:Label ID="Label86" runat="server" Text="" CssClass="lblAuswe3action"></asp:Label>
                <asp:Label ID="Label87" runat="server" Text="" CssClass="lblAuswe4"></asp:Label>
            </section>
        </section>
        <section class="Dailystatement" style="display: none; padding-top: 4%;">
            <dx:ASPxGridView ID="grdTranspondersShortTerm" ClientInstanceName="grdTranspondersShortTerm" KeyFieldName="ID" runat="server" AutoGenerateColumns="False"
                Width="100%" Theme="Office2003Blue" OnBatchUpdate="grdTranspondersShortTerm_BatchUpdate" OnCustomCallback="grdTranspondersShortTerm_CustomCallback">
                <ClientSideEvents RowClick="function(s, e) {
	SetGrdRowNum(s, e);
}"
                    EndCallback="function(s, e) {
grdShortTermEndCallBack(s,e);
	}"
                    Init="function(s, e) {
	//GetActiveSTTransponderNr()
}" />
                <Columns>
                    <dx:GridViewDataTextColumn VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption=" " VisibleIndex="1" Width="5%" FieldName="Card">
                        <HeaderStyle HorizontalAlign="left" />
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, cardNo %>" VisibleIndex="2" Width="2%" FieldName="TransponderNr">
                        <PropertiesTextEdit>
                            <ClientSideEvents TextChanged="function(s, e) {
	ausweisChanged(s, e, 2);
}"></ClientSideEvents>
                        </PropertiesTextEdit>
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataCheckColumn Caption="<%$ Resources:localizedText, active_new %>" VisibleIndex="3" Width="8%" FieldName="TransponderActive">
                        <PropertiesCheckEdit>
                            <ClientSideEvents CheckedChanged="function(s, e) {
    if (s.GetChecked()) {
	    activeCheckedChanged(s, e, 2);
    }
}"></ClientSideEvents>
                        </PropertiesCheckEdit>
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, activatedOn %>" VisibleIndex="4" Width="10%" FieldName="ValidFrom">
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, expiryDate_new %>" VisibleIndex="5" Width="10%" FieldName="ValidTo">
                        <HeaderStyle HorizontalAlign="Center" />
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

            <dx:ASPxGridView ID="ASPxGridView3" Visible="false" runat="server" AutoGenerateColumns="False"
                Width="100%" Theme="Office2003Blue">
                <Columns>
                    <dx:GridViewDataTextColumn VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Nr" VisibleIndex="1" Width="3%" FieldName="Card">
                        <HeaderStyle HorizontalAlign="Center" />
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, cardNo %>" VisibleIndex="2" Width="3%" FieldName="TransponderNr">
                        <PropertiesTextEdit>
                        </PropertiesTextEdit>
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataCheckColumn Caption="<%$ Resources:localizedText, active_new %>" VisibleIndex="3" Width="3%" FieldName="TransponderActive">
                        <PropertiesCheckEdit>
                        </PropertiesCheckEdit>
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataDateColumn Caption="Aktiviert von:" VisibleIndex="4" Width="5%" FieldName="ExtendedTo">
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="Aktiviert am:" VisibleIndex="5" Width="5%">
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="Uhrzeit:" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6" Width="4%">
                        <CellStyle HorizontalAlign="Center" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="Zutritt ab:" HeaderStyle-HorizontalAlign="Center" VisibleIndex="7" Width="4%">
                        <CellStyle HorizontalAlign="Center" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="Uhrzeit ab:" HeaderStyle-HorizontalAlign="Center" VisibleIndex="8" Width="4%">
                        <CellStyle HorizontalAlign="Center" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="Zutritt bis:" HeaderStyle-HorizontalAlign="Center" VisibleIndex="9" Width="4%">
                        <CellStyle HorizontalAlign="Center" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="Uhrzeit bis:" HeaderStyle-HorizontalAlign="Center" VisibleIndex="10" Width="4%">
                        <CellStyle HorizontalAlign="Center" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="Inaktiv" HeaderStyle-HorizontalAlign="Center" VisibleIndex="10" Width="4%">
                        <CellStyle HorizontalAlign="Center" />
                    </dx:GridViewDataDateColumn>
                </Columns>
                <SettingsBehavior AllowDragDrop="False" AllowGroup="false" AllowSelectSingleRowOnly="true" AllowSort="False" AllowSelectByRowClick="true" />
                <SettingsPager ShowEmptyDataRows="true" Visible="False" PageSize="10"></SettingsPager>
                <SettingsEditing EditFormColumnCount="10" Mode="Batch" NewItemRowPosition="Bottom">
                    <BatchEditSettings EditMode="Row" />
                </SettingsEditing>
                <Settings ShowStatusBar="Hidden" />
            </dx:ASPxGridView>

            <section class="surchpersonalinfomationbtm">
                <asp:Label ID="Label88" runat="server" Text="" CssClass="lblAusweselect"></asp:Label>
                <asp:Label ID="Label89" runat="server" Text="<%$ Resources:localizedText, idCards %>" CssClass="lblAuswe1new"></asp:Label>
                <asp:Label ID="Label90" runat="server" Text="" CssClass="lblAuswe1newselect"></asp:Label>
                <asp:Label ID="Label91" runat="server" Text="" CssClass="lblAuswe1select"></asp:Label>
                <asp:Label ID="Label92" runat="server" Text="" CssClass="lblAuswe3new"></asp:Label>
                <%--<asp:Label ID="Label69" runat="server" Text="" CssClass="lblAuswe3"></asp:Label>
                           <asp:Label ID="Label70" runat="server" Text="" CssClass="lblAuswe3"></asp:Label>
                           <asp:Label ID="Label71" runat="server" Text="Aktionen:" CssClass="lblAuswe3"></asp:Label>
                           <asp:Label ID="Label72" runat="server" Text="" CssClass="lblAuswe3action"></asp:Label>
                           <asp:Label ID="Label73" runat="server" Text="" CssClass="lblAuswe4"></asp:Label>--%>
            </section>
        </section>
        <div id="importantDialog" class="dialogBox"></div>
        <div id="saveAlert" class="saveAlertBox"></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnAcceptCompany" ClientIDMode="Static" CssClass=" btnAcceptCompany" runat="server" Text="<%$ Resources:localizedText, applyrecord %>" Style="margin-top: 14px; display: none; float: left; text-align: left;" />
    <asp:Button ID="btnApplyCompanyTo" ClientIDMode="Static" CssClass="BottomFooterBtnsRightnew btnAcceptCompany" runat="server" Text="<%$ Resources:localizedText, applyrecord %>" Style="margin-top: 14px; float: left; text-align: left; display: none;" />
    <asp:Button ID="btnApplyVisitorApplications" runat="server" CssClass="editbtnfooterorange" Text="Anmeldungen übernehmen" Style="display: none; float: left; clear: both; width: 184px; height: 15px; margin-top: 10px;" />
    <asp:Button ID="btnApplyVisitorData" runat="server" CssClass="editbtnfooterorange" Text="Besucherdaten übernehmen" Style="display: none; float: left; clear: both; width: 185px; height: 15px; margin-top: 10px;" />
    <section class="btmsecLeftMidcreatenew">
        <asp:Button ID="btnNewCompany" CssClass="BottomFooterBtnsLeftnew_vis " runat="server" Text="<%$ Resources:localizedText, newCompany %>" />
        <asp:Button ID="btnSaveCompany" ClientIDMode="Static" CssClass="BottomFooterBtnsLeftsave " runat="server" Text="<%$ Resources:localizedText, saveVisitorCompany %>" />
        <asp:Button ID="btnDeleteCompany" ClientIDMode="Static" Style="display: none;" CssClass="BottomFooterBtnsLeftdelete " runat="server" Text="<%$ Resources:localizedText, deleteButton %>" />

        <asp:Button ID="btnBackCompany" ClientIDMode="Static" CssClass="BottomFooterBtnBack " runat="server" Text="<%$ Resources:localizedText, backButton %>" Style="display: none;" />

    </section>
    <asp:Button ID="btnEntNew" runat="server" CssClass="newbtnfooterblue" Text="<%$ Resources:localizedText, newvisitor %>" Style="color: rgba(46,116,223,1.00);" OnClick="btnEntNew_Click" />

    <asp:Button ID="btnEntSave" runat="server" CssClass="savebtnfootergreen" Text="<%$ Resources:localizedText, saveVisitor %>" Style="color: forestgreen;" />

    <asp:Button ID="btnCancelDel" runat="server" CssClass="deletebtnfooterred" Text="<%$ Resources:localizedText, deleteVisitor %>" Style="color: red;" />
    <section style="display: none" class="manufacture">
        <asp:Button ID="btnNewManufacturer" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newmanufacturer %>" />
        <asp:Button ID="btnSaveManufacturer" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, savemanufacturer %>" />
        <asp:Button ID="btnDeleteManufacturer" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deletemanufacturer %>" />
    </section>
    <section class="footerextra" style="display: none">
        <asp:Button ID="btnNewModel" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newvehicletype %>" Style="width: 118px !important;" />
        <asp:Button ID="btnSaveModel" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, savevehicletype %>" Style="width: 150px !important;" />
        <asp:Button ID="btnDeleteModel" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deletevehicletype %>" Style="width: 150px !important; padding-left: 0px;" />
    </section>

    <asp:Button ID="btnSaveAusweis" runat="server" Text="<%$ Resources:localizedText, saveCard %>" CssClass="btnAuswesSave" />
    <asp:Button ID="btnDeleteAusweis" runat="server" Text="<%$ Resources:localizedText, deleteCard %>" CssClass="btnAuswesDelete" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBack_Click" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>

