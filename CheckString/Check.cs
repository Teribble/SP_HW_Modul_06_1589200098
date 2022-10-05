using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckString
{
    public static class Check
    {
        public static bool IsPolidrom(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

        public static int NumOfOffers(string text)
        {
            var offers = text.Split('.', '?', '!').Where(x=> x != "");

            return offers.Count();
        }

        public static string GetReverse(string word)
        {
            string buffer = string.Empty;

            word.Reverse().ToList().ForEach(x => { buffer += x; });

            return buffer;
        }
    }
}
