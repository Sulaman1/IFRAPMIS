using DAL.Models;
using DAL.Models.Domain.TechTrainingnamespace;
using IFRAPMIS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IFRAPMIS.Controllers.TechTrainingnamespace
{
    public class TechTrainingMemberController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public TechTrainingMemberController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: TechTrainingMembers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TechTrainingMembers.Include(m => m.BeneficiaryVerified).Include(m => m.TechTraining);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> _Index(int id)
        {
            var applicationDbContext = await _context.TechTrainingMembers.Include(m => m.BeneficiaryVerified).Include(m => m.TechTraining).Where(a => a.TechTrainingId == id).ToListAsync();
            return PartialView(applicationDbContext);
        }
        public async Task<IActionResult> TrackMember(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> AjaxMemberInformation(string id)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var Info = _context.BeneficiaryVerifieds.Where(a => a.CNIC == id).FirstOrDefault();

            if (Info != null)
            {
                return Json(new { isValid = true, Info, message = "Fetch data successfully!" });
            }

            return Json(new { isValid = false, Info, message = "Beneficiary data not found!" });
        }
        public async Task<JsonResult> AddBeneficiaryInTraining(int MId, int TId)
        {
            var result = _context.TechTrainingMembers.Count(a => a.BeneficiaryVerified.BeneficiaryVerifiedId == MId && a.TechTrainingId == TId);
            if (MId == 0 || TId == 0)
            {
                return Json(new { isValid = false, message = "Failed to Add Member!" });
            }
            else if (result > 0)
            {
                return Json(new { isValid = false, message = "Selected member is already added!" });
            }
            else
            {
                TechTrainingMember obj = new TechTrainingMember();
                obj.TechTrainingId = TId;
                //obj.Age = age;
                obj.BeneficiaryVerifiedId = MId;
                obj.Designation = "";
                obj.IdentifiedBy = "";
                obj.PWD = "";
                //obj.RPL = "";
                obj.PreferredSkill1 = "";
                obj.PreferredSkill2 = "";
                obj.PreferredSkill3 = "";
                obj.PreferredSkill4 = "";
                obj.SelfEmployed = "";
                obj.CreatedOn = DateTime.Today.Date;
                //---------
                var TCode = _context.TechTrainings.Find(TId).TrainingCode;
                var TrainingMemberCount = _context.TechTrainingMembers.Count(a => a.TechTrainingId == TId) + 1;
                string val = (TrainingMemberCount).ToString("D3");
                obj.BeneficiaryTrainingCode = (TCode + "-" + val);
                while (_context.TechTrainingMembers.Count(a => a.BeneficiaryTrainingCode == obj.BeneficiaryTrainingCode) > 0)
                {
                    val = (++TrainingMemberCount).ToString("D3");
                    obj.BeneficiaryTrainingCode = (TCode + "-" + val);
                }
                //---------
                // Add the object explicitly
                _context.TechTrainingMembers.Add(obj);
                await _context.SaveChangesAsync();
                //_context.Add(obj);              
                //await _context.SaveChangesAsync();
            }
            return Json(new { isValid = true, message = "Member has been added successfully." });
        }                           
        
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TechTrainingMembers == null)
            {
                return NotFound();
            }

            var tVTTrainingMember = await _context.TechTrainingMembers.FindAsync(id);
            if (tVTTrainingMember == null)
            {
                return NotFound();
            }
            //ViewData["IdentifiedById"] = new SelectList(_context.IdentifiedBy, "Name", "Name");
            //ViewData["DesignationId"] = new SelectList(_context.Designation, "DesignationName", "DesignationName");



            //ViewData["MemberTrainingId"] = new SelectList(_context.MemberTraining, "MemberTrainingId", "MemberTrainingId", tVTTrainingMember.MemberTrainingId);
            return View(tVTTrainingMember);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TechTrainingMember tVTTrainingMember, IFormFile EducationDocAttachment, IFormFile CNICAttachment, IFormFile AdmissionFormAttachment)
        {
            if (id != tVTTrainingMember.TechTrainingMemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (EducationDocAttachment != null && EducationDocAttachment.Length > 0)
                    {
                        var rootPath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\TVTTrainingMember" + tVTTrainingMember.BeneficiaryVerifiedId.ToString() + "\\EduDoc\\");
                        string fileName = Path.GetFileName(EducationDocAttachment.FileName);
                        Random random = new Random();
                        int randomNumber = random.Next(999, 100000);
                        fileName = "EduDoc" + randomNumber.ToString() + Path.GetExtension(fileName);
                        tVTTrainingMember.EducationDocAttachment = Path.Combine("/Documents/TVTTrainingMember" + tVTTrainingMember.BeneficiaryVerifiedId.ToString() + "/EduDoc/" + fileName);//Server Path
                        string sPath = Path.Combine(rootPath);
                        if (!System.IO.Directory.Exists(sPath))
                        {
                            System.IO.Directory.CreateDirectory(sPath);
                        }
                        string FullPathWithFileName = Path.Combine(sPath, fileName);
                        using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                        {
                            await EducationDocAttachment.CopyToAsync(stream);
                        }
                    }
                    if (CNICAttachment != null && CNICAttachment.Length > 0)
                    {
                        var rootPath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\TVTTrainingMember" + tVTTrainingMember.BeneficiaryVerifiedId.ToString() + "\\CNIC\\");
                        string fileName = Path.GetFileName(CNICAttachment.FileName);
                        Random random = new Random();
                        int randomNumber = random.Next(999, 100000);
                        fileName = "CNIC" + randomNumber.ToString() + Path.GetExtension(fileName);
                        tVTTrainingMember.CNICAttachment = Path.Combine("/Documents/TVTTrainingMember" + tVTTrainingMember.BeneficiaryVerifiedId.ToString() + "/CNIC/" + fileName);//Server Path
                        string sPath = Path.Combine(rootPath);
                        if (!System.IO.Directory.Exists(sPath))
                        {
                            System.IO.Directory.CreateDirectory(sPath);
                        }
                        string FullPathWithFileName = Path.Combine(sPath, fileName);
                        using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                        {
                            await CNICAttachment.CopyToAsync(stream);
                        }
                    }
                    if (AdmissionFormAttachment != null && AdmissionFormAttachment.Length > 0)
                    {
                        var rootPath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\TVTTrainingMember" + tVTTrainingMember.BeneficiaryVerifiedId.ToString() + "\\AForm\\");
                        string fileName = Path.GetFileName(AdmissionFormAttachment.FileName);
                        Random random = new Random();
                        int randomNumber = random.Next(999, 100000);
                        fileName = "AForm" + randomNumber.ToString() + Path.GetExtension(fileName);
                        tVTTrainingMember.AdmissionFormAttachment = Path.Combine("/Documents/TVTTrainingMember" + tVTTrainingMember.BeneficiaryVerifiedId.ToString() + "/AForm/" + fileName);//Server Path
                        string sPath = Path.Combine(rootPath);
                        if (!System.IO.Directory.Exists(sPath))
                        {
                            System.IO.Directory.CreateDirectory(sPath);
                        }
                        string FullPathWithFileName = Path.Combine(sPath, fileName);
                        using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                        {
                            await AdmissionFormAttachment.CopyToAsync(stream);
                        }
                    }
                    _context.Update(tVTTrainingMember);

                    var member = _context.BeneficiaryVerifieds.Find(tVTTrainingMember.BeneficiaryVerifiedId);
                    member.Age = tVTTrainingMember.Age;
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TVTTrainingMemberExists(tVTTrainingMember.TechTrainingMemberId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(TrackMember), "TVTTrainingMembers", new { id = tVTTrainingMember.TechTrainingId });
            }
            //ViewData["IdentifiedById"] = new SelectList(_context.IdentifiedBy, "Name", "Name", tVTTrainingMember.IdentifiedBy);
            //ViewData["DesignationId"] = new SelectList(_context.Designation, "DesignationName", "DesignationName", tVTTrainingMember.Designation);
            return View(tVTTrainingMember);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TechTrainingMembers == null)
            {
                return NotFound();
            }

            var tVTTrainingMember = await _context.TechTrainingMembers
                .Include(m => m.BeneficiaryVerified)
                .Include(m => m.TechTraining)
                .FirstOrDefaultAsync(m => m.TechTrainingMemberId == id);
            if (tVTTrainingMember == null)
            {
                return NotFound();
            }

            return View(tVTTrainingMember);
        }

        // POST: TVTTrainingMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TechTrainingMembers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TVTTrainingMember'  is null.");
            }
            var tVTTrainingMember = await _context.TechTrainingMembers.FindAsync(id);
            if (tVTTrainingMember != null)
            {
                _context.TechTrainingMembers.Remove(tVTTrainingMember);
                await _context.SaveChangesAsync();
            }

            return View();
            //return RedirectToAction(nameof(Details), "TVTTrainings", new { id = tVTTrainingMember.TechTrainingId });
        }

        private bool TVTTrainingMemberExists(int id)
        {
            return _context.TechTrainingMembers.Any(e => e.TechTrainingMemberId == id);
        }
    }
}
