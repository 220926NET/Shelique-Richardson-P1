// See https://aka.ms/new-console-template for more information

using Microsoft.Data.SqlClient;

/*
Expense Reimbursement System~
MVPs:
-Users should be able to login/register[X]
-Users should have either Employee or Manager role[X]
-Users should be able to submit expense reimbrsement ticket[X]
-Managers should be able to process tickets[X]
-Employees should be able to view all prior ticket submissions[X]
--Database connection-SQL[X]
*/


public class start
{

    public static string? userN;
    //To track user (by username) while using the app
    public static void Main(string[] args)
    {

        SqlConnection connection = new SqlConnection("Server=tcp:revexample.database.windows.net,1433;Initial Catalog=RevatureEx;Persist Security Info=False;User ID=FlashCard;Password=flashProject01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        void printOptions()
        {
            //App entry point
            Console.WriteLine("Welcome! Press [L] to login or [R] to register");
            Console.WriteLine("----------------------------------------------");
            string? userInput = Console.ReadLine();
            Console.WriteLine("----------------------------------------------");
            if (userInput == "L" || userInput == "l")
            {
                Console.WriteLine("Welcome back!");
                Console.WriteLine("----------------------------------------------");
                login();
            }
            else if (userInput == "R" || userInput == "r")
            {
                Console.WriteLine("Fill out the registration page to join! One sec...");
                Console.WriteLine("------------------------------------------------------");
                register();
            }
            else
            {
                printOptions();
            }
        }
        printOptions();


        void register()
        {
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
            login();
        }

        void login()
        {
            Console.WriteLine("~Login~");
            Console.WriteLine("~~~~~~~~");
            Console.WriteLine("Enter your username");
            Console.WriteLine("----------------------------------------------");

            try
            {
                checkUser();

                void checkUser()
                {

                    connection.Open();
                    userN = Console.ReadLine();
                    Console.WriteLine("--------------------------------");

                    account user1 = new account();
                    //Checks if username exists in DB
                    SqlCommand checkUserName = new SqlCommand("select count(*) from Users where userName = '" + userN + "'", connection);
                    //checkUserName.Parameters.AddWithValue("userName", @userN);
                    int userExist = (int)checkUserName.ExecuteScalar();
                    if (userExist > 0)
                    {       //if it exists, user can go on to enter password
                        Console.WriteLine("Enter your 6 digit pin");
                        Console.WriteLine("----------------------------------------------");
                        int pin = int.Parse(Console.ReadLine());
                        Console.WriteLine("----------------------------------------------");

                        //checks if pin matches with the username in the DB
                        SqlCommand checkPin = new SqlCommand("select count(*) from Users where userName = '" + userN + "' and userPin = '" + pin + "'", connection);
                        //checkPin.Parameters.AddWithValue("userPin", @pin);
                        int pinExist = (int)checkPin.ExecuteScalar();

                        if (pinExist > 0)
                        {       //if it does, user goes on to the app
                            Console.WriteLine("Login successful!");
                            connection.Close();
                            App();
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
            catch
            {
                //errorMessage();

            }

            App();

        }
        void errorMessage()
        {
            Console.WriteLine("I don't know what's happening!");
            Console.WriteLine("This username/pin doesn't exists! [1]Login/[2]Signup");
            int select = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("----------------------------------------------");
            
            if (select == 1)
            {
                login();
            }
            else
            {
                register();
            }
        }

        void App()
        {
            connection.Open();
            SqlCommand isManager = new SqlCommand("select userName from Users where userType = 'M' and userName = '" + userN + "'", connection);
            string M = (string)isManager.ExecuteScalar();
            
            //checks if the user logged in is a manager or regular employee
            Manager manage = new Manager();
            if (M == userN)
            {
                connection.Close();
                //start page for managers
                manage.managerApp();

            }
            else
            {
                //start page for regular employees
                Tickets submit = new Tickets();
                Console.WriteLine("[1]Would you like to submit an expense reimbursement ticket?");
                Console.WriteLine("[2]Would you like to review your previous expense reimbursement tickets?");
                Console.WriteLine("[0]Logout");
                Console.WriteLine("----------------------------------------------");
                int userInput = int.Parse(Console.ReadLine());
                Console.WriteLine("----------------------------------------------");

                if (userInput == 1)
                {   
                    connection.Close();
                    submit.submitTicket();
                }
                else if (userInput == 2)
                {   connection.Close();
                    submit.previousTickets();
                }
                else if (userInput == 0){
                    Console.WriteLine("See you later! GoodBye!");
                    Environment.Exit(0);
                }
            }

        }

    }


}
