using System;
namespace ConsoleApp1;
public struct Person
{
    public string FirstName;
    public string LastName;

    private string email;
    private string password;

    public string Email
    {
        get { return email; }
        set
        {
            if (!string.IsNullOrEmpty(value) && value.Contains("@"))
                email = value;
        }
    }

    internal string Password
    {
        get { return password; }
        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 6)
                password = value;
        }
    }
}

public class ClientsCounter
{
    private static int Clients = 0;
    protected string ClientsData = "Regular";

    public ClientsCounter()
    {
        Clients++;
    }

    public static int GetUserCount()
    {
        return Clients;
    }

    public void DisplayInfo(Person p)
    {
        Console.WriteLine($"Fullname: {p.FirstName} {p.LastName}, Email: {p.Email}");
    }

    internal void ShowClientsData()
    {
        Console.WriteLine($"Client Type: {ClientsData}");
    }
}

class ClientsData : ClientsCounter
{
    public ClientsData()
    {
        ClientsData = "New"; 
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person p1 = new Person
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john@doe.com"
        };

        ClientsCounter client1 = new ClientsCounter();
        client1.DisplayInfo(p1);
        client1.ShowClientsData();

        ClientsData vip = new ClientsData();
        vip.ShowClientsData();

        Console.WriteLine($"Total Users: {ClientsCounter.GetUserCount()}");
    }
}