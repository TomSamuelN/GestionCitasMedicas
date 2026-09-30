using ClinicaMedica.Aplicacion.Servicios;
using ClinicaMedica.Dominio.Modelos;
using ClinicaMedica.Infraestructura.Notificaciones;
using ClinicaMedica.Infraestructura.Persistencia;

Console.WriteLine("=== SISTEMA DE GESTIÓN DE CITAS MÉDICAS ===");

// 1. Inicialización de dependencias (DIP)
var repoCitas = new RepositorioCitasEnMemoria();
var notificador = new NotificadorEmail();
var servicioCitas = new ServicioCitas(repoCitas, notificador);

// 2. Registrar especialidades
var cardiologia = new Especialidad("Cardiología");
var pediatria = new Especialidad("Pediatría");
Console.WriteLine($"Especialidades creadas: {cardiologia.Nombre}, {pediatria.Nombre}");

// 3. Registrar médicos y asignar especialidad
var drPerez = new Medico("Dr. Carlos Pérez", cardiologia);
var draGomez = new Medico("Dra. Ana Gómez", pediatria);
Console.WriteLine($"Médicos registrados: {drPerez.NombreCompleto} ({drPerez.Especialidad.Nombre})");

// Reasignación de especialidad
draGomez.AsignarEspecialidad(cardiologia);
Console.WriteLine($"Especialidad actualizada para {draGomez.NombreCompleto}: {draGomez.Especialidad.Nombre}");

// 4. Registrar pacientes
var paciente1 = new Paciente("María López", "maria.lopez@example.com", "555-0101");
var paciente2 = new Paciente("Juan Morales", "juan.morales@example.com", "555-0202");
Console.WriteLine($"Pacientes registrados: {paciente1.NombreCompleto}, {paciente2.NombreCompleto}");

// 5. Agendar cita médica
var fechaCita1 = DateTime.Now.AddDays(2).Date.AddHours(10); // En 2 días a las 10:00
var cita1 = servicioCitas.AgendarCita(paciente1, drPerez, fechaCita1);
Console.WriteLine($"\n[CITA AGENDADA] ID: {cita1.Id} para {paciente1.NombreCompleto} con {drPerez.NombreCompleto} el {cita1.FechaHora:dd/MM/yyyy HH:mm}");

// 6. Enviar recordatorio
Console.WriteLine("\n--- Envío de Recordatorio ---");
servicioCitas.EnviarRecordatorio(cita1.Id);

// 7. Consultar citas por paciente y por médico
Console.WriteLine("\n--- Consultas de Citas ---");
var citasPaciente = servicioCitas.ConsultarPorPaciente(paciente1.Id);
Console.WriteLine($"Citas encontradas para el paciente {paciente1.NombreCompleto}: {citasPaciente.Count()}");

var citasMedico = servicioCitas.ConsultarPorMedico(drPerez.Id);
Console.WriteLine($"Citas encontradas para el médico {drPerez.NombreCompleto}: {citasMedico.Count()}");

// 8. Reprogramar cita
Console.WriteLine("\n--- Reprogramación ---");
var nuevaFecha = fechaCita1.AddHours(2); // Mismo día a las 12:00
servicioCitas.ReprogramarCita(cita1.Id, nuevaFecha);
Console.WriteLine($"Cita reprogramada con éxito. Nueva fecha: {cita1.FechaHora:dd/MM/yyyy HH:mm} (Estado: {cita1.Estado})");

// 9. Cancelar cita
Console.WriteLine("\n--- Cancelación ---");
servicioCitas.CancelarCita(cita1.Id);
Console.WriteLine($"Cita cancelada con éxito. Estado actual: {cita1.Estado}");

Console.WriteLine("\n=== Ejecución finalizada correctamente ===");