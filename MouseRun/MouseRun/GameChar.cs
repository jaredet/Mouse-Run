using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MouseRun
{
    public class GameChar
    {
        public List<Vector2> waypoints {get; set;}
        protected Point destination;
        protected Vector2 location;
        protected float speed;

        protected GameChar()
        {
            waypoints = new List<Vector2>();
            location = new Vector2();
            destination = new Point();
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

    public class Cat : GameChar
    {
        Cat()
        {
            waypoints = new List<Vector2>();
            location = new Vector2();
            speed = GameConstants.CatSpeed;
        }

        Cat(Point p)
        {
            waypoints = new List<Vector2>();
            location = new Vector2(p.X * 20, p.Y * 20);
            speed = GameConstants.CatSpeed;
        }

        Cat(Vector2 v)
        {
            waypoints = new List<Vector2>();
            location = v;
            speed = GameConstants.CatSpeed;
        }

        void Update(GameTime gameTime)
        {
            Vector2 destination = new Vector2(waypoints[0].X * 20, waypoints[0].Y * 20);
            if (Math.Abs(Vector2.Distance(location, destination)) < 0.2)
            {
                waypoints.RemoveAt(0);
            }
            Move(gameTime);
        }

        void Move(GameTime gameTime)
        {
            Vector2 destination = new Vector2(waypoints[0].X * 20, waypoints[0].Y * 20);
            
        }
    }
}
