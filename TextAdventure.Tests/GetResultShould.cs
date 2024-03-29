using NUnit.Framework;
using TextAdventure;

namespace TextAdventure.Tests
{
    [TestFixture]
    class GetResultTests
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }

        [TestCase("get", "sword")]
        [TestCase("get", "ring")]
        [TestCase("get", "rattle")]
        public void GetResult_ShouldReturnEmptyString(string result, string attribute)
        {
            Assert.That(game.GetResult(result, attribute), Is.EqualTo(""));
            Assert.That(game.inventory.Contains(attribute));
        }

        [TestCase("load", "level2")]
        [TestCase("load", "level3")]
        [TestCase("load", "end")]
        public void GetResult_ShouldReturnNextLevel(string result, string attribute)
        {
            Assert.That(game.GetResult(result, attribute), Is.EqualTo(game.GetLevel(attribute)));
        }

    }
}