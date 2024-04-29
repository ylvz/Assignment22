using Assignment22;

class Program
{
    private static SemaphoreSlim consoleSempahore=new SemaphoreSlim(1,1);
    static void Main(string[] args)
    {
        BankAccount sharedAccount = new BankAccount();
        List<Client> clients = new List<Client>();
        List<Thread> clientThreads = new List<Thread>();

        for (int i = 0; i < 5; i++)
        {
            var client = new Client(sharedAccount, i);
            var thread = new Thread(client.Run);
            clients.Add(client);
            clientThreads.Add(thread);
            thread.Start();
        }

        Console.WriteLine("Press any key to stop transactions...");
        Console.ReadKey();

        clients.ForEach(client => client.Stop());
        clientThreads.ForEach(thread => thread.Join());

        Console.WriteLine($"Final Balance: {sharedAccount.balance}");
        Console.WriteLine($"Total Transactions: {sharedAccount.totalTransactions}");
        Console.WriteLine($"Total Errors: {sharedAccount.GetNumberOfErrors}");
        Console.ReadKey();
    }
}