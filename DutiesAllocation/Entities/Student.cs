using DutiesAllocationApp.Enums;

namespace DutiesAllocationApp.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentCode { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string Email { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public DateOnly DateJoined { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }  
    }
}