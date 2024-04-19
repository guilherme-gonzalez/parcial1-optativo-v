using Repository.Data;
using System;
using System.Collections.Generic;

namespace Services.Logica
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(string connectionString)
        {
            _clienteRepository = new ClienteRepository(connectionString);
        }

        public bool Add(ClienteModel modelo)
        {
            if (ValidacionCliente(modelo))
            {
                return _clienteRepository.add(modelo);
            }
            else
            {
                return false;
            }
        }

        public ClienteModel Get(int id)
        {
            return _clienteRepository.get(id);
        }

        public bool Update(ClienteModel modelo)
        {
            if (ValidacionCliente(modelo))
            {
                return _clienteRepository.update(modelo);
            }
            else
            {
                return false;
            }
        }

        public bool Delete(ClienteModel modelo)
        {
            if (modelo != null)
            {
                return _clienteRepository.remove(modelo);
            }
            else
            {
                return false;
            }
        }
        
        public IEnumerable<ClienteModel> list()
        {
            try
            {
                return _clienteRepository.list();
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