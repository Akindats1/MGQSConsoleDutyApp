using DutiesAllocation.Entities.Dto;
using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Entities.Dto;

namespace DutiesAllocationApp.Services.Contracts
{
    public interface IDutyService
    {
        void CreateDuty(DutyDto request);
        void GetAllDuties();
        void UpdateDuty(UpdateDutyDto request);
        void DeleteDuty();
        void ViewDuty();
    }
}
