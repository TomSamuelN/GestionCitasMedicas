using ClinicaMedica.Dominio.Modelos;

namespace ClinicaMedica.Dominio.Contratos;

public interface IRepositorioCitas : IRepositorio<CitaMedica>
{
    IEnumerable<CitaMedica> ObtenerPorPacienteId(Guid pacienteId);
    IEnumerable<CitaMedica> ObtenerPorMedicoId(Guid medicoId);
    bool ExisteSolapamiento(Guid medicoId, DateTime fechaHora, TimeSpan duracion);
}