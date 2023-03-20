using FluentAssertions;
using Newtonsoft.Json;
using StudentAccount.Dal;
using System.Net;
using System.Text;

namespace StudentAccount.IntegrationTests.Student;

public class PostStudentTests : BaseTest
{
    private readonly HttpClient _httpClient;
    public PostStudentTests()
    {
        _httpClient = InitTestServer().GetClient();
    }

    [Fact]
    public async Task PostAsync_IfNoExceptionOccurred_SavesNewEntityInDb()
    {
        // Arrange
        var inputModel = new Orchestrators.Student.Contract.CreateStudent
        {
            FirstName = "SomeFirstName",
            LastName = "SomeLastName"
        };

        // Act
        var message = new HttpRequestMessage(
            HttpMethod.Post,
            $"api/v1/students")
        {
            Content = new StringContent(JsonConvert.SerializeObject(inputModel), Encoding.UTF8, "application/json")
        };
        var result = await _httpClient.SendAsync(message);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        result.Content.Should().NotBeNull();
        var responseModel = JsonConvert.DeserializeObject<Model.Student.Student>(await result.Content.ReadAsStringAsync());
        responseModel.Should().NotBeNull();
        var savedEntity = AppDbContext.Students
            .FirstOrDefault(s =>
                s.FirstName == inputModel.FirstName
                && s.LastName == inputModel.LastName
                && s.Id == responseModel.Id);
        savedEntity.Should().NotBeNull();
    }

}