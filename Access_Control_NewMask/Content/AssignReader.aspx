<%@ Page Title="<%$ Resources:localizedText, buildingPlan %>" Language="C#" MasterPageFile="~/MasterPages/Primary.Master" AutoEventWireup="true" CodeBehind="AssignReader.aspx.cs" Inherits="Access_Control_NewMask.Content.AssignReader" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/AssignReader.js"></script>
    <link href="Styles/AssignReader.css" rel="stylesheet" />
    <link href="Styles/SaveDeleteDialog.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
        <div id="terminalDIV" class="contentdiv">
        

        <div class="contentdivtopNew">
            <asp:Label ID="Label1" runat="server" Text="Terminal ID" CssClass="L1HeaderT1drplables2"></asp:Label>
            <dx:ASPxComboBox ID="ddlTerminalId" ClientInstanceName="ddlTerminalId" ValueField="TerminalID" TextField="TermID"  runat="server" CssClass="L1HeaderT1drplists2" TextFormatString="{0}" DropDownWidth="400px" DropDownRows="20" Theme="Office2003Blue">

                <ClientSideEvents SelectedIndexChanged="function(s, e) {
terminalSelectedChanged(s,e);	
}"
                    DropDown="function(s, e) {
	dropdownClicked(s,e);
}"></ClientSideEvents>
                <Columns>
                     <dx:ListBoxColumn Caption="Nr:" FieldName="TermID" Name="TermID" Width="15%" />
                         <dx:ListBoxColumn Caption="<%$ Resources:LocalizedText,description1 %>" FieldName="TerminalDescription" Name="TerminalDescription" Width="60%" />
                     <dx:ListBoxColumn Caption="<%$ Resources:LocalizedText,accessTerminal %>" FieldName="TermType" Name="TermType" Width="25%" />
                </Columns>
            </dx:ASPxComboBox>

            <asp:Label ID="Label4" runat="server" Text="<%$ Resources:LocalizedText,description1 %>" CssClass="L1HeaderT1drplablesdescription "></asp:Label>
            <dx:ASPxComboBox ID="ddlTerminalDescription" ClientInstanceName="ddlTerminalDescription" ValueField="TerminalID" TextField="TerminalDescription" runat="server" CssClass="L1HeaderT1drplists2description" TextFormatString="{1}" DropDownWidth="400px" DropDownRows="20" Theme="Office2003Blue">
                <ClientSideEvents SelectedIndexChanged="function(s, e) {
terminalSelectedChanged(s,e);	
}"
                    DropDown="function(s, e) {
dropdownClicked(s,e);	
}"></ClientSideEvents>
                <Columns>
                     <dx:ListBoxColumn Caption="Nr:" FieldName="TermID" Name="TermID" Width="15%" />
                         <dx:ListBoxColumn Caption="<%$ Resources:LocalizedText,description1 %>" FieldName="TerminalDescription" Name="TerminalDescription" Width="60%" />
                     <dx:ListBoxColumn Caption="<%$ Resources:LocalizedText,accessTerminal %>" FieldName="TermType" Name="TermType" Width="25%" />
                </Columns>
            </dx:ASPxComboBox> 
            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:LocalizedText,accessTerminal %>" CssClass="L1HeaderT1drplables2new"></asp:Label>
            <dx:ASPxComboBox ID="ddlTerminalControlUnit" ClientInstanceName="ddlTerminalControlUnit" ValueField="TerminalID" TextField="TermType" runat="server" CssClass="L1HeaderT1drplistsnew" TextFormatString="{2}" DropDownWidth="400px" DropDownRows="20" Theme="Office2003Blue">
                <ClientSideEvents SelectedIndexChanged="function(s, e) {
terminalSelectedChanged(s,e);	
}"
                   DropDown="function(s, e) {
