using Microsoft.Data.SqlClient;

public class userLogin
{
    SqlConnection connection = new SqlConnection1().connectString();

    start app = new start();
    register regis = new register();

    public void login()
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
        catch
        {
            //errorMessage();
        }

        app.App();

    }
    void errorMessage()
    {
        Console.WriteLine("I don't know what's happening!");
        Console.WriteLine("This username/pin doesn't exists! [1]Login/[2]Signup");
        int select = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("----------------------------------------------");

        if (select == 1)
        {
            connection.Close();
            login();
        }
        else
        {
            connection.Close();
            regis.registration();
        }
    }

}