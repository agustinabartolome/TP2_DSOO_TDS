using System;
using System.Collections.Generic;
using System.Text;
using TP_2.model;

namespace TP_2.service
{
    internal class ventaSuplementoService

    {
        private List<ventaSuplemento> listadoSuplementos = new List<ventaSuplemento>();

        private static List<ventaSuplemento> historialSuplementos = new List<ventaSuplemento>();


        public ventaSuplementoService()
        {
            // Inicialización hardcodeada de la lista de suplementos
            listadoSuplementos = new List<ventaSuplemento>
        {
            new ventaSuplemento("Suplemento proteico", 12, 2000, 3),
            new ventaSuplemento("Barras de cereal", 8, 1500, 18),
            new ventaSuplemento("Suplementos de aminoacidos", 15, 1900, 5)
        };
        }


        //Método para agregar suplemento

        public void crearNuevoSuplemento(string nombreNuevoSuplemento, double precioListaNuevoSuplemento, double porcentajeGananciaNuevoSuplemento, int cantidadSuplementoNuevo)
        {
            // Crear una instancia de la clase ventaSuplemento con los valores proporcionados
            ventaSuplemento suplementoVendido = new ventaSuplemento(nombreNuevoSuplemento, precioListaNuevoSuplemento, porcentajeGananciaNuevoSuplemento, cantidadSuplementoNuevo);

            // Agregar la un nuevo suplemento
            listadoSuplementos.Add(suplementoVendido);
           

            //Sumar el suplemento al historial
            historialSuplementos.Add(suplementoVendido);
        }
        
        public List<ventaSuplemento> obtenerDetallesNuevoSuplemento()
        {
            return listadoSuplementos;
        }

        //Método para buscar suplemento


        public ventaSuplemento buscarSuplementos(string buscarNombreSuplemento)
        {
            return listadoSuplementos.Find(suplemento => suplemento.nombreSuplemento == buscarNombreSuplemento);
        }

        //Método para comprar suplementos

        //Método para listar suplementos

        public List<ventaSuplemento> obtenerTodosLosSuplementos()
        {
            return listadoSuplementos;
        }

        //Método para que se muestre el historial

        public List<ventaSuplemento> obtenerHistorialSuplementos()
        {
            return historialSuplementos;
        }

    }
}
