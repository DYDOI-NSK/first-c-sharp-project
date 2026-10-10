namespace Calculator
{
    class Entity
    {
        List<string> expression = [];

        Dictionary<string, Func<int, int, int>> mathOperations = new Dictionary<
            string,
            Func<int, int, int>
        >()
        {
            { "+", (value, sum) => value + sum },
            { "-", (value, sum) => value - sum },
            { "*", (value, sum) => value * sum },
            { "/", (value, sum) => value / sum },
        };

        public void addValue(string? input)
        {
            if (input == null)
            {
                return;
            }

            bool expectNumber = expression.Count % 2 == 0;
            bool valid = expectNumber
                ? int.TryParse(input, out _)
                : mathOperations.ContainsKey(input);

            if (valid)
            {
                expression.Add(input);
            }
        }

        public int getResult()
        {
            if (expression.Count == 0)
            {
                return 0;
            }

            List<int> values = [int.Parse(expression[0])];
            List<string> operators = [];

            for (int i = 1; i + 1 < expression.Count; i += 2)
            {
                string operation = expression[i];
                int next = int.Parse(expression[i + 1]);

                if (operation == "*" || operation == "/")
                {
                    values[^1] = mathOperations[operation](values[^1], next);
                }
                else
                {
                    operators.Add(operation);
                    values.Add(next);
                }
            }

            int result = values[0];

            for (int i = 0; i < operators.Count; i++)
            {
                result = mathOperations[operators[i]](result, values[i + 1]);
            }

            return result;
        }

        public string getExpession()
        {
            List<string> result = [string.Join(" ", expression), "=", getResult().ToString()];
            return string.Join(" ", result);
        }
    }
}
