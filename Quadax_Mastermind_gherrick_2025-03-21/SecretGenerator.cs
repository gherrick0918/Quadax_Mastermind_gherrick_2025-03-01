using Quadax_Mastermind_gherrick_2025_03_21.Interfaces;

namespace Quadax_Mastermind_gherrick_2025_03_21
{
    /// <summary>
    /// Generates secret codes for the Mastermind game.
    /// </summary>
    public class SecretGenerator : ISecretGenerator
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// Generates a secret code.
        /// </summary>
        /// <returns>A string representing the secret code.</returns>
        public string GenerateSecret()
        {
            var secret = new char[4];
            for (var i = 0; i < 4; i++)
            {
                secret[i] = (char)('1' + _random.Next(6));
            }
            return new string(secret);
        }
    }
}