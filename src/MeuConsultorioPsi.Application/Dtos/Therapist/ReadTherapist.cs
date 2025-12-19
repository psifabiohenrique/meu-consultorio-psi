using System;
using System.Collections.Generic;
using System.Text;

namespace MeuConsultorioPsi.Application.Dtos.Therapist;

public class ReadTherapist
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LicenseNumber { get; set; }
}
