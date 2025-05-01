using System.ComponentModel.DataAnnotations;

namespace NetStock.Dtos
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Email obrigatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha obrigatoria")]
        public string Passwod { get; set; }

    }
}