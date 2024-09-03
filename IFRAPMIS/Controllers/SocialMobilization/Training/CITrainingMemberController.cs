using DAL.Models;
using DAL.Models.Domain.SocialMobilization.Training;
using IFRAPMIS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using DAL.Models.Domain.MasterSetup;

namespace IFRAPMIS.Controllers.SocialMobilization.Training
{

    public class CITrainingMemberController : Controller
    {
        public class CIMemberDTO
        {
            public int CIMemberId { get; set; }
            public string MemberCode { get; set; }

            // Assuming BeneficiaryVerified is a related entity, create a DTO for it as well
            public BeneficiaryVerifiedDTO BeneficiaryVerified { get; set; }

            // Add other properties you need to expose
        }
        public class BeneficiaryVerifiedDTO
        {
            public string CNIC { get; set; }
            public string BeneficiaryName { get; set; }
            public string BeneficiaryFather { get; set; }
            public string Mobile { get; set; }
            public string Gender { get; set; }

            // Add other properties from BeneficiaryVerified if needed
        }

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CITrainingMemberController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CITrainingMembers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = await _context.CITrainingMembers
                                                .Include(m => m.CIMember)
                                                    .ThenInclude(cim => cim.BeneficiaryVerified)
                                                .Include(m => m.CICIGTrainings)
                                                .ToListAsync();
            return View(applicationDbContext);
        }
        public async Task<IActionResult> _Index(int id)
        {
            var applicationDbContext = await _context.CITrainingMembers
                                                .Include(m => m.CIMember)
                                                    .ThenInclude(cim => cim.BeneficiaryVerified)
                                                .Include(m => m.CICIGTrainings)
                                                //.Include(a => a.CIMember.Designation)
                                                .Where(a => a.CICIGTrainingsId == id)
                                                .ToListAsync();

            var ciTrainMember = applicationDbContext;
            return PartialView(ciTrainMember);
        }
        public async Task<IActionResult> TrackMember(int id)
        {
            ViewBag.MTId = id;
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> AjaxMemberInformation(string id)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            /**
             *  MemberId 1
             *  CICIGId 3
             *  
             */
            var info = _context.CIMembers
                .Include(a => a.CICIG)
                .Include(a => a.BeneficiaryVerified)
                .Where(a => a.BeneficiaryVerified.CNIC == id /*&& a.BeneficiaryVerified.BeneficiaryTypeId == 1*/ && a.CICIG.IsVerified == true)
                .FirstOrDefault();
            if (info == null)
            {
                return new JsonResult(new { isValid = false, message = "No data found" });
            }
            var infoDto = new CIMemberDTO
            {
                CIMemberId = info.CIMemberId,
                MemberCode = info.MemberCode,
                BeneficiaryVerified = new BeneficiaryVerifiedDTO
                {
                    CNIC = info.BeneficiaryVerified.CNIC,
                    BeneficiaryName = info.BeneficiaryVerified.BeneficiaryName,
                    BeneficiaryFather = info.BeneficiaryVerified.BeneficiaryFather,
                    Mobile = info.BeneficiaryVerified.Mobile,
                    Gender = info.BeneficiaryVerified.Gender
                }
            };
            //if (currentUser.DistrictId > 1)   
            //{
            //Info = Info.CICIG.District == currentUser.DistrictName ? Info : null;
            //}
            //if (Info == null)
            //{

            //    return Json(new { isValid = false, Info, count = 0, message = "" });
            //}
            var AnyOtherTraining = _context.CITrainingMembers.Include(a => a.CIMember.CICIG.Village.UnionCouncils.Tehsil).Include(a => a.CICIGTrainings.TrainingTitle.TrainingHead).Where(a => a.CIMember.CIMemberId == info.CIMemberId).ToList();


            string abounttrainings = "";
            if (AnyOtherTraining.Count() > 0)
            {
                abounttrainings += "Selected member has already taken (" + AnyOtherTraining.Count().ToString() + ") training(s).";
                int counter = 1;
                foreach (var a in AnyOtherTraining)
                {
                    abounttrainings += "(" + counter++ + ") Tehsil: " + a.CIMember.CICIG.Village.UnionCouncils.Tehsil.TehsilName + ", UC: " + a.CIMember.CICIG.Village.UnionCouncils.UnionCouncilName + ", Training Head: " + a.CICIGTrainings.TrainingTitle.TrainingHead.TrainingHeadName + ", Training Type: " + a.CICIGTrainings.TrainingTitle + ", Training Title: " + a.CICIGTrainings.TrainingName + ". ";

                }
            }
            /**
             * BeneficiaryVerified.BeneficiaryName
             * BeneficiaryVerified.BeneficiaryFather
             * BeneficiaryVerified.cnic
             * BeneficiaryVerified.membercode
             * BeneficiaryVerified.mobile
             * BeneficiaryVerified.gender
             */
            //var options = new JsonSerializerOptions
            //{
            //    ReferenceHandler = ReferenceHandler.Preserve,
            //    // Other options if needed
            //};
            return new JsonResult(new { isValid = true, info = infoDto, count = AnyOtherTraining.Count(), message = abounttrainings });
            //return Json(new { isValid = true, Info = infoDto, count = AnyOtherTraining.Count(), message = abounttrainings }, JsonRequestBehavior.AllowGet);
            //return Json(new { isValid = true, Info = JsonSerializer.Serialize(infoDto, options), count = AnyOtherTraining.Count(), message = abounttrainings });
            //return Json(new { isValid = true, Info, count = AnyOtherTraining.Count(), message = abounttrainings });
        }
        public async Task<JsonResult> AddBeneficiaryInTraining(int CDMId, int MTId)
        {
            var result = _context.CITrainingMembers.Count(a => a.CIMemberId == CDMId && a.CICIGTrainingsId == MTId);
            if (CDMId == 0 || MTId == 0)
            {
                return Json(new { isValid = false, message = "Failed to Add BeneficiaryVerified!" });
            }
            else if (result > 0)
            {
                return Json(new { isValid = false, message = "Selected member is already added!" });
            }
            else
            {
                CITrainingMember obj = new CITrainingMember();
                obj.CIMemberId = CDMId;
                obj.CICIGTrainingsId = MTId;
                //obj.CreatedOn = DateTime.Today.Date;
                _context.Add(obj);
                var memberTrainingObj = _context.CICIGTrainings.Find(MTId);
                memberTrainingObj.TotalMembersParticipated += 1;
                _context.Update(memberTrainingObj);
                await _context.SaveChangesAsync();
            }
            return Json(new { isValid = true, message = "BeneficiaryVerified has been added successfully." });
        }
        // GET: CITrainingMemberss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CITrainingMembers == null)
            {
                return NotFound();
            }

