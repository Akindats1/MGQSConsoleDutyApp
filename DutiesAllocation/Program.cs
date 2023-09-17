using DutiesAllocation.Repository;
using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Menus;
using DutiesAllocationApp.Repository;
using DutiesAllocationApp.Services;

Console.WriteLine("==================Welcome MGQS Duty App (File Base System)===============");

var studentRepository = new StudentRepository();
var studentService = new StudentService(studentRepository);
var dutyRepository = new DutyRepository();
var dutyService = new DutyService(dutyRepository);
var dutyAssignmentRepository = new DutyAssignmentRepository();
var dutyAssignmentService = new DutyAssignmentService(dutyAssignmentRepository, studentRepository, dutyRepository);
Menu.MainMenu(studentService, dutyService, dutyAssignmentService);