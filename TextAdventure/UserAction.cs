namespace TextAdventure
{
    public class UserAction
    {    
    public string descriptions;
    public string resultDescription;
    public string result;
    public string resultAttribute;
        public UserAction(string actionDescriptions, string actionResultDescription, string actionResult, string actionResultAttribute = "none")
        {
            descriptions = actionDescriptions;
            resultDescription = actionResultDescription;
            result = actionResult;
            resultAttribute = actionResultAttribute;
        }
    }
}
