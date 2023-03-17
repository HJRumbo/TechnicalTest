using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Person>> GetAll() 
        {

            return await _context.People!.FromSql($"EXEC SP_SelectAllPeople").ToListAsync();
        }

        public async Task<bool> SavePerson(Person person)
        {
            try
            {
                await _context.People!.AddAsync(person);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                Exception exception = new("Error al guardar en base de datos");
                throw exception;
            }
        }
    }
}
