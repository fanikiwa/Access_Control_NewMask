<%@ Page Title="Mitglieder Zusatzbogen" Language="C#" MasterPageFile="~/MasterPages/Gate.Master" AutoEventWireup="true" CodeBehind="GateMembersform.aspx.cs" Inherits="Access_Control_NewMask.Content.GateMembersform" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/GateMembersform.js"></script>
    <link href="Styles/GateMembersform.css" rel="stylesheet" />
    <link href="Styles/FormviewsearchMembers.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            $(".btnProgress").each(function () {
                var label = $(this);
                label.after("<input type = 'text' class='txtHidden  ListenForChange' style = 'display:none; margin-left:20px; width: 100%;  margin-bottom: 5px;margin-top: 5px;' />");
                var textbox = $(this).next();
                //var id = this.id.split('_')[this.id.split('_').length - 1];
                var id = this.id;
                //console.log( id );
                textbox[0].name = id.replace("lbl", "txt");
                textbox.val(label.html());
                label.click(function (e) {
                    e.preventDefault();
                    $(this).hide();
                    $(this).next().show();
                    $(this).next().focus();
                    $($(this).next()).on("change", function (e) {
                        saveChanges = true;
                        e.preventDefault();
                        //console.log( this.id );
                    });
                });
                textbox.focusout(function () { //focusout
                    //return;
                    $('.txtHidden').each(function () { $(this).hide(); $(this).prev().show(); });
                    $(this).hide(); //hide textbox
                    $(this).prev().html($(this).val()); //set label value 
                    $(this).prev().css("color", "black");
                    $(this).prev().show();
                });
            })
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">
    <div id="ControlSection1" class="ControlSection">
        <div id="AEHeaderLeftDiv">

            <div id="BottomHeaderLabels">
                <asp:Label ID="Label45" runat="server" Text="Studio-Gruppen Nr.:" CssClass="L1HeaderT1drplablesmandant"></asp:Label>
                <dx:ASPxComboBox ID="cobMemberGroupNr" ClientInstanceName="cobMemberGroupNr" runat="server" ValueField="ID" TextField="GroupNumber" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                    TextFormatString="{0}" CssClass="lblMandant ColorBlue" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" EnableCallbackMode="true">

                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobMemberGroupNrIndexChanged(s,e);
}"
                        DropDown="function(s, e) {
dplGroupClick(s,e);		
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn Caption="Studio-Gruppen Nr:" Name="GroupNumber" FieldName="GroupNumber" Width="10%" />
                        <dx:ListBoxColumn Caption="Gruppen Bezeichnung:" Name="GroupName" FieldName="GroupName" Width="90%" />
                    </Columns>
                </dx:ASPxComboBox>
                <asp:Label ID="Label50" runat="server" Text="Gruppen Bezeichnung:" CssClass="L1HeaderT1drplables2"></asp:Label>
                <dx:ASPxComboBox ID="cobMemberGroupName" ClientInstanceName="cobMemberGroupName" ClientIDMode="Static" runat="server" ValueField="ID" TextField="GroupName" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                    TextFormatString="{1}" CssClass="L1HeaderT1drplists ColorBlue" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" EnableCallbackMode="true">

                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
cobMemberGroupNameIndexChanged(s,e);	
}"
                        DropDown="function(s, e) {
	dplGroupClick(s,e);	
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn Caption="Studio-Gruppen Nr:" Name="GroupNumber" FieldName="GroupNumber" Width="10%" />
                        <dx:ListBoxColumn Caption="Gruppen Bezeichnung:" Name="GroupName" FieldName="GroupName" Width="90%" />
                    </Columns>
                </dx:ASPxComboBox>
                <asp:Label ID="lblLocationHeader" runat="server" Text="Mitglieds Nr.:" CssClass="L1HeaderT1drplables"></asp:Label>
                <dx:ASPxComboBox ID="cobMemberNr" ClientInstanceName="cobMemberNr" runat="server" ValueField="ID" TextField="MemberNumber" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                    TextFormatString="{0}" CssClass="lblMandant ColorBlue" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" EnableCallbackMode="true" OnCallback="cobMemberNr_Callback">

                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cobMemberNrIndexChanged(s,e);
}"
                        DropDown="function(s, e) {
dpMemberClick(s,e);	
}"
                        EndCallback="function(s, e) {
