using System;
using System.IO;

namespace HW_2_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            if ((args.Length != 2) && (args[0] != "-c") && (args[0] != "-u"))
            {
                Console.WriteLine("Ошибка ввода ключа, попробуйте еще раз.");
                return;
            }
            else if (!File.Exists(args[1]))
            {
                Console.WriteLine("Ошибка ввода ссылки на файл, попробуйте еще раз.");
                return;
            }
            else if (args[0] == "-c")
            {
                LzwAlgorithm.Compress(args[1]);
                var compressedFileSize = new FileInfo(args[1]);
                var decompressedFileSize = new FileInfo(args[1] + ".zipped");
                Console.WriteLine("Файл был удачно сжат!");
                Console.WriteLine($"Коэффициент сжатия: x {(double)compressedFileSize.Length / decompressedFileSize.Length}");
            }
            else if (args[0] == "-u")
            {
                LzwAlgorithm.Decompress(args[1]);
                Console.WriteLine("Файл был удачно разжат!");
            }
        }
    } 
}
