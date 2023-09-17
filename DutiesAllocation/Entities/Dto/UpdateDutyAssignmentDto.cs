using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutiesAllocationApp.Entities.Dto
{
    public record UpdateDutyAssignmentDto
    {
        public string StudentCode { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string DutyName { get; set; } = string.Empty;
    }
}
