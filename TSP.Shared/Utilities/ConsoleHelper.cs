namespace TSP.Shared.Utilities
{
    public static class ConsoleHelper
    {
        public static async Task TypeWriter(string text, int delay = 25)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                await Task.Delay(delay);
            }
            Console.WriteLine();
        }
    }
}
