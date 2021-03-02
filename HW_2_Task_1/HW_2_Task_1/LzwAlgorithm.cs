using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace HW_2_Task_1
{
    class LzwAlgorithm //: ILzwAlgorithm
    {
        private static Trie Initalisation() // name
        {
            var trie = new Trie();
            for (int i = 0; i < 256; i++)
            {
                trie.Add($"{(char)i}");
            }
            return trie;
        }
        public void Compress(string readPath)
        {
            var writePath = readPath + ".zipped";
            using (var readFile = new FileStream(readPath,FileMode.Open))
            {
                var arrayOfBytes = new byte[readFile.Length];
                readFile.Read(arrayOfBytes, 0, arrayOfBytes.Length);
                using (var writeFile = new FileStream(writePath, FileMode.OpenOrCreate))
                {
                    var trie = Initalisation();
                    for (int i = 0; i < arrayOfBytes.Length; i++)
                    {
                        int lastResult = -1;
                        var currentLine = $"{(char)arrayOfBytes[i]}";
                        var result = trie.Add(currentLine);
                        while (result != -1)
                        {
                            lastResult = result;
                            i++;
                            if (i == readFile.Length)
                            {
                                break;
                            }
                            currentLine += $"{(char)arrayOfBytes[i]}";
                            result = trie.Add(currentLine);
                            
                        }
                        i--;
                        var helpArray = BitConverter.GetBytes(lastResult);
                        var index = (int)Math.Ceiling(Math.Log2(lastResult) / 8);
                        if (index == 0)
                        {
                            index = 1;
                        }
                        writeFile.Write(helpArray, 0, index);
                    }
                }
            }
        }

        public void Decompress(string readPath)
        {
            throw new NotImplementedException();
        }
    }
}
