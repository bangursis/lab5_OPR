using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5OPR
{
    /**
     * min -- МИНИМАЛЬНЫЙ СРОК ЭКСПЛУАТАЦИИ
     * max -- МАКСИМАЛЬНЫЙ
     * 
     * currentT -- СРОК ЭКСПЛУАТАЦИИ В НАЧАЛЕ
     * 
     * rateOfI -- ПРОЦЕНТ ИЗМЕНЕНИЯ ЦЕНЫ НА НОВЫЙ 
     * rateOfR -- ПРОЦЕНТ ИЗМЕНЕНИЯ ПРИБЫЛИ
     * rateOfS -- ЦЕНЫ ОБСЛУЖИВАНИЯ
     * rateOfC -- ПРОДАЖИ
     * 
     * I -- цена нового в начале
     * r -- *
     * s -- *
     * c -- * 
     * 
     * **/
    class Preferences
    {
        public int min{ get; set; }
        public int max { get; set; }
        public int years { get; set; }
        public int currentT { get; set; }
        public int rateOfI { get; set; }
        public int rateOfR { get; set; }
        public int rateOfS { get; set; } 
        public int rateOfC { get; set; }
        public List<int> I { get; set; }
        public List<int> R { get; set; }
        public List<int> C { get; set; }
        public List<int> S { get; set; }

        public Preferences()
        {
            min = 2;
            max = 5;
            years = 5;
            currentT = 2;
            rateOfI = 20;
            rateOfR = -20;
            rateOfS = -20;
            rateOfC = 20;
            I = new List<int>();
            R = new List<int>();
            C = new List<int>();
            S = new List<int>();

            I.Add(60000);
            R.Add(30000);
            C.Add(1200);
            S.Add(I[0]);

            for (int i = 1; i <= years + currentT; i++)
            {
                I.Add(getNext(I[i - 1], rateOfI));
                R.Add(getNext(R[i - 1], rateOfR));
                C.Add(getNext(C[i - 1], rateOfC));
                S.Add(getNext(S[i - 1], rateOfS));
            }
        }
        private static int getNext(int cur, int rate)
        {
            return cur + (cur * rate) / 100;
        }
    }

}
