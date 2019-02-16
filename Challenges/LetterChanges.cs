using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class LetterChanges
    {
        string str;

        public LetterChanges(string str)
        {
            this.str = str;
        }

        public string GetResult()
        {
            StringBuilder tempResult = new StringBuilder();
            StringBuilder result = new StringBuilder();

            foreach (char c in str)
            {
                tempResult.Append(NextInAlphabet(c));
            }

            foreach (char c in tempResult.ToString())
            {
                if (IsVowel(c))
                {
                    result.Append(Char.ToUpper(c));
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        private static bool IsVowel(char c)
        {
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
            {
                return true;
            }

            return false;
        }

        private static char NextInAlphabet(char c)
        {
            if (Char.IsLetter(c))
            {
                if (c == 'z')
                {
                    return 'a';
                }
                else if (c == 'Z')
                {
                    return 'A';
                }
                else
                {
                    int cInt = (int)c;
                    return (char)(cInt + 1);
                }
            }

            return c;
        }
    }
}
