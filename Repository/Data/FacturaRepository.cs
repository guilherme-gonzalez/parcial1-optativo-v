using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class FacturaRepository : IFactura
    {
        private readonly DbContext _context;

        public FacturaRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(FacturaModel factura)
        {
            try
            {
                await _context.AddAsync(factura);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveAsync(FacturaModel factura)
        {
            try
            {
                _context.Remove(factura);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateAsync(FacturaModel factura)
        {
            try
            {
                _context.Update(factura);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FacturaModel> GetAsync(int id)
        {
            try
            {
                return await _context.Set<FacturaModel>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<FacturaModel>> ListAsync()
        {
            try
            {
                return await _context.Set<FacturaModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}