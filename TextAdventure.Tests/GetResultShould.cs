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
        public void GetResult_ShouldReturnEmptyString(string input1, string input2)
        {
            Assert.That(game.GetResult(input1, input2), Is.EqualTo(""));
        }

    }
}