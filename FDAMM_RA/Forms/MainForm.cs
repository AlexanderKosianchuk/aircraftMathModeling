using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using ZedGraph;
using WeifenLuo.WinFormsUI.Docking;

using Resources;
using MathPlaneModel;
using PlaneVisualisation;

namespace FDAMM_RA
{
    public partial class MainForm : Form
    {
        #region Global param init

        public DifferentialMeanings d;
        public IntegralMeanings S;
        public Forses F;
        public Moments M;
        public Coefficient C;
        public LinearizedCoefficient c;
        public Overload N;
        public Controls del;
        public Statics s;
        public double t = 0;

        Modeling modeling = new Modeling();
        Integrating integ = new Integrating();

        GlobalServParam p = new GlobalServParam();

        static int modelDimention = 10;
        //static int modelDimention = 23;

        //Контейнеры диф и инт значений для передачи на интегрирование
        Double[] X = new Double[modelDimention];
        Double[] X0 = new Double[modelDimention];
        Double[] Y = new Double[modelDimention];

        public FlyParamForm fpForm;
        GraphicsListForm glForm;
        public DataGridForm dgForm;
        public AviatingForm avForm;
        public PlaneVisualisationForm pvForm;
        StaticsForm stForm;

        AutopilotForm auForm;
        ScriptingAutopilotForm scrForm;

        HardwareDeviceAttachingForm haForm;

        Object oDataGridCellValue;

        //using acceleration
        String acceleration;

        #endregion

        public MainForm()
        {
            InitializeComponent();   

            //SetInitialConditions();
            this.toolStripComboBox1_Design.SelectedItem = "Aviating";
            this.toolStripComboBox_Acceleration.SelectedItem = "No acceleration";
            this.toolStripComboBox1_IntegMeth.SelectedItem = "Runge Kutti with corr";
            this.toolStripLabel_HardwareConnection.Image = BitmapResources.NotConnected;
        }

        #region Set initials

        /// <summary>
        /// Set initial conditions
        /// </summary>
        public void SetInitialConditions()
        {
            d = new DifferentialMeanings();
            S = new IntegralMeanings();
            F = new Forses();
            M = new Moments();
            C = new Coefficient();
            c = new LinearizedCoefficient();
            N = new Overload();
            del = new Controls();
            s = new Statics();

            acceleration = this.toolStripComboBox_Acceleration.Text;

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

            if (haForm == null)
            { haForm = new HardwareDeviceAttachingForm(this); }
            else if (scrForm != null)
            {
                haForm.Close();
                haForm = new HardwareDeviceAttachingForm(this);
            }

        }

        /// <summary>
        /// Set initial values
        /// </summary>
        public void SetInitialValues()
        {

            d.Clear();
            S.Clear();
            F.Clear();
            M.Clear();
            C.Clear();
            N.Clear();
            del.Clear();
            C.Clear();

            //Обнуляем массивы интегрирования
            for (int j = 0; j < modelDimention; j++)
            {
                X[j] = 0;
                X0[j] = 0;
                Y[j] = 0;
            }

            modeling.bal(S, C, del, s);
            modeling.setRealParamValuesFromIncrements(S, d, del);
            modeling.calcLinearCoef(S, del, c, s);

        }

        #endregion

