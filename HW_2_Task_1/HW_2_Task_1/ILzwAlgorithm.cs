using System;
using System.Collections.Generic;
using System.Text;

namespace HW_2_Task_1
{
    interface ILzwAlgorithm
    {
        /*bool Compress(string pInputFileName, string pOutputFileName);
        bool Decompress(string pInputFileName, string pOutputFileName);*/

        void Compress(string inputLine);
        string Decompress(string outputLine);
    }
}
