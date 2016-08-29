using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace JustOneProject.VariousStuff.MemoryConsumption
{
    public class MemoryConsumptionTests
    {
        private static MemoryGuard _memoryGuard = new MemoryGuard();

        public static void TestMemoryConsumption()
        {
            const int length = 64 * 1000 * 1000;
            var array = new byte[length];
            array[9999] = 33;
            var arrayForAdding = new byte[15 * 1000 * 1000];
            arrayForAdding[9999] = 33;

            for (int i = 0; i < 8; i++)
            {
                array = Merge(array, arrayForAdding);
            }

            arrayForAdding = new byte[15 * 1000 * 1000];
            
            for (int i = 0; i < 8 * 2; i++)
            {
                array = Merge(array, arrayForAdding);
            }

        }

        private static byte[] Merge(byte[] data, byte[] bytesToAppend)
        {
            if (data == null)
            {
                return bytesToAppend;
            }

            if (bytesToAppend == null)
            {
                return data;
            }

            var newArrayLength = data.Length + bytesToAppend.Length;
            var message = "Merge: newArrayLength = " + newArrayLength / (1000 * 1000);
            Debug.WriteLine(message);

            PrintMemoryUsedByGC();
            _memoryGuard.UpdateArrayLengthAndCallGcWhenAppropriate(newArrayLength);

            byte[] result = new byte[newArrayLength];
            Array.Copy(data, 0, result, 0, data.Length);
            Array.Copy(bytesToAppend, 0, result, data.Length, bytesToAppend.Length);
            Wait();
            return result;
        }

        private static void Wait()
        {
            Task.Delay(TimeSpan.FromSeconds(1)).Wait();
        }

        private static void PrintMemoryUsedByGC()
        {
            long totalMemory = GC.GetTotalMemory(false) / 1024;
            Debug.WriteLine("Total memory in KB: " + totalMemory);
        }
        
    }
}