using System;

namespace Snake
{
    public class FoodSpawner
    {
        public static Point foodPoint = new Point(0,0);
        public void SpawnFood()
        {
            bool locationLimit = false;
            while (!locationLimit)
            {
                foodPoint = Grid.grid[rand.Next(Grid.grid.GetLength(0)), rand.Next(Grid.grid.GetLength(1))];
                System.Console.WriteLine($"{foodPoint.x} + {foodPoint.y}");
                if (foodPoint != Snake.currentPosition)
                {
                    locationLimit = true;
                }
                foreach (Tail tail in Snake.tail)
                {
                    if (foodPoint != tail.currentPos)
                    {
                        locationLimit = true;
                    }
                }
            }
        }
        Random rand = new Random();
    }
}
