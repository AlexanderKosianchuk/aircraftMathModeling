using System;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Resources;
using PlaneVisualisation;
using MathPlaneModel;

namespace FDAMM_RA
{
    public partial class MainForm : Form
    {
        #region Global param init

        public double t = 0;

        GlobalServParamSingleton p = GlobalServParamSingleton.Instance;
        IAircraftModel model = ModelCreator.GetAircraftModel();

        public FlyParamForm fpForm;
        GraphicsListForm glForm;
        public DataGridForm dgForm;
        public AviatingForm avForm;
        public PlaneVisualisationForm pvForm;
        StaticsForm stForm;

        AutopilotForm auForm;
        ScriptingAutopilotForm scrForm;

        Object oDataGridCellValue;

        #endregion

        public MainForm()
        {
            InitializeComponent();   
        }

        #region Set initials

        /// <summary>
        /// Set initial conditions
        /// </summary>
        public void SetInitialConditions()
        {
            SetInitialValues();

            if (stForm == null)
            { stForm = new StaticsForm(this, s); }
            else if (stForm != null)
            {
                stForm.Close();
                stForm = new StaticsForm(this, s);
            }

            if (fpForm == null)
            { fpForm = new FlyParamForm(this); }
            else if (fpForm != null)
            {
                fpForm.Close();
                fpForm = new FlyParamForm(this);
            }

            if (glForm == null)
            { glForm = new GraphicsListForm(this); }
            else if (glForm != null)
            {
                glForm.Close();
                glForm = new GraphicsListForm(this);
            }

            if (dgForm == null)
            { dgForm = new DataGridForm(this); }
            else if (dgForm != null)
            {
                dgForm.Close();
                dgForm = new DataGridForm(this);
            }

            if (avForm == null)
            { avForm = new AviatingForm(this); }
            else if (avForm != null)
            {
                avForm.Close();
                avForm = new AviatingForm(this);
            }

            if (pvForm == null)
            { pvForm = new PlaneVisualisationForm(this.toolStripButton6_Visualisation, S); }
            else if (pvForm != null)
            {
                pvForm.Close();
                pvForm = new PlaneVisualisationForm(this.toolStripButton6_Visualisation, S);
            }

            if (auForm == null)
            { auForm = new AutopilotForm(this); }
            else if (auForm != null)
            {
                auForm.Close();
                auForm = new AutopilotForm(this);
            }

            if (scrForm == null)
            { scrForm = new ScriptingAutopilotForm(this); }
            else if (scrForm != null)
            {
                scrForm.Close();
                scrForm = new ScriptingAutopilotForm(this);
            }
        }

        #endregion

        private void maneuring()
        {
                if (auForm.maneur == "change height by kH*delH + kdH*dH")
                {
                    avForm.trackBar3.Enabled = false;
                    avForm.textBox3.Enabled = false;

                    if (del.e_rv_BAL + (auForm.kH * (S.Yg - auForm.tH) + auForm.kdH * d.Yg) <= (s.del_e_rvMIN))
                    {
                        //to prevent out of range on the next iteration
                        if (del.e_rv <= (s.del_e_rvMIN))
                        {
                            del.e_rv_DEL = s.del_e_rvMIN + del.e_rv_BAL;
                        }
                        else
                        {
                            del.e_rv_DEL -= s.del_e_rvSTEP;
                        }
                    }
                    else if (del.e_rv_BAL + (auForm.kH * (S.Yg - auForm.tH) + auForm.kdH * d.Yg) >= (s.del_e_rvMAX))
                    {
                        if (del.e_rv >= (s.del_e_rvMAX))
                        {
                            del.e_rv_DEL = s.del_e_rvMAX - del.e_rv_BAL;
                        }
                        else
                        {
                            del.e_rv_DEL += s.del_e_rvSTEP;
                        };
                    }
                    else
                    {
                        if (auForm.kH * (S.Yg - auForm.tH) + auForm.kdH * d.Yg > del.e_rv_BAL)
                        { del.e_rv_DEL = auForm.kH * (S.Yg - auForm.tH) + auForm.kdH * d.Yg - del.e_rv_BAL; }
                        else
                        {
                            if (auForm.kH * (S.Yg - auForm.tH) + auForm.kdH * d.Yg > 0)
                            { del.e_rv_DEL = del.e_rv_BAL - auForm.kH * (S.Yg - auForm.tH) + auForm.kdH * d.Yg; }
                            else { del.e_rv_DEL = auForm.kH * (S.Yg - auForm.tH) + auForm.kdH * d.Yg - del.e_rv_BAL; }
                        }
                    }

                    avForm.textBox3.Text = Convert.ToString(del.e_rv);

                }
        }


