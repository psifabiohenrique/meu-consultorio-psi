using System.ComponentModel.DataAnnotations;

namespace MeuConsultorioPsi.Application.Dtos.Patient;

public class UpdatePatient
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(200, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 200 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A data de nascimento é obrigatória")]
    [DataType(DataType.Date, ErrorMessage = "Data de nascimento inválida")]
    public DateTime BirthDate { get; set; }
}
