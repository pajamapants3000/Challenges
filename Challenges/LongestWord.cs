using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class LongestWord
    {
        string sen;

        public LongestWord(string sen)
        {
            this.sen = sen;

            string[] words = sen.Split(" ");
        }

        public string GetResult()
        {

            string result = "";
            string[] words = sen.Split(" ");

            foreach (string word in words)
            {
                string trimmedWord = TrimPunctuation(word);
                if (trimmedWord.Length > result.Length)
                {
                    result = trimmedWord;
                }
            }

            return result;
        }

        private static string TrimPunctuation(string possiblyPunctuatedString)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < possiblyPunctuatedString.Length; i++)
            {
                if (char.IsPunctuation(possiblyPunctuatedString[i]))
                {
                    break;
                }

                result.Append(possiblyPunctuatedString[i]);
            }

            return result.ToString();
        }
    }
}
