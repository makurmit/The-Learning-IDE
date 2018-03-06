import java.util.Random;
import java.util.Scanner;

public class HiLow {
	
	public static void main(String[] args) {
		boolean playing = true;
		Random rand = new Random();
		Scanner scan = new Scanner(System.in);
		System.out.println("Hello and welcome to the High-low number guessing game.");
		
		while (playing) {
			int answer = rand.nextInt(100) + 1;
			boolean win = false;
			int numGuesses = 1;
			
			do {
				System.out.print("Guess a number between 1 and 100:");
				int guess = scan.nextInt();
				
				if (guess == answer) {
					System.out.println("Congrats, you got in " + numGuesses + " guesses.");
					win = true;
				}
				else if (guess < answer) {
					System.out.println("Too low");
					numGuesses++;
				}
				else if (guess > answer) {
					System.out.println("Too high");
					numGuesses++;
				}
			} while (!win);
			System.out.println("Would you like to play again?(y/n)");
			String playAgain = scan.next();
			if (playAgain.equals("n")) {
				scan.close();
				playing = false;
				System.out.println("Goodbye");
			}
		}
	}
}



