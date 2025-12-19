using System.ComponentModel.DataAnnotations;

namespace MeuConsultorioPsi.Application.Dtos.Therapist;

public class UpdateTherapist
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(200, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 200 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O número de registro do profissional é obrigatório")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "O número de registro deve ter até 50 caracteres")]
    public string LicenseNumber { get; set; }
}
