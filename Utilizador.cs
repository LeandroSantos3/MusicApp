using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Prático
{
    internal class Utilizador
    {
        //Playlist playlist;
        //List<Playlist> list;
        List<Registo> registos;
        public static int proximo = 1;
        public string Nome { get; set; }
        public int Pass { get; set; }
        public int id;

        public Utilizador()
        {
            this.id = proximo++;
            registos = new List<Registo>();
        }

               
        public void ClassificarMedia() { }
        
        public void ReproduzirMedia() { }

        public void ObterEstatistica() { }

        public void ObterInfoPlaylist() { }

       
    }

    internal class Regular : Utilizador
    {
        
        public Regular(string nome)
        {

            this.Nome = nome;
            Playlist playlist = new Playlist("Default");
            
        }
    }

    internal class Premium : Utilizador
    {
            
       
        public Premium(string nome, int pass)
        {
            this.Nome = nome;
            this.Pass = pass;
            Playlist playlist = new Playlist("Default");
            List<Playlist> playlists = new List<Playlist>(); //pegar aqui para criar mais playlists
        }

        public void CriarPlaylist() 
        {
            
        }
        public void EliminarPlaylist() { }
        public void AdicionarMediaAPlaylist() { }
        public void EliminarMediaDePLaylist() { }




    }

}
