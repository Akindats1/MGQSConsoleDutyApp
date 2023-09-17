using DutiesAllocation.Entities.Dto;
using DutiesAllocationApp.Entities;

namespace DutiesAllocationApp.Repository.Contracts
{
    public interface IStudentRepository
    {
        Student Create(StudentDto request);
        Student FindByCode(string code);
        Student FindById(int id);
        Student FindByEmail(string email);
        List<Student> GetAllStudents();
    }
}