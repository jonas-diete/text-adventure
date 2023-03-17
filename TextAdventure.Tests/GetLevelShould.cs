using NUnit.Framework;
using TextAdventure;

namespace TextAdventure.Tests
{
    [TestFixture]
    class GetLevelTests
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }

        [Test]
        public void GetLevel_ShouldReturnLevelDescriptionAndAskForInput()
        {
            List<UserAction> actions = new List<UserAction>();
            Level level1 = new Level("level1", "Level Description Here", actions);
            List<Level> levels = new List<Level>();
            levels.Add(level1);
            game.levels = levels;
            Assert.That(game.GetLevel("level1"), Is.EqualTo("\n\nLevel Description Here\nWhat do you want to do?"));
            Assert.That(game.currentLevel.description, Is.EqualTo("Level Description Here"));
        }
    }
}