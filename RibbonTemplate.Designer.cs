
namespace OrbHwDoc
{
    partial class RibbonTemplate : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonTemplate()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabTemplate = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.TglBtoDocIdProp = this.Factory.CreateRibbonToggleButton();
            this.tabTemplate.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTemplate
            // 
            this.tabTemplate.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabTemplate.Groups.Add(this.group1);
            this.tabTemplate.Label = "ORBITAL - HW";
            this.tabTemplate.Name = "tabTemplate";
            // 
            // group1
            // 
            this.group1.Items.Add(this.TglBtoDocIdProp);
            this.group1.Label = "group1";
            this.group1.Name = "group1";
            // 
            // TglBtoDocIdProp
            // 
            this.TglBtoDocIdProp.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.TglBtoDocIdProp.Label = "Propiedades Generales";
            this.TglBtoDocIdProp.Name = "TglBtoDocIdProp";
            this.TglBtoDocIdProp.ShowImage = true;
            this.TglBtoDocIdProp.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.TglBtoDocIdProp_Click);
            // 
            // RibbonTemplate
            // 
            this.Name = "RibbonTemplate";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tabTemplate);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonTemplate_Load);
            this.tabTemplate.ResumeLayout(false);
            this.tabTemplate.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabTemplate;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton TglBtoDocIdProp;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonTemplate RibbonTemplate
        {
            get { return this.GetRibbon<RibbonTemplate>(); }
        }
    }
}
