using System;

namespace MeuConsultorioPsi.Domain.Entities;

public class Patient
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }

    protected Patient() { }

    public static Patient Create(string name, DateTime birthDate)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name), "O nome é obrigatório");
        }

        if (birthDate == default)
        {
            throw new ArgumentException("A data de nascimento é obrigatória", nameof(birthDate));
        }

        if (birthDate > DateTime.Now)
        {
            throw new ArgumentException("A data de nascimento não pode ser no futuro", nameof(birthDate));
        }

        return new Patient
        {
            Id = Guid.NewGuid(),
            Name = name,
            BirthDate = birthDate
        };
    }

    public void Update(string name, DateTime birthDate)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name), "É obrigatório enviar um modelo de paciente completo.")
        }
        if (birthDate == default)
        {
            throw new ArgumentException(nameof(birthDate), "A data de nascimento é obrigatório");
        }
        if (birthDate > DateTime.Now)
        {
            throw new ArgumentException(nameof(birthDate), "A data de nascimento não pode ser no futuro")
        }


        Name = name;
        BirthDate = birthDate;
    }
}
