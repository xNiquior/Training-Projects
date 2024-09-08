using System.Runtime.CompilerServices;

namespace CaesarCipher
{
    internal class Program
    {
        public static string DecryptCaesar(in string upperCaseAlphabet, string encryptedMessage, int shift)
        {
            string lowerCaseAlphabet = upperCaseAlphabet.ToLower();

            int len = upperCaseAlphabet.Length;
            shift %= len;

            char[] decryptedMessage = new char[encryptedMessage.Length];

            for (int i = 0; i < decryptedMessage.Length; i++)
            {
                char symbol = encryptedMessage[i];
                
                if (upperCaseAlphabet[0] <= symbol && symbol <= upperCaseAlphabet[len - 1])
                {
                    decryptedMessage[i] = upperCaseAlphabet[(symbol - upperCaseAlphabet[0] + shift) % len];
                }
                else if (lowerCaseAlphabet[0] <= symbol && symbol <= lowerCaseAlphabet[len - 1])
                {
                    decryptedMessage[i] = lowerCaseAlphabet[(symbol - lowerCaseAlphabet[0] + shift) % len];
                }
                else
                {
                    decryptedMessage[i] = symbol;
                }
            }

            return new string(decryptedMessage); ;
        }


        static void Main(string[] args)
        {
            string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string RussianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string[] Alphabets = { EnglishAlphabet, RussianAlphabet };

            string[] EnglishPhrases =
            {
                "> You have chosen Engilsh language!",
                "> Enter the encrypted message: ",
                "> The shift is equal to ",
            };
            string[] RussianPhrases =
            {
                "> Вы выбрали русский язык!",
                "> Введите зашифрованное сообщение: ",
                "> Сдвиг равен ",
            };
            string[][] Phrases = { EnglishPhrases, RussianPhrases, };


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("> Choose your language:\n> 1. English\n> 2. Russian\n");
            Console.ForegroundColor = ConsoleColor.White;


            int choice = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Phrases[choice][0]);

            Console.Write(Phrases[choice][1]);
            Console.ForegroundColor = ConsoleColor.White;

            string encryptedMessage = Console.ReadLine();
            Console.WriteLine();

            for (int i = 1; i < RussianAlphabet.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Phrases[choice][2] + i + ".\n");

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(DecryptCaesar(Alphabets[choice], encryptedMessage, i));

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n==========================================================================================================================================================\n");
            }
        }
    }
}
