using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Domain.Models.People
{
    public interface Receptionist : IEmpRole
    {
        public void setAnnouncement(string announcement);
    }
}
