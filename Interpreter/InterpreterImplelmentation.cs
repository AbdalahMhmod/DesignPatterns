namespace Interpreter
{
    public class InterpreterClient
    {
        private readonly InterpreterContext _interpreterContext;

        public InterpreterClient(InterpreterContext interpreterContext)
        {
            _interpreterContext = interpreterContext;
        }

        public string Interpret(string str)
        {
            IExpression expression;
            if(str.Contains("Hexadecimal"))
            {
                expression = new IntToHexadecimalExpression(int.Parse(str.Split(' ')[0]));
            }
            else if(str.Contains("Binary"))
            {
                expression = new IntToBinaryExpression(int.Parse(str.Split(' ')[0]));
            }
            else
            {
                return str;
            }

            return expression.Interpret(_interpreterContext);
        }
    }

    public class IntToBinaryExpression : IExpression
    {
        private readonly int _value;

        public IntToBinaryExpression(int value)
        {
            _value = value;
        }

        public string Interpret(InterpreterContext interpreterContext)
        {
            return interpreterContext.GetBinanryFormat(_value);
        }
    }

    public class IntToHexadecimalExpression : IExpression
    {
        private readonly int _value;

        public IntToHexadecimalExpression(int value)
        {
            _value = value;
        }

        public string Interpret(InterpreterContext interpreterContext)
        {
            return interpreterContext.GetHexadecimalFormat(_value);
        }
    }

    public interface IExpression
    {
        string Interpret(InterpreterContext interpreterContext);
    }

    public class InterpreterContext
    {
        internal string GetBinanryFormat(int value)
        {
            return Convert.ToString(value, 2);
        }

        internal string GetHexadecimalFormat(int value)
        {
            return Convert.ToString(value, 16);
        }
    }
}
