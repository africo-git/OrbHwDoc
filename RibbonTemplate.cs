using Microsoft.Office.Tools.Ribbon;
using Word = Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                Globals.ThisDocument.ActionsPane.Controls.Add(ThisDocument.MyDocIdProp_Uc);
                Globals.ThisDocument.Application.TaskPanes[Word.WdTaskPanes.wdTaskPaneDocumentActions].Visible = true;

                ThisDocument.MyDocIdProp_Uc.UpdateFrom();
            }
            else
            {
                Globals.ThisDocument.ActionsPane.Controls.Remove(ThisDocument.MyDocIdProp_Uc);
                Globals.ThisDocument.Application.TaskPanes[Word.WdTaskPanes.wdTaskPaneDocumentActions].Visible = false;
            }
        }
    }
}
