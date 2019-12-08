﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTestsApp
{
    public class ThreadWork
    {
        public static void DoWork()
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("Thread - working.");
                    Thread.Sleep(100);
                }
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine("Thread - caught ThreadAbortException - resetting.");
                Console.WriteLine("Exception message: {0}", e.Message);
                Thread.ResetAbort();
            }
            Console.WriteLine("Thread - still alive and working.");
            Thread.Sleep(1000);
            Console.WriteLine("Thread - finished working.");
        }
    }

    public class MultiThreading
    {
        public static void Execute()
        {
            ThreadStart myThreadDelegate = new ThreadStart(ThreadWork.DoWork);
            Thread myThread = new Thread(myThreadDelegate);
            myThread.Start();
            Thread.Sleep(100);
            Console.WriteLine("Main - aborting my thread.");
            myThread.Abort();
            myThread.Join();
            Console.WriteLine("Main ending.");
        }
    }
}
