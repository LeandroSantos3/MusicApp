//a44097 - Leandro Santos
namespace Trabalho_Prático
{
    internal class MusicApp
    {      
        List<Musica> medias; //conjunto de medias da MusicApp como um todo
        List<Utilizador> utilizadores; //lista de users
        List<Artista> artistas; //lista de artistas
        static List<Playlist> playlistas = new List<Playlist>(); //playlist generalizada para todos os useres, mas independentemente do tipo de user e da quantidade todos os useres terão acesso - só pode ser criado e editado pelo Admin

        List<Registo> registos; //guarda cada media classificada de cada user
        static protected Playlist favoritos = new Playlist("Favoritos");

        public MusicApp()
        {
            Artista leo1 = new Artista("Leo", "Cabo Verde");
            Artista leo2 = new Artista("Leo Santos", "Cabo Verde / PT");
            Musica m1 = new Musica(1, "musica1", "teste", 1, 2022, leo1);
            Musica m2 = new Musica(1, "musica2", "teste", 1, 2022, leo2);
            Musica m3 = new Musica(1, "musica3", "teste", 1, 2022, leo1);
            Utilizador leop = new Premium("leop", 1);

            

            medias = new List<Musica>();
            utilizadores = new List<Utilizador>();
            artistas = new List<Artista>();
            // playlistas = new List<Playlist>(); //playlist para os guest´s, podendo ser mais de um, mas os user terão acesso a todos eles, pois serão as playlist's "default"
            registos = new List<Registo>();


            medias.Add(m1); medias.Add(m2); medias.Add(m3);
            utilizadores.Add(leop);
            artistas.Add(leo2); artistas.Add(leo1);
        }

        public void AdicionarMusica(Musica media)
        {
            medias.Add(media);
        }

        public bool ValidarMedia(Musica media)
        {
            foreach (var item in medias)
            {
                if (item.Titulo.Equals(media.Titulo))
                    return false;
            }
            return true;
        }

        public Artista ValidarArtista(string nomeAAvaliar, string nacionalidadeAAvaliar)
        {
            foreach (var item in artistas)
            {
                if (item.Nome.Equals(nomeAAvaliar) && item.Nacionalidade.Equals(nacionalidadeAAvaliar))
                    return item;
            }
            return null;
        }

        public void EliminarMusica(string nomeMusicaEliminar)
        {
            medias.Remove(ProcurarMedia(nomeMusicaEliminar));
        }

        public void AdicionarPlaylist(Playlist playlist)
        {
            playlistas.Add(playlist);
        }

        public void EliminarPlaylist(string nomePlaylistAEliminar)
        {
            playlistas.Remove(PlayListAEliminar(nomePlaylistAEliminar));
            Console.WriteLine("Eliminado com sucesso");
        }

        public Playlist PlayListAEliminar(string nomeAEliminar)
        {
            foreach (var item in playlistas)
            {
                if (item.nomePlaylist.Equals(nomeAEliminar))
                    return item;
            }
            //Console.WriteLine("Nenhuma PLaylist com esse nome\n");
            return null;
        }
        public void ListarPlaylist()
        {
            foreach (var item in playlistas)
            {
                Console.WriteLine(item.nomePlaylist + "\n");
            }
        }

        public void AdicionarUtilizador(Utilizador utilizador)
        {
            utilizadores.Add(utilizador);
        }

        public void MostrarUser()
        {
            foreach (var item in utilizadores)
            {
                Console.WriteLine($"id: {item.id}, nome: {item.Nome}\n");
            }
        }

        public bool ValidarConta(string nomeAValidar)
        {
            foreach (var item in utilizadores)
            {
                if (item.Nome.Equals(nomeAValidar))
                    return false;
            }
            return true;

        }
        public bool ValidarContaPremuim(string nomeAValidar, int pass)
        {
            foreach (var item in utilizadores)
            {
                if (item.Nome.Equals(nomeAValidar) && item.Pass.Equals(pass))
                    return false;
            }
            return true;
        }
        public Premium AtribuirContaPremuim(string nomeAValidar, int pass)
        {
            foreach (var item in utilizadores)
            {
                if (item.Nome.Equals(nomeAValidar) && item.Pass.Equals(pass))
                {
                    Utilizador utilizador = item;
                    return (Premium)utilizador;
                }
            }
            return null;
        }

        public void EliminarUtilizador(string nomeUtilizador)
        {
            utilizadores.Remove(ProcurarUtilizadorAEliminar(nomeUtilizador));
        }

