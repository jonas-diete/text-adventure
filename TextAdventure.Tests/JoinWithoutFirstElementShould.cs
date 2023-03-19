using NUnit.Framework;
using TextAdventure;

namespace TextAdventure.Tests
{
    [TestFixture]
    class JoinWithoutFirstElementTests
    {
        private Game game;
        private string[] test1 = {"have", "compass"};
        private string[] test2 = {"have", "battle", "axe"};
        private string[] test3 = {"have", "old", "oak", "bow"};

        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }

        [Test]
        public void JoinWithoutFirstElement_ShouldReturnCorrectString1()
        {
            Assert.That(game.JoinWithoutFirstElement(test1), Is.EqualTo("compass"));
        }
                
        [Test]
        public void JoinWithoutFirstElement_ShouldReturnCorrectString2()
        {
            Assert.That(game.JoinWithoutFirstElement(test2), Is.EqualTo("battle axe"));
        }
                
        [Test]
        public void JoinWithoutFirstElement_ShouldReturnCorrectString3()
        {
            Assert.That(game.JoinWithoutFirstElement(test3), Is.EqualTo("old oak bow"));
        }
    }
}