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
        public static void RestoreFundamentalProp()
        {

            // Compañía
            if (!OrbHwDocTool.CustomPropertyExist("orbCompany"))
                OrbHwDocTool.NewDocCustomProperty("orbCompany", Office.MsoDocProperties.msoPropertyTypeString, "Orbital Sistemas Aeroespaciales, S.L.");

            // Dirección 1 Compañía
            if (!OrbHwDocTool.CustomPropertyExist("orbCompanyAddress1"))
                OrbHwDocTool.NewDocCustomProperty("orbCompanyAddress1", Office.MsoDocProperties.msoPropertyTypeString, "Carretera de Artica 29, 3ª Planta");

            // Dirección 2 Compañía
            if (!OrbHwDocTool.CustomPropertyExist("orbCompanyAddress2"))
                OrbHwDocTool.NewDocCustomProperty("orbCompanyAddress2", Office.MsoDocProperties.msoPropertyTypeString, "31013 Artica, Navarra");

            // Dirección 3 Compañía
            if (!OrbHwDocTool.CustomPropertyExist("orbCompanyAddress3"))
                OrbHwDocTool.NewDocCustomProperty("orbCompanyAddress3", Office.MsoDocProperties.msoPropertyTypeString, "SPAIN");

            // CIF Compañía
            if (!OrbHwDocTool.CustomPropertyExist("orbCif"))
                OrbHwDocTool.NewDocCustomProperty("orbCif", Office.MsoDocProperties.msoPropertyTypeString, "CIF: B31954506");

            // Actualizamos todos los campos del documento
            OrbHwDocTool.UpdateAllDocFields();

        }

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

        public static void UpdateAllDocFields()
        {
            foreach (Word.Range range in Globals.ThisDocument.StoryRanges)
            {
                Word.Range r = range;

                while (r != null)
                {
                    r.Fields.Update();
                    r = r.NextStoryRange;       // return null at the end.
                }
            }
        }
        #endregion

    }
}