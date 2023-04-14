# Demo.Consumer.Client.Api.PersonApi

All URIs are relative to *https://www.apidemoserver.com/api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeletePerson**](PersonApi.md#deleteperson) | **DELETE** /person/{person-id} | Delete Person |
| [**GetPerson**](PersonApi.md#getperson) | **GET** /person/{person-id} | Query Person |
| [**GetPersons**](PersonApi.md#getpersons) | **GET** /person | Query Persons |
| [**UpdatePerson**](PersonApi.md#updateperson) | **PATCH** /person/{person-id} | Update Person |

<a name="deleteperson"></a>
# **DeletePerson**
> void DeletePerson (Guid personId)

Delete Person

Deletes a Person identified by its person-id

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Demo.Consumer.Client.Api;
using Demo.Consumer.Client.Client;
using Demo.Consumer.Client.Model;

namespace Example
{
    public class DeletePersonExample
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
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PersonApi.DeletePerson: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeletePersonWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete Person
    apiInstance.DeletePersonWithHttpInfo(personId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PersonApi.DeletePersonWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **personId** | **Guid** | Eindeutige ID für die Personenstammdaten als UUID |  |

### Return type

void (empty response body)

### Authorization

[httpBasic](../README.md#httpBasic)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/problem+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | NO CONTENT: Delete was successfully performed. |  -  |
| **400** | BAD REQUEST: The Request is not valid. |  -  |
| **401** | UNAUTHORIZED: The User is not authorized to call the endpoint |  -  |
| **500** | INTERNAL SERVER ERROR: Other Errors on Server. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getperson"></a>
# **GetPerson**
> Person GetPerson (Guid personId)

Query Person

This Endpoint will be used to get the person information for a specific Person identified by the person-id.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Demo.Consumer.Client.Api;
using Demo.Consumer.Client.Client;
using Demo.Consumer.Client.Model;

namespace Example
{
    public class GetPersonExample
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
                // Query Person
                Person result = apiInstance.GetPerson(personId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PersonApi.GetPerson: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetPersonWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Query Person
    ApiResponse<Person> response = apiInstance.GetPersonWithHttpInfo(personId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PersonApi.GetPersonWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **personId** | **Guid** | Eindeutige ID für die Personenstammdaten als UUID |  |

### Return type

[**Person**](Person.md)

### Authorization

[httpBasic](../README.md#httpBasic)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The JSON Object for the corresponding person. |  -  |
| **400** | BAD REQUEST: The Request is not valid. |  -  |
| **401** | UNAUTHORIZED: The User is not authorized to call the endpoint |  -  |
| **500** | INTERNAL SERVER ERROR: Other Errors on Server. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getpersons"></a>
# **GetPersons**
> List&lt;Person&gt; GetPersons ()

Query Persons

This Endpoint will be used to get a list of all persons.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Demo.Consumer.Client.Api;
using Demo.Consumer.Client.Client;
using Demo.Consumer.Client.Model;

namespace Example
{
    public class GetPersonsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://www.apidemoserver.com/api";
            // Configure HTTP basic authorization: httpBasic
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";

            var apiInstance = new PersonApi(config);

            try
            {
                // Query Persons
                List<Person> result = apiInstance.GetPersons();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PersonApi.GetPersons: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetPersonsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Query Persons
    ApiResponse<List<Person>> response = apiInstance.GetPersonsWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PersonApi.GetPersonsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;Person&gt;**](Person.md)

### Authorization

[httpBasic](../README.md#httpBasic)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Array of all persons. |  -  |
| **400** | BAD REQUEST: Die Anfrage ist nicht valide. |  -  |
| **401** | UNAUTHORIZED: Der Benutzer ist nicht berechtigt diesen Service aufzurufen |  -  |
| **500** | INTERNAL SERVER ERROR: Alle sonstigen Fehler |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateperson"></a>
# **UpdatePerson**
> void UpdatePerson (Guid personId, Person person = null)

Update Person

Updates a Person according to the given request object.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Demo.Consumer.Client.Api;
using Demo.Consumer.Client.Client;
using Demo.Consumer.Client.Model;

namespace Example
{
    public class UpdatePersonExample
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
            var person = new Person(); // Person |  (optional) 

            try
            {
                // Update Person
                apiInstance.UpdatePerson(personId, person);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PersonApi.UpdatePerson: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdatePersonWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update Person
    apiInstance.UpdatePersonWithHttpInfo(personId, person);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PersonApi.UpdatePersonWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **personId** | **Guid** | Eindeutige ID für die Personenstammdaten als UUID |  |
| **person** | [**Person**](Person.md) |  | [optional]  |

### Return type

void (empty response body)

### Authorization

[httpBasic](../README.md#httpBasic)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/problem+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | UPDATE: The ressource was successfully changed. |  * Location -  <br>  |
| **400** | BAD REQUEST: The Request is not valid. |  -  |
| **401** | UNAUTHORIZED: The User is not authorized to call the endpoint |  -  |
| **500** | INTERNAL SERVER ERROR: Other Errors on Server. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

