using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.Model
{
    public class Page
    {
        public int id { get; set; }
        public DateTime EntryDate { get; set; }
        public string Title { get; set; }
        public string Thought { get; set; }
    }
}
