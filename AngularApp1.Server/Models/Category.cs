using System.ComponentModel.DataAnnotations;

namespace Online_Buy_Plus;

public class Category
{
    [MaxLength(50)]
    [Key]
    public string Name { get; set; }
    public Product Product { get; set; }
    
}