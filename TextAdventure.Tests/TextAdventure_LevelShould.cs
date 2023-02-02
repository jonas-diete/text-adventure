using NUnit.Framework;
using TextAdventure;

namespace TextAdventure.Tests
{
    [TestFixture]
    public class Tests
    {
        private Level level;
        private UserAction action1;
        private UserAction action2;
        private UserAction[] actions;

        [SetUp]
        public void Setup()
        {
            action1 = new UserAction("open eyes", "You open your eyes. Everything is bright, bright light! An incredible sensation overcomes you - you feel more alive than ever before!", "none");
            action2 = new UserAction("shout hello", "You open your mouth and try to shout but you can just emit a strange scream.", "none");
            actions = new UserAction[] { action1, action2 };
            level = new Level("intro", "You emerge into bright light.", actions);
        }

        [Test]
        public void Level_ShouldReturnCorrectValues()
        {
            Assert.That(level.name, Is.EqualTo("intro"));
            Assert.That(level.description, Is.EqualTo("You emerge into bright light."));
            Assert.That(level.actions[0].description, Is.EqualTo("open eyes"));
        }
    }
}

