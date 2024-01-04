using System.ComponentModel.DataAnnotations;

namespace api.Dto
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage ="O campo {0} deve ter no máximo {1} caracteres.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "Fommato de {0} Inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage ="O campo {0} é obrigatório.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,20}$", ErrorMessage = "A senha deve ter pelo menos 8 caracteres, no máximo 20 caracteres, incluindo pelo menos uma letra e um número.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Senhas não conferem")]
        public string ConfirmPassword { get; set; }
    }
}
