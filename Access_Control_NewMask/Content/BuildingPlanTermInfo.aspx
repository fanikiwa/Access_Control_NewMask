<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Primary.Master" AutoEventWireup="true" CodeBehind="BuildingPlanTermInfo.aspx.cs" Inherits="Access_Control_NewMask.Content.BuildingPlanTermInfo" %>
<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/BuildingPlanTermInfo.js"></script>
    <link href="Styles/BuildingPlanTermInfo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
        <div class="termnlContn">
        <div class="dsplySec">
            <%--<section class="dvns1"></section>--%>
            <asp:Label ID="lblTerminalId" runat="server" Text="Terminal ID" CssClass="lblTerminalId"></asp:Label>
            <asp:TextBox ID="txtTerminalId" runat="server" CssClass="txtTerminalId"></asp:TextBox>

            <%--<section class="dvns3">  </section>--%>
            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="lblDscptn"></asp:Label>
            <asp:TextBox ID="txtTerminalDescription" runat="server" CssClass="txtDscptn"></asp:TextBox>

            <%--<section class="dvns2"> </section>--%>
            <asp:Label ID="lblAccessTerminal" runat="server" Text="<%$ Resources:localizedText, accessTerminal %>" CssClass="lblAccssTermnl"></asp:Label>
            <asp:TextBox ID="txtAccessTerminal" runat="server" CssClass="txtAccssTermnl"></asp:TextBox>


            <%--<section class="dvns4"></section>--%>
            <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, approvedAccess %>" CssClass="lblAuthrzEntry" style="display:none;"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="txtAuthrzEntry" style="display:none;"></asp:TextBox>

            <%--<section class="dvns5">   </section>--%>
            <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, unauthorizeAccessAttempt %>" CssClass="lblFbdnAccss" style="display:none;"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" CssClass="txtFbdnAccss" style="display:none;"></asp:TextBox>

        </div>
        <section class="contentdivbottom1">
                <section class="contentdivbottom1left">
                 <section class="contentdivbottom1left1"></section>
                    <section class="contentdivbottom1left2">
                <asp:Label ID="Label14" runat="server" Text="<%$ Resources:LocalizedText,TerminalinfoTermkonfig %>"></asp:Label>
                </section>
                     <section class="contentdivbottom1left3">
                         <asp:ImageButton ID="ImageButtonTermConfig" runat="server" CssClass="imageButton" />
                     </section>
                     <section class="contentdivbottom1left4"></section>
                </section>
              <section class="contentdivbottom1Rightopen">       </section>
                <section class="contentdivbottom1Right">
               <section class="contentdivbottom1Right1"></section>
               <section class="contentdivbottom1Right2">
                   <asp:Label ID="Label15" runat="server" Text="<%$ Resources:localizedText, AssignedReadersOnTheDoorsInTheAccessSoftware %>"></asp:Label>
               </section>
                <section class="contentdivbottom1Right3"></section>
                </section>
            </section>
        <div class="grdSec">
            <section class="gridSection"> 
                <dx:ASPxGridView ID="grvTerminalInfo" ClientInstanceName="grvTerminalInfo" runat="server" SettingsBehavior-AllowDragDrop="false" SettingsBehavior-AllowSort="false" AutoGenerateColumns="False"
                    EnableTheming="True" Theme="Office2003Blue"   OnHtmlDataCellPrepared="grvTerminalInfo_HtmlDataCellPrepared" Width="100%" >
                    <ClientSideEvents CustomButtonClick="function(s, e) {
	showProfilesInfo(s,e)
}" />
                    <Columns>

                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, readerId_new %>" Width="4%" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" FieldName="ReaderNo" ShowInCustomizationForm="True">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle HorizontalAlign="Center" Border-BorderColor="Gray" BackColor="#FFF1C6">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="5%" Caption="<%$ Resources:localizedText, readerType %>" VisibleIndex="2" FieldName="ReaderType" ShowInCustomizationForm="True">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle HorizontalAlign="Left" Border-BorderColor="Gray" BackColor="#FFF1C6">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Visible="false" Width="5%" Caption="<%$ Resources:localizedText, direction %>" VisibleIndex="3" FieldName="Direction" ShowInCustomizationForm="True">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle HorizontalAlign="Center" Border-BorderColor="Gray" BackColor="#FFF1C6">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="5%" Caption="<%$ Resources:localizedText, direction %>" VisibleIndex="4" FieldName="ReaderDirection" ShowInCustomizationForm="True">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle HorizontalAlign="Center" Border-BorderColor="Gray" BackColor="#FFF1C6">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="10%" Caption="<%$ Resources:localizedText, description1 %>" VisibleIndex="5" FieldName="ReaderDescription" ShowInCustomizationForm="True">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle HorizontalAlign="Left" Border-BorderColor="Gray" BackColor="#FFF1C6">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="4%" Caption="<%$ Resources:localizedText, relayTime %>" VisibleIndex="6" FieldName="RelayTime" ShowInCustomizationForm="True">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle HorizontalAlign="Center" Border-BorderColor="Gray" BackColor="#FFF1C6">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                         <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="5%" Caption="<%$ Resources:localizedText, status %>" VisibleIndex="7" ShowInCustomizationForm="True" FieldName="Status">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle HorizontalAlign="Center" Border-BorderColor="Gray" BackColor="#FFF1C6">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataImageColumn Caption="<%$ Resources:localizedText, connection_new %>" VisibleIndex="8" Width="5%">
                            <DataItemTemplate>
                                <dx:ASPxImage ID="terminalPointer" ImageUrl="../Images/FormImages/ArrowRightBlack.png"
                                    CssClass='<%# !this.Page.IsPostBack ? (string) Eval("BuildingName") == "" ? "terminalPointerHide" : "" : "" %>' runat="server" ShowLoadingImage="true">
                                </dx:ASPxImage>
                            </DataItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle CssClass="commandColumn">
                                <Border BorderColor="Gray" />
                            </CellStyle>
                        </dx:GridViewDataImageColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="10%" Caption="<%$ Resources:localizedText, building_new %>" VisibleIndex="9" FieldName="BuildingName" ShowInCustomizationForm="True">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle BackColor="#AADBCD" Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="10%" Caption="<%$ Resources:localizedText, level_new %>" VisibleIndex="10" FieldName="FloorName" ShowInCustomizationForm="True">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle BackColor="#AADBCD" Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="10%" Caption="<%$ Resources:localizedText, room %>" VisibleIndex="11" FieldName="RoomName" ShowInCustomizationForm="True">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle BackColor="#AADBCD" Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="10%" Caption="<%$ Resources:localizedText, door %>" VisibleIndex="12" FieldName="DoorName" ShowInCustomizationForm="True">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle BackColor="#AADBCD" Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewCommandColumn HeaderStyle-HorizontalAlign="Center" Visible="false" Width="7%" Caption="<%$ Resources:localizedText, accProfile %>" VisibleIndex="13" ShowNewButton="false" ShowEditButton="false" ButtonType="Image" ShowInCustomizationForm="True">
                            <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="accessProfileInfo" Text="Info">
                                    <Image ToolTip="Zutritt Profile Info" Url="../Images/FormImages/terminal-info.png" />
                                </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>

                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Visible="false" Width="3%" Caption="<%$ Resources:localizedText, activeTtle %>" VisibleIndex="14" FieldName="AccessProfile" ShowInCustomizationForm="True">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewCommandColumn HeaderStyle-HorizontalAlign="Center" Visible="false" Width="7%" Caption="<%$ Resources:localizedText, swProfile %>" VisibleIndex="15" ShowNewButton="false" ShowEditButton="false" ButtonType="Image" ShowInCustomizationForm="True">
                            <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="switchingProfileInfo" Text="Info">
                                    <Image ToolTip="Schalt Profile Info" Url="../Images/FormImages/terminal-info.png" />
                                </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>

                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Visible="false" Width="3%" Caption="<%$ Resources:localizedText, activeTtle %>" VisibleIndex="16" FieldName="SwitchProfile" ShowInCustomizationForm="True">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="DoorId" VisibleIndex="17" FieldName="DoorID" Visible="false">
                        </dx:GridViewDataTextColumn>
                         <dx:GridViewDataTextColumn Caption="BuildingPlanId" VisibleIndex="18" FieldName="BuildingPlanID" Visible="false">
                        </dx:GridViewDataTextColumn>
                    </Columns>

                    <SettingsBehavior AllowDragDrop="False" AllowSort="False"></SettingsBehavior>

                    <SettingsPager PageSize="31" ShowEmptyDataRows="True" Visible="False">
                    </SettingsPager>
                </dx:ASPxGridView>
            </section>
            <section class="tblSec" style="display:none;">
                <asp:Table runat="server" CssClass="tblMain" CellPadding="0" CellSpacing="0">
                    <asp:TableRow CssClass="tblRow">
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, noOfAccssPrflsPerTrmnl %>" CssClass="lblTblCell"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="Label5" runat="server" Text="Info" CssClass="lblTblCell"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText, noOfSwitchingPflPerAccssTerminal %>" CssClass="lblTblCell"></asp:Label>
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
                            <asp:ImageButton ID="accessProfile_Info"  runat="server" CssClass="imgCenters" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblSchaltProfiles" runat="server" Text="" CssClass="lblCesnterAlign"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:ImageButton ID="switchingProfile_Info"  runat="server" CssClass="imgCenters" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblHolidaySchedule" runat="server" Text="" CssClass="lblCesnterAlign"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:ImageButton ID="ImageButton1"  runat="server" CssClass="imgCenter" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="lblAccessProfileHolidays" runat="server" Text="" CssClass="lblCesnterAlign"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">

                            <asp:ImageButton ID="BuildingPlanHolidayPlanAccessProfilesPerTerminal"  runat="server" CssClass="imgCenters" />
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:Label ID="Label16" runat="server" Text="">
                          
                            </asp:Label>
                        </asp:TableCell>
                        <asp:TableCell CssClass="tblCell">
                            <asp:ImageButton ID="BuildingPlanHolidayPlanSwitchProfilesPerTerminal"  runat="server" CssClass="imgCenters" />

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
     <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBack_Click" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>