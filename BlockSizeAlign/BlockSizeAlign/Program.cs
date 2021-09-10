using System;

namespace BlockSizeAlign
{
    class Program
    {
        private const int BlockSize = 1024 * 4;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] testInt = { 0, 1, 2, 1024 * 4, 1024 * 4 + 1, 1024 * 1024 * 4, 1024 * 1024 * 16 - 1 };
            for(int i = 0; i < testInt.Length; i++)
            {
                int size = (testInt[i] - 1 + BlockSize) / BlockSize * BlockSize;
                Console.WriteLine(testInt[i] + " size: " + size);
            }       
        }
    }
}

//Hello World!
//0 size: 0
//1 size: 4096
//2 size: 4096
//4096 size: 4096
//4097 size: 8192
//4194304 size: 4194304
//16777215 size: 16777216
