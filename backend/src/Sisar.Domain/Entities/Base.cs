namespace Sisar.Domain.Entities
{
    public abstract class Base
    {
        public long Id { get; set; }

        public DateTime DtCriacao { get; set; }

        public DateTime DtEdicao { get; set; }

        public bool Ativo { get; set; }

        internal List<string> _errors;

        public IReadOnlyCollection<string> Errors => _errors;

        public abstract bool Validate();
    }
}
