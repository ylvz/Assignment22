using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{

    internal class Transaction
    {
        Accunt account1 = new Accunt();
        Accunt account2 = new Accunt();
        Mutex mutexLock=new Mutex();
        bool isRunning = true;

        public void StartDeadlockTransaction() 
        {
            Thread t1 = new Thread(() => account1.DeadlockTransfer(account2, 500, "Account1", "Account2"));
            Thread t2 = new Thread(() => account2.DeadlockTransfer(account1, 500, "Account2", "Account1"));

            t1.Start();
            t2.Start();

        }

        public void StartNoDeadlockTransaction() 
        {
            Thread t3 = new Thread(() => account1.NoDeadLockTransfer(mutexLock, account2, 500, "Account1", "Account2"));
            Thread t4 = new Thread(() => account2.NoDeadLockTransfer(mutexLock, account1, 500, "Account2", "Account1"));
            t3.Start();
            t4.Start();
        }

        public bool IsRunning { get { return isRunning; } set { isRunning = value; } }

    }
}
