using System;
using System.Collections.Generic;
using System.Text;

namespace Project2
{
    class MyQueue
    {
        private int m_Size, front, rear, m_Count;
        private Customer[] m_Items;

        public MyQueue(int size)
        {
            m_Size = size;
            m_Items = new Customer[size];
            front = 0;
            rear = -1;
            m_Count = 0;
        } 
        public void Enque(Customer customer)
        {
            if (rear == m_Size - 1) rear = -1;

            m_Items[++rear] = customer;
            m_Count++;
        }

        public Customer Deque()
        {
            Customer temp = m_Items[front++];
            if (front == m_Size) front = 0;

            m_Count--;
            return temp;
        }

        public bool isEmpty()
        {
            return m_Count == 0;
        }

    }
}
