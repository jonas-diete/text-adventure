namespace TextAdventure
{
    public class UserAction
    {    
    public string descriptions;
    public string resultDescription;
    public string result;
    public string resultAttribute;
    public string requirement;
    public string reqNotFulfilled;

        public UserAction(string actionDescriptions, string actionResultDescription, string actionResult, string actionResultAttribute = "none", string actionRequirement = "none", string descriptionWhenReqNotFulfilled = "none")
        {
            descriptions = actionDescriptions;
            resultDescription = actionResultDescription;
            result = actionResult;
            resultAttribute = actionResultAttribute;
            requirement = actionRequirement;
            reqNotFulfilled = descriptionWhenReqNotFulfilled;
        }
    }
}
