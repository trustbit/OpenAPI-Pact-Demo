using System.Net;
using System.Text;
using Demo.Provider.Service.Models;
using Newtonsoft.Json;

namespace Demo.Provider.Service.Tests.Middleware;

public class ProviderState
{
    public string Consumer { get; set; }
    public string State { get; set; }
}

public class ProviderStateMiddleware
{
    private const string ConsumerName = "Demo.Consumer";
    private readonly RequestDelegate _next;
    private readonly IDictionary<string, Action<Database>> _providerStates;

    public ProviderStateMiddleware(RequestDelegate next)
    {
        _next = next;
        _providerStates = new Dictionary<string, Action<Database>>
        {
            {
                "There is no data",
                RemoveAllData
            },
            {
                "There is a single person with id dbe553a1-c2b4-4759-a95b-735a656033c8",
                AddData
            }
        };
    }

    private void RemoveAllData(Database database)
    {
        database.RemoveAll();
    }

    private void AddData(Database database)
    {
        database.RemoveAll();
        var identifier = new Guid("dbe553a1-c2b4-4759-a95b-735a656033c8");
        database.Update(
            identifier,
            new Person
            {
                Name = new PersonName { Surname = "first", Lastname = "last" }, Gender = Person.GenderEnum.MEnum
            });
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path.Value == "/provider-states")
        {
            await this.HandleProviderStatesRequest(context);
            await context.Response.WriteAsync(String.Empty);
        }
        else
        {
            await this._next(context);
        }
    }

    private async Task HandleProviderStatesRequest(HttpContext context)
    {
        context.Response.StatusCode = (int)HttpStatusCode.OK;

        if (context.Request.Method.ToUpper() == HttpMethod.Post.ToString().ToUpper() &&
            context.Request.Body != null)
        {
            string jsonRequestBody = String.Empty;
            using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8))
            {
                jsonRequestBody = await reader.ReadToEndAsync();
            }

            var providerState = JsonConvert.DeserializeObject<ProviderState>(jsonRequestBody);

            //A null or empty provider state key must be handled
            if (providerState != null && !String.IsNullOrEmpty(providerState.State) &&
                providerState.Consumer == ConsumerName)
            {
                var database = context.RequestServices.GetRequiredService<Database>();
                _providerStates[providerState.State].Invoke(database);
            }
        }
    }
}