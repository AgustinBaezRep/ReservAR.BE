using ReservAR.Application.Login.Commands;
using ReservAR.Domain.UserAggregate.ValueObjects;

namespace ReservAR.Application.Common.Interfaces.IRepositories;

public interface IUserRepository : IRepositoryBase<Domain.UserAggregate.Usuario, UsuarioId>
{
    Task<Domain.UserAggregate.Usuario?> GetUserByEmailAsync(LoginCommand userCommand, CancellationToken cancellation);
}
