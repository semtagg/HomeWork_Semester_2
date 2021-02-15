using System;

namespace HW_1_Task_2
{
    class Tests
    {
        public static bool Test()
        {
            var firstCase = "KAPKAPKAP$";
            var firstAnswer = "PKKKPP$AAA";
            if (!String.Equals(BWT.Inverse(firstCase), firstAnswer))
            {
                Console.WriteLine(1);
                return false;
            }
            if (!String.Equals(BWT.Reverse(firstAnswer) + "$", firstCase))
            {
                Console.WriteLine(BWT.Reverse(firstAnswer));
                return false;
            }
            var secondCase = "ANANAS$";
            var secondAnswer = "S$NNAAA";
            if (!String.Equals(BWT.Inverse(secondCase), secondAnswer))
            {
                Console.WriteLine(3);
                return false;
            }
            if (!String.Equals(BWT.Reverse(secondAnswer) + "$", secondCase))
            {
                Console.WriteLine(4);
                return false;
            }
            var thirdCase = "banana$";
            var thirdAnswer = "annb$aa";
            if (!String.Equals(BWT.Inverse(thirdCase), thirdAnswer))
            {
                Console.WriteLine(5);
                return false;
            }
            if (!String.Equals(BWT.Reverse(thirdAnswer) + "$", thirdCase))
            {
                Console.WriteLine(6);
                return false;
            }
            return true;
        }
    }
}