using System;
using System.Collections.Generic;
using System.Text;

namespace TP_2.model
{
    internal class ventaSuplemento
    {
        public int cantidadDisponible { get; set; }
        public double precioFinal { get; set; }

        public string nombreSuplemento { get; set; }
        public double porcentajeGanancias { get; set; }
        public double precioLista { get; set; }

        public int cantidadSuplemento { get; set; }

        public ventaSuplemento(string suplemento, double gananciaPorcentaje, double listadoPrecio, int cantidadSuplemento)
        {
            nombreSuplemento = suplemento;
            porcentajeGanancias = gananciaPorcentaje;
            precioLista = listadoPrecio;
            cantidadDisponible = cantidadSuplemento;

        }

        public ventaSuplemento() { }

        public double CalcularPrecio()
        {
            double precioConGanancia = precioLista + (precioLista * (porcentajeGanancias / 100));
            double precioFinal = precioConGanancia + (precioConGanancia * 0.21);
            return precioFinal;
        }

    }
}
