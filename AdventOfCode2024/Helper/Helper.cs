namespace Helper
{
    public class Helper
    {
        private readonly static Dictionary<string, double> resultsForTestData = new()
        {
            {"1.1", 11},
            {"1.2", 31},
            {"2.1", 2},
            {"2.2", 4},
            {"3.1", 161},
            {"3.2", 48},
            {"4.1", 18},
            {"4.2", 9},
            {"5.1", 143},
            {"5.2", 123},
            {"6.1", 41},
            {"6.2", 6},
            {"7.1", 3749},
            {"7.2", 11387},
            {"8.1", 14},
            {"9.1", 1928},
            {"9.2", 2858},
            {"10.1", 36},
            {"11.1", 55312},
            {"12.1", 1930}
        };

        public static string[] GetAllInputsFromTxt(int day, bool useTestInput)
        {
            string fileName = "Day" + day.ToString() + "_input";
            if (useTestInput)
            {
                fileName += "_test";
            }
            fileName += ".txt";

            string[] lines;

            if (File.Exists(fileName))
            {
                // Read a text file line by line.
                lines = File.ReadAllLines(fileName);
            }

            else
            {
                throw new Exception("File doesn't exist");
            }

            return lines;
        }

        public static bool IsMyTestResultCorrect(int day, int part, double myResult)
        {
            string key = day.ToString() + "." + part.ToString();
            resultsForTestData.TryGetValue(key, out double correctResult);
            return myResult == correctResult;
        }
    }
}
