namespace Entidades
{
    public class Mensagem
    {
        public string Id { get; set; }
        public string Conteudo { get; set; }
        public int Tokens_gastos { get; set; }
        public DateTime Criado { get; set; }
        public string Autor {  get; set; }

        public override string ToString()
        {
            return $"MENSAGEM RECEBIDA - {Criado}\n" +
                   $"Id: {this.Id}\n" +
                   $"Mensagem: {this.Conteudo}\n" +
                   $"Total de tokens gastos: {this.Tokens_gastos}\n";
        }
    }
}
