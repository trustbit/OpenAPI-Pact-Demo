# Creating the provider

1. Use the generator to create the stubs
   Using the <https://openapi-generator.tech/docs/generators/aspnetcore> 

    ```
    docker run --rm \
    -v ${PWD}/../:/local openapitools/openapi-generator-cli generate \
    -i /local/InterfaceDescription/openapi_bundled.yaml \
    -g aspnetcore  \
    --additional-properties=aspnetCoreVersion=6.0,packageName=Demo.Provider.Service,packageTitle="Demo Provider Services", \
    -o /local/Provider/out/aspnetcore
    ```

2. Copy the generated stubs into `application` and change directory
3. start & build the application via `./build.sh`
4. Launch project via `dotnet run --project src/Demo.Provider.Service/Demo.Provider.Service.csproj --launch-profile OpenAPI`
5. Implement API endpoints at `src/Demo.Provider.Service/Controllers/PersonApi.cs` with the help of the In-Memory-Database

# Verifing with Pact Broker

- add verification tests
- configure to connect them with the broker on `PACT_BROKER_BASE_URL` and `PACT_BROKER_TOKEN`
- check if deployment is possible via
```bash
docker run \
    -v $(pwd)/Consumer/pacts:/pacts \
    pactfoundation/pact-cli:latest -- \
    pact-broker can-i-deploy \
        --pacticipant Demo.Provider \
        --latest \
        --broker-base-url $PACT_BROKER_BASE_URL \
        --broker-token $PACT_BROKER_TOKEN
```