﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Web;
using Access_Control_NewMask.Dtos;

/// <summary>
/// Summary description for AccessPersonalProtocalReportPortrait
/// </summary>
public class AccessPersonalProtocalReportPortrait : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRTable xrTable2;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell34;
    private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
    private PageHeaderBand pageHeaderBand1;
    private XRTable xrTable1;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell33;
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
    private XRPanel xrPanel1;
    private XRTable xrTable11;
    private XRTableRow xrTableRow13;
    private XRTableCell xrTableCell47;
    private XRTableCell xrTableCell48;
    private XRTable xrTable12;
    private XRTableRow xrTableRow14;
    private XRTableCell xrTableCell139;
    private XRTableCell xrTableCell140;
    private XRTable xrTable10;
    private XRTableRow xrTableRow12;
    private XRTableCell xrTableCell39;
    private XRTableCell xrTableCell40;
    private XRTable xrTable9;
    private XRTableRow xrTableRow11;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell38;
    private XRPageInfo xrPageInfo4;
    private XRTable xrTable13;
    private XRTableRow xrTableRow15;
    private XRTableCell xrTableCell141;
    private XRTable xrTable17;
    private XRTableRow xrTableRow19;
    private XRTableCell xrTableCell148;
    private XRTableCell xrTableCell149;
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
    private XRTable xrTable8;
    private XRTableRow xrTableRow10;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell36;
    private XRTable xrTable7;
    private XRTableRow xrTableRow9;
    private XRTableCell xrTableCell43;
    private XRTableCell xrTableCell44;
    private XRTable xrTable3;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell45;
    private XRTableCell xrTableCell46;
    private XRTable xrTable4;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell49;
    private XRTableCell xrTableCell50;
    private XRTable xrTable18;
    private XRTableRow xrTableRow20;
    private XRTableCell xrTableCell71;
    private XRTable xrTable5;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell51;
    private XRTableCell xrTableCell52;
    private XRLabel xrLabel1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public AccessPersonalProtocalReportPortrait()
    {
        InitializeComponent();
        this.DataSource = HttpContext.Current.Session["AccessLogReportsDto"];
        //
        // TODO: Add constructor logic here
        //
        if (HttpContext.Current.Session["acReport"] != null)
        {
            var acReport = (AccessReportSettings_DTO)HttpContext.Current.Session["acReport"];

            if (!acReport.DisplayBPLocation)
            {
                xrTable1.DeleteColumn(xrTableCell7);
                xrTable2.DeleteColumn(xrTableCell8);
            }

            if (!acReport.DisplayBPBuilding)
            {
                xrTable1.DeleteColumn(xrTableCell9);
                xrTable2.DeleteColumn(xrTableCell10);
            }

            if (!acReport.DisplayBPFloor)
            {
                xrTable1.DeleteColumn(xrTableCell11);
                xrTable2.DeleteColumn(xrTableCell12);
            }

            if (!acReport.DisplayBPRoom)
            {
                xrTable1.DeleteColumn(xrTableCell13);
                xrTable2.DeleteColumn(xrTableCell14);
            }

            if (!acReport.DisplayClient)
            {
                xrTable1.DeleteColumn(xrTableCell21);
                xrTable2.DeleteColumn(xrTableCell22);
            }
            if (!acReport.DisplayCostCenter)
            {
                xrTable1.DeleteColumn(xrTableCell25);
                xrTable2.DeleteColumn(xrTableCell26);
            }
            if (!acReport.DisplayDepartment)
            {
                xrTable1.DeleteColumn(xrTableCell27);
                xrTable2.DeleteColumn(xrTableCell28);
            }

            if (!acReport.DisplayLongTermCard)
            {
                xrTable1.DeleteColumn(xrTableCell31);
                xrTable2.DeleteColumn(xrTableCell32);
            }
            
            if (!acReport.DisplayShortTermCard)
            {
                xrTable1.DeleteColumn(xrTableCell33);
                xrTable2.DeleteColumn(xrTableCell34);
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
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.pageHeaderBand1 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
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
            this.xrTable11 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow13 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable12 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow14 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell139 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell140 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable10 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow12 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable9 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPageInfo4 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrTable13 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow15 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell141 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable17 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow19 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell148 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell149 = new DevExpress.XtraReports.UI.XRTableCell();
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
            this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable7 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable18 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow20 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
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
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable2.SizeF = new System.Drawing.SizeF(769.9999F, 13.83331F);
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell8,
            this.xrTableCell10,
            this.xrTableCell12,
            this.xrTableCell14,
            this.xrTableCell16,
            this.xrTableCell18,
            this.xrTableCell20,
            this.xrTableCell22,
            this.xrTableCell24,
            this.xrTableCell26,
            this.xrTableCell28,
            this.xrTableCell30,
            this.xrTableCell32,
            this.xrTableCell34});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell8.CanGrow = false;
            this.xrTableCell8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BPLocation")});
            this.xrTableCell8.Font = new System.Drawing.Font("Tahoma", 6F);
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell8.StyleName = "DataField";
            this.xrTableCell8.StylePriority.UseBorderColor = false;
            this.xrTableCell8.StylePriority.UseBorders = false;
            this.xrTableCell8.StylePriority.UseFont = false;
            this.xrTableCell8.StylePriority.UsePadding = false;
            this.xrTableCell8.Text = "xrTableCell8";
            this.xrTableCell8.Weight = 6.97136617196491D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell10.CanGrow = false;
            this.xrTableCell10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BPBuilding")});
            this.xrTableCell10.Font = new System.Drawing.Font("Tahoma", 6F);
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell10.StyleName = "DataField";
            this.xrTableCell10.StylePriority.UseBorderColor = false;
            this.xrTableCell10.StylePriority.UseBorders = false;
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.StylePriority.UsePadding = false;
            this.xrTableCell10.Text = "xrTableCell10";
            this.xrTableCell10.Weight = 6.64711735636514D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell12.CanGrow = false;
            this.xrTableCell12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BPLevel")});
            this.xrTableCell12.Font = new System.Drawing.Font("Tahoma", 6F);
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell12.StyleName = "DataField";
            this.xrTableCell12.StylePriority.UseBorderColor = false;
            this.xrTableCell12.StylePriority.UseBorders = false;
            this.xrTableCell12.StylePriority.UseFont = false;
            this.xrTableCell12.StylePriority.UsePadding = false;
            this.xrTableCell12.Text = "xrTableCell12";
            this.xrTableCell12.Weight = 6.76725813509283D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell14.CanGrow = false;
            this.xrTableCell14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BPRoom")});
            this.xrTableCell14.Font = new System.Drawing.Font("Tahoma", 6F);
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell14.StyleName = "DataField";
            this.xrTableCell14.StylePriority.UseBorderColor = false;
            this.xrTableCell14.StylePriority.UseBorders = false;
            this.xrTableCell14.StylePriority.UseFont = false;
            this.xrTableCell14.StylePriority.UsePadding = false;
            this.xrTableCell14.Text = "xrTableCell14";
            this.xrTableCell14.Weight = 4.55158316290336D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell16.CanGrow = false;
            this.xrTableCell16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BPDoor")});
            this.xrTableCell16.Font = new System.Drawing.Font("Tahoma", 6F);
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell16.StyleName = "DataField";
            this.xrTableCell16.StylePriority.UseBorderColor = false;
            this.xrTableCell16.StylePriority.UseBorders = false;
            this.xrTableCell16.StylePriority.UseFont = false;
            this.xrTableCell16.StylePriority.UsePadding = false;
            this.xrTableCell16.Text = "xrTableCell16";
            this.xrTableCell16.Weight = 5.99418866720117D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell18.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell18.CanGrow = false;
            this.xrTableCell18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BookingDate", "{0:dd.MM.yyyy}")});
            this.xrTableCell18.Font = new System.Drawing.Font("Tahoma", 6F);
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell18.StyleName = "DataField";
            this.xrTableCell18.StylePriority.UseBorderColor = false;
            this.xrTableCell18.StylePriority.UseBorders = false;
            this.xrTableCell18.StylePriority.UseFont = false;
            this.xrTableCell18.StylePriority.UsePadding = false;
            this.xrTableCell18.StylePriority.UseTextAlignment = false;
            this.xrTableCell18.Text = "xrTableCell18";
            this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell18.Weight = 6.14966070837525D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell20.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell20.CanGrow = false;
            this.xrTableCell20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BookingTime", "{0:HH:mm}")});
            this.xrTableCell20.Font = new System.Drawing.Font("Tahoma", 6F);
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell20.StyleName = "DataField";
            this.xrTableCell20.StylePriority.UseBorderColor = false;
            this.xrTableCell20.StylePriority.UseBorders = false;
            this.xrTableCell20.StylePriority.UseFont = false;
            this.xrTableCell20.StylePriority.UsePadding = false;
            this.xrTableCell20.StylePriority.UseTextAlignment = false;
            this.xrTableCell20.Text = "xrTableCell20";
            this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell20.Weight = 5.43945222533043D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell22.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell22.CanGrow = false;
            this.xrTableCell22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PersClient")});
            this.xrTableCell22.Font = new System.Drawing.Font("Tahoma", 6F);
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell22.StyleName = "DataField";
            this.xrTableCell22.StylePriority.UseBorderColor = false;
            this.xrTableCell22.StylePriority.UseBorders = false;
            this.xrTableCell22.StylePriority.UseFont = false;
            this.xrTableCell22.StylePriority.UsePadding = false;
            this.xrTableCell22.Text = "xrTableCell22";
            this.xrTableCell22.Weight = 9.06741872742942D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell24.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell24.CanGrow = false;
            this.xrTableCell24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PersLocation")});
            this.xrTableCell24.Font = new System.Drawing.Font("Tahoma", 6F);
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell24.StyleName = "DataField";
            this.xrTableCell24.StylePriority.UseBorderColor = false;
            this.xrTableCell24.StylePriority.UseBorders = false;
            this.xrTableCell24.StylePriority.UseFont = false;
            this.xrTableCell24.StylePriority.UsePadding = false;
            this.xrTableCell24.Text = "xrTableCell24";
            this.xrTableCell24.Weight = 7.74963640323235D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell26.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell26.CanGrow = false;
            this.xrTableCell26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PersCostCenter")});
            this.xrTableCell26.Font = new System.Drawing.Font("Tahoma", 6F);
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell26.StyleName = "DataField";
            this.xrTableCell26.StylePriority.UseBorderColor = false;
            this.xrTableCell26.StylePriority.UseBorders = false;
            this.xrTableCell26.StylePriority.UseFont = false;
            this.xrTableCell26.StylePriority.UsePadding = false;
            this.xrTableCell26.Text = "xrTableCell26";
            this.xrTableCell26.Weight = 8.78914536709446D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell28.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell28.CanGrow = false;
            this.xrTableCell28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PersDepartement")});
            this.xrTableCell28.Font = new System.Drawing.Font("Tahoma", 6F);
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell28.StyleName = "DataField";
            this.xrTableCell28.StylePriority.UseBorderColor = false;
            this.xrTableCell28.StylePriority.UseBorders = false;
            this.xrTableCell28.StylePriority.UseFont = false;
            this.xrTableCell28.StylePriority.UsePadding = false;
            this.xrTableCell28.Text = "xrTableCell28";
            this.xrTableCell28.Weight = 7.94219187063702D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell30.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell30.CanGrow = false;
            this.xrTableCell30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Name")});
            this.xrTableCell30.Font = new System.Drawing.Font("Tahoma", 6F);
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell30.StyleName = "DataField";
            this.xrTableCell30.StylePriority.UseBorderColor = false;
            this.xrTableCell30.StylePriority.UseBorders = false;
            this.xrTableCell30.StylePriority.UseFont = false;
            this.xrTableCell30.StylePriority.UsePadding = false;
            this.xrTableCell30.Text = "xrTableCell30";
            this.xrTableCell30.Weight = 7.93030358241665D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell32.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell32.CanGrow = false;
            this.xrTableCell32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CardNumber")});
            this.xrTableCell32.Font = new System.Drawing.Font("Tahoma", 6F);
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell32.StyleName = "DataField";
            this.xrTableCell32.StylePriority.UseBorderColor = false;
            this.xrTableCell32.StylePriority.UseBorders = false;
            this.xrTableCell32.StylePriority.UseFont = false;
            this.xrTableCell32.StylePriority.UsePadding = false;
            this.xrTableCell32.Text = "xrTableCell32";
            this.xrTableCell32.Weight = 9.03961037740476D;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell34.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell34.CanGrow = false;
            this.xrTableCell34.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CardNumbershort")});
            this.xrTableCell34.Font = new System.Drawing.Font("Tahoma", 6F);
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell34.StyleName = "DataField";
            this.xrTableCell34.StylePriority.UseBorderColor = false;
            this.xrTableCell34.StylePriority.UseBorders = false;
            this.xrTableCell34.StylePriority.UseFont = false;
            this.xrTableCell34.StylePriority.UsePadding = false;
            this.xrTableCell34.Text = "xrTableCell34";
            this.xrTableCell34.Weight = 9.26182524478596D;
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
            this.BottomMargin.HeightF = 0F;
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
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable1.SizeF = new System.Drawing.SizeF(769.9999F, 20.83333F);
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrTableCell9,
            this.xrTableCell11,
            this.xrTableCell13,
            this.xrTableCell15,
            this.xrTableCell17,
            this.xrTableCell19,
            this.xrTableCell21,
            this.xrTableCell23,
            this.xrTableCell25,
            this.xrTableCell27,
            this.xrTableCell29,
            this.xrTableCell31,
            this.xrTableCell33});
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
            this.xrTableCell7.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.xrTableCell7.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell7.StyleName = "FieldCaption";
            this.xrTableCell7.StylePriority.UseBackColor = false;
            this.xrTableCell7.StylePriority.UseBorderColor = false;
            this.xrTableCell7.StylePriority.UseBorders = false;
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.StylePriority.UseForeColor = false;
            this.xrTableCell7.StylePriority.UsePadding = false;
            this.xrTableCell7.Text = "Standort";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell7.Weight = 7.16666666666667D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell9.CanGrow = false;
            this.xrTableCell9.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.xrTableCell9.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell9.StyleName = "FieldCaption";
            this.xrTableCell9.StylePriority.UseBorderColor = false;
            this.xrTableCell9.StylePriority.UseBorders = false;
            this.xrTableCell9.StylePriority.UseFont = false;
            this.xrTableCell9.StylePriority.UseForeColor = false;
            this.xrTableCell9.StylePriority.UsePadding = false;
            this.xrTableCell9.Text = "Gebäude";
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell9.Weight = 6.83333333333333D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell11.CanGrow = false;
            this.xrTableCell11.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.xrTableCell11.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell11.StyleName = "FieldCaption";
            this.xrTableCell11.StylePriority.UseBorderColor = false;
            this.xrTableCell11.StylePriority.UseBorders = false;
            this.xrTableCell11.StylePriority.UseFont = false;
            this.xrTableCell11.StylePriority.UseForeColor = false;
            this.xrTableCell11.StylePriority.UsePadding = false;
            this.xrTableCell11.Text = "Ebene";
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell11.Weight = 6.95683951723732D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell13.CanGrow = false;
            this.xrTableCell13.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.xrTableCell13.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell13.StyleName = "FieldCaption";
            this.xrTableCell13.StylePriority.UseBorderColor = false;
            this.xrTableCell13.StylePriority.UseBorders = false;
            this.xrTableCell13.StylePriority.UseFont = false;
            this.xrTableCell13.StylePriority.UseForeColor = false;
            this.xrTableCell13.StylePriority.UsePadding = false;
            this.xrTableCell13.Text = "Raum";
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell13.Weight = 4.67909053162927D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell15.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell15.CanGrow = false;
            this.xrTableCell15.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.xrTableCell15.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell15.StyleName = "FieldCaption";
            this.xrTableCell15.StylePriority.UseBorderColor = false;
            this.xrTableCell15.StylePriority.UseBorders = false;
            this.xrTableCell15.StylePriority.UseFont = false;
            this.xrTableCell15.StylePriority.UseForeColor = false;
            this.xrTableCell15.StylePriority.UsePadding = false;
            this.xrTableCell15.Text = "Tür/Leser";
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell15.Weight = 6.16212075345982D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell17.CanGrow = false;
            this.xrTableCell17.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.xrTableCell17.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell17.StyleName = "FieldCaption";
            this.xrTableCell17.StylePriority.UseBorderColor = false;
            this.xrTableCell17.StylePriority.UseBorders = false;
            this.xrTableCell17.StylePriority.UseFont = false;
            this.xrTableCell17.StylePriority.UseForeColor = false;
            this.xrTableCell17.StylePriority.UsePadding = false;
            this.xrTableCell17.StylePriority.UseTextAlignment = false;
            this.xrTableCell17.Text = "Datum";
            this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell17.Weight = 6.32193767046944D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell19.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell19.CanGrow = false;
            this.xrTableCell19.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.xrTableCell19.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell19.StyleName = "FieldCaption";
            this.xrTableCell19.StylePriority.UseBorderColor = false;
            this.xrTableCell19.StylePriority.UseBorders = false;
            this.xrTableCell19.StylePriority.UseFont = false;
            this.xrTableCell19.StylePriority.UseForeColor = false;
            this.xrTableCell19.StylePriority.UsePadding = false;
            this.xrTableCell19.StylePriority.UseTextAlignment = false;
            this.xrTableCell19.Text = "Uhrzeit";
            this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell19.Weight = 5.59183657076936D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell21.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell21.CanGrow = false;
            this.xrTableCell21.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.xrTableCell21.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell21.StyleName = "FieldCaption";
            this.xrTableCell21.StylePriority.UseBorderColor = false;
            this.xrTableCell21.StylePriority.UseBorders = false;
            this.xrTableCell21.StylePriority.UseFont = false;
            this.xrTableCell21.StylePriority.UseForeColor = false;
            this.xrTableCell21.StylePriority.UsePadding = false;
            this.xrTableCell21.Text = "Mandant";
            this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell21.Weight = 9.3214371985476D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell23.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell23.CanGrow = false;
            this.xrTableCell23.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.xrTableCell23.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell23.StyleName = "FieldCaption";
            this.xrTableCell23.StylePriority.UseBorderColor = false;
            this.xrTableCell23.StylePriority.UseBorders = false;
            this.xrTableCell23.StylePriority.UseFont = false;
            this.xrTableCell23.StylePriority.UseForeColor = false;
            this.xrTableCell23.StylePriority.UsePadding = false;
            this.xrTableCell23.Text = "Standort";
            this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell23.Weight = 7.96673775788723D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell25.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell25.CanGrow = false;
            this.xrTableCell25.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.xrTableCell25.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell25.StyleName = "FieldCaption";
            this.xrTableCell25.StylePriority.UseBorderColor = false;
            this.xrTableCell25.StylePriority.UseBorders = false;
            this.xrTableCell25.StylePriority.UseFont = false;
            this.xrTableCell25.StylePriority.UseForeColor = false;
            this.xrTableCell25.StylePriority.UsePadding = false;
            this.xrTableCell25.Text = "Kostenstelle";
            this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell25.Weight = 9.03536812690385D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell27.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell27.CanGrow = false;
            this.xrTableCell27.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.xrTableCell27.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell27.StyleName = "FieldCaption";
            this.xrTableCell27.StylePriority.UseBorderColor = false;
            this.xrTableCell27.StylePriority.UseBorders = false;
            this.xrTableCell27.StylePriority.UseFont = false;
            this.xrTableCell27.StylePriority.UseForeColor = false;
            this.xrTableCell27.StylePriority.UsePadding = false;
            this.xrTableCell27.Text = "Abteilung";
            this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell27.Weight = 8.16468129978941D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell29.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell29.CanGrow = false;
            this.xrTableCell29.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.xrTableCell29.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell29.StyleName = "FieldCaption";
            this.xrTableCell29.StylePriority.UseBorderColor = false;
            this.xrTableCell29.StylePriority.UseBorders = false;
            this.xrTableCell29.StylePriority.UseFont = false;
            this.xrTableCell29.StylePriority.UseForeColor = false;
            this.xrTableCell29.StylePriority.UsePadding = false;
            this.xrTableCell29.Text = "Name";
            this.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell29.Weight = 8.15247417212082D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell31.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell31.CanGrow = false;
            this.xrTableCell31.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.xrTableCell31.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell31.StyleName = "FieldCaption";
            this.xrTableCell31.StylePriority.UseBorderColor = false;
            this.xrTableCell31.StylePriority.UseBorders = false;
            this.xrTableCell31.StylePriority.UseFont = false;
            this.xrTableCell31.StylePriority.UseForeColor = false;
            this.xrTableCell31.StylePriority.UsePadding = false;
            this.xrTableCell31.Text = "Ausweis Nr.lang";
            this.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell31.Weight = 9.29284309288191D;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell33.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell33.CanGrow = false;
            this.xrTableCell33.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.xrTableCell33.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell33.StyleName = "FieldCaption";
            this.xrTableCell33.StylePriority.UseBorderColor = false;
            this.xrTableCell33.StylePriority.UseBorders = false;
            this.xrTableCell33.StylePriority.UseFont = false;
            this.xrTableCell33.StylePriority.UseForeColor = false;
            this.xrTableCell33.StylePriority.UsePadding = false;
            this.xrTableCell33.Text = "Ausweis Nr.kurz";
            this.xrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell33.Weight = 9.52129997497072D;
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
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(536.9999F, 6.00001F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(233.0001F, 23F);
            this.xrPageInfo2.StyleName = "PageInfo";
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel1});
            this.reportHeaderBand1.HeightF = 147.3334F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // xrPanel1
            // 
            this.xrPanel1.BorderColor = System.Drawing.Color.Gray;
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable11,
            this.xrTable12,
            this.xrTable10,
            this.xrTable9,
            this.xrPageInfo4,
            this.xrTable13,
            this.xrTable17,
            this.xrPageInfo1,
            this.xrTable16,
            this.xrTable15,
            this.xrTable6,
            this.xrTable8,
            this.xrTable7,
            this.xrTable3,
            this.xrTable4,
            this.xrTable18,
            this.xrTable5,
            this.xrLabel1});
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 48.33337F);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(770F, 89F);
            this.xrPanel1.StylePriority.UseBorderColor = false;
            this.xrPanel1.StylePriority.UseBorders = false;
            // 
            // xrTable11
            // 
            this.xrTable11.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTable11.LocationFloat = new DevExpress.Utils.PointFloat(457.0417F, 48.66667F);
            this.xrTable11.Name = "xrTable11";
            this.xrTable11.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow13});
            this.xrTable11.SizeF = new System.Drawing.SizeF(87.78833F, 14.16667F);
            this.xrTable11.StylePriority.UseBorders = false;
            // 
            // xrTableRow13
            // 
            this.xrTableRow13.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell47,
            this.xrTableCell48});
            this.xrTableRow13.Name = "xrTableRow13";
            this.xrTableRow13.Weight = 1D;
            // 
            // xrTableCell47
            // 
            this.xrTableCell47.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell47.Name = "xrTableCell47";
            this.xrTableCell47.StylePriority.UseFont = false;
            this.xrTableCell47.Text = "bis:";
            this.xrTableCell47.Weight = 0.974141991648678D;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BookingTimeTo", "{0:HH:mm}")});
            this.xrTableCell48.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 3, 0, 0, 100F);
            this.xrTableCell48.StylePriority.UseFont = false;
            this.xrTableCell48.StylePriority.UsePadding = false;
            this.xrTableCell48.StylePriority.UseTextAlignment = false;
            this.xrTableCell48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell48.Weight = 1.16382206489637D;
            // 
            // xrTable12
            // 
            this.xrTable12.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTable12.LocationFloat = new DevExpress.Utils.PointFloat(564.4357F, 71.62498F);
            this.xrTable12.Name = "xrTable12";
            this.xrTable12.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow14});
            this.xrTable12.SizeF = new System.Drawing.SizeF(202.5643F, 14.16666F);
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
            this.xrTableCell139.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell139.Name = "xrTableCell139";
            this.xrTableCell139.StylePriority.UseBorders = false;
            this.xrTableCell139.StylePriority.UseFont = false;
            this.xrTableCell139.StylePriority.UseTextAlignment = false;
            this.xrTableCell139.Text = "Erstellt von:";
            this.xrTableCell139.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            this.xrTableCell139.Weight = 2.57926414706855D;
            // 
            // xrTableCell140
            // 
            this.xrTableCell140.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LogedInUser")});
            this.xrTableCell140.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.xrTableCell140.Name = "xrTableCell140";
            this.xrTableCell140.StylePriority.UseFont = false;
            this.xrTableCell140.StylePriority.UseTextAlignment = false;
            this.xrTableCell140.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            this.xrTableCell140.Weight = 4.8932275172849D;
            // 
            // xrTable10
            // 
            this.xrTable10.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTable10.LocationFloat = new DevExpress.Utils.PointFloat(564.4357F, 48.66667F);
            this.xrTable10.Name = "xrTable10";
            this.xrTable10.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow12});
            this.xrTable10.SizeF = new System.Drawing.SizeF(202.5643F, 14.16666F);
            this.xrTable10.StylePriority.UseBorders = false;
            // 
            // xrTableRow12
            // 
            this.xrTableRow12.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell39,
            this.xrTableCell40});
            this.xrTableRow12.Name = "xrTableRow12";
            this.xrTableRow12.Weight = 1D;
            // 
            // xrTableCell39
            // 
            this.xrTableCell39.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell39.Name = "xrTableCell39";
            this.xrTableCell39.StylePriority.UseFont = false;
            this.xrTableCell39.Text = "Ausgwählter Zeitbereich:";
            this.xrTableCell39.Weight = 4.01030746868399D;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DurationSelection")});
            this.xrTableCell40.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.StylePriority.UseFont = false;
            this.xrTableCell40.Weight = 1.83997130668582D;
            // 
            // xrTable9
            // 
            this.xrTable9.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTable9.LocationFloat = new DevExpress.Utils.PointFloat(564.4357F, 27.66663F);
            this.xrTable9.Name = "xrTable9";
            this.xrTable9.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow11});
            this.xrTable9.SizeF = new System.Drawing.SizeF(202.5643F, 14.16667F);
            this.xrTable9.StylePriority.UseBorders = false;
            // 
            // xrTableRow11
            // 
            this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell37,
            this.xrTableCell38});
            this.xrTableRow11.Name = "xrTableRow11";
            this.xrTableRow11.Weight = 1D;
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.StylePriority.UseFont = false;
            this.xrTableCell37.Text = "Selektion der Auswertungen:  ";
            this.xrTableCell37.Weight = 4.72044701484554D;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.StylePriority.UseFont = false;
            this.xrTableCell38.Text = "Object";
            this.xrTableCell38.Weight = 2.16579076623004D;
            // 
            // xrPageInfo4
            // 
            this.xrPageInfo4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPageInfo4.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.xrPageInfo4.Format = "{0:dd.MM.yyyy}";
            this.xrPageInfo4.LocationFloat = new DevExpress.Utils.PointFloat(378.3842F, 71.45824F);
            this.xrPageInfo4.Name = "xrPageInfo4";
            this.xrPageInfo4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrPageInfo4.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo4.SizeF = new System.Drawing.SizeF(68.24005F, 14.00001F);
            this.xrPageInfo4.StylePriority.UseBorders = false;
            this.xrPageInfo4.StylePriority.UseFont = false;
            this.xrPageInfo4.StylePriority.UsePadding = false;
            // 
            // xrTable13
            // 
            this.xrTable13.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTable13.LocationFloat = new DevExpress.Utils.PointFloat(313.3842F, 71.45831F);
            this.xrTable13.Name = "xrTable13";
            this.xrTable13.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow15});
            this.xrTable13.SizeF = new System.Drawing.SizeF(65F, 14.16666F);
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
            this.xrTableCell141.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell141.Name = "xrTableCell141";
            this.xrTableCell141.StylePriority.UseFont = false;
            this.xrTableCell141.Text = "Gedruckt am:";
            this.xrTableCell141.Weight = 4.31282861405303D;
            // 
            // xrTable17
            // 
            this.xrTable17.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTable17.LocationFloat = new DevExpress.Utils.PointFloat(313.3842F, 48.66665F);
            this.xrTable17.Name = "xrTable17";
            this.xrTable17.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow19});
            this.xrTable17.SizeF = new System.Drawing.SizeF(133.2401F, 16.66666F);
            this.xrTable17.StylePriority.UseBorders = false;
            // 
            // xrTableRow19
            // 
            this.xrTableRow19.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell148,
            this.xrTableCell149});
            this.xrTableRow19.Name = "xrTableRow19";
            this.xrTableRow19.Weight = 1D;
            // 
            // xrTableCell148
            // 
            this.xrTableCell148.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell148.Name = "xrTableCell148";
            this.xrTableCell148.StylePriority.UseFont = false;
            this.xrTableCell148.Text = "Uhrzeit von:";
            this.xrTableCell148.Weight = 1.81669841675676D;
            // 
            // xrTableCell149
            // 
            this.xrTableCell149.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BookingTimeFrom", "{0:HH:mm}")});
            this.xrTableCell149.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.xrTableCell149.Name = "xrTableCell149";
            this.xrTableCell149.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 16, 0, 0, 100F);
            this.xrTableCell149.StylePriority.UseFont = false;
            this.xrTableCell149.StylePriority.UsePadding = false;
            this.xrTableCell149.StylePriority.UseTextAlignment = false;
            this.xrTableCell149.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell149.Weight = 1.90725642126679D;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPageInfo1.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.xrPageInfo1.Format = "{0:H:mm}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(497.0416F, 71.45831F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 3, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(47.78851F, 13.99995F);
            this.xrPageInfo1.StylePriority.UseBorders = false;
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UsePadding = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTable16
            // 
            this.xrTable16.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTable16.LocationFloat = new DevExpress.Utils.PointFloat(457.0416F, 27.66666F);
            this.xrTable16.Name = "xrTable16";
            this.xrTable16.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow18});
            this.xrTable16.SizeF = new System.Drawing.SizeF(87.78839F, 14.16667F);
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
            this.xrTableCell146.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell146.Name = "xrTableCell146";
            this.xrTableCell146.StylePriority.UseFont = false;
            this.xrTableCell146.Text = "bis:";
            this.xrTableCell146.Weight = 0.974145010954119D;
            // 
            // xrTableCell147
            // 
            this.xrTableCell147.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BookingDateTo", "{0:dd.MM.yyyy}")});
            this.xrTableCell147.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.xrTableCell147.Name = "xrTableCell147";
            this.xrTableCell147.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 1, 0, 0, 100F);
            this.xrTableCell147.StylePriority.UseFont = false;
            this.xrTableCell147.StylePriority.UsePadding = false;
            this.xrTableCell147.StylePriority.UseTextAlignment = false;
            this.xrTableCell147.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell147.Weight = 1.16382053201822D;
            // 
            // xrTable15
            // 
            this.xrTable15.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTable15.LocationFloat = new DevExpress.Utils.PointFloat(313.3843F, 27.66665F);
            this.xrTable15.Name = "xrTable15";
            this.xrTable15.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow17});
            this.xrTable15.SizeF = new System.Drawing.SizeF(133.24F, 14.16667F);
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
            this.xrTableCell152.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell152.Name = "xrTableCell152";
            this.xrTableCell152.StylePriority.UseFont = false;
            this.xrTableCell152.Text = "Datum von:";
            this.xrTableCell152.Weight = 1.6917977610233D;
            // 
            // xrTableCell153
            // 
            this.xrTableCell153.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BookingDateFrom", "{0:dd.MM.yyyy}")});
            this.xrTableCell153.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.xrTableCell153.Name = "xrTableCell153";
            this.xrTableCell153.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell153.StylePriority.UseFont = false;
            this.xrTableCell153.StylePriority.UsePadding = false;
            this.xrTableCell153.Weight = 1.77613250841981D;
            // 
            // xrTable6
            // 
            this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(165.3454F, 71.45831F);
            this.xrTable6.Name = "xrTable6";
            this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8});
            this.xrTable6.SizeF = new System.Drawing.SizeF(132.93F, 14.16668F);
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
            this.xrTableCell41.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.StylePriority.UseBorders = false;
            this.xrTableCell41.StylePriority.UseFont = false;
            this.xrTableCell41.StylePriority.UseTextAlignment = false;
            this.xrTableCell41.Text = "bis:";
            this.xrTableCell41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            this.xrTableCell41.Weight = 0.448094758714021D;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell42.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PersClientTo")});
            this.xrTableCell42.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.StylePriority.UseBorders = false;
            this.xrTableCell42.StylePriority.UseFont = false;
            this.xrTableCell42.Weight = 2.61622116609194D;
            // 
            // xrTable8
            // 
            this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(165.3453F, 51.16665F);
            this.xrTable8.Name = "xrTable8";
            this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10});
            this.xrTable8.SizeF = new System.Drawing.SizeF(132.9301F, 14.16667F);
            // 
            // xrTableRow10
            // 
            this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell35,
            this.xrTableCell36});
            this.xrTableRow10.Name = "xrTableRow10";
            this.xrTableRow10.Weight = 1D;
            // 
            // xrTableCell35
            // 
            this.xrTableCell35.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell35.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.StylePriority.UseBorders = false;
            this.xrTableCell35.StylePriority.UseFont = false;
            this.xrTableCell35.StylePriority.UseTextAlignment = false;
            this.xrTableCell35.Text = "bis:";
            this.xrTableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            this.xrTableCell35.Weight = 0.448096603593307D;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell36.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BPBuildingTo")});
            this.xrTableCell36.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.StylePriority.UseBorders = false;
            this.xrTableCell36.StylePriority.UseFont = false;
            this.xrTableCell36.Weight = 1.98314071160271D;
            // 
            // xrTable7
            // 
            this.xrTable7.LocationFloat = new DevExpress.Utils.PointFloat(165.3453F, 27.66665F);
            this.xrTable7.Name = "xrTable7";
            this.xrTable7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow9});
            this.xrTable7.SizeF = new System.Drawing.SizeF(132.9301F, 14.16667F);
            // 
            // xrTableRow9
            // 
            this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell43,
            this.xrTableCell44});
            this.xrTableRow9.Name = "xrTableRow9";
            this.xrTableRow9.Weight = 1D;
            // 
            // xrTableCell43
            // 
            this.xrTableCell43.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell43.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell43.Name = "xrTableCell43";
            this.xrTableCell43.StylePriority.UseBorders = false;
            this.xrTableCell43.StylePriority.UseFont = false;
            this.xrTableCell43.StylePriority.UseTextAlignment = false;
            this.xrTableCell43.Text = "bis:";
            this.xrTableCell43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            this.xrTableCell43.Weight = 0.448094834555536D;
            // 
            // xrTableCell44
            // 
            this.xrTableCell44.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell44.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BPLocationTo")});
            this.xrTableCell44.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.xrTableCell44.Name = "xrTableCell44";
            this.xrTableCell44.StylePriority.UseBorders = false;
            this.xrTableCell44.StylePriority.UseFont = false;
            this.xrTableCell44.Weight = 1.98314220286693D;
            // 
            // xrTable3
            // 
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(4.833272F, 71.62497F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
            this.xrTable3.SizeF = new System.Drawing.SizeF(148.6067F, 14.16667F);
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell45,
            this.xrTableCell46});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell45.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.StylePriority.UseBorders = false;
            this.xrTableCell45.StylePriority.UseFont = false;
            this.xrTableCell45.StylePriority.UseTextAlignment = false;
            this.xrTableCell45.Text = "Mandant:";
            this.xrTableCell45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            this.xrTableCell45.Weight = 0.960933164420922D;
            // 
            // xrTableCell46
            // 
            this.xrTableCell46.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell46.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PersClientFrom")});
            this.xrTableCell46.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.xrTableCell46.Name = "xrTableCell46";
            this.xrTableCell46.StylePriority.UseBorders = false;
            this.xrTableCell46.StylePriority.UseFont = false;
            this.xrTableCell46.Weight = 1.75702187376749D;
            // 
            // xrTable4
            // 
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(4.83317F, 27.66664F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
            this.xrTable4.SizeF = new System.Drawing.SizeF(148.6068F, 14.16667F);
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell49,
            this.xrTableCell50});
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Weight = 1D;
            // 
            // xrTableCell49
            // 
            this.xrTableCell49.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell49.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell49.Name = "xrTableCell49";
            this.xrTableCell49.StylePriority.UseBorders = false;
            this.xrTableCell49.StylePriority.UseFont = false;
            this.xrTableCell49.StylePriority.UseTextAlignment = false;
            this.xrTableCell49.Text = "Standort:";
            this.xrTableCell49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            this.xrTableCell49.Weight = 0.976941087154687D;
            // 
            // xrTableCell50
            // 
            this.xrTableCell50.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell50.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BPLocationFrom")});
            this.xrTableCell50.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.xrTableCell50.Name = "xrTableCell50";
            this.xrTableCell50.StylePriority.UseBorders = false;
            this.xrTableCell50.StylePriority.UseFont = false;
            this.xrTableCell50.Weight = 1.7862883579644D;
            // 
            // xrTable18
            // 
            this.xrTable18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTable18.LocationFloat = new DevExpress.Utils.PointFloat(457.0416F, 71.45831F);
            this.xrTable18.Name = "xrTable18";
            this.xrTable18.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow20});
            this.xrTable18.SizeF = new System.Drawing.SizeF(40F, 14.16666F);
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
            this.xrTableCell71.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell71.Name = "xrTableCell71";
            this.xrTableCell71.StylePriority.UseBorders = false;
            this.xrTableCell71.StylePriority.UseFont = false;
            this.xrTableCell71.Text = "Uhrzeit:";
            this.xrTableCell71.Weight = 4.07870398615865D;
            // 
            // xrTable5
            // 
            this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(4.83317F, 48.66665F);
            this.xrTable5.Name = "xrTable5";
            this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
            this.xrTable5.SizeF = new System.Drawing.SizeF(148.6068F, 16.66666F);
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell51,
            this.xrTableCell52});
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.Weight = 1D;
            // 
            // xrTableCell51
            // 
            this.xrTableCell51.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell51.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell51.Name = "xrTableCell51";
            this.xrTableCell51.StylePriority.UseBorders = false;
            this.xrTableCell51.StylePriority.UseFont = false;
            this.xrTableCell51.Text = "Gebäude:";
            this.xrTableCell51.Weight = 0.906182544281648D;
            // 
            // xrTableCell52
            // 
            this.xrTableCell52.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell52.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BPBuildingFrom")});
            this.xrTableCell52.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.xrTableCell52.Name = "xrTableCell52";
            this.xrTableCell52.StylePriority.UseBorders = false;
            this.xrTableCell52.StylePriority.UseFont = false;
            this.xrTableCell52.Weight = 1.65690975018033D;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(4.5F, 2F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(169.0883F, 18F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Personal Zutrittsprotokolle";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(Access_Control_NewMask.Dtos.AccessLogReportsDto);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // AccessPersonalProtocalReportPortrait
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.pageHeaderBand1,
            this.pageFooterBand1,
            this.reportHeaderBand1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.Margins = new System.Drawing.Printing.Margins(65, 15, 0, 0);
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
            this.Version = "15.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
