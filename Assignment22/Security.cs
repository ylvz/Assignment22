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

        public void MakePreTransactionStamp(double balance,int clientId)
        {
            Stamp stamp = new Stamp(clientId, balance);
            //Create stamp w client id and balance
            //Add stamp to transactionHistory list
            transactionHistory.Add(stamp);
            preBalance = balance;
            //assign parameter balance to pre balance and return string about info 
        }

        public void MakePostTransactionStamp(double balance,int clientId)
        {
            //Exactly the same as MakePreTransactionStamp except you assign balance to postBalance
            Stamp stamp = new Stamp(clientId, balance);
            transactionHistory.Add(stamp);
            postBalance = balance;

        }

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
