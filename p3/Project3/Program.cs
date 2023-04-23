using System;
using System.Collections;
using System.Collections.Generic;

namespace Project3
{
    class Program
    {
        static void Main(string[] args)
        {
            String[,] duraklar_veri_girisi = 
            { 
                {"İnciraltı", "28", "2", "10" },
                {"Sahilevleri", "8", "1", "11"}, 
                {"Doğal Yaşam Parkı", "17", "1", "6"}, 
                {"Bostanlı İskele", "7", "0", "5" }, 
                {"Alsancak İskele", "12", "1", "7" },
                {"Karşıyaka Evlendirme Dairesi", "6", "1", "5" },
                {"Alaybey Tersane Cafe", "7", "1", "4" },
                {"Konak İskele", "13", "0", "25" },
                {"Göztepe Köprü", "9", "1", "20" } 
            };


            DurakAgaci durakAgaci = new DurakAgaci();

            // Durakları diziden alıp ağaca ekleme döngüsü
            for (int i = 0; i < duraklar_veri_girisi.GetLength(0); i++)
            {
                durakAgaci.Insert(new Durak(duraklar_veri_girisi[i, 0], Convert.ToInt32(duraklar_veri_girisi[i, 1]), Convert.ToInt32(duraklar_veri_girisi[i, 2]), Convert.ToInt32(duraklar_veri_girisi[i, 3])));
            }

            Console.WriteLine("Durak Ağacı inOrder Gezinme Durumu:\n");

            durakAgaci.InOrder(durakAgaci.GetRoot());

            Console.WriteLine("\nDurak Ağacı Derinliği: {0}\n", durakAgaci.depthCalculator(durakAgaci.GetRoot()));

            durakAgaci.MusteriKayitlari(durakAgaci.GetRoot());

            Console.WriteLine("Kiralama Geçmişi ID Sorgulama: ");
            Console.Write("ID Giriniz: ");
            string id = Console.ReadLine();

            durakAgaci.GetIdRecord(id, durakAgaci.GetRoot());

            Console.WriteLine("\nBisiklet Kiralama Metodu:");
            Console.Write("Durak Adı Giriniz: ");
            string durakAdi = Console.ReadLine();
            Console.Write("İşlemi Gerçekleştirecek ID Giriniz: ");
            id = Console.ReadLine();

            durakAgaci.RentBike(durakAdi, id, durakAgaci.GetRoot());

            Hashtable hashtable = new Hashtable();

            for (int i = 0; i < duraklar_veri_girisi.GetLength(0); i++) // diziden veri çekip hashtable'a ekle
            {
                hashtable.Add(duraklar_veri_girisi[i, 0], new Durak(duraklar_veri_girisi[i, 0], Convert.ToInt32(duraklar_veri_girisi[i, 1]), Convert.ToInt32(duraklar_veri_girisi[i, 2]), Convert.ToInt32(duraklar_veri_girisi[i, 3])));
            }

            Console.WriteLine("Güncelleme Öncesi Durakların Durumu:\n");
            foreach (Durak item in hashtable.Values)
            {
                item.Status();
            }

            Console.WriteLine("\nGüncelleme Sonrası Durakların Durumu\n");
            foreach (Durak item in hashtable.Values)
            {
                if (item.BosPark > 5)
                {
                    item.BosPark -= 5;
                    item.NormalBisiklet += 5;
                }
                item.Status();
            }

            Console.WriteLine("\nHeap Yapısı İlk 3 Eleman Print:\n");
            MyHeap myHeap = new MyHeap(hashtable.Count);

            foreach (Durak item in hashtable.Values) //Veri HashTable'dan çekildi. Gerekli Parklara 5 bisiklet eklenmiş halidir.
            {
                myHeap.Insert(item);
            }

            for (int i = 0; i < 3 && !myHeap.IsEmpty(); i++)
            {
                myHeap.Remove().Status();
            }

            Console.WriteLine("Projenin 4. Bölümü Sıralama Algoritmaları.\nGörüntülemek için bir tuşa basınız.");
            Console.ReadKey();

            List<int> list_for_simple = new List<int>();
            List<int> list_for_advanced = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < 20; i++)  //rastgele sayılar ekle
            {
                list_for_simple.Add(rnd.Next(100));
                list_for_advanced.Add(rnd.Next(100));
            }

            Console.WriteLine("\nListenin sıralanmamış hali:\n");
            foreach (var item in list_for_simple)
            {
                Console.Write(item + " ");
            }

            int temp, smallest;     //Selection Sort 

            for (int i = 0; i < list_for_simple.Count - 1; i++)
            {
                smallest = i;

                for (int j = i + 1; j < list_for_simple.Count; j++)
                {
                    if (list_for_simple[j] < list_for_simple[smallest]) smallest = j;
                }

                temp = list_for_simple[smallest];
                list_for_simple[smallest] = list_for_simple[i];
                list_for_simple[i] = temp;
            }

            Console.WriteLine("\n\nListenin 'Selection Sort' ile sıralanmış hali:\n");
            foreach (var item in list_for_simple)
            {
                Console.Write(item + " ");
            }

            //Quick Sort
            

            void QuickSort(List<int> list, int low, int high)
            {
                int Partition(List<int> list, int low,
                                    int high)
                {
                    int pivot = list[high];

                    int lowIndex = (low - 1);

                    for (int j = low; j < high; j++)
                    {
                        if (list[j] <= pivot)
                        {
                            lowIndex++;

                            int temp = list[lowIndex];
                            list[lowIndex] = list[j];
                            list[j] = temp;
                        }
                    }

                    int temp1 = list[lowIndex + 1];
                    list[lowIndex + 1] = list[high];
                    list[high] = temp1;

                    return lowIndex + 1;
                }

                if (low < high)
                {
                    int partitionIndex = Partition(list, low, high);

                    QuickSort(list, low, partitionIndex - 1);
                    QuickSort(list, partitionIndex + 1, high);
                }
            }

            Console.WriteLine("\n\nListenin sıralanmamış hali:\n");
            foreach (var item in list_for_advanced)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n\nListenin 'Quick Sort' ile sıralanmış hali:\n");
            QuickSort(list_for_advanced, 0, list_for_advanced.Count - 1);
            foreach (var item in list_for_advanced)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n\n");

        }
    }
}
