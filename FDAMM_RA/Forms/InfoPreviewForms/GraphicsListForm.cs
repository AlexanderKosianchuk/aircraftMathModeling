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
    public partial class GraphicsListForm : DockContent
    {
        MainForm mForm;
        GraphicsForm graphForm;

        //делегат для анчека галочки в списке при закрытии окна с графиком путем нажатия крестика
        public delegate void DelegateCheckedListBox2SetItemChecked(int index, bool check);

        public GraphicsListForm(MainForm MainForm)
        {
            mForm = MainForm;

            InitializeComponent();

            if (mForm.fpForm == null)
            {
                mForm.fpForm = new FlyParamForm(mForm);
            }

            listGraphicsForm = new List<GraphicsForm>();
            mForm.fpForm.InitCheckedListBoxItems(this.checkedListBox1);

        }

        string sChecketListBoxFirstItemChecked = null;
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sChecketListBoxFirstItemChecked == null)
            {
                sChecketListBoxFirstItemChecked = checkedListBox1.SelectedItem.ToString();
            }
            else if (sChecketListBoxFirstItemChecked.Equals(checkedListBox1.SelectedItem.ToString()))
            {
                sChecketListBoxFirstItemChecked = null;
            }
            else
            {
                checkedListBox2.Items.Add(sChecketListBoxFirstItemChecked + "/"
                    + checkedListBox1.SelectedItem.ToString());
                sChecketListBoxFirstItemChecked = null;

                checkedListBox1.Items.Clear();
                mForm.fpForm.InitCheckedListBoxItems(this.checkedListBox1);

            }

        }

        /// <summary>
        /// List to store created forms with charts
        /// to get posibiliti input points and close them
        /// </summary>
        public List<GraphicsForm> listGraphicsForm;
        //Number of GraphForm exemplar to get it from list
        int iNumInList = 0;
        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //if this graph doesnt exist - create a form with it
            //and add it into the list
            //else close existing form
            if (!checkedListBox2.GetItemChecked(checkedListBox2.SelectedIndex))
            {
                string sGraphicsName = checkedListBox2.Items[checkedListBox2.SelectedIndex].ToString();
                string[] sSplitedGraphicsName = sGraphicsName.Split('/');
                List<string> sAxis = new List<string>();
                foreach (string s in sSplitedGraphicsName)
                {
                    sAxis.Add(s);
                }

                graphForm = new GraphicsForm();
                listGraphicsForm.Add(graphForm);
                graphForm.Tag = iNumInList;
                iNumInList++;
                graphForm.Text = sGraphicsName;
                graphForm.CreateChart(sGraphicsName, sAxis[0], sAxis[1], "", 0, 0);
                graphForm.iNumItemToUncheck = checkedListBox2.SelectedIndex;
                graphForm.SetItemChecked = new DelegateCheckedListBox2SetItemChecked(checkedListBox2.SetItemChecked);
                graphForm.Show(mForm.dockPanel1, DockState.Document);
            }
            else
            {
                foreach (GraphicsForm gForm in listGraphicsForm)
                {
                    if (gForm.iNumItemToUncheck == checkedListBox2.SelectedIndex)
                    {
                        listGraphicsForm[(int)gForm.Tag].Hide();
                    }
                }

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (listGraphicsForm != null)
            {
                int i = 0;
                foreach (GraphicsForm gForm in listGraphicsForm)
                {
                    listGraphicsForm[i].Hide();
                    i++;
                }
            }
            listGraphicsForm.Clear();
            iNumInList = 0;
            checkedListBox2.Items.Clear(); 
        }

        private void GraphicsListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mForm.toolStripButton4_Graphics.Checked = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            foreach (GraphicsForm gForm in listGraphicsForm)
            {
                gForm.chartAutoScaleEna = !gForm.chartAutoScaleEna;
            }

        }



    }
}
