var answer = Math.round(Math.random() * 99) + 1;

var guesses = 1;
var guess = 0;

function SendData(form){
	
	guess = form.inputBox.value;
	
	if (guess == answer){
		document.getElementById('prompt').innerHTML = "CORRECT! It took only " + guesses + " guesses.";
	}
	
	else if (guess < 0 || guess > 101){
		document.getElementById('prompt').innerHTML = "Out of range, guess between 1 and 100.";
		guesses++;
	}
	
	else if(guess > answer){
		document.getElementById('prompt').innerHTML = "Too high, try again.";
		guesses++;
	}
	
	else if(guess < answer){
		document.getElementById('prompt').innerHTML = "Too low, try again.";
		guesses++;
	}
	
	else if (guess != answer){
		document.getElementById('prompt').innerHTML = "Try again, numbers  between 1 and 100.";
		guesses++;
	}
}
