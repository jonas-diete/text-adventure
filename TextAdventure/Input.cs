namespace TextAdventure
{
    public class Input
    {
        public string GetInput()
        {
            Console.WriteLine("What do you want to do?");
            string playerInput = Console.ReadLine()!.ToLower();
            return playerInput;
        }
    }
}