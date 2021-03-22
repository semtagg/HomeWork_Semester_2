using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;


namespace HW_6_Task_2
{
    public class Map
    {
        public Map(string path)
        {
            InitMap(path);
        }

        private struct Player
        {
            public int x;
            public int y;
        }

        static private Player player = new Player(); // убрать статик
        static private bool[,] boolMap;

        private void InitMap(string path)
        {
            int j = 0;
            string[] readText = File.ReadAllLines(path);
            boolMap = new bool[readText[0].Length, readText.Length];
            foreach (string line in readText)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '@')
                    {
                        player.x = i;
                        player.y = j;
                    }
                    if (line[i] == ' ' || line[i] == '@')
                    {
                        boolMap[i, j] = true;
                    }
                }
                Console.WriteLine(line);
                j++;
            }
            Console.WriteLine($"X = {player.x}, Y = {player.y}.");
        }

        public bool TryMove((int, int) coordinates)
        {
            (int x, int y) = coordinates;
            if (x < 0 || y < 0) // проверить в boolMap[, ]
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                
                return boolMap[x, y];
            }
        }

        public (int, int) GetCoordinates()
            => (player.x, player.y);
    }
}
