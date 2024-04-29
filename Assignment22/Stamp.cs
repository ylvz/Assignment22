using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment22
{
    internal class Stamp
    {
        public int clientId;
        public double balance;

        public Stamp(int clientId, double balance)
        {
            this.balance = balance;
            this.clientId = clientId;
        }
    }
}
