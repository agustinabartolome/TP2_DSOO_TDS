using System;
using System.Collections.Generic;
using System.Text;
using TP_2.model;

namespace TP_2.service
{
    internal class servicioEntrenamientoPersonalizadoService
    {
        private List<servicioEntrenamientoPersonalizado> entrenamientosPersonalizados = new List<servicioEntrenamientoPersonalizado>();

        private List<servicioEntrenamientoPersonalizado> historialEntrenamientosPersonalizados = new List<servicioEntrenamientoPersonalizado>();

        private List<registroEntrenamientoPersonalizado> registros = new List<registroEntrenamientoPersonalizado>();

        public servicioEntrenamientoPersonalizadoService()
        {
            // Inicialización hardcodeada de la lista de suplementos
            entrenamientosPersonalizados = new List<servicioEntrenamientoPersonalizado>
        {
            new servicioEntrenamientoPersonalizado("Fuerza" ,2),
            new servicioEntrenamientoPersonalizado("Cinta", 1),
            new servicioEntrenamientoPersonalizado("Circuito", 1.15),
            new servicioEntrenamientoPersonalizado("Natacion", 1.5)
        };
        }

        //Método para buscar entrenamiento personalizado


        public servicioEntrenamientoPersonalizado buscarEntrenamientoPersonalizado(string buscarNombreEntrenamientoPersonalizado)
        {
            return entrenamientosPersonalizados.Find(entrenamiento => entrenamiento.tipoEntrenamiento == buscarNombreEntrenamientoPersonalizado);
        }


        //Método para reservar y/o registrar entrenamiento personalizado

        public void registrarEntrenamientoPersonalizado(string nombre, string apellido, string dni, entrenamientoPersonalizado entrenamiento)
        {
            var nuevoRegistro = new registroEntrenamientoPersonalizado(nombre, apellido, dni, entrenamiento);
            registros.Add(nuevoRegistro);
        }

        public List<registroEntrenamientoPersonalizado> obtenerRegistros()
        {
            return registros;
        }

        //Método para listar entrenamiento personalizado

        public List<servicioEntrenamientoPersonalizado> obtenerTodosLosEntrenamientosPersonalizados()
        {
            return entrenamientosPersonalizados;
        }

        //Agregar entrenamiento personalizado


        public void crearNuevoEntrenamientoPersonalizado(string nombreNuevoEntrenamientoPersonalizado, double duracionHorasEntrenamientoPersonalizado)
        {
            // Crear una instancia de la clase serviciosEntrenamientosPersonalizados con los valores proporcionados
            servicioEntrenamientoPersonalizado nuevoEntrenamiento = new servicioEntrenamientoPersonalizado(nombreNuevoEntrenamientoPersonalizado, duracionHorasEntrenamientoPersonalizado);

            // Agregar la nueva actividad grupal a la lista de actividades
            entrenamientosPersonalizados.Add(nuevoEntrenamiento);

            //Sumar el entrenamiento al historial
            historialEntrenamientosPersonalizados.Add(nuevoEntrenamiento);
        }

        

        public List<servicioEntrenamientoPersonalizado> obtenerDetallesNuevoEntrenamientoPersonalizado()
        {
            return entrenamientosPersonalizados;
        }

        //Método para que se muestre el historial

        public List<servicioEntrenamientoPersonalizado> obtenerHistorialEntrenamientosPersonalizados()
        {
            return historialEntrenamientosPersonalizados;
        }

        public void registrarEntrenamientoPersonalizado(string nombre, string apellido, string dni, servicioEntrenamientoPersonalizado entrenamiento)
        {
            var nuevoRegistro = new registroEntrenamientoPersonalizado(nombre, apellido, dni, entrenamiento);
            registros.Add(nuevoRegistro); 
        }
    }
}

