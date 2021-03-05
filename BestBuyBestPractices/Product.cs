using System;


namespace BestBuyBestPractices
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double CategoryID { get; set; }
        public int OnSale { get; set; }
        public string StockLevel { get; set; }

        //internal class GetAllProducts
        //{
        //    public GetAllProducts()
        //    {
        //    }
        //}
    }
}
