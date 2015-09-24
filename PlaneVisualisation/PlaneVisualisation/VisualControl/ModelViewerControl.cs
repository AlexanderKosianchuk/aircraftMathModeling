#region File Description
//-----------------------------------------------------------------------------
// ModelViewerControl.cs
//
// Microsoft XNA Community Game Platform
// Copyright (c) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MathPlaneModel;


namespace PlaneVisualisation
{
    /// <summary>
    /// Example control inherits from GraphicsDeviceControl, and displays
    /// a spinning 3D model. The main form class is responsible for loading
    /// the model: this control just displays it.
    /// </summary>
    class ModelViewerControl : GraphicsDeviceControl
    {
        public IntegralMeanings modelOperatingParams;

        /// <summary>
        /// Gets or sets the current model.
        /// </summary>
        public Model Model
        {
            get { return model; }

            set
            {
                model = value;

                if (model != null)
                {
                    MeasureModel();
                }
            }
        }

        Model model;


        // Cache information about the model size and position.
        Matrix[] boneTransforms;
        Vector3 modelCenter;
        float modelRadius;


        // Timer controls the rotation speed.
        Stopwatch timer;


        /// <summary>
        /// Initializes the control.
        /// </summary>
        protected override void Initialize()
        {
            // Start the animation timer.
            timer = Stopwatch.StartNew();

            // Hook the idle event to constantly redraw our animation.
            Application.Idle += delegate { Invalidate(); };
        }


        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.LightSkyBlue);

            if (model != null)
            {
                // Compute camera matrices.
                float rotation = (float)timer.Elapsed.TotalSeconds;


                //modelOperatingParams
                Vector3 eyePosition = modelCenter;

                eyePosition.Z = modelRadius * 3;
                eyePosition.Y = modelRadius * 1.5f;
                //eyePosition.X = modelRadius;

                float aspectRatio = GraphicsDevice.Viewport.AspectRatio;
                
                float nearClip = modelRadius / 100;
                float farClip = modelRadius * 100;

                //Eiler angles
                Matrix world = new Matrix();
                world += Matrix.CreateRotationY((float)(modelOperatingParams.PSI / (180 / Math.PI)));
                world += Matrix.CreateRotationZ((float)(modelOperatingParams.GAMA / (180 / Math.PI)));
                world += Matrix.CreateRotationX((float)(modelOperatingParams.THETA / (180 / Math.PI) - (5 / (180 / Math.PI))));

                Matrix view = Matrix.CreateLookAt(eyePosition, modelCenter, Vector3.Up);
                Matrix projection = Matrix.CreatePerspectiveFieldOfView(1, aspectRatio,
                                                                    nearClip, farClip);

                // Draw the model.
                foreach (ModelMesh mesh in model.Meshes)
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        effect.World = boneTransforms[mesh.ParentBone.Index] * world;
                        effect.View = view;
                        effect.Projection = projection;

                        effect.EnableDefaultLighting();
                        effect.PreferPerPixelLighting = true;
                        effect.SpecularPower = 5;
                    }

                    mesh.Draw();
                }
            }
        }


        /// <summary>
        /// Whenever a new model is selected, we examine it to see how big
        /// it is and where it is centered. This lets us automatically zoom
        /// the display, so we can correctly handle models of any scale.
        /// </summary>
        void MeasureModel()
        {
            // Look up the absolute bone transforms for this model.
            boneTransforms = new Matrix[model.Bones.Count];
            
            model.CopyAbsoluteBoneTransformsTo(boneTransforms);

            // Compute an (approximate) model center position by
            // averaging the center of each mesh bounding sphere.
            modelCenter = Vector3.Zero;

            foreach (ModelMesh mesh in model.Meshes)
            {
                BoundingSphere meshBounds = mesh.BoundingSphere;
                Matrix transform = boneTransforms[mesh.ParentBone.Index];
                Vector3 meshCenter = Vector3.Transform(meshBounds.Center, transform);

                modelCenter += meshCenter;
            }

            modelCenter /= model.Meshes.Count;

            // Now we know the center point, we can compute the model radius
            // by examining the radius of each mesh bounding sphere.
            modelRadius = 0;

            foreach (ModelMesh mesh in model.Meshes)
            {
                BoundingSphere meshBounds = mesh.BoundingSphere;
                Matrix transform = boneTransforms[mesh.ParentBone.Index];
                Vector3 meshCenter = Vector3.Transform(meshBounds.Center, transform);

                float transformScale = transform.Forward.Length();
                
                float meshRadius = (meshCenter - modelCenter).Length() +
                                   (meshBounds.Radius * transformScale);

                modelRadius = Math.Max(modelRadius,  meshRadius);
            }
        }

        public void getIntegralMeaningsRef(IntegralMeanings integralMeanings)
        {
            modelOperatingParams = integralMeanings;
        }
    }
}
