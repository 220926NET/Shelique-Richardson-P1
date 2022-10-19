using Microsoft.Data.SqlClient;

public class register
{
    public void registration()
    {
        start st = new start();
        userLogin login = new userLogin();

        SqlConnection connection = new SqlConnection1().connectString();

        connection.Open();

        Console.WriteLine("~Register~");
        Console.WriteLine("~~~~~~~~~~~");
        Console.WriteLine("Please enter your first name.");
        Console.WriteLine("----------------------------------------------");
        string? firstName = Console.ReadLine();
        Console.WriteLine("----------------------------");
        Console.WriteLine("Please enter your last name");
        Console.WriteLine("----------------------------------------------");
        string? lastName = Console.ReadLine();
        Console.WriteLine("-----------------------------");

        Console.WriteLine("Please create a username.");
        Console.WriteLine("----------------------------------------------");
        string? userGuess = Console.ReadLine();
        Console.WriteLine("----------------------------");

        //Checking whether the entered userName already exists in DB
        SqlCommand checkUserName = new SqlCommand("select userName from Users where userName = '" + userGuess + "'", connection);
        //checkUserName.Parameters.AddWithValue("userName", @userN);
        string userExist = (string)checkUserName.ExecuteScalar();

        while (true)
        {
            if (userExist != userGuess)
            {
                break;
            }
            Console.WriteLine("That username exists already! Enter a new one.");
            Console.WriteLine("----------------------------------------------");
            userGuess = Console.ReadLine();
            Console.WriteLine("----------------------------");
        }

        Console.WriteLine("Please create a 6 digit pin to login");
        Console.WriteLine("----------------------------------------------");
        var userPin = Console.ReadLine();
        Console.WriteLine("----------------------------");

        //limits input to 6 digit pin

        while (userPin.Length > 6 || userPin.Length < 6)
        {
            Console.WriteLine("Please enter a pin that is ONLY 6 digits long");
            Console.WriteLine("----------------------------------------------");
            userPin = Console.ReadLine();
            Console.WriteLine("----------------------------");
        }

        Console.WriteLine("Next enter your email address.");
        Console.WriteLine("----------------------------------------------");
        string? email = Console.ReadLine();
        Console.WriteLine("----------------------------");

        //Checks if email already exists in DB
        SqlCommand checkEmail = new SqlCommand("select email from Users where email = '" + email + "'", connection);
        //checkUserName.Parameters.AddWithValue("userName", @userN);
        string emailExist = (string)checkEmail.ExecuteScalar();

        while (true)
        {
            if (emailExist != email)
            {
                break;
            }
            Console.WriteLine("That email exists already! Enter a new one.");
            Console.WriteLine("----------------------------------------------");
            email = Console.ReadLine();
            Console.WriteLine("----------------------------");
        }


        Console.WriteLine("Are you an Employee [E] or a Manager [M]? Press [E] for Employee or [M] for Manager.");
        Console.WriteLine("-----------------------------------------------------------------------------------");
        string? userType = Console.ReadLine();
        Console.WriteLine("----------------------------");


        if (userType == "E" || userType == "e")
        {
            Console.WriteLine($"Your registration is complete,{firstName}! Welcome to the team!");
            Console.WriteLine("----------------------------------------------------------------");

        }
        else if (userType == "M" || userType == "m")
        {

            Console.WriteLine($"Your registration is complete, {firstName}! Welcome to the team!");
            Console.WriteLine("-----------------------------------------------------------------");

        }

        //Saves all the new user info to the DB
        string insertUser = "Insert into Users (firstName, lastName, userName, userPin, email, userType) values ('" + firstName + "','" + lastName + "','" + userGuess + "','" + userPin + "','" + email + "','" + userType + "')";
        SqlCommand addUser = new SqlCommand(insertUser, connection);
        //addUser.Parameters.AddWithValue("userName", @userN);
        addUser.ExecuteNonQuery();
        connection.Close();
        login.login();
    }

}