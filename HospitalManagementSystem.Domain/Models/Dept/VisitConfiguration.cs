namespace HospitalManagementSystem.Domain.Models.Department
{
    public static class VisitConfiguration
    {
        public static readonly double VisitCost = 999;
    }
}

/*
 * 
 * Configuration.OwnsOne(x => x.VisitConfiguration)
 * 
 * Configuration
 *  => VisitConfiguration
 *      => VisitCost
 *  => DoctorConfiguration
 *      => MaxAge
 *
*/