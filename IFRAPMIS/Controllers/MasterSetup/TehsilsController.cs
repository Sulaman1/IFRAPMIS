using BAL.IRepository.MasterSetup;
using DAL.Models.Domain.MasterSetup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IFRAPMIS.Controllers.MasterSetup
{
    public class TehsilsController : Controller
    {
        private readonly ITehsil _context;

        public TehsilsController(ITehsil context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Tehsil> tehsils = await _context.GetAll();
            return View(tehsils);
        }
        // GET: Tehsils           
        // GET: Tehsils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tehsil = await _context.GetById(id);
            if (tehsil == null)
            {
                return NotFound();
            }

            return View(tehsil);
        }

        // GET: Tehsils/Create
        public async Task<IActionResult> Create()
        {
            var allDistricts = await _context.GetAllDistrict();
            
            var districts = new List<SelectListItem>();
            foreach (var district in allDistricts)
            {
                districts.Add(new SelectListItem { Value = district.DistrictId.ToString(), Text = district.DistrictName });
            }                      

            ViewBag.DistrictId = new SelectList(districts, "Value", "Text");            
           
            return View();
        }

        // POST: Tehsils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TehsilId,TehsilName,DistrictId")] Tehsil tehsil)
        {
            if (ModelState.IsValid)
            {
                var result = _context.Count(tehsil.TehsilName);
                if (result > 0)
                {
                    ModelState.AddModelError(nameof(tehsil.TehsilName), "Tehsil already exist!");
                    return View(tehsil);
                }
                _context.Insert(tehsil);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["DistrictId"] = new SelectList(_context.GetAllDistrict().Result.Where(a => a.DistrictId > 1), "DistrictId", "Name", tehsil.DistrictId);
            var allDistricts = await _context.GetAllDistrict();

            var districts = new List<SelectListItem>();
            foreach (var district in allDistricts)
            {
                districts.Add(new SelectListItem { Value = district.DistrictId.ToString(), Text = district.DistrictName });
            }

            ViewBag.DistrictId = new SelectList(districts, "Value", "Text");
            return View(tehsil);
        }

        // GET: Tehsils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tehsil = await _context.GetById(id);
            if (tehsil == null)
            {
                return NotFound();
            }
            ViewData["DistrictId"] = new SelectList(_context.GetAllDistrict().Result.Where(a => a.DistrictId > 1), "DistrictId", "Name", tehsil.DistrictId);
            //ViewData["DistrictId"] = new SelectList(_context.GetAllDistrict(), "DistrictId", "Name");
            return View(tehsil);
        }

        // POST: Tehsils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TehsilId,TehsilName,DistrictId")] Tehsil tehsil)
        {
            if (id != tehsil.TehsilId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = _context.Count(tehsil.TehsilName);
                if (result > 0)
                {
                    ModelState.AddModelError(nameof(tehsil.TehsilName), "Tehsil already exist!");
                    return View(tehsil);
                }
                try
                {
                    _context.Update(tehsil);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TehsilExists(tehsil.TehsilId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistrictId"] = new SelectList(_context.GetAllDistrict().Result.Where(a => a.DistrictId > 1), "DistrictId", "Name", tehsil.DistrictId);
            //ViewData["DistrictId"] = new SelectList(_context.GetAllDistrict(), "DistrictId", "Name");
            return View(tehsil);
        }

        // GET: Tehsils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tehsil = await _context.GetById(id);
            if (tehsil == null)
            {
                return NotFound();
            }

            return View(tehsil);
        }

        // POST: Tehsils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tehsil = await _context.GetById(id);
            _context.Remove(tehsil);
            return RedirectToAction(nameof(Index));
        }
        private bool TehsilExists(int id)
        {
            return _context.Exist(id);
        }
    }
}
