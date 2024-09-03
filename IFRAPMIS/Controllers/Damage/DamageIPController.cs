using DAL.Models.Domain.MasterSetup;
using DAL.Models.Domain.SocialMobilization.Training;
using DAL.Models;
using IFRAPMIS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BAL.IRepository.SocialMobilization;
using DAL.Models.Domain.SocialMobilization;
using BAL.IRepository.Damage;
using DAL.Models.Domain.Damage;

namespace IFRAPMIS.Controllers.Damage
{
    public class DamageIpController : Controller
    {
        private readonly IDamageIP _context;
        private readonly ApplicationDbContext _context0;

        public DamageIpController(IDamageIP context, ApplicationDbContext context1)
        {
            _context = context;
            _context0 = context1;
        }
        // GET: DamageIps
        public async Task<IActionResult> Index(int id)
        {
            var applicationDbContext = await _context.GetAll(id, HttpContext.User);
            return View(applicationDbContext);
        }
        // GET: DamageIps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context == null)
            {
                return NotFound();
            }

            var damageIP = await _context.GetById(id);
            if (damageIP == null)
            {
                return NotFound();
            }
            return View(damageIP);
        }
        public async Task<JsonResult> GetAllDamageAssessmentHTSId(int damageAssessmentHTS)
        {
            List<DamageAssessmentHTS> damageAssessmentHTs = await _context.GetAllDamageAssessmentHTSId(damageAssessmentHTS);
            var dmList = damageAssessmentHTs.Select(m => new SelectListItem()
            {
                Text = m.DamageAssessmentHTSType.ToString(),
                Value = m.DamageAssessmentHTSId.ToString(),
            });
            return Json(dmList);
        }public async Task<JsonResult> GetAllDamageAssessmentLivestockId(int damageAssessmentLivestock)
        {
            List<DamageAssessmentLivestock> damageAssessments = await _context.GetAllDamageAssessmentLivestockId(damageAssessmentLivestock);
            var dmList = damageAssessments.Select(m => new SelectListItem()
            {
                Text = m.DamageAssessmentLivestockType.ToString(),
                Value = m.DamageAssessmentLivestockId.ToString(),
            });
            return Json(dmList);
        }

        // GET: DamageIps/detail
        public async Task<IActionResult> Create(int id)
        {
            ViewData["DamageAssessmentHTSId"] = new SelectList(await _context.GetAllDamageAssessmentHTSId(damageAssessmentHTS), "DamageAssessmentHTSId", "DamageAssessmentHTSType");
            ViewData["DamageAssessmentLivestockId"] = new SelectList(await _context.GetAllDamageAssessmentLivestockId(damageIP.DamageAssessmentLivestockId), "DamageAssessmentLivestockId", "DamageAssessmentLivestockType");

            return View(obj);
        }

