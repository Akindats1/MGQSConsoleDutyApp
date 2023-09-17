using DutiesAllocation.Entities.Dto;
using DutiesAllocationApp;
using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Repository.Contracts;

namespace DutiesAllocation.Repository
{
    public class DutyRepository : IDutyRepository
    {
        public List<Duty> duties = new List<Duty>();
        
        public Duty Create(DutyDto request)
        {
            int id = (duties.Count != 0) ? duties[duties.Count - 1].Id + 1 : 1;
            var duty = new Duty
            {
                Id = id,
                DutyName = request.DutyName,
                Description = request.Description
            };
            return duty;
        }
        
        public Duty FindById(int id)
        {
            return duties.Find(i => i.Id == id)!;
        }
        
        public List<Duty> GetAllDuties()
        {
            return duties;
        }
        public Duty FindByName(string name)
        {
            return duties.Find(n => n.DutyName == name)!;
        }


       
        
    }
}