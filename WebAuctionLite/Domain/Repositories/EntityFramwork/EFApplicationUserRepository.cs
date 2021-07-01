using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAuctionLite.Domain.Entities;
using WebAuctionLite.Domain.Repositories.Abstract;
using WebAuctionLite.Entities;

namespace WebAuctionLite.Domain.Repositories.EntityFramework
{
    public class EFApplicationUserRepository : IApplicationUserRepository
    {
        private readonly AppDbContext context;
        public EFApplicationUserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<ApplicationUser> GetApplicationUsers()
        {
            return context.ApplicationUsers;
        }

        public ApplicationUser GetApplicationUserById(Guid id)
        {
            return context.ApplicationUsers.FirstOrDefault(x => x.Id == id);
        }

        public ApplicationUser GetApplicationUserByName(string firstName)
        {
            return context.ApplicationUsers.FirstOrDefault(x => x.FirstName == firstName);
        }

        public void SaveApplicationUser(ApplicationUser entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteApplicationUser(Guid id)
        {
            context.ApplicationUsers.Remove(new ApplicationUser() { Id = id });
            context.SaveChanges();
        }
    }
}
