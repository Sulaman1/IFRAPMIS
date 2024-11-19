using BAL.IRepository.SocialMobilization;
using DAL.Models;
using DAL.Models.Domain.MasterSetup;
using DAL.Models.Domain.SocialMobilization;
using DAL.Models.Domain.SocialMobilization.Training;
using IFRAPMIS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static IFRAPMIS.Controllers.SocialMobilization.Training.CITrainingMemberController;

namespace IFRAPMIS.Controllers.SocialMobilization
{
    public class CICIGController : Controller
    {
        private readonly ICICIG _context;
        private readonly ApplicationDbContext _context0;
        private readonly UserManager<ApplicationUser> _userManager;

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

        public CICIGController(ICICIG context, ApplicationDbContext context1, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _context0 = context1;
            _userManager = userManager;
        }

        public async Task<IActionResult> TrackMember(int id)
        {
            var designation = new[]
                        {
                            new { DesignationId = 1, DesignationName = "Manager" },
                            new { DesignationId = 2, DesignationName = "Engineer" },
                            new { DesignationId = 3, DesignationName = "Technician" }
                        };
            // Create the SelectList and pass it to ViewData
            ViewData["DesignationId"] = new SelectList(designation, "DesignationId", "DesignationName", "BeneficiaryVerified");

            ViewBag.CICIGId = id;
            return View();
        }
        public async Task<JsonResult> AjaxMemberInformation(string id, int CicigId)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var cicigForCode = _context0.CICIGs.Where(c => c.CICIGId == CicigId)
                                                .Select(c => c.Code)
                                                .FirstOrDefault();

            var info = _context0.BeneficiaryVerifieds                                                                        
                            .Where(a => a.CNIC == id /*&& a.BeneficiaryVerified.BeneficiaryTypeId == 1*/)
                            .FirstOrDefault();
            if (info == null)
            {
                return new JsonResult(new { isValid = false, message = "No data found" });
            }
           
            return Json(new { isValid = true, info, CicigId = cicigForCode });
        }

        public async Task<IActionResult> _Index(int id)
        {
            var applicationDbContext = await _context0.CIMembers      
                                                .Include(cim => cim.BeneficiaryVerified)
                                                .Where(a => a.CICIGId == id)
                                                .ToListAsync();

            var ciTrainMember = applicationDbContext;
            return PartialView(ciTrainMember);
        }
        public async Task<JsonResult> AddBeneficiary(int BenVerifiedId, int CicigId, string DesignationId)
        {
            var miscode = _context0.CICIGs.Where(c => c.CICIGId == CicigId).Select(c => c.Code).FirstOrDefault();            
            var result = _context0.CIMembers.Count(a => a.BeneficiaryVerified.BeneficiaryVerifiedId == BenVerifiedId);

            if (BenVerifiedId == 0 || CicigId == 0)
            {
                return Json(new { isValid = false, message = "Failed to Add BeneficiaryVerified!" });
            }
            else if (result > 0)
            {
                return Json(new { isValid = false, message = "Selected member is already added!" });
            }
            else
            {
                if (_context0.CIMembers.Count() == 0)
                {
                    CIMember obj = new CIMember();
                    obj.MemberCode = miscode + "-1";
                    obj.BeneficiaryVerifiedId = BenVerifiedId;
                    obj.CICIGId = CicigId;
                    //obj.CreatedOn = DateTime.Today.Date;
                    _context0.Add(obj);
                    await _context0.SaveChangesAsync();
                }
                else 
                {
                    //string mcode = _context0.CIMembers.Last().MemberCode;                    
                    string mcode = _context0.CIMembers
                                    .OrderByDescending(m => m.CIMemberId) // Replace MemberId with your unique identifier
                                    .Select(m => m.MemberCode)
                                    .FirstOrDefault() ?? string.Empty;

                    CIMember obj = new CIMember();
                    //obj.MemberCode = Convert.ToString(Convert.ToInt32(miscode.Split('-')[0].Trim())+1);
                    if (!string.IsNullOrEmpty(mcode) && mcode.Count(c => c == '-') >= 2)
                    {
                        var parts = mcode.Split('-');

                        // Ensure the last part is numeric before converting and incrementing
                        if (int.TryParse(parts[^1].Trim(), out int lastNumber))
                        {
                            // Increment the last number
                            int incrementedNumber = lastNumber + 1;

                            // Format the MemberCode, keeping the prefix and middle part intact
                            obj.MemberCode = $"{parts[0]}-{parts[1]}-{incrementedNumber}";
                        }
                        else
                        {
                            // Handle the case where the last part is not a valid integer
                            obj.MemberCode = "Invalid Code"; // Example fallback value
                        }
                    }
                    else
                    {
                        // Handle the case where miscode is null, empty, or doesn't contain the expected format
                        obj.MemberCode = "Invalid Code"; // Example fallback value
                    }



                    obj.BeneficiaryVerifiedId = BenVerifiedId;
                    obj.CICIGId = CicigId;
                    //obj.CreatedOn = DateTime.Today.Date;
                    _context0.Add(obj);
                    await _context0.SaveChangesAsync();
                }
                
            }
            return Json(new { isValid = true, message = "BeneficiaryVerified has been added successfully." });
        }

