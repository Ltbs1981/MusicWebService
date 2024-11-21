using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicWebService.Modelos
{
    internal class MusicasPreferidas
    {
        public string? Nome { get; set; }
        public List<Musica> ListaDeMusicasFavoritas { get; }

        public MusicasPreferidas(string nome)
        {

            Nome = nome;
            ListaDeMusicasFavoritas = new List<Musica>();
        }

        public void AdicionarMusicasFavoritas(Musica musica)
        {
            ListaDeMusicasFavoritas.Add(musica);
        }

        public void ExibirMusicasFavoritas()
        {
            Console.WriteLine($"Essas são as músicas favoritas -> {Nome}");
            foreach (var musica in ListaDeMusicasFavoritas)
            {
                Console.WriteLine($"- {musica.Nome} de {musica.Artista}");
            }
            Console.WriteLine();
        }

        public void GerarArquivoJson()
        {
            string json = JsonSerializer.Serialize(new
            {
                nome = Nome,
                musicas = ListaDeMusicasFavoritas
            });
            string nomeDoArquivo = $"musicas-favoritas-{Nome}.json";

            File.WriteAllText(nomeDoArquivo, json);
            Console.WriteLine($"O arquivo Json foi criado com sucesso! {Path.GetFullPath(nomeDoArquivo)}");
        }
        public void GerarDocumentoTXTComAsMusicasFavoritas()
        {
            string nomeDoArquivo = $"musicas-favoritas-{Nome}.txt";
            using (StreamWriter arquivo = new StreamWriter(nomeDoArquivo))
            {
                arquivo.WriteLine($"Músicas favoritas do {Nome}\n");
                foreach (var musica in ListaDeMusicasFavoritas)
                {
                    arquivo.WriteLine($"- {musica.Nome} de: {musica.Artista}");
                }
            }
            Console.WriteLine("txt gerado com sucesso!");
        }
    }
}