using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuyExercisePractice
{
    class DapperProductRepository : IProductRespository
    {
        private readonly IDbConnection conn;

        public DapperProductRepository(IDbConnection connection)
        {
            conn = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var pro = conn.Query<Product>("SELECT * FROM products");
            return pro;
        }

        public void InsertProduct(int productID, string productName, decimal price, int categoryID, int onSale, string stockLevel)
        {
            conn.Execute("INSERT INTO PRODUCTS (Name) VALUES (@productsProductID, @productsName, @productsPrice, @productsCategoryID, @productsOnSale, @productsStockLevel);",
            new {productProductID = productID, productName = productName, productPrice = price, productCategoryID = categoryID, productsOnSale = onSale, productsStockLevel = stockLevel });

        }

        internal string InsertProduct(string userInput)
        {
            if (true)
            {
                return userInput;
            }
        }
    }
}
