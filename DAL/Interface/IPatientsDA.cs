using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GE = GlobalEntity;

namespace DAL.Interface
{
    public interface IPatientsDA
    {
        Task<List<GE::Patient>> GetPatients();

        Task<GE::Patient> GetPatientbyID(int PatientId);

        Task<string> Save(GE::Patient patient);

        Task<string> RemovePatient(int PatientId);
    }
}
