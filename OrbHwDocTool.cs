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

        #region PROPIEDADES DEL DOCUMENTO
        public static void NewDocCustomProperty(string prop, Office.MsoDocProperties type, object content)
        {
            Office.DocumentProperties toolDocCustomProps =
                Globals.ThisDocument.CustomDocumentProperties as Office.DocumentProperties;

            if (!CustomPropertyExist(prop))
                toolDocCustomProps.Add(prop, false, type, content);
        }

        public static Boolean CustomPropertyExist(string propName)
        {
            Office.DocumentProperties toolDocCustomProps =
                Globals.ThisDocument.CustomDocumentProperties as Office.DocumentProperties;

            try
            {
                Office.DocumentProperty temp = toolDocCustomProps[propName];
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

    }
}