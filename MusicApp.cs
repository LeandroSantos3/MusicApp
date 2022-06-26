using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Trabalho_Prático
{
    internal class MusicApp
    {
        List<Musica> medias; //consjunto de media da MusicApp como um todo
        List<Utilizador> utilizadores;
        List<Artista> artistas;              
        List<Playlist> playlistas; //playlist generalizada para todos os useres, mas independentemente do tipo de user e da quantidade todos os useres terão acesso - só pode ser criado e editado pelo Admin
        List<Playlist> MediaPlaylist; //playlist de cada UserPremium
        List<Registo> registos; //guarda cada media classificada
        

        public MusicApp()
        {
            medias = new List<Musica>();
            utilizadores = new List<Utilizador>();
            artistas=new List<Artista>();           
            playlistas = new List<Playlist>(); //playlist para os guest´s, podendo ser mais de um, mas os user terão acesso a todos eles, pois serão as playlist's "default"
            registos = new List<Registo>();
        }
    
        public void AdicionarMusica(Musica media)
        {
            medias.Add(media);
        }

        public Artista ValidarArtista(string nomeAAvaliar, string nacionalidadeAAvaliar) //extra
        {
            foreach (var item in artistas)
            {
                if(item.Nome.Equals(nomeAAvaliar) &&item.Nacionalidade.Equals(nacionalidadeAAvaliar))
                    return item;                                    
            }
            return null;
        }

        public void EliminarMusica(string nomeMusicaEliminar) 
        {
            medias.Remove(ProcurarMedia(nomeMusicaEliminar)); //atenção ele retorna o proprio objeto            
        }
        
        public void AdicionarPlaylist(Playlist playlist)
        {            
            playlistas.Add(playlist);       //adiciono à listagem
        }

        public void EliminarPlaylist(string nomePlaylistAEliminar)
        {
            playlistas.Remove(PlayListAEliminar(nomePlaylistAEliminar));
        }

        public Playlist PlayListAEliminar(string nomeAEliminar)
        {
            foreach (var item in playlistas)
            {
                if (item.nomePlaylist.Equals(nomeAEliminar))
                    return item;
                else
                    Console.WriteLine("Nenhuma PLaylist com esse nome");
                //return null;
            }            
            return null;
        }
        public void ListarPlaylist() //extra
        {
            foreach (var item in playlistas)
            {
                Console.WriteLine(item.nomePlaylist + "\n");
            }
        }

        public void AdicionarUtilizador(Utilizador utilizador)
        {     
                utilizadores.Add(utilizador); // mas assim ele permite ter n user com o mesmo nome....
        }

        public void MostrarUser()
        {
            foreach (var item in utilizadores)
            {
                Console.WriteLine($"id: {item.id}, nome: {item.Nome}");
            }
        }         //*******   Funciona a criação de user com a herança e id auto

        public bool ValidarConta(string nomeAValidar)   //extra
        {
            foreach (var item in utilizadores)
            {
                if (item.Nome.Equals(nomeAValidar))              
                    return false;               
            }
            return true;

        }
        public bool ValidarContaPremuim(string nomeAValidar, int pass)   //extra
        {
            foreach (var item  in utilizadores)
            {
                if (item.Nome.Equals(nomeAValidar) && item.Pass.Equals(pass))
                    return false;
            }
            return true;

        }

        public void EliminarUtilizador(string nomeUtilizador)
        {
            utilizadores.Remove(ProcurarUtilizadorAEliminar(nomeUtilizador));//elimina o primeiro com o nome igual
        }

        public Utilizador ProcurarUtilizadorAEliminar(string nomeUtilizador)//extra 
        {
            foreach (var item in utilizadores)
            {
                if(item.Nome.Equals(nomeUtilizador))
                    return item;
               
            }
            Console.WriteLine("Não existe nenhum utilizador com esse nome");
            return null;
        }
        public void AdicionarArtista(Artista artista) 
        {
            artistas.Add(artista);  
        }

        public Playlist ValidarPlaylist(string nomePlaylist)
        {
            foreach (var item in playlistas)
            {
                if (item.nomePlaylist.Equals(nomePlaylist))
                    return item;
            }
            return null;
        }        

        public void EliminarArtista(string nomeArtistaEliminar, string nacionalidade ) 
        {
            artistas.Remove(ProcurarArtistaAEliminar(nomeArtistaEliminar,nacionalidade));      
            
        }
        public Artista ProcurarArtistaAEliminar(string nomeArtistaEliminar, string nacionalidade) //não foi pedido
        {
            foreach (var item in artistas)
            {
                if (item.Nome.Equals(nomeArtistaEliminar) && item.Nacionalidade.Equals(nacionalidade)) //ou seja, se o nome for igual e o proprio tiver a mesma nacionalidade, ele o eliminará
                {
                    //Console.WriteLine("Artista " + item.Nome + ", foi eliminado");
                    return item;
                }
            }
            Console.WriteLine("Artista não existe");
            return null;
        }

        public void ListarMusicas() 
        {
            foreach (var item in medias)
            {
                Console.WriteLine($"ID: {item.ID}, Titulo: {item.Titulo}");//, Genero: {item.Genero}, Duração(minutos): {item.Duracao}, Ano: {item.Ano}, Nome do Artista:{item.retornarArtista.Nome}, Nacionalidade do Artista: {item.retornarArtista.Nacionalidade}");
            }           
        }       

        public void ListarArtistas()
        {
            foreach (var item in artistas)
            {
                item.Mostrar();
            }
        }

        public Musica ProcurarMedia(string nomeMusicaProcurar)

        {
            foreach (var item in medias)
            {
                if (item.Titulo.Equals(nomeMusicaProcurar))
                    return item;
            }
            return null;
        }

        public void ClassificarMedia(Registo registo)
        {
            registos.Add(registo); //funciona!!
            
            //falta adicionar na propria listagem de Utilizador - ficaria uma lista em paralelo
            
        }        

        public void MostrarInfoMedia(string nomeMusicaASaber) //aqui eu quero não só saber os dados da media mais principalemte os seus registos e suas classificações ;
                                                              //uma musica pode ser classificada por n user (uso da classe associativa Registo
        {
            if (ProcurarMedia(nomeMusicaASaber) == null)
                Console.WriteLine("a musica nao existe");
            else
            {
                foreach (var item in registos)
                {
                    if (item.media.Titulo.Equals(nomeMusicaASaber))
                    {
                        Console.WriteLine($"ID: {item.media.ID}, Titulo: {item.media.Titulo}, Genero: {item.media.Genero}, Duração(minutos): {item.media.Duracao}, Ano: {item.media.Ano}, " +
                            $"Nome do Artista:{item.media.retornarArtista.Nome}, Nacionalidade do Artista: {item.media.retornarArtista.Nacionalidade}");
                        item.MostrarRegisto();
                    }
                }
            }
        }

        public void MostrarInfoPlaylist(string nomePlaylist)
        {
            if (PlayListAEliminar(nomePlaylist) != null)
            {
                Console.WriteLine($"As medias registadas na Playlist {nomePlaylist} sao:\n");
                if (playlistas.Count < 0)
                {
                    Console.WriteLine("Ainda não está nada registado na lista, o admin precisa adicionar musicas àplaylist genérica");
                }
                else
                {
                    foreach (var item in playlistas)
                    {
                        item.MostarPLaylist();
                    }
                }                
                //ListarMusicas();                
            }
            else
            {
                Console.WriteLine("PLaylist não existe");               
            }
            
        }
        public void MostrarInfoArtista(string nomeArtista, string nacionalidade)
        {
            foreach (var item in artistas)
            {
                if(item.Nome.Equals(nomeArtista) && item.Nacionalidade.Equals(nacionalidade))
                {
                    item.Mostrar();
                }
            }
        }

        public void MostrarEstatisticasDeMedia()/*string nomeMediaASAber) *///estatistica em registo
        {
            //if (ProcurarMedia(nomeMediaASAber) == null)
            //    Console.WriteLine("a musica nao existe");
            //else
            //{
                foreach (var item in registos)
                {
                    //if (item.media.Titulo.Equals(nomeMediaASAber))
                    //{
                        item.MostrarRegisto();
                    //}i
                }
            //}
        }        
        public void ReproduzirMusica(Musica media) 
        {
            foreach (var item in registos)
            {
                if (item.media.Titulo.Equals(media.Titulo)) 
                    item.media.NumeroReproducao++;
            }
        }

        public void ReproduzirMusicaNova()
        {
            foreach (var item in medias)
            {
                if (item.NumeroReproducao.Equals(0))
                {
                    ReproduzirMusica(item);     //reproduz os com o numero de reprodução == 0
                    Console.WriteLine("tocando musica nova...");
                }
            }
        }

        public void ReproduzirPlaylist()
        {
            foreach (var item in medias)
            {
                 ReproduzirMusica(item);                
            }
            Console.WriteLine("playing...todas as musicas da playlist foi tocada");
        }

        
        public void ReproduzirMusicasDoArtista(Artista artista) 
        {
            foreach (var item in medias)
            {
                if(item.retornarArtista.Nome.Equals(artista.Nome)&& item.retornarArtista.Nacionalidade.Equals(artista.Nacionalidade))
                {
                    ReproduzirMusica(item);
                }
            }
        }

       public void MostrarPlaylist(string nomePLaylist) 
        {
            foreach (var item in playlistas)
            {
                if (item.nomePlaylist.Equals(nomePLaylist))
                {
                    item.MostarPLaylist();
                }
            }            
        }

        public void AdicionarMediaAPlaylist(Musica media, Playlist playlist)
        {             
            playlist.AdicionarMedia(media);//adicionar a media à coleção
        }

        public void ELiminarMediaDePlaylist(Musica media, Playlist playlist)
        {
            playlist.RemoverMedia(media.Titulo);
        }

        public void PlaylistsDoUtilizador()
        {
            
        }
        public void MostrarEstatisticasDoUtilizador() 
        {

        }
        public void AlterarTipoUtilizador()
        {

        }


    }
}
