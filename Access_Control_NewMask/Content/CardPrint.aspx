<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CardPrint.aspx.cs" Inherits="Access_Control_NewMask.Content.CardPrint" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.2.Web, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="IE=9"/>
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
</head>
<body>
    
    <script> 
    $(document).ready(function()
    {
        PrintReport();
    });

    function PrintReport() {
        PersonalCardPrint.PerformCallback()
    }
     </script>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <dx:ASPxCallbackPanel ID="PersonalCardPrint" runat="server" OnCallback="PersonalCardPrint_Callback">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <dx:ASPxWebDocumentViewer   ID="PersonalCardPrintDocViewer" Style="width: 100%; height: 2000px;" ClientIDMode="Static" ClientInstanceName="TodayLocalASPxDocumentViewer" runat="server" Theme="Office2003Blue">
                    </dx:ASPxWebDocumentViewer>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
        </div>
    </form>
</body>
</html>
