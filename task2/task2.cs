using System;
using System.Globalization;
using System.IO;


namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Пути к файлам передаются программе в качестве аргументов");
                return;
            }            

            string path_circle = args[0];
            string path_point = args[1];

            //читаем и записываем входные данные из файлов, соблюдая региональное нормы разделения дробной части
            string[] circle_xy_r = File.ReadAllLines(path_circle);           
            string[] circle_xy = circle_xy_r[0].Split();
            float circle_x = float.Parse(circle_xy[0], CultureInfo.InvariantCulture);
            float circle_y = float.Parse(circle_xy[1], CultureInfo.InvariantCulture);
            float circle_r = float.Parse(circle_xy_r[1], CultureInfo.InvariantCulture);
            string[] pointsData = File.ReadAllLines(path_point);

            //перебор точек
            foreach (string point in pointsData)
            {
                string[] pointCoordinates = point.Split();
                float point_x = float.Parse(pointCoordinates[0], CultureInfo.InvariantCulture);
                float point_y = float.Parse(pointCoordinates[1], CultureInfo.InvariantCulture);

                // расчет положения точки относительно окружности согласно формуле
                // (x — x0) ^ 2 + (y — y0) ^ 2 = r ^ 2
                float dx = point_x - circle_x;
                float dy = point_y - circle_y;
                float distance_pow = dx * dx + dy * dy;
                float radius_pow = circle_r * circle_r;

                if (distance_pow == radius_pow)
                {
                    Console.WriteLine(0); // 0 - точка лежит на окружности
                }
                else if (distance_pow < radius_pow)
                {
                    Console.WriteLine(1); // 1 - точка внутри
                }
                else
                {
                    Console.WriteLine(2); // 2 - точка снаружи
                }
            }            
        }    
    }
}
