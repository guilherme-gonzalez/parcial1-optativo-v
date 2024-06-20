using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository.Data
{
    public class ClienteRepository : ICliente
    {
        private readonly ContextAppDB _context;

        public ClienteRepository(ContextAppDB context)
        {
            _context = context;
        }

        public async Task<bool> IsDocumentoUniqueAsync(string documento)
        {
            return !await _context.Clientes.AnyAsync(c => c.documento == documento);
        }

        public async Task<bool> AddAsync(ClienteModel cliente)
        {
            try
            {
                await _context.Clientes.AddAsync(cliente);
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
                _context.Clientes.Remove(cliente);
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
                _context.Clientes.Update(cliente);
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
                return await _context.Clientes.FindAsync(id);
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
                return await _context.Clientes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
