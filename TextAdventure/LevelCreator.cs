using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace TextAdventure
{
    public class LevelCreator
    {
        public List<Level> LoadLevelsFromCsv()
        {
            using var streamReader = File.OpenText("levels.csv");
            using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);
            csvReader.Read();
            csvReader.ReadHeader();

            string levelName;
            string levelDescription;
            Level level;
            List<Level> levels = new List<Level>();

            while (csvReader.Read()) // Reads each level
            {
                levelName = csvReader.GetField("levelName")!;
                levelDescription = csvReader.GetField("description")!;
                UserAction action;
                List<UserAction> actions = new List<UserAction>();

                // reads the actions and creates them as objects
                for (int i = 0; i < 10; i++)
                {
                    if (csvReader.GetField("action" + i + "Description") != "")
                    {
                        action = new UserAction(csvReader.GetField("action" + i + "Description")!, csvReader.GetField("action" + i + "ResultDescription")!, csvReader.GetField("action" + i + "Result")!, csvReader.GetField("action" + i + "ResultAttribute")!, csvReader.GetField("action" + i + "Requirement")!, csvReader.GetField("action" + i + "ReqNotFulfilled")!); 
                        actions.Add(action);
                    }
                }

                level = new Level(levelName, levelDescription, actions);
                levels.Add(level);
            }

            return levels;
        }
    }
}
