using System;
using static ValidationCheck.Validation;

namespace Validator
{
    class Program
    {

        public delegate bool Validation(string input);

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
                Console.WriteLine("  4) Phrase with odd letters lower case, even capitalized");
                Console.WriteLine("Enter 'x' to exit");
                string[] phrase = new string[4]{"pin code", "phone number", "email address",
                                    "phrase"};
                    
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
                    case ('4'):
                        if(!GetInput(phrase[3], EveryOtherCapitalized))
                        {
                            Console.WriteLine("Phrase does not alternate lower and upper case. Please try again.");
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
