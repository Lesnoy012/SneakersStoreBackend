namespace SneakersStoreAuth.API.Contracts
{
    public record UserRegisterRequest(
        string UserName,
        string Password
    );
}
