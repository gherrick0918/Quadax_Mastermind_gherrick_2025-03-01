using FluentAssertions;
using NSubstitute;
using Quadax_Mastermind_gherrick_2025_03_01.Interfaces;

namespace Quadax_Mastermind_gherrick_2025_03_01.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void AskToPlayAgain_ShouldReturnTrue_WhenResponseIsY()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            using var sr = new StringReader("y");
            Console.SetIn(sr);
            var result = Game.AskToPlayAgain();
            result.Should().BeTrue();
        }

        [Test]
        public void AskToPlayAgain_ShouldReturnFalse_WhenResponseIsN()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            using var sr = new StringReader("n");
            Console.SetIn(sr);
            var result = Game.AskToPlayAgain();
            result.Should().BeFalse();
        }

        [Test]
        public void AskToPlayAgain_ShouldReturnFalse_WhenResponseIsInvalid()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            using var sr = new StringReader("invalid");
            Console.SetIn(sr);
            var result = Game.AskToPlayAgain();
            result.Should().BeFalse();
        }

        [Test]
        public void IsValidGuess_ShouldReturnFalse_WhenGuessIsEmpty()
        {
            var result = Game.IsValidGuess(string.Empty);
            result.Should().BeFalse();
        }

        [Test]
        public void IsValidGuess_ShouldReturnFalse_WhenGuessIsNotFourCharacters()
        {
            var result = Game.IsValidGuess("123");
            result.Should().BeFalse();
        }

        [Test]
        public void IsValidGuess_ShouldReturnFalse_WhenGuessContainsInvalidCharacters()
        {
            var result = Game.IsValidGuess("1237");
            result.Should().BeFalse();
        }

        [Test]
        public void IsValidGuess_ShouldReturnTrue_WhenGuessIsValid()
        {
            var result = Game.IsValidGuess("1234");
            result.Should().BeTrue();
        }

        [Test]
        public void GetPlayerGuess_ShouldReturnEnteredGuess()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            using var sr = new StringReader("1234");
            Console.SetIn(sr);
            var result = Game.GetPlayerGuess();
            result.Should().Be("1234");
        }

        [Test]
        public void GetPlayerGuess_ShouldReturnEmptyString_WhenInputIsNull()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            using var sr = new StringReader(string.Empty);
            Console.SetIn(sr);
            var result = Game.GetPlayerGuess();
            result.Should().BeEmpty();
        }

        [Test]
        public void GetPlayerGuess_ShouldReturnEmptyString_WhenInputIsEmpty()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            using var sr = new StringReader(string.Empty);
            Console.SetIn(sr);
            var result = Game.GetPlayerGuess();
            result.Should().BeEmpty();
        }

        [Test]
        public void DisplayWelcomeMessage_ShouldOutputCorrectMessage()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            Game.DisplayWelcomeMessage();
            var result = sw.ToString().Trim().Replace("\r\n", "\n");
            result.Should().Be("Welcome to Mastermind!\nTry to guess the 4-digit number. Each digit ranges from 1 to 6.\nYou have 10 attempts. Good luck!");
        }

        [Test]
        public void PlayGame_ShouldDisplayWelcomeMessage()
        {
            var secretGenerator = Substitute.For<ISecretGenerator>();
            var hintGenerator = Substitute.For<IHintGenerator>();
            var game = new Game(secretGenerator, hintGenerator);

            using var sw = new StringWriter();
            Console.SetOut(sw);
            using var sr = new StringReader("1234\n1234\n1234\n1234\n1234\n1234\n1234\n1234\n1234\n1234");
            Console.SetIn(sr);
            game.PlayGame();
            var result = sw.ToString();
            result.Should().Contain("Welcome to Mastermind!");
        }

        [Test]
        public void PlayGame_ShouldDisplayCorrectHint()
        {
            var secretGenerator = Substitute.For<ISecretGenerator>();
            var hintGenerator = Substitute.For<IHintGenerator>();
            secretGenerator.GenerateSecret().Returns("1234");
            hintGenerator.GenerateHint("1234", "1234").Returns("++++");
            var game = new Game(secretGenerator, hintGenerator);

            using var sw = new StringWriter();
            Console.SetOut(sw);
            using var sr = new StringReader("1234");
            Console.SetIn(sr);
            game.PlayGame();
            var result = sw.ToString();
            result.Should().Contain("Hint: ++++");
        }

        [Test]
        public void PlayGame_ShouldDisplayCongratulationsMessage_WhenGuessIsCorrect()
        {
            var secretGenerator = Substitute.For<ISecretGenerator>();
            var hintGenerator = Substitute.For<IHintGenerator>();
            secretGenerator.GenerateSecret().Returns("1234");
            hintGenerator.GenerateHint("1234", "1234").Returns("++++");
            var game = new Game(secretGenerator, hintGenerator);

            using var sw = new StringWriter();
            Console.SetOut(sw);
            using var sr = new StringReader("1234");
            Console.SetIn(sr);
            game.PlayGame();
            var result = sw.ToString();
            result.Should().Contain("Congratulations! You've guessed the number correctly.");
        }
    }
}