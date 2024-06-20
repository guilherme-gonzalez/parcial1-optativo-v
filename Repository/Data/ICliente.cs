using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public interface ICliente
    {
        Task<bool> AddAsync(ClienteModel cliente);
        Task<bool> RemoveAsync(ClienteModel cliente);
        Task<bool> UpdateAsync(ClienteModel cliente);
        Task<ClienteModel> GetAsync(int id);
        Task<IEnumerable<ClienteModel>> ListAsync();
        Task<bool> IsDocumentoUniqueAsync(string documento);
    }
}