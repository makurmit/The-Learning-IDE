import random

def playLoop():
	playing = True
	answer = random.randint(1, 100)
	win = False
	numGuesses = 1
	while (win == False):
		win = guessLoop(answer)
		if (win):
			print("Congrats, you got it in", numGuesses, "guesses.")
		else:
			numGuesses += 1
	playAgain = input("Would you like to play again?(y/n):")
	if (playAgain == "n"):
		playing = False
		print("Goodbye")
	return playing

def guessLoop(answer):
	win = False
	guess = int(input("Guess a number between 1 and 100:"))
	if (guess == answer):
		win = True
	elif (guess < answer):
		print("Too low")
	elif (guess > answer):
		print("Too high")
	return win
	
playing = True
print("Hello and welcome to the High-low number guessing game.")
while (playing):
	playing = playLoop()