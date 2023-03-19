using NUnit.Framework;
using TextAdventure;

namespace TextAdventure.Tests
{
    [TestFixture]
    class CheckInventoryTests
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game();
            game.inventory.Add("compass");
            game.inventory.Add("battle axe");
            game.inventory.Add("old oak bow");
        }

        [TestCase("have compass")]
        [TestCase("have battle axe")]
        [TestCase("have old oak bow")]
        public void CheckInventory_ShouldReturnTrueIfItemInInventory(string input)
        {
            Assert.That(game.CheckInventory(input), Is.EqualTo(true));
        }

        [TestCase("have red cap")]
        [TestCase("have spool")]
        [TestCase("have a lovely roast dinner")]
        public void CheckInventory_ShouldReturnFalseIfItemNotInInventory(string input)
        {
            Assert.That(game.CheckInventory(input), Is.EqualTo(false));
        }

        [TestCase("go to compass")]
        [TestCase("get battle axe")]
        [TestCase("shoot old oak bow")]
        public void CheckInventory_ShouldReturnFalseIfRequirementIsNotHave(string input)
        {
            Assert.That(game.CheckInventory(input), Is.EqualTo(false));
        }
    }
}