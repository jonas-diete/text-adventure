using NUnit.Framework;
using TextAdventure;

namespace TextAdventure.Tests
{
    [TestFixture]
    class EvaluateInputTests
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game();
            List<UserAction> actions = new List<UserAction>();
            UserAction action1 = new UserAction("talk to troll;chat with troll;shout at troll", "You say hi to the troll.", "none");
            UserAction action2 = new UserAction("talk to knight;chat with knight;shout at knight", "You say hi to the knight.", "none");
            actions.Add(action1);
            actions.Add(action2);
            Level level1 = new Level("level1", "Level Description Here", actions);
            List<Level> levels = new List<Level>();
            levels.Add(level1);
            game.levels = levels;
            game.currentLevel = game.levels[0];
        }

        [Test]
        public void EvaluateInput_Should()
        {
            Assert.That(game.EvaluateInput("talk to troll", game.currentLevel.actions), Is.EqualTo("You say hi to the troll."));
        }
    }
}