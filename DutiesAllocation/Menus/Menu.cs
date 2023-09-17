using DutiesAllocation.Entities.Dto;
using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Entities.Dto;
using DutiesAllocationApp.Enums;
using DutiesAllocationApp.Services;
using DutiesAllocationApp.Services.Contracts;
using System;
using System.IO;

namespace DutiesAllocationApp.Menus
{
    public class Menu
    {
        public static void MainMenu(IStudentService studentService, IDutyService dutyService, IDutyAssignmentService dutyAssignmentService)
        {
            bool flag = true;
            var studentDto = new StudentDto();
            var updateStudentDto = new UpdateStudentDto();
            var dutyDto = new DutyDto();
            var dutyAssignmentDto = new DutyAssignmentDto();

            try
            {
                while (flag)
                {
                    PrintMenu();
                    Console.Write("\nPlease enter your preferred option: ");
                    string option = Console.ReadLine()!;

                    switch (option.ToLower())
                    {
                        case "1":
                            StudentMenu(studentService);
                            Console.WriteLine("");
                            break;
                        case "2":
                            DutyMenu(dutyService);
                            Console.WriteLine("");
                            break;
                        case "3":
                            DutyAssignmentMenu(dutyAssignmentService);
                            Console.WriteLine("");
                            break;
                        case "0":
                            flag = false;
                            break;
                        default:
                            throw new InvalidOperationException("Unknown operation!");
                    }
                }
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            static void PrintMenu()
            {
                Console.WriteLine("Enter 1 to view student menu.");
                Console.WriteLine("Enter 2 to view duty menu.");
                Console.WriteLine("Enter 3 to view duty assignment menu.");
                Console.WriteLine("Enter 0 to exit.");
            }

        }

        public static void StudentMenu(IStudentService studentService)
        {
            var studentDto = new StudentDto();
            var updateStudentDto = new UpdateStudentDto();
            var flag = true;

            while (flag)
            {
                PrintStudentMenu();
                string option = Console.ReadLine()!;
                switch (option.ToLower())
                {
                    case "1":
                        Console.WriteLine("");
                        studentService.CreateStudent(studentDto);
                        Console.WriteLine("");
                        break;
                    case "2":
                        Console.WriteLine("");
                        studentService.GetAllStudents();
                        Console.WriteLine("");
                        break;
                    case "3":
                        Console.WriteLine("");
                        studentService.ViewStudent();
                        Console.WriteLine("");
                        break;
                    case "4":
                        Console.WriteLine("");
                        studentService.UpdateStudent(updateStudentDto);
                        Console.WriteLine("");
                        break;
                    case "5":
                        Console.WriteLine("");
                        studentService.DeleteStudent();
                        Console.WriteLine("");
                        break;
                    case "0":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;

                }

            }
            static void PrintStudentMenu()
            {
                Console.WriteLine("Enter 1 to add new Student.");
                Console.WriteLine("Enter 2 to view all students.");
                Console.WriteLine("Enter 3 to view a student.");
                Console.WriteLine("Enter 4 to update a student.");
                Console.WriteLine("Enter 5 to delete a student.");
                Console.WriteLine("Enter 0 to go back to main menu.");
            }
        }

        public static void DutyMenu(IDutyService dutyService)
        {
            var dutyDto = new DutyDto();
            var updateDutyDto = new UpdateDutyDto();
            var flag = true;

            while (flag)
            {
                PrintDutyMenu();
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("");
                        dutyService.CreateDuty(dutyDto);
                        Console.WriteLine("");
                        break;
                    case "2":
                        Console.WriteLine("");
                        dutyService.GetAllDuties();
                        Console.WriteLine("");
                        break;
                    case "3":
                        Console.WriteLine("");
                        dutyService.UpdateDuty(updateDutyDto);
                        Console.WriteLine("");
                        break;
                    case "4":
                        Console.WriteLine("");
                        dutyService.DeleteDuty();
                        Console.WriteLine("");
                        break;
                    case "5":
                        Console.WriteLine("");
                        dutyService.ViewDuty();
                        Console.WriteLine("");
                        break;
                    case "0":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;

                }
            }
            static void PrintDutyMenu()
            {
                Console.WriteLine("Enter 1 to create new duty.");
                Console.WriteLine("Enter 2 to view all duty.");
                Console.WriteLine("Enter 3 to update duty.");
                Console.WriteLine("Enter 4 to delete duty.");
                Console.WriteLine("Enter 5 to view a duty");
                Console.WriteLine("Enter 0 to go back to main menu.");
            }
        }

        public static void DutyAssignmentMenu(IDutyAssignmentService dutyAssignmentService)
        {
            var updateDutyAssignmentDto = new UpdateDutyAssignmentDto();
            var dutyAssignmentDto = new DutyAssignmentDto();
            var flag = true;

            while (flag)
            {
                PrintDutyAssignmentMenu();
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("");
                        dutyAssignmentService.AssignDutyTostudent(dutyAssignmentDto);
                        Console.WriteLine("");
                        break;
                    case "2":
                        Console.WriteLine("");
                        dutyAssignmentService.ViewAllDutyToStudent();
                        Console.WriteLine("");
                        break;
                    case "3":
                        Console.WriteLine("");
                        Console.Write("Enter student code: ");
                        string inputCode = Console.ReadLine();
                        dutyAssignmentService.DeleteDutyToStudent(inputCode);
                        Console.WriteLine("");
                        break;
                    case "4":
                        Console.WriteLine("");
                        Console.Write("Enter duty assignment id to update: ");
                        int id = int.Parse(Console.ReadLine()!);
                        dutyAssignmentService.UpdateDutyToStudent(id, updateDutyAssignmentDto);
                        Console.WriteLine("");
                        break;
                    case "5":
                        Console.WriteLine("");
                        Console.Write("Enter the name of duty to view: ");
                        string viewDuty = Console.ReadLine();
                        dutyAssignmentService.ViewDutyToAStudent(viewDuty);
                        Console.WriteLine("");
                        break;
                    case "0":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
            static void PrintDutyAssignmentMenu()
            {
                Console.WriteLine("Enter 1 to assign duty to student");
                Console.WriteLine("Enter 2 to view duties to students");
                Console.WriteLine("Enter 3 to delete duty to student");
                Console.WriteLine("Enter 4 to update duty to student");
                Console.WriteLine("Enter 5 to view duty to student");
                Console.WriteLine("Enter 0 to go back to the main menu");

            }
        }
    }
    
}