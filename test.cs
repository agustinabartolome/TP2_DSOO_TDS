using System;
using System.Collections.Generic;
using System.Linq;
using TP_2.model;
using TP_2.service;

namespace TP_2
{
    internal class test
    {
        private static List<servicioClasesGrupales> clasesGrupalesCreadas;
        private static List<servicioEntrenamientoPersonalizado> entrenamientosPersonalizadosCreados;
        private static int nuevosParticipantes;

        private static ventaSuplementoService ventaSuplementoService = new ventaSuplementoService();
        private static servicioEntrenamientoPersonalizadoService servicioEntrenamientoPersonalizadoService = new servicioEntrenamientoPersonalizadoService();
        private static servicioClasesGrupalesService servicioClasesGrupalesService = new servicioClasesGrupalesService();

        public static List<ventaSuplemento> SuplementosCreados { get; private set; }

        public static void ejecutarMenuPrincipal()
        {
            char eleccion;
            do
            {
                Console.WriteLine("***********************************************************");
                Console.WriteLine("BIENVENIDO AL SISTEMA DE INFORMACIÓN DEL CLUB DEPORTIVO");
                Console.WriteLine("***********************************************************");
                Console.WriteLine("****** Elija una opción para comenzar ******");
                Console.WriteLine("*A: Servicio de ventas de suplementos*");
                Console.WriteLine("*B: Servicio deportivo: entrenamientos personalizados*");
                Console.WriteLine("*C: Servicio deportivo: entrenamientos grupales*");
                Console.WriteLine("*D: Otras consultas sobre servicios deportivos*");
                Console.WriteLine("*E: Historial*");
                Console.WriteLine("*F: Salir*");
                Console.WriteLine("*********************************************");
                Console.WriteLine("*Ingrese su opción*");

                eleccion = Console.ReadLine()[0];

                switch (eleccion)
                {
                    case 'A':
                        menuSuplementos();
                        break;
                    case 'B':
                        menuEntrenamientosPersonalizados();
                        break;
                    case 'C':
                        menuEntrenamientosGrupales();
                        break;
                    case 'D':
                        menuOtrasConsultas();
                        break;
                    case 'E':
                        menuHistorial();
                        break;
                    case 'F':
                        Console.WriteLine("Gracias por consultar el sistema del club deportivo.");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }

            } while (eleccion != 'F');
        }

