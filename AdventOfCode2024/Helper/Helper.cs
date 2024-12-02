namespace Helper
{
    public class Helper
    {
        private readonly static Dictionary<string, double> resultsForTestData = new()
        {
            {"1.1", 11},
            {"1.2", 31},
            {"2.1", 2},
            {"2.2", 4}
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
