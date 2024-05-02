using Assignment22;

class Program
{

    // Entry point for the console application. Sets up bank account management with multiple client threads.
    static void Main(string[] args)
    {
        BankAccount sharedAccount = new BankAccount();
        List<Client> clients = new List<Client>();
        List<Thread> clientThreads = new List<Thread>();
        Manager manager = new Manager(sharedAccount);

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

        manager.GatherResults();
        Console.ReadKey();
    }
}