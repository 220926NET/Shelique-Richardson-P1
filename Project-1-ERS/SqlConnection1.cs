using Microsoft.Data.SqlClient;

public class SqlConnection1{

    private const string connString = $"Server=tcp:revexample.database.windows.net,1433;Initial Catalog=RevatureEx;Persist Security Info=False;User ID=FlashCard;Password={theKey.password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public SqlConnection connectString(){
        
        return new SqlConnection(connString);
    }


}