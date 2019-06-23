using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class cicle
    {
        int meaning;
        cicle next;
        public cicle(int n)
        {
            meaning = n;
            next = null;
        }
        public cicle(int n,cicle nekst)
        {
            meaning = n;
            next = nekst;
        }
        public int Meaning
        {
            get
            {
                return meaning;
            }
            set
            {
                meaning = value;
            }
        }
        public cicle Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите N - количество элементов списка");
            int n = NaturalCheck();
            cicle head= CicleCreate(n);
            cicle tmp = head;
            Console.WriteLine("Дважды выведенный список (демонстрация цикличности)");
            for (int i = 0; i < 2*n; i++)
            {
                Console.Write(tmp.Meaning+" ");
                tmp = tmp.Next;
            }
            Console.WriteLine();
            Console.WriteLine("Введите N - элемент, который нужно найти");
            int v = NaturalCheck();
            cicle srch = CicleSearch(head,v);
            if (srch == null)
            {
                Console.WriteLine("N/F");
            }
            else
            {
                Console.WriteLine("Found");
            }
            Console.WriteLine("Введите N - элемент, который нужно удалить");
            v = NaturalCheck();
            CicleDelete(head,v);
            tmp = head;
            Console.WriteLine("Дважды выведенный список");
            for (int i = 0; i < 2 * n-1; i++)
            {
                Console.Write(tmp.Meaning + " ");
                tmp = tmp.Next;
            }
            Console.ReadLine();
        }
        static cicle CicleCreate(int n)
        {
            cicle c = new cicle(1);
            c.Next = CicleCreate(n, 2, c);
            return c;
        }
        static cicle CicleCreate(int n,int number, cicle head)
        {

            cicle c = new cicle(number);
            if (number < n)
            {
                c.Next= CicleCreate(n, number+1, head);
            }
            else
            {
                c.Next = head;
            }
            return c;
        }
        static cicle CicleSearch(cicle head,int n)
        {
            if (head.Meaning == n)
            {
                return head;
            }
            else
            {
                return CicleSearch(head.Next, n,1);
            }
        }
        static cicle CicleSearch(cicle head, int n,int c)
        {
            if (head.Meaning == n)
            {
                return head;
            }
            else
            {
                if (head.Meaning == 1)
                {
                    return null;
                }
                else
                {
                    return CicleSearch(head.Next, n,1);
                }
                
            }
        }
        static void CicleDelete(cicle head,int n)
        {
            if (head.Next.Meaning == n)
            {
                head.Next = head.Next.Next;
            }
            else
            {
                CicleDelete(head.Next, n, 1);
            }
        }
        static void CicleDelete(cicle head, int n,int c)
        {
            if (head.Next.Meaning == n)
            {
                head.Next = head.Next.Next;
            }
            else
            {
                if (head.Meaning == 1)
                {
                    Console.WriteLine("Element N/F");
                }
                else
                {
                    CicleDelete(head.Next, n, 1);
                }

            }
        }
        static int IntCheck()
        {
            int n;
            bool ok = false;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string s = Console.ReadLine();
            do
            {
                ok = int.TryParse(s, out n);
                if (ok == false)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ввод неправильный. Повторите.");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    s = Console.ReadLine();
                }
            } while (!ok);
            Console.ForegroundColor = ConsoleColor.White;
            return (n);
        }
        static int NaturalCheck()
        {
            int n;
            bool ok = false;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string s = Console.ReadLine();
            do
            {
                ok = int.TryParse(s, out n);
                if (ok == false)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ввод неправильный. Повторите.");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    s = Console.ReadLine();
                }
                else
                {
                    if (n <= 0)
                    {
                        ok = false;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Ввод неправильный. Повторите.");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        s = Console.ReadLine();
                    }
                }
            } while (!ok);
            Console.ForegroundColor = ConsoleColor.White;
            return (n);
        }
    }

}
