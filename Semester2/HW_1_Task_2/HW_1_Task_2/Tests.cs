using System;

namespace HW_1_Task_2
{
    class Tests
    {
        public static bool Test()
        {
            var firstCase = "KAPKAPKAP$";
            var firstAnswer = "PKKKPP$AAA";
            if (!String.Equals(BWT.Direct(firstCase), firstAnswer))
            {
                return false;
            }
            if (!String.Equals(BWT.Inverse(firstAnswer) + "$", firstCase))
            {
                return false;
            }
            var secondCase = "ANANAS$";
            var secondAnswer = "S$NNAAA";
            if (!String.Equals(BWT.Direct(secondCase), secondAnswer))
            {
                return false;
            }
            if (!String.Equals(BWT.Inverse(secondAnswer) + "$", secondCase))
            {
                return false;
            }
            var thirdCase = "banana$";
            var thirdAnswer = "annb$aa";
            if (!String.Equals(BWT.Direct(thirdCase), thirdAnswer))
            {
                return false;
            }
            if (!String.Equals(BWT.Inverse(thirdAnswer) + "$", thirdCase))
            {
                return false;
            }
            return true;
        }
    }
}