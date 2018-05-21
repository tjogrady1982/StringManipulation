using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation
{
    public class FileContents
    {
        public DateTime pubDate;
        public string title;
        public string author;

        public FileContents(string pubDate, string title, string author)
        {

            this.pubDate = DateTime.Parse(pubDate);
            this.title = title.Replace("?","");
            this.author = author.Replace("?", "");



        }

       
    }
}
