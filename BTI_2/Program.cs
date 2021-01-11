using System;

namespace BTI_2
{
    class Program
    {
        
        private static string Cipher(string input, string key, bool encipher)
        {
            for (int i = 0; i < key.Length; ++i)
                if (!char.IsLetter(key[i]))
                    return null;

            string output = string.Empty;
            int nonAlphaCharCount = 0;

            for (int i = 0; i < input.Length; ++i)
            {
                if (char.IsLetter(input[i]))
                {
                    bool cIsUpper = char.IsUpper(input[i]);
                    char offset = cIsUpper ? 'A' : 'a';
                    int keyIndex = (i - nonAlphaCharCount) % key.Length;
                    int k = (cIsUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex])) - offset;
                    k = encipher ? k : -k;
                    char ch = (char)((Mod(((input[i] + k) - offset), 26)) + offset);
                    output += ch;
                }
                else
                {
                    output += input[i];
                    ++nonAlphaCharCount;
                }
            }
            return output;
        }
        private static int Mod(int a, int b)
        {
            return (a % b + b) % b;
        }

        public static string Encipher(string input, string key)
        {
            return Cipher(input, key, true);
        }
        public static string Decipher(string input, string key)
        {
            return Cipher(input, key, false);
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Wprowadź tekst/słowo do zaszyfrowania: ");
                string text = Console.ReadLine();
                Console.Write("Wprowadź klucz szyfrujący: ");
                string key = Console.ReadLine();
                string enciphered = Encipher(text, key);
                string deciphered = Decipher(enciphered, key);
                Console.WriteLine("\n------------------------------------------\n");
                Console.WriteLine("Zaszyfrowane tekst/słowo: {0}", enciphered);
                Console.WriteLine("Odszyfrowane tekst/słowo: {0}", deciphered);
                Console.WriteLine("\n------------------------------------------\n");
            }
        }
        
    }
}