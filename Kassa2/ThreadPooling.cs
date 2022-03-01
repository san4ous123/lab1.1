using System;
using System.Threading;

namespace Kassa2
{
    class ThreadPooling
    {
        public static int[] People = new int[] {5, 3 ,4};
        public static int i,Mnoz;
        public static bool A, B, C;
        public static DateTime starttime = DateTime.Now;
        static void Main()
        {
            HW1.QueueTime(People, 1);

            Console.ReadLine();
        }
        public static void Start(int n)
        {
            Mnoz = n;
            if(n > 0)
                ThreadPool.QueueUserWorkItem(WriteKassA);
            if (n > 1)
                ThreadPool.QueueUserWorkItem(WriteKassB);
            if (n > 2)
                ThreadPool.QueueUserWorkItem(WriteKassC);
        }

        static void WriteKassA(object ob)
        {
            int a = People[i];
            while (a > 0)
            {
                Console.Write(a);
                a--;
                Thread.Sleep(500);
            }

            i+= Mnoz;
            if (i < People.Length)
                ThreadPool.QueueUserWorkItem(WriteKassA);
            else
            {
                A = true;
                CountHours();
            }
        }
        static void WriteKassB(object ob)
        {
            int b = People[i+1];
            while (b > 0)
            {
                Console.Write(b);
                b--;
                Thread.Sleep(500);
            }

           i+= Mnoz -1;
            if (i+1 < People.Length)
                ThreadPool.QueueUserWorkItem(WriteKassB);
            else
            {
                B = true;
                CountHours();
            }

        }
        static void WriteKassC(object ob)
        {
            int с = People[i + 2];
            while (с > 0)
            {
                Console.Write(с);
                с--;
                Thread.Sleep(500);
            }

            i+= Mnoz - 2;
            if (i+2 < People.Length)
                ThreadPool.QueueUserWorkItem(WriteKassC);
            else
            {
                C = true;
                CountHours();
            }
        }
        static void CountHours()
        {
            if (Mnoz == 1 & A == true)
                EndTime();
            else if (Mnoz == 2 & A == true && B == true)
                EndTime();
            else if (Mnoz == 3 & A == true && B == true && C == true)
                EndTime();
        }
        static void EndTime()
        {
            DateTime endtime = DateTime.Now;
            TimeSpan endtimeSec = (endtime - starttime) * 2;
            Console.WriteLine(" Затрачено " + endtimeSec.Seconds + " часов");
        }
    }
    public class HW1
    {
        public static long QueueTime(int[] customers, int n)
        {
            ThreadPooling.Start(n);
            return 0;
        }
    }

}
