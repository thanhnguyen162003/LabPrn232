using SE171643.Repository.Entities;

namespace SE171643.Repository.Abstractions
{
    public interface ISystemAccountRepository
    {
        Task<SystemAccount?> FindByEmail(string email);
        Task<SystemAccount?> ValidateCredentials(string email, string password);
    }
}
