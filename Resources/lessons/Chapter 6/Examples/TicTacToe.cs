using System;

enum Cell
{
    blank,
    x,
    o
}


class Program
{

    private static Cell[] board = new Cell[9];

    public static void Main(string[] args)
	{
        Console.WriteLine("Welcome to Tic Tac Toe!");

        do
        {
            CreateBoard();

            bool p1x = WhoGoesFirst();

            PrintBoard();

            PlayGame(p1x);

        } while (PlayAgain());
    }

    private static void CreateBoard()
    {
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = Cell.blank;
        }
    }

    private static void PrintBoard()
    {

        Cell c;

        for (int i = 0; i < board.Length; i++)
        {
            c = board[i];

            if (i % 3 == 0 && i != 0)
            {
                Console.WriteLine("");
            }

            switch (c)
            {
                case Cell.blank:
                    Console.Write("|_|");
                    break;
                case Cell.x:
                    Console.Write("|x|");
                    break;
                case Cell.o:
                    Console.Write("|o|");
                    break;
            }
        }

        Console.WriteLine();
    }

    private static bool WhoGoesFirst()
    {
        bool validInput = false;
        bool p1x = false;

        Console.WriteLine("Which token will go first? (x/o)");

        do
        {
            String answer = Console.ReadLine();
            if (answer.Equals("x"))
            {
                p1x = true;
                validInput = true;
            }
            else if (answer.Equals("o"))
            {
                p1x = false;
                validInput = true;
            }
            else
            {
                Console.WriteLine("Please answer x or o.");
            }
        } while (!validInput);

        return p1x;
    }

    private static void PlayGame(bool p1x)
    {
        Cell token;
        if (p1x)
        {
            token = Cell.x;
        }
        else
        {
            token = Cell.o;
        }

        for (int i = 0; i < 9; i++)
        {
            PlaceToken(token);

            PrintBoard();

            if (CheckWin())
            {
                i = 9;
                if (token == Cell.x)
                {
                    Console.WriteLine("x wins!");
                }
                else if (token == Cell.o)
                {
                    Console.WriteLine("o wins!");
                }
            }

            if (CheckDraw())
            {
                i = 9;
                Console.WriteLine("It's a draw.");
            }

            if (token == Cell.x)
            {
                token = Cell.o;
            }
            else if (token == Cell.o)
            {
                token = Cell.x;
            }
        }


    }

    private static void PlaceToken(Cell token)
    {
        int place = 0;

        do
        {
            place = GetPlace();
            if (board[place] != Cell.blank)
            {
                Console.WriteLine("Spot taken.");
                PrintBoard();
            }
        } while (board[place] != Cell.blank);

        board[place] = token;
    }

    private static int GetPlace()
    {
        int place = 0;
        String answer = "";
        bool validInput = false;

        do
        {
            Console.WriteLine("Where would you like to place your token? (1-9)");
            answer = Console.ReadLine();
            try
            {
                place = int.Parse(answer);
                place--;
                if (place >= board.Length || place < 0)
                {
                    Console.WriteLine("Out of bounds.");
                    PrintBoard();
                }
                else
                {
                    validInput = true;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please input a number.");
                PrintBoard();
            }
        } while (!validInput);
        return place;
    }

    private static bool CheckWin()
    {
        bool win = false;

        if (winState(0, 1, 2) || winState(3, 4, 5) || winState(6, 7, 8) || winState(0, 3, 6) || winState(1, 4, 7) || winState(2, 5, 8) || winState(0, 4, 8) || winState(2, 4, 6))
        {
            win = true;
        }

        return win;
    }

    private static bool winState(int spot1, int spot2, int spot3)
    {
        return ((board[spot1] == Cell.x && board[spot2] == Cell.x && board[spot3] == Cell.x) || (board[spot1] == Cell.o && board[spot2] == Cell.o && board[spot3] == Cell.o));
    }

    private static bool CheckDraw()
    {
        return (board[0] != Cell.blank && board[1] != Cell.blank && board[2] != Cell.blank && board[3] != Cell.blank && board[4] != Cell.blank && board[5] != Cell.blank && board[6] != Cell.blank && board[7] != Cell.blank && board[8] != Cell.blank);
    }

    private static bool PlayAgain()
    {
        bool playAgain = false;

        Console.WriteLine("Would you like to play again? (y/n)");
        String answer = Console.ReadLine();
        if (answer.Equals("y"))
        {
            playAgain = true;
        }
        else
        {
            Console.WriteLine("Goodbye!");
        }

        return playAgain;
    }


}


