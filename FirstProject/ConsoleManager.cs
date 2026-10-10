namespace ConsoleManager
{
    static class Controller
    {
        public static event Action onConsoleClear;

        public static void log<T>(T value)
        {
            Console.WriteLine(value);
        }

        public static void updateConsole()
        {
            Console.Clear();

            if (onConsoleClear != null)
            {
                onConsoleClear();
            }
        }

        public static string? getUserNumber()
        {
            Console.WriteLine("Insert number or operator (+ - * /), = to finish:");
            string? input = Console.ReadLine();
            updateConsole();
            return input;
        }
    }
}
