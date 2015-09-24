﻿namespace FDAMM_RA
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (stForm != null)
            { stForm.Close(); }
            if (avForm != null)
            { avForm.Close(); }
            if (dgForm != null)
            { dgForm.Close(); }
            if (fpForm != null)
            { fpForm.Close(); }
            if (glForm != null)
            { glForm.Close(); }
            if (pvForm != null)
            { pvForm.Close(); }
            if (scrForm != null)
            { scrForm.Close(); }
            if (auForm != null)
            { auForm.Close(); }
            if (haForm != null)
            { haForm.Close(); }

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin2 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin2 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient4 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient8 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin2 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient9 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient5 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient10 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient11 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient12 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient6 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient13 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient14 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            this.stepTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStripDockForms = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1_Statics = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2_FlyParam = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3_DataGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4_Graphics = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5_Aviating = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6_Visualisation = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1_StartSim = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2_Reset = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolStripAcceleration = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_HardwareConnection = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_IterationNum = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBox_Acceleration = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSimulation = new System.Windows.Forms.ToolStrip();
            this.toolStripAutomation = new System.Windows.Forms.ToolStrip();
            this.toolStripButton7_Autopilot = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8_ScriptingAutopilot = new System.Windows.Forms.ToolStripButton();
            this.toolStripDesign = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1_FullSceen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBox1_Design = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton10_Run = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton11_Stop = new System.Windows.Forms.ToolStripButton();
            this.toolStripIntegMeth = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox1_IntegMeth = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripDockForms.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.toolStripAcceleration.SuspendLayout();
            this.toolStripSimulation.SuspendLayout();
            this.toolStripAutomation.SuspendLayout();
            this.toolStripDesign.SuspendLayout();
            this.toolStripIntegMeth.SuspendLayout();
            this.SuspendLayout();
            // 
            // stepTimer
            // 
            this.stepTimer.Interval = 1;
            this.stepTimer.Tick += new System.EventHandler(this.stepTimer_Tick);
            // 
            // toolStripDockForms
            // 
            this.toolStripDockForms.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripDockForms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1_Statics,
            this.toolStripButton2_FlyParam,
            this.toolStripButton3_DataGrid,
            this.toolStripButton4_Graphics,
            this.toolStripButton5_Aviating,
            this.toolStripSeparator3,
            this.toolStripButton6_Visualisation});
            this.toolStripDockForms.Location = new System.Drawing.Point(3, 25);
            this.toolStripDockForms.Name = "toolStripDockForms";
            this.toolStripDockForms.Size = new System.Drawing.Size(154, 25);
            this.toolStripDockForms.TabIndex = 10;
            this.toolStripDockForms.Text = "toolStripDockForms";
            // 
            // toolStripButton1_Statics
            // 
            this.toolStripButton1_Statics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1_Statics.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1_Statics.Image")));
            this.toolStripButton1_Statics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1_Statics.Name = "toolStripButton1_Statics";
            this.toolStripButton1_Statics.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1_Statics.Text = "Statics";
            this.toolStripButton1_Statics.Click += new System.EventHandler(this.toolStripButton1_Statics_Click);
            // 
            // toolStripButton2_FlyParam
            // 
            this.toolStripButton2_FlyParam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2_FlyParam.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2_FlyParam.Image")));
            this.toolStripButton2_FlyParam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2_FlyParam.Name = "toolStripButton2_FlyParam";
            this.toolStripButton2_FlyParam.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2_FlyParam.Text = "FlyParam";
            this.toolStripButton2_FlyParam.Click += new System.EventHandler(this.toolStripButton2_FlyParam_Click);
            // 
            // toolStripButton3_DataGrid
            // 
            this.toolStripButton3_DataGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3_DataGrid.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3_DataGrid.Image")));
            this.toolStripButton3_DataGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3_DataGrid.Name = "toolStripButton3_DataGrid";
            this.toolStripButton3_DataGrid.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3_DataGrid.Text = "DataGrid";
            this.toolStripButton3_DataGrid.Click += new System.EventHandler(this.toolStripButton3_DataGrid_Click);
            // 
            // toolStripButton4_Graphics
            // 
            this.toolStripButton4_Graphics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4_Graphics.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4_Graphics.Image")));
            this.toolStripButton4_Graphics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4_Graphics.Name = "toolStripButton4_Graphics";
            this.toolStripButton4_Graphics.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4_Graphics.Text = "Graphics";
            this.toolStripButton4_Graphics.Click += new System.EventHandler(this.toolStripButton4_Graphics_Click);
            // 
            // toolStripButton5_Aviating
            // 
            this.toolStripButton5_Aviating.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5_Aviating.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5_Aviating.Image")));
            this.toolStripButton5_Aviating.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5_Aviating.Name = "toolStripButton5_Aviating";
            this.toolStripButton5_Aviating.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5_Aviating.Text = "Aviating";
            this.toolStripButton5_Aviating.Click += new System.EventHandler(this.toolStripButton5_Aviating_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton6_Visualisation
            // 
            this.toolStripButton6_Visualisation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6_Visualisation.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6_Visualisation.Image")));
            this.toolStripButton6_Visualisation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6_Visualisation.Name = "toolStripButton6_Visualisation";
            this.toolStripButton6_Visualisation.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6_Visualisation.Text = "PlaneVisualisation";
            this.toolStripButton6_Visualisation.Click += new System.EventHandler(this.toolStripButton6_Visualisation_Click);
            // 
            // toolStripButton1_StartSim
            // 
            this.toolStripButton1_StartSim.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1_StartSim.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1_StartSim.Image")));
            this.toolStripButton1_StartSim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1_StartSim.Name = "toolStripButton1_StartSim";
            this.toolStripButton1_StartSim.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1_StartSim.Text = "StartSim";
            this.toolStripButton1_StartSim.Click += new System.EventHandler(this.toolStripButton1_StartSim_Click);
            // 
            // toolStripButton2_Reset
            // 
            this.toolStripButton2_Reset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2_Reset.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2_Reset.Image")));
            this.toolStripButton2_Reset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2_Reset.Name = "toolStripButton2_Reset";
            this.toolStripButton2_Reset.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2_Reset.Text = "Reset";
            this.toolStripButton2_Reset.Click += new System.EventHandler(this.toolStripButton2_Reset_Click);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(792, 548);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(792, 573);
            this.toolStripContainer1.TabIndex = 14;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer2
            // 
            this.toolStripContainer2.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.AutoScroll = true;
            this.toolStripContainer2.ContentPanel.Controls.Add(this.dockPanel1);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(792, 523);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.LeftToolStripPanelVisible = false;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.RightToolStripPanelVisible = false;
            this.toolStripContainer2.Size = new System.Drawing.Size(792, 573);
            this.toolStripContainer2.TabIndex = 15;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.toolStripSimulation);
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.toolStripDockForms);
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.toolStripAutomation);
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.toolStripDesign);
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.toolStripAcceleration);
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.toolStripIntegMeth);
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dockPanel1.BackgroundImage")));
            this.dockPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBackColor = System.Drawing.SystemColors.Control;
            this.dockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingSdi;
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(792, 523);
            dockPanelGradient4.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient4.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin2.DockStripGradient = dockPanelGradient4;
            tabGradient8.EndColor = System.Drawing.SystemColors.Control;
            tabGradient8.StartColor = System.Drawing.SystemColors.Control;
            tabGradient8.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin2.TabGradient = tabGradient8;
            dockPanelSkin2.AutoHideStripSkin = autoHideStripSkin2;
            tabGradient9.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient9.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient9.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient2.ActiveTabGradient = tabGradient9;
            dockPanelGradient5.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient5.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient2.DockStripGradient = dockPanelGradient5;
            tabGradient10.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient10.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient10.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient2.InactiveTabGradient = tabGradient10;
            dockPaneStripSkin2.DocumentGradient = dockPaneStripGradient2;
            tabGradient11.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient11.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient11.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient11.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient2.ActiveCaptionGradient = tabGradient11;
            tabGradient12.EndColor = System.Drawing.SystemColors.Control;
            tabGradient12.StartColor = System.Drawing.SystemColors.Control;
            tabGradient12.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient2.ActiveTabGradient = tabGradient12;
            dockPanelGradient6.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient6.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient2.DockStripGradient = dockPanelGradient6;
            tabGradient13.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient13.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient13.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient13.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient2.InactiveCaptionGradient = tabGradient13;
            tabGradient14.EndColor = System.Drawing.Color.Transparent;
            tabGradient14.StartColor = System.Drawing.Color.Transparent;
            tabGradient14.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient2.InactiveTabGradient = tabGradient14;
            dockPaneStripSkin2.ToolWindowGradient = dockPaneStripToolWindowGradient2;
            dockPanelSkin2.DockPaneStripSkin = dockPaneStripSkin2;
            this.dockPanel1.Skin = dockPanelSkin2;
            this.dockPanel1.TabIndex = 0;
            // 
            // toolStripAcceleration
            // 
            this.toolStripAcceleration.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripAcceleration.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_HardwareConnection,
            this.toolStripTextBox_IterationNum,
            this.toolStripSeparator1,
            this.toolStripComboBox_Acceleration});
            this.toolStripAcceleration.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripAcceleration.Location = new System.Drawing.Point(217, 25);
            this.toolStripAcceleration.Name = "toolStripAcceleration";
            this.toolStripAcceleration.Size = new System.Drawing.Size(286, 25);
            this.toolStripAcceleration.TabIndex = 17;
            this.toolStripAcceleration.Text = "toolStripAcceleration";
            // 
            // toolStripLabel_HardwareConnection
            // 
            this.toolStripLabel_HardwareConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel_HardwareConnection.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel_HardwareConnection.Image")));
            this.toolStripLabel_HardwareConnection.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.toolStripLabel_HardwareConnection.Name = "toolStripLabel_HardwareConnection";
            this.toolStripLabel_HardwareConnection.Padding = new System.Windows.Forms.Padding(5, 0, 3, 0);
            this.toolStripLabel_HardwareConnection.Size = new System.Drawing.Size(24, 22);
            this.toolStripLabel_HardwareConnection.Text = "toolStripLabel_HardwareConnection";
            this.toolStripLabel_HardwareConnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripTextBox_IterationNum
            // 
            this.toolStripTextBox_IterationNum.Name = "toolStripTextBox_IterationNum";
            this.toolStripTextBox_IterationNum.Size = new System.Drawing.Size(60, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripComboBox_Acceleration
            // 
            this.toolStripComboBox_Acceleration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox_Acceleration.Items.AddRange(new object[] {
            "No acceleration",
            "Hardware acceleration"});
            this.toolStripComboBox_Acceleration.Name = "toolStripComboBox_Acceleration";
            this.toolStripComboBox_Acceleration.Size = new System.Drawing.Size(180, 25);
            this.toolStripComboBox_Acceleration.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox_Acceleration_SelectedIndexChanged);
            // 
            // toolStripSimulation
            // 
            this.toolStripSimulation.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripSimulation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1_StartSim,
            this.toolStripButton2_Reset});
            this.toolStripSimulation.Location = new System.Drawing.Point(4, 0);
            this.toolStripSimulation.Name = "toolStripSimulation";
            this.toolStripSimulation.Size = new System.Drawing.Size(56, 25);
            this.toolStripSimulation.TabIndex = 0;
            this.toolStripSimulation.Text = "toolStripSimulation";
            // 
            // toolStripAutomation
            // 
            this.toolStripAutomation.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripAutomation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton7_Autopilot,
            this.toolStripButton8_ScriptingAutopilot});
            this.toolStripAutomation.Location = new System.Drawing.Point(157, 25);
            this.toolStripAutomation.Name = "toolStripAutomation";
            this.toolStripAutomation.Size = new System.Drawing.Size(56, 25);
            this.toolStripAutomation.TabIndex = 11;
            // 
            // toolStripButton7_Autopilot
            // 
            this.toolStripButton7_Autopilot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7_Autopilot.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7_Autopilot.Image")));
            this.toolStripButton7_Autopilot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7_Autopilot.Name = "toolStripButton7_Autopilot";
            this.toolStripButton7_Autopilot.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7_Autopilot.Text = "Autopilot";
            this.toolStripButton7_Autopilot.Click += new System.EventHandler(this.toolStripButton1_Autopilot_Click);
            // 
            // toolStripButton8_ScriptingAutopilot
            // 
            this.toolStripButton8_ScriptingAutopilot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8_ScriptingAutopilot.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8_ScriptingAutopilot.Image")));
            this.toolStripButton8_ScriptingAutopilot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8_ScriptingAutopilot.Name = "toolStripButton8_ScriptingAutopilot";
            this.toolStripButton8_ScriptingAutopilot.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8_ScriptingAutopilot.Text = "ScriptingAutopilot";
            this.toolStripButton8_ScriptingAutopilot.Click += new System.EventHandler(this.toolStripButton2_ScriptingAutopilot_Click);
            // 
            // toolStripDesign
            // 
            this.toolStripDesign.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripDesign.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1_FullSceen,
            this.toolStripSeparator2,
            this.toolStripComboBox1_Design});
            this.toolStripDesign.Location = new System.Drawing.Point(300, 0);
            this.toolStripDesign.Name = "toolStripDesign";
            this.toolStripDesign.Size = new System.Drawing.Size(174, 25);
            this.toolStripDesign.TabIndex = 12;
            // 
            // toolStripButton1_FullSceen
            // 
            this.toolStripButton1_FullSceen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1_FullSceen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1_FullSceen.Image")));
            this.toolStripButton1_FullSceen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1_FullSceen.Name = "toolStripButton1_FullSceen";
            this.toolStripButton1_FullSceen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1_FullSceen.Text = "FullSceen";
            this.toolStripButton1_FullSceen.Click += new System.EventHandler(this.toolStripButton1_FullSceen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripComboBox1_Design
            // 
            this.toolStripComboBox1_Design.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1_Design.Items.AddRange(new object[] {
            "Clear",
            "Aviating",
            "Autopilot",
            "StaticsDebug"});
            this.toolStripComboBox1_Design.Name = "toolStripComboBox1_Design";
            this.toolStripComboBox1_Design.Size = new System.Drawing.Size(100, 25);
            this.toolStripComboBox1_Design.ToolTipText = "Design";
            this.toolStripComboBox1_Design.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_Design_SelectedIndexChanged);
            // 
            // toolStripButton10_Run
            // 
            this.toolStripButton10_Run.Name = "toolStripButton10_Run";
            this.toolStripButton10_Run.Size = new System.Drawing.Size(23, 23);
            // 
            // toolStripButton11_Stop
            // 
            this.toolStripButton11_Stop.Name = "toolStripButton11_Stop";
            this.toolStripButton11_Stop.Size = new System.Drawing.Size(23, 23);
            // 
            // toolStripIntegMeth
            // 
            this.toolStripIntegMeth.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripIntegMeth.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBox1_IntegMeth});
            this.toolStripIntegMeth.Location = new System.Drawing.Point(64, 0);
            this.toolStripIntegMeth.Name = "toolStripIntegMeth";
            this.toolStripIntegMeth.Size = new System.Drawing.Size(233, 25);
            this.toolStripIntegMeth.TabIndex = 18;
            // 
            // toolStripComboBox1_IntegMeth
            // 
            this.toolStripComboBox1_IntegMeth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1_IntegMeth.Items.AddRange(new object[] {
            "Eiler",
            "Runge Kutti",
            "Runge Kutti with corr"});
            this.toolStripComboBox1_IntegMeth.Name = "toolStripComboBox1_IntegMeth";
            this.toolStripComboBox1_IntegMeth.Size = new System.Drawing.Size(125, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1_Integrating method";
            this.toolStripLabel1.Size = new System.Drawing.Size(100, 22);
            this.toolStripLabel1.Text = "Integrating method";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.toolStripContainer2);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FDAMM_RA";
            this.toolStripDockForms.ResumeLayout(false);
            this.toolStripDockForms.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.toolStripAcceleration.ResumeLayout(false);
            this.toolStripAcceleration.PerformLayout();
            this.toolStripSimulation.ResumeLayout(false);
            this.toolStripSimulation.PerformLayout();
            this.toolStripAutomation.ResumeLayout(false);
            this.toolStripAutomation.PerformLayout();
            this.toolStripDesign.ResumeLayout(false);
            this.toolStripDesign.PerformLayout();
            this.toolStripIntegMeth.ResumeLayout(false);
            this.toolStripIntegMeth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer stepTimer;
        private System.Windows.Forms.ToolStrip toolStripDockForms;
        public System.Windows.Forms.ToolStripButton toolStripButton2_FlyParam;
        public System.Windows.Forms.ToolStripButton toolStripButton3_DataGrid;
        public System.Windows.Forms.ToolStripButton toolStripButton4_Graphics;
        public System.Windows.Forms.ToolStripButton toolStripButton5_Aviating;
        private System.Windows.Forms.ToolStripButton toolStripButton1_StartSim;
        private System.Windows.Forms.ToolStripButton toolStripButton2_Reset;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        public System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private System.Windows.Forms.ToolStrip toolStripSimulation;
        private System.Windows.Forms.ToolStripButton toolStripButton10_Run;
        private System.Windows.Forms.ToolStripButton toolStripButton11_Stop;
        public WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        public System.Windows.Forms.ToolStripButton toolStripButton6_Visualisation;
        public System.Windows.Forms.ToolStripButton toolStripButton1_Statics;
        private System.Windows.Forms.ToolStrip toolStripAutomation;
        public System.Windows.Forms.ToolStripButton toolStripButton7_Autopilot;
        public System.Windows.Forms.ToolStripButton toolStripButton8_ScriptingAutopilot;
        private System.Windows.Forms.ToolStrip toolStripDesign;
        private System.Windows.Forms.ToolStripButton toolStripButton1_FullSceen;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1_Design;
        private System.Windows.Forms.ToolStrip toolStripAcceleration;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_IterationNum;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripComboBox toolStripComboBox_Acceleration;
        public System.Windows.Forms.ToolStripLabel toolStripLabel_HardwareConnection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        internal System.Windows.Forms.ToolStrip toolStripIntegMeth;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        public System.Windows.Forms.ToolStripComboBox toolStripComboBox1_IntegMeth;


    }
}

