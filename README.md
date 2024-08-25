<h1>Trabajo práctico: Sistema de facturación para el Club Deportivo</h1>

<h3>Trabajo práctico grupal realizado para la materia "Desarrollo de Sistemas Orientado a Objetos</h3>

Descripción y consignas:

El club deportivo necesita un sistema para calcular y mostrar información sobre los servicios que ofrece. El club ofrece servicio de venta de suplementos y además brinda dos tipos de servicios deportivos: 
Entrenamiento Personalizado y Clases Grupales.
A continuación se detalla la información necesaria para desarrollar el sistema.

Venta de suplementos:
 Cada suplemento tiene un nombre, un porcentaje de ganancia y un precio de lista (estos datos se deben ingresar por teclado al sistema). Para calcular el precio final de un suplemento, se suma la ganancia al precio de lista y se agrega el 21% de IVA.
Servicios Deportivos: Los servicios deportivos son de dos tipos:
 
 Entrenamiento Personalizado: Se conoce el tipo de entrenamiento y la duración en horas (estos datos se deben ingresar por teclado al sistema). El precio se calcula multiplicando la duración por $2000 que es el valor por hora de entrenamiento.
 
 Clases Grupales: Se conoce el tipo de clase, el número de participantes y la duración en minutos (estos datos se deben ingresar por teclado al sistema). El precio se calcula multiplicando la duración por $80 que es el valor por minuto de las clases. Si el número de participantes es mayor a 10, se disminuye el precio en un 20%.
 
 Para ambos servicios, se suma la mitad del IVA sobre su precio. En todos los casos, el IVA a tomar es del 21%.

El sistema debe guardar un historial de facturación que incluya tanto la venta de suplementos como los servicios prestados.

1.Diagrama UML de la solución.
2.Implementar el método "calcularPrecio()" que represente el cálculo del precio final de cada servicio.
3.Implementar otra función que recorra la lista de servicios y, para cada uno, muestre su nombre, detalles específicos y el precio final calculado. 
4.Crea una función en la clase Test que mediante un menú le permita al usuario ingresar los detalles específicos de cada servicio y agregarlo a la lista o colección. 

El menú debe tener las siguientes opciones:
 1. Agregar un nuevo servicio
 2. Mostrar detalles de los servicios
 3. Salir del programa
 
5.Además, se solicita implementar dos métodos que deberán ser mostrados al momento de finalizar el programa:
montoTotalFacturado: Devuelve el valor total facturado por el club, considerando tanto los suplementos vendidos como los servicios prestados. 
cantServiciosSimples: Devuelve la cantidad de servicios de clases grupales con menos de 10 participantes.

Diagrama UML: ![TP2_Grupo2_ComF_BartoloméAbril_BartoloméAgustina_Diagrama de Clases](https://github.com/user-attachments/assets/5162dc59-36e5-4865-83af-459313d14f2e)
