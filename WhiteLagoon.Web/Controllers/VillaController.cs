using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Domain.Entities;
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
            return View(villas);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Villa villa)
        {
            if(villa.Name == villa.Description)
            {
                ModelState.AddModelError("", "The description cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _dBContext.Villas.Add(villa);
                _dBContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
