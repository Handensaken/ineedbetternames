using System;
using Raylib_cs;
namespace Snake
{
    class Program
    {

        public enum GameScreens //enum of different screens used 
        {   
            Start,
            Game,
            Gameover
        }

        public static GameScreens gameScreen = GameScreens.Start;   //sets the first screen

        static void Main(string[] args)
        {
            Grid grid = new Grid();
            Snake snake = new Snake();
            FoodSpawner foodSpawner = new FoodSpawner(); //I trust people to know what instantiation is
            Raylib.InitWindow(800, 800, "snake");
            Raylib.SetTargetFPS(15); //Game moves based on frames. lower frames = lower speed. if your computer can't run it at 60 Fps don't use it, it's on fire.
            foodSpawner.SpawnFood();

            while (!Raylib.WindowShouldClose()) //looping the game untill it is closed
            {
                //logic. everything that need them quick maths
                if (gameScreen == GameScreens.Start)
                {
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {
                        gameScreen = GameScreens.Game;
                    }
                }
                else if (gameScreen == GameScreens.Game) //Can be slightly optimized through the use of a generic GameObject type.
                {
                    snake.Update();
                    foreach (Tail tail in Snake.tail)
                    {
                        tail.Update();
                    }
                }
                else if (gameScreen == GameScreens.Gameover)
                {
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
                    {
                        Raylib.CloseWindow();
                    }
                }

                //graphics. you know them colors and stuff yeah.
                Raylib.BeginDrawing();

                if (gameScreen == GameScreens.Start)
                {
                    Raylib.ClearBackground(Color.WHITE);
                    Raylib.DrawText("Press SPACE to start", 40, 350, 64, Color.BLACK);
                }
                else if (gameScreen == GameScreens.Game) //can be optimized through use of a generic GameObject type.
                {
                    Raylib.ClearBackground(Color.WHITE);
                    Grid.Draw();
                    snake.Draw();
                    Food.Draw();
                    foreach (Tail tail in Snake.tail)
                    {
                        tail.Draw();
                    }
                }
                else if (gameScreen == GameScreens.Gameover)
                {
                    Raylib.ClearBackground(Color.BLACK);
                    Raylib.DrawText("Game Over", 250, 300, 64, Color.RED);
                    Raylib.DrawText("Press ESCAPE to quit", 40, 500, 64, Color.RED);
                }


                Raylib.EndDrawing();

            }

        }
    }
}
