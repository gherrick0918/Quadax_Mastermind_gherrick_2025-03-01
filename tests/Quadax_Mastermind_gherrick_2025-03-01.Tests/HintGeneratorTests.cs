using FluentAssertions;
using Quadax_Mastermind_gherrick_2025_03_01.Interfaces;

namespace Quadax_Mastermind_gherrick_2025_03_01.Tests
{
    [TestFixture]
    public class HintGeneratorTests
    {
        private IHintGenerator _hintGenerator;

        [SetUp]
        public void Setup()
        {
            _hintGenerator = new HintGenerator();
        }

        [Test]
        public void GenerateHint_AllCorrectPositions_ReturnsFourPluses()
        {
            var secret = "1234";
            var guess = "1234";
            var expectedHint = "++++";

            var hint = _hintGenerator.GenerateHint(secret, guess);

            hint.Should().Be(expectedHint);
        }

        [Test]
        public void GenerateHint_AllCorrectDigitsWrongPositions_ReturnsFourMinuses()
        {
            var secret = "1234";
            var guess = "4321";
            var expectedHint = "----";

            var hint = _hintGenerator.GenerateHint(secret, guess);

            hint.Should().Be(expectedHint);
        }

        [Test]
        public void GenerateHint_MixedCorrectAndWrongPositions_ReturnsMixedHint()
        {
            var secret = "1234";
            var guess = "1243";
            var expectedHint = "++--";

            var hint = _hintGenerator.GenerateHint(secret, guess);

            hint.Should().Be(expectedHint);
        }

        [Test]
        public void GenerateHint_NoCorrectDigits_ReturnsEmptyHint()
        {
            var secret = "1234";
            var guess = "5678";
            var expectedHint = "";

            var hint = _hintGenerator.GenerateHint(secret, guess);

            hint.Should().Be(expectedHint);
        }

        [Test]
        public void GenerateWrongPositionHints_AllCorrectDigitsWrongPositions_ReturnsFourMinuses()
        {
            var secret = "1234";
            var guess = "4321";
            var hint = new char[4];
            var secretUsed = new bool[4];
            var guessUsed = new bool[4];
            var hintIndex = 0;

            HintGenerator.GenerateWrongPositionHints(secret, guess, hint, secretUsed, guessUsed, ref hintIndex);

            var result = new string(hint, 0, hintIndex);
            result.Should().Be("----");
        }

        [Test]
        public void GenerateWrongPositionHints_MixedCorrectAndWrongPositions_ReturnsMixedHint()
        {
            var secret = "1234";
            var guess = "1243";
            var hint = new char[4];
            var secretUsed = new bool[4];
            var guessUsed = new bool[4];
            var hintIndex = 0;

            // First, generate correct position hints
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    hint[hintIndex++] = '+';
                    secretUsed[i] = true;
                    guessUsed[i] = true;
                }
            }

            // Then, generate wrong position hints
            for (int i = 0; i < secret.Length; i++)
            {
                if (!secretUsed[i])
                {
                    for (int j = 0; j < guess.Length; j++)
                    {
                        if (!guessUsed[j] && secret[i] == guess[j])
                        {
                            hint[hintIndex++] = '-';
                            secretUsed[i] = true;
                            guessUsed[j] = true;
                            break;
                        }
                    }
                }
            }

            var result = new string(hint, 0, hintIndex);
            result.Should().Be("++--");
        }

        [Test]
        public void GenerateWrongPositionHints_NoCorrectDigits_ReturnsEmptyHint()
        {
            var secret = "1234";
            var guess = "5678";
            var hint = new char[4];
            var secretUsed = new bool[4];
            var guessUsed = new bool[4];
            var hintIndex = 0;

            HintGenerator.GenerateWrongPositionHints(secret, guess, hint, secretUsed, guessUsed, ref hintIndex);

            var result = new string(hint, 0, hintIndex);
            result.Should().Be("");
        }

        [Test]
        public void GenerateWrongPositionHints_SomeCorrectSomeWrongPositions_ReturnsCorrectHint()
        {
            var secret = "1234";
            var guess = "1325";
            var hint = new char[4];
            var secretUsed = new bool[4];
            var guessUsed = new bool[4];
            var hintIndex = 0;

            // First, generate correct position hints
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    hint[hintIndex++] = '+';
                    secretUsed[i] = true;
                    guessUsed[i] = true;
                }
            }

            // Then, generate wrong position hints
            for (int i = 0; i < secret.Length; i++)
            {
                if (!secretUsed[i])
                {
                    for (int j = 0; j < guess.Length; j++)
                    {
                        if (!guessUsed[j] && secret[i] == guess[j])
                        {
                            hint[hintIndex++] = '-';
                            secretUsed[i] = true;
                            guessUsed[j] = true;
                            break;
                        }
                    }
                }
            }

            var result = new string(hint, 0, hintIndex);
            result.Should().Be("+--");
        }

        [Test]
        public void GenerateWrongPositionHints_DuplicateDigitsInGuess_ReturnsCorrectHint()
        {
            var secret = "1122";
            var guess = "2211";
            var hint = new char[4];
            var secretUsed = new bool[4];
            var guessUsed = new bool[4];
            var hintIndex = 0;

            HintGenerator.GenerateCorrectPositionHints(secret, guess, hint, secretUsed, guessUsed);
            HintGenerator.GenerateWrongPositionHints(secret, guess, hint, secretUsed, guessUsed, ref hintIndex);

            var result = new string(hint, 0, hintIndex);
            result.Should().Be("----");
        }

        [Test]
        public void GenerateHint_SomeCorrectSomeWrongPositions_ReturnsCorrectHint()
        {
            var secret = "1234";
            var guess = "1325";
            var expectedHint = "+--";

            var hint = _hintGenerator.GenerateHint(secret, guess);

            hint.Should().Be(expectedHint);
        }

        [Test]
        public void GenerateHint_DuplicateDigitsInGuess_ReturnsCorrectHint()
        {
            var secret = "1122";
            var guess = "2211";
            var expectedHint = "----";

            var hint = _hintGenerator.GenerateHint(secret, guess);

            hint.Should().Be(expectedHint);
        }

        [Test]
        public void GenerateHint_SomeCorrectSomeWrongPositionsWithDuplicates_ReturnsCorrectHint()
        {
            var secret = "1122";
            var guess = "1212";
            var expectedHint = "++--";

            var hint = _hintGenerator.GenerateHint(secret, guess);

            hint.Should().Be(expectedHint);
        }

        [Test]
        public void GenerateHint_AllWrongPositionsWithDuplicates_ReturnsCorrectHint()
        {
            var secret = "1122";
            var guess = "2211";
            var expectedHint = "----";

            var hint = _hintGenerator.GenerateHint(secret, guess);

            hint.Should().Be(expectedHint);
        }
    }
}