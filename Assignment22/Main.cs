using Assignment22;

internal class Main
{
    private List<Client> clients = new List<Client>();
    private List<Thread> threads = new List<Thread>();
    private BankAccount bankAccount;
    public volatile bool operating = true;  // Use volatile to ensure visibility across threads
    public static Semaphore semaphore = new Semaphore(1, 1);
    private object lockObject = new object();
    private Security security = new Security();



    public Main(BankAccount bankAccount)
    {
        this.bankAccount = bankAccount;
    }

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

    public void StopClients()
    {
        operating = false;  // Signal threads to stop
        foreach (var thread in threads)
        {
            thread.Join();  // Ensure all threads finish
        }
    }

    public void GatherResults()
    {
        Console.WriteLine($"Final Balance: {bankAccount.balance}");
        Console.WriteLine($"Total Transactions: {bankAccount.totalTransactions}");
        Console.WriteLine($"Number of Errors Detected: {security.numberOfErrors}");
    }
}
