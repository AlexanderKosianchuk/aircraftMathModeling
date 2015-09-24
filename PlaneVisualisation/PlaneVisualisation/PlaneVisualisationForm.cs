using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WeifenLuo.WinFormsUI.Docking;

using MathPlaneModel;

namespace PlaneVisualisation
{
    public partial class PlaneVisualisationForm : DockContent
    {

        ContentBuilder contentBuilder;
        ContentManager contentManager;
        
        ToolStripButton toolStripButtomOnMainForm;

        public PlaneVisualisationForm(ToolStripButton toolStripButton, IntegralMeanings integralMeanings)
        {
            toolStripButtomOnMainForm = toolStripButton;

            InitializeComponent();

            //
            contentBuilder = new ContentBuilder();
            contentManager = new ContentManager(modelViewerControl.Services,
                                                contentBuilder.OutputDirectory);

            modelViewerControl.getIntegralMeaningsRef(integralMeanings);
        }

        /// <summary>
        /// Loads a new 3D model file into the ModelViewerControl.
        /// </summary>
        void LoadModel(string fileName)
        {
            // Unload any existing model.
            modelViewerControl.Model = null;
            contentManager.Unload();

            // Tell the ContentBuilder what to build.
            contentBuilder.Clear();
            contentBuilder.Add(fileName, "plane", null, "ModelProcessor");

            // Build this new model data.
            string buildError = contentBuilder.Build();

            if (string.IsNullOrEmpty(buildError))
            {
                // If the build succeeded, use the ContentManager to
                // load the temporary .xnb file that we just created.
                modelViewerControl.Model = contentManager.Load<Model>("plane");
            }
            else
            {
                // If the build failed, display an error message.
                MessageBox.Show(buildError, "Error");
            }
        }

        private void PlaneVisualisationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            toolStripButtomOnMainForm.Checked = false;
        }

        private void PlaneVisualisationForm_Load(object sender, EventArgs e)
        {
            // Default to the directory which contains our content files.
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string relativePath = Path.Combine(assemblyLocation, "../");
            string contentPath = Path.GetFullPath(relativePath);
            LoadModel(contentPath + "Content\\plane.FBX");
        }
    }
}
