<%@ Page Title="Dashboard Einstellungen" Language="C#" MasterPageFile="~/MasterPages/Secondary.Master" AutoEventWireup="true" CodeBehind="DashboardSettings.aspx.cs" Inherits="Access_Control_NewMask.Content.DashboardSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/DashboardSettings.js"></script>
    <link href="Styles/DashboardSettings.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="contArea">
        <div class="topCont2">
            <section class="secTopLeft">
            </section>
            <section class="secTopRight">
                <section class="secBtnHolder" style="display: none;">
                </section>
            </section>
        </div>
        <div class="bottomCont">
            <section class="DashboardSettings">
                <section class="DashboardSettingstop">
                    <asp:Label ID="Label41" runat="server" Text="<%$ Resources:localizedText, Dashboardsettings  %>" CssClass="lblDashbortSetting"></asp:Label>
                </section>
                <section class="DashboardSettingsbtm">
                    <section class="DashboardSettingsbtmlbl">
                        <asp:Label ID="Label42" runat="server" Text="<%$ Resources:localizedText, accessInformation  %>" CssClass="lblDashbortSetting"></asp:Label>
                    </section>
                    <section class="secContr">
                        <section class="secControls">
                            <asp:Label ID="Label43" runat="server" Text="<%$ Resources:localizedText, objectInformation  %>" CssClass="lblAll"></asp:Label>
                            <asp:CheckBox ID="chkObjectInfo" ClientIDMode="Static" runat="server" CssClass="checkInfomation" />
                        </section>
                        <section class="secControls">
                            <asp:Label ID="Label44" runat="server" Text="<%$ Resources:localizedText, readersActionTitle  %>" CssClass="lblAll"></asp:Label>
                            <asp:CheckBox ID="chkReaderAction2" ClientIDMode="Static" runat="server" CssClass="checkInfomation" />
                            <asp:Label ID="Label61" runat="server" Text="<%$ Resources:localizedText, reset  %>" CssClass="lblinfo"></asp:Label>
                        </section>
                        <section class="secControls">
                            <asp:Label ID="Label45" runat="server" Text="<%$ Resources:localizedText, peoplePresentTitle  %>" CssClass="lblAll"></asp:Label>
                            <asp:CheckBox ID="chkpeoplepresent" ClientIDMode="Static" runat="server" CssClass="checkInfomation" />
                            <asp:Label ID="Label62" runat="server" Text="<%$ Resources:localizedText, reset  %>" CssClass="lblinfo"></asp:Label>
                        </section>

                    </section>
                    <section class="DashboardSettingsbtmlbl">
                        <asp:Label ID="Label64" runat="server" Text="<%$ Resources:localizedText, accessCheck  %>" CssClass="lblDashbortSetting"></asp:Label>
                    </section>
                    <section class="secContr">
                        <section class="secControls">
                            <asp:Label ID="Label46" runat="server" Text="<%$ Resources:localizedText, accessCheckTitle %>" CssClass="lblAll1"></asp:Label>
                            <asp:CheckBox ID="chkAccessCheck" ClientIDMode="Static" runat="server" CssClass="checkInfomation1" />
                            <asp:Label ID="Label67" runat="server" Text="<%$ Resources:localizedText, reader %>" CssClass="lblReader"></asp:Label>
                            <asp:ImageButton ID="ImageButton3" runat="server" CssClass="imgVistrPhotoCamera" />
                        </section>
                        <section class="secControls">
                            <asp:Label ID="Label47" runat="server" Text="<%$ Resources:localizedText, insight %>" CssClass="lblAll1"></asp:Label>
                            <asp:CheckBox ID="chkInsight" ClientIDMode="Static" runat="server" CssClass="checkInfomation" />
                        </section>
                        <section class="secControls">
                            <asp:Label ID="Label49" runat="server" Text="<%$ Resources:localizedText, changes %>" CssClass="lblAll1"></asp:Label>
                            <asp:CheckBox ID="chkChanges" ClientIDMode="Static" runat="server" CssClass="checkInfomation" />
                        </section>
                    </section>
                    <section class="DashboardSettingsbtmlbl">
                        <asp:Label ID="Label65" runat="server" Text="<%$ Resources:localizedText, personalPassPhoto %>" CssClass="lblDashbortSetting"></asp:Label>
                    </section>
                    <section class="secContr">
                        <section class="secControls">
                            <asp:Label ID="Label51" runat="server" Text="<%$ Resources:localizedText, takePassportPhoto %>" CssClass="lblAll2"></asp:Label>
                            <asp:CheckBox ID="chkRecordPersPhoto" ClientIDMode="Static" runat="server" CssClass="checkInfomation1" />
                            <asp:Label ID="Label68" runat="server" Text="<%$ Resources:localizedText, camera %>" CssClass="lblCamera1"></asp:Label>
                            <asp:ImageButton ID="ImageButton2" runat="server" CssClass="btnVistrPhotoCamera" />
                        </section>
                        <section class="secControls">
                            <asp:Label ID="Label52" runat="server" Text="<%$ Resources:localizedText, employeeInspection %>" CssClass="lblAll2"></asp:Label>
                            <asp:CheckBox ID="chkPersonalInsight" ClientIDMode="Static" runat="server" CssClass="checkInfomation" />
                        </section>
                        <section class="secControls">
                            <asp:Label ID="Label54" runat="server" Text="<%$ Resources:localizedText, employeeChanges %>" CssClass="lblAll2new"></asp:Label>
                            <asp:CheckBox ID="chkPersChanges" ClientIDMode="Static" runat="server" CssClass="checkInfomation" />
                        </section>
                    </section>
                    <section class="DashboardSettingsbtmlbl">
                        <asp:Label ID="Label66" runat="server" Text="<%$ Resources:localizedText, visitorsPassportPhoto %>" CssClass="lblDashbortSetting"></asp:Label>
                    </section>
                    <section class="secContr">
                        <section class="secControls">
                            <asp:Label ID="Label56" runat="server" Text="<%$ Resources:localizedText, takePassportPhoto %>" CssClass="lblAll3"></asp:Label>
                            <asp:CheckBox ID="chkVisPersPhoto" ClientIDMode="Static" runat="server" CssClass="checkInfomation1" />
                            <asp:Label ID="Label69" runat="server" Text="<%$ Resources:localizedText, camera %>" CssClass="lblCamera"></asp:Label>
                            <asp:ImageButton ID="ImageButton1" runat="server" CssClass="btnVistrPhotoCamera2" />
                        </section>
                        <section class="secControls">
                            <asp:Label ID="Label57" runat="server" Text="<%$ Resources:localizedText, inspectVisitorData %>" CssClass="lblAll2"></asp:Label>
                            <asp:CheckBox ID="chkVisitorDtails" ClientIDMode="Static" runat="server" CssClass="checkInfomation" />
                        </section>
                        <section class="secControls">
                            <asp:Label ID="Label59" runat="server" Text="<%$ Resources:localizedText, changeVisitorData %>" CssClass="lblAll3"></asp:Label>
                            <asp:CheckBox ID="chkChangeVistrDtails" ClientIDMode="Static" runat="server" CssClass="checkInfomation" />
                        </section>
                    </section>

                </section>
            </section>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <section class="dashsettings">
     <asp:Button ID="btnSave" CssClass="BottomFooterBtnsLeft savebtnfootergreen" runat="server" Text="Einstellungen speichern" Style="width:157px" />
</section>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
     <asp:Button ID="btnBack" ClientIDMode="Static" CssClass="BottomFooterBtnsRight backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, back  %>" OnClick="btnBack_Click" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
