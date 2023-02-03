namespace TextAdventure.Tests
{
    [TestFixture]
    class TranlateInputTests
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }

        [TestCase("walk")]
        [TestCase("run")]
        [TestCase("sprint")]
        public void TranslateInput_ShouldReturnGo(string input)
        {
            Assert.That(game.TranslateInput(input), Is.EqualTo("go"));
        }

        [TestCase("shout")]
        [TestCase("scream")]
        [TestCase("call")]
        public void TranslateInput_ShouldReturnSay(string input)
        {
            Assert.That(game.TranslateInput(input), Is.EqualTo("say"));
        }
    }
}