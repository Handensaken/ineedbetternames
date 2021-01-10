using System;
using Raylib_cs;
namespace Snake
{
    public class Food
    {
        public static void Draw()
        {
            Raylib.DrawRectangle(FoodSpawner.foodPoint.x, FoodSpawner.foodPoint.y, 19, 19, Color.RED);
        }
    }
}
