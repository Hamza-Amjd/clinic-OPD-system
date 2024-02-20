using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public string Description { get; set; } = null!;

    public long ContactNumber { get; set; }
}
