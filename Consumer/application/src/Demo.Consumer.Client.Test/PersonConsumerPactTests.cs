using System;
using System.Collections.Generic;
using Demo.Consumer.Client.Api;
using Demo.Consumer.Client.Model;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using Xunit;

namespace Demo.Consumer.Client.Test
{
    public class PersonConsumerPactTests : IClassFixture<ConsumerPactClassFixture>
    {
        private readonly IMockProviderService _mockProviderService;
        private readonly string _mockProviderServiceBaseUri;
        private readonly PersonApi _apiInstance;

        public PersonConsumerPactTests(ConsumerPactClassFixture fixture)
        {
            _mockProviderService = fixture.MockProviderService;
            _mockProviderService
                .ClearInteractions(); //NOTE: Clears any previously registered interactions before the test is run
            _mockProviderServiceBaseUri = fixture.MockProviderServiceBaseUri;

            _apiInstance = new PersonApi(_mockProviderServiceBaseUri);
        }

        [Fact]
        public void WithNoData_GettingAllPersons_ReturnsEmptyList()
        {
            // Arrange
            _mockProviderService.Given("There is no data")
                .UponReceiving("A valid GET request for all persons")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "/api/person"
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = Array.Empty<object>()
                });

            // Act
            var result = _apiInstance.GetPersons();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void WithNoData_UpdatingPerson_ReturnsCreatedWithLink()
        {
            // Arrange
            _mockProviderService.Given("There is no data")
                .UponReceiving("A valid PATCH request for a new person")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Patch,
                    Path = "/api/person/dbe553a1-c2b4-4759-a95b-735a656033c8",
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json" }
                    },
                    Body = new
                    {
                        name = new { surname = "first", lastname = "last" },
                        gender = "m",
                    }
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 201,
                    Headers = new Dictionary<string, object>
                    {
                        { "Location", "~/api/person/dbe553a1-c2b4-4759-a95b-735a656033c8" },
                        { "Content-Type", "application/json; charset=utf-8" }
                    }
                });

            // Act
            var identifier = new Guid("dbe553a1-c2b4-4759-a95b-735a656033c8");
            _apiInstance.UpdatePerson(identifier,new Person(new PersonName("first", "last"), Person.GenderEnum.M));
        }

        [Fact]
        public void WithSinglePerson_GettingAllPersons_ReturnsEntry()
        {
            // Arrange
            _mockProviderService.Given("There is a single person with id dbe553a1-c2b4-4759-a95b-735a656033c8")
                .UponReceiving("A valid GET request for all persons with existing data")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "/api/person"
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = new object[]
                    {
                        new
                        {
                            Name = new { Surname = "first", Lastname = "last" },
                            Gender = "M",
                            PersonId = "dbe553a1-c2b4-4759-a95b-735a656033c8"
                        }
                    }
                });

            // Act
            var result = _apiInstance.GetPersons();

            // Assert
            Assert.NotEmpty(result);
            var item = Assert.Single(result);
            Assert.Equal(new Guid("dbe553a1-c2b4-4759-a95b-735a656033c8"), item.PersonId);
        }


        [Fact]
        public void WithSinglePerson_GettingPerson_ReturnsEntry()
        {
            // Arrange
            _mockProviderService.Given("There is a single person with id dbe553a1-c2b4-4759-a95b-735a656033c8")
                .UponReceiving("A valid GET request for a specific person")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "/api/person/dbe553a1-c2b4-4759-a95b-735a656033c8"
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body =
                        new
                        {
                            Name = new { Surname = "first", Lastname = "last" },
                            Gender = "M",
                            PersonId = "dbe553a1-c2b4-4759-a95b-735a656033c8"
                        }
                });

            var identifier = new Guid("dbe553a1-c2b4-4759-a95b-735a656033c8");
            // Act
            var result = _apiInstance.GetPerson(identifier);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(identifier, result.PersonId);
        }

        [Fact]
        public void WithSinglePerson_RemovingPerson_Returns204()
        {
            // Arrange
            _mockProviderService.Given("There is a single person with id dbe553a1-c2b4-4759-a95b-735a656033c8")
                .UponReceiving("A valid DELETE request for removing an existing person")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Delete,
                    Path = "/api/person/dbe553a1-c2b4-4759-a95b-735a656033c8"
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 204,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                });

            var identifier = new Guid("dbe553a1-c2b4-4759-a95b-735a656033c8");

            // Act
            _apiInstance.DeletePerson(identifier);
        }
    }
}