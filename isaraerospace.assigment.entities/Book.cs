using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isaraerospace.assigment.entities
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public string InStock { get; set; }

        public string Binding { get; set; }

        public string Description { get; set; }
    }
}
