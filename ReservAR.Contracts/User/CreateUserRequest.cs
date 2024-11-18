namespace ReservAR.Contracts.User;

public record CreateUserRequest(string firstName,
    string lastName,
    string email,
    string password);
