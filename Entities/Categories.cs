using System.ComponentModel.DataAnnotations;

namespace NetStock.Entities{
    public class Categories{

        [Key]
        int CategoryID{get;set;}
        [Required(ErrorMessage ="Categoria obrigatoria")]
        string Name{get;set;}

    }
}