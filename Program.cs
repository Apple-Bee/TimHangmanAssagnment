using System;
using System.Text;

class HangmanGame
{
    private string[] words = { "apple", "banana", "orange", "grape", "kiwi" };
    private string secretWord;
    private char[] guessedWord;
    private StringBuilder incorrectLetters = new StringBuilder();
    private int guessesLeft = 10;
    private StringBuilder guessedLetters = new StringBuilder();

    public void StartGame()
    {
        // Select a random word from the array
        Random random = new Random();
        secretWord = words[random.Next(words.Length)];

        // Initialize guessed word with dashes
        guessedWord = new char[secretWord.Length];
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
            string guess = Console.ReadLine().ToLower();

            if (guessedLetters.ToString().Contains(guess))
            {
                Console.WriteLine("You have already guessed the letter '" + guess + "'. Please try again.");
                continue;
            }
            else
            {
                guessedLetters.Append(guess);
            }

            if (guess.Length == 1)
            {
                // Guess is a letter
                if (secretWord.Contains(guess))
                {
                    // Update guessedWord with correct guesses
                    for (int i = 0; i < secretWord.Length; i++)
                    {
                        if (secretWord[i] == guess[0])
                        {
                            guessedWord[i] = guess[0];
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

