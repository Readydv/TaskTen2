using System;
using System.IO;
using TaskTen2;

namespace MiniCalculator
{
    class Program
    {

        static ILogger Logger { get; set; }

        static void Main(string[] args)
        {

            Logger = new Logger();

            var worker1 = new Worker1(Logger);
            worker1.Work();

            ISumCalculator sumCalculator = new SumCalculator();
            double number1 = 0;
            double number2 = 0;

            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Введите первое число:");
                number1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Введите второе число:");
                number2 = Convert.ToDouble(Console.ReadLine());

                double result = sumCalculator.Sum(number1, number2);
                Console.WriteLine($"Сумма равна: {result}");
            }
            catch (FormatException)
            {
                Logger.Error("Ошибка: Введенное значение не является числом");
            }
            catch (OverflowException)
            {
                Logger.Error("Ошибка: Введенное значение слишком велико или слишком мало");
            }
            finally
            {
                Worker2 worker2 = new Worker2(Logger);
                worker2.Work();
            }
        }
    }

    public interface ISumCalculator
    {
        double Sum(double num1, double num2);
    }

    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }

    public interface IWorker
    {
        void Work();
    }


    public class SumCalculator : ISumCalculator
    {
        public double Sum(double num1, double num2)
        {
            return num1 + num2;
        }
    }

    public class Logger : ILogger
    {
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }

        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
        }
    }
}