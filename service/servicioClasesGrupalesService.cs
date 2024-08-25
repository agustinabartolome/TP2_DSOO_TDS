using System;
using System.Collections.Generic;
using System.Text;
using TP_2.model;

namespace TP_2.service
{
    internal class servicioClasesGrupalesService
    {
        private List<servicioClasesGrupales> listaDeClasesGrupales = new List<servicioClasesGrupales>();

        private List<servicioClasesGrupales> historialClasesGrupales = new List<servicioClasesGrupales>();

        private List<registroClasesGrupales> registros = new List<registroClasesGrupales>();

        public int maximoParticipantes;

        public servicioClasesGrupalesService()
        {
            // Inicialización hardcodeada de la lista de suplementos
            listaDeClasesGrupales = new List<servicioClasesGrupales>
        {
            new servicioClasesGrupales("Yoga", 20, 60, 20),
            new servicioClasesGrupales("Pilates", 10, 45, 15),
            new servicioClasesGrupales("Zumba", 15, 50, 25),
            new servicioClasesGrupales("Circuito", 10, 50, 12)
        };
        }


        //Método para buscar entrenamiento o clases grupales

        public servicioClasesGrupales buscarClasesGrupales(string buscarNombreClasesGrupales)
        {
            return listaDeClasesGrupales.Find(clase => clase.tipoClase == buscarNombreClasesGrupales);
        
        }

        //Método para reservar entrenamiento o clases grupales

        public bool registrarEntrenamientoGrupal(string nombre, string apellido, string dni, servicioClasesGrupales entrenamiento)
        {
            if (entrenamiento.participantes < entrenamiento.maximoParticipantes)
            {
                entrenamiento.participantes++;
                var nuevoRegistro = new registroClasesGrupales(nombre, apellido, dni, entrenamiento, maximoParticipantes);
                registros.Add(nuevoRegistro);
                return true;
            }
            else
            {
                return false; // No hay cupo disponible
            }
        }

        public List<registroClasesGrupales> obtenerRegistros()
        {
            return registros;
        }

        //Método para listar entrenamiento o clases grupales

        public List<servicioClasesGrupales> obtenerTodasLasClasesGrupales()
        {
            return listaDeClasesGrupales;
        }

        //Crear Clases Grupales

        public void crearNuevaClaseGrupal(string nombreNuevaClaseGrupal, int nuevosParticipantes , int duracionMinutosClaseGrupal, int maximoParticipantes)
        {
            // Crear una instancia de la clase serviciosClasesGrupales con los valores proporcionados
            servicioClasesGrupales nuevaClaseGrupal = new servicioClasesGrupales(nombreNuevaClaseGrupal, nuevosParticipantes, duracionMinutosClaseGrupal, maximoParticipantes);

            // Agregar la nueva actividad grupal a la lista de actividades
            listaDeClasesGrupales.Add(nuevaClaseGrupal);

            //Para que se sume al historial
            historialClasesGrupales.Add(nuevaClaseGrupal);
        }

        public List<servicioClasesGrupales> obtenerDetallesNuevasClasesGrupales()
        {
            return listaDeClasesGrupales;
        }

        // Método para que se muestre el historial

        public List<servicioClasesGrupales> obtenerHistorialClasesGrupales()
        {
            return historialClasesGrupales;
        }

        //Métodos entrenamientos disponibles

        public List<servicioClasesGrupales> obtenerEntrenamientosDisponibles()
        {
            return listaDeClasesGrupales.FindAll(e => e.participantes < e.maximoParticipantes);
        }
        /*
        internal bool registrarEntrenamientoGrupal(string nombre, string apellido, string dni, entrenamientoGrupal entrenamiento)
        {
            if (entrenamiento.participantes < entrenamiento.maximoParticipantes)
            {
                entrenamiento.participantes++;
                var nuevoRegistro = new registroClasesGrupales(nombre, apellido, dni, entrenamiento, maximoParticipantes);
                registros.Add(nuevoRegistro);
                return true;
            }
            else
            {
                return false; // No hay cupo disponible
            }
        }*/
    }

    
}
