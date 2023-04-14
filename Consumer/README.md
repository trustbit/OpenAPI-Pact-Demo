# Creating the consumer

1. Use the generator to create the stubs
   Using the <https://openapi-generator.tech/docs/generators/csharp-netcore/> 

    ```
    docker run --rm \
    -v ${PWD}/../:/local openapitools/openapi-generator-cli generate \
    -i /local/InterfaceDescription/openapi_bundled.yaml \
    -g csharp-netcore \
    --additional-properties=library=httpclient,packageName=Demo.Consumer.Client,packageTitle="Demo Consumer Client",targetFramework="netstandard2.1" \
    -o /local/Consumer/out/
    ```

2. Copy the generated stubs into `application` and change directory
3. start & build the application via `./build.sh`
4. Launch project via `dotnet run --project src/Demo.Provider.Service/Demo.Provider.Service.csproj --launch-profile OpenAPI`
5. Implement API endpoints at `src/Demo.Provider.Service/Controllers/PersonApi.cs` with the help of the In-Memory-Database