using DutiesAllocation.Entities.Dto;
using DutiesAllocationApp.Entities;

namespace DutiesAllocationApp.Services.Contracts
{
    public interface IStudentService
    {
        void CreateStudent(StudentDto request);
        void UpdateStudent( UpdateStudentDto updateStudentDto);
        void DeleteStudent();
        void ViewStudent();
        void GetAllStudents();

       
    }
}