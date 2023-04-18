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
3. Implement Pact tests

# Pushing Data to Pact Broker

1. Obtain Token + Host configuration (from <https://trustbit.pactflow.io/settings/api-tokens>)
```bash
PACT_BROKER_BASE_URL="https://trustbit.pactflow.io"
PACT_BROKER_TOKEN="xKT2uJxqKIP6RoqXzcgo4A"
```

2. Publish Pacts from `Consumer/pacts/demo.consumer-demo.provider.json` to broker
```bash
docker run \
    -v $(pwd)/Consumer/pacts:/pacts \
    pactfoundation/pact-cli:latest -- \
    pact-broker publish \
        --consumer-app-version 1.0.0 \
        --broker-base-url $PACT_BROKER_BASE_URL \
        --broker-token $PACT_BROKER_TOKEN \
        /pacts/demo.consumer-demo.provider.json \
        --tag master
```

3. Run the [can-i-deploy](https://docs.pact.io/pact_broker/can_i_deploy) check for the consumer
```bash
docker run \
    -v $(pwd)/pacts:/pacts \
    pactfoundation/pact-cli:latest -- \
    pact-broker can-i-deploy \
        --pacticipant Demo.Consumer \
        --latest \
        --broker-base-url $PACT_BROKER_BASE_URL \
        --broker-token $PACT_BROKER_TOKEN
```