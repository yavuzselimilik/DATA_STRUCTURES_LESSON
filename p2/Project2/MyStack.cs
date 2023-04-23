using System;
using System.Collections.Generic;
using System.Text;

namespace Project2
{
    class MyStack
    {
        private readonly int m_Size;
        private int m_StackPointer = 0;
        Customer[] m_Items;

        public MyStack(int size)
        {
            m_Size = size;
            m_Items = new Customer[size];
        }
        public void Push(Customer item)
        {
            if (m_StackPointer >= m_Size) throw new StackOverflowException();
            m_Items[m_StackPointer] = item;
            m_StackPointer++;
        }
        public Customer Pop()
        {
            m_StackPointer--;
            if (m_StackPointer >= 0)
            {
                return m_Items[m_StackPointer];
            }
            else
            {
                m_StackPointer = 0;
                throw new InvalidOperationException("Cannot pop an empty stack");
            }
        }

        public bool isEmpty()
        {
            return m_StackPointer == 0;
        }
    }
}
