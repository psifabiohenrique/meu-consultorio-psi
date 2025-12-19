using System;
using System.Threading.Tasks;
using MeuConsultorioPsi.Application.Dtos.Therapist;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MeuConsultorioPsi.Application.Services.Therapist;

public class UpdateTherapistService
{

    private readonly AppDbContext _context;

    public UpdateTherapistService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ReadTherapist> ExecuteAsync(Guid id, UpdateTherapist dto)
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

        if (therapist.LicenseNumber != dto.LicenseNumber)
        {
            var licenseAlreadyExists = await _context.Therapists
                .AnyAsync(t => t.LicenseNumber == dto.LicenseNumber && t.Id != id);

            if (licenseAlreadyExists)
            {
                throw new InvalidOperationException(
                    $"Já existe um terapeuta cadastrado com o número de licença: {dto.LicenseNumber}");
            }
        }

        therapist.Update(dto.Name, dto.LicenseNumber);


        await _context.SaveChangesAsync();

        return new ReadTherapist
        {
            Id = therapist.Id,
            Name = therapist.Name,
            LicenseNumber = therapist.LicenseNumber
        };
    }
}
