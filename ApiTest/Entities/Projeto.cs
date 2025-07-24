namespace ApiTest.Entities
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<Desenvolvedor> Desenvolvedores { get; set;}
    }
}
