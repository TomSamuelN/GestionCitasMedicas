using ClinicaMedica.Dominio.Contratos;
using ClinicaMedica.Dominio.Modelos;

namespace ClinicaMedica.Infraestructura.Notificaciones;

public class NotificadorEmail : INotificador
{
    public void EnviarRecordatorio(CitaMedica cita)
    {
        Console.WriteLine($"[EMAIL ENVIADO] A: {cita.Paciente.CorreoElectronico} | " +
                          $"Estimado/a {cita.Paciente.NombreCompleto}, su cita con el/la Dr/a. {cita.Medico.NombreCompleto} " +
                          $"({cita.Medico.Especialidad.Nombre}) está agendada para el {cita.FechaHora:dd/MM/yyyy HH:mm}.");
    }
}