using ConsoleTables;
using DutiesAllocation.Repository;
using DutiesAllocationApp.Constants;
using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Entities.Dto;
using DutiesAllocationApp.Repository;
using DutiesAllocationApp.Repository.Contracts;
using DutiesAllocationApp.Services.Contracts;

namespace DutiesAllocationApp.Services
{
    public class DutyAssignmentService : IDutyAssignmentService
    {
        private readonly DutyRepository _dutyRepository;
        private readonly StudentRepository _studentRepository;
        private readonly DutyAssignmentRepository _dutyAssignmentRepository;

        public DutyAssignmentService(DutyAssignmentRepository dutyAssignmentRepository, StudentRepository studentRepository, DutyRepository dutyRepository)
        {
            _dutyRepository = dutyRepository;
            _studentRepository = studentRepository;
            _dutyAssignmentRepository = dutyAssignmentRepository;

        }
        public void AssignDutyTostudent(DutyAssignmentDto request)
        {
            var dutiesAssignment = _dutyAssignmentRepository.GetDutyAssignments(); 
   
            Console.WriteLine("Enter duty id: ");
            int dutyId = request.DutyId = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Enter student code: ");
            string studentCode = request.StudentCode = Console.ReadLine()!;

            var student = _studentRepository.FindByCode(studentCode)!;
            var duty = _dutyRepository.FindById(dutyId);
            var studentAssignmentCode = _dutyAssignmentRepository.GetDutyAssignmentByStudentCode(studentCode);


            var dutyAssign = new DutyAssignment
            {
                StudentCode = studentCode,
                DutyName = duty.DutyName,
                StudentName = $"{student.FirstName} {student.LastName}",
            };

            if (duty == null || student == null)
            {
                Console.WriteLine("Student or duty does not exist");
                return;
            }

            if (studentAssignmentCode == null)
            {
                dutiesAssignment.Add(dutyAssign);
                Console.WriteLine($"{duty.DutyName} duty has been assigned to {student.LastName} {student.FirstName}");
                return;

            }
            
            Console.WriteLine($"{studentAssignmentCode.DutyName} duty already assigned to {studentAssignmentCode.StudentName}");
        }

        public void DeleteDutyToStudent(string code)
        {
            try
            {

                var dutyAssignment = _dutyAssignmentRepository.GetDutyAssignmentByStudentCode(code);
                var student = _studentRepository.FindByCode(code);
                var dutyAssignments = _dutyAssignmentRepository.GetDutyAssignments();

                if (student == null)
                {
                    Console.Write("Record not found");
                    return;
                }

                dutyAssignments.Remove(dutyAssignment);
                Console.WriteLine($"{dutyAssignment.DutyName} duty successfully deleted for {dutyAssignment.StudentName}");
            }
            catch (Exception ex)
            {
                Console.Write($"Something went wrong:{ex.Message}");
            }
        }

        public void UpdateDutyToStudent(int id, UpdateDutyAssignmentDto request)
        {
            var dutyAssignment = _dutyAssignmentRepository.FindById(id);
            var student = _studentRepository.FindById(id);
            var duty = _dutyAssignmentRepository.FindById(id);

            if (duty == null || student == null)
            {
                Console.WriteLine("Record not found");
                return;
            }

            if (dutyAssignment != null)
            {
               Console.Write("Enter student code: ");
                request.StudentCode = Console.ReadLine()!;

                Console.Write("Enter duty name: ");
                request.DutyName = Console.ReadLine()!;

                Console.Write("Enter student name: ");
                request.StudentName = Console.ReadLine()!.Trim();


                dutyAssignment.StudentName = request.StudentName;
                dutyAssignment.DutyName = request.DutyName;
                dutyAssignment.StudentCode = request.StudentCode;
                
                Console.WriteLine($"Duty assignment successfully updated!");
                return;
            }

            Console.WriteLine($"Duty assignment not found!");

        }

        public void ViewAllDutyToStudent()
        {
            try
            {
                if (_dutyAssignmentRepository is not null)
                {
                    var table = new ConsoleTable( "Student Code", "Student Name", "Duty Name");
                    

                    foreach (var student in _dutyAssignmentRepository.dutyAssignments)
                    {
                        table.AddRow(student.StudentCode, student.StudentName, student.DutyName);
                    }

                    table.Write(Format.Default);

                    return;
                }

                Console.WriteLine(Messages.NORECORDSFOUND);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ViewDutyToAStudent(string dutyName)
        {
            var dutyAssignment = _dutyAssignmentRepository.GetAllDutyAssignments(dutyName);

            if (dutyAssignment is not null)
            {
                foreach (var duty in dutyAssignment)
                {
                    PrintView(duty);
                }
            }

        }

        public void PrintView(DutyAssignment dutyAssignment)
        {
            Console.WriteLine(
                $@"Student Code:{dutyAssignment.StudentCode} 
                Student Name:{dutyAssignment.StudentName}
                Duty Name: {dutyAssignment.DutyName}");
        }


    }


}
