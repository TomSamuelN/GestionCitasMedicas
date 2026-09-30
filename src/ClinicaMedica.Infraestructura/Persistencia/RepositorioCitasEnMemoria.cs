using ClinicaMedica.Dominio.Contratos;
using ClinicaMedica.Dominio.Modelos;

namespace ClinicaMedica.Infraestructura.Persistencia;

public class RepositorioCitasEnMemoria : RepositorioEnMemoria<CitaMedica>, IRepositorioCitas
{
    public IEnumerable<CitaMedica> ObtenerPorPacienteId(Guid pacienteId) =>
        _datos.Where(c => c.Paciente.Id == pacienteId);

    public IEnumerable<CitaMedica> ObtenerPorMedicoId(Guid medicoId) =>
        _datos.Where(c => c.Medico.Id == medicoId);

    public bool ExisteSolapamiento(Guid medicoId, DateTime fechaHora, TimeSpan duracion)
    {
        return _datos.Any(c =>
            c.Medico.Id == medicoId &&
            c.Estado != EstadoCita.Cancelada &&
            Math.Abs((c.FechaHora - fechaHora).TotalMinutes) < duracion.TotalMinutes);
    }
}