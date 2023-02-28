namespace TextAdventure
{
    public class Level
    {
        public string name;
        public string description;
        public List<UserAction> actions = new List<UserAction>();

        public Level(string levelName, string levelDescription, List<UserAction> levelActions)
        {
            name = levelName;
            description = levelDescription;
            actions = levelActions;
        }
    }
}
