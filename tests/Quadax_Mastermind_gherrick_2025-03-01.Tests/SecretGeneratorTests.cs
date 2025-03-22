using FluentAssertions;
using Quadax_Mastermind_gherrick_2025_03_01.Interfaces;

namespace Quadax_Mastermind_gherrick_2025_03_01.Tests
{
    [TestFixture]
    public class SecretGeneratorTests
    {
        private ISecretGenerator _secretGenerator;

        [SetUp]
        public void Setup()
        {
            _secretGenerator = new SecretGenerator();
        }

        [Test]
        public void GenerateSecret_ReturnsFourDigitString()
        {
            var secret = _secretGenerator.GenerateSecret();

            secret.Length.Should().Be(4);
        }

        [Test]
        public void GenerateSecret_ReturnsDigitsBetweenOneAndSix()
        {
            var secret = _secretGenerator.GenerateSecret();

            foreach (var digit in secret)
            {
                digit.Should().BeInRange('1', '6');
            }
        }

        [Test]
        public void GenerateSecret_ReturnsUniqueSecrets()
        {
            var secrets = new HashSet<string>();

            for (int i = 0; i < 1000; i++)
            {
                var secret = _secretGenerator.GenerateSecret();

                while (secrets.Any(s => s == secret))
                {
                    secret = _secretGenerator.GenerateSecret();
                }

                secrets.Add(secret);
            }

            secrets.Count.Should().Be(1000);
        }

        [Test]
        public void GenerateSecret_DoesNotReturnSameSecretConsecutively()
        {
            var previousSecret = _secretGenerator.GenerateSecret();

            for (int i = 0; i < 100; i++)
            {
                var currentSecret = _secretGenerator.GenerateSecret();
                currentSecret.Should().NotBe(previousSecret);
                previousSecret = currentSecret;
            }
        }
    }
}