using System;
using System.IO;
using System.Globalization;

namespace task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Проверяем наличие аргументов командной строки
            if (args.Length == 0)
            {
                Console.WriteLine("Укажите путь к файлу с массивом чисел.");
                return;
            }
            string filePath = args[0];

            // Считываем числа из файла и заносим в массив
            string[] lines = File.ReadAllLines(filePath);
            int[] nums = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                nums[i] = int.Parse(lines[i], CultureInfo.InvariantCulture);
            }

            // вычисляем медианное значение
            Array.Sort(nums);
            double median;
            
            if (nums.Length % 2 == 1)
            {
                median = (nums[nums.Length / 2 - 1] + nums[nums.Length / 2]) * 0.5;
            }
            else
            {
                median = nums[nums.Length / 2];
            }

            //приводим массив к медианному значению за один ход уменьшая или увеличивая число массива на 1
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                while (nums[i] != Math.Round(median))
                {
                    if (nums[i] < median)
                    { nums[i]++; count++; }
                    else { nums[i]--; count++; }

                }
            }
			Console.Write(count);
        }
    }
}
