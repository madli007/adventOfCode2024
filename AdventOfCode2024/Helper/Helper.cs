namespace Helper
{
    public class Helper
    {
        public static string[] GetAllInputsFromTxt(int day, bool useTestInput)
        {
            string fileName = "Day" + day.ToString() + "_input";
            if (useTestInput)
            {
                fileName += "_test";
            }
            fileName += ".txt";

            string[] lines = [];

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
    }
}
