using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockRogue
{
    class Program
    {
        static void Main(string[] args)
        {
            //var b = BlockChain.BlockChain.CreateChainFromFile("chain.json");
            var b = BlockChain.BlockChain.CreateNewChain();
            b.CreateBlock("Test more");
            b.SaveChain("chain.json");
            Console.Out.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(b, Newtonsoft.Json.Formatting.Indented));
            Console.In.ReadLine();
        }
    }
}
