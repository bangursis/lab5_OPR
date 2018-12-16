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
            var temp = stages.OrderBy(x => -x.year).ThenBy(x => x.t).GroupBy(x => x.year).ToList();

            foreach (var year in temp)
            {
                DataGridView dgv = new DataGridView();
                dgv.Name = year.Key.ToString();
                dgv.Columns.Add("t", "t");
                dgv.Columns.Add("SaveV", "Save");
                dgv.Columns.Add("SellV", "Sell");
                dgv.Columns.Add("max", "max");
                dgv.Columns.Add("dec", "decision");

                foreach (var t in year.GroupBy(x => x.t))
                {
                    var sell = t.FirstOrDefault(el => el.option == "");
                    var save = t.FirstOrDefault(el => el.option == "Save");

                    dgv.Rows.Add(
                        t.Key
                        , save != null? save.result.ToString() : "---"
                        , sell != null ? sell.result.ToString() : "---"
                        , t.Max(el => el.result)
                        , t.FirstOrDefault(el => el.result == t.Max(elem => elem.result)).option
                    );
                    
                }
                Label label = new Label();
                label.Text = year.Key.ToString();
                result.Controls.Add(label);
                result.Controls.Add(dgv);
            }
        }
    }
}
