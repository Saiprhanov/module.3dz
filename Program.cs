using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module3dz
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 1: Напечатать весь массив целых чисел
            int[] arr = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Массив: ");
            Console.WriteLine(string.Join(", ", arr));

            //Задание 2: Найти индекс масимального значения в массиве
            int MaxIndex = Array.IndexOf(arr, arr.Max());
            Console.WriteLine($"Индекс максимального значения: {MaxIndex}");

            //Задание 3: Найти индекс максимального четного значения в массиве
            int MaxChetnijIndex = Array.IndexOf(arr.Where(x => x % 2 == 0).ToArray(), arr.Where(x => x % 2 == 0).Max());
            Console.WriteLine($"Индекс максимального четного число: {MaxChetnijIndex}");

            //Задание 4: Удалить элемент из массива по индексу
            int indexToDelete = 3;
            arr = arr.Where((element, index) => index != indexToDelete).ToArray();
            Console.WriteLine($"Массив после удаления элемента по индексу {indexToDelete}: {string.Join(", ", arr)}");

            // Задание 5: Удаление элементов из массива по значению
            int valueToDelete = 2;
            arr = arr.Where(element => element != valueToDelete).ToArray();
            Console.WriteLine($"Массив после удаления элементов со значением {valueToDelete}: {string.Join(", ", arr)}");

            // Задание 6: Вставить элемент в массив по индексу
            int valueToInsert = 99;
            int indexToInsert = 1;
            arr = arr.Take(indexToInsert).Concat(new[] { valueToInsert }).Concat(arr.Skip(indexToInsert)).ToArray();
            Console.WriteLine($"Массив после вставки {valueToInsert} по индексу {indexToInsert}: {string.Join(", ", arr)}");

            // Задание 7: Удалить те элементы массива, которые встречаются в нем ровно два раза
            arr = arr.GroupBy(x => x).Where(group => group.Count() != 2).SelectMany(group => group).ToArray();
            Console.WriteLine($"Массив после удаления элементов, которые встречаются ровно два раза: {string.Join(", ", arr)}");

            // Задание 8: Удалить из строки слова, в которых есть буква 'a'
            string inputString = "Это пример, анаконда, арбуз";
            string[] words = inputString.Split(' ');
            words = words.Where(word => !word.Contains('а')).ToArray();
            string resultString = string.Join(" ", words);
            Console.WriteLine($"Строка после удаления слов с буквой 'a': {resultString}");

            // Задание 9: Удалить из строки слова, в которых есть хоть одна буква последнего слова
            string lastWord = words.Last();
            words = words.Where(word => !word.Intersect(lastWord).Any()).ToArray();
            resultString = string.Join(" ", words);
            Console.WriteLine($"Строка после удаления слов с буквами из последнего слова: {resultString}");

            // Задание 10: Выделить квадратными скобками слова, начинающиеся и заканчивающиеся одной буквой
            words = inputString.Split(' ');
            words = words.Select(word =>
            {
                if (word.Length > 2 && word[0] == word[word.Length - 1])
                    return $"[{word}]";
                return word;
            }).ToArray();
            resultString = string.Join(" ", words);
            Console.WriteLine($" Строка с выделенными квадратными скобками: {resultString}");

            // Задание 11: Обнулить элементы тех строк, на пересечении которых с главной диагональю стоит четный элемент
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == j && matrix[i, j] % 2 == 0)
                    {
                        for (int k = 0; k < cols; k++)
                        {
                            matrix[i, k] = 0;
                        }
                    }
                }
            }
            Console.WriteLine("Матрица после обнуления элементов:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }

            // Задание 12: Обнулить элементы тех столбцов, на пересечении которых с главной диагональю стоит четный элемент
            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (i == j && matrix[i, j] % 2 == 0)
                    {
                        for (int k = 0; k < rows; k++)
                        {
                            matrix[k, j] = 0;
                        }
                    }
                }
            }
            Console.WriteLine("Матрица после обнуления элементов в столбцах:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }

            // Задание 13: Удалить те столбцы, в которых встречается хотя бы два одинаковых элемента
            var columnsToDelete = Enumerable.Range(0, cols).Where(col =>
            {
                var columnValues = new int[rows];
                for (int row = 0; row < rows; row++)
                {
                    columnValues[row] = matrix[row, col];
                }
                return columnValues.GroupBy(x => x).Any(group => group.Count() >= 2);
            }).ToList();

            foreach (var col in columnsToDelete.OrderByDescending(c => c))
            {
                matrix = DeleteColumn(matrix, col);
            }

            Console.WriteLine("Матрица после удаления столбцов:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols - columnsToDelete.Count; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }

            // Задание 14: Подсчитать количество пробелов во вводе до ввода точки
            int spaceCount = 0;
            char inputChar;
            do
            {
                inputChar = Console.ReadKey().KeyChar;
                if (inputChar == ' ')
                {
                    spaceCount++;
                }
            } while (inputChar != '.');
            Console.WriteLine($"\nКоличество пробелов: {spaceCount}");

            //Задание 16: Числовые значения символов нижнего регистра в коде ASCII отличаются от значений символов верхнего регистра на величину 32.
            //Используя эту информацию, написать программу,
            //которая считывает с клавиатуры и конвертирует все символы нижнего регистра в символы верхнего регистра и наоборот.

            Console.Write("Введите строку: ");
            string inputString2 = Console.ReadLine();
            char[] convertedChars = inputString2.ToCharArray();
            for (int i = 0; i < convertedChars.Length; i++)
            {
                if (char.IsLower(convertedChars[i]))
                {
                    convertedChars[i] = char.ToUpper(convertedChars[i]);
                }
                else if (char.IsUpper(convertedChars[i]))
                {
                    convertedChars[i] = char.ToLower(convertedChars[i]);
                }
            }
            string convertedString = new string(convertedChars);
            Console.WriteLine($"Преобразованная строка: {convertedString}");


            // Задание 15: Проверить, является ли номер трамвайного билета счастливым
            Console.Write("Введите номер трамвайного билета (6-значное число): ");
            string ticketNumber = Console.ReadLine();
            if (ticketNumber.Length == 6)
            {
                int sumFirstHalf = 0;
                int sumSecondHalf = 0;
                for (int i = 0; i < 3; i++)
                {
                    sumFirstHalf += int.Parse(ticketNumber[i].ToString());
                    sumSecondHalf += int.Parse(ticketNumber[i + 3].ToString());
                }
                if (sumFirstHalf == sumSecondHalf)
                {
                    Console.WriteLine("Этот билет счастливый!");
                }
                else
                {
                    Console.WriteLine("Этот билет не счастливый.");
                }
            }
            else
            {
                Console.WriteLine("Неправильный формат номера билета.");
            }
        }

        static int[,] DeleteColumn(int[,] matrix, int columnIndex)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] newMatrix = new int[rows, cols - 1];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0, newCol = 0; j < cols; j++)
                {
                    if (j != columnIndex)
                    {
                        newMatrix[i, newCol] = matrix[i, j];
                        newCol++;
                    }
                }
            }
            return newMatrix;
        }
    }
}
