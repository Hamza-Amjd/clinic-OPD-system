using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GE = GlobalEntity;

namespace BLL.Interface
{
    public interface IPatientBC
    {
       Task<List<GE::Patient>> GetPatients();

        Task<GE::Patient> GetPatientbyID(int PatientID);

        Task<string> Save(GE::Patient patient);

        Task<string> RemovePatient(int PatientID);
    }
}
