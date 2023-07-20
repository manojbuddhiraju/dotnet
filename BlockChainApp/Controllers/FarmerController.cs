using BlockChainApp.Data;
using BlockChainApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BlockChainApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FarmerController : ControllerBase
    {
        private readonly BlockChainAppDbContext _dbcontext;

        public FarmerController(BlockChainAppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }


        [HttpGet]
        [Route("/Farmers")]
        public async Task<IActionResult> Get(string Name, string City, string MobileNumber)
        {
            string response = string.Empty;
            var farmers = await _dbcontext.FarmerData.Where(x => x.Name == Name && x.City == City && x.MobileNumber == MobileNumber).FirstOrDefaultAsync();

            if(farmers != null)
            {
                response = "verified";
            }
            else
            {
                response = "Not Verified";
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("/AddFarmer")]
        public async Task<IActionResult> Post(FarmerData farmerData)
        {
            string response = string.Empty;
            var farmers = await _dbcontext.FarmerData.Where(x => x.Name == farmerData.Name && x.City == farmerData.City && x.MobileNumber == farmerData.MobileNumber).FirstOrDefaultAsync();

            if(farmers == null)
            {
                _dbcontext.FarmerData.Add(farmerData);
                var x = await _dbcontext.SaveChangesAsync();
                if (x == 1)
                {
                    response = "Added Farmer Details";
                }
                else
                {
                    response = "Error Occured";
                }
            }
            else
            {
                response = "Farmer Exist";
            }
            
            return Ok(response);
        }

        [HttpGet]
        [Route("/Login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            string response = string.Empty;
            var login = await _dbcontext.Login.Where(x => x.username == username && x.password == password).FirstOrDefaultAsync();

            if (login != null)
            {
                response = "verified";
            }
            else
            {
                response = "Not Verified";
            }
            return Ok(response);
        }
    }
}
