<%@ Page Title="<%$ Resources:localizedText ,visitor%>" Language="C#" MasterPageFile="~/MasterPages/Gate.Master" AutoEventWireup="true" CodeBehind="GateVisitors.aspx.cs" Inherits="Access_Control_NewMask.Content.GateVisitors" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/GateVisitors.js?v=<%= Access_Control_NewMask.Controllers.Version.JSVersion %>"></script>
    <link href="Styles/GateVisitors.css?v=<%= Access_Control_NewMask.Controllers.Version.JSVersion %>" rel="stylesheet" />
    <%--<link href="Styles/ImportantDialogVisitorDashboard.css" rel="stylesheet" />--%>
    <script src="Scripts/Webcamscripts/webcam.min.js"></script>
    <script type="text/javascript" src="Scripts/TakePhoto.js"></script>
    <link href="Styles/SerchClientCompanyDashbord.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">
    <asp:HiddenField ID="hiddenFieldVisitInstanceId" runat="server" />
    <asp:HiddenField ID="hiddenFieldVisitInstanceIdNr" runat="server" />
    <asp:HiddenField ID="hiddenFieldSecurityTrainerId" runat="server" />
    <asp:HiddenField ID="hiddenFieldSelectedVehicleType" runat="server" />
    <asp:HiddenField ID="hiddenFieldSelectedVehicleModel" runat="server" />
    <asp:HiddenField ID="hiddenFieldSaveChanges" runat="server" />
    <dx:ASPxLoadingPanel ID="LoadingPanel" runat="server" ClientInstanceName="LoadingPanel" Modal="True" ShowImage="true" ClientIDMode="Static" Text="Stammdaten werden gesendet...">
        <Image Url="../Images/FormImages/Loading.gif" />
    </dx:ASPxLoadingPanel>
    <div class="midareavisitor2">
        <div class="midcontentareavisitor2">
            <div class="persinfoareavisitor">
                <div id="tabcontroldiv">
                    <div id="UpperDiv" style="display: block;">
                        <div id="leftdiv">
                            <section class="topbtnarea">
                                <asp:Button ID="btnvishitorie" runat="server" Text="<%$ Resources:localizedText ,visitorData_new%>" CssClass="newstandardbutton btnregister" />
                                <asp:Button ID="btnVisApplication" runat="server" Text="<%$ Resources:localizedText ,applications%>" CssClass="newstandardbutton btnregister" Style="margin-left: 0px;" />
                                <%--    <asp:Button ID="btnPersonalCalender" runat="server" Text="PersonalKalender" CssClass="btncalender" />--%>
                            </section>
                            <section id="secDispTwo" class="tab1leftsection">
                                <section class="tab1leftsection1Left">
                                    <asp:Label ID="Label32" runat="server" Text="<%$ Resources:localizedText ,visitorinformation%>" CssClass="lblpersonal22new" Style="display: none"></asp:Label>
                                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText ,visitorID%>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                    <asp:Label ID="Label71" runat="server" Text="<%$ Resources:localizedText ,company%>" CssClass="lblpersonal2 fontweight600" Style="display: none"></asp:Label>

                                    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText ,firstName2%>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                    <asp:Label ID="Label73" runat="server" Text="<%$ Resources:localizedText ,surname%>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                    <asp:Label ID="Label72" runat="server" Text="<%$ Resources:localizedText ,company%>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText,company %>" CssClass="lblpersonal2 fontweight600" Style="display: none"></asp:Label>
                                    <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, expectedEntry %>" CssClass="lblpersonal2 fontweight600" Style="display: none;"></asp:Label>
                                    <asp:Label ID="Label5" runat="server" Text="<%$ Resources:localizedText, road2 %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                    <asp:Label ID="Label68" runat="server" Text="<%$ Resources:localizedText, housenum %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                    <asp:Label ID="Label69" runat="server" Text="<%$ Resources:localizedText, zipCode3 %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                    <asp:Label ID="Label17" runat="server" Text="<%$ Resources:localizedText, loc %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                    <asp:Label ID="Label22" runat="server" Text="<%$ Resources:localizedText, telephone %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                    <asp:Label ID="Label18" runat="server" Text="<%$ Resources:localizedText, mobile %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                    <asp:Label ID="Label19" runat="server" Text="<%$ Resources:localizedText, email1 %>" CssClass="lblpersonal2 fontweight600"></asp:Label>
                                    <asp:Label ID="Label21" runat="server" Text="<%$ Resources:localizedText, indicator %>" CssClass="lblpersonal2 fontweight600" Style="margin-top: 2px;"></asp:Label>
                                    <asp:Label ID="Label20" runat="server" Text="<%$ Resources:localizedText, vehicleType %>" CssClass="lblpersonal2 fontweight600" Style="margin-top: 5px;"></asp:Label>

                                    <div style="display: none;">
                                        <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText ,personVisited%>" CssClass="lblpersonalNew fontweight600"></asp:Label>
                                        <asp:Label ID="Label13" runat="server" Text="<%$ Resources:localizedText ,purposeOfVisit %>" CssClass="lblpersonalsplit2new fontweight600"></asp:Label>

                                        <asp:Label ID="Label30" runat="server" Text="<%$ Resources:localizedText ,securityCheckBy%>" CssClass="lblpersonalsplit fontweight600" Style="line-height: 14px;"></asp:Label>
                                        <asp:Label ID="Label31" runat="server" Text="<%$ Resources:localizedText ,securityTrainingBy %>" CssClass="lblpersonalsplit2 fontweight600"></asp:Label>
                                    </div>
                                </section>
                            </section>
                            <section id="secDispOne" class="tab1leftsection2Left">
                                <asp:TextBox ID="txtVisitorDbId" runat="server" Style="display: none;" CssClass="txtpersonalnewwcost"></asp:TextBox>
                                <asp:TextBox ID="txtVisitorID" runat="server" CssClass="txtpersonalnewwcost"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton2" runat="server" CssClass="buttonbes" Style="display: none;" />
                                <asp:TextBox ID="txtName" ClientIDMode="Static" runat="server" CssClass="txtpersonal"></asp:TextBox>
                                <asp:TextBox ID="txtSurName" ClientIDMode="Static" runat="server" CssClass="txtpersonal"></asp:TextBox>
                                <asp:TextBox ID="txtVisitorCompanyID" ClientIDMode="Static" runat="server" CssClass="txtpersonal" Style="display: none;"></asp:TextBox>
                                <asp:TextBox ID="txtVisitorCompanyName" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="txtcompanynew" Style="margin-bottom: 1%; margin-top: 0px;"></asp:TextBox>
                                <div style="display: none;">

                                    <dx:ASPxComboBox ID="dplCompanyName" ClientInstanceName="dplCompanyName" runat="server" ValueField="ID" TextField="Client_Nr" OnCallback="dplCompanyName_Callback" CallbackPageSize="100000" EnableCallbackMode="true"
                                        TextFormatString="{0}" CssClass="txtpersonalnrnew" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" HorizontalAlign="Left">

                                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	dplCompanyNameSelectedIndexChanged(s, e)
}"
                                            EndCallback="function(s, e) {
	dplCompanyNameEndCallback(s,e);
}"></ClientSideEvents>
                                        <Columns>
                                            <%--<dx:ListBoxColumn FieldName="Client_Nr" Visible="false" Name="ProfileDescription" ToolTip="" Width="20%" Caption="Nr" />--%>
                                            <dx:ListBoxColumn FieldName="Name" Name="ID" ToolTip="Firma" Caption="Firma" Width="80%" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                </div>


                                <asp:Button ID="btnSearchClient" runat="server" CssClass="btnSearchPersnlnew" Text="..." ClientIDMode="Static" />
                                <asp:Button ID="btnSerchClient" runat="server" CssClass="btnSearchclient" Text="" ClientIDMode="Static" />
                                <asp:TextBox ID="txtCompany" ClientIDMode="Static" runat="server" CssClass="txtpersonal" Style="display: none"></asp:TextBox>
                                <div style="display: none;">
                                    <dx:ASPxDateEdit ID="dtpExpectedEntry" runat="server" Theme="Office2003Blue" CssClass="dtpckr" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif"
                                        EnableTheming="true" Font-Size="14px" HorizontalAlign="Center">
                                    </dx:ASPxDateEdit>
                                </div>
                                <asp:TextBox ID="txtStreet" ClientIDMode="Static" ReadOnly="true" runat="server" CssClass="txtpersonal"></asp:TextBox>
                                <asp:TextBox ID="txtStreetNr" ClientIDMode="Static" ReadOnly="true" runat="server" CssClass="txtpersonaln0_200"></asp:TextBox>
                                <asp:TextBox ID="txtPostalCode" ClientIDMode="Static" ReadOnly="true" runat="server" CssClass="txtpersonalnr"></asp:TextBox>
                                <asp:TextBox ID="txtLocation" ClientIDMode="Static" ReadOnly="true" runat="server" CssClass="txtpersonal"></asp:TextBox>
                                <asp:TextBox ID="txtTelephone" ClientIDMode="Static" runat="server" CssClass="txtpersonal"></asp:TextBox>
                                <asp:TextBox ID="txtMobile" ClientIDMode="Static" runat="server" CssClass="txtpersonal"></asp:TextBox>
                                <asp:TextBox ID="txtEmail" ClientIDMode="Static" runat="server" CssClass="txtpersonal"></asp:TextBox>
                                <asp:TextBox ID="txtVehicleId" ClientIDMode="Static" runat="server" CssClass="txtpersonal" Style="display: none"></asp:TextBox>
                                <asp:TextBox ID="txtVehicleNo" ClientIDMode="Static" runat="server" CssClass="txtpersonalnew"></asp:TextBox>
                                <asp:TextBox ID="txtVehicleTypes" runat="server" CssClass="txtpersonal"></asp:TextBox>
                                <asp:Button ID="btnsearchvehicle" runat="server" CssClass="btnSearchPersnlnew" Text="" ClientIDMode="Static" />
                                <div style="display: none">
                                    <asp:TextBox ID="txtPersVisited" ReadOnly="true" runat="server" CssClass="txtpersonal21"></asp:TextBox>
                                    <asp:Button ID="btnSearchPersonal" runat="server" CssClass="btnSearchPersnl" Text="..." />
                                    <asp:TextBox ID="txtPurpose" runat="server" CssClass="txtpersonal2"></asp:TextBox>
                                    <asp:Button ID="Button7" runat="server" CssClass="btnsearchTimeOut" Text="..." Enabled="false" />

                                    <asp:TextBox ID="txtSecurityChecked" ReadOnly="true" runat="server" CssClass="txtpersonal31"></asp:TextBox>
                                    <asp:Button ID="btnSecurityCheckBy" runat="server" CssClass="btnSearchPurpose" Text="..." />
                                    <asp:Label ID="Label23" runat="server" Text="<%$ Resources:localizedText ,am%>" CssClass="lbl"></asp:Label>
                                    <dx:ASPxTimeEdit ID="dtpcheckTime" runat="server" CssClass="txtpersonal32" EnableTheming="true">
                                        <SpinButtons Enabled="false" ShowIncrementButtons="false"></SpinButtons>
                                    </dx:ASPxTimeEdit>

                                    <asp:TextBox ID="txtTrainingBy" ReadOnly="true" runat="server" CssClass="txtpersonal3"></asp:TextBox>
                                    <asp:Button ID="btnSecurityTrainedBy" runat="server" CssClass="btnSearchTimein" Text="..." />
                                    <asp:Label ID="Label24" runat="server" Text="<%$ Resources:localizedText ,am%>" CssClass="lblpersonalLeftDiv2"></asp:Label>
                                    <dx:ASPxTimeEdit ID="dtptrainingTime" runat="server" CssClass="txtpersonal32b" EnableTheming="true">
                                        <SpinButtons Enabled="false" ShowIncrementButtons="false"></SpinButtons>
                                    </dx:ASPxTimeEdit>
                                </div>
                            </section>
                            <section class="tab1leftsection2Leftpicnew">
                                <section class="photoarea">
                                    <fieldset id="PhotoFieldset" class="actualpic">
                                        <%-- style="float: right; margin-left: auto; border: 1px solid black; height: 214px; padding: 0;"--%>
                                        <asp:HiddenField ID="photVal" ClientIDMode="Static" runat="server" />
                                        <div id="Photoholder" class="PhotoholderClsnewpic">
                                            <img id="img" runat="server" src="" />
                                        </div>
                                    </fieldset>
                                </section>
                                <section class="areared1">
                                    <section class="picbuttons">
                                        <div style="display: none;">
                                            <asp:FileUpload ID="UploadPhoto" ClientIDMode="Static" CssClass="PhotoholderButtonsClsUpload" accept=".png,.jpg,.jpeg,.gif" runat="server" />
                                        </div>
                                        <asp:Button ID="btnTriggerFileUpload" runat="server" CssClass="PhotoholderClsnewb hyperButtonsHover" Text="<%$ Resources:localizedText, selectingaSavedPhoto %>" Style="color: forestgreen;" />
                                    </section>
                                    <section class="picbuttons">
                                        <asp:Button ID="btnTakeWebcamPicture" runat="server" CssClass="PhotoholderClsnewb hyperButtonsHover" Text="<%$ Resources:localizedText, activateWebcam %>" Style="color: rgba(46,116,223,1.00);" />
                                    </section>
                                    <section class="picbuttons">
                                        <%--<asp:Button ID="Button17" runat="server" CssClass="PhotoholderClsnew hyperButtonsHover" Text="Passfoto Specichern" Style="color: #2DAA9E;" />--%>
                                    </section>
                                    <section class="picbuttons">
                                        <asp:Button ID="btnRemovePhoto" runat="server" CssClass="PhotoholderClsnewb hyperButtonsHover" Text="<%$ Resources:localizedText, deletePhoto %>" Style="color: red;" />
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
                                <asp:Button ID="btnAccept" runat="server" Text="<%$ Resources:localizedText, accept %>" CssClass="cameraButtonsLeft " />
                                <asp:Button ID="btnCancelPhoto" runat="server" Text="<%$ Resources:localizedText, cancelphoto %>" CssClass="cameraButtonsRight " />
                            </section>
                            <section class="topbtnareanewHeader">
                                <asp:Label ID="Label93" runat="server" Text="<%$ Resources:localizedText ,visitingclient %>" CssClass="newcompany"></asp:Label>
                            </section>

                            <section style="float: left; width: 100%; height: 5%;">
                                <asp:Label ID="Label95" runat="server" Text="<%$ Resources:localizedText ,name%>" CssClass="lblcompanyname"></asp:Label>

                                <asp:TextBox ID="txtToCompanyId" ClientIDMode="Static" runat="server" CssClass="txtareanamenew" Style="display: none;"></asp:TextBox>
                                <asp:TextBox ID="txtToCompanyName" ClientIDMode="Static" runat="server" CssClass="txtareanamenew"></asp:TextBox>
                                <asp:Button ID="btnSearchclient1" runat="server" CssClass="btnSearchclient" Text="" ClientIDMode="Static" />

                                <div style="display: none;">
                                    <asp:Label ID="Label94" runat="server" Text="<%$ Resources:localizedText ,companyclientid%>" CssClass="lblcompany"></asp:Label>
                                    <dx:ASPxComboBox ID="dplToCompanyNr" runat="server" ValueField="ID" TextField="Client_Nr" TextFormatString="{0}" EnableCallbackMode="true" CallbackPageSize="100000" CssClass="drpcompanyid" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px">
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
                                    <%--       <dx:ASPxDropDownEdit ID="ASPxDropDownEdit2" runat="server" CssClass="drpcompanyname" Theme="Office2003Blue"></dx:ASPxDropDownEdit>--%>
                                    <dx:ASPxComboBox ID="dplToCompanyName" runat="server" ValueField="ID" TextField="Name" TextFormatString="{1}" EnableCallbackMode="true" CssClass="drpcompanyname" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px">
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
                                    <asp:ImageButton ID="btnSearchClient2" runat="server" CssClass="buttonbesnew" Style="margin-top: 2px;" />
                                </div>

                            </section>

                            <section style="width: 31%; float: right; height: 13%; margin-top: 10px; margin-left: 6px; border-radius: 5px;">
                                <section class="picbuttons">
                                </section>
                                <section class="picbuttons">
                                </section>

                                <section class="picbuttons">
                                </section>
                            </section>
                        </div>

                        <div id="rightdiv">
                            <section class="topbtnarea" style="height: 1%;">
                            </section>
                            <section class="rightdivTopnew">
                                <section class="topsmall1">
                                    <asp:Label ID="Label33" runat="server" Text="<%$ Resources:localizedText, registrationfrom %>" CssClass="lblpersonalRightTitle" Style="color: red;"></asp:Label>
                                </section>

                                <section class="centre1big" style="height: 71%;">
                                    <section class="centre1bigtop" style="height: 44%;">

                                        <section class="visit1">
                                            <section class="visit1anew">
                                                <asp:Label ID="Label52" runat="server" Text="<%$ Resources:localizedText ,name%>" CssClass="lblpersonalRightCont fontweight600"></asp:Label>
                                            </section>
                                            <section class="visit1bnewName">
                                                <asp:TextBox ID="txtPersonalName" ClientIDMode="Static" Enabled="false" runat="server" CssClass="txtpersonalbottomsmallnew1"></asp:TextBox>
                                            </section>
                                            <%-- <section class="visit1c">
                                                <asp:Button ID="Button8" runat="server" Visible="false" CssClass="btnSearchGLBL ColorRed" Text="..." />
                                            </section>--%>
                                        </section>
                                        <section class="visit1">
                                            <section class="visit1anew">
                                                <asp:Label ID="Label96" runat="server" Text="<%$ Resources:localizedText ,telephone%>" CssClass="lblpersonalRightCont fontweight600"></asp:Label>
                                            </section>
                                            <section class="visit1bnew">
                                                <asp:TextBox ID="txtPersPhoneNr" Enabled="false" ClientIDMode="Static" runat="server" CssClass="txtpersonalbottomsmall2new2"></asp:TextBox>
                                            </section>
                                            <section class="visit1anewUsr">
                                                <asp:Label ID="Label97" runat="server" Text="<%$ Resources:localizedText ,mobil%>" CssClass="lblpersonalRightCont fontweight600"></asp:Label>
                                            </section>
                                            <section class="visit1bnewabc">
                                                <asp:TextBox ID="txtPersMobileNr" Enabled="false" ClientIDMode="Static" runat="server" CssClass="txtTelPhn"></asp:TextBox>
                                            </section>

                                        </section>
                                        <section class="visit1" style="display: none;">
                                            <section class="visit1anew">
                                                <asp:Label ID="Label53" runat="server" Text="<%$ Resources:localizedText ,personalnum%>" CssClass="lblpersonalRightCont fontweight600"></asp:Label>
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
                                            <section class="secreasonForVisit">
                                                <asp:TextBox ID="txtVisitReason" ClientIDMode="Static" ReadOnly="true" runat="server" CssClass="txtpersonalbottomsmallnew1"></asp:TextBox>
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
                                                </dx:ASPxDateEdit>
                                                <asp:Label ID="Label58" runat="server" Text="<%$ Resources:localizedText, timeOfDay %>" CssClass="lblShotr fontweight600" Style="color: red;"></asp:Label>
                                                <dx:ASPxTimeEdit ID="drpRegTime" ClientInstanceName="drpRegTime" runat="server" CssClass="txtsize1date" DisplayFormatString="HH:mm" family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" HorizontalAlign="Center">
                                                    <SpinButtons Enabled="false" ShowIncrementButtons="false">
                                                    </SpinButtons>
                                                </dx:ASPxTimeEdit>
                                            </section>


                                            <section class="tab1leftsection1CheckRows">
                                                <asp:Label ID="Label11" runat="server" Text="<%$ Resources:localizedText, visitbegins %>" CssClass="lblpersonalRightCont3 fontweight600" Style="line-height: 14px;"></asp:Label>
                                                <asp:Label ID="Label15" runat="server" Text="<%$ Resources:localizedText, date %>" CssClass="lblShotrnewdate fontweight600"></asp:Label>
                                                <dx:ASPxDateEdit ID="dtpStartDate" ClientInstanceName="dtpStartDate" runat="server" Theme="Office2003Blue" CssClass="dtpckrnew" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" EnableTheming="true" Font-Size="14px" HorizontalAlign="Center" />
                                                <asp:Label ID="Label25" runat="server" Text="<%$ Resources:localizedText, timeOfDay %>" CssClass="lblShotr fontweight600"></asp:Label>
                                                <dx:ASPxTimeEdit ID="dtpStartDateTime" ClientInstanceName="dtpStartDateTime" runat="server" CssClass="txtsize1date" DisplayFormatString="HH:mm" family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" HorizontalAlign="Center">
                                                    <SpinButtons Enabled="false" ShowIncrementButtons="false">
                                                    </SpinButtons>
                                                </dx:ASPxTimeEdit>
                                            </section>
                                            <section class="tab1leftsection1CheckRows">
                                                <asp:Label ID="Label12" runat="server" Text="<%$ Resources:localizedText, visitends %>" CssClass="lblpersonalRightCont3 fontweight600"></asp:Label>
                                                <asp:Label ID="Label26" runat="server" Text="<%$ Resources:localizedText, date %>" CssClass="lblShotrnewdate fontweight600"></asp:Label>
                                                <dx:ASPxDateEdit ID="dtpEndDate" runat="server" Theme="Office2003Blue" CssClass="dtpckrnew" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif"
                                                    EnableTheming="true" Font-Size="14px" HorizontalAlign="Center" />
                                                <asp:Label ID="Label27" runat="server" Text="<%$ Resources:localizedText, timeOfDay %>" CssClass="lblShotr fontweight600"></asp:Label>
                                                <dx:ASPxTimeEdit ID="dtpEndDateTime" ClientInstanceName="dtpEndDateTime" runat="server" CssClass="txtsize1date" DisplayFormatString="HH:mm" family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" HorizontalAlign="Center">
                                                    <SpinButtons Enabled="false" ShowIncrementButtons="false">
                                                    </SpinButtons>
                                                </dx:ASPxTimeEdit>
                                            </section>
                                            <section class="tab1leftsection1CheckRows">
                                                <asp:Button ID="btnApplyRegDates" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, applycredentials %>" CssClass="btndatatakeover" />
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
                                <asp:TextBox ID="txtPersActivated" Enabled="false" runat="server" CssClass="txtfrom"></asp:TextBox>
                                <asp:Label ID="Label99" runat="server" Text="<%$ Resources:localizedText, am %>" CssClass="lblfromto"></asp:Label>
                                <asp:TextBox ID="txtCardActivatedTime" Enabled="false" runat="server" CssClass="txtfromto"></asp:TextBox>



                            </section>
                            <section class="visactive">
                                <section class="areaeight" style="display: none;">
                                    <asp:Label ID="Label65" CssClass="lblautomatic" runat="server" Text="<%$ Resources:localizedText, longtermid %>"></asp:Label>
                                    <asp:TextBox ID="txtCardNumber" CssClass="txtpersonalbottomsmallnewww1" runat="server" Enabled="false"></asp:TextBox>
                                    <asp:ImageButton ID="imgidentity" runat="server" CssClass="buttonbesnew" />
                                    <asp:Label ID="Label76" runat="server" Text="<%$ Resources:localizedText ,active %>" CssClass="lblActive"></asp:Label>
                                    <asp:CheckBox ID="CheckBox2" runat="server" CssClass="chkAccssData" />

                                </section>
                                <section class="areaeight">
                                    <asp:Label ID="Label66" CssClass="lblautomatic" runat="server" Text="<%$ Resources:localizedText ,shorttermid %>"></asp:Label>
                                    <asp:TextBox ID="txtCardPinCode" CssClass="txtpersonalbottomsmallnewww1" runat="server" Enabled="false"></asp:TextBox>
                                    <asp:ImageButton ID="imgSelection" runat="server" CssClass="buttonbesnewcards" ClientIDMode="Static" />
                                    <asp:Label ID="Label77" runat="server" Text="<%$ Resources:localizedText ,active %>" CssClass="lblActive"></asp:Label>
                                    <asp:CheckBox ID="chkCardActive" ClientIDMode="Static" runat="server" CssClass="chkAccssData" />
                                    <asp:ImageButton ID="ImageButton3" runat="server" CssClass="btnprintarea" />
                                </section>
                                <section class="areaeight">
                                    <asp:Label ID="Label67" CssClass="lblautomatic" runat="server" Text="<%$ Resources:localizedText ,visitorplanid %>"></asp:Label>
                                    <%--    <dx:ASPxDropDownEdit ID="ASPxDropDownEdit3" runat="server" CssClass="drpvisplanid" Theme="Office2003Blue"></dx:ASPxDropDownEdit>--%>
                                    <dx:ASPxComboBox ID="cobVisitorPlanNr" runat="server" SelectedIndex="0" TextFormatString="{0}" ValueField="ID" TextField="VisitorPlanNr" CssClass="drpvisplanid" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px">

                                        <Columns>
                                            <dx:ListBoxColumn FieldName="VisitorPlanNr" Name="VisitorPlanNr" ToolTip="" Width="20%" Caption="Plan Nr." />
                                            <dx:ListBoxColumn FieldName="VisitorPlanDescription" Name="VisitorPlanDescription" ToolTip="Bezeichnung:" Width="80%" Caption="Plan Bezeichnung" />
                                        </Columns>
                                    </dx:ASPxComboBox>

                                    <asp:TextBox ID="txtVisitorPlangroup" CssClass="txtpersonalbottomsmallnewww1below" runat="server" Style="display: none;"></asp:TextBox>
                                    <asp:ImageButton ID="btnVisitorPlanInfo" runat="server" CssClass="buttonbesnewplan2" Style="background-size: cover;" />
                                     <asp:ImageButton ID="imgserchvisitorplan" runat="server" CssClass="buttonbesnewplan" Style="background-size: cover;" />
                                    
                                </section>
                                <section class="areaeight">
                                    <asp:Label ID="Label100" CssClass="lblautomatic" runat="server" Text="<%$ Resources:localizedText ,descriptionnew %>"></asp:Label>
                                    <%--  <dx:ASPxDropDownEdit ID="ASPxDropDownEdit4" runat="server" CssClass="drpdescription" Theme="Office2003Blue"></dx:ASPxDropDownEdit>--%>
                                    <dx:ASPxComboBox ID="cobVisitorPlanName" runat="server" SelectedIndex="0" TextFormatString="{1}" ValueField="ID" TextField="VisitorPlanDescription" CssClass="drpdescription" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px">

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
                                    </dx:ASPxDateEdit>
                                    <asp:Label ID="Label61" runat="server" Text="<%$ Resources:localizedText, timeOfDay %>" CssClass="lblShotr fontweight600"></asp:Label>
                                    <dx:ASPxTimeEdit ID="drpVisitStartDateTime" ClientInstanceName="drpVisitStartDateTime" ClientIDMode="Static" runat="server" CssClass="txtsize1date" DisplayFormatString="HH:mm" family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" HorizontalAlign="Center">
                                        <SpinButtons Enabled="false" ShowIncrementButtons="false">
                                        </SpinButtons>
                                    </dx:ASPxTimeEdit>
                                </section>
                                <section class="areaeight">
                                    <asp:Label ID="Label62" runat="server" Text="<%$ Resources:localizedText, accessto1 %>" CssClass="lblautomatic fontweight600"></asp:Label>
                                    <asp:Label ID="Label63" runat="server" Text="<%$ Resources:localizedText, date %>" CssClass="datearea fontweight600"></asp:Label>
                                    <dx:ASPxDateEdit ID="drpVisitEndDate" ClientInstanceName="drpVisitEndDate" runat="server" Theme="Office2003Blue" CssClass="dtpckrnew" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" EnableTheming="true" Font-Size="14px" HorizontalAlign="Center">
                                    </dx:ASPxDateEdit>
                                    <asp:Label ID="Label64" runat="server" Text="<%$ Resources:localizedText, timeOfDay %>" CssClass="lblShotr fontweight600"></asp:Label>
                                    <dx:ASPxTimeEdit ID="drpVisitEndDateTime" ClientInstanceName="drpVisitEndDateTime" ClientIDMode="Static" runat="server" CssClass="txtsize1date" DisplayFormatString="HH:mm" family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" HorizontalAlign="Center">
                                        <SpinButtons Enabled="false" ShowIncrementButtons="false">
                                        </SpinButtons>
                                    </dx:ASPxTimeEdit>
                                </section>
                                <section class="areaeight" style="height: 16%;">
                                    <asp:Label ID="Label107" runat="server" Text="<%$ Resources:localizedText, usetodaydate %>" CssClass="lbldatefrom"></asp:Label>
                                    <asp:CheckBox ID="chkAutomaticLogout" ClientIDMode="Static" runat="server" CssClass="chkdate" />
                                    <asp:Button ID="btnSendVisitorData" runat="server" Text="<%$ Resources:localizedText, senddata2 %>" CssClass="btndata" Style="margin-top: 2px;" />
                                </section>
                                <section class="areaeight" style="height: 16%;">
                                    <asp:Label ID="Label108" runat="server" Text="<%$ Resources:localizedText, automaticallycheckout %>" CssClass="lbldatefromum"></asp:Label>
                                    <dx:ASPxTimeEdit ID="drpAutomaticLogout" ClientInstanceName="drpAutomaticLogout" ClientIDMode="Static" runat="server" CssClass="txtsize1dateum" DisplayFormatString="HH:mm" family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" HorizontalAlign="Center">
                                        <SpinButtons Enabled="false" ShowIncrementButtons="false">
                                        </SpinButtons>
                                    </dx:ASPxTimeEdit>
                                    <asp:Button ID="btnSendActivate" runat="server" Text="<%$ Resources:localizedText, sendandlogincalender %>" CssClass="btndataum" Style="margin-top: 2px;" />
                                </section>
                                    <section class="areaeight" style="height: 12%;"> 
                                    <asp:Button ID="btnVisitorBookOut" runat="server" Text="Besucher ausbuchen" CssClass="btndataum" Style="margin-top: 2px;float:right;color:red;" />
                                </section>
                                <section class="areaeight" style="display: none">
                                    <asp:Label ID="Label14" runat="server" Text="<%$ Resources:localizedText, autolock %>" CssClass="lblautomatic fontweight600" Style="line-height: 14px;"></asp:Label>
                                    <asp:Label ID="Label28" runat="server" Text="<%$ Resources:localizedText, date %>" CssClass="datearea fontweight600"></asp:Label>
                                    <dx:ASPxDateEdit ID="drpVisitAutoDate" ClientInstanceName="drpVisitAutoDate" runat="server" Theme="Office2003Blue" CssClass="dtpckrnew" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" EnableTheming="true" Font-Size="14px" HorizontalAlign="Center">
                                    </dx:ASPxDateEdit>
                                    <asp:Label ID="Label29" runat="server" Text="<%$ Resources:localizedText, timeOfDay %>" CssClass="lblShotr fontweight600"></asp:Label>
                                    <dx:ASPxTimeEdit ID="drpVisitAutoDateTime" ClientInstanceName="drpVisitAutoDateTime" ClientIDMode="Static" runat="server" CssClass="txtsize1date" DisplayFormatString="HH:mm" family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" HorizontalAlign="Center">
                                        <SpinButtons Enabled="false" ShowIncrementButtons="false">
                                        </SpinButtons>
                                    </dx:ASPxTimeEdit>
                                </section>
                                <section class="areaeight" style="display: none;">
                                    <asp:Label ID="Label36" runat="server" Text="<%$ Resources:localizedText, autolock %>" CssClass="lblautomaticnew2 fontweight600" Style="line-height: 14px;"></asp:Label>
                                    <asp:Label ID="Label34" runat="server" Text="<%$ Resources:localizedText, afterstd %>" CssClass="datearea fontweight600" Style="margin-top: -2px;"></asp:Label>
                                    <asp:TextBox ID="txtSTDTime" runat="server" CssClass="txtsize1" Style="margin-top: -2px;"></asp:TextBox>
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
                        <%--                     <asp:Button ID="btnBackNew" CssClass="backbtn " runat="server" Text="<%$ Resources:localizedText, backButton %>" ClientIDMode="Static"/>--%>

                        <div id="rightdivgrid" class="rightdivgrid" style="display: none;">
                            <section class="gridHolderSec">
                                <dx:ASPxGridView ID="grdVisitorDescription" ClientInstanceName="grdVisitorDescription" runat="server" AutoGenerateColumns="False" Width="100%" Theme="Office2003Blue" EnablePagingGestures="False" KeyFieldName="ID" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif"
                                    Font-Size="14px" EnableCallBacks="False">
                                    <ClientSideEvents RowDblClick="function(s, e) {
	 grdVisitorDataDblClick(s, e)
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Width="20%" Caption="<%$ Resources:localizedText, visitorPlannumber %>" VisibleIndex="1" FieldName="VisitorPlanNr">
                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Width="68%" Caption="<%$ Resources:localizedText, visitorPlandescr %>" VisibleIndex="2" FieldName="VisitorPlanDescription"></dx:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsBehavior AllowFocusedRow="True" AllowSort="False" AllowDragDrop="false" />
                                    <SettingsPager Visible="False" PageSize="28" ShowEmptyDataRows="True">
                                    </SettingsPager>
                                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />

                                </dx:ASPxGridView>
                            </section>
                            <section class="buttonHolderSec">
                                <asp:Button ID="btnAcceptAccessPlan" runat="server" Text="<%$ Resources:localizedText, applyrecord %>" CssClass="btnAcceptPlan" />
                            </section>

                        </div>

                        <div id="rightdivtransponder" class="rightdivtransponder" style="display: none;">
                            <dx:ASPxGridView ID="grdTransponder" runat="server" AutoGenerateColumns="False" Width="100%" Theme="Office2003Blue" EnablePagingGestures="False" KeyFieldName="ID" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif"
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
                    <div class="searchVehicletype" id="vehicletype" style="display: none; border-top: none;">

                        <section class="secLeftTopcartypenew">
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

                        <div class="secholder" style="width: 95%; height: 85%;">
                            <section class="left" style="margin-left: 14%;">
                                <asp:Label ID="Label112" runat="server" Text="<%$ Resources:localizedText, manufacturertable %>" CssClass="herslabel"></asp:Label>
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
                                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, manufacturer %>" VisibleIndex="1" FieldName="Name">
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
                                    <dx:ASPxGridView ID="grdVehicleModel" ClientInstanceName="grdVehicleModel" OnCustomCallback="grdVehicleModel_CustomCallback" KeyFieldName="ID" runat="server" AutoGenerateColumns="False" Width="86%" CssClass="gridright">
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
                                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, newvehicletype %>" VisibleIndex="1" FieldName="Type">
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
                                <asp:Button ID="btnApplyVehicleType" runat="server" CssClass="editbtnfooterorange" Text="<%$ Resources:localizedText, takeover %>" Style="float: right; clear: both; width: 88px; margin-right: 0px; height: 15px;" />
                            </section>



                        </div>



                        <div style="display: none;">
                            <div id="visitorcartype" class="Controlvisitorcartype">
                                <section class="secSelectiontop1cartype">
                                    <asp:Label ID="Label49" runat="server" Text="PKW" CssClass="lblTitlenew"></asp:Label>

                                </section>
                                <section class="secSelectiontop1cartype">
                                    <section class="txtSearchVisitorareascartype" style="margin-left: 5px;">
                                        <asp:Label ID="Label101" runat="server" Text="<%$ Resources:localizedText, manufacturer %>" CssClass="lblnamecar"></asp:Label>
                                        <%--  <dx:ASPxComboBox ID="cboVehicleTypes" runat="server" ValueType="System.String" ValueField="ID" OnCallback="cboVehicleTypes_Callback" EnableCallbackMode="true"  TextField="Name" ClientIDMode="Static" CssClass="drpallcar" DropDownRows="20" Theme="Office2003Blue" DropDownWidth="300px" Font-Size="14px" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important">
                                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	 cboVehicleTypesSelectedIndexChanged(s, e)
}"
                                            EndCallback="function(s, e) {
	cboVehicleTypesEndCallback(s,e)
}"></ClientSideEvents>
                                        <Columns>
                                            <dx:ListBoxColumn FieldName="Name" Name="Name" Width="100%" Caption="Hersteller" />
                                        </Columns>
                                    </dx:ASPxComboBox>--%>
                                    </section>


                                </section>
                            </div>

                            <div class="Wrappernew3" style="border: none;">

                                <div id="GridIdNr" class="gridIdNr">

                                    <dx:ASPxGridView ID="grdVehicles" ClientInstanceName="grdVehicles" ClientIDMode="Static" runat="server" AutoGenerateColumns="False" Width="100%" Theme="Office2003Blue" OnCustomCallback="grdVehicles_CustomCallback" EnableCallBacks="true" OnBatchUpdate="grdVehicles_BatchUpdate" KeyFieldName="ID" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="14px" SettingsEditing-Mode="Batch">

                                        <ClientSideEvents RowClick="function(s, e) {
	grdVehicleTypesClick(s,e)
}"></ClientSideEvents>
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="False" VisibleIndex="0">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, manufacturer1 %>" FieldName="Name" VisibleIndex="1" Width="50%">
                                                <EditFormSettings Visible="false" />
                                                <DataItemTemplate>
                                                    <%-- <dx:ASPxLabel runat="server" Text='<%# Convert.ToString(Eval("Name")) %>' Visible='<%# Convert.ToBoolean(Eval("showName")) %>'  font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="14px"/>--%>
                                                </DataItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                            <%--       <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, typevehicle1 %>" FieldName="Type" VisibleIndex="2" Visible="false">
                            </dx:GridViewDataTextColumn>--%>
                                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, typevehicle1 %>" FieldName="Type" VisibleIndex="2" Width="50%">
                                                <PropertiesTextEdit>
                                                    <ClientSideEvents TextChanged="function(s, e) {
	
	//grdVehicleTypesFillCell(s, e);
	
}"></ClientSideEvents>
                                                </PropertiesTextEdit>
                                                <PropertiesTextEdit>
                                                    <ClientSideEvents
                                                        LostFocus="" />
                                                </PropertiesTextEdit>


                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="false" />
                                        <SettingsPager PageSize="24" ShowEmptyDataRows="True" Visible="False">
                                        </SettingsPager>
                                        <SettingsDataSecurity AllowDelete="False" AllowEdit="true" AllowInsert="true" />
                                        <SettingsBehavior AllowDragDrop="False" AllowFocusedRow="True" AllowGroup="false" AllowSelectSingleRowOnly="true" AllowSort="False" AllowSelectByRowClick="true" />
                                        <SettingsPager ShowEmptyDataRows="true" Visible="False" PageSize="17"></SettingsPager>
                                        <SettingsEditing EditFormColumnCount="17" Mode="Batch" NewItemRowPosition="Bottom">
                                            <BatchEditSettings EditMode="Cell" StartEditAction="DblClick" ShowConfirmOnLosingChanges="False" />
                                        </SettingsEditing>
                                        <Settings ShowStatusBar="Hidden" />
                                    </dx:ASPxGridView>




                                </div>

                                <div id="Grid3" class="Grid2">
                                    <section style="display: none">
                                        <asp:DropDownList ID="DropDownList3" runat="server" Visible="true" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" AutoPostBack="true" DataTextField="Name" DataValueField="ID">
                                        </asp:DropDownList>
                                    </section>
                                    <section id="fvSec3" style="width: 100%; height: 100%">

                                        <section style="width: 49%; height: 100%; float: left; border-right: 1px solid grey;">
                                            <asp:Label ID="lblmanufacture" runat="server" Text="<%$ Resources:localizedText,manufacturer12 %>" CssClass="lblptype" Style="float: left; width: 100%; height: 40%"></asp:Label>
                                            <asp:TextBox ID="txtvehicleType" runat="server" Enabled="true" CssClass="txtptypenew" Width="96%" Text='<%# Bind("Name") %>'></asp:TextBox>
                                            <%--      <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" ValueType="System.String" CssClass="txtptypenew" Theme="Office2003Blue" Style="float: left; width: 96%; height: 40%"></dx:ASPxComboBox>--%>
                                        </section>
                                        <section style="float: left; width: 50%; height: 100%">

                                            <asp:Label ID="lblCartype" runat="server" Text="<%$ Resources:localizedText,typevehicle1 %>" CssClass="lblptype" Style="float: left; width: 100%; height: 40%"></asp:Label>

                                            <asp:TextBox ID="txtvehicleModel" runat="server" Enabled="true" CssClass="txtpmemo" Text='<%# Bind("Type") %>' Style="float: left; width: 96%; height: 40%; margin-left: 2%;"></asp:TextBox>
                                        </section>
                                    </section>
                                </div>


                            </div>
                            <section class="buttonHolderSecnew">
                                <asp:Button ID="btnTakeOver" ClientIDMode="Static" CssClass="BottomFooterBtnsRight btnAcceptCompany" runat="server" Text="<%$ Resources:localizedText, applyrecord %>" />
                            </section>
                            <section class="ActionBtnsBottom">
                                <%--                            <asp:Button ID="Button24" CssClass="GridFooterBtnsLeft btnnew2" runat="server" Text="<%$ Resources:localizedText, newrecord %>" />
                            <asp:Button ID="Button25" CssClass="GridFooterBtnsLeft btnEdit" runat="server" Text="<%$ Resources:localizedText, editing %>" Style="display: none" />
                            <asp:Button ID="Button26" CssClass="GridFooterBtnsLeft btnSavenew" runat="server" Text="<%$ Resources:localizedText, savedata %>" />
                            <asp:Button ID="Button27" CssClass="GridFooterBtnsLeft btnAuswesDelete" runat="server" Text="<%$ Resources:localizedText, deleterecord %>" />
                            <asp:Button ID="btnBackCarType" CssClass="BottomFooterBtnsRight btnClosenew" runat="server" Text="<%$ Resources:localizedText, applyrecord %>" />--%>
                            </section>
                        </div>

                    </div>
                    <div class="searchclint" id="client" style="display: none;">
                        <div class="Wrappernew3">
                            <div id="GrdIdNr" class="gridIdNr">
                                <%-- <dx:ASPxGridView ID="grdClients" ClientInstanceName="grdClients" runat="server" KeyFieldName="ID" ClientIDMode="Static" CellPadding="4" ForeColor="#333333" Width="100%" GridLines="Both" Theme="Office2003Blue" OnCustomCallback="grdClients_CustomCallback" AutoGenerateColumns="False" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="14px">
                                    <ClientSideEvents RowClick="function(s, e) {
	grdvwgrdClientsRowClick(s, e)
}"
                                        RowDblClick="function(s, e) {
 grdClientsRowDBClick(s,e);
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="Firma Mandant ID:" VisibleIndex="1" FieldName="Client_Nr" Width="15%">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Name:" VisibleIndex="2" FieldName="Name" Width="85%">
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
                                        <asp:Label ID="Label74" runat="server" Text="<%$ Resources:localizedText, companynonew %>" CssClass="lblclient"></asp:Label>
                                        <asp:TextBox ID="txtClientNr" runat="server" Enabled="true" CssClass="txtpclientdesc" Text='<%# Bind("Name") %>'></asp:TextBox>
                                    </section>
                                    <section>
                                        <asp:Label ID="Label75" runat="server" Text="<%$ Resources:localizedText, companynew %>" CssClass="lblptype"></asp:Label>
                                        <asp:TextBox ID="txtClientName" runat="server" Enabled="true" CssClass="txtpmemo" Text='<%# Bind("Type") %>'></asp:TextBox>
                                    </section>
                                </section>
                            </div>

                            <section class="ActionBtnsBottom">
                                <asp:Button ID="btnNew" CssClass="GridFooterBtnsLeft btnNew" runat="server" Text="<%$ Resources:localizedText, newButton %>" />
                                <%--  <asp:Button ID="Button17" CssClass="GridFooterBtnsLeft btnEdit" runat="server" Text="<%$ Resources:localizedText, editing %>" /> --%>
                                <asp:Button ID="btnSave" CssClass="GridFooterBtnsLeft btnSave" runat="server" Text="<%$ Resources:localizedText, saveButton %>" />
                                <asp:Button ID="btnDelete" CssClass="GridFooterBtnsLeft btnLöschen" runat="server" Text="<%$ Resources:localizedText, deleteButton %>" />
                                <asp:Button ID="btnCompanyBack" CssClass="BottomFooterBtnsRight btnClose" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
                            </section>
                        </div>

                    </div>
                    <div class="ControlSectionnewclient" style="display: none">
                        <%--<asp:Label ID="Label111" runat="server" Text="<%$ Resources:localizedText, creatingvisitorcompany %>" CssClass="visitorlonig"></asp:Label>--%>
                        <section class="left1">
                        <asp:Label ID="Label111" runat="server" Text="<%$ Resources:localizedText, companyno %>" CssClass="lblcomp"></asp:Label>
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
<asp:Label ID="Label113" runat="server" Text="Firmen Name:" CssClass="lblcomp1"></asp:Label>
                         <dx:ASPxComboBox ID="cobCompanyName" ClientInstanceName="cobCompanyName" ValueField="ID" style="width: 344px;" TextField="CompanyName" runat="server" EnableCallbackMode="true" OnCallback="cobCompanyName_Callback" ValueType="System.String" CssClass="ctextbx1" Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextFormatString="{1}" DropDownRows="20" DropDownWidth="400px">
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
                <asp:ImageButton ID="ImageButton1" runat="server" CssClass="buttonbesnew" Style="background-size: cover; display:none;"  />
            </section>
                    </div>
                    <div class="searchclintnewclint" style="display: none;">

                        <section class="btmsecLeftMid">
                            <section class="innersec">
                                <section class="upperbtmsecLeftMid">
                                    <section class="secdiv">
                                        <section class="secdivleft">
                                            <asp:Label ID="lblloc" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, companyno %>"></asp:Label>
                                            <asp:TextBox ID="txtCompanyNr" runat="server" CssClass="txtsec2"></asp:TextBox>
                                        </section>
                                        <section class="secdivright">
                                            <asp:Label ID="lblCustomerData" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, company %>"></asp:Label>
                                            <asp:TextBox ID="txtCompanyName" runat="server" CssClass="txtsec" style="width: 345px;"></asp:TextBox>
                                        </section>
                                    </section>
                                    <section class="secdiv">
                                        <section class="secdivleft">
                                            <asp:Label ID="lblPlz" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, plz %>"></asp:Label>
                                            <asp:TextBox ID="txtCompanyZipCode" runat="server" CssClass="txtsec2"></asp:TextBox>
                                        </section>
                                        <section class="secdivright">
                                            <asp:Label ID="lblOrt" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, placeTitle %>"></asp:Label>
                                            <asp:TextBox ID="txtCompanyPlace" runat="server" CssClass="txtsec" Style="width:345px;"></asp:TextBox>
                                        </section>
                                    </section>
                                    <section class="secdiv">
                                        <section class="secdivleft">
                                            <asp:Label ID="Label110" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, street2 %>"></asp:Label>
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
                                            <dx:ASPxComboBox ID="cboCompanyState" CssClass="bunddlist" Theme="Aqua" runat="server" ValueField="ID" TextField="StateName"
                                                SelectedIndex="0" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" DropDownWidth="300px" style="width: 245px;" ValueType="System.String">
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
                                            <asp:TextBox ID="txtCompanyMemo" CssClass="txtMemo" runat="server" Rows="5"  TextMode="MultiLine"></asp:TextBox>
                                        </section>
                                    </section>
                                </section>
                            </section>

                        </section>

                    </div>

                    <section class="searchclintnewclintnewest">
                      <asp:Button ID="btnApplyVisitorCompany" runat="server" Text="<%$ Resources:localizedText, accept %>" CssClass="btnApplyCompany" Style="float:left; display:none;" />
                    </section>

                    <section class="serchClintfilter" style="display: none; ">
                        <div id="BottomHeaderLabelsclints" style="margin-left:21% "display: none;">
