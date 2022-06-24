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
            foreach (var item in musicas)
            {
                if (item.Titulo.Equals(nomeMediaAEliminar)) 
                    musicas.Remove(item);
                Console.WriteLine(item.Titulo+ " Eliminado com sucesso");
            }
        }
    }
}
