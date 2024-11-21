using MusicWebService.Filtros;
using MusicWebService.Modelos;
using System.Text.Json;

using (HttpClient client = new HttpClient())
{
    try
    {
        // Requisição para obter os dados JSON de músicas
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

        // Filtro de músicas em C#
        //LinqFilter.FiltrarMusicasEmCSharp(musicas);
        //musicas[1].ExibirDetalhesDaMusica();
        //LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
        //LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
        //LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "rock");
        //LinqFilter.FiltrarMusicasDeUmArtista(musicas, "U2");

        // Instância de músicas favoritas de Isabela
        var musicaDaBela = new MusicasPreferidas("Isabela");
        musicaDaBela.AdicionarMusicasFavoritas(musicas[980]);
        musicaDaBela.AdicionarMusicasFavoritas(musicas[513]);
        musicaDaBela.AdicionarMusicasFavoritas(musicas[1000]);
        musicaDaBela.AdicionarMusicasFavoritas(musicas[999]);
        musicaDaBela.AdicionarMusicasFavoritas(musicas[37]);
        musicaDaBela.AdicionarMusicasFavoritas(musicas[1024]);
        musicaDaBela.AdicionarMusicasFavoritas(musicas[888]);
        musicaDaBela.AdicionarMusicasFavoritas(musicas[33]);

        // Gera um documento TXT com as músicas favoritas
        musicaDaBela.GerarDocumentoTXTComAsMusicasFavoritas();

        // Gera um arquivo JSON com as músicas favoritas
         //musicaDaBela.GerarArquivoJson();

        // Outras instâncias comentadas para estudo:
        
        //var musicasPreferidasDoDaniel = new MusicasPreferidas("Daniel");
        //musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[1]);
        //musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[377]);
        //musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[4]);
        //musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[6]);
        //musicasPreferidasDoDaniel.AdicionarMusicasFavoritas(musicas[1467]);

        //var musicasPreferidasEmilly = new MusicasPreferidas("Emilly");
        //musicasPreferidasEmilly.AdicionarMusicasFavoritas(musicas[500]);
        //musicasPreferidasEmilly.AdicionarMusicasFavoritas(musicas[637]);
        //musicasPreferidasEmilly.AdicionarMusicasFavoritas(musicas[428]);
        //musicasPreferidasEmilly.AdicionarMusicasFavoritas(musicas[13]);
        //musicasPreferidasEmilly.AdicionarMusicasFavoritas(musicas[71]);

        //musicasPreferidasEmilly.ExibirMusicasFavoritas();
        
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}
