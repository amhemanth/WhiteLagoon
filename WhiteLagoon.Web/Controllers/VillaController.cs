using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _dBContext;
        public VillaController(ApplicationDbContext dBContext)
        {
            _dBContext = dBContext;
        }
        public IActionResult Index()
        {
            var villas = _dBContext.Villas.ToList();
            return View();
        }
    }
}
