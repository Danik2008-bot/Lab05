using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 2)
        {
            // dotnet run -- <входной файл> <выходной файл>
            RunGame(args[0], args[1]);
            return;
        }

        // по умолчанию прогоняем три теста и сравниваем с эталонными логами
        for (int i = 1; i <= 3; i++)
        {
            string input = "data/" + i + ".ChaseData.txt";
            string output = "out/" + i + ".PursuitLog.txt";
            string expected = "data/" + i + ".PursuitLog.txt";

            RunGame(input, output);

            bool ok = Normalize(File.ReadAllText(output)) == Normalize(File.ReadAllText(expected));
            string result = ok ? "OK" : "FAILED";
            Console.WriteLine("Test " + i + ": " + result);
            Console.WriteLine();
        }
    }

    static void RunGame(string input, string output)
    {
        // через статические поля класса Game задаём пути к входному и выходному файлам
        Game.InputFile = input;
        Game.OutFile = output;

        Game game = new Game(Game.ReadFieldSize());
        game.Run(); // запуск игры и вывод результатов
    }

    // чтобы различие \r\n и \n не влияло на сравнение
    static string Normalize(string text)
    {
        return text.Replace("\r\n", "\n");
    }
}
