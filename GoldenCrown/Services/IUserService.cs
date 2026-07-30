namespace GoldenCrown.Services
{
    public interface IUserService
    {
        Task<Result<string>> LoginAsync(string login, string password);
        Task<Result> RegisterAsync(string username, string name, string password);
    }
}
