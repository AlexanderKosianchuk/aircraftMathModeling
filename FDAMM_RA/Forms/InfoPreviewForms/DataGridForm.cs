using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace FDAMM_RA
{
    public partial class DataGridForm : DockContent
    {
        MainForm mForm;

        public DataGridForm(MainForm MainForm)
        {
            mForm = MainForm;
            InitializeComponent();
            InitDataGrid();
        }

        /// <summary>
        /// Return fly parameter reference by a string
        /// </summary>
        /// <param name="s">Input string or fly parameter</param>
        /// <returns></returns>
        public Object InitDataObject(String s)
        {
            Object o = new Object();
            switch (s)
            {
                case "t" : o = mForm.t; break;
                case "Vx" : o = mForm.S.Vx; break;
                case "Vy" : o = mForm.S.Vy; break;
                case "Vz" : o = mForm.S.Vz; break;

                case "Wx" : o = mForm.S.Wx; break;
                case "Wy" : o = mForm.S.Wy; break;
                case "Wz" : o = mForm.S.Wz; break;

                case "Xg" : o = mForm.S.Xg; break;
                case "Yg" : o = mForm.S.Yg; break;
                case "Zg" : o = mForm.S.Zg; break;

                case "GAMA": o = mForm.S.GAMA; break;
                case "PSI": o = mForm.S.PSI; break;
                case "THETA": o = mForm.S.THETA; break;
                case "THETA_PATH": o = mForm.S.THETA_PATH; break;

                case "V" : o = mForm.S.V; break;
                case "ALPHA": o = mForm.S.ALPHA; break;
                case "BETA": o = mForm.S.BETA; break;

                case "Fx1" : o = mForm.F.x1; break;
                case "Fy1" : o = mForm.F.y1; break;
                case "Fz1" : o = mForm.F.z1; break;

                case "Cx" : o = mForm.C.x; break;
                case "Cy" : o = mForm.C.y; break;
                case "Cz" : o = mForm.C.z; break;

                case "Fx2" : o = mForm.F.x2; break;
                case "Fy2" : o = mForm.F.y2; break;
                case "Fz2" : o = mForm.F.z2; break;

                case "Fx3" : o = mForm.F.x3; break;
                case "Fy3" : o = mForm.F.y3; break;
                case "Fz3" : o = mForm.F.z3; break;

                case "Mx1" : o = mForm.M.x1; break;
                case "My1" : o = mForm.M.y1; break;
                case "Mz1" : o = mForm.M.z1; break;

                case "Nx" : o = mForm.N.x; break;
                case "Ny" : o = mForm.N.y; break;
                case "Nz" : o = mForm.N.z; break;

                case "Mx3" : o = mForm.M.x3; break;
                case "My3" : o = mForm.M.y3; break;
                case "Mz3" : o = mForm.M.z3; break;

                case "del_e": o = mForm.del.e; break;
                case "del_e_rv": o = mForm.del.e_rv; break;
                case "del_n": o = mForm.del.n; break;
                case "Tr" : o = mForm.del.Tr; break;

                case "dVx" : o = mForm.d.Vx; break;
                case "dVy" : o = mForm.d.Vy; break;
                case "dVz" : o = mForm.d.Vz; break;

                case "dWx" : o = mForm.d.Wx; break;
                case "dWy" : o = mForm.d.Wy; break;
                case "dWz" : o = mForm.d.Wz; break;

                case "dXg" : o = mForm.d.Xg; break;
                case "dYg" : o = mForm.d.Yg; break;
                case "dZg" : o = mForm.d.Zg; break;

                case "dGAMA": o = mForm.d.GAMA; break;
                case "dPSI": o = mForm.d.PSI; break;
                case "dTHETA": o = mForm.d.THETA; break;
                case "dTHETA_PATH": o = mForm.d.THETA_PATH; break;

                case "dV": o = mForm.d.V; break;
                case "dALPHA": o = mForm.d.ALPHA; break;
                case "dBETA": o = mForm.d.BETA; break;
            }

            return o;       
        }

        /// <summary>
        /// Create columns in data grid for all checked items in FlyParam checkedListBox
        /// </summary>
        public void InitDataGrid()
        {
            if (mForm.fpForm != null)
            {
                this.dataGridView1.Columns.Clear();

                foreach (string checkedItemString in mForm.fpForm.checkedListBox1.CheckedItems)
                {
                    this.dataGridView1.Columns.Add(checkedItemString, checkedItemString);
                }
            }
        
        }

        private void DataGridForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mForm.toolStripButton3_DataGrid.Checked = false;
        }

    }
}
