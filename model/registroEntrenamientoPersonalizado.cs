using System;
using System.Collections.Generic;
using System.Text;

namespace TP_2.model
{
    internal class registroEntrenamientoPersonalizado
    {
        private string nombre { get; set; }
        private string apellido { get; set; }
        private string dni { get; set; }

        private servicioEntrenamientoPersonalizado entrenamiento1;

       

        public string nombreRegistro { get; set; }
        public string apellidoRegistro { get; set; }
        public string documento { get; set; }
        public entrenamientoPersonalizado entrenamiento { get; set; }

        public registroEntrenamientoPersonalizado(string nombre, string apellido, string dni, entrenamientoPersonalizado entrenamiento)
        {
            nombreRegistro = nombre;
            apellidoRegistro = apellido;
            documento = dni;
            this.entrenamiento = entrenamiento;
        }

        public registroEntrenamientoPersonalizado(string nombre, string apellido, string dni, servicioEntrenamientoPersonalizado entrenamiento1)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.entrenamiento1 = entrenamiento1;
        }

        /*
        public override string ToString()
        {
            return $"Nombre: {nombreRegistro}, Apellido: {apellidoRegistro}, DNI: {documento}, Entrenamiento: {entrenamiento.tipoEntrenamiento}, Valor: ${entrenamiento.valorFinalEntrenamientoPersonalizado}, Duración: {entrenamiento.horasDuracion} horas";
        }*/
    }

    public class entrenamientoPersonalizado
    {
    }
}
    
