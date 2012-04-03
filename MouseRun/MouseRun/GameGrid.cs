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
            HashSet<Point> closedSet = new HashSet<Point>(); // The set of nodes already evaluated.
            HashSet<Point> openSet   = new HashSet<Point>(); // The set of tentative nodes to be evaluated,
            openSet.Add(start);                              // initially containing the start node
            Dictionary<Point,Point> came_from = new Dictionary<Point,Point>();  // The map of navigated nodes.
            Dictionary<Point,int> g_score = new Dictionary<Point,int>();
            Dictionary<Point,int> h_score = new Dictionary<Point,int>();
            Dictionary<Point,int> f_score = new Dictionary<Point,int>();
 
             g_score[start] = 0;
             h_score[start] = Math.Abs(start.X - end.X) + Math.Abs(start.Y - end.Y);
             f_score[start] = g_score[start] + h_score[start];
 
             while(openSet.Count > 0)
             {
                 Point current = openSet.First();
                 foreach(Point p in openSet)
                 {
                     if(f_score[p] < f_score[current])
                     {
                         current = p;
                     }
                 }

                 if (current == end)
                 {
                     List<Vector2> waypoints = new List<Vector2>();
                     while (current != start)
                     {
                         Point from = came_from[current];
                         if ((from.X > current.X) && (from.Y == current.Y)) // Left
                         {
                             waypoints.Insert(0, GameConstants.DirectionLeft);
                         }

                         else if ((from.X < current.X) && (from.Y == current.Y)) // Right
                         {
                             waypoints.Insert(0, GameConstants.DirectionRight);
                         }

                         else if ((from.X == current.X) && (from.Y > current.Y)) // Up
                         {
                             waypoints.Insert(0, GameConstants.DirectionUp);
                         }

                         else if ((from.X == current.X) && (from.Y < current.Y)) // Down
                         {
                             waypoints.Insert(0, GameConstants.DirectionDown);
                         }

                         else if ((from.X > current.X) && (from.Y > current.Y)) // LeftUp
                         {
                             waypoints.Insert(0, GameConstants.DirectionLeftUp);
                         }

                         else if ((from.X > current.X) && (from.Y < current.Y)) // LeftDown
                         {
                             waypoints.Insert(0, GameConstants.DirectionLeftUp);
                         }

                         else if ((from.X < current.X) && (from.Y > current.Y)) // RightUp
                         {
                             waypoints.Insert(0, GameConstants.DirectionLeftUp);
                         }

                         else if ((from.X < current.X) && (from.Y < current.Y)) // RightDown
                         {
                             waypoints.Insert(0, GameConstants.DirectionLeftUp);
                         }

                         current = from;
                     }

                     return waypoints;
                 }
 
                 openSet.Remove(current);
                 closedSet.Add(current);
                 foreach (Point neighbor in FreeAdjacent(current))
                 {
                     bool tentative_is_better = false;

                     if (closedSet.Contains(neighbor))
                     {
                         continue;
                     }

                     int tentative_g_score = g_score[current] + 
                         (int)(10 * Math.Sqrt(Math.Abs(current.X - neighbor.X)*Math.Abs(current.X - neighbor.X) + 
                         Math.Abs(current.Y - neighbor.Y)*Math.Abs(current.Y - neighbor.Y)));
 
                     if(!openSet.Contains(neighbor))
                     {
                         openSet.Add(neighbor);
                         h_score[neighbor] = Math.Abs(neighbor.X - end.X) + Math.Abs(neighbor.Y - end.Y);
                         tentative_is_better = true;
                     }

                     else if (tentative_g_score < g_score[neighbor])
                     {
                         tentative_is_better = true;
                     }

                     else
                     {
                         tentative_is_better = false;
                     }
 
                     if (tentative_is_better == true)
                     {
                         came_from[neighbor] = current;
                         g_score[neighbor] = tentative_g_score;
                         f_score[neighbor] = g_score[neighbor] + h_score[neighbor];
                     }
                 }
             }
             return new List<Vector2>();
        }
    }
}
