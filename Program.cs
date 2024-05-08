using System;
using System.Text;

class HangmanGame
{
    private string[] words = { "apple", "banana", "orange", "grape", "kiwi" };
    private string secretWord;//dashed word
    private char[] guessedWord;//word that has to be reaveld
    private StringBuilder incorrectLetters = new StringBuilder(); //string modify 
    private int guessesLeft = 10;
    private StringBuilder guessedLetters = new StringBuilder(); //string modify

    public void StartGame()
    {
        // Select a random word from the array
        Random random = new Random();
        secretWord = words[random.Next(words.Length)]; //get a random index from words array and out it in the secretWord

        // Initialize guessed word with dashes
        guessedWord = new char[secretWord.Length]; // SecretWord transform to dashes
        for (int i = 0; i < secretWord.Length; i++)  
        {
            guessedWord[i] = '_';
        }

        Console.WriteLine("Welcome to Hangman!");
        Console.WriteLine("Guess the word or a letter. You have 10 guesses.");

        // Main game loop
        while (guessesLeft > 0)
        {
            Console.WriteLine();
            Console.WriteLine("Word: " + new string(guessedWord));
            Console.WriteLine("Incorrect guesses: " + incorrectLetters);
            Console.WriteLine("Guesses left: " + guessesLeft);
            Console.Write("Enter your guess: ");
            string guess = Console.ReadLine().ToLower();// input ur guess

            if (guessedLetters.ToString().Contains(guess))// here i store the the wrong letter and if guessedLetter in stringbuilder allready contains in the guessed letter it will tell me and just contrinue
            {
                Console.WriteLine("You have already guessed the letter '" + guess + "'. Please try again.");
                continue;
            }
            else
            {
                guessedLetters.Append(guess); // if not containing a allready guessed letter it will add it to guessedLetters stringBuilder
            }

            if (guess.Length == 1) // here i  check if guess contains leter it will reveal. 
            {
                // Guess is a letter
                if (secretWord.Contains(guess))
                {
                    // Update guessedWord with correct guesses
                    for (int i = 0; i < secretWord.Length; i++) //loop true the secretWord
                    {
                        if (secretWord[i] == guess[0]) //check if secretWord and guessed letter is the same
                        {
                            guessedWord[i] = guess[0];//here it will transform the dashes to the letter if it is correct
                        }
                    }
                }
                else
                {
                    // Add incorrect guess to StringBuilder
                    incorrectLetters.Append(guess + " "); 
                    guessesLeft--;
                }
            }
            else
            {
                // Guess is the whole word
                if (guess == secretWord)
                {
                    Console.WriteLine("Congratulations! You've guessed the word: " + secretWord);
                    return;
                }
                else
                {
                    Console.WriteLine("Incorrect guess! Try again.");
                    guessesLeft--;
                }
            }

            // Check if all letters have been guessed
            if (new string(guessedWord) == secretWord)
            {
                Console.WriteLine("Congratulations! You've guessed the word: " + secretWord);
                return;
            }
        }

        // If guesses run out
        Console.WriteLine("You've run out of guesses! The word was: " + secretWord);
    }
}

class Program
{
    static void Main(string[] args)
    {
        HangmanGame hangman = new HangmanGame();
        hangman.StartGame();
    }
}

