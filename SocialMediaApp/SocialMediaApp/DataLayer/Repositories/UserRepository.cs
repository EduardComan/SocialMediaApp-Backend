using SocialMediaApp.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialMediaApp.DataLayer.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User GetUserByEmail(string name);
        User GetUserByIdWithNotifications(Guid id);
    }

    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        public UserRepository(EfDbContext context) : base(context) { }


        public User GetUserByEmail(string email)
        {
            //SELECT TOP(1) * from Users as u
            var result = GetRecords()

                // FULL JOIN Notifications as n on n.UserId = u.Id
                //.Include(u => u.Notifications)

                // WHERE u.Email = @email 
                // IQueryable pana aici -> rezultatul nu e concret
                .Where(u => u.Email == email)

                .FirstOrDefault();
            // -> rezultat concret
            return result;
        }

        public User GetUserByIdWithNotifications(Guid id)
        {
            //var result = GetRecords()
            //    .Include(user => user.Notifications)
            //    .FirstOrDefault(user => user.Id == id);

            //return result;

            return null;
        }
    }
}
