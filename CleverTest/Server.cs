using System.Threading;

namespace CleverTest
{
    public static class Server
    {
        private static ReaderWriterLockSlim rwl = new ReaderWriterLockSlim();
        static int Count { get; set; } = 0;
        public static int GetCount()
        {
            rwl.EnterReadLock();
            try
            {
                Thread.Sleep(300);
                return Count;
            }
            finally
            {
                rwl.ExitReadLock();
            }
        }


        public static void AddToCount(int value)
        {
            rwl.EnterWriteLock();
            try
            {
                Thread.Sleep(10000);
                Count += value;
            }
            finally
            {
                rwl.ExitWriteLock();
            }
        }
    }
}
