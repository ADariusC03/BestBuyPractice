using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyExercisePractice
{
    interface IProductRespository
    {
        IEnumerable<Product> GetAllProducts();
        void InsertProduct(int ProductID, string productName, decimal price, int categoryID, int onSale, string stockLevel);
    }
}
