// See https://aka.ms/new-console-template for more information
//using users;
using ReimbursementTickets;

/*
Expense Reimbursement System~
MVPs:
-Users should be able to login/register
-Users should have either Employee or Manager role
-Users should be able to submit expense reimbrsement ticket
-Managers should be able to process tickets
-Employees should be able to vew all prior ticket submissions
--Database connection-SQL

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
    public static void Main(string[] args)
    {
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
            string? userName = Console.ReadLine();



            Console.WriteLine("Next enter your email address.");
            Console.WriteLine("----------------------------------------------");
            string? email = Console.ReadLine();

            Console.WriteLine("Please create a 6 digit pin to login");
            Console.WriteLine("----------------------------------------------");
            int userPin = int.Parse(Console.ReadLine());




            Console.WriteLine("Are you an Employee [E] or a Manager [M]? Press [E] for Employee or [M] for Manager.");
            Console.WriteLine("----------------------------------------------");
            string? userType = Console.ReadLine();

            account account1 = new account(firstName, lastName, userName, userPin, email, userType);

            if (userType == "E" || userType == "e")
            {
                Console.WriteLine($"Your registration is complete,{firstName}! Welcome to the team!");
                Console.WriteLine("----------------------------------------------");
                //logic to save info to direct them to a certain start page


                account1.addEmployee();

            }
            else if (userType == "M" || userType == "m")
            {


                //logic to save info to direct them to a certain start page

                //account account1 = new account(firstName, lastName, userName, userPin, email, userType);



                //Put this list into a class/method aalone so that the login feature can access it as well
                //add verification feature to check if user exists in accounts and if pin exists(for login feature)
                //bool userNameExists = 
                bool userExists = account1.addEmployee().Contains(account1);
                if (userExists == true)
                {
                    Console.WriteLine("This username already exists! [1]Login/[2]Signup");
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
                else
                {
                    Console.WriteLine($"Your registration is complete, {firstName}! Welcome to the team!");
                    Console.WriteLine("----------------------------------------------");

                    account1.addEmployee();
                }
            }
            login();

        }

        void login()
        {
            try
            {
                Console.WriteLine("Login");
                Console.WriteLine("~~~~~~~~~~~");
                Console.WriteLine("Enter your username");
                Console.WriteLine("----------------------------------------------");
                checkUser();

                void checkUser()
                {
                    string? user = Console.ReadLine();
                    account user1 = new account();
                    List<account> currentEmployee = user1.addEmployee();

                    if (user1.userName.Contains(user))
                    {
                        Console.WriteLine("Enter your 6 digit pin");
                        Console.WriteLine("----------------------------------------------");
                        int pin = int.Parse(Console.ReadLine());

                        if(user1.userPin==pin){
                             Console.WriteLine("Login successful!");
                             App();
                        }else{
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
                errorMessage();
            }

            App();

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
                //}else if (userInput==2){
                //submit.previousTickets();
            }
        }

        void errorMessage() {
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
    }


}
