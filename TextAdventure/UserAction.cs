namespace TextAdventure
{
    public class UserAction
    {    
    public string description;
    public string resultDescription;
    public string result;
    public string resultAttribute;
        public UserAction(string actionDescription, string actionResultDescription, string actionResult, string actionResultAttribute = "none")
        {
            description = actionDescription;
            resultDescription = actionResultDescription;
            result = actionResult;
            resultAttribute = actionResultAttribute;
        }
    }
}
