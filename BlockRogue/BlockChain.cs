using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BlockRogue.BlockChain
{
    class BlockChain
    {
        private LinkedList<Block> _blocks = new LinkedList<Block>();
        public LinkedList<Block> Blocks {  get { return _blocks;  } }

        protected BlockChain()
        {
            _blocks.AddFirst(new Block("And then there was love", "0"));
        }

        protected BlockChain(Block genesisBlock)
        {
            _blocks.AddFirst(genesisBlock);
        }

        public bool CreateBlock(string data)
        {
            _blocks.AddLast(new Block(data, _blocks.Last.Value.Hash));

            return true;
        }

        public bool SaveChain(string filename)
        {
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(filename))
            {
                output.Write(JsonConvert.SerializeObject(this, Formatting.None));
            }

            return true;
        }

        public static BlockChain CreateChainFromFile(string filename)
        {
            string data = String.Empty;

            using (System.IO.StreamReader input = new System.IO.StreamReader(filename))
            {
                data = input.ReadToEnd();
            }

            JObject jdata = (JObject)JsonConvert.DeserializeObject(data);
            IList<Block> b = jdata["Blocks"].Select(t => t.ToObject<Block>()).ToList();

            BlockChain chain = new BlockChain(b[0]);

            foreach (Block block in b.Skip(1))
            {
                chain.Blocks.AddLast(block);
            }

            return chain;
        }

        public static BlockChain CreateNewChain()
        {
            return new BlockChain();
        }
    }
}
