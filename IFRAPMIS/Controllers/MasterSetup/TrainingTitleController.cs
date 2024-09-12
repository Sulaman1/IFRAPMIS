using BAL.IRepository.MasterSetup;
using DAL.Models.Domain.MasterSetup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IFRAPMIS.Controllers.MasterSetup
{
    public class TrainingTitleController : Controller
    {

        private readonly ITrainingTitle _context;

        public TrainingTitleController(ITrainingTitle context)
        {
            _context = context;
        }

        // GET: TrainingTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: TrainingTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingTitle = await _context.GetById(id);
            if (trainingTitle == null)
            {
                return NotFound();
            }

            return View(trainingTitle);
        }

        // GET: TrainingTypes/Create
        public IActionResult Create()
        {
            ViewData["TrainingHeadId"] = new SelectList(_context.GetAllTrainingHead(), "TrainingHeadId", "TrainingHeadName");
            return View();
        }

        // POST: TrainingTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainingTitle trainingTitle)
        {
            if (ModelState.IsValid)
            {
                var result = _context.Count(trainingTitle.TrainingName);
                if (result > 0)
                {
                    ModelState.AddModelError(nameof(trainingTitle.TrainingName), "Name already exist!");
                    return View(trainingTitle);
                }
                _context.Insert(trainingTitle);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrainingHeadId"] = new SelectList(_context.GetAllTrainingHead(), "TrainingHeadId", "TrainingHeadName", trainingTitle.TrainingHeadId);
            return View(trainingTitle);
        }

        // GET: TrainingTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingTitle = await _context.GetById(id);
            if (trainingTitle == null)
            {
                return NotFound();
            }
            ViewData["TrainingHeadId"] = new SelectList(_context.GetAllTrainingHead(), "TrainingHeadId", "TrainingHeadName", trainingTitle.TrainingHeadId);
            return View(trainingTitle);
        }

        // POST: TrainingTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TrainingTitle trainingTitle)
        {
            if (id != trainingTitle.TitleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result = _context.Count(trainingTitle.TrainingName);
                    if (result > 1)
                    {
                        ModelState.AddModelError(nameof(trainingTitle.TrainingName), "Name already exist!");
                        return View(trainingTitle);
                    }
                    _context.Update(trainingTitle);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingTypeExists(trainingTitle.TitleId))
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
            ViewData["TrainingHeadId"] = new SelectList(_context.GetAllTrainingHead(), "TrainingHeadId", "TrainingHeadName", trainingTitle.TrainingHeadId);
            return View(trainingTitle);
        }

        // GET: TrainingTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingTitle = await _context.GetById(id);
            if (trainingTitle == null)
            {
                return NotFound();
            }

            return View(trainingTitle);
        }

        // POST: TrainingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var trainingTitle = await _context.GetById(id);
            if (trainingTitle != null)
            {
                _context.Remove(trainingTitle);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TrainingTypeExists(int id)
        {
            return _context.Exist(id);
        }
    }
}
