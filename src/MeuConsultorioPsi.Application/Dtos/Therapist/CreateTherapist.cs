using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MeuConsultorioPsi.Application.Dtos.Therapist;

public class CreateTherapist
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(200, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 200 caracteres")]
    public string Name { get; set; }
    [Required(ErrorMessage = "O número de registro do profissional é obrigatório")]
    public string LicenseNumber { get; set; }
}
