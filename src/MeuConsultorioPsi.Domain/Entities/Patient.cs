using System;

namespace MeuConsultorioPsi.Domain.Entities;

public class Patient
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }

    protected Patient() { }
}
