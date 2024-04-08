using System.ComponentModel.DataAnnotations;

namespace Online_Buy_Plus;

public class Product
{
    public int ID { get; set; }
    [MaxLength(50)]
    public string Title { get; set; }
    public int Price { get; set; }
    public int BuyPrice { get; set; }
    public int Weight { get; set; }
    [MaxLength(1000)]
    public string Details { get; set; }
    [MaxLength(50)]
    public string CategoryString { get; set; }
    public string Image { get; set; }
    public int CountAvailable { get; set; }
    public string Supplier { get; set; }
    public Category Category { get; set; }
}