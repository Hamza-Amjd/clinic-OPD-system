using DAL.Interface;
using DAL.Models;
using GlobalEntity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using GE = GlobalEntity;


namespace DAL
{   
    public class PatientsDA:IPatientsDA
    {
        private readonly MedeaseDbContext medeaseDbContext;

        public PatientsDA(MedeaseDbContext medeaseDbContext)
        {
            this.medeaseDbContext= medeaseDbContext;
        }


        public async Task<List<GE::Patient>> GetPatients()
        {
            var _data = await this.medeaseDbContext.Patients.ToListAsync();
            List<GE::Patient> patients = new List<GE::Patient>();
            if(_data !=null && _data.Count > 0)
            {
                _data.ForEach(item =>
                {
                    patients.Add(new GE.Patient()
                    {
                        PatientId = item.PatientId,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        ContactNo = item.ContactNo,
                        DateOfBirth = item.DateOfBirth,
                        Gender = item.Gender,
                    });
                });
            }
            return patients;
        }

        public async Task<GE::Patient> GetPatientbyID(int PatientId)
        {
            var _data = await this.medeaseDbContext.Patients.FirstOrDefaultAsync(item=>item.PatientId==PatientId);
            GE::Patient patient = new GE.Patient();
            if (_data != null)
            {
                
                    patient=(new GE.Patient()
                    {
                        PatientId = _data.PatientId,
                        FirstName = _data.FirstName,
                        LastName = _data.LastName,
                        ContactNo = _data.ContactNo,
                        DateOfBirth = _data.DateOfBirth,
                        Gender = _data.Gender,
                    });
                
            }
            return patient;
        }

        public async Task<string> Save(GE::Patient patient)
        {
            string Response = string.Empty;
            try
            {
                if (patient.PatientId > 0)
                {   var _exist= await this.medeaseDbContext.Patients.FirstOrDefaultAsync(item => item.PatientId == patient.PatientId);
                    if (_exist != null)
                    {
                    _exist.FirstName = patient.FirstName;
                    _exist.LastName = patient.LastName;
                    _exist.ContactNo = patient.ContactNo;
                    _exist.DateOfBirth = patient.DateOfBirth;
                   _exist.Gender = patient.Gender;
                    }

                }
                
                else
                {
                    Models.Patient _patient = new Models.Patient()
                    {
                        FirstName = patient.FirstName,
                        LastName = patient.LastName,
                        ContactNo = patient.ContactNo,
                        DateOfBirth = patient.DateOfBirth,
                        Gender = patient.Gender,
                    }; 
                await this.medeaseDbContext.Patients.AddAsync(_patient);
                }
                

                await this.medeaseDbContext.SaveChangesAsync();
                Response = "pass";

            }
            catch(Exception ex) {
                Response = ex.Message;
            }
            return Response;
        }

        public async Task<string> RemovePatient(int PatientId)
        {
            var _data = await this.medeaseDbContext.Patients.FirstOrDefaultAsync(item => item.PatientId == PatientId);
            string Response = string.Empty;
            if (_data != null)
            {
                try
                {
                    this.medeaseDbContext.Patients.Remove(_data);
                    await this.medeaseDbContext.SaveChangesAsync();
                    Response = "pass";
                }
                catch (Exception ex)
                {
                    Response = ex.Message;
                }

            }
            return Response;
        }
    }

}
