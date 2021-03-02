using System;
using System.Collections.Generic;
using System.Text;

namespace HW_2_Task_1
{
    interface ILzwAlgorithm
    {
        void Compress(string inputLine);

        void Decompress(string outputLine);
    }
}
