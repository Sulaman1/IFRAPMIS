//using DAL.Models;
//using IFRAPMIS.Data;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;

//namespace IFRAPMIS.Controllers.SocialMobilization.Training
//{
//    public class CITrainingParticipationController : Controller
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly UserManager<ApplicationUser> _userManager;
//        public CITrainingParticipationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
//        {
//            _context = context;
//            _userManager = userManager;
//        }

//        public async Task<IActionResult> _Index(int id)
//        {
//            ViewBag.Id = id;
//            var applicationDbContext = _context.MemberTrainingCICIG.Include(j => j.CommunityInstitution).Where(a => a.MemberTrainingId == id);
//            return PartialView(await applicationDbContext.ToListAsync());
//        }
//        // GET: MemberTrainingCICIGs/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.MemberTrainingCICIG == null)
//            {
//                return NotFound();
//            }
//            ViewBag.Id = id;
//            var memberTrainingCICIG = await _context.MemberTrainingCICIG
//                .Include(j => j.CommunityInstitution)
//                .FirstOrDefaultAsync(m => m.MemberTrainingCICIGId == id);
//            if (memberTrainingCICIG == null)
//            {
//                return NotFound();
//            }

//            return View(memberTrainingCICIG);
//        }

//        // GET: MemberTrainingCICIGs/Create
//        public IActionResult Create(int id)
//        {
//            MemberTrainingCICIG obj = new MemberTrainingCICIG();
//            obj.MemberTrainingId = id;
//            ViewData["DistrictId"] = new SelectList(_context.District.Where(a => a.DistrictId > 1), "DistrictId", "Name");
//            return View(obj);
//        }

//        // POST: MemberTrainingCICIGs/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(MemberTrainingCICIG memberTrainingCICIG, int DistrictId)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(memberTrainingCICIG);
//                await _context.SaveChangesAsync();
//                var MemberList = _context.CommunityInstituteMember.Where(a => a.CommunityInstitutionId == memberTrainingCICIG.CommunityInstitutionId).ToList();
//                foreach (var member in MemberList)
//                {
//                    var obj = new MemberTrainingDetail();
//                    obj.CreatedOn = DateTime.Now;
//                    obj.MemberTrainingId = memberTrainingCICIG.MemberTrainingId;
//                    obj.CommunityInstituteMemberId = member.CommunityInstituteMemberId;
//                    _context.MemberTrainingDetail.Add(obj);
//                }
//                if (MemberList.Count > 0)
//                {
//                    await _context.SaveChangesAsync();
//                }
//                return RedirectToAction(nameof(Index), "MemberTrainings", new { id = memberTrainingCICIG.CommunityInstitutionId });
//            }
//            ViewData["DistrictId"] = new SelectList(_context.District.Where(a => a.DistrictId > 1), "DistrictId", "Name", DistrictId);
//            ViewData["CommunityInstitutionId"] = new SelectList(_context.CommunityInstitution, "CommunityInstitutionId", "Name", memberTrainingCICIG.CommunityInstitutionId);
//            return View(memberTrainingCICIG);
//        }

//        // GET: MemberTrainingCICIGs/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.MemberTrainingCICIG == null)
//            {
//                return NotFound();
//            }

//            var memberTrainingCICIG = await _context.MemberTrainingCICIG.FindAsync(id);
//            if (memberTrainingCICIG == null)
//            {
//                return NotFound();
//            }
//            ViewData["CommunityInstitutionId"] = new SelectList(_context.CommunityInstitution, "CommunityInstitutionId", "Name", memberTrainingCICIG.CommunityInstitutionId);
//            return View(memberTrainingCICIG);
//        }

//        // POST: MemberTrainingCICIGs/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, MemberTrainingCICIG memberTrainingCICIG)
//        {
//            if (id != memberTrainingCICIG.MemberTrainingCICIGId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(memberTrainingCICIG);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!MemberTrainingCICIGExists(memberTrainingCICIG.MemberTrainingCICIGId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index), new { id = memberTrainingCICIG.CommunityInstitutionId });
//            }
//            ViewData["CommunityInstitutionId"] = new SelectList(_context.CommunityInstitution, "CommunityInstitutionId", "Name", memberTrainingCICIG.CommunityInstitutionId);
//            return View(memberTrainingCICIG);
//        }

//        // GET: MemberTrainingCICIGs/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.MemberTrainingCICIG == null)
//            {
//                return NotFound();
//            }

//            var memberTrainingCICIG = await _context.MemberTrainingCICIG
//                .Include(j => j.CommunityInstitution)
//                .FirstOrDefaultAsync(m => m.MemberTrainingCICIGId == id);
//            if (memberTrainingCICIG == null)
//            {
//                return NotFound();
//            }

//            return View(memberTrainingCICIG);
//        }

//        // POST: MemberTrainingCICIGs/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.MemberTrainingCICIG == null)
//            {
//                return Problem("Entity set 'ApplicationDbContext.MemberTrainingCICIG'  is null.");
//            }
//            var memberTrainingCICIG = await _context.MemberTrainingCICIG.FindAsync(id);
//            if (memberTrainingCICIG != null)
//            {
//                _context.MemberTrainingCICIG.Remove(memberTrainingCICIG);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index), "MemberTrainings", new { id = memberTrainingCICIG.CommunityInstitutionId });
//        }

//        private bool MemberTrainingCICIGExists(int id)
//        {
//            return _context.MemberTrainingCICIG.Any(e => e.MemberTrainingCICIGId == id);
//        }

//        public async Task<JsonResult> GetCIs(int districtId)
//        {
//            List<CommunityInstitution> communityInstitutions = await _context.CommunityInstitution.Where(a => a.DistrictId == districtId).ToListAsync();
//            var CIList = communityInstitutions.Select(m => new SelectListItem()
//            {
//                Text = m.CICode + " - " + m.Name,
//                Value = m.CommunityInstitutionId.ToString(),
//            });
//            return Json(CIList);
//        }
//    }
//}
