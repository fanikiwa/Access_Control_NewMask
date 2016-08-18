using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Web;
using Access_Control_NewMask.Dtos;

/// <summary>
/// Summary description for MembersAttendanceReport
/// </summary>
public class MembersAttendanceReport : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRTable xrTable2;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell30;
    private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
    private PageHeaderBand pageHeaderBand1;
    private XRTable xrTable1;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell29;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private PageFooterBand pageFooterBand1;
    private XRPageInfo xrPageInfo2;
    private ReportHeaderBand reportHeaderBand1;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private DevExpress.DataAccess.ObjectBinding.ObjectDataSource AccessLogReportsDto;
    private XRPanel xrPanel1;
    private XRTable xrTable12;
    private XRTableRow xrTableRow14;
    private XRTableCell xrTableCell139;
    private XRTableCell xrTableCell140;
    private XRPageInfo xrPageInfo4;
    private XRTable xrTable13;
    private XRTableRow xrTableRow15;
    private XRTableCell xrTableCell141;
    private XRPageInfo xrPageInfo1;
    private XRTable xrTable16;
    private XRTableRow xrTableRow18;
    private XRTableCell xrTableCell146;
    private XRTableCell xrTableCell147;
    private XRTable xrTable15;
    private XRTableRow xrTableRow17;
    private XRTableCell xrTableCell152;
    private XRTableCell xrTableCell153;
    private XRTable xrTable6;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell41;
    private XRTableCell xrTableCell42;
    private XRTable xrTable3;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell32;
    private XRTable xrTable18;
    private XRTableRow xrTableRow20;
    private XRTableCell xrTableCell71;
    private XRTableCell xrTableCell50;
    private XRTableCell xrTableCell49;
    private XRLabel xrLabel1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public MembersAttendanceReport()
    {
        InitializeComponent();
        this.DataSource = HttpContext.Current.Session["AccessLogReportsDto"];

        //
        // TODO: Add constructor logic here
        //

        if (HttpContext.Current.Session["acReport"] != null)
        {
            var acReport = (AccessReportSettings_DTO)HttpContext.Current.Session["acReport"];
             
            if (!acReport.DisplayMemberDate)
            {
                xrTable1.DeleteColumn(xrTableCell7);
                xrTable2.DeleteColumn(xrTableCell8);
            }

            if (!acReport.DisplayMemberGroup)
            {
                xrTable1.DeleteColumn(xrTableCell13);
                xrTable2.DeleteColumn(xrTableCell14);
            }

            if (!acReport.DisplayMemberName)
            {
                xrTable1.DeleteColumn(xrTableCell15);
                xrTable2.DeleteColumn(xrTableCell16);
            }

            if (!acReport.DisplayMemberId)
            {
                xrTable1.DeleteColumn(xrTableCell49);
                xrTable2.DeleteColumn(xrTableCell50);
            }

            if (!acReport.DisplayMemberContractNr)
            {
                xrTable1.DeleteColumn(xrTableCell17);
                xrTable2.DeleteColumn(xrTableCell18);
            }

            if (!acReport.DisplayMemberCardNr)
            {
                xrTable1.DeleteColumn(xrTableCell19);
                xrTable2.DeleteColumn(xrTableCell20);
            }


            if (!acReport.DisplayExpiryDate)
            {
                xrTable1.DeleteColumn(xrTableCell25);
                xrTable2.DeleteColumn(xrTableCell26);
            }

            if (!acReport.DisplayMemberEntry)
            {
                xrTable1.DeleteColumn(xrTableCell27);
                xrTable2.DeleteColumn(xrTableCell28);
            }

            if (!acReport.DisplayMemberExit)
            {
                xrTable1.DeleteColumn(xrTableCell29);
                xrTable2.DeleteColumn(xrTableCell30);
            }
        }
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.pageHeaderBand1 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.pageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrTable12 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow14 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell139 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell140 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPageInfo4 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrTable13 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow15 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell141 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrTable16 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow18 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell146 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell147 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable15 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow17 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell152 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell153 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable18 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow20 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.AccessLogReportsDto = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccessLogReportsDto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail.HeightF = 13.83331F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable2
            // 
            this.xrTable2.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(3.999812F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1040F, 13.83331F);
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell8,
            this.xrTableCell14,
            this.xrTableCell16,
            this.xrTableCell50,
            this.xrTableCell18,
            this.xrTableCell20,
            this.xrTableCell26,
            this.xrTableCell28,
            this.xrTableCell30});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell8.CanGrow = false;
            this.xrTableCell8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BookingDate", "{0:dd.MM.yyyy}")});
            this.xrTableCell8.Font = new System.Drawing.Font("Tahoma", 7F);
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell8.StyleName = "DataField";
            this.xrTableCell8.StylePriority.UseBorderColor = false;
            this.xrTableCell8.StylePriority.UseBorders = false;
            this.xrTableCell8.StylePriority.UseFont = false;
            this.xrTableCell8.StylePriority.UsePadding = false;
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell8.Weight = 14.3145645857414D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell14.CanGrow = false;
            this.xrTableCell14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MemberGroup")});
            this.xrTableCell14.Font = new System.Drawing.Font("Tahoma", 7F);
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell14.StyleName = "DataField";
            this.xrTableCell14.StylePriority.UseBorderColor = false;
            this.xrTableCell14.StylePriority.UseBorders = false;
            this.xrTableCell14.StylePriority.UseFont = false;
            this.xrTableCell14.StylePriority.UsePadding = false;
            this.xrTableCell14.Weight = 17.0884805071848D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell16.CanGrow = false;
            this.xrTableCell16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Name")});
            this.xrTableCell16.Font = new System.Drawing.Font("Tahoma", 7F);
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell16.StyleName = "DataField";
            this.xrTableCell16.StylePriority.UseBorderColor = false;
            this.xrTableCell16.StylePriority.UseBorders = false;
            this.xrTableCell16.StylePriority.UseFont = false;
            this.xrTableCell16.StylePriority.UsePadding = false;
            this.xrTableCell16.Weight = 14.1794976334009D;
            // 
            // xrTableCell50
            // 
            this.xrTableCell50.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell50.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell50.CanGrow = false;
            this.xrTableCell50.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ID_Nr")});
            this.xrTableCell50.Font = new System.Drawing.Font("Tahoma", 7F);
            this.xrTableCell50.Name = "xrTableCell50";
            this.xrTableCell50.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell50.StylePriority.UseBorderColor = false;
            this.xrTableCell50.StylePriority.UseBorders = false;
            this.xrTableCell50.StylePriority.UseFont = false;
            this.xrTableCell50.StylePriority.UsePadding = false;
            this.xrTableCell50.Weight = 10.6186170075238D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell18.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell18.CanGrow = false;
            this.xrTableCell18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AgreementNr", "{0:dd/MM/yy}")});
            this.xrTableCell18.Font = new System.Drawing.Font("Tahoma", 7F);
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell18.StyleName = "DataField";
            this.xrTableCell18.StylePriority.UseBorderColor = false;
            this.xrTableCell18.StylePriority.UseBorders = false;
            this.xrTableCell18.StylePriority.UseFont = false;
            this.xrTableCell18.StylePriority.UsePadding = false;
            this.xrTableCell18.Weight = 9.35428699839767D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell20.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell20.CanGrow = false;
            this.xrTableCell20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CardNumber", "{0:HH:mm}")});
            this.xrTableCell20.Font = new System.Drawing.Font("Tahoma", 7F);
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell20.StyleName = "DataField";
            this.xrTableCell20.StylePriority.UseBorderColor = false;
            this.xrTableCell20.StylePriority.UseBorders = false;
            this.xrTableCell20.StylePriority.UseFont = false;
            this.xrTableCell20.StylePriority.UsePadding = false;
            this.xrTableCell20.Weight = 9.85054023601965D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell26.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell26.CanGrow = false;
            this.xrTableCell26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ExpiryDate", "{0:dd.MM.yyyy}")});
            this.xrTableCell26.Font = new System.Drawing.Font("Tahoma", 7F);
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell26.StyleName = "DataField";
            this.xrTableCell26.StylePriority.UseBorderColor = false;
            this.xrTableCell26.StylePriority.UseBorders = false;
            this.xrTableCell26.StylePriority.UseFont = false;
            this.xrTableCell26.StylePriority.UsePadding = false;
            this.xrTableCell26.StylePriority.UseTextAlignment = false;
            this.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell26.Weight = 12.0465573623813D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell28.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell28.CanGrow = false;
            this.xrTableCell28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "EntryDate", "{0:HH:mm}")});
            this.xrTableCell28.Font = new System.Drawing.Font("Tahoma", 7F);
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell28.StyleName = "DataField";
            this.xrTableCell28.StylePriority.UseBorderColor = false;
            this.xrTableCell28.StylePriority.UseBorders = false;
            this.xrTableCell28.StylePriority.UseFont = false;
            this.xrTableCell28.StylePriority.UsePadding = false;
            this.xrTableCell28.StylePriority.UseTextAlignment = false;
            this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell28.Weight = 8.52424628962755D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell30.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell30.CanGrow = false;
            this.xrTableCell30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ExitDate", "{0:HH:mm}")});
            this.xrTableCell30.Font = new System.Drawing.Font("Tahoma", 7F);
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell30.StyleName = "DataField";
            this.xrTableCell30.StylePriority.UseBorderColor = false;
            this.xrTableCell30.StylePriority.UseBorders = false;
            this.xrTableCell30.StylePriority.UseFont = false;
            this.xrTableCell30.StylePriority.UsePadding = false;
            this.xrTableCell30.StylePriority.UseTextAlignment = false;
            this.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell30.Weight = 11.3983133331609D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 81F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // pageHeaderBand1
            // 
            this.pageHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.pageHeaderBand1.HeightF = 20.83333F;
            this.pageHeaderBand1.Name = "pageHeaderBand1";
            // 
            // xrTable1
            // 
            this.xrTable1.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(3.999729F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1040F, 20.83333F);
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrTableCell13,
            this.xrTableCell15,
            this.xrTableCell49,
            this.xrTableCell17,
            this.xrTableCell19,
            this.xrTableCell25,
            this.xrTableCell27,
            this.xrTableCell29});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell7.CanGrow = false;
            this.xrTableCell7.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell7.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell7.StyleName = "FieldCaption";
            this.xrTableCell7.StylePriority.UseBorderColor = false;
            this.xrTableCell7.StylePriority.UseBorders = false;
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.StylePriority.UseForeColor = false;
            this.xrTableCell7.StylePriority.UsePadding = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "Datum";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell7.Weight = 14.9867024030441D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell13.CanGrow = false;
            this.xrTableCell13.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell13.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell13.StyleName = "FieldCaption";
            this.xrTableCell13.StylePriority.UseBorderColor = false;
            this.xrTableCell13.StylePriority.UseBorders = false;
            this.xrTableCell13.StylePriority.UseFont = false;
            this.xrTableCell13.StylePriority.UseForeColor = false;
            this.xrTableCell13.StylePriority.UsePadding = false;
            this.xrTableCell13.Text = "Studiogruppe";
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell13.Weight = 17.8908582623849D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell15.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell15.CanGrow = false;
            this.xrTableCell15.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell15.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell15.StyleName = "FieldCaption";
            this.xrTableCell15.StylePriority.UseBorderColor = false;
            this.xrTableCell15.StylePriority.UseBorders = false;
            this.xrTableCell15.StylePriority.UseFont = false;
            this.xrTableCell15.StylePriority.UseForeColor = false;
            this.xrTableCell15.StylePriority.UsePadding = false;
            this.xrTableCell15.Text = "Name";
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell15.Weight = 14.8452863532841D;
            // 
            // xrTableCell49
            // 
            this.xrTableCell49.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell49.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell49.CanGrow = false;
            this.xrTableCell49.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell49.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell49.Name = "xrTableCell49";
            this.xrTableCell49.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell49.StylePriority.UseBorderColor = false;
            this.xrTableCell49.StylePriority.UseBorders = false;
            this.xrTableCell49.StylePriority.UseFont = false;
            this.xrTableCell49.StylePriority.UseForeColor = false;
            this.xrTableCell49.StylePriority.UsePadding = false;
            this.xrTableCell49.StylePriority.UseTextAlignment = false;
            this.xrTableCell49.Text = "Mitglied ID Nr.:";
            this.xrTableCell49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell49.Weight = 11.1171892232758D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell17.CanGrow = false;
            this.xrTableCell17.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell17.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell17.StyleName = "FieldCaption";
            this.xrTableCell17.StylePriority.UseBorderColor = false;
            this.xrTableCell17.StylePriority.UseBorders = false;
            this.xrTableCell17.StylePriority.UseFont = false;
            this.xrTableCell17.StylePriority.UseForeColor = false;
            this.xrTableCell17.StylePriority.UsePadding = false;
            this.xrTableCell17.Text = "Vertrags Nr.";
            this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell17.Weight = 9.79354986141304D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell19.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell19.CanGrow = false;
            this.xrTableCell19.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell19.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell19.StyleName = "FieldCaption";
            this.xrTableCell19.StylePriority.UseBorderColor = false;
            this.xrTableCell19.StylePriority.UseBorders = false;
            this.xrTableCell19.StylePriority.UseFont = false;
            this.xrTableCell19.StylePriority.UseForeColor = false;
            this.xrTableCell19.StylePriority.UsePadding = false;
            this.xrTableCell19.Text = "Ausweis Nr.";
            this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell19.Weight = 10.3130795864679D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell25.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell25.CanGrow = false;
            this.xrTableCell25.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell25.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell25.StyleName = "FieldCaption";
            this.xrTableCell25.StylePriority.UseBorderColor = false;
            this.xrTableCell25.StylePriority.UseBorders = false;
            this.xrTableCell25.StylePriority.UseFont = false;
            this.xrTableCell25.StylePriority.UseForeColor = false;
            this.xrTableCell25.StylePriority.UsePadding = false;
            this.xrTableCell25.StylePriority.UseTextAlignment = false;
            this.xrTableCell25.Text = "Gültig bis";
            this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell25.Weight = 12.6121964281937D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell27.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell27.CanGrow = false;
            this.xrTableCell27.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell27.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell27.StyleName = "FieldCaption";
            this.xrTableCell27.StylePriority.UseBorderColor = false;
            this.xrTableCell27.StylePriority.UseBorders = false;
            this.xrTableCell27.StylePriority.UseFont = false;
            this.xrTableCell27.StylePriority.UseForeColor = false;
            this.xrTableCell27.StylePriority.UsePadding = false;
            this.xrTableCell27.StylePriority.UseTextAlignment = false;
            this.xrTableCell27.Text = "Eintritt";
            this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell27.Weight = 8.92448298072641D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell29.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell29.CanGrow = false;
            this.xrTableCell29.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell29.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell29.StyleName = "FieldCaption";
            this.xrTableCell29.StylePriority.UseBorderColor = false;
            this.xrTableCell29.StylePriority.UseBorders = false;
            this.xrTableCell29.StylePriority.UseFont = false;
            this.xrTableCell29.StylePriority.UseForeColor = false;
            this.xrTableCell29.StylePriority.UsePadding = false;
            this.xrTableCell29.StylePriority.UseTextAlignment = false;
            this.xrTableCell29.Text = "Austritt";
            this.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell29.Weight = 11.9334949063407D;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "xrTableCell1";
            this.xrTableCell1.Weight = 1D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "xrTableCell2";
            this.xrTableCell2.Weight = 1D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "xrTableCell3";
            this.xrTableCell3.Weight = 1D;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "xrTableCell4";
            this.xrTableCell4.Weight = 1D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "xrTableCell5";
            this.xrTableCell5.Weight = 1D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "xrTableCell6";
            this.xrTableCell6.Weight = 1D;
            // 
            // pageFooterBand1
            // 
            this.pageFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2});
            this.pageFooterBand1.HeightF = 29.00001F;
            this.pageFooterBand1.Name = "pageFooterBand1";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Format = "Seite {0} von {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(605.9999F, 0F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(438F, 23F);
            this.xrPageInfo2.StyleName = "PageInfo";
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel1});
            this.reportHeaderBand1.HeightF = 131.6666F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // xrPanel1
            // 
            this.xrPanel1.BorderColor = System.Drawing.Color.Gray;
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable12,
            this.xrPageInfo4,
            this.xrTable13,
            this.xrPageInfo1,
            this.xrTable16,
            this.xrTable15,
            this.xrTable6,
            this.xrTable3,
            this.xrTable18,
            this.xrLabel1});
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(3.999812F, 46.66667F);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(1040F, 74.99995F);
            this.xrPanel1.StylePriority.UseBorderColor = false;
            this.xrPanel1.StylePriority.UseBorders = false;
            // 
            // xrTable12
            // 
            this.xrTable12.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTable12.LocationFloat = new DevExpress.Utils.PointFloat(795.8336F, 26.8334F);
            this.xrTable12.Name = "xrTable12";
            this.xrTable12.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow14});
            this.xrTable12.SizeF = new System.Drawing.SizeF(234.1664F, 14.16666F);
            this.xrTable12.StylePriority.UseBorders = false;
            // 
            // xrTableRow14
            // 
            this.xrTableRow14.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell139,
            this.xrTableCell140});
            this.xrTableRow14.Name = "xrTableRow14";
            this.xrTableRow14.Weight = 1D;
            // 
            // xrTableCell139
            // 
            this.xrTableCell139.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell139.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell139.Name = "xrTableCell139";
            this.xrTableCell139.StylePriority.UseBorders = false;
            this.xrTableCell139.StylePriority.UseFont = false;
            this.xrTableCell139.StylePriority.UseTextAlignment = false;
            this.xrTableCell139.Text = "Erstellt von:";
            this.xrTableCell139.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            this.xrTableCell139.Weight = 1.39192324017656D;
            // 
            // xrTableCell140
            // 
            this.xrTableCell140.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LogedInUser")});
            this.xrTableCell140.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.xrTableCell140.Name = "xrTableCell140";
            this.xrTableCell140.StylePriority.UseFont = false;
            this.xrTableCell140.StylePriority.UseTextAlignment = false;
            this.xrTableCell140.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            this.xrTableCell140.Weight = 3.32276461126878D;
            // 
            // xrPageInfo4
            // 
            this.xrPageInfo4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPageInfo4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo4.Format = "{0:dd.MM.yyyy}";
            this.xrPageInfo4.LocationFloat = new DevExpress.Utils.PointFloat(551.8917F, 51.16666F);
            this.xrPageInfo4.Name = "xrPageInfo4";
            this.xrPageInfo4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
            this.xrPageInfo4.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo4.SizeF = new System.Drawing.SizeF(58.33002F, 14.16666F);
            this.xrPageInfo4.StylePriority.UseBorders = false;
            this.xrPageInfo4.StylePriority.UseFont = false;
            this.xrPageInfo4.StylePriority.UsePadding = false;
            // 
            // xrTable13
            // 
            this.xrTable13.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTable13.LocationFloat = new DevExpress.Utils.PointFloat(476.982F, 51.16666F);
            this.xrTable13.Name = "xrTable13";
            this.xrTable13.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow15});
            this.xrTable13.SizeF = new System.Drawing.SizeF(74.90958F, 14.16666F);
            this.xrTable13.StylePriority.UseBorders = false;
            // 
            // xrTableRow15
            // 
            this.xrTableRow15.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell141});
            this.xrTableRow15.Name = "xrTableRow15";
            this.xrTableRow15.Weight = 1D;
            // 
            // xrTableCell141
            // 
            this.xrTableCell141.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell141.Name = "xrTableCell141";
            this.xrTableCell141.StylePriority.UseFont = false;
            this.xrTableCell141.Text = "Gedruckt am:";
            this.xrTableCell141.Weight = 4.07186405635624D;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPageInfo1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.xrPageInfo1.Format = "{0:HH:mm}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(707.8899F, 51.16666F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 13, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(65.92999F, 14.16666F);
            this.xrPageInfo1.StylePriority.UseBorders = false;
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UsePadding = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTable16
            // 
            this.xrTable16.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTable16.LocationFloat = new DevExpress.Utils.PointFloat(656.4303F, 26.83334F);
            this.xrTable16.Name = "xrTable16";
            this.xrTable16.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow18});
            this.xrTable16.SizeF = new System.Drawing.SizeF(117.39F, 14.16666F);
            this.xrTable16.StylePriority.UseBorders = false;
            // 
            // xrTableRow18
            // 
            this.xrTableRow18.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell146,
            this.xrTableCell147});
            this.xrTableRow18.Name = "xrTableRow18";
            this.xrTableRow18.Weight = 1D;
            // 
            // xrTableCell146
            // 
            this.xrTableCell146.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell146.Name = "xrTableCell146";
            this.xrTableCell146.StylePriority.UseFont = false;
            this.xrTableCell146.Text = "bis:";
            this.xrTableCell146.Weight = 1.2974474566875747D;
            // 
            // xrTableCell147
            // 
            this.xrTableCell147.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BookingDateTo", "{0:dd.MM.yyyy}")});
            this.xrTableCell147.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell147.Name = "xrTableCell147";
            this.xrTableCell147.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 0, 0, 0, 100F);
            this.xrTableCell147.StylePriority.UseFont = false;
            this.xrTableCell147.StylePriority.UsePadding = false;
            this.xrTableCell147.StylePriority.UseTextAlignment = false;
            this.xrTableCell147.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell147.Weight = 1.6622757268438555D;
            // 
            // xrTable15
            // 
            this.xrTable15.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTable15.LocationFloat = new DevExpress.Utils.PointFloat(476.9821F, 26.83334F);
            this.xrTable15.Name = "xrTable15";
            this.xrTable15.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow17});
            this.xrTable15.SizeF = new System.Drawing.SizeF(133.24F, 14.16666F);
            this.xrTable15.StylePriority.UseBorders = false;
            // 
            // xrTableRow17
            // 
            this.xrTableRow17.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell152,
            this.xrTableCell153});
            this.xrTableRow17.Name = "xrTableRow17";
            this.xrTableRow17.Weight = 1D;
            // 
            // xrTableCell152
            // 
            this.xrTableCell152.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell152.Name = "xrTableCell152";
            this.xrTableCell152.StylePriority.UseFont = false;
            this.xrTableCell152.Text = "Datum von:";
            this.xrTableCell152.Weight = 1.9982032251018793D;
            // 
            // xrTableCell153
            // 
            this.xrTableCell153.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BookingDateFrom", "{0:dd.MM.yyyy}")});
            this.xrTableCell153.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.xrTableCell153.Name = "xrTableCell153";
            this.xrTableCell153.StylePriority.UseFont = false;
            this.xrTableCell153.Weight = 1.5559364101585622D;
            // 
            // xrTable6
            // 
            this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(266.5537F, 26.83337F);
            this.xrTable6.Name = "xrTable6";
            this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8});
            this.xrTable6.SizeF = new System.Drawing.SizeF(197.6725F, 14.16667F);
            // 
            // xrTableRow8
            // 
            this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell41,
            this.xrTableCell42});
            this.xrTableRow8.Name = "xrTableRow8";
            this.xrTableRow8.Weight = 1D;
            // 
            // xrTableCell41
            // 
            this.xrTableCell41.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell41.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.StylePriority.UseBorders = false;
            this.xrTableCell41.StylePriority.UseFont = false;
            this.xrTableCell41.StylePriority.UseTextAlignment = false;
            this.xrTableCell41.Text = "bis:";
            this.xrTableCell41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            this.xrTableCell41.Weight = 0.4571621767600752D;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell42.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MemberGroupTo")});
            this.xrTableCell42.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.StylePriority.UseBorders = false;
            this.xrTableCell42.StylePriority.UseFont = false;
            this.xrTableCell42.Weight = 3.2313434153021059D;
            // 
            // xrTable3
            // 
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(5F, 26.83334F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
            this.xrTable3.SizeF = new System.Drawing.SizeF(240.1313F, 14.16666F);
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell31,
            this.xrTableCell32});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell31.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.StylePriority.UseBorders = false;
            this.xrTableCell31.StylePriority.UseFont = false;
            this.xrTableCell31.StylePriority.UseTextAlignment = false;
            this.xrTableCell31.Text = "Studio Gruppe von:";
            this.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            this.xrTableCell31.Weight = 1.9407890317238D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MemberGroupFrom")});
            this.xrTableCell32.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.StylePriority.UseBorders = false;
            this.xrTableCell32.StylePriority.UseFont = false;
            this.xrTableCell32.Weight = 2.52427174797699D;
            // 
            // xrTable18
            // 
            this.xrTable18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTable18.LocationFloat = new DevExpress.Utils.PointFloat(656.4304F, 51.16666F);
            this.xrTable18.Name = "xrTable18";
            this.xrTable18.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow20});
            this.xrTable18.SizeF = new System.Drawing.SizeF(51.45953F, 14.16666F);
            this.xrTable18.StylePriority.UseFont = false;
            // 
            // xrTableRow20
            // 
            this.xrTableRow20.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell71});
            this.xrTableRow20.Name = "xrTableRow20";
            this.xrTableRow20.Weight = 1D;
            // 
            // xrTableCell71
            // 
            this.xrTableCell71.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell71.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell71.Name = "xrTableCell71";
            this.xrTableCell71.StylePriority.UseBorders = false;
            this.xrTableCell71.StylePriority.UseFont = false;
            this.xrTableCell71.Text = "Uhrzeit:";
            this.xrTableCell71.Weight = 3.35610260009766D;
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.Title.ForeColor = System.Drawing.Color.Maroon;
            this.Title.Name = "Title";
            // 
            // FieldCaption
            // 
            this.FieldCaption.BackColor = System.Drawing.Color.Transparent;
            this.FieldCaption.BorderColor = System.Drawing.Color.Black;
            this.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.FieldCaption.BorderWidth = 1F;
            this.FieldCaption.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.FieldCaption.ForeColor = System.Drawing.Color.Maroon;
            this.FieldCaption.Name = "FieldCaption";
            // 
            // PageInfo
            // 
            this.PageInfo.BackColor = System.Drawing.Color.Transparent;
            this.PageInfo.BorderColor = System.Drawing.Color.Black;
            this.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PageInfo.BorderWidth = 1F;
            this.PageInfo.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.PageInfo.ForeColor = System.Drawing.Color.Black;
            this.PageInfo.Name = "PageInfo";
            // 
            // DataField
            // 
            this.DataField.BackColor = System.Drawing.Color.Transparent;
            this.DataField.BorderColor = System.Drawing.Color.Black;
            this.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataField.BorderWidth = 1F;
            this.DataField.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.DataField.ForeColor = System.Drawing.Color.Black;
            this.DataField.Name = "DataField";
            this.DataField.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(4.500001F, 1.999992F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(240.6313F, 17.17F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UsePadding = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Anwesenheitsliste Mitglieder";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // AccessLogReportsDto
            // 
            this.AccessLogReportsDto.DataSource = typeof(Access_Control_NewMask.Dtos.AccessLogReportsDto);
            this.AccessLogReportsDto.Name = "AccessLogReportsDto";
            // 
            // MembersAttendanceReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.pageHeaderBand1,
            this.pageFooterBand1,
            this.reportHeaderBand1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.AccessLogReportsDto});
            this.DataSource = this.AccessLogReportsDto;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(24, 12, 0, 81);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
            this.Version = "15.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccessLogReportsDto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
