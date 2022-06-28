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
            //playlist = new Playlist("Default"); *** Cuidado, pois estava a criar sema logo de novo e passariam a ser independentes de cada um...
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

            if (playlists.Remove(ProcurarPlalistPrivada(nomeP)) == true)
            {
                playlist = null;
                Console.WriteLine("Eliminado com sucesso");
            }

        }
        public void EliminarMediaDePLaylist(Playlist playlist, Media media)
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

            //playlist.RemoverMedia(mediaM);
            // user.ProcurarMediaInPlaylistPrivada(mediaM, playlist);
            playlist.RemoverMedia(media.Titulo);
            Console.WriteLine("Eliminado com sucesso?");
            playlist.MostarPLaylist();
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

        public void EliminarMediaDePLaylist()
        {

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
                //else // está errado prq dará um loop de erros
                    
            }
            Console.WriteLine("Nao existe nada com esse nome");
            return null;
        }

        //public Media ProcurarMediaInPlaylistPrivada(string nome, Playlist playlist)
        //{
        //    foreach (var item in ProcurarPlalistPrivada(nome)
        //    {
        //        if (item.ProcurarMedia(nome).Titulo.Equals(nome))
        //        {
        //            return item.ProcurarMedia(nome);
        //        }
        //    }
        //    return null;

        //}
    }
}


//public Musica ProcurarMusicaListaPrivada(string nomeMusica)
//{

//}



//public void ClassificarMedia() { }

//public void ObterEstatistica() { }




//public void MostrarItens(Playlist playlist)
//{
//    Console.WriteLine($"Os dados da musica:");
//    Console.WriteLine($"Nome: {playlist.nomePlaylist}");
//    playlist.MostarPLaylist();

//}



