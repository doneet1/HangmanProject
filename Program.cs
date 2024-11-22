using System;
using System.Reflection;
using System.Text;

namespace learning;
class Program
{
    static void Main()
    {
        string[] words = { "test", "dupa", "albinos", "wariat", "typ" };
        string[] hiddenWords = new string[words.Length];
        Array.Copy(words, hiddenWords, words.Length);

        Random randomWord = new();
        int random = randomWord.Next(0, words.Length);

        int health = 7;

        for(int i = 0; i < hiddenWords.Length; i++)
        {
            int len = hiddenWords[i].Length;
            string newString = new string('*', len);
            hiddenWords[i] = newString;
        }

        Console.WriteLine($"Health: {health}");
        Console.WriteLine($"Hidden word = {hiddenWords[random]}");

        while (hiddenWords[random].IndexOf('*') != -1 && health > 0)
        {
            Console.Write("Type a Letter:  ");
            char guess = Console.ReadLine()[0];
            Console.WriteLine("\n\n");
            if (words[random].Contains(guess))
            {
                int count = 0;
                for(int i = 0; i < words[random].Length; i++)
                {
                    if (words[random][i] == guess)
                    {
                        count++;
                    }
                }
                for (int i = 0; i < count; i++)
                {
                    int indexOfGuess = words[random].IndexOf(guess);
                    hiddenWords[random] = hiddenWords[random].Remove(indexOfGuess, 1);
                    hiddenWords[random] = hiddenWords[random].Insert(indexOfGuess, Convert.ToString(guess));
                    words[random] = words[random].Remove(indexOfGuess, 1);
                    words[random] = words[random].Insert(indexOfGuess, "*");
                }
                Console.WriteLine($"Correct guess!\n\n{hiddenWords[random]}\n\n");
            }
            else
            {
                health -= 1;
                Console.WriteLine($"Wrong guess!\n{hiddenWords[random]}\n\n-1 Life!\nYour lives: {health}\n\n");
            }
        }
        if(health > 0)
        {
            Console.WriteLine("You Won!");
        }
        else
        {
            Console.WriteLine("You Lost!");
        }
    }
}