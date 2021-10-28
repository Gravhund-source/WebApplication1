using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Code;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IHashing _iHashing;
        //private readonly IDataProtector _protector;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_iHashing = iHashing;
            //_protector = protector.CreateProtector("WebApplication1.HomeController.VictorGawron");
        }

        public IActionResult Index()
        {
            //Running Encryption....
            //IndexModel? indexModel = null;
            //string hashedValueAsString = null;
            //if (Password != null)
            //{
            //    hashedValueAsString = _iHashing.BcryptHash(Password);
            //    indexModel = new IndexModel() { HashedValueAsString = hashedValueAsString, OriginalText = Password };
            //}

            ////Running Encryption....
            ////string payload = "Victor Gawron";
            //if (CryptoName != null)
            //{
            //    string protectedPayload = _protector.Protect(CryptoName);

            //    string UnprotectedPayload = _protector.Unprotect(protectedPayload);
            //    indexModel = new IndexModel() { OriginalEncryptionText = UnprotectedPayload, EncryptedValueAsString = protectedPayload };
            //}    

            return View();
            //return View(model: indexModel);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}