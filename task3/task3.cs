using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("На вход программы должны передаваться три пути к файлам: <values.json> <tests.json> <report.json>");
                return;
            }
            string path_values = args[0];
            string path_tests = args[1];
            string path_report = args[2];

            // считываем и десериализуем полученные файлы
            var valuesFileContent = File.ReadAllText(path_values);
            var testsFileContent = File.ReadAllText(path_tests);
            var valuesData = JsonConvert.DeserializeObject<ValuesFile>(valuesFileContent);
            var testsData = JsonConvert.DeserializeObject<TestReport>(testsFileContent);

            // создаем словарь для поиска по id
            Dictionary<int, string> valuesDictionary = new Dictionary<int, string>();
            foreach (var value in valuesData.Values)
            {
                valuesDictionary[value.Id] = value.Value;
            }

            // заполняем поля в tests, сериализуем и записываем в файл
            FillValues(testsData.Tests, valuesDictionary);
            var reportContent = JsonConvert.SerializeObject(testsData, Formatting.Indented);            
            File.WriteAllText(path_report, reportContent);
        }


        // логика записи полей в структуре
        static void FillValues(List<Test> tests, Dictionary<int, string> valuesDictionary)
        {
            foreach (var test in tests)
            {
                if (valuesDictionary.TryGetValue(test.Id, out var value))
                {
                    test.Value = value;
                }

                if (test.Values != null && test.Values.Count > 0)
                {
                    FillValues(test.Values, valuesDictionary);
                }
            }
        }
        public class Test
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Value { get; set; }
            public List<Test> Values { get; set; }
        }
        public class TestReport
        {
            public List<Test> Tests { get; set; }
        }
        public class TestValue
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }
        public class ValuesFile
        {
            public List<TestValue> Values { get; set; }
        }
    }
}