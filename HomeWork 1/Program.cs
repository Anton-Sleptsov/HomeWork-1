using System.Threading.Channels;

namespace HomeWork_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите выражение (число оператор число): ");
                string input = Console.ReadLine();

                try
                {
                    int operatorIndex = -1;
                    char[] operators = ['+', '-', '*', '/',':'];
                    foreach (char op in operators)
                    {
                        operatorIndex = input.LastIndexOf(op);
                        if (operatorIndex != -1)
                            break;
                    }

                    if (operatorIndex == -1)
                    {
                        ShowErrorMessage("оператор не найден!");
                        continue;
                    }

                    string num1Str = input.Substring(0, operatorIndex);
                    string opStr = input.Substring(operatorIndex, 1);
                    string num2Str = input.Substring(operatorIndex + 1);
                    
                    if(num1Str[num1Str.Length - 1] == '-')
                    {
                        num1Str = num1Str.Substring(0, num1Str.Length - 1);
                        num2Str = "-" + num2Str;
                    }

                    double num1 = double.Parse(num1Str);
                    double num2 = double.Parse(num2Str);

                    double result;

                    switch (opStr)
                    {
                        case "+":
                            result = num1 + num2;
                            break;
                        case "-":
                            result = num1 - num2;
                            break;
                        case "*":
                            result = num1 * num2;
                            break;
                        case "/":
                        case ":":
                            if (num2 == 0)
                            {
                                ShowErrorMessage("на 0 делить нельзя!");
                                continue;
                            }
                            result = num1 / num2;
                            break;
                        default:
                            ShowErrorMessage("неверный оператор!");
                            continue;
                    }

                    ShowResult(result);
                }
                catch (FormatException)
                {
                    ShowErrorMessage("некорректный ввод чисел!");
                }
                catch (Exception e)
                {
                    ShowErrorMessage(e.Message);
                }

                Console.Write("Нажмите ESC для выхода или любую другую клавишу, чтобы продолжить");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    break;

                Console.WriteLine();
            }
        }

        static void ShowErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка: " + message);
            Console.ResetColor();
        }

        static void ShowResult(double result)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Результат: " + result);
            Console.ResetColor();
        }
    }
}
