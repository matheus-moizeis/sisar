#region Namespaces

using Sisar.Core.Exceptions;
using Sisar.Domain.Validators;

#endregion

namespace Sisar.Domain.Entities
{
    public class Emitente : Base
    {
        #region Propriedades

        public string RazaoSocial { get; private set; }

        public string NomeFantasia { get; private set; }

        public string Cnpj { get; private set; }

        #endregion

        #region Construtores

        public Emitente(string razaoSocial, string nomeFantasia, string cnpj)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            _errors = new List<string>();
            Validate();
        }

        protected Emitente() { }

        #endregion

        #region Métodos

        public override bool Validate()
        {
            var validator = new EmitenteValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);

                    throw new DomainException("Campos inválidos, favor verificar", _errors);

                }
            }
            return true;
        }

        #endregion

    }
}
