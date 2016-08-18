using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Web;
using Access_Control_NewMask.Dtos;

/// <summary>
/// Summary description for PersonalReportListVarD
/// </summary>
public class PersonalReportListVarD : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRTable xrTable2;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell30;
    private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
    private PageHeaderBand pageHeaderBand1;
    private XRTable xrTable1;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell15;
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
    private DevExpress.DataAccess.ObjectBinding.ObjectDataSource PersonalReportsListDto;
    private XRTableCell xrTableCell50;
    private XRTableCell xrTableCell49;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell59;
    private XRTableCell xrTableCell64;
    private XRTableCell xrTableCell63;
    private XRTableCell xrTableCell62;
    private XRTableCell xrTableCell61;
    private XRTableCell xrTableCell60;
    private XRTableCell xrTableCell68;
    private XRTableCell xrTableCell67;
    private XRTableCell xrTableCell66;
    private XRTableCell xrTableCell65;
    private XRTableCell xrTableCell46;
    private XRTableCell xrTableCell45;
    private XRTableCell xrTableCell47;
    private XRTableCell xrTableCell48;
    private XRTableCell xrTableCell55;
    private XRTableCell xrTableCell54;
    private XRTableCell xrTableCell53;
    private XRTableCell xrTableCell52;
    private XRTableCell xrTableCell56;
    private XRTableCell xrTableCell58;
    private XRTableCell xrTableCell57;
    private XRTableCell xrTableCell51;
    private XRPanel xrPanel1;
    private XRLabel xrLabel1;
    private XRTable xrTable11;
    private XRTableRow xrTableRow13;
    private XRTableCell xrTableCell43;
    private XRTableCell xrTableCell44;
    private XRTable xrTable8;
    private XRTableRow xrTableRow10;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell36;
    private XRTable xrTable4;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell22;
    private XRTable xrTable3;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell32;
    private XRTable xrTable5;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell24;
    private XRTable xrTable12;
    private XRTableRow xrTableRow14;
    private XRTableCell xrTableCell139;
    private XRTableCell xrTableCell140;
    private XRTable xrTable9;
    private XRTableRow xrTableRow11;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell38;
    private XRPageInfo xrPageInfo4;
    private XRTable xrTable13;
    private XRTableRow xrTableRow15;
    private XRTableCell xrTableCell141;
    private XRPageInfo xrPageInfo1;
    private XRTable xrTable6;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell41;
    private XRTableCell xrTableCell42;
    private XRTable xrTable18;
    private XRTableRow xrTableRow20;
    private XRTableCell xrTableCell71;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public PersonalReportListVarD()
    {
        InitializeComponent();
        this.DataSource = HttpContext.Current.Session["PersonalistDto"];

        //
        // TODO: Add constructor logic here
        //

        if (HttpContext.Current.Session["PersonalacReport"] != null)
        {
            var acReport = (PersonalReportsListSettingsDto)HttpContext.Current.Session["PersonalacReport"];
            if (!acReport.DisplayClient)
            { 
                xrTable1.DeleteColumn(xrTableCell19);
                xrTable2.DeleteColumn(xrTableCell20); 
            }
            if (!acReport.DisplayLocation)
            {
                xrTable1.DeleteColumn(xrTableCell15);
                xrTable2.DeleteColumn(xrTableCell16);
            }
            if (!acReport.DisplayDepartment)
            {
                xrTable1.DeleteColumn(xrTableCell49);
                xrTable2.DeleteColumn(xrTableCell50);
            }
            if (!acReport.DisplayName)
            {
                xrTable1.DeleteColumn(xrTableCell13);
                xrTable2.DeleteColumn(xrTableCell14);
            }
            if (!acReport.DisplayPersonalID)
            {
                xrTable1.DeleteColumn(xrTableCell25);
                xrTable2.DeleteColumn(xrTableCell26);
            }
            if (!acReport.DisplayPlace)
            {
                xrTable1.DeleteColumn(xrTableCell7);
                xrTable2.DeleteColumn(xrTableCell8);
            }
            if (!acReport.DisplayPostalCode)
            {
                xrTable1.DeleteColumn(xrTableCell45);
                xrTable2.DeleteColumn(xrTableCell59);
            }
            if (!acReport.DisplayStreetAndNr)
            {
                xrTable1.DeleteColumn(xrTableCell47);
                xrTable2.DeleteColumn(xrTableCell64);
            }
            if (!acReport.DisplayDateOfBirth)
            {
                xrTable1.DeleteColumn(xrTableCell48);
                xrTable2.DeleteColumn(xrTableCell63);
            }

            if (!acReport.DisplayEnrtyDate)
            {
                xrTable1.DeleteColumn(xrTableCell55);
                xrTable2.DeleteColumn(xrTableCell62);
            }
            if (!acReport.DisplayExitDate)
            {
                xrTable1.DeleteColumn(xrTableCell54);
                xrTable2.DeleteColumn(xrTableCell61);
            }

            if (!acReport.DisplayEmployedAs)
            {
                xrTable1.DeleteColumn(xrTableCell53);
                xrTable2.DeleteColumn(xrTableCell60);
            }
            if (!acReport.DisplayNationality)
            {
                xrTable1.DeleteColumn(xrTableCell52);
                xrTable2.DeleteColumn(xrTableCell68);
            }
            if (!acReport.DisplayCompanyTelephone)
            {
                xrTable1.DeleteColumn(xrTableCell56);
                xrTable2.DeleteColumn(xrTableCell67);
            }
            if (!acReport.DisplayCompanyMobile)
            {
                xrTable1.DeleteColumn(xrTableCell58);
                xrTable2.DeleteColumn(xrTableCell66);
            }
            if (!acReport.DisplayPrivateTelephone)
            {
                xrTable1.DeleteColumn(xrTableCell57);
                xrTable2.DeleteColumn(xrTableCell65);
            }
            if (!acReport.DisplayPrivateMobile)
            {
                xrTable1.DeleteColumn(xrTableCell51);
                xrTable2.DeleteColumn(xrTableCell46);
            }
            if (!acReport.DisplayLongTermCard)
            {
                xrTable1.DeleteColumn(xrTableCell9);
                xrTable2.DeleteColumn(xrTableCell11);
            }
            if (!acReport.DisplayShortTermCard)
            {
                //xrTable1.DeleteColumn(xrTableCell10);
                //xrTable2.DeleteColumn(xrTableCell12);
            }
            if (!acReport.DisplayAccessAuthorization)
            {
                //xrTable1.DeleteColumn(xrTableCell51);
                //xrTable2.DeleteColumn(xrTableCell46);
            }
            if (!acReport.DisplayAccessPlanNr)
            {
                xrTable1.DeleteColumn(xrTableCell27);
                xrTable2.DeleteColumn(xrTableCell28);
            }
            if (!acReport.DisplayAccessPlanDescription)
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
    /// 

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
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell59 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell64 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell63 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell62 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell61 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell60 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell68 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell67 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell65 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.pageHeaderBand1 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell55 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell54 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell53 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell56 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell58 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell57 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
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
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable11 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow13 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable8 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable12 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow14 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell139 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell140 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable9 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPageInfo4 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrTable13 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow15 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell141 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable18 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow20 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PersonalReportsListDto = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonalReportsListDto)).BeginInit();
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
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 6F);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(4.000002F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1082F, 13.83331F);
            this.xrTable2.StylePriority.UseFont = false;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell14,
            this.xrTableCell16,
            this.xrTableCell50,
            this.xrTableCell20,
            this.xrTableCell26,
            this.xrTableCell8,
            this.xrTableCell59,
            this.xrTableCell64,
            this.xrTableCell63,
            this.xrTableCell62,
            this.xrTableCell61,
            this.xrTableCell60,
            this.xrTableCell68,
            this.xrTableCell67,
            this.xrTableCell66,
            this.xrTableCell65,
            this.xrTableCell46,
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell28,
            this.xrTableCell30});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell14.CanGrow = false;
            this.xrTableCell14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FirstName")});
            this.xrTableCell14.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell14.StyleName = "DataField";
            this.xrTableCell14.StylePriority.UseBorderColor = false;
            this.xrTableCell14.StylePriority.UseBorders = false;
            this.xrTableCell14.StylePriority.UseFont = false;
            this.xrTableCell14.StylePriority.UsePadding = false;
            this.xrTableCell14.Weight = 5.8998109269295727D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell16.CanGrow = false;
            this.xrTableCell16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Location")});
            this.xrTableCell16.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell16.StyleName = "DataField";
            this.xrTableCell16.StylePriority.UseBorderColor = false;
            this.xrTableCell16.StylePriority.UseBorders = false;
            this.xrTableCell16.StylePriority.UseFont = false;
            this.xrTableCell16.StylePriority.UsePadding = false;
            this.xrTableCell16.Weight = 6.7879645188052136D;
            // 
            // xrTableCell50
            // 
            this.xrTableCell50.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell50.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell50.CanGrow = false;
            this.xrTableCell50.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DepartmentName")});
            this.xrTableCell50.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell50.Name = "xrTableCell50";
            this.xrTableCell50.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell50.StylePriority.UseBorderColor = false;
            this.xrTableCell50.StylePriority.UseBorders = false;
            this.xrTableCell50.StylePriority.UseFont = false;
            this.xrTableCell50.StylePriority.UsePadding = false;
            this.xrTableCell50.Weight = 6.1133286172208843D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell20.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell20.CanGrow = false;
            this.xrTableCell20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ClientName")});
            this.xrTableCell20.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell20.StyleName = "DataField";
            this.xrTableCell20.StylePriority.UseBorderColor = false;
            this.xrTableCell20.StylePriority.UseBorders = false;
            this.xrTableCell20.StylePriority.UseFont = false;
            this.xrTableCell20.StylePriority.UsePadding = false;
            this.xrTableCell20.Weight = 6.0637075269724034D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell26.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell26.CanGrow = false;
            this.xrTableCell26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Pers_Nr")});
            this.xrTableCell26.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell26.StyleName = "DataField";
            this.xrTableCell26.StylePriority.UseBorderColor = false;
            this.xrTableCell26.StylePriority.UseBorders = false;
            this.xrTableCell26.StylePriority.UseFont = false;
            this.xrTableCell26.StylePriority.UsePadding = false;
            this.xrTableCell26.Weight = 3.2339837169475913D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell8.CanGrow = false;
            this.xrTableCell8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Place")});
            this.xrTableCell8.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell8.StylePriority.UseBorderColor = false;
            this.xrTableCell8.StylePriority.UseBorders = false;
            this.xrTableCell8.StylePriority.UseFont = false;
            this.xrTableCell8.StylePriority.UsePadding = false;
            this.xrTableCell8.Weight = 4.6913815312919631D;
            // 
            // xrTableCell59
            // 
            this.xrTableCell59.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell59.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell59.CanGrow = false;
            this.xrTableCell59.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PostalCode")});
            this.xrTableCell59.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell59.Name = "xrTableCell59";
            this.xrTableCell59.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell59.StylePriority.UseBorderColor = false;
            this.xrTableCell59.StylePriority.UseBorders = false;
            this.xrTableCell59.StylePriority.UseFont = false;
            this.xrTableCell59.StylePriority.UsePadding = false;
            this.xrTableCell59.Weight = 3.3100372851452189D;
            // 
            // xrTableCell64
            // 
            this.xrTableCell64.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell64.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell64.CanGrow = false;
            this.xrTableCell64.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "StreetNrAndName")});
            this.xrTableCell64.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell64.Name = "xrTableCell64";
            this.xrTableCell64.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell64.StylePriority.UseBorderColor = false;
            this.xrTableCell64.StylePriority.UseBorders = false;
            this.xrTableCell64.StylePriority.UseFont = false;
            this.xrTableCell64.StylePriority.UsePadding = false;
            this.xrTableCell64.Weight = 6.7711430442784826D;
            // 
            // xrTableCell63
            // 
            this.xrTableCell63.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell63.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell63.CanGrow = false;
            this.xrTableCell63.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DateOfBirth", "{0:dd.MM.yyyy}")});
            this.xrTableCell63.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell63.Name = "xrTableCell63";
            this.xrTableCell63.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell63.StylePriority.UseBorderColor = false;
            this.xrTableCell63.StylePriority.UseBorders = false;
            this.xrTableCell63.StylePriority.UseFont = false;
            this.xrTableCell63.StylePriority.UsePadding = false;
            this.xrTableCell63.Weight = 4.7499096561626741D;
            // 
            // xrTableCell62
            // 
            this.xrTableCell62.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell62.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell62.CanGrow = false;
            this.xrTableCell62.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "EntryDate", "{0:dd.MM.yyyy}")});
            this.xrTableCell62.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell62.Name = "xrTableCell62";
            this.xrTableCell62.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell62.StylePriority.UseBorderColor = false;
            this.xrTableCell62.StylePriority.UseBorders = false;
            this.xrTableCell62.StylePriority.UseFont = false;
            this.xrTableCell62.StylePriority.UsePadding = false;
            this.xrTableCell62.Weight = 4.8509591924064273D;
            // 
            // xrTableCell61
            // 
            this.xrTableCell61.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell61.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell61.CanGrow = false;
            this.xrTableCell61.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ExitDate", "{0:dd.MM.yyyy}")});
            this.xrTableCell61.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell61.Name = "xrTableCell61";
            this.xrTableCell61.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell61.StylePriority.UseBorderColor = false;
            this.xrTableCell61.StylePriority.UseBorders = false;
            this.xrTableCell61.StylePriority.UseFont = false;
            this.xrTableCell61.StylePriority.UsePadding = false;
            this.xrTableCell61.Weight = 4.9027700402692922D;
            // 
            // xrTableCell60
            // 
            this.xrTableCell60.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell60.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell60.CanGrow = false;
            this.xrTableCell60.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell60.Name = "xrTableCell60";
            this.xrTableCell60.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell60.StylePriority.UseBorderColor = false;
            this.xrTableCell60.StylePriority.UseBorders = false;
            this.xrTableCell60.StylePriority.UseFont = false;
            this.xrTableCell60.StylePriority.UsePadding = false;
            this.xrTableCell60.Weight = 6.3288251165040741D;
            // 
            // xrTableCell68
            // 
            this.xrTableCell68.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell68.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell68.CanGrow = false;
            this.xrTableCell68.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Nationality")});
            this.xrTableCell68.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell68.Name = "xrTableCell68";
            this.xrTableCell68.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell68.StylePriority.UseBorderColor = false;
            this.xrTableCell68.StylePriority.UseBorders = false;
            this.xrTableCell68.StylePriority.UseFont = false;
            this.xrTableCell68.StylePriority.UsePadding = false;
            this.xrTableCell68.Weight = 6.063704369695345D;
            // 
            // xrTableCell67
            // 
            this.xrTableCell67.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell67.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell67.CanGrow = false;
            this.xrTableCell67.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CompanyPhone")});
            this.xrTableCell67.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell67.Name = "xrTableCell67";
            this.xrTableCell67.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell67.StylePriority.UseBorderColor = false;
            this.xrTableCell67.StylePriority.UseBorders = false;
            this.xrTableCell67.StylePriority.UseFont = false;
            this.xrTableCell67.StylePriority.UsePadding = false;
            this.xrTableCell67.Weight = 5.5788223419003442D;
            // 
            // xrTableCell66
            // 
            this.xrTableCell66.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell66.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell66.CanGrow = false;
            this.xrTableCell66.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CompanyMobile")});
            this.xrTableCell66.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell66.Name = "xrTableCell66";
            this.xrTableCell66.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell66.StylePriority.UseBorderColor = false;
            this.xrTableCell66.StylePriority.UseBorders = false;
            this.xrTableCell66.StylePriority.UseFont = false;
            this.xrTableCell66.StylePriority.UsePadding = false;
            this.xrTableCell66.Weight = 4.5908008550175055D;
            // 
            // xrTableCell65
            // 
            this.xrTableCell65.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell65.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell65.CanGrow = false;
            this.xrTableCell65.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PrivatePhone")});
            this.xrTableCell65.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell65.Name = "xrTableCell65";
            this.xrTableCell65.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell65.StylePriority.UseBorderColor = false;
            this.xrTableCell65.StylePriority.UseBorders = false;
            this.xrTableCell65.StylePriority.UseFont = false;
            this.xrTableCell65.StylePriority.UsePadding = false;
            this.xrTableCell65.Weight = 4.6749984624153509D;
            // 
            // xrTableCell46
            // 
            this.xrTableCell46.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell46.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell46.CanGrow = false;
            this.xrTableCell46.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PrivateMobile")});
            this.xrTableCell46.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell46.Name = "xrTableCell46";
            this.xrTableCell46.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell46.StylePriority.UseBorderColor = false;
            this.xrTableCell46.StylePriority.UseBorders = false;
            this.xrTableCell46.StylePriority.UseFont = false;
            this.xrTableCell46.StylePriority.UsePadding = false;
            this.xrTableCell46.Weight = 4.92765926476082D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell11.CanGrow = false;
            this.xrTableCell11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CardNumber")});
            this.xrTableCell11.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell11.StylePriority.UseBorderColor = false;
            this.xrTableCell11.StylePriority.UseBorders = false;
            this.xrTableCell11.StylePriority.UseFont = false;
            this.xrTableCell11.StylePriority.UsePadding = false;
            this.xrTableCell11.Text = " ";
            this.xrTableCell11.Weight = 4.8749908477044945D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell12.CanGrow = false;
            this.xrTableCell12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AusweisNrShortTerm")});
            this.xrTableCell12.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell12.StylePriority.UseBorderColor = false;
            this.xrTableCell12.StylePriority.UseBorders = false;
            this.xrTableCell12.StylePriority.UseFont = false;
            this.xrTableCell12.StylePriority.UsePadding = false;
            this.xrTableCell12.Weight = 5.2240356791350635D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell28.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell28.CanGrow = false;
            this.xrTableCell28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AccessPlanNr")});
            this.xrTableCell28.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell28.StyleName = "DataField";
            this.xrTableCell28.StylePriority.UseBorderColor = false;
            this.xrTableCell28.StylePriority.UseBorders = false;
            this.xrTableCell28.StylePriority.UseFont = false;
            this.xrTableCell28.StylePriority.UsePadding = false;
            this.xrTableCell28.Weight = 5.0882742641839123D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell30.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell30.CanGrow = false;
            this.xrTableCell30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "AccessPlanDescription")});
            this.xrTableCell30.Font = new System.Drawing.Font("Tahoma", 6.5F);
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrTableCell30.StyleName = "DataField";
            this.xrTableCell30.StylePriority.UseBorderColor = false;
            this.xrTableCell30.StylePriority.UseBorders = false;
            this.xrTableCell30.StylePriority.UseFont = false;
            this.xrTableCell30.StylePriority.UsePadding = false;
            this.xrTableCell30.Weight = 4.621816771121428D;
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
            this.BottomMargin.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.BottomMargin.HeightF = 81F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.StylePriority.UseFont = false;
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
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 6F);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(3.999977F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1082F, 20.83333F);
            this.xrTable1.StylePriority.UseFont = false;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell13,
            this.xrTableCell15,
            this.xrTableCell49,
            this.xrTableCell19,
            this.xrTableCell25,
            this.xrTableCell7,
            this.xrTableCell45,
            this.xrTableCell47,
            this.xrTableCell48,
            this.xrTableCell55,
            this.xrTableCell54,
            this.xrTableCell53,
            this.xrTableCell52,
            this.xrTableCell56,
            this.xrTableCell58,
            this.xrTableCell57,
            this.xrTableCell51,
            this.xrTableCell9,
            this.xrTableCell10,
            this.xrTableCell27,
            this.xrTableCell29});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell13.CanGrow = false;
            this.xrTableCell13.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell13.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell13.StyleName = "FieldCaption";
            this.xrTableCell13.StylePriority.UseBorderColor = false;
            this.xrTableCell13.StylePriority.UseBorders = false;
            this.xrTableCell13.StylePriority.UseFont = false;
            this.xrTableCell13.StylePriority.UseForeColor = false;
            this.xrTableCell13.StylePriority.UsePadding = false;
            this.xrTableCell13.Text = "Name";
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell13.Weight = 6.1784652348935083D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell15.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell15.CanGrow = false;
            this.xrTableCell15.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell15.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell15.StyleName = "FieldCaption";
            this.xrTableCell15.StylePriority.UseBorderColor = false;
            this.xrTableCell15.StylePriority.UseBorders = false;
            this.xrTableCell15.StylePriority.UseFont = false;
            this.xrTableCell15.StylePriority.UseForeColor = false;
            this.xrTableCell15.StylePriority.UsePadding = false;
            this.xrTableCell15.Text = "Standort";
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell15.Weight = 7.1085682008041049D;
            // 
            // xrTableCell49
            // 
            this.xrTableCell49.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell49.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell49.CanGrow = false;
            this.xrTableCell49.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell49.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell49.Name = "xrTableCell49";
            this.xrTableCell49.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell49.StylePriority.UseBorderColor = false;
            this.xrTableCell49.StylePriority.UseBorders = false;
            this.xrTableCell49.StylePriority.UseFont = false;
            this.xrTableCell49.StylePriority.UseForeColor = false;
            this.xrTableCell49.StylePriority.UsePadding = false;
            this.xrTableCell49.StylePriority.UseTextAlignment = false;
            this.xrTableCell49.Text = "Abteilung";
            this.xrTableCell49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell49.Weight = 6.4020618512116023D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell19.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell19.CanGrow = false;
            this.xrTableCell19.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell19.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell19.StyleName = "FieldCaption";
            this.xrTableCell19.StylePriority.UseBorderColor = false;
            this.xrTableCell19.StylePriority.UseBorders = false;
            this.xrTableCell19.StylePriority.UseFont = false;
            this.xrTableCell19.StylePriority.UseForeColor = false;
            this.xrTableCell19.StylePriority.UsePadding = false;
            this.xrTableCell19.Text = "Mandant  ";
            this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell19.Weight = 6.3501040299359408D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell25.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell25.CanGrow = false;
            this.xrTableCell25.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell25.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell25.StyleName = "FieldCaption";
            this.xrTableCell25.StylePriority.UseBorderColor = false;
            this.xrTableCell25.StylePriority.UseBorders = false;
            this.xrTableCell25.StylePriority.UseFont = false;
            this.xrTableCell25.StylePriority.UseForeColor = false;
            this.xrTableCell25.StylePriority.UsePadding = false;
            this.xrTableCell25.Text = "ID Nr";
            this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell25.Weight = 3.3867223819322887D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell7.CanGrow = false;
            this.xrTableCell7.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell7.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell7.StylePriority.UseBorderColor = false;
            this.xrTableCell7.StylePriority.UseBorders = false;
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.StylePriority.UseForeColor = false;
            this.xrTableCell7.StylePriority.UsePadding = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "Ort";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell7.Weight = 4.9129656794928076D;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell45.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell45.CanGrow = false;
            this.xrTableCell45.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell45.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell45.StylePriority.UseBorderColor = false;
            this.xrTableCell45.StylePriority.UseBorders = false;
            this.xrTableCell45.StylePriority.UseFont = false;
            this.xrTableCell45.StylePriority.UseForeColor = false;
            this.xrTableCell45.StylePriority.UsePadding = false;
            this.xrTableCell45.StylePriority.UseTextAlignment = false;
            this.xrTableCell45.Text = "PLZ";
            this.xrTableCell45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell45.Weight = 3.4663730826897794D;
            // 
            // xrTableCell47
            // 
            this.xrTableCell47.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell47.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell47.CanGrow = false;
            this.xrTableCell47.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell47.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell47.Name = "xrTableCell47";
            this.xrTableCell47.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell47.StylePriority.UseBorderColor = false;
            this.xrTableCell47.StylePriority.UseBorders = false;
            this.xrTableCell47.StylePriority.UseFont = false;
            this.xrTableCell47.StylePriority.UseForeColor = false;
            this.xrTableCell47.StylePriority.UsePadding = false;
            this.xrTableCell47.StylePriority.UseTextAlignment = false;
            this.xrTableCell47.Text = "traße und Nr.";
            this.xrTableCell47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell47.Weight = 7.0909497273947739D;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell48.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell48.CanGrow = false;
            this.xrTableCell48.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell48.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell48.StylePriority.UseBorderColor = false;
            this.xrTableCell48.StylePriority.UseBorders = false;
            this.xrTableCell48.StylePriority.UseFont = false;
            this.xrTableCell48.StylePriority.UseForeColor = false;
            this.xrTableCell48.StylePriority.UsePadding = false;
            this.xrTableCell48.StylePriority.UseTextAlignment = false;
            this.xrTableCell48.Text = "Geburtsdatum\t ";
            this.xrTableCell48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell48.Weight = 4.9742485624943171D;
            // 
            // xrTableCell55
            // 
            this.xrTableCell55.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell55.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell55.CanGrow = false;
            this.xrTableCell55.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell55.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell55.Name = "xrTableCell55";
            this.xrTableCell55.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell55.StylePriority.UseBorderColor = false;
            this.xrTableCell55.StylePriority.UseBorders = false;
            this.xrTableCell55.StylePriority.UseFont = false;
            this.xrTableCell55.StylePriority.UseForeColor = false;
            this.xrTableCell55.StylePriority.UsePadding = false;
            this.xrTableCell55.StylePriority.UseTextAlignment = false;
            this.xrTableCell55.Text = "Eintrittsdatum\t";
            this.xrTableCell55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell55.Weight = 5.0800836340263782D;
            // 
            // xrTableCell54
            // 
            this.xrTableCell54.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell54.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell54.CanGrow = false;
            this.xrTableCell54.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell54.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell54.Name = "xrTableCell54";
            this.xrTableCell54.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell54.StylePriority.UseBorderColor = false;
            this.xrTableCell54.StylePriority.UseBorders = false;
            this.xrTableCell54.StylePriority.UseFont = false;
            this.xrTableCell54.StylePriority.UseForeColor = false;
            this.xrTableCell54.StylePriority.UsePadding = false;
            this.xrTableCell54.StylePriority.UseTextAlignment = false;
            this.xrTableCell54.Text = "Austrittsdatum\t ";
            this.xrTableCell54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell54.Weight = 5.1343189404584546D;
            // 
            // xrTableCell53
            // 
            this.xrTableCell53.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell53.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell53.CanGrow = false;
            this.xrTableCell53.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell53.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell53.Name = "xrTableCell53";
            this.xrTableCell53.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell53.StylePriority.UseBorderColor = false;
            this.xrTableCell53.StylePriority.UseBorders = false;
            this.xrTableCell53.StylePriority.UseFont = false;
            this.xrTableCell53.StylePriority.UseForeColor = false;
            this.xrTableCell53.StylePriority.UsePadding = false;
            this.xrTableCell53.StylePriority.UseTextAlignment = false;
            this.xrTableCell53.Text = "Beschäftigt ais";
            this.xrTableCell53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell53.Weight = 6.6277342250390294D;
            // 
            // xrTableCell52
            // 
            this.xrTableCell52.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell52.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell52.CanGrow = false;
            this.xrTableCell52.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell52.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell52.Name = "xrTableCell52";
            this.xrTableCell52.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell52.StylePriority.UseBorderColor = false;
            this.xrTableCell52.StylePriority.UseBorders = false;
            this.xrTableCell52.StylePriority.UseFont = false;
            this.xrTableCell52.StylePriority.UseForeColor = false;
            this.xrTableCell52.StylePriority.UsePadding = false;
            this.xrTableCell52.StylePriority.UseTextAlignment = false;
            this.xrTableCell52.Text = "Nationalität";
            this.xrTableCell52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell52.Weight = 6.3501044924110781D;
            // 
            // xrTableCell56
            // 
            this.xrTableCell56.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell56.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell56.CanGrow = false;
            this.xrTableCell56.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell56.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell56.Name = "xrTableCell56";
            this.xrTableCell56.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell56.StylePriority.UseBorderColor = false;
            this.xrTableCell56.StylePriority.UseBorders = false;
            this.xrTableCell56.StylePriority.UseFont = false;
            this.xrTableCell56.StylePriority.UseForeColor = false;
            this.xrTableCell56.StylePriority.UsePadding = false;
            this.xrTableCell56.StylePriority.UseTextAlignment = false;
            this.xrTableCell56.Text = "Firmen Telefon";
            this.xrTableCell56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell56.Weight = 5.8423130321459853D;
            // 
            // xrTableCell58
            // 
            this.xrTableCell58.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell58.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell58.CanGrow = false;
            this.xrTableCell58.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell58.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell58.Name = "xrTableCell58";
            this.xrTableCell58.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell58.StylePriority.UseBorderColor = false;
            this.xrTableCell58.StylePriority.UseBorders = false;
            this.xrTableCell58.StylePriority.UseFont = false;
            this.xrTableCell58.StylePriority.UseForeColor = false;
            this.xrTableCell58.StylePriority.UsePadding = false;
            this.xrTableCell58.StylePriority.UseTextAlignment = false;
            this.xrTableCell58.Text = "Firmen Handy";
            this.xrTableCell58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell58.Weight = 4.8076151698404512D;
            // 
            // xrTableCell57
            // 
            this.xrTableCell57.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell57.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell57.CanGrow = false;
            this.xrTableCell57.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell57.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell57.Name = "xrTableCell57";
            this.xrTableCell57.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell57.StylePriority.UseBorderColor = false;
            this.xrTableCell57.StylePriority.UseBorders = false;
            this.xrTableCell57.StylePriority.UseFont = false;
            this.xrTableCell57.StylePriority.UseForeColor = false;
            this.xrTableCell57.StylePriority.UsePadding = false;
            this.xrTableCell57.StylePriority.UseTextAlignment = false;
            this.xrTableCell57.Text = "Privat Telefon";
            this.xrTableCell57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell57.Weight = 4.8958064871912423D;
            // 
            // xrTableCell51
            // 
            this.xrTableCell51.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell51.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell51.CanGrow = false;
            this.xrTableCell51.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell51.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell51.Name = "xrTableCell51";
            this.xrTableCell51.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell51.StylePriority.UseBorderColor = false;
            this.xrTableCell51.StylePriority.UseBorders = false;
            this.xrTableCell51.StylePriority.UseFont = false;
            this.xrTableCell51.StylePriority.UseForeColor = false;
            this.xrTableCell51.StylePriority.UsePadding = false;
            this.xrTableCell51.StylePriority.UseTextAlignment = false;
            this.xrTableCell51.Text = "Privat Handy";
            this.xrTableCell51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell51.Weight = 5.1604030480540644D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell9.CanGrow = false;
            this.xrTableCell9.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell9.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell9.StylePriority.UseBorderColor = false;
            this.xrTableCell9.StylePriority.UseBorders = false;
            this.xrTableCell9.StylePriority.UseFont = false;
            this.xrTableCell9.StylePriority.UseForeColor = false;
            this.xrTableCell9.StylePriority.UsePadding = false;
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.Text = "Langzeit Ausweis";
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell9.Weight = 5.1052180088727006D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell10.CanGrow = false;
            this.xrTableCell10.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell10.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell10.StylePriority.UseBorderColor = false;
            this.xrTableCell10.StylePriority.UseBorders = false;
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.StylePriority.UseForeColor = false;
            this.xrTableCell10.StylePriority.UsePadding = false;
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.Text = "Kurzzeit Ausweis";
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell10.Weight = 5.4707823214404518D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell27.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell27.CanGrow = false;
            this.xrTableCell27.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell27.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell27.StyleName = "FieldCaption";
            this.xrTableCell27.StylePriority.UseBorderColor = false;
            this.xrTableCell27.StylePriority.UseBorders = false;
            this.xrTableCell27.StylePriority.UseFont = false;
            this.xrTableCell27.StylePriority.UseForeColor = false;
            this.xrTableCell27.StylePriority.UsePadding = false;
            this.xrTableCell27.Text = "Zutrittsplan Nr";
            this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell27.Weight = 5.3285842399880439D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xrTableCell29.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell29.CanGrow = false;
            this.xrTableCell29.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Bold);
            this.xrTableCell29.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell29.StyleName = "FieldCaption";
            this.xrTableCell29.StylePriority.UseBorderColor = false;
            this.xrTableCell29.StylePriority.UseBorders = false;
            this.xrTableCell29.StylePriority.UseFont = false;
            this.xrTableCell29.StylePriority.UseForeColor = false;
            this.xrTableCell29.StylePriority.UsePadding = false;
            this.xrTableCell29.Text = "Zutrittsplan Bez.";
            this.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell29.Weight = 4.8401250473701509D;
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
            this.xrPageInfo2.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold);
            this.xrPageInfo2.Format = "Seite {0} von {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(643.7854F, 0F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(442.2146F, 23F);
            this.xrPageInfo2.StyleName = "PageInfo";
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel1});
            this.reportHeaderBand1.HeightF = 157.2916F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // xrPanel1
            // 
            this.xrPanel1.BorderColor = System.Drawing.Color.Gray;
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrTable11,
            this.xrTable8,
            this.xrTable4,
            this.xrTable3,
            this.xrTable5,
            this.xrTable12,
            this.xrTable9,
            this.xrPageInfo4,
            this.xrTable13,
            this.xrPageInfo1,
            this.xrTable6,
            this.xrTable18});
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(4.000002F, 48.95836F);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(1082F, 99.99988F);
            this.xrPanel1.StylePriority.UseBorderColor = false;
            this.xrPanel1.StylePriority.UseBorders = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(10F, 10F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(188.255F, 17.16667F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UsePadding = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Personallisten";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTable11
            // 
            this.xrTable11.LocationFloat = new DevExpress.Utils.PointFloat(276.5539F, 76.00001F);
            this.xrTable11.Name = "xrTable11";
            this.xrTable11.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow13});
            this.xrTable11.SizeF = new System.Drawing.SizeF(201.6725F, 14.16667F);
            // 
            // xrTableRow13
            // 
            this.xrTableRow13.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell43,
            this.xrTableCell44});
            this.xrTableRow13.Name = "xrTableRow13";
            this.xrTableRow13.Weight = 1D;
            // 
            // xrTableCell43
            // 
            this.xrTableCell43.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell43.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell43.Name = "xrTableCell43";
            this.xrTableCell43.StylePriority.UseBorders = false;
            this.xrTableCell43.StylePriority.UseFont = false;
            this.xrTableCell43.StylePriority.UseTextAlignment = false;
            this.xrTableCell43.Text = "bis:";
            this.xrTableCell43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            this.xrTableCell43.Weight = 0.4480942005602952D;
            // 
            // xrTableCell44
            // 
            this.xrTableCell44.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell44.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PersClientTo")});
            this.xrTableCell44.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.xrTableCell44.Name = "xrTableCell44";
            this.xrTableCell44.StylePriority.UseBorders = false;
            this.xrTableCell44.StylePriority.UseFont = false;
            this.xrTableCell44.Weight = 3.2404113915018855D;
            // 
            // xrTable8
            // 
            this.xrTable8.LocationFloat = new DevExpress.Utils.PointFloat(276.554F, 53.99999F);
            this.xrTable8.Name = "xrTable8";
            this.xrTable8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10});
            this.xrTable8.SizeF = new System.Drawing.SizeF(201.6725F, 14.16667F);
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
            this.xrTableCell35.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.StylePriority.UseBorders = false;
            this.xrTableCell35.StylePriority.UseFont = false;
            this.xrTableCell35.StylePriority.UseTextAlignment = false;
            this.xrTableCell35.Text = "bis:";
            this.xrTableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            this.xrTableCell35.Weight = 0.4480942005602952D;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell36.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PersDepartmentTo")});
            this.xrTableCell36.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.StylePriority.UseBorders = false;
            this.xrTableCell36.StylePriority.UseFont = false;
            this.xrTableCell36.Weight = 3.2404113915018855D;
            // 
            // xrTable4
            // 
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(11.00016F, 76F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
            this.xrTable4.SizeF = new System.Drawing.SizeF(244.1313F, 14.16667F);
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell21,
            this.xrTableCell22});
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Weight = 1D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell21.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.StylePriority.UseBorders = false;
            this.xrTableCell21.StylePriority.UseFont = false;
            this.xrTableCell21.StylePriority.UseTextAlignment = false;
            this.xrTableCell21.Text = "Mandant von:";
            this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            this.xrTableCell21.Weight = 1.4944431160187595D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PersClientFrom")});
            this.xrTableCell22.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.StylePriority.UseBorders = false;
            this.xrTableCell22.StylePriority.UseFont = false;
            this.xrTableCell22.Weight = 2.9706176636820305D;
            // 
            // xrTable3
            // 
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(11.00021F, 54F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
            this.xrTable3.SizeF = new System.Drawing.SizeF(244.1313F, 14.16667F);
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
            this.xrTableCell31.Text = "Abteilung von:";
            this.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            this.xrTableCell31.Weight = 1.4944421392494134D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PersDepartmentFrom")});
            this.xrTableCell32.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.StylePriority.UseBorders = false;
            this.xrTableCell32.StylePriority.UseFont = false;
            this.xrTableCell32.Weight = 2.9706186404513764D;
            // 
            // xrTable5
            // 
            this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(11.00016F, 32.6667F);
            this.xrTable5.Name = "xrTable5";
            this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
            this.xrTable5.SizeF = new System.Drawing.SizeF(244.1313F, 14.16667F);
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell23,
            this.xrTableCell24});
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.Weight = 1D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell23.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StylePriority.UseBorders = false;
            this.xrTableCell23.StylePriority.UseFont = false;
            this.xrTableCell23.StylePriority.UseTextAlignment = false;
            this.xrTableCell23.Text = "Standort von:";
            this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            this.xrTableCell23.Weight = 1.4944431160187595D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PersLocationFrom")});
            this.xrTableCell24.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.StylePriority.UseBorders = false;
            this.xrTableCell24.StylePriority.UseFont = false;
            this.xrTableCell24.Weight = 2.9706176636820305D;
            // 
            // xrTable12
            // 
            this.xrTable12.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTable12.LocationFloat = new DevExpress.Utils.PointFloat(800.8335F, 54.00002F);
            this.xrTable12.Name = "xrTable12";
            this.xrTable12.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow14});
            this.xrTable12.SizeF = new System.Drawing.SizeF(256.4995F, 14.16666F);
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
            this.xrTableCell139.Weight = 2.1286356941201747D;
            // 
            // xrTableCell140
            // 
            this.xrTableCell140.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LoggedInUser")});
            this.xrTableCell140.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.xrTableCell140.Name = "xrTableCell140";
            this.xrTableCell140.StylePriority.UseFont = false;
            this.xrTableCell140.StylePriority.UseTextAlignment = false;
            this.xrTableCell140.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            this.xrTableCell140.Weight = 2.9489733473245217D;
            // 
            // xrTable9
            // 
            this.xrTable9.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTable9.LocationFloat = new DevExpress.Utils.PointFloat(800.8336F, 35.83333F);
            this.xrTable9.Name = "xrTable9";
            this.xrTable9.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow11});
            this.xrTable9.SizeF = new System.Drawing.SizeF(256.4995F, 14.16667F);
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
            this.xrTableCell37.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.StylePriority.UseFont = false;
            this.xrTableCell37.Text = "Druckbeginn nach:";
            this.xrTableCell37.Weight = 2.1379551344860532D;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "VariableTextType")});
            this.xrTableCell38.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.StylePriority.UseFont = false;
            this.xrTableCell38.Weight = 2.9618844702028015D;
            // 
            // xrPageInfo4
            // 
            this.xrPageInfo4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPageInfo4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo4.Format = "{0:dd.MM.yyyy}";
            this.xrPageInfo4.LocationFloat = new DevExpress.Utils.PointFloat(582.8264F, 35.83336F);
            this.xrPageInfo4.Name = "xrPageInfo4";
            this.xrPageInfo4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo4.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo4.SizeF = new System.Drawing.SizeF(76.04163F, 14.33332F);
            this.xrPageInfo4.StylePriority.UseBorders = false;
            this.xrPageInfo4.StylePriority.UseFont = false;
            // 
            // xrTable13
            // 
            this.xrTable13.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTable13.LocationFloat = new DevExpress.Utils.PointFloat(497.0869F, 36.00001F);
            this.xrTable13.Name = "xrTable13";
            this.xrTable13.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow15});
            this.xrTable13.SizeF = new System.Drawing.SizeF(85.73932F, 14.16665F);
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
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(728.3009F, 36.00001F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 12, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(65.62494F, 13.66662F);
            this.xrPageInfo1.StylePriority.UseBorders = false;
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UsePadding = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTable6
            // 
            this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(276.554F, 35.83336F);
            this.xrTable6.Name = "xrTable6";
            this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow8});
            this.xrTable6.SizeF = new System.Drawing.SizeF(201.6725F, 14.16667F);
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
            this.xrTableCell41.Weight = 0.44809475871402082D;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell42.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PersLocationTo")});
            this.xrTableCell42.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.StylePriority.UseBorders = false;
            this.xrTableCell42.StylePriority.UseFont = false;
            this.xrTableCell42.Weight = 3.24041083334816D;
            // 
            // xrTable18
            // 
            this.xrTable18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTable18.LocationFloat = new DevExpress.Utils.PointFloat(676.5353F, 36.00001F);
            this.xrTable18.Name = "xrTable18";
            this.xrTable18.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow20});
            this.xrTable18.SizeF = new System.Drawing.SizeF(51.7655F, 14.16666F);
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
            // PersonalReportsListDto
            // 
            this.PersonalReportsListDto.DataSource = typeof(Access_Control_NewMask.Dtos.PersonalReportsListDto);
            this.PersonalReportsListDto.Name = "PersonalReportsListDto";
            // 
            // PersonalReportListVarD
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.pageHeaderBand1,
            this.pageFooterBand1,
            this.reportHeaderBand1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.PersonalReportsListDto});
            this.DataSource = this.PersonalReportsListDto;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(8, 6, 0, 81);
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
            ((System.ComponentModel.ISupportInitialize)(this.xrTable11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonalReportsListDto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
