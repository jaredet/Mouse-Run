using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MouseRun
{
    static class GameConstants
    {
        // Grid Dimensions
        public const int GridMinX = 0;
        public const int GridMaxX = 21;
        public const int GridMinY = 0;
        public const int GridMaxY = 29;

        // Graphics Settings
        public const int WinResX = (GridMaxX - GridMinX + 1) * 20;
        public const int WinResY = (GridMaxY - GridMinY + 1) * 20;

        // Basic Cardinal Directions
        //public Vector2 DirectionLeft  = new Vector2(-1.0f, 0.0f);
        //public Vector2 DirectionRight = new Vector2(1.0f, 0.0f);
        //public Vector2 DirectionUp    = new Vector2(0.0f, -1.0f);
        //public Vector2 DirectionDown  = new Vector2(0.0f, 1.0f);
        //public Vector2 DirectionStop  = new Vector2(0.0f, 0.0f);

        // Diagonal Directions (Cats only)
        //public const Vector2 DirectionLeftUp    = new Vector2(-0.70710678f, -0.70710678f);
        //public const Vector2 DirectionRightUp   = new Vector2(0.70710678f, -0.70710678f);
        //public const Vector2 DirectionLeftDown  = new Vector2(-0.70710678f, 0.70710678f);
        //public const Vector2 DirectionRightDown = new Vector2(0.70710678f, 0.70710678f);

        // aStar Constants
        public const float StraightCost = 1.0f;
        public const float DiagonalCost = 1.41421356f;

    }
}
