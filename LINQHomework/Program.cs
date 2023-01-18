using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQHomework
{
    class Program
    {

        static void Main(string[] args)
        {

            var persons = new List<Person>
            {
                new Person { Name = "Антон", Age = 12},
                new Person { Name = "Георг", Age = 17},
                new Person { Name = "Андрей", Age = 19},
                new Person { Name = "Василий", Age = 23},
                new Person { Name = "Мария", Age = 55},
                new Person { Name = "Анастасия", Age = 28},
                new Person { Name = "Иван", Age = 36},
                new Person { Name = "Петр", Age = 55},
                new Person { Name = "Лаврентий", Age = 12}
            };
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine(string.Join(", ", list.Top(30)));

            var listPerson = new List<string>();
            var filterPersons = persons.Top(30, x => x.Age);

            //Вывод в консоль
            foreach (var item in filterPersons)
            {
                listPerson.Add($"{item.Name}: {item.Age}");
            }

            Console.WriteLine(string.Join(' ', listPerson));
        }
    }

    public class Person
    {
        public int Age;
        public string Name;

    }

    public static class IEnumerableExtensions
    {

        public static IEnumerable<T> Top<T>(this IEnumerable<T> list, double X)
        {
            IEnumerable<T> result = null;
            try
            { 
                if (X < 1 || X > 100) throw new ArgumentException();
                var elementCount = (int)Math.Ceiling((double)list.Count() * X / 100);
                result = list.OrderByDescending(x => x).Take(elementCount);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public static IEnumerable<T> Top<T>(this IEnumerable<T> list, double X, Func<T, int> operation)
        {
            IEnumerable<T> result = null;
            try
            {
                if (X < 1 || X > 100) throw new ArgumentException();
                var elementCount = (int)Math.Ceiling((double)list.Count() * X / 100);
               // list.Select( operation(x));
                result = list.OrderByDescending(x => operation(x)).Take(elementCount);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
    }
}
