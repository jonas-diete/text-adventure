using NUnit.Framework;
using TextAdventure;

namespace TextAdventure.Tests
{
    [TestFixture]
    class TranslateInputTests
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }

        [TestCase("walk to house")]
        [TestCase("run to house")]
        [TestCase("sprint to house")]
        public void TranslateInput_ShouldReturnGoToHouse(string input)
        {
            Assert.That(game.TranslateInput(input), Is.EqualTo("go to house"));
        }

        [TestCase("shout hello")]
        [TestCase("scream hello")]
        [TestCase("call hello")]
        public void TranslateInput_ShouldReturnSayHello(string input)
        {
            Assert.That(game.TranslateInput(input), Is.EqualTo("say hello"));
        }
    }
}