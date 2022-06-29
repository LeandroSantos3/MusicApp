namespace Trabalho_Prático
{
    internal class Utilizador
    {
        static protected Playlist playlist =  new Playlist("Default");
        List<Registo> registos;
        public List<Playlist> playlists;
        public static int proximo = 1;
        public string Nome { get; set; }
        public int Pass { get; set; }
        public int id;

        public Utilizador()
        {
            this.id = proximo++;
            registos = new List<Registo>();           
            playlists = new List<Playlist>();
        }
    }

    internal class Regular : Utilizador
    {
        public Regular(string nome)
        {
            this.Nome = nome;
        }
    }

    internal class Premium : Utilizador
    {

        public Premium(string nome, int pass)
        {
            this.Nome = nome;
            this.Pass = pass;
        }

        public void CriarPlaylist(Playlist playlist)
        {
            playlists.Add(playlist);
            Console.WriteLine("Playlist privada - " + playlist.nomePlaylist + " - criada com sucesso");
        }

        public void EliminarPlaylist(string nomeP)
        {

            if (playlists.Remove(ProcurarPlalistPrivada(nomeP)) == true)
            {
                playlist = null;
                Console.WriteLine("Eliminado com sucesso");
            }

        }
        public void EliminarMediaDePLaylist(Playlist playlist, Media media)
        {
            playlist.RemoverMedia(media.Titulo);
            Console.WriteLine("Eliminado com sucesso");
            
        }

        public void AdicionarMediaAPlaylist(Musica media, Playlist playlist, Premium user)
        {
            foreach (var item in playlists)
            {
                if (item.nomePlaylist.Equals(playlist.nomePlaylist))
                {
                    user.AdicioanarListaPrivada(media, playlist);
                }
            }
        }

        public void VerPLaylistCriada(Playlist playlist) //extra
        {
            if (playlists == null)
                Console.WriteLine("Impossivel saber, playlist não existe ou foi eliminada");
            else
                playlist.MostarPLaylist();
        }

        public void AdicioanarListaPrivada(Musica media, Playlist playlist) //extra
        {
            playlist.AdicionarMedia(media); // aqui vai pra a lista generica
            Console.WriteLine("Adicioando com sucesso");
        }

        public Playlist ProcurarPlalistPrivada(string nome) //extra
        {            
            foreach (var item in playlists)
            {
               if (item.nomePlaylist.Equals(nome))
                    return item;                                    
            }
            Console.WriteLine("Nao existe nada com esse nome");
            return null;
        }

        
    }
}


