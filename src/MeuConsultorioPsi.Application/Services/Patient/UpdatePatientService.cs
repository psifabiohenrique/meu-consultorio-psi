using MeuConsultorioPsi.Application.Dtos.Patient;
using MeuConsultorioPsi.Domain.Entities;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeuConsultorioPsi.Application.Services.Patient;

public class UpdatePatientService
{
    public readonly AppDbContext _context;

    public UpdatePatientService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ReadPatient> ExecuteAsync(Guid id, UpdatePatient dto)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("O ID do paciente é obrigatório", nameof(id));
        }

        var patient = await _context.Patients
            .FirstOrDefaultAsync(p => p.Id == id);

        if (patient is null)
        {
            throw new KeyNotFoundException(
                $"Nenhum paciente encontrado com o ID: {id}");
        }

        patient.Update(dto.Name, dto.BirthDate);
        await _context.SaveChangesAsync();

        return new ReadPatient
        {
            Id = id,
            Name = patient.Name,
            BirthDate = patient.BirthDate
        };
    }
}
