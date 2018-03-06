import java.util.Scanner;

public class TicTacToe
{
	
	private static Cell[] board = new Cell[9];
	
	private static Scanner scan = new Scanner(System.in);
	
	public static void main(String[] args){
		System.out.println("Welcome to Tic Tac Toe!");
		
		do {
			CreateBoard();
			
			boolean p1x = WhoGoesFirst();
			
			PrintBoard();
			
			PlayGame(p1x);
		
		} while (PlayAgain());
	}
	
	private static void CreateBoard(){
		for (int i = 0; i < board.length; i++) {
			board[i] = Cell.blank;
		}
	}
	
	private static void PrintBoard(){
		
		Cell c;
		
		for (int i = 0; i < board.length; i++) {
			c = board[i];
			
			if (i % 3 == 0 && i != 0){
				System.out.println("");
			}
			
			switch (c)
			{
				case blank:
					System.out.print("|_|");
					break;
				case x:
					System.out.print("|x|");
					break;
				case o:
					System.out.print("|o|");
					break;
			}
		}
		
		System.out.println();
	}

	private static boolean WhoGoesFirst(){
		boolean validInput = false;
		boolean p1x = false;
		
		System.out.println("Which token will go first? (x/o)");

		do {			
			String answer = scan.nextLine();
			if (answer.equalsIgnoreCase("x")){
				p1x = true;
				validInput = true;
			} else if (answer.equalsIgnoreCase("o")){
				p1x = false;
				validInput = true;
			} else {
				System.out.println("Please answer x or o.");
			}
		} while(!validInput);
		
		return p1x;
	}
	
	private static void PlayGame(boolean p1x){
		Cell token;
		if (p1x){
			token = Cell.x;
		} else {
			token = Cell.o;
		}
		
		for (int i = 0; i < 9; i++){
			PlaceToken(token);
			
			PrintBoard();
			
			if (CheckWin()){
				i = 9;
				if (token == Cell.x){
					System.out.println("x wins!");
				} else if (token == Cell.o){
					System.out.println("o wins!");
				}
			}
			
			if (CheckDraw()){
				i = 9;
				System.out.println("It's a draw.");
			}
			
			if (token == Cell.x){
				token = Cell.o;
			} else if (token == Cell.o){
				token = Cell.x;
			}
		}
		
		
	}
	
	private static void PlaceToken(Cell token){
		int place = 0;
		
		do {
			place = GetPlace();
			if (board[place] != Cell.blank){
				System.out.println("Spot taken.");
				PrintBoard();
			}
		} while (board[place] != Cell.blank);
		
		board[place] = token;
	}
	
	private static int GetPlace(){
		int place = 0;
		String answer = "";
		boolean validInput = false;
				
		do {
			System.out.println("Where would you like to place your token? (1-9)");
			answer = scan.nextLine();
			try{
				place = Integer.parseInt(answer);
				place--;
				if (place >= board.length || place < 0){
					System.out.println("Out of bounds.");
					PrintBoard();
				} else {
					validInput = true;
				}
			} catch (NumberFormatException e){
				System.out.println("Please input a number.");
				PrintBoard();
			}
		} while (!validInput);
		return place;
	}
		
	private static boolean CheckWin(){
		boolean win = false;
		
		if(winState(0, 1, 2) || winState(3, 4, 5) || winState(6, 7, 8) || winState(0, 3, 6) || winState(1, 4, 7) || winState(2, 5, 8) || winState(0, 4, 8) || winState(2, 4, 6)){
			win = true;
		}
		
		return win;
	}
	
	private static boolean winState(int spot1, int spot2, int spot3){
		return ((board[spot1] == Cell.x && board[spot2] == Cell.x && board[spot3] == Cell.x) || (board[spot1] == Cell.o && board[spot2] == Cell.o && board[spot3] == Cell.o));
	}
		
	private static boolean CheckDraw(){
		return (board[0] != Cell.blank && board[1] != Cell.blank && board[2] != Cell.blank && board[3] != Cell.blank && board[4] != Cell.blank && board[5] != Cell.blank && board[6] != Cell.blank && board[7] != Cell.blank && board[8] != Cell.blank);
	}

	private static boolean PlayAgain(){
		boolean playAgain = false;
		
		System.out.println("Would you like to play again? (y/n)");
		String answer = scan.nextLine();
		if (answer.equalsIgnoreCase("y")){
			playAgain = true;
		} else {
			System.out.println("Goodbye!");
		}
			
		return playAgain;
	}
	
}


