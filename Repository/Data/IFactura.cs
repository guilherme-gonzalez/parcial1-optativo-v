using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public interface IFactura
    {
        Task<bool> AddAsync(FacturaModel factura);
        Task<bool> RemoveAsync(FacturaModel factura);
        Task<bool> UpdateAsync(FacturaModel factura);
        Task<FacturaModel> GetAsync(int id);
        Task<IEnumerable<FacturaModel>> ListAsync();
    }
}