namespace MediatRDemo.Domain.Entities
{
	public class MedicationLogEntry<TMeasurement> : BaseLogEntry
	{
		public Medication Medication { get; set; }
		public TMeasurement Measurement { get; set; }
	}
}
