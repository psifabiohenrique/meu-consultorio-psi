using System;

namespace MeuConsultorioPsi.Domain.Entities;

public class Therapist
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string LicenseNumber { get; private set; }

    protected Therapist() { }

    public static Therapist Create(string name, string licenseNumber)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException("O Nome é obrigatório");
        }
        if (string.IsNullOrWhiteSpace(licenseNumber))
        {
            throw new ArgumentNullException("O número de licença é obrigatório");
        }

        return new Therapist
        {
            Id = Guid.NewGuid(),
            Name = name,
            LicenseNumber = licenseNumber
        };
    }

    public void Update(string name, string licenseNumber)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name), "O Nome é obrigatório");
        }
        if (string.IsNullOrWhiteSpace(licenseNumber))
        {
            throw new ArgumentNullException(nameof(licenseNumber), "O número de licença é obrigatório");
        }

        Name = name;
        LicenseNumber = licenseNumber;
    }
}
