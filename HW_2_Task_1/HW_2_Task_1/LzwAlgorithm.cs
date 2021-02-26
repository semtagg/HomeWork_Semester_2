using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_Task_1
{
    class LzwAlgorithm : ILzwAlgorithm
    {
        private void Initalisation(Trie trie) // name
        {

            for (byte i = 0; i < 255; i++)
            {
                var newLine = $"{(char)i}";
                trie.Add(newLine);
            }
        }
        public void Compress(string readPath)
        {
            var writePath = readPath + ".zipped";
            using (var read = new FileStream(readPath,FileMode.Open))
            {
                var array = new byte[read.Length];
                read.Read(array, 0, array.Length);
                using (var write = new FileStream(writePath, FileMode.OpenOrCreate))
                {
                    var trie = new Trie();
                    Initalisation(trie);
                    for (int i = 0; i < array.Length; i++)
                    {
                        var currentLine = $"{array[i]}";
                        (var data, var result) = trie.Add(currentLine);
                        while (result)
                        {
                            i++;
                            currentLine += $"{array[i]}";
                        }
                        write.Write(BitConverter.GetBytes(data));
                    }
                }
            }
        }

        public string Decompress(string outputLine)
        {
            throw new NotImplementedException();
        }
    }
}
