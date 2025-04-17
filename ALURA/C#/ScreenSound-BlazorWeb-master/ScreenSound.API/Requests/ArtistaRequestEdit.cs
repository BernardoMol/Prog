namespace ScreenSound.API.Requests;

// public record ArtistaRequestEdit(int Id,string nome,string bio)
//     : ArtistaRequest(nome,bio);

public record ArtistaRequestEdit(int Id, string nome, string bio, string? fotoPerfil)
    : ArtistaRequest(nome, bio,fotoPerfil);