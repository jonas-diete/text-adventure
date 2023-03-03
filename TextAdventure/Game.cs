namespace TextAdventure
{
    public class Game
    {
        Level currentLevel;
        List<Level> levels = new List<Level>();

        public Game()
        {
            LevelCreator levelCreator = new LevelCreator();
            levels = levelCreator.LoadLevelsFromCsv();
            currentLevel = levels[0];
        }

        public void StartGame()
        {
            LoadIntro();
            Console.WriteLine(currentLevel.description);
            Console.WriteLine("What do you want to do?");
            while (currentLevel.name != "end")
            {
                string playerInput = Console.ReadLine()!.ToLower().Trim();
                EvaluateInput(playerInput, currentLevel.actions);
            }
        }

        private void EvaluateInput(string playerInput, List<UserAction> possibleActions)
        {
            foreach (var possibleAction in possibleActions)
            {
                string[] playerInputArray = playerInput.Split(" ");
                playerInputArray[0] = TranslateInput(playerInputArray[0]);
                string updatedPlayerInput = String.Join(" ", playerInputArray);
                string[] actionDescriptions = possibleAction.descriptions.Split(";");           
                if (Array.Exists(actionDescriptions, description => description == updatedPlayerInput))
                {
                    if (possibleAction.requirement == "" || currentLevel.actionsCompleted.Exists(action => action == possibleAction.requirement))
                    {
                        Console.WriteLine(possibleAction.resultDescription);
                        LoadResult(possibleAction.result, possibleAction.resultAttribute);
                        currentLevel.actionsCompleted.Add(actionDescriptions[0]);
                        return; 
                    } 
                    else
                    {
                        Console.WriteLine(possibleAction.reqNotFulfilled);
                        return;
                    }

                }
            }
            Console.WriteLine("I don't understand what to do.");
        }

        public string TranslateInput(string input)
        {
            if (input == "shout" || input == "call" || input == "scream")
            {
                return "say";
            }

            if (input == "walk" || input == "run" || input == "sprint")
            {
                return "go";
            }

            return input;
        }

        private void LoadLevel(string levelName)
        {
            foreach (Level level in levels)
            {
                if (level.name == levelName)
                {
                    currentLevel = level;
                    Console.WriteLine(currentLevel.description);
                    Console.WriteLine("What would you like to do?");
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
            Console.WriteLine("---------");
            Console.WriteLine("Hello and welcome to Into The Light - a text adventure by Jonas Diete");
            Console.WriteLine("---------");
            Console.WriteLine("");
        }
    }
}