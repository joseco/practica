using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
   public class ClienteBLL
    {
        public ClienteBLL()
        {
            
        }

        public static List<Cliente> GetCliente( ){

            CapaDatos.ClienteDSTableAdapters.ClienteTableAdapter adapter = new CapaDatos.ClienteDSTableAdapters.ClienteTableAdapter();
            ClienteDS.ClienteDataTable table = adapter.GetCliente();

            List<Cliente> list = new List<Cliente>();
            foreach(var row in table){
                Cliente obj= getCLienteFromRow(row);
                    list.Add(obj);
            }
            return list;
        }
        public static Cliente getCLienteFromRow(ClienteDS.ClienteRow row)
        {
            Cliente obj = new Cliente()
            {
                ClienteId = row.cliente_id,
                Nombre = row.nombre,
                Nit = row.nit
            };
            return obj;
        }





        public static void EliminarCliente(int clienteId)
        {
            if(clienteId <=0)
                throw new ArgumentException("El id del Cliente no puede ser menor o igual que cero");
            CapaDatos.ClienteDSTableAdapters.ClienteTableAdapter adapter = new CapaDatos.ClienteDSTableAdapters.ClienteTableAdapter();
            adapter.EliminarCliente(clienteId);
        }


        public static int InsertarCliente(Cliente obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("El objeto no puede ser nulo");
            }

            if (string.IsNullOrEmpty(obj.Nombre))
            {
                throw new ArgumentException("El nombre no puede ser nulo o vacio");
            }

            if (string.IsNullOrEmpty(obj.Nit))
            {
                throw new ArgumentException("El nit no puede ser nulo o vacio");
            }

            
            int? id = 0;
            CapaDatos.ClienteDSTableAdapters.ClienteTableAdapter adapter = new CapaDatos.ClienteDSTableAdapters.ClienteTableAdapter();
            adapter.InsertarCliente(obj.Nombre, obj.Nit, ref id);

            if (id == null || id <= 0)
                throw new Exception("La llave primaria no se generó correctamente");

            return id.Value;
        }




        public static void ActualizarCliente(Cliente obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("El objeto no puede ser nulo");
            }

            if (string.IsNullOrEmpty(obj.Nombre))
            {
                throw new ArgumentException("El nombre no puede ser nulo o vacio");
            }

            if (string.IsNullOrEmpty(obj.Nit))
            {
                throw new ArgumentException("El nit no puede ser nulo o vacio");
            }

            CapaDatos.ClienteDSTableAdapters.ClienteTableAdapter adapter = new CapaDatos.ClienteDSTableAdapters.ClienteTableAdapter();
            adapter.InsertarCliente(obj.Nombre, obj.Nit, obj.ClienteId);
        }


        public static Cliente GetCLienteById(int clienteId)
        {
            if (clienteId <= 0)
                throw new ArgumentException("El id del contacto no puede ser menor o igual que cero");

            CapaDatos.ClienteDSTableAdapters.ClienteTableAdapter adapter = new CapaDatos.ClienteDSTableAdapters.ClienteTableAdapter();
            ClienteDS.ClienteDataTable table = adapter.GetClienteById(clienteId);

            Cliente obj = getCLienteFromRow(table[0]);

            return obj;
        }


        public static Cliente GetCLienteByNit(int clienteId)
        {
            if (clienteId <= 0)
                throw new ArgumentException("El Nit del contacto no puede ser menor o igual que cero");

            CapaDatos.ClienteDSTableAdapters.ClienteTableAdapter adapter = new CapaDatos.ClienteDSTableAdapters.ClienteTableAdapter();
            ClienteDS.ClienteDataTable table = adapter.GetClienteById(clienteId);
            Cliente obj = getCLienteFromRow(table[0]);

            return obj;
        }

    }
}
