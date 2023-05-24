using System;
using System.Collections.Generic;
using System.Linq;
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
    }
    #region SelectMany

    #endregion


}
