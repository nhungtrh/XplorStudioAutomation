using System;
using System.Collections.Generic;


namespace WebRegression.Utilities
{
    public class RandomDataGenerator
    {
        static string lowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
        static string upperCaseLetters = lowerCaseLetters.ToUpper();
        static string numericChars = "0123456789";
        static Random randomizer = new Random();

        public string GenerateRandomString(int length, char[] possibleChars)
        {
            List<char> outputChars = new List<char> { };
            for (int i = 0; i < length; i++)
            {
                int index = randomizer.Next(possibleChars.Length);
                outputChars.Add(possibleChars[index]);
            }
            return string.Join("", outputChars.ToArray());
        }
        public string GetLowercaseString(int length)
        {
            char[] lowerCaseChars = lowerCaseLetters.ToCharArray();
            return GenerateRandomString(length, lowerCaseChars);
        }
        public string GetUpperCaseString(int length)
        {
            char[] upperCaseChars = upperCaseLetters.ToCharArray();
            return GenerateRandomString(length, upperCaseChars);
        }
        public string GetMixCaseAlphabeticString(int length)
        {
            char[] inputChars = (lowerCaseLetters + upperCaseLetters).ToCharArray();
            return GenerateRandomString(length, inputChars);
        }

        public string GetLettersDigitsString(int length)
        {
            char[] inputChars = (lowerCaseLetters + upperCaseLetters + numericChars).ToCharArray();
            return GenerateRandomString(length, inputChars);
        }

        public string GetDigitString(int length)
        {
            char[] digitChars = numericChars.ToCharArray();
            return GenerateRandomString(length, digitChars);
        }

        public bool GetRandomBool()
        {
            bool[] choises = { false, true };
            return choises[randomizer.Next(2)];
        }

        public string GenerateRandomEmailAddress()
        {

            string emailAddress = GetMixCaseAlphabeticString(6) + "@gmail.com";
            return emailAddress;
        }

        public string PinGenerator(int digits)
        {
            if (digits <= 1) return "";

            var _min = (int)Math.Pow(10, digits - 1);
            var _max = (int)Math.Pow(10, digits) - 1;
            return randomizer.Next(_min, _max).ToString();
        }

        public double NextRandomRange(double minimum, double maximum)
        {
            Random rand = new Random();
            return rand.NextDouble() * (maximum - minimum) + minimum;
        }

    }
}