namespace Part2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Transaction transaction = new Transaction();
            bool validInput = false;

            while(!validInput)
            {
                Console.WriteLine("Press 1 for failing to lock or 2 successful locking.");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        transaction.StartDeadlockTransaction();
                        validInput = true;
                        break;
                    case "2":
                        transaction.StartNoDeadlockTransaction();
                        validInput = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input, enter one of the two options.");
                        break;
                }
            }

        }
    }
}