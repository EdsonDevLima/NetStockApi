using System.ComponentModel.DataAnnotations;

namespace NetStock.Entities
{
    public class User
    {

        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Email obrigatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha obrigatoria")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Nome obrigatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Telefone obrigatorio")]
        public string Phone { get; set; }

    }
}