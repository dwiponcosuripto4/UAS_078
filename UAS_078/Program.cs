using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_078
{
    class Node
    {
        public int tahun;
        public int nobuku;
        public string nama;
        public string namap;

        public Node next;
        public Node prev;

    }
    class Program
    {
        public Node START;
        public Program()
        {
            START = null;
        }

        public void addNode()
        {
            int tahun;
            int nobuku;
            string nama;
            string namap;
            Console.Write("\nMasukan tahun terbit: ");
            tahun = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukan no buku: ");
            nobuku = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukan judul buku: ");
            nama = Console.ReadLine();
            Console.Write("\nMasukan nama pengarang: ");
            namap = Console.ReadLine();
            Node newnode = new Node();
            newnode.tahun = tahun;
            newnode.nobuku = nobuku;
            newnode.nama = nama;
            newnode.namap = namap;

            if (START == null || tahun <= START.tahun)
            {
                if ((START != null) && (tahun == START.tahun))
                    Console.WriteLine("\nDuplicate year not allowed");
                return;
            }
            newnode.next = START;
            if (START != null)
                START.prev = newnode;
            newnode.prev = null;
            START = newnode;
            return;
        }
        public bool search(int tahun, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null &&
                tahun != current.tahun; previous = current,
                current = current.next)
            { }
            return (current != null);
        }

        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the ascending order of " + "books are:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null;
                    currentNode = currentNode.next)
                    Console.Write(currentNode.tahun + "  " + currentNode.nama + " " + currentNode.namap + " " + currentNode.nobuku);
            }
        }
        public void retraverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the descending order of " + "books are:\n");
                Node currentNode;
                for (currentNode = START; currentNode.next != null;
                    currentNode = currentNode.next)
                { }
                while (currentNode != null)
                {
                    Console.Write(currentNode.tahun + "  " + currentNode.nama + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        static void Main(string[] args)
        {
            Program x = new Program();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Tambah Buku");
                    Console.WriteLine("2. Urutkan Buku dari awal ditambhkan ");
                    Console.WriteLine("3. Urutkan Buku dari terakhir ditambahkan ");
                    Console.WriteLine("4. Cari buku");
                    Console.WriteLine("5. Exit");
                    Console.WriteLine("\n Enter your choice (1-5) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    Console.WriteLine();
                    switch (ch)
                    {
                        case '1':
                            {
                                x.addNode();
                            }
                            break;
                        case '2':
                            {
                                x.traverse();
                            }
                            break;
                        case '3':
                            {
                                x.retraverse();
                            }
                            break;
                        case '4':
                            {
                                if (x.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is Empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record you want to search: ");
                                int tahun = Convert.ToInt32(Console.ReadLine());
                                if (x.search(tahun, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.tahun);
                                    Console.WriteLine("\nName: " + curr.nama);
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the values entered.");
                }
            }
        }
    }
}
// 2. DoublyLinkList karena dapat menyimpan data dobel atau lebih dari satu
// 3. Operasi yang digunakan dalam algorithma stack adalah Push dan Pop
// 4. Data dapat ditambakan diakhir disebut insert, sedangkan data dihapus dari yang paling terkahir disebut delete atau remove
// 5a. 17
// 5b. 25 20 10 5 1 8 15 12 22 36 30 28 40 38 48 45 50 (PREORDER)
