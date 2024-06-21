using HospitalManagementSystem.Application.Models;
using HospitalManagementSystem.Application.Repositories;
using HospitalManagementSystem.Domain.Models.People;
using Microsoft.IdentityModel.Tokens;

namespace HospitalManagementSystem.Application.Services
{
    public interface IPatientService
    {
        Task CreatePatientAsync(CreatePatientDTO patient);
        Task<PatientDetailsDTO?> GetPatientDetailsAsync(Guid patientId);
        Task<IEnumerable<PatientDTO>> GetPatientsAsync();
        Task<PatientDTO> GetPatientAsync(Guid patientId);
        Task RemovePatientAsync(Guid patientId);
        Task DeletePatientAsync(Guid patientId);
        Task UpdatePatientAsync(PatientDTO patient);
        Task<IEnumerable<PatientDTO>> GetPatientsAsync(string? firstname, string? lastname, string? pesel);
        Task RegisterAsync(UserDTO userDTO);

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

        public async Task<PatientDTO> GetPatientAsync(Guid patientId)
        {
            var p = await _patientRepository.GetPatientAsync(patientId);
            if (p == null)
                return null;
            return new PatientDTO(p);
        }

        public async Task<PatientDetailsDTO?> GetPatientDetailsAsync(Guid patientId)
        {
            var p = await _patientRepository.GetPatientAsync(patientId);
            if (p == null)
                return null;
            return new PatientDetailsDTO(p);
        }

        public async Task<IEnumerable<PatientDTO>> GetPatientsAsync()
        {
            var patients = await _patientRepository.GetPatientsAsync();
            return patients.Select(x => new PatientDTO(x));
        }

        public async Task<IEnumerable<PatientDTO>> GetPatientsAsync(string? firstname, string? lastname, string? pesel)
        {
            var patients = await _patientRepository.GetPatientsAsync(firstname, lastname, pesel);
            return patients.Select(x => new PatientDTO(x));
        }

        public async Task RegisterAsync(UserDTO userDTO)
        {
            var patient = await _patientRepository.GetPatientAsync((Guid)userDTO.Id);
            patient.Email=userDTO.Email;
            patient.Username=userDTO.Username;
            patient.Password=userDTO.Password;
            await _patientRepository.Update(patient);
            
        }

        public async Task RemovePatientAsync(Guid patientId)
        {
            await _patientRepository.Remove(patientId);
        }

        public async Task UpdatePatientAsync(PatientDTO patient)
        {
            var p = await _patientRepository.GetPatientAsync(patient.Id);
            if (p == null)
            {
                return;
            }
            p.SetFirstname(patient.FirstName);
            p.SetLastname(patient.LastName);
            p.SetPesel(patient.Pesel);
            p.SetBirthDate(patient.Birthdate);
            p.SetMothersName(patient.MothersName);
            p.SetFathersName(patient.FathersName);

            await _patientRepository.Update(p);

        }

        
    }
}