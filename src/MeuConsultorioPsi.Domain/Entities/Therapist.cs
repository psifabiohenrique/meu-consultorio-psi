using System;

namespace MeuConsultorioPsi.Domain.Entities;

public class Therapist
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string LicenseNumber { get; private set; }

    protected Therapist() {}
}
