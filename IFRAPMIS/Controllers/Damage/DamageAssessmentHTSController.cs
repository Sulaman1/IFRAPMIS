using BAL.IRepository.Damage;
using DAL.Models.Domain.Damage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IFRAPMIS.Controllers.Damage
{
    public class DamageAssessmentHTSController : Controller
    {
        private readonly IDamageAssessmentHTS _context;

        public DamageAssessmentHTSController(IDamageAssessmentHTS context)
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

            var damageAssessmentHTS = await _context.GetById(id);
            if (damageAssessmentHTS == null)
            {
                return NotFound();
            }

            return View(damageAssessmentHTS);
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
        public ActionResult Create([Bind("DamageAssessmentHTSId,DamageAssessmentHTSType")] DamageAssessmentHTS damageAssessmentHTS)
        {
            if (ModelState.IsValid)
            {
                _context.Insert(damageAssessmentHTS);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(damageAssessmentHTS);
        }

        // GET: Proviences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var damageAssessmentHTS = await _context.GetById(id);
            if (damageAssessmentHTS == null)
            {
                return NotFound();
            }
            return View(damageAssessmentHTS);
        }

        // POST: Proviences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("DamageAssessmentHTSId,DamageAssessmentHTSType")] DamageAssessmentHTS damageAssessmentHTS)
        {
            if (id != damageAssessmentHTS.DamageAssessmentHTSId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(damageAssessmentHTS);
                    _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DamageAssessmentHTSExists(damageAssessmentHTS.DamageAssessmentHTSId))
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
            return View(damageAssessmentHTS);
        }

        // GET: Proviences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var damageAssessmentHTS = await _context.GetById(id);
            if (damageAssessmentHTS == null)
            {
                return NotFound();
            }

            return View(damageAssessmentHTS);
        }

        // POST: Proviences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var damageAssessmentHTS = await _context.GetById(id);
            _context.Remove(damageAssessmentHTS);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool DamageAssessmentHTSExists(int id)
        {
            return _context.Exist(id);
        }
    }
}
