using Quadax_Mastermind_gherrick_2025_03_01.Interfaces;

namespace Quadax_Mastermind_gherrick_2025_03_01.Factories
{
    /// <summary>
    /// Factory class for creating instances of IHintGenerator.
    /// </summary>
    public static class HintGeneratorFactory
    {
        /// <summary>
        /// Creates an instance of IHintGenerator.
        /// </summary>
        /// <returns>An instance of HintGenerator.</returns>
        public static IHintGenerator Create()
        {
            return new HintGenerator();
        }
    }
}