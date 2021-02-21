using System;

namespace HW_2_Task_2
{
    class Test
    {
        public static bool Tests()
        {
            var firstCalc = new Calculator(new ArrayCalc());
            var secondCalc = new Calculator(new ListCalc());
            var firstLine = "1 2 +".Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var firstResult = 3d;
            if (!Double.Equals(firstCalc.GetResult(firstLine), firstResult))
            {
                return false;
            }
            if (!Double.Equals(secondCalc.GetResult(firstLine), firstResult))
            {
                return false;
            }
            var secondLine = "3 5 + 2 * 6 7 + 8 9 - / -".Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var secondResult = 29d;
            if (!Double.Equals(firstCalc.GetResult(secondLine), secondResult))
            {
                return false;
            }
            if (!Double.Equals(secondCalc.GetResult(secondLine), secondResult))
            {
                return false;
            }
            var thirdLine = "6 10 + 4 - 1 2 2 * + / 1 +".Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var thirdResult = 3.4d;
            if (!Double.Equals(firstCalc.GetResult(thirdLine), thirdResult))
            {
                return false;
            }
            if (!Double.Equals(secondCalc.GetResult(thirdLine), thirdResult))
            {
                return false;
            }
            return true;
        }
    }
}
