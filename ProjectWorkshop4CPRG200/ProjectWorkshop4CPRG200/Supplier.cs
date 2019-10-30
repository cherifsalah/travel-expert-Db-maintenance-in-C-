//Class Supplier : contain property of a given Supplier, CopySupplier give a copy of a supplier

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWorkshop4CPRG200
{
    public class Supplier
    {
        //class property
        public int SupplierID { get; set; }

        public string SupName { get; set; }

        //method copy a Supplier
        public Supplier CopySupplier()
        {
            Supplier copy = new Supplier();
            copy.SupplierID = SupplierID; // this Supplier ID
            copy.SupName = SupName;

            return copy;
        }
    }
}
