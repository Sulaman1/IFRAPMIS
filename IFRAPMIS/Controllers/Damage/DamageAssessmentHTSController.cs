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

        // GET: Damage Assessment HTS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Damage Assessment HTS/Create
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

        // GET: Damage Assessment HTS/Edit
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

        // POST: Damage Assessment HTS/Edit
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

        // GET: Damage Assessment HTS/Delete
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

        // POST: Damage Assessment HTS/Delete
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