<%--<asp:Label ID="Label1072" runat="server" Text="<%$ Resources:localizedText, companyClient %>" CssClass="L1HeaderT1drplablesclint" ></asp:Label>
                            <asp:Label ID="Label1082" runat="server" Text="<%$ Resources:localizedText, plz %>" CssClass="lblPlz2new" ></asp:Label>
                            <asp:Label ID="Label109" runat="server" Text="<%$ Resources:localizedText, place2 %>" CssClass="L1HeaderT1drplablesplace_new" ></asp:Label>--%>
                        </div> 
                        <div id="BottomHeaderListsclints" style="margin-left:26%; margin-top:20px;"  >

                               <asp:Label ID="Label135" runat="server" Text="<%$ Resources:localizedText, companyno %>" CssClass="lblcompnow"></asp:Label>
                          <%--  <dx:ASPxComboBox ID="ASPxComboBox3" runat="server" ValueType="System.String" CssClass="ctextbxnew" Theme="Office2003Blue"></dx:ASPxComboBox>--%>
                       
                            <dx:ASPxComboBox ID="cobVisitorCompanyNr" ClientInstanceName="cobVisitorCompanyNr" runat="server" ValueField="ID" TextField="CompanyNr" EnableCallbackMode="true" OnCallback="cobVisitorCompanyNr_Callback" ValueType="System.String" TextFormatString="{0}" CssClass="ctextbxnew" Theme="Office2003Blue" CallbackPageSize="100000" DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                 <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cboVisitorCompanySelectedChanged(s,e);
}"></ClientSideEvents>
                                 <Columns>
                          <dx:ListBoxColumn Caption="Nr:" Name="CompanyNr" FieldName="CompanyNr" Width="15%" />
                          <dx:ListBoxColumn Caption="Firmen Name:" Name="CompanyName" FieldName="CompanyName" Width="85%" />
                      </Columns>
                            </dx:ASPxComboBox>
                             <asp:Label ID="Label114" runat="server" Text="<%$ Resources:localizedText, companyClient %>" CssClass="lbcompanyt" ></asp:Label>
                            <dx:ASPxComboBox ID="cboVisitorCompany" ClientInstanceName="cboVisitorCompany" runat="server" CssClass="L1HeaderT1drplists_clint" ValueField="ID" TextField="CompanyName"  TextFormatString="{1}" EnableCallbackMode="true" OnCallback="cboVisitorCompany_Callback" CallbackPageSize="100000" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cboVisitorCompanySelectedChanged(s,e);
}"></ClientSideEvents>
                                 <Columns>
                          <dx:ListBoxColumn Caption="Nr:" Name="CompanyNr" FieldName="CompanyNr" Width="15%" />
                          <dx:ListBoxColumn Caption="Firmen Name:" Name="CompanyName" FieldName="CompanyName" Width="85%" />
                      </Columns>
                            </dx:ASPxComboBox>
                            <dx:ASPxComboBox ID="cboVisitorPostalCode" ClientInstanceName="cboVisitorPostalCode" runat="server" CssClass="L1HeaderT1drplistsplz_desc" SelectedIndex="0" ValueField="ID" TextField="ZipCode" EnableCallbackMode="true" OnCallback="cboVisitorPostalCode_Callback" CallbackPageSize="100000" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="100px">

                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cboVisitorPostalCodeSelectionChaged(s,e);
}"></ClientSideEvents>

                            </dx:ASPxComboBox>
                            <dx:ASPxComboBox ID="cboVisitorLocation" ClientInstanceName="cboVisitorLocation" runat="server" CssClass="L1HeaderT1drplists_clintnew" SelectedIndex="0" ValueField="ID" TextField="Place" EnableCallbackMode="true" OnCallback="cboVisitorLocation_Callback" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px">

                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cboVisitorLocationSelectionChanged(s,e);
}"></ClientSideEvents>
                            </dx:ASPxComboBox>

                        </div> 
                    </section>
                    <div class="Visitorclient" style="display: none;  border: none;">
                        <section class="gridHolderSec">
                            <dx:ASPxGridView ID="grdVisitorCompany" ClientInstanceName="grdVisitorCompany" KeyFieldName="ID" OnCustomCallback="grdVisitorCompany_CustomCallback" CallbackPageSize="100000" SettingsBehavior-AllowSort="false" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True">
                                <ClientSideEvents RowDblClick="function(s, e) {
	grdVisitorCompanyDblClick(s, e)
}"
                                    RowClick="function(s, e) {
 grdVisitorCompanyRowClick(s, e);	
}" />
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="false" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="3%" HeaderStyle-HorizontalAlign="left" Caption="<%$ Resources:localizedText, no2 %>" VisibleIndex="1" HeaderStyle-BackColor="#fff2c8" FieldName="CompanyNr">
                                        <CellStyle HorizontalAlign="left"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="17%" Caption="<%$ Resources:localizedText, companyClient %>" VisibleIndex="2" HeaderStyle-BackColor="#fff2c8" FieldName="CompanyName"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="4%" Caption="<%$ Resources:localizedText, plz %>" VisibleIndex="3" HeaderStyle-HorizontalAlign="left" HeaderStyle-BackColor="#fff2c8" FieldName="ZipCode">
                                        <CellStyle HorizontalAlign="left"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="8%" Caption="<%$ Resources:localizedText, place2 %>" VisibleIndex="4" HeaderStyle-BackColor="#fff2c8" FieldName="Place"></dx:GridViewDataTextColumn>
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
                        <section class="buttonHolderSec">
                            
        
                        </section>
                    </div>

                   <%-- <section class="btmsecLeftMidcreatenew" style="display: none">
                        <asp:Button ID="btnNewCompany" CssClass="BottomFooterBtnsLeftnew_vis " runat="server" style="display: none" Text="<%$ Resources:localizedText, newCompany %>" />
                        <asp:Button ID="btnSaveCompany" ClientIDMode="Static" CssClass="BottomFooterBtnsLeftsave " runat="server" style="display: none" Text="<%$ Resources:localizedText, saveVisitorCompany %>" />
                        <asp:Button ID="btnDeleteCompany" ClientIDMode="Static" Style="display: none;" CssClass="BottomFooterBtnsLeftdelete " runat="server" Text="<%$ Resources:localizedText, deleteButton %>" />

                        <asp:Button ID="btnBackCompany" ClientIDMode="Static" CssClass="BottomFooterBackCompany " runat="server" Text="<%$ Resources:localizedText, backButton %>" Style="display:none;" />

                    </section>--%>
                    <div class="searchVisitors" style="display: none;">
                        <dx:ASPxGridView ID="grdSearchVisitors" SettingsBehavior-AllowSort="false" ClientInstanceName="grdSearchVisitors" runat="server" Width="100%" AutoGenerateColumns="False" Theme="Office2003Blue" EnableTheming="True" KeyFieldName="ID">
                            <ClientSideEvents RowDblClick="function(s, e) {
	grdSearchVisitorsDblClick(s, e)
}"></ClientSideEvents>
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="false" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Width="4%" Caption="<%$ Resources:localizedText, visitorsId %>" VisibleIndex="1" FieldName="VisitorID"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Width="11%" Caption="Vorname" VisibleIndex="2" FieldName="SurName"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Width="11%" Caption="Nachname" VisibleIndex="3" FieldName="OtherName"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Width="15%" Caption="<%$ Resources:localizedText, company1 %>" VisibleIndex="4" FieldName="Company"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Width="10%" Caption="Straße" VisibleIndex="3" FieldName="Street"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Width="5%" Caption="Postleitzahl" VisibleIndex="6" FieldName="PostalCode"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Width="10%" Caption="Ort" VisibleIndex="7" FieldName="Location"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Width="10%" Caption="Telefon" VisibleIndex="7" FieldName="Telephone"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Width="10%" Caption="Handy" VisibleIndex="8" FieldName="Mobile"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Width="15%" Caption="E-mail" VisibleIndex="9" FieldName="Email"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn Width="5%" Caption="Zutritt ab" VisibleIndex="10" FieldName="vStartDate"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn Width="5%" Caption="Zutritt bis" VisibleIndex="11" FieldName="vEndDate"></dx:GridViewDataDateColumn>
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
                    <section class="clientholderarea" style="display: none; border: none; border-top: none; padding-top: 0px;">   
                        <section class="serchClintnewarea" style="margin-top: 0px;">
                            <div id="BottomHeaderLabelsclints1">
                               <%-- <asp:Label ID="Label104" runat="server" Text="Mandant:" CssClass="L1HeaderT1drplablesclint" Style="color: white"></asp:Label>--%>
                          <%--      <asp:Label ID="Label105" runat="server" Text="PLZ:" CssClass="lblPlz2new" Style="color: white"></asp:Label>
                                <asp:Label ID="Label106" runat="server" Text="<%$ Resources:localizedText, place2 %>" CssClass="L1HeaderT1drplablesplace_new" Style="color: white"></asp:Label>
                          --%>  </div>

                            <div id="BottomHeaderListsclints2" style="margin-top:25px; margin-left:26%;">
                                  <asp:Label ID="Label105" runat="server" Text="Mandant Nr.:" CssClass="lblcomp2"></asp:Label>
                            <dx:ASPxComboBox ID="ASPxComboBox4" runat="server" ValueType="System.String" CssClass="ctextbxnext" Theme="Office2003Blue"></dx:ASPxComboBox>









                                 <asp:Label ID="Label104" runat="server" Text="Mandant:" CssClass="L1HeaderT1drplablesclintnew1" Style="color: black"></asp:Label>
                                <dx:ASPxComboBox ID="cboClientName" ClientInstanceName="cboClientName" runat="server" CssClass="L1HeaderT1drplists_clint" ValueField="ID" TextField="Name" SelectedIndex="0" TextFormatString="{0}" EnableCallbackMode="true" OnCallback="cboClientName_Callback" CallbackPageSize="100000" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px">
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="Name" Name="Name" ToolTip="Name" Width="100%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                                <dx:ASPxComboBox ID="cboClentZipCode" ClientInstanceName="cboClentZipCode" runat="server" CssClass="L1HeaderT1drplistsplz_desc" SelectedIndex="0" ValueField="ID" TextField="ZipCode" EnableCallbackMode="true" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="100px">
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="Plz" Name="Plz" ToolTip="Plz" Width="100%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                                <dx:ASPxComboBox ID="cboClientPlace" ClientInstanceName="cboClientPlace" runat="server" CssClass="L1HeaderT1drplists_clintnew" SelectedIndex="0" ValueField="ID" TextField="Ort" EnableCallbackMode="true" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px">
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="Ort" Name="Ort" ToolTip="Ort" Width="100%" />
                                    </Columns>
                                </dx:ASPxComboBox>

                            </div>
                        </section>                 
                        <div class="clientholderarea2" >
                        
                        <div class="clientholderareagrid" style="height: 89%;">


                            <dx:ASPxGridView ID="grdClients" ClientInstanceName="grdClients" EnableCallBacks="true" KeyFieldName="ID" SettingsBehavior-AllowSort="false" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True">
                                <ClientSideEvents RowClick="function(s, e) {
	grdClientsRowClick(s, e)
}"
                                    RowDblClick="function(s, e) {
 grdClientsRowDBClick(s,e);
}"></ClientSideEvents>
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="false" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="3%" HeaderStyle-HorizontalAlign="left" Caption="<%$ Resources:localizedText, no2 %>" VisibleIndex="1" HeaderStyle-BackColor="#fff2c8" FieldName="Client_Nr" >
                                        <CellStyle HorizontalAlign="left"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="17%" Caption="Mandant:" VisibleIndex="2" HeaderStyle-BackColor="#fff2c8" FieldName="Name"></dx:GridViewDataTextColumn>
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
                        </div>
                        <div class="clientholderareagridBtn">
                        
                            </div>
                    </div>

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
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, idcardnumber %>" VisibleIndex="2" Width="2%" FieldName="TransponderNr">
                                <PropertiesTextEdit>
                                    <ClientSideEvents TextChanged="function(s, e) {
	ausweisChanged(s, e, 1);
}"></ClientSideEvents>
                                </PropertiesTextEdit>
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataCheckColumn Caption="<%$ Resources:localizedText, active %>" VisibleIndex="3" Width="8%" FieldName="TransponderActive">
                                <PropertiesCheckEdit ClientInstanceName="chkActive">
                                    <ClientSideEvents CheckedChanged="function(s, e) {
	SetActive(s, e, true);
}" />
                                </PropertiesCheckEdit>
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataCheckColumn>
                            <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, activatedOn %>" VisibleIndex="4" Width="10%" FieldName="ValidFrom">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, expirydate %>" VisibleIndex="5" Width="10%" FieldName="ValidTo">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, extended %>" VisibleIndex="6" Width="10%" FieldName="ExtendedTo">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataCheckColumn Caption="<%$ Resources:localizedText, inactive_new %>" VisibleIndex="7" Width="10%" FieldName="TransponderInActive">
                                <PropertiesCheckEdit ClientInstanceName="chkInactive">
                                    <ClientSideEvents CheckedChanged="function(s, e) {
	SetActive(s, e, false);
}" />
                                </PropertiesCheckEdit>
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataCheckColumn>
                            <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, inactiveFrom %>" VisibleIndex="8" Width="10%" FieldName="TransponderDeactivatedOn">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, actions %>" VisibleIndex="9" Width="10%" FieldName="Action">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, memoTitle %>" VisibleIndex="10" Width="31%" FieldName="Memo">
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
                        <asp:Label ID="Label79" runat="server" Text="<%$ Resources:localizedText, idCards %>" CssClass="lblAuswe1new"></asp:Label>
                        <asp:Label ID="Label80" runat="server" Text="" CssClass="lblAusweActive"></asp:Label>
                        <asp:Label ID="Label81" runat="server" Text="" CssClass="lblAuswe1"></asp:Label>
                        <asp:Label ID="Label82" runat="server" Text="" CssClass="lblAuswe3"></asp:Label>
                        <asp:Label ID="Label83" runat="server" Text="" CssClass="lblAuswe3"></asp:Label>
                        <asp:Label ID="Label84" runat="server" Text="" CssClass="lblAuswe3"></asp:Label>
                        <asp:Label ID="Label85" runat="server" Text="<%$ Resources:localizedText, actions %>" CssClass="lblAuswe3"></asp:Label>
                        <asp:Label ID="Label86" runat="server" Text="" CssClass="lblAuswe3action"></asp:Label>
                        <asp:Label ID="Label87" runat="server" Text="" CssClass="lblAuswe4"></asp:Label>
                    </section>
                </section>
                <section class="Dailystatement" style="display: none; padding-top: 5%;">
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
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, idNo %>" VisibleIndex="2" Width="2%" FieldName="TransponderNr">
                                <PropertiesTextEdit>
                                    <ClientSideEvents TextChanged="function(s, e) {
	ausweisChanged(s, e, 2);
}"></ClientSideEvents>
                                </PropertiesTextEdit>
                                <HeaderStyle HorizontalAlign="left" />
                                <CellStyle HorizontalAlign="Left"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataCheckColumn Caption="<%$ Resources:localizedText, active %>" VisibleIndex="3" Width="8%" FieldName="TransponderActive">
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
                            <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, expirydate %>" VisibleIndex="5" Width="10%" FieldName="ValidTo">
                                <HeaderStyle HorizontalAlign="Center" />
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
                        <asp:Label ID="Label88" runat="server" Text="" CssClass="lblAusweselect"></asp:Label>
                        <asp:Label ID="Label89" runat="server" Text="<%$ Resources:localizedText, idCards %>" CssClass="lblAuswe1new"></asp:Label>
                        <asp:Label ID="Label90" runat="server" Text="" CssClass="lblAuswe1newselect"></asp:Label>
                        <asp:Label ID="Label91" runat="server" Text="" CssClass="lblAuswe1select"></asp:Label>
                        <asp:Label ID="Label92" runat="server" Text="" CssClass="lblAuswe3new"></asp:Label>
                    </section>
                </section>
                <asp:ObjectDataSource ID="odsfvVisitors" runat="server" DataObjectTypeName="KruAll.Core.Models.Visitor" DeleteMethod="DeleteVisitor" InsertMethod="NewVisitor" SelectMethod="GetVisitorById" TypeName="KruAll.Core.Repositories.VisitorRepository" UpdateMethod="EditVisitor">
                    <SelectParameters>
                    </SelectParameters>
                </asp:ObjectDataSource>

                <asp:ObjectDataSource ID="odsfvVisitorApplications" runat="server" DataObjectTypeName="Access_Control.Dtos.VisitorApplicationDto" InsertMethod="CreateVisitorApplication" SelectMethod="GetVisitorApplicationById" TypeName="Access_Control.ViewModels.VisitorApplicationViewModel" UpdateMethod="UpdateVisitorApplication" DeleteMethod="DeleteVisitorApplication">
                    <%--<SelectParameters>
                <asp:ControlParameter ControlID="ddlPersonalName" PropertyName="SelectedValue" DefaultValue="0" Name="visitorApplicationID" Type="Int64" ConvertEmptyStringToNull="true"></asp:ControlParameter>
            </SelectParameters>--%>
                </asp:ObjectDataSource>

                <asp:ObjectDataSource ID="odsddlVisitors" runat="server" DataObjectTypeName="KruAll.Core.Models.Visitor" DeleteMethod="DeleteVisitor" InsertMethod="NewVisitor" SelectMethod="GetAllVisitors2" TypeName="KruAll.Core.Repositories.VisitorRepository" UpdateMethod="EditVisitor"></asp:ObjectDataSource>
                <div id="importantDialog" class="dialogBox"></div> 
            </div>
        </div>
        <div id="ControlSection1" class="ControlSection" style="display: none;">
            <div id="AEHeaderLeftDiv">
                <%--   <section class="topsec">
                <asp:Label ID="lbldroptxt" runat="server" Text="" CssClass="L1HeaderT1drplablesdesc" Style="font-weight: 600;"></asp:Label>
            </section>--%>
                <section class="topsecbtm">
                    <div id="BottomHeaderLabels">
                        <%-- <asp:Label ID="Label49" runat="server" Text=" Nr.:" CssClass="L1HeaderT1drplablesnr"></asp:Label>--%>
                        <asp:Label ID="Label50" runat="server" Text="<%$ Resources:localizedText ,companyClient%>" CssClass="L1HeaderT1drplablesdesc"></asp:Label>
                        <asp:Label ID="Label70" runat="server" Text="<%$ Resources:localizedText ,postcode%>" CssClass="L1HeaderT1drplables" ></asp:Label>
                        <asp:Label ID="lblCostCenterHeader" runat="server" Text="<%$ Resources:localizedText ,loc%>" CssClass="L1HeaderT1drplablesplace3"></asp:Label>
                        <asp:Label ID="lblEmployeeName" runat="server" Text="<%$ Resources:localizedText ,visitorID%>" CssClass="L1HeaderT1drplables2" ></asp:Label>
                        <asp:Label ID="lblPersNo" runat="server" Text="<%$ Resources:localizedText ,name%>" CssClass="L1HeaderT1drplablesid"></asp:Label>
                        <%--<asp:Label ID="lblLocationHeader" runat="server" Text="Datum von:" CssClass="L1HeaderT1drplables"></asp:Label>--%>
                        <%--<asp:Label ID="Label101" runat="server" Text=" bis:" CssClass="L1HeaderT1drplables"></asp:Label>--%>
                        <asp:Label ID="Label103" runat="server" Text="<%$ Resources:localizedText ,fulltextsearch%>" CssClass="L1HeaderT1drplablesvolltext"></asp:Label>
                        <asp:Label ID="Label102" runat="server" Text="<%$ Resources:localizedText ,allvisitors%>" CssClass="L1HeaderT1drplablesall"></asp:Label>
                   </div> 
                    <div id="BottomHeaderListsOld" style="display: none">
                        <asp:DropDownList ID="ddlTopCompanyNrorig" runat="server" CssClass="L1HeaderT1drplistsclientNr" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" DataTextField="Nr" DataValueField="ID" AutoPostBack="true" Style="display: none"></asp:DropDownList>

                        <%--<dx:ASPxComboBox ID="ddlTopCompanyNr" ClientInstanceName="ddlTopCompanyNr" runat="server" ClientIDMode="Static" ValueField="ID" TextField="Nr"
                                    TextFormatString="{0}" CssClass="L1HeaderT1drplistsclientNr" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" HorizontalAlign="Left">
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="Nr" Name="ProfileDescription" ToolTip="" Width="20%" Caption="Nr" />
                                        <dx:ListBoxColumn FieldName="Name" Name="ID" ToolTip="Bezeichnung:" Width="80%" />
                                    </Columns>
                                </dx:ASPxComboBox>--%>
                        <asp:DropDownList ID="ddlTopCompanyDescorig" runat="server" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" DataTextField="Name" DataValueField="ID" AutoPostBack="false" Style="display: none"></asp:DropDownList>
                        <dx:ASPxComboBox ID="ddlTopCompanyDesc" ClientInstanceName="ddlTopCompanyDesc" runat="server" ValueField="ID" TextField="Name" AutoPostBack="false"
                            TextFormatString="{0}-{1}" CssClass="L1HeaderT1drplists" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" HorizontalAlign="Left">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlTopCompanyDescSelectedIndexChanged(s, e) 
}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn FieldName="Nr" Name="ID" ToolTip="" Width="20%" Caption="Nr" />
                                <dx:ListBoxColumn FieldName="Name" Name="ProfileDescription" ToolTip="Bezeichnung:" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:DropDownList ID="ddlVisitorNameorig" runat="server" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" DataTextField="Name" DataValueField="ID" AutoPostBack="true" Style="display: none"></asp:DropDownList>
                        <dx:ASPxComboBox ID="ddlpostalcode" ClientInstanceName="ddlpostalcode" runat="server" ValueField="ID" TextField="PostalCode"
                            TextFormatString="{0}" CssClass="L1HeaderT1drplistsclientNr" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" HorizontalAlign="left">

                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlpostalcodeSelectedIndexChanged(s, e)
}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn FieldName="PostalCode" Name="PostalCode" ToolTip="" Width="20%" Caption="Nr" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:DropDownList ID="ddlVisitorIDorig" runat="server" CssClass="L1HeaderT1drplistsclientNr" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" Style="width: 13%; display: none" DataTextField="VisitorID" DataValueField="ID" AutoPostBack="true"></asp:DropDownList>
                        <dx:ASPxComboBox ID="ddlLocation" ClientInstanceName="ddlLocation" runat="server" ValueField="ID" TextField="Location"
                            TextFormatString="{0}" CssClass="L1HeaderT1drplistsclientNr" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" HorizontalAlign="Left" Style="width: 13%;">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlLocationSelectedIndexChanged(s, e)
}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn FieldName="Location" Name="Location" ToolTip="" Width="50%" Caption="Nr" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:DropDownList ID="ddlCompanyorig" runat="server" CssClass="L1HeaderT1drplistsclientNr" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" DataTextField="Company" DataValueField="ID" AutoPostBack="true" Style="display: none"></asp:DropDownList>
                        <dx:ASPxComboBox ID="ddlVisitorID" ClientInstanceName="ddlVisitorID" runat="server" ValueField="ID" TextField="VisitorID"
                            TextFormatString="{0}" CssClass="L1HeaderT1drplistsclientNr" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" HorizontalAlign="left">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlVisitorIDSelectedIndexChanged(s, e)
}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn FieldName="VisitorID" Name="ID" ToolTip="Bezeichnung:" Width="20%" />
                                <dx:ListBoxColumn FieldName="Name" Name="Name" ToolTip="" Width="80%" Caption="Nr" />

                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:DropDownList ID="ddlVisitorNameorig1" runat="server" CssClass="L1HeaderT1drplists" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" DataTextField="Location" DataValueField="ID" AutoPostBack="true" Style="display: none"></asp:DropDownList>
                        <dx:ASPxComboBox ID="ddlVisitorName" ClientInstanceName="ddlVisitorName" runat="server" ValueField="ID" TextField="Name"
                            TextFormatString="{1}" CssClass="L1HeaderT1drplists" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" HorizontalAlign="Left" Style="margin-left: 6px">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlVisitorNameSelectedIndexChanged(s, e)
}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn FieldName="VisitorID" Name="VisitorID" ToolTip="" Width="20%" Caption="Nr" />
                                <dx:ListBoxColumn FieldName="Name" Name="Name" ToolTip="Bezeichnung:" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <%--    <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server" CssClass="L1HeaderT1drplistsplzdatepicker" DropDownWidth="400px" Theme="Office2003Blue" HorizontalAlign="center"></dx:ASPxDateEdit>
                    <dx:ASPxDateEdit ID="ASPxDateEdit2" runat="server" CssClass="L1HeaderT1drplistsplzdatepicker" DropDownWidth="400px" Theme="Office2003Blue" HorizontalAlign="center"></dx:ASPxDateEdit>--%>
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="txtfromtext"></asp:TextBox>
                        <asp:CheckBox ID="CheckBox1" runat="server" CssClass="chkActivationnew" Checked="true" />


                    </div>
                    <div id="BottomHeaderLists">
                        <dx:ASPxComboBox ID="ddlTopCompanyNrHistory" ClientInstanceName="ddlTopCompanyNrHistory" runat="server" CssClass="L1HeaderT1drplists" ValueField="ID" TextField="Nr" SelectedIndex="0" TextFormatString="{0}" EnableCallbackMode="true" OnCallback="ddlTopCompanyNrHistory_Callback" CallbackPageSize="100000" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlTopCompanyNrHistorySelectedChanged(s,e);
}"></ClientSideEvents>
                            <Columns>
                                <%--<dx:ListBoxColumn FieldName="Nr" Name="Nr" ToolTip="" Width="20%" />--%>
                                <dx:ListBoxColumn FieldName="Name" Name="Name" ToolTip="" Width="100%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <dx:ASPxComboBox ID="ddlPostalCodeHistory" ClientInstanceName="ddlPostalCodeHistory" runat="server" CssClass="L1HeaderT1drplistsclientNr" SelectedIndex="0" ValueField="ID" TextField="PostalCode" EnableCallbackMode="true" OnCallback="ddlPostalCodeHistory_Callback" CallbackPageSize="100000" Theme="Office2003Blue">

                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlPostalCodeHistorySelectionChaged(s,e);
}"></ClientSideEvents>
                        </dx:ASPxComboBox>
                        <dx:ASPxComboBox ID="ddlLocationHistory" ClientInstanceName="ddlLocationHistory" runat="server" CssClass="L1HeaderT1drplists" SelectedIndex="0" ValueField="ID" TextField="Location" EnableCallbackMode="true" OnCallback="ddlLocationHistory_Callback" CallbackPageSize="100000" Theme="Office2003Blue">

                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ddlLocationHistorySelectionChanged(s,e);
}"></ClientSideEvents>
                        </dx:ASPxComboBox>
                        <dx:ASPxComboBox ID="ddlVisitorIDHistory" ClientInstanceName="ddlVisitorIDHistory" runat="server" CssClass="L1HeaderT1drplistsclientNr" ValueField="ID" TextField="VisitorID" TextFormatString="{0}" EnableCallbackMode="true" OnCallback="ddlVisitorIDHistory_Callback" CallbackPageSize="100000" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px" HorizontalAlign="left">
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
                        <dx:ASPxComboBox ID="ddlVisitorNameHistory" ClientInstanceName="ddlVisitorNameHistory" runat="server" CssClass="L1HeaderT1drplists" ValueField="ID" TextField="Name" TextFormatString="{1}" EnableCallbackMode="true" OnCallback="ddlVisitorNameHistory_Callback" CallbackPageSize="100000" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px" Style="margin-left: 8px;">
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
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="txtfromtext"></asp:TextBox>
                        <asp:CheckBox ID="chkAllVisitors" runat="server" CssClass="chkActivationnew" />
                    </div>
                </section>
            </div>

            <div id="AEHeaderRightDiv">
                <asp:Button ID="btnRefresh" ClientIDMode="Static" runat="server" Text="" CssClass="refreshButton" />


            </div>

        </div>
        <div class="Visitorsapplicationnewvishis" style="display: none;">

            <div id="tabcontroldivnew2" style="height: 96%;">
                <dx:ASPxGridView ID="grdVisitorsHistory" ClientInstanceName="grdVisitorsHistory" KeyFieldName="ID" OnCustomCallback="grdVisitorsHistory_CustomCallback" EnableCallBacks="true" CallbackPageSize="100000" SettingsBehavior-AllowSort="false" runat="server" Width="100%" AutoGenerateColumns="False" Theme="Office2003Blue" EnableTheming="True">
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
                        <dx:GridViewDataTextColumn Width="11%" Caption="<%$ Resources:localizedText, companyClient %>" VisibleIndex="2" FieldName="Company"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="4%" Caption="PLZ:" VisibleIndex="3" HeaderStyle-HorizontalAlign="left" FieldName="CompanyPostalCode">
                            <CellStyle HorizontalAlign="left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="11%" Caption="<%$ Resources:localizedText, place2 %>" VisibleIndex="4" FieldName="CompanyLocation"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="11%" Caption="<%$ Resources:localizedText, street %>" VisibleIndex="5" FieldName="CompanyStreet"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="3%" Caption="<%$ Resources:localizedText, no2 %>" VisibleIndex="6" HeaderStyle-HorizontalAlign="left" Visible="false" FieldName="CompanyStreet">
                            <CellStyle HorizontalAlign="left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="4%" Caption="<%$ Resources:localizedText, visitorID %>" VisibleIndex="7" HeaderStyle-HorizontalAlign="left" CellStyle-HorizontalAlign="Left" FieldName="VisitorID"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="11%" Caption="Name:" VisibleIndex="8" FieldName="VisitorName"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="8%" Caption="<%$ Resources:localizedText, telephone %>" VisibleIndex="9" HeaderStyle-HorizontalAlign="left" FieldName="Telephone">
                            <CellStyle HorizontalAlign="left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="8%" Caption="<%$ Resources:localizedText, mobile2 %>" VisibleIndex="10" HeaderStyle-HorizontalAlign="left" FieldName="Mobile">
                            <CellStyle HorizontalAlign="left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="11%" Caption="E-mail:" VisibleIndex="11" FieldName="Email" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="5%" Caption="<%$ Resources:localizedText, accessfrom %>" VisibleIndex="12" FieldName="" HeaderStyle-HorizontalAlign="Center" Visible="false">
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="5%" Caption="<%$ Resources:localizedText, to %>" VisibleIndex="13" HeaderStyle-HorizontalAlign="Center" Visible="false">
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="5%" Caption="<%$ Resources:localizedText, timeTitle %>" VisibleIndex="14" HeaderStyle-HorizontalAlign="Center" Visible="false">
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsPager Visible="False" ShowEmptyDataRows="true" PageSize="29"></SettingsPager>
                    <SettingsBehavior AllowFocusedRow="true" AllowDragDrop="false" AllowSort="false" />
                    <SettingsDataSecurity AllowDelete="False" AllowInsert="False" AllowEdit="False"></SettingsDataSecurity>
                </dx:ASPxGridView>

            </div>
           
        </div>
        <div class="Visitorsapplication" style="display: none; margin-top: 5px; border: none;">

            <div id="tabcontroldivnew" style="height: 96%;">
                <dx:ASPxGridView ID="grdFilteredVisitors" ClientInstanceName="grdFilteredVisitors" KeyFieldName="ID" EnableCallBacks="true" OnCustomCallback="grdFilteredVisitors_CustomCallback" SettingsBehavior-AllowSort="false" runat="server" Width="100%" AutoGenerateColumns="False"  EnableTheming="false">

                    <ClientSideEvents RowDblClick="function(s, e) {
	grdFilteredVisitorsRowDbClick(s,e);
}"></ClientSideEvents>
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="false" VisibleIndex="0"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="8%" Caption="<%$ Resources:localizedText, applications2 %>" VisibleIndex="1" FieldName="PersName">
                            <CellStyle BackColor="#E4F2EC" Border-BorderColor="Gray" ForeColor="Black">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                            <HeaderStyle BackColor="#E4F2EC" Font-Bold="true" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="7%" Caption="<%$ Resources:localizedText, telephone %>" VisibleIndex="2" FieldName="PersPhoneNr">
                            <HeaderStyle BackColor="#E4F2EC" HorizontalAlign="left" ForeColor="Black" Font-Bold="true"/>
                            <CellStyle BackColor="#E4F2EC" Border-BorderColor="Gray" HorizontalAlign="left" ForeColor="Black">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="3%" Caption="<%$ Resources:localizedText, no2 %>" VisibleIndex="3" FieldName="CompanyNr" Visible="false">
                            <HeaderStyle BackColor="#FCD3CF" HorizontalAlign="left" ForeColor="Black"  Font-Bold="true"/>
                            <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" HorizontalAlign="left" ForeColor="Black">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="13%" Caption="<%$ Resources:localizedText, companyClient %>" VisibleIndex="4" FieldName="Company">
                            <HeaderStyle BackColor="#FCD3CF" ForeColor="Black"  Font-Bold="true" />
                            <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" ForeColor="Black">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="5%" Caption="<%$ Resources:localizedText, postcode %>" VisibleIndex="5" FieldName="CompanyPostalCode">
                            <HeaderStyle BackColor="#FCD3CF" HorizontalAlign="left" Font-Bold="true" />
                            <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" HorizontalAlign="left" ForeColor="Black">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="8%" Caption="<%$ Resources:localizedText, loc %>" VisibleIndex="6" FieldName="CompanyLocation">
                            <HeaderStyle BackColor="#FCD3CF" Font-Bold="true" />
                            <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" ForeColor="Black">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="7%" Caption="<%$ Resources:localizedText, road2 %>" VisibleIndex="7" FieldName="CompanyStreet">
                            <HeaderStyle BackColor="#FCD3CF" Font-Bold="true" />
                            <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" ForeColor="Black">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="3%" Caption="<%$ Resources:localizedText, no2 %>" VisibleIndex="8" FieldName="CompanyStreetNr">
                            <HeaderStyle BackColor="#FCD3CF" HorizontalAlign="left" Font-Bold="true" />
                            <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" ForeColor="Black" HorizontalAlign="Left">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="5%" Caption="<%$ Resources:localizedText, visitorID %>" VisibleIndex="9" FieldName="VisitorID">
                            <HeaderStyle BackColor="#FCD3CF" HorizontalAlign="left" Font-Bold="true" />
                            <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" HorizontalAlign="left" ForeColor="Black">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="13%" Caption="<%$ Resources:localizedText, name %>" VisibleIndex="10" FieldName="VisitorName">
                            <HeaderStyle BackColor="#FCD3CF" Font-Bold="true" />
                            <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" ForeColor="Black">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="7%" Caption="<%$ Resources:localizedText, telephone %>" VisibleIndex="11" FieldName="Telephone">
                            <HeaderStyle BackColor="#FCD3CF" HorizontalAlign="left" Font-Bold="true" />
                            <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" HorizontalAlign="left" ForeColor="Black">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="7%" Caption="<%$ Resources:localizedText, mobile2 %>" VisibleIndex="12" FieldName="Mobile">
                            <HeaderStyle BackColor="#FCD3CF" HorizontalAlign="left" Font-Bold="true" />
                            <CellStyle BackColor="#FCD3CF" Border-BorderColor="Gray" HorizontalAlign="left" ForeColor="Black">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Width="5%" Caption="<%$ Resources:localizedText, visitorsSince_new1 %>" VisibleIndex="13" FieldName="vStartDate">
                            <HeaderStyle BackColor="#FFF6DC" HorizontalAlign="Center" Font-Bold="true" />
                            <CellStyle BackColor="#FFF6DC" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataDateColumn>

                        <dx:GridViewDataTimeEditColumn Width="5%" Caption="<%$ Resources:localizedText, time_new %>" VisibleIndex="14" FieldName="vStartDate">
                            <HeaderStyle BackColor="#FFF6DC" HorizontalAlign="Center" Font-Bold="true" />
                            <CellStyle BackColor="#FFF6DC" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTimeEditColumn>

                        <dx:GridViewDataDateColumn Width="5%" Caption="<%$ Resources:localizedText, to %>" VisibleIndex="15" FieldName="vEndDate">
                            <HeaderStyle BackColor="#FFF6DC" HorizontalAlign="Center" Font-Bold="true" />
                            <CellStyle BackColor="#FFF6DC" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataDateColumn>

                        <dx:GridViewDataTimeEditColumn Width="5%" Caption="<%$ Resources:localizedText, time_new %>" VisibleIndex="16" FieldName="vEndDate">
                            <HeaderStyle BackColor="#FFF6DC" HorizontalAlign="Center" Font-Bold="true" />
                            <CellStyle BackColor="#FFF6DC" Border-BorderColor="Gray" HorizontalAlign="Center" ForeColor="Black">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTimeEditColumn>
                    </Columns>

                    <SettingsPager Visible="False" ShowEmptyDataRows="true" PageSize="29"></SettingsPager>
                    <SettingsBehavior AllowFocusedRow="true" AllowDragDrop="false" AllowSort="false" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
                    <SettingsDataSecurity AllowDelete="False" AllowInsert="False" AllowEdit="False"></SettingsDataSecurity>
                </dx:ASPxGridView>
            </div>
            

        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterLeft" runat="server">

    <asp:Button ID="btnApplyCompanyTo" CssClass="BottomFooterBtnsRight btnAcceptCompany" runat="server" Text="<%$ Resources:localizedText, applyrecord %>" Style="display:none;  float: left; margin-top:4px;" />
        <asp:Button ID="btnAcceptCompany" ClientIDMode="Static" CssClass="BottomFooterBtnsRight btnAcceptCompany" runat="server" Text="<%$ Resources:localizedText, applyrecord %>" Style="float: left;  display:none; margin-top:4px; " />                
     <asp:Button ID="btnApplyVisitorData" runat="server" CssClass="editbtnfooterorange" Text="<%$ Resources:localizedText, applyvisitordata %>" Style="float: left; clear: both; width: 176px; height: 15px; display:none; margin-top:0px;" />


    <asp:Button ID="btnApplyVisitorApplications" runat="server" CssClass="editbtnfooterorange" Text="<%$ Resources:localizedText, applyregisty %>" Style="float:left; clear: both; width: 176px; height: 15px; display:none; margin-top:0px;" />


     <section class="btmsecLeftMidcreatenew" style="display: none">
                        <asp:Button ID="btnNewCompany" CssClass="BottomFooterBtnsLeftnew_vis " runat="server"  Text="<%$ Resources:localizedText, newCompany %>" />
                        <asp:Button ID="btnSaveCompany" ClientIDMode="Static" CssClass="BottomFooterBtnsLeftsave " runat="server"  Text="<%$ Resources:localizedText, saveVisitorCompany %>" />
                        <asp:Button ID="btnDeleteCompany" ClientIDMode="Static" Style="display: none;" CssClass="BottomFooterBtnsLeftdelete " runat="server" Text="<%$ Resources:localizedText, deleteButton %>" />

                        <asp:Button ID="btnBackCompany" ClientIDMode="Static" CssClass="BottomFooterBackCompany " runat="server" Text="<%$ Resources:localizedText, backButton %>" Style="display:none;" />

                    </section>



    <section class="visitorpicsarea">
        <asp:Button ID="btnEntNew" runat="server" CssClass="PhotoholderClsnew hyperButtonsHover" OnClick="btnEntNew_Click" Text="<%$ Resources:localizedText, createVisitor %>" Style="color: rgba(46,116,223,1.00); margin-top: 0; margin-left: 0;" />

        <asp:Button ID="btnEntSave" runat="server" CssClass="PhotoholderClsnew hyperButtonsHover" OnClick="btnEntSave_Click" Text="<%$ Resources:localizedText, saveVisitor %>" Style="color: forestgreen; margin-top: 0; margin-left: 0;" />

        <asp:Button ID="btnCancelDel" runat="server" CssClass="PhotoholderClsnew hyperButtonsHover" OnClick="btnCancelDel_Click" Text="<%$ Resources:localizedText, deleteVisitor %>" Style="color: red; margin-top: 0; margin-left: 0;" />
    </section>
    <section class="idcardarea" style="display: none">

        <asp:Button ID="btnSaveAusweis" runat="server" Text="<%$ Resources:localizedText, saveCard %>" CssClass="btnAuswesSavenew" />
        <asp:Button ID="btnDeleteAusweis" runat="server" Text="<%$ Resources:localizedText, deleteCard %>" CssClass="btnAuswesDeletenew" />

    </section>

    <section class="BottomFooterBtnsLeft_car" style="display: none">

        <section class="manufacture">
            <asp:Button ID="btnNewManufacturer" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newmanufacturer %>" Style="padding: 0 0 5px 0; margin: 0 0 0 4px;" />
            <asp:Button ID="btnSaveManufacturer" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, savemanufacturer %>" Style="padding: 0 0 5px 0; margin: 0 0 0 4px;" />
            <asp:Button ID="btnDeleteManufacturer" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deletemanufacturer %>" Style="padding: 0 0 5px 0; margin: 0 0 0 4px;" />
        </section>
        <section class="footerextra" style="float: right;">
            <asp:Button ID="btnNewModel" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newvehicletype %>" Style="width: 118px !important; padding: 0 0 5px 0; margin: 0 0 0 4px;" />
            <asp:Button ID="btnSaveModel" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, savevehicletype %>" Style="width: 150px !important; padding: 0 0 5px 0; margin: 0 0 0 4px;" />
            <asp:Button ID="btnDeleteModel" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deletevehicletype %>" Style="width: 150px !important; padding: 0 0 5px 0; margin: 0 0 0 4px;" />
        </section>


        <section style="display: none;">

            <asp:Button ID="btnNewvehicleType" CssClass="GridFooterBtnsLeftnew btnnew2" runat="server" Text="<%$ Resources:localizedText, newmanufacturer %>" Style="width: 115px; float: left;" />
            <%--        <asp:Button ID="btnsaveehicleType" CssClass="GridFooterBtnsLeftnew btnEdit" runat="server" Text="Hersteller speichern" Style="display: none" />--%>
            <asp:Button ID="btnsaveehicleType" ClientIDMode="Static" CssClass="GridFooterBtnsLeftnew btnSavenew_new" runat="server" Text="<%$ Resources:localizedText, savemanufacturer %>" Style="color: forestgreen; width: 148px; float: left;" />
            <asp:Button ID="btnDeletevehicleType" CssClass="GridFooterBtnsLeftnew btnDeletenew" runat="server" Text="<%$ Resources:localizedText, deletemanufacturer %>" />
            <asp:Button ID="btnNewvehicleModel" CssClass="GridFooterBtnsLeftnew btnnew2" runat="server" Text="<%$ Resources:localizedText, newvehicletype %>" Style="float: left;" />
            <asp:Button ID="btnSavevTypeModel" ClientIDMode="Static" CssClass="GridFooterBtnsLeftnew btnSavenew" runat="server" Text="<%$ Resources:localizedText, savevehicletype %>" Style="color: forestgreen; float: left;" />
            <asp:Button ID="btnDeletevTypeModel" ClientIDMode="Static" CssClass="BottomFooterBtnsRightnew btnClosenew2" runat="server" Text="<%$ Resources:localizedText, deletevehicletype %>" Style="float: left;" />
        </section>
    </section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBackNew" CssClass="BottomFooterBtnsRight btnDeletenew2 " runat="server" Text="<%$ Resources:localizedText, backButton %>" ClientIDMode="Static" Style="float: right; margin-top:5px;" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
