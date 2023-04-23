using System;
using System.Collections.Generic;
using System.Text;

namespace Project2
{
    class MyPriorityQueueDecreasing
    {
        List<Customer> list;

        public MyPriorityQueueDecreasing()
        {
            list = new List<Customer>();
        }

        public void Add(Customer customer)
        {
            list.Add(customer);
        }

        public Customer Deque()
        {
            Customer max = list[0];
            int index = 0;

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].ProductsNumber > max.ProductsNumber)
                {
                    max = list[i];
                    index = i;
                } 
            }
            list.RemoveAt(index);
            return max;
        }

        public bool isEmpty()
        {
            if (list.Count == 0) return true;
            return false;
        }
    }
}
