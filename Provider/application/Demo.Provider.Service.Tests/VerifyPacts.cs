using Microsoft.AspNetCore;
using PactNet;
using PactNet.Infrastructure.Outputters;
using Xunit.Abstractions;

namespace Demo.Provider.Service.Tests;

public class VerifyPacts : IClassFixture<ProviderApiFixture>
{
    private readonly ProviderApiFixture _fixture;
    private ITestOutputHelper _outputHelper { get; }

    public VerifyPacts(ITestOutputHelper output, ProviderApiFixture fixture)
    {
        _outputHelper = output;
        _fixture = fixture;
    }

    [Fact]
    public void EnsureProviderApiHonoursPactWithConsumer()
    {
        // Arrange
        var config = new PactVerifierConfig()
        {
            // NOTE: We default to using a ConsoleOutput,
            // however xUnit 2 does not capture the console output,
            // so a custom outputter is required.
            Outputters = new List<IOutput>
            {
                new XUnitOutput(_outputHelper)
            },

            // Output verbose verification logs to the test output
            Verbose = true,
            PublishVerificationResults = true,
            ProviderVersion = "2.4.1-f3842db9e603d7",
        };
        string pactPath = Path.Combine(
            "..",
            "..",
            "..",
            "..",
            "..",
            "..",
            "Consumer",
            "pacts",
            "demo.consumer-demo.provider.json");

        //Act / Assert
        IPactVerifier pactVerifier = new PactVerifier(config);
        pactVerifier.ProviderState($"{_fixture.ServerUri}provider-states")
            .ServiceProvider("Demo.Provider", _fixture.ServerUri.ToString().TrimEnd('/'))
            .PactUri(pactPath)

            // .PactBroker(System.Environment.GetEnvironmentVariable("PACT_BROKER_BASE_URL"),
            //     uriOptions: new PactUriOptions(System.Environment.GetEnvironmentVariable("PACT_BROKER_TOKEN")),
            //     consumerVersionTags: new List<string> { "master" })
            .Verify();
    }
}