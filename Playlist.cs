using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Prático
{
    internal class Playlist
    {
        List<Media> musicas;
        //List<Utilizador> utilizadores;
        public string nomePlaylist;

        public Playlist(string nome)
        {
            this.nomePlaylist = nome;
            musicas = new List<Media>();
            //utilizadores = new List<Utilizador>();
        }

        public void AdicionarMedia(Media media)
        {
            musicas.Add(media);
        }

        public void RemoverMedia(string nomeMediaAEliminar)
        {
            if (ProcurarMedia(nomeMediaAEliminar) != null)
            {
                musicas.Remove(ProcurarMedia(nomeMediaAEliminar));
               // Console.WriteLine("Eliminado com sucesso");
            }
            //else
            //{
            //    Console.WriteLine("Nenhuma media encontrada");
            //}
        }
        public Media ProcurarMedia(string nomeMedia)
        {
            foreach (var item in musicas)
            {
                if (item.Titulo.Equals(nomeMedia))
                    return item;
            }
            return null;
        }

        public void MostarPLaylist()
        {
            foreach (var item in musicas)
            {
                Console.WriteLine($"Titulo: {item.Titulo}, Artista: {item.retornarArtista.Nome}\n");
            }
        }

    }
}

