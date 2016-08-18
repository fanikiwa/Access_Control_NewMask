<%@ Page Title="<%$ Resources:localizedText, membersinactivemasterdocuments %>" Language="C#" MasterPageFile="~/MasterPages/Secondary.Master" AutoEventWireup="true" CodeBehind="MembersDocumenteInactive.aspx.cs" Inherits="Access_Control_NewMask.Content.MembersDocumenteInactive" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/MembersDocumenteInactive.js"></script>
    <link href="Styles/MembersDocumenteInactive.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
     <asp:HiddenField ID="hiddenFieldMemberId" runat="server" />
    <div id="ControlSecarea" class="ControlSecarea1new2ab">
        <div class="ControlSecarea3">
            <section class="rightDvns">
                <asp:Button ID="Button1" runat="server" Text="Personalstamm" CssClass="Personenbutton2personal" Style="display: none;"></asp:Button>
                <span class="arrowpoint"></span>
                <asp:Button ID="btnidentity" runat="server" Text="<%$ Resources:localizedText, identitycard %>" CssClass=" newstandardbutton Personenbutton2"></asp:Button>
                <span class="arrowpoint"></span>
                <asp:Button ID="btnpassport" runat="server" Text="<%$ Resources:localizedText, passport %>" CssClass="newstandardbutton Leserbutton2"></asp:Button>
                <span class="arrowpoint"></span>
                <asp:Button ID="btnlicense" runat="server" Text="<%$ Resources:localizedText, driverLicense %>" CssClass="newstandardbutton Zutrittsprofilbutton2"></asp:Button>
                <span class="arrowpoint"></span>
                <asp:Button ID="btnguest" runat="server" Text="<%$ Resources:localizedText, healthCard %>" CssClass="newstandardbutton Zutrittsprofilbutton2holiday"></asp:Button>
            </section>
        </div>
    </div>
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
                    <asp:TextBox ID="txtIDCreatedIn" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="Pass Nummer:" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtIDNumber" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, nameid%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtIDFirstName" Enabled="false" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, firstnames%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtIDName" Enabled="false" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, birthdate%>" class="lblname1"></asp:Label>
                </section>

                <dx:ASPxDateEdit ID="dtIDDateOfBirth" ClientEnabled="false" runat="server" CssClass="txtarea1new ListenForChange" Theme="Office2003Blue"></dx:ASPxDateEdit>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText,national%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtIDNationality" Enabled="false" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, birthplace%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtIDPlaceofBirth" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, addationalnumber%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtIDAdditionalNumber" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, expirydate%>" class="lblname1"></asp:Label>
                </section>
                <dx:ASPxDateEdit ID="dtIDExpiryDate" runat="server" CssClass="txtarea1new ListenForChange" Theme="Office2003Blue"></dx:ASPxDateEdit>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, eyecolor%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtIDEyeColor" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, size%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtMemberHeight" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, issuedon%>" class="lblname1"></asp:Label>
                </section>
                <dx:ASPxDateEdit ID="dtIDIssuedOn" runat="server" CssClass="txtarea1new ListenForChange" Theme="Office2003Blue"></dx:ASPxDateEdit>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, address2%>" class="lblname1" Style="margin-top: 14px;"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtIDAddress" runat="server" CssClass="txtarea1 ListenForChange" TextMode="MultiLine" Style="height: 42px; overflow: hidden; resize: none;"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, isseudby%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtIDIssuingAuthority" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>

            <div class="memoarea1">
                <section class="lblareamemo">
                    <asp:Label runat="server" Text="Memo" class="lblmemo1"></asp:Label>
                </section>
                <section class="txtcontentmemo">
                    <asp:TextBox ID="txtIDMemo" runat="server" CssClass="txtarea1memo" TextMode="MultiLine"></asp:TextBox>
                </section>
            </div>
        </div>
        <div class="perscenterpass" style="display: none">
            <div class="areatitlepassport">
                <asp:Label runat="server" Text="<%$ Resources:localizedText, passport%>" class="lblperstop"></asp:Label>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, createdin%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtPPCreatedIn" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="Pass Nummer:" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtPPNumber" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, nameid%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtPPFirstName" Enabled="false" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, firstnames%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtPPName" Enabled="false" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, birthdate%>" class="lblname1"></asp:Label>
                </section>
                <dx:ASPxDateEdit ID="dtPPDateOfBirth" ClientEnabled="false" runat="server" CssClass="txtarea1new ListenForChange" Theme="Office2003Blue"></dx:ASPxDateEdit>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText,national%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtPPNationality" Enabled="false" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText,gender_new%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtPPGender" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, birthplace%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtPPPlaceofBirth" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, issuedon%>" class="lblname1"></asp:Label>
                </section> 
                <dx:ASPxDateEdit ID="dtPPIssuedOn" runat="server" CssClass="txtarea1new ListenForChange" Theme="Office2003Blue"></dx:ASPxDateEdit>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, expirydate%>" class="lblname1"></asp:Label>
                </section>
                <dx:ASPxDateEdit ID="dtPPExpiryDate" runat="server" CssClass="txtarea1new ListenForChange" Theme="Office2003Blue"></dx:ASPxDateEdit>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, eyecolor%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtPPEyeColor" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, size%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtPPSize" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
     
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, isseudby%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtPPIssuingAuthority" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>

            <div class="memoarea1new resizememo2">
                <section class="lblareamemo">
                    <asp:Label runat="server" Text="Memo" class="lblmemo1"></asp:Label>
                </section>
                <section class="txtcontentmemo">
                    <asp:TextBox ID="txtPPMemo" runat="server" CssClass="txtarea1memonew" TextMode="MultiLine" Style="min-height: 96px;"></asp:TextBox>
                </section>
            </div>
        </div>
        <div class="perscenterfuh" style="display: none">
            <div class="areatitlefuh">
                <asp:Label runat="server" Text="<%$ Resources:localizedText, driverLicense%>" class="lblperstop"></asp:Label>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, createdin%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtDLCreatedIn" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, licenseNo%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtDLNumber" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, nameid%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtDLFirstName" Enabled="false" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, firstnames%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtDLName" Enabled="false" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, birthdate%>" class="lblname1"></asp:Label>
                </section>
                <dx:ASPxDateEdit ID="dtDLDateOfBirth" ClientEnabled="false" runat="server" CssClass="txtarea1new ListenForChange" Theme="Office2003Blue"></dx:ASPxDateEdit>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, birthplace%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtDLPlaceofBirth" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>

            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, issuedon%>" class="lblname1"></asp:Label>
                </section>
                <dx:ASPxDateEdit ID="dtDLIssuedOn" runat="server" CssClass="txtarea1new ListenForChange" Theme="Office2003Blue"></dx:ASPxDateEdit>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, drivingLicenseClass%>" class="lblname1" Style="margin-top: 2%;"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtDLClass" runat="server" CssClass="txtarea1 ListenForChange" TextMode="MultiLine" Style="height: 25px; overflow: hidden; resize: none;"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, isseudby%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtDLIssuingAuthority" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>

            <div class="memoarea1text resizememo3">
                <section class="lblareamemo">
                    <asp:Label runat="server" Text="Memo" class="lblmemo1"></asp:Label>
                </section>
                <section class="txtcontentmemo">
                    <asp:TextBox ID="txtDLMemo" runat="server" CssClass="txtarea1memomidlast" TextMode="MultiLine" Style="min-height: 96px;"></asp:TextBox>
                </section>
            </div>
        </div>
        <div class="perscenterges" style="display: none">
            <div class="areatitleges">
                <asp:Label runat="server" Text="<%$ Resources:localizedText, healthCard%>" class="lblperstop"></asp:Label>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, cashRegister%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtHIBoxOffice" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, createdIn_new%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtHICreatedIn" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, nameid%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtHIFirstName" Enabled="false" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, firstnames%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtHIName" Enabled="false" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, birthdate%>" class="lblname1"></asp:Label>
                </section>
                <dx:ASPxDateEdit ID="dtHIDateOfBirth" ClientEnabled="false" runat="server" CssClass="txtarea1new ListenForChange" Theme="Office2003Blue"></dx:ASPxDateEdit>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, personalItemNo%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtHIMemberNumber" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, passwordsNoOfCarrier%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtHISecurityNumber" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, IdentificationCardNumber%>" class="lblname1"></asp:Label>
                </section>
                <section class="txtcontent">
                    <asp:TextBox ID="txtHICardNumber" runat="server" CssClass="txtarea1 ListenForChange"></asp:TextBox>
                </section>
            </div>
            <div class="holder1">
                <section class="lblarea">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, expirationDate%>" class="lblname1"></asp:Label>
                </section>
                <dx:ASPxDateEdit ID="dtHIExpirationDate" runat="server" CssClass="txtarea1new ListenForChange" Theme="Office2003Blue"></dx:ASPxDateEdit>
            </div>


            <div class="memoarea1lastmemo resizememo4">
                <section class="lblareamemo">
                    <asp:Label runat="server" Text="Memo" class="lblmemo1"></asp:Label>
                </section>
                <section class="txtcontentmemo">
                    <asp:TextBox ID="txtHIMemo" runat="server" CssClass="txtarea1memomidlastnew" TextMode="MultiLine" Style="min-height: 96px;"></asp:TextBox>
                </section>
            </div>
        </div>
        <div id="importantDialog" class="dialogBox">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server"> 
    <section class="leftinfo1">
        <asp:Button ID="btnNew" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft newbtnfooterblue" runat="server" Text="Personalausweis neu" Style="width: 139px; text-align: right !important; display: none;" />
        <asp:Button ID="btnEntSave" CssClass="BottomFooterBtnsLeft savebtnfootergreen" runat="server" Text="Personalausweis speichern" Style="width: 219px; margin-left: 0; display: none;" />
        <asp:Button ID="btnCancelDel" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft deletebtnfooterred" runat="server" Text="" Style="text-align: right !important; width: 217px; display: none;" /> 
    </section>
    <section class="leftinfo2">
        <asp:Label ID="Label1" runat="server" Text="" CssClass="lblname1personal"></asp:Label>
    </section>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
        <asp:Button ID="btnBack" CssClass="BottomFooterBtnsRight backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBack_Click" />
    <asp:Button ID="btnActHelp" CssClass="BottomFooterBtnsRight helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
