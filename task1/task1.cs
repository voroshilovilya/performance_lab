using System;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Программа ожидает что параметры передадутся в качестве аргументов командной строки
            if (args.Length != 2)
            {
                Console.WriteLine("Параметры передаются в качестве аргументов командной строки");
                return;
            }

            int n = int.Parse(args[0]);
            int m = int.Parse(args[1]);

            //создание с последующим заполнением массива
            int[] c_array = new int[n];
            for (int i = 0; i < n; i++)
            {
                c_array[i] = i + 1;
            }

            //перебор массива до первого замыкания            
            int current_index = 0;
            
            do
            {
                Console.Write(c_array[current_index]);
                current_index = (current_index + m - 1) % n;
            } 
            while (current_index != 0);
        } 
    }
    
}
