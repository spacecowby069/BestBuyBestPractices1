using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace BestBuyBestPractices
{
    public class Program
    {
        private static readonly IDbConnection connection;
        
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
           
            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var repo = new DepartmentRepository(conn);

            Console.WriteLine("Type a new Department name");

            var newDepartment = Console.ReadLine();

            repo.InsertDepartment(newDepartment);

            var departments = repo.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine();
                Console.WriteLine(dept.Name);
                Console.WriteLine();
                Console.WriteLine(dept.DepartmentID);
            }
            Console.WriteLine("-------------------------------");

            ListProducts();

            DeleteProduct();


        }

        public static void DeleteProduct()
        {
            var prodRepo = new ProductRepository(connection);

            Console.WriteLine($"Please enter the productID of the product you would like to deleteaaaaaa:");
            var productID = Convert.ToInt32(Console.ReadLine());

            prodRepo.DeleteProduct(productID);
        }

        public static void UpdateProductName()
        {
            var prodRepo = new ProductRepository(connection);

            Console.WriteLine($"What is the productID of the product you would like to update?");
            var productID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"What is the new name you would like for the product with an id of {productID}?");
            var updatedName = Console.ReadLine();

            prodRepo.UpdateProductName(productID, updatedName);
        }

        public static void CreatAndListProducts()
        {
            var prodRepo = new ProductRepository(connection);

            Console.WriteLine($"What is the new product name?");
            var prodName = Console.ReadLine();

            Console.WriteLine($"What is the new product's price?");
            var price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"What is the new product's category id?");
            var categoryID = Convert.ToDouble(Console.ReadLine());

            prodRepo.CreateProduct(prodName, price, categoryID);

            var products = prodRepo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID} {product.Name}");
            }

        }

        public static void ListProducts()
        {
            var prodRepo = new ProductRepository(connection);
            var products = prodRepo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID} {product.Name}");
            }
        }

        public static void ListDepartments()
        {
            var repo = new DepartmentRepository(connection);

            var departments = repo.GetAllDepartments();

            foreach (var item in departments)
            {
                Console.WriteLine($"{item.DepartmentID} {item.Name}");
            }
        }

        public static void DepartmentUpdate()
        {
            var repo = new DepartmentRepository(connection);

            Console.WriteLine($"Would you like to update a department? yes or no");

            if (Console.ReadLine().ToUpper() == "YES")
            {
                Console.WriteLine($"What is the ID of the Deparment you would like to update?");

                var id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"What would you like to change the name of the department to?");

                var newName = Console.ReadLine();

                repo.UpdateDepartment(id, newName);

                var depts = repo.GetAllDepartments();

                foreach (var item in depts)
                {
                    Console.WriteLine($"{item.DepartmentID} {item.Name}");
                }
            }
        }
    }
}
