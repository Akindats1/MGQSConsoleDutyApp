using DutiesAllocation.Entities.Dto;
using DutiesAllocation.Repository;
using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Repository.Contracts;
using DutiesAllocationApp.Shared;

namespace DutiesAllocationApp.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public List<Student> students = new List<Student>();
        
        public Student Create(StudentDto request)
        {

            int id = students.Count != 0 ? students[students.Count - 1].Id + 1 : 1;
            string code = Helper.GenerateCode(id);

            var student = new Student
            {
                Id = id,
                StudentCode = code,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                DateJoined = request.DateJoined,
                Created = DateTime.Now
            };

            return student;
        }
        public Student FindByCode(string code)
        {
            return students.Find(i => i.StudentCode == code)!;
        }

        public Student FindById(int id)
        {
            return students.Find(i => i.Id == id)!;
        }

        public Student FindByIdOrCode(int id, string code)
        {
            return students.Find(i => i.Id == id || i.StudentCode == code)!;
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public Student FindByEmail(string email)
        {
            return students.Find(x => x.Email == email)!;
        }



    }
}