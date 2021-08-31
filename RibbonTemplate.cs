using Microsoft.Office.Tools.Ribbon;
using Word = Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;


namespace OrbHwDoc
{
    public partial class RibbonTemplate
    {
        private void RibbonTemplate_Load(object sender, RibbonUIEventArgs e)
        {
            
        }

        private void TglBtoDocIdProp_Click(object sender, RibbonControlEventArgs e)
        {
            if(TglBtoDocIdProp.Checked)
            {
                Globals.ThisDocument.ActionsPane.Controls.Remove(ThisDocument.MyDocIdProp_Uc);
                Globals.ThisDocument.ActionsPane.Controls.Add(ThisDocument.MyDocIdProp_Uc);
                Globals.ThisDocument.Application.TaskPanes[Word.WdTaskPanes.wdTaskPaneDocumentActions].Visible = true;

                TglBtoCtrlVer.Enabled = false;  // Desactivado otros botones incompatibles
            }
            else
            {
                Globals.ThisDocument.ActionsPane.Controls.Remove(ThisDocument.MyDocIdProp_Uc);
                Globals.ThisDocument.Application.TaskPanes[Word.WdTaskPanes.wdTaskPaneDocumentActions].Visible = false;

                TglBtoCtrlVer.Enabled = true;   // Activa los botones que eran incompatibles
            }
        }

        private void TglBtoCtrlVer_Click(object sender, RibbonControlEventArgs e)
        {
            if (TglBtoCtrlVer.Checked)
            {
                Globals.ThisDocument.ActionsPane.Controls.Remove(ThisDocument.MyDocIdProp_Uc);
                Globals.ThisDocument.ActionsPane.Controls.Add(new Button());    // Probamos con un botón
                Globals.ThisDocument.Application.TaskPanes[Word.WdTaskPanes.wdTaskPaneDocumentActions].Visible = true;

                TglBtoDocIdProp.Enabled = false;    // Desactivado otros botones incompatibles
            }
            else
            {
                Globals.ThisDocument.ActionsPane.Controls.Remove(ThisDocument.MyDocIdProp_Uc);
                Globals.ThisDocument.Application.TaskPanes[Word.WdTaskPanes.wdTaskPaneDocumentActions].Visible = false;

                TglBtoDocIdProp.Enabled = true;     // Activa los botones que eran incompatibles
            }
        }
    }
}
