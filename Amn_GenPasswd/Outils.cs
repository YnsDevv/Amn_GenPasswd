using System;
using System.Text;

namespace Amn_GenPasswd
{
    public class Outils
    {
        private const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string NumericChars = "0123456789";
        private const string SpecialChars = "!@#$%^&*()_+=-{}[]\\|:;\"'<>,.?/";

        private static Random random = new Random();

        public static string[] GeneratePasswords(int count, int length)
        {
            string[] passwords = new string[count];

            for (int i = 0; i < count; i++)
            {
                passwords[i] = GeneratePassword(length);
            }

            return passwords;
        }
        public static string GeneratePassword(int lengt)
        {
            StringBuilder password = new StringBuilder();
            string chars = "";

            if (Amn_GenPasswd.Form1.minuscule)
                chars += LowercaseChars;
            if (Amn_GenPasswd.Form1.majuscule)
                chars += UppercaseChars;
            if (Amn_GenPasswd.Form1.num)
                chars += NumericChars;
            if (Amn_GenPasswd.Form1.special_charactere)
                chars += SpecialChars;

            for (int i = 0; i < lengt; i++)
            {
                password.Append(chars[random.Next(0, chars.Length)]);
            }
            
            return password.ToString();
        }
    }
}