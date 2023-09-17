using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Repository.Contracts;

namespace DutiesAllocationApp.Repository
{
    public class DutyAssignmentRepository : IDutyAssignmentRepository
    {
        public List<DutyAssignment> dutyAssignments = new List<DutyAssignment>();
        
        public DutyAssignment Create(DutyAssignment request)
        {
            int id = dutyAssignments.Count != 0 ? dutyAssignments[dutyAssignments.Count - 1].DutyId + 1 : 1;
            var dutyAssignment = new DutyAssignment
            {
                DutyId = id,
                StudentCode = request.StudentCode,
                DutyName = request.StudentName
            };
            return dutyAssignment;
        }
        public IEnumerable<DutyAssignment> GetAllDutyAssignments(string dutyName)
        {
            return dutyAssignments.Where(a => a.DutyName == dutyName);
        }

        public List<DutyAssignment> GetDutyAssignments()
        {
            return dutyAssignments;
        }

        public DutyAssignment FindById(int id)
        {
           
            return dutyAssignments.Find(i => i.DutyId == id)!;
            
        }

        public DutyAssignment GetDutyAssignmentByStudentCode(string code)
        {
            return dutyAssignments.Find(i => i.StudentCode == code)!;    
        }

        
    }
}
