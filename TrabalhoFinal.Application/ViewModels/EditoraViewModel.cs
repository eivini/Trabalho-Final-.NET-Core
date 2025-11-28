using System.ComponentModel.DataAnnotations;
using TrabalhoFinal.Domain.Validations;

namespace TrabalhoFinal.Application.ViewModels;

public class EditoraViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome da editora é obrigatório")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O país é obrigatório")]
    [StringLength(50, ErrorMessage = "O país deve ter no máximo 50 caracteres")]
    public string Pais { get; set; } = string.Empty;

    [Required(ErrorMessage = "O ano de fundação é obrigatório")]
    [Range(1800, 3000, ErrorMessage = "Ano de fundação inválido")]
    [AnoFuturo(ErrorMessage = "O ano de fundação não pode ser no futuro")]
    public int AnoFundacao { get; set; }

    [Required(ErrorMessage = "O site é obrigatório")]
    [StringLength(200, ErrorMessage = "O site deve ter no máximo 200 caracteres")]
    public string Site { get; set; } = string.Empty;

    public DateTime DataCriacao { get; set; }
    
    // Para exibição na lista
    public int QuantidadeMangas { get; set; }
}
