using NUnit.Framework;
using TextAdventure;

namespace TextAdventure.Tests
{
    [TestFixture]
    class TranslateTests
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }

        [TestCase("walk")]
        [TestCase("run")]
        [TestCase("sprint")]
        public void Translate_ShouldReturnGo(string input)
        {
            Assert.That(game.TranslateInput(input), Is.EqualTo("go"));
        }

        [TestCase("shout")]
        [TestCase("scream")]
        [TestCase("call")]
        public void Translate_ShouldReturnSay(string input)
        {
            Assert.That(game.TranslateInput(input), Is.EqualTo("say"));
        }
    }
}