using System.ComponentModel.DataAnnotations;

namespace Sisar.API.ViewModel
{
    public class UpdateEmitenteViewModel
    {
        [Required(ErrorMessage = "O Id não pode ser vazio.")]
        [Range(1, int.MaxValue, ErrorMessage = "O id não pode ser menor que 1.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Cnpj é obrigatorio.")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O campo RazaoSocial é obrigatorio.")]
        [MaxLength(50, ErrorMessage = "O campo RazaoSocial deve possuir no máximo 50 caracteres ")]
        [MinLength(10, ErrorMessage = "O campo RazaoSocial deve possuir no mínimo 10 caracteres ")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O campo NomeFantasia é obrigatorio.")]
        [MaxLength(50, ErrorMessage = "O campo RazaoSocial deve possuir no máximo 50 caracteres ")]
        [MinLength(3, ErrorMessage = "O campo RazaoSocial deve possuir no mínimo 3 caracteres ")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "O campo ativo não pode ser vazio.")]
        public bool Ativo { get; set; }
    }
}
