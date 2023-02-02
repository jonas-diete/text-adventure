namespace TextAdventure
{
    public class LevelCreator
    {
        public Level[] CreateLevels()
        {
            string description = "After a long, hard journey you emerge from the dark place that has been your home for your entire life. Your body aches from the effort and you wish you could have stayed longer in your cosy, warm home. But you know there is no way back. Terrified of the new life that awaits you, you decided to close your eyes for the last part of the journey and haven't yet dared to open them again. Now there is a calm settling in your body. It's over. You have arrived.";
            UserAction action1 = new UserAction("open eyes", "You open your eyes. Everything is bright, bright light! An incredible sensation overcomes you - you feel more alive than ever before! However, the light is so bright that you can't really make out anything. For now you will have to rely on your other senses.", "none");
            UserAction action2 = new UserAction("shout hello", "You open your mouth and try to shout but you can just emit a strange scream. Then you hear familiar voices. Voices you have known your whole life. You can't quite make out what they say or where they come from, but they give you confidence. You suddenly feel very tired.", "none");
            UserAction action3 = new UserAction("sleep", "The surface on which you lie is soft and feels very comfortable. You fall asleep just where you are. ", "load level2");
            UserAction[] actions = { action1, action2, action3 };
            Level level1 = new Level("level1", description, actions);

            Level[] levels = { level1 };
            return levels;
        }
    }
}
