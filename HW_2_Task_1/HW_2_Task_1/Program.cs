using System;
using System.IO;

namespace HW_2_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите полное имя файла: ");
            var name = Console.ReadLine();
            Console.WriteLine("Введите ключ:\n1) '-c', если хотите сжать файл.\n2) '-u', если хотите разжать файл.");
            var key = Console.ReadLine();
            if (key == "-c")
            {
                LzwAlgorithm.Compress(name);
                var compressedFileSize = new FileInfo(name);
                var decompressedFileSize = new FileInfo(name + ".zipped");
                Console.WriteLine("Файл был удачно сжат!");
                Console.WriteLine($"Коэффициент сжатия: x {(double)compressedFileSize.Length / decompressedFileSize.Length}");
            }
            else
            {
                LzwAlgorithm.Decompress(name);
                Console.WriteLine("Файл был удачно разжат!");
            }
        }
    }
}
