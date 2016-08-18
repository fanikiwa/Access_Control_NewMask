<%@ Page Title="Zutrittsplan Terminal Info" Language="C#" MasterPageFile="~/MasterPages/Primary.Master" AutoEventWireup="true" CodeBehind="AccessPlanTerminalInfo.aspx.cs" Inherits="Access_Control_NewMask.Content.AccessPlanTerminalInfo" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/AccessPlanTerminalInfo.js"></script>
    <link href="Styles/AccessPlanTerminalInfo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="termnlContn">
        <div class="dsplySec">
            <section class="topleft">
            <%--<section class="dvns1">  </section>--%>
                <asp:Label ID="lblTerminalId" runat="server" Text="<%$ Resources:localizedText, terminalId %>" CssClass="lblTerminalId"></asp:Label>
                <asp:TextBox ID="txtTerminalId" runat="server" CssClass="txtTerminalId"></asp:TextBox>
          
             <%--<section class="dvns3"> </section>--%>
                <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, descrption %>" CssClass="lblDscptn"></asp:Label>
                <asp:TextBox ID="txtTerminalDescription" runat="server" CssClass="txtDscptn"></asp:TextBox>
           
            <%--<section class="dvns2"></section>--%>
                <asp:Label ID="lblAccessTerminal" runat="server" Text="<%$ Resources:localizedText, accessTerminal %>" CssClass="lblAccssTermnl"></asp:Label>
                <asp:TextBox ID="txtAccessTerminal" runat="server" CssClass="txtAccssTermnl"></asp:TextBox>
            
           
            <%--<section class="dvns4"> </section>--%>
                <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, approvedAccess %>" CssClass="lblAuthrzEntry" Style="display:none"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="txtAuthrzEntry" Style="display:none"></asp:TextBox>
           
            <%--<section class="dvns5"> </section>--%>
                <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, unauthorizeAccessAttempt %>" CssClass="lblFbdnAccss" Style="display:none"></asp:Label>
                <asp:TextBox ID="TextBox4" runat="server" CssClass="txtFbdnAccss" Style="display:none"></asp:TextBox>
           </section>
        </div>
        
        <div class="grdSec">
            <section class="contentdivbottom1newab">
                <section class="contentdivbottom1leftnewab">
                 <section class="contentdivbottom1left1newab"></section>
                    <section class="contentdivbottom1left2newab">
                <asp:Label ID="Label14" runat="server" Text="<%$ Resources:LocalizedText,TerminalinfoTermkonfig %>">></asp:Label>
                </section>
                     <section class="contentdivbottom1left3newab">
                         <asp:ImageButton ID="ImageButtonTermConfig" runat="server" OnClick="ImageButtonTermConfig_Click"  CssClass="imageButton" />
                     </section>
                     <section class="contentdivbottom1left4newab"></section>
                </section>
                <section class="contentdivbottom1Rightnewab">
               <section class="contentdivbottom1Right1newab"></section>
               <section class="contentdivbottom1Right2newab">
                   <asp:Label ID="Label15" runat="server" Text="<%$ Resources:localizedText, AssignedReadersOnTheDoorsInTheAccessSoftware %>"></asp:Label>
               </section>
                <section class="contentdivbottom1Right3newab"></section>
                </section>
            </section>
            <section class="gridSection">
         
                <dx:ASPxGridView ID="grvTerminalInfo" ClientInstanceName="grvTerminalInfo" OnHtmlRowPrepared="grvTerminalInfo_HtmlRowPrepared" OnHtmlDataCellPrepared="grvTerminalInfo_HtmlDataCellPrepared" runat="server" SettingsBehavior-AllowDragDrop="false" SettingsBehavior-AllowSort="false" AutoGenerateColumns="False"
                     EnableTheming="True" Theme="Office2003Blue" Width="100%"  >
                <ClientSideEvents CustomButtonClick="function(s, e) {
	showProfilesInfo(s,e)
}" />          
                    <Columns>
                        
                        <dx:GridViewDataTextColumn VisibleIndex="0" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="4%" HeaderStyle-HorizontalAlign="Center" Caption="<%$ Resources:localizedText, readerId_new %>" VisibleIndex="1" FieldName="ReaderNo">
                            <CellStyle HorizontalAlign="Center" Border-BorderColor="Gray" BackColor="#FFF1C6"></CellStyle>
                        </dx:GridViewDataTextColumn>
                         <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="5%" Caption="<%$ Resources:localizedText, readerInfo_new %>" VisibleIndex="2" FieldName="ReaderType">
                            <CellStyle HorizontalAlign="Left" Border-BorderColor="Gray" BackColor="#FFF1C6"></CellStyle>
                        </dx:GridViewDataTextColumn>
                         <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="5%" Caption="<%$ Resources:localizedText, readerType %>" VisibleIndex="3" FieldName="Direction">
                            <CellStyle HorizontalAlign="Left" Border-BorderColor="Gray" BackColor="#FFF1C6"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="5%" Caption="<%$ Resources:localizedText, direction %>" VisibleIndex="4" FieldName="ReaderDirection">
                            <CellStyle HorizontalAlign="Center" Border-BorderColor="Gray" BackColor="#FFF1C6"></CellStyle>
                           <%-- <DataItemTemplate>
                                <dx:ASPxLabel ID="directionLabel" runat="server" Text='<%#  !this.Page.IsPostBack  ? Eval("ReaderDirection") : "" %>'
                                    ForeColor='<%# !this.Page.IsPostBack ? (string) Eval("ReaderDirection") == "Eingang" ? 
                                    System.Drawing.Color.Green : System.Drawing.Color.Red : System.Drawing.Color.Black %>'>
                                </dx:ASPxLabel>
                            </DataItemTemplate>--%>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="10%" Caption="<%$ Resources:localizedText, description2 %>" VisibleIndex="5" FieldName="ReaderDescription">
                            <CellStyle HorizontalAlign="Left" Border-BorderColor="Gray" BackColor="#FFF1C6"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="4%" Caption="<%$ Resources:localizedText, relayTime %>" VisibleIndex="6" FieldName="RelayTime">
                            <CellStyle HorizontalAlign="Center" Border-BorderColor="Gray" BackColor="#FFF1C6"></CellStyle>
                        </dx:GridViewDataTextColumn>
                               <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="5%" Caption="<%$ Resources:localizedText, status %>" VisibleIndex="7" FieldName="Status">
                            <CellStyle HorizontalAlign="Center" Border-BorderColor="Gray" BackColor="#FFF1C6"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataImageColumn Width="5%" Caption="<%$ Resources:localizedText, connection_new %>" VisibleIndex="8">
                             <DataItemTemplate>
                                    <dx:ASPxImage ID="terminalPointer"  ImageUrl="../Images/FormImages/ArrowRightBlack.png"
                                        CssClass='<%# !this.Page.IsPostBack ? (string) Eval("BuildingName") == "" ? "terminalPointerHide" : "" : "" %>' runat="server" ShowLoadingImage="true">
                                    </dx:ASPxImage>
                                </DataItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle>
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataImageColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="10%" VisibleIndex="9" Caption="<%$ Resources:localizedText, building %>" FieldName="BuildingName">
                            <CellStyle BackColor="#AADBCD" Border-BorderColor="Gray"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="10%" VisibleIndex="10" Caption="<%$ Resources:localizedText, level_new %>" FieldName="FloorName">
                            <CellStyle BackColor="#AADBCD" Border-BorderColor="Gray"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="10%" VisibleIndex="11" Caption="<%$ Resources:localizedText, room %>" FieldName="RoomName">
                            <CellStyle BackColor="#AADBCD" Border-BorderColor="Gray"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="10%" VisibleIndex="12" Caption="<%$ Resources:localizedText, door %>" FieldName="DoorName">
                            <CellStyle BackColor="#AADBCD" Border-BorderColor="Gray"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewCommandColumn HeaderStyle-HorizontalAlign="Center" Visible="false" Width="7%" Caption="<%$ Resources:localizedText, accProfile %>" VisibleIndex="13" ShowNewButton="false" ShowEditButton="false" ButtonType="Image">
                            <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="accessProfileInfo" Text="Info">
                                    <Image ToolTip="Zutritt Profile Info" Url="../Images/FormImages/terminal-info.png" />
                                </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>
                            <CellStyle Border-BorderColor="Gray"></CellStyle>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Visible="false" Width="3%" VisibleIndex="14" Caption="<%$ Resources:LocalizedText,activeTtle %>" FieldName="AccessProfile">
                            <CellStyle Border-BorderColor="Gray"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewCommandColumn HeaderStyle-HorizontalAlign="Center" Visible="false" Width="7%" Caption="<%$ Resources:localizedText, swProfile %>" VisibleIndex="15" ShowNewButton="false" ShowEditButton="false" ButtonType="Image">
                            <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="switchingProfileInfo" Text="Info">
                                    <Image ToolTip="Schalt Profile Info" Url="../Images/FormImages/terminal-info.png" />
                                </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>
                            <CellStyle Border-BorderColor="Gray"></CellStyle>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Visible="false" Width="3%" VisibleIndex="16" Caption="<%$ Resources:LocalizedText,activeTtle %>" FieldName="SwitchProfile">
                            <CellStyle Border-BorderColor="Gray"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="DoorID" FieldName="DoorID" Visible="false" VisibleIndex="17"></dx:GridViewDataTextColumn>
                         <dx:GridViewDataTextColumn Caption="BuidingPlanId" FieldName="BuildingPlanID" Visible="false" VisibleIndex="18"></dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsPager PageSize="32" ShowEmptyDataRows="True" Visible="False">
                    </SettingsPager>
                </dx:ASPxGridView> 
            </section>
            <section class="tblSec" style="display:none;">
                <asp:Table runat="server" CssClass="tblMain" CellPadding="0" CellSpacing="0">
                    <asp:TableRow CssClass="tblRow">
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:LocalizedText,noOfAccssPrflsPerTrmnl %>" CssClass="lblTblCell"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="Label5" runat="server" Text="Info" CssClass="lblTblCell"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="Label6" runat="server" Text="<%$ Resources:LocalizedText,noOfSwitchingPflPerAccssTerminal %>" CssClass="lblTblCell"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="Label7" runat="server" Text="Info" CssClass="lblTblCell"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="Label8" runat="server" Text="<%$ Resources:localizedText, holidaySchedule %>" CssClass="lblTblCell"></asp:Label>
                        </asp:TableCell>
                         <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="Label13" runat="server" Text="Info" CssClass="lblTblCell"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="Label9" runat="server" Text="<%$ Resources:localizedText, accessProfileHolidays %>" CssClass="lblTblCell"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="Label10" runat="server" Text="Info" CssClass="lblTblCell"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="Label11" runat="server" Text="<%$ Resources:localizedText, switchingPrflHoliday %>" CssClass="lblTblCell"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="Label12" runat="server" Text="Info" CssClass="lblTblCell"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                     <asp:TableRow CssClass="tblRow">
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblAccessProfiles" runat="server" Text="" CssClass="lblCesnterAlign"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:ImageButton ID="accessProfile_Info"  runat="server" CssClass="imgCenters"/>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblSchaltProfiles" runat="server" Text="" CssClass="lblCesnterAlign"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                             <asp:ImageButton ID="switchingProfile_Info"  runat="server" CssClass="imgCenters"/>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                       <asp:Label ID="lblHolidaySchedule" runat="server" Text="" CssClass="lblCesnterAlign"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:ImageButton ID="ImageButton1"  runat="server" CssClass="imgCenter"/> 
                        </asp:TableCell>
                              
                        <asp:TableCell CssClass="tblCell">
                          <asp:Label ID="lblAccessProfileHolidays" runat="server" Text="" CssClass="lblCesnterAlign"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
      
                             <asp:ImageButton ID="BuildingPlanHolidayPlanAccessProfilesPerTerminal"  runat="server" CssClass="imgCenters"/>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                           
                        </asp:TableCell>
                          <asp:TableCell CssClass="tblCell">
                            <asp:ImageButton ID="BuildingPlanHolidayPlanSwitchProfilesPerTerminal" runat="server" CssClass="imgCenters"/>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </section>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
      <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server"  Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBack_Click" />

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
