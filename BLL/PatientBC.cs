using BLL.Interface;
using DAL;
using DAL.Interface;
using GE = GlobalEntity;

namespace BLL
{
    public class PatientBC : IPatientBC
    {
        private readonly IPatientsDA patientsDA;

        public PatientBC(IPatientsDA patients)
        {
            this.patientsDA = patients;
        }
        public async  Task<List<GE::Patient>> GetPatients()
        {
            return await this.patientsDA.GetPatients();
        }

        public async Task<GE::Patient> GetPatientbyID(int PatientID)
        {
            return await this.patientsDA.GetPatientbyID(PatientID);
        }
        public async Task<string> Save(GE::Patient patient)
        {
            return await this.patientsDA.Save(patient);
        }

        public async Task<string> RemovePatient(int PatientID)
        {
            return await this.patientsDA.RemovePatient(PatientID);
        }
    }
}
