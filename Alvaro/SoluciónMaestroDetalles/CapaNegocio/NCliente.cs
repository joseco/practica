using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapaDatos;
using System.Data;


namespace CapaNegocio
{
    public class NCliente
    {
        //metodo Insertar que llama el metodo insertar de la clase dCliente
        //de la CADADatos

        public static string Insertar(string nombre, string nit)
        {
            DCliente obj = new DCliente();
            obj.Nombre = nombre;
            obj.Nit = nit;
            return obj.Insertar(obj);
        }
        //metodo Actualizar que llama el metodo insertar de la clase dCliente
        //de la CADADatos

        public static string Actualizar(int clienteId, string nombre, string nit)
        {
            DCliente obj = new DCliente();
            obj.ClienteId = clienteId;
            obj.Nombre = nombre;
            obj.Nit = nit;
            return obj.Actualizar(obj);
        }
        //metodo eliminar que llama el metodo insertar de la clase dCliente
        //de la CADADatos

        public static string Eliminar(int clienteid)
        {
            DCliente obj = new DCliente();
            obj.ClienteId = clienteid;
            return obj.Eliminar(obj);
        }


        //metodo Mostrar que llama el metodo Mostrar de la clase dCliente
        //de la CADADatos

        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        //metodo Mostrar que llama el metodo Mostrar por Id de la clase dCliente
        //de la CADADatos

        public static DataTable MostrarId(int buscarById)
        {
            DCliente obj = new DCliente();
            obj.TextoBuscarId =buscarById;
            return obj.BuscarPorID(obj);
        }

        //metodo Mostrar que llama el metodo Mostrar por Nit la clase dCliente
        //de la CADADatos

        public static DataTable MostrarNit(string buscarNit)
        {
             DCliente obj = new DCliente();
             obj.TextoBuscar = buscarNit;
            return obj.BuscarNit(obj);
        }

    }
}