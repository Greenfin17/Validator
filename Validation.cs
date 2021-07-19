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
        public static bool IsRanger(string rangerName)
        {
            string[] rangerList = new string[]{"Zayto", "Ollie Akana", "Amelia Jones", "Izzy Garcia", "Javi Garcia", "Aiyon"};
            bool returnVal = false;
            for ( int i = 0; i < rangerList.Length; i++ )
            {
                if (rangerList[i].Contains(rangerName))
                {
                    returnVal = true;
                }
            }
            return returnVal;
        }

        private static string removePunctuation(string originalStr)
        {
            string returnStr = string.Empty;
            for (int i = 0; i < originalStr.Length; i++)
            {
                int testChar = (int)originalStr[i];
                if ((testChar >= 65 && testChar <= 90) || (testChar >= 97 && testChar <= 122))
                {
                    returnStr += originalStr[i];
                }
            }
            return returnStr;
        }

        public static bool IsPalindrome(string testStr)
        {
            bool returnVal = true;
            string noPunct = string.Empty;
            noPunct = removePunctuation(testStr);
            noPunct = noPunct.ToLower();
            for (int i = 0, j = noPunct.Length - 1; i < noPunct.Length && j >= i; i++, j--)
            {
                if ( noPunct[i] != noPunct[j])
                {
                    returnVal = false;
                    break;
                }
            }
            return returnVal;
        }
    }
}