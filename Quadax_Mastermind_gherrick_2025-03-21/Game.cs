using Quadax_Mastermind_gherrick_2025_03_21.Interfaces;

namespace Quadax_Mastermind_gherrick_2025_03_21
{
    /// <summary>
    /// Represents the Mastermind game.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Game"/> class.
    /// </remarks>
    /// <param name="secretGenerator">The secret generator.</param>
    /// <param name="hintGenerator">The hint generator.</param>
    public class Game(ISecretGenerator secretGenerator, IHintGenerator hintGenerator)
    {
        private readonly ISecretGenerator _secretGenerator = secretGenerator;
        private readonly IHintGenerator _hintGenerator = hintGenerator;
        private readonly int _attempts = 10;

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Start()
        {
            do
            {
                PlayGame();
            } while (AskToPlayAgain());
        }

        /// <summary>
        /// Plays a single game session.
        /// </summary>
        internal void PlayGame()
        {
            var secret = _secretGenerator.GenerateSecret();
            var attempts = _attempts;

            DisplayWelcomeMessage();

            while (attempts > 0)
            {
                var guess = GetPlayerGuess();

                if (!IsValidGuess(guess))
                {
                    Console.WriteLine("Invalid guess. Please enter a 4-digit number with each digit between 1 and 6.");
                    continue;
                }

                var hint = _hintGenerator.GenerateHint(secret, guess);
                Console.WriteLine("Hint: " + hint);

                if (hint == "++++")
                {
                    Console.WriteLine("Congratulations! You've guessed the number correctly.");
                    return;
                }

                attempts--;
                Console.WriteLine($"Attempts remaining: {attempts}");
            }

            Console.WriteLine($"Sorry, you've lost. The correct number was: {secret}");
        }

        /// <summary>
        /// Displays the welcome message.
        /// </summary>
        internal static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to Mastermind!");
            Console.WriteLine("Try to guess the 4-digit number. Each digit ranges from 1 to 6.");
            Console.WriteLine("You have 10 attempts. Good luck!");
        }

        /// <summary>
        /// Gets the player's guess.
        /// </summary>
        /// <returns>The player's guess.</returns>
        internal static string GetPlayerGuess()
        {
            Console.Write("Enter your guess: ");
            var guess = Console.ReadLine();
            return guess ?? string.Empty;
        }

        /// <summary>
        /// Validates the player's guess.
        /// </summary>
        /// <param name="guess">The player's guess.</param>
        /// <returns><c>true</c> if the guess is valid; otherwise, <c>false</c>.</returns>
        internal static bool IsValidGuess(string guess)
        {
            if (string.IsNullOrEmpty(guess) || guess.Length != 4)
            {
                return false;
            }

            foreach (var c in guess)
            {
                if (c < '1' || c > '6')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Asks the player if they want to play again.
        /// </summary>
        /// <returns><c>true</c> if the player wants to play again; otherwise, <c>false</c>.</returns>
        internal static bool AskToPlayAgain()
        {
            Console.WriteLine("Do you want to play again? (y/n): ");
            var response = Console.ReadLine();
            return response != null && response.Trim().ToLower() == "y";
        }
    }
}