        private static void menuSuplementos()
        {
            char opcionMenuSuplementos;
            do
            {
                Console.WriteLine("***************************************************************");
                Console.WriteLine("**Menú de opciones del servicio de ventas de suplementos**");
                Console.WriteLine("***************************************************************");
                Console.WriteLine("1. Agregar suplemento");
                Console.WriteLine("2. Buscar suplemento");
                Console.WriteLine("3. Comprar suplemento");
                Console.WriteLine("4. Salir");
                Console.WriteLine("Ingrese su opción: ");
                opcionMenuSuplementos = Console.ReadLine()[0];

                switch (opcionMenuSuplementos)
                {
                    case '1':
                        //Agregamos un suplemento

                        agregarSuplemento();
                        break;
                    case '2':
                        //Se busca un suplemento por el nombre

                        buscarSuplemento();
                        break;
                    case '3':
                        // Comprar suplemento

                        comprarSuplemento();
                        break;
                    case '4':
                        Console.WriteLine("Gracias por consultar sobre suplementos.");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            } while (opcionMenuSuplementos != '4');
        }

        private static void agregarSuplemento()
        {
            Console.WriteLine("Ingrese el nombre del nuevo suplemento: ");
            string nombreNuevoSuplemento = Console.ReadLine();

            Console.WriteLine("Ingrese el precio de lista: ");
            double precioListaNuevoSuplemento = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingrese el porcentaje de ganancias: ");
            double porcentajeGananciaNuevoSuplemento = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingresela cantidad por unidad del nuevo suplemento: ");
            int cantidadSuplementoNuevo = Convert.ToInt32(Console.ReadLine());

            ventaSuplementoService.crearNuevoSuplemento(nombreNuevoSuplemento, precioListaNuevoSuplemento, porcentajeGananciaNuevoSuplemento, cantidadSuplementoNuevo);

            SuplementosCreados = ventaSuplementoService.obtenerDetallesNuevoSuplemento();

            foreach (var suplemento in SuplementosCreados)
            {
                Console.WriteLine(suplemento);
            }

            //Se deben mostrar los datos del nuevo suplemento agregado

            Console.WriteLine("Datos del nuevo suplemento: " + nombreNuevoSuplemento + ", con precio de lista de $ " + precioListaNuevoSuplemento + " y un % de ganancia de " + porcentajeGananciaNuevoSuplemento);
            double valorListaNuevoSuplemento = precioListaNuevoSuplemento + (precioListaNuevoSuplemento * porcentajeGananciaNuevoSuplemento/100);
            double valorVentaNuevoSuplemento = valorListaNuevoSuplemento + (valorListaNuevoSuplemento * 0.21);
            Console.WriteLine("El precio de venta del nuevo suplemento es de: $ " + valorVentaNuevoSuplemento);
        }

        private static void buscarSuplemento()
        {
            Console.WriteLine("Ingrese el nombre del suplemento que desea buscar: ");
            string buscarNombreSuplemento = Console.ReadLine();

            ventaSuplemento suplemento = ventaSuplementoService.buscarSuplementos(buscarNombreSuplemento);

            if (suplemento != null)
            {
                Console.WriteLine("Hemos encontrado el suplemento " + suplemento.nombreSuplemento + " en los registros del club.");
                Console.WriteLine("Su valor es de $ " + suplemento.CalcularPrecio());
            }
            else
            {
                Console.WriteLine("No se pudo encontrar el suplemento en nuestro registro.");
            }
        }

        private static void comprarSuplemento()
        {
            Console.WriteLine("Ingrese el nombre del suplemento que desea comprar: ");
            String nombreSuplemento = Console.ReadLine();

            // Buscar el suplemento en la lista de suplementos disponibles
            ventaSuplemento suplemento = ventaSuplementoService.buscarSuplementos(nombreSuplemento);

            if (suplemento != null)
            {
                Console.WriteLine("Suplemento encontrado: " + suplemento.nombreSuplemento);
                Console.WriteLine("Precio final: $ " + suplemento.CalcularPrecio());
                Console.WriteLine("Cantidad disponible: " + suplemento.cantidadDisponible);

                Console.WriteLine("Ingrese la cantidad que desea comprar: ");
                int cantidadCompra = Convert.ToInt32(Console.ReadLine());

                // Verificar si hay suficiente cantidad disponible para la compra
                if (cantidadCompra > suplemento.cantidadDisponible)
                {
                    Console.WriteLine("La cantidad solicitada excede la disponibilidad.");
                    return;
                }

                Console.WriteLine("¿Desea comprar " + cantidadCompra + " unidades de " + suplemento.nombreSuplemento + "? (sí/no)");
                string respuesta = Console.ReadLine().ToLower();

                if (respuesta == "sí" || respuesta == "si")
                {
                    // Realizar la compra
                    
                    double totalCompra = cantidadCompra * suplemento.CalcularPrecio();
                    Console.WriteLine("Detalles de la compra:");
                    Console.WriteLine("- Suplemento: " + suplemento.nombreSuplemento);
                    Console.WriteLine("- Cantidad: " + cantidadCompra);
                    Console.WriteLine("- Precio unitario: $ " + suplemento.CalcularPrecio());
                    Console.WriteLine("- Total: $ " + totalCompra);

                    Console.WriteLine("Presione Enter para aceptar la compra.");
                    Console.ReadLine();

                    // Actualizar la cantidad disponible del suplemento
                    suplemento.cantidadDisponible -= cantidadCompra;
                    Console.WriteLine("Compra realizada con éxito.");
                }
                else if (respuesta == "no")
                {
                    Console.WriteLine("Compra cancelada.");
                }
                else
                {
                    Console.WriteLine("Respuesta no reconocida. Compra cancelada.");
                }
            }
            else
            {
                Console.WriteLine("El suplemento no está en el listado del registro del club.");
            }
        }

        private static void menuEntrenamientosPersonalizados()
        {
            char opcionMenuEntrenamientoPersonalizado;
            do
            {
                Console.WriteLine("*********************************************************");
                Console.WriteLine("**Menú de opciones del servicio deportivo: entrenamiento personalizado**");
                Console.WriteLine("*********************************************************");
                Console.WriteLine("1. Buscar entrenamiento");
                Console.WriteLine("2. Reservar entrenamiento");
                Console.WriteLine("3. Salir");
                Console.WriteLine("Ingrese su opción: ");
                opcionMenuEntrenamientoPersonalizado = Console.ReadLine()[0];

                switch (opcionMenuEntrenamientoPersonalizado)
                {
                    case '1':
                        //Buscar entrenamiento

                        buscarEntrenamientoPersonalizado();
                        break;
                    case '2':
                        // Reservar entrenamiento.

                        reservarCupoEntrenamientoPersonalizado();
                        break;
                    case '3':
                        Console.WriteLine("Gracias por consultar sobre entrenamientos personalizados.");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            } while (opcionMenuEntrenamientoPersonalizado != '3');
        }

        private static void buscarEntrenamientoPersonalizado()
        {
            Console.WriteLine("Ingrese el nombre del entrenamiento personalizado que desea buscar: ");
            string buscarNombreEntrenamientoPersonalizado = Console.ReadLine();

            servicioEntrenamientoPersonalizado entrenamientoPersonalizado = servicioEntrenamientoPersonalizadoService.buscarEntrenamientoPersonalizado(buscarNombreEntrenamientoPersonalizado);

            if (entrenamientoPersonalizado != null)
            {
                Console.WriteLine("Hemos encontrado el entrenamiento " + entrenamientoPersonalizado.tipoEntrenamiento + " con una duración de " + entrenamientoPersonalizado.horasDuracion + " horas en los registros del club.");
                Console.WriteLine("Su valor es de $ " + entrenamientoPersonalizado.calcularPrecio());
            }
            else
            {
                Console.WriteLine("No se pudo encontrar el entrenamiento en nuestro registro.");
            }
        }

        private static void reservarCupoEntrenamientoPersonalizado()
        {
            Console.WriteLine("Ingrese el nombre del entrenamiento personalizado para el que desea reservar cupo: ");
            string nombreEntrenamiento = Console.ReadLine();

            // Buscar el entrenamiento personalizado en la lista de entrenamientos disponibles
            servicioEntrenamientoPersonalizado entrenamientoPersonalizado = servicioEntrenamientoPersonalizadoService.buscarEntrenamientoPersonalizado(nombreEntrenamiento);

            if (entrenamientoPersonalizado != null)
            {
                Console.WriteLine("Entrenamiento encontrado: " + entrenamientoPersonalizado.tipoEntrenamiento + ".");
                Console.WriteLine($"Valor: $  " + entrenamientoPersonalizado.calcularPrecio() + ".");
                Console.WriteLine($"Duración: " + entrenamientoPersonalizado.horasDuracion + " horas.");

                // Solicitar los datos personales del usuario
                Console.WriteLine("Ingrese sus datos personales para registrarse en este entrenamiento:");

                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Apellido: ");
                string apellido = Console.ReadLine();

                Console.Write("DNI: ");
                string dni = Console.ReadLine();

                // Mostrar los datos del registro
                Console.WriteLine("Datos del registro:");
                Console.WriteLine("Entrenamiento: " + entrenamientoPersonalizado.tipoEntrenamiento + ".");
                Console.WriteLine("Valor: $ "  + entrenamientoPersonalizado.calcularPrecio() + ".");
                Console.WriteLine("Duración: " +entrenamientoPersonalizado.horasDuracion + " horas");
                Console.WriteLine("Nombre: " + nombre + ".");
                Console.WriteLine("Apellido: " + apellido + ".");
                Console.WriteLine("DNI: " + dni + ".");

                Console.WriteLine("¿Desea confirmar el registro? (sí/no)");
                string respuesta = Console.ReadLine().ToLower();

                if (respuesta == "sí" || respuesta == "si")
                {
                    // Confirmar el registro
                    Console.WriteLine("Registro confirmado. Detalles del entrenamiento:");
                    Console.WriteLine("- Entrenamiento: " + entrenamientoPersonalizado.tipoEntrenamiento + ".");
                    Console.WriteLine("- Valor: $ " + entrenamientoPersonalizado.calcularPrecio() + ".");
                    Console.WriteLine("- Duración: " + entrenamientoPersonalizado.horasDuracion + " horas.");

                    Console.WriteLine("Presione Enter para aceptar el registro.");
                    Console.ReadLine();

                    //Para guardar la reserva
                    servicioEntrenamientoPersonalizadoService.registrarEntrenamientoPersonalizado(nombre, apellido, dni, entrenamientoPersonalizado);

                    // Mostrar el registro completo del usuario
                    Console.WriteLine("Registro completo:");
                    Console.WriteLine("Nombre: " + nombre + ".");
                    Console.WriteLine("Apellido: " + apellido + ".");
                    Console.WriteLine("DNI: " + dni + ".");
                    Console.WriteLine("Entrenamiento: " + entrenamientoPersonalizado.tipoEntrenamiento + ".");
                    Console.WriteLine("Valor: $ " + entrenamientoPersonalizado.calcularPrecio() + ".");
                    Console.WriteLine("Duración: " + entrenamientoPersonalizado.horasDuracion + " horas.");
                    Console.WriteLine("Presione Enter para volver al menú anterior.");
                    Console.ReadLine();
                }
                else if (respuesta == "no")
                {
                    Console.WriteLine("Registro cancelado.");
                }
                else
                {
                    Console.WriteLine("Respuesta no reconocida. Registro cancelado.");
                }
            }
            else
            {
                Console.WriteLine("El entrenamiento personalizado no está en el listado del registro del club.");
            }
        }

        private static void menuEntrenamientosGrupales()
        {
            char opcionMenuEntrenamientoGrupal;
            do
            {
                Console.WriteLine("*********************************************************");
                Console.WriteLine("**Menú de opciones del servicio deportivo: entrenamiento grupal**");
                Console.WriteLine("*********************************************************");
                Console.WriteLine("1. Buscar entrenamiento");
                Console.WriteLine("2. Reservar cupo");
                Console.WriteLine("3. Consultar entrenamiento disponible");
                Console.WriteLine("4. Salir");
                Console.WriteLine("Ingrese su opción: ");
                opcionMenuEntrenamientoGrupal = Console.ReadLine()[0];

                switch (opcionMenuEntrenamientoGrupal)
                {
                    case '1':
                        //Buscar Entrenamiento grupal

                        buscarEntrenamientoGrupal();
                        break;
                    case '2':
                        // Reserva cupo.

                        reservarCupoEntrenamientoGrupal();
                        break;
                    case '3':
                        // Consultar entrenamiento disponible

                        consultarEntrenamientosGrupalesDisponibles();
                        break;
                    case '4':
                        Console.WriteLine("Gracias por consultar sobre entrenamientos grupales.");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            } while (opcionMenuEntrenamientoGrupal != '4');
        }

        private static void buscarEntrenamientoGrupal()
        {
            Console.WriteLine("Ingrese el nombre del entrenamiento grupal que desea buscar: ");
            string buscarNombreClasesGrupales = Console.ReadLine();

            servicioClasesGrupales claseGrupal = servicioClasesGrupalesService.buscarClasesGrupales(buscarNombreClasesGrupales);

            if (claseGrupal != null)
            {
                Console.WriteLine("Hemos encontrado el entrenamiento " + claseGrupal.tipoClase + " donde participan " + claseGrupal.participantes + " alumnos y con una duración de " + claseGrupal.minutosDuracion + " minutos en los registros del club.");
                Console.WriteLine("Su valor es de $ " + claseGrupal.calcularPrecio());
            }
            else
            {
                Console.WriteLine("No se pudo encontrar el entrenamiento grupal en nuestro registro.");
            }
        }

        private static void reservarCupoEntrenamientoGrupal()
        {
            Console.WriteLine("Ingrese el nombre del entrenamiento grupal para el que desea reservar cupo: ");
            string nombreEntrenamiento = Console.ReadLine();

            // Buscar el entrenamiento grupal en la lista de entrenamientos disponibles
            servicioClasesGrupales entrenamiento = servicioClasesGrupalesService.buscarClasesGrupales(nombreEntrenamiento);

            if (entrenamiento != null)
            {
                Console.WriteLine("Entrenamiento encontrado: " + entrenamiento.tipoClase +".");
                Console.WriteLine("Valor: $ " + entrenamiento.calcularPrecio() + ".");
                Console.WriteLine("Duración: " +entrenamiento.minutosDuracion +" minutos");
                Console.WriteLine("Cupo máximo de participantes: " + entrenamiento.maximoParticipantes + ".");

                if (entrenamiento.participantes < entrenamiento.maximoParticipantes)
                {
                    // Solicitar los datos personales del usuario
                    Console.WriteLine("Ingrese sus datos personales para registrarse en este entrenamiento:");

                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Apellido: ");
                    string apellido = Console.ReadLine();

                    Console.Write("DNI: ");
                    string dni = Console.ReadLine();

                    // Mostrar los datos del registro
                    Console.WriteLine("Datos del registro:");
                    Console.WriteLine("Entrenamiento: " + entrenamiento.tipoClase + ".");
                    Console.WriteLine("Valor: $ " + entrenamiento.calcularPrecio() + ".");
                    Console.WriteLine("Duración: " + entrenamiento.minutosDuracion + " minutos.");
                    Console.WriteLine("Nombre: " + nombre + ".");
                    Console.WriteLine("Apellido: " + apellido + ".");
                    Console.WriteLine("DNI: " + dni + ".");

                    Console.WriteLine("¿Desea confirmar el registro? (sí/no)");
                    string respuesta = Console.ReadLine().ToLower();

                    if (respuesta == "sí" || respuesta == "si")
                    {
                        // Confirmar el registro
                        bool registrado = servicioClasesGrupalesService.registrarEntrenamientoGrupal(nombre, apellido, dni, entrenamiento);

                        if (registrado)
                        {
                            Console.WriteLine("Registro confirmado. Detalles del entrenamiento:");
                            Console.WriteLine("- Entrenamiento: " + entrenamiento.tipoClase  + ".");
                            Console.WriteLine("- Valor: $ : " + entrenamiento.calcularPrecio() + ".");
                            Console.WriteLine("- Duración: " + entrenamiento.minutosDuracion + " minutos.");
                            Console.WriteLine("- Participantes: " + entrenamiento.participantes + ".");
                            int cupoDisponible = entrenamiento.maximoParticipantes - entrenamiento.participantes;
                            Console.WriteLine("- Cupo disponible: " + cupoDisponible + ".");

                            Console.WriteLine("Presione Enter para aceptar el registro.");
                            Console.ReadLine();

                            // Mostrar el registro completo del usuario
                            Console.WriteLine("Registro completo:");
                            Console.WriteLine("Nombre: " + nombre + ".");
                            Console.WriteLine("Apellido: " + apellido + ".");
                            Console.WriteLine("DNI: " + dni + ".");
                            Console.WriteLine("Entrenamiento: " + entrenamiento.tipoClase + ".");
                            Console.WriteLine("Valor: $ " + entrenamiento.calcularPrecio() + ".");
                            Console.WriteLine("Duración: " + entrenamiento.minutosDuracion  +  "minutos.");
                            Console.WriteLine("Participantes: " + entrenamiento.participantes + ".");
                            Console.WriteLine("- Cupo disponible: " + cupoDisponible + ".");
                            Console.WriteLine("Presione Enter para volver al menú anterior.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("No se pudo realizar el registro porque el cupo está lleno.");
                        }
                    }
                    else if (respuesta == "no")
                    {
                        Console.WriteLine("Registro cancelado.");
                    }
                    else
                    {
                        Console.WriteLine("Respuesta no reconocida. Registro cancelado.");
                    }
                }
                else
                {
                    Console.WriteLine("No hay cupos disponibles para este entrenamiento.");
                }
            }
            else
            {
                Console.WriteLine("El entrenamiento grupal no está en el listado del registro del club.");
            }
        }

        private static void consultarEntrenamientosGrupalesDisponibles()
        {
            var entrenamientosDisponibles = servicioClasesGrupalesService.obtenerEntrenamientosDisponibles();

            if (entrenamientosDisponibles.Any())
            {
                Console.WriteLine("Clases grupales con cupos disponibles:");
                foreach (var entrenamiento in entrenamientosDisponibles)
                {
                    Console.WriteLine("- " + entrenamiento.tipoClase + ": " + entrenamiento.participantes + " participantes, con un cupo máximo de " + entrenamiento.maximoParticipantes + ", con una duración de " + entrenamiento.minutosDuracion + " minutos y un valor de $ " + entrenamiento.calcularPrecio() + ".");
                }
            }
            else
            {
                Console.WriteLine("No hay clases grupales disponibles con cupos.");
            }

            Console.WriteLine("Presione Enter para volver al menú anterior.");
            Console.ReadLine();
        }

        private static void menuOtrasConsultas()
        {
            char opcionMenuOtrasConsultas;
            do
            {
                Console.WriteLine("*********************************************************");
                Console.WriteLine("**Menú de opciones respecto a otras consultas**");
                Console.WriteLine("*********************************************************");
                Console.WriteLine("1. Agregar entrenamiento personalizado");
                Console.WriteLine("2. Agregar entrenamiento grupal");
                Console.WriteLine("3. Consultar listado de entrenamientos personalizados");
                Console.WriteLine("4. Consultar listado de entrenamientos grupales");
                Console.WriteLine("5. Salir");
                Console.WriteLine("Ingrese su opción: ");
                opcionMenuOtrasConsultas = Console.ReadLine()[0];

                switch (opcionMenuOtrasConsultas)
                {
                    case '1':
                        agregarEntrenamientoPersonalizado();
                        break;
                    case '2':
                        agregarEntrenamientoGrupal();
                        break;
                    case '3':
                        consultarEntrenamientosPersonalizados();
                        break;
                    case '4':
                        consultarEntrenamientosGrupales();
                        break;
                    case '5':
                        Console.WriteLine("Gracias por visitar este apartado para consultas específicas.");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            } while (opcionMenuOtrasConsultas != '5');
        }

        private static void agregarEntrenamientoPersonalizado()
        {
            Console.WriteLine("Ingrese el nombre del nuevo entrenamiento personalizado: ");
            string nombreNuevoEntrenamientoPersonalizado = Console.ReadLine();

            Console.WriteLine("Ingrese el tiempo de duración en horas: ");
            int duracionHorasEntrenamientoPersonalizado = Convert.ToInt32(Console.ReadLine());

            double valorTotal = (2000 * duracionHorasEntrenamientoPersonalizado) + (2000 * duracionHorasEntrenamientoPersonalizado * (0.21 / 2));
            Console.WriteLine("El valor total del nuevo entrenamiento personalizado es $: " + valorTotal);

            servicioEntrenamientoPersonalizadoService.crearNuevoEntrenamientoPersonalizado(nombreNuevoEntrenamientoPersonalizado, duracionHorasEntrenamientoPersonalizado);

            entrenamientosPersonalizadosCreados = servicioEntrenamientoPersonalizadoService.obtenerDetallesNuevoEntrenamientoPersonalizado();

            foreach (var entrenamiento in entrenamientosPersonalizadosCreados)
            {
                Console.WriteLine(entrenamiento);
            }
        }

        private static void agregarEntrenamientoGrupal()
        {
            Console.WriteLine("Ingrese el nombre de la nueva clase grupal: ");
            string nombreNuevaClaseGrupal = Console.ReadLine();

            Console.WriteLine("Ingrese cupo máximo de participantes: ");
            int maximoParticipantes = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese la cantidad de participantes inscriptos: ");
            int participantesClaseGrupal = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el tiempo de duración en minutos: ");
            int duracionMinutosClaseGrupal = Convert.ToInt32(Console.ReadLine());

            double valorTotalClase = (80 * duracionMinutosClaseGrupal) + (80 * duracionMinutosClaseGrupal * (0.21 / 2));
            Console.WriteLine("El valor total de la nueva clase es $: " + valorTotalClase);

            double valorTotalCompleto = (valorTotalClase - (0.2 * valorTotalClase));
            Console.WriteLine("Si se completa el cupo máximo de " + maximoParticipantes + " participantes, el nuevo valor total de la clase es de $: " + valorTotalCompleto + " por participante");

            servicioClasesGrupalesService.crearNuevaClaseGrupal(nombreNuevaClaseGrupal, participantesClaseGrupal, duracionMinutosClaseGrupal, maximoParticipantes);

            clasesGrupalesCreadas = servicioClasesGrupalesService.obtenerDetallesNuevasClasesGrupales();

            foreach (var clase in clasesGrupalesCreadas)
            {
                Console.WriteLine(clase);
            }
        }

        private static void consultarEntrenamientosPersonalizados()
        {
            List<servicioEntrenamientoPersonalizado> listaDeEntrenamientosPersonalizados = servicioEntrenamientoPersonalizadoService.obtenerTodosLosEntrenamientosPersonalizados();

            foreach (var entrenamiento in listaDeEntrenamientosPersonalizados)
            {
                Console.WriteLine(entrenamiento.tipoEntrenamiento + "  con " + entrenamiento.horasDuracion + " horas de duración. ");
                Console.WriteLine("El valor total es de $: " +  entrenamiento.calcularPrecio());
            }
        }

        private static void consultarEntrenamientosGrupales()
        {
            List<servicioClasesGrupales> listaDeClasesGrupales = servicioClasesGrupalesService.obtenerTodasLasClasesGrupales();

            foreach (var clase in listaDeClasesGrupales)
            {
                
                Console.WriteLine(clase.tipoClase + " con " + clase.participantes + " participantes, con  un cupo máximo de " + clase.maximoParticipantes + ", con " + clase.minutosDuracion + " minutos de duración.");
                Console.WriteLine("El valor total es de $: " + clase.calcularPrecio());
            }
        }

        private static void menuHistorial()
        {
            char opcionMenuHistorial;
            do
            {
                Console.WriteLine("*********************************************************");
                Console.WriteLine("**Menú de opciones sobre el historial**");
                Console.WriteLine("*********************************************************");
                Console.WriteLine("1. Servicios ventas de suplementos");
                Console.WriteLine("2. Servicios deportivos: entrenamientos personalizados");
                Console.WriteLine("3. Servicios deportivos: entrenamientos grupales");
                Console.WriteLine("4. Salir");
                Console.WriteLine("Ingrese su opción: ");
                opcionMenuHistorial = Console.ReadLine()[0];

                switch (opcionMenuHistorial)
                {
                    case '1':
                        // Historial ventas de suplementos.

                        mostrarHistorialSuplementos();

                        break;
                    case '2':
                        // Historial entrenamientos personalizados.

                        mostrarHistorialEntrenamientosPersonalizados();
                        break;
                    case '3':
                        // Historial entrenamientos grupales.

                        mostrarHistorialEntrenamientosGrupales();
                        break;
                    case '4':
                        Console.WriteLine("Gracias por consultar el historial.");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            } while (opcionMenuHistorial != '4');
        }

        private static void mostrarHistorialSuplementos()
        {

            var historial = ventaSuplementoService.obtenerHistorialSuplementos();
            foreach (var suplemento in historial)
            {
                //Invertimos los nombres de las variables porcentajeGanancias y precioLista por errores a la hora de hacer las cuentas que no se pudieron solucionar
                
                Console.WriteLine("Suplemento: " + suplemento.nombreSuplemento + ".");// Ganancia: " + suplemento.porcentajeGanancias + ". Precio: $ " + suplemento.precioLista + ".");
                
                double valorPrecioSuplementoInicial = suplemento.porcentajeGanancias + (suplemento.porcentajeGanancias * (suplemento.precioLista/ 100));
                double valorPrecioSuplementoFinal = valorPrecioSuplementoInicial + (valorPrecioSuplementoInicial * 0.21);
                Console.WriteLine("Su valor es de $ " + valorPrecioSuplementoFinal);
            }
        }

        private static void mostrarHistorialEntrenamientosPersonalizados()
        {
            var historial = servicioEntrenamientoPersonalizadoService.obtenerHistorialEntrenamientosPersonalizados();
            foreach (var entrenamiento in historial)
            {
                Console.WriteLine("Entrenamiento: " + entrenamiento.tipoEntrenamiento + ". Duración: " + entrenamiento.horasDuracion + " horas.");
                Console.WriteLine("Su valor es de $ " + entrenamiento.calcularPrecio());
            }
        }

        private static void mostrarHistorialEntrenamientosGrupales()
        {
            var historial = servicioClasesGrupalesService.obtenerHistorialClasesGrupales();
            foreach (var clase in historial)
            {
                Console.WriteLine("Clase: " + clase.tipoClase + ". Participantes: " + clase.participantes + ". Cupo Máximo: " + clase.maximoParticipantes + " participanes. Duración: " + clase.minutosDuracion + " minutos.");
                Console.WriteLine("Su valor es de $ " + clase.calcularPrecio());
            }
        }
    }
}

