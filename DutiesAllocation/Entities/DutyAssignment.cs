namespace DutiesAllocationApp.Entities
{
    public class DutyAssignment 
    {
        public int DutyId { get; set; }
        public string StudentCode { get; set; } = null!;
        public string StudentName { get; set; } = null!;
        public string DutyName { get; set; } = null!;
    }
}
