using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

namespace OrbHwDoc
{
    public partial class DocIdProp_Uc : UserControl
    {
        public DocIdProp_Uc()
        {
            InitializeComponent();
        }

        public void UpdateFrom()
        {
            Office.DocumentProperties myCustomProp =
                Globals.ThisDocument.CustomDocumentProperties as Office.DocumentProperties;

            if (OrbHwDocTool.CustomPropertyExist("orbDocCode"))
                this.MyDocIdProp_Uc_Wpf.txtOrbDocCode.Text = (string)myCustomProp["orbDocCode"].Value;

            if (OrbHwDocTool.CustomPropertyExist("orbDocTittle"))
                this.MyDocIdProp_Uc_Wpf.txtOrbDocTittle.Text = (string)myCustomProp["orbDocTittle"].Value;

            if (OrbHwDocTool.CustomPropertyExist("orbDocShortTittle"))
                this.MyDocIdProp_Uc_Wpf.txtOrbDocShortTittle.Text = (string)myCustomProp["orbDocShortTittle"].Value;

            if (OrbHwDocTool.CustomPropertyExist("orbDocClass"))
                this.MyDocIdProp_Uc_Wpf.txtOrbDocClass.Text = (string)myCustomProp["orbDocClass"].Value;

            if (OrbHwDocTool.CustomPropertyExist("orbDocSubclass"))
                this.MyDocIdProp_Uc_Wpf.txtOrbDocSubclass.Text = (string)myCustomProp["orbDocSubclass"].Value;

            if (OrbHwDocTool.CustomPropertyExist("orbDocMajorIssue") && OrbHwDocTool.CustomPropertyExist("orbDocMinorIssue"))
                this.MyDocIdProp_Uc_Wpf.txtOrbDocIssue.Text = Convert.ToString((int)myCustomProp["orbDocMajorIssue"].Value) + "." +
                    Convert.ToString((int)myCustomProp["orbDocMinorIssue"].Value);

            if (OrbHwDocTool.CustomPropertyExist("orbDocIssueDate"))
                this.MyDocIdProp_Uc_Wpf.dateOrbDocIssueDate.SelectedDate = (DateTime)myCustomProp["orbDocIssueDate"].Value;
        }

        public void SaveChange()
        {
            Office.DocumentProperties myCustomProp =
                Globals.ThisDocument.CustomDocumentProperties as Office.DocumentProperties;

            if (OrbHwDocTool.CustomPropertyExist("orbDocCode"))
                myCustomProp["orbDocCode"].Value = MyDocIdProp_Uc_Wpf.txtOrbDocCode.Text;

            if (OrbHwDocTool.CustomPropertyExist("orbDocTittle"))
                myCustomProp["orbDocTittle"].Value = MyDocIdProp_Uc_Wpf.txtOrbDocTittle.Text;

            if (OrbHwDocTool.CustomPropertyExist("orbDocShortTittle"))
                myCustomProp["orbDocShortTittle"].Value = MyDocIdProp_Uc_Wpf.txtOrbDocShortTittle.Text;

            if (OrbHwDocTool.CustomPropertyExist("orbDocClass"))
                myCustomProp["orbDocClass"].Value = MyDocIdProp_Uc_Wpf.txtOrbDocClass.Text;

            if (OrbHwDocTool.CustomPropertyExist("orbDocSubclass"))
                myCustomProp["orbDocSubclass"].Value = MyDocIdProp_Uc_Wpf.txtOrbDocSubclass.Text;

            if (OrbHwDocTool.CustomPropertyExist("orbDocIssueDate"))
                myCustomProp["orbDocIssueDate"].Value = MyDocIdProp_Uc_Wpf.dateOrbDocIssueDate.SelectedDate;

            OrbHwDocTool.UpdateAllDocFields();
        }
    }
}
