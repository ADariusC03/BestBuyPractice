using BestBuyExercisePractice;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Products
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Configuration
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            #endregion


            IDbConnection conn = new MySqlConnection(connString);
            DapperProductRepository repos = new DapperProductRepository(conn);

            Console.WriteLine("Howdy Partner, here are the current products: ");
            Console.WriteLine("Press enter......");
            Console.ReadLine();

            var pro = repos.GetAllProducts();
            Print(pro);


            Console.WriteLine("Do you wish to add another product to table?");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of your new products?");
                userInput = Console.ReadLine();

                repos.InsertProduct(userInput);
                Print(repos.GetAllProducts());
            }
            Console.WriteLine("Thanks. See you later!");
        }


        private static void Print(IEnumerable<Product> pro)
        {
            foreach (var prod in pro)
            {
                Console.WriteLine($"ProductID: {prod.productID} Name: {prod.Name} Price: {prod.price} CategoryID: {prod.categoryID} Onsale: {prod.onSale} Stocklevel {prod.stockLevel}");
            }

        }


        


    }
}
