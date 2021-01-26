using System;
using Raylib_cs;
using System.Collections.Generic;
namespace Snake
{


    public class Snake
    {
        public enum Directions  //an enum for keeping track of directions
        {
            up,
            down,
            right,
            left
        }
        FoodSpawner foodSpawner = new FoodSpawner();
        Directions direction = Directions.right;
        public static Point currentPosition = new Point(0, 0);
        public static Point previousPosition = new Point(0, 0);
        int iIndex = 0;
        int jIndex = 0;
        //I trust people know how to declare variables and classes

        public static List<Tail> tail = new List<Tail>(); //a list to keep track of the tail

        public void Update()
        {

            //changes the direction based on input
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && direction != Directions.left && direction != Directions.right || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) && direction != Directions.left && direction != Directions.right)
            {
                direction = Directions.left;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && direction != Directions.left && direction != Directions.right || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && direction != Directions.left && direction != Directions.right)
            {
                direction = Directions.right;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && direction != Directions.down && direction != Directions.up || Raylib.IsKeyDown(KeyboardKey.KEY_DOWN) && direction != Directions.down && direction != Directions.up)
            {
                direction = Directions.down;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && direction != Directions.down && direction != Directions.up || Raylib.IsKeyDown(KeyboardKey.KEY_UP) && direction != Directions.down && direction != Directions.up)
            {
                direction = Directions.up;
            }

            //moves the snake by setting the position to a point in the grid.
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

            //kills snake if hitting the outer edges
            if (iIndex < 0)
            {
                iIndex = 0;
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
            
            previousPosition = currentPosition;//sets previous position to the current position right before changing the current position
            currentPosition = Grid.grid[iIndex, jIndex];
            if (currentPosition == FoodSpawner.foodPoint) //adds length to the snake if food is eaten
            {
                tail.Add(new Tail());
                foodSpawner.SpawnFood();
            }
            foreach (Tail tail in tail) //kills snake if hit own tail
            {
                if (currentPosition == tail.currentPos)
                {
                    Program.gameScreen = Program.GameScreens.Gameover;
                }
            }
        }
        public void Draw() //yay colors
        {
            Raylib.DrawRectangle(currentPosition.x, currentPosition.y, 19, 19, Color.GREEN);
        }
    }
}
