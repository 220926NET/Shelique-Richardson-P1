using Microsoft.Data.SqlClient;


public class Manager
{
            SqlConnection conn = new SqlConnection("Server=tcp:revexample.database.windows.net,1433;Initial Catalog=RevatureEx;Persist Security Info=False;User ID=FlashCard;Password=flashProject01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    public void managerApp()
    {

        Tickets submit1 = new Tickets();
        Console.WriteLine("[1]Would you like to submit an expense reimbursement ticket?");
        Console.WriteLine("[2]Would you like to review your previous expense reimbursement tickets?");
        Console.WriteLine("[3]Would you like to view all expense reimbursement tickets?");
        Console.WriteLine("[4]Would you like to process pending tickets?");
        Console.WriteLine("----------------------------------------------");

        int input = int.Parse(Console.ReadLine());

        if (input == 1)
        {
            submit1.submitTicket2();
        }
        else if (input == 2)
        {
            submit1.previousTickets2();
        }
        else if(input == 3){
            viewAllTickets();

        }else if(input == 4){

        }

    }



    public void viewAllTickets(){
         conn.Open();

        Console.WriteLine("Here are all of the ticket submissions!");
        Console.WriteLine("____________________________________________");
        SqlCommand allTix = new SqlCommand("SELECT * FROM allTickets", conn);

        SqlDataReader reading = allTix.ExecuteReader();
        //List<userTickets> tickets = new List<userTickets>();
        while (reading.Read())
        {
            int tickID = (int)reading["ticketID"];
            string useName = (string)reading["userName"];
            string exNote = (string)reading["expenseNote"];
            decimal price = (decimal)reading["cost"];
            string stats = (string)reading["status"];
            DateTime  date = (DateTime)reading["date"];

            Console.WriteLine($"{tickID} | {useName} | {exNote} | {price} | {date} | {stats}");

            //account users = new account(name, last, user, pins, emails, type);

            //people.Add(users);
        }
        reading.Close();
        conn.Close();
        Console.WriteLine("____________________________________________");
        managerApp();

    }

}