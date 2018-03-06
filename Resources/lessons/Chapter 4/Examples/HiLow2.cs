using System;

public class HiLow2
    {
        public static void Main(string[] args)
        {
            bool playing = true;
            Random rand = new Random();
            Console.WriteLine("Hello and welcome to the High-low number guessing game.");

            while (playing)
            {
                playing = playLoop(rand);
            }
        }

        public static bool guessLoop(int answer)
        {
            bool win = false;
            Console.Write("Guess a number between 1 and 100:");
            int guess;
            int.TryParse(Console.ReadLine(), out guess);

            if (guess == answer)
            {
                win = true;
            }
            else if (guess < answer)
            {
                Console.WriteLine("Too low");
            }
            else if (guess > answer)
            {
                Console.WriteLine("Too high");
            }
            return win;
        }

        public static bool playLoop(Random rand)
        {
            bool playing = true;
            int answer = rand.Next(100) + 1;
            bool win = false;
            int numGuesses = 1;

            do
            {
                win = guessLoop(answer);
                if (win)
                {
					Console.WriteLine($"Congrats you got it in {numGuesses} guesses.");
                }
				else
				{
					numGuesses++;
				}
            } while (!win);
            Console.WriteLine("Would you like to play again?(y/n)");
            String playAgain = Console.ReadLine();
            if (playAgain.Equals("n"))
            {
                Console.WriteLine("Goodbye");
                playing = false;
            }
            return playing;
        }
    }