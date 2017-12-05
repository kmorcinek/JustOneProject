using System;
using System.ComponentModel;
using System.IO;

namespace JustOneProject.Presentation.Moving
{
    public class GuyPlace2
    {
        public int X { get; private set; }

        public GuyPlace2(int x)
        {
            X = x;
        }

        public void MoveLeft(int distance)
        {
//            Move(Direction.Left, distance);
        }

        private void Move(Direction direction, int distance, string name)
        {

            if (name == null)
            {
            }
            else
            {
//                System.Windows.Forms.MessageBox.Show(name); 
            }

            if (distance < 0)
            {
                throw new IOException("vs");
            }

            if (direction == Direction.Left)
            {
                X -= distance;
            }
        }
    }

    public enum Direction
    {
        Left,
        Right
    }
}