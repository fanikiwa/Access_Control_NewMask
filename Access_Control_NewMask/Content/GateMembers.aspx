﻿<%@ Page Title="<%$ Resources:localizedText, memberscheck  %>" Language="C#" MasterPageFile="~/MasterPages/Gate.Master" AutoEventWireup="true" CodeBehind="GateMembers.aspx.cs" Inherits="Access_Control_NewMask.Content.GateMembers" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/GateMembers.js?v=<%= Access_Control_NewMask.Controllers.Version.JSVersion %>"></script>
    <script src="Scripts/Webcamscripts/webcam.min.js"></script>
    <script src="Scripts/TakePhoto.js"></script>
    <link href="Styles/GateMembers.css?v=<%= Access_Control_NewMask.Controllers.Version.JSVersion %>" rel="stylesheet" />
    <link href="Styles/FormViewSearch.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">
    <asp:HiddenField ID="hiddenFieldSearchValue" runat="server" />
    <asp:HiddenField ID="hiddenFieldSaveChanges" runat="server" />
    <asp:HiddenField ID="hfdHistUpdate" runat="server" />
    <div id="ControlSection1" class="ControlSection">
        <div id="AEHeaderLeftDiv">
            <div id="BottomHeaderLabels">
                <asp:Label ID="Label45" runat="server" Text="<%$ Resources:localizedText, groupNo4 %>" CssClass="L1HeaderT1drplablesmandant"></asp:Label>

                <dx:ASPxComboBox ID="cobMemberGroupNr" ClientInstanceName="cobMemberGroupNr" runat="server" ValueField="ID" TextField="GroupNumber" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                    TextFormatString="{0}" CssClass="lblMandant ColorBlue" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" EnableCallbackMode="true" OnCallback="cobMemberGroupNr_Callback" CallbackPageSize="100000">

                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobMemberGroupNrIndexChanged(s,e);	
}"
                        DropDown="function(s, e) {
	dplGroupClick(s,e);
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" Name="GroupNumber" FieldName="GroupNumber" Width="20%" />
                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, groupdescriptionnew %>" Name="GroupName" FieldName="GroupName" Width="80%" />
                    </Columns>
                </dx:ASPxComboBox>

                <asp:Label ID="Label50" runat="server" Text="<%$ Resources:localizedText, descriptionAccs %>" CssClass="L1HeaderT1drplables2"></asp:Label>

                <dx:ASPxComboBox ID="cobMemberGroupName" ClientInstanceName="cobMemberGroupName" ClientIDMode="Static" runat="server" ValueField="ID" TextField="GroupName" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                    TextFormatString="{1}" CssClass="L1HeaderT1drplists ColorBlue" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" EnableCallbackMode="true" OnCallback="cobMemberGroupName_Callback" CallbackPageSize="100000">

                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobMemberGroupNameIndexChanged(s,e);	
}"
                        DropDown="function(s, e) {
	dplGroupClick(s,e);
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" Name="GroupNumber" FieldName="GroupNumber" Width="20%" />
                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, groupdescriptionnew %>" Name="GroupName" FieldName="GroupName" Width="80%" />
                    </Columns>
                </dx:ASPxComboBox>

                <asp:Label ID="lblLocationHeader" runat="server" Text="<%$ Resources:localizedText, membersnonew %>" CssClass="L1HeaderT1drplables"></asp:Label>

                <dx:ASPxComboBox ID="cobMemberNr" ClientInstanceName="cobMemberNr" runat="server" ValueField="ID" TextField="MemberNumber" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                    TextFormatString="{0}" CssClass="lblMandant ColorBlue" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" EnableCallbackMode="true" OnCallback="cobMemberNr_Callback" CallbackPageSize="100000">

                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cobMemberNrIndexChanged(s,e);
}"
                        DropDown="function(s, e) {
	dpMemberClick(s,e);
}"
                        EndCallback="function(s, e) {
	cobMemberNrEndCallBack(s,e);
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" Name="MemberNumber" FieldName="MemberNumber" Width="20%" />
                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, membername %>" Name="FullName" FieldName="FullName" Width="80%" />
                    </Columns>
                </dx:ASPxComboBox>

                <asp:Label ID="lblDepartmentHeader" runat="server" Text="<%$ Resources:localizedText, membername %>" CssClass="L1HeaderT1drplablesnew"></asp:Label>

                <dx:ASPxComboBox ID="cobMemberName"
                    ClientInstanceName="cobMemberName"
                    runat="server"
                    ValueField="ID"
                    TextField="FullName"
                    Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                    TextFormatString="{1}"
                    CssClass="L1HeaderT1drplists ColorBlue"
                    DropDownRows="20"
                    DropDownWidth="400px"
                    Theme="Office2003Blue"
                    OnCallback="cobMemberName_Callback"
                    EnableCallbackMode="true" CallbackPageSize="100000">

                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cobMemberNameIndexChanged(s,e);
}"
                        DropDown="function(s, e) {
	dpMemberClick(s,e);	
}"
                        EndCallback="function(s, e) {
