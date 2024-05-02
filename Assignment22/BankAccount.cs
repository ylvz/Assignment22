using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment22;

public class BankAccount
{
    public double balance { get; private set; }
    public int totalTransactions { get; private set; }
    Security security = new Security();
    Mutex mutex = new Mutex();

    public void Transaction(double amount, int clientId)
    {
        try
        {
            mutex.WaitOne();
            security.MakePreTransactionStamp(balance, clientId);
            balance += amount;
            totalTransactions++;
            security.MakePostTransactionStamp(balance, clientId);
            security.VerifyLastTransaction();
        }

        finally { mutex.ReleaseMutex(); }

    }

    public int GetNumberOfErrors()
    {
        return security.numberOfErrors;
    }
}
