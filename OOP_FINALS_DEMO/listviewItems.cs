using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_FINALS_DEMO
{
    public class listviewItems
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public listviewItems(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
