using System;
using Cobilas.IO.Serialization.Json;

namespace com.cobilas.cs.lib.io.test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(Json.Serialize(new just { /*num1 = "Olá",*/ num2 = "Mundo", num3 = "terreno", num4 = "querido" }));

            _ = Console.ReadLine();
        }
    }

    [Serializable]
    class just : just2 {
        public string num3;
        //[NonSerialized] 
        public string num4;
    }

    [Serializable]
    class just2 {
        private string num1 = "Olá";
        //[NonSerialized] 
        public string num2;
    }
}
