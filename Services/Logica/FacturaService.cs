using Repository.Data;
using System;
using System.Collections.Generic;

namespace Services.Logica
{
    public class FacturaService
    {
        private readonly FacturaRepository _facturaRepository;

        public FacturaService(string connectionString)
        {
            _facturaRepository = new FacturaRepository(connectionString);
        }

        public bool Add(FacturaModel modelo)
        {
            if (ValidacionFactura(modelo))
            {
                return _facturaRepository.add(modelo);
            }
            else
            {
                return false;
            }
        }

        public FacturaModel Get(int id)
        {
            return _facturaRepository.get(id);
        }

        public bool Update(FacturaModel modelo)
        {
            if (ValidacionFactura(modelo))
            {
                return _facturaRepository.update(modelo);
            }
            else
            {
                return false;
            }
        }

        public bool Delete(FacturaModel modelo)
        {
            if (modelo != null)
            {
                return _facturaRepository.remove(modelo);
            }
            else
            {
                return false;
            }
        }
        
        public IEnumerable<FacturaModel> list()
        {
            try
            {
                return _facturaRepository.list();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidacionFactura(FacturaModel factura)
        {
            if (factura == null || string.IsNullOrEmpty(factura.nro_factura))
            {
                return false;
            }
            return true;
        }
    }
}