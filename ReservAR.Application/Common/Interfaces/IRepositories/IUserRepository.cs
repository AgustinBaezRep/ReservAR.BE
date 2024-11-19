using ReservAR.Application.Login.Commands;
using ReservAR.Domain.UserAggregate.ValueObjects;

namespace ReservAR.Application.Common.Interfaces.IRepositories;

public interface IUserRepository : IRepositoryBase<Domain.UserAggregate.User, UserId>
{
    Task<Domain.UserAggregate.User?> GetUserByEmailAsync(LoginCommand userCommand, CancellationToken cancellation);
}