cobMemberNameEndCallBack(s,e);	
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" Name="MemberNumber" FieldName="MemberNumber" Width="20%" />
                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, membername %>" Name="FullName" FieldName="FullName" Width="80%" />
                    </Columns>
                </dx:ASPxComboBox>

            </div>

        </div>

        <div id="AEHeaderRightDiv">
            <section class="empFormViewNav">
                <section class="fvNavSearch">
                    <asp:Label ID="lblSearchAllEmp" runat="server" Text="<%$ Resources:localizedText, search %>" Style="width: 52px" />
                    <asp:Button ID="btnSearchAllMembers" runat="server" Text="" CssClass="searchAllEmp" />
                </section>
                <section class="fvNavPrevious">
                    <span></span>
                    <asp:Button ID="fvNavPrev" runat="server" Text="" CssClass="btnFvNavPrev" />
                </section>

                <section class="fvNavCurrentEmpNum">
                    <asp:Label ID="lblFvCurrentEntry" Text="<%$ Resources:localizedText, pos1 %>" runat="server" />
                    <asp:TextBox ID="txtFvCurrentEntry" runat="server" Width="96%" Enabled="false" />
                </section>

                <section class="fvNavTotalEmpNum">
                    <asp:Label ID="lblFvTotalEntries" Text="<%$ Resources:localizedText, num1 %>" runat="server" />
                    <asp:TextBox ID="txtFvTotalEntries" runat="server" Width="96%" Enabled="false" />
                </section>

                <section class="fvNavNext">
                    <span></span>
                    <asp:Button ID="fvNavNext" runat="server" Text="" CssClass="btnFvNavNext" />
                </section>

            </section>
        </div>
        <section class="fulltxtarealbl">
            <asp:Label ID="Label62" runat="server" Text="<%$ Resources:localizedText, fulltextsearch %>" CssClass="fulltxtareanew"></asp:Label>
        </section>
        <div class="textsearcharea">
            <asp:Label ID="Label74" runat="server" Text="<%$ Resources:localizedText, nameorcontractno1 %>" CssClass="fulltxtarea"></asp:Label>

            <asp:UpdatePanel ID="upPnl_MemberNameSearch" runat="server">
                <ContentTemplate>
                    <dx:ASPxComboBox ID="cboMemberNameSearch" ClientInstanceName="cboMemberNameSearch" runat="server" EnableCallbackMode="True" ValueField="ID" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="drpmemberstext ColorBlue" Theme="Office2003Blue" IncrementalFilteringMode="Contains" TextFormatString="{0} {1}" DropDownStyle="DropDown" DropDownRows="20" DropDownWidth="500px" OnItemsRequestedByFilterCondition="cboMemberNameSearch_OnItemsRequestedByFilterCondition" OnItemRequestedByValue="cboMemberNameSearch_OnItemRequestedByValue" CallbackPageSize="20">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) { cboMemberNameSearchSelectionChanged(s,e); }"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn FieldName="MemberNumber" Caption="MemberNumber" Name="MemberNumber" Width="20%" />
                            <dx:ListBoxColumn FieldName="FirstName" Caption="Name" Name="FirstName" Width="30%" />
                            <dx:ListBoxColumn FieldName="SurName" Caption="Vorname" Name="SurName" Width="30%" />
                            <dx:ListBoxColumn FieldName="AgreementNr" Caption="AgreementNr" Name="AgreementNr" Width="20%" />
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
                <asp:Button ID="btnMembers" CssClass="newstandardbutton1 BottomFooterBtnsLeftdocument btnDocumente" runat="server" Text="<%$ Resources:localizedText, members %>" Enabled="false" Style="padding-left: 13px !important; text-align: left !important; padding-top: 0; margin-top: 0;" />
                <asp:Button ID="btnMemberForm" CssClass="newstandardbutton BottomFooterBtnsLeftbogen btnbogen" runat="server" Text="<%$ Resources:localizedText, applicationForm %>" Style="padding-left: 0px !important; width: 77px; text-align: left !important; padding-top: 0; margin-top: 0;" />
                <asp:Button ID="btnMemberDocs" CssClass="newstandardbutton BottomFooterBtnsLeftdocument btnDocumente" runat="server" Text="<%$ Resources:localizedText, document %>" Style="padding-left: 13px !important; text-align: left !important; width: 102px !important; padding-top: 0; margin-top: 0;" />

            </section>
            <div id="UpperDiv">
                <div id="leftdiv">
                    <section class="topHeaderSec">
                        <section class="headerLeftSec">
                            <asp:Label ID="Label39" runat="server" Text="<%$ Resources:localizedText, studiogroup1 %>" CssClass="lblpersonal2lient fontweight600"></asp:Label>

                            <dx:ASPxComboBox ID="cobMemberGroup" ClientInstanceName="cobMemberGroup" runat="server" ValueField="ID" TextField="GroupName"
                                TextFormatString="{1}" CssClass="dplpersonalsplit2 ColorBlue" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" SelectedIndex="0">

                                <Columns>
                                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, studiogroupno %>" Name="GroupNr" FieldName="GroupNr" Width="10%" />
                                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, groupdescriptionnew %>" Name="GroupName" FieldName="GroupName" Width="90%" />
                                </Columns>
                            </dx:ASPxComboBox>
                            <asp:Button ID="btnCompany" runat="server" Enabled="true" Text="" CssClass="btnpersonalsplit ColorRed fontweight600" ClientIDMode="Static" Style="margin-top: 1px;" />
                        </section>
                        <section class="headerRightSec">
                            <section class="secSelection">
                                <asp:Label ID="Label26" runat="server" Text="<%$ Resources:localizedText, birthdate %>" CssClass="lblstandort2"></asp:Label>
                                <dx:ASPxDateEdit ID="dpDateOfBirth" ClientInstanceName="dpDateOfBirth" CssClass="txtstandort" runat="server" Theme="Office2003Blue">
                                </dx:ASPxDateEdit>

                            </section>

                        </section>
                    </section>
                    <section class="bttmSection">
                        <section class="bttmSecLeftControls">
                            <section class="secUserInput" style="display: none;">
                                <asp:Label ID="Label40" runat="server" Text="Mandant:" CssClass="lblpersonal2lientnew fontweight600"></asp:Label>
                                <asp:TextBox ID="txtCompanyName" runat="server" CssClass="txtpersonalcustomer ColorBlue"></asp:TextBox>
                            </section>
                            <section class="secUserInput">
                                <asp:Label ID="Label15" runat="server" Text="<%$ Resources:localizedText, salutation_new %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                <dx:ASPxComboBox ID="cobSalutation" ClientInstanceName="cobSalutation" runat="server" ValueField="AnredeCode" TextField="AnredeName" CssClass="dplpersonalsplit2 ColorBlue" Theme="Office2003Blue">
                                </dx:ASPxComboBox>
                            </section>
                            <section class="secUserInput">
                                <asp:Label ID="Label13" runat="server" Text="<%$ Resources:localizedText, membersno %>" CssClass="lblpersonalsplit"></asp:Label>
                                <asp:TextBox ID="txtMemberNr" ClientIDMode="Static" runat="server" Enabled="true" CssClass="txtpersonalsplit numbersOnly" Style="text-align: left !important; width: 105px;"></asp:TextBox>

                            </section>
                            <section class="secUserInput">
                                <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText ,name%>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                <asp:TextBox ID="txtSurName" ClientIDMode="Static" runat="server" CssClass="txtpersonal ColorBlue"> </asp:TextBox>
                            </section>
                            <section class="secUserInput">
                                <asp:Label ID="Label41" runat="server" Text="<%$ Resources:localizedText ,firstName1%>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                <asp:TextBox ID="txtFirstName" ClientIDMode="Static" runat="server" CssClass="txtpersonal ColorBlue"></asp:TextBox>

                            </section>
                            <section class="secUserInput" style="display: none;">
                                <asp:Label ID="Label2" runat="server" Text="<%$  Resources:localizedText ,company %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                <asp:TextBox ID="txtCompany" ClientIDMode="Static" runat="server" CssClass="txtpersonal ColorBlue"></asp:TextBox>
                            </section>
                            <section class="secUserInput">
                                <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText,street %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                <asp:TextBox ID="txtStreet" ClientIDMode="Static" runat="server" CssClass="txtpersonal ColorBlue"></asp:TextBox>
                            </section>
                            <section class="secUserInput">
                                <asp:Label ID="Label70" runat="server" Text="<%$ Resources:localizedText, housenum %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                <asp:TextBox ID="txtStreetNr" ClientIDMode="Static" runat="server" Style="text-align: left;" CssClass="txtpersonal ColorBlue"></asp:TextBox>
                            </section>
                            <section class="secUserInput">
                                <asp:Label ID="Label69" runat="server" Text="<%$ Resources:localizedText, postcode %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                <asp:TextBox ID="txtPostalCode" ClientIDMode="Static" runat="server" Style="text-align: left;" CssClass="txtpersonal ColorBlue"></asp:TextBox>
                            </section>
                            <section class="secUserInput">
                                <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, loc %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                <asp:TextBox ID="txtPhysicalAddress" ClientIDMode="Static" runat="server" CssClass="txtpersonal ColorBlue"></asp:TextBox>
                            </section>
                            <section class="secUserInput">
                                <asp:Label ID="Label56" runat="server" Text="<%$ Resources:localizedText, contractNo %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                <asp:TextBox ID="txtAgreementNr" ClientIDMode="Static" runat="server" CssClass="txtpersonal ColorBlue"></asp:TextBox>
                            </section>
                            <section class="secUserInput">
                                <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText, contractduration1 %>" CssClass="lblpersonalsplits"></asp:Label>
                                <dx:ASPxComboBox runat="server" ID="cobDuration" ClientInstanceName="cobDuration" ValueField="ID" TextField="Duration" EnableCallbackMode="true" DropDownRows="6" DropDownWidth="240px" Theme="Office2003Blue" TextFormatString="{1}" CssClass="dplpersonalsplit">

                                    <Columns>
                                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" FieldName="DurationNr" Name="DurationNr" />
                                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, contractduration1 %>" FieldName="Duration" Name="Duration" />
                                    </Columns>
                                </dx:ASPxComboBox>
                                <asp:Button ID="btnContractDuration" runat="server" Enabled="true" Text="..." CssClass="btnpersonalsplit ColorRed fontweight600" />

                            </section>
                            <section class="secUserInput">
                                <asp:Label ID="Label75" runat="server" Text="<%$ Resources:localizedText, membinactive %>" CssClass="lblpersonal2 fontweight600" Style="min-width: 190px;"> </asp:Label>
                                <asp:CheckBox ID="chkActivateMember" runat="server" CssClass="chkAccssDataarea" />
                            </section>
                        </section>
                        <section class="bttmSecRightControls">
                            <section class="secSelectionTop">

                                <section class="secSelection">
                                    <asp:Label ID="Label43" runat="server" Text="<%$ Resources:localizedText, nationality %>" CssClass="lblstandort"></asp:Label>

                                    <asp:TextBox ID="txtNationality" runat="server" CssClass="txtstandort"></asp:TextBox>
                                </section>
                                <section class="secSelection">
                                    <asp:Label ID="Label44" runat="server" Text="<%$ Resources:localizedText, job %>" CssClass="lblstandort"></asp:Label>

                                    <asp:TextBox ID="txtProfession" runat="server" CssClass="txtstandort"></asp:TextBox>
                                </section>
                                <section class="secSelection">
                                    <asp:Label ID="Label17" runat="server" Text="<%$ Resources:localizedText, telephone %>" CssClass="lblstandort"></asp:Label>

                                    <asp:TextBox ID="txtTelephone" runat="server" CssClass="txtstandort"></asp:TextBox>
                                </section>
                                <section class="secSelection">
                                    <asp:Label ID="Label18" runat="server" Text="<%$ Resources:localizedText, cellPhone %>" CssClass="lblstandort"></asp:Label>

                                    <asp:TextBox ID="txtMobileNo" runat="server" CssClass="txtstandort"></asp:TextBox>
                                </section>
                                <section class="secSelection">
                                    <asp:Label ID="Label19" runat="server" Text="<%$ Resources:localizedText, email1 %>" CssClass="lblstandort"></asp:Label>

                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="txtstandort"></asp:TextBox>
                                </section>
                            </section>
                            <section class="secMemo">
                                <section class="secMemoHeader">
                                    <asp:Label ID="Label42" runat="server" Text="<%$ Resources:localizedText ,memoTitle%>" CssClass="lblstandortheader" />
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
                            <asp:Label ID="Label32" runat="server" Text="<%$ Resources:localizedText ,document%>" CssClass="lblpersonal22" Style="display: none"></asp:Label>
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
                                <asp:TextBox ID="txtLongTermCardNr" runat="server" CssClass="txtAccsDatanew" Style="text-align: left;" Enabled="false"></asp:TextBox>
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
                                <asp:TextBox ID="txtShortTermCardNr" runat="server" CssClass="txtAccsDatanew" Style="text-align: left;" Enabled="false"></asp:TextBox>
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
                                <asp:Label ID="Label9" runat="server" Text="<%$ Resources:localizedText ,dateofentry %>" CssClass="lblAccsssData fontweight600"></asp:Label>
                            </section>
                            <section class="sec1Divns2">
                                <dx:ASPxDateEdit ID="dpEntryDate" ClientInstanceName="dpEntryDate" runat="server" CssClass="txtarea1new" Theme="Office2003Blue">
                                </dx:ASPxDateEdit>

                                <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText ,dateofexit %>" CssClass="lblarea2new fontweight600"></asp:Label>
                            </section>
                            <section class="sec1Divns3">
                                <dx:ASPxDateEdit ID="dpExitDate" ClientInstanceName="dpExitDate" runat="server" CssClass="txtarea1newright" Theme="Office2003Blue">
                                </dx:ASPxDateEdit>

                            </section>
                        </section>



                        <section class="sectitlearea">
                            <asp:Label ID="Label28" runat="server" Text="<%$ Resources:localizedText ,accessviaplan %>" CssClass="lblnewgridtitle"></asp:Label>
                        </section>
                        <section class="shadowarea">

                            <section class="sec1dr">
                                <section class="secDatePck">
                                    <asp:Label ID="Label34" runat="server" Text="<%$ Resources:localizedText ,accessAuthorizationFrom %>" CssClass="lblDate"></asp:Label>
                                </section>
                                <section class="secDatePck2">
                                    <dx:ASPxDateEdit ID="dpAccessPlanDateFrom" ClientInstanceName="dpAccessPlanDateFrom" HorizontalAlign="Center" runat="server" Theme="Office2003Blue" CssClass="dateEdit" DisplayFormatString="dd.MM.yyyy">
                                    </dx:ASPxDateEdit>
                                </section>
                                <section class="secDatePck3">
                                    <asp:Label ID="Label35" runat="server" Text="<%$ Resources:localizedText ,toAccss %>" CssClass="lblBis"></asp:Label>
                                    <dx:ASPxDateEdit ID="dpAccessPlanDateTo" ClientInstanceName="dpAccessPlanDateTo" HorizontalAlign="Center" runat="server" Theme="Office2003Blue" CssClass="dateEditNew" DisplayFormatString="dd.MM.yyyy">
                                    </dx:ASPxDateEdit>
                                </section>
                            </section>
                            <section class="sec1fd">
                                <section class="secDatePck">
                                    <asp:Label ID="Label36" runat="server" Text="<%$ Resources:localizedText ,accessPlanNr %>" CssClass="lblDate2"></asp:Label>
                                </section>
                                <section class="secDatePck2e">
                                    <asp:TextBox ID="txtAccessPlanNr" Enabled="false" runat="server" CssClass="dateEditew"></asp:TextBox>
                                </section>
                                <section class="secDatePck3e">
                                    <asp:Label ID="Label48" runat="server" Text="<%$ Resources:localizedText ,descriptionnew %>" CssClass="lblDescrp"></asp:Label>
                                    <asp:TextBox ID="txtAccessPlanName" Enabled="false" runat="server" CssClass="dateEdited"></asp:TextBox>




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
                                <asp:Label ID="Label49" runat="server" Text="<%$ Resources:localizedText ,passportPhoto %>" CssClass="BottomFooterBtnsLeftpassport" Style="margin-top: -27px;"></asp:Label>
                                <fieldset id="PhotoFieldset" class="fieldset">
                                    <asp:HiddenField ID="photVal" ClientIDMode="Static" runat="server" />
                                    <div id="Photoholder" class="PhotoholderCls">

                                        <img id="img" runat="server" src=""  />
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
                            <asp:Button ID="btnTakePhoto" runat="server" Text="<%$ Resources:localizedText, takePhoto %>" CssClass="cameraButtonsLeft " Style="width: 110px;" />

                            <asp:Button ID="btnClearPhoto" runat="server" Text="<%$ Resources:localizedText, clearPhoto %>" CssClass="cameraButtonsRight " />

                        </section>
                        <asp:Button ID="btnAccept" runat="server" Text="<%$ Resources:localizedText, takeover %>" CssClass="cameraButtonsLeft " />

                        <asp:Button ID="btnCancelPhoto" runat="server" Text="<%$ Resources:localizedText, cancel_New %>" CssClass="cameraButtonsRight " />
                    </section>

                    <div class="readergrid" style="display: none;">
                        <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName=" " KeyFieldName="ID" runat="server" AutoGenerateColumns="False" Width="100%" Theme="Office2003Blue" CssClass="readerdata">


                            <Columns>
                                <dx:GridViewDataTextColumn VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Nr.:" VisibleIndex="1" Width="30%" FieldName="Card">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Ausweis Nr.:" VisibleIndex="2" Width="70%" FieldName="TransponderNr">
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

                <section class="accessreadergrp">
                    <asp:Label ID="Label66" runat="server" Text=" <%$ Resources:localizedText ,accessviaccessgroup%>" CssClass="lblnewgridtitle2"></asp:Label>


                    <section class="accessreadgrid">
                        <dx:ASPxGridView ID="grdAccessGroups" ClientInstanceName="grdAccessGroups" runat="server" Width="100%"
                            Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="12px">
                            <Columns>
                                <dx:GridViewDataTextColumn VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText ,no2%>" VisibleIndex="1" Width="5%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000">
                                    <HeaderStyle HorizontalAlign="left" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText ,descriptionAccs%>" VisibleIndex="2" Width="20%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000">
                                    <HeaderStyle HorizontalAlign="left" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText ,activeAccss%>" VisibleIndex="3" Width="5%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000">
                                    <HeaderStyle HorizontalAlign="center" />
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText ,fromnew%>" VisibleIndex="4" Width="5%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000">
                                    <HeaderStyle HorizontalAlign="center" />
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText ,tonew%>" VisibleIndex="5" Width="5%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000">
                                    <HeaderStyle HorizontalAlign="center" />
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText ,info%>" VisibleIndex="6" Width="5%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000">
                                    <HeaderStyle HorizontalAlign="center" />
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsPager ShowEmptyDataRows="true" Visible="False" PageSize="6"></SettingsPager>
                        </dx:ASPxGridView>
                    </section>
                </section>





                <asp:Label ID="Label5" runat="server" Text="<%$ Resources:localizedText ,attendancehours1 %>" CssClass="lblnewbottomtitle"></asp:Label>
                <section style="width: 250px; height: 33px; float: left; clear: none; margin-left: 27.5%; margin-right: auto;">

                    <asp:Label ID="Label27" runat="server" Text="<%$ Resources:localizedText ,year1 %>" CssClass="lblyear"></asp:Label>
                    <section class="sec2">
                        <section class="griddatemover">
                            <section class="griddatemoverleft">
                                <asp:Button ID="btnCalendarYearPrevious" runat="server" Text="" CssClass="korbtnFvNavPrevNr" />
                            </section>
                            <section class="griddatemovercenter">
                                <dx:ASPxComboBox runat="server" ID="ddlYear" ClientIDMode="Static" ClientInstanceName="ddlCalendarYear2Old" Theme="Aqua" ValueType="System.String" AutoPostBack="true" CssClass="ddlYearStyle2" Style="min-width: 100%; color: dodgerblue;" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" HorizontalAlign="Center"></dx:ASPxComboBox>

                            </section>
                            <section class="btnNext">
                                <asp:Button ID="btnCalendarYearNext" runat="server" Text="" CssClass="korbtnFvNavNexNrt" />
                            </section>
                        </section>
                    </section>

                </section>
                <section class="tableSec">
                    <asp:Table runat="server" CellPadding="0" ID="accountOverviewTable" CellSpacing="0" CssClass="mainTable">
                        <asp:TableRow CssClass="tblRow">
                            <asp:TableCell CssClass="tblCellColmnOne">
                                <asp:Label ID="Label21" runat="server" Text="<%$ Resources:localizedText ,months%>" CssClass="lblTableHeader"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tblCell">
                                <asp:Label ID="Label29" runat="server" Text="<%$ Resources:localizedText ,jan%>" CssClass="lblTopHeaderBlue"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tblCell">
                                <asp:Label ID="Label30" runat="server" Text="<%$ Resources:localizedText ,feb%>" CssClass="lblTopHeaderBlue"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tblCell">
                                <asp:Label ID="Label31" runat="server" Text="<%$ Resources:localizedText ,mar%>" CssClass="lblTopHeaderBlue"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tblCell">
                                <asp:Label ID="Label11" runat="server" Text="<%$ Resources:localizedText ,apr%>" CssClass="lblTopHeaderBlue"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tblCell">
                                <asp:Label ID="Label12" runat="server" Text="<%$ Resources:localizedText ,may%>" CssClass="lblTopHeaderBlue"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tblCell">
                                <asp:Label ID="Label14" runat="server" Text="<%$ Resources:localizedText ,jun%>" CssClass="lblTopHeaderBlue"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tblCell">
                                <asp:Label ID="Label16" runat="server" Text="<%$ Resources:localizedText ,jul%>" CssClass="lblTopHeaderBlue"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tblCell">
                                <asp:Label ID="Label20" runat="server" Text="<%$ Resources:localizedText ,aug%>" CssClass="lblTopHeaderBlue"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tblCell">
                                <asp:Label ID="Label22" runat="server" Text="<%$ Resources:localizedText ,sep%>" CssClass="lblTopHeaderBlue"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tblCell">
                                <asp:Label ID="Label38" runat="server" Text="<%$ Resources:localizedText ,oct%>" CssClass="lblTopHeaderBlue"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tblCell">
                                <asp:Label ID="Label23" runat="server" Text="<%$ Resources:localizedText ,nov%>" CssClass="lblTopHeaderBlue"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tblCell">
                                <asp:Label ID="Label24" runat="server" Text="<%$ Resources:localizedText ,dec%>" CssClass="lblTopHeaderBlue"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tblCell">
                                <asp:Label ID="Label25" runat="server" Text="<%$ Resources:localizedText ,total%>" CssClass="lblTopHeaderBlue"></asp:Label>
                            </asp:TableCell>



                        </asp:TableRow>

                        <asp:TableRow CssClass="tblRow">
                            <asp:TableCell CssClass="tblCellColmnOne">
                                <asp:Label ID="Label79" runat="server" Text="<%$ Resources:localizedText ,presenthours%>" CssClass="lblTableHeader"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell ID="JanuaryTTCell" ClientIDMode="Static" runat="server" CssClass="tblCell"></asp:TableCell>
                            <asp:TableCell ID="FebruaryTTCell" ClientIDMode="Static" runat="server" CssClass="tblCell"></asp:TableCell>
                            <asp:TableCell ID="MarchTTCell" ClientIDMode="Static" runat="server" CssClass="tblCell"></asp:TableCell>
                            <asp:TableCell ID="AprilTTCell" ClientIDMode="Static" runat="server" CssClass="tblCell"></asp:TableCell>
                            <asp:TableCell ID="MayTTCell" ClientIDMode="Static" runat="server" CssClass="tblCell"></asp:TableCell>
                            <asp:TableCell ID="JuneTTCell" ClientIDMode="Static" runat="server" CssClass="tblCell"></asp:TableCell>
                            <asp:TableCell ID="JulyTTCell" ClientIDMode="Static" runat="server" CssClass="tblCell"></asp:TableCell>
                            <asp:TableCell ID="AugustTTCell" ClientIDMode="Static" runat="server" CssClass="tblCell"></asp:TableCell>
                            <asp:TableCell ID="SeptemberTTCell" ClientIDMode="Static" runat="server" CssClass="tblCell"></asp:TableCell>
                            <asp:TableCell ID="OctoberTTCell" ClientIDMode="Static" runat="server" CssClass="tblCell"></asp:TableCell>
                            <asp:TableCell ID="NovemberTTCell" ClientIDMode="Static" runat="server" CssClass="tblCell"></asp:TableCell>
                            <asp:TableCell ID="DecemberTTCell" ClientIDMode="Static" runat="server" CssClass="tblCell"></asp:TableCell>
                            <asp:TableCell ID="AnualBalanceTTCell" ClientIDMode="Static" runat="server" CssClass="tblCell"></asp:TableCell>
                        </asp:TableRow>

                    </asp:Table>
                </section>
            </div>
            <section class="surchpersonalinfomation" style="display: none">
                <dx:ASPxGridView ID="grdTransponders" ClientInstanceName="grdTransponders" KeyFieldName="ID" runat="server" OnCustomCallback="grdTransponders_CustomCallback"
                    AutoGenerateColumns="False" Width="100%" Theme="Office2003Blue" OnBatchUpdate="grdTransponders_BatchUpdate"
                    Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="12px">

                    <ClientSideEvents RowClick="function(s, e) {
