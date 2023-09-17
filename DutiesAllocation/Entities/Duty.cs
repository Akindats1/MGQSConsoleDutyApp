namespace DutiesAllocationApp.Entities
{
    public class Duty
    {
        public int Id { get; set; }
        public string DutyName { get; set; } = null!;
        public string? Description { get; set; } 
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}