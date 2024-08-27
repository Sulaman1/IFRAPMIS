using DAL.Models.Domain.MasterSetup;
using DAL.Models;
using IFRAPMIS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Models.Domain.SocialMobilization.Training;

namespace IFRAPMIS.Controllers.SocialMobilization.Training
{
    public class CICIGTrainingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CICIGTrainingController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CICIGTrainingss
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = await _context.CICIGTrainings.Include(m => m.Village)

                                                                    .Include(m => m.Phase)
                                                                    .Include(m => m.CICIGTrainingTrainers)
                                                                    .Include(m => m.TrainingTitle)
                                                                        .ThenInclude(tt => tt.TrainingHead)

                                                                    .ToListAsync();

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser.DistrictName == "All")
            {
                applicationDbContext = applicationDbContext.Where(a => a.District == currentUser.DistrictName).ToList();
            }
            return View(applicationDbContext);
        }

        // GET: CICIGTrainingss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CICIGTrainings == null)
            {
                return NotFound();
            }

            var cicigTraining = await _context.CICIGTrainings
                .Include(m => m.CICIGTrainingTrainers)
                .Include(a => a.Village.UnionCouncils.Tehsil.District)

                .Include(m => m.TrainingTitle.TrainingHead)
                .FirstOrDefaultAsync(m => m.CICIGTrainingsId == id);
            if (cicigTraining == null)
            {
                return NotFound();
            }
            return View(cicigTraining);
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
        // GET: CICIGTrainingss/Create
        public async Task<IActionResult> Create()
        {
            ViewData["TrainingById"] = new SelectList(_context.Sections/*.Where(a => a.SectionId == 2)*/, "SectionId", "Name");
            var THead = _context.TrainingHeads;
            ViewData["TrainingHeadId"] = new SelectList(THead, "TrainingHeadId", "TrainingHeadName");
            ViewData["TrainerId"] = new SelectList(_context.Trainers/*.Where(a => a.SectionId == 2)*/, "TrainerId", "TrainerName");

            var districtAccess = _context.Districts.Where(a => a.DistrictId > 0);

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser.DistrictName == "All")
            {
                districtAccess = districtAccess.Where(a => a.DistrictName == currentUser.DistrictName);
            }
            ViewData["District"] = new SelectList(districtAccess, "DistrictName", "DistrictName");
            ViewData["PhaseId"] = new SelectList(_context.Phases, "PhaseId", "Name");
            //-----------------------------------------------            
            CICIGTrainings obj = new CICIGTrainings();
            obj.Started = DateTime.Today.Date;
            //obj.IsCompleted = false;
            return View(obj);
        }

        // POST: CICIGTrainingss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        //[Bind("CICIGTrainingsId, CommunityTypeId, EntryBy, DateOfCreation, District, Tehsil, UnionCouncil, VillageId, PhaseId, Name, HouseHoldNumber, HouseHoldParticipated, Venue, Lat, Long, Gender")] 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CICIGTrainings cicigTraining, int TrainingHeadId, IFormFile AttendanceAttachment, IFormFile ReportAttachment, IFormFile SessionPlanAttachment, IFormFile PictureAttachment1, IFormFile PictureAttachment2, IFormFile PictureAttachment3, IFormFile PictureAttachment4)
        {
            if (ModelState.IsValid)
            {
                /**
                 * If trainingHead is present dont enter data
                 * If trainingTitle is present dont enter data
                 */

                var TrainingCount = _context.CICIGTrainings.Count(a => a.TrainingTitleId == cicigTraining.TrainingTitleId) + 1;
                var TrainingTypeInfo = _context.TrainingTitles.Find(cicigTraining.TrainingTitleId);
                //var DistrictCode = _context.Districts.Find(cicigTraining.District).Code;
                var DistrictCode = _context.Districts.FirstOrDefault(d => d.DistrictName == cicigTraining.District);
                string TrainingCode = DistrictCode + "-" + _context.TrainingHeads.Find(TrainingTypeInfo.TrainingHeadId).TrainingHeadCode + "-" + TrainingTypeInfo.TrainingTitleCode;
                string val = (TrainingCount).ToString("D3");
                cicigTraining.TrainingCode = (TrainingCode + "-" + val);
                while (_context.CICIGTrainings.Count(a => a.TrainingCode == cicigTraining.TrainingCode) > 0)
                {
                    val = (++TrainingCount).ToString("D3");
                    cicigTraining.TrainingCode = (TrainingCode + "-" + val);
                }
                if (AttendanceAttachment != null && AttendanceAttachment.Length > 0)
                {
                    var rootPath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + cicigTraining.TrainingTitleId + "\\AttendanceSheet\\");
                    string fileName = Path.GetFileName(AttendanceAttachment.FileName);
                    Random random = new Random();
                    int randomNumber = random.Next(9999, 999999);
                    fileName = "AttendanceSheet" + randomNumber.ToString() + Path.GetExtension(fileName);
                    cicigTraining.AttendanceAttachment = Path.Combine("/Documents/Training" + cicigTraining.TrainingTitleId + "/AttendanceSheet/" + fileName);//Server Path
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
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + cicigTraining.TrainingTitleId + "\\Report\\");
                    string fileName = Path.GetFileName(ReportAttachment.FileName);
                    Random random = new Random();
                    int randomNumber = random.Next(9999, 999999);
                    fileName = "Report" + randomNumber.ToString() + Path.GetExtension(fileName);
                    cicigTraining.ReportAttachment = Path.Combine("/Documents/Training" + cicigTraining.TrainingTitleId + "/Report/" + fileName);//Server Path
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
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + cicigTraining.TrainingTitleId + "\\SessionPlan\\");
                    string fileName = Path.GetFileName(SessionPlanAttachment.FileName);
                    Random random = new Random();
                    int randomNumber = random.Next(9999, 999999);
                    fileName = "SessionPlan" + randomNumber.ToString() + Path.GetExtension(fileName);
                    cicigTraining.SessionPlanAttachment = Path.Combine("/Documents/Training" + cicigTraining.TrainingTitleId + "/SessionPlan/" + fileName);//Server Path
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
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + cicigTraining.TrainingTitleId + "\\Pictures\\");
                    string fileName = Path.GetFileName(PictureAttachment1.FileName);
                    Random random = new Random();
                    int randomNumber = random.Next(9999, 999999);
                    fileName = "Picture" + randomNumber.ToString() + Path.GetExtension(fileName);
                    cicigTraining.PictureAttachment1 = Path.Combine("/Documents/Training" + cicigTraining.TrainingTitleId + "/Pictures/" + fileName);//Server Path
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
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + cicigTraining.TrainingTitleId + "\\Pictures\\");
                    string fileName = Path.GetFileName(PictureAttachment2.FileName);
                    Random random = new Random();
                    int randomNumber = random.Next(9999, 999999);
                    fileName = "Picture" + randomNumber.ToString() + Path.GetExtension(fileName);
                    cicigTraining.PictureAttachment2 = Path.Combine("/Documents/Training" + cicigTraining.TrainingTitleId + "/Pictures/" + fileName);//Server Path
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
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + cicigTraining.TrainingTitleId + "\\Pictures\\");
                    string fileName = Path.GetFileName(PictureAttachment3.FileName);
                    Random random = new Random();
                    int randomNumber = random.Next(9999, 999999);
                    fileName = "Picture" + randomNumber.ToString() + Path.GetExtension(fileName);
                    cicigTraining.PictureAttachment3 = Path.Combine("/Documents/Training" + cicigTraining.TrainingTitleId + "/Pictures/" + fileName);//Server Path
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
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + cicigTraining.TrainingTitleId + "\\Pictures\\");
                    string fileName = Path.GetFileName(PictureAttachment4.FileName);
                    Random random = new Random();
                    int randomNumber = random.Next(9999, 999999);
                    fileName = "Picture" + randomNumber.ToString() + Path.GetExtension(fileName);
                    cicigTraining.PictureAttachment4 = Path.Combine("/Documents/Training" + cicigTraining.TrainingTitleId + "/Pictures/" + fileName);//Server Path
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
                //cicigTraining.SubmittedForReviewBy = currentUser.UserName;
                //cicigTraining.District = _context.Districts.Find(cicigTraining.District);
                _context.Add(cicigTraining);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["TrainingById"] = new MultiSelectList(_context.Sections/*.Where(a => a.SectionId == 2)*/, "SectionId", "Name", cicigTraining.CICIGTrainingTrainers.Select(t => t.TrainerId));
            //ViewData["TrainingById"] = new SelectList(_context.Sections.Where(a => a.SectionId == 2), "SectionId", "Name", cicigTraining.TrainerId);
            ViewData["TrainingHeadId"] = new SelectList(_context.TrainingHeads, "TrainingHeadId", "TrainingHeadName", TrainingHeadId);
            ViewData["TrainingTitleId"] = new SelectList(_context.TrainingTitles.Where(a => a.TrainingHeadId == TrainingHeadId), "TrainingTitleId", "TrainingTypeName", TrainingHeadId);
            ViewData["PhaseId"] = new SelectList(_context.Phases, "PhaseId", "Name", cicigTraining.Phase);
            return View(cicigTraining);
        }

        // GET: CICIGTrainingss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CICIGTrainings == null)
            {
                return NotFound();
            }


            //var cicigTraining = await _context.CICIGTrainings.Include(a => a.Village.UnionCouncils.Tehsil)
            //                                                 .Where(a => a.CICIGTrainingsId == id)
            //                                                 .FirstOrDefaultAsync();
            var cicigTraining = _context.CICIGTrainings
                                 .Include(ct => ct.Phase)
                                 .Include(ct => ct.CICIGTrainingTrainers)
                                 .ThenInclude(tt => tt.Trainer)
                                 .Include(ct => ct.Village)
                                 .ThenInclude(v => v.UnionCouncils)
                                 .ThenInclude(uc => uc.Tehsil)
                                 .ThenInclude(t => t.District)
                                 .FirstOrDefault(ct => ct.CICIGTrainingsId == id);

            if (cicigTraining == null)
            {
                return NotFound();
            }
            int? TrainingHeadId = _context.TrainingTitles.Find(cicigTraining.TrainingTitleId).TrainingHeadId;


            ViewData["SectionId"] = new MultiSelectList(_context.Sections, "SectionId", "Name", cicigTraining.CICIGTrainingTrainers.Select(t => t.TrainerId));
            //ViewData["SectionId"] = new MultiSelectList(_context.Sections/*.Where(a => a.SectionId == 2)*/, "SectionId", "Name", cicigTraining.CICIGTrainingTrainers.Select(t => t.TrainerId));
            //ViewData["SectionId"] = new MultiSelectList(_context.Sections.Where(a => a.SectionId == 2), "SectionId", "Name", cicigTraining.Trainer.Select(t => t.TrainerId));
            //ViewData["SectionId"] = new SelectList(_context.Sections.Where(a => a.SectionId == 2), "SectionId", "Name", cicigTraining.TrainerId);


            ViewData["TrainerId"] = new MultiSelectList(_context.Trainers/*.Where(a => a.SectionId == 2)*/, "TrainerId", "TrainerName", cicigTraining.CICIGTrainingTrainers.Select(t => t.TrainerId));  // Pre-selected TrainerIds);
            //ViewData["TrainerId"] = new SelectList(_context.Trainers.Where(a => a.SectionId == 2), "TrainerId", "TrainerName", cicigTraining.TrainerId);

            ViewData["TrainingHeadId"] = new SelectList(_context.TrainingHeads, "TrainingHeadId", "TrainingHeadName", TrainingHeadId);

            ViewData["TrainingTitleId"] = new SelectList(_context.TrainingTitles.Where(a => a.TrainingHeadId == TrainingHeadId), "TitleId", "TrainingName", TrainingHeadId);
            var districtAccess = _context.Districts.Where(a => a.DistrictName == cicigTraining.District);
            var tehsilAccess = _context.Tehsils.Where(a => a.District.DistrictName.Equals(cicigTraining.District));
            //var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            ViewData["DistrictId"] = new SelectList(districtAccess, "DistrictName", "DistrictName");
            ViewData["TehsilId"] = new SelectList(tehsilAccess, "TehsilId", "TehsilName", cicigTraining.Village.UnionCouncils.TehsilId);
            ViewData["UnionCouncilId"] = new SelectList(_context.UnionCouncils.Where(a => a.TehsilId == cicigTraining.Village.UnionCouncils.TehsilId), "UnionCouncilId", "UnionCouncilName", cicigTraining.Village.UnionCouncilId);
            ViewData["VillageId"] = new SelectList(_context.Villages.Where(a => a.UnionCouncilId == cicigTraining.Village.UnionCouncilId), "VillageId", "VillageName", cicigTraining.VillageId);

            ViewData["PhaseId"] = new SelectList(_context.Phases, "PhaseId", "Name", cicigTraining.Phase);
            ViewBag.IsAllow = true;
            //var currentuser = await _userManager.GetUserAsync(User);
            //if (cicigTraining.SubmittedForReviewBy != null)
            //{
            //    if (currentuser.UserName != cicigTraining.SubmittedForReviewBy)
            //    {
            //        ViewBag.IsAllow = false;
            //    }
            //}
            //else
            //{
            //    ViewBag.IsAllow = true;
            //    cicigTraining.SubmittedForReviewBy = currentuser.UserName;
            //}


            return View(cicigTraining);
        }

        // POST: CICIGTrainingss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CICIGTrainings cicigTraining, int TrainingHeadId, IFormFile? AttendanceAttachment, IFormFile? ReportAttachment, IFormFile? SessionPlanAttachment, IFormFile? PictureAttachment1, IFormFile? PictureAttachment2, IFormFile? PictureAttachment3, IFormFile? PictureAttachment4)
        {
            if (id != cicigTraining.CICIGTrainingsId)
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
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + cicigTraining.TrainingTitleId + "\\AttendanceSheet\\");
                        string fileName = Path.GetFileName(AttendanceAttachment.FileName);
                        Random random = new Random();
                        int randomNumber = random.Next(9999, 999999);
                        fileName = "AttendanceSheet" + randomNumber.ToString() + Path.GetExtension(fileName);
                        cicigTraining.AttendanceAttachment = Path.Combine("/Documents/Training" + cicigTraining.TrainingTitleId + "/AttendanceSheet/" + fileName);//Server Path
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
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + cicigTraining.TrainingTitleId + "\\Report\\");
                        string fileName = Path.GetFileName(ReportAttachment.FileName);
                        Random random = new Random();
                        int randomNumber = random.Next(9999, 999999);
                        fileName = "Report" + randomNumber.ToString() + Path.GetExtension(fileName);
                        cicigTraining.ReportAttachment = Path.Combine("/Documents/Training" + cicigTraining.TrainingTitleId + "/Report/" + fileName);//Server Path
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
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + cicigTraining.TrainingTitleId + "\\SessionPlan\\");
                        string fileName = Path.GetFileName(SessionPlanAttachment.FileName);
                        Random random = new Random();
                        int randomNumber = random.Next(9999, 999999);
                        fileName = "SessionPlan" + randomNumber.ToString() + Path.GetExtension(fileName);
                        cicigTraining.SessionPlanAttachment = Path.Combine("/Documents/Training" + cicigTraining.TrainingTitleId + "/SessionPlan/" + fileName);//Server Path
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
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + cicigTraining.TrainingTitleId + "\\Pictures\\");
                        string fileName = Path.GetFileName(PictureAttachment1.FileName);
                        Random random = new Random();
                        int randomNumber = random.Next(9999, 999999);
                        fileName = "Picture" + randomNumber.ToString() + Path.GetExtension(fileName);
                        cicigTraining.PictureAttachment1 = Path.Combine("/Documents/Training" + cicigTraining.TrainingTitleId + "/Pictures/" + fileName);//Server Path
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
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + cicigTraining.TrainingTitleId + "\\Pictures\\");
                        string fileName = Path.GetFileName(PictureAttachment2.FileName);
                        Random random = new Random();
                        int randomNumber = random.Next(9999, 999999);
                        fileName = "Picture" + randomNumber.ToString() + Path.GetExtension(fileName);
                        cicigTraining.PictureAttachment2 = Path.Combine("/Documents/Training" + cicigTraining.TrainingTitleId + "/Pictures/" + fileName);//Server Path
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
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + cicigTraining.TrainingTitleId + "\\Pictures\\");
                        string fileName = Path.GetFileName(PictureAttachment3.FileName);
                        Random random = new Random();
                        int randomNumber = random.Next(9999, 999999);
                        fileName = "Picture" + randomNumber.ToString() + Path.GetExtension(fileName);
                        cicigTraining.PictureAttachment3 = Path.Combine("/Documents/Training" + cicigTraining.TrainingTitleId + "/Pictures/" + fileName);//Server Path
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
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\Training" + cicigTraining.TrainingTitleId + "\\Pictures\\");
                        string fileName = Path.GetFileName(PictureAttachment4.FileName);
                        Random random = new Random();
                        int randomNumber = random.Next(9999, 999999);
                        fileName = "Picture" + randomNumber.ToString() + Path.GetExtension(fileName);
                        cicigTraining.PictureAttachment4 = Path.Combine("/Documents/Training" + cicigTraining.TrainingTitleId + "/Pictures/" + fileName);//Server Path
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
                    //cicigTraining.District = _context.Districts.Find(cicigTraining.District);
                    _context.Update(cicigTraining);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CICIGTrainingsExists(cicigTraining.CICIGTrainingsId))
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


            ViewData["SectionId"] = new MultiSelectList(_context.Sections/*.Where(a => a.SectionId == 2)*/, "SectionId", "Name");
            //ViewData["SectionId"] = new SelectList(_context.Sections.Where(a => a.SectionId == 2), "SectionId", "Name");

            ViewData["TrainerId"] = new MultiSelectList(_context.Trainers/*.Where(a => a.SectionId == 2)*/, "TrainerId", "TrainerName", cicigTraining.CICIGTrainingTrainers.Select(t => t.TrainerId));
            //ViewData["TrainerId"] = new SelectList(_context.Trainers.Where(a => a.SectionId == 2), "TrainerId", "TrainerName", cicigTraining.TrainerId);
            ViewData["TrainingHeadId"] = new SelectList(_context.TrainingHeads, "TrainingHeadId", "TrainingHeadName", TrainingHeadId);
            ViewData["TrainingTitleId"] = new SelectList(_context.TrainingTitles.Where(a => a.TrainingHeadId == TrainingHeadId), "TrainingTitleId", "TrainingTypeName", TrainingHeadId);
            ViewData["VillageId"] = new SelectList(_context.Villages.Where(a => a.UnionCouncilId == cicigTraining.Village.UnionCouncilId), "VillageId", "Name", cicigTraining.VillageId);
            ViewData["PhaseId"] = new SelectList(_context.Phases, "PhaseId", "Name", cicigTraining.Phase);
            return View(cicigTraining);
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
        // GET: CICIGTrainingss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CICIGTrainings == null)
            {
                return NotFound();
            }

            var cicigTraining = await _context.CICIGTrainings
                .Include(m => m.CICIGTrainingTrainers)
                .Include(m => m.TrainingTitle)
                .FirstOrDefaultAsync(m => m.CICIGTrainingsId == id);
            if (cicigTraining == null)
            {
                return NotFound();
            }

            return View(cicigTraining);
        }

        // POST: CICIGTrainingss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CICIGTrainings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CICIGTrainings'  is null.");
            }
            var cicigTraining = await _context.CICIGTrainings.FindAsync(id);
            if (cicigTraining != null)
            {

                _context.Database.ExecuteSqlRaw("delete [Training].[CITrainingMember] where CICIGTrainingsId=" + cicigTraining.CICIGTrainingsId);

                _context.CICIGTrainings.Remove(cicigTraining);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CICIGTrainingsExists(int id)
        {
            return _context.CICIGTrainings.Any(e => e.CICIGTrainingsId == id);
        }
    }
}
