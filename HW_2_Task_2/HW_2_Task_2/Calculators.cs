using System;
using System.Collections.Generic;
using System.Text;

namespace HW_2_Task_2
{
    interface ICalculator
    {
        double GetResult(string[] inputLine);
    }
    class FirstCalculator : ICalculator
    {

        public double GetResult(string[] inputLine)
        {
            var array = new int[inputLine.Length];

            int top = -1;

            int x;
            int res = 0;
            for (int i = 0; i < inputLine.Length; i++)
            {
                if (int.TryParse(inputLine[i], out x))
                {
                    top++;
                    array[top] = x;
                }
                else
                {
                    switch (inputLine[i])
                    {
                        case "+":
                            res = array[top - 1] + array[top];
                            break;
                        case "-":
                            res = array[top - 1] - array[top];
                            break;
                        case "*":
                            res = array[top - 1] * array[top];
                            break;
                        case "/":
                            res = array[top - 1] / array[top];
                            break;
                    }
                    top--;
                    array[top] = res;
                }
            }

            return array[top];
        }
    }
    /*class SecondCalculator : ICalculator
    {
        public SecondCalculator(string line)
        {
            var inputLine = line;
        }
        public string GetLine => throw new NotImplementedException();

        public double GetResult()
        {
            throw new NotImplementedException();
        }
    }*/
}
