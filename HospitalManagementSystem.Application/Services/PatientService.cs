using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Domain.Models.People;

namespace HospitalManagementSystem.Application.Services
{
    public interface IPatientService
    {
        Task CreatePatientAsync(CreatePatientDTO patient);
        Task<PatientDetailsDTO?> GetPatientDetailsAsync(Guid patientId);
        Task<IEnumerable<PatientDTO>> GetPatientsAsync();
        Task RemovePatientAsync(Guid patientId);
        Task DeletePatientAsync(Guid patientId);
        void UpdatePatientAsync(Guid patientId, PatientDetailsDTO patient);
        //Task UpdatePatientAsync(Guid patientId, PatientEditDTO patient);
    }

    internal class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
            => _patientRepository = patientRepository;

        public async Task CreatePatientAsync(CreatePatientDTO patientDTO)
        {
            var patient = new Patient(patientDTO.FirstName, patientDTO.LastName, patientDTO.Pesel, patientDTO.BirthDate, patientDTO.Sex, patientDTO.Insured, patientDTO.MothersName, patientDTO.FathersName);
            await _patientRepository.AddAsync(patient);
        }

        public async Task DeletePatientAsync(Guid patientId)
        {
            await _patientRepository.Delete(patientId);
        }

        public async Task<PatientDetailsDTO?> GetPatientDetailsAsync(Guid patientId)
        {
            var p = await _patientRepository.GetAsync(patientId);
            if (p == null)
                return null;
            return new PatientDetailsDTO(p);
        }

        public async Task<IEnumerable<PatientDTO>> GetPatientsAsync()
        {
            var patients = await _patientRepository.GetPatientsAsync();
            return patients.Select(x => new PatientDTO(x));
        }

        public async Task RemovePatientAsync(Guid patientId)
        {
            await _patientRepository.Remove(patientId);
        }

        public async Task UpdatePatientAsync(Guid patientId, PatientDetailsDTO patient)
        {
            var p = await _patientRepository.GetAsync(patientId);
            
        }

        void IPatientService.UpdatePatientAsync(Guid patientId, PatientDetailsDTO patient)
        {
            throw new NotImplementedException();
        }

        //public Task UpdatePatientAsync(Guid patientId, PatientEditDTO patient)
        //{
        //    throw new NotImplementedException();
        //}
    }
}