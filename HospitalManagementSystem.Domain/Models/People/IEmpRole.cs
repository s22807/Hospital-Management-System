using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Domain.Models.People
{
    public interface IEmpRole
    {
        public enum Role
        {
            Trainee,
            Receptionist,
            Admin,
            Doctor
        }

        public bool hasRole(string role);
        public void setRole(string role);
    }
}
