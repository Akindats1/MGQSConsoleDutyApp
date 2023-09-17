using ConsoleTables;
using DutiesAllocation.Entities.Dto;
using DutiesAllocation.Repository;
using DutiesAllocationApp.Constants;
using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Entities.Dto;
using DutiesAllocationApp.Services.Contracts;

namespace DutiesAllocationApp.Services
{
    public class DutyService : IDutyService
    {
        private readonly DutyRepository _dutyRepository;

        public DutyService(DutyRepository dutyRepository)
        {
            _dutyRepository = dutyRepository;
        }

        public void CreateDuty(DutyDto request)
        {
            try
            {

                Console.Write("Enter duty name: ");
                request.DutyName = Console.ReadLine()!.Trim()!;

                Console.Write("Enter duty description (optional): ");
                request.Description = Console.ReadLine();

                var findDuty = _dutyRepository.FindByName(request.DutyName);

                if (findDuty is not null) 
                {
                    Console.WriteLine($"Record with {findDuty.DutyName} already exist!");
                }

                var duty = _dutyRepository.Create(request);

                _dutyRepository.duties.Add(duty);
                Console.WriteLine($"Record with `{request.DutyName}` created successfully");

            }
            catch (Exception ex) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            
        }

        public void DeleteDuty()
        {
            try
            {
                Console.Write("Enter duty Id of duty to delete: ");
                int id = int.Parse(Console.ReadLine()!);
                var duty = _dutyRepository.FindById(id);

                if (duty is not null)
                {
                    _dutyRepository.duties.Remove(duty);
                    Console.WriteLine(Messages.RECORDREMOVED);
                    return;
                }

                Console.WriteLine(Messages.NOTFOUND);

            }
            catch (Exception ex)
            {
                Console.Write($"Something went wrong:{ex.Message}");
            }
        }

        public void GetAllDuties()
        {
            try
            {
                if (_dutyRepository.duties.Count != 0)
                {
                    var table = new ConsoleTable("Id", "Duty Name", "Description");

                    foreach (var duty in _dutyRepository.duties)
                    {
                        table.AddRow(duty.Id, duty.DutyName, duty.Description);
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
        
        public void UpdateDuty(UpdateDutyDto request)
        {
            try
            {
                Console.Write("Enter ID for duty to update record: ");
                int id = int.Parse(Console.ReadLine()!);
                var duty = _dutyRepository.FindById(id);

                if (duty is not null)
                {
                    Console.Write("Enter duty name: ");
                    duty.DutyName = request.DutyName = Console.ReadLine()!;

                    Console.Write("Enter duty description: ");
                    duty.Description = request.Description = Console.ReadLine();

                    Console.WriteLine(Messages.RECORDUPDATED);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ViewDuty()
        {
            Console.Write("Enter duty name to search: ");
            string dutyName = Console.ReadLine()!;

            var duty = _dutyRepository.FindByName(dutyName);

            if (duty is not null)
            {
                PrintDutyDetail(duty);
                return;
            }

            Console.WriteLine(Messages.NOTFOUND);
        }

        private void PrintDutyDetail(Duty duty)
        {
            Console.WriteLine(
                $@"Id: {duty.Id}
                Duty Name: {duty.DutyName}
                Description: {duty.Description}");
        }
    }
}
