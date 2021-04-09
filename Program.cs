using System;

namespace UMT_strong_password_checker
{
    class Program
    {
        public static void Main(string[] args)
        {
            int minLength = 6, maxLength = 20;

            // The strings for input uppercarse, lowercase, digits and special chars
            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowercase = "abcdefghijklmnopqrstuvwxyz";

            string digits = "0123456789";
            string specialChars = "#?!,-'/`_*$@%&*=+";
          

            string errorMessage = "";

                                  
            Console.WriteLine("Enter password:");

            // Input password from keyboard (string s for password)
            string s = Console.ReadLine();

            // Print the password
            Console.WriteLine("\nYour password is: " + s +  "\n");

            int score = 0;

            // Conditions for a strong password
            
            // 1 - length of password
            if (s.Length >= minLength && s.Length <= maxLength)   // between 6 and 20
            {
                score++;
                //Console.WriteLine("Your password has at least 6 characters and at most 20 characters! Perfect!");
            }
            else if (s.Length < minLength)
            {     
                errorMessage = errorMessage + " You need to add " + (minLength - s.Length) + " more characters. It is too short.\n ";
            }

            else if (s.Length > maxLength)
            {
                errorMessage = errorMessage + " You need to remove " + (s.Length - maxLength) + " characters. It is too long.\n ";
            }

            // 2 - if password containts uppercase letters
            if (Contains(s, uppercase))
            {
                score++;
                //Console.WriteLine("You have used Uppercase Letters. Perfect!");
            }
            else
            {
                errorMessage = errorMessage + "You need to add at least 1 uppercase letter.\n ";
            }

            // 3 - if password containts lowercase letters
            if (Contains(s, lowercase))
            {
                score++;
                //Console.WriteLine("You have used Lowercase Letters. Perfect!");
            }
            else
            {
                errorMessage = errorMessage + "You need to add at least 1 lowercase letter.\n ";
            }

            // 4 - if password containts digits
            if (Contains(s, digits))
            {
                score++;
                //Console.WriteLine("You have used Digits. Perfect!");
            }
            else
            {
                errorMessage = errorMessage + "You need to add at least 1 digit.\n ";
            }

            // 5 - if password containts special chars
            if (Contains(s, specialChars))
            {
                score++;
                //Console.WriteLine("You have used Special Chars. Perfect!");
            }
            else
            {
                errorMessage = errorMessage + "You need to add at least 1 special char.\n ";
            }

            // 6 if password do not contains three repeating characters in a row
            int aux = s[0];
            int characterRepeated = 1;

            for(int i = 1; i < s.Length; i++)
            {
                if (aux == s[i])  
                    characterRepeated++;
                else
                    characterRepeated = 1;

                aux = s[i];

                if (characterRepeated == 3)
                {
                    score = 0;
                    Console.WriteLine("\n Your password MUST NOT contain three repeating character in a row. Try again!");
                    break;
                }

            }

            Console.WriteLine(errorMessage);

            switch (score) {
                
                case 5:
                    Console.WriteLine("\nCongratulations! Your password '"+ s +"' is very strong. Welcome!");
                    break;

                default:
                    Console.WriteLine("\nYour password '" + s + "' is NOT allowed on this site because you do not perform all conditions!");
                    break;

            }

            Console.ReadLine();
        }

        public static bool Contains(string target, string list)
        {
            return target.IndexOfAny(list.ToCharArray()) != -1;
        }      
    }
}