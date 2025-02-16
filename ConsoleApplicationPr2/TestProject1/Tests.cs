using System;
using NUnit.Framework;
using ConsoleApp1;



[TestFixture]
public class ClientsCounterTests
{
    [Test]
    public void Person_Email_ShouldBeValid()
    {
        Person p = new Person();
        p.Email = "test@mail.com";
        Assert.AreEqual("test@mail.com", p.Email);
    }

    [Test]
    public void Person_Email_ShouldNotSetInvalidValue()
    {
        Person p = new Person();
        p.Email = "invalid-email";
        Assert.AreNotEqual("invalid-email", p.Email);
    }
    
    public void ClientsCounter_ShouldIncreaseCount()
    {
        int before = ClientsCounter.GetUserCount();
        ClientsCounter client = new ClientsCounter();
        Assert.AreEqual(before + 1, ClientsCounter.GetUserCount());
    }

    [Test]
    public void DisplayInfo_ShouldPrintCorrectData()
    {
        Person p = new Person { FirstName = "John", LastName = "Doe", Email = "john@doe.com" };
        ClientsCounter client = new ClientsCounter();

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            client.DisplayInfo(p);
            string result = sw.ToString().Trim();
            Assert.AreEqual("Fullname: John Doe, Email: john@doe.com", result);
        }
    }
}