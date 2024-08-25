using System;
using System.Collections.Generic;
using System.Text;

namespace TP_2.model
{
    internal class servicioEntrenamientoPersonalizado
    {

        public string tipoEntrenamiento { get; set; }
        public double horasDuracion { get; set; }

        private double valorInicial { get; set; }
        private double gananciaTotal { get; set; }
        private double valorFinal { get; set; }


        public servicioEntrenamientoPersonalizado(string tipoEntrenamiento, double horasDuracion)
        {
            this.tipoEntrenamiento = tipoEntrenamiento;
            this.horasDuracion = horasDuracion;
        }

        public servicioEntrenamientoPersonalizado() { }

        public double calcularPrecio()
        {
            valorInicial = 2000 * horasDuracion;
            gananciaTotal = valorInicial * (0.21 / 2);
            valorFinal = valorInicial + gananciaTotal;
            return valorFinal;
        }

    }

    }



