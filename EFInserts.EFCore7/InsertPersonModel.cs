using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInserts.EFCore7
{
    [SimpleJob(RunStrategy.ColdStart,launchCount:1,warmupCount:1,iterationCount:10)]
    public class InsertPersonModel
    {
        private readonly DataContext _dataContext;

        private List<string> Names { get; set; }
        public InsertPersonModel():this(new DataContext())
        {
            
        }
        public InsertPersonModel(DataContext dataContext)
        {
            _dataContext = dataContext;
            Names = new();
        }

        private int _batchSize;
        [Params(100,1000,3000)]
        public int BatchSize
        {
            get => _batchSize;
            set
            {
                _batchSize = value;
                InitNames();
            }

        }
        private void InitNames()
        {
            Names = new List<string>(_batchSize);
            for(int i = 0; i < _batchSize; i++)
            {
                Names.Add(GenerateRandomString(20));
            }
        }

        #region Benchmarks
        [Benchmark]
        public void AddOneByOneWithSave()
        {
            var stopWatch = StartWatch();

            foreach(var name in Names)
            {
                _dataContext.Add(new Person() { Name = name });
                _dataContext.SaveChanges();
            }
            PrintTimeElapsed(stopWatch);
        }
        [Benchmark]
        public void AddOneByOne()
        {
            var stopWatch = StartWatch();

            foreach (var name in Names)
            {
                _dataContext.Add(new Person() { Name = name });
            }
            _dataContext.SaveChanges();
            PrintTimeElapsed(stopWatch);
        }
        [Benchmark]
        public void AddRange()
        {
            var stopWatch = StartWatch();

            IList<Person> batch = new List<Person>( Names.Select(n=>new Person() { Name = n }));
            _dataContext.People.AddRange(batch);
            _dataContext.SaveChanges();
            PrintTimeElapsed(stopWatch);
        }
        [Benchmark]
        public void BulkExtensionBulkInsert()
        {
            var stopWatch = StartWatch();

            IList<Person> batch = new List<Person>(Names.Select(n => new Person() { Name = n }));
            _dataContext.MockableBulkInsert(batch);

            PrintTimeElapsed(stopWatch);
        }
        #endregion


        #region Helper Methods to generate Names
        private static readonly Random random = new Random();
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ012356789";
        private static string GenerateRandomString(int length)
        {
            return new string(Enumerable.Repeat(Chars, length)
                            .Select(s => s[random.Next(s.Length)]).ToArray());

        }

        private static Stopwatch StartWatch()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            return stopWatch;
        }
        private static void PrintTimeElapsed(Stopwatch stopwatch)
        {
            stopwatch.Stop();
            var elapsed = stopwatch.Elapsed;
            Console.WriteLine( $"Run time:{elapsed.Hours:00}:{elapsed.Minutes:00}:{elapsed.Seconds/10:00}");
        }

        #endregion

    }
}