        public async Task<IActionResult> CDSummaryView()
        {
            ViewData["DistrictId"] = new SelectList(await _context.GetAllDistrict(), "DistrictName", "DistrictName");
            ViewData["CommunityTypeId"] = new SelectList(await _context.GetCommunityTypes(), "CommunityTypeId", "Name");
            return View();
        }///Views/CICIG/Components/CDSummary/CDSummary.cshtml
        public IActionResult ReloadCDSummary(int DId, int TId, int UCId, int CTId)
        {
            return ViewComponent("CDSummary", new { DId, TId, UCId, CTId });
        }

        // GET: CICIGs
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.Heading = (id == 1) ? "Community Institutions" : "Common Interest Groups";
            ViewBag.Id = id;
            //-----------------------------------------------
            var applicationDbContext = await _context.GetAll(id, HttpContext.User);
            return View(applicationDbContext);
        }
        public async Task<IActionResult> SubmittedForReviewIndex(int id)
        {
            ViewBag.Heading = (id == 1) ? "Community Institutions" : "Common Interest Groups";
            ViewBag.Id = id;
            return View(await _context.GetAllSubmittedForReview(id, HttpContext.User));
        }
        public async Task<IActionResult> SubmittedForVerifyIndex(int id)
        {
            ViewBag.Heading = (id == 1) ? "Community Institutions" : "Common Interest Groups";
            ViewBag.Id = id;
            return View(await _context.GetAllSubmittedForVerify(id, HttpContext.User));
        }
        public async Task<IActionResult> VerifiedIndex(int id)
        {
            ViewBag.Heading = (id == 1) ? "Community Institutions" : "Common Interest Groups";
            ViewBag.Id = id;
            return View(await _context.GetAllVerified(id, HttpContext.User));
        }
        // GET: CICIGs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context == null)
            {
                return NotFound();
            }

            var communityInstitution = await _context.GetById(id);
            if (communityInstitution == null)
            {
                return NotFound();
            }
            ViewBag.Id = communityInstitution.CommunityTypeId;
            return View(communityInstitution);
        }
        public async Task<IActionResult> SubmittedDetails(int? id, int c)
        {
            if (id == null || _context == null)
            {
                return NotFound();
            }

            var communityInstitution = await _context.GetByIdSubmittedDetails(id);
            if (communityInstitution == null)
            {
                return RedirectToAction("SubmittedForReviewIndex", new { id = c });
            }

            return View(communityInstitution);
        }
        public async Task<IActionResult> VerifiedDetails(int? id, int c)
        {
            if (id == null || _context == null)
            {
                return NotFound();
            }

            var communityInstitution = await _context.GetByIdVerifiedDetails(id);
            if (communityInstitution == null)
            {
                return RedirectToAction("SubmittedForVerifyIndex", new { id = c });
            }

            return View(communityInstitution);
        }
        public async Task<JsonResult> CISubmitForReviewRequest(int id)
        {
            var status = await _context.CISubmitForReviewRequest(id, User.Identity.Name);
            if (status)
            {
                return Json(new { isValid = true, message = "CI/CIG has been submitted successfully for review." });
            }
            else
            {
                return Json(new { isValid = false, message = "Failed to Submit CI/CIG!" });
            }
        }
        public async Task<JsonResult> CIRejectdRequest(int id, int val, string description)
        {
            var status = await _context.CIApprovalRequest(id, val, User.Identity.Name, description);
            string message = "";
            if (status)
            {
                message = "CI/CIG has been Rejected successfully.";
                return Json(new { isValid = status, message = message });
            }
            else
            {
                return Json(new { isValid = status, message = "Failed to Reject CI/CIG!" });
            }
        }
        public async Task<JsonResult> CIApprovalRequest(int id, int val, string description)
        {
            var status = await _context.CIApprovalRequest(id, val, User.Identity.Name, description);
            string message = "";
            if (status)
            {
                message = "CI/CIG has been approved successfully.";
                return Json(new { isValid = status, message = message });
            }
            else
            {
                return Json(new { isValid = status, message = "Failed to Submit CI/CIG!" });
            }
        }
        public async Task<JsonResult> CISubmitForApprovalRequest(int id, int val, string description)
        {
            var status = await _context.CISubmitForApprovalRequest(id, val, User.Identity.Name, description);
            string message = "";
            if (status)
            {
                message = "CI/CIG has been Submitted for approval successfully.";
                return Json(new { isValid = status, message = message });
            }
            else
            {
                return Json(new { isValid = status, message = "CI/CIG has been submitted successfully for approval." });
            }
        }
        public async Task<JsonResult> GetTehsils(string districtName)
        {
            List<Tehsil> tehsils = await _context.GetAllTehsilByDistrictName(districtName);
            var tehsilList = tehsils.Select(m => new SelectListItem()
            {
                Text = m.TehsilName.ToString(),
                Value = m.TehsilId.ToString(),
            });
            return Json(tehsilList);
        }

        public async Task<JsonResult> GetUCs(int tehsilId)
        {
            List<UnionCouncil> unionCouncils = await _context.GetAllUCByTehsilId(tehsilId);
            var UCList = unionCouncils.Select(m => new SelectListItem()
            {
                Text = m.UnionCouncilName.ToString(),
                Value = m.UnionCouncilId.ToString(),
            });
            return Json(UCList);
        }
        public async Task<JsonResult> GetVillages(int ucId)
        {
            List<Village> villages = await _context.GetAllVillageByUCId(ucId);
            var VillageList = villages.Select(m => new SelectListItem()
            {
                Text = m.VillageName.ToString(),
                Value = m.VillageId.ToString(),
            });
            return Json(VillageList);
        }
        // GET: CICIGs/detail
        public async Task<IActionResult> Create(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            ViewBag.Heading = (id == 1) ? "Community Institutions" : "Common Interest Groups";
            //-----------------------------------------------                        
            ViewData["District"] = new SelectList(await _context.GetDistricts(HttpContext.User), "DistrictName", "DistrictName");
            ViewData["PhaseId"] = new SelectList(_context0.Phases, "PhaseId", "Name");
            //-----------------------------------------------            
            CICIG obj = new CICIG();
            obj.CommunityTypeId = id;
            obj.DateOfCreation = DateTime.Today.Date;
            var currentUser = _context.GetCurrentUser(HttpContext.User);
            obj.EntryBy = currentUser.Result.UserName + " " + currentUser.Result.LastName;
            return View(obj);
        }

        // POST: CICIGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, CICIG communityInstitution, IFormFile SelectionFormAttachment, IFormFile VillageProfileAttachment, IFormFile TOPAttachment)
        {
            if (communityInstitution.CommunityTypeId == 0)
            {
                return NotFound();
            }
            ViewBag.Heading = (communityInstitution.CommunityTypeId == 1) ? "Community Institutions" : "Common Interest Groups";
            if (SelectionFormAttachment != null && SelectionFormAttachment.Length > 0)
            {
                if (Path.GetExtension(SelectionFormAttachment.FileName) != ".pdf")
                {
                    ModelState.AddModelError(nameof(communityInstitution.SelectionFormAttachment), "Please attach only Pdf file format.");
                }
            }
            if (VillageProfileAttachment != null && VillageProfileAttachment.Length > 0)
            {
                if (Path.GetExtension(VillageProfileAttachment.FileName) != ".pdf")
                {
                    ModelState.AddModelError(nameof(communityInstitution.VillageProfileAttachment), "Please attach only Pdf file format.");
                }
            }
            if (TOPAttachment != null && TOPAttachment.Length > 0)
            {
                if (Path.GetExtension(TOPAttachment.FileName) != ".pdf")
                {
                    ModelState.AddModelError(nameof(communityInstitution.TOPAttachment), "Please attach only Pdf file format.");
                }
            }
            if (ModelState.IsValid)
            {
                if (SelectionFormAttachment != null && SelectionFormAttachment.Length > 0)
                {
                    Random random = new Random();
                    int randomNumber1 = random.Next(999, 100000);
                    var rootPath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\CD" + communityInstitution.District + "\\SeletionForm" + randomNumber1.ToString() + "\\");
                    string fileName = Path.GetFileName(SelectionFormAttachment.FileName);
                    int randomNumber2 = random.Next(999, 100000);
                    fileName = "SeletionForm" + randomNumber2.ToString() + Path.GetExtension(fileName);
                    communityInstitution.SelectionFormAttachment = Path.Combine("/Documents/CD" + communityInstitution.District + "/SeletionForm" + randomNumber1.ToString() + "/" + fileName);//Server Path
                    string sPath = Path.Combine(rootPath);
                    if (!System.IO.Directory.Exists(sPath))
                    {
                        System.IO.Directory.CreateDirectory(sPath);
                    }
                    string FullPathWithFileName = Path.Combine(sPath, fileName);
                    using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                    {
                        await SelectionFormAttachment.CopyToAsync(stream);
                    }
                }
                if (VillageProfileAttachment != null && VillageProfileAttachment.Length > 0)
                {
                    Random random = new Random();
                    int randomNumber1 = random.Next(999, 100000);
                    var rootPath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\CD" + communityInstitution.District + "\\VillageProfile" + randomNumber1.ToString() + "\\");
                    string fileName = Path.GetFileName(VillageProfileAttachment.FileName);
                    int randomNumber2 = random.Next(999, 100000);
                    fileName = "VillageProfile" + randomNumber2.ToString() + Path.GetExtension(fileName);
                    communityInstitution.VillageProfileAttachment = Path.Combine("/Documents/CD" + communityInstitution.District + "/VillageProfile" + randomNumber1.ToString() + "/" + fileName);//Server Path
                    string sPath = Path.Combine(rootPath);
                    if (!System.IO.Directory.Exists(sPath))
                    {
                        System.IO.Directory.CreateDirectory(sPath);
                    }
                    string FullPathWithFileName = Path.Combine(sPath, fileName);
                    using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                    {
                        await VillageProfileAttachment.CopyToAsync(stream);
                    }
                }
                if (TOPAttachment != null && TOPAttachment.Length > 0)
                {
                    Random random = new Random();
                    int randomNumber1 = random.Next(999, 100000);
                    var rootPath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot\\Documents\\CD" + communityInstitution.District + "\\TOP" + randomNumber1.ToString() + "\\");
                    string fileName = Path.GetFileName(TOPAttachment.FileName);
                    int randomNumber2 = random.Next(999, 100000);
                    fileName = "TOP" + randomNumber2.ToString() + Path.GetExtension(fileName);
                    communityInstitution.TOPAttachment = Path.Combine("/Documents/CD" + communityInstitution.District + "/TOP" + randomNumber1.ToString() + "/" + fileName);//Server Path
                    string sPath = Path.Combine(rootPath);
                    if (!System.IO.Directory.Exists(sPath))
                    {
                        System.IO.Directory.CreateDirectory(sPath);
                    }
                    string FullPathWithFileName = Path.Combine(sPath, fileName);
                    using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                    {
                        await TOPAttachment.CopyToAsync(stream);
                    }
                }
                communityInstitution.IsRejected = false;
                communityInstitution.IsReviewed = false;
                communityInstitution.IsSubmittedForReview = false;
                communityInstitution.IsVerified = false;
                communityInstitution.IsApproved = false;

                await _context.Insert(communityInstitution);
                return RedirectToAction(nameof(Index), new { id = communityInstitution.CommunityTypeId });
            }
            //-----------------------------------------------
            var districtAccess = await _context.GetDistricts(HttpContext.User);
            ViewData["District"] = new SelectList(districtAccess, "DistrictName", "DistrictName", communityInstitution.District);
            //----------------------------------------------- 
            ViewData["Tehsil"] = new SelectList(await _context.GetAllTehsilByDistrictName(communityInstitution.District), "TehsilId", "TehsilName", Convert.ToInt32(communityInstitution.Tehsil));
            ViewData["UnionCouncil"] = new SelectList(await _context.GetAllUCByTehsilId(Convert.ToInt32(communityInstitution.Tehsil)), "UnionCouncilId", "UnionCouncilName", communityInstitution.Village.UnionCouncilId);
            ViewData["VillageId"] = new SelectList(await _context.GetAllVillageByUCId(communityInstitution.Village.UnionCouncilId), "VillageId", "VillageName", communityInstitution.VillageId);
            ViewData["PhaseId"] = new SelectList(_context0.Phases, "PhaseId", "Name", communityInstitution.Phase);
            return View(communityInstitution);
        }

        // GET: CICIGs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context == null)
            {
                return NotFound();
            }
            var communityInstitution = await _context.GetById(id);
            if (communityInstitution == null)
            {
                return NotFound();
            }
            if (communityInstitution.CommunityTypeId == 1)
            {
                ViewBag.Heading = "Community Institutions";
            }
            else
            {
                ViewBag.Heading = "Common Interest Groups";
            }
            //-----------------------------------------------
            var districtAccess = await _context.GetDistricts(HttpContext.User);
            ViewData["District"] = new SelectList(districtAccess, "DistrictName", "DistrictName", communityInstitution.District);
            //----------------------------------------------- 
            ViewData["Tehsil"] = new SelectList(await _context.GetAllTehsilByDistrictName(communityInstitution.District), "TehsilId", "TehsilName", Convert.ToInt32(communityInstitution.Tehsil));
            ViewData["UnionCouncil"] = new SelectList(await _context.GetAllUCByTehsilId(Convert.ToInt32(communityInstitution.Tehsil)), "UnionCouncilId", "UnionCouncilName", communityInstitution.Village.UnionCouncilId);
            ViewData["VillageId"] = new SelectList(await _context.GetAllVillageByUCId(communityInstitution.Village.UnionCouncilId), "VillageId", "VillageName", communityInstitution.VillageId);
            ViewData["PhaseId"] = new SelectList(_context0.Phases, "PhaseId", "Name", communityInstitution.Phase);

            //ViewData["DistrictId"] = new SelectList(await _context.GetDistricts(HttpContext.User), "DistrictId", "Name", communityInstitution.District);
            //ViewData["TehsilId"] = new SelectList(await _context.GetAllTehsilByDistrictName(communityInstitution.District), "TehsilId", "TehsilName", communityInstitution.Village.UnionCouncils.TehsilId);
            //ViewData["UnionCouncilId"] = new SelectList(await _context.GetAllUCByTehsilId(communityInstitution.Village.UnionCouncils.TehsilId), "UnionCouncilId", "UnionCouncilName", communityInstitution.Village.UnionCouncilId);
            //ViewData["VillageId"] = new SelectList(await _context.GetAllVillageByUCId(communityInstitution.Village.UnionCouncilId), "VillageId", "Name", communityInstitution.VillageId);
            //ViewData["PhaseId"] = new SelectList(_context0.Phases, "PhaseId", "Name", communityInstitution.Phase);
            return View(communityInstitution);
        }

        // POST: CICIGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CICIG communityInstitution, IFormFile SelectionFormAttachment, IFormFile VillageProfileAttachment, IFormFile TOPAttachment, int IsUnverifed)
        {
            if (id != communityInstitution.CICIGId)
            {
                return NotFound();
            }
            //int district = _context0.Districts.Find(d => d.DistrictName == communityInstitution.District);
            int DistrictId = _context0.Districts
                                    .FirstOrDefault(d => d.DistrictName == communityInstitution.District)?
                                    .DistrictId ?? 0;

            if (ModelState.IsValid)
            {
                try
                {
                    if (IsUnverifed == 1)
                    {
                        communityInstitution.IsVerified = false;
                    }
                    else if (IsUnverifed == 2)
                    {
                        //communityInstitution.IsReviewed = false;
                        communityInstitution.IsVerified = false;
                    }
                    else if (IsUnverifed == 3)
                    {
                        //communityInstitution.IsReviewed = false;
                        communityInstitution.IsVerified = false;
                        //communityInstitution.IsSubmittedForReview = false;
                    }
                    if (SelectionFormAttachment != null && SelectionFormAttachment.Length > 0)
                    {
                        Random random = new Random();
                        int randomNumber1 = random.Next(999, 100000);
                        var rootPath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\CD" + DistrictId.ToString() + "\\SeletionForm" + randomNumber1.ToString() + "\\");
                        string fileName = Path.GetFileName(SelectionFormAttachment.FileName);
                        int randomNumber2 = random.Next(999, 100000);
                        fileName = "SeletionForm" + randomNumber2.ToString() + Path.GetExtension(fileName);
                        communityInstitution.SelectionFormAttachment = Path.Combine("/Documents/CD" + DistrictId.ToString() + "/SeletionForm" + randomNumber1.ToString() + "/" + fileName);//Server Path
                        string sPath = Path.Combine(rootPath);
                        if (!System.IO.Directory.Exists(sPath))
                        {
                            System.IO.Directory.CreateDirectory(sPath);
                        }
                        string FullPathWithFileName = Path.Combine(sPath, fileName);
                        using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                        {
                            await SelectionFormAttachment.CopyToAsync(stream);
                        }
                    }
                    if (VillageProfileAttachment != null && VillageProfileAttachment.Length > 0)
                    {
                        Random random = new Random();
                        int randomNumber1 = random.Next(999, 100000);
                        var rootPath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\CD" + DistrictId.ToString() + "\\VillageProfile" + randomNumber1.ToString() + "\\");
                        string fileName = Path.GetFileName(VillageProfileAttachment.FileName);
                        int randomNumber2 = random.Next(999, 100000);
                        fileName = "VillageProfile" + randomNumber2.ToString() + Path.GetExtension(fileName);
                        communityInstitution.VillageProfileAttachment = Path.Combine("/Documents/CD" + DistrictId.ToString() + "/VillageProfile" + randomNumber1.ToString() + "/" + fileName);//Server Path
                        string sPath = Path.Combine(rootPath);
                        if (!System.IO.Directory.Exists(sPath))
                        {
                            System.IO.Directory.CreateDirectory(sPath);
                        }
                        string FullPathWithFileName = Path.Combine(sPath, fileName);
                        using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                        {
                            await VillageProfileAttachment.CopyToAsync(stream);
                        }
                    }
                    if (TOPAttachment != null && TOPAttachment.Length > 0)
                    {
                        Random random = new Random();
                        int randomNumber1 = random.Next(999, 100000);
                        var rootPath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\Documents\\CD" + DistrictId.ToString() + "\\TOP" + randomNumber1.ToString() + "\\");
                        string fileName = Path.GetFileName(TOPAttachment.FileName);
                        int randomNumber2 = random.Next(999, 100000);
                        fileName = "TOP" + randomNumber2.ToString() + Path.GetExtension(fileName);
                        communityInstitution.TOPAttachment = Path.Combine("/Documents/CD" + DistrictId.ToString() + "/TOP" + randomNumber1.ToString() + "/" + fileName);//Server Path
                        string sPath = Path.Combine(rootPath);
                        if (!System.IO.Directory.Exists(sPath))
                        {
                            System.IO.Directory.CreateDirectory(sPath);
                        }
                        string FullPathWithFileName = Path.Combine(sPath, fileName);
                        using (var stream = new FileStream(FullPathWithFileName, FileMode.Create))
                        {
                            await TOPAttachment.CopyToAsync(stream);
                        }
                    }
                    //communityInstitution.District = _context0.Districts.Find(DistrictId).DistrictName;
                    
                    _context0.Update(communityInstitution);
                    _context0.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CICIGExists(communityInstitution.CICIGId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = communityInstitution.CommunityTypeId });
            }
            ViewBag.Heading = (id == 1) ? "Community Institutions" : "Common Interest Groups";

            var districtAccess = await _context.GetDistricts(HttpContext.User);
            ViewData["District"] = new SelectList(districtAccess, "DistrictName", "DistrictName", communityInstitution.District);
            //----------------------------------------------- 
            ViewData["Tehsil"] = new SelectList(await _context.GetAllTehsilByDistrictName(communityInstitution.District), "TehsilId", "TehsilName", Convert.ToInt32(communityInstitution.Tehsil));
            ViewData["UnionCouncil"] = new SelectList(await _context.GetAllUCByTehsilId(Convert.ToInt32(communityInstitution.Tehsil)), "UnionCouncilId", "UnionCouncilName", Convert.ToInt32(communityInstitution.UnionCouncil));
            ViewData["VillageId"] = new SelectList(await _context.GetAllVillageByUCId(Convert.ToInt32(communityInstitution.UnionCouncil)), "VillageId", "VillageName", communityInstitution.VillageId);
            ViewData["PhaseId"] = new SelectList(_context0.Phases, "PhaseId", "Name", communityInstitution.Phase);

           return View(communityInstitution);
        }
        // GET: CICIGs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context == null)
            {
                return NotFound();
            }

            var communityInstitution = await _context.GetById(id);
            if (communityInstitution == null)
            {
                return NotFound();
            }

            return View(communityInstitution);
        }
        // POST: CICIGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CICIG'  is null.");
            }
            var communityInstitution = await _context.GetById(id);
            if (communityInstitution != null)
            {
                _context.Remove(communityInstitution);
            }

            return RedirectToAction(nameof(Index));
        }
        private bool CICIGExists(int id)
        {
            return _context.Exist(id);
        }
    }
}
