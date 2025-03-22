using Quadax_Mastermind_gherrick_2025_03_01.Factories;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Quadax_Mastermind_gherrick_2025-03-01.Tests")]

namespace Quadax_Mastermind_gherrick_2025_03_01
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