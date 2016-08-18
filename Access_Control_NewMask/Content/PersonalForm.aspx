<%@ Page Title="<%$ Resources:localizedText, applicationForm %>" Language="C#" MasterPageFile="~/MasterPages/Primary.Master" AutoEventWireup="true" CodeBehind="PersonalForm.aspx.cs" Inherits="Access_Control_NewMask.Content.PersonalForm" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/PersonalForm.js"></script>
    <link href="Styles/PersonalForm.css" rel="stylesheet" />
    <link href="Styles/FormViewSearch.css" rel="stylesheet" />
     <script type="text/javascript">
        $( function () {
            $( ".btnProgress" ).each( function () {
                var label = $( this );
                label.after( "<input type = 'text' class='txtHidden  ListenForChange' style = 'display:none; margin-left:20px; width: 100%;  margin-bottom: 5px;margin-top: 5px;' />" );
                var textbox = $( this ).next();
                //var id = this.id.split('_')[this.id.split('_').length - 1];
                var id = this.id;
                //console.log( id );
                textbox[0].name = id.replace( "lbl", "txt" );
                textbox.val( label.html() );
                label.click( function ( e ) {
                    e.preventDefault();
                    $( this ).hide();
                    $( this ).next().show();
                    $( this ).next().focus();
                    $( $( this ).next() ).on( "change", function ( e ) {
                        saveChanges = true;
                        e.preventDefault();
                        //console.log( this.id );
                    } );
                } );
                textbox.focusout( function () { //focusout
                    //return;
                    $( '.txtHidden' ).each( function () { $( this ).hide(); $( this ).prev().show(); } );
                    $( this ).hide(); //hide textbox
                    $( this ).prev().html( $( this ).val() ); //set label value 
                    $( this ).prev().css( "color", "black" );
                    $( this ).prev().show();
                } );
            } )
        } );

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
      <asp:HiddenField ID="hiddenFieldSaveChanges" runat="server" />
    <div id="ControlSection1" class="ControlSection">
        <div id="AEHeaderLeftDiv">
            <div id="BottomHeaderLabels">
                <asp:Label ID="lblCostCenterHeader" runat="server" Text="<%$ Resources:localizedText, clientsnew %>" CssClass="L1HeaderT1drplables1cutomer"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="Mandanten Bezeichnung:" Style="display: none;" CssClass="L1HeaderT1drplables1desc"></asp:Label>
                <asp:Label ID="lblLocationHeader" runat="server" Text="<%$ Resources:localizedText, location1 %>" CssClass="L1HeaderT1drplables1"></asp:Label>
                <asp:Label ID="lblDepartmentHeader" runat="server" Text="<%$ Resources:localizedText, department %>" CssClass="L1HeaderT1drplables1new"></asp:Label>
                <asp:Label ID="lblEmployeeName" runat="server" Text="<%$ Resources:localizedText, name %>" CssClass="L1HeaderT1drplables1new"></asp:Label>
                <asp:Label ID="lblPersNo" runat="server" Text="ID Nr.:" CssClass="L1HeaderT1drplables1newid"></asp:Label>
                <asp:Label ID="lblIdentification" runat="server" Text="<%$ Resources:localizedText, cardNo %>" CssClass="L1HeaderT1drplables1newid"></asp:Label>


            </div>

            <div id="BottomHeaderLists">
                <%--<asp:DropDownList ID="dplClientsorig" DataTextField="Client_Nr" DataValueField="ID" runat="server" CssClass="L1HeaderT1drplists2client" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                    Style="display: none">
                </asp:DropDownList>--%>
           
                <dx:ASPxComboBox ID="dplClients" runat="server" ValueField="ID" TextField="Client_Nr" ClientIDMode="Static"
                    TextFormatString="{0}-{1}" CssClass="L1HeaderT1drplists2client ColorBlue" SelectedIndex="0" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue">

                    <ClientSideEvents SelectedIndexChanged="function(s, e) {dplClientsSelectedIndexChanged(s,e)}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn FieldName="Client_Nr" Name="ProfileDescription" ToolTip="" Width="20%" Caption=" Nr.:" />
                        <dx:ListBoxColumn FieldName="Name" Name="ID" ToolTip="Bezeichnung:" Width="80%" Caption="<%$ Resources:localizedText ,description_new%>" />
                    </Columns>
                </dx:ASPxComboBox>
               <%-- <asp:DropDownList ID="dplClientsNameorig" DataValueField="ID" DataTextField="Name" runat="server" CssClass="L1HeaderT1drplists2" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                    Style="display: none">
                </asp:DropDownList>--%>
                <dx:ASPxComboBox ID="dplClientsName" runat="server" ValueField="ID" TextField="Name" ClientIDMode="Static"
                    TextFormatString="{1}" CssClass="cboName ColorBlue" DropDownRows="6" DropDownWidth="400px" Theme="Office2003Blue">

                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	dplClientsNameSelectedIndexChanged(s,e);
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn FieldName="Client_Nr" Name="ProfileDescription" ToolTip="" Width="18%" Caption="Mandanten Nr.:" />
                        <dx:ListBoxColumn FieldName="Name" Name="ID" ToolTip="Bezeichnung:" Width="42%" Caption="Mandanten Bezeichnung:" />
                    </Columns>
                </dx:ASPxComboBox>
               <%-- <asp:DropDownList ID="dpllLocationorig" runat="server" DataTextField="Name" DataValueField="ID" CssClass="L1HeaderT1drplists2" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                    Style="display: none">
                </asp:DropDownList>--%>
                <dx:ASPxComboBox ID="dpllLocation" runat="server" ValueField="ID" TextField="Name" ClientIDMode="Static"
                    TextFormatString="{0}" CssClass="L1HeaderT1drplists2 ColorBlue" SelectedIndex="0" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue">

                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	dpllLocationSelectedIndexChanged(s, e);
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn FieldName="ID" Caption="Nr." Name="" Visible="false" />
                        <dx:ListBoxColumn FieldName="Location_Nr" Caption="Nr.:" Name="" ToolTip="Bezeichnung:" Width="20%" />
                        <dx:ListBoxColumn FieldName="Name" Name="ProfileDescription" ToolTip="" Width="80%" Caption="<%$ Resources:localizedText, description_new %>" />
                        <%--   <dx:ListBoxColumn  FieldName="Name" Name="ID" ToolTip="Bezeichnung:" Width="42%" />--%>
                    </Columns>
                </dx:ASPxComboBox>
                <%--<asp:DropDownList ID="dplDepartmentorig" runat="server" DataTextField="Name" DataValueField="ID" CssClass="L1HeaderT1drplists2" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                    Style="display: none">
                </asp:DropDownList>--%>
                <dx:ASPxComboBox ID="dplDepartment" runat="server" ValueField="ID" TextField="Name" ClientIDMode="Static"
                    TextFormatString="{0}" CssClass="L1HeaderT1drplists2 ColorBlue" SelectedIndex="0" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue">

                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	dplDepartmentSelectedIndexChanged(s, e);
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn FieldName="ID" Caption="ID." Name="ID" Visible="false" />
                        <dx:ListBoxColumn FieldName="Department_Nr" Caption="Nr.:" Name="Department_Nr" ToolTip="Bezeichnung:" Width="20%" />
                        <dx:ListBoxColumn FieldName="Name" Name="ProfileDescription" ToolTip="" Width="80%" Caption="<%$ Resources:localizedText, description_new %>" />
                        <%--  <dx:ListBoxColumn  FieldName="Name" Name="ID" ToolTip="Bezeichnung:" Width="42%" />--%>
                    </Columns>
                </dx:ASPxComboBox>
               <%-- <asp:DropDownList ID="dpllPersNameorig" runat="server" DataTextField="PersNr_Fullname" DataValueField="ID" CssClass="L1HeaderT1drplists2" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" Style="display: none">
                </asp:DropDownList>--%>
                <dx:ASPxComboBox ID="dpllPersName" runat="server" ValueField="Pers_Nr" ValueType="System.Int32" TextField="PersNr_Fullname" ClientIDMode="Static" DropDownRows="20"
                    TextFormatString="{1}-{2}" CssClass="L1HeaderT1drplists2 ColorBlue" DropDownWidth="400px" Theme="Office2003Blue">

                    <ClientSideEvents SelectedIndexChanged="function(s, e) { dpllPersNameSelectedIndexChanged(s, e); }"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn FieldName="Pers_Nr" Name="ID" ToolTip="Bezeichnung:" Width="20%" Caption="Pers.Nr." />
                        <dx:ListBoxColumn FieldName="FirstName" Name="ProfileDescription" ToolTip="" Width="40%" Caption="<%$ Resources:localizedText, name %>" />
                        <dx:ListBoxColumn FieldName="LastName" Name="ID" ToolTip="Bezeichnung:" Width="40%" />
                    </Columns>
                </dx:ASPxComboBox>
                <%--<asp:DropDownList ID="dplIDNrorig" runat="server" DataValueField="ID" DataTextField="Pers_Nr" CssClass="L1HeaderT1drplists2" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" Style="display: none">
                </asp:DropDownList>--%>
                <dx:ASPxComboBox ID="dplIDNr" runat="server" ValueField="Pers_Nr" ValueType="System.Int32" TextField="Pers_Nr" ClientIDMode="Static" DropDownRows="20"
                    TextFormatString="{0}" CssClass="L1HeaderT1drplists2new ColorBlue" DropDownWidth="100px" Theme="Office2003Blue" HorizontalAlign="left">

                    <ClientSideEvents SelectedIndexChanged="function(s, e) { dplIDNrSelectedIndexChanged(s, e); }"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn FieldName="Pers_Nr" Name="ProfileDescription" ToolTip="" Width="10%" Caption="ID Nr.:" />
                        <%--        <dx:ListBoxColumn  FieldName="Name" Name="ID" ToolTip="Bezeichnung:" Width="42%" />--%>
                    </Columns>
                </dx:ASPxComboBox>
              <%--  <asp:DropDownList ID="dplAusweisNrorig" runat="server" DataValueField="ID" DataTextField="Card_Nr" CssClass="L1HeaderT1drplists2" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" Style="display: none">
                </asp:DropDownList>--%>
                <dx:ASPxComboBox ID="dplAusweisNr" runat="server" ValueField="Pers_Nr" ValueType="System.Int32" TextField="Card_Nr" ClientIDMode="Static" DropDownRows="20"
                    TextFormatString="{0}" CssClass="L1HeaderT1drplists2new ColorBlue" DropDownWidth="100px" Theme="Office2003Blue" HorizontalAlign="left">

                    <ClientSideEvents SelectedIndexChanged="function(s, e) { dplAusweisNrPersNameSelectedIndexChanged(s, e); }"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn FieldName="Card_Nr" Name="ProfileDescription" ToolTip="" Width="10%" Caption="<%$ Resources:localizedText, cardNo %>" />
                        <dx:ListBoxColumn FieldName="Name" Name="ID" ToolTip="Bezeichnung:" Width="90%" Visible="false" />
                    </Columns>
                </dx:ASPxComboBox>
            </div>

        </div>

        <div id="AEHeaderRightDiv">

            <section class="empFormViewNav">
                <section class="fvNavSearch">
                    <asp:Label ID="lblSearchAllEmp" runat="server" Text="<%$ Resources:localizedText, search %>" />
                    <asp:Button ID="btnSearchAllEmp" runat="server" Text="" CssClass="searchAllEmp" />
                </section>

                <section class="fvNavPrevious">
                    <span></span>
                    <asp:Button ID="fvNavPrev" runat="server" Text="" CssClass="btnFvNavPrev" />
                </section>

                <section class="fvNavCurrentEmpNum">
                    <asp:Label ID="lblFvCurrentEntry" Text="<%$ Resources:localizedText, pos %>" runat="server" />
                    <asp:TextBox ID="txtCurrentPersonnel" runat="server" Width="96%" Enabled="false" />
                </section>

                <section class="fvNavTotalEmpNum">
                    <asp:Label ID="lblFvTotalEntries" Text="<%$ Resources:localizedText, num %>" runat="server" />
                    <asp:TextBox ID="txtTotalPersonnel" runat="server" Width="96%" Enabled="false" />
                </section>

                <section class="fvNavNext">
                    <span></span>
                    <asp:Button ID="fvNavNext" runat="server" Text="" CssClass="btnFvNavNext" />
                </section>
            </section>
        </div>

    </div>
    <section class="upperSectionPersonal">
        <asp:Button ID="btnPersonalStamm" CssClass=" newstandardbutton BottomFooterBtnsLeftdocument btnpersonal " runat="server" Text="Personalstamm"  />
         <asp:Button ID="btnPersonalForm" CssClass=" newstandardbutton BottomFooterBtnsLeftdocument2 btnbogen " runat="server" Text="<%$ Resources:localizedText, applicationForm %>" Enabled="false" Style="text-align: center;" />
        <asp:Button ID="btnPERSDOC" CssClass=" newstandardbutton BottomFooterBtnsLeftdocument btnDocumente " runat="server" Text="<%$ Resources:localizedText, document %>" OnClick="btnPERSDOC_Click"/>
       
        <%-- <asp:ListItem Selected="True" Value="0">keine</asp:ListItem>--%>
    </section>
    <div class="tabcontroldiv">
        <div id="contentholder">
            <div class="divLeft">
                <section class="secDivLeftTop">
                    <section class="secDivLeftTopLeft">
                        <asp:Label ID="Label37" runat="server" Text="<%$ Resources:localizedText, employeeNr %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label17" runat="server" Text="<%$ Resources:localizedText, title_new %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label39" runat="server" Text="<%$ Resources:localizedText, salutation_new %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label41" runat="server" Text="Name:" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label40" runat="server" Text="<%$ Resources:localizedText, firstName1 %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label44" runat="server" Text="<%$ Resources:localizedText, postalCode_new %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label43" runat="server" Text="<%$ Resources:localizedText, placeOfResidence %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label45" runat="server" Text="<%$ Resources:localizedText, street %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label46" runat="server" Text="<%$ Resources:localizedText, addition %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label47" runat="server" Text="<%$ Resources:localizedText, gender_new %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label48" runat="server" Text="<%$ Resources:localizedText, nationality %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label51" runat="server" Text="<%$ Resources:localizedText, dateOfBirth %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label52" runat="server" Text="<%$ Resources:localizedText, birthplace %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="lblbankAccount" runat="server" Text="<%$ Resources:localizedText, bankDetails %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="lblaccountHolder" runat="server" Text="<%$ Resources:localizedText, accountOwner %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="lblBank" runat="server" Text="<%$ Resources:localizedText, bankCode %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="lblaccountNumber" runat="server" Text="<%$ Resources:localizedText, accountNumber_new %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="lblbic" runat="server" Text="<%$ Resources:localizedText, selling %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="lbliban" runat="server" Text="<%$ Resources:localizedText, bank_new %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label59" runat="server" Text="<%$ Resources:localizedText, drivingLicense_new %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label60" runat="server" Text="<%$ Resources:localizedText, since %>" CssClass="lblPersonalInfo"></asp:Label>
                    </section>
                    <section class="secDivLeftTopRight">
                        <asp:TextBox ID="txtPersonnelNo" runat="server" CssClass="txtPersonalInfo"></asp:TextBox>
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="txtPersonalInfo"></asp:TextBox>
                        <asp:TextBox ID="txtSalutation" runat="server" CssClass="txtPersonalInfo"></asp:TextBox>
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="txtPersonalInfo"></asp:TextBox>
                        <asp:TextBox ID="txtName" runat="server" CssClass="txtPersonalInfo"></asp:TextBox>
                        <asp:TextBox ID="txtPostalCode" runat="server" CssClass="txtPersonalInfo"></asp:TextBox>
                        <asp:TextBox ID="txtPlaceOfResidence" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtRoad" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtAdditional" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtGender" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtNationality" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <dx:ASPxDateEdit ID="txtDateOfBirth" runat="server" CssClass="txtPersonalInfodatepick  ListenForChange" Theme="Office2003Blue">
                            <ClientSideEvents DateChanged="function(s, e) {
	saveChanges=true;
}"></ClientSideEvents>
                        </dx:ASPxDateEdit>
                        <asp:TextBox ID="txtPlaceOfBirth" runat="server" CssClass="txtPersonalInfo  ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtBankAccount" runat="server" CssClass="txtPersonalInfo  ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtAccountHolder" runat="server" CssClass="txtPersonalInfo  ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtBank" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtAccountNumber" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtBic" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtIban" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtDrivingLicense" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <dx:ASPxDateEdit ID="txtSince" runat="server" CssClass="txtPersonalInfodatepick ListenForChange" Theme="Office2003Blue">
                            <ClientSideEvents DateChanged="function(s, e) {
	saveChanges=true;
}"></ClientSideEvents>
                        </dx:ASPxDateEdit>
                    </section>
                </section>

            </div>

            <div class="divCentreLeft">
                <section class="secdivCentreLeftTop">
                    <section class="secCentre1TopLeft">
                        <asp:Label ID="Label73" runat="server" Text="<%$ Resources:localizedText, maritalStatus_new %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label74" runat="server" Text="<%$ Resources:localizedText, children_new %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label75" runat="server" Text="<%$ Resources:localizedText, taxOffice %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label76" runat="server" Text="<%$ Resources:localizedText, taxClass_new %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label77" runat="server" Text="<%$ Resources:localizedText, healthInsurance %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label78" runat="server" Text="<%$ Resources:localizedText, healthInsuranceNo %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label79" runat="server" Text="<%$ Resources:localizedText, pensionInsurance %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="Label80" runat="server" Text="Soz.Vers.Nr.:" CssClass="lblPersonalInfo"></asp:Label>

                    </section>
                    <section class="secCentreTopRight">
                        <asp:TextBox ID="txtMaritalStatus" runat="server" CssClass="txtPersonalInfo  ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtChildren" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtTaxOffice" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtTaxClass" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtHealthInsurance" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtHealthInsuranceNumber" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtPensionInsurance" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtSozVerseNumber" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    </section>
                </section>
                <section class="secdivCentreLeftBttm">
                    <section class="secCentre1BttmLeft">
                        <asp:Label ID="lblcontract" runat="server" Text="<%$ Resources:localizedText, contractType %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="lblemployedFrom" runat="server" Text="<%$ Resources:localizedText, employedFrom %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="lblemployedAs" runat="server" Text="<%$ Resources:localizedText, employedAs_new %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="learnedProfession" runat="server" Text="<%$ Resources:localizedText, profession %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="employment" runat="server" Text="<%$ Resources:localizedText, employmentType %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="residencePermit" runat="server" Text="<%$ Resources:localizedText, residencePermit %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="authorizedBy" runat="server" Text="<%$ Resources:localizedText, approvedBy %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="approvedBy" runat="server" Text="<%$ Resources:localizedText, approvedTo %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="numberOfHours" runat="server" Text="<%$ Resources:localizedText, totalHours %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="lblcontractTerminates" runat="server" Text="<%$ Resources:localizedText, endOfContract %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="lbleliminatedOn" runat="server" Text="<%$ Resources:localizedText, eliminatedOn %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="lblreason" runat="server" Text="<%$ Resources:localizedText, reason %>" CssClass="lblPersonalInfo"></asp:Label>
                        <asp:Label ID="lblemploymentReference" runat="server" Text="<%$ Resources:localizedText, workCertificate %>" CssClass="lblPersonalInfo"></asp:Label>
                    </section>
                    <section class="secCentre1BttmRight">
                        <asp:TextBox ID="txtContract" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <dx:ASPxDateEdit ID="txtEmployedFrom" runat="server" CssClass="txtPersonalInfodatepick ListenForChange" Theme="Office2003Blue" Style="min-width: 100%;" DisplayFormatString="dd.MM.yyyy">
                            <ClientSideEvents DateChanged="function(s, e) {
	saveChanges=true;
}"></ClientSideEvents>
                        </dx:ASPxDateEdit>
                        <asp:TextBox ID="txtEmployedAs" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtLearnedProfession" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtEmployed" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtResidencePermit" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtAuthhorizedBy" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtApprovedBy" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtNumberOfHours" runat="server" CssClass="txtPersonalInfo ListenForChange" Theme="Office2003Blue"></asp:TextBox>
                        <dx:ASPxDateEdit ID="txtContractTerminates" runat="server" CssClass="txtPersonalInfodatepick ListenForChange" Theme="Office2003Blue">
                            <ClientSideEvents DateChanged="function(s, e) {
	saveChanges=true;
}"></ClientSideEvents>
                        </dx:ASPxDateEdit>
                        <dx:ASPxDateEdit ID="txtElimanatedOn" runat="server" CssClass="txtPersonalInfodatepick ListenForChange" Theme="Office2003Blue">
                            <ClientSideEvents DateChanged="function(s, e) {
	saveChanges=true;
}"></ClientSideEvents>
                        </dx:ASPxDateEdit>
                        <asp:TextBox ID="txtReason" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                        <asp:TextBox ID="txtEmploymentReference" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    </section>
                </section>
            </div>

            <div class="divCentreRight">
                <section class="secCentre2Left">
                    <asp:Label ID="lblF1" runat="server" Text="F1..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF2" runat="server" Text="F2..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF3" runat="server" Text="F3..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF4" runat="server" Text="F4..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF5" runat="server" Text="F5..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF6" runat="server" Text="F6..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF7" runat="server" Text="F7..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF8" runat="server" Text="F8..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF9" runat="server" Text="F9..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF10" runat="server" Text="F10..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF11" runat="server" Text="F11..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF12" runat="server" Text="F12..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF13" runat="server" Text="F13..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF14" runat="server" Text="F14..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF15" runat="server" Text="F15..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF16" runat="server" Text="F16..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF17" runat="server" Text="F17..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF18" runat="server" Text="F18..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF19" runat="server" Text="F19..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF20" runat="server" Text="F20..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF21" runat="server" Text="F21..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                </section>
                <section class="secCentre2Right">
                    <asp:TextBox ID="txtFF1" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF2" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF3" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF4" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF5" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF6" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF7" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF8" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF9" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF10" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF11" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF12" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF13" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF14" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF15" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF16" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF17" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF18" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF19" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF20" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF21" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                </section>
            </div>

            <div class="divRight">
                <section class="secDivright_Left">
                    <asp:Label ID="lblF22" runat="server" Text="F22..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF23" runat="server" Text="F23..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF24" runat="server" Text="F24..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF25" runat="server" Text="F25..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF26" runat="server" Text="F26..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF27" runat="server" Text="F27..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF28" runat="server" Text="F28..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF29" runat="server" Text="F29..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF30" runat="server" Text="F30..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF31" runat="server" Text="F31..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF32" runat="server" Text="F32..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF33" runat="server" Text="F33..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF34" runat="server" Text="F34..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF35" runat="server" Text="F35..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF36" runat="server" Text="F36..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF37" runat="server" Text="F37..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF38" runat="server" Text="F38..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF39" runat="server" Text="F39..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF40" runat="server" Text="F40..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF41" runat="server" Text="F41..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblF42" runat="server" Text="F42..." CssClass="btnProgress ListenForChange" ForeColor="Red"></asp:Label>
                </section>
                <section class="secDivright_Right">
                    <asp:TextBox ID="txtFF22" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF23" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF24" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF25" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF26" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF27" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF28" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF29" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF30" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF31" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF32" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF33" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF34" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF35" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF36" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF37" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF38" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF39" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF40" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF41" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                    <asp:TextBox ID="txtFF42" runat="server" CssClass="txtPersonalInfo ListenForChange"></asp:TextBox>
                </section>
            </div>

            <div id="importantDialog" class="dialogBox"></div>
        </div>

        <div id="searchPersData" class="searchPersonnelData" style="display: none;">
             <dx:ASPxGridView ID="grdPersData" SettingsBehavior-AllowSort="false" ClientInstanceName="grdPersData" runat="server" Width="100%" KeyFieldName="Pers_Nr" AutoGenerateColumns="False" Theme="Office2003Blue" EnableTheming="True">
                 <ClientSideEvents RowDblClick="function(s, e) {
	BindSelectedPers(s.GetRowKey(e.visibleIndex));
}"></ClientSideEvents>
                 <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID">
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
                <SettingsPager ShowEmptyDataRows="true" PageSize="23" Visible="False"></SettingsPager>
                <SettingsBehavior AllowSort="false" AllowDragDrop="false" AllowFocusedRow="true" AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" ProcessSelectionChangedOnServer="false" />
                <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
            </dx:ASPxGridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnNew" CssClass="BottomFooterBtnsLeft newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newPersonal %>"  Style="display:none;"/>
    <asp:Button ID="btnSave" CssClass="BottomFooterBtnsLeft savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, savedatanew %>" Style="width:105px;"/>
    <asp:Button ID="btnDelete" CssClass="BottomFooterBtnsLeft deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deletedatedatanew %>"   Style="width:110px; display:none !important;"/>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
     <asp:Button ID="btnBack" CssClass="BottomFooterBtnsRight backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>"  OnClick="btnBack_Click"/>
    <asp:Button ID="btnHelp" ClientIDMode="Static" CssClass="BottomFooterBtnsRight helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
