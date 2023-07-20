using Microsoft.EntityFrameworkCore;

namespace BlockChainApp.Data.Entities
{
    [Keyless]
    public class Login
    {
        public string username { get; set; }
        public string password { get; set; }
        public string city { get; set; }
        public string web3Account { get; set; }
    }
}
