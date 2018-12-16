using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5OPR
{
    class Program
    {
        static Preferences pref { get; set; }
        static List<int> conditions { get; set; }
        static List<Stage> stages { get; set; }
        static void Main(string[] args)
        {
            pref = new Preferences();
            conditions = new List<int>();
            stages = new List<Stage>();

            var result = f(pref.currentT, 1);
            result.Item2.Reverse();
            printStages();

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Console.WriteLine("Predicted profit: " + result.Item1);
            Console.WriteLine(String.Join("---> ", result.Item2 ));

            Console.ReadKey();
        }

        private static Tuple<int, List<String>> f(int currentT, int year)
        {
            var options = new List<Tuple<int, List<String>>>();

            if (currentT < pref.max) { options.Add(save(currentT, year));}
            if (currentT >= pref.min) { options.Add(sellNBuy(currentT, year)); }
            
            return findMax(options);
        }

        private static Tuple<int, List<String>> save(int t, int year)
        {
            var tuple = year != pref.years ? f(t + 1, year + 1) : Tuple.Create(pref.S[t + 1], new List<String>());
            int result = tuple.Item1;
            List<String> way = tuple.Item2;            

            result +=  pref.R[t] - pref.C[t];

            way.Add(year + ":( Save:" + t +" ) ");
            stages.Add(new Stage(year, t, "Save", result));
            return Tuple.Create(result, way);
        }

        private static Tuple<int, List<String>> sellNBuy(int t, int year)
        {
            var tuple = year != pref.years ? f(1, year + 1) : Tuple.Create(pref.S[1], new List<String>()) ;
            int result = tuple.Item1;
            List<String> way = tuple.Item2;

            result += pref.S[t] + pref.R[0] - pref.C[0] - pref.I[year];
            way.Add( year + ":( Sell:" + t +" ) ");

            stages.Add(new Stage(year, t, "Sell", result));
            return Tuple.Create(result, way) ;
        }

        private static void printStages()
        {
            var temp = stages.OrderBy(x => -x.year).ThenBy(x => x.t).GroupBy(x => x.year).ToList();

            foreach (var year in temp)
            {
                Console.WriteLine(year.Key + " : ");
                foreach (var t in year.GroupBy(x => x.t))
                {
                    Console.WriteLine("\t" + t.Key + " : ");
                    foreach (var option in t)
                    {
                        Console.WriteLine("\t\t" + option.option + " : " + option.result);
                    }
                    Console.WriteLine("\t\tMax" + "  : " + t.Max(x => x.result));
                }
                Console.WriteLine("-----------------------------------------------\n");
            }


        }
        private static Tuple<int, List<String>> findMax(List<Tuple<int, List<String>>> options)
        {
            var result = options[0];

            foreach (var item in options)
            {
                if (item.Item1 > result.Item1)
                    result = item;
            }
            return result;
        }
    }
}
