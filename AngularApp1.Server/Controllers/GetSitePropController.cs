using System.Data;
using System.Text.Json.Nodes;
using System.Text.Unicode;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Online_Buy_Plus.Controllers;

[ApiController]
[Route("[controller]")]
public class GetSitePropController : ControllerBase
{
    private readonly ILogger<GetSitePropController> _logger;

    public GetSitePropController(ILogger<GetSitePropController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetFacebook")]
    public string GetFacebook()
    {
        ef cntxt = new ef();

        var Selected = cntxt.Site.FirstOrDefault();
        if (Selected != null)
        {
            return Selected.Facebook;
        }
        else return "";
    }

    [HttpGet("GetWhatsApp")]
    public string GetWhatsApp()
    {
        ef cntxt = new ef();

        var Selected = cntxt.Site.FirstOrDefault();
        if (Selected != null)
        {
            return Selected.WhatsApp;
        }
        else return "";
    }

    [HttpGet("GetLogo")]
    public string GetLogo()
    {
        ef cntxt = new ef();

        var Selected = cntxt.Site.FirstOrDefault();
        if (Selected != null)
        {
            return Convert.ToBase64String(Selected.Logo);
        }
        else return "";
    }

    [HttpPost("GetProducts")]
    public async Task<List<Product>> GetProducts([FromBody] List<int> CurrentProducts)
    {
        int Count = 8;

        List<Product> All = new List<Product>();

        ef cntxt = new ef();

        var ProSource = await cntxt.Products.OrderBy(r => Guid.NewGuid()).ToArrayAsync();

        if (CurrentProducts.Count() >= ProSource.Count())
        {
            return new List<Product>();
        }

        foreach (Product pro in ProSource)
        {
            if (!CurrentProducts.Contains(pro.ID))
            {
                Count--;

                All.Add(pro);
            }

            if (Count == 0)
            break;
        }

        return All;
    }
}
