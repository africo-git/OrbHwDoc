using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Office.Tools.Word;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

namespace OrbHwDoc
{
    public partial class ThisDocument
    {
        private static DocIdProp_Uc myDocIdProp_Uc = new DocIdProp_Uc();

        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {
            // Es necesario llamar a este procedimiento es esta parte del documento
            // para que funcione bien el "document actionon pane".
            OrbHwDocTool.DocActionTaskPaneIni();

            OrbHwDocTool.RestoreFundamentalProp();
        }

        private void ThisDocument_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region Propiedades de la clase
        public static DocIdProp_Uc MyDocIdProp_Uc
        {
            get => myDocIdProp_Uc;
        }
        #endregion

        #region Código generado por el Diseñador de VSTO

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisDocument_Startup);
            this.Shutdown += new System.EventHandler(ThisDocument_Shutdown);
        }

        #endregion
    }
}
