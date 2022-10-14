// See https://aka.ms/new-console-template for more information
//using users;
//using ReimbursementTickets;
using Microsoft.Data.SqlClient;

/*
Expense Reimbursement System~
MVPs:
-Users should be able to login/register[X]
-Users should have either Employee or Manager role[X]
-Users should be able to submit expense reimbrsement ticket[X]
-Managers should be able to process tickets[]
-Employees should be able to vew all prior ticket submissions[X]
--Database connection-SQL[X]

Ideas~
--Employees class with Manager class embedded with additional features (Inheritance)

*/

/*
-login method
-register method
-ticket class
-submit expense reimbursement ticket method
-process ticket method

*/

public class start
{

    public static string? userN;
    public static void Main(string[] args)
    {

        SqlConnection connection = new SqlConnection("Server=tcp:revexample.database.windows.net,1433;Initial Catalog=RevatureEx;Persist Security Info=False;User ID=FlashCard;Password=flashProject01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        // connection.Open();
         //SqlCommand command = new SqlCommand("SELECT * FROM Users", connection);
         //SqlDataReader reader = command.ExecuteReader();
        // List<account> people = new List<account>();
        // while (reader.Read())
        // {
        //     string name = (string)reader["firstName"];
        //     string last = (string)reader["lastName"];
        //     string user = (string)reader["userName"];
        //     string emails = (string)reader["email"];
        //     string type = (string)reader["userType"];
        //     int pins = (int)reader["userPin"];
        //     Console.WriteLine($"{name} {last} {user} {emails} {type} {pins}");

        //     account users = new account(name, last, user, pins, emails, type);

        //     people.Add(users);
        // }
        // reader.Close();
        // connection.Close();



        void printOptions()
        {
            Console.WriteLine("Welcome! Press [L] to login or [R] to register");
            Console.WriteLine("----------------------------------------------");
            string? userInput = Console.ReadLine();
            if (userInput == "L" || userInput == "l")
            {
                Console.WriteLine("Welcome back!");
                login();
            }
            else if (userInput == "R" || userInput == "r")
            {
                Console.WriteLine("Fill out the registration page to join!");
                Console.WriteLine("----------------------------------------------");
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

            Console.WriteLine("Register");
            Console.WriteLine("~~~~~~~~~~~");
            Console.WriteLine("Please enter your first name.");
            Console.WriteLine("----------------------------------------------");
            string? firstName = Console.ReadLine();
            Console.WriteLine("Please enter your last name");
            Console.WriteLine("----------------------------------------------");
            string? lastName = Console.ReadLine();

            Console.WriteLine("Please create a username.");
            Console.WriteLine("----------------------------------------------");
            string? userGuess = Console.ReadLine();

            //account user1 = new account();
            //List<account> currentEmployee = user1.addEmployee();

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
            }

            Console.WriteLine("Please create a 6 digit pin to login");
            Console.WriteLine("----------------------------------------------");
            var userPin = Console.ReadLine();

            //Trying to limit 6 digit pin

            while (userPin.Length > 6 || userPin.Length < 6)
            {
                Console.WriteLine("Please enter a pin that is ONLY 6 digits long");
                Console.WriteLine("----------------------------------------------");
                userPin = Console.ReadLine();
            }

            Console.WriteLine("Next enter your email address.");
            Console.WriteLine("----------------------------------------------");
            string? email = Console.ReadLine();
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
            }



            Console.WriteLine("Are you an Employee [E] or a Manager [M]? Press [E] for Employee or [M] for Manager.");
            Console.WriteLine("----------------------------------------------");
            string? userType = Console.ReadLine();

            //account account1 = new account(firstName, lastName, userName, userPin, email, userType);

            if (userType == "E" || userType == "e")
            {
                Console.WriteLine($"Your registration is complete,{firstName}! Welcome to the team!");
                Console.WriteLine("----------------------------------------------");
                //logic to save info to direct them to a certain start page


                //account1.addEmployee();

            }
            else if (userType == "M" || userType == "m")
            {
                //logic to save info to direct them to a certain start page

                //account account1 = new account(firstName, lastName, userName, userPin, email, userType);

                //Put this list into a class/method aalone so that the login feature can access it as well

                Console.WriteLine($"Your registration is complete, {firstName}! Welcome to the team!");
                Console.WriteLine("----------------------------------------------");



                //     account1.addEmployee();
                // }
            }
             string insertUser = "Insert into Users (firstName, lastName, userName, userPin, email, userType) values ('"+ firstName + "','" + lastName + "','" + userGuess + "','"+ userPin + "','" + email + "','" + userType + "')";
            SqlCommand addUser = new SqlCommand( insertUser, connection);
            //addUser.Parameters.AddWithValue("userName", @userN);
            addUser.ExecuteNonQuery();
            connection.Close();
            login();

        }

        void login()
        {
            Console.WriteLine("Login");
            Console.WriteLine("~~~~~~~~~~~");
            Console.WriteLine("Enter your username");
            Console.WriteLine("----------------------------------------------");

            try
            {
                checkUser();

                void checkUser()
                {
                    
                    connection.Open();
                    userN = Console.ReadLine();
                    account user1 = new account();
                    // List<account> currentEmployee = user1.addEmployee();

                    SqlCommand checkUserName = new SqlCommand("select count(*) from Users where userName = '" + userN + "'", connection);
                    //checkUserName.Parameters.AddWithValue("userName", @userN);
                    int userExist = (int)checkUserName.ExecuteScalar();
                    if (userExist > 0)
                    {
                        Console.WriteLine("Enter your 6 digit pin");
                        Console.WriteLine("----------------------------------------------");
                        int pin = int.Parse(Console.ReadLine());

                        SqlCommand checkPin = new SqlCommand("select count(*) from Users where userName = '" + userN + "' and userPin = '" + pin + "'", connection);
                        //checkPin.Parameters.AddWithValue("userPin", @pin);
                        int pinExist = (int)checkPin.ExecuteScalar();

                        if (pinExist > 0)
                        {
                            Console.WriteLine("Login successful!");
                            App();
                        }
                        else
                        {
                            errorMessage();
                        }
                        //reader.Close();
                        connection.Close();
                    }
                    else
                    {
                        errorMessage();
                    }

                }
            }
            catch
            {
                errorMessage();

            }

            App();

        }
        void errorMessage()
        {
            Console.WriteLine("I don't know what's happening!");
            Console.WriteLine("This username/pin doesn't exists! [1]Login/[2]Signup");
            int select = Convert.ToInt32(Console.ReadLine());
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
            Tickets submit = new Tickets();
            Console.WriteLine("[1]Would you like to submit an expense reimbursement ticket?");
            Console.WriteLine("[2]Would you like to review your previous expense reimbursement tickets?");
            Console.WriteLine("----------------------------------------------");
            int userInput = int.Parse(Console.ReadLine());


            if (userInput == 1)
            {
                submit.submitTicket();
                }else if (userInput==2){
                submit.previousTickets();
            }
        }



    }


}
