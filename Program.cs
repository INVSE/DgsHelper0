namespace DgsHelper0
{
    using System;
    using System.IO;
    using System.Linq;

    class DiagnosisProgram
    {
        static void Main(string[] args)
        {
            string dgsPath = Path.Combine(Directory.GetCurrentDirectory(), "Dgs");

            if (!Directory.Exists(dgsPath))
            {
                Console.WriteLine("Папка с диагностикой не найдена.");
                return;
            }

            var files = Directory.GetFiles(dgsPath, "*.txt");

            if (files.Length == 0)
            {
                Console.WriteLine("Нет доступных файлов диагностики.");
                return;
            }

            Console.WriteLine("Выберите диагностику:");
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {Path.GetFileNameWithoutExtension(files[i])}");
            }

            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= files.Length)
            {
                string selectedFile = files[choice - 1];

                var diagnosisTree = new DiagnosisTree(selectedFile);
                var diagnosisRunner = new DiagnosisRunner();
                diagnosisRunner.Execute(diagnosisTree.Root);
            }
            else
            {
                Console.WriteLine("Неверный выбор.");
            }
        }
    }
}
