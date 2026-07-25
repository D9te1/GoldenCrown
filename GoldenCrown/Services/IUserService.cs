namespace GoldenCrown.Services
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(string username, string name, string password);
    }
}