SetGrdRowNum(s, e);
}"
                        EndCallback="function(s, e) {
grdLongTermEndCallBack(s,e);	
}"
                        Init="function(s, e) {
GetActiveTransponderNr();
}"
                        FocusedRowChanged="function(s, e) {
SetGrdRowNum(s, e);	
}"></ClientSideEvents>

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
                        <asp:Label ID="lblCardCount" runat="server" Text="" CssClass="" Style="text-align: center; display: block;"></asp:Label>
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
                        <asp:Label ID="lblActionCount" runat="server" Text="" CssClass=""></asp:Label>
                    </section>
                    <section class="lblAuswe4">
                        <asp:Label ID="Label63" runat="server" Text="" CssClass=""></asp:Label>
                    </section>
                </section>
            </section>
            <section class="Dailystatement" style="display: none">
                <dx:ASPxGridView ID="grdTranspondersShortTerm" ClientInstanceName="grdTranspondersShortTerm" KeyFieldName="ID" runat="server" AutoGenerateColumns="False" OnCustomCallback="grdTranspondersShortTerm_CustomCallback"
                    Width="100%" Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="12px" OnBatchUpdate="grdTranspondersShortTerm_BatchUpdate">
                    <ClientSideEvents RowClick="function(s, e) {
SetGrdRowNum(s, e);	
}"
                        EndCallback="function(s, e) {