dropdownClicked(s,e);	
}"></ClientSideEvents>
                 <Columns>
                     <dx:ListBoxColumn Caption="Nr:" FieldName="TermID" Name="TermID" Width="15%" />
                         <dx:ListBoxColumn Caption="<%$ Resources:LocalizedText,description1 %>" FieldName="TerminalDescription" Name="TerminalDescription" Width="60%" />
                     <dx:ListBoxColumn Caption="<%$ Resources:LocalizedText,accessTerminal %>" FieldName="TermType" Name="TermType" Width="25%" />
                </Columns>
            </dx:ASPxComboBox>
       

            <asp:Label ID="Label5" runat="server" Text="<%$ Resources:LocalizedText,viewAllTerminals %>" CssClass="L1HeaderT1drplablesall"></asp:Label>
            <asp:CheckBox ID="chkShowAll" runat="server" CssClass="chekcbox" />
            <asp:Button ID="btnTerminalInfo" runat="server" Text="Terminal Info"  CssClass="newstandardbutton Terminalinfo btnTerminalInfo" OnClick="btnTerminalInfo_Click" />
            <section class="sec2">
                <section class="griddatemover">
                    <section class="griddatemoverleft">
                        <asp:Button ID="btnTerminalPrevious" runat="server" Text=""  CssClass="korbtnFvNavPrevNr" />
                    </section>
                    <section class="griddatemovercenter">
                        <asp:TextBox ID="txtSelectedTerminal" Theme="Aqua" Enabled="false" CssClass="ddlYearStyle" runat="server"></asp:TextBox>
                        <%--<asp:DropDownList ID="ddlTariffYear" runat="server" Theme="Aqua" ValueType="System.String" AutoPostBack="True" Style="min-width: 100%;" CssClass="ddlYearStyle"></asp:DropDownList>--%>
                    </section>
                    <section class="griddatemoverright">
                        <asp:Button ID="btnTerminalNext" runat="server" Text=""  CssClass="korbtnFvNavNexNrt" />
                    </section>
                </section>
            </section>

        </div>
        <div class="secTopGrid" > <%--style="display:none"--%>
            <asp:Label ID="Label7" runat="server" Text="<%$ Resources:LocalizedText,doorselection %>" CssClass="doorselection"></asp:Label>
           <%-- <dx:ASPxGridView ID="grdDoorDetails" ClientInstanceName="grdDoorDetails" SettingsBehavior-AllowSort="false" runat="server" Width="100%" Theme="Office2003Blue" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="ReaderId"
                OnHtmlDataCellPrepared="grdDoorDetails_HtmlDataCellPrepared" OnHtmlRowPrepared="grdDoorDetails_HtmlRowPrepared">
                <ClientSideEvents CustomButtonClick="function(s, e) {
	showTerminalInfoDoor(s,e)
}" />
                <Columns>
                    <dx:GridViewDataTextColumn Visible="False" VisibleIndex="0" FieldName="ReaderId"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="4%" Caption="<%$ Resources:localizedText, terminalId %>" ReadOnly="true" VisibleIndex="1" FieldName="TermID">
                        <EditFormSettings Visible="False" />

                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <CellStyle HorizontalAlign="Center" BackColor="#FFF1C6" Border-BorderColor="Gray">
                            <Border BorderColor="Gray"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Left" Width="15%" Caption="<%$ Resources:localizedText, terminalDscptn %>" ReadOnly="true" VisibleIndex="2" FieldName="TerminalDescription">
                        <EditFormSettings Visible="False" />

                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray">
                            <Border BorderColor="Gray"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="4%" VisibleIndex="3" Caption="Leser ID" FieldName="ReaderNo">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <CellStyle HorizontalAlign="Center" BackColor="#FFF1C6" Border-BorderColor="Gray">
                            <Border BorderColor="Gray"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="5%" VisibleIndex="4" Caption="Richtung" FieldName="Direction">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <CellStyle HorizontalAlign="Center" BackColor="#FFF1C6" Border-BorderColor="Gray">
                            <Border BorderColor="Gray"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="15%" VisibleIndex="5" Caption=" Leser Bezeichnung" FieldName="ReaderDescription">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <CellStyle HorizontalAlign="Left" BackColor="#FFF1C6" Border-BorderColor="Gray">
