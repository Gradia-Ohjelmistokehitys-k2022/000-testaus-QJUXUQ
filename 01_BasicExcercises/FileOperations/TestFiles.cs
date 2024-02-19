namespace FileOperations
{
    public class File
    {

        public static void Main(string[] args)
        {
        }

        private static void PrintFile(List<string> systemConfig)
        {
            foreach (var item in systemConfig)
            {
                Console.WriteLine(item);
            }
        }

        public static List<string> ReadFile(List<string> fileContent, string directory, string filePath)
        {

            StreamReader reader = new StreamReader(directory + filePath);
            try
            {
                do
                {
                    fileContent.Add(reader.ReadLine());
                }
                while (reader.Peek() != -1);
            }
            catch (FileNotFoundException e)
            {
                throw;
            }
            catch
            {
                fileContent.Add(("File is empty"));
            }
            finally
            {
                reader.Close();
            }
            return fileContent;
        }
    }
}