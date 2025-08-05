using Moq;
using ReservAR.Application.Common.Interfaces;
using ReservAR.Application.Common.Interfaces.IRepositories;
using ReservAR.Application.Login.Commands;
using ReservAR.Application.User.Commands.Create;
using ErrorOr;
using AutoFixture;

namespace ReservAR.Application.Test.Users;

public class CreateUserCommandHandlerTest : BaseTest<CreateUserCommandHandler>
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IAggregateLoader> _aggregateLoaderMock;
    private readonly Domain.UserAggregate.Usuario _userAggregate;
    private readonly CreateUserCommand _createUserCommand;
    private readonly LoginCommand _loginCommand;

    private readonly CancellationToken _cancellationToken;

    private readonly IFixture _fixture;

    public CreateUserCommandHandlerTest()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _aggregateLoaderMock = new Mock<IAggregateLoader>();
        _userAggregate = Mock.Of<Domain.UserAggregate.Usuario>();

        _cancellationToken = CancellationToken.None;

        _fixture = new Fixture();
        _createUserCommand = _fixture.Create<CreateUserCommand>();
        _loginCommand = _fixture.Create<LoginCommand>();

        _aggregateLoaderMock.Setup(s => s.CreateAggregate<Domain.UserAggregate.Usuario, Domain.UserAggregate.ValueObjects.UsuarioId>())
            .Returns(_userAggregate);

        Mock.Get(_userAggregate).Setup(s => s.Create(_createUserCommand.firstName,
            _createUserCommand.lastName,
            _createUserCommand.email,
            _createUserCommand.password));

        SUT = new CreateUserCommandHandler(_userRepositoryMock.Object,
            _aggregateLoaderMock.Object);
    }

    [Fact]
    public async Task CreateUserCommandHandler_ShouldReturnCreated_WhenUserWasAddedToTheDatabaseSuccesfully()
    {
        // Arrange
        _userRepositoryMock.Setup(s => s.GetUserByEmailAsync(_loginCommand, _cancellationToken))
            .ReturnsAsync(() => null);

        _userRepositoryMock.Setup(s => s.AddAsync(_userAggregate, _cancellationToken))
            .Returns(Task.CompletedTask);

        // Act
        var result = await SUT.Handle(_createUserCommand, _cancellationToken);

        // Assert
        Assert.IsType<ErrorOr<Created>>(result);
    }
}
