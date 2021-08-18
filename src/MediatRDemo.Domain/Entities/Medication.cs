namespace MediatRDemo.Domain.Entities
{
	public class Medication : BaseEntity<int>
	{
		public MedicationAmountType Type { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
