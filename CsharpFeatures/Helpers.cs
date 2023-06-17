using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace CsharpFeatures
{
    public class Helpers
    {
        #region Chunk
        //Before .Net 6
        public IEnumerable<T[]> ChunkCustom<T>(IEnumerable<T> items, int size)
        {
            while (items.Any())
            {
                yield return items.Take(size).ToArray();
            }
            items = items.Skip(size);
        }

        //After .Net 6
        public IEnumerable<T[]> Chunk<T>(IEnumerable<T> items, int size)
        {
            return items.Chunk(size);
        }
        #endregion

        public static void NumberFormatting()
        {
            #region Number Parsing
            var numberAsText = "56";

            //old approach
            var numberAsInt = int.Parse(numberAsText);
            var numberAsDouble = double.Parse(numberAsText);

            var numberAsIntnew = numberAsText.Parse<int>();
            var numberAsDoublenew = numberAsText.Parse<double>();
        }
        #endregion

        //instead of having overloaded methods like below
        public static decimal Sum(decimal x, decimal y)
        {
            return x + y;
        }
        public static int Sum(int x,int y)
        {
            return x + y;
        }

        //Generic method

        public static INumber<T> Sum<T>(T x, T y) 
            where T : INumber<T>
        {
            return x + y;
        }


        public void ConditionCheck()
        {
            if (string.IsNullOrEmpty(null))
            {
                //Evaluates to True
            }
            if (string.IsNullOrEmpty(""))
            {
                //Evaluates to True
            }
            if(string.IsNullOrEmpty(" "))
            {
                //Evaluates to False
            }
            if(string.IsNullOrWhiteSpace(" "))
            {
                //Evaluates to True
            }
        }


    #region order by
    public void PerformOrdeBy()
        {
            List<int> numbers = new() { 2, 5, 7, 22, 88, 4 };
            //old Approach
            var ascendingSortOld = numbers.OrderBy(x => x).ToList();
            var descendingSortOld = numbers.OrderByDescending(x => x).ToList();

            //new Approach
            var ascendingNew = numbers.Order();
            var descendingNew = numbers.OrderDescending();
        }

        #endregion

        #region DateOnly
        public void GetDateOnly()
        {
            //old Approach
            var dateTime = new DateTime(2023, 05, 23);
            var date = dateTime.ToShortDateString(); //05/23/2023

            //New Approach
            var dateOnly = new DateOnly(2023, 05, 23);
            Console.WriteLine(dateOnly); //05/23/2023

        }
        //.Net 7
        public void DateTimeOptions()
        {
            DateTime currentTime = DateTime.Now;

            Console.WriteLine( $"MilliSeconds:{currentTime.Millisecond}");
            Console.WriteLine($"MicroSeconds:{currentTime.Microsecond}");
            Console.WriteLine($"NanoSecond:{currentTime.Nanosecond}");

        }

        public void RandomFromList()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product() { Id = 1, Name = "Mobile", Price = 500 });
            products.Add(new Product() { Id = 1, Name = "Laptop", Price = 1500 });
            products.Add(new Product() { Id = 1, Name = "Printer", Price = 50 });
            products.Add(new Product() { Id = 1, Name = "Montior", Price = 100 });
            //.Net 8
            //var randomProducts = Random.Shared.GetItems(products, 3);
        }
        #endregion

        #region Number Generics
        #endregion
    }



}
