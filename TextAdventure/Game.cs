namespace TextAdventure
{
    public class Game
    {
        Level currentLevel;
        List<Level> levels = new List<Level>();
        string intro;
        List<string> inventory = new List<string>();

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
                Console.WriteLine(EvaluateInput(playerInput, currentLevel.actions));
            }
            Console.ReadLine();
        }

        private string EvaluateInput(string playerInput, List<UserAction> possibleActions)
        {
            foreach (var possibleAction in possibleActions)
            {
                string[] actionDescriptions = possibleAction.descriptions.Split(";");
                if (Array.Exists(actionDescriptions, description => description == TranslateInput(playerInput)))
                {
                    if (possibleAction.requirement == "" || currentLevel.actionsCompleted.Exists(action => action == possibleAction.requirement))
                    {
                        currentLevel.actionsCompleted.Add(actionDescriptions[0]);
                        return possibleAction.resultDescription + GetResult(possibleAction.result, possibleAction.resultAttribute); 
                    } 
                    else
                    {
                        return possibleAction.reqNotFulfilled;
                    }
                }
            }
            return "I don't understand what to do.";
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

        private string GetLevel(string levelName)
        {
            foreach (Level level in levels)
            {
                if (level.name == levelName)
                {
                    currentLevel = level;
                    string result = "\n\n" + currentLevel.description;
                    if (level.name != "end") 
                        {
                            result += "\nWhat do you want to do?"; 
                        }
                    return result;
                }
            }
            return "Error: Level doesn't exist.";
        }

        private string GetResult(string result, string attribute)
        {
            if (result == "get")
            {
                inventory.Add(attribute);
            }
            else if (result == "load")
            {
                return GetLevel(attribute);
            }
            return "";
        }
    }
}