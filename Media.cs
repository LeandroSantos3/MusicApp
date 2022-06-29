namespace Trabalho_Prático
{
    internal class Media
    {
        Artista artista;
        List<Registo> registos;


        static int ProximoNumero = 0;
        static int NumeroReproducaoZerado = 0;
        public int ID { get; } = 0;
        public string Titulo { get; }
        public string Genero { get; }
        public int Duracao { get; }
        public int Ano { get; }

        public Artista retornarArtista { get; } // para poder retorna o artista associado à media

        public int NumeroReproducao { get; set; } = 0;



        public Media(string Titulo, string Genero, int Duracao, int Ano, Artista artista)
        {

            this.ID = ProximoNumero;
            ProximoNumero++;
            this.Titulo = Titulo;
            this.Genero = Genero;
            this.Duracao = Duracao;
            this.Ano = Ano;
            this.retornarArtista = artista;
            this.NumeroReproducao = NumeroReproducaoZerado;

            registos = new List<Registo>();

        }

        public int ObterEstatistica()
        {
            return NumeroReproducao;
        }

        public interface Reproduzivel
        {
            void Reproduzir(Media media);
        }
    }

    internal class Video : Media
    {
        public int Resolucao { get; }

        public Video(int Resolucao, string Titulo, string Genero, int Duracao,
            int Ano, Artista artista) : base(Titulo, Genero, Duracao, Ano, artista)
        {
            this.Resolucao = Resolucao;
        }
    }

    internal class Musica : Media
    {
        public int Bps { get; }

        public Musica(int Bps, string Titulo, string Genero, int Duracao,
            int Ano, Artista artista) : base(Titulo, Genero, Duracao, Ano, artista)
        {
            this.Bps = Bps;
        }
    }
}


