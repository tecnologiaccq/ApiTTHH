using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

/// <summary>
/// Summary description for SolicitudVacacion
/// </summary>
public class SolicitudVacacion : DevExpress.XtraReports.UI.XtraReport
{
	private TopMarginBand TopMargin;
	private BottomMarginBand BottomMargin;
	private DetailBand Detail;
	private XRLabel lbl_empresa;
	private XRLabel xrLabel1;
	private XRLabel lbl_ruc_empresa;
	private XRLabel xrLabel4;
	private XRLabel xrLabel5;
	private XRRichText xrRichText2;
	private DevExpress.DataAccess.Json.JsonDataSource jsonDataSource2;
	private DetailReportBand DetailReport;
	private DetailBand Detail1;
	private GroupHeaderBand GroupHeader1;
	private XRLabel xrLabel18;
	private XRTable xrTable1;
	private XRTableRow xrTableRow1;
	private XRTableCell xrTableCell1;
	private XRTableCell xrTableCell2;
	private XRTableCell xrTableCell3;
	private XRTableCell xrTableCell4;
	private XRTable xrTable4;
	private XRTableRow xrTableRow4;
	private XRTableCell xrTableCell10;
	private XRTableCell xrTableCell11;
	private XRTableCell xrTableCell12;
	private XRTableCell xrTableCell13;
	private ReportFooterBand ReportFooter;
	private XRLine xrLine3;
	private XRLabel xrLabel10;
	private XRLabel xrLabel11;
	private XRLabel xrLabel8;
	private XRLine xrLine2;
	private XRLabel xrLabel9;
	private XRLabel xrLabel7;
	private XRLabel xrLabel6;
	private XRLine xrLine1;
    private XRRichText xrRichText3;
    private XRRichText xrRichText5;
    private XRRichText xrRichText4;
    private DevExpress.DataAccess.Json.JsonDataSource jsonDataSource1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

