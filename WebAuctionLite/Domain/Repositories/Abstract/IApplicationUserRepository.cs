using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAuctionLite.Domain.Entities;
using WebAuctionLite.Entities;

namespace WebAuctionLite.Domain.Repositories.Abstract
{
    public interface IApplicationUserRepository
    {
        IQueryable<ApplicationUser> GetApplicationUsers();
        ApplicationUser GetApplicationUserById(Guid id);
        ApplicationUser GetApplicationUserByName(string firstName);
        void SaveApplicationUser(ApplicationUser entity);
        void DeleteApplicationUser(Guid id);
    }
}
