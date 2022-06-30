//a44097 - Leandro Santos
namespace Trabalho_Prático
{
    internal class Artista
    {
        List<Media> medias;
        public string Nome { get; }
        public string Nacionalidade { get; }

        public Artista(string Nome, string Nacionalidade)
        {
            this.Nome = Nome;
            this.Nacionalidade = Nacionalidade;
            medias = new List<Media>();
        }

        public void AdicionarMedia(Media media)
        {
            medias.Add(media);
        }

        public void Mostrar()
        {
            Console.WriteLine($"Nome: {Nome}, Nacionalidade: {Nacionalidade}");
        }
    }
}
