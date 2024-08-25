using System;
using System.Collections.Generic;
using System.Text;

namespace TP_2.model
{
    internal class registroClasesGrupales
    {
        private string nombre { get; set; }
        private string apellido { get; set; }
        private string dni { get; set; }
        private servicioClasesGrupales entrenamiento;

        public string nombreRegistroGrupal { get; set; }
        public string apellidoRegistroGrupal { get; set; }
        public string documento { get; set; }

        public int maximoParticipantes { get; set; }
        public entrenamientoGrupal Entrenamiento { get; set; }


        public registroClasesGrupales(string nombre, string apellido, string dni, servicioClasesGrupales entrenamiento, int maximoParticipantes)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.entrenamiento = entrenamiento;
            this.maximoParticipantes = maximoParticipantes;
        }

        /*
        public override string ToString()
        {
            return "Nombre: " +  nombreRegistroGrupal + ". Apellido: " +  apellidoRegistroGrupal + ". DNI: " + documento + ". Entrenamiento: clase grupal:" + servicioClasesGrupales.tipoClase + ", valor: " + servicioClasesGrupales.calcularPrecio() + ", duración: " + servicioClasesGrupales.minutosDuracion + " minutos, y " + servicioClasesGrupales.participantes/servicioClasesGrupales.maximoParticipantes + " participantes.";
        }*/
    }

    public class entrenamientoGrupal
    {
        internal int participantes;
        internal int maximoParticipantes;
    }
}

