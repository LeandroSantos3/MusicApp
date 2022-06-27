namespace Trabalho_Prático
{
    internal class Utilizador
    {
        public Playlist playlist;
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
            playlist = new Playlist("Default");
            playlists = new List<Playlist>();
            //Console.WriteLine("Utilizador criado1");
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
            //playlist.Elimia = null;
            //if(playlist== null)
            //{
            //    Console.WriteLine("Nulo");
            //}
            //bool res = playlists.Remove(playlist); 
            //if (res)
            //{
            //    this.playlist = null;
            //    Console.WriteLine("Eliminado");
            //    return;
            //}
            //Console.WriteLine("nao eliminado");
            //playlists.Remove(ProcurarPlalistPrivada(nomeP));      testes
            if (playlists.Remove(ProcurarPlalistPrivada(nomeP)) == true)
            {
                playlist = null;
                Console.WriteLine("Eliminado com sucesso");
                //VerPLaylistCriada(nomeP);
            }               
            //else
            //Console.WriteLine("Não foi eliminado");
        }

        public void AdicionarMediaAPlaylist(Musica media, Playlist playlist, Premium user)
        {
            foreach (var item in playlists)
            {

                if (item.nomePlaylist.Equals(playlist.nomePlaylist))
                {
                    user.AdicioanarListaPrivada(media);
                }
            }
        }

        public void EliminarMediaDePLaylist(Playlist playlist, Media media,string mediaM)
        {
            //if(media == null)
            //{
            //    Console.WriteLine("Musica não existe ou já foi eliminado da playlist privada");
            //}
            //else
            //{
            //    media = playlist.ProcurarMedia(mediaM);
            //    if (media != null)
            //    {                       
            //        media = null;
            //        playlist.RemoverMedia(mediaM);                        
            //        Console.WriteLine("Eliminado com sucesso");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Nada encontrado");
            //    }

            //}
            playlist.MostarPLaylist();
            playlist.RemoverMedia(mediaM);
        }

        public void VerPLaylistCriada(string nomeP) //extra
        {
            if (playlist == null)
                Console.WriteLine("Impossivel saber, playlist não existe ou foi eliminada");
            else
                playlist.MostarPLaylist();
        }        

        public void AdicioanarListaPrivada(Musica media)
        {
            playlist.AdicionarMedia(media);
            Console.WriteLine("Adicioando com sucesso");
        }

        public Playlist ProcurarPlalistPrivada(string nome)
        {
            //Console.WriteLine("Nao existe nada com esse nome1");
            foreach (var item in playlists)
            {
                //Console.WriteLine("Nao existe nada com esse nome2");
                if (item.nomePlaylist.Equals(nome))
                    return item;
                else
                    Console.WriteLine("Nao existe nada com esse nome");
            }
            return null;
        }

        //public Musica ProcurarMusicaListaPrivada(string nomeMusica)
        //{
            
        //}



        //public void ClassificarMedia() { }

        //public void ObterEstatistica() { }



    }

}

//public void MostrarItens(Playlist playlist)
//{
//    Console.WriteLine($"Os dados da musica:");
//    Console.WriteLine($"Nome: {playlist.nomePlaylist}");
//    playlist.MostarPLaylist();

//}

