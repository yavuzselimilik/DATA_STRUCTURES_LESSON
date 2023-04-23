using System;
using System.Collections.Generic;
using System.Text;

namespace Project2
{
    class MyPriorityQueueIncreasing
    {
        List<Customer> list;

        public MyPriorityQueueIncreasing()
        {
            list = new List<Customer>();
        }

        public void Add(Customer customer)
        {
            list.Add(customer);
        }

        public Customer Deque()
        {
            Customer min = list[0];
            int index = 0;

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].ProductsNumber < min.ProductsNumber)
                {
                    min = list[i];
                    index = i;
                }
            }
            list.RemoveAt(index);
            return min;
        }

        public bool isEmpty()
        {
            if (list.Count == 0) return true;
            return false;
        }
    }
}
