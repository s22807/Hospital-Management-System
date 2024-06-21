using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Domain.Models.Department
{
    public class Tag
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Tag(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public void SetName(string name) {
            if (!name.IsNullOrEmpty())
                Name = name;
            else throw new ArgumentException("Name cannot be null or empty");
        }
    }
}
