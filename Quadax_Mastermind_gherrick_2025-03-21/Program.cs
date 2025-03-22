using Quadax_Mastermind_gherrick_2025_03_21.Factories;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Quadax_Mastermind_gherrick_2025-03-21.Tests")]

namespace Quadax_Mastermind_gherrick_2025_03_21
{
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var secretGenerator = SecretGeneratorFactory.Create();
            var hintGenerator = HintGeneratorFactory.Create();
            var game = new Game(secretGenerator, hintGenerator);
            game.Start();
        }
    }
}