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
        DBaccess app = new DBaccess();

        app.DBapp();

    }

}
