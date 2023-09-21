using System;
using Cobilas.IO.Serialization.Json;

namespace com.cobilas.cs.lib.io.test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(Json.Serialize(new just { num1 = "Olá", num2 = "Mundo" }));

            _ = Console.ReadLine();
        }
    }

    [Serializable]
    class just {
        public string num1;
        //[NonSerialized] 
        public string num2;
    }
}
