using System.IO;
using System;

namespace HW_6_Task_2
{
    public class Map
    {
        public Map(string path)
        {
            try
            {
                MapInitialization(path);
            }
            catch (PlayerNotFoundException)
            {
                throw new PlayerNotFoundException();
            }
        }

        private (int X, int Y) player;
        private (int X, int Y) max;
        private bool[,] mapOutline;

        private void MapInitialization(string path)
        {
            var j = 0;
            var readText = File.ReadAllLines(path);
            max = (readText[0].Length, readText.Length);
            player = (-1, -1);
            mapOutline = new bool[max.X, max.Y];
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
                        mapOutline[i, j] = true;
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

        public bool TryMove((int X, int Y) coordinates)
        {
            (int x, int y) = coordinates;
            if (x < 0 || y < 0 || max.Y < y || max.X < x)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return mapOutline[x, y];
            }
        }

        public (int, int) GetCoordinates()
            => player;

        public (int X, int Y) GetMax()
            => max;
    }
}
