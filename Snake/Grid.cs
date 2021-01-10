using System;
using Raylib_cs;
namespace Snake
{
    public class Grid
    {
        public static Point[,] grid = new Point[40, 40];
        public Grid()
        {
            for (int i = 0; i < grid.GetLength(0); i++) //looping through grid
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = new Point(i * 19 + 32, j * 19 + 32);   //assigning value to point in grid. *19 + 32 was found by extensive testing but it works well enough
                    System.Console.WriteLine("X: " + grid[i, j].x);
                    System.Console.WriteLine("Y: " + grid[i, j].y);
                }
            }
        }
        public static void Draw()
        {
           
            for (int i = 0; i < grid.GetLength(0); i++)//draws vertical lines for the grid
            {
                Point pos = new Point(grid[i, 0].x, grid[i, 0].y);
                Raylib.DrawLine(pos.x, pos.y, pos.x, 792, Color.BLACK);
            }
            Raylib.DrawLine(40 * 19 + 32, 32, 40 * 19 + 32, 792, Color.BLACK); //adds last line outside the grid
            for (int i = 0; i < grid.GetLength(1); i++)//draws horizontal lines
            {
                //horizontal
                Point pos = new Point(grid[0, i].x, grid[0, i].y);
                Raylib.DrawLine(pos.x , pos.y, 792, pos.y, Color.BLACK);
            }
            Raylib.DrawLine(32,40 * 19 + 32, 792, 40 * 19 + 32, Color.BLACK); //last line outside
        }
    }
}
