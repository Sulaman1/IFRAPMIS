using DAL.Models;
using DAL.Models.Domain.SocialMobilization;
using DAL.Models.Domain.SocialMobilization.Training;
using IFRAPMIS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IFRAPMIS.Controllers.SocialMobilization.Training
{
    public class CITrainingParticipationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CITrainingParticipationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> _Index(int id)
        {
            ViewBag.Id = id;

            var applicationDbContext = _context.CITrainingParticipations
                                                .Include(j => j.CICIG)
                                                .Where(a => a.CICIGTrainingsId == id);

            return PartialView(await applicationDbContext.ToListAsync());
        }
        // GET: CITrainingParticipations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CITrainingParticipations == null)
            {
                return NotFound();
            }
            ViewBag.Id = id;
            var ciTrainingParticipation = await _context.CITrainingParticipations
                .Include(j => j.CICIG)
                .FirstOrDefaultAsync(m => m.CITrainingParticipationId == id);
            if (ciTrainingParticipation == null)
            {
                return NotFound();
            }

            return View(ciTrainingParticipation);
        }

        // GET: CITrainingParticipations/Create
        public IActionResult Create(int id)
        {
            CITrainingParticipation obj = new CITrainingParticipation();

            obj.CICIGTrainingsId = id;
            ViewData["DistrictId"] = new SelectList(_context.Districts/*.Where(a => a.DistrictId > 1)*/, "DistrictName", "DistrictName");

            return View(obj);
        }

        // POST: CITrainingParticipations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CITrainingParticipationId, CICIGId, CICIGTrainingsId")] CITrainingParticipation ciTrainingParticipation, string DistrictId)
        {
            if (ModelState.IsValid)
            {
                /**
                 * if CI is assigned to Training it cant be added to another training
                 * Add all the beneficiaries of that CI to this training
                 */
                var isCIExistInTraining = await _context.CITrainingParticipations.CountAsync(m => m.CICIGId == ciTrainingParticipation.CICIGId);
                if (isCIExistInTraining == 0)
                {
                    _context.Add(ciTrainingParticipation);
                    await _context.SaveChangesAsync();
                    var MemberList = _context.CIMembers.Where(a => a.CICIGId == ciTrainingParticipation.CICIGId).ToList();
                    foreach (var member in MemberList)
                    {
                        var obj = new CITrainingMember();
                        //obj.CreatedOn = DateTime.Now;
                        obj.CICIGTrainingsId = ciTrainingParticipation.CICIGTrainingsId;
                        obj.CIMemberId = member.CIMemberId;
                        _context.CITrainingMembers.Add(obj);
                    }
                    if (MemberList.Count > 0)
                    {
                        await _context.SaveChangesAsync();
                    }
                    return RedirectToAction(nameof(Details), "CICIGTraining", new { id = ciTrainingParticipation.CICIGTrainingsId });
                }               
            }
            ViewData["DistrictId"] = new SelectList(_context.Districts/*.Where(a => a.DistrictId > 1)*/, "DistrictName", "DistrictName"/*, DistrictId*/);

            ViewData["CICIGId"] = new SelectList(_context.CICIGs, "CICIGId", "Name", ciTrainingParticipation.CICIGId);
            return View(ciTrainingParticipation);
        }

        // GET: CITrainingParticipations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CITrainingParticipations == null)
            {
                return NotFound();
            }

            var ciTrainingParticipation = await _context.CITrainingParticipations.FindAsync(id);
            if (ciTrainingParticipation == null)
            {
                return NotFound();
            }
            ViewData["CICIGId"] = new SelectList(_context.CICIGs, "CICIGId", "Name", ciTrainingParticipation.CICIGId);
            return View(ciTrainingParticipation);
        }

        // POST: CITrainingParticipations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CITrainingParticipation ciTrainingParticipation)
        {
            if (id != ciTrainingParticipation.CITrainingParticipationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciTrainingParticipation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CITrainingParticipationExists(ciTrainingParticipation.CITrainingParticipationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = ciTrainingParticipation.CICIGId });
            }
            ViewData["CICIGId"] = new SelectList(_context.CICIGs, "CICIGId", "Name", ciTrainingParticipation.CICIGId);
            return View(ciTrainingParticipation);
        }

        // GET: CITrainingParticipations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CITrainingParticipations == null)
            {
                return NotFound();
            }

            var ciTrainingParticipation = await _context.CITrainingParticipations
                .Include(j => j.CICIG)
                .FirstOrDefaultAsync(m => m.CITrainingParticipationId == id);
            if (ciTrainingParticipation == null)
            {
                return NotFound();
            }

            return View(ciTrainingParticipation);
        }

        // POST: CITrainingParticipations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CITrainingParticipations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CITrainingParticipations'  is null.");
            }
            var ciTrainingParticipation = await _context.CITrainingParticipations.FindAsync(id);
            if (ciTrainingParticipation != null)
            {
                _context.CITrainingParticipations.Remove(ciTrainingParticipation);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), "CICIGTraining", new { id = ciTrainingParticipation.CICIGTrainingsId });

        }

        private bool CITrainingParticipationExists(int id)
        {
            return _context.CITrainingParticipations.Any(e => e.CITrainingParticipationId == id);
        }

        public async Task<JsonResult> GetCIsByDistrictName(string districtName)
        {
            List<CICIG> communityInstitutions = await _context.CICIGs.Where(a => a.District == districtName).ToListAsync();
            var CIList = communityInstitutions.Select(m => new SelectListItem()
            {
                Text = m.Code + " - " + m.Name,
                Value = m.CICIGId.ToString(),
            });
            return Json(CIList);
        }

        public async Task<JsonResult> GetCITrainingsByDistrictName(string districtName)
        {
            List<CICIGTrainings> ciTrainings = await _context.CICIGTrainings.Where(a => a.District == districtName).ToListAsync();
            var ciTrainingsList = ciTrainings.Select(m => new SelectListItem()
            {
                Text = m.TrainingCode + " - " + m.TrainingName,
                Value = m.CICIGTrainingsId.ToString(),
            });
            return Json(ciTrainingsList);
        }

    }
}