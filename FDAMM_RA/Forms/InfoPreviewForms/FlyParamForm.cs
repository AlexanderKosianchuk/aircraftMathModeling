using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

using Resources;

namespace FDAMM_RA
{
    public partial class FlyParamForm : DockContent
    {
        MainForm mForm;

        public FlyParamForm(MainForm MainForm)
        {
            mForm = MainForm;
            InitializeComponent();
            InitCheckedListBoxItems(this.checkedListBox1);
            checkedListBox1.SetItemChecked(0, true);
        }

        public void InitCheckedListBoxItems(CheckedListBox clb)
        {
            clb.Items.Add("t");

            clb.Items.Add("Vx");
            clb.Items.Add("Vy");
            clb.Items.Add("Vz");

            clb.Items.Add("Wx");
            clb.Items.Add("Wy");
            clb.Items.Add("Wz");

            clb.Items.Add("Xg");
            clb.Items.Add("Yg");
            clb.Items.Add("Zg");

            clb.Items.Add("GAMA");
            clb.Items.Add("PSI");
            clb.Items.Add("THETA");
            clb.Items.Add("THETA_PATH");

            clb.Items.Add("V");
            clb.Items.Add("ALPHA");
            clb.Items.Add("BETA");

            clb.Items.Add("Fx1");
            clb.Items.Add("Fy1");
            clb.Items.Add("Fz1");

            clb.Items.Add("Cxa");
            clb.Items.Add("Cya");
            clb.Items.Add("Cza");

            clb.Items.Add("Fx2");
            clb.Items.Add("Fy2");
            clb.Items.Add("Fz2");

            clb.Items.Add("Fx3");
            clb.Items.Add("Fy3");
            clb.Items.Add("Fz3");

            clb.Items.Add("Mx1");
            clb.Items.Add("My1");
            clb.Items.Add("Mz1");

            clb.Items.Add("oWx");
            clb.Items.Add("oWy");
            clb.Items.Add("oWz");

            clb.Items.Add("Mx3");
            clb.Items.Add("My3");
            clb.Items.Add("Mz3");

            clb.Items.Add("del_e");
            clb.Items.Add("del_e_rv");
            clb.Items.Add("del_n");
            clb.Items.Add("Tr");

            clb.Items.Add("dVx");
            clb.Items.Add("dVy");
            clb.Items.Add("dVz");

            clb.Items.Add("dWx");
            clb.Items.Add("dWy");
            clb.Items.Add("dWz");

            clb.Items.Add("dXg");
            clb.Items.Add("dYg");
            clb.Items.Add("dZg");

            clb.Items.Add("dGAMA");
            clb.Items.Add("dPSI");
            clb.Items.Add("dTHETA");
            clb.Items.Add("dTHETA_PATH");

            clb.Items.Add("dV");
            clb.Items.Add("dALPHA");
            clb.Items.Add("dBETA");
        
        }

        private void FlyParamForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mForm.toolStripButton2_FlyParam.Checked = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            mForm.dgForm.InitDataGrid();
        }



    }
}
