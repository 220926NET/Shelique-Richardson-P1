namespace ReimbursementTickets;
public class Tickets
{
    public double cost;
    public string expenseNote;
    public DateTime date = DateTime.Today;


        public void submitTicket()
        {

            Console.WriteLine("Please enter what the expense was for and any additonal notes below.");
            Console.WriteLine("----------------------------------------------");
            expenseNote = Console.ReadLine();

            Console.WriteLine("Please enter the amount you would like reimbursed.");
            Console.WriteLine("----------------------------------------------");
            cost = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Your ticket was successfully submitted on {date}. ");
            Console.WriteLine("[1]Submit another Ticket?");
            Console.WriteLine("[2]Review previous ticket submissions?");
            Console.WriteLine("[3]Logout");
            Console.WriteLine("----------------------------------------------");
            int response = Convert.ToInt32(Console.ReadLine());
            if (response == 1)
            {
                submitTicket();
                //}else if (response==2){
                // previousTickets();
            }
            else
            {
                Console.WriteLine("GoodBye!");
                Environment.Exit(0);
            }
        } 
    


}
