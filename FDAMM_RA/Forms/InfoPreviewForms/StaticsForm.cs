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
    public partial class StaticsForm : DockContent
    {
        MainForm mForm;

        Statics initialStatics = new Statics();
        public Statics scoe;

        public StaticsForm(MainForm MainForm, Statics mainFormScoe)
        {
            mForm = MainForm;
            scoe = mainFormScoe;

            InitializeComponent();

            SetInitialValues();

        }

        static int columnNameIndex = 0;
        static int columnValueIndex = 1;

        private void SetInitialValues()
        {

            int rowIndex = 0;

            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "dt";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.dt;
            scoe.g = initialStatics.g;
            rowIndex++;

            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "g";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.g;
            scoe.g = initialStatics.g;
            rowIndex++;

            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "G";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.G;
            scoe.G = initialStatics.G;
            rowIndex++;

            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "m";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.m;
            scoe.m = initialStatics.m;
            rowIndex++;

            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "A";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.A;
            scoe.A = initialStatics.A;
            rowIndex++;

            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "S";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.S;
            scoe.S = initialStatics.S;
            rowIndex++;

            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "L";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.L;
            scoe.L = initialStatics.L;
            rowIndex++;

            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "bA";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.bA;
            scoe.bA = initialStatics.bA;
            rowIndex++;

            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "PO_h";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.PO_h;
            scoe.PO_h = initialStatics.PO_h;
            rowIndex++;

            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "ALPHAt";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.ALPHAt;
            scoe.ALPHAt = initialStatics.ALPHAt;
            rowIndex++;

            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "Cyo";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.Cyo;
            scoe.Cyo = initialStatics.Cyo;
            rowIndex++;

            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "Cxo";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.Cxo;
            scoe.Cxo = initialStatics.Cxo;
            rowIndex++;

            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "Cy_ALPHA";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.Cy_ALPHA;
            scoe.Cy_ALPHA = initialStatics.Cy_ALPHA;
            rowIndex++;

            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "Cz_BETA ";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.Cz_BETA;
            scoe.Cz_BETA = initialStatics.Cz_BETA;
            rowIndex++;

            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "DELTA_Cxa";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.DELTA_Cxa;
            scoe.DELTA_Cxa = initialStatics.DELTA_Cxa;
            rowIndex++;

            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "mzo";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.mzo;
            scoe.mzo = initialStatics.mzo;
            rowIndex++;

            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "mz_ALPHA";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.mz_ALPHA;
            scoe.mz_ALPHA = initialStatics.mz_ALPHA;
            rowIndex++;

            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "mx_BETA";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.mx_BETA;
            scoe.mx_BETA = initialStatics.mx_BETA;
            rowIndex++;

            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "my_BETA";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.my_BETA;
            scoe.my_BETA = initialStatics.my_BETA;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "mx_w1x";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.mx_w1x;
            scoe.mx_w1x = initialStatics.mx_w1x;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "mx_w1y";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.mx_w1y;
            scoe.mx_w1y = initialStatics.mx_w1y;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "my_w1y";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.my_w1y;
            scoe.my_w1y = initialStatics.my_w1y;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "my_w1x";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.my_w1x;
            scoe.my_w1x = initialStatics.my_w1x;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "mz_w1z_plus_mz_ALPHA1";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.mz_w1z_plus_mz_ALPHA1;
            scoe.mz_w1z_plus_mz_ALPHA1 = initialStatics.mz_w1z_plus_mz_ALPHA1;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "mx_del_e";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.mx_del_e;
            scoe.mx_del_e = initialStatics.mx_del_e;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "my_del_e";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.my_del_e;
            scoe.my_del_e = initialStatics.my_del_e;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "mz_del_e_rv";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.mz_del_e_rv;
            scoe.mz_del_e_rv = initialStatics.mz_del_e_rv;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "mx_del_n";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.mx_del_n;
            scoe.mx_del_n = initialStatics.mx_del_n;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "my_del_n";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.my_del_n;
            scoe.my_del_n = initialStatics.my_del_n;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "Ixx";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.Ixx;
            scoe.Ixx = initialStatics.Ixx;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "Iyy";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.Iyy;
            scoe.Iyy = initialStatics.Iyy;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "Izz";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.Izz;
            scoe.Izz = initialStatics.Izz;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "Vo";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.Vo;
            scoe.Vo = initialStatics.Vo;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "Tro";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.Tro;
            scoe.Tro = initialStatics.Tro;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "ALFo ";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.ALPHAo * (180 / Math.PI);
            scoe.ALPHAo = initialStatics.ALPHAo;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "THETAo";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.THETAo * (180 / Math.PI);
            scoe.THETAo = initialStatics.THETAo;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "BETo";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.BETo * (180 / Math.PI);
            scoe.BETo = initialStatics.BETo;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "del_eo";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.del_eo * (180 / Math.PI);
            scoe.del_eo = initialStatics.del_eo;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "del_no";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.del_no * (180 / Math.PI);
            scoe.del_no = initialStatics.del_no;
            rowIndex++;
       
            dataGridView1.Rows.Add();
            dataGridView1[columnNameIndex, rowIndex].Value = "del_e_rvo";
            dataGridView1[columnValueIndex, rowIndex].Value = initialStatics.del_e_rvo * (180 / Math.PI);
            scoe.del_e_rvo = initialStatics.del_e_rvo;
            rowIndex++;
        }

        public Statics GetStaticsValues()
        {
            return scoe;
        }

        private void StaticsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mForm.toolStripButton1_Statics.Checked = false;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            switch (dataGridView1.CurrentCell.RowIndex)
            {
                case (0):
                    {
                        scoe.g = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;
                case(1):
                    {
                        scoe.g = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;
                case (2):
                    {
                        scoe.G = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (3):
                    {
                        scoe.m = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (4):
                    {
                        scoe.A = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (5):
                    {
                        scoe.S = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (6):
                    {
                        scoe.L = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (7):
                    {
                        scoe.bA = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (8):
                    {
                        scoe.PO_h = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (9):
                    {
                        scoe.ALPHAt = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (10):
                    {
                        scoe.Cyo = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (11):
                    {
                        scoe.Cxo = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (12):
                    {
                        scoe.Cy_ALPHA = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (13):
                    {
                        scoe.Cz_BETA = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (14):
                    {
                        scoe.DELTA_Cxa = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (15):
                    {
                        scoe.mzo = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (16):
                    {
                        scoe.mz_ALPHA = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (17):
                    {
                        scoe.mx_BETA = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (18):
                    {
                        scoe.my_BETA = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (19):
                    {
                        scoe.mx_w1x = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (20):
                    {
                        scoe.mx_w1y = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (21):
                    {
                        scoe.my_w1y = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (22):
                    {
                        scoe.my_w1x = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (23):
                    {
                        scoe.mz_w1z_plus_mz_ALPHA1 = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (24):
                    {
                        scoe.mx_del_e = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (25):
                    {
                        scoe.my_del_e = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (26):
                    {
                        scoe.mz_del_e_rv = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (27):
                    {
                        scoe.mx_del_n = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (28):
                    {
                        scoe.my_del_n = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (29):
                    {
                        scoe.Ixx = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (30):
                    {
                        scoe.Iyy = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (31):
                    {
                        scoe.Izz = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (32):
                    {
                        scoe.Vo = Convert.ToDouble(dataGridView1.CurrentCell.Value);
                    }
                    break;

                case (33):
                    {
                        scoe.Tro = Convert.ToDouble(dataGridView1.CurrentCell.Value) * (180 / Math.PI);
                    }
                    break;

                case (34):
                    {
                        scoe.ALPHAo = Convert.ToDouble(dataGridView1.CurrentCell.Value) * (180 / Math.PI);
                    }
                    break;

                case (35):
                    {
                        scoe.THETAo = Convert.ToDouble(dataGridView1.CurrentCell.Value) * (180 / Math.PI);
                    }
                    break;

                case (36):
                    {
                        scoe.BETo = Convert.ToDouble(dataGridView1.CurrentCell.Value) * (180 / Math.PI);
                    }
                    break;

                case (37):
                    {
                        scoe.del_eo = Convert.ToDouble(dataGridView1.CurrentCell.Value) * (180 / Math.PI);
                    }
                    break;

                case (38):
                    {
                        scoe.del_no = Convert.ToDouble(dataGridView1.CurrentCell.Value) * (180 / Math.PI);
                    }
                    break;

                case (39):
                    {
                        scoe.del_e_rvo = Convert.ToDouble(dataGridView1.CurrentCell.Value) * (180 / Math.PI);
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
