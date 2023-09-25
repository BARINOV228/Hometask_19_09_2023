using System;
using System.IO;

namespace TestGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в генератор тестов!");

            Console.WriteLine("Введите название предмета для создания теста:");
            string subject = Console.ReadLine();

            string CleanSubject = subject.Replace(" ", "_"); // Заменяем пробелы на символ подчеркивания

            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), CleanSubject);
            Directory.CreateDirectory(directoryPath);

            Console.WriteLine($"Папка {CleanSubject} успешно создана на рабочем столе.");

            Console.WriteLine("Введите количество вопросов в тесте:");
            int questionCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество вариантов ответов для каждого вопроса:");
            int answerCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= questionCount; i++)
            {
                Console.WriteLine($"Введите вопрос {i}:");
                string question = Console.ReadLine();

                string testFileName = $"Test{i}.txt";
                string testFilePath = Path.Combine(directoryPath, testFileName);

                using (StreamWriter writer = new StreamWriter(testFilePath))
                {
                    writer.WriteLine(question);

                    for (int j = 1; j <= answerCount; j++)
                    {
                        Console.WriteLine($"Введите вариант ответа {j}:");
                        string answer = Console.ReadLine();

                        writer.WriteLine(answer);
                    }
                }

                Console.WriteLine($"Тест {i} успешно создан и сохранен в файле {testFileName}.");
            }

            Console.WriteLine("Генерация тестов завершена. Спасибо за использование!");
        }
    }
}