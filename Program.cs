namespace CCCUrdle_game;

using System;
					
public class CCCUrdle
{
	public static void Main(string[] args)
	{
		Random rand = new Random();

		// initialising word array
		string[] potSecWords = {"Apple", "Beach", "Click", "Diary", "Earth",
							   "Fruit", "Ghost", "Heart", "Juice", "Light",
							   "Money", "Party", "Radio", "Smile", "Table",
							   "Water", "Youth"};
		string guess = "";
		int maxAttempts = 6;
		int userAttempts = 0;
		
		// start a new game (pick random secret word): 
		int secretWordIndex = rand.Next(potSecWords.Length);
		string secretWord = potSecWords[secretWordIndex];
		Console.WriteLine("I'm thinking of a five letter word...");
		
		Console.WriteLine(secretWord);
		
		while (maxAttempts != userAttempts)
		{
			// user makes a new guess
			Console.WriteLine("You have 6 attempts. So far you have made " + userAttempts + " attempts.");
			Console.WriteLine("You have " + (maxAttempts - userAttempts) + " left.");
			Console.WriteLine("Please guess a word: ");
			guess = Console.ReadLine();
			
			Console.WriteLine(secretWord);
			
			// Makes guess all lowercase, and the first letter uppercase
			guess = guess.ToLower();
			guess = char.ToUpper(guess[0]) + guess.Substring(1);
			
			// need to check that guess meets all requirements (5 letters long, valid characters, etc.)
			if (string.IsNullOrEmpty(guess))
			{
				Console.WriteLine("Very funny. Please ENTER a word.\n");
				continue;
			}
			
			if (guess.Length != 5)
			{
				Console.WriteLine("Your word is too long or too short.");
				continue;
			}
			
			if (guess != secretWord)
			{
				// guess is incorrect.
				userAttempts++;
				Console.WriteLine("That is not the correct word.");
			
				// for every letter in the secret word
				for (int i = 0; i < secretWord.Length; i++)
				{
					if (secretWord[i] == guess[i])
					{
						// if the letters match
						Console.WriteLine("The letter " + guess[i] + " is GREEN. (Is present in the secret word and in the correct position.)");
					}
					
					else
					{
						// letters do not match positions
            			if (secretWord.IndexOf(guess[i]) != -1)
						{
							// letter is ORANGE
							Console.WriteLine("The letter " + guess[i] + " is ORANGE. (Is present in the secret word but in the incorrect position.)");
						}
					}
				}
			}
			else 
			{
				if (guess == secretWord)
				{
					Console.WriteLine("That is the correct word!");
				}
			}
		}
		Console.WriteLine("The right word was " + secretWord);
	}
}
