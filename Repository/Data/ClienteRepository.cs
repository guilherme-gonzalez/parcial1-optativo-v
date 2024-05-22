using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class ClienteRepository : ICliente
    {
        private readonly DbContext _context;

        public ClienteRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(ClienteModel cliente)
        {
            try
            {
                await _context.AddAsync(cliente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveAsync(ClienteModel cliente)
        {
            try
            {
                _context.Remove(cliente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateAsync(ClienteModel cliente)
        {
            try
            {
                _context.Update(cliente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClienteModel> GetAsync(int id)
        {
            try
            {
                return await _context.Set<ClienteModel>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ClienteModel>> ListAsync()
        {
            try
            {
                return await _context.Set<ClienteModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}