using Microsoft.Data.SqlClient;

public class register
{

    public static string? userGuess;
    public static string? email;
    public static string? firstName;
    public static string? userPin;
    public static string? lastName;
    public static string? userType;



    public void registration()
    {
        DBaccess db = new DBaccess();

        start st = new start();
        userLogin login = new userLogin();

        Console.WriteLine("~Register~");
        Console.WriteLine("~~~~~~~~~~~");
        Console.WriteLine("Please enter your first name.");
        Console.WriteLine("----------------------------------------------");
        firstName = Console.ReadLine();
        Console.WriteLine("----------------------------");
        Console.WriteLine("Please enter your last name");
        Console.WriteLine("----------------------------------------------");
        lastName = Console.ReadLine();
        Console.WriteLine("-----------------------------");

        Console.WriteLine("Please create a username.");
        Console.WriteLine("----------------------------------------------");
        userGuess = Console.ReadLine();
        Console.WriteLine("----------------------------");

        //Checking whether the entered userName already exists in DB
        db.checkUserName();

        Console.WriteLine("Please create a 6 digit pin to login");
        Console.WriteLine("----------------------------------------------");
        userPin = Console.ReadLine();
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
        email = Console.ReadLine();
        Console.WriteLine("----------------------------");

        //Checks if email already exists in DB
        db.checkEmail();

        Console.WriteLine("Are you an Employee [E] or a Manager [M]? Press [E] for Employee or [M] for Manager.");
        Console.WriteLine("-----------------------------------------------------------------------------------");
        userType = Console.ReadLine();
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
        db.addUser();
        login.login();
    }

}