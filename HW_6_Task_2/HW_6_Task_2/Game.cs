using System;

namespace HW_6_Task_2
{
    /// <summary>
    /// Implements the mechanics of the game.
    /// </summary>
    public class Game
    {
        public Game(string path)
        {
            map = new Map(path);
            coordinates = map.GetCoordinates();
        }

        private Map map;
        private (int X, int Y) coordinates;
        public (int X, int Y) СurrentCoordinates { get; private set; }

        /// <summary>
        /// Movement of the player to the left.
        /// </summary>
        public void OnLeft(object sender, EventArgs args)
        {
            СurrentCoordinates = coordinates;
            coordinates.X--;
            Move();
        }

        /// <summary>
        /// Movement of the player to the right.
        /// </summary>
        public void OnRight(object sender, EventArgs args)
        {
            СurrentCoordinates = coordinates;
            coordinates.X++;
            Move();
        }

        /// <summary>
        /// Movement of the player up.
        /// </summary>
        public void OnUp(object sender, EventArgs args)
        {
            СurrentCoordinates = coordinates;
            coordinates.Y--;
            Move();
        }

        /// <summary>
        /// Movement of the player down.
        /// </summary>
        public void OnDown(object sender, EventArgs args)
        {
            СurrentCoordinates = coordinates;
            coordinates.Y++;
            Move();
        }

        private void Move()
        {
            if (map.TryMove(coordinates))
            {
                Console.SetCursorPosition(СurrentCoordinates.X, СurrentCoordinates.Y);
                Console.Write(' ');
                Console.SetCursorPosition(coordinates.X, coordinates.Y);
                Console.Write('@');
            }
            else
            {
                coordinates = СurrentCoordinates;
            }
            Console.SetCursorPosition(map.GetMax().X, map.GetMax().Y);
            Console.WriteLine("");
        }
    }
}
