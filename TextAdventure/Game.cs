namespace TextAdventure
{
    public class Game
    {
        Level currentLevel;
        Level[] levels;
        Input input;

        public Game()
        {
            LevelCreator levelCreator = new LevelCreator();
            levels = levelCreator.CreateLevels();
            currentLevel = levels[0];
            input = new Input();
        }

        public void StartGame()
        {
            LoadIntro();
            Console.WriteLine(currentLevel.description);
            while (currentLevel.name != "end")
            {
                string playerInput = input.GetInput();
                EvaluateInput(playerInput, currentLevel.actions);
            }
        }

        private void EvaluateInput(string playerInput, UserAction[] possibleActions)
        {
            foreach (UserAction possibleAction in possibleActions)
            {
                // todo: need to translate the playerInput here, so it is standardised into take, look, go, open, close, turn on, turn off             
                if (playerInput == possibleAction.description)
                {
                    Console.WriteLine(possibleAction.resultDescription);
                    LoadResult(possibleAction.result, possibleAction.resultAttribute);
                    return;
                }
            }
            Console.WriteLine("I don't understand what to do.");
        }

        private void LoadLevel(string levelName)
        {
            foreach (Level level in levels)
            {
                if (level.name == levelName)
                {
                    currentLevel = level;
                    Console.WriteLine(currentLevel.description);
                }
            }
        }

        private void LoadResult(string result, string attribute)
        {
            if (result == "get")
            {
                // todo: add phone to inventory instead of the writeline
                Console.WriteLine("Received" + attribute);
            }
            else if (result == "load")
            {
                LoadLevel(attribute);
            }
        }
            

        private void LoadIntro()
        {
            Console.WriteLine("Hello and welcome to Into The Light - a text adventure by Jonas Diete");
            Console.WriteLine("---------");
            Console.WriteLine("");
        }
    }
}