grdTransShortTermEndCallBack(s,e);	
}"
                        Init="function(s, e) {
GetActiveSTTransponderNr();	
}"
                        FocusedRowChanged="function(s, e) {
SetGrdRowNum(s, e);	
}"></ClientSideEvents>
                    <Columns>
                        <dx:GridViewDataTextColumn VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption=" " VisibleIndex="1" Width="5%" FieldName="Card">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText ,Transpondernumber%>" VisibleIndex="2" Width="2%" FieldName="TransponderNr">
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
                    <asp:Label ID="lblAusweisCount" runat="server" Text="" CssClass="lblAuswe1newselect"></asp:Label>
                    <asp:Label ID="Label67" runat="server" Text="" CssClass="lblAuswe1select"></asp:Label>
                    <asp:Label ID="Label68" runat="server" Text="" CssClass="lblAuswe3new"></asp:Label>
                </section>
            </section>
        </div>
        <div id="rightdiv2">
            <div class="Wrappernew">
                <div id="Grid" class="Grid">
                    <dx:ASPxGridView ID="ASPxGridView3" runat="server" CellPadding="4" ForeColor="#333333" Width="100%" GridLines="Both" Theme="Office2003Blue"
                        AutoGenerateColumns="False" KeyFieldName="ID" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="14px">

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

                            </dx:ASPxColorEdit>
                            <asp:TextBox ID="txtPersTypeId" runat="server" CssClass="txtpmemo" Style="display: none" EnableCustomColors="True"></asp:TextBox>
                        </section>
                    </section>
                </div>

                <section class="ActionBtnsBottom">
                    <asp:Button ID="btnNewPersType" CssClass="GridFooterBtnsLeft btnNew" runat="server" Text="<%$ Resources:localizedText, newButton %>" />
                    <asp:Button ID="btnEditPersType" CssClass="GridFooterBtnsLeft btnEdit" runat="server" Text="<%$ Resources:localizedText, editing %>" Style="display: none" />
                    <asp:Button ID="btnSavePersType" CssClass="GridFooterBtnsLeft btnSave" runat="server" Text="<%$ Resources:localizedText, saveButton %>" />
                    <asp:Button ID="btnDeletePersType" CssClass="GridFooterBtnsLeft btnLöschen" runat="server" Text="<%$ Resources:localizedText, deleteButton %>" />
                    <asp:Button ID="btnPersTypeBack" CssClass="BottomFooterBtnsRight btnClose" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
                </section>
            </div>
        </div>
        <div id="rightdiv3">
            <div class="Wrappernew3">
                <div id="GridIdNr" class="gridIdNr">
                    <dx:ASPxGridView ID="grdVehicleTypes" KeyFieldName="ID" EnableCallBacks="false" runat="server" CellPadding="4" ForeColor="#333333" Width="100%" GridLines="Both" Theme="Office2003Blue" AutoGenerateColumns="False" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="14px">
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
                    <dx:ASPxGridView ID="ASPxGridView4" runat="server" CellPadding="4" ClientInstanceName="grdClients" KeyFieldName="ID" ClientIDMode="Static" ForeColor="#333333" Width="100%" GridLines="Both" Theme="Office2003Blue" AutoGenerateColumns="False" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="14px">

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
                        <SettingsPager PageSize="11" ShowEmptyDataRows="True" Visible="False">
                        </SettingsPager>
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                    </dx:ASPxGridView>
                </div>

                <div id="Grid4" class="Grid4">
                    <section style="display: none">
                        <dx:ASPxComboBox ID="DropDownList2" runat="server" Visible="true" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ValueType="System.String">
                        </dx:ASPxComboBox>
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

                <section class="ActionBtnsBottom" style="display: none;">
                    <asp:Button ID="btnNewClient" CssClass="GridFooterBtnsLeft btnNew" runat="server" Text="<%$ Resources:localizedText, newButton %>" />
                    <asp:Button ID="btnSaveClient" CssClass="GridFooterBtnsLeft btnSave" runat="server" Text="<%$ Resources:localizedText, saveButton %>" />
                    <asp:Button ID="btnDeleteClient" CssClass="GridFooterBtnsLeft btnLöschen" runat="server" Text="<%$ Resources:localizedText, deleteButton %>" />
                    <asp:Button ID="btnCompanyBack" CssClass="BottomFooterBtnsRight btnClose" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
                </section>
            </div>
        </div>
        <div id="gridSearch" class="searchContact" style="display: none;">
            <section class="resizegridarea">
                <dx:ASPxGridView ID="grdAccessPlan" runat="server" AutoGenerateColumns="False" Theme="Office2003Blue" Width="100%" ClientInstanceName="grdAccessPlan" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important"
                    Font-Size="12px" KeyFieldName="ID">

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
                    <SettingsPager PageSize="31" ShowEmptyDataRows="True">
                    </SettingsPager>
                </dx:ASPxGridView>
            </section>
            <section class="SecApplyAccesslan">
                <asp:Button ID="btnApplyAccessPlan" runat="server" Text="<%$ Resources:localizedText, takeover %>" CssClass="ubernahme" Style="margin-top: 10px !important;" />
            </section>
        </div>
        <div id="searchPersData" class="searchPersonnelData" style="display: none;">
            <dx:ASPxGridView ID="ASPxGridView6" SettingsBehavior-AllowSort="false" ClientInstanceName="grdPersData" runat="server" Width="100%" KeyFieldName="Pers_Nr" AutoGenerateColumns="False" Theme="Office2003Blue" EnableTheming="True">

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



        <div id="searchgrid" class="search2" style="display: none;">
            <section class="btnGrdSearchPersonal">
                <dx:ASPxGridView ID="grdSearchMember" ClientInstanceName="grdSearchMember" EnableCallBacks="true" OnCustomCallback="grdSearchMember_CustomCallback" runat="server" AutoGenerateColumns="False" Theme="Office2003Blue" Width="100%" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important"
                    Font-Size="12px" KeyFieldName="ID">
                    <ClientSideEvents RowDblClick="function(s, e) {
