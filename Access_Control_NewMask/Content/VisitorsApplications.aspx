<%@ Page Title="<%$ Resources:localizedText, visitorregistration %>" Language="C#" MasterPageFile="~/MasterPages/Primary.Master" AutoEventWireup="true" CodeBehind="VisitorsApplications.aspx.cs" Inherits="Access_Control_NewMask.Content.VisitorsApplications" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/VisitorsApplications.css" rel="stylesheet" />
    <script src="Scripts/VisitorsApplications.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="ContentAreaDiv">
        <div id="ControlSection1" class="TopContentAreaDiv">
            <div id="AEHeaderLeftDiv">
                <div class="BottomHeaderLabels">
                    <asp:Label ID="lblCostCenterHeader" runat="server" Text="<%$ Resources:localizedText, company %>" CssClass="L1HeaderT1drplables"></asp:Label>
                    <asp:Label ID="lblApplicants" runat="server" Text="<%$ Resources:localizedText, applications2 %>" CssClass="L1HeaderT1drplables"></asp:Label>
                    <asp:Label ID="lblDepartmentHeader" runat="server" Text="<%$ Resources:localizedText, department %>" CssClass="L1HeaderT1drplables"></asp:Label>
                    <asp:Label ID="lblNotifyingId" runat="server" Text="<%$ Resources:localizedText, notifyingId %>" CssClass="L1HeaderT1drplablesid"></asp:Label>
                    <asp:Label ID="lblDate" runat="server" Text="<%$ Resources:localizedText, date %>" CssClass="L1HeaderT1drplables" Style="display: none"></asp:Label>
                    <!--<asp:Label ID="lblZipCode" runat="server" Text="<%$ Resources:localizedText, zipCode %>" CssClass="L1HeaderT1drplablesnew"></asp:Label>
                <asp:Label ID="lblZipLocation" runat="server" Text="<%$ Resources:localizedText, zipLocation %>" CssClass="L1HeaderT1drplablesnew2"></asp:Label>-->
                    <asp:Label ID="lblVisitorsName" runat="server" Text="<%$ Resources:localizedText, visitorname %>" CssClass="L1HeaderT1drplableslong"></asp:Label>
                </div>

                <div class="BottomHeaderLists">
                    <dx:ASPxComboBox ID="ddlVisitorCompany" ClientInstanceName="ddlVisitorCompany" ValueField="ID" TextField="Name" runat="server" Theme="Office2003Blue" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" DataTextField="Name" ValueType="System.String" HorizontalAlign="Left" DropDownRows="20"  CallbackPageSize="100000">
                    </dx:ASPxComboBox>

                    <dx:ASPxComboBox ID="ddlPersonalName" ClientInstanceName="ddlPersonalName" ValueField="ID" TextField="FullName" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" DataTextField="FullName"  HorizontalAlign="Left" DropDownRows="20"  CallbackPageSize="100000">
                    </dx:ASPxComboBox>

                    <dx:ASPxComboBox ID="ddlPersonalDepartment" ClientInstanceName="ddlPersonalDepartment" ValueField="ID" TextField="Name" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" DataTextField="StartDate" Style="display: none"  HorizontalAlign="Left" DropDownRows="20"  CallbackPageSize="100000">
                    </dx:ASPxComboBox>

                    <dx:ASPxComboBox ID="ddlApplicationID" ClientInstanceName="ddlApplicationID" runat="server" ValueField="ID" TextField="VisitorID" Theme="Office2003Blue" ValueType="System.String" DataTextField="VisitorID" CssClass="L1HeaderT1drplistsid" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" HorizontalAlign="Left" DropDownRows="20"  CallbackPageSize="100000">
                    </dx:ASPxComboBox>

                    <dx:ASPxComboBox ID="ddlVisitorName" ClientInstanceName="ddlVisitorName" runat="server" ValueField="ID" TextField="VisitorName" Theme="Office2003Blue" ValueType="System.String" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" DataTextField="VisitorName"  HorizontalAlign="Left" DropDownRows="20"  CallbackPageSize="100000">
                    </dx:ASPxComboBox>

                </div>

            </div>

            <div id="AEHeaderRightDiv">

                <section class="empFormViewNav">
                    <section class="fvNavSearch">
                        <asp:Label ID="lblSearchAllEmp" runat="server" Text="<%$ Resources:localizedText, search %>" />
                        <asp:Button ID="btnSearchVisitors" runat="server" Text="" CssClass="searchAllEmp" />
                    </section>

                    <section class="fvNavPrevious">
                        <span></span>
                        <asp:Button ID="fvNavPrev" runat="server" Text="" CssClass="btnFvNavPrev" />
                        <%--OnClick="fvNavPrev_Click" --%>
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
                        <%--OnClick="fvNavNext_Click"--%>
                    </section>

                </section>

            </div>

        </div>

        <div id="MainContdiv">

            <%--<div ID="fvVisitors"  CssClass="fvVisitors" >--%>
            <div id="Visitors" class="fvVisitors">

                <section class="wrappernew">
                    <section class="secwrapperleft">
                        <section class="secHeader">
                            <asp:Label ID="Label28" runat="server" Text="<%$ Resources:localizedText, visitorLogin %>" CssClass="lbltop" Style="display: none"></asp:Label>
                            <asp:Label ID="Label34" runat="server" Text="<%$ Resources:localizedText, signedIn %>" CssClass="lbltopnew fontweight600 ColorRed"></asp:Label>
                        </section>
                        <section class="secLeft">

                            <section class="secLeft">
                                <section class="seclefttop">
                                    <section class="visName">

                                        <asp:Label ID="Label31" runat="server" Text="Name:" CssClass="lblNme"></asp:Label>
                                        <asp:TextBox ID="txtPersName" runat="server" CssClass="txtName" Enabled="false"></asp:TextBox>

                                    </section>
                                    <section class="visNr">
                                        <asp:Label ID="Label33" runat="server" Text="<%$ Resources:localizedText, employeeNr %>" CssClass="lblPersNr"></asp:Label>
                                        <asp:TextBox ID="txtPersNr" runat="server" CssClass="txtPersNr" Enabled="false"></asp:TextBox>
                                        <asp:Label ID="Label35" runat="server" Text="<%$ Resources:localizedText, departments %>" CssClass="lbltopnew" Style="display: none"></asp:Label>
                                        <asp:TextBox ID="txtDepartment" runat="server" CssClass="txtsize4dept" ReadOnly="true" Style="display: none"></asp:TextBox>
                                    </section>
                                </section>
                                <section class="divlabelstop" style="display: none">
                                    <asp:Label ID="Label24" runat="server" Text="<%$ Resources:localizedText, notifyingId %>" CssClass="lbltop fontweight600 ColorRed"></asp:Label>
                                    <asp:Label ID="Label25" runat="server" Text="Angemeldet von:" CssClass="lbltop fontweight600 ColorRed"></asp:Label>
                                    <asp:Label ID="Label27" runat="server" Text="<%$ Resources:localizedText, departments %>" CssClass="lbltop fontweight600"></asp:Label>
                                </section>
                                <section class="tabsec2top" style="display: none">
                                    <section class="tabsec2top1new">
                                        <section class="tabsec2top1left">
                                            <section>
                                                <asp:TextBox ID="txtVisitInstanceID" runat="server" CssClass="txtsize3"></asp:TextBox>
                                            </section>
                                            <section>
                                                <asp:TextBox ID="txtPersVisited" runat="server" CssClass="txtsize2" ReadOnly="true"></asp:TextBox>
                                                <%-- <asp:HiddenField ID="txtPersonalID" runat="server" Value='<%# Bind("PersonalID") %>' />--%>
                                                <asp:Button ID="btnSearchPersonnal" runat="server" Text="" CssClass="btnprgsedit" Enabled="true" />
                                            </section>
                                        </section>
                                        <section class="tabsec2top1right">
                                            <section class="tabsec2top1righttop">
                                                <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, phone %>" CssClass="lblShotr fontweight600"></asp:Label>
                                                <asp:TextBox ID="txtPersonnelPhone" runat="server" CssClass="txtsize2new" ReadOnly="true"></asp:TextBox>
                                            </section>
                                            <section class="tabsec2top1rightbttm">
                                                <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, cellPhone %>" CssClass="lblShotr fontweight600"></asp:Label>
                                                <asp:TextBox ID="txtPersonnelCellPhone" runat="server" CssClass="txtsize2new" ReadOnly="true"></asp:TextBox>
                                            </section>
                                        </section>
                                    </section>
                                    <section class="tabsec2top1">
                                    </section>
                                </section>

                                <section class="visData">
                                    <asp:Label ID="Label32" runat="server" Text="<%$ Resources:localizedText, visitorData_new %>" CssClass="lblVisitorData"></asp:Label>
                                </section>
                                <section class="secleftbttm" style="height: 67%;">
                                    <section class="divlabelsbttm">
                                        <%--<asp:Label ID="Label20" runat="server" Text="<%$ Resources:localizedText, expectedEntry %>" CssClass="lblbttm fontweight600"></asp:Label>--%>
                                        <asp:Label ID="Label9" runat="server" Text="<%$ Resources:localizedText, visitorID %>" CssClass="lblbttmnew fontweight600"></asp:Label>
                                        <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText, firstname_new %>" CssClass="lblbttm fontweight600"></asp:Label>
                                        <asp:Label ID="Label36" runat="server" Text="<%$ Resources:localizedText, surname %>" CssClass="lblbttm fontweight600"></asp:Label>
                                        <asp:Label ID="Label11" runat="server" Text="<%$ Resources:localizedText, company %>" CssClass="lblbttmnnn fontweight600"></asp:Label>
                                        <asp:Label ID="Label12" runat="server" Text="<%$ Resources:localizedText, street %>" CssClass="lblbttm fontweight600"></asp:Label>
                                        <asp:Label ID="Label26" runat="server" Text="Nr.:" CssClass="lblbttm fontweight600"></asp:Label>
                                        <asp:Label ID="Label13" runat="server" Text="<%$ Resources:localizedText, loc %>" CssClass="lblbttm fontweight600"></asp:Label>
                                        <asp:Label ID="Label30" runat="server" Text="PLZ:" CssClass="lblbttm fontweight600" Style="display: none"></asp:Label>
                                        <asp:Label ID="Label14" runat="server" Text="<%$ Resources:localizedText, telephone %>" CssClass="lblbttm2 fontweight600"></asp:Label>
                                        <asp:Label ID="Label15" runat="server" Text="<%$ Resources:localizedText, mobile %>" CssClass="lblbttm2 fontweight600"></asp:Label>
                                        <asp:Label ID="Label17" runat="server" Text="<%$ Resources:localizedText, email1 %>" CssClass="lblbttm2 fontweight600"></asp:Label>
                                        <asp:Label ID="Label18" runat="server" Text="<%$ Resources:localizedText, indicator %>" CssClass="lblbttm2new fontweight600"></asp:Label>
                                        <asp:Label ID="Label19" runat="server" Text="<%$ Resources:localizedText, vehicleType %>" CssClass="lblbttm2 fontweight600"></asp:Label>
                                    </section>
                                    <section class="tabsec2bttm">
                                        <%--<asp:TextBox ID="TextBox25" runat="server" CssClass="txtsize4 ColorRed"></asp:TextBox>--%>
                                        <asp:ImageButton ID="ImageButton2" runat="server" CssClass="buttonbes" Style="display: none;" />
                                        <asp:TextBox ID="txtVisitorID" runat="server" CssClass="txtsize4id ColorBlue" Enabled="false"></asp:TextBox>
                                        <asp:TextBox ID="txtOtherNames" runat="server" CssClass="txtsize4 ColorBlue"></asp:TextBox>

                                        <asp:TextBox ID="txtSurName" runat="server" CssClass="txtsize4 ColorBlue"></asp:TextBox>
                                        <%--     <asp:TextBox ID="txtStreet1" runat="server" CssClass="txtsize4 ColorBlue" ></asp:TextBox>--%>
                                        <dx:ASPxComboBox ID="cobCompany" runat="server" ValueField="ID" TextField="Client_Nr" HorizontalAlign="Left"
                                            TextFormatString="{0}" CssClass="txtpersonalnrnew" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">

                                            <Columns>
                                                <%--<dx:ListBoxColumn FieldName="Client_Nr" Caption="Firma Nr." Name="ProfileDescription" ToolTip="" Width="18%" />--%>
                                                <dx:ListBoxColumn FieldName="Name" Name="ID" Caption="Firma" ToolTip="Firma" Width="42%" />
                                            </Columns>
                                        </dx:ASPxComboBox>
                                        <asp:Button ID="btnClint" runat="server" Text="" CssClass="btnpersonalsplitserch fontweight600" />
                                        <asp:TextBox ID="txtStreet" runat="server" CssClass="txtsize4 ColorBlue"></asp:TextBox>
                                        <asp:TextBox ID="txtSteetNr" runat="server" CssClass="txtsize4 ColorBlue"></asp:TextBox>
                                        <asp:TextBox ID="txtLocation" runat="server" CssClass="txtsize4 ColorBlue"></asp:TextBox>
                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="txtsize4new ColorBlue" Style="display: none"></asp:TextBox>
                                        <asp:TextBox ID="txtTelephone" runat="server" CssClass="txtsize4 ColorBlue"></asp:TextBox>
                                        <asp:TextBox ID="txtMobile" runat="server" CssClass="txtsize4"></asp:TextBox>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="txtsize4"></asp:TextBox>
                                        <asp:TextBox ID="txtVehicleModel" runat="server" ReadOnly="true" CssClass="txtsize4" ClientIDMode="Static"></asp:TextBox>
                                        <asp:TextBox ID="txtRegNo" runat="server" CssClass="txtsize5"></asp:TextBox>
                                        <asp:Button ID="btnCarType" runat="server" Text="" CssClass="btnpersonalsplitserch fontweight600" />
                                    </section>
                                </section>
                                <section class="secleftmid" style="height: 19%;">
                                    <section class="divlabelsmid">
                                        <asp:Label ID="Label21" runat="server" Text="<%$ Resources:localizedText, filedOn %>" CssClass="lblmidneeew fontweight600 ColorRed"></asp:Label>
                                        <asp:Label ID="Label22" runat="server" Text="Besuchsbeginn:" CssClass="lblmid fontweight600"></asp:Label>
                                        <asp:Label ID="Label23" runat="server" Text="Besuchsendes:" CssClass="lblmid fontweight600"></asp:Label>
                                    </section>
                                    <section class="tabsec2mid">
                                        <section class="tabsec2midleft">
                                            <section style="float: left; width: 49%;">
                                                <section class="secmiddiv1">
                                                    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, date %>" CssClass="lblShotr fontweight600 ColorRed"></asp:Label>
                                                    <%--<asp:TextBox ID="TextBox8" runat="server" CssClass="txtsize1"></asp:TextBox>--%>
                                                    <dx:ASPxDateEdit ID="dtpDateReg" runat="server" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="txtsize1" ReadOnly="false" Date='<%# Bind("DateFiled") %>' Theme="Office2003Blue"></dx:ASPxDateEdit>
                                                </section>
                                                <section class="secmiddiv2">
                                                    <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, date %>" CssClass="lblShotr fontweight600"></asp:Label>
                                                    <%--<asp:TextBox ID="TextBox9" runat="server" CssClass="txtsize1"></asp:TextBox>--%>
                                                    <dx:ASPxDateEdit ID="dtpStartDate" runat="server" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="txtsize1" ReadOnly="false" Date='<%# Bind("EntryDate") %>' Theme="Office2003Blue"></dx:ASPxDateEdit>
                                                </section>
                                                <section class="secmiddiv3">
                                                    <asp:Label ID="Label5" runat="server" Text="<%$ Resources:localizedText, date %>" CssClass="lblShotr fontweight600"></asp:Label>
                                                    <%-- <asp:TextBox ID="TextBox10" runat="server" CssClass="txtsize1"></asp:TextBox>--%>
                                                    <dx:ASPxDateEdit ID="dtpEndDate" runat="server" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="txtsize1" ReadOnly="false" Date='<%# Bind("ExitDate") %>' Theme="Office2003Blue"></dx:ASPxDateEdit>
                                                </section>
                                            </section>
                                            <section style="float: right; width: 49%; height: 97%;">
                                                <section class="secmiddiv1">
                                                    <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText, time1 %>" CssClass="lblShotr ColorRed"></asp:Label>
                                                    <dx:ASPxTimeEdit ID="dtpRegDateTime" runat="server" CssClass="txtsize1new" DateTime='<%# Bind("TimeFiled") %>'>
                                                        <SpinButtons Enabled="false" ShowIncrementButtons="false"></SpinButtons>
                                                    </dx:ASPxTimeEdit>
                                                </section>
                                                <section class="secmiddiv2">
                                                    <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText, time1 %>" CssClass="lblShotr"></asp:Label>
                                                    <dx:ASPxTimeEdit ID="dtpStartDateTime" runat="server" CssClass="txtsize1new" DateTime='<%# Bind("EntryTime") %>'>
                                                        <SpinButtons Enabled="false" ShowIncrementButtons="false"></SpinButtons>
                                                    </dx:ASPxTimeEdit>
                                                </section>
                                                <section class="secmiddiv3">
                                                    <asp:Label ID="Label8" runat="server" Text="<%$ Resources:localizedText, time1 %>" CssClass="lblShotr"></asp:Label>
                                                    <dx:ASPxTimeEdit ID="dtpEndDateTime" runat="server" CssClass="txtsize1new" DateTime='<%# Bind("ExitTime") %>'>
                                                        <SpinButtons Enabled="false" ShowIncrementButtons="false"></SpinButtons>
                                                    </dx:ASPxTimeEdit>
                                                </section>
                                            </section>

                                        </section>
                                    </section>
                                </section>
                            </section>

                        </section>
                    </section>
                    <section class="secwrapperright">
                        <section class="secHeader" style="display: none">
                            <asp:Label ID="Label20" runat="server" Text="<%$ Resources:localizedText, passportPhoto %>" CssClass="lblDateFrom2"></asp:Label>
                        </section>
                        <section class="secRight">
                            <section class="tabsec3bttmnew">
                                <section class="lblmemholder">
                                    <asp:Label ID="Label37" runat="server" Text="Grund des Besuches" CssClass="memHeader"></asp:Label>
                                </section>
                                <section class="memosec">
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="txt" TextMode="MultiLine"></asp:TextBox>
                                </section>

                            </section>
                            <section class="tabsec3" style="display: none">
                                <section class="tabsec3top" style="display: none">
                                    <section class="photo" style="height: 90%;">
                                        <fieldset id="PhotoFieldset1" style="width: 80%; height: 90%; margin-left: auto; margin-right: auto; border: 1px solid black; display: none">
                                            <legend style="display: none">
                                                <asp:Label ID="Label16" runat="server" Text="<%$ Resources:localizedText, photo %>" CssClass="PhotoholderCls"></asp:Label></legend>
                                            <div id="Photoholder2" class="PhotoholderCls">
                                            </div>
                                        </fieldset>
                                        <section class="photoFieldSet">
                                        </section>
                                    </section>

                                    <section class="PhotoBtnsHolder" style="display: none">
                                        <asp:Button ID="btnUploadPic" runat="server" Text="<%$ Resources:localizedText, insertPicture %>" CssClass="PhotoholderButtonsCls btnewphoto" Font-Size="Small" />
                                    </section>
                                    <section class="PhotoBtnsHolder" style="display: none">
                                        <asp:Button ID="btnDeletePic" runat="server" Text="<%$ Resources:localizedText, removePicture %>" CssClass="PhotoholderButtonsCls btdelphoto" Font-Size="Small" />
                                    </section>
                                </section>

                                <section class="photo" style="width: 100%; height: 70%;">
                                    <fieldset id="PhotoFieldset" style="width: 198px; min-width: 150px; margin-right: auto; border: 1px solid black; height: 214px; padding: 0;">

                                        <div id="Photoholder" class="PhotoholderClsnew">
                                        </div>
                                    </fieldset>
                                </section>
                                <%-- <section class="secCommentedLinks" style="display:none"></section>--%>
                                <section class="tabsec3bttm">
                                    <section class="lblmemholder" style="display: none">
                                        <asp:Label ID="Label29" runat="server" Text="<%$ Resources:localizedText, memo %>" CssClass="memHeader"></asp:Label>
                                    </section>
                                    <section class="memosec" style="display: none">
                                        <asp:TextBox ID="txtMemo" runat="server" CssClass="txt" TextMode="MultiLine"></asp:TextBox>
                                    </section>
                                    <section class="sectionLinks">
                                        <section class="secLinkOne">
                                            <%--  <asp:HyperLink ID="HyperLink2" runat="server" CssClass="hypLnkVis"><asp:Literal runat="server" Text="<%$ Resources:localizedText, addPhoto%>" /></asp:HyperLink>--%>
                                            <asp:Button ID="btnTriggerFileUpload" runat="server" CssClass="hypLnkVis hyperButtonsHover" Text="<%$ Resources:localizedText, selectingaSavedPhoto %>" Style="color: forestgreen;" />
                                        </section>
                                        <section class="secLinkTwo">
                                            <%-- <asp:HyperLink ID="HyperLink3" runat="server" CssClass="hypLnkVis2"> <asp:Literal runat="server" Text="<%$ Resources:localizedText, takePhoto_new%>" /></asp:HyperLink>--%>
                                            <asp:Button ID="btnTakeWebcamPicture" runat="server" CssClass="hypLnkVis2 hyperButtonsHover" Text="<%$ Resources:localizedText, activateWebcam %>" Style="color: rgba(46,116,223,1.00);" />
                                        </section>
                                        <section class="secLinkThree">
                                            <%--                                        <asp:HyperLink ID="HyperLink4" runat="server" CssClass="hypLnkVis3"><asp:Literal runat="server" Text="<%$ Resources:localizedText, deletePhoto%>" /></asp:HyperLink>--%>
                                            <asp:Button ID="btnRemovePhoto" runat="server" CssClass="hypLnkVis3 hyperButtonsHover" Text="<%$ Resources:localizedText, deletePhoto %>" Style="color: red;" />

                                        </section>
                                    </section>
                                </section>
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
                        <asp:Button ID="btnAccept" runat="server" Text="Übernehmen" CssClass="cameraButtonsLeft " />
                        <asp:Button ID="btnCancelPhoto" runat="server" Text="Aufheben" CssClass="cameraButtonsRight " />
                    </section>
            </div>

            <section class="secgrid">
                <dx:ASPxGridView ID="grdVisitors" runat="server" AutoGenerateColumns="False" EnableTheming="false" Width="100%" KeyFieldName="ID" ClientInstanceName="grdVisitors">

                    <ClientSideEvents RowDblClick="function(s, e) {
	grdVisitorsRowDbClick(s,e);
}"></ClientSideEvents>

                    <Columns>
                        <dx:GridViewDataTextColumn VisibleIndex="0" Visible="false" Caption="ID" FieldName="ID">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn VisibleIndex="1" Caption="<%$ Resources:localizedText, applications2 %>" FieldName="PersName" Width="13%">
                            <CellStyle BackColor="#ADDCCB" Border-BorderColor="Gray" ForeColor="Black"></CellStyle>
                            <HeaderStyle BackColor="#ADDCCB" Font-Bold="true" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn VisibleIndex="2" Caption="<%$ Resources:localizedText, telephone %>" FieldName="PersPhoneNr" Width="12%">
                            <CellStyle BackColor="#ADDCCB" Border-BorderColor="Gray" ForeColor="Black" HorizontalAlign="left"></CellStyle>
                            <HeaderStyle BackColor="#ADDCCB" HorizontalAlign="left" Font-Bold="true" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn VisibleIndex="3" Caption="<%$ Resources:localizedText, no2 %>" FieldName="CompanyNr" Width="5%">
                            <HeaderStyle BackColor="#f69679" HorizontalAlign="left" ForeColor="Black" Font-Bold="true" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" HorizontalAlign="left" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn VisibleIndex="5" Caption="<%$ Resources:localizedText, companyClient %>" FieldName="Company" Width="13%">
                            <HeaderStyle BackColor="#f69679" HorizontalAlign="Left" ForeColor="Black" Font-Bold="true" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" HorizontalAlign="Left" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="5%" Caption="<%$ Resources:localizedText, postcode %>" VisibleIndex="5" FieldName="CompanyPostalCode">
                            <HeaderStyle BackColor="#f69679" ForeColor="Black" Font-Bold="true" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black" HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="8%" Caption="<%$ Resources:localizedText, place2 %>" VisibleIndex="6" FieldName="CompanyLocation">


                            <HeaderStyle BackColor="#f69679" ForeColor="Black" Font-Bold="true" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="7%" Caption="<%$ Resources:localizedText, street %>" VisibleIndex="7" FieldName="CompanyStreet">


                            <HeaderStyle BackColor="#f69679" ForeColor="Black" Font-Bold="true" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="3%" Caption="Nr.:" VisibleIndex="8" FieldName="CompanyStreetNr">


                            <HeaderStyle BackColor="#f69679" ForeColor="Black" Font-Bold="true" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black" HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn VisibleIndex="6" Caption=" Bes.ID:" FieldName="VisitorID" Width="3%">
                            <HeaderStyle BackColor="#f69679" HorizontalAlign="left" ForeColor="Black" Font-Bold="true" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" HorizontalAlign="left" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="15%" Caption="<%$ Resources:localizedText, name %>" VisibleIndex="10" FieldName="VisitorName">
                            <HeaderStyle BackColor="#f69679" ForeColor="Black" Font-Bold="true" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn VisibleIndex="8" Caption="<%$ Resources:localizedText, telephone %>" FieldName="Telephone" Width="9%">
                            <HeaderStyle BackColor="#f69679" HorizontalAlign="left" ForeColor="Black" Font-Bold="true" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" HorizontalAlign="left" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn VisibleIndex="9" Caption="<%$ Resources:localizedText, mobile %>" FieldName="Mobile" Width="9%">
                            <HeaderStyle BackColor="#f69679" HorizontalAlign="left" ForeColor="Black" Font-Bold="true" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" HorizontalAlign="left" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn VisibleIndex="10" Caption="<%$ Resources:localizedText, visitorsSince_new1 %>" FieldName="vStartDate" Width="10%">
                            <HeaderStyle BackColor="#FFF1C6" HorizontalAlign="left" Font-Bold="true" />
                            <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray" HorizontalAlign="left" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTimeEditColumn VisibleIndex="11" Caption="<%$ Resources:localizedText, time_new1 %>" FieldName="vStartDate" Width="5%">
                            <HeaderStyle BackColor="#FFF1C6" HorizontalAlign="Center" Font-Bold="true" />
                            <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray" HorizontalAlign="left" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTimeEditColumn>
                        <dx:GridViewDataDateColumn VisibleIndex="12" Caption="<%$ Resources:localizedText, toScm %>" FieldName="vEndDate" Width="5%">
                            <HeaderStyle BackColor="#FFF1C6" HorizontalAlign="Center" Font-Bold="true" />
                            <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray" HorizontalAlign="left" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTimeEditColumn VisibleIndex="13" Caption="<%$ Resources:localizedText, time_new1 %>" FieldName="vEndDate" Width="5%">
                            <HeaderStyle BackColor="#FFF1C6" HorizontalAlign="Center" Font-Bold="true" />
                            <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTimeEditColumn>
                    </Columns>
                    <%--                <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="False" AllowDragDrop="false" ProcessSelectionChangedOnServer="True" />--%>
                    <SettingsPager PageSize="32" ShowEmptyDataRows="True">
                    </SettingsPager>
                    <Settings />
                    <SettingsBehavior AllowFocusedRow="true" AllowDragDrop="false" AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" AllowGroup="false" ProcessSelectionChangedOnServer="true" />
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="CompanyPostalCode" ShowInCustomizationForm="True" Width="5%" Caption="<%$ Resources:localizedText, postcode %>" VisibleIndex="6">
                            <HeaderStyle BackColor="#f69679" HorizontalAlign="left" ForeColor="Black" Font-Bold="true" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" HorizontalAlign="left" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CompanyLocation" ShowInCustomizationForm="True" Width="8%" Caption="<%$ Resources:localizedText, place2 %>" VisibleIndex="7">
                            <HeaderStyle BackColor="#f69679" HorizontalAlign="left" ForeColor="Black" Font-Bold="true" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" HorizontalAlign="left" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CompanyStreet" ShowInCustomizationForm="True" Width="7%" Caption="<%$ Resources:localizedText, street %>" VisibleIndex="9">
                            <HeaderStyle BackColor="#f69679" HorizontalAlign="left" ForeColor="Black" Font-Bold="true" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" HorizontalAlign="left" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CompanyStreetNr" ShowInCustomizationForm="True" Width="3%" Caption="Nr.:" VisibleIndex="10">
                            <HeaderStyle BackColor="#FFF1C6" HorizontalAlign="Center" Font-Bold="true" />
                            <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="VisitorID" ShowInCustomizationForm="True" Width="3%" Caption=" Bes.ID:" VisibleIndex="8">
                            <HeaderStyle BackColor="#f69679" HorizontalAlign="left" ForeColor="Black" Font-Bold="true" />
                            <CellStyle BackColor="#f69679" Border-BorderColor="Gray" HorizontalAlign="left" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="VisitorName" ShowInCustomizationForm="True" Width="15%" Caption="Name:" VisibleIndex="13">
                            <HeaderStyle BackColor="#FFF1C6" HorizontalAlign="Center" Font-Bold="true" />
                            <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Telephone" ShowInCustomizationForm="True" Width="9%" Caption="<%$ Resources:localizedText, telephone %>" VisibleIndex="11">
                            <HeaderStyle BackColor="#FFF1C6" HorizontalAlign="Center" Font-Bold="true" />
                            <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Mobile" ShowInCustomizationForm="True" Width="9%" Caption="<%$ Resources:localizedText, mobile %>" VisibleIndex="12">
                            <HeaderStyle BackColor="#FFF1C6" HorizontalAlign="Center" Font-Bold="true" />
                            <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="vStartDate" ShowInCustomizationForm="True" Width="10%" Caption="<%$ Resources:localizedText, visitorsSince_new1 %>" VisibleIndex="14">
                            <HeaderStyle BackColor="#FFF1C6" HorizontalAlign="Center" Font-Bold="true" />
                            <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTimeEditColumn FieldName="vStartDate" ShowInCustomizationForm="True" Width="5%" Caption="<%$ Resources:localizedText, time_new1 %>" VisibleIndex="15">
                            <HeaderStyle BackColor="#FFF1C6" HorizontalAlign="Center" Font-Bold="true" />
                            <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTimeEditColumn>
                        <dx:GridViewDataDateColumn FieldName="vEndDate" ShowInCustomizationForm="True" Width="5%" Caption="<%$ Resources:localizedText, toScm %>" VisibleIndex="16">
                            <HeaderStyle BackColor="#FFF1C6" HorizontalAlign="Center" Font-Bold="true" />
                            <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTimeEditColumn FieldName="vEndDate" ShowInCustomizationForm="True" Width="5%" Caption="<%$ Resources:localizedText, time_new1 %>" VisibleIndex="17">
                            <HeaderStyle BackColor="#FFF1C6" HorizontalAlign="Center" Font-Bold="true" />
                            <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTimeEditColumn>
                    </Columns>
                </dx:ASPxGridView>
            </section>

            <asp:ObjectDataSource ID="odsfvVisitorApplications" runat="server" DataObjectTypeName="Access_Control.Dtos.VisitorApplicationDto" InsertMethod="CreateVisitorApplication" SelectMethod="GetVisitorApplicationById" TypeName="Access_Control.ViewModels.VisitorApplicationViewModel" UpdateMethod="UpdateVisitorApplication" DeleteMethod="DeleteVisitorApplication">
                <SelectParameters>
                    <%--   <asp:ControlParameter ControlID="ddlPersonalName" PropertyName="SelectedValue" DefaultValue="0" Name="visitorApplicationID" Type="Int64" ConvertEmptyStringToNull="true"></asp:ControlParameter>--%>
                </SelectParameters>
            </asp:ObjectDataSource>

            <%--  <asp:ObjectDataSource ID="odsgrdVisitorApplications" runat="server" SelectMethod="GetVisitorApplications" TypeName="Access_Control.ViewModels.VisitorApplicationViewModel" DataObjectTypeName="Access_Control.Dtos.VisitorApplicationDto" DeleteMethod="DeleteVisitorApplication" InsertMethod="CreateVisitorApplication" UpdateMethod="UpdateVisitorApplication"></asp:ObjectDataSource>

        <asp:ObjectDataSource ID="odsSearchPersonnel" runat="server" SelectMethod="GetPersonnel" TypeName="Access_Control.ViewModels.PersonnelViewModel"></asp:ObjectDataSource>

        <asp:ObjectDataSource ID="odsCarList" runat="server" DataObjectTypeName="KruAll.Core.Models.VehicleType" DeleteMethod="DeleteVehicleType" InsertMethod="NewVehicleType" SelectMethod="GetVehicleType" TypeName="KruAll.Core.Repositories.VehicleTypeRepository" UpdateMethod="EditvehicleType"></asp:ObjectDataSource>
            --%>
        </div>


        <div class="searchVisitors" style="display: none;">
            <dx:ASPxGridView ID="grdSearchVisitors" ClientInstanceName="grdSearchVisitors" runat="server" Width="100%" AutoGenerateColumns="False" Theme="" EnableCallBacks="false" EnableTheming="false" KeyFieldName="ID">
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="false" VisibleIndex="0"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="8%" Caption="<%$ Resources:localizedText, applications2 %>" VisibleIndex="1" FieldName="PersName">
                        <CellStyle BackColor="#ADDCCB" Border-BorderColor="Gray" ForeColor="Black"></CellStyle>
                        <HeaderStyle BackColor="#ADDCCB" />

                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="7%" Caption="<%$ Resources:localizedText, telephone %>" VisibleIndex="2" FieldName="PersPhoneNr">
                        <CellStyle BackColor="#ADDCCB" Border-BorderColor="Gray" ForeColor="Black"></CellStyle>
                        <HeaderStyle BackColor="#ADDCCB" />

                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="3%" Caption="Nr.:" VisibleIndex="3" FieldName="CompanyNr">


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
                    <dx:GridViewDataTextColumn Width="3%" Caption="Nr.:" VisibleIndex="8" FieldName="CompanyStreetNr">


                        <HeaderStyle BackColor="#f69679" ForeColor="Black" />
                        <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black" HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="5%" Caption="<%$ Resources:localizedText, visitorID %>" VisibleIndex="9" FieldName="VisitorID">


                        <HeaderStyle BackColor="#f69679" ForeColor="Black" />
                        <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black" HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="15%" Caption="Name:" VisibleIndex="10" FieldName="VisitorName">
                        <HeaderStyle BackColor="#f69679" ForeColor="Black" />
                        <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="7%" Caption="<%$ Resources:localizedText, telephone %>" VisibleIndex="11" FieldName="Telephone">
                        <HeaderStyle BackColor="#f69679" ForeColor="Black" />
                        <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="7%" Caption="<%$ Resources:localizedText, mobile %>" VisibleIndex="12" FieldName="Mobile">
                        <HeaderStyle BackColor="#f69679" ForeColor="Black" />
                        <CellStyle BackColor="#f69679" Border-BorderColor="Gray" ForeColor="Black"></CellStyle>
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
                <SettingsBehavior AllowFocusedRow="true" AllowDragDrop="false" AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" AllowSort="false" ProcessSelectionChangedOnServer="true" />
            </dx:ASPxGridView>
        </div>

        <section id="searchpersonnel" style="display: none">
            <dx:ASPxGridView ID="grdSearchPersonnel" runat="server" AutoGenerateColumns="false" KeyFieldName="ID" ClientInstanceName="grdSearchPersonnel" EnableCallBacks="false" EnableTheming="True" Theme="Office2003Blue" Width="100%">
                <Columns>
                    <dx:GridViewDataTextColumn VisibleIndex="2" Caption="<%$ Resources:localizedText, name %>" FieldName="Fullname">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn VisibleIndex="3" Caption="<%$ Resources:localizedText, name %>" FieldName="Pers_Nr">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="False" AllowDragDrop="false" ProcessSelectionChangedOnServer="True" />
                <SettingsPager PageSize="23" ShowEmptyDataRows="True"></SettingsPager>
            </dx:ASPxGridView>
        </section>

        <section id="searchcarsection" style="display: none" class="searchsection">
            <%--class="searchsection"--%>
            <dx:ASPxGridView ID="grdCarSearch" runat="server" AutoGenerateColumns="False" EnableTheming="True" Theme="Office2003Blue" Width="100%" KeyFieldName="ID" ClientInstanceName="grdCarSearch" EnableCallBacks="false">
                <ClientSideEvents RowDblClick="function(s, e) {
	 grdcartypeClick(s, e)
}"></ClientSideEvents>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" Visible="false" VisibleIndex="0" FieldName="ID">
                        <CellStyle HorizontalAlign="Left">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:LocalizedText,manufacturer1 %>" VisibleIndex="1" FieldName="Name">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:LocalizedText,typevehicle1 %>" VisibleIndex="2" FieldName="Type">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Memo" VisibleIndex="3" FieldName="Memo">
                        <CellStyle HorizontalAlign="Left">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                </Columns>

                <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="False" AllowDragDrop="false" ProcessSelectionChangedOnServer="True" />
                <SettingsPager PageSize="1000" ShowEmptyDataRows="false" Visible="False">
                </SettingsPager>

                <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
            </dx:ASPxGridView>
            <div class="Wrappernew3">
                <div id="GrdIdNrnew" class="gridIdNr">
                    <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="grdClients" runat="server" KeyFieldName="ID" ClientIDMode="Static" CellPadding="4" ForeColor="#333333" Width="100%" GridLines="Both" Theme="Office2003Blue" AutoGenerateColumns="False" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="14px">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="Hersteller:" VisibleIndex="1" FieldName="" Width="33%">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="  

