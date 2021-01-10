using System;
using Raylib_cs;
using System.Collections.Generic;
namespace Snake
{


    public class Snake
    {
        FoodSpawner foodSpawner = new FoodSpawner();

        Program ugly = new Program();
        public enum Directions
        {
            up,
            down,
            right,
            left
        }
        Directions direction = Directions.right;
        public static Point currentPosition = new Point(0, 0);
        public static Point previousPosition = new Point(0, 0);
        int iIndex = 0;
        int jIndex = 0;

        public static List<Tail> tail = new List<Tail>();

        public void Update()
        {

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_A) && direction != Directions.left && direction != Directions.right || Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT) && direction != Directions.left && direction != Directions.right)
            {
                direction = Directions.left;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_D) && direction != Directions.left && direction != Directions.right || Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT) && direction != Directions.left && direction != Directions.right)
            {
                direction = Directions.right;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_S) && direction != Directions.down && direction != Directions.up || Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN) && direction != Directions.down && direction != Directions.up)
            {
                direction = Directions.down;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_W) && direction != Directions.down && direction != Directions.up || Raylib.IsKeyPressed(KeyboardKey.KEY_UP) && direction != Directions.down && direction != Directions.up)
            {
                direction = Directions.up;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_E))
            {
                tail.Add(new Tail());
                System.Console.WriteLine("pressed e");
            }

            switch (direction)
            {
                case Directions.up:
                    {
                        jIndex -= 1;
                        break;
                    }
                case Directions.down:
                    {
                        jIndex += 1;
                        break;
                    }
                case Directions.right:
                    {
                        iIndex += 1;
                        break;
                    }
                case Directions.left:
                    {
                        iIndex -= 1;
                        break;
                    }
            }


            if (iIndex < 0)
            {
                iIndex = 0; /*Will kill snake when I can be fucked*/
                Program.gameScreen = Program.GameScreens.Gameover;
            };
            if (iIndex > 39)
            {
                iIndex = 39;
                Program.gameScreen = Program.GameScreens.Gameover;
            }
            if (jIndex < 0)
            {
                jIndex = 0;
                Program.gameScreen = Program.GameScreens.Gameover;
            }
            if (jIndex > 39)
            {
                jIndex = 39;
                Program.gameScreen = Program.GameScreens.Gameover;
            }

            previousPosition = currentPosition;
            currentPosition = Grid.grid[iIndex, jIndex];
            if (currentPosition == FoodSpawner.foodPoint)
            {
                tail.Add(new Tail());
                foodSpawner.SpawnFood();
            }
            foreach (Tail tail in tail)
            {
                if (currentPosition == tail.currentPos)
                {
                    Program.gameScreen = Program.GameScreens.Gameover;
                }
            }
        }
        public void Draw()
        {
            Raylib.DrawRectangle(currentPosition.x, currentPosition.y, 19, 19, Color.GREEN);
        }
    }
}
