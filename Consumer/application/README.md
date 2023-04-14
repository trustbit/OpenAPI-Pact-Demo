# Demo.Consumer.Client - the C# library for the API for Demo

# Goal
This API Description is used as the basis to show code generating use-cases.


<SecurityDefinitions />

This C# SDK is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project:

- API version: 1.0.0
- SDK version: 1.0.0
- Build package: org.openapitools.codegen.languages.CSharpNetCoreClientCodegen

<a name="frameworks-supported"></a>
## Frameworks supported
- .NET Core >=1.0
- .NET Framework >=4.6
- Mono/Xamarin >=vNext

<a name="dependencies"></a>
## Dependencies

- [RestSharp](https://www.nuget.org/packages/RestSharp) - 106.13.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 13.0.2 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.8.0 or later
- [System.ComponentModel.Annotations](https://www.nuget.org/packages/System.ComponentModel.Annotations) - 5.0.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
Install-Package System.ComponentModel.Annotations
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742).
NOTE: RestSharp for .Net Core creates a new socket for each api call, which can lead to a socket exhaustion problem. See [RestSharp#1406](https://github.com/restsharp/RestSharp/issues/1406).

<a name="installation"></a>
## Installation
Generate the DLL using your preferred tool (e.g. `dotnet build`)

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using Demo.Consumer.Client.Api;
using Demo.Consumer.Client.Client;
using Demo.Consumer.Client.Model;
```
<a name="usage"></a>
## Usage

To use the API client with a HTTP proxy, setup a `System.Net.WebProxy`
```csharp
Configuration c = new Configuration();
System.Net.WebProxy webProxy = new System.Net.WebProxy("http://myProxyUrl:80/");
webProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
c.Proxy = webProxy;
```

<a name="getting-started"></a>
## Getting Started

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Demo.Consumer.Client.Api;
using Demo.Consumer.Client.Client;
using Demo.Consumer.Client.Model;

namespace Example
{
    public class Example
    {
        public static void Main()
        {

            Configuration config = new Configuration();
            config.BasePath = "https://www.apidemoserver.com/api";
            // Configure HTTP basic authorization: httpBasic
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";

            var apiInstance = new PersonApi(config);
            var personId = "personId_example";  // Guid | Eindeutige ID für die Personenstammdaten als UUID

            try
            {
                // Delete Person
                apiInstance.DeletePerson(personId);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling PersonApi.DeletePerson: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }

        }
    }
}
```

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *https://www.apidemoserver.com/api*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*PersonApi* | [**DeletePerson**](docs/PersonApi.md#deleteperson) | **DELETE** /person/{person-id} | Delete Person
*PersonApi* | [**GetPerson**](docs/PersonApi.md#getperson) | **GET** /person/{person-id} | Query Person
*PersonApi* | [**GetPersons**](docs/PersonApi.md#getpersons) | **GET** /person | Query Persons
*PersonApi* | [**UpdatePerson**](docs/PersonApi.md#updateperson) | **PATCH** /person/{person-id} | Update Person


<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.Person](docs/Person.md)
 - [Model.PersonAddress](docs/PersonAddress.md)
 - [Model.PersonName](docs/PersonName.md)
 - [Model.Problem](docs/Problem.md)


<a name="documentation-for-authorization"></a>
## Documentation for Authorization

<a name="httpBasic"></a>
### httpBasic

- **Type**: HTTP basic authentication
