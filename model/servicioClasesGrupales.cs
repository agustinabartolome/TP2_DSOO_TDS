using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace TP_2.model
{
    internal class servicioClasesGrupales
    {
        
        public string tipoClase { get; set; }
        public int participantes { get; set; }
        public int minutosDuracion { get; set; }

        public int nuevosParticipantes {  get; set; }

        public double valorInicial { get; set; }
        public double gananciaTotal { get; set; }
        public double total { get; set; }
        public double valorFinal { get; set; }

        public double valorFinalClaseGrupal { get; set; }
        public int maximoParticipantes { get; set; }

        public servicioClasesGrupales(string tipoClase, int participantes, int minutosDuracion, int maximoParticipantes)
        {
            this.tipoClase = tipoClase;
            this.participantes = participantes;
            this.minutosDuracion = minutosDuracion;
            this.maximoParticipantes = maximoParticipantes;
        }

        public servicioClasesGrupales() { }

        public double calcularPrecio()
        {
            double valorInicial = 80 * minutosDuracion;
            if (participantes > 10)
            {
                valorInicial *= 0.8; // Descuento del 20%
            }
            double gananciaTotal = valorInicial * (0.21 / 2);
            return valorInicial + gananciaTotal;
        }

    
    }

}
