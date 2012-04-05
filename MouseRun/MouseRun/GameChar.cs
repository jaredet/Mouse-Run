using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MouseRun
{
    class GameChar
    {
        public List<Vector2> waypoints {get; set;}
        private Point destination;
        private Point location;
        private float speed;

        GameChar()
        {
            waypoints = new List<Vector2>();
            location = new Point();
            destination = location;
            speed = 0.0f;
        }

        void Update(GameTime gameTime)
        {
            Move(gameTime);
        }

        void Move(GameTime gameTime)
        {
            
        }
    }
}
