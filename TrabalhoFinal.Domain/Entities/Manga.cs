namespace TrabalhoFinal.Domain.Entities;

public class Manga
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public int Volumes { get; set; }
    public int AnoPublicacao { get; set; }
    public bool EmAndamento { get; set; }
    public decimal Preco { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    
    // Chave estrangeira explícita (requisito obrigatório)
    public int EditoraId { get; set; }
    
    // Navegação para a editora
    public Editora Editora { get; set; } = null!;
}
