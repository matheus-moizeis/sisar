namespace Sisar.Service.DTO
{
    public class EmitenteDTO
    {
        #region Propriedades

        public long Id { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string Cnpj { get; set; }

        public bool Ativo { get; set; }

        public DateTime DtCriacao { get; set; }

        public DateTime DtEdicao { get; set; }

        #endregion

        #region Construtores

        public EmitenteDTO()
        {

        }

        public EmitenteDTO(long id, string razaoSocial, string nomeFantasia, string cnpj, bool ativo, DateTime dtCriacao, DateTime dtEdicao)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Ativo = ativo;
            DtCriacao = dtCriacao;
            DtEdicao = dtEdicao;
        }

        #endregion
    }
}
