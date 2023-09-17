using DutiesAllocationApp.Entities;

namespace DutiesAllocationApp.Repository.Contracts
{
    public interface IDutyAssignmentRepository
    {
        DutyAssignment Create(DutyAssignment request);
        DutyAssignment FindById(int id); 
        List<DutyAssignment> GetDutyAssignments();
        DutyAssignment GetDutyAssignmentByStudentCode(string code);
        IEnumerable<DutyAssignment> GetAllDutyAssignments(string dutyName);

    }
}
