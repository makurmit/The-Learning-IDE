from enum import Enum

board = []

Cell = Enum("Cell", "blank x o")

def main():
	playing = True
	print("Welcome to Tic Tac Toe!")

	while playing:
		CreateBoard()

		p1x = WhoGoesFirst()

		PrintBoard()

		PlayGame(p1x)
		
		playing = PlayAgain()

def CreateBoard():
	board.clear()
	for i in range (0, 9):
		board.append(Cell.blank)

def WhoGoesFirst():
	p1x = False
	validInput = False
	
	while (validInput == False):
		answer = input("Which token will go first? (x/o)\n")
		if (answer == "x"):
			p1x = True
			validInput = True
		elif (answer == "o"):
			p1x = False
			validInput = True
		else:
			print("Please answer x or o.")
	
	return p1x

def PrintBoard():
	c = Cell.blank
	
	for i in range(0, len(board)):
		c = board[i]

		if (i % 3 == 0 and i != 0):
			print()

		if (c == Cell.blank):
			print("|_|", end="")
		elif (c == Cell.x):
			print("|x|", end="")
		elif (c == Cell.o):
			print("|o|", end="")

	print()

def PlayGame(p1x):
	token = Cell.blank
	if (p1x):
		token = Cell.x
	else:
		token = Cell.o

	for i in range (0, 9):
		PlaceToken(token)
		
		PrintBoard()
		
		if (CheckWin()):
			if (token == Cell.x):
				print("x wins!")
			elif (token == Cell.o):
				print("o wins!")
			break
			
		if (CheckDraw()):
			print("It's a draw.")
			break
			
		if (token == Cell.x):
			token = Cell.o
		elif (token == Cell.o):
			token = Cell.x
		
def PlaceToken(token):
	place = 0
	placeTaken = True
	
	while (placeTaken):
		place = GetPlace()
		if (board[place] != Cell.blank):
			print("Spot taken.")
			PrintBoard()
		elif (board[place] == Cell.blank):
			placeTaken = False
	
	board[place] = token

def GetPlace():
	place = 0
	answer = ""
	validInput = False
	
	while (validInput == False):
		answer = input("Where would you like to place your token? (1-9)\n")
		try:
			place = int(answer)
			place -= 1
			if (place >= len(board) or place < 0):
				print("Out of bounds.")
				PrintBoard()
			else:
				validInput = True
		except:
			print("Please input a number.")
			PrintBoard()
			
	return place
		
def CheckWin():
	win = False
	
	if (winState(0, 1, 2) or winState(3, 4, 5) or winState(6, 7, 8) or winState(0, 3, 6) or winState(1, 4, 7) or winState(2, 5, 8) or winState(0, 4, 8) or winState(2, 4, 6)):
		win = True
		
	return win

def winState(spot1, spot2, spot3):
	return ((board[spot1] == Cell.x and board[spot2] == Cell.x and board[spot3] == Cell.x) or (board[spot1] == Cell.o and board[spot2] == Cell.o and board[spot3] == Cell.o))
		
def CheckDraw():
	return (board[0] != Cell.blank and board[1] != Cell.blank and board[2] != Cell.blank and board[3] != Cell.blank and board[4] != Cell.blank and board[5] != Cell.blank and board[6] != Cell.blank and board[7] != Cell.blank and board[8] != Cell.blank)
	
def PlayAgain():
	playAgain = False
	
	answer = input("Would you like to play again? (y/n)\n")
	if (answer == "y"):
		playAgain = True
	else:
		print("Goodbye!")
	
	return playAgain
	
	

main()




