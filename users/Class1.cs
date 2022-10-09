namespace users;

public class account
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string userName { get; set; }
    public int userPin { get; set; }
    public string email { get; set; }
    public string userType { get; set; } //just employee or manager
    public List<account> addEmployee()
    {
        List<account> employees = new List<account>();

        employees.Add(new account(firstName, lastName, userName, userPin, email, userType));
        foreach (account member in employees)
        {
            Console.WriteLine(member.firstName);
        }
        return employees;
    }
    public account(string firstName, string lastName, string userName, int userPin, string email, string userType)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.userName = userName;
        this.userPin = userPin;
        this.email = email;
        this.userType = userType;
    }



}




