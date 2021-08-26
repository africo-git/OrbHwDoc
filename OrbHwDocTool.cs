using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;


namespace OrbHwDoc
{
    public static class OrbHwDocTool
    {
        public static void DocActionTaskPaneIni()
        {
            Globals.ThisDocument.ActionsPane.Controls.Add(new Label());
            Globals.ThisDocument.ActionsPane.Controls.Clear();  // Quita todos los controles.
            Globals.ThisDocument.Application.TaskPanes[Word.WdTaskPanes.wdTaskPaneDocumentActions].Visible = false;
        }
    }
}
