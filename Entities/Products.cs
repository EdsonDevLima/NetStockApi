using System.ComponentModel.DataAnnotations;

namespace NetStock.Entities{
    public class Products{

        [Key]
        int ProductID{get;set;}
        [Required(ErrorMessage ="Nome do produto obrigatorio")]
        string Name{get;set;}
        [Required(ErrorMessage ="Quantidade obrigatoria")]
        int Amount{get;set;}
        [Required(ErrorMessage ="Preço obrigatorio")]
        int Price{get;set;}

    }
}