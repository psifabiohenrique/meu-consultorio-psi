using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuConsultorioPsi.Application.Dtos.Therapist;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MeuConsultorioPsi.Application.Services.Therapist;

public class ReadAllTherapistsService
{
    private readonly AppDbContext _context;

    public ReadAllTherapistsService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ReadTherapist>> ExecuteAsync(int? pageNumber = null, int? pageSize = null)
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

        IQueryable<Domain.Entities.Therapist> query = _context.Therapists;

        if (pageNumber.HasValue && pageSize.HasValue)
        {
            int skip = (pageNumber.Value - 1) * pageSize.Value;
            query = query.Skip(skip).Take(pageSize.Value);
        }

        var result = await query
            .Select(t => new ReadTherapist
            {
                Id = t.Id,
                Name = t.Name,
                LicenseNumber = t.LicenseNumber
            })
            .ToListAsync();

        return result;
    }
}
