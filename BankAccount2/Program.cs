namespace Part2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Transaction transaction = new Transaction();
            bool validInput = false;

            //Make the user input 
            while(!validInput)
            {
                Console.WriteLine("Press 1 for failed locking or 2 for successful locking.");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        transaction.StartDeadlockThreads();
                        validInput = true;
                        break;
                    case "2":
                        transaction.StartNoDeadlockThreads();
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