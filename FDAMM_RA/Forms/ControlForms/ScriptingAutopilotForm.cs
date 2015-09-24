using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using MathPlaneModel;

namespace FDAMM_RA
{
    public partial class ScriptingAutopilotForm : DockContent
    {
        MainForm mForm;

        public ScriptingAutopilotForm(MainForm MainForm)
        {
            mForm = MainForm;
            InitializeComponent();
        }

        private void ScriptingAutopilotForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            mForm.toolStripButton8_ScriptingAutopilot.Checked = false;
        }


    }
}
