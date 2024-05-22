using Repository.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class FacturaService
    {
        private readonly FacturaRepository _facturaRepository;

        public FacturaService(Repository.Context.ContextAppDB context)
        {
            _facturaRepository = new FacturaRepository(context);
        }

        public async Task<bool> AddAsync(FacturaModel modelo)
        {
            if (ValidacionFactura(modelo))
            {
                return await _facturaRepository.AddAsync(modelo);
            }
            else
            {
                return false;
            }
        }

        public async Task<FacturaModel> GetAsync(int id)
        {
            return await _facturaRepository.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(FacturaModel modelo)
        {
            if (ValidacionFactura(modelo))
            {
                return await _facturaRepository.UpdateAsync(modelo);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(FacturaModel modelo)
        {
            if (modelo != null)
            {
                return await _facturaRepository.RemoveAsync(modelo);
            }
            else
            {
                return false;
            }
        }
        
        public async Task<IEnumerable<FacturaModel>> ListAsync()
        {
            try
            {
                return await _facturaRepository.ListAsync();
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