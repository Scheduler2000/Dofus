using System;
using System.Globalization;
using System.Text;

namespace Renaissance.Abstract.Extensions
{
    public static class StringExtensions
    {
        public static string ConcatCopy(this string str, int times)
        {
            var builder = new StringBuilder(str.Length * times);

            for (int i = 0; i < times; i++)
                builder.Append(str);

            return builder.ToString();
        }

        public static int CountOccurences(this string str, char chr, int startIndex, int count)
        {
            int occurences = 0;

            for (int i = startIndex; i < startIndex + count; i++)
            {
                if (str[i] == chr)
                    occurences++;
            }

            return occurences;
        }

        public static string GenerateName(this int length)
        {
             string Vowels = "aeiouy";
             string Consonants = "bcdfghjklmnpqrstvwxz";


            var rand = new Random();
            var name = string.Empty;

            var vowel = rand.Next(0, 2) == 0;
            name += vowel ? Vowels[rand.Next(0, Vowels.Length - 1)] : Consonants[rand.Next(0, Consonants.Length - 1)];
            vowel = !vowel;

            for (var i = 0; i < length - 1; i++)
            {
                name += vowel ? Vowels[rand.Next(0, Vowels.Length - 1)] : Consonants[rand.Next(0, Consonants.Length - 1)];
                vowel = !vowel;
            }

            return name;
        }
    }
}
