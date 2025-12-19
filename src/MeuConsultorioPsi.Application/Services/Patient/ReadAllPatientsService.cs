using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuConsultorioPsi.Application.Dtos.Patient;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MeuConsultorioPsi.Application.Services.Patient;

public class ReadAllPatientsService
{
    private readonly AppDbContext _context;

    public ReadAllPatientsService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ReadPatient>> ExecuteAsync(int? pageNumber = null, int? pageSize = null)
    {
        if (pageNumber.HasValue || pageSize.HasValue)
        {
            if (!pageNumber.HasValue || !pageSize.HasValue)
            {
                throw new ArgumentException(
                    "Ambos pageNumber e pageSize devem ser fornecidos ou nenhum deles");
            }

            if (pageNumber < 1)
            {
                throw new ArgumentException("O número da página deve ser maior que 0", nameof(pageNumber));
            }

            if (pageSize < 1 || pageSize > 100)
            {
                throw new ArgumentException("O tamanho da página deve estar entre 1 e 100", nameof(pageSize));
            }
        }

        IQueryable<Domain.Entities.Patient> query = _context.Patients.AsQueryable();

        if (pageNumber.HasValue && pageSize.HasValue)
        {
            int skip = (pageNumber.Value - 1) * pageSize.Value;
            query = query.Skip(skip).Take(pageSize.Value);
        }
        List<ReadPatient> patients = await query
            .Select(p => new ReadPatient
            {
                Id = p.Id,
                Name = p.Name,
                BirthDate = p.BirthDate
            })
            .ToListAsync();

        return patients;
    }
    public async Task<IEnumerable<ReadPatient>> ExecuteAsync(Guid therapistId, int? pageNumber = null, int? pageSize = null)
    {
        if (therapistId == Guid.Empty)
        {
            throw new ArgumentException("O ID do terapeuta é obrigatório", nameof(therapistId));
        }

        if (pageNumber.HasValue || pageSize.HasValue)
        {
            if (!pageNumber.HasValue || !pageSize.HasValue)
            {
                throw new ArgumentException(
                    "Ambos pageNumber e pageSize devem ser fornecidos ou nenhum deles");
            }

            if (pageNumber < 1)
            {
                throw new ArgumentException("O número da página deve ser maior que 0", nameof(pageNumber));
            }

            if (pageSize < 1 || pageSize > 100)
            {
                throw new ArgumentException("O tamanho da página deve estar entre 1 e 100", nameof(pageSize));
            }
        }

        List<Guid> patientIds = await _context.Treatments
            .Where(t => t.TherapistId == therapistId)
            .Select(t => t.PatientId)
            .Distinct()
            .ToListAsync();

        IQueryable<Domain.Entities.Patient> query = _context.Patients
            .Where(p => patientIds.Contains(p.Id));

        if (pageNumber.HasValue && pageSize.HasValue)
        {
            int skip = (pageNumber.Value - 1) * pageSize.Value;
            query = query.Skip(skip).Take(pageSize.Value);
        }

        var result = await query
            .Select(p => new ReadPatient
            {
                Id = p.Id,
                Name = p.Name,
                BirthDate = p.BirthDate
            })
            .ToListAsync();

        return result;
    }
}
