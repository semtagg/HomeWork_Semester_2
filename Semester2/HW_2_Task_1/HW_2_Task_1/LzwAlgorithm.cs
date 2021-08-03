﻿using System;
using System.Collections;
using System.IO;

namespace HW_2_Task_1
{
    /// <summary>
    /// The algorithm used to compress and decompress files.
    /// </summary>
    public static class LzwAlgorithm
    {
        private static int GetCurrentNumberOfBytes(int size, int count)
            => (int)Math.Ceiling(Math.Log2(size) / 8) > count ? (int)Math.Ceiling(Math.Log2(size) / 8) : count;

        /// <summary>
        /// Сompresses the file and writes it in a new file.
        /// </summary>
        /// <param name="readPath">Path to the file which we want to compress.</param>
        public static void Compress(string readPath)
        {
            using var readFile = new FileStream(readPath, FileMode.Open);
            using var writeFile = new FileStream(readPath + ".zipped", FileMode.OpenOrCreate);
            var trie = new Trie();
            var currentNumberOfBytes = 1;
            var isChanged = false;
            var currentByte = (byte)0;
            for (int i = 0; i < readFile.Length; i++)
            {
                currentNumberOfBytes = GetCurrentNumberOfBytes(trie.Count, currentNumberOfBytes);
                if (!isChanged)
                {
                    currentByte = (byte)readFile.ReadByte();
                }
                var result = trie.TryAdd(currentByte);
                if ((i == readFile.Length - 1) && (result == -1))
                {
                    var helpArray = BitConverter.GetBytes(trie.GetLastResult());
                    writeFile.Write(helpArray, 0, currentNumberOfBytes);
                }
                if (result == -1)
                {
                    isChanged = false;
                    continue;
                }
                else
                {
                    isChanged = true;
                    var helpArray = BitConverter.GetBytes(result);
                    writeFile.Write(helpArray, 0, currentNumberOfBytes);
                    i--;
                }
            }
        }

        private static Hashtable InitializeHashtable()
        {
            var hashtable = new Hashtable();
            for (int i = 0; i < 256; i++)
            {
                hashtable.Add(i, new byte[] { (byte)i });
            }
            return hashtable;
        }

        /// <summary>
        /// Decompresses the file and writes it in a new file.
        /// </summary>
        /// <param name="readPath">Path to the file which we want to decompress.</param>
        public static void Decompress(string readPath)
        {
            using var readFile = new FileStream(readPath, FileMode.Open);
            using var writeFile = new FileStream(readPath.Substring(0, readPath.Length - 7), FileMode.OpenOrCreate);
            var hashtable = InitializeHashtable();
            var currentHashtableIndex = 256;
            var currentNumberOfBytes = 1;
            for (int i = 0; i < readFile.Length; i += currentNumberOfBytes)
            {
                byte[] arrayOfBytes;
                if (currentNumberOfBytes <= 4)
                {
                    arrayOfBytes = new byte[4];
                }
                else
                {
                    arrayOfBytes = new byte[currentNumberOfBytes];
                }
                for (int j = 0; j < currentNumberOfBytes; j++)
                {
                    arrayOfBytes[j] = (byte)readFile.ReadByte();
                }
                var index = BitConverter.ToInt32(arrayOfBytes, 0);
                if (currentHashtableIndex != 256)
                {
                    ((byte[])hashtable[currentHashtableIndex - 1])[^1] = ((byte[])hashtable[index])[0];
                }
                var arrayForWrite = (byte[])hashtable[index];
                writeFile.Write(arrayForWrite);
                Array.Resize(ref arrayForWrite, arrayForWrite.Length + 1);
                hashtable.Add(currentHashtableIndex, arrayForWrite);
                currentHashtableIndex++;
                currentNumberOfBytes = GetCurrentNumberOfBytes(hashtable.Count, currentNumberOfBytes);
            } 
        }
    }
}
