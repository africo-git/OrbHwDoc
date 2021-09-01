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
            // Carga los controles en el ActionsPane
            Globals.ThisDocument.ActionsPane.Controls.Add(Globals.ThisDocument.myDocIdProp_Uc);
            Globals.ThisDocument.ActionsPane.Controls.Add(Globals.ThisDocument.myDocVerCtrl_Uc);

            // Almacena los índices de los controles cargados en el ActionsPane
            int myDocIdProp_Uc_index = Globals.ThisDocument.ActionsPane.Controls.GetChildIndex(Globals.ThisDocument.myDocIdProp_Uc);
            int myDocVerCtrl_Uc_index = Globals.ThisDocument.ActionsPane.Controls.GetChildIndex(Globals.ThisDocument.myDocVerCtrl_Uc);

            // Oculta todos los controles en el ActionsPane
            Globals.ThisDocument.ActionsPane.Controls[myDocIdProp_Uc_index].Visible = false;
            Globals.ThisDocument.ActionsPane.Controls[myDocVerCtrl_Uc_index].Visible = false;

            // Oculta el Document Actions Task Pane
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

            // Código del documento
            if (!OrbHwDocTool.CustomPropertyExist("orbDocCode"))
                OrbHwDocTool.NewDocCustomProperty("orbDocCode", Office.MsoDocProperties.msoPropertyTypeString, "Document Code");

            // Título del documento
            if (!OrbHwDocTool.CustomPropertyExist("orbDocTittle"))
                OrbHwDocTool.NewDocCustomProperty("orbDocTittle", Office.MsoDocProperties.msoPropertyTypeString, "Document Tittle");

            // Título corto del documento
            if (!OrbHwDocTool.CustomPropertyExist("orbDocShortTittle"))
                OrbHwDocTool.NewDocCustomProperty("orbDocShortTittle", Office.MsoDocProperties.msoPropertyTypeString, "Document Short Tittle");

            //Clase del documento
            if (!OrbHwDocTool.CustomPropertyExist("orbDocClass"))
                OrbHwDocTool.NewDocCustomProperty("orbDocClass", Office.MsoDocProperties.msoPropertyTypeString, "Class");

            //Subclase del documento
            if (!OrbHwDocTool.CustomPropertyExist("orbDocSubclass"))
                OrbHwDocTool.NewDocCustomProperty("orbDocSubclass", Office.MsoDocProperties.msoPropertyTypeString, "Subclass");

            //Edición del documeto
            if (!OrbHwDocTool.CustomPropertyExist("orbDocMajorIssue"))
                OrbHwDocTool.NewDocCustomProperty("orbDocMajorIssue", Office.MsoDocProperties.msoPropertyTypeNumber, "1");

            //Revisión del documeto
            if (!OrbHwDocTool.CustomPropertyExist("orbDocMinorIssue"))
                OrbHwDocTool.NewDocCustomProperty("orbDocMinorIssue", Office.MsoDocProperties.msoPropertyTypeNumber, "0");

            //Fecha general de versión del documento
            if (!OrbHwDocTool.CustomPropertyExist("orbDocIssueDate"))
                OrbHwDocTool.NewDocCustomProperty("orbDocIssueDate", Office.MsoDocProperties.msoPropertyTypeDate, DateTime.Now);

            //Motivo de la versión 1.0 (inicial) del documento
            if (!OrbHwDocTool.CustomPropertyExist("orbDocIssue1-0Reson"))
                OrbHwDocTool.NewDocCustomProperty("orbDocIssue1-0Reson", Office.MsoDocProperties.msoPropertyTypeString, "Document generation");

            //Fecha de la versión 1.0 (inicial) del documento
            if (!OrbHwDocTool.CustomPropertyExist("orbDocIssue1-0Date"))
                OrbHwDocTool.NewDocCustomProperty("orbDocIssue1-0Date", Office.MsoDocProperties.msoPropertyTypeDate, DateTime.Now);

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