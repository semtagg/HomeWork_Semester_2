using System;

namespace HW_6_Task_2
{
    public class Game
    {
        private (int, int) coordinates;
        private Map map;
        public Game(string path)
        {
            map = new Map(path);
            coordinates = map.GetCoordinates();
        }
        private static int x;
        private static int y;
        public void OnLeft(object sender, EventArgs args)
        {
            x = coordinates.Item1;
            y = coordinates.Item2;
            coordinates.Item1--;
            TryMove(ref coordinates);
        }
        
        public void OnRight(object sender, EventArgs args)
        {
            x = coordinates.Item1;
            y = coordinates.Item2;
            coordinates.Item1++;
            TryMove(ref coordinates);
        }
        public void OnUp(object sender, EventArgs args)
        {
            x = coordinates.Item1;
            y = coordinates.Item2;
            coordinates.Item2--;
            TryMove(ref coordinates);
        }
        public void OnDown(object sender, EventArgs args)
        {
            x = coordinates.Item1;
            y = coordinates.Item2;
            coordinates.Item2++;
            TryMove(ref coordinates);
        }

        private void Move()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            Console.SetCursorPosition(coordinates.Item1, coordinates.Item2);
            Console.Write('@');
        }

        private void TryMove(ref (int, int) coordinates)
        {
            if (map.TryMove(coordinates))
            {
                Move();
            }
            else
            {
                coordinates.Item1 = x;
                coordinates.Item2 = y;
            }
            Console.SetCursorPosition(0,9);
            Console.Write("                                   ");
            Console.SetCursorPosition(0, 9);
            Console.WriteLine($"X = {coordinates.Item1}, Y = {coordinates.Item2}.");
        }
    }
}
