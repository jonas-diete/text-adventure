namespace TextAdventure
{
    internal class UserAction
    {    
    public string description;
    public string result;
    public string resultDescription;
        public UserAction(string actionDescription, string actionResultDescription, string actionResult)
        {
            description = actionDescription;
            result = actionResult;
            resultDescription = actionResultDescription;
        }
    }
}
