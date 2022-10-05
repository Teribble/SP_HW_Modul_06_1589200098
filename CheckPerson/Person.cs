using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CheckPerson
{
    public static class Person
    {
        public static bool IsLetters(string word)
        {
            return Regex.IsMatch(word, @"^[a-zA-Zа-яА-Я]+$");
        }

        public static bool IsDigit(string word)
        {
            return Regex.IsMatch(word, @"^[0-9]+$");
        }

        /// <summary>
        /// Проверка номера на формат 456-456-4564
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool IsPhoneNum(string word)
        {
            return Regex.IsMatch(word, "[0-9]{3}-[0-9]{3}-[0-9]{4}");
        }

        public static bool IsEmail(string word)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(word, emailPattern);
        }
    }
}