cobMemberNrEndCallBack(s,e);	
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn Caption="Mitglieds Nr:" Name="MemberNumber" FieldName="MemberNumber" Width="10%" />
                        <dx:ListBoxColumn Caption="Mitgliedsname:" Name="FullName" FieldName="FullName" Width="90%" />
                    </Columns>
                </dx:ASPxComboBox>
                <asp:Label ID="lblDepartmentHeader" runat="server" Text="Mitgliedsname:" CssClass="L1HeaderT1drplablesnew"></asp:Label>
                <dx:ASPxComboBox ID="cobMemberName" ClientInstanceName="cobMemberName" runat="server" ValueField="ID" TextField="FullName" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                    TextFormatString="{1}" CssClass="L1HeaderT1drplists ColorBlue" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue" EnableCallbackMode="true" OnCallback="cobMemberName_Callback">

                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cobMemberNameIndexChanged(s,e);
}"
                        DropDown="function(s, e) {
dpMemberClick(s,e);		
}"
                        EndCallback="function(s, e) {
cobMemberNameEndCallBack(s,e);	
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn Caption="Mitglieds Nr:" Name="MemberNumber" FieldName="MemberNumber" Width="10%" />
                        <dx:ListBoxColumn Caption="Mitgliedsname:" Name="FullName" FieldName="FullName" Width="90%" />
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
                    <asp:TextBox ID="txtFvCurrentEntry" runat="server" Width="96%" Enabled="false" />
                </section>

                <section class="fvNavTotalEmpNum">
                    <asp:Label ID="lblFvTotalEntries" Text="<%$ Resources:localizedText, num %>" runat="server" />
                    <asp:TextBox ID="txtFvTotalEntries" runat="server" Width="96%" Enabled="false" />
                </section>

                <section class="fvNavNext">
                    <span></span>
                    <asp:Button ID="fvNavNext" runat="server" Text="" CssClass="btnFvNavNext" />
                </section>
            </section>
        </div>

    </div>
    <section id="uppersec" class="upperSectionPersonal">
        <asp:Button ID="btnPersonalStamm" CssClass=" newstandardbutton BottomFooterBtnsLeftdocument btnpersonal " runat="server" Text="Mitgliederstamm" />
        <asp:Button ID="btnPersonalForm" CssClass=" newstandardbutton1 BottomFooterBtnsLeftdocument2 btnbogen " runat="server" Text="<%$ Resources:localizedText, applicationForm %>" Enabled="false" Style="text-align: center;" />
        <asp:Button ID="btnPERSDOC" CssClass=" newstandardbutton BottomFooterBtnsLeftdocument btnDocumente " runat="server" Text="<%$ Resources:localizedText, document %>" />

    </section>
    <div id="tabcontroldiv" class="tabcontroldiv">
        <asp:Label ID="Label2" runat="server" Text="Zusatzfelder" CssClass="lbladdfield"></asp:Label>
        <div id="contentholdernew">
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


        </div>
        <div id="importantDialog" class="dialogBox">
        </div>
    </div>

    <div id="searchgrid" class="search2" style="display: none;">
        <section class="btnGrdSearchPersonal">
            <dx:ASPxGridView ID="grdSearchMember" ClientInstanceName="grdSearchMember" runat="server" AutoGenerateColumns="False" Theme="Office2003Blue" Width="100%" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important"
                Font-Size="12px" KeyFieldName="ID">

                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Studio-Gruppen Nr.:" VisibleIndex="1" FieldName="GroupNumber">
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Gruppen Bezeichnung:" VisibleIndex="2" FieldName="GroupName">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Mitglieds Nr.:" VisibleIndex="3" FieldName="MemberNumber">
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Mitgliedsname:" VisibleIndex="4" FieldName="FullName">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="false" AllowDragDrop="false"></SettingsBehavior>
                <SettingsPager PageSize="33" ShowEmptyDataRows="True">
                </SettingsPager>
            </dx:ASPxGridView>
        </section>
        <section class="btnApplySec">
            <asp:Button ID="btnApplyMember" runat="server" Text="Übernehmen" CssClass="ubernahme" />
        </section>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnNew" CssClass="newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newButton %>" Style="display: none; width: 46px;" />
    <asp:Button ID="btnSave" CssClass="savebtnfootergreen" runat="server" Text="Daten speichern" Style="width: 102px; padding-left: 2px; " />
    <asp:Button ID="btnDelete" CssClass="deletebtnfooterred" runat="server" Text="Daten löschen" Style="width: 103px; display: none;" />
    <%--  <asp:Button ID="btnNew" CssClass="BottomFooterBtnsLeft newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newPersonal %>" />
    <asp:Button ID="btnSave" CssClass="BottomFooterBtnsLeft savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, savePersonal %>" />
    <asp:Button ID="btnDelete" CssClass="BottomFooterBtnsLeft deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deletePersonal %>" />--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="BottomFooterBtnsRight backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBack_Click" />
    <asp:Button ID="btnHelp" ClientIDMode="Static" CssClass="BottomFooterBtnsRight helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
