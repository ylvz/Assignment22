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
    private readonly Mutex mutex = new Mutex();


    public void Transaction(double amount, int clientId)
    {
        mutex.WaitOne(); // Start of critical section

        security.MakePreTransactionStamp(balance, clientId);
        balance += amount;
        totalTransactions++;
        security.MakePostTransactionStamp(balance, clientId);
        security.VerifyLastTransaction();

        mutex.ReleaseMutex(); // End of critical section
    }

    public int GetNumberOfErrors()
    {
        return security.numberOfErrors;
    }
}
