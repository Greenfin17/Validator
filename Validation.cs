using System;
using System.Text.RegularExpressions;


namespace ValidationCheck
{
    public class Validation
    {
        public static bool IsPinCode(string code)
        {
            bool returnVal = true;
            foreach (char item in code)
            {
                if (!char.IsDigit(item))
                {
                    returnVal = false;
                }
            }
            if (!(code.Length >= 4 && code.Length <= 8))
            {
                returnVal = false;
            }
            return returnVal;
        }
        public static bool IsPhone(string phone)
        {
            bool returnVal = false;
            Regex phoneRegEx = new Regex(@"^\(?[0-9]{3}\)?[- .]?[0-9]{3}[- .]?([0-9]{4})$");
            Regex phone555Check = new Regex(@"^\(?[555]\)?");
            if (phoneRegEx.IsMatch(phone))
            {
                returnVal = true;
            }
            if (phone555Check.IsMatch(phone))
            {
                returnVal = false;
            }
            return returnVal;
        }
        public static bool IsEmail(string email)
        {
            bool returnVal = false;
            email = email.Trim().ToLower();
            Regex emailRegEx = new Regex(@"^[[a-z.1-9]{1,50}@[a-z1-9]{1,50}[.](com|net|org|edu|mil|gov|edu)$");
            if (emailRegEx.IsMatch(email))
            {
                returnVal = true;
            }
            return returnVal;
        }

        public static bool EveryOtherCapitalized(string testString)
        {
            bool returnVal = true;
            bool cont = true;
            testString = testString.Trim();
            char[] trimChars = { '!' };
            testString = testString.TrimEnd(trimChars);
            int index = 0;

            foreach (char character in testString)
            {
                if (!Char.IsWhiteSpace(character) && (index == 0 || index % 2 == 0))
                {
                    if (!Char.IsLower(character))
                    {
                        cont = false;
                        returnVal = false;
                    }
                }
                else if (!Char.IsWhiteSpace(character) && Char.IsLower(character))
                {
                    cont = false;
                    returnVal = false;
                }
                if (!cont)
                {
                    break;
                }
                // Don't count whitespaces
                if (!Char.IsWhiteSpace(character))
                {
                    index++;
                }
            }
            return returnVal;
        }
    }
}