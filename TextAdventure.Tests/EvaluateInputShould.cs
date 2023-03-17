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
            UserAction action1 = new UserAction("talk to troll;chat with troll;communicate with troll", "You say hi to the troll.", "none");
            UserAction action2 = new UserAction("talk to knight;chat with knight;communicate with knight", "You say hi to the knight.", "none");
            actions.Add(action1);
            actions.Add(action2);
            Level level1 = new Level("level1", "Level Description Here", actions);
            List<Level> levels = new List<Level>();
            levels.Add(level1);
            game.levels = levels;
            game.currentLevel = game.levels[0];
        }

        [TestCase("talk to troll")]
        [TestCase("chat with troll")]
        [TestCase("communicate with troll")]
        public void EvaluateInput_Should(string input)
        {
            Assert.That(game.EvaluateInput(input, game.currentLevel.actions), Is.EqualTo("You say hi to the troll."));
        }
    }
}