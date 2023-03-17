using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidateUser(string userName, string password)
        {
            return await _context.Users!.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password) != null;
        }

        public async Task<User> SaveUser(User user)
        {
            try
            {
                var result = await _context.Users!.AddAsync(user);

                return result.Entity;
            }
            catch (Exception)
            {

                Exception exception = new("Error al guardar en base de datos");
                throw exception;
            }
        }
    }
}
