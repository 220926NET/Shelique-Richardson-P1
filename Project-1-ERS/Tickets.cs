using Microsoft.Data.SqlClient;

public class Tickets
{
    public decimal cost;
    public string expenseNote;
    public DateTime date = DateTime.Today;

    
    




    public void submitTicket()
    {
        SqlConnection connection = new SqlConnection("Server=tcp:revexample.database.windows.net,1433;Initial Catalog=RevatureEx;Persist Security Info=False;User ID=FlashCard;Password=flashProject01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //  connection.Open();
        // SqlCommand command = new SqlCommand("SELECT * FROM Tickets", connection);
        // SqlDataReader reader = command.ExecuteReader();
        // //List<userTickets> tickets = new List<userTickets>();
        // while (reader.Read())
        // {
        //     int ticketID = (int)reader["ticketID"];
        //     string userName = (string)reader["userName"];
        //     string expenseNote = (string)reader["expenseNote"];
        //     decimal cost = (decimal)reader["cost"];

        //     Console.WriteLine($"{ticketID} {userName} {expenseNote} {cost}");

        //     //account users = new account(name, last, user, pins, emails, type);

        //     //people.Add(users);
        // }
        // reader.Close();
        // connection.Close();

        connection.Open();

        Console.WriteLine("Please enter what the expense was for and any additonal notes below.");
        Console.WriteLine("----------------------------------------------");
        expenseNote = Console.ReadLine();

        Console.WriteLine("Please enter the amount you would like reimbursed.");
        Console.WriteLine("----------------------------------------------");
        cost = Convert.ToDecimal(Console.ReadLine());



        string insertTicket = "Insert into allTickets (userName, expenseNote, cost, [date],[status]) values ('"+ start.userN +"','" + expenseNote + "','"+ cost +"', GetDate(),'Pending Approval')";
        SqlCommand addTicket = new SqlCommand(insertTicket, connection);
        //addUser.Parameters.AddWithValue("userName", @userN);
        addTicket.ExecuteNonQuery();
        connection.Close();


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
