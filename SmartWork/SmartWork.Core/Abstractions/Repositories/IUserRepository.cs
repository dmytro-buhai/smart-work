using Microsoft.AspNetCore.Identity;

namespace SmartWork.Core.Abstractions.Repositories
{
    interface IUserRepository : IRepository<IdentityUser>
    {
    }
}
