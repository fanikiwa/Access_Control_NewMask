<%@ Page Title="Besuchte Mandanten" Language="C#" MasterPageFile="~/MasterPages/Reports.Master" AutoEventWireup="true" CodeBehind="ReportsVisitorsAttendanceList.aspx.cs" Inherits="Access_Control_NewMask.Content.ReportsVisitorsAttendanceList" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/ReportsVisitorsAttendanceList.js"></script>
    <link href="Styles/ReportsVisitorsAttendanceList.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
     <div class="ContentAreaDiv">
        <div id="ControlSection1" class="TopContentAreaDiv">
            <asp:Label ID="Label1" runat="server" Text="Liste welche Besucher bei welchem Mandanten Anwesend waren" CssClass="lbltoparea"></asp:Label>
        </div>
        <div id="MainContdiv">
            <section class="midareaholder">
                <section class="topareatitles">
                    <asp:Label ID="Label2" runat="server" Text="Druck Auswahl" CssClass="lbltopareafirst"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="Druckbeginn nach" CssClass="lbltopareafirstright"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text="Selektion der Auswertungen" CssClass="lbltopareafirstrightB"></asp:Label>
                </section> 
                  <section class="areasixitemsrighttop">
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label5" runat="server" Text="Datum von:" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server" Theme="Office2003Blue" CssClass="cmbFrombottom"></dx:ASPxDateEdit>
                        <asp:Label ID="Label6" runat="server" Text="bis:" CssClass="lbltopareafirsttobottom"></asp:Label>
                          <dx:ASPxDateEdit ID="ASPxDateEdit2" runat="server" Theme="Office2003Blue" CssClass="cmbFromarea2"></dx:ASPxDateEdit> 
                        <asp:Label ID="Label7" runat="server" Text="Datum:" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        	
	
	   <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                                <asp:TableRow CssClass="rowOne">
                                      <asp:TableCell CssClass="tblCell3">
                                         <asp:CheckBox ID="chkenstri" runat="server" /><label for='chkenstri'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>  

                    </section>                  
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label40" runat="server" Text="Uhrzeit von:" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxTimeEdit ID="ASPxTimeEdit1" runat="server" Theme="Office2003Blue" CssClass="cmbFrombottom" SpinButtons-ShowIncrementButtons="false"></dx:ASPxTimeEdit>                          
                        <asp:Label ID="Label41" runat="server" Text="bis:" CssClass="lbltopareafirsttobottom"></asp:Label>
     <dx:ASPxTimeEdit ID="ASPxTimeEdit2" runat="server" Theme="Office2003Blue" CssClass="cmbFromarea2" SpinButtons-ShowIncrementButtons="false"></dx:ASPxTimeEdit>
                        <asp:Label ID="Label42" runat="server" Text="Uhrzeit:" CssClass="lbltopareafirstdatebottom"></asp:Label>
                            	
	
	   <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                                <asp:TableRow CssClass="rowOne">
                                      <asp:TableCell CssClass="tblCell3">
                                         <asp:CheckBox ID="chkPersonalDate" runat="server" /><label for='chkPersonalDate'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>  

                    </section>
                </section>
                <section class="lastvariant">
                    <asp:CheckBox ID="CheckBox1" runat="server" CssClass="chkAccssDataareaA" />
                    <asp:Label ID="Label43" runat="server" Text="Variante A" CssClass="lblvariantlastarea"></asp:Label>
                </section>
 <section class="areasixitems">
                    <asp:Label ID="Label8" runat="server" Text="Mandant von:" CssClass="lbltopareafirstdateleft"></asp:Label>
                    <dx:ASPxComboBox ID="ASPxComboBox25" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFrom"></dx:ASPxComboBox>
                    <asp:Label ID="Label35" runat="server" Text="bis:" CssClass="lbltopareafirstto"></asp:Label>
                    <dx:ASPxComboBox ID="ASPxComboBox26" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFromnew"></dx:ASPxComboBox>
                    <asp:Label ID="Label36" runat="server" Text="Mandant:" CssClass="lbltopareafirstdate"></asp:Label>
      <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlast">
                                <asp:TableRow CssClass="rowOne">
                                      <asp:TableCell CssClass="tblCell3">
                                         <asp:CheckBox ID="chkaus" runat="server" /><label for='chkaus'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>  
                    <asp:CheckBox ID="CheckBox4" runat="server" CssClass="chkAccssDataarea" />
                    <asp:Label ID="Label37" runat="server" Text="Variante B" CssClass="lblvariantlast"></asp:Label>

                </section>
                
             


                  <section class="topareatitlespers"> 
                </section>



                 <section class="areasixitemsrightlastpers">
                        <section class="areasixitemslastvariant">
                        <asp:Label ID="Label38" runat="server" Text="Firmenname von:" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="ASPxComboBox28" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFrombottom"></dx:ASPxComboBox>
                        <asp:Label ID="Label39" runat="server" Text="bis:" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="ASPxComboBox29" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFromarea2"></dx:ASPxComboBox>
                        <asp:Label ID="Label44" runat="server" Text="Besucher Firma:" CssClass="lbltopareafirstdatebottom"></asp:Label>
                     	
	
	   <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                                <asp:TableRow CssClass="rowOne">
                                      <asp:TableCell CssClass="tblCell3">
                                         <asp:CheckBox ID="chkcostcenter" runat="server" /><label for='chkcostcenter'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>  

                    </section>
                        <section class="areasixitemslastvariant">
                        <asp:Label ID="Label12" runat="server" Text="Name von:" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="ASPxComboBox16" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFrombottom"></dx:ASPxComboBox>
                        <asp:Label ID="Label26" runat="server" Text="bis:" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="ASPxComboBox17" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFromarea2"></dx:ASPxComboBox>
                        <asp:Label ID="Label27" runat="server" Text="Name von:" CssClass="lbltopareafirstdatebottom"></asp:Label>
                       	
	
	   <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                                <asp:TableRow CssClass="rowOne">
                                      <asp:TableCell CssClass="tblCell3">
                                         <asp:CheckBox ID="chkdepartment" runat="server" /><label for='chkdepartment'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>  
                    </section>
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label28" runat="server" Text="Besucher ID von:" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="ASPxComboBox19" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFrombottom"></dx:ASPxComboBox>
                        <asp:Label ID="Label29" runat="server" Text="bis:" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="ASPxComboBox20" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFromarea2"></dx:ASPxComboBox>
                        <asp:Label ID="Label30" runat="server" Text="Besucher ID:" CssClass="lbltopareafirstdatebottom"></asp:Label>
                       	
	
	   <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                                <asp:TableRow CssClass="rowOne">
                                      <asp:TableCell CssClass="tblCell3">
                                         <asp:CheckBox ID="chklocation" runat="server" /><label for='chklocation'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>   
                    </section>
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label31" runat="server" Text="Ausweis Nr. kurz von:" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="ASPxComboBox22" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFrombottom"></dx:ASPxComboBox>
                        <asp:Label ID="Label32" runat="server" Text="bis:" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="ASPxComboBox23" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFromarea2"></dx:ASPxComboBox>
                        <asp:Label ID="Label33" runat="server" Text="Ausweis Nr. kurz:" CssClass="lbltopareafirstdatebottom"></asp:Label>
                       	
	
	   <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                                <asp:TableRow CssClass="rowOne">
                                      <asp:TableCell CssClass="tblCell3">
                                         <asp:CheckBox ID="chkcompany" runat="server" /><label for='chkcompany'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>  
                    </section>
                     <section class="areasixitemslastvariant">
                        <asp:Label ID="Label9" runat="server" Text="Ausweis Nr. kurz von:" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFrombottom"></dx:ASPxComboBox>
                        <asp:Label ID="Label10" runat="server" Text="bis:" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="ASPxComboBox2" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="cmbFromarea2"></dx:ASPxComboBox>
                        <asp:Label ID="Label11" runat="server" Text="Grund des Besuches:" CssClass="lbltopareafirstdatebottom"></asp:Label>
                  	
	
	   <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                                <asp:TableRow CssClass="rowOne">
                                      <asp:TableCell CssClass="tblCell3">
                                         <asp:CheckBox ID="chkaust" runat="server" /><label for='chkaust'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>  

                    </section>
                </section>
                <section class="lastvariantC">
                    <asp:CheckBox ID="CheckBox2" runat="server" CssClass="chkAccssDataareaClast" />
                    <asp:Label ID="Label34" runat="server" Text="Variante C" CssClass="lblvariantlastarea"></asp:Label>
                </section>
            </section>

        </div>

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
           <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" ClientIDMode="Static" OnClick="btnBack_Click"/>
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
