namespace MediatRDemo.Domain.Entities
{
	public class MedicationLogEntry : BaseLogEntry
	{
		public int Count { get; set; }
	}

	public class WeightLogEntry : BaseLogEntry
	{
		public double Weight { get; set; }
	}
}
