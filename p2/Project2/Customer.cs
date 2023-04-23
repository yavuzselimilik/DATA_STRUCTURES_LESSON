using System;
using System.Collections.Generic;
using System.Text;

namespace Project2
{
    class Customer
    {
        public string CustomerName { get;  }
        public int ProductsNumber { get;  }

        public Customer(string customerName, int productsNumber)
        {
            this.CustomerName = customerName;
            this.ProductsNumber = productsNumber;
        }

        public override string ToString()
        {
            return CustomerName + " " + ProductsNumber;
        }
    }
}
