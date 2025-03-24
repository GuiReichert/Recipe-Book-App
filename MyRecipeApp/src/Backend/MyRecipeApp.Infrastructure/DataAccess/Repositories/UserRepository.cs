using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyRecipeApp.Domain.Entities;
using MyRecipeApp.Domain.Repositories.User;

namespace MyRecipeApp.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        private readonly MyRecipeApp_DbContext _dbContext;

        public UserRepository(MyRecipeApp_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add (User user)
        {
            await _dbContext.Users.AddAsync(user);
        }

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _dbContext.Users.AnyAsync(u => u.Email.Equals(email) && u.isActive);
        }



    }
}
