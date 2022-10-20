using Microsoft.Data.SqlClient;

public class userLogin
{
    start app = new start();
    DBaccess db = new DBaccess();

    public void login()
    {
        Console.WriteLine("~Login~");
        Console.WriteLine("~~~~~~~~");
        Console.WriteLine("Enter your username");
        Console.WriteLine("----------------------------------------------");

        try
        {
            db.DBlogin();

        }
        catch
        {
            //errorMessage();
        }

        app.App();
    }

}