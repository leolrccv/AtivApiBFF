namespace ApiCliente.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string NomeMae { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}