module Cell
	BLANK = "|_|"
	X = "|x|"
	O = "|o|"
end

@board = []

def main()
	playing = true
	puts "Welcome to Tic Tac Toe!"
	
	while playing do
		CreateBoard()

		p1x = WhoGoesFirst()

		PrintBoard()
		
		PlayGame(p1x)
		
		playing = PlayAgain()
	end
end

def CreateBoard()
	@board.clear()
	for i in 0..8 do
		@board.push(Cell::BLANK)
	end
end

def WhoGoesFirst()
	p1x = false
	validInput = false
	
	while (validInput == false) do
		puts "Which token will go first? (x/o)\n"
		answer = gets.chomp()
		if (answer == "x")
			p1x = true
			validInput = true
		elsif (answer == "o")
			p1x = false
			validInput = true
		else
			puts "Please answer x or o."
		end
	end
	
	return p1x
end

def PrintBoard()
	c = Cell::BLANK
	
	for i in (0..8) do
		c = @board[i]

		if (i % 3 == 0 and i != 0)
			puts
		end

		print c
	end
	puts
end

def PlayGame(p1x)
	token = Cell::BLANK
	if (p1x)
		token = Cell::X
	else
		token = Cell::O
	end

	for i in (0..8) do
		PlaceToken(token)
		
		PrintBoard()
		
		if (CheckWin())
			if (token == Cell::X)
				puts "x wins!"
			elsif (token == Cell::O)
				puts "o wins!"
			end
			break
		end
			
		if (CheckDraw())
			puts "It's a draw."
			break
		end
			
		if (token == Cell::X)
			token = Cell::O
		elsif (token == Cell::O)
			token = Cell::X
		end
	end
end
		
def PlaceToken(token)
	place = 0
	placeTaken = true
	
	while (placeTaken) do
		place = GetPlace()
		if (@board[place] != Cell::BLANK)
			puts "Spot taken."
			PrintBoard()
		elsif (@board[place] == Cell::BLANK)
			placeTaken = false
			@board[place] = token
		end
	end
	
end

def GetPlace()
	place = 0
	answer = ""
	validInput = false
	
	while (validInput == false)
		puts "Where would you like to place your token? (1-9)\n"
		answer = gets.chomp()
		
		if (answer.to_i != 0)
			place = answer.to_i
			place -= 1
			if (place >= 9 or place < 0)
				puts "Out of bounds."
				PrintBoard()
			else
				validInput = true
			end
		else
			puts "Please input a number."
			PrintBoard()
		end
				
	end
			
	return place
end
		
def CheckWin()
	win = false
	
	if (winState(0, 1, 2) or winState(3, 4, 5) or winState(6, 7, 8) or winState(0, 3, 6) or winState(1, 4, 7) or winState(2, 5, 8) or winState(0, 4, 8) or winState(2, 4, 6))
		win = true
	end
		
	return win
end

def winState(spot1, spot2, spot3)
	return ((@board[spot1] == Cell::X and @board[spot2] == Cell::X and @board[spot3] == Cell::X) or (@board[spot1] == Cell::O and @board[spot2] == Cell::O and @board[spot3] == Cell::O))
end
		
def CheckDraw()
	return (@board[0] != Cell::BLANK and @board[1] != Cell::BLANK and @board[2] != Cell::BLANK and @board[3] != Cell::BLANK and @board[4] != Cell::BLANK and @board[5] != Cell::BLANK and @board[6] != Cell::BLANK and @board[7] != Cell::BLANK and @board[8] != Cell::BLANK)
end
	
def PlayAgain()
	playAgain = false
	
	puts "Would you like to play again? (y/n)\n"
	answer = gets.chomp
	if (answer == "y")
		playAgain = true
	else
		puts "Goodbye!"
	end
	
	return playAgain
end


main()

