using ClinicaMedica.Dominio.Modelos;

namespace ClinicaMedica.Dominio.Contratos;

public interface INotificador
{
    void EnviarRecordatorio(CitaMedica cita);
}