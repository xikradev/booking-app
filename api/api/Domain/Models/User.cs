using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace api.Domain.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "O campo Full Name é obrigatório.")]
        [StringLength(150, ErrorMessage = "O campo FullName deve ter no máximo 150 caracteres.")]
        public string Fullname { get; set; }
    }
}
