playing = true

puts "Hello and welcome to the High-low number guessing game."
while (playing) do
	answer = rand(1..100)
	win = false
	numGuesses = 1
	while win == false do
		print "Guess a number between 1 and 100:"
		guess = gets.chomp.to_i
		if (guess == answer)
			print "Congrats, you got it in ", numGuesses, " guesses.\n"
			win = true
		elsif (guess < answer)
			puts "Too low"
			numGuesses += 1
		elsif (guess > answer)
			puts "Too high"
			numGuesses += 1
		end
	end
	puts "Would you like to play again?(y/n):"
	playAgain = gets.chomp
	if (playAgain == "n")
		playing = false
		puts "Goodbye"
	end
end