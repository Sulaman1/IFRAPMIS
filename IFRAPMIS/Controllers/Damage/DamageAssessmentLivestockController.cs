using BAL.IRepository.Damage;
using DAL.Models.Domain.Damage;
using DAL.Models.Domain.MasterSetup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IFRAPMIS.Controllers.Damage
{
    public class DamageAssessmentLivestockController : Controller
    {
        private readonly IDamageAssessmentLivestock _context;

        public DamageAssessmentLivestockController(IDamageAssessmentLivestock context)
        {
            _context = context;
        }

        // GET: Proviences
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: Proviences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var damageAssessmentLivestock = await _context.GetById(id);
            if (damageAssessmentLivestock == null)
            {
                return NotFound();
            }

            return View(damageAssessmentLivestock);
        }

        // GET: Proviences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proviences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("DamageAssessmentLivestockId,DamageAssessmentLivestockType")] DamageAssessmentLivestock damageAssessmentLivestock)
        {
            if (ModelState.IsValid)
            {
                _context.Insert(damageAssessmentLivestock);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(damageAssessmentLivestock);
        }

        // GET: Proviences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var damageAssessmentLivestock = await _context.GetById(id);
            if (damageAssessmentLivestock == null)
            {
                return NotFound();
            }
            return View(damageAssessmentLivestock);
        }

        // POST: Proviences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("DamageAssessmentLivestockId,DamageAssessmentLivestockType")] DamageAssessmentLivestock damageAssessmentLivestock)
        {
            if (id != damageAssessmentLivestock.DamageAssessmentLivestockId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(damageAssessmentLivestock);
                    _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DamageAssessmentLivestockExists(damageAssessmentLivestock.DamageAssessmentLivestockId))
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
            return View(damageAssessmentLivestock);
        }

        // GET: Proviences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provience = await _context.GetById(id);
            if (provience == null)
            {
                return NotFound();
            }

            return View(provience);
        }

        // POST: Proviences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var damageAssessmentLivestock = await _context.GetById(id);
            _context.Remove(damageAssessmentLivestock);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool DamageAssessmentLivestockExists(int id)
        {
            return _context.Exist(id);
        }
    }
}

