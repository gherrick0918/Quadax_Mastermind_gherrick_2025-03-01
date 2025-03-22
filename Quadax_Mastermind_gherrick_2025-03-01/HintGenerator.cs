using Quadax_Mastermind_gherrick_2025_03_01.Interfaces;

namespace Quadax_Mastermind_gherrick_2025_03_01
{
    /// <summary>
    /// Generates hints for the Mastermind game based on the secret and guess.
    /// </summary>
    public class HintGenerator : IHintGenerator
    {
        /// <summary>
        /// Generates a hint based on the provided secret and guess.
        /// </summary>
        /// <param name="secret">The secret code to be guessed.</param>
        /// <param name="guess">The player's guess.</param>
        /// <returns>A hint indicating the correctness of the guess.</returns>
        public string GenerateHint(string secret, string guess)
        {
            var hint = new char[4];
            var secretUsed = new bool[4];
            var guessUsed = new bool[4];

            var hintIndex = GenerateCorrectPositionHints(secret, guess, hint, secretUsed, guessUsed);
            GenerateWrongPositionHints(secret, guess, hint, secretUsed, guessUsed, ref hintIndex);

            return new string(hint, 0, hintIndex);
        }

        /// <summary>
        /// Generates hints for correct digits in the correct position.
        /// </summary>
        /// <param name="secret">The secret code to be guessed.</param>
        /// <param name="guess">The player's guess.</param>
        /// <param name="hint">The hint array to be filled.</param>
        /// <param name="secretUsed">Array indicating which digits in the secret have been used.</param>
        /// <param name="guessUsed">Array indicating which digits in the guess have been used.</param>
        /// <returns>The index in the hint array after processing correct position hints.</returns>
        internal static int GenerateCorrectPositionHints(string secret, string guess, char[] hint, bool[] secretUsed, bool[] guessUsed)
        {
            var hintIndex = 0;
            for (var i = 0; i < 4; i++)
            {
                if (guess[i] == secret[i])
                {
                    hint[hintIndex++] = '+';
                    secretUsed[i] = true;
                    guessUsed[i] = true;
                }
            }
            return hintIndex;
        }

        /// <summary>
        /// Generates hints for correct digits in the wrong position.
        /// </summary>
        /// <param name="secret">The secret code to be guessed.</param>
        /// <param name="guess">The player's guess.</param>
        /// <param name="hint">The hint array to be filled.</param>
        /// <param name="secretUsed">Array indicating which digits in the secret have been used.</param>
        /// <param name="guessUsed">Array indicating which digits in the guess have been used.</param>
        /// <param name="hintIndex">The index in the hint array to start filling from.</param>
        internal static void GenerateWrongPositionHints(string secret, string guess, char[] hint, bool[] secretUsed, bool[] guessUsed, ref int hintIndex)
        {
            for (var i = 0; i < 4; i++)
            {
                if (!guessUsed[i])
                {
                    for (var j = 0; j < 4; j++)
                    {
                        if (!secretUsed[j] && guess[i] == secret[j])
                        {
                            hint[hintIndex++] = '-';
                            secretUsed[j] = true;
                            break;
                        }
                    }
                }
            }
        }
    }
}
