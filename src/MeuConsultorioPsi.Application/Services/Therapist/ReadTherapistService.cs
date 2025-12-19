using System;
using System.Threading.Tasks;
using MeuConsultorioPsi.Application.Dtos.Therapist;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MeuConsultorioPsi.Application.Services.Therapist;

public class ReadTherapistService
{
    private readonly AppDbContext _context;

    public ReadTherapistService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ReadTherapist> ExecuteAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("O ID do terapeuta é obrigatório", nameof(id));
        }

        var therapist = await _context.Therapists
            .FirstOrDefaultAsync(t => t.Id == id);

        if (therapist == null)
        {
            throw new KeyNotFoundException(
                $"Nenhum terapeuta encontrado com o ID: {id}");
        }

        return new ReadTherapist
        {
            Id = therapist.Id,
            Name = therapist.Name,
            LicenseNumber = therapist.LicenseNumber
        };
    }
}
