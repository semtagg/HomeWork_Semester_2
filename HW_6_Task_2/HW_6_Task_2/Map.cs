using System.IO;
using System;

namespace HW_6_Task_2
{
    /// <summary>
    /// Contains information about the map.
    /// </summary>
    public class Map
    {
        public Map(string path)
        {
            InitializeMap(path);
        }

        private (int X, int Y) player;
        private (int X, int Y) max;
        private bool[,] mapOutline;

        private void InitializeMap(string path)
        {
            var j = 0;
            var readText = File.ReadAllLines(path);
            max = (readText[0].Length, readText.Length);
            player = (-1, -1);
            mapOutline = new bool[max.Y, max.X];
            foreach (string line in readText)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '@')
                    {
                        player.X = i;
                        player.Y = j;
                    }
                    if (line[i] == ' ' || line[i] == '@')
                    {
                        mapOutline[j, i] = true;
                    }
                }
                Console.WriteLine(line);
                j++;
            }
            if (player == (-1, -1))
            {
                throw new PlayerNotFoundException();
            }
        }

        /// <summary>
        /// Trying to make a move to the new cordinates.
        /// </summary>
        public bool TryMove((int X, int Y) coordinates)
        {
            (int x, int y) = coordinates;
            if (x < 0 || y < 0 || max.Y < y || max.X < x)
            {
                throw new IndexOutOfRangeException();
            }
            return mapOutline[y, x];
        }

        /// <summary>
        /// Getting player coordinates.
        /// </summary>
        public (int, int) GetCoordinates()
            => player;

        /// <summary>
        /// Getting map dimensions.
        /// </summary>
        public (int X, int Y) GetMax()
            => max;

        /// <summary>
        /// Getting map outlines.
        /// </summary>
        public bool[,] GetMap()
            => mapOutline;
    }
}
