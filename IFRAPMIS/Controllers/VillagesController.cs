using BAL.IRepository.MasterSetup;
using BAL.Services.MasterSetup;
using DAL.Models;
using IFRAPMIS.Data;
using Microsoft.AspNetCore.Mvc;

namespace IFRAPMIS.Controllers
{
    public class VillagesController : Controller
    {
        public IVillage context;
        public VillagesController(IVillage _context) 
        {
            context = _context;    
        }
        public async Task<IActionResult> Index()
        {
            List<Village> vList = await context.GetAll();
            return View();
        }
    }
}
