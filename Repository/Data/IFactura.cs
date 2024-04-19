using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public interface IFactura
    {
        bool add(FacturaModel factura);
        bool remove(FacturaModel factura);
        bool update(FacturaModel factura);
        FacturaModel get(int id);
        IEnumerable<FacturaModel> list();
    }
}