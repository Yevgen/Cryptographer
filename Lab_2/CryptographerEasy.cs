using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class CryptographerEasy
    {

        private string Encryptions(string text, int key)
        {
            //32 - 122
            string result = "";
            //string lowerText = text.ToLower();
            foreach (var letter in text)
            {
                if (Char.IsLower(letter))
                    result += EncryptionsLetter(letter, key, 'a', 'z');
                else if (Char.IsUpper(letter))
                    result += EncryptionsLetter(letter, key, 'A', 'Z');
                else
                    result += letter;
            }

            return result;
        }
        private string Decryptions(string text, int key)
        {
            string result = "";

            foreach (var letter in text)
            {
                if (Char.IsLower(letter))
                    result += DecryptionsLetter(letter, key, 'a', 'z');
                else if (Char.IsUpper(letter))
                    result += DecryptionsLetter(letter, key, 'A', 'Z');
                else result += letter;
            }

            return result;
        }

        private char EncryptionsLetter(char letter, int key, int left, int right)
        {
            int lenght = right - left + 1;
            char result;

            int code = (int)letter - left;

            code += key;
            code = code % lenght;
            code += left;

            result = (char)code;

            return result;
        }
        private char DecryptionsLetter(char letter, int key, int left, int right)
        {
            int lenght = right - left + 1;

            char result;

            int code = (int)letter - left;
            code -= key;
            if (code < 0)
            {
                code = lenght + code;
            }
            code = code % lenght;
            code += left;
            result = (char)code;

            return result;
        }
    }
}
