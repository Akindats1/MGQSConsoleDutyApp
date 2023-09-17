using DutiesAllocationApp.Enums;

namespace DutiesAllocation.Entities.Dto
{
    public record UpdateStudentDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public Gender Gender { get; set; }   
    }
}