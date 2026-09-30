using ClinicaMedica.Dominio.Comun;

namespace ClinicaMedica.Dominio.Modelos;

public class CitaMedica
{
    public Guid Id { get; }
    public Paciente Paciente { get; }
    public Medico Medico { get; }
    public DateTime FechaHora { get; private set; }
    public EstadoCita Estado { get; private set; }

    public CitaMedica(Paciente paciente, Medico medico, DateTime fechaHora)
    {
        Id = Guid.NewGuid();
        Paciente = paciente ?? throw new ArgumentNullException(nameof(paciente));
        Medico = medico ?? throw new ArgumentNullException(nameof(medico));
        FechaHora = Validador.FechaFutura(fechaHora, nameof(fechaHora));
        Estado = EstadoCita.Programada;
    }

    public void Cancelar()
    {
        if (Estado == EstadoCita.Cancelada)
            throw new InvalidOperationException("La cita ya se encuentra cancelada.");

        Estado = EstadoCita.Cancelada;
    }

    public void Reprogramar(DateTime nuevaFechaHora)
    {
        if (Estado == EstadoCita.Cancelada)
            throw new InvalidOperationException("No se puede reprogramar una cita cancelada.");

        FechaHora = Validador.FechaFutura(nuevaFechaHora, nameof(nuevaFechaHora));
        Estado = EstadoCita.Reprogramada;
    }
}