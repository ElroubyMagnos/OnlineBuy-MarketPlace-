using System.ComponentModel.DataAnnotations;

namespace Online_Buy_Plus;

public class Fatora
{
    public int ID { get; set; }
    public int AllPrice { get; set; }
    public int AllWeight { get; set; }
    public int Number { get; set; }
    public string AllProductsID { get; set; }
    public bool Delivery { get; set; }
    public string BuyerAddress { get; set; }
    public int BuyerPhone { get; set; }
    public bool IsReady { get; set; } = false;
    public bool Closed { get; set; } = false;
    public bool Finished { get; set; } = false;
    public string BranchName { get; set; }
    public DateTime When { get; set; }
}