using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorManager
    {
        private List<string> operators;
        private List<string> standart_operators = new List<string>(new string[] { "(", ")", "+", "-", "*", "/" });

        public CalculatorManager(params string[] operatorList)
        {
            if (operatorList.Length == 0)
                operators = new List<string>(standart_operators);
            else
                operators = new List<string>(operatorList);

        }

        private IEnumerable<string> Separate(string input)
        {
            List<string> inputSeparated = new List<string>();
            int pos = 0;
            while (pos < input.Length)
            {
                string s = string.Empty + input[pos];
                if (!standart_operators.Contains(input[pos].ToString()))
                {
                    if (Char.IsDigit(input[pos]))
                        for (int i = pos + 1; i < input.Length &&
                            (Char.IsDigit(input[i]) || input[i] == ',' || input[i] == '.'); i++)
                            s += input[i];
                    else if (Char.IsLetter(input[pos]))
                        for (int i = pos + 1; i < input.Length &&
                            (Char.IsLetter(input[i]) || Char.IsDigit(input[i])); i++)
                            s += input[i];
                }
                yield return s;
                pos += s.Length;
            }
        }

        private byte GetOperationPriority(string s)
        {
            switch (s)
            {
                case "(":
                    return 1;
                case ")":
                    return 2;
                case "+":
                    return 3;
                case "-":
                    return 4;
                case "*":
                case "/":
                    return 5;
                default:
                    return 0;
            }
        }

        string ReplaceMinus(string input)
        {
            StringBuilder result = new StringBuilder(input.Length);
            int start = 0;

            if (input[0] == '-')
            {
                for (int j = 1; j < input.Length; j++)
                {
                    if (operators.Contains(input[j].ToString()))
                    {
                        var tmp = input.Substring(0, j);
                        result.Append("0" + tmp);
                        start = j;
                        break;
                    }
                    if (j == input.Length - 1)
                    {
                        var tmp = input.Substring(0);
                        result.Append("(0" + tmp + ")");
                    }
                }
            }

            for (int i = start; i < input.Length; i++)
            {
                if (input[i] == '-' && input[i - 1] != ')' && operators.Contains(input[i - 1].ToString()))
                {
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (operators.Contains(input[j].ToString()))
                        {
                            var tmp = input.Substring(i, j - i);
                            result.Append("0" + tmp + ")");
                            i = j;
                            break;
                        }
                        if (j == input.Length - 1)
                        {
                            var tmp = input.Substring(i);
                            result.Append("0" + tmp + ")");
                            i = j;
                        }
                    }
                }
                else
                    result.Append(input[i]);
            }

            return result.ToString();
        }

        public string[] ConvertToPostfixNotation(string input)
        {
            List<string> outputSeparated = new List<string>();
            Stack<string> stack = new Stack<string>();

            input = ReplaceMinus(input.Trim());

            foreach (string c in Separate(input))
            {
                if (operators.Contains(c))
                {
                    if (stack.Count > 0 && !c.Equals("("))
                    {
                        if (c.Equals(")"))
                        {
                            string s = stack.Pop();
                            while (s != "(")
                            {
                                outputSeparated.Add(s);
                                s = stack.Pop();
                            }
                        }
                        else if (GetOperationPriority(c) >= GetOperationPriority(stack.Peek()))
                            stack.Push(c);
                        else
                        {
                            while (stack.Count > 0 && GetOperationPriority(c) < GetOperationPriority(stack.Peek()))
                                outputSeparated.Add(stack.Pop());
                            stack.Push(c);
                        }
                    }
                    else
                        stack.Push(c);
                }
                else
                    outputSeparated.Add(c);
            }
            if (stack.Count > 0)
                foreach (string c in stack)
                    outputSeparated.Add(c);

            return outputSeparated.ToArray();
        }


        public static string Calculate(params string[] values)
        {
            Stack<string> stack = new Stack<string>();

            string[] operation = new string[] { "/", "*", "+", "-" };

            foreach (var item in values)
            {
                if (operation.Contains(item))
                {
                    double a;
                    double b;

                    string sb = stack.Pop();
                    string sa = stack.Pop();

                    if (!double.TryParse(sa, out a) | !double.TryParse(sb, out b)) { Console.WriteLine("Error!!!"); }

                    if (item == "/") stack.Push((a / b).ToString());
                    if (item == "*") stack.Push((a * b).ToString());
                    if (item == "+") stack.Push((a + b).ToString());
                    if (item == "-") stack.Push((a - b).ToString());
                }
                else
                {
                    stack.Push(item);
                }
            }

            return stack.Pop();
        }
    }

    
}
