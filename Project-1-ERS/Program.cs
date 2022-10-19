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
    SqlConnection connection = new SqlConnection1().connectString();
    //Connection to the DB

    public static void Main(string[] args)
    {
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
                userLogin login = new userLogin();
                login.login();
            }
            else if (userInput == "R" || userInput == "r")
            {
                Console.WriteLine("Fill out the registration page to join! One sec...");
                Console.WriteLine("------------------------------------------------------");
                register regis = new register();
                regis.registration();
            }
            else
            {
                printOptions();
            }
        }
        printOptions();
    }

    public void App()
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

}
