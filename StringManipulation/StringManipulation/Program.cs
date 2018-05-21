using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Importing csv file...");
            var fileContents = ImportFile();

            Console.WriteLine("| Pub Date    |                    Title | Authors                         |");
            Console.WriteLine("|==========================================================================|");

            foreach (var item in fileContents)
            {
                Console.WriteLine("| " + ChangeDateFormat(item.pubDate) + " | " + Truncate(item.title, 24) + " | " + Truncate(item.author, 28) + " |");
            }
            Console.ReadLine();

        }

        static List<FileContents> ImportFile()
        {
            var fileContentList = new List<FileContents>();

            var filepath = @"C:\Users\Tim\gfvdgf.csv";

            Console.WriteLine(filepath);
            using (var reader = new StreamReader(filepath, Encoding.ASCII)) //handling unknown character encoding
            {
                var ext = Path.GetExtension(filepath.ToString());
                if (ext == ".csv")
                {
                    reader.ReadLine();
                    var i = 1; //ignore first line as will be harcoding headers and extra formatting to match example
                    while (!reader.EndOfStream)
                    {
                        i = i + 1;
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        string pubDate = values[0];
                        string title = values[1];
                        string author = values[2];


                        FileContents fileContents = new FileContents(pubDate, title, author);
                        fileContentList.Add(fileContents);
                    }
                }
            }

            return fileContentList;
        }
        public static string Truncate(string value, int maxChars)//truncates, fill fixed width
        {
            return value.Length <= maxChars ? value.PadRight(maxChars) : value.Substring(0, maxChars) + "...";
        }

        public static string ChangeDateFormat(DateTime value)
        {
            string format = "dd MMM yyyy";
            return value.ToString(format);
        }
    }
}
