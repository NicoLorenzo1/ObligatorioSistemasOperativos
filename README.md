# ObligatorioSistemasOperativos

Sistemas Operativos, curso 2022

Trabajo Obligatorio

4 de Abril de 2022.

En el presente documento se detallan los trabajos obligatorios que deberán ser entregados en las fechas indicadas. 


Detalle de cada Entrega

Primera Entrega

En esta primera entrega, se deberá realizar lo siguiente:

	Instalación de una máquina virtual (tipo 2) con algún sistema operativo Linux server. Algunos de los sistemas operativos Linux server libres son: Ubuntu, Debian, CentosOS. 
	Crear un grupo llamado SO.
	Crear un usuario sin privilegios llamado SO_User.
	Crear un shell script llamado copiaSeguridad.sh que realizará una copia de seguridad del usuario cuyo nombre se pase como parámetro en un directorio de copias de seguridad que tendremos en nuestro sistema. El script deberá copiar el directorio personal del usuario elegido dentro del directorio /backup, en un directorio con el nombre del usuario. Por ejemplo, para el usuario javierpm, deberá copiar el directorio personal de javierpm en el directorio /backup/javierpm.
	Modificar la seguridad de Linux para que el usuario SO_User pueda ejecutar en modo root solo para el script copiaSeguridad.sh

 

A tener en cuenta:

Deberás tener en cuenta los siguientes requisitos:
	Respaldos
	Se debe ejecutar el script como root.
	Se debe pasar por parámetro el nombre de un usuario con cuenta en el sistema. Esto implicará comprobar:
	Que se ha pasado un valor en el parámetro 1
	Que el valor pasado por parámetro corresponde con el nombre de una cuenta de usuario en el sistema.
	Se deberá obtener la información de la cuenta de usuario del fichero de cuentas de usuario del sistema. En concreto necesitamos la ruta del directorio personal del usuario al que se va a realizar la copia de seguridad.
	Se deben mantener los permisos de los ficheros almacenados en el directorio personal del usuario en el directorio de copia de seguridad.
	Para el caso en que ya exista el directorio dentro de /backup, se deberá preguntar si se desea eliminar el backup existente. 
	Top
	Al inicio del sistema, se debe ejecutar un script cada 1 minuto que saque estadísticas del sistema y de cada proceso (automático). Consumo de CPU, memoria y demás información.
	La salida debe ser almacenada dentro del directorio /Estadisticas

Que entregar?

Se deberá entregar un informe de no más de 30 páginas detallando lo realizado, justificando pasos y decisiones, además del marco conceptual teórico correspondiente.

El informe deberá contener un breve capítulo de conclusiones. 
Segunda Entrega

Se nos ha contratado para realizar un planificador de corto plazo para un sistema operativo servidor que se instalará en un servidor de mediano porte. Pero antes de comenzar el desarrollo, se nos pide que generemos una simulación del mismo como para poderla evaluar su comportamiento. Esto es con el objetivo de validar si el diseño es correcto para este servidor. 

Para que la evaluación del planificador sea lo más realista posible, se nos pide que el mismo contemple (entre otras cosas): 

	Poder ingresar la cantidad de procesadores o cores.
	Poder modificar la cantidad de tiempo que los procesos se encuentran en CPU.
	Poder modificar la prioridad de los mismos en tiempo de ejecución (prioridad de 1 a 99).
	Poder bloquear un proceso en cualquier momento.
	Poder cargar (de alguna forma) múltiples procesos de un solo ingreso
	Poder insertar procesos ya sea del S.O. como de usuario indicando:
	Tiempo total de ejecución
	Cada qué tiempo realiza una E/S (periódica sin modificación)
	Tiempo en que espera por la E/S (puede ser diferente para cada proceso).


En todo momento se deberá visualizar lo siguiente:
	Proceso ejecutando en CPU (o en CPUs)
	Lista de los procesos listos indicando el orden en que ingresaran a CPU.
	Lista de los procesos bloqueados (indicando si se encuentra bloqueado por el usuario o por una entrada salida) ordenada en cada momento por quien sería el próximo a ser desbloqueado.


Qué entregar?

Se deberá entregar un informe no más de 60 páginas, indicando cada paso que se ha realizado indicando el porqué del mismo. Es decir, justificando cada acción realizada.

Se deberá justificar cada aspecto que el planificador tome en consideración para evaluar quien será el próximo a procesar. 

 
Entregables: El presente trabajo deberá ser entregado conjuntamente con el informe del análisis, discusión, documentación de la solución propuesta incluido un pseudocódigo, y la demostración que se lograron los resultados esperados, con las conclusiones que le merezca. Los entregables deberán ser subidos a la webasignatura. 

Reglas de colaboración: El obligatorio es en grupo de 3 personas, los integrantes son los responsables de la división del trabajo en forma equitativa. El trabajo debe ser original, producido enteramente por ustedes. La documentación teórica debe contener las referencias a las fuentes de donde tomó la información (con referencias en los párrafos correspondientes) y en caso de incluir texto literal de alguna fuente DEBEN ponerlo entre comillas. Debe poner referencias a cualquier fuente consultada, utilice la metodología propuesta en el documento “Presentacion del Curso” y las normas APA, que se encuentra en el material del curso. 

Entregas tardías: No se es posible entregar el obligatorio después de fecha. 

Entregas por email: No se aceptarán entregas por email excepto que Web Asignatura no esté disponible seis horas antes a la fecha final de entrega. La entrega por email debe enviarse a todos los profesores y pedirles confirmación de entrega. Es su responsabilidad asegurarse que el trabajo haya sido recibido. 

Valuación: La entrega será evaluada y se asignará una nota a cada uno de los estudiantes, pudiéndose tomar defensas orales y/o escritas en el caso que los profesores lo consideren necesario. 

Fechas: 
Entrega de la letra: 04 de abril de 2022 
Primera Entrega: 18 de mayo de 2022. Hora 18:15
Defensa Primer Entrega: 25 de mayo de 2022, Hora 18:15
Segunda Entrega: 20 de junio de 2022, Hora 18:15
Defensa Segunda Entrega: 27 de junio de 2022, Hora 18:15
