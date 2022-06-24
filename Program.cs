using Trabalho_Prático;

MusicApp MusicApp = new MusicApp();
int status = 0;


while (status == 0)
//dps usar sistemas de menu encandeado
{
breakpointMenuPrincipal:

    Console.WriteLine("\n**************************");
    Console.WriteLine("            MENU INICIO           ");
    Console.WriteLine("***************************\n");
    Console.WriteLine("1- Guest");
    Console.WriteLine("2- Utilizador");
    Console.WriteLine("3- Admin");
    Console.WriteLine("4- sair");


    Console.WriteLine("Escolha uma opção");
    int opcao = int.Parse(Console.ReadLine());
    switch (opcao)
    {
        case 4:
            {
                Console.WriteLine("Adeus...");
                return;
                break;

            }
        case 1:
            {
                Console.Clear();
                Console.WriteLine("\n**************************");
                Console.WriteLine("            MENU GUEST           ");
                Console.WriteLine("***************************\n");
                Console.WriteLine("0 - <- VOLTAR");
                Console.WriteLine("1- Reproduzir musica");
                Console.WriteLine("2- Listar Musicas");
                Console.WriteLine("3- +Info PLaylist -guest");
                Console.WriteLine("4- Adicionar novo Utilizador"); //sign in

                int opcao2 = int.Parse(Console.ReadLine());
                switch (opcao2)
                {
                    case 0:
                        {
                            Console.Clear();
                            goto breakpointMenuPrincipal;
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine("o nome da musica a reproduzir");
                            string nomeM = Console.ReadLine();

                            Musica musica = MusicApp.ProcurarMedia(nomeM);
                            if (MusicApp.ProcurarMedia(nomeM) != null)
                            {
                                MusicApp.ReproduzirMusica(musica);
                                Console.WriteLine("playing ...");
                                //  ******** ->     fazer o system delay depois

                            }
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("Todas as nossas musicas, até o momento...\n");
                            MusicApp.ListarMusicas();

                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("o nome da Playlist a saber mais informações");
                            string nome = Console.ReadLine();
                            MusicApp.MostrarInfoPlaylist(nome);
                            break;
                        }
                    case 4:
                        {
                        checkpoint:

                            Console.WriteLine("Qual será o perfil?");
                            Console.WriteLine("1- Regular");
                            Console.WriteLine("2- Premium");
                            int user = int.Parse(Console.ReadLine());

                            if (user == 1)
                            {
                                Console.WriteLine("O nome do Utilizador");
                                string nomeU = Console.ReadLine();


                                if (MusicApp.ValidarConta(nomeU) == false)
                                {
                                    Console.WriteLine("Já existe um user com esse nome");
                                    goto checkpoint;
                                }
                                else
                                {
                                    Utilizador utilizador = new Regular(nomeU);// so cria se for true
                                    MusicApp.AdicionarUtilizador(utilizador);
                                    Console.WriteLine("Utilizador regular criado com sucesso");
                                }
                            }
                            else if (user == 2)
                            {
                                Console.WriteLine("O nome do Utilizador Premium");
                                string nomeU = Console.ReadLine();
                                Console.WriteLine("O numero da Pass Premium");
                                int passP = int.Parse(Console.ReadLine());


                                if (MusicApp.ValidarConta(nomeU) == false)
                                {
                                    Console.WriteLine("Já existe um user com esse nome");
                                    goto checkpoint;
                                }
                                else
                                {
                                    Utilizador utilizador = new Premium(nomeU, passP);// so cria se for true
                                    MusicApp.AdicionarUtilizador(utilizador);
                                    Console.WriteLine("Utilizador Premium criado com sucesso");
                                    goto breakpointMenuPrincipal;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Nenhuma opção selecionada");
                                goto breakpointMenuPrincipal;
                            }
                            break;
                        }

                }
                break;
            }

        case 2:
            {
            breakpointUser:
                Console.Clear();
                Console.WriteLine("\n**************************");
                Console.WriteLine("            MENU USUARIO           ");
                Console.WriteLine("***************************\n");
                Console.WriteLine("0 - <- VOLTAR");
                Console.WriteLine("1- Entrar como Regular");
                Console.WriteLine("2- Entrar como Premium");

                int opcao2 = int.Parse(Console.ReadLine());
                switch (opcao2)
                {
                    case 0:
                        {
                            Console.Clear();
                            goto breakpointMenuPrincipal;
                            break;
                        }
                    case 1: //preciso carrregar a sessão do mesmo ****************
                        {
                            Console.WriteLine("O nome User");
                            string nomeU = Console.ReadLine();
                            if(MusicApp.ValidarConta(nomeU)==false)
                            {
                                Console.Clear();
                                Console.WriteLine("\n**************************");
                                Console.WriteLine("            MENU USUARIO           ");
                                Console.WriteLine("***************************\n");
                                Console.WriteLine("0 - <- VOLTAR");
                                Console.WriteLine("1- Reproduzir musica");
                                Console.WriteLine("2- Listar Musicas");
                                Console.WriteLine("3- +Info PLaylist");

                                int opcao3 = int.Parse(Console.ReadLine());
                                switch (opcao3)
                                {
                                    case 0:
                                        {
                                            Console.Clear();
                                            goto breakpointUser;
                                            break;
                                        }
                                    case 1:
                                        {
                                            Console.WriteLine("o nome da musica a reproduzir");
                                            string nomeM = Console.ReadLine();

                                            Musica musica = MusicApp.ProcurarMedia(nomeM);
                                            if (MusicApp.ProcurarMedia(nomeM) != null)
                                            {
                                                MusicApp.ReproduzirMusica(musica);
                                                Console.WriteLine("playing ...");
                                                //  ******** ->     fazer o system delay depois

                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("Todas as nossas musicas, até o momento...\n");
                                            MusicApp.ListarMusicas();

                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("o nome da Playlist a saber mais informações");
                                            string nome = Console.ReadLine();
                                            MusicApp.MostrarInfoPlaylist(nome);
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Nenhuma opção selecioando");
                                            goto breakpointUser;
                                            break;
                                        }
                                }                          
                            }
                            else
                            {
                                Console.WriteLine("Não existe nenhum User Regular com esse nome");
                                goto breakpointUser;
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("O nome User");
                            string nomeU = Console.ReadLine();
                            Console.WriteLine("A senha(pass)");
                            int pass = int.Parse(Console.ReadLine());

                            if(MusicApp.ValidarContaPremuim(nomeU, pass) == false)
                            {
                                
                                Console.Clear();
                                Console.WriteLine("\n**************************");
                                Console.WriteLine("            MENU USUARIO *PREMIUM*          ");
                                Console.WriteLine("***************************\n");
                                Console.WriteLine("1- Reproduzir musica");
                                Console.WriteLine("2- Listar Musicas");
                                Console.WriteLine("3- +Info PLaylist");
                                Console.WriteLine("4- Classificar Musica");
                                Console.WriteLine("5- Ver classicacao Musica");
                                Console.WriteLine("6- +Info Musica");
                                Console.WriteLine("7- +Info Artista");

                                int opcao3 = int.Parse(Console.ReadLine());
                                switch (opcao3)
                                {
                                    case 0:
                                        {
                                            Console.Clear();
                                            goto breakpointUser;
                                            break;
                                        }
                                    case 1:
                                        {
                                            Console.WriteLine("o nome da musica a reproduzir");
                                            string nomeM = Console.ReadLine();

                                            Musica musica = MusicApp.ProcurarMedia(nomeM);
                                            if (MusicApp.ProcurarMedia(nomeM) != null)
                                            {
                                                MusicApp.ReproduzirMusica(musica);
                                                Console.WriteLine("playing ...");
                                                //  ******** ->     fazer o system delay depois

                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("Todas as nossas musicas, até o momento...\n");
                                            MusicApp.ListarMusicas();

                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("o nome da Playlist a saber mais informações");
                                            string nome = Console.ReadLine();
                                            MusicApp.MostrarInfoPlaylist(nome);
                                            break;
                                        }
                                    case 4:
                                        {
                                        breakpoint:
                                            Console.WriteLine("Qual o nome da musica a classificar?");
                                            string nomeMusica = Console.ReadLine();

                                            Media media = MusicApp.ProcurarMedia(nomeMusica);
                                            if (nomeMusica == null)
                                            {
                                                Console.WriteLine("A musica não existe nas nossas listagens");
                                                goto breakpoint;
                                            }
                                            else
                                            {
                                                Console.WriteLine("O nome do Utilizador");
                                                string nome = Console.ReadLine();

                                                Utilizador utilizador = MusicApp.ProcurarUtilizadorAEliminar(nome); //embora o nome, ele procura se existe um utuilizador na lista de Utilizadores
                                                Console.WriteLine("A sua classificação de 1-5(5 - entra pra sua playlist de favoritos)");
                                                int pontucao = int.Parse(Console.ReadLine());

                                                Registo registo = new Registo(utilizador, media, pontucao);
                                                MusicApp.ClassificarMedia(registo);
                                                Console.WriteLine("Media classificado com sucesso");
                                            }
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.WriteLine("o nome da media a saber?");
                                            string nomeMusica = Console.ReadLine();
                                            //MusicApp.MostrarInfoMedia(nomeMusica);
                                            MusicApp.MostrarEstatisticasDeMedia(nomeMusica);
                                            break;
                                        }
                                    case 6:
                                        {
                                            Console.WriteLine("nome da musica e se saber mais detalhes?");
                                            string musica = Console.ReadLine();
                                            MusicApp.MostrarInfoMedia(musica);
                                            break;
                                        }
                                    case 7:
                                        {
                                            Console.WriteLine("O nome do artista");
                                            string nome = Console.ReadLine();
                                            Console.WriteLine("A sua nacioanalidade");
                                            string nacionalidade = Console.ReadLine();

                                            if (MusicApp.ProcurarArtistaAEliminar(nome, nacionalidade) != null)
                                            {
                                                MusicApp.MostrarInfoArtista(nome, nacionalidade);
                                            }

                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Nenhuma opção selecioando");
                                            goto breakpointUser;
                                            break;
                                        }
                                }
                            }
                            else
                            {

                                Console.WriteLine("Não existe nenhum User Regular com esse nome");
                                //ssytem sleep
                                goto breakpointUser;
                            }
                            break;
                        }
                } break;
            }


        case 3:
            {
                Console.Clear();
                Console.WriteLine("\n**************************");
                Console.WriteLine("            MENU ADMIN           ");
                Console.WriteLine("***************************\n");
                Console.WriteLine("0 - <- VOLTAR");
                Console.WriteLine("1- Adicionar Musica");
                Console.WriteLine("2- Eliminar Musica");
                Console.WriteLine("3- Adicionar Playlist");
                Console.WriteLine("4- Eliminar Playlist");// seria a playlist geral dos guests
                Console.WriteLine("5- Adicionar Musica PLaylist - Guest");
                Console.WriteLine("6- Listar Artistas");
                Console.WriteLine("7- Adicionar Artista");
                Console.WriteLine("9- Eliminar Utilizador");
                Console.WriteLine("8- Eliminar Artista");
                Console.WriteLine("10- Listar User");
                int opcao2 = int.Parse(Console.ReadLine());
                switch (opcao2)
                {
                    case 0:
                        {
                            Console.Clear();
                            goto breakpointMenuPrincipal;
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine("*****Adicionando uma nova musica*****\n");
                            Console.WriteLine("BPS:");
                            int bps = int.Parse(Console.ReadLine());
                            Console.WriteLine("O Titulo?");
                            string titulo = Console.ReadLine();
                            Console.WriteLine("Genero:");
                            string genero = Console.ReadLine();
                            Console.WriteLine("Duracao");
                            int duracao = int.Parse(Console.ReadLine());
                            Console.WriteLine("Ano:");
                            int ano = int.Parse(Console.ReadLine());
                            Console.WriteLine("nome do Artista");
                            string nomeA = Console.ReadLine();
                            Console.WriteLine("Nacionalidade");
                            string nacionalidade = Console.ReadLine();

                            Artista artista = MusicApp.ValidarArtista(nomeA, nacionalidade);
                            if (artista == null)
                            {
                                Artista artista2 = new Artista(nomeA, nacionalidade);
                                Musica media2 = new Musica(bps, titulo, genero, duracao, ano, artista2);
                                MusicApp.AdicionarMusica(media2);
                                MusicApp.AdicionarArtista(artista2);
                                Console.WriteLine("\n-------->Musica e Artista criada e adicionada com sucesso");
                            }
                            else
                            {
                                Musica media = new Musica(bps, titulo, genero, duracao, ano, artista);
                                MusicApp.AdicionarMusica(media);
                                //MusicApp.AdicionarArtista(artista); pois o artisat já existe
                                Console.WriteLine("\n-------->Musica criada e adicionada com sucesso");
                            }

                            //colocar system spleep 2s
                            Console.Clear();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("O nome do filme a eliminar");
                            string nome = Console.ReadLine();
                            MusicApp.EliminarMusica(nome);
                            Console.WriteLine($"\n-------->Musica-{nome}, eliminada sucesso");


                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("O nome da Playlist");
                            string nomePlaylist = Console.ReadLine();
                            Playlist playlist = MusicApp.ValidarPlaylist(nomePlaylist);
                            if (playlist == null)
                            {
                                Playlist playlist1 = new Playlist(nomePlaylist);
                                MusicApp.AdicionarPlaylist(playlist1);
                                Console.WriteLine("Playlist criado e adicionado com sucesso");
                            }
                            else
                            {
                                //    MusicApp.AdicionarPlaylist(playlist);
                                Console.WriteLine("Playlist já existe na nossa listagem");
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Nome Playlist");
                            string nome = Console.ReadLine();
                            MusicApp.EliminarPlaylist(nome);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("O nome da PLaylist a adicionar a musica");
                            string nomePlaylist = Console.ReadLine();
                            if (MusicApp.PlayListAEliminar(nomePlaylist) != null)
                            {
                                Playlist playlist = MusicApp.PlayListAEliminar(nomePlaylist);
                                Console.WriteLine("o nome da Musica");
                                string nomeMusica = Console.ReadLine();
                                if (MusicApp.ProcurarMedia(nomeMusica) != null)
                                {
                                    Musica media = MusicApp.ProcurarMedia(nomeMusica);
                                    MusicApp.AdicionarMediaAPlaylist(media, playlist);
                                }
                                else
                                    Console.WriteLine("Nenhuma media encontrada");
                            }
                            else
                            {
                                Console.WriteLine("Nenhuma playlist encontrada");
                            }
                            Console.WriteLine("Adicionado com sucesso");


                            break;
                        }
                    case 6:
                        {
                            MusicApp.ListarArtistas();
                            break;
                        }

                    case 7:
                        {
                            Console.WriteLine("o nome");
                            string nome = Console.ReadLine();
                            Console.WriteLine("A nacionalidade");
                            string nacionalidade = Console.ReadLine();

                            Artista artista = new Artista(nome, nacionalidade);
                            MusicApp.ValidarArtista(nome, nacionalidade);
                            MusicApp.AdicionarArtista(artista);

                            break;
                        }

                    case 8:
                        {
                            Console.WriteLine("o nome do artista a ser eliminado");
                            string nome = Console.ReadLine();
                            Console.WriteLine("a nacioanlidade");
                            string nacionalidade = Console.ReadLine();

                            MusicApp.EliminarArtista(nome, nacionalidade);
                            break;
                        }
                    case 9:
                        {
                            Console.WriteLine("nome do utilizador a ser eliminado");
                            string nomeUtilizador = Console.ReadLine();

                            MusicApp.EliminarUtilizador(nomeUtilizador);
                            break;
                        }
                    case 10: //case de testes
                        {
                            MusicApp.MostrarUser();
                            //MusicApp.ListarPlaylist();


                            break;
                            //            }   //  testes!
                        }
                    default:
                        {
                            Console.WriteLine("Nenhuma opção válida escolhida");
                            goto breakpointMenuPrincipal;
                            break;
                        }
                        break;
                }
                break;
                }
               
    }
}












//    Console.WriteLine("0- Sair");


//    Console.WriteLine("Escolha uma opção");
//    int opcao1 = int.Parse(Console.ReadLine());

//    switch (opcao1)
//    {
//        case 0:
//            {
//                Console.WriteLine("Adeus...");
//                break;
//                return;
//            }
//        




//int opcao2 = int.Parse(Console.ReadLine());
//switch (opcao2)
//{
//    case 0:
//        {
//            Console.Clear();
//            goto breakpointMenuPrincipal;
//            break;
//        }
//}






//        case 15:
//            {
//    Console.WriteLine("o nome da Playlist a saber mais informações");
//    string nome = Console.ReadLine();
//    MusicApp.MostrarInfoPlaylist(nome);
//    break;
//}

//       
//        //case 19:
//        //    {
//        //        Console.WriteLine("o nome da musica a saber as plays");
//        //        string nomeM = Console.ReadLine();

//        //        MusicApp.Obter
//        //        break;
//        //    }



//        default:
//            Console.WriteLine("Nenhuma opção selecioanda");
//            break;
//    }
//}



