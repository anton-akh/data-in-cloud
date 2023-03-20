using FluentAssertions;
using Moq;
using StudentAccount.Model.Student;
using StudentAccount.Orchestrators.Student;

namespace StudentAccount.Orchestrators.Tests.Student;

public class StudentOrchestratorTests
{
    [Fact]
    public async Task CreateAsync_IfNoException_StoresEntityAndReturnsResult()
    {
        // Arrange
        var inputModel = new Model.Student.Student
        {
            FirstName = "TestFirstName",
            LastName = "TestLastName"
        };
        var createdModel = new Model.Student.Student
        {
            FirstName = "SavedFirstName",
            LastName = "SavedLastName",
            Id = 101010
        };
        var repositoryMock = new Mock<IStudentRepository>();
        repositoryMock
            .Setup(rm => rm.CreateAsync(inputModel))
            .ReturnsAsync(createdModel);
        var orchestrator = new StudentOrchestrator(repositoryMock.Object);

        // Act
        var result = await orchestrator.CreateAsync(inputModel);

        // Assert
        result.Should().Be(createdModel);
        repositoryMock.Verify(sar => sar.CreateAsync(inputModel), Times.Once);
    }
}