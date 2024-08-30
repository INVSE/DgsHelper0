using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgsHelper0
{
    internal class DiagnosisRunner
    {
        public void Execute(DiagnosisNode node)
        {
            // Проверяем, является ли текущий узел вопросом
            if (node.Text.StartsWith("Q:"))
            {
                Console.WriteLine(node.Text.Substring(2).Trim());

                // Выводим варианты ответов
                for (int i = 0; i < node.Children.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {node.Children[i].Text.Trim()}");
                }

                // Получаем выбор пользователя
                if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= node.Children.Count)
                {
                    // Переходим к выбранному узлу, если выбор корректный
                    Execute(node.Children[choice - 1]);
                }
                else
                {
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    Execute(node);  // Повторяем вопрос при некорректном выборе
                }
            }
            else if (node.Text.StartsWith("R:"))
            {
                // Если узел является результатом, выводим его и завершаем выполнение
                Console.WriteLine(node.Text.Substring(2).Trim());
            }
            else
            {
                // Если узел - это промежуточный ответ, переходим к его дочернему узлу
                if (node.Children.Count > 0)
                {
                    Execute(node.Children[0]);
                }
                else
                {
                    // Если у промежуточного ответа нет дочерних узлов, выводим ошибку
                    Console.WriteLine("Некорректный формат файла диагностики. Узел не имеет дочерних элементов.");
                }
            }
        }
    }
}
