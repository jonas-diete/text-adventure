using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace TextAdventure
{
    public class LevelCreator
    {
        public Level[] CreateLevels()
        {
            // Level 1
            string description = "After a long, hard journey you emerge from the dark place that has been your home for your entire life. Your body aches from the effort and you wish you could have stayed longer in your cosy, warm home. But you know there is no way back. Terrified of the new life that awaits you, you decided to close your eyes for the last part of the journey and haven't yet dared to open them again. Now there is a calm settling in your body. It's over. You have arrived.";
            UserAction action1 = new UserAction("open eyes", "You open your eyes. Everything is bright, bright light! An incredible sensation overcomes you - you feel more alive than ever before! However, the light is so bright that you can't really make out anything. For now you will have to rely on your other senses.", "none");
            UserAction action2 = new UserAction("say hello", "You open your mouth and try to shout but you can just emit a strange scream. Then you hear familiar voices. Voices you have known your whole life. You can't quite make out what they say or where they come from, but they give you confidence. You suddenly feel very tired.", "none");
            UserAction action3 = new UserAction("sleep", "The surface on which you lie is soft and feels very comfortable. You fall asleep just where you are. ", "load", "level2");
            List<UserAction> actions = new List<UserAction>();
            actions.Add(action1); 
            actions.Add(action2);
            actions.Add(action3);
            Level level1 = new Level("level1", description, actions);

            // Level 2
            description = "You wake up and open your eyes. You lie comfortably but you are hungry.";
            UserAction action4 = new UserAction("get up", "You try to stand up but you realise your legs are too weak.", "none");
            UserAction action5 = new UserAction("eat something", "You look around to see if there is any food. Suddenly a large glass barrel is emerging from somewhere and moves towards you. It's filled with a deliciously smelling liquid and has a soft opening at the front, almost like you could drink out of it. You press your mouth onto it and the liquid emerges. It is warm, slightly sweet and very tasty. Probably the best thing you have ever drunk!", "load", "end");
            actions = new List<UserAction>();
            actions.Add(action4); 
            actions.Add(action5);
            Level level2 = new Level("level2", description, actions);

            // Level 3 -- the end
            description = "You have won the game!";
            actions = new List<UserAction>();
            Level level3 = new Level("end", description, actions);

            Level[] levels = { level1, level2, level3 };
            return levels;
        }

        public Level[] LoadLevelsFromCsv()
        {
            // var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            // {
            //     HasHeaderRecord = true
            // };

            using var streamReader = File.OpenText("levels.csv");
            using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);
            csvReader.Read();
            csvReader.ReadHeader();

            List<string> levelAttributes = new List<string>();
            string levelName;
            string levelDescription;
            List<UserAction> actions = new List<UserAction>();

            while (csvReader.Read()) // Reads each level
            {
                levelName = csvReader.GetField("levelName")!;
                levelDescription = csvReader.GetField("description")!;
                UserAction action;
                string actionDescription;
                string actionResultDescription;
                string actionResult;
                string actionResultAttribute;

                for (int i = 0; i < 10; i++)
                {
                    if (csvReader.GetField("action" + i + "Description") != "")
                    {
                        actionDescription = csvReader.GetField("action" + i + "Description")!;
                        actionResultDescription = csvReader.GetField("action" + i + "ResultDescription")!;
                        actionResult = csvReader.GetField("action" + i + "Result")!;
                        actionResultAttribute = csvReader.GetField("action" + i + "ResultAttribute")!;
                        Console.WriteLine(actionDescription + actionResultDescription + actionResult + actionResultAttribute);
                        action = new UserAction(actionDescription, actionResultDescription, actionResult, actionResultAttribute); 
                        // TODO: Make actions a list and make level accept that list as argument not an array!
                    }

                }
                // for (int i = 0; csvReader.TryGetField<string>(i, out value); i++)
                // {
                //     if (value != "")
                //     {
                //         levelAttributes.Add(value);
                //     }
                // }
            }

            // foreach (string attribute in levelAttributes)
            // {
            //     Console.WriteLine(attribute);
            // }

            string description = "Level1";
            actions = new List<UserAction>();
            Level level1 = new Level("level1", description, actions);

            description = "End";
            actions = new List<UserAction>();
            Level level2 = new Level("end", description, actions);
            Level[] levels = { level1, level2 };
            return levels;
        }
    }
}
