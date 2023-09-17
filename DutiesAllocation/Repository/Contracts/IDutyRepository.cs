using DutiesAllocation.Entities.Dto;
using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Entities.Dto;

namespace DutiesAllocationApp.Repository.Contracts
{
    public interface IDutyRepository
    {
        Duty Create(DutyDto request);
        List<Duty> GetAllDuties();
        Duty FindById(int id);
        Duty FindByName(string name);
    }
}