        /// <summary>
        /// Processing step
        /// </summary>
        private void sim(ref double t, double dt)
        {
            //if(S.Vx < s.VtakeOff)
            //{
            //    Y = modeling.GetIntegratedValues(S, modelDimention);
            //    modeling.takeOff(d, S, F, M, del, s);
            //    X = modeling.GetDiffValues(d, modelDimention);
            //    X0 = integ.RungeKytt_withCor_step1(modelDimention, dt, X0, Y);
            //    integ.RungeKytt_withCor_step1(modelDimention, dt, X0, Y);
            //    modeling.ReturnIntegratedValues(S, Y);
                
            //    Y = modeling.GetIntegratedValues(S, modelDimention);
            //    modeling.takeOff(d, S, F, M, del, s);
            //    X = modeling.GetDiffValues(d, modelDimention);
            //    integ.RungeKytt_withCor_step2(modelDimention, dt, X, Y, X0);
            //    modeling.ReturnIntegratedValues(S, Y);
            //}

            if (this.toolStripComboBox1_IntegMeth.Text == "Runge Kutti with corr")
            {
                Y = modeling.getIntegratedValuesIncrements(S, modelDimention);
                modeling.dynLinear(d, S, c, del, s);
                X = modeling.getDiffValuesIncrements(d, modelDimention);
                X0 = integ.rungeKytti_withCor_step1(modelDimention, dt, X0, Y);
                integ.rungeKytti_withCor_step1(modelDimention, dt, X0, Y);
                modeling.returnIntegratedValuesIncrements(S, Y);

                Y = modeling.getIntegratedValuesIncrements(S, modelDimention);
                modeling.dynLinear(d, S, c, del, s);
                X = modeling.getDiffValuesIncrements(d, modelDimention);
                integ.rungeKytti_withCor_step2(modelDimention, dt, X, Y, X0);
                modeling.returnIntegratedValuesIncrements(S, Y);
                modeling.setRealParamValuesFromIncrements(S, d, del);
            }
            else if (this.toolStripComboBox1_IntegMeth.Text == "Runge Kutti")
            {
                Y = modeling.getIntegratedValuesIncrements(S, modelDimention);
                modeling.dynLinear(d, S, c, del, s);
                X = modeling.getDiffValuesIncrements(d, modelDimention);
                X0 = integ.rungeKytti_step1(modelDimention, dt, X, Y, X0);
                integ.rungeKytti_step1(modelDimention, dt, X, Y, X0);
                modeling.returnIntegratedValuesIncrements(S, Y);

                Y = modeling.getIntegratedValuesIncrements(S, modelDimention);
                modeling.dynLinear(d, S, c, del, s);
                X = modeling.getDiffValuesIncrements(d, modelDimention);
                integ.rungeKytti_step2(modelDimention, dt, X, Y, X0);
                modeling.returnIntegratedValuesIncrements(S, Y);
                modeling.setRealParamValuesFromIncrements(S, d, del);
            }
            else
            {
                Y = modeling.getIntegratedValuesIncrements(S, modelDimention);
                modeling.dynLinear(d, S, c, del, s);
                X = modeling.getDiffValuesIncrements(d, modelDimention);
                integ.eiler(modelDimention, dt, X, Y);
                modeling.returnIntegratedValuesIncrements(S, Y);
                modeling.setRealParamValuesFromIncrements(S, d, del);
            }

            dataGridFill();
            initilizeGrapg();

            t += s.dt;
        }


        Int32 dataForTranscendingViaUsb;

        UInt32 numBytesWritten;
        UInt32 numBytesAvailable;
        UInt32 numBytesRead;

        byte[] bytesToWrite;
        byte[] bytesToRead;
        byte[] paramByteArray = new byte[24];
        byte[] doubleByteArray = new byte[4];
        byte[] singleAlignByte = new byte[1];
        double TEMP_PARAM_VALUE;

