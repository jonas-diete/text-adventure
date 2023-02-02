namespace TextAdventure
{
    public class Game
    {
        Level currentLevel;
        Input input;

        public Game()
        {
            LevelCreator levelCreator = new LevelCreator();
            Level[] levels = levelCreator.CreateLevels();
            currentLevel = levels[0];
            input = new Input();
        }

        public void StartGame()
        {
            LoadIntro();

            for (int i = 0; i < 5; i++)  // todo: use a while loop here
            {
                string playerInput = input.GetInput();
                string result = EvaluateInput(playerInput, currentLevel.actions);
                Console.WriteLine(result);
            }

        }

        private string EvaluateInput(string playerInput, UserAction[] possibleActions)
        {
            foreach (UserAction possibleAction in possibleActions)
            {
                // todo: need to translate the playerInput here, so it is standardised into
                // take, look, go, open, close, turn on, turn off
                if (playerInput == possibleAction.description)
                {
                    LoadResult(possibleAction.result);
                    return possibleAction.resultDescription;
                }
            }
            return "I don't understand what to do.";
        }

        private void LoadResult(string result)
        {
            string firstWord = result.Split(' ')[0];
            if (firstWord == "get")
            {
                // todo: add phone to inventory instead of the writeline
                Console.WriteLine("You have got a phone!");
            }
            else if (firstWord == "load")
            {
                // todo: load next level
                Console.WriteLine("You are in the next level!");
            }
        }

        private void LoadIntro()
        {
            Console.WriteLine("Hello and welcome to The Return - a classical text adventure");
            Console.WriteLine("---------");
            Console.WriteLine("");
            Console.WriteLine(currentLevel.description);
        }
    }
}