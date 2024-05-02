using Assignment22;
using System;

internal class Manager
{
    private List<Client> clients = new List<Client>();
    private List<Thread> threads = new List<Thread>();
    private BankAccount bankAccount;
    public volatile bool operating = true;  // Use volatile to ensure visibility across threads
    private Security security = new Security();


    // Constructor initializes the manager with a specified bank account.
    public Manager(BankAccount bankAccount)
    {
        this.bankAccount = bankAccount;
    }
    // Starts a specified number of client threads to perform operations on the bank account.
    public void StartClients(int numberOfClients = 10)
    {
        for (int i = 0; i < numberOfClients; i++)
        {
            Client client = new Client(bankAccount, i);
            Thread thread = new Thread(new ThreadStart(client.Run));
            threads.Add(thread);
            clients.Add(client);
            thread.Start();
            operating = true;
        }
    }

    // Stops all client threads and ensures they have finished execution.
    public void StopClients()
    {
        operating = false;  // Signal threads to stop
        foreach (var thread in threads)
        {
            thread.Join();  // Ensure all threads finish
        }
    }

    // Displays the final results of the bank account after all transactions are completed.
    public void GatherResults()
    {
        Console.WriteLine($"Final Balance: {bankAccount.balance}");
        Console.WriteLine($"Total Transactions: {bankAccount.totalTransactions}");
        Console.WriteLine($"Number of Errors Detected: {bankAccount.GetNumberOfErrors()}"); 
    }
}
