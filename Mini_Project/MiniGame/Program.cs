using System;
using System.Collections.Generic;

namespace MiniGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>()
            {
                "CAR","BALL","JAVA","KILLER","DOG","FUN","RADIO","DANCE","STANDING","PHONE","PEN"
            };

            Random r = new Random();
            string word = words[r.Next(words.Count)];

            char[] display = new char[word.Length];
            for (int i = 0; i < display.Length; i++)
                display[i] = '_';

            int chances = 6;
            int remaining = chances;

            HashSet<char> guessed = new HashSet<char>(); 

            while (remaining > 0)
            {
                Console.WriteLine("\nWord: " + new string(display));
                Console.WriteLine("Word Length: " + word.Length);
                Console.WriteLine("Chances left: " + remaining);
                Console.Write("Enter single letter: ");

                Console.Write("\nGuessed Letters: ");
                foreach (char g in guessed)
                    Console.Write(g + " ");
                Console.WriteLine();

                string input = Console.ReadLine().ToUpper();
                char ch = input[0];

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Space not allowed");
                    continue;
                }

                if (!Char.IsLetter(ch))
                {
                    Console.WriteLine("Enter alphabet only");
                    continue;
                }

                if (guessed.Contains(ch))
                {
                    Console.WriteLine("Already guessed");
                    continue;
                }

                guessed.Add(ch);

                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == ch)
                        display[i] = ch;
                }

                if (new string(display) == word)
                {
                    Console.WriteLine("\nYOU WON");
                    break;
                }
                else
                {
                    Console.WriteLine("Try Again");
                }

                remaining--;
            }
        }
    }
}
