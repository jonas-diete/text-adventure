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
            UserAction action1 = new UserAction("talk to troll;chat with troll;communicate with troll", "You say hi to the troll.", "none", "none", "go to bridge", "There is no troll.");
            UserAction action2 = new UserAction("talk to knight;chat with knight;communicate with knight", "You say hi to the knight.", "none", "none", "go to bridge", "There is no knight.");
            actions.Add(action1);
            actions.Add(action2);
            Level level1 = new Level("level1", "You walk to the bridge. There is a troll and a knight.", actions);
            List<Level> levels = new List<Level>();
            levels.Add(level1);
            game.levels = levels;
            game.currentLevel = game.levels[0];
        }

        [TestCase("talk to troll")]
        [TestCase("chat with troll")]
        [TestCase("communicate with troll")]
        public void EvaluateInput_ShouldReturnRequirementNotFulfilledDescription(string input)
        {
            // Here the requirement 'go to bridge' is not fulfilled:
            Assert.That(game.EvaluateInput(input, game.currentLevel.actions), Is.EqualTo("There is no troll."));
        }

        [TestCase("talk to troll")]
        [TestCase("chat with troll")]
        [TestCase("communicate with troll")]
        public void EvaluateInput_ShouldReturnResultDescriptionOfFirstAction(string input)
        {
            game.currentLevel.actionsCompleted.Add("go to bridge");
            Assert.That(game.EvaluateInput(input, game.currentLevel.actions), Is.EqualTo("You say hi to the troll."));
        }

        [TestCase("talk to knight")]
        [TestCase("chat with knight")]
        [TestCase("communicate with knight")]
        public void EvaluateInput_ShouldReturnResultDescriptionOfSecondAction(string input)
        {
            game.currentLevel.actionsCompleted.Add("go to bridge");
            Assert.That(game.EvaluateInput(input, game.currentLevel.actions), Is.EqualTo("You say hi to the knight."));
        }

        [TestCase("ask troll for the way")]
        [TestCase("hit troll")]
        [TestCase("fight the knight")]
        public void EvaluateInput_ShouldReturnIDontUnderstand(string input)
        {
            game.currentLevel.actionsCompleted.Add("go to bridge");
            Assert.That(game.EvaluateInput(input, game.currentLevel.actions), Is.EqualTo("I don't understand what to do."));
        }
    }
}