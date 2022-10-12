public class account
{
    List<account> employees = new List<account>();
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string userName { get; set; }
    public int userPin { get; set; }
    public string email { get; set; }
    public string userType { get; set; } //just employee or manager



    public List<account> addEmployee()
    {
        //employees.Add(new account(firstName, lastName, userName, userPin, email, userType));

        //to check if exists
        // foreach (account member in employees)
        // {
        //     Console.WriteLine(member.firstName, member.email);
        // }
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

    public account()
    {
        employees.Add(new account(firstName = "Sheli", lastName = "Richards", userName = "sheli27", 
        userPin = 123456, email = "shelique519@revature.net", userType = "M"));

        employees.Add(new account(firstName, lastName, userName, userPin, email, userType));

    }
}
