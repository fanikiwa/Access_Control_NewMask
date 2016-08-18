<%@ Page Title="<%$ Resources:localizedText, gatemonitorid %>" Language="C#" MasterPageFile="~/MasterPages/Gate.Master" AutoEventWireup="true" CodeBehind="GatePersonalDocument.aspx.cs" Inherits="Access_Control_NewMask.Content.GatePersonalDocument" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/GatePersonalDocument.js"></script>
    <link href="Styles/GatePersonalDocument.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">
    <asp:HiddenField ID="hiddenFieldType" runat="server" />
    <asp:HiddenField ID="hiddenFieldPersonalNumber" runat="server" />
    <div id="midarea1">
        <div id="topmidmenu1">
            <asp:Button ID="btnPesonalDocument" ClientIDMode="Static" runat="server" Text="Personal" CssClass="btnpersonalnew"   Style="display:none;" />
            <asp:Button ID="btnIndentification" runat="server" ClientIDMode="Static" Text="<%$ Resources:localizedText, identitycard %>" CssClass="Personalaeratop newstandardbutton Personenbutton2"></asp:Button>
            <span class="arrowpoint"></span>
            <asp:Button ID="btnpassport" runat="server" Text="<%$ Resources:localizedText, passport %>" CssClass="Personalaeratop newstandardbutton Leserbutton2"></asp:Button>
            <span class="arrowpoint"></span>
            <asp:Button ID="btnlicense" runat="server" Text="<%$ Resources:localizedText, driverLicense %>" CssClass="Personalaeratop newstandardbutton Zutrittsprofilbutton2"  Style="width:100% !important;"></asp:Button>
            <span class="arrowpoint"></span>
            <asp:Button ID="btnguest" runat="server" Text="<%$ Resources:localizedText, healthCard %>" CssClass="Personalaeratop newstandardbutton Zutrittsprofilbutton2holiday"></asp:Button>
        </div>
        <div id="midcontentarea">
            <div class="contentarea2">
                <div class="perscenter">
                    <div class="areatitle">
                        <asp:Label runat="server" Text="<%$ Resources:localizedText, identitycard %>" class="lblperstop"></asp:Label>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, createdin%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtIDCreatedIn" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText,idnumber%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtIDNumber" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, nameid%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtIDName" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, firstnames%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtIDFirstName" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, birthdate%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtIDDateOfBirth" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                        <section style="display: none;">
                            <dx:ASPxDateEdit ID="dtIDDateOfBirth" runat="server" CssClass="txtarea1new" Theme="Office2003Blue"></dx:ASPxDateEdit>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText,national%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtIDNationality" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, birthplace%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtIDPlaceofBirth" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, addationalnumber%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtIDAdditionalNumber" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, expirydate%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtIDExpiryDate" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                        <section style="display: none;">
                            <dx:ASPxDateEdit ID="dtIDExpiryDate" runat="server" CssClass="txtarea1new" Theme="Office2003Blue"></dx:ASPxDateEdit>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, eyecolor%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtIDEyeColor" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, size%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtIDSize" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, issuedon%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtIDIssuedOn" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                        <section style="display: none;">
                            <dx:ASPxDateEdit ID="dtIDIssuedOn" runat="server" CssClass="txtarea1new" Theme="Office2003Blue"></dx:ASPxDateEdit>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, address2%>" class="lblname1" Style="margin-top: 14px;"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtIDAddress" runat="server" CssClass="txtarea1" TextMode="MultiLine" Style="height: 40px; overflow: hidden; resize: none;"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, isseudby%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtIDIssuingAuthority" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>

                    <div class="memoarea1" style="margin-top: -2px; height: 17%;">
                        <section class="lblareamemo">
                            <asp:Label runat="server" Text="Memo" class="lblmemo1" Style="margin-left: 4px;"></asp:Label>
                        </section>
                        <section class="txtcontentmemo">
                            <asp:TextBox ID="txtIDMemo" runat="server" CssClass="txtarea1memo" TextMode="MultiLine" Style="min-height: 77px; margin-left: 4px; width:98.5%;"></asp:TextBox>
                        </section>
                    </div>
                </div>

                <div class="perscenterpass" style="display: none">
                    <div class="areatitlepassport">
                        <asp:Label runat="server" Text="<%$ Resources:localizedText, passport %>" class="lblperstop"></asp:Label>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, createdin%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtPPCreatedIn" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, passportno%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtPPNumber" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, nameid%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtPPName" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, firstnames%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtPPFirstName" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, birthdate%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtPPDateOfBirth" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                        <section style="display: none;">
                            <dx:ASPxDateEdit ID="dtPPDateOfBirth" runat="server" CssClass="txtarea1new" Theme="Office2003Blue"></dx:ASPxDateEdit>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText,national%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtPPNationality" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText,gender_new%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtPPGender" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, birthplace%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtPPPlaceofBirth" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, issuedon%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtPPIssuedOn" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                        <section style="display: none;">
                            <dx:ASPxDateEdit ID="dtPPIssuedOn" runat="server" CssClass="txtarea1new" Theme="Office2003Blue"></dx:ASPxDateEdit>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, expirydate%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtPPExpiryDate" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                        <section style="display: none;">
                            <dx:ASPxDateEdit ID="dtPPExpiryDate" runat="server" CssClass="txtarea1new" Theme="Office2003Blue"></dx:ASPxDateEdit>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, eyecolor%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtPPEyeColor" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, size%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtPPSize" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <%--<div class="holder1">
     <section class="lblarea"><asp:Label runat="server" Text="<%$ Resources:localizedText, issuedon%>" class="lblname1"></asp:Label></section>
     <section class="txtcontent"><asp:TextBox ID="TextBox27" runat="server" CssClass="txtarea1"></asp:TextBox></section>
    </div>
             <div class="holder1">
     <section class="lblarea"><asp:Label runat="server" Text="<%$ Resources:localizedText, address2%>" class="lblname1"  Style="margin-top: 2%;"></asp:Label></section>
     <section class="txtcontent"><asp:TextBox ID="TextBox28" runat="server" CssClass="txtarea1" TextMode="MultiLine" Style="height:35px; overflow:hidden; resize:none;"></asp:TextBox></section>
    </div>--%>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, isseudby%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtPPIssuingAuthority" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>

                    <div class="memoarea1new resizememo2" style="margin-left:4px; width: 100%;">
                        <section class="lblareamemo">
                            <asp:Label runat="server" Text="Memo" class="lblmemo1" Style="margin-left:4px;"></asp:Label>
                        </section>
                        <section class="txtcontentmemo">
                            <asp:TextBox ID="txtPPMemo" runat="server" CssClass="txtarea1memonew" TextMode="MultiLine" Style="min-height: 78px; width: 99.5%;"></asp:TextBox>
                        </section>
                    </div>
                </div>

                <div class="perscenterfuh" style="display: none">
                    <div class="areatitlefuh">
                        <asp:Label runat="server" Text="<%$ Resources:localizedText, driverLicense %>" class="lblperstop"></asp:Label>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, createdin%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtDLCreatedIn" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, licenseNo%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtDLNumber" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, nameid%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtDLName" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, firstnames%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtDLFirstName" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, birthdate%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtDLDateOfBirth" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                        <section style="display: none;">
                            <dx:ASPxDateEdit ID="dtDLDateOfBirth" runat="server" CssClass="txtarea1new" Theme="Office2003Blue"></dx:ASPxDateEdit>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, birthplace%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtDLPlaceofBirth" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>

                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, issuedon%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtDLIssuedOn" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                        <section style="display: none;">
                            <dx:ASPxDateEdit ID="dtDLIssuedOn" runat="server" CssClass="txtarea1new" Theme="Office2003Blue"></dx:ASPxDateEdit>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, drivingLicenseClass%>" class="lblname1" Style="margin-top: 2%;"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtDLClass" runat="server" CssClass="txtarea1" TextMode="MultiLine" Style="height: 25px; overflow: hidden; resize: none;"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, isseudby%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtDLIssuingAuthority" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>

                    <div class="memoarea1text resizememo3"  Style="margin-left: 4px;">
                        <section class="lblareamemo">
                            <asp:Label runat="server" Text="Memo" class="lblmemo1" Style="margin-left: 4px;"></asp:Label>
                        </section>
                        <section class="txtcontentmemo">
                            <asp:TextBox ID="txtDLMemo" runat="server" CssClass="txtarea1memomidlast" TextMode="MultiLine" Style="min-height: 78px; margin-left: 1px; width: 99.5%;"></asp:TextBox>
                        </section>
                    </div>
                </div>

                <div class="perscenterges" style="display: none">
                    <div class="areatitleges">
                        <asp:Label runat="server" Text="<%$ Resources:localizedText, healthCard %>" class="lblperstop"  Style="margin-left: 0;"></asp:Label>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, cashRegister %>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtHIBoxOffice" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, createdIn_new %>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtHICreatedIn" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, nameid%>" CssClass="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtHIName" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, firstnames%>" CssClass="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtHIFirstName" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, birthdate%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtHIDateOfBirth" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                        <section style="display: none;">
                            <dx:ASPxDateEdit ID="dtHIDateOfBirth" runat="server" CssClass="txtarea1new" Theme="Office2003Blue"></dx:ASPxDateEdit>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, personalItemNo%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtHIPersonalNumber" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, passwordsNoOfCarrier%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtHISecurityNumber" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, IdentificationCardNumber%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtHICardNumber" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                    </div>
                    <div class="holder1">
                        <section class="lblarea">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, expirationDate%>" class="lblname1"></asp:Label>
                        </section>
                        <section class="txtcontent">
                            <asp:TextBox ID="txtHIExpirationDate" runat="server" CssClass="txtarea1"></asp:TextBox>
                        </section>
                        <section style="display: none;">
                            <dx:ASPxDateEdit ID="dtHIExpirationDate" runat="server" CssClass="txtarea1new" Theme="Office2003Blue"></dx:ASPxDateEdit>
                        </section>
                    </div>


                    <div class="memoarea1text resizememo4" Style="margin-left: 4px;">
                        <section class="lblareamemo">
                            <asp:Label runat="server" Text="Memo" class="lblmemo1" Style="margin-left: 2px;"></asp:Label>
                        </section>
                        <section class="txtcontentmemo">
                            <asp:TextBox ID="txtHIMemo" runat="server" CssClass="txtarea1memomidlast" TextMode="MultiLine" Style="min-height: 77px; width: 99.5%; margin-left: 1px;"></asp:TextBox>
                        </section>
                    </div>
                </div>

            </div>

            <div class="contentarea3">
                
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterLeft" runat="server">
    <section class="leftinfo1">
        <asp:Button ID="btnEntSave" CssClass="BottomFooterBtnsLeft savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, saveidentitycard %>" Style="padding-left: 5px; width: 180px;" />
    </section>
    <section class="leftinfo2" style="display: none;">
        <asp:Label ID="lblChangeText" ClientIDMode="Static" runat="server" Text="Personalstammdaten" CssClass="lblname1personalbottom"></asp:Label>
        <asp:Button ID="btnCancelDel" CssClass="BottomFooterBtnsLeft btndel" runat="server" Text="<%$ Resources:localizedText, deleteButton %>" />
    </section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="BottomFooterBtnsRight backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" Style="margin-top: 2%;" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
