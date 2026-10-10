namespace FirstProject
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            Calculator.Entity calculator = new Calculator.Entity();
            ConsoleManager.Controller.onConsoleClear += () => displayMathExpression(calculator);

            while (running)
            {
                string? input = ConsoleManager.Controller.getUserNumber();

                running = !submited(input);

                if (!running)
                {
                    return;
                }

                calculator.addValue(input);
                ConsoleManager.Controller.updateConsole();
            }
        }

        static void displayMathExpression(Calculator.Entity calculator)
        {
            ConsoleManager.Controller.log(calculator.getExpession());
        }

        static bool submited(string? input)
        {
            return input == "=";
        }
    }
}
