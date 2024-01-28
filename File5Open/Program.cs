using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("Birinci fayl nomini kiriting:");
        string firstFileName = Console.ReadLine();

        // open the first file
        Thread firstThread = new Thread(() => OpenFile(firstFileName));
        firstThread.Start();
        firstThread.Join(); // Birinchi faylni ochishni kutish

        Console.WriteLine($"First file opened, Enter the next file name : ");

        Thread[] threads = new Thread[4];
        for (int i = 0; i < 4; i++)
        {
            Console.Write($"File {i + 2}: ");
            string fileName = Console.ReadLine();

            int index = i; // Thread ichida ishlatish uchun indexni saqlash
            threads[i] = new Thread(() => OpenFile(fileName));
            threads[i].Start();
        }

        // Barcha Thread-larni kutib olish
        foreach (var thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine("All files are opened.");
    }

    static void OpenFile(string fileName)
    {
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: File is opening - {fileName}");
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: File is already opened- {fileName}");
    }
}
