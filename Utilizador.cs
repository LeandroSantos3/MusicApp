using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Prático
{
    internal class Utilizador
    {
        Playlist playlist;        
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
        }                     
           
    }

    internal class Regular : Utilizador
    {
        
        public Regular(string nome)
        {
            this.Nome = nome;
            //Playlist playlist = new Playlist("Default");            
        }
    }

    internal class Premium : Utilizador
    {

        //List<Playlist> playlists;
        public Premium(string nome, int pass)
        {
            this.Nome = nome;
            this.Pass = pass;
            //Playlist playlist = new Playlist("Default");
           //List<Playlist> playlists = new Playlist; //pegar aqui para criar mais playlists
        }

        public void CriarPlaylist() 
        {
            Console.WriteLine("O nome da playlist?");
            string nomePLaylistNova = Console.ReadLine();
            Playlist playlist2 = new Playlist(nomePLaylistNova);
            //playlists = new List<Playlist>(); //pegar aqui para criar mais playlists
            ////    playlists.Add(playlist2);
            CriarColecao(playlist2);
        }
        public void CriarColecao(Playlist playlist)
        {
            playlists.Add(playlist);
            Console.WriteLine("Criado e adicionado com sucesso!");
        }
        public void VerPLaylistCriada(string nome)
        {
            foreach (var item in playlists)
            {
                if (item.nomePlaylist.Equals(nome))
                {
                    Console.WriteLine(playlists.Count()); item.MostarPLaylist();
                }

                else
                    Console.WriteLine("Lista vazia");
            }
        }
        
        public void EliminarPlaylist() { }
        public void AdicionarMediaAPlaylist(Musica media,Playlist playlist)
        {
            //foreach (var item in playlists)
            //{
            //    if (item.nomePlaylist.Equals(playlist.nomePlaylist))
            //    {
            //        playlist.Ad
            //    }
            //    else
            //    {
            //        Console.WriteLine("Não existe nada com esse nome nas playlists privadas");
            //    }
            //}
            playlist.AdicionarMedia(media);
        }

        //public void AdicioanarListaPrivada(Musica media)
        //{
           
        //}

        public Playlist ProcurarPlalistPrivada(string nome)
        {
            foreach (var item in playlists)
            {
                if (item.nomePlaylist.Equals(nome))
                    return item;
                else
                    Console.WriteLine("Nao existe nada com esse nome");
            }return null;
        }
        public void EliminarMediaDePLaylist() { }
        public void ClassificarMedia() { }

        public void ObterEstatistica() { }




    }

}
