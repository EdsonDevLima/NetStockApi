using System.ComponentModel.DataAnnotations;

namespace NetStock.Entities
{
    public class Categories
    {

        [Key]
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Categoria obrigatoria")]
        public string Name { get; set; }

    }
}