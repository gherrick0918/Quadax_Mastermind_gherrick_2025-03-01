using Quadax_Mastermind_gherrick_2025_03_21.Interfaces;

namespace Quadax_Mastermind_gherrick_2025_03_21.Factories
{
    /// <summary>
    /// Factory class for creating instances of ISecretGenerator.
    /// </summary>
    public static class SecretGeneratorFactory
    {
        /// <summary>
        /// Creates an instance of ISecretGenerator.
        /// </summary>
        /// <returns>An instance of SecretGenerator.</returns>
        public static ISecretGenerator Create()
        {
            return new SecretGenerator();
        }
    }
}