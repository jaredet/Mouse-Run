using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MouseRun
{
    public static class GameConstants
    {
        // Grid Dimensions
        public const int GridMinX = 0;
        public const int GridMaxX = 21;
        public const int GridMinY = 0;
        public const int GridMaxY = 29;

        // Graphics Settings
        public const int WinResX = (GridMaxX - GridMinX + 1) * 20;
        public const int WinResY = (GridMaxY - GridMinY + 1) * 20;

        // Speeds
        public const float MouseSpeed = 2.0f;
        public const float CatSpeed   = 2.2f;

    }
}
