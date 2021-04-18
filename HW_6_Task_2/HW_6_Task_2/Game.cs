using System;

namespace HW_6_Task_2
{
    public class Game
    {
        public Game(string path)
        {
            map = new Map(path);
            this.coordinates = map.GetCoordinates();
        }

        private Map map;
        private (int X, int Y) coordinates;
        private (int X, int Y) currentCoordinates;

        public void OnLeft(object sender, EventArgs args)
        {
            currentCoordinates = coordinates;
            coordinates.X--;
            Move();
        }

        public void OnRight(object sender, EventArgs args)
        {
            currentCoordinates = coordinates;
            coordinates.X++;
            Move();
        }
        public void OnUp(object sender, EventArgs args)
        {
            currentCoordinates = coordinates;
            coordinates.Y--;
            Move();
        }
        public void OnDown(object sender, EventArgs args)
        {
            currentCoordinates = coordinates;
            coordinates.Y++;
            Move();
        }

        private void Move()
        {
            try
            {
                if (map.TryMove(coordinates))
                {
                    Console.SetCursorPosition(currentCoordinates.X, currentCoordinates.Y);
                    Console.Write(' ');
                    Console.SetCursorPosition(coordinates.X, coordinates.Y);
                    Console.Write('@');
                }
                else
                {
                    coordinates = currentCoordinates;
                }
                Console.SetCursorPosition(map.GetMax().X, map.GetMax().Y);
                Console.WriteLine("");
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
