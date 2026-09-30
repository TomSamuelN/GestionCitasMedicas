using ClinicaMedica.Dominio.Contratos;
using ClinicaMedica.Dominio.Modelos;

namespace ClinicaMedica.Infraestructura.Notificaciones;

public class NotificadorSms : INotificador
{
    public void EnviarRecordatorio(CitaMedica cita)
    {
        Console.WriteLine($"[SMS ENVIADO] Al número: {cita.Paciente.Telefono} | Recordatorio de cita con Dr/a. {cita.Medico.NombreCompleto}: {cita.FechaHora:dd/MM/yyyy HH:mm}.");
    }
}