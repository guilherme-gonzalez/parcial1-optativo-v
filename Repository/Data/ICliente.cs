using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public interface ICliente
    {
        bool add(ClienteModel cliente);
        bool remove(ClienteModel cliente);
        bool update(ClienteModel cliente);
        ClienteModel get(int id);
        IEnumerable<ClienteModel> list();
    }
}
