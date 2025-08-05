using Microsoft.EntityFrameworkCore;
using ReservAR.Application.Common.Interfaces.IRepositories;
using ReservAR.Application.Login.Commands;
using ReservAR.Domain.UserAggregate;
using ReservAR.Domain.UserAggregate.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Repositories;

internal class UsuarioRepository(ReservarDbContext dbContext) : RepositoryBase<Usuario, UsuarioId>(dbContext), IUserRepository
{
    public async Task<Usuario?> GetUserByEmailAsync(LoginCommand userCommand, CancellationToken cancellation)
    {
        var user = await DbQuery
            .FirstOrDefaultAsync(user => user.Email.Equals(userCommand.email));

        return user;
    }
}