Fahrzeugtyp:"
                                VisibleIndex="2" FieldName="Name" Width="60%">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="False" VisibleIndex="0">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsBehavior AllowFocusedRow="true" AllowDragDrop="false" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="true" />
                        <SettingsPager PageSize="11" ShowEmptyDataRows="True" Visible="False">
                        </SettingsPager>
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                    </dx:ASPxGridView>
                </div>

                <div id="Grid4new" class="Grid2">
                    <section style="display: none">
                        <asp:DropDownList ID="DropDownList1" runat="server" Visible="true" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" AutoPostBack="true" DataTextField="Name" DataValueField="ID">
                        </asp:DropDownList>
                    </section>
                    <section id="fvSec3new" style="width: 100%; height: 100%">

                        <section>
                            <asp:Label ID="Label38" runat="server" Text="Hersteller:" CssClass="lblclient" Style="width: 12%;"></asp:Label>
                            <asp:TextBox ID="TextBox3" runat="server" Enabled="true" CssClass="txtpclientdesc" Text='<%# Bind("Name") %>'></asp:TextBox>
                        </section>
                        <section>
                            <asp:Label ID="Label39" runat="server" Text="  

Fahrzeugtyp:"
                                CssClass="lblptypenew" Style="width: 11%;"></asp:Label>
                            <asp:TextBox ID="TextBox4" runat="server" Enabled="true" CssClass="txtpmemonew" Text='<%# Bind("Type") %>'></asp:TextBox>
                        </section>
                    </section>
                </div>

                <section class="ActionBtnsBottom">
                    <asp:Button ID="Button1" CssClass="GridFooterBtnsLeft btnNew" runat="server" Text="<%$ Resources:localizedText, newButton %>" />
                    <%--        <asp:Button ID="Button17" CssClass="GridFooterBtnsLeft btnEdit" runat="server" Text="<%$ Resources:localizedText, editing %>" />--%>
                    <asp:Button ID="Button2" CssClass="GridFooterBtnsLeft btnSave" runat="server" Text="<%$ Resources:localizedText, saveButton %>" />
                    <asp:Button ID="Button3" CssClass="GridFooterBtnsLeft btnLöschen" runat="server" Text="<%$ Resources:localizedText, deleteButton %>" />
                    <asp:Button ID="Button4" CssClass="BottomFooterBtnsRight btnClose" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
                </section>
            </div>
        </section>

        <div class="searchclint" id="client" style="display: none;">
            <div class="Wrappernew3">
                <div id="GrdIdNr" class="gridIdNr">

                    <dx:ASPxGridView ID="grdClients" ClientInstanceName="grdClients" runat="server" KeyFieldName="ID" ClientIDMode="Static" CellPadding="4" ForeColor="#333333" Width="100%" GridLines="Both" Theme="Office2003Blue" AutoGenerateColumns="False" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="14px">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, companyclientid %>" VisibleIndex="1" FieldName="Client_Nr" Width="15%">
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
                    </dx:ASPxGridView>
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
                    <asp:Button ID="btnNew" CssClass="GridFooterBtnsLeft btnNew" runat="server" Text="<%$ Resources:localizedText, newButton %>" />
                    <%--        <asp:Button ID="Button17" CssClass="GridFooterBtnsLeft btnEdit" runat="server" Text="<%$ Resources:localizedText, editing %>" />--%>
                    <asp:Button ID="btnSave" CssClass="GridFooterBtnsLeft btnSave" runat="server" Text="<%$ Resources:localizedText, saveButton %>" />
                    <asp:Button ID="btnDelete" CssClass="GridFooterBtnsLeft btnLöschen" runat="server" Text="<%$ Resources:localizedText, deleteButton %>" />
                    <asp:Button ID="btnCompanyBack" CssClass="BottomFooterBtnsRight btnClose" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
                </section>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <%--<asp:Button ID="btnEntNew" CssClass="BottomFooterBtnsLeft btnNew" runat="server" Text="<%$ Resources:localizedText, newButton %>" OnClick="btnEntNew_Click" />--%>
    <%-- <asp:Button ID="btnEntEdit" CssClass="BottomFooterBtnsLeft btnEdit" runat="server" Text="<%$ Resources:localizedText, editing %>" OnClick="btnEntEdit_Click" />--%>
    <asp:Button ID="btnEntSave" CssClass="BottomFooterBtnsLeft btnSave" runat="server" Text="<%$ Resources:localizedText, saveButton %>" Style="display: none;" />
    <asp:Button ID="btnCancelDel" CssClass="BottomFooterBtnsLeft btnLöschen" runat="server" Text="<%$ Resources:localizedText, deleteButton %>" Style="display: none;" />
    <asp:Button ID="btnApply" runat="server" Text="<%$ Resources:localizedText, takeover %>" CssClass="editbtnfooterorange" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" ClientIDMode="Static" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
