//a44097 - Leandro Santos
namespace Trabalho_Prático
{
    internal class Registo // classe Associativa
    {
        public Utilizador utilizador { get; }
        public Media media { get; }
        public int Classificacao { get; }

        public Registo(Utilizador utilizador, Media media, int Classificacao)
        {
            this.utilizador = utilizador;
            this.media = media;
            this.Classificacao = Classificacao;
        }

        public void MostrarRegisto()
        {
            Console.WriteLine($"{this.utilizador.Nome},{this.media.Titulo},classificação: {this.Classificacao},numero de reproduções: {media.ObterEstatistica()}");
        }
    }
}
