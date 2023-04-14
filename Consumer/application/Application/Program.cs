// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Demo.Consumer.Client.Api;
using Demo.Consumer.Client.Client;
using Demo.Consumer.Client.Model;

Configuration config = new Configuration();
config.BasePath = "http://localhost:8080/api";
// Configure HTTP basic authorization: httpBasic
// config.Username = "YOUR_USERNAME";
// config.Password = "YOUR_PASSWORD";

var apiInstance = new PersonApi(config);


try
{
    PrintPersons(apiInstance.GetPersons());

    var personId = Guid.NewGuid();

    Debug.WriteLine("Creating person with id " + personId);
    apiInstance.UpdatePerson(personId, new Person(new PersonName("first", "last"), Person.GenderEnum.M));

    PrintPersons(apiInstance.GetPersons());

    Debug.WriteLine("Removing person with id " + personId);
    apiInstance.DeletePerson(personId);

    PrintPersons(apiInstance.GetPersons());
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PersonApi.DeletePerson: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}


void PrintPersons(IReadOnlyCollection<Person> persons)
{
    Debug.WriteLine("Persons: " + persons.Count);
    Debug.Indent();
    foreach (var person in persons)
    {
        Debug.WriteLine(person.ToString());
    }

    Debug.Unindent();
}