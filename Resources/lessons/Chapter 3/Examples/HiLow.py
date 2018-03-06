import random
playing = True

print("Hello and welcome to the High-low number guessing game.")
while (playing):
	answer = random.randint(1, 100)
	win = False
	numGuesses = 1
	while (win == False):
		guess = int(input("Guess a number between 1 and 100:"))
		if (guess == answer):
			print("Congrats, you got it in", numGuesses, "guesses.")
			win = True
		elif (guess < answer):
			print("Too low")
			numGuesses += 1
		elif (guess > answer):
			print("Too high")
			numGuesses += 1
	playAgain = input("Would you like to play again?(y/n):")
	if (playAgain == "n"):
		playing = False
		print("Goodbye")
