using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace BlockRogue.BlockChain
{
    class Block
    {
        public long Timestamp { get; }
        public string Data { get; }
        public string PreviousHash { get; }

        public string Hash { get; protected set; }
        public string Nonce { get { return this._nonce; } set { this._nonce = value; Hash = CreateHash(); } }
        private string _nonce = string.Empty;

        public Block(string data, string previousHash)
        {
            Data = data;
            PreviousHash = previousHash;
            Timestamp = DateTime.UtcNow.Ticks; //TODO: Convert to Unix Timestamp Ticks
            Hash = CreateHash();
        }

        [JsonConstructor]
        public Block(string data, string previousHash, long timestamp, string hash)
        {
            Data = data;
            PreviousHash = previousHash;
            Timestamp = timestamp;


            if (hash == CreateHash())
                Hash = hash;
            else
                throw new Exception("Invalid block");
        }

        protected string CreateHash()
        {
            byte[] data = Encoding.UTF8.GetBytes(Timestamp.ToString() + Data + PreviousHash + Nonce);
            byte[] hashData = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);

            string hash = string.Empty;

            foreach (byte b in hashData)
            {
                hash += b.ToString("x2");
            }

            return hash;
        }
    }
}
