using System;
using System.Threading.Tasks;
using MeuConsultorioPsi.Application.Dtos.Therapist;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MeuConsultorioPsi.Application.Services.Therapist;

/// <summary>
/// Serviço responsável por atualizar um terapeuta existente.
/// 
/// Responsabilidades:
/// - Receber o ID do terapeuta e DTO com dados atualizados
/// - Validar se o terapeuta existe
/// - Validar regras de negócio (ex.: licença única)
/// - Atualizar as propriedades usando método Update() da entidade
/// - Persistir no banco de dados
/// - Retornar o DTO atualizado
/// 
/// Padrão: Aplicação de Service Pattern + Separation of Concerns
/// </summary>
public class UpdateTherapistService
{
    /// <summary>
    /// Injeção de dependência do contexto do banco de dados.
    /// </summary>
    private readonly AppDbContext _context;

    /// <summary>
    /// Construtor que recebe o contexto do banco via injeção de dependência.
    /// </summary>
    /// <param name="context">Contexto do Entity Framework Core</param>
    public UpdateTherapistService(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Atualiza um terapeuta existente.
    /// 
    /// Fluxo:
    /// 1. Valida o ID
    /// 2. Busca o terapeuta no banco
    /// 3. Valida se existe (KeyNotFoundException)
    /// 4. Valida se o novo número de licença é único (se foi alterado)
    /// 5. Chama método Update() na entidade para atualizar propriedades
    /// 6. Persiste as mudanças no banco
    /// 7. Retorna o DTO com os dados atualizados
    /// </summary>
    /// <param name="id">ID do terapeuta a ser atualizado</param>
    /// <param name="dto">DTO contendo os novos dados (Nome, Número de Licença)</param>
    /// <returns>DTO com os dados atualizados do terapeuta</returns>
    /// <exception cref="ArgumentException">Lançada se o ID é vazio</exception>
    /// <exception cref="KeyNotFoundException">Lançada se o terapeuta não é encontrado</exception>
    /// <exception cref="InvalidOperationException">Lançada se o número de licença já existe em outro terapeuta</exception>
    public async Task<ReadTherapist> ExecuteAsync(Guid id, UpdateTherapist dto)
    {
        // PASSO 1: Validação - verificar se o ID é válido
        if (id == Guid.Empty)
        {
            throw new ArgumentException("O ID do terapeuta é obrigatório", nameof(id));
        }

        // PASSO 2: Buscar o terapeuta no banco
        var therapist = await _context.Therapists
            .FirstOrDefaultAsync(t => t.Id == id);

        // PASSO 3: Verificar se foi encontrado
        if (therapist == null)
        {
            throw new KeyNotFoundException(
                $"Nenhum terapeuta encontrado com o ID: {id}");
        }

        // PASSO 4: Validar unicidade da licença
        // Se o número de licença foi alterado, verifica se já existe outro terapeuta com esse número
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

        // PASSO 5: Atualizar as propriedades usando método Update() da entidade
        // O método Update() valida e atualiza Name e LicenseNumber, mantendo o ID original
        therapist.Update(dto.Name, dto.LicenseNumber);

        // PASSO 6: Persistir as mudanças no banco
        // Como a entidade já foi rastreada pelo EF Core (buscada com FirstOrDefaultAsync),
        // apenas chamar SaveChangesAsync() é suficiente
        await _context.SaveChangesAsync();

        // PASSO 7: Retornar DTO atualizado
        return new ReadTherapist
        {
            Id = therapist.Id,
            Name = therapist.Name,
            LicenseNumber = therapist.LicenseNumber
        };
    }
}
