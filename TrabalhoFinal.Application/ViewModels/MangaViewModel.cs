using System.ComponentModel.DataAnnotations;
using TrabalhoFinal.Domain.Validations;

namespace TrabalhoFinal.Application.ViewModels;

public class MangaViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O título do mangá é obrigatório")]
    [StringLength(150, MinimumLength = 2, ErrorMessage = "O título deve ter entre 2 e 150 caracteres")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "O autor é obrigatório")]
    [StringLength(100, ErrorMessage = "O autor deve ter no máximo 100 caracteres")]
    public string Autor { get; set; } = string.Empty;

    [Required(ErrorMessage = "O gênero é obrigatório")]
    [StringLength(50, ErrorMessage = "O gênero deve ter no máximo 50 caracteres")]
    public string Genero { get; set; } = string.Empty;

    [Required(ErrorMessage = "O número de volumes é obrigatório")]
    [Range(1, 1000, ErrorMessage = "O número de volumes deve estar entre 1 e 1000")]
    public int Volumes { get; set; }

    [Required(ErrorMessage = "O ano de publicação é obrigatório")]
    [Range(1950, 3000, ErrorMessage = "Ano de publicação inválido")]
    [AnoFuturo(ErrorMessage = "O ano de publicação não pode ser no futuro")]
    public int AnoPublicacao { get; set; }

    [Display(Name = "Em Andamento")]
    public bool EmAndamento { get; set; }

    [Required(ErrorMessage = "O preço é obrigatório")]
    [Range(0.01, 10000, ErrorMessage = "O preço deve estar entre R$ 0,01 e R$ 10.000,00")]
    [PrecoMinimo(5.00, ErrorMessage = "O preço mínimo é R$ 5,00")]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "A editora é obrigatória")]
    [Display(Name = "Editora")]
    public int EditoraId { get; set; }

    public DateTime DataCriacao { get; set; }
    
    // Para exibição
    public string? EditoraNome { get; set; }
}
