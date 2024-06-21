using HospitalManagementSystem.Domain.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Models
{
    public class TagDTO
    {
        public TagDTO(Tag e)
        {
            Id = e.Id;
            Name = e.Name;
        }
        public TagDTO(string name) { 
            Name = name;
        }
        public TagDTO() { }

        public Guid? Id { get; set; }
        public string Name { get; set; }
    }
}
