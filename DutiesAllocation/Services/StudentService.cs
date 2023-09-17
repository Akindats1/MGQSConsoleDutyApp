using ConsoleTables;
using DutiesAllocation.Entities.Dto;
using DutiesAllocation.Repository;
using DutiesAllocationApp.Constants;
using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Enums;
using DutiesAllocationApp.Repository;
using DutiesAllocationApp.Repository.Contracts;
using DutiesAllocationApp.Services.Contracts;
using DutiesAllocationApp.Shared;

namespace DutiesAllocationApp.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentRepository _studentRepository;
        
        public StudentService(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void CreateStudent(StudentDto request)
        {   
            try
            {
                Console.Write("Enter firstname: ");
                request.FirstName = Console.ReadLine()!;

                Console.Write("Enter lastname: ");
                request.LastName = Console.ReadLine()!;

                Console.Write("Enter middlename: ");
                request.MiddleName = Console.ReadLine();

                Console.Write("Enter email address: ");
                request.Email = Console.ReadLine()!;

                int gender = Helper.SelectEnum("Enter employee gender:\nEnter 1 for Male\nEnter 2 for Female: ", 1, 2);
                request.Gender = (Gender)gender;

                Console.Write("Enter date of birth (2003-12-25): ");
                var dob = Helper.TryParseDateOnly(Console.ReadLine()!);
                request.DateOfBirth = dob;

                Console.Write("Enter date joined (2003-12-25): ");
                var joinedDate = Helper.TryParseDateOnly(Console.ReadLine()!);
                request.DateJoined = joinedDate;

                var findStudent = _studentRepository.FindByEmail(request.Email);

                if (findStudent is not null)
                {
                    Console.WriteLine($"Record with {findStudent.Email} already exist!");
                    return;
                }

                var student = _studentRepository.Create(request);

                _studentRepository.students.Add(student);
                Console.WriteLine($"Record with `{request.Email}` created successfully");

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
            public void UpdateStudent( UpdateStudentDto request)
            {
                try
                {
                    Console.Write("Enter ID for employee to update record: ");
                    int id = int.Parse(Console.ReadLine()!);
                    var student = _studentRepository.FindById(id);

                    if (student is not null)
                    {
                        Console.Write("Enter new firstname: ");
                        student.FirstName = request.FirstName = Console.ReadLine()!;

                        Console.Write("Enter new lastname: ");
                        student.LastName = request.LastName = Console.ReadLine()!;

                        Console.Write("Enter new middlename: ");
                        student.MiddleName = request.MiddleName = Console.ReadLine()!;

                        int genderUpdate = Helper.SelectEnum("Enter employee gender:\nEnter 1 for Male\nEnter 2 for Female: ", 1, 2);
                        student.Gender = request.Gender = (Gender)genderUpdate;

                        student.Modified = DateTime.Now;

                        Console.WriteLine(Messages.RECORDUPDATED);
                        return;
                    }

                    Console.WriteLine(Messages.NOTFOUND);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        public void DeleteStudent()
        {
            try
            {
                Console.Write("Enter employee code of employee to delete: ");
                string code = Console.ReadLine()!;
                var employee = _studentRepository.FindByCode(code);

                if (employee is not null)
                {
                    _studentRepository.students.Remove(employee);
                    Console.WriteLine(Messages.RECORDREMOVED);
                    return;
                }

                Console.WriteLine(Messages.NOTFOUND);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetAllStudents()
        {
            try
            {
                if (_studentRepository.students.Count != 0)
                {
                    var table = new ConsoleTable("Id", "Employee Code", "Firstname", "Lastname", "Date Joined");

                    foreach (var student in _studentRepository.students)
                    {
                        table.AddRow(student.Id, student.StudentCode, student.FirstName, student.LastName, student.DateJoined);
                    }

                    table.Write(Format.Alternative);

                    return;
                }

                Console.WriteLine(Messages.NORECORDSFOUND);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ViewStudent()
        {
            try
            {
                Console.Write("Enter employee code to search: ");
                string code = Console.ReadLine()!;

                var employee = _studentRepository.FindByCode(code);

                if (employee is not null)
                {
                    PrintStudentDetail(employee);
                    return;
                }

                Console.WriteLine(Messages.NOTFOUND);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void PrintStudentDetail(Student student)
        {
            Console.WriteLine(
           $@"Id: {student.Id}
            Employee Code: {student.StudentCode}
            Firstname: {student.FirstName}
            Lastname: {student.LastName}
            Middlename: {student.MiddleName}
            Email: {student.Email}
            Gender: {student.Gender}
            Date Of Birth: {student.DateOfBirth.ToShortDateString()}
            Date Joined {student.DateJoined.ToString("dd/MM/yyyy")}"
           );
        }


    }
}