        // POST: DamageIps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, DamageIP damageIP, IFormFile Attachment)
        {
            if (damageIP.DamageIPId == 0)
            {
                return NotFound();
            }
            if (Attachment != null && Attachment.Length > 0)
            {
                if (Path.GetExtension(Attachment.FileName) != ".pdf")
                {
                    ModelState.AddModelError(nameof(damageIP.Attachment), "Please attach only Pdf file format.");
                }
            }
            
            if (ModelState.IsValid)
            {
                if (Attachment != null && Attachment.Length > 0)
                {
                    Random random = new Random();
                    int randomNumber1 = random.Next(999, 100000);
                    var rootPath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\CD" + damageIP.BeneficiaryIP + "\\Attachment" + randomNumber1.ToString() + "\\");

                    string fileName = Path.GetFileName(Attachment.FileName);
                    int randomNumber2 = random.Next(999, 100000);
                    fileName = "Attachment" + randomNumber2.ToString() + Path.GetExtension(fileName);
                    damageIP.Attachment = Path.Combine("/Documents/CD" + damageIP.BeneficiaryIP + "/Attachment" + randomNumber1.ToString() + "/" + fileName);//Server Path
                    string sPath = Path.Combine(rootPath);
                    if (!System.IO.Directory.Exists(sPath))
                    {
                        System.IO.Directory.CreateDirectory(sPath);
                    }
                    string FullPathWithFileName = Path.Combine(sPath, fileName);
                    using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                    {
                        await Attachment.CopyToAsync(stream);
                    }
                }
                
                await _context.Insert(damageIP);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DamageAssessmentHTSId"] = new SelectList(await _context.GetAllDamageAssessmentHTSId(damageIP.DamageAssessmentHTSId), "DamageAssessmentHTSId", "DamageAssessmentHTSType", damageIP.DamageAssessmentHTSId);
            ViewData["DamageAssessmentLivestockId"] = new SelectList(await _context.GetAllDamageAssessmentLivestockId(damageIP.DamageAssessmentLivestockId), "DamageAssessmentLivestockId", "DamageAssessmentLivestockType", damageIP.DamageAssessmentLivestockId);
            
            return View(damageIP);
        }

        // GET: DamageIps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context == null)
            {
                return NotFound();
            }
            var damageIP = await _context.GetById(id);
            if (damageIP == null)
            {
                return NotFound();
            }
            ViewData["DamageAssessmentHTSId"] = new SelectList(await _context.GetAllDamageAssessmentHTSId(damageIP.DamageAssessmentHTSId), "DamageAssessmentHTSId", "DamageAssessmentHTSType", damageIP.DamageAssessmentHTSId);
            ViewData["DamageAssessmentLivestockId"] = new SelectList(await _context.GetAllDamageAssessmentLivestockId(damageIP.DamageAssessmentLivestockId), "DamageAssessmentLivestockId", "DamageAssessmentLivestockType", damageIP.DamageAssessmentLivestockId);

            return View(damageIP);
        }

        // POST: DamageIps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DamageIP damageIP, IFormFile Attachment)
        {
            if (id != damageIP.DamageIPId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Attachment != null && Attachment.Length > 0)
                    {
                        Random random = new Random();
                        int randomNumber1 = random.Next(999, 100000);
                        var rootPath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\CD" + damageIP.BeneficiaryIP + "\\Attachment" + randomNumber1.ToString() + "\\");

                        string fileName = Path.GetFileName(Attachment.FileName);
                        int randomNumber2 = random.Next(999, 100000);
                        fileName = "Attachment" + randomNumber2.ToString() + Path.GetExtension(fileName);
                        damageIP.Attachment = Path.Combine("/Documents/CD" + damageIP.BeneficiaryIP + "/Attachment" + randomNumber1.ToString() + "/" + fileName);//Server Path
                        string sPath = Path.Combine(rootPath);
                        if (!System.IO.Directory.Exists(sPath))
                        {
                            System.IO.Directory.CreateDirectory(sPath);
                        }
                        string FullPathWithFileName = Path.Combine(sPath, fileName);
                        using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                        {
                            await Attachment.CopyToAsync(stream);
                        }
                    }
                    _context0.Update(damageIP);
                    _context0.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exist(damageIP.DamageIPId))
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
            ViewData["DamageAssessmentHTSId"] = new SelectList(await _context.GetAllDamageAssessmentHTSId(damageIP.DamageAssessmentHTSId), "DamageAssessmentHTSId", "DamageAssessmentHTSType", damageIP.DamageAssessmentHTSId);
            ViewData["DamageAssessmentLivestockId"] = new SelectList(await _context.GetAllDamageAssessmentLivestockId(damageIP.DamageAssessmentLivestockId), "DamageAssessmentLivestockId", "DamageAssessmentLivestockType", damageIP.DamageAssessmentLivestockId);

            return View(damageIP);
        }
        // GET: DamageIps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context == null)
            {
                return NotFound();
            }

            var damageIP = await _context.GetById(id);
            if (damageIP == null)
            {
                return NotFound();
            }

            return View(damageIP);
        }
        // POST: DamageIps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DamageIP'  is null.");
            }
            var damageIP = await _context.GetById(id);
            if (damageIP != null)
            {
                _context.Remove(damageIP);
            }

            return RedirectToAction(nameof(Index));
        }
        private bool Exist(int id)
        {
            return _context.Exist(id);
        }
    }
}
