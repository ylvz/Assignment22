using Assignment22;

public class Client
{
    public int Id { get; private set; }
    private BankAccount account;
    private bool operating = true;

    // Constructor initializes a new client with a specified bank account and client ID.
    public Client(BankAccount account, int clientId)
    {
        this.account = account;
        Id = clientId;
    }

    // Continuously performs random transactions on the bank account until stopped.
    public void Run()
    {
        Random random = new Random(Id);
        while (operating)
        {
            bool isDeposit = random.NextDouble() > 0.5;
            double amount = random.Next(1, 1000);
            account.Transaction(isDeposit ? amount : -amount, Id);
            Thread.Sleep(800); // simulate time between transactions
            Console.WriteLine("Client ID:" + Id + " Deposited amount:" + amount);
        }
    }


    // Stops the client from making further transactions.
    public void Stop() => operating = false;
}