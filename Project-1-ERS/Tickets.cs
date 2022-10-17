using Microsoft.Data.SqlClient;

public class Tickets
{
    public decimal cost;
    public string expenseNote;
    public DateTime date = DateTime.Today;

        //Connection to the DB
        SqlConnection connection = new SqlConnection1().connectString();

    public void TixMenu(){
        Console.WriteLine("[1]Submit a Ticket?");
        Console.WriteLine("[2]Review previous ticket submissions?");
        Console.WriteLine("[3]Logout");
        Console.WriteLine("----------------------------------------------");
        int response = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("----------------------------");
        if (response == 1)
        {
            submitTicket();
            }else if (response==2){
            previousTickets();
        }
        else
        {
            Console.WriteLine("GoodBye!");
            Environment.Exit(0);
        }

    }
    public void submitTicket()
    {
        connection.Open();

        Console.WriteLine("Please enter what the expense was for and any additonal notes below.");
        Console.WriteLine("----------------------------------------------");
        expenseNote = Console.ReadLine();
        Console.WriteLine("----------------------------");

        Console.WriteLine("Please enter the amount you would like reimbursed.");
        Console.WriteLine("----------------------------------------------");
        cost = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("----------------------------");

        string insertTicket = "Insert into allTickets (userName, expenseNote, cost, [date],[status]) values ('"+ start.userN +"','" + expenseNote + "','"+ cost +"', GetDate(),'Pending Approval')";
        SqlCommand addTicket = new SqlCommand(insertTicket, connection);
        //addUser.Parameters.AddWithValue("userName", @userN);
        addTicket.ExecuteNonQuery();
        connection.Close();
        Console.WriteLine($"Your ticket was successfully submitted on {date}. ");
        TixMenu();
    }



    public void previousTickets(){

        Console.WriteLine("Here are your previous ticket submissions!");
        Console.WriteLine("____________________________________________");

         connection.Open();
        SqlCommand previousTix = new SqlCommand("SELECT * FROM allTickets where userName = '"+start.userN+"'", connection);
        SqlDataReader reader = previousTix.ExecuteReader();
        //List<userTickets> tickets = new List<userTickets>();
        while (reader.Read())
        {
            int ticketID = (int)reader["ticketID"];
            string userName = (string)reader["userName"];
            string expenseNote = (string)reader["expenseNote"];
            decimal cost = (decimal)reader["cost"];
            string status = (string)reader["status"];
            DateTime date = (DateTime)reader["date"];

            Console.WriteLine($"{ticketID} | {userName} | {expenseNote} | {cost} | {date} | {status}");
            Console.WriteLine("________________________________________________________");

        }
        reader.Close();
        connection.Close();
        Console.WriteLine("____________________________________________");
        TixMenu();

    }

    Manager App2 = new Manager();
       public void submitTicket2()
    {
        connection.Open();

        Console.WriteLine("Please enter what the expense was for and any additonal notes below.");
        Console.WriteLine("----------------------------------------------");
        expenseNote = Console.ReadLine();

        Console.WriteLine("Please enter the amount you would like reimbursed.");
        Console.WriteLine("----------------------------------------------");
        cost = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("----------------------------");


        string insertTicket = "Insert into allTickets (userName, expenseNote, cost, [date],[status]) values ('"+ start.userN +"','" + expenseNote + "','"+ cost +"', GetDate(),'Pending Approval')";
        SqlCommand addTicket = new SqlCommand(insertTicket, connection);
        //addUser.Parameters.AddWithValue("userName", @userN);
        addTicket.ExecuteNonQuery();
        connection.Close();

        Console.WriteLine($"Your ticket was successfully submitted on {date}. ");
        
        App2.managerApp();
    }


    public void previousTickets2(){

        Console.WriteLine("Here are your previous ticket submissions!");
        Console.WriteLine("____________________________________________");

         connection.Open();
        SqlCommand previousTix = new SqlCommand("SELECT * FROM allTickets where userName = '"+start.userN+"'", connection);
        SqlDataReader reader = previousTix.ExecuteReader();
        //List<userTickets> tickets = new List<userTickets>();
        while (reader.Read())
        {
            int ticketID = (int)reader["ticketID"];
            string userName = (string)reader["userName"];
            string expenseNote = (string)reader["expenseNote"];
            decimal cost = (decimal)reader["cost"];
            string status = (string)reader["status"];
            DateTime date = (DateTime)reader["date"];

            Console.WriteLine($"{ticketID} | {userName} | {expenseNote} | {cost} | {date} | {status}");

            Console.WriteLine("________________________________________________________");

        }
        reader.Close();
        connection.Close();
        Console.WriteLine("____________________________________________");
        App2.managerApp();

    }


}
