using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Cryptographer
    {
        List<char> alphabetEng;
        List<char> alphabetEngUpper;
        List<char> alphabetUkr;
        List<char> alphabetUkrUpper;
        public Cryptographer()
        {
            alphabetEng = getAlphabetEng(true);
            alphabetEngUpper = getAlphabetEng(false);
            alphabetUkr = getAlphabetUkr(true);
            alphabetUkrUpper = getAlphabetUkr(false);
        }
        public string Encryptions(string text, string key)
        {
            string result = "";
            int n = 0;
            foreach (var symbol in text)
            {
                var alphabet = getAppropriateAlphabet(symbol);
                if (alphabet != null)
                    result += EncryptionsLetterA(symbol, getKey(key, n), alphabet);
                else
                    result += symbol;
                n++;
            }
            return result;
        }
        public string Decryptions(string text, string key)
        {
            string result = "";
            int n = 0;
            foreach (var symbol in text)
            {
                var alphabet = getAppropriateAlphabet(symbol);
                if (alphabet != null)
                    result += DecryptionsLetterA(symbol, getKey(key, n), alphabet);
                else
                    result += symbol;
                n++;
            }
            return result;
        }
        private List<char> getAlphabetEng(bool lower)
        {
            List<char> result = new List<char>();
            if (lower)
                for (int i = 'a'; i <= 'z'; i++)
                    result.Add((char)i);
            else
                for (int i = 'A'; i <= 'Z'; i++)
                    result.Add((char)i);

            return result;
        }
        private List<char> getAlphabetUkr(bool lower)
        {
            List<char> result = new List<char>();
            char left, right, v1, v2, v3, e, ye, u, i, yi;
            if (lower)
            {
                left = 'а'; right = 'я';
                v1 = 'ъ'; v2 = 'ы'; v3 = 'э';
                e = 'е'; ye = 'є'; u = 'и'; i = 'і'; yi = 'ї';
            }
            else
            {
                left = 'А'; right = 'Я';
                v1 = 'Ъ'; v2 = 'Ы'; v3 = 'Э';
                e = 'Е'; ye = 'Є'; u = 'И'; i = 'І'; yi = 'Ї';
            }

            for (int w = left; w <= right; w++)
            {
                if (w != v1 && w != v2 && w != v3)
                {
                    result.Add((char)w);
                    if (w == e)
                    {
                        result.Add(ye);
                    }
                    else if (w == u)
                    {
                        result.Add(i);
                        result.Add(yi);
                    }
                }
            }
            return result;
        }
        private List<char> getAppropriateAlphabet(char symbol)
        {
            List<char> result = null;
            List<char>[] arrAlpabets = new List<char>[4] { alphabetEng, alphabetEngUpper, alphabetUkr, alphabetUkrUpper };
            foreach (var temp in arrAlpabets)
            {
                if (temp.Contains(symbol))
                    result = temp;
            }

            return result;
        }


        private int getKey(string key, int n)
        {
            int result = 0;
            char symbol = key[n % key.Count()];
            if (Char.IsLetterOrDigit(symbol))
            {
                var alphabet = getAppropriateAlphabet(symbol);
                if (alphabet == null)
                {
                    result = Convert.ToInt32(symbol);
                }
                else
                {
                    result = alphabet.IndexOf(symbol);
                }
            }

            return result;
        }

        private char EncryptionsLetterA(char symbol, int key, List<char> alphabet)
        {
            char result = '0'; ;
            int code = alphabet.IndexOf(symbol);
            code = (code + key) % alphabet.Count;
            result = alphabet[code];
            return result;
        }
        private char DecryptionsLetterA(char symbol, int key, List<char> alphabet)
        {
            char result = '0'; ;
            int code = alphabet.IndexOf(symbol);
            code = code - key;
            if (code < 0)
                code = alphabet.Count + code;
            result = alphabet[code];
            return result;
        }
    }
}
