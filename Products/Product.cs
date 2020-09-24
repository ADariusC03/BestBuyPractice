using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyExercisePractice
{
    class Product
    {
        public Product()
        {

        }
        public int productID { get; set; }
        public string Name { get; set; }
        public decimal price { get; set; }
        public int categoryID { get; set; }
        public int onSale { get; set; }
        public string stockLevel { get; set; }

    }
}
