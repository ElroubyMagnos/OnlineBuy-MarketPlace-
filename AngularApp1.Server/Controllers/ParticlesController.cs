using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Buy_Plus.Models;
using OnlineBuyDB.Models;

namespace Online_Buy_Plus.Controllers;

[ApiController]
[Route("[controller]")]
public class ParticlesController : ControllerBase
{
    private readonly ILogger<ParticlesController> _logger;

    public ParticlesController(ILogger<ParticlesController> logger)
    {
        _logger = logger;
    }

    [HttpGet("CheckBillNumber/{billnumber}")]
    public async Task<bool> CheckBillNumber(int billnumber)
    {
        ef cntxt = new ef();

        var Selected = await cntxt.Fwater.FirstOrDefaultAsync(x => x.Number == billnumber);

        return Selected != null;
    }

    [HttpGet("GetBranches")]
    public async Task<List<Branch>> GetBranches()
    {
        ef cntxt = new ef();

        return cntxt.Branches.ToList();
    }

    [HttpGet("SendBillChat/{msg}/{billnumber}")]
    public async Task<bool> SendBillChat(string msg, int billnumber)
    {
        ef cntxt = new ef();
        cntxt.BillChat.Add(new OnlineBuyDB.Models.BillChat()
        {
            BillNumber = billnumber,
            Message = msg,
            SeenByEmployee = false,
            Sender = billnumber.ToString(),
        });

        await cntxt.SaveChangesAsync();

        return true;
    }

    [HttpGet("SendResChat/{msg}/{billnumber}")]
    public async Task<bool> SendResChat(string msg, int billnumber)
    {
        ef cntxt = new ef();
        cntxt.RChat.Add(new ReserveChat()
        {
            BillNumber = billnumber,
            Message = msg,
            Sender = billnumber.ToString(),
        });

        await cntxt.SaveChangesAsync();

        return true;
    }

    [HttpPost("ReceiveFatora")]
    public async Task<bool> ReceiveFatora([FromBody] Fatora Fatora)
    {
        if (Fatora != null)
        {
            ef cntxt = new ef();

            await cntxt.Fwater.AddAsync(Fatora);

            await cntxt.SaveChangesAsync();

            return true;
        }

        return false;
    }

    [HttpGet("SendFatora/{id}")]
    public async Task<Fatora> SendFatora(int id)
    {
        ef cntxt = new ef();

        return await cntxt.Fwater.FirstOrDefaultAsync(x => x.Number == id);
    }

    [HttpGet("GetBillMsgs/{id}")]
    public async Task<List<BillChat>> GetBillMsgs(int id)
    {
        ef cntxt = new ef();

        return await cntxt.BillChat.Where(x => x.BillNumber == id).Take(10).ToListAsync();
    }

    [HttpGet("GetResMsgs/{id}")]
    public async Task<List<ReserveChat>> GetResMsgs(int id)
    {
        ef cntxt = new ef();

        return await cntxt.RChat.Where(x => x.BillNumber == id).Take(10).ToListAsync();
    }

    [HttpGet("GetAllProductsID/{BillNumber}")]
    public async Task<List<Product>> GetAllProductsID(int BillNumber)
    {
        ef cntxt = new ef();

        List<Product> Buyed = new List<Product>();

        var Selected = await cntxt.Fwater.FirstOrDefaultAsync(x => x.Number == BillNumber);

        foreach (var pro in Selected.AllProductsID.Split(','))
        {
            if (pro.Length > 0)
            {
                Buyed.Add(await cntxt.Products.FirstOrDefaultAsync(x => x.ID.ToString() == pro));
            }
        }

        return Buyed;
    }
}
