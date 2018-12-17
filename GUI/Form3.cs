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
    public partial class Form3 : Form
    {
        List<Stage> stages { get; set; }

        public Form3(List<Stage> stages)
        {
            InitializeComponent();
            this.stages = stages;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            printStages();
        }

        public void printStages()
        {
            result.Controls.Clear();
            result.Height = 0;
            result.Width = 1200;
            this.Width = 1200;
            var temp = stages.OrderBy(x => -x.year).ThenBy(x => x.t).GroupBy(x => x.year).ToList();

            foreach (var year in temp)
            {
                DataGridView dgv = new DataGridView();
                dgv.Name = year.Key.ToString();
                dgv.Width = 450;
                dgv.Columns.Add("t", "t");
                dgv.Columns.Add("SaveV", "Save");
                dgv.Columns.Add("SellV", "Sell");
                dgv.Columns.Add("Sell1", "Sell to 1");
                dgv.Columns.Add("Sell2", "Sell to 2");
                dgv.Columns.Add("max", "max");
                dgv.Columns.Add("dec", "decision");

                foreach (var t in year.GroupBy(x => x.t))
                {
                    var sell = t.FirstOrDefault(el => el.option == "Sell");
                    var sellto1yo = t.FirstOrDefault(el => el.option == "Sell to 1 y.o.");
                    var sellto2yo = t.FirstOrDefault(el => el.option == "Sell to 2 y.o.");
                    var save = t.FirstOrDefault(el => el.option == "Save");
                    

                    dgv.Rows.Add(
                        t.Key
                        , save != null? save.result.ToString() : "---"
                        , sell != null ? sell.result.ToString() : "---"
                        , sellto1yo != null ? sellto1yo.result.ToString() : "---"
                        , sellto2yo != null ? sellto2yo.result.ToString() : "---"
                        , t.Max(el => el.result)
                        , t.FirstOrDefault(el => el.result == t.Max(elem => elem.result)).option
                    );
                    
                }
                Label label = new Label();
                label.Text = year.Key.ToString();
                result.Controls.Add(label);
                result.Controls.Add(dgv);
                result.Height += dgv.Size.Height;
            }
        }
    }
}
