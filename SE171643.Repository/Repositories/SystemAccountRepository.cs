using Microsoft.EntityFrameworkCore;
using SE171643.Repository.Abstractions;
using SE171643.Repository.Entities;

namespace SE171643.Repository.Repositories
{
    internal class SystemAccountRepository(Summer2025HandbagDbContext context) : ISystemAccountRepository
    {
        public async Task<SystemAccount?> FindByEmail(string email)
            => await context.SystemAccounts.FirstOrDefaultAsync(a => a.Email == email && a.IsActive == true);

        public async Task<SystemAccount?> ValidateCredentials(string email, string password)
            => await context.SystemAccounts.FirstOrDefaultAsync(a => a.Email == email && a.Password == password && a.IsActive == true);
    }
}
