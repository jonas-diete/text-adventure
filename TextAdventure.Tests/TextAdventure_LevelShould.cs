using NUnit.Framework;
using TextAdventure;

namespace TextAdventure.Tests
{
    [TestFixture]
    public class Tests
    {
        private Level level;
        private UserAction action1;
        private List<UserAction> actions = new List<UserAction>();

        

        [SetUp]
        public void Setup()
        {
            action1 = new UserAction("open eyes", "Some description", "none");
            actions.Add(action1);
            level = new Level("intro", "You emerge into bright light.", actions);
        }

        [Test]
        public void Level_ShouldReturnCorrectValues()
        {
            Assert.That(level.name, Is.EqualTo("intro"));
            Assert.That(level.description, Is.EqualTo("You emerge into bright light."));
            Assert.That(level.actions[0].descriptions, Is.EqualTo("open eyes"));
        }
    }
}