        public Utilizador ProcurarUtilizadorAEliminar(string nomeUtilizador)
        {
            foreach (var item in utilizadores)
            {
                if (item.Nome.Equals(nomeUtilizador))
                    return item;
            }
            Console.WriteLine("Não existe nenhum utilizador com esse nome\n");
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

        public void EliminarArtista(string nomeArtistaEliminar, string nacionalidade)
        {
            artistas.Remove(ProcurarArtistaAEliminar(nomeArtistaEliminar, nacionalidade));

        }
        public Artista ProcurarArtistaAEliminar(string nomeArtistaEliminar, string nacionalidade) // obs:  esse metodo apesar do nome so procura e retorna o user, acabei por criar com esse nome que era pra ser auxiliar
                                                                                                  //do metodo pra eliminar, mas depois acabei por o reaproveitar pro programa como um todo, então nao mudei o nome pra nao estar 
                                                                                                  //sujeito a erros depois no final do projeto - dia atual dia 29/06 -  entra pretendida 1/07
        {
            foreach (var item in artistas)
            {
                if (item.Nome.Equals(nomeArtistaEliminar) && item.Nacionalidade.Equals(nacionalidade))
                {
                    return item;
                }
            }
            Console.WriteLine("Artista não existe\n");
            return null;
        }

        public void ListarMusicas()
        {
            if( medias.Count == 0)
            {
                Console.WriteLine("Ainda não existem musicas na nossa App\n");
            }
            else
            {
                Console.WriteLine("Todas as nossas musicas, até o momento...\n");
                foreach (var item in medias)
                {
                    Console.WriteLine($"Titulo: {item.Titulo}, Artista: {item.retornarArtista.Nome}\n");
                }
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
            registos.Add(registo);
        }

        public void MostrarInfoMedia(string nomeMusicaASaber)
        {
            if (ProcurarMedia(nomeMusicaASaber) == null)
                Console.WriteLine("a musica não existe\n");
            else
            {
                foreach (var item in medias)
                {
                    if (item.Titulo.Equals(nomeMusicaASaber))
                    {
                        Console.WriteLine($"ID: {item.ID}, Titulo: {item.Titulo}, Genero: {item.Genero}, Duração(minutos): {item.Duracao}, Ano: {item.Ano}, " +
                            $"Nome do Artista:{item.retornarArtista.Nome}, Nacionalidade do Artista: {item.retornarArtista.Nacionalidade} e o numero de reproduções total: {item.ObterEstatistica()}\n");
                        
                    }
                }
            }
        }

        public void MostrarInfoPlaylist()
        {
            if(playlistas.Count==0)
                Console.WriteLine("Ainda não está nada registado na lista, o admin precisa adicionar musicas à Playlist genérica\n");
            else
            {
                foreach (var item in playlistas)
                {                   
                    item.MostarPLaylist();
                }
            }
            
        }
        public void MostrarInfoArtista(string nomeArtista, string nacionalidade)
        {
            foreach (var item in artistas)
            {
                if (item.Nome.Equals(nomeArtista) && item.Nacionalidade.Equals(nacionalidade))
                    item.Mostrar();
            }
        }

        public void MostrarEstatisticasDeMedia(Utilizador utilizador)
        {
            if(registos.Count() == null)            
                Console.WriteLine("Ainda nao foi classificado nenhuma musica");
            
            else
            {
                foreach (var item in registos)
                {
                    if (item.utilizador.Nome.Equals(utilizador.Nome))
                    {
                        item.MostrarRegisto();
                    }
                }
            }
            
        }

        public void MostrarListaFavoritos(Utilizador utilizador)
        {         

            foreach (var item in utilizadores)
            {
               if (item.Nome.Equals(utilizador.Nome))
                    favoritos.MostarPLaylist();               
            }
            
        }

        public bool AtribuirFavorito(Utilizador utilizador, Registo registo, Media media)
        {
            foreach (var item in registos)
            {
                if (item.utilizador.Nome.Equals(registo.utilizador.Nome) && item.Classificacao.Equals(registo.Classificacao) && item.media.Titulo.Equals(media.Titulo))
                {                    
                    favoritos.AdicionarMedia((Musica)item.media);
                    return true;
                }
            }return false;            
        }

        public void ReproduzirMusica(Musica media)
        {
            foreach (var item in medias)
            {
                if (item.Titulo.Equals(media.Titulo))
                    item.NumeroReproducao++;
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
                    break; //assim ele nao toca todas as == 0 de uma só vez
                } 
            }
        }

        public void ReproduzirPlaylist()
        {
            string nomeP = "Default";
            foreach (var item in playlistas)
            {
                if (item.nomePlaylist.Equals(nomeP))
                    ReproduzirMusica(item.RetornarItemPlaylist());
            }
            Console.WriteLine("playing...todas as musicas da playlist foi tocada");
        }


        public void ReproduzirMusicasDoArtista(Artista artista)
        {
            foreach (var item in medias)
            {
                if (item.retornarArtista.Nome.Equals(artista.Nome) && item.retornarArtista.Nacionalidade.Equals(artista.Nacionalidade))
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

        //public Utilizador AlterarTipoUtilizador(Utilizador utilizador)
        //{
        //    foreach (var item in utilizadores)
        //    {
        //        if (item.Nome.Equals(utilizador.Nome))
        //        {
        //            CriarNovoUserRegular(item);                    
        //        }
        //    }return null;
        //}
        //public void CriarNovoUserRegular(Utilizador utilizador)
        //{
        //    utilizador =  new Regular(utilizador.Nome);
        //    EliminarUtilizador(utilizador.Nome); // ele elimina o antigo
        //    Console.WriteLine("Foi mudado a sua conta para o tipo Regular");
        //}




    }
}