            var memberTrainingDetail = await _context.CITrainingMembers
                .Include(m => m.CIMember)
                .Include(m => m.CICIGTrainings)
                .FirstOrDefaultAsync(m => m.CICIGTrainingsId == id);
            if (memberTrainingDetail == null)
            {
                return NotFound();
            }
            return View(memberTrainingDetail);
        }

        // GET: CITrainingMembers/Create
        public IActionResult Create()
        {
            var ciMembers = _context.CIMembers.Include(cim => cim.BeneficiaryVerified);
            ViewData["CIMemberId"] = new SelectList(ciMembers, "CIMemberId", "BeneficiaryVerified.CNIC");
            ViewData["CICIGTrainingsId"] = new SelectList(_context.CICIGTrainings, "CICIGTrainingsId", "CICIGTrainingsId");
            return View();
        }

        // POST: CITrainingMemberss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CITrainingMembersId,CICIGTrainingId,CIMemberId")] CITrainingMember memberTrainingDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memberTrainingDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var ciMembers = _context.CIMembers.Include(cim => cim.BeneficiaryVerified);
            ViewData["CIMemberId"] = new SelectList(ciMembers, "CIMemberId", "BeneficiaryVerified.CNIC", memberTrainingDetail.CIMemberId);
            ViewData["CICIGTrainingsId"] = new SelectList(_context.CICIGTrainings, "CICIGTrainingsId", "CICIGTrainingsId", memberTrainingDetail.CICIGTrainingsId);
            return View(memberTrainingDetail);
        }

        // GET: CITrainingMemberss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CITrainingMembers == null)
            {
                return NotFound();
            }

            var memberTrainingDetail = await _context.CITrainingMembers.FindAsync(id);
            if (memberTrainingDetail == null)
            {
                return NotFound();
            }
            var ciMembers = _context.CIMembers.Include(cim => cim.BeneficiaryVerified);
            ViewData["CIMemberId"] = new SelectList(ciMembers, "CIMemberId", "BeneficiaryVerified.CNIC", memberTrainingDetail.CIMemberId);
            ViewData["CICIGTrainingsId"] = new SelectList(_context.CICIGTrainings, "CICIGTrainingsId", "CICIGTrainingsId", memberTrainingDetail.CICIGTrainingsId);
            return View(memberTrainingDetail);
        }

        // POST: CITrainingMemberss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CITrainingMemberId,CICIGTrainingsId,CIMemberId")] CITrainingMember memberTrainingDetail)
        {
            if (id != memberTrainingDetail.CITrainingMemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memberTrainingDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CITrainingMembersExists(memberTrainingDetail.CITrainingMemberId))
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
            var ciMembers = _context.CIMembers.Include(cim => cim.BeneficiaryVerified);
            ViewData["CIMemberId"] = new SelectList(ciMembers, "CIMemberId", "BeneficiaryVerified.CNIC", memberTrainingDetail.CIMemberId);
            ViewData["CICIGTrainingId"] = new SelectList(_context.CICIGTrainings, "CICIGTrainingId", "CICIGTrainingId", memberTrainingDetail.CICIGTrainingsId);
            return View(memberTrainingDetail);
        }

        // GET: CITrainingMemberss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CITrainingMembers == null)
            {
                return NotFound();
            }

            var memberTrainingDetail = await _context.CITrainingMembers
                .Include(m => m.CIMember.BeneficiaryVerified)
                .Include(m => m.CICIGTrainings)
                .FirstOrDefaultAsync(m => m.CITrainingMemberId == id);
            if (memberTrainingDetail == null)
            {
                return NotFound();
            }

            return View(memberTrainingDetail);
        }

        // POST: CITrainingMemberss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CITrainingMembers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CITrainingMembers'  is null.");
            }
            var memberTrainingDetail = await _context.CITrainingMembers.FindAsync(id);
            if (memberTrainingDetail != null)
            {
                _context.CITrainingMembers.Remove(memberTrainingDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Details), "CICIGTrainings", new { id = memberTrainingDetail.CICIGTrainingsId });
        }

        private bool CITrainingMembersExists(int id)
        {
            return _context.CITrainingMembers.Any(e => e.CITrainingMemberId == id);
        }
    }
}

