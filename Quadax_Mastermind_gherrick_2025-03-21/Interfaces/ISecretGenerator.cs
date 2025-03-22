namespace Quadax_Mastermind_gherrick_2025_03_21.Interfaces
{
    /// <summary>
    /// Interface for generating secret codes.
    /// </summary>
    public interface ISecretGenerator
    {
        /// <summary>
        /// Generates a secret code.
        /// </summary>
        /// <returns>A string representing the secret code.</returns>
        string GenerateSecret();
    }
}