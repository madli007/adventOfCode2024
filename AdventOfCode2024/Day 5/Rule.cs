namespace Day_5
{
    internal class Rule
    {
        public Rule() { }
        public Rule(int page1,  int page2)
        {
            Page1 = page1;
            Page2 = page2;
        }

        public int Page1 { get; set; }
        public int Page2 { get; set; }
    }
}
