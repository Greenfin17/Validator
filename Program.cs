using System;
using System.Text.RegularExpressions;

namespace Validator
{
    class Program
    {
        static bool IsPinCode(string code)
        {
            bool returnVal = true;
            foreach(char item in code)
            {
                if (!char.IsDigit(item))
                {
                    returnVal = false;
                }
            }
            if (!(code.Length >= 4 && code.Length <= 8)) {
                returnVal = false;
            }
            return returnVal;
        }


        static bool IsPhone(string phone)
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
        static bool IsEmail(string email)
        {
            bool returnVal = false;
            email.Trim().ToLower();
            Regex emailRegEx = new Regex(@"^[[a-z.1-9]{1,50}@[a-z1-9]{1,50}[.](com|net|org|edu|mil|gov|edu)$");
            // Regex emailRegEx = new Regex(@"^[a-z.]{1,50}[@][a-z]{1,50}[.][com|org|net|mil|gov|edu");
            if (emailRegEx.IsMatch(email))
            {
                returnVal = true;
            }
            return returnVal;
        }

        public delegate bool Validation(string input);


        static bool GetPin()
        {
            Console.WriteLine("Enter a pin code between 4 and 8 digits, numbers only");
            string pin = Console.ReadLine();
            ConsoleKeyInfo escKey;
            bool invalid = true;
            bool returnVal = false;
            while (invalid)
            {
                if (IsPinCode(pin))
                {
                    Console.WriteLine("Your pin is valid. Thank you");
                    invalid = false;
                    returnVal = true;
                }
                else
                {
                    Console.WriteLine("Invalid pin. Please try again. Hit \"Esc\" to exit pin input");
                    escKey = Console.ReadKey(true);
                    if (escKey.Key == ConsoleKey.Escape)
                    {
                        invalid = false;
                    }
                    else
                    {
                        Console.Write(escKey.KeyChar);
                        pin = Console.ReadLine();
                        pin = pin.Insert(0, escKey.KeyChar.ToString());

                    }
                }
            }
            return returnVal;
        }

        static bool getPhone()
        {
            Console.WriteLine("Enter your phone number:");
            string phone = Console.ReadLine();
            ConsoleKeyInfo escKey;
            bool invalid = true;
            bool returnVal = false;
            while (invalid)
            {
                if (IsPhone(phone))
                {
                    Console.WriteLine("Your phone is valid. Thank you");
                    invalid = false;
                    returnVal = true;
                }
                else
                {
                    Console.WriteLine("Invalid phone. Please try again. Hit \"Esc\" to exit phone input");
                    escKey = Console.ReadKey(true);
                    if (escKey.Key == ConsoleKey.Escape)
                    {
                        invalid = false;
                    }
                    else
                    {
                        Console.Write(escKey.KeyChar);
                        phone = Console.ReadLine();
                        // insert the first character if it was not the Esc key;
                        phone = phone.Insert(0, escKey.KeyChar.ToString());

                    }
                }
            }
            return returnVal;

        }
        static bool GetInput(string phrase, Validation validationFunction)
        {
            Console.WriteLine($"Enter your {phrase}:");
            string input = Console.ReadLine();
            ConsoleKeyInfo escKey;
            bool invalid = true;
            bool returnVal = false;
            while (invalid)
            {
                if (validationFunction(input))
                {
                    Console.WriteLine($"Your {phrase} is valid. Thank you");
                    invalid = false;
                    returnVal = true;
                }
                else
                {
                    Console.WriteLine($"Invalid {phrase}. Please try again. Hit \"Esc\" to exit phone input");
                    escKey = Console.ReadKey(true);
                    if (escKey.Key == ConsoleKey.Escape)
                    {
                        invalid = false;
                    }
                    else
                    {
                        Console.Write(escKey.KeyChar);
                        input = Console.ReadLine();
                        // insert the first character if it was not the Esc key;
                        input = input.Insert(0, escKey.KeyChar.ToString());

                    }
                }
            }
            return returnVal;
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo inputKey = new ConsoleKeyInfo();
            bool exit = false;

            while (!exit) 
            {
                Console.WriteLine("Select validation check:");
                Console.WriteLine("  1) Pin code");
                Console.WriteLine("  2) Phone Number");
                Console.WriteLine("  3) Email");
                Console.WriteLine("Enter 'x' to exit");
                string[] phrase = new string[3]{"pin code", "phone number", "email address"};
                    
                inputKey = Console.ReadKey(true);
                Console.Write('\n');
                switch (inputKey.KeyChar)
                {
                    case ('1'):
                        if (!GetInput(phrase[0], IsPinCode))
                        {
                            Console.WriteLine($"Valid {phrase[0]} not entered. Please try again later.");
                        }
                        break;
                    case ('2'):
                        if (!GetInput(phrase[1], IsPhone))
                        {
                            Console.WriteLine($"Valid {phrase[1]} not entered. Please try again later.");
                        }
                        break;
                    case ('3'):
                        if(!GetInput(phrase[2], IsEmail))
                        {
                            Console.WriteLine($"Valid {phrase[2]} not entered. Please try again later.");
                        }
                        break;
                    case ('x'):
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
