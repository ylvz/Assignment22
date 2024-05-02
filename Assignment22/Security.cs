using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment22
{
    
    internal class Security
    {
        List<Stamp> transactionHistory;
        public int numberOfErrors;
        double preBalance;
        double postBalance;


        public Security() 
        {
            transactionHistory = new List<Stamp>();
        }

        // Records a pre-transaction stamp containing the client ID and balance before the transaction.
        public void MakePreTransactionStamp(double balance,int clientId)
        {
            Stamp stamp = new Stamp(clientId, balance);
            transactionHistory.Add(stamp);
            preBalance = balance;
        }

        // Records a post-transaction stamp containing the client ID and balance after the transaction.
        public void MakePostTransactionStamp(double balance,int clientId)
        {
            Stamp stamp = new Stamp(clientId, balance);
            transactionHistory.Add(stamp);
            postBalance = balance;

        }

        // Verifies the last transaction to ensure the recorded balances align correctly; increments error count if not.
        public void VerifyLastTransaction()
        {
            // Assumes transactionHistory has the correct ordering of pre and post transaction states
            if (transactionHistory.Count < 2)
                return;

            var lastTransaction = transactionHistory[transactionHistory.Count - 1];
            var previousTransaction = transactionHistory[transactionHistory.Count - 2];


            // Verify if the post transaction balance matches expected balance from the pre transaction state
            if (previousTransaction.balance + (postBalance - preBalance) != lastTransaction.balance)
            {
                numberOfErrors++;
            }
        }


    }
}
