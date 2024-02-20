using Microsoft.AspNetCore.Mvc;
using BLL;
using GE = GlobalEntity;
using BLL.Interface;

namespace clinic_OPD_system.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientBC patientBC;

        public PatientsController(IPatientBC patientBC)
        {
            this.patientBC = patientBC;
        }

        public async Task<IActionResult> Index()
        {
            List<GE::Patient> patients = await this.patientBC.GetPatients();
            return View(patients);
        }

        public IActionResult Create()
        {
            return View(new GE.Patient());
        }

        public async Task<IActionResult> Edit(string PatientID)
        {
            GE::Patient patients = await this.patientBC.GetPatientbyID(Convert.ToInt32(PatientID));
            return View("Create",patients);
        }
        public async Task<IActionResult> Save(GE::Patient patient) {
            string Response= await this.patientBC.Save(patient);
            return Json(Response);
        }
        public async Task<IActionResult> Remove(string PatientID)
        {
            string Response  = await this.patientBC.RemovePatient(Convert.ToInt32(PatientID));
            return Json(Response);
        }
    }
}
