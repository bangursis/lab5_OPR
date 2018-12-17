using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form2 : Form
    {
        public int min { get; set; }
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
        static List<Stage> stages { get; set; }
        public bool to1yo { get; set; }
        public bool to2yo { get; set; }

        Graphics graphics;
        private Pen pen;
        private List<Tuple<Point, Point>> points;

        public Form2()
        {
            InitializeComponent();

            this.graphics = panel1.CreateGraphics();
            this.pen = new Pen(Color.Black);
            this.points = new List<Tuple<Point, Point>>();

            stages = new List<Stage>();
            I = new List<int>();
            C = new List<int>();
            S = new List<int>();
            R = new List<int>();
        }

        public Tuple<int, List<String>> f(int currentT, int year)
        {
            var options = new List<Tuple<int, List<String>>>();

            if (currentT < this.max) { options.Add(save(currentT, year)); }
            if (currentT >= this.min) {
                options.Add(sellNBuy(currentT, year));
                if (to1yo)
                    options.Add(sellNBuyNyo(currentT, year, 1));
                if (to2yo)
                    options.Add(sellNBuyNyo(currentT, year, 2));
            }

            return findMax(options);
        }

        internal void calculate()
        {
            var result = f(this.currentT, 1);
            result.Item2.Reverse();

            roadMap.Text = String.Join("---> ", result.Item2);
            amount.Text = result.Item1.ToString();
            new Form3(stages).Show();
        }

        public Tuple<int, List<String>> save(int t, int year)
        {
            var tuple = year != this.years ? f(t + 1, year + 1) : Tuple.Create(this.S[t + 1], new List<String>());
            int result = tuple.Item1;
            List<String> way = tuple.Item2;

            result += this.R[t] - this.C[t];

            way.Add(year + ":( Save:" + t + " ) ");
            stages.Add(new Stage(year, t, "Save", result));

            createALink(year, t, t + 1);

            return Tuple.Create(result, way);
        }

        public Tuple<int, List<String>> sellNBuy(int t, int year)
        {
            var tuple = year != this.years ? f(1, year + 1) : Tuple.Create(this.S[1], new List<String>());
            int result = tuple.Item1;
            List<String> way = tuple.Item2;

            result += this.S[t] + this.R[0] - this.C[0] - this.I[year];
            way.Add(year + ":( Sell:" + t + " ) ");
            stages.Add(new Stage(year, t, "Sell", result));

            createALink(year, t, 1);

            return Tuple.Create(result, way);
        }
        private Tuple<int, List<string>> sellNBuyNyo(int t, int year, int age)
        {
            var tuple = year != this.years ? f(age + 1, year + 1) : Tuple.Create(this.S[age + 1], new List<String>());
            int result = tuple.Item1;
            List<String> way = tuple.Item2;

            result += this.S[t] + this.R[age] - this.C[age] - this.S[age];
            way.Add(year + ":( Sell to " + age + " y.o.:" + t + " ) ");
            stages.Add(new Stage(year, t, "Sell to " + age + " y.o.", result));

            createALink(year, t, age + 1);

            return Tuple.Create(result, way);
        }

        private void createALink(int year, int t, int v)
        {
            var p1 = new Point((year - 1) * 100, panel1.Height - (t * 40));
            var p2 = new Point(year * 100, panel1.Height - (v * 40));
            points.Add(Tuple.Create(p1, p2));
            
        }

        public void panel1_Paint(object sender, PaintEventArgs e)
        {
            graphics.DrawLine(pen, 0, panel1.Height, 0, 0);
            graphics.DrawLine(pen, 0, panel1.Height - 1, panel1.Width, panel1.Height - 1);

            foreach (var point in points)
            {
                graphics.DrawLine(pen, point.Item1, point.Item2);
                graphics.DrawEllipse(pen, new Rectangle(new Point(point.Item1.X-4, point.Item1.Y - 4) , new Size(8, 8)));
                graphics.DrawEllipse(pen, new Rectangle(new Point(point.Item2.X - 4, point.Item2.Y - 4), new Size(8, 8)));
            }
        }

        public void setSize()
        {
            panel1.Height = (this.max + 1) * 40;
            panel1.Width = 10 * 100;
        }
        public void fillLists()
        {
            for (int i = 1; i <= years + currentT; i++)
            {
                I.Add(getNext(I[i - 1], rateOfI));
                R.Add(getNext(R[i - 1], rateOfR));
                C.Add(getNext(C[i - 1], rateOfC));
                S.Add(getNext(S[i - 1], rateOfS));
            }

        }
        public int getNext(int cur, int rate)
        {
            return cur + (cur * rate) / 100;
        }

        public static Tuple<int, List<String>> findMax(List<Tuple<int, List<String>>> options)
        {
            var result = options[0];

            foreach (var item in options)
            {
                if (item.Item1 > result.Item1)
                    result = item;
            }
            return result;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void amount_Click(object sender, EventArgs e)
        {

        }

        private void roadMap_Click(object sender, EventArgs e)
        {

        }
    }
}