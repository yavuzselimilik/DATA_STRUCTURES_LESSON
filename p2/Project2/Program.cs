using System;
using System.Collections;
using System.Collections.Generic;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            // Veri girişini burdan yapınız. Eşit sayıda musteri ve ürün adet bilgisi girilmeli.
            string[] musteriAdi = { "Ali", "Merve", "Veli", "Gülay", "Okan", "Zekiye", "Kemal", "Banu", "İlker", "Songül", "Nuri", "Deniz"};
            int[] urunSayisi = { 8, 11, 16, 5, 15, 14, 19, 3, 18, 17, 13, 15};
            int count = 0;

            ArrayList arrayList = new ArrayList();

            while (count < musteriAdi.Length)
            {
                List<Customer> tempList = new List<Customer>();
                for (int i = 0; i <= rnd.Next(5); i++)
                {
                    tempList.Add(new Customer(musteriAdi[count], urunSayisi[count]));
                    count++;
                    if (count >= musteriAdi.Length) break;
                }
                arrayList.Add(tempList);
            }

            for (int i = 0; i < arrayList.Count; i++)
            {
                Console.WriteLine("\nArray index: " + i + "\n");
                foreach (var item in (List<Customer>)arrayList[i])
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("\n\nDinamik dizin eleman sayısı: {0}.", arrayList.Count);
            Console.WriteLine("Listelerin ortalama eleman sayısı: {0}.\n", Convert.ToDouble(musteriAdi.Length) / arrayList.Count);

            Console.WriteLine("Stack Sınıfı Print:\n\n");

            MyStack myStack = new MyStack(musteriAdi.Length);

            for (int i = 0; i < musteriAdi.Length; i++)
            {
                myStack.Push(new Customer(musteriAdi[i], urunSayisi[i]));
            }

            while (!myStack.isEmpty())
            {
                Console.WriteLine(myStack.Pop());
            }

            Console.WriteLine("\n\nQueue Sınıfı Print:\n\n");

            MyQueue myQueue = new MyQueue(musteriAdi.Length);

            for (int i = 0; i < musteriAdi.Length; i++)
            {
                myQueue.Enque(new Customer(musteriAdi[i], urunSayisi[i]));
            }

            int time_q = 0;
            int total_time_q = 0;
            while (!myQueue.isEmpty())
            {
                Customer temp = myQueue.Deque();
                time_q += temp.ProductsNumber;
                total_time_q += time_q;
                Console.WriteLine(temp);
            }

            Console.WriteLine("\n\nPriority Queue (Azalan) Sınıfı Print:\n\n");

            MyPriorityQueueDecreasing myPriorityQueueDecreasing = new MyPriorityQueueDecreasing();

            for (int i = 0; i < musteriAdi.Length; i++)
            {
                myPriorityQueueDecreasing.Add(new Customer(musteriAdi[i], urunSayisi[i]));
            }

            while (!myPriorityQueueDecreasing.isEmpty())
            {
                Console.WriteLine(myPriorityQueueDecreasing.Deque());
            }

            Console.WriteLine("\n\nPriority Queue (Artan) Sınıfı Print:\n\n");

            MyPriorityQueueIncreasing myPriorityQueueIncreasing = new MyPriorityQueueIncreasing();

            for (int i = 0; i < musteriAdi.Length; i++)
            {
                myPriorityQueueIncreasing.Add(new Customer(musteriAdi[i], urunSayisi[i]));
            }

            int time_pq = 0;
            int total_time_pq = 0;
            
            while (!myPriorityQueueIncreasing.isEmpty())
            {
                Customer temp = myPriorityQueueIncreasing.Deque();
                time_pq += temp.ProductsNumber;
                total_time_pq += time_pq;
                Console.WriteLine(temp);
            }
            
            Console.WriteLine("\nKuyruk ortalama işlem tamamlama süresi: " + Convert.ToDouble(total_time_q) / musteriAdi.Length);
            Console.WriteLine("\nÖncelikli Kuyruk(Artan) ortalama işlem tamamlama süresi: " + Convert.ToDouble(total_time_pq) / musteriAdi.Length);
        }
    }
}
