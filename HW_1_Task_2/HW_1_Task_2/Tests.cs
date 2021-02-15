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
                return false;
            }
            if (!String.Equals(BWT.Reverse(firstAnswer) + "$", firstCase))
            {
                return false;
            }
            var secondCase = "ANANAS$";
            var secondAnswer = "S$NNAAA";
            if (!String.Equals(BWT.Inverse(secondCase), secondAnswer))
            {
                return false;
            }
            if (!String.Equals(BWT.Reverse(secondAnswer) + "$", secondCase))
            {
                return false;
            }
            var thirdCase = "banana$";
            var thirdAnswer = "annb$aa";
            if (!String.Equals(BWT.Inverse(thirdCase), thirdAnswer))
            {
                return false;
            }
            if (!String.Equals(BWT.Reverse(thirdAnswer) + "$", thirdCase))
            {
                return false;
            }
            return true;
        }
    }
}