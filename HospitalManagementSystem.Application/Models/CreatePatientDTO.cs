using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Models
{
    public record CreatePatientDTO(string FirstName, string LastName, string Pesel, DateTime BirthDate, bool Sex, string? MothersName, string? FathersName, bool Insured);
}