        private void stepTimer_Tick(object sender, EventArgs e)
        {
            if (avForm != null)
            { avForm.GetControlValues(del); }

            if (stForm != null)
            { s = stForm.GetStaticsValues(); }

            sim(ref t, s.dt);

            dataGridFill();
            initilizeGrapg();

            t += s.dt;

            if (auForm.executeChangeHeightDuringSim.Checked)
            { maneuring(); }
        }



        /// <summary>
        /// Dynamic DataGrid Value Filling during simulation
        /// </summary>
        void dataGridFill()
        {
            if (dgForm != null)
            {

                dgForm.dataGridView1.Rows.Add();

                foreach (DataGridViewTextBoxColumn dataGridColumn in dgForm.dataGridView1.Columns)
                {
                    if (dataGridColumn.HeaderText == "t")
                    {
                        dgForm.dataGridView1[dataGridColumn.HeaderText, p.rowNum].Value = Math.Round(t, 4);
                    }
                    else
                    {
                        oDataGridCellValue = dgForm.InitDataObject(dataGridColumn.HeaderText);
                        dgForm.dataGridView1[dataGridColumn.HeaderText, p.rowNum].Value = oDataGridCellValue;
                    }
                }

                if (p.rowNum > p.RowMaxCount)
                {
                    dgForm.dataGridView1.Rows.RemoveAt(0);
                }
                else if (p.rowNum <= p.RowMaxCount)
                {
                    p.rowNum++;
                }
            }

        }

        double XAxisValue;
        double YAxisValue;
        /// <summary>
        /// Draw graphics
        /// </summary>
        private void initilizeGrapg()
        {

            foreach (GraphicsForm gForm in glForm.listGraphicsForm)
            {
                Object oXAxisValue = dgForm.InitDataObject(gForm.pane.XAxis.Title.Text);
                Object oYAxisValue = dgForm.InitDataObject(gForm.pane.YAxis.Title.Text);
                XAxisValue = (double)oXAxisValue;
                YAxisValue = (double)oYAxisValue;
                gForm.DrawChart(XAxisValue, YAxisValue);
            }
        }

        #region ToolStrip buttom click event processors

        private void toolStripButton1_Statics_Click(object sender, EventArgs e)
        {
            if (toolStripButton1_Statics.Checked)
            {
                stForm.Hide();
            }
            else
            {
                stForm.Show(this.dockPanel1);
            }

            toolStripButton1_Statics.Checked = !toolStripButton1_Statics.Checked;

        }

        private void toolStripButton2_FlyParam_Click(object sender, EventArgs e)
        {
            if (toolStripButton2_FlyParam.Checked)
            {
                fpForm.Hide();
            }
            else
            {
                fpForm.Show(this.dockPanel1);
            }

            toolStripButton2_FlyParam.Checked = !toolStripButton2_FlyParam.Checked;
        }

        private void toolStripButton3_DataGrid_Click(object sender, EventArgs e)
        {
            if (toolStripButton3_DataGrid.Checked)
            {
                dgForm.Hide();
            }
            else
            {
                dgForm.Show(this.dockPanel1);
            }

            toolStripButton3_DataGrid.Checked = !toolStripButton3_DataGrid.Checked;
        }

        private void toolStripButton4_Graphics_Click(object sender, EventArgs e)
        {
            if (toolStripButton4_Graphics.Checked)
            {
                glForm.Hide();
            }
            else
            {
                glForm.Show(this.dockPanel1);
            }

            toolStripButton4_Graphics.Checked = !toolStripButton4_Graphics.Checked;

        }


        private void toolStripButton5_Aviating_Click(object sender, EventArgs e)
        {
            if (toolStripButton5_Aviating.Checked)
            {
                avForm.Hide();
            }
            else
            {
                avForm.Show(this.dockPanel1);
            }

            toolStripButton5_Aviating.Checked = !toolStripButton5_Aviating.Checked;

        }

        private void toolStripButton6_Visualisation_Click(object sender, EventArgs e)
        {
            if (toolStripButton6_Visualisation.Checked)
            {
                pvForm.Hide();
            }
            else
            {
                pvForm.Show(this.dockPanel1, DockState.Document);
            }

            toolStripButton6_Visualisation.Checked = !toolStripButton6_Visualisation.Checked;

        }

