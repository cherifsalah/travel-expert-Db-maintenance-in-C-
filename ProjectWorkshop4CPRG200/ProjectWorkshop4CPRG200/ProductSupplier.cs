//ProductSupplier class: property of a ProductSupplier
//(ProductSupplierId, ProductId, SupplierId, ProductName, SupplierName)
// a method to copy a productSupplier
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWorkshop4CPRG200
{
    public class ProductSupplier
    {
        //class property

        public int ProductSupplierID { get; set; }
        public int? ProductID { get; set; }

        public int? SupplierID { get; set; }

        public string ProductName { get; set; }
                  
        public string SupplierName { get; set; }
        //method copy a Product
        public ProductSupplier CopyProductSupplier()
        {
            ProductSupplier copy = new ProductSupplier();
            copy.ProductSupplierID = ProductSupplierID; //this ProductSupplierID
            copy.ProductID = ProductID; // this Product ID
            copy.SupplierID = SupplierID;
            copy.ProductName = ProductName;
            copy.SupplierName = SupplierName;

            return copy;
        }
        

    }
}