<Border BorderColor="Gray"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Visible="False" HeaderStyle-HorizontalAlign="Center" Width="4%" VisibleIndex="6" Caption="Relaiszeit">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <CellStyle HorizontalAlign="Center" BackColor="#FFF1C6" Border-BorderColor="Gray">
                            <Border BorderColor="Gray"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                     <dx:GridViewDataImageColumn Caption="Verbindung" VisibleIndex="7" Width="4%">
                        <DataItemTemplate>
                                    <dx:ASPxImage ID="terminalPointer"  ImageUrl="../Images/FormImages/ArrowRightBlack.png"
                                        CssClass='<%# this.Page.IsPostBack ? (string) Eval("ReaderDescription") == "" ? "terminalPointerHide" : "" : "" %>' runat="server" ShowLoadingImage="true">
                                    </dx:ASPxImage>
                                </DataItemTemplate>
                         <EditItemTemplate>
                                    <dx:ASPxImage ID="terminalPointer"  ImageUrl="../Images/FormImages/ArrowRightBlack.png"
                                        CssClass='<%# this.Page.IsPostBack ? (string) Eval("ReaderDescription") == "" ? "terminalPointerHide" : "" : "" %>' runat="server" ShowLoadingImage="true">
                                    </dx:ASPxImage>
                        </EditItemTemplate>
                         <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataImageColumn>
                    <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="12%" VisibleIndex="8" Caption="Gebäude" FieldName="BuildingName">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <CellStyle BackColor="#AADBCD" Border-BorderColor="Gray">
                            <Border BorderColor="Gray"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="12%" VisibleIndex="9" Caption="Ebene" FieldName="FloorName">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <CellStyle BackColor="#AADBCD" Border-BorderColor="Gray">
                            <Border BorderColor="Gray"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="12%" VisibleIndex="10" Caption="Raum" FieldName="RoomName">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <CellStyle BackColor="#AADBCD" Border-BorderColor="Gray">
                            <Border BorderColor="Gray"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="12%" VisibleIndex="11" Caption="Tür" FieldName="DoorName">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <CellStyle BackColor="#AADBCD" Border-BorderColor="Gray">
                            <Border BorderColor="Gray"></Border>
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataCheckColumn HeaderStyle-HorizontalAlign="Center" Width="4%" Caption="<%$ Resources:localizedText, assigned %>" VisibleIndex="12" FieldName="ReaderAssigned">
                        <PropertiesCheckEdit ValueChecked="True"></PropertiesCheckEdit>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <CellStyle BackColor="#ADDCCB" Border-BorderColor="Gray">
                            <Border BorderColor="Gray"></Border>
                        </CellStyle>
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewCommandColumn HeaderStyle-HorizontalAlign="Center" Width="3%" Caption="Info" VisibleIndex="13" ShowNewButton="false" ShowEditButton="false" ButtonType="Image">
                        <CustomButtons>
                            <dx:GridViewCommandColumnCustomButton ID="terminalInfoGrdDoorDetails" Text="Info">
                                <Image ToolTip="TermKonfig" Url="../Images/FormImages/TMK-Info.png" />
                            </dx:GridViewCommandColumnCustomButton>
                        </CustomButtons>

                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <CellStyle BackColor="#AADBCD" Border-BorderColor="Gray">
                            <Border BorderColor="Gray"></Border>
                        </CellStyle>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewCommandColumn Visible="False" HeaderStyle-HorizontalAlign="Center" Width="4%" VisibleIndex="14" Caption="Zutrittsprofile info" ShowNewButton="false" ShowEditButton="false" ButtonType="Image">
                        <CustomButtons>
                            <dx:GridViewCommandColumnCustomButton ID="AccessProfileInfo" Text="Info">
                                <Image ToolTip="Zutrittsprofile Info" Url="../Images/FormImages/terminal-info.png" />
                            </dx:GridViewCommandColumnCustomButton>
                        </CustomButtons>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Visible="False" HeaderStyle-HorizontalAlign="Center" Width="4%" VisibleIndex="15" Caption="Aktiv" FieldName="AccessProfile">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewCommandColumn Visible="False" HeaderStyle-HorizontalAlign="Center" Width="4%" VisibleIndex="16" Caption="Schaltprofile info" ShowNewButton="false" ShowEditButton="false" ButtonType="Image">
                        <CustomButtons>
                            <dx:GridViewCommandColumnCustomButton ID="SwitchProfileInfo" Text="Info">
                                <Image ToolTip="Schaltprofile Info" Url="../Images/FormImages/terminal-info.png" />
                            </dx:GridViewCommandColumnCustomButton>
                        </CustomButtons>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Visible="False" HeaderStyle-HorizontalAlign="Center" Width="4%" VisibleIndex="17" Caption="Aktiv" FieldName="SwitchProfile">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>                   
                </Columns>

