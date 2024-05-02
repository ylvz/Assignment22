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

    // Executes a transaction on the bank account with thread safety, records security stamps, and verifies the transaction.
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

    // Returns the number of transaction-related errors detected by the security system.
    public int GetNumberOfErrors()
    {
        return security.numberOfErrors;
    }
}
