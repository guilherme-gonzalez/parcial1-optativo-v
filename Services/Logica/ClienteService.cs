using Repository.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(Repository.Context.ContextAppDB context)
        {
            _clienteRepository = new ClienteRepository(context);
        }

        public async Task<bool> IsDocumentoUnique(string documento)
        {
            return await _clienteRepository.IsDocumentoUniqueAsync(documento);
        }

        public async Task<bool> AddAsync(ClienteModel modelo)
        {
            if (ValidacionCliente(modelo))
            {
                return await _clienteRepository.AddAsync(modelo);
            }
            else
            {
                return false;
            }
        }

        public async Task<ClienteModel> GetAsync(int id)
        {
            return await _clienteRepository.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(ClienteModel modelo)
        {
            if (ValidacionCliente(modelo))
            {
                return await _clienteRepository.UpdateAsync(modelo);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(ClienteModel modelo)
        {
            if (modelo != null)
            {
                return await _clienteRepository.RemoveAsync(modelo);
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<ClienteModel>> ListAsync()
        {
            try
            {
                return await _clienteRepository.ListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidacionCliente(ClienteModel cliente)
        {
            if (cliente == null || string.IsNullOrEmpty(cliente.nombre))
            {
                return false;
            }
            return true;
        }
    }
}
