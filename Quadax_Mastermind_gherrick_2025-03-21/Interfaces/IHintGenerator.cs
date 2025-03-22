namespace Quadax_Mastermind_gherrick_2025_03_21.Interfaces
{
    /// <summary>
    /// Interface for generating hints based on the secret and guess.
    /// </summary>
    public interface IHintGenerator
    {
        /// <summary>
        /// Generates a hint based on the provided secret and guess.
        /// </summary>
        /// <param name="secret">The secret code to be guessed.</param>
        /// <param name="guess">The player's guess.</param>
        /// <returns>A hint indicating the correctness of the guess.</returns>
        string GenerateHint(string secret, string guess);
    }
}