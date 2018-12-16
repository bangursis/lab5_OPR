namespace GUI
{
    public class Stage
    {
        public int year { get; }
        public int t { get; }
        public int result { get; }
        public string option { get; }

        public Stage(int year, int t, string option, int result)
        {
            this.year = year;
            this.t = t;
            this.option = option;
            this.result = result;
        }
    }
}