using Microsoft.EntityFrameworkCore;
using ReservAR.Application.Common.Interfaces.IRepositories;
using ReservAR.Application.Login.Commands;
using ReservAR.Domain.UserAggregate;
using ReservAR.Domain.UserAggregate.ValueObjects;

namespace ReservAR.Infraestructure.Persistance.Repositories;

internal class UserRepository(ReservarDbContext dbContext) : RepositoryBase<User, UserId>(dbContext), IUserRepository
{
    public async Task<User?> GetUserByEmailAsync(LoginCommand userCommand, CancellationToken cancellation)
    {
        var user = await DbQuery
            .FirstOrDefaultAsync(user => user.Email.Equals(userCommand.email) && user.Password.Equals(userCommand.password));

        return user;
    }
}
