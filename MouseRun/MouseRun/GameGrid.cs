using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MouseRun
{
    static class GameGrid
    {
        static private int[] barriers;

        static GameGrid()
        {
            barriers = new int[30];
            barriers[00] = 0x3FFFFF;
            barriers[01] = 0x200001;
            barriers[02] = 0x2DF3ED;
            barriers[03] = 0x2DF3ED;
            barriers[04] = 0x200001;
            barriers[05] = 0x277FB9;
            barriers[06] = 0x270039;
            barriers[07] = 0x270039;
            barriers[08] = 0x277FB9;
            barriers[09] = 0x200001;
            barriers[10] = 0x2EAA9D;
            barriers[11] = 0x2C000D;
            barriers[12] = 0x288045;
            barriers[13] = 0x222111;
            barriers[14] = 0x288C45;
            barriers[15] = 0x288C45;
            barriers[16] = 0x222111;
            barriers[17] = 0x288045;
            barriers[18] = 0x2C000D;
            barriers[19] = 0x2E555D;
            barriers[20] = 0x200001;
            barriers[21] = 0x277FB9;
            barriers[22] = 0x270039;
            barriers[23] = 0x270039;
            barriers[24] = 0x277FB9;
            barriers[25] = 0x200001;
            barriers[26] = 0x2DF3ED;
            barriers[27] = 0x2DF3ED;
            barriers[28] = 0x200001;
            barriers[29] = 0x3FFFFF;
        }

        public static bool IsInGrid(Point p)
        {
            if (p.X >= GameConstants.GridMinX && p.X <= GameConstants.GridMaxX &&
                p.Y >= GameConstants.GridMinY && p.Y <= GameConstants.GridMaxY)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public static bool Free(Point p)
        {
            int n = 0x01;
            n <<= 21 - p.X;
            if ((barriers[p.Y] & n) != 0)
            {
                return false;
            }

            else if(!IsInGrid(p))
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        public static List<Point> Adjacent(Point p)
        {
            List<Point> a = new List<Point>();
            if (IsInGrid(p))
            {
                if(IsInGrid(new Point(p.X - 1, p.Y)))
                {
                    a.Add(new Point(p.X - 1, p.Y));
                }

                if (IsInGrid(new Point(p.X + 1, p.Y)))
                {
                    a.Add(new Point(p.X + 1, p.Y));
                }

                if (IsInGrid(new Point(p.X, p.Y - 1)))
                {
                    a.Add(new Point(p.X, p.Y - 1));
                }

                if (IsInGrid(new Point(p.X, p.Y + 1)))
                {
                    a.Add(new Point(p.X, p.Y + 1));
                }
            }

            return a;
        }

        public static List<Point> FreeAdjacent(Point p)
        {
            List<Point> a  = Adjacent(p);
            List<Point> fa = new List<Point>();

            for (int i = 0; i < a.Count; i++)
            {
                if(Free(a[i]))
                {
                    fa.Add(a[i]);
                }
            }

            return fa;
        }

        public static List<Vector2> aStar(Point start, Point end)
        {
        }
    }
}
