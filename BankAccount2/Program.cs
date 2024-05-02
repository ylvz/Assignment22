// See https://aka.ms/new-console-template for more information
using System.Security.Principal;

Console.WriteLine("Hello, World!");
Account account1 = new Account();
Account account2 = new Account();
// Thread for transferring money from account1 to account2
Thread t1 = new Thread(()->account1.transfer(account2, 500), "Transaction
1");
// Thread for transferring money from account2 to account1
Thread t2 = new Thread(()->account2.transfer(account1, 300), "Transaction
2");
t1.start();
t2.start();
