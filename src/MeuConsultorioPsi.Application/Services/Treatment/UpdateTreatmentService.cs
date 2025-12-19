using MeuConsultorioPsi.Application.Dtos.Treatment;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeuConsultorioPsi.Application.Services.Treatment;

public class UpdateTreatmentService
{
    private readonly AppDbContext _context;

    public UpdateTreatmentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ReadTreatment> ExecuteAsync(Guid id, UpdateTreatment dto)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id), "O ID do tratamento é obrigatório e deve ser válido");
        }

        var treatment = await _context.Treatments.FirstOrDefaultAsync(t => t.Id == id);

        if ( treatment is null)
        {
            throw new KeyNotFoundException($"Nenhum tratamento encontrado com o ID: {id}");
        }

        treatment.Update(dto.TherapistId, dto.PatientId, dto.StartDate, dto.EndDate, dto.IsActive);

        await _context.SaveChangesAsync();

        return new ReadTreatment
        {
            Id = treatment.Id,
            TherapistId = treatment.TherapistId,
            PatientId = treatment.PatientId,
            StartDate = treatment.StartDate,
            EndDate = treatment.EndDate,
            IsActive = treatment.IsActive
        };
    }
}
