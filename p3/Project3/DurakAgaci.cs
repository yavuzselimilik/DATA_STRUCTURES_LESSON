using System;
using System.Collections.Generic;
using System.Text;

namespace Project3
{
    class DurakDugum
    {
        public Durak data;
        public DurakDugum leftChild, rightChild;
        public Random rnd = new Random();
        
        public List<string[]> liste = new List<string[]>();

        public DurakDugum(Durak givenData)
        {
            this.data = givenData;

            // 1-10 arası kayıt ekle
            for (int i = 0; i < rnd.Next(10) + 1; i++)
            {
                if (data.NormalBisiklet + data.TandemBisiklet > 0)
                {
                    string tempID = Convert.ToString(rnd.Next(20) + 1); //rastgele id oluştur
                    string tempTime = rnd.Next(24) + ":" + (rnd.Next(50) + 10); //rastgele saat oluştur

                    liste.Add(new string[] { tempID, tempTime });

                    if (data.NormalBisiklet == 0) data.TandemBisiklet--;
                    else data.NormalBisiklet--;
                    data.BosPark++;
                }
                
            }
        }

        public void DisplayNode()
        {
            Console.WriteLine(data);
        }
    }
    class DurakAgaci
    {
        
        private DurakDugum root;


        public DurakAgaci()
        {
            root = null;
        }
        public DurakDugum GetRoot()
        {
            return root;
        }
        // Ağaca bir düğüm eklemeyi sağlayan metot
        public void Insert(Durak newdata)
        {
            DurakDugum newNode = new DurakDugum(newdata);

            if (root == null) root = newNode;
            else
            {
                DurakDugum current = root;
                DurakDugum parent;
                while (true)
                {
                    parent = current;
                    if (current.data.DurakAdi.CompareTo(newdata.DurakAdi) == 1)
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                }
            }
        }
        // Agacın inOrder Dolasılması
        public void InOrder(DurakDugum localRoot)
        {
            if (localRoot != null)
            {
                InOrder(localRoot.leftChild);
                localRoot.DisplayNode();
                InOrder(localRoot.rightChild);
            }
        }

        public void MusteriKayitlari(DurakDugum localRoot)
        {
            if (localRoot != null)
            {
                MusteriKayitlari(localRoot.leftChild);
                Console.WriteLine("-------------------");
                localRoot.DisplayNode();
                Console.WriteLine("-------------------");
                for (int i = 0; i < localRoot.liste.Count; i++)
                {
                    Console.WriteLine("Müşteri ID: {0} Kiralama Saati: {1}", localRoot.liste[i][0], localRoot.liste[i][1]);
                }
                Console.WriteLine("\nBu Duraktan {0} Müşteri Kiralama Yapmıştır.\n", localRoot.liste.Count);
                MusteriKayitlari(localRoot.rightChild);
            }
        }

        public int depthCalculator(DurakDugum localRoot)
        {
            if (localRoot == null)
            {
                return -1;
            }
            int leftDeep = depthCalculator(localRoot.leftChild);
            int rightDeep = depthCalculator(localRoot.rightChild);

            if (leftDeep > rightDeep) return (leftDeep + 1);
            else return (rightDeep + 1);
            
        }

        public void GetIdRecord(string id, DurakDugum localRoot)
        {
            if (localRoot != null)
            {
                GetIdRecord(id, localRoot.leftChild);
                for (int i = 0; i < localRoot.liste.Count; i++)
                {
                    if (id.Equals(localRoot.liste[i][0]))
                    {
                        Console.WriteLine("ID: {0} Kiralama Saati: {1} Kiralanan Durak: {2}", id, localRoot.liste[i][1], localRoot.data.DurakAdi);
                    }
                }
                GetIdRecord(id, localRoot.rightChild);
            }
        }

        public void RentBike(string durakAdi, string id, DurakDugum root)
        {
            DurakDugum Find(string durakAdi, DurakDugum root)
            {
                if (root != null)
                {
                    if (durakAdi.CompareTo(root.data.DurakAdi) == 0) return root;
                    if (durakAdi.CompareTo(root.data.DurakAdi) < 0) return Find(durakAdi, root.leftChild);
                    else return Find(durakAdi, root.rightChild);
                }
                return null;
            }

            DurakDugum foundNode = Find(durakAdi, root);

            if (foundNode == null) Console.WriteLine("\nAranan Durak Bulunamadı.");
            else
            {
                if (foundNode.data.NormalBisiklet > 0)
                {
                    string tempTime = foundNode.rnd.Next(24) + ":" + (foundNode.rnd.Next(50) + 10); //rastgele saat oluştur
                    foundNode.liste.Add(new string[] { id, tempTime });

                    foundNode.data.NormalBisiklet--;
                    foundNode.data.BosPark++;

                    Console.WriteLine("\n");
                    foundNode.DisplayNode();
                    Console.WriteLine("Boş park sayısı --> {0} Normal bisiklet sayısı --> {1} Tandem bisiklet sayısı --> {2}", foundNode.data.BosPark, foundNode.data.NormalBisiklet, foundNode.data.TandemBisiklet);
                    Console.WriteLine("-------------------");

                    for (int i = 0; i < foundNode.liste.Count; i++)
                    {
                        Console.WriteLine("Müşteri ID: {0} Kiralama Saati: {1}", foundNode.liste[i][0], foundNode.liste[i][1]);
                    }
                }
                else Console.WriteLine("\nBu durakta normal bisikle kalmamıştır.");
            }
        }
    }
}
