using System;
using System.Collections.Generic;
using Raylib_cs;
namespace Snake
{
    public class Tail
    {
        //static List<Tail> tail = new List<Tail>();
        public Point currentPos;
        Point prevPoint;
       /* public Tail()
        {
            tail.Add(this);
        }*/

        public void Update()
        {
            if (Snake.tail.IndexOf(this) != 0)
            {
                prevPoint = currentPos;
                currentPos = Snake.tail[Snake.tail.IndexOf(this) - 1].prevPoint;
            }
            else
            {
                prevPoint = currentPos;
                currentPos = Snake.previousPosition;
            }
        }
        public void Draw()
        {
            Raylib.DrawRectangle(currentPos.x,currentPos.y,19,19,Color.GREEN);
        }

    }
}
