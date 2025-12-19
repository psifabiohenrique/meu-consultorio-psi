using System;
using System.Threading.Tasks;
using MeuConsultorioPsi.Application.Dtos.Therapist;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MeuConsultorioPsi.Application.Services.Therapist;

public class CreateTherapistService
{

    private readonly AppDbContext _context;

    public CreateTherapistService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ReadTherapist> ExecuteAsync(CreateTherapist dto)
    {
        var licenseAlreadyExists = await _context.Therapists
            .AnyAsync(t => t.LicenseNumber == dto.LicenseNumber);

        if (licenseAlreadyExists)
        {
            throw new InvalidOperationException(
                $"Já existe um terapeuta cadastrado com o número de licença: {dto.LicenseNumber}");
        }

        var therapist = Domain.Entities.Therapist.Create(dto.Name, dto.LicenseNumber);

        await _context.Therapists.AddAsync(therapist);

        await _context.SaveChangesAsync();

        return new ReadTherapist
        {
            Id = therapist.Id,
            Name = therapist.Name,
            LicenseNumber = therapist.LicenseNumber
        };
    }
}
