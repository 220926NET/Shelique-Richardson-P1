using Microsoft.Data.SqlClient;


public class Manager
{
    //Connection to the DB
    SqlConnection conn = new SqlConnection1().connectString();

    public void managerApp()
    {
        //Menu for the managers
        Tickets submit1 = new Tickets();
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("========================================================");
        Console.WriteLine("[1]Submit an expense reimbursement ticket?");
        Console.WriteLine("[2]Review your previous tickets?");
        Console.WriteLine("[3]View all tickets?");
        Console.WriteLine("[4]Process pending tickets?");
        Console.WriteLine("[0]Logout");
        Console.WriteLine("========================================================");

        int input = int.Parse(Console.ReadLine());
        Console.WriteLine("----------------------------");

        if (input == 1)
        {
            submit1.submitTicket();
        }
        else if (input == 2)
        {
            submit1.previousTickets();
        }
        else if (input == 3)
        {
            viewAllTickets();

        }
        else if (input == 4)
        {
            processTickets();
        }
        else if (input == 0)
        {
            Console.WriteLine("==========================");
            Console.WriteLine("See you later! GoodBye!");
            Console.WriteLine("==========================");
            Environment.Exit(0);
        }
    }

    //To view all tickets in the DB
    public void viewAllTickets()
    {
        conn.Open();

        Console.WriteLine("Here are all of the ticket submissions!");
        Console.WriteLine("____________________________________________");
        SqlCommand allTix = new SqlCommand("SELECT * FROM allTickets", conn);

        SqlDataReader reading = allTix.ExecuteReader();
        while (reading.Read())
        {
            int tickID = (int)reading["ticketID"];
            string useName = (string)reading["userName"];
            string exNote = (string)reading["expenseNote"];
            decimal price = (decimal)reading["cost"];
            string stats = (string)reading["status"];
            DateTime date = (DateTime)reading["date"];

            //To list the info from the DB in the Console
            Console.WriteLine($"{tickID} | {useName} | {exNote} | {price} | {date} | {stats}");
            Console.WriteLine("________________________________________________________");

        }
        reading.Close();
        conn.Close();
        managerApp();
    }

    //To process pending tickets in the DB
    public void processTickets()
    {
        Console.WriteLine("Here are all the tickets that are pending!");
        Console.WriteLine("______________________________________________");

        conn.Open();
        SqlCommand all = new SqlCommand("SELECT * FROM allTickets where status = 'Pending Approval'", conn);
        SqlDataReader viewAll = all.ExecuteReader();

        while (viewAll.Read())
        {
            int tickID = (int)viewAll["ticketID"];
            string useName = (string)viewAll["userName"];
            string exNote = (string)viewAll["expenseNote"];
            decimal price = (decimal)viewAll["cost"];
            string stats = (string)viewAll["status"];
            DateTime date = (DateTime)viewAll["date"];


            Console.WriteLine($"{tickID} | {useName} | {exNote} | {price} | {date} | {stats}");
            Console.WriteLine("________________________________________________________");

        }
        viewAll.Close();


        Console.WriteLine("Enter the ticketId of the ticket you want to process");
        int tixID = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("----------------------------");
        Console.WriteLine("[1]Approve Request/[2]Deny Request");
        Console.WriteLine("____________________________________________");

        int process = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("----------------------------");
        if (process == 1)
        {
            SqlCommand approveTix = new SqlCommand("update allTickets SET [status] = 'Approved' where ticketID= '" + tixID + "'", conn);
            approveTix.ExecuteNonQuery();
            Console.WriteLine("____________________________________________");
            Console.WriteLine($" Ticket number {tixID} has been approved!");

        }
        else if (process == 2)
        {
            SqlCommand denyTix = new SqlCommand("update allTickets SET [status] = 'Denied' where ticketID= '" + tixID + "'", conn);
            denyTix.ExecuteNonQuery();
            Console.WriteLine("____________________________________________");
            Console.WriteLine($" Ticket number {tixID} has been denied!");

        }
        conn.Close();
        Console.WriteLine("____________________________________________");
        managerApp();

    }

}