using HospitalManagementSystem.Domain.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Models
{
    public class PersonDTO
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Pesel { get; private set; }

        public DateTime BirthDate { get; protected set; }

        public bool Sex { get; set; }
        
        public PersonDTO(Person p)
        {
            FirstName = p.FirstName;
            LastName = p.LastName;
            Pesel = p.Pesel;
            BirthDate = p.BirthDate;
        }
    }
}