        private void hardWareAcceleration(ref double t)
        {

            dataForTranscendingViaUsb = Convert.ToInt32(this.del.e_rv_DEL * 1000);
            bytesToWrite = BitConverter.GetBytes(dataForTranscendingViaUsb);
            numBytesWritten = 0;
            haForm.ftStatus = haForm.ftdiDevice.Write(bytesToWrite, bytesToWrite.Length, ref numBytesWritten);
            if (haForm.ftStatus != haForm.STATUS_OK)
            {
                //
            }

            numBytesAvailable = 0;
            do
            {
                haForm.ftStatus = haForm.ftdiDevice.GetRxBytesAvailable(ref numBytesAvailable);
                if (haForm.ftStatus != haForm.STATUS_OK)
                {
                    this.toolStripComboBox_Acceleration.SelectedItem = "No acceleration";
                    MessageBox.Show("Failed to get number of bytes available to read (error " + haForm.ftStatus.ToString() + ")");
                    haForm.ftdiDevice.Close();
                }
                Thread.Sleep(10);
            }
            while (numBytesAvailable < bytesToWrite.Length);

            numBytesRead = 0;
            bytesToRead = new byte[numBytesAvailable];
            // Note that the Read method is overloaded, so can read string or byte array data
            haForm.ftStatus = haForm.ftdiDevice.Read(bytesToRead, numBytesAvailable, ref numBytesRead);
            if (haForm.ftStatus != haForm.STATUS_OK)
            {
                toolStripComboBox_Acceleration.SelectedItem = "No acceleration";
                MessageBox.Show("Failed to read data (error " + haForm.ftStatus.ToString() + ")");
                haForm.ftdiDevice.Close();
            }
            else
            {

                if (bytesToRead.Length == 25)
                {
                    byte[] alignByte = { 195 };
                    Array.Copy(bytesToRead, 0, singleAlignByte, 0, 1);
                    if (singleAlignByte[0] == alignByte[0])
                    {
                        Array.Copy(bytesToRead, 1, paramByteArray, 0, 24);
                        readingParamsFromHardwareAccelerator();
                        modeling.setRealParamValuesFromIncrements(S, d, del);

                        dataGridFill();
                        initilizeGrapg();

                        t += s.dt;
                    }
                    else
                    {
                        //no align byte
                    }


                }
                else if ((bytesToRead.Length > 24) && (bytesToRead.Length < 35))
                {
                    int i = 0;
                    byte[] alignByte = { 195 };
                    bool alignByteFound = false;
                    bool noAlignByteInArray = false;
                    while (!alignByteFound)
                    {
                        Array.Copy(bytesToRead, i, singleAlignByte, 0, 1);
                        Array.Copy(bytesToRead, i + 1, paramByteArray, 0, 24);
                        if (singleAlignByte[0] == alignByte[0])
                        {
                            alignByteFound = true;
                        }
                        else
                        {
                            if (i > 11)
                            {
                                alignByteFound = true;
                                noAlignByteInArray = true;
                            }
                            else
                            {
                                i++;
                                alignByteFound = false;
                            }
                        }

                    }

                    if (!noAlignByteInArray)
                    {
                        readingParamsFromHardwareAccelerator();
                        modeling.setRealParamValuesFromIncrements(S, d, del);

                        dataGridFill();
                        initilizeGrapg();

                        t += s.dt;
                    }
                    else
                    {
                        //no align byte in array
                    }
                }
                else if ((bytesToRead.Length > 0) && (bytesToRead.Length < 5))
                { 
                    //may be del_rv transfer err                
                }
                else
                {
                    //if less 21 or more 31 - transfer err, leave previous values
                }

            }
        }

        void readingParamsFromHardwareAccelerator()
        {

            Array.Copy(paramByteArray, 0, doubleByteArray, 0, 4);
            TEMP_PARAM_VALUE = Convert.ToDouble(BitConverter.ToInt32(doubleByteArray, 0)) / 1000;
            if (TEMP_PARAM_VALUE > (S.THETA_DEL + 5) || TEMP_PARAM_VALUE < (S.THETA_DEL - 5))
            {
                //calculation or transfer err leave previous value            
            }
            else
            {
                S.THETA_DEL = TEMP_PARAM_VALUE;
            }

            Array.Copy(paramByteArray, 4, doubleByteArray, 0, 4);
            TEMP_PARAM_VALUE = Convert.ToDouble(BitConverter.ToInt32(doubleByteArray, 0)) / 1000;
            if (TEMP_PARAM_VALUE > (S.Wz_DEL + 5) || TEMP_PARAM_VALUE < (S.Wz_DEL - 5))
            {
                //calculation or transfer err leave previous value            
            }
            else
            {
                S.Wz_DEL = TEMP_PARAM_VALUE;
            }

            Array.Copy(paramByteArray, 8, doubleByteArray, 0, 4);
            TEMP_PARAM_VALUE = Convert.ToDouble(BitConverter.ToInt32(doubleByteArray, 0)) / 1000;
            if (TEMP_PARAM_VALUE > (S.THETA_PATH_DEL + 5) || TEMP_PARAM_VALUE < (S.THETA_PATH_DEL - 5))
            {
                //calculation or transfer err leave previous value            
            }
            else
            {
                S.THETA_PATH_DEL = TEMP_PARAM_VALUE;
            }

            Array.Copy(paramByteArray, 12, doubleByteArray, 0, 4);
            TEMP_PARAM_VALUE = Convert.ToDouble(BitConverter.ToInt32(doubleByteArray, 0)) / 1000;
            if (TEMP_PARAM_VALUE > (S.ALPHA_DEL + 5) || TEMP_PARAM_VALUE < (S.ALPHA_DEL - 5))
            {
                //calculation or transfer err leave previous value            
            }
            else
            {
                S.ALPHA_DEL = TEMP_PARAM_VALUE;
            }

            Array.Copy(paramByteArray, 16, doubleByteArray, 0, 4);
            TEMP_PARAM_VALUE = Convert.ToDouble(BitConverter.ToInt32(doubleByteArray, 0)) / 1000;
            if (TEMP_PARAM_VALUE > (S.Yg_DEL + 100) || TEMP_PARAM_VALUE < (S.Yg_DEL - 100))
            {
                //calculation or transfer err leave previous value            
            }
            else
            {
                S.Yg_DEL = TEMP_PARAM_VALUE;
            }

            Array.Copy(paramByteArray, 20, doubleByteArray, 0, 4);
            TEMP_PARAM_VALUE = Convert.ToDouble(BitConverter.ToInt32(doubleByteArray, 0)) / 1000;
            if (TEMP_PARAM_VALUE > (d.Wz_DEL + 10) || TEMP_PARAM_VALUE < (d.Wz_DEL - 10))
            {
                //calculation or transfer err leave previous value            
            }
            else
            {
                d.Wz_DEL = TEMP_PARAM_VALUE;
            }
            
           
        }

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

