//Class product: property ProductID , ProductName and a method to copy a product
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWorkshop4CPRG200
{
    public class Product
    {

        //class property
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        //method copy a Product
        public Product CopyProduct()
        {
            Product copy = new Product();
            copy.ProductID = ProductID; // this Product ID
            copy.ProductName = ProductName;
            
            return copy;
        }


    }
}
