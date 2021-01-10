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

        public void Update() //moves the individual pieces of the tail to the prior position of the piece in front.
        {
            if (Snake.tail.IndexOf(this) != 0) //gets previous position from the head if it's the first piece of tail
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
        public void Draw() //draws the tail
        {
            Raylib.DrawRectangle(currentPos.x, currentPos.y, 19, 19, Color.GREEN);
        }

    }
}
