using Microsoft.Data.SqlClient;


public class DBaccess{
    SqlConnection connection = new SqlConnection1().connectString();
            register regis = new register();

    public void DBapp(){
        connection.Open();
        SqlCommand isManager = new SqlCommand("select userName from Users where userType = 'M' and userName = '" + start.userN + "'", connection);
        string M = (string)isManager.ExecuteScalar();

        //checks if the user logged in is a manager or regular employee
        Manager manage = new Manager();
        if (M == start.userN)
        {
            connection.Close();
            //start page for managers
            manage.managerApp();
        }
        else
        {
            //start page for regular employees
            Tickets submit = new Tickets();
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("========================================================");
            Console.WriteLine("[1]Submit an expense reimbursement ticket?");
            Console.WriteLine("[2]Review your previous expense reimbursement tickets?");
            Console.WriteLine("[0]Logout");
            Console.WriteLine("========================================================");
            int userInput = int.Parse(Console.ReadLine());
            Console.WriteLine("----------------------------------------------");

            if (userInput == 1)
            {
                connection.Close();
                submit.submitTicket();
            }
            else if (userInput == 2)
            {
                connection.Close();
                submit.previousTickets();
            }
            else if (userInput == 0)
            {
                Console.WriteLine("==========================");
                Console.WriteLine("See you later! GoodBye!");
                Console.WriteLine("==========================");
                Environment.Exit(0);
            }
        }
    }

    public void DBlogin(){
            start app = new start();

        checkUser();

            void checkUser()
            {

                connection.Open();
                start.userN = Console.ReadLine();
                Console.WriteLine("--------------------------------");

                account user1 = new account();
                //Checks if username exists in DB
                SqlCommand checkUserName = new SqlCommand("select count(*) from Users where userName = '" + start.userN + "'", connection);
                //checkUserName.Parameters.AddWithValue("userName", @userN);
                int userExist = (int)checkUserName.ExecuteScalar();
                if (userExist > 0)
                {       //if it exists, user can go on to enter password
                    Console.WriteLine("Enter your 6 digit pin");
                    Console.WriteLine("----------------------------------------------");
                    int pin = int.Parse(Console.ReadLine());
                    Console.WriteLine("----------------------------------------------");

                    //checks if pin matches with the username in the DB
                    SqlCommand checkPin = new SqlCommand("select count(*) from Users where userName = '" + start.userN + "' and userPin = '" + pin + "'", connection);
                    //checkPin.Parameters.AddWithValue("userPin", @pin);
                    int pinExist = (int)checkPin.ExecuteScalar();

                    if (pinExist > 0)
                    {       //if it does, user goes on to the app
                    
                        Console.WriteLine("~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("Login successful!");
                        Console.WriteLine("~~~~~~~~~~~~~~~~~");
                        connection.Close();
                        app.App();
                    }
                    else
                    {   //message just to tell the user the username or pin is incorrect
                        errorMessage();
                    }
                }
                else
                {
                    errorMessage();
                }
            }
    }
    public void errorMessage()
    {      userLogin login = new userLogin();

        Console.WriteLine("I don't know what's happening!");
        Console.WriteLine("This username/pin doesn't exists! [1]Login/[2]Signup");
        int select = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("----------------------------------------------");

        if (select == 1)
        {
            connection.Close();
            login.login();
        }
        else
        {
            connection.Close();
            regis.registration();
        }
    }



    public void checkUserName(){
                connection.Open();

        SqlCommand checkUserName = new SqlCommand("select userName from Users where userName = '" + register.userGuess + "'", connection);
        //checkUserName.Parameters.AddWithValue("userName", @userN);
        string userExist = (string)checkUserName.ExecuteScalar();

        while (true)
        {
            if (userExist != register.userGuess)
            {
                break;
            }
            Console.WriteLine("That username exists already! Enter a new one.");
            Console.WriteLine("----------------------------------------------");
            register.userGuess = Console.ReadLine();
            Console.WriteLine("----------------------------");
        }
    }

    public  void checkEmail(){
         SqlCommand checkEmail = new SqlCommand("select email from Users where email = '" + register.email + "'", connection);
        //checkUserName.Parameters.AddWithValue("userName", @userN);
        string emailExist = (string)checkEmail.ExecuteScalar();

        while (true)
        {
            if (emailExist != register.email)
            {
                break;
            }
            Console.WriteLine("That email exists already! Enter a new one.");
            Console.WriteLine("----------------------------------------------");
            register.email = Console.ReadLine();
            Console.WriteLine("----------------------------");
        }
    }

     public void addUser(){
            string insertUser = "Insert into Users (firstName, lastName, userName, userPin, email, userType) values ('" + register.firstName + "','" + register.lastName + "','" + register.userGuess + "','" + register.userPin + "','" + register.email + "','" + register.userType + "')";


         SqlCommand addUser = new SqlCommand(insertUser, connection);
        //addUser.Parameters.AddWithValue("userName", @userN);
        addUser.ExecuteNonQuery();
        connection.Close();
    }


}