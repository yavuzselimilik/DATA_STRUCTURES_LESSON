using System;
using System.Collections.Generic;
using System.Text;

namespace Project4
{
    class Dugum
    {
        public int key, yukseklik;
        public Dugum left, right;
        public Dugum(int data)
        {
            key = data;
            yukseklik = 1;
        }

    }
    class AVLTree
    {
        public Dugum kok;

        int yukseklik(Dugum dugum)
        {
            if (dugum == null)
                return 0;
            return dugum.yukseklik;
        }

        int max(int a, int b)
        {
            return (a > b) ? a : b;
        }
        Dugum sagaDondur(Dugum y)
        {
            Dugum x = y.left;
            Dugum T2 = x.right;

            x.right = y;
            y.left = T2;

            y.yukseklik = max(yukseklik(y.left), yukseklik(y.right)) + 1;
            x.yukseklik = max(yukseklik(x.left), yukseklik(x.right)) + 1;
            return x;
        }
        Dugum SolaDondur(Dugum x)
        {
            Dugum y = x.right;
            Dugum T2 = y.left;
            y.left = x;
            x.right = T2;
            x.yukseklik = max(yukseklik(x.left), yukseklik(x.right)) + 1;
            y.yukseklik = max(yukseklik(y.left), yukseklik(y.right) + 1);
            return y;

        }
        int denge_ne(Dugum dugum)
        {
            if (dugum == null)
            {
                return 0;

            }
            return yukseklik(dugum.left) - yukseklik(dugum.right);
        }

        public Dugum ekle(Dugum dugum, int data)
        {
            if (dugum == null)
            {
                return (new Dugum(data));
            }
            if (data < dugum.key)
                dugum.left = ekle(dugum.left, data);
            else if (data > dugum.key)
                dugum.right = ekle(dugum.right, data);
            dugum.yukseklik = 1 + max(yukseklik(dugum.left), yukseklik(dugum.right));
            int denge = denge_ne(dugum);

            if (denge > 1 && data < dugum.left.key)
                return sagaDondur(dugum);
            if (denge < -1 && data > dugum.right.key)
                return SolaDondur(dugum);
            if (denge > 1 && data > dugum.left.key)
            {
                dugum.left = SolaDondur(dugum.left);
                return sagaDondur(dugum);
            }
            if (denge < -1 && data < dugum.right.key)
            {
                dugum.right = sagaDondur(dugum.right);
                return SolaDondur(dugum);
            }
            return dugum;

        }

        public void inOrder(Dugum dugum)
        {
            if (dugum != null)
            {
                inOrder(dugum.left);
                Console.Write(dugum.key + " ");
                inOrder(dugum.right);
            }
        }

    }
}
