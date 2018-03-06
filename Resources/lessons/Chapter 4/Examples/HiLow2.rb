def playLoop()
	playing = true
	
	answer = rand(1..100)
	win = false
	numGuesses = 1
	while win == false do
		win = guessLoop(answer)
		if (win)
			print "Congrats, you got it in ", numGuesses, " guesses.\n"
		else
			numGuesses += 1
		end
	end
	puts "Would you like to play again?(y/n):"
	playAgain = gets.chomp
	if (playAgain == "n")
		playing = false
		puts "Goodbye"
	end
	
	return playing
end

def guessLoop(answer)
	win = false
	
	print "Guess a number between 1 and 100:"
	guess = gets.chomp.to_i
	if (guess == answer)
		win = true
	elsif (guess < answer)
		puts "Too low"
	elsif (guess > answer)
		puts "Too high"
	end
	
	return win
end

playing = true

puts "Hello and welcome to the High-low number guessing game."
while (playing) do
	playing = playLoop()
end