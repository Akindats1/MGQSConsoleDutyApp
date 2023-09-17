namespace DutiesAllocationApp.Entities.Dto
{
    public record DutyAssignmentDto
    { 
        public int DutyId { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string DutyName { get; set; } = string.Empty;
    }
}
