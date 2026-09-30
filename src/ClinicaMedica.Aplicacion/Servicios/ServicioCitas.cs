using ClinicaMedica.Dominio.Contratos;
using ClinicaMedica.Dominio.Modelos;

namespace ClinicaMedica.Aplicacion.Servicios;

public class ServicioCitas
{
    private readonly IRepositorioCitas _repositorioCitas;
    private readonly INotificador _notificador;
    private static readonly TimeSpan DuracionCita = TimeSpan.FromMinutes(30);

    public ServicioCitas(IRepositorioCitas repositorioCitas, INotificador notificador)
    {
        _repositorioCitas = repositorioCitas ?? throw new ArgumentNullException(nameof(repositorioCitas));
        _notificador = notificador ?? throw new ArgumentNullException(nameof(notificador));
    }

    public CitaMedica AgendarCita(Paciente paciente, Medico medico, DateTime fechaHora)
    {
        if (_repositorioCitas.ExisteSolapamiento(medico.Id, fechaHora, DuracionCita))
            throw new InvalidOperationException("El médico no se encuentra disponible en la fecha y hora seleccionadas.");

        var cita = new CitaMedica(paciente, medico, fechaHora);
        _repositorioCitas.Guardar(cita);
        return cita;
    }

    public void ReprogramarCita(Guid citaId, DateTime nuevaFechaHora)
    {
        var cita = _repositorioCitas.ObtenerPorId(citaId)
                   ?? throw new KeyNotFoundException("Cita no encontrada.");

        if (_repositorioCitas.ExisteSolapamiento(cita.Medico.Id, nuevaFechaHora, DuracionCita))
            throw new InvalidOperationException("El médico no se encuentra disponible en el nuevo horario.");

        cita.Reprogramar(nuevaFechaHora);
    }

    public void CancelarCita(Guid citaId)
    {
        var cita = _repositorioCitas.ObtenerPorId(citaId)
                   ?? throw new KeyNotFoundException("Cita no encontrada.");

        cita.Cancelar();
    }

    public void EnviarRecordatorio(Guid citaId)
    {
        var cita = _repositorioCitas.ObtenerPorId(citaId)
                   ?? throw new KeyNotFoundException("Cita no encontrada.");

        if (cita.Estado == EstadoCita.Cancelada)
            throw new InvalidOperationException("No se puede enviar recordatorio de una cita cancelada.");

        _notificador.EnviarRecordatorio(cita);
    }

    public IEnumerable<CitaMedica> ConsultarPorPaciente(Guid pacienteId) =>
        _repositorioCitas.ObtenerPorPacienteId(pacienteId);

    public IEnumerable<CitaMedica> ConsultarPorMedico(Guid medicoId) =>
        _repositorioCitas.ObtenerPorMedicoId(medicoId);
}