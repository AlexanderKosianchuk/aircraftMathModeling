using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PlaneVisualisation
{
    class ConnectedCam : GameComponent
    {
        public Matrix viev;

        Vector3 position;
        Vector3 angle;

        float speed = 1;
        float turnSpeed = 2;

        public ConnectedCam (Game game, Vector3 position, Vector3 lookAt) : base (game)
        {
            this.position = position;

            viev = Matrix.CreateLookAt(position, lookAt, Vector3.Up);
        
        }

        public override void Update(GameTime gameTime)
        {
            /*float yaw = MathHelper.ToRadians()
            float pitch = 
            float raw*/

            base.Update(gameTime);
        }
    }
}