            if (this.toolStripComboBox_Acceleration.Text == "No acceleration")
            { sim(ref t, s.dt); }
            else
            { hardWareAcceleration(ref t); }

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
                if (this.toolStripComboBox_Acceleration.Text == "No acceleration")
                {
                    //запустить симуляцию
                    stepTimer.Enabled = true;
                    if (fpForm != null)
                    {
                        fpForm.Enabled = false;
                    }
                    toolStripButton1_StartSim.Text = "Stop";
                    toolStripButton1_StartSim.Image = BitmapResources.Pause;
                }
                else if (this.toolStripComboBox_Acceleration.Text == "Hardware acceleration")
                {
                    if (toolStripTextBox_IterationNum.Text == ""
                        || toolStripTextBox_IterationNum.Text == "0"
                        || toolStripTextBox_IterationNum.Text == " ")
                    {
                        //запустить симуляцию
                        stepTimer.Enabled = true;
                        if (fpForm != null)
                        {
                            fpForm.Enabled = false;
                        }
                        toolStripButton1_StartSim.Text = "Stop";
                        toolStripButton1_StartSim.Image = BitmapResources.Pause;
                    }
                    else
                    {
                        toolStripButton1_StartSim.Text = "Stop";
                        toolStripButton1_StartSim.Image = BitmapResources.Pause;
                        for (int i = 0; i < Convert.ToInt32(toolStripTextBox_IterationNum.Text); i++)
                        {
                            if (avForm != null)
                            { avForm.GetControlValues(del); }

                            if (stForm != null)
                            { s = stForm.GetStaticsValues(); }

                            hardWareAcceleration(ref t);
                        }
                        toolStripButton1_StartSim.Text = "StartSim";
                        toolStripButton1_StartSim.Image = BitmapResources.Play;
                    }
                    clicked = !clicked;
                }

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

        private void toolStripComboBox_Acceleration_SelectedIndexChanged(object sender, EventArgs e)
        {
            acceleration = toolStripComboBox_Acceleration.Text;
            if (toolStripComboBox_Acceleration.Text == "Hardware acceleration")
            {
                this.toolStripLabel_HardwareConnection.Image = BitmapResources.Connect;
                this.toolStripComboBox1_IntegMeth.Enabled = false;
                haForm.ShowDialog();                
            }
            else
            {
                this.toolStripLabel_HardwareConnection.Image = BitmapResources.NotConnected;
                this.toolStripComboBox1_IntegMeth.Enabled = true;
            }

        }

        #endregion



    }
}


       