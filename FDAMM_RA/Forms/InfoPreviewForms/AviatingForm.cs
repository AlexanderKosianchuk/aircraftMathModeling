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
    public partial class AviatingForm : DockContent
    {
        internal MainForm mForm;

        public AviatingForm(MainForm mainForm)
        {
            mForm = mainForm;
            InitializeComponent();

            SetInitialTrackBarsControls();
        }

        /// <summary>
        /// Задаем начальные значения контролам управления
        /// </summary>
        public void SetInitialTrackBarsControls()
        {

            //del_e
            trackBar1.Minimum = -15000;
            trackBar1.Maximum = 15000;
            trackBar1.TickFrequency = 2000;
            trackBar1.LargeChange = 1000;
            trackBar1.SmallChange = 100;
            trackBar1.Value = Convert.ToInt32(mForm.del.e * 1000);
            textBox1.Text = Convert.ToString(Convert.ToDouble(trackBar1.Value / 1000));

            //del_n
            trackBar2.Minimum = -20000;
            trackBar2.Maximum = 20000;
            trackBar2.TickFrequency = 2000;
            trackBar2.LargeChange = 1000;
            trackBar2.SmallChange = 100;
            trackBar2.Value = Convert.ToInt32(mForm.del.n * 1000);
            textBox2.Text = Convert.ToString(Convert.ToDouble(trackBar2.Value / 1000));

            //del_e_rv
            trackBar3.Minimum = -20000;
            trackBar3.Maximum = 10000;
            trackBar3.TickFrequency = 2000;
            trackBar3.LargeChange = 1000;
            trackBar3.SmallChange = 100;
            trackBar3.Value = Convert.ToInt32(mForm.del.e_rv * 1000);
            textBox3.Text = Convert.ToString(Convert.ToDouble(trackBar3.Value / 1000));

            //T
            trackBar4.Minimum = 0;
            trackBar4.Maximum = 14000;
            trackBar4.TickFrequency = 2000;
            trackBar4.LargeChange = 1000;
            trackBar4.SmallChange = 100;
            trackBar4.Value = Convert.ToInt32(mForm.del.Tr);
            textBox4.Text = Convert.ToString(Convert.ToDouble(trackBar4.Value));

            SetControlValues(mForm.del);

        }

        //получаем значения элементов управления
        public void GetControlValues(Controls del)
        {
            del.e = Convert.ToDouble(textBox1.Text);
            del.n = Convert.ToDouble(textBox2.Text);
            del.e_rv = Convert.ToDouble(textBox3.Text);
            del.Tr = Convert.ToDouble(textBox4.Text);

            if (Convert.ToDouble(textBox1.Text) > Math.Round(del.e_BAL, 4))
            { del.e_DEL = Convert.ToDouble(textBox1.Text) - Math.Round(del.e_BAL, 4); }
            else
            {
                if (Convert.ToDouble(textBox1.Text) > 0)
                { del.e_DEL = Math.Round(del.e_BAL, 4) - Convert.ToDouble(textBox1.Text); }
                else { del.e_DEL = Convert.ToDouble(textBox1.Text) - Math.Round(del.e_BAL, 4); }
            }

            if (Convert.ToDouble(textBox2.Text) > Math.Round(del.n_BAL, 4))
            { del.n_DEL = Convert.ToDouble(textBox2.Text) - Math.Round(del.n_BAL, 4); }
            else
            {
                if (Convert.ToDouble(textBox2.Text) > 0)
                { del.n_DEL = Math.Round(del.n_BAL, 4) - Convert.ToDouble(textBox2.Text); }
                else { del.n_DEL = Convert.ToDouble(textBox2.Text) - Math.Round(del.n_BAL, 4); }
            }
            
            if (Convert.ToDouble(textBox3.Text) > Math.Round(del.e_rv_BAL, 4))
            { del.e_rv_DEL = Convert.ToDouble(textBox3.Text) - Math.Round(del.e_rv_BAL, 4); }
            else
            {
                if (Convert.ToDouble(textBox3.Text) > 0)
                { del.e_rv_DEL = Math.Round(del.e_rv_BAL, 4) - Convert.ToDouble(textBox3.Text); }
                else { del.e_rv_DEL = Convert.ToDouble(textBox3.Text) - Math.Round(del.e_rv_BAL, 4); }
            }

            if (Convert.ToDouble(textBox4.Text) > Math.Round(del.Tr_BAL, 4))
            { del.Tr_DEL = Convert.ToDouble(textBox4.Text) - Math.Round(del.Tr_BAL, 4); }
            else { del.Tr_DEL = Math.Round(del.Tr_BAL, 4) - Convert.ToDouble(textBox4.Text); }
        }

        public void SetControlValues(Controls del)
        {
            textBox1.Text = Convert.ToString(Math.Round(del.e,4));
            textBox2.Text = Convert.ToString(Math.Round(del.n,4));
            textBox3.Text = Convert.ToString(Math.Round(del.e_rv, 4));
            textBox4.Text = Convert.ToString(del.Tr);      
        }

        #region Обработчики trackBar_Scroll и textBox_TextChanged

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // Display the trackbar value in the text box.
            textBox1.Text = Convert.ToString(Math.Round((Convert.ToDouble(trackBar1.Value) / 1000),4));
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(Math.Round((Convert.ToDouble(trackBar2.Value) / 1000),4));
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(Math.Round((Convert.ToDouble(trackBar3.Value) / 1000),4));
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(Convert.ToDouble(trackBar4.Value));
        }

        /////////////////////////////////////////////////////////////

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //del_e
            trackBar1.Value = (int)Convert.ToDouble(textBox1.Text) * 1000;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //del_n
            trackBar2.Value = (int)Convert.ToDouble(textBox2.Text) * 1000;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //del_e_rv
            trackBar3.Value = (int)Convert.ToDouble(textBox3.Text) * 1000;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //Tr
            trackBar4.Value = (int)Convert.ToDouble(textBox4.Text);
        }

        #endregion

        private void AviatingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mForm.toolStripButton5_Aviating.Checked = false;
        }

    }
}
