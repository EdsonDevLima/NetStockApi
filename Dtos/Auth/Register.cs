using System.ComponentModel.DataAnnotations;
using NetStock.Entities;

namespace NetStock.Dtos
{
    public class RegisterUserDto : User
    {
        [Required(ErrorMessage = "Confirmação de senha obrigatoria")]
        public string ConfirmPasswod { get; set; }

    }
}