using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    //Code provided by Farid in the assignment 2.
    internal class Transaction
    {
        Accunt account1 = new Accunt();
        Accunt account2 = new Accunt();
        Mutex mutexLock=new Mutex();

        //Method to start the threads with deadlock.
        public void StartDeadlockThreads() 
        {
            Thread t1 = new Thread(() => account1.DeadlockTransfer(account2, 500, "Account1", "Account2"));
            Thread t2 = new Thread(() => account2.DeadlockTransfer(account1, 500, "Account2", "Account1"));

            t1.Start();
            t2.Start();

        }

        //Method to start the threads with no deadlock.
        public void StartNoDeadlockThreads() 
        {
            Thread t3 = new Thread(() => account1.NoDeadLockTransfer(mutexLock, account2, 500, "Account1", "Account2"));
            Thread t4 = new Thread(() => account2.NoDeadLockTransfer(mutexLock, account1, 500, "Account2", "Account1"));
            t3.Start();
            t4.Start();
        }


    }
}
