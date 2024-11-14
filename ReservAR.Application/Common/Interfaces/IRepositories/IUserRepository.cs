using ReservAR.Application.Login.Commands;
using ReservAR.Domain.UserAggregate;
using ReservAR.Domain.UserAggregate.ValueObjects;

namespace ReservAR.Application.Common.Interfaces.IRepositories;

public interface IUserRepository : IRepositoryBase<User, UserId>
{
    Task<User?> GetUserByEmailAsync(LoginCommand userCommand, CancellationToken cancellation);
}
