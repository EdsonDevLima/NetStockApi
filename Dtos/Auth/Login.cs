using System.ComponentModel.DataAnnotations;

namespace NetStock.Dtos{
    public class Login{
        [Required(ErrorMessage ="Email obrigatorio")]
        string Email{get;set;}
        [Required(ErrorMessage ="Senha obrigatoria")]
        string Passwod{get;set;}
        
    }
}