<SettingsBehavior AllowSort="False"></SettingsBehavior>

                <SettingsPager Visible="False" ShowEmptyDataRows="True" PageSize="1"></SettingsPager>
            </dx:ASPxGridView>--%>
               <section class="sectable">
                         <asp:Table runat="server" GridLines="Vertical" CellSpacing="1" CellPadding="1" BorderStyle="Solid" BorderWidth="1px" Font-Size="Medium" ForeColor="" Width="100%" Height="100%">
                              <asp:TableHeaderRow Height="10%" Width="100%" BorderStyle="Solid" BorderWidth="1px">
                                <asp:TableCell CssClass="tablecell2"> <asp:Label ID="Label59" runat="server" Text="<%$ Resources:localizedText, location1 %>"></asp:Label> </asp:TableCell>
                                 <asp:TableCell CssClass="tablecell"> <asp:Label ID="lblLocation" runat="server"  CssClass="LabelTextFormat" Text=""></asp:Label></asp:TableCell>
                                <asp:TableCell CssClass="tablecell2"> <asp:Label ID="Label61" runat="server" Text="<%$ Resources:localizedText, building2 %>"></asp:Label></asp:TableCell>
                                <asp:TableCell CssClass="tablecell">  <asp:Label ID="lblBuilding" runat="server"  CssClass="LabelTextFormat" Text=""></asp:Label></asp:TableCell>
                                <asp:TableCell CssClass="tablecell2"><asp:Label ID="Label63" runat="server" Text="<%$ Resources:localizedText, floor2 %>"></asp:Label></asp:TableCell>
                                <asp:TableCell CssClass="tablecell"><asp:Label ID="lblFloor" runat="server"  CssClass="LabelTextFormat" Text=""></asp:Label></asp:TableCell>
                                <asp:TableCell CssClass="tablecell2"><asp:Label ID="Label65" runat="server" Text="<%$ Resources:localizedText, room2 %>"></asp:Label></asp:TableCell>
                                <asp:TableCell CssClass="tablecell"> <asp:Label ID="lblRoom" runat="server"  CssClass="LabelTextFormat" Text=""></asp:Label></asp:TableCell>
                                   <asp:TableCell CssClass="tablecell2"><asp:Label ID="Label8" runat="server" Text="<%$ Resources:localizedText, door2 %>"></asp:Label></asp:TableCell>
                                <asp:TableCell CssClass="tablecell"> <asp:Label ID="lblDoor" runat="server" CssClass="LabelTextFormat" Text=""></asp:Label></asp:TableCell>
                              
                             </asp:TableHeaderRow>                           
                             
                         </asp:Table>                        
                       </section>

        </div>
        <div class="contentdivbottomNew">
            <section class="contentdivbottom1">
                <section class="contentdivbottom1left">
                 <section class="contentdivbottom1left1"></section>
                    <section class="contentdivbottom1left2new015">
                <asp:Label ID="Label3" runat="server" Text="Leserzuordnung aus der Termkonfig"></asp:Label>
                </section>
                     <section class="contentdivbottom1left3">
                         <asp:ImageButton ID="ImageButtonTermConfig" runat="server" CssClass="imageButton" />
                     </section>
                     <section class="contentdivbottom1left4"></section>
                </section>
                <section class="contentdivbottom1Right">
               <section class="contentdivbottom1Right1"></section>
               <section class="contentdivbottom1Right2new015">
                   <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText, AssignedReadersOnTheDoorsInTheAccessSoftware %>"></asp:Label>
               </section>
                <section class="contentdivbottom1Right3"></section>
                </section>
            </section>
            <section class="contentdivbottomgrind"> 
                <dx:ASPxGridView ID="grdReaders" ClientInstanceName="grdReaders" runat="server" AutoGenerateColumns="False" SettingsBehavior-AllowDragDrop="false"
                    SettingsBehavior-AllowSort="false" EnableTheming="True" Theme="Office2003Blue" Width="100%" KeyFieldName="ReaderId" OnBatchUpdate="grdReaders_BatchUpdate"
                  EnableCallBacks="true" OnCustomCallback="grdReaders_CustomCallback" OnHtmlDataCellPrepared="grdReaders_HtmlDataCellPrepared" OnHtmlRowPrepared="grdReaders_HtmlRowPrepared" OnDataBound="grdReaders_DataBound" 
                    OnHtmlCommandCellPrepared="grdReaders_HtmlCommandCellPrepared" OnCustomButtonInitialize="grdReaders_CustomButtonInitialize" >
                    
                    <ClientSideEvents CustomButtonClick="function(s, e) {
	showTerminalInfo(s,e)
}" />
          

                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ReaderID" VisibleIndex="0" Visible="false" FieldName="ReaderId">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="4%" Caption="<%$ Resources:localizedText, terminalId %>" ReadOnly="true" VisibleIndex="1" FieldName="TermID">
                            <EditFormSettings Visible="False" />

                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle HorizontalAlign="Center" BackColor="#FFF1C6" Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="15%" Caption="<%$ Resources:localizedText, terminalDscptn %>" ReadOnly="true" VisibleIndex="2" FieldName="TerminalDescription">
                            <EditFormSettings Visible="False" />

                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <%--<dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, accessTerminal %>" ReadOnly="true" VisibleIndex="2" FieldName="TermType">
                          <EditFormSettings Visible="False"/>
                         </dx:GridViewDataTextColumn>--%>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="4%" Caption="Leser ID" ReadOnly="true" VisibleIndex="3" FieldName="ReaderNo">
                            <EditFormSettings Visible="False" />

                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle HorizontalAlign="Center" BackColor="#FFF1C6" Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="5%" Caption="<%$ Resources:localizedText, direction %>" Visible="false" ReadOnly="true" VisibleIndex="4" FieldName="Direction">
                            <EditFormSettings Visible="False" />
                           
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle HorizontalAlign="Center" BackColor="#FFF1C6" Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                         <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="5%" Caption="<%$ Resources:localizedText, direction %>" ReadOnly="true" VisibleIndex="5" FieldName="ReaderDirection">
                            <EditFormSettings Visible="False" />
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle HorizontalAlign="Center" BackColor="#FFF1C6" Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="15%" Caption="<%$ Resources:localizedText, readerDescptn %>" ReadOnly="true" VisibleIndex="6" FieldName="ReaderDescription">
                            <EditFormSettings Visible="False" />

                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                         <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="4%" Caption="<%$ Resources:localizedText, status %>" ReadOnly="true" VisibleIndex="7" FieldName="Status">
                            <EditFormSettings Visible="False" />

                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle BackColor="#FFF1C6" Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                            <dx:GridViewDataImageColumn Width="4%" Caption="<%$ Resources:localizedText, connection %>"  VisibleIndex="8" >
                                <DataItemTemplate>
                                    <dx:ASPxImage ID="terminalPointer"  ImageUrl="../Images/FormImages/ArrowRightBlack.png"
                                         CssClass='<%# GetSelectedValue()> 0 ?( CheckIfQueryStringExists(this.Request.QueryString["sTd"]) > 0 || this.Page.IsPostBack ? (string) Eval("BuildingName") == "" ? "terminalPointerHide" : "" : ""):"" %>' runat="server" ShowLoadingImage="true">
                                    </dx:ASPxImage>
                                </DataItemTemplate>
                                <EditItemTemplate>
                                   <dx:ASPxImage ID="terminalPointer"  ImageUrl="../Images/FormImages/ArrowRightBlack.png"
                                        CssClass='<%# GetSelectedValue()> 0 ? (CheckIfQueryStringExists(this.Request.QueryString["sTd"]) > 0 || this.Page.IsPostBack ? (string) Eval("BuildingName") == "" ? "terminalPointerHide" : "" : ""):"" %>' runat="server" ShowLoadingImage="true">
                                    </dx:ASPxImage>
                                </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle>
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataImageColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="12%" Caption="<%$ Resources:localizedText, building %>" ReadOnly="true" VisibleIndex="9" FieldName="BuildingName">
                            <EditFormSettings Visible="False" />

                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle BackColor="#ADDCCB" Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="12%" Caption="<%$ Resources:localizedText, level %>" ReadOnly="true" VisibleIndex="10" FieldName="FloorName">
                            <EditFormSettings Visible="False" />

                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle BackColor="#ADDCCB" Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="12%" Caption="<%$ Resources:localizedText, room %>" ReadOnly="true" VisibleIndex="11" FieldName="RoomName">
                            <EditFormSettings Visible="False" />

                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle BackColor="#ADDCCB" Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Width="12%" Caption="<%$ Resources:localizedText, door %>" ReadOnly="true" VisibleIndex="12" FieldName="DoorName">
                            <EditFormSettings Visible="False" />

                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle BackColor="#ADDCCB" Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                       <dx:GridViewDataCheckColumn  HeaderStyle-HorizontalAlign="Center" Width="4%"  Caption="<%$ Resources:localizedText, assigned %>" VisibleIndex="13" Visible="true" FieldName="ReaderAssigned">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle BackColor="#ADDCCB" Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                          <%-- <DataItemTemplate>
                               <dx:ASPxCheckBox ID="chk" runat="server" Value='<%# Eval("ReaderAssigned") %>' OnInit="chk_Init"></dx:ASPxCheckBox>
                           </DataItemTemplate>--%>
                        </dx:GridViewDataCheckColumn>
                        <%-- <dx:GridViewCommandColumn ShowSelectCheckbox="True"  ShowClearFilterButton="True"  HeaderStyle-HorizontalAlign="Center" Width="4%" Caption="<%$ Resources:localizedText, assigned %>" VisibleIndex="13" >
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle BackColor="#ADDCCB" Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewCommandColumn>--%>
                        <dx:GridViewCommandColumn HeaderStyle-HorizontalAlign="Center" Width="3%" Caption="Info" VisibleIndex="14" ShowNewButton="false" ShowEditButton="false" ButtonType="Image">
                            <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="terminalInfo" Text="Info">
                                    <Image ToolTip="Terminal Info" Url="../Images/FormImages/18pxorange.png" />
                                </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>

                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <CellStyle BackColor="#AADBCD" Border-BorderColor="Gray">
                                <Border BorderColor="Gray"></Border>
                            </CellStyle>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn Caption="DoorId" VisibleIndex="15" Visible="false" FieldName="DoorID">

                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="BuidingPlanId" VisibleIndex="16" Visible="false" FieldName="BuildingPlanID">

                        </dx:GridViewDataTextColumn>
                    
                    </Columns>

                    <SettingsBehavior AllowDragDrop="False" AllowSort="False"></SettingsBehavior>

                    <SettingsPager PageSize="20" ShowEmptyDataRows="True" Visible="False">
                    </SettingsPager>
                    <SettingsEditing Mode="Batch">
                        <BatchEditSettings ShowConfirmOnLosingChanges="False" />
                    </SettingsEditing>
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="True" AllowInsert="False" />
                    <Settings ShowStatusBar="Hidden" />
                </dx:ASPxGridView>
                 <%--<dx:XpoDataSource ID="xds" runat="server" TypeName="MyObject">
                  </dx:XpoDataSource>--%>
                <dx:ASPxCallback ID="cb" runat="server" ClientInstanceName="cb" >
            </dx:ASPxCallback>
            </section>
        </div>

    </div>
    <div id="confirmSave">

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
     <asp:Button ID="btnTake" CssClass="editbtnfooterorange" runat="server" Text="<%$ Resources:localizedText, takeover %>"  Style="width: 92px !important; padding-left:0 !important;"/>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
        <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>"  OnClick="btnBack_Click"/>
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
