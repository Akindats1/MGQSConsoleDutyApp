namespace DutiesAllocation.Entities.Dto
{
    public class DutyDto
    {
        public string DutyName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime Created { get; set; }
    }
}