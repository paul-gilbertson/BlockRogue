using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockRogue
{
    class Program
    {
        private static RLNET.RLRootConsole rConsole;

        static void Main(string[] args)
        {
            var b = BlockChain.BlockChain.CreateChainFromFile("chain.json");
            //var b = BlockChain.BlockChain.CreateNewChain();
            b.CreateBlock("Test more");
            b.SaveChain("chain.json");
            Console.Out.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(b, Newtonsoft.Json.Formatting.Indented));

            rConsole = new RLNET.RLRootConsole("terminal8x8.png", 100, 70, 8, 8);
            rConsole.Update += RConsole_Update;
            rConsole.Render += RConsole_Render;
            rConsole.Run();

            Console.In.ReadLine();
        }

        private static void RConsole_Render(object sender, RLNET.UpdateEventArgs e)
        {
            rConsole.Draw();
        }

        private static void RConsole_Update(object sender, RLNET.UpdateEventArgs e)
        {
            rConsole.Print(10, 10, "Test", RLNET.RLColor.White);
        }
    }
}
