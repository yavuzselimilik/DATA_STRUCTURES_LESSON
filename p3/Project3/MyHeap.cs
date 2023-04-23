using System;
using System.Collections.Generic;
using System.Text;

namespace Project3
{
    class MyHeap
    {
        int currentSize, maxSize;
        public Durak[] durakArray;

        public MyHeap(int maxSize)
        {
            this.maxSize = maxSize;
            currentSize = 0;
            durakArray = new Durak[maxSize];
        }

        public bool Insert(Durak durak)
        {
            if (currentSize == maxSize) return false;
            durakArray[currentSize] = durak;
            TrickleUp(currentSize++);
            return true;
        }

        public void TrickleUp(int index)
        {
            int parent = (index - 1) / 2;
            Durak bottom = durakArray[index];

            while (index > 0 && durakArray[parent].NormalBisiklet < bottom.NormalBisiklet)
            {
                durakArray[index] = durakArray[parent]; //aşşağı taşıma
                index = parent;
                parent = (parent - 1) / 2;
            }
            durakArray[index] = bottom;
        }

        public Durak Remove()
        {
            Durak root = durakArray[0];
            durakArray[0] = durakArray[--currentSize];
            TrickleDown(0);
            return root;
        }

        public void TrickleDown(int index)
        {
            int largerChild;
            Durak top = durakArray[index];

            while (index < currentSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;

                if (rightChild < currentSize && durakArray[leftChild].NormalBisiklet < durakArray[rightChild].NormalBisiklet) //rightChild olma durumu
                {
                    largerChild = rightChild;
                }
                else largerChild = leftChild;

                if (top.NormalBisiklet >= durakArray[largerChild].NormalBisiklet) break;

                durakArray[index] = durakArray[largerChild];
                index = largerChild;
            }
            durakArray[index] = top;
        }

        public bool IsEmpty()
        {
            return currentSize == 0;
        }
    }
}
