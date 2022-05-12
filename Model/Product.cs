using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
/// 
namespace Model
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductQuntity { get; set; }
        public int ProductPrice { get; set; }
        public int CompanyId { get; set; }
        
        public Company Company { get; set; }

    }
}
