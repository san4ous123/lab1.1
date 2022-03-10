using System;

public class HW1
{
    public static long QueueTime(int[] customers, int n)
    {
        int theTime = 0;
        while (customers.Length > 0)
        {
            int cassazan = 0;
            if (n > customers.Length)
            {
                cassazan = customers.Length;
            }
            else
            {
                cassazan = n;
            }

            for (int x = 0; x < cassazan; x++)
            {
                customers[x]--;
            }
            customers = Array.FindAll(customers, y => y != 0);

            theTime++;
        }
        return theTime;
    }
}
class Programm
{
    static void Main()
    {
        Console.WriteLine(HW1.QueueTime(new int[] { 5, 3, 4 }, 1) == 12);
        Console.WriteLine(HW1.QueueTime(new int[] { 10, 2, 3, 3 }, 2) == 10);
        Console.WriteLine(HW1.QueueTime(new int[] { 2, 3, 10 }, 2) == 12);
    }
}
