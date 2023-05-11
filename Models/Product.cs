using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crudOperation_ADO.net.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public List<Category> category { get; set; }
        public int CategoryId { get; set; }
    }
}