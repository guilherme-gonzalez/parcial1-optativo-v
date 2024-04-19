using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Repository.Data
{
    public class ClienteRepository : ICliente
    {
        private IDbConnection conexionDB;

        public ClienteRepository(string _connectionString)
        {
            conexionDB = new DbConection(_connectionString).dbConnection();
        }

        public bool add(ClienteModel cliente)
        {
            try
            {
                //var cmd = conexionDB.CreateCommand();
                //cmd.CommandText = */
                
                var query = @"INSERT INTO Cliente(nombre, id_banco, apellido, documento, direccion, mail, celular, estado) 
VALUES(@Nombre,@Id_banco, @Apellido, @Documento, @Direccion, @Mail, @Celular, @Estado)";
                if (conexionDB.Execute(query, cliente) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool remove(ClienteModel cliente)
        {
            try
            {
                var query = "DELETE FROM Cliente WHERE Id = @Id";
                if (conexionDB.Execute(query, cliente) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(ClienteModel cliente)
        {
            try
            {
                var query = @"UPDATE Cliente SET
                              id_banco = @Id_banco,
                              nombre = @Nombre, 
                              apellido = @Apellido, 
                              documento = @Documento, 
                              direccion = @Direccion, 
                              mail = @Mail, 
                              celular = @Celular, 
                              estado = @Estado 
                              WHERE Id = @Id";
                if (conexionDB.Execute(query, cliente) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteModel get(int id)
        {
            try
            {
                var query = "SELECT * FROM Cliente WHERE Id = @Id";
                return conexionDB.QueryFirstOrDefault<ClienteModel>(query, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ClienteModel> list()
        {
            try
            {
                var query = "SELECT * FROM Cliente";
                return conexionDB.Query<ClienteModel>(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

