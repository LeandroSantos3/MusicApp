namespace Trabalho_Prático
{
    internal class Playlist
    {
        List<Media> musicas;
        public string nomePlaylist;

        public Playlist(string nome)
        {
            this.nomePlaylist = nome;
            musicas = new List<Media>();
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
            }
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
             Console.WriteLine("total " + musicas.Count());
            foreach (var item in musicas)
            {
                Console.WriteLine($"Titulo: {item.Titulo}, Artista: {item.retornarArtista.Nome}\n");
            }
        }

        public Musica RetornarItemPlaylist()
        {
            foreach (var item in musicas)
            {
                return (Musica)item;
            }
            return null;
        }

        
    }
}

