using System;
using System.Collections.Generic;

namespace HW_2_Task_2
{
    class Test
    {
        public static bool Tests()
        {
            var calculators = new List<Calculator>();
            calculators.Add(new Calculator(new ListStack()));
            calculators.Add(new Calculator(new ListStack()));
            foreach (var element in calculators)
            {
                var firstLine = "1 2 +";
                var firstResult = 3d;
                if (Math.Abs(element.GetResult(firstLine) - firstResult) > 10e-6)
                {
                    return false;
                }
                var secondLine = "3 5 + 2 * 6 7 + 8 9 - / -";
                var secondResult = 29d;
                if (Math.Abs(element.GetResult(secondLine) - secondResult) > 10e-6)
                {
                    return false;
                }
                var thirdLine = "6 10 + 4 - 1 2 2 * + / 1 +";
                var thirdResult = 3.4d;
                if (Math.Abs(element.GetResult(thirdLine) - thirdResult) > 10e-6)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
