using System;

namespace MeuConsultorioPsi.Application.Dtos.Patient;

public class ReadPatient
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
}
