﻿namespace TextAdventure
{
    public class Level
    {
        public string name;
        public string description;
        public UserAction[] actions;

        public Level(string levelName, string levelDescription, UserAction[] levelActions)
        {
            name = levelName;
            description = levelDescription;
            actions = levelActions;
        }
    }
}
