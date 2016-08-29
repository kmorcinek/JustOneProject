using System;
using System.Diagnostics;

namespace JustOneProject.VariousStuff.MemoryConsumption
{
    public class MemoryGuard
    {
        private const int MemoryThresholdInMegabytes = 550;

        private static long _arraysTotalLength;

        private static readonly object SyncRoot = new object();

        public void UpdateArrayLengthAndCallGcWhenAppropriate(int length)
        {
            lock (SyncRoot)
            {
                _arraysTotalLength += length;

                Debug.WriteLine(_arraysTotalLength);

                if (_arraysTotalLength > MemoryThresholdInMegabytes * 1024 * 1024)
                {
                    CallGc();

                    _arraysTotalLength = length;
                }
            }
        }

        /// <summary>
        /// We have problems with large objects in 2nd generation of GC. Caused by concatenating byte arrays in MobileSynchronizationService.Merge method().
        /// According to http://stackoverflow.com/questions/233596/best-practice-for-forcing-garbage-collection-in-c-sharp we can make explicit GC.
        /// </summary>
        private static void CallGc()
        {
            // Big arrays are allocated in 2nd generation
            const int bigArraysGeneration = 2;
            Debug.WriteLine("Invoked Garbage Collection");
            GC.Collect(bigArraysGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
        }
    }
}