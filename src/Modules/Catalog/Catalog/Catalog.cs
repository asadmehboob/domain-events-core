using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    

    public class Catalog
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; } = string.Empty;

        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public Catalog(Guid id, string title, string author, decimal price)
        {
            Id = id;
            Title = title;
            Author = author;
            Price = price;
        }

        public void UpdatePrice(decimal price)
        {
            Price = price;
        }


    }




}
