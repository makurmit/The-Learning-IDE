using System;

public class HiLow
{
	public static void Main(string[] args)
	{
		bool playing = true;
		Random rand = new Random();
		Console.WriteLine("Hello and welcome to the High-low number guessing game.");

		while (playing)
		{
            int answer = rand.Next(100) + 1;
            bool win = false;
            int numGuesses = 1;

            do
            {
                Console.Write("Guess a number between 1 and 100:");
                int guess;
                int.TryParse(Console.ReadLine(), out guess);

                if (guess == answer)
                {
                    Console.WriteLine($"Congrats you got it in {numGuesses} guesses.");
                    win = true;
                }
                else if(guess < answer)
                {
                    Console.WriteLine("Too low");
                    numGuesses++;
                }
                else if(guess > answer)
                {
                    Console.WriteLine("Too high");
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
		}
	}
}