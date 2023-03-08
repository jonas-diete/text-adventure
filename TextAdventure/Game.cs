namespace TextAdventure
{
    public class Game
    {
        Level currentLevel;
        List<Level> levels = new List<Level>();
        string intro;

        public Game()
        {
            LevelCreator levelCreator = new LevelCreator();
            levels = levelCreator.LoadLevelsFromCsv();
            currentLevel = levels[0];
            intro = "\n------------------------------------------------------------\nWelcome to Into The Light - a text adventure by Jonas Diete\n------------------------------------------------------------\n\n";
        }

        public void StartGame()
        {
            Console.WriteLine(intro + currentLevel.description + "\n\n" + "What do you want to do?");
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
                string[] actionDescriptions = possibleAction.descriptions.Split(";");
                if (Array.Exists(actionDescriptions, description => description == TranslateInput(playerInput)))
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
            string[] playerInputArray = input.Split(" ");
            playerInputArray[0] = Translate(playerInputArray[0]);
            return String.Join(" ", playerInputArray);
        }

        private string Translate(string input)
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
                    Console.WriteLine("");
                    Console.WriteLine(currentLevel.description);
                    if (level.name != "end") { Console.WriteLine("What would you like to do?"); }
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
            Console.WriteLine("\n------------------------------------------------------------\nWelcome to Into The Light - a text adventure by Jonas Diete\n------------------------------------------------------------\n");
        }
    }
}