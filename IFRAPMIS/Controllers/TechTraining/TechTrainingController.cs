using DAL.Models.Domain.MasterSetup;
using DAL.Models;
using IFRAPMIS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Models.Domain.TechTrainingnamespace;

namespace IFRAPMIS.Controllers.TechTrainingnamespace
{
    public class TechTrainingController : Controller
    {        
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TechTrainingController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: TechTrainings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = await _context.TechTrainings.Include(t => t.TrainingTitle)
                                                                        .ThenInclude(t => t.TrainingHead)
                                                                   .ToListAsync();
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser.DistrictName != "All")
            {
                applicationDbContext = applicationDbContext.Where(a => a.District == currentUser.DistrictName).ToList();
            }
            return View(applicationDbContext);
        }

        // GET: TechTrainings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TechTrainings == null)
            {
                return NotFound();
            }

            var techTraining = await _context.TechTrainings
                .Include(a => a.Village.UnionCouncils.Tehsil.District)
                .Include(m => m.TrainingTitle.TrainingHead)
                .FirstOrDefaultAsync(m => m.TechTrainingId == id);
            if (techTraining == null)
            {
                return NotFound();
            }
            return View(techTraining);
        }
        public async Task<JsonResult> GetTrainingTypes(int trainingHeadId)
        {
            List<TrainingTitle> trainings = await _context.TrainingTitles.Where(a => a.TrainingHeadId == trainingHeadId).ToListAsync();
            var trainingList = trainings.Select(m => new SelectListItem()
            {
                Text = m.TrainingName.ToString(),
                Value = m.TitleId.ToString(),
            });
            return Json(trainingList);
        }
        public async Task<JsonResult> GetTrainers(int sectionId)
        {
            List<Trainer> emplyees = await _context.Trainers.Where(a => a.SectionId == sectionId).ToListAsync();
            var employeeList = emplyees.Select(m => new SelectListItem()
            {
                Text = m.TrainerName.ToString(),
                Value = m.TrainerId.ToString(),
            });
            return Json(employeeList);
        }
        // GET: TechTrainings/Create
        public async Task<IActionResult> Create()
        {
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerName");//IP waghera
            //ViewData["TrainingById"] = new SelectList(_context.Sections, "SectionId", "Name");
            var THead = _context.TrainingHeads;
            ViewData["TrainingHeadId"] = new SelectList(THead, "TrainingHeadId", "TrainingHeadName");
            
            var districtAccess = await _context.Districts.ToListAsync();
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser.DistrictName != "All")
            {
                districtAccess = districtAccess.Where(a => a.DistrictName == currentUser.DistrictName).ToList();
            }

            ViewData["District"] = new SelectList(districtAccess, "DistrictName", "DistrictName");
            ViewData["PhaseId"] = new SelectList(_context.Phases, "PhaseId", "Name");
            //-----------------------------------------------
            TechTraining obj = new TechTraining();
            //TechTraining obj = new TechTraining();
            obj.DateOfCreation = DateTime.Today.Date;
            return View(obj);
        }

        // POST: TechTrainings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TechTraining techTraining, int TrainingHeadId, IFormFile AttendanceAttachment, IFormFile ReportAttachment, IFormFile SessionPlanAttachment, IFormFile PictureAttachment1, IFormFile PictureAttachment2, IFormFile PictureAttachment3, IFormFile PictureAttachment4)
        {
            if (ModelState.IsValid)
            {
                var TrainingCount = _context.TechTrainings.Count(a => a.TrainingTitleId == techTraining.TrainingTitleId) + 1;
                var TrainingTypeInfo = _context.TrainingTitles.Find(techTraining.TrainingTitleId);
                var DistrictCode = _context.Districts.Find(techTraining.District).Code;
                string TrainingCode = DistrictCode + "-" + _context.TrainingHeads.Find(TrainingTypeInfo.TrainingHeadId).TrainingHeadCode + "-" + TrainingTypeInfo.TrainingTitleCode;
                string val = (TrainingCount).ToString("D3");
                techTraining.TrainingCode = (TrainingCode + "-" + val);
                while (_context.TechTrainings.Count(a => a.TrainingCode == techTraining.TrainingCode) > 0)
                {
                    val = (++TrainingCount).ToString("D3");
                    techTraining.TrainingCode = (TrainingCode + "-" + val);
                }
                if (AttendanceAttachment != null && AttendanceAttachment.Length > 0)
                {
                    var rootPath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + techTraining.TrainingTitleId + "\\AttendanceSheet\\");
                    string fileName = Path.GetFileName(AttendanceAttachment.FileName);
                    Random random = new Random();
                    int randomNumber = random.Next(9999, 999999);
                    fileName = "AttendanceSheet" + randomNumber.ToString() + Path.GetExtension(fileName);
                    techTraining.AttendanceAttachment = Path.Combine("/Documents/Training" + techTraining.TrainingTitleId + "/AttendanceSheet/" + fileName);//Server Path
                    string sPath = Path.Combine(rootPath);
                    if (!System.IO.Directory.Exists(sPath))
                    {
                        System.IO.Directory.CreateDirectory(sPath);
                    }
                    string FullPathWithFileName = Path.Combine(sPath, fileName);
                    using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                    {
                        await AttendanceAttachment.CopyToAsync(stream);
                    }
                }
                if (ReportAttachment != null && ReportAttachment.Length > 0)
                {
                    var rootPath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + techTraining.TrainingTitleId + "\\Report\\");
                    string fileName = Path.GetFileName(ReportAttachment.FileName);
                    Random random = new Random();
                    int randomNumber = random.Next(9999, 999999);
                    fileName = "Report" + randomNumber.ToString() + Path.GetExtension(fileName);
                    techTraining.ReportAttachment = Path.Combine("/Documents/Training" + techTraining.TrainingTitleId + "/Report/" + fileName);//Server Path
                    string sPath = Path.Combine(rootPath);
                    if (!System.IO.Directory.Exists(sPath))
                    {
                        System.IO.Directory.CreateDirectory(sPath);
                    }
                    string FullPathWithFileName = Path.Combine(sPath, fileName);
                    using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                    {
                        await ReportAttachment.CopyToAsync(stream);
                    }
                }
                if (SessionPlanAttachment != null && SessionPlanAttachment.Length > 0)
                {
                    var rootPath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + techTraining.TrainingTitleId + "\\SessionPlan\\");
                    string fileName = Path.GetFileName(SessionPlanAttachment.FileName);
                    Random random = new Random();
                    int randomNumber = random.Next(9999, 999999);
                    fileName = "SessionPlan" + randomNumber.ToString() + Path.GetExtension(fileName);
                    techTraining.SessionPlanAttachment = Path.Combine("/Documents/Training" + techTraining.TrainingTitleId + "/SessionPlan/" + fileName);//Server Path
                    string sPath = Path.Combine(rootPath);
                    if (!System.IO.Directory.Exists(sPath))
                    {
                        System.IO.Directory.CreateDirectory(sPath);
                    }
                    string FullPathWithFileName = Path.Combine(sPath, fileName);
                    using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                    {
                        await SessionPlanAttachment.CopyToAsync(stream);
                    }
                }
                if (PictureAttachment1 != null && PictureAttachment1.Length > 0)
                {
                    var rootPath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + techTraining.TrainingTitleId + "\\Pictures\\");
                    string fileName = Path.GetFileName(PictureAttachment1.FileName);
                    Random random = new Random();
                    int randomNumber = random.Next(9999, 999999);
                    fileName = "Picture" + randomNumber.ToString() + Path.GetExtension(fileName);
                    techTraining.PictureAttachment1 = Path.Combine("/Documents/Training" + techTraining.TrainingTitleId + "/Pictures/" + fileName);//Server Path
                    string sPath = Path.Combine(rootPath);
                    if (!System.IO.Directory.Exists(sPath))
                    {
                        System.IO.Directory.CreateDirectory(sPath);
                    }
                    string FullPathWithFileName = Path.Combine(sPath, fileName);
                    using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                    {
                        await PictureAttachment1.CopyToAsync(stream);
                    }
                }
                if (PictureAttachment2 != null && PictureAttachment2.Length > 0)
                {
                    var rootPath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + techTraining.TrainingTitleId + "\\Pictures\\");
                    string fileName = Path.GetFileName(PictureAttachment2.FileName);
                    Random random = new Random();
                    int randomNumber = random.Next(9999, 999999);
                    fileName = "Picture" + randomNumber.ToString() + Path.GetExtension(fileName);
                    techTraining.PictureAttachment2 = Path.Combine("/Documents/Training" + techTraining.TrainingTitleId + "/Pictures/" + fileName);//Server Path
                    string sPath = Path.Combine(rootPath);
                    if (!System.IO.Directory.Exists(sPath))
                    {
                        System.IO.Directory.CreateDirectory(sPath);
                    }
                    string FullPathWithFileName = Path.Combine(sPath, fileName);
                    using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                    {
                        await PictureAttachment2.CopyToAsync(stream);
                    }
                }
                if (PictureAttachment3 != null && PictureAttachment3.Length > 0)
                {
                    var rootPath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + techTraining.TrainingTitleId + "\\Pictures\\");
                    string fileName = Path.GetFileName(PictureAttachment3.FileName);
                    Random random = new Random();
                    int randomNumber = random.Next(9999, 999999);
                    fileName = "Picture" + randomNumber.ToString() + Path.GetExtension(fileName);
                    techTraining.PictureAttachment3 = Path.Combine("/Documents/Training" + techTraining.TrainingTitleId + "/Pictures/" + fileName);//Server Path
                    string sPath = Path.Combine(rootPath);
                    if (!System.IO.Directory.Exists(sPath))
                    {
                        System.IO.Directory.CreateDirectory(sPath);
                    }
                    string FullPathWithFileName = Path.Combine(sPath, fileName);
                    using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                    {
                        await PictureAttachment3.CopyToAsync(stream);
                    }
                }
                if (PictureAttachment4 != null && PictureAttachment4.Length > 0)
                {
                    var rootPath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + techTraining.TrainingTitleId + "\\Pictures\\");
                    string fileName = Path.GetFileName(PictureAttachment4.FileName);
                    Random random = new Random();
                    int randomNumber = random.Next(9999, 999999);
                    fileName = "Picture" + randomNumber.ToString() + Path.GetExtension(fileName);
                    techTraining.PictureAttachment4 = Path.Combine("/Documents/Training" + techTraining.TrainingTitleId + "/Pictures/" + fileName);//Server Path
                    string sPath = Path.Combine(rootPath);
                    if (!System.IO.Directory.Exists(sPath))
                    {
                        System.IO.Directory.CreateDirectory(sPath);
                    }
                    string FullPathWithFileName = Path.Combine(sPath, fileName);
                    using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                    {
                        await PictureAttachment4.CopyToAsync(stream);
                    }
                }
                
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                techTraining.District = _context.Districts.Find(techTraining.District).DistrictName;
                _context.Add(techTraining);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrainingById"] = new SelectList(_context.Sections, "SectionId", "Name", techTraining.TrainingTitleId);
            ViewData["TrainingHeadId"] = new SelectList(_context.TrainingHeads, "TrainingHeadId", "TrainingHeadName", TrainingHeadId);
            ViewData["TitleId"] = new SelectList(_context.TrainingTitles.Where(a => a.TrainingHeadId == TrainingHeadId), "TitleId", "TrainingTypeName", TrainingHeadId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerName", techTraining.TrainingName);
            ViewData["PhaseId"] = new SelectList(_context.Phases, "PhaseId", "Name", techTraining.Phase);
            return View(techTraining);
        }

        // GET: TechTrainings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TechTrainings == null)
            {
                return NotFound();
            }

            var techTraining = await _context.TechTrainings.Include(a => a.Village.UnionCouncils.Tehsil).Where(a => a.TechTrainingId == id).FirstOrDefaultAsync();
            if (techTraining == null)
            {
                return NotFound();
            }
            int TrainingHeadId = _context.TrainingTitles.Find(techTraining.TrainingTitleId).TrainingHeadId ?? 0;
            
            //ViewData["TrainingById"] = new SelectList(_context.TVTTrainedBy, "Name", "Name", techTraining.TVTTrainer);
            ViewData["TrainingById"] = new SelectList(_context.Sections, "SectionId", "Name", techTraining.TrainingTitleId);
            
            ViewData["TrainingHeadId"] = new SelectList(_context.TrainingHeads, "TrainingHeadId", "TrainingHeadName", TrainingHeadId);
            ViewData["TitleId"] = new SelectList(_context.TrainingTitles.Where(a => a.TrainingHeadId == TrainingHeadId), "TitleId", "TrainingTypeName", TrainingHeadId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerName", techTraining.TrainingName);
            var districtAccess = _context.Districts.Where(a => a.DistrictName == techTraining.District);
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            ViewData["District"] = new SelectList(districtAccess, "DistrictName", "DistrictName");
            ViewData["TehsilId"] = new SelectList(_context.Tehsils.Where(a => a.District.DistrictName == techTraining.District), "TehsilId", "TehsilName", techTraining.Village.UnionCouncils.TehsilId);
            ViewData["UnionCouncilId"] = new SelectList(_context.UnionCouncils.Where(a => a.TehsilId == techTraining.Village.UnionCouncils.TehsilId), "UnionCouncilId", "UnionCouncilName", techTraining.Village.UnionCouncilId);
            ViewData["VillageId"] = new SelectList(_context.Villages.Where(a => a.UnionCouncilId == techTraining.Village.UnionCouncilId), "VillageId", "Name", techTraining.VillageId);
            ViewData["PhaseId"] = new SelectList(_context.Phases, "PhaseId", "Name", techTraining.Phase);
            ViewBag.IsAllow = true;
            return View(techTraining);
        }

        // POST: TechTrainings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TechTraining techTraining, int TrainingHeadId, IFormFile? AttendanceAttachment, IFormFile? ReportAttachment, IFormFile? SessionPlanAttachment, IFormFile? PictureAttachment1, IFormFile? PictureAttachment2, IFormFile? PictureAttachment3, IFormFile? PictureAttachment4)
        {
            if (id != techTraining.TechTrainingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (AttendanceAttachment != null && AttendanceAttachment.Length > 0)
                    {
                        var rootPath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + techTraining.TrainingTitleId + "\\AttendanceSheet\\");
                        string fileName = Path.GetFileName(AttendanceAttachment.FileName);
                        Random random = new Random();
                        int randomNumber = random.Next(9999, 999999);
                        fileName = "AttendanceSheet" + randomNumber.ToString() + Path.GetExtension(fileName);
                        techTraining.AttendanceAttachment = Path.Combine("/Documents/Training" + techTraining.TrainingTitleId + "/AttendanceSheet/" + fileName);//Server Path
                        string sPath = Path.Combine(rootPath);
                        if (!System.IO.Directory.Exists(sPath))
                        {
                            System.IO.Directory.CreateDirectory(sPath);
                        }
                        string FullPathWithFileName = Path.Combine(sPath, fileName);
                        using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                        {
                            await AttendanceAttachment.CopyToAsync(stream);
                        }
                    }
                    if (ReportAttachment != null && ReportAttachment.Length > 0)
                    {
                        var rootPath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + techTraining.TrainingTitleId + "\\Report\\");
                        string fileName = Path.GetFileName(ReportAttachment.FileName);
                        Random random = new Random();
                        int randomNumber = random.Next(9999, 999999);
                        fileName = "Report" + randomNumber.ToString() + Path.GetExtension(fileName);
                        techTraining.ReportAttachment = Path.Combine("/Documents/Training" + techTraining.TrainingTitleId + "/Report/" + fileName);//Server Path
                        string sPath = Path.Combine(rootPath);
                        if (!System.IO.Directory.Exists(sPath))
                        {
                            System.IO.Directory.CreateDirectory(sPath);
                        }
                        string FullPathWithFileName = Path.Combine(sPath, fileName);
                        using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                        {
                            await ReportAttachment.CopyToAsync(stream);
                        }
                    }
                    if (SessionPlanAttachment != null && SessionPlanAttachment.Length > 0)
                    {
                        var rootPath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + techTraining.TrainingTitleId + "\\SessionPlan\\");
                        string fileName = Path.GetFileName(SessionPlanAttachment.FileName);
                        Random random = new Random();
                        int randomNumber = random.Next(9999, 999999);
                        fileName = "SessionPlan" + randomNumber.ToString() + Path.GetExtension(fileName);
                        techTraining.SessionPlanAttachment = Path.Combine("/Documents/Training" + techTraining.TrainingTitleId + "/SessionPlan/" + fileName);//Server Path
                        string sPath = Path.Combine(rootPath);
                        if (!System.IO.Directory.Exists(sPath))
                        {
                            System.IO.Directory.CreateDirectory(sPath);
                        }
                        string FullPathWithFileName = Path.Combine(sPath, fileName);
                        using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                        {
                            await SessionPlanAttachment.CopyToAsync(stream);
                        }
                    }
                    if (PictureAttachment1 != null && PictureAttachment1.Length > 0)
                    {
                        var rootPath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + techTraining.TrainingTitleId + "\\Pictures\\");
                        string fileName = Path.GetFileName(PictureAttachment1.FileName);
                        Random random = new Random();
                        int randomNumber = random.Next(9999, 999999);
                        fileName = "Picture" + randomNumber.ToString() + Path.GetExtension(fileName);
                        techTraining.PictureAttachment1 = Path.Combine("/Documents/Training" + techTraining.TrainingTitleId + "/Pictures/" + fileName);//Server Path
                        string sPath = Path.Combine(rootPath);
                        if (!System.IO.Directory.Exists(sPath))
                        {
                            System.IO.Directory.CreateDirectory(sPath);
                        }
                        string FullPathWithFileName = Path.Combine(sPath, fileName);
                        using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                        {
                            await PictureAttachment1.CopyToAsync(stream);
                        }
                    }
                    if (PictureAttachment2 != null && PictureAttachment2.Length > 0)
                    {
                        var rootPath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + techTraining.TrainingTitleId + "\\Pictures\\");
                        string fileName = Path.GetFileName(PictureAttachment2.FileName);
                        Random random = new Random();
                        int randomNumber = random.Next(9999, 999999);
                        fileName = "Picture" + randomNumber.ToString() + Path.GetExtension(fileName);
                        techTraining.PictureAttachment2 = Path.Combine("/Documents/Training" + techTraining.TrainingTitleId + "/Pictures/" + fileName);//Server Path
                        string sPath = Path.Combine(rootPath);
                        if (!System.IO.Directory.Exists(sPath))
                        {
                            System.IO.Directory.CreateDirectory(sPath);
                        }
                        string FullPathWithFileName = Path.Combine(sPath, fileName);
                        using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                        {
                            await PictureAttachment2.CopyToAsync(stream);
                        }
                    }
                    if (PictureAttachment3 != null && PictureAttachment3.Length > 0)
                    {
                        var rootPath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + techTraining.TrainingTitleId + "\\Pictures\\");
                        string fileName = Path.GetFileName(PictureAttachment3.FileName);
                        Random random = new Random();
                        int randomNumber = random.Next(9999, 999999);
                        fileName = "Picture" + randomNumber.ToString() + Path.GetExtension(fileName);
                        techTraining.PictureAttachment3 = Path.Combine("/Documents/Training" + techTraining.TrainingTitleId + "/Pictures/" + fileName);//Server Path
                        string sPath = Path.Combine(rootPath);
                        if (!System.IO.Directory.Exists(sPath))
                        {
                            System.IO.Directory.CreateDirectory(sPath);
                        }
                        string FullPathWithFileName = Path.Combine(sPath, fileName);
                        using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                        {
                            await PictureAttachment3.CopyToAsync(stream);
                        }
                    }
                    if (PictureAttachment4 != null && PictureAttachment4.Length > 0)
                    {
                        var rootPath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + techTraining.TrainingTitleId + "\\Pictures\\");
                        string fileName = Path.GetFileName(PictureAttachment4.FileName);
                        Random random = new Random();
                        int randomNumber = random.Next(9999, 999999);
                        fileName = "Picture" + randomNumber.ToString() + Path.GetExtension(fileName);
                        techTraining.PictureAttachment4 = Path.Combine("/Documents/Training" + techTraining.TrainingTitleId + "/Pictures/" + fileName);//Server Path
                        string sPath = Path.Combine(rootPath);
                        if (!System.IO.Directory.Exists(sPath))
                        {
                            System.IO.Directory.CreateDirectory(sPath);
                        }
                        string FullPathWithFileName = Path.Combine(sPath, fileName);
                        using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                        {
                            await PictureAttachment4.CopyToAsync(stream);
                        }
                    }
                    techTraining.District = _context.Districts.Find(techTraining.District).DistrictName;
                    _context.Update(techTraining);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechTrainingExists(techTraining.TechTrainingId))
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
            //ViewData["TrainingById"] = new SelectList(_context.TVTTrainedBy, "Name", "Name", techTraining.TVTTrainer);
            ViewData["TrainingById"] = new SelectList(_context.Sections, "SectionId", "Name", techTraining.TrainingTitleId);

            ViewData["TrainingHeadId"] = new SelectList(_context.TrainingHeads, "TrainingHeadId", "TrainingHeadName", TrainingHeadId);
            ViewData["TitleId"] = new SelectList(_context.TrainingTitles.Where(a => a.TrainingHeadId == TrainingHeadId), "TitleId", "TrainingTypeName", TrainingHeadId);
            ViewData["VillageId"] = new SelectList(_context.Villages.Where(a => a.UnionCouncilId == techTraining.Village.UnionCouncilId), "VillageId", "Name", techTraining.VillageId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "TrainerId", "TrainerName", techTraining.TrainingName);
            ViewData["PhaseId"] = new SelectList(_context.Phases, "PhaseId", "Name", techTraining.Phase);
            return View(techTraining);
        }
        public async Task<JsonResult> GetTehsils(int districtId)
        {
            List<Tehsil> tehsils = await _context.Tehsils.Where(a => a.DistrictId == districtId).ToListAsync();
            var tehsilList = tehsils.Select(m => new SelectListItem()
            {
                Text = m.TehsilName.ToString(),
                Value = m.TehsilId.ToString(),
            });
            return Json(tehsilList);
        }
        public async Task<JsonResult> GetUCs(int tehsilId)
        {
            List<UnionCouncil> unionCouncils = await _context.UnionCouncils.Where(a => a.TehsilId == tehsilId).ToListAsync();
            var UCList = unionCouncils.Select(m => new SelectListItem()
            {
                Text = m.UnionCouncilName.ToString(),
                Value = m.UnionCouncilId.ToString(),
            });
            return Json(UCList);
        }
        // GET: TechTrainings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TechTrainings == null)
            {
                return NotFound();
            }

            var techTraining = await _context.TechTrainings
                .Include(m => m.TrainingTitle)
                .FirstOrDefaultAsync(m => m.TechTrainingId == id);
            if (techTraining == null)
            {
                return NotFound();
            }

            return View(techTraining);
        }

        // POST: TechTrainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TechTrainings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TechTraining'  is null.");
            }
            var techTraining = await _context.TechTrainings.FindAsync(id);
            if (techTraining != null)
            {
                _context.TechTrainings.Remove(techTraining);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TechTrainingExists(int id)
        {
            return _context.TechTrainings.Any(e => e.TechTrainingId == id);
        }
    }
}
