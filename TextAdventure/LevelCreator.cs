namespace TextAdventure
{
    public class LevelCreator
    {
        public Level[] CreateLevels()
        {
            string description = "You wake up in a dark space. You can't see anything. It feels like you are lying on a basic mattress. You are wearing your normal clothes: a t-shirt and a pair of jeans. You can feel your phone in one of your jeans pockets.";
            UserAction action1 = new UserAction("take phone", "You take your phone out of your pocket. No signal!", "get phone");
            UserAction action2 = new UserAction("look around", "You try to look around but everything is pitch black - it's impossible to see.", "none");
            UserAction[] actions = { action1, action2 };
            Level level1 = new Level("cave", description, actions);

            Level[] levels = { level1 };
            return levels;
        }
    }
}
