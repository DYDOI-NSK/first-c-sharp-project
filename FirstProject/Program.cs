interface IMathExpController
{
    void updateMathExp(string? value);
    string getMathExp();
    string getResult();
}

class MathExpControllerImpl(Action<string?> update, Func<string> get, Func<string> getFullResult)
    : IMathExpController
{
    public void updateMathExp(string? value) => update(value);

    public string getMathExp() => get();

    public string getResult() => getFullResult();
}

namespace FirstProject
{
    class Program
    {
        static void Main(string[] args)
        {
            MathExpControllerImpl expControlls = createMathExp()();

            string? firstInput = getUserNumber();
            updateConsole(expControlls, firstInput);
            string? secondInput = getUserNumber();
            updateConsole(expControlls, secondInput);

            Console.Clear();
            Console.WriteLine(expControlls.getResult());
        }

        static Func<MathExpControllerImpl> createMathExp()
        {
            List<string> mathExp = [];

            string get()
            {
                return string.Join(" + ", mathExp);
            }

            return () =>
                new MathExpControllerImpl(
                    update: (value) =>
                    {
                        if (value == null)
                        {
                            return;
                        }

                        mathExp.Add(value);
                    },
                    get,
                    getFullResult: () =>
                    {
                        List<string> result =
                        [
                            get(),
                            "=",
                            mathExp
                                .ConvertAll(element => Convert.ToInt32(element))
                                .Sum()
                                .ToString(),
                        ];
                        return string.Join(" ", result);
                    }
                );
        }

        static void updateConsole(MathExpControllerImpl expController, string? value)
        {
            Console.Clear();
            expController.updateMathExp(value);
            Console.WriteLine(expController.getMathExp());
        }

        static string? getUserNumber()
        {
            Console.WriteLine("Insert number to add:");
            return Console.ReadLine();
        }
    }
}
