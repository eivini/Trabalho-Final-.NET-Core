namespace TrabalhoFinal.Domain.Entities;

public class Editora
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Pais { get; set; } = string.Empty;
    public int AnoFundacao { get; set; }
    public string Site { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    
    // Relacionamento 1:N - Uma editora tem muitos mangás
    public ICollection<Manga> Mangas { get; set; } = new List<Manga>();
}
