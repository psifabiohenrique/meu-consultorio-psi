using MeuConsultorioPsi.Application.Dtos.Patient;
using MeuConsultorioPsi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeuConsultorioPsi.Application.Services.Patient;

public class CreatePatientService
{
    private readonly AppDbContext _context;

    public CreatePatientService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ReadPatient> ExecuteAsync(CreatePatient dto)
    {
        var patient = Domain.Entities.Patient.Create(dto.Name, dto.BirthDate);
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();

        return new ReadPatient
        {
            Id = patient.Id,
            Name = patient.Name,
            BirthDate = patient.BirthDate
        };
    }
}