        public bool clicked = false; //если кнопка "Start" не нажата
        public void toolStripButton1_StartSim_Click(object sender, EventArgs e)
        {
            if (clicked == false)
            {
                //запустить симуляцию
                stepTimer.Enabled = true;
                if (fpForm != null)
                {
                    fpForm.Enabled = false;
                }
                toolStripButton1_StartSim.Text = "Stop";
                toolStripButton1_StartSim.Image = BitmapResources.Pause;
                clicked = !clicked;
            }
            else if (clicked == true)
            {
                //остановить симуляцию
                stepTimer.Enabled = false;
                toolStripButton1_StartSim.Text = "StartSim";
                toolStripButton1_StartSim.Image = BitmapResources.Play;
            }

            clicked = !clicked;
        }

        private void toolStripButton2_Reset_Click(object sender, EventArgs e)
        {
            stepTimer.Enabled = false;

            if (fpForm != null)
            {
                fpForm.Enabled = true;
            }
            toolStripButton1_StartSim.Text = "StartSim";
            toolStripButton1_StartSim.Image = BitmapResources.Play;
            clicked = !clicked;
            
            t = 0;
            p.rowNum = 0;

            foreach (GraphicsForm gForm in glForm.listGraphicsForm)
            {
                gForm.Close();
            }

            SetInitialConditions();

            toolStripComboBox1_Design_SelectedIndexChanged(sender, e);

        }

        private void toolStripButton1_Autopilot_Click(object sender, EventArgs e)
        {
            if (toolStripButton7_Autopilot.Checked)
            {
                auForm.Hide();
            }
            else
            {
                auForm.Show(this.dockPanel1);
            }

            toolStripButton7_Autopilot.Checked = !toolStripButton7_Autopilot.Checked;

        }

        private void toolStripButton2_ScriptingAutopilot_Click(object sender, EventArgs e)
        {
            if (toolStripButton8_ScriptingAutopilot.Checked)
            {
                scrForm.Hide();
            }
            else
            {
                scrForm.Show(this.dockPanel1);
            }

            toolStripButton8_ScriptingAutopilot.Checked = !toolStripButton8_ScriptingAutopilot.Checked;

        }

        private void toolStripButton1_FullSceen_Click(object sender, EventArgs e)
        {
            if (toolStripButton1_FullSceen.Checked)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }

            toolStripButton1_FullSceen.Checked = !toolStripButton1_FullSceen.Checked;
        }

        private void toolStripComboBox1_Design_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.toolStripComboBox1_Design.SelectedItem.ToString())
            {
                case "Clear":
                    SetInitialConditions();
                    pvForm.Show(this.dockPanel1, DockState.Document);
                    toolStripButton6_Visualisation.Checked = true;
                    break;

                case "Aviating":
                    SetInitialConditions();
                    pvForm.Show(this.dockPanel1, DockState.Document);
                    toolStripButton6_Visualisation.Checked = true;
                    avForm.Show(this.dockPanel1);
                    this.toolStripButton5_Aviating.Checked = true;
                    break;

                case "Autopilot":
                    SetInitialConditions();
                    pvForm.Show(this.dockPanel1, DockState.Document);
                    toolStripButton6_Visualisation.Checked = true;
                    scrForm.Show(this.dockPanel1, DockState.DockBottomAutoHide);
                    auForm.Show(this.dockPanel1, DockState.DockLeft);
                    avForm.Show(this.dockPanel1);
                    this.toolStripButton8_ScriptingAutopilot.Checked = true;
                    this.toolStripButton7_Autopilot.Checked = true;
                    this.toolStripButton5_Aviating.Checked = true;
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                    toolStripButton1_FullSceen.Checked = true;
                    break;

                case "StaticsDebug":
                    SetInitialConditions();
                    pvForm.Show(this.dockPanel1, DockState.Document);
                    toolStripButton6_Visualisation.Checked = true;
                    stForm.Show(this.dockPanel1, DockState.DockLeft);
                    avForm.Show(this.dockPanel1);
                    this.toolStripButton1_Statics.Checked = true;
                    this.toolStripButton5_Aviating.Checked = true;
                    break;

                case "":
                    break;
            }
        }

        #endregion
    }
}


       