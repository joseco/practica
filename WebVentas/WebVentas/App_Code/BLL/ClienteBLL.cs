using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientesNameEspace.DLL
{
    public class ClienteBLL
    {
        public ClienteBLL()
        {

        }

        public static List<EntidadCliente> GetClientes()
        {
            ClienteTableAdapters.Cliente_dataSetTableAdapter adapter = new ClienteTableAdapters.Cliente_dataSetTableAdapter();
            Cliente.Cliente_dataSetDataTable table = adapter.SelccionarClientes();

            List<EntidadCliente> list = new List<EntidadCliente>();
            foreach (var row in table)
            {
                EntidadCliente obj = GetClienteFromRow(row);
                list.Add(obj);
            }

            return list;
        }

        public static EntidadCliente GetContactoById(int clienteid)
        {
            if (clienteid <= 0)
                throw new ArgumentException("El id del CLIENTE no puede ser menor o igual que cero");
 
            ClienteTableAdapters.Cliente_dataSetTableAdapter adapter = new ClienteTableAdapters.Cliente_dataSetTableAdapter();
            Cliente.Cliente_dataSetDataTable table = adapter.SeleccionarClientePorID(clienteid);


            EntidadCliente obj = GetClienteFromRow(table[0]);

            return obj;
        }


        public static void EliminarClientes(int Clienteid)
        {
            if (Clienteid <= 0)
                throw new ArgumentException("El id del cliente no puede ser menor o igual que cero");

            ClienteTableAdapters.Cliente_dataSetTableAdapter adapter = new ClienteTableAdapters.Cliente_dataSetTableAdapter();
            adapter.EliminarCliente(Clienteid);

        }

        public static int InsertarClientes(EntidadCliente obj)
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
            ClienteTableAdapters.Cliente_dataSetTableAdapter adapter = new ClienteTableAdapters.Cliente_dataSetTableAdapter();
            adapter.InsertarCliente(obj.Nombre, obj.Nit);

            if (id == null || id <= 0)
                throw new Exception("La llave primaria no se generó correctamente");

            return id.Value;

        }


        public static void ActualizarContacto(EntidadCliente obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("El objeto no puede ser nulo");
            }

            if (obj.Cliente_id <= 0)
            {
                throw new ArgumentException("El id del cliente no puede ser menor o igual que cero");
            }

            if (string.IsNullOrEmpty(obj.Nombre))
            {
                throw new ArgumentException("El nombre no puede ser nulo o vacio");
            }

            if (string.IsNullOrEmpty(obj.Nit))
            {
                throw new ArgumentException("El Nit no puede ser nulo o vacio");
            }

            ClienteTableAdapters.Cliente_dataSetTableAdapter adapter = new ClienteTableAdapters.Cliente_dataSetTableAdapter();
            adapter.ActualizarCliente(obj.Cliente_id, obj.Nombre, obj.Nit);


        }

        private static EntidadCliente GetClienteFromRow(Cliente.Cliente_dataSetRow row)
        {
            EntidadCliente obj = new EntidadCliente()
            {
                Cliente_id = row.cliente_id,
                Nombre = row.nombre,
                Nit = row.nit

            };
            return obj;
        }

    }

}