grdSearchMemberRowDbClick(s,e);	
}"></ClientSideEvents>

                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Studio-Gruppen Nr.:" VisibleIndex="1" FieldName="GroupNumber">
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Gruppen Bezeichnung:" VisibleIndex="2" FieldName="GroupName">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Mitglieds Nr.:" VisibleIndex="3" FieldName="MemberNumber">
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Mitgliedsname:" VisibleIndex="4" FieldName="FullName">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="false" AllowDragDrop="false"></SettingsBehavior>
                    <SettingsPager PageSize="32" ShowEmptyDataRows="True">
                    </SettingsPager>
                </dx:ASPxGridView>
            </section>
            <section class="btnApplySec">
                <asp:Button ID="btnApplyMember" runat="server" Text="Übernehmen" CssClass="ubernahme" />
            </section>
        </div>
        <div id="importantDialog" class="dialogBox">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnNew" CssClass="newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newMember %>" Style="width: 100px;" />
    <asp:Button ID="btnSave" CssClass="savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, saveMember%>" Style="width: 124px; padding-left: 2px;" />
    <asp:Button ID="btnDelete" CssClass="deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deleteMember%>" Style="width: 120px;" />

    <asp:Button ID="btnNewAusweis" runat="server" Text="<%$ Resources:localizedText, newCard %>" CssClass="btnAuswesNew" />
    <asp:Button ID="btnSaveAusweis" runat="server" Text="<%$ Resources:localizedText, saveCard %>" CssClass="btnAuswesSave" />
    <asp:Button ID="btnDeleteAusweis" runat="server" Text="<%$ Resources:localizedText, deleteCard %>" CssClass="btnAuswesDelete" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBack_Click" />
    <asp:Button ID="btnHelp" ClientIDMode="Static" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
