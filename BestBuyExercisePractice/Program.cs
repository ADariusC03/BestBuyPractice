using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BestBuyExercisePractice
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
            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);
            

            Console.WriteLine("Howdy Partner, here are the current department: ");
            Console.WriteLine("Press enter......");
            Console.ReadLine();

            var depos = repo.GetAllDepartments();
            Print(depos);


            Console.WriteLine("Do you wish to add another department to table?");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of your new department?");
                userInput = Console.ReadLine();

                repo.InsertDepartment(userInput);
                Print(repo.GetAllDepartments());
            }
            Console.WriteLine("Thanks. See you later!");
        }


        private static void Print(IEnumerable<Department> depos)
        {
            foreach (var depo in depos)
            {
                Console.WriteLine($"ID: {depo.DepartmentID} Name: {depo.Name}");
            }

        }

        
    }

}