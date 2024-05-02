using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    internal class Accunt
    {
        int balance;
        public Mutex transferMutex = new Mutex();

        public void NoDeadLockTransfer(Mutex mutexLock, Accunt reciever,int amount, string account,string recieverName)
        {
            try
            {
                mutexLock.WaitOne();
                Thread.Sleep(500);
                reciever.transferMutex.WaitOne();
                reciever.balance -= amount;
                Console.WriteLine(account + " is inside the transfer method.");
                Console.WriteLine($"{amount} was transferred to {recieverName} from {account}. {account} " + $"Current balance = {balance}");
                mutexLock.ReleaseMutex();
            }
            finally { reciever.transferMutex.ReleaseMutex(); }

        }

        public void DeadlockTransfer(Accunt reciever, int amount, string account,string recieverName) 
        {
            lock (this)
            {
                Thread.Sleep(50);
                lock (reciever)
                {
                    reciever.balance -= amount;
                    balance -= amount;
                    Console.WriteLine(account + " is inside the transfer method.");
                    Console.WriteLine($"{amount} was transferred to {recieverName} from {account}. {account} " + $"Current balance = {balance}");
                }
            }
        }
    }
}
