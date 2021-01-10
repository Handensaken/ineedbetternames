using System;
using Raylib_cs;
namespace Snake
{
    class Program
    {

        public enum GameScreens
        {
            Start,
            Game,
            Gameover
        }

        public static GameScreens gameScreen = GameScreens.Start;

        static void Main(string[] args)
        {
            Grid grid = new Grid();

            Snake snake = new Snake();
            FoodSpawner foodSpawner = new FoodSpawner();
            Raylib.InitWindow(800, 800, "snake");
            Raylib.SetTargetFPS(15);
            foodSpawner.SpawnFood();

            while (!Raylib.WindowShouldClose())
            {
                //logic
                if (gameScreen == GameScreens.Start)
                {
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {
                        gameScreen = GameScreens.Game;
                    }
                }
                else if (gameScreen == GameScreens.Game)
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

                //graphics
                Raylib.BeginDrawing();

                if (gameScreen == GameScreens.Start)
                {
                    Raylib.ClearBackground(Color.WHITE);
                    Raylib.DrawText("Press SPACE to start", 40, 350, 64, Color.BLACK);
                }
                else if (gameScreen == GameScreens.Game)
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
