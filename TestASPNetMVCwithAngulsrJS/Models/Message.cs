using System;
using System.Collections.Generic;

namespace TestASPNetMVCwithAngulsrJS.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Original { get; set; }

        public string Encrypted
        {
            get
            {
                return Encrypting(this.Original);
            }
        }

        public Nullable<System.DateTime> DateTime { get; set; }

        private static string Encrypting(string original)
        {
            string res = original;
            DatabaseContext db = new DatabaseContext();
            IEnumerable<Symbol> symbols = (IEnumerable<Symbol>)db.Symbols;

            foreach (Symbol symbol in symbols)
            {
                string oldSymbol = symbol.OldSymbol;
                string newSymbol = symbol.NewSymbol;

                res = res.Replace(oldSymbol, newSymbol);
            }
            return res;
        }
    }
}