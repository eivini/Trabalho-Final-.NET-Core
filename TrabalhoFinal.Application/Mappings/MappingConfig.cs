using Mapster;
using TrabalhoFinal.Application.ViewModels;
using TrabalhoFinal.Domain.Entities;

namespace TrabalhoFinal.Application.Mappings;

public static class MappingConfig
{
    public static void RegisterMappings()
    {
        // Editora -> EditoraViewModel
        TypeAdapterConfig<Editora, EditoraViewModel>
            .NewConfig()
            .Map(dest => dest.QuantidadeMangas, src => src.Mangas.Count);

        // EditoraViewModel -> Editora
        TypeAdapterConfig<EditoraViewModel, Editora>
            .NewConfig()
            .Ignore(dest => dest.Mangas);

        // Manga -> MangaViewModel
        TypeAdapterConfig<Manga, MangaViewModel>
            .NewConfig()
            .Map(dest => dest.EditoraNome, src => src.Editora.Nome);

        // MangaViewModel -> Manga
        TypeAdapterConfig<MangaViewModel, Manga>
            .NewConfig()
            .Map(dest => dest.EmAndamento, src => src.EmAndamento)
            .Ignore(dest => dest.Editora);
    }
}
