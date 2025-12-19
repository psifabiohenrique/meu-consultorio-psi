using MeuConsultorioPsi.Application.Dtos.Patient;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeuConsultorioPsi.Application.Services.Patient;

public class ReadPatientService
{
    private readonly AppDbContext _context;

    public ReadPatientService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ReadPatient> ExecuteAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException(
                "O ID do paciente é obrigatório", nameof(id));
        }

        var patient = await _context.Patients
            .FirstOrDefaultAsync(p => p.Id == id);

        if (patient is null)
        {
            throw new KeyNotFoundException(
                $"Nenhum paciente encontrado com o ID: {id}");
        }

        return new ReadPatient
        {
            Id = patient.Id,
            Name = patient.Name,
            BirthDate = patient.BirthDate
        };
    }
}
