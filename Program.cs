using System;
using System.IO;
using System.Collections.Generic;

namespace seanCaesar
{
    class Program
    {
        static string Encrypt(string plaintext, int shiftkey)
        {
            List<char> letters = new List<char>();
            foreach (char i in plaintext)
            {
                letters.Add(i);
            }
            for (int i = 0; i < letters.Count; i++)
            {
                if (letters[i] != ' ' & Char.IsLetter(letters[i]))
                {
                    if ((int)letters[i] + shiftkey >= 123 || (int)letters[i] + shiftkey >= 91 & (int)letters[i] <= 90)
                    {
                        letters[i] = (char)((int)letters[i] + shiftkey - 26);
                    }
                    else letters[i] = (char)((int)letters[i] + shiftkey);
                }
            }
            return string.Join("", letters);
        }
        static string Decrypt(string cyphertext, int shiftkey)
        {
            List<char> letters = new List<char>();
            foreach (char i in cyphertext)
            {
                letters.Add(i);
            }
            for (int i = 0; i < letters.Count; i++)
            {
                if (letters[i] != ' ' & Char.IsLetter(letters[i]))
                {
                    if ((int)letters[i] - shiftkey <= 64 || (int)letters[i] - shiftkey <= 96 & (int)letters[i] >= 97)
                    {
                        letters[i] = (char)((int)letters[i] - shiftkey + 26);
                    }
                    else letters[i] = (char)((int)letters[i] - shiftkey);
                }

            }
            return string.Join("", letters);
        }


        static void encrypttext(string file, int key)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                string line = sr.ReadToEnd();
                string encrypted = Encrypt(line, key);
                Console.WriteLine(encrypted);
                StreamWriter fileStr = File.CreateText("encrypted.txt");
                fileStr.WriteLine(encrypted);
                fileStr.Close();
            }
        }
        static void decrypttext(string file, int key)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                string line = sr.ReadToEnd();
                string decrypted = Decrypt(line, key);
                Console.WriteLine(decrypted);
                StreamWriter fileStr = File.CreateText("decrypted.txt");
                fileStr.WriteLine(decrypted);
                fileStr.Close();
            }
        }
        static void Main(string[] args)
        {
            //decrypttext("ciphertext.txt", 8);
            decrypttext(args[0], Int32.Parse(args[1]));

        }
    }
}