	public SolicitudVacacion()
	{
		InitializeComponent();
		CultureInfo culture = new CultureInfo("es-MX");
		//
		// TODO: Add constructor logic here
		//
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolicitudVacacion));
            DevExpress.DataAccess.Json.CustomJsonSource customJsonSource1 = new DevExpress.DataAccess.Json.CustomJsonSource();
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode1 = new DevExpress.DataAccess.Json.JsonSchemaNode("root", true);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode2 = new DevExpress.DataAccess.Json.JsonSchemaNode("Fecha", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<System.DateTime>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode3 = new DevExpress.DataAccess.Json.JsonSchemaNode("Dias", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<double>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode4 = new DevExpress.DataAccess.Json.JsonSchemaNode("fechaInicio", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<System.DateTime>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode5 = new DevExpress.DataAccess.Json.JsonSchemaNode("fechafin", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<System.DateTime>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode6 = new DevExpress.DataAccess.Json.JsonSchemaNode("nombre", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode7 = new DevExpress.DataAccess.Json.JsonSchemaNode("reemplazo", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode8 = new DevExpress.DataAccess.Json.JsonSchemaNode("cargo", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode9 = new DevExpress.DataAccess.Json.JsonSchemaNode("nombreJefe", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode10 = new DevExpress.DataAccess.Json.JsonSchemaNode("empresa", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode11 = new DevExpress.DataAccess.Json.JsonSchemaNode("ruc_empresa", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode12 = new DevExpress.DataAccess.Json.JsonSchemaNode("Detalle", true, DevExpress.DataAccess.Json.JsonNodeType.Array);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode13 = new DevExpress.DataAccess.Json.JsonSchemaNode("diasPeriodo", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<double>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode14 = new DevExpress.DataAccess.Json.JsonSchemaNode("anio", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode15 = new DevExpress.DataAccess.Json.JsonSchemaNode("FechaInicial", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<System.DateTime>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode16 = new DevExpress.DataAccess.Json.JsonSchemaNode("FechaFinal", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<System.DateTime>));
            DevExpress.XtraReports.UI.XRWatermark xrWatermark1 = new DevExpress.XtraReports.UI.XRWatermark();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrRichText2 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_ruc_empresa = new DevExpress.XtraReports.UI.XRLabel();
            this.lbl_empresa = new DevExpress.XtraReports.UI.XRLabel();
            this.jsonDataSource2 = new DevExpress.DataAccess.Json.JsonDataSource(this.components);
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrRichText5 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText4 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichText3 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.jsonDataSource1 = new DevExpress.DataAccess.Json.JsonDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 64F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrRichText2,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel1,
            this.lbl_ruc_empresa,
            this.lbl_empresa});
            this.Detail.HeightF = 274.6667F;
            this.Detail.Name = "Detail";
            // 
            // xrRichText2
            // 
            this.xrRichText2.Font = new DevExpress.Drawing.DXFont("Arial", 11.25F, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, new DevExpress.Drawing.DXFontAdditionalProperty[] {
            new DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", ((byte)(0)))});
            this.xrRichText2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 211.125F);
            this.xrRichText2.Name = "xrRichText2";
            this.xrRichText2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrRichText2.SerializableRtfString = resources.GetString("xrRichText2.SerializableRtfString");
            this.xrRichText2.SizeF = new System.Drawing.SizeF(727F, 63.54166F);
            this.xrRichText2.StylePriority.UseFont = false;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new DevExpress.Drawing.DXFont("Arial", 11.25F, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, new DevExpress.Drawing.DXFontAdditionalProperty[] {
            new DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", ((byte)(0)))});
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 159.7083F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(727F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "SOLICITUD DE VACACIONES GOZADAS";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new DevExpress.Drawing.DXFont("Arial", 11F);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(466.6666F, 97.12499F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(260.3334F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Quito,  [Fecha!d \'de\' MMMM \'de\' yyyy]";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel4.TextFormatString = "{0:d \'de\' MMMM \'de\' yyyy}";
            this.xrLabel4.Draw += new DevExpress.XtraReports.UI.DrawEventHandler(this.xrLabel4_Draw);
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new DevExpress.Drawing.DXFont("Arial", 11F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 46F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(727.0001F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Amazonas s/n y República";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbl_ruc_empresa
            // 
            this.lbl_ruc_empresa.Font = new DevExpress.Drawing.DXFont("Arial", 11F);
            this.lbl_ruc_empresa.LocationFloat = new DevExpress.Utils.PointFloat(0F, 23F);
            this.lbl_ruc_empresa.Multiline = true;
            this.lbl_ruc_empresa.Name = "lbl_ruc_empresa";
            this.lbl_ruc_empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_ruc_empresa.SizeF = new System.Drawing.SizeF(727F, 23F);
            this.lbl_ruc_empresa.StylePriority.UseFont = false;
            this.lbl_ruc_empresa.StylePriority.UseTextAlignment = false;
            this.lbl_ruc_empresa.Text = "RUC: [ruc_empresa]";
            this.lbl_ruc_empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbl_empresa
            // 
            this.lbl_empresa.Font = new DevExpress.Drawing.DXFont("Arial", 11.25F, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, new DevExpress.Drawing.DXFontAdditionalProperty[] {
            new DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", ((byte)(0)))});
            this.lbl_empresa.LocationFloat = new DevExpress.Utils.PointFloat(1.589457E-05F, 0F);
            this.lbl_empresa.Multiline = true;
            this.lbl_empresa.Name = "lbl_empresa";
            this.lbl_empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbl_empresa.SizeF = new System.Drawing.SizeF(727F, 23F);
            this.lbl_empresa.StylePriority.UseFont = false;
            this.lbl_empresa.StylePriority.UseTextAlignment = false;
            this.lbl_empresa.Text = "[empresa]";
            this.lbl_empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // jsonDataSource2
            // 
            customJsonSource1.Json = resources.GetString("customJsonSource1.Json");
            this.jsonDataSource2.JsonSource = customJsonSource1;
            this.jsonDataSource2.Name = "jsonDataSource2";
            jsonSchemaNode12.Nodes.Add(jsonSchemaNode13);
            jsonSchemaNode12.Nodes.Add(jsonSchemaNode14);
            jsonSchemaNode12.Nodes.Add(jsonSchemaNode15);
            jsonSchemaNode12.Nodes.Add(jsonSchemaNode16);
            jsonSchemaNode1.Nodes.Add(jsonSchemaNode2);
            jsonSchemaNode1.Nodes.Add(jsonSchemaNode3);
            jsonSchemaNode1.Nodes.Add(jsonSchemaNode4);
            jsonSchemaNode1.Nodes.Add(jsonSchemaNode5);
            jsonSchemaNode1.Nodes.Add(jsonSchemaNode6);
            jsonSchemaNode1.Nodes.Add(jsonSchemaNode7);
            jsonSchemaNode1.Nodes.Add(jsonSchemaNode8);
            jsonSchemaNode1.Nodes.Add(jsonSchemaNode9);
            jsonSchemaNode1.Nodes.Add(jsonSchemaNode10);
            jsonSchemaNode1.Nodes.Add(jsonSchemaNode11);
            jsonSchemaNode1.Nodes.Add(jsonSchemaNode12);
            this.jsonDataSource2.Schema = jsonSchemaNode1;
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1,
            this.GroupHeader1,
            this.ReportFooter});
            this.DetailReport.DataMember = "Detalle";
            this.DetailReport.DataSource = this.jsonDataSource2;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail1.HeightF = 18F;
            this.Detail1.Name = "Detail1";
            // 
            // xrTable1
            // 
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(727F, 18F);
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 11.5D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell1.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.xrTableCell1.StylePriority.UseBackColor = false;
            this.xrTableCell1.StylePriority.UseBorders = false;
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UsePadding = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "[anio]";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell1.Weight = 0.090972142412322959D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell2.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.xrTableCell2.StylePriority.UseBackColor = false;
            this.xrTableCell2.StylePriority.UseBorders = false;
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UsePadding = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "[diasPeriodo]";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell2.Weight = 0.15181142529904976D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell3.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.xrTableCell3.StylePriority.UseBackColor = false;
            this.xrTableCell3.StylePriority.UseBorders = false;
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UsePadding = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "[FechaInicial!d \'de\' MMMM \'de\' yyyy]";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell3.Weight = 0.17062925726892936D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell4.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.xrTableCell4.StylePriority.UseBackColor = false;
            this.xrTableCell4.StylePriority.UseBorders = false;
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UsePadding = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "[FechaFinal!d \'de\' MMMM \'de\' yyyy]";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell4.Weight = 0.14043332886585186D;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4,
            this.xrLabel18});
            this.GroupHeader1.HeightF = 36F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable4
            // 
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 18F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable4.SizeF = new System.Drawing.SizeF(727.0001F, 18F);
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell13});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 11.5D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.BackColor = System.Drawing.Color.Gainsboro;
            this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell10.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell10.Multiline = true;
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.xrTableCell10.StylePriority.UseBackColor = false;
            this.xrTableCell10.StylePriority.UseBorders = false;
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.StylePriority.UsePadding = false;
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.Text = "Período";
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell10.Weight = 0.090972142412322959D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.BackColor = System.Drawing.Color.Gainsboro;
            this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell11.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell11.Multiline = true;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.xrTableCell11.StylePriority.UseBackColor = false;
            this.xrTableCell11.StylePriority.UseBorders = false;
            this.xrTableCell11.StylePriority.UseFont = false;
            this.xrTableCell11.StylePriority.UsePadding = false;
            this.xrTableCell11.StylePriority.UseTextAlignment = false;
            this.xrTableCell11.Text = "Días a Disfrutar\t";
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell11.Weight = 0.15181142529904976D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.BackColor = System.Drawing.Color.Gainsboro;
            this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell12.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell12.Multiline = true;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.xrTableCell12.StylePriority.UseBackColor = false;
            this.xrTableCell12.StylePriority.UseBorders = false;
            this.xrTableCell12.StylePriority.UseFont = false;
            this.xrTableCell12.StylePriority.UsePadding = false;
            this.xrTableCell12.StylePriority.UseTextAlignment = false;
            this.xrTableCell12.Text = "Fecha Inicial";
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell12.Weight = 0.17062925726892936D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.BackColor = System.Drawing.Color.Gainsboro;
            this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell13.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell13.Multiline = true;
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.xrTableCell13.StylePriority.UseBackColor = false;
            this.xrTableCell13.StylePriority.UseBorders = false;
            this.xrTableCell13.StylePriority.UseFont = false;
            this.xrTableCell13.StylePriority.UsePadding = false;
            this.xrTableCell13.StylePriority.UseTextAlignment = false;
            this.xrTableCell13.Text = "Fecha Final";
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell13.Weight = 0.14043332886585186D;
            // 
            // xrLabel18
            // 
            this.xrLabel18.BackColor = System.Drawing.Color.Gainsboro;
            this.xrLabel18.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel18.Font = new DevExpress.Drawing.DXFont("Calibri", 12F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel18.Multiline = true;
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(727F, 18F);
            this.xrLabel18.StylePriority.UseBackColor = false;
            this.xrLabel18.StylePriority.UseBorders = false;
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "PERÍODOS";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrRichText5,
            this.xrRichText4,
            this.xrRichText3,
            this.xrLine3,
            this.xrLabel10,
            this.xrLabel11,
            this.xrLabel8,
            this.xrLine2,
            this.xrLabel9,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLine1});
            this.ReportFooter.HeightF = 402.2501F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrRichText5
            // 
            this.xrRichText5.Font = new DevExpress.Drawing.DXFont("Arial", 11.25F, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, new DevExpress.Drawing.DXFontAdditionalProperty[] {
            new DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", ((byte)(0)))});
            this.xrRichText5.LocationFloat = new DevExpress.Utils.PointFloat(55.20833F, 26.6667F);
            this.xrRichText5.Name = "xrRichText5";
            this.xrRichText5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrRichText5.SerializableRtfString = resources.GetString("xrRichText5.SerializableRtfString");
            this.xrRichText5.SizeF = new System.Drawing.SizeF(298.8955F, 26.45833F);
            this.xrRichText5.StylePriority.UseFont = false;
            // 
            // xrRichText4
            // 
            this.xrRichText4.Font = new DevExpress.Drawing.DXFont("Arial", 11.25F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrRichText4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 26.6667F);
            this.xrRichText4.Name = "xrRichText4";
            this.xrRichText4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrRichText4.SerializableRtfString = resources.GetString("xrRichText4.SerializableRtfString");
            this.xrRichText4.SizeF = new System.Drawing.SizeF(55.20833F, 26.4583F);
            this.xrRichText4.StylePriority.UseFont = false;
            // 
            // xrRichText3
            // 
            this.xrRichText3.Font = new DevExpress.Drawing.DXFont("Arial", 11.25F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrRichText3.LocationFloat = new DevExpress.Utils.PointFloat(354.1039F, 26.6667F);
            this.xrRichText3.Name = "xrRichText3";
            this.xrRichText3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrRichText3.SerializableRtfString = resources.GetString("xrRichText3.SerializableRtfString");
            this.xrRichText3.SizeF = new System.Drawing.SizeF(340.6045F, 26.45833F);
            this.xrRichText3.StylePriority.UseFont = false;
            // 
            // xrLine3
            // 
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(227.0367F, 137.0834F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(285.4167F, 12.5F);
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(245.638F, 149.5833F);
            this.xrLabel10.Multiline = true;
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(252.0833F, 22.99999F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "[nombre]";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(245.638F, 172.5833F);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(252.0833F, 22.99999F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Trabajador/a";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(450.1846F, 346.2501F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(252.0833F, 22.99999F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Talento Humano";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine2
            // 
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(431.5833F, 333.7501F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(285.4167F, 12.5F);
            // 
            // xrLabel9
            // 
            this.xrLabel9.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(450.1846F, 369.2501F);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(252.0833F, 22.99999F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Registrado";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(22.76796F, 369.2501F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(252.0833F, 32.99997F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Jefe Inmediato\r\nAutorizado";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(22.76796F, 346.2501F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(252.0833F, 22.99999F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "[nombreJefe]";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(4.166698F, 333.7501F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(285.4167F, 12.5F);
            // 
            // jsonDataSource1
            // 
            this.jsonDataSource1.Name = "jsonDataSource1";
            // 
            // SolicitudVacacion
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.DetailReport});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.jsonDataSource2,
            this.jsonDataSource1});
            this.DataSource = this.jsonDataSource2;
            this.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "BackColor", "[empresa]\n\n")});
            this.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F);
            this.Margins = new DevExpress.Drawing.DXMargins(50F, 50F, 64F, 100F);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.Version = "24.2";
            xrWatermark1.Id = "Watermark1";
            this.Watermarks.AddRange(new DevExpress.XtraPrinting.Drawing.Watermark[] {
            xrWatermark1});
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion

	private void xrLabel4_Draw(object sender, DrawEventArgs e)
	{
		XRLabel label = sender as XRLabel;
		CultureInfo culture = new CultureInfo("es-MX");
		label.Text = string.Format(culture, label.Text);
	}
}
