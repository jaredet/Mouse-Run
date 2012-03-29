using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MouseRun
{
    static class GameConstants
    {
        public static const int GridMinX = 0;
        public static const int GridMaxX = 21;
        public static const int GridMinY = 0;
        public static const int GridMaxY = 29;

        //Basic Cardinal Directions
        public static const Vector2 DirectionLeft  = new Vector2(-1.0f, 0.0f);
        public static const Vector2 DirectionRight = new Vector2(1.0f, 0.0f);
        public static const Vector2 DirectionUp    = new Vector2(0.0f, -1.0f);
        public static const Vector2 DirectionDown  = new Vector2(0.0f, 1.0f);
        public static const Vector2 DirectionStop  = new Vector2(0.0f, 0.0f);

        //Diagonal Directions (Cats only)
        public static const Vector2 DirectionLeftUp    = new Vector2(-0.70710678f, -0.70710678f);
        public static const Vector2 DirectionRightUp   = new Vector2(0.70710678f, -0.70710678f);
        public static const Vector2 DirectionLeftDown  = new Vector2(-0.70710678f, 0.70710678f);
        public static const Vector2 DirectionRightDown = new Vector2(0.70710678f, 0.70710678f);

        //aStar Constants
        public static const float StraightCost = 1.0f;
        public static const float DiagonalCost = 1.41421356